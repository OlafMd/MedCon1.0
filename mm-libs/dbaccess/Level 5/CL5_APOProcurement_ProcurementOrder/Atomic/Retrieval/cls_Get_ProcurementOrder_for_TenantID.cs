/* 
 * Generated on 10/23/2014 4:19:15 PM
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

namespace CL5_APOProcurement_ProcurementOrder.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ProcurementOrder_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ProcurementOrder_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5PO_GPOfT_1224_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5PO_GPOfT_1224_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOProcurement_ProcurementOrder.Atomic.Retrieval.SQL.cls_Get_ProcurementOrder_for_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L5PO_GPOfT_1224> results = new List<L5PO_GPOfT_1224>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "ProcurementOrder_Number","PositionsCount","Position_ValueTotal","DisplayName","Creation_Timestamp","ORD_PRC_ProcurementOrder_HeaderID","GlobalPropertyMatchingID","notesNumber","CMN_BPT_SupplierID","ISO4127","Symbol" });
				while(reader.Read())
				{
					L5PO_GPOfT_1224 resultItem = new L5PO_GPOfT_1224();
					//0:Parameter ProcurementOrder_Number of type String
					resultItem.ProcurementOrder_Number = reader.GetString(0);
					//1:Parameter PositionsCount of type int
					resultItem.PositionsCount = reader.GetInteger(1);
					//2:Parameter Position_ValueTotal of type Decimal
					resultItem.Position_ValueTotal = reader.GetDecimal(2);
					//3:Parameter DisplayName of type String
					resultItem.DisplayName = reader.GetString(3);
					//4:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(4);
					//5:Parameter ORD_PRC_ProcurementOrder_HeaderID of type Guid
					resultItem.ORD_PRC_ProcurementOrder_HeaderID = reader.GetGuid(5);
					//6:Parameter GlobalPropertyMatchingID of type String
					resultItem.GlobalPropertyMatchingID = reader.GetString(6);
					//7:Parameter notesNumber of type int
					resultItem.notesNumber = reader.GetInteger(7);
					//8:Parameter CMN_BPT_SupplierID of type Guid
					resultItem.CMN_BPT_SupplierID = reader.GetGuid(8);
					//9:Parameter ISO4127 of type String
					resultItem.ISO4127 = reader.GetString(9);
					//10:Parameter Symbol of type String
					resultItem.Symbol = reader.GetString(10);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_ProcurementOrder_for_TenantID",ex);
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
		public static FR_L5PO_GPOfT_1224_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5PO_GPOfT_1224_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5PO_GPOfT_1224_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5PO_GPOfT_1224_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5PO_GPOfT_1224_Array functionReturn = new FR_L5PO_GPOfT_1224_Array();
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

				throw new Exception("Exception occured in method cls_Get_ProcurementOrder_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5PO_GPOfT_1224_Array : FR_Base
	{
		public L5PO_GPOfT_1224[] Result	{ get; set; } 
		public FR_L5PO_GPOfT_1224_Array() : base() {}

		public FR_L5PO_GPOfT_1224_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5PO_GPOfT_1224 for attribute L5PO_GPOfT_1224
		[DataContract]
		public class L5PO_GPOfT_1224 
		{
			//Standard type parameters
			[DataMember]
			public String ProcurementOrder_Number { get; set; } 
			[DataMember]
			public int PositionsCount { get; set; } 
			[DataMember]
			public Decimal Position_ValueTotal { get; set; } 
			[DataMember]
			public String DisplayName { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public Guid ORD_PRC_ProcurementOrder_HeaderID { get; set; } 
			[DataMember]
			public String GlobalPropertyMatchingID { get; set; } 
			[DataMember]
			public int notesNumber { get; set; } 
			[DataMember]
			public Guid CMN_BPT_SupplierID { get; set; } 
			[DataMember]
			public String ISO4127 { get; set; } 
			[DataMember]
			public String Symbol { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5PO_GPOfT_1224_Array cls_Get_ProcurementOrder_for_TenantID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5PO_GPOfT_1224_Array invocationResult = cls_Get_ProcurementOrder_for_TenantID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

