/* 
 * Generated on 18.2.2015 23:29:51
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
using CL1_CMN_PRO;
using CL1_CMN_PRO_ASS;
using CL1_CMN_PRO_CUS;

namespace CL5_Zugseil_Product.Complex.Retrieval
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Get_Product_Customizations_and_CustomizationVariants.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Get_Product_Customizations_and_CustomizationVariants
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_L5PR_GPCaCV_1310 Execute(DbConnection Connection, DbTransaction Transaction, P_L5PR_GPCaCV_1310 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            //Leave UserCode region to enable user code saving
            #region UserCode
            var returnValue = new FR_L5PR_GPCaCV_1310();
            returnValue.Result = new L5PR_GPCaCV_1310();


            ORM_CMN_PRO_Product product;
            List<ORM_CMN_PRO_CUS_Customization> customizations = new List<ORM_CMN_PRO_CUS_Customization>();
            List<ORM_CMN_PRO_CUS_Customization_Variant> customizationVariants = new List<ORM_CMN_PRO_CUS_Customization_Variant>();


            #region Check if product is customizable

            product = ORM_CMN_PRO_Product.Query.Search(Connection, Transaction, new ORM_CMN_PRO_Product.Query()
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID,
                CMN_PRO_ProductID = Parameter.ProductId,
                //IsCustomizable = true
            }).FirstOrDefault();

            if (product == null)
            {
                returnValue.Status = FR_Status.Error_Internal;
                returnValue.ErrorMessage = String.Format("Product with ID = {0} is not customizable or does not exist in database!", Parameter.ProductId.ToString());
                return returnValue;
            }

            #endregion

            ORM_CMN_PRO_ASS_AssortmentProduct assortmentProduct;

            #region Product is not part of an assortment

            // If product is not part of any assortment product, 
            // then it is local product so take all customizations and customization variants for that product and return that as result.
            assortmentProduct = ORM_CMN_PRO_ASS_AssortmentProduct.Query.Search(Connection, Transaction, new ORM_CMN_PRO_ASS_AssortmentProduct.Query()
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID,
                Ext_CMN_PRO_Product_RefID = product.CMN_PRO_ProductID
            }).FirstOrDefault();

            if (assortmentProduct == null)
            {
                #region Retrieve all customizations and values for product

                customizations = ORM_CMN_PRO_CUS_Customization.Query.Search(Connection, Transaction, new ORM_CMN_PRO_CUS_Customization.Query()
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID,
                    Product_RefID = product.CMN_PRO_ProductID
                });

                foreach (var customization in customizations)
                {
                    List<ORM_CMN_PRO_CUS_Customization_Variant> variants = ORM_CMN_PRO_CUS_Customization_Variant.Query.Search(Connection, Transaction, new ORM_CMN_PRO_CUS_Customization_Variant.Query()
                    {
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID,
                        Customization_RefID = customization.CMN_PRO_CUS_CustomizationID
                    });
                    customizationVariants.AddRange(variants);
                }
                #endregion

                returnValue.Result.Customizations = customizations.ToArray();
                returnValue.Result.CustomizationVariants = customizationVariants.ToArray();

                return returnValue;
            }

            #endregion

            #region Product is part of an assortment

            // Find all assortment vendor products that are bound to it

            List<ORM_CMN_PRO_ASS_AssortmentProduct_VendorProduct> assortmentProductVendorProducts = ORM_CMN_PRO_ASS_AssortmentProduct_VendorProduct.Query.Search(Connection, Transaction, new ORM_CMN_PRO_ASS_AssortmentProduct_VendorProduct.Query()
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID,
                CMN_PRO_ASS_AssortmentProduct_RefID = assortmentProduct.CMN_PRO_ASS_AssortmentProductID
            });

            // Check if there is customization for each asortment product vendor product

            int numberOfBoundProductsThatHaveCustomizations = 0;
            List<Guid> boundProductIds = new List<Guid>();
            foreach (var assortmentProductVendorProduct in assortmentProductVendorProducts)
            {
                ORM_CMN_PRO_Product vendorProduct = ORM_CMN_PRO_Product.Query.Search(Connection, Transaction, new ORM_CMN_PRO_Product.Query()
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID,
                    CMN_PRO_ProductID = assortmentProductVendorProduct.CMN_PRO_Product_RefID,
                    IsCustomizable = true
                }).FirstOrDefault();

                if (vendorProduct == null)
                {
                    continue;
                }

                bool hasCustomizations = ORM_CMN_PRO_CUS_Customization.Query.Exists(Connection, Transaction, new ORM_CMN_PRO_CUS_Customization.Query()
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID,
                    Product_RefID = vendorProduct.CMN_PRO_ProductID
                });

                if (hasCustomizations)
                {
                    numberOfBoundProductsThatHaveCustomizations++;
                    boundProductIds.Add(vendorProduct.CMN_PRO_ProductID);
                }
            }


            if (numberOfBoundProductsThatHaveCustomizations == 0)
            {
                // Nothing!
            }
            else if (numberOfBoundProductsThatHaveCustomizations == 1)
            {
                #region Retrieve all customizations and values for product

                customizations = ORM_CMN_PRO_CUS_Customization.Query.Search(Connection, Transaction, new ORM_CMN_PRO_CUS_Customization.Query()
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID,
                    Product_RefID = boundProductIds[0]
                });

                foreach (var customization in customizations)
                {
                    List<ORM_CMN_PRO_CUS_Customization_Variant> variants = ORM_CMN_PRO_CUS_Customization_Variant.Query.Search(Connection, Transaction, new ORM_CMN_PRO_CUS_Customization_Variant.Query()
                    {
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID,
                        Customization_RefID = customization.CMN_PRO_CUS_CustomizationID
                    });
                    customizationVariants.AddRange(variants);
                }

                #endregion
            }
            else
            {
                #region More then one product that is bound to assortment product has variants

                ORM_CMN_PRO_ASS_AssortmentVariant assortmentProductVariant = ORM_CMN_PRO_ASS_AssortmentVariant.Query.Search(Connection, Transaction, new ORM_CMN_PRO_ASS_AssortmentVariant.Query()
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID,
                    Ext_CMN_PRO_Product_Variant_RefID = Parameter.ProductVariantId
                }).FirstOrDefault();

                if (assortmentProductVariant != null)
                {
                    List<ORM_CMN_PRO_ASS_AssortmentVariant_VendorVariant> assortmentVariantVendorVariants = ORM_CMN_PRO_ASS_AssortmentVariant_VendorVariant.Query.Search(Connection, Transaction, new ORM_CMN_PRO_ASS_AssortmentVariant_VendorVariant.Query()
                    {
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID,
                        CMN_PRO_ASS_AssortmentVariant_RefID = assortmentProductVariant.CMN_PRO_ASS_AssortmentVariantID
                    });

                    ORM_CMN_PRO_ASS_AssortmentVariant_VendorVariant defaultAssortmentVariantVendorVariant = assortmentVariantVendorVariants.FirstOrDefault(x => x.IsDefaultVendorVariant == true);
                    if (defaultAssortmentVariantVendorVariant == null)
                    {
                        defaultAssortmentVariantVendorVariant = assortmentVariantVendorVariants.OrderBy(x => x.OrderSequence).FirstOrDefault();
                    }

                    if (defaultAssortmentVariantVendorVariant != null)
                    {
                        ORM_CMN_PRO_Product_Variant productVariant = ORM_CMN_PRO_Product_Variant.Query.Search(Connection, Transaction, new ORM_CMN_PRO_Product_Variant.Query()
                        {
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID,
                            CMN_PRO_Product_VariantID = defaultAssortmentVariantVendorVariant.CMN_PRO_Product_Variant_RefID
                        }).FirstOrDefault();

                        if (productVariant != null)
                        {
                            product = ORM_CMN_PRO_Product.Query.Search(Connection, Transaction, new ORM_CMN_PRO_Product.Query()
                            {
                                IsDeleted = false,
                                Tenant_RefID = securityTicket.TenantID,
                                CMN_PRO_ProductID = productVariant.CMN_PRO_Product_RefID
                            }).FirstOrDefault();

                            if (product != null)
                            {
                                customizations = ORM_CMN_PRO_CUS_Customization.Query.Search(Connection, Transaction, new ORM_CMN_PRO_CUS_Customization.Query()
                                {
                                    IsDeleted = false,
                                    Tenant_RefID = securityTicket.TenantID,
                                    Product_RefID = product.CMN_PRO_ProductID
                                });

                                foreach (var customization in customizations)
                                {
                                    List<ORM_CMN_PRO_CUS_Customization_Variant> variants = ORM_CMN_PRO_CUS_Customization_Variant.Query.Search(Connection, Transaction, new ORM_CMN_PRO_CUS_Customization_Variant.Query()
                                    {
                                        IsDeleted = false,
                                        Tenant_RefID = securityTicket.TenantID,
                                        Customization_RefID = customization.CMN_PRO_CUS_CustomizationID
                                    });
                                    customizationVariants.AddRange(variants);
                                }
                            }
                        }
                    }
                }

                #endregion
            }


            #endregion

            returnValue.Result.Customizations = customizations.ToArray();
            returnValue.Result.CustomizationVariants = customizationVariants.ToArray();
            return returnValue;

            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_L5PR_GPCaCV_1310 Invoke(string ConnectionString, P_L5PR_GPCaCV_1310 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_L5PR_GPCaCV_1310 Invoke(DbConnection Connection, P_L5PR_GPCaCV_1310 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_L5PR_GPCaCV_1310 Invoke(DbConnection Connection, DbTransaction Transaction, P_L5PR_GPCaCV_1310 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_L5PR_GPCaCV_1310 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_L5PR_GPCaCV_1310 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_L5PR_GPCaCV_1310 functionReturn = new FR_L5PR_GPCaCV_1310();
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

                throw new Exception("Exception occured in method cls_Get_Product_Customizations_and_CustomizationVariants", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Custom Return Type
    [Serializable]
    public class FR_L5PR_GPCaCV_1310 : FR_Base
    {
        public L5PR_GPCaCV_1310 Result { get; set; }

        public FR_L5PR_GPCaCV_1310() : base() { }

        public FR_L5PR_GPCaCV_1310(Exception ex) : base(ex) { }

    }
    #endregion

    #region Support Classes
    #region SClass P_L5PR_GPCaCV_1310 for attribute P_L5PR_GPCaCV_1310
    [DataContract]
    public class P_L5PR_GPCaCV_1310
    {
        //Standard type parameters
        [DataMember]
        public Guid ProductId { get; set; }
        [DataMember]
        public Guid? ProductVariantId { get; set; }

    }
    #endregion
    #region SClass L5PR_GPCaCV_1310 for attribute L5PR_GPCaCV_1310
    [DataContract]
    public class L5PR_GPCaCV_1310
    {
        //Standard type parameters
        [DataMember]
        public ORM_CMN_PRO_CUS_Customization[] Customizations { get; set; }
        [DataMember]
        public ORM_CMN_PRO_CUS_Customization_Variant[] CustomizationVariants { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5PR_GPCaCV_1310 cls_Get_Product_Customizations_and_CustomizationVariants(,P_L5PR_GPCaCV_1310 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5PR_GPCaCV_1310 invocationResult = cls_Get_Product_Customizations_and_CustomizationVariants.Invoke(connectionString,P_L5PR_GPCaCV_1310 Parameter,securityTicket);
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
var parameter = new CL5_Zugseil_Product.Complex.Retrieval.P_L5PR_GPCaCV_1310();
parameter.ProductId = ...;
parameter.ProductVariantId = ...;

*/
