/* 
 * Generated on 8/28/2014 11:49:51 AM
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
    /// var result = cls_Get_ExpectedDeliveries_for_ProcurementOrderPositions.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ExpectedDeliveries_for_ProcurementOrderPositions
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5PO_GEDfPOP_1132_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5PO_GEDfPOP_1132 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5PO_GEDfPOP_1132_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOProcurement_ProcurementOrder.Atomic.Retrieval.SQL.cls_Get_ExpectedDeliveries_for_ProcurementOrderPositions.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@ProcurementOrderPositions"," IN $$ProcurementOrderPositions$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$ProcurementOrderPositions$",Parameter.ProcurementOrderPositions);


			List<L5PO_GEDfPOP_1132> results = new List<L5PO_GEDfPOP_1132>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "ORD_PRC_ExpectedDelivery_HeaderID","ORD_PRC_ProcurementOrder_Position_RefID","ExpectedDeliveryDate" });
				while(reader.Read())
				{
					L5PO_GEDfPOP_1132 resultItem = new L5PO_GEDfPOP_1132();
					//0:Parameter ORD_PRC_ExpectedDelivery_HeaderID of type Guid
					resultItem.ORD_PRC_ExpectedDelivery_HeaderID = reader.GetGuid(0);
					//1:Parameter ORD_PRC_ProcurementOrder_Position_RefID of type Guid
					resultItem.ORD_PRC_ProcurementOrder_Position_RefID = reader.GetGuid(1);
					//2:Parameter ExpectedDeliveryDate of type DateTime
					resultItem.ExpectedDeliveryDate = reader.GetDate(2);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_ExpectedDeliveries_for_ProcurementOrderPositions",ex);
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
		public static FR_L5PO_GEDfPOP_1132_Array Invoke(string ConnectionString,P_L5PO_GEDfPOP_1132 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5PO_GEDfPOP_1132_Array Invoke(DbConnection Connection,P_L5PO_GEDfPOP_1132 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5PO_GEDfPOP_1132_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5PO_GEDfPOP_1132 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5PO_GEDfPOP_1132_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5PO_GEDfPOP_1132 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5PO_GEDfPOP_1132_Array functionReturn = new FR_L5PO_GEDfPOP_1132_Array();
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

				throw new Exception("Exception occured in method cls_Get_ExpectedDeliveries_for_ProcurementOrderPositions",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5PO_GEDfPOP_1132_Array : FR_Base
	{
		public L5PO_GEDfPOP_1132[] Result	{ get; set; } 
		public FR_L5PO_GEDfPOP_1132_Array() : base() {}

		public FR_L5PO_GEDfPOP_1132_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5PO_GEDfPOP_1132 for attribute P_L5PO_GEDfPOP_1132
		[DataContract]
		public class P_L5PO_GEDfPOP_1132 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] ProcurementOrderPositions { get; set; } 

		}
		#endregion
		#region SClass L5PO_GEDfPOP_1132 for attribute L5PO_GEDfPOP_1132
		[DataContract]
		public class L5PO_GEDfPOP_1132 
		{
			//Standard type parameters
			[DataMember]
			public Guid ORD_PRC_ExpectedDelivery_HeaderID { get; set; } 
			[DataMember]
			public Guid ORD_PRC_ProcurementOrder_Position_RefID { get; set; } 
			[DataMember]
			public DateTime ExpectedDeliveryDate { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5PO_GEDfPOP_1132_Array cls_Get_ExpectedDeliveries_for_ProcurementOrderPositions(,P_L5PO_GEDfPOP_1132 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5PO_GEDfPOP_1132_Array invocationResult = cls_Get_ExpectedDeliveries_for_ProcurementOrderPositions.Invoke(connectionString,P_L5PO_GEDfPOP_1132 Parameter,securityTicket);
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
var parameter = new CL5_APOProcurement_ProcurementOrder.Atomic.Retrieval.P_L5PO_GEDfPOP_1132();
parameter.ProcurementOrderPositions = ...;

*/
