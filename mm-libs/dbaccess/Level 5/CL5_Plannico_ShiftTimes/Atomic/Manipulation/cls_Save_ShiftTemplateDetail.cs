/* 
 * Generated on 11/8/2013 12:08:33 PM
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
using CL1_CMN_PPS;
using PlannicoModel.Models;
using VacationPlaner;

namespace CL5_Plannico_ShiftTimes.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_ShiftTemplateDetail.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_ShiftTemplateDetail
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5ST_SSTD_1423 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();


            var item = new ORM_CMN_PPS_ShiftTemplate_WorkDetail();
            if (Parameter.CMN_PPS_ShiftTemplate_WorkDetailID != Guid.Empty)
            {
                var result = item.Load(Connection, Transaction, Parameter.CMN_PPS_ShiftTemplate_WorkDetailID);
                if (result.Status != FR_Status.Success || item.CMN_PPS_ShiftTemplate_WorkDetailID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }
            item.CMN_PPS_ShiftTemplate_RefID = Parameter.CMN_PPS_ShiftTemplate_RefID;
            item.Duration_in_sec = Parameter.Duration_in_sec;
            item.ShiftStart_Offset_sec = Parameter.ShiftStart_Offset_sec;
            item.Tenant_RefID = securityTicket.TenantID;
            item.WorkDetail_Note_Content = Parameter.WorkDetail_Note_Content;
            item.WorkDetail_Note_Title = Parameter.WorkDetail_Note_Title;
            item.Save(Connection, Transaction);

            ORM_CMN_PPS_ShiftTemplate shiftTemplate = new ORM_CMN_PPS_ShiftTemplate();
            shiftTemplate.Load(Connection, Transaction, item.CMN_PPS_ShiftTemplate_RefID);
            shiftTemplate.Default_AllowedBreakTimeTemplate_RefID = Parameter.AllowedBreakTime_RefID;
            shiftTemplate.Save(Connection, Transaction);

                ORM_CMN_STR_PPS_WorkDetail_Activity.Query activityDetailQuery = new ORM_CMN_STR_PPS_WorkDetail_Activity.Query();
                activityDetailQuery.IsDeleted = false;
                activityDetailQuery.Tenant_RefID = securityTicket.TenantID;
                activityDetailQuery.CMN_PPS_ShiftTemplate_WorkDetail_RefID = item.CMN_PPS_ShiftTemplate_WorkDetailID;
                List<ORM_CMN_STR_PPS_WorkDetail_Activity> activityDetails = ORM_CMN_STR_PPS_WorkDetail_Activity.Query.Search(Connection, Transaction, activityDetailQuery);
                if (activityDetails != null && activityDetails.Count != 0)
                {
                    ORM_CMN_STR_PPS_WorkDetail_Activity activityDetail = activityDetails.FirstOrDefault();
                    activityDetail.CMN_STR_PPS_Workplace_RefID=Parameter.CMN_STR_PPS_Workplace_RefID;
                    
                    ORM_CMN_STR_PPS_Activity activity = new ORM_CMN_STR_PPS_Activity();
                    if (Parameter.AbsenceReason_RefID != Guid.Empty)
                    {
                        activity.Load(Connection, Transaction, activityDetail.CMN_STR_PPS_Activity_RefID);
                        if(activity.CMN_STR_PPS_ActivityID==Guid.Empty)
                            activity.CMN_STR_PPS_ActivityID=Guid.NewGuid();
                        activity.AbsenceReason_RefID = Parameter.AbsenceReason_RefID;
                        activity.IsAbsenceActivity=true;
                        activity.Tenant_RefID=securityTicket.TenantID;
                        activity.Save(Connection,Transaction);  
                        activityDetail.CMN_STR_PPS_Activity_RefID=activity.CMN_STR_PPS_ActivityID;
                    }else if(activityDetail.CMN_STR_PPS_Activity_RefID!=Guid.Empty){
                        activity.Load(Connection, Transaction, activityDetail.CMN_STR_PPS_Activity_RefID);
                        activity.Remove(Connection, Transaction);
                    }
                    activityDetail.Save(Connection, Transaction);
                }
                else
                {
                    ORM_CMN_STR_PPS_WorkDetail_Activity activityDetail = new ORM_CMN_STR_PPS_WorkDetail_Activity();
                    activityDetail.CMN_PPS_ShiftTemplate_WorkDetail_RefID = item.CMN_PPS_ShiftTemplate_WorkDetailID;
                    activityDetail.CMN_STR_PPS_Workplace_RefID=Parameter.CMN_STR_PPS_Workplace_RefID;
                    activityDetail.Tenant_RefID = securityTicket.TenantID;

                    ORM_CMN_STR_PPS_Activity activity = new ORM_CMN_STR_PPS_Activity();
                    if (Parameter.AbsenceReason_RefID != Guid.Empty)
                    {
                        activity.AbsenceReason_RefID = Parameter.AbsenceReason_RefID;
                        activity.IsAbsenceActivity=true;
                        activity.Tenant_RefID=securityTicket.TenantID;
                        activity.Save(Connection,Transaction);  
                        activityDetail.CMN_STR_PPS_WorkDetail_ActivityID=activity.CMN_STR_PPS_ActivityID;
                    }
                    activityDetail.Save(Connection, Transaction);
                }

                returnValue.Result = item.CMN_PPS_ShiftTemplate_WorkDetailID;
			//Put your code here
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5ST_SSTD_1423 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5ST_SSTD_1423 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5ST_SSTD_1423 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5ST_SSTD_1423 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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
				throw new Exception("Exception occured in method cls_Save_ShiftTemplateDetail",ex);
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
FR_Guid cls_Save_ShiftTemplateDetail(,P_L5ST_SSTD_1423 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_ShiftTemplateDetail.Invoke(connectionString,P_L5ST_SSTD_1423 Parameter,securityTicket);
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
var parameter = new CL5_Plannico_ShiftTimes.Atomic.Manipulation.P_L5ST_SSTD_1423();
parameter.CMN_PPS_ShiftTemplate_RefID = ...;
parameter.ShiftStart_Offset_sec = ...;
parameter.Duration_in_sec = ...;
parameter.AllowedBreakTime_RefID = ...;
parameter.WorkDetail_Note_Title = ...;
parameter.WorkDetail_Note_Content = ...;
parameter.AbsenceReason_RefID = ...;
parameter.Required_StaffHeadCount = ...;
parameter.CMN_PPS_ShiftTemplate_WorkDetailID = ...;
parameter.CMN_STR_PPS_Workplace_RefID = ...;

*/