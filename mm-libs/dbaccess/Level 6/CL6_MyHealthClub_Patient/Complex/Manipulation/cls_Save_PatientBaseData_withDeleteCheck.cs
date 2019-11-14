/* 
 * Generated on 8/12/2014 1:25:28 PM
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
using CL5_MyHealthClub_Patient.Atomic.Manipulation;
using CL1_PPS_TSK;
using CL1_HEC_APP;
using CL1_HEC_ACT;
using CL5_MyHealthClub_EMR.Atomic.Manipulation;

namespace CL6_MyHealthClub_Patient.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_PatientBaseData_withDeleteCheck.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_PatientBaseData_withDeleteCheck
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6PA_SPBDwDC_1323 Execute(DbConnection Connection,DbTransaction Transaction,P_L6PA_SPBDwDC_1323 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_L6PA_SPBDwDC_1323();
			//Put your code here

            returnValue.Result = new L6PA_SPBDwDC_1323();

            Guid PatientId = Guid.Empty;
            if (!Parameter.BaseData.isDeleted)
            {
                PatientId = cls_Save_PatientBaseData.Invoke(Connection, Transaction, Parameter.BaseData, securityTicket).Result;

                cls_Create_EMRCreationRequest.Invoke(Connection, Transaction, new P_L5ME_CECRfPID_1520() { PatientID = PatientId }, securityTicket);
            }
            else
            {
                List<ORM_HEC_ACT_PlannedAction> existingAppointment = ORM_HEC_ACT_PlannedAction.Query.Search(Connection, Transaction, new ORM_HEC_ACT_PlannedAction.Query
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID,
                    Patient_RefID = Parameter.BaseData.ID
                }).ToList();

                if (existingAppointment.Count > 0) //cannot delete
                {
                    List<L6PA_SPBDwDC_1323_UsedInAppointment> usedAppointmentList = new List<L6PA_SPBDwDC_1323_UsedInAppointment>();

                    foreach (var appointment in existingAppointment)
                    {
                        ORM_HEC_APP_Appointment patientAppointment = ORM_HEC_APP_Appointment.Query.Search(Connection, Transaction, new ORM_HEC_APP_Appointment.Query
                        {
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID,
                            HEC_APP_AppointmentID = appointment.Appointment_RefID
                        }).Single();

                        ORM_PPS_TSK_Task appointmentName = ORM_PPS_TSK_Task.Query.Search(Connection, Transaction, new ORM_PPS_TSK_Task.Query
                        {
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID,
                            PPS_TSK_TaskID = patientAppointment.Ext_PPS_TSK_Task_RefID
                        }).Single();

                        usedAppointmentList.Add(new L6PA_SPBDwDC_1323_UsedInAppointment {AppointmentName= appointmentName.DisplayName });
                    }
                    returnValue.Result.UsedInAppointment = usedAppointmentList.ToArray();
                }

                if (existingAppointment.Count == 0)
                {
                    PatientId = cls_Save_PatientBaseData.Invoke(Connection, Transaction, Parameter.BaseData, securityTicket).Result;
                }
            }
            returnValue.Result.ID = PatientId;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6PA_SPBDwDC_1323 Invoke(string ConnectionString,P_L6PA_SPBDwDC_1323 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6PA_SPBDwDC_1323 Invoke(DbConnection Connection,P_L6PA_SPBDwDC_1323 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6PA_SPBDwDC_1323 Invoke(DbConnection Connection, DbTransaction Transaction,P_L6PA_SPBDwDC_1323 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6PA_SPBDwDC_1323 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6PA_SPBDwDC_1323 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6PA_SPBDwDC_1323 functionReturn = new FR_L6PA_SPBDwDC_1323();
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

				throw new Exception("Exception occured in method cls_Save_PatientBaseData_withDeleteCheck",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6PA_SPBDwDC_1323 : FR_Base
	{
		public L6PA_SPBDwDC_1323 Result	{ get; set; }

		public FR_L6PA_SPBDwDC_1323() : base() {}

		public FR_L6PA_SPBDwDC_1323(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6PA_SPBDwDC_1323 for attribute P_L6PA_SPBDwDC_1323
		[DataContract]
		public class P_L6PA_SPBDwDC_1323 
		{
			//Standard type parameters
			[DataMember]
			public P_L5PA_GPBD_1613 BaseData { get; set; } 

		}
		#endregion
		#region SClass L6PA_SPBDwDC_1323 for attribute L6PA_SPBDwDC_1323
		[DataContract]
		public class L6PA_SPBDwDC_1323 
		{
			[DataMember]
			public L6PA_SPBDwDC_1323_UsedInAppointment[] UsedInAppointment { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid ID { get; set; } 

		}
		#endregion
		#region SClass L6PA_SPBDwDC_1323_UsedInAppointment for attribute UsedInAppointment
		[DataContract]
		public class L6PA_SPBDwDC_1323_UsedInAppointment 
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
FR_L6PA_SPBDwDC_1323 cls_Save_PatientBaseData_withDeleteCheck(,P_L6PA_SPBDwDC_1323 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6PA_SPBDwDC_1323 invocationResult = cls_Save_PatientBaseData_withDeleteCheck.Invoke(connectionString,P_L6PA_SPBDwDC_1323 Parameter,securityTicket);
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
var parameter = new CL6_MyHealthClub_Patient.Complex.Manipulation.P_L6PA_SPBDwDC_1323();
parameter.BaseData = ...;

*/
