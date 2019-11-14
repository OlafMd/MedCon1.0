/* 
 * Generated on 20/05/2014 11:30:05
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
using CL1_CMN_PPS;
using CL5_Plannico_DailyWorkSchedules.Complex.Retrieval;
using CL1_CMN_CAL;
using CL1_CMN_BPT_EMP;
using CL5_VacationPlanner_Tenant.Atomic.Retrieval;
using CL5_VacationPlanner_Contract.Atomic.Retrieval;
using CL5_VacationPlanner_Contract.Atomic.Manipulation;
using VacationPlaner.Utils;
using CL5_VacationPlanner_Tenant.Complex.Retrieval;
using CL5_VacationPlanner_Absence.Atomic.Retrieval;
using CL6_VacationPlanner_Tenant.Atomic.Retrieval;
using VacationPlaner;

namespace CL5_Plannico_DailyWorkSchedules.Atomic.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Update_DailyWorkSchedule.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Update_DailyWorkSchedule
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Base Execute(DbConnection Connection, DbTransaction Transaction, P_L6DWS_UDWS_1129 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            //Leave UserCode region to enable user code saving
            #region UserCode
            var returnValue = new FR_Base();

            ORM_CMN_STR_PPS_DailyWorkSchedule.Query scheduleQuery = new ORM_CMN_STR_PPS_DailyWorkSchedule.Query();
            scheduleQuery.Employee_RefID = Parameter.EmployeeID;
            scheduleQuery.WorkSheduleDate = Parameter.WorkscheduleDate;
            scheduleQuery.Tenant_RefID = securityTicket.TenantID;
            scheduleQuery.IsDeleted = false;
            List<ORM_CMN_STR_PPS_DailyWorkSchedule> schedules = ORM_CMN_STR_PPS_DailyWorkSchedule.Query.Search(Connection, Transaction, scheduleQuery);
            if (schedules.Count == 1)
            {
                ORM_CMN_STR_PPS_DailyWorkSchedule schedule = schedules[0];
                if (Parameter.SheduleBreakTemplate_RefID != Guid.Empty)
                {
                    ORM_CMN_PPS_BreakTime_Template breakTemplate = new ORM_CMN_PPS_BreakTime_Template();
                    var result = breakTemplate.Load(Connection, Transaction, Parameter.SheduleBreakTemplate_RefID);
                    if (result.Status != FR_Status.Success || breakTemplate.CMN_PPS_BreakTime_TemplateID == Guid.Empty)
                    {
                        var error = new FR_Guid();
                        error.ErrorMessage = "No Such ID.";
                        error.Status = FR_Status.Error_Internal;
                        return error;
                    }

                    int duration = 0;
                    ORM_CMN_PPS_BreakTime_Template_Assignment.Query breakeTimeAssigmentQuery = new ORM_CMN_PPS_BreakTime_Template_Assignment.Query();
                    breakeTimeAssigmentQuery.IsDeleted = false;
                    breakeTimeAssigmentQuery.Tenant_RefID = securityTicket.TenantID;
                    breakeTimeAssigmentQuery.BreakTime_Template_RefID = breakTemplate.CMN_PPS_BreakTime_TemplateID;
                    List<ORM_CMN_PPS_BreakTime_Template_Assignment> breakTimeAssignemnts = ORM_CMN_PPS_BreakTime_Template_Assignment.Query.Search(Connection, Transaction, breakeTimeAssigmentQuery);
                    foreach (var assignment in breakTimeAssignemnts)
                    {
                        ORM_CMN_PPS_BreakTime breakeTime = new ORM_CMN_PPS_BreakTime();
                        breakeTime.Load(Connection, Transaction, assignment.BreakTime_RefID);
                        duration += breakeTime.Default_Duration_in_sec;
                        

                    }
                    schedule.SheduleBreakTemplate_RefID = breakTemplate.CMN_PPS_BreakTime_TemplateID;
                    schedule.BreakDurationTime_in_sec = duration;
                    schedule.Save(Connection, Transaction);
                }
                else
                {
                    P_L5DWS_GDWSDFDWSID_1156 par = new P_L5DWS_GDWSDFDWSID_1156();
                    par.DailyWorkScheduleID = schedule.CMN_STR_PPS_DailyWorkScheduleID;
                    List<L5DWS_GDWSDFDWSID_1156> details = cls_Get_DailyWorkSchedule_Detail_For_DailyWorkScheduleID.Invoke(Connection, Transaction, par, securityTicket).Result.ToList();
                    foreach (var detail in details)
                    {
                        ORM_CMN_STR_PPS_DailyWorkSchedule_Detail scheduleDetail = new ORM_CMN_STR_PPS_DailyWorkSchedule_Detail();
                        var result = scheduleDetail.Load(Connection, Transaction, detail.CMN_STR_PPS_DailyWorkSchedule_DetailID);
                        if (result.Status != FR_Status.Success || scheduleDetail.CMN_STR_PPS_DailyWorkSchedule_DetailID == Guid.Empty)
                        {
                            var error = new FR_Guid();
                            error.ErrorMessage = "No Such ID.";
                            error.Status = FR_Status.Error_Internal;
                            return error;
                        }
                        scheduleDetail.SheduleForWorkplace_RefID = Parameter.WorkplaceID;
                        scheduleDetail.Save(Connection, Transaction);
               
                    }
                }
            }


            //Put your code here
            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_Base Invoke(string ConnectionString, P_L6DWS_UDWS_1129 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Base Invoke(DbConnection Connection, P_L6DWS_UDWS_1129 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction, P_L6DWS_UDWS_1129 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_L6DWS_UDWS_1129 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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
                throw new Exception("Exception occured in method cls_Update_DailyWorkSchedule", ex);
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
FR_Base cls_Update_DailyWorkSchedule(,P_L6DWS_UDWS_1129 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Base invocationResult = cls_Update_DailyWorkSchedule.Invoke(connectionString,P_L6DWS_UDWS_1129 Parameter,securityTicket);
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
var parameter = new CL5_Plannico_DailyWorkSchedules.Atomic.Manipulation.P_L6DWS_UDWS_1129();
parameter.LeaveTypeID = ...;
parameter.WorkplaceID = ...;

*/
