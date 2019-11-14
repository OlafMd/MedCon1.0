/* 
 * Generated on 14/11/2014 12:01:15
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
using CL5_Zugseil_Catalogs.Atomic.Retrieval;

namespace CL5_Zugseil_Catalogs.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Delete_Product_from_CatalogGroup_and_Subgroups.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Delete_Product_from_CatalogGroup_and_Subgroups
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5CA_DPfCGaS_1152 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            //Find all catalog group children and recursivly call delete function for it

            ORM_CMN_PRO_Catalog_ProductGroup.Query children = new ORM_CMN_PRO_Catalog_ProductGroup.Query();
            children.CatalogProductGroup_Parent_RefID = Parameter.CatalogProductGroupID;
            List<ORM_CMN_PRO_Catalog_ProductGroup> childProductGroups = ORM_CMN_PRO_Catalog_ProductGroup.Query.Search(Connection, Transaction, children);

            ORM_CMN_PRO_Catalog_Product catProd = new ORM_CMN_PRO_Catalog_Product();
            catProd.Load(Connection, Transaction, Parameter.CatalogProductID);

            foreach (var child in childProductGroups)
            {
                P_L5CA_GCPfPaCG_1653 param = new P_L5CA_GCPfPaCG_1653() { CatalogGroupID = child.CMN_PRO_Catalog_ProductGroupID, ProductID = catProd.CMN_PRO_Product_RefID };
                var catProduct = cls_Get_CatalogProduct_for_ProductID_and_CatalogGroupID.Invoke(Connection, Transaction, param, securityTicket ).Result.ToList();

                P_L5CA_DPfCGaS_1152 paramForChild = new P_L5CA_DPfCGaS_1152();

                if (catProduct != null && catProduct.Count > 0)
                {
                    foreach(var cp in catProduct)
                    {
                        //P_L5CA_DPfCGaS_1152 paramForChild = new P_L5CA_DPfCGaS_1152();
                        paramForChild.CatalogProductGroupID = child.CMN_PRO_Catalog_ProductGroupID;
                        paramForChild.CatalogProductID = cp.CMN_PRO_Catalog_ProductID;
                        cls_Delete_Product_from_CatalogGroup_and_Subgroups.Invoke(Connection, Transaction, paramForChild, securityTicket);
                    }
                }
                
                paramForChild.CatalogProductGroupID = child.CMN_PRO_Catalog_ProductGroupID;
                paramForChild.CatalogProductID = Parameter.CatalogProductID;
                cls_Delete_Product_from_CatalogGroup_and_Subgroups.Invoke(Connection, Transaction, paramForChild, securityTicket);
                }
            

            //Deletion

            ORM_CMN_PRO_Catalog_Product_2_ProductGroup.Query productAssotiationQuery = new ORM_CMN_PRO_Catalog_Product_2_ProductGroup.Query();
            productAssotiationQuery.CMN_PRO_Catalog_Product_RefID = Parameter.CatalogProductID;
            List<ORM_CMN_PRO_Catalog_Product_2_ProductGroup> productGroups = ORM_CMN_PRO_Catalog_Product_2_ProductGroup.Query.Search(Connection, Transaction, productAssotiationQuery);

            foreach (var prGroup in productGroups.Where(x => x.CMN_PRO_Catalog_ProductGroup_RefID == Parameter.CatalogProductGroupID))
            {
                prGroup.IsDeleted = true;
                prGroup.Save(Connection, Transaction);
            }

            if (productGroups.Where(x => x.CMN_PRO_Catalog_ProductGroup_RefID != Parameter.CatalogProductGroupID).ToList().Count == 0)
            {
                ORM_CMN_PRO_Catalog_Product prod = new ORM_CMN_PRO_Catalog_Product();
                prod.Load(Connection, Transaction, Parameter.CatalogProductID);


                ORM_CMN_PRO_Catalog_Product.Query productQuery = new ORM_CMN_PRO_Catalog_Product.Query();
                productQuery.Tenant_RefID = securityTicket.TenantID;
                productQuery.CMN_PRO_Product_RefID = prod.CMN_PRO_Product_RefID;
                productQuery.IsDeleted = false;
                var products = ORM_CMN_PRO_Catalog_Product.Query.Search(Connection, Transaction, productQuery);

                foreach (var product in products)
                {
                    product.IsDeleted = true;
                    product.Save(Connection, Transaction);
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
		public static FR_Guid Invoke(string ConnectionString,P_L5CA_DPfCGaS_1152 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5CA_DPfCGaS_1152 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5CA_DPfCGaS_1152 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5CA_DPfCGaS_1152 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Delete_Product_from_CatalogGroup_and_Subgroups",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5CA_DPfCGaS_1152 for attribute P_L5CA_DPfCGaS_1152
		[DataContract]
		public class P_L5CA_DPfCGaS_1152 
		{
			//Standard type parameters
			[DataMember]
			public Guid CatalogProductGroupID { get; set; } 
			[DataMember]
			public Guid CatalogProductID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Delete_Product_from_CatalogGroup_and_Subgroups(,P_L5CA_DPfCGaS_1152 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Delete_Product_from_CatalogGroup_and_Subgroups.Invoke(connectionString,P_L5CA_DPfCGaS_1152 Parameter,securityTicket);
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
var parameter = new CL5_Zugseil_Catalogs.Atomic.Manipulation.P_L5CA_DPfCGaS_1152();
parameter.CatalogProductGroupID = ...;
parameter.CatalogProductID = ...;

*/
