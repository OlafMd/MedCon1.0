using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MHCWidget_Web.Models.Backoffice;
using CL5_MyHealthClub_TaskTemplate.Atomic.Retrieval;
using CL5_MyHealtClub_Slot.Model;
using CL5_MyHealthClub_TimeAndException.Atomic.Retrieval;
using CL1_HEC;
using CL5_MyHealtClub_Slot.Model.Device;
using CL5_MyHealtClub_Slot.Model.Emplyee;
using CL5_MyHealtClub_Slot.Model.AppointmentSpace;
using MHCWidget_Web.Models.Device;
using DLCore_DBCommons.MyHealthClub;
using DLCore_DBCommons.Utils;

namespace CL5_MyHealtClub_Slot.Utils
{
    class ModelConvertor
    {
        public static Practice ConvertPracticeDBData(Guid officeID, L5TE_GNWTfOID_1506[] officeNonWorkTimes, L5TE_GSHfOID_1540[] officeStandardHours, L5ATW_NfTID_1148[] appointmentTypesDB)
        {
            var practice = new Practice();
            
            practice.Availabilities = ConvertPracticeAvailabilities(officeStandardHours);
            practice.Exceptions = ConvertPracticeExceptions(officeNonWorkTimes);
            practice.AppointmentTypes = ConvertAppointmentTypes(appointmentTypesDB);

            return practice;
        }

        public static List<Staff> ConvertStaffDBData(Guid officeID, L5TE_GSAfT_1645[] doctorsDB, ORM_HEC_Doctor[] hecDoctorsDB, ORM_HEC_Doctor_AssignableAppointmentType[] doc2AATypes, L5TE_GTEFAS_1440[] doctorsExceptions)
        {
            var retVal = new List<Staff>();
            foreach (var doc in doctorsDB)
            {
                List<Guid> appointmentType2DoctorIds = new List<Guid>();
                var doctorORM = hecDoctorsDB.SingleOrDefault(d => d.BusinessParticipant_RefID == doc.BusinessParticipantID);
                if (doctorORM != null)
                {
                    appointmentType2DoctorIds.AddRange(doc2AATypes.Where(d2a => d2a.Doctor_RefID == doctorORM.HEC_DoctorID).Select(s => s.TaskTemplate_RefID));
                }

                var exceptionsPerEmp = doctorsExceptions.SingleOrDefault(de => de.CMN_BPT_EMP_EmployeeID == doc.CMN_BPT_EMP_EmployeeID);
                retVal.Add(new Staff()
                {
                    ID = doc.CMN_BPT_EMP_EmployeeID,
                    PrimaryProsessionID = doc.Professions.FirstOrDefault(p => p.IsPrimary) == null ? Guid.Empty : doc.Professions.First(p => p.IsPrimary).Profession_RefID,
                    Skills = ConvertDoctorSkills(doc.Skills.Select(s => s.SkillID).ToList()),
                    Availabilities = ConvertDoctorAvailabilities(doc.Availability, officeID, true),
                    WebAvailabilities = ConvertDoctorAvailabilities(doc.Availability, officeID, false),
                    Exceptions = ConvertDoctorExceptions(exceptionsPerEmp == null ? null : exceptionsPerEmp.Events),
                    AvailableAppointmentTypeIds = appointmentType2DoctorIds,
                    IsAvailabeForWebBooking = doc.WebAvailability != null
                });
            }
            return retVal;
        }


        public static List<DeviceInstance> ConvertDevice(L5TE_GDAfT_1844[] deviceDataDB)
        {
            var retVal = new List<DeviceInstance>();
            foreach (var d in deviceDataDB)
                retVal.Add(new DeviceInstance()
                {
                    ID = d.PPS_DEV_Device_InstanceID,
                    DeviceId = d.Device_RefID,
                    Availabilities = ConvertDeviceAvailabilities(d.Availabilities.Where(a => !a.IsAvailabilityExclusionItem).ToArray()),
                    Exceptions = ConvertDeviceExceptions(d.Availabilities.Where(a => a.IsAvailabilityExclusionItem).ToArray())
                });

            return retVal;
        }

        public static List<Appointment> ConvertAppointments(L5A_GAABDfObTfD_1915[] appoinmentsDB)
        {
            var retVal = new List<Appointment>();
            foreach (var app in appoinmentsDB)
                retVal.Add(new Appointment()
                {
                    ID = app.PPS_TSK_TaskID,
                    StaffIDs = app.StaffIDList.Select(s => s.CMN_BPT_EMP_Employee_RefID).ToList(),
                    DeviceInstanceIDs = app.DeviceIDList.Select(s => s.PPS_DEV_Device_Instance_RefID).ToList(),
                    AppointmentStart = app.PlannedStartDate,
                    AppointmentEnd = app.PlannedStartDate.AddSeconds(int.Parse(app.PlannedDuration_in_sec))
                });

            return retVal;
        }

