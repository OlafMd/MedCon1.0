/* 
 * Generated on 3/27/2014 2:30:46 PM
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
using CL1_LOG_RSV;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;
using System.Runtime.Serialization;
using CL1_LOG_SHP;
using CL1_ORD_CUO;
using CL5_APOLogistic_ShippingOrder.Utils;

namespace CL5_APOLogistic_ShippingOrder.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Delete_ShipmentPosition.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Delete_ShipmentPosition
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5SO_DSP_1449 Execute(DbConnection Connection,DbTransaction Transaction,P_L5SO_DSP_1449 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5SO_DSP_1449();

            //get shipment position by ID
            CL1_LOG_SHP.ORM_LOG_SHP_Shipment_Position shipmentPositionToDelete = new ORM_LOG_SHP_Shipment_Position();
            shipmentPositionToDelete.Load(Connection, Transaction, Parameter.PositionID);


		    ORM_LOG_RSV_Reservation.Query.SoftDelete(Connection, Transaction,
		        new ORM_LOG_RSV_Reservation.Query
		        {
                    LOG_SHP_Shipment_Position_RefID = shipmentPositionToDelete.LOG_SHP_Shipment_PositionID,
                    IsDeleted = false
		        });

		    
            //remove shipment position
            shipmentPositionToDelete.Remove(Connection, Transaction);

            // update header total value
             cls_Update_Current_TotalValue_on_ShipmentHeader_from_Positions.Invoke(Connection, Transaction, new P_L5SO_UCTVoSHfP_1549 { ShipmentHeaderID = Parameter.ShipmentHeaderID }, securityTicket);

            returnValue.Result = new L5SO_DSP_1449();
            returnValue.Result.DeletedPosition = Parameter.PositionID;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5SO_DSP_1449 Invoke(string ConnectionString,P_L5SO_DSP_1449 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5SO_DSP_1449 Invoke(DbConnection Connection,P_L5SO_DSP_1449 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5SO_DSP_1449 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5SO_DSP_1449 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5SO_DSP_1449 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5SO_DSP_1449 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5SO_DSP_1449 functionReturn = new FR_L5SO_DSP_1449();
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
	public class FR_L5SO_DSP_1449 : FR_Base
	{
		public L5SO_DSP_1449 Result	{ get; set; }

		public FR_L5SO_DSP_1449() : base() {}

		public FR_L5SO_DSP_1449(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5SO_DSP_1449 for attribute P_L5SO_DSP_1449
		[DataContract]
		public class P_L5SO_DSP_1449 
		{
			//Standard type parameters
			[DataMember]
			public Guid PositionID { get; set; } 
			[DataMember]
			public Guid ShipmentHeaderID { get; set; } 

		}
		#endregion
		#region SClass L5SO_DSP_1449 for attribute L5SO_DSP_1449
		[DataContract]
		public class L5SO_DSP_1449 
		{
			//Standard type parameters
			[DataMember]
			public Guid DeletedPosition { get; set; } 

		}
		#endregion

	#endregion
}
