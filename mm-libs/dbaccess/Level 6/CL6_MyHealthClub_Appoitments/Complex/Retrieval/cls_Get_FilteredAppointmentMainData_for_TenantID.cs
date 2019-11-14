/* 
 * Generated on 7/7/2014 2:04:03 PM
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
using DLCore_DBCommons.MyHealthClub;

namespace CL6_MyHealthClub_Appoitments.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_FilteredAppointmentMainData_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_FilteredAppointmentMainData_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6AT_GFAMDfTID Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L6AT_GFAMDfTID();
            returnValue.Result = new L6AT_GFAMDfTID();
            List<L5AP_GAMDfTID_1035> appointmentLIst = new List<L5AP_GAMDfTID_1035>();

            var notFilteredAppointments = cls_Get_AppointmentMainData_for_TenantID.Invoke(Connection, Transaction, new P_L5AP_GAMDfTID_1035() { AvaPropertyMatchingID = EnumUtils.GetEnumDescription(AvailabilityType.Standard) }, securityTicket).Result;

            foreach (var item in notFilteredAppointments)
            {
                L5AP_GAMDfTID_1035 appointment = new L5AP_GAMDfTID_1035();
                appointment.PatientID = item.PatientID;
                appointment.DisplayName = item.DisplayName;
                appointment.Office_Name = item.Office_Name;
                appointment.PatientBirthDay = item.PatientBirthDay;
                appointment.PatientFirstName = item.PatientFirstName;
                appointment.PatientLastName = item.PatientLastName;
                appointment.PlannedStartDate = item.PlannedStartDate;
                appointment.PPS_TSK_TaskID = item.PPS_TSK_TaskID;
                appointment.TaskTemplateName = item.TaskTemplateName;
                appointment.AcademicTitle = item.AcademicTitle;
                appointment.PlannedDuration_in_sec = item.PlannedDuration_in_sec;
                appointment.PatientEmail = item.PatientEmail;

                List<L5AP_GAMDfTID_1035_Doctor>  Doctor = item.Doctor.Where(i => i.DoctorFlag != null).ToList();
                appointment.Doctor = Doctor.ToArray();

                List<L5AP_GAMDfTID_1035_RequiredDoctor> RequiredDocor = item.RequiredDoctor.Where(i => i.RequiredDoctorFlag != null).ToList();
                appointment.RequiredDoctor = RequiredDocor.ToArray();

                appointmentLIst.Add(appointment);
            }

            returnValue.Result.Appointment = appointmentLIst.ToArray();

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6AT_GFAMDfTID Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6AT_GFAMDfTID Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6AT_GFAMDfTID Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6AT_GFAMDfTID Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6AT_GFAMDfTID functionReturn = new FR_L6AT_GFAMDfTID();
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

				throw new Exception("Exception occured in method cls_Get_FilteredAppointmentMainData_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6AT_GFAMDfTID : FR_Base
	{
		public L6AT_GFAMDfTID Result	{ get; set; }

		public FR_L6AT_GFAMDfTID() : base() {}

		public FR_L6AT_GFAMDfTID(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L6AT_GFAMDfTID for attribute L6AT_GFAMDfTID
		[DataContract]
		public class L6AT_GFAMDfTID 
		{
			//Standard type parameters
			[DataMember]
			public L5AP_GAMDfTID_1035[] Appointment { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6AT_GFAMDfTID cls_Get_FilteredAppointmentMainData_for_TenantID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6AT_GFAMDfTID invocationResult = cls_Get_FilteredAppointmentMainData_for_TenantID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

