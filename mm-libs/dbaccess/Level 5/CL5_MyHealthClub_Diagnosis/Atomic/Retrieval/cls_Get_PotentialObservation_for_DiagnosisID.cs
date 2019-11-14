/* 
 * Generated on 10/6/2014 12:17:22 PM
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
    /// var result = cls_Get_PotentialObservation_for_DiagnosisID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_PotentialObservation_for_DiagnosisID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5DI_GPOfDID_1216_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5DI_GPOfDID_1216 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5DI_GPOfDID_1216_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_Diagnosis.Atomic.Retrieval.SQL.cls_Get_PotentialObservation_for_DiagnosisID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"DiagnosisID", Parameter.DiagnosisID);



			List<L5DI_GPOfDID_1216> results = new List<L5DI_GPOfDID_1216>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "HEC_DIA_TypicalPotentialObservationID","PotentialObservation_RefID","PotentialDiagnosis_RefID","Observation_Text_DictID" });
				while(reader.Read())
				{
					L5DI_GPOfDID_1216 resultItem = new L5DI_GPOfDID_1216();
					//0:Parameter HEC_DIA_TypicalPotentialObservationID of type Guid
					resultItem.HEC_DIA_TypicalPotentialObservationID = reader.GetGuid(0);
					//1:Parameter PotentialObservation_RefID of type Guid
					resultItem.PotentialObservation_RefID = reader.GetGuid(1);
					//2:Parameter PotentialDiagnosis_RefID of type Guid
					resultItem.PotentialDiagnosis_RefID = reader.GetGuid(2);
					//3:Parameter Observation_Text of type Dict
					resultItem.Observation_Text = reader.GetDictionary(3);
					resultItem.Observation_Text.SourceTable = "hec_potentialobservations";
					loader.Append(resultItem.Observation_Text);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_PotentialObservation_for_DiagnosisID",ex);
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
		public static FR_L5DI_GPOfDID_1216_Array Invoke(string ConnectionString,P_L5DI_GPOfDID_1216 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5DI_GPOfDID_1216_Array Invoke(DbConnection Connection,P_L5DI_GPOfDID_1216 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5DI_GPOfDID_1216_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5DI_GPOfDID_1216 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5DI_GPOfDID_1216_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5DI_GPOfDID_1216 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5DI_GPOfDID_1216_Array functionReturn = new FR_L5DI_GPOfDID_1216_Array();
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

				throw new Exception("Exception occured in method cls_Get_PotentialObservation_for_DiagnosisID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5DI_GPOfDID_1216_Array : FR_Base
	{
		public L5DI_GPOfDID_1216[] Result	{ get; set; } 
		public FR_L5DI_GPOfDID_1216_Array() : base() {}

		public FR_L5DI_GPOfDID_1216_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5DI_GPOfDID_1216 for attribute P_L5DI_GPOfDID_1216
		[DataContract]
		public class P_L5DI_GPOfDID_1216 
		{
			//Standard type parameters
			[DataMember]
			public Guid DiagnosisID { get; set; } 

		}
		#endregion
		#region SClass L5DI_GPOfDID_1216 for attribute L5DI_GPOfDID_1216
		[DataContract]
		public class L5DI_GPOfDID_1216 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_DIA_TypicalPotentialObservationID { get; set; } 
			[DataMember]
			public Guid PotentialObservation_RefID { get; set; } 
			[DataMember]
			public Guid PotentialDiagnosis_RefID { get; set; } 
			[DataMember]
			public Dict Observation_Text { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5DI_GPOfDID_1216_Array cls_Get_PotentialObservation_for_DiagnosisID(,P_L5DI_GPOfDID_1216 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5DI_GPOfDID_1216_Array invocationResult = cls_Get_PotentialObservation_for_DiagnosisID.Invoke(connectionString,P_L5DI_GPOfDID_1216 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_Diagnosis.Atomic.Retrieval.P_L5DI_GPOfDID_1216();
parameter.DiagnosisID = ...;

*/
