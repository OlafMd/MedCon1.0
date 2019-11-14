/* 
 * Generated on 3/27/2014 2:35:20 PM
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
using CL2_Shipment.Atomic.Manipulation;
using CL1_LOG_SHP;
using CL1_ORD_CUO;
using CL5_APOLogistic_ShippingOrder.Utils;
using CL3_Articles.Atomic.Retrieval;

namespace CL5_APOLogistic_ShippingOrder.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Add_ShipmentPosition_to_Header.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Add_ShipmentPosition_to_Header
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5SO_ASPtH_1405 Execute(DbConnection Connection,DbTransaction Transaction,P_L5SO_ASPtH_1405 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_L5SO_ASPtH_1405();

            var savedShipmentPositionID = cls_Save_Shipment_Position.Invoke(Connection, Transaction, Parameter.Position, securityTicket).Result;
                           
            #region Edit shipment header and position total values

            var shipmentPosition = CL1_LOG_SHP.ORM_LOG_SHP_Shipment_Position.Query.Search(Connection, Transaction, new ORM_LOG_SHP_Shipment_Position.Query
            {
                LOG_SHP_Shipment_PositionID = savedShipmentPositionID,
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID
            }).Single();


            shipmentPosition.ShipmentPosition_ValueWithoutTax = Parameter.Position.ShipmentPosition_PricePerUnitValueWithoutTax * Convert.ToDecimal(Parameter.Position.QuantityToShip);
            shipmentPosition.ShipmentPosition_PricePerUnitValueWithoutTax = Parameter.Position.ShipmentPosition_PricePerUnitValueWithoutTax;

            shipmentPosition.Save(Connection, Transaction);

            cls_Update_Current_TotalValue_on_ShipmentHeader_from_Positions.Invoke(Connection, Transaction, new P_L5SO_UCTVoSHfP_1549 { ShipmentHeaderID = Parameter.ShipmentHeaderID }, securityTicket);
          
            #endregion

            var randomShipmentPositionID = ORM_LOG_SHP_Shipment_Position.Query.Search(Connection, Transaction, new ORM_LOG_SHP_Shipment_Position.Query
            {
                LOG_SHP_Shipment_Header_RefID = Parameter.ShipmentHeaderID
            }).Select(i => i.LOG_SHP_Shipment_PositionID).Where(i => i != savedShipmentPositionID).First();

            var orgUnitID = ORM_ORD_CUO_CustomerOrder_Position_2_ShipmentPosition.Query.Search(Connection, Transaction, new ORM_ORD_CUO_CustomerOrder_Position_2_ShipmentPosition.Query()
            {
                LOG_SHP_Shipment_Position_RefID = randomShipmentPositionID

            }).Select(i => i.CMN_BPT_CTM_OrganizationalUnit_RefID).FirstOrDefault();

            //need this just for organizationalunits
            var customerPosition2ShipmentPosition = new ORM_ORD_CUO_CustomerOrder_Position_2_ShipmentPosition(){
            
                AssignmentID = Guid.NewGuid(),
                ORD_CUO_CustomerOrder_Position_RefID = Guid.Empty,
                LOG_SHP_Shipment_Position_RefID = savedShipmentPositionID,
                Creation_Timestamp = DateTime.Now,
                Tenant_RefID = securityTicket.TenantID,
                CMN_BPT_CTM_OrganizationalUnit_RefID = orgUnitID
            };

            customerPosition2ShipmentPosition.Save(Connection, Transaction);

            returnValue.Result = new L5SO_ASPtH_1405();
            returnValue.Result.AddedPosition = savedShipmentPositionID;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5SO_ASPtH_1405 Invoke(string ConnectionString,P_L5SO_ASPtH_1405 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5SO_ASPtH_1405 Invoke(DbConnection Connection,P_L5SO_ASPtH_1405 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5SO_ASPtH_1405 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5SO_ASPtH_1405 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5SO_ASPtH_1405 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5SO_ASPtH_1405 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5SO_ASPtH_1405 functionReturn = new FR_L5SO_ASPtH_1405();
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

				throw ex;
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5SO_ASPtH_1405 : FR_Base
	{
		public L5SO_ASPtH_1405 Result	{ get; set; }

		public FR_L5SO_ASPtH_1405() : base() {}

		public FR_L5SO_ASPtH_1405(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5SO_ASPtH_1405 for attribute P_L5SO_ASPtH_1405
		[DataContract]
		public class P_L5SO_ASPtH_1405 
		{
			//Standard type parameters
			[DataMember]
			public P_L2SH_SLSSP_1413 Position { get; set; } 
			[DataMember]
			public Guid ShipmentHeaderID { get; set; } 

		}
		#endregion
		#region SClass L5SO_ASPtH_1405 for attribute L5SO_ASPtH_1405
		[DataContract]
		public class L5SO_ASPtH_1405 
		{
			//Standard type parameters
			[DataMember]
			public Guid AddedPosition { get; set; } 

		}
		#endregion

	#endregion
}
