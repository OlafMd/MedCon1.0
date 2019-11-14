/* 
 * Generated on 11/15/2014 5:21:21 PM
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
using CL2_Language.Atomic.Retrieval;
using CL1_CMN;
using CL1_CMN_PRO;
using CL1_CMN_BPT;
using CL1_CMN_SLS;
using CL3_Product.Complex.Manipulation;

namespace CL3_Zugseil_Catalog.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Import_Catalog.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Import_Catalog
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L3CA_IC_1527 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Guid();

            //Put your code here
            #region All tenant's languages
            P_L2LN_GALFTID_1530 langParam = new P_L2LN_GALFTID_1530();
            langParam.Tenant_RefID = securityTicket.TenantID;
            var allTenantLanguages = cls_Get_All_Languages_ForTenantID.Invoke(Connection, Transaction, langParam, securityTicket).Result;
            #endregion

            #region Get catalog's language or create it
            // check if language with that ISO exists for Tenant (Lower, exmpl de)
            var languageQuery = new ORM_CMN_Language.Query();
            languageQuery.ISO_639_1 = Parameter.CatalogLanguage_ISO_639_1.ToLower();
            languageQuery.Tenant_RefID = securityTicket.TenantID;
            languageQuery.IsDeleted = false;

            var language = ORM_CMN_Language.Query.Search(Connection, Transaction, languageQuery).FirstOrDefault();

            // if language does not exist for that Tenant
            if (language == null)
            {
                //check if language with that ISO exists for Tenant (Upper exmpl DE)
                languageQuery = new ORM_CMN_Language.Query();
                languageQuery.ISO_639_1 = Parameter.CatalogLanguage_ISO_639_1.ToUpper();
                languageQuery.Tenant_RefID = securityTicket.TenantID;
                languageQuery.IsDeleted = false;

                language = ORM_CMN_Language.Query.Search(Connection, Transaction, languageQuery).FirstOrDefault();

                // if language does not exist for that Tenant create it
                if (language == null)
                {
                    language = new ORM_CMN_Language();
                    language.CMN_LanguageID = Guid.NewGuid();
                    language.ISO_639_1 = Parameter.CatalogLanguage_ISO_639_1;
                    language.Name = new Dict(ORM_CMN_Language.TableName);
                    foreach (var item in allTenantLanguages)
                    {
                        language.Name.AddEntry(item.CMN_LanguageID, "CatalogLanguage - " + Parameter.CatalogLanguage_ISO_639_1);
                    }
                    language.Creation_Timestamp = DateTime.Now;
                    language.Tenant_RefID = securityTicket.TenantID;
                    language.IsDeleted = false;
                    language.Save(Connection, Transaction);
                }
            }
            #endregion

            #region Get catalog's currency or create it
            // check if currency with that ISO exists for Tenant
            var currencyQuery = new ORM_CMN_Currency.Query();
            currencyQuery.ISO4127 = Parameter.CatalogCurrency_ISO_4217.ToUpper();
            currencyQuery.Tenant_RefID = securityTicket.TenantID;
            currencyQuery.IsDeleted = false;

            var currency = ORM_CMN_Currency.Query.Search(Connection, Transaction, currencyQuery).FirstOrDefault();

            if (currency == null)
            {
                currencyQuery = new ORM_CMN_Currency.Query();
                currencyQuery.ISO4127 = Parameter.CatalogCurrency_ISO_4217.ToLower();
                currencyQuery.Tenant_RefID = securityTicket.TenantID;
                currencyQuery.IsDeleted = false;

                currency = ORM_CMN_Currency.Query.Search(Connection, Transaction, currencyQuery).FirstOrDefault();

                if (currency == null)
                {
                    currency = new ORM_CMN_Currency();
                    currency.CMN_CurrencyID = Guid.NewGuid();
                    currency.ISO4127 = Parameter.CatalogCurrency_ISO_4217;
                    currency.Name = new Dict(ORM_CMN_Currency.TableName);
                    foreach (var item in allTenantLanguages)
                    {
                        currency.Name.AddEntry(item.CMN_LanguageID, "CatalogCurrency - " + Parameter.CatalogCurrency_ISO_4217);
                    }
                    currency.Tenant_RefID = securityTicket.TenantID;
                    currency.Creation_Timestamp = DateTime.Now;
                    currency.Save(Connection, Transaction);
                }
            }
            #endregion

            #region save ORM_CMN_PRO_SubscribedCatalog
            var businessParticipant = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction,
            new ORM_CMN_BPT_BusinessParticipant.Query()
            {
                IfTenant_Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).Single();

            var subscribedCatalog = new ORM_CMN_PRO_SubscribedCatalog();
            subscribedCatalog.CMN_PRO_SubscribedCatalogID = Guid.NewGuid();
            subscribedCatalog.CatalogCodeITL = Parameter.CatalogCodeITL;
            subscribedCatalog.SubscribedCatalog_Name = Parameter.CatalogName;
            subscribedCatalog.SubscribedBy_BusinessParticipant_RefID = businessParticipant != null ? businessParticipant.CMN_BPT_BusinessParticipantID : Guid.Empty;
            subscribedCatalog.Tenant_RefID = securityTicket.TenantID;
            subscribedCatalog.SubscribedCatalog_ValidFrom = Parameter.ValidFrom_Date;
            subscribedCatalog.SubscribedCatalog_ValidThrough = Parameter.ValidTo_Date;
            subscribedCatalog.SubscribedCatalog_Description = Parameter.CatalogDescription;
            subscribedCatalog.Creation_Timestamp = DateTime.Now;
            subscribedCatalog.IsDeleted = false;
            subscribedCatalog.SubscribedCatalog_CurrentRevision = Parameter.CatalogVersion;
            subscribedCatalog.IsCatalogPublic = Parameter.IsCatalogPublic;

            subscribedCatalog.SubscribedCatalog_Language_RefID = language.CMN_LanguageID;
            subscribedCatalog.SubscribedCatalog_Currency_RefID = currency.CMN_CurrencyID;

            #region Create Supplier

            var CMN_BPT_SupplierID = cls_CreateOrUpdateSupplier_for_ImportedCatalog.Invoke(Connection, Transaction, Parameter.SupplierData, securityTicket).Result;

            #endregion

            subscribedCatalog.PublishingSupplier_RefID = CMN_BPT_SupplierID;
            subscribedCatalog.Save(Connection, Transaction);

            #endregion

            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L3CA_IC_1527 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L3CA_IC_1527 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L3CA_IC_1527 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3CA_IC_1527 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Import_Catalog",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3CA_IC_1527 for attribute P_L3CA_IC_1527
		[DataContract]
		public class P_L3CA_IC_1527 
		{
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
			public String CatalogLanguage_ISO_639_1 { get; set; } 
			[DataMember]
			public String CatalogCurrency_ISO_4217 { get; set; } 
			[DataMember]
			public int CatalogVersion { get; set; } 
			[DataMember]
			public Boolean IsCatalogPublic { get; set; } 
			[DataMember]
            public P_L3PR_IoUPfSC_1326_Products[] Products { get; set; } 
			[DataMember]
            public P_L3CA_CoUSfIC_1602 SupplierData { get; set; } 
                   
		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Import_Catalog(,P_L3CA_IC_1527 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Import_Catalog.Invoke(connectionString,P_L3CA_IC_1527 Parameter,securityTicket);
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
var parameter = new CL3_Zugseil_Catalog.Complex.Manipulation.P_L3CA_IC_1527();
parameter.CatalogCodeITL = ...;
parameter.CatalogName = ...;
parameter.CatalogDescription = ...;
parameter.ValidFrom_Date = ...;
parameter.ValidTo_Date = ...;
parameter.CatalogLanguage_ISO_639_1 = ...;
parameter.CatalogCurrency_ISO_4217 = ...;
parameter.CatalogVersion = ...;
parameter.IsCatalogPublic = ...;
parameter.Products = ...;
parameter.SupplierData = ...;

*/
