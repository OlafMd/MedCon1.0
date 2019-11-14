/* 
 * Generated on 11/3/2014 3:23:02 PM
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
using CL1_USR;
using CL1_CMN_PRO;
using CL1_CMN_SLS;
using DLCore_DBCommons.Zugseil;
using CL5_Zugseil_Catalogs.Atomic.Retrieval;
using Newtonsoft.Json;


namespace CL5_Zugseil_Catalogs.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Publish_NewCatalogVersion.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Publish_NewCatalogVersion
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5CA_PNCV_1520 Execute(DbConnection Connection,DbTransaction Transaction,P_L5CA_PNCV_1520 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_L5CA_PNCV_1520();
            returnValue.Result = new L5CA_PNCV_1520();

			//Put your code here
            var account = new ORM_USR_Account();
            account.Load(Connection, Transaction, securityTicket.AccountID);

            #region Update active catalog revision

            ORM_CMN_PRO_Catalog_Revision rev = new ORM_CMN_PRO_Catalog_Revision();
            rev.Load(Connection, Transaction, Parameter.CMN_PRO_Catalog_RevisionID);
            rev.Valid_From = Parameter.Valid_From;
            rev.Valid_Through = Parameter.Valid_Through;
            rev.Default_PricelistRelease_RefID = Parameter.Default_PricelistRelease_RefID;
            rev.PublishedBy_BusinessParticipant_RefID = account.BusinessParticipant_RefID;
            rev.PublishedOn_Date = DateTime.Now;

            rev.Save(Connection, Transaction);

            #endregion

            #region Update catalog public/private status
            if (rev.RevisionNumber == 1)
            {
                ORM_CMN_PRO_Catalog catalog = new ORM_CMN_PRO_Catalog();
                catalog.Load(Connection, Transaction, rev.CMN_PRO_Catalog_RefID);

                catalog.IsPublicCatalog = Parameter.IsPublic;

                catalog.Save(Connection, Transaction);
            }
            #endregion

            #region Create new catalog revision

            ORM_CMN_PRO_Catalog_Revision newRev = new ORM_CMN_PRO_Catalog_Revision();
            newRev.CMN_PRO_Catalog_RevisionID = Guid.NewGuid();
            newRev.CMN_PRO_Catalog_RefID = rev.CMN_PRO_Catalog_RefID;
            newRev.Tenant_RefID = securityTicket.TenantID;
            newRev.Creation_Timestamp = DateTime.Now;
            newRev.CatalogRevision_Description = "Revision for Catalog";
            newRev.CatalogRevision_Name = "New Catalog Revision";
            newRev.IsDeleted = false;
            newRev.RevisionNumber = rev.RevisionNumber + 1;
            newRev.Save(Connection, Transaction);

            #endregion

            #region Products

            var oldProducts = ORM_CMN_PRO_Catalog_Product.Query.Search(Connection, Transaction, new ORM_CMN_PRO_Catalog_Product.Query()
            {
                CMN_PRO_Catalog_Revision_RefID = rev.CMN_PRO_Catalog_RevisionID,
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID
            }); 
            
            if (oldProducts.Count == 0)
            {
                returnValue.Result.Status_Code = -1;        // -1 no products in revision
                returnValue.Result.Status_Message = "no products in revision";
                return returnValue;
            }

            //oldProductID - newProductID
            Dictionary<Guid, Guid> productsMapping = new Dictionary<Guid, Guid>();

            var productsWithoutPrices = ProductWithoutPrices(Connection,Transaction, Parameter, securityTicket, oldProducts);
            if (productsWithoutPrices.Count > 0)
            {
                returnValue.Result.Status_Code = -2;                            // -2 => pricelist does not have price for product
                returnValue.Result.Status_Message = JsonConvert.SerializeObject(productsWithoutPrices);
                return returnValue;
            }

            foreach (var item in oldProducts)
            {
                var newProduct = new ORM_CMN_PRO_Catalog_Product()
                {
                    CMN_PRO_Catalog_ProductID = Guid.NewGuid(),
                    CMN_PRO_Product_Variant_RefID = item.CMN_PRO_Product_Variant_RefID,
                    Creation_Timestamp = DateTime.Now,
                    Tenant_RefID = item.Tenant_RefID,
                    CMN_PRO_Catalog_Revision_RefID = newRev.CMN_PRO_Catalog_RevisionID,
                    CMN_PRO_Product_RefID = item.CMN_PRO_Product_RefID,
                };

                newProduct.Save(Connection, Transaction);

                productsMapping.Add(item.CMN_PRO_Catalog_ProductID, newProduct.CMN_PRO_Catalog_ProductID);
            }

            #endregion

            #region ProductGroups

            var oldGroups = ORM_CMN_PRO_Catalog_ProductGroup.Query.Search(Connection, Transaction, new ORM_CMN_PRO_Catalog_ProductGroup.Query()
            {
                Catalog_Revision_RefID = rev.CMN_PRO_Catalog_RevisionID,
                IsDeleted = false
            });

            //oldGroupID - newGroupID 
            Dictionary<Guid, Guid> groupsMapping = new Dictionary<Guid, Guid>();
            groupsMapping.Add(Guid.Empty, Guid.Empty);

            foreach (var item in oldGroups)
            {
                groupsMapping.Add(item.CMN_PRO_Catalog_ProductGroupID, Guid.NewGuid());
            }

            foreach (var item in oldGroups)
            {

                var newGroup = new ORM_CMN_PRO_Catalog_ProductGroup()
                {
                    CMN_PRO_Catalog_ProductGroupID = groupsMapping[item.CMN_PRO_Catalog_ProductGroupID],
                    Catalog_Revision_RefID = newRev.CMN_PRO_Catalog_RevisionID,
                    CatalogProductGroup_Name = item.CatalogProductGroup_Name,
                    CatalogProductGroup_Parent_RefID = groupsMapping[item.CatalogProductGroup_Parent_RefID],
                    Creation_Timestamp = DateTime.Now,
                    Tenant_RefID = item.Tenant_RefID
                };

                newGroup.Save(Connection, Transaction);

                var oldProductsInGroup = ORM_CMN_PRO_Catalog_Product_2_ProductGroup.Query.Search(Connection, Transaction, new ORM_CMN_PRO_Catalog_Product_2_ProductGroup.Query()
                {
                    CMN_PRO_Catalog_ProductGroup_RefID = item.CMN_PRO_Catalog_ProductGroupID,
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                });

                foreach (var product in oldProductsInGroup)
                {
                    if (groupsMapping.ContainsKey(product.CMN_PRO_Catalog_ProductGroup_RefID) && productsMapping.ContainsKey(product.CMN_PRO_Catalog_Product_RefID))
                    {
                        var newProduct = new ORM_CMN_PRO_Catalog_Product_2_ProductGroup()
                        {
                            AssignmentID = Guid.NewGuid(),
                            CMN_PRO_Catalog_ProductGroup_RefID = groupsMapping[product.CMN_PRO_Catalog_ProductGroup_RefID],
                            CMN_PRO_Catalog_Product_RefID = productsMapping[product.CMN_PRO_Catalog_Product_RefID],
                            Creation_Timestamp = DateTime.Now,
                            Tenant_RefID = item.Tenant_RefID
                        };

                        newProduct.Save(Connection, Transaction);
                    }
                }
            }


            #endregion

            returnValue.Result.Status_Code = 1;
            returnValue.Result.Status_Message = "Success";
            returnValue.Result.ID = newRev.CMN_PRO_Catalog_RevisionID;
			return returnValue;
			#endregion UserCode
		}
		#endregion

        #region SUpport methods
        private static List<L5CA_GACPfR_1621> ProductWithoutPrices(DbConnection Connection, DbTransaction Transaction, P_L5CA_PNCV_1520 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket, List<ORM_CMN_PRO_Catalog_Product> oldProducts)
        {
            List<L5CA_GACPfR_1621> products = new List<L5CA_GACPfR_1621>();
            L5CA_GACPfR_1621 product;

            List<Guid> insertedProducts = new List<Guid>();

            foreach (var item in oldProducts)
            {
                if (insertedProducts.Any(i => i == item.CMN_PRO_Product_RefID))
                    continue;

                insertedProducts.Add(item.CMN_PRO_Product_RefID);

                ORM_CMN_SLS_Pricelist_Release plr = new ORM_CMN_SLS_Pricelist_Release();
                plr.Load(Connection, Transaction, Parameter.Default_PricelistRelease_RefID);

                var pricelistPriceQry = new ORM_CMN_SLS_Price.Query()
                {
                    CMN_PRO_Product_RefID = item.CMN_PRO_Product_RefID,
                    PricelistRelease_RefID = plr.CMN_SLS_Pricelist_ReleaseID,
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                };

                var prices = ORM_CMN_SLS_Price.Query.Search(Connection, Transaction, pricelistPriceQry);
                if (prices.Count == 0)
                {
                    ORM_CMN_PRO_Product pr = new ORM_CMN_PRO_Product();
                    pr.Load(Connection, Transaction, item.CMN_PRO_Product_RefID);

                    product = new L5CA_GACPfR_1621();
                    product.Product_Number = pr.Product_Number;
                    product.Product_Name = pr.Product_Name;
                    product.Product_Description = pr.Product_Description;

                    products.Add(product);
                }
            }

            return products;
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5CA_PNCV_1520 Invoke(string ConnectionString,P_L5CA_PNCV_1520 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5CA_PNCV_1520 Invoke(DbConnection Connection,P_L5CA_PNCV_1520 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5CA_PNCV_1520 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5CA_PNCV_1520 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5CA_PNCV_1520 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5CA_PNCV_1520 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5CA_PNCV_1520 functionReturn = new FR_L5CA_PNCV_1520();
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

				throw new Exception("Exception occured in method cls_Publish_NewCatalogVersion",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5CA_PNCV_1520 : FR_Base
	{
		public L5CA_PNCV_1520 Result	{ get; set; }

		public FR_L5CA_PNCV_1520() : base() {}

		public FR_L5CA_PNCV_1520(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5CA_PNCV_1520 for attribute P_L5CA_PNCV_1520
		[DataContract]
		public class P_L5CA_PNCV_1520 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_Catalog_RevisionID { get; set; } 
			[DataMember]
			public DateTime Valid_From { get; set; } 
			[DataMember]
			public DateTime Valid_Through { get; set; } 
			[DataMember]
			public Guid Default_PricelistRelease_RefID { get; set; } 
			[DataMember]
			public Boolean IsPrivate { get; set; } 
			[DataMember]
			public Boolean IsPublic { get; set; } 
			[DataMember]
			public String SendMailTo { get; set; } 
			[DataMember]
			public String CatalogName { get; set; } 
			[DataMember]
			public String Comment { get; set; } 
			[DataMember]
			public Boolean ImportImmidiately { get; set; } 
			[DataMember]
			public Boolean ImportLater { get; set; } 
			[DataMember]
			public DateTime ImportOnDate { get; set; } 
			[DataMember]
			public EPrivateCatalogType CatalogType { get; set; } 

		}
		#endregion
		#region SClass L5CA_PNCV_1520 for attribute L5CA_PNCV_1520
		[DataContract]
		public class L5CA_PNCV_1520 
		{
			//Standard type parameters
			[DataMember]
			public int Status_Code { get; set; } 
			[DataMember]
			public String Status_Message { get; set; } 
			[DataMember]
			public Guid ID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5CA_PNCV_1520 cls_Publish_NewCatalogVersion(,P_L5CA_PNCV_1520 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5CA_PNCV_1520 invocationResult = cls_Publish_NewCatalogVersion.Invoke(connectionString,P_L5CA_PNCV_1520 Parameter,securityTicket);
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
var parameter = new CL5_Zugseil_Catalogs.Complex.Manipulation.P_L5CA_PNCV_1520();
parameter.CMN_PRO_Catalog_RevisionID = ...;
parameter.Valid_From = ...;
parameter.Valid_Through = ...;
parameter.Default_PricelistRelease_RefID = ...;
parameter.IsPrivate = ...;
parameter.IsPublic = ...;
parameter.SendMailTo = ...;
parameter.CatalogName = ...;
parameter.Comment = ...;
parameter.ImportImmidiately = ...;
parameter.ImportLater = ...;
parameter.ImportOnDate = ...;
parameter.CatalogType = ...;

*/
