/* 
 * Generated on 2/25/2015 9:12:52 PM
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

namespace CL3_Measurements.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_MeasurementTarrifs_All.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_MeasurementTarrifs_All
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3_MTA_1318_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3_MTA_1318_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_Measurements.Atomic.Retrieval.SQL.cls_MeasurementTarrifs_All.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L3_MTA_1318> results = new List<L3_MTA_1318>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "MRS_RUN_Measurement_TariffID","GlobalPropertyMatchingID","MeasurementTariffName_DictID","Creation_Timestamp","Tenant_RefID" });
				while(reader.Read())
				{
					L3_MTA_1318 resultItem = new L3_MTA_1318();
					//0:Parameter MRS_RUN_Measurement_TariffID of type Guid
					resultItem.MRS_RUN_Measurement_TariffID = reader.GetGuid(0);
					//1:Parameter GlobalPropertyMatchingID of type string
					resultItem.GlobalPropertyMatchingID = reader.GetString(1);
					//2:Parameter MeasurementTariffName of type Dict
					resultItem.MeasurementTariffName = reader.GetDictionary(2);
					resultItem.MeasurementTariffName.SourceTable = "mrs_run_measurement_tariffs";
					loader.Append(resultItem.MeasurementTariffName);
					//3:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(3);
					//4:Parameter Tenant_RefID of type Guid
					resultItem.Tenant_RefID = reader.GetGuid(4);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_MeasurementTarrifs_All",ex);
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
		public static FR_L3_MTA_1318_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3_MTA_1318_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3_MTA_1318_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3_MTA_1318_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3_MTA_1318_Array functionReturn = new FR_L3_MTA_1318_Array();
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

				functionReturn = Execute(Connection, Transaction,securityTicket);

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

				throw new Exception("Exception occured in method cls_MeasurementTarrifs_All",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3_MTA_1318_Array : FR_Base
	{
		public L3_MTA_1318[] Result	{ get; set; } 
		public FR_L3_MTA_1318_Array() : base() {}

		public FR_L3_MTA_1318_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L3_MTA_1318 for attribute L3_MTA_1318
		[DataContract]
		public class L3_MTA_1318 
		{
			//Standard type parameters
			[DataMember]
			public Guid MRS_RUN_Measurement_TariffID { get; set; } 
			[DataMember]
			public string GlobalPropertyMatchingID { get; set; } 
			[DataMember]
			public Dict MeasurementTariffName { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public Guid Tenant_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3_MTA_1318_Array cls_MeasurementTarrifs_All(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3_MTA_1318_Array invocationResult = cls_MeasurementTarrifs_All.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

