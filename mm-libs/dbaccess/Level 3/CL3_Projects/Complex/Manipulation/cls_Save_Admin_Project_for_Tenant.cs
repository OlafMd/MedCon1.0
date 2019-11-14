/* 
 * Generated on 11/20/2014 1:33:39 PM
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
using CL2_RightsPackage.Atomic.Retrieval;
using CL1_DOC;
using DLCore_DBCommons.Utils;
using DLCore_DBCommons.DanuTask;

namespace CL3_Project.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Admin_Project_for_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Admin_Project_for_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L3SPFT_SPN_1100 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_Guid();

            var item = new ORM_TMS_PRO_Project();
            if (Parameter.TMS_PRO_ProjectID != Guid.Empty)
            {
                item.Load(Connection, Transaction, Parameter.TMS_PRO_ProjectID);
            }

            if(Parameter.IsDeleted==true)
            {
                ORM_TMS_PRO_Project.Query query = new ORM_TMS_PRO_Project.Query();
                query.TMS_PRO_ProjectID = item.TMS_PRO_ProjectID;
                item.IsDeleted = true;
                ORM_TMS_PRO_Project.Query.SoftDelete(Connection, Transaction, query);


                #region Delete ORM_TMS_PRO_BusinessTask
                ORM_TMS_PRO_BusinessTask.Query ORM_TMS_PRO_BusinessTaskquery = new ORM_TMS_PRO_BusinessTask.Query();
                ORM_TMS_PRO_BusinessTaskquery.Project_RefID = Parameter.TMS_PRO_ProjectID;
                ORM_TMS_PRO_BusinessTaskquery.IsArchived = false;
                ORM_TMS_PRO_BusinessTaskquery.IsDeleted = false;
                ORM_TMS_PRO_BusinessTask.Query.SoftDelete(Connection, Transaction, ORM_TMS_PRO_BusinessTaskquery);

                #endregion

                #region Delete ORM_TMS_PRO_BusinessTaskPackage

                ORM_TMS_PRO_BusinessTaskPackage.Query ORM_TMS_PRO_BusinessTaskPackagequery = new ORM_TMS_PRO_BusinessTaskPackage.Query();
                ORM_TMS_PRO_BusinessTaskPackagequery.Project_RefID = Parameter.TMS_PRO_ProjectID;
                ORM_TMS_PRO_BusinessTaskPackagequery.IsDeleted = false;

                ORM_TMS_PRO_BusinessTaskPackage.Query.SoftDelete(Connection, Transaction, ORM_TMS_PRO_BusinessTaskPackagequery);


                #endregion

                #region Delete ORM_TMS_PRO_ProjectMember

                var ORM_TMS_PRO_ProjectMemberquery = new ORM_TMS_PRO_ProjectMember.Query();
                ORM_TMS_PRO_ProjectMemberquery.IsDeleted = true;
                ORM_TMS_PRO_ProjectMemberquery.Project_RefID = Parameter.TMS_PRO_ProjectID;

                ORM_TMS_PRO_ProjectMember.Query.SoftDelete(Connection, Transaction, ORM_TMS_PRO_ProjectMemberquery);

                #endregion

                #region Delete ORM_TMS_PRO_BussinessTask_2_Feature
                var ORM_TMS_PRO_BussinessTask_2_Featurequery = new ORM_TMS_PRO_BusinessTask_2_Feature.Query();
                ORM_TMS_PRO_BussinessTask_2_Featurequery.Feature_RefID = Parameter.TMS_PRO_ProjectID;
                ORM_TMS_PRO_BussinessTask_2_Featurequery.IsDeleted = true;
                ORM_TMS_PRO_BusinessTask_2_Feature.Query.SoftDelete(Connection, Transaction, ORM_TMS_PRO_BussinessTask_2_Featurequery);

                #endregion

                #region Delete ORM_TMS_PRO_Features
                var ORM_TMS_PRO_Featuresquery = new ORM_TMS_PRO_Feature.Query();
                ORM_TMS_PRO_Featuresquery.TMS_PRO_FeatureID = Parameter.TMS_PRO_ProjectID;
                ORM_TMS_PRO_Featuresquery.IsDeleted = true;
                ORM_TMS_PRO_Feature.Query.SoftDelete(Connection, Transaction, ORM_TMS_PRO_Featuresquery);

                #endregion
                #region Delete ORM_TMS_DeveloperTasks
                var ORM_TMS_Developertaskquery = new ORM_TMS_PRO_DeveloperTask.Query();
                ORM_TMS_Developertaskquery.TMS_PRO_DeveloperTaskID = Parameter.TMS_PRO_ProjectID;
                ORM_TMS_Developertaskquery.IsDeleted = true;
                ORM_TMS_PRO_DeveloperTask.Query.SoftDelete(Connection, Transaction, ORM_TMS_Developertaskquery);
                #endregion
                return returnValue;
            }
            
            if (Parameter.IsArchived == true)
            {
                #region archive Project
                //ORM_TMS_PRO_Project.Query searchQueryProject = new ORM_TMS_PRO_Project.Query();
                //searchQueryProject.TMS_PRO_ProjectID = item.TMS_PRO_ProjectID;
                //searchQueryProject.IsArchived = false;

                //ORM_TMS_PRO_Project.Query updateQueryProject = new ORM_TMS_PRO_Project.Query();
                //updateQueryProject.TMS_PRO_ProjectID = item.TMS_PRO_ProjectID;
                //updateQueryProject.IsArchived = true;

                //ORM_TMS_PRO_Project.Query.Update(Connection, Transaction, searchQueryProject, updateQueryProject);
                var project  = ORM_TMS_PRO_Project.Query.Search(Connection, Transaction, new ORM_TMS_PRO_Project.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false,
                    TMS_PRO_ProjectID = Parameter.TMS_PRO_ProjectID
                }).Single();
                project.IsArchived = true;
                project.Save(Connection, Transaction);

                #endregion

                #region archive ORM_TMS_PRO_BusinessTask

                //ORM_TMS_PRO_BusinessTask.Query searchQueryBusinessTask = new ORM_TMS_PRO_BusinessTask.Query();
                //searchQueryBusinessTask.Project_RefID= item.TMS_PRO_ProjectID;
                //searchQueryBusinessTask.IsArchived = false;

                //ORM_TMS_PRO_BusinessTask.Query updateQueryBusinessTask = new ORM_TMS_PRO_BusinessTask.Query();
                //updateQueryBusinessTask.Project_RefID = item.TMS_PRO_ProjectID;
                //updateQueryBusinessTask.IsArchived = true;

                //ORM_TMS_PRO_BusinessTask.Query.Update(Connection, Transaction, searchQueryBusinessTask, updateQueryBusinessTask);

                var businesstaskList = ORM_TMS_PRO_BusinessTask.Query.Search(Connection, Transaction, new ORM_TMS_PRO_BusinessTask.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false,
                    Project_RefID = Parameter.TMS_PRO_ProjectID
                });

                foreach (var businesstaskitem in businesstaskList)
                {
                    businesstaskitem.IsArchived = true;
                    businesstaskitem.Save(Connection, Transaction);
                }

                #endregion

                #region archive ORM_TMS_PRO_Features

                //ORM_TMS_PRO_Feature.Query searchQueryFeature = new ORM_TMS_PRO_Feature.Query();
                //searchQueryFeature.Project_RefID = item.TMS_PRO_ProjectID;
                //searchQueryFeature.IsArchived = false;

                //ORM_TMS_PRO_Feature.Query updateQueryFeature = new ORM_TMS_PRO_Feature.Query();
                //updateQueryFeature.Project_RefID = item.TMS_PRO_ProjectID;
                //updateQueryFeature.IsArchived = true;

                //ORM_TMS_PRO_Feature.Query.Update(Connection, Transaction, searchQueryFeature, updateQueryFeature);

                var featureList = ORM_TMS_PRO_Feature.Query.Search(Connection, Transaction, new ORM_TMS_PRO_Feature.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false,
                    Project_RefID = Parameter.TMS_PRO_ProjectID
                });

                foreach (var feature in featureList)
                {
                    feature.IsArchived = true;
                    feature.Save(Connection, Transaction);
                }
                

                #endregion

                #region archive ORM_TMS_DeveloperTasks

                var devTaskList = ORM_TMS_PRO_DeveloperTask.Query.Search(Connection, Transaction, new ORM_TMS_PRO_DeveloperTask.Query()
                {
                    Tenant_RefID=securityTicket.TenantID,
                    Project_RefID=item.TMS_PRO_ProjectID,
                    IsDeleted=false

                });
                foreach(var devTask in devTaskList){
                    devTask.IsArchived = true;
                    devTask.Save(Connection,Transaction);
                }
                //ORM_TMS_PRO_DeveloperTask.Query searchQueryDeveloperTask = new ORM_TMS_PRO_DeveloperTask.Query();
                //searchQueryDeveloperTask.Project_RefID = item.TMS_PRO_ProjectID;
                //searchQueryDeveloperTask.IsArchived = false;

                //ORM_TMS_PRO_DeveloperTask.Query updateQueryDeveloperTask = new ORM_TMS_PRO_DeveloperTask.Query();
                //updateQueryDeveloperTask.Project_RefID = item.TMS_PRO_ProjectID;
                //updateQueryDeveloperTask.IsArchived = true;

                //ORM_TMS_PRO_DeveloperTask.Query.Update(Connection, Transaction, searchQueryDeveloperTask, updateQueryDeveloperTask);
                #endregion            

            }

            if (Parameter.TMS_PRO_ProjectID == Guid.Empty)
            {
                item.TMS_PRO_ProjectID = Guid.NewGuid();

                #region Define Documents

                var structureHeader = new ORM_DOC_Structure_Header();
                structureHeader.DOC_Structure_HeaderID = Guid.NewGuid();
                structureHeader.Label = Parameter.Name_DictID.Contents.FirstOrDefault().Content;
                structureHeader.Tenant_RefID = securityTicket.TenantID;
                var structureStatusSave = structureHeader.Save(Connection, Transaction);

                item.DOC_Structure_Header_RefID = structureHeader.DOC_Structure_HeaderID;

                #endregion

                #region ORM_TMS_PRO_ProjectMember

                #region ProjectMemberID

                String gpmProjectMember = EnumUtils.GetEnumDescription(ERightsPackage.ProjectMember);

                var parameter = new P_L2RP_GRPfGPM_1150();
                parameter.GlobalPropertyMatchingID = gpmProjectMember;

                var projectMemberID = cls_Get_RightPackage_for_GlobalPropertyMatchingID.Invoke(Connection, Transaction, parameter, securityTicket).Result;

                #endregion

                #region ProjectManagerID

                String gpmProjectManager = EnumUtils.GetEnumDescription(ERightsPackage.ProjectManager);

                parameter = new P_L2RP_GRPfGPM_1150();
                parameter.GlobalPropertyMatchingID = gpmProjectManager;

                var projectManagerID = cls_Get_RightPackage_for_GlobalPropertyMatchingID.Invoke(Connection, Transaction, parameter, securityTicket).Result;

                #endregion

                var projectMember = new ORM_TMS_PRO_ProjectMember();

                projectMember.Project_RefID = item.TMS_PRO_ProjectID;
                projectMember.USR_Account_RefID = securityTicket.AccountID;
                projectMember.IsDeleted = false;
                projectMember.Tenant_RefID = securityTicket.TenantID;
                projectMember.IsOwner = true;
                projectMember.Save(Connection, Transaction);

                ORM_TMS_PRO_Members_2_RightPackage assignment_member = new ORM_TMS_PRO_Members_2_RightPackage();
                assignment_member.ACC_RightsPackage_RefID = projectMemberID.TMS_PRO_ACC_RightsPackageID;
                assignment_member.ProjectMember_RefID = projectMember.TMS_PRO_ProjectMemberID;
                assignment_member.IsDeleted = false;
                assignment_member.Tenant_RefID = securityTicket.TenantID;
                assignment_member.Save(Connection, Transaction);

                ORM_TMS_PRO_Members_2_RightPackage assignment_manager = new ORM_TMS_PRO_Members_2_RightPackage();
                assignment_manager.ACC_RightsPackage_RefID = projectManagerID.TMS_PRO_ACC_RightsPackageID;
                assignment_manager.ProjectMember_RefID = projectMember.TMS_PRO_ProjectMemberID;
                assignment_manager.IsDeleted = false;
                assignment_manager.Tenant_RefID = securityTicket.TenantID;
                assignment_manager.Save(Connection, Transaction);
                #endregion

                item.Tenant_RefID = securityTicket.TenantID;
            }
            if(Parameter.Name_DictID!=null)
                item.Name = Parameter.Name_DictID;
            if(Parameter.Description_DictID!=null)
                item.Description = Parameter.Description_DictID;
            if(Parameter.Status_RefID!=null)
                item.Status_RefID = Parameter.Status_RefID;
            if (Parameter.Color != null)
                item.Color = Parameter.Color;

             

            return new FR_Guid(item.Save(Connection, Transaction), item.TMS_PRO_ProjectID);
          
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L3SPFT_SPN_1100 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L3SPFT_SPN_1100 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L3SPFT_SPN_1100 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3SPFT_SPN_1100 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Admin_Project_for_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3SPFT_SPN_1100 for attribute P_L3SPFT_SPN_1100
		[DataContract]
		public class P_L3SPFT_SPN_1100 
		{
			//Standard type parameters
			[DataMember]
			public Guid TMS_PRO_ProjectID { get; set; } 
			[DataMember]
			public Dict Name_DictID { get; set; } 
			[DataMember]
			public Dict Description_DictID { get; set; } 
			[DataMember]
			public String Color { get; set; } 
			[DataMember]
			public Guid Status_RefID { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 
			[DataMember]
			public Boolean IsArchived { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Admin_Project_for_Tenant(,P_L3SPFT_SPN_1100 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Admin_Project_for_Tenant.Invoke(connectionString,P_L3SPFT_SPN_1100 Parameter,securityTicket);
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
var parameter = new CL3_Project.Complex.Manipulation.P_L3SPFT_SPN_1100();
parameter.TMS_PRO_ProjectID = ...;
parameter.Name_DictID = ...;
parameter.Description_DictID = ...;
parameter.Color = ...;
parameter.Status_RefID = ...;
parameter.IsDeleted = ...;
parameter.IsArchived = ...;

*/
