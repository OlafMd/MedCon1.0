/* 
 * Generated on 6/9/2014 1:36:11 PM
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
using CSV2Core.Core;
using System.Runtime.Serialization;
using CL5_APOBilling_Bill.Atomic.Retrieval;

namespace CL5_APOBilling_Bill.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_All_Payment_Data_for_BillHeader.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_All_Payment_Data_for_BillHeader
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5BL_GAPDfBH_1021 Execute(DbConnection Connection,DbTransaction Transaction,P_L5BL_GAPDfBH_1021 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5BL_GAPDfBH_1021();
            returnValue.Result = new L5BL_GAPDfBH_1021();

            #region Bill data
            
            var bill = CL1_BIL.ORM_BIL_BillHeader.Query.Search(Connection, Transaction,
                new CL1_BIL.ORM_BIL_BillHeader.Query
                {
                    BIL_BillHeaderID = Parameter.BillHeaderID,
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                }).Single();

            var billPaymentCondition = CL1_ACC_PAY.ORM_ACC_PAY_Condition.Query.Search(Connection, Transaction,
                new CL1_ACC_PAY.ORM_ACC_PAY_Condition.Query
                {
                    ACC_PAY_ConditionID = bill.BillHeader_PaymentCondition_RefID,
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                }).Single();

            returnValue.Result.Bill_PaymentDeadline = bill.DateOnBill.AddDays(billPaymentCondition.MaximumPaymentTreshold_InDays);
            returnValue.Result.Bill_TotalValue = bill.TotalValue_IncludingTax;

            #endregion

            #region Payments data

            bool hasInstallmentPlan = CL1_BIL.ORM_BIL_BillHeader_2_InstallmentPlan.Query.Exists(Connection, Transaction,
                new CL1_BIL.ORM_BIL_BillHeader_2_InstallmentPlan.Query
                {
                    BIL_BillHeader_RefID = Parameter.BillHeaderID,
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                });

            if (hasInstallmentPlan)
            {
                returnValue.Result.PaymentsWithInstallments = 
                    cls_Get_Payments_with_Installments_for_BillHeader.Invoke(Connection, Transaction, 
                        new P_L5BL_GPwIfBH_1009 { BillHeaderID = Parameter.BillHeaderID }, securityTicket).Result;
            }
            else
            {
                returnValue.Result.Payments =
                     cls_Get_Payments_for_BillHeader.Invoke(Connection, Transaction,
                         new P_L5BL_GPfBH_0926 { BillHeaderID = Parameter.BillHeaderID }, securityTicket).Result;
            }

            #endregion

            #region Tenant's revenue booking accounts

            Guid currentFiscalYearID = CL2_FiscalYear.Complex.Retrieval.cls_Get_Current_FiscalYear.Invoke(Connection, Transaction, securityTicket).Result.ACC_FiscalYearID;

            var tenantBPID = CL1_CMN_BPT.ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction,
                new CL1_CMN_BPT.ORM_CMN_BPT_BusinessParticipant.Query
                {
                    IfTenant_Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID,
                }).Single().CMN_BPT_BusinessParticipantID;

            var bookingAccountParam = new CL3_BookingAccounts.Atomic.Retrieval.P_L3BA_GBAPBPAfBP_1717
            {
                IsRevenueAccount = true,
                FiscalYearID = currentFiscalYearID,
                BusinessParticipantID_List = new Guid[] { tenantBPID }
            };

            returnValue.Result.BookingAccounts = CL3_BookingAccounts.Atomic.Retrieval.cls_Get_BookingAccount_Purpose_BPAssignment_for_BPID_List.Invoke(
                Connection, Transaction, bookingAccountParam, securityTicket).Result;

            #endregion

            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5BL_GAPDfBH_1021 Invoke(string ConnectionString,P_L5BL_GAPDfBH_1021 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5BL_GAPDfBH_1021 Invoke(DbConnection Connection,P_L5BL_GAPDfBH_1021 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5BL_GAPDfBH_1021 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5BL_GAPDfBH_1021 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5BL_GAPDfBH_1021 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5BL_GAPDfBH_1021 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5BL_GAPDfBH_1021 functionReturn = new FR_L5BL_GAPDfBH_1021();
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

				throw new Exception("Exception occured in method cls_Get_All_Payment_Data_for_BillHeader",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5BL_GAPDfBH_1021 : FR_Base
	{
		public L5BL_GAPDfBH_1021 Result	{ get; set; }

		public FR_L5BL_GAPDfBH_1021() : base() {}

		public FR_L5BL_GAPDfBH_1021(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5BL_GAPDfBH_1021 for attribute P_L5BL_GAPDfBH_1021
		[DataContract]
		public class P_L5BL_GAPDfBH_1021 
		{
			//Standard type parameters
			[DataMember]
			public Guid BillHeaderID { get; set; } 

		}
		#endregion
		#region SClass L5BL_GAPDfBH_1021 for attribute L5BL_GAPDfBH_1021
		[DataContract]
		public class L5BL_GAPDfBH_1021 
		{
			//Standard type parameters
			[DataMember]
			public Decimal Bill_TotalValue { get; set; } 
			[DataMember]
			public DateTime Bill_PaymentDeadline { get; set; } 
			[DataMember]
			public CL5_APOBilling_Bill.Atomic.Retrieval.L5BL_GPfBH_0926[] Payments { get; set; } 
			[DataMember]
			public CL5_APOBilling_Bill.Atomic.Retrieval.L5BL_GPwIfBH_1009[] PaymentsWithInstallments { get; set; } 
			[DataMember]
			public CL3_BookingAccounts.Atomic.Retrieval.L3BA_GBAPBPAfBP_1717[] BookingAccounts { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5BL_GAPDfBH_1021 cls_Get_All_Payment_Data_for_BillHeader(,P_L5BL_GAPDfBH_1021 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5BL_GAPDfBH_1021 invocationResult = cls_Get_All_Payment_Data_for_BillHeader.Invoke(connectionString,P_L5BL_GAPDfBH_1021 Parameter,securityTicket);
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
var parameter = new CL5_APOBilling_Bill.Complex.Retrieval.P_L5BL_GAPDfBH_1021();
parameter.BillHeaderID = ...;

*/
