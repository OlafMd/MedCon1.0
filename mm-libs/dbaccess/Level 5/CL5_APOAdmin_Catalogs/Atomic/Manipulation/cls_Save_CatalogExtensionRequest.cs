/* 
 * Generated on 12/27/2013 11:12:08 AM
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
using System.Runtime.Serialization;
using CL1_CMN_BPT_CTM;
using CL1_USR;
using CL1_CMN_PRO;

namespace CL5_APOAdmin_Catalogs.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_CatalogExtensionRequest.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_CatalogExtensionRequest
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5CA_SCER_0931 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_Guid();

            ORM_CMN_BPT_CTM_CatalogProductExtensionRequests request = new ORM_CMN_BPT_CTM_CatalogProductExtensionRequests();
            request.Load(Connection, Transaction, Parameter.RequestID);

            if (Parameter.SendAnswer)
            {
                ORM_USR_Account account = new ORM_USR_Account();
                account.Load(Connection, Transaction, securityTicket.AccountID);

                request.IfAnswerSent_By_BusinessParticipant_RefID = account.BusinessParticipant_RefID;
                request.IfAnswerSent_Date = DateTime.Now;
            }
            request.IsAnswerSent = Parameter.SendAnswer;
            request.Request_Answer = Parameter.RequestAnswer;
            request.Save(Connection, Transaction);

            #region Add products
            ORM_CMN_BPT_CTM_CatalogProductExtensionRequest_Product product = null;

            if (Parameter.Products != null)
            {
                foreach (P_L5CA_SCER_0931a item in Parameter.Products)
                {
                    ORM_CMN_PRO_Product.Query prodQuery = new ORM_CMN_PRO_Product.Query() 
                    {
                        CMN_PRO_ProductID = item.ProductID,
                        IsDeleted = false, 
                        Tenant_RefID = securityTicket.TenantID
                    };
                    var prod = ORM_CMN_PRO_Product.Query.Search(Connection, Transaction, prodQuery).Single();
                    if (String.IsNullOrEmpty(prod.ProductITL))
                    {
                        prod.ProductITL = prod.CMN_PRO_ProductID.ToString();
                        prod.Save(Connection, Transaction);
                    }

                    if (item.IsDeleted)
                    {
                        ORM_CMN_BPT_CTM_CatalogProductExtensionRequest_Product.Query query = new ORM_CMN_BPT_CTM_CatalogProductExtensionRequest_Product.Query();
                        query.CatalogProductExtensionRequest_RefID = request.CMN_BPT_CTM_CatalogProductExtensionRequestID;
                        query.CMN_BPT_CTM_CatalogProductExtensionRequest_ProductID = item.Request_ProductID;
                        //query.Tenant_RefID = securityTicket.TenantID;
                        //ORM_CMN_BPT_CTM_CatalogProductExtensionRequest_Product.Query.SoftDelete(Connection, Transaction, query);
                        var itemToDelete = ORM_CMN_BPT_CTM_CatalogProductExtensionRequest_Product.Query.Search(Connection, Transaction, query).SingleOrDefault();
                        if (itemToDelete != default(ORM_CMN_BPT_CTM_CatalogProductExtensionRequest_Product))
                        {
                            itemToDelete.IsDeleted = true;
                            itemToDelete.Save(Connection, Transaction);
                        }
                        continue;
                    }

                    product = new ORM_CMN_BPT_CTM_CatalogProductExtensionRequest_Product();
                    product.CMN_BPT_CTM_CatalogProductExtensionRequest_ProductID = Guid.NewGuid();
                    product.CatalogProductExtensionRequest_RefID = request.CMN_BPT_CTM_CatalogProductExtensionRequestID;
                    product.CMN_PRO_Product_RefID = prod.CMN_PRO_ProductID;
                    product.Creation_Timestamp = DateTime.Now;
                    product.Tenant_RefID = securityTicket.TenantID;
                    product.Comment = "";
                    product.Save(Connection, Transaction);
                }
            }
            #endregion

            #region Save products in Catalog Products for Catalog Revision

            if (Parameter.Products != null)
            {
                // Find catalog revision
                var catalogRevision = ORM_CMN_PRO_Catalog_Revision.Query.Search(Connection, Transaction,
                    new ORM_CMN_PRO_Catalog_Revision.Query
                    {
                        PublishedBy_BusinessParticipant_RefID = Guid.Empty,
                        CMN_PRO_Catalog_RefID = request.RequestedFor_Catalog_RefID,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).OrderByDescending(x => x.PublishedOn_Date).FirstOrDefault();

                if (catalogRevision != null)
                {
                    foreach (P_L5CA_SCER_0931a item in Parameter.Products)
                    {
                        // Find product
                        var p = ORM_CMN_PRO_Product.Query.Search(Connection, Transaction,
                            new ORM_CMN_PRO_Product.Query()
                        {
                            CMN_PRO_ProductID = item.ProductID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        }).Single();

                        // Find catalog product for product
                        var catalogProduct = ORM_CMN_PRO_Catalog_Product.Query.Search(Connection, Transaction,
                            new ORM_CMN_PRO_Catalog_Product.Query
                            {
                                CMN_PRO_Catalog_Revision_RefID = catalogRevision.CMN_PRO_Catalog_RevisionID,
                                CMN_PRO_Product_RefID = p.CMN_PRO_ProductID,
                                Tenant_RefID = p.Tenant_RefID,
                                IsDeleted = false
                            }).SingleOrDefault();


                        // If product not exist then add product to catalog products
                        if (catalogProduct == null)
                        {
                            // Find product variant for product
                            ORM_CMN_PRO_Product_Variant productVariant = null;
                            if (p.HasProductVariants)
                            {
                                productVariant = ORM_CMN_PRO_Product_Variant.Query.Search(Connection, Transaction,
                                   new ORM_CMN_PRO_Product_Variant.Query
                                   {
                                       CMN_PRO_Product_RefID = p.CMN_PRO_ProductID,
                                       Tenant_RefID = p.Tenant_RefID,
                                       IsStandardProductVariant = true,
                                       IsDeleted = false
                                   }).OrderByDescending(x => x.Creation_Timestamp).FirstOrDefault();
                            }

                            // Create catalog product for product
                            catalogProduct = new ORM_CMN_PRO_Catalog_Product();
                            catalogProduct.CMN_PRO_Catalog_Revision_RefID = catalogRevision.CMN_PRO_Catalog_RevisionID;
                            catalogProduct.CMN_PRO_Product_RefID = p.CMN_PRO_ProductID;
                            catalogProduct.CMN_PRO_Product_Variant_RefID = p.HasProductVariants ? productVariant.CMN_PRO_Product_VariantID : Guid.Empty;
                            catalogProduct.Tenant_RefID = securityTicket.TenantID;
                            catalogProduct.Save(Connection, Transaction);
                        }
                        else {

                            if (item.IsDeleted) {
                                catalogProduct.IsDeleted = true;
                                catalogProduct.Save(Connection, Transaction);
                            }
                        
                        }

                    }
                }
            }

            #endregion

            returnValue.Result = request.CMN_BPT_CTM_CatalogProductExtensionRequestID;

            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5CA_SCER_0931 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5CA_SCER_0931 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5CA_SCER_0931 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5CA_SCER_0931 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_CatalogExtensionRequest",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5CA_SCER_0931 for attribute P_L5CA_SCER_0931
		[DataContract]
		public class P_L5CA_SCER_0931 
		{
			[DataMember]
			public P_L5CA_SCER_0931a[] Products { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid RequestID { get; set; } 
			[DataMember]
			public bool SendAnswer { get; set; } 
			[DataMember]
			public Guid LanguageID { get; set; } 
			[DataMember]
			public String RequestAnswer { get; set; } 

		}
		#endregion
		#region SClass P_L5CA_SCER_0931a for attribute Products
		[DataContract]
		public class P_L5CA_SCER_0931a 
		{
			//Standard type parameters
			[DataMember]
			public Guid Request_ProductID { get; set; } 
			[DataMember]
			public String ProductITL { get; set; } 
			[DataMember]
			public Guid ProductID { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_CatalogExtensionRequest(,P_L5CA_SCER_0931 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_CatalogExtensionRequest.Invoke(connectionString,P_L5CA_SCER_0931 Parameter,securityTicket);
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
var parameter = new CL5_APOAdmin_Catalogs.Atomic.Manipulation.P_L5CA_SCER_0931();
parameter.Products = ...;

parameter.RequestID = ...;
parameter.SendAnswer = ...;
parameter.LanguageID = ...;
parameter.RequestAnswer = ...;

*/
