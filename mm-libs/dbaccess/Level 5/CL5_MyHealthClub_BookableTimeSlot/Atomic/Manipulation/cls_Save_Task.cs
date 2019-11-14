/* 
 * Generated on 17.01.2015 14:10:45
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
using CL1_CMN_CAL_AVA;
using DLCore_DBCommons.Utils;
using DLCore_DBCommons.MyHealthClub;
using CL1_PPS_TSK;
using CL1_HEC_APP;
using CL1_HEC_ACT;
using CL1_PPS_TSK_BOK;
using CL1_HEC;
using CL5_MyHealthClub_BookableTimeSlot.Atomic.Retrieval;
using CL5_MyHealthClub_TimeAndException.Atomic.Retrieval;
using CL3_Profession.Atomic.Retrieval;
using CL5_MyHealtClub_Slot.Utils;
using CL5_MyHealtClub_Slot.Model;

namespace CL5_MyHealthClub_BookableTimeSlot.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Task.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Task
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5BTS_STI_1331 Execute(DbConnection Connection,DbTransaction Transaction,P_L5BTS_STI_1331 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
            #region UserCode
            var returnValue = new FR_L5BTS_STI_1331()
            {
                Result = new L5BTS_STI_1331()
            };

            //Put your code here
            #region Save

            var webAvailabilityType = ORM_CMN_CAL_AVA_Availability_Type.Query.Search(Connection, Transaction, new ORM_CMN_CAL_AVA_Availability_Type.Query
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID,
                GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(AvailabilityType.WebBooking)
            }).First();


            var standardAvailabilityType = ORM_CMN_CAL_AVA_Availability_Type.Query.Search(Connection, Transaction, new ORM_CMN_CAL_AVA_Availability_Type.Query
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID,
                GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(AvailabilityType.Standard)
            }).First();

            if (Parameter.PPS_TSK_TaskID == Guid.Empty)
            {
                //=====================New Task=====================
                ORM_PPS_TSK_Task task = new ORM_PPS_TSK_Task();
                task.PPS_TSK_TaskID = Guid.NewGuid();
                var newTaskIdentifierNumber = ORM_PPS_TSK_Task.Query.Search(Connection, Transaction, new ORM_PPS_TSK_Task.Query
                {
                    Tenant_RefID = securityTicket.TenantID
                }).Count;

                task.TaskIdentifier = (++newTaskIdentifierNumber).ToString();
                task.DisplayName = "AT" + task.TaskIdentifier;
                task.InstantiatedFrom_TaskTemplate_RefID = Parameter.TaskTemplate_RefID;
                task.PlannedStartDate = Parameter.PlannedStartDate;
                task.PlannedDuration_in_sec = Parameter.PlannedDuration_in_sec;
                task.IsDeleted = false;
                task.Tenant_RefID = securityTicket.TenantID;
                //=====================Selected availability types=====================

                ORM_PPRS_TSK_Task_SelectedAvailabilityType selectedTypes = new ORM_PPRS_TSK_Task_SelectedAvailabilityType();
                selectedTypes.PPRS_TSK_Task_SelectedAvailabilityTypeID = Guid.NewGuid();
                selectedTypes.PPS_TSK_Task_RefID = task.PPS_TSK_TaskID;
                selectedTypes.CMN_CAL_AVA_Availability_Type_RefID = Parameter.IsWebBooking ? webAvailabilityType.CMN_CAL_AVA_Availability_TypeID : standardAvailabilityType.CMN_CAL_AVA_Availability_TypeID;
                selectedTypes.IsDeleted = false;
                selectedTypes.Tenant_RefID = securityTicket.TenantID;
                selectedTypes.Save(Connection, Transaction);
                //=====================New Employee=====================
                if (Parameter.Employee != null && Parameter.Employee.Count() > 0)
                {
                    foreach (var employeeParam in Parameter.Employee)
                    {
                        ORM_PPS_TSK_Task_StaffBooking staff = new ORM_PPS_TSK_Task_StaffBooking();
                        staff.PPS_TSK_Task_StaffBookingsID = Guid.NewGuid();
                        staff.PPS_TSK_Task_RefID = task.PPS_TSK_TaskID;
                        staff.CMN_BPT_EMP_Employee_RefID = employeeParam.CMN_BPT_EMP_Employee_RefID;
                        staff.CreatedFrom_TaskTemplate_RequiredStaff_RefID = employeeParam.CreatedFrom_TaskTemplate_RequiredStaff_RefID;
                        staff.IsDeleted = false;
                        staff.Tenant_RefID = securityTicket.TenantID;
                        staff.Save(Connection, Transaction);
                    }
                }
                //=====================New Device=====================
                if (Parameter.Devices != null && Parameter.Devices.Count() > 0)
                {
                    foreach (var deviceParam in Parameter.Devices)
                    {
                        ORM_PPS_TSK_Task_DeviceBooking device = new ORM_PPS_TSK_Task_DeviceBooking();
                        device.PPS_TSK_Task_DeviceBookingID = Guid.NewGuid();
                        device.PPS_TSK_Task_RefID = task.PPS_TSK_TaskID;
                        device.PPS_DEV_Device_Instance_RefID = deviceParam.PPS_DEV_Device_Instance_RefID;
                        device.IsDeleted = false;
                        device.Tenant_RefID = securityTicket.TenantID;
                        device.Save(Connection, Transaction);
                    }
                }
                //=====================New Office=====================
                if (Parameter.Office != null)
                {
                    ORM_PPS_TSK_Task_OfficeBooking office = new ORM_PPS_TSK_Task_OfficeBooking();
                    office.PPS_TSK_Task_OfficeBookingID = Guid.NewGuid();
                    office.PPS_TSK_Task_RefID = task.PPS_TSK_TaskID;
                    office.CMN_STR_Office_RefID = Parameter.Office.CMN_STR_Office_RefID;
                    office.IsDeleted = false;
                    office.Tenant_RefID = securityTicket.TenantID;
                    office.Save(Connection, Transaction);
                }
                //=====================New Patient=====================
                if (Parameter.Patient != null)
                {
                    ORM_HEC_APP_Appointment appointmnet = new ORM_HEC_APP_Appointment();
                    appointmnet.HEC_APP_AppointmentID = Guid.NewGuid();
                    appointmnet.Ext_PPS_TSK_Task_RefID = task.PPS_TSK_TaskID;
                    appointmnet.IsDeleted = false;
                    appointmnet.Tenant_RefID = securityTicket.TenantID;
                    appointmnet.Save(Connection, Transaction);

                    ORM_HEC_ACT_PlannedAction plannedAppointment = new ORM_HEC_ACT_PlannedAction();
                    plannedAppointment.HEC_ACT_PlannedActionID = Guid.NewGuid();
                    plannedAppointment.Appointment_RefID = appointmnet.HEC_APP_AppointmentID;
                    plannedAppointment.Patient_RefID = Parameter.Patient.Patient_RefID;
                    plannedAppointment.IsDeleted = false;
                    plannedAppointment.Tenant_RefID = securityTicket.TenantID;
                    plannedAppointment.Save(Connection, Transaction);
                }
                task.Save(Connection, Transaction);
                returnValue.Result.ID = task.PPS_TSK_TaskID;
            }
            #endregion
            //=====================Edit or Delete=====================
            else
            {
                var task = ORM_PPS_TSK_Task.Query.Search(Connection, Transaction, new ORM_PPS_TSK_Task.Query
                {
                    PPS_TSK_TaskID = Parameter.PPS_TSK_TaskID,
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                }).Single();
                #region Edit
                if (Parameter.IsDeleted == false)
                {
                    if (task.InstantiatedFrom_TaskTemplate_RefID != Parameter.TaskTemplate_RefID) //changed task template
                    {
                        //=====================First delete old employee and device=====================
                        var employeeForDelete = ORM_PPS_TSK_Task_StaffBooking.Query.SoftDelete(Connection, Transaction, new ORM_PPS_TSK_Task_StaffBooking.Query
                        {
                            PPS_TSK_Task_RefID = Parameter.PPS_TSK_TaskID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        });
                        var deviceForDelete = ORM_PPS_TSK_Task_DeviceBooking.Query.SoftDelete(Connection, Transaction, new ORM_PPS_TSK_Task_DeviceBooking.Query
                        {
                            PPS_TSK_Task_RefID = Parameter.PPS_TSK_TaskID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        });
                        task.InstantiatedFrom_TaskTemplate_RefID = Parameter.TaskTemplate_RefID;
                        task.PlannedDuration_in_sec = Parameter.PlannedDuration_in_sec;

                        //=====================New Employee=====================
                        if (Parameter.Employee != null && Parameter.Employee.Count() > 0)
                        {
                            foreach (var employeeParam in Parameter.Employee)
                            {
                                ORM_PPS_TSK_Task_StaffBooking staff = new ORM_PPS_TSK_Task_StaffBooking();
                                staff.PPS_TSK_Task_StaffBookingsID = Guid.NewGuid();
                                staff.PPS_TSK_Task_RefID = task.PPS_TSK_TaskID;
                                staff.CMN_BPT_EMP_Employee_RefID = employeeParam.CMN_BPT_EMP_Employee_RefID;
                                staff.CreatedFrom_TaskTemplate_RequiredStaff_RefID = employeeParam.CreatedFrom_TaskTemplate_RequiredStaff_RefID;
                                staff.IsDeleted = false;
                                staff.Tenant_RefID = securityTicket.TenantID;
                                staff.Save(Connection, Transaction);
                            }
                        }
                        //=====================New Device=====================
                        if (Parameter.Devices != null && Parameter.Devices.Count() > 0)
                        {
                            foreach (var deviceParam in Parameter.Devices)
                            {
                                ORM_PPS_TSK_Task_DeviceBooking device = new ORM_PPS_TSK_Task_DeviceBooking();
                                device.PPS_TSK_Task_DeviceBookingID = Guid.NewGuid();
                                device.PPS_TSK_Task_RefID = task.PPS_TSK_TaskID;
                                device.PPS_DEV_Device_Instance_RefID = deviceParam.PPS_DEV_Device_Instance_RefID;
                                device.IsDeleted = false;
                                device.Tenant_RefID = securityTicket.TenantID;
                                device.Save(Connection, Transaction);
                            }
                        }
                    }
                    else //only change existing employee and device
                    {
                        //=====================Edit employee=====================
                        if (Parameter.Employee != null)
                        {
                            foreach (var employeeParam in Parameter.Employee)
                            {
                                var existingEmployee = ORM_PPS_TSK_Task_StaffBooking.Query.Search(Connection, Transaction, new ORM_PPS_TSK_Task_StaffBooking.Query
                                {
                                    PPS_TSK_Task_StaffBookingsID = employeeParam.PPS_TSK_Task_StaffBookingsID,
                                    IsDeleted = false,
                                    Tenant_RefID = securityTicket.TenantID
                                }).SingleOrDefault();

                                if (existingEmployee == null) //if employee dont exist (if deleted from other page), create new
                                {
                                    ORM_PPS_TSK_Task_StaffBooking staff = new ORM_PPS_TSK_Task_StaffBooking();
                                    staff.PPS_TSK_Task_StaffBookingsID = Guid.NewGuid();
                                    staff.PPS_TSK_Task_RefID = task.PPS_TSK_TaskID;
                                    staff.CMN_BPT_EMP_Employee_RefID = employeeParam.CMN_BPT_EMP_Employee_RefID;
                                    staff.CreatedFrom_TaskTemplate_RequiredStaff_RefID = employeeParam.CreatedFrom_TaskTemplate_RequiredStaff_RefID;
                                    staff.IsDeleted = false;
                                    staff.Tenant_RefID = securityTicket.TenantID;
                                    staff.Save(Connection, Transaction);
                                }
                                else
                                {
                                    existingEmployee.CMN_BPT_EMP_Employee_RefID = employeeParam.CMN_BPT_EMP_Employee_RefID;
                                    existingEmployee.CreatedFrom_TaskTemplate_RequiredStaff_RefID = employeeParam.CreatedFrom_TaskTemplate_RequiredStaff_RefID;
                                    existingEmployee.Tenant_RefID = securityTicket.TenantID;
                                    existingEmployee.Save(Connection, Transaction);
                                }
                            }
                        }
                        //=====================Edit device=====================
                        if (Parameter.Devices != null)
                        {
                            foreach (var deviceParam in Parameter.Devices)
                            {
                                var existingDevice = ORM_PPS_TSK_Task_DeviceBooking.Query.Search(Connection, Transaction, new ORM_PPS_TSK_Task_DeviceBooking.Query
                                {
                                    PPS_TSK_Task_DeviceBookingID = deviceParam.PPS_TSK_Task_DeviceBookingID,
                                    IsDeleted = false,
                                    Tenant_RefID = securityTicket.TenantID
                                }).SingleOrDefault();
                                if (existingDevice == null)
                                {
                                    ORM_PPS_TSK_Task_DeviceBooking device = new ORM_PPS_TSK_Task_DeviceBooking();
                                    device.PPS_TSK_Task_DeviceBookingID = Guid.NewGuid();
                                    device.PPS_TSK_Task_RefID = task.PPS_TSK_TaskID;
                                    device.PPS_DEV_Device_Instance_RefID = deviceParam.PPS_DEV_Device_Instance_RefID;
                                    device.IsDeleted = false;
                                    device.Tenant_RefID = securityTicket.TenantID;
                                    device.Save(Connection, Transaction);
                                }
                                else
                                {
                                    existingDevice.PPS_DEV_Device_Instance_RefID = deviceParam.PPS_DEV_Device_Instance_RefID;
                                    existingDevice.Tenant_RefID = securityTicket.TenantID;
                                    existingDevice.Save(Connection, Transaction);
                                }
                            }
                        }
                    }
                    //=====================Edit other data=====================    
                    task.PlannedStartDate = Parameter.PlannedStartDate;

                    //=====================Edit selected availability types=====================
                    var existingAvailabilityType = ORM_PPRS_TSK_Task_SelectedAvailabilityType.Query.Search(Connection, Transaction, new ORM_PPRS_TSK_Task_SelectedAvailabilityType.Query
                    {
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID,
                        PPS_TSK_Task_RefID = task.PPS_TSK_TaskID
                    }).Single();

                    existingAvailabilityType.CMN_CAL_AVA_Availability_Type_RefID = Parameter.IsWebBooking ? webAvailabilityType.CMN_CAL_AVA_Availability_TypeID : standardAvailabilityType.CMN_CAL_AVA_Availability_TypeID;
                    existingAvailabilityType.Save(Connection, Transaction);

                    //=====================Edit Office=====================
                    if (Parameter.Office != null)
                    {
                        var existingOffice = ORM_PPS_TSK_Task_OfficeBooking.Query.Search(Connection, Transaction, new ORM_PPS_TSK_Task_OfficeBooking.Query
                        {
                            PPS_TSK_Task_OfficeBookingID = Parameter.Office.PPS_TSK_Task_OfficeBookingID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        }).Single();
                        existingOffice.CMN_STR_Office_RefID = Parameter.Office.CMN_STR_Office_RefID;
                        existingOffice.Tenant_RefID = securityTicket.TenantID;
                        existingOffice.Save(Connection, Transaction);
                    }
                    //=====================Edit Patient=====================
                    //when inter tenant communication is implemented, this part should be changed.
                    if (Parameter.Patient != null && Parameter.Patient.Patient_RefID != Guid.Empty)
                    {


                        var appointmentForEdit = ORM_HEC_APP_Appointment.Query.Search(Connection, Transaction, new ORM_HEC_APP_Appointment.Query
                        {
                            Ext_PPS_TSK_Task_RefID = task.PPS_TSK_TaskID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        }).Single();

                        var patientPlannedAppointmentForEdit = ORM_HEC_ACT_PlannedAction.Query.Search(Connection, Transaction, new ORM_HEC_ACT_PlannedAction.Query()
                        {
                            Appointment_RefID = appointmentForEdit.HEC_APP_AppointmentID,
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false
                        }).Single();

                        returnValue.Result.ReplacedPatient = new L5TA_STI_1037_ReplacedPatient()
                        {
                            ID = patientPlannedAppointmentForEdit.Patient_RefID
                        };

                        patientPlannedAppointmentForEdit.Patient_RefID = Parameter.Patient.Patient_RefID;
                        patientPlannedAppointmentForEdit.Save(Connection, Transaction);


                    }
                }
                #endregion
                #region Delete
                else
                {
                    //=====================Delete employee=====================
                    var employeeForDelete = ORM_PPS_TSK_Task_StaffBooking.Query.Search(Connection, Transaction, new ORM_PPS_TSK_Task_StaffBooking.Query
                    {
                        PPS_TSK_Task_RefID = Parameter.PPS_TSK_TaskID,
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID
                    }).ToArray();
                    foreach (var empForDel in employeeForDelete)
                    {
                        empForDel.IsDeleted = true;
                        empForDel.Save(Connection, Transaction);
                    }
                    //=====================Delete devices=====================
                    var deviceForDelete = ORM_PPS_TSK_Task_DeviceBooking.Query.Search(Connection, Transaction, new ORM_PPS_TSK_Task_DeviceBooking.Query
                    {
                        PPS_TSK_Task_RefID = Parameter.PPS_TSK_TaskID,
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID
                    }).ToArray();
                    foreach (var devForDel in deviceForDelete)
                    {
                        devForDel.IsDeleted = true;
                        devForDel.Save(Connection, Transaction);
                    }

                    //=====================Delete office=====================
                    var officeForDelete = ORM_PPS_TSK_Task_OfficeBooking.Query.Search(Connection, Transaction, new ORM_PPS_TSK_Task_OfficeBooking.Query
                    {
                        PPS_TSK_Task_RefID = Parameter.PPS_TSK_TaskID,
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID
                    }).Single();

                    //=====================Delete patient=====================
                    var appointmentForDelete = ORM_HEC_APP_Appointment.Query.Search(Connection, Transaction, new ORM_HEC_APP_Appointment.Query
                    {
                        Ext_PPS_TSK_Task_RefID = task.PPS_TSK_TaskID,
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID
                    }).Single();

                    var plannedAction = ORM_HEC_ACT_PlannedAction.Query.Search(Connection, Transaction, new ORM_HEC_ACT_PlannedAction.Query()
                    {
                        Tenant_RefID = securityTicket.TenantID,
                        Appointment_RefID = appointmentForDelete.HEC_APP_AppointmentID,
                    }).Single();

                    var patientPlannedAppointmentToDelete = ORM_HEC_ACT_PlannedAction.Query.Search(Connection, Transaction, new ORM_HEC_ACT_PlannedAction.Query()
                    {
                        Appointment_RefID = appointmentForDelete.HEC_APP_AppointmentID,
                        Patient_RefID = plannedAction.Patient_RefID,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).Single();

                    patientPlannedAppointmentToDelete.IsDeleted = true;
                    patientPlannedAppointmentToDelete.Save(Connection, Transaction);

                    appointmentForDelete.IsDeleted = true;
                    appointmentForDelete.Save(Connection, Transaction);

                    task.IsDeleted = true;

                    var firstBookedEmp = employeeForDelete;


                    var slot = ORM_PPS_TSK_BOK_BookableTimeSlot.Query.Search(Connection, Transaction, new ORM_PPS_TSK_BOK_BookableTimeSlot.Query()
                    {
                        Tenant_RefID = securityTicket.TenantID,
                        FreeInterval_Start = task.PlannedStartDate,
                        TaskTemplate_RefID = task.InstantiatedFrom_TaskTemplate_RefID,
                        Office_RefID = officeForDelete.CMN_STR_Office_RefID,
                        IsDeleted = false
                    }).Single();

                    var allCombs = cls_Get_Slot_NotAvaCombiantions_for_SlotID.Invoke(Connection, Transaction, new P_L5BTS_GSNACfSID_1456() { SlotID = slot.PPS_TSK_BOK_BookableTimeSlotID }, securityTicket).Result;

                    L5BTS_GSNACfSID_1456 selecetedComb = null;
                    foreach (var comb in allCombs)
                    {
                        if (!comb.Devices.Select(s => s.PPS_DEV_Device_Instance_RefID).Except(deviceForDelete.Select(s => s.PPS_DEV_Device_Instance_RefID)).Any()
                            &&
                            !comb.Staff.Select(s => s.CMN_BPT_EMP_Employee_RefID).Except(employeeForDelete.Select(s => s.CMN_BPT_EMP_Employee_RefID)).Any())
                            selecetedComb = comb;
                    }

                    if (selecetedComb != null)
                    {
                        var comb = ORM_PPS_TSK_BOK_AvailableResourceCombination.Query.Search(Connection, Transaction, new ORM_PPS_TSK_BOK_AvailableResourceCombination.Query()
                        {
                            Tenant_RefID = securityTicket.TenantID,
                            PPS_TSK_BOK_AvailableResourceCombinationID = selecetedComb.PPS_TSK_BOK_AvailableResourceCombinationID,

                        }).Single();

                        if (!comb.IsDeleted)
                        {

                            comb.IsAvailable = true;
                            comb.Save(Connection, Transaction);


                            L5TE_GSAfT_1645[] allEmployeesDB = cls_Get_Staff_with_Availability_for_TenantID.Invoke(Connection, Transaction, securityTicket).Result;
                            ORM_HEC_Doctor[] hecDoctorsDB = ORM_HEC_Doctor.Query.Search(Connection, Transaction, new ORM_HEC_Doctor.Query() { Tenant_RefID = securityTicket.TenantID, IsDeleted = false }).ToArray();
                            ORM_HEC_Doctor_AssignableAppointmentType[] hecDoctor2ATDB = ORM_HEC_Doctor_AssignableAppointmentType.Query.Search(Connection, Transaction, new ORM_HEC_Doctor_AssignableAppointmentType.Query() { Tenant_RefID = securityTicket.TenantID, IsDeleted = false }).ToArray();
                            L5TE_GTEFAS_1440[] allStaffExceptions = cls_Get_TimeExceptionsForAllStaff.Invoke(Connection, Transaction, securityTicket).Result;
                            L3P_GPfT_1537[] professionsForTenant = cls_Get_Professions_for_TenantID.Invoke(Connection, Transaction, securityTicket).Result;
                            L5TE_GSAfT_1645[] employeesFromPracticeDB = allEmployeesDB.Where(e => employeeForDelete.Select(s => s.CMN_BPT_EMP_Employee_RefID).Contains(e.CMN_BPT_EMP_EmployeeID)).ToArray();
                            var staff = ModelConvertor.ConvertStaffDBData(officeForDelete.CMN_STR_Office_RefID, employeesFromPracticeDB, hecDoctorsDB, hecDoctor2ATDB, allStaffExceptions, professionsForTenant);

                            TimeSlot ts = new TimeSlot() { PeriodStart = slot.FreeInterval_Start, PeriodEnd = slot.FreeInterval_End };
                            bool isComboWebBookable = true;
                            foreach (var item in selecetedComb.Staff)
                            {
                                var employee = staff.Single(s => s.ID == item.CMN_BPT_EMP_Employee_RefID);
                                if (!StaffAvailabiltyCalculations.IsStaffWebBookableInThisTameRange(employee, ts))
                                {
                                    isComboWebBookable = false;
                                    break;
                                }
                            }

                            if (isComboWebBookable)
                            {
                                var slot2ATs = ORM_PPS_TSK_BOK_BookableTimeSlots_2_AvailabilityType.Query.Search(Connection, Transaction, new ORM_PPS_TSK_BOK_BookableTimeSlots_2_AvailabilityType.Query()
                                {
                                    Tenant_RefID = securityTicket.TenantID,
                                    IsDeleted = false,
                                    PPS_TSK_BOK_BookableTimeSlot_RefID = slot.PPS_TSK_BOK_BookableTimeSlotID
                                }).Single();

                                if (slot2ATs.CMN_CAL_AVA_Availability_TypeID != webAvailabilityType.CMN_CAL_AVA_Availability_TypeID)
                                {
                                    slot2ATs.CMN_CAL_AVA_Availability_TypeID = webAvailabilityType.CMN_CAL_AVA_Availability_TypeID;
                                    slot2ATs.Save(Connection, Transaction);
                                }
                            }
                        }
                    }

                    officeForDelete.IsDeleted = true;
                    officeForDelete.Save(Connection, Transaction);

                }
                #endregion
                task.Save(Connection, Transaction);
                returnValue.Result.ID = task.PPS_TSK_TaskID;
            }

            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5BTS_STI_1331 Invoke(string ConnectionString,P_L5BTS_STI_1331 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5BTS_STI_1331 Invoke(DbConnection Connection,P_L5BTS_STI_1331 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5BTS_STI_1331 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5BTS_STI_1331 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5BTS_STI_1331 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5BTS_STI_1331 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5BTS_STI_1331 functionReturn = new FR_L5BTS_STI_1331();
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

				throw new Exception("Exception occured in method cls_Save_Task",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5BTS_STI_1331 : FR_Base
	{
		public L5BTS_STI_1331 Result	{ get; set; }

		public FR_L5BTS_STI_1331() : base() {}

		public FR_L5BTS_STI_1331(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5BTS_STI_1331 for attribute P_L5BTS_STI_1331
		[DataContract]
		public class P_L5BTS_STI_1331 
		{
			[DataMember]
			public P_L5BTS_STI_1331_Device[] Devices { get; set; }
			[DataMember]
			public P_L5BTS_STI_1331_Employee[] Employee { get; set; }
			[DataMember]
			public P_L5BTS_STI_1331_Office Office { get; set; }
			[DataMember]
			public P_L5BTS_STI_1331_Patient Patient { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid PPS_TSK_TaskID { get; set; } 
			[DataMember]
			public DateTime PlannedStartDate { get; set; } 
			[DataMember]
			public Guid TaskTemplate_RefID { get; set; } 
			[DataMember]
			public int PlannedDuration_in_sec { get; set; } 
			[DataMember]
			public bool IsWebBooking { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 

		}
		#endregion
		#region SClass P_L5BTS_STI_1331_Device for attribute Devices
		[DataContract]
		public class P_L5BTS_STI_1331_Device 
		{
			//Standard type parameters
			[DataMember]
			public Guid PPS_TSK_Task_DeviceBookingID { get; set; } 
			[DataMember]
			public Guid PPS_DEV_Device_Instance_RefID { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 

		}
		#endregion
		#region SClass P_L5BTS_STI_1331_Employee for attribute Employee
		[DataContract]
		public class P_L5BTS_STI_1331_Employee 
		{
			//Standard type parameters
			[DataMember]
			public Guid PPS_TSK_Task_StaffBookingsID { get; set; } 
			[DataMember]
			public Guid CMN_BPT_EMP_Employee_RefID { get; set; } 
			[DataMember]
			public Guid CreatedFrom_TaskTemplate_RequiredStaff_RefID { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 

		}
		#endregion
		#region SClass P_L5BTS_STI_1331_Office for attribute Office
		[DataContract]
		public class P_L5BTS_STI_1331_Office 
		{
			//Standard type parameters
			[DataMember]
			public Guid PPS_TSK_Task_OfficeBookingID { get; set; } 
			[DataMember]
			public Guid CMN_STR_Office_RefID { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 

		}
		#endregion
		#region SClass P_L5BTS_STI_1331_Patient for attribute Patient
		[DataContract]
		public class P_L5BTS_STI_1331_Patient 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_APP_AppointmentID { get; set; } 
			[DataMember]
			public Guid Patient_RefID { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 

		}
		#endregion
		#region SClass L5BTS_STI_1331 for attribute L5BTS_STI_1331
		[DataContract]
		public class L5BTS_STI_1331 
		{
			[DataMember]
			public L5TA_STI_1037_ReplacedPatient ReplacedPatient { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid ID { get; set; } 

		}
		#endregion
		#region SClass L5TA_STI_1037_ReplacedPatient for attribute ReplacedPatient
		[DataContract]
		public class L5TA_STI_1037_ReplacedPatient 
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
FR_L5BTS_STI_1331 cls_Save_Task(,P_L5BTS_STI_1331 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5BTS_STI_1331 invocationResult = cls_Save_Task.Invoke(connectionString,P_L5BTS_STI_1331 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_BookableTimeSlot.Atomic.Manipulation.P_L5BTS_STI_1331();
parameter.Devices = ...;
parameter.Employee = ...;
parameter.Office = ...;
parameter.Patient = ...;

parameter.PPS_TSK_TaskID = ...;
parameter.PlannedStartDate = ...;
parameter.TaskTemplate_RefID = ...;
parameter.PlannedDuration_in_sec = ...;
parameter.IsWebBooking = ...;
parameter.IsDeleted = ...;

*/