        private static List<Availability> ConvertPracticeAvailabilities(L5TE_GSHfOID_1540[] practiceAvaDB)
        {
            var retVal = new List<Availability>();

            foreach (var ava in practiceAvaDB)
            {
                var availability = new Availability();
                availability.ID = ava.TimeID;
                availability.PeriodStart = DateTime.MinValue.AddMinutes(ava.TimeFrom_InMinutes);
                availability.PeriodEnd = DateTime.MinValue.AddMinutes(ava.TimeTo_InMinutes);

                if (ava.IsMonday) availability.DayOfWeek = DayOfWeek.Monday;
                if (ava.IsTuesday) availability.DayOfWeek = DayOfWeek.Tuesday;
                if (ava.IsWednesday) availability.DayOfWeek = DayOfWeek.Wednesday;
                if (ava.IsThursday) availability.DayOfWeek = DayOfWeek.Thursday;
                if (ava.IsFriday) availability.DayOfWeek = DayOfWeek.Friday;

                retVal.Add(availability);
            }
            retVal = retVal.OrderBy(o => o.DayOfWeek).ToList();
            return retVal;
        }


        private static List<ExceptionTime> ConvertPracticeExceptions(L5TE_GNWTfOID_1506[] practiceExceptionDB)
        {
            var retVal = new List<ExceptionTime>();

            if(practiceExceptionDB != null)
                foreach (var exceptionDB in practiceExceptionDB)
                {
                    var exception = new ExceptionTime()
                    {
                        ID = exceptionDB.TimeID,
                        PeriodStart = exceptionDB.StartTime,
                        PeriodEnd = exceptionDB.EndTime
                    };

                    if (exceptionDB.IsDaily)
                    {
                        exception.Recurency = Recurency.Daily;
                    }
                    else if (exceptionDB.IsWeekly)
                    {
                        exception.Recurency = Recurency.Weekly;
                    }
                    else if (exceptionDB.IsMonthly)
                    {
                        exception.Recurency = Recurency.Monthly;
                    }
                    else if (exceptionDB.IsYearly)
                    {
                        exception.Recurency = Recurency.Yearly;
                    }

                    retVal.Add(exception);
                }
            return retVal;
        }

        private static List<Availability> ConvertDoctorAvailabilities(L5TE_GSAfT_1645_Availability[] doctorAvaDB, Guid officeID, bool webBookable)
        {
            var retVal = new List<Availability>();

            var doctorAvaDBforOffice = doctorAvaDB.Where(w => w.OfficeID_WhereHeIsAvailable == officeID).ToArray();
            if (webBookable)
                doctorAvaDBforOffice = doctorAvaDBforOffice.Where(w => w.GlobalPropertyMatchingID == EnumUtils.GetEnumDescription(AvailabilityType.WebBooking)).ToArray();
 
            foreach (var ava in doctorAvaDBforOffice)
            {
                var availability = new Availability();
                availability.ID = ava.CMN_BPT_BusinessParticipant_AvailabilityID;
                availability.PeriodStart = DateTime.MinValue.Add(ava.StartTime.TimeOfDay);
                availability.PeriodEnd = DateTime.MinValue.Add(ava.EndTime.TimeOfDay);

                if (ava.HasRepeatingOn_Mondays) availability.DayOfWeek = DayOfWeek.Monday;
                if (ava.HasRepeatingOn_Tuesdays) availability.DayOfWeek = DayOfWeek.Tuesday;
                if (ava.HasRepeatingOn_Wednesdays) availability.DayOfWeek = DayOfWeek.Wednesday;
                if (ava.HasRepeatingOn_Thursdays) availability.DayOfWeek = DayOfWeek.Thursday;
                if (ava.HasRepeatingOn_Fridays) availability.DayOfWeek = DayOfWeek.Friday;

                retVal.Add(availability);
            }
            retVal = retVal.OrderBy(o => o.DayOfWeek).ToList();
            return retVal;
        }

        private static List<Skill> ConvertDoctorSkills(List<Guid> skillIds)
        {
            List<Skill> retVal = new List<Skill>();

            if (skillIds != null)
            {
                foreach (var key in skillIds)
                    retVal.Add(new Skill()
                    {
                        ID = key
                    });
            }

            return retVal;
        }

        private static List<ExceptionTime> ConvertDoctorExceptions(L5TE_GTEFAS_1440_Events[] practiceExceptionDB)
        {
            var retVal = new List<ExceptionTime>();

            if(practiceExceptionDB != null)
                foreach (var exceptionDB in practiceExceptionDB)
                {
                    var exception = new ExceptionTime()
                    {
                        ID = exceptionDB.CMN_CAL_EventID,
                        PeriodStart = exceptionDB.StartTime,
                        PeriodEnd = exceptionDB.EndTime,
                    };

                    if (exceptionDB.IsDaily)
                    {
                        exception.Recurency = Recurency.Daily;
                    }
                    else if (exceptionDB.IsWeekly)
                    {
                        exception.Recurency = Recurency.Weekly;

                    }
                    else if (exceptionDB.IsMonthly)
                    {
                        exception.Recurency = Recurency.Monthly;
                    }
                    else if (exceptionDB.IsYearly)
                    {
                        exception.Recurency = Recurency.Yearly;
                    }

                    retVal.Add(exception);
                }
            return retVal;
        }

