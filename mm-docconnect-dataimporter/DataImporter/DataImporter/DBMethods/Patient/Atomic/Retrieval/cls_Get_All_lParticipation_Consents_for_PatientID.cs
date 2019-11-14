/* 
 * Generated on 1/20/2017 2:31:25 PM
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
    /// var result = cls_Get_All_lParticipation_Consents_for_PatientID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_All_lParticipation_Consents_for_PatientID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_PA_GAPCFPID_1119_Array Execute(DbConnection Connection,DbTransaction Transaction,P_PA_GAPCFPID_1119 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_PA_GAPCFPID_1119_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "DataImporter.DBMethods.Patient.Atomic.Retrieval.SQL.cls_Get_All_lParticipation_Consents_for_PatientID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PatientID", Parameter.PatientID);



			List<PA_GAPCFPID_1119_raw> results = new List<PA_GAPCFPID_1119_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "participationFrom","partiicipationThrough","ContractName","contractValidFrom","contractValidThrough","HEC_CRT_InsuranceToBrokerContract_ParticipatingPatientID","contractID","IsDeleted" });
				while(reader.Read())
				{
					PA_GAPCFPID_1119_raw resultItem = new PA_GAPCFPID_1119_raw();
					//0:Parameter participationFrom of type DateTime
					resultItem.participationFrom = reader.GetDate(0);
					//1:Parameter partiicipationThrough of type DateTime
					resultItem.partiicipationThrough = reader.GetDate(1);
					//2:Parameter ContractName of type String
					resultItem.ContractName = reader.GetString(2);
					//3:Parameter contractValidFrom of type DateTime
					resultItem.contractValidFrom = reader.GetDate(3);
					//4:Parameter contractValidThrough of type DateTime
					resultItem.contractValidThrough = reader.GetDate(4);
					//5:Parameter HEC_CRT_InsuranceToBrokerContract_ParticipatingPatientID of type Guid
					resultItem.HEC_CRT_InsuranceToBrokerContract_ParticipatingPatientID = reader.GetGuid(5);
					//6:Parameter contractID of type Guid
					resultItem.contractID = reader.GetGuid(6);
					//7:Parameter IsDeleted of type Boolean
					resultItem.IsDeleted = reader.GetBoolean(7);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_All_lParticipation_Consents_for_PatientID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = PA_GAPCFPID_1119_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_PA_GAPCFPID_1119_Array Invoke(string ConnectionString,P_PA_GAPCFPID_1119 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_PA_GAPCFPID_1119_Array Invoke(DbConnection Connection,P_PA_GAPCFPID_1119 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_PA_GAPCFPID_1119_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_PA_GAPCFPID_1119 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_PA_GAPCFPID_1119_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_PA_GAPCFPID_1119 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_PA_GAPCFPID_1119_Array functionReturn = new FR_PA_GAPCFPID_1119_Array();
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

				throw new Exception("Exception occured in method cls_Get_All_lParticipation_Consents_for_PatientID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class PA_GAPCFPID_1119_raw 
	{
		public DateTime participationFrom; 
		public DateTime partiicipationThrough; 
		public String ContractName; 
		public DateTime contractValidFrom; 
		public DateTime contractValidThrough; 
		public Guid HEC_CRT_InsuranceToBrokerContract_ParticipatingPatientID; 
		public Guid contractID; 
		public Boolean IsDeleted; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static PA_GAPCFPID_1119[] Convert(List<PA_GAPCFPID_1119_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_PA_GAPCFPID_1119 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.HEC_CRT_InsuranceToBrokerContract_ParticipatingPatientID)).ToArray()
	group el_PA_GAPCFPID_1119 by new 
	{ 
		el_PA_GAPCFPID_1119.HEC_CRT_InsuranceToBrokerContract_ParticipatingPatientID,

	}
	into gfunct_PA_GAPCFPID_1119
	select new PA_GAPCFPID_1119
	{     
		participationFrom = gfunct_PA_GAPCFPID_1119.FirstOrDefault().participationFrom ,
		partiicipationThrough = gfunct_PA_GAPCFPID_1119.FirstOrDefault().partiicipationThrough ,
		ContractName = gfunct_PA_GAPCFPID_1119.FirstOrDefault().ContractName ,
		contractValidFrom = gfunct_PA_GAPCFPID_1119.FirstOrDefault().contractValidFrom ,
		contractValidThrough = gfunct_PA_GAPCFPID_1119.FirstOrDefault().contractValidThrough ,
		HEC_CRT_InsuranceToBrokerContract_ParticipatingPatientID = gfunct_PA_GAPCFPID_1119.Key.HEC_CRT_InsuranceToBrokerContract_ParticipatingPatientID ,
		contractID = gfunct_PA_GAPCFPID_1119.FirstOrDefault().contractID ,
		IsDeleted = gfunct_PA_GAPCFPID_1119.FirstOrDefault().IsDeleted ,

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_PA_GAPCFPID_1119_Array : FR_Base
	{
		public PA_GAPCFPID_1119[] Result	{ get; set; } 
		public FR_PA_GAPCFPID_1119_Array() : base() {}

		public FR_PA_GAPCFPID_1119_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_PA_GAPCFPID_1119 for attribute P_PA_GAPCFPID_1119
		[DataContract]
		public class P_PA_GAPCFPID_1119 
		{
			//Standard type parameters
			[DataMember]
			public Guid PatientID { get; set; } 

		}
		#endregion
		#region SClass PA_GAPCFPID_1119 for attribute PA_GAPCFPID_1119
		[DataContract]
		public class PA_GAPCFPID_1119 
		{
			//Standard type parameters
			[DataMember]
			public DateTime participationFrom { get; set; } 
			[DataMember]
			public DateTime partiicipationThrough { get; set; } 
			[DataMember]
			public String ContractName { get; set; } 
			[DataMember]
			public DateTime contractValidFrom { get; set; } 
			[DataMember]
			public DateTime contractValidThrough { get; set; } 
			[DataMember]
			public Guid HEC_CRT_InsuranceToBrokerContract_ParticipatingPatientID { get; set; } 
			[DataMember]
			public Guid contractID { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_PA_GAPCFPID_1119_Array cls_Get_All_lParticipation_Consents_for_PatientID(,P_PA_GAPCFPID_1119 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_PA_GAPCFPID_1119_Array invocationResult = cls_Get_All_lParticipation_Consents_for_PatientID.Invoke(connectionString,P_PA_GAPCFPID_1119 Parameter,securityTicket);
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
var parameter = new DataImporter.DBMethods.Patient.Atomic.Retrieval.P_PA_GAPCFPID_1119();
parameter.PatientID = ...;

*/
