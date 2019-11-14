/* 
 * Generated on 01/24/17 11:29:15
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
    /// var result = cls_Get_Cases_with_Wrongfully_Transferred_BillPositions.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Cases_with_Wrongfully_Transferred_BillPositions
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_CAS_GCwWTBP_1832_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_CAS_GCwWTBP_1832_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "DataImporter.DBMethods.Case.Atomic.Retrieval.SQL.cls_Get_Cases_with_Wrongfully_Transferred_BillPositions.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<CAS_GCwWTBP_1832> results = new List<CAS_GCwWTBP_1832>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "HEC_CAS_CaseID","BIL_BillPosition_TransmitionStatusID","HEC_CAS_Case_BillCodeID","HEC_BIL_BillPosition_BillCodeID","HEC_BIL_BillPositionID","Ext_BIL_BillPosition_RefID","Creation_Timestamp" });
				while(reader.Read())
				{
					CAS_GCwWTBP_1832 resultItem = new CAS_GCwWTBP_1832();
					//0:Parameter HEC_CAS_CaseID of type Guid
					resultItem.HEC_CAS_CaseID = reader.GetGuid(0);
					//1:Parameter BIL_BillPosition_TransmitionStatusID of type Guid
					resultItem.BIL_BillPosition_TransmitionStatusID = reader.GetGuid(1);
					//2:Parameter HEC_CAS_Case_BillCodeID of type Guid
					resultItem.HEC_CAS_Case_BillCodeID = reader.GetGuid(2);
					//3:Parameter HEC_BIL_BillPosition_BillCodeID of type Guid
					resultItem.HEC_BIL_BillPosition_BillCodeID = reader.GetGuid(3);
					//4:Parameter HEC_BIL_BillPositionID of type Guid
					resultItem.HEC_BIL_BillPositionID = reader.GetGuid(4);
					//5:Parameter Ext_BIL_BillPosition_RefID of type Guid
					resultItem.Ext_BIL_BillPosition_RefID = reader.GetGuid(5);
					//6:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(6);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Cases_with_Wrongfully_Transferred_BillPositions",ex);
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
		public static FR_CAS_GCwWTBP_1832_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_CAS_GCwWTBP_1832_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_CAS_GCwWTBP_1832_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_CAS_GCwWTBP_1832_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_CAS_GCwWTBP_1832_Array functionReturn = new FR_CAS_GCwWTBP_1832_Array();
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

				throw new Exception("Exception occured in method cls_Get_Cases_with_Wrongfully_Transferred_BillPositions",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_CAS_GCwWTBP_1832_Array : FR_Base
	{
		public CAS_GCwWTBP_1832[] Result	{ get; set; } 
		public FR_CAS_GCwWTBP_1832_Array() : base() {}

		public FR_CAS_GCwWTBP_1832_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass CAS_GCwWTBP_1832 for attribute CAS_GCwWTBP_1832
		[DataContract]
		public class CAS_GCwWTBP_1832 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_CAS_CaseID { get; set; } 
			[DataMember]
			public Guid BIL_BillPosition_TransmitionStatusID { get; set; } 
			[DataMember]
			public Guid HEC_CAS_Case_BillCodeID { get; set; } 
			[DataMember]
			public Guid HEC_BIL_BillPosition_BillCodeID { get; set; } 
			[DataMember]
			public Guid HEC_BIL_BillPositionID { get; set; } 
			[DataMember]
			public Guid Ext_BIL_BillPosition_RefID { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_CAS_GCwWTBP_1832_Array cls_Get_Cases_with_Wrongfully_Transferred_BillPositions(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_CAS_GCwWTBP_1832_Array invocationResult = cls_Get_Cases_with_Wrongfully_Transferred_BillPositions.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

