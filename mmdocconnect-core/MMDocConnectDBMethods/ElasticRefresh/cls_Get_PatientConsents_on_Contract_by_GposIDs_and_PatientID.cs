/* 
 * Generated on 03/02/17 20:20:39
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

namespace MMDocConnectDBMethods.ElasticRefresh
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_PatientConsents_on_Contract_by_GposIDs_and_PatientID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_PatientConsents_on_Contract_by_GposIDs_and_PatientID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_ER_GPCoCbGposIDsaPID_2020_Array Execute(DbConnection Connection,DbTransaction Transaction,P_ER_GPCoCbGposIDsaPID_2020 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_ER_GPCoCbGposIDsaPID_2020_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.ElasticRefresh.SQL.cls_Get_PatientConsents_on_Contract_by_GposIDs_and_PatientID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PatientID", Parameter.PatientID);

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@GposIDs"," IN $$GposIDs$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$GposIDs$",Parameter.GposIDs);


			List<ER_GPCoCbGposIDsaPID_2020> results = new List<ER_GPCoCbGposIDsaPID_2020>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "consent_valid_from","contract_id" });
				while(reader.Read())
				{
					ER_GPCoCbGposIDsaPID_2020 resultItem = new ER_GPCoCbGposIDsaPID_2020();
					//0:Parameter consent_valid_from of type DateTime
					resultItem.consent_valid_from = reader.GetDate(0);
					//1:Parameter contract_id of type Guid
					resultItem.contract_id = reader.GetGuid(1);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_PatientConsents_on_Contract_by_GposIDs_and_PatientID",ex);
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
		public static FR_ER_GPCoCbGposIDsaPID_2020_Array Invoke(string ConnectionString,P_ER_GPCoCbGposIDsaPID_2020 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_ER_GPCoCbGposIDsaPID_2020_Array Invoke(DbConnection Connection,P_ER_GPCoCbGposIDsaPID_2020 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_ER_GPCoCbGposIDsaPID_2020_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_ER_GPCoCbGposIDsaPID_2020 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_ER_GPCoCbGposIDsaPID_2020_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_ER_GPCoCbGposIDsaPID_2020 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_ER_GPCoCbGposIDsaPID_2020_Array functionReturn = new FR_ER_GPCoCbGposIDsaPID_2020_Array();
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

				throw new Exception("Exception occured in method cls_Get_PatientConsents_on_Contract_by_GposIDs_and_PatientID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_ER_GPCoCbGposIDsaPID_2020_Array : FR_Base
	{
		public ER_GPCoCbGposIDsaPID_2020[] Result	{ get; set; } 
		public FR_ER_GPCoCbGposIDsaPID_2020_Array() : base() {}

		public FR_ER_GPCoCbGposIDsaPID_2020_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_ER_GPCoCbGposIDsaPID_2020 for attribute P_ER_GPCoCbGposIDsaPID_2020
		[DataContract]
		public class P_ER_GPCoCbGposIDsaPID_2020 
		{
			//Standard type parameters
			[DataMember]
			public Guid PatientID { get; set; } 
			[DataMember]
			public Guid[] GposIDs { get; set; } 

		}
		#endregion
		#region SClass ER_GPCoCbGposIDsaPID_2020 for attribute ER_GPCoCbGposIDsaPID_2020
		[DataContract]
		public class ER_GPCoCbGposIDsaPID_2020 
		{
			//Standard type parameters
			[DataMember]
			public DateTime consent_valid_from { get; set; } 
			[DataMember]
			public Guid contract_id { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_ER_GPCoCbGposIDsaPID_2020_Array cls_Get_PatientConsents_on_Contract_by_GposIDs_and_PatientID(,P_ER_GPCoCbGposIDsaPID_2020 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_ER_GPCoCbGposIDsaPID_2020_Array invocationResult = cls_Get_PatientConsents_on_Contract_by_GposIDs_and_PatientID.Invoke(connectionString,P_ER_GPCoCbGposIDsaPID_2020 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.ElasticRefresh.P_ER_GPCoCbGposIDsaPID_2020();
parameter.PatientID = ...;
parameter.GposIDs = ...;

*/
