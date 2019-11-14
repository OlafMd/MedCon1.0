/* 
 * Generated on 7/15/2014 5:57:17 PM
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
using CL3_DeveloperTask.Atomic.Retrieval;
using CL3_Project.Atomic.Retrieval;
using CL3_Notes.Atomic.Retrieval;
using CL1_TMS_PRO;

namespace CL6_DanuTask_User.Complex.Retrieval
{
	/// <summary>
    /// 
    
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_DeveloperModuleDashboardMenuData_for_ActiveUser.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_DeveloperModuleDashboardMenuData_for_ActiveUser
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6US_GDMDMDfAU_1802 Execute(DbConnection Connection,DbTransaction Transaction,P_L6US_GDMDMDfAU_1802 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_L6US_GDMDMDfAU_1802();
			//Put your code here
            returnValue.Result = new L6US_GDMDMDfAU_1802();


            #region ActiveTask
            P_L3DT_GADTfAU_1505 Parameter_ActiveTask = new P_L3DT_GADTfAU_1505();
            Parameter_ActiveTask.IsBeingPrepared_Only = Parameter.IsBeingPrepared_Only;
            returnValue.Result.ActiveTask = cls_Get_ActiveDeveloperTask_for_ActiveUser.Invoke(Connection, Transaction, Parameter_ActiveTask, securityTicket).Result.FirstOrDefault();
            #endregion


            #region ProjectIDs
            P_L3PR_GPIDLfAUaRPL_1344 Paramater_Project = new P_L3PR_GPIDLfAUaRPL_1344();
            Paramater_Project.IsArchived = Parameter.IsArchived;
            Paramater_Project.RightPackIDList = Parameter.RightPackIDList;
            List<L3PR_GPIDLfAUaRPL_1344> AvailableProjects = cls_Get_ProjectIDList_for_ActiveUser_and_RightPackageList.Invoke(Connection, Transaction, Paramater_Project, securityTicket).Result.ToList();
            #endregion

            if (AvailableProjects != null && AvailableProjects.Count > 0)
            {
                #region AssignedTasks
                P_L3DT_GADTLfAUaPL_1559 Parameter_AssignedTasks = new P_L3DT_GADTLfAUaPL_1559();
                Parameter_AssignedTasks.IsBeingPrepared_Only = Parameter.IsBeingPrepared_Only;
                Parameter_AssignedTasks.ProjectID_List = AvailableProjects.Select(p => p.Project_ID).ToArray();
                Parameter_AssignedTasks.FeatureStatusExcluded = Parameter.FeatureStatusDifferentFromThis;
                Parameter_AssignedTasks.BusinessTaskStatusExcluded = Parameter.BusinessTaskStatusDifferentFromThis;
                Parameter_AssignedTasks.ProjectStatusExcluded = Parameter.ProjectStatusDifferenFromThis;
                returnValue.Result.AssignedTasks = cls_Get_AssignedDeveloperTaskList_for_ActiveUser_and_ProjectList.Invoke(Connection, Transaction, Parameter_AssignedTasks, securityTicket).Result;
                #endregion

                #region CompletedTasks
                P_L3DT_GCDTfAUaPL_1610 Parameter_CompletedTasks = new P_L3DT_GCDTfAUaPL_1610();
                Parameter_CompletedTasks.ProjectID_List = AvailableProjects.Select(p => p.Project_ID).ToArray();
                returnValue.Result.CompletedTasks = cls_Get_CompletedDeveloperTasks_for_ActiveUser_and_ProjectList.Invoke(Connection, Transaction, Parameter_CompletedTasks, securityTicket).Result;
                #endregion

                #region MentionedTasks
                P_L3DT_GDTIDwAUiM_1712 Parameter_MentionTasks = new P_L3DT_GDTIDwAUiM_1712();
                Parameter_MentionTasks.BusinessTaskStatusExcluded = Parameter.BusinessTaskStatusDifferentFromThis;
                Parameter_MentionTasks.FeatureStatusExcluded = Parameter.FeatureStatusDifferentFromThis;
                Parameter_MentionTasks.ProjectStatusExcluded = Parameter.ProjectStatusDifferenFromThis;
                returnValue.Result.MentionTasks = cls_Get_DeveloperTaskIDs_where_ActiveUser_is_Mentioned.Invoke(Connection, Transaction, Parameter_MentionTasks, securityTicket).Result;
                #endregion

                #region FreeTasks
                P_L3DT_GFDTLfAUIDaPL_1643 Parameter_FreeTasks = new P_L3DT_GFDTLfAUIDaPL_1643();
                Parameter_FreeTasks.IsBeingPrepared_Only = Parameter.IsBeingPrepared_Only;
                Parameter_FreeTasks.ProjectID_List = AvailableProjects.Select(p => p.Project_ID).ToArray();
                Parameter_FreeTasks.BusinessTaskStatusExcluded = Parameter.BusinessTaskStatusDifferentFromThis;
                Parameter_FreeTasks.FeatureStatusExcluded = Parameter.FeatureStatusDifferentFromThis;
                Parameter_FreeTasks.ProjectStatusExcluded = Parameter.ProjectStatusDifferenFromThis;
                returnValue.Result.FreeTasks = cls_Get_FreeDeveloperTasksList_for_ActiveUser_and_ProjectList.Invoke(Connection, Transaction, Parameter_FreeTasks, securityTicket).Result;
                #endregion

                #region RecommendedTasks
                P_L3DT_GRDTLfAU_1408 Parameter_RecommendedTasks = new P_L3DT_GRDTLfAU_1408();
                Parameter_RecommendedTasks.BusinessTaskStatusExcluded = Parameter.BusinessTaskStatusDifferentFromThis;
                Parameter_RecommendedTasks.FeatureStatusExcluded = Parameter.FeatureStatusDifferentFromThis;
                Parameter_RecommendedTasks.ProjectStatusExcluded = Parameter.ProjectStatusDifferenFromThis;
                Parameter_RecommendedTasks.IsBeingPrepared_Only = Parameter.IsBeingPrepared_Only;
                Parameter_RecommendedTasks.ProjectID_List = AvailableProjects.Select(p => p.Project_ID).ToArray();
                returnValue.Result.RecomendedTasks = cls_Get_RecommendedDeveloperTaskList_for_ActiveUser.Invoke(Connection, Transaction, Parameter_RecommendedTasks, securityTicket).Result;
               
                #endregion
            }


            //Notes
            ORM_TMS_PRO_Project_Notes.Query notesQuery = new ORM_TMS_PRO_Project_Notes.Query();
            notesQuery.IsDeleted = false;
            notesQuery.Tenant_RefID = securityTicket.TenantID;
            var notes = ORM_TMS_PRO_Project_Notes.Query.Search(Connection, Transaction, notesQuery).Count;
            returnValue.Result.NotesCount = notes;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6US_GDMDMDfAU_1802 Invoke(string ConnectionString,P_L6US_GDMDMDfAU_1802 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6US_GDMDMDfAU_1802 Invoke(DbConnection Connection,P_L6US_GDMDMDfAU_1802 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6US_GDMDMDfAU_1802 Invoke(DbConnection Connection, DbTransaction Transaction,P_L6US_GDMDMDfAU_1802 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6US_GDMDMDfAU_1802 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6US_GDMDMDfAU_1802 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6US_GDMDMDfAU_1802 functionReturn = new FR_L6US_GDMDMDfAU_1802();
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

				throw new Exception("Exception occured in method cls_Get_DeveloperModuleDashboardMenuData_for_ActiveUser",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6US_GDMDMDfAU_1802 : FR_Base
	{
		public L6US_GDMDMDfAU_1802 Result	{ get; set; }

		public FR_L6US_GDMDMDfAU_1802() : base() {}

		public FR_L6US_GDMDMDfAU_1802(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6US_GDMDMDfAU_1802 for attribute P_L6US_GDMDMDfAU_1802
		[DataContract]
		public class P_L6US_GDMDMDfAU_1802 
		{
			//Standard type parameters
			[DataMember]
			public Boolean IsArchived { get; set; } 
			[DataMember]
			public Guid[] RightPackIDList { get; set; } 
			[DataMember]
			public Boolean IsBeingPrepared_Only { get; set; } 
			[DataMember]
			public Guid ProjectStatusDifferenFromThis { get; set; } 
			[DataMember]
			public Guid FeatureStatusDifferentFromThis { get; set; } 
			[DataMember]
			public Guid BusinessTaskStatusDifferentFromThis { get; set; } 

		}
		#endregion
		#region SClass L6US_GDMDMDfAU_1802 for attribute L6US_GDMDMDfAU_1802
		[DataContract]
		public class L6US_GDMDMDfAU_1802 
		{
			//Standard type parameters
			[DataMember]
			public L3DT_GADTfAU_1505 ActiveTask { get; set; } 
			[DataMember]
			public L3DT_GADTLfAUaPL_1559[] AssignedTasks { get; set; } 
			[DataMember]
			public L3DT_GCDTfAUaPL_1610[] CompletedTasks { get; set; } 
			[DataMember]
			public L3DT_GDTIDwAUiM_1712[] MentionTasks { get; set; } 
			[DataMember]
			public L3DT_GFDTLfAUIDaPL_1643[] FreeTasks { get; set; } 
			[DataMember]
			public L3DT_GRDTLfAU_1408[] RecomendedTasks { get; set; }
            [DataMember]
            public int NotesCount { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6US_GDMDMDfAU_1802 cls_Get_DeveloperModuleDashboardMenuData_for_ActiveUser(,P_L6US_GDMDMDfAU_1802 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6US_GDMDMDfAU_1802 invocationResult = cls_Get_DeveloperModuleDashboardMenuData_for_ActiveUser.Invoke(connectionString,P_L6US_GDMDMDfAU_1802 Parameter,securityTicket);
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
var parameter = new CL6_DanuTask_User.Complex.Retrieval.P_L6US_GDMDMDfAU_1802();
parameter.IsArchived = ...;
parameter.RightPackIDList = ...;
parameter.IsBeingPrepared_Only = ...;
parameter.ProjectStatusDifferenFromThis = ...;
parameter.FeatureStatusDifferentFromThis = ...;
parameter.BusinessTaskStatusDifferentFromThis = ...;

*/
