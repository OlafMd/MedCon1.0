/* 
 * Generated on 01/31/17 11:12:54
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

namespace DataImporter.DBMethods.Case.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_DocumentationCases_Without_BillPositions.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_DocumentationCases_Without_BillPositions
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_CAS_GDCWBP_1757_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_CAS_GDCWBP_1757_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "DataImporter.DBMethods.Case.Atomic.Retrieval.SQL.cls_Get_DocumentationCases_Without_BillPositions.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<CAS_GDCWBP_1757> results = new List<CAS_GDCWBP_1757>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "HEC_CAS_CaseID","CaseNumber" });
				while(reader.Read())
				{
					CAS_GDCWBP_1757 resultItem = new CAS_GDCWBP_1757();
					//0:Parameter HEC_CAS_CaseID of type Guid
					resultItem.HEC_CAS_CaseID = reader.GetGuid(0);
					//1:Parameter CaseNumber of type String
					resultItem.CaseNumber = reader.GetString(1);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_DocumentationCases_Without_BillPositions",ex);
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
		public static FR_CAS_GDCWBP_1757_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_CAS_GDCWBP_1757_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_CAS_GDCWBP_1757_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_CAS_GDCWBP_1757_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_CAS_GDCWBP_1757_Array functionReturn = new FR_CAS_GDCWBP_1757_Array();
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

				throw new Exception("Exception occured in method cls_Get_DocumentationCases_Without_BillPositions",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_CAS_GDCWBP_1757_Array : FR_Base
	{
		public CAS_GDCWBP_1757[] Result	{ get; set; } 
		public FR_CAS_GDCWBP_1757_Array() : base() {}

		public FR_CAS_GDCWBP_1757_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass CAS_GDCWBP_1757 for attribute CAS_GDCWBP_1757
		[DataContract]
		public class CAS_GDCWBP_1757 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_CAS_CaseID { get; set; } 
			[DataMember]
			public String CaseNumber { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_CAS_GDCWBP_1757_Array cls_Get_DocumentationCases_Without_BillPositions(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_CAS_GDCWBP_1757_Array invocationResult = cls_Get_DocumentationCases_Without_BillPositions.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

