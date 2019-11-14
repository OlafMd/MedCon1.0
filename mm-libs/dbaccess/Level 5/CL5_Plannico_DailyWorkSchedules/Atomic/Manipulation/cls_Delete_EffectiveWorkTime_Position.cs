/* 
 * Generated on 09-May-14 11:31:32
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
using CL1_CMN_BPT_EMP;
using CL1_CMN_CAL;
using CL5_VacationPlanner_Contract.Atomic.Retrieval;
using CL5_VacationPlanner_Contract.Atomic.Manipulation;
using VacationPlaner;

namespace CL5_Plannico_DailyWorkSchedules.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Delete_EffectiveWorkTime_Position.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Delete_EffectiveWorkTime_Position
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Base Execute(DbConnection Connection,DbTransaction Transaction,P_L5DWS_DEWTP_1130 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Base();
			//Put your code here

            ORM_CMN_BPT_EMP_EffectiveWorkTime_Position.Query positionQuery = new ORM_CMN_BPT_EMP_EffectiveWorkTime_Position.Query();
            positionQuery.CMN_BPT_EMP_EffectiveWorkTime_PositionID = Parameter.CMN_BPT_EMP_EffectiveWorkTime_PositionID;
            positionQuery.IsDeleted = false;
            positionQuery.Tenant_RefID = securityTicket.TenantID;

            var position = ORM_CMN_BPT_EMP_EffectiveWorkTime_Position.Query.Search(Connection, Transaction, positionQuery).FirstOrDefault();
            if (position == null)
                return null;

            ORM_CMN_BPT_EMP_Employee_LeaveRequest leaveRequest = new ORM_CMN_BPT_EMP_Employee_LeaveRequest();
            Guid leaveRequestID = Guid.Empty;
            if (position.CMN_BPT_EMP_Employee_LeaveRequest_RefID != Guid.Empty)
            {
                leaveRequestID = position.CMN_BPT_EMP_Employee_LeaveRequest_RefID;
            }


            if (leaveRequestID != Guid.Empty)
            {
                leaveRequest.Load(Connection, Transaction, leaveRequestID);
                leaveRequest.Remove(Connection, Transaction);

                ORM_CMN_CAL_Event leaveRequestEvent = new ORM_CMN_CAL_Event();
                leaveRequestEvent.Load(Connection, Transaction, leaveRequest.CMN_CAL_Event_RefID);
                leaveRequestEvent.Remove(Connection, Transaction);

                var calQuery = new ORM_CMN_CAL_Event.Query();
                calQuery.CMN_CAL_EventID = leaveRequest.CMN_CAL_Event_RefID;
                var calendarRes = ORM_CMN_CAL_Event.Query.Search(Connection, Transaction, calQuery);
                ORM_CMN_CAL_Event calendarEvent = calendarRes[0];
                var timeFrame = cls_Get_CalculationTimeFramesForTenant.Invoke(Connection, Transaction, securityTicket).Result.Where(x => x.CalculationTimeframe_StartDate.Year == calendarEvent.StartTime.Year).FirstOrDefault();

                P_L5EM_GEATFSbRTFE_1423 statParam = new P_L5EM_GEATFSbRTFE_1423();
                statParam.absenceReasonID = leaveRequest.CMN_BPT_STA_AbsenceReason_RefID;
                statParam.employeeID = leaveRequest.RequestedFor_Employee_RefID;
                statParam.timeFrameID = timeFrame.CMN_CAL_CalculationTimeframeID;
                var statistics = cls_Get_Employee_AbsenceReason_TimeframeStatistic_byReasonTimeFrameEmployee.Invoke(Connection, Transaction, statParam, securityTicket).Result;
                if (statistics != null)
                {
                    P_L5EM_SEARTFS_1356 updateStatisticsParam = new P_L5EM_SEARTFS_1356();
                    updateStatisticsParam.CMN_BPT_EMP_Employee_AbsenceReason_TimeframeStatisticsID = statistics.CMN_BPT_EMP_Employee_AbsenceReason_TimeframeStatisticsID;
                    updateStatisticsParam.Employee_RefID = statistics.Employee_RefID;
                    updateStatisticsParam.CalculationTimeframe_RefID = statistics.CalculationTimeframe_RefID;
                    updateStatisticsParam.AbsenceReason_RefID = statistics.AbsenceReason_RefID;

                    updateStatisticsParam.R_AbsenceCarryOver_InDays = statistics.R_AbsenceCarryOver_InDays;
                    updateStatisticsParam.R_AbsenceCarryOver_InHours = statistics.R_AbsenceCarryOver_InHours;

                    updateStatisticsParam.R_TotalAllowedAbsenceTime_InDays = statistics.R_TotalAllowedAbsenceTime_InDays + Parameter.durationInDays;
                    updateStatisticsParam.R_TotalAllowedAbsenceTime_InHours = statistics.R_TotalAllowedAbsenceTime_InHours + Parameter.durationInHours;

                    updateStatisticsParam.R_RequestReservedAbsence_InDays = statistics.R_RequestReservedAbsence_InDays ;
                    updateStatisticsParam.R_RequestReservedAbsence_InHours = statistics.R_RequestReservedAbsence_InHours ;

                    updateStatisticsParam.R_AbsenceTimeUsed_InDays = statistics.R_AbsenceTimeUsed_InDays - Parameter.durationInDays;
                    updateStatisticsParam.R_AbsenceTimeUsed_InHours = statistics.R_AbsenceTimeUsed_InHours - Parameter.durationInHours;

                    var res = cls_Save_Employee_AbsenceReason_TimeframeStatistic.Invoke(Connection, Transaction, updateStatisticsParam, securityTicket);
                }
            }

            position.IsDeleted = true;
            position.Save(Connection, Transaction);

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Base Invoke(string ConnectionString,P_L5DWS_DEWTP_1130 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection,P_L5DWS_DEWTP_1130 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction,P_L5DWS_DEWTP_1130 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5DWS_DEWTP_1130 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Base functionReturn = new FR_Base();
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
