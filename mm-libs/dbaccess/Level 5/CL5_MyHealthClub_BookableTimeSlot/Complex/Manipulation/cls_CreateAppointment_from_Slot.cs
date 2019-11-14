/* 
 * Generated on 24.11.2014 17:05:46
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
using CL5_MyHealthClub_TimeAndException.Atomic.Retrieval;
using CL5_MyHealtClub_Slot.Model;
using CL5_MyHealtClub_Slot.Utils;
using CL1_HEC;
using System.Threading.Tasks;
using CL1_PPS_TSK_BOK;
using CL5_MyHealthClub_TaskTemplate.Atomic.Manipulation;
using CL3_Profession.Atomic.Retrieval;
using CL1_CMN_CAL_AVA;
using DLCore_DBCommons.Utils;
using DLCore_DBCommons.MyHealthClub;
using CL5_MyHealtClub_Slot.Model.Emplyee;

namespace CL5_MyHealthClub_BookableTimeSlot.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_CreateAppointment_from_Slot.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_CreateAppointment_from_Slot
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5S_CAfS_1141 Execute(DbConnection Connection,DbTransaction Transaction,P_L5S_CAfS_1141 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5S_CAfS_1141();

            returnValue.Result = new L5S_CAfS_1141();

            var slot = ORM_PPS_TSK_BOK_BookableTimeSlot.Query.Search(Connection, Transaction, new ORM_PPS_TSK_BOK_BookableTimeSlot.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                PPS_TSK_BOK_BookableTimeSlotID = Parameter.SlotID
            }).Single();

            var resourceCombinations = ORM_PPS_TSK_BOK_AvailableResourceCombination.Query.Search(Connection, Transaction, new ORM_PPS_TSK_BOK_AvailableResourceCombination.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                BookableTimeSlot_RefID = slot.PPS_TSK_BOK_BookableTimeSlotID,
                IsAvailable = true
            }).ToArray();

            Dictionary<Guid, List<ORM_PPS_TSK_BOK_StaffResource>> staffResourcePerCombination = new Dictionary<Guid, List<ORM_PPS_TSK_BOK_StaffResource>>();
            Dictionary<Guid, List<ORM_PPS_TSK_BOK_DeviceResource>> deviceResourcePerCombination = new Dictionary<Guid, List<ORM_PPS_TSK_BOK_DeviceResource>>();

            foreach (var resourceCombination in resourceCombinations)
            {
                var staffResources = ORM_PPS_TSK_BOK_StaffResource.Query.Search(Connection, Transaction, new ORM_PPS_TSK_BOK_StaffResource.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false,
                    AvailableResourceCombination_RefID = resourceCombination.PPS_TSK_BOK_AvailableResourceCombinationID
                }).ToList();
                staffResourcePerCombination.Add(resourceCombination.PPS_TSK_BOK_AvailableResourceCombinationID, staffResources);

                var deviceResources = ORM_PPS_TSK_BOK_DeviceResource.Query.Search(Connection, Transaction, new ORM_PPS_TSK_BOK_DeviceResource.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false,
                    AvailableResourceCombination_RefID = resourceCombination.PPS_TSK_BOK_AvailableResourceCombinationID
                }).ToList();
                deviceResourcePerCombination.Add(resourceCombination.PPS_TSK_BOK_AvailableResourceCombinationID, deviceResources);
            }

            L5TE_GSAfT_1645[] allEmployeesDB = cls_Get_Staff_with_Availability_for_TenantID.Invoke(Connection, Transaction, securityTicket).Result;
            ORM_HEC_Doctor[] hecDoctorsDB = ORM_HEC_Doctor.Query.Search(Connection, Transaction, new ORM_HEC_Doctor.Query() { Tenant_RefID = securityTicket.TenantID, IsDeleted = false }).ToArray();
            ORM_HEC_Doctor_AssignableAppointmentType[] hecDoctor2ATDB = ORM_HEC_Doctor_AssignableAppointmentType.Query.Search(Connection, Transaction, new ORM_HEC_Doctor_AssignableAppointmentType.Query() { Tenant_RefID = securityTicket.TenantID, IsDeleted = false }).ToArray();
            L5TE_GTEFAS_1440[] allStaffExceptions = cls_Get_TimeExceptionsForAllStaff.Invoke(Connection, Transaction, securityTicket).Result;
            L3P_GPfT_1537[] professionsForTenant = cls_Get_Professions_for_TenantID.Invoke(Connection, Transaction, securityTicket).Result;

            //Parallel.Invoke(

            //    () =>
            //    {
            //        allEmployeesDB = cls_Get_Staff_with_Availability_for_TenantID.Invoke(Transaction.Connection.ConnectionString, securityTicket).Result;
            //    },

            //    () =>
            //    {
            //        allStaffExceptions = cls_Get_TimeExceptionsForAllStaff.Invoke(Transaction.Connection.ConnectionString, securityTicket).Result;
            //    },

            //    () =>
            //    {
            //        hecDoctorsDB = ORM_HEC_Doctor.Query.Search(Transaction.Connection.ConnectionString, new ORM_HEC_Doctor.Query() { Tenant_RefID = securityTicket.TenantID, IsDeleted = false }).ToArray();
            //    },

            //    () =>
            //    {
            //        hecDoctor2ATDB = ORM_HEC_Doctor_AssignableAppointmentType.Query.Search(Transaction.Connection.ConnectionString, new ORM_HEC_Doctor_AssignableAppointmentType.Query() { Tenant_RefID = securityTicket.TenantID, IsDeleted = false }).ToArray();
            //    },

            //    () =>
            //    {
            //        professionsForTenant = cls_Get_Professions_for_TenantID.Invoke(Transaction.Connection.ConnectionString, securityTicket).Result;
            //    }
            //);

            var usedStaffIDs = new List<Guid>();
            foreach (var staffCombo in staffResourcePerCombination)
                foreach (var item in staffCombo.Value)
                    if (!usedStaffIDs.Contains(item.CMN_BPT_EMP_Employee_RefID))
                        usedStaffIDs.Add(item.CMN_BPT_EMP_Employee_RefID);

            L5TE_GSAfT_1645[] employeesFromPracticeDB = allEmployeesDB.Where(e => usedStaffIDs.Contains(e.CMN_BPT_EMP_EmployeeID)).ToArray();
            var staff = ModelConvertor.ConvertStaffDBData(slot.Office_RefID, employeesFromPracticeDB, hecDoctorsDB, hecDoctor2ATDB, allStaffExceptions, professionsForTenant);
            List<Staff> staffForThisAppointmentType = new List<Staff>(staff.Where(s => s.AvailableAppointmentTypeIds.Contains(slot.TaskTemplate_RefID)));
            TimeSlot ts = new TimeSlot() { PeriodStart = slot.FreeInterval_Start, PeriodEnd = slot.FreeInterval_End };

            Dictionary<Guid, bool> combination2webBookable = new Dictionary<Guid, bool>();

            foreach (var staffCombo in staffResourcePerCombination)
            {
                bool isComboWebBookable = true;
                foreach (var item in staffCombo.Value)
                {
                    var employee = staffForThisAppointmentType.Single(s => s.ID == item.CMN_BPT_EMP_Employee_RefID);
                    if (!StaffAvailabiltyCalculations.IsStaffWebBookableInThisTameRange(employee, ts))
                    {
                        isComboWebBookable = false;
                        break;
                    }
                }

                combination2webBookable.Add(staffCombo.Key, isComboWebBookable);
            }

            var firstWebBookableCombID = combination2webBookable.First(f => f.Value).Key;
            
            var paramDevice = new List<P_L5TA_STI_1037_Device>();
            foreach (var instanceID in deviceResourcePerCombination[firstWebBookableCombID].Select(s => s.PPS_DEV_Device_Instance_RefID))
                paramDevice.Add(new P_L5TA_STI_1037_Device(){ PPS_DEV_Device_Instance_RefID = instanceID});

            var paramStaff = new List<P_L5TA_STI_1037_Employee>();
            foreach (var staffCombo in staffResourcePerCombination[firstWebBookableCombID])
                paramStaff.Add(new P_L5TA_STI_1037_Employee()
                { 
                    CMN_BPT_EMP_Employee_RefID = staffCombo.CMN_BPT_EMP_Employee_RefID, 
                    CreatedFrom_TaskTemplate_RequiredStaff_RefID = staffCombo.CreatedFor_TaskTemplateRequiredStaff_RefID
                });

            P_L5TA_STI_1037 param = new P_L5TA_STI_1037()
            {
                Patient= new P_L5TA_STI_1037_Patient()
                {
                    Patient_RefID = Parameter.Patient_RefID
                },
                Office = new P_L5TA_STI_1037_Office()
                {
                    CMN_STR_Office_RefID = slot.Office_RefID
                },
                IsWebBooking = true,
                PlannedStartDate = slot.FreeInterval_Start,
                PlannedDuration_in_sec = (int)(slot.FreeInterval_End - slot.FreeInterval_Start).TotalSeconds,
                TaskTemplate_RefID = slot.TaskTemplate_RefID,
                Devices = paramDevice.ToArray(),
                Employee = paramStaff.ToArray()
                
            };

            var result = cls_Save_TaskInstance.Invoke(Connection, Transaction, param, securityTicket).Result;

            var selected = resourceCombinations.First(f => f.PPS_TSK_BOK_AvailableResourceCombinationID == firstWebBookableCombID);
            selected.IsAvailable = false;
            selected.Save(Connection, Transaction);


            if (combination2webBookable.Where(f => f.Value).Count() == 1) // ako je to jedina web bookable onda promeni tip
            {
                var standardAvailabilityType = ORM_CMN_CAL_AVA_Availability_Type.Query.Search(Connection, Transaction, new ORM_CMN_CAL_AVA_Availability_Type.Query()
                {
                    GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(AvailabilityType.Standard),
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).Single();

                var slot2ATs = ORM_PPS_TSK_BOK_BookableTimeSlots_2_AvailabilityType.Query.Search(Connection, Transaction, new ORM_PPS_TSK_BOK_BookableTimeSlots_2_AvailabilityType.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false,
                    PPS_TSK_BOK_BookableTimeSlot_RefID = slot.PPS_TSK_BOK_BookableTimeSlotID       
                }).Single();

                slot2ATs.CMN_CAL_AVA_Availability_TypeID = standardAvailabilityType.CMN_CAL_AVA_Availability_TypeID;
                slot2ATs.Save(Connection, Transaction);
            }

            returnValue.Result.ID = result.ID;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5S_CAfS_1141 Invoke(string ConnectionString,P_L5S_CAfS_1141 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5S_CAfS_1141 Invoke(DbConnection Connection,P_L5S_CAfS_1141 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5S_CAfS_1141 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5S_CAfS_1141 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5S_CAfS_1141 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5S_CAfS_1141 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5S_CAfS_1141 functionReturn = new FR_L5S_CAfS_1141();
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

				throw new Exception("Exception occured in method cls_CreateAppointment_from_Slot",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5S_CAfS_1141 : FR_Base
	{
		public L5S_CAfS_1141 Result	{ get; set; }

		public FR_L5S_CAfS_1141() : base() {}

		public FR_L5S_CAfS_1141(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5S_CAfS_1141 for attribute P_L5S_CAfS_1141
		[DataContract]
		public class P_L5S_CAfS_1141 
		{
			//Standard type parameters
			[DataMember]
			public Guid SlotID { get; set; } 
			[DataMember]
			public Guid Patient_RefID { get; set; } 

		}
		#endregion
		#region SClass L5S_CAfS_1141 for attribute L5S_CAfS_1141
		[DataContract]
		public class L5S_CAfS_1141 
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
FR_L5S_CAfS_1141 cls_CreateAppointment_from_Slot(,P_L5S_CAfS_1141 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5S_CAfS_1141 invocationResult = cls_CreateAppointment_from_Slot.Invoke(connectionString,P_L5S_CAfS_1141 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_BookableTimeSlot.Complex.Manipulation.P_L5S_CAfS_1141();
parameter.SlotID = ...;
parameter.Patient_RefID = ...;

*/
