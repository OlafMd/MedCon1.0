/* 
 * Generated on 11/8/2013 4:44:09 PM
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
using VacationPlannerCore.Utils;
using VacationPlaner;

namespace CL5_Plannico_ShiftTimes.Complex.Retrieval
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Get_ShiftTemplates_For_ShiftTemplateID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Get_ShiftTemplates_For_ShiftTemplateID
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_L5ST_GSTFSTI_1641 Execute(DbConnection Connection, DbTransaction Transaction, P_L5ST_GSTFSTI_1641 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_L5ST_GSTFSTI_1641();
            returnValue.Result = new L5ST_GSTFSTI_1641();
            

            ORM_CMN_PPS_ShiftTemplate.Query shiftTemplateQuery = new ORM_CMN_PPS_ShiftTemplate.Query();
            shiftTemplateQuery.Tenant_RefID = securityTicket.TenantID;
            shiftTemplateQuery.IsDeleted = false;
            shiftTemplateQuery.CMN_PPS_ShiftTemplateID = Parameter.ShiftTemplateID;
            List<ORM_CMN_PPS_ShiftTemplate> shiftTemplates = ORM_CMN_PPS_ShiftTemplate.Query.Search(Connection, Transaction, shiftTemplateQuery);


            ORM_CMN_PPS_ShiftTemplate shiftTemplate = shiftTemplates[0];
            L5ST_GSTFT_1610 templateItem = new L5ST_GSTFT_1610();
            templateItem.CMN_PPS_ShiftTemplateID = shiftTemplate.CMN_PPS_ShiftTemplateID;
            templateItem.CMN_STR_Office_RefID = shiftTemplate.CMN_STR_Office_RefID;
            templateItem.CMN_STR_Workarea_RefID = shiftTemplate.CMN_STR_Workarea_RefID;
            templateItem.CMN_STR_Workplace_RefID = shiftTemplate.CMN_STR_Workplace_RefID;
            templateItem.ShiftTemplate_Name = shiftTemplate.ShiftTemplate_Name;
            templateItem.ShiftTemplate_ShortName = shiftTemplate.ShiftTemplate_ShortName;

            ORM_CMN_PPS_ShiftTemplate_WorkDetail.Query workdetailsQuery = new ORM_CMN_PPS_ShiftTemplate_WorkDetail.Query();
            workdetailsQuery.IsDeleted = false;
            workdetailsQuery.Tenant_RefID = securityTicket.TenantID;
            workdetailsQuery.CMN_PPS_ShiftTemplate_RefID = shiftTemplate.CMN_PPS_ShiftTemplateID;
            List<ORM_CMN_PPS_ShiftTemplate_WorkDetail> workDetails = ORM_CMN_PPS_ShiftTemplate_WorkDetail.Query.Search(Connection, Transaction, workdetailsQuery);
            if (workDetails != null && workDetails.Count != 0)
            {
                int startingTime = 0;
                int endingTime = 0;
                int brakeTime = 0;
                double totalWorkTime = 0;
                foreach (var workDetail in workDetails)
                {
                    if (startingTime == 0 || startingTime > workDetail.ShiftStart_Offset_sec)
                    {
                        startingTime = (int)workDetail.ShiftStart_Offset_sec;
                    }
                    if (endingTime < workDetail.ShiftStart_Offset_sec + workDetail.Duration_in_sec)
                    {
                        endingTime = (int)workDetail.ShiftStart_Offset_sec + (int)workDetail.Duration_in_sec;
                    }

                    totalWorkTime += workDetail.Duration_in_sec;
                }
                templateItem.BrakeTime = CronExtender.secondsToTime(brakeTime);
                templateItem.EndTime = CronExtender.secondsToTime(endingTime);
                templateItem.StartTime = CronExtender.secondsToTime(startingTime);
                templateItem.Worktime = CronExtender.secondsToTime(Int32.Parse(totalWorkTime.ToString()));
            }
  



            returnValue.Result.ShiftTemplate = templateItem;


            //Put your code here
            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_L5ST_GSTFSTI_1641 Invoke(string ConnectionString, P_L5ST_GSTFSTI_1641 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_L5ST_GSTFSTI_1641 Invoke(DbConnection Connection, P_L5ST_GSTFSTI_1641 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_L5ST_GSTFSTI_1641 Invoke(DbConnection Connection, DbTransaction Transaction, P_L5ST_GSTFSTI_1641 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_L5ST_GSTFSTI_1641 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_L5ST_GSTFSTI_1641 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_L5ST_GSTFSTI_1641 functionReturn = new FR_L5ST_GSTFSTI_1641();
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
                throw new Exception("Exception occured in method cls_Get_ShiftTemplates_For_ShiftTemplateID", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Custom Return Type
    [Serializable]
    public class FR_L5ST_GSTFSTI_1641 : FR_Base
    {
        public L5ST_GSTFSTI_1641 Result { get; set; }

        public FR_L5ST_GSTFSTI_1641() : base() { }

        public FR_L5ST_GSTFSTI_1641(Exception ex) : base(ex) { }

    }
    #endregion

    #region Support Classes


    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5ST_GSTFSTI_1641 cls_Get_ShiftTemplates_For_ShiftTemplateID(,P_L5ST_GSTFSTI_1641 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5ST_GSTFSTI_1641 invocationResult = cls_Get_ShiftTemplates_For_ShiftTemplateID.Invoke(connectionString,P_L5ST_GSTFSTI_1641 Parameter,securityTicket);
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
var parameter = new CL5_Plannico_ShiftTimes.Complex.Retrieval.P_L5ST_GSTFSTI_1641();
parameter.ShiftTemplateID = ...;

*/