using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CL5_MyHealtClub_Slot.Model;
using CL5_MyHealthClub_BookableTimeSlot.Atomic.Retrieval;

namespace CL5_MyHealtClub_Slot.Utils
{
    public class CombinationUtils
    {
        public static bool CompareCombinations(ResourceCombination calculatedCombination, L5BTS_GBSfPID_1141_ResourceCombination persistedCombination)
        {
            var retVal = true;

            foreach (var calcCombinationStaff in calculatedCombination.StaffCombination.Data)
            {
                var persistedStaffComb = persistedCombination.Staff.SingleOrDefault(s => s.CMN_BPT_EMP_Employee_RefID == calcCombinationStaff.Staff.ID && s.CreatedFor_TaskTemplateRequiredStaff_RefID == calcCombinationStaff.ID);
                if (persistedStaffComb == null)
                {
                    retVal = false;
                    break;
                }
            }

            if (retVal && calculatedCombination.IsDeviceNeeded)
            {
                foreach (var calcCombinationDevice in calculatedCombination.DeviceInstancesCombination.Data)
                {
                    var persistedDeviceComb = persistedCombination.Devices.SingleOrDefault(s => s.PPS_DEV_Device_Instance_RefID == calcCombinationDevice.ID);
                    if (persistedDeviceComb == null)
                    {
                        retVal = false;
                        break;
                    }
                }
            }

            return retVal;
        }
    }
}
