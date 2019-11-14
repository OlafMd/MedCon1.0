/* 
 * Generated on 12/9/2014 4:48:53 PM
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
using CL2_Feature.Complex.Retrieval;
using CL1_TMS_PRO;
using CL3_ProjectMember.Atomic.Retrieval;

namespace CL6_DeveloperTask.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_DeveloperTask_Info_for_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_DeveloperTask_Info_for_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6DT_GDTIfT_1444_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L6DT_GDTIfT_1444_Array();
			//Put your code here
            List<L6DT_GDTIfT_1444> DeveloperTasksInfo = new List<L6DT_GDTIfT_1444>();
            var devTasksAndFeaturesForTenant = cls_Get_DeveloperTask_with_Features_for_Tenant.Invoke(Connection, Transaction,securityTicket).Result.ToList();
            var nonArchivedNonDeletedParents = cls_Get_Features_for_Tenant.Invoke(Connection, Transaction, securityTicket).Result.ToList();
            
            foreach (var item in devTasksAndFeaturesForTenant)
            {

                L6DT_GDTIfT_1444 DeveloperTaskInfo = new L6DT_GDTIfT_1444();

                DeveloperTaskInfo.Identifier = item.IdentificationNumber;
                DeveloperTaskInfo.DeveloperTaskDescription = item.Description;
                DeveloperTaskInfo.DeveloperTaskName = item.Name;
                DeveloperTaskInfo.DeveloperTaskID = item.TMS_PRO_DeveloperTaskID;
                DeveloperTaskInfo.EstimatedTime = item.DeveloperTime_RequiredEstimation_min;
                DeveloperTaskInfo.Points = item.Developer_Points;
                DeveloperTaskInfo.DeadLine = item.Completion_Deadline.Date.ToString("d");
                DeveloperTaskInfo.ProjectID = item.Project_RefID;
                DeveloperTaskInfo.ProjectMemberID = item.TMS_PRO_ProjectMemberID;
                //checking for subscriptions for current user
               
                ORM_TMS_PRO_Peers_Development subscription = ORM_TMS_PRO_Peers_Development.Query.Search(Connection, Transaction, new ORM_TMS_PRO_Peers_Development.Query()
                {
                    DeveloperTask_RefID = item.TMS_PRO_DeveloperTaskID,
                    Tenant_RefID = securityTicket.TenantID,
                    ProjectMember_RefID =item.TMS_PRO_ProjectMemberID,
                    IsDeleted = false
                }).SingleOrDefault();

                if (subscription != null)
                {
                    DeveloperTaskInfo.IsSubscribed = true;
                }
                       
                
                
               
                //**********************************
                var parents= nonArchivedNonDeletedParents.Where(f => f.TMS_PRO_FeatureID == item.TMS_PRO_FeatureID).SingleOrDefault();
                if (parents != null)
                {
                    DeveloperTaskInfo.Path = parents.BTPath;
                }
                else
                {
                    DeveloperTaskInfo.Path = "-";
                }



                DeveloperTaskInfo.DeveloperInfo = new L6DT_GDTIfT_1444DeveloperInfo();
                List<L6DT_GDTIfT_1444TagInfo> TagsInfo = new List<L6DT_GDTIfT_1444TagInfo>();
                P_L3PM_GAIfPMID_1345 ProjectMemberInfoParameter = new P_L3PM_GAIfPMID_1345();
                ProjectMemberInfoParameter.ProjectMemberID = item.GrabbedByMember_RefID;
                var projectMemberInfo = cls_Get_Account_Information_for_ProjectMemberID.Invoke(Connection, Transaction, ProjectMemberInfoParameter, securityTicket).Result.ToList().SingleOrDefault();
                if (projectMemberInfo != null)
                {

                    DeveloperTaskInfo.DeveloperInfo.ProjectMemberID = projectMemberInfo.TMS_PRO_ProjectMemberID;
                    DeveloperTaskInfo.DeveloperInfo.FirstAndLastName = projectMemberInfo.FirstName + " " + projectMemberInfo.LastName;
                    DeveloperTaskInfo.DeveloperInfo.ProjectMemberID = item.GrabbedByMember_RefID;


                    P_L3DT_GTfDT_1738 developerTaskTagsParameter = new P_L3DT_GTfDT_1738();
                    developerTaskTagsParameter.DTaskID = item.TMS_PRO_DeveloperTaskID;
                    var tagsForDeveloperTask = cls_Get_Tags_for_DeveloperTask.Invoke(Connection, Transaction, developerTaskTagsParameter, securityTicket).Result.ToList();

                    List<L6DT_GDTIfT_1444TagInfo> Tags4DeveloperTask = new List<L6DT_GDTIfT_1444TagInfo>();
                    foreach(var tag in tagsForDeveloperTask)
                    {
                        L6DT_GDTIfT_1444TagInfo tagInfo = new L6DT_GDTIfT_1444TagInfo();
                        tagInfo.TagID = tag.TMS_PRO_TagID;
                        tagInfo.TagValue = tag.TagValue;
                        tagInfo.AssignmentID = tag.AssignmentID;
                        Tags4DeveloperTask.Add(tagInfo);
                    }
                    DeveloperTaskInfo.TagsInfo = Tags4DeveloperTask.ToArray();
                    DeveloperTasksInfo.Add(DeveloperTaskInfo);
                }
               
                
            }
            returnValue.Result = DeveloperTasksInfo.ToArray();
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6DT_GDTIfT_1444_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6DT_GDTIfT_1444_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6DT_GDTIfT_1444_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6DT_GDTIfT_1444_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6DT_GDTIfT_1444_Array functionReturn = new FR_L6DT_GDTIfT_1444_Array();
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

				throw new Exception("Exception occured in method cls_Get_DeveloperTask_Info_for_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6DT_GDTIfT_1444_Array : FR_Base
	{
		public L6DT_GDTIfT_1444[] Result	{ get; set; } 
		public FR_L6DT_GDTIfT_1444_Array() : base() {}

		public FR_L6DT_GDTIfT_1444_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L6DT_GDTIfT_1444 for attribute L6DT_GDTIfT_1444
		[DataContract]
		public class L6DT_GDTIfT_1444 
		{
			[DataMember]
			public L6DT_GDTIfT_1444DeveloperInfo DeveloperInfo { get; set; }
			[DataMember]
			public L6DT_GDTIfT_1444TagInfo[] TagsInfo { get; set; }
			[DataMember]
			public L6DT_GDTIfT_1444InvestedWorkTimesInfo[] InvestedWorkTimesInfo { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid DeveloperTaskID { get; set; } 
			[DataMember]
			public String Path { get; set; } 
			[DataMember]
			public Guid ParentID { get; set; } 
			[DataMember]
			public Guid ProjectID { get; set; } 
			[DataMember]
			public String DeveloperTaskName { get; set; } 
			[DataMember]
			public String Identifier { get; set; } 
			[DataMember]
			public Guid ProjectMemberID { get; set; } 
			[DataMember]
			public String DeadLine { get; set; } 
			[DataMember]
			public Boolean IsSubscribed { get; set; } 
			[DataMember]
			public String DeveloperTaskDescription { get; set; } 
			[DataMember]
			public int Points { get; set; } 
			[DataMember]
			public Double EstimatedTime { get; set; } 
			[DataMember]
			public String Status { get; set; } 

		}
		#endregion
		#region SClass L6DT_GDTIfT_1444DeveloperInfo for attribute DeveloperInfo
		[DataContract]
		public class L6DT_GDTIfT_1444DeveloperInfo 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProjectMemberID { get; set; } 
			[DataMember]
			public Guid UserID { get; set; } 
			[DataMember]
			public String FirstAndLastName { get; set; } 

		}
		#endregion
		#region SClass L6DT_GDTIfT_1444TagInfo for attribute TagsInfo
		[DataContract]
		public class L6DT_GDTIfT_1444TagInfo 
		{
			//Standard type parameters
			[DataMember]
			public Guid TagID { get; set; } 
			[DataMember]
			public Guid AssignmentID { get; set; } 
			[DataMember]
			public String TagValue { get; set; } 

		}
		#endregion
		#region SClass L6DT_GDTIfT_1444InvestedWorkTimesInfo for attribute InvestedWorkTimesInfo
		[DataContract]
		public class L6DT_GDTIfT_1444InvestedWorkTimesInfo 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProjectMemberID { get; set; } 
			[DataMember]
			public Guid UserID { get; set; } 
			[DataMember]
			public String ProjectMemberFirstAndLastName { get; set; } 
			[DataMember]
			public Double InvestedTimeInMin { get; set; } 
			[DataMember]
			public Double Percentage { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6DT_GDTIfT_1444_Array cls_Get_DeveloperTask_Info_for_Tenant(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6DT_GDTIfT_1444_Array invocationResult = cls_Get_DeveloperTask_Info_for_Tenant.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

