/* 
 * Generated on 21/05/2014 18:35:36
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
using VacationPlaner;

namespace CL6_Plannico_DailyWorkSchedule.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_DailyWorkSchedule_LeaveType.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_DailyWorkSchedule_LeaveType
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L6DWS_SDWSLT_1819 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_Guid();

            DateTime startTime = Parameter.WorkSheduleDate.AddMinutes(Parameter.dayStartInMins);

            ORM_CMN_STR_PPS_DailyWorkSchedule dailyWorkSchedule = new ORM_CMN_STR_PPS_DailyWorkSchedule();

            double startTimeInSec = startTime.TimeOfDay.TotalSeconds;
            double endTimeInSec = startTime.TimeOfDay.TotalSeconds + Parameter.R_ContractSpecified_WorkingTime_in_sec;

            if (Parameter.DailyWorkScheduleID != Guid.Empty)
            {
                ORM_CMN_STR_PPS_DailyWorkSchedule.Query dailyWorkScheduleQuery = new ORM_CMN_STR_PPS_DailyWorkSchedule.Query();
                dailyWorkScheduleQuery.CMN_STR_PPS_DailyWorkScheduleID = Parameter.DailyWorkScheduleID;
                dailyWorkScheduleQuery.Tenant_RefID = securityTicket.TenantID;
                dailyWorkScheduleQuery.IsDeleted = false;

                ORM_CMN_STR_PPS_DailyWorkSchedule dailyWorkScheduleForSave = ORM_CMN_STR_PPS_DailyWorkSchedule.Query.Search(Connection, Transaction, dailyWorkScheduleQuery).FirstOrDefault();
                dailyWorkScheduleForSave.IsBreakTimeManualySpecified = false;
                dailyWorkScheduleForSave.BreakDurationTime_in_sec = 0;

                dailyWorkScheduleForSave.R_WorkDay_Start_in_sec = (int)startTimeInSec;
                dailyWorkScheduleForSave.R_WorkDay_Duration_in_sec = Parameter.R_ContractSpecified_WorkingTime_in_sec;
                dailyWorkScheduleForSave.R_WorkDay_End_in_sec = (int)endTimeInSec;
                dailyWorkScheduleForSave.R_ContractSpecified_WorkingTime_in_sec = Parameter.R_ContractSpecified_WorkingTime_in_sec;
                dailyWorkScheduleForSave.ContractWorkerText = "";
                dailyWorkScheduleForSave.Employee_RefID = Parameter.Employee_RefID;
                dailyWorkScheduleForSave.WorkSheduleDate = Parameter.WorkSheduleDate.Date;

                dailyWorkScheduleForSave.Save(Connection, Transaction);

                dailyWorkSchedule = dailyWorkScheduleForSave;
            }
            else
            {

                ORM_CMN_STR_PPS_DailyWorkSchedule dailyWorkScheduleForSave = new ORM_CMN_STR_PPS_DailyWorkSchedule();
                dailyWorkScheduleForSave.IsBreakTimeManualySpecified = false;
                dailyWorkScheduleForSave.BreakDurationTime_in_sec = 0;

                dailyWorkScheduleForSave.R_WorkDay_Start_in_sec = (int)startTimeInSec;
                dailyWorkScheduleForSave.R_WorkDay_Duration_in_sec = Parameter.R_ContractSpecified_WorkingTime_in_sec;
                dailyWorkScheduleForSave.R_WorkDay_End_in_sec = (int)endTimeInSec;
                dailyWorkScheduleForSave.R_ContractSpecified_WorkingTime_in_sec = Parameter.R_ContractSpecified_WorkingTime_in_sec;
                dailyWorkScheduleForSave.ContractWorkerText = "";
                dailyWorkScheduleForSave.Employee_RefID = Parameter.Employee_RefID;
                dailyWorkScheduleForSave.WorkSheduleDate = Parameter.WorkSheduleDate.Date;
                dailyWorkScheduleForSave.Tenant_RefID = securityTicket.TenantID;

                dailyWorkScheduleForSave.Save(Connection, Transaction);

                dailyWorkSchedule = dailyWorkScheduleForSave;
            }
            P_L6DWS_SDWSD_1130 detailParam = new P_L6DWS_SDWSD_1130();
            detailParam.WorkTime_Start = dailyWorkSchedule.WorkSheduleDate.AddSeconds(startTimeInSec);
            detailParam.WorkTime_End = dailyWorkSchedule.WorkSheduleDate.AddSeconds(endTimeInSec);
            detailParam.DailyWorkSchedule_RefID = dailyWorkSchedule.CMN_STR_PPS_DailyWorkScheduleID;
            detailParam.IsWorkBreak = false;
            detailParam.SheduleForWorkplace_RefID = Guid.Empty;
            detailParam.AbsenceReason_RefID = Parameter.LeaveTypeID;
            detailParam.RequestedBy_Employee_RefID = Guid.Empty;
            detailParam.RequestedFor_Employee_RefID = Parameter.Employee_RefID;
            detailParam.durationInDays = Parameter.durationInDays;
            detailParam.durationInHours = Parameter.durationInHours;
            cls_Save_DailyWorkSchedule_Detail.Invoke(Connection, Transaction, detailParam, securityTicket);

            returnValue.Result = dailyWorkSchedule.CMN_STR_PPS_DailyWorkScheduleID;

            //Put your code here
            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L6DWS_SDWSLT_1819 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L6DWS_SDWSLT_1819 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L6DWS_SDWSLT_1819 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6DWS_SDWSLT_1819 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

                Guid errorID = Guid.NewGuid();
                ServerLog.Instance.Fatal("Application error occured. ErrorID = " + errorID, ex);
				throw new Exception("Exception occured in method cls_Save_DailyWorkSchedule_LeaveType",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes


	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_DailyWorkSchedule_LeaveType(,P_L6DWS_SDWSLT_1819 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_DailyWorkSchedule_LeaveType.Invoke(connectionString,P_L6DWS_SDWSLT_1819 Parameter,securityTicket);
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
var parameter = new CL6_Plannico_DailyWorkSchedule.Atomic.Manipulation.P_L6DWS_SDWSLT_1819();
parameter.WorkSheduleDate = ...;
parameter.LeaveTypeID = ...;
parameter.R_ContractSpecified_WorkingTime_in_sec = ...;
parameter.Employee_RefID = ...;
parameter.durationInDays = ...;
parameter.durationInHours = ...;

*/
