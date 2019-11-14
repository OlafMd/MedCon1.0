/* 
 * Generated on 14.10.2014 16:32:42
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
using CL5_APOAdmin_Articles.Atomic.Retrieval;
using DLCore_DBCommons.Utils;
using CL1_CMN_PRO;
using DLCore_DBCommons.APODemand;

namespace CL5_APOAdmin_Articles.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_ProductSupplier.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_ProductSupplier
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5AR_SPS_1535 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 

			var returnValue = new FR_Guid();

			#region ProductSupplier

			var productSupplier = new ORM_CMN_PRO_Product_Supplier();

			if (Parameter.Product_SupplierID != Guid.Empty)
			{
				var fetched = productSupplier.Load(Connection, Transaction, Parameter.Product_SupplierID);
			}

			if (Parameter.IsDeleted == true)
            {
                #region Delete ProductSupplier including Discount Values


                var deletePrices = CL1_CMN.ORM_CMN_Price.Query.Search(Connection, Transaction, new CL1_CMN.ORM_CMN_Price.Query
                {
                    CMN_PriceID = productSupplier.ProcurementPrice_RefID,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).SingleOrDefault();

                var deletePriceValues = CL1_CMN.ORM_CMN_Price_Value.Query.Search(Connection, Transaction, new CL1_CMN.ORM_CMN_Price_Value.Query
                {
                    Price_RefID = productSupplier.ProcurementPrice_RefID,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).SingleOrDefault();


                if (deletePriceValues != null)
                {
                    deletePriceValues.IsDeleted = true;
                    deletePriceValues.Save(Connection, Transaction);
                }

                if (deletePrices != null)
                {
                    deletePrices.IsDeleted = true;
                    deletePrices.Save(Connection, Transaction);
                }

                productSupplier.IsDeleted = true;
                productSupplier.Save(Connection, Transaction);

                ORM_CMN_PRO_Product_Supplier_DiscountValue.Query.SoftDelete(Connection, Transaction, 
                    new ORM_CMN_PRO_Product_Supplier_DiscountValue.Query
                    {
                        Product_Supplier_RefID = productSupplier.CMN_PRO_Product_SupplierID,
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID
                    });

                returnValue.Result = Parameter.Product_SupplierID;

                // fixing priority
                 var suppliersParam = new P_L5AA_GPSfPI_1248()
                 {
                        ProductID = Parameter.ProductID
                 };

                var SupplierProducts = cls_Get_ProductSuppliers_for_ProductID.Invoke(
                    Connection, Transaction, suppliersParam, securityTicket).Result;

                for (int i = 0; i < SupplierProducts.Count(); i++)
                {
                    if (SupplierProducts[i].SupplierPriority != (i + 1))
                    {
                        var findSupplierProduct = ORM_CMN_PRO_Product_Supplier.Query.Search(Connection, Transaction, new ORM_CMN_PRO_Product_Supplier.Query{
                            CMN_PRO_Product_SupplierID = SupplierProducts[i].CMN_PRO_Product_SupplierID,
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false
                        }).SingleOrDefault();

                        if (findSupplierProduct != null && findSupplierProduct.SupplierPriority != (i + 1))
                        {
                            findSupplierProduct.SupplierPriority = (i + 1);
                            findSupplierProduct.Save(Connection, Transaction);
                        }
                    }
                }


				return returnValue;

                #endregion
            }

			if (Parameter.Product_SupplierID == Guid.Empty)
			{
				// new product supplier
				productSupplier.CMN_PRO_Product_SupplierID = Guid.NewGuid();
				productSupplier.Tenant_RefID = securityTicket.TenantID;
				productSupplier.Creation_Timestamp = DateTime.Now;
				productSupplier.CMN_PRO_Product_RefID = Parameter.ProductID;

                // new cmn_prices

                var prices = new CL1_CMN.ORM_CMN_Price();
                prices.CMN_PriceID = Guid.NewGuid();
                prices.Tenant_RefID = securityTicket.TenantID;
                prices.Save(Connection, Transaction);
                
                // new cmn_price_values
                var priceValue = new CL1_CMN.ORM_CMN_Price_Value();
                priceValue.CMN_Price_ValueID = Guid.NewGuid();
                priceValue.Price_RefID = prices.CMN_PriceID;
                priceValue.PriceValue_Amount = Parameter.ProcurementPrice;
                priceValue.Tenant_RefID = securityTicket.TenantID;
                priceValue.Save(Connection, Transaction);

                productSupplier.ProcurementPrice_RefID = prices.CMN_PriceID;

			}


            var findPriceValues = CL1_CMN.ORM_CMN_Price_Value.Query.Search(Connection, Transaction, new CL1_CMN.ORM_CMN_Price_Value.Query
            {
                Price_RefID = productSupplier.ProcurementPrice_RefID,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).SingleOrDefault();

            if (findPriceValues != null)
            {
                findPriceValues.PriceValue_Amount = Parameter.ProcurementPrice;
                findPriceValues.Save(Connection, Transaction);
            }

            productSupplier.CMN_BPT_Supplier_RefID = Parameter.SupplierID;
			productSupplier.MinimalPackageOrderingAmount = (float) Parameter.MinimalPackageOrderingAmount;
			productSupplier.BatchOrderSize = Parameter.BatchOrderSize;
			productSupplier.SupplierPriority = Parameter.SupplierPriority;
            
			productSupplier.Save(Connection, Transaction);

			returnValue.Result = productSupplier.CMN_PRO_Product_SupplierID;

			#endregion

            #region Product Supplier Discount Values
            
            #region Preload default discount types

            var discountTypes = CL1_ORD_PRC.ORM_ORD_PRC_DiscountType.Query.Search(Connection, Transaction, 
                new CL1_ORD_PRC.ORM_ORD_PRC_DiscountType.Query
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                }).Where(x => !String.IsNullOrEmpty(x.GlobalPropertyMatchingID));

            #endregion

            if (Parameter.Product_SupplierID != Guid.Empty)
            {
                #region Load and update Discounts 
                
                var discountValues = ORM_CMN_PRO_Product_Supplier_DiscountValue.Query.Search(Connection, Transaction,
                    new ORM_CMN_PRO_Product_Supplier_DiscountValue.Query
                    {
                        Product_Supplier_RefID = productSupplier.CMN_PRO_Product_SupplierID,
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID
                    });

                foreach (var item in discountValues)
                {
                    string matchingID = discountTypes.Single(x => x.ORD_PRC_DiscountTypeID == item.ORD_PRC_DiscountType_RefID).GlobalPropertyMatchingID;
                    EDiscountType currentDiscountType = EnumUtils.GetEnumValueByDescription<EDiscountType>(matchingID);

                    switch(currentDiscountType)
                    {
                        case EDiscountType.CashDiscount:
                            item.DiscountValue = Parameter.CashDiscount;
                            break;
                        case EDiscountType.MainDiscount:
                            item.DiscountValue = Parameter.Discount1;
                            break;
                        case EDiscountType.Discount2:
                            item.DiscountValue = Parameter.Discount2;
                            break;
                        case EDiscountType.Discount3:
                            item.DiscountValue = Parameter.Discount3;
                            break;
                    }
                    item.Save(Connection, Transaction);
                }

                #endregion
            }
            else
            {
                #region Create discount values

                ORM_CMN_PRO_Product_Supplier_DiscountValue productSupplierDiscountValue = null;
                foreach(var item in discountTypes)
                {
                    productSupplierDiscountValue = new ORM_CMN_PRO_Product_Supplier_DiscountValue
                    {
                        CMN_PRO_Product_Supplier_DiscountValueID = Guid.NewGuid(),
                        Product_Supplier_RefID = productSupplier.CMN_PRO_Product_SupplierID,
                        ORD_PRC_DiscountType_RefID = item.ORD_PRC_DiscountTypeID,
                        IsRelativeDiscountValue = true,
                        IsAbsoluteDiscountValue = false,
                        Tenant_RefID = securityTicket.TenantID
                    };

                    EDiscountType currentDiscountType = EnumUtils.GetEnumValueByDescription<EDiscountType>(item.GlobalPropertyMatchingID);
                    switch (currentDiscountType)
                    {
                        case EDiscountType.CashDiscount:
                            productSupplierDiscountValue.DiscountValue = Parameter.CashDiscount;
                            break;
                        case EDiscountType.MainDiscount:
                            productSupplierDiscountValue.DiscountValue = Parameter.Discount1;
                            break;
                        case EDiscountType.Discount2:
                            productSupplierDiscountValue.DiscountValue = Parameter.Discount2;
                            break;
                        case EDiscountType.Discount3:
                            productSupplierDiscountValue.DiscountValue = Parameter.Discount3;
                            break;
                    }
                    productSupplierDiscountValue.Save(Connection, Transaction);
                }
                
                #endregion
            }
            
            #endregion

            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5AR_SPS_1535 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5AR_SPS_1535 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AR_SPS_1535 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AR_SPS_1535 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_ProductSupplier",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5AR_SPS_1535 for attribute P_L5AR_SPS_1535
		[DataContract]
		public class P_L5AR_SPS_1535 
		{
			//Standard type parameters
			[DataMember]
			public Guid Product_SupplierID { get; set; } 
			[DataMember]
			public Guid SupplierID { get; set; } 
			[DataMember]
			public Guid ProductID { get; set; } 
			[DataMember]
			public int SupplierPriority { get; set; } 
			[DataMember]
			public Double MinimalPackageOrderingAmount { get; set; } 
			[DataMember]
			public int BatchOrderSize { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 
			[DataMember]
			public double Discount1 { get; set; } 
			[DataMember]
			public double Discount2 { get; set; } 
			[DataMember]
			public double Discount3 { get; set; } 
			[DataMember]
			public double CashDiscount { get; set; } 
			[DataMember]
			public double ProcurementPrice { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_ProductSupplier(,P_L5AR_SPS_1535 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_ProductSupplier.Invoke(connectionString,P_L5AR_SPS_1535 Parameter,securityTicket);
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
var parameter = new CL5_APOAdmin_Articles.Complex.Manipulation.P_L5AR_SPS_1535();
parameter.Product_SupplierID = ...;
parameter.SupplierID = ...;
parameter.ProductID = ...;
parameter.SupplierPriority = ...;
parameter.MinimalPackageOrderingAmount = ...;
parameter.BatchOrderSize = ...;
parameter.IsDeleted = ...;
parameter.Discount1 = ...;
parameter.Discount2 = ...;
parameter.Discount3 = ...;
parameter.CashDiscount = ...;
parameter.ProcurementPrice = ...;

*/
