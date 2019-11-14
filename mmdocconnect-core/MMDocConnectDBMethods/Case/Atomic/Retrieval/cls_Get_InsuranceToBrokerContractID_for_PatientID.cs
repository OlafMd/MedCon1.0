/* 
 * Generated on 1/17/2017 1:38:47 PM
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

namespace MMDocConnectDBMethods.Case.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_InsuranceToBrokerContractID_for_PatientID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_InsuranceToBrokerContractID_for_PatientID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_CAS_GItBCIDfPID_1232_Array Execute(DbConnection Connection,DbTransaction Transaction,P_CAS_GItBCIDfPID_1232 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_CAS_GItBCIDfPID_1232_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.Case.Atomic.Retrieval.SQL.cls_Get_InsuranceToBrokerContractID_for_PatientID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PatientID", Parameter.PatientID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"TreatmentDate", Parameter.TreatmentDate);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"TakeExpiredConsentsIntoAccount", Parameter.TakeExpiredConsentsIntoAccount);



			List<CAS_GItBCIDfPID_1232_raw> results = new List<CAS_GItBCIDfPID_1232_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "HEC_CRT_InsuranceToBrokerContract_ParticipatingPatientID","insurance_to_broker_contract","contract_valid_through","contract_consent_valid_for_months","contract_id","patient_consent_valid_from","contract_name","drug_id","diagnosis_id" });
				while(reader.Read())
				{
					CAS_GItBCIDfPID_1232_raw resultItem = new CAS_GItBCIDfPID_1232_raw();
					//0:Parameter HEC_CRT_InsuranceToBrokerContract_ParticipatingPatientID of type Guid
					resultItem.HEC_CRT_InsuranceToBrokerContract_ParticipatingPatientID = reader.GetGuid(0);
					//1:Parameter insurance_to_broker_contract of type Guid
					resultItem.insurance_to_broker_contract = reader.GetGuid(1);
					//2:Parameter contract_valid_through of type DateTime
					resultItem.contract_valid_through = reader.GetDate(2);
					//3:Parameter contract_consent_valid_for_months of type int
					resultItem.contract_consent_valid_for_months = reader.GetInteger(3);
					//4:Parameter contract_id of type Guid
					resultItem.contract_id = reader.GetGuid(4);
					//5:Parameter patient_consent_valid_from of type DateTime
					resultItem.patient_consent_valid_from = reader.GetDate(5);
					//6:Parameter contract_name of type String
					resultItem.contract_name = reader.GetString(6);
					//7:Parameter drug_id of type Guid
					resultItem.drug_id = reader.GetGuid(7);
					//8:Parameter diagnosis_id of type Guid
					resultItem.diagnosis_id = reader.GetGuid(8);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_InsuranceToBrokerContractID_for_PatientID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = CAS_GItBCIDfPID_1232_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_CAS_GItBCIDfPID_1232_Array Invoke(string ConnectionString,P_CAS_GItBCIDfPID_1232 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_CAS_GItBCIDfPID_1232_Array Invoke(DbConnection Connection,P_CAS_GItBCIDfPID_1232 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_CAS_GItBCIDfPID_1232_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_CAS_GItBCIDfPID_1232 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_CAS_GItBCIDfPID_1232_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_CAS_GItBCIDfPID_1232 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_CAS_GItBCIDfPID_1232_Array functionReturn = new FR_CAS_GItBCIDfPID_1232_Array();
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

				throw new Exception("Exception occured in method cls_Get_InsuranceToBrokerContractID_for_PatientID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class CAS_GItBCIDfPID_1232_raw 
	{
		public Guid HEC_CRT_InsuranceToBrokerContract_ParticipatingPatientID; 
		public Guid insurance_to_broker_contract; 
		public DateTime contract_valid_through; 
		public int contract_consent_valid_for_months; 
		public Guid contract_id; 
		public DateTime patient_consent_valid_from; 
		public String contract_name; 
		public Guid drug_id; 
		public Guid diagnosis_id; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static CAS_GItBCIDfPID_1232[] Convert(List<CAS_GItBCIDfPID_1232_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_CAS_GItBCIDfPID_1232 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.HEC_CRT_InsuranceToBrokerContract_ParticipatingPatientID)).ToArray()
	group el_CAS_GItBCIDfPID_1232 by new 
	{ 
		el_CAS_GItBCIDfPID_1232.HEC_CRT_InsuranceToBrokerContract_ParticipatingPatientID,

	}
	into gfunct_CAS_GItBCIDfPID_1232
	select new CAS_GItBCIDfPID_1232
	{     
		HEC_CRT_InsuranceToBrokerContract_ParticipatingPatientID = gfunct_CAS_GItBCIDfPID_1232.Key.HEC_CRT_InsuranceToBrokerContract_ParticipatingPatientID ,
		insurance_to_broker_contract = gfunct_CAS_GItBCIDfPID_1232.FirstOrDefault().insurance_to_broker_contract ,
		contract_valid_through = gfunct_CAS_GItBCIDfPID_1232.FirstOrDefault().contract_valid_through ,
		contract_consent_valid_for_months = gfunct_CAS_GItBCIDfPID_1232.FirstOrDefault().contract_consent_valid_for_months ,
		contract_id = gfunct_CAS_GItBCIDfPID_1232.FirstOrDefault().contract_id ,
		patient_consent_valid_from = gfunct_CAS_GItBCIDfPID_1232.FirstOrDefault().patient_consent_valid_from ,
		contract_name = gfunct_CAS_GItBCIDfPID_1232.FirstOrDefault().contract_name ,

		drugs = 
		(
			from el_drugs in gfunct_CAS_GItBCIDfPID_1232.Where(element => !EqualsDefaultValue(element.drug_id)).ToArray()
			group el_drugs by new 
			{ 
				el_drugs.drug_id,

			}
			into gfunct_drugs
			select new CAS_GItBCIDfPID_1232a
			{     
				drug_id = gfunct_drugs.Key.drug_id ,

			}
		).ToArray(),
		diagnoses = 
		(
			from el_diagnoses in gfunct_CAS_GItBCIDfPID_1232.Where(element => !EqualsDefaultValue(element.diagnosis_id)).ToArray()
			group el_diagnoses by new 
			{ 
				el_diagnoses.diagnosis_id,

			}
			into gfunct_diagnoses
			select new CAS_GItBCIDfPID_1232b
			{     
				diagnosis_id = gfunct_diagnoses.Key.diagnosis_id ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_CAS_GItBCIDfPID_1232_Array : FR_Base
	{
		public CAS_GItBCIDfPID_1232[] Result	{ get; set; } 
		public FR_CAS_GItBCIDfPID_1232_Array() : base() {}

		public FR_CAS_GItBCIDfPID_1232_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_CAS_GItBCIDfPID_1232 for attribute P_CAS_GItBCIDfPID_1232
		[DataContract]
		public class P_CAS_GItBCIDfPID_1232 
		{
			//Standard type parameters
			[DataMember]
			public Guid PatientID { get; set; } 
			[DataMember]
			public DateTime TreatmentDate { get; set; } 
			[DataMember]
			public Boolean TakeExpiredConsentsIntoAccount { get; set; } 

		}
		#endregion
		#region SClass CAS_GItBCIDfPID_1232 for attribute CAS_GItBCIDfPID_1232
		[DataContract]
		public class CAS_GItBCIDfPID_1232 
		{
			[DataMember]
			public CAS_GItBCIDfPID_1232a[] drugs { get; set; }
			[DataMember]
			public CAS_GItBCIDfPID_1232b[] diagnoses { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid HEC_CRT_InsuranceToBrokerContract_ParticipatingPatientID { get; set; } 
			[DataMember]
			public Guid insurance_to_broker_contract { get; set; } 
			[DataMember]
			public DateTime contract_valid_through { get; set; } 
			[DataMember]
			public int contract_consent_valid_for_months { get; set; } 
			[DataMember]
			public Guid contract_id { get; set; } 
			[DataMember]
			public DateTime patient_consent_valid_from { get; set; } 
			[DataMember]
			public String contract_name { get; set; } 

		}
		#endregion
		#region SClass CAS_GItBCIDfPID_1232a for attribute drugs
		[DataContract]
		public class CAS_GItBCIDfPID_1232a 
		{
			//Standard type parameters
			[DataMember]
			public Guid drug_id { get; set; } 

		}
		#endregion
		#region SClass CAS_GItBCIDfPID_1232b for attribute diagnoses
		[DataContract]
		public class CAS_GItBCIDfPID_1232b 
		{
			//Standard type parameters
			[DataMember]
			public Guid diagnosis_id { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_CAS_GItBCIDfPID_1232_Array cls_Get_InsuranceToBrokerContractID_for_PatientID(,P_CAS_GItBCIDfPID_1232 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_CAS_GItBCIDfPID_1232_Array invocationResult = cls_Get_InsuranceToBrokerContractID_for_PatientID.Invoke(connectionString,P_CAS_GItBCIDfPID_1232 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Case.Atomic.Retrieval.P_CAS_GItBCIDfPID_1232();
parameter.PatientID = ...;
parameter.TreatmentDate = ...;
parameter.TakeExpiredConsentsIntoAccount = ...;

*/
