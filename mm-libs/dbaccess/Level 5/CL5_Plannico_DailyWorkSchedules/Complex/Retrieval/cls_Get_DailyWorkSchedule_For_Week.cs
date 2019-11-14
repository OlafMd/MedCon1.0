/* 
 * Generated on 29/04/2014 10:51:02
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

namespace CL5_Plannico_DailyWorkSchedules.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_DailyWorkSchedule_For_Week.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_DailyWorkSchedule_For_Week
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5DWS_GDWSFW_1148 Execute(DbConnection Connection,DbTransaction Transaction,P_L5DWS_GDWSFW_1148 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5DWS_GDWSFW_1148();
            //Put your code here
            returnValue.Result = new L5DWS_GDWSFW_1148();

            List<L5DWS_GDWSFT_1154> resultSchedules = new List<L5DWS_GDWSFT_1154>();

            DateTime scheduleDate = Parameter.WeekStartDate.Date;

            for (var i = 0; i < 7; i++)
            {
                
                ORM_CMN_STR_PPS_DailyWorkSchedule.Query scheduleQuery = new ORM_CMN_STR_PPS_DailyWorkSchedule.Query();
                scheduleQuery.WorkSheduleDate = scheduleDate;
                scheduleQuery.Tenant_RefID = securityTicket.TenantID;
                scheduleQuery.IsDeleted = false;

                var schedules = ORM_CMN_STR_PPS_DailyWorkSchedule.Query.Search(Connection, Transaction, scheduleQuery); 

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
                scheduleDate = scheduleDate.AddDays(1);
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
		public static FR_L5DWS_GDWSFW_1148 Invoke(string ConnectionString,P_L5DWS_GDWSFW_1148 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5DWS_GDWSFW_1148 Invoke(DbConnection Connection,P_L5DWS_GDWSFW_1148 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5DWS_GDWSFW_1148 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5DWS_GDWSFW_1148 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5DWS_GDWSFW_1148 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5DWS_GDWSFW_1148 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5DWS_GDWSFW_1148 functionReturn = new FR_L5DWS_GDWSFW_1148();
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
				throw new Exception("Exception occured in method cls_Get_DailyWorkSchedule_For_Week",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5DWS_GDWSFW_1148 : FR_Base
	{
		public L5DWS_GDWSFW_1148 Result	{ get; set; }

		public FR_L5DWS_GDWSFW_1148() : base() {}

		public FR_L5DWS_GDWSFW_1148(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5DWS_GDWSFW_1148 cls_Get_DailyWorkSchedule_For_Week(,P_L5DWS_GDWSFW_1148 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5DWS_GDWSFW_1148 invocationResult = cls_Get_DailyWorkSchedule_For_Week.Invoke(connectionString,P_L5DWS_GDWSFW_1148 Parameter,securityTicket);
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
var parameter = new CL5_Plannico_DailyWorkSchedules.Complex.Retrieval.P_L5DWS_GDWSFW_1148();
parameter.WeekStartDate = ...;

*/
