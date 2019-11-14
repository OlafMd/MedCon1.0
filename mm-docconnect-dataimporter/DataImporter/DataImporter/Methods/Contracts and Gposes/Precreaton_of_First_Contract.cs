using CL1_CMN_BPT;
using CL1_CMN;
using CSV2Core.SessionSecurity;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL1_CMN_PRO;
using CSV2Core_MySQL.Dictionaries.MultiTable;
using CL2_Language.Atomic.Retrieval;
using CL1_USR;
using CL1_CMN_CTR;
using CL1_HEC_CTR;
using CL1_HEC_DIA;
using CL1_HEC_HIS;
using CL1_HEC_CRT;
using CL1_HEC;

namespace DataImporter.Methods
{
    class Precreaton_of_First_Contract
    {

        public static void Create_Contract_With_Private_HIP(DbConnection Connection, DbTransaction Transaction, SessionSecurityTicket securityTicket)
        {


            Guid ContractId = Guid.NewGuid();
            var accountforTenant = ORM_USR_Account.Query.Search(Connection, Transaction, new ORM_USR_Account.Query()
            {
                IsDeleted = false,
                USR_AccountID = securityTicket.AccountID,
                Tenant_RefID = securityTicket.TenantID

            }).Single();

            var businessParticipantForTenant = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, new ORM_CMN_BPT_BusinessParticipant.Query()
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID,
                CMN_BPT_BusinessParticipantID = accountforTenant.BusinessParticipant_RefID
            }).Single();

            var contractRoles = ORM_CMN_CTR_Contract_Role.Query.Search(Connection, Transaction, new ORM_CMN_CTR_Contract_Role.Query()
            {
                RoleName = "Mediator",
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID
            }).SingleOrDefault();

            if (contractRoles == null)
            {
                contractRoles = new ORM_CMN_CTR_Contract_Role();
                contractRoles.CMN_CTR_Contract_RoleID = Guid.NewGuid();
                contractRoles.IsDeleted = false;
                contractRoles.Tenant_RefID = securityTicket.TenantID;
                contractRoles.Creation_Timestamp = DateTime.Now;
                contractRoles.RoleName = "Mediator";

                contractRoles.Save(Connection, Transaction);
            }

            var contractParties = new ORM_CMN_CTR_Contract_Party();
            contractParties.Tenant_RefID = securityTicket.TenantID;
            contractParties.IsDeleted = false;
            contractParties.Undersigning_BusinessParticipant_RefID = businessParticipantForTenant.CMN_BPT_BusinessParticipantID;
            contractParties.Creation_Timestamp = DateTime.Now;
            contractParties.CMN_CTR_Contract_PartyID = Guid.NewGuid();
            contractParties.Contract_RefID = ContractId;
            contractParties.Party_ContractRole_RefID = contractRoles.CMN_CTR_Contract_RoleID;

            contractParties.Save(Connection, Transaction);

            var contract = new ORM_CMN_CTR_Contract();
            contract.CMN_CTR_ContractID = ContractId;
            contract.IsDeleted = false;
            contract.Creation_Timestamp = DateTime.Now;
            contract.Tenant_RefID = securityTicket.TenantID;
            contract.ContractName = "mm House contract";
            contract.ValidFrom = new DateTime(2015, 1, 1);
            contract.Save(Connection, Transaction);

            var healthcarecontracts = new ORM_HEC_CRT_InsuranceToBrokerContract();
            healthcarecontracts.HEC_CRT_InsuranceToBrokerContractID = Guid.NewGuid();
            healthcarecontracts.IsDeleted = false;
            healthcarecontracts.Tenant_RefID = securityTicket.TenantID;
            healthcarecontracts.Ext_CMN_CTR_Contract_RefID = ContractId;
            healthcarecontracts.Creation_Timestamp = DateTime.Now;
            healthcarecontracts.Save(Connection, Transaction);


            var healthcareproductCovered = new ORM_HEC_CTR_InsuranceToBrokerContracts_CoveredHealthcareProduct();
            healthcareproductCovered.IsDeleted = false;
            healthcareproductCovered.Tenant_RefID = securityTicket.TenantID;
            healthcareproductCovered.Creation_Timestamp = DateTime.Now;
            healthcareproductCovered.HEC_CTR_InsuranceToBrokerContracts_CoveredHealthcareProductID = Guid.NewGuid();
            healthcareproductCovered.HealthcareProduct_RefID = Guid.NewGuid();
            healthcareproductCovered.InsuranceToBrokerContract_RefID = healthcarecontracts.HEC_CRT_InsuranceToBrokerContractID;
            healthcareproductCovered.Save(Connection, Transaction);


            var hecProducts = new ORM_HEC_Product();
            hecProducts.IsDeleted = false;
            hecProducts.Tenant_RefID = securityTicket.TenantID;
            hecProducts.HEC_ProductID = healthcareproductCovered.HealthcareProduct_RefID;
            hecProducts.Creation_Timestamp = DateTime.Now;
            hecProducts.Modification_Timestamp = DateTime.Now;
            hecProducts.Ext_PRO_Product_RefID = Guid.NewGuid();
            hecProducts.Save(Connection, Transaction);

            var DBLanguages = cls_Get_All_Languages.Invoke(Connection, Transaction, securityTicket).Result.ToList();
            Dict ProductNameDict = new Dict(ORM_CMN_PRO_Product.TableName);
            for (int i = 0; i < DBLanguages.Count; i++)
            {
                ProductNameDict.AddEntry(DBLanguages[i].CMN_LanguageID, "Aflibercept 2,0mg");
            }

            var products = new ORM_CMN_PRO_Product();
            products.CMN_PRO_ProductID = hecProducts.Ext_PRO_Product_RefID;
            products.IsDeleted = false;
            products.Tenant_RefID = securityTicket.TenantID;
            products.Creation_Timestamp = DateTime.Now;
            products.Product_Name = ProductNameDict;
            products.IsProducable_Internally = true;
            products.Product_Number = "Aflibercept";
            products.Save(Connection, Transaction);

            var healthcareproductCovered2 = new ORM_HEC_CTR_InsuranceToBrokerContracts_CoveredHealthcareProduct();
            healthcareproductCovered2.IsDeleted = false;
            healthcareproductCovered2.Tenant_RefID = securityTicket.TenantID;
            healthcareproductCovered2.Creation_Timestamp = DateTime.Now;
            healthcareproductCovered2.HEC_CTR_InsuranceToBrokerContracts_CoveredHealthcareProductID = Guid.NewGuid();
            healthcareproductCovered2.HealthcareProduct_RefID = Guid.NewGuid();
            healthcareproductCovered2.InsuranceToBrokerContract_RefID = healthcarecontracts.HEC_CRT_InsuranceToBrokerContractID;
            healthcareproductCovered2.Save(Connection, Transaction);

