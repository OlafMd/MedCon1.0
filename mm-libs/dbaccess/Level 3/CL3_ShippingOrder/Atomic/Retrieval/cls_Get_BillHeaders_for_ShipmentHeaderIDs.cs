/* 
 * Generated on 5/21/2014 1:55:34 PM
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

namespace CL3_ShippingOrder.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_BillHeaders_for_ShipmentHeaderIDs.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_BillHeaders_for_ShipmentHeaderIDs
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_CL3_GBHNfSH_1131_Array Execute(DbConnection Connection,DbTransaction Transaction,P_CL3_GBHNfSH_1131 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_CL3_GBHNfSH_1131_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_ShippingOrder.Atomic.Retrieval.SQL.cls_Get_BillHeaders_for_ShipmentHeaderIDs.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@ShipmentHeaderIDs"," IN $$ShipmentHeaderIDs$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$ShipmentHeaderIDs$",Parameter.ShipmentHeaderIDs);


			List<CL3_GBHNfSH_1131> results = new List<CL3_GBHNfSH_1131>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "LOG_SHP_Shipment_HeaderID","BIL_BillHeaderID","BillNumber" });
				while(reader.Read())
				{
					CL3_GBHNfSH_1131 resultItem = new CL3_GBHNfSH_1131();
					//0:Parameter LOG_SHP_Shipment_HeaderID of type Guid
					resultItem.LOG_SHP_Shipment_HeaderID = reader.GetGuid(0);
					//1:Parameter BIL_BillHeaderID of type Guid
					resultItem.BIL_BillHeaderID = reader.GetGuid(1);
					//2:Parameter BillNumber of type String
					resultItem.BillNumber = reader.GetString(2);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_BillHeaders_for_ShipmentHeaderIDs",ex);
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
		public static FR_CL3_GBHNfSH_1131_Array Invoke(string ConnectionString,P_CL3_GBHNfSH_1131 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_CL3_GBHNfSH_1131_Array Invoke(DbConnection Connection,P_CL3_GBHNfSH_1131 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_CL3_GBHNfSH_1131_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_CL3_GBHNfSH_1131 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_CL3_GBHNfSH_1131_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_CL3_GBHNfSH_1131 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_CL3_GBHNfSH_1131_Array functionReturn = new FR_CL3_GBHNfSH_1131_Array();
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

				throw new Exception("Exception occured in method cls_Get_BillHeaders_for_ShipmentHeaderIDs",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_CL3_GBHNfSH_1131_Array : FR_Base
	{
		public CL3_GBHNfSH_1131[] Result	{ get; set; } 
		public FR_CL3_GBHNfSH_1131_Array() : base() {}

		public FR_CL3_GBHNfSH_1131_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_CL3_GBHNfSH_1131 for attribute P_CL3_GBHNfSH_1131
		[DataContract]
		public class P_CL3_GBHNfSH_1131 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] ShipmentHeaderIDs { get; set; } 

		}
		#endregion
		#region SClass CL3_GBHNfSH_1131 for attribute CL3_GBHNfSH_1131
		[DataContract]
		public class CL3_GBHNfSH_1131 
		{
			//Standard type parameters
			[DataMember]
			public Guid LOG_SHP_Shipment_HeaderID { get; set; } 
			[DataMember]
			public Guid BIL_BillHeaderID { get; set; } 
			[DataMember]
			public String BillNumber { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_CL3_GBHNfSH_1131_Array cls_Get_BillHeaders_for_ShipmentHeaderIDs(,P_CL3_GBHNfSH_1131 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_CL3_GBHNfSH_1131_Array invocationResult = cls_Get_BillHeaders_for_ShipmentHeaderIDs.Invoke(connectionString,P_CL3_GBHNfSH_1131 Parameter,securityTicket);
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
var parameter = new CL3_ShippingOrder.Atomic.Retrieval.P_CL3_GBHNfSH_1131();
parameter.ShipmentHeaderIDs = ...;

*/
