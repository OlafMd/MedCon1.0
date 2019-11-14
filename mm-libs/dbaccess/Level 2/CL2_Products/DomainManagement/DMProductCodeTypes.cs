using System;
using System.Collections.Generic;
using System.Linq;
using CSV2Core.SessionSecurity;
using System.Data.Common;
using System.ComponentModel;
using System.Reflection;
using DLCore_DBCommons.Utils;
using CL2_Language.Atomic.Retrieval;
using DLCore_DBCommons;
using System.Xml;
using CL1_CMN_PRO;

namespace CL2_Products.DomainManagement
{

    public enum EProductCodeType
    {
        [Description("product-code-type.EAN")]
        EAN
    }

    public class DMProductCodeTypes
    {
        public static String ResourceFilePath = "CL2_Products.DomainManagement.Resources.product-code-type.xml";

        ///<summary>
        /// Get all Product Code Types enum strings
        ///<summary>
        public static List<String> Get_PredefinedProductCodeTypes(DbConnection Connection, DbTransaction Transaction, SessionSecurityTicket securityTicket)
        {
            var enumValues = Enum.GetValues(typeof(EProductCodeType)).Cast<EProductCodeType>();

            var contactTypes = enumValues.Select(i=>GetEnumDescription(i)).ToList();
         
            return contactTypes;
        }

        ///<summary>
        /// Get Product Code Type for current Tenant from DB or create it if there is no entry
        ///<summary>
        public static Guid Get_ProductCodeType_ByGlobalMatchingID(DbConnection Connection, DbTransaction Transaction, EProductCodeType type, SessionSecurityTicket securityTicket)
        {
            string globalPropertyMatchingID = GetEnumDescription(type);

            var query = new ORM_CMN_PRO_ProductCode_Type.Query();
            query.GlobalPropertyMatchingID = globalPropertyMatchingID;
            query.IsDeleted = false;
            query.Tenant_RefID = securityTicket.TenantID;

            var result = ORM_CMN_PRO_ProductCode_Type.Query.Search(Connection, Transaction, query);

            if (result == null || result.Count() == 0)
            {
                return Save_ProductCodeTypeForTenant(Connection, Transaction, globalPropertyMatchingID, securityTicket);
            }

            if (result.Count() == 1) { 
            
                return result.First().CMN_PRO_ProductCode_TypeID;
            }
            else
            {
                throw new Exception("Multiple ComunicationContactTypes with same \"type\" field are defined in the database!");
            }
        }

        ///<summary>
        /// Save Product Code Type for current Tenant (from SessionSecurityTicket)
        ///<summary>
        private static Guid Save_ProductCodeTypeForTenant(DbConnection Connection, DbTransaction Transaction, String contactType, SessionSecurityTicket securityTicket)
        {
            var allProductCodeTypes = EnumUtils.GetAllEnumTypeDescriptionPairs<EProductCodeType>();
            var enumType = allProductCodeTypes[contactType];

            string globalPropertyMatchingID = GetEnumDescription(enumType);

            #region Dict_Label

            #region Get Languages

            P_L2LN_GALFTID_1530 param = new P_L2LN_GALFTID_1530();
            param.Tenant_RefID = securityTicket.TenantID;
            var DBLanguages = cls_Get_All_Languages_ForTenantID.Invoke(Connection, Transaction, param, securityTicket).Result;

            var languages = DBLanguages.Select(i => new ISOLanguage() { ISO = i.ISO_639_1, LanguageID = i.CMN_LanguageID }).ToList();

            #endregion

            Assembly asm = Assembly.GetExecutingAssembly();
            XmlDocument resource = new XmlDocument();
            XmlTextReader reader = new XmlTextReader(asm.GetManifestResourceStream(DMProductCodeTypes.ResourceFilePath));
            resource.Load(reader);

            var PCTEnums = DMProductCodeTypes.Get_PredefinedProductCodeTypes(Connection, Transaction, securityTicket);

            var dict = DBCommonsReader.Instance.GetDictObjectsFromResourceFile(PCTEnums, resource,
                ORM_CMN_PRO_ProductCode_Type.TableName, languages);

            #endregion

            ORM_CMN_PRO_ProductCode_Type ORMContactType = new ORM_CMN_PRO_ProductCode_Type();
            ORMContactType.CMN_PRO_ProductCode_TypeID = Guid.NewGuid();
            ORMContactType.GlobalPropertyMatchingID = globalPropertyMatchingID;
            ORMContactType.ProductCode_TypeName = dict[globalPropertyMatchingID].Contents.FirstOrDefault().Content;
            ORMContactType.Creation_Timestamp = DateTime.Now;
            ORMContactType.Tenant_RefID = securityTicket.TenantID;
            ORMContactType.Save(Connection, Transaction);

            return ORMContactType.CMN_PRO_ProductCode_TypeID;
        }

        public static string GetEnumDescription(Enum value)
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
}
