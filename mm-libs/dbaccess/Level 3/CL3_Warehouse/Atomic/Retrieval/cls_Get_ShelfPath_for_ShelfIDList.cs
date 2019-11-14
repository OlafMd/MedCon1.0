/* 
 * Generated on 3/20/2015 01:59:39
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

namespace CL3_Warehouse.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ShelfPath_for_ShelfIDList.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ShelfPath_for_ShelfIDList
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3WH_GSPfSL_1443_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3WH_GSPfSL_1443 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3WH_GSPfSL_1443_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_Warehouse.Atomic.Retrieval.SQL.cls_Get_ShelfPath_for_ShelfIDList.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@ShelfIDs"," IN $$ShelfIDs$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$ShelfIDs$",Parameter.ShelfIDs);


			List<L3WH_GSPfSL_1443> results = new List<L3WH_GSPfSL_1443>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "Rack_Name","RackCode","Area_Name","AreaCode","Warehouse_Name","WarehouseCode","Shelf_Name","ShelfCode","LOG_WRH_ShelfID" });
				while(reader.Read())
				{
					L3WH_GSPfSL_1443 resultItem = new L3WH_GSPfSL_1443();
					//0:Parameter Rack_Name of type String
					resultItem.Rack_Name = reader.GetString(0);
					//1:Parameter RackCode of type String
					resultItem.RackCode = reader.GetString(1);
					//2:Parameter Area_Name of type String
					resultItem.Area_Name = reader.GetString(2);
					//3:Parameter AreaCode of type String
					resultItem.AreaCode = reader.GetString(3);
					//4:Parameter Warehouse_Name of type String
					resultItem.Warehouse_Name = reader.GetString(4);
					//5:Parameter WarehouseCode of type String
					resultItem.WarehouseCode = reader.GetString(5);
					//6:Parameter Shelf_Name of type String
					resultItem.Shelf_Name = reader.GetString(6);
					//7:Parameter ShelfCode of type String
					resultItem.ShelfCode = reader.GetString(7);
					//8:Parameter LOG_WRH_ShelfID of type Guid
					resultItem.LOG_WRH_ShelfID = reader.GetGuid(8);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_ShelfPath_for_ShelfIDList",ex);
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
		public static FR_L3WH_GSPfSL_1443_Array Invoke(string ConnectionString,P_L3WH_GSPfSL_1443 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3WH_GSPfSL_1443_Array Invoke(DbConnection Connection,P_L3WH_GSPfSL_1443 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3WH_GSPfSL_1443_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3WH_GSPfSL_1443 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3WH_GSPfSL_1443_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3WH_GSPfSL_1443 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3WH_GSPfSL_1443_Array functionReturn = new FR_L3WH_GSPfSL_1443_Array();
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

				throw new Exception("Exception occured in method cls_Get_ShelfPath_for_ShelfIDList",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3WH_GSPfSL_1443_Array : FR_Base
	{
		public L3WH_GSPfSL_1443[] Result	{ get; set; } 
		public FR_L3WH_GSPfSL_1443_Array() : base() {}

		public FR_L3WH_GSPfSL_1443_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3WH_GSPfSL_1443 for attribute P_L3WH_GSPfSL_1443
		[DataContract]
		public class P_L3WH_GSPfSL_1443 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] ShelfIDs { get; set; } 

		}
		#endregion
		#region SClass L3WH_GSPfSL_1443 for attribute L3WH_GSPfSL_1443
		[DataContract]
		public class L3WH_GSPfSL_1443 
		{
			//Standard type parameters
			[DataMember]
			public String Rack_Name { get; set; } 
			[DataMember]
			public String RackCode { get; set; } 
			[DataMember]
			public String Area_Name { get; set; } 
			[DataMember]
			public String AreaCode { get; set; } 
			[DataMember]
			public String Warehouse_Name { get; set; } 
			[DataMember]
			public String WarehouseCode { get; set; } 
			[DataMember]
			public String Shelf_Name { get; set; } 
			[DataMember]
			public String ShelfCode { get; set; } 
			[DataMember]
			public Guid LOG_WRH_ShelfID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3WH_GSPfSL_1443_Array cls_Get_ShelfPath_for_ShelfIDList(,P_L3WH_GSPfSL_1443 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3WH_GSPfSL_1443_Array invocationResult = cls_Get_ShelfPath_for_ShelfIDList.Invoke(connectionString,P_L3WH_GSPfSL_1443 Parameter,securityTicket);
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
var parameter = new CL3_Warehouse.Atomic.Retrieval.P_L3WH_GSPfSL_1443();
parameter.ShelfIDs = ...;

*/
