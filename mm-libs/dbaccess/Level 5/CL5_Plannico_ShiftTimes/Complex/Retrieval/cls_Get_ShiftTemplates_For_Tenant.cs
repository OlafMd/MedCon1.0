/* 
 * Generated on 4/16/2014 11:12:03 AM
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
using VacationPlannerCore.Utils;
using PlannicoModel.Models;
using CL5_Plannico_Breaks.Complex.Retrieval;
using VacationPlaner;

namespace CL5_Plannico_ShiftTimes.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ShiftTemplates_For_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ShiftTemplates_For_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5ST_GSTFT_1610_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_L5ST_GSTFT_1610_Array();

            List<L5ST_GSTFT_1610> shiftTemplatesReturn = new List<L5ST_GSTFT_1610>();

            ORM_CMN_PPS_ShiftTemplate.Query shiftTemplateQuery=new ORM_CMN_PPS_ShiftTemplate.Query();
            shiftTemplateQuery.Tenant_RefID = securityTicket.TenantID;
            shiftTemplateQuery.IsDeleted = false;
            List<ORM_CMN_PPS_ShiftTemplate> shiftTemplates = ORM_CMN_PPS_ShiftTemplate.Query.Search(Connection, Transaction, shiftTemplateQuery);
            foreach (var shiftTemplate in shiftTemplates)
            {
                L5ST_GSTFT_1610 templateItem = new L5ST_GSTFT_1610();
                templateItem.CMN_PPS_ShiftTemplateID = shiftTemplate.CMN_PPS_ShiftTemplateID;
                templateItem.CMN_STR_Office_RefID = shiftTemplate.CMN_STR_Office_RefID;
                templateItem.CMN_STR_Workarea_RefID = shiftTemplate.CMN_STR_Workarea_RefID;
                templateItem.CMN_STR_Workplace_RefID = shiftTemplate.CMN_STR_Workplace_RefID;
                templateItem.ShiftTemplate_Name = shiftTemplate.ShiftTemplate_Name;
                templateItem.ShiftTemplate_ShortName = shiftTemplate.ShiftTemplate_ShortName;
                templateItem.Default_AllowedBreakTimeTemplate_RefID = shiftTemplate.Default_AllowedBreakTimeTemplate_RefID;
                templateItem.DisplayColor = shiftTemplate.DisplayColor;

                ORM_CMN_PPS_ShiftTemplate_WorkDetail.Query workdetailsQuery = new ORM_CMN_PPS_ShiftTemplate_WorkDetail.Query();
                workdetailsQuery.IsDeleted = false;
                workdetailsQuery.Tenant_RefID = securityTicket.TenantID;
                workdetailsQuery.CMN_PPS_ShiftTemplate_RefID = shiftTemplate.CMN_PPS_ShiftTemplateID;
                List<ORM_CMN_PPS_ShiftTemplate_WorkDetail> workDetails = ORM_CMN_PPS_ShiftTemplate_WorkDetail.Query.Search(Connection, Transaction, workdetailsQuery);
                if (workDetails != null && workDetails.Count != 0)
                {
                    int startingTime = 0;
                    int endingTime = 0;
                    double totalWorkTime = 0;
                    foreach (var workDetail in workDetails)
                    {
                        if (startingTime == 0 || (startingTime > workDetail.ShiftStart_Offset_sec && workDetail.ShiftStart_Offset_sec != 0))
                        {
                            startingTime = (int)workDetail.ShiftStart_Offset_sec;
                        }
                        if (endingTime < workDetail.ShiftStart_Offset_sec + workDetail.Duration_in_sec)
                        {
                            endingTime = (int)workDetail.ShiftStart_Offset_sec + (int)workDetail.Duration_in_sec;
                        }

                        totalWorkTime += workDetail.Duration_in_sec;
                    }

                    templateItem.EndTime = CronExtender.secondsToTime(endingTime);
                    templateItem.StartTime = CronExtender.secondsToTime(startingTime);
                    templateItem.Worktime = CronExtender.secondsToTime(Int32.Parse(totalWorkTime.ToString()));
                }
                else
                {

                    templateItem.EndTime = CronExtender.secondsToTime(0);
                    templateItem.StartTime = CronExtender.secondsToTime(0);
                    templateItem.Worktime = CronExtender.secondsToTime(0);
                }
                int brakeTime = 0;
                if (shiftTemplate.Default_AllowedBreakTimeTemplate_RefID != Guid.Empty)
                {
                    P_L5BR_GBMFTID_1537 par = new P_L5BR_GBMFTID_1537();
                    par.CMN_PPS_BreakTime_TemplateID = shiftTemplate.Default_AllowedBreakTimeTemplate_RefID;
                    L5BR_GBMFTID_1537 breakModel = cls_Get_BreakModels_For_TemplateID.Invoke(Connection, Transaction, par, securityTicket).Result;
                    brakeTime = breakModel.BreakModel.Duration;
                    templateItem.BrakeTime = CronExtender.secondsToTime(brakeTime);
                    templateItem.Worktime = CronExtender.secondsToTime(CronExtender.timeToSeconds(templateItem.Worktime) - brakeTime);
                }
                else
                {

                    templateItem.BrakeTime = CronExtender.secondsToTime(0);
                }
                P_L5ST_GSTQFST_1516 param=new P_L5ST_GSTQFST_1516();
                param.ShiftTemplateID=shiftTemplate.CMN_PPS_ShiftTemplateID;
                templateItem.Qualifications=cls_Get_ShiftQualifications_For_ShiftTemplateID.Invoke(Connection, Transaction, param, securityTicket).Result;

                shiftTemplatesReturn.Add(templateItem);
                
            }

            returnValue.Result = shiftTemplatesReturn.ToArray();

     

			//Put your code here
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5ST_GSTFT_1610_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5ST_GSTFT_1610_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5ST_GSTFT_1610_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5ST_GSTFT_1610_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5ST_GSTFT_1610_Array functionReturn = new FR_L5ST_GSTFT_1610_Array();
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

				functionReturn = Execute(Connection, Transaction,securityTicket);


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
	public class FR_L5ST_GSTFT_1610_Array : FR_Base
	{
		public L5ST_GSTFT_1610[] Result	{ get; set; } 
		public FR_L5ST_GSTFT_1610_Array() : base() {}

		public FR_L5ST_GSTFT_1610_Array(Exception ex): base(ex) {}

	}
	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5ST_GSTFT_1610_Array cls_Get_ShiftTemplates_For_Tenant(string sessionToken = null)
{
	 var securityTicket = ...;
	 FR_L5ST_GSTFT_1610_Array result = cls_Get_ShiftTemplates_For_Tenant.Invoke(connectionString,securityTicket);
	 return result;
}
*/