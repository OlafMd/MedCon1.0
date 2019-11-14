/* 
 * Generated on 01/08/2014 15:20:27
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
using CL1_CMN_PPS;
using PlannicoModel.Models;
using VacationPlannerCore.Utils;
using CL5_Plannico_Breaks.Complex.Retrieval;
using CL1_CMN_STR_PPS;

namespace CL5_Plannico_ShiftTimes.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ShiftTemplates_With_Details_For_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ShiftTemplates_With_Details_For_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5ST_GSTWDFT_1520_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5ST_GSTWDFT_1520_Array();

            List<L5ST_GSTWDFT_1520> shiftTemplatesReturn = new List<L5ST_GSTWDFT_1520>();

            ORM_CMN_PPS_ShiftTemplate.Query shiftTemplateQuery = new ORM_CMN_PPS_ShiftTemplate.Query();
            shiftTemplateQuery.Tenant_RefID = securityTicket.TenantID;
            shiftTemplateQuery.IsDeleted = false;
            List<ORM_CMN_PPS_ShiftTemplate> shiftTemplates = ORM_CMN_PPS_ShiftTemplate.Query.Search(Connection, Transaction, shiftTemplateQuery);
            foreach (var shiftTemplate in shiftTemplates)
            {
                L5ST_GSTWDFT_1520 templateItem = new L5ST_GSTWDFT_1520();
                templateItem.CMN_PPS_ShiftTemplateID = shiftTemplate.CMN_PPS_ShiftTemplateID;
                templateItem.CMN_STR_Office_RefID = shiftTemplate.CMN_STR_Office_RefID;
                templateItem.CMN_STR_Workarea_RefID = shiftTemplate.CMN_STR_Workarea_RefID;
                templateItem.CMN_STR_Workplace_RefID = shiftTemplate.CMN_STR_Workplace_RefID;
                templateItem.ShiftTemplate_Name = shiftTemplate.ShiftTemplate_Name;
                templateItem.ShiftTemplate_ShortName = shiftTemplate.ShiftTemplate_ShortName;
                templateItem.Default_AllowedBreakTimeTemplate_RefID = shiftTemplate.Default_AllowedBreakTimeTemplate_RefID;
                templateItem.DisplayColor = shiftTemplate.DisplayColor;

                ORM_CMN_PPS_ShiftTemplate_WorkDetail.Query workdetailsQuery = new ORM_CMN_PPS_ShiftTemplate_WorkDetail.Query();
                workdetailsQuery.IsDeleted = false;
                workdetailsQuery.Tenant_RefID = securityTicket.TenantID;
                workdetailsQuery.CMN_PPS_ShiftTemplate_RefID = shiftTemplate.CMN_PPS_ShiftTemplateID;
                List<ORM_CMN_PPS_ShiftTemplate_WorkDetail> workDetails = ORM_CMN_PPS_ShiftTemplate_WorkDetail.Query.Search(Connection, Transaction, workdetailsQuery);
                if (workDetails != null && workDetails.Count != 0)
                {
                    int startingTime = 0;
                    int endingTime = 0;
                    double totalWorkTime = 0;
                    foreach (var workDetail in workDetails)
                    {
                        if (startingTime == 0 || (startingTime > workDetail.ShiftStart_Offset_sec && workDetail.ShiftStart_Offset_sec != 0))
                        {
                            startingTime = (int)workDetail.ShiftStart_Offset_sec;
                        }
                        if (endingTime < workDetail.ShiftStart_Offset_sec + workDetail.Duration_in_sec)
                        {
                            endingTime = (int)workDetail.ShiftStart_Offset_sec + (int)workDetail.Duration_in_sec;
                        }

                        totalWorkTime += workDetail.Duration_in_sec;
                    }

                    templateItem.EndTime = CronExtender.secondsToTime(endingTime);
                    templateItem.StartTime = CronExtender.secondsToTime(startingTime);
                    templateItem.Worktime = CronExtender.secondsToTime(Int32.Parse(totalWorkTime.ToString()));
                }
                else
                {

                    templateItem.EndTime = CronExtender.secondsToTime(0);
                    templateItem.StartTime = CronExtender.secondsToTime(0);
                    templateItem.Worktime = CronExtender.secondsToTime(0);
                }
                int brakeTime = 0;
                if (shiftTemplate.Default_AllowedBreakTimeTemplate_RefID != Guid.Empty)
                {
                    P_L5BR_GBMFTID_1537 par = new P_L5BR_GBMFTID_1537();
                    par.CMN_PPS_BreakTime_TemplateID = shiftTemplate.Default_AllowedBreakTimeTemplate_RefID;
                    L5BR_GBMFTID_1537 breakModel = cls_Get_BreakModels_For_TemplateID.Invoke(Connection, Transaction, par, securityTicket).Result;
                    brakeTime = breakModel.BreakModel.Duration;
                    templateItem.BrakeTime = CronExtender.secondsToTime(brakeTime);
                    templateItem.Worktime = CronExtender.secondsToTime(CronExtender.timeToSeconds(templateItem.Worktime) - brakeTime);
                }
                else
                {

                    templateItem.BrakeTime = CronExtender.secondsToTime(0);
                }
                P_L5ST_GSTQFST_1516 param = new P_L5ST_GSTQFST_1516();
                param.ShiftTemplateID = shiftTemplate.CMN_PPS_ShiftTemplateID;
                templateItem.Qualifications = cls_Get_ShiftQualifications_For_ShiftTemplateID.Invoke(Connection, Transaction, param, securityTicket).Result;

                List<L5ST_GSTWDFT_1520_Detail> returnList = new List<L5ST_GSTWDFT_1520_Detail>();

                ORM_CMN_PPS_ShiftTemplate_WorkDetail.Query shiftTemplateDetailQuery = new ORM_CMN_PPS_ShiftTemplate_WorkDetail.Query();
                shiftTemplateDetailQuery.Tenant_RefID = securityTicket.TenantID;
                shiftTemplateDetailQuery.IsDeleted = false;
                shiftTemplateDetailQuery.CMN_PPS_ShiftTemplate_RefID = shiftTemplate.CMN_PPS_ShiftTemplateID;
                List<ORM_CMN_PPS_ShiftTemplate_WorkDetail> shiftTemplateDetails = ORM_CMN_PPS_ShiftTemplate_WorkDetail.Query.Search(Connection, Transaction, shiftTemplateDetailQuery);
                foreach (var shiftTemplateDetail in shiftTemplateDetails)
                {
                    L5ST_GSTWDFT_1520_Detail shiftTemplateDetailItem = new L5ST_GSTWDFT_1520_Detail();
                    shiftTemplateDetailItem.CMN_PPS_ShiftTemplate_WorkDetailID = shiftTemplateDetail.CMN_PPS_ShiftTemplate_WorkDetailID;
                    shiftTemplateDetailItem.Duration_in_sec = shiftTemplateDetail.Duration_in_sec;
                    shiftTemplateDetailItem.Required_StaffHeadCount = shiftTemplateDetail.Required_StaffHeadCount;
                    shiftTemplateDetailItem.ShiftStart_Offset_sec = shiftTemplateDetail.ShiftStart_Offset_sec;
                    shiftTemplateDetailItem.WorkDetail_Note_Content = shiftTemplateDetail.WorkDetail_Note_Content;
                    shiftTemplateDetailItem.WorkDetail_Note_Title = shiftTemplateDetail.WorkDetail_Note_Title;

                    ORM_CMN_STR_PPS_WorkDetail_Activity.Query activityDetailQuery = new ORM_CMN_STR_PPS_WorkDetail_Activity.Query();
                    activityDetailQuery.IsDeleted = false;
                    activityDetailQuery.Tenant_RefID = securityTicket.TenantID;
                    activityDetailQuery.CMN_PPS_ShiftTemplate_WorkDetail_RefID = shiftTemplateDetail.CMN_PPS_ShiftTemplate_WorkDetailID;
                    List<ORM_CMN_STR_PPS_WorkDetail_Activity> activityDetails = ORM_CMN_STR_PPS_WorkDetail_Activity.Query.Search(Connection, Transaction, activityDetailQuery);
                    if (activityDetails != null && activityDetails.Count != 0)
                    {
                        ORM_CMN_STR_PPS_WorkDetail_Activity activityDetail = activityDetails.FirstOrDefault();
                        shiftTemplateDetailItem.CMN_STR_PPS_Workplace_RefID = activityDetail.CMN_STR_PPS_Workplace_RefID;

                        if (activityDetail.CMN_STR_PPS_Activity_RefID != Guid.Empty)
                        {
                            ORM_CMN_STR_PPS_Activity activity = new ORM_CMN_STR_PPS_Activity();
                            activity.Load(Connection, Transaction, activityDetail.CMN_STR_PPS_Activity_RefID);
                            shiftTemplateDetailItem.AbsenceReason_RefID = activity.AbsenceReason_RefID;
                        }

                    }
               
                    returnList.Add(shiftTemplateDetailItem);
                }
                templateItem.Details = returnList.ToArray();

                shiftTemplatesReturn.Add(templateItem);

            }

            returnValue.Result = shiftTemplatesReturn.ToArray();

			//Put your code here
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5ST_GSTWDFT_1520_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5ST_GSTWDFT_1520_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5ST_GSTWDFT_1520_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5ST_GSTWDFT_1520_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5ST_GSTWDFT_1520_Array functionReturn = new FR_L5ST_GSTWDFT_1520_Array();
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

				throw new Exception("Exception occured in method cls_Get_ShiftTemplates_With_Details_For_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5ST_GSTWDFT_1520_Array : FR_Base
	{
		public L5ST_GSTWDFT_1520[] Result	{ get; set; } 
		public FR_L5ST_GSTWDFT_1520_Array() : base() {}

		public FR_L5ST_GSTWDFT_1520_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes


	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5ST_GSTWDFT_1520_Array cls_Get_ShiftTemplates_With_Details_For_Tenant(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5ST_GSTWDFT_1520_Array invocationResult = cls_Get_ShiftTemplates_With_Details_For_Tenant.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