            var hecProducts2 = new ORM_HEC_Product();
            hecProducts2.IsDeleted = false;
            hecProducts2.Tenant_RefID = securityTicket.TenantID;
            hecProducts2.HEC_ProductID = healthcareproductCovered2.HealthcareProduct_RefID;
            hecProducts2.Creation_Timestamp = DateTime.Now;
            hecProducts2.Modification_Timestamp = DateTime.Now;
            hecProducts2.Ext_PRO_Product_RefID = Guid.NewGuid();
            hecProducts2.Save(Connection, Transaction);

            Dict ProductNameDict2 = new Dict(ORM_CMN_PRO_Product.TableName);
            for (int i = 0; i < DBLanguages.Count; i++)
            {
                ProductNameDict2.AddEntry(DBLanguages[i].CMN_LanguageID, "Bevacizumab 1,25mg");
            }


            var products2 = new ORM_CMN_PRO_Product();
            products2.CMN_PRO_ProductID = hecProducts2.Ext_PRO_Product_RefID;
            products2.IsDeleted = false;
            products2.Tenant_RefID = securityTicket.TenantID;
            products2.Creation_Timestamp = DateTime.Now;
            products2.Product_Name = ProductNameDict2;
            products2.IsProducable_Internally = true;
            products2.Product_Number = "Bevacizumab";
            products2.Save(Connection, Transaction);

            var healthcareproductCovered3 = new ORM_HEC_CTR_InsuranceToBrokerContracts_CoveredHealthcareProduct();
            healthcareproductCovered3.IsDeleted = false;
            healthcareproductCovered3.Tenant_RefID = securityTicket.TenantID;
            healthcareproductCovered3.Creation_Timestamp = DateTime.Now;
            healthcareproductCovered3.HEC_CTR_InsuranceToBrokerContracts_CoveredHealthcareProductID = Guid.NewGuid();
            healthcareproductCovered3.HealthcareProduct_RefID = Guid.NewGuid();
            healthcareproductCovered3.InsuranceToBrokerContract_RefID = healthcarecontracts.HEC_CRT_InsuranceToBrokerContractID;
            healthcareproductCovered3.Save(Connection, Transaction);

            var hecProducts3 = new ORM_HEC_Product();
            hecProducts3.IsDeleted = false;
            hecProducts3.Tenant_RefID = securityTicket.TenantID;
            hecProducts3.HEC_ProductID = healthcareproductCovered3.HealthcareProduct_RefID;
            hecProducts3.Creation_Timestamp = DateTime.Now;
            hecProducts3.Modification_Timestamp = DateTime.Now;
            hecProducts3.Ext_PRO_Product_RefID = Guid.NewGuid();
            hecProducts3.Save(Connection, Transaction);

            Dict ProductNameDict3 = new Dict(ORM_CMN_PRO_Product.TableName);
            for (int i = 0; i < DBLanguages.Count; i++)
            {
                ProductNameDict3.AddEntry(DBLanguages[i].CMN_LanguageID, "Bevacizumab 1,5mg");
            }

            var products3 = new ORM_CMN_PRO_Product();
            products3.CMN_PRO_ProductID = hecProducts3.Ext_PRO_Product_RefID;
            products3.IsDeleted = false;
            products3.Tenant_RefID = securityTicket.TenantID;
            products3.Creation_Timestamp = DateTime.Now;
            products3.Product_Name = ProductNameDict3;
            products3.IsProducable_Internally = true;
            products3.Product_Number = "Bevacizumab-1.5";
            products3.Save(Connection, Transaction);

            var healthcareproductCovered4 = new ORM_HEC_CTR_InsuranceToBrokerContracts_CoveredHealthcareProduct();
            healthcareproductCovered4.IsDeleted = false;
            healthcareproductCovered4.Tenant_RefID = securityTicket.TenantID;
            healthcareproductCovered4.Creation_Timestamp = DateTime.Now;
            healthcareproductCovered4.HEC_CTR_InsuranceToBrokerContracts_CoveredHealthcareProductID = Guid.NewGuid();
            healthcareproductCovered4.HealthcareProduct_RefID = Guid.NewGuid();
            healthcareproductCovered4.InsuranceToBrokerContract_RefID = healthcarecontracts.HEC_CRT_InsuranceToBrokerContractID;
            healthcareproductCovered4.Save(Connection, Transaction);

            var hecProducts4 = new ORM_HEC_Product();
            hecProducts4.IsDeleted = false;
            hecProducts4.Tenant_RefID = securityTicket.TenantID;
            hecProducts4.HEC_ProductID = healthcareproductCovered4.HealthcareProduct_RefID;
            hecProducts4.Creation_Timestamp = DateTime.Now;
            hecProducts4.Modification_Timestamp = DateTime.Now;
            hecProducts4.Ext_PRO_Product_RefID = Guid.NewGuid();
            hecProducts4.Save(Connection, Transaction);

            Dict ProductNameDict4 = new Dict(ORM_CMN_PRO_Product.TableName);
            for (int i = 0; i < DBLanguages.Count; i++)
            {
                ProductNameDict4.AddEntry(DBLanguages[i].CMN_LanguageID, "Eylea");
            }

            var products4 = new ORM_CMN_PRO_Product();
            products4.CMN_PRO_ProductID = hecProducts4.Ext_PRO_Product_RefID;
            products4.IsDeleted = false;
            products4.Tenant_RefID = securityTicket.TenantID;
            products4.Creation_Timestamp = DateTime.Now;
            products4.Product_Name = ProductNameDict4;
            products4.IsProducable_Internally = false;
            products4.Product_Number = "9299319";
            products4.Save(Connection, Transaction);

            var healthcareproductCovered5 = new ORM_HEC_CTR_InsuranceToBrokerContracts_CoveredHealthcareProduct();
            healthcareproductCovered5.IsDeleted = false;
            healthcareproductCovered5.Tenant_RefID = securityTicket.TenantID;
            healthcareproductCovered5.Creation_Timestamp = DateTime.Now;
            healthcareproductCovered5.HEC_CTR_InsuranceToBrokerContracts_CoveredHealthcareProductID = Guid.NewGuid();
            healthcareproductCovered5.HealthcareProduct_RefID = Guid.NewGuid();
            healthcareproductCovered5.InsuranceToBrokerContract_RefID = healthcarecontracts.HEC_CRT_InsuranceToBrokerContractID;
            healthcareproductCovered5.Save(Connection, Transaction);

