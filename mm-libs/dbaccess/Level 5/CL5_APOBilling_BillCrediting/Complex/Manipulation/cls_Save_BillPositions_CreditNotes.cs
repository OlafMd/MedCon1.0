/* 
 * Generated on 7/31/2014 1:44:18 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 * Required Assemblies:
 * System.Runtime.Serialization
 * CSV2Core
 * CSV2Core_MySQL
 */
using System;
using System.Linq;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using System.Runtime.Serialization;
using CL5_APOBilling_BillCrediting.Atomic.Retrieval;
using CL1_ACC_CRN;
using CL2_NumberRange.Complex.Retrieval;
using DLCore_DBCommons.Utils;
using DLCore_DBCommons.APODemand;
using CL1_BIL;

namespace CL5_APOBilling_BillCrediting.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_BillPositions_CreditNotes.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_BillPositions_CreditNotes
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5BC_SBPCN_0951 Execute(DbConnection Connection,DbTransaction Transaction,P_L5BC_SBPCN_0951 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5BC_SBPCN_0951();
            returnValue.Result = new L5BC_SBPCN_0951();
            var resultsBillReimbursements = new List<Guid>();
            
            #region Load BillPosition Credits, if exist
            var billPositionsCreditIds = cls_Get_Reimbursements_and_GrantedCreditNotes_for_BillPositions.Invoke(
                Connection,
                Transaction,
                new P_L5BC_GRaGCNfBP_1021() { BillPositionIDs = Parameter.BillPositionCredits.Select(bpc => bpc.BillPositionID).ToArray() },
                securityTicket).Result;
            #endregion

            #region Load or Create BillPosition GrantedCreditNote
            var billGrantedCreditNote = new ORM_ACC_CRN_GrantedCreditNote();
            if (billPositionsCreditIds != null && billPositionsCreditIds.Count() > 0)
            {
                #region Load GrantedCreditNote
                billGrantedCreditNote.Load(
                    Connection,
                    Transaction,
                    billPositionsCreditIds[0].ACC_CRN_GrantedCreditNoteID);
                if (billGrantedCreditNote.ACC_CRN_GrantedCreditNoteID == Guid.Empty)
                {
                    returnValue.Status = FR_Status.Error_Internal;
                    returnValue.Result = null;
                    return returnValue;
                }

                #region Load related Reimbursements to extract TotalAmount without Reimbursements linked to Parameter.BillPositions
                var grantedCreditNoteReimbursements = ORM_BIL_BillPosition_Reimbursement.Query.Search(
                    Connection,
                    Transaction,
                    new ORM_BIL_BillPosition_Reimbursement.Query()
                    {
                        ACC_CRN_GrantedCreditNote_RefID = billGrantedCreditNote.ACC_CRN_GrantedCreditNoteID,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    });
                if (grantedCreditNoteReimbursements == null || grantedCreditNoteReimbursements.Count <= 0)
                {
                    returnValue.Status = FR_Status.Error_Internal;
                    returnValue.Result = null;
                    return returnValue;
                }
                var selectedBillPositions = Parameter.BillPositionCredits.Select(bp => bp.BillPositionID).ToList();
                grantedCreditNoteReimbursements
                    = grantedCreditNoteReimbursements.Where(gcnr => !selectedBillPositions.Any(bp => bp == gcnr.BIL_BillPosition_RefID)).ToList();

                billGrantedCreditNote.CreditNote_Value = grantedCreditNoteReimbursements.Sum(gcnr => gcnr.ReimbursedValue);
                #endregion

                #endregion
            }
            else
            {
                #region Create GrantedCreditNote
                #region Get GrantedCreditNote Number
                var grantedCreditNoteNumber = cls_Get_and_Increase_IncreasingNumber_for_UsageArea.Invoke(
                    Connection,
                    Transaction,
                    new P_L2NR_GaIINfUA_1454() 
                    {
                        GlobalStaticMatchingID = EnumUtils.GetEnumDescription(ENumberRangeUsageAreaType.BillNumber)  
                    },
                    securityTicket).Result.Current_IncreasingNumber;
                #endregion

                billGrantedCreditNote.ACC_CRN_GrantedCreditNoteID = Guid.NewGuid();
                billGrantedCreditNote.CreditNote_Number = grantedCreditNoteNumber;
                billGrantedCreditNote.CreditNote_Currency_RefID = Parameter.BillPositionCredits[0].BillHeaderCurencyID;
                billGrantedCreditNote.DateOnCreditNote = DateTime.Now;
                billGrantedCreditNote.Tenant_RefID = securityTicket.TenantID;
                #endregion
            }
            #endregion

            foreach (var billPosition in Parameter.BillPositionCredits)
            {
                var billReimbursement = new ORM_BIL_BillPosition_Reimbursement();

                #region Load or Create BillPosition Reimbursement
                if (billPositionsCreditIds != null && billPositionsCreditIds.Any(bpc => bpc.BIL_BillPosition_RefID == billPosition.BillPositionID))
                {
                    #region Load Reimbursement
                    billReimbursement.Load(
                        Connection, 
                        Transaction, 
                        billPositionsCreditIds.Where(bpc => bpc.BIL_BillPosition_RefID == billPosition.BillPositionID).First().BIL_BillPosition_ReimbursementID);
                    if (billReimbursement.BIL_BillPosition_ReimbursementID == Guid.Empty)
                    {
                        returnValue.Status = FR_Status.Error_Internal;
                        returnValue.Result = null;
                        return returnValue;
                    }
                    #endregion
                }
                else
                {
                    #region Create Reimbursement
                    billReimbursement.BIL_BillPosition_RefID = billPosition.BillPositionID;
                    billReimbursement.ACC_CRN_GrantedCreditNote_RefID = billGrantedCreditNote.ACC_CRN_GrantedCreditNoteID;
                    billReimbursement.Tenant_RefID = securityTicket.TenantID;
                    #endregion
                }
                #endregion

                #region Update or Save Reimbursement and GrantedCreditNote
                billReimbursement.ReimbursedQuantity = billPosition.ReimbursedQuantity;
                billReimbursement.ReimbursedValue = billPosition.ReimbursedValue;
                var saveBillReimbursement = billReimbursement.Save(Connection, Transaction);
                if (saveBillReimbursement.Status != FR_Status.Success)
                {
                    returnValue.Status = FR_Status.Error_Internal;
                    returnValue.Result = null;
                    return returnValue;
                }
                resultsBillReimbursements.Add(billReimbursement.ACC_CRN_GrantedCreditNote_RefID);

                billGrantedCreditNote.CreditNote_Value += billReimbursement.ReimbursedValue;
                #endregion
            }

            #region Save BillPosition GrantedCreditNote
            var saveGrantedCreditNote = billGrantedCreditNote.Save(Connection, Transaction);
            if (saveGrantedCreditNote.Status != FR_Status.Success)
            {
                returnValue.Status = FR_Status.Error_Internal;
                returnValue.Result = null;
                return returnValue;
            }
            #endregion

            returnValue.Result.GrantedCreditNoteID = billGrantedCreditNote.ACC_CRN_GrantedCreditNoteID;
            returnValue.Result.BillPositionReimbursementIDs = resultsBillReimbursements.ToArray();
            returnValue.Status = FR_Status.Success;

            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5BC_SBPCN_0951 Invoke(string ConnectionString,P_L5BC_SBPCN_0951 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5BC_SBPCN_0951 Invoke(DbConnection Connection,P_L5BC_SBPCN_0951 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5BC_SBPCN_0951 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5BC_SBPCN_0951 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5BC_SBPCN_0951 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5BC_SBPCN_0951 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5BC_SBPCN_0951 functionReturn = new FR_L5BC_SBPCN_0951();
			try
			{

				if (cleanupConnection == true) 
				{
					Connection = CSV2Core_MySQL.Support.DBSQLSupport.CreateConnection(ConnectionString);
					Connection.Open();
				}
				if (cleanupTransaction == true)
				{
					Transaction = Connection.BeginTransaction();
				}

				functionReturn = Execute(Connection, Transaction,Parameter,securityTicket);

				#region Cleanup Connection/Transaction
				//Commit the transaction 
				if (cleanupTransaction == true)
				{
					Transaction.Commit();
				}
				//Close the connection
				if (cleanupConnection == true)
				{
					Connection.Close();
				}
				#endregion
			}
			catch (Exception ex)
			{
				try
				{
					if (cleanupTransaction == true && Transaction!=null)
					{
						Transaction.Rollback();
					}
				}
				catch { }

				try
				{
					if (cleanupConnection == true && Connection != null)
					{
						Connection.Close();
					}
				}
				catch { }

				throw new Exception("Exception occured in method cls_Save_BillPositions_CreditNotes",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5BC_SBPCN_0951 : FR_Base
	{
		public L5BC_SBPCN_0951 Result	{ get; set; }

		public FR_L5BC_SBPCN_0951() : base() {}

		public FR_L5BC_SBPCN_0951(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5BC_SBPCN_0951 for attribute P_L5BC_SBPCN_0951
		[DataContract]
		public class P_L5BC_SBPCN_0951 
		{
			[DataMember]
			public P_L5BC_SBPCN_0951a[] BillPositionCredits { get; set; }

			//Standard type parameters
		}
		#endregion
		#region SClass P_L5BC_SBPCN_0951a for attribute BillPositionCredits
		[DataContract]
		public class P_L5BC_SBPCN_0951a 
		{
			//Standard type parameters
			[DataMember]
			public Guid BillPositionID { get; set; } 
			[DataMember]
			public decimal ReimbursedValue { get; set; } 
			[DataMember]
			public double ReimbursedQuantity { get; set; } 
			[DataMember]
			public Guid BillHeaderCurencyID { get; set; } 

		}
		#endregion
		#region SClass L5BC_SBPCN_0951 for attribute L5BC_SBPCN_0951
		[DataContract]
		public class L5BC_SBPCN_0951 
		{
			//Standard type parameters
			[DataMember]
			public Guid GrantedCreditNoteID { get; set; } 
			[DataMember]
			public Guid[] BillPositionReimbursementIDs { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5BC_SBPCN_0951 cls_Save_BillPositions_CreditNotes(,P_L5BC_SBPCN_0951 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5BC_SBPCN_0951 invocationResult = cls_Save_BillPositions_CreditNotes.Invoke(connectionString,P_L5BC_SBPCN_0951 Parameter,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

/* Support for Parameter Invocation (Copy&Paste)
var parameter = new CL5_APOBilling_BillCrediting.Complex.Manipulation.P_L5BC_SBPCN_0951();
parameter.BillPositionCredits = ...;


*/
