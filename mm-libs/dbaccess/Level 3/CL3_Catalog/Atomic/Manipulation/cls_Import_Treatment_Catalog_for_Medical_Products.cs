/* 
 * Generated on 2/7/2014 4:13:06 PM
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
using CL1_HEC;
using CL2_Language.Atomic.Retrieval;

namespace CL3_Catalog.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Import_Treatment_Catalog_for_Medical_Products.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Import_Treatment_Catalog_for_Medical_Products
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L3ITCafMP_1634 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here

            /*
         * @save product
         * */
            P_L3CCfTaIC_1526 par = new P_L3CCfTaIC_1526();
            par.CatalogCodeITL = Parameter.CatalogCodeITL;
            par.CatalogDescription = Parameter.CatalogDescription;
            par.CatalogName = Parameter.CatalogName;
            par.isDeleted = Parameter.isDeleted;
            par.SubscribedBy_BusinessParticipant_RefID = Parameter.SubscribedBy_BusinessParticipant_RefID;
            par.ValidFrom_Date = Parameter.ValidFrom_Date;
            par.ValidTo_Date = Parameter.ValidTo_Date;
            par.CatalogLanguage_ISO_639_1_codes = Parameter.CatalogLanguage_ISO_639_1_codes;
            par.CatalogCurrency_ISO_4217 = Parameter.CatalogCurrency_ISO_4217;
            par.CatalogVersion = Parameter.CatalogVersion;
            par.IsCatalogPublic = Parameter.IsCatalogPublic;
            par.ClientName = Parameter.ClientName;

            List<P_L3CCfTaIC_1526_Products> productList = new List<P_L3CCfTaIC_1526_Products>();

            if (Parameter.Products != null)
            {
                foreach (var item in Parameter.Products)
                {
                    P_L3CCfTaIC_1526_Products product = new P_L3CCfTaIC_1526_Products();
                    product.isDeleted = item.isDeleted;
                    product.IsProduct_Article = item.IsProduct_Article;
                    product.Product_Description = item.Product_Description;
                    product.Product_Name = item.Product_Name;
                    product.Product_Number = item.Product_Number;
                    product.ProductITL = item.ProductITL;
                    product.Dosage = item.Dosage;
                    product.Price = item.Price;
                    product.Amount = item.Amount;
                    product.MeasuredInUnit_ISO_um_ums = item.MeasuredInUnit_ISO_um_ums;
                    product.VAT = item.VAT;
                    productList.Add(product);
                }

                par.Products = productList.ToArray();
            }
            if (Parameter.SupplierData != null)
            {
                P_L3CCfTaIC_1526_SupplierData supplier = new P_L3CCfTaIC_1526_SupplierData();
                supplier.SupplierITL = Parameter.SupplierData.SupplierITL;
                supplier.Supplier_Name = Parameter.SupplierData.Supplier_Name;
                supplier.CountryISO = Parameter.SupplierData.CountryISO;
                supplier.Street_Name = Parameter.SupplierData.Street_Name;
                supplier.Street_Number = Parameter.SupplierData.Street_Number;
                supplier.ZIP = Parameter.SupplierData.ZIP;
                supplier.Town = Parameter.SupplierData.ZIP;
                supplier.Region_Code = Parameter.SupplierData.Region_Code;
                supplier.TenantITL = Parameter.SupplierData.TenantITL;

                par.SupplierData = supplier;
            }
            List<L3CCfTaIC_1526> products = cls_Create_Catalog_for_Treatments_and_Import_Catalog.Invoke(Connection, Transaction, par, securityTicket).Result.ToList();


            /*
            * @save hec_product
            * */

            var DBLanguages = cls_Get_All_Languages.Invoke(Connection, Transaction, securityTicket).Result.ToList();

            foreach (var product in products)
            {

                #region edit hec_product

                if (product.isEdit == true)
                {
                    var hec_productQuery = new ORM_HEC_Product.Query();
                    hec_productQuery.Tenant_RefID = securityTicket.TenantID;
                    hec_productQuery.Ext_PRO_Product_RefID = product.ProductID;
                    hec_productQuery.IsDeleted = false;

                    var hec_product = ORM_HEC_Product.Query.Search(Connection, Transaction, hec_productQuery).First();

                    //try to find dosage if it exists
                    var dosageQuery = new ORM_HEC_Product_DosageForm.Query();
                    dosageQuery.Tenant_RefID = securityTicket.TenantID;
                    dosageQuery.IsDeleted = false;
                    dosageQuery.GlobalPropertyMatchingID = product.Dosage;

                    var dosage = ORM_HEC_Product_DosageForm.Query.Search(Connection, Transaction, dosageQuery).FirstOrDefault();

                    //if not create new
                    if (dosage == null)
                    {
                        dosage = new ORM_HEC_Product_DosageForm();
                        dosage.HEC_Product_DosageFormID = Guid.NewGuid();//hec_product.ProductDosageForm_RefID
                        dosage.Tenant_RefID = securityTicket.TenantID;
                        dosage.Creation_Timestamp = DateTime.Now;

                        dosage.GlobalPropertyMatchingID = product.Dosage;
                        dosage.Save(Connection, Transaction);
                    }

                    hec_product.ProductDosageForm_RefID = dosage.HEC_Product_DosageFormID;
                    hec_product.Save(Connection, Transaction);

                }
                #endregion

                #region save hec_product
                else
                {

                    ORM_HEC_Product hec_product = new ORM_HEC_Product();
                    hec_product.Ext_PRO_Product_RefID = product.ProductID;
                    hec_product.HEC_ProductID = Guid.NewGuid();
                    hec_product.Creation_Timestamp = DateTime.Now;
                    hec_product.Tenant_RefID = securityTicket.TenantID;
                    hec_product.IsDeleted = false;

                    //try to find dosage if it exists
                    var dosageQuery = new ORM_HEC_Product_DosageForm.Query();
                    dosageQuery.Tenant_RefID = securityTicket.TenantID;
                    dosageQuery.IsDeleted = false;
                    dosageQuery.GlobalPropertyMatchingID = product.Dosage;

                    var dosage = ORM_HEC_Product_DosageForm.Query.Search(Connection, Transaction, dosageQuery).FirstOrDefault();

                    //if not create new
                    if (dosage == null)
                    {
                        dosage = new ORM_HEC_Product_DosageForm();
                        dosage.HEC_Product_DosageFormID = Guid.NewGuid();//hec_product.ProductDosageForm_RefID
                        dosage.Tenant_RefID = securityTicket.TenantID;
                        dosage.Creation_Timestamp = DateTime.Now;

                        dosage.GlobalPropertyMatchingID = product.Dosage;
                        dosage.Save(Connection, Transaction);
                    }

                    hec_product.ProductDosageForm_RefID = dosage.HEC_Product_DosageFormID;
                    hec_product.Save(Connection, Transaction);
                }
                #endregion
            }

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L3ITCafMP_1634 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L3ITCafMP_1634 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L3ITCafMP_1634 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3ITCafMP_1634 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Import_Treatment_Catalog_for_Medical_Products",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3ITCafMP_1634 for attribute P_L3ITCafMP_1634
		[DataContract]
		public class P_L3ITCafMP_1634 
		{
			[DataMember]
			public P_L3ITCafMP_1634_Products[] Products { get; set; }
			[DataMember]
			public P_L3ITCafMP_1634_SupplierData SupplierData { get; set; }

			//Standard type parameters
			[DataMember]
			public String CatalogCodeITL { get; set; } 
			[DataMember]
			public String CatalogName { get; set; } 
			[DataMember]
			public String CatalogDescription { get; set; } 
			[DataMember]
			public DateTime ValidFrom_Date { get; set; } 
			[DataMember]
			public DateTime ValidTo_Date { get; set; } 
			[DataMember]
			public bool isDeleted { get; set; } 
			[DataMember]
			public Guid SubscribedBy_BusinessParticipant_RefID { get; set; } 
			[DataMember]
			public String CatalogLanguage_ISO_639_1_codes { get; set; } 
			[DataMember]
			public String CatalogCurrency_ISO_4217 { get; set; } 
			[DataMember]
			public int CatalogVersion { get; set; } 
			[DataMember]
			public Boolean IsCatalogPublic { get; set; } 
			[DataMember]
			public String ClientName { get; set; } 

		}
		#endregion
		#region SClass P_L3ITCafMP_1634_Products for attribute Products
		[DataContract]
		public class P_L3ITCafMP_1634_Products 
		{
			//Standard type parameters
			[DataMember]
			public String ProductITL { get; set; } 
			[DataMember]
			public bool isDeleted { get; set; } 
			[DataMember]
			public Dict Product_Name { get; set; } 
			[DataMember]
			public Dict Product_Description { get; set; } 
			[DataMember]
			public String Product_Number { get; set; } 
			[DataMember]
			public bool IsProduct_Article { get; set; } 
			[DataMember]
			public String Dosage { get; set; } 
			[DataMember]
			public Decimal Price { get; set; } 
			[DataMember]
			public double Amount { get; set; } 
			[DataMember]
			public String MeasuredInUnit_ISO_um_ums { get; set; } 
			[DataMember]
			public String VAT { get; set; } 

		}
		#endregion
		#region SClass P_L3ITCafMP_1634_SupplierData for attribute SupplierData
		[DataContract]
		public class P_L3ITCafMP_1634_SupplierData 
		{
			//Standard type parameters
			[DataMember]
			public String SupplierITL { get; set; } 
			[DataMember]
			public String TenantITL { get; set; } 
			[DataMember]
			public String Supplier_Name { get; set; } 
			[DataMember]
			public String CountryISO { get; set; } 
			[DataMember]
			public String Street_Name { get; set; } 
			[DataMember]
			public String Street_Number { get; set; } 
			[DataMember]
			public String ZIP { get; set; } 
			[DataMember]
			public String Town { get; set; } 
			[DataMember]
			public String Region_Code { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Import_Treatment_Catalog_for_Medical_Products(,P_L3ITCafMP_1634 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Import_Treatment_Catalog_for_Medical_Products.Invoke(connectionString,P_L3ITCafMP_1634 Parameter,securityTicket);
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
var parameter = new CL3_Catalog.Atomic.Manipulation.P_L3ITCafMP_1634();
parameter.Products = ...;
parameter.SupplierData = ...;

parameter.CatalogCodeITL = ...;
parameter.CatalogName = ...;
parameter.CatalogDescription = ...;
parameter.ValidFrom_Date = ...;
parameter.ValidTo_Date = ...;
parameter.isDeleted = ...;
parameter.SubscribedBy_BusinessParticipant_RefID = ...;
parameter.CatalogLanguage_ISO_639_1_codes = ...;
parameter.CatalogCurrency_ISO_4217 = ...;
parameter.CatalogVersion = ...;
parameter.IsCatalogPublic = ...;
parameter.ClientName = ...;

*/
