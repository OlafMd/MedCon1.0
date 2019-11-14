/* 
 * Generated on 3/16/2015 2:51:45 PM
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
using CL2_Zugseil_Shipments.Atomic.Retrieval;
using CL1_LOG_SHP;
using CL1_CMN_STR;
using CL1_CMN_BPT;
using CL1_ORD_CUO;

namespace CL5_Zugseil_PickingPreparation.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ShippmentHeaders_with_CustomerOrder_for_Picking_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ShippmentHeaders_with_CustomerOrder_for_Picking_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5PP_GSHwCOfPfT_1348_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5PP_GSHwCOfPfT_1348 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5PP_GSHwCOfPfT_1348_Array();

			//Put your code here
            List<L5PP_GSHwCOfPfT_1348> retVal = new List<L5PP_GSHwCOfPfT_1348>();
            returnValue.Result = retVal.ToArray();

            #region Retrieve Headers

            // get all headers
            P_L2SH_GSHfT_1527 shipmentHeadersParam = new P_L2SH_GSHfT_1527();
            shipmentHeadersParam.IsShipped = false;
            shipmentHeadersParam.ShipmentNumber = Parameter.ShipmentNumber;
            shipmentHeadersParam.ShipmentCreationDateFrom = Parameter.ShipmentCreationDateFrom;
            shipmentHeadersParam.ShipmentCreationDateTo = Parameter.ShipmentCreationDateTo;
            var headersResult = cls_Get_ShippmentHeaders_for_TenantID.Invoke(Connection, Transaction, shipmentHeadersParam, securityTicket).Result;

            if (headersResult == null)
                return returnValue;

            // filter headers
            List<L2SH_GSHfT_1527> headers = new List<L2SH_GSHfT_1527>();
            List<L2SH_GSHfT_1527> tempHeaders = new List<L2SH_GSHfT_1527>();
            if (Parameter.HasPositionsPartiallyToPick)
            {
                // filtered by passed parameter option
                tempHeaders = headersResult.Where(i => i.IsPartiallyReadyForPicking && !i.IsManuallyCleared_ForPicking).ToList();
                // add not inserted shipment headers
                headers.AddRange(tempHeaders.Where(i => !headers.Any(j => j.LOG_SHP_Shipment_HeaderID == i.LOG_SHP_Shipment_HeaderID)).ToList());
            }

            if (Parameter.IsReadyForPicking)
            {
                // filtered by passed parameter option
                tempHeaders = headersResult.Where(i => i.IsReadyForPicking && !i.IsManuallyCleared_ForPicking).ToList();
                // add not inserted shipment headers
                headers.AddRange(tempHeaders.Where(i => !headers.Any(j => j.LOG_SHP_Shipment_HeaderID == i.LOG_SHP_Shipment_HeaderID)).ToList());
            }

            if (Parameter.IsInPickingProcess)
            {
                // filtered by passed parameter option
                tempHeaders = headersResult.Where(i => i.HasPickingStarted || i.HasPickingFinished || i.IsManuallyCleared_ForPicking).ToList();
                // add not inserted shipment headers
                headers.AddRange(tempHeaders.Where(i => !headers.Any(j => j.LOG_SHP_Shipment_HeaderID == i.LOG_SHP_Shipment_HeaderID)).ToList());
            }

            if (Parameter.NoPositionsFullyToPick)
            {
                // filtered by passed parameter option
                tempHeaders = headersResult.Where(i =>
                        !(i.IsPartiallyReadyForPicking && !i.IsManuallyCleared_ForPicking) &&
                        !(i.IsReadyForPicking && !i.IsManuallyCleared_ForPicking) &&
                        !(i.HasPickingStarted || i.HasPickingFinished || i.IsManuallyCleared_ForPicking)
                    ).ToList();
                // add not inserted shipment headers
                headers.AddRange(tempHeaders.Where(i => !headers.Any(j => j.LOG_SHP_Shipment_HeaderID == i.LOG_SHP_Shipment_HeaderID)).ToList());
            }

            #endregion

            L5PP_GSHwCOfPfT_1348 retValItem;
            foreach (var header in headers)
            {
                #region Getting data

                #region Shipment positions
                // get one shipment position for shipment header
                ORM_LOG_SHP_Shipment_Position.Query shipmentPositionsQuery = new ORM_LOG_SHP_Shipment_Position.Query();
                shipmentPositionsQuery.LOG_SHP_Shipment_Header_RefID = header.LOG_SHP_Shipment_HeaderID;
                shipmentPositionsQuery.Tenant_RefID = securityTicket.TenantID;
                shipmentPositionsQuery.IsDeleted = false;
                List<ORM_LOG_SHP_Shipment_Position> shipmentPositions = ORM_LOG_SHP_Shipment_Position.Query.Search(Connection, Transaction, shipmentPositionsQuery);

                if (shipmentPositions == null || shipmentPositions.Count == 0)
                    continue;
                #endregion

                #region Customer order position for shipment position
                // get one customer order position for shipment position
                ORM_ORD_CUO_CustomerOrder_Position_2_ShipmentPosition customerOrder2ShipmentPosition = null;
                foreach (var shipmentPosition in shipmentPositions)
                {
                    ORM_ORD_CUO_CustomerOrder_Position_2_ShipmentPosition.Query customerOrder2ShipmentPositionQuery = new ORM_ORD_CUO_CustomerOrder_Position_2_ShipmentPosition.Query();
                    customerOrder2ShipmentPositionQuery.LOG_SHP_Shipment_Position_RefID = shipmentPosition.LOG_SHP_Shipment_PositionID;
                    customerOrder2ShipmentPositionQuery.Tenant_RefID = securityTicket.TenantID;
                    customerOrder2ShipmentPositionQuery.IsDeleted = false;
                    customerOrder2ShipmentPosition =
                        ORM_ORD_CUO_CustomerOrder_Position_2_ShipmentPosition.Query
                        .Search(Connection, Transaction, customerOrder2ShipmentPositionQuery).FirstOrDefault();

                    if (customerOrder2ShipmentPosition != null)
                        break;
                }

                if (customerOrder2ShipmentPosition == null)
                    continue;
                #endregion

                #region Customer order position
                ORM_ORD_CUO_CustomerOrder_Position orm_CustomerOrderPosition = new ORM_ORD_CUO_CustomerOrder_Position();
                var distributionOrderPosition = orm_CustomerOrderPosition.Load(Connection, Transaction, customerOrder2ShipmentPosition.ORD_CUO_CustomerOrder_Position_RefID);
                if (distributionOrderPosition.Status != FR_Status.Success || orm_CustomerOrderPosition.ORD_CUO_CustomerOrder_PositionID == Guid.Empty)
                    continue;
                #endregion

                #region Customer order header
                // get customer order header for customer order position
                ORM_ORD_CUO_CustomerOrder_Header.Query customerOrderHeaderQuery = new ORM_ORD_CUO_CustomerOrder_Header.Query();
                customerOrderHeaderQuery.ORD_CUO_CustomerOrder_HeaderID = orm_CustomerOrderPosition.CustomerOrder_Header_RefID;
                customerOrderHeaderQuery.Tenant_RefID = securityTicket.TenantID;
                customerOrderHeaderQuery.IsDeleted = false;
                if (!String.IsNullOrEmpty(Parameter.CustomerOrderNumber))
                    customerOrderHeaderQuery.CustomerOrder_Number = Parameter.CustomerOrderNumber;

                ORM_ORD_CUO_CustomerOrder_Header customerOrderHeader = ORM_ORD_CUO_CustomerOrder_Header.Query.Search(Connection, Transaction, customerOrderHeaderQuery).FirstOrDefault();
                if (customerOrderHeader == null)
                    continue;

                // apply filter for customer order header
                if (Parameter.OrderDateFrom != null)
                {
                    if (customerOrderHeader.CustomerOrder_Date < Parameter.OrderDateFrom)
                        continue;
                }

                if (Parameter.OrderDateTo != null)
                {
                    if (customerOrderHeader.CustomerOrder_Date > Parameter.OrderDateTo)
                        continue;
                }
                #endregion

                #region Customer
                ORM_CMN_BPT_BusinessParticipant.Query bussinerParticipantQuery = new ORM_CMN_BPT_BusinessParticipant.Query();
                bussinerParticipantQuery.CMN_BPT_BusinessParticipantID = customerOrderHeader.OrderingCustomer_BusinessParticipant_RefID;
                bussinerParticipantQuery.Tenant_RefID = securityTicket.TenantID;
                bussinerParticipantQuery.IsDeleted = false;

                ORM_CMN_BPT_BusinessParticipant bussinerParticipant = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, bussinerParticipantQuery).FirstOrDefault();

                if (bussinerParticipant == null)
                    continue;

                if (!String.IsNullOrEmpty(Parameter.Customer))
                {
                    if (!bussinerParticipant.DisplayName.ToUpper().Contains(Parameter.Customer.ToUpper()))
                        continue;
                }
                #endregion

                #endregion

                retValItem = new L5PP_GSHwCOfPfT_1348();
                retValItem.LOG_SHP_Shipment_HeaderID = header.LOG_SHP_Shipment_HeaderID;
                retValItem.ShipmentHeader_Number = header.ShipmentHeader_Number;
                retValItem.IsShipped = header.IsShipped;
                retValItem.IsBilled = header.IsBilled;
                retValItem.IsReadyForPicking = header.IsReadyForPicking;
                retValItem.IsPartiallyReadyForPicking = header.IsPartiallyReadyForPicking;
                retValItem.HasPickingStarted = header.HasPickingStarted;
                retValItem.HasPickingFinished = header.HasPickingFinished;
                retValItem.IsManuallyCleared_ForPicking = header.IsManuallyCleared_ForPicking;
                retValItem.ShipmentCreationDate = header.Creation_Timestamp;

                retValItem.ORD_CUO_CustomerOrder_HeaderID = customerOrderHeader.ORD_CUO_CustomerOrder_HeaderID;
                retValItem.CustomerOrderNumber = customerOrderHeader.CustomerOrder_Number;
                retValItem.CustomerOrderDate = customerOrderHeader.CustomerOrder_Date;

                retValItem.Customer = bussinerParticipant.DisplayName;

                retVal.Add(retValItem);
            }

            retVal = retVal.Skip(Parameter.From).Take(Parameter.Size).ToList();

            returnValue.Result = retVal.ToArray();

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5PP_GSHwCOfPfT_1348_Array Invoke(string ConnectionString,P_L5PP_GSHwCOfPfT_1348 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5PP_GSHwCOfPfT_1348_Array Invoke(DbConnection Connection,P_L5PP_GSHwCOfPfT_1348 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5PP_GSHwCOfPfT_1348_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5PP_GSHwCOfPfT_1348 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5PP_GSHwCOfPfT_1348_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5PP_GSHwCOfPfT_1348 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5PP_GSHwCOfPfT_1348_Array functionReturn = new FR_L5PP_GSHwCOfPfT_1348_Array();
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

				throw new Exception("Exception occured in method cls_Get_ShippmentHeaders_with_CustomerOrder_for_Picking_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5PP_GSHwCOfPfT_1348_Array : FR_Base
	{
		public L5PP_GSHwCOfPfT_1348[] Result	{ get; set; } 
		public FR_L5PP_GSHwCOfPfT_1348_Array() : base() {}

		public FR_L5PP_GSHwCOfPfT_1348_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5PP_GSHwCOfPfT_1348 for attribute P_L5PP_GSHwCOfPfT_1348
		[DataContract]
		public class P_L5PP_GSHwCOfPfT_1348 
		{
			//Standard type parameters
			[DataMember]
			public Boolean NoPositionsFullyToPick { get; set; } 
			[DataMember]
			public Boolean HasPositionsPartiallyToPick { get; set; } 
			[DataMember]
			public Boolean IsReadyForPicking { get; set; } 
			[DataMember]
			public Boolean IsInPickingProcess { get; set; } 
			[DataMember]
			public String CustomerOrderNumber { get; set; } 
			[DataMember]
			public String ShipmentNumber { get; set; } 
			[DataMember]
			public DateTime? OrderDateFrom { get; set; } 
			[DataMember]
			public DateTime? OrderDateTo { get; set; } 
			[DataMember]
			public String Customer { get; set; } 
			[DataMember]
			public DateTime? ShipmentCreationDateFrom { get; set; } 
			[DataMember]
			public DateTime? ShipmentCreationDateTo { get; set; } 
			[DataMember]
			public int From { get; set; } 
			[DataMember]
			public int Size { get; set; } 

		}
		#endregion
		#region SClass L5PP_GSHwCOfPfT_1348 for attribute L5PP_GSHwCOfPfT_1348
		[DataContract]
		public class L5PP_GSHwCOfPfT_1348 
		{
			//Standard type parameters
			[DataMember]
			public Guid LOG_SHP_Shipment_HeaderID { get; set; } 
			[DataMember]
			public String ShipmentHeader_Number { get; set; } 
			[DataMember]
			public Boolean IsShipped { get; set; } 
			[DataMember]
			public Boolean IsBilled { get; set; } 
			[DataMember]
			public Boolean IsReadyForPicking { get; set; } 
			[DataMember]
			public Boolean IsPartiallyReadyForPicking { get; set; } 
			[DataMember]
			public Boolean HasPickingStarted { get; set; } 
			[DataMember]
			public Boolean HasPickingFinished { get; set; } 
			[DataMember]
			public Boolean IsManuallyCleared_ForPicking { get; set; } 
			[DataMember]
			public DateTime ShipmentCreationDate { get; set; } 
			[DataMember]
			public Guid ORD_CUO_CustomerOrder_HeaderID { get; set; } 
			[DataMember]
			public String CustomerOrderNumber { get; set; } 
			[DataMember]
			public DateTime CustomerOrderDate { get; set; } 
			[DataMember]
			public String Customer { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5PP_GSHwCOfPfT_1348_Array cls_Get_ShippmentHeaders_with_CustomerOrder_for_Picking_for_TenantID(,P_L5PP_GSHwCOfPfT_1348 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5PP_GSHwCOfPfT_1348_Array invocationResult = cls_Get_ShippmentHeaders_with_CustomerOrder_for_Picking_for_TenantID.Invoke(connectionString,P_L5PP_GSHwCOfPfT_1348 Parameter,securityTicket);
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
var parameter = new CL5_Zugseil_PickingPreparation.Complex.Retrieval.P_L5PP_GSHwCOfPfT_1348();
parameter.NoPositionsFullyToPick = ...;
parameter.HasPositionsPartiallyToPick = ...;
parameter.IsReadyForPicking = ...;
parameter.IsInPickingProcess = ...;
parameter.CustomerOrderNumber = ...;
parameter.ShipmentNumber = ...;
parameter.OrderDateFrom = ...;
parameter.OrderDateTo = ...;
parameter.Customer = ...;
parameter.ShipmentCreationDateFrom = ...;
parameter.ShipmentCreationDateTo = ...;
parameter.From = ...;
parameter.Size = ...;

*/
