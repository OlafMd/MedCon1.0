/* 
 * Generated on 19.09.2014 12:50:39
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 * Required Assemblies:
 * System.Runtime.Serialization
 * CSV2Core
 * CSV2Core_MySQL
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using System.Runtime.Serialization;

namespace CL2_Correspondences.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_CorrespondenceTypes.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_CorrespondenceTypes
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2CO_GCT_1127_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2CO_GCT_1127_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_Correspondences.Atomic.Retrieval.SQL.cls_Get_CorrespondenceTypes.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L2CO_GCT_1127> results = new List<L2CO_GCT_1127>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_PER_PersonInfo_CorrespondenceTypeID","GlobalPropertyMatchingID","DisplayName" });
				while(reader.Read())
				{
					L2CO_GCT_1127 resultItem = new L2CO_GCT_1127();
					//0:Parameter CMN_PER_PersonInfo_CorrespondenceTypeID of type Guid
					resultItem.CMN_PER_PersonInfo_CorrespondenceTypeID = reader.GetGuid(0);
					//1:Parameter GlobalPropertyMatchingID of type String
					resultItem.GlobalPropertyMatchingID = reader.GetString(1);
					//2:Parameter DisplayName of type String
					resultItem.DisplayName = reader.GetString(2);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_CorrespondenceTypes",ex);
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
		public static FR_L2CO_GCT_1127_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2CO_GCT_1127_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2CO_GCT_1127_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2CO_GCT_1127_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2CO_GCT_1127_Array functionReturn = new FR_L2CO_GCT_1127_Array();
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

				throw new Exception("Exception occured in method cls_Get_CorrespondenceTypes",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2CO_GCT_1127_Array : FR_Base
	{
		public L2CO_GCT_1127[] Result	{ get; set; } 
		public FR_L2CO_GCT_1127_Array() : base() {}

		public FR_L2CO_GCT_1127_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L2CO_GCT_1127 for attribute L2CO_GCT_1127
		[DataContract]
		public class L2CO_GCT_1127 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_PER_PersonInfo_CorrespondenceTypeID { get; set; } 
			[DataMember]
			public String GlobalPropertyMatchingID { get; set; } 
			[DataMember]
			public String DisplayName { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2CO_GCT_1127_Array cls_Get_CorrespondenceTypes(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2CO_GCT_1127_Array invocationResult = cls_Get_CorrespondenceTypes.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

