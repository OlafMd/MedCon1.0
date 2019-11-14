using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CL5_MyHealtClub_Slot.Model;
using CL5_MyHealtClub_Slot.Model.Emplyee;
using MHCWidget_Web.Models.Backoffice;

namespace CL5_MyHealtClub_Slot.Model.Emplyee
{
    public class Staff
    {
        public Guid ID { get; set; }

        public bool IsAvailabeForWebBooking { get; set; }
        public Guid PrimaryProsessionID { get; set; }
        public List<Skill> Skills { get; set; }

        public List<Guid> AvailableAppointmentTypeIds { get; set; }

        public List<Availability> Availabilities { get; set; }
        public List<Availability> WebAvailabilities { get; set; }
        public List<ExceptionTime> Exceptions { get; set; }

        public Staff()
        {
            Skills = new List<Skill>();
            Availabilities = new List<Availability>();
            Exceptions = new List<ExceptionTime>();
            AvailableAppointmentTypeIds = new List<Guid>();
            WebAvailabilities = new List<Availability>();
        }
    }


}