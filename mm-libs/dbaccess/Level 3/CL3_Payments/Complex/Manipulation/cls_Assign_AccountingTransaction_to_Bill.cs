/* 
 * Generated on 7/10/2014 5:55:08 PM
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

namespace CL3_Payments.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Assign_AccountingTransaction_to_Bill.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Assign_AccountingTransaction_to_Bill
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L3PY_AATtB_1107 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            #region Create new Bill Header Assigned Payment entry

            var bpID = CL1_USR.ORM_USR_Account.Query.Search(Connection, Transaction,
                new CL1_USR.ORM_USR_Account.Query
                {
                    USR_AccountID = securityTicket.AccountID,
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID,
                }).Single().BusinessParticipant_RefID;

            var assignedPayment = new CL1_BIL.ORM_BIL_BillHeader_AssignedPayment
            {
                BIL_BillHeader_AssignedPaymentID = Guid.NewGuid(),
                AssignedBy_BusinessParticipant_RefID = bpID,
                BIL_BillHeader_RefID = Parameter.BillHeaderID,
                ACC_BOK_AccountingTransaction_RefID = Parameter.AccountTransactionID,
                AssignedValue = Parameter.AssignedAmount,
                Tenant_RefID = securityTicket.TenantID,
                Creation_Timestamp = DateTime.Now
            };
            assignedPayment.Save(Connection, Transaction);

            #endregion

            #region Assign accunting transaction to installments

            var installmentPlan = CL1_BIL.ORM_BIL_BillHeader_2_InstallmentPlan.Query.Search(Connection, Transaction, new
                CL1_BIL.ORM_BIL_BillHeader_2_InstallmentPlan.Query
            {
                BIL_BillHeader_RefID = Parameter.BillHeaderID,
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID
            }).SingleOrDefault();

            if (installmentPlan != null)
            {
                var installmentParam = new CL3_InstallmentPlans.Complex.Manipulation.P_L3IP_AATfIP_1331
                {
                    AccountingTransactionID = Parameter.AccountTransactionID,
                    InstallmentPlanID = installmentPlan.BIL_InstallmentPlan_RefID,
                    TransactionAmount = Parameter.AssignedAmount,
                    PaymentDate = Parameter.PaymentDate
                };

                CL3_InstallmentPlans.Complex.Manipulation.cls_Assign_AccountingTransaction_for_InstallmentPlan.Invoke(Connection, Transaction, installmentParam, securityTicket);
            }

            #endregion

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L3PY_AATtB_1107 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L3PY_AATtB_1107 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L3PY_AATtB_1107 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3PY_AATtB_1107 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Guid functionReturn = new FR_Guid();
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

				throw new Exception("Exception occured in method cls_Assign_AccountingTransaction_to_Bill",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3PY_AATtB_1107 for attribute P_L3PY_AATtB_1107
		[DataContract]
		public class P_L3PY_AATtB_1107 
		{
			//Standard type parameters
			[DataMember]
			public Guid BillHeaderID { get; set; } 
			[DataMember]
			public Decimal AssignedAmount { get; set; } 
			[DataMember]
			public Guid AccountTransactionID { get; set; } 
			[DataMember]
			public DateTime PaymentDate { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Assign_AccountingTransaction_to_Bill(,P_L3PY_AATtB_1107 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Assign_AccountingTransaction_to_Bill.Invoke(connectionString,P_L3PY_AATtB_1107 Parameter,securityTicket);
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
var parameter = new CL3_Payments.Complex.Manipulation.P_L3PY_AATtB_1107();
parameter.BillHeaderID = ...;
parameter.AssignedAmount = ...;
parameter.AccountTransactionID = ...;
parameter.PaymentDate = ...;

*/
