/* 
 * Generated on 15/04/2014 13:14:04
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
using CL1_CMN_STR_PPS;
using PlannicoModel.Models;
using CL5_Plannico_DailyWorkSchedules.Atomic.Retrieval;
using VacationPlaner;

namespace CL5_Plannico_DailyWorkSchedules.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_DailyWorkSchedules_WithDetails_For_Period.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_DailyWorkSchedules_WithDetails_For_Period
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5DWS_GDWSWDFP_1225 Execute(DbConnection Connection,DbTransaction Transaction,P_L5DWS_GDWSWDFP_1225 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5DWS_GDWSWDFP_1225();

            List<L5DWS_GDWSWDFT_0946> resultList = new List<L5DWS_GDWSWDFT_0946>();
            DateTime currentDate = Parameter.StartDate.Date;
            while (currentDate.Ticks <= Parameter.EndDate.Ticks)
            {
                    ORM_CMN_STR_PPS_DailyWorkSchedule.Query scheduleQuery = new ORM_CMN_STR_PPS_DailyWorkSchedule.Query();
                    scheduleQuery.Tenant_RefID = securityTicket.TenantID;
                    scheduleQuery.IsDeleted = false;
                    scheduleQuery.WorkSheduleDate = currentDate;
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
                        P_L5DWS_GEWTFD_1648 param = new P_L5DWS_GEWTFD_1648();
                        param.currentDate = currentDate;                        

                        scheduleList.Add(resultItem);
                    }
                    resultList.AddRange(scheduleList);
                    currentDate = currentDate.AddDays(1);
                
            }

            returnValue.Result = new L5DWS_GDWSWDFP_1225();
            returnValue.Result.DailyWorkSchedulesWithDetails = resultList.ToArray();
			//Put your code here
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5DWS_GDWSWDFP_1225 Invoke(string ConnectionString,P_L5DWS_GDWSWDFP_1225 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5DWS_GDWSWDFP_1225 Invoke(DbConnection Connection,P_L5DWS_GDWSWDFP_1225 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5DWS_GDWSWDFP_1225 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5DWS_GDWSWDFP_1225 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5DWS_GDWSWDFP_1225 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5DWS_GDWSWDFP_1225 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5DWS_GDWSWDFP_1225 functionReturn = new FR_L5DWS_GDWSWDFP_1225();
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
				throw new Exception("Exception occured in method cls_Get_DailyWorkSchedules_WithDetails_For_Period",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5DWS_GDWSWDFP_1225 : FR_Base
	{
		public L5DWS_GDWSWDFP_1225 Result	{ get; set; }

		public FR_L5DWS_GDWSWDFP_1225() : base() {}

		public FR_L5DWS_GDWSWDFP_1225(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
	

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5DWS_GDWSWDFP_1225 cls_Get_DailyWorkSchedules_WithDetails_For_Period(,P_L5DWS_GDWSWDFP_1225 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5DWS_GDWSWDFP_1225 invocationResult = cls_Get_DailyWorkSchedules_WithDetails_For_Period.Invoke(connectionString,P_L5DWS_GDWSWDFP_1225 Parameter,securityTicket);
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
var parameter = new CL5_Plannico_DailyWorkSchedules.Complex.Retrieval.P_L5DWS_GDWSWDFP_1225();
parameter.StartDate = ...;
parameter.EndDate = ...;

*/
