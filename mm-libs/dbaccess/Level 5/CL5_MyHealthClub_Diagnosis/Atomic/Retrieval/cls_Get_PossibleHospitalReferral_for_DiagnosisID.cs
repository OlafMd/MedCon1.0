/* 
 * Generated on 10/7/2014 11:57:35 AM
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

namespace CL5_MyHealthClub_Diagnosis.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_PossibleHospitalReferral_for_DiagnosisID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_PossibleHospitalReferral_for_DiagnosisID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5DI_GPHRfDID_1139_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5DI_GPHRfDID_1139 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5DI_GPHRfDID_1139_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_Diagnosis.Atomic.Retrieval.SQL.cls_Get_PossibleHospitalReferral_for_DiagnosisID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"DiagnosisID", Parameter.DiagnosisID);



			List<L5DI_GPHRfDID_1139> results = new List<L5DI_GPHRfDID_1139>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "HospitalName","ContactPersonTitle","ContactPersonFirstName","ContactPersonLastName","Street_Name","Street_Number","Town","Contact_Telephone","MedicalPracticeType_Name_DictID","PotentialDiagnosis_RefID","HEC_DIA_FrequentPotentialDiagnosisID","MedicalPractice_RefID" });
				while(reader.Read())
				{
					L5DI_GPHRfDID_1139 resultItem = new L5DI_GPHRfDID_1139();
					//0:Parameter HospitalName of type String
					resultItem.HospitalName = reader.GetString(0);
					//1:Parameter ContactPersonTitle of type String
					resultItem.ContactPersonTitle = reader.GetString(1);
					//2:Parameter ContactPersonFirstName of type String
					resultItem.ContactPersonFirstName = reader.GetString(2);
					//3:Parameter ContactPersonLastName of type String
					resultItem.ContactPersonLastName = reader.GetString(3);
					//4:Parameter Street_Name of type String
					resultItem.Street_Name = reader.GetString(4);
					//5:Parameter Street_Number of type String
					resultItem.Street_Number = reader.GetString(5);
					//6:Parameter Town of type String
					resultItem.Town = reader.GetString(6);
					//7:Parameter Contact_Telephone of type String
					resultItem.Contact_Telephone = reader.GetString(7);
					//8:Parameter MedicalPracticeType_Name of type Dict
					resultItem.MedicalPracticeType_Name = reader.GetDictionary(8);
					resultItem.MedicalPracticeType_Name.SourceTable = "hec_medicalpractice_types";
					loader.Append(resultItem.MedicalPracticeType_Name);
					//9:Parameter PotentialDiagnosis_RefID of type Guid
					resultItem.PotentialDiagnosis_RefID = reader.GetGuid(9);
					//10:Parameter HEC_DIA_FrequentPotentialDiagnosisID of type Guid
					resultItem.HEC_DIA_FrequentPotentialDiagnosisID = reader.GetGuid(10);
					//11:Parameter MedicalPractice_RefID of type Guid
					resultItem.MedicalPractice_RefID = reader.GetGuid(11);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_PossibleHospitalReferral_for_DiagnosisID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = results.ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5DI_GPHRfDID_1139_Array Invoke(string ConnectionString,P_L5DI_GPHRfDID_1139 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5DI_GPHRfDID_1139_Array Invoke(DbConnection Connection,P_L5DI_GPHRfDID_1139 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5DI_GPHRfDID_1139_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5DI_GPHRfDID_1139 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5DI_GPHRfDID_1139_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5DI_GPHRfDID_1139 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5DI_GPHRfDID_1139_Array functionReturn = new FR_L5DI_GPHRfDID_1139_Array();
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

				throw new Exception("Exception occured in method cls_Get_PossibleHospitalReferral_for_DiagnosisID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5DI_GPHRfDID_1139_Array : FR_Base
	{
		public L5DI_GPHRfDID_1139[] Result	{ get; set; } 
		public FR_L5DI_GPHRfDID_1139_Array() : base() {}

		public FR_L5DI_GPHRfDID_1139_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5DI_GPHRfDID_1139 for attribute P_L5DI_GPHRfDID_1139
		[DataContract]
		public class P_L5DI_GPHRfDID_1139 
		{
			//Standard type parameters
			[DataMember]
			public Guid DiagnosisID { get; set; } 

		}
		#endregion
		#region SClass L5DI_GPHRfDID_1139 for attribute L5DI_GPHRfDID_1139
		[DataContract]
		public class L5DI_GPHRfDID_1139 
		{
			//Standard type parameters
			[DataMember]
			public String HospitalName { get; set; } 
			[DataMember]
			public String ContactPersonTitle { get; set; } 
			[DataMember]
			public String ContactPersonFirstName { get; set; } 
			[DataMember]
			public String ContactPersonLastName { get; set; } 
			[DataMember]
			public String Street_Name { get; set; } 
			[DataMember]
			public String Street_Number { get; set; } 
			[DataMember]
			public String Town { get; set; } 
			[DataMember]
			public String Contact_Telephone { get; set; } 
			[DataMember]
			public Dict MedicalPracticeType_Name { get; set; } 
			[DataMember]
			public Guid PotentialDiagnosis_RefID { get; set; } 
			[DataMember]
			public Guid HEC_DIA_FrequentPotentialDiagnosisID { get; set; } 
			[DataMember]
			public Guid MedicalPractice_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5DI_GPHRfDID_1139_Array cls_Get_PossibleHospitalReferral_for_DiagnosisID(,P_L5DI_GPHRfDID_1139 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5DI_GPHRfDID_1139_Array invocationResult = cls_Get_PossibleHospitalReferral_for_DiagnosisID.Invoke(connectionString,P_L5DI_GPHRfDID_1139 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_Diagnosis.Atomic.Retrieval.P_L5DI_GPHRfDID_1139();
parameter.DiagnosisID = ...;

*/
