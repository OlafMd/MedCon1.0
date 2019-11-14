/* 
 * Generated on 03.02.2015 16:05:14
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
using CSV2Core_MySQL.Dictionaries.MultiTable;
using System.Runtime.Serialization;
using CL1_CMN_BPT_USR;
using CL5_MPC_Account.Utils;

namespace CL5_MPC_Account.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_IsValid_Credential.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_IsValid_Credential
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5AC_RAfEaP_1602 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Guid();

            returnValue.Result = Guid.Empty;

            var bptUser = ORM_CMN_BPT_USR_User.Query.Search(Connection, Transaction, new ORM_CMN_BPT_USR_User.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                Username = Parameter.Email,
                IsDeleted = false
            }).SingleOrDefault();

            if (bptUser != null)
            {
                var bptUserPass = ORM_CMN_BPT_USR_User_Password.Query.Search(Connection, Transaction, new ORM_CMN_BPT_USR_User_Password.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    CMN_BPT_USR_User_RefID = bptUser.CMN_BPT_USR_UserID,
                    IsDeleted = false,
                    IsActive = true
                }).SingleOrDefault();

                if (bptUserPass != null)
                {
                    var cryptoUtils = new CryptoUtils();
                    string passSalt = bptUserPass.Password_Salt;
                    string hash = cryptoUtils.GenerateSaltedHash(Parameter.Password, passSalt);

                    if (bptUserPass.Password_Hash == hash)
                        returnValue.Result = bptUser.CMN_BPT_USR_UserID;
                }
            }

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5AC_RAfEaP_1602 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5AC_RAfEaP_1602 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AC_RAfEaP_1602 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AC_RAfEaP_1602 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_IsValid_Credential",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5AC_RAfEaP_1602 for attribute P_L5AC_RAfEaP_1602
		[DataContract]
		public class P_L5AC_RAfEaP_1602 
		{
			//Standard type parameters
			[DataMember]
			public string Email { get; set; } 
			[DataMember]
			public string Password { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_IsValid_Credential(,P_L5AC_RAfEaP_1602 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_IsValid_Credential.Invoke(connectionString,P_L5AC_RAfEaP_1602 Parameter,securityTicket);
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
var parameter = new CL5_MPC_Account.Atomic.Retrieval.P_L5AC_RAfEaP_1602();
parameter.Email = ...;
parameter.Password = ...;

*/