            var hecProducts5 = new ORM_HEC_Product();
            hecProducts5.IsDeleted = false;
            hecProducts5.Tenant_RefID = securityTicket.TenantID;
            hecProducts5.HEC_ProductID = healthcareproductCovered5.HealthcareProduct_RefID;
            hecProducts5.Creation_Timestamp = DateTime.Now;
            hecProducts5.Modification_Timestamp = DateTime.Now;
            hecProducts5.Ext_PRO_Product_RefID = Guid.NewGuid();
            hecProducts5.Save(Connection, Transaction);

            Dict ProductNameDict5 = new Dict(ORM_CMN_PRO_Product.TableName);
            for (int i = 0; i < DBLanguages.Count; i++)
            {
                ProductNameDict5.AddEntry(DBLanguages[i].CMN_LanguageID, "Lucentis DFL");
            }

            var products5 = new ORM_CMN_PRO_Product();
            products5.CMN_PRO_ProductID = hecProducts5.Ext_PRO_Product_RefID;
            products5.IsDeleted = false;
            products5.Tenant_RefID = securityTicket.TenantID;
            products5.Creation_Timestamp = DateTime.Now;
            products5.Product_Name = ProductNameDict5;
            products5.IsProducable_Internally = false;
            products5.Product_Number = "67760";
            products5.Save(Connection, Transaction);

            var healthcareproductCovered6 = new ORM_HEC_CTR_InsuranceToBrokerContracts_CoveredHealthcareProduct();
            healthcareproductCovered6.IsDeleted = false;
            healthcareproductCovered6.Tenant_RefID = securityTicket.TenantID;
            healthcareproductCovered6.Creation_Timestamp = DateTime.Now;
            healthcareproductCovered6.HEC_CTR_InsuranceToBrokerContracts_CoveredHealthcareProductID = Guid.NewGuid();
            healthcareproductCovered6.HealthcareProduct_RefID = Guid.NewGuid();
            healthcareproductCovered6.InsuranceToBrokerContract_RefID = healthcarecontracts.HEC_CRT_InsuranceToBrokerContractID;
            healthcareproductCovered6.Save(Connection, Transaction);

            var hecProducts6 = new ORM_HEC_Product();
            hecProducts6.IsDeleted = false;
            hecProducts6.Tenant_RefID = securityTicket.TenantID;
            hecProducts6.HEC_ProductID = healthcareproductCovered6.HealthcareProduct_RefID;
            hecProducts6.Creation_Timestamp = DateTime.Now;
            hecProducts6.Modification_Timestamp = DateTime.Now;
            hecProducts6.Ext_PRO_Product_RefID = Guid.NewGuid();
            hecProducts6.Save(Connection, Transaction);

            Dict ProductNameDict6 = new Dict(ORM_CMN_PRO_Product.TableName);
            for (int i = 0; i < DBLanguages.Count; i++)
            {
                ProductNameDict6.AddEntry(DBLanguages[i].CMN_LanguageID, "Lucentis FSP");
            }


            var products6 = new ORM_CMN_PRO_Product();
            products6.CMN_PRO_ProductID = hecProducts6.Ext_PRO_Product_RefID;
            products6.IsDeleted = false;
            products6.Tenant_RefID = securityTicket.TenantID;
            products6.Creation_Timestamp = DateTime.Now;
            products6.Product_Name = ProductNameDict6;
            products6.IsProducable_Internally = false;
            products6.Product_Number = "10108939";
            products6.Save(Connection, Transaction);

            var healthcareproductCovered7 = new ORM_HEC_CTR_InsuranceToBrokerContracts_CoveredHealthcareProduct();
            healthcareproductCovered7.IsDeleted = false;
            healthcareproductCovered7.Tenant_RefID = securityTicket.TenantID;
            healthcareproductCovered7.Creation_Timestamp = DateTime.Now;
            healthcareproductCovered7.HEC_CTR_InsuranceToBrokerContracts_CoveredHealthcareProductID = Guid.NewGuid();
            healthcareproductCovered7.HealthcareProduct_RefID = Guid.NewGuid();
            healthcareproductCovered7.InsuranceToBrokerContract_RefID = healthcarecontracts.HEC_CRT_InsuranceToBrokerContractID;
            healthcareproductCovered7.Save(Connection, Transaction);

            var hecProducts7 = new ORM_HEC_Product();
            hecProducts7.IsDeleted = false;
            hecProducts7.Tenant_RefID = securityTicket.TenantID;
            hecProducts7.HEC_ProductID = healthcareproductCovered7.HealthcareProduct_RefID;
            hecProducts7.Creation_Timestamp = DateTime.Now;
            hecProducts7.Modification_Timestamp = DateTime.Now;
            hecProducts7.Ext_PRO_Product_RefID = Guid.NewGuid();
            hecProducts7.Save(Connection, Transaction);

            Dict ProductNameDict7 = new Dict(ORM_CMN_PRO_Product.TableName);
            for (int i = 0; i < DBLanguages.Count; i++)
            {
                ProductNameDict7.AddEntry(DBLanguages[i].CMN_LanguageID, "Macugen");
            }

            var products7 = new ORM_CMN_PRO_Product();
            products7.CMN_PRO_ProductID = hecProducts7.Ext_PRO_Product_RefID;
            products7.IsDeleted = false;
            products7.Tenant_RefID = securityTicket.TenantID;
            products7.Creation_Timestamp = DateTime.Now;
            products7.Product_Name = ProductNameDict7;
            products7.IsProducable_Internally = false;
            products7.Product_Number = "00000000";
            products7.Save(Connection, Transaction);

            var healthcareproductCovered8 = new ORM_HEC_CTR_InsuranceToBrokerContracts_CoveredHealthcareProduct();
            healthcareproductCovered8.IsDeleted = false;
            healthcareproductCovered8.Tenant_RefID = securityTicket.TenantID;
            healthcareproductCovered8.Creation_Timestamp = DateTime.Now;
            healthcareproductCovered8.HEC_CTR_InsuranceToBrokerContracts_CoveredHealthcareProductID = Guid.NewGuid();
            healthcareproductCovered8.HealthcareProduct_RefID = Guid.NewGuid();
            healthcareproductCovered8.InsuranceToBrokerContract_RefID = healthcarecontracts.HEC_CRT_InsuranceToBrokerContractID;
            healthcareproductCovered8.Save(Connection, Transaction);


            var hecProducts8 = new ORM_HEC_Product();
            hecProducts8.IsDeleted = false;
            hecProducts8.Tenant_RefID = securityTicket.TenantID;
            hecProducts8.HEC_ProductID = healthcareproductCovered8.HealthcareProduct_RefID;
            hecProducts8.Creation_Timestamp = DateTime.Now;
            hecProducts8.Modification_Timestamp = DateTime.Now;
            hecProducts8.Ext_PRO_Product_RefID = Guid.NewGuid();
            hecProducts8.Save(Connection, Transaction);

