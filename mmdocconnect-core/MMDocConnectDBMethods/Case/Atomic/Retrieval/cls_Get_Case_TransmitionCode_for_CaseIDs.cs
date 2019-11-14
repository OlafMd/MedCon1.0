/* 
 * Generated on 12/15/16 13:28:15
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

namespace MMDocConnectDBMethods.Case.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Case_TransmitionCode_for_CaseIDs.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Case_TransmitionCode_for_CaseIDs
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_CAS_GCTCfCIDs_1519_Array Execute(DbConnection Connection,DbTransaction Transaction,P_CAS_GCTCfCIDs_1519 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_CAS_GCTCfCIDs_1519_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.Case.Atomic.Retrieval.SQL.cls_Get_Case_TransmitionCode_for_CaseIDs.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@CaseID"," IN $$CaseID$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$CaseID$",Parameter.CaseID);


			List<CAS_GCTCfCIDs_1519> results = new List<CAS_GCTCfCIDs_1519>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "fs_status","fs_key","status_date","status_id","gpos_type","bill_position_id","case_id" });
				while(reader.Read())
				{
					CAS_GCTCfCIDs_1519 resultItem = new CAS_GCTCfCIDs_1519();
					//0:Parameter fs_status of type int
					resultItem.fs_status = reader.GetInteger(0);
					//1:Parameter fs_key of type String
					resultItem.fs_key = reader.GetString(1);
					//2:Parameter status_date of type DateTime
					resultItem.status_date = reader.GetDate(2);
					//3:Parameter status_id of type Guid
					resultItem.status_id = reader.GetGuid(3);
					//4:Parameter gpos_type of type String
					resultItem.gpos_type = reader.GetString(4);
					//5:Parameter bill_position_id of type Guid
					resultItem.bill_position_id = reader.GetGuid(5);
					//6:Parameter case_id of type Guid
					resultItem.case_id = reader.GetGuid(6);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Case_TransmitionCode_for_CaseIDs",ex);
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
		public static FR_CAS_GCTCfCIDs_1519_Array Invoke(string ConnectionString,P_CAS_GCTCfCIDs_1519 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_CAS_GCTCfCIDs_1519_Array Invoke(DbConnection Connection,P_CAS_GCTCfCIDs_1519 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_CAS_GCTCfCIDs_1519_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_CAS_GCTCfCIDs_1519 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_CAS_GCTCfCIDs_1519_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_CAS_GCTCfCIDs_1519 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_CAS_GCTCfCIDs_1519_Array functionReturn = new FR_CAS_GCTCfCIDs_1519_Array();
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

				throw new Exception("Exception occured in method cls_Get_Case_TransmitionCode_for_CaseIDs",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_CAS_GCTCfCIDs_1519_Array : FR_Base
	{
		public CAS_GCTCfCIDs_1519[] Result	{ get; set; } 
		public FR_CAS_GCTCfCIDs_1519_Array() : base() {}

		public FR_CAS_GCTCfCIDs_1519_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_CAS_GCTCfCIDs_1519 for attribute P_CAS_GCTCfCIDs_1519
		[DataContract]
		public class P_CAS_GCTCfCIDs_1519 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] CaseID { get; set; } 

		}
		#endregion
		#region SClass CAS_GCTCfCIDs_1519 for attribute CAS_GCTCfCIDs_1519
		[DataContract]
		public class CAS_GCTCfCIDs_1519 
		{
			//Standard type parameters
			[DataMember]
			public int fs_status { get; set; } 
			[DataMember]
			public String fs_key { get; set; } 
			[DataMember]
			public DateTime status_date { get; set; } 
			[DataMember]
			public Guid status_id { get; set; } 
			[DataMember]
			public String gpos_type { get; set; } 
			[DataMember]
			public Guid bill_position_id { get; set; } 
			[DataMember]
			public Guid case_id { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_CAS_GCTCfCIDs_1519_Array cls_Get_Case_TransmitionCode_for_CaseIDs(,P_CAS_GCTCfCIDs_1519 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_CAS_GCTCfCIDs_1519_Array invocationResult = cls_Get_Case_TransmitionCode_for_CaseIDs.Invoke(connectionString,P_CAS_GCTCfCIDs_1519 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Case.Atomic.Retrieval.P_CAS_GCTCfCIDs_1519();
parameter.CaseID = ...;

*/
