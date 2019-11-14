/* 
 * Generated on 3/10/2014 12:16:33 PM
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
using CL1_USR;
using DLCore_DBCommons.Utils;
using DLCore_DBCommons.APODemand;

namespace CL2_Shipment.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_ShipmentStatusHistory.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_ShipmentStatusHistory
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L2SH_SSSH_1210 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            var account = new ORM_USR_Account();
            account.Load(Connection, Transaction, securityTicket.AccountID);

            var statusPickingFinished = CL1_LOG_SHP.ORM_LOG_SHP_Shipment_Status.Query.Search(Connection, Transaction,
            new CL1_LOG_SHP.ORM_LOG_SHP_Shipment_Status.Query()
            {
                GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(Parameter.ShipmentHeaderStatus),
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).Single();

            var shipmentStatusHistory = new CL1_LOG_SHP.ORM_LOG_SHP_Shipment_StatusHistory();
            shipmentStatusHistory.LOG_SHP_Shipment_Header_RefID = Parameter.ShipmentHeaderID;
            shipmentStatusHistory.LOG_SHP_Shipment_Status_RefID = statusPickingFinished.LOG_SHP_Shipment_StatusID;
            shipmentStatusHistory.PerformedBy_BusinessParticipant_RefID = account.BusinessParticipant_RefID;
            shipmentStatusHistory.Tenant_RefID = securityTicket.TenantID;
            shipmentStatusHistory.Save(Connection, Transaction);
           
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L2SH_SSSH_1210 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L2SH_SSSH_1210 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L2SH_SSSH_1210 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2SH_SSSH_1210 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_ShipmentStatusHistory",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L2SH_SSSH_1210 for attribute P_L2SH_SSSH_1210
		[DataContract]
		public class P_L2SH_SSSH_1210 
		{
			//Standard type parameters
			[DataMember]
			public Guid ShipmentHeaderID { get; set; } 
			[DataMember]
			public EShipmentStatus ShipmentHeaderStatus { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_ShipmentStatusHistory(,P_L2SH_SSSH_1210 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_ShipmentStatusHistory.Invoke(connectionString,P_L2SH_SSSH_1210 Parameter,securityTicket);
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
var parameter = new CL2_Shipment.Atomic.Manipulation.P_L2SH_SSSH_1210();
parameter.ShipmentHeaderID = ...;
parameter.ShipmentHeaderStatus = ...;

*/
