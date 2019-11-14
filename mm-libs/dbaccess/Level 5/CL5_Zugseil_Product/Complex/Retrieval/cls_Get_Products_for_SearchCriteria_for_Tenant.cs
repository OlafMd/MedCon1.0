/* 
 * Generated on 2/12/2015 11:09:26 AM
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
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Products_for_SearchCriteria_for_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Products_for_SearchCriteria_for_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5PR_GPfSCfT_0938 Execute(DbConnection Connection,DbTransaction Transaction,P_L5PR_GPfSCfT_0938 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_L5PR_GPfSCfT_0938();

            P_L5PR_GNoPfT_1442 numberOfArticelsParameter = new P_L5PR_GNoPfT_1442();
            numberOfArticelsParameter.LanguageID = Parameter.LanguageID;
            numberOfArticelsParameter.SearchCriteria = Parameter.SearchCriteria;

            L5PR_GNoPfT_1442 numberOfProducts = new L5PR_GNoPfT_1442();
            numberOfProducts = cls_Get_Number_of_Products_for_Tenant.Invoke(Connection, Transaction, numberOfArticelsParameter, securityTicket).Result;

            P_L5PR_GPfT_1439 ProductListParameter = new P_L5PR_GPfT_1439();
            ProductListParameter.LanguageID = Parameter.LanguageID;
            ProductListParameter.ActivePage = Parameter.ActivePage;
            ProductListParameter.PageSize = Parameter.PageSize;
            ProductListParameter.SearchCriteria = Parameter.SearchCriteria;
            ProductListParameter.ExcludedProducts = Parameter.ExcludedProducts;
           
            if (Parameter.ActivePage != 0)
            {
                ProductListParameter.ActivePage = Parameter.ActivePage - 1;
            }
            List<L5PR_GPfT_1439> productList = new List<L5PR_GPfT_1439>();

            if ((numberOfProducts.NumberOfProducts - (Parameter.ActivePage + Parameter.PageSize)) > 0 || (numberOfProducts.NumberOfProducts - (Parameter.ActivePage + Parameter.PageSize)) == 0)
            {

                productList = cls_Get_Products_for_Tenant.Invoke(Connection, Transaction, ProductListParameter, securityTicket).Result.ToList();
            }
            else
            {
                int itemsLeft = numberOfProducts.NumberOfProducts - Parameter.ActivePage;
                if (itemsLeft > 0)
                {
                    ProductListParameter.PageSize = itemsLeft;
                    productList = cls_Get_Products_for_Tenant.Invoke(Connection, Transaction, ProductListParameter, securityTicket).Result.ToList();
                }
                else
                {
                    productList = null;
                }
            }

            L5PR_GPfSCfT_0938 result = new L5PR_GPfSCfT_0938();
            result.ProductList = productList != null ? productList.ToArray() : new List<L5PR_GPfT_1439>().ToArray();
            result.NumberOfProducts = numberOfProducts;
            returnValue.Result = result;

            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5PR_GPfSCfT_0938 Invoke(string ConnectionString,P_L5PR_GPfSCfT_0938 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5PR_GPfSCfT_0938 Invoke(DbConnection Connection,P_L5PR_GPfSCfT_0938 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5PR_GPfSCfT_0938 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5PR_GPfSCfT_0938 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5PR_GPfSCfT_0938 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5PR_GPfSCfT_0938 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5PR_GPfSCfT_0938 functionReturn = new FR_L5PR_GPfSCfT_0938();
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

				throw new Exception("Exception occured in method cls_Get_Products_for_SearchCriteria_for_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5PR_GPfSCfT_0938 : FR_Base
	{
		public L5PR_GPfSCfT_0938 Result	{ get; set; }

		public FR_L5PR_GPfSCfT_0938() : base() {}

		public FR_L5PR_GPfSCfT_0938(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5PR_GPfSCfT_0938 for attribute P_L5PR_GPfSCfT_0938
		[DataContract]
		public class P_L5PR_GPfSCfT_0938 
		{
			//Standard type parameters
			[DataMember]
			public Guid LanguageID { get; set; } 
			[DataMember]
			public int PageSize { get; set; } 
			[DataMember]
			public int ActivePage { get; set; } 
			[DataMember]
			public String SearchCriteria { get; set; } 
			[DataMember]
			public String OrderByCriteria { get; set; } 
			[DataMember]
			public Guid[] ExcludedProducts { get; set; } 

		}
		#endregion
		#region SClass L5PR_GPfSCfT_0938 for attribute L5PR_GPfSCfT_0938
		[DataContract]
		public class L5PR_GPfSCfT_0938 
		{
			//Standard type parameters
			[DataMember]
			public L5PR_GNoPfT_1442 NumberOfProducts { get; set; } 
			[DataMember]
			public L5PR_GPfT_1439[] ProductList { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5PR_GPfSCfT_0938 cls_Get_Products_for_SearchCriteria_for_Tenant(,P_L5PR_GPfSCfT_0938 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5PR_GPfSCfT_0938 invocationResult = cls_Get_Products_for_SearchCriteria_for_Tenant.Invoke(connectionString,P_L5PR_GPfSCfT_0938 Parameter,securityTicket);
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
var parameter = new CL5_Zugseil_Product.Complex.Retrieval.P_L5PR_GPfSCfT_0938();
parameter.LanguageID = ...;
parameter.PageSize = ...;
parameter.ActivePage = ...;
parameter.SearchCriteria = ...;
parameter.OrderByCriteria = ...;
parameter.ExcludedProducts = ...;

*/
