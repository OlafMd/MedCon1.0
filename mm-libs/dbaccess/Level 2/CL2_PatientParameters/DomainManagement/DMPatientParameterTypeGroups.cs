using System;
using System.Collections.Generic;
using System.Linq;
using CSV2Core.SessionSecurity;
using System.Data.Common;
using System.ComponentModel;
using System.Reflection;
using DLCore_DBCommons.Utils;
using System.Runtime.Serialization;
using CL1_HEC;
namespace CL2_PatientParameters.DomainManagement
{
    [DataContract]
    public enum EPatientParameterTypeGroup
    {
        [EnumMember]
        [Description("myhealtclub.gpapp.group.heartrate")]
        HeartRate,
        [EnumMember]
        [Description("myhealtclub.gpapp.group.preasure")]
        Preasure,
        [EnumMember]
        [Description("myhealtclub.gpapp.group.temperature")]
        Temperature,
        [EnumMember]
        [Description("myhealtclub.gpapp.group.bmi")]
        BMI,
        [EnumMember]
        [Description("myhealtclub.gpapp.group.oxygen-saturation")]
        Oxygen_saturation,
        [EnumMember]
        [Description("myhealtclub.gpapp.group.respiration")]
        Respiration
    }

    internal class DMPatientParameterTypeGroups
    {
        public static String ResourceFilePath = "CL2_PatientParameters.DomainManagement.Resources.patient-parametertype-groups.xml";

         ///<summary>
        /// Get all Patient Parameter Types Group enum strings
        ///<summary>
        public static List<PredefinedPatientParameterTypeGroup> Get_PredefinedPatientParameterTypeGroup(DbConnection Connection, DbTransaction Transaction, SessionSecurityTicket securityTicket)
        {
            var enumValues = Enum.GetValues(typeof(EPatientParameterTypeGroup)).Cast<EPatientParameterTypeGroup>();

            var contactTypes = enumValues.Select(i=>
                new PredefinedPatientParameterTypeGroup(){ Type = i, GlobalPropertyMatchingID = GetEnumDescription(i)}).ToList();
         
            return contactTypes;
        }

        ///<summary>
        /// Get Patient Parameter Types Group  for current Tenant from DB or create it if there is no entry
        ///<summary>
        public static Guid Get_PatientParameterTypeGroup_for_GlobalPropertyMatchingID(DbConnection Connection, DbTransaction Transaction, String globalPropertyMatchingID, SessionSecurityTicket securityTicket)
        {
            var query = new ORM_HEC_Patient_ParameterType_Group.Query();
            query.GlobalPropertyMatchingID = globalPropertyMatchingID;
            query.IsDeleted = false;
            query.Tenant_RefID = securityTicket.TenantID;
            var result =ORM_HEC_Patient_ParameterType_Group.Query.Search(Connection, Transaction, query);

            if (result == null || result.Count() == 0)
            {
                return Save_PatientParameterTypeGroupForTenant(Connection, Transaction, globalPropertyMatchingID, securityTicket);
            }

            if (result.Count() == 1) { 
            
                return result.First().HEC_Patient_ParameterType_GroupID;
            }
            else
            {
                throw new Exception("Multiple PatientParameterTypeGroup with same \"type\" field are defined in the database!");
            }
        }

        ///<summary>
        /// Save Patient Parameter Types Group  for current Tenant (from SessionSecurityTicket)
        ///<summary>
        private static Guid Save_PatientParameterTypeGroupForTenant(DbConnection Connection, DbTransaction Transaction, String groupType, SessionSecurityTicket securityTicket)
        {
            var allContactTypes = EnumUtils.GetAllEnumTypeDescriptionPairs<EPatientParameterTypeGroup>();
            var enumType = allContactTypes[groupType];

            string description = GetEnumDescription(enumType);

            ORM_HEC_Patient_ParameterType_Group ORMPatientParameterTypeGroup = new ORM_HEC_Patient_ParameterType_Group();
            ORMPatientParameterTypeGroup.HEC_Patient_ParameterType_GroupID = Guid.NewGuid();
            ORMPatientParameterTypeGroup.GlobalPropertyMatchingID = description;
            ORMPatientParameterTypeGroup.Creation_Timestamp = DateTime.Now;
            ORMPatientParameterTypeGroup.Tenant_RefID = securityTicket.TenantID;
            ORMPatientParameterTypeGroup.Save(Connection, Transaction);

            return ORMPatientParameterTypeGroup.HEC_Patient_ParameterType_GroupID;
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

    public class PredefinedPatientParameterTypeGroup
    {
        public EPatientParameterTypeGroup Type { get; set; }
        public String GlobalPropertyMatchingID { get; set; } 
    
    }
    
}
