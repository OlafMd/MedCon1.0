/* 
 * Generated on 3/13/2015 3:01:07 PM
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
using CL3_ShelfContent.Atomic.Retrieval;

namespace CL5_Zugseil_PickingPreparation.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ShippmentHeaderDetails_and_DistributionOrder_with_PositionDetails_for_ShipmentID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ShippmentHeaderDetails_and_DistributionOrder_with_PositionDetails_for_ShipmentID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5SH_GSHDaDOwPDfS_1013 Execute(DbConnection Connection,DbTransaction Transaction,P_L5SH_GSHDaDOwPDfS_1013 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_L5SH_GSHDaDOwPDfS_1013();

			//Put your code here
            if (Parameter.ShipmentHeaderID == null || Parameter.ShipmentHeaderID == Guid.Empty)
                return null;

            L5SH_GSHDaDOwPDfS_1013 retVal = new L5SH_GSHDaDOwPDfS_1013();
            
            P_L5PP_GSHDaDOwPfS_1428 param = new P_L5PP_GSHDaDOwPfS_1428();
            param.ShipmentHeaderID = Parameter.ShipmentHeaderID;
            var shipmentHeaderDetailsWithPositions = cls_Get_ShippmentHeaderDetails_and_DistributionOrder_with_Positions_for_ShipmentID.Invoke(Connection, Transaction, param, securityTicket).Result;

            #region variant quantities

            List<L3SC_GPVQfPV_0942> productVariantQuantities = new List<L3SC_GPVQfPV_0942>();

            P_L3SC_GPVQfPV_0942 productVariantQuantitiesParameter = new P_L3SC_GPVQfPV_0942();
            productVariantQuantitiesParameter.ProductVatiantIDList = shipmentHeaderDetailsWithPositions.Select(i => i.CMN_PRO_Product_VariantID).Distinct().ToArray();
            var productVariantQuantitiesResult = cls_Get_ProductVariantQuantities_for_ProductVariantIDList.Invoke(Connection, Transaction, productVariantQuantitiesParameter, securityTicket);
            if (productVariantQuantitiesResult != null && productVariantQuantitiesResult.Result != null)
                productVariantQuantities = productVariantQuantitiesResult.Result.ToList();

            #endregion


            if (shipmentHeaderDetailsWithPositions == null || shipmentHeaderDetailsWithPositions.Count() == 0)
                return null;

            #region Retrieve shipment header details
            var shipmentDetails = shipmentHeaderDetailsWithPositions.FirstOrDefault(i => i.LOG_SHP_Shipment_HeaderID == Parameter.ShipmentHeaderID);

            #region address
            L5PP_GSHDaDOwPfS_1428 address = shipmentHeaderDetailsWithPositions.FirstOrDefault(i => i.IsShippingAddress);

            if(address == null)
                address = shipmentHeaderDetailsWithPositions.FirstOrDefault(i => i.IsDefault);
            
            #endregion

            L5SH_GSHDaDOwPDfS_1013_ShipmentDetailHeader shipmentDetailHeaderRetVal = new L5SH_GSHDaDOwPDfS_1013_ShipmentDetailHeader();
            shipmentDetailHeaderRetVal.ORD_DIS_DistributionOrder_HeaderID = shipmentDetails.DistributionOrder_Header_RefID;
            shipmentDetailHeaderRetVal.DistributionOrderNumber = shipmentDetails.DistributionOrderNumber;
            shipmentDetailHeaderRetVal.DistributionOrderDate = shipmentDetails.DistributionOrderDate;
            shipmentDetailHeaderRetVal.ShipmentHeader_Number = shipmentDetails.ShipmentHeader_Number;
            shipmentDetailHeaderRetVal.ShipmentCreationDate = shipmentDetails.ShipmentCreationDate;
            shipmentDetailHeaderRetVal.Office_Name_DictID = shipmentDetails.Office_Name;
            shipmentDetailHeaderRetVal.CMN_STR_OfficeID = shipmentDetails.CMN_STR_OfficeID;
            shipmentDetailHeaderRetVal.CostCenter_Name_DictID = shipmentDetails.Name;
            shipmentDetailHeaderRetVal.CMN_STR_CostCenterID = shipmentDetails.CMN_STR_CostCenterID;
            shipmentDetailHeaderRetVal.Street_Name = address != null ? address.Street_Name : String.Empty;
            shipmentDetailHeaderRetVal.Street_Number = address != null ? shipmentDetails.Street_Number : String.Empty;
            shipmentDetailHeaderRetVal.City_PostalCode = address != null ? shipmentDetails.City_PostalCode : String.Empty;
            shipmentDetailHeaderRetVal.City_Name = address != null ? shipmentDetails.City_Name : String.Empty;
            shipmentDetailHeaderRetVal.Country_Name = address != null ? shipmentDetails.Country_Name : String.Empty; 

            #endregion

            #region Retrieve shipment positions
            List<L5SH_GSHDaDOwPDfS_1013_ShipmentPositions> positionsRetVal = new List<L5SH_GSHDaDOwPDfS_1013_ShipmentPositions>();
            L5SH_GSHDaDOwPDfS_1013_ShipmentPositions positionItemRetVal;
            int quantity;
            foreach (var position in shipmentHeaderDetailsWithPositions)
            {
                if(!Int32.TryParse(position.Quantity, out quantity))
                    quantity = 0;

                #region Get product quantities
                var positionQuantities = productVariantQuantities.Where(i => i.Product_Variant_RefID == position.CMN_PRO_Product_VariantID).ToList();
                double quantityReserved = productVariantQuantities.Sum(i => i.ReservedQuantity);
                double quantityOnStock = productVariantQuantities.Sum(i => i.CurrentQuantity);
                double freeQuantity = productVariantQuantities.Sum(i => i.FreeQuantity);
                #endregion

                positionItemRetVal = new L5SH_GSHDaDOwPDfS_1013_ShipmentPositions();
                positionItemRetVal.LOG_SHP_Shipment_PositionID = position.LOG_SHP_Shipment_PositionID;
                positionItemRetVal.CMN_PRO_ProductID = position.CMN_PRO_ProductID;
                positionItemRetVal.CMN_PRO_Product_VariantID = position.CMN_PRO_Product_VariantID;
                positionItemRetVal.Product_Number = position.Product_Number;
                positionItemRetVal.Product_Name = position.Product_Name;
                positionItemRetVal.VariantName = position.VariantName;
                positionItemRetVal.QuantityOnOrder = quantity;
                positionItemRetVal.QuantityReserved = Int32.Parse(quantityReserved.ToString());
                positionItemRetVal.QuantityOnStock = Int32.Parse(quantityOnStock.ToString());
                positionItemRetVal.FreeQuantity = Int32.Parse(freeQuantity.ToString());

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
		public static FR_L5SH_GSHDaDOwPDfS_1013 Invoke(string ConnectionString,P_L5SH_GSHDaDOwPDfS_1013 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5SH_GSHDaDOwPDfS_1013 Invoke(DbConnection Connection,P_L5SH_GSHDaDOwPDfS_1013 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5SH_GSHDaDOwPDfS_1013 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5SH_GSHDaDOwPDfS_1013 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5SH_GSHDaDOwPDfS_1013 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5SH_GSHDaDOwPDfS_1013 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5SH_GSHDaDOwPDfS_1013 functionReturn = new FR_L5SH_GSHDaDOwPDfS_1013();
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

				throw new Exception("Exception occured in method cls_Get_ShippmentHeaderDetails_and_DistributionOrder_with_PositionDetails_for_ShipmentID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5SH_GSHDaDOwPDfS_1013 : FR_Base
	{
		public L5SH_GSHDaDOwPDfS_1013 Result	{ get; set; }

		public FR_L5SH_GSHDaDOwPDfS_1013() : base() {}

		public FR_L5SH_GSHDaDOwPDfS_1013(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
        #region SClass P_L5SH_GSHDaDOwPDfS_1013 for attribute P_L5SH_GSHDaDOwPDfS_1013
        [DataContract]
		public class P_L5SH_GSHDaDOwPDfS_1013 
		{
			//Standard type parameters
			[DataMember]
			public Guid ShipmentHeaderID { get; set; } 

		}
		#endregion
        #region SClass L5SH_GSHDaDOwPDfS_1013 for attribute L5SH_GSHDaDOwPDfS_1013
        [DataContract]
		public class L5SH_GSHDaDOwPDfS_1013 
		{
			[DataMember]
			public L5SH_GSHDaDOwPDfS_1013_ShipmentDetailHeader ShipmentDetailHeader { get; set; }
			[DataMember]
			public L5SH_GSHDaDOwPDfS_1013_ShipmentPositions[] ShipmentPositions { get; set; }

			//Standard type parameters
		}
		#endregion
        #region SClass L5SH_GSHDaDOwPDfS_1013_ShipmentDetailHeader for attribute ShipmentDetailHeader
        [DataContract]
		public class L5SH_GSHDaDOwPDfS_1013_ShipmentDetailHeader 
		{
			//Standard type parameters
			[DataMember]
			public Guid ORD_DIS_DistributionOrder_HeaderID { get; set; } 
			[DataMember]
			public DateTime DistributionOrderDate { get; set; } 
			[DataMember]
			public String DistributionOrderNumber { get; set; } 
			[DataMember]
			public String ShipmentHeader_Number { get; set; } 
			[DataMember]
			public DateTime ShipmentCreationDate { get; set; } 
			[DataMember]
			public Guid CMN_STR_OfficeID { get; set; } 
			[DataMember]
			public Dict Office_Name_DictID { get; set; } 
			[DataMember]
			public Guid CMN_STR_CostCenterID { get; set; } 
			[DataMember]
			public Dict CostCenter_Name_DictID { get; set; } 
			[DataMember]
			public String Street_Name { get; set; } 
			[DataMember]
			public String Street_Number { get; set; } 
			[DataMember]
			public String City_PostalCode { get; set; } 
			[DataMember]
			public String City_Name { get; set; } 
			[DataMember]
			public String Country_Name { get; set; } 

		}
		#endregion
        #region SClass L5SH_GSHDaDOwPDfS_1013_ShipmentPositions for attribute ShipmentPositions
        [DataContract]
		public class L5SH_GSHDaDOwPDfS_1013_ShipmentPositions 
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
FR_L5SH_GSHDwPDfS_1013 cls_Get_ShippmentHeaderDetails_and_DistributionOrder_with_PositionDetails_for_ShipmentID(,P_L5SH_GSHDwPDfS_1013 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5SH_GSHDwPDfS_1013 invocationResult = cls_Get_ShippmentHeaderDetails_and_DistributionOrder_with_PositionDetails_for_ShipmentID.Invoke(connectionString,P_L5SH_GSHDwPDfS_1013 Parameter,securityTicket);
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
var parameter = new CL5_Zugseil_PickingPreparation.Complex.Retrieval.P_L5SH_GSHDwPDfS_1013();
parameter.ShipmentHeaderID = ...;

*/
