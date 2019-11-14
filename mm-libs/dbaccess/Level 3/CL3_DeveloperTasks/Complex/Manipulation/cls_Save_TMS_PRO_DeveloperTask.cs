/* 
 * Generated on 04-Dec-14 9:42:03 AM
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
using CL1_TMS_PRO;
using CL3_DeveloperTask.Atomic.Retrieval;
using CL1_CMN_BPT;
using CL1_CMN_PRO;
using CL1_TMS;
using CL3_QuickTask.Atomic.Manipulation;

namespace CL3_DeveloperTask.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_TMS_PRO_DeveloperTask.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_TMS_PRO_DeveloperTask
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L3DT_SDT_0949 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here
            Boolean multipleEdit;

            String oldName = "";
            String oldDescription = "";
            Guid oldPriority_RefID = Guid.Empty;
            Guid oldDeveloperTask_Type_RefID = Guid.Empty;
            double oldEstimatedReqTime = -1;
            DateTime oldCompletion_Deadline = new DateTime();
            Boolean oldIsBeingPrepared = false;

            Guid Project_RefID = Guid.Empty;

            if (Parameter.Parent_RefID != Guid.Empty)
            {

                ORM_TMS_PRO_Feature.Query query = new ORM_TMS_PRO_Feature.Query();
                query.TMS_PRO_FeatureID = Parameter.Parent_RefID;

                var items = ORM_TMS_PRO_Feature.Query.Search(Connection, Transaction, query);
                Project_RefID = items.FirstOrDefault().Project_RefID;

            }

            foreach (var TMS_PRO_DeveloperTaskID in Parameter.TMS_PRO_DeveloperTaskIDList)
            {
                var item = new CL1_TMS_PRO.ORM_TMS_PRO_DeveloperTask();
                var result = item.Load(Connection, Transaction, TMS_PRO_DeveloperTaskID);

                P_L3DT_GPfDT_1659 parameterPeers = new P_L3DT_GPfDT_1659();
                parameterPeers.DTaskID = item.TMS_PRO_DeveloperTaskID;

                List<L3DT_GPfDT_1659> dtaskPeers = cls_Get_Peers_for_DTaskID.Invoke(Connection, Transaction, parameterPeers, securityTicket).Result.ToList();


                if (Parameter.IsDeleted == true)
                {
                    #region Delete ORM_CMN_BPT_InvestedWorkTime

                    var involment_query = new ORM_TMS_PRO_DeveloperTask_Involvement.Query();
                    involment_query.DeveloperTask_RefID = item.TMS_PRO_DeveloperTaskID;
                    involment_query.IsDeleted = false;

                    var involments = ORM_TMS_PRO_DeveloperTask_Involvement.Query.Search(Connection, Transaction, involment_query);

                    foreach (var involment in involments)
                    {

                        var dtinv_query = new ORM_TMS_PRO_DeveloperTask_Involvements_InvestedWorkTime.Query();
                        dtinv_query.TMS_PRO_DeveloperTask_Involvement_RefID = involment.TMS_PRO_DeveloperTask_InvolvementID;
                        dtinv_query.IsDeleted = false;

                        var dtinv = ORM_TMS_PRO_DeveloperTask_Involvements_InvestedWorkTime.Query.Search(Connection, Transaction, dtinv_query);

                        foreach (var dt in dtinv)
                        {
                            dt.IsDeleted = true;
                            dt.Save(Connection, Transaction);

                            var inv_query = new ORM_CMN_BPT_InvestedWorkTime.Query();
                            inv_query.CMN_BPT_InvestedWorkTimeID = dt.CMN_BPT_InvestedWorkTime_RefID;
                            inv_query.IsDeleted = false;

                            ORM_CMN_BPT_InvestedWorkTime.Query.SoftDelete(Connection, Transaction, inv_query);
                        }

                    }
                    #endregion

                    #region DeleteAssignments

                    ORM_TMS_PRO_Peers_Development.Query instance1 = new ORM_TMS_PRO_Peers_Development.Query();
                    instance1.DeveloperTask_RefID = TMS_PRO_DeveloperTaskID;
                    ORM_TMS_PRO_Peers_Development.Query.SoftDelete(Connection, Transaction, instance1);

                    ORM_TMS_PRO_Feature_2_DeveloperTask.Query instance2 = new ORM_TMS_PRO_Feature_2_DeveloperTask.Query();
                    instance2.DeveloperTask_RefID = TMS_PRO_DeveloperTaskID;
                    ORM_TMS_PRO_Feature_2_DeveloperTask.Query.SoftDelete(Connection, Transaction, instance2);

                    ORM_TMS_PRO_DeveloperTask_Involvement.Query instance3 = new ORM_TMS_PRO_DeveloperTask_Involvement.Query();
                    instance3.DeveloperTask_RefID = TMS_PRO_DeveloperTaskID;
                    ORM_TMS_PRO_DeveloperTask_Involvement.Query.SoftDelete(Connection, Transaction, instance3);

                    ORM_TMS_PRO_DeveloperTask_StatusHistory.Query instance4 = new ORM_TMS_PRO_DeveloperTask_StatusHistory.Query();
                    instance4.DeveloperTask_RefID = TMS_PRO_DeveloperTaskID;
                    ORM_TMS_PRO_DeveloperTask_StatusHistory.Query.SoftDelete(Connection, Transaction, instance4);

                    ORM_TMS_PRO_DeveloperTask_Recommendation.Query instance5 = new ORM_TMS_PRO_DeveloperTask_Recommendation.Query();
                    instance5.DeveloperTask_RefID = TMS_PRO_DeveloperTaskID;
                    ORM_TMS_PRO_DeveloperTask_Recommendation.Query.SoftDelete(Connection, Transaction, instance5);

                    ORM_CMN_PRO_Product_Release_2_DeveloperTask.Query instance6 = new ORM_CMN_PRO_Product_Release_2_DeveloperTask.Query();
                    instance6.TMS_PRO_DeveloperTask_RefID = TMS_PRO_DeveloperTaskID;
                    ORM_CMN_PRO_Product_Release_2_DeveloperTask.Query.SoftDelete(Connection, Transaction, instance6);

                    ORM_TMS_QuickTask.Query instance7 = new ORM_TMS_QuickTask.Query();
                    instance7.AssignedTo_DeveloperTask_RefID = TMS_PRO_DeveloperTaskID;
                    var quicktasks = ORM_TMS_QuickTask.Query.Search(Connection, Transaction, instance7);
                    foreach (var quicktask in quicktasks)
                    {
                        var param = new P_L3QT_SQT_0905();
                        param.TMS_QuickTaskID = quicktask.TMS_QuickTaskID;
                        param.IsDeleted = true;
                        cls_Save_TMS_QuickTask.Invoke(Connection, Transaction, param, securityTicket);
                    }

                    #endregion

                    #region projectInfo

                    var project = new ORM_TMS_PRO_Project();
                    project.Load(Connection, Transaction, item.Project_RefID);

                    ORM_TMS_PRO_Project_Status ProjectStatus = new ORM_TMS_PRO_Project_Status();
                    ProjectStatus.Load(Connection, Transaction, project.Status_RefID);

                    Guid language = Parameter.LanguageID;
                    String statusLabel = ProjectStatus.Label.GetContent(language);
                    String projectName = project.Name.GetContent(language);

                    #endregion


                    item.IsDeleted = true;
                    item.Save(Connection, Transaction);
                }





                if (Parameter.IsArchived == true)
                {
                    item.IsArchived = true;
                    item.Save(Connection, Transaction);

                    continue;
                }


                #region ORM_TMS_PRO_Feature_2_DeveloperTask

                if (Parameter.Parent_RefID != Guid.Empty)
                {
                    ORM_TMS_PRO_Feature_2_DeveloperTask.Query assignquery = new ORM_TMS_PRO_Feature_2_DeveloperTask.Query();
                    assignquery.DeveloperTask_RefID = item.TMS_PRO_DeveloperTaskID;

                    List<ORM_TMS_PRO_Feature_2_DeveloperTask> assignments = ORM_TMS_PRO_Feature_2_DeveloperTask.Query.Search(Connection, Transaction, assignquery);
                    foreach (var assignment in assignments)
                    {
                        assignment.Feature_RefID = Parameter.Parent_RefID;
                        assignment.Save(Connection, Transaction);
                    }
                }
                #endregion

                if (Project_RefID != Guid.Empty)
                    item.Project_RefID = Project_RefID;

                if (Parameter.TMS_PRO_DeveloperTaskIDList.Length == 1)
                {
                    multipleEdit = false;

                    oldName = item.Name;
                    oldDescription = item.Description;

                    item.Name = Parameter.TaskName;
                    item.Description = Parameter.Description;

                    item.Priority_RefID = Parameter.Priority_RefID;
                    item.DeveloperTask_Type_RefID = Parameter.DeveloperTask_Type_RefID;

                    item.DeveloperTime_RequiredEstimation_min = Parameter.DeveloperTime_RequiredEstimation_min;
                    item.Completion_Deadline = Parameter.Completion_Deadline;
                    item.IsBeingPrepared = Parameter.IsBeingPrepared;
                    item.IsTaskEstimable = Parameter.IsTaskEstimable;

                    #region ORM_CMN_PRO_Product_Release_2_DeveloperTask

                    if (Parameter.ReleaseID != Guid.Empty)
                    {
                        var revisionAssignment = new ORM_CMN_PRO_Product_Release_2_DeveloperTask();
                        revisionAssignment.AssignmentID = Guid.NewGuid();
                        revisionAssignment.CMN_PRO_Product_Release_RefID = Parameter.ReleaseID;
                        revisionAssignment.TMS_PRO_DeveloperTask_RefID = item.TMS_PRO_DeveloperTaskID;
                        revisionAssignment.Creation_Timestamp = DateTime.Now;
                        revisionAssignment.Tenant_RefID = securityTicket.TenantID;

                        revisionAssignment.Save(Connection, Transaction);
                    }
                    else
                    {

                        var query = new ORM_CMN_PRO_Product_Release_2_DeveloperTask.Query();
                        query.TMS_PRO_DeveloperTask_RefID = item.TMS_PRO_DeveloperTaskID;

                        ORM_CMN_PRO_Product_Release_2_DeveloperTask.Query.SoftDelete(Connection, Transaction, query);

                    }

                    #endregion



                }

                else
                {
                    multipleEdit = true;

                    if (Parameter.Priority_RefID != Guid.Empty)
                        item.Priority_RefID = Parameter.Priority_RefID;
                    if (Parameter.DeveloperTask_Type_RefID != Guid.Empty)
                        item.DeveloperTask_Type_RefID = Parameter.DeveloperTask_Type_RefID;
                    if (Parameter.DeveloperTime_RequiredEstimation_min != 0)
                        item.DeveloperTime_RequiredEstimation_min = Parameter.DeveloperTime_RequiredEstimation_min;
                    if (Parameter.Completion_Deadline != new DateTime())
                        item.Completion_Deadline = Parameter.Completion_Deadline;
                    if (Parameter.IsBeingPreparedIgnore == false)
                        item.IsBeingPrepared = Parameter.IsBeingPrepared;


                    if (Parameter.ReleaseIDIgnore == false)
                    {
                        #region ORM_CMN_PRO_Product_Release_2_DeveloperTask

                        if (Parameter.ReleaseID != Guid.Empty)
                        {
                            var revisionAssignment = new ORM_CMN_PRO_Product_Release_2_DeveloperTask();
                            revisionAssignment.AssignmentID = Guid.NewGuid();
                            revisionAssignment.CMN_PRO_Product_Release_RefID = Parameter.ReleaseID;
                            revisionAssignment.TMS_PRO_DeveloperTask_RefID = item.TMS_PRO_DeveloperTaskID;
                            revisionAssignment.Creation_Timestamp = DateTime.Now;
                            revisionAssignment.Tenant_RefID = securityTicket.TenantID;

                            revisionAssignment.Save(Connection, Transaction);
                        }
                        else
                        {

                            var query = new ORM_CMN_PRO_Product_Release_2_DeveloperTask.Query();
                            query.TMS_PRO_DeveloperTask_RefID = item.TMS_PRO_DeveloperTaskID;

                            ORM_CMN_PRO_Product_Release_2_DeveloperTask.Query.SoftDelete(Connection, Transaction, query);

                        }

                        #endregion
                    }

                }


                item.Save(Connection, Transaction);
            }


			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L3DT_SDT_0949 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L3DT_SDT_0949 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L3DT_SDT_0949 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3DT_SDT_0949 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_TMS_PRO_DeveloperTask",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3DT_SDT_0949 for attribute P_L3DT_SDT_0949
		[DataContract]
		public class P_L3DT_SDT_0949 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] TMS_PRO_DeveloperTaskIDList { get; set; } 
			[DataMember]
			public String TaskName { get; set; } 
			[DataMember]
			public String Description { get; set; } 
			[DataMember]
			public Guid Parent_RefID { get; set; } 
			[DataMember]
			public Guid Priority_RefID { get; set; } 
			[DataMember]
			public Guid DeveloperTask_Type_RefID { get; set; } 
			[DataMember]
			public long DeveloperTime_RequiredEstimation_min { get; set; } 
			[DataMember]
			public DateTime Completion_Deadline { get; set; } 
			[DataMember]
			public Boolean IsBeingPreparedIgnore { get; set; } 
			[DataMember]
			public Boolean IsBeingPrepared { get; set; } 
			[DataMember]
			public Boolean ReleaseIDIgnore { get; set; } 
			[DataMember]
			public Guid ReleaseID { get; set; } 
			[DataMember]
			public Boolean SendEmail { get; set; } 
			[DataMember]
			public Guid LanguageID { get; set; } 
			[DataMember]
			public Boolean IsArchived { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 
			[DataMember]
			public Boolean IsTaskEstimable { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_TMS_PRO_DeveloperTask(,P_L3DT_SDT_0949 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_TMS_PRO_DeveloperTask.Invoke(connectionString,P_L3DT_SDT_0949 Parameter,securityTicket);
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
var parameter = new CL3_DeveloperTask.Complex.Manipulation.P_L3DT_SDT_0949();
parameter.TMS_PRO_DeveloperTaskIDList = ...;
parameter.TaskName = ...;
parameter.Description = ...;
parameter.Parent_RefID = ...;
parameter.Priority_RefID = ...;
parameter.DeveloperTask_Type_RefID = ...;
parameter.DeveloperTime_RequiredEstimation_min = ...;
parameter.Completion_Deadline = ...;
parameter.IsBeingPreparedIgnore = ...;
parameter.IsBeingPrepared = ...;
parameter.ReleaseIDIgnore = ...;
parameter.ReleaseID = ...;
parameter.SendEmail = ...;
parameter.LanguageID = ...;
parameter.IsArchived = ...;
parameter.IsDeleted = ...;
parameter.IsTaskEstimable = ...;

*/
