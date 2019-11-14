/* 
 * Generated on 8/1/2014 3:33:10 PM
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
using CL1_CMN_PRO;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;
using System.Runtime.Serialization;

namespace CL5_APOAdmin_Catalogs.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Add_Product_to_ProductGroup.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Add_Product_to_ProductGroup
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5CA_APtPG_1137_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5CA_APtPG_1137 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_L5CA_APtPG_1137_Array();
			//Put your code here
            List<L5CA_APtPG_1137> returnList = new List<L5CA_APtPG_1137>();

            foreach(var ProductITL in Parameter.Products) {

                ORM_CMN_PRO_Product.Query prodQuery = new ORM_CMN_PRO_Product.Query() { 
                    ProductITL = ProductITL, 
                    IsDeleted = false, 
                    Tenant_RefID = securityTicket.TenantID,
                    IsProductAvailableForOrdering = true
                };
                var prod = ORM_CMN_PRO_Product.Query.Search(Connection, Transaction, prodQuery).Single();

                

                ORM_CMN_PRO_Catalog_Product.Query catalogProductQuery = new ORM_CMN_PRO_Catalog_Product.Query()
                {
                    CMN_PRO_Product_RefID = prod.CMN_PRO_ProductID,
                    CMN_PRO_Catalog_Revision_RefID = Parameter.CatalogRevision_ID,
                    IsDeleted = false
                };

                if (ORM_CMN_PRO_Catalog_Product.Query.Exists(Connection, Transaction, catalogProductQuery)) {

                    String GroupName = "Catalogue root";
                    
                    ORM_CMN_PRO_Catalog_ProductGroup catGroup = new ORM_CMN_PRO_Catalog_ProductGroup();
                    if (Parameter.Product_Group_ID != Guid.Empty) { 
                        catGroup.Load(Connection, Transaction, Parameter.Product_Group_ID);
                        GroupName = catGroup.CatalogProductGroup_Name;
                    }

                    L5CA_APtPG_1137 item = new L5CA_APtPG_1137()
                    {
                        CatalgueProductGroup = GroupName,
                        Product_Name = prod.Product_Name
                    };
                    returnList.Add(item);
                    continue;   // catalog group for the product already exists in catalog revision
                }

                //  Create catalog product

                ORM_CMN_PRO_Catalog_Product newCp = new ORM_CMN_PRO_Catalog_Product();
                newCp.CMN_PRO_Product_RefID = prod.CMN_PRO_ProductID;
                newCp.CMN_PRO_Catalog_ProductID = Guid.NewGuid();
                newCp.Tenant_RefID = securityTicket.TenantID;
                newCp.CMN_PRO_Catalog_Revision_RefID = Parameter.CatalogRevision_ID;

                //  Create catalog product 2 product group (Product group already exists) if there is group id in Parameter else only add to catalog 
                if (Parameter.Product_Group_ID != Guid.Empty)
                {
                    ORM_CMN_PRO_Catalog_Product_2_ProductGroup prodToGroup = new ORM_CMN_PRO_Catalog_Product_2_ProductGroup();
                    prodToGroup.CMN_PRO_Catalog_Product_RefID = newCp.CMN_PRO_Catalog_ProductID;
                    prodToGroup.CMN_PRO_Catalog_ProductGroup_RefID = Parameter.Product_Group_ID;
                    prodToGroup.Tenant_RefID = securityTicket.TenantID;

                    prodToGroup.Save(Connection, Transaction);
                }
                newCp.Save(Connection, Transaction);
            }

            returnValue.Result = returnList.ToArray();

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5CA_APtPG_1137_Array Invoke(string ConnectionString,P_L5CA_APtPG_1137 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5CA_APtPG_1137_Array Invoke(DbConnection Connection,P_L5CA_APtPG_1137 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5CA_APtPG_1137_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5CA_APtPG_1137 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5CA_APtPG_1137_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5CA_APtPG_1137 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5CA_APtPG_1137_Array functionReturn = new FR_L5CA_APtPG_1137_Array();
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

				throw new Exception("Exception occured in method cls_Add_Product_to_ProductGroup",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5CA_APtPG_1137_Array : FR_Base
	{
		public L5CA_APtPG_1137[] Result	{ get; set; } 
		public FR_L5CA_APtPG_1137_Array() : base() {}

		public FR_L5CA_APtPG_1137_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5CA_APtPG_1137 for attribute P_L5CA_APtPG_1137
		[DataContract]
		public class P_L5CA_APtPG_1137 
		{
			//Standard type parameters
			[DataMember]
			public Guid Product_Group_ID { get; set; } 
			[DataMember]
			public String[] Products { get; set; } 
			[DataMember]
			public Guid CatalogRevision_ID { get; set; } 

		}
		#endregion
		#region SClass L5CA_APtPG_1137 for attribute L5CA_APtPG_1137
		[DataContract]
		public class L5CA_APtPG_1137 
		{
			//Standard type parameters
			[DataMember]
			public String CatalgueProductGroup { get; set; } 
			[DataMember]
			public Dict Product_Name { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5CA_APtPG_1137_Array cls_Add_Product_to_ProductGroup(,P_L5CA_APtPG_1137 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5CA_APtPG_1137_Array invocationResult = cls_Add_Product_to_ProductGroup.Invoke(connectionString,P_L5CA_APtPG_1137 Parameter,securityTicket);
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
var parameter = new CL5_APOAdmin_Catalogs.Atomic.Manipulation.P_L5CA_APtPG_1137();
parameter.Product_Group_ID = ...;
parameter.Products = ...;
parameter.CatalogRevision_ID = ...;

*/
