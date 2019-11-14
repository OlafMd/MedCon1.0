/* 
 * Generated on 10/24/2014 2:26:30 PM
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
using CL3_Warehouse.Complex.Manipulation;
using CL3_ShippingOrder.Complex.Manipulation;

namespace CL5_APOLogistic_ReturnShipment.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Create_ReturnShipment.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Create_ReturnShipment
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5RS_CRSH_1332_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5RS_CRSH_1332 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_L5RS_CRSH_1332_Array();
            var results = new List<L5RS_CRSH_1332>();

            var contentAdjustments = new List<P_L3WH_SSCA_1732a>();
            var deleteReservationsParam = new List<P_L3SO_DARaUSHfPTIL_1159a>();

            foreach (var inputHeader in Parameter.ReturnShipmentHeaders)
            {
                #region Create New Shipment and ReturnShipment Headers

                var createShipmentandReturnShipmentHeaderParam = new P_L5RS_CSaRSH_0244()
                {
                    SupplierID = inputHeader.SupplierID
                };

                var resultHeadersCreation = cls_Create_Shipment_and_ReturnShipment_Header.Invoke(Connection, Transaction, createShipmentandReturnShipmentHeaderParam, securityTicket);
                if (resultHeadersCreation.Status != FR_Status.Success)
                {
                    returnValue.Status = FR_Status.Error_Internal;
                    returnValue.Result = null;
                    return returnValue;
                }

                #endregion

                #region Create New Shipment and ReturnShipment Positions

                var positionsParam = new List<P_L5RS_CRSP_1405a>();

                foreach (var inputPosition in inputHeader.ReturnShipmentPositions)
                {
                    var position = new P_L5RS_CRSP_1405a();
                    position.ShipmentHeaderID = resultHeadersCreation.Result.ShipmentHeaderID;
                    position.ReturnShipmentHeaderID = resultHeadersCreation.Result.ReturnShipmentHeaderID;

                    position.ProductID = inputPosition.ProductID;
                    position.Quantity = inputPosition.Quantity;;
                    position.PricePerUnit = inputPosition.PricePerUnit;
                    position.ReturnPolicyID = inputPosition.ReturnPolicyID;
                    position.ReceiptPositionID = inputPosition.ReceiptPositionID;

                    positionsParam.Add(position);
                }

                var createPositionsParam = new P_L5RS_CRSP_1405()
                {
                    Positions = positionsParam.ToArray()
                };

                var resultPositionsCreation = cls_Create_ReturnShipment_Positions.Invoke(Connection, Transaction, createPositionsParam,securityTicket);
                if (resultPositionsCreation.Status != FR_Status.Success)
                {
                    returnValue.Status = FR_Status.Error_Internal;
                    returnValue.Result = null;
                    return returnValue;
                }

                #endregion

                #region Create New ContentAdjustments and DeleteReservatins parameters

                foreach (var inputPosition in inputHeader.ReturnShipmentPositions)
                {
                    var productTrackingInstance = new ORM_LOG_ProductTrackingInstance();
                    productTrackingInstance.Load(Connection, Transaction, inputPosition.ProductTrackingInstanceID);

                    var savedPosition = resultPositionsCreation.Result.Positions.Single(i=>i.ProductID == inputPosition.ProductID && i.ReceiptPositionID == inputPosition.ReceiptPositionID );

                    var paramContentAdjustment = new P_L3WH_SSCA_1732a();
                    paramContentAdjustment.AdjustedQuantity = productTrackingInstance.CurrentQuantityOnTrackingInstance - inputPosition.Quantity;
                    paramContentAdjustment.IsManualCorrection = true;
                    paramContentAdjustment.IfManualCorrection_InventoryChangeReason_RefID = inputPosition.ReturnPolicyID;
                    paramContentAdjustment.IsShipmentWithdrawal = true;
                    paramContentAdjustment.IfShipmentWithdrawal_ShipmentPosition_RefID = savedPosition.ShipmentPositionID;
                    paramContentAdjustment.ProductID = inputPosition.ProductID;
                    paramContentAdjustment.ShelfContentID = inputPosition.ShelfContentID;
                    paramContentAdjustment.TrackingInstanceID = inputPosition.ProductTrackingInstanceID;
                    contentAdjustments.Add(paramContentAdjustment);

                    deleteReservationsParam.Add(new P_L3SO_DARaUSHfPTIL_1159a()
                    {
                        ProductTrackingInstanceID = inputPosition.ProductTrackingInstanceID,
                        RemovedQuantityFromTrackingInstance = inputPosition.Quantity,
                        CurrentQuantityOnTrackingInstance = productTrackingInstance.CurrentQuantityOnTrackingInstance
                    });
                }

                #endregion

                var result = new L5RS_CRSH_1332()
                {
                    ShipmentHeaderNumber = resultPositionsCreation.Result.ShipmentHeaderNumber,
                    ShipmentHeaderTotalValue = resultPositionsCreation.Result.ShipmentHeaderTotalValue,
                    ShipmentHeaderSupplierName = resultPositionsCreation.Result.ShipmentHeaderSupplierName
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
		public static FR_L5RS_CRSH_1332_Array Invoke(string ConnectionString,P_L5RS_CRSH_1332 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5RS_CRSH_1332_Array Invoke(DbConnection Connection,P_L5RS_CRSH_1332 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5RS_CRSH_1332_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5RS_CRSH_1332 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5RS_CRSH_1332_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5RS_CRSH_1332 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5RS_CRSH_1332_Array functionReturn = new FR_L5RS_CRSH_1332_Array();
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

				throw new Exception("Exception occured in method cls_Create_ReturnShipment",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5RS_CRSH_1332_Array : FR_Base
	{
		public L5RS_CRSH_1332[] Result	{ get; set; } 
		public FR_L5RS_CRSH_1332_Array() : base() {}

		public FR_L5RS_CRSH_1332_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5RS_CRSH_1332 for attribute P_L5RS_CRSH_1332
		[DataContract]
		public class P_L5RS_CRSH_1332 
		{
			[DataMember]
			public P_L5RS_CRSH_1332a[] ReturnShipmentHeaders { get; set; }

			//Standard type parameters
		}
		#endregion
		#region SClass P_L5RS_CRSH_1332a for attribute ReturnShipmentHeaders
		[DataContract]
		public class P_L5RS_CRSH_1332a 
		{
			[DataMember]
			public P_L5RS_CRSH_1332b[] ReturnShipmentPositions { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid SupplierID { get; set; } 

		}
		#endregion
		#region SClass P_L5RS_CRSH_1332b for attribute ReturnShipmentPositions
		[DataContract]
		public class P_L5RS_CRSH_1332b 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProductID { get; set; } 
			[DataMember]
			public int Quantity { get; set; } 
			[DataMember]
			public Decimal PricePerUnit { get; set; } 
			[DataMember]
			public Guid ReceiptPositionID { get; set; } 
			[DataMember]
			public Guid ShelfContentID { get; set; } 
			[DataMember]
			public Guid ProductTrackingInstanceID { get; set; } 
			[DataMember]
			public Guid ReturnPolicyID { get; set; } 

		}
		#endregion
		#region SClass L5RS_CRSH_1332 for attribute L5RS_CRSH_1332
		[DataContract]
		public class L5RS_CRSH_1332 
		{
			//Standard type parameters
			[DataMember]
			public string ShipmentHeaderNumber { get; set; } 
			[DataMember]
			public decimal ShipmentHeaderTotalValue { get; set; } 
			[DataMember]
			public string ShipmentHeaderSupplierName { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5RS_CRSH_1332_Array cls_Create_ReturnShipment(,P_L5RS_CRSH_1332 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5RS_CRSH_1332_Array invocationResult = cls_Create_ReturnShipment.Invoke(connectionString,P_L5RS_CRSH_1332 Parameter,securityTicket);
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
var parameter = new CL5_APOLogistic_ReturnShipment.Complex.Manipulation.P_L5RS_CRSH_1332();
parameter.ReturnShipmentHeaders = ...;


*/
