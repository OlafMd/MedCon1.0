using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MHCWidget_Web.Models.Backoffice;
using CL5_MyHealtClub_Slot.Model;
using MHCWidget_Web.Models.Device;
using CL5_MyHealtClub_Slot.Model.AppointmentSpace;
using CL5_MyHealtClub_Slot.Model.Device;

namespace CL5_MyHealtClub_Slot.Utils
{
    class DeviceAvailabilityCalculations
    {
        public static List<DeviceCombination> GetFilteredDeviceForAppointmentType(List<DeviceInstance> practiceDeviceInstances, AppointmentType appointmentType)
        {
            List<DeviceCombination> retVal = new List<DeviceCombination>(); ;

            Dictionary<Guid, List<DeviceInstance>> instancesPerReq = new Dictionary<Guid, List<DeviceInstance>>();

            foreach (var reqDeviceType in appointmentType.RequiredDeviceTypes)
            {
                var devicesByDeviceType = practiceDeviceInstances.Where(d => d.DeviceId == reqDeviceType.ID).ToList();

                if (devicesByDeviceType.Count < reqDeviceType.Count)
                    return retVal;

                instancesPerReq.Add(reqDeviceType.ID, devicesByDeviceType);
            }

            var combinationPerMappedReq = new Dictionary<Guid, List<DeviceInstance>>();
            var mappingKeysToRealRequs = new Dictionary<Guid, Guid>();

            foreach (var ipr in instancesPerReq)
            {
                for (int i = 0; i < appointmentType.RequiredDeviceTypes.First(r => r.ID == ipr.Key).Count; i++)
                {
                    var tempKey = Guid.NewGuid();
                    mappingKeysToRealRequs.Add(tempKey, ipr.Key);
                    combinationPerMappedReq.Add(tempKey, new List<DeviceInstance>(ipr.Value));
                }
            }

            TreeNode tree = new TreeNode(Guid.Empty, Guid.Empty);
            int reqSkillsCounter = 0;
            foreach (var key in combinationPerMappedReq.Keys)
            {
                var device2ReqList = combinationPerMappedReq[key];
                var leafs = TreeUtils.GetLeafs(tree);
                foreach (var leaf in leafs)
                    foreach (var device2Req in device2ReqList)
                        if (!TreeUtils.IsAncestorsContainsID(leaf, device2Req.ID)
                            && TreeUtils.GetNodeDepth(leaf) == reqSkillsCounter)
                            leaf.Add(new TreeNode(device2Req.ID, key));

                reqSkillsCounter++;
            }

            var instanceCombinationNodes = TreeUtils.GetBranchesCurrentSize(tree, combinationPerMappedReq.Keys.Count);
            if (instanceCombinationNodes.Count > 0)
            {
                foreach (var combination in instanceCombinationNodes)
                {
                    var instances = new List<DeviceInstance>();
                    foreach (var c in combination)
                        if (c.StaffReqID != Guid.Empty)
                            instances.Add(practiceDeviceInstances.First(f => f.ID == c.StaffID));

                    retVal.Add(new DeviceCombination() { Data = instances });
                }
            }

            return retVal;
        }
    }
}
