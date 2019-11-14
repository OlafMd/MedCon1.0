/* 
 * Generated on 12/25/2013 9:45:17 AM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 * Required Assemblies:
 * System.Runtime.Serialization
 * CSV2Core
 * CSV2Core_MySQL
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;
using System.Runtime.Serialization;
using CL1_CMN_PRO;
using CL5_APOAdmin_Catalogs.Atomic.Manipulation;
using CL3_Catalog.Utils;

namespace CL5_Catalog.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Catalog_BaseData.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Catalog_BaseData
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5SCBD_1454 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here

            #region Save

            ORM_CMN_PRO_Catalog catalog = new ORM_CMN_PRO_Catalog();
            ORM_CMN_PRO_MasterCatalog mc = new ORM_CMN_PRO_MasterCatalog();

            #region Delete
            if (Parameter.isDeleted == true)
            {

                /*
                * @Delete Catalog
                * */
                catalog.Load(Connection, Transaction, Parameter.CatalogID);
                catalog.IsDeleted = true;
                catalog.Save(Connection, Transaction);

                /*
                * @Delete Catalog's master catalog
                * */
                ORM_CMN_PRO_MasterCatalog masterCata = new ORM_CMN_PRO_MasterCatalog();
                masterCata.Load(Connection, Transaction, catalog.CMN_PRO_MasterCatalog_RefID);
                masterCata.IsDeleted = true;
                masterCata.Save(Connection, Transaction);

                /*
                * @Delete CMN_PRO_Catalog_Revisions
                * */
                var catalogRevisionQuery = new ORM_CMN_PRO_Catalog_Revision.Query();
                catalogRevisionQuery.Tenant_RefID = securityTicket.TenantID;
                catalogRevisionQuery.CMN_PRO_Catalog_RefID = Parameter.CatalogID;

                var catalogRevisionDel = ORM_CMN_PRO_Catalog_Revision.Query.Search(Connection, Transaction, catalogRevisionQuery);
                if (catalogRevisionDel != null)
                {
                    foreach (var item in catalogRevisionDel)
                    {
                        ORM_CMN_PRO_Catalog_ProductGroup.Query searchProductGroupQuery = new ORM_CMN_PRO_Catalog_ProductGroup.Query();
                        searchProductGroupQuery.Catalog_Revision_RefID = item.CMN_PRO_Catalog_RevisionID;
                        List<ORM_CMN_PRO_Catalog_ProductGroup> revisionGroups = ORM_CMN_PRO_Catalog_ProductGroup.Query.Search(Connection,Transaction, searchProductGroupQuery);

                        /*
                        * @Deep delete product groups
                        * */
                        P_L5CA_DCPG_1049 delParam = new P_L5CA_DCPG_1049();
                        foreach(var group in revisionGroups) {
                            delParam.ProductGroupID = group.CMN_PRO_Catalog_ProductGroupID;
                            cls_Delete_Catalog_Product_Group.Invoke(Connection, Transaction, delParam);
                        }

                        /*
                        * @Delete products that are in root of catalog revision (not in group)
                        * */
                        ORM_CMN_PRO_Catalog_Product.Query revisionProductsQuery = new ORM_CMN_PRO_Catalog_Product.Query();
                        revisionProductsQuery.CMN_PRO_Catalog_Revision_RefID = item.CMN_PRO_Catalog_RevisionID;
                        List<ORM_CMN_PRO_Catalog_Product> revisionProducts = ORM_CMN_PRO_Catalog_Product.Query.Search(Connection, Transaction, revisionProductsQuery);

                        foreach(var product in revisionProducts)
                        {
                            product.IsDeleted = true;
                            product.Save(Connection, Transaction);
                        }

                        /*
                        * @Delete catalog revision
                        * */
                        item.IsDeleted = true;
                        item.Save(Connection, Transaction);
                    }
                }

                returnValue.Result = Parameter.CatalogID;
                return returnValue;
            }
            #endregion


            /*
            * @save CMN_PRO_Catalogs
            * */
            if (Parameter.CatalogID == Guid.Empty)
            {

                mc.CMN_PRO_MasterCatalogID = Guid.NewGuid();
                mc.Catalog_Description = new Dict();
                mc.Catalog_Name = Parameter.CatalogName_Dict;
                mc.CatalogPublishing_DefaultCurrency_RefID = Parameter.Catalog_Currency_RefID;
                mc.CatalogPublishing_DefaultLanguage_RefID = Parameter.Catalog_Language_RefID;
                mc.Creation_Timestamp = DateTime.Now;
                mc.Save(Connection, Transaction);

                catalog.CMN_PRO_CatalogID = Guid.NewGuid();
                catalog.CMN_PRO_MasterCatalog_RefID = mc.CMN_PRO_MasterCatalogID;
                catalog.Tenant_RefID = securityTicket.TenantID;
                catalog.IsPublicCatalog = Parameter.isPublic;
                catalog.CatalogCodeITL = RandomString.Generate(8);
                catalog.Creation_Timestamp = DateTime.Now;
                catalog.IsDeleted = false;
                if (Parameter.Catalog_Currency_RefID != Guid.Empty)
                    catalog.Catalog_Currency_RefID = Parameter.Catalog_Currency_RefID;
                if (Parameter.Catalog_Language_RefID != Guid.Empty)
                    catalog.Catalog_Language_RefID = Parameter.Catalog_Language_RefID;

                catalog.Save(Connection, Transaction);

                /*
                * @save Revision
                * */

                ORM_CMN_PRO_Catalog_Revision rev = new ORM_CMN_PRO_Catalog_Revision();
                rev.CMN_PRO_Catalog_RevisionID = Guid.NewGuid();
                rev.CMN_PRO_Catalog_RefID = catalog.CMN_PRO_CatalogID;
                rev.Tenant_RefID = securityTicket.TenantID;
                rev.Creation_Timestamp = DateTime.Now;
                rev.CatalogRevision_Description = "Initial revision for catalog ";
                rev.CatalogRevision_Name = "Initial catalog revision";
                rev.IsDeleted = false;
                rev.RevisionNumber = 1;
                rev.Save(Connection, Transaction);

            }
            else
            {
                /*
                * @edit Catalog
                * */

                catalog.Load(Connection, Transaction, Parameter.CatalogID);
                catalog.Tenant_RefID = securityTicket.TenantID;
                catalog.IsPublicCatalog = Parameter.isPublic;
                catalog.IsDeleted = false;
                if (Parameter.Catalog_Currency_RefID != Guid.Empty)
                    catalog.Catalog_Currency_RefID = Parameter.Catalog_Currency_RefID;
                if (Parameter.Catalog_Language_RefID != Guid.Empty)
                    catalog.Catalog_Language_RefID = Parameter.Catalog_Language_RefID;

                catalog.Save(Connection, Transaction);

                mc.Load(Connection, Transaction, catalog.CMN_PRO_MasterCatalog_RefID);
                mc.Catalog_Name = Parameter.CatalogName_Dict;
                mc.CatalogPublishing_DefaultCurrency_RefID = Parameter.Catalog_Currency_RefID;
                mc.CatalogPublishing_DefaultLanguage_RefID = Parameter.Catalog_Language_RefID;

                mc.Save(Connection, Transaction);

            }

            #endregion
            returnValue.Result = Parameter.CatalogID;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5SCBD_1454 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5SCBD_1454 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5SCBD_1454 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5SCBD_1454 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Catalog_BaseData",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5SCBD_1454 for attribute P_L5SCBD_1454
		[DataContract]
		public class P_L5SCBD_1454 
		{
			//Standard type parameters
			[DataMember]
			public Guid CatalogID { get; set; } 
			[DataMember]
			public Dict CatalogName_Dict { get; set; } 
			[DataMember]
			public Guid Catalog_Currency_RefID { get; set; } 
			[DataMember]
			public Guid Catalog_Language_RefID { get; set; } 
			[DataMember]
			public bool isPublic { get; set; } 
			[DataMember]
			public bool isDeleted { get; set; } 
			[DataMember]
			public string CatalogeCodeITL { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Catalog_BaseData(,P_L5SCBD_1454 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Catalog_BaseData.Invoke(connectionString,P_L5SCBD_1454 Parameter,securityTicket);
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
var parameter = new CL5_Catalog.Atomic.Manipulation.P_L5SCBD_1454();
parameter.CatalogID = ...;
parameter.CatalogName_Dict = ...;
parameter.Catalog_Currency_RefID = ...;
parameter.Catalog_Language_RefID = ...;
parameter.isPublic = ...;
parameter.isDeleted = ...;
parameter.CatalogeCodeITL = ...;

*/
