/* 
 * Generated on 1/17/2014 3:13:24 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 * Required Assemblies:
 * System.Runtime.Serialization
 * CSV2Core
 * CSV2Core_MySQL
 */
using System;
using System.Linq;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;
using System.Runtime.Serialization;
using BOp.CatalogAPI;
using BOp.CatalogAPI.data;
using CL1_CMN_PRO;
using CL1_CMN;
using DLCore_DBCommons.Utils;
using CL1_CMN_SLS;
using CL1_CMN_PRO_PAC;
using CL1_CMN_BPT;
using CL1_CMN_COM;
using DLCore_DBCommons.APODemand;
using CL2_Country.Atomic.Retrieval;
using CL3_Taxes.Atomic.Retrieval;
using CL2_Language.Atomic.Retrieval;
using CL3_Taxes.Atomic.Manipulation;
using CL1_ACC_TAX;

namespace CL3_Catalog.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Import_Catalog_and_Create_new_PricelIst_with_Products.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Import_Catalog_and_Create_new_PricelIst_with_Products
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3ICaCnP_1426_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3ICaCnP_1426 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_L3ICaCnP_1426_Array();
            List<L3ICaCnP_1426> ProductList = new List<L3ICaCnP_1426>();
            returnValue.Result = ProductList.ToArray();
            var _service = CatalogServiceFactory.GetSubscriptionService();

            //make data to send to Architecture so that they will know which catalog to update
            var subscriptionRequest = new SubscriptionRequest();
            subscriptionRequest.CatalogCode = Parameter.CatalogCodeITL;
            Customer customer = new Customer();

            // for only Tenant specific cases add Business Participant ID
            if (Parameter.SubscribedBy_BusinessParticipant_RefID != Guid.Empty)
            {
                customer.BusinessParticipantITL = Parameter.SubscribedBy_BusinessParticipant_RefID.ToString();
                
            }
            else
            {
                var customerBPT = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction,
                new ORM_CMN_BPT_BusinessParticipant.Query()
                {
                    IfTenant_Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).Single();

                customer.BusinessParticipantITL = customerBPT.CMN_BPT_BusinessParticipantID.ToString();
            }
            customer.TenantITL = securityTicket.TenantID.ToString();
            customer.Name = Parameter.ClientName;
            customer.SourceRealm = BOp.Infrastructure.PropertyRepository.Instance.RealmID.ToString();
  
            subscriptionRequest.Customer = customer;

            /*
              * @see if catalog with the same ITL for that bussinessParticipant exists
              * */
            var subscribedCatalogQuery = new ORM_CMN_PRO_SubscribedCatalog.Query();
            subscribedCatalogQuery.Tenant_RefID = securityTicket.TenantID;
            subscribedCatalogQuery.CatalogCodeITL = Parameter.CatalogCodeITL;
            if (Parameter.SubscribedBy_BusinessParticipant_RefID != Guid.Empty)
            {
                subscribedCatalogQuery.SubscribedBy_BusinessParticipant_RefID = Parameter.SubscribedBy_BusinessParticipant_RefID;
            }
            subscribedCatalogQuery.IsDeleted = false;

            var subscribedCatalog = ORM_CMN_PRO_SubscribedCatalog.Query.Search(Connection, Transaction, subscribedCatalogQuery).FirstOrDefault();

            #region Get VAT

            var defaultCountryISOCode = cls_Get_DefaultCountryISOCode_for_TenantID.Invoke(Connection, Transaction, securityTicket).Result;

            var param = new P_L3TX_GTfCICaT_1359();
            param.CountryISOCode = "DE";

            
            
            var taxes = cls_Get_Taxes_for_CountryISOCode_and_TenantID.Invoke(Connection, Transaction, param, securityTicket).Result;
            //if there are no taxes for tenant
            Guid countryID = Guid.Empty;
            if (taxes.Length == 0)
            {
                var country = cls_Get_AllCountries_for_TenantID.Invoke(Connection, Transaction, securityTicket).Result.FirstOrDefault();

                if (country != null)
                    countryID = country.CMN_CountryID;
            }
            else
            {
                countryID = taxes.First().CMN_CountryID; // ti slucajni posmatracu ovog koda nemoj zameriti na ovakvom resenju.
            }

            #endregion

            #region save

            if (subscribedCatalog == null)
            {
                /*
                * @save ORM_CMN_PRO_SubscribedCatalog  
                * */
                subscribedCatalog = new ORM_CMN_PRO_SubscribedCatalog();
                subscribedCatalog.CMN_PRO_SubscribedCatalogID = Guid.NewGuid();
                subscribedCatalog.CatalogCodeITL = Parameter.CatalogCodeITL;
                subscribedCatalog.SubscribedCatalog_Name = Parameter.CatalogName;
                subscribedCatalog.SubscribedBy_BusinessParticipant_RefID = Parameter.SubscribedBy_BusinessParticipant_RefID;
                subscribedCatalog.Tenant_RefID = securityTicket.TenantID;
                subscribedCatalog.SubscribedCatalog_ValidFrom = Parameter.ValidFrom_Date;
                subscribedCatalog.SubscribedCatalog_ValidThrough = Parameter.ValidTo_Date;
                subscribedCatalog.SubscribedCatalog_Description = Parameter.CatalogDescription;
                subscribedCatalog.Creation_Timestamp = DateTime.Now;
                subscribedCatalog.IsDeleted = false;
                subscribedCatalog.SubscribedCatalog_CurrentRevision = Parameter.CatalogVersion;
                subscribedCatalog.IsCatalogPublic = Parameter.IsCatalogPublic;

                // check if language with that ISO exists for Tenant (Lower, exmpl de)
                var languageQuery = new ORM_CMN_Language.Query();
                languageQuery.ISO_639_1 = Parameter.CatalogLanguage_ISO_639_1_codes.ToLower();
                languageQuery.Tenant_RefID = securityTicket.TenantID;
                languageQuery.IsDeleted = false;

                var language = ORM_CMN_Language.Query.Search(Connection, Transaction, languageQuery).FirstOrDefault();

                // if language does not exist for that Tenant
                if (language == null)
                {
                    //check if language with that ISO exists for Tenant (Upper exmpl DE)
                    languageQuery = new ORM_CMN_Language.Query();
                    languageQuery.ISO_639_1 = Parameter.CatalogLanguage_ISO_639_1_codes.ToUpper();
                    languageQuery.Tenant_RefID = securityTicket.TenantID;
                    languageQuery.IsDeleted = false;

                    language = ORM_CMN_Language.Query.Search(Connection, Transaction, languageQuery).FirstOrDefault();

                    // if language does not exist for that Tenant
                    if (language == null)
                    {
                        ORM_CMN_Language newLanguage = new ORM_CMN_Language();
                        newLanguage.CMN_LanguageID = Guid.NewGuid();
                        newLanguage.ISO_639_1 = Parameter.CatalogLanguage_ISO_639_1_codes;
                        newLanguage.Creation_Timestamp = DateTime.Now;
                        newLanguage.Tenant_RefID = securityTicket.TenantID;
                        newLanguage.IsDeleted = false;
                        newLanguage.Save(Connection, Transaction);

                        subscribedCatalog.SubscribedCatalog_Language_RefID = newLanguage.CMN_LanguageID;
                    }
                    else
                        subscribedCatalog.SubscribedCatalog_Language_RefID = language.CMN_LanguageID;
                }
                else
                    subscribedCatalog.SubscribedCatalog_Language_RefID = language.CMN_LanguageID;

                // check if currency with that ISO exists for Tenant

                var currencyQuery = new ORM_CMN_Currency.Query();
                currencyQuery.ISO4127 = Parameter.CatalogCurrency_ISO_4217;
                currencyQuery.Tenant_RefID = securityTicket.TenantID;
                currencyQuery.IsDeleted = false;

                var currency = ORM_CMN_Currency.Query.Search(Connection, Transaction, currencyQuery).FirstOrDefault();

                if (currency == null)
                {
                    ORM_CMN_Currency newCurrency = new ORM_CMN_Currency();
                    newCurrency.CMN_CurrencyID = Guid.NewGuid();
                    newCurrency.ISO4127 = Parameter.CatalogCurrency_ISO_4217;
                    newCurrency.Tenant_RefID = securityTicket.TenantID;
                    newCurrency.Creation_Timestamp = DateTime.Now;
                    newCurrency.Save(Connection, Transaction);

                    subscribedCatalog.SubscribedCatalog_Currency_RefID = newCurrency.CMN_CurrencyID;
                }
                else
                    subscribedCatalog.SubscribedCatalog_Currency_RefID = currency.CMN_CurrencyID;

                #region product group
                /*
                * @Search product group
                * */
                ORM_CMN_PRO_ProductGroup productGroup = new ORM_CMN_PRO_ProductGroup();

                var productGroupQuery = new ORM_CMN_PRO_ProductGroup.Query();
                productGroupQuery.Tenant_RefID = securityTicket.TenantID;
                if (Parameter.IsCatalogPublic == false)
                {
                    productGroupQuery.GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(EProductGroup.HauseList);
                }
                else
                {
                    productGroupQuery.GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(EProductGroup.ABDA);
                }
                // for only Tenant specific cases add Business Participant ID
                if (Parameter.SubscribedBy_BusinessParticipant_RefID != Guid.Empty)
                {
                    productGroupQuery.GlobalPropertyMatchingID += Parameter.SubscribedBy_BusinessParticipant_RefID;
                }
                productGroupQuery.IsDeleted = false;

                productGroup = ORM_CMN_PRO_ProductGroup.Query.Search(Connection, Transaction, productGroupQuery).FirstOrDefault();

                if (productGroup == null)
                {
                    /*
                    * @Create product group for products if product group for that BP and Tenent does not exist
                    * */
                    productGroup = new ORM_CMN_PRO_ProductGroup();
                    productGroup.Tenant_RefID = securityTicket.TenantID;
                    productGroup.Creation_Timestamp = DateTime.Now;
                    productGroup.CMN_PRO_ProductGroupID = Guid.NewGuid();
                    productGroup.ProductGroup_Name = new Dict(ORM_CMN_PRO_ProductGroup.TableName);

                    if (Parameter.IsCatalogPublic == false)
                    {
                        productGroup.GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(EProductGroup.HauseList);
                        productGroup.ProductGroup_Name.AddEntry(language.CMN_LanguageID, "HauseList Group");
                    }
                    else
                    {
                        productGroup.GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(EProductGroup.ABDA);
                        productGroup.ProductGroup_Name.AddEntry(language.CMN_LanguageID, "ABDA Group");
                    }
                    // for only Tenant specific cases add Business Participant ID
                    if (Parameter.SubscribedBy_BusinessParticipant_RefID != Guid.Empty)
                    {
                        productGroup.GlobalPropertyMatchingID += Parameter.SubscribedBy_BusinessParticipant_RefID;
                        productGroup.ProductGroup_Name.AddEntry(language.CMN_LanguageID, "HauseList Group");
                    }
                    productGroup.Save(Connection, Transaction);
                }
                #endregion

                #region create priceList for Catalog
                /*
                * @create pricelist_Release
                * */
                ORM_CMN_SLS_Pricelist_Release pricelist_Release = new ORM_CMN_SLS_Pricelist_Release();
                pricelist_Release.CMN_SLS_Pricelist_ReleaseID = Guid.NewGuid();
                pricelist_Release.Release_Version = "v1";
                if (Parameter.IsCatalogPublic == false)
                {
                    pricelist_Release.PricelistRelease_ValidFrom = Parameter.ValidFrom_Date;
                    pricelist_Release.PricelistRelease_ValidTo = Parameter.ValidTo_Date;
                }
                else
                {
                    pricelist_Release.IsPricelistAlwaysActive = true;
                }
                pricelist_Release.Tenant_RefID = securityTicket.TenantID;
                pricelist_Release.Creation_Timestamp = DateTime.Now;
                pricelist_Release.Pricelist_RefID = Guid.NewGuid();//priceList.CMN_SLS_PricelistID
                pricelist_Release.Save(Connection, Transaction);

                /*
                * @create pricelist
                * */
                ORM_CMN_SLS_Pricelist priceList = new ORM_CMN_SLS_Pricelist();
                priceList.CMN_SLS_PricelistID = pricelist_Release.Pricelist_RefID;

                var DBLanguages = cls_Get_All_Languages.Invoke(Connection, Transaction, securityTicket).Result.ToList();

                Dict nameDict = new Dict("cmn_sls_pricelist");
                if (Parameter.IsCatalogPublic == false)
                {
                    for (int i = 0; i < DBLanguages.Count; i++)
                    {
                        nameDict.AddEntry(DBLanguages[i].CMN_LanguageID, Parameter.CatalogName + "_" + Parameter.ValidFrom_Date.ToShortDateString() + "_" + Parameter.ValidTo_Date.ToShortDateString());
                    }
                }
                else
                {
                    for (int i = 0; i < DBLanguages.Count; i++)
                    {
                        nameDict.AddEntry(DBLanguages[i].CMN_LanguageID, "ABDA_PriceList");
                    }
                }
                priceList.Pricelist_Name = nameDict;
                priceList.Tenant_RefID = securityTicket.TenantID;
                priceList.Creation_Timestamp = DateTime.Now;
                priceList.Save(Connection, Transaction);

                #endregion

                if (Parameter.IsCatalogPublic == false)
                {
                    #region create and save products in product group and give product its price , product amout and measure unit

                    /*
                    * @create and save products in product group
                    * */

                    bool isAlreadyInABDA = false;
                    foreach (var item in Parameter.Products)
                    {
                        ORM_CMN_PRO_Product product = new ORM_CMN_PRO_Product();
                            
                        // only for Tenant specific cases add Business Participant ID (!Lucentis)
                        if (Parameter.SubscribedBy_BusinessParticipant_RefID == Guid.Empty)
                        {
                            var productQuery = new ORM_CMN_PRO_Product.Query();
                            productQuery.ProductITL = item.ProductITL;
                            productQuery.Tenant_RefID = securityTicket.TenantID;
                            productQuery.IsDeleted = false;
                            productQuery.IsProductAvailableForOrdering = true;

                            product = ORM_CMN_PRO_Product.Query.Search(Connection, Transaction, productQuery).FirstOrDefault();

                            //if it is not in ABDA
                            if (product == null)
                            {
                                product = new ORM_CMN_PRO_Product();
                                product.CMN_PRO_ProductID = Guid.NewGuid();
                                product.Creation_Timestamp = DateTime.Now;
                                product.Tenant_RefID = securityTicket.TenantID;
                                product.ProductITL = item.ProductITL;
                                product.Product_Name = item.Product_Name;
                                product.Product_Description = item.Product_Description;
                                product.Product_Number = item.Product_Number;
                                product.IsProduct_Article = item.IsProduct_Article;
                                product.IsProductAvailableForOrdering = true;
                                product.PackageInfo_RefID = Guid.NewGuid();//packageInfo.CMN_PRO_PAC_PackageInfoID

                                isAlreadyInABDA = false;
                            }
                            else
                            {
                                isAlreadyInABDA = true;
                            }
                        }
                        else
                        {
                            product.CMN_PRO_ProductID = Guid.NewGuid();
                            product.Creation_Timestamp = DateTime.Now;
                            product.Tenant_RefID = securityTicket.TenantID;
                            product.ProductITL = item.ProductITL;
                            product.Product_Name = item.Product_Name;
                            product.Product_Description = item.Product_Description;
                            product.Product_Number = item.Product_Number;
                            product.IsProduct_Article = item.IsProduct_Article;                       
                            product.IsProductAvailableForOrdering = true;
                            product.PackageInfo_RefID = Guid.NewGuid();//packageInfo.CMN_PRO_PAC_PackageInfoID

                            isAlreadyInABDA = false;
                        }

                        product.IfImportedFromExternalCatalog_CatalogSubscription_RefID = subscribedCatalog.CMN_PRO_SubscribedCatalogID;
                        product.Save(Connection, Transaction);

                        L3ICaCnP_1426 pro = new L3ICaCnP_1426();
                        pro.ProductID = product.CMN_PRO_ProductID;
                        if (product.IsProduct_Article) pro.Dosage = item.Dosage;
                            pro.isEdit = false;
                        ProductList.Add(pro);

                        ORM_CMN_PRO_Product_2_ProductGroup product_2_productGroup = new ORM_CMN_PRO_Product_2_ProductGroup();
                        product_2_productGroup.CMN_PRO_Product_RefID = product.CMN_PRO_ProductID;
                        product_2_productGroup.CMN_PRO_ProductGroup_RefID = productGroup.CMN_PRO_ProductGroupID;
                        product_2_productGroup.Tenant_RefID = securityTicket.TenantID;
                        product_2_productGroup.Creation_Timestamp = DateTime.Now;
                        product_2_productGroup.Save(Connection, Transaction);

                        if (isAlreadyInABDA == false)
                        {
                            ORM_CMN_SLS_Price price = new ORM_CMN_SLS_Price();
                            price.CMN_SLS_PriceID = Guid.NewGuid();
                            price.Tenant_RefID = securityTicket.TenantID;
                            price.Creation_Timestamp = DateTime.Now;
                            price.PricelistRelease_RefID = pricelist_Release.CMN_SLS_Pricelist_ReleaseID;
                            price.CMN_PRO_Product_RefID = product.CMN_PRO_ProductID;
                            price.PriceAmount = item.Price;
                            price.CMN_Currency_RefID = subscribedCatalog.SubscribedCatalog_Currency_RefID;
                            price.Save(Connection, Transaction);

                            //add amount and Measure
                            ORM_CMN_PRO_PAC_PackageInfo packageInfo = new ORM_CMN_PRO_PAC_PackageInfo();
                            packageInfo.CMN_PRO_PAC_PackageInfoID = product.PackageInfo_RefID;
                            packageInfo.Tenant_RefID = securityTicket.TenantID;
                            packageInfo.Creation_Timestamp = DateTime.Now;
                            packageInfo.PackageContent_Amount = item.Amount;

                            //check if MeasureUnit exists for this Tenant
                            var unitsQuery = new ORM_CMN_Unit.Query();
                            unitsQuery.Tenant_RefID = securityTicket.TenantID;
                            unitsQuery.ISOCode = item.MeasuredInUnit_ISO_um_ums;
                            unitsQuery.IsDeleted = false;

                            var measuredInUnit = ORM_CMN_Unit.Query.Search(Connection, Transaction, unitsQuery).FirstOrDefault();
                            if (measuredInUnit == null)
                            {
                                ORM_CMN_Unit newMeasuredInUnit = new ORM_CMN_Unit();
                                newMeasuredInUnit.Tenant_RefID = securityTicket.TenantID;
                                newMeasuredInUnit.Creation_Timestamp = DateTime.Now;
                                newMeasuredInUnit.ISOCode = item.MeasuredInUnit_ISO_um_ums;
                                newMeasuredInUnit.CMN_UnitID = Guid.NewGuid();
                                newMeasuredInUnit.Save(Connection, Transaction);

                                packageInfo.PackageContent_MeasuredInUnit_RefID = newMeasuredInUnit.CMN_UnitID;
                            }
                            else
                                packageInfo.PackageContent_MeasuredInUnit_RefID = measuredInUnit.CMN_UnitID;

                            packageInfo.Save(Connection, Transaction);

                            if (countryID != Guid.Empty)// if there is a country for this Tenant
                            {
                                #region Create Taxes

                                double productVAT = 0;
                                Double.TryParse(item.VAT, out productVAT);

                                var tax = taxes.Where(i => i.TaxRate == productVAT).SingleOrDefault();

                                if (tax == default(L3TX_GTfCICaT_1359))
                                {
                                    #region CreateTax

                                    var saveTaxParam = new P_L3TX_STX_1119();
                                    saveTaxParam.ACC_TAX_TaxeID = Guid.Empty;
                                    saveTaxParam.TaxName = new Dict(ORM_ACC_TAX_Tax.TableName);
                                    saveTaxParam.TaxName.AddEntry(language.CMN_LanguageID, productVAT.ToString());
                                    saveTaxParam.TaxRate = productVAT;
                                    if (taxes.Length != 0)
                                    {
                                        saveTaxParam.EconomicRegion_RefID = taxes.First().CMN_EconomicRegionID;
                                        saveTaxParam.Country_RefID = taxes.First().CMN_CountryID;
                                    }
                                    else
                                    {
                                        saveTaxParam.EconomicRegion_RefID = Guid.Empty;
                                        saveTaxParam.Country_RefID = countryID;
                                    }
                                    var saveTaxResult = cls_Save_Tax.Invoke(Connection, Transaction, saveTaxParam, securityTicket).Result;

                                    #endregion

                                    #region Update Available taxes

                                    param = new P_L3TX_GTfCICaT_1359();
                                    param.CountryISOCode = "DE";

                                    taxes = cls_Get_Taxes_for_CountryISOCode_and_TenantID.Invoke(Connection, Transaction, param, securityTicket).Result;

                                    tax = taxes.Where(i => i.TaxRate == productVAT).SingleOrDefault();

                                    #endregion

                                }

                                var salesTax = new ORM_CMN_PRO_Product_SalesTaxAssignmnet();
                                salesTax.CMN_PRO_Product_SalesTaxAssignmnetID = Guid.NewGuid();
                                salesTax.Product_RefID = product.CMN_PRO_ProductID;
                                salesTax.ApplicableSalesTax_RefID = tax.ACC_TAX_TaxeID;
                                salesTax.Creation_Timestamp = DateTime.Now;
                                salesTax.Tenant_RefID = securityTicket.TenantID;
                                salesTax.Save(Connection, Transaction);

                                #endregion
                            }
                        }
                    }
                    #endregion
                }
                /*
                * @See if Supplier already exists in database
                * */
                ORM_CMN_BPT_Supplier supplier = new ORM_CMN_BPT_Supplier();

                var supplierQuery = new ORM_CMN_BPT_BusinessParticipant.Query();
                supplierQuery.BusinessParticipantITL = Parameter.SupplierData.SupplierITL;
                supplierQuery.Tenant_RefID = securityTicket.TenantID;
                supplierQuery.IsDeleted = false;

                var supplier_bussinessParticipant = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, supplierQuery).FirstOrDefault();

                #region if supplier does not exist

                if (supplier_bussinessParticipant == null)
                {
                    /*
                     * @Make Supplier Data
                     * */

                    var tenantQuery = new ORM_CMN_Tenant.Query()
                    {
                        TenantITL = Parameter.SupplierData.TenantITL,
                        Tenant_RefID = securityTicket.TenantID
                    };

                    var supplierTenant = ORM_CMN_Tenant.Query.Search(Connection, Transaction, tenantQuery).SingleOrDefault();

                    if (supplierTenant == default(ORM_CMN_Tenant))
                    {
                        supplierTenant = new ORM_CMN_Tenant();
                        supplierTenant.CMN_TenantID = Guid.NewGuid();
                        supplierTenant.TenantITL = Parameter.SupplierData.TenantITL;
                        supplierTenant.Tenant_RefID = securityTicket.TenantID;
                        supplierTenant.Creation_Timestamp = DateTime.Now;
                        supplierTenant.Save(Connection, Transaction);
                    }

                    supplier.CMN_BPT_SupplierID = Guid.NewGuid();
                    supplier.Ext_BusinessParticipant_RefID = Guid.NewGuid();//supplierBussinessParticipant.CMN_BPT_BusinessParticipantID
                    supplier.Creation_Timestamp = DateTime.Now;
                    supplier.IsDeleted = false;
                    supplier.Tenant_RefID = securityTicket.TenantID;
                    supplier.Save(Connection, Transaction);

                    ORM_CMN_BPT_BusinessParticipant supplierBussinessParticipant = new ORM_CMN_BPT_BusinessParticipant();
                    supplierBussinessParticipant.CMN_BPT_BusinessParticipantID = supplier.Ext_BusinessParticipant_RefID;
                    supplierBussinessParticipant.DisplayName = Parameter.SupplierData.Supplier_Name;
                    supplierBussinessParticipant.BusinessParticipantITL = Parameter.SupplierData.SupplierITL;
                    supplierBussinessParticipant.Creation_Timestamp = DateTime.Now;
                    supplierBussinessParticipant.Tenant_RefID = securityTicket.TenantID;
                    supplierBussinessParticipant.IsCompany = true;
                    supplierBussinessParticipant.IsTenant = true;
                    supplierBussinessParticipant.IfTenant_Tenant_RefID = supplierTenant.CMN_TenantID;
                    supplierBussinessParticipant.IfCompany_CMN_COM_CompanyInfo_RefID = Guid.NewGuid();//companyInfo.CMN_COM_CompanyInfoID 
                    supplierBussinessParticipant.Save(Connection, Transaction);

                    ORM_CMN_COM_CompanyInfo companyInfo = new ORM_CMN_COM_CompanyInfo();
                    companyInfo.CMN_COM_CompanyInfoID = supplierBussinessParticipant.IfCompany_CMN_COM_CompanyInfo_RefID;
                    companyInfo.Creation_Timestamp = DateTime.Now;
                    companyInfo.Tenant_RefID = securityTicket.TenantID;
                    companyInfo.Contact_UCD_RefID = Guid.NewGuid();//universalContactDetail.CMN_UniversalContactDetailID
                    companyInfo.Save(Connection, Transaction);

                    ORM_CMN_UniversalContactDetail universalContactDetail = new ORM_CMN_UniversalContactDetail();
                    universalContactDetail.CMN_UniversalContactDetailID = companyInfo.Contact_UCD_RefID;
                    universalContactDetail.IsCompany = true;
                    universalContactDetail.Country_639_1_ISOCode = Parameter.SupplierData.CountryISO;
                    universalContactDetail.Street_Name = Parameter.SupplierData.Supplier_Name;
                    universalContactDetail.Street_Number = Parameter.SupplierData.Street_Number;
                    universalContactDetail.ZIP = Parameter.SupplierData.ZIP;
                    universalContactDetail.Town = Parameter.SupplierData.Town;
                    universalContactDetail.Region_Code = Parameter.SupplierData.Region_Code;
                    universalContactDetail.Tenant_RefID = securityTicket.TenantID;
                    universalContactDetail.Creation_Timestamp = DateTime.Now;
                    universalContactDetail.Save(Connection, Transaction);
                }
                #endregion
                #region if supplier exists , check if its data is changed
                else
                {

                    var tenantQuery = new ORM_CMN_Tenant.Query()
                    {
                        TenantITL = Parameter.SupplierData.TenantITL,
                        Tenant_RefID = securityTicket.TenantID
                    };

                    var supplierTenant = ORM_CMN_Tenant.Query.Search(Connection, Transaction, tenantQuery).SingleOrDefault();

                    if (supplierTenant == default(ORM_CMN_Tenant))
                    {
                        supplierTenant = new ORM_CMN_Tenant();
                        supplierTenant.CMN_TenantID = Guid.NewGuid();
                        supplierTenant.TenantITL = Parameter.SupplierData.TenantITL;
                        supplierTenant.Tenant_RefID = securityTicket.TenantID;
                        supplierTenant.Creation_Timestamp = DateTime.Now;
                        supplierTenant.Save(Connection, Transaction);

                        supplier_bussinessParticipant.IsTenant = true;
                        supplier_bussinessParticipant.IfTenant_Tenant_RefID = supplierTenant.CMN_TenantID;
                    }

                    supplier_bussinessParticipant.DisplayName = Parameter.SupplierData.Supplier_Name;
                    supplier_bussinessParticipant.Save(Connection, Transaction);

                    var query = new ORM_CMN_BPT_Supplier.Query();
                    query.Ext_BusinessParticipant_RefID = supplier_bussinessParticipant.CMN_BPT_BusinessParticipantID;
                    query.Tenant_RefID = securityTicket.TenantID;
                    query.IsDeleted = false;

                    supplier = ORM_CMN_BPT_Supplier.Query.Search(Connection, Transaction, query).First();

                    //edit universal contact details

                    var companyInfoQuery = new ORM_CMN_COM_CompanyInfo.Query();
                    companyInfoQuery.CMN_COM_CompanyInfoID = supplier_bussinessParticipant.IfCompany_CMN_COM_CompanyInfo_RefID;
                    companyInfoQuery.Tenant_RefID = securityTicket.TenantID;
                    companyInfoQuery.IsDeleted = false;

                    var companyInfo = ORM_CMN_COM_CompanyInfo.Query.Search(Connection, Transaction, companyInfoQuery).First();

                    var universalContactDetailQuery = new ORM_CMN_UniversalContactDetail.Query();
                    universalContactDetailQuery.CMN_UniversalContactDetailID = companyInfo.Contact_UCD_RefID;
                    universalContactDetailQuery.Tenant_RefID = securityTicket.TenantID;
                    universalContactDetailQuery.IsDeleted = false;

                    var universalContactDetail = ORM_CMN_UniversalContactDetail.Query.Search(Connection, Transaction, universalContactDetailQuery).First();

                    universalContactDetail.Country_639_1_ISOCode = Parameter.SupplierData.CountryISO;
                    universalContactDetail.Street_Name = Parameter.SupplierData.Supplier_Name;
                    universalContactDetail.Street_Number = Parameter.SupplierData.Street_Number;
                    universalContactDetail.ZIP = Parameter.SupplierData.ZIP;
                    universalContactDetail.Town = Parameter.SupplierData.Town;
                    universalContactDetail.Region_Code = Parameter.SupplierData.Region_Code;
                    universalContactDetail.Save(Connection, Transaction);

                }
                #endregion

                subscribedCatalog.SubscribedCatalog_PricelistRelease_RefID = pricelist_Release.CMN_SLS_Pricelist_ReleaseID;
                subscribedCatalog.PublishingSupplier_RefID = supplier.CMN_BPT_SupplierID;
                subscribedCatalog.Save(Connection, Transaction);

                /*
                * @send Kika information which catalog has been subscribed to who
                * */       
                var result = _service.SubscribeToCatalog(subscriptionRequest);

                if (result.ResponseStatus != ResponseStatus.OK)
                    throw new Exception("Catalog subscription failed!");

            }
            #endregion
                
            #region edit
            else
            {
                #region delete catalog

                if (Parameter.isDeleted == true)
                {
                    /*
                    * @delete ORM_CMN_PRO_SubscribedCatalog
                     * */
                    subscribedCatalog.IsDeleted = true;
                    subscribedCatalog.Save(Connection, Transaction);

                    /*
                     * @all products from this catalog are not available anymore
                     * */
                    var productQuery = new ORM_CMN_PRO_Product.Query();
                    productQuery.Tenant_RefID = securityTicket.TenantID;
                    productQuery.IfImportedFromExternalCatalog_CatalogSubscription_RefID = subscribedCatalog.CMN_PRO_SubscribedCatalogID;
                    productQuery.IsDeleted = false;

                    var productList = ORM_CMN_PRO_Product.Query.Search(Connection, Transaction, productQuery).ToList();

                    foreach (var product in productList)
                    {
                        product.IsProductAvailableForOrdering = false;
                        product.Save(Connection, Transaction);
                    }

                    /*
                   * @delete priceList and all products prices
                    * */

                    var priceReleaseQuery = new ORM_CMN_SLS_Pricelist_Release.Query();
                    priceReleaseQuery.Tenant_RefID = securityTicket.TenantID;
                    priceReleaseQuery.CMN_SLS_Pricelist_ReleaseID = subscribedCatalog.SubscribedCatalog_PricelistRelease_RefID;
                    priceReleaseQuery.IsDeleted = false;

                    var priceRelease = ORM_CMN_SLS_Pricelist_Release.Query.Search(Connection, Transaction, priceReleaseQuery).First();
                    priceRelease.IsDeleted = true;

                    var priceListQuery = new ORM_CMN_SLS_Pricelist.Query();
                    priceListQuery.Tenant_RefID = securityTicket.TenantID;
                    priceListQuery.CMN_SLS_PricelistID = priceRelease.Pricelist_RefID;
                    priceListQuery.IsDeleted = false;

                    var priceList = ORM_CMN_SLS_Pricelist.Query.Search(Connection, Transaction, priceListQuery).First();
                    priceList.IsDeleted = true;
                    priceList.Save(Connection, Transaction);

                    var priceQuery = new ORM_CMN_SLS_Price.Query();
                    priceQuery.Tenant_RefID = securityTicket.TenantID;
                    priceQuery.PricelistRelease_RefID = priceRelease.Pricelist_RefID;
                    priceQuery.IsDeleted = false;

                    var prices = ORM_CMN_SLS_Price.Query.Search(Connection, Transaction, priceQuery).ToList();

                    foreach (var price in prices)
                    {
                        price.IsDeleted = true;
                        price.Save(Connection, Transaction);
                    }

                    priceRelease.Save(Connection, Transaction);

                    //send to Kika so he will know which catalog has got unsubscribed
                    var result = _service.UnsubscribeFromCatalog(subscriptionRequest);
                }

                #endregion
                else
                {

                    /*
                    * @edit ORM_CMN_PRO_SubscribedCatalog
                    * */
                    subscribedCatalog.SubscribedCatalog_Name = Parameter.CatalogName;
                    subscribedCatalog.SubscribedCatalog_ValidFrom = Parameter.ValidFrom_Date;
                    subscribedCatalog.SubscribedCatalog_ValidThrough = Parameter.ValidTo_Date;
                    subscribedCatalog.SubscribedCatalog_Description = Parameter.CatalogDescription;

                    subscribedCatalog.SubscribedCatalog_CurrentRevision = Parameter.CatalogVersion;

                    // check if language with that ISO exists for Tenant (Lower, exmpl de)
                    var languageQuery = new ORM_CMN_Language.Query();
                    languageQuery.ISO_639_1 = Parameter.CatalogLanguage_ISO_639_1_codes.ToLower();
                    languageQuery.Tenant_RefID = securityTicket.TenantID;
                    languageQuery.IsDeleted = false;

                    var language = ORM_CMN_Language.Query.Search(Connection, Transaction, languageQuery).FirstOrDefault();

                    // if language does not exist for that Tenant
                    if (language == null)
                    {
                        //check if language with that ISO exists for Tenant (Upper exmpl DE)
                        languageQuery = new ORM_CMN_Language.Query();
                        languageQuery.ISO_639_1 = Parameter.CatalogLanguage_ISO_639_1_codes.ToUpper();
                        languageQuery.Tenant_RefID = securityTicket.TenantID;
                        languageQuery.IsDeleted = false;

                        language = ORM_CMN_Language.Query.Search(Connection, Transaction, languageQuery).FirstOrDefault();

                        // if language does not exist for that Tenant
                        if (language == null)
                        {
                            ORM_CMN_Language newLanguage = new ORM_CMN_Language();
                            newLanguage.CMN_LanguageID = Guid.NewGuid();
                            newLanguage.ISO_639_1 = Parameter.CatalogLanguage_ISO_639_1_codes;
                            newLanguage.Creation_Timestamp = DateTime.Now;
                            newLanguage.Tenant_RefID = securityTicket.TenantID;
                            newLanguage.IsDeleted = false;
                            newLanguage.Save(Connection, Transaction);

                            subscribedCatalog.SubscribedCatalog_Language_RefID = newLanguage.CMN_LanguageID;
                        }
                        else
                            subscribedCatalog.SubscribedCatalog_Language_RefID = language.CMN_LanguageID;
                    }
                    else
                        subscribedCatalog.SubscribedCatalog_Language_RefID = language.CMN_LanguageID;

                    // check if currency with that ISO exists for Tenant

                    var currencyQuery = new ORM_CMN_Currency.Query();
                    currencyQuery.ISO4127 = Parameter.CatalogCurrency_ISO_4217;
                    currencyQuery.Tenant_RefID = securityTicket.TenantID;
                    currencyQuery.IsDeleted = false;

                    var currency = ORM_CMN_Currency.Query.Search(Connection, Transaction, currencyQuery).FirstOrDefault();

                    if (currency == null)
                    {
                        ORM_CMN_Currency newCurrency = new ORM_CMN_Currency();
                        newCurrency.CMN_CurrencyID = Guid.NewGuid();
                        newCurrency.ISO4127 = Parameter.CatalogCurrency_ISO_4217;
                        newCurrency.Tenant_RefID = securityTicket.TenantID;
                        newCurrency.Creation_Timestamp = DateTime.Now;
                        newCurrency.Save(Connection, Transaction);

                        subscribedCatalog.SubscribedCatalog_Currency_RefID = newCurrency.CMN_CurrencyID;
                    }
                    else
                        subscribedCatalog.SubscribedCatalog_Currency_RefID = currency.CMN_CurrencyID;

                    subscribedCatalog.Save(Connection, Transaction);

                    #region edit products

                    /*
               * @edit product in the correct productGroup, find product by its ITL code and product group GlobalPropertyMatchingID
               * */
                    var productGroupQuery = new ORM_CMN_PRO_ProductGroup.Query();
                    productGroupQuery.Tenant_RefID = securityTicket.TenantID;
                    if (Parameter.IsCatalogPublic == false)
                    {
                        productGroupQuery.GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(EProductGroup.HauseList);
                    }
                    else
                    {
                        productGroupQuery.GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(EProductGroup.ABDA);
                    }
                    // for only Tenant specific cases add Business Participant ID
                    if (Parameter.SubscribedBy_BusinessParticipant_RefID != Guid.Empty)
                    {
                        productGroupQuery.GlobalPropertyMatchingID += Parameter.SubscribedBy_BusinessParticipant_RefID;
                    }

                    productGroupQuery.IsDeleted = false;

                    var productGroup = ORM_CMN_PRO_ProductGroup.Query.Search(Connection, Transaction, productGroupQuery).FirstOrDefault();

                    foreach (var item in Parameter.Products)
                    {
                        var pricelist_ReleaseQuery = new ORM_CMN_SLS_Pricelist_Release.Query();
                        pricelist_ReleaseQuery.Tenant_RefID = securityTicket.TenantID;
                        pricelist_ReleaseQuery.IsDeleted = false;
                        pricelist_ReleaseQuery.CMN_SLS_Pricelist_ReleaseID = subscribedCatalog.SubscribedCatalog_PricelistRelease_RefID;

                        var pricelist_Release = ORM_CMN_SLS_Pricelist_Release.Query.Search(Connection, Transaction, pricelist_ReleaseQuery).First();

                        var productQuery = new ORM_CMN_PRO_Product.Query();
                        productQuery.ProductITL = item.ProductITL;
                        productQuery.Tenant_RefID = securityTicket.TenantID;
                        productQuery.IfImportedFromExternalCatalog_CatalogSubscription_RefID = subscribedCatalog.CMN_PRO_SubscribedCatalogID;
                        productQuery.IsDeleted = false;
                        productQuery.IsProductAvailableForOrdering = true;

                        var product = ORM_CMN_PRO_Product.Query.Search(Connection, Transaction, productQuery).FirstOrDefault();

                        #region if product exists

                        if (product != null)
                        {
                            product.Product_Name = item.Product_Name;
                            product.Product_Description = item.Product_Description;
                            product.Product_Number = item.Product_Number;
                            product.Save(Connection, Transaction);

                            L3ICaCnP_1426 pro = new L3ICaCnP_1426();
                            pro.ProductID = product.CMN_PRO_ProductID;
                            if (product.IsProduct_Article) pro.Dosage = item.Dosage;
                            pro.isEdit = true;
                            ProductList.Add(pro);

                            //update price
                            var priceQuery = new ORM_CMN_SLS_Price.Query();
                            priceQuery.Tenant_RefID = securityTicket.TenantID;
                            priceQuery.CMN_PRO_Product_RefID = product.CMN_PRO_ProductID;
                            priceQuery.IsDeleted = false;

                            var price = ORM_CMN_SLS_Price.Query.Search(Connection, Transaction, priceQuery).First();
                            price.PriceAmount = item.Price;
                            price.Save(Connection, Transaction);

                            //update package info (amount and price)
                            var packageInfoQuery = new ORM_CMN_PRO_PAC_PackageInfo.Query();
                            packageInfoQuery.CMN_PRO_PAC_PackageInfoID = product.PackageInfo_RefID;
                            packageInfoQuery.Tenant_RefID = securityTicket.TenantID;
                            packageInfoQuery.IsDeleted = false;

                            var packageInfo = ORM_CMN_PRO_PAC_PackageInfo.Query.Search(Connection, Transaction, packageInfoQuery).First();

                            packageInfo.PackageContent_Amount = item.Amount;

                            var unitQuery = new ORM_CMN_Unit.Query();
                            unitQuery.Tenant_RefID = securityTicket.TenantID;
                            unitQuery.CMN_UnitID = packageInfo.PackageContent_MeasuredInUnit_RefID;
                            unitQuery.ISOCode = item.MeasuredInUnit_ISO_um_ums;
                            unitQuery.IsDeleted = false;

                            var unit = ORM_CMN_Unit.Query.Search(Connection, Transaction, unitQuery).FirstOrDefault();

                            if (unit == null)//Measure unit was changed!
                            {
                                var rightUnitQuery = new ORM_CMN_Unit.Query();
                                rightUnitQuery.Tenant_RefID = securityTicket.TenantID;
                                rightUnitQuery.ISOCode = item.MeasuredInUnit_ISO_um_ums;
                                rightUnitQuery.IsDeleted = false;

                                var rightUnit = ORM_CMN_Unit.Query.Search(Connection, Transaction, rightUnitQuery).FirstOrDefault();

                                if (rightUnit == null)
                                {
                                    ORM_CMN_Unit newMeasuredInUnit = new ORM_CMN_Unit();
                                    newMeasuredInUnit.Tenant_RefID = securityTicket.TenantID;
                                    newMeasuredInUnit.Creation_Timestamp = DateTime.Now;
                                    newMeasuredInUnit.ISOCode = item.MeasuredInUnit_ISO_um_ums;
                                    newMeasuredInUnit.CMN_UnitID = Guid.NewGuid();
                                    newMeasuredInUnit.Save(Connection, Transaction);

                                    packageInfo.PackageContent_MeasuredInUnit_RefID = newMeasuredInUnit.CMN_UnitID;
                                }
                                else
                                    packageInfo.PackageContent_MeasuredInUnit_RefID = rightUnit.CMN_UnitID;
                            }
                            // else measure unit stays the same

                            packageInfo.Save(Connection, Transaction);

                            if (countryID != Guid.Empty)
                            {
                                #region Update Taxes

                                double productVAT = 0;
                                Double.TryParse(item.VAT, out productVAT);

                                var tax = taxes.Where(i => i.TaxRate == productVAT).SingleOrDefault();

                                if (tax == default(L3TX_GTfCICaT_1359))
                                {
                                    #region CreateTax

                                    var saveTaxParam = new P_L3TX_STX_1119();
                                    saveTaxParam.ACC_TAX_TaxeID = Guid.Empty;
                                    saveTaxParam.EconomicRegion_RefID = taxes.First().CMN_EconomicRegionID;
                                    saveTaxParam.Country_RefID = taxes.First().CMN_CountryID;
                                    saveTaxParam.TaxName = new Dict(ORM_ACC_TAX_Tax.TableName);
                                    saveTaxParam.TaxName.AddEntry(language.CMN_LanguageID, productVAT.ToString());

                                    var saveTaxResult = cls_Save_Tax.Invoke(Connection, Transaction, saveTaxParam, securityTicket).Result;

                                    #endregion

                                    #region Update Available taxes

                                    param = new P_L3TX_GTfCICaT_1359();
                                    param.CountryISOCode = "DE";

                                    taxes = cls_Get_Taxes_for_CountryISOCode_and_TenantID.Invoke(Connection, Transaction, param, securityTicket).Result;

                                    tax = taxes.Where(i => i.TaxRate == productVAT).SingleOrDefault();

                                    #endregion

                                }

                                var salesTaxQuery = new ORM_CMN_PRO_Product_SalesTaxAssignmnet.Query();
                                salesTaxQuery.Tenant_RefID = securityTicket.TenantID;
                                salesTaxQuery.Product_RefID = product.CMN_PRO_ProductID;
                                salesTaxQuery.IsDeleted = false;

                                var salesTax = ORM_CMN_PRO_Product_SalesTaxAssignmnet.Query.Search(Connection, Transaction, salesTaxQuery).Single();
                                salesTax.ApplicableSalesTax_RefID = tax.ACC_TAX_TaxeID;
                                salesTax.Save(Connection, Transaction);

                                #endregion
                            }

                        }
                        #endregion

                        #region if not, create a product  and it's price
                        else
                        {
                            ORM_CMN_PRO_Product productNew = new ORM_CMN_PRO_Product();
                            productNew.CMN_PRO_ProductID = Guid.NewGuid();
                            productNew.Creation_Timestamp = DateTime.Now;
                            productNew.Tenant_RefID = securityTicket.TenantID;
                            productNew.ProductITL = item.ProductITL;
                            productNew.Product_Name = item.Product_Name;
                            productNew.Product_Description = item.Product_Description;
                            productNew.Product_Number = item.Product_Number;
                            productNew.IsProductAvailableForOrdering = true;
                            productNew.IsProduct_Article = item.IsProduct_Article;
                            productNew.IfImportedFromExternalCatalog_CatalogSubscription_RefID = subscribedCatalog.CMN_PRO_SubscribedCatalogID;
                            productNew.PackageInfo_RefID = Guid.NewGuid();//packageInfo.CMN_PRO_PAC_PackageInfoID
                            productNew.Save(Connection, Transaction);

                            L3ICaCnP_1426 pro = new L3ICaCnP_1426();
                            pro.ProductID = productNew.CMN_PRO_ProductID;
                            if (productNew.IsProduct_Article) pro.Dosage = item.Dosage;
                            pro.isEdit = false;
                            ProductList.Add(pro);

                            /*
                            * @add new product to product group
                            * */
                            ORM_CMN_PRO_Product_2_ProductGroup product_2_productGroup = new ORM_CMN_PRO_Product_2_ProductGroup();
                            product_2_productGroup.CMN_PRO_Product_RefID = productNew.CMN_PRO_ProductID;
                            product_2_productGroup.CMN_PRO_ProductGroup_RefID = productGroup.CMN_PRO_ProductGroupID;
                            product_2_productGroup.Tenant_RefID = securityTicket.TenantID;
                            product_2_productGroup.Creation_Timestamp = DateTime.Now;
                            product_2_productGroup.Save(Connection, Transaction);

                            /*
                           * @add price to product
                           * */
                            ORM_CMN_SLS_Price price = new ORM_CMN_SLS_Price();
                            price.CMN_SLS_PriceID = Guid.NewGuid();
                            price.Tenant_RefID = securityTicket.TenantID;
                            price.Creation_Timestamp = DateTime.Now;
                            price.PricelistRelease_RefID = pricelist_Release.CMN_SLS_Pricelist_ReleaseID;
                            price.CMN_PRO_Product_RefID = productNew.CMN_PRO_ProductID;
                            price.PriceAmount = item.Price;
                            price.CMN_Currency_RefID = subscribedCatalog.SubscribedCatalog_Currency_RefID;
                            price.Save(Connection, Transaction);

                            //add amount and Measure
                            ORM_CMN_PRO_PAC_PackageInfo packageInfo = new ORM_CMN_PRO_PAC_PackageInfo();
                            packageInfo.CMN_PRO_PAC_PackageInfoID = productNew.PackageInfo_RefID;
                            packageInfo.Tenant_RefID = securityTicket.TenantID;
                            packageInfo.Creation_Timestamp = DateTime.Now;
                            packageInfo.PackageContent_Amount = item.Amount;

                            //check if MeasureUnit exists for this Tenant

                            var unitsQuery = new ORM_CMN_Unit.Query();
                            unitsQuery.Tenant_RefID = securityTicket.TenantID;
                            unitsQuery.ISOCode = item.MeasuredInUnit_ISO_um_ums;
                            unitsQuery.IsDeleted = false;

                            var measuredInUnit = ORM_CMN_Unit.Query.Search(Connection, Transaction, unitsQuery).FirstOrDefault();

                            if (measuredInUnit == null)
                            {
                                ORM_CMN_Unit newMeasuredInUnit = new ORM_CMN_Unit();
                                newMeasuredInUnit.Tenant_RefID = securityTicket.TenantID;
                                newMeasuredInUnit.Creation_Timestamp = DateTime.Now;
                                newMeasuredInUnit.ISOCode = item.MeasuredInUnit_ISO_um_ums;
                                newMeasuredInUnit.CMN_UnitID = Guid.NewGuid();
                                newMeasuredInUnit.Save(Connection, Transaction);

                                packageInfo.PackageContent_MeasuredInUnit_RefID = newMeasuredInUnit.CMN_UnitID;
                            }
                            else
                                packageInfo.PackageContent_MeasuredInUnit_RefID = measuredInUnit.CMN_UnitID;

                            packageInfo.Save(Connection, Transaction);

                            #region Create Taxes

                            double productVAT = 0;
                            Double.TryParse(item.VAT, out productVAT);

                            var tax = taxes.Where(i => i.TaxRate == productVAT).SingleOrDefault();

                            if (tax == default(L3TX_GTfCICaT_1359))
                            {
                                #region CreateTax

                                var saveTaxParam = new P_L3TX_STX_1119();
                                saveTaxParam.ACC_TAX_TaxeID = Guid.Empty;
                                saveTaxParam.EconomicRegion_RefID = taxes.First().CMN_EconomicRegionID;
                                saveTaxParam.Country_RefID = taxes.First().CMN_CountryID;
                                saveTaxParam.TaxName = new Dict(ORM_ACC_TAX_Tax.TableName);
                                saveTaxParam.TaxName.AddEntry(language.CMN_LanguageID, productVAT.ToString());

                                var saveTaxResult = cls_Save_Tax.Invoke(Connection, Transaction, saveTaxParam, securityTicket).Result;

                                #endregion

                                #region Update Available taxes

                                param = new P_L3TX_GTfCICaT_1359();
                                param.CountryISOCode = defaultCountryISOCode.Country_639_1_ISOCode;

                                taxes = cls_Get_Taxes_for_CountryISOCode_and_TenantID.Invoke(Connection, Transaction, param, securityTicket).Result;

                                tax = taxes.Where(i => i.TaxRate == productVAT).SingleOrDefault();

                                #endregion

                            }

                            var salesTax = new ORM_CMN_PRO_Product_SalesTaxAssignmnet();
                            salesTax.CMN_PRO_Product_SalesTaxAssignmnetID = Guid.NewGuid();
                            salesTax.Product_RefID = product.CMN_PRO_ProductID;
                            salesTax.ApplicableSalesTax_RefID = tax.ACC_TAX_TaxeID;
                            salesTax.Creation_Timestamp = DateTime.Now;
                            salesTax.Tenant_RefID = securityTicket.TenantID;
                            salesTax.Save(Connection, Transaction);

                            #endregion
                        }
                        #endregion
                    }
                    #endregion

                    #region edit supplier

                    /*
               * @edit supplier
               * */

                    var supplierQuery = new ORM_CMN_BPT_BusinessParticipant.Query();
                    supplierQuery.BusinessParticipantITL = Parameter.SupplierData.SupplierITL;
                    supplierQuery.Tenant_RefID = securityTicket.TenantID;
                    supplierQuery.IsDeleted = false;

                    var supplier_bussinessParticipant = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, supplierQuery).FirstOrDefault();

                    supplier_bussinessParticipant.DisplayName = Parameter.SupplierData.Supplier_Name;
                    supplier_bussinessParticipant.Save(Connection, Transaction);

                    //edit universal contact details

                    var companyInfoQuery = new ORM_CMN_COM_CompanyInfo.Query();
                    companyInfoQuery.CMN_COM_CompanyInfoID = supplier_bussinessParticipant.IfCompany_CMN_COM_CompanyInfo_RefID;
                    companyInfoQuery.Tenant_RefID = securityTicket.TenantID;
                    companyInfoQuery.IsDeleted = false;

                    var companyInfo = ORM_CMN_COM_CompanyInfo.Query.Search(Connection, Transaction, companyInfoQuery).First();

                    var universalContactDetailQuery = new ORM_CMN_UniversalContactDetail.Query();
                    universalContactDetailQuery.CMN_UniversalContactDetailID = companyInfo.Contact_UCD_RefID;
                    universalContactDetailQuery.Tenant_RefID = securityTicket.TenantID;
                    universalContactDetailQuery.IsDeleted = false;

                    var universalContactDetail = ORM_CMN_UniversalContactDetail.Query.Search(Connection, Transaction, universalContactDetailQuery).First();

                    universalContactDetail.Country_639_1_ISOCode = Parameter.SupplierData.CountryISO;
                    universalContactDetail.Street_Name = Parameter.SupplierData.Supplier_Name;
                    universalContactDetail.Street_Number = Parameter.SupplierData.Street_Number;
                    universalContactDetail.ZIP = Parameter.SupplierData.ZIP;
                    universalContactDetail.Town = Parameter.SupplierData.Town;
                    universalContactDetail.Region_Code = Parameter.SupplierData.Region_Code;
                    universalContactDetail.Save(Connection, Transaction);
                    #endregion
                }
            }
            #endregion

            returnValue.Result = ProductList.ToArray();
            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3ICaCnP_1426_Array Invoke(string ConnectionString,P_L3ICaCnP_1426 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3ICaCnP_1426_Array Invoke(DbConnection Connection,P_L3ICaCnP_1426 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3ICaCnP_1426_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3ICaCnP_1426 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3ICaCnP_1426_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3ICaCnP_1426 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3ICaCnP_1426_Array functionReturn = new FR_L3ICaCnP_1426_Array();
			try
			{

				if (cleanupConnection == true) 
				{
					Connection = CSV2Core_MySQL.Support.DBSQLSupport.CreateConnection(ConnectionString);
					Connection.Open();
				}
				if (cleanupTransaction == true)
				{
					Transaction = Connection.BeginTransaction();
				}

				functionReturn = Execute(Connection, Transaction,Parameter,securityTicket);

				#region Cleanup Connection/Transaction
				//Commit the transaction 
				if (cleanupTransaction == true)
				{
					Transaction.Commit();
				}
				//Close the connection
				if (cleanupConnection == true)
				{
					Connection.Close();
				}
				#endregion
			}
			catch (Exception ex)
			{
				try
				{
					if (cleanupTransaction == true && Transaction!=null)
					{
						Transaction.Rollback();
					}
				}
				catch { }

				try
				{
					if (cleanupConnection == true && Connection != null)
					{
						Connection.Close();
					}
				}
				catch { }

				throw new Exception("Exception occured in method cls_Import_Catalog_and_Create_new_PricelIst_with_Products",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3ICaCnP_1426_Array : FR_Base
	{
		public L3ICaCnP_1426[] Result	{ get; set; } 
		public FR_L3ICaCnP_1426_Array() : base() {}

		public FR_L3ICaCnP_1426_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3ICaCnP_1426 for attribute P_L3ICaCnP_1426
		[DataContract]
		public class P_L3ICaCnP_1426 
		{
			[DataMember]
			public P_L3ICaCnP_1426_Products[] Products { get; set; }
			[DataMember]
			public P_L3ICaCnP_1426_SupplierData SupplierData { get; set; }

			//Standard type parameters
			[DataMember]
			public String CatalogCodeITL { get; set; } 
			[DataMember]
			public String CatalogName { get; set; } 
			[DataMember]
			public String CatalogDescription { get; set; } 
			[DataMember]
			public DateTime ValidFrom_Date { get; set; } 
			[DataMember]
			public DateTime ValidTo_Date { get; set; } 
			[DataMember]
			public bool isDeleted { get; set; } 
			[DataMember]
			public Guid SubscribedBy_BusinessParticipant_RefID { get; set; } 
			[DataMember]
			public String CatalogLanguage_ISO_639_1_codes { get; set; } 
			[DataMember]
			public String CatalogCurrency_ISO_4217 { get; set; } 
			[DataMember]
			public int CatalogVersion { get; set; } 
			[DataMember]
			public Boolean IsCatalogPublic { get; set; } 
			[DataMember]
			public String ClientName { get; set; } 

		}
		#endregion
		#region SClass P_L3ICaCnP_1426_Products for attribute Products
		[DataContract]
		public class P_L3ICaCnP_1426_Products 
		{
			//Standard type parameters
			[DataMember]
			public String ProductITL { get; set; } 
			[DataMember]
			public bool isDeleted { get; set; } 
			[DataMember]
			public Dict Product_Name { get; set; } 
			[DataMember]
			public Dict Product_Description { get; set; } 
			[DataMember]
			public String Product_Number { get; set; } 
			[DataMember]
			public bool IsProduct_Article { get; set; } 
			[DataMember]
			public String Dosage { get; set; } 
			[DataMember]
			public Decimal Price { get; set; } 
			[DataMember]
			public double Amount { get; set; } 
			[DataMember]
			public String MeasuredInUnit_ISO_um_ums { get; set; } 
			[DataMember]
			public String VAT { get; set; } 

		}
		#endregion
		#region SClass P_L3ICaCnP_1426_SupplierData for attribute SupplierData
		[DataContract]
		public class P_L3ICaCnP_1426_SupplierData 
		{
			//Standard type parameters
			[DataMember]
			public String SupplierITL { get; set; } 
			[DataMember]
			public String TenantITL { get; set; } 
			[DataMember]
			public String Supplier_Name { get; set; } 
			[DataMember]
			public String CountryISO { get; set; } 
			[DataMember]
			public String Street_Name { get; set; } 
			[DataMember]
			public String Street_Number { get; set; } 
			[DataMember]
			public String ZIP { get; set; } 
			[DataMember]
			public String Town { get; set; } 
			[DataMember]
			public String Region_Code { get; set; } 

		}
		#endregion
		#region SClass L3ICaCnP_1426 for attribute L3ICaCnP_1426
		[DataContract]
		public class L3ICaCnP_1426 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProductID { get; set; } 
			[DataMember]
			public String Dosage { get; set; } 
			[DataMember]
			public bool isEdit { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3ICaCnP_1426_Array cls_Import_Catalog_and_Create_new_PricelIst_with_Products(,P_L3ICaCnP_1426 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3ICaCnP_1426_Array invocationResult = cls_Import_Catalog_and_Create_new_PricelIst_with_Products.Invoke(connectionString,P_L3ICaCnP_1426 Parameter,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

/* Support for Parameter Invocation (Copy&Paste)
var parameter = new CL3_Catalog.Atomic.Manipulation.P_L3ICaCnP_1426();
parameter.Products = ...;
parameter.SupplierData = ...;

parameter.CatalogCodeITL = ...;
parameter.CatalogName = ...;
parameter.CatalogDescription = ...;
parameter.ValidFrom_Date = ...;
parameter.ValidTo_Date = ...;
parameter.isDeleted = ...;
parameter.SubscribedBy_BusinessParticipant_RefID = ...;
parameter.CatalogLanguage_ISO_639_1_codes = ...;
parameter.CatalogCurrency_ISO_4217 = ...;
parameter.CatalogVersion = ...;
parameter.IsCatalogPublic = ...;
parameter.ClientName = ...;

*/
