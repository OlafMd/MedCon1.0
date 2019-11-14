/* 
 * Generated on 02/09/17 15:50:52
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
    /// var result = cls_Get_Patient_PracticeName_for_PatientID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Patient_PracticeName_for_PatientID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_P_PA_GPPNfPID_1131 Execute(DbConnection Connection,DbTransaction Transaction,P_P_PA_GPPNfPID_1131 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_P_PA_GPPNfPID_1131();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.Patient.Atomic.Retrieval.SQL.cls_Get_Patient_PracticeName_for_PatientID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PatientID", Parameter.PatientID);



			List<P_PA_GPPNfPID_1131> results = new List<P_PA_GPPNfPID_1131>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "name","practice_id" });
				while(reader.Read())
				{
					P_PA_GPPNfPID_1131 resultItem = new P_PA_GPPNfPID_1131();
					//0:Parameter name of type String
					resultItem.name = reader.GetString(0);
					//1:Parameter practice_id of type Guid
					resultItem.practice_id = reader.GetGuid(1);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Patient_PracticeName_for_PatientID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = results.FirstOrDefault();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_P_PA_GPPNfPID_1131 Invoke(string ConnectionString,P_P_PA_GPPNfPID_1131 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_P_PA_GPPNfPID_1131 Invoke(DbConnection Connection,P_P_PA_GPPNfPID_1131 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_P_PA_GPPNfPID_1131 Invoke(DbConnection Connection, DbTransaction Transaction,P_P_PA_GPPNfPID_1131 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_P_PA_GPPNfPID_1131 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_P_PA_GPPNfPID_1131 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_P_PA_GPPNfPID_1131 functionReturn = new FR_P_PA_GPPNfPID_1131();
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

				throw new Exception("Exception occured in method cls_Get_Patient_PracticeName_for_PatientID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_P_PA_GPPNfPID_1131 : FR_Base
	{
		public P_PA_GPPNfPID_1131 Result	{ get; set; }

		public FR_P_PA_GPPNfPID_1131() : base() {}

		public FR_P_PA_GPPNfPID_1131(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_P_PA_GPPNfPID_1131 for attribute P_P_PA_GPPNfPID_1131
		[DataContract]
		public class P_P_PA_GPPNfPID_1131 
		{
			//Standard type parameters
			[DataMember]
			public Guid PatientID { get; set; } 

		}
		#endregion
		#region SClass P_PA_GPPNfPID_1131 for attribute P_PA_GPPNfPID_1131
		[DataContract]
		public class P_PA_GPPNfPID_1131 
		{
			//Standard type parameters
			[DataMember]
			public String name { get; set; } 
			[DataMember]
			public Guid practice_id { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_P_PA_GPPNfPID_1131 cls_Get_Patient_PracticeName_for_PatientID(,P_P_PA_GPPNfPID_1131 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_P_PA_GPPNfPID_1131 invocationResult = cls_Get_Patient_PracticeName_for_PatientID.Invoke(connectionString,P_P_PA_GPPNfPID_1131 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Patient.Atomic.Retrieval.P_P_PA_GPPNfPID_1131();
parameter.PatientID = ...;

*/
