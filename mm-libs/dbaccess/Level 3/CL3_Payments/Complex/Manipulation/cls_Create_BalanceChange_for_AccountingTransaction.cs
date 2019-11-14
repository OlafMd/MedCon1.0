/* 
 * Generated on 6/10/2014 1:31:04 PM
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
    /// var result = cls_Create_BalanceChange_for_AccountingTransaction.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Create_BalanceChange_for_AccountingTransaction
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L3PY_CBCfAT_1329 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Guid();
			
            var bookingAccount = CL1_ACC_BOK.ORM_ACC_BOK_BookingAccounts_Purpose_BP_Assignment.Query.Search(Connection, Transaction, 
                new CL1_ACC_BOK.ORM_ACC_BOK_BookingAccounts_Purpose_BP_Assignment.Query
                {
                    BookingAccount_RefID = Parameter.BookingAccountID,
                    IsDeleted = false,
                    Is_L3_BankAccount = true,
                    Tenant_RefID = securityTicket.TenantID
                }).Single();

            bool isBankAccount = bookingAccount.If_L3_AssetAccount_BankAccount_RefID != Guid.Empty;

            if (isBankAccount)
            {
                #region Bank account balance change
                
                var balanceChange = new CL1_ACC_BNK.ORM_ACC_BNK_BankAccount_BalanceChange
                {
                    ACC_BNK_BankAccount_BalanceChangeID = Guid.NewGuid(),
                    BankAccount_RefID = bookingAccount.If_L3_AssetAccount_BankAccount_RefID,
                    BalanceChange = Parameter.Amount,
                    Tenant_RefID = securityTicket.TenantID,
                };
                balanceChange.Save(Connection, Transaction);

                var balance2transaction = new CL1_ACC_BNK.ORM_ACC_BNK_BankAccountBalanceChange_2_AccountingTransaction
                {
                    AssignmentID = Guid.NewGuid(),
                    ACC_BNK_BankAccount_BalanceChange_RefID = balanceChange.ACC_BNK_BankAccount_BalanceChangeID,
                    ACC_BOK_Accounting_Transaction_RefID = Parameter.AccountingTransactionID,
                    Tenant_RefID = securityTicket.TenantID
                };
                balance2transaction.Save(Connection, Transaction);

                #endregion
            }
            else
            {
                #region Cash box balance change
                
                var balanceChange = new CL1_ACC_CBX.ORM_ACC_CBX_CashBox_BalanceChange
                {
                    ACC_CBX_CashBox_BalanceChangeID = Guid.NewGuid(),
                    CashBox_RefID = bookingAccount.If_L3_AssetAccount_CashBox_RefID,
                    BalanceChange = Parameter.Amount,
                    Tenant_RefID = securityTicket.TenantID
                };
                balanceChange.Save(Connection, Transaction);

                var cashBox2transaction = new CL1_ACC_CBX.ORM_ACC_CBX_CashBoxBalanceChange_2_AccountingTransaction
                {
                    AssignmentID = Guid.NewGuid(),
                    ACC_CBX_CashBox_BalanceChange_RefID = balanceChange.ACC_CBX_CashBox_BalanceChangeID,
                    ACC_BOK_Accounting_Transaction_RefID = Parameter.AccountingTransactionID,
                    Tenant_RefID = securityTicket.TenantID
                };
                cashBox2transaction.Save(Connection, Transaction);

                #endregion
            }
            
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L3PY_CBCfAT_1329 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L3PY_CBCfAT_1329 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L3PY_CBCfAT_1329 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3PY_CBCfAT_1329 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Create_BalanceChange_for_AccountingTransaction",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3PY_CBCfAT_1329 for attribute P_L3PY_CBCfAT_1329
		[DataContract]
		public class P_L3PY_CBCfAT_1329 
		{
			//Standard type parameters
			[DataMember]
			public Guid AccountingTransactionID { get; set; } 
			[DataMember]
			public Guid BookingAccountID { get; set; } 
			[DataMember]
			public Decimal Amount { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Create_BalanceChange_for_AccountingTransaction(,P_L3PY_CBCfAT_1329 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Create_BalanceChange_for_AccountingTransaction.Invoke(connectionString,P_L3PY_CBCfAT_1329 Parameter,securityTicket);
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
var parameter = new CL3_Payments.Complex.Manipulation.P_L3PY_CBCfAT_1329();
parameter.AccountingTransactionID = ...;
parameter.BookingAccountID = ...;
parameter.Amount = ...;

*/
