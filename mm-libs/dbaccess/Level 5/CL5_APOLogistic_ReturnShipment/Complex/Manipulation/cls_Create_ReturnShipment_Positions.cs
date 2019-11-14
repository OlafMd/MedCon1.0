/* 
 * Generated on 10/24/2014 2:36:43 PM
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
using CL1_CMN_BPT;
using CL1_LOG_SHP;

namespace CL5_APOLogistic_ReturnShipment.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Create_ReturnShipment_Positions.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Create_ReturnShipment_Positions
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5RS_CRSP_1405 Execute(DbConnection Connection,DbTransaction Transaction,P_L5RS_CRSP_1405 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5RS_CRSP_1405();

            returnValue.Result = new L5RS_CRSP_1405();
            FR_Base resultHeader, resultPosition, resultReturnPosition;

            if (Parameter.Positions.Count() <= 0)
            {
                returnValue.Status = FR_Status.Success;
                returnValue.Result = null;
                return returnValue;
            }

            #region Load Shipment Header and calculate Total Price
            decimal totalValueWithoutTax = 0;

            #region Load Shipment Header
            var shipmentHeader = new ORM_LOG_SHP_Shipment_Header();
            var result = shipmentHeader.Load(Connection, Transaction, Parameter.Positions[0].ShipmentHeaderID);
            if (result.Status != FR_Status.Success)
            {
                returnValue.Status = FR_Status.Error_Internal;
                returnValue.Result = null;
                return returnValue;
            }
            #endregion

            #region Load Shipment Header Positions And Calculate Total Value
            var shipmentPositions = ORM_LOG_SHP_Shipment_Position.Query.Search(
                Connection,
                Transaction,
                new ORM_LOG_SHP_Shipment_Position.Query()
                {
                    LOG_SHP_Shipment_Header_RefID = shipmentHeader.LOG_SHP_Shipment_HeaderID,
                    Tenant_RefID = securityTicket.TenantID
                }).ToList();
            foreach (var position in shipmentPositions)
            {
                totalValueWithoutTax += position.ShipmentPosition_ValueWithoutTax;
            }
            #endregion

            shipmentHeader.ShipmentHeader_ValueWithoutTax = totalValueWithoutTax;
            #endregion

            var savedPositions = new List<L5RS_CRSP_1405a>();
            foreach (var position in Parameter.Positions)
            {
                #region Create Shipment Position Object
                var newShipmentPositionObject = new ORM_LOG_SHP_Shipment_Position();
                newShipmentPositionObject.CMN_PRO_Product_RefID = position.ProductID;
                newShipmentPositionObject.Creation_Timestamp = DateTime.Now;
                newShipmentPositionObject.LOG_SHP_Shipment_Header_RefID = position.ShipmentHeaderID;
                newShipmentPositionObject.LOG_SHP_Shipment_PositionID = Guid.NewGuid();
                newShipmentPositionObject.QuantityToShip = position.Quantity;
                newShipmentPositionObject.ShipmentPosition_ValueWithoutTax = position.PricePerUnit * position.Quantity;
                newShipmentPositionObject.ShipmentPosition_PricePerUnitValueWithoutTax = position.PricePerUnit;
                newShipmentPositionObject.Tenant_RefID = securityTicket.TenantID;
                shipmentHeader.ShipmentHeader_ValueWithoutTax += newShipmentPositionObject.ShipmentPosition_ValueWithoutTax;
                #endregion

                #region Create ReturnShipment Position Object
                var newReturnShipmentPositionObject = new ORM_LOG_SHP_ReturnShipment_Position();
                newReturnShipmentPositionObject.Creation_Timestamp = DateTime.Now;
                newReturnShipmentPositionObject.Ext_Shipment_Position_RefID = newShipmentPositionObject.LOG_SHP_Shipment_PositionID;
                newReturnShipmentPositionObject.LOG_SHP_ReturnShipment_PositionID = Guid.NewGuid();
                newReturnShipmentPositionObject.ReturnPolicy_RefID = position.ReturnPolicyID;
                newReturnShipmentPositionObject.ReturnProductOriginatedFromReceiptPosition_RefID = position.ReceiptPositionID;
                newReturnShipmentPositionObject.ReturnShipment_Header_RefID = position.ReturnShipmentHeaderID;
                newReturnShipmentPositionObject.Tenant_RefID = securityTicket.TenantID;
                #endregion

                #region Save Position
                resultPosition = newShipmentPositionObject.Save(Connection, Transaction);
                resultReturnPosition = newReturnShipmentPositionObject.Save(Connection, Transaction);
                if (resultPosition.Status != FR_Status.Success || resultReturnPosition.Status != FR_Status.Success)
                {
                    returnValue.Status = FR_Status.Error_Internal;
                    returnValue.Result = null;
                    return returnValue;
                }

                savedPositions.Add(
                    new L5RS_CRSP_1405a(){
                        ProductID = position.ProductID,
                        ReceiptPositionID = position.ReceiptPositionID,
                        ShipmentPositionID = newShipmentPositionObject.LOG_SHP_Shipment_PositionID
                    });
                #endregion
            }

            #region Update Shipment Header with Total Value
            resultHeader = shipmentHeader.Save(Connection, Transaction);
            if (resultHeader.Status != FR_Status.Success)
            {
                returnValue.Status = FR_Status.Error_Internal;
                returnValue.Result = null;
                return returnValue;
            }
            #endregion

            #region Fetch ShipmentHeader SupplierName
            var supplierBusinessParticipant = new ORM_CMN_BPT_BusinessParticipant();
            supplierBusinessParticipant.Load(Connection, Transaction, shipmentHeader.RecipientBusinessParticipant_RefID);
            #endregion

            returnValue.Status = FR_Status.Success;

            returnValue.Result.ShipmentHeaderSupplierName = supplierBusinessParticipant == null ? string.Empty : supplierBusinessParticipant.DisplayName;
            returnValue.Result.ShipmentHeaderNumber = shipmentHeader.ShipmentHeader_Number;
            returnValue.Result.ShipmentHeaderTotalValue = shipmentHeader.ShipmentHeader_ValueWithoutTax;
            returnValue.Result.Positions = savedPositions.ToArray();

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5RS_CRSP_1405 Invoke(string ConnectionString,P_L5RS_CRSP_1405 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5RS_CRSP_1405 Invoke(DbConnection Connection,P_L5RS_CRSP_1405 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5RS_CRSP_1405 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5RS_CRSP_1405 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5RS_CRSP_1405 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5RS_CRSP_1405 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5RS_CRSP_1405 functionReturn = new FR_L5RS_CRSP_1405();
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

				throw new Exception("Exception occured in method cls_Create_ReturnShipment_Positions",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5RS_CRSP_1405 : FR_Base
	{
		public L5RS_CRSP_1405 Result	{ get; set; }

		public FR_L5RS_CRSP_1405() : base() {}

		public FR_L5RS_CRSP_1405(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5RS_CRSP_1405 for attribute P_L5RS_CRSP_1405
		[DataContract]
		public class P_L5RS_CRSP_1405 
		{
			[DataMember]
			public P_L5RS_CRSP_1405a[] Positions { get; set; }

			//Standard type parameters
		}
		#endregion
		#region SClass P_L5RS_CRSP_1405a for attribute Positions
		[DataContract]
		public class P_L5RS_CRSP_1405a 
		{
			//Standard type parameters
			[DataMember]
			public Guid ShipmentHeaderID { get; set; } 
			[DataMember]
			public Guid ReturnShipmentHeaderID { get; set; } 
			[DataMember]
			public Guid ProductID { get; set; } 
			[DataMember]
			public int Quantity { get; set; } 
			[DataMember]
			public Decimal PricePerUnit { get; set; } 
			[DataMember]
			public Guid ReturnPolicyID { get; set; } 
			[DataMember]
			public Guid ReceiptPositionID { get; set; } 

		}
		#endregion
		#region SClass L5RS_CRSP_1405 for attribute L5RS_CRSP_1405
		[DataContract]
		public class L5RS_CRSP_1405 
		{
			[DataMember]
			public L5RS_CRSP_1405a[] Positions { get; set; }

			//Standard type parameters
			[DataMember]
			public string ShipmentHeaderNumber { get; set; } 
			[DataMember]
			public string ShipmentHeaderSupplierName { get; set; } 
			[DataMember]
			public decimal ShipmentHeaderTotalValue { get; set; } 

		}
		#endregion
		#region SClass L5RS_CRSP_1405a for attribute Positions
		[DataContract]
		public class L5RS_CRSP_1405a 
		{
			//Standard type parameters
			[DataMember]
			public Guid ShipmentPositionID { get; set; } 
			[DataMember]
			public Guid ReceiptPositionID { get; set; } 
			[DataMember]
			public Guid ProductID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5RS_CRSP_1405 cls_Create_ReturnShipment_Positions(,P_L5RS_CRSP_1405 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5RS_CRSP_1405 invocationResult = cls_Create_ReturnShipment_Positions.Invoke(connectionString,P_L5RS_CRSP_1405 Parameter,securityTicket);
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
var parameter = new CL5_APOLogistic_ReturnShipment.Complex.Manipulation.P_L5RS_CRSP_1405();
parameter.Positions = ...;


*/
