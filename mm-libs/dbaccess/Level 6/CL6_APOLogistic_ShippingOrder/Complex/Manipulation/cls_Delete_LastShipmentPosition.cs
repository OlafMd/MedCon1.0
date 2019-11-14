/* 
 * Generated on 3/15/2014 3:58:47 PM
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
using CL5_APOLogistic_ShippingOrder.Complex.Manipulation;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;
using System.Runtime.Serialization;
using CL5_APOLogistic_ShippingOrder.Atomic.Manipulation;
using CL1_LOG_SHP;
using CL1_LOG_RSV;
using CL1_LOG_WRH;
using CL1_LOG;

namespace CL6_APOLogistic_ShippingOrder.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Finish_PickingControl.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
    public class cls_Delete_LastShipmentPosition
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
        protected static FR_Guid Execute(DbConnection Connection, DbTransaction Transaction, P_L6SO_DLSP_1535 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Guid();

            // delete position

            P_L5SO_DSP_1449 deleteShipmentParam = new P_L5SO_DSP_1449();
            deleteShipmentParam.ShipmentHeaderID = Parameter.Shipment_HeaderID;
            deleteShipmentParam.PositionID = Parameter.PositionID;
            cls_Delete_ShipmentPosition.Invoke(Connection, Transaction, deleteShipmentParam, securityTicket);


            // delete status
            P_L5SO_CSOS_1148 parameterStatus = new P_L5SO_CSOS_1148();
            parameterStatus.IsDeleted = true;
            parameterStatus.LOG_SHP_Shipment_HeaderID = Parameter.Shipment_HeaderID;
            cls_Change_ShippigOrderHeader_Status.Invoke(Connection, Transaction, parameterStatus, securityTicket);



            // delete header

            P_L5SO_DSH_1440 deleteShipmentHeaderParam = new P_L5SO_DSH_1440();
            deleteShipmentHeaderParam.ShipmentHeaderID = Parameter.Shipment_HeaderID;
            cls_Delete_ShipmentHeader.Invoke(Connection, Transaction, deleteShipmentHeaderParam, securityTicket);




            return returnValue;

            #endregion UserCode
        }
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
        public static FR_Guid Invoke(string ConnectionString, P_L6SO_DLSP_1535 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
        public static FR_Guid Invoke(DbConnection Connection, P_L6SO_DLSP_1535 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
        public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, P_L6SO_DLSP_1535 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
        protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_L6SO_DLSP_1535 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Finish_PickingControl",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
    #region SClass P_L6SO_DLSP_1535 for attribute P_L6SO_DLSP_1535
    [DataContract]
    public class P_L6SO_DLSP_1535 
		{
			//Standard type parameters

            [DataMember]
            public Guid PositionID { get; set; }

			[DataMember]
			public Guid Shipment_HeaderID { get; set; }


		}
		#endregion

	#endregion
}


