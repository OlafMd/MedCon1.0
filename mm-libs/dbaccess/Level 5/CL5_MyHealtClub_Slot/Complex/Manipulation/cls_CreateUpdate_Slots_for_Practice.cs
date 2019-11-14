/* 
 * Generated on 17.09.2014 17:12:58
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
using DLCore_DBCommons.Utils;
using DLCore_DBCommons.MyHealthClub;
using CL5_MyHealtClub_Slot.Utils;
using CL5_MyHealthClub_TaskTemplate.Atomic.Retrieval;
using CL5_MyHealtClub_Slot.Model;
using MHCWidget_Web.Models.Backoffice;
using CL5_MyHealthClub_TimeAndException.Atomic.Retrieval;
using CL1_HEC;
using CL1_PPS_TSK;
using CL5_MyHealthClub_BookableTimeSlot.Atomic.Retrieval;
using CL5_MyHealthClub_BookableTimeSlot.Complex.Manipulation;
using System.Threading.Tasks;

namespace CL5_MyHealthClub_Slot.Complex.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_CreateUpdate_Slots_for_Practice.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_CreateUpdate_Slots_for_Practice
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_L5S_SUSfP_1708 Execute(DbConnection Connection, DbTransaction Transaction, P_L5S_SUSfP_1708 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            //Leave UserCode region to enable user code saving
            #region UserCode
            var returnValue = new FR_L5S_SUSfP_1708();

            //ucitati sve potrebne podatke
            L5ATW_NfTID_1148[] appointmnetTypesDB = null;
            L5TE_GNWTfOID_1506[] officeNonWorkingTimes = null;
            L5TE_GSHfOID_1540[] officeStandardHours = null;
            L5TE_GSAfT_1645[] allEmployeesDB = null;
            L5TE_GTEFAS_1440[] allStaffExceptions = null;
            L5TE_GDAfT_1844[] devices = null;
            ORM_HEC_Doctor[] hecDoctorsDB = null;
            ORM_HEC_Doctor_AssignableAppointmentType[] hecDoctor2ATDB = null;
            ORM_PPS_TSK_Task_Template_OrganizationalUnitAvailability[] ppsTaskTemplate2Office = null;
            L5BTS_GBSfPID_1141[] slotsAndCombinationForPractice = null;

            Parallel.Invoke(

                () =>
                {
                    appointmnetTypesDB = cls_Get_AppointmentTypeWeb_Name_for_TenantID.Invoke(Transaction.Connection.ConnectionString, securityTicket).Result;
                },

                () =>
                {
                    officeNonWorkingTimes = cls_Get_NonWorkingTimesforOfficeID.Invoke(Transaction.Connection.ConnectionString, new P_L5TE_GNWTfOID_1506() { OfficeID = Parameter.PracticeID }, securityTicket).Result;
                },

                () =>
                {
                    officeStandardHours = cls_Get_StandardHours_for_OfficeID.Invoke(Transaction.Connection.ConnectionString, new P_L5TE_GSHfOID_1540() { OfficeID = Parameter.PracticeID }, securityTicket).Result;
                }
                ,

                () =>
                {
                    allEmployeesDB = cls_Get_Staff_with_Availability_for_TenantID.Invoke(Transaction.Connection.ConnectionString, securityTicket).Result;
                },

                () =>
                {
                    allStaffExceptions = cls_Get_TimeExceptionsForAllStaff.Invoke(Transaction.Connection.ConnectionString, securityTicket).Result;
                },

                () =>
                {
                    devices = cls_Get_Devices_Availability_for_TenantID.Invoke(Transaction.Connection.ConnectionString, securityTicket).Result;
                },

                () =>
                {
                    hecDoctorsDB = ORM_HEC_Doctor.Query.Search(Transaction.Connection.ConnectionString, new ORM_HEC_Doctor.Query() { Tenant_RefID = securityTicket.TenantID, IsDeleted = false }).ToArray();
                },

                () =>
                {
                    hecDoctor2ATDB = ORM_HEC_Doctor_AssignableAppointmentType.Query.Search(Transaction.Connection.ConnectionString, new ORM_HEC_Doctor_AssignableAppointmentType.Query() { Tenant_RefID = securityTicket.TenantID, IsDeleted = false }).ToArray();
                },

                () =>
                {
                    ppsTaskTemplate2Office = ORM_PPS_TSK_Task_Template_OrganizationalUnitAvailability.Query.Search(Transaction.Connection.ConnectionString, new ORM_PPS_TSK_Task_Template_OrganizationalUnitAvailability.Query() { Tenant_RefID = securityTicket.TenantID, IsDeleted = false, CMN_STR_Office_RefID = Parameter.PracticeID }).ToArray();
                },

                () =>
                {
                    slotsAndCombinationForPractice = cls_Get_BookableSlots_for_PracticeID.Invoke(Transaction.Connection.ConnectionString, new P_L5BTS_GBSfPID_1141() { OfficeID = Parameter.PracticeID, AvaTypeMatchingID = EnumUtils.GetEnumDescription(AvailabilityType.WebBooking) }, securityTicket).Result;
                }
            );

            L5TE_GSAfT_1645[] employeesFromPracticeDB = allEmployeesDB.Where(e => e.Offices != null && e.Offices.FirstOrDefault(o => o.OfficeID == Parameter.PracticeID) != null).ToArray();
            

            //prepakuj podatke u zeljeni model
            var practice = ModelConvertor.ConvertPracticeDBData(Parameter.PracticeID, officeNonWorkingTimes, officeStandardHours, appointmnetTypesDB.Where(w => ppsTaskTemplate2Office.Select(s => s.PPS_TSK_Task_Template_RefID).Contains(w.PPS_TSK_Task_TemplateID)).ToArray());
            practice.Staff = ModelConvertor.ConvertStaffDBData(Parameter.PracticeID, employeesFromPracticeDB, hecDoctorsDB, hecDoctor2ATDB, allStaffExceptions);
            practice.Devices = ModelConvertor.ConvertDevice(devices.Where(d => d.CMN_STR_Office_RefID == Parameter.PracticeID).ToArray());

            foreach (var appointmentType in practice.AppointmentTypes)
            {
                var persistedSlotsForAT = slotsAndCombinationForPractice.Where(w => w.TaskTemplate_RefID == appointmentType.ID).ToArray();
                bool needDevices = appointmentType.RequiredDeviceTypes != null && appointmentType.RequiredDeviceTypes.Count > 0;

                //ucititati sve appointmente tog tipa u praksi
                var scheduledAppParam = new P_L5A_GAABDfObTfD_1915()
                {
                    FromDate = DateTime.Now.AddDays(-1),
                    OfficeID = Parameter.PracticeID,
                    TaskTemplateID = appointmentType.ID
                };
                var scheduledAppointmentsDB = cls_Get_AllAppointment_BaseData_for_Office_by_Type_from_Date.Invoke(Connection, Transaction, scheduledAppParam, securityTicket).Result;

                //ucitane appointmente prebaciti u zeljeni model
                var scheduledAppointments = ModelConvertor.ConvertAppointments(scheduledAppointmentsDB);

                var posibleResourceCombinations = new List<ResourceCombination>();

                //iskalkulisati sve moguce kombinacije osoblja za zelejni tip appointmenta
                var staffCombinations = StaffAvailabiltyCalculations.GetFilteredStaffForAppointmentTypeBySkills(practice.Staff, appointmentType);
                var weekFramesPerStaffCombination = new Dictionary<Guid, List<RangeIntersection>>();
                foreach (var comb in staffCombinations)
                    weekFramesPerStaffCombination.Add(comb.ID, StaffAvailabiltyCalculations.CalculateWeekAvailableFramesForStaffCombination(comb.Data, practice.Availabilities));


                //iskalkulisati sve moguce kombinacije osoblja za zelejni tip appointmenta
                if (needDevices)
                {
                    var deviceInstanceCombinations = DeviceAvailabilityCalculations.GetFilteredDeviceForAppointmentType(practice.Devices, appointmentType);
                    var weekFramesPerDeviceCombination = new Dictionary<Guid, List<RangeIntersection>>();
                    foreach (var comb in deviceInstanceCombinations)
                    {
                        var allAbilities = comb.Data.Select(s => s.Availabilities).ToList();
                        allAbilities.Add(practice.Availabilities);
                        weekFramesPerDeviceCombination.Add(comb.ID, StaffAvailabiltyCalculations.FindAllIntersections(allAbilities));
                    }

                    foreach (var deviceCombination in weekFramesPerDeviceCombination)
                    {
                        foreach (var staffCombination in weekFramesPerStaffCombination)
                        {
                            var allIntersects = new List<List<RangeIntersection>>();
                            allIntersects.Add(staffCombination.Value);
                            allIntersects.Add(deviceCombination.Value);
                            var resourceCombinationIntersections = StaffAvailabiltyCalculations.FindAllIntersections(allIntersects);
                            if (resourceCombinationIntersections.Count > 0)
                            {
                                posibleResourceCombinations.Add(new ResourceCombination()
                                {
                                    AppointmentTypeID = appointmentType.ID,
                                    OfficeID = Parameter.PracticeID,
                                    StaffCombination = staffCombinations.Single(s => s.ID == staffCombination.Key),
                                    DeviceInstancesCombination = deviceInstanceCombinations.Single(s => s.ID == deviceCombination.Key),
                                    TimeIntersections = resourceCombinationIntersections,
                                    IsDeviceNeeded = true
                                });
                            }
                        }
                    }
                }
                else
                {
                    foreach (var staffCombination in weekFramesPerStaffCombination)
                        posibleResourceCombinations.Add(new ResourceCombination()
                        {
                            AppointmentTypeID = appointmentType.ID,
                            OfficeID = Parameter.PracticeID,
                            StaffCombination = staffCombinations.Single(s => s.ID == staffCombination.Key),
                            TimeIntersections = staffCombination.Value
                        });
                }

                //pranaci validne slotove od postojecih
                List<TimeSlot> calculatedSlots = new List<TimeSlot>();

                foreach (var combination in posibleResourceCombinations)
                {
                    //slotovi za narednih 6 meseci u odnosu na nedeljne slotove - izuzeci

                    var combinationSlots = TimeRangeUtils.CalculateTimeFramesFromRanges(combination.TimeIntersections, appointmentType.DurationInSec);

                    var exceptions = combination.StaffCombination.Data.Select(select => select.Staff).SelectMany(c => c.Exceptions).ToList();
                    if (combination.IsDeviceNeeded)
                        exceptions.AddRange(combination.DeviceInstancesCombination.Data.SelectMany(s => s.Exceptions).ToList());
                    var makeSlotsForNext3Months = StaffAvailabiltyCalculations.MakeSlotsForPeriod(combinationSlots, exceptions, DateTime.Now, DateTime.Now.AddMonths(3));

                    var thisCombinationAppointments = scheduledAppointments.Where(w => w.StaffIDs.Intersect(combination.StaffCombination.Data.Select(s => s.Staff.ID)).Any()).ToList();
                    if (needDevices)
                        thisCombinationAppointments = thisCombinationAppointments.Where(w => w.DeviceInstanceIDs.Intersect(combination.DeviceInstancesCombination.Data.Select(s => s.DeviceId)).Any()).ToList();

                    foreach (var slot in makeSlotsForNext3Months)
                    {
                        if (!TimeRangeUtils.SlotOverlapingWithSlotArray(slot, calculatedSlots) && !TimeRangeUtils.SlotOverlapingWithAppontmentArray(slot, thisCombinationAppointments))
                        {
                            var slotMatch = calculatedSlots.FirstOrDefault(s => s.PeriodStart == slot.PeriodStart && s.PeriodEnd == slot.PeriodEnd);
                            if (slotMatch == null)
                            {
                                slot.ResourceCombination.Add(combination);
                                calculatedSlots.Add(slot);
                            }
                            else
                            {
                                slotMatch.ResourceCombination.Add(combination);
                            }
                        }
                    }
                }

                var updatedSlotIDs = new List<Guid>();
                var slotParam = new List<P_L5BTS_CSwRC_1156_Slot>();
                foreach (var slot in calculatedSlots)
                {
                    var persistedSlot = persistedSlotsForAT.FirstOrDefault(f => f.FreeInterval_Start == slot.PeriodStart && f.FreeInterval_End == slot.PeriodEnd);
                    if (persistedSlot != null)
                    {
                        updatedSlotIDs.Add(persistedSlot.PPS_TSK_BOK_BookableTimeSlotID);
                        var keepCombinationsIDs = new List<Guid>();

                        bool isWebBookable = true;
                        var combinationList = new List<P_L5BTS_CSwRC_1156_Slot_Combination>();
                        foreach (var slotCombination in slot.ResourceCombination)
                        {
                            // da li je vidljiv za web bookovanje
                            foreach (var staff in slotCombination.StaffCombination.Data)
                                if (isWebBookable)
                                    if (!StaffAvailabiltyCalculations.IsStaffWebBookableInThisTameRange(staff.Staff, slot))
                                        isWebBookable = false;


                            // proveri da li vec postoji takva kobinacija u bazi
                            bool thisCombinationMatchedWithSomePersisted = false;
                            foreach (var persistedCombination in persistedSlot.Combinations)
                            {
                                if (CombinationUtils.CompareCombinations(slotCombination, persistedCombination))
                                {
                                    thisCombinationMatchedWithSomePersisted = true;
                                    keepCombinationsIDs.Add(persistedCombination.PPS_TSK_BOK_AvailableResourceCombinationID);
                                    break;
                                }
                            }
                            if (thisCombinationMatchedWithSomePersisted)// ako postoji preskoci je
                                continue;


                            var staffList = new List<P_L5BTS_CSwRC_1156_Slot_Combination_Staff>();
                            var deviceInstanceList = new List<P_L5BTS_CSwRC_1156_Slot_Combination_DeviceInstance>();
                            foreach (var staff in slotCombination.StaffCombination.Data)
                            {
                                staffList.Add(new P_L5BTS_CSwRC_1156_Slot_Combination_Staff()
                                {
                                    CreatedFor_TaskTemplateRequiredStaff_RefID = staff.ID,
                                    StaffID = staff.Staff.ID
                                });
                                if (isWebBookable)
                                    if (!StaffAvailabiltyCalculations.IsStaffWebBookableInThisTameRange(staff.Staff, slot))
                                        isWebBookable = false;
                            }
                            if (slotCombination.IsDeviceNeeded)
                                foreach (var deviceInstance in slotCombination.DeviceInstancesCombination.Data)
                                {
                                    deviceInstanceList.Add(new P_L5BTS_CSwRC_1156_Slot_Combination_DeviceInstance()
                                    {
                                        DeviceInstanceID = deviceInstance.ID
                                    });
                                }

                            combinationList.Add(new P_L5BTS_CSwRC_1156_Slot_Combination()
                            {
                                DeviceInstance = deviceInstanceList.ToArray(),
                                Staff = staffList.ToArray()
                            });
                        }

                        if(combinationList.Count > 0 || ((persistedSlot.WebBookable != null) != isWebBookable))
                            slotParam.Add(new P_L5BTS_CSwRC_1156_Slot()
                            {
                                Combinations = combinationList.ToArray(),
                                End = slot.PeriodEnd,
                                Start = slot.PeriodStart,
                                SlotID = persistedSlot.PPS_TSK_BOK_BookableTimeSlotID,
                                IsWebBookable = isWebBookable,
                                CombinationForDelete = new P_L5BTS_CSwRC_1156_Slot_CombinationsForDelete()
                                {
                                    CombinationIDs = persistedSlot.Combinations.Select(s => s.PPS_TSK_BOK_AvailableResourceCombinationID).Except(keepCombinationsIDs).ToArray()
                                }
                            });
                    }
                    else
                    {
                        bool isWebBookable = true;
                        var combinationList = new List<P_L5BTS_CSwRC_1156_Slot_Combination>();
                        foreach (var slotCombination in slot.ResourceCombination)
                        {
                            var staffList = new List<P_L5BTS_CSwRC_1156_Slot_Combination_Staff>();
                            var deviceInstanceList = new List<P_L5BTS_CSwRC_1156_Slot_Combination_DeviceInstance>();
                            foreach (var staff in slotCombination.StaffCombination.Data)
                            {
                                staffList.Add(new P_L5BTS_CSwRC_1156_Slot_Combination_Staff()
                                {
                                    CreatedFor_TaskTemplateRequiredStaff_RefID = staff.ID,
                                    StaffID = staff.Staff.ID
                                });
                                if (isWebBookable)
                                    if (!StaffAvailabiltyCalculations.IsStaffWebBookableInThisTameRange(staff.Staff, slot))
                                        isWebBookable = false;
                            }
                            if (slotCombination.IsDeviceNeeded)
                                foreach (var deviceInstance in slotCombination.DeviceInstancesCombination.Data)
                                {
                                    deviceInstanceList.Add(new P_L5BTS_CSwRC_1156_Slot_Combination_DeviceInstance()
                                    {
                                        DeviceInstanceID = deviceInstance.ID
                                    });
                                }

                            combinationList.Add(new P_L5BTS_CSwRC_1156_Slot_Combination()
                            {
                                DeviceInstance = deviceInstanceList.ToArray(),
                                Staff = staffList.ToArray()
                            });
                        }

                        slotParam.Add(new P_L5BTS_CSwRC_1156_Slot()
                        {
                            Combinations = combinationList.ToArray(),
                            End = slot.PeriodEnd,
                            Start = slot.PeriodStart,
                            SlotID = Guid.NewGuid(),
                            IsWebBookable = isWebBookable
                        });
                    }




                }

                var createSlotBulkParam = new P_L5BTS_CSwRC_1156()
                {
                    AppointmentTypeID = appointmentType.ID,
                    OfficeID = Parameter.PracticeID,
                    Slots = slotParam.ToArray()
                };

                var persistedSlotForDeleteIDs = persistedSlotsForAT.Where(s => !updatedSlotIDs.Contains(s.PPS_TSK_BOK_BookableTimeSlotID)).Select(s => s.PPS_TSK_BOK_BookableTimeSlotID).ToArray();
                cls_Delete_Slots.Invoke(Connection, Transaction, new P_L5BTS_DS_1510() { SlotIDs = persistedSlotForDeleteIDs }, securityTicket);
                cls_Create_Slots_with_ResourceCombinations.Invoke(Connection, Transaction, createSlotBulkParam, securityTicket);
            }
            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_L5S_SUSfP_1708 Invoke(string ConnectionString, P_L5S_SUSfP_1708 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_L5S_SUSfP_1708 Invoke(DbConnection Connection, P_L5S_SUSfP_1708 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_L5S_SUSfP_1708 Invoke(DbConnection Connection, DbTransaction Transaction, P_L5S_SUSfP_1708 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_L5S_SUSfP_1708 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_L5S_SUSfP_1708 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_L5S_SUSfP_1708 functionReturn = new FR_L5S_SUSfP_1708();
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

                functionReturn = Execute(Connection, Transaction, Parameter, securityTicket);

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
                    if (cleanupTransaction == true && Transaction != null)
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

                throw new Exception("Exception occured in method cls_CreateUpdate_Slots_for_Practice", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Custom Return Type
    [Serializable]
    public class FR_L5S_SUSfP_1708 : FR_Base
    {
        public L5S_SUSfP_1708 Result { get; set; }

        public FR_L5S_SUSfP_1708() : base() { }

        public FR_L5S_SUSfP_1708(Exception ex) : base(ex) { }

    }
    #endregion

    #region Support Classes
    #region SClass P_L5S_SUSfP_1708 for attribute P_L5S_SUSfP_1708
    [DataContract]
    public class P_L5S_SUSfP_1708
    {
        //Standard type parameters
        [DataMember]
        public Guid PracticeID { get; set; }

    }
    #endregion
    #region SClass L5S_SUSfP_1708 for attribute L5S_SUSfP_1708
    [DataContract]
    public class L5S_SUSfP_1708
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
FR_L5S_SUSfP_1708 cls_CreateUpdate_Slots_for_Practice(,P_L5S_SUSfP_1708 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5S_SUSfP_1708 invocationResult = cls_CreateUpdate_Slots_for_Practice.Invoke(connectionString,P_L5S_SUSfP_1708 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_Slot.Complex.Manipulation.P_L5S_SUSfP_1708();
parameter.PracticeID = ...;

*/
