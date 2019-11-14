/* 
 * Generated on 7/7/2014 03:41:46
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
    /// var result = cls_Get_Default_SupplierName_for_Warehouse.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Default_SupplierName_for_Warehouse
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3WH_GDSNfW_1618_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3WH_GDSNfW_1618 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3WH_GDSNfW_1618_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_Warehouse.Atomic.Retrieval.SQL.cls_Get_Default_SupplierName_for_Warehouse.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"WarehouseID", Parameter.WarehouseID);



			List<L3WH_GDSNfW_1618> results = new List<L3WH_GDSNfW_1618>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "WarehouseSupplierName","CMN_BPT_Supplier_RefID" });
				while(reader.Read())
				{
					L3WH_GDSNfW_1618 resultItem = new L3WH_GDSNfW_1618();
					//0:Parameter WarehouseSupplierName of type String
					resultItem.WarehouseSupplierName = reader.GetString(0);
					//1:Parameter CMN_BPT_Supplier_RefID of type Guid
					resultItem.CMN_BPT_Supplier_RefID = reader.GetGuid(1);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Default_SupplierName_for_Warehouse",ex);
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
		public static FR_L3WH_GDSNfW_1618_Array Invoke(string ConnectionString,P_L3WH_GDSNfW_1618 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3WH_GDSNfW_1618_Array Invoke(DbConnection Connection,P_L3WH_GDSNfW_1618 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3WH_GDSNfW_1618_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3WH_GDSNfW_1618 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3WH_GDSNfW_1618_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3WH_GDSNfW_1618 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3WH_GDSNfW_1618_Array functionReturn = new FR_L3WH_GDSNfW_1618_Array();
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

				throw new Exception("Exception occured in method cls_Get_Default_SupplierName_for_Warehouse",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3WH_GDSNfW_1618_Array : FR_Base
	{
		public L3WH_GDSNfW_1618[] Result	{ get; set; } 
		public FR_L3WH_GDSNfW_1618_Array() : base() {}

		public FR_L3WH_GDSNfW_1618_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3WH_GDSNfW_1618 for attribute P_L3WH_GDSNfW_1618
		[DataContract]
		public class P_L3WH_GDSNfW_1618 
		{
			//Standard type parameters
			[DataMember]
			public Guid WarehouseID { get; set; } 

		}
		#endregion
		#region SClass L3WH_GDSNfW_1618 for attribute L3WH_GDSNfW_1618
		[DataContract]
		public class L3WH_GDSNfW_1618 
		{
			//Standard type parameters
			[DataMember]
			public String WarehouseSupplierName { get; set; } 
			[DataMember]
			public Guid CMN_BPT_Supplier_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3WH_GDSNfW_1618_Array cls_Get_Default_SupplierName_for_Warehouse(,P_L3WH_GDSNfW_1618 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3WH_GDSNfW_1618_Array invocationResult = cls_Get_Default_SupplierName_for_Warehouse.Invoke(connectionString,P_L3WH_GDSNfW_1618 Parameter,securityTicket);
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
var parameter = new CL3_Warehouse.Atomic.Retrieval.P_L3WH_GDSNfW_1618();
parameter.WarehouseID = ...;

*/
