using System;

namespace Core_ClassLibrarySupport.Apoteken
{
    public class STLD_AffinityStatus
    {
         public static readonly ItemObject[] affinityItems = new ItemObject[] {  
                new ItemObject{ Text = "Kunde", Value = Guid.Parse("35D739B8-1CE6-4CC1-90D2-4BECD5A02A0A") }, 
                new ItemObject{ Text = "interessierter Nicht-Kunde", Value = Guid.Parse("801DAA9F-FF96-487F-BE54-A879F94110CC") },
                new ItemObject{ Text = "kein Kontakt gewünscht", Value = Guid.Parse("9867B434-9471-4D8C-B2DB-72219CAF650A") },
            };

    }

    public class STLD_PracticeType
    {
        public static readonly ItemObject[] typesItems = new ItemObject[] {   
                new ItemObject{ Text = "Augen-OP-Zentrum", Value = Guid.Parse("829CE981-2374-4D2A-BA20-F657BBA5F751") }, 
                new ItemObject{ Text = "Gemeinschaftspraxis", Value = Guid.Parse("A8FB8D0D-CF33-46A3-8ADC-3B0B91A1CF06") }, 
                new ItemObject{ Text = "Einzelpraxis", Value = Guid.Parse("9E85A42E-ACD6-4CA4-B35A-EF97763E62B2") }, 
                new ItemObject{ Text = "Klinik", Value = Guid.Parse("E7FDFC14-CCA7-4CE9-BD2B-485299F53085") }, 
                new ItemObject{ Text = "MVZ", Value = Guid.Parse("83422D9B-27BF-4540-8DFE-C737E9956A24") }, 
                new ItemObject{ Text = "Krankenhaus", Value = Guid.Parse("66842601-FE1C-4BB4-BE8E-51D0E8DD812C") }, 
                new ItemObject{ Text = "Augenklinik", Value = Guid.Parse("4649FFBD-ED43-4C19-B267-1BB9218D5EF9") }, 
                new ItemObject{ Text = "andere", Value = Guid.Parse("FC960760-A4F4-4A77-9419-490A09E6EF72") }, 
                new ItemObject{ Text = "Augentagesklinik", Value = Guid.Parse("91CB59C8-A6D0-49A3-9753-E6CAFE749158") },                
                new ItemObject{ Text = "Überörtliche Gemeinschaftspraxis", Value = Guid.Parse("5BAA9C1E-2949-471B-97EE-5C87C450C9C4") }, 
                new ItemObject{ Text = "Ärztehaus", Value = Guid.Parse("30B23A30-3B06-4834-A547-B866DDDF0E76") }, 
                new ItemObject{ Text = "Augenzentrum", Value = Guid.Parse("66F45A18-6D08-457E-9B19-51F87D4D6327") }, 
                new ItemObject{ Text = "Augenarztpraxis", Value = Guid.Parse("CBDAD2F7-1C27-4C70-9D15-DC6D5AA09E60") }, 
                new ItemObject{ Text = "Augenchirurgisches Zentrum", Value = Guid.Parse("{7C35CA4B-443D-4393-9CE0-2989AAF1690E}") },
                new ItemObject{ Text = "Augenlaserzentrum", Value = Guid.Parse("{E9AE2938-E512-43BF-95CC-ECC239C0BCE6}") },
                new ItemObject{ Text = "Gesundheitszentrum", Value = Guid.Parse("{1C9B941D-60A2-4068-BBEA-DC58B40F5685}") },
                new ItemObject{ Text = "Praxisklinik", Value = Guid.Parse("{CBF98AB4-D2FE-4082-A433-C24821F2B921}") },
            };
    }

