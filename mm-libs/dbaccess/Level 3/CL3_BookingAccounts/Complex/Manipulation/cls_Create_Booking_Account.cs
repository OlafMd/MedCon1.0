/* 
 * Generated on 7/1/2014 1:54:34 PM
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
    /// var result = cls_Create_Booking_Account.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Create_Booking_Account
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L3BA_CBA_1305 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_Guid();

            var bookingAccount = new CL1_ACC_BOK.ORM_ACC_BOK_BookingAccount
            {
                ACC_BOK_BookingAccountID = Guid.NewGuid(),
                BookingAccountName = Parameter.BookingAccountName,
                BookingAccountNumber = Parameter.BookingAccountNumber,
                FiscalYear_RefID = Parameter.FiscalYearID,
                Creation_Timestamp = DateTime.Now,
                Tenant_RefID = securityTicket.TenantID
            };
            bookingAccount.Save(Connection, Transaction);

            returnValue.Result = bookingAccount.ACC_BOK_BookingAccountID;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L3BA_CBA_1305 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L3BA_CBA_1305 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L3BA_CBA_1305 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3BA_CBA_1305 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Create_Booking_Account",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3BA_CBA_1305 for attribute P_L3BA_CBA_1305
		[DataContract]
		public class P_L3BA_CBA_1305 
		{
			//Standard type parameters
			[DataMember]
			public Guid FiscalYearID { get; set; } 
			[DataMember]
			public String BookingAccountName { get; set; } 
			[DataMember]
			public String BookingAccountNumber { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Create_Booking_Account(,P_L3BA_CBA_1305 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Create_Booking_Account.Invoke(connectionString,P_L3BA_CBA_1305 Parameter,securityTicket);
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
var parameter = new CL3_BookingAccounts.Complex.Manipulation.P_L3BA_CBA_1305();
parameter.FiscalYearID = ...;
parameter.BookingAccountName = ...;
parameter.BookingAccountNumber = ...;

*/