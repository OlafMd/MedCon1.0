using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CL5_MyHealtClub_Slot.Model;
using CL5_MyHealtClub_Slot.Model.Emplyee;
using CL5_MyHealtClub_Slot.Model.AppointmentSpace;
using MHCWidget_Web.Models.Device;

namespace MHCWidget_Web.Models.Backoffice
{
    public class Practice
    {
        public Guid ID { get; set; }
        public List<Availability> Availabilities { get; set; }
        public List<ExceptionTime> Exceptions { get; set; }
        public List<Staff> Staff { get; set; }
        public List<AppointmentType> AppointmentTypes { get; set; }
        public List<DeviceInstance> Devices { get; set; }

        public Practice()
        {
            Availabilities = new List<Availability>();
            Staff = new List<Staff>();
            Exceptions = new List<ExceptionTime>();
            AppointmentTypes = new List<AppointmentType>();
            Devices = new List<DeviceInstance>();
        }
    }
}