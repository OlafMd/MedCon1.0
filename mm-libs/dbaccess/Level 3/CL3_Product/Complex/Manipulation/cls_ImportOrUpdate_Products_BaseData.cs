/* 
 * Generated on 11/25/2014 09:20:25
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
using CL3_Taxes.Atomic.Manipulation;
using CL1_CMN_PRO;
using CL1_CMN;
using CL1_CMN_BPT;
using CL1_CMN_PRO_PAC;
using DLUtils_Common.Calculations;

namespace CL3_Product.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_ImportOrUpdate_Products_BaseData.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_ImportOrUpdate_Products_BaseData
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3PR_IoUPBD_1614_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3PR_IoUPBD_1614 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_L3PR_IoUPBD_1614_Array();
            var result = new List<L3PR_IoUPBD_1614>();

            //Put your code here

            #region Get All Producers for Tenant

            var allProducers = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, new ORM_CMN_BPT_BusinessParticipant.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            });

            #endregion

            #region Get Taxes For Default Country

            var taxesToImport = Parameter.Products.Select(i => i.VAT).Distinct();

            var param = new P_L3TX_STfDCaRR_1119();
            param.TaxRates = taxesToImport.ToArray();
            var allTaxes = cls_Save_Taxes_for_DefaultCountry_and_ReturnResult.Invoke(Connection, Transaction, param, securityTicket).Result;

            #endregion

            foreach (var item in Parameter.Products)
            {
                bool alreadyExistingInDB = true;

                #region ORM_CMN_PRO_Product
                var productQuery = new ORM_CMN_PRO_Product.Query();
                productQuery.ProductITL = item.ProductITL;
                productQuery.Tenant_RefID = securityTicket.TenantID;
                productQuery.IsDeleted = false;
                productQuery.IsProductAvailableForOrdering = true;

                var product = ORM_CMN_PRO_Product.Query.Search(Connection, Transaction, productQuery).FirstOrDefault();

                if (product == null)
                {
                    product = new ORM_CMN_PRO_Product();
                    product.CMN_PRO_ProductID = Guid.NewGuid();
                    product.ProductITL = item.ProductITL;
                    product.PackageInfo_RefID = Guid.NewGuid();
                    product.Creation_Timestamp = DateTime.Now;
                    product.Tenant_RefID = securityTicket.TenantID;

                    alreadyExistingInDB = false;
                }

                product.Product_Name = item.Product_Name;
                product.Product_Description = item.Product_Description;
                product.Product_Number = item.Product_Number;
                product.IsProduct_Article = true;
                product.IsProductAvailableForOrdering = true;

                #region Save Producer
                var producerBPT = allProducers.Where(i => i.DisplayName == item.Producer).FirstOrDefault();

                if (producerBPT == default(ORM_CMN_BPT_BusinessParticipant))
                {
                    producerBPT = new ORM_CMN_BPT_BusinessParticipant();
                    producerBPT.CMN_BPT_BusinessParticipantID = Guid.NewGuid();
                    producerBPT.DisplayName = item.Producer;
                    producerBPT.IsCompany = true;
                    producerBPT.Tenant_RefID = securityTicket.TenantID;
                    producerBPT.Creation_Timestamp = DateTime.Now;
                    producerBPT.Save(Connection, Transaction);
                }

                #endregion

                product.ProducingBusinessParticipant_RefID = producerBPT.CMN_BPT_BusinessParticipantID;
                product.Save(Connection, Transaction);
                #endregion

                #region Unit
                //Unit could be used for multiple products, there is no sense to edit unit
                //If there is need to change unit, we should find unit with that iso code and change reference

                var unitsQuery = new ORM_CMN_Unit.Query();
                unitsQuery.Tenant_RefID = securityTicket.TenantID;
                unitsQuery.ISOCode = item.MeasuredInUnit_ISO_um_ums;
                unitsQuery.IsDeleted = false;

                var measuredInUnit = ORM_CMN_Unit.Query.Search(Connection, Transaction, unitsQuery).FirstOrDefault();
                if (measuredInUnit == null)
                {
                    measuredInUnit = new ORM_CMN_Unit();
                    measuredInUnit.Tenant_RefID = securityTicket.TenantID;
                    measuredInUnit.Creation_Timestamp = DateTime.Now;
                    measuredInUnit.ISOCode = item.MeasuredInUnit_ISO_um_ums;
                    measuredInUnit.CMN_UnitID = Guid.NewGuid();
                    measuredInUnit.Save(Connection, Transaction);
                }
                #endregion

                #region PackageInfo
                var packageInfo = new ORM_CMN_PRO_PAC_PackageInfo();
                packageInfo.Load(Connection, Transaction, product.PackageInfo_RefID);
                if (packageInfo.CMN_PRO_PAC_PackageInfoID == Guid.Empty)
                {
                    packageInfo.CMN_PRO_PAC_PackageInfoID = product.PackageInfo_RefID;
                    packageInfo.Creation_Timestamp = DateTime.Now;
                    packageInfo.Tenant_RefID = securityTicket.TenantID;
                }
                packageInfo.PackageContent_DisplayLabel = item.Amount;
                packageInfo.PackageContent_Amount = PackageAmountUtils.GetPackageAmount(item.Amount);
                packageInfo.PackageContent_MeasuredInUnit_RefID = measuredInUnit.CMN_UnitID;

                packageInfo.Save(Connection, Transaction);
                #endregion

                #region VAT
                var salesTax = ORM_CMN_PRO_Product_SalesTaxAssignmnet.Query.Search(Connection, Transaction, new ORM_CMN_PRO_Product_SalesTaxAssignmnet.Query()
                {
                    Product_RefID = product.CMN_PRO_ProductID,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).FirstOrDefault();

                if (salesTax == null)
                {
                    salesTax = new ORM_CMN_PRO_Product_SalesTaxAssignmnet();
                    salesTax.CMN_PRO_Product_SalesTaxAssignmnetID = Guid.NewGuid();
                    salesTax.Product_RefID = product.CMN_PRO_ProductID;
                    salesTax.Creation_Timestamp = DateTime.Now;
                    salesTax.Tenant_RefID = securityTicket.TenantID;
                }

                salesTax.ApplicableSalesTax_RefID = allTaxes.Where(i => i.TaxRate == item.VAT).Select(j => j.TaxID).FirstOrDefault();
                salesTax.Save(Connection, Transaction);
                #endregion

                result.Add(new L3PR_IoUPBD_1614()
                {
                    ProductITL = product.ProductITL,
                    ProductID = product.CMN_PRO_ProductID,
                    IsAlreadyExisted = alreadyExistingInDB
                });
            }

            returnValue.Result = result.ToArray();
            return returnValue;
		}
		#endregion
        #endregion UserCode
        #region Method Invocation Wrappers
        ///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3PR_IoUPBD_1614_Array Invoke(string ConnectionString,P_L3PR_IoUPBD_1614 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3PR_IoUPBD_1614_Array Invoke(DbConnection Connection,P_L3PR_IoUPBD_1614 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3PR_IoUPBD_1614_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3PR_IoUPBD_1614 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3PR_IoUPBD_1614_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3PR_IoUPBD_1614 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3PR_IoUPBD_1614_Array functionReturn = new FR_L3PR_IoUPBD_1614_Array();
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

				throw new Exception("Exception occured in method cls_ImportOrUpdate_Products_BaseData",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3PR_IoUPBD_1614_Array : FR_Base
	{
		public L3PR_IoUPBD_1614[] Result	{ get; set; } 
		public FR_L3PR_IoUPBD_1614_Array() : base() {}

		public FR_L3PR_IoUPBD_1614_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3PR_IoUPBD_1614 for attribute P_L3PR_IoUPBD_1614
		[DataContract]
		public class P_L3PR_IoUPBD_1614 
		{
			[DataMember]
			public P_L3PR_IoUPBD_1614_Products[] Products { get; set; }

			//Standard type parameters
		}
		#endregion
		#region SClass P_L3PR_IoUPBD_1614_Products for attribute Products
		[DataContract]
		public class P_L3PR_IoUPBD_1614_Products 
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
			public String Amount { get; set; } 
			[DataMember]
			public String MeasuredInUnit_ISO_um_ums { get; set; } 
			[DataMember]
			public double VAT { get; set; } 
			[DataMember]
			public String Producer { get; set; } 

		}
		#endregion
		#region SClass L3PR_IoUPBD_1614 for attribute L3PR_IoUPBD_1614
		[DataContract]
		public class L3PR_IoUPBD_1614 
		{
			//Standard type parameters
			[DataMember]
			public String ProductITL { get; set; } 
			[DataMember]
			public Guid ProductID { get; set; } 
			[DataMember]
			public bool IsAlreadyExisted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3PR_IoUPBD_1614_Array cls_ImportOrUpdate_Products_BaseData(,P_L3PR_IoUPBD_1614 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3PR_IoUPBD_1614_Array invocationResult = cls_ImportOrUpdate_Products_BaseData.Invoke(connectionString,P_L3PR_IoUPBD_1614 Parameter,securityTicket);
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
var parameter = new CL3_Product.Complex.Manipulation.P_L3PR_IoUPBD_1614();
parameter.Products = ...;


*/
