/* 
 * Generated on 26.06.2014 13:58:14
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
using CL3_Device.Atomic.Retrieval;
using CL5_MyHealthClub_Device.Atomic.Retrieval;

namespace CL6_MyHealthClub_Device.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_AllDeviceInstanceData_for_DeviceInstanceID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_AllDeviceInstanceData_for_DeviceInstanceID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6DE_GADDfDID_1155 Execute(DbConnection Connection,DbTransaction Transaction,P_L6DE_GADIDfDID_1155 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
            var returnValue = new FR_L6DE_GADDfDID_1155();
            returnValue.Result = new L6DE_GADDfDID_1155();
            returnValue.Result.BaseData = cls_Get_Device_for_DeviceInstanceID.Invoke(Connection, Transaction, new P_L3DE_GDfDIID_1452() { DeviceInstanceID = Parameter.DeviceInstanceID }, securityTicket).Result;
            returnValue.Result.OtherWorkTime = cls_Get_Device_Availability_for_DeviceID.Invoke(Connection, Transaction, new P_L5DE_GDAfDIID_1150() { DeviceInstanceID = Parameter.DeviceInstanceID }, securityTicket).Result;           
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6DE_GADDfDID_1155 Invoke(string ConnectionString,P_L6DE_GADIDfDID_1155 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6DE_GADDfDID_1155 Invoke(DbConnection Connection,P_L6DE_GADIDfDID_1155 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6DE_GADDfDID_1155 Invoke(DbConnection Connection, DbTransaction Transaction,P_L6DE_GADIDfDID_1155 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6DE_GADDfDID_1155 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6DE_GADIDfDID_1155 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6DE_GADDfDID_1155 functionReturn = new FR_L6DE_GADDfDID_1155();
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

				throw new Exception("Exception occured in method cls_Get_AllDeviceInstanceData_for_DeviceInstanceID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6DE_GADDfDID_1155 : FR_Base
	{
		public L6DE_GADDfDID_1155 Result	{ get; set; }

		public FR_L6DE_GADDfDID_1155() : base() {}

		public FR_L6DE_GADDfDID_1155(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6DE_GADIDfDID_1155 for attribute P_L6DE_GADIDfDID_1155
		[DataContract]
		public class P_L6DE_GADIDfDID_1155 
		{
			//Standard type parameters
			[DataMember]
			public Guid DeviceInstanceID { get; set; } 

		}
		#endregion
		#region SClass L6DE_GADDfDID_1155 for attribute L6DE_GADDfDID_1155
		[DataContract]
		public class L6DE_GADDfDID_1155 
		{
			//Standard type parameters
			[DataMember]
			public L3DE_GDfDIID_1452 BaseData { get; set; } 
			[DataMember]
			public L5DE_GDAfDIID_1150[] OtherWorkTime { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6DE_GADDfDID_1155 cls_Get_AllDeviceInstanceData_for_DeviceInstanceID(,P_L6DE_GADIDfDID_1155 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6DE_GADDfDID_1155 invocationResult = cls_Get_AllDeviceInstanceData_for_DeviceInstanceID.Invoke(connectionString,P_L6DE_GADIDfDID_1155 Parameter,securityTicket);
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
var parameter = new CL6_MyHealthClub_Device.Complex.Retrieval.P_L6DE_GADIDfDID_1155();
parameter.DeviceInstanceID = ...;

*/
