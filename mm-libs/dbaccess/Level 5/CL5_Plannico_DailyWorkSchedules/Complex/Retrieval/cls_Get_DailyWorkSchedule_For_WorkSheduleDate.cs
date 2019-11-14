/* 
 * Generated on 14-Jan-14 17:52:35
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
using CL5_Plannico_DailyWorkSchedules.Atomic.Retrieval;
using PlannicoModel.Models;
using VacationPlaner;

namespace CL5_Plannico_DailyWorkSchedules.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_DailyWorkSchedule_For_WorkSheduleDate.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_DailyWorkSchedule_For_WorkSheduleDate
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5DWS_GDWSFWSD_1748 Execute(DbConnection Connection,DbTransaction Transaction,P_L5DWS_GDWSFWSD_1748 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_L5DWS_GDWSFWSD_1748();
			//Put your code here
            returnValue.Result = new L5DWS_GDWSFWSD_1748();

            ORM_CMN_STR_PPS_DailyWorkSchedule.Query scheduleQuery = new ORM_CMN_STR_PPS_DailyWorkSchedule.Query();
            scheduleQuery.WorkSheduleDate = Parameter.WorkSheduleDate;
            scheduleQuery.Tenant_RefID = securityTicket.TenantID;
            scheduleQuery.IsDeleted = false;

            var schedules = ORM_CMN_STR_PPS_DailyWorkSchedule.Query.Search(Connection, Transaction, scheduleQuery);

            List<L5DWS_GDWSFT_1154> resultSchedules =  new List<L5DWS_GDWSFT_1154>();

            foreach (var schedule in schedules)
            {
                L5DWS_GDWSFT_1154 resultSchedule = new L5DWS_GDWSFT_1154();
                resultSchedule.BreakDurationTime_in_sec = schedule.BreakDurationTime_in_sec;
                resultSchedule.CMN_STR_PPS_DailyWorkScheduleID = schedule.CMN_STR_PPS_DailyWorkScheduleID;
                resultSchedule.ContractWorkerText = schedule.ContractWorkerText;
                resultSchedule.Employee_RefID = schedule.Employee_RefID;
                resultSchedule.InstantiatedWithShiftTemplate_RefID = schedule.InstantiatedWithShiftTemplate_RefID;
                resultSchedule.IsBreakTimeManualySpecified = schedule.IsBreakTimeManualySpecified;
                resultSchedule.IsWorkShedule_Confirmed = schedule.IsWorkShedule_Confirmed;
                resultSchedule.R_ContractSpecified_WorkingTime_in_sec = schedule.R_ContractSpecified_WorkingTime_in_sec;
                resultSchedule.R_WorkDay_Duration_in_sec = schedule.R_WorkDay_Duration_in_sec;
                resultSchedule.R_WorkDay_Start_in_sec = schedule.R_WorkDay_Start_in_sec;
                resultSchedule.SheduleBreakTemplate_RefID = schedule.SheduleBreakTemplate_RefID;
                resultSchedule.WorkingSheduleComment = schedule.WorkingSheduleComment;
                resultSchedule.WorkShedule_ConfirmedBy_Account_RefID = schedule.WorkShedule_ConfirmedBy_Account_RefID;
                resultSchedule.WorkSheduleDate = schedule.WorkSheduleDate;
                resultSchedule.R_WorkDay_End_in_sec = schedule.R_WorkDay_End_in_sec;

                resultSchedules.Add(resultSchedule);
            }

            returnValue.Result.DailyWorkSchedules = resultSchedules.ToArray();


			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5DWS_GDWSFWSD_1748 Invoke(string ConnectionString,P_L5DWS_GDWSFWSD_1748 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5DWS_GDWSFWSD_1748 Invoke(DbConnection Connection,P_L5DWS_GDWSFWSD_1748 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5DWS_GDWSFWSD_1748 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5DWS_GDWSFWSD_1748 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5DWS_GDWSFWSD_1748 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5DWS_GDWSFWSD_1748 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5DWS_GDWSFWSD_1748 functionReturn = new FR_L5DWS_GDWSFWSD_1748();
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
	public class FR_L5DWS_GDWSFWSD_1748 : FR_Base
	{
		public L5DWS_GDWSFWSD_1748 Result	{ get; set; }

		public FR_L5DWS_GDWSFWSD_1748() : base() {}

		public FR_L5DWS_GDWSFWSD_1748(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes


	#endregion
}
