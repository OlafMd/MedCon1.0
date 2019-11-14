/* 
 * Generated on 2/3/2015 14:47:58
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
using CL1_CMN;
using CL3_Assortment.Complex.Manipulation;
using CL1_CMN_PRO;
using CL3_Assortment.Atomic.Retrieval;
using CL1_DOC;
using BOp.Infrastructure;
using System.Net;
using CL1_CMN_PRO_ASS;
using BOp.CatalogAPI.data;
using CL5_Zugseil_Product.Complex.Manipulation;

namespace CL5_Zugseil_Assortments.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_AssortmentProducts.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_AssortmentProducts
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Base Execute(DbConnection Connection,DbTransaction Transaction,P_L5AS_SAP_1515 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_Base();

            var defaultLanguages = ORM_CMN_Language.Query.Search(Connection, Transaction, new ORM_CMN_Language.Query
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID
            });
            List<P_L3AS_SAVP_0004> parameterVendorProduct = new List<P_L3AS_SAVP_0004>();
            List<P_L3AS_SAVV_0040> parameterVendorVariants = new List<P_L3AS_SAVV_0040>();
            #region ImportCatalogProducts
            foreach (var productFromCatalog in Parameter.Products.Where(x => !string.IsNullOrEmpty(x.ProductITL)).ToList())
            {
                P_L5PR_IPfC_1648 importProductFromCatalogParameter=new P_L5PR_IPfC_1648();
                importProductFromCatalogParameter.Product = new ProductsForImport();
                importProductFromCatalogParameter.Product.CatalogITL = productFromCatalog.CatalogITL;
                importProductFromCatalogParameter.Product.Code = productFromCatalog.Code;
                importProductFromCatalogParameter.Product.Custom = productFromCatalog.Custom;
                importProductFromCatalogParameter.Product.Description = productFromCatalog.Description;
                importProductFromCatalogParameter.Product.Name = productFromCatalog.Name;
                importProductFromCatalogParameter.Product.LongName = productFromCatalog.LongName;
                importProductFromCatalogParameter.Product.ProductITL = productFromCatalog.ProductITL;
                importProductFromCatalogParameter.Product.Variants = new List<Variant>();
                foreach (var variant in productFromCatalog.Variants)
                {
                    importProductFromCatalogParameter.Product.Variants.Add(variant);

                }
                importProductFromCatalogParameter.Product.Customizations = new List<Customization>();

                if (productFromCatalog.Customizations != null)
                {
                    foreach (var customization in productFromCatalog.Customizations)
                    {
                        importProductFromCatalogParameter.Product.Customizations.Add(customization);
                    }
                }

                importProductFromCatalogParameter.Product.Vat = productFromCatalog.Vat;
                Guid productID= cls_Import_Product_from_Catalog.Invoke(Connection, Transaction, importProductFromCatalogParameter, securityTicket).Result;
                Parameter.Products.Where(x => x.ProductITL == productFromCatalog.ProductITL).ToList().ForEach(x => x.LocalProductID = productID);
            }
            #endregion import

            foreach (var parameterProduct in Parameter.Products)
            {
                ORM_CMN_PRO_Product productDB = new ORM_CMN_PRO_Product();

                #region loadProduct
               
                productDB.Load(Connection, Transaction, parameterProduct.LocalProductID);
           
                Guid originalProductId = productDB.CMN_PRO_ProductID;
                #endregion
                P_L3AS_GNoPiAfP_1512 parameterAssortmentProductExists = new P_L3AS_GNoPiAfP_1512();
                parameterAssortmentProductExists.AssortmentID = Parameter.AssortmentID;
                parameterAssortmentProductExists.ProductRefID = originalProductId;
                int numberOfProductsInAssortment = cls_Get_Number_of_Products_in_Assortment_for_ProductID.Invoke(Connection, Transaction, parameterAssortmentProductExists, securityTicket).Result.NumberOfProducts;

                if (numberOfProductsInAssortment == 0)
                {
                    #region SaveProductCopy
                    ORM_CMN_PRO_Product productCopyToCreate = new ORM_CMN_PRO_Product();

                    productCopyToCreate.CMN_PRO_ProductID = Guid.NewGuid();
                    productCopyToCreate.ProductITL = string.Empty;
                    productCopyToCreate.IsProduct_Article = true;
                    productCopyToCreate.IsProductAvailableForOrdering = true;
                    productCopyToCreate.IsImportedFromExternalCatalog = false;
                    productCopyToCreate.IsProductForInternalDistributionOnly = true;
                    productCopyToCreate.Product_Name = new Dict(ORM_CMN_PRO_Product.TableName);
                    productCopyToCreate.Product_Description = new Dict(ORM_CMN_PRO_Product.TableName);
                    productCopyToCreate.PackageInfo_RefID = Guid.NewGuid();
                    productCopyToCreate.Creation_Timestamp = DateTime.Now;
                    productCopyToCreate.Tenant_RefID = securityTicket.TenantID;
                    productCopyToCreate.IsDeleted = false;
                    productCopyToCreate.Save(Connection, Transaction);
                    productCopyToCreate.Product_Number = productDB.Product_Number;
                    foreach (var lang in defaultLanguages)
                    {
                        productCopyToCreate.Product_Name.UpdateEntry(lang.CMN_LanguageID, productDB.Product_Name.Contents.FirstOrDefault().Content);
                        productCopyToCreate.Product_Description.UpdateEntry(lang.CMN_LanguageID, productDB.Product_Description.Contents.FirstOrDefault().Content);
                    }
                    productCopyToCreate.ProductType_RefID = Guid.Empty;
                    productCopyToCreate.ProductSuccessor_RefID = Guid.Empty;
                    productCopyToCreate.IsDeleted = false;
                    var productDocumentStructureRefID = Guid.NewGuid();
                    if (productDB.Product_DocumentationStructure_RefID != Guid.Empty)
                    {
                        productCopyToCreate.Product_DocumentationStructure_RefID = productDocumentStructureRefID;
                    }
                    productCopyToCreate.Save(Connection, Transaction);
                    #endregion

                    #region copyPicture
                     if (productDB.Product_DocumentationStructure_RefID != Guid.Empty)
                     {
                         var documentStructureHeaders = ORM_DOC_Structure_Header.Query.Search(Connection, Transaction, new ORM_DOC_Structure_Header.Query { DOC_Structure_HeaderID = productDB.Product_DocumentationStructure_RefID });
                         if (documentStructureHeaders != null && documentStructureHeaders.Count() > 0)
                         {
                             var documentStructureHeader = documentStructureHeaders.First();
                             ORM_DOC_Structure_Header docStructureHeaderToCreate = new ORM_DOC_Structure_Header();
                             docStructureHeaderToCreate.DOC_Structure_HeaderID = productDocumentStructureRefID;
                             docStructureHeaderToCreate.IsDeleted = false;
                             docStructureHeaderToCreate.Label = documentStructureHeader.Label;
                             docStructureHeaderToCreate.Tenant_RefID = securityTicket.TenantID;
                             docStructureHeaderToCreate.Save(Connection, Transaction);

                             var documentStructures = ORM_DOC_Structure.Query.Search(Connection, Transaction, new ORM_DOC_Structure.Query
                             {
                                 Structure_Header_RefID = documentStructureHeader.DOC_Structure_HeaderID
                             });
                             var documentStructureID=Guid.NewGuid();
                             if(documentStructures!=null && documentStructures.Count()>0)
                             {
                                 var documentStructure = documentStructures.First();
                                 ORM_DOC_Structure structureToCreate = new ORM_DOC_Structure();
                                 structureToCreate.Label = "Product picture";
                                 structureToCreate.DOC_StructureID=documentStructureID;
                                 structureToCreate.Structure_Header_RefID = docStructureHeaderToCreate.DOC_Structure_HeaderID;
                                 structureToCreate.CreatedBy_Account_RefID = securityTicket.AccountID;
                                 structureToCreate.Tenant_RefID = securityTicket.TenantID;
                                 structureToCreate.Save(Connection, Transaction);

                                 var document2DocumentStructures = ORM_DOC_Document_2_Structure.Query.Search(Connection, Transaction, new ORM_DOC_Document_2_Structure.Query
                                 {
                                     Structure_RefID = documentStructure.DOC_StructureID
                                 });

                                 if (document2DocumentStructures != null && document2DocumentStructures.Count()>0)
                                 {
                                     var document2DocumentStructure = document2DocumentStructures.First();

                                     var documentService = InfrastructureFactory.CreateDocumentService();
                                     var webClient = new WebClient();
                                     var imageBytes=webClient.DownloadData(documentService.GenerateDownloadLink(document2DocumentStructure.Document_RefID));

                                     var documentID = documentService.UploadDocument(imageBytes, productCopyToCreate.Product_Number,securityTicket.SessionTicket,null,null);    
                                     ORM_DOC_Document documentToCreate = new ORM_DOC_Document();
                                     documentToCreate.DOC_DocumentID = documentID;
                                         documentToCreate.Tenant_RefID = securityTicket.TenantID;
                                         documentToCreate.Save(Connection, Transaction);


                                         ORM_DOC_Document_2_Structure documentStructureToSave = new ORM_DOC_Document_2_Structure();
                                         documentStructureToSave.Document_RefID = documentToCreate.DOC_DocumentID;
                                         documentStructureToSave.Structure_RefID = structureToCreate.DOC_StructureID;
                                         documentStructureToSave.StructureHeader_RefID = docStructureHeaderToCreate.DOC_Structure_HeaderID;
                                         documentStructureToSave.Tenant_RefID = securityTicket.TenantID;
                                         documentStructureToSave.Save(Connection, Transaction);

                                        
                                     
                                    
                                 }
                             
                             }
                              
                         
                         }
                     
                     }

                    #endregion



                    var dimensionsDb = ORM_CMN_PRO_Dimension.Query.Search(Connection, Transaction, new ORM_CMN_PRO_Dimension.Query
                    {
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID,
                        Product_RefID = originalProductId

                    });

                    List<ORM_CMN_PRO_Dimension_Value> dimensionValuesToCreate = new List<ORM_CMN_PRO_Dimension_Value>();
                   
                    #region SaveDimensions
                    foreach (var dimensionDb in dimensionsDb)
                    {
                        var dimensionName = dimensionDb.DimensionName;
                        var dimensionID = dimensionDb.CMN_PRO_DimensionID;

                        ORM_CMN_PRO_Dimension dimensionCopyToCreate = new ORM_CMN_PRO_Dimension();
                        dimensionCopyToCreate.CMN_PRO_DimensionID = Guid.NewGuid();
                        dimensionCopyToCreate.Creation_Timestamp = DateTime.Now;
                        dimensionCopyToCreate.DimensionName = new Dict(ORM_CMN_PRO_Dimension.TableName);
                        dimensionCopyToCreate.IsDeleted = false;
                        dimensionCopyToCreate.IsDimensionTemplate = false;
                        dimensionCopyToCreate.Product_RefID = productCopyToCreate.CMN_PRO_ProductID;
                        dimensionCopyToCreate.Tenant_RefID = securityTicket.TenantID;
                        dimensionCopyToCreate.OrderSequence = dimensionDb.OrderSequence;
                        dimensionCopyToCreate.Modification_Timestamp = DateTime.Now;
                       dimensionCopyToCreate.Save(Connection, Transaction);
                        foreach (var lang in defaultLanguages)
                        {
                            dimensionCopyToCreate.DimensionName.UpdateEntry(lang.CMN_LanguageID, dimensionName.Contents.FirstOrDefault().Content);

                        }
                        dimensionCopyToCreate.Save(Connection, Transaction);

                        var dimensionValuesDb = ORM_CMN_PRO_Dimension_Value.Query.Search(Connection, Transaction, new ORM_CMN_PRO_Dimension_Value.Query
                        {
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false,
                            Dimensions_RefID = dimensionID
                        });

                        dimensionValuesDb.ForEach(x => x.Dimensions_RefID = dimensionCopyToCreate.CMN_PRO_DimensionID);
                        dimensionValuesToCreate.AddRange(dimensionValuesDb);
                    }
                    #endregion

                    var productVariantsDb = ORM_CMN_PRO_Product_Variant.Query.Search(Connection, Transaction, new ORM_CMN_PRO_Product_Variant.Query
                    {
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false,
                        CMN_PRO_Product_RefID = originalProductId
                    });

                

                    #region AssortmentProductSave
                    ORM_CMN_PRO_ASS_AssortmentProduct assortmentProductToCreate = new ORM_CMN_PRO_ASS_AssortmentProduct();
                    assortmentProductToCreate.CMN_PRO_ASS_AssortmentProductID = Guid.NewGuid();
                    assortmentProductToCreate.Ext_CMN_PRO_Product_RefID = productCopyToCreate.CMN_PRO_ProductID;
                    assortmentProductToCreate.IsDeleted = false;
                    assortmentProductToCreate.Tenant_RefID = securityTicket.TenantID;
                    assortmentProductToCreate.Save(Connection, Transaction);
                    #endregion

                    #region Assortment Vendor Product Save
                    P_L3AS_SAVP_0004 parameterVendorProductItem = new P_L3AS_SAVP_0004();
                    parameterVendorProductItem.AssortmentProductID = assortmentProductToCreate.CMN_PRO_ASS_AssortmentProductID;
                    parameterVendorProductItem.ProductRefID = originalProductId;
                    parameterVendorProduct.Add(parameterVendorProductItem);
                    ORM_CMN_PRO_ASS_AssortmentProduct_VendorProduct assortmentVendorProductToCreate = new ORM_CMN_PRO_ASS_AssortmentProduct_VendorProduct();
                
                    #endregion

                    #region Assortment2Assortment Product save
                    ORM_CMN_PRO_ASS_Assortment_2_AssortmentProduct assortmentToAssortmentProductToCreate = new ORM_CMN_PRO_ASS_Assortment_2_AssortmentProduct();
                    assortmentToAssortmentProductToCreate.AssignmentID = Guid.NewGuid();
                    assortmentToAssortmentProductToCreate.CMN_PRO_ASS_Assortment_Product_RefID = assortmentProductToCreate.CMN_PRO_ASS_AssortmentProductID;
                    assortmentToAssortmentProductToCreate.CMN_PRO_ASS_Assortment_RefID = Parameter.AssortmentID;
                    assortmentToAssortmentProductToCreate.IsDeleted = false;
                    assortmentToAssortmentProductToCreate.Tenant_RefID = securityTicket.TenantID;
                    assortmentToAssortmentProductToCreate.Save(Connection, Transaction);
                    #endregion
                    List<ORM_CMN_PRO_Variant_DimensionValue> variantDimensionValueAssignmentToCreate = new List<ORM_CMN_PRO_Variant_DimensionValue>();
                    foreach (var productVariantDb in productVariantsDb)
                    {

                        #region ProductVariant Save
                        ORM_CMN_PRO_ASS_DistributionPrice distributionPriceToCreate = new ORM_CMN_PRO_ASS_DistributionPrice();
                        distributionPriceToCreate.CMN_PRO_ASS_DistributionPriceID = Guid.NewGuid();
                        distributionPriceToCreate.IsDeleted = false;
                        distributionPriceToCreate.Tenant_RefID = securityTicket.TenantID;
                        distributionPriceToCreate.Save(Connection, Transaction);

                        ORM_CMN_PRO_Product_Variant productVariantToCreate = new ORM_CMN_PRO_Product_Variant();
                        productVariantToCreate.CMN_PRO_Product_VariantID = Guid.NewGuid();
                        productVariantToCreate.CMN_PRO_Product_RefID = productCopyToCreate.CMN_PRO_ProductID;
                        productVariantToCreate.Creation_Timestamp = DateTime.Now;
                        productVariantToCreate.Tenant_RefID = securityTicket.TenantID;
                        productVariantToCreate.ProductVariantITL = "";
                        productVariantToCreate.ProductVariant_DocumentationStructure_RefID = Guid.Empty;
                        productVariantToCreate.VariantName = new Dict(ORM_CMN_PRO_Product_Variant.TableName);
                        productVariantToCreate.IsDeleted = false;
                        productVariantToCreate.IsStandardProductVariant = productVariantDb.IsStandardProductVariant;
                        productVariantToCreate.IsImportedFromExternalCatalog = false;
                        productVariantToCreate.Modification_Timestamp = DateTime.Now;
                      
                        productVariantToCreate.Save(Connection, Transaction);
                        foreach (var lang in defaultLanguages)
                        {
                            productVariantToCreate.VariantName.UpdateEntry(lang.CMN_LanguageID, productVariantDb.VariantName.Contents.FirstOrDefault().Content);

                        }
                        productVariantToCreate.Save(Connection, Transaction);
                   
                        #endregion

                        #region dimensionValuesAssignemnt
                    
                            var assignmentExists = ORM_CMN_PRO_Variant_DimensionValue.Query.Search(Connection, Transaction, new ORM_CMN_PRO_Variant_DimensionValue.Query
                            {
                                Tenant_RefID = securityTicket.TenantID,
                           
                                ProductVariant_RefID = productVariantDb.CMN_PRO_Product_VariantID

                            });
                        foreach(var variantAssignment in assignmentExists)
                        {

                         
                            variantAssignment.IsDeleted = false;
                            variantAssignment.ProductVariant_RefID = productVariantToCreate.CMN_PRO_Product_VariantID;
                            variantAssignment.Tenant_RefID = securityTicket.TenantID;

                            variantDimensionValueAssignmentToCreate.Add(variantAssignment);
                            
                            }
                        #endregion

                        #region AddVariantToAssortment
                        ORM_CMN_PRO_ASS_AssortmentVariant assortmentVariantToCreate = new ORM_CMN_PRO_ASS_AssortmentVariant();
                        assortmentVariantToCreate.CMN_PRO_ASS_AssortmentVariantID = Guid.NewGuid();
                        assortmentVariantToCreate.Ext_CMN_PRO_Product_Variant_RefID = productVariantToCreate.CMN_PRO_Product_VariantID;
                        assortmentVariantToCreate.IsDeleted = false;
                        assortmentVariantToCreate.DistributionPrice_RefID = distributionPriceToCreate.CMN_PRO_ASS_DistributionPriceID;
                        assortmentVariantToCreate.Tenant_RefID = securityTicket.TenantID;
                        assortmentVariantToCreate.Save(Connection, Transaction);
                        #endregion
                             P_L3AS_SAVV_0040 parameterVendorVariantItem = new P_L3AS_SAVV_0040();
                             parameterVendorVariantItem.AssortmentVariantID = assortmentVariantToCreate.CMN_PRO_ASS_AssortmentVariantID;
                             parameterVendorVariantItem.ProductVariantID = productVariantDb.CMN_PRO_Product_VariantID;
                             parameterVendorVariantItem.OrderSequence = 1;
                             parameterVendorVariantItem.IsDefaultVendorVariant = true;
                             parameterVendorVariants.Add(parameterVendorVariantItem);
                    }

                    #region SaveDimensionValuesAndAssignment
                    foreach (var dimensionValueToCreate in dimensionValuesToCreate)
                    {

                        var valueName = dimensionValueToCreate.DimensionValue_Text;
                        var valueID = dimensionValueToCreate.CMN_PRO_Dimension_ValueID;

                        ORM_CMN_PRO_Dimension_Value dimensionValueToCreateUpdate = new ORM_CMN_PRO_Dimension_Value();
                        dimensionValueToCreateUpdate.CMN_PRO_Dimension_ValueID = Guid.NewGuid();
                        dimensionValueToCreateUpdate.Creation_Timestamp = DateTime.Now;
                        dimensionValueToCreateUpdate.DimensionValue_Text = new Dict(ORM_CMN_PRO_Dimension_Value.TableName);
                        dimensionValueToCreateUpdate.Dimensions_RefID = dimensionValueToCreate.Dimensions_RefID;
                        dimensionValueToCreateUpdate.IsDeleted = false;
                        dimensionValueToCreateUpdate.Tenant_RefID = securityTicket.TenantID;
                        dimensionValueToCreateUpdate.Modification_Timestamp = DateTime.Now;
                        dimensionValueToCreateUpdate.OrderSequence = dimensionValueToCreate.OrderSequence;
                        dimensionValueToCreateUpdate.Save(Connection, Transaction);
                        foreach (var lang in defaultLanguages)
                        {
                            dimensionValueToCreateUpdate.DimensionValue_Text.UpdateEntry(lang.CMN_LanguageID, valueName.Contents.FirstOrDefault().Content);
                        }
                        dimensionValueToCreateUpdate.Save(Connection, Transaction);

                        var assignments = variantDimensionValueAssignmentToCreate.Where(x => x.DimensionValue_RefID == valueID).ToList();
                        foreach (var assignment in assignments)
                        {
                            ORM_CMN_PRO_Variant_DimensionValue assignmentToSave = new ORM_CMN_PRO_Variant_DimensionValue();
                            assignmentToSave.CMN_PRO_Variant_DimensionValueID = Guid.NewGuid();
                            assignmentToSave.Creation_Timestamp = DateTime.Now;
                            assignmentToSave.DimensionValue_RefID = dimensionValueToCreateUpdate.CMN_PRO_Dimension_ValueID;
                            assignmentToSave.IsDeleted = false;
                            assignmentToSave.Modification_Timestamp = DateTime.Now;
                            assignmentToSave.ProductVariant_RefID = assignment.ProductVariant_RefID;
                            assignmentToSave.Tenant_RefID = securityTicket.TenantID;
                            assignmentToSave.Save(Connection, Transaction);



                        }
                    }
                    #endregion
                }

            }
            cls_Save_Assortment_Vendor_Products.Invoke(Connection, Transaction, parameterVendorProduct.ToArray(),securityTicket);
            cls_Save_Assortment_Vendor_Variants.Invoke(Connection, Transaction, parameterVendorVariants.ToArray(), securityTicket);

            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Base Invoke(string ConnectionString,P_L5AS_SAP_1515 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection,P_L5AS_SAP_1515 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AS_SAP_1515 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AS_SAP_1515 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Base functionReturn = new FR_Base();
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

				throw new Exception("Exception occured in method cls_Save_AssortmentProducts",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5AS_SAP_1515 for attribute P_L5AS_SAP_1515
		[DataContract]
		public class P_L5AS_SAP_1515 
		{
			[DataMember]
			public AssortmentProduct[] Products { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid AssortmentID { get; set; } 

		}
		#endregion
		#region SClass AssortmentProduct for attribute Products
		[DataContract]
		public class AssortmentProduct:Product
		{
			//Standard type parameters
			[DataMember]
			public Guid LocalProductID { get; set; } 
			[DataMember]
			public string CatalogITL { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Base cls_Save_AssortmentProducts(,P_L5AS_SAP_1515 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Base invocationResult = cls_Save_AssortmentProducts.Invoke(connectionString,P_L5AS_SAP_1515 Parameter,securityTicket);
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
var parameter = new CL5_Zugseil_Assortments.Complex.Manipulation.P_L5AS_SAP_1515();
parameter.Products = ...;

parameter.AssortmentID = ...;

*/
