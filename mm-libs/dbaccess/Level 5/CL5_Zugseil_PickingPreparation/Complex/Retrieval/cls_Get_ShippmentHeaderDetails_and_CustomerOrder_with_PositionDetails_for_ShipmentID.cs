/* 
 * Generated on 3/17/2015 11:30:35 AM
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
using CL5_Zugseil_PickingPreparation.Atomic.Retrieval;
using CL2_Zugseil_Shipments.Atomic.Retrieval;

namespace CL5_Zugseil_PickingPreparation.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ShippmentHeaderDetails_and_CustomerOrder_with_PositionDetails_for_ShipmentID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ShippmentHeaderDetails_and_CustomerOrder_with_PositionDetails_for_ShipmentID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5SH_GSHDaCOwPDfS_1128 Execute(DbConnection Connection,DbTransaction Transaction,P_L5SH_GSHDaCOwPDfS_1128 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_L5SH_GSHDaCOwPDfS_1128();

			//Put your code here
            if (Parameter.ShipmentHeaderID == null || Parameter.ShipmentHeaderID == Guid.Empty)
                return null;

            L5SH_GSHDaCOwPDfS_1128 retVal = new L5SH_GSHDaCOwPDfS_1128();

            P_L5PP_GSHDaCOwPfS_1125 param = new P_L5PP_GSHDaCOwPfS_1125();
            param.ShipmentHeaderID = Parameter.ShipmentHeaderID;
            var shipmentHeaderDetailsWithPositions = cls_Get_ShippmentHeaderDetails_and_CustomerOrder_with_Positions_for_ShipmentID.Invoke(Connection, Transaction, param, securityTicket).Result;

            if (shipmentHeaderDetailsWithPositions == null || shipmentHeaderDetailsWithPositions.Count() == 0)
                return null;

            #region Retrieve shipment header details
            var shipmentDetails = shipmentHeaderDetailsWithPositions.FirstOrDefault(i => i.LOG_SHP_Shipment_HeaderID == Parameter.ShipmentHeaderID);
            L5SH_GSHDaCOwPDfS_1128_ShipmentDetailHeader shipmentDetailHeaderRetVal = new L5SH_GSHDaCOwPDfS_1128_ShipmentDetailHeader();
            shipmentDetailHeaderRetVal.ORD_CUO_CustomerOrder_HeaderID = shipmentDetails.ORD_CUO_CustomerOrder_HeaderID;
            shipmentDetailHeaderRetVal.CustomerOrderNumber = shipmentDetails.CustomerOrder_Number;
            shipmentDetailHeaderRetVal.CustomerOrderDate = shipmentDetails.CustomerOrder_Date;
            shipmentDetailHeaderRetVal.ShipmentHeader_Number = shipmentDetails.ShipmentHeader_Number;
            shipmentDetailHeaderRetVal.ShipmentCreationDate = shipmentDetails.ShipmentCreationDate;
            shipmentDetailHeaderRetVal.Customer = shipmentDetails.DisplayName; 
            #endregion

            #region Retrieve shipment positions
            List<L5SH_GSHDaCOwPDfS_1128_ShipmentPositions> positionsRetVal = new List<L5SH_GSHDaCOwPDfS_1128_ShipmentPositions>();
            L5SH_GSHDaCOwPDfS_1128_ShipmentPositions positionItemRetVal;
            int quantity;
            foreach (var position in shipmentHeaderDetailsWithPositions)
            {
                if (!Int32.TryParse(position.Position_Quantity, out quantity))
                    quantity = 0;

                #region Get product quantities
                P_L2SH_GQiSCfPV_1654 quantitiesParam = new P_L2SH_GQiSCfPV_1654();
                quantitiesParam.ProductID = position.CMN_PRO_ProductID;
                quantitiesParam.ProductVariantID = position.CMN_PRO_Product_VariantID;
                var productQuantities = cls_Get_Quantities_in_ShelfContents_for_ProductVariantID.Invoke(Connection, Transaction, quantitiesParam, securityTicket).Result;
                #endregion

                positionItemRetVal = new L5SH_GSHDaCOwPDfS_1128_ShipmentPositions();
                positionItemRetVal.LOG_SHP_Shipment_PositionID = position.LOG_SHP_Shipment_PositionID;
                positionItemRetVal.CMN_PRO_ProductID = position.CMN_PRO_ProductID;
                positionItemRetVal.CMN_PRO_Product_VariantID = position.CMN_PRO_Product_VariantID;
                positionItemRetVal.Product_Number = position.Product_Number;
                positionItemRetVal.Product_Name = position.Product_Name;
                positionItemRetVal.VariantName = position.VariantName;
                positionItemRetVal.QuantityOnOrder = quantity;
                positionItemRetVal.QuantityReserved = productQuantities != null ? productQuantities.ReservedQuantity : 0;
                positionItemRetVal.QuantityOnStock = productQuantities != null ? productQuantities.CurrentQuantity : 0;
                positionItemRetVal.FreeQuantity = productQuantities != null ? productQuantities.FreeQuantity : 0;

                positionsRetVal.Add(positionItemRetVal);
            }
            #endregion

            retVal.ShipmentDetailHeader = shipmentDetailHeaderRetVal;
            retVal.ShipmentPositions = positionsRetVal.ToArray();

            returnValue.Result = retVal;
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5SH_GSHDaCOwPDfS_1128 Invoke(string ConnectionString,P_L5SH_GSHDaCOwPDfS_1128 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5SH_GSHDaCOwPDfS_1128 Invoke(DbConnection Connection,P_L5SH_GSHDaCOwPDfS_1128 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5SH_GSHDaCOwPDfS_1128 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5SH_GSHDaCOwPDfS_1128 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5SH_GSHDaCOwPDfS_1128 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5SH_GSHDaCOwPDfS_1128 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5SH_GSHDaCOwPDfS_1128 functionReturn = new FR_L5SH_GSHDaCOwPDfS_1128();
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

				throw new Exception("Exception occured in method cls_Get_ShippmentHeaderDetails_and_CustomerOrder_with_PositionDetails_for_ShipmentID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5SH_GSHDaCOwPDfS_1128 : FR_Base
	{
		public L5SH_GSHDaCOwPDfS_1128 Result	{ get; set; }

		public FR_L5SH_GSHDaCOwPDfS_1128() : base() {}

		public FR_L5SH_GSHDaCOwPDfS_1128(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5SH_GSHDaCOwPDfS_1128 for attribute P_L5SH_GSHDaCOwPDfS_1128
		[DataContract]
		public class P_L5SH_GSHDaCOwPDfS_1128 
		{
			//Standard type parameters
			[DataMember]
			public Guid ShipmentHeaderID { get; set; } 

		}
		#endregion
		#region SClass L5SH_GSHDaCOwPDfS_1128 for attribute L5SH_GSHDaCOwPDfS_1128
		[DataContract]
		public class L5SH_GSHDaCOwPDfS_1128 
		{
			[DataMember]
			public L5SH_GSHDaCOwPDfS_1128_ShipmentDetailHeader ShipmentDetailHeader { get; set; }
			[DataMember]
			public L5SH_GSHDaCOwPDfS_1128_ShipmentPositions[] ShipmentPositions { get; set; }

			//Standard type parameters
		}
		#endregion
		#region SClass L5SH_GSHDaCOwPDfS_1128_ShipmentDetailHeader for attribute ShipmentDetailHeader
		[DataContract]
		public class L5SH_GSHDaCOwPDfS_1128_ShipmentDetailHeader 
		{
			//Standard type parameters
			[DataMember]
			public Guid ORD_CUO_CustomerOrder_HeaderID { get; set; } 
			[DataMember]
			public DateTime CustomerOrderDate { get; set; } 
			[DataMember]
			public String CustomerOrderNumber { get; set; } 
			[DataMember]
			public String ShipmentHeader_Number { get; set; } 
			[DataMember]
			public DateTime ShipmentCreationDate { get; set; } 
			[DataMember]
			public String Customer { get; set; } 

		}
		#endregion
		#region SClass L5SH_GSHDaCOwPDfS_1128_ShipmentPositions for attribute ShipmentPositions
		[DataContract]
		public class L5SH_GSHDaCOwPDfS_1128_ShipmentPositions 
		{
			//Standard type parameters
			[DataMember]
			public Guid LOG_SHP_Shipment_PositionID { get; set; } 
			[DataMember]
			public Guid CMN_PRO_ProductID { get; set; } 
			[DataMember]
			public String Product_Number { get; set; } 
			[DataMember]
			public Dict Product_Name { get; set; } 
			[DataMember]
			public Guid CMN_PRO_Product_VariantID { get; set; } 
			[DataMember]
			public Dict VariantName { get; set; } 
			[DataMember]
			public int QuantityOnOrder { get; set; } 
			[DataMember]
			public int QuantityReserved { get; set; } 
			[DataMember]
			public int QuantityOnStock { get; set; } 
			[DataMember]
			public int FreeQuantity { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5SH_GSHDaCOwPDfS_1128 cls_Get_ShippmentHeaderDetails_and_CustomerOrder_with_PositionDetails_for_ShipmentID(,P_L5SH_GSHDaCOwPDfS_1128 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5SH_GSHDaCOwPDfS_1128 invocationResult = cls_Get_ShippmentHeaderDetails_and_CustomerOrder_with_PositionDetails_for_ShipmentID.Invoke(connectionString,P_L5SH_GSHDaCOwPDfS_1128 Parameter,securityTicket);
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
var parameter = new CL5_Zugseil_PickingPreparation.Complex.Retrieval.P_L5SH_GSHDaCOwPDfS_1128();
parameter.ShipmentHeaderID = ...;

*/
