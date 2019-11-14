/* 
 * Generated on 29.9.2015 10:41:45
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
using MMDocConnectDBMethods.Patient.Atomic.Retrieval;

namespace MMDocConnectDBMethods.Patient.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_PatientData_With_ContractListTenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_PatientData_With_ContractListTenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_PA_GPDWCLT_1118 Execute(DbConnection Connection,DbTransaction Transaction,P_PA_GPDWCLT_1118 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_PA_GPDWCLT_1118();
            returnValue.Result = new PA_GPDWCLT_1118();
            var patientData = cls_Get_Patient_Details_for_PatientID.Invoke(Connection, Transaction, new P_P_PA_GPDfPID_1124 { PatientID = Parameter.PatientID }, securityTicket).Result;
            var ctrList = cls_Get_Contracts_Where_Hip_Participating_for_HipID.Invoke(Connection, Transaction, new P_PA_GCwHipPfHipID_0954() { HipIkNumber = patientData.HealthInsurance_IKNumber }, securityTicket).Result;
            returnValue.Result.InitalData = new PA_GDAPV_1629()
            {
                Contracts = ctrList.Select(ctr =>
                {
                    return new PA_GDAPV_1629_Contracts()
                    {
                        ID = ctr.ContractID,
                        Name = ctr.ContractName,
                        participation_consent_valid_days = ctr.ParticipationConsentValidForMonths,
                        ValidFrom = ctr.ValidFrom,
                        ValidThrough = ctr.ValidThrough
                    };
                }).ToArray()
            };

            PA_GPDWCLT_1118_PatientData returnPatientData = new PA_GPDWCLT_1118_PatientData();
            returnPatientData.birthday = patientData.birthday;
            returnPatientData.contract_number = patientData.contract_number;
            returnPatientData.gender = patientData.gender;
            returnPatientData.health_insurance_provider = patientData.health_insurance_provider;
            returnPatientData.id = patientData.id;
            returnPatientData.insurance_id = patientData.insurance_id;
            returnPatientData.insurance_status = patientData.insurance_status;
            returnPatientData.name = patientData.name;
            returnPatientData.patient_first_name = patientData.patient_first_name;
            returnPatientData.patient_last_name = patientData.patient_last_name;
            if (patientData.ParticipationConsent.Length > 0)
            {
                var participationConsrnt = patientData.ParticipationConsent.OrderByDescending(m => m.participation_consent_issue_date).FirstOrDefault();
                returnPatientData.ValidThrough = participationConsrnt.ValidThrough;
                returnPatientData.participation_consent_issue_date = participationConsrnt.participation_consent_issue_date;
            }
            returnValue.Result.PatientData = returnPatientData;

            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_PA_GPDWCLT_1118 Invoke(string ConnectionString,P_PA_GPDWCLT_1118 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_PA_GPDWCLT_1118 Invoke(DbConnection Connection,P_PA_GPDWCLT_1118 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_PA_GPDWCLT_1118 Invoke(DbConnection Connection, DbTransaction Transaction,P_PA_GPDWCLT_1118 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_PA_GPDWCLT_1118 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_PA_GPDWCLT_1118 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_PA_GPDWCLT_1118 functionReturn = new FR_PA_GPDWCLT_1118();
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

				throw new Exception("Exception occured in method cls_Get_PatientData_With_ContractListTenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_PA_GPDWCLT_1118 : FR_Base
	{
		public PA_GPDWCLT_1118 Result	{ get; set; }

		public FR_PA_GPDWCLT_1118() : base() {}

		public FR_PA_GPDWCLT_1118(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_PA_GPDWCLT_1118 for attribute P_PA_GPDWCLT_1118
		[DataContract]
		public class P_PA_GPDWCLT_1118 
		{
			//Standard type parameters
			[DataMember]
			public Guid PatientID { get; set; } 

		}
		#endregion
		#region SClass PA_GPDWCLT_1118 for attribute PA_GPDWCLT_1118
		[DataContract]
		public class PA_GPDWCLT_1118 
		{
			[DataMember]
			public PA_GPDWCLT_1118_PatientData PatientData { get; set; }

			//Standard type parameters
			[DataMember]
			public PA_GDAPV_1629 InitalData { get; set; } 

		}
		#endregion
		#region SClass PA_GPDWCLT_1118_PatientData for attribute PatientData
		[DataContract]
		public class PA_GPDWCLT_1118_PatientData 
		{
			//Standard type parameters
			[DataMember]
			public String name { get; set; } 
			[DataMember]
			public String patient_first_name { get; set; } 
			[DataMember]
			public String patient_last_name { get; set; } 
			[DataMember]
			public DateTime birthday { get; set; } 
			[DataMember]
			public String insurance_id { get; set; } 
			[DataMember]
			public String insurance_status { get; set; } 
			[DataMember]
			public int gender { get; set; } 
			[DataMember]
			public String health_insurance_provider { get; set; } 
			[DataMember]
			public Guid id { get; set; } 
			[DataMember]
			public int contract_number { get; set; } 
			[DataMember]
			public DateTime participation_consent_issue_date { get; set; } 
			[DataMember]
			public DateTime ValidThrough { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_PA_GPDWCLT_1118 cls_Get_PatientData_With_ContractListTenant(,P_PA_GPDWCLT_1118 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_PA_GPDWCLT_1118 invocationResult = cls_Get_PatientData_With_ContractListTenant.Invoke(connectionString,P_PA_GPDWCLT_1118 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Patient.Complex.Retrieval.P_PA_GPDWCLT_1118();
parameter.PatientID = ...;

*/
