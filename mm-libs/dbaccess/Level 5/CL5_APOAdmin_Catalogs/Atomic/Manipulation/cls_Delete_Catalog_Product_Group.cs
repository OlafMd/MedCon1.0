/* 
 * Generated on 12/20/2013 10:54:48 AM
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
using System.Runtime.Serialization;
using CL1_CMN_PRO;

namespace CL5_APOAdmin_Catalogs.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Delete_Catalog_Product_Group.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Delete_Catalog_Product_Group
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5CA_DCPG_1049 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here


            // DELETE CHILDREN

            ORM_CMN_PRO_Catalog_ProductGroup.Query children = new ORM_CMN_PRO_Catalog_ProductGroup.Query();
            children.CatalogProductGroup_Parent_RefID = Parameter.ProductGroupID;

            List<ORM_CMN_PRO_Catalog_ProductGroup> childProductGroups = ORM_CMN_PRO_Catalog_ProductGroup.Query.Search(Connection, Transaction, children);

            foreach (var child in childProductGroups)
            {
                P_L5CA_DCPG_1049 paramForChild = new P_L5CA_DCPG_1049();
                paramForChild.ProductGroupID = child.CMN_PRO_Catalog_ProductGroupID;
                cls_Delete_Catalog_Product_Group.Invoke(Connection, Transaction, paramForChild, securityTicket);
            }

            // DELETE PARENT

            ORM_CMN_PRO_Catalog_ProductGroup group = new ORM_CMN_PRO_Catalog_ProductGroup();
            group.Load(Connection, Transaction, Parameter.ProductGroupID);

            ORM_CMN_PRO_Catalog_Product_2_ProductGroup.Query productsQuery = new ORM_CMN_PRO_Catalog_Product_2_ProductGroup.Query();
            productsQuery.CMN_PRO_Catalog_ProductGroup_RefID = Parameter.ProductGroupID;
            List<ORM_CMN_PRO_Catalog_Product_2_ProductGroup> productGroups = ORM_CMN_PRO_Catalog_Product_2_ProductGroup.Query.Search(Connection, Transaction, productsQuery);
            
            foreach(var product2productGroup in productGroups)
            {
                ORM_CMN_PRO_Catalog_Product product = new ORM_CMN_PRO_Catalog_Product();
                product.Load(Connection, Transaction, product2productGroup.CMN_PRO_Catalog_Product_RefID);
                
                product.IsDeleted = true;
                product.Save(Connection, Transaction);

                product2productGroup.IsDeleted = true;
                product2productGroup.Save(Connection, Transaction);
            }

            group.IsDeleted = true;
            group.Save(Connection, Transaction);

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5CA_DCPG_1049 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5CA_DCPG_1049 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5CA_DCPG_1049 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5CA_DCPG_1049 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Delete_Catalog_Product_Group",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5CA_DCPG_1049 for attribute P_L5CA_DCPG_1049
		[DataContract]
		public class P_L5CA_DCPG_1049 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProductGroupID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Delete_Catalog_Product_Group(,P_L5CA_DCPG_1049 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Delete_Catalog_Product_Group.Invoke(connectionString,P_L5CA_DCPG_1049 Parameter,securityTicket);
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
var parameter = new CL5_APOAdmin_Catalogs.Atomic.Manipulation.P_L5CA_DCPG_1049();
parameter.ProductGroupID = ...;

*/
