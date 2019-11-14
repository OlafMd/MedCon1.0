/* 
 * Generated on 2/6/2015 10:04:04 AM
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

namespace CL5_MyHealthClub_DoctorsAndStaff.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Device_ConfigurationCodes.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Device_ConfigurationCodes
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5DO_SDCC_0919 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            #region Save
            if (Parameter.USR_Device_ConfigurationCodeID == Guid.Empty)
            {
                ORM_USR_Device_ConfigurationCode deviceConfigurationCode = new ORM_USR_Device_ConfigurationCode();
                deviceConfigurationCode.USR_Device_ConfigurationCodeID = Guid.NewGuid();
                deviceConfigurationCode.DeviceConfigurationCode = Parameter.DeviceConfigurationCode;
                deviceConfigurationCode.Preconfigured_PrimaryUser_RefID = Parameter.AccountID;
                deviceConfigurationCode.DateOfExpiry = DateTime.MinValue;
                deviceConfigurationCode.Exclusively_UsableBy_Device_RefID = Guid.Empty;
                deviceConfigurationCode.IsMultipleUsagesAllowed = false;
                deviceConfigurationCode.Preconfigured_ApplicationBaseURL = Parameter.Preconfigured_ApplicationBaseURL;
                deviceConfigurationCode.Tenant_RefID = securityTicket.TenantID;
                deviceConfigurationCode.Save(Connection, Transaction);
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
		public static FR_Guid Invoke(string ConnectionString,P_L5DO_SDCC_0919 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5DO_SDCC_0919 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5DO_SDCC_0919 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5DO_SDCC_0919 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Device_ConfigurationCodes",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5DO_SDCC_0919 for attribute P_L5DO_SDCC_0919
		[DataContract]
		public class P_L5DO_SDCC_0919 
		{
			//Standard type parameters
			[DataMember]
			public Guid USR_Device_ConfigurationCodeID { get; set; } 
			[DataMember]
			public Guid AccountID { get; set; } 
			[DataMember]
			public String DeviceConfigurationCode { get; set; } 
			[DataMember]
			public String Preconfigured_ApplicationBaseURL { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Device_ConfigurationCodes(,P_L5DO_SDCC_0919 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Device_ConfigurationCodes.Invoke(connectionString,P_L5DO_SDCC_0919 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_DoctorsAndStaff.Atomic.Manipulation.P_L5DO_SDCC_0919();
parameter.USR_Device_ConfigurationCodeID = ...;
parameter.AccountID = ...;
parameter.DeviceConfigurationCode = ...;
parameter.Preconfigured_ApplicationBaseURL = ...;

*/