            Dict ProductNameDict8 = new Dict(ORM_CMN_PRO_Product.TableName);
            for (int i = 0; i < DBLanguages.Count; i++)
            {
                ProductNameDict8.AddEntry(DBLanguages[i].CMN_LanguageID, "Ozurdex");
            }


            var products8 = new ORM_CMN_PRO_Product();
            products8.CMN_PRO_ProductID = hecProducts8.Ext_PRO_Product_RefID;
            products8.IsDeleted = false;
            products8.Tenant_RefID = securityTicket.TenantID;
            products8.Creation_Timestamp = DateTime.Now;
            products8.Product_Name = ProductNameDict8;
            products8.IsProducable_Internally = false;
            products8.Product_Number = "6839790";
            products8.Save(Connection, Transaction);

            var healthcareproductCovered9 = new ORM_HEC_CTR_InsuranceToBrokerContracts_CoveredHealthcareProduct();
            healthcareproductCovered9.IsDeleted = false;
            healthcareproductCovered9.Tenant_RefID = securityTicket.TenantID;
            healthcareproductCovered9.Creation_Timestamp = DateTime.Now;
            healthcareproductCovered9.HEC_CTR_InsuranceToBrokerContracts_CoveredHealthcareProductID = Guid.NewGuid();
            healthcareproductCovered9.HealthcareProduct_RefID = Guid.NewGuid();
            healthcareproductCovered9.InsuranceToBrokerContract_RefID = healthcarecontracts.HEC_CRT_InsuranceToBrokerContractID;
            healthcareproductCovered9.Save(Connection, Transaction);

            var hecProducts9 = new ORM_HEC_Product();
            hecProducts9.IsDeleted = false;
            hecProducts9.Tenant_RefID = securityTicket.TenantID;
            hecProducts9.HEC_ProductID = healthcareproductCovered9.HealthcareProduct_RefID;
            hecProducts9.Creation_Timestamp = DateTime.Now;
            hecProducts9.Modification_Timestamp = DateTime.Now;
            hecProducts9.Ext_PRO_Product_RefID = Guid.NewGuid();
            hecProducts9.Save(Connection, Transaction);

            Dict ProductNameDict9 = new Dict(ORM_CMN_PRO_Product.TableName);
            for (int i = 0; i < DBLanguages.Count; i++)
            {
                ProductNameDict9.AddEntry(DBLanguages[i].CMN_LanguageID, "Ranibizumab 0,5mg");
            }


            var products9 = new ORM_CMN_PRO_Product();
            products9.CMN_PRO_ProductID = hecProducts9.Ext_PRO_Product_RefID;
            products9.IsDeleted = false;
            products9.Tenant_RefID = securityTicket.TenantID;
            products9.Creation_Timestamp = DateTime.Now;
            products9.Product_Name = ProductNameDict9;
            products9.IsProducable_Internally = true;
            products9.Product_Number = "Ranibizumab";
            products9.Save(Connection, Transaction);

            var businessParticipantHIP = new ORM_CMN_BPT_BusinessParticipant();
            businessParticipantHIP.CMN_BPT_BusinessParticipantID = Guid.NewGuid();
            businessParticipantHIP.IsDeleted = false;
            businessParticipantHIP.Tenant_RefID = securityTicket.TenantID;
            businessParticipantHIP.Creation_Timestamp = DateTime.Now;
            businessParticipantHIP.Modification_Timestamp = DateTime.Now;
            businessParticipantHIP.DisplayName = "Private HIP";
            businessParticipantHIP.IsCompany = true;
            businessParticipantHIP.Save(Connection, Transaction);

