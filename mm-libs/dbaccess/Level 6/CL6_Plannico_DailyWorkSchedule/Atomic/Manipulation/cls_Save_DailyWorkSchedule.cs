/* 
 * Generated on 3/25/2014 2:34:34 PM
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
using CL1_CMN_PPS;
using CL1_CMN_STR_PPS;
using CL1_CMN_BPT_EMP;
using CL6_Plannico_DailyWorkSchedule.Atomic.Manipulation;
using VacationPlaner.Utils;
using VacationPlaner;

namespace CL5_Plannico_DailyWorkSchedules.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_DailyWorkSchedule.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_DailyWorkSchedule
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L6DWS_SDWS_1053 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here

            ORM_CMN_STR_PPS_DailyWorkSchedule schedule = new ORM_CMN_STR_PPS_DailyWorkSchedule();
            if (Parameter.CMN_STR_PPS_DailyWorkScheduleID != Guid.Empty)
            {
                var result = schedule.Load(Connection, Transaction, Parameter.CMN_STR_PPS_DailyWorkScheduleID);
                if (result.Status != FR_Status.Success || schedule.CMN_STR_PPS_DailyWorkScheduleID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID.";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }



            schedule.Employee_RefID = Parameter.Employee_RefID;
            schedule.ContractWorkerText = Parameter.ContractWorkerText;
            schedule.BreakDurationTime_in_sec = Parameter.BreakDurationTime_in_sec;
            schedule.IsBreakTimeManualySpecified = Parameter.IsBreakTimeManualySpecified;
            schedule.IsWorkShedule_Confirmed = Parameter.IsWorkShedule_Confirmed;
            schedule.R_ContractSpecified_WorkingTime_in_sec = Parameter.R_ContractSpecified_WorkingTime_in_sec;
            schedule.R_WorkDay_Duration_in_sec = Parameter.R_WorkDay_Duration_in_sec;
            schedule.R_WorkDay_Start_in_sec = Parameter.R_WorkDay_Start_in_sec;
            schedule.R_WorkDay_End_in_sec = Parameter.R_WorkDay_Start_in_sec + Parameter.R_WorkDay_Duration_in_sec;
            schedule.SheduleBreakTemplate_RefID = Parameter.SheduleBreakTemplate_RefID;
            schedule.Tenant_RefID = securityTicket.TenantID;
            schedule.WorkingSheduleComment = Parameter.WorkingSheduleComment;
            schedule.ContractWorkerText = Parameter.ContractWorkerText;
            schedule.WorkShedule_ConfirmedBy_Account_RefID = Parameter.WorkShedule_ConfirmedBy_Account_RefID;
            schedule.WorkSheduleDate = Parameter.WorkSheduleDate;
            schedule.InstantiatedWithShiftTemplate_RefID = Parameter.InstantiatedWithShiftTemplate_RefID;
            schedule.Save(Connection, Transaction);           

            returnValue.Result = schedule.CMN_STR_PPS_DailyWorkScheduleID;
           
            



			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L6DWS_SDWS_1053 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L6DWS_SDWS_1053 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L6DWS_SDWS_1053 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6DWS_SDWS_1053 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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
				throw new Exception("Exception occured in method cls_Save_DailyWorkSchedule",ex);
			}
			return functionReturn;
		}
		#endregion
	}


}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_DailyWorkSchedule(,P_L6DWS_SDWS_1053 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_DailyWorkSchedule.Invoke(connectionString,P_L6DWS_SDWS_1053 Parameter,securityTicket);
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
var parameter = new CL5_Plannico_DailyWorkSchedules.Atomic.Manipulation.P_L6DWS_SDWS_1053();
parameter.Details = ...;

parameter.CMN_STR_PPS_DailyWorkScheduleID = ...;
parameter.Employee_RefID = ...;
parameter.WorkSheduleDate = ...;
parameter.InstantiatedWithShiftTemplate_RefID = ...;
parameter.SheduleBreakTemplate_RefID = ...;
parameter.IsBreakTimeManualySpecified = ...;
parameter.WorkingSheduleComment = ...;
parameter.ContractWorkerText = ...;
parameter.R_WorkDay_Start_in_sec = ...;
parameter.R_WorkDay_Duration_in_sec = ...;
parameter.BreakDurationTime_in_sec = ...;
parameter.IsWorkShedule_Confirmed = ...;
parameter.R_ContractSpecified_WorkingTime_in_sec = ...;
parameter.WorkShedule_ConfirmedBy_Account_RefID = ...;
parameter.LeaveTypeID = ...;
parameter.WorkplaceID = ...;
parameter.RequestedBy_Employee_RefID = ...;

*/