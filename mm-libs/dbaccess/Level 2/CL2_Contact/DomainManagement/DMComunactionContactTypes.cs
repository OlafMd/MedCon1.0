using System;
using System.Collections.Generic;
using System.Linq;
using CSV2Core.SessionSecurity;
using System.Data.Common;
using CL1_CMN_PER;
using System.ComponentModel;
using System.Reflection;
using DLCore_DBCommons.Utils;
using System.Runtime.Serialization;

namespace CL2_Contact.DomainManagement
{
    [DataContract]
    public enum EComunactionContactType {
        [EnumMember]
        [Description("comunication-contact-type.phone")] 
        Phone,
        [EnumMember]
        [Description("comunication-contact-type.fax")]
        Fax,
        [EnumMember]
        [Description("comunication-contact-type.email")]
        Email,
        [EnumMember]
        [Description("comunication-contact-type.mobile")]
        Mobile,
        [EnumMember]
        [Description("comunication-contact-type.extension")]
        Extension,
        [EnumMember]
        [Description("comunication-contact-type.skype-name")]
        Skype,
        [EnumMember]
        [Description("comunication-contact-type.url")]
        URL
    }

    internal class DMComunactionContactTypes
    {
        public static String ResourceFilePath = "CL2_Contact.DomainManagement.Resources.comunication-contact-types.xml";

        ///<summary>
        /// Get all Comunication Contact Types enum strings
        ///<summary>
        public static List<PredefinedCommunactionContactType> Get_PredefinedComunactionContactTypes(DbConnection Connection, DbTransaction Transaction, SessionSecurityTicket securityTicket)
        {
            var enumValues = Enum.GetValues(typeof(EComunactionContactType)).Cast<EComunactionContactType>();

            var contactTypes = enumValues.Select(i=>
                new PredefinedCommunactionContactType(){ Type = i, GlobalPropertyMatchingID = GetEnumDescription(i)}).ToList();
         
            return contactTypes;
        }

        ///<summary>
        /// Get Communication Contact Type for current Tenant from DB or create it if there is no entry
        ///<summary>
        public static Guid Get_CommunactionContactType_for_GlobalPropertyMatchingID(DbConnection Connection, DbTransaction Transaction, String globalPropertyMatchingID, SessionSecurityTicket securityTicket)
        {
            var query = new ORM_CMN_PER_CommunicationContact_Type.Query();
            query.Type = globalPropertyMatchingID;
            query.IsDeleted = false;
            query.Tenant_RefID = securityTicket.TenantID;
            var result = ORM_CMN_PER_CommunicationContact_Type.Query.Search(Connection, Transaction, query);

            if (result == null || result.Count() == 0)
            {
                return Save_CommunactionContactTypeForTenant(Connection, Transaction, globalPropertyMatchingID, securityTicket);
            }

            if (result.Count() == 1) { 
            
                return result.First().CMN_PER_CommunicationContact_TypeID;
            }
            else
            {
                throw new Exception("Multiple ComunicationContactTypes with same \"type\" field are defined in the database!");
            }
        }

        ///<summary>
        /// Save Communication Contact Type for current Tenant (from SessionSecurityTicket)
        ///<summary>
        private static Guid Save_CommunactionContactTypeForTenant(DbConnection Connection, DbTransaction Transaction, String contactType, SessionSecurityTicket securityTicket)
        {
            var allContactTypes = EnumUtils.GetAllEnumTypeDescriptionPairs<EComunactionContactType>();
            var enumType = allContactTypes[contactType];

            string description = GetEnumDescription(enumType);

            ORM_CMN_PER_CommunicationContact_Type ORMContactType = new ORM_CMN_PER_CommunicationContact_Type();
            ORMContactType.CMN_PER_CommunicationContact_TypeID = Guid.NewGuid();
            ORMContactType.Type = description;
            ORMContactType.Creation_Timestamp = DateTime.Now;
            ORMContactType.Tenant_RefID = securityTicket.TenantID;
            ORMContactType.Save(Connection, Transaction);

            return ORMContactType.CMN_PER_CommunicationContact_TypeID;
        }

        private static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
    }

    public class PredefinedCommunactionContactType
    {
        public EComunactionContactType Type { get; set; }
        public String GlobalPropertyMatchingID { get; set; } 
    
    }
}
