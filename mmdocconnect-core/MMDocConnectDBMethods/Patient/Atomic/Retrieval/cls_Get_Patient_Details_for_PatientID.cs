/* 
 * Generated on 11/09/15 13:40:57
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

namespace MMDocConnectDBMethods.Patient.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Patient_Details_for_PatientID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Patient_Details_for_PatientID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_P_PA_GPDfPID_1124 Execute(DbConnection Connection,DbTransaction Transaction,P_P_PA_GPDfPID_1124 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_P_PA_GPDfPID_1124();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.Patient.Atomic.Retrieval.SQL.cls_Get_Patient_Details_for_PatientID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PatientID", Parameter.PatientID);



			List<P_PA_GPDfPID_1124_raw> results = new List<P_PA_GPDfPID_1124_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "name","patient_first_name","patient_last_name","birthday","insurance_id","insurance_status","gender","health_insurance_provider","contractID","HealthInsuranceProviderID","HealthInsurance_IKNumber","id","contract_number","participation_consent_issue_date","ValidThrough","HEC_CRT_InsuranceToBrokerContract_ParticipatingPatientID" });
				while(reader.Read())
				{
					P_PA_GPDfPID_1124_raw resultItem = new P_PA_GPDfPID_1124_raw();
					//0:Parameter name of type String
					resultItem.name = reader.GetString(0);
					//1:Parameter patient_first_name of type String
					resultItem.patient_first_name = reader.GetString(1);
					//2:Parameter patient_last_name of type String
					resultItem.patient_last_name = reader.GetString(2);
					//3:Parameter birthday of type DateTime
					resultItem.birthday = reader.GetDate(3);
					//4:Parameter insurance_id of type String
					resultItem.insurance_id = reader.GetString(4);
					//5:Parameter insurance_status of type String
					resultItem.insurance_status = reader.GetString(5);
					//6:Parameter gender of type int
					resultItem.gender = reader.GetInteger(6);
					//7:Parameter health_insurance_provider of type String
					resultItem.health_insurance_provider = reader.GetString(7);
					//8:Parameter contractID of type Guid
					resultItem.contractID = reader.GetGuid(8);
					//9:Parameter HealthInsuranceProviderID of type Guid
					resultItem.HealthInsuranceProviderID = reader.GetGuid(9);
					//10:Parameter HealthInsurance_IKNumber of type String
					resultItem.HealthInsurance_IKNumber = reader.GetString(10);
					//11:Parameter id of type Guid
					resultItem.id = reader.GetGuid(11);
					//12:Parameter contract_number of type int
					resultItem.contract_number = reader.GetInteger(12);
					//13:Parameter participation_consent_issue_date of type DateTime
					resultItem.participation_consent_issue_date = reader.GetDate(13);
					//14:Parameter ValidThrough of type DateTime
					resultItem.ValidThrough = reader.GetDate(14);
					//15:Parameter HEC_CRT_InsuranceToBrokerContract_ParticipatingPatientID of type Guid
					resultItem.HEC_CRT_InsuranceToBrokerContract_ParticipatingPatientID = reader.GetGuid(15);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Patient_Details_for_PatientID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = P_PA_GPDfPID_1124_raw.Convert(results).FirstOrDefault();

			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_P_PA_GPDfPID_1124 Invoke(string ConnectionString,P_P_PA_GPDfPID_1124 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_P_PA_GPDfPID_1124 Invoke(DbConnection Connection,P_P_PA_GPDfPID_1124 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_P_PA_GPDfPID_1124 Invoke(DbConnection Connection, DbTransaction Transaction,P_P_PA_GPDfPID_1124 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_P_PA_GPDfPID_1124 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_P_PA_GPDfPID_1124 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_P_PA_GPDfPID_1124 functionReturn = new FR_P_PA_GPDfPID_1124();
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

				throw new Exception("Exception occured in method cls_Get_Patient_Details_for_PatientID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class P_PA_GPDfPID_1124_raw 
	{
		public String name; 
		public String patient_first_name; 
		public String patient_last_name; 
		public DateTime birthday; 
		public String insurance_id; 
		public String insurance_status; 
		public int gender; 
		public String health_insurance_provider; 
		public Guid contractID; 
		public Guid HealthInsuranceProviderID; 
		public String HealthInsurance_IKNumber; 
		public Guid id; 
		public int contract_number; 
		public DateTime participation_consent_issue_date; 
		public DateTime ValidThrough; 
		public Guid HEC_CRT_InsuranceToBrokerContract_ParticipatingPatientID; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static P_PA_GPDfPID_1124[] Convert(List<P_PA_GPDfPID_1124_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_P_PA_GPDfPID_1124 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.id)).ToArray()
	group el_P_PA_GPDfPID_1124 by new 
	{ 
		el_P_PA_GPDfPID_1124.id,

	}
	into gfunct_P_PA_GPDfPID_1124
	select new P_PA_GPDfPID_1124
	{     
		name = gfunct_P_PA_GPDfPID_1124.FirstOrDefault().name ,
		patient_first_name = gfunct_P_PA_GPDfPID_1124.FirstOrDefault().patient_first_name ,
		patient_last_name = gfunct_P_PA_GPDfPID_1124.FirstOrDefault().patient_last_name ,
		birthday = gfunct_P_PA_GPDfPID_1124.FirstOrDefault().birthday ,
		insurance_id = gfunct_P_PA_GPDfPID_1124.FirstOrDefault().insurance_id ,
		insurance_status = gfunct_P_PA_GPDfPID_1124.FirstOrDefault().insurance_status ,
		gender = gfunct_P_PA_GPDfPID_1124.FirstOrDefault().gender ,
		health_insurance_provider = gfunct_P_PA_GPDfPID_1124.FirstOrDefault().health_insurance_provider ,
		contractID = gfunct_P_PA_GPDfPID_1124.FirstOrDefault().contractID ,
		HealthInsuranceProviderID = gfunct_P_PA_GPDfPID_1124.FirstOrDefault().HealthInsuranceProviderID ,
		HealthInsurance_IKNumber = gfunct_P_PA_GPDfPID_1124.FirstOrDefault().HealthInsurance_IKNumber ,
		id = gfunct_P_PA_GPDfPID_1124.Key.id ,
		contract_number = gfunct_P_PA_GPDfPID_1124.FirstOrDefault().contract_number ,

		ParticipationConsent = 
		(
			from el_ParticipationConsent in gfunct_P_PA_GPDfPID_1124.Where(element => !EqualsDefaultValue(element.HEC_CRT_InsuranceToBrokerContract_ParticipatingPatientID)).ToArray()
			group el_ParticipationConsent by new 
			{ 
				el_ParticipationConsent.HEC_CRT_InsuranceToBrokerContract_ParticipatingPatientID,

			}
			into gfunct_ParticipationConsent
			select new PA_GPDfPID_1124_ParticipationConsent
			{     
				participation_consent_issue_date = gfunct_ParticipationConsent.FirstOrDefault().participation_consent_issue_date ,
				ValidThrough = gfunct_ParticipationConsent.FirstOrDefault().ValidThrough ,
				HEC_CRT_InsuranceToBrokerContract_ParticipatingPatientID = gfunct_ParticipationConsent.Key.HEC_CRT_InsuranceToBrokerContract_ParticipatingPatientID ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_P_PA_GPDfPID_1124 : FR_Base
	{
		public P_PA_GPDfPID_1124 Result	{ get; set; }

		public FR_P_PA_GPDfPID_1124() : base() {}

		public FR_P_PA_GPDfPID_1124(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_P_PA_GPDfPID_1124 for attribute P_P_PA_GPDfPID_1124
		[DataContract]
		public class P_P_PA_GPDfPID_1124 
		{
			//Standard type parameters
			[DataMember]
			public Guid PatientID { get; set; } 

		}
		#endregion
		#region SClass P_PA_GPDfPID_1124 for attribute P_PA_GPDfPID_1124
		[DataContract]
		public class P_PA_GPDfPID_1124 
		{
			[DataMember]
			public PA_GPDfPID_1124_ParticipationConsent[] ParticipationConsent { get; set; }

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
			public Guid contractID { get; set; } 
			[DataMember]
			public Guid HealthInsuranceProviderID { get; set; } 
			[DataMember]
			public String HealthInsurance_IKNumber { get; set; } 
			[DataMember]
			public Guid id { get; set; } 
			[DataMember]
			public int contract_number { get; set; } 

		}
		#endregion
		#region SClass PA_GPDfPID_1124_ParticipationConsent for attribute ParticipationConsent
		[DataContract]
		public class PA_GPDfPID_1124_ParticipationConsent 
		{
			//Standard type parameters
			[DataMember]
			public DateTime participation_consent_issue_date { get; set; } 
			[DataMember]
			public DateTime ValidThrough { get; set; } 
			[DataMember]
			public Guid HEC_CRT_InsuranceToBrokerContract_ParticipatingPatientID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_P_PA_GPDfPID_1124 cls_Get_Patient_Details_for_PatientID(,P_P_PA_GPDfPID_1124 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_P_PA_GPDfPID_1124 invocationResult = cls_Get_Patient_Details_for_PatientID.Invoke(connectionString,P_P_PA_GPDfPID_1124 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Patient.Atomic.Retrieval.P_P_PA_GPDfPID_1124();
parameter.PatientID = ...;

*/
