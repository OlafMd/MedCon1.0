/* 
 * Generated on 8/7/2014 9:11:07 AM
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
using System.Runtime.Serialization;
using CL3_Articles.Atomic.Retrieval;

namespace CL3_Articles.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Articles_with_StandardPrices_for_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Articles_with_StandardPrices_for_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3PR_GAwSPfT_1535_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3PR_GAwSPfT_1535 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L3PR_GAwSPfT_1535_Array();
			//Put your code here

            List<Guid> productList = new List<Guid>();
            var paramArticles = new CL3_Articles.Atomic.Retrieval.P_L3AR_GAfT_0942
            {
                ActiveComponent = Parameter.ActiveComponent,
                ActiveComponentStartWith = Parameter.ActiveComponentStartWith,
                CustomArticlesGroupGlobalPropertyID = Parameter.CustomArticlesGroupGlobalPropertyID,
                DosageFormQuery = Parameter.DosageFormQuery,
                GeneralQuery = Parameter.GeneralQuery,
                IsAvailableForOrdering = Parameter.IsAvailableForOrdering,
                LanguageID = Parameter.LanguageID,
                ProducerName = Parameter.ProducerName,
                ProductID = Parameter.ProductID,
                ProductNameStartWith = Parameter.ProductNameStartWith,
                PZNQuery = Parameter.PZNQuery,
                UnitQuery = Parameter.UnitQuery,
                IsDefaultStock = Parameter.IsPartOfDefaultStock
            };

            List<L3AR_GAfT_0942> articles = cls_Get_Articles_for_Tenant.Invoke(Connection, Transaction, paramArticles, securityTicket).Result.ToList();

            foreach (var item in articles)
	        {
                
                productList.Add(item.CMN_PRO_ProductID);
	        }

            List<L3PR_GAwSPfT_1535> results = new List<L3PR_GAwSPfT_1535>();

            if (productList.Count > 0)
            {
                var paramPrices = new CL3_Price.Complex.Retrieval.P_L3PR_GSPfPIL_1645
                {
                    ProductIDList = productList.ToArray()
                };

                var prices = CL3_Price.Complex.Retrieval.cls_Get_StandardPrices_for_ProductIDList.Invoke(Connection, Transaction, paramPrices, securityTicket).Result.ToList();
                               
                foreach (var articl in articles)
                {
                    var articlesWithPrices = new L3PR_GAwSPfT_1535();

                    articlesWithPrices.Article = articl;
                    articlesWithPrices.Prices = prices.Where(x => x.ProductID == articl.CMN_PRO_ProductID).Single();
                    results.Add(articlesWithPrices);

                }
            }
            
			returnValue.Result = results.ToArray();
            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3PR_GAwSPfT_1535_Array Invoke(string ConnectionString,P_L3PR_GAwSPfT_1535 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3PR_GAwSPfT_1535_Array Invoke(DbConnection Connection,P_L3PR_GAwSPfT_1535 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3PR_GAwSPfT_1535_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3PR_GAwSPfT_1535 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3PR_GAwSPfT_1535_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3PR_GAwSPfT_1535 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3PR_GAwSPfT_1535_Array functionReturn = new FR_L3PR_GAwSPfT_1535_Array();
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

				throw new Exception("Exception occured in method cls_Get_Articles_with_StandardPrices_for_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3PR_GAwSPfT_1535_Array : FR_Base
	{
		public L3PR_GAwSPfT_1535[] Result	{ get; set; } 
		public FR_L3PR_GAwSPfT_1535_Array() : base() {}

		public FR_L3PR_GAwSPfT_1535_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3PR_GAwSPfT_1535 for attribute P_L3PR_GAwSPfT_1535
		[DataContract]
		public class P_L3PR_GAwSPfT_1535 
		{
			//Standard type parameters
			[DataMember]
			public Guid LanguageID { get; set; } 
			[DataMember]
			public string ProductNameStartWith { get; set; } 
			[DataMember]
			public string ProducerName { get; set; } 
			[DataMember]
			public string GeneralQuery { get; set; } 
			[DataMember]
			public string DosageFormQuery { get; set; } 
			[DataMember]
			public string UnitQuery { get; set; } 
			[DataMember]
			public string PZNQuery { get; set; } 
			[DataMember]
			public string CustomArticlesGroupGlobalPropertyID { get; set; } 
			[DataMember]
			public string ActiveComponent { get; set; } 
			[DataMember]
			public string ActiveComponentStartWith { get; set; } 
			[DataMember]
			public bool? IsAvailableForOrdering { get; set; } 
			[DataMember]
			public Guid? ProductID { get; set; } 
			[DataMember]
			public bool? IsPartOfDefaultStock { get; set; } 

		}
		#endregion
		#region SClass L3PR_GAwSPfT_1535 for attribute L3PR_GAwSPfT_1535
		[DataContract]
		public class L3PR_GAwSPfT_1535 
		{
			//Standard type parameters
			[DataMember]
			public CL3_Articles.Atomic.Retrieval.L3AR_GAfT_0942 Article { get; set; } 
			[DataMember]
			public CL3_Price.Complex.Retrieval.L3PR_GSPfPIL_1645 Prices { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3PR_GAwSPfT_1535_Array cls_Get_Articles_with_StandardPrices_for_Tenant(,P_L3PR_GAwSPfT_1535 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3PR_GAwSPfT_1535_Array invocationResult = cls_Get_Articles_with_StandardPrices_for_Tenant.Invoke(connectionString,P_L3PR_GAwSPfT_1535 Parameter,securityTicket);
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
var parameter = new CL3_Articles.Complex.Retrieval.P_L3PR_GAwSPfT_1535();
parameter.LanguageID = ...;
parameter.ProductNameStartWith = ...;
parameter.ProducerName = ...;
parameter.GeneralQuery = ...;
parameter.DosageFormQuery = ...;
parameter.UnitQuery = ...;
parameter.PZNQuery = ...;
parameter.CustomArticlesGroupGlobalPropertyID = ...;
parameter.ActiveComponent = ...;
parameter.ActiveComponentStartWith = ...;
parameter.IsAvailableForOrdering = ...;
parameter.ProductID = ...;
parameter.IsPartOfDefaultStock = ...;

*/
