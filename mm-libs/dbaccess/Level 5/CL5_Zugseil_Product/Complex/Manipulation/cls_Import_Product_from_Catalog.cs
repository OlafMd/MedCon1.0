/* 
 * Generated on 2/3/2015 15:21:02
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
using BOp.CatalogAPI.data;
using CL1_CMN;
using CL1_CMN_PRO;
using CL1_CMN_PRO_CUS;

namespace CL5_Zugseil_Product.Complex.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Import_Product_from_Catalog.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Import_Product_from_Catalog
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Guid Execute(DbConnection Connection, DbTransaction Transaction, P_L5PR_IPfC_1648 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
            var defaultLanguages = ORM_CMN_Language.Query.Search(Connection, Transaction, new ORM_CMN_Language.Query
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID
            });
            var productFromCatalog = Parameter.Product;
            ORM_CMN_PRO_SubscribedCatalog subscribedCatalog = new ORM_CMN_PRO_SubscribedCatalog();
            var existingCatalog = ORM_CMN_PRO_SubscribedCatalog.Query.Search(Connection, Transaction, new ORM_CMN_PRO_SubscribedCatalog.Query() { CatalogCodeITL = productFromCatalog.CatalogITL });
            if (existingCatalog != null && existingCatalog.Count() > 0)
                subscribedCatalog = existingCatalog.First();
           var supplierID= subscribedCatalog.PublishingSupplier_RefID;
        
            ORM_CMN_PRO_Product productToCreateUpdate = new ORM_CMN_PRO_Product();
            productToCreateUpdate.CMN_PRO_ProductID = Guid.NewGuid();

            ORM_CMN_PRO_Product.Query productDbQuery = new ORM_CMN_PRO_Product.Query();
            productDbQuery.ProductITL = productFromCatalog.ProductITL;
            productDbQuery.Tenant_RefID = securityTicket.TenantID;
            productDbQuery.IsDeleted = false;

            var product = ORM_CMN_PRO_Product.Query.Search(Connection, Transaction, productDbQuery);

            if (product != null && product.Count > 0)
            {
                productToCreateUpdate = product.First();

                ORM_CMN_PRO_Dimension.Query dimensionQuery = new ORM_CMN_PRO_Dimension.Query();
                dimensionQuery.Product_RefID = productToCreateUpdate.CMN_PRO_ProductID;
                dimensionQuery.Tenant_RefID = securityTicket.TenantID;
                dimensionQuery.IsDeleted = false;

                var dimensions = ORM_CMN_PRO_Dimension.Query.Search(Connection, Transaction, dimensionQuery);
                foreach (var dimension in dimensions)
                {
                    ORM_CMN_PRO_Dimension_Value.Query dimensionValuesQuery = new ORM_CMN_PRO_Dimension_Value.Query();
                    dimensionValuesQuery.Dimensions_RefID = dimension.CMN_PRO_DimensionID;
                    dimensionValuesQuery.Tenant_RefID = securityTicket.TenantID;
                    var dimensionValues = ORM_CMN_PRO_Dimension_Value.Query.Search(Connection, Transaction, dimensionValuesQuery);
                    foreach (var dimensionValue in dimensionValues)
                    {
                        ORM_CMN_PRO_Variant_DimensionValue.Query dimensionValueVariantQuery = new ORM_CMN_PRO_Variant_DimensionValue.Query();
                        dimensionValueVariantQuery.DimensionValue_RefID = dimensionValue.CMN_PRO_Dimension_ValueID;
                        ORM_CMN_PRO_Variant_DimensionValue.Query.SoftDelete(Connection, Transaction, dimensionValueVariantQuery);
                    }
                    ORM_CMN_PRO_Dimension_Value.Query.SoftDelete(Connection, Transaction, dimensionValuesQuery);
                }

                ORM_CMN_PRO_Dimension.Query.SoftDelete(Connection, Transaction, dimensionQuery);

            }

            productToCreateUpdate.IsImportedFromExternalCatalog = true;
            productToCreateUpdate.Product_Name = new Dict(ORM_CMN_PRO_Product.TableName);
            productToCreateUpdate.IsDeleted = false;
            productToCreateUpdate.ProductITL = productFromCatalog.ProductITL;
            productToCreateUpdate.Product_Description = new Dict(ORM_CMN_PRO_Product.TableName);
            productToCreateUpdate.Tenant_RefID = securityTicket.TenantID;
            productToCreateUpdate.Product_Number = productFromCatalog.Code;

            foreach (var lang in defaultLanguages)
            {
                productToCreateUpdate.Product_Name.AddEntry(lang.CMN_LanguageID, productFromCatalog.Name);
                productToCreateUpdate.Product_Description.AddEntry(lang.CMN_LanguageID, productFromCatalog.Description);
            }

            productToCreateUpdate.Save(Connection, Transaction);
            returnValue.Result = productToCreateUpdate.CMN_PRO_ProductID;
            foreach(var customizationToDelete in ORM_CMN_PRO_CUS_Customization.Query.Search(Connection, Transaction, new ORM_CMN_PRO_CUS_Customization.Query() { Product_RefID = productToCreateUpdate.CMN_PRO_ProductID }))
            {
            ORM_CMN_PRO_CUS_Customization.Query.SoftDelete(Connection, Transaction, new ORM_CMN_PRO_CUS_Customization.Query() { CMN_PRO_CUS_CustomizationID = customizationToDelete.CMN_PRO_CUS_CustomizationID });
                if(ORM_CMN_PRO_CUS_Customization_Variant.Query.Exists(Connection,Transaction,new ORM_CMN_PRO_CUS_Customization_Variant.Query(){  Customization_RefID= customizationToDelete.CMN_PRO_CUS_CustomizationID}))
                {
                    ORM_CMN_PRO_CUS_Customization_Variant.Query.SoftDelete(Connection, Transaction, new ORM_CMN_PRO_CUS_Customization_Variant.Query() { Customization_RefID = customizationToDelete.CMN_PRO_CUS_CustomizationID });
                }
            }
          var customizationOrderSequence=0;
          if (productFromCatalog.Customizations != null)
          {
              productToCreateUpdate.IsCustomizable = true;
              productToCreateUpdate.Save(Connection, Transaction);
              foreach (var customization in productFromCatalog.Customizations)
              {
                  ORM_CMN_PRO_CUS_Customization customizationToSave = new ORM_CMN_PRO_CUS_Customization();
                  customizationToSave.CMN_PRO_CUS_CustomizationID = Guid.NewGuid();
                  customizationToSave.Customization_Description = new Dict(ORM_CMN_PRO_CUS_Customization.TableName);
                  customizationToSave.Customization_Name = new Dict(ORM_CMN_PRO_CUS_Customization.TableName);
                  customizationToSave.IsDeleted = false;
                  customizationToSave.Product_RefID = productToCreateUpdate.CMN_PRO_ProductID;
                  customizationToSave.Tenant_RefID = securityTicket.TenantID;
                  customizationToSave.OrderSequence = customizationOrderSequence;
                  customizationOrderSequence++;

                  foreach (var lang in defaultLanguages)
                  {
                      customizationToSave.Customization_Description.UpdateEntry(lang.CMN_LanguageID, customization.Description);
                      customizationToSave.Customization_Name.UpdateEntry(lang.CMN_LanguageID, customization.Name);
                  }
                  customizationToSave.Save(Connection, Transaction);
                  var customizationVariantOrderSequence = 0;
                  foreach (var customizationVariant in customization.CustomizationVariants)
                  {
                      ORM_CMN_PRO_CUS_Customization_Variant customizationVariantsToSave = new ORM_CMN_PRO_CUS_Customization_Variant();
                      customizationVariantsToSave.CMN_PRO_CUS_Customization_VariantID = Guid.NewGuid();
                      customizationVariantsToSave.Customization_RefID = customizationToSave.CMN_PRO_CUS_CustomizationID;
                      customizationVariantsToSave.CustomizationVariant_Name = new Dict(ORM_CMN_PRO_CUS_Customization_Variant.TableName);
                      customizationVariantsToSave.OrderSequence = customizationVariantOrderSequence;
                      customizationVariantOrderSequence++;
                      customizationVariantsToSave.IsDeleted = false;
                      customizationVariantsToSave.Tenant_RefID = securityTicket.TenantID;
                      foreach (var lang in defaultLanguages)
                      {
                          customizationVariantsToSave.CustomizationVariant_Name.UpdateEntry(lang.CMN_LanguageID, customizationVariant.Name);
                      }
                      customizationVariantsToSave.Save(Connection, Transaction);
                  }

              }
          }


            ORM_CMN_PRO_Product_Variant.Query productVariantQuery = new ORM_CMN_PRO_Product_Variant.Query();
            productVariantQuery.CMN_PRO_Product_RefID = productToCreateUpdate.CMN_PRO_ProductID;
            productVariantQuery.Tenant_RefID = securityTicket.TenantID;
            productVariantQuery.IsDeleted = false;

            var productVariantsDb = ORM_CMN_PRO_Product_Variant.Query.Search(Connection, Transaction, productVariantQuery);
            List<ORM_CMN_PRO_Dimension> dimensionsToCreate = new List<ORM_CMN_PRO_Dimension>();
            List<ORM_CMN_PRO_Dimension_Value> dimensionValuesToCreate = new List<ORM_CMN_PRO_Dimension_Value>();

            foreach (var productVariantFromCatalog in productFromCatalog.Variants)
            {
                ORM_CMN_PRO_Product_Variant.Query variantToCreateQuery = new ORM_CMN_PRO_Product_Variant.Query();
                variantToCreateQuery.ProductVariantITL = productVariantFromCatalog.ITL;
                variantToCreateQuery.Tenant_RefID = securityTicket.TenantID;
                var isVariantSaved = ORM_CMN_PRO_Product_Variant.Query.Exists(Connection, Transaction, variantToCreateQuery);
               
                ORM_CMN_PRO_Product_Variant productVariantToCreate = new ORM_CMN_PRO_Product_Variant();
                if (isVariantSaved)
                {
                    productVariantToCreate.Load(Connection, Transaction, ORM_CMN_PRO_Product_Variant.Query.Search(Connection, Transaction, variantToCreateQuery).FirstOrDefault().CMN_PRO_Product_VariantID);
                }
                else
                {
                    productVariantToCreate.CMN_PRO_Product_VariantID = Guid.NewGuid();
                }
                productVariantToCreate.IsStandardProductVariant = productVariantFromCatalog.DefaultVariant;
                productVariantToCreate.CMN_PRO_Product_RefID = productToCreateUpdate.CMN_PRO_ProductID;
                productVariantToCreate.IsDeleted = false;
                productVariantToCreate.Tenant_RefID = securityTicket.TenantID;
                productVariantToCreate.IsImportedFromExternalCatalog = true;
                productVariantToCreate.ProductVariantITL = productVariantFromCatalog.ITL;
                productVariantToCreate.VariantName = new Dict(ORM_CMN_PRO_Product_Variant.TableName);
                foreach (var lang in defaultLanguages)
                {
                    productVariantToCreate.VariantName.UpdateEntry(lang.CMN_LanguageID, productVariantFromCatalog.Name);
                }
                productVariantToCreate.Save(Connection, Transaction);
                ORM_CMN_Price procurementPrice = new ORM_CMN_Price();
                procurementPrice.CMN_PriceID = Guid.NewGuid();
                procurementPrice.IsDeleted = false;
                procurementPrice.Tenant_RefID = securityTicket.TenantID;
                procurementPrice.Save(Connection,Transaction);

                foreach (var price in productVariantFromCatalog.PriceGrades)
                {
                    ORM_CMN_Price_Value priceValues = new ORM_CMN_Price_Value();
                    priceValues.Price_RefID = procurementPrice.CMN_PriceID;
                    var procurementPriceAmount = price.SalesPrice ?? 0;
                    priceValues.PriceValue_Amount = (double)procurementPriceAmount;
                    priceValues.PriceValue_Currency_RefID = subscribedCatalog.SubscribedCatalog_Currency_RefID;
                    priceValues.IsDeleted = false;
                    priceValues.Tenant_RefID = securityTicket.TenantID;
                    priceValues.Save(Connection, Transaction);
                
                }
                
                ORM_CMN_PRO_Product_Supplier productSupplier = new ORM_CMN_PRO_Product_Supplier();
                productSupplier.CMN_BPT_Supplier_RefID = supplierID;
                productSupplier.CMN_PRO_Product_RefID = productVariantToCreate.CMN_PRO_Product_RefID;
                productSupplier.CMN_PRO_Product_Variant_RefID = productVariantToCreate.CMN_PRO_Product_VariantID;
                productSupplier.ProcurementPrice_RefID = procurementPrice.CMN_PriceID;
                productSupplier.Tenant_RefID = securityTicket.TenantID;
                productSupplier.SupplierPriority = 0;
                productSupplier.IsDeleted = false;
                productSupplier.Save(Connection, Transaction);

              
                foreach (var dimension in productVariantFromCatalog.Dimensions)
                {
                    if (dimensionsToCreate.Where(x => x.DimensionName.Contents.First().Content == dimension.Key).Count() == 0)
                    {
                        ORM_CMN_PRO_Dimension dimensionToCreate = new ORM_CMN_PRO_Dimension();
                        dimensionToCreate.DimensionName = new Dict(ORM_CMN_PRO_Dimension.TableName);
                        foreach (var lang in defaultLanguages)
                        {
                            dimensionToCreate.DimensionName.AddEntry(lang.CMN_LanguageID, dimension.Key);
                        }
                        dimensionToCreate.OrderSequence = dimensionsToCreate.Count() + 1;
                        dimensionToCreate.CMN_PRO_DimensionID = Guid.NewGuid();
                        dimensionToCreate.Product_RefID = productVariantToCreate.CMN_PRO_Product_RefID;
                        dimensionToCreate.IsDeleted = false;
                        dimensionToCreate.Tenant_RefID = securityTicket.TenantID;
                        dimensionsToCreate.Add(dimensionToCreate);

                    }

                    var dimensionValue = dimensionValuesToCreate.Where(x => x.DimensionValue_Text.Contents.First().Content == dimension.Value);
                    ORM_CMN_PRO_Dimension_Value dimensionValueToCreate = new ORM_CMN_PRO_Dimension_Value();
                    if (dimensionValue != null && dimensionValue.Count() > 0)
                    {
                        dimensionValueToCreate = dimensionValue.First();
                    }
                    else
                    {
                        dimensionValueToCreate.DimensionValue_Text = new Dict(ORM_CMN_PRO_Dimension_Value.TableName);
                        foreach (var lang in defaultLanguages)
                        {
                            dimensionValueToCreate.DimensionValue_Text.AddEntry(lang.CMN_LanguageID, dimension.Value);
                        }
                        dimensionValueToCreate.Dimensions_RefID = dimensionsToCreate.First(x => x.DimensionName.Contents.First().Content == dimension.Key).CMN_PRO_DimensionID;
                        dimensionValueToCreate.CMN_PRO_Dimension_ValueID = Guid.NewGuid();
                        dimensionValueToCreate.OrderSequence = dimensionValuesToCreate.Count() + 1;
                        dimensionValueToCreate.IsDeleted = false;
                        dimensionValueToCreate.Tenant_RefID = securityTicket.TenantID;
                        dimensionValuesToCreate.Add(dimensionValueToCreate);
                    }
                    ORM_CMN_PRO_Variant_DimensionValue variantDimensionValueToCreate = new ORM_CMN_PRO_Variant_DimensionValue();
                    variantDimensionValueToCreate.CMN_PRO_Variant_DimensionValueID = Guid.NewGuid();
                    variantDimensionValueToCreate.DimensionValue_RefID = dimensionValueToCreate.CMN_PRO_Dimension_ValueID;
                    variantDimensionValueToCreate.ProductVariant_RefID = productVariantToCreate.CMN_PRO_Product_VariantID;
                    variantDimensionValueToCreate.IsDeleted = false;
                    variantDimensionValueToCreate.Tenant_RefID = securityTicket.TenantID;
                    variantDimensionValueToCreate.Save(Connection, Transaction);

                }
            }
            foreach (var dimensionToCreate in dimensionsToCreate)
            {
                dimensionToCreate.Save(Connection, Transaction);
            }
            foreach (var dimensionValueToCreate in dimensionValuesToCreate)
            {
                dimensionValueToCreate.Save(Connection, Transaction);
            }

			return returnValue;
			#endregion UserCode
		}
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_Guid Invoke(string ConnectionString, P_L5PR_IPfC_1648 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, P_L5PR_IPfC_1648 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, P_L5PR_IPfC_1648 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_L5PR_IPfC_1648 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

                functionReturn = Execute(Connection, Transaction, Parameter, securityTicket);

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
                    if (cleanupTransaction == true && Transaction != null)
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

                throw new Exception("Exception occured in method cls_Import_Product_from_Catalog", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
    #region SClass P_L5PR_IPfC_1648 for attribute P_L5PR_IPfC_1648
    [DataContract]
    public class P_L5PR_IPfC_1648
    {
        [DataMember]
        public ProductsForImport Product { get; set; }

        //Standard type parameters
    }
    #endregion
    #region SClass ProductsForImport for attribute Product
    [DataContract]
    public class ProductsForImport : Product
    {
        //Standard type parameters
        [DataMember]
        public string CatalogITL { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Import_Product_from_Catalog(,P_L5PR_IPfC_1648 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Import_Product_from_Catalog.Invoke(connectionString,P_L5PR_IPfC_1648 Parameter,securityTicket);
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
var parameter = new CL5_Zugseil_Product.Complex.Manipulation.P_L5PR_IPfC_1648();
parameter.Product = ...;


*/
