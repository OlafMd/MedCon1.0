/* 
 * Generated on 04-Dec-14 9:28:31 AM
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
using CL3_User.Atomic.Retrieval;
using CL3_Feature.Atomic.Retrieval;
using CL3_DeveloperTask.Complex.Manipulation;
using CL1_TMS;
using CL3_QuickTask.Atomic.Manipulation;

namespace CL3_Features.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_TMS_PRO_Feature.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_TMS_PRO_Feature
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L3FE_SF_0927 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here

            String oldName = "";
            String oldDescription = "";

            #region Get_Project
            Guid Project_RefID = Guid.Empty;

            if (Parameter.Parent_RefID != Guid.Empty)
            {
                ORM_TMS_PRO_BusinessTask.Query query = new ORM_TMS_PRO_BusinessTask.Query();
                query.TMS_PRO_BusinessTaskID = Parameter.Parent_RefID;

                var items = ORM_TMS_PRO_BusinessTask.Query.Search(Connection, Transaction, query);
                Project_RefID = items.FirstOrDefault().Project_RefID;
            }

            #endregion

            foreach (var TMS_PRO_FeatureID in Parameter.TMS_PRO_FeatureIDList)
            {
                var item = new ORM_TMS_PRO_Feature();
                var result = item.Load(Connection, Transaction, TMS_PRO_FeatureID);

                oldName = "";
                oldDescription = "";

                P_L3FE_GPfF_1445 peersParameter = new P_L3FE_GPfF_1445();
                peersParameter.FeatureID = item.TMS_PRO_FeatureID;
                List<L3FE_GPfF_1445> featurePeers = cls_Get_Peers_for_Feature.Invoke(Connection, Transaction, peersParameter, securityTicket).Result.ToList();

                if (Parameter.IsDeleted == true)
                {

                    #region DeleteAssignments

                    ORM_TMS_PRO_Feature.Query instance1 = new ORM_TMS_PRO_Feature.Query();
                    instance1.TMS_PRO_FeatureID = TMS_PRO_FeatureID;
                    ORM_TMS_PRO_Feature.Query.SoftDelete(Connection, Transaction, instance1);

                    ORM_TMS_PRO_BusinessTask_2_Feature.Query instance2 = new ORM_TMS_PRO_BusinessTask_2_Feature.Query();
                    instance2.Feature_RefID = TMS_PRO_FeatureID;
                    ORM_TMS_PRO_BusinessTask_2_Feature.Query.SoftDelete(Connection, Transaction, instance2);

                    ORM_TMS_PRO_Peers_Feature.Query instance3 = new ORM_TMS_PRO_Peers_Feature.Query();
                    instance3.Feature_RefID = TMS_PRO_FeatureID;
                    instance3.IsDeleted = false;
                    ORM_TMS_PRO_Peers_Feature.Query.SoftDelete(Connection, Transaction, instance3);

                    ORM_TMS_PRO_Feature_2_DeveloperTask.Query instance4 = new ORM_TMS_PRO_Feature_2_DeveloperTask.Query();
                    instance4.Feature_RefID = TMS_PRO_FeatureID;
                    List<ORM_TMS_PRO_Feature_2_DeveloperTask> assignmentResult = ORM_TMS_PRO_Feature_2_DeveloperTask.Query.Search(Connection, Transaction, instance4);
                    var DTasks = assignmentResult.Select(i => i.DeveloperTask_RefID).ToArray();

                    ORM_TMS_QuickTask.Query instance7 = new ORM_TMS_QuickTask.Query();
                    instance7.AssignedTo_Feature_RefID = TMS_PRO_FeatureID;
                    var quicktasks = ORM_TMS_QuickTask.Query.Search(Connection, Transaction, instance7);
                    foreach (var quicktask in quicktasks)
                    {
                        var param = new P_L3QT_SQT_0905();
                        param.TMS_QuickTaskID = quicktask.TMS_QuickTaskID;
                        param.IsDeleted = true;
                        cls_Save_TMS_QuickTask.Invoke(Connection, Transaction, param, securityTicket);
                    }

                    P_L3DT_SDT_0949 DTParam = new P_L3DT_SDT_0949();
                    DTParam.TMS_PRO_DeveloperTaskIDList = DTasks;
                    DTParam.IsDeleted = true;
                    DTParam.SendEmail = false;
                    cls_Save_TMS_PRO_DeveloperTask.Invoke(Connection, Transaction, DTParam, securityTicket);

                    #endregion


                    


                    continue;
                }

                if (Parameter.IsArchived == true)
                {
                    ORM_TMS_PRO_Feature_2_DeveloperTask.Query instance3 = new ORM_TMS_PRO_Feature_2_DeveloperTask.Query();
                    instance3.Feature_RefID = TMS_PRO_FeatureID;
                    List<ORM_TMS_PRO_Feature_2_DeveloperTask> assignmentResult = ORM_TMS_PRO_Feature_2_DeveloperTask.Query.Search(Connection, Transaction, instance3);
                    var DTasks = assignmentResult.Select(i => i.DeveloperTask_RefID).ToArray();

                    P_L3DT_SDT_0949 DTParam = new P_L3DT_SDT_0949();
                    DTParam.TMS_PRO_DeveloperTaskIDList = DTasks;
                    DTParam.IsArchived = true;
                    DTParam.SendEmail = false;
                    cls_Save_TMS_PRO_DeveloperTask.Invoke(Connection, Transaction, DTParam, securityTicket);

                    item.IsArchived = true;
                    item.Save(Connection, Transaction);

                    continue;
                }

                #region ORM_BusinessTask_2_Feature

                ORM_TMS_PRO_BusinessTask_2_Feature.Query assignquery = new ORM_TMS_PRO_BusinessTask_2_Feature.Query();
                assignquery.Feature_RefID = item.TMS_PRO_FeatureID;

                List<ORM_TMS_PRO_BusinessTask_2_Feature> assignments = ORM_TMS_PRO_BusinessTask_2_Feature.Query.Search(Connection, Transaction, assignquery);
                foreach (var assignment in assignments)
                {
                    assignment.BusinessTask_RefID = Parameter.Parent_RefID;
                    assignment.Save(Connection, Transaction);
                }

                #endregion


                item.Project_RefID = Project_RefID;

                if (Parameter.TMS_PRO_FeatureIDList.Length == 1)
                {

                    if (Parameter.FeatureName != null && item.Name.GetContent(Parameter.LanguageID) != Parameter.FeatureName.GetContent(Parameter.LanguageID))
                    {
                        oldName = item.Name.GetContent(Parameter.LanguageID);
                        item.Name = Parameter.FeatureName;
                    }
                    if (Parameter.Description != null && item.Description.GetContent(Parameter.LanguageID) != Parameter.Description.GetContent(Parameter.LanguageID))
                    {
                        oldDescription = item.Description.GetContent(Parameter.LanguageID);
                        item.Description = Parameter.Description;
                    }

                }

                #region mailSendout

                
                

                #endregion


                if (Parameter.Parent_RefID != Guid.Empty)
                    item.Parent_RefID = Parameter.Parent_RefID;
                if (Parameter.Type_RefID != Guid.Empty)
                    item.Type_RefID = Parameter.Type_RefID;
                if (Parameter.Status_RefID != Guid.Empty)
                    item.Status_RefID = Parameter.Status_RefID;
                if (Parameter.Feature_Deadline != new DateTime())
                    item.Feature_Deadline = Parameter.Feature_Deadline;



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
		public static FR_Guid Invoke(string ConnectionString,P_L3FE_SF_0927 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L3FE_SF_0927 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L3FE_SF_0927 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3FE_SF_0927 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_TMS_PRO_Feature",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3FE_SF_0927 for attribute P_L3FE_SF_0927
		[DataContract]
		public class P_L3FE_SF_0927 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] TMS_PRO_FeatureIDList { get; set; } 
			[DataMember]
			public Dict FeatureName { get; set; } 
			[DataMember]
			public Dict Description { get; set; } 
			[DataMember]
			public Guid Parent_RefID { get; set; } 
			[DataMember]
			public Guid Type_RefID { get; set; } 
			[DataMember]
			public Guid Status_RefID { get; set; } 
			[DataMember]
			public DateTime Feature_Deadline { get; set; } 
			[DataMember]
			public Boolean IsArchived { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 
			[DataMember]
			public Guid LanguageID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_TMS_PRO_Feature(,P_L3FE_SF_0927 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_TMS_PRO_Feature.Invoke(connectionString,P_L3FE_SF_0927 Parameter,securityTicket);
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
var parameter = new CL3_Features.Complex.Manipulation.P_L3FE_SF_0927();
parameter.TMS_PRO_FeatureIDList = ...;
parameter.FeatureName = ...;
parameter.Description = ...;
parameter.Parent_RefID = ...;
parameter.Type_RefID = ...;
parameter.Status_RefID = ...;
parameter.Feature_Deadline = ...;
parameter.IsArchived = ...;
parameter.IsDeleted = ...;
parameter.LanguageID = ...;

*/
