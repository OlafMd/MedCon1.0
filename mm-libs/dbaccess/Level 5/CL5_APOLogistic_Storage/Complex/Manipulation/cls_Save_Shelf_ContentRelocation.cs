/* 
 * Generated on 5/16/2014 12:37:38 PM
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
using CL1_LOG_WRH;
using CL1_LOG;
using CL3_Warehouse.Complex.Manipulation;

namespace CL5_APOLogistic_Storage.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Shelf_ContentRelocation.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Shelf_ContentRelocation
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Bool Execute(DbConnection Connection,DbTransaction Transaction,P_L5SG_SSCR_1048 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Bool();
			//Put your code here

            foreach (var adjustment in Parameter.Adjustments)
            {                
                var currentShelfContetnAdjustment = new ORM_LOG_WRH_Shelf_ContentAdjustment();
                var currentshelfContent = new ORM_LOG_WRH_Shelf_Content();
                var destinationShelfContent = new ORM_LOG_WRH_Shelf_Content();
                var destinationShelf = new ORM_LOG_WRH_Shelf();

                currentshelfContent.Load(Connection, Transaction, adjustment.ShelfContentID);  
                
                currentShelfContetnAdjustment = ORM_LOG_WRH_Shelf_ContentAdjustment.Query.Search(
                    Connection, 
                    Transaction, 
                    new ORM_LOG_WRH_Shelf_ContentAdjustment.Query() 
                    {
                        ShelfContent_RefID = currentshelfContent.LOG_WRH_Shelf_ContentID,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).FirstOrDefault();

                destinationShelfContent.Tenant_RefID = securityTicket.TenantID;
                destinationShelfContent.Shelf_RefID = adjustment.DestinationShelf;                
                destinationShelfContent.Product_RefID = adjustment.ProductID;
                destinationShelfContent.LOG_WRH_Shelf_ContentID = Guid.NewGuid();
                var destinationShelfContentID = new FR_Guid(destinationShelfContent.Save(Connection, Transaction),
                    destinationShelfContent.LOG_WRH_Shelf_ContentID).Result;

                var destinationShelfContentTrackingInstance = new ORM_LOG_ProductTrackingInstance();
                var sourceShelfContentTrackingInstance = new ORM_LOG_ProductTrackingInstance();

                if (adjustment.TrackingInstanceID != null && adjustment.TrackingInstanceID != Guid.Empty)
                {                    
                    sourceShelfContentTrackingInstance.Load(Connection, Transaction, adjustment.TrackingInstanceID);         
           
                    destinationShelfContentTrackingInstance.ExpirationDate = sourceShelfContentTrackingInstance.ExpirationDate;
                    destinationShelfContentTrackingInstance.BatchNumber = sourceShelfContentTrackingInstance.BatchNumber;
                    destinationShelfContentTrackingInstance.Tenant_RefID = securityTicket.TenantID;
                    destinationShelfContentTrackingInstance.TrackingCode = String.Empty;
                    destinationShelfContentTrackingInstance.CMN_PRO_Product_RefID = adjustment.ProductID;
                    destinationShelfContentTrackingInstance.LOG_ProductTrackingInstanceID = Guid.NewGuid();
                    var destinationShelfContentTrackingInstanceID = new FR_Guid(destinationShelfContentTrackingInstance.Save(Connection, Transaction),
                        destinationShelfContentTrackingInstance.LOG_ProductTrackingInstanceID).Result;

                    var historyEntry = new ORM_LOG_ProductTrackingInstance_HistoryEntry();
                    historyEntry.LOG_ProductTrackingInstance_HistoryEntryID = Guid.NewGuid();
                    historyEntry.ProductTrackingInstance_RefID = destinationShelfContentTrackingInstanceID;
                    historyEntry.Tenant_RefID = securityTicket.TenantID;
                    historyEntry.HistoryEntry_Text = "Transfered from other shelf content.";
                    historyEntry.Save(Connection, Transaction);

                    var assignment = new ORM_LOG_WRH_ShelfContent_2_TrackingInstance();
                    assignment.LOG_ProductTrackingInstance_RefID = destinationShelfContentTrackingInstanceID;
                    assignment.LOG_WRH_Shelf_Content_RefID = destinationShelfContentID;
                    assignment.Tenant_RefID = securityTicket.TenantID;
                    assignment.AssignmentID = Guid.NewGuid();
                    var savedAssignment = new FR_Guid(assignment.Save(Connection, Transaction), assignment.AssignmentID);
                }
                else
                {                                     
                    destinationShelfContentTrackingInstance.Tenant_RefID = securityTicket.TenantID;
                    destinationShelfContentTrackingInstance.CMN_PRO_Product_RefID = adjustment.ProductID;
                    destinationShelfContentTrackingInstance.LOG_ProductTrackingInstanceID = Guid.NewGuid();
                    var destinationShelfContentTrackingInstanceID = new FR_Guid(destinationShelfContentTrackingInstance.Save(Connection, Transaction),
                        destinationShelfContentTrackingInstance.LOG_ProductTrackingInstanceID).Result;

                    var historyEntry = new ORM_LOG_ProductTrackingInstance_HistoryEntry();
                    historyEntry.LOG_ProductTrackingInstance_HistoryEntryID = Guid.NewGuid();
                    historyEntry.ProductTrackingInstance_RefID = destinationShelfContentTrackingInstanceID;
                    historyEntry.Tenant_RefID = securityTicket.TenantID;
                    historyEntry.HistoryEntry_Text = "Transfered from other shelf content.";
                    historyEntry.Save(Connection, Transaction);
                }

                var sourceAdjustmentSaveParameter = new P_L3WH_SSCA_1732();

                var adjustmentsList = new List<P_L3WH_SSCA_1732a>();

                var sourceAdjustment = new P_L3WH_SSCA_1732a();
                sourceAdjustment.AdjustedQuantity = currentshelfContent.Quantity_Current - adjustment.AdjustedQuantity;
                sourceAdjustment.ProductID = adjustment.ProductID;
                sourceAdjustment.ShelfContentID = adjustment.ShelfContentID;
                sourceAdjustment.TrackingInstanceID = sourceShelfContentTrackingInstance.LOG_ProductTrackingInstanceID;
                sourceAdjustment.IsManualCorrection = true;
                sourceAdjustment.IfManualCorrection_InventoryChangeReason_RefID = Guid.Empty;
                sourceAdjustment.IsRelocation = true;
                sourceAdjustment.RelocationAdjustmentID = Guid.NewGuid();

                var destinationAdjustment = new P_L3WH_SSCA_1732a();
                destinationAdjustment.AdjustedQuantity = destinationShelfContent.Quantity_Current + adjustment.AdjustedQuantity;
                destinationAdjustment.IsManualCorrection = true;
                destinationAdjustment.ProductID = adjustment.ProductID;
                destinationAdjustment.ShelfContentID = destinationShelfContent.LOG_WRH_Shelf_ContentID;
                destinationAdjustment.TrackingInstanceID = destinationShelfContentTrackingInstance.LOG_ProductTrackingInstanceID;
                destinationAdjustment.IfManualCorrection_InventoryChangeReason_RefID = Guid.Empty;
                destinationAdjustment.IsRelocation = true;
                destinationAdjustment.RelocationAdjustmentID = Guid.NewGuid();

                sourceAdjustment.IfRelocation_CorrespondingAdjustment_RefID = destinationAdjustment.RelocationAdjustmentID;
                destinationAdjustment.IfRelocation_CorrespondingAdjustment_RefID = sourceAdjustment.RelocationAdjustmentID;

                adjustmentsList.Add(sourceAdjustment);
                adjustmentsList.Add(destinationAdjustment);

                sourceAdjustmentSaveParameter.Adjustments = adjustmentsList.ToArray();
                
                var IsAdjustmentSaved = cls_Save_Shelf_ContentAdjustments.Invoke(Connection, Transaction, sourceAdjustmentSaveParameter, securityTicket).Result;            
            }            

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Bool Invoke(string ConnectionString,P_L5SG_SSCR_1048 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection,P_L5SG_SSCR_1048 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction,P_L5SG_SSCR_1048 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5SG_SSCR_1048 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Shelf_ContentRelocation",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5SG_SSCR_1048 for attribute P_L5SG_SSCR_1048
		[DataContract]
		public class P_L5SG_SSCR_1048 
		{
			[DataMember]
			public P_L5SG_SSCR_1048a[] Adjustments { get; set; }

			//Standard type parameters
		}
		#endregion
		#region SClass P_L5SG_SSCR_1048a for attribute Adjustments
		[DataContract]
		public class P_L5SG_SSCR_1048a 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProductID { get; set; } 
			[DataMember]
			public Guid TrackingInstanceID { get; set; } 
			[DataMember]
			public Guid ShelfContentID { get; set; } 
			[DataMember]
			public Guid InventoryChangeReasonID { get; set; } 
			[DataMember]
			public double AdjustedQuantity { get; set; } 
			[DataMember]
			public Guid DestinationShelf { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Bool cls_Save_Shelf_ContentRelocation(,P_L5SG_SSCR_1048 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Bool invocationResult = cls_Save_Shelf_ContentRelocation.Invoke(connectionString,P_L5SG_SSCR_1048 Parameter,securityTicket);
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
var parameter = new CL5_APOLogistic_Storage.Complex.Manipulation.P_L5SG_SSCR_1048();
parameter.Adjustments = ...;


*/
