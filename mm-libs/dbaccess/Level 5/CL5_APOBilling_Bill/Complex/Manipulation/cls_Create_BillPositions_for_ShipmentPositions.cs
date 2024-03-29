/* 
 * Generated on 4/16/2014 6:05:40 PM
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
using CSV2Core.Core;
using System.Runtime.Serialization;

namespace CL5_APOBilling_Bill.Complex.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Create_BillPositions_for_ShipmentPositions.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Create_BillPositions_for_ShipmentPositions
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5BL_SBPfSP_1632 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
            #region UserCode
            var returnValue = new FR_Guid();

            // shipped status for tenant
            var statusParam = new CL5_APOBilling_Shipment.Atomic.Retrieval.P_L5SH_GSSfGPMaT_1700
            {
                GlobalPropertyMatchingID = DLCore_DBCommons.Utils.EnumUtils.GetEnumDescription(DLCore_DBCommons.APODemand.EShipmentStatus.Shipped)
            };
            var statusResult = CL5_APOBilling_Shipment.Atomic.Retrieval.cls_Get_Shipment_Status_for_GlobalPropertyMatchingID_and_TenantID.Invoke(Connection, Transaction, statusParam, securityTicket).Result;
            
            // Get bill positions for header ID
            var parameterBillPosition = new CL5_APOBilling_Bill.Atomic.Retrieval.P_L5BL_GBPfBH_1534();
            parameterBillPosition.BillHeaderID = Parameter.BillHeaderID;
            parameterBillPosition.ShipmentStatusID = statusResult.LOG_SHP_Shipment_StatusID;
            var alreadyAddedBillPositions = CL5_APOBilling_Bill.Atomic.Retrieval.cls_Get_BillPositions_for_BillHeader.Invoke(Connection, Transaction, parameterBillPosition, securityTicket).Result;
            
            // It must be the same RecipientBusinessParticipant_RefID for all bill positions on one header.
            if (alreadyAddedBillPositions.Select(x => x.RecipientBusinessParticipant_RefID).Distinct().ToList().Count > 1)
            {
                throw new ArgumentException(string.Format("There are duplicates for RecipientBusinessParticipant_RefID in database. BillHeaderID={1}", Parameter.BillHeaderID));
            }
            Guid recipientBusinessParticipantID = alreadyAddedBillPositions.Select(x => x.RecipientBusinessParticipant_RefID).Distinct().SingleOrDefault();

            var billHeader = new CL1_BIL.ORM_BIL_BillHeader();
            billHeader.Load(Connection, Transaction, Parameter.BillHeaderID);

            int positionCounter = 0;
            foreach (var id in Parameter.ShipmentPositions)
            {
                #region Find Shipment Position
                // Find Shipment Position
                var shipmentPosition = new CL1_LOG_SHP.ORM_LOG_SHP_Shipment_Position();
                shipmentPosition.Load(Connection, Transaction, id);

                // Check if Position is good
                if (shipmentPosition == null || shipmentPosition.LOG_SHP_Shipment_PositionID == Guid.Empty)
                    continue;

                #endregion

                #region Find Product and Taxes
                // Find Product
                var product = new CL1_CMN_PRO.ORM_CMN_PRO_Product();
                product.Load(Connection, Transaction, shipmentPosition.CMN_PRO_Product_RefID);

                // Find taxes
                var productTax = CL1_CMN_PRO.ORM_CMN_PRO_Product_SalesTaxAssignmnet.Query.Search(Connection, Transaction,
                    new CL1_CMN_PRO.ORM_CMN_PRO_Product_SalesTaxAssignmnet.Query
                    {
                        Product_RefID = product.CMN_PRO_ProductID,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).FirstOrDefault();

                var tax = new CL1_ACC_TAX.ORM_ACC_TAX_Tax();
                if (productTax != null)
                    tax.Load(Connection, Transaction, productTax.ApplicableSalesTax_RefID);
                else
                    tax = null;
                #endregion

                #region Find Bill Header and Shipment Header
                // Find Bill Header

                // Find Shipment Header
                var shipmentHeader =  new CL1_LOG_SHP.ORM_LOG_SHP_Shipment_Header();
                shipmentHeader.Load(Connection, Transaction, shipmentPosition.LOG_SHP_Shipment_Header_RefID);
                #endregion

                #region Check Bill Header status
                // Get status for bill header
                var statusCreated = CL1_BIL.ORM_BIL_BillStatus.Query.Search(Connection, Transaction,
                    new CL1_BIL.ORM_BIL_BillStatus.Query
                    {
                        GlobalPropertyMatchingID = DLCore_DBCommons.Utils.EnumUtils.GetEnumDescription(DLCore_DBCommons.APODemand.EBillStatus.Created),
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).Single();

                // Check current bill header status
                var billHeaderStatuses = CL1_BIL.ORM_BIL_BillHeader_2_BillStatus.Query.Search(Connection, Transaction,
                new CL1_BIL.ORM_BIL_BillHeader_2_BillStatus.Query
                {
                    BIL_BillHeader_RefID = billHeader.BIL_BillHeaderID,
                    IsCurrentStatus = true,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                });

                var billHeaderStatusesExists = billHeaderStatuses.Any(x => x.BIL_BillStatus_RefID == statusCreated.BIL_BillStatusID);

                // Throw exception if bill doesn't have a good status
                if (!billHeaderStatusesExists) throw new Exception("Bill header doesn't have created status!");
                #endregion

                #region Check does current bill position have the same customer
                // Check does current bill position have the same customer
                if (recipientBusinessParticipantID == Guid.Empty)
                {
                    recipientBusinessParticipantID = shipmentHeader.RecipientBusinessParticipant_RefID;
                }
                else
                {
                    if (recipientBusinessParticipantID != shipmentHeader.RecipientBusinessParticipant_RefID)
                        throw new ArgumentException("All Shipment positions must have the same RecipientBusinessParticipant_RefID");
                }
                #endregion

                #region Check does exist bill position for current order position
                bool exist = CL1_BIL.ORM_BIL_BillPosition_2_ShipmentPosition.Query.Exists(Connection, Transaction,
                    new CL1_BIL.ORM_BIL_BillPosition_2_ShipmentPosition.Query
                    {
                        LOG_SHP_Shipment_Position_RefID = shipmentPosition.LOG_SHP_Shipment_PositionID,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    });
                if (exist)
                {
                    throw new ArgumentException("There is already Bill position for some Shipment position");
                }
                #endregion

                #region Create Bill Position
                // Create Bill position for Customer order position
                var billPosition = new CL1_BIL.ORM_BIL_BillPosition();
                billPosition.BIL_BilHeader_RefID = billHeader.BIL_BillHeaderID;
                billPosition.BIL_BillPosition_Group_RefID = Guid.Empty;
                billPosition.ApplicableSalesTax_RefID = (tax != null ? tax.ACC_TAX_TaxeID : Guid.Empty);
                billPosition.PositionNumber = string.Empty;
                billPosition.BillPosition_Description = string.Empty;
                billPosition.BillPosition_Comment = string.Empty;
                billPosition.PositionIndex = positionCounter++;
                billPosition.PositionValue_BeforeTax = Convert.ToDecimal(shipmentPosition.ShipmentPosition_ValueWithoutTax);
                billPosition.PositionPricePerUnitValue_BeforeTax = shipmentPosition.ShipmentPosition_PricePerUnitValueWithoutTax;
                billPosition.PositionPricePerUnitValue_IncludingTax = DLUtils_Common.Calculations.MoneyUtils.CalculateGrossPriceForTaxInPercent(billPosition.PositionPricePerUnitValue_BeforeTax, Convert.ToDecimal(tax == null ? 0 : tax.TaxRate));
                billPosition.PositionValue_IncludingTax = billPosition.PositionPricePerUnitValue_IncludingTax * (decimal)shipmentPosition.QuantityToShip;
                billPosition.BillPosition_ProductNumber = product.Product_Number;
                billPosition.Quantity = (decimal)shipmentPosition.QuantityToShip;
                billPosition.Tenant_RefID = securityTicket.TenantID;
                billPosition.Creation_Timestamp = DateTime.Now;
                billPosition.Save(Connection, Transaction);

                // Create relationship between Bill position and Shipment position
                var billPosition2ShipmentPosition = new CL1_BIL.ORM_BIL_BillPosition_2_ShipmentPosition();
                billPosition2ShipmentPosition.BIL_BillPosition_RefID = billPosition.BIL_BillPositionID;
                billPosition2ShipmentPosition.LOG_SHP_Shipment_Position_RefID = shipmentPosition.LOG_SHP_Shipment_PositionID;
                billPosition2ShipmentPosition.Tenant_RefID = securityTicket.TenantID;
                billPosition2ShipmentPosition.Creation_Timestamp = DateTime.Now;
                billPosition2ShipmentPosition.Save(Connection, Transaction);

                // Change Bill Header total values
                billHeader.TotalValue_BeforeTax =  alreadyAddedBillPositions.Sum(x=> x.PositionValue_BeforeTax) + billPosition.PositionValue_BeforeTax;
                billHeader.TotalValue_IncludingTax = alreadyAddedBillPositions.Sum(x=> x.PositionValue_IncludingTax) + billPosition.PositionValue_IncludingTax;

                #endregion
            }

            // Save Bill Header with new total values
            billHeader.Save(Connection, Transaction);
            return new FR_Guid(Guid.NewGuid());
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_Guid Invoke(string ConnectionString,P_L5BL_SBPfSP_1632 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString,Parameter,securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection,P_L5BL_SBPfSP_1632 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null,Parameter,securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5BL_SBPfSP_1632 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null,Parameter,securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5BL_SBPfSP_1632 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_Guid functionReturn = new FR_Guid();
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

                throw new Exception("Exception occured in method cls_Create_BillPositions_for_ShipmentPositions",ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
        #region SClass P_L5BL_SBPfSP_1632 for attribute P_L5BL_SBPfSP_1632
        [DataContract]
        public class P_L5BL_SBPfSP_1632 
        {
            //Standard type parameters
            [DataMember]
            public Guid BillHeaderID { get; set; } 
            [DataMember]
            public Guid[] ShipmentPositions { get; set; } 

        }
        #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Create_BillPositions_for_ShipmentPositions(,P_L5BL_SBPfSP_1632 Parameter, string sessionToken = null)
{
    try
    {
        var securityTicket = Verify(sessionToken);
        FR_Guid invocationResult = cls_Create_BillPositions_for_ShipmentPositions.Invoke(connectionString,P_L5BL_SBPfSP_1632 Parameter,securityTicket);
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
var parameter = new CL5_APOBilling_Bill.Complex.Manipulation.P_L5BL_SBPfSP_1632();
parameter.BillHeaderID = ...;
parameter.ShipmentPositions = ...;

*/
