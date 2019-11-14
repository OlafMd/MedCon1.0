/* 
 * Generated on 1/20/2017 2:31:26 PM
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

namespace DataImporter.DBMethods.Patient.Atomic.Retrieval
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
		protected static FR_PA_GPDfPID_1729 Execute(DbConnection Connection,DbTransaction Transaction,P_PA_GPDfPID_1729 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_PA_GPDfPID_1729();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "DataImporter.DBMethods.Patient.Atomic.Retrieval.SQL.cls_Get_Patient_Details_for_PatientID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PatientID", Parameter.PatientID);



			List<PA_GPDfPID_1729_raw> results = new List<PA_GPDfPID_1729_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "name","patient_first_name","patient_last_name","birthday","insurance_id","insurance_status","gender","health_insurance_provider","contractID","HealthInsurance_IKNumber","id","contract_number","participation_consent_issue_date","ValidThrough","HEC_CRT_InsuranceToBrokerContract_ParticipatingPatientID" });
				while(reader.Read())
				{
					PA_GPDfPID_1729_raw resultItem = new PA_GPDfPID_1729_raw();
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
					//9:Parameter HealthInsurance_IKNumber of type String
					resultItem.HealthInsurance_IKNumber = reader.GetString(9);
					//10:Parameter id of type Guid
					resultItem.id = reader.GetGuid(10);
					//11:Parameter contract_number of type int
					resultItem.contract_number = reader.GetInteger(11);
					//12:Parameter participation_consent_issue_date of type DateTime
					resultItem.participation_consent_issue_date = reader.GetDate(12);
					//13:Parameter ValidThrough of type DateTime
					resultItem.ValidThrough = reader.GetDate(13);
					//14:Parameter HEC_CRT_InsuranceToBrokerContract_ParticipatingPatientID of type Guid
					resultItem.HEC_CRT_InsuranceToBrokerContract_ParticipatingPatientID = reader.GetGuid(14);

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

			returnStatus.Result = PA_GPDfPID_1729_raw.Convert(results).FirstOrDefault();

			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_PA_GPDfPID_1729 Invoke(string ConnectionString,P_PA_GPDfPID_1729 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_PA_GPDfPID_1729 Invoke(DbConnection Connection,P_PA_GPDfPID_1729 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_PA_GPDfPID_1729 Invoke(DbConnection Connection, DbTransaction Transaction,P_PA_GPDfPID_1729 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_PA_GPDfPID_1729 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_PA_GPDfPID_1729 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_PA_GPDfPID_1729 functionReturn = new FR_PA_GPDfPID_1729();
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
	public class PA_GPDfPID_1729_raw 
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

		public static PA_GPDfPID_1729[] Convert(List<PA_GPDfPID_1729_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_PA_GPDfPID_1729 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.id)).ToArray()
	group el_PA_GPDfPID_1729 by new 
	{ 
		el_PA_GPDfPID_1729.id,

	}
	into gfunct_PA_GPDfPID_1729
	select new PA_GPDfPID_1729
	{     
		name = gfunct_PA_GPDfPID_1729.FirstOrDefault().name ,
		patient_first_name = gfunct_PA_GPDfPID_1729.FirstOrDefault().patient_first_name ,
		patient_last_name = gfunct_PA_GPDfPID_1729.FirstOrDefault().patient_last_name ,
		birthday = gfunct_PA_GPDfPID_1729.FirstOrDefault().birthday ,
		insurance_id = gfunct_PA_GPDfPID_1729.FirstOrDefault().insurance_id ,
		insurance_status = gfunct_PA_GPDfPID_1729.FirstOrDefault().insurance_status ,
		gender = gfunct_PA_GPDfPID_1729.FirstOrDefault().gender ,
		health_insurance_provider = gfunct_PA_GPDfPID_1729.FirstOrDefault().health_insurance_provider ,
		contractID = gfunct_PA_GPDfPID_1729.FirstOrDefault().contractID ,
		HealthInsurance_IKNumber = gfunct_PA_GPDfPID_1729.FirstOrDefault().HealthInsurance_IKNumber ,
		id = gfunct_PA_GPDfPID_1729.Key.id ,
		contract_number = gfunct_PA_GPDfPID_1729.FirstOrDefault().contract_number ,

		ParticipationConsent = 
		(
			from el_ParticipationConsent in gfunct_PA_GPDfPID_1729.Where(element => !EqualsDefaultValue(element.HEC_CRT_InsuranceToBrokerContract_ParticipatingPatientID)).ToArray()
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
	public class FR_PA_GPDfPID_1729 : FR_Base
	{
		public PA_GPDfPID_1729 Result	{ get; set; }

		public FR_PA_GPDfPID_1729() : base() {}

		public FR_PA_GPDfPID_1729(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_PA_GPDfPID_1729 for attribute P_PA_GPDfPID_1729
		[DataContract]
		public class P_PA_GPDfPID_1729 
		{
			//Standard type parameters
			[DataMember]
			public Guid PatientID { get; set; } 

		}
		#endregion
		#region SClass PA_GPDfPID_1729 for attribute PA_GPDfPID_1729
		[DataContract]
		public class PA_GPDfPID_1729 
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
FR_PA_GPDfPID_1729 cls_Get_Patient_Details_for_PatientID(,P_PA_GPDfPID_1729 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_PA_GPDfPID_1729 invocationResult = cls_Get_Patient_Details_for_PatientID.Invoke(connectionString,P_PA_GPDfPID_1729 Parameter,securityTicket);
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
var parameter = new DataImporter.DBMethods.Patient.Atomic.Retrieval.P_PA_GPDfPID_1729();
parameter.PatientID = ...;

*/
