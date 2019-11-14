/* 
 * Generated on 14.11.2014 11:09:48
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
using CL3_Device.Atomic.Manipulation;
using CL1_PPS_TSK;
using CL1_PPS_DEV;

namespace CL5_MyHealthClub_Device.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Device.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Device
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5MHC_SD_1351 Execute(DbConnection Connection,DbTransaction Transaction,P_L5MHC_SD_1351 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_L5MHC_SD_1351();
			//Put your code here

            returnValue.Result = new L5MHC_SD_1351();

            Guid DeviceId = Guid.Empty;
            if (!Parameter.BaseData.IsDelete)
            {
                DeviceId = cls_Save_DeviceOnly.Invoke(Connection, Transaction, Parameter.BaseData, securityTicket).Result;
            }
            else
            {
                List<ORM_PPS_DEV_Device_Instance> existingDeviceInstance = ORM_PPS_DEV_Device_Instance.Query.Search(Connection, Transaction, new ORM_PPS_DEV_Device_Instance.Query
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID,
                    Device_RefID = Parameter.BaseData.PPS_DEV_DeviceID
                }).ToList();

                if (existingDeviceInstance.Count > 0) //cannot delete
                {
                    List<L5MHC_SD_1351_UsedInDeviceInstance> usedDeviceInstanceList = new List<L5MHC_SD_1351_UsedInDeviceInstance>();

                    foreach (var deviceInstance in existingDeviceInstance)
                    {
                        usedDeviceInstanceList.Add(new L5MHC_SD_1351_UsedInDeviceInstance { DeviceInstanceName = deviceInstance.DeviceInventoryNumber });
                    }

                    returnValue.Result.UsedInDeviceInstance = usedDeviceInstanceList.ToArray();
                }

                List<ORM_PPS_TSK_Task_Template_RequiredDevice> existingAppointmentType = ORM_PPS_TSK_Task_Template_RequiredDevice.Query.Search(Connection, Transaction, new ORM_PPS_TSK_Task_Template_RequiredDevice.Query
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID,
                    DEV_Device_RefID = Parameter.BaseData.PPS_DEV_DeviceID
                }).ToList();

                if (existingAppointmentType.Count > 0) //cannot delete
                {
                    List<L5MHC_SD_1351_UsedInAppointmentType> usedAppointmentTypeList = new List<L5MHC_SD_1351_UsedInAppointmentType>();

                    foreach (var appointmentType in existingAppointmentType)
                    {
                        ORM_PPS_TSK_Task_Template appointmentTypeName = ORM_PPS_TSK_Task_Template.Query.Search(Connection, Transaction, new ORM_PPS_TSK_Task_Template.Query
                        {
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID,
                            PPS_TSK_Task_TemplateID = appointmentType.TaskTemplate_RefID
                        }).Single();
                        usedAppointmentTypeList.Add(new L5MHC_SD_1351_UsedInAppointmentType { AppointmentTypeName = appointmentTypeName.TaskTemplateName });
                    }
                    returnValue.Result.UsedInAppointmentType = usedAppointmentTypeList.ToArray();
                }

                if (existingDeviceInstance.Count == 0 && existingAppointmentType.Count == 0)
                {
                    DeviceId = cls_Save_DeviceOnly.Invoke(Connection, Transaction, Parameter.BaseData, securityTicket).Result;
                }
            }
            returnValue.Result.ID = DeviceId;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5MHC_SD_1351 Invoke(string ConnectionString,P_L5MHC_SD_1351 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5MHC_SD_1351 Invoke(DbConnection Connection,P_L5MHC_SD_1351 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5MHC_SD_1351 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5MHC_SD_1351 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5MHC_SD_1351 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5MHC_SD_1351 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5MHC_SD_1351 functionReturn = new FR_L5MHC_SD_1351();
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

				throw new Exception("Exception occured in method cls_Save_Device",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5MHC_SD_1351 : FR_Base
	{
		public L5MHC_SD_1351 Result	{ get; set; }

		public FR_L5MHC_SD_1351() : base() {}

		public FR_L5MHC_SD_1351(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5MHC_SD_1351 for attribute P_L5MHC_SD_1351
		[DataContract]
		public class P_L5MHC_SD_1351 
		{
			//Standard type parameters
			[DataMember]
			public P_L3DE_SD_1044 BaseData { get; set; } 

		}
		#endregion
		#region SClass L5MHC_SD_1351 for attribute L5MHC_SD_1351
		[DataContract]
		public class L5MHC_SD_1351 
		{
			[DataMember]
			public L5MHC_SD_1351_UsedInDeviceInstance[] UsedInDeviceInstance { get; set; }
			[DataMember]
			public L5MHC_SD_1351_UsedInAppointmentType[] UsedInAppointmentType { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid ID { get; set; } 

		}
		#endregion
		#region SClass L5MHC_SD_1351_UsedInDeviceInstance for attribute UsedInDeviceInstance
		[DataContract]
		public class L5MHC_SD_1351_UsedInDeviceInstance 
		{
			//Standard type parameters
			[DataMember]
			public String DeviceInstanceName { get; set; } 

		}
		#endregion
		#region SClass L5MHC_SD_1351_UsedInAppointmentType for attribute UsedInAppointmentType
		[DataContract]
		public class L5MHC_SD_1351_UsedInAppointmentType 
		{
			//Standard type parameters
			[DataMember]
			public Dict AppointmentTypeName { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5MHC_SD_1351 cls_Save_Device(,P_L5MHC_SD_1351 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5MHC_SD_1351 invocationResult = cls_Save_Device.Invoke(connectionString,P_L5MHC_SD_1351 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_Device.Atomic.Manipulation.P_L5MHC_SD_1351();
parameter.BaseData = ...;

*/
