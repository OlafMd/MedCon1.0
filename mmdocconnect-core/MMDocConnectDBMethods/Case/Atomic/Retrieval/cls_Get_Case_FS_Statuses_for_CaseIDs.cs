/* 
 * Generated on 04/19/17 20:11:16
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
    /// var result = cls_Get_Case_FS_Statuses_for_CaseIDs.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Case_FS_Statuses_for_CaseIDs
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_CAS_GCFSSfCIDs_1349_Array Execute(DbConnection Connection,DbTransaction Transaction,P_CAS_GCFSSfCIDs_1349 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_CAS_GCFSSfCIDs_1349_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.Case.Atomic.Retrieval.SQL.cls_Get_Case_FS_Statuses_for_CaseIDs.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@PatientIDs"," IN $$PatientIDs$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$PatientIDs$",Parameter.PatientIDs);


			List<CAS_GCFSSfCIDs_1349> results = new List<CAS_GCFSSfCIDs_1349>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "fs_status","fs_key","status_date","gpos_type","is_status_active","bill_position_id","is_status_manually_set","primary_comment","secondary_comment","immutable_data","case_id","bill_position_creation_date","patient_id" });
				while(reader.Read())
				{
					CAS_GCFSSfCIDs_1349 resultItem = new CAS_GCFSSfCIDs_1349();
					//0:Parameter fs_status of type int
					resultItem.fs_status = reader.GetInteger(0);
					//1:Parameter fs_key of type String
					resultItem.fs_key = reader.GetString(1);
					//2:Parameter status_date of type DateTime
					resultItem.status_date = reader.GetDate(2);
					//3:Parameter gpos_type of type String
					resultItem.gpos_type = reader.GetString(3);
					//4:Parameter is_status_active of type Boolean
					resultItem.is_status_active = reader.GetBoolean(4);
					//5:Parameter bill_position_id of type Guid
					resultItem.bill_position_id = reader.GetGuid(5);
					//6:Parameter is_status_manually_set of type Boolean
					resultItem.is_status_manually_set = reader.GetBoolean(6);
					//7:Parameter primary_comment of type String
					resultItem.primary_comment = reader.GetString(7);
					//8:Parameter secondary_comment of type String
					resultItem.secondary_comment = reader.GetString(8);
					//9:Parameter immutable_data of type String
					resultItem.immutable_data = reader.GetString(9);
					//10:Parameter case_id of type Guid
					resultItem.case_id = reader.GetGuid(10);
					//11:Parameter bill_position_creation_date of type DateTime
					resultItem.bill_position_creation_date = reader.GetDate(11);
					//12:Parameter patient_id of type Guid
					resultItem.patient_id = reader.GetGuid(12);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Case_FS_Statuses_for_CaseIDs",ex);
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
		public static FR_CAS_GCFSSfCIDs_1349_Array Invoke(string ConnectionString,P_CAS_GCFSSfCIDs_1349 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_CAS_GCFSSfCIDs_1349_Array Invoke(DbConnection Connection,P_CAS_GCFSSfCIDs_1349 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_CAS_GCFSSfCIDs_1349_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_CAS_GCFSSfCIDs_1349 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_CAS_GCFSSfCIDs_1349_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_CAS_GCFSSfCIDs_1349 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_CAS_GCFSSfCIDs_1349_Array functionReturn = new FR_CAS_GCFSSfCIDs_1349_Array();
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

				throw new Exception("Exception occured in method cls_Get_Case_FS_Statuses_for_CaseIDs",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_CAS_GCFSSfCIDs_1349_Array : FR_Base
	{
		public CAS_GCFSSfCIDs_1349[] Result	{ get; set; } 
		public FR_CAS_GCFSSfCIDs_1349_Array() : base() {}

		public FR_CAS_GCFSSfCIDs_1349_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_CAS_GCFSSfCIDs_1349 for attribute P_CAS_GCFSSfCIDs_1349
		[DataContract]
		public class P_CAS_GCFSSfCIDs_1349 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] PatientIDs { get; set; } 

		}
		#endregion
		#region SClass CAS_GCFSSfCIDs_1349 for attribute CAS_GCFSSfCIDs_1349
		[DataContract]
		public class CAS_GCFSSfCIDs_1349 
		{
			//Standard type parameters
			[DataMember]
			public int fs_status { get; set; } 
			[DataMember]
			public String fs_key { get; set; } 
			[DataMember]
			public DateTime status_date { get; set; } 
			[DataMember]
			public String gpos_type { get; set; } 
			[DataMember]
			public Boolean is_status_active { get; set; } 
			[DataMember]
			public Guid bill_position_id { get; set; } 
			[DataMember]
			public Boolean is_status_manually_set { get; set; } 
			[DataMember]
			public String primary_comment { get; set; } 
			[DataMember]
			public String secondary_comment { get; set; } 
			[DataMember]
			public String immutable_data { get; set; } 
			[DataMember]
			public Guid case_id { get; set; } 
			[DataMember]
			public DateTime bill_position_creation_date { get; set; } 
			[DataMember]
			public Guid patient_id { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_CAS_GCFSSfCIDs_1349_Array cls_Get_Case_FS_Statuses_for_CaseIDs(,P_CAS_GCFSSfCIDs_1349 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_CAS_GCFSSfCIDs_1349_Array invocationResult = cls_Get_Case_FS_Statuses_for_CaseIDs.Invoke(connectionString,P_CAS_GCFSSfCIDs_1349 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Case.Atomic.Retrieval.P_CAS_GCFSSfCIDs_1349();
parameter.PatientIDs = ...;

*/
