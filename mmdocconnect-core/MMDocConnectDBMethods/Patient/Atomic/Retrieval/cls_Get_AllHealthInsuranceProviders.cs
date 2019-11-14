/* 
 * Generated on 10/24/15 11:51:43
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
    /// var result = cls_Get_AllHealthInsuranceProviders.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_AllHealthInsuranceProviders
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_PA_GAHIP_1223_Array Execute(DbConnection Connection,DbTransaction Transaction,P_PA_GAHIP_1223 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_PA_GAHIP_1223_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.Patient.Atomic.Retrieval.SQL.cls_Get_AllHealthInsuranceProviders.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@ContractIDs"," IN $$ContractIDs$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$ContractIDs$",Parameter.ContractIDs);


			List<PA_GAHIP_1223> results = new List<PA_GAHIP_1223>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "id","name" });
				while(reader.Read())
				{
					PA_GAHIP_1223 resultItem = new PA_GAHIP_1223();
					//0:Parameter id of type Guid
					resultItem.id = reader.GetGuid(0);
					//1:Parameter name of type String
					resultItem.name = reader.GetString(1);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_AllHealthInsuranceProviders",ex);
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
		public static FR_PA_GAHIP_1223_Array Invoke(string ConnectionString,P_PA_GAHIP_1223 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_PA_GAHIP_1223_Array Invoke(DbConnection Connection,P_PA_GAHIP_1223 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_PA_GAHIP_1223_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_PA_GAHIP_1223 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_PA_GAHIP_1223_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_PA_GAHIP_1223 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_PA_GAHIP_1223_Array functionReturn = new FR_PA_GAHIP_1223_Array();
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

				throw new Exception("Exception occured in method cls_Get_AllHealthInsuranceProviders",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_PA_GAHIP_1223_Array : FR_Base
	{
		public PA_GAHIP_1223[] Result	{ get; set; } 
		public FR_PA_GAHIP_1223_Array() : base() {}

		public FR_PA_GAHIP_1223_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_PA_GAHIP_1223 for attribute P_PA_GAHIP_1223
		[DataContract]
		public class P_PA_GAHIP_1223 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] ContractIDs { get; set; } 

		}
		#endregion
		#region SClass PA_GAHIP_1223 for attribute PA_GAHIP_1223
		[DataContract]
		public class PA_GAHIP_1223 
		{
			//Standard type parameters
			[DataMember]
			public Guid id { get; set; } 
			[DataMember]
			public String name { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_PA_GAHIP_1223_Array cls_Get_AllHealthInsuranceProviders(,P_PA_GAHIP_1223 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_PA_GAHIP_1223_Array invocationResult = cls_Get_AllHealthInsuranceProviders.Invoke(connectionString,P_PA_GAHIP_1223 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Patient.Atomic.Retrieval.P_PA_GAHIP_1223();
parameter.ContractIDs = ...;

*/
