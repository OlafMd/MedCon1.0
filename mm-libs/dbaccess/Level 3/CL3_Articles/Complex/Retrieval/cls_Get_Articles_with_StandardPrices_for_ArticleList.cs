/* 
 * Generated on 9/9/2014 10:38:50 AM
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
    /// var result = cls_Get_Articles_with_StandardPrices_for_ArticleList.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Articles_with_StandardPrices_for_ArticleList
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3PR_GAwSPfAL_1021_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3PR_GAwSPfAL_1021 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L3PR_GAwSPfAL_1021_Array();
			//Put your code here

            List<Guid> productList = new List<Guid>();
            var paramArticles = new CL3_Articles.Atomic.Retrieval.P_L3AR_GAfAL_0942
            {
               ProductID_List = Parameter.ProductListParameter.ProductID_List
            };

            List<L3AR_GAfAL_0942> articles = cls_Get_Articles_for_ArticleList.Invoke(Connection, Transaction, paramArticles, securityTicket).Result.ToList();

            foreach (var item in articles)
            {

                productList.Add(item.CMN_PRO_ProductID);
            }

            List<L3PR_GAwSPfAL_1021> results = new List<L3PR_GAwSPfAL_1021>();

            if (productList.Count > 0)
            {
                var paramPrices = new CL3_Price.Complex.Retrieval.P_L3PR_GSPfPIL_1645
                {
                    ProductIDList = productList.ToArray()
                };

                var prices = CL3_Price.Complex.Retrieval.cls_Get_StandardPrices_for_ProductIDList.Invoke(Connection, Transaction, paramPrices, securityTicket).Result.ToList();
                               
                foreach (var articl in articles)
                {
                    var articlesWithPrices = new L3PR_GAwSPfAL_1021();

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
		public static FR_L3PR_GAwSPfAL_1021_Array Invoke(string ConnectionString,P_L3PR_GAwSPfAL_1021 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3PR_GAwSPfAL_1021_Array Invoke(DbConnection Connection,P_L3PR_GAwSPfAL_1021 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3PR_GAwSPfAL_1021_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3PR_GAwSPfAL_1021 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3PR_GAwSPfAL_1021_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3PR_GAwSPfAL_1021 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3PR_GAwSPfAL_1021_Array functionReturn = new FR_L3PR_GAwSPfAL_1021_Array();
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

				throw new Exception("Exception occured in method cls_Get_Articles_with_StandardPrices_for_ArticleList",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3PR_GAwSPfAL_1021_Array : FR_Base
	{
		public L3PR_GAwSPfAL_1021[] Result	{ get; set; } 
		public FR_L3PR_GAwSPfAL_1021_Array() : base() {}

		public FR_L3PR_GAwSPfAL_1021_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3PR_GAwSPfAL_1021 for attribute P_L3PR_GAwSPfAL_1021
		[DataContract]
		public class P_L3PR_GAwSPfAL_1021 
		{
			//Standard type parameters
			[DataMember]
			public P_L3AR_GAfAL_0942 ProductListParameter { get; set; } 

		}
		#endregion
		#region SClass L3PR_GAwSPfAL_1021 for attribute L3PR_GAwSPfAL_1021
		[DataContract]
		public class L3PR_GAwSPfAL_1021 
		{
			//Standard type parameters
			[DataMember]
			public CL3_Articles.Atomic.Retrieval.L3AR_GAfAL_0942 Article { get; set; } 
			[DataMember]
			public CL3_Price.Complex.Retrieval.L3PR_GSPfPIL_1645 Prices { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3PR_GAwSPfAL_1021_Array cls_Get_Articles_with_StandardPrices_for_ArticleList(,P_L3PR_GAwSPfAL_1021 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3PR_GAwSPfAL_1021_Array invocationResult = cls_Get_Articles_with_StandardPrices_for_ArticleList.Invoke(connectionString,P_L3PR_GAwSPfAL_1021 Parameter,securityTicket);
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
var parameter = new CL3_Articles.Complex.Retrieval.P_L3PR_GAwSPfAL_1021();
parameter.ProductListParameter = ...;

*/