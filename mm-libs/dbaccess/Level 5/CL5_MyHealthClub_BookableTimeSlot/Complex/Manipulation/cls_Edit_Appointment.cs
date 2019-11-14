/* 
 * Generated on 09.01.2015 10:51:19
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
using CL1_PPS_TSK_BOK;
using CL5_MyHealthClub_BookableTimeSlot.Atomic.Retrieval;
using CL5_MyHealthClub_BookableTimeSlot.Atomic.Manipulation;
using CL5_MyHealthClub_TaskTemplate.Atomic.Retrieval;

namespace CL5_MyHealthClub_BookableTimeSlot.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Edit_Appointment.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Edit_Appointment
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5BTS_EA_2008 Execute(DbConnection Connection,DbTransaction Transaction,P_L5BTS_EA_2008 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_L5BTS_EA_2008();
            returnValue.Result = new L5BTS_EA_2008();

            var appointment = cls_Get_AllAppointment_Task_for_AppointmentID.Invoke(Connection, Transaction, new P_L5A_GAATfAID_1530() { AppointmentID = Parameter.AppointmentID }, securityTicket).Result;

            var oldCombinationORM = ORM_PPS_TSK_BOK_AvailableResourceCombination.Query.Search(Connection, Transaction, new ORM_PPS_TSK_BOK_AvailableResourceCombination.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                PPS_TSK_BOK_AvailableResourceCombinationID = Parameter.OldCombinationID
            }).Single();
            oldCombinationORM.IsAvailable = true;
            oldCombinationORM.Save(Connection, Transaction);

            var newCombinationORM = ORM_PPS_TSK_BOK_AvailableResourceCombination.Query.Search(Connection, Transaction, new ORM_PPS_TSK_BOK_AvailableResourceCombination.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                PPS_TSK_BOK_AvailableResourceCombinationID = Parameter.NewCombinationID
            }).Single();

            var newSlot = ORM_PPS_TSK_BOK_BookableTimeSlot.Query.Search(Connection, Transaction, new ORM_PPS_TSK_BOK_BookableTimeSlot.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                PPS_TSK_BOK_BookableTimeSlotID = newCombinationORM.BookableTimeSlot_RefID
            }).Single();


            var allCombs = cls_Get_Slot_Combiantions_for_SlotID.Invoke(Connection, Transaction, new P_L5BTS_GSCfSID_1319() { SlotID = newSlot.PPS_TSK_BOK_BookableTimeSlotID }, securityTicket).Result;
            var selectedCombination = allCombs.Single(s => s.PPS_TSK_BOK_AvailableResourceCombinationID == Parameter.NewCombinationID);

            bool _isSameAppointmentType = newSlot.TaskTemplate_RefID == appointment.InstantiatedFrom_TaskTemplate_RefID;

            var paramDevice = new List<P_L5BTS_STI_1331_Device>();
            foreach (var instance in selectedCombination.Devices)
            {
                var _assignemtID = Guid.Empty;
                if (_isSameAppointmentType)
                {
                    var persistedInstance = appointment.Devices.SingleOrDefault(s => s.PPS_DEV_Device_Instance_RefID == instance.PPS_DEV_Device_Instance_RefID);
                    if (persistedInstance != null)
                    {
                        _assignemtID = persistedInstance.PPS_TSK_Task_DeviceBookingID;
                    }
                }
                paramDevice.Add(new P_L5BTS_STI_1331_Device()
                {
                    PPS_DEV_Device_Instance_RefID = instance.PPS_DEV_Device_Instance_RefID,
                    PPS_TSK_Task_DeviceBookingID = _assignemtID
                });
            }

            var paramStaff = new List<P_L5BTS_STI_1331_Employee>();
            foreach (var staffCombo in selectedCombination.Staff)
            {
                var _assignemtID = Guid.Empty;
                if(_isSameAppointmentType)
                {
                    var persistedStaff = appointment.Staff.SingleOrDefault(s => s.CreatedFrom_TaskTemplate_RequiredStaff_RefID == staffCombo.CreatedFor_TaskTemplateRequiredStaff_RefID);
                    if(persistedStaff != null)
                    {
                        _assignemtID = persistedStaff.PPS_TSK_Task_StaffBookingsID;
                    }
                }

                paramStaff.Add(new P_L5BTS_STI_1331_Employee()
                {
                    CMN_BPT_EMP_Employee_RefID = staffCombo.CMN_BPT_EMP_Employee_RefID,
                    CreatedFrom_TaskTemplate_RequiredStaff_RefID = staffCombo.CreatedFor_TaskTemplateRequiredStaff_RefID,
                    PPS_TSK_Task_StaffBookingsID = _assignemtID
                });
            }

            P_L5BTS_STI_1331_Patient patientInfo = new P_L5BTS_STI_1331_Patient();
            patientInfo.Patient_RefID = Parameter.PatientID;
            P_L5BTS_STI_1331 param = new P_L5BTS_STI_1331()
            {
                Patient = patientInfo,
                PPS_TSK_TaskID = Parameter.AppointmentID,
                Office = new P_L5BTS_STI_1331_Office()
                {
                    CMN_STR_Office_RefID = newSlot.Office_RefID,
                    PPS_TSK_Task_OfficeBookingID = appointment.Offices.PPS_TSK_Task_OfficeBookingID
                },
                PlannedStartDate = newSlot.FreeInterval_Start,
                PlannedDuration_in_sec = (int)(newSlot.FreeInterval_End - newSlot.FreeInterval_Start).TotalSeconds,
                TaskTemplate_RefID = newSlot.TaskTemplate_RefID,
                Devices = paramDevice.ToArray(),
                Employee = paramStaff.ToArray()

            };

            var result = cls_Save_Task.Invoke(Connection, Transaction, param, securityTicket).Result;
            returnValue.Result.ID = result.ID;

            if (result.ReplacedPatient != null)
                returnValue.Result.ReplacedPatient = new L5S_CAfSCID_1705_ReplacedPatient()
                {
                    ID = result.ReplacedPatient.ID
                };

            newCombinationORM.IsAvailable = false;
            newCombinationORM.Save(Connection, Transaction);


			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5BTS_EA_2008 Invoke(string ConnectionString,P_L5BTS_EA_2008 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5BTS_EA_2008 Invoke(DbConnection Connection,P_L5BTS_EA_2008 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5BTS_EA_2008 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5BTS_EA_2008 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5BTS_EA_2008 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5BTS_EA_2008 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5BTS_EA_2008 functionReturn = new FR_L5BTS_EA_2008();
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

				throw new Exception("Exception occured in method cls_Edit_Appointment",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5BTS_EA_2008 : FR_Base
	{
		public L5BTS_EA_2008 Result	{ get; set; }

		public FR_L5BTS_EA_2008() : base() {}

		public FR_L5BTS_EA_2008(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5BTS_EA_2008 for attribute P_L5BTS_EA_2008
		[DataContract]
		public class P_L5BTS_EA_2008 
		{
			//Standard type parameters
			[DataMember]
			public Guid PatientID { get; set; } 
			[DataMember]
			public Guid AppointmentID { get; set; } 
			[DataMember]
			public Guid OldCombinationID { get; set; } 
			[DataMember]
			public Guid NewCombinationID { get; set; } 

		}
		#endregion
		#region SClass L5BTS_EA_2008 for attribute L5BTS_EA_2008
		[DataContract]
		public class L5BTS_EA_2008 
		{
			[DataMember]
			public L5S_CAfSCID_1705_ReplacedPatient ReplacedPatient { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid ID { get; set; } 

		}
		#endregion
		#region SClass L5S_CAfSCID_1705_ReplacedPatient for attribute ReplacedPatient
		[DataContract]
		public class L5S_CAfSCID_1705_ReplacedPatient 
		{
			//Standard type parameters
			[DataMember]
			public Guid ID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5BTS_EA_2008 cls_Edit_Appointment(,P_L5BTS_EA_2008 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5BTS_EA_2008 invocationResult = cls_Edit_Appointment.Invoke(connectionString,P_L5BTS_EA_2008 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_BookableTimeSlot.Complex.Manipulation.P_L5BTS_EA_2008();
parameter.PatientID = ...;
parameter.AppointmentID = ...;
parameter.OldCombinationID = ...;
parameter.NewCombinationID = ...;

*/
