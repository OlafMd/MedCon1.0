/* 
 * Generated on 9/3/2014 3:21:55 PM
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
using CL6_DanuTask_User.Atomic.Retrieval;
using System.Web.Configuration;
using CL1_TMS_PRO;
using CL1_TMS;
using CL1_CMN_BPT;
using CL1_USR;
using CL1_CMN;
using CL1_TMP_PRO;
using CL6_DanuTask_PriceGrade.Atomic.Retrieval;

namespace CL6_DanuTask_User.Complex.Retrieval
{
	/// <summary>
    /// 
    
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_AdminModuleDashboardMenuData_for_ActiveUser.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_AdminModuleDashboardMenuData_for_ActiveUser
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6US_GAMDMDfAU_1317 Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L6US_GAMDMDfAU_1317();
			//Put your code here
            L6US_GAMDMDfAU_1317 tempResult = new L6US_GAMDMDfAU_1317();
            
            Guid ApplicationID = Guid.Parse(WebConfigurationManager.AppSettings["ApplicationID"].ToString());
            List<L6US_GAMDMDfAU_1317a> tempUsers = new List<L6US_GAMDMDfAU_1317a>();

            //Retrieve users
            ORM_USR_Account.Query userQuery = new ORM_USR_Account.Query();
            userQuery.Tenant_RefID = securityTicket.TenantID;
            userQuery.IsDeleted = false;

            List<ORM_USR_Account> resultUsers = ORM_USR_Account.Query.Search(Connection, Transaction, userQuery);

            ORM_CMN_Account_ApplicationSubscription.Query appSubscriptionQuery = new ORM_CMN_Account_ApplicationSubscription.Query();

            foreach (var currentUser in resultUsers)
            {
                L6US_GAMDMDfAU_1317a tempUser = new L6US_GAMDMDfAU_1317a();
                appSubscriptionQuery.Account_RefID = currentUser.USR_AccountID;
                appSubscriptionQuery.IsDeleted = false;
                appSubscriptionQuery.Tenant_RefID = securityTicket.TenantID;

                List<ORM_CMN_Account_ApplicationSubscription> tempSubscriptionResult = ORM_CMN_Account_ApplicationSubscription.Query.Search(Connection, Transaction, appSubscriptionQuery);
                if (tempSubscriptionResult != null && tempSubscriptionResult.Count > 0)
                {
                    tempUser.User_IsSubscribed = tempSubscriptionResult.Exists(ts => ts.Application_RefID == ApplicationID && !ts.IsDisabled);
                }
                else
                {
                    tempUser.User_IsSubscribed = false;
                }
                tempUsers.Add(tempUser);
            }

            tempResult.ActiveUsers = tempUsers.ToArray();

            ORM_TMS_PRO_Project.Query projectsQuery = new ORM_TMS_PRO_Project.Query();
            projectsQuery.Tenant_RefID = securityTicket.TenantID;
            projectsQuery.IsDeleted = false;
            projectsQuery.IsArchived = false;

            tempResult.ProjectsCount = ORM_TMS_PRO_Project.Query.Search(Connection, Transaction, projectsQuery).Count;

            ORM_TMS_QuickTask_Type.Query quickTaskQuery = new ORM_TMS_QuickTask_Type.Query();
            quickTaskQuery.Tenant_RefID = securityTicket.TenantID;
            quickTaskQuery.IsDeleted = false;

            tempResult.WorkingTimeTypesCount = ORM_TMS_QuickTask_Type.Query.Search(Connection, Transaction, quickTaskQuery).Count;


            ORM_TMS_PRO_DeveloperTask_Priority.Query developerTaskPrioritiesQuery = new ORM_TMS_PRO_DeveloperTask_Priority.Query();
            developerTaskPrioritiesQuery.Tenant_RefID = securityTicket.TenantID;
            developerTaskPrioritiesQuery.IsDeleted = false;

            tempResult.DeveloperTaskPrioritiesCount = ORM_TMS_PRO_DeveloperTask_Priority.Query.Search(Connection, Transaction, developerTaskPrioritiesQuery).Count;


            ORM_TMP_PRO_ProjectMember_Type.Query  projectMemberTypeQuery = new ORM_TMP_PRO_ProjectMember_Type.Query();
            projectMemberTypeQuery.Tenant_RefID = securityTicket.TenantID;
            projectMemberTypeQuery.IsDeleted = false;

            tempResult.ProjectMemberTypesCount = ORM_TMP_PRO_ProjectMember_Type.Query.Search(Connection, Transaction, projectMemberTypeQuery).Count;

            //ORM_CMN_BPT_InvestedWorkTime_ChargingLevel.Query chargingLevelQuery = new ORM_CMN_BPT_InvestedWorkTime_ChargingLevel.Query();
            //chargingLevelQuery.Tenant_RefID = securityTicket.TenantID;
            //chargingLevelQuery.IsDeleted = false;
            //tempResult.PriceGradesCount = ORM_CMN_BPT_InvestedWorkTime_ChargingLevel.Query.Search(Connection, Transaction, chargingLevelQuery).Count;
            tempResult.PriceGradesCount = cls_Get_PriceGrades_for_Tenant.Invoke(Connection, Transaction, securityTicket).Result.ToList().Count;
            tempResult.PlannedProjectsCount = 6;

            returnValue.Result = tempResult;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6US_GAMDMDfAU_1317 Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6US_GAMDMDfAU_1317 Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6US_GAMDMDfAU_1317 Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6US_GAMDMDfAU_1317 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6US_GAMDMDfAU_1317 functionReturn = new FR_L6US_GAMDMDfAU_1317();
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

				functionReturn = Execute(Connection, Transaction,securityTicket);

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

				throw new Exception("Exception occured in method cls_Get_AdminModuleDashboardMenuData_for_ActiveUser",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6US_GAMDMDfAU_1317 : FR_Base
	{
		public L6US_GAMDMDfAU_1317 Result	{ get; set; }

		public FR_L6US_GAMDMDfAU_1317() : base() {}

		public FR_L6US_GAMDMDfAU_1317(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L6US_GAMDMDfAU_1317 for attribute L6US_GAMDMDfAU_1317
		[DataContract]
		public class L6US_GAMDMDfAU_1317 
		{
			[DataMember]
			public L6US_GAMDMDfAU_1317a[] ActiveUsers { get; set; }

			//Standard type parameters
			[DataMember]
			public int ProjectsCount { get; set; } 
			[DataMember]
			public int WorkingTimeTypesCount { get; set; } 
			[DataMember]
			public int DeveloperTaskPrioritiesCount { get; set; } 
			[DataMember]
			public int ProjectMemberTypesCount { get; set; } 
			[DataMember]
			public int PriceGradesCount { get; set; } 
			[DataMember]
			public int PlannedProjectsCount { get; set; } 

		}
		#endregion
		#region SClass L6US_GAMDMDfAU_1317a for attribute ActiveUsers
		[DataContract]
		public class L6US_GAMDMDfAU_1317a 
		{
			//Standard type parameters
			[DataMember]
			public bool User_IsSubscribed { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6US_GAMDMDfAU_1317 cls_Get_AdminModuleDashboardMenuData_for_ActiveUser(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6US_GAMDMDfAU_1317 invocationResult = cls_Get_AdminModuleDashboardMenuData_for_ActiveUser.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

