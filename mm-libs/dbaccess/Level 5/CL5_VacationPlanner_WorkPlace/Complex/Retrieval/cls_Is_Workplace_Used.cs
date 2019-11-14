/* 
 * Generated on 14/08/2014 15:05:52
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
using CL1_CMN_BPT_EMP;
using CL1_CMN_PPS;
using CL1_CMN_STR_PPS;
using PlannicoModel.Models;

namespace CL5_VacationPlanner_WorkPlace.complex.Retrieval
{
    /// <summary>
    /// No description found in <meta/> tag
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Is_Workplace_Used.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Is_Workplace_Used
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Bool Execute(DbConnection Connection, DbTransaction Transaction, P_L5WP_IWPU_1503 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_Bool();
            //Put your code here

            ORM_CMN_BPT_EMP_Employee_PlanGroup.Query planGroupQuery = new ORM_CMN_BPT_EMP_Employee_PlanGroup.Query();
            planGroupQuery.BoundTo_WorkPlace_RefID = Parameter.WorkplaceID;
            planGroupQuery.IsDeleted = false;
            planGroupQuery.Tenant_RefID = securityTicket.TenantID;
            if (ORM_CMN_BPT_EMP_Employee_PlanGroup.Query.Exists(Connection, Transaction, planGroupQuery))
                returnValue.Result = true;

            ORM_CMN_BPT_EMP_ExtraWorkCalculation_StructureBinding.Query extraWorkCalculationQuery = new ORM_CMN_BPT_EMP_ExtraWorkCalculation_StructureBinding.Query();
            extraWorkCalculationQuery.BoundTo_Workplace_RefID = Parameter.WorkplaceID;
            extraWorkCalculationQuery.IsDeleted = false;
            extraWorkCalculationQuery.Tenant_RefID = securityTicket.TenantID;
            if (ORM_CMN_BPT_EMP_ExtraWorkCalculation_StructureBinding.Query.Exists(Connection, Transaction, extraWorkCalculationQuery))
                returnValue.Result = true;

            ORM_CMN_BPT_EMP_ExtraWorkCalculation_Surcharge_StructureBinding.Query surchargeQuery = new ORM_CMN_BPT_EMP_ExtraWorkCalculation_Surcharge_StructureBinding.Query();
            surchargeQuery.BoundTo_Workplace_RefID = Parameter.WorkplaceID;
            surchargeQuery.IsDeleted = false;
            surchargeQuery.Tenant_RefID = securityTicket.TenantID;
            if (ORM_CMN_BPT_EMP_ExtraWorkCalculation_Surcharge_StructureBinding.Query.Exists(Connection, Transaction, surchargeQuery))
                returnValue.Result = true;

            ORM_CMN_BPT_EMP_Employee.Query employeeQuery = new ORM_CMN_BPT_EMP_Employee.Query();
            employeeQuery.Primary_Workplace_RefID = Parameter.WorkplaceID;
            employeeQuery.IsDeleted = false;
            employeeQuery.Tenant_RefID = securityTicket.TenantID;
            if (ORM_CMN_BPT_EMP_Employee.Query.Exists(Connection, Transaction, employeeQuery))
                returnValue.Result = true;

            ORM_CMN_PPS_ShiftTemplate.Query shiftTemplateQuery = new ORM_CMN_PPS_ShiftTemplate.Query();
            shiftTemplateQuery.CMN_STR_Workplace_RefID = Parameter.WorkplaceID;
            shiftTemplateQuery.IsDeleted = false;
            shiftTemplateQuery.Tenant_RefID = securityTicket.TenantID;
            if (ORM_CMN_PPS_ShiftTemplate.Query.Exists(Connection, Transaction, shiftTemplateQuery))
                returnValue.Result = true;


            ORM_CMN_PPS_BreakTime_Defaults_StructureBinding.Query defaultBreakQuery = new ORM_CMN_PPS_BreakTime_Defaults_StructureBinding.Query();
            defaultBreakQuery.BoundTo_Workplace_RefID = Parameter.WorkplaceID;
            defaultBreakQuery.IsDeleted = false;
            defaultBreakQuery.Tenant_RefID = securityTicket.TenantID;
            if (ORM_CMN_PPS_BreakTime_Defaults_StructureBinding.Query.Exists(Connection, Transaction, defaultBreakQuery))
                returnValue.Result = true;

            ORM_CMN_PPS_BreakTime_Template.Query breakTimeTemplateQuery = new ORM_CMN_PPS_BreakTime_Template.Query();
            breakTimeTemplateQuery.BoundTo_Workplace_RefID = Parameter.WorkplaceID;
            breakTimeTemplateQuery.IsDeleted = false;
            breakTimeTemplateQuery.Tenant_RefID = securityTicket.TenantID;
            if (ORM_CMN_PPS_BreakTime_Template.Query.Exists(Connection, Transaction, breakTimeTemplateQuery))
                returnValue.Result = true;

            ORM_CMN_STR_PPS_Workplace_ResponsiblePerson.Query WorkplaceResponsiblePersonQuery = new ORM_CMN_STR_PPS_Workplace_ResponsiblePerson.Query();
            WorkplaceResponsiblePersonQuery.Workplace_RefID = Parameter.WorkplaceID;
            WorkplaceResponsiblePersonQuery.IsDeleted = false;
            WorkplaceResponsiblePersonQuery.Tenant_RefID = securityTicket.TenantID;
            if (ORM_CMN_STR_PPS_Workplace_ResponsiblePerson.Query.Exists(Connection, Transaction, WorkplaceResponsiblePersonQuery))
                returnValue.Result = true;
            
     

            ORM_CMN_BPT_EMP_EffectiveWorkTime_Position.Query WorkplaceEffectiveWorkTimePositionQuery = new ORM_CMN_BPT_EMP_EffectiveWorkTime_Position.Query();
            WorkplaceEffectiveWorkTimePositionQuery.Workplace_RefID = Parameter.WorkplaceID;
            WorkplaceEffectiveWorkTimePositionQuery.IsDeleted = false;
            WorkplaceEffectiveWorkTimePositionQuery.Tenant_RefID = securityTicket.TenantID;
            if (ORM_CMN_BPT_EMP_EffectiveWorkTime_Position.Query.Exists(Connection, Transaction, WorkplaceEffectiveWorkTimePositionQuery))
                returnValue.Result = true;

            ORM_CMN_STR_PPS_DailyWorkSchedule_Detail.Query WorkplaceDailyScheduleQuery = new ORM_CMN_STR_PPS_DailyWorkSchedule_Detail.Query();
            WorkplaceDailyScheduleQuery.SheduleForWorkplace_RefID = Parameter.WorkplaceID;
            WorkplaceDailyScheduleQuery.IsDeleted = false;
            WorkplaceDailyScheduleQuery.Tenant_RefID = securityTicket.TenantID;
            if (ORM_CMN_STR_PPS_DailyWorkSchedule_Detail.Query.Exists(Connection, Transaction, WorkplaceDailyScheduleQuery))
                returnValue.Result = true;

            ORM_CMN_STR_PPS_WorkDetail_Activity.Query WorkplaceWorkDetailActivityQuery = new ORM_CMN_STR_PPS_WorkDetail_Activity.Query();
            WorkplaceWorkDetailActivityQuery.CMN_STR_PPS_Workplace_RefID = Parameter.WorkplaceID;
            WorkplaceWorkDetailActivityQuery.IsDeleted = false;
            WorkplaceWorkDetailActivityQuery.Tenant_RefID = securityTicket.TenantID;
            if (ORM_CMN_STR_PPS_WorkDetail_Activity.Query.Exists(Connection, Transaction, WorkplaceWorkDetailActivityQuery))
                returnValue.Result = true;

  





            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_Bool Invoke(string ConnectionString, P_L5WP_IWPU_1503 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Bool Invoke(DbConnection Connection, P_L5WP_IWPU_1503 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction, P_L5WP_IWPU_1503 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_L5WP_IWPU_1503 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_Bool functionReturn = new FR_Bool();
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

                throw new Exception("Exception occured in method cls_Is_Workplace_Used", ex);
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
FR_Bool cls_Is_Workplace_Used(,P_L5WP_IWPU_1503 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Bool invocationResult = cls_Is_Workplace_Used.Invoke(connectionString,P_L5WP_IWPU_1503 Parameter,securityTicket);
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
var parameter = new CL5_VacationPlanner_WorkPlace.complex.Retrieval.P_L5WP_IWPU_1503();
parameter.WorkplaceID = ...;

*/
