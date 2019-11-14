/* 
 * Generated on 5/30/2014 1:58:41 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 * Required Assemblies:
 * System.Runtime.Serialization
 * CSV2Core
 * CSV2Core_MySQL
 */
using System;
using System.Data.Common;
using CSV2Core.Core;
using System.Runtime.Serialization;

namespace CL3_BookingAccounts.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Create_Accounting_Transaction_with_BookingLines.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Create_Accounting_Transaction_with_BookingLines
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L3BA_CATwBL_1315 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            #region Create new Accounting Transaction
            
            var accountingTransaction = new CL1_ACC_BOK.ORM_ACC_BOK_Accounting_Transaction
            {
                ACC_BOK_Accounting_TransactionID = Guid.NewGuid(),
                TransactionType_RefID = Parameter.AccountingTransactionTypeID,
                Comment = null,
                Creation_Timestamp = DateTime.Now,
                Tenant_RefID  = securityTicket.TenantID
            };
            accountingTransaction.Save(Connection, Transaction);
            
            #endregion

            #region Create booking lines

            foreach (var line in Parameter.BookingLines)
            {
                var bookingLine = new CL1_ACC_BOK.ORM_ACC_BOK_Accounting_BookingLine
                {
                    ACC_BOK_Accounting_BookingLineID = Guid.NewGuid(),
                    PartOfAccountingTransaction_RefID = accountingTransaction.ACC_BOK_Accounting_TransactionID,
                    BookingAccount_RefID = line.BookingAccountID,
                    TransactionValue = line.TransactionValue,
                    DateOfTransaction = Parameter.DateOfTransaction,
                    Currency_RefID = Parameter.CurrencyID,
                    Creation_Timestamp = DateTime.Now,
                    Tenant_RefID = securityTicket.TenantID
                };
                bookingLine.Save(Connection, Transaction);
            }

            #endregion

            returnValue.Result = accountingTransaction.ACC_BOK_Accounting_TransactionID;
            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L3BA_CATwBL_1315 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L3BA_CATwBL_1315 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L3BA_CATwBL_1315 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3BA_CATwBL_1315 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Create_Accounting_Transaction_with_BookingLines",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3BA_CATwBL_1315 for attribute P_L3BA_CATwBL_1315
		[DataContract]
		public class P_L3BA_CATwBL_1315 
		{
			[DataMember]
			public P_L3BA_CATwBL_1315a[] BookingLines { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid ACC_FiscalYearID { get; set; } 
			[DataMember]
			public Guid AccountingTransactionTypeID { get; set; } 
			[DataMember]
			public Guid CurrencyID { get; set; } 
			[DataMember]
			public DateTime DateOfTransaction { get; set; } 

		}
		#endregion
		#region SClass P_L3BA_CATwBL_1315a for attribute BookingLines
		[DataContract]
		public class P_L3BA_CATwBL_1315a 
		{
			//Standard type parameters
			[DataMember]
			public Guid BookingLinesID { get; set; } 
			[DataMember]
			public Guid BookingAccountID { get; set; } 
			[DataMember]
			public DateTime? DateOfBooking { get; set; } 
			[DataMember]
			public Decimal TransactionValue { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Create_Accounting_Transaction_with_BookingLines(,P_L3BA_CATwBL_1315 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Create_Accounting_Transaction_with_BookingLines.Invoke(connectionString,P_L3BA_CATwBL_1315 Parameter,securityTicket);
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
var parameter = new CL3_BookingAccounts.Complex.Manipulation.P_L3BA_CATwBL_1315();
parameter.BookingLines = ...;

parameter.ACC_FiscalYearID = ...;
parameter.AccountingTransactionTypeID = ...;
parameter.CurrencyID = ...;
parameter.DateOfTransaction = ...;

*/
