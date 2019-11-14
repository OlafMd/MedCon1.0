/* 
 * Generated on 5/23/2014 6:06:11 PM
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
using DLCore_DBCommons.Utils;
using DLCore_DBCommons.APODemand;
using CL5_APOLogistic_ShippingOrder.Complex.Retrieval;
using CL5_APOLogistic_ShippingOrder.Utils;
using CL2_NumberRange.Complex.Retrieval;

namespace CL5_APOLogistic_ShippingOrder.Complex.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Split_ShipmentHeader_with_Positions.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Split_ShipmentHeader_with_Positions
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_L5SO_SSHwP_1030 Execute(DbConnection Connection, DbTransaction Transaction, P_L5SO_SSHwP_1030 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_L5SO_SSHwP_1030();
            returnValue.Result = new L5SO_SSHwP_1030();

            var oldShipmentHeader = new CL1_LOG_SHP.ORM_LOG_SHP_Shipment_Header();
            oldShipmentHeader.Load(Connection, Transaction, Parameter.HeaderID);

            var oldPositions = CL1_LOG_SHP.ORM_LOG_SHP_Shipment_Position.Query.Search(Connection, Transaction,
            new CL1_LOG_SHP.ORM_LOG_SHP_Shipment_Position.Query
            {
                LOG_SHP_Shipment_Header_RefID = Parameter.HeaderID,
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID
            });

            bool isThereAnyDifference = false;
            foreach (var item in Parameter.Positions)
            {
                var oldPosition = oldPositions.Single(x => x.LOG_SHP_Shipment_PositionID == item.PositionID);

                if (oldPosition.QuantityToShip > item.PickingQuantity)
                {
                    isThereAnyDifference = true;
                    break;
                }
            }

            if (!isThereAnyDifference)
            {
                throw new ShipmentHeaderException(ResultMessage.SplitShipment_ThereIsNoDifferenceBetweenNewAndOldOne);
            }

            #region Create New ShippmentHeader

            var incrNumberParam = new P_L2NR_GaIINfUA_1454()
            {
                GlobalStaticMatchingID = EnumUtils.GetEnumDescription(ENumberRangeUsageAreaType.ShipmentNumber)
            };
            var shipmentOrderNumber = cls_Get_and_Increase_IncreasingNumber_for_UsageArea.Invoke(Connection, Transaction, incrNumberParam, securityTicket).Result.Current_IncreasingNumber;


            var newShipmentHeader = new CL1_LOG_SHP.ORM_LOG_SHP_Shipment_Header();
            newShipmentHeader.LOG_SHP_Shipment_HeaderID = Guid.NewGuid();
            newShipmentHeader.ShipmentHeader_Number = shipmentOrderNumber;
            newShipmentHeader.Tenant_RefID = securityTicket.TenantID;
            newShipmentHeader.Creation_Timestamp = DateTime.Now;
            newShipmentHeader.IsPartialShippingAllowed = oldShipmentHeader.IsPartialShippingAllowed;
            newShipmentHeader.Shippipng_AddressUCD_RefID = oldShipmentHeader.Shippipng_AddressUCD_RefID;
            newShipmentHeader.Source_Warehouse_RefID = oldShipmentHeader.Source_Warehouse_RefID;
            newShipmentHeader.ShipmentPriority = oldShipmentHeader.ShipmentPriority;
            newShipmentHeader.ShipmentType_RefID = oldShipmentHeader.ShipmentType_RefID;

            newShipmentHeader.RecipientBusinessParticipant_RefID = oldShipmentHeader.RecipientBusinessParticipant_RefID;
            
            newShipmentHeader.Save(Connection, Transaction);

            var assignmentQuery = new CL1_LOG_SHP.ORM_LOG_SHP_ShipmentHeader_2_CustomerOrderHeader.Query();
            assignmentQuery.LOG_SHP_Shipment_Header_RefID = oldShipmentHeader.LOG_SHP_Shipment_HeaderID;
            assignmentQuery.IsDeleted = false;
            assignmentQuery.Tenant_RefID = securityTicket.TenantID;

            var oldAssignment = CL1_LOG_SHP.ORM_LOG_SHP_ShipmentHeader_2_CustomerOrderHeader.Query.Search(Connection, Transaction, assignmentQuery).Single();

            var shipmentToCustomerOrderHeader = new CL1_LOG_SHP.ORM_LOG_SHP_ShipmentHeader_2_CustomerOrderHeader();
            shipmentToCustomerOrderHeader.ORD_CUO_CustomerOrder_Header_RefID = oldAssignment.ORD_CUO_CustomerOrder_Header_RefID;
            shipmentToCustomerOrderHeader.LOG_SHP_Shipment_Header_RefID = newShipmentHeader.LOG_SHP_Shipment_HeaderID;
            shipmentToCustomerOrderHeader.Tenant_RefID = securityTicket.TenantID;
            shipmentToCustomerOrderHeader.Creation_Timestamp = DateTime.Now;
            shipmentToCustomerOrderHeader.Save(Connection, Transaction);

            #region Status

            var statusCreated = CL1_LOG_SHP.ORM_LOG_SHP_Shipment_Status.Query.Search(Connection, Transaction,
                 new CL1_LOG_SHP.ORM_LOG_SHP_Shipment_Status.Query()
                 {
                     GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(EShipmentStatus.Created),
                     Tenant_RefID = securityTicket.TenantID,
                     IsDeleted = false
                 }).Single();

            var account = new CL1_USR.ORM_USR_Account();
            account.Load(Connection, Transaction, securityTicket.AccountID);

            var shipmentStatusHistory = new CL1_LOG_SHP.ORM_LOG_SHP_Shipment_StatusHistory();
            shipmentStatusHistory.LOG_SHP_Shipment_Header_RefID = newShipmentHeader.LOG_SHP_Shipment_HeaderID;
            shipmentStatusHistory.LOG_SHP_Shipment_Status_RefID = statusCreated.LOG_SHP_Shipment_StatusID;
            shipmentStatusHistory.PerformedBy_BusinessParticipant_RefID = account.BusinessParticipant_RefID;
            shipmentStatusHistory.Tenant_RefID = account.Tenant_RefID;
            shipmentStatusHistory.Save(Connection, Transaction);

            #endregion

            #endregion

            var param = new P_L5SO_GSPwPaSfSH_1141()
            {
                ShippmentHeaderID = Parameter.HeaderID,
                LanguageID = Parameter.LanguageID
            };
            var splittingPositions = cls_Get_ShipmentPositions_with_Prices_and_Stock_for_ShipmentHeaderID.Invoke(Connection, Transaction, param, securityTicket).Result;

            decimal totalAmountForOldHeader = 0;
            decimal totalAmountForNewHeader = 0;
            foreach (var item in Parameter.Positions)
            {
                var oldPosition = oldPositions.Single(x => x.LOG_SHP_Shipment_PositionID == item.PositionID);

                var newQuantity = oldPosition.QuantityToShip - item.PickingQuantity;
                var positionToSplit = splittingPositions.Single(x => x.ShipmentPositionID == item.PositionID);
                var availableQuantity = positionToSplit.QuantityAvailable;

                decimal unitPrice = oldPosition.ShipmentPosition_PricePerUnitValueWithoutTax;

                if (item.PickingQuantity > availableQuantity + positionToSplit.ReservedQuantity)
                {
                    throw new ShipmentHeaderException(ResultMessage.SplitShipment_FreeQuantityNotAvailable);
                }

                if (newQuantity > 0)
                {
                    var newPosition = new CL1_LOG_SHP.ORM_LOG_SHP_Shipment_Position
                    {
                        LOG_SHP_Shipment_PositionID = Guid.NewGuid(),
                        LOG_SHP_Shipment_Header_RefID = newShipmentHeader.LOG_SHP_Shipment_HeaderID,
                        Tenant_RefID = securityTicket.TenantID,
                        CMN_PRO_Product_RefID = oldPosition.CMN_PRO_Product_RefID,
                        QuantityToShip = newQuantity,
                        ShipmentPosition_PricePerUnitValueWithoutTax = unitPrice,
                        ShipmentPosition_ValueWithoutTax = unitPrice * (decimal)newQuantity
                    };
                    newPosition.Save(Connection, Transaction);

                    totalAmountForNewHeader += newPosition.ShipmentPosition_ValueWithoutTax;

                    var oldAssignmentCustomerOrderToShipmentPosition = CL1_ORD_CUO.ORM_ORD_CUO_CustomerOrder_Position_2_ShipmentPosition.Query.Search(Connection, Transaction,
                        new CL1_ORD_CUO.ORM_ORD_CUO_CustomerOrder_Position_2_ShipmentPosition.Query
                        {
                            LOG_SHP_Shipment_Position_RefID = oldPosition.LOG_SHP_Shipment_PositionID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        }).Single();

                    var customerOrder2ShipmentPosition = new CL1_ORD_CUO.ORM_ORD_CUO_CustomerOrder_Position_2_ShipmentPosition
                    {
                        AssignmentID = Guid.NewGuid(),
                        Creation_Timestamp = DateTime.Now,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false,
                        LOG_SHP_Shipment_Position_RefID = newPosition.LOG_SHP_Shipment_PositionID,
                        ORD_CUO_CustomerOrder_Position_RefID = oldAssignmentCustomerOrderToShipmentPosition.ORD_CUO_CustomerOrder_Position_RefID,
                        CMN_BPT_CTM_OrganizationalUnit_RefID = oldAssignmentCustomerOrderToShipmentPosition.CMN_BPT_CTM_OrganizationalUnit_RefID
                    };
                    customerOrder2ShipmentPosition.Save(Connection, Transaction);
                }

                oldPosition.QuantityToShip = item.PickingQuantity;
                oldPosition.ShipmentPosition_ValueWithoutTax = unitPrice * (decimal)item.PickingQuantity;
                oldPosition.IsDeleted = (oldPosition.QuantityToShip == 0);

                oldPosition.Save(Connection, Transaction);

                totalAmountForOldHeader += oldPosition.ShipmentPosition_ValueWithoutTax;
            }

            oldShipmentHeader.ShipmentHeader_ValueWithoutTax = totalAmountForOldHeader;
            oldShipmentHeader.Save(Connection, Transaction);

            newShipmentHeader.ShipmentHeader_ValueWithoutTax = totalAmountForNewHeader;
            newShipmentHeader.Save(Connection, Transaction);

            // set return value to ok and new header's id
            returnValue.Result.NewHeaderID = newShipmentHeader.LOG_SHP_Shipment_HeaderID;
            returnValue.Result.Message = CL5_APOLogistic_ShippingOrder.Utils.ResultMessage.SplitShipment_OK;

            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_L5SO_SSHwP_1030 Invoke(string ConnectionString, P_L5SO_SSHwP_1030 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_L5SO_SSHwP_1030 Invoke(DbConnection Connection, P_L5SO_SSHwP_1030 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_L5SO_SSHwP_1030 Invoke(DbConnection Connection, DbTransaction Transaction, P_L5SO_SSHwP_1030 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_L5SO_SSHwP_1030 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_L5SO_SSHwP_1030 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_L5SO_SSHwP_1030 functionReturn = new FR_L5SO_SSHwP_1030();
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

                functionReturn = Execute(Connection, Transaction, Parameter, securityTicket);

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
                    if (cleanupTransaction == true && Transaction != null)
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

                throw new Exception("Exception occured in method cls_Split_ShipmentHeader_with_Positions", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Custom Return Type
    [Serializable]
    public class FR_L5SO_SSHwP_1030 : FR_Base
    {
        public L5SO_SSHwP_1030 Result { get; set; }

        public FR_L5SO_SSHwP_1030() : base() { }

        public FR_L5SO_SSHwP_1030(Exception ex) : base(ex) { }

    }
    #endregion

    #region Support Classes
    #region SClass P_L5SO_SSHwP_1030 for attribute P_L5SO_SSHwP_1030
    [DataContract]
    public class P_L5SO_SSHwP_1030
    {
        [DataMember]
        public P_L5SO_SSHwP_1030a[] Positions { get; set; }

        //Standard type parameters
        [DataMember]
        public Guid HeaderID { get; set; }
        [DataMember]
        public Guid LanguageID { get; set; }

    }
    #endregion
    #region SClass P_L5SO_SSHwP_1030a for attribute Positions
    [DataContract]
    public class P_L5SO_SSHwP_1030a
    {
        //Standard type parameters
        [DataMember]
        public Guid PositionID { get; set; }
        [DataMember]
        public double PickingQuantity { get; set; }

    }
    #endregion
    #region SClass L5SO_SSHwP_1030 for attribute L5SO_SSHwP_1030
    [DataContract]
    public class L5SO_SSHwP_1030
    {
        //Standard type parameters
        [DataMember]
        public Guid NewHeaderID { get; set; }
        [DataMember]
        public ResultMessage Message { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5SO_SSHwP_1030 cls_Split_ShipmentHeader_with_Positions(,P_L5SO_SSHwP_1030 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5SO_SSHwP_1030 invocationResult = cls_Split_ShipmentHeader_with_Positions.Invoke(connectionString,P_L5SO_SSHwP_1030 Parameter,securityTicket);
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
var parameter = new CL5_APOLogistic_ShippingOrder.Complex.Manipulation.P_L5SO_SSHwP_1030();
parameter.Positions = ...;

parameter.HeaderID = ...;
parameter.LanguageID = ...;

*/