        private static List<Availability> ConvertDeviceAvailabilities(L5TE_GDAfT_1844_Availability[] deviceAvaDB)
        {
            var retVal = new List<Availability>();

            foreach (var ava in deviceAvaDB)
            {
                var availability = new Availability();
                availability.ID = ava.CMN_CAL_AVA_AvailabilityID;
                availability.PeriodStart = DateTime.MinValue.Add(ava.StartTime.TimeOfDay);
                availability.PeriodEnd = DateTime.MinValue.Add(ava.EndTime.TimeOfDay);

                if (ava.HasRepeatingOn_Mondays) availability.DayOfWeek = DayOfWeek.Monday;
                if (ava.HasRepeatingOn_Tuesdays) availability.DayOfWeek = DayOfWeek.Tuesday;
                if (ava.HasRepeatingOn_Wednesdays) availability.DayOfWeek = DayOfWeek.Wednesday;
                if (ava.HasRepeatingOn_Thursdays) availability.DayOfWeek = DayOfWeek.Thursday;
                if (ava.HasRepeatingOn_Fridays) availability.DayOfWeek = DayOfWeek.Friday;

                retVal.Add(availability);
            }
            retVal = retVal.OrderBy(o => o.DayOfWeek).ToList();
            return retVal;
        }

        private static List<ExceptionTime> ConvertDeviceExceptions(L5TE_GDAfT_1844_Availability[] deviceAvaDB)
        {
            var retVal = new List<ExceptionTime>();

            if (deviceAvaDB != null)
                foreach (var exceptionDB in deviceAvaDB)
                {
                    var exception = new ExceptionTime()
                    {
                        ID = exceptionDB.CMN_CAL_AVA_AvailabilityID,
                        PeriodStart = exceptionDB.StartTime,
                        PeriodEnd = exceptionDB.EndTime,
                    };

                    if (exceptionDB.IsDaily)
                    {
                        exception.Recurency = Recurency.Daily;
                    }
                    else if (exceptionDB.IsWeekly)
                    {
                        exception.Recurency = Recurency.Weekly;

                    }
                    else if (exceptionDB.IsMonthly)
                    {
                        exception.Recurency = Recurency.Monthly;
                    }
                    else if (exceptionDB.IsYearly)
                    {
                        exception.Recurency = Recurency.Yearly;
                    }

                    retVal.Add(exception);
                }
            return retVal;
        }

        private static List<AppointmentType> ConvertAppointmentTypes(L5ATW_NfTID_1148[] appointmentTypesDB)
        {
            var retVal = new List<AppointmentType>();

            foreach (var type in appointmentTypesDB)
            {
                var requiredStaff = new List<ReqStaffByName>();
                
                foreach(var tRE in type.Required_Employee.Where(e => e.Required_Employee_RefID != Guid.Empty))
                    requiredStaff.Add(new ReqStaffByName()
                    {
                        ID = tRE.PPS_TSK_Task_RequiredStaffID,
                        StaffID = tRE.Required_Employee_RefID
                    });

                retVal.Add(new AppointmentType()
                {
                    ID = type.PPS_TSK_Task_TemplateID,
                    DurationInSec = (int)type.Duration_EstimatedMax_in_sec,
                    RequiredStaff = requiredStaff,
                    ReqStaffByAbillities = ConvertReqStaffByAbillity(type.Required_Employee),
                    RequiredDeviceTypes = ConvertReqDeviceTypes(type.Device)
                });
            }

            return retVal;
        }

        private static List<ReqStaffByAbillity> ConvertReqStaffByAbillity(L5ATW_NfTID_1148_staff[] reqs)
        {
            var retVal = new List<ReqStaffByAbillity>();

            foreach (var req in reqs.Where(r => r.Required_Employee_RefID == Guid.Empty).ToArray())
                retVal.Add(new ReqStaffByAbillity()
                {
                    ID = req.PPS_TSK_Task_RequiredStaffID,
                    ProfessionID = req.CMN_STR_Profession_RefID,
                    SkillIDs = req.Skills.Select(s => s.CMN_STR_Skill_RefID).ToList(),
                    Count = req.StaffQuantity
                });

            return retVal;
        }

        private static List<RequiredDeviceType> ConvertReqDeviceTypes(L5ATW_NfTID_1148_Device[] deviceTypes)
        {
            var retVal = new List<RequiredDeviceType>();

            foreach (var deviceType in deviceTypes)
                retVal.Add(new RequiredDeviceType()
                {
                    ID = deviceType.DEV_Device_RefID,
                    Count = deviceType.RequiredQuantity,    
                });

            return retVal;
        }
    }
}
