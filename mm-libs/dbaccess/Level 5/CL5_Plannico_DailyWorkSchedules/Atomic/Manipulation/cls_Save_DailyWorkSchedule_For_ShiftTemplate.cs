/* 
 * Generated on 12-Mar-14 14:48:27
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
using CL1_CMN_STR_PPS;
using PlannicoModel.Models;
using VacationPlaner;

namespace CL5_Plannico_DailyWorkSchedules.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_DailyWorkSchedule_For_ShiftTemplate.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_DailyWorkSchedule_For_ShiftTemplate
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5DWS_SDWSFST_1447 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Guid();

            ORM_CMN_PPS_ShiftTemplate.Query shiftTemplateQuery = new ORM_CMN_PPS_ShiftTemplate.Query();
            shiftTemplateQuery.CMN_PPS_ShiftTemplateID = Parameter.InstantiatedWithShiftTemplate_RefID;
            shiftTemplateQuery.Tenant_RefID = securityTicket.TenantID;
            shiftTemplateQuery.IsDeleted = false;

            ORM_CMN_PPS_ShiftTemplate shiftTemplate = ORM_CMN_PPS_ShiftTemplate.Query.Search(Connection, Transaction, shiftTemplateQuery).FirstOrDefault();

            

            ORM_CMN_PPS_ShiftTemplate_WorkDetail.Query shiftTemplateWorkDetailQuery = new ORM_CMN_PPS_ShiftTemplate_WorkDetail.Query();
            shiftTemplateWorkDetailQuery.CMN_PPS_ShiftTemplate_RefID = Parameter.InstantiatedWithShiftTemplate_RefID;
            shiftTemplateWorkDetailQuery.Tenant_RefID = securityTicket.TenantID;
            shiftTemplateWorkDetailQuery.IsDeleted = false;

            var shiftTemplateDetailsResult = ORM_CMN_PPS_ShiftTemplate_WorkDetail.Query.Search(Connection, Transaction, shiftTemplateWorkDetailQuery);

            double totalTime = 0;            
            DateTime? startTime = null;
            DateTime? endTime = null;

            foreach (var shiftTemplateDetail in shiftTemplateDetailsResult)
            {
                DateTime detailStartTime = Parameter.WorkSheduleDate.Date.AddSeconds(shiftTemplateDetail.ShiftStart_Offset_sec);
                DateTime detailEndTime = Parameter.WorkSheduleDate.Date.AddSeconds(shiftTemplateDetail.ShiftStart_Offset_sec +Math.Abs( shiftTemplateDetail.Duration_in_sec));

                if (startTime == null) startTime = detailStartTime;
                if (endTime == null) endTime = detailEndTime;

                if (detailStartTime < startTime) startTime = detailStartTime;
                if (detailEndTime > endTime) endTime = detailEndTime;

                totalTime += shiftTemplateDetail.Duration_in_sec;

            }

            double startTimeInSec = 0;
            double endTimeInSec = 0;

            if (startTime.HasValue)
                startTimeInSec = startTime.Value.TimeOfDay.TotalSeconds;

            if (endTime.HasValue)
                endTimeInSec = endTime.Value.TimeOfDay.TotalSeconds;

            ORM_CMN_STR_PPS_DailyWorkSchedule dailyWorkSchedule = new ORM_CMN_STR_PPS_DailyWorkSchedule();
            dailyWorkSchedule.IsBreakTimeManualySpecified = false;
            dailyWorkSchedule.SheduleBreakTemplate_RefID = shiftTemplate.Default_AllowedBreakTimeTemplate_RefID;
            dailyWorkSchedule.InstantiatedWithShiftTemplate_RefID = Parameter.InstantiatedWithShiftTemplate_RefID;

            if(shiftTemplate.Default_AllowedBreakTimeTemplate_RefID != Guid.Empty && Parameter.IsBreakTimeCalculated_Planning){
                ORM_CMN_PPS_BreakTime_Template_Assignment.Query breakTimeAssignmentQuery = new ORM_CMN_PPS_BreakTime_Template_Assignment.Query();
                breakTimeAssignmentQuery.BreakTime_Template_RefID = shiftTemplate.Default_AllowedBreakTimeTemplate_RefID;
                breakTimeAssignmentQuery.Tenant_RefID = securityTicket.TenantID;
                breakTimeAssignmentQuery.IsDeleted = false;
                var breakTimeAssignments = ORM_CMN_PPS_BreakTime_Template_Assignment.Query.Search(Connection, Transaction, breakTimeAssignmentQuery);
                foreach (var breakTimeAssignment in breakTimeAssignments)
                {
          

                ORM_CMN_PPS_BreakTime.Query breakTimeQuery = new ORM_CMN_PPS_BreakTime.Query();
                breakTimeQuery.CMN_PPS_BreakTimeID = breakTimeAssignment.BreakTime_RefID;
                breakTimeQuery.Tenant_RefID = securityTicket.TenantID;
                breakTimeQuery.IsDeleted = false;
                breakTimeQuery.IsDinnerBreak = false;
                breakTimeQuery.IsLunchBreak = false;
                breakTimeQuery.IsBreakfastBreak = false;

                var breakTime = ORM_CMN_PPS_BreakTime.Query.Search(Connection, Transaction, breakTimeQuery).FirstOrDefault();
                if (breakTime != null)
                {
                    dailyWorkSchedule.BreakDurationTime_in_sec += breakTime.Default_Duration_in_sec;
                }
                }
      
                

            }else
            {
                dailyWorkSchedule.BreakDurationTime_in_sec = 0;
            }

            dailyWorkSchedule.R_WorkDay_Start_in_sec = (int)startTimeInSec;
            dailyWorkSchedule.R_WorkDay_Duration_in_sec = (int)totalTime;
            dailyWorkSchedule.R_WorkDay_End_in_sec = (int)endTimeInSec;
            dailyWorkSchedule.R_ContractSpecified_WorkingTime_in_sec = Parameter.R_ContractSpecified_WorkingTime_in_sec;
            dailyWorkSchedule.ContractWorkerText = "";
            dailyWorkSchedule.Employee_RefID = Parameter.Employee_RefID;
            dailyWorkSchedule.WorkSheduleDate = Parameter.WorkSheduleDate.Date;
            dailyWorkSchedule.Tenant_RefID = securityTicket.TenantID;
  
            dailyWorkSchedule.Save(Connection, Transaction);
            returnValue.Result = dailyWorkSchedule.CMN_STR_PPS_DailyWorkScheduleID;
            foreach (var shiftTemplateDetail in shiftTemplateDetailsResult)
            {
                P_L5DWS_SDWSD_1130 detailParam = new P_L5DWS_SDWSD_1130();
                detailParam.WorkTime_Start = dailyWorkSchedule.WorkSheduleDate.AddSeconds(shiftTemplateDetail.ShiftStart_Offset_sec);
                detailParam.WorkTime_End = dailyWorkSchedule.WorkSheduleDate.AddSeconds(shiftTemplateDetail.ShiftStart_Offset_sec + shiftTemplateDetail.Duration_in_sec);
                detailParam.DailyWorkSchedule_RefID = dailyWorkSchedule.CMN_STR_PPS_DailyWorkScheduleID;
                detailParam.IsWorkBreak = false;
                detailParam.SheduleForWorkplace_RefID = Guid.Empty;
                detailParam.AbsenceReason_RefID = Guid.Empty;
                detailParam.RequestedBy_Employee_RefID = Guid.Empty;
                detailParam.RequestedFor_Employee_RefID = Parameter.Employee_RefID;
                cls_Save_Employee_DailyWorkSchedule_Detail.Invoke(Connection, Transaction, detailParam, securityTicket);
            }

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5DWS_SDWSFST_1447 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5DWS_SDWSFST_1447 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5DWS_SDWSFST_1447 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5DWS_SDWSFST_1447 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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
				throw ex;
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes


	#endregion
}
