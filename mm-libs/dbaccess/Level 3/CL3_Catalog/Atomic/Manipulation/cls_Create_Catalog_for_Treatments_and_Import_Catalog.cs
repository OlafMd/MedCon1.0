/* 
 * Generated on 2/7/2014 3:42:50 PM
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
using CL1_CMN_SLS;
using CL2_Language.Atomic.Retrieval;
using CL1_CMN_PRO_PAC;
using CL1_CMN;
using CL3_Taxes.Atomic.Retrieval;
using CL3_Taxes.Atomic.Manipulation;
using CL1_ACC_TAX;
using CL1_CMN_BPT;
using CL1_CMN_COM;
using CL2_Country.Atomic.Retrieval;
using DLCore_DBCommons.Utils;
using DLCore_DBCommons.APODemand;

namespace CL3_Catalog.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Create_Catalog_for_Treatments_and_Import_Catalog.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Create_Catalog_for_Treatments_and_Import_Catalog
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3CCfTaIC_1526_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3CCfTaIC_1526 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L3CCfTaIC_1526_Array();
			//Put your code here
            List<L3CCfTaIC_1526> ProductList = new List<L3CCfTaIC_1526>();
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
                customer.BusinessParticipantITL = securityTicket.TenantID.ToString();
            }
            customer.TenantITL = securityTicket.TenantID.ToString();
            customer.Name = Parameter.ClientName;
           // customer.SourceRealm = BOp.Infrastructure.PropertyRepository.Instance.RealmID.ToString();

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
                productGroupQuery.GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(EProductGroup.Treatment);

                //if (Parameter.IsCatalogPublic == false)
                //{
                //    productGroupQuery.GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(EProductGroup.HauseList);
                //}
                //else
                //{
                //    productGroupQuery.GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(EProductGroup.ABDA);
                //}
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
                    productGroupQuery.GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(EProductGroup.Treatment);
                    productGroup.ProductGroup_Name.AddEntry(language.CMN_LanguageID, "Treatment Group");

                    //if (Parameter.IsCatalogPublic == false)
                    //{
                    //    productGroup.GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(EProductGroup.HauseList);
                    //    productGroup.ProductGroup_Name.AddEntry(language.CMN_LanguageID, "HauseList Group");
                    //}
                    //else
                    //{
                    //    productGroup.GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(EProductGroup.ABDA);
                    //    productGroup.ProductGroup_Name.AddEntry(language.CMN_LanguageID, "ABDA Group");
                    //}

                    // for only Tenant specific cases add Business Participant ID
                    if (Parameter.SubscribedBy_BusinessParticipant_RefID != Guid.Empty)
                    {
                        productGroup.GlobalPropertyMatchingID += Parameter.SubscribedBy_BusinessParticipant_RefID;
                        productGroup.ProductGroup_Name.AddEntry(language.CMN_LanguageID, "Treatment Group");
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

                        L3CCfTaIC_1526 pro = new L3CCfTaIC_1526();
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

            returnValue.Result = ProductList.ToArray();
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3CCfTaIC_1526_Array Invoke(string ConnectionString,P_L3CCfTaIC_1526 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3CCfTaIC_1526_Array Invoke(DbConnection Connection,P_L3CCfTaIC_1526 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3CCfTaIC_1526_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3CCfTaIC_1526 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3CCfTaIC_1526_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3CCfTaIC_1526 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3CCfTaIC_1526_Array functionReturn = new FR_L3CCfTaIC_1526_Array();
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

				throw new Exception("Exception occured in method cls_Create_Catalog_for_Treatments_and_Import_Catalog",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3CCfTaIC_1526_Array : FR_Base
	{
		public L3CCfTaIC_1526[] Result	{ get; set; } 
		public FR_L3CCfTaIC_1526_Array() : base() {}

		public FR_L3CCfTaIC_1526_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3CCfTaIC_1526 for attribute P_L3CCfTaIC_1526
		[DataContract]
		public class P_L3CCfTaIC_1526 
		{
			[DataMember]
			public P_L3CCfTaIC_1526_Products[] Products { get; set; }
			[DataMember]
			public P_L3CCfTaIC_1526_SupplierData SupplierData { get; set; }

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
		#region SClass P_L3CCfTaIC_1526_Products for attribute Products
		[DataContract]
		public class P_L3CCfTaIC_1526_Products 
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
		#region SClass P_L3CCfTaIC_1526_SupplierData for attribute SupplierData
		[DataContract]
		public class P_L3CCfTaIC_1526_SupplierData 
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
		#region SClass L3CCfTaIC_1526 for attribute L3CCfTaIC_1526
		[DataContract]
		public class L3CCfTaIC_1526 
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
FR_L3CCfTaIC_1526_Array cls_Create_Catalog_for_Treatments_and_Import_Catalog(,P_L3CCfTaIC_1526 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3CCfTaIC_1526_Array invocationResult = cls_Create_Catalog_for_Treatments_and_Import_Catalog.Invoke(connectionString,P_L3CCfTaIC_1526 Parameter,securityTicket);
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
var parameter = new CL3_Catalog.Atomic.Manipulation.P_L3CCfTaIC_1526();
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
