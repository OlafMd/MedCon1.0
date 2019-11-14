/* 
 * Generated on 5/27/2014 3:07:49 PM
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
using CL3_Events.Atomic.Retrieval;
using VacationPlannerCore.CustomClasses;
using CL6_VacationPlanner_Tenant.Atomic.Retrieval;
using CL5_VacationPlanner_Tenant.Atomic.Retrieval;
using CL5_VacationPlanner_Company.Complex.Retrieval;
using PlannicoModel.Models;

namespace CLE_L5_PlannicoMobile_Events.Complex.Retrieval
{
	/// <summary>
    /// No description found in <meta/> tag
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Events_for_Timespan_Data.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Events_for_Timespan_Data
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5LR_EV_TSD_1047_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5LR_EV_TSD_1047 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_L5LR_EV_TSD_1047_Array();
            #region  get events
            var allevents = cls_Get_StructureEvents_For_Tenant.Invoke(Connection, Transaction, securityTicket).Result;
            var sessionSettings = cls_Get_Settings_For_Tenant.Invoke(Connection, Transaction, securityTicket).Result;
            var tennantInformation = cls_get_Tenant_Informations.Invoke(Connection, Transaction, securityTicket).Result;
            //get full structure for plannico mobile
            #region organize data part
            L5CM_GCSFT_1157 company = cls_Get_Company_Structure_For_Tenant.Invoke(Connection, Transaction, securityTicket).Result;
            List<L3EV_GSEFT_1647> allEventsForWorkOrganisation = new List<L3EV_GSEFT_1647>();
            
            foreach (var office in company.Offices)
            {
                foreach (var ev in allevents)
                {
                    if (office.CMN_CAL_CalendarInstance_RefID == ev.CalendarInstance_RefID)
                    {
                        allEventsForWorkOrganisation.Add(ev);
                    }
                }
            }

            foreach (var workArea in company.WorkAreas)
            {
                foreach (var ev in allevents)
                {
                    if (workArea.CMN_CAL_CalendarInstance_RefID == ev.CalendarInstance_RefID)
                    {
                        allEventsForWorkOrganisation.Add(ev);
                    }
                }
            }

            foreach (var workPlace in company.WorkPlaces)
            {
                foreach (var ev in allevents)
                {
                    if (workPlace.CMN_CAL_CalendarInstance_RefID == ev.CalendarInstance_RefID)
                    {
                        allEventsForWorkOrganisation.Add(ev);
                    }
                }
            }
            foreach (var ev in allevents)
            {
                
                if (ev.CalendarInstance_RefID == tennantInformation.CMN_CAL_CalendarInstance_RefID)
                {
                    allEventsForWorkOrganisation.Add(ev);
                }
            }
            
            returnValue.Result = allEventsForWorkOrganisation.mapDBEventsToObjects(Parameter.StartDate, Parameter.EndDate).ToArray();
            #endregion
            #endregion
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5LR_EV_TSD_1047_Array Invoke(string ConnectionString,P_L5LR_EV_TSD_1047 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5LR_EV_TSD_1047_Array Invoke(DbConnection Connection,P_L5LR_EV_TSD_1047 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5LR_EV_TSD_1047_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5LR_EV_TSD_1047 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5LR_EV_TSD_1047_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5LR_EV_TSD_1047 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5LR_EV_TSD_1047_Array functionReturn = new FR_L5LR_EV_TSD_1047_Array();
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

				throw new Exception("Exception occured in method cls_Get_Events_for_Timespan_Data",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5LR_EV_TSD_1047_Array : FR_Base
	{
		public L5LR_EV_TSD_1047[] Result	{ get; set; } 
		public FR_L5LR_EV_TSD_1047_Array() : base() {}

		public FR_L5LR_EV_TSD_1047_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5LR_EV_TSD_1047 for attribute P_L5LR_EV_TSD_1047
		[DataContract]
		public class P_L5LR_EV_TSD_1047 
		{
			//Standard type parameters
			[DataMember]
			public DateTime StartDate { get; set; } 
			[DataMember]
			public DateTime EndDate { get; set; } 

		}
		#endregion
		#region SClass L5LR_EV_TSD_1047 for attribute L5LR_EV_TSD_1047
		[DataContract]
		public class L5LR_EV_TSD_1047 
		{
			//Standard type parameters
			[DataMember]
			public Guid repetitionRangesCMN_CAL_Repetition_RangeID { get; set; } 
			[DataMember]
			public Guid CalendarInstance_RefID { get; set; } 
			[DataMember]
			public Dict StructureEvent_Name { get; set; } 
			[DataMember]
			public Guid CMN_CAL_EventID { get; set; } 
			[DataMember]
			public String InternalEventTypeID { get; set; } 
			[DataMember]
			public String R_CronExpression { get; set; } 
			[DataMember]
			public DateTime EndTime { get; set; } 
			[DataMember]
			public DateTime StartTime { get; set; } 
			[DataMember]
			public bool IsRepetitive { get; set; } 
			[DataMember]
			public bool EventType_IsHalfWorkingDay { get; set; } 
			[DataMember]
			public bool EventType_IsNonWorkingDay { get; set; } 
			[DataMember]
			public bool EventType_IsShowingNotification { get; set; } 
			[DataMember]
			public double EventType_ColorCode_Alpha { get; set; } 
			[DataMember]
			public string EventType_ColorCode_Background { get; set; } 
			[DataMember]
			public string EventType_ColorCode_Foreground { get; set; } 
			[DataMember]
			public int EventType_PriorityOrdinal { get; set; } 
			[DataMember]
			public bool IsDaily { get; set; } 
			[DataMember]
			public int dailyRepetition_EveryNumberOfDays { get; set; } 
			[DataMember]
			public bool IsWeekly { get; set; } 
			[DataMember]
			public int weeklyRepetition_EveryNumberOfWeeks { get; set; } 
			[DataMember]
			public bool weeklyHasRepeatingOn_Mondays { get; set; } 
			[DataMember]
			public bool weeklyHasRepeatingOn_Tuesdays { get; set; } 
			[DataMember]
			public bool weeklyHasRepeatingOn_Wednesdays { get; set; } 
			[DataMember]
			public bool weeklyHasRepeatingOn_Thursdays { get; set; } 
			[DataMember]
			public bool weeklyHasRepeatingOn_Fridays { get; set; } 
			[DataMember]
			public bool weeklyHasRepeatingOn_Saturdays { get; set; } 
			[DataMember]
			public bool weeklyHasRepeatingOn_Sundays { get; set; } 
			[DataMember]
			public bool IsMonthly { get; set; } 
			[DataMember]
			public bool monthlyIsFixed { get; set; } 
			[DataMember]
			public int monthlyIfFixed_DayOfMonth { get; set; } 
			[DataMember]
			public int monthlyRepetition_EveryNumberOfMonths { get; set; } 
			[DataMember]
			public int relativeOrdinal { get; set; } 
			[DataMember]
			public bool relativeIsFriday { get; set; } 
			[DataMember]
			public bool relativeIsMonday { get; set; } 
			[DataMember]
			public bool relativeIsSaturday { get; set; } 
			[DataMember]
			public bool relativeIsSunday { get; set; } 
			[DataMember]
			public bool relativeIsThursday { get; set; } 
			[DataMember]
			public bool relativeIsTuesday { get; set; } 
			[DataMember]
			public bool relativeIsWednesday { get; set; } 
			[DataMember]
			public bool relativeIsWeekDay { get; set; } 
			[DataMember]
			public bool relativeIsWeekendDay { get; set; } 
			[DataMember]
			public bool IsYearly { get; set; } 
			[DataMember]
			public bool yearlyIsFixed { get; set; } 
			[DataMember]
			public int yearlyIfFixed_DayOfMonth { get; set; } 
			[DataMember]
			public int yearlyRepetition_Month { get; set; } 
			[DataMember]
			public int yearlyRelativeOrdinal { get; set; } 
			[DataMember]
			public bool yearlyRelativeIsFriday { get; set; } 
			[DataMember]
			public bool yearlyRelativeIsMonday { get; set; } 
			[DataMember]
			public bool yearlyRelativeIsSaturday { get; set; } 
			[DataMember]
			public bool yearlyRelativeIsSunday { get; set; } 
			[DataMember]
			public bool yearlyRelativeIsThursday { get; set; } 
			[DataMember]
			public bool yearlyRelativeIsTuesday { get; set; } 
			[DataMember]
			public bool yearlyRelativeIsWednesday { get; set; } 
			[DataMember]
			public bool yearlyRelativeIsWeekDay { get; set; } 
			[DataMember]
			public bool yearlyRelativeIsWeekendDay { get; set; } 
			[DataMember]
			public DateTimeRange[] repetitions { get; set; } 
			[DataMember]
			public L3EV_GSEFT_1647_forbidenLeaveTypes[] forbiddenLeaveTypes { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5LR_EV_TSD_1047_Array cls_Get_Events_for_Timespan_Data(,P_L5LR_EV_TSD_1047 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5LR_EV_TSD_1047_Array invocationResult = cls_Get_Events_for_Timespan_Data.Invoke(connectionString,P_L5LR_EV_TSD_1047 Parameter,securityTicket);
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
var parameter = new CLE_L5_PlannicoMobile_Events.Complex.Retrieval.P_L5LR_EV_TSD_1047();
parameter.StartDate = ...;
parameter.EndDate = ...;

*/
