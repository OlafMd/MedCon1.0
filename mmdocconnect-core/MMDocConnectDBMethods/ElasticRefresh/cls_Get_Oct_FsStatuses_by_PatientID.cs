/* 
 * Generated on 04/20/17 15:31:16
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

namespace MMDocConnectDBMethods.ElasticRefresh
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Oct_FsStatuses_by_PatientID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Oct_FsStatuses_by_PatientID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_ER_GOctFsSbPID_1829_Array Execute(DbConnection Connection,DbTransaction Transaction,P_ER_GOctFsSbPID_1829 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_ER_GOctFsSbPID_1829_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.ElasticRefresh.SQL.cls_Get_Oct_FsStatuses_by_PatientID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PatientID", Parameter.PatientID);



			List<ER_GOctFsSbPID_1829> results = new List<ER_GOctFsSbPID_1829>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "localization","fs_status_code","op_date","case_id" });
				while(reader.Read())
				{
					ER_GOctFsSbPID_1829 resultItem = new ER_GOctFsSbPID_1829();
					//0:Parameter localization of type String
					resultItem.localization = reader.GetString(0);
					//1:Parameter fs_status_code of type int
					resultItem.fs_status_code = reader.GetInteger(1);
					//2:Parameter op_date of type DateTime
					resultItem.op_date = reader.GetDate(2);
					//3:Parameter case_id of type Guid
					resultItem.case_id = reader.GetGuid(3);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Oct_FsStatuses_by_PatientID",ex);
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
		public static FR_ER_GOctFsSbPID_1829_Array Invoke(string ConnectionString,P_ER_GOctFsSbPID_1829 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_ER_GOctFsSbPID_1829_Array Invoke(DbConnection Connection,P_ER_GOctFsSbPID_1829 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_ER_GOctFsSbPID_1829_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_ER_GOctFsSbPID_1829 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_ER_GOctFsSbPID_1829_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_ER_GOctFsSbPID_1829 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_ER_GOctFsSbPID_1829_Array functionReturn = new FR_ER_GOctFsSbPID_1829_Array();
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

				throw new Exception("Exception occured in method cls_Get_Oct_FsStatuses_by_PatientID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_ER_GOctFsSbPID_1829_Array : FR_Base
	{
		public ER_GOctFsSbPID_1829[] Result	{ get; set; } 
		public FR_ER_GOctFsSbPID_1829_Array() : base() {}

		public FR_ER_GOctFsSbPID_1829_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_ER_GOctFsSbPID_1829 for attribute P_ER_GOctFsSbPID_1829
		[DataContract]
		public class P_ER_GOctFsSbPID_1829 
		{
			//Standard type parameters
			[DataMember]
			public Guid PatientID { get; set; } 

		}
		#endregion
		#region SClass ER_GOctFsSbPID_1829 for attribute ER_GOctFsSbPID_1829
		[DataContract]
		public class ER_GOctFsSbPID_1829 
		{
			//Standard type parameters
			[DataMember]
			public String localization { get; set; } 
			[DataMember]
			public int fs_status_code { get; set; } 
			[DataMember]
			public DateTime op_date { get; set; } 
			[DataMember]
			public Guid case_id { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_ER_GOctFsSbPID_1829_Array cls_Get_Oct_FsStatuses_by_PatientID(,P_ER_GOctFsSbPID_1829 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_ER_GOctFsSbPID_1829_Array invocationResult = cls_Get_Oct_FsStatuses_by_PatientID.Invoke(connectionString,P_ER_GOctFsSbPID_1829 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.ElasticRefresh.P_ER_GOctFsSbPID_1829();
parameter.PatientID = ...;

*/
