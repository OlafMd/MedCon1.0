using System;
using System.Collections.Generic;
using System.Linq;
using CSV2Core.SessionSecurity;
using System.Data.Common;
using System.ComponentModel;
using System.Reflection;
using DLCore_DBCommons.Utils;
using System.Runtime.Serialization;
using CL1_HEC_CMT;

namespace CL2_HECCommunityRole.DomainManagement
{
    [DataContract]
    public enum ECommunityRole {
        [EnumMember]
        [Description("community-role.contributor")]
        Contributor = 1,
        [EnumMember]
        [Description("community-role.consumer")]
        Consumer = 2,
        [EnumMember]
        [Description("community-role.administrator")] 
        Administrator = 3,
        [EnumMember]
        [Description("community-role.bureaucrat")]
        Bureaucrat = 4,
        [EnumMember]
        [Description("community-role.founder")]
        Founder = 5,
        [EnumMember]
        [Description("community-role.founder-init")]
        Founder_Init = 6
    }

    public class DMCommunityRoles
    {
        public static String ResourceFilePath = "CL2_HECCommunityRole.DomainManagement.Resources.community-roles.xml";

        ///<summary>
        /// Get all Comunication Contact Types enum strings
        ///<summary>
        public static List<PredefinedCommunityRole> Get_PredefinedComunactionContactTypes(DbConnection Connection, DbTransaction Transaction, SessionSecurityTicket securityTicket)
        {
            var enumValues = Enum.GetValues(typeof(ECommunityRole)).Cast<ECommunityRole>();

            var contactTypes = enumValues.Select(i=>
                new PredefinedCommunityRole() { Type = i, GlobalPropertyMatchingID = GetEnumDescription(i)}).ToList();
         
            return contactTypes;
        }

        ///<summary>
        /// Get Communication Contact Type for current Tenant from DB or create it if there is no entry
        ///<summary>
        public static Guid Get_CommunityRole_for_GlobalPropertyMatchingID(DbConnection Connection, DbTransaction Transaction, String globalPropertyMatchingID, Guid communityID, SessionSecurityTicket securityTicket)
        {
            var query = new ORM_HEC_CMT_OfferedRole.Query();
            query.GlobalPropertyMatchingID = globalPropertyMatchingID;
            query.IsDeleted = false;
            query.Tenant_RefID = securityTicket.TenantID;

            var result = ORM_HEC_CMT_OfferedRole.Query.Search(Connection, Transaction, query);

            if (result == null || result.Count() == 0)
            {
                return Save_CommunityRoleForTenant(Connection, Transaction, globalPropertyMatchingID, communityID, securityTicket);
            }

            if (result.Count() == 1) { 
            
                return result.First().HEC_CMT_OfferedRoleID;
            }
            else
            {
                throw new Exception("Multiple OfferedRole with same \"type\" field are defined in the database!");
            }
        }

        ///<summary>
        /// Save Communication Contact Type for current Tenant (from SessionSecurityTicket)
        ///<summary>
        private static Guid Save_CommunityRoleForTenant(DbConnection Connection, DbTransaction Transaction, String contactType, Guid communityID, SessionSecurityTicket securityTicket)
        {
            var allContactTypes = EnumUtils.GetAllEnumTypeDescriptionPairs<ECommunityRole>();
            var enumType = allContactTypes[contactType];

            string description = GetEnumDescription(enumType);


            ORM_HEC_CMT_OfferedRole role = new ORM_HEC_CMT_OfferedRole();
            role.HEC_CMT_OfferedRoleID = Guid.NewGuid();
            role.GlobalPropertyMatchingID = description;
            role.Creation_Timestamp = DateTime.Now;
            role.CommunityRoleITL = Guid.NewGuid().ToString();
            role.Community_RefID = communityID;
            role.Tenant_RefID = securityTicket.TenantID;

            role.Save(Connection, Transaction);

            return role.HEC_CMT_OfferedRoleID;
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

    public class PredefinedCommunityRole
    {
        public ECommunityRole Type { get; set; }
        public String GlobalPropertyMatchingID { get; set; }  
    }
}
