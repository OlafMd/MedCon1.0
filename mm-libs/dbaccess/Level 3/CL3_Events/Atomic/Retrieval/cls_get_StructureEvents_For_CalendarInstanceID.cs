/* 
 * Generated on 10/14/2013 12:23:08 PM
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

namespace CL3_Events.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_get_StructureEvents_For_CalendarInstanceID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_get_StructureEvents_For_CalendarInstanceID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3EV_GSEFCID_1042_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3EV_GSEFCID_1042 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3EV_GSEFCID_1042_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_Events.Atomic.Retrieval.SQL.cls_get_StructureEvents_For_CalendarInstanceID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CalendarInstanceID", Parameter.CalendarInstanceID);



			List<L3EV_GSEFCID_1042_raw> results = new List<L3EV_GSEFCID_1042_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "repetitionRangesCMN_CAL_Repetition_RangeID","repetitionRangesStartDate","repetitionRangesHasEndType_Occurrence","repetitionRangesHasEndType_DateTime","repetitionRangesHasEndType_NoEndDate","repetitionRangesEnd_AfterSpecifiedOccurrences","repetitionRangesEnd_ByDate","CMN_CAL_EventID","IsRepetitive","StartTime","EndTime","R_EventDuration_sec","CMN_STR_SCE_StructureCalendarEventID","StructureEvent_Name_DictID","StructureEvent_Description_DictID","IsHavingCapacityRestriction","CMN_STR_SCE_CapacityRestrictionID","IsValueCalculated_InPercentage","IsValueCalculated_InHeadCount","IsValueCalculated_InWorkingHours","ValueCalculated","IsEvent_ImportedFromTemplate","IsShowingNotification","IsWorkingDayEvent","IsWorkingHalfDayEvent","IsNonWorkingDay","EventType_CMN_STR_SCE_StructureCalendarEvent_TypeID","EventType_EventIcon_RefID","EventType_CalendaEventName_DictID","EventType_PriorityOrdinal","EventType_ColorCode_Foreground","EventType_ColorCode_Background","EventType_ColorCode_Alpha","EventType_IsShowingNotification","EventType_IsWorkingDay","EventType_IsHalfWorkingDay","EventType_IsNonWorkingDay","CMN_STR_SCE_CapacityRestriction_TypeID","CapacityRestrictionType_Name_DictID","CMN_CAL_RepetitionID","IsDaily","IsMonthly","IsWeekly","IsYearly","R_CronExpression","relativeCMN_CAL_RepetitionPattern_RelativeID","relativeOrdinal","relativeIsWeekDay","relativeIsWeekendDay","relativeIsMonday","relativeIsTuesday","relativeIsThursday","relativeIsFriday","relativeIsWednesday","relativeIsSaturday","yearlyCMN_CAL_RepetitionPattern_YearlyID","relativeIsSunday","yearlyRepetition_EveryNumberOfYears","yearlyIsFixed","yearlyRepetition_Month","yearlyIsRelative","yearlyIfFixed_DayOfMonth","monthlyIfFixed_DayOfMonth","monthlyIsRelative","weeklyHasRepeatingOn_Sundays","weeklyHasRepeatingOn_Saturdays","weeklyHasRepeatingOn_Thursdays","weeklyHasRepeatingOn_Fridays","weeklyHasRepeatingOn_Wednesdays","weeklyHasRepeatingOn_Tuesdays","weeklyHasRepeatingOn_Mondays","weeklyRepetition_EveryNumberOfWeeks","weeklyCMN_CAL_RepetitionPattern_WeeklyID","dailyRepetition_EveryNumberOfDays","dailyCMN_CAL_RepetitionPattern_DailyID","monthlyCMN_CAL_RepetitionPattern_MonthlyID","monthlyRepetition_EveryNumberOfMonths","monthlyIsFixed","yearlyRelativeCMN_CAL_RepetitionPattern_RelativeID","yearlyRelativeOrdinal","yearlyRelativeIsWeekDay","yearlyRelativeIsWeekendDay","yearlyRelativeIsMonday","yearlyRelativeIsTuesday","yearlyRelativeIsThursday","yearlyRelativeIsFriday","yearlyRelativeIsWednesday","yearlyRelativeIsSaturday","yearlyRelativeIsSunday","InternalEventTypeID","Name_DictID","CMN_BPT_STA_AbsenceReasonID","CMN_STR_SCE_ForbiddenLeaveTypeID","CMN_STR_SCE_StructureCalendarEvent_RefID" });
				while(reader.Read())
				{
					L3EV_GSEFCID_1042_raw resultItem = new L3EV_GSEFCID_1042_raw();
					//0:Parameter repetitionRangesCMN_CAL_Repetition_RangeID of type Guid
					resultItem.repetitionRangesCMN_CAL_Repetition_RangeID = reader.GetGuid(0);
					//1:Parameter repetitionRangesStartDate of type DateTime
					resultItem.repetitionRangesStartDate = reader.GetDate(1);
					//2:Parameter repetitionRangesHasEndType_Occurrence of type bool
					resultItem.repetitionRangesHasEndType_Occurrence = reader.GetBoolean(2);
					//3:Parameter repetitionRangesHasEndType_DateTime of type bool
					resultItem.repetitionRangesHasEndType_DateTime = reader.GetBoolean(3);
					//4:Parameter repetitionRangesHasEndType_NoEndDate of type bool
					resultItem.repetitionRangesHasEndType_NoEndDate = reader.GetBoolean(4);
					//5:Parameter repetitionRangesEnd_AfterSpecifiedOccurrences of type long
					resultItem.repetitionRangesEnd_AfterSpecifiedOccurrences = reader.GetLong(5);
					//6:Parameter repetitionRangesEnd_ByDate of type DateTime
					resultItem.repetitionRangesEnd_ByDate = reader.GetDate(6);
					//7:Parameter CMN_CAL_EventID of type Guid
					resultItem.CMN_CAL_EventID = reader.GetGuid(7);
					//8:Parameter IsRepetitive of type bool
					resultItem.IsRepetitive = reader.GetBoolean(8);
					//9:Parameter StartTime of type DateTime
					resultItem.StartTime = reader.GetDate(9);
					//10:Parameter EndTime of type DateTime
					resultItem.EndTime = reader.GetDate(10);
					//11:Parameter R_EventDuration_sec of type long
					resultItem.R_EventDuration_sec = reader.GetLong(11);
					//12:Parameter CMN_STR_SCE_StructureCalendarEventID of type Guid
					resultItem.CMN_STR_SCE_StructureCalendarEventID = reader.GetGuid(12);
					//13:Parameter StructureEvent_Name of type Dict
					resultItem.StructureEvent_Name = reader.GetDictionary(13);
					resultItem.StructureEvent_Name.SourceTable = "cmn_str_sce_structurecalendarevents";
					loader.Append(resultItem.StructureEvent_Name);
					//14:Parameter StructureEvent_Description of type Dict
					resultItem.StructureEvent_Description = reader.GetDictionary(14);
					resultItem.StructureEvent_Description.SourceTable = "cmn_str_sce_structurecalendarevents";
					loader.Append(resultItem.StructureEvent_Description);
					//15:Parameter IsHavingCapacityRestriction of type bool
					resultItem.IsHavingCapacityRestriction = reader.GetBoolean(15);
					//16:Parameter CMN_STR_SCE_CapacityRestrictionID of type Guid
					resultItem.CMN_STR_SCE_CapacityRestrictionID = reader.GetGuid(16);
					//17:Parameter IsValueCalculated_InPercentage of type bool
					resultItem.IsValueCalculated_InPercentage = reader.GetBoolean(17);
					//18:Parameter IsValueCalculated_InHeadCount of type bool
					resultItem.IsValueCalculated_InHeadCount = reader.GetBoolean(18);
					//19:Parameter IsValueCalculated_InWorkingHours of type bool
					resultItem.IsValueCalculated_InWorkingHours = reader.GetBoolean(19);
					//20:Parameter ValueCalculated of type double
					resultItem.ValueCalculated = reader.GetDouble(20);
					//21:Parameter IsEvent_ImportedFromTemplate of type bool
					resultItem.IsEvent_ImportedFromTemplate = reader.GetBoolean(21);
					//22:Parameter IsShowingNotification of type bool
					resultItem.IsShowingNotification = reader.GetBoolean(22);
					//23:Parameter IsWorkingDayEvent of type bool
					resultItem.IsWorkingDayEvent = reader.GetBoolean(23);
					//24:Parameter IsWorkingHalfDayEvent of type bool
					resultItem.IsWorkingHalfDayEvent = reader.GetBoolean(24);
					//25:Parameter IsNonWorkingDay of type bool
					resultItem.IsNonWorkingDay = reader.GetBoolean(25);
					//26:Parameter EventType_CMN_STR_SCE_StructureCalendarEvent_TypeID of type Guid
					resultItem.EventType_CMN_STR_SCE_StructureCalendarEvent_TypeID = reader.GetGuid(26);
					//27:Parameter EventType_EventIcon_RefID of type Guid
					resultItem.EventType_EventIcon_RefID = reader.GetGuid(27);
					//28:Parameter EventType_CalendaEventName_DictID of type Dict
					resultItem.EventType_CalendaEventName_DictID = reader.GetDictionary(28);
					resultItem.EventType_CalendaEventName_DictID.SourceTable = "cmn_str_sce_structurecalendarevent_types";
					loader.Append(resultItem.EventType_CalendaEventName_DictID);
					//29:Parameter EventType_PriorityOrdinal of type int
					resultItem.EventType_PriorityOrdinal = reader.GetInteger(29);
					//30:Parameter EventType_ColorCode_Foreground of type String
					resultItem.EventType_ColorCode_Foreground = reader.GetString(30);
					//31:Parameter EventType_ColorCode_Background of type String
					resultItem.EventType_ColorCode_Background = reader.GetString(31);
					//32:Parameter EventType_ColorCode_Alpha of type double
					resultItem.EventType_ColorCode_Alpha = reader.GetDouble(32);
					//33:Parameter EventType_IsShowingNotification of type bool
					resultItem.EventType_IsShowingNotification = reader.GetBoolean(33);
					//34:Parameter EventType_IsWorkingDay of type double
					resultItem.EventType_IsWorkingDay = reader.GetDouble(34);
					//35:Parameter EventType_IsHalfWorkingDay of type bool
					resultItem.EventType_IsHalfWorkingDay = reader.GetBoolean(35);
					//36:Parameter EventType_IsNonWorkingDay of type double
					resultItem.EventType_IsNonWorkingDay = reader.GetDouble(36);
					//37:Parameter CMN_STR_SCE_CapacityRestriction_TypeID of type Guid
					resultItem.CMN_STR_SCE_CapacityRestriction_TypeID = reader.GetGuid(37);
					//38:Parameter CapacityRestrictionType_Name of type Dict
					resultItem.CapacityRestrictionType_Name = reader.GetDictionary(38);
					resultItem.CapacityRestrictionType_Name.SourceTable = "cmn_str_sce_capacityrestriction_types";
					loader.Append(resultItem.CapacityRestrictionType_Name);
					//39:Parameter CMN_CAL_RepetitionID of type Guid
					resultItem.CMN_CAL_RepetitionID = reader.GetGuid(39);
					//40:Parameter IsDaily of type bool
					resultItem.IsDaily = reader.GetBoolean(40);
					//41:Parameter IsMonthly of type bool
					resultItem.IsMonthly = reader.GetBoolean(41);
					//42:Parameter IsWeekly of type bool
					resultItem.IsWeekly = reader.GetBoolean(42);
					//43:Parameter IsYearly of type bool
					resultItem.IsYearly = reader.GetBoolean(43);
					//44:Parameter R_CronExpression of type String
					resultItem.R_CronExpression = reader.GetString(44);
					//45:Parameter relativeCMN_CAL_RepetitionPattern_RelativeID of type Guid
					resultItem.relativeCMN_CAL_RepetitionPattern_RelativeID = reader.GetGuid(45);
					//46:Parameter relativeOrdinal of type int
					resultItem.relativeOrdinal = reader.GetInteger(46);
					//47:Parameter relativeIsWeekDay of type bool
					resultItem.relativeIsWeekDay = reader.GetBoolean(47);
					//48:Parameter relativeIsWeekendDay of type bool
					resultItem.relativeIsWeekendDay = reader.GetBoolean(48);
					//49:Parameter relativeIsMonday of type bool
					resultItem.relativeIsMonday = reader.GetBoolean(49);
					//50:Parameter relativeIsTuesday of type bool
					resultItem.relativeIsTuesday = reader.GetBoolean(50);
					//51:Parameter relativeIsThursday of type bool
					resultItem.relativeIsThursday = reader.GetBoolean(51);
					//52:Parameter relativeIsFriday of type bool
					resultItem.relativeIsFriday = reader.GetBoolean(52);
					//53:Parameter relativeIsWednesday of type bool
					resultItem.relativeIsWednesday = reader.GetBoolean(53);
					//54:Parameter relativeIsSaturday of type bool
					resultItem.relativeIsSaturday = reader.GetBoolean(54);
					//55:Parameter yearlyCMN_CAL_RepetitionPattern_YearlyID of type Guid
					resultItem.yearlyCMN_CAL_RepetitionPattern_YearlyID = reader.GetGuid(55);
					//56:Parameter relativeIsSunday of type bool
					resultItem.relativeIsSunday = reader.GetBoolean(56);
					//57:Parameter yearlyRepetition_EveryNumberOfYears of type int
					resultItem.yearlyRepetition_EveryNumberOfYears = reader.GetInteger(57);
					//58:Parameter yearlyIsFixed of type bool
					resultItem.yearlyIsFixed = reader.GetBoolean(58);
					//59:Parameter yearlyRepetition_Month of type int
					resultItem.yearlyRepetition_Month = reader.GetInteger(59);
					//60:Parameter yearlyIsRelative of type bool
					resultItem.yearlyIsRelative = reader.GetBoolean(60);
					//61:Parameter yearlyIfFixed_DayOfMonth of type int
					resultItem.yearlyIfFixed_DayOfMonth = reader.GetInteger(61);
					//62:Parameter monthlyIfFixed_DayOfMonth of type int
					resultItem.monthlyIfFixed_DayOfMonth = reader.GetInteger(62);
					//63:Parameter monthlyIsRelative of type bool
					resultItem.monthlyIsRelative = reader.GetBoolean(63);
					//64:Parameter weeklyHasRepeatingOn_Sundays of type bool
					resultItem.weeklyHasRepeatingOn_Sundays = reader.GetBoolean(64);
					//65:Parameter weeklyHasRepeatingOn_Saturdays of type bool
					resultItem.weeklyHasRepeatingOn_Saturdays = reader.GetBoolean(65);
					//66:Parameter weeklyHasRepeatingOn_Thursdays of type bool
					resultItem.weeklyHasRepeatingOn_Thursdays = reader.GetBoolean(66);
					//67:Parameter weeklyHasRepeatingOn_Fridays of type bool
					resultItem.weeklyHasRepeatingOn_Fridays = reader.GetBoolean(67);
					//68:Parameter weeklyHasRepeatingOn_Wednesdays of type bool
					resultItem.weeklyHasRepeatingOn_Wednesdays = reader.GetBoolean(68);
					//69:Parameter weeklyHasRepeatingOn_Tuesdays of type bool
					resultItem.weeklyHasRepeatingOn_Tuesdays = reader.GetBoolean(69);
					//70:Parameter weeklyHasRepeatingOn_Mondays of type bool
					resultItem.weeklyHasRepeatingOn_Mondays = reader.GetBoolean(70);
					//71:Parameter weeklyRepetition_EveryNumberOfWeeks of type int
					resultItem.weeklyRepetition_EveryNumberOfWeeks = reader.GetInteger(71);
					//72:Parameter weeklyCMN_CAL_RepetitionPattern_WeeklyID of type Guid
					resultItem.weeklyCMN_CAL_RepetitionPattern_WeeklyID = reader.GetGuid(72);
					//73:Parameter dailyRepetition_EveryNumberOfDays of type int
					resultItem.dailyRepetition_EveryNumberOfDays = reader.GetInteger(73);
					//74:Parameter dailyCMN_CAL_RepetitionPattern_DailyID of type Guid
					resultItem.dailyCMN_CAL_RepetitionPattern_DailyID = reader.GetGuid(74);
					//75:Parameter monthlyCMN_CAL_RepetitionPattern_MonthlyID of type Guid
					resultItem.monthlyCMN_CAL_RepetitionPattern_MonthlyID = reader.GetGuid(75);
					//76:Parameter monthlyRepetition_EveryNumberOfMonths of type int
					resultItem.monthlyRepetition_EveryNumberOfMonths = reader.GetInteger(76);
					//77:Parameter monthlyIsFixed of type bool
					resultItem.monthlyIsFixed = reader.GetBoolean(77);
					//78:Parameter yearlyRelativeCMN_CAL_RepetitionPattern_RelativeID of type Guid
					resultItem.yearlyRelativeCMN_CAL_RepetitionPattern_RelativeID = reader.GetGuid(78);
					//79:Parameter yearlyRelativeOrdinal of type int
					resultItem.yearlyRelativeOrdinal = reader.GetInteger(79);
					//80:Parameter yearlyRelativeIsWeekDay of type bool
					resultItem.yearlyRelativeIsWeekDay = reader.GetBoolean(80);
					//81:Parameter yearlyRelativeIsWeekendDay of type bool
					resultItem.yearlyRelativeIsWeekendDay = reader.GetBoolean(81);
					//82:Parameter yearlyRelativeIsMonday of type bool
					resultItem.yearlyRelativeIsMonday = reader.GetBoolean(82);
					//83:Parameter yearlyRelativeIsTuesday of type bool
					resultItem.yearlyRelativeIsTuesday = reader.GetBoolean(83);
					//84:Parameter yearlyRelativeIsThursday of type bool
					resultItem.yearlyRelativeIsThursday = reader.GetBoolean(84);
					//85:Parameter yearlyRelativeIsFriday of type bool
					resultItem.yearlyRelativeIsFriday = reader.GetBoolean(85);
					//86:Parameter yearlyRelativeIsWednesday of type bool
					resultItem.yearlyRelativeIsWednesday = reader.GetBoolean(86);
					//87:Parameter yearlyRelativeIsSaturday of type bool
					resultItem.yearlyRelativeIsSaturday = reader.GetBoolean(87);
					//88:Parameter yearlyRelativeIsSunday of type bool
					resultItem.yearlyRelativeIsSunday = reader.GetBoolean(88);
					//89:Parameter InternalEventTypeID of type String
					resultItem.InternalEventTypeID = reader.GetString(89);
					//90:Parameter Name of type Dict
					resultItem.Name = reader.GetDictionary(90);
					resultItem.Name.SourceTable = "cmn_bpt_sta_absencereasons";
					loader.Append(resultItem.Name);
					//91:Parameter CMN_BPT_STA_AbsenceReasonID of type Guid
					resultItem.CMN_BPT_STA_AbsenceReasonID = reader.GetGuid(91);
					//92:Parameter CMN_STR_SCE_ForbiddenLeaveTypeID of type Guid
					resultItem.CMN_STR_SCE_ForbiddenLeaveTypeID = reader.GetGuid(92);
					//93:Parameter CMN_STR_SCE_StructureCalendarEvent_RefID of type Guid
					resultItem.CMN_STR_SCE_StructureCalendarEvent_RefID = reader.GetGuid(93);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_get_StructureEvents_For_CalendarInstanceID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L3EV_GSEFCID_1042_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3EV_GSEFCID_1042_Array Invoke(string ConnectionString,P_L3EV_GSEFCID_1042 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3EV_GSEFCID_1042_Array Invoke(DbConnection Connection,P_L3EV_GSEFCID_1042 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3EV_GSEFCID_1042_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3EV_GSEFCID_1042 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3EV_GSEFCID_1042_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3EV_GSEFCID_1042 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3EV_GSEFCID_1042_Array functionReturn = new FR_L3EV_GSEFCID_1042_Array();
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

				throw new Exception("Exception occured in method cls_get_StructureEvents_For_CalendarInstanceID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L3EV_GSEFCID_1042_raw 
	{
		public Guid repetitionRangesCMN_CAL_Repetition_RangeID; 
		public DateTime repetitionRangesStartDate; 
		public bool repetitionRangesHasEndType_Occurrence; 
		public bool repetitionRangesHasEndType_DateTime; 
		public bool repetitionRangesHasEndType_NoEndDate; 
		public long repetitionRangesEnd_AfterSpecifiedOccurrences; 
		public DateTime repetitionRangesEnd_ByDate; 
		public Guid CMN_CAL_EventID; 
		public bool IsRepetitive; 
		public DateTime StartTime; 
		public DateTime EndTime; 
		public long R_EventDuration_sec; 
		public Guid CMN_STR_SCE_StructureCalendarEventID; 
		public Dict StructureEvent_Name; 
		public Dict StructureEvent_Description; 
		public bool IsHavingCapacityRestriction; 
		public Guid CMN_STR_SCE_CapacityRestrictionID; 
		public bool IsValueCalculated_InPercentage; 
		public bool IsValueCalculated_InHeadCount; 
		public bool IsValueCalculated_InWorkingHours; 
		public double ValueCalculated; 
		public bool IsEvent_ImportedFromTemplate; 
		public bool IsShowingNotification; 
		public bool IsWorkingDayEvent; 
		public bool IsWorkingHalfDayEvent; 
		public bool IsNonWorkingDay; 
		public Guid EventType_CMN_STR_SCE_StructureCalendarEvent_TypeID; 
		public Guid EventType_EventIcon_RefID; 
		public Dict EventType_CalendaEventName_DictID; 
		public int EventType_PriorityOrdinal; 
		public String EventType_ColorCode_Foreground; 
		public String EventType_ColorCode_Background; 
		public double EventType_ColorCode_Alpha; 
		public bool EventType_IsShowingNotification; 
		public double EventType_IsWorkingDay; 
		public bool EventType_IsHalfWorkingDay; 
		public double EventType_IsNonWorkingDay; 
		public Guid CMN_STR_SCE_CapacityRestriction_TypeID; 
		public Dict CapacityRestrictionType_Name; 
		public Guid CMN_CAL_RepetitionID; 
		public bool IsDaily; 
		public bool IsMonthly; 
		public bool IsWeekly; 
		public bool IsYearly; 
		public String R_CronExpression; 
		public Guid relativeCMN_CAL_RepetitionPattern_RelativeID; 
		public int relativeOrdinal; 
		public bool relativeIsWeekDay; 
		public bool relativeIsWeekendDay; 
		public bool relativeIsMonday; 
		public bool relativeIsTuesday; 
		public bool relativeIsThursday; 
		public bool relativeIsFriday; 
		public bool relativeIsWednesday; 
		public bool relativeIsSaturday; 
		public Guid yearlyCMN_CAL_RepetitionPattern_YearlyID; 
		public bool relativeIsSunday; 
		public int yearlyRepetition_EveryNumberOfYears; 
		public bool yearlyIsFixed; 
		public int yearlyRepetition_Month; 
		public bool yearlyIsRelative; 
		public int yearlyIfFixed_DayOfMonth; 
		public int monthlyIfFixed_DayOfMonth; 
		public bool monthlyIsRelative; 
		public bool weeklyHasRepeatingOn_Sundays; 
		public bool weeklyHasRepeatingOn_Saturdays; 
		public bool weeklyHasRepeatingOn_Thursdays; 
		public bool weeklyHasRepeatingOn_Fridays; 
		public bool weeklyHasRepeatingOn_Wednesdays; 
		public bool weeklyHasRepeatingOn_Tuesdays; 
		public bool weeklyHasRepeatingOn_Mondays; 
		public int weeklyRepetition_EveryNumberOfWeeks; 
		public Guid weeklyCMN_CAL_RepetitionPattern_WeeklyID; 
		public int dailyRepetition_EveryNumberOfDays; 
		public Guid dailyCMN_CAL_RepetitionPattern_DailyID; 
		public Guid monthlyCMN_CAL_RepetitionPattern_MonthlyID; 
		public int monthlyRepetition_EveryNumberOfMonths; 
		public bool monthlyIsFixed; 
		public Guid yearlyRelativeCMN_CAL_RepetitionPattern_RelativeID; 
		public int yearlyRelativeOrdinal; 
		public bool yearlyRelativeIsWeekDay; 
		public bool yearlyRelativeIsWeekendDay; 
		public bool yearlyRelativeIsMonday; 
		public bool yearlyRelativeIsTuesday; 
		public bool yearlyRelativeIsThursday; 
		public bool yearlyRelativeIsFriday; 
		public bool yearlyRelativeIsWednesday; 
		public bool yearlyRelativeIsSaturday; 
		public bool yearlyRelativeIsSunday; 
		public String InternalEventTypeID; 
		public Dict Name; 
		public Guid CMN_BPT_STA_AbsenceReasonID; 
		public Guid CMN_STR_SCE_ForbiddenLeaveTypeID; 
		public Guid CMN_STR_SCE_StructureCalendarEvent_RefID; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L3EV_GSEFCID_1042[] Convert(List<L3EV_GSEFCID_1042_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L3EV_GSEFCID_1042 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.CMN_STR_SCE_StructureCalendarEventID)).ToArray()
	group el_L3EV_GSEFCID_1042 by new 
	{ 
		el_L3EV_GSEFCID_1042.CMN_STR_SCE_StructureCalendarEventID,

	}
	into gfunct_L3EV_GSEFCID_1042
	select new L3EV_GSEFCID_1042
	{     
		repetitionRangesCMN_CAL_Repetition_RangeID = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().repetitionRangesCMN_CAL_Repetition_RangeID ,
		repetitionRangesStartDate = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().repetitionRangesStartDate ,
		repetitionRangesHasEndType_Occurrence = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().repetitionRangesHasEndType_Occurrence ,
		repetitionRangesHasEndType_DateTime = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().repetitionRangesHasEndType_DateTime ,
		repetitionRangesHasEndType_NoEndDate = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().repetitionRangesHasEndType_NoEndDate ,
		repetitionRangesEnd_AfterSpecifiedOccurrences = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().repetitionRangesEnd_AfterSpecifiedOccurrences ,
		repetitionRangesEnd_ByDate = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().repetitionRangesEnd_ByDate ,
		CMN_CAL_EventID = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().CMN_CAL_EventID ,
		IsRepetitive = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().IsRepetitive ,
		StartTime = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().StartTime ,
		EndTime = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().EndTime ,
		R_EventDuration_sec = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().R_EventDuration_sec ,
		CMN_STR_SCE_StructureCalendarEventID = gfunct_L3EV_GSEFCID_1042.Key.CMN_STR_SCE_StructureCalendarEventID ,
		StructureEvent_Name = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().StructureEvent_Name ,
		StructureEvent_Description = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().StructureEvent_Description ,
		IsHavingCapacityRestriction = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().IsHavingCapacityRestriction ,
		CMN_STR_SCE_CapacityRestrictionID = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().CMN_STR_SCE_CapacityRestrictionID ,
		IsValueCalculated_InPercentage = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().IsValueCalculated_InPercentage ,
		IsValueCalculated_InHeadCount = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().IsValueCalculated_InHeadCount ,
		IsValueCalculated_InWorkingHours = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().IsValueCalculated_InWorkingHours ,
		ValueCalculated = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().ValueCalculated ,
		IsEvent_ImportedFromTemplate = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().IsEvent_ImportedFromTemplate ,
		IsShowingNotification = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().IsShowingNotification ,
		IsWorkingDayEvent = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().IsWorkingDayEvent ,
		IsWorkingHalfDayEvent = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().IsWorkingHalfDayEvent ,
		IsNonWorkingDay = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().IsNonWorkingDay ,
		EventType_CMN_STR_SCE_StructureCalendarEvent_TypeID = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().EventType_CMN_STR_SCE_StructureCalendarEvent_TypeID ,
		EventType_EventIcon_RefID = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().EventType_EventIcon_RefID ,
		EventType_CalendaEventName_DictID = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().EventType_CalendaEventName_DictID ,
		EventType_PriorityOrdinal = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().EventType_PriorityOrdinal ,
		EventType_ColorCode_Foreground = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().EventType_ColorCode_Foreground ,
		EventType_ColorCode_Background = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().EventType_ColorCode_Background ,
		EventType_ColorCode_Alpha = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().EventType_ColorCode_Alpha ,
		EventType_IsShowingNotification = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().EventType_IsShowingNotification ,
		EventType_IsWorkingDay = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().EventType_IsWorkingDay ,
		EventType_IsHalfWorkingDay = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().EventType_IsHalfWorkingDay ,
		EventType_IsNonWorkingDay = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().EventType_IsNonWorkingDay ,
		CMN_STR_SCE_CapacityRestriction_TypeID = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().CMN_STR_SCE_CapacityRestriction_TypeID ,
		CapacityRestrictionType_Name = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().CapacityRestrictionType_Name ,
		CMN_CAL_RepetitionID = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().CMN_CAL_RepetitionID ,
		IsDaily = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().IsDaily ,
		IsMonthly = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().IsMonthly ,
		IsWeekly = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().IsWeekly ,
		IsYearly = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().IsYearly ,
		R_CronExpression = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().R_CronExpression ,
		relativeCMN_CAL_RepetitionPattern_RelativeID = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().relativeCMN_CAL_RepetitionPattern_RelativeID ,
		relativeOrdinal = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().relativeOrdinal ,
		relativeIsWeekDay = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().relativeIsWeekDay ,
		relativeIsWeekendDay = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().relativeIsWeekendDay ,
		relativeIsMonday = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().relativeIsMonday ,
		relativeIsTuesday = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().relativeIsTuesday ,
		relativeIsThursday = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().relativeIsThursday ,
		relativeIsFriday = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().relativeIsFriday ,
		relativeIsWednesday = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().relativeIsWednesday ,
		relativeIsSaturday = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().relativeIsSaturday ,
		yearlyCMN_CAL_RepetitionPattern_YearlyID = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().yearlyCMN_CAL_RepetitionPattern_YearlyID ,
		relativeIsSunday = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().relativeIsSunday ,
		yearlyRepetition_EveryNumberOfYears = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().yearlyRepetition_EveryNumberOfYears ,
		yearlyIsFixed = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().yearlyIsFixed ,
		yearlyRepetition_Month = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().yearlyRepetition_Month ,
		yearlyIsRelative = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().yearlyIsRelative ,
		yearlyIfFixed_DayOfMonth = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().yearlyIfFixed_DayOfMonth ,
		monthlyIfFixed_DayOfMonth = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().monthlyIfFixed_DayOfMonth ,
		monthlyIsRelative = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().monthlyIsRelative ,
		weeklyHasRepeatingOn_Sundays = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().weeklyHasRepeatingOn_Sundays ,
		weeklyHasRepeatingOn_Saturdays = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().weeklyHasRepeatingOn_Saturdays ,
		weeklyHasRepeatingOn_Thursdays = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().weeklyHasRepeatingOn_Thursdays ,
		weeklyHasRepeatingOn_Fridays = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().weeklyHasRepeatingOn_Fridays ,
		weeklyHasRepeatingOn_Wednesdays = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().weeklyHasRepeatingOn_Wednesdays ,
		weeklyHasRepeatingOn_Tuesdays = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().weeklyHasRepeatingOn_Tuesdays ,
		weeklyHasRepeatingOn_Mondays = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().weeklyHasRepeatingOn_Mondays ,
		weeklyRepetition_EveryNumberOfWeeks = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().weeklyRepetition_EveryNumberOfWeeks ,
		weeklyCMN_CAL_RepetitionPattern_WeeklyID = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().weeklyCMN_CAL_RepetitionPattern_WeeklyID ,
		dailyRepetition_EveryNumberOfDays = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().dailyRepetition_EveryNumberOfDays ,
		dailyCMN_CAL_RepetitionPattern_DailyID = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().dailyCMN_CAL_RepetitionPattern_DailyID ,
		monthlyCMN_CAL_RepetitionPattern_MonthlyID = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().monthlyCMN_CAL_RepetitionPattern_MonthlyID ,
		monthlyRepetition_EveryNumberOfMonths = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().monthlyRepetition_EveryNumberOfMonths ,
		monthlyIsFixed = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().monthlyIsFixed ,
		yearlyRelativeCMN_CAL_RepetitionPattern_RelativeID = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().yearlyRelativeCMN_CAL_RepetitionPattern_RelativeID ,
		yearlyRelativeOrdinal = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().yearlyRelativeOrdinal ,
		yearlyRelativeIsWeekDay = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().yearlyRelativeIsWeekDay ,
		yearlyRelativeIsWeekendDay = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().yearlyRelativeIsWeekendDay ,
		yearlyRelativeIsMonday = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().yearlyRelativeIsMonday ,
		yearlyRelativeIsTuesday = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().yearlyRelativeIsTuesday ,
		yearlyRelativeIsThursday = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().yearlyRelativeIsThursday ,
		yearlyRelativeIsFriday = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().yearlyRelativeIsFriday ,
		yearlyRelativeIsWednesday = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().yearlyRelativeIsWednesday ,
		yearlyRelativeIsSaturday = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().yearlyRelativeIsSaturday ,
		yearlyRelativeIsSunday = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().yearlyRelativeIsSunday ,
		InternalEventTypeID = gfunct_L3EV_GSEFCID_1042.FirstOrDefault().InternalEventTypeID ,

		forbidenLeaveTypes = 
		(
			from el_forbidenLeaveTypes in gfunct_L3EV_GSEFCID_1042.Where(element => !EqualsDefaultValue(element.CMN_STR_SCE_ForbiddenLeaveTypeID)).ToArray()
			group el_forbidenLeaveTypes by new 
			{ 
				el_forbidenLeaveTypes.CMN_STR_SCE_ForbiddenLeaveTypeID,

			}
			into gfunct_forbidenLeaveTypes
			select new L3EV_GSEFCID_1042_forbidenLeaveTypes
			{     
				Name = gfunct_forbidenLeaveTypes.FirstOrDefault().Name ,
				CMN_BPT_STA_AbsenceReasonID = gfunct_forbidenLeaveTypes.FirstOrDefault().CMN_BPT_STA_AbsenceReasonID ,
				CMN_STR_SCE_ForbiddenLeaveTypeID = gfunct_forbidenLeaveTypes.Key.CMN_STR_SCE_ForbiddenLeaveTypeID ,
				CMN_STR_SCE_StructureCalendarEvent_RefID = gfunct_forbidenLeaveTypes.FirstOrDefault().CMN_STR_SCE_StructureCalendarEvent_RefID ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L3EV_GSEFCID_1042_Array : FR_Base
	{
		public L3EV_GSEFCID_1042[] Result	{ get; set; } 
		public FR_L3EV_GSEFCID_1042_Array() : base() {}

		public FR_L3EV_GSEFCID_1042_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3EV_GSEFCID_1042 for attribute P_L3EV_GSEFCID_1042
		[DataContract]
		public class P_L3EV_GSEFCID_1042 
		{
			//Standard type parameters
			[DataMember]
			public Guid CalendarInstanceID { get; set; } 

		}
		#endregion
		#region SClass L3EV_GSEFCID_1042 for attribute L3EV_GSEFCID_1042
		[DataContract]
		public class L3EV_GSEFCID_1042 
		{
			[DataMember]
			public L3EV_GSEFCID_1042_forbidenLeaveTypes[] forbidenLeaveTypes { get; set; }

			//Standard type parameters
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
			public bool IsEvent_ImportedFromTemplate { get; set; } 
			[DataMember]
			public bool IsShowingNotification { get; set; } 
			[DataMember]
			public bool IsWorkingDayEvent { get; set; } 
			[DataMember]
			public bool IsWorkingHalfDayEvent { get; set; } 
			[DataMember]
			public bool IsNonWorkingDay { get; set; } 
			[DataMember]
			public Guid EventType_CMN_STR_SCE_StructureCalendarEvent_TypeID { get; set; } 
			[DataMember]
			public Guid EventType_EventIcon_RefID { get; set; } 
			[DataMember]
			public Dict EventType_CalendaEventName_DictID { get; set; } 
			[DataMember]
			public int EventType_PriorityOrdinal { get; set; } 
			[DataMember]
			public String EventType_ColorCode_Foreground { get; set; } 
			[DataMember]
			public String EventType_ColorCode_Background { get; set; } 
			[DataMember]
			public double EventType_ColorCode_Alpha { get; set; } 
			[DataMember]
			public bool EventType_IsShowingNotification { get; set; } 
			[DataMember]
			public double EventType_IsWorkingDay { get; set; } 
			[DataMember]
			public bool EventType_IsHalfWorkingDay { get; set; } 
			[DataMember]
			public double EventType_IsNonWorkingDay { get; set; } 
			[DataMember]
			public Guid CMN_STR_SCE_CapacityRestriction_TypeID { get; set; } 
			[DataMember]
			public Dict CapacityRestrictionType_Name { get; set; } 
			[DataMember]
			public Guid CMN_CAL_RepetitionID { get; set; } 
			[DataMember]
			public bool IsDaily { get; set; } 
			[DataMember]
			public bool IsMonthly { get; set; } 
			[DataMember]
			public bool IsWeekly { get; set; } 
			[DataMember]
			public bool IsYearly { get; set; } 
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
			public Guid yearlyRelativeCMN_CAL_RepetitionPattern_RelativeID { get; set; } 
			[DataMember]
			public int yearlyRelativeOrdinal { get; set; } 
			[DataMember]
			public bool yearlyRelativeIsWeekDay { get; set; } 
			[DataMember]
			public bool yearlyRelativeIsWeekendDay { get; set; } 
			[DataMember]
			public bool yearlyRelativeIsMonday { get; set; } 
			[DataMember]
			public bool yearlyRelativeIsTuesday { get; set; } 
			[DataMember]
			public bool yearlyRelativeIsThursday { get; set; } 
			[DataMember]
			public bool yearlyRelativeIsFriday { get; set; } 
			[DataMember]
			public bool yearlyRelativeIsWednesday { get; set; } 
			[DataMember]
			public bool yearlyRelativeIsSaturday { get; set; } 
			[DataMember]
			public bool yearlyRelativeIsSunday { get; set; } 
			[DataMember]
			public String InternalEventTypeID { get; set; } 

		}
		#endregion
		#region SClass L3EV_GSEFCID_1042_forbidenLeaveTypes for attribute forbidenLeaveTypes
		[DataContract]
		public class L3EV_GSEFCID_1042_forbidenLeaveTypes 
		{
			//Standard type parameters
			[DataMember]
			public Dict Name { get; set; } 
			[DataMember]
			public Guid CMN_BPT_STA_AbsenceReasonID { get; set; } 
			[DataMember]
			public Guid CMN_STR_SCE_ForbiddenLeaveTypeID { get; set; } 
			[DataMember]
			public Guid CMN_STR_SCE_StructureCalendarEvent_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3EV_GSEFCID_1042_Array cls_get_StructureEvents_For_CalendarInstanceID(,P_L3EV_GSEFCID_1042 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3EV_GSEFCID_1042_Array invocationResult = cls_get_StructureEvents_For_CalendarInstanceID.Invoke(connectionString,P_L3EV_GSEFCID_1042 Parameter,securityTicket);
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
var parameter = new CL3_Events.Atomic.Retrieval.P_L3EV_GSEFCID_1042();
parameter.CalendarInstanceID = ...;

*/