/* 
 * Generated on 2/1/2015 15:37:18
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
using CL1_CMN_PRO_ASS;
using BOp.CatalogAPI.data;
using BOp.CatalogAPI;
using CL5_Zugseil_Product.Atomic.Retrieval;
using CL3_Variant.Atomic.Retrieval;

namespace CL5_Zugseil_Product.Complex.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Save_Product_from_Assortment.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Save_Product_from_Assortment
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Guid Execute(DbConnection Connection, DbTransaction Transaction, P_L5PR_SPfA_1023 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_Guid();
            var productParameters = Parameter.Products;
            returnValue = cls_Save_Product.Invoke(Connection, Transaction, productParameters, securityTicket);

            var productService = CatalogServiceFactory.GetProductService();
            foreach (var vendorProduct in Parameter.VendorProducts)
            {
                Guid vendorProductID = vendorProduct.VendorProductID;
                if (!string.IsNullOrEmpty(vendorProduct.ProductITL))
                {
                    ProductDetailsRequest productDetailsRequest = new ProductDetailsRequest();

                    productDetailsRequest.CatalogCode = vendorProduct.CatalogITL;
                    productDetailsRequest.ProductIDs = new List<string>();
                    productDetailsRequest.ProductIDs.Add(vendorProduct.ProductITL);
                    List<Product> products = new List<Product>();
                    products.AddRange(productService.GetProductDetails<Product>(productDetailsRequest).ProductDetails);
                    foreach (var product in products)
                    {
                        P_L5PR_IPfC_1648 parameter = new P_L5PR_IPfC_1648();
                        parameter.Product = new ProductsForImport();
                        parameter.Product.Code = product.Code;
                        parameter.Product.Custom = product.Custom;
                        parameter.Product.Description = product.Description;
                        parameter.Product.LongName = product.LongName;
                        parameter.Product.Name = product.Name;
                        parameter.Product.ProductITL = product.ProductITL;
                        parameter.Product.CatalogITL = vendorProduct.CatalogITL;
                        parameter.Product.Variants = new List<Variant>();
                        foreach (var variant in product.Variants)
                        {
                            parameter.Product.Variants.Add(variant);

                        }
                        parameter.Product.Vat = product.Vat;

                        vendorProductID = cls_Import_Product_from_Catalog.Invoke(Connection, Transaction, parameter, securityTicket).Result;
                        vendorProduct.ProductRefID = vendorProductID;
                    }
                }

                ORM_CMN_PRO_ASS_AssortmentProduct_VendorProduct vendorProductToSave = new ORM_CMN_PRO_ASS_AssortmentProduct_VendorProduct();
                var vendorProductExists = ORM_CMN_PRO_ASS_AssortmentProduct_VendorProduct.Query.Exists(Connection, Transaction, new ORM_CMN_PRO_ASS_AssortmentProduct_VendorProduct.Query()
                {
                    CMN_PRO_ASS_AssortmentProduct_VendorProductID = vendorProduct.VendorProductID
                });
                if (vendorProductExists)
                    vendorProductToSave.Load(Connection, Transaction, vendorProduct.VendorProductID);
                vendorProductToSave.CMN_PRO_ASS_AssortmentProduct_RefID = vendorProduct.AssortmentProductID;
                vendorProductToSave.CMN_PRO_Product_RefID = vendorProduct.ProductRefID;
                vendorProductToSave.IsDeleted = vendorProduct.IsDeleted;
                vendorProductToSave.Tenant_RefID = securityTicket.TenantID;

                vendorProductToSave.Save(Connection, Transaction);

                if (vendorProduct.IsDeleted == true)
                {
                    P_L3VA_GAVVfAP_1926 parameterAssortmentVendorVariants = new P_L3VA_GAVVfAP_1926();
                    parameterAssortmentVendorVariants.ProductID = Parameter.Products.ProductID;
                    var assortmentVendorProductVariants = cls_Get_Assortment_Vendor_Variants_for_AssortmentProductID.Invoke(Connection, Transaction, parameterAssortmentVendorVariants, securityTicket).Result;
                    
                    P_L3VA_GAVfP_1300 parameterVendorVariantToDelete = new P_L3VA_GAVfP_1300();
                    parameterVendorVariantToDelete.ProductID = vendorProductToSave.CMN_PRO_Product_RefID;

                    var vendorProductVariantsToDelete = cls_Get_All_Variants_for_Product.Invoke(Connection, Transaction, parameterVendorVariantToDelete, securityTicket).Result;

                    if (vendorProductVariantsToDelete != null)
                    {
                        foreach (var vendorProductVariantToDelete in vendorProductVariantsToDelete)
                        {
                            
                            if (assortmentVendorProductVariants.ToList().Count(x => x.CMN_PRO_Product_Variant_RefID == vendorProductVariantToDelete.CMN_PRO_Product_VariantID) > 0)
                            {
                                var assortmentProductVariantsIDs = assortmentVendorProductVariants.Where(x => x.CMN_PRO_Product_Variant_RefID == vendorProductVariantToDelete.CMN_PRO_Product_VariantID).Select(x => x.CMN_PRO_ASS_AssortmentVariant_VendorVariantID).ToList();
                              
                                foreach (var assortmentProductVariantsID in assortmentProductVariantsIDs)
                                {
                                    ORM_CMN_PRO_ASS_AssortmentVariant_VendorVariant variantToDelete = new ORM_CMN_PRO_ASS_AssortmentVariant_VendorVariant();
                                    variantToDelete.Load(Connection, Transaction, assortmentProductVariantsID);
                                    variantToDelete.IsDeleted = true;
                                     variantToDelete.IsDefaultVendorVariant = false;
                                    variantToDelete.Save(Connection, Transaction);
                                }
                                assortmentVendorProductVariants.ToList().RemoveAll(x => x.CMN_PRO_Product_Variant_RefID == vendorProductVariantToDelete.CMN_PRO_Product_VariantID);
                          
                                var assortmentVariantIDs=assortmentVendorProductVariants.Select(x=>x.CMN_PRO_ASS_AssortmentVariantID).ToList();
                                foreach (var assortmentVariantID in assortmentVariantIDs.Distinct().ToList())
                                {
                                    var vendorVariantsToUpdate = ORM_CMN_PRO_ASS_AssortmentVariant_VendorVariant.Query.Search(Connection, Transaction, new ORM_CMN_PRO_ASS_AssortmentVariant_VendorVariant.Query()
                                    {
                                        CMN_PRO_ASS_AssortmentVariant_RefID = assortmentVariantID,
                                        IsDeleted = false,
                                        Tenant_RefID = securityTicket.TenantID

                                    }).ToList();
                                    var orderSequence = 1;
                                    foreach (var variantToUpdate in vendorVariantsToUpdate)
                                    {
                                      
                                        variantToUpdate.OrderSequence = orderSequence;
                                        if (orderSequence == 0 && vendorVariantsToUpdate.Count(x => x.IsDefaultVendorVariant) == 0)
                                        {
                                            variantToUpdate.IsDefaultVendorVariant = true;

                                        }
                                        variantToUpdate.Save(Connection, Transaction);
                                        orderSequence++;
                                    }
                                    
                                }



                            }
                        }
                    }

                }

            }
            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_Guid Invoke(string ConnectionString, P_L5PR_SPfA_1023 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, P_L5PR_SPfA_1023 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, P_L5PR_SPfA_1023 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_L5PR_SPfA_1023 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

                throw new Exception("Exception occured in method cls_Save_Product_from_Assortment", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
    #region SClass P_L5PR_SPfA_1023 for attribute P_L5PR_SPfA_1023
    [DataContract]
    public class P_L5PR_SPfA_1023
    {
        [DataMember]
        public P_L5PR_SPfA_1023a[] VendorProducts { get; set; }

        //Standard type parameters
        [DataMember]
        public P_L5PR_SP_1614 Products { get; set; }
        [DataMember]
        public Guid AssortmentID { get; set; }

    }
    #endregion
    #region SClass P_L5PR_SPfA_1023a for attribute VendorProducts
    [DataContract]
    public class P_L5PR_SPfA_1023a
    {
        //Standard type parameters
        [DataMember]
        public Guid VendorProductID { get; set; }
        [DataMember]
        public Guid ProductRefID { get; set; }
        [DataMember]
        public Guid AssortmentProductID { get; set; }
        [DataMember]
        public string ProductITL { get; set; }
        [DataMember]
        public string CatalogITL { get; set; }
        [DataMember]
        public bool IsDeleted { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Product_from_Assortment(,P_L5PR_SPfA_1023 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Product_from_Assortment.Invoke(connectionString,P_L5PR_SPfA_1023 Parameter,securityTicket);
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
var parameter = new CL5_Zugseil_Product.Complex.Manipulation.P_L5PR_SPfA_1023();
parameter.VendorProducts = ...;

parameter.Products = ...;
parameter.AssortmentID = ...;

*/
