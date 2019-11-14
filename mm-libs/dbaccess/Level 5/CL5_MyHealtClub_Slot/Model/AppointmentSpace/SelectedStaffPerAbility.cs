using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MHCWidget_Web.Models.Backoffice;
using CL5_MyHealtClub_Slot.Model.Emplyee;

namespace CL5_MyHealtClub_Slot.Model.AppointmentSpace
{
    public class SelectedStaffPerAbility
    {
        public List<Staff> Staff { get; set; }
        public int StillNeed { get; set; }

        public SelectedStaffPerAbility()
        {
            Staff = new List<Staff>();
            StillNeed = 1;
        }

        public void AddStaff(Staff staff)
        {
            Staff.Add(staff);
        }

        public void AddStaff(List<Staff> staff)
        {
            Staff.AddRange(staff);
        }

        public bool ContainsStaffID(Guid staffID)
        {
            return Staff.FirstOrDefault(s => s.ID == staffID) != null;
        }

        public List<Guid> GetStaffIDs()
        {
            return Staff.Select(s => s.ID).ToList();
        }
    }
}
