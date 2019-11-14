/* 
 * Generated on 12/5/2014 12:21:50 PM
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
using CL5_Zugseil_Product.Atomic.Retrieval;

namespace CL5_Zugseil_Product.Complex.Retrieval
{
	/// <summary>
    /// Get_Products_with_CatalogsProducts_by_SearchCriteria_for_Tenant
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Products_with_CatalogsProducts_by_SearchCriteria_for_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Products_with_CatalogsProducts_by_SearchCriteria_for_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5PR_GPwCPbSCfT_1237_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5PR_GPwCPbSCfT_1237 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5PR_GPwCPbSCfT_1237_Array();
			//Put your code here

            var returnedProductsList = new List<L5PR_GPwCPbSCfT_1237>();

            if ((!Parameter.LoadInternalProducts && Parameter.LastIncludedCatalog != null && !String.IsNullOrEmpty(Parameter.LastIncludedCatalog.CatalogITL)) && String.IsNullOrEmpty(Parameter.SearchCriteria))
            {
                // load only catalogs if defined last included catalog and you don't need own products
                P_L5PR_GCPfCAfT_1705 parameter = new P_L5PR_GCPfCAfT_1705();
                parameter.From = Parameter.IncludedProductsCountFromLastCatalog;
                parameter.Size = Parameter.Size - Parameter.IncludedProductsCountFromLastCatalog;
                parameter.LastIncludedCatalog = Parameter.LastIncludedCatalog;
                parameter.CatalogsToInclude = Parameter.CatalogsToInclude;
                parameter.SearchCriteria = Parameter.SearchCriteria;
                parameter.IncludedProductsCountFromLastCatalog = Parameter.IncludedProductsCountFromLastCatalog;

                returnedProductsList.AddRange(cls_Get_Catalogs_Products_from_CatalogAPI_for_Tenant.Invoke(Connection, Transaction, parameter, securityTicket).Result.Products.ToList());

                returnValue.Result = returnedProductsList.ToArray();
                return returnValue;
            }

            ///////////// GET PRODUCTS WITHOUT ITL //////////////
            if (Parameter.LastIncludedCatalog == null || String.IsNullOrEmpty(Parameter.LastIncludedCatalog.CatalogITL))
            {
                List<L5PR_GPwITL_1100> productsWithoutITL = new List<L5PR_GPwITL_1100>();
                if (Parameter.LoadInternalProducts)
                {
                    // load own products first if LastIncludedCatalog not defined
                    var parameterProductsNoITL = new P_L5PR_GPwITL_1100();
                    parameterProductsNoITL.LanguageID = Parameter.LanguageID;
                    parameterProductsNoITL.SearchCriteria = Parameter.SearchCriteria;
                    parameterProductsNoITL.Size = Parameter.Size;
                    parameterProductsNoITL.From = Parameter.From;

                    productsWithoutITL = cls_Get_Products_without_ITL_for_Tenant.Invoke(Connection, Transaction, parameterProductsNoITL, securityTicket).Result.ToList();

                    if (productsWithoutITL != null && productsWithoutITL.Count() > 0) // if it returns some number of products
                    {
                        // return all internal products
                        returnedProductsList = productsWithoutITL.Select(item => new L5PR_GPwCPbSCfT_1237()
                        {
                            CMN_PRO_ProductID = item.CMN_PRO_ProductID,
                            ProductITL = string.Empty,
                            Product_Number = item.Product_Number,
                            Product_Name = item.Product_Name,
                            Product_Description = item.Product_Description,
                            CatalogITL = string.Empty,
                            CatalogName = string.Empty

                        }).ToList();
                    }
                }

                if (Parameter.CatalogsToInclude != null && Parameter.CatalogsToInclude.Count() > 0)
                {
                    // return catalog products to populate return value list
                    P_L5PR_GCPfCAfT_1705 parameter = new P_L5PR_GCPfCAfT_1705();
                    parameter.From = 0;
                    parameter.Size = Parameter.Size - productsWithoutITL.Count();
                    parameter.IncludedProductsCountFromLastCatalog = 0;
                    parameter.LastIncludedCatalog = Parameter.CatalogsToInclude.FirstOrDefault();
                    parameter.CatalogsToInclude = Parameter.CatalogsToInclude;
                    parameter.SearchCriteria = Parameter.SearchCriteria;
                    parameter.LanguageID = Parameter.LanguageID;

                    returnedProductsList.AddRange(cls_Get_Catalogs_Products_from_CatalogAPI_for_Tenant.Invoke(Connection, Transaction, parameter, securityTicket).Result.Products.ToList());
                }
            }
            else
            {
                // LastIncludedCatalog is defined, continue loading products from them
                if (Parameter.CatalogsToInclude != null && Parameter.CatalogsToInclude.Count() > 0)
                {
                    P_L5PR_GCPfCAfT_1705 parameter = new P_L5PR_GCPfCAfT_1705();
                    parameter.From = Parameter.IncludedProductsCountFromLastCatalog;
                    parameter.Size = Parameter.Size;
                    parameter.IncludedProductsCountFromLastCatalog = Parameter.IncludedProductsCountFromLastCatalog;
                    parameter.LastIncludedCatalog = Parameter.LastIncludedCatalog;
                    parameter.CatalogsToInclude = Parameter.CatalogsToInclude;
                    parameter.SearchCriteria = Parameter.SearchCriteria;
                    parameter.LanguageID = Parameter.LanguageID;

                    returnedProductsList.AddRange(cls_Get_Catalogs_Products_from_CatalogAPI_for_Tenant.Invoke(Connection, Transaction, parameter, securityTicket).Result.Products.ToList());
                }
            }


            returnValue.Result = returnedProductsList.ToArray();

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5PR_GPwCPbSCfT_1237_Array Invoke(string ConnectionString,P_L5PR_GPwCPbSCfT_1237 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5PR_GPwCPbSCfT_1237_Array Invoke(DbConnection Connection,P_L5PR_GPwCPbSCfT_1237 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5PR_GPwCPbSCfT_1237_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5PR_GPwCPbSCfT_1237 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5PR_GPwCPbSCfT_1237_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5PR_GPwCPbSCfT_1237 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5PR_GPwCPbSCfT_1237_Array functionReturn = new FR_L5PR_GPwCPbSCfT_1237_Array();
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

				throw new Exception("Exception occured in method cls_Get_Products_with_CatalogsProducts_by_SearchCriteria_for_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5PR_GPwCPbSCfT_1237_Array : FR_Base
	{
		public L5PR_GPwCPbSCfT_1237[] Result	{ get; set; } 
		public FR_L5PR_GPwCPbSCfT_1237_Array() : base() {}

		public FR_L5PR_GPwCPbSCfT_1237_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5PR_GPwCPbSCfT_1237 for attribute P_L5PR_GPwCPbSCfT_1237
		[DataContract]
		public class P_L5PR_GPwCPbSCfT_1237 
		{
			//Standard type parameters
			[DataMember]
			public Guid LanguageID { get; set; } 
			[DataMember]
			public int Size { get; set; } 
			[DataMember]
			public int From { get; set; } 
			[DataMember]
			public String SearchCriteria { get; set; } 
			[DataMember]
			public P_L5PR_GPwCPbSCfT_1237_CatalogsToInclude[] CatalogsToInclude { get; set; } 
			[DataMember]
			public bool LoadInternalProducts { get; set; } 
			[DataMember]
			public P_L5PR_GPwCPbSCfT_1237_CatalogsToInclude LastIncludedCatalog { get; set; } 
			[DataMember]
			public int IncludedProductsCountFromLastCatalog { get; set; } 

		}
        [DataContract]
        public class P_L5PR_GPwCPbSCfT_1237_CatalogsToInclude
        {
            //Standard type parameters
            [DataMember]
            public String CatalogITL { get; set; }
            [DataMember]
            public String CatalogName { get; set; }
        }
		#endregion
		#region SClass L5PR_GPwCPbSCfT_1237 for attribute L5PR_GPwCPbSCfT_1237
		[DataContract]
		public class L5PR_GPwCPbSCfT_1237 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_ProductID { get; set; } 
			[DataMember]
			public String ProductITL { get; set; } 
			[DataMember]
			public String Product_Number { get; set; } 
			[DataMember]
			public Dict Product_Name { get; set; } 
			[DataMember]
			public Dict Product_Description { get; set; } 
			[DataMember]
			public String CatalogITL { get; set; } 
			[DataMember]
			public String CatalogName { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5PR_GPwCPbSCfT_1237_Array cls_Get_Products_with_CatalogsProducts_by_SearchCriteria_for_Tenant(,P_L5PR_GPwCPbSCfT_1237 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5PR_GPwCPbSCfT_1237_Array invocationResult = cls_Get_Products_with_CatalogsProducts_by_SearchCriteria_for_Tenant.Invoke(connectionString,P_L5PR_GPwCPbSCfT_1237 Parameter,securityTicket);
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
var parameter = new CL5_Zugseil_Product.Complex.Retrieval.P_L5PR_GPwCPbSCfT_1237();
parameter.LanguageID = ...;
parameter.Size = ...;
parameter.From = ...;
parameter.SearchCriteria = ...;
parameter.CatalogsToInclude = ...;
parameter.LoadInternalProducts = ...;
parameter.LastIncludedCatalog = ...;
parameter.IncludedProductsCountFromLastCatalog = ...;

*/
