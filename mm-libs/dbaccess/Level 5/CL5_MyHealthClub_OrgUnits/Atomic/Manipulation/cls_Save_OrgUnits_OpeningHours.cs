/* 
 * Generated on 14.11.2014 12:25:19
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
using CL1_CMN_STR;
using CL1_CMN_CAL;
using CL5_MyHealthClub_BookableTimeSlot.Complex.Manipulation;

namespace CL5_MyHealthClub_OrgUnits.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_OrgUnits_OpeningHours.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_OrgUnits_OpeningHours
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5OU_SPUOH_1111 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            foreach (var item in Parameter.OpeningHours)
            {
                #region Non-working  Hours
                if (item.IsNonWorkingHours)
                {
                    var workTimeExceptionsQuery = new ORM_CMN_STR_Office_WorktimeTemplateException.Query();
                    workTimeExceptionsQuery.IsDeleted = false;
                    workTimeExceptionsQuery.Tenant_RefID = securityTicket.TenantID;
                    workTimeExceptionsQuery.Office_RefID = Parameter.OfficeID;
                    workTimeExceptionsQuery.CMN_STR_Office_WorktimeTemplateExceptionID = item.TimeID;

                    var workTimeExceptions = ORM_CMN_STR_Office_WorktimeTemplateException.Query.Search(Connection, Transaction, workTimeExceptionsQuery).SingleOrDefault();

                    #region Delete
                    if (item.IsDeleted)
                    {
                        if (workTimeExceptions != null)
                        {
                            workTimeExceptions.IsDeleted = true;
                            workTimeExceptions.Save(Connection, Transaction);
                        }
                    }
                    #endregion
                    else
                    {
                        #region Save
                        if (workTimeExceptions == null)
                        {
                            workTimeExceptions = new ORM_CMN_STR_Office_WorktimeTemplateException();
                            workTimeExceptions.CMN_STR_Office_WorktimeTemplateExceptionID = item.TimeID;
                            workTimeExceptions.CMN_CAL_Event_RefID = Guid.NewGuid();
                            workTimeExceptions.Office_RefID = Parameter.OfficeID;
                            workTimeExceptions.Description = item.Description;
                            workTimeExceptions.Tenant_RefID = securityTicket.TenantID;
                            workTimeExceptions.Creation_Timestamp = DateTime.Now;
                            workTimeExceptions.Save(Connection, Transaction);


                            var Events = new ORM_CMN_CAL_Event();
                            Events.CMN_CAL_EventID = workTimeExceptions.CMN_CAL_Event_RefID;
                            Events.IsRepetitive = item.IsRepetitive;
                            Events.IsWholeDayEvent = item.IsWholeDay;
                            Events.StartTime = item.StartDate;
                            Events.EndTime = item.EndDate;                         
                            Events.Tenant_RefID = securityTicket.TenantID;
                            Events.Creation_Timestamp = DateTime.Now;

                            if (item.IsRepetitive)
                            {
                                Events.Repetition_RefID = Guid.NewGuid();

                                var repetitions = new ORM_CMN_CAL_Repetition();
                                repetitions.CMN_CAL_RepetitionID = Events.Repetition_RefID;
                                repetitions.IsMonthly = item.IsMontly;
                                repetitions.IsWeekly = item.IsWeekly;
                                repetitions.IsDaily = item.IsDaily;
                                repetitions.IsYearly = item.IsYearly;
                                repetitions.Tenant_RefID = securityTicket.TenantID;
                                repetitions.Creation_Timestamp = DateTime.Now;
                                repetitions.Save(Connection, Transaction);

                                if (item.IsWeekly)
                                {
                                    var repetitionWeekly = new ORM_CMN_CAL_RepetitionPatterns_Weekly();
                                    repetitionWeekly.CMN_CAL_RepetitionPattern_WeeklyID = Guid.NewGuid();
                                    repetitionWeekly.Repetition_RefID = repetitions.CMN_CAL_RepetitionID;
                                    repetitionWeekly.Tenant_RefID = securityTicket.TenantID;
                                    repetitionWeekly.Creation_Timestamp = DateTime.Now;
                                    repetitionWeekly.Save(Connection, Transaction);
                                }

                                if (item.IsMontly)
                                {
                                    var repetitionMontly = new ORM_CMN_CAL_RepetitionPatterns_Monthly();
                                    repetitionMontly.CMN_CAL_RepetitionPattern_MonthlyID = Guid.NewGuid();
                                    repetitionMontly.Repetition_RefID = repetitions.CMN_CAL_RepetitionID;
                                    repetitionMontly.Tenant_RefID = securityTicket.TenantID;
                                    repetitionMontly.Creation_Timestamp = DateTime.Now;
                                    repetitionMontly.Save(Connection, Transaction);
                                }

                                if (item.IsDaily)
                                {
                                    var repetitionDaily = new ORM_CMN_CAL_RepetitionPatterns_Daily();
                                    repetitionDaily.CMN_CAL_RepetitionPattern_DailyID = Guid.NewGuid();
                                    repetitionDaily.Repetition_RefID = repetitions.CMN_CAL_RepetitionID;
                                    repetitionDaily.Tenant_RefID = securityTicket.TenantID;
                                    repetitionDaily.Creation_Timestamp = DateTime.Now;
                                    repetitionDaily.Save(Connection, Transaction);
                                }

                                if (item.IsYearly)
                                {
                                    var repetitionYearly = new ORM_CMN_CAL_RepetitionPatterns_Yearly();
                                    repetitionYearly.CMN_CAL_RepetitionPattern_YearlyID = Guid.NewGuid();
                                    repetitionYearly.Repetition_RefID = repetitions.CMN_CAL_RepetitionID;
                                    repetitionYearly.Tenant_RefID = securityTicket.TenantID;
                                    repetitionYearly.Creation_Timestamp = DateTime.Now;
                                    repetitionYearly.Save(Connection, Transaction);
                                }
                            }

                            Events.Save(Connection, Transaction);
                        }
                        #endregion
                        #region Edit
                        else
                        {
                            workTimeExceptions.Description = item.Description;
                            workTimeExceptions.Save(Connection, Transaction);

                            var EventsQuery = new ORM_CMN_CAL_Event.Query();
                            EventsQuery.CMN_CAL_EventID = workTimeExceptions.CMN_CAL_Event_RefID;
                            EventsQuery.IsDeleted = false;
                            EventsQuery.Tenant_RefID = securityTicket.TenantID;

                            var Events = ORM_CMN_CAL_Event.Query.Search(Connection, Transaction, EventsQuery).Single();
             
                            Events.IsRepetitive = item.IsRepetitive;
                            Events.IsWholeDayEvent = item.IsWholeDay;
                            Events.StartTime = item.StartDate;
                            Events.EndTime = item.EndDate;
                            #region delete old repetation if exists
                            
                            var repetitionsQuery = new ORM_CMN_CAL_Repetition.Query();
                                repetitionsQuery.IsDeleted = false;
                                repetitionsQuery.Tenant_RefID = securityTicket.TenantID;
                                repetitionsQuery.CMN_CAL_RepetitionID = Events.Repetition_RefID;

                                var repetitions = ORM_CMN_CAL_Repetition.Query.Search(Connection, Transaction, repetitionsQuery).SingleOrDefault();
                                if (repetitions != null)
                                {
                                    repetitions.IsDeleted = true;
                                    repetitions.Save(Connection, Transaction);

                                    if (repetitions.IsDaily)
                                    {
                                        var repetitionDailyQuery = new ORM_CMN_CAL_RepetitionPatterns_Daily.Query();
                                        repetitionDailyQuery.IsDeleted = false;
                                        repetitionDailyQuery.Tenant_RefID = securityTicket.TenantID;
                                        repetitionDailyQuery.Repetition_RefID = repetitions.CMN_CAL_RepetitionID;

                                        var repetitionDaily = ORM_CMN_CAL_RepetitionPatterns_Daily.Query.Search(Connection, Transaction, repetitionDailyQuery).Single();
                                        repetitionDaily.IsDeleted = true;
                                        repetitionDaily.Save(Connection, Transaction);
                                    }

                                    if (repetitions.IsWeekly)
                                    {
                                        var repetitionWeeklyQuery = new ORM_CMN_CAL_RepetitionPatterns_Weekly.Query();
                                        repetitionWeeklyQuery.IsDeleted = false;
                                        repetitionWeeklyQuery.Tenant_RefID = securityTicket.TenantID;
                                        repetitionWeeklyQuery.Repetition_RefID = repetitions.CMN_CAL_RepetitionID;

                                        var repetitionWeekly = ORM_CMN_CAL_RepetitionPatterns_Weekly.Query.Search(Connection, Transaction, repetitionWeeklyQuery).Single();
                                        repetitionWeekly.IsDeleted = true;
                                        repetitionWeekly.Save(Connection, Transaction);
                                    }

                                    if (repetitions.IsMonthly)
                                    {
                                        var repetitionMontlyQuery = new ORM_CMN_CAL_RepetitionPatterns_Monthly.Query();
                                        repetitionMontlyQuery.IsDeleted = false;
                                        repetitionMontlyQuery.Tenant_RefID = securityTicket.TenantID;
                                        repetitionMontlyQuery.Repetition_RefID = repetitions.CMN_CAL_RepetitionID;

                                        var repetitionMontly = ORM_CMN_CAL_RepetitionPatterns_Monthly.Query.Search(Connection, Transaction, repetitionMontlyQuery).Single();
                                        repetitionMontly.IsDeleted = true;
                                        repetitionMontly.Save(Connection, Transaction);
                                    }

                                    if (repetitions.IsYearly)
                                    {
                                        var repetitionYearlyQuery = new ORM_CMN_CAL_RepetitionPatterns_Yearly.Query();
                                        repetitionYearlyQuery.IsDeleted = false;
                                        repetitionYearlyQuery.Tenant_RefID = securityTicket.TenantID;
                                        repetitionYearlyQuery.Repetition_RefID = repetitions.CMN_CAL_RepetitionID;

                                        var repetitionYearly = ORM_CMN_CAL_RepetitionPatterns_Yearly.Query.Search(Connection, Transaction, repetitionYearlyQuery).Single();
                                        repetitionYearly.IsDeleted = true;
                                        repetitionYearly.Save(Connection, Transaction);
                                    }
                                }
                            #endregion
                                if (item.IsRepetitive)
                                {
                                    Events.Repetition_RefID = Guid.NewGuid();
                                    repetitions = new ORM_CMN_CAL_Repetition();
                                    repetitions.CMN_CAL_RepetitionID = Events.Repetition_RefID;
                                    repetitions.IsMonthly = item.IsMontly;
                                    repetitions.IsWeekly = item.IsWeekly;
                                    repetitions.IsDaily = item.IsDaily;
                                    repetitions.IsYearly = item.IsYearly;
                                    repetitions.Tenant_RefID = securityTicket.TenantID;
                                    repetitions.Creation_Timestamp = DateTime.Now;
                                    repetitions.Save(Connection, Transaction);

                                    if (item.IsWeekly)
                                    {
                                        var repetitionWeekly = new ORM_CMN_CAL_RepetitionPatterns_Weekly();
                                        repetitionWeekly.CMN_CAL_RepetitionPattern_WeeklyID = Guid.NewGuid();
                                        repetitionWeekly.Repetition_RefID = repetitions.CMN_CAL_RepetitionID;
                                        repetitionWeekly.Tenant_RefID = securityTicket.TenantID;
                                        repetitionWeekly.Creation_Timestamp = DateTime.Now;
                                        repetitionWeekly.Save(Connection, Transaction);
                                    }

                                    if (item.IsMontly)
                                    {
                                        var repetitionMontly = new ORM_CMN_CAL_RepetitionPatterns_Monthly();
                                        repetitionMontly.CMN_CAL_RepetitionPattern_MonthlyID = Guid.NewGuid();
                                        repetitionMontly.Repetition_RefID = repetitions.CMN_CAL_RepetitionID;
                                        repetitionMontly.Tenant_RefID = securityTicket.TenantID;
                                        repetitionMontly.Creation_Timestamp = DateTime.Now;
                                        repetitionMontly.Save(Connection, Transaction);
                                    }

                                    if (item.IsDaily)
                                    {
                                        var repetitionDaily = new ORM_CMN_CAL_RepetitionPatterns_Daily();
                                        repetitionDaily.CMN_CAL_RepetitionPattern_DailyID = Guid.NewGuid();
                                        repetitionDaily.Repetition_RefID = repetitions.CMN_CAL_RepetitionID;
                                        repetitionDaily.Tenant_RefID = securityTicket.TenantID;
                                        repetitionDaily.Creation_Timestamp = DateTime.Now;
                                        repetitionDaily.Save(Connection, Transaction);
                                    }

                                    if (item.IsYearly)
                                    {
                                        var repetitionYearly = new ORM_CMN_CAL_RepetitionPatterns_Yearly();
                                        repetitionYearly.CMN_CAL_RepetitionPattern_YearlyID = Guid.NewGuid();
                                        repetitionYearly.Repetition_RefID = repetitions.CMN_CAL_RepetitionID;
                                        repetitionYearly.Tenant_RefID = securityTicket.TenantID;
                                        repetitionYearly.Creation_Timestamp = DateTime.Now;
                                        repetitionYearly.Save(Connection, Transaction);
                                    }
                                }

                            Events.Save(Connection, Transaction);
                        }
                        #endregion
                    }
                }
                #endregion
                #region Standard Hours
                else
                {
                    var workTimeTemplateQuery = new ORM_CMN_STR_Office_Weekly_WorkTimeTemplate.Query();
                    workTimeTemplateQuery.IsDeleted = false;
                    workTimeTemplateQuery.Office_RefID = Parameter.OfficeID;
                    workTimeTemplateQuery.CMN_STR_Office_Weekly_WorkTimeTemplateID = item.TimeID;
                    workTimeTemplateQuery.Tenant_RefID = securityTicket.TenantID;

                    var workTimeTemplate = ORM_CMN_STR_Office_Weekly_WorkTimeTemplate.Query.Search(Connection, Transaction, workTimeTemplateQuery).SingleOrDefault();

                    #region Delete         
                    if (item.IsDeleted)
                    {  
                        if (workTimeTemplate != null)
                        {
                            workTimeTemplate.IsDeleted = true;
                            workTimeTemplate.Save(Connection, Transaction);
                        }
                    }
                    #endregion
                    else
                    {
                        #region Save                
                        if (workTimeTemplate == null)
                        {
                            workTimeTemplate = new ORM_CMN_STR_Office_Weekly_WorkTimeTemplate();
                            workTimeTemplate.CMN_STR_Office_Weekly_WorkTimeTemplateID = item.TimeID;
                            workTimeTemplate.Office_RefID = Parameter.OfficeID;
                            workTimeTemplate.CMN_CAL_WeeklyOfficeHours_Interval_RefID = Guid.NewGuid();
                            workTimeTemplate.Tenant_RefID = securityTicket.TenantID;
                            workTimeTemplate.Creation_Timestamp = DateTime.Now;
                            workTimeTemplate.Save(Connection, Transaction);

                            ORM_CMN_CAL_WeeklyOfficeHours_Interval WeeklyOfficeHours_Interval = new ORM_CMN_CAL_WeeklyOfficeHours_Interval();
                            WeeklyOfficeHours_Interval.CMN_CAL_WeeklyOfficeHours_IntervalID = workTimeTemplate.CMN_CAL_WeeklyOfficeHours_Interval_RefID;
                            WeeklyOfficeHours_Interval.WeeklyOfficeHours_Template_RefID = Guid.NewGuid();
                            WeeklyOfficeHours_Interval.Tenant_RefID = securityTicket.TenantID;
                            WeeklyOfficeHours_Interval.Creation_Timestamp = DateTime.Now;
                            WeeklyOfficeHours_Interval.IsMonday = item.IsMonday;
                            WeeklyOfficeHours_Interval.IsTuesday = item.IsTuesday;
                            WeeklyOfficeHours_Interval.IsWednesday = item.IsWednesday;
                            WeeklyOfficeHours_Interval.IsThursday = item.IsThursday;
                            WeeklyOfficeHours_Interval.IsFriday = item.IsFriday;
                            WeeklyOfficeHours_Interval.IsSaturday = item.IsSaturday;
                            WeeklyOfficeHours_Interval.IsSunday = item.IsSunday;
                            WeeklyOfficeHours_Interval.IsWholeDay = item.IsWholeDay;
                            WeeklyOfficeHours_Interval.TimeFrom_InMinutes = item.TimeFrom_InMinutes;
                            WeeklyOfficeHours_Interval.TimeTo_InMinutes = item.TimeTo_InMinutes;
                            WeeklyOfficeHours_Interval.Save(Connection, Transaction);

                            ORM_CMN_CAL_WeeklyOfficeHours_Template WeeklyOfficeHours_Template = new ORM_CMN_CAL_WeeklyOfficeHours_Template();
                            WeeklyOfficeHours_Template.CMN_CAL_WeeklyOfficeHours_TemplateID = WeeklyOfficeHours_Interval.WeeklyOfficeHours_Template_RefID;
                            WeeklyOfficeHours_Template.OfficeHoursTemplate_Name = item.OfficeHoursTemplate_Name;
                            WeeklyOfficeHours_Template.Creation_Timestamp = DateTime.Now;
                            WeeklyOfficeHours_Template.Tenant_RefID = securityTicket.TenantID;
                            WeeklyOfficeHours_Template.Save(Connection, Transaction);

                        }
                        else
                        #endregion
                        #region Edit                
                        {
                            var WeeklyOfficeHours_IntervalQuery = new ORM_CMN_CAL_WeeklyOfficeHours_Interval.Query();
                            WeeklyOfficeHours_IntervalQuery.IsDeleted = false;
                            WeeklyOfficeHours_IntervalQuery.Tenant_RefID = securityTicket.TenantID;
                            WeeklyOfficeHours_IntervalQuery.CMN_CAL_WeeklyOfficeHours_IntervalID = workTimeTemplate.CMN_CAL_WeeklyOfficeHours_Interval_RefID;

                            var WeeklyOfficeHours_Interval = ORM_CMN_CAL_WeeklyOfficeHours_Interval.Query.Search(Connection, Transaction, WeeklyOfficeHours_IntervalQuery).Single();

                            WeeklyOfficeHours_Interval.IsWholeDay = item.IsWholeDay;
                            WeeklyOfficeHours_Interval.TimeFrom_InMinutes = item.TimeFrom_InMinutes;
                            WeeklyOfficeHours_Interval.TimeTo_InMinutes = item.TimeTo_InMinutes;
                            WeeklyOfficeHours_Interval.Save(Connection, Transaction);

                            var WeeklyOfficeHours_TemplateQuery = new ORM_CMN_CAL_WeeklyOfficeHours_Template.Query();
                            WeeklyOfficeHours_TemplateQuery.IsDeleted = false;
                            WeeklyOfficeHours_TemplateQuery.Tenant_RefID = securityTicket.TenantID;
                            WeeklyOfficeHours_TemplateQuery.CMN_CAL_WeeklyOfficeHours_TemplateID = WeeklyOfficeHours_Interval.WeeklyOfficeHours_Template_RefID;

                            var WeeklyOfficeHours_Template = ORM_CMN_CAL_WeeklyOfficeHours_Template.Query.Search(Connection, Transaction, WeeklyOfficeHours_TemplateQuery).Single();

                            WeeklyOfficeHours_Template.OfficeHoursTemplate_Name = item.OfficeHoursTemplate_Name;
                            WeeklyOfficeHours_Template.Save(Connection, Transaction);

                        }
                        #endregion
                    }
                }
                #endregion
            }
            
            if(Parameter.UpdateSlots)
                cls_CreateUpdate_Slots_for_Practice.Invoke(Connection, Transaction, new P_L5S_SUSfP_1708() { PracticeID = Parameter.OfficeID }, securityTicket);
			
            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5OU_SPUOH_1111 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5OU_SPUOH_1111 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5OU_SPUOH_1111 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5OU_SPUOH_1111 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_OrgUnits_OpeningHours",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5OU_SPUOH_1111 for attribute P_L5OU_SPUOH_1111
		[DataContract]
		public class P_L5OU_SPUOH_1111 
		{
			[DataMember]
			public P_L5OU_SPUOH_1111_OpeningHours[] OpeningHours { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid OfficeID { get; set; } 
			[DataMember]
			public bool UpdateSlots { get; set; } 

		}
		#endregion
		#region SClass P_L5OU_SPUOH_1111_OpeningHours for attribute OpeningHours
		[DataContract]
		public class P_L5OU_SPUOH_1111_OpeningHours 
		{
			//Standard type parameters
			[DataMember]
			public Guid TimeID { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 
			[DataMember]
			public Boolean IsNonWorkingHours { get; set; } 
			[DataMember]
			public String OfficeHoursTemplate_Name { get; set; } 
			[DataMember]
			public Boolean IsWholeDay { get; set; } 
			[DataMember]
			public Boolean IsMonday { get; set; } 
			[DataMember]
			public Boolean IsTuesday { get; set; } 
			[DataMember]
			public Boolean IsWednesday { get; set; } 
			[DataMember]
			public Boolean IsThursday { get; set; } 
			[DataMember]
			public Boolean IsFriday { get; set; } 
			[DataMember]
			public Boolean IsSaturday { get; set; } 
			[DataMember]
			public Boolean IsSunday { get; set; } 
			[DataMember]
			public long TimeFrom_InMinutes { get; set; } 
			[DataMember]
			public long TimeTo_InMinutes { get; set; } 
			[DataMember]
			public Boolean IsYearly { get; set; } 
			[DataMember]
			public Boolean IsWeekly { get; set; } 
			[DataMember]
			public Boolean IsMontly { get; set; } 
			[DataMember]
			public Boolean IsDaily { get; set; } 
			[DataMember]
			public Boolean IsRepetitive { get; set; } 
			[DataMember]
			public DateTime StartDate { get; set; } 
			[DataMember]
			public DateTime EndDate { get; set; } 
			[DataMember]
			public String Description { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_OrgUnits_OpeningHours(,P_L5OU_SPUOH_1111 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_OrgUnits_OpeningHours.Invoke(connectionString,P_L5OU_SPUOH_1111 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_OrgUnits.Atomic.Manipulation.P_L5OU_SPUOH_1111();
parameter.OpeningHours = ...;

parameter.OfficeID = ...;
parameter.UpdateSlots = ...;

*/
