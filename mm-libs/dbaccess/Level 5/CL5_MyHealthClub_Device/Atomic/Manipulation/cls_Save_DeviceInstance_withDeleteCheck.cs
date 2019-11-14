/* 
 * Generated on 14.11.2014 11:09:55
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
using CL5_MyHealthClub_BookableTimeSlot.Complex.Manipulation;
using CL1_PPS_DEV;

namespace CL5_MyHealthClub_Device.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_DeviceInstance_withDeleteCheck.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_DeviceInstance_withDeleteCheck
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5MHC_SDIwDC_1040 Execute(DbConnection Connection,DbTransaction Transaction,P_L5MHC_SDIwDC_1040 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5MHC_SDIwDC_1040();
			//Put your code here

            returnValue.Result = new L5MHC_SDIwDC_1040();

            Guid DeviceInstanceId = Guid.Empty;
            if (!Parameter.BaseData.IsDelete)
            {        
                DeviceInstanceId = cls_Save_DeviceInstance.Invoke(Connection, Transaction, Parameter.BaseData, securityTicket).Result;          
            }
            else
            {
                List<ORM_PPS_TSK_Task_DeviceBooking> existingAppointment = ORM_PPS_TSK_Task_DeviceBooking.Query.Search(Connection, Transaction, new ORM_PPS_TSK_Task_DeviceBooking.Query
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID,
                    PPS_DEV_Device_Instance_RefID = Parameter.BaseData.PPS_DEV_Device_InstanceID
                }).ToList();

                if (existingAppointment.Count > 0) //cannot delete
                {
                    List<L5MHC_SDIwDC_1040_UsedInAppointment> usedAppointmentList = new List<L5MHC_SDIwDC_1040_UsedInAppointment>();

                    foreach (var appointment in existingAppointment)
                    {
                        ORM_PPS_TSK_Task appointmentName = ORM_PPS_TSK_Task.Query.Search(Connection, Transaction, new ORM_PPS_TSK_Task.Query
                        {
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID,
                            PPS_TSK_TaskID = appointment.PPS_TSK_Task_RefID
                        }).Single();
                        usedAppointmentList.Add(new L5MHC_SDIwDC_1040_UsedInAppointment { AppointmentName = appointmentName.DisplayName });
                    }
                    returnValue.Result.UsedInAppointment = usedAppointmentList.ToArray();
                }

                if (existingAppointment.Count == 0)
                {
                    DeviceInstanceId = cls_Save_DeviceInstance.Invoke(Connection, Transaction, Parameter.BaseData, securityTicket).Result;   
                }
            }
            returnValue.Result.ID = DeviceInstanceId;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5MHC_SDIwDC_1040 Invoke(string ConnectionString,P_L5MHC_SDIwDC_1040 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5MHC_SDIwDC_1040 Invoke(DbConnection Connection,P_L5MHC_SDIwDC_1040 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5MHC_SDIwDC_1040 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5MHC_SDIwDC_1040 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5MHC_SDIwDC_1040 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5MHC_SDIwDC_1040 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5MHC_SDIwDC_1040 functionReturn = new FR_L5MHC_SDIwDC_1040();
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

				throw new Exception("Exception occured in method cls_Save_DeviceInstance_withDeleteCheck",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5MHC_SDIwDC_1040 : FR_Base
	{
		public L5MHC_SDIwDC_1040 Result	{ get; set; }

		public FR_L5MHC_SDIwDC_1040() : base() {}

		public FR_L5MHC_SDIwDC_1040(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5MHC_SDIwDC_1040 for attribute P_L5MHC_SDIwDC_1040
		[DataContract]
		public class P_L5MHC_SDIwDC_1040 
		{
			//Standard type parameters
			[DataMember]
			public P_L3DE_SDI_1107 BaseData { get; set; } 
			[DataMember]
			public bool UpdateSlots { get; set; } 

		}
		#endregion
		#region SClass L5MHC_SDIwDC_1040 for attribute L5MHC_SDIwDC_1040
		[DataContract]
		public class L5MHC_SDIwDC_1040 
		{
			[DataMember]
			public L5MHC_SDIwDC_1040_UsedInAppointment[] UsedInAppointment { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid ID { get; set; } 

		}
		#endregion
		#region SClass L5MHC_SDIwDC_1040_UsedInAppointment for attribute UsedInAppointment
		[DataContract]
		public class L5MHC_SDIwDC_1040_UsedInAppointment 
		{
			//Standard type parameters
			[DataMember]
			public String AppointmentName { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5MHC_SDIwDC_1040 cls_Save_DeviceInstance_withDeleteCheck(,P_L5MHC_SDIwDC_1040 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5MHC_SDIwDC_1040 invocationResult = cls_Save_DeviceInstance_withDeleteCheck.Invoke(connectionString,P_L5MHC_SDIwDC_1040 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_Device.Atomic.Manipulation.P_L5MHC_SDIwDC_1040();
parameter.BaseData = ...;
parameter.UpdateSlots = ...;

*/
