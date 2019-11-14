/* 
 * Generated on 3/27/2015 12:36:07
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

namespace CL5_MyHealthClub_Examanations.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Patient_Examination_Diagnoses.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Patient_Examination_Diagnoses
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5EX_GPED_1922_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5EX_GPED_1922 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5EX_GPED_1922_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_Examanations.Atomic.Retrieval.SQL.cls_Get_Patient_Examination_Diagnoses.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PatientID", Parameter.PatientID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ExaminationID", Parameter.ExaminationID);



			List<L5EX_GPED_1922> results = new List<L5EX_GPED_1922>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "ICD10_Code","PotentialDiagnosis_Name_DictID","HEC_Patient_DiagnosisID","PotentialDiagnosisITL","ScheduledExpiryDate" });
				while(reader.Read())
				{
					L5EX_GPED_1922 resultItem = new L5EX_GPED_1922();
					//0:Parameter ICD10_Code of type String
					resultItem.ICD10_Code = reader.GetString(0);
					//1:Parameter PotentialDiagnosis_Name of type Dict
					resultItem.PotentialDiagnosis_Name = reader.GetDictionary(1);
					resultItem.PotentialDiagnosis_Name.SourceTable = "hec_dia_potentialdiagnoses";
					loader.Append(resultItem.PotentialDiagnosis_Name);
					//2:Parameter HEC_Patient_DiagnosisID of type Guid
					resultItem.HEC_Patient_DiagnosisID = reader.GetGuid(2);
					//3:Parameter PotentialDiagnosisITL of type String
					resultItem.PotentialDiagnosisITL = reader.GetString(3);
					//4:Parameter ScheduledExpiryDate of type DateTime
					resultItem.ScheduledExpiryDate = reader.GetDate(4);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Patient_Examination_Diagnoses",ex);
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
		public static FR_L5EX_GPED_1922_Array Invoke(string ConnectionString,P_L5EX_GPED_1922 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5EX_GPED_1922_Array Invoke(DbConnection Connection,P_L5EX_GPED_1922 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5EX_GPED_1922_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5EX_GPED_1922 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5EX_GPED_1922_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5EX_GPED_1922 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5EX_GPED_1922_Array functionReturn = new FR_L5EX_GPED_1922_Array();
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

				throw new Exception("Exception occured in method cls_Get_Patient_Examination_Diagnoses",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5EX_GPED_1922_Array : FR_Base
	{
		public L5EX_GPED_1922[] Result	{ get; set; } 
		public FR_L5EX_GPED_1922_Array() : base() {}

		public FR_L5EX_GPED_1922_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5EX_GPED_1922 for attribute P_L5EX_GPED_1922
		[DataContract]
		public class P_L5EX_GPED_1922 
		{
			//Standard type parameters
			[DataMember]
			public Guid PatientID { get; set; } 
			[DataMember]
			public Guid ExaminationID { get; set; } 

		}
		#endregion
		#region SClass L5EX_GPED_1922 for attribute L5EX_GPED_1922
		[DataContract]
		public class L5EX_GPED_1922 
		{
			//Standard type parameters
			[DataMember]
			public String ICD10_Code { get; set; } 
			[DataMember]
			public Dict PotentialDiagnosis_Name { get; set; } 
			[DataMember]
			public Guid HEC_Patient_DiagnosisID { get; set; } 
			[DataMember]
			public String PotentialDiagnosisITL { get; set; } 
			[DataMember]
			public DateTime ScheduledExpiryDate { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5EX_GPED_1922_Array cls_Get_Patient_Examination_Diagnoses(,P_L5EX_GPED_1922 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5EX_GPED_1922_Array invocationResult = cls_Get_Patient_Examination_Diagnoses.Invoke(connectionString,P_L5EX_GPED_1922 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_Examanations.Atomic.Retrieval.P_L5EX_GPED_1922();
parameter.PatientID = ...;
parameter.ExaminationID = ...;

*/
