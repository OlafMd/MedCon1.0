/* 
 * Generated on 3/3/2017 3:49:25 PM
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

namespace MMDocConnectDBMethods.Order.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Order_Status_History_for_OrderIDs.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Order_Status_History_for_OrderIDs
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_OR_GOSHfOIDs_1528_Array Execute(DbConnection Connection,DbTransaction Transaction,P_OR_GOSHfOIDs_1528 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_OR_GOSHfOIDs_1528_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.Order.Atomic.Retrieval.SQL.cls_Get_Order_Status_History_for_OrderIDs.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@OrderIDs"," IN $$OrderIDs$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$OrderIDs$",Parameter.OrderIDs);


			List<OR_GOSHfOIDs_1528> results = new List<OR_GOSHfOIDs_1528>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "StatusCode","StatusGPMID","StatusChangedOn","OrderID" });
				while(reader.Read())
				{
					OR_GOSHfOIDs_1528 resultItem = new OR_GOSHfOIDs_1528();
					//0:Parameter StatusCode of type int
					resultItem.StatusCode = reader.GetInteger(0);
					//1:Parameter StatusGPMID of type String
					resultItem.StatusGPMID = reader.GetString(1);
					//2:Parameter StatusChangedOn of type DateTime
					resultItem.StatusChangedOn = reader.GetDate(2);
					//3:Parameter OrderID of type Guid
					resultItem.OrderID = reader.GetGuid(3);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Order_Status_History_for_OrderIDs",ex);
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
		public static FR_OR_GOSHfOIDs_1528_Array Invoke(string ConnectionString,P_OR_GOSHfOIDs_1528 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_OR_GOSHfOIDs_1528_Array Invoke(DbConnection Connection,P_OR_GOSHfOIDs_1528 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_OR_GOSHfOIDs_1528_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_OR_GOSHfOIDs_1528 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_OR_GOSHfOIDs_1528_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_OR_GOSHfOIDs_1528 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_OR_GOSHfOIDs_1528_Array functionReturn = new FR_OR_GOSHfOIDs_1528_Array();
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

				throw new Exception("Exception occured in method cls_Get_Order_Status_History_for_OrderIDs",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_OR_GOSHfOIDs_1528_Array : FR_Base
	{
		public OR_GOSHfOIDs_1528[] Result	{ get; set; } 
		public FR_OR_GOSHfOIDs_1528_Array() : base() {}

		public FR_OR_GOSHfOIDs_1528_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_OR_GOSHfOIDs_1528 for attribute P_OR_GOSHfOIDs_1528
		[DataContract]
		public class P_OR_GOSHfOIDs_1528 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] OrderIDs { get; set; } 

		}
		#endregion
		#region SClass OR_GOSHfOIDs_1528 for attribute OR_GOSHfOIDs_1528
		[DataContract]
		public class OR_GOSHfOIDs_1528 
		{
			//Standard type parameters
			[DataMember]
			public int StatusCode { get; set; } 
			[DataMember]
			public String StatusGPMID { get; set; } 
			[DataMember]
			public DateTime StatusChangedOn { get; set; } 
			[DataMember]
			public Guid OrderID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_OR_GOSHfOIDs_1528_Array cls_Get_Order_Status_History_for_OrderIDs(,P_OR_GOSHfOIDs_1528 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_OR_GOSHfOIDs_1528_Array invocationResult = cls_Get_Order_Status_History_for_OrderIDs.Invoke(connectionString,P_OR_GOSHfOIDs_1528 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Order.Atomic.Retrieval.P_OR_GOSHfOIDs_1528();
parameter.OrderIDs = ...;

*/
