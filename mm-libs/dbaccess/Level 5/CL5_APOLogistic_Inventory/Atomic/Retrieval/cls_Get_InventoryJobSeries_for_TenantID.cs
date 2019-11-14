/* 
 * Generated on 6/2/2014 1:34:56 PM
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
    /// var result = cls_Get_InventoryJobSeries_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_InventoryJobSeries_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5IN_GIJSfT_1331_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5IN_GIJSfT_1331_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOLogistic_Inventory.Atomic.Retrieval.SQL.cls_Get_InventoryJobSeries_for_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L5IN_GIJSfT_1331> results = new List<L5IN_GIJSfT_1331>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "LOG_WRH_INJ_InventoryJob_SeriesID","InventoryJobSeries_DisplayName","Creation_Timestamp","RythmCronExpression","ShelfToCount","ArticlesToCount" });
				while(reader.Read())
				{
					L5IN_GIJSfT_1331 resultItem = new L5IN_GIJSfT_1331();
					//0:Parameter LOG_WRH_INJ_InventoryJob_SeriesID of type Guid
					resultItem.LOG_WRH_INJ_InventoryJob_SeriesID = reader.GetGuid(0);
					//1:Parameter InventoryJobSeries_DisplayName of type String
					resultItem.InventoryJobSeries_DisplayName = reader.GetString(1);
					//2:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(2);
					//3:Parameter RythmCronExpression of type String
					resultItem.RythmCronExpression = reader.GetString(3);
					//4:Parameter ShelfToCount of type int
					resultItem.ShelfToCount = reader.GetInteger(4);
					//5:Parameter ArticlesToCount of type int
					resultItem.ArticlesToCount = reader.GetInteger(5);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_InventoryJobSeries_for_TenantID",ex);
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
		public static FR_L5IN_GIJSfT_1331_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5IN_GIJSfT_1331_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5IN_GIJSfT_1331_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5IN_GIJSfT_1331_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5IN_GIJSfT_1331_Array functionReturn = new FR_L5IN_GIJSfT_1331_Array();
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

				throw new Exception("Exception occured in method cls_Get_InventoryJobSeries_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5IN_GIJSfT_1331_Array : FR_Base
	{
		public L5IN_GIJSfT_1331[] Result	{ get; set; } 
		public FR_L5IN_GIJSfT_1331_Array() : base() {}

		public FR_L5IN_GIJSfT_1331_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5IN_GIJSfT_1331 for attribute L5IN_GIJSfT_1331
		[DataContract]
		public class L5IN_GIJSfT_1331 
		{
			//Standard type parameters
			[DataMember]
			public Guid LOG_WRH_INJ_InventoryJob_SeriesID { get; set; } 
			[DataMember]
			public String InventoryJobSeries_DisplayName { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public String RythmCronExpression { get; set; } 
			[DataMember]
			public int ShelfToCount { get; set; } 
			[DataMember]
			public int ArticlesToCount { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5IN_GIJSfT_1331_Array cls_Get_InventoryJobSeries_for_TenantID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5IN_GIJSfT_1331_Array invocationResult = cls_Get_InventoryJobSeries_for_TenantID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

