/* 
 * Generated on 4/11/2014 5:47:14 PM
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
using System.Runtime.Serialization;
using CL5_APOBackoffice_CustomerOrder.Atomic.Retrieval;
using CL1_ORD_CUO;
using CL1_LOG_SHP;

namespace CL5_APOBackoffice_CustomerOrder.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Create_ShipmentHeader_with_Positions.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Create_ShipmentHeader_with_Positions
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Base Execute(DbConnection Connection,DbTransaction Transaction,P_L5CO_CSHwP_1519 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_Base();
            
            #region Get CustomerOrderPositions 

            var param = new P_L5CO_GACOPaOUDfCH_1623(){
                CustomerOrderHeaderID = Parameter.CustomerOrderHeaderID
            };
            var customerOrderPositions = cls_Get_AllCustomerOrderPositions_and_OrganizationalUnitDistributions_for_CustomerOrderHeaderID.Invoke(Connection, Transaction, param, securityTicket ).Result;

            #endregion

            #region Create ShipmentHeaders

            var orgUnit2ShipmentHeader = new Dictionary<Guid, Guid>();

            var allOrganizationalUnitsInOrder = customerOrderPositions.SelectMany(i=>i.OrgUnitAssigments).Select(j=>j.CMN_BPT_CTM_OrganizationalUnit_RefID).Distinct();
           
            foreach(var organizationalUnits in allOrganizationalUnitsInOrder){
            
                var shipmentHeaderParam = new P_L5CO_CSHfCO_1528(){
                    CustomerOrderHeaderID = Parameter.CustomerOrderHeaderID
                };

                var shipmentHeaderID = cls_Create_ShipmentHeader_for_CustomerOrderID.Invoke(Connection, Transaction, shipmentHeaderParam, securityTicket).Result;

                orgUnit2ShipmentHeader.Add(organizationalUnits, shipmentHeaderID);
            }
            
            #endregion

            #region Positions

            if (customerOrderPositions != null)
            {
                foreach (var position in customerOrderPositions)
                {
                    #region Orders for office

                    foreach (var item in position.OrgUnitAssigments)
                    {
                        var shippmentHeaderID = orgUnit2ShipmentHeader[item.CMN_BPT_CTM_OrganizationalUnit_RefID];

                        var shipmentPosition = new CL1_LOG_SHP.ORM_LOG_SHP_Shipment_Position
                        {
                            LOG_SHP_Shipment_PositionID = Guid.NewGuid(),
                            LOG_SHP_Shipment_Header_RefID = shippmentHeaderID,
                            CMN_PRO_Product_RefID = position.CMN_PRO_Product_RefID,
                            Tenant_RefID = securityTicket.TenantID,
                            Creation_Timestamp = DateTime.Now,
                            QuantityToShip = item.Quantity,
                            ShipmentPosition_PricePerUnitValueWithoutTax = position.Position_ValuePerUnit,
                            ShipmentPosition_ValueWithoutTax = (decimal)item.Quantity * position.Position_ValuePerUnit
                        };
                        shipmentPosition.Save(Connection, Transaction);

                        var customerOrderToShipmentPosition= new CL1_ORD_CUO.ORM_ORD_CUO_CustomerOrder_Position_2_ShipmentPosition
                        {
                            AssignmentID = Guid.NewGuid(),
                            Creation_Timestamp = DateTime.Now,
                            Tenant_RefID = securityTicket.TenantID,
                            LOG_SHP_Shipment_Position_RefID = shipmentPosition.LOG_SHP_Shipment_PositionID,
                            ORD_CUO_CustomerOrder_Position_RefID = position.ORD_CUO_CustomerOrder_PositionID,
                            CMN_BPT_CTM_OrganizationalUnit_RefID = item.CMN_BPT_CTM_OrganizationalUnit_RefID ,
                            IsDeleted = false
                        };
                        customerOrderToShipmentPosition.Save(Connection, Transaction);

                        #region Update ShipmentHeader

                        var shipmentHeader = new CL1_LOG_SHP.ORM_LOG_SHP_Shipment_Header();
                        shipmentHeader.Load(Connection, Transaction, shippmentHeaderID);

                        shipmentHeader.ShipmentHeader_ValueWithoutTax += shipmentPosition.ShipmentPosition_ValueWithoutTax;
                        shipmentHeader.Save(Connection, Transaction);

                        #endregion
                    }

                    #endregion

                    #region Orders for company

                    var quantitiesForOffices = position.OrgUnitAssigments.Sum(i=>i.Quantity);
                    var quantitiesForCompany = position.Position_Quantity - quantitiesForOffices;

                    if(quantitiesForCompany>0){

                        var shippmentHeaderID = Guid.Empty;
                        var containsOrderCompany =  orgUnit2ShipmentHeader.ContainsKey(Guid.Empty);

                        if (!containsOrderCompany)
                        {
                            var shipmentHeaderParam = new P_L5CO_CSHfCO_1528(){
                                CustomerOrderHeaderID = Parameter.CustomerOrderHeaderID
                            };

                            shippmentHeaderID = cls_Create_ShipmentHeader_for_CustomerOrderID.Invoke(Connection, Transaction, shipmentHeaderParam, securityTicket).Result;
                            orgUnit2ShipmentHeader.Add(Guid.Empty, shippmentHeaderID);
                        }

                        shippmentHeaderID = orgUnit2ShipmentHeader[Guid.Empty];

                        var shipmentPosition = new CL1_LOG_SHP.ORM_LOG_SHP_Shipment_Position
                        {
                            LOG_SHP_Shipment_PositionID = Guid.NewGuid(),
                            LOG_SHP_Shipment_Header_RefID = shippmentHeaderID,
                            CMN_PRO_Product_RefID = position.CMN_PRO_Product_RefID,
                            Tenant_RefID = securityTicket.TenantID,
                            Creation_Timestamp = DateTime.Now,
                            QuantityToShip = quantitiesForCompany,
                            ShipmentPosition_PricePerUnitValueWithoutTax = position.Position_ValuePerUnit,
                            ShipmentPosition_ValueWithoutTax = (decimal)quantitiesForCompany * position.Position_ValuePerUnit
                        };
                        shipmentPosition.Save(Connection, Transaction);

                        var customerOrderToShipmentPosition= new CL1_ORD_CUO.ORM_ORD_CUO_CustomerOrder_Position_2_ShipmentPosition
                        {
                            AssignmentID = Guid.NewGuid(),
                            Creation_Timestamp = DateTime.Now,
                            Tenant_RefID = securityTicket.TenantID,
                            LOG_SHP_Shipment_Position_RefID = shipmentPosition.LOG_SHP_Shipment_PositionID,
                            ORD_CUO_CustomerOrder_Position_RefID = position.ORD_CUO_CustomerOrder_PositionID,
                            CMN_BPT_CTM_OrganizationalUnit_RefID = Guid.Empty 
                        };
                        customerOrderToShipmentPosition.Save(Connection, Transaction);

                        #region Update ShipmentHeader

                        var shipmentHeader = new CL1_LOG_SHP.ORM_LOG_SHP_Shipment_Header();
                        shipmentHeader.Load(Connection, Transaction, shippmentHeaderID);

                        shipmentHeader.ShipmentHeader_ValueWithoutTax += shipmentPosition.ShipmentPosition_ValueWithoutTax;
                        shipmentHeader.Save(Connection, Transaction);

                        #endregion
                    }

                    #endregion
                }
            }

            #endregion

            #region Comments

            var allOrgUnitIDs = orgUnit2ShipmentHeader.Select( x => x.Key );

            foreach(var orgUnitID in allOrgUnitIDs){

                var currentShipmentID = orgUnit2ShipmentHeader[orgUnitID];

                var custOrderNotes = ORM_ORD_CUO_CustomerOrder_Note.Query.Search(Connection, Transaction, new ORM_ORD_CUO_CustomerOrder_Note.Query()
                    {
                        CustomerOrder_Header_RefID = Parameter.CustomerOrderHeaderID,
                        CMN_BPT_CTM_OrganizationalUnit_RefID = orgUnitID,
                        IsDeleted = false
                    }
                );

                foreach (var custOrderNote in custOrderNotes)
                {
                    var shipmentHeader = new CL1_LOG_SHP.ORM_LOG_SHP_Shipment_Header();
                    shipmentHeader.Load(Connection,Transaction, currentShipmentID);

                    var shipmentNote = new ORM_LOG_SHP_Shipment_Note()
                    {
                        LOG_SHP_Shipment_NoteID = Guid.NewGuid(),
                        Shipment_Header_RefID = currentShipmentID,
                        Shipment_Position_RefID = Guid.Empty,
                        IsNotePrintedOnDeliveryPaper = true,
                        Title = custOrderNote.Title,
                        Comment = custOrderNote.Comment,
                        NotePublishDate = custOrderNote.NotePublishDate,
                        SequenceOrderNumber = custOrderNote.SequenceOrderNumber,
                        Creation_Timestamp = DateTime.Now,
                        Tenant_RefID = securityTicket.TenantID,
                        CreatedBy_BusinessParticipant_RefID = shipmentHeader.RecipientBusinessParticipant_RefID
                    };

                    shipmentNote.Save(Connection, Transaction);
                }
            }
            
            #endregion 

            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Base Invoke(string ConnectionString,P_L5CO_CSHwP_1519 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection,P_L5CO_CSHwP_1519 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction,P_L5CO_CSHwP_1519 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5CO_CSHwP_1519 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Base functionReturn = new FR_Base();
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

				throw new Exception("Exception occured in method cls_Create_ShipmentHeader_with_Positions",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5CO_CSHwP_1519 for attribute P_L5CO_CSHwP_1519
		[DataContract]
		public class P_L5CO_CSHwP_1519 
		{
			//Standard type parameters
			[DataMember]
			public Guid CustomerOrderHeaderID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Base cls_Create_ShipmentHeader_with_Positions(,P_L5CO_CSHwP_1519 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Base invocationResult = cls_Create_ShipmentHeader_with_Positions.Invoke(connectionString,P_L5CO_CSHwP_1519 Parameter,securityTicket);
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
var parameter = new CL5_APOBackoffice_CustomerOrder.Complex.Manipulation.P_L5CO_CSHwP_1519();
parameter.CustomerOrderHeaderID = ...;

*/
