/* 
 * Generated on 3/11/2015 1:30:16 PM
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
using CL1_ORD_DIS;
using CL1_CMN_STR;

namespace CL5_Zugseil_PickingPreparation.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ShippmentHeaders_with_DistributionOrder_for_Picking_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ShippmentHeaders_with_DistributionOrder_for_Picking_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5PP_GSHwDOfPfT_1013_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5PP_GSHwDOfPfT_1013 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5PP_GSHwDOfPfT_1013_Array();

			//Put your code here
            List<L5PP_GSHwDOfPfT_1013> retVal = new List<L5PP_GSHwDOfPfT_1013>();
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
                tempHeaders = headersResult.Where(i=>i.IsPartiallyReadyForPicking && !i.IsManuallyCleared_ForPicking).ToList();
                // add not inserted shipment headers
                headers.AddRange(tempHeaders.Where(i=>!headers.Any(j=>j.LOG_SHP_Shipment_HeaderID == i.LOG_SHP_Shipment_HeaderID)).ToList());
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

            L5PP_GSHwDOfPfT_1013 retValItem;
            foreach(var header in headers)
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

                #region Distribution order position for shipment position
                // get one distribution order position for shipment position
                ORM_ORD_DIS_DistributionOrderPosition_2_ShipmentOrderPosition distributionOrder2ShipmentPosition = null;
                foreach (var shipmentPosition in shipmentPositions)
                {
                    ORM_ORD_DIS_DistributionOrderPosition_2_ShipmentOrderPosition.Query distributionOrder2ShipmentPositionQuery = new ORM_ORD_DIS_DistributionOrderPosition_2_ShipmentOrderPosition.Query();
                    distributionOrder2ShipmentPositionQuery.LOG_SHP_Shipment_Position_RefID = shipmentPosition.LOG_SHP_Shipment_PositionID;
                    distributionOrder2ShipmentPositionQuery.Tenant_RefID = securityTicket.TenantID;
                    distributionOrder2ShipmentPositionQuery.IsDeleted = false;
                    distributionOrder2ShipmentPosition =
                        ORM_ORD_DIS_DistributionOrderPosition_2_ShipmentOrderPosition.Query
                        .Search(Connection, Transaction, distributionOrder2ShipmentPositionQuery).FirstOrDefault();

                    if (distributionOrder2ShipmentPosition != null)
                        break;
                }

                if (distributionOrder2ShipmentPosition == null)
                    continue; 
                #endregion

                #region Disrtibution order position
                ORM_ORD_DIS_DistributionOrder_Position orm_DistributionOrderPosition = new ORM_ORD_DIS_DistributionOrder_Position();
                var distributionOrderPosition = orm_DistributionOrderPosition.Load(Connection, Transaction, distributionOrder2ShipmentPosition.ORD_DIS_DistributionOrder_Position_RefID);
                if (distributionOrderPosition.Status != FR_Status.Success || orm_DistributionOrderPosition.ORD_DIS_DistributionOrder_PositionID == Guid.Empty)
                    continue; 
                #endregion

                #region Distribution order header
                // get sitribution order header for distribution order position
                ORM_ORD_DIS_DistributionOrder_Header.Query distributionOrderHeaderQuery = new ORM_ORD_DIS_DistributionOrder_Header.Query();
                distributionOrderHeaderQuery.ORD_DIS_DistributionOrder_HeaderID = orm_DistributionOrderPosition.DistributionOrder_Header_RefID;
                distributionOrderHeaderQuery.Tenant_RefID = securityTicket.TenantID;
                distributionOrderHeaderQuery.IsDeleted = false;

                ORM_ORD_DIS_DistributionOrder_Header distributionOrderHeader = ORM_ORD_DIS_DistributionOrder_Header.Query.Search(Connection, Transaction, distributionOrderHeaderQuery).FirstOrDefault();
                if (distributionOrderHeader == null)
                    continue; 

                // apply filter for distribution order header
                if (Parameter.OrderDateFrom != null)
                {
                    if (distributionOrderHeader.DistributionOrderDate < Parameter.OrderDateFrom)
                        continue;
                }

                if (Parameter.OrderDateTo != null)
                {
                    if (distributionOrderHeader.DistributionOrderDate > Parameter.OrderDateTo)
                        continue;
                }

                if (!String.IsNullOrEmpty(Parameter.DistributionOrderNumber))
                {
                    if (!distributionOrderHeader.DistributionOrderNumber.ToUpper().Contains(Parameter.DistributionOrderNumber.ToUpper()))
                        continue;
                }
                #endregion

                #region CostCenter
                // get cost center for distribution order header
                ORM_CMN_STR_CostCenter orm_CostCenter = new ORM_CMN_STR_CostCenter();
                var costCenter = orm_CostCenter.Load(Connection, Transaction, distributionOrderHeader.Charged_CostCenter_RefID);
                if (costCenter.Status != FR_Status.Success || orm_CostCenter.CMN_STR_CostCenterID == Guid.Empty)
                    continue; 

                if (!String.IsNullOrEmpty(Parameter.CostCenter))
                {
                    // apply filter for cost center
                    if (!orm_CostCenter.Name.Contents.Any(i => i.Content.ToLower().Contains(Parameter.CostCenter)))
                        continue;
                }
                #endregion

                #region Office
                // get office for cost center
                ORM_CMN_STR_Office_2_CostCenter.Query office2CostCenterQuery = new ORM_CMN_STR_Office_2_CostCenter.Query();
                office2CostCenterQuery.CostCenter_RefID = orm_CostCenter.CMN_STR_CostCenterID;
                office2CostCenterQuery.Tenant_RefID = securityTicket.TenantID;
                office2CostCenterQuery.IsDefault = false;
                ORM_CMN_STR_Office_2_CostCenter office2CostCenter = ORM_CMN_STR_Office_2_CostCenter.Query.Search(Connection, Transaction, office2CostCenterQuery).FirstOrDefault();
                
                ORM_CMN_STR_Office orm_Office = null;
                if (office2CostCenter != null)
                {
                    orm_Office = new ORM_CMN_STR_Office();
                    var office = orm_Office.Load(Connection, Transaction, office2CostCenter.Office_RefID);
                    if (office.Status != FR_Status.Success || orm_Office.CMN_STR_OfficeID == Guid.Empty)
                    {
                        // there is no office with such ID
                        orm_Office = null;
                    }
                    else
                    {
                        // office loaded, apply filter
                        if (!String.IsNullOrEmpty(Parameter.OrganizationalUnit))
                        {
                            if (!(orm_Office.Office_InternalName.ToLower().Contains(Parameter.OrganizationalUnit) ||
                                orm_Office.Office_Name.Contents.Any(i => i.Content.ToLower().Contains(Parameter.OrganizationalUnit))))
                            {
                                continue;
                            }
                        }
                    }
                }
                #endregion

                #endregion

                retValItem = new L5PP_GSHwDOfPfT_1013();
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

                retValItem.ORD_DIS_DistributionOrder_HeaderID = distributionOrderHeader.ORD_DIS_DistributionOrder_HeaderID;
                retValItem.DistributionOrderNumber = distributionOrderHeader.DistributionOrderNumber;
                retValItem.DistributionOrderDate = distributionOrderHeader.DistributionOrderDate;

                retValItem.CMN_STR_CostCenterID = orm_CostCenter.CMN_STR_CostCenterID;
                retValItem.CostCenterName = orm_CostCenter.Name;

                retValItem.CMN_STR_OfficeID = orm_Office != null ? orm_Office.CMN_STR_OfficeID : Guid.Empty;
                retValItem.OfficeInternalName = orm_Office != null ? orm_Office.Office_InternalName : String.Empty;

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
		public static FR_L5PP_GSHwDOfPfT_1013_Array Invoke(string ConnectionString,P_L5PP_GSHwDOfPfT_1013 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5PP_GSHwDOfPfT_1013_Array Invoke(DbConnection Connection,P_L5PP_GSHwDOfPfT_1013 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5PP_GSHwDOfPfT_1013_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5PP_GSHwDOfPfT_1013 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5PP_GSHwDOfPfT_1013_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5PP_GSHwDOfPfT_1013 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5PP_GSHwDOfPfT_1013_Array functionReturn = new FR_L5PP_GSHwDOfPfT_1013_Array();
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

				throw new Exception("Exception occured in method cls_Get_ShippmentHeaders_with_DistributionOrder_for_Picking_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5PP_GSHwDOfPfT_1013_Array : FR_Base
	{
		public L5PP_GSHwDOfPfT_1013[] Result	{ get; set; } 
		public FR_L5PP_GSHwDOfPfT_1013_Array() : base() {}

		public FR_L5PP_GSHwDOfPfT_1013_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
        #region SClass P_L5PP_GSHwDOfPfT_1013 for attribute P_L5PP_GSHwDOfPfT_1013
        [DataContract]
		public class P_L5PP_GSHwDOfPfT_1013 
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
			public String DistributionOrderNumber { get; set; } 
			[DataMember]
			public String ShipmentNumber { get; set; } 
			[DataMember]
			public DateTime? OrderDateFrom { get; set; } 
			[DataMember]
			public DateTime? OrderDateTo { get; set; } 
			[DataMember]
			public String OrganizationalUnit { get; set; } 
			[DataMember]
			public String CostCenter { get; set; } 
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
        #region SClass L5PP_GSHwDOfPfT_1013 for attribute L5PP_GSHwDOfPfT_1013
        [DataContract]
		public class L5PP_GSHwDOfPfT_1013 
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
			public Guid ORD_DIS_DistributionOrder_HeaderID { get; set; } 
			[DataMember]
			public String DistributionOrderNumber { get; set; } 
			[DataMember]
			public DateTime DistributionOrderDate { get; set; } 
			[DataMember]
			public Guid CMN_STR_CostCenterID { get; set; } 
			[DataMember]
			public Dict CostCenterName { get; set; } 
			[DataMember]
			public Guid CMN_STR_OfficeID { get; set; } 
			[DataMember]
			public String OfficeInternalName { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5SH_GSHfPfT_1013_Array cls_Get_ShippmentHeaders_with_DistributionOrder_for_Picking_for_TenantID(,P_L5SH_GSHfPfT_1013 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5SH_GSHfPfT_1013_Array invocationResult = cls_Get_ShippmentHeaders_with_DistributionOrder_for_Picking_for_TenantID.Invoke(connectionString,P_L5SH_GSHfPfT_1013 Parameter,securityTicket);
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
var parameter = new CL5_Zugseil_PickingPreparation.Complex.Retrieval.P_L5SH_GSHfPfT_1013();
parameter.NoPositionsFullyToPick = ...;
parameter.HasPositionsPartiallyToPick = ...;
parameter.IsReadyForPicking = ...;
parameter.IsInPickingProcess = ...;
parameter.DistributionOrderNumber = ...;
parameter.ShipmentNumber = ...;
parameter.OrderDateFrom = ...;
parameter.OrderDateTo = ...;
parameter.OrganizationalUnit = ...;
parameter.CostCenter = ...;
parameter.ShipmentCreationDateFrom = ...;
parameter.ShipmentCreationDateTo = ...;

*/
