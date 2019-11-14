/* 
 * Generated on 3/5/2015 15:52:32
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
using CL1_LOG_SHP;
using CL1_ORD_CUO;
using CL1_CMN;
using CL1_USR;
using DLCore_DBCommons.Utils;
using DLCore_DBCommons.Zugseil;


namespace CL5_Zugseil_CustomerOrder.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Accept_CustomerOrder_and_Create_Shipment.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Accept_CustomerOrder_and_Create_Shipment
	{
		public static readonly int QueryTimeout = 60;
        public static readonly string NumberRangeGlobalPropertyMatchingID = "zugseil-numberrange-shipment";

		#region Method Execution
		protected static FR_L5CO_ACOaCS_2108_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5CO_ACOaCS_2108[] Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_L5CO_ACOaCS_2108_Array();
            List<L5CO_ACOaCS_2108> confirmedProcurementOrders = new List<L5CO_ACOaCS_2108>();
            foreach (var param in Parameter)
            {
                L5CO_ACOaCS_2108 procurementOrderITL = new L5CO_ACOaCS_2108();
                var confirmedStatus = ORM_ORD_CUO_CustomerOrder_Status.Query.Search(Connection, Transaction,
              new ORM_ORD_CUO_CustomerOrder_Status.Query
              {
                  GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(ECustomerOrderStatus.Confirmed),
                  Tenant_RefID = securityTicket.TenantID,
                  IsDeleted = false
              }).Single().ORD_CUO_CustomerOrder_StatusID;

                var customerOrder = new ORM_ORD_CUO_CustomerOrder_Header();
                customerOrder.Load(Connection, Transaction, param.CustomerOrderHeaderID);
                customerOrder.Current_CustomerOrderStatus_RefID = confirmedStatus;
                customerOrder.IsCustomerOrderFinalized = true;
                customerOrder.Save(Connection, Transaction);

                ORM_USR_Account account = new ORM_USR_Account();
                account.Load(Connection, Transaction, securityTicket.AccountID);

                ORM_ORD_CUO_CustomerOrder_StatusHistory newStatusInHistory = new ORM_ORD_CUO_CustomerOrder_StatusHistory();
                newStatusInHistory.CustomerOrder_Header_RefID = customerOrder.ORD_CUO_CustomerOrder_HeaderID;
                newStatusInHistory.StatusHistoryComment = param.Message;
                newStatusInHistory.Tenant_RefID = securityTicket.TenantID;
                newStatusInHistory.CustomerOrder_Status_RefID = confirmedStatus;
                newStatusInHistory.PerformedBy_BusinessParticipant_RefID = account.BusinessParticipant_RefID;
                newStatusInHistory.Save(Connection, Transaction);

                
                procurementOrderITL.ProcurementOrderITL = customerOrder.ProcurementOrderITL;
                procurementOrderITL.ProcuringTenatID = customerOrder.OrderingCustomer_BusinessParticipant_RefID.ToString();
                

            
                ORM_CMN_NumberRange_UsageArea numberRangeUsageArea = ORM_CMN_NumberRange_UsageArea.Query.Search(Connection, Transaction, new ORM_CMN_NumberRange_UsageArea.Query()
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID,
                    GlobalStaticMatchingID = NumberRangeGlobalPropertyMatchingID
                }).FirstOrDefault();


                if (numberRangeUsageArea == null)
                {
                    throw new Exception(String.Format("Number range usage area with GPMID = {0} was not found.", NumberRangeGlobalPropertyMatchingID));
                }

                ORM_CMN_NumberRange numberRange = ORM_CMN_NumberRange.Query.Search(Connection, Transaction, new ORM_CMN_NumberRange.Query()
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID,
                    NumberRange_UsageArea_RefID = numberRangeUsageArea.CMN_NumberRange_UsageAreaID
                }).FirstOrDefault();

                if (numberRange == null)
                {
                    throw new Exception(String.Format("Number range for area with GPMID = {0} was not found.", NumberRangeGlobalPropertyMatchingID));
                }

                numberRange.Value_Current++;
                numberRange.Save(Connection, Transaction);
                string shipmentNumber = numberRange.FixedPrefix + numberRange.Value_Current.ToString().PadLeft(numberRange.Formatting_NumberLength, numberRange.Formatting_LeadingFillCharacter[0]);

                ORM_LOG_SHP_Shipment_Header shipmentHeader = new ORM_LOG_SHP_Shipment_Header();
                shipmentHeader.LOG_SHP_Shipment_HeaderID = Guid.NewGuid();
                shipmentHeader.RecipientBusinessParticipant_RefID = customerOrder.OrderingCustomer_BusinessParticipant_RefID;
                shipmentHeader.ShipmentHeaderITL = shipmentHeader.LOG_SHP_Shipment_HeaderID.ToString();
                shipmentHeader.ShipmentHeader_Number = shipmentNumber;
                shipmentHeader.Shippipng_AddressUCD_RefID = customerOrder.ShippingAddressUCD_RefID;
                shipmentHeader.ShipmentPriority = 0;
                shipmentHeader.ShipmentHeader_ValueWithoutTax = customerOrder.TotalValue_BeforeTax;
                shipmentHeader.ShipmentHeader_Currency_RefID = customerOrder.CustomerOrder_Currency_RefID;
                shipmentHeader.Tenant_RefID = securityTicket.TenantID;
                shipmentHeader.IsDeleted = false;
                shipmentHeader.Save(Connection, Transaction);

                var customerOrderPositions = ORM_ORD_CUO_CustomerOrder_Position.Query.Search(Connection, Transaction, new ORM_ORD_CUO_CustomerOrder_Position.Query()
                {
                    CustomerOrder_Header_RefID = customerOrder.ORD_CUO_CustomerOrder_HeaderID,
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                });

                if (customerOrderPositions != null)
                {
                    foreach (var customerOrderPosition in customerOrderPositions)
                    {
                        ORM_LOG_SHP_Shipment_Position shipmentPosition = new ORM_LOG_SHP_Shipment_Position();
                        shipmentPosition.LOG_SHP_Shipment_PositionID = Guid.NewGuid();
                        shipmentPosition.ShipmentPositionITL = shipmentPosition.LOG_SHP_Shipment_PositionID.ToString();
                        shipmentPosition.LOG_SHP_Shipment_Header_RefID = shipmentHeader.LOG_SHP_Shipment_HeaderID;
                        shipmentPosition.CMN_PRO_Product_RefID = customerOrderPosition.CMN_PRO_Product_RefID;
                        shipmentPosition.CMN_PRO_ProductVariant_RefID = customerOrderPosition.CMN_PRO_Product_Variant_RefID;
                        shipmentPosition.CMN_PRO_ProductRelease_RefID = customerOrderPosition.CMN_PRO_Product_Release_RefID;
                        shipmentPosition.QuantityToShip = customerOrderPosition.Position_Quantity;
                        shipmentPosition.ShipmentPosition_PricePerUnitValueWithoutTax = customerOrderPosition.Position_ValuePerUnit;
                        shipmentPosition.ShipmentPosition_ValueWithoutTax = customerOrderPosition.Position_ValueTotal;
                        shipmentPosition.IsCancelled = false;
                        shipmentPosition.Tenant_RefID = securityTicket.TenantID;
                        shipmentPosition.IsDeleted = false;
                        shipmentPosition.Save(Connection, Transaction);
                        ORM_ORD_CUO_CustomerOrder_Position_2_ShipmentPosition customerOrderPositionToShipmentPosition = new ORM_ORD_CUO_CustomerOrder_Position_2_ShipmentPosition();
                        customerOrderPositionToShipmentPosition.AssignmentID = Guid.NewGuid();
                        customerOrderPositionToShipmentPosition.LOG_SHP_Shipment_Position_RefID = shipmentPosition.LOG_SHP_Shipment_PositionID;
                        customerOrderPositionToShipmentPosition.ORD_CUO_CustomerOrder_Position_RefID = customerOrderPosition.ORD_CUO_CustomerOrder_PositionID;
                        customerOrderPositionToShipmentPosition.Tenant_RefID = securityTicket.TenantID;
                        customerOrderPositionToShipmentPosition.IsDeleted = false;
                        customerOrderPositionToShipmentPosition.Save(Connection, Transaction);
                    }
                
                
                }


                //TO DO: UNCOMMENT AFTER JANKO ADD STATUSES
                //var shipmentStatusHistoryStatusID = ORM_LOG_SHP_Shipment_Status.Query.Search(Connection, Transaction, new ORM_LOG_SHP_Shipment_Status.Query()
                //{
                //    GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(EShipmentStatus.Created),
                //    Tenant_RefID = securityTicket.TenantID,
                //    IsDeleted = false
                //}).Single().LOG_SHP_Shipment_StatusID;

                //ORM_LOG_SHP_Shipment_StatusHistory shipmentStatusHistory = new ORM_LOG_SHP_Shipment_StatusHistory();
                //shipmentStatusHistory.LOG_SHP_Shipment_StatusHistoryID = Guid.NewGuid();
                //shipmentStatusHistory.LOG_SHP_Shipment_Header_RefID = shipmentHeader.LOG_SHP_Shipment_HeaderID;
                //shipmentStatusHistory.LOG_SHP_Shipment_Status_RefID = shipmentStatusHistoryStatusID;
                //shipmentStatusHistory.PerformedBy_BusinessParticipant_RefID = securityTicket.TenantID;
                //shipmentStatusHistory.Tenant_RefID = securityTicket.TenantID;
                //shipmentStatusHistory.IsDeleted = false;
                //shipmentStatusHistory.Save(Connection, Transaction);

                ORM_LOG_SHP_ShipmentHeader_2_CustomerOrderHeader shipmentToCustomerOrderHeader = new ORM_LOG_SHP_ShipmentHeader_2_CustomerOrderHeader();
                shipmentToCustomerOrderHeader.AssignmentID = Guid.NewGuid();
                shipmentToCustomerOrderHeader.LOG_SHP_Shipment_Header_RefID = shipmentHeader.LOG_SHP_Shipment_HeaderID;
                shipmentToCustomerOrderHeader.ORD_CUO_CustomerOrder_Header_RefID = customerOrder.ORD_CUO_CustomerOrder_HeaderID;
                shipmentToCustomerOrderHeader.Tenant_RefID = securityTicket.TenantID;
                shipmentToCustomerOrderHeader.IsDeleted = false;
                shipmentToCustomerOrderHeader.Save(Connection, Transaction);


                confirmedProcurementOrders.Add(procurementOrderITL);
            }
            returnValue.Result = confirmedProcurementOrders.ToArray();
            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5CO_ACOaCS_2108_Array Invoke(string ConnectionString,P_L5CO_ACOaCS_2108[] Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5CO_ACOaCS_2108_Array Invoke(DbConnection Connection,P_L5CO_ACOaCS_2108[] Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5CO_ACOaCS_2108_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5CO_ACOaCS_2108[] Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5CO_ACOaCS_2108_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5CO_ACOaCS_2108[] Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5CO_ACOaCS_2108_Array functionReturn = new FR_L5CO_ACOaCS_2108_Array();
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

				throw new Exception("Exception occured in method cls_Accept_CustomerOrder_and_Create_Shipment",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5CO_ACOaCS_2108_Array : FR_Base
	{
		public L5CO_ACOaCS_2108[] Result	{ get; set; } 
		public FR_L5CO_ACOaCS_2108_Array() : base() {}

		public FR_L5CO_ACOaCS_2108_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
    #region SClass P_L5CO_ACOaCS_2108 for attribute P_L5CO_ACOaCS_2108[]
    [DataContract]
		public class P_L5CO_ACOaCS_2108 
		{
			//Standard type parameters
			[DataMember]
			public Guid CustomerOrderHeaderID { get; set; } 
			[DataMember]
			public String Message { get; set; } 

		}
		#endregion
		#region SClass L5CO_ACOaCS_2108 for attribute L5CO_ACOaCS_2108
		[DataContract]
		public class L5CO_ACOaCS_2108 
		{
			//Standard type parameters
			[DataMember]
			public String ProcurementOrderITL { get; set; } 
			[DataMember]
			public String ProcuringTenatID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5CO_ACOaCS_2108_Array cls_Accept_CustomerOrder_and_Create_Shipment(,P_L5CO_ACOaCS_2108 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5CO_ACOaCS_2108_Array invocationResult = cls_Accept_CustomerOrder_and_Create_Shipment.Invoke(connectionString,P_L5CO_ACOaCS_2108 Parameter,securityTicket);
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
var parameter = new CL5_Zugseil_CustomerOrder.Complex.Manipulation.P_L5CO_ACOaCS_2108();
parameter.CustomerOrderHeaderID = ...;
parameter.Message = ...;

*/
