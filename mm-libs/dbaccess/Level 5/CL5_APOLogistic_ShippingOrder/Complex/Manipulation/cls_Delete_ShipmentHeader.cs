/* 
 * Generated on 8/20/2014 8:35:06 AM
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
using CL1_LOG_SHP;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;
using System.Runtime.Serialization;

namespace CL5_APOLogistic_ShippingOrder.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Delete_ShipmentHeader.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Delete_ShipmentHeader
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5SO_DSH_1440 Execute(DbConnection Connection,DbTransaction Transaction,P_L5SO_DSH_1440 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_L5SO_DSH_1440();
			//Put your code here

            ORM_LOG_SHP_Shipment_Header shipmentHeaderToDelate = new ORM_LOG_SHP_Shipment_Header();
		    shipmentHeaderToDelate.Load(Connection, Transaction, Parameter.ShipmentHeaderID);

		    shipmentHeaderToDelate.Remove(Connection, Transaction);

            returnValue.Result = new L5SO_DSH_1440();
		    returnValue.Result.DeletedHeader = Parameter.ShipmentHeaderID;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5SO_DSH_1440 Invoke(string ConnectionString,P_L5SO_DSH_1440 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5SO_DSH_1440 Invoke(DbConnection Connection,P_L5SO_DSH_1440 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5SO_DSH_1440 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5SO_DSH_1440 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5SO_DSH_1440 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5SO_DSH_1440 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5SO_DSH_1440 functionReturn = new FR_L5SO_DSH_1440();
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

				throw new Exception("Exception occured in method cls_Delete_ShipmentHeader",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5SO_DSH_1440 : FR_Base
	{
		public L5SO_DSH_1440 Result	{ get; set; }

		public FR_L5SO_DSH_1440() : base() {}

		public FR_L5SO_DSH_1440(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5SO_DSH_1440 for attribute P_L5SO_DSH_1440
		[DataContract]
		public class P_L5SO_DSH_1440 
		{
			//Standard type parameters
			[DataMember]
			public Guid ShipmentHeaderID { get; set; } 

		}
		#endregion
		#region SClass L5SO_DSH_1440 for attribute L5SO_DSH_1440
		[DataContract]
		public class L5SO_DSH_1440 
		{
			//Standard type parameters
			[DataMember]
			public Guid DeletedHeader { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5SO_DSH_1440 cls_Delete_ShipmentHeader(,P_L5SO_DSH_1440 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5SO_DSH_1440 invocationResult = cls_Delete_ShipmentHeader.Invoke(connectionString,P_L5SO_DSH_1440 Parameter,securityTicket);
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
var parameter = new CL5_APOLogistic_ShippingOrder.Complex.Manipulation.P_L5SO_DSH_1440();
parameter.ShipmentHeaderID = ...;

*/
