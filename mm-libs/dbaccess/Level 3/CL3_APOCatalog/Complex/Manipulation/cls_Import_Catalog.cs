/* 
 * Generated on 4/2/2014 10:53:28 AM
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
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;
using System.Runtime.Serialization;
using CL1_CMN;
using CL2_Language.Atomic.Retrieval;
using CL1_CMN_PRO;
using DLCore_DBCommons.Utils;
using DLCore_DBCommons.APODemand;
using CL1_CMN_SLS;
using CL3_Articles.Complex.Manipulation;

namespace CL3_APOCatalog.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Import_Catalog.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Import_Catalog
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L3CA_IC_1426 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 

            var returnValue = new FR_Guid();

            #region Tenant is already subscribed to this catalog

            var subscribedCatalogQuery = new ORM_CMN_PRO_SubscribedCatalog.Query();
            subscribedCatalogQuery.Tenant_RefID = securityTicket.TenantID;
            subscribedCatalogQuery.CatalogCodeITL = Parameter.CatalogCodeITL;
            subscribedCatalogQuery.IsDeleted = false;

            var alreadySubscribedCatalog = ORM_CMN_PRO_SubscribedCatalog.Query.Search(Connection, Transaction, subscribedCatalogQuery).FirstOrDefault();

            if (alreadySubscribedCatalog != null)
                throw new Exception("Tenant is already subscribed to this catalog!");

            #endregion

            #region All tenant's languages

            var allTenantLanguages = cls_Get_All_Languages.Invoke(Connection, Transaction, securityTicket).Result.ToList();

            #endregion

            #region Get catalog's language or create it 

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

                // if language does not exist for that Tenant create it
                if (language == null)
                {
                    language = new ORM_CMN_Language();
                    language.CMN_LanguageID = Guid.NewGuid();
                    language.ISO_639_1 = Parameter.CatalogLanguage_ISO_639_1_codes;
                    language.Name = new Dict(ORM_CMN_Currency.TableName);
                    foreach (var item in allTenantLanguages)
                    {
                        language.Name.AddEntry(item.CMN_LanguageID, "CatalogLanguage - " + Parameter.CatalogLanguage_ISO_639_1_codes);
                    }
                    language.Creation_Timestamp = DateTime.Now;
                    language.Tenant_RefID = securityTicket.TenantID;
                    language.IsDeleted = false;
                    language.Save(Connection, Transaction);
                }
            }

            #endregion

            #region Get catalog's currency or create it 

            // check if currency with that ISO exists for Tenant
            var currencyQuery = new ORM_CMN_Currency.Query();
            currencyQuery.ISO4127 = Parameter.CatalogCurrency_ISO_4217.ToUpper();
            currencyQuery.Tenant_RefID = securityTicket.TenantID;
            currencyQuery.IsDeleted = false;

            var currency = ORM_CMN_Currency.Query.Search(Connection, Transaction, currencyQuery).FirstOrDefault();

            if (currency == null)
            {
                currencyQuery = new ORM_CMN_Currency.Query();
                currencyQuery.ISO4127 = Parameter.CatalogCurrency_ISO_4217.ToLower();
                currencyQuery.Tenant_RefID = securityTicket.TenantID;
                currencyQuery.IsDeleted = false;

                currency = ORM_CMN_Currency.Query.Search(Connection, Transaction, currencyQuery).FirstOrDefault();

                if (currency == null)
                {
                    currency = new ORM_CMN_Currency();
                    currency.CMN_CurrencyID = Guid.NewGuid();
                    currency.ISO4127 = Parameter.CatalogCurrency_ISO_4217;
                    currency.Name = new Dict(ORM_CMN_Currency.TableName);
                    foreach (var item in allTenantLanguages)
                    {
                        currency.Name.AddEntry(item.CMN_LanguageID, "CatalogCurrency - " + Parameter.CatalogCurrency_ISO_4217);
                    }
                    currency.Tenant_RefID = securityTicket.TenantID;
                    currency.Creation_Timestamp = DateTime.Now;
                    currency.Save(Connection, Transaction);
                }
            }

            #endregion
            
            /*
            * @save ORM_CMN_PRO_SubscribedCatalog  
            * */
            var subscribedCatalog = new ORM_CMN_PRO_SubscribedCatalog();
            subscribedCatalog.CMN_PRO_SubscribedCatalogID = Guid.NewGuid();
            subscribedCatalog.CatalogCodeITL = Parameter.CatalogCodeITL;
            subscribedCatalog.SubscribedCatalog_Name = Parameter.CatalogName;
            subscribedCatalog.SubscribedBy_BusinessParticipant_RefID = Guid.Empty; // This ClassLib is not used by Lucentis
            subscribedCatalog.Tenant_RefID = securityTicket.TenantID;
            subscribedCatalog.SubscribedCatalog_ValidFrom = Parameter.ValidFrom_Date;
            subscribedCatalog.SubscribedCatalog_ValidThrough = Parameter.ValidTo_Date;
            subscribedCatalog.SubscribedCatalog_Description = Parameter.CatalogDescription;
            subscribedCatalog.Creation_Timestamp = DateTime.Now;
            subscribedCatalog.IsDeleted = false;
            subscribedCatalog.SubscribedCatalog_CurrentRevision = Parameter.CatalogVersion;
            subscribedCatalog.IsCatalogPublic = Parameter.IsCatalogPublic;

            subscribedCatalog.SubscribedCatalog_Language_RefID = language.CMN_LanguageID;
            subscribedCatalog.SubscribedCatalog_Currency_RefID = currency.CMN_CurrencyID;

            #region Create product group

            ORM_CMN_PRO_ProductGroup productGroup = new ORM_CMN_PRO_ProductGroup();

            var productGroupQuery = new ORM_CMN_PRO_ProductGroup.Query();
            productGroupQuery.Tenant_RefID = securityTicket.TenantID;
            productGroupQuery.IsDeleted = false;
            if (Parameter.IsCatalogPublic == false)
            {
                if (Parameter.CatalogType == EnumUtils.GetEnumDescription(EPrivateCatalogType.SpecialRequests))
                    productGroupQuery.GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(EProductGroup.SpecialRequests);
                else if(Parameter.CatalogType == EnumUtils.GetEnumDescription(EPrivateCatalogType.Houselist))
                    productGroupQuery.GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(EProductGroup.HauseList);
                else if (Parameter.CatalogType == EnumUtils.GetEnumDescription(EPrivateCatalogType.Treatment))
                    productGroupQuery.GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(EProductGroup.Treatment);
            }
            else
            {
                productGroupQuery.GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(EProductGroup.ABDA);
            }

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
                    if (Parameter.CatalogType == EnumUtils.GetEnumDescription(EPrivateCatalogType.SpecialRequests)){

                        productGroup.GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(EProductGroup.SpecialRequests);
                        productGroup.ProductGroup_Name.AddEntry(language.CMN_LanguageID, "SpecialRequests Group");
                    }
                    else if (Parameter.CatalogType == EnumUtils.GetEnumDescription(EPrivateCatalogType.Houselist))
                    {
                        productGroup.GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(EProductGroup.HauseList);
                        productGroup.ProductGroup_Name.AddEntry(language.CMN_LanguageID, "HauseList Group");
                    }
                    else if (Parameter.CatalogType == EnumUtils.GetEnumDescription(EPrivateCatalogType.Treatment))
                    {
                        productGroup.GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(EProductGroup.Treatment);
                        productGroup.ProductGroup_Name.AddEntry(language.CMN_LanguageID, "HauseList Group");
                    }
                }
                else
                {
                    productGroup.GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(EProductGroup.ABDA);
                    productGroup.ProductGroup_Name.AddEntry(language.CMN_LanguageID, "ABDA Group");
                }

                productGroup.Save(Connection, Transaction);
            }
            #endregion

            #region Create priceList for catalog
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
            pricelist_Release.Pricelist_RefID = Guid.NewGuid();
            pricelist_Release.Save(Connection, Transaction);

            /*
            * @create pricelist
            * */
            ORM_CMN_SLS_Pricelist priceList = new ORM_CMN_SLS_Pricelist();
            priceList.CMN_SLS_PricelistID = pricelist_Release.Pricelist_RefID;

            Dict nameDict = new Dict("cmn_sls_pricelist");
            if (Parameter.IsCatalogPublic == false)
            {
                for (int i = 0; i < allTenantLanguages.Count; i++)
                {
                    nameDict.AddEntry(allTenantLanguages[i].CMN_LanguageID, Parameter.CatalogName + "_" + Parameter.ValidFrom_Date.ToShortDateString() + "_" + Parameter.ValidTo_Date.ToShortDateString());
                }
            }
            else
            {
                for (int i = 0; i < allTenantLanguages.Count; i++)
                {
                    nameDict.AddEntry(allTenantLanguages[i].CMN_LanguageID, EPriceList.ABDAPriceList.ToString());
                }

                priceList.GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(EPriceList.ABDAPriceList);
            }
            priceList.Pricelist_Name = nameDict;
            priceList.Tenant_RefID = securityTicket.TenantID;
            priceList.Creation_Timestamp = DateTime.Now;
            priceList.Save(Connection, Transaction);

            #endregion

            #region Create Supplier

            var CMN_BPT_SupplierID = cls_CreateOrUpdateSupplier_for_ImportedCatalog.Invoke(Connection, Transaction, Parameter.SupplierData, securityTicket).Result;

            #endregion

            subscribedCatalog.SubscribedCatalog_PricelistRelease_RefID = pricelist_Release.CMN_SLS_Pricelist_ReleaseID;
            subscribedCatalog.PublishingSupplier_RefID = CMN_BPT_SupplierID;
            subscribedCatalog.Save(Connection, Transaction);

            if (Parameter.IsCatalogPublic == false)
            {
                var importProductsParam = new P_L3AR_IoUPfSC_1325();
                importProductsParam.SubscribedCatalogID = subscribedCatalog.CMN_PRO_SubscribedCatalogID;
                importProductsParam.CatalogCurrencyID = subscribedCatalog.SubscribedCatalog_Currency_RefID;
                importProductsParam.CatalogLanguageID = subscribedCatalog.SubscribedCatalog_Language_RefID;
                importProductsParam.ProductGroupID = productGroup.CMN_PRO_ProductGroupID;
                importProductsParam.PriceListReleaseID = pricelist_Release.CMN_SLS_Pricelist_ReleaseID;
                importProductsParam.Products = Parameter.Products;

                cls_ImportOrUpdate_Products_for_SubscribedCatalog.Invoke(Connection, Transaction, importProductsParam, securityTicket);
            }
            else
            {
                #region Create Recommended ABDA Sales PriceList

                var recommendedABDASalsesPrice_priceList = ORM_CMN_SLS_Pricelist.Query.Search(Connection, Transaction, new ORM_CMN_SLS_Pricelist.Query()
                {
                    GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(EPriceList.RecommendedABDASalesPriceList),
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).SingleOrDefault();

                if (recommendedABDASalsesPrice_priceList == null)
                {
                    recommendedABDASalsesPrice_priceList = new ORM_CMN_SLS_Pricelist();
                    recommendedABDASalsesPrice_priceList.CMN_SLS_PricelistID = Guid.NewGuid();
                    recommendedABDASalsesPrice_priceList.Pricelist_Name = new Dict("cmn_sls_pricelist");
                    foreach (var lang in allTenantLanguages)
                        recommendedABDASalsesPrice_priceList.Pricelist_Name.AddEntry(lang.CMN_LanguageID, EPriceList.RecommendedABDASalesPriceList.ToString());
                    recommendedABDASalsesPrice_priceList.GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(EPriceList.RecommendedABDASalesPriceList);
                    recommendedABDASalsesPrice_priceList.Tenant_RefID = securityTicket.TenantID;
                    recommendedABDASalsesPrice_priceList.Creation_Timestamp = DateTime.Now;
                    recommendedABDASalsesPrice_priceList.Save(Connection, Transaction);

                    ORM_CMN_SLS_Pricelist_Release recommendedABDASalsesPrice_pricelist_Release = new ORM_CMN_SLS_Pricelist_Release();
                    recommendedABDASalsesPrice_pricelist_Release.CMN_SLS_Pricelist_ReleaseID = Guid.NewGuid(); 
                    recommendedABDASalsesPrice_pricelist_Release.Release_Version = "v1";
                    recommendedABDASalsesPrice_pricelist_Release.IsPricelistAlwaysActive = true;
                    recommendedABDASalsesPrice_pricelist_Release.Tenant_RefID = securityTicket.TenantID;
                    recommendedABDASalsesPrice_pricelist_Release.Creation_Timestamp = DateTime.Now;
                    recommendedABDASalsesPrice_pricelist_Release.Pricelist_RefID = recommendedABDASalsesPrice_priceList.CMN_SLS_PricelistID;
                    recommendedABDASalsesPrice_pricelist_Release.Save(Connection, Transaction);
                }


                #endregion
            }

            return returnValue;

			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L3CA_IC_1426 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L3CA_IC_1426 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L3CA_IC_1426 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3CA_IC_1426 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Guid functionReturn = new FR_Guid();
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

				throw new Exception("Exception occured in method cls_Import_Catalog",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3CA_IC_1426 for attribute P_L3CA_IC_1426
		[DataContract]
		public class P_L3CA_IC_1426 
		{
			//Standard type parameters
			[DataMember]
			public String CatalogCodeITL { get; set; } 
			[DataMember]
			public String CatalogName { get; set; } 
			[DataMember]
			public String CatalogType { get; set; } 
			[DataMember]
			public String CatalogDescription { get; set; } 
			[DataMember]
			public DateTime ValidFrom_Date { get; set; } 
			[DataMember]
			public DateTime ValidTo_Date { get; set; } 
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
			[DataMember]
			public P_L3AR_IoUPfSC_1325_Products[] Products { get; set; } 
			[DataMember]
			public P_L3CA_CoUSfIC_1545 SupplierData { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Import_Catalog(,P_L3CA_IC_1426 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Import_Catalog.Invoke(connectionString,P_L3CA_IC_1426 Parameter,securityTicket);
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
var parameter = new CL3_APOCatalog.Complex.Manipulation.P_L3CA_IC_1426();
parameter.CatalogCodeITL = ...;
parameter.CatalogName = ...;
parameter.CatalogType = ...;
parameter.CatalogDescription = ...;
parameter.ValidFrom_Date = ...;
parameter.ValidTo_Date = ...;
parameter.CatalogLanguage_ISO_639_1_codes = ...;
parameter.CatalogCurrency_ISO_4217 = ...;
parameter.CatalogVersion = ...;
parameter.IsCatalogPublic = ...;
parameter.ClientName = ...;
parameter.Products = ...;
parameter.SupplierData = ...;

*/
