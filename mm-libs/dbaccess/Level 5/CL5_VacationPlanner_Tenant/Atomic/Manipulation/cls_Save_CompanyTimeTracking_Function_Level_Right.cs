/* 
 * Generated on 27/08/2014 12:46:24
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
using CL1_USR;

namespace CL5_VacationPlanner_Tenant.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_CompanyTimeTracking_Function_Level_Right.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_CompanyTimeTracking_Function_Level_Right
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Base Execute(DbConnection Connection,DbTransaction Transaction,P_L5TN_SCTTFLR_1230 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Base();

            ORM_USR_Account_FunctionLevelRight companyTimeTrackingRight=new ORM_USR_Account_FunctionLevelRight();

            ORM_USR_Account_FunctionLevelRight.Query accountFunctionLevelRightQuery = new ORM_USR_Account_FunctionLevelRight.Query();
            accountFunctionLevelRightQuery.RightName = "CompanyTimeTracking";
            accountFunctionLevelRightQuery.GlobalPropertyMatchingID = "CompanyTimeTracking";
            accountFunctionLevelRightQuery.Tenant_RefID = securityTicket.TenantID;
            accountFunctionLevelRightQuery.IsDeleted = false;
            var accountFunctionLevelRights = ORM_USR_Account_FunctionLevelRight.Query.Search(Connection, Transaction, accountFunctionLevelRightQuery);
            if (accountFunctionLevelRights != null && accountFunctionLevelRights.Count == 0)
            {
                companyTimeTrackingRight.GlobalPropertyMatchingID = "CompanyTimeTracking";
                companyTimeTrackingRight.RightName = "CompanyTimeTracking";
                companyTimeTrackingRight.Tenant_RefID = securityTicket.TenantID;
                companyTimeTrackingRight.Save(Connection, Transaction);
            }
            else
            {
                companyTimeTrackingRight = accountFunctionLevelRights[0];
            }

            ORM_USR_Account_2_FunctionLevelRight.Query accountToFunctionLevelRightsQuery = new ORM_USR_Account_2_FunctionLevelRight.Query();
            accountToFunctionLevelRightsQuery.Account_RefID = Parameter.AccountID;
            accountToFunctionLevelRightsQuery.FunctionLevelRight_RefID = companyTimeTrackingRight.USR_Account_FunctionLevelRightID;
            accountToFunctionLevelRightsQuery.Tenant_RefID = securityTicket.TenantID;
            var accountRights = ORM_USR_Account_2_FunctionLevelRight.Query.Search(Connection, Transaction, accountToFunctionLevelRightsQuery);
            if (accountRights != null && accountRights.Count == 0)
            {
                ORM_USR_Account_2_FunctionLevelRight accountRight = new ORM_USR_Account_2_FunctionLevelRight();
                accountRight.Account_RefID = Parameter.AccountID;
                accountRight.Tenant_RefID = securityTicket.TenantID;
                accountRight.FunctionLevelRight_RefID = companyTimeTrackingRight.USR_Account_FunctionLevelRightID;
                accountRight.Save(Connection, Transaction);
            }

			//Put your code here
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Base Invoke(string ConnectionString,P_L5TN_SCTTFLR_1230 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection,P_L5TN_SCTTFLR_1230 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction,P_L5TN_SCTTFLR_1230 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5TN_SCTTFLR_1230 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Base functionReturn = new FR_Base();
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

				throw new Exception("Exception occured in method cls_Save_CompanyTimeTracking_Function_Level_Right",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5TN_SCTTFLR_1230 for attribute P_L5TN_SCTTFLR_1230
		[DataContract]
		public class P_L5TN_SCTTFLR_1230 
		{
			//Standard type parameters
			[DataMember]
			public Guid AccountID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Base cls_Save_CompanyTimeTracking_Function_Level_Right(,P_L5TN_SCTTFLR_1230 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Base invocationResult = cls_Save_CompanyTimeTracking_Function_Level_Right.Invoke(connectionString,P_L5TN_SCTTFLR_1230 Parameter,securityTicket);
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
var parameter = new CL5_VacationPlanner_Tenant.Atomic.Manipulation.P_L5TN_SCTTFLR_1230();
parameter.AccountID = ...;

*/
