using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CL5_MyHealtClub_Slot.Model;
using MHCWidget_Web.Models.Backoffice;

namespace MHCWidget_Web.Models.Device
{
    public class DeviceInstance
    {
        public Guid ID { get; set; }

        public Guid DeviceId { get; set; }

        public List<Availability> Availabilities { get; set; }
        public List<ExceptionTime> Exceptions { get; set; }

        public DeviceInstance()
        {
            Availabilities = new List<Availability>();
            Exceptions = new List<ExceptionTime>();
        }
    }


}