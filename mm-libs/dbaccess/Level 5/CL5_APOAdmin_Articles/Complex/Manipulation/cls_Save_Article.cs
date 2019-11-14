/* 
 * Generated on 6/24/2014 5:12:33 PM
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
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;
using System.Runtime.Serialization;
using DLCore_DBCommons.APODemand;
using DLCore_DBCommons.Utils;
using CL1_CMN_PRO;
using CL1_CMN;
using CL1_CMN_PRO_PAC;
using DLUtils_Common.Calculations;
using CL2_Products.DomainManagement;
using CL1_HEC;
using DLCore_DBCommons.XMLInDBModels;
using CL1_CMN_BPT;

namespace CL5_APOAdmin_Articles.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Article.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Article
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5AR_SA_1525 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            var languageQuery = new ORM_CMN_Language.Query();
            languageQuery.Tenant_RefID = securityTicket.TenantID;
            languageQuery.IsDeleted = false;

            var languages = ORM_CMN_Language.Query.Search(Connection, Transaction, languageQuery);

            var product = new ORM_CMN_PRO_Product();

            if (Parameter.ArticleID == Guid.Empty)
            {
                #region ORM_CMN_PRO_Product

                product = new ORM_CMN_PRO_Product();
                product.CMN_PRO_ProductID = Guid.NewGuid();
                product.ProductITL = Guid.NewGuid().ToString();

                product.IsProduct_Article = true;
                product.IsProductAvailableForOrdering = true;
                product.IsImportedFromExternalCatalog = false;

                product.Product_Name = new Dict(ORM_CMN_PRO_Product.TableName);
                product.Product_Description = new Dict(ORM_CMN_PRO_Product.TableName);

                product.PackageInfo_RefID = Guid.NewGuid();

                product.Creation_Timestamp = DateTime.Now;
                product.Tenant_RefID = securityTicket.TenantID;

                product.Save(Connection, Transaction);

                #endregion

                #region CustomArticles Group

                var customerArticlesGroupID = Guid.Empty;

                var customArticlesGlobalMatching = EnumUtils.GetEnumDescription(EProductGroup.CustomArticles);

                var customerArticlesGroup = ORM_CMN_PRO_ProductGroup.Query.Search(Connection, Transaction, new ORM_CMN_PRO_ProductGroup.Query()
                {
                    GlobalPropertyMatchingID = customArticlesGlobalMatching,
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID

                });

                if (customerArticlesGroup == null || customerArticlesGroup.Count() == 0)
                {
                    var group = new ORM_CMN_PRO_ProductGroup();
                    group.CMN_PRO_ProductGroupID = Guid.NewGuid();
                    group.GlobalPropertyMatchingID = customArticlesGlobalMatching;
                    group.ProductGroup_Name = new Dict(ORM_CMN_PRO_ProductGroup.TableName);
                    foreach (var language in languages)
                    {
                        group.ProductGroup_Name.AddEntry(language.CMN_LanguageID, "Custom Articles");
                    }
                    group.ProductGroup_Description = new Dict(ORM_CMN_PRO_ProductGroup.TableName);
                    group.IsDeleted = false;
                    group.Creation_Timestamp = DateTime.Now;
                    group.Tenant_RefID = securityTicket.TenantID;
                    group.Save(Connection, Transaction);

                    customerArticlesGroupID = group.CMN_PRO_ProductGroupID;
                }
                else
                {
                    customerArticlesGroupID = customerArticlesGroup.Single().CMN_PRO_ProductGroupID;
                }

                var product2Group = new ORM_CMN_PRO_Product_2_ProductGroup();
                product2Group.AssignmentID = Guid.NewGuid();
                product2Group.CMN_PRO_Product_RefID = product.CMN_PRO_ProductID;
                product2Group.CMN_PRO_ProductGroup_RefID = customerArticlesGroupID;
                product2Group.Creation_Timestamp = DateTime.Now;
                product2Group.Tenant_RefID = securityTicket.TenantID;
                product2Group.Save(Connection, Transaction);

                #endregion
            }
            else 
            {
                product.Load(Connection, Transaction, Parameter.ArticleID);
            }

            #region ORM_CMN_PRO_Product

            product.Product_Number = Parameter.PZN;

            foreach (var language in languages)
                product.Product_Name.UpdateEntry(language.CMN_LanguageID, Parameter.ArticleName);

            foreach (var language in languages)
                product.Product_Description.UpdateEntry(language.CMN_LanguageID, Parameter.Notice);

            product.DefaultStorageTemperature_min_in_kelvin = Parameter.StorageTemperatureFrom_in_kelvin;
            product.DefaultStorageTemperature_max_in_kelvin = Parameter.StorageTemperatureTo_in_kelvin;
            product.DefaultExpirationPeriod_in_sec = Parameter.Expiring_in_seconds;

            product.ProductType_RefID = Parameter.ArticleType_RefID;

            product.IsPlaceholderArticle = Parameter.IsDummy;

            product.IsStorage_CoolingRequired = Parameter.IsStorage_CoolingRequired;
            product.IsStorage_BatchNumberMandatory = Parameter.IsStorage_BatchNumberMandatory;
            product.IsStorage_ExpiryDateMandatory = Parameter.IsStorage_ExpiryDateMandatory;
            product.IsProductPartOfDefaultStock = Parameter.IsProduct_PartOfDefaultStock;
            
            var xml = new ProductAdditionalInfoXML(){
                IsPharmacyOnlyDistribution = Parameter.IsProduct_PharmacyOnlyDistribution
            };
            product.ProductAdditionalInfoXML = xml.ToPayload();

            product.ProductSuccessor_RefID = Parameter.ProductSuccessor_RefID;

            product.Save(Connection, Transaction);

            #endregion

            #region ORM_HEC_Product

            var query = new ORM_HEC_Product.Query();
            query.Ext_PRO_Product_RefID = product.CMN_PRO_ProductID;
            query.IsDeleted = false;
            query.Tenant_RefID = securityTicket.TenantID;

            var hecProduct = ORM_HEC_Product.Query.Search(Connection, Transaction, query).SingleOrDefault();
            if(hecProduct==null)
            {
                hecProduct = new ORM_HEC_Product();
                hecProduct.HEC_ProductID = Guid.NewGuid();
                hecProduct.Ext_PRO_Product_RefID = product.CMN_PRO_ProductID;
                hecProduct.Creation_Timestamp = DateTime.Now;
                hecProduct.Tenant_RefID = securityTicket.TenantID;
            }
            hecProduct.ProductDosageForm_RefID = Parameter.DosageForm_RefID;
            hecProduct.IsProduct_AddictiveDrug = Parameter.IsProduct_AddictiveDrug;
            hecProduct.Save(Connection, Transaction);
            
            #endregion

            #region ORM_CMN_PRO_Product_2_ProductGroup

            var groupQuery = new ORM_CMN_PRO_Product_2_ProductGroup.Query();
            groupQuery.CMN_PRO_Product_RefID = product.CMN_PRO_ProductID;
            groupQuery.IsDeleted = false;
            groupQuery.Tenant_RefID = securityTicket.TenantID;

            var alreadyPersistedGroups = ORM_CMN_PRO_Product_2_ProductGroup.Query.Search(Connection, Transaction, groupQuery);

            //delete removed groups
            foreach (var item in alreadyPersistedGroups)
            {
                var globalGroup = new ORM_CMN_PRO_ProductGroup();
                globalGroup.Load(Connection, Transaction, item.CMN_PRO_ProductGroup_RefID);

                if (!Parameter.ArticleGroup_RefIDs.Contains(item.CMN_PRO_ProductGroup_RefID) && String.IsNullOrEmpty(globalGroup.GlobalPropertyMatchingID))
                {
                    item.IsDeleted = true;
                    item.Save(Connection, Transaction);
                }
            }

            //add new groups
            foreach (var groupID in Parameter.ArticleGroup_RefIDs)
            {
                if (!alreadyPersistedGroups.Select(i => i.CMN_PRO_ProductGroup_RefID).Contains(groupID))
                {
                    var group = new ORM_CMN_PRO_Product_2_ProductGroup();
                    group.AssignmentID = Guid.NewGuid();
                    group.CMN_PRO_Product_RefID = product.CMN_PRO_ProductID;
                    group.CMN_PRO_ProductGroup_RefID = groupID;
                    group.Creation_Timestamp = DateTime.Now;
                    group.Tenant_RefID = securityTicket.TenantID;
                    group.Save(Connection, Transaction);
                }
            }

            #endregion

            #region ORM_CMN_PRO_Product_SalesTaxAssignmnet

            var salesTaxQuery = new ORM_CMN_PRO_Product_SalesTaxAssignmnet.Query();
            salesTaxQuery.Product_RefID = product.CMN_PRO_ProductID;
            salesTaxQuery.IsDeleted = false;
            salesTaxQuery.Tenant_RefID = securityTicket.TenantID;

            var salesTax = ORM_CMN_PRO_Product_SalesTaxAssignmnet.Query.Search(Connection, Transaction, salesTaxQuery).SingleOrDefault();
            if (salesTax == null)
            {
                salesTax = new ORM_CMN_PRO_Product_SalesTaxAssignmnet();
                salesTax.CMN_PRO_Product_SalesTaxAssignmnetID = Guid.NewGuid();
                salesTax.Product_RefID = product.CMN_PRO_ProductID;
                salesTax.Creation_Timestamp = DateTime.Now;
                salesTax.Tenant_RefID = securityTicket.TenantID;
            }
            salesTax.ApplicableSalesTax_RefID = Parameter.VAT_RefID;
            salesTax.Save(Connection, Transaction);

            #endregion

            #region ORM_CMN_PRO_Product_2_ProductCode

            var product2CodeQuery = new ORM_CMN_PRO_Product_2_ProductCode.Query();
            product2CodeQuery.CMN_PRO_Product_RefID = product.CMN_PRO_ProductID;
            product2CodeQuery.Tenant_RefID = securityTicket.TenantID;
            product2CodeQuery.IsDeleted = false;

            var productCodeAssignment = ORM_CMN_PRO_Product_2_ProductCode.Query.Search(Connection, Transaction, product2CodeQuery).SingleOrDefault();

            if (productCodeAssignment == null)
            {
                #region ORM_CMN_PRO_ProductCode

                //Get Product Code Type or create it if not exist
                var eanID = DMProductCodeTypes.Get_ProductCodeType_ByGlobalMatchingID(Connection, Transaction, EProductCodeType.EAN, securityTicket);

                var productCode = new ORM_CMN_PRO_ProductCode();
                productCode.CMN_PRO_ProductCodeID = Guid.NewGuid();
                productCode.ProductCode_Type_RefID = eanID;
                productCode.ProductCode_Value = Parameter.EAN;
                productCode.Creation_Timestamp = DateTime.Now;
                productCode.Tenant_RefID = securityTicket.TenantID;
                productCode.Save(Connection, Transaction);

                #endregion

                #region ORM_CMN_PRO_Product_2_ProductCode

                var product2Code = new ORM_CMN_PRO_Product_2_ProductCode();
                product2Code.AssignmentID = Guid.NewGuid();
                product2Code.CMN_PRO_Product_RefID = product.CMN_PRO_ProductID;
                product2Code.CMN_PRO_ProductCode_RefID = productCode.CMN_PRO_ProductCodeID;
                product2Code.Creation_Timestamp = DateTime.Now;
                product2Code.Tenant_RefID = securityTicket.TenantID;
                product2Code.Save(Connection, Transaction);

                #endregion
            }
            else 
            {
                #region ORM_CMN_PRO_ProductCode

                var productCode = new ORM_CMN_PRO_ProductCode();
                productCode.Load(Connection, Transaction, productCodeAssignment.CMN_PRO_ProductCode_RefID);
                productCode.ProductCode_Value = Parameter.EAN;
                productCode.Save(Connection, Transaction);

                #endregion
            }

            #endregion

            #region ORM_CMN_PRO_PackageInfo

            var packageInfo = new ORM_CMN_PRO_PAC_PackageInfo();
            packageInfo.Load(Connection, Transaction, product.PackageInfo_RefID);
            if (packageInfo.CMN_PRO_PAC_PackageInfoID == Guid.Empty) 
            {
                packageInfo = new ORM_CMN_PRO_PAC_PackageInfo();
                packageInfo.CMN_PRO_PAC_PackageInfoID = product.PackageInfo_RefID;
                packageInfo.Creation_Timestamp = DateTime.Now;
                packageInfo.Tenant_RefID = securityTicket.TenantID;
            
            }
            packageInfo.PackageContent_Amount = PackageAmountUtils.GetPackageAmount(Parameter.UnitAmount);
            packageInfo.PackageContent_DisplayLabel = Parameter.UnitAmount;
            packageInfo.PackageContent_MeasuredInUnit_RefID = Parameter.Unit_RefID;
            packageInfo.Save(Connection, Transaction);

            #endregion

            #region Producer

            var producer = new ORM_CMN_BPT_BusinessParticipant();
            producer.Load(Connection, Transaction, product.ProducingBusinessParticipant_RefID);
            if (producer.CMN_BPT_BusinessParticipantID == Guid.Empty) 
            {
                producer.CMN_BPT_BusinessParticipantID = Guid.NewGuid();
                producer.IsCompany = true;
                producer.Tenant_RefID = securityTicket.TenantID;
                producer.Creation_Timestamp = DateTime.Now;

                product.ProducingBusinessParticipant_RefID = producer.CMN_BPT_BusinessParticipantID;
                product.Save(Connection, Transaction);
            }
            producer.DisplayName = Parameter.Producer;
            producer.Save(Connection, Transaction);

            #endregion

            returnValue.Result = product.CMN_PRO_ProductID;
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5AR_SA_1525 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5AR_SA_1525 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AR_SA_1525 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AR_SA_1525 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Article",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5AR_SA_1525 for attribute P_L5AR_SA_1525
		[DataContract]
		public class P_L5AR_SA_1525 
		{
			//Standard type parameters
			[DataMember]
			public Guid ArticleID { get; set; } 
			[DataMember]
			public String PZN { get; set; } 
			[DataMember]
			public String EAN { get; set; } 
			[DataMember]
			public String ArticleName { get; set; } 
			[DataMember]
			public String UnitAmount { get; set; } 
			[DataMember]
			public Guid Unit_RefID { get; set; } 
			[DataMember]
			public String Producer { get; set; } 
			[DataMember]
			public Guid VAT_RefID { get; set; } 
			[DataMember]
			public long Expiring_in_seconds { get; set; } 
			[DataMember]
			public Double StorageTemperatureFrom_in_kelvin { get; set; } 
			[DataMember]
			public Double StorageTemperatureTo_in_kelvin { get; set; } 
			[DataMember]
			public String Notice { get; set; } 
			[DataMember]
			public Guid ArticleType_RefID { get; set; } 
			[DataMember]
			public Guid[] ArticleGroup_RefIDs { get; set; } 
			[DataMember]
			public Guid DosageForm_RefID { get; set; } 
			[DataMember]
			public Guid ProductSuccessor_RefID { get; set; } 
			[DataMember]
			public bool IsDummy { get; set; } 
			[DataMember]
			public bool IsRegularArticle { get; set; } 
			[DataMember]
			public Boolean IsStorage_CoolingRequired { get; set; } 
			[DataMember]
			public Boolean IsStorage_BatchNumberMandatory { get; set; } 
			[DataMember]
			public Boolean IsStorage_ExpiryDateMandatory { get; set; } 
			[DataMember]
			public Boolean IsProduct_PartOfDefaultStock { get; set; } 
			[DataMember]
			public Boolean IsProduct_AddictiveDrug { get; set; } 
			[DataMember]
			public Boolean IsProduct_PharmacyOnlyDistribution { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Article(,P_L5AR_SA_1525 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Article.Invoke(connectionString,P_L5AR_SA_1525 Parameter,securityTicket);
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
var parameter = new CL5_APOAdmin_Articles.Complex.Manipulation.P_L5AR_SA_1525();
parameter.ArticleID = ...;
parameter.PZN = ...;
parameter.EAN = ...;
parameter.ArticleName = ...;
parameter.UnitAmount = ...;
parameter.Unit_RefID = ...;
parameter.Producer = ...;
parameter.VAT_RefID = ...;
parameter.Expiring_in_seconds = ...;
parameter.StorageTemperatureFrom_in_kelvin = ...;
parameter.StorageTemperatureTo_in_kelvin = ...;
parameter.Notice = ...;
parameter.ArticleType_RefID = ...;
parameter.ArticleGroup_RefIDs = ...;
parameter.DosageForm_RefID = ...;
parameter.ProductSuccessor_RefID = ...;
parameter.IsDummy = ...;
parameter.IsRegularArticle = ...;
parameter.IsStorage_CoolingRequired = ...;
parameter.IsStorage_BatchNumberMandatory = ...;
parameter.IsStorage_ExpiryDateMandatory = ...;
parameter.IsProduct_PartOfDefaultStock = ...;
parameter.IsProduct_AddictiveDrug = ...;
parameter.IsProduct_PharmacyOnlyDistribution = ...;

*/
