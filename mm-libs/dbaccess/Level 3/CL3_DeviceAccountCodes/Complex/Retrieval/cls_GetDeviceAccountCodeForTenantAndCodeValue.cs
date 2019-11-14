/* 
 * Generated on 8/30/2013 10:11:21 AM
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

namespace CL3_DeviceAccountCodes.Complex.Retrieval
{
	/// <summary>
    /// 
      
    
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_GetDeviceAccountCodeForTenantAndCodeValue.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_GetDeviceAccountCodeForTenantAndCodeValue
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3DAC_GDACFTCV_1616 Execute(DbConnection Connection,DbTransaction Transaction,P_L3DAC_GDACFTCV_1616 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_L3DAC_GDACFTCV_1616();
			//Put your code here
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3DAC_GDACFTCV_1616 Invoke(string ConnectionString,P_L3DAC_GDACFTCV_1616 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3DAC_GDACFTCV_1616 Invoke(DbConnection Connection,P_L3DAC_GDACFTCV_1616 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3DAC_GDACFTCV_1616 Invoke(DbConnection Connection, DbTransaction Transaction,P_L3DAC_GDACFTCV_1616 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3DAC_GDACFTCV_1616 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3DAC_GDACFTCV_1616 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3DAC_GDACFTCV_1616 functionReturn = new FR_L3DAC_GDACFTCV_1616();
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

				throw new Exception("Exception occured in method cls_GetDeviceAccountCodeForTenantAndCodeValue",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3DAC_GDACFTCV_1616 : FR_Base
	{
		public L3DAC_GDACFTCV_1616 Result	{ get; set; }

		public FR_L3DAC_GDACFTCV_1616() : base() {}

		public FR_L3DAC_GDACFTCV_1616(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3DAC_GDACFTCV_1616 for attribute P_L3DAC_GDACFTCV_1616
		[DataContract]
		public class P_L3DAC_GDACFTCV_1616 
		{
			//Standard type parameters
			[DataMember]
			public string CodeValue { get; set; } 

		}
		#endregion
		#region SClass L3DAC_GDACFTCV_1616 for attribute L3DAC_GDACFTCV_1616
		[DataContract]
		public class L3DAC_GDACFTCV_1616 
		{
			//Standard type parameters
			[DataMember]
			public Guid USR_Device_AccountCodeID { get; set; } 
			[DataMember]
			public DateTime AccountCode_ValidFrom { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3DAC_GDACFTCV_1616 cls_GetDeviceAccountCodeForTenantAndCodeValue(,P_L3DAC_GDACFTCV_1616 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3DAC_GDACFTCV_1616 invocationResult = cls_GetDeviceAccountCodeForTenantAndCodeValue.Invoke(connectionString,P_L3DAC_GDACFTCV_1616 Parameter,securityTicket);
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
var parameter = new CL3_DeviceAccountCodes.Complex.Retrieval.P_L3DAC_GDACFTCV_1616();
parameter.CodeValue = ...;

*/
