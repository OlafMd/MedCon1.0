/* 
 * Generated on 10/10/2014 1:19:48 PM
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
using CL3_Warehouse.Atomic.Retrieval;
using CL3_Supplier.Complex.Retrieval;
using CL3_Price.Complex.Retrieval;
using CL3_APOStatistic.Atomic.Retrieval;
using CL3_APOStatistic.Complex.Retrieval;

namespace CL5_APOAdmin_Articles.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Additional_ArticleData_for_ArticleList.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Additional_ArticleData_for_ArticleList
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5AR_GAADfAL_1426_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5AR_GAADfAL_1426 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5AR_GAADfAL_1426_Array();

            if (Parameter.ProductITLList != null && Parameter.ProductITLList.Length > 0)
            {
                P_L3AR_GAIDfAITLs_1641 articleParam = new P_L3AR_GAIDfAITLs_1641();
                articleParam.ProductITLList = Parameter.ProductITLList;
                var articles = cls_Get_ArticleID_for_ArticleITLs.Invoke(Connection, Transaction, articleParam, securityTicket).Result;

                Guid[] productIDList = articles.Select(x => x.CMN_PRO_ProductID).ToArray();

                #region Get Msr

                var msrForProducts = cls_Get_MSR_for_ProductIDList.Invoke(Connection, Transaction, new P_L3AS_GSMRfPL_1508 { ProductIDList = productIDList }, securityTicket).Result;

                #endregion

                #region Get storage data for ariticle list

                List<L5AR_GAADfAL_1426> returnValuesList = new List<L5AR_GAADfAL_1426>();

                L3WH_GASfA_1924[] storages = new L3WH_GASfA_1924[] { };
                Guid[] articlesWithExpectedDelivery = new Guid[] { };
                if (productIDList != null && productIDList.Count() > 0)
                {
                    var storageParam = new P_L3WH_GASfA_1924();
                    storageParam.ArticleID_List = productIDList;
                    storages = cls_Get_ArticleStorages_for_ArticleIDList.Invoke(Connection, Transaction, storageParam, securityTicket).Result;

                    var expectedDeliveryParam = new P_L3AR_GIHEDfPL_0911 { ProductIDList = productIDList };
                    articlesWithExpectedDelivery = cls_Get_If_Has_Expected_Delivery_for_ProductIDList.Invoke(
                        Connection, Transaction, expectedDeliveryParam, securityTicket).Result.Select(x => x.ProductID).ToArray();
                }

                foreach (var item in productIDList)
                {
                    var storage = storages.FirstOrDefault(x => x.ArticleID == item);

                    

                    #region get supplier data
                    string supplierName = String.Empty;
                    Guid supplierID = Guid.Empty;
                    string storagePlace = String.Empty;

                    if (storage != null)
                    {
                        storagePlace = storage.WarehouseCode + storage.AreaCode + storage.RackCode + storage.ShelfCode;

                        P_L3SP_GDSfS_1347 supplierParam = new P_L3SP_GDSfS_1347();
                        supplierParam.AreaID = storage.AreaID;
                        supplierParam.RackID = storage.RackID;
                        supplierParam.WarehouseID = storage.WarehouseID;
                        var supplier = cls_Get_Default_Supplier_from_Storage.Invoke(Connection, Transaction, supplierParam, securityTicket).Result;
                        supplierName = supplier.SupplierName;
                        supplierID = supplier.SupplierID;
                    }

                    #endregion

                    #region stock quantities

                    P_L3AR_GSQfP_1220 stockParam = new P_L3AR_GSQfP_1220();
                    stockParam.ProductID = item;
                    var stockQuantities = cls_Get_StockQuantities_for_ProductID.Invoke(Connection, Transaction, stockParam, securityTicket).Result; 

                    #endregion

                    var productMSR = msrForProducts.SingleOrDefault(x => x.ProductID == item);

                    #region form output parameter

                    L5AR_GAADfAL_1426 result = new L5AR_GAADfAL_1426();

                    result.ProductID = item;
                    result.SupplierID = supplierID;
                    result.SupplierName = supplierName;
                    result.StockQuantities = stockQuantities;
                    result.StoragePlace = storagePlace;
                    result.ProductITL = articles.SingleOrDefault(x => x.CMN_PRO_ProductID == item).ProductITL;
                    var expDel = articlesWithExpectedDelivery.SingleOrDefault(x => x == item);
                    result.HasExpectedDelivery = (expDel == Guid.Empty) ? false : true;

                    result.MSR = (productMSR != null) ? productMSR.MSR : (double) 0.0;
                    returnValuesList.Add(result);

                    #endregion
                }
                
                #endregion

                returnValue.Result = returnValuesList.ToArray();
            }

            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5AR_GAADfAL_1426_Array Invoke(string ConnectionString,P_L5AR_GAADfAL_1426 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5AR_GAADfAL_1426_Array Invoke(DbConnection Connection,P_L5AR_GAADfAL_1426 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5AR_GAADfAL_1426_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AR_GAADfAL_1426 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5AR_GAADfAL_1426_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AR_GAADfAL_1426 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5AR_GAADfAL_1426_Array functionReturn = new FR_L5AR_GAADfAL_1426_Array();
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

				throw new Exception("Exception occured in method cls_Get_Additional_ArticleData_for_ArticleList",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5AR_GAADfAL_1426_Array : FR_Base
	{
		public L5AR_GAADfAL_1426[] Result	{ get; set; } 
		public FR_L5AR_GAADfAL_1426_Array() : base() {}

		public FR_L5AR_GAADfAL_1426_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5AR_GAADfAL_1426 for attribute P_L5AR_GAADfAL_1426
		[DataContract]
		public class P_L5AR_GAADfAL_1426 
		{
			//Standard type parameters
			[DataMember]
			public string[] ProductITLList { get; set; } 

		}
		#endregion
		#region SClass L5AR_GAADfAL_1426 for attribute L5AR_GAADfAL_1426
		[DataContract]
		public class L5AR_GAADfAL_1426 
		{
			//Standard type parameters
			[DataMember]
			public string SupplierName { get; set; } 
			[DataMember]
			public L3AR_GSQfP_1220 StockQuantities { get; set; } 
			[DataMember]
			public Guid SupplierID { get; set; } 
			[DataMember]
			public Guid ProductID { get; set; } 
			[DataMember]
			public string StoragePlace { get; set; } 
			[DataMember]
			public string ProductITL { get; set; } 
			[DataMember]
			public double MSR { get; set; } 
			[DataMember]
			public Boolean HasExpectedDelivery { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5AR_GAADfAL_1426_Array cls_Get_Additional_ArticleData_for_ArticleList(,P_L5AR_GAADfAL_1426 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5AR_GAADfAL_1426_Array invocationResult = cls_Get_Additional_ArticleData_for_ArticleList.Invoke(connectionString,P_L5AR_GAADfAL_1426 Parameter,securityTicket);
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
var parameter = new CL5_APOAdmin_Articles.Complex.Retrieval.P_L5AR_GAADfAL_1426();
parameter.ProductITLList = ...;

*/
