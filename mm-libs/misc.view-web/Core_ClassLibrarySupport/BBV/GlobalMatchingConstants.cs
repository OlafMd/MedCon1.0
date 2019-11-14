using System;
using Core_ClassLibrarySupport.Apoteken;

namespace Core_ClassLibrarySupport.BBV
{
    public class STLD_Sudies
    {
        public static readonly string Sudies_GlobalProperty = "BBV.ParticipationPolicy";
    }

    public class STLD_DocumentSlot
    {
        public static readonly string Document_SlotGlobalProperty_FrontPage = "BBV.SlotGlobalProperty_FrontPage";
        public static readonly string Document_SlotGlobalProperty_BackPage = "BBV.SlotGlobalProperty_BackPage";
    }

    public class STLD_Salutation
    {
        public static readonly ItemObject[] salutationsItems = new ItemObject[] {  
                new ItemObject{ Text = "Herr", Value = Guid.Parse("CAFD3EA6-E0A2-4AB4-B7ED-9D4C406B8B71") }, 
                new ItemObject{ Text = "Frau", Value = Guid.Parse("032EB27F-DCAC-4E9B-A9B7-F60BCD93EC3C") }, 
            };
    }
}
