/* 
 * Generated on 14.11.2014 12:11:39
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
using CL5_MyHealthClub_Device.Atomic.Manipulation;
using CL1_CMN_CAL_AVA;
using CL1_PPS_DEV;
using CL1_CMN_CAL;
using CL5_MyHealthClub_BookableTimeSlot.Complex.Manipulation;

namespace CL6_MyHealthClub_Device.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Device_and_TimeTables.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Device_and_TimeTables
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6DE_SDaTT_1355 Execute(DbConnection Connection,DbTransaction Transaction,P_L6DE_SDaTT_1355 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_L6DE_SDaTT_1355();

            returnValue.Result = new L6DE_SDaTT_1355();
            returnValue.Result.BaseData = new L5MHC_SDIwDC_1040();

            Parameter.BaseData.UpdateSlots = Parameter.UpdateSlots;

            var prevOfficeID = Guid.Empty;
            if (Parameter.BaseData.BaseData.PPS_DEV_Device_InstanceID != Guid.Empty)
            {
                ORM_PPS_DEV_Device_Instance_OfficeLocation location = ORM_PPS_DEV_Device_Instance_OfficeLocation.Query.Search(Connection, Transaction, new ORM_PPS_DEV_Device_Instance_OfficeLocation.Query()
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID,
                    DeviceInstance_RefID = Parameter.BaseData.BaseData.PPS_DEV_Device_InstanceID
                }).SingleOrDefault();
                if (location != null)
                    prevOfficeID = location.CMN_STR_Office_RefID;
            }


            var instanceID = cls_Save_DeviceInstance_withDeleteCheck.Invoke(Connection, Transaction, Parameter.BaseData, securityTicket).Result;
            if (Parameter.BaseData.BaseData.IsDelete)
            {
                returnValue.Result.BaseData = instanceID;
            }
            else
            {
                if (Parameter.AvailabilityDate != null)
                {
                    foreach (var timeItem in Parameter.AvailabilityDate)
                    {

                        var availabilityType = ORM_CMN_CAL_AVA_Availability_Type.Query.Search(Connection, Transaction, new ORM_CMN_CAL_AVA_Availability_Type.Query()
                        {
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false,
                            GlobalPropertyMatchingID = timeItem.Type
                        }).First();

                        #region Delete
                        if (timeItem.IsDeleted)
                        {
                            ORM_PPS_DEV_Device_Instance_Availability.Query.SoftDelete(Connection, Transaction, new ORM_PPS_DEV_Device_Instance_Availability.Query()
                                {
                                    Tenant_RefID = securityTicket.TenantID,
                                    IsDeleted = false,
                                    CMN_CAL_AVA_Availability_RefID = timeItem.AvailabilityID,
                                });
                        }
                        #endregion
                        else
                        {
                            var assignment = ORM_PPS_DEV_Device_Instance_Availability.Query.Search(Connection, Transaction, new ORM_PPS_DEV_Device_Instance_Availability.Query()
                            {
                                Tenant_RefID = securityTicket.TenantID,
                                IsDeleted = false,
                                CMN_CAL_AVA_Availability_RefID = timeItem.AvailabilityID,
                                DeviceInstance_RefID = instanceID.ID
                            }).SingleOrDefault();

                            #region Save
                            if (assignment == null)
                            {
                                assignment = new ORM_PPS_DEV_Device_Instance_Availability();
                                assignment.PPS_DEV_Device_Instance_AvailabilityID = Guid.NewGuid();
                                assignment.CMN_CAL_AVA_Availability_RefID = timeItem.AvailabilityID;
                                assignment.DeviceInstance_RefID = instanceID.ID;
                                assignment.Tenant_RefID = securityTicket.TenantID;
                                assignment.Creation_Timestamp = DateTime.Now;
                                assignment.Save(Connection, Transaction);


                                var availability = new ORM_CMN_CAL_AVA_Availability();
                                availability.CMN_CAL_AVA_AvailabilityID = assignment.CMN_CAL_AVA_Availability_RefID;
                                availability.Tenant_RefID = securityTicket.TenantID;
                                availability.Creation_Timestamp = DateTime.Now;
                                availability.AvailabilityType_RefID = availabilityType.CMN_CAL_AVA_Availability_TypeID;
                                availability.IsAvailabilityExclusionItem = timeItem.IsException;
                                availability.Save(Connection, Transaction);

                                Guid EventId = Guid.NewGuid();

                                var date = new ORM_CMN_CAL_AVA_Date();
                                date.CMN_CAL_AVA_DateID = Guid.NewGuid();
                                date.Availability_RefID = availability.CMN_CAL_AVA_AvailabilityID;
                                date.CMN_CAL_Event_RefID = EventId;
                                date.DateName = timeItem.AvailabilityDate_Name;
                                date.DateComment = timeItem.Reason;
                                date.Tenant_RefID = securityTicket.TenantID;
                                date.Creation_Timestamp = DateTime.Now;
                                date.Save(Connection, Transaction);

                                var events = new ORM_CMN_CAL_Event();
                                events.CMN_CAL_EventID = EventId;
                                events.IsRepetitive = timeItem.IsRepetitive;
                                events.StartTime = timeItem.AvailabilityDate_From;
                                events.EndTime = timeItem.AvailabilityDate_To;
                                events.Tenant_RefID = securityTicket.TenantID;
                                events.Creation_Timestamp = DateTime.Now;
                                events.Repetition_RefID = Guid.NewGuid();
                                events.Save(Connection, Transaction);

                                if (timeItem.IsRepetitive)
                                {
                                    events.Repetition_RefID = Guid.NewGuid();

                                    var repetitions = new ORM_CMN_CAL_Repetition();
                                    repetitions.CMN_CAL_RepetitionID = events.Repetition_RefID;
                                    repetitions.IsMonthly = timeItem.IsMontly;
                                    repetitions.IsWeekly = timeItem.IsWeekly;
                                    repetitions.IsDaily = timeItem.IsDaily;
                                    repetitions.IsYearly = timeItem.IsYearly;
                                    repetitions.Tenant_RefID = securityTicket.TenantID;
                                    repetitions.Creation_Timestamp = DateTime.Now;
                                    repetitions.Save(Connection, Transaction);

                                    if (timeItem.IsWeekly)
                                    {
                                        var repetitionWeekly = new ORM_CMN_CAL_RepetitionPatterns_Weekly();
                                        repetitionWeekly.CMN_CAL_RepetitionPattern_WeeklyID = Guid.NewGuid();
                                        repetitionWeekly.Repetition_RefID = repetitions.CMN_CAL_RepetitionID;
                                        repetitionWeekly.Tenant_RefID = securityTicket.TenantID;
                                        repetitionWeekly.Creation_Timestamp = DateTime.Now;
                                        repetitionWeekly.HasRepeatingOn_Fridays = timeItem.HasRepeatingOn_Fridays;
                                        repetitionWeekly.HasRepeatingOn_Mondays = timeItem.HasRepeatingOn_Mondays;
                                        repetitionWeekly.HasRepeatingOn_Saturdays = timeItem.HasRepeatingOn_Saturdays;
                                        repetitionWeekly.HasRepeatingOn_Sundays = timeItem.HasRepeatingOn_Sundays;
                                        repetitionWeekly.HasRepeatingOn_Thursdays = timeItem.HasRepeatingOn_Thursdays;
                                        repetitionWeekly.HasRepeatingOn_Tuesdays = timeItem.HasRepeatingOn_Tuesdays;
                                        repetitionWeekly.HasRepeatingOn_Wednesdays = timeItem.HasRepeatingOn_Wednesdays;
                                        repetitionWeekly.Save(Connection, Transaction);
                                    }

                                    if (timeItem.IsMontly)
                                    {
                                        var repetitionMontly = new ORM_CMN_CAL_RepetitionPatterns_Monthly();
                                        repetitionMontly.CMN_CAL_RepetitionPattern_MonthlyID = Guid.NewGuid();
                                        repetitionMontly.Repetition_RefID = repetitions.CMN_CAL_RepetitionID;
                                        repetitionMontly.Tenant_RefID = securityTicket.TenantID;
                                        repetitionMontly.Creation_Timestamp = DateTime.Now;
                                        repetitionMontly.Save(Connection, Transaction);
                                    }

                                    if (timeItem.IsDaily)
                                    {
                                        var repetitionDaily = new ORM_CMN_CAL_RepetitionPatterns_Daily();
                                        repetitionDaily.CMN_CAL_RepetitionPattern_DailyID = Guid.NewGuid();
                                        repetitionDaily.Repetition_RefID = repetitions.CMN_CAL_RepetitionID;
                                        repetitionDaily.Tenant_RefID = securityTicket.TenantID;
                                        repetitionDaily.Creation_Timestamp = DateTime.Now;
                                        repetitionDaily.Save(Connection, Transaction);
                                    }

                                    if (timeItem.IsYearly)
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
                                var date = ORM_CMN_CAL_AVA_Date.Query.Search(Connection, Transaction, new ORM_CMN_CAL_AVA_Date.Query()
                                {
                                    Availability_RefID = assignment.CMN_CAL_AVA_Availability_RefID,
                                    IsDeleted = false,
                                    Tenant_RefID = securityTicket.TenantID
                                }).Single();

                                date.DateName = timeItem.AvailabilityDate_Name;
                                date.DateComment = timeItem.Reason;
                                date.Save(Connection, Transaction);

                                var Events = ORM_CMN_CAL_Event.Query.Search(Connection, Transaction, new ORM_CMN_CAL_Event.Query()
                                {
                                    CMN_CAL_EventID = date.CMN_CAL_Event_RefID,
                                    Tenant_RefID = securityTicket.TenantID,
                                    IsDeleted = false
                                }).Single();

                                Events.IsRepetitive = timeItem.IsRepetitive;
                                Events.IsWholeDayEvent = timeItem.IsWholeDay;
                                Events.StartTime = timeItem.AvailabilityDate_From;
                                Events.EndTime = timeItem.AvailabilityDate_To;

                                var repetitions = ORM_CMN_CAL_Repetition.Query.Search(Connection, Transaction, new ORM_CMN_CAL_Repetition.Query()
                                {
                                    CMN_CAL_RepetitionID = Events.Repetition_RefID,
                                    Tenant_RefID = securityTicket.TenantID,
                                    IsDeleted = false
                                }).SingleOrDefault();

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

                                if (timeItem.IsRepetitive)
                                {
                                    Events.Repetition_RefID = Guid.NewGuid();
                                    repetitions = new ORM_CMN_CAL_Repetition();
                                    repetitions.CMN_CAL_RepetitionID = Events.Repetition_RefID;
                                    repetitions.IsMonthly = timeItem.IsMontly;
                                    repetitions.IsWeekly = timeItem.IsWeekly;
                                    repetitions.IsDaily = timeItem.IsDaily;
                                    repetitions.IsYearly = timeItem.IsYearly;
                                    repetitions.Tenant_RefID = securityTicket.TenantID;
                                    repetitions.Creation_Timestamp = DateTime.Now;
                                    repetitions.Save(Connection, Transaction);

                                    if (timeItem.IsWeekly)
                                    {
                                        var repetitionWeekly = new ORM_CMN_CAL_RepetitionPatterns_Weekly();
                                        repetitionWeekly.CMN_CAL_RepetitionPattern_WeeklyID = Guid.NewGuid();
                                        repetitionWeekly.HasRepeatingOn_Fridays = timeItem.HasRepeatingOn_Fridays;
                                        repetitionWeekly.HasRepeatingOn_Mondays = timeItem.HasRepeatingOn_Mondays;
                                        repetitionWeekly.HasRepeatingOn_Saturdays = timeItem.HasRepeatingOn_Saturdays;
                                        repetitionWeekly.HasRepeatingOn_Sundays = timeItem.HasRepeatingOn_Sundays;
                                        repetitionWeekly.HasRepeatingOn_Thursdays = timeItem.HasRepeatingOn_Thursdays;
                                        repetitionWeekly.HasRepeatingOn_Tuesdays = timeItem.HasRepeatingOn_Tuesdays;
                                        repetitionWeekly.HasRepeatingOn_Wednesdays = timeItem.HasRepeatingOn_Wednesdays;
                                        repetitionWeekly.Repetition_RefID = repetitions.CMN_CAL_RepetitionID;
                                        repetitionWeekly.Tenant_RefID = securityTicket.TenantID;
                                        repetitionWeekly.Creation_Timestamp = DateTime.Now;
                                        repetitionWeekly.Save(Connection, Transaction);
                                    }

                                    if (timeItem.IsMontly)
                                    {
                                        var repetitionMontly = new ORM_CMN_CAL_RepetitionPatterns_Monthly();
                                        repetitionMontly.CMN_CAL_RepetitionPattern_MonthlyID = Guid.NewGuid();
                                        repetitionMontly.Repetition_RefID = repetitions.CMN_CAL_RepetitionID;
                                        repetitionMontly.Tenant_RefID = securityTicket.TenantID;
                                        repetitionMontly.Creation_Timestamp = DateTime.Now;
                                        repetitionMontly.Save(Connection, Transaction);
                                    }

                                    if (timeItem.IsDaily)
                                    {
                                        var repetitionDaily = new ORM_CMN_CAL_RepetitionPatterns_Daily();
                                        repetitionDaily.CMN_CAL_RepetitionPattern_DailyID = Guid.NewGuid();
                                        repetitionDaily.Repetition_RefID = repetitions.CMN_CAL_RepetitionID;
                                        repetitionDaily.Tenant_RefID = securityTicket.TenantID;
                                        repetitionDaily.Creation_Timestamp = DateTime.Now;
                                        repetitionDaily.Save(Connection, Transaction);
                                    }

                                    if (timeItem.IsYearly)
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
                    returnValue.Result.BaseData = instanceID;
                }
            }
            if (Parameter.UpdateSlots)
            {
                if (!Parameter.BaseData.BaseData.IsDelete)
                {
                    cls_CreateUpdate_Slots_for_Practice.Invoke(Connection, Transaction, new P_L5S_SUSfP_1708() { PracticeID = Parameter.BaseData.BaseData.OfficeID }, securityTicket);
                    if (prevOfficeID != Guid.Empty && prevOfficeID != Parameter.BaseData.BaseData.OfficeID)
                        cls_CreateUpdate_Slots_for_Practice.Invoke(Connection, Transaction, new P_L5S_SUSfP_1708() { PracticeID = prevOfficeID }, securityTicket);
                }
                else
                {
                    if (prevOfficeID != Guid.Empty)
                        cls_CreateUpdate_Slots_for_Practice.Invoke(Connection, Transaction, new P_L5S_SUSfP_1708() { PracticeID = prevOfficeID }, securityTicket);      
                }
            }


            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6DE_SDaTT_1355 Invoke(string ConnectionString,P_L6DE_SDaTT_1355 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6DE_SDaTT_1355 Invoke(DbConnection Connection,P_L6DE_SDaTT_1355 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6DE_SDaTT_1355 Invoke(DbConnection Connection, DbTransaction Transaction,P_L6DE_SDaTT_1355 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6DE_SDaTT_1355 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6DE_SDaTT_1355 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6DE_SDaTT_1355 functionReturn = new FR_L6DE_SDaTT_1355();
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

				throw new Exception("Exception occured in method cls_Save_Device_and_TimeTables",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6DE_SDaTT_1355 : FR_Base
	{
		public L6DE_SDaTT_1355 Result	{ get; set; }

		public FR_L6DE_SDaTT_1355() : base() {}

		public FR_L6DE_SDaTT_1355(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6DE_SDaTT_1355 for attribute P_L6DE_SDaTT_1355
		[DataContract]
		public class P_L6DE_SDaTT_1355 
		{
			[DataMember]
			public P_L6DE_SDaTT_1355_AvailabilityDate[] AvailabilityDate { get; set; }

			//Standard type parameters
			[DataMember]
			public bool UpdateSlots { get; set; } 
			[DataMember]
			public P_L5MHC_SDIwDC_1040 BaseData { get; set; } 

		}
		#endregion
		#region SClass P_L6DE_SDaTT_1355_AvailabilityDate for attribute AvailabilityDate
		[DataContract]
		public class P_L6DE_SDaTT_1355_AvailabilityDate 
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
			public Guid AvailabilityID { get; set; } 
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
		#region SClass L6DE_SDaTT_1355 for attribute L6DE_SDaTT_1355
		[DataContract]
		public class L6DE_SDaTT_1355 
		{
			//Standard type parameters
			[DataMember]
			public L5MHC_SDIwDC_1040 BaseData { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6DE_SDaTT_1355 cls_Save_Device_and_TimeTables(,P_L6DE_SDaTT_1355 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6DE_SDaTT_1355 invocationResult = cls_Save_Device_and_TimeTables.Invoke(connectionString,P_L6DE_SDaTT_1355 Parameter,securityTicket);
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
var parameter = new CL6_MyHealthClub_Device.Complex.Manipulation.P_L6DE_SDaTT_1355();
parameter.AvailabilityDate = ...;

parameter.UpdateSlots = ...;
parameter.BaseData = ...;

*/
