/* 
 * Generated on 7/29/2014 12:35:48 PM
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
using CL5_APOLogistic_Storage.Atomic.Retrieval;
using CL5_APOLogistic_Inventory.Atomic.Manipulation;
using CL3_Articles.Atomic.Retrieval;
using CL3_Warehouse.Complex.Manipulation;
using CL1_LOG;
using CL1_LOG_WRH;

namespace CL5_APOLogistic_Inventory.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_CountingRun_Results.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_CountingRun_Results
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Bool Execute(DbConnection Connection,DbTransaction Transaction,P_L5IN_SCRR_1056 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_Bool();

            
            
            #region save new items
            Boolean proceed = true;
            List<P_L5IN_SCR_1056a> newItemsList = new List<P_L5IN_SCR_1056a>();
            foreach (var item in Parameter.NewItemsData)
            {
                Guid productTrackingInstanceID = Guid.Empty;
                Guid shelfContentID = new Guid();

                P_L5SG_GPfSbP_1109 parameter = new P_L5SG_GPfSbP_1109();
                parameter.BatchNumber = item.BatchNumber;
                parameter.ExparationDate = item.ExpirationDate;
                parameter.ProductID = item.Product_RefID;
                parameter.ShelfID = item.ShelfID;

                var articles = cls_Get_Product_from_Shelf_by_ProductID.Invoke(Connection, Transaction, parameter, securityTicket).Result.ToList();

                if (articles.Count > 0)
                {
                    P_L5IN_SIJPSCaTI_1418 paramSaveInvJob = new P_L5IN_SIJPSCaTI_1418();
                    paramSaveInvJob.InvJobProcessShelfID = item.InvJobProcessShelfID;
                    paramSaveInvJob.ShelfContentID = articles.First().LOG_WRH_Shelf_ContentID ;
                    paramSaveInvJob.ProductTrackingInstanceID = articles.First().LOG_ProductTrackingInstanceID;
                    paramSaveInvJob.ShelfExpectedQuantity = item.ExpectedQuantity;
                    paramSaveInvJob.TrackingInstanceExpectedQuantity = item.ExpectedQuantity;

                    shelfContentID = articles.First().LOG_WRH_Shelf_ContentID;

                    var invJob = cls_Save_InventoryJob_Process_ShelfContent_and_TrackingInstance.Invoke(Connection, Transaction, paramSaveInvJob, securityTicket).Result;
                }
                else
                { 
                    List<Guid> articleIDs = new List<Guid>();
                    articleIDs.Add(item.Product_RefID);
                    P_L3AR_GAfAL_0942 paramArticleData = new P_L3AR_GAfAL_0942();
                    paramArticleData.ProductID_List = articleIDs.ToArray();

                    var articleData = cls_Get_Articles_for_ArticleList.Invoke(Connection, Transaction, paramArticleData, securityTicket).Result.First();
                    if (articleData.IsStorage_BatchNumberMandatory && (item.BatchNumber == string.Empty || item.BatchNumber == null))
                    {
                        proceed = false;
                    }
                    else if (articleData.IsStorage_ExpiryDateMandatory && (item.ExpirationDate == null || item.ExpirationDate == DateTime.MinValue))
                    {
                        proceed = false;
                    }
                    else
                    {
                        P_L3WH_SSCfP_1635 paramShelfContent = new P_L3WH_SSCfP_1635();
                        paramShelfContent.BatchNumber = item.BatchNumber;
                        paramShelfContent.ExpirationDate = item.ExpirationDate;
                        paramShelfContent.ProductID = item.Product_RefID;
                        paramShelfContent.Quantity = item.ExpectedQuantity;
                        paramShelfContent.ShelfID = item.ShelfID;                        

                        var shelfContent = cls_Save_Shelf_Content_for_ProductID.Invoke(Connection, Transaction, paramShelfContent, securityTicket).Result;

                        P_L5IN_SIJPSCaTI_1418 paramSaveInvJob = new P_L5IN_SIJPSCaTI_1418();
                        paramSaveInvJob.InvJobProcessShelfID = item.InvJobProcessShelfID;
                        paramSaveInvJob.ShelfContentID = shelfContent.ShelfContentID;
                        paramSaveInvJob.ProductTrackingInstanceID = shelfContent.TrackingInstanceID;
                        paramSaveInvJob.ShelfExpectedQuantity = item.ExpectedQuantity;
                        paramSaveInvJob.TrackingInstanceExpectedQuantity = item.ExpectedQuantity;

                        shelfContentID = shelfContent.ShelfContentID;

                        productTrackingInstanceID = shelfContent.TrackingInstanceID;

                        var invJob = cls_Save_InventoryJob_Process_ShelfContent_and_TrackingInstance.Invoke(Connection, Transaction, paramSaveInvJob, securityTicket).Result;
                    }
                }

                if (!(item.CountedQuantity == 0 || item.CountedQuantity == null))
                {
                    P_L5IN_SCR_1056a result = new P_L5IN_SCR_1056a();
                    result.Quantity = item.CountedQuantity.Value;
                    result.ShelfContentID = shelfContentID;
                    result.ProductRefID = item.Product_RefID;
                    result.ProcessShelfRefID = item.InvJobProcessShelfID;
                    if (productTrackingInstanceID != Guid.Empty)
                    {
                        result.ProductTrackingInstanceID = productTrackingInstanceID;
                    }
                
                    newItemsList.Add(result);
                }
            }
            #endregion

            #region Edit items

            var editItems = Parameter.Results.Where(x => x.IsEdited == true).ToList();
            List<P_L5IN_SCR_1056a> countingResults = new List<P_L5IN_SCR_1056a>();
            if (editItems.Count > 0)
            {
                List<L3WH_UPTI_1439a> batchNrResultsList = new List<L3WH_UPTI_1439a>();
                List<P_L3WH_UPTI_1439a> param = new List<P_L3WH_UPTI_1439a>();
                foreach (var item in editItems)
                {
                    if (item.ProductTrackingInstanceID == null)
                        continue;

                    //check if batch number has changed
                    var existingTrackingInstance = new ORM_LOG_ProductTrackingInstance();
                    existingTrackingInstance.Load(Connection, Transaction, (Guid)item.ProductTrackingInstanceID);
                    if (existingTrackingInstance.BatchNumber != item.BatchNumber)
                    {
                        //create new tracking instance
                        var newTrackingInstance = new ORM_LOG_ProductTrackingInstance();
                        newTrackingInstance.LOG_ProductTrackingInstanceID = Guid.NewGuid();
                        newTrackingInstance.BatchNumber = item.BatchNumber;
                        newTrackingInstance.ExpirationDate = item.ExpirationDate;
                        newTrackingInstance.CurrentQuantityOnTrackingInstance = item.Quantity;
                        newTrackingInstance.TrackingInstanceTakenFromSourceTrackingInstance_RefID = existingTrackingInstance.TrackingInstanceTakenFromSourceTrackingInstance_RefID;
                        newTrackingInstance.TrackingCode = existingTrackingInstance.TrackingCode;
                        newTrackingInstance.SerialNumber = existingTrackingInstance.SerialNumber;
                        newTrackingInstance.OwnedBy_BusinessParticipant_RefID = existingTrackingInstance.OwnedBy_BusinessParticipant_RefID;
                        newTrackingInstance.CMN_PRO_Product_RefID = existingTrackingInstance.CMN_PRO_Product_RefID;
                        newTrackingInstance.CMN_PRO_Product_Variant_RefID = existingTrackingInstance.CMN_PRO_Product_Variant_RefID;
                        newTrackingInstance.CMN_PRO_Product_Release_RefID = existingTrackingInstance.CMN_PRO_Product_Release_RefID;
                        newTrackingInstance.IsDeleted = false;
                        newTrackingInstance.Tenant_RefID = securityTicket.TenantID;
                        newTrackingInstance.InitialQuantityOnTrackingInstance = existingTrackingInstance.InitialQuantityOnTrackingInstance;
                        newTrackingInstance.R_FreeQuantity = existingTrackingInstance.R_FreeQuantity;
                        newTrackingInstance.R_ReservedQuantity = existingTrackingInstance.R_ReservedQuantity;
                        newTrackingInstance.Save(Connection, Transaction);

                        //delete old and create new shelf content and tracking instance assotiation
                        var existingSCtoTIQuery = new ORM_LOG_WRH_ShelfContent_2_TrackingInstance.Query();
                        existingSCtoTIQuery.LOG_ProductTrackingInstance_RefID = existingTrackingInstance.LOG_ProductTrackingInstanceID;
                        existingSCtoTIQuery.Tenant_RefID = securityTicket.TenantID;
                        existingSCtoTIQuery.IsDeleted = false;
                        var existingSCtoTI = ORM_LOG_WRH_ShelfContent_2_TrackingInstance.Query.Search(Connection, Transaction, existingSCtoTIQuery).FirstOrDefault();

                        existingSCtoTI.IsDeleted = true;
                        existingSCtoTI.Save(Connection, Transaction);

                        var newSCtoTI = new ORM_LOG_WRH_ShelfContent_2_TrackingInstance();
                        newSCtoTI.AssignmentID = Guid.NewGuid();
                        newSCtoTI.LOG_ProductTrackingInstance_RefID = newTrackingInstance.LOG_ProductTrackingInstanceID;
                        newSCtoTI.LOG_WRH_Shelf_Content_RefID = existingSCtoTI.LOG_WRH_Shelf_Content_RefID;
                        newSCtoTI.Tenant_RefID = securityTicket.TenantID;
                        newSCtoTI.Creation_Timestamp = DateTime.Now;
                        newSCtoTI.Save(Connection, Transaction);

                        //delete old and create new content adjustment and tracking instance assotiation and content adjustment
                        var existingCAtoTIQuery = new ORM_LOG_WRH_Shelf_ContentAdjustment_TrackingInstance.Query();
                        existingCAtoTIQuery.LOG_ProductTrackingInstance_RefID = existingTrackingInstance.LOG_ProductTrackingInstanceID;
                        existingCAtoTIQuery.IsDeleted = false;
                        existingCAtoTIQuery.Tenant_RefID = securityTicket.TenantID;
                        var existingCAtoTI = ORM_LOG_WRH_Shelf_ContentAdjustment_TrackingInstance.Query.Search(Connection, Transaction, existingCAtoTIQuery).FirstOrDefault();
                        
                        existingCAtoTI.IsDeleted = true;
                        existingCAtoTI.Save(Connection, Transaction);

                        var existingContentAdjustment = new ORM_LOG_WRH_Shelf_ContentAdjustment();
                        existingContentAdjustment.Load(Connection, Transaction, existingCAtoTI.LOG_WRH_Shelf_ContentAdjustment_RefID);

                        var newContentAdjustment = new ORM_LOG_WRH_Shelf_ContentAdjustment();
                        newContentAdjustment.LOG_WRH_Shelf_ContentAdjustmentID = Guid.NewGuid();
                        newContentAdjustment.ShelfContent_RefID = existingContentAdjustment.ShelfContent_RefID;
                        newContentAdjustment.QuantityChangedAmount = item.Quantity;
                        newContentAdjustment.QuantityChangedDate = DateTime.Now;
                        newContentAdjustment.IsInitialReceipt = false;
                        newContentAdjustment.IsInventoryJobCorrection = existingContentAdjustment.IsInventoryJobCorrection;
                        newContentAdjustment.IfInventoryJobCorrection_InvenoryJobProcess_RefID = existingContentAdjustment.IfInventoryJobCorrection_InvenoryJobProcess_RefID;
                        newContentAdjustment.IsShipmentWithdrawal = existingContentAdjustment.IsShipmentWithdrawal;
                        newContentAdjustment.IfShipmentWithdrawal_ShipmentPosition_RefID = existingContentAdjustment.IfShipmentWithdrawal_ShipmentPosition_RefID;
                        newContentAdjustment.IsManualCorrection = existingContentAdjustment.IsManualCorrection;
                        newContentAdjustment.IfManualCorrection_InventoryChangeReason_RefID = existingContentAdjustment.IfManualCorrection_InventoryChangeReason_RefID;
                        newContentAdjustment.PerformedAt_Date = existingContentAdjustment.PerformedAt_Date;
                        newContentAdjustment.PerformedBy_Account_RefID = existingContentAdjustment.PerformedBy_Account_RefID;
                        newContentAdjustment.ContentAdjustmentComment = existingContentAdjustment.ContentAdjustmentComment;
                        newContentAdjustment.IsBatchNumberOrSerialKeyUpdate = true;
                        newContentAdjustment.IfBatchNumberOrSerialKeyUpdate_CorrespondingAdjustment_RefID = existingContentAdjustment.LOG_WRH_Shelf_ContentAdjustmentID;
                        newContentAdjustment.IsRelocation = false;
                        newContentAdjustment.IfRelocation_CorrespondingAdjustment_RefID = Guid.Empty;
                        newContentAdjustment.Creation_Timestamp = DateTime.Now;
                        newContentAdjustment.Tenant_RefID = securityTicket.TenantID;
                        newContentAdjustment.Save(Connection, Transaction);

                        var newCAtoTI = new ORM_LOG_WRH_Shelf_ContentAdjustment_TrackingInstance();
                        newCAtoTI.LOG_WRH_Shelf_ContentAdjustment_TrackingInstanceID = Guid.NewGuid();
                        newCAtoTI.LOG_ProductTrackingInstance_RefID = newTrackingInstance.LOG_ProductTrackingInstanceID;
                        newCAtoTI.LOG_WRH_Shelf_ContentAdjustment_RefID = newContentAdjustment.LOG_WRH_Shelf_ContentAdjustmentID;
                        newCAtoTI.LOG_WRH_Shelf_ContentAdjustment_TrackingInstanceID = newTrackingInstance.LOG_ProductTrackingInstanceID;
                        newCAtoTI.QuantityChangedAmount = item.Quantity - existingContentAdjustment.QuantityChangedAmount;
                        newCAtoTI.IsDeleted = false;
                        newCAtoTI.Tenant_RefID = securityTicket.TenantID;
                        newCAtoTI.Creation_Timestamp = DateTime.Now;
                        newCAtoTI.Save(Connection, Transaction);

                        item.ProductTrackingInstanceID = newTrackingInstance.LOG_ProductTrackingInstanceID;

                        L3WH_UPTI_1439a batchNrChangedResults = new L3WH_UPTI_1439a();
                        batchNrChangedResults.TrackingInstanceID = newTrackingInstance.LOG_ProductTrackingInstanceID;
                        batchNrChangedResults.ProductID = newTrackingInstance.CMN_PRO_Product_RefID;
                        batchNrChangedResults.LOG_WRH_Shelf_ContentID = newContentAdjustment.ShelfContent_RefID;

                        existingTrackingInstance.IsDeleted = true;
                        existingTrackingInstance.Save(Connection, Transaction);

                        batchNrResultsList.Add(batchNrChangedResults);
                    }
                    else
                    {
                        P_L3WH_UPTI_1439a p = new P_L3WH_UPTI_1439a();
                        p.BatchNumber = item.BatchNumber;
                        p.ExpirationDate = item.ExpirationDate;
                        p.ProductTrackingInstanceID = (Guid)item.ProductTrackingInstanceID;
                        p.ShelfContentID = item.ShelfContentID;
                        p.Quantity = item.Quantity;
                        p.ProductID = item.ProductRefID;
                        param.Add(p);
                    }
                }
                P_L3WH_UPTI_1439 paramUpdateTrackingInstance = new P_L3WH_UPTI_1439();
                paramUpdateTrackingInstance.ProductTrackingInstance = param.ToArray();
                var result = cls_Update_ProductTrackingInstance.Invoke(Connection, Transaction, paramUpdateTrackingInstance, securityTicket).Result;

                List<L3WH_UPTI_1439a> finalList = new List<L3WH_UPTI_1439a>();
                finalList = result.newTrackingInstance.ToList();
                finalList.AddRange(batchNrResultsList);
                result.newTrackingInstance = finalList.ToArray();

                foreach (var item in editItems)
                {
                    if (item.ProductTrackingInstanceID == null)
                        continue;
                    //var oldProcessShelf = new CL1_LOG_WRH_INJ.ORM_LOG_WRH_INJ_InventoryJob_Process_Shelf().Load(Connection, Transaction, item.ProcessShelfRefID);
                    //var newProcessShelf = new CL1_LOG_WRH_INJ.ORM_LOG_WRH_INJ_InventoryJob_Process_Shelf();
                    var oldProcessShelfContent = CL1_LOG_WRH_INJ.ORM_LOG_WRH_INJ_InventoryJob_Process_ShelfContent.Query.Search(Connection, Transaction, new CL1_LOG_WRH_INJ.ORM_LOG_WRH_INJ_InventoryJob_Process_ShelfContent.Query()
                    {
                        LOG_WRH_INJ_InventoryJob_Process_Shelf_RefID = item.ProcessShelfRefID,
                        LOG_WRH_Shelf_Content_RefID = item.ShelfContentID,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).Single();

                    var newProcessShelfContent = new CL1_LOG_WRH_INJ.ORM_LOG_WRH_INJ_InventoryJob_Process_ShelfContent();
                    newProcessShelfContent.Creation_Timestamp = DateTime.Now;
                    newProcessShelfContent.ExpectedQuantityOnShelfContent = oldProcessShelfContent.ExpectedQuantityOnShelfContent;
                    newProcessShelfContent.IsDeleted = false;
                    newProcessShelfContent.LOG_WRH_INJ_InventoryJob_Process_Shelf_RefID = oldProcessShelfContent.LOG_WRH_INJ_InventoryJob_Process_Shelf_RefID;
                    newProcessShelfContent.LOG_WRH_INJ_InventoryJob_Process_ShelfContentID = Guid.NewGuid();
                    newProcessShelfContent.LOG_WRH_Shelf_Content_RefID = result.newTrackingInstance.Where(x => x.ProductID == item.ProductRefID).Single().LOG_WRH_Shelf_ContentID;
                    newProcessShelfContent.Tenant_RefID = securityTicket.TenantID;

                    newProcessShelfContent.Save(Connection, Transaction);
                    
                    oldProcessShelfContent.IsDeleted = true;
                    oldProcessShelfContent.Save(Connection, Transaction);


                    var oldProcessShelfContentTrackingInstance = CL1_LOG_WRH_INJ.ORM_LOG_WRH_INJ_Process_ShelfContents_TrackingInstance.Query.Search(Connection, Transaction, new CL1_LOG_WRH_INJ.ORM_LOG_WRH_INJ_Process_ShelfContents_TrackingInstance.Query()
                    {
                        LOG_WRH_INJ_InventoryJob_Process_ShelfContent_RefID = oldProcessShelfContent.LOG_WRH_INJ_InventoryJob_Process_ShelfContentID,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).Single();

                    var newProcessShelfContentTrackingInstance = new CL1_LOG_WRH_INJ.ORM_LOG_WRH_INJ_Process_ShelfContents_TrackingInstance();
                    newProcessShelfContentTrackingInstance.Creation_Timestamp = DateTime.Now;
                    newProcessShelfContentTrackingInstance.ExpectedQuantityOnTrackingInstance = oldProcessShelfContentTrackingInstance.ExpectedQuantityOnTrackingInstance;
                    newProcessShelfContentTrackingInstance.LOG_ProductTrackingInstance_RefID = result.newTrackingInstance.Where(x => x.ProductID == item.ProductRefID).Single().TrackingInstanceID;
                    newProcessShelfContentTrackingInstance.LOG_WRH_INJ_InventoryJob_Process_ShelfContent_RefID = newProcessShelfContent.LOG_WRH_INJ_InventoryJob_Process_ShelfContentID;
                    newProcessShelfContentTrackingInstance.LOG_WRH_INJ_Process_ShelfContents_TrackingInstanceID = Guid.NewGuid();
                    newProcessShelfContentTrackingInstance.Tenant_RefID = securityTicket.TenantID;

                    newProcessShelfContentTrackingInstance.Save(Connection, Transaction);
                    oldProcessShelfContentTrackingInstance.IsDeleted = true;
                    oldProcessShelfContentTrackingInstance.Save(Connection, Transaction);
                }

                foreach (var item in Parameter.Results.ToList())
                {

                    if (result.newTrackingInstance.Any(x => x.ProductID == item.ProductRefID))
                    {
                        var res = result.newTrackingInstance.Where(x => x.ProductID == item.ProductRefID).Single();
                        item.ProductTrackingInstanceID = res.TrackingInstanceID;
                        item.ShelfContentID = res.LOG_WRH_Shelf_ContentID;
                    }
                    countingResults.Add(item);
                }
            }
            else
            {
                countingResults = Parameter.Results.ToList();
            }

            #endregion
            List<P_L5IN_SCR_1056a> completeList = new List<P_L5IN_SCR_1056a>();
            completeList.AddRange(newItemsList);
            completeList.AddRange(countingResults);
            

            if (proceed)
            {
                var countingRun = CL1_LOG_WRH_INJ.ORM_LOG_WRH_INJ_InventoryJob_CountingRun.Query.Search(Connection, Transaction,
                    new CL1_LOG_WRH_INJ.ORM_LOG_WRH_INJ_InventoryJob_CountingRun.Query
                    {
                        LOG_WRH_INJ_InventoryJob_CountingRunID = Parameter.CountingRunID,
                        IsCounting_Started = true,
                        IsCounting_Completed = false,
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID
                    }).Single();

                var countingResult = new CL1_LOG_WRH_INJ.ORM_LOG_WRH_INJ_InventryJob_CountingResult();
                var countingResultTrackingInstance = new CL1_LOG_WRH_INJ.ORM_LOG_WRH_INJ_CountingResult_TrackingInstance();

                foreach (var item in completeList)
                {
                    bool isTrackingInstance = (item.ProductTrackingInstanceID != Guid.Empty);

                    #region Load or create new Counting Result
                    // try to find counting result for the same ShelfContentID
                    countingResult = CL1_LOG_WRH_INJ.ORM_LOG_WRH_INJ_InventryJob_CountingResult.Query.Search(Connection, Transaction,
                        new CL1_LOG_WRH_INJ.ORM_LOG_WRH_INJ_InventryJob_CountingResult.Query
                        {
                            CountingRun_RefID = Parameter.CountingRunID,
                            Product_RefID = item.ProductRefID,
                            Process_Shelf_RefID = item.ProcessShelfRefID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        }).SingleOrDefault();

                    #region Create new counting result if none is found by ShelfContent_RefID
                    if (countingResult == null)
                    {
                        countingResult = new CL1_LOG_WRH_INJ.ORM_LOG_WRH_INJ_InventryJob_CountingResult
                        {
                            LOG_WRH_INJ_InventoryJob_CountingResultID = Guid.NewGuid(),
                            Creation_Timestamp = DateTime.Now,
                            Tenant_RefID = securityTicket.TenantID,
                            CountedAmount = 0.0,
                            CountingRun_RefID = Parameter.CountingRunID,
                            IsDifferenceToExpectedQuantityFound = false,
                            Product_RefID = item.ProductRefID,
                            Process_Shelf_RefID = item.ProcessShelfRefID,
                        };
                        countingResult.Save(Connection, Transaction);
                    }
                    #endregion
                    #endregion

                    if (isTrackingInstance)
                    {
                        if (item.InventoryJob_CountingResultID == Guid.Empty || item.CountingResult_TrackingInstanceID == Guid.Empty)
                        {
                            countingResultTrackingInstance = new CL1_LOG_WRH_INJ.ORM_LOG_WRH_INJ_CountingResult_TrackingInstance
                            {
                                LOG_WRH_INJ_CountingResult_TrackingInstanceID = Guid.NewGuid(),
                                Creation_Timestamp = DateTime.Now,
                                Tenant_RefID = securityTicket.TenantID,
                                LOG_WRH_INJ_InventoryJob_CountingResult_RefID = countingResult.LOG_WRH_INJ_InventoryJob_CountingResultID,
                                LOG_ProductTrackingInstanceID = item.ProductTrackingInstanceID.Value
                            };
                        }
                        else
                        {
                            countingResultTrackingInstance.Load(Connection, Transaction, item.CountingResult_TrackingInstanceID);
                        }
                        countingResultTrackingInstance.CountedAmount = item.Quantity;
                        countingResultTrackingInstance.Save(Connection, Transaction);

                        var tiResults = CL1_LOG_WRH_INJ.ORM_LOG_WRH_INJ_CountingResult_TrackingInstance.Query.Search(Connection, Transaction,
                            new CL1_LOG_WRH_INJ.ORM_LOG_WRH_INJ_CountingResult_TrackingInstance.Query
                            {
                                LOG_WRH_INJ_InventoryJob_CountingResult_RefID = countingResult.LOG_WRH_INJ_InventoryJob_CountingResultID,
                                IsDeleted = false,
                                Tenant_RefID = securityTicket.TenantID
                            });

                        countingResult.CountedAmount = tiResults.Sum(x => x.CountedAmount);
                        countingResult.Save(Connection, Transaction);
                    }
                }
            }

            returnValue.Result = proceed;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Bool Invoke(string ConnectionString,P_L5IN_SCRR_1056 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection,P_L5IN_SCRR_1056 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction,P_L5IN_SCRR_1056 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5IN_SCRR_1056 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Bool functionReturn = new FR_Bool();
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

				throw new Exception("Exception occured in method cls_Save_CountingRun_Results",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5IN_SCRR_1056 for attribute P_L5IN_SCRR_1056
		[DataContract]
		public class P_L5IN_SCRR_1056 
		{
			[DataMember]
			public P_L5IN_SCR_1056a[] Results { get; set; }
			[DataMember]
			public P_L5IN_SCR_1056b[] NewItemsData { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid InventoryProcessID { get; set; } 
			[DataMember]
			public Guid CountingRunID { get; set; } 

		}
		#endregion
		#region SClass P_L5IN_SCR_1056a for attribute Results
		[DataContract]
		public class P_L5IN_SCR_1056a 
		{
			//Standard type parameters
			[DataMember]
			public Guid CountingResult_TrackingInstanceID { get; set; } 
			[DataMember]
			public Guid InventoryJob_CountingResultID { get; set; } 
			[DataMember]
			public Double Quantity { get; set; } 
			[DataMember]
			public Guid ShelfContentID { get; set; } 
			[DataMember]
			public Guid ProductRefID { get; set; } 
			[DataMember]
			public Guid ProcessShelfRefID { get; set; } 
			[DataMember]
			public Guid? ProductTrackingInstanceID { get; set; } 
			[DataMember]
			public string BatchNumber { get; set; } 
			[DataMember]
			public DateTime ExpirationDate { get; set; } 
			[DataMember]
			public bool IsEdited { get; set; } 

		}
		#endregion
		#region SClass P_L5IN_SCR_1056b for attribute NewItemsData
		[DataContract]
		public class P_L5IN_SCR_1056b 
		{
			//Standard type parameters
			[DataMember]
			public Guid ShelfID { get; set; } 
			[DataMember]
			public Guid Product_RefID { get; set; } 
			[DataMember]
			public string BatchNumber { get; set; } 
			[DataMember]
			public DateTime ExpirationDate { get; set; } 
			[DataMember]
			public Guid InvJobProcessShelfID { get; set; } 
			[DataMember]
			public double ExpectedQuantity { get; set; } 
			[DataMember]
			public double? CountedQuantity { get; set; } 
			[DataMember]
			public Guid ProcessShelfRefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Bool cls_Save_CountingRun_Results(,P_L5IN_SCRR_1056 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Bool invocationResult = cls_Save_CountingRun_Results.Invoke(connectionString,P_L5IN_SCRR_1056 Parameter,securityTicket);
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
var parameter = new CL5_APOLogistic_Inventory.Complex.Manipulation.P_L5IN_SCRR_1056();
parameter.Results = ...;
parameter.NewItemsData = ...;

parameter.InventoryProcessID = ...;
parameter.CountingRunID = ...;

*/