            var contractPartiesRolesHIP = ORM_CMN_CTR_Contract_Role.Query.Search(Connection, Transaction, new ORM_CMN_CTR_Contract_Role.Query()
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID,
                RoleName = "Health Insurance Provider"
            }).SingleOrDefault();

            if (contractPartiesRolesHIP == null)
            {
                contractPartiesRolesHIP = new ORM_CMN_CTR_Contract_Role();
                contractPartiesRolesHIP.CMN_CTR_Contract_RoleID = Guid.NewGuid();
                contractPartiesRolesHIP.IsDeleted = false;
                contractPartiesRolesHIP.Tenant_RefID = securityTicket.TenantID;
                contractPartiesRolesHIP.Creation_Timestamp = DateTime.Now;
                contractPartiesRolesHIP.Modification_Timestamp = DateTime.Now;
                contractPartiesRolesHIP.RoleName = "Health Insurance Provider";
                contractPartiesRolesHIP.Save(Connection, Transaction);
            }

            var contractPartiesHIP = new ORM_CMN_CTR_Contract_Party();
            contractPartiesHIP.Tenant_RefID = securityTicket.TenantID;
            contractPartiesHIP.IsDeleted = false;
            contractPartiesHIP.Undersigning_BusinessParticipant_RefID = businessParticipantHIP.CMN_BPT_BusinessParticipantID;
            contractPartiesHIP.Creation_Timestamp = DateTime.Now;
            contractPartiesHIP.CMN_CTR_Contract_PartyID = Guid.NewGuid();
            contractPartiesHIP.Contract_RefID = ContractId;
            contractPartiesHIP.Party_ContractRole_RefID = contractPartiesRolesHIP.CMN_CTR_Contract_RoleID;
            contractPartiesHIP.Save(Connection, Transaction);

            var healthInsuranceCompany = new ORM_HEC_HIS_HealthInsurance_Company();
            healthInsuranceCompany.IsDeleted = false;
            healthInsuranceCompany.Tenant_RefID = securityTicket.TenantID;
            healthInsuranceCompany.Creation_Timestamp = DateTime.Now;
            healthInsuranceCompany.CMN_BPT_BusinessParticipant_RefID = businessParticipantHIP.CMN_BPT_BusinessParticipantID;
            healthInsuranceCompany.HealthInsurance_IKNumber = "000000000";
            healthInsuranceCompany.Save(Connection, Transaction);

        }

        public static void FixPrecreationOfFirstContract(DbConnection Connection, DbTransaction Transaction, SessionSecurityTicket securityTicket)
        {

            var productsQuery = new ORM_CMN_PRO_Product.Query();
            productsQuery.IsDeleted = false;
            productsQuery.Tenant_RefID = securityTicket.TenantID;

            var productList = ORM_CMN_PRO_Product.Query.Search(Connection, Transaction, productsQuery).ToList();

            foreach (var item in productList)
            {
                if (item.IsProducable_Internally)
                {
                    item.IsProducable_Internally = false;
                }
                else
                {
                    item.IsProducable_Internally = true;
                }
                item.Save(Connection, Transaction);
            }
        }

        public static void FixPrecreationOfFirstContractDrugs(DbConnection Connection, DbTransaction Transaction, SessionSecurityTicket securityTicket)
        {

            var accountforTenant = ORM_USR_Account.Query.Search(Connection, Transaction, new ORM_USR_Account.Query()
            {
                IsDeleted = false,
                USR_AccountID = securityTicket.AccountID,
                Tenant_RefID = securityTicket.TenantID

            }).Single();

            var businessParticipantForTenant = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, new ORM_CMN_BPT_BusinessParticipant.Query()
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID,
                CMN_BPT_BusinessParticipantID = accountforTenant.BusinessParticipant_RefID
            }).Single();

            var searchContractParties = ORM_CMN_CTR_Contract_Party.Query.Search(Connection, Transaction, new ORM_CMN_CTR_Contract_Party.Query()
            {

                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID,
                Undersigning_BusinessParticipant_RefID = businessParticipantForTenant.CMN_BPT_BusinessParticipantID

            }).ToList();
            Guid contractID = Guid.NewGuid();
            foreach (var partie in searchContractParties)
            {
                var searchContract = ORM_CMN_CTR_Contract.Query.Search(Connection, Transaction, new ORM_CMN_CTR_Contract.Query()
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID,
                    CMN_CTR_ContractID = partie.Contract_RefID,
                    ContractName = "IVI-Vertrag",
                }).SingleOrDefault();
                if (searchContract != null)
                {
                    contractID = searchContract.CMN_CTR_ContractID;
                }

            }


            var hecContract = ORM_HEC_CRT_InsuranceToBrokerContract.Query.Search(Connection, Transaction, new ORM_HEC_CRT_InsuranceToBrokerContract.Query()
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID,
                Ext_CMN_CTR_Contract_RefID = contractID

            }).Single();

            var ProductList = ORM_CMN_PRO_Product.Query.Search(Connection, Transaction, new ORM_CMN_PRO_Product.Query()
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID
            }).ToList();


            foreach (var product in ProductList)
            {

                //var hecProducts = new ORM_HEC_Product();
                //hecProducts.IsDeleted = false;
                //hecProducts.Tenant_RefID = securityTicket.TenantID;
                //hecProducts.HEC_ProductID = healthcareproductCovered.HealthcareProduct_RefID;
                //hecProducts.Creation_Timestamp = DateTime.Now;
                //hecProducts.Modification_Timestamp = DateTime.Now;
                //hecProducts.Ext_PRO_Product_RefID = product.CMN_PRO_ProductID;
                //hecProducts.Save(Connection, Transaction);

                var hecProducts = ORM_HEC_Product.Query.Search(Connection, Transaction, new ORM_HEC_Product.Query()
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID,
                    Ext_PRO_Product_RefID = product.CMN_PRO_ProductID
                }).SingleOrDefault();


                if (hecProducts != null)
                {
                    var healthcareproductCovered = new ORM_HEC_CTR_InsuranceToBrokerContracts_CoveredHealthcareProduct();
                    healthcareproductCovered.IsDeleted = false;
                    healthcareproductCovered.Tenant_RefID = securityTicket.TenantID;
                    healthcareproductCovered.Creation_Timestamp = DateTime.Now;
                    healthcareproductCovered.HEC_CTR_InsuranceToBrokerContracts_CoveredHealthcareProductID = Guid.NewGuid();
                    healthcareproductCovered.HealthcareProduct_RefID = hecProducts.HEC_ProductID;
                    healthcareproductCovered.InsuranceToBrokerContract_RefID = hecContract.HEC_CRT_InsuranceToBrokerContractID;
                    healthcareproductCovered.Save(Connection, Transaction);

                }



            }

        }

        public static void Create_Contract_Ivi_Vertrag(DbConnection Connection, DbTransaction Transaction, SessionSecurityTicket securityTicket)
        {
            var accountforTenant = ORM_USR_Account.Query.Search(Connection, Transaction, new ORM_USR_Account.Query()
            {
                IsDeleted = false,
                USR_AccountID = securityTicket.AccountID,
                Tenant_RefID = securityTicket.TenantID

            }).Single();

            var businessParticipantForTenant = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, new ORM_CMN_BPT_BusinessParticipant.Query()
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID,
                CMN_BPT_BusinessParticipantID = accountforTenant.BusinessParticipant_RefID
            }).Single();

            var searchContractParties = ORM_CMN_CTR_Contract_Party.Query.Search(Connection, Transaction, new ORM_CMN_CTR_Contract_Party.Query()
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID,
                Undersigning_BusinessParticipant_RefID = businessParticipantForTenant.CMN_BPT_BusinessParticipantID
            }).ToList();

            var contractRoles = ORM_CMN_CTR_Contract_Role.Query.Search(Connection, Transaction, new ORM_CMN_CTR_Contract_Role.Query()
            {
                RoleName = "Mediator",
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID
            }).SingleOrDefault();

            if (contractRoles == null)
            {
                contractRoles = new ORM_CMN_CTR_Contract_Role();
                contractRoles.CMN_CTR_Contract_RoleID = Guid.NewGuid();
                contractRoles.IsDeleted = false;
                contractRoles.Tenant_RefID = securityTicket.TenantID;
                contractRoles.Creation_Timestamp = DateTime.Now;
                contractRoles.RoleName = "Mediator";

                contractRoles.Save(Connection, Transaction);
            }

            var contractParties = new ORM_CMN_CTR_Contract_Party();
            contractParties.Tenant_RefID = securityTicket.TenantID;
            contractParties.IsDeleted = false;
            contractParties.Undersigning_BusinessParticipant_RefID = businessParticipantForTenant.CMN_BPT_BusinessParticipantID;
            contractParties.Creation_Timestamp = DateTime.Now;
            contractParties.CMN_CTR_Contract_PartyID = Guid.NewGuid();
            contractParties.Contract_RefID = Guid.NewGuid();
            contractParties.Party_ContractRole_RefID = contractRoles.CMN_CTR_Contract_RoleID;
            contractParties.Save(Connection, Transaction);

            var contract = new ORM_CMN_CTR_Contract();
            contract.CMN_CTR_ContractID = contractParties.Contract_RefID;
            contract.IsDeleted = false;
            contract.Creation_Timestamp = DateTime.Now;
            contract.Tenant_RefID = securityTicket.TenantID;
            contract.ContractName = "IVI-Vertrag";
            contract.ValidFrom = new DateTime(2013, 6, 15);
            contract.Save(Connection, Transaction);

            var healthcarecontracts = new ORM_HEC_CRT_InsuranceToBrokerContract();
            healthcarecontracts.HEC_CRT_InsuranceToBrokerContractID = Guid.NewGuid();
            healthcarecontracts.IsDeleted = false;
            healthcarecontracts.Tenant_RefID = securityTicket.TenantID;
            healthcarecontracts.Ext_CMN_CTR_Contract_RefID = contract.CMN_CTR_ContractID;
            healthcarecontracts.Creation_Timestamp = DateTime.Now;
            healthcarecontracts.Save(Connection, Transaction);


            //Contract parameters
            var contractParameters = new ORM_CMN_CTR_Contract_Parameter();
            contractParameters.IsDeleted = false;
            contractParameters.Tenant_RefID = securityTicket.TenantID;
            contractParameters.Modification_Timestamp = DateTime.Now;
            contractParameters.Creation_Timestamp = DateTime.Now;
            contractParameters.ParameterName = "Duration of participation consent – Month";
            contractParameters.Contract_RefID = contract.CMN_CTR_ContractID;
            contractParameters.IfNumericValue_Value = 12;
            contractParameters.IsNumericValue = true;
            contractParameters.Save(Connection, Transaction);

            var contractParameters2 = new ORM_CMN_CTR_Contract_Parameter();
            contractParameters2.IsDeleted = false;
            contractParameters2.Tenant_RefID = securityTicket.TenantID;
            contractParameters2.Modification_Timestamp = DateTime.Now;
            contractParameters2.Creation_Timestamp = DateTime.Now;
            contractParameters2.ParameterName = "Number of days between surgery and aftercare - Days";
            contractParameters2.Contract_RefID = contract.CMN_CTR_ContractID;
            contractParameters2.IfNumericValue_Value = 28;
            contractParameters2.IsNumericValue = true;
            contractParameters2.Save(Connection, Transaction);

            var contractParameters3 = new ORM_CMN_CTR_Contract_Parameter();
            contractParameters3.IsDeleted = false;
            contractParameters3.Tenant_RefID = securityTicket.TenantID;
            contractParameters3.Modification_Timestamp = DateTime.Now;
            contractParameters3.Creation_Timestamp = DateTime.Now;
            contractParameters3.ParameterName = "Number of days between treatment and settlement claim - Days";
            contractParameters3.Contract_RefID = contract.CMN_CTR_ContractID;
            contractParameters3.IfNumericValue_Value = 180;
            contractParameters3.IsNumericValue = true;
            contractParameters3.Save(Connection, Transaction);

            var contractParameters4 = new ORM_CMN_CTR_Contract_Parameter();
            contractParameters4.IsDeleted = false;
            contractParameters4.Tenant_RefID = securityTicket.TenantID;
            contractParameters4.Modification_Timestamp = DateTime.Now;
            contractParameters4.Creation_Timestamp = DateTime.Now;
            contractParameters4.ParameterName = "Number of days between submission to HIP and reply – Days";
            contractParameters4.Contract_RefID = contract.CMN_CTR_ContractID;
            contractParameters4.IfNumericValue_Value = 14;
            contractParameters4.IsNumericValue = true;
            contractParameters4.Save(Connection, Transaction);

            var contractParameters5 = new ORM_CMN_CTR_Contract_Parameter();
            contractParameters5.IsDeleted = false;
            contractParameters5.Tenant_RefID = securityTicket.TenantID;
            contractParameters5.Modification_Timestamp = DateTime.Now;
            contractParameters5.Creation_Timestamp = DateTime.Now;
            contractParameters5.ParameterName = "Number of days between response and payment – Days";
            contractParameters5.Contract_RefID = contract.CMN_CTR_ContractID;
            contractParameters5.IfNumericValue_Value = 20;
            contractParameters5.IsNumericValue = true;
            contractParameters5.Save(Connection, Transaction);

            var contractParameters6 = new ORM_CMN_CTR_Contract_Parameter();
            contractParameters6.IsDeleted = false;
            contractParameters6.Tenant_RefID = securityTicket.TenantID;
            contractParameters6.Modification_Timestamp = DateTime.Now;
            contractParameters6.Creation_Timestamp = DateTime.Now;
            contractParameters6.ParameterName = "Number of days between HIP response and rejection  - Days";
            contractParameters6.Contract_RefID = contract.CMN_CTR_ContractID;
            contractParameters6.IfNumericValue_Value = 30;
            contractParameters6.IsNumericValue = true;
            contractParameters6.Save(Connection, Transaction);

            var contractParameters7 = new ORM_CMN_CTR_Contract_Parameter();
            contractParameters7.IsDeleted = false;
            contractParameters7.Tenant_RefID = securityTicket.TenantID;
            contractParameters7.Modification_Timestamp = DateTime.Now;
            contractParameters7.Creation_Timestamp = DateTime.Now;
            contractParameters7.ParameterName = "Contract characteristic ID";
            contractParameters7.Contract_RefID = contract.CMN_CTR_ContractID;
            contractParameters7.IfStringValue_Value = "17172100035";
            contractParameters7.IsStringValue = true;
            contractParameters7.Save(Connection, Transaction);

            //Add medications to this contract
            var ProductList = ORM_CMN_PRO_Product.Query.Search(Connection, Transaction, new ORM_CMN_PRO_Product.Query()
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID
            }).ToList();

            foreach (var product in ProductList)
            {
                var hecProducts = ORM_HEC_Product.Query.Search(Connection, Transaction, new ORM_HEC_Product.Query()
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID,
                    Ext_PRO_Product_RefID = product.CMN_PRO_ProductID
                }).SingleOrDefault();


                if (hecProducts != null)
                {
                    var healthcareproductCovered = new ORM_HEC_CTR_InsuranceToBrokerContracts_CoveredHealthcareProduct();
                    healthcareproductCovered.IsDeleted = false;
                    healthcareproductCovered.Tenant_RefID = securityTicket.TenantID;
                    healthcareproductCovered.Creation_Timestamp = DateTime.Now;
                    healthcareproductCovered.HEC_CTR_InsuranceToBrokerContracts_CoveredHealthcareProductID = Guid.NewGuid();
                    healthcareproductCovered.HealthcareProduct_RefID = hecProducts.HEC_ProductID;
                    healthcareproductCovered.InsuranceToBrokerContract_RefID = healthcarecontracts.HEC_CRT_InsuranceToBrokerContractID;
                    healthcareproductCovered.Save(Connection, Transaction);

                }

            }

            Guid ContractID = contract.CMN_CTR_ContractID;
            Dictionary<int, string> HIPCompanies = new Dictionary<int, string>();
            HIPCompanies.Add(109519005, "AOK Nordost (Berlin)");
            HIPCompanies.Add(100395611, "AOK Nordost (Mecklenburg Vorpommern)");
            HIPCompanies.Add(100696012, "AOK Nordost (Brandenburg)");

            foreach (var item in HIPCompanies)
            {
                var businessParticipantHIP = new ORM_CMN_BPT_BusinessParticipant();
                businessParticipantHIP.CMN_BPT_BusinessParticipantID = Guid.NewGuid();
                businessParticipantHIP.IsDeleted = false;
                businessParticipantHIP.IsCompany = true;
                businessParticipantHIP.Tenant_RefID = securityTicket.TenantID;
                businessParticipantHIP.Creation_Timestamp = DateTime.Now;
                businessParticipantHIP.Modification_Timestamp = DateTime.Now;
                businessParticipantHIP.DisplayName = item.Value;
                businessParticipantHIP.Save(Connection, Transaction);

                var contractPartiesRolesHIP = ORM_CMN_CTR_Contract_Role.Query.Search(Connection, Transaction, new ORM_CMN_CTR_Contract_Role.Query()
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID,
                    RoleName = "Health Insurance Provider"
                }).SingleOrDefault();

                if (contractPartiesRolesHIP == null)
                {
                    contractPartiesRolesHIP = new ORM_CMN_CTR_Contract_Role();
                    contractPartiesRolesHIP.CMN_CTR_Contract_RoleID = Guid.NewGuid();
                    contractPartiesRolesHIP.IsDeleted = false;
                    contractPartiesRolesHIP.Tenant_RefID = securityTicket.TenantID;
                    contractPartiesRolesHIP.Creation_Timestamp = DateTime.Now;
                    contractPartiesRolesHIP.Modification_Timestamp = DateTime.Now;
                    contractPartiesRolesHIP.RoleName = "Health Insurance Provider";
                    contractPartiesRolesHIP.Save(Connection, Transaction);
                }

                var contractPartiesHIP = new ORM_CMN_CTR_Contract_Party();
                contractPartiesHIP.Tenant_RefID = securityTicket.TenantID;
                contractPartiesHIP.IsDeleted = false;
                contractPartiesHIP.Undersigning_BusinessParticipant_RefID = businessParticipantHIP.CMN_BPT_BusinessParticipantID;
                contractPartiesHIP.Creation_Timestamp = DateTime.Now;
                contractPartiesHIP.CMN_CTR_Contract_PartyID = Guid.NewGuid();
                contractPartiesHIP.Contract_RefID = ContractID;
                contractPartiesHIP.Party_ContractRole_RefID = contractPartiesRolesHIP.CMN_CTR_Contract_RoleID;
                contractPartiesHIP.Save(Connection, Transaction);

                var healthInsuranceCompany = new ORM_HEC_HIS_HealthInsurance_Company();
                healthInsuranceCompany.IsDeleted = false;
                healthInsuranceCompany.Tenant_RefID = securityTicket.TenantID;
                healthInsuranceCompany.Creation_Timestamp = DateTime.Now;
                healthInsuranceCompany.CMN_BPT_BusinessParticipant_RefID = businessParticipantHIP.CMN_BPT_BusinessParticipantID;
                healthInsuranceCompany.HealthInsurance_IKNumber = item.Key.ToString();
                healthInsuranceCompany.Save(Connection, Transaction);
            }

            var contract2diagnoses = new ORM_HEC_CTR_InsuranceToBrokerContracts_CoveredPotentialDiagnosis();
            contract2diagnoses.IsDeleted = false;
            contract2diagnoses.Tenant_RefID = securityTicket.TenantID;
            contract2diagnoses.Creation_Timestamp = DateTime.Now;
            contract2diagnoses.Modification_Timestamp = DateTime.Now;
            contract2diagnoses.InsuranceToBrokerContract_RefID = healthcarecontracts.HEC_CRT_InsuranceToBrokerContractID;
            contract2diagnoses.PotentialDiagnosis_RefID = Guid.NewGuid();
            contract2diagnoses.Save(Connection, Transaction);

            //diagnose1 
            var DBLanguages = cls_Get_All_Languages.Invoke(Connection, Transaction, securityTicket).Result.ToList();
            Dict DiagnosisName = new Dict(ORM_HEC_DIA_PotentialDiagnosis.TableName);
            for (int i = 0; i < DBLanguages.Count; i++)
            {
                DiagnosisName.AddEntry(DBLanguages[i].CMN_LanguageID, "neovaskuläre (feuchte) altersabhängige Makuladegeneration");
            }

            var diagnoses = new ORM_HEC_DIA_PotentialDiagnosis();
            diagnoses.PotentialDiagnosis_Name = DiagnosisName;
            diagnoses.IsDeleted = false;
            diagnoses.Tenant_RefID = securityTicket.TenantID;
            diagnoses.Creation_Timestamp = DateTime.Now;
            diagnoses.Modification_Timestamp = DateTime.Now;
            diagnoses.HEC_DIA_PotentialDiagnosisID = contract2diagnoses.PotentialDiagnosis_RefID;
            diagnoses.Save(Connection, Transaction);

            var diagnosis2catalogCodes = new ORM_HEC_DIA_PotentialDiagnosis_CatalogCode();
            diagnosis2catalogCodes.IsDeleted = false;
            diagnosis2catalogCodes.Tenant_RefID = securityTicket.TenantID;
            diagnosis2catalogCodes.Creation_Timestamp = DateTime.Now;
            diagnosis2catalogCodes.Modification_Timestamp = DateTime.Now;
            diagnosis2catalogCodes.PotentialDiagnosis_RefID = diagnoses.HEC_DIA_PotentialDiagnosisID;
            diagnosis2catalogCodes.PotentialDiagnosis_Catalog_RefID = Guid.NewGuid();
            diagnosis2catalogCodes.Code = "H35.3";
            diagnosis2catalogCodes.Save(Connection, Transaction);


            Dict CatalogName = new Dict(ORM_HEC_DIA_PotentialDiagnosis_Catalog.TableName);
            for (int i = 0; i < DBLanguages.Count; i++)
            {
                DiagnosisName.AddEntry(DBLanguages[i].CMN_LanguageID, "ICD-10");
            }

            var diagnosisCatalogs = new ORM_HEC_DIA_PotentialDiagnosis_Catalog();
            diagnosisCatalogs.Catalog_DisplayName = "ICD-10";
            diagnosisCatalogs.IsDeleted = false;
            diagnosisCatalogs.Tenant_RefID = securityTicket.TenantID;
            diagnosisCatalogs.Creation_Timestamp = DateTime.Now;
            diagnosisCatalogs.Modification_Timestamp = DateTime.Now;
            diagnosisCatalogs.HEC_DIA_PotentialDiagnosis_CatalogID = diagnosis2catalogCodes.PotentialDiagnosis_Catalog_RefID;
            diagnosisCatalogs.Catalog_Name = CatalogName;
            diagnosisCatalogs.Save(Connection, Transaction);

            //diagnose2 

            var contract2diagnoses2 = new ORM_HEC_CTR_InsuranceToBrokerContracts_CoveredPotentialDiagnosis();
            contract2diagnoses2.IsDeleted = false;
            contract2diagnoses2.Tenant_RefID = securityTicket.TenantID;
            contract2diagnoses2.Creation_Timestamp = DateTime.Now;
            contract2diagnoses2.Modification_Timestamp = DateTime.Now;
            contract2diagnoses2.InsuranceToBrokerContract_RefID = healthcarecontracts.HEC_CRT_InsuranceToBrokerContractID;
            contract2diagnoses2.PotentialDiagnosis_RefID = Guid.NewGuid();
            contract2diagnoses2.Save(Connection, Transaction);

            Dict DiagnosisName2 = new Dict(ORM_HEC_DIA_PotentialDiagnosis.TableName);
            for (int i = 0; i < DBLanguages.Count; i++)
            {
                DiagnosisName2.AddEntry(DBLanguages[i].CMN_LanguageID, "Makulaödem nach venösem Netzhautgefäßverschluss");
            }

            var diagnoses2 = new ORM_HEC_DIA_PotentialDiagnosis();
            diagnoses2.PotentialDiagnosis_Name = DiagnosisName2;
            diagnoses2.IsDeleted = false;
            diagnoses2.Tenant_RefID = securityTicket.TenantID;
            diagnoses2.Creation_Timestamp = DateTime.Now;
            diagnoses2.Modification_Timestamp = DateTime.Now;
            diagnoses2.HEC_DIA_PotentialDiagnosisID = contract2diagnoses2.PotentialDiagnosis_RefID;
            diagnoses2.Save(Connection, Transaction);



            var diagnosis2catalogCodes2 = new ORM_HEC_DIA_PotentialDiagnosis_CatalogCode();
            diagnosis2catalogCodes2.IsDeleted = false;
            diagnosis2catalogCodes2.Tenant_RefID = securityTicket.TenantID;
            diagnosis2catalogCodes2.Creation_Timestamp = DateTime.Now;
            diagnosis2catalogCodes2.Modification_Timestamp = DateTime.Now;
            diagnosis2catalogCodes2.PotentialDiagnosis_RefID = diagnoses2.HEC_DIA_PotentialDiagnosisID;
            diagnosis2catalogCodes2.PotentialDiagnosis_Catalog_RefID = Guid.NewGuid();
            diagnosis2catalogCodes2.Code = "H34.8";
            diagnosis2catalogCodes2.Save(Connection, Transaction);

            var diagnosisCatalogs2 = new ORM_HEC_DIA_PotentialDiagnosis_Catalog();
            diagnosisCatalogs2.IsDeleted = false;
            diagnosisCatalogs2.Catalog_DisplayName = "ICD-10";
            diagnosisCatalogs2.Tenant_RefID = securityTicket.TenantID;
            diagnosisCatalogs2.Creation_Timestamp = DateTime.Now;
            diagnosisCatalogs2.Modification_Timestamp = DateTime.Now;
            diagnosisCatalogs2.HEC_DIA_PotentialDiagnosis_CatalogID = diagnosis2catalogCodes2.PotentialDiagnosis_Catalog_RefID;
            diagnosisCatalogs2.Catalog_Name = CatalogName;
            diagnosisCatalogs2.Save(Connection, Transaction);


            //diagnose3

            var contract2diagnoses3 = new ORM_HEC_CTR_InsuranceToBrokerContracts_CoveredPotentialDiagnosis();
            contract2diagnoses3.IsDeleted = false;
            contract2diagnoses3.Tenant_RefID = securityTicket.TenantID;
            contract2diagnoses3.Creation_Timestamp = DateTime.Now;
            contract2diagnoses3.Modification_Timestamp = DateTime.Now;
            contract2diagnoses3.InsuranceToBrokerContract_RefID = healthcarecontracts.HEC_CRT_InsuranceToBrokerContractID;
            contract2diagnoses3.PotentialDiagnosis_RefID = Guid.NewGuid();
            contract2diagnoses3.Save(Connection, Transaction);

            Dict DiagnosisName3 = new Dict(ORM_HEC_DIA_PotentialDiagnosis.TableName);
            for (int i = 0; i < DBLanguages.Count; i++)
            {
                DiagnosisName3.AddEntry(DBLanguages[i].CMN_LanguageID, "diabetisches Makulaödem");
            }

            var diagnoses3 = new ORM_HEC_DIA_PotentialDiagnosis();
            diagnoses3.PotentialDiagnosis_Name = DiagnosisName3;
            diagnoses3.IsDeleted = false;
            diagnoses3.Tenant_RefID = securityTicket.TenantID;
            diagnoses3.Creation_Timestamp = DateTime.Now;
            diagnoses3.Modification_Timestamp = DateTime.Now;
            diagnoses3.HEC_DIA_PotentialDiagnosisID = contract2diagnoses3.PotentialDiagnosis_RefID;
            diagnoses3.Save(Connection, Transaction);

            var diagnosis2catalogCodes3 = new ORM_HEC_DIA_PotentialDiagnosis_CatalogCode();
            diagnosis2catalogCodes3.IsDeleted = false;
            diagnosis2catalogCodes3.Tenant_RefID = securityTicket.TenantID;
            diagnosis2catalogCodes3.Creation_Timestamp = DateTime.Now;
            diagnosis2catalogCodes3.Modification_Timestamp = DateTime.Now;
            diagnosis2catalogCodes3.PotentialDiagnosis_RefID = diagnoses3.HEC_DIA_PotentialDiagnosisID;
            diagnosis2catalogCodes3.PotentialDiagnosis_Catalog_RefID = Guid.NewGuid();
            diagnosis2catalogCodes3.Code = "H36.0";
            diagnosis2catalogCodes3.Save(Connection, Transaction);

            var diagnosisCatalogs3 = new ORM_HEC_DIA_PotentialDiagnosis_Catalog();
            diagnosisCatalogs3.IsDeleted = false;
            diagnosisCatalogs3.Catalog_DisplayName = "ICD-10";
            diagnosisCatalogs3.Tenant_RefID = securityTicket.TenantID;
            diagnosisCatalogs3.Creation_Timestamp = DateTime.Now;
            diagnosisCatalogs3.Modification_Timestamp = DateTime.Now;
            diagnosisCatalogs3.HEC_DIA_PotentialDiagnosis_CatalogID = diagnosis2catalogCodes3.PotentialDiagnosis_Catalog_RefID;
            diagnosisCatalogs3.Catalog_Name = CatalogName;
            diagnosisCatalogs3.Save(Connection, Transaction);


        }

    }

}

