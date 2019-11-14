/* 
 * Generated on 7/24/2014 9:00:50 AM
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
using CL3_Warehouse.Complex.Manipulation;
using CL1_LOG_RET;
using CL1_LOG;
using CL3_ShippingOrder.Complex.Manipulation;

namespace CL5_APOLogistic_ReturnShipment.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_ReturnShipment_Header_and_Position.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_ReturnShipment_Header_and_Position
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5RS_SRSHaP_0807_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5RS_SRSHaP_0807 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_L5RS_SRSHaP_0807_Array();
            var results = new List<L5RS_SRSHaP_0807>();
            var contentAdjustments = new List<P_L3WH_SSCA_1732a>();
            var deleteReservationsParam = new List<P_L3SO_DARaUSHfPTIL_1159a>();

            foreach (var returnShipment in Parameter.ReturnShipments)
            {
                #region Create New Shipment and ReturnShipment Headers
                var resultHeadersCreation = new FR_L5RS_CSaRSH_0244();
                if (returnShipment.CreateNewHeader)
                {
                    resultHeadersCreation = cls_Create_Shipment_and_ReturnShipment_Header.Invoke(
                        Connection, 
                        Transaction, 
                        returnShipment.ShipmentHeader, 
                        securityTicket);
                    if (resultHeadersCreation.Status != FR_Status.Success)
                    {
                        returnValue.Status = FR_Status.Error_Internal;
                        returnValue.Result = null;
                        return returnValue;
                    }
                }
                #endregion

                #region Create New Shipment and ReturnShipment Positions
                var resultPositionsCreation = new FR_L5RS_CSaRSPfH_0449();
                if (returnShipment.CreateNewHeader)
                {
                    foreach (var position in returnShipment.ShipmentPositions.Positions)
                    {
                        position.ShipmentHeaderID = resultHeadersCreation.Result.ShipmentHeaderID;
                        position.ReturnShipmentHeaderID = resultHeadersCreation.Result.ReturnShipmentHeaderID;

                        #region Fetch ReturnPolicyID if needed
                        if (position.ReturnPolicyId == Guid.Empty)
                        {
                            var returnPolicy = ORM_LOG_RET_ReturnPolicy.Query.Search(Connection, Transaction, 
                                new ORM_LOG_RET_ReturnPolicy.Query()
                                {
                                    IsDeleted = false,
                                    Tenant_RefID = securityTicket.TenantID,
                                    GlobalPropertyMatchingID = position.ReturnPolicyGlobalPropertyMatchingId
                                }).FirstOrDefault();
                            if (returnPolicy != null)
                            {
                                position.ReturnPolicyId = returnPolicy.LOG_RET_ReturnPolicyID;
                            }
                        }
                        #endregion
                    }
                }
                resultPositionsCreation = cls_Create_Shipment_and_ReturnShipment_Positions_for_HeaderID.Invoke(
                    Connection, 
                    Transaction, 
                    returnShipment.ShipmentPositions, 
                    securityTicket);
                if (resultPositionsCreation.Status != FR_Status.Success)
                {
                    returnValue.Status = FR_Status.Error_Internal;
                    returnValue.Result = null;
                    return returnValue;
                }
                #endregion

                #region Create New ContentAdjustments parameter
                
                foreach (var item in returnShipment.ShipmentPositions.Positions)
                {

                    var productTrackingInstance = new ORM_LOG_ProductTrackingInstance();
                    productTrackingInstance.Load(
                        Connection,
                        Transaction,
                        (Guid)item.ProductTrackingInstance);

                    var paramContentAdjustment = new P_L3WH_SSCA_1732a(); 
                    paramContentAdjustment.AdjustedQuantity = productTrackingInstance.CurrentQuantityOnTrackingInstance - item.Quantity;
                    paramContentAdjustment.IsManualCorrection = true;
                    paramContentAdjustment.IfManualCorrection_InventoryChangeReason_RefID = item.ReturnPolicyId;
                    paramContentAdjustment.IsShipmentWithdrawal = true;
                    paramContentAdjustment.IfShipmentWithdrawal_ShipmentPosition_RefID = item.ShipmentPositionID;
                    paramContentAdjustment.ProductID = item.ProductId;
                    paramContentAdjustment.ShelfContentID = item.ShelfContentID;
                    paramContentAdjustment.TrackingInstanceID = item.ProductTrackingInstance ?? Guid.Empty;
                    contentAdjustments.Add(paramContentAdjustment);

                    deleteReservationsParam.Add(new P_L3SO_DARaUSHfPTIL_1159a()
                    {
                        ProductTrackingInstanceID = (Guid)item.ProductTrackingInstance,
                        RemovedQuantityFromTrackingInstance = item.Quantity,
                        CurrentQuantityOnTrackingInstance = productTrackingInstance.CurrentQuantityOnTrackingInstance
                    });
                }

                #endregion

                var result = new L5RS_SRSHaP_0807()
                {
                    ShipmentHeaderID = returnShipment.ShipmentPositions.Positions[0].ShipmentHeaderID,
                    ShipmentHeaderNumber = resultPositionsCreation.Result.ShipmentHeaderNumber,
                    ShipmentHeaderTotalValue = resultPositionsCreation.Result.ShipmentHeaderTotalValue,
                    ReturnShipmentHeaderID = returnShipment.ShipmentPositions.Positions[0].ReturnShipmentHeaderID,
                    ShipmentHeaderSupplierName = resultPositionsCreation.Result.ShipmentHeaderSupplierName,
                    ShipmentPositionIDs = resultPositionsCreation.Result.ShipmentPositionIDs,
                    ReturnShipmentPositionIDs = resultPositionsCreation.Result.ReturnShipmentPositionIDs
                };
                results.Add(result);
            }

            #region ClearReservations 

            var deleteResParam = new P_L3SO_DARaUSHfPTIL_1159()
            {
                TracknigInstances = deleteReservationsParam.ToArray()
            };

            cls_Delete_ActiveReservations_and_UpdateShipmentHeaders_for_ProductTrackingInstanceIDList.Invoke(Connection, Transaction, deleteResParam, securityTicket);

            #endregion

            #region Save ShelfContentAdjustments

            P_L3WH_SSCA_1732 paramContent = new P_L3WH_SSCA_1732();
            paramContent.Adjustments = contentAdjustments.ToArray();

            var resultContentAdjustments = cls_Save_Shelf_ContentAdjustments.Invoke(Connection, Transaction, paramContent, securityTicket);
            if (resultContentAdjustments.Status != FR_Status.Success || resultContentAdjustments.Result == false)
            {
                returnValue.Status = FR_Status.Error_Internal;
                returnValue.Result = null;
                return returnValue;
            }

            #endregion

            returnValue.Status = FR_Status.Success;
            returnValue.Result = results.ToArray();

            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5RS_SRSHaP_0807_Array Invoke(string ConnectionString,P_L5RS_SRSHaP_0807 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5RS_SRSHaP_0807_Array Invoke(DbConnection Connection,P_L5RS_SRSHaP_0807 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5RS_SRSHaP_0807_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5RS_SRSHaP_0807 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5RS_SRSHaP_0807_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5RS_SRSHaP_0807 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5RS_SRSHaP_0807_Array functionReturn = new FR_L5RS_SRSHaP_0807_Array();
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

				throw new Exception("Exception occured in method cls_Save_ReturnShipment_Header_and_Position",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5RS_SRSHaP_0807_Array : FR_Base
	{
		public L5RS_SRSHaP_0807[] Result	{ get; set; } 
		public FR_L5RS_SRSHaP_0807_Array() : base() {}

		public FR_L5RS_SRSHaP_0807_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5RS_SRSHaP_0807 for attribute P_L5RS_SRSHaP_0807
		[DataContract]
		public class P_L5RS_SRSHaP_0807 
		{
			[DataMember]
			public P_L5RS_SRSHaP_0807a[] ReturnShipments { get; set; }

			//Standard type parameters
		}
		#endregion
		#region SClass P_L5RS_SRSHaP_0807a for attribute ReturnShipments
		[DataContract]
		public class P_L5RS_SRSHaP_0807a 
		{
			//Standard type parameters
			[DataMember]
			public P_L5RS_CSaRSH_0244 ShipmentHeader { get; set; } 
			[DataMember]
			public P_L5RS_CSaRSPfH_0449 ShipmentPositions { get; set; } 
			[DataMember]
			public bool CreateNewHeader { get; set; } 

		}
		#endregion
		#region SClass L5RS_SRSHaP_0807 for attribute L5RS_SRSHaP_0807
		[DataContract]
		public class L5RS_SRSHaP_0807 
		{
			//Standard type parameters
			[DataMember]
			public Guid ShipmentHeaderID { get; set; } 
			[DataMember]
			public string ShipmentHeaderNumber { get; set; } 
			[DataMember]
			public decimal ShipmentHeaderTotalValue { get; set; } 
			[DataMember]
			public string ShipmentHeaderSupplierName { get; set; } 
			[DataMember]
			public Guid ReturnShipmentHeaderID { get; set; } 
			[DataMember]
			public Guid[] ShipmentPositionIDs { get; set; } 
			[DataMember]
			public Guid[] ReturnShipmentPositionIDs { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5RS_SRSHaP_0807_Array cls_Save_ReturnShipment_Header_and_Position(,P_L5RS_SRSHaP_0807 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5RS_SRSHaP_0807_Array invocationResult = cls_Save_ReturnShipment_Header_and_Position.Invoke(connectionString,P_L5RS_SRSHaP_0807 Parameter,securityTicket);
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
var parameter = new CL5_APOLogistic_ReturnShipment.Complex.Manipulation.P_L5RS_SRSHaP_0807();
parameter.ReturnShipments = ...;


*/
