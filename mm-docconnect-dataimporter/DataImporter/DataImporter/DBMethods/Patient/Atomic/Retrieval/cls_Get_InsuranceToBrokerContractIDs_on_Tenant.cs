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
    /// var result = cls_Get_InsuranceToBrokerContractIDs_on_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_InsuranceToBrokerContractIDs_on_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_PA_GITBCIDsoT_1238_Array Execute(DbConnection Connection,DbTransaction Transaction,P_PA_GITBCIDsoT_1238 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_PA_GITBCIDsoT_1238_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "DataImporter.DBMethods.Patient.Atomic.Retrieval.SQL.cls_Get_InsuranceToBrokerContractIDs_on_Tenant.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@PatientIDs"," IN $$PatientIDs$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$PatientIDs$",Parameter.PatientIDs);


			List<PA_GITBCIDsoT_1238> results = new List<PA_GITBCIDsoT_1238>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "InsuranceToBrokerContractID","PatientID" });
				while(reader.Read())
				{
					PA_GITBCIDsoT_1238 resultItem = new PA_GITBCIDsoT_1238();
					//0:Parameter InsuranceToBrokerContractID of type Guid
					resultItem.InsuranceToBrokerContractID = reader.GetGuid(0);
					//1:Parameter PatientID of type Guid
					resultItem.PatientID = reader.GetGuid(1);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_InsuranceToBrokerContractIDs_on_Tenant",ex);
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
		public static FR_PA_GITBCIDsoT_1238_Array Invoke(string ConnectionString,P_PA_GITBCIDsoT_1238 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_PA_GITBCIDsoT_1238_Array Invoke(DbConnection Connection,P_PA_GITBCIDsoT_1238 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_PA_GITBCIDsoT_1238_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_PA_GITBCIDsoT_1238 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_PA_GITBCIDsoT_1238_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_PA_GITBCIDsoT_1238 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_PA_GITBCIDsoT_1238_Array functionReturn = new FR_PA_GITBCIDsoT_1238_Array();
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

				throw new Exception("Exception occured in method cls_Get_InsuranceToBrokerContractIDs_on_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_PA_GITBCIDsoT_1238_Array : FR_Base
	{
		public PA_GITBCIDsoT_1238[] Result	{ get; set; } 
		public FR_PA_GITBCIDsoT_1238_Array() : base() {}

		public FR_PA_GITBCIDsoT_1238_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_PA_GITBCIDsoT_1238 for attribute P_PA_GITBCIDsoT_1238
		[DataContract]
		public class P_PA_GITBCIDsoT_1238 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] PatientIDs { get; set; } 

		}
		#endregion
		#region SClass PA_GITBCIDsoT_1238 for attribute PA_GITBCIDsoT_1238
		[DataContract]
		public class PA_GITBCIDsoT_1238 
		{
			//Standard type parameters
			[DataMember]
			public Guid InsuranceToBrokerContractID { get; set; } 
			[DataMember]
			public Guid PatientID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_PA_GITBCIDsoT_1238_Array cls_Get_InsuranceToBrokerContractIDs_on_Tenant(,P_PA_GITBCIDsoT_1238 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_PA_GITBCIDsoT_1238_Array invocationResult = cls_Get_InsuranceToBrokerContractIDs_on_Tenant.Invoke(connectionString,P_PA_GITBCIDsoT_1238 Parameter,securityTicket);
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
var parameter = new DataImporter.DBMethods.Patient.Atomic.Retrieval.P_PA_GITBCIDsoT_1238();
parameter.PatientIDs = ...;

*/
