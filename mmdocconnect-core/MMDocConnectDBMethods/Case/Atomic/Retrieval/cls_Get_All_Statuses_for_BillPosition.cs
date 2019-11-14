/* 
 * Generated on 07/24/15 13:18:15
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
    /// var result = cls_Get_All_Statuses_for_BillPosition.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_All_Statuses_for_BillPosition
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_CAS_GASfBP_1030_Array Execute(DbConnection Connection,DbTransaction Transaction,P_CAS_GASfBP_1030 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_CAS_GASfBP_1030_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.Case.Atomic.Retrieval.SQL.cls_Get_All_Statuses_for_BillPosition.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"BillPosition", Parameter.BillPosition);



			List<CAS_GASfBP_1030> results = new List<CAS_GASfBP_1030>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "StatusID","StatusCode","IsActive","Creation_Timestamp" });
				while(reader.Read())
				{
					CAS_GASfBP_1030 resultItem = new CAS_GASfBP_1030();
					//0:Parameter StatusID of type Guid
					resultItem.StatusID = reader.GetGuid(0);
					//1:Parameter StatusCode of type int
					resultItem.StatusCode = reader.GetInteger(1);
					//2:Parameter IsActive of type bool
					resultItem.IsActive = reader.GetBoolean(2);
					//3:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(3);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_All_Statuses_for_BillPosition",ex);
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
		public static FR_CAS_GASfBP_1030_Array Invoke(string ConnectionString,P_CAS_GASfBP_1030 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_CAS_GASfBP_1030_Array Invoke(DbConnection Connection,P_CAS_GASfBP_1030 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_CAS_GASfBP_1030_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_CAS_GASfBP_1030 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_CAS_GASfBP_1030_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_CAS_GASfBP_1030 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_CAS_GASfBP_1030_Array functionReturn = new FR_CAS_GASfBP_1030_Array();
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

				throw new Exception("Exception occured in method cls_Get_All_Statuses_for_BillPosition",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_CAS_GASfBP_1030_Array : FR_Base
	{
		public CAS_GASfBP_1030[] Result	{ get; set; } 
		public FR_CAS_GASfBP_1030_Array() : base() {}

		public FR_CAS_GASfBP_1030_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_CAS_GASfBP_1030 for attribute P_CAS_GASfBP_1030
		[DataContract]
		public class P_CAS_GASfBP_1030 
		{
			//Standard type parameters
			[DataMember]
			public Guid BillPosition { get; set; } 

		}
		#endregion
		#region SClass CAS_GASfBP_1030 for attribute CAS_GASfBP_1030
		[DataContract]
		public class CAS_GASfBP_1030 
		{
			//Standard type parameters
			[DataMember]
			public Guid StatusID { get; set; } 
			[DataMember]
			public int StatusCode { get; set; } 
			[DataMember]
			public bool IsActive { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_CAS_GASfBP_1030_Array cls_Get_All_Statuses_for_BillPosition(,P_CAS_GASfBP_1030 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_CAS_GASfBP_1030_Array invocationResult = cls_Get_All_Statuses_for_BillPosition.Invoke(connectionString,P_CAS_GASfBP_1030 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Case.Atomic.Retrieval.P_CAS_GASfBP_1030();
parameter.BillPosition = ...;

*/
