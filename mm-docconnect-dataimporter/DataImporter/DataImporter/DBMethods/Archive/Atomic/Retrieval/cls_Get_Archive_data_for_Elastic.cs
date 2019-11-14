/* 
 * Generated on 1/20/2017 2:33:08 PM
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

namespace DataImporter.DBMethods.Archive.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Archive_data_for_Elastic.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Archive_data_for_Elastic
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_AR_GAADFE_1548_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_AR_GAADFE_1548_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "DataImporter.DBMethods.Archive.Atomic.Retrieval.SQL.cls_Get_Archive_data_for_Elastic.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<AR_GAADFE_1548> results = new List<AR_GAADFE_1548>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "id","document_id","gpmid","file_date","description","file_type","recipient" });
				while(reader.Read())
				{
					AR_GAADFE_1548 resultItem = new AR_GAADFE_1548();
					//0:Parameter id of type Guid
					resultItem.id = reader.GetGuid(0);
					//1:Parameter document_id of type String
					resultItem.document_id = reader.GetString(1);
					//2:Parameter gpmid of type String
					resultItem.gpmid = reader.GetString(2);
					//3:Parameter file_date of type DateTime
					resultItem.file_date = reader.GetDate(3);
					//4:Parameter description of type String
					resultItem.description = reader.GetString(4);
					//5:Parameter file_type of type String
					resultItem.file_type = reader.GetString(5);
					//6:Parameter recipient of type String
					resultItem.recipient = reader.GetString(6);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Archive_data_for_Elastic",ex);
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
		public static FR_AR_GAADFE_1548_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_AR_GAADFE_1548_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_AR_GAADFE_1548_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_AR_GAADFE_1548_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_AR_GAADFE_1548_Array functionReturn = new FR_AR_GAADFE_1548_Array();
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

				throw new Exception("Exception occured in method cls_Get_Archive_data_for_Elastic",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_AR_GAADFE_1548_Array : FR_Base
	{
		public AR_GAADFE_1548[] Result	{ get; set; } 
		public FR_AR_GAADFE_1548_Array() : base() {}

		public FR_AR_GAADFE_1548_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass AR_GAADFE_1548 for attribute AR_GAADFE_1548
		[DataContract]
		public class AR_GAADFE_1548 
		{
			//Standard type parameters
			[DataMember]
			public Guid id { get; set; } 
			[DataMember]
			public String document_id { get; set; } 
			[DataMember]
			public String gpmid { get; set; } 
			[DataMember]
			public DateTime file_date { get; set; } 
			[DataMember]
			public String description { get; set; } 
			[DataMember]
			public String file_type { get; set; } 
			[DataMember]
			public String recipient { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_AR_GAADFE_1548_Array cls_Get_Archive_data_for_Elastic(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_AR_GAADFE_1548_Array invocationResult = cls_Get_Archive_data_for_Elastic.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

