/* 
 * Generated on 9/5/2013 11:41:28 AM
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
using CL5_Lucentis_Patient.Atomic.Retrieval;

namespace CL5_Lucentis_Patient.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Patient_for_PatientID_and_Get_All_HealthInsurance_Companies.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Patient_for_PatientID_and_Get_All_HealthInsurance_Companies
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5PA_GPfPIDaAHIC_1113 Execute(DbConnection Connection,DbTransaction Transaction,P_L5PA_GPfPIDaAHIC_1113 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5PA_GPfPIDaAHIC_1113();
            returnValue.Result = new L5PA_GPfPIDaAHIC_1113();
            returnValue.Result.Patient = new L5PA_GPfPID_1413();
            List<L5PA_GAHICfP_1137> healthCompanies = new List<L5PA_GAHICfP_1137>();
            returnValue.Result.HealthInsurance_Company = healthCompanies.ToArray();

            P_L5PA_GPfPID_1413 param = new P_L5PA_GPfPID_1413();
            param.PatientID = Parameter.PatientID;
            L5PA_GPfPID_1413 patient = new L5PA_GPfPID_1413();
            patient = cls_Get_Patient_for_PatientID.Invoke(Connection,Transaction, param, securityTicket).Result;


            returnValue.Result.Patient = patient;

            List<L5PA_GAHICfP_1137> HealthInsuranceCompanies = new List<L5PA_GAHICfP_1137>();

            HealthInsuranceCompanies = cls_Get_AllHealthInsuranceCompanies_for_Patient.Invoke(Connection, Transaction, securityTicket).Result.ToList();

            returnValue.Result.HealthInsurance_Company = HealthInsuranceCompanies.ToArray();

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5PA_GPfPIDaAHIC_1113 Invoke(string ConnectionString,P_L5PA_GPfPIDaAHIC_1113 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5PA_GPfPIDaAHIC_1113 Invoke(DbConnection Connection,P_L5PA_GPfPIDaAHIC_1113 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5PA_GPfPIDaAHIC_1113 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5PA_GPfPIDaAHIC_1113 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5PA_GPfPIDaAHIC_1113 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5PA_GPfPIDaAHIC_1113 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5PA_GPfPIDaAHIC_1113 functionReturn = new FR_L5PA_GPfPIDaAHIC_1113();
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

				throw new Exception("Exception occured in method cls_Get_Patient_for_PatientID_and_Get_All_HealthInsurance_Companies",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5PA_GPfPIDaAHIC_1113 : FR_Base
	{
		public L5PA_GPfPIDaAHIC_1113 Result	{ get; set; }

		public FR_L5PA_GPfPIDaAHIC_1113() : base() {}

		public FR_L5PA_GPfPIDaAHIC_1113(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5PA_GPfPIDaAHIC_1113 for attribute P_L5PA_GPfPIDaAHIC_1113
		[DataContract]
		public class P_L5PA_GPfPIDaAHIC_1113 
		{
			//Standard type parameters
			[DataMember]
			public Guid PatientID { get; set; } 

		}
		#endregion
		#region SClass L5PA_GPfPIDaAHIC_1113 for attribute L5PA_GPfPIDaAHIC_1113
		[DataContract]
		public class L5PA_GPfPIDaAHIC_1113 
		{
			//Standard type parameters
			[DataMember]
			public L5PA_GPfPID_1413 Patient { get; set; } 
			[DataMember]
			public L5PA_GAHICfP_1137[] HealthInsurance_Company { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5PA_GPfPIDaAHIC_1113 cls_Get_Patient_for_PatientID_and_Get_All_HealthInsurance_Companies(,P_L5PA_GPfPIDaAHIC_1113 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5PA_GPfPIDaAHIC_1113 invocationResult = cls_Get_Patient_for_PatientID_and_Get_All_HealthInsurance_Companies.Invoke(connectionString,P_L5PA_GPfPIDaAHIC_1113 Parameter,securityTicket);
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
var parameter = new CL5_Lucentis_Patient.Complex.Retrieval.P_L5PA_GPfPIDaAHIC_1113();
parameter.PatientID = ...;

*/
