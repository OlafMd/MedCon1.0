/* 
 * Generated on 16.09.2014 15:24:56
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
using CL6_APOReporting_APODemand.Atomic.Retrieval;
using CL3_Price.Complex.Retrieval;

namespace CL6_APOReporting_APODemand.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Data_for_ProcurementPrices.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Data_for_ProcurementPrices
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6AD_GDfPR_1535_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L6AD_GDfPR_1535 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L6AD_GDfPR_1535_Array();
			//Put your code here
            returnValue.Result = new FR_L6AD_GDfPR_1535_Array().Result;

            var ShippedArticles = cls_Get_ProductList_for_ShipmentPositionsByFilterDate.Invoke(Connection, Transaction, new P_L6AD_GPLfSPBFD_1828 {DateFrom = Parameter.DateFrom, DateTo = Parameter.DateTo, CustomerID = Parameter.Customer}, securityTicket).Result.ToList();

            var returnResultList = new List<L6AD_GDfPR_1535>();

            L6AD_GDfPR_1535 result = null;
            if (ShippedArticles.Any())
            {

            var ProductGuidList = ShippedArticles.Select(x => x.CMN_PRO_ProductID).ToArray();
            

            var averageProcurementPrices = cls_Get_AverageProcurementPrices_for_ArticleList.Invoke(Connection, Transaction, new P_L6AD_GAPPfAL_1842 { ProductIDList = ProductGuidList}, securityTicket).Result.ToList();
            var procurementPricesFromProductSuppliers = cls_Get_ProcurementPricesFromProductSuppliers_for_ArticleList.Invoke(Connection, Transaction, new P_L6AD_GPFPSfAL_1027 { ProductIDList = ProductGuidList} ,securityTicket).Result.ToList();
            var ABDAPrices = cls_Get_StandardPrices_for_ProductIDList.Invoke(Connection, Transaction, new P_L3PR_GSPfPIL_1645 { ProductIDList = ProductGuidList }, securityTicket).Result.ToList();
            
                foreach (var product in ShippedArticles)
                {
                    



                    var averageProcurementPrice = averageProcurementPrices.SingleOrDefault(x => x.Product_RefID == product.CMN_PRO_ProductID);
                    if (averageProcurementPrice != null && averageProcurementPrice.PriceValue_Amount != 0 )
                    {
                        if (averageProcurementPrice.PriceValue_Amount > Parameter.ProcurementPrice && averageProcurementPrice.PriceValue_Amount > 0)
                        {
                            result = new L6AD_GDfPR_1535();
                            result.Price = Math.Round((decimal)averageProcurementPrice.PriceValue_Amount, 2);
                            result.PZN = product.Product_Number;
                            result.ProductName = product.Product_Name.Contents[0].Content;
                            result.ShippedQuantity = product.QuantityToShip;
                            returnResultList.Add(result);
                        }
                         continue;
                    }
                    else
                    {
                        var procurementPrice_FromProductSuppliers = procurementPricesFromProductSuppliers.SingleOrDefault(x => x.CMN_PRO_Product_RefID == product.CMN_PRO_ProductID);
                        if (procurementPrice_FromProductSuppliers != null && procurementPrice_FromProductSuppliers.PriceValue_Amount != 0)
                        {
                            if (procurementPrice_FromProductSuppliers.PriceValue_Amount > Parameter.ProcurementPrice && procurementPrice_FromProductSuppliers.PriceValue_Amount > 0)
                            {
                                result = new L6AD_GDfPR_1535();
                                result.Price = Math.Round((decimal)procurementPrice_FromProductSuppliers.PriceValue_Amount, 2);
                                result.PZN = product.Product_Number;
                                result.ProductName = product.Product_Name.Contents[0].Content;
                                result.ShippedQuantity = product.QuantityToShip;
                                returnResultList.Add(result);
                            }
                            continue;
                        }
                        else
                        {
                            var ABDAPrice = ABDAPrices.SingleOrDefault(x=> x.ProductID == product.CMN_PRO_ProductID);
                            if (ABDAPrice != null && ABDAPrice.AbdaPrice != 0)
                            {
                                if (ABDAPrice.AbdaPrice > (decimal)Parameter.ProcurementPrice && ABDAPrice.AbdaPrice > 0)
                                {
                                    result = new L6AD_GDfPR_1535();
                                    result.Price = Math.Round(ABDAPrice.AbdaPrice,2);
                                    result.PZN = product.Product_Number;
                                    result.ProductName = product.Product_Name.Contents[0].Content;
                                    result.ShippedQuantity = product.QuantityToShip;
                                    returnResultList.Add(result);
                                }
                            }
                        }
                    }

                    

                }

                returnValue.Result = returnResultList.ToArray();
            }
            else returnValue.Result = null;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6AD_GDfPR_1535_Array Invoke(string ConnectionString,P_L6AD_GDfPR_1535 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6AD_GDfPR_1535_Array Invoke(DbConnection Connection,P_L6AD_GDfPR_1535 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6AD_GDfPR_1535_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L6AD_GDfPR_1535 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6AD_GDfPR_1535_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6AD_GDfPR_1535 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6AD_GDfPR_1535_Array functionReturn = new FR_L6AD_GDfPR_1535_Array();
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

				throw new Exception("Exception occured in method cls_Get_Data_for_ProcurementPrices",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6AD_GDfPR_1535_Array : FR_Base
	{
		public L6AD_GDfPR_1535[] Result	{ get; set; } 
		public FR_L6AD_GDfPR_1535_Array() : base() {}

		public FR_L6AD_GDfPR_1535_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6AD_GDfPR_1535 for attribute P_L6AD_GDfPR_1535
		[DataContract]
		public class P_L6AD_GDfPR_1535 
		{
			//Standard type parameters
			[DataMember]
			public DateTime DateFrom { get; set; } 
			[DataMember]
			public DateTime DateTo { get; set; } 
			[DataMember]
			public Double ProcurementPrice { get; set; } 
			[DataMember]
			public Guid Customer { get; set; } 

		}
		#endregion
		#region SClass L6AD_GDfPR_1535 for attribute L6AD_GDfPR_1535
		[DataContract]
		public class L6AD_GDfPR_1535 
		{
			//Standard type parameters
			[DataMember]
			public String PZN { get; set; } 
			[DataMember]
			public String ProductName { get; set; } 
			[DataMember]
			public decimal Price { get; set; } 
			[DataMember]
			public float ShippedQuantity { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6AD_GDfPR_1535_Array cls_Get_Data_for_ProcurementPrices(,P_L6AD_GDfPR_1535 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6AD_GDfPR_1535_Array invocationResult = cls_Get_Data_for_ProcurementPrices.Invoke(connectionString,P_L6AD_GDfPR_1535 Parameter,securityTicket);
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
var parameter = new CL6_APOReporting_APODemand.Complex.Manipulation.P_L6AD_GDfPR_1535();
parameter.DateFrom = ...;
parameter.DateTo = ...;
parameter.ProcurementPrice = ...;
parameter.Customer = ...;

*/
