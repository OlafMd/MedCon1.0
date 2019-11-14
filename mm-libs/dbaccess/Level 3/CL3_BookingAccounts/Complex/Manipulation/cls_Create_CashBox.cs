/* 
 * Generated on 6/9/2014 4:51:16 PM
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
    /// var result = cls_Create_CashBox.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Create_CashBox
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Bool Execute(DbConnection Connection,DbTransaction Transaction,P_L3BA_CCB_1646 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_Bool();

            #region Booking account

            var bookingAccount = new CL1_ACC_BOK.ORM_ACC_BOK_BookingAccount
            {
                ACC_BOK_BookingAccountID = Guid.NewGuid(),
                BookingAccountName = Parameter.BookingAccountName,
                BookingAccountNumber = "000001",
                FiscalYear_RefID = Parameter.FiscalYearID,
                Tenant_RefID = securityTicket.TenantID
            };
            bookingAccount.Save(Connection, Transaction);

            #endregion

            #region Create Account assignment to booking account as "Bank Account"

            var accountAssignment = CL3_BookingAccounts.Utils.BookingAccountUtils.GetEmptyBankAccount();
            accountAssignment.ACC_BOK_BookingAccounts_Purpose_BP_AssignmentID = Guid.NewGuid();
            accountAssignment.BookingAccount_RefID = bookingAccount.ACC_BOK_BookingAccountID;
            accountAssignment.BusinessParticipant_RefID = Parameter.BusinessParticipantID;
            accountAssignment.Tenant_RefID = securityTicket.TenantID;

            accountAssignment.Save(Connection, Transaction);

            #endregion

            #region Bank account

            var bankAccount = new CL1_ACC_CBX.ORM_ACC_CBX_CashBox
            {
                ACC_CBX_CashBoxID = Guid.NewGuid(),
                CashBoxName = Parameter.BookingAccountName,
                CashBoxNumber = Parameter.CashBoxNumber,
                Currency_RefID = Parameter.CurrencyID,
                Tenant_RefID = securityTicket.TenantID
            };
            bankAccount.Save(Connection, Transaction);

            #endregion

            returnValue.Result = true;
            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Bool Invoke(string ConnectionString,P_L3BA_CCB_1646 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection,P_L3BA_CCB_1646 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction,P_L3BA_CCB_1646 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3BA_CCB_1646 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Bool functionReturn = new FR_Bool();
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

				throw new Exception("Exception occured in method cls_Create_CashBox",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3BA_CCB_1646 for attribute P_L3BA_CCB_1646
		[DataContract]
		public class P_L3BA_CCB_1646 
		{
			//Standard type parameters
			[DataMember]
			public Guid FiscalYearID { get; set; } 
			[DataMember]
			public Guid BookingAccountID { get; set; } 
			[DataMember]
			public Guid BusinessParticipantID { get; set; } 
			[DataMember]
			public String BookingAccountName { get; set; } 
			[DataMember]
			public String CashBoxNumber { get; set; } 
			[DataMember]
			public Guid CurrencyID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Bool cls_Create_CashBox(,P_L3BA_CCB_1646 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Bool invocationResult = cls_Create_CashBox.Invoke(connectionString,P_L3BA_CCB_1646 Parameter,securityTicket);
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
var parameter = new CL3_BookingAccounts.Complex.Manipulation.P_L3BA_CCB_1646();
parameter.FiscalYearID = ...;
parameter.BookingAccountID = ...;
parameter.BusinessParticipantID = ...;
parameter.BookingAccountName = ...;
parameter.CashBoxNumber = ...;
parameter.CurrencyID = ...;

*/
