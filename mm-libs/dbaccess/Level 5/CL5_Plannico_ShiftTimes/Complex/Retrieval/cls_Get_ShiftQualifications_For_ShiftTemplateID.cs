/* 
 * Generated on 16/04/2014 15:16:53
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
using VacationPlaner;

namespace CL5_Plannico_ShiftTimes.Complex.Retrieval
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Get_ShiftQualifications_For_ShiftTemplateID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Get_ShiftQualifications_For_ShiftTemplateID
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Guids Execute(DbConnection Connection, DbTransaction Transaction, P_L5ST_GSTQFST_1516 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            //Leave UserCode region to enable user code saving
            #region UserCode
            var returnValue = new FR_Guids();
            List<Guid> returnList = new List<Guid>();

            ORM_CMN_PPS_ShiftTemplate_WorkDetail.Query shiftTemplateDetailQuery = new ORM_CMN_PPS_ShiftTemplate_WorkDetail.Query();
            shiftTemplateDetailQuery.Tenant_RefID = securityTicket.TenantID;
            shiftTemplateDetailQuery.IsDeleted = false;
            shiftTemplateDetailQuery.CMN_PPS_ShiftTemplate_RefID = Parameter.ShiftTemplateID;
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
                            ORM_CMN_STR_PPS_Activity_SkillAssignment.Query SkillactivityAssignment = new ORM_CMN_STR_PPS_Activity_SkillAssignment.Query();
                            SkillactivityAssignment.CMN_STR_PPS_Activity_RefID = activity.CMN_STR_PPS_Activity_RefID;
                            SkillactivityAssignment.Tenant_RefID = securityTicket.TenantID;
                            SkillactivityAssignment.IsDeleted = false;
                            List<ORM_CMN_STR_PPS_Activity_SkillAssignment> skillAssignments = ORM_CMN_STR_PPS_Activity_SkillAssignment.Query.Search(Connection, Transaction, SkillactivityAssignment);
                            if (skillAssignments.Count != 0)
                            {
                                if(!returnList.Contains(skillAssignments[0].CMN_STR_Skill_RefID))
                                   returnList.Add(skillAssignments[0].CMN_STR_Skill_RefID);
                            }
                        }
                    }
                }
            }
            returnValue.Result = returnList.ToArray();
            //Put your code here
            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_Guids Invoke(string ConnectionString, P_L5ST_GSTQFST_1516 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Guids Invoke(DbConnection Connection, P_L5ST_GSTQFST_1516 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Guids Invoke(DbConnection Connection, DbTransaction Transaction, P_L5ST_GSTQFST_1516 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Guids Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_L5ST_GSTQFST_1516 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_Guids functionReturn = new FR_Guids();
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
                throw new Exception("Exception occured in method cls_Get_ShiftQualifications_For_ShiftTemplateID", ex);
            }
            return functionReturn;
        }
        #endregion
    }


}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guids cls_Get_ShiftQualifications_For_ShiftTemplateID(,P_L5ST_GSTQFST_1516 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guids invocationResult = cls_Get_ShiftQualifications_For_ShiftTemplateID.Invoke(connectionString,P_L5ST_GSTQFST_1516 Parameter,securityTicket);
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
var parameter = new CL5_Plannico_ShiftTimes.Complex.Retrieval.P_L5ST_GSTQFST_1516();
parameter.ShiftTemplateID = ...;

*/
