/* 
 * Generated on 7/23/2014 1:47:38 PM
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

namespace CL5_APOLogistic_Inventory.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ShelfContent_with_Quantity_for_InventoryJob_ProcessID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ShelfContent_with_Quantity_for_InventoryJob_ProcessID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5IN_GSCwQfIJP_1023_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5IN_GSCwQfIJP_1023 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5IN_GSCwQfIJP_1023_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOLogistic_Inventory.Atomic.Retrieval.SQL.cls_Get_ShelfContent_with_Quantity_for_InventoryJob_ProcessID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ProcessID", Parameter.ProcessID);



			List<L5IN_GSCwQfIJP_1023> results = new List<L5IN_GSCwQfIJP_1023>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "LOG_WRH_INJ_InventoryJob_Process_ShelfID","LOG_WRH_Shelf_RefID","LOG_WRH_Shelf_ContentID","LOG_ProductTrackingInstanceID","BatchNumber","ExpirationDate","ShelfContent_Quantity","TrackingInstance_Quantity","Product_RefID","ShelfCode","ShelfName" });
				while(reader.Read())
				{
					L5IN_GSCwQfIJP_1023 resultItem = new L5IN_GSCwQfIJP_1023();
					//0:Parameter LOG_WRH_INJ_InventoryJob_Process_ShelfID of type Guid
					resultItem.LOG_WRH_INJ_InventoryJob_Process_ShelfID = reader.GetGuid(0);
					//1:Parameter LOG_WRH_Shelf_RefID of type Guid
					resultItem.LOG_WRH_Shelf_RefID = reader.GetGuid(1);
					//2:Parameter LOG_WRH_Shelf_ContentID of type Guid
					resultItem.LOG_WRH_Shelf_ContentID = reader.GetGuid(2);
					//3:Parameter LOG_ProductTrackingInstanceID of type Guid
					resultItem.LOG_ProductTrackingInstanceID = reader.GetGuid(3);
					//4:Parameter BatchNumber of type String
					resultItem.BatchNumber = reader.GetString(4);
					//5:Parameter ExpirationDate of type DateTime
					resultItem.ExpirationDate = reader.GetDate(5);
					//6:Parameter ShelfContent_Quantity of type Double
					resultItem.ShelfContent_Quantity = reader.GetDouble(6);
					//7:Parameter TrackingInstance_Quantity of type Double
					resultItem.TrackingInstance_Quantity = reader.GetDouble(7);
					//8:Parameter Product_RefID of type Guid
					resultItem.Product_RefID = reader.GetGuid(8);
					//9:Parameter ShelfCode of type string
					resultItem.ShelfCode = reader.GetString(9);
					//10:Parameter ShelfName of type string
					resultItem.ShelfName = reader.GetString(10);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_ShelfContent_with_Quantity_for_InventoryJob_ProcessID",ex);
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
		public static FR_L5IN_GSCwQfIJP_1023_Array Invoke(string ConnectionString,P_L5IN_GSCwQfIJP_1023 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5IN_GSCwQfIJP_1023_Array Invoke(DbConnection Connection,P_L5IN_GSCwQfIJP_1023 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5IN_GSCwQfIJP_1023_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5IN_GSCwQfIJP_1023 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5IN_GSCwQfIJP_1023_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5IN_GSCwQfIJP_1023 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5IN_GSCwQfIJP_1023_Array functionReturn = new FR_L5IN_GSCwQfIJP_1023_Array();
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

				throw new Exception("Exception occured in method cls_Get_ShelfContent_with_Quantity_for_InventoryJob_ProcessID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5IN_GSCwQfIJP_1023_Array : FR_Base
	{
		public L5IN_GSCwQfIJP_1023[] Result	{ get; set; } 
		public FR_L5IN_GSCwQfIJP_1023_Array() : base() {}

		public FR_L5IN_GSCwQfIJP_1023_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5IN_GSCwQfIJP_1023 for attribute P_L5IN_GSCwQfIJP_1023
		[DataContract]
		public class P_L5IN_GSCwQfIJP_1023 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProcessID { get; set; } 

		}
		#endregion
		#region SClass L5IN_GSCwQfIJP_1023 for attribute L5IN_GSCwQfIJP_1023
		[DataContract]
		public class L5IN_GSCwQfIJP_1023 
		{
			//Standard type parameters
			[DataMember]
			public Guid LOG_WRH_INJ_InventoryJob_Process_ShelfID { get; set; } 
			[DataMember]
			public Guid LOG_WRH_Shelf_RefID { get; set; } 
			[DataMember]
			public Guid LOG_WRH_Shelf_ContentID { get; set; } 
			[DataMember]
			public Guid LOG_ProductTrackingInstanceID { get; set; } 
			[DataMember]
			public String BatchNumber { get; set; } 
			[DataMember]
			public DateTime ExpirationDate { get; set; } 
			[DataMember]
			public Double ShelfContent_Quantity { get; set; } 
			[DataMember]
			public Double TrackingInstance_Quantity { get; set; } 
			[DataMember]
			public Guid Product_RefID { get; set; } 
			[DataMember]
			public string ShelfCode { get; set; } 
			[DataMember]
			public string ShelfName { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5IN_GSCwQfIJP_1023_Array cls_Get_ShelfContent_with_Quantity_for_InventoryJob_ProcessID(,P_L5IN_GSCwQfIJP_1023 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5IN_GSCwQfIJP_1023_Array invocationResult = cls_Get_ShelfContent_with_Quantity_for_InventoryJob_ProcessID.Invoke(connectionString,P_L5IN_GSCwQfIJP_1023 Parameter,securityTicket);
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
var parameter = new CL5_APOLogistic_Inventory.Atomic.Retrieval.P_L5IN_GSCwQfIJP_1023();
parameter.ProcessID = ...;

*/
