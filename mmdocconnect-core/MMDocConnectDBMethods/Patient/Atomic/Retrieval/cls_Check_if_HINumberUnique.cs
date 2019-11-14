/* 
 * Generated on 5/27/2015 9:39:56 AM
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
    /// var result = cls_Check_if_HINumberUnique.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Check_if_HINumberUnique
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_PA_CIHINU_1023_Array Execute(DbConnection Connection,DbTransaction Transaction,P_PA_CIHINU_1023 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_PA_CIHINU_1023_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.Patient.Atomic.Retrieval.SQL.cls_Check_if_HINumberUnique.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"InsuranceNumber", Parameter.InsuranceNumber);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"MedicalPracticeID", Parameter.MedicalPracticeID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PatientID", Parameter.PatientID);



			List<PA_CIHINU_1023> results = new List<PA_CIHINU_1023>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "isHINumberUnique","FirstName","LastName" });
				while(reader.Read())
				{
					PA_CIHINU_1023 resultItem = new PA_CIHINU_1023();
					//0:Parameter isHINumberUnique of type bool
					resultItem.isHINumberUnique = reader.GetBoolean(0);
					//1:Parameter FirstName of type String
					resultItem.FirstName = reader.GetString(1);
					//2:Parameter LastName of type String
					resultItem.LastName = reader.GetString(2);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Check_if_HINumberUnique",ex);
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
		public static FR_PA_CIHINU_1023_Array Invoke(string ConnectionString,P_PA_CIHINU_1023 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_PA_CIHINU_1023_Array Invoke(DbConnection Connection,P_PA_CIHINU_1023 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_PA_CIHINU_1023_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_PA_CIHINU_1023 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_PA_CIHINU_1023_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_PA_CIHINU_1023 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_PA_CIHINU_1023_Array functionReturn = new FR_PA_CIHINU_1023_Array();
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

				throw new Exception("Exception occured in method cls_Check_if_HINumberUnique",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_PA_CIHINU_1023_Array : FR_Base
	{
		public PA_CIHINU_1023[] Result	{ get; set; } 
		public FR_PA_CIHINU_1023_Array() : base() {}

		public FR_PA_CIHINU_1023_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_PA_CIHINU_1023 for attribute P_PA_CIHINU_1023
		[DataContract]
		public class P_PA_CIHINU_1023 
		{
			//Standard type parameters
			[DataMember]
			public String InsuranceNumber { get; set; } 
			[DataMember]
			public Guid MedicalPracticeID { get; set; } 
			[DataMember]
			public Guid PatientID { get; set; } 

		}
		#endregion
		#region SClass PA_CIHINU_1023 for attribute PA_CIHINU_1023
		[DataContract]
		public class PA_CIHINU_1023 
		{
			//Standard type parameters
			[DataMember]
			public bool isHINumberUnique { get; set; } 
			[DataMember]
			public String FirstName { get; set; } 
			[DataMember]
			public String LastName { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_PA_CIHINU_1023_Array cls_Check_if_HINumberUnique(,P_PA_CIHINU_1023 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_PA_CIHINU_1023_Array invocationResult = cls_Check_if_HINumberUnique.Invoke(connectionString,P_PA_CIHINU_1023 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Patient.Atomic.Retrieval.P_PA_CIHINU_1023();
parameter.InsuranceNumber = ...;
parameter.MedicalPracticeID = ...;
parameter.PatientID = ...;

*/
