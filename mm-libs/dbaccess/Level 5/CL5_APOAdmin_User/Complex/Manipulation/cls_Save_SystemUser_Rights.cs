/* 
 * Generated on 12/10/2013 4:09:32 PM
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
using CL1_USR;
using CL5_APOAdmin_User.Complex.Retrieval;

namespace CL5_APOAdmin_User.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_SystemUser_Rights.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_SystemUser_Rights
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5US_SSUR_1542 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var flrGroupRights = cls_Get_FunctionLevelGroupsAndRights_for_TenantID_and_CurrentApplication.Invoke(Connection, Transaction, securityTicket).Result.GroupRights;

            var flRights = flrGroupRights.SelectMany(i => i.FLRights).ToList();

            foreach (var flRight in flRights)
            {
                var groupQuery = new ORM_USR_Account_2_FunctionLevelRight.Query();
                groupQuery.FunctionLevelRight_RefID = flRight.USR_Account_FunctionLevelRightID;
                groupQuery.Account_RefID = Parameter.UserAccountID;

                ORM_USR_Account_2_FunctionLevelRight.Query.SoftDelete(Connection, Transaction, groupQuery);
            }

            if (Parameter.IsDeleted)
            {
                //IMPORTANT!!!! 
                //don't delete account item, it might be used and subscribed to the another app
                return new FR_Guid(FR_Base.Status_OK, Parameter.UserAccountID);
            }

            foreach (var right in Parameter.AllowedRights)
            {
                var groupQuery = new ORM_USR_Account_2_FunctionLevelRight.Query();
                groupQuery.FunctionLevelRight_RefID = right;
                groupQuery.Account_RefID = Parameter.UserAccountID;

                var recoveredNo = ORM_USR_Account_2_FunctionLevelRight.Query.SoftRecover(Connection, Transaction, groupQuery);
                if (recoveredNo != 0)
                    continue;

                var rightAssignment = new ORM_USR_Account_2_FunctionLevelRight();
                rightAssignment.AssignmentID = Guid.NewGuid();
                rightAssignment.Account_RefID = Parameter.UserAccountID;
                rightAssignment.FunctionLevelRight_RefID = right;
                rightAssignment.Creation_Timestamp = DateTime.Now;
                rightAssignment.Tenant_RefID = securityTicket.TenantID;
                rightAssignment.Save(Connection, Transaction);
            }

            return new FR_Guid(FR_Base.Status_OK, Parameter.UserAccountID);

			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5US_SSUR_1542 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5US_SSUR_1542 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5US_SSUR_1542 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5US_SSUR_1542 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_SystemUser_Rights",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5US_SSUR_1542 for attribute P_L5US_SSUR_1542
		[DataContract]
		public class P_L5US_SSUR_1542 
		{
			//Standard type parameters
			[DataMember]
			public Guid UserAccountID { get; set; } 
			[DataMember]
			public Guid[] AllowedRights { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_SystemUser_Rights(,P_L5US_SSUR_1542 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_SystemUser_Rights.Invoke(connectionString,P_L5US_SSUR_1542 Parameter,securityTicket);
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
var parameter = new CL5_APOAdmin_User.Complex.Manipulation.P_L5US_SSUR_1542();
parameter.UserAccountID = ...;
parameter.AllowedRights = ...;
parameter.IsDeleted = ...;

*/
