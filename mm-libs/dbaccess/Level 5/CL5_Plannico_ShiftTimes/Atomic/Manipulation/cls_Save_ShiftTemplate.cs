/* 
 * Generated on 4/16/2014 11:50:21 AM
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
using PlannicoModel.Models;
using CL1_CMN_STR_PPS;
using VacationPlaner;

namespace CL5_Plannico_ShiftTimes.Atomic.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Save_ShiftTemplate.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Save_ShiftTemplate
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Guid Execute(DbConnection Connection, DbTransaction Transaction, P_L5ST_SST_0854 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_Guid();

            var item = new ORM_CMN_PPS_ShiftTemplate();
            if (Parameter.CMN_PPS_ShiftTemplateID != Guid.Empty)
            {
                var result = item.Load(Connection, Transaction, Parameter.CMN_PPS_ShiftTemplateID);
                if (result.Status != FR_Status.Success || item.CMN_PPS_ShiftTemplateID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }

            item.ShiftTemplate_Name = Parameter.ShiftTemplate_Name;
            item.ShiftTemplate_ShortName = Parameter.ShiftTemplate_ShortName;
            item.CMN_STR_Office_RefID = Parameter.CMN_STR_Office_RefID;
            item.CMN_STR_Workarea_RefID = Parameter.CMN_STR_Workarea_RefID;
            item.CMN_STR_Workplace_RefID = Parameter.CMN_STR_Workplace_RefID;
            item.Default_AllowedBreakTimeTemplate_RefID = Parameter.Default_AllowedBreakTimeTemplate_RefID;
            item.DisplayColor = Parameter.DisplayColor;
            item.Tenant_RefID = securityTicket.TenantID;
            item.Save(Connection, Transaction);
            returnValue.Result = item.CMN_PPS_ShiftTemplateID;


            foreach (var skillID in Parameter.QualificationList)
            {
                ORM_CMN_STR_PPS_Activity_SkillAssignment.Query activityAssignment = new ORM_CMN_STR_PPS_Activity_SkillAssignment.Query();
                activityAssignment.CMN_STR_Skill_RefID = skillID;
                activityAssignment.Tenant_RefID = securityTicket.TenantID;
                activityAssignment.IsDeleted = false;
                List<ORM_CMN_STR_PPS_Activity_SkillAssignment> skillAssignments = ORM_CMN_STR_PPS_Activity_SkillAssignment.Query.Search(Connection, Transaction, activityAssignment);
                if (skillAssignments.Count == 0)
                {

                    ORM_CMN_STR_PPS_Activity activity = new ORM_CMN_STR_PPS_Activity();
                    activity.Activity_ShortName = "generated skill activity";
                    activity.IsSkill = true;
                    activity.Tenant_RefID = securityTicket.TenantID;
                    activity.Save(Connection, Transaction);

                    ORM_CMN_STR_PPS_Activity_SkillAssignment skillAssignemnt = new ORM_CMN_STR_PPS_Activity_SkillAssignment();
                    skillAssignemnt.CMN_STR_Skill_RefID = skillID;
                    skillAssignemnt.CMN_STR_PPS_Activity_RefID = activity.CMN_STR_PPS_ActivityID;
                    skillAssignemnt.Tenant_RefID = securityTicket.TenantID;
                    skillAssignemnt.Save(Connection, Transaction);
                }

            }

            ORM_CMN_PPS_ShiftTemplate_WorkDetail.Query shiftTemplateDetailQuery = new ORM_CMN_PPS_ShiftTemplate_WorkDetail.Query();
            shiftTemplateDetailQuery.Tenant_RefID = securityTicket.TenantID;
            shiftTemplateDetailQuery.IsDeleted = false;
            shiftTemplateDetailQuery.CMN_PPS_ShiftTemplate_RefID = item.CMN_PPS_ShiftTemplateID;
            List<ORM_CMN_PPS_ShiftTemplate_WorkDetail> shiftTemplateDetails = ORM_CMN_PPS_ShiftTemplate_WorkDetail.Query.Search(Connection, Transaction, shiftTemplateDetailQuery);
            foreach (var shiftTemplateDetail in shiftTemplateDetails)
            {
                ORM_CMN_STR_PPS_WorkDetail_Activity.Query activityQuery = new ORM_CMN_STR_PPS_WorkDetail_Activity.Query();
                activityQuery.IsDeleted = false;
                activityQuery.Tenant_RefID = securityTicket.TenantID;
                activityQuery.CMN_PPS_ShiftTemplate_WorkDetail_RefID = shiftTemplateDetail.CMN_PPS_ShiftTemplate_WorkDetailID;
                List<ORM_CMN_STR_PPS_WorkDetail_Activity> activities = ORM_CMN_STR_PPS_WorkDetail_Activity.Query.Search(Connection, Transaction, activityQuery);
                if (activities.Count != 0)
                {
                    activities = activities.Where(i => i.CMN_STR_PPS_Workplace_RefID == Guid.Empty).ToList();
                    foreach (var activity in activities)
                    {
                        ORM_CMN_STR_PPS_Activity activityItem = new ORM_CMN_STR_PPS_Activity();
                        activityItem.Load(Connection, Transaction, activity.CMN_STR_PPS_Activity_RefID);
                        if (!activityItem.IsAbsenceActivity)
                        {
                            activity.Remove(Connection, Transaction);
                        }
                    }
                }
                foreach (var skillID in Parameter.QualificationList)
                {
                    ORM_CMN_STR_PPS_Activity_SkillAssignment.Query SkillactivityAssignment = new ORM_CMN_STR_PPS_Activity_SkillAssignment.Query();
                    SkillactivityAssignment.CMN_STR_Skill_RefID = skillID;
                    SkillactivityAssignment.Tenant_RefID = securityTicket.TenantID;
                    SkillactivityAssignment.IsDeleted = false;
                    List<ORM_CMN_STR_PPS_Activity_SkillAssignment> skillAssignments = ORM_CMN_STR_PPS_Activity_SkillAssignment.Query.Search(Connection, Transaction, SkillactivityAssignment);
                    if (skillAssignments.Count != 0)
                    {
                        ORM_CMN_STR_PPS_WorkDetail_Activity activityAssignment = new ORM_CMN_STR_PPS_WorkDetail_Activity();
                        activityAssignment.CMN_PPS_ShiftTemplate_WorkDetail_RefID = shiftTemplateDetail.CMN_PPS_ShiftTemplate_WorkDetailID;
                        activityAssignment.CMN_STR_PPS_Activity_RefID = skillAssignments[0].CMN_STR_PPS_Activity_RefID;
                        activityAssignment.Tenant_RefID = securityTicket.TenantID;
                        activityAssignment.Save(Connection, Transaction);
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
        public static FR_Guid Invoke(string ConnectionString, P_L5ST_SST_0854 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, P_L5ST_SST_0854 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, P_L5ST_SST_0854 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_L5ST_SST_0854 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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
                throw new Exception("Exception occured in method cls_Save_ShiftTemplate", ex);
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
FR_Guid cls_Save_ShiftTemplate(P_L5ST_SST_0854 Parameter,string sessionToken = null)
{
	 var securityTicket = ...;
	 FR_Guid result = cls_Save_ShiftTemplate.Invoke(connectionString,P_L5ST_SST_0854 Parameter,securityTicket);
	 return result;
}
*/