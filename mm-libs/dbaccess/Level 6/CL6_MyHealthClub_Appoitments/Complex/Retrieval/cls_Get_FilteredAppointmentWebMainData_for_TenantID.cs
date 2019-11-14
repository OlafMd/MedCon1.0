/* 
 * Generated on 7/8/2014 1:24:37 PM
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
using CL5_MyHealthClub_TaskTemplate.Atomic.Retrieval;
using DLCore_DBCommons.Utils;
using CL2_Contact.DomainManagement;
using DLCore_DBCommons.MyHealthClub;


namespace CL6_MyHealthClub_Appoitments.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_FilteredAppointmentWebMainData_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_FilteredAppointmentWebMainData_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6AT_GFAWMDfTID Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_L6AT_GFAWMDfTID();

            returnValue.Result = new L6AT_GFAWMDfTID();
            //List<L5AP_GAWMDfTID_1101> appointmentLIst = new List<L5AP_GAWMDfTID_1101>();

            var notFilteredAppointments = cls_Get_AppointmentWebMainData_for_TenantID.Invoke(Connection, Transaction, new P_L5AP_GAWMDfTID_1101 { Type = EnumUtils.GetEnumDescription(EComunactionContactType.Phone), TaskType = EnumUtils.GetEnumDescription(AvailabilityType.WebBooking) }, securityTicket).Result;

            foreach (var item in notFilteredAppointments)
            {
                //L5AP_GAWMDfTID_1101 appointment = new L5AP_GAWMDfTID_1101();
                //appointment.DisplayName = item.DisplayName;
                //appointment.Office_Name = item.Office_Name;
                //appointment.PatientBirthDay = item.PatientBirthDay;
                //appointment.PatientFirstName = item.PatientFirstName;
                //appointment.PatientLastName = item.PatientLastName;
                //appointment.PlannedStartDate = item.PlannedStartDate;
                //appointment.PPS_TSK_TaskID = item.PPS_TSK_TaskID;
                //appointment.TaskTemplateName = item.TaskTemplateName;
                //appointment.AcademicTitle = item.AcademicTitle;
                //appointment.PlannedDuration_in_sec = item.PlannedDuration_in_sec;

                List<L5AP_GAWMDfTID_1101_Doctor> Doctor = item.Doctor.Where(i => i.DoctorFlag != null).ToList();
                item.Doctor = Doctor.ToArray();

                List<L5AP_GAWMDfTID_1101_RequiredDoctor> RequiredDocor = item.RequiredDoctor.Where(i => i.RequiredDoctorFlag != null).ToList();
                item.RequiredDoctor = RequiredDocor.ToArray();

                //appointmentLIst.Add(item);
            }

            returnValue.Result.Appointment = notFilteredAppointments; // appointmentLIst.ToArray();

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6AT_GFAWMDfTID Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6AT_GFAWMDfTID Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6AT_GFAWMDfTID Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6AT_GFAWMDfTID Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6AT_GFAWMDfTID functionReturn = new FR_L6AT_GFAWMDfTID();
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

				functionReturn = Execute(Connection, Transaction,securityTicket);

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

				throw new Exception("Exception occured in method cls_Get_FilteredAppointmentWebMainData_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6AT_GFAWMDfTID : FR_Base
	{
		public L6AT_GFAWMDfTID Result	{ get; set; }

		public FR_L6AT_GFAWMDfTID() : base() {}

		public FR_L6AT_GFAWMDfTID(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L6AT_GFAWMDfTID for attribute L6AT_GFAWMDfTID
		[DataContract]
		public class L6AT_GFAWMDfTID 
		{
			//Standard type parameters
			[DataMember]
			public L5AP_GAWMDfTID_1101[] Appointment { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6AT_GFAWMDfTID cls_Get_FilteredAppointmentWebMainData_for_TenantID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6AT_GFAWMDfTID invocationResult = cls_Get_FilteredAppointmentWebMainData_for_TenantID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

