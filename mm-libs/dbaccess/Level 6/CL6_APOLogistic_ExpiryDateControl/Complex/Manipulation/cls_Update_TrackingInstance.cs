/* 
 * Generated on 8/27/2014 11:28:16 AM
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
using CL1_LOG;
using CL1_LOG_WRH;
using CL3_Warehouse.Complex.Manipulation;

namespace CL6_APOLogistic_ExpiryDateControl.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Update_TrackingInstance.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Update_TrackingInstance
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L6ED_UTI_1307 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_Guid();
            //Put your code here

            foreach (var item in Parameter.ProductTrackingInstance)
            {
                var existingTrackingInstance = new CL1_LOG.ORM_LOG_ProductTrackingInstance();
                existingTrackingInstance.Load(Connection, Transaction, item.ProductTrackingInstanceID);
                if (existingTrackingInstance == null)
                {
                    continue;
                }

                if (existingTrackingInstance.BatchNumber != item.BatchNumber)
                {
                    #region Create new tracking instance
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
                    #endregion

                    #region Delete old and create new shelf content and tracking instance assotiation
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
                    #endregion

                    #region Delete old and create new content adjustment and tracking instance assotiation and content adjustment
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
                    newContentAdjustment.QuantityChangedAmount = 0;
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
                    newCAtoTI.QuantityChangedAmount = 0;
                    newCAtoTI.IsDeleted = false;
                    newCAtoTI.Tenant_RefID = securityTicket.TenantID;
                    newCAtoTI.Creation_Timestamp = DateTime.Now;
                    newCAtoTI.Save(Connection, Transaction);
                    #endregion

                    item.ProductTrackingInstanceID = newTrackingInstance.LOG_ProductTrackingInstanceID;

                    existingTrackingInstance.IsDeleted = true;
                    existingTrackingInstance.Save(Connection, Transaction);
                }
                else
                {
                    existingTrackingInstance.ExpirationDate = item.ExpirationDate;
                    existingTrackingInstance.Save(Connection, Transaction);
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
		public static FR_Guid Invoke(string ConnectionString,P_L6ED_UTI_1307 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L6ED_UTI_1307 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L6ED_UTI_1307 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6ED_UTI_1307 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Update_TrackingInstance",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L6ED_UTI_1307 for attribute P_L6ED_UTI_1307
		[DataContract]
		public class P_L6ED_UTI_1307 
		{
			[DataMember]
			public P_L6ED_UTI_1307a[] ProductTrackingInstance { get; set; }

			//Standard type parameters
		}
		#endregion
		#region SClass P_L6ED_UTI_1307a for attribute ProductTrackingInstance
		[DataContract]
		public class P_L6ED_UTI_1307a 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProductTrackingInstanceID { get; set; } 
			[DataMember]
			public String BatchNumber { get; set; } 
			[DataMember]
			public DateTime ExpirationDate { get; set; } 
			[DataMember]
			public double Quantity { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Update_TrackingInstance(,P_L6ED_UTI_1307 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Update_TrackingInstance.Invoke(connectionString,P_L6ED_UTI_1307 Parameter,securityTicket);
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
var parameter = new CL6_APOLogistic_ExpiryDateControl.Complex.Manipulation.P_L6ED_UTI_1307();
parameter.ProductTrackingInstance = ...;


*/
