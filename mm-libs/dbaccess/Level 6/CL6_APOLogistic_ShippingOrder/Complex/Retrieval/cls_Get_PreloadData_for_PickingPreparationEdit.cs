/* 
 * Generated on 11/13/2014 11:58:15 AM
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
using CL6_APOLogistic_ShippingOrder.Atomic.Retrieval;
using CL5_APOLogistic_ShippingOrder.Atomic.Retrieval;
using CL5_APOLogistic_ShippingOrder.Complex.Retrieval;

namespace CL6_APOLogistic_ShippingOrder.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_PreloadData_for_PickingPreparationEdit.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_PreloadData_for_PickingPreparationEdit
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6SO_GPDfPPE_1456 Execute(DbConnection Connection,DbTransaction Transaction,P_L6SO_GPDfPPE_1456 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L6SO_GPDfPPE_1456();

            #region ExtendedShipmentHeaderDetails
            returnValue.Result = new L6SO_GPDfPPE_1456();
            P_L5SO_GSaCOHDfSH_1446 headerDetailsGetParam = new P_L5SO_GSaCOHDfSH_1446();
            headerDetailsGetParam.ShippingHeaderID = Parameter.ShipmentHeaderID;

            returnValue.Result.ExtendedShipmentHeaderDetails = cls_Get_Shipment_and_CustomerOrderHeaderDetails_for_ShipmentHeaderID.Invoke(Connection, Transaction, headerDetailsGetParam, securityTicket).Result;
            #endregion

            #region OrganizationalUnit
            var organizationalUnits = cls_Get_OrganizationalUnit_for_ShipmentHeaderID.Invoke(Connection, Transaction, new P_L5SO_GOUfSH_1157 { ShippingHeaderID = Parameter.ShipmentHeaderID }, securityTicket).Result;

            if (organizationalUnits.Count() >= 1)
            {
                returnValue.Result.OrganizationalUnit = organizationalUnits.First();
            }
            else
            {
                returnValue.Result.OrganizationalUnit = new L5OS_GOUfSH_1157();
            }

            #endregion

            #region Address

		    var addressForSHHeaderID =
		        cls_Get_Address_for_ShipmentHeaderID.Invoke(Connection, Transaction,
		            new P_L6SO_GAfSHI_1435 {ShipmentHeaderID = Parameter.ShipmentHeaderID}, securityTicket).Result;

		    if (addressForSHHeaderID != null)
		        returnValue.Result.AddressForHeader = addressForSHHeaderID;

            #endregion

            #region ShipmentPositions

            P_L5SO_GSPwPaSfSH_1141 shipmentPositionsParam = new P_L5SO_GSPwPaSfSH_1141()
            {
                ShippmentHeaderID = Parameter.ShipmentHeaderID,
                LanguageID = Parameter.LanguageID
            };

            var shipmentPositions = cls_Get_ShipmentPositions_with_Prices_and_Stock_for_ShipmentHeaderID.Invoke(Connection, Transaction, shipmentPositionsParam, securityTicket).Result;
            returnValue.Result.ShipmentPositions = shipmentPositions;
            
            #endregion

            #region UnexecutedReservation

            if (shipmentPositions != null && shipmentPositions.Count() != 0)
            {
                P_L6SO_GAURfPL_1149 reservationParam = new P_L6SO_GAURfPL_1149()
                {
                    ProductID = shipmentPositions.Select(x => x.CMN_PRO_ProductID).ToArray()
                };

                var unexecutedReservation = cls_Get_All_Unexecuted_Reservation_for_ProductList.Invoke(Connection, Transaction, reservationParam, securityTicket);
                returnValue.Result.UnexecutedReservation = unexecutedReservation.Result.ToArray();
            }
            else 
            { 
                returnValue.Result.UnexecutedReservation = new L6SO_GAURfPL_1149[0];
            }
            
            #endregion

            #region CustomerOrderPosition

            var customerOrderPosition = cls_Get_CustomerOrderPosition_for_ShipmentPositionList.Invoke(
                Connection, 
                Transaction, 
                new P_L6SO_GCOPfSPL_1152 { 
                    ShipmentPositionID = shipmentPositions.Select(x => x.ShipmentPositionID).ToArray()
                },
                securityTicket).Result;

            returnValue.Result.CustomerOrderPosition = customerOrderPosition;

            #endregion

            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6SO_GPDfPPE_1456 Invoke(string ConnectionString,P_L6SO_GPDfPPE_1456 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6SO_GPDfPPE_1456 Invoke(DbConnection Connection,P_L6SO_GPDfPPE_1456 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6SO_GPDfPPE_1456 Invoke(DbConnection Connection, DbTransaction Transaction,P_L6SO_GPDfPPE_1456 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6SO_GPDfPPE_1456 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6SO_GPDfPPE_1456 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6SO_GPDfPPE_1456 functionReturn = new FR_L6SO_GPDfPPE_1456();
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

				throw new Exception("Exception occured in method cls_Get_PreloadData_for_PickingPreparationEdit",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6SO_GPDfPPE_1456 : FR_Base
	{
		public L6SO_GPDfPPE_1456 Result	{ get; set; }

		public FR_L6SO_GPDfPPE_1456() : base() {}

		public FR_L6SO_GPDfPPE_1456(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6SO_GPDfPPE_1456 for attribute P_L6SO_GPDfPPE_1456
		[DataContract]
		public class P_L6SO_GPDfPPE_1456 
		{
			//Standard type parameters
			[DataMember]
			public Guid ShipmentHeaderID { get; set; } 
			[DataMember]
			public Guid LanguageID { get; set; } 

		}
		#endregion
		#region SClass L6SO_GPDfPPE_1456 for attribute L6SO_GPDfPPE_1456
		[DataContract]
		public class L6SO_GPDfPPE_1456 
		{
			//Standard type parameters
			[DataMember]
			public L5SO_GSaCOHDfSH_1446 ExtendedShipmentHeaderDetails { get; set; } 
			[DataMember]
			public L5OS_GOUfSH_1157 OrganizationalUnit { get; set; } 
			[DataMember]
			public L6SO_GAfSHI_1435 AddressForHeader { get; set; } 
			[DataMember]
			public L5SO_GSPwPaSfSH_1141[] ShipmentPositions { get; set; } 
			[DataMember]
			public L6SO_GAURfPL_1149[] UnexecutedReservation { get; set; } 
			[DataMember]
			public L6SO_GCOPfSPL_1152[] CustomerOrderPosition { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6SO_GPDfPPE_1456 cls_Get_PreloadData_for_PickingPreparationEdit(,P_L6SO_GPDfPPE_1456 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6SO_GPDfPPE_1456 invocationResult = cls_Get_PreloadData_for_PickingPreparationEdit.Invoke(connectionString,P_L6SO_GPDfPPE_1456 Parameter,securityTicket);
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
var parameter = new CL6_APOLogistic_ShippingOrder.Complex.Retrieval.P_L6SO_GPDfPPE_1456();
parameter.ShipmentHeaderID = ...;
parameter.LanguageID = ...;

*/
