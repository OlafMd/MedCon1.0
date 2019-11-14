/* 
 * Generated on 10/1/2014 3:23:42 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 * Required Assemblies:
 * System.Runtime.Serialization
 * CSV2Core
 * CSV2Core_MySQL
 */
using System;
using System.Data.Common;
using System.Linq;
using System.Runtime.Serialization;
using CL1_CMN_BPT_CTM;
using CL1_CMN_PRO;
using CL1_CMN_PRO_PAC;
using CL1_CMN_SLS;
using CL1_ORD_CUO;
using CL2_NumberRange.Complex.Retrieval;
using CSV2Core.Core;
using DLCore_DBCommons.APODemand;
using DLCore_DBCommons.Utils;
using Realm.APODemand;
using System.Collections.Generic;

namespace CL5_APOBackoffice_CustomerOrder.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Create_CustomerOrder_after_MessageReceive.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Create_CustomerOrder_after_MessageReceive
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guids Execute(DbConnection Connection,DbTransaction Transaction,P_L5CO_CCOaMR_1102 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_Guids();
            var result = new List<Guid>();

            #region Current_CustomerOrderStatus

            var orderedStatusID = ORM_ORD_CUO_CustomerOrder_Status.Query.Search(Connection, Transaction,
            new ORM_ORD_CUO_CustomerOrder_Status.Query
            {
                GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(ECustomerOrderStatus.Ordered),
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).SingleOrDefault().ORD_CUO_CustomerOrder_StatusID;

            #endregion

            #region Get All OrganizationalUnits

            var organizationalUnits = ORM_CMN_BPT_CTM_OrganizationalUnit.Query.Search(Connection, Transaction, new ORM_CMN_BPT_CTM_OrganizationalUnit.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            });
            #endregion

            foreach (var procurement in Parameter.Procurements)
            {

                #region CustomerOrder_Number

                var incrNumberParam = new P_L2NR_GaIINfUA_1454()
                {
                    GlobalStaticMatchingID = EnumUtils.GetEnumDescription(ENumberRangeUsageAreaType.CustomerOrderNumber)
                };
                var customerOrderNumber = cls_Get_and_Increase_IncreasingNumber_for_UsageArea.Invoke(Connection, Transaction, incrNumberParam, securityTicket).Result.Current_IncreasingNumber;

                #endregion

                var cuoHeader = new ORM_ORD_CUO_CustomerOrder_Header();
                cuoHeader.ORD_CUO_CustomerOrder_HeaderID = Guid.NewGuid();
                cuoHeader.ProcurementOrderITL = procurement.ProcurementHeaderInfo.ProcurementOrderInfo.ITL;
                cuoHeader.Current_CustomerOrderStatus_RefID = orderedStatusID;
                cuoHeader.CustomerOrder_Number = customerOrderNumber;
                cuoHeader.CustomerOrder_Date = DateTime.Now;
                cuoHeader.OrderingCustomer_BusinessParticipant_RefID = Parameter.CustomerBusinessParticipantID;
                cuoHeader.CreatedBy_BusinessParticipant_RefID = Parameter.CustomerBusinessParticipantID;
                cuoHeader.CanceledBy_BusinessParticipant_RefID = Guid.Empty;
                cuoHeader.CustomerOrder_Currency_RefID = Guid.Empty;
                cuoHeader.TotalValue_BeforeTax = 0;
                cuoHeader.IsCustomerOrderFinalized = false;
                cuoHeader.DeliveryDeadline = new DateTime();
                cuoHeader.IsPartialShippingAllowed = true;
                cuoHeader.Tenant_RefID = securityTicket.TenantID;
                cuoHeader.Creation_Timestamp = DateTime.Now;
                cuoHeader.Save(Connection, Transaction);

                #region CustomerOrderStatusHistory

                var statusHistory = new ORM_ORD_CUO_CustomerOrder_StatusHistory()
                {
                    ORD_CUO_CustomerOrder_StatusHistoryID = Guid.NewGuid(),
                    CustomerOrder_Header_RefID = cuoHeader.ORD_CUO_CustomerOrder_HeaderID,
                    CustomerOrder_Status_RefID = orderedStatusID,
                    StatusHistoryComment = "",
                    PerformedBy_BusinessParticipant_RefID = Parameter.CustomerBusinessParticipantID,
                    Creation_Timestamp = DateTime.Now,
                    Tenant_RefID = securityTicket.TenantID
                };

                statusHistory.Save(Connection, Transaction);

                #endregion

                var count = 1;
                decimal ammount = 0;

                foreach (var position in procurement.ProcurementPositions)
                {
                    #region FindArticle

                    var product = ORM_CMN_PRO_Product.Query.Search(Connection, Transaction,
                        new ORM_CMN_PRO_Product.Query()
                        {
                            ProductITL = position.Product.ProductITL,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID,
                            IsProductAvailableForOrdering = true
                        }).Single();

                    var packageInfo = ORM_CMN_PRO_PAC_PackageInfo.Query.Search(Connection, Transaction,
                        new ORM_CMN_PRO_PAC_PackageInfo.Query()
                        {
                            CMN_PRO_PAC_PackageInfoID = product.PackageInfo_RefID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        }).SingleOrDefault();

                    #endregion

                    #region Find Price

                    decimal priceAmount = 0;

                    if (position.Product.SourceCatalogITL == EnumUtils.GetEnumDescription(EPublicCatalogs.ABDA))
                    {
                        var abdaCatalogSubscription = ORM_CMN_PRO_SubscribedCatalog.Query.Search(Connection, Transaction,
                            new ORM_CMN_PRO_SubscribedCatalog.Query()
                            {
                                CatalogCodeITL = EnumUtils.GetEnumDescription(EPublicCatalogs.ABDA),
                                Tenant_RefID = securityTicket.TenantID,
                                IsDeleted = false
                            }
                        ).SingleOrDefault();

                        var price = ORM_CMN_SLS_Price.Query.Search(Connection, Transaction, new ORM_CMN_SLS_Price.Query()
                        {
                            CMN_PRO_Product_RefID = product.CMN_PRO_ProductID,
                            PricelistRelease_RefID = abdaCatalogSubscription.SubscribedCatalog_PricelistRelease_RefID,
                            IsDeleted = false
                        }).Single();

                        priceAmount = price.PriceAmount;
                    }
                    else
                    {
                        var catalog = ORM_CMN_PRO_Catalog.Query.Search(Connection, Transaction,
                        new ORM_CMN_PRO_Catalog.Query()
                        {
                            CatalogCodeITL = position.Product.SourceCatalogITL,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID

                        }).Single();

                        var lastPublishedRevision = ORM_CMN_PRO_Catalog_Revision.Query.Search(Connection, Transaction,
                            new ORM_CMN_PRO_Catalog_Revision.Query()
                            {
                                CMN_PRO_Catalog_RefID = catalog.CMN_PRO_CatalogID,
                                IsDeleted = false,
                                Tenant_RefID = securityTicket.TenantID,
                            }).Where(j => j.PublishedOn_Date != new DateTime()).OrderBy(i => i.RevisionNumber).Last();

                        var price = ORM_CMN_SLS_Price.Query.Search(Connection, Transaction,
                            new ORM_CMN_SLS_Price.Query()
                            {
                                CMN_PRO_Product_RefID = product.CMN_PRO_ProductID,
                                PricelistRelease_RefID = lastPublishedRevision.Default_PricelistRelease_RefID,
                                CMN_Currency_RefID = catalog.Catalog_Currency_RefID,
                                IsDeleted = false,
                                Tenant_RefID = securityTicket.TenantID

                            }).Single();

                        priceAmount = price.PriceAmount;
                    }

                    #endregion

                    var cuoPosition = new ORM_ORD_CUO_CustomerOrder_Position();
                    cuoPosition.ORD_CUO_CustomerOrder_PositionID = Guid.NewGuid();
                    cuoPosition.CustomerOrder_Header_RefID = cuoHeader.ORD_CUO_CustomerOrder_HeaderID;
                    cuoPosition.Position_OrdinalNumber = count++;
                    cuoPosition.Position_Quantity = position.TotalOrderQuantity;
                    cuoPosition.Position_ValuePerUnit = priceAmount;
                    cuoPosition.Position_ValueTotal = priceAmount * (decimal)position.TotalOrderQuantity;
                    cuoPosition.Position_Comment = String.Empty;
                    cuoPosition.Position_Unit_RefID = packageInfo.PackageContent_MeasuredInUnit_RefID;
                    cuoPosition.Position_RequestedDateOfDelivery = new DateTime();
                    cuoPosition.CMN_PRO_Product_RefID = product.CMN_PRO_ProductID;
                    cuoPosition.CMN_PRO_Product_Release_RefID = Guid.Empty;
                    cuoPosition.CMN_PRO_Product_Variant_RefID = Guid.Empty;
                    cuoPosition.IsProductReplacementAllowed = position.Product.IsProductReplacementAllowed;

                    cuoPosition.Tenant_RefID = securityTicket.TenantID;
                    cuoPosition.Creation_Timestamp = DateTime.Now;
                    cuoPosition.Save(Connection, Transaction);

                    #region Product 2 OrganizationalUnit

                    foreach (var item in position.TargetOrgUnitInfo)
                    {
                        var orgUnit = organizationalUnits.Where(i => i.CustomerTenant_OfficeITL == item.OfficeITL).Single();

                        var assignement = new ORM_ORD_CUO_Position_CustomerOrganizationalUnitDistribution()
                        {
                            ORD_CUO_Position_CustomerOrganizationalUnitDistributionID = Guid.NewGuid(),
                            Quantity = item.SubQuantity,
                            CMN_BPT_CTM_OrganizationalUnit_RefID = orgUnit.CMN_BPT_CTM_OrganizationalUnitID,
                            ORD_CUO_CustomerOrder_Position_RefID = cuoPosition.ORD_CUO_CustomerOrder_PositionID,
                            Creation_Timestamp = DateTime.Now,
                            Tenant_RefID = securityTicket.TenantID
                        };

                        assignement.Save(Connection, Transaction);

                    }

                    #endregion

                    ammount += cuoPosition.Position_ValueTotal;
                }

                #region Create comments

                if (procurement.ProcurementComments != null)
                {

                    foreach (var item in procurement.ProcurementComments)
                    {
                        var orgUnit = organizationalUnits.Where(i => i.CustomerTenant_OfficeITL == item.OfficeITL).Single();

                        var assignement = new ORM_ORD_CUO_CustomerOrder_Note()
                        {
                            ORD_CUO_CustomerOrder_NoteID = Guid.NewGuid(),
                            CustomerOrder_Header_RefID = cuoHeader.ORD_CUO_CustomerOrder_HeaderID,
                            CustomerOrder_Position_RefID = Guid.Empty,
                            CMN_BPT_CTM_OrganizationalUnit_RefID = orgUnit.CMN_BPT_CTM_OrganizationalUnitID,
                            Title = item.Title,
                            Comment = item.Content,
                            NotePublishDate = item.PublilshDate,
                            SequenceOrderNumber = item.SequenceNumber,
                            Creation_Timestamp = DateTime.Now,
                            Tenant_RefID = securityTicket.TenantID
                        };

                        assignement.Save(Connection, Transaction);
                    }
                }

                #endregion

                cuoHeader.TotalValue_BeforeTax = ammount;
                cuoHeader.Save(Connection, Transaction);

                result.Add(cuoHeader.ORD_CUO_CustomerOrder_HeaderID);
            }

            returnValue.Result = result.ToArray();
            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guids Invoke(string ConnectionString,P_L5CO_CCOaMR_1102 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guids Invoke(DbConnection Connection,P_L5CO_CCOaMR_1102 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guids Invoke(DbConnection Connection, DbTransaction Transaction,P_L5CO_CCOaMR_1102 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guids Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5CO_CCOaMR_1102 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Guids functionReturn = new FR_Guids();
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

				throw new Exception("Exception occured in method cls_Create_CustomerOrder_after_MessageReceive",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5CO_CCOaMR_1102 for attribute P_L5CO_CCOaMR_1102
		[DataContract]
		public class P_L5CO_CCOaMR_1102 
		{
			//Standard type parameters
			[DataMember]
			public Guid CustomerBusinessParticipantID { get; set; } 
			[DataMember]
			public Procurement[] Procurements { get; set; } 
			[DataMember]
			public ProcurementComment[] ProcurementComments { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guids cls_Create_CustomerOrder_after_MessageReceive(,P_L5CO_CCOaMR_1102 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guids invocationResult = cls_Create_CustomerOrder_after_MessageReceive.Invoke(connectionString,P_L5CO_CCOaMR_1102 Parameter,securityTicket);
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
var parameter = new CL5_APOBackoffice_CustomerOrder.Complex.Manipulation.P_L5CO_CCOaMR_1102();
parameter.CustomerBusinessParticipantID = ...;
parameter.Procurements = ...;
parameter.ProcurementComments = ...;

*/
