/* 
 * Generated on 7/31/2014 1:44:24 PM
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
using CL1_BIL;
using CL1_CMN_BPT;
using CL5_APOBilling_Bill.Complex.Retrieval;
using CL5_APOBilling_BillCrediting.Atomic.Retrieval;

namespace CL5_APOBilling_BillCrediting.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_BillPositions_with_CreditData_for_BillHeaderID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_BillPositions_with_CreditData_for_BillHeaderID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5BC_GBPwCDfBH_1607 Execute(DbConnection Connection,DbTransaction Transaction,P_L5BC_GBPwCDfBH_1607 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5BC_GBPwCDfBH_1607();
            var result = new L5BC_GBPwCDfBH_1607();

            #region Get Bill Header
            var billHeader = new ORM_BIL_BillHeader();
            if (billHeader.Load(Connection, Transaction, Parameter.BillHeaderId).Status != FR_Status.Success)
            {
                returnValue.Status = FR_Status.Error_Internal;
                returnValue.Result = null;
                return returnValue;
            }
            #endregion

            #region Get Bill Recipiant BusinessParticipant
            var billRecipiant = new ORM_CMN_BPT_BusinessParticipant();
            if (billRecipiant.Load(Connection, Transaction, billHeader.BillRecipient_BuisnessParticipant_RefID).Status != FR_Status.Success) 
            {
                returnValue.Result = null;
                returnValue.Status = FR_Status.Error_Internal;
                return returnValue;
            } 
            #endregion

            #region Get Bill Positions
            var resultBillPositions = cls_Get_BillPositions_with_Articles_for_BillHeader.Invoke(
                Connection, 
                Transaction, 
                new P_L5BL_GBPwAfBH_1848() { BillHeaderID = Parameter.BillHeaderId }, 
                securityTicket);
            if (resultBillPositions.Status != FR_Status.Success || resultBillPositions.Result == null || resultBillPositions.Result.Count() <= 0)
            {
                returnValue.Status = FR_Status.Error_Internal;
                returnValue.Result = null;
                return returnValue;
            }
            #endregion

            #region Get Order Header (Shipment and CustomerOrderReturn)
            var resultOrderHeader = cls_Get_Shipment_and_CustomerOrderReturn_Header_for_BillPositionIDs.Invoke(
                Connection, 
                Transaction,
                new P_L5BC_GSaCORHfCP_1109()
                {
                    BillPositionIDs = resultBillPositions.Result.Select(bp => bp.BillPosition.BIL_BillPositionID).ToArray()
                }, 
                securityTicket);
            if (resultOrderHeader.Status != FR_Status.Success || resultOrderHeader.Result == null)
            {
                returnValue.Result = null;
                returnValue.Status = FR_Status.Error_Internal;
                return returnValue;
            }
            #endregion

            #region Get Bill Credit data
            var resultBillCredits = cls_Get_BillReimbursement_and_GrantedCreditNotes_for_BillPositionIDs.Invoke(
                Connection, 
                Transaction, 
                new P_L5BC_GBRaGCNfBP_1331() 
                {
                    BillPositionIDs = resultBillPositions.Result.Select(bp => bp.BillPosition.BIL_BillPositionID).ToArray()
                }, 
                securityTicket);
            if (resultBillCredits.Status != FR_Status.Success)
            {
                returnValue.Result = null;
                returnValue.Status = FR_Status.Error_Internal;
                return returnValue;
            }
            #endregion

            #region Set result
            var creditingBills = new List<L5BC_GBPwCDfBH_1607a>();
            foreach (var billPosition in resultBillPositions.Result)
            {
                var orderHeader = resultOrderHeader.Result
                    .Where(coh => coh.BIL_BillPositionID == billPosition.BillPosition.BIL_BillPositionID).FirstOrDefault();
                if (orderHeader == null)
                {
                    returnValue.Result = null;
                    returnValue.Status = FR_Status.Error_Internal;
                    return returnValue;
                }
                var billCredits = resultBillCredits.Result
                    .Where(bc => bc.BIL_BillPosition_RefID == billPosition.BillPosition.BIL_BillPositionID).FirstOrDefault();
                var creditingBill = new L5BC_GBPwCDfBH_1607a()
                {
                    BillPosition = billPosition.BillPosition,
                    Article = billPosition.Article,
                    BillCredits = billCredits ?? new L5BC_GBRaGCNfBP_1331(),
                    CustomerOrderHeaderNumber 
                        = orderHeader.LOG_SHP_Shipment_HeaderID == Guid.Empty || orderHeader.LOG_SHP_Shipment_HeaderID == null || string.IsNullOrEmpty(orderHeader.ShipmentHeader_Number)
                        ? orderHeader.CustomerOrderReturnNumber
                        : orderHeader.ShipmentHeader_Number
                };
                creditingBills.Add(creditingBill);
            }
            result.CreditingBills = creditingBills.ToArray();
            result.BillHeaderNumber = billHeader.BillNumber;
            result.BillHeaderBillRecipiantName = billRecipiant.DisplayName;
            result.BillHeaderDateOnBill = billHeader.DateOnBill;
            result.BillHeaderCurencyID = billHeader.Currency_RefID;
            returnValue.Status = FR_Status.Success;
            returnValue.Result = result;
            #endregion

            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5BC_GBPwCDfBH_1607 Invoke(string ConnectionString,P_L5BC_GBPwCDfBH_1607 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5BC_GBPwCDfBH_1607 Invoke(DbConnection Connection,P_L5BC_GBPwCDfBH_1607 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5BC_GBPwCDfBH_1607 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5BC_GBPwCDfBH_1607 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5BC_GBPwCDfBH_1607 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5BC_GBPwCDfBH_1607 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5BC_GBPwCDfBH_1607 functionReturn = new FR_L5BC_GBPwCDfBH_1607();
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

				throw new Exception("Exception occured in method cls_Get_BillPositions_with_CreditData_for_BillHeaderID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5BC_GBPwCDfBH_1607 : FR_Base
	{
		public L5BC_GBPwCDfBH_1607 Result	{ get; set; }

		public FR_L5BC_GBPwCDfBH_1607() : base() {}

		public FR_L5BC_GBPwCDfBH_1607(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5BC_GBPwCDfBH_1607 for attribute P_L5BC_GBPwCDfBH_1607
		[DataContract]
		public class P_L5BC_GBPwCDfBH_1607 
		{
			//Standard type parameters
			[DataMember]
			public Guid BillHeaderId { get; set; } 

		}
		#endregion
		#region SClass L5BC_GBPwCDfBH_1607 for attribute L5BC_GBPwCDfBH_1607
		[DataContract]
		public class L5BC_GBPwCDfBH_1607 
		{
			[DataMember]
			public L5BC_GBPwCDfBH_1607a[] CreditingBills { get; set; }

			//Standard type parameters
			[DataMember]
			public string BillHeaderNumber { get; set; } 
			[DataMember]
			public string BillHeaderBillRecipiantName { get; set; } 
			[DataMember]
			public DateTime BillHeaderDateOnBill { get; set; } 
			[DataMember]
			public Guid BillHeaderCurencyID { get; set; } 

		}
		#endregion
		#region SClass L5BC_GBPwCDfBH_1607a for attribute CreditingBills
		[DataContract]
		public class L5BC_GBPwCDfBH_1607a 
		{
			//Standard type parameters
			[DataMember]
			public string CustomerOrderHeaderNumber { get; set; } 
			[DataMember]
			public CL5_APOBilling_Bill.Atomic.Retrieval.L5BL_GBPfBH_1534 BillPosition { get; set; } 
			[DataMember]
			public CL3_Articles.Atomic.Retrieval.L3AR_GAfAL_0942 Article { get; set; } 
			[DataMember]
			public CL5_APOBilling_BillCrediting.Atomic.Retrieval.L5BC_GBRaGCNfBP_1331 BillCredits { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5BC_GBPwCDfBH_1607 cls_Get_BillPositions_with_CreditData_for_BillHeaderID(,P_L5BC_GBPwCDfBH_1607 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5BC_GBPwCDfBH_1607 invocationResult = cls_Get_BillPositions_with_CreditData_for_BillHeaderID.Invoke(connectionString,P_L5BC_GBPwCDfBH_1607 Parameter,securityTicket);
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
var parameter = new CL5_APOBilling_BillCrediting.Complex.Retrieval.P_L5BC_GBPwCDfBH_1607();
parameter.BillHeaderId = ...;

*/
