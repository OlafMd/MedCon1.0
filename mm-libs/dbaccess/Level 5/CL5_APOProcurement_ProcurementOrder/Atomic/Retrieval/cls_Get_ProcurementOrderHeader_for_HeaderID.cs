/* 
 * Generated on 4/8/2014 03:48:36
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
    /// var result = cls_Get_ProcurementOrderHeader_for_HeaderID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ProcurementOrderHeader_for_HeaderID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5PO_GPOHfH_1406_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5PO_GPOHfH_1406 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5PO_GPOHfH_1406_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOProcurement_ProcurementOrder.Atomic.Retrieval.SQL.cls_Get_ProcurementOrderHeader_for_HeaderID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ProcurementOrderHeaderID", Parameter.ProcurementOrderHeaderID);



			List<L5PO_GPOHfH_1406> results = new List<L5PO_GPOHfH_1406>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "ORD_PRC_ProcurementOrder_HeaderID","ProcurementOrder_Number","CMN_BPT_SupplierID","SupplierName","SupplierType" });
				while(reader.Read())
				{
					L5PO_GPOHfH_1406 resultItem = new L5PO_GPOHfH_1406();
					//0:Parameter ORD_PRC_ProcurementOrder_HeaderID of type Guid
					resultItem.ORD_PRC_ProcurementOrder_HeaderID = reader.GetGuid(0);
					//1:Parameter ProcurementOrder_Number of type String
					resultItem.ProcurementOrder_Number = reader.GetString(1);
					//2:Parameter CMN_BPT_SupplierID of type Guid
					resultItem.CMN_BPT_SupplierID = reader.GetGuid(2);
					//3:Parameter SupplierName of type String
					resultItem.SupplierName = reader.GetString(3);
					//4:Parameter SupplierType of type String
					resultItem.SupplierType = reader.GetString(4);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_ProcurementOrderHeader_for_HeaderID",ex);
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
		public static FR_L5PO_GPOHfH_1406_Array Invoke(string ConnectionString,P_L5PO_GPOHfH_1406 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5PO_GPOHfH_1406_Array Invoke(DbConnection Connection,P_L5PO_GPOHfH_1406 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5PO_GPOHfH_1406_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5PO_GPOHfH_1406 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5PO_GPOHfH_1406_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5PO_GPOHfH_1406 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5PO_GPOHfH_1406_Array functionReturn = new FR_L5PO_GPOHfH_1406_Array();
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

				throw new Exception("Exception occured in method cls_Get_ProcurementOrderHeader_for_HeaderID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5PO_GPOHfH_1406_Array : FR_Base
	{
		public L5PO_GPOHfH_1406[] Result	{ get; set; } 
		public FR_L5PO_GPOHfH_1406_Array() : base() {}

		public FR_L5PO_GPOHfH_1406_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5PO_GPOHfH_1406 for attribute P_L5PO_GPOHfH_1406
		[DataContract]
		public class P_L5PO_GPOHfH_1406 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProcurementOrderHeaderID { get; set; } 

		}
		#endregion
		#region SClass L5PO_GPOHfH_1406 for attribute L5PO_GPOHfH_1406
		[DataContract]
		public class L5PO_GPOHfH_1406 
		{
			//Standard type parameters
			[DataMember]
			public Guid ORD_PRC_ProcurementOrder_HeaderID { get; set; } 
			[DataMember]
			public String ProcurementOrder_Number { get; set; } 
			[DataMember]
			public Guid CMN_BPT_SupplierID { get; set; } 
			[DataMember]
			public String SupplierName { get; set; } 
			[DataMember]
			public String SupplierType { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5PO_GPOHfH_1406_Array cls_Get_ProcurementOrderHeader_for_HeaderID(,P_L5PO_GPOHfH_1406 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5PO_GPOHfH_1406_Array invocationResult = cls_Get_ProcurementOrderHeader_for_HeaderID.Invoke(connectionString,P_L5PO_GPOHfH_1406 Parameter,securityTicket);
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
var parameter = new CL5_APOProcurement_ProcurementOrder.Atomic.Retrieval.P_L5PO_GPOHfH_1406();
parameter.ProcurementOrderHeaderID = ...;

*/
