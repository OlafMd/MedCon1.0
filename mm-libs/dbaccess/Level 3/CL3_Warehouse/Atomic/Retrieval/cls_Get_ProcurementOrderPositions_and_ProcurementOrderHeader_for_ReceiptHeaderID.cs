/* 
 * Generated on 4/28/2014 6:53:28 PM
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

namespace CL3_Warehouse.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ProcurementOrderPositions_and_ProcurementOrderHeader_for_ReceiptHeaderID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ProcurementOrderPositions_and_ProcurementOrderHeader_for_ReceiptHeaderID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3WH_GPOPaPOHfRH_0918_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3WH_GPOPaPOHfRH_0918 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3WH_GPOPaPOHfRH_0918_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_Warehouse.Atomic.Retrieval.SQL.cls_Get_ProcurementOrderPositions_and_ProcurementOrderHeader_for_ReceiptHeaderID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ReceiptHeaderID", Parameter.ReceiptHeaderID);



			List<L3WH_GPOPaPOHfRH_0918> results = new List<L3WH_GPOPaPOHfRH_0918>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "Position_ValueTotal","ProcurementOrder_Currency_RefID","ORD_PRC_ProcurementOrder_HeaderID","ORD_PRC_ProcurementOrder_PositionID","LOG_RCP_Receipt_PositionID" });
				while(reader.Read())
				{
					L3WH_GPOPaPOHfRH_0918 resultItem = new L3WH_GPOPaPOHfRH_0918();
					//0:Parameter Position_ValueTotal of type decimal
					resultItem.Position_ValueTotal = reader.GetDecimal(0);
					//1:Parameter ProcurementOrder_Currency_RefID of type Guid
					resultItem.ProcurementOrder_Currency_RefID = reader.GetGuid(1);
					//2:Parameter ORD_PRC_ProcurementOrder_HeaderID of type Guid
					resultItem.ORD_PRC_ProcurementOrder_HeaderID = reader.GetGuid(2);
					//3:Parameter ORD_PRC_ProcurementOrder_PositionID of type Guid
					resultItem.ORD_PRC_ProcurementOrder_PositionID = reader.GetGuid(3);
					//4:Parameter LOG_RCP_Receipt_PositionID of type Guid
					resultItem.LOG_RCP_Receipt_PositionID = reader.GetGuid(4);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_ProcurementOrderPositions_and_ProcurementOrderHeader_for_ReceiptHeaderID",ex);
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
		public static FR_L3WH_GPOPaPOHfRH_0918_Array Invoke(string ConnectionString,P_L3WH_GPOPaPOHfRH_0918 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3WH_GPOPaPOHfRH_0918_Array Invoke(DbConnection Connection,P_L3WH_GPOPaPOHfRH_0918 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3WH_GPOPaPOHfRH_0918_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3WH_GPOPaPOHfRH_0918 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3WH_GPOPaPOHfRH_0918_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3WH_GPOPaPOHfRH_0918 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3WH_GPOPaPOHfRH_0918_Array functionReturn = new FR_L3WH_GPOPaPOHfRH_0918_Array();
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

				throw new Exception("Exception occured in method cls_Get_ProcurementOrderPositions_and_ProcurementOrderHeader_for_ReceiptHeaderID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3WH_GPOPaPOHfRH_0918_Array : FR_Base
	{
		public L3WH_GPOPaPOHfRH_0918[] Result	{ get; set; } 
		public FR_L3WH_GPOPaPOHfRH_0918_Array() : base() {}

		public FR_L3WH_GPOPaPOHfRH_0918_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3WH_GPOPaPOHfRH_0918 for attribute P_L3WH_GPOPaPOHfRH_0918
		[DataContract]
		public class P_L3WH_GPOPaPOHfRH_0918 
		{
			//Standard type parameters
			[DataMember]
			public Guid ReceiptHeaderID { get; set; } 

		}
		#endregion
		#region SClass L3WH_GPOPaPOHfRH_0918 for attribute L3WH_GPOPaPOHfRH_0918
		[DataContract]
		public class L3WH_GPOPaPOHfRH_0918 
		{
			//Standard type parameters
			[DataMember]
			public decimal Position_ValueTotal { get; set; } 
			[DataMember]
			public Guid ProcurementOrder_Currency_RefID { get; set; } 
			[DataMember]
			public Guid ORD_PRC_ProcurementOrder_HeaderID { get; set; } 
			[DataMember]
			public Guid ORD_PRC_ProcurementOrder_PositionID { get; set; } 
			[DataMember]
			public Guid LOG_RCP_Receipt_PositionID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3WH_GPOPaPOHfRH_0918_Array cls_Get_ProcurementOrderPositions_and_ProcurementOrderHeader_for_ReceiptHeaderID(,P_L3WH_GPOPaPOHfRH_0918 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3WH_GPOPaPOHfRH_0918_Array invocationResult = cls_Get_ProcurementOrderPositions_and_ProcurementOrderHeader_for_ReceiptHeaderID.Invoke(connectionString,P_L3WH_GPOPaPOHfRH_0918 Parameter,securityTicket);
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
var parameter = new CL3_Warehouse.Atomic.Retrieval.P_L3WH_GPOPaPOHfRH_0918();
parameter.ReceiptHeaderID = ...;

*/
