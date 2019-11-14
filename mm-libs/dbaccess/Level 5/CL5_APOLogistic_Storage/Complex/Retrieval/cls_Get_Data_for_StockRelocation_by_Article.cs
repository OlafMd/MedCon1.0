/* 
 * Generated on 5/14/2014 11:24:42 AM
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
using CL3_Articles.Atomic.Retrieval;
using CL5_APOLogistic_Storage.Atomic.Retrieval;

namespace CL5_APOLogistic_Storage.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Data_for_StockRelocation_by_Article.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Data_for_StockRelocation_by_Article
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5SG_GDfSR_1618 Execute(DbConnection Connection,DbTransaction Transaction,P_L5SG_GDfSR_1618 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_L5SG_GDfSR_1618();

            var getArticleParameter = new P_L3AR_GAfAL_0942();
            getArticleParameter.ProductID_List = new Guid[1];
            getArticleParameter.ProductID_List[0] = Parameter.ProductID;
            var article = cls_Get_Articles_for_ArticleList.Invoke(Connection, Transaction, getArticleParameter, securityTicket).Result.First();

            var getStorageDetailsParameter = new P_L5SG_GSDfPIDoSID_1612();
            getStorageDetailsParameter.ProductID = Parameter.ProductID;
            var storageDetails = cls_Get_StorageDetails_for_ProductIDorShelfID.Invoke(Connection, Transaction, getStorageDetailsParameter, securityTicket).Result.ToList();

            List<L5SG_GDfSR_1618a> articleStorageDetails = new List<L5SG_GDfSR_1618a>();

            foreach (var storageDetail in storageDetails)
            {
                L5SG_GDfSR_1618a temporaryDetail = new L5SG_GDfSR_1618a();
                temporaryDetail.Article = article;
                temporaryDetail.StorageDetails = storageDetail;

                articleStorageDetails.Add(temporaryDetail);
            }

            returnValue.Result = new L5SG_GDfSR_1618();
            returnValue.Result.ArticleStorageDetails = articleStorageDetails.ToArray();

			//Put your code here
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5SG_GDfSR_1618 Invoke(string ConnectionString,P_L5SG_GDfSR_1618 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5SG_GDfSR_1618 Invoke(DbConnection Connection,P_L5SG_GDfSR_1618 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5SG_GDfSR_1618 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5SG_GDfSR_1618 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5SG_GDfSR_1618 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5SG_GDfSR_1618 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5SG_GDfSR_1618 functionReturn = new FR_L5SG_GDfSR_1618();
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

				throw new Exception("Exception occured in method cls_Get_Data_for_StockRelocation_by_Article",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5SG_GDfSR_1618 : FR_Base
	{
		public L5SG_GDfSR_1618 Result	{ get; set; }

		public FR_L5SG_GDfSR_1618() : base() {}

		public FR_L5SG_GDfSR_1618(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5SG_GDfSR_1618 for attribute P_L5SG_GDfSR_1618
		[DataContract]
		public class P_L5SG_GDfSR_1618 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProductID { get; set; } 

		}
		#endregion
		#region SClass L5SG_GDfSR_1618 for attribute L5SG_GDfSR_1618
		[DataContract]
		public class L5SG_GDfSR_1618 
		{
			[DataMember]
			public L5SG_GDfSR_1618a[] ArticleStorageDetails { get; set; }

			//Standard type parameters
		}
		#endregion
		#region SClass L5SG_GDfSR_1618a for attribute ArticleStorageDetails
		[DataContract]
		public class L5SG_GDfSR_1618a 
		{
			//Standard type parameters
			[DataMember]
			public L3AR_GAfAL_0942 Article { get; set; } 
			[DataMember]
			public L5SG_GSDfPIDoSID_1612 StorageDetails { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5SG_GDfSR_1618 cls_Get_Data_for_StockRelocation_by_Article(,P_L5SG_GDfSR_1618 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5SG_GDfSR_1618 invocationResult = cls_Get_Data_for_StockRelocation_by_Article.Invoke(connectionString,P_L5SG_GDfSR_1618 Parameter,securityTicket);
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
var parameter = new CL5_APOLogistic_Storage.Complex.Retrieval.P_L5SG_GDfSR_1618();
parameter.ProductID = ...;

*/
