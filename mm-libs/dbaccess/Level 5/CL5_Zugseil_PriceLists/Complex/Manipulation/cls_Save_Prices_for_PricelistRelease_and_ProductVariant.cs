/* 
 * Generated on 31/10/2014 12:10:06
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
using CL1_CMN_SLS;

namespace CL5_Zugseil_PriceLists.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Prices_for_PricelistRelease_and_ProductVariant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Prices_for_PricelistRelease_and_ProductVariant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5PL_SPfPRaPV_0920 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here

            foreach (var item in Parameter.Data)
            {
                foreach (var currentPrice in item.Prices)
                { 
                    var price = new ORM_CMN_SLS_Price();
                    price.Tenant_RefID = securityTicket.TenantID;

                    if (currentPrice.PriceAmount == 0 && currentPrice.PriceID != Guid.Empty)
                    {
                        price.Load(Connection, Transaction, currentPrice.PriceID);

                        price.PriceAmount = 0;
                        price.IsDeleted = true;

                        price.Save(Connection, Transaction);
                    }
                    else if (currentPrice.PriceAmount != 0)
                    {
                        if (currentPrice.PriceID != Guid.Empty)
                        {
                            price.Load(Connection, Transaction, currentPrice.PriceID);

                            price.PriceAmount = currentPrice.PriceAmount;

                            price.Save(Connection, Transaction);
                        }
                        else
                        {
                            var pricequery = new ORM_CMN_SLS_Price.Query();
                            pricequery.CMN_Currency_RefID = currentPrice.CurrencyID;
                            pricequery.CMN_PRO_Product_Variant_RefID = item.ProductVariantID;
                            pricequery.PricelistRelease_RefID = item.PricelistReleaseID;

                            var prices = ORM_CMN_SLS_Price.Query.Search(Connection, Transaction, pricequery);
                            if (prices != null && prices.Count > 0)
                            {
                                price = prices.FirstOrDefault();
                                price.IsDeleted = false;
                                price.PriceAmount = currentPrice.PriceAmount;

                                price.Save(Connection, Transaction);
                            }
                            else
                            {
                                var productVariant = new CL1_CMN_PRO.ORM_CMN_PRO_Product_Variant();
                                productVariant.Load(Connection, Transaction, item.ProductVariantID);

                                price.CMN_SLS_PriceID = Guid.NewGuid();
                                price.CMN_Currency_RefID = currentPrice.CurrencyID;
                                price.CMN_PRO_Product_Variant_RefID = item.ProductVariantID;
                                price.CMN_PRO_Product_RefID = productVariant.CMN_PRO_Product_RefID;
                                price.PricelistRelease_RefID = item.PricelistReleaseID;
                                price.PriceAmount = currentPrice.PriceAmount;

                                price.Save(Connection, Transaction);
                            }
                        }
                    }

                    returnValue.Result = price.CMN_SLS_PriceID;

                }
            }


			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5PL_SPfPRaPV_0920 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5PL_SPfPRaPV_0920 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5PL_SPfPRaPV_0920 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5PL_SPfPRaPV_0920 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Guid functionReturn = new FR_Guid();
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

				throw new Exception("Exception occured in method cls_Save_Prices_for_PricelistRelease_and_ProductVariant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5PL_SPfPRaPV_0920 for attribute P_L5PL_SPfPRaPV_0920
		[DataContract]
		public class P_L5PL_SPfPRaPV_0920 
		{
			[DataMember]
			public P_L5PL_SPfPRaPV_0920a[] Data { get; set; }

			//Standard type parameters
		}
		#endregion
		#region SClass P_L5PL_SPfPRaPV_0920a for attribute Data
		[DataContract]
		public class P_L5PL_SPfPRaPV_0920a 
		{
			[DataMember]
			public P_L5PL_SPfPRaPV_0920b[] Prices { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid ProductVariantID { get; set; } 
			[DataMember]
			public Guid PricelistReleaseID { get; set; } 

		}
		#endregion
		#region SClass P_L5PL_SPfPRaPV_0920b for attribute Prices
		[DataContract]
		public class P_L5PL_SPfPRaPV_0920b 
		{
			//Standard type parameters
			[DataMember]
			public Guid PriceID { get; set; } 
			[DataMember]
			public decimal PriceAmount { get; set; } 
			[DataMember]
			public Guid CurrencyID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Prices_for_PricelistRelease_and_ProductVariant(,P_L5PL_SPfPRaPV_0920 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Prices_for_PricelistRelease_and_ProductVariant.Invoke(connectionString,P_L5PL_SPfPRaPV_0920 Parameter,securityTicket);
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
var parameter = new CL5_Zugseil_PriceLists.Complex.Manipulation.P_L5PL_SPfPRaPV_0920();
parameter.Data = ...;


*/
