/* 
 * Generated on 6/24/2014 6:17:07 PM
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
using CL5_APOProcurement_ProcurementOrder.Atomic.Retrieval;
using CL3_Price.Complex.Retrieval;
using CL3_Articles.Atomic.Retrieval;

namespace CL5_APOProcurement_ProcurementOrder.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Open_ExtraDemandProducts_with_ArticleData.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Open_ExtraDemandProducts_with_ArticleData
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5PO_GOEDPwAD_1719_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5PO_GOEDPwAD_1719_Array();

            List<L5PO_GOEDPwAD_1719> list = new List<L5PO_GOEDPwAD_1719>();

            var extraDemandProducts = cls_Get_Open_ExtraDemandProducts.Invoke(Connection, Transaction, securityTicket).Result;

            L3AR_GAfAL_0942[] articles = new L3AR_GAfAL_0942[0];
            L3PR_GSPfPIL_1645[] prices = new L3PR_GSPfPIL_1645[0];
            if (extraDemandProducts.Count() != 0)
            {
                var articleIds = extraDemandProducts.Select(x => x.Product_RefID).Distinct().ToArray();

                var articleParam = new P_L3AR_GAfAL_0942 { ProductID_List = articleIds };
                articles = CL3_Articles.Atomic.Retrieval.cls_Get_Articles_for_ArticleList.Invoke(Connection, Transaction, articleParam, securityTicket).Result;

                var priceParam = new P_L3PR_GSPfPIL_1645 { ProductIDList = articleIds };
                prices = cls_Get_StandardPrices_for_ProductIDList.Invoke(Connection, Transaction, priceParam, securityTicket).Result;
            }

            L5PO_GOEDPwAD_1719 listItem = null;
            foreach (var item in extraDemandProducts)
            {
                listItem = new L5PO_GOEDPwAD_1719();

                listItem.ExtraDemandProduct = item;
                listItem.Article = articles.Single(x => x.CMN_PRO_ProductID == item.Product_RefID);
                listItem.Price = prices.Single(x => x.ProductID == item.Product_RefID);

                list.Add(listItem);
            }

            returnValue.Result = list.ToArray();

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5PO_GOEDPwAD_1719_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5PO_GOEDPwAD_1719_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5PO_GOEDPwAD_1719_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5PO_GOEDPwAD_1719_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5PO_GOEDPwAD_1719_Array functionReturn = new FR_L5PO_GOEDPwAD_1719_Array();
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

				functionReturn = Execute(Connection, Transaction,securityTicket);

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

				throw new Exception("Exception occured in method cls_Get_Open_ExtraDemandProducts_with_ArticleData",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5PO_GOEDPwAD_1719_Array : FR_Base
	{
		public L5PO_GOEDPwAD_1719[] Result	{ get; set; } 
		public FR_L5PO_GOEDPwAD_1719_Array() : base() {}

		public FR_L5PO_GOEDPwAD_1719_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5PO_GOEDPwAD_1719 for attribute L5PO_GOEDPwAD_1719
		[DataContract]
		public class L5PO_GOEDPwAD_1719 
		{
			//Standard type parameters
			[DataMember]
			public CL5_APOProcurement_ProcurementOrder.Atomic.Retrieval.L5PO_GOEDP_1716 ExtraDemandProduct { get; set; } 
			[DataMember]
			public CL3_Articles.Atomic.Retrieval.L3AR_GAfAL_0942 Article { get; set; } 
			[DataMember]
			public CL3_Price.Complex.Retrieval.L3PR_GSPfPIL_1645 Price { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5PO_GOEDPwAD_1719_Array cls_Get_Open_ExtraDemandProducts_with_ArticleData(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5PO_GOEDPwAD_1719_Array invocationResult = cls_Get_Open_ExtraDemandProducts_with_ArticleData.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

