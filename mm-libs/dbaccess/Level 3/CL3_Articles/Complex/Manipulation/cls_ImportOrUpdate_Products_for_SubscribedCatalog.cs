/* 
 * Generated on 6/2/2014 12:18:59 PM
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
using CL1_CMN_SLS;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;
using System.Runtime.Serialization;
using CL1_CMN_PRO;
using DLCore_DBCommons.Utils;
using DLCore_DBCommons.APODemand;
using CL2_MedicalProduct.Atomic.Retrieval;
using CL3_Components.Complex.Manipulation;

namespace CL3_Articles.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_ImportOrUpdate_Products_for_SubscribedCatalog.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_ImportOrUpdate_Products_for_SubscribedCatalog
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3AR_IoUPfSC_1325_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3AR_IoUPfSC_1325 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_L3AR_IoUPfSC_1325_Array();

            var importedProducts = new List<L3AR_IoUPfSC_1325>();

            #region ABDA catalog

            var catalogQuery = new ORM_CMN_PRO_SubscribedCatalog.Query();
            catalogQuery.Tenant_RefID = securityTicket.TenantID;
            catalogQuery.IsDeleted = false;
            catalogQuery.CatalogCodeITL = EnumUtils.GetEnumDescription(EPublicCatalogs.ABDA);

            var abdaCatalog = ORM_CMN_PRO_SubscribedCatalog.Query.Search(Connection, Transaction, catalogQuery).SingleOrDefault();

            #endregion

            #region ImportOrUpdate Product's BaseData

            var param = new P_L3AR_IoUPBD_1631();

            var products = Parameter.Products.Select(item=>new P_L3AR_IoUPBD_1631a()
            {
                ProductITL = item.ProductITL,
                Product_Name = item.Product_Name,
                Product_Description = item.Product_Description,
                Product_Number = item.Product_Number,
                Dosage = item.Dosage,
                Amount = item.Amount,
                MeasuredInUnit_ISO_um_ums = item.MeasuredInUnit_ISO_um_ums,
                VAT = Double.Parse(item.VAT),
                Producer = item.Producer,
                DistributionStatus = item.DistributionStatus,
                DefaultExpirationPeriod_in_sec = item.DefaultExpirationPeriod_in_sec,
                DefaultStorageTemperature_min_in_kelvin = item.DefaultStorageTemperature_min_in_kelvin,
                DefaultStorageTemperature_max_in_kelvin = item.DefaultStorageTemperature_max_in_kelvin,
                IsStorage_CoolingRequired = item.IsStorage_CoolingRequired,
                IsProduct_AddictiveDrug = item.IsProduct_AddictiveDrug,
                ActiveComponents = item.ActiveComponents,
                IsPharmacyOnlyDistribution = item.IsPharmacyOnlyDistribution
            }).ToArray();

            param.Products = products;

            var importedProductsBaseData = cls_ImportOrUpdate_Products_BaseData.Invoke(Connection, Transaction, param, securityTicket).Result;
                
            #endregion

            foreach (var importedProductBaseData in importedProductsBaseData)
            {
                var currentParameter = Parameter.Products.SingleOrDefault(i => i.ProductITL == importedProductBaseData.ProductITL);

                var product = new ORM_CMN_PRO_Product();
                product.Load(Connection, Transaction, importedProductBaseData.ProductID);

                if (!importedProductBaseData.IsAlreadyExisted)
                {
                    product.IfImportedFromExternalCatalog_CatalogSubscription_RefID = Parameter.SubscribedCatalogID;
                    product.IsImportedFromExternalCatalog = true;
                    product.Save(Connection, Transaction);

                    ORM_CMN_PRO_Product_2_ProductGroup product_2_productGroup = new ORM_CMN_PRO_Product_2_ProductGroup();
                    product_2_productGroup.CMN_PRO_Product_RefID = product.CMN_PRO_ProductID;
                    product_2_productGroup.CMN_PRO_ProductGroup_RefID = Parameter.ProductGroupID;
                    product_2_productGroup.Tenant_RefID = securityTicket.TenantID;
                    product_2_productGroup.Creation_Timestamp = DateTime.Now;
                    product_2_productGroup.Save(Connection, Transaction);
                }
                else
                {
                    #region Update Product_2_ProductGroup

                    var groupsParam = new P_CL2_MP_GAPGfP_1735();
                    groupsParam.ProductID = product.CMN_PRO_ProductID;
                    var productGroups = cls_Get_All_ProductGroups_for_ProductID.Invoke(Connection, Transaction, groupsParam, securityTicket).Result;

                    var abdaGroup = productGroups.Where(i => i.GlobalPropertyMatchingID == EnumUtils.GetEnumDescription(EProductGroup.ABDA)).FirstOrDefault();
                    var houselistGroup = productGroups.Where(i => i.GlobalPropertyMatchingID == EnumUtils.GetEnumDescription(EProductGroup.HauseList)).FirstOrDefault();
                    
                    if (abdaGroup == default(CL2_MP_GAPGfP_1735))
                    {
                        //it's not in abda
                        if (houselistGroup == default(CL2_MP_GAPGfP_1735))
                        {
                            //it's not in abda and it's not in houselist
                            product.IfImportedFromExternalCatalog_CatalogSubscription_RefID = Parameter.SubscribedCatalogID;
                            product.IsImportedFromExternalCatalog = true;
                            product.Save(Connection, Transaction);
                        }
                        else
                        {
                            //it's not in abda but it's in houselist
                            //check if new import isn't from abda
                            //it could be new house list 
                            if (abdaCatalog == null || abdaCatalog.CMN_PRO_SubscribedCatalogID != Parameter.SubscribedCatalogID)
                            {
                                product.IfImportedFromExternalCatalog_CatalogSubscription_RefID = Parameter.SubscribedCatalogID;
                                product.IsImportedFromExternalCatalog = true;
                                product.Save(Connection, Transaction);
                            }
                        }
                    }
                    else
                    {
                        //it's in abda
                        if (houselistGroup == default(CL2_MP_GAPGfP_1735))
                        {
                            //it's in abda but it's not in houselist
                            //it could be house list or just update abda
                            product.IfImportedFromExternalCatalog_CatalogSubscription_RefID = Parameter.SubscribedCatalogID;
                            product.IsImportedFromExternalCatalog = true;
                            product.Save(Connection, Transaction);
                        }
                        else
                        {
                            //it's in abda and it's in houselist
                            //check if new import isn't from abda
                            //it could be only house list 
                            if (abdaCatalog.CMN_PRO_SubscribedCatalogID != Parameter.SubscribedCatalogID) 
                            {
                                product.IfImportedFromExternalCatalog_CatalogSubscription_RefID = Parameter.SubscribedCatalogID;
                                product.IsImportedFromExternalCatalog = true;
                                product.Save(Connection, Transaction);
                            }
                        }
                    }

                    var isAlreadyInGroup = ORM_CMN_PRO_Product_2_ProductGroup.Query.Exists(Connection, Transaction, new ORM_CMN_PRO_Product_2_ProductGroup.Query()
                    {
                        CMN_PRO_Product_RefID = product.CMN_PRO_ProductID,
                        CMN_PRO_ProductGroup_RefID = Parameter.ProductGroupID,
                        Tenant_RefID = securityTicket.TenantID
                    });

                    if (!isAlreadyInGroup)
                    {
                        ORM_CMN_PRO_Product_2_ProductGroup product_2_productGroup = new ORM_CMN_PRO_Product_2_ProductGroup();
                        product_2_productGroup.CMN_PRO_Product_RefID = product.CMN_PRO_ProductID;
                        product_2_productGroup.CMN_PRO_ProductGroup_RefID = Parameter.ProductGroupID;
                        product_2_productGroup.Tenant_RefID = securityTicket.TenantID;
                        product_2_productGroup.Creation_Timestamp = DateTime.Now;
                        product_2_productGroup.Save(Connection, Transaction);
                    }

                    #endregion
                }

                #region Default Price

                var price = ORM_CMN_SLS_Price.Query.Search(Connection, Transaction, new ORM_CMN_SLS_Price.Query()
                {
                    PricelistRelease_RefID = Parameter.PriceListReleaseID,
                    CMN_PRO_Product_RefID = product.CMN_PRO_ProductID,
                    Tenant_RefID = securityTicket.TenantID,
                    CMN_Currency_RefID = Parameter.CatalogCurrencyID,
                    IsDeleted = false
                }).SingleOrDefault();

                if (price == null)
                {
                    price = new ORM_CMN_SLS_Price();
                    price.CMN_SLS_PriceID = Guid.NewGuid();
                    price.PricelistRelease_RefID = Parameter.PriceListReleaseID;
                    price.CMN_PRO_Product_RefID = product.CMN_PRO_ProductID;
                    price.CMN_Currency_RefID = Parameter.CatalogCurrencyID;
                    price.Tenant_RefID = securityTicket.TenantID;
                    price.Creation_Timestamp = DateTime.Now;
                }

                price.PriceAmount = currentParameter.Price;
                price.Save(Connection, Transaction);

                #endregion

                importedProducts.Add(new L3AR_IoUPfSC_1325() { ProductID = product.CMN_PRO_ProductID, ProductITL = product.ProductITL });
            }

            returnValue.Result = importedProducts.ToArray();

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3AR_IoUPfSC_1325_Array Invoke(string ConnectionString,P_L3AR_IoUPfSC_1325 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3AR_IoUPfSC_1325_Array Invoke(DbConnection Connection,P_L3AR_IoUPfSC_1325 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3AR_IoUPfSC_1325_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3AR_IoUPfSC_1325 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3AR_IoUPfSC_1325_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3AR_IoUPfSC_1325 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3AR_IoUPfSC_1325_Array functionReturn = new FR_L3AR_IoUPfSC_1325_Array();
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

				throw new Exception("Exception occured in method cls_ImportOrUpdate_Products_for_SubscribedCatalog",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3AR_IoUPfSC_1325_Array : FR_Base
	{
		public L3AR_IoUPfSC_1325[] Result	{ get; set; } 
		public FR_L3AR_IoUPfSC_1325_Array() : base() {}

		public FR_L3AR_IoUPfSC_1325_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3AR_IoUPfSC_1325 for attribute P_L3AR_IoUPfSC_1325
		[DataContract]
		public class P_L3AR_IoUPfSC_1325 
		{
			[DataMember]
			public P_L3AR_IoUPfSC_1325_Products[] Products { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid SubscribedCatalogID { get; set; } 
			[DataMember]
			public Guid CatalogCurrencyID { get; set; } 
			[DataMember]
			public Guid CatalogLanguageID { get; set; } 
			[DataMember]
			public Guid ProductGroupID { get; set; } 
			[DataMember]
			public Guid PriceListReleaseID { get; set; } 

		}
		#endregion
		#region SClass P_L3AR_IoUPfSC_1325_Products for attribute Products
		[DataContract]
		public class P_L3AR_IoUPfSC_1325_Products 
		{
			//Standard type parameters
			[DataMember]
			public String ProductITL { get; set; } 
			[DataMember]
			public Dict Product_Name { get; set; } 
			[DataMember]
			public Dict Product_Description { get; set; } 
			[DataMember]
			public String Product_Number { get; set; } 
			[DataMember]
			public String Dosage { get; set; } 
			[DataMember]
			public Decimal Price { get; set; } 
			[DataMember]
			public String Amount { get; set; } 
			[DataMember]
			public String MeasuredInUnit_ISO_um_ums { get; set; } 
			[DataMember]
			public String VAT { get; set; } 
			[DataMember]
			public String Producer { get; set; } 
			[DataMember]
			public int DistributionStatus { get; set; } 
			[DataMember]
			public long DefaultExpirationPeriod_in_sec { get; set; } 
			[DataMember]
			public double DefaultStorageTemperature_min_in_kelvin { get; set; } 
			[DataMember]
			public double DefaultStorageTemperature_max_in_kelvin { get; set; } 
			[DataMember]
			public bool IsStorage_CoolingRequired { get; set; } 
			[DataMember]
			public bool IsProduct_AddictiveDrug { get; set; } 
			[DataMember]
			public bool IsPharmacyOnlyDistribution { get; set; } 
			[DataMember]
			public P_L3CO_SCfIPFC_1324_Component[] ActiveComponents { get; set; } 

		}
		#endregion
		#region SClass L3AR_IoUPfSC_1325 for attribute L3AR_IoUPfSC_1325
		[DataContract]
		public class L3AR_IoUPfSC_1325 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProductID { get; set; } 
			[DataMember]
			public String ProductITL { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3AR_IoUPfSC_1325_Array cls_ImportOrUpdate_Products_for_SubscribedCatalog(,P_L3AR_IoUPfSC_1325 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3AR_IoUPfSC_1325_Array invocationResult = cls_ImportOrUpdate_Products_for_SubscribedCatalog.Invoke(connectionString,P_L3AR_IoUPfSC_1325 Parameter,securityTicket);
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
var parameter = new CL3_Articles.Complex.Manipulation.P_L3AR_IoUPfSC_1325();
parameter.Products = ...;

parameter.SubscribedCatalogID = ...;
parameter.CatalogCurrencyID = ...;
parameter.CatalogLanguageID = ...;
parameter.ProductGroupID = ...;
parameter.PriceListReleaseID = ...;

*/
