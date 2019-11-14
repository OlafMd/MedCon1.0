/* 
 * Generated on 4/22/2017 12:44:55 PM
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
    /// var result = cls_Get_ElasticRefresh_Aftercares_for_CaseIDs.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ElasticRefresh_Aftercares_for_CaseIDs
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_ER_GERAfCIDs_1023_Array Execute(DbConnection Connection,DbTransaction Transaction,P_ER_GERAfCIDs_1023 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_ER_GERAfCIDs_1023_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.ElasticRefresh.SQL.cls_Get_ElasticRefresh_Aftercares_for_CaseIDs.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@CaseIDs"," IN $$CaseIDs$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$CaseIDs$",Parameter.CaseIDs);
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"AftercarePlannedActionTypeID", Parameter.AftercarePlannedActionTypeID);



			List<ER_GERAfCIDs_1023> results = new List<ER_GERAfCIDs_1023>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "performed_by_bpt_id","cancelled","action_id","case_id","performed" });
				while(reader.Read())
				{
					ER_GERAfCIDs_1023 resultItem = new ER_GERAfCIDs_1023();
					//0:Parameter performed_by_bpt_id of type Guid
					resultItem.performed_by_bpt_id = reader.GetGuid(0);
					//1:Parameter cancelled of type Boolean
					resultItem.cancelled = reader.GetBoolean(1);
					//2:Parameter action_id of type Guid
					resultItem.action_id = reader.GetGuid(2);
					//3:Parameter case_id of type Guid
					resultItem.case_id = reader.GetGuid(3);
					//4:Parameter performed of type Boolean
					resultItem.performed = reader.GetBoolean(4);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_ElasticRefresh_Aftercares_for_CaseIDs",ex);
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
		public static FR_ER_GERAfCIDs_1023_Array Invoke(string ConnectionString,P_ER_GERAfCIDs_1023 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_ER_GERAfCIDs_1023_Array Invoke(DbConnection Connection,P_ER_GERAfCIDs_1023 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_ER_GERAfCIDs_1023_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_ER_GERAfCIDs_1023 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_ER_GERAfCIDs_1023_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_ER_GERAfCIDs_1023 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_ER_GERAfCIDs_1023_Array functionReturn = new FR_ER_GERAfCIDs_1023_Array();
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

				throw new Exception("Exception occured in method cls_Get_ElasticRefresh_Aftercares_for_CaseIDs",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_ER_GERAfCIDs_1023_Array : FR_Base
	{
		public ER_GERAfCIDs_1023[] Result	{ get; set; } 
		public FR_ER_GERAfCIDs_1023_Array() : base() {}

		public FR_ER_GERAfCIDs_1023_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_ER_GERAfCIDs_1023 for attribute P_ER_GERAfCIDs_1023
		[DataContract]
		public class P_ER_GERAfCIDs_1023 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] CaseIDs { get; set; } 
			[DataMember]
			public Guid AftercarePlannedActionTypeID { get; set; } 

		}
		#endregion
		#region SClass ER_GERAfCIDs_1023 for attribute ER_GERAfCIDs_1023
		[DataContract]
		public class ER_GERAfCIDs_1023 
		{
			//Standard type parameters
			[DataMember]
			public Guid performed_by_bpt_id { get; set; } 
			[DataMember]
			public Boolean cancelled { get; set; } 
			[DataMember]
			public Guid action_id { get; set; } 
			[DataMember]
			public Guid case_id { get; set; } 
			[DataMember]
			public Boolean performed { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_ER_GERAfCIDs_1023_Array cls_Get_ElasticRefresh_Aftercares_for_CaseIDs(,P_ER_GERAfCIDs_1023 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_ER_GERAfCIDs_1023_Array invocationResult = cls_Get_ElasticRefresh_Aftercares_for_CaseIDs.Invoke(connectionString,P_ER_GERAfCIDs_1023 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.ElasticRefresh.P_ER_GERAfCIDs_1023();
parameter.CaseIDs = ...;
parameter.AftercarePlannedActionTypeID = ...;

*/
