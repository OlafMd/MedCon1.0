/* 
 * Generated on 8/1/2014 9:22:22 AM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 * Required Assemblies:
 * System.Runtime.Serialization
 * CSV2Core
 * CSV2Core_MySQL
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using System.Runtime.Serialization;

namespace CL3_Warehouse.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Update_ProductTrackingInstance.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Update_ProductTrackingInstance
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3WH_UPTI_1439 Execute(DbConnection Connection,DbTransaction Transaction,P_L3WH_UPTI_1439 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L3WH_UPTI_1439();
            returnValue.Result = new L3WH_UPTI_1439();
            
			//Put your code here

            List<P_L3WH_SSCA_1732a> contentAdjustments = new List<P_L3WH_SSCA_1732a>();
            List<L3WH_UPTI_1439a> returnVal = new List<L3WH_UPTI_1439a>();

            foreach (var trackingInstance in Parameter.ProductTrackingInstance)
            {
                P_L3WH_SSCA_1732a ca = new P_L3WH_SSCA_1732a();
                L3WH_UPTI_1439a retItem = new L3WH_UPTI_1439a();

                #region TrackingInstance
                var newTrackingInstance = new CL1_LOG.ORM_LOG_ProductTrackingInstance();
                var oldTrackingInstance = new CL1_LOG.ORM_LOG_ProductTrackingInstance();
                oldTrackingInstance.Load(Connection,Transaction, trackingInstance.ProductTrackingInstanceID);
                
                newTrackingInstance.BatchNumber = trackingInstance.BatchNumber;
                newTrackingInstance.ExpirationDate = trackingInstance.ExpirationDate;
                newTrackingInstance.Creation_Timestamp = DateTime.Now;

                newTrackingInstance.OwnedBy_BusinessParticipant_RefID = oldTrackingInstance.OwnedBy_BusinessParticipant_RefID;
                newTrackingInstance.R_FreeQuantity = oldTrackingInstance.R_FreeQuantity;
                newTrackingInstance.R_ReservedQuantity = oldTrackingInstance.R_ReservedQuantity;
                newTrackingInstance.SerialNumber = oldTrackingInstance.SerialNumber;
                newTrackingInstance.Tenant_RefID = securityTicket.TenantID;
                newTrackingInstance.TrackingCode = (oldTrackingInstance.TrackingCode == null) ? String.Empty : oldTrackingInstance.TrackingCode;
                newTrackingInstance.TrackingInstanceTakenFromSourceTrackingInstance_RefID = oldTrackingInstance.TrackingInstanceTakenFromSourceTrackingInstance_RefID;
                newTrackingInstance.CMN_PRO_Product_RefID = oldTrackingInstance.CMN_PRO_Product_RefID;
                newTrackingInstance.CMN_PRO_Product_Release_RefID = oldTrackingInstance.CMN_PRO_Product_Release_RefID;
                newTrackingInstance.CMN_PRO_Product_Variant_RefID = oldTrackingInstance.CMN_PRO_Product_Variant_RefID;
                newTrackingInstance.CurrentQuantityOnTrackingInstance = oldTrackingInstance.CurrentQuantityOnTrackingInstance;
                newTrackingInstance.InitialQuantityOnTrackingInstance = oldTrackingInstance.InitialQuantityOnTrackingInstance;
                newTrackingInstance.IsDeleted = false;

                newTrackingInstance.Save(Connection, Transaction);

                oldTrackingInstance.TrackingCode = (oldTrackingInstance.TrackingCode == null) ? String.Empty : oldTrackingInstance.TrackingCode;
                oldTrackingInstance.IsDeleted = true;
                oldTrackingInstance.Save(Connection, Transaction);
                #endregion

                #region ShelfContent

                CL1_LOG_WRH.ORM_LOG_WRH_Shelf_Content newShelfContent = new CL1_LOG_WRH.ORM_LOG_WRH_Shelf_Content();
                CL1_LOG_WRH.ORM_LOG_WRH_Shelf_Content oldShelfContent = new CL1_LOG_WRH.ORM_LOG_WRH_Shelf_Content();
                oldShelfContent.Load(Connection, Transaction, trackingInstance.ShelfContentID);

                newShelfContent.GlobalPropertyMatchingID = oldShelfContent.GlobalPropertyMatchingID;
                newShelfContent.IntakeIntoInventoryDate = oldShelfContent.IntakeIntoInventoryDate;
                newShelfContent.IsLocked = oldShelfContent.IsLocked;
                newShelfContent.PlacedIntoStock_Date = oldShelfContent.PlacedIntoStock_Date;
                newShelfContent.Product_RefID = oldShelfContent.Product_RefID;
                newShelfContent.Product_Release_RefID = oldShelfContent.Product_Release_RefID;
                newShelfContent.Product_Variant_RefID = oldShelfContent.Product_Variant_RefID;
                newShelfContent.Quantity_Current = oldShelfContent.Quantity_Current;
                newShelfContent.Quantity_Initial = oldShelfContent.Quantity_Initial;
                newShelfContent.R_FreeQuantity = oldShelfContent.R_FreeQuantity;
                newShelfContent.R_ProcurementValue = oldShelfContent.R_ProcurementValue;
                newShelfContent.R_ProcurementValue_Currency_RefID = oldShelfContent.R_ProcurementValue_Currency_RefID;
                newShelfContent.R_ReservedQuantity = oldShelfContent.R_ReservedQuantity;
                newShelfContent.ReceivedAsFulfillmentOf_ProcurementOrderHeader_RefID = oldShelfContent.ReceivedAsFulfillmentOf_ProcurementOrderHeader_RefID;
                newShelfContent.ReceivedAsFulfillmentOf_ProcurementOrderPosition_RefID = oldShelfContent.ReceivedAsFulfillmentOf_ProcurementOrderPosition_RefID;
                newShelfContent.ReceptionDate = oldShelfContent.ReceptionDate;
                newShelfContent.Shelf_RefID = oldShelfContent.Shelf_RefID;
                newShelfContent.Tenant_RefID = securityTicket.TenantID;
                newShelfContent.UsedShelfCapacityAmount = oldShelfContent.UsedShelfCapacityAmount;
                
                newShelfContent.LOG_WRH_Shelf_ContentID = Guid.NewGuid();
                newShelfContent.Creation_Timestamp = DateTime.Now;
                newShelfContent.Save(Connection,Transaction);

                CL1_LOG_WRH.ORM_LOG_WRH_Shelf_Content.Query.SoftDelete(Connection, Transaction, new CL1_LOG_WRH.ORM_LOG_WRH_Shelf_Content.Query()
                {
                    LOG_WRH_Shelf_ContentID = trackingInstance.ShelfContentID,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }); 

                CL1_LOG_WRH.ORM_LOG_WRH_ShelfContent_2_TrackingInstance shelfContent2TrackingInstance = new CL1_LOG_WRH.ORM_LOG_WRH_ShelfContent_2_TrackingInstance();
                shelfContent2TrackingInstance.LOG_ProductTrackingInstance_RefID = newTrackingInstance.LOG_ProductTrackingInstanceID;
                shelfContent2TrackingInstance.LOG_WRH_Shelf_Content_RefID = newShelfContent.LOG_WRH_Shelf_ContentID;
                shelfContent2TrackingInstance.Tenant_RefID = securityTicket.TenantID;
                shelfContent2TrackingInstance.Save(Connection, Transaction);

                var oldsc2ti = CL1_LOG_WRH.ORM_LOG_WRH_ShelfContent_2_TrackingInstance.Query.SoftDelete(Connection, Transaction, new CL1_LOG_WRH.ORM_LOG_WRH_ShelfContent_2_TrackingInstance.Query()
                {
                    LOG_WRH_Shelf_Content_RefID = oldShelfContent.LOG_WRH_Shelf_ContentID,
                    Tenant_RefID = securityTicket.TenantID
                });

                #endregion

                ca.ProductID = newTrackingInstance.CMN_PRO_Product_RefID;
                ca.ShelfContentID = newShelfContent.LOG_WRH_Shelf_ContentID;
                ca.TrackingInstanceID = newTrackingInstance.LOG_ProductTrackingInstanceID;
                ca.AdjustedQuantity = trackingInstance.Quantity;
                contentAdjustments.Add(ca);

                retItem.ProductID = trackingInstance.ProductID;
                retItem.TrackingInstanceID = newTrackingInstance.LOG_ProductTrackingInstanceID;
                retItem.LOG_WRH_Shelf_ContentID = newShelfContent.LOG_WRH_Shelf_ContentID;
                returnVal.Add(retItem);
            }

            P_L3WH_SSCA_1732 param = new P_L3WH_SSCA_1732();
            param.Adjustments = contentAdjustments.ToArray();
            cls_Save_Shelf_ContentAdjustments.Invoke(Connection, Transaction, param, securityTicket);

            returnValue.Result.newTrackingInstance = returnVal.ToArray();

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3WH_UPTI_1439 Invoke(string ConnectionString,P_L3WH_UPTI_1439 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3WH_UPTI_1439 Invoke(DbConnection Connection,P_L3WH_UPTI_1439 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3WH_UPTI_1439 Invoke(DbConnection Connection, DbTransaction Transaction,P_L3WH_UPTI_1439 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3WH_UPTI_1439 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3WH_UPTI_1439 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3WH_UPTI_1439 functionReturn = new FR_L3WH_UPTI_1439();
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

				throw new Exception("Exception occured in method cls_Update_ProductTrackingInstance",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3WH_UPTI_1439 : FR_Base
	{
		public L3WH_UPTI_1439 Result	{ get; set; }

		public FR_L3WH_UPTI_1439() : base() {}

		public FR_L3WH_UPTI_1439(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3WH_UPTI_1439 for attribute P_L3WH_UPTI_1439
		[DataContract]
		public class P_L3WH_UPTI_1439 
		{
			[DataMember]
			public P_L3WH_UPTI_1439a[] ProductTrackingInstance { get; set; }

			//Standard type parameters
		}
		#endregion
		#region SClass P_L3WH_UPTI_1439a for attribute ProductTrackingInstance
		[DataContract]
		public class P_L3WH_UPTI_1439a 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProductTrackingInstanceID { get; set; } 
			[DataMember]
			public String BatchNumber { get; set; } 
			[DataMember]
			public DateTime ExpirationDate { get; set; } 
			[DataMember]
			public Guid ShelfContentID { get; set; } 
			[DataMember]
			public Guid InventoryJob_CountingResultID { get; set; } 
			[DataMember]
			public double Quantity { get; set; } 
			[DataMember]
			public Guid ProductID { get; set; } 

		}
		#endregion
		#region SClass L3WH_UPTI_1439 for attribute L3WH_UPTI_1439
		[DataContract]
		public class L3WH_UPTI_1439 
		{
			[DataMember]
			public L3WH_UPTI_1439a[] newTrackingInstance { get; set; }

			//Standard type parameters
		}
		#endregion
		#region SClass L3WH_UPTI_1439a for attribute newTrackingInstance
		[DataContract]
		public class L3WH_UPTI_1439a 
		{
			//Standard type parameters
			[DataMember]
			public Guid TrackingInstanceID { get; set; } 
			[DataMember]
			public Guid ProductID { get; set; } 
			[DataMember]
			public Guid LOG_WRH_Shelf_ContentID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3WH_UPTI_1439 cls_Update_ProductTrackingInstance(,P_L3WH_UPTI_1439 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3WH_UPTI_1439 invocationResult = cls_Update_ProductTrackingInstance.Invoke(connectionString,P_L3WH_UPTI_1439 Parameter,securityTicket);
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
var parameter = new CL3_Warehouse.Complex.Manipulation.P_L3WH_UPTI_1439();
parameter.ProductTrackingInstance = ...;


*/
