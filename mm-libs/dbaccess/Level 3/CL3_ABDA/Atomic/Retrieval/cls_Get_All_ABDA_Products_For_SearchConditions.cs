/* 
 * Generated on 9/22/2014 2:41:07 PM
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
using DLCore_DBCommons.Utils;
using DLCore_DBCommons.APODemand;
using CL1_CMN_PRO;
using CL3_ABDA.Utils;
using BOp.CatalogAPI.data;
using BOp.CatalogAPI;

namespace CL3_ABDA.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_All_ABDA_Products_For_SearchConditions.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_All_ABDA_Products_For_SearchConditions
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3ABDA_GAAPfSC_1547 Execute(DbConnection Connection,DbTransaction Transaction,P_L3ABDA_GAAPfSC_1547 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_L3ABDA_GAAPfSC_1547();

            returnValue.Result = new L3ABDA_GAAPfSC_1547();

            string catalogITL = EnumUtils.GetEnumDescription(EPublicCatalogs.ABDA);

            var sbsCatalog = ORM_CMN_PRO_SubscribedCatalog.Query.Search(Connection, Transaction, new ORM_CMN_PRO_SubscribedCatalog.Query()
            {
                CatalogCodeITL = catalogITL,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).FirstOrDefault();

            if (sbsCatalog == null)
                return returnValue;

            string query = "";
            bool isSecondQueryNeeded = false;

            if (Parameter.IsPrefixSearch)
            {
                QueryBuilderPrefixSearch prefixSearch = new QueryBuilderPrefixSearch(Parameter);
                query = prefixSearch.GetQuery();
            }
            else
            {
                QueryBuilderImpressiveSearch impressiveSearch = new QueryBuilderImpressiveSearch(Parameter.PZN, Parameter.SearchQuery);
                query = impressiveSearch.GetQuery();
                isSecondQueryNeeded = impressiveSearch.IsSecondQueryNeeded();
            }

            var ProductService = CatalogServiceFactory.GetProductService();
            ProductQueryRequest request = new ProductQueryRequest() { CatalogCode = catalogITL };
            var res = ProductService.QueryProducts(request, query);
            var retrievedProducts = res.Documents.ToList();

            returnValue.Result.Products = retrievedProducts.ToArray();
            returnValue.Result.Query = query;
            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3ABDA_GAAPfSC_1547 Invoke(string ConnectionString,P_L3ABDA_GAAPfSC_1547 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3ABDA_GAAPfSC_1547 Invoke(DbConnection Connection,P_L3ABDA_GAAPfSC_1547 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3ABDA_GAAPfSC_1547 Invoke(DbConnection Connection, DbTransaction Transaction,P_L3ABDA_GAAPfSC_1547 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3ABDA_GAAPfSC_1547 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3ABDA_GAAPfSC_1547 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3ABDA_GAAPfSC_1547 functionReturn = new FR_L3ABDA_GAAPfSC_1547();
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

				throw new Exception("Exception occured in method cls_Get_All_ABDA_Products_For_SearchConditions",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3ABDA_GAAPfSC_1547 : FR_Base
	{
		public L3ABDA_GAAPfSC_1547 Result	{ get; set; }

		public FR_L3ABDA_GAAPfSC_1547() : base() {}

		public FR_L3ABDA_GAAPfSC_1547(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3ABDA_GAAPfSC_1547 for attribute P_L3ABDA_GAAPfSC_1547
		[DataContract]
		public class P_L3ABDA_GAAPfSC_1547 
		{
			//Standard type parameters
			[DataMember]
			public string PZN { get; set; } 
			[DataMember]
			public string SearchQuery { get; set; } 
			[DataMember]
			public string ProductName { get; set; } 
			[DataMember]
			public string ActiveSubstance { get; set; } 
			[DataMember]
			public string Producer { get; set; } 
			[DataMember]
			public bool IsPrefixSearch { get; set; } 

		}
		#endregion
		#region SClass L3ABDA_GAAPfSC_1547 for attribute L3ABDA_GAAPfSC_1547
		[DataContract]
		public class L3ABDA_GAAPfSC_1547 
		{
			//Standard type parameters
			[DataMember]
			public Product[] Products { get; set; } 
			[DataMember]
			public string Query { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3ABDA_GAAPfSC_1547 cls_Get_All_ABDA_Products_For_SearchConditions(,P_L3ABDA_GAAPfSC_1547 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3ABDA_GAAPfSC_1547 invocationResult = cls_Get_All_ABDA_Products_For_SearchConditions.Invoke(connectionString,P_L3ABDA_GAAPfSC_1547 Parameter,securityTicket);
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
var parameter = new CL3_ABDA.Atomic.Retrieval.P_L3ABDA_GAAPfSC_1547();
parameter.PZN = ...;
parameter.SearchQuery = ...;
parameter.ProductName = ...;
parameter.ActiveSubstance = ...;
parameter.Producer = ...;
parameter.IsPrefixSearch = ...;

*/
