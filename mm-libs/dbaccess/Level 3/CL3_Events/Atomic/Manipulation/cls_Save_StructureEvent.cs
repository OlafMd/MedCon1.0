/* 
 * Generated on 3/26/2014 2:34:21 PM
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
using CL1_CMN_STR_SCE;
using CL1_CMN_CAL;
using CL1_CMN;

namespace CL3_Events.Atomic.Manipulation
{
	/// <summary>
    /// No description found in <meta/> tag
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_StructureEvent.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_StructureEvent
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L3EV_SSE_1048 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_Guid();
            //Put your code here


   
            if (Parameter.CalendarInstanceID == Guid.Empty)
            {
                ORM_CMN_Tenant tenant = new ORM_CMN_Tenant();
                if (securityTicket.TenantID != Guid.Empty)
                {
                    var result = tenant.Load(Connection, Transaction, securityTicket.TenantID);
                    if (result.Status != FR_Status.Success || tenant.CMN_TenantID == Guid.Empty)
                    {
                        var error = new FR_Guid();
                        error.ErrorMessage = "No Such ID";
                        error.Status = FR_Status.Error_Internal;
                        return error;
                    }
                }
                if (tenant.CMN_CAL_CalendarInstance_RefID == Guid.Empty)
                {
                    ORM_CMN_CAL_CalendarInstance instance = new ORM_CMN_CAL_CalendarInstance();
                    instance.WeekStartsOnDay = 1;
                    instance.Save(Connection, Transaction);
                    tenant.CMN_CAL_CalendarInstance_RefID = instance.CMN_CAL_CalendarInstanceID;
                    tenant.Save(Connection, Transaction);
                }
            }

            ORM_CMN_CAL_Event calendarEvent = new ORM_CMN_CAL_Event();
            if (Parameter.CMN_CAL_EventID != Guid.Empty)
            {
                var result = calendarEvent.Load(Connection, Transaction, Parameter.CMN_CAL_EventID);
                if (result.Status != FR_Status.Success || calendarEvent.CMN_CAL_EventID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }
            calendarEvent.CalendarInstance_RefID = Parameter.CalendarInstanceID;
            calendarEvent.EndTime = Parameter.EndTime;
            calendarEvent.IsRepetitive = Parameter.IsRepetitive;
            calendarEvent.R_EventDuration_sec = Parameter.R_EventDuration_sec;

            calendarEvent.StartTime = Parameter.StartTime;
            calendarEvent.Tenant_RefID = securityTicket.TenantID;
            calendarEvent.CalendarInstance_RefID = Parameter.CalendarInstanceID;

            if (Parameter.IsRepetitive)
            {
                ORM_CMN_CAL_Repetition repetition = new ORM_CMN_CAL_Repetition();
                if (Parameter.CMN_CAL_RepetitionID != Guid.Empty)
                {
                    var result = repetition.Load(Connection, Transaction, Parameter.CMN_CAL_RepetitionID);
                    if (result.Status != FR_Status.Success || repetition.CMN_CAL_RepetitionID == Guid.Empty)
                    {
                        var error = new FR_Guid();
                        error.ErrorMessage = "No Such ID";
                        error.Status = FR_Status.Error_Internal;
                        return error;
                    }
                }
                repetition.IsDaily = Parameter.IsDaily;
                repetition.IsMonthly = Parameter.IsMonthly;
                repetition.IsWeekly = Parameter.IsWeekly;
                repetition.IsYearly = Parameter.IsYearly;
                repetition.R_CronExpression = Parameter.R_CronExpression;
                repetition.Tenant_RefID = securityTicket.TenantID;
                repetition.Save(Connection, Transaction);
                calendarEvent.IsRepetitive = true;
                calendarEvent.Repetition_RefID = repetition.CMN_CAL_RepetitionID;

                ORM_CMN_CAL_Repetition_Ranx repetitionRange = new ORM_CMN_CAL_Repetition_Ranx();
                if (Parameter.repetitionRangesCMN_CAL_Repetition_RangeID != Guid.Empty)
                {
                    var result = repetitionRange.Load(Connection, Transaction, Parameter.repetitionRangesCMN_CAL_Repetition_RangeID);
                    if (result.Status != FR_Status.Success || repetitionRange.CMN_CAL_Repetition_RangeID == Guid.Empty)
                    {
                        var error = new FR_Guid();
                        error.ErrorMessage = "No Such ID";
                        error.Status = FR_Status.Error_Internal;
                        return error;
                    }
                }
                repetitionRange.End_AfterSpecifiedOccurrences = Parameter.repetitionRangesEnd_AfterSpecifiedOccurrences;
                repetitionRange.End_ByDate = Parameter.repetitionRangesEnd_ByDate;
                repetitionRange.HasEndType_DateTime = Parameter.repetitionRangesHasEndType_DateTime;
                repetitionRange.HasEndType_NoEndDate = Parameter.repetitionRangesHasEndType_NoEndDate;
                repetitionRange.HasEndType_Occurrence = Parameter.repetitionRangesHasEndType_Occurrence;
                repetitionRange.Repetition_RefID = repetition.CMN_CAL_RepetitionID;
                repetitionRange.Tenant_RefID = securityTicket.TenantID;
                repetitionRange.Save(Connection, Transaction);
            
                if (Parameter.IsDaily)
                {
                    ORM_CMN_CAL_RepetitionPatterns_Daily daily = new ORM_CMN_CAL_RepetitionPatterns_Daily();
                    if (Parameter.dailyCMN_CAL_RepetitionPattern_DailyID != Guid.Empty)
                    {
                        var result = daily.Load(Connection, Transaction, Parameter.dailyCMN_CAL_RepetitionPattern_DailyID);
                        if (result.Status != FR_Status.Success || daily.CMN_CAL_RepetitionPattern_DailyID == Guid.Empty)
                        {
                            var error = new FR_Guid();
                            error.ErrorMessage = "No Such ID";
                            error.Status = FR_Status.Error_Internal;
                            return error;
                        }
                    }
                    daily.Repetition_EveryNumberOfDays = Parameter.dailyRepetition_EveryNumberOfDays;
                    daily.Repetition_RefID = repetition.CMN_CAL_RepetitionID;
                    daily.Tenant_RefID = securityTicket.TenantID;
                    daily.Save(Connection, Transaction);
                }
                else if (Parameter.IsWeekly)
                {
                    ORM_CMN_CAL_RepetitionPatterns_Weekly weekly = new ORM_CMN_CAL_RepetitionPatterns_Weekly();
                    if (Parameter.weeklyCMN_CAL_RepetitionPattern_WeeklyID != Guid.Empty)
                    {
                        var result = weekly.Load(Connection, Transaction, Parameter.weeklyCMN_CAL_RepetitionPattern_WeeklyID);
                        if (result.Status != FR_Status.Success || weekly.CMN_CAL_RepetitionPattern_WeeklyID == Guid.Empty)
                        {
                            var error = new FR_Guid();
                            error.ErrorMessage = "No Such ID";
                            error.Status = FR_Status.Error_Internal;
                            return error;
                        }
                    }
                    weekly.HasRepeatingOn_Fridays = Parameter.weeklyHasRepeatingOn_Fridays;
                    weekly.HasRepeatingOn_Mondays = Parameter.weeklyHasRepeatingOn_Mondays;
                    weekly.HasRepeatingOn_Saturdays = Parameter.weeklyHasRepeatingOn_Saturdays;
                    weekly.HasRepeatingOn_Sundays = Parameter.weeklyHasRepeatingOn_Sundays;
                    weekly.HasRepeatingOn_Thursdays = Parameter.weeklyHasRepeatingOn_Thursdays;
                    weekly.HasRepeatingOn_Tuesdays = Parameter.weeklyHasRepeatingOn_Tuesdays;
                    weekly.HasRepeatingOn_Wednesdays = Parameter.weeklyHasRepeatingOn_Wednesdays;
                    weekly.Repetition_EveryNumberOfWeeks = Parameter.weeklyRepetition_EveryNumberOfWeeks;
                    weekly.Repetition_RefID = repetition.CMN_CAL_RepetitionID;
                    weekly.Tenant_RefID = securityTicket.TenantID;
                    weekly.Save(Connection, Transaction);
                }
                else if (Parameter.IsMonthly)
                {
                    ORM_CMN_CAL_RepetitionPatterns_Monthly monthly = new ORM_CMN_CAL_RepetitionPatterns_Monthly();
                    if (Parameter.monthlyCMN_CAL_RepetitionPattern_MonthlyID != Guid.Empty)
                    {
                        var result = monthly.Load(Connection, Transaction, Parameter.monthlyCMN_CAL_RepetitionPattern_MonthlyID);
                        if (result.Status != FR_Status.Success || monthly.CMN_CAL_RepetitionPattern_MonthlyID == Guid.Empty)
                        {
                            var error = new FR_Guid();
                            error.ErrorMessage = "No Such ID";
                            error.Status = FR_Status.Error_Internal;
                            return error;
                        }
                    }
                    monthly.Repetition_EveryNumberOfMonths = Parameter.monthlyRepetition_EveryNumberOfMonths;
                    monthly.Repetition_RefID = repetition.CMN_CAL_RepetitionID;
                    monthly.Tenant_RefID = securityTicket.TenantID;
                    if (Parameter.monthlyIsRelative)
                    {
                        monthly.IsFixed = false;
                        monthly.IsRelative = true;
                        ORM_CMN_CAL_RepetitionPatterns_Relative relative = new ORM_CMN_CAL_RepetitionPatterns_Relative();
                        if (Parameter.relativeCMN_CAL_RepetitionPattern_RelativeID != Guid.Empty)
                        {
                            var result = relative.Load(Connection, Transaction, Parameter.relativeCMN_CAL_RepetitionPattern_RelativeID);
                            if (result.Status != FR_Status.Success || relative.CMN_CAL_RepetitionPattern_RelativeID == Guid.Empty)
                            {
                                var error = new FR_Guid();
                                error.ErrorMessage = "No Such ID";
                                error.Status = FR_Status.Error_Internal;
                                return error;
                            }
                        }
                        relative.IsFriday = Parameter.relativeIsFriday;
                        relative.IsMonday = Parameter.relativeIsMonday;
                        relative.IsSaturday = Parameter.relativeIsSaturday;
                        relative.IsSunday = Parameter.relativeIsSunday;
                        relative.IsThursday = Parameter.relativeIsThursday;
                        relative.IsTuesday = Parameter.relativeIsTuesday;
                        relative.IsWednesday = Parameter.relativeIsWednesday;
                        relative.IsWeekDay = Parameter.relativeIsWeekDay;
                        relative.IsWeekendDay = Parameter.relativeIsWeekendDay;
                        relative.Ordinal = Parameter.relativeOrdinal;
                        relative.Tenant_RefID = securityTicket.TenantID;
                        relative.Save(Connection, Transaction);
                        monthly.IfRelative_RepetitionPattern_RefID = relative.CMN_CAL_RepetitionPattern_RelativeID;

                    }
                    else
                    {
                        monthly.IsRelative = false;
                        monthly.IsFixed = true;
                        monthly.IfFixed_DayOfMonth = Parameter.monthlyIfFixed_DayOfMonth;
            
                    }
                    monthly.Save(Connection, Transaction);
                }
                else
                {
                    ORM_CMN_CAL_RepetitionPatterns_Yearly yearly = new ORM_CMN_CAL_RepetitionPatterns_Yearly();
                    if (Parameter.yearlyCMN_CAL_RepetitionPattern_YearlyID != Guid.Empty)
                    {
                        var result = yearly.Load(Connection, Transaction, Parameter.yearlyCMN_CAL_RepetitionPattern_YearlyID);
                        if (result.Status != FR_Status.Success || yearly.CMN_CAL_RepetitionPattern_YearlyID == Guid.Empty)
                        {
                            var error = new FR_Guid();
                            error.ErrorMessage = "No Such ID";
                            error.Status = FR_Status.Error_Internal;
                            return error;
                        }
                    }
                    yearly.Repetition_EveryNumberOfYears = Parameter.yearlyRepetition_EveryNumberOfYears;
                    yearly.Repetition_Month = Parameter.yearlyRepetition_Month;
                    yearly.Repetition_RefID = repetition.CMN_CAL_RepetitionID;
                    yearly.Tenant_RefID = securityTicket.TenantID;
                    if (Parameter.yearlyIsRelative)
                    {
                        yearly.IsRelative = true;
                        yearly.IsFixed = false;
                        ORM_CMN_CAL_RepetitionPatterns_Relative relative = new ORM_CMN_CAL_RepetitionPatterns_Relative();
                        if (Parameter.relativeCMN_CAL_RepetitionPattern_RelativeID != Guid.Empty)
                        {
                            var result = relative.Load(Connection, Transaction, Parameter.relativeCMN_CAL_RepetitionPattern_RelativeID);
                            if (result.Status != FR_Status.Success || relative.CMN_CAL_RepetitionPattern_RelativeID == Guid.Empty)
                            {
                                var error = new FR_Guid();
                                error.ErrorMessage = "No Such ID";
                                error.Status = FR_Status.Error_Internal;
                                return error;
                            }
                        }
                        relative.IsFriday = Parameter.relativeIsFriday;
                        relative.IsMonday = Parameter.relativeIsMonday;
                        relative.IsSaturday = Parameter.relativeIsSaturday;
                        relative.IsSunday = Parameter.relativeIsSunday;
                        relative.IsThursday = Parameter.relativeIsThursday;
                        relative.IsTuesday = Parameter.relativeIsTuesday;
                        relative.IsWednesday = Parameter.relativeIsWednesday;
                        relative.IsWeekDay = Parameter.relativeIsWeekDay;
                        relative.IsWeekendDay = Parameter.relativeIsWeekendDay;
                        relative.Ordinal = Parameter.relativeOrdinal;
                        relative.Tenant_RefID = securityTicket.TenantID;
                        
                        relative.Save(Connection, Transaction);
                        yearly.IfRelative_RepetitionPattern_RefID = relative.CMN_CAL_RepetitionPattern_RelativeID;
                        yearly.IsFixed = false;
                    }
                    else
                    {
                        yearly.IsRelative = false;
                        yearly.IsFixed = true;
                        yearly.IfFixed_DayOfMonth = Parameter.yearlyIfFixed_DayOfMonth;
                    }
                    yearly.Save(Connection, Transaction);
                }

            }
            else
            {
                calendarEvent.IsRepetitive = false;
                calendarEvent.Repetition_RefID = Guid.Empty;
            }

            calendarEvent.Save(Connection, Transaction);
    
            ORM_CMN_STR_SCE_StructureCalendarEvent structureEvent = new ORM_CMN_STR_SCE_StructureCalendarEvent();
            if (Parameter.CMN_STR_SCE_StructureCalendarEventID != Guid.Empty)
            {
                var result = structureEvent.Load(Connection, Transaction, Parameter.CMN_STR_SCE_StructureCalendarEventID);
                if (result.Status != FR_Status.Success || structureEvent.CMN_STR_SCE_StructureCalendarEventID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }

            if (Parameter.IsHavingCapacityRestriction)
            {
                ORM_CMN_STR_SCE_CapacityRestriction capacityRestriction = new ORM_CMN_STR_SCE_CapacityRestriction();
                if (Parameter.CMN_STR_SCE_CapacityRestrictionID != Guid.Empty)
                {
                    var result = capacityRestriction.Load(Connection, Transaction, Parameter.CMN_STR_SCE_CapacityRestrictionID);
                    if (result.Status != FR_Status.Success || capacityRestriction.CMN_STR_SCE_CapacityRestrictionID == Guid.Empty)
                    {
                        var error = new FR_Guid();
                        error.ErrorMessage = "No Such ID";
                        error.Status = FR_Status.Error_Internal;
                        return error;
                    }
                }
                capacityRestriction.IsValueCalculated_InHeadCount = Parameter.IsValueCalculated_InHeadCount;
                capacityRestriction.IsValueCalculated_InPercentage = Parameter.IsValueCalculated_InPercentage;
                capacityRestriction.IsValueCalculated_InWorkingHours = Parameter.IsValueCalculated_InWorkingHours;
                capacityRestriction.CapacityRestrictionType_RefID = Parameter.CMN_STR_SCE_CapacityRestriction_TypeID;
                capacityRestriction.Tenant_RefID = securityTicket.TenantID;
                capacityRestriction.ValueCalculated = Parameter.ValueCalculated;
                capacityRestriction.Save(Connection, Transaction);
                structureEvent.IfHavingCapacityRestriction_Restriction_RefID = capacityRestriction.CMN_STR_SCE_CapacityRestrictionID;
                structureEvent.IsHavingCapacityRestriction = true;

            }
            else
            {
                structureEvent.IsHavingCapacityRestriction = false;
            }

            var eventType = new ORM_CMN_STR_SCE_StructureCalendarEvent_Type();
         
            var resultForType = eventType.Load(Connection, Transaction, Parameter.StructureCalendarEvent_Type_RefID);
            if (resultForType.Status != FR_Status.Success || eventType.CMN_STR_SCE_StructureCalendarEvent_TypeID == Guid.Empty)
            {
                var error = new FR_Guid();
                error.ErrorMessage = "No Such ID";
                error.Status = FR_Status.Error_Internal;
                return error;
            }




            structureEvent.IsWorkingDayEvent = eventType.IsWorkingDay;
            structureEvent.IsWorkingHalfDayEvent = eventType.IsHalfWorkingDay;
            structureEvent.IsNonWorkingDay = eventType.IsNonWorkingDay;
            structureEvent.CMN_CAL_Event_RefID = calendarEvent.CMN_CAL_EventID;
            structureEvent.StructureCalendarEvent_Type_RefID = Parameter.StructureCalendarEvent_Type_RefID;
            structureEvent.R_CalendarInstance_RefID = Parameter.CalendarInstanceID;
            structureEvent.StructureEvent_Description = Parameter.StructureEvent_Description;
            structureEvent.StructureEvent_Name = Parameter.StructureEvent_Name;
            structureEvent.Tenant_RefID = securityTicket.TenantID;
            structureEvent.IsEvent_ImportedFromTemplate = Parameter.IsEvent_ImportedFromTemplate;
            structureEvent.IsBusinessDay = Parameter.IsBusinessDay;
            structureEvent.Save(Connection, Transaction);
            returnValue.Result = structureEvent.CMN_STR_SCE_StructureCalendarEventID;

          
            ORM_CMN_STR_SCE_ForbiddenLeaveType whereInstanceForbiddenLeaveType = CSV2Core_MySQL.Support.SQLClassFilter.GetDefaultInstance<ORM_CMN_STR_SCE_ForbiddenLeaveType>();
            whereInstanceForbiddenLeaveType.CMN_STR_SCE_StructureCalendarEvent_RefID = structureEvent.CMN_STR_SCE_StructureCalendarEventID;
            CSV2Core_MySQL.Support.SQLClassFilter.Delete(Connection, Transaction, whereInstanceForbiddenLeaveType);

            foreach (var forbidenLeaveType in Parameter.forbidenLeaveTypes)
            {
                ORM_CMN_STR_SCE_ForbiddenLeaveType item = new ORM_CMN_STR_SCE_ForbiddenLeaveType();
                if (forbidenLeaveType.CMN_STR_SCE_ForbiddenLeaveTypeID != Guid.Empty)
                {
                    var result = item.Load(Connection, Transaction, forbidenLeaveType.CMN_STR_SCE_ForbiddenLeaveTypeID);
                    if (result.Status != FR_Status.Success || item.CMN_STR_SCE_ForbiddenLeaveTypeID == Guid.Empty)
                    {
                        var error = new FR_Guid();
                        error.ErrorMessage = "No Such ID";
                        error.Status = FR_Status.Error_Internal;
                        return error;
                    }
                }
                item.CMN_BPT_STA_AbsenceReason_RefID = forbidenLeaveType.CMN_BPT_STA_AbsenceReasonID;
                item.CMN_STR_SCE_StructureCalendarEvent_RefID = structureEvent.CMN_STR_SCE_StructureCalendarEventID;
                item.Tenant_RefID = securityTicket.TenantID;
                item.Save(Connection, Transaction);
            }
            return returnValue;


            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L3EV_SSE_1048 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L3EV_SSE_1048 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L3EV_SSE_1048 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3EV_SSE_1048 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw ex;
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3EV_SSE_1048 for attribute P_L3EV_SSE_1048
		[DataContract]
		public class P_L3EV_SSE_1048 
		{
			[DataMember]
			public P_L3EV_SSE_1048_forbidenLeaveTypes[] forbidenLeaveTypes { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid CalendarInstanceID { get; set; } 
			[DataMember]
			public Guid repetitionRangesCMN_CAL_Repetition_RangeID { get; set; } 
			[DataMember]
			public DateTime repetitionRangesStartDate { get; set; } 
			[DataMember]
			public bool repetitionRangesHasEndType_Occurrence { get; set; } 
			[DataMember]
			public bool repetitionRangesHasEndType_DateTime { get; set; } 
			[DataMember]
			public bool repetitionRangesHasEndType_NoEndDate { get; set; } 
			[DataMember]
			public long repetitionRangesEnd_AfterSpecifiedOccurrences { get; set; } 
			[DataMember]
			public DateTime repetitionRangesEnd_ByDate { get; set; } 
			[DataMember]
			public Guid CMN_CAL_EventID { get; set; } 
			[DataMember]
			public bool IsRepetitive { get; set; } 
			[DataMember]
			public DateTime StartTime { get; set; } 
			[DataMember]
			public DateTime EndTime { get; set; } 
			[DataMember]
			public long R_EventDuration_sec { get; set; } 
			[DataMember]
			public Guid CMN_STR_SCE_StructureCalendarEventID { get; set; } 
			[DataMember]
			public Dict StructureEvent_Name { get; set; } 
			[DataMember]
			public Dict StructureEvent_Description { get; set; } 
			[DataMember]
			public bool IsHavingCapacityRestriction { get; set; } 
			[DataMember]
			public Guid CMN_STR_SCE_CapacityRestrictionID { get; set; } 
			[DataMember]
			public bool IsValueCalculated_InPercentage { get; set; } 
			[DataMember]
			public bool IsValueCalculated_InHeadCount { get; set; } 
			[DataMember]
			public bool IsValueCalculated_InWorkingHours { get; set; } 
			[DataMember]
			public double ValueCalculated { get; set; } 
			[DataMember]
			public Guid CMN_STR_SCE_CapacityRestriction_TypeID { get; set; } 
			[DataMember]
			public Dict CapacityRestrictionType_Name { get; set; } 
			[DataMember]
			public Guid CMN_CAL_RepetitionID { get; set; } 
			[DataMember]
			public Guid StructureCalendarEvent_Type_RefID { get; set; } 
			[DataMember]
			public bool IsDaily { get; set; } 
			[DataMember]
			public bool IsMonthly { get; set; } 
			[DataMember]
			public bool IsWeekly { get; set; } 
			[DataMember]
			public bool IsYearly { get; set; } 
			[DataMember]
			public bool IsEvent_ImportedFromTemplate { get; set; } 
			[DataMember]
			public String R_CronExpression { get; set; } 
			[DataMember]
			public Guid relativeCMN_CAL_RepetitionPattern_RelativeID { get; set; } 
			[DataMember]
			public int relativeOrdinal { get; set; } 
			[DataMember]
			public bool relativeIsWeekDay { get; set; } 
			[DataMember]
			public bool relativeIsWeekendDay { get; set; } 
			[DataMember]
			public bool relativeIsMonday { get; set; } 
			[DataMember]
			public bool relativeIsTuesday { get; set; } 
			[DataMember]
			public bool relativeIsThursday { get; set; } 
			[DataMember]
			public bool relativeIsFriday { get; set; } 
			[DataMember]
			public bool relativeIsWednesday { get; set; } 
			[DataMember]
			public bool relativeIsSaturday { get; set; } 
			[DataMember]
			public Guid yearlyCMN_CAL_RepetitionPattern_YearlyID { get; set; } 
			[DataMember]
			public bool relativeIsSunday { get; set; } 
			[DataMember]
			public int yearlyRepetition_EveryNumberOfYears { get; set; } 
			[DataMember]
			public bool yearlyIsFixed { get; set; } 
			[DataMember]
			public int yearlyRepetition_Month { get; set; } 
			[DataMember]
			public bool yearlyIsRelative { get; set; } 
			[DataMember]
			public int yearlyIfFixed_DayOfMonth { get; set; } 
			[DataMember]
			public int monthlyIfFixed_DayOfMonth { get; set; } 
			[DataMember]
			public bool monthlyIsRelative { get; set; } 
			[DataMember]
			public bool weeklyHasRepeatingOn_Sundays { get; set; } 
			[DataMember]
			public bool weeklyHasRepeatingOn_Saturdays { get; set; } 
			[DataMember]
			public bool weeklyHasRepeatingOn_Thursdays { get; set; } 
			[DataMember]
			public bool weeklyHasRepeatingOn_Fridays { get; set; } 
			[DataMember]
			public bool weeklyHasRepeatingOn_Wednesdays { get; set; } 
			[DataMember]
			public bool weeklyHasRepeatingOn_Tuesdays { get; set; } 
			[DataMember]
			public bool weeklyHasRepeatingOn_Mondays { get; set; } 
			[DataMember]
			public int weeklyRepetition_EveryNumberOfWeeks { get; set; } 
			[DataMember]
			public Guid weeklyCMN_CAL_RepetitionPattern_WeeklyID { get; set; } 
			[DataMember]
			public int dailyRepetition_EveryNumberOfDays { get; set; } 
			[DataMember]
			public Guid dailyCMN_CAL_RepetitionPattern_DailyID { get; set; } 
			[DataMember]
			public Guid monthlyCMN_CAL_RepetitionPattern_MonthlyID { get; set; } 
			[DataMember]
			public int monthlyRepetition_EveryNumberOfMonths { get; set; } 
			[DataMember]
			public bool monthlyIsFixed { get; set; } 
			[DataMember]
			public bool IsBusinessDay { get; set; } 

		}
		#endregion
		#region SClass P_L3EV_SSE_1048_forbidenLeaveTypes for attribute forbidenLeaveTypes
		[DataContract]
		public class P_L3EV_SSE_1048_forbidenLeaveTypes 
		{
			//Standard type parameters
			[DataMember]
			public Dict Name { get; set; } 
			[DataMember]
			public Guid CMN_BPT_STA_AbsenceReasonID { get; set; } 
			[DataMember]
			public Guid CMN_STR_SCE_ForbiddenLeaveTypeID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_StructureEvent(P_L3EV_SSE_1048 Parameter,string sessionToken = null)
{
	 var securityTicket = ...;
	 FR_Guid result = cls_Save_StructureEvent.Invoke(connectionString,P_L3EV_SSE_1048 Parameter,securityTicket);
	 return result;
}
*/