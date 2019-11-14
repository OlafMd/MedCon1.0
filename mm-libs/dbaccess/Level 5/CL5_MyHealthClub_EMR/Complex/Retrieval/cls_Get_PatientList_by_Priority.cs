/* 
 * Generated on 27.01.2015 14:25:13
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
using CL5_MyHealthClub_EMR.Atomic.Retrieval;

namespace CL5_MyHealthClub_EMR.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_PatientList_by_Priority.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_PatientList_by_Priority
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5ME_GPLbP_1045_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5ME_GPLbP_1045 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5ME_GPLbP_1045_Array();

            var currentTime = DateTime.Now;
            var limitInPast = currentTime.AddDays(-Parameter.TimeLimitInDays);
            var limitInFuture = currentTime.AddDays(-Parameter.TimeLimitInDays);

            var nextNearPeriodPatients = new Dictionary<Guid, DateTime>();
            var nextFarPeriodPatients = new Dictionary<Guid, DateTime>();
            var prevNearPeriodPatients = new Dictionary<Guid, DateTime>();
            var prevFarPeriodPatients = new Dictionary<Guid, DateTime>();

            var historyByPatients = cls_Get_PatientActionHistory_for_TenantID.Invoke(Connection, Transaction, securityTicket).Result;
            foreach (var patient in historyByPatients)
            {
                DateTime nextAppointmentDate = DateTime.MaxValue;
                DateTime prevAppointmentDate = DateTime.MinValue;
                if(patient.PlannedActions.Length > 0)
                    nextAppointmentDate = patient.PlannedActions.OrderBy(d => d.PlannedFor_Date).First().PlannedFor_Date;
                if (patient.PerformedActions.Length > 0)
                    prevAppointmentDate = patient.PerformedActions.OrderByDescending(d => d.IfPerfomed_DateOfAction).First().IfPerfomed_DateOfAction;

                if (nextAppointmentDate < limitInFuture)
                    nextNearPeriodPatients.Add(patient.HEC_PatientID, nextAppointmentDate);
                else
                    nextFarPeriodPatients.Add(patient.HEC_PatientID, nextAppointmentDate);


                if (prevAppointmentDate > limitInPast)
                    prevNearPeriodPatients.Add(patient.HEC_PatientID, prevAppointmentDate);
                else
                    prevFarPeriodPatients.Add(patient.HEC_PatientID, prevAppointmentDate);
            }

            var nextNearPeriodPatientsList = nextNearPeriodPatients.ToList().OrderBy(d => d.Value);
            var nextFarPeriodPatientsList = nextFarPeriodPatients.ToList().OrderBy(d => d.Value);
            var prevNearPeriodPatientsList = prevNearPeriodPatients.ToList().OrderByDescending(d => d.Value);
            var prevFarPeriodPatientsList = prevFarPeriodPatients.ToList().OrderByDescending(d => d.Value);

            var res = new List<L5ME_GPLbP_1045>();

            foreach (var pari in nextNearPeriodPatientsList)
                res.Add(new L5ME_GPLbP_1045() { PatientID = pari.Key });

            foreach (var pari in prevNearPeriodPatientsList)
                if(!res.Select(s => s.PatientID).Contains(pari.Key))
                    res.Add(new L5ME_GPLbP_1045() { PatientID = pari.Key });

            foreach (var pari in nextFarPeriodPatientsList)
                if (!res.Select(s => s.PatientID).Contains(pari.Key))
                    res.Add(new L5ME_GPLbP_1045() { PatientID = pari.Key });

            foreach (var pari in prevFarPeriodPatientsList)
                if (!res.Select(s => s.PatientID).Contains(pari.Key))
                    res.Add(new L5ME_GPLbP_1045() { PatientID = pari.Key });
            

            returnValue.Result = res.ToArray();

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5ME_GPLbP_1045_Array Invoke(string ConnectionString,P_L5ME_GPLbP_1045 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5ME_GPLbP_1045_Array Invoke(DbConnection Connection,P_L5ME_GPLbP_1045 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5ME_GPLbP_1045_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5ME_GPLbP_1045 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5ME_GPLbP_1045_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5ME_GPLbP_1045 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5ME_GPLbP_1045_Array functionReturn = new FR_L5ME_GPLbP_1045_Array();
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

				throw new Exception("Exception occured in method cls_Get_PatientList_by_Priority",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5ME_GPLbP_1045_Array : FR_Base
	{
		public L5ME_GPLbP_1045[] Result	{ get; set; } 
		public FR_L5ME_GPLbP_1045_Array() : base() {}

		public FR_L5ME_GPLbP_1045_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5ME_GPLbP_1045 for attribute P_L5ME_GPLbP_1045
		[DataContract]
		public class P_L5ME_GPLbP_1045 
		{
			//Standard type parameters
			[DataMember]
			public int TimeLimitInDays { get; set; } 
			[DataMember]
			public bool GetFullSync { get; set; } 
			[DataMember]
			public DateTime LastSyncDate { get; set; } 

		}
		#endregion
		#region SClass L5ME_GPLbP_1045 for attribute L5ME_GPLbP_1045
		[DataContract]
		public class L5ME_GPLbP_1045 
		{
			//Standard type parameters
			[DataMember]
			public Guid PatientID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5ME_GPLbP_1045_Array cls_Get_PatientList_by_Priority(,P_L5ME_GPLbP_1045 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5ME_GPLbP_1045_Array invocationResult = cls_Get_PatientList_by_Priority.Invoke(connectionString,P_L5ME_GPLbP_1045 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_EMR.Complex.Retrieval.P_L5ME_GPLbP_1045();
parameter.TimeLimitInDays = ...;
parameter.GetFullSync = ...;
parameter.LastSyncDate = ...;

*/
