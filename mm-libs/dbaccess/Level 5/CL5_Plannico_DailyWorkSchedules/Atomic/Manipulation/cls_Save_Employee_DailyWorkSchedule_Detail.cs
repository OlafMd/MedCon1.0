/* 
 * Generated on 08/05/2014 13:45:13
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
using CL1_CMN_CAL;
using PlannicoModel.Models;
using CL5_VacationPlanner_Contract.Atomic.Retrieval;
using CL1_CMN_BPT_EMP;
using CL1_CMN_STR_PPS;
using CL5_VacationPlanner_Contract.Atomic.Manipulation;
using VacationPlaner;

namespace CL5_Plannico_DailyWorkSchedules.Atomic.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Save_Employee_DailyWorkSchedule_Detail.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Save_Employee_DailyWorkSchedule_Detail
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Guid Execute(DbConnection Connection, DbTransaction Transaction, P_L5DWS_SDWSD_1130 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            //Leave UserCode region to enable user code saving
            #region UserCode
            var returnValue = new FR_Guid();
            //Put your code here

            ORM_CMN_STR_PPS_DailyWorkSchedule_Detail scheduleDetail = new ORM_CMN_STR_PPS_DailyWorkSchedule_Detail();
            if (Parameter.CMN_STR_PPS_DailyWorkSchedule_DetailID != Guid.Empty)
            {
                var result = scheduleDetail.Load(Connection, Transaction, Parameter.CMN_STR_PPS_DailyWorkSchedule_DetailID);
                if (result.Status != FR_Status.Success || scheduleDetail.CMN_STR_PPS_DailyWorkSchedule_DetailID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID.";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }

                scheduleDetail.AbsenceReason_RefID = Parameter.AbsenceReason_RefID;
                scheduleDetail.CMN_BPT_EMP_Employee_LeaveRequest_RefID = Parameter.CMN_BPT_EMP_Employee_LeaveRequest_RefID;
                scheduleDetail.CMN_CAL_Event_RefID = Parameter.CMN_CAL_Event_RefID;
                scheduleDetail.DailyWorkSchedule_RefID = Parameter.DailyWorkSchedule_RefID;
                scheduleDetail.IsWorkBreak = Parameter.IsWorkBreak;
                scheduleDetail.SheduleForWorkplace_RefID = Parameter.SheduleForWorkplace_RefID;
                scheduleDetail.Tenant_RefID = securityTicket.TenantID;
                scheduleDetail.Save(Connection, Transaction);

                ORM_CMN_CAL_Event.Query calEventQuery = new ORM_CMN_CAL_Event.Query();
                calEventQuery.CMN_CAL_EventID = Parameter.CMN_CAL_Event_RefID;
                calEventQuery.IsDeleted = false;
                calEventQuery.Tenant_RefID = securityTicket.TenantID;

                ORM_CMN_CAL_Event calEvent = ORM_CMN_CAL_Event.Query.Search(Connection, Transaction, calEventQuery).FirstOrDefault();                

                calEvent.StartTime = Parameter.WorkTime_Start;
                calEvent.EndTime = Parameter.WorkTime_End;
                calEvent.R_EventDuration_sec = (int)Parameter.WorkTime_End.Subtract(Parameter.WorkTime_Start).TotalSeconds;
                calEvent.Save(Connection, Transaction);

            }
            else
            {
                scheduleDetail.AbsenceReason_RefID = Parameter.AbsenceReason_RefID;
                scheduleDetail.CMN_BPT_EMP_Employee_LeaveRequest_RefID = Parameter.CMN_BPT_EMP_Employee_LeaveRequest_RefID;
                scheduleDetail.CMN_CAL_Event_RefID = Parameter.CMN_CAL_Event_RefID;
                scheduleDetail.DailyWorkSchedule_RefID = Parameter.DailyWorkSchedule_RefID;
                scheduleDetail.IsWorkBreak = Parameter.IsWorkBreak;
                scheduleDetail.SheduleForWorkplace_RefID = Parameter.SheduleForWorkplace_RefID;
                scheduleDetail.Tenant_RefID = securityTicket.TenantID;
               

                ORM_CMN_CAL_Event calEvent = new ORM_CMN_CAL_Event();
                calEvent.StartTime = Parameter.WorkTime_Start;
                calEvent.EndTime = Parameter.WorkTime_End;
                calEvent.R_EventDuration_sec = (int)(Parameter.WorkTime_End - Parameter.WorkTime_Start).TotalSeconds;
                calEvent.Tenant_RefID = securityTicket.TenantID;
                calEvent.Save(Connection, Transaction);

                scheduleDetail.CMN_CAL_Event_RefID = calEvent.CMN_CAL_EventID;
                scheduleDetail.Save(Connection, Transaction);
            }
            returnValue.Result = scheduleDetail.CMN_STR_PPS_DailyWorkSchedule_DetailID;

            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_Guid Invoke(string ConnectionString, P_L5DWS_SDWSD_1130 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, P_L5DWS_SDWSD_1130 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, P_L5DWS_SDWSD_1130 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_L5DWS_SDWSD_1130 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

                functionReturn = Execute(Connection, Transaction, Parameter, securityTicket);

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
                    if (cleanupTransaction == true && Transaction != null)
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
                throw new Exception("Exception occured in method cls_Save_Employee_DailyWorkSchedule_Detail", ex);
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
FR_Guid cls_Save_Employee_DailyWorkSchedule_Detail(,P_L5DWS_SDWSD_1130 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Employee_DailyWorkSchedule_Detail.Invoke(connectionString,P_L5DWS_SDWSD_1130 Parameter,securityTicket);
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
var parameter = new CL5_Plannico_DailyWorkSchedules.Atomic.Manipulation.P_L5DWS_SDWSD_1130();
parameter.CMN_STR_PPS_DailyWorkSchedule_DetailID = ...;
parameter.DailyWorkSchedule_RefID = ...;
parameter.CMN_CAL_Event_RefID = ...;
parameter.WorkTime_Start = ...;
parameter.WorkTime_End = ...;
parameter.AbsenceReason_RefID = ...;
parameter.SheduleForWorkplace_RefID = ...;
parameter.IsWorkBreak = ...;
parameter.RequestedBy_Employee_RefID = ...;
parameter.RequestedFor_Employee_RefID = ...;
parameter.durationInDays = ...;
parameter.durationInHours = ...;
parameter.OldDurationInDays = ...;
parameter.OldDurationInHours = ...;

*/
