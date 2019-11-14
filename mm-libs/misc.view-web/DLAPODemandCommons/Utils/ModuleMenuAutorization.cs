using System;
using System.Collections.Generic;
using System.Linq;
using DLAPODemandCommons.Controls;

namespace DLAPODemandCommons.Utils
{
    public class ModuleMenuAutorization
    {
        public static bool IsModuleVisible(List<String> allAvailableRights)
        {
            var allUserRightsForCurrentApp = XMLModelReader.Instance.MenuModel.APOModuleMenuItems.Where(i=>!String.IsNullOrEmpty(i.Url) && i.Url!="#").SelectMany(i => i.UserRights);

            return allAvailableRights.Intersect(allUserRightsForCurrentApp).Any();
        }
    }
}
