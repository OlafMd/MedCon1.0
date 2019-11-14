/* 
 * Generated on 15-Apr-14 13:55:55
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
using PlannicoModel.Models;
using CL1_CMN_STR_PPS;
using CL5_Plannico_DailyWorkSchedules.Atomic.Retrieval;
using VacationPlaner;

namespace CL5_Plannico_DailyWorkSchedules.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_DailyWorkSchedules_WithDetails_For_Period_And_EmployeeID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_DailyWorkSchedules_WithDetails_For_Period_And_EmployeeID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5DWS_GDWSWDFPAE_1331 Execute(DbConnection Connection,DbTransaction Transaction,P_L5DWS_GDWSWDFPAE_1331 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_L5DWS_GDWSWDFPAE_1331();
			//Put your code here

            List<L5DWS_GDWSWDFT_0946> resultList = new List<L5DWS_GDWSWDFT_0946>();

            var periodLength = (Parameter.PeriodEndDate.Date - Parameter.PeriodStartDate.Date).TotalDays + 1;

            for (var i = 0; i < periodLength; i++)
            {
                ORM_CMN_STR_PPS_DailyWorkSchedule.Query scheduleQuery = new ORM_CMN_STR_PPS_DailyWorkSchedule.Query();
                scheduleQuery.Employee_RefID = Parameter.EmployeeID;
                scheduleQuery.Tenant_RefID = securityTicket.TenantID;
                scheduleQuery.IsDeleted = false;
                scheduleQuery.WorkSheduleDate = Parameter.PeriodStartDate.Date.AddDays(i);
                List<ORM_CMN_STR_PPS_DailyWorkSchedule> workSechedules = ORM_CMN_STR_PPS_DailyWorkSchedule.Query.Search(Connection, Transaction, scheduleQuery);
                var scheduleList = new List<L5DWS_GDWSWDFT_0946>();
                foreach (var workSchedule in workSechedules)
                {
                    var resultItem = new L5DWS_GDWSWDFT_0946();
                    resultItem.BreakDurationTime_in_sec = workSchedule.BreakDurationTime_in_sec;
                    resultItem.CMN_STR_PPS_DailyWorkScheduleID = workSchedule.CMN_STR_PPS_DailyWorkScheduleID;
                    resultItem.ContractWorkerText = workSchedule.ContractWorkerText;
                    resultItem.Employee_RefID = workSchedule.Employee_RefID;
                    resultItem.InstantiatedWithShiftTemplate_RefID = workSchedule.InstantiatedWithShiftTemplate_RefID;
                    resultItem.IsBreakTimeManualySpecified = workSchedule.IsBreakTimeManualySpecified;
                    resultItem.IsWorkShedule_Confirmed = workSchedule.IsWorkShedule_Confirmed;
                    resultItem.R_ContractSpecified_WorkingTime_in_sec = workSchedule.R_ContractSpecified_WorkingTime_in_sec;
                    resultItem.R_WorkDay_Duration_in_sec = workSchedule.R_WorkDay_Duration_in_sec;
                    resultItem.R_WorkDay_End_in_sec = workSchedule.R_WorkDay_End_in_sec;
                    resultItem.R_WorkDay_Start_in_sec = workSchedule.R_WorkDay_Start_in_sec;
                    resultItem.SheduleBreakTemplate_RefID = workSchedule.SheduleBreakTemplate_RefID;
                    resultItem.WorkingSheduleComment = workSchedule.WorkingSheduleComment;
                    resultItem.WorkShedule_ConfirmedBy_Account_RefID = workSchedule.WorkShedule_ConfirmedBy_Account_RefID;
                    resultItem.WorkSheduleDate = workSchedule.WorkSheduleDate;
                    P_L5DWS_GDWSDFDWSID_1156 par = new P_L5DWS_GDWSDFDWSID_1156();
                    par.DailyWorkScheduleID = workSchedule.CMN_STR_PPS_DailyWorkScheduleID;
                    List<L5DWS_GDWSDFDWSID_1156> details = cls_Get_DailyWorkSchedule_Detail_For_DailyWorkScheduleID.Invoke(Connection, Transaction, par, securityTicket).Result.ToList();
                    List<L5DWS_GDWSWDFT_0946_Detail> resultDetails = new List<L5DWS_GDWSWDFT_0946_Detail>();
                    foreach (var detail in details)
                    {
                        L5DWS_GDWSWDFT_0946_Detail resultDetail = new L5DWS_GDWSWDFT_0946_Detail();
                        resultDetail.AbsenceReason_RefID = detail.AbsenceReason_RefID;
                        resultDetail.CMN_CAL_Event_RefID = detail.CMN_CAL_Event_RefID;
                        resultDetail.CMN_STR_PPS_DailyWorkSchedule_DetailID = detail.CMN_STR_PPS_DailyWorkSchedule_DetailID;
                        resultDetail.FromTime_as_DateTime = detail.FromTime_as_DateTime;
                        resultDetail.FromTime_as_time = detail.FromTime_as_time;
                        resultDetail.IsWorkBreak = detail.IsWorkBreak;
                        resultDetail.SheduleForWorkplace_RefID = detail.SheduleForWorkplace_RefID;
                        resultDetail.TotalWorkTime_as_time = detail.TotalWorkTime_as_time;
                        resultDetail.ToTime_as_DateTime = detail.ToTime_as_DateTime;
                        resultDetail.ToTime_as_time = detail.ToTime_as_time;
                        resultDetail.LeaveRequest_RefID = detail.LeaveRequest_RefID;
                        resultDetails.Add(resultDetail);
                    }
                    resultItem.Details = resultDetails.ToArray();
                    P_L5DWS_GEWTFDID_1406 param = new P_L5DWS_GEWTFDID_1406();
                    param.DailyWorkScheduleID = workSchedule.CMN_STR_PPS_DailyWorkScheduleID;
                    //resultItem.ActualDetails = cls_Get_EffectiveWorkTimes_For_DailyWorkScheduleID.Invoke(Connection, Transaction, param, securityTicket).Result;

                    scheduleList.Add(resultItem);
                }
                resultList.AddRange(scheduleList);
            }

            returnValue.Result = new L5DWS_GDWSWDFPAE_1331();
            returnValue.Result.DailyWorkSchedulesWithDetails = resultList.ToArray();

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5DWS_GDWSWDFPAE_1331 Invoke(string ConnectionString,P_L5DWS_GDWSWDFPAE_1331 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5DWS_GDWSWDFPAE_1331 Invoke(DbConnection Connection,P_L5DWS_GDWSWDFPAE_1331 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5DWS_GDWSWDFPAE_1331 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5DWS_GDWSWDFPAE_1331 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5DWS_GDWSWDFPAE_1331 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5DWS_GDWSWDFPAE_1331 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5DWS_GDWSWDFPAE_1331 functionReturn = new FR_L5DWS_GDWSWDFPAE_1331();
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

                Guid errorID = Guid.NewGuid();
                ServerLog.Instance.Fatal("Application error occured. ErrorID = " + errorID, ex);
				throw ex;
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5DWS_GDWSWDFPAE_1331 : FR_Base
	{
		public L5DWS_GDWSWDFPAE_1331 Result	{ get; set; }

		public FR_L5DWS_GDWSWDFPAE_1331() : base() {}

		public FR_L5DWS_GDWSWDFPAE_1331(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes

	#endregion
}
