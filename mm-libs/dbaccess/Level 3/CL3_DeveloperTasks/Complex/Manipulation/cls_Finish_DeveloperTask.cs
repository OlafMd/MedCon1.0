/* 
 * Generated on 7/16/2014 2:55:37 PM
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
using CL2_DeveloperTask.Atomic.Retrieval;
using DLCore_DBCommons.DanuTask;
using DLCore_DBCommons.Utils;
using CL1_TMS_PRO;
using CL1_TMP_PRO;
using CL1_USR;
using CL1_CMN_BPT;
using CL3_InvestedWorkTimes.Complex.Retrieval;

namespace CL3_DeveloperTask.Complex.Manipulation
{
	/// <summary>
    /// 

    
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Finish_DeveloperTask.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Finish_DeveloperTask
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L3DT_FDT_1646 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
            //Put your code here

            #region Finished Status ID

            var Parameter_StatusFinished = new P_L2DT_GDTSfGPM_1121();
            Parameter_StatusFinished.GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(EDeveloperTaskHistory.Finished);
            var StatusFinished = cls_Get_DeveloperTaskStatus_for_GlobalPropertyMatchingID.Invoke(Connection, Transaction, Parameter_StatusFinished, securityTicket).Result;

            var Parameter_StatusStarted = new P_L2DT_GDTSfGPM_1121();
            Parameter_StatusStarted.GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(EDeveloperTaskHistory.Started);
            var StatusStarted = cls_Get_DeveloperTaskStatus_for_GlobalPropertyMatchingID.Invoke(Connection, Transaction, Parameter_StatusStarted, securityTicket).Result;

            #endregion

            #region Developer Task involvement
            ORM_TMS_PRO_DeveloperTask_Involvement DeveloperTask_Involvemnet = new ORM_TMS_PRO_DeveloperTask_Involvement();
            DeveloperTask_Involvemnet.Load(Connection, Transaction, Parameter.DeveloperTask_InvolvementID);

            DeveloperTask_Involvemnet.IsActive = false;
            DeveloperTask_Involvemnet.IsArchived = true;
            DeveloperTask_Involvemnet.R_InvestedWorkingTime_min += Parameter.DeveloperTask_InvestedTime;

            DeveloperTask_Involvemnet.Save(Connection, Transaction);
            #endregion

            #region Developer Task

            //ORM_TMS_PRO_DeveloperTask_Involvement.Query InvolvementQuery = new ORM_TMS_PRO_DeveloperTask_Involvement.Query();
            //InvolvementQuery.DeveloperTask_RefID = DeveloperTask_Involvemnet.DeveloperTask_RefID;

            //var InvestedTime = ORM_TMS_PRO_DeveloperTask_Involvement.Query.Search(Connection, Transaction, InvolvementQuery).Sum(i => i.R_InvestedWorkingTime_min);

            ORM_TMS_PRO_DeveloperTask DeveloperTask = new ORM_TMS_PRO_DeveloperTask();
            DeveloperTask.Load(Connection, Transaction, DeveloperTask_Involvemnet.DeveloperTask_RefID);
            DeveloperTask.DeveloperTime_CurrentInvestment_min += Parameter.DeveloperTask_InvestedTime;
            DeveloperTask.Completion_Timestamp = DateTime.Now;
            DeveloperTask.PercentageComplete = "100";
            DeveloperTask.IsComplete = true;
            DeveloperTask.Save(Connection, Transaction);

            //Retrieve start task timestamp
            ORM_TMS_PRO_DeveloperTask_StatusHistory.Query DeveloperTask_History_Query = new ORM_TMS_PRO_DeveloperTask_StatusHistory.Query();
            DeveloperTask_History_Query.DeveloperTask_Status_RefID = StatusStarted.TMS_PRO_DeveloperTask_StatusID;
            DeveloperTask_History_Query.DeveloperTask_RefID = DeveloperTask.TMS_PRO_DeveloperTaskID;
            DeveloperTask_History_Query.TriggeredBy_ProjectMember_RefID = DeveloperTask_Involvemnet.ProjectMember_RefID;
            List<ORM_TMS_PRO_DeveloperTask_StatusHistory> statusHistoryResult = ORM_TMS_PRO_DeveloperTask_StatusHistory.Query.Search(Connection, Transaction, DeveloperTask_History_Query);
            

            //Status History
            ORM_TMS_PRO_DeveloperTask_StatusHistory DeveloperTask_StatusHistory = new ORM_TMS_PRO_DeveloperTask_StatusHistory();
            DeveloperTask_StatusHistory.DeveloperTask_RefID = DeveloperTask.TMS_PRO_DeveloperTaskID;
            DeveloperTask_StatusHistory.DeveloperTask_Status_RefID = StatusFinished.TMS_PRO_DeveloperTask_StatusID;
            DeveloperTask_StatusHistory.TriggeredBy_ProjectMember_RefID = DeveloperTask_Involvemnet.ProjectMember_RefID;
            DeveloperTask_StatusHistory.Comment = Parameter.DeveloperTask_Comment!=""? "Comment: "+Parameter.DeveloperTask_Comment+"</br>"+ "Invested time : " 
                + DeveloperTask_Involvemnet.R_InvestedWorkingTime_min + " minutes":
                 "Invested time: " + DeveloperTask_Involvemnet.R_InvestedWorkingTime_min + " minutes";
            DeveloperTask_StatusHistory.Tenant_RefID = securityTicket.TenantID;
            DeveloperTask_StatusHistory.Save(Connection, Transaction);

            #endregion

            #region Charging Level
            ORM_TMP_PRO_ProjectMember_Type_AvailableChargingLevel DefaultChargingLevel = null;
            ORM_TMS_PRO_ProjectMember GrabbedByMember = new ORM_TMS_PRO_ProjectMember();
            GrabbedByMember.Load(Connection, Transaction, DeveloperTask.GrabbedByMember_RefID);

            if(GrabbedByMember != null)
            {
                ORM_TMP_PRO_ProjectMember_Type_AvailableChargingLevel.Query ChargingLevelQuery = new ORM_TMP_PRO_ProjectMember_Type_AvailableChargingLevel.Query();
                ChargingLevelQuery.ProjectMember_Type_RefID = GrabbedByMember.ProjectMember_Type_RefID;
                ChargingLevelQuery.IsDeleted = false;

                List<ORM_TMP_PRO_ProjectMember_Type_AvailableChargingLevel> AvailbaleChargingLevels =
                        ORM_TMP_PRO_ProjectMember_Type_AvailableChargingLevel.Query.Search(Connection, Transaction, ChargingLevelQuery);

                if (AvailbaleChargingLevels.Exists(acl => acl.IsDefault))
                {
                    DefaultChargingLevel = AvailbaleChargingLevels.Where(acl => acl.IsDefault).FirstOrDefault();
                }
                else if(AvailbaleChargingLevels.Count>0)
                {
                    DefaultChargingLevel = AvailbaleChargingLevels.FirstOrDefault();
                }
            }

            #endregion

            #region Invested WorkTimes

            //User Account
            ORM_USR_Account UserAccount = new ORM_USR_Account();
            UserAccount.Load(Connection, Transaction, securityTicket.AccountID);


            ORM_CMN_BPT_InvestedWorkTime InvestedWorkTimes = new ORM_CMN_BPT_InvestedWorkTime();
            InvestedWorkTimes.BusinessParticipant_RefID = UserAccount.BusinessParticipant_RefID;
            InvestedWorkTimes.WorkTime_Start = statusHistoryResult.OrderBy(c => c.Creation_Timestamp).LastOrDefault().Creation_Timestamp;
            InvestedWorkTimes.WorkTime_Amount_min = Parameter.DeveloperTask_InvestedTime;
            InvestedWorkTimes.WorkTime_InternalIdentifier = cls_Get_New_InvestedWorkTime_Identifier.Invoke(Connection, Transaction, securityTicket).Result.IWT_Identifier;
            InvestedWorkTimes.WorkTime_Source = "DanuTask - [D" + DeveloperTask.IdentificationNumber + "] " + DeveloperTask.Name;
            InvestedWorkTimes.WorkTime_Comment.AddEntry(Parameter.LanguageID, Parameter.DeveloperTask_Comment);
            InvestedWorkTimes.ChargingLevel_RefID = DefaultChargingLevel != null ? DefaultChargingLevel.ChargingLevel_RefID : Guid.Empty;
            InvestedWorkTimes.Tenant_RefID = securityTicket.TenantID;
            InvestedWorkTimes.Save(Connection, Transaction);
            #endregion

            #region Developer Task Involvements Invested time
            ORM_TMS_PRO_DeveloperTask_Involvements_InvestedWorkTime DeveloperTaskInvolvements_InvestedTime = new ORM_TMS_PRO_DeveloperTask_Involvements_InvestedWorkTime();
            DeveloperTaskInvolvements_InvestedTime.CMN_BPT_InvestedWorkTime_RefID = InvestedWorkTimes.CMN_BPT_InvestedWorkTimeID;
            DeveloperTaskInvolvements_InvestedTime.TMS_PRO_DeveloperTask_Involvement_RefID = DeveloperTask_Involvemnet.TMS_PRO_DeveloperTask_InvolvementID;
            DeveloperTaskInvolvements_InvestedTime.Tenant_RefID = securityTicket.TenantID;
            DeveloperTaskInvolvements_InvestedTime.Save(Connection, Transaction);
            #endregion

            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L3DT_FDT_1646 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L3DT_FDT_1646 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L3DT_FDT_1646 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3DT_FDT_1646 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Finish_DeveloperTask",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3DT_FDT_1646 for attribute P_L3DT_FDT_1646
		[DataContract]
		public class P_L3DT_FDT_1646 
		{
			//Standard type parameters
			[DataMember]
			public Guid DeveloperTask_InvolvementID { get; set; } 
			[DataMember]
			public long DeveloperTask_InvestedTime { get; set; } 
			[DataMember]
			public String DeveloperTask_Comment { get; set; } 
			[DataMember]
			public Guid LanguageID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Finish_DeveloperTask(,P_L3DT_FDT_1646 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Finish_DeveloperTask.Invoke(connectionString,P_L3DT_FDT_1646 Parameter,securityTicket);
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
var parameter = new CL3_DeveloperTask.Complex.Manipulation.P_L3DT_FDT_1646();
parameter.DeveloperTask_InvolvementID = ...;
parameter.DeveloperTask_InvestedTime = ...;
parameter.DeveloperTask_Comment = ...;
parameter.LanguageID = ...;

*/
