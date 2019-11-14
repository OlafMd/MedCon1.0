/* 
 * Generated on 10/29/2014 3:18:22 PM
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
using BOp.CatalogAPI;
using BOp.CatalogAPI.service;
using BOp.CatalogAPI.data.wrappers;
using CL5_Zugseil_Catalogs.Atomic.Retrieval;
using Newtonsoft.Json;
using CL1_CMN_PRO;



namespace CL5_Zugseil_Catalogs.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Catalogs_for_SearchCriteria_for_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Catalogs_for_SearchCriteria_for_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5CA_GAfSCfT_1158 Execute(DbConnection Connection,DbTransaction Transaction,P_L5CA_GAfSCfT_1158 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5CA_GAfSCfT_1158();
			
            //Put your code here
            List<L5CA_GCaRfT_1445> catalogWithRevisionsList = new List<L5CA_GCaRfT_1445>();
            List<L5CA_GCfT_1110> catalogsList = new List<L5CA_GCfT_1110>();
            List<L5CA_GAfSCfT_1158_Subscribers> subscribers = new List<L5CA_GAfSCfT_1158_Subscribers>();

            if (!String.IsNullOrEmpty(Parameter.SearchCriteria))
            {
                Parameter.SearchCriteria = Parameter.SearchCriteria.Replace("%", "\\%");
                Parameter.SearchCriteria = "%" + Parameter.SearchCriteria.ToUpper() + "%";
            }
            else
            {
                Parameter.SearchCriteria = null;
            }

            #region get catalog list
            P_L5CA_GCfT_1110 catalogsParameter = new P_L5CA_GCfT_1110();
            catalogsParameter.LanguageID = Parameter.LanguageID;
            catalogsParameter.ActivePage = Parameter.ActivePage;
            catalogsParameter.PageSize = Parameter.PageSize;
            catalogsParameter.SearchCriteria = Parameter.SearchCriteria;

            var catalogsListResult = cls_Get_Catalogs_for_TenantID.Invoke(Connection, Transaction, catalogsParameter, securityTicket);
            if (catalogsListResult.Status == FR_Status.Success && catalogsListResult.Result != null)
                catalogsList = catalogsListResult.Result.ToList();

            #endregion

            #region get catalog revisions
            L5CA_GCaRfT_1445 catalogWithRevisionsItem;
            L5CA_GCaRfT_1445a revisionItem;
            List<L5CA_GCaRfT_1445a> revisionList;
            ORM_CMN_PRO_Catalog_Revision.Query revisionQuery;
            List<ORM_CMN_PRO_Catalog_Revision> revisionsResult;
            foreach (var catalog in catalogsList)
            {
                revisionQuery = new ORM_CMN_PRO_Catalog_Revision.Query();
                revisionQuery.Tenant_RefID = securityTicket.TenantID;
                revisionQuery.IsDeleted = false;
                revisionQuery.CMN_PRO_Catalog_RefID = catalog.CMN_PRO_CatalogID;
                revisionsResult = ORM_CMN_PRO_Catalog_Revision.Query.Search(Connection, Transaction, revisionQuery);

                if(revisionsResult != null && revisionsResult.Count > 0)
                {
                    revisionList = new List<L5CA_GCaRfT_1445a>();
                    foreach (var revision in revisionsResult)
                    {
                        revisionItem = new L5CA_GCaRfT_1445a();
                        revisionItem.CatalogRevision_Description = revision.CatalogRevision_Description;
                        revisionItem.CatalogRevision_Name = revision.CatalogRevision_Name;
                        revisionItem.CMN_PRO_Catalog_RevisionID = revision.CMN_PRO_Catalog_RevisionID;
                        revisionItem.Default_PricelistRelease_RefID = revision.Default_PricelistRelease_RefID;
                        revisionItem.PublishedBy_BusinessParticipant_RefID = revision.PublishedBy_BusinessParticipant_RefID;
                        revisionItem.PublishedOn_Date = revision.PublishedOn_Date;
                        revisionItem.RevisionNumber = revision.RevisionNumber;
                        revisionItem.Valid_From = revision.Valid_From;
                        revisionItem.Valid_Through = revision.Valid_Through;

                        revisionList.Add(revisionItem);
                    }

                    catalogWithRevisionsItem = new L5CA_GCaRfT_1445();
                    catalogWithRevisionsItem.Catalog_Currency_RefID = catalog.Catalog_Currency_RefID;
                    catalogWithRevisionsItem.Catalog_Language_RefID = catalog.Catalog_Language_RefID;
                    catalogWithRevisionsItem.Catalog_Name_DictID = catalog.Catalog_Name;
                    catalogWithRevisionsItem.CatalogCodeITL = catalog.CatalogCodeITL;
                    catalogWithRevisionsItem.CMN_PRO_CatalogID = catalog.CMN_PRO_CatalogID;
                    catalogWithRevisionsItem.IsPublicCatalog = catalog.IsPublicCatalog;
                    catalogWithRevisionsItem.Revisions = revisionList.ToArray();

                    catalogWithRevisionsList.Add(catalogWithRevisionsItem);
                }
            }
            #endregion

            #region get subscribers

            ICatalogSubscriptionService catalogSubscriptionService = CatalogServiceFactory.GetSubscriptionService();

            CatalogSubscriptionStatisticsRequest request;
            CatalogSubscriptionStatisticsResponse response;
            L5CA_GAfSCfT_1158_Subscribers subscriber;
            foreach(var catalog in catalogWithRevisionsList)
            {
                request = new CatalogSubscriptionStatisticsRequest(){
                    AccessToken = catalog.IsPublicCatalog ? null : "to-be-defined",
                    CatalogCode = catalog.CatalogCodeITL
                };
                response = catalogSubscriptionService.CatalogSubscriptionStatistics(request);
                if (response != null && response.ResponseStatus == BOp.CatalogAPI.data.ResponseStatus.OK && 
                    response.subscribedCustomers != null && response.subscribedCustomers.Count > 0)
                {
                    if (subscribers.Any(i => i.CMN_PRO_CatalogID == catalog.CMN_PRO_CatalogID))
                    {
                        subscriber = subscribers.Single(i => i.CMN_PRO_CatalogID == catalog.CMN_PRO_CatalogID);
                        subscriber.Names.AddRange(response.subscribedCustomers.Select(i => i.Name));
                    }
                    else
                    {
                        subscriber = new L5CA_GAfSCfT_1158_Subscribers();
                        subscriber.CMN_PRO_CatalogID = catalog.CMN_PRO_CatalogID;
                        subscriber.Names = new List<string>();
                        subscriber.Names.AddRange(response.subscribedCustomers.Select(i => i.Name));
                        subscribers.Add(subscriber);
                    }
                }
            }

            #endregion

            L5CA_GAfSCfT_1158 result = new L5CA_GAfSCfT_1158();
            result.CatalogList = catalogWithRevisionsList.ToArray();
            result.Subscribers = subscribers.ToArray();
            returnValue.Result = result;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5CA_GAfSCfT_1158 Invoke(string ConnectionString,P_L5CA_GAfSCfT_1158 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5CA_GAfSCfT_1158 Invoke(DbConnection Connection,P_L5CA_GAfSCfT_1158 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5CA_GAfSCfT_1158 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5CA_GAfSCfT_1158 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5CA_GAfSCfT_1158 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5CA_GAfSCfT_1158 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5CA_GAfSCfT_1158 functionReturn = new FR_L5CA_GAfSCfT_1158();
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

				throw new Exception("Exception occured in method cls_Get_Catalogs_for_SearchCriteria_for_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5CA_GAfSCfT_1158 : FR_Base
	{
		public L5CA_GAfSCfT_1158 Result	{ get; set; }

		public FR_L5CA_GAfSCfT_1158() : base() {}

		public FR_L5CA_GAfSCfT_1158(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5CA_GAfSCfT_1158 for attribute P_L5CA_GAfSCfT_1158
		[DataContract]
		public class P_L5CA_GAfSCfT_1158 
		{
			//Standard type parameters
			[DataMember]
			public Guid LanguageID { get; set; } 
			[DataMember]
			public int PageSize { get; set; } 
			[DataMember]
			public int ActivePage { get; set; } 
			[DataMember]
			public String SearchCriteria { get; set; } 
			[DataMember]
			public String OrderByCriteria { get; set; } 

		}
		#endregion
		#region SClass L5CA_GAfSCfT_1158 for attribute L5CA_GAfSCfT_1158
		[DataContract]
		public class L5CA_GAfSCfT_1158 
		{
			[DataMember]
			public L5CA_GAfSCfT_1158_Subscribers[] Subscribers { get; set; }

			//Standard type parameters
			[DataMember]
			public L5CA_GCaRfT_1445[] CatalogList { get; set; } 

		}
		#endregion
		#region SClass L5CA_GAfSCfT_1158_Subscribers for attribute Subscribers
		[DataContract]
		public class L5CA_GAfSCfT_1158_Subscribers 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_CatalogID { get; set; } 
			[DataMember]
			public List<String> Names { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5CA_GAfSCfT_1158 cls_Get_Catalogs_for_SearchCriteria_for_Tenant(,P_L5CA_GAfSCfT_1158 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5CA_GAfSCfT_1158 invocationResult = cls_Get_Catalogs_for_SearchCriteria_for_Tenant.Invoke(connectionString,P_L5CA_GAfSCfT_1158 Parameter,securityTicket);
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
var parameter = new CL5_Zugseil_Catalogs.Complex.Retrieval.P_L5CA_GAfSCfT_1158();
parameter.LanguageID = ...;
parameter.PageSize = ...;
parameter.ActivePage = ...;
parameter.SearchCriteria = ...;
parameter.OrderByCriteria = ...;

*/
