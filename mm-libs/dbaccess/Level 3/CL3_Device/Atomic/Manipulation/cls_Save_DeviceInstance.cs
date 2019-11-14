/* 
 * Generated on 26.06.2014 11:39:16
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
using CL1_PPS_DEV;

namespace CL3_Device.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_DeviceInstance.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_DeviceInstance
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L3DE_SDI_1107 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            if (!Parameter.IsDelete)
            {
                ORM_PPS_DEV_Device_Instance instance;

                if (Parameter.PPS_DEV_Device_InstanceID == Guid.Empty)
                {
                    instance = new ORM_PPS_DEV_Device_Instance();
                    instance.Tenant_RefID = securityTicket.TenantID;
                    instance.PPS_DEV_Device_InstanceID = Guid.NewGuid();
                }
                else
                {
                    instance = ORM_PPS_DEV_Device_Instance.Query.Search(Connection, Transaction, new ORM_PPS_DEV_Device_Instance.Query()
                    {
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID,
                        PPS_DEV_Device_InstanceID = Parameter.PPS_DEV_Device_InstanceID
                    }).SingleOrDefault();
                }
                instance.Device_RefID = Parameter.PPS_DEV_DeviceID;
                instance.DeviceInventoryNumber = Parameter.DeviceInventoryNumber;
                instance.Save(Connection, Transaction);

                ORM_PPS_DEV_Device_Instance_OfficeLocation location = ORM_PPS_DEV_Device_Instance_OfficeLocation.Query.Search(Connection, Transaction, new ORM_PPS_DEV_Device_Instance_OfficeLocation.Query()
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID,
                    DeviceInstance_RefID = instance.PPS_DEV_Device_InstanceID
                }).SingleOrDefault();
                if (location == null)
                {
                    location = new ORM_PPS_DEV_Device_Instance_OfficeLocation();
                    location.PPS_DEV_Device_Instance_OfficeLocationID = Guid.NewGuid();
                    location.DeviceInstance_RefID = instance.PPS_DEV_Device_InstanceID;
                    location.Tenant_RefID = securityTicket.TenantID;
                }
                location.CMN_STR_Office_RefID = Parameter.OfficeID;
                location.Save(Connection, Transaction);

                returnValue.Result = instance.PPS_DEV_Device_InstanceID;
            }
            else
            {
                ORM_PPS_DEV_Device_Instance.Query.SoftDelete(Connection, Transaction, new ORM_PPS_DEV_Device_Instance.Query()
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID,
                    PPS_DEV_Device_InstanceID = Parameter.PPS_DEV_Device_InstanceID
                });

                ORM_PPS_DEV_Device_Instance_OfficeLocation.Query.SoftDelete(Connection, Transaction, new ORM_PPS_DEV_Device_Instance_OfficeLocation.Query()
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID,
                    DeviceInstance_RefID = Parameter.PPS_DEV_Device_InstanceID
                });

                returnValue.Result = Parameter.PPS_DEV_Device_InstanceID;
            }

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L3DE_SDI_1107 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L3DE_SDI_1107 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L3DE_SDI_1107 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3DE_SDI_1107 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_DeviceInstance",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3DE_SDI_1107 for attribute P_L3DE_SDI_1107
		[DataContract]
		public class P_L3DE_SDI_1107 
		{
			//Standard type parameters
			[DataMember]
			public bool IsDelete { get; set; } 
			[DataMember]
			public Guid PPS_DEV_DeviceID { get; set; } 
			[DataMember]
			public Guid PPS_DEV_Device_InstanceID { get; set; } 
			[DataMember]
			public Guid OfficeID { get; set; } 
			[DataMember]
			public string DeviceInventoryNumber { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_DeviceInstance(,P_L3DE_SDI_1107 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_DeviceInstance.Invoke(connectionString,P_L3DE_SDI_1107 Parameter,securityTicket);
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
var parameter = new CL3_Device.Atomic.Manipulation.P_L3DE_SDI_1107();
parameter.IsDelete = ...;
parameter.PPS_DEV_DeviceID = ...;
parameter.PPS_DEV_Device_InstanceID = ...;
parameter.OfficeID = ...;
parameter.DeviceInventoryNumber = ...;

*/
