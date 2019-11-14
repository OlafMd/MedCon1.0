/* 
 * Generated on 7/15/2014 6:10:24 PM
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
using DLCore_DBCommons.Utils;
using DLCore_DBCommons.DanuTask;
using CL2_DeveloperTask.Atomic.Retrieval;
using CL1_USR;
using CL1_TMP_PRO;
using CL1_CMN_BPT;
using CL3_InvestedWorkTimes.Complex.Retrieval;

namespace CL3_DeveloperTask.Complex.Manipulation
{
	/// <summary>
    /// 
    /// Active developer task gets stopped
    
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Stop_DeveloperTask.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Stop_DeveloperTask
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L3DT_SDT_1808 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Guid();
            //Put your code here
            #region StatusID's

            var Parameter_StoppedStatus = new P_L2DT_GDTSfGPM_1121();
            Parameter_StoppedStatus.GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(EDeveloperTaskHistory.Stopped);
            var StoppedStatus_ID = cls_Get_DeveloperTaskStatus_for_GlobalPropertyMatchingID.Invoke(Connection, Transaction, Parameter_StoppedStatus, securityTicket).Result;

            #endregion

            #region Involvement
            ORM_TMS_PRO_DeveloperTask_Involvement DeveloperTask_Involvement = new ORM_TMS_PRO_DeveloperTask_Involvement();
            DeveloperTask_Involvement.Load(Connection, Transaction, Parameter.DeveloperTask_InvolvementID);

            //Update invested time on involvement
            DeveloperTask_Involvement.R_InvestedWorkingTime_min += Parameter.DeveloperTask_InvestedTime;
            DeveloperTask_Involvement.Save(Connection, Transaction);

            #endregion

            #region Developer task
            ORM_TMS_PRO_DeveloperTask DeveloperTask = new ORM_TMS_PRO_DeveloperTask();
            DeveloperTask.Load(Connection, Transaction, Parameter.DeveloperTask_ID);

            DeveloperTask.IsIncompleteInformation = Parameter.DeveloperTask_IsMissingInfo;
            DeveloperTask.PercentageComplete = Parameter.DeveloperTask_PercentageComplete.ToString();
            DeveloperTask.DeveloperTime_CurrentInvestment_min += Parameter.DeveloperTask_InvestedTime;

            DeveloperTask.Save(Connection, Transaction);

            #endregion

            #region Update developer task status history

            ORM_TMS_PRO_DeveloperTask_StatusHistory DeveloperTask_StatusHistory = new ORM_TMS_PRO_DeveloperTask_StatusHistory();

            DeveloperTask_StatusHistory.DeveloperTask_RefID = Parameter.DeveloperTask_ID;
            DeveloperTask_StatusHistory.DeveloperTask_Status_RefID = StoppedStatus_ID.TMS_PRO_DeveloperTask_StatusID;
            DeveloperTask_StatusHistory.TriggeredBy_ProjectMember_RefID = DeveloperTask_Involvement.ProjectMember_RefID;
            DeveloperTask_StatusHistory.CreatedFor_ProjectMember_RefID = Guid.Empty;
            DeveloperTask_StatusHistory.Comment = Parameter.DeveloperTask_StopComment != "" ? "Comment: " + Parameter.DeveloperTask_StopComment +"</br>" : "";            
            DeveloperTask_StatusHistory.Comment += "Total invested time:  " + DeveloperTask_Involvement.R_InvestedWorkingTime_min +
                                                    " minutes" + "</br>" +
                                                    "Current invested time:  " + Parameter.DeveloperTask_InvestedTime +
                                                    " minutes" + "</br>" +
                                                    " Percentage complete: " + Parameter.DeveloperTask_PercentageComplete + "%\n";
            DeveloperTask_StatusHistory.Tenant_RefID = securityTicket.TenantID;
            DeveloperTask_StatusHistory.Save(Connection, Transaction);

            if (Parameter.DeveloperTask_IsMissingInfo)
            {
                //TODO: Change active developer task


                var Parameter_MissingInfoStatus = new P_L2DT_GDTSfGPM_1121();
                Parameter_MissingInfoStatus.GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(EDeveloperTaskHistory.MissingInfo);
                var MissingInfoStatus_ID = cls_Get_DeveloperTaskStatus_for_GlobalPropertyMatchingID.Invoke(Connection, Transaction, Parameter_MissingInfoStatus, securityTicket).Result;


                DeveloperTask_StatusHistory = new ORM_TMS_PRO_DeveloperTask_StatusHistory();
                DeveloperTask_StatusHistory.DeveloperTask_RefID = Parameter.DeveloperTask_ID;
                DeveloperTask_StatusHistory.DeveloperTask_Status_RefID = MissingInfoStatus_ID.TMS_PRO_DeveloperTask_StatusID;
                DeveloperTask_StatusHistory.TriggeredBy_ProjectMember_RefID = DeveloperTask_Involvement.ProjectMember_RefID;
                DeveloperTask_StatusHistory.CreatedFor_ProjectMember_RefID = Guid.Empty;
                DeveloperTask_StatusHistory.Comment = Parameter.DeveloperTask_StopComment;
                DeveloperTask_StatusHistory.Tenant_RefID = securityTicket.TenantID;
                DeveloperTask_StatusHistory.Save(Connection, Transaction);
            }


            #endregion 

            #region Load user account

            ORM_USR_Account UserAccount = new ORM_USR_Account();
            UserAccount.Load(Connection, Transaction, securityTicket.AccountID);

            #endregion

            #region Default charging level
            ORM_TMP_PRO_ProjectMember_Type_AvailableChargingLevel DefaultChargingLevel = null;
            ORM_TMS_PRO_ProjectMember DeveloperTask_GrabbedByMember = new ORM_TMS_PRO_ProjectMember();
            DeveloperTask_GrabbedByMember.Load(Connection, Transaction, DeveloperTask.GrabbedByMember_RefID);
            if (DeveloperTask_GrabbedByMember != null)
            {
                ORM_TMP_PRO_ProjectMember_Type_AvailableChargingLevel.Query SelectChargingLevel = new ORM_TMP_PRO_ProjectMember_Type_AvailableChargingLevel.Query();
                SelectChargingLevel.ProjectMember_Type_RefID = DeveloperTask_GrabbedByMember.ProjectMember_Type_RefID;
                SelectChargingLevel.IsDeleted = false;

                 List<ORM_TMP_PRO_ProjectMember_Type_AvailableChargingLevel> AvailableChargingLevels =
                      ORM_TMP_PRO_ProjectMember_Type_AvailableChargingLevel.Query.Search(Connection, Transaction, SelectChargingLevel);

                 if (AvailableChargingLevels.Count > 0)
                 {
                     if (AvailableChargingLevels.Exists(acl => acl.IsDefault))
                     {
                         DefaultChargingLevel = AvailableChargingLevels.Where(acl => acl.IsDefault).FirstOrDefault();
                     }
                     else
                     {
                         DefaultChargingLevel = AvailableChargingLevels.FirstOrDefault();
                     }
                 }
            }
            #endregion

            #region Invested work times
            ORM_CMN_BPT_InvestedWorkTime InvestedWorkTimes = new ORM_CMN_BPT_InvestedWorkTime();
            InvestedWorkTimes.BusinessParticipant_RefID = UserAccount.BusinessParticipant_RefID;
            InvestedWorkTimes.ChargingLevel_RefID = DefaultChargingLevel != null ? DefaultChargingLevel.ChargingLevel_RefID : Guid.Empty;
            InvestedWorkTimes.Tenant_RefID = securityTicket.TenantID;
            InvestedWorkTimes.WorkTime_Amount_min = Parameter.DeveloperTask_InvestedTime;
            InvestedWorkTimes.WorkTime_Comment.AddEntry(Parameter.LanguageID, Parameter.DeveloperTask_StopComment);
            InvestedWorkTimes.WorkTime_Start = DateTime.Now.AddMinutes(-Parameter.DeveloperTask_InvestedTime);
            InvestedWorkTimes.WorkTime_InternalIdentifier = cls_Get_New_InvestedWorkTime_Identifier.Invoke(Connection, Transaction, securityTicket).Result.IWT_Identifier;
            InvestedWorkTimes.WorkTime_Source = "Danutask - [D"+DeveloperTask.IdentificationNumber+"] "+DeveloperTask.Name;
            InvestedWorkTimes.Tenant_RefID = securityTicket.TenantID;
            InvestedWorkTimes.WorkTime_Comment.AddEntry(Parameter.LanguageID, Parameter.DeveloperTask_StopComment);
            InvestedWorkTimes.Save(Connection, Transaction);
            #endregion



            #region Developer task invested work times
            ORM_TMS_PRO_DeveloperTask_Involvements_InvestedWorkTime DeveloperTaskInvolvement_InvestedTime = new ORM_TMS_PRO_DeveloperTask_Involvements_InvestedWorkTime();
            DeveloperTaskInvolvement_InvestedTime.CMN_BPT_InvestedWorkTime_RefID = InvestedWorkTimes.CMN_BPT_InvestedWorkTimeID;
            DeveloperTaskInvolvement_InvestedTime.TMS_PRO_DeveloperTask_Involvement_RefID = DeveloperTask_Involvement.TMS_PRO_DeveloperTask_InvolvementID;
            DeveloperTaskInvolvement_InvestedTime.Tenant_RefID = securityTicket.TenantID;
            DeveloperTaskInvolvement_InvestedTime.Save(Connection, Transaction);
            #endregion


            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L3DT_SDT_1808 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L3DT_SDT_1808 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L3DT_SDT_1808 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3DT_SDT_1808 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Stop_DeveloperTask",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3DT_SDT_1808 for attribute P_L3DT_SDT_1808
		[DataContract]
		public class P_L3DT_SDT_1808 
		{
			//Standard type parameters
			[DataMember]
			public Guid DeveloperTask_ID { get; set; } 
			[DataMember]
			public Guid DeveloperTask_InvolvementID { get; set; } 
			[DataMember]
			public long DeveloperTask_InvestedTime { get; set; } 
			[DataMember]
			public String DeveloperTask_StopComment { get; set; } 
			[DataMember]
			public bool DeveloperTask_IsMissingInfo { get; set; } 
			[DataMember]
			public Double DeveloperTask_PercentageComplete { get; set; } 
			[DataMember]
			public Guid LanguageID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Stop_DeveloperTask(,P_L3DT_SDT_1808 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Stop_DeveloperTask.Invoke(connectionString,P_L3DT_SDT_1808 Parameter,securityTicket);
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
var parameter = new CL3_DeveloperTask.Complex.Manipulation.P_L3DT_SDT_1808();
parameter.DeveloperTask_ID = ...;
parameter.DeveloperTask_InvolvementID = ...;
parameter.DeveloperTask_InvestedTime = ...;
parameter.DeveloperTask_StopComment = ...;
parameter.DeveloperTask_IsMissingInfo = ...;
parameter.DeveloperTask_PercentageComplete = ...;
parameter.LanguageID = ...;

*/
