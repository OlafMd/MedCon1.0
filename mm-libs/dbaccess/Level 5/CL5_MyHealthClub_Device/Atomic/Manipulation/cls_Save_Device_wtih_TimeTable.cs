/* 
 * Generated on 30.05.2014 17:47:46
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
using CL3_Device.Atomic.Manipulation;
using CL1_CMN_CAL_AVA;
using CL1_PPS_DEV;
using CL1_CMN_CAL;

namespace CL5_MyHealthClub_Device.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Device_wtih_TimeTable.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Device_wtih_TimeTable
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5MHC_SDwTT_1419 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            var instanceID = cls_Save_DeviceInstance.Invoke(Connection, Transaction, Parameter.BaseData, securityTicket).Result;

            if (Parameter.Availabilities != null)
            {
                foreach (var availability in Parameter.Availabilities)
                {
                    if (!availability.IsDelete)
                    {
                        ORM_PPS_DEV_Device_Instance_Availability assignemnt;
                        if (availability.CMN_CAL_AVA_AvailabilityID != Guid.Empty)
                        {

                            assignemnt = ORM_PPS_DEV_Device_Instance_Availability.Query.Search(Connection, Transaction, new ORM_PPS_DEV_Device_Instance_Availability.Query()
                                {
                                    CMN_CAL_AVA_Availability_RefID = availability.CMN_CAL_AVA_AvailabilityID,
                                    DeviceInstance_RefID = instanceID,
                                    IsDeleted = false,
                                    Tenant_RefID = securityTicket.TenantID
                                }).Single();
                        }
                        else
                        {
                            assignemnt = new ORM_PPS_DEV_Device_Instance_Availability();
                            assignemnt.PPS_DEV_Device_Instance_AvailabilityID = Guid.NewGuid();
                            assignemnt.DeviceInstance_RefID = instanceID;
                            assignemnt.CMN_CAL_AVA_Availability_RefID = Guid.NewGuid();
                            assignemnt.Tenant_RefID = securityTicket.TenantID;
                            assignemnt.Save(Connection, Transaction);
                        }

                        ORM_CMN_CAL_AVA_Availability ORM_CMN_CAL_AVA_Availability = ORM_CMN_CAL_AVA_Availability.Query.Search(Connection, Transaction, new ORM_CMN_CAL_AVA_Availability.Query()
                        {
                            CMN_CAL_AVA_AvailabilityID = assignemnt.CMN_CAL_AVA_Availability_RefID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        }).SingleOrDefault();

                        if (ORM_CMN_CAL_AVA_Availability == null)
                        {
                            ORM_CMN_CAL_AVA_Availability = new ORM_CMN_CAL_AVA_Availability();
                            ORM_CMN_CAL_AVA_Availability.CMN_CAL_AVA_AvailabilityID = assignemnt.CMN_CAL_AVA_Availability_RefID;
                            ORM_CMN_CAL_AVA_Availability.Tenant_RefID = securityTicket.TenantID;
                        }
                        ORM_CMN_CAL_AVA_Availability.Save(Connection, Transaction);

                        ORM_CMN_CAL_AVA_Date date = ORM_CMN_CAL_AVA_Date.Query.Search(Connection, Transaction, new ORM_CMN_CAL_AVA_Date.Query()
                        {
                            Availability_RefID = ORM_CMN_CAL_AVA_Availability.CMN_CAL_AVA_AvailabilityID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        }).SingleOrDefault();

                        if (date == null)
                        {
                            date = new ORM_CMN_CAL_AVA_Date();
                            date.CMN_CAL_AVA_DateID = Guid.NewGuid();
                            date.Tenant_RefID = securityTicket.TenantID;
                            date.Availability_RefID = ORM_CMN_CAL_AVA_Availability.CMN_CAL_AVA_AvailabilityID;
                            date.CMN_CAL_Event_RefID = Guid.NewGuid();             
                        }
                        date.DateName = availability.Name;
                        date.Save(Connection, Transaction);

                        ORM_CMN_CAL_Event eventItem = ORM_CMN_CAL_Event.Query.Search(Connection, Transaction, new ORM_CMN_CAL_Event.Query()
                        {
                            CMN_CAL_EventID = date.CMN_CAL_Event_RefID,
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false
                        }).SingleOrDefault();

                        if (eventItem == null)
                        {
                            eventItem = new ORM_CMN_CAL_Event();
                            eventItem.CMN_CAL_EventID = Guid.NewGuid();
                            eventItem.Tenant_RefID = securityTicket.TenantID;
                            eventItem.IsRepetitive = true;
                            eventItem.Repetition_RefID = Guid.NewGuid();
                        }
                        eventItem.IsWholeDayEvent = availability.IsWholeDay;
                        eventItem.StartTime = availability.StartTime;
                        eventItem.EndTime = availability.EndTime;
                        eventItem.Save(Connection, Transaction);

                        ORM_CMN_CAL_Repetition repetition = ORM_CMN_CAL_Repetition.Query.Search(Connection, Transaction, new ORM_CMN_CAL_Repetition.Query()
                        {
                            CMN_CAL_RepetitionID = eventItem.Repetition_RefID,
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false
                        }).SingleOrDefault();

                        if (repetition == null)
                        {
                            repetition = new ORM_CMN_CAL_Repetition();
                            repetition.CMN_CAL_RepetitionID = Guid.NewGuid();
                            repetition.Tenant_RefID = securityTicket.TenantID;
                            repetition.CMN_CAL_RepetitionID = eventItem.Repetition_RefID;
                            repetition.IsWeekly = true;
                            repetition.Save(Connection, Transaction);
                        }

                        ORM_CMN_CAL_RepetitionPatterns_Weekly weekly = ORM_CMN_CAL_RepetitionPatterns_Weekly.Query.Search(Connection, Transaction, new ORM_CMN_CAL_RepetitionPatterns_Weekly.Query()
                        {
                            Repetition_RefID = repetition.CMN_CAL_RepetitionID,
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false
                        }).SingleOrDefault();

                        if (repetition == null)
                        {
                            weekly = new ORM_CMN_CAL_RepetitionPatterns_Weekly();
                            weekly.CMN_CAL_RepetitionPattern_WeeklyID = Guid.NewGuid();
                            weekly.Repetition_RefID = repetition.CMN_CAL_RepetitionID;
                            weekly.Tenant_RefID = securityTicket.TenantID;
                            weekly.Save(Connection, Transaction);
                        }
                    }
                    else
                    {

                        var assignemnt = ORM_PPS_DEV_Device_Instance_Availability.Query.Search(Connection, Transaction, new ORM_PPS_DEV_Device_Instance_Availability.Query()
                        {
                            CMN_CAL_AVA_Availability_RefID = availability.CMN_CAL_AVA_AvailabilityID,
                            DeviceInstance_RefID = instanceID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        }).Single();

                        ORM_CMN_CAL_AVA_Availability ORM_CMN_CAL_AVA_Availability = ORM_CMN_CAL_AVA_Availability.Query.Search(Connection, Transaction, new ORM_CMN_CAL_AVA_Availability.Query()
                        {
                            CMN_CAL_AVA_AvailabilityID = assignemnt.CMN_CAL_AVA_Availability_RefID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        }).Single();

                        ORM_CMN_CAL_AVA_Date date = ORM_CMN_CAL_AVA_Date.Query.Search(Connection, Transaction, new ORM_CMN_CAL_AVA_Date.Query()
                        {
                            Availability_RefID = ORM_CMN_CAL_AVA_Availability.CMN_CAL_AVA_AvailabilityID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        }).Single();

                        ORM_CMN_CAL_Event eventItem = ORM_CMN_CAL_Event.Query.Search(Connection, Transaction, new ORM_CMN_CAL_Event.Query()
                        {
                            CMN_CAL_EventID = date.CMN_CAL_Event_RefID,
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false
                        }).Single();

                        ORM_CMN_CAL_Repetition repetition = ORM_CMN_CAL_Repetition.Query.Search(Connection, Transaction, new ORM_CMN_CAL_Repetition.Query()
                        {
                            CMN_CAL_RepetitionID = eventItem.Repetition_RefID,
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false
                        }).Single();

                        ORM_CMN_CAL_RepetitionPatterns_Weekly weekly = ORM_CMN_CAL_RepetitionPatterns_Weekly.Query.Search(Connection, Transaction, new ORM_CMN_CAL_RepetitionPatterns_Weekly.Query()
                        {
                            Repetition_RefID = repetition.CMN_CAL_RepetitionID,
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false
                        }).Single();

                        assignemnt.IsDeleted = true;
                        assignemnt.Save(Connection, Transaction);
                        ORM_CMN_CAL_AVA_Availability.IsDeleted = true;
                        ORM_CMN_CAL_AVA_Availability.Save(Connection, Transaction);
                        date.IsDeleted = true;
                        date.Save(Connection, Transaction);
                        eventItem.IsDeleted = true;
                        eventItem.Save(Connection, Transaction);
                        repetition.IsDeleted = true;
                        repetition.Save(Connection, Transaction);
                        weekly.IsDeleted = true;
                        weekly.Save(Connection, Transaction);
                    }
                }
            }

            if (Parameter.Unavailabilities != null)
            {
                foreach (var unavailability in Parameter.Unavailabilities)
                {
                    if (!unavailability.IsDelete)
                    {
                        ORM_PPS_DEV_Device_Instance_Availability assignemnt;
                        if (unavailability.CMN_CAL_AVA_AvailabilityID != Guid.Empty)
                        {

                            assignemnt = ORM_PPS_DEV_Device_Instance_Availability.Query.Search(Connection, Transaction, new ORM_PPS_DEV_Device_Instance_Availability.Query()
                            {
                                CMN_CAL_AVA_Availability_RefID = unavailability.CMN_CAL_AVA_AvailabilityID,
                                DeviceInstance_RefID = instanceID,
                                IsDeleted = false,
                                Tenant_RefID = securityTicket.TenantID
                            }).Single();
                        }
                        else
                        {
                            assignemnt = new ORM_PPS_DEV_Device_Instance_Availability();
                            assignemnt.PPS_DEV_Device_Instance_AvailabilityID = Guid.NewGuid();
                            assignemnt.DeviceInstance_RefID = instanceID;
                            assignemnt.CMN_CAL_AVA_Availability_RefID = Guid.NewGuid();
                            assignemnt.Tenant_RefID = securityTicket.TenantID;
                            assignemnt.Save(Connection, Transaction);
                        }

                        ORM_CMN_CAL_AVA_Availability ORM_CMN_CAL_AVA_Availability = ORM_CMN_CAL_AVA_Availability.Query.Search(Connection, Transaction, new ORM_CMN_CAL_AVA_Availability.Query()
                        {
                            CMN_CAL_AVA_AvailabilityID = assignemnt.CMN_CAL_AVA_Availability_RefID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID,
                            IsAvailabilityExclusionItem = true
                        }).SingleOrDefault();

                        if (ORM_CMN_CAL_AVA_Availability == null)
                        {
                            ORM_CMN_CAL_AVA_Availability = new ORM_CMN_CAL_AVA_Availability();
                            ORM_CMN_CAL_AVA_Availability.CMN_CAL_AVA_AvailabilityID = assignemnt.CMN_CAL_AVA_Availability_RefID;
                            ORM_CMN_CAL_AVA_Availability.Tenant_RefID = securityTicket.TenantID;
                            ORM_CMN_CAL_AVA_Availability.IsAvailabilityExclusionItem = true;
                        }
                        ORM_CMN_CAL_AVA_Availability.AvailabilityComment = unavailability.Reason;
                        ORM_CMN_CAL_AVA_Availability.Save(Connection, Transaction);

                        ORM_CMN_CAL_AVA_Date date = ORM_CMN_CAL_AVA_Date.Query.Search(Connection, Transaction, new ORM_CMN_CAL_AVA_Date.Query()
                        {
                            Availability_RefID = ORM_CMN_CAL_AVA_Availability.CMN_CAL_AVA_AvailabilityID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID,
                        }).SingleOrDefault();

                        if (date == null)
                        {
                            date = new ORM_CMN_CAL_AVA_Date();
                            date.CMN_CAL_AVA_DateID = Guid.NewGuid();
                            date.Tenant_RefID = securityTicket.TenantID;
                            date.Availability_RefID = ORM_CMN_CAL_AVA_Availability.CMN_CAL_AVA_AvailabilityID;
                            date.CMN_CAL_Event_RefID = Guid.NewGuid();
                            date.Save(Connection, Transaction);
                        }

                        ORM_CMN_CAL_Event eventItem = ORM_CMN_CAL_Event.Query.Search(Connection, Transaction, new ORM_CMN_CAL_Event.Query()
                        {
                            CMN_CAL_EventID = date.CMN_CAL_Event_RefID,
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false
                        }).SingleOrDefault();

                        if (eventItem == null)
                        {
                            eventItem = new ORM_CMN_CAL_Event();
                            eventItem.CMN_CAL_EventID = Guid.NewGuid();
                            eventItem.Tenant_RefID = securityTicket.TenantID;
                            eventItem.IsRepetitive = true;
                            eventItem.Repetition_RefID = Guid.NewGuid();
                        }
                        eventItem.IsWholeDayEvent = unavailability.IsWholeDay;
                        eventItem.StartTime = unavailability.StartTime;
                        eventItem.EndTime = unavailability.EndTime;
                        eventItem.Save(Connection, Transaction);

                        ORM_CMN_CAL_Repetition repetition = ORM_CMN_CAL_Repetition.Query.Search(Connection, Transaction, new ORM_CMN_CAL_Repetition.Query()
                        {
                            CMN_CAL_RepetitionID = eventItem.Repetition_RefID,
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false
                        }).SingleOrDefault();

                        if (repetition == null)
                        {
                            repetition = new ORM_CMN_CAL_Repetition();
                            repetition.CMN_CAL_RepetitionID = Guid.NewGuid();
                            repetition.Tenant_RefID = securityTicket.TenantID;
                            repetition.CMN_CAL_RepetitionID = eventItem.Repetition_RefID;
                            repetition.IsWeekly = true;
                            repetition.Save(Connection, Transaction);
                        }

                        ORM_CMN_CAL_RepetitionPatterns_Weekly weekly = ORM_CMN_CAL_RepetitionPatterns_Weekly.Query.Search(Connection, Transaction, new ORM_CMN_CAL_RepetitionPatterns_Weekly.Query()
                        {
                            Repetition_RefID = repetition.CMN_CAL_RepetitionID,
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false
                        }).SingleOrDefault();

                        if (repetition == null)
                        {
                            weekly = new ORM_CMN_CAL_RepetitionPatterns_Weekly();
                            weekly.CMN_CAL_RepetitionPattern_WeeklyID = Guid.NewGuid();
                            weekly.Repetition_RefID = repetition.CMN_CAL_RepetitionID;
                            weekly.Tenant_RefID = securityTicket.TenantID;
                            weekly.Save(Connection, Transaction);
                        }
                    }
                    else
                    {

                        var assignemnt = ORM_PPS_DEV_Device_Instance_Availability.Query.Search(Connection, Transaction, new ORM_PPS_DEV_Device_Instance_Availability.Query()
                        {
                            CMN_CAL_AVA_Availability_RefID = unavailability.CMN_CAL_AVA_AvailabilityID,
                            DeviceInstance_RefID = instanceID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        }).Single();

                        ORM_CMN_CAL_AVA_Availability ORM_CMN_CAL_AVA_Availability = ORM_CMN_CAL_AVA_Availability.Query.Search(Connection, Transaction, new ORM_CMN_CAL_AVA_Availability.Query()
                        {
                            CMN_CAL_AVA_AvailabilityID = assignemnt.CMN_CAL_AVA_Availability_RefID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        }).Single();

                        ORM_CMN_CAL_AVA_Date date = ORM_CMN_CAL_AVA_Date.Query.Search(Connection, Transaction, new ORM_CMN_CAL_AVA_Date.Query()
                        {
                            Availability_RefID = ORM_CMN_CAL_AVA_Availability.CMN_CAL_AVA_AvailabilityID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        }).Single();

                        ORM_CMN_CAL_Event eventItem = ORM_CMN_CAL_Event.Query.Search(Connection, Transaction, new ORM_CMN_CAL_Event.Query()
                        {
                            CMN_CAL_EventID = date.CMN_CAL_Event_RefID,
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false
                        }).Single();

                        ORM_CMN_CAL_Repetition repetition = ORM_CMN_CAL_Repetition.Query.Search(Connection, Transaction, new ORM_CMN_CAL_Repetition.Query()
                        {
                            CMN_CAL_RepetitionID = eventItem.Repetition_RefID,
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false
                        }).Single();

                        ORM_CMN_CAL_RepetitionPatterns_Weekly weekly = ORM_CMN_CAL_RepetitionPatterns_Weekly.Query.Search(Connection, Transaction, new ORM_CMN_CAL_RepetitionPatterns_Weekly.Query()
                        {
                            Repetition_RefID = repetition.CMN_CAL_RepetitionID,
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false
                        }).Single();

                        assignemnt.IsDeleted = true;
                        assignemnt.Save(Connection, Transaction);
                        ORM_CMN_CAL_AVA_Availability.IsDeleted = true;
                        ORM_CMN_CAL_AVA_Availability.Save(Connection, Transaction);
                        date.IsDeleted = true;
                        date.Save(Connection, Transaction);
                        eventItem.IsDeleted = true;
                        eventItem.Save(Connection, Transaction);
                        repetition.IsDeleted = true;
                        repetition.Save(Connection, Transaction);
                        weekly.IsDeleted = true;
                        weekly.Save(Connection, Transaction);
                    }
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
		public static FR_Guid Invoke(string ConnectionString,P_L5MHC_SDwTT_1419 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5MHC_SDwTT_1419 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5MHC_SDwTT_1419 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5MHC_SDwTT_1419 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Device_wtih_TimeTable",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5MHC_SDwTT_1419 for attribute P_L5MHC_SDwTT_1419
		[DataContract]
		public class P_L5MHC_SDwTT_1419 
		{
			[DataMember]
			public P_L5MHC_SDwTT_1419_Availability[] Availabilities { get; set; }
			[DataMember]
			public P_L5MHC_SDwTT_1419_Unavailability[] Unavailabilities { get; set; }

			//Standard type parameters
			[DataMember]
			public P_L3DE_SDI_1107 BaseData { get; set; } 

		}
		#endregion
		#region SClass P_L5MHC_SDwTT_1419_Availability for attribute Availabilities
		[DataContract]
		public class P_L5MHC_SDwTT_1419_Availability 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_CAL_AVA_AvailabilityID { get; set; } 
			[DataMember]
			public DateTime StartTime { get; set; } 
			[DataMember]
			public DateTime EndTime { get; set; } 
			[DataMember]
			public String Name { get; set; } 
			[DataMember]
			public bool IsWholeDay { get; set; } 
			[DataMember]
			public bool IsDelete { get; set; } 

		}
		#endregion
		#region SClass P_L5MHC_SDwTT_1419_Unavailability for attribute Unavailabilities
		[DataContract]
		public class P_L5MHC_SDwTT_1419_Unavailability 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_CAL_AVA_AvailabilityID { get; set; } 
			[DataMember]
			public DateTime StartTime { get; set; } 
			[DataMember]
			public DateTime EndTime { get; set; } 
			[DataMember]
			public String Reason { get; set; } 
			[DataMember]
			public int Recurrence { get; set; } 
			[DataMember]
			public bool IsWholeDay { get; set; } 
			[DataMember]
			public bool IsDelete { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Device_wtih_TimeTable(,P_L5MHC_SDwTT_1419 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Device_wtih_TimeTable.Invoke(connectionString,P_L5MHC_SDwTT_1419 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_Device.Atomic.Manipulation.P_L5MHC_SDwTT_1419();
parameter.Availabilities = ...;
parameter.Unavailabilities = ...;

parameter.BaseData = ...;

*/
