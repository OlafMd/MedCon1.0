/* 
 * Generated on 1/18/2017 3:50:24 PM
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
    /// var result = cls_Get_Cases_for_SubmissionReport_for_CaseIDs.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Cases_for_SubmissionReport_for_CaseIDs
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_CAS_GCfSRfCIDs_1855_Array Execute(DbConnection Connection,DbTransaction Transaction,P_CAS_GCfSRfCIDs_1855 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_CAS_GCfSRfCIDs_1855_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.Case.Atomic.Retrieval.SQL.cls_Get_Cases_for_SubmissionReport_for_CaseIDs.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@CaseIDs"," IN $$CaseIDs$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$CaseIDs$",Parameter.CaseIDs);


			List<CAS_GCfSRfCIDs_1855> results = new List<CAS_GCfSRfCIDs_1855>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CaseNumber","CaseID","TreatmentPlannedActionID","PatientID","TreatmentDoctorID","DrugID","DiagnoseID","Localization","TreatmentDate","CaseCreationDate" });
				while(reader.Read())
				{
					CAS_GCfSRfCIDs_1855 resultItem = new CAS_GCfSRfCIDs_1855();
					//0:Parameter CaseNumber of type String
					resultItem.CaseNumber = reader.GetString(0);
					//1:Parameter CaseID of type Guid
					resultItem.CaseID = reader.GetGuid(1);
					//2:Parameter TreatmentPlannedActionID of type Guid
					resultItem.TreatmentPlannedActionID = reader.GetGuid(2);
					//3:Parameter PatientID of type Guid
					resultItem.PatientID = reader.GetGuid(3);
					//4:Parameter TreatmentDoctorID of type Guid
					resultItem.TreatmentDoctorID = reader.GetGuid(4);
					//5:Parameter DrugID of type Guid
					resultItem.DrugID = reader.GetGuid(5);
					//6:Parameter DiagnoseID of type Guid
					resultItem.DiagnoseID = reader.GetGuid(6);
					//7:Parameter Localization of type String
					resultItem.Localization = reader.GetString(7);
					//8:Parameter TreatmentDate of type DateTime
					resultItem.TreatmentDate = reader.GetDate(8);
					//9:Parameter CaseCreationDate of type DateTime
					resultItem.CaseCreationDate = reader.GetDate(9);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Cases_for_SubmissionReport_for_CaseIDs",ex);
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
		public static FR_CAS_GCfSRfCIDs_1855_Array Invoke(string ConnectionString,P_CAS_GCfSRfCIDs_1855 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_CAS_GCfSRfCIDs_1855_Array Invoke(DbConnection Connection,P_CAS_GCfSRfCIDs_1855 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_CAS_GCfSRfCIDs_1855_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_CAS_GCfSRfCIDs_1855 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_CAS_GCfSRfCIDs_1855_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_CAS_GCfSRfCIDs_1855 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_CAS_GCfSRfCIDs_1855_Array functionReturn = new FR_CAS_GCfSRfCIDs_1855_Array();
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

				throw new Exception("Exception occured in method cls_Get_Cases_for_SubmissionReport_for_CaseIDs",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_CAS_GCfSRfCIDs_1855_Array : FR_Base
	{
		public CAS_GCfSRfCIDs_1855[] Result	{ get; set; } 
		public FR_CAS_GCfSRfCIDs_1855_Array() : base() {}

		public FR_CAS_GCfSRfCIDs_1855_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_CAS_GCfSRfCIDs_1855 for attribute P_CAS_GCfSRfCIDs_1855
		[DataContract]
		public class P_CAS_GCfSRfCIDs_1855 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] CaseIDs { get; set; } 

		}
		#endregion
		#region SClass CAS_GCfSRfCIDs_1855 for attribute CAS_GCfSRfCIDs_1855
		[DataContract]
		public class CAS_GCfSRfCIDs_1855 
		{
			//Standard type parameters
			[DataMember]
			public String CaseNumber { get; set; } 
			[DataMember]
			public Guid CaseID { get; set; } 
			[DataMember]
			public Guid TreatmentPlannedActionID { get; set; } 
			[DataMember]
			public Guid PatientID { get; set; } 
			[DataMember]
			public Guid TreatmentDoctorID { get; set; } 
			[DataMember]
			public Guid DrugID { get; set; } 
			[DataMember]
			public Guid DiagnoseID { get; set; } 
			[DataMember]
			public String Localization { get; set; } 
			[DataMember]
			public DateTime TreatmentDate { get; set; } 
			[DataMember]
			public DateTime CaseCreationDate { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_CAS_GCfSRfCIDs_1855_Array cls_Get_Cases_for_SubmissionReport_for_CaseIDs(,P_CAS_GCfSRfCIDs_1855 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_CAS_GCfSRfCIDs_1855_Array invocationResult = cls_Get_Cases_for_SubmissionReport_for_CaseIDs.Invoke(connectionString,P_CAS_GCfSRfCIDs_1855 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Case.Atomic.Retrieval.P_CAS_GCfSRfCIDs_1855();
parameter.CaseIDs = ...;

*/
