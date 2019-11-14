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
using CL2_PatientParameters;
using CL2_Contact;
namespace CL2_PatientParameters.DomainManagement
{
    [DataContract]
    public enum EPatientParameterTypes
    {
        [EnumMember]
        [Description("myhealtclub.gpapp.pulse-volume")]
        Volume,
        [EnumMember]
        [Description("myhealtclub.gpapp.pulse-rhytm")]
        Rhytm,
        [EnumMember]
        [Description("myhealtclub.gpapp.pulse-frequency")]
        Frequency,
        [EnumMember]
        [Description("myhealtclub.gpapp.preasure-sys")]
        Systolic,
        [EnumMember]
        [Description("myhealtclub.gpapp.preasure-dia")]
        Diastolic,
        [EnumMember]
        [Description("myhealtclub.gpapp.body-temp")]
        Temperature,
        [EnumMember]
        [Description("myhealtclub.gpapp.bmi-height")]
        Height,
        [EnumMember]
        [Description("myhealtclub.gpapp.bmi-weight")]
        Weight,
        [EnumMember]
        [Description("myhealtclub.gpapp.oxygen-saturation")]
        Saturation,
        [EnumMember]
        [Description("myhealtclub.gpapp.respiration")]
        Respiration
    }

    internal class DMPatientParameterTypes
    {
        public static String ResourceFilePath = "CL2_PatientParameters.DomainManagement.Resources.patient-parametertype.xml";

        ///<summary>
        /// Get all Patient Parameter Types enum strings
        ///<summary>
        public static List<PredefinedPatientParameterTypes> Get_PredefinedPatientParameterTypes(DbConnection Connection, DbTransaction Transaction, SessionSecurityTicket securityTicket)
        {
            var enumValues = Enum.GetValues(typeof(EPatientParameterTypes)).Cast<EPatientParameterTypes>();

            var contactTypes = enumValues.Select(i =>
                new PredefinedPatientParameterTypes() { Type = i, GlobalPropertyMatchingID = GetEnumDescription(i) }).ToList();

            return contactTypes;
        }

        ///<summary>
        /// Get Patient Parameter Types for current Tenant from DB or create it if there is no entry
        ///<summary>
        public static Guid Get_PatientParameterTypes_for_GlobalPropertyMatchingID(DbConnection Connection, DbTransaction Transaction, String globalPropertyMatchingID, SessionSecurityTicket securityTicket)
        {
            var query = new ORM_HEC_Patient_ParameterType.Query();
            query.GlobalPropertyMatchingID = globalPropertyMatchingID;
            query.IsDeleted = false;
            query.Tenant_RefID = securityTicket.TenantID;
            var result = ORM_HEC_Patient_ParameterType.Query.Search(Connection, Transaction, query);

            if (result == null || result.Count() == 0)
            {
                return Save_PatientParameterTypesForTenant(Connection, Transaction, globalPropertyMatchingID, securityTicket);
            }

            if (result.Count() == 1)
            {

                return result.First().HEC_Patient_ParameterTypeID;
            }
            else
            {
                throw new Exception("Multiple PatientParameterType with same \"type\" field are defined in the database!");
            }
        }

