/* 
 * Generated on 11/5/2014 1:30:12 PM
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

namespace CL2_Shipment.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Shipment_Position.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Shipment_Position
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L2SH_SLSSP_1413 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_Guid();

            var item = new ORM_LOG_SHP_Shipment_Position();
            if (Parameter.LOG_SHP_Shipment_PositionID != Guid.Empty)
            {
                var result = item.Load(Connection, Transaction, Parameter.LOG_SHP_Shipment_PositionID);
            }

            if (Parameter.IsDeleted == true)
            {
                item.IsDeleted = true;
                return new FR_Guid(item.Save(Connection, Transaction), item.LOG_SHP_Shipment_PositionID);
            }

            //Creation specific parameters (Tenant, Account ... )
            if (Parameter.LOG_SHP_Shipment_PositionID == Guid.Empty)
            {
                item.Tenant_RefID = securityTicket.TenantID;
            }

            item.ShipmentPositionITL = Parameter.ShipmentPositionITL;
            item.LOG_SHP_Shipment_Header_RefID = Parameter.LOG_SHP_Shipment_Header_RefID;
            item.CMN_PRO_Product_RefID = Parameter.CMN_PRO_Product_RefID;
            item.CMN_PRO_ProductVariant_RefID = Parameter.CMN_PRO_ProductVariant_RefID;
            item.CMN_PRO_ProductRelease_RefID = Parameter.CMN_PRO_ProductRelease_RefID;
            item.TrackingInstance_ToShip_RefID = Parameter.TrackingInstance_ToShip_RefID;
            item.QuantityToShip = Parameter.QuantityToShip;
            item.ShipmentPosition_PricePerUnitValueWithoutTax = Parameter.ShipmentPosition_PricePerUnitValueWithoutTax;
            item.ShipmentPosition_ValueWithoutTax = Parameter.ShipmentPosition_PricePerUnitValueWithoutTax * Convert.ToDecimal(item.QuantityToShip);
            
            return new FR_Guid(item.Save(Connection, Transaction), item.LOG_SHP_Shipment_PositionID);
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L2SH_SLSSP_1413 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L2SH_SLSSP_1413 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L2SH_SLSSP_1413 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2SH_SLSSP_1413 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Shipment_Position",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L2SH_SLSSP_1413 for attribute P_L2SH_SLSSP_1413
		[DataContract]
		public class P_L2SH_SLSSP_1413 
		{
			//Standard type parameters
			[DataMember]
			public Guid LOG_SHP_Shipment_PositionID { get; set; } 
			[DataMember]
			public String ShipmentPositionITL { get; set; } 
			[DataMember]
			public Guid LOG_SHP_Shipment_Header_RefID { get; set; } 
			[DataMember]
			public Guid CMN_PRO_Product_RefID { get; set; } 
			[DataMember]
			public Guid CMN_PRO_ProductVariant_RefID { get; set; } 
			[DataMember]
			public Guid CMN_PRO_ProductRelease_RefID { get; set; } 
			[DataMember]
			public Guid TrackingInstance_ToShip_RefID { get; set; } 
			[DataMember]
			public Double QuantityToShip { get; set; } 
			[DataMember]
			public Decimal ShipmentPosition_PricePerUnitValueWithoutTax { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Shipment_Position(,P_L2SH_SLSSP_1413 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Shipment_Position.Invoke(connectionString,P_L2SH_SLSSP_1413 Parameter,securityTicket);
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
var parameter = new CL2_Shipment.Atomic.Manipulation.P_L2SH_SLSSP_1413();
parameter.LOG_SHP_Shipment_PositionID = ...;
parameter.ShipmentPositionITL = ...;
parameter.LOG_SHP_Shipment_Header_RefID = ...;
parameter.CMN_PRO_Product_RefID = ...;
parameter.CMN_PRO_ProductVariant_RefID = ...;
parameter.CMN_PRO_ProductRelease_RefID = ...;
parameter.TrackingInstance_ToShip_RefID = ...;
parameter.QuantityToShip = ...;
parameter.ShipmentPosition_PricePerUnitValueWithoutTax = ...;
parameter.IsDeleted = ...;

*/
