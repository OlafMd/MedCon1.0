/* 
 * Generated on 9/5/2014 3:41:40 PM
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

namespace CL3_Supplier.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ProductIDs_for_SupplierID_via_StockReceipts.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ProductIDs_for_SupplierID_via_StockReceipts
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3SP_GPfSvSR_1524_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3SP_GPfSvSR_1524 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3SP_GPfSvSR_1524_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_Supplier.Atomic.Retrieval.SQL.cls_Get_ProductIDs_for_SupplierID_via_StockReceipts.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ProvidingSupplier", Parameter.ProvidingSupplier);



			List<L3SP_GPfSvSR_1524> results = new List<L3SP_GPfSvSR_1524>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "ReceiptPosition_Product_RefID","SupplierName","CMN_BPT_SupplierID" });
				while(reader.Read())
				{
					L3SP_GPfSvSR_1524 resultItem = new L3SP_GPfSvSR_1524();
					//0:Parameter ReceiptPosition_Product_RefID of type Guid
					resultItem.ReceiptPosition_Product_RefID = reader.GetGuid(0);
					//1:Parameter SupplierName of type String
					resultItem.SupplierName = reader.GetString(1);
					//2:Parameter CMN_BPT_SupplierID of type Guid
					resultItem.CMN_BPT_SupplierID = reader.GetGuid(2);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_ProductIDs_for_SupplierID_via_StockReceipts",ex);
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
		public static FR_L3SP_GPfSvSR_1524_Array Invoke(string ConnectionString,P_L3SP_GPfSvSR_1524 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3SP_GPfSvSR_1524_Array Invoke(DbConnection Connection,P_L3SP_GPfSvSR_1524 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3SP_GPfSvSR_1524_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3SP_GPfSvSR_1524 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3SP_GPfSvSR_1524_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3SP_GPfSvSR_1524 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3SP_GPfSvSR_1524_Array functionReturn = new FR_L3SP_GPfSvSR_1524_Array();
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

				throw new Exception("Exception occured in method cls_Get_ProductIDs_for_SupplierID_via_StockReceipts",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3SP_GPfSvSR_1524_Array : FR_Base
	{
		public L3SP_GPfSvSR_1524[] Result	{ get; set; } 
		public FR_L3SP_GPfSvSR_1524_Array() : base() {}

		public FR_L3SP_GPfSvSR_1524_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3SP_GPfSvSR_1524 for attribute P_L3SP_GPfSvSR_1524
		[DataContract]
		public class P_L3SP_GPfSvSR_1524 
		{
			//Standard type parameters
			[DataMember]
			public Guid? ProvidingSupplier { get; set; } 

		}
		#endregion
		#region SClass L3SP_GPfSvSR_1524 for attribute L3SP_GPfSvSR_1524
		[DataContract]
		public class L3SP_GPfSvSR_1524 
		{
			//Standard type parameters
			[DataMember]
			public Guid ReceiptPosition_Product_RefID { get; set; } 
			[DataMember]
			public String SupplierName { get; set; } 
			[DataMember]
			public Guid CMN_BPT_SupplierID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3SP_GPfSvSR_1524_Array cls_Get_ProductIDs_for_SupplierID_via_StockReceipts(,P_L3SP_GPfSvSR_1524 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3SP_GPfSvSR_1524_Array invocationResult = cls_Get_ProductIDs_for_SupplierID_via_StockReceipts.Invoke(connectionString,P_L3SP_GPfSvSR_1524 Parameter,securityTicket);
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
var parameter = new CL3_Supplier.Atomic.Retrieval.P_L3SP_GPfSvSR_1524();
parameter.ProvidingSupplier = ...;

*/
