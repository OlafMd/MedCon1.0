/* 
 * Generated on 14.11.2014 11:52:49
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
using CL1_CMN_CAL;
using CL1_CMN_CAL_AVA;
using CL1_CMN_BPT;
using CL1_CMN_BPT_EMP;
using CL5_MyHealthClub_BookableTimeSlot.Complex.Manipulation;

namespace CL5_MyHealthClub_DoctorsAndStaff.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Doctors_and_Staff_Availability.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Doctors_and_Staff_Availability
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5DO_SDaSA_1634 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_Guid();

            foreach (var item in Parameter.AvailabilityDate)
            {
                #region Delete
                if (item.IsDeleted)
                {
                    ORM_CMN_BPT_BusinessParticipant_Availability.Query.SoftDelete(Connection, Transaction, new ORM_CMN_BPT_BusinessParticipant_Availability.Query()
                    {
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false,
                        CMN_BPT_BusinessParticipant_AvailabilityID = item.OfficeAvailabilityID
                    });
                }
                #endregion
                else
                {
                    var officeAvailabilityQuery = new ORM_CMN_BPT_BusinessParticipant_Availability.Query();
                    officeAvailabilityQuery.Tenant_RefID = securityTicket.TenantID;
                    officeAvailabilityQuery.IsDeleted = false;
                    officeAvailabilityQuery.CMN_BPT_BusinessParticipant_AvailabilityID = item.OfficeAvailabilityID;

                    var bpAvailability = ORM_CMN_BPT_BusinessParticipant_Availability.Query.Search(Connection, Transaction, officeAvailabilityQuery).SingleOrDefault();

                    #region Save
                    if (bpAvailability == null)
                    {
                        bpAvailability = new ORM_CMN_BPT_BusinessParticipant_Availability();
                        bpAvailability.CMN_BPT_BusinessParticipant_AvailabilityID = item.OfficeAvailabilityID;
                        bpAvailability.BusinessParticipant_RefID = Parameter.CMN_BPT_BusinessParticipantID;
                        bpAvailability.CMN_CAL_AVA_Availability_RefID = Guid.NewGuid();
                        bpAvailability.Tenant_RefID = securityTicket.TenantID;
                        bpAvailability.Creation_Timestamp = DateTime.Now;
                        bpAvailability.Save(Connection, Transaction);


                        var availability = new ORM_CMN_CAL_AVA_Availability();
                        availability.CMN_CAL_AVA_AvailabilityID = bpAvailability.CMN_CAL_AVA_Availability_RefID;
                        availability.Tenant_RefID = securityTicket.TenantID;
                        availability.Creation_Timestamp = DateTime.Now;

                        var availabilityTypeQuery = new ORM_CMN_CAL_AVA_Availability_Type.Query();
                        availabilityTypeQuery.IsDeleted = false;
                        availabilityTypeQuery.Tenant_RefID = securityTicket.TenantID;
                        availabilityTypeQuery.GlobalPropertyMatchingID = item.Type;

                        var availabilityType = ORM_CMN_CAL_AVA_Availability_Type.Query.Search(Connection, Transaction, availabilityTypeQuery).First();

                        availability.Office_RefID = item.OfficeID;
                        availability.AvailabilityType_RefID = availabilityType.CMN_CAL_AVA_Availability_TypeID;
                        availability.IsAvailabilityExclusionItem = item.IsException;
                        availability.Save(Connection, Transaction);

                        Guid EventId = Guid.NewGuid();

                        var date = new ORM_CMN_CAL_AVA_Date();
                        date.CMN_CAL_AVA_DateID = Guid.NewGuid();
                        date.Availability_RefID = availability.CMN_CAL_AVA_AvailabilityID;
                        date.CMN_CAL_Event_RefID = EventId;
                        date.DateName = item.AvailabilityDate_Name;
                        date.DateComment = item.Reason;
                        date.Tenant_RefID = securityTicket.TenantID;
                        date.Creation_Timestamp = DateTime.Now;
                        date.Save(Connection, Transaction);

                        var events = new ORM_CMN_CAL_Event();
                        events.CMN_CAL_EventID = EventId;
                        events.IsRepetitive = item.IsRepetitive;
                        events.StartTime = item.AvailabilityDate_From;
                        events.EndTime = item.AvailabilityDate_To;
                        events.Tenant_RefID = securityTicket.TenantID;
                        events.Creation_Timestamp = DateTime.Now;
                        events.IsWholeDayEvent = item.IsWholeDay;

                        if (item.IsRepetitive)
                        {
                            events.Repetition_RefID = Guid.NewGuid();

                            var repetitions = new ORM_CMN_CAL_Repetition();
                            repetitions.CMN_CAL_RepetitionID = events.Repetition_RefID;
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
                                repetitionWeekly.HasRepeatingOn_Fridays = item.HasRepeatingOn_Fridays;
                                repetitionWeekly.HasRepeatingOn_Mondays = item.HasRepeatingOn_Mondays;
                                repetitionWeekly.HasRepeatingOn_Saturdays = item.HasRepeatingOn_Saturdays;
                                repetitionWeekly.HasRepeatingOn_Sundays = item.HasRepeatingOn_Sundays;
                                repetitionWeekly.HasRepeatingOn_Thursdays = item.HasRepeatingOn_Thursdays;
                                repetitionWeekly.HasRepeatingOn_Tuesdays = item.HasRepeatingOn_Tuesdays;
                                repetitionWeekly.HasRepeatingOn_Wednesdays = item.HasRepeatingOn_Wednesdays;
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

                        events.Save(Connection, Transaction);

                    }
                    #endregion

                    #region Edit
                    else
                    {
                        bpAvailability.Save(Connection, Transaction);
                        var eventsQuery = new ORM_CMN_CAL_Event.Query();
                        eventsQuery.IsDeleted = false;
                        eventsQuery.Tenant_RefID = securityTicket.TenantID;

                        var availability = ORM_CMN_CAL_AVA_Availability.Query.Search(Connection, Transaction, new ORM_CMN_CAL_AVA_Availability.Query()
                        {
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false,
                            CMN_CAL_AVA_AvailabilityID = bpAvailability.CMN_CAL_AVA_Availability_RefID
                        }).Single();

                        availability.Office_RefID = item.OfficeID;
                        availability.Save(Connection, Transaction);

                        var dateQuery = new ORM_CMN_CAL_AVA_Date.Query();
                        dateQuery.IsDeleted = false;
                        dateQuery.Tenant_RefID = securityTicket.TenantID;
                        dateQuery.Availability_RefID = bpAvailability.CMN_CAL_AVA_Availability_RefID;

                        var date = ORM_CMN_CAL_AVA_Date.Query.Search(Connection, Transaction, dateQuery).Single();
                        date.DateName = item.AvailabilityDate_Name;
                        date.DateComment = item.Reason;
                        date.Save(Connection, Transaction);

                        eventsQuery.CMN_CAL_EventID = date.CMN_CAL_Event_RefID;

                        var Events = ORM_CMN_CAL_Event.Query.Search(Connection, Transaction, eventsQuery).Single();

                        Events.IsRepetitive = item.IsRepetitive;
                        Events.IsWholeDayEvent = item.IsWholeDay;
                        Events.StartTime = item.AvailabilityDate_From;
                        Events.EndTime = item.AvailabilityDate_To;
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

                            if (repetitions.IsWeekly)
                            {
                                ORM_CMN_CAL_RepetitionPatterns_Weekly.Query.SoftDelete(Connection, Transaction, new ORM_CMN_CAL_RepetitionPatterns_Weekly.Query()
                                {
                                    IsDeleted = false,
                                    Tenant_RefID = securityTicket.TenantID,
                                    Repetition_RefID = repetitions.CMN_CAL_RepetitionID,
                                });
                            }

                            if (repetitions.IsMonthly)
                            {
                                ORM_CMN_CAL_RepetitionPatterns_Monthly.Query.SoftDelete(Connection, Transaction, new ORM_CMN_CAL_RepetitionPatterns_Monthly.Query()
                                {
                                    Repetition_RefID = repetitions.CMN_CAL_RepetitionID,
                                    Tenant_RefID = securityTicket.TenantID,
                                    IsDeleted = false
                                });
                            }

                            if (repetitions.IsDaily)
                            {
                                ORM_CMN_CAL_RepetitionPatterns_Daily.Query.SoftDelete(Connection, Transaction, new ORM_CMN_CAL_RepetitionPatterns_Daily.Query()
                                {
                                    Repetition_RefID = repetitions.CMN_CAL_RepetitionID,
                                    IsDeleted = false,
                                    Tenant_RefID = securityTicket.TenantID
                                });
                            }

                            if (repetitions.IsYearly)
                            {
                                ORM_CMN_CAL_RepetitionPatterns_Yearly.Query.SoftDelete(Connection, Transaction, new ORM_CMN_CAL_RepetitionPatterns_Yearly.Query()
                                {
                                    Tenant_RefID = securityTicket.TenantID,
                                    IsDeleted = false,
                                    Repetition_RefID = repetitions.CMN_CAL_RepetitionID
                                });
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
                                repetitionWeekly.HasRepeatingOn_Fridays = item.HasRepeatingOn_Fridays;
                                repetitionWeekly.HasRepeatingOn_Mondays = item.HasRepeatingOn_Mondays;
                                repetitionWeekly.HasRepeatingOn_Saturdays = item.HasRepeatingOn_Saturdays;
                                repetitionWeekly.HasRepeatingOn_Sundays = item.HasRepeatingOn_Sundays;
                                repetitionWeekly.HasRepeatingOn_Thursdays = item.HasRepeatingOn_Thursdays;
                                repetitionWeekly.HasRepeatingOn_Tuesdays = item.HasRepeatingOn_Tuesdays;
                                repetitionWeekly.HasRepeatingOn_Wednesdays = item.HasRepeatingOn_Wednesdays;
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
            var emp = ORM_CMN_BPT_EMP_Employee.Query.Search(Connection, Transaction, new ORM_CMN_BPT_EMP_Employee.Query { BusinessParticipant_RefID = Parameter.CMN_BPT_BusinessParticipantID, IsDeleted = false, Tenant_RefID = securityTicket.TenantID }).FirstOrDefault();       
            var oficeToDoctorList = ORM_CMN_BPT_EMP_Employee_2_Office.Query.Search(Connection, Transaction, new ORM_CMN_BPT_EMP_Employee_2_Office.Query { CMN_BPT_EMP_Employee_RefID = emp.CMN_BPT_EMP_EmployeeID, IsDeleted = false, Tenant_RefID = securityTicket.TenantID });

            if(Parameter.UpdateSlots)
                foreach (var o2d in oficeToDoctorList)
                    cls_CreateUpdate_Slots_for_Practice.Invoke(Connection, Transaction, new P_L5S_SUSfP_1708() { PracticeID = o2d.CMN_STR_Office_RefID }, securityTicket);
            
            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5DO_SDaSA_1634 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5DO_SDaSA_1634 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5DO_SDaSA_1634 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5DO_SDaSA_1634 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Doctors_and_Staff_Availability",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5DO_SDaSA_1634 for attribute P_L5DO_SDaSA_1634
		[DataContract]
		public class P_L5DO_SDaSA_1634 
		{
			[DataMember]
			public P_L5DO_SDaSA_1634_AvailabilityDate[] AvailabilityDate { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid CMN_BPT_BusinessParticipantID { get; set; } 
			[DataMember]
			public bool UpdateSlots { get; set; } 

		}
		#endregion
		#region SClass P_L5DO_SDaSA_1634_AvailabilityDate for attribute AvailabilityDate
		[DataContract]
		public class P_L5DO_SDaSA_1634_AvailabilityDate 
		{
			//Standard type parameters
			[DataMember]
			public Boolean IsDeleted { get; set; } 
			[DataMember]
			public Boolean IsException { get; set; } 
			[DataMember]
			public String Reason { get; set; } 
			[DataMember]
			public String Type { get; set; } 
			[DataMember]
			public String AvailabilityDate_Name { get; set; } 
			[DataMember]
			public DateTime AvailabilityDate_From { get; set; } 
			[DataMember]
			public DateTime AvailabilityDate_To { get; set; } 
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
			public Guid OfficeID { get; set; } 
			[DataMember]
			public Guid OfficeAvailabilityID { get; set; } 
			[DataMember]
			public bool HasRepeatingOn_Mondays { get; set; } 
			[DataMember]
			public bool HasRepeatingOn_Tuesdays { get; set; } 
			[DataMember]
			public bool HasRepeatingOn_Wednesdays { get; set; } 
			[DataMember]
			public bool HasRepeatingOn_Thursdays { get; set; } 
			[DataMember]
			public bool HasRepeatingOn_Fridays { get; set; } 
			[DataMember]
			public bool HasRepeatingOn_Saturdays { get; set; } 
			[DataMember]
			public bool HasRepeatingOn_Sundays { get; set; } 
			[DataMember]
			public bool IsWholeDay { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Doctors_and_Staff_Availability(,P_L5DO_SDaSA_1634 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Doctors_and_Staff_Availability.Invoke(connectionString,P_L5DO_SDaSA_1634 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_DoctorsAndStaff.Atomic.Manipulation.P_L5DO_SDaSA_1634();
parameter.AvailabilityDate = ...;

parameter.CMN_BPT_BusinessParticipantID = ...;
parameter.UpdateSlots = ...;

*/
