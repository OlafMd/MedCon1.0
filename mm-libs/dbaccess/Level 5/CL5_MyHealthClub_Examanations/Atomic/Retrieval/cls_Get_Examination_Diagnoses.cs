/* 
 * Generated on 2/10/2015 9:23:18 AM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Linq;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL5_MyHealthClub_Examanations.Atomic.Retrieval
{
	[Serializable]
	public class cls_Get_Examination_Diagnoses
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5EX_GED_1640_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5EX_GED_1640 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5EX_GED_1640_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_Examanations.Atomic.Retrieval.SQL.cls_Get_Examination_Diagnoses.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PatientID", Parameter.PatientID);
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ExaminationID", Parameter.ExaminationID);


			List<L5EX_GED_1640> results = new List<L5EX_GED_1640>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "ICD10_Code","PotentialDiagnosis_Name_DictID","R_ScheduledExpiryDate","HEC_Patient_DiagnosisID","HEC_ACT_PerformedAction_RefID","PotentialDiagnosisITL" });
				while(reader.Read())
				{
					L5EX_GED_1640 resultItem = new L5EX_GED_1640();
					//0:Parameter ICD10_Code of type String
					resultItem.ICD10_Code = reader.GetString(0);
					//1:Parameter PotentialDiagnosis_Name of type Dict
					resultItem.PotentialDiagnosis_Name = reader.GetDictionary(1);
					resultItem.PotentialDiagnosis_Name.SourceTable = "hec_dia_potentialdiagnoses";
					loader.Append(resultItem.PotentialDiagnosis_Name);
					//2:Parameter R_ScheduledExpiryDate of type DateTime
					resultItem.R_ScheduledExpiryDate = reader.GetDate(2);
					//3:Parameter HEC_Patient_DiagnosisID of type Guid
					resultItem.HEC_Patient_DiagnosisID = reader.GetGuid(3);
					//4:Parameter HEC_ACT_PerformedAction_RefID of type Guid
					resultItem.HEC_ACT_PerformedAction_RefID = reader.GetGuid(4);
					//5:Parameter PotentialDiagnosisITL of type String
					resultItem.PotentialDiagnosisITL = reader.GetString(5);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw ex;
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
		public static FR_L5EX_GED_1640_Array Invoke(string ConnectionString,P_L5EX_GED_1640 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5EX_GED_1640_Array Invoke(DbConnection Connection,P_L5EX_GED_1640 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5EX_GED_1640_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5EX_GED_1640 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5EX_GED_1640_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5EX_GED_1640 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5EX_GED_1640_Array functionReturn = new FR_L5EX_GED_1640_Array();
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

				throw ex;
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5EX_GED_1640_Array : FR_Base
	{
		public L5EX_GED_1640[] Result	{ get; set; } 
		public FR_L5EX_GED_1640_Array() : base() {}

		public FR_L5EX_GED_1640_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5EX_GED_1640 for attribute P_L5EX_GED_1640
		[Serializable]
		public class P_L5EX_GED_1640 
		{
			//Standard type parameters
			public Guid PatientID; 
			public Guid ExaminationID; 

		}
		#endregion
		#region SClass L5EX_GED_1640 for attribute L5EX_GED_1640
		[Serializable]
		public class L5EX_GED_1640 
		{
			//Standard type parameters
			public String ICD10_Code; 
			public Dict PotentialDiagnosis_Name; 
			public DateTime R_ScheduledExpiryDate; 
			public Guid HEC_Patient_DiagnosisID; 
			public Guid HEC_ACT_PerformedAction_RefID; 
			public String PotentialDiagnosisITL; 

		}
		#endregion

	#endregion
}
