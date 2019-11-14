using System;
using System.Collections.Generic;
using System.Linq;
using CSV2Core.SessionSecurity;
using System.Data.Common;
using System.ComponentModel;
using System.Reflection;
using DLCore_DBCommons.Utils;
using System.Runtime.Serialization;
using CL1_DOC;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL2_DocumentTamplates.DomainManagement
{
    [DataContract]
    public enum EDocumentTemplates {
        [EnumMember]
        [Description("document-templates.default-printing.prescription-note")]
        PrescriptionNote,
        [EnumMember]
        [Description("document-templates.default-printing.referral-summary")]
        ReferralSummary
    }

    internal class DMDocumentTemplates
    {
        public static String ResourceFilePath = "CL2_DocumentTemplates.DomainManagement.Resources.document-templates.xml";

        ///<summary>
        /// Get all Document Templates enum strings
        ///<summary>
        public static List<PredefinedDocumentTemplates> Get_PredefinedDocumentTemplates(DbConnection Connection, DbTransaction Transaction, SessionSecurityTicket securityTicket)
        {
            var enumValues = Enum.GetValues(typeof(EDocumentTemplates)).Cast<EDocumentTemplates>();

            var documentTemplates = enumValues.Select(i =>
                new PredefinedDocumentTemplates() { DocumentTemplates = i, GlobalPropertyMatchingID = GetEnumDescription(i) }).ToList();

            return documentTemplates;
        }

        ///<summary>
        /// Get Document Templates for current Tenant from DB or create it if there is no entry
        ///<summary>
        public static Guid Get_DocumentTemplates_for_GlobalPropertyMatchingID(DbConnection Connection, DbTransaction Transaction, String globalPropertyMatchingID, SessionSecurityTicket securityTicket)
        {
            var documentTemplate = ORM_DOC_DocumentTemplate.Query.Search(Connection, Transaction, new ORM_DOC_DocumentTemplate.Query
            {
                GlobalPropertyMatchingID = globalPropertyMatchingID,
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID
            });

            if (documentTemplate == null || documentTemplate.Count() == 0)
            {
                return Save_DocumentTemplateForTenant(Connection, Transaction, globalPropertyMatchingID, securityTicket);
            }

            if (documentTemplate.Count() == 1)
            {
                return documentTemplate.First().DOC_DocumentTemplateID;
            }
            else
            {
                throw new Exception("Multiple DocumentTemplates with same \"type\" field are defined in the database!");
            }
        }

        ///<summary>
        /// Save Communication Contact Type for current Tenant (from SessionSecurityTicket)
        ///<summary>
        private static Guid Save_DocumentTemplateForTenant(DbConnection Connection, DbTransaction Transaction, String type, SessionSecurityTicket securityTicket)
        {
            var allDocumentTemplates = EnumUtils.GetAllEnumTypeDescriptionPairs<EDocumentTemplates>();
            var enumType = allDocumentTemplates[type];

            string description = GetEnumDescription(enumType);

            ORM_DOC_DocumentTemplate documentTemplate = new ORM_DOC_DocumentTemplate();
            documentTemplate.DOC_DocumentTemplateID = Guid.NewGuid();
            documentTemplate.GlobalPropertyMatchingID = description;
            documentTemplate.Creation_Timestamp = DateTime.Now;
            documentTemplate.Tenant_RefID = securityTicket.TenantID;
            documentTemplate.TemplateContent = string.Empty;
            documentTemplate.Save(Connection, Transaction);

            return documentTemplate.DOC_DocumentTemplateID;
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

    public class PredefinedDocumentTemplates
    {
        public EDocumentTemplates DocumentTemplates { get; set; }
        public String GlobalPropertyMatchingID { get; set; } 
    
    }
}
