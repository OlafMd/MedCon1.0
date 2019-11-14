/* 
 * Generated on 29/04/2014 11:00:07
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
using VacationPlannerCore.CustomClasses;
using VacationPlaner;

namespace CL5_Plannico_DailyWorkSchedules.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Check_For_DailyWorkSchedules_For_Period.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Check_For_DailyWorkSchedules_For_Period
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5DWS_CDWSFP_1053 Execute(DbConnection Connection,DbTransaction Transaction,P_L5DWS_CDWSFP_1053 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_L5DWS_CDWSFP_1053();

            L5DWS_CDWSFP_1053 returnVal = new L5DWS_CDWSFP_1053();

            
            DateTime currentDate=Parameter.StartDate.Date;
            while (currentDate <= Parameter.EndDate.Date)
            {
                ORM_CMN_STR_PPS_DailyWorkSchedule.Query scheduleQuery = new ORM_CMN_STR_PPS_DailyWorkSchedule.Query();
                scheduleQuery.Tenant_RefID = securityTicket.TenantID;
                scheduleQuery.IsDeleted = false;
                scheduleQuery.WorkSheduleDate = currentDate;
                scheduleQuery.Employee_RefID = Parameter.EmployeeID;
                List<ORM_CMN_STR_PPS_DailyWorkSchedule> workSechedules = ORM_CMN_STR_PPS_DailyWorkSchedule.Query.Search(Connection, Transaction, scheduleQuery);
                if (Parameter.StartDate.Date == Parameter.EndDate.Date&&workSechedules.Count != 0)
                {
                    DateTimeRange requestRange = new DateTimeRange();
                    requestRange.Start = Parameter.StartDate;
                    requestRange.End = Parameter.EndDate;
                    P_L5DWS_GDWSDFDWSID_1156 par=new P_L5DWS_GDWSDFDWSID_1156();
                    par.DailyWorkScheduleID=workSechedules[0].CMN_STR_PPS_DailyWorkScheduleID;
                    var details = cls_Get_DailyWorkSchedule_Detail_For_DailyWorkScheduleID.Invoke(Connection, Transaction, par, securityTicket).Result;     
                    foreach (var detail in details)
                    {
                        DateTimeRange dateRange = new DateTimeRange();
                        dateRange.Start = detail.FromTime_as_DateTime;
                        dateRange.End = detail.ToTime_as_DateTime;
                        if (requestRange.Intersects(dateRange))
                        {
                            returnVal.hasPlaning = true;
                        }
                    }
                }
                else if (currentDate == Parameter.StartDate.Date && workSechedules.Count != 0)
                {
                    DateTimeRange requestRange = new DateTimeRange();
                    requestRange.Start = Parameter.StartDate;
                    requestRange.End = new DateTime(Parameter.StartDate.Year,Parameter.StartDate.Month,Parameter.StartDate.Day,23,59,59);
                    P_L5DWS_GDWSDFDWSID_1156 par = new P_L5DWS_GDWSDFDWSID_1156();
                    par.DailyWorkScheduleID = workSechedules[0].CMN_STR_PPS_DailyWorkScheduleID;
                    var details = cls_Get_DailyWorkSchedule_Detail_For_DailyWorkScheduleID.Invoke(Connection, Transaction, par, securityTicket).Result;
                    foreach (var detail in details)
                    {
                        DateTimeRange dateRange = new DateTimeRange();
                        dateRange.Start = detail.FromTime_as_DateTime;
                        dateRange.End = detail.ToTime_as_DateTime;
                        if (requestRange.Intersects(dateRange))
                        {
                            returnVal.hasPlaning = true;
                        }
                    }
                }
                else if(currentDate ==Parameter.EndDate.Date&& workSechedules.Count != 0)
                {
                    DateTimeRange requestRange = new DateTimeRange();
                    requestRange.Start = new DateTime(Parameter.EndDate.Year, Parameter.EndDate.Month, Parameter.EndDate.Day, 0, 0, 0);
                    requestRange.End = Parameter.EndDate;
                    P_L5DWS_GDWSDFDWSID_1156 par = new P_L5DWS_GDWSDFDWSID_1156();
                    par.DailyWorkScheduleID = workSechedules[0].CMN_STR_PPS_DailyWorkScheduleID;
                    var details = cls_Get_DailyWorkSchedule_Detail_For_DailyWorkScheduleID.Invoke(Connection, Transaction, par, securityTicket).Result;
                    foreach (var detail in details)
                    {
                        DateTimeRange dateRange = new DateTimeRange();
                        dateRange.Start = detail.FromTime_as_DateTime;
                        dateRange.End = detail.ToTime_as_DateTime;
                        if (requestRange.Intersects(dateRange))
                        {
                            returnVal.hasPlaning = true;
                        }
                    }
                }
                else 
                {
                    if (workSechedules.Count != 0)
                    {
                        returnVal.hasPlaning = true;
                    }

                }
             //   ORM_CMN_STR_PPS_EffectiveWorkTime.Query effectiveWorkTimeQuery = new ORM_CMN_STR_PPS_EffectiveWorkTime.Query();
             //   effectiveWorkTimeQuery.IsDeleted = false;
             //   effectiveWorkTimeQuery.Tenant_RefID = securityTicket.TenantID;
             //   var actuals = ORM_CMN_STR_PPS_EffectiveWorkTime.Query.Search(Connection, Transaction, effectiveWorkTimeQuery).Where(x => x.WorkTime_StartTime.Date == currentDate).ToArray();

             //   if (Parameter.StartDate.Date == Parameter.EndDate.Date && workSechedules.Count != 0)
             //   {
             //       DateTimeRange requestRange = new DateTimeRange();
             //       requestRange.Start = Parameter.StartDate;
             //       requestRange.End = Parameter.EndDate;
             //       foreach (var actual in actuals)
             //       {
             //           DateTimeRange dateRange = new DateTimeRange();
             //           dateRange.Start = actual.WorkTime_StartTime;
             //           dateRange.End = actual.WorkTime_StartTime.AddSeconds(actual.WorkTime_Duration_in_sec);
             //           if (requestRange.Intersects(dateRange))
             //           {
             //               returnVal.hasActuals = true;
             //           }
             //       }
             //   }
             //   else if (currentDate == Parameter.StartDate.Date && workSechedules.Count != 0)
             //   {
             //       DateTimeRange requestRange = new DateTimeRange();
             //       requestRange.Start = Parameter.StartDate;
             //       requestRange.End = new DateTime(Parameter.StartDate.Year, Parameter.StartDate.Month, Parameter.StartDate.Day, 23, 59, 59);
             //       foreach (var actual in actuals)
             //       {
             //           DateTimeRange dateRange = new DateTimeRange();
             //           dateRange.Start = actual.WorkTime_StartTime;
             //           dateRange.End = actual.WorkTime_StartTime.AddSeconds(actual.WorkTime_Duration_in_sec);
             //           if (requestRange.Intersects(dateRange))
             //           {
             //               returnVal.hasActuals = true;
             //           }
             //       }
             //   }
             //   else if (currentDate == Parameter.EndDate.Date && workSechedules.Count != 0)
             //   {
             //       DateTimeRange requestRange = new DateTimeRange();
             //       requestRange.Start = new DateTime(Parameter.EndDate.Year, Parameter.EndDate.Month, Parameter.EndDate.Day, 0, 0, 0);
             //       requestRange.End = Parameter.EndDate;
             //       foreach (var actual in actuals)
             //       {
             //           DateTimeRange dateRange = new DateTimeRange();
             //           dateRange.Start = actual.WorkTime_StartTime;
             //           dateRange.End = actual.WorkTime_StartTime.AddSeconds(actual.WorkTime_Duration_in_sec);
             //           if (requestRange.Intersects(dateRange))
             //           {
             //               returnVal.hasActuals = true;
             //           }
             //       }
             //   }
             //   else
             //   {
             //       if (workSechedules.Count != 0)
             //       {
             //           returnVal.hasActuals = true;
             //       }

             //   }
             //  
                currentDate = currentDate.AddDays(1);
             }
            returnValue.Result = returnVal;
			//Put your code here
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5DWS_CDWSFP_1053 Invoke(string ConnectionString,P_L5DWS_CDWSFP_1053 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5DWS_CDWSFP_1053 Invoke(DbConnection Connection,P_L5DWS_CDWSFP_1053 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5DWS_CDWSFP_1053 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5DWS_CDWSFP_1053 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5DWS_CDWSFP_1053 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5DWS_CDWSFP_1053 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5DWS_CDWSFP_1053 functionReturn = new FR_L5DWS_CDWSFP_1053();
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
				throw new Exception("Exception occured in method cls_Check_For_DailyWorkSchedules_For_Period",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5DWS_CDWSFP_1053 : FR_Base
	{
		public L5DWS_CDWSFP_1053 Result	{ get; set; }

		public FR_L5DWS_CDWSFP_1053() : base() {}

		public FR_L5DWS_CDWSFP_1053(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes


	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5DWS_CDWSFP_1053 cls_Check_For_DailyWorkSchedules_For_Period(,P_L5DWS_CDWSFP_1053 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5DWS_CDWSFP_1053 invocationResult = cls_Check_For_DailyWorkSchedules_For_Period.Invoke(connectionString,P_L5DWS_CDWSFP_1053 Parameter,securityTicket);
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
var parameter = new CL5_Plannico_DailyWorkSchedules.Complex.Retrieval.P_L5DWS_CDWSFP_1053();
parameter.StartDate = ...;
parameter.EndDate = ...;
parameter.EmployeeID = ...;

*/
