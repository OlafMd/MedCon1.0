/* 
 * Generated on 4/5/2017 1:54:45 PM
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
    /// var result = cls_Get_is_Patient_HIP_on_an_Oct_Contract.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_is_Patient_HIP_on_an_Oct_Contract
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_PA_GiPHipoaOctC_1811_Array Execute(DbConnection Connection,DbTransaction Transaction,P_PA_GiPHipoaOctC_1811 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_PA_GiPHipoaOctC_1811_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.Patient.Atomic.Retrieval.SQL.cls_Get_is_Patient_HIP_on_an_Oct_Contract.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PatientID", Parameter.PatientID);



			List<PA_GiPHipoaOctC_1811> results = new List<PA_GiPHipoaOctC_1811>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "PatientHealthInsuranceID","ContractID" });
				while(reader.Read())
				{
					PA_GiPHipoaOctC_1811 resultItem = new PA_GiPHipoaOctC_1811();
					//0:Parameter PatientHealthInsuranceID of type Guid
					resultItem.PatientHealthInsuranceID = reader.GetGuid(0);
					//1:Parameter ContractID of type Guid
					resultItem.ContractID = reader.GetGuid(1);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_is_Patient_HIP_on_an_Oct_Contract",ex);
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
		public static FR_PA_GiPHipoaOctC_1811_Array Invoke(string ConnectionString,P_PA_GiPHipoaOctC_1811 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_PA_GiPHipoaOctC_1811_Array Invoke(DbConnection Connection,P_PA_GiPHipoaOctC_1811 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_PA_GiPHipoaOctC_1811_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_PA_GiPHipoaOctC_1811 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_PA_GiPHipoaOctC_1811_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_PA_GiPHipoaOctC_1811 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_PA_GiPHipoaOctC_1811_Array functionReturn = new FR_PA_GiPHipoaOctC_1811_Array();
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

				throw new Exception("Exception occured in method cls_Get_is_Patient_HIP_on_an_Oct_Contract",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_PA_GiPHipoaOctC_1811_Array : FR_Base
	{
		public PA_GiPHipoaOctC_1811[] Result	{ get; set; } 
		public FR_PA_GiPHipoaOctC_1811_Array() : base() {}

		public FR_PA_GiPHipoaOctC_1811_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_PA_GiPHipoaOctC_1811 for attribute P_PA_GiPHipoaOctC_1811
		[DataContract]
		public class P_PA_GiPHipoaOctC_1811 
		{
			//Standard type parameters
			[DataMember]
			public Guid PatientID { get; set; } 

		}
		#endregion
		#region SClass PA_GiPHipoaOctC_1811 for attribute PA_GiPHipoaOctC_1811
		[DataContract]
		public class PA_GiPHipoaOctC_1811 
		{
			//Standard type parameters
			[DataMember]
			public Guid PatientHealthInsuranceID { get; set; } 
			[DataMember]
			public Guid ContractID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_PA_GiPHipoaOctC_1811_Array cls_Get_is_Patient_HIP_on_an_Oct_Contract(,P_PA_GiPHipoaOctC_1811 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_PA_GiPHipoaOctC_1811_Array invocationResult = cls_Get_is_Patient_HIP_on_an_Oct_Contract.Invoke(connectionString,P_PA_GiPHipoaOctC_1811 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Patient.Atomic.Retrieval.P_PA_GiPHipoaOctC_1811();
parameter.PatientID = ...;

*/