        ///<summary>
        /// Save Patient Parameter Types for current Tenant (from SessionSecurityTicket)
        ///<summary>
        private static Guid Save_PatientParameterTypesForTenant(DbConnection Connection, DbTransaction Transaction, String Type, SessionSecurityTicket securityTicket)
        {
            var allContactTypes = EnumUtils.GetAllEnumTypeDescriptionPairs<EPatientParameterTypes>();
            var enumType = allContactTypes[Type];

            string description = GetEnumDescription(enumType);

            ORM_HEC_Patient_ParameterType ORMPatientParameterType = new ORM_HEC_Patient_ParameterType();
            ORMPatientParameterType.HEC_Patient_ParameterTypeID = Guid.NewGuid();
            ORMPatientParameterType.GlobalPropertyMatchingID = description;
            ORMPatientParameterType.Creation_Timestamp = DateTime.Now;
            ORMPatientParameterType.Tenant_RefID = securityTicket.TenantID;
            ORMPatientParameterType.Save(Connection, Transaction);

            Guid ParameterTypeGroupID = new Guid();
            ///<summary>
            /// Save Patient Parameter Types2Patient Parameter TypeGroups for current Tenant (from SessionSecurityTicket)
            ///<summary>
            switch (Type)
            {
                case "myhealtclub.gpapp.pulse-volume":
                    ParameterTypeGroupID = CL2_PatientParameters.DomainManagement.DMPatientParameterTypeGroups.Get_PatientParameterTypeGroup_for_GlobalPropertyMatchingID(Connection, Transaction, "myhealtclub.gpapp.group.heartrate", securityTicket);
                    break;
                case "myhealtclub.gpapp.pulse-rhytm":
                    ParameterTypeGroupID = CL2_PatientParameters.DomainManagement.DMPatientParameterTypeGroups.Get_PatientParameterTypeGroup_for_GlobalPropertyMatchingID(Connection, Transaction, "myhealtclub.gpapp.group.heartrate", securityTicket);
                    break;
                case "myhealtclub.gpapp.pulse-frequency":
                    ParameterTypeGroupID = CL2_PatientParameters.DomainManagement.DMPatientParameterTypeGroups.Get_PatientParameterTypeGroup_for_GlobalPropertyMatchingID(Connection, Transaction, "myhealtclub.gpapp.group.heartrate", securityTicket);
                    break;
                case "myhealtclub.gpapp.preasure-sys":
                    ParameterTypeGroupID = CL2_PatientParameters.DomainManagement.DMPatientParameterTypeGroups.Get_PatientParameterTypeGroup_for_GlobalPropertyMatchingID(Connection, Transaction, "myhealtclub.gpapp.group.preasure", securityTicket);
                    break;
                case "myhealtclub.gpapp.preasure-dia":
                    ParameterTypeGroupID = CL2_PatientParameters.DomainManagement.DMPatientParameterTypeGroups.Get_PatientParameterTypeGroup_for_GlobalPropertyMatchingID(Connection, Transaction, "myhealtclub.gpapp.group.preasure", securityTicket);
                    break;
                case "myhealtclub.gpapp.body-temp":
                    ParameterTypeGroupID = CL2_PatientParameters.DomainManagement.DMPatientParameterTypeGroups.Get_PatientParameterTypeGroup_for_GlobalPropertyMatchingID(Connection, Transaction, "myhealtclub.gpapp.group.temperature", securityTicket);
                    break;
                case "myhealtclub.gpapp.bmi-height":
                    ParameterTypeGroupID = CL2_PatientParameters.DomainManagement.DMPatientParameterTypeGroups.Get_PatientParameterTypeGroup_for_GlobalPropertyMatchingID(Connection, Transaction, "myhealtclub.gpapp.group.bmi", securityTicket);
                    break;
                case "myhealtclub.gpapp.bmi-weight":
                    ParameterTypeGroupID = CL2_PatientParameters.DomainManagement.DMPatientParameterTypeGroups.Get_PatientParameterTypeGroup_for_GlobalPropertyMatchingID(Connection, Transaction, "myhealtclub.gpapp.group.bmi", securityTicket);
                    break;
                case "myhealtclub.gpapp.oxygen-saturation":
                    ParameterTypeGroupID = CL2_PatientParameters.DomainManagement.DMPatientParameterTypeGroups.Get_PatientParameterTypeGroup_for_GlobalPropertyMatchingID(Connection, Transaction, "myhealtclub.gpapp.group.oxygen-saturation", securityTicket);
                    break;
                case "myhealtclub.gpapp.respiration":
                    ParameterTypeGroupID = CL2_PatientParameters.DomainManagement.DMPatientParameterTypeGroups.Get_PatientParameterTypeGroup_for_GlobalPropertyMatchingID(Connection, Transaction, "myhealtclub.gpapp.group.respiration", securityTicket);
                    break;
            }
            ORM_HEC_Patient_ParameterType_2_ParameterTypeGroup partype2pargroup = new ORM_HEC_Patient_ParameterType_2_ParameterTypeGroup();
            partype2pargroup.AssignmentID = Guid.NewGuid();
            partype2pargroup.Tenant_RefID = securityTicket.TenantID;
            partype2pargroup.HEC_Patient_ParameterType_Group_RefID = ParameterTypeGroupID;
            partype2pargroup.HEC_Patient_ParameterType_RefID = ORMPatientParameterType.HEC_Patient_ParameterTypeID;
            partype2pargroup.Save(Connection,Transaction);

            return ORMPatientParameterType.HEC_Patient_ParameterTypeID;
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

    public class PredefinedPatientParameterTypes
    {
        public EPatientParameterTypes Type { get; set; }
        public String GlobalPropertyMatchingID { get; set; }
        
    }
    
}