    public class STLD_MedicalAssociation
    {
        public static readonly ItemObject[] associationItems = new ItemObject[] {   
                new ItemObject{ Text = "KV Westfalen-Lippe", Value = Guid.Parse("895BD5EA-BF03-47AD-A691-4CEDA3D5DF13") }, 
                new ItemObject{ Text = "KV Rheinland", Value = Guid.Parse("D8BF09AC-A47B-4200-926B-452CAC33C4BD") },
                new ItemObject{ Text = "KV Saarland", Value = Guid.Parse("51E2B613-672A-41FD-8AAE-83ABC9C8A12E") }, 
                new ItemObject{ Text = "KV Hessen", Value = Guid.Parse("63049290-AB3C-4DF6-A366-7DEFC74A5FCC") },
                new ItemObject{ Text = "KV Baden-Württemberg", Value = Guid.Parse("C6298A41-AD0B-4A64-A353-C4DC098C002D") }, 
                new ItemObject{ Text = "KV Bayern", Value = Guid.Parse("96448C4D-F60A-482C-B64C-727F41D294CB") },
                new ItemObject{ Text = "KV Bremen", Value = Guid.Parse("AD9847AE-4607-4705-9D7F-D98D80B7A47E") }, 
                new ItemObject{ Text = "KV Hamburg", Value = Guid.Parse("EACC4E12-10F7-46EA-A83D-05DB5A7E0F9F") }, 
                new ItemObject{ Text = "KV Niedersachsen", Value = Guid.Parse("8DDF8A81-3998-450C-8DD5-5A725621B56C") },
                new ItemObject{ Text = "KV Schleswig-Holstein", Value = Guid.Parse("B1085823-A890-479F-A2B2-5F673827F74C") }, 
                new ItemObject{ Text = "KV Mecklenburg-Vorpommern", Value = Guid.Parse("B1085823-A890-479F-A2B2-5F673827F74C") },
                new ItemObject{ Text = "KV Brandenburg", Value = Guid.Parse("F56A420D-E7BA-40AA-9BA1-7C5BFFB27636") }, 
                new ItemObject{ Text = "KV Berlin", Value = Guid.Parse("F3AC95E6-B11F-4634-A611-A62AD8C07C78") },
                new ItemObject{ Text = "KV Sachsen", Value = Guid.Parse("70435092-41C1-402A-ADF3-E85C4C67EB29") },
                new ItemObject{ Text = "KV Sachsen-Anhalt", Value = Guid.Parse("0F83AFA2-25AF-4132-9210-85D54E73065C") }, 
                new ItemObject{ Text = "KV Thüringen", Value = Guid.Parse("0F9B5200-D3E2-4393-B1D4-A94BCAED7A02") },
                new ItemObject{ Text = "KV Nordrhein-Westfalen", Value = Guid.Parse("B767952D-A609-4A13-BC12-8E5BB93C5C30") },
                new ItemObject{ Text = "KV Rheinland-Pfalz", Value = Guid.Parse("4526E585-D608-487A-A9EB-280B7BC5120D") },
            };
        
    }

    public class STLD_Salutation
    {
        public static readonly ItemObject[] salutationsItems = new ItemObject[] {  
                new ItemObject{ Text = "Herr", Value = Guid.Parse("CAFD3EA6-E0A2-4AB4-B7ED-9D4C406B8B71") }, 
                new ItemObject{ Text = "Frau", Value = Guid.Parse("032EB27F-DCAC-4E9B-A9B7-F60BCD93EC3C") }, 
                new ItemObject{ Text = "Firma", Value = Guid.Parse("DE860043-ECCD-4E2E-8C89-58AB2B0CB112") },
            };
    }

    public class STLD_Function
    {
        public static readonly ItemObject[] functionsItems = new ItemObject[] {  
                new ItemObject{ Text = "angestellter Arzt", Value = Guid.Parse("2789408B-89E6-419D-80B2-DF7CA7ECDBCA") }, 
                new ItemObject{ Text = "Praxisinhaber", Value = Guid.Parse("22C3AD3C-AC2F-40E8-94B3-24DB2621F44D") }, 
                new ItemObject{ Text = "Partner", Value = Guid.Parse("1E9FCB9C-4E87-4C01-855B-D9C7E6EB875E") },
            };
    }

    public class STLD_Title
    {
        public static readonly ItemObject[] titlesItems = new ItemObject[] {  
                new ItemObject{ Text = "Dr. med.", Value = Guid.Parse("9BEBD598-22A2-4007-913A-D928FAD03385") }, 
                new ItemObject{ Text = "Prof. Dr. med.", Value = Guid.Parse("70774451-52F5-42EA-9F95-7029A083015E") }, 
                new ItemObject{ Text = "PD Dr. med.", Value = Guid.Parse("662BF387-CC9F-4D1C-BFF2-50AF2FE97E43") }, 
                new ItemObject{ Text = "Dipl.-Med.", Value = Guid.Parse("096C4F4C-3E27-40E5-9E0B-69F6C8C6D24F") }, 
            };
    }

    public class STLD_ResponsibleSales
    {
        public static readonly ItemObject[] salesItems = new ItemObject[] {   
                new ItemObject{ Text = "Christian Dold", Value = Guid.Parse("8C61DF15-F157-4B1C-84FE-551739B1E584") }, 
                new ItemObject{ Text = "Ost", Value = Guid.Parse("08D7954A-EB37-482F-B5E6-E97FEDDA5F8A") }, 
                new ItemObject{ Text = "Nord-West", Value = Guid.Parse("B5BB4DC5-E87D-4818-9D76-C0424653B994") }, 
            };
    }

    public class ItemObject
    {
        public string Text { get; set; }
        public Guid Value { get; set; }
    }

    public static class ads
    {
    }
}
