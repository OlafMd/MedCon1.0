/* 
 * Generated on 4/14/2014 11:48:14 AM
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
    /// var result = cls_Get_Results_for_CountingRun.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Results_for_CountingRun
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5IN_GRfCR_1143_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5IN_GRfCR_1143 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5IN_GRfCR_1143_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOLogistic_Inventory.Atomic.Retrieval.SQL.cls_Get_Results_for_CountingRun.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CountingRunID", Parameter.CountingRunID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"OnlyIf_IsDifferenceFound", Parameter.OnlyIf_IsDifferenceFound);



			List<L5IN_GRfCR_1143> results = new List<L5IN_GRfCR_1143>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "LOG_WRH_INJ_InventoryJob_CountingRunID","LOG_WRH_Shelf_Content_RefID","LOG_WRH_INJ_InventoryJob_Process_ShelfID","LOG_ProductTrackingInstance_RefID","TrackingInstance_CurrentQuantity","Shelf_CurrentQuantity","BatchNumber","Shelf_CountedAmount","TrackingInstance_CountedAmount","Shelf_DifferenceFound","TrackingInstance_DifferenceFound","LOG_WRH_INJ_InventoryJob_CountingResultID","LOG_WRH_INJ_CountingResult_TrackingInstanceID" });
				while(reader.Read())
				{
					L5IN_GRfCR_1143 resultItem = new L5IN_GRfCR_1143();
					//0:Parameter LOG_WRH_INJ_InventoryJob_CountingRunID of type Guid
					resultItem.LOG_WRH_INJ_InventoryJob_CountingRunID = reader.GetGuid(0);
					//1:Parameter LOG_WRH_Shelf_Content_RefID of type Guid
					resultItem.LOG_WRH_Shelf_Content_RefID = reader.GetGuid(1);
					//2:Parameter LOG_WRH_INJ_InventoryJob_Process_ShelfID of type Guid
					resultItem.LOG_WRH_INJ_InventoryJob_Process_ShelfID = reader.GetGuid(2);
					//3:Parameter LOG_ProductTrackingInstance_RefID of type Guid
					resultItem.LOG_ProductTrackingInstance_RefID = reader.GetGuid(3);
					//4:Parameter TrackingInstance_CurrentQuantity of type Double
					resultItem.TrackingInstance_CurrentQuantity = reader.GetDouble(4);
					//5:Parameter Shelf_CurrentQuantity of type Double
					resultItem.Shelf_CurrentQuantity = reader.GetDouble(5);
					//6:Parameter BatchNumber of type String
					resultItem.BatchNumber = reader.GetString(6);
					//7:Parameter Shelf_CountedAmount of type Double
					resultItem.Shelf_CountedAmount = reader.GetDouble(7);
					//8:Parameter TrackingInstance_CountedAmount of type Double
					resultItem.TrackingInstance_CountedAmount = reader.GetDouble(8);
					//9:Parameter Shelf_DifferenceFound of type Boolean
					resultItem.Shelf_DifferenceFound = reader.GetBoolean(9);
					//10:Parameter TrackingInstance_DifferenceFound of type Boolean
					resultItem.TrackingInstance_DifferenceFound = reader.GetBoolean(10);
					//11:Parameter LOG_WRH_INJ_InventoryJob_CountingResultID of type Guid
					resultItem.LOG_WRH_INJ_InventoryJob_CountingResultID = reader.GetGuid(11);
					//12:Parameter LOG_WRH_INJ_CountingResult_TrackingInstanceID of type Guid
					resultItem.LOG_WRH_INJ_CountingResult_TrackingInstanceID = reader.GetGuid(12);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Results_for_CountingRun",ex);
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
		public static FR_L5IN_GRfCR_1143_Array Invoke(string ConnectionString,P_L5IN_GRfCR_1143 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5IN_GRfCR_1143_Array Invoke(DbConnection Connection,P_L5IN_GRfCR_1143 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5IN_GRfCR_1143_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5IN_GRfCR_1143 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5IN_GRfCR_1143_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5IN_GRfCR_1143 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5IN_GRfCR_1143_Array functionReturn = new FR_L5IN_GRfCR_1143_Array();
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

				throw new Exception("Exception occured in method cls_Get_Results_for_CountingRun",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5IN_GRfCR_1143_Array : FR_Base
	{
		public L5IN_GRfCR_1143[] Result	{ get; set; } 
		public FR_L5IN_GRfCR_1143_Array() : base() {}

		public FR_L5IN_GRfCR_1143_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5IN_GRfCR_1143 for attribute P_L5IN_GRfCR_1143
		[DataContract]
		public class P_L5IN_GRfCR_1143 
		{
			//Standard type parameters
			[DataMember]
			public Guid CountingRunID { get; set; } 
			[DataMember]
			public bool? OnlyIf_IsDifferenceFound { get; set; } 

		}
		#endregion
		#region SClass L5IN_GRfCR_1143 for attribute L5IN_GRfCR_1143
		[DataContract]
		public class L5IN_GRfCR_1143 
		{
			//Standard type parameters
			[DataMember]
			public Guid LOG_WRH_INJ_InventoryJob_CountingRunID { get; set; } 
			[DataMember]
			public Guid LOG_WRH_Shelf_Content_RefID { get; set; } 
			[DataMember]
			public Guid LOG_WRH_INJ_InventoryJob_Process_ShelfID { get; set; } 
			[DataMember]
			public Guid LOG_ProductTrackingInstance_RefID { get; set; } 
			[DataMember]
			public Double TrackingInstance_CurrentQuantity { get; set; } 
			[DataMember]
			public Double Shelf_CurrentQuantity { get; set; } 
			[DataMember]
			public String BatchNumber { get; set; } 
			[DataMember]
			public Double Shelf_CountedAmount { get; set; } 
			[DataMember]
			public Double TrackingInstance_CountedAmount { get; set; } 
			[DataMember]
			public Boolean Shelf_DifferenceFound { get; set; } 
			[DataMember]
			public Boolean TrackingInstance_DifferenceFound { get; set; } 
			[DataMember]
			public Guid LOG_WRH_INJ_InventoryJob_CountingResultID { get; set; } 
			[DataMember]
			public Guid LOG_WRH_INJ_CountingResult_TrackingInstanceID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5IN_GRfCR_1143_Array cls_Get_Results_for_CountingRun(,P_L5IN_GRfCR_1143 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5IN_GRfCR_1143_Array invocationResult = cls_Get_Results_for_CountingRun.Invoke(connectionString,P_L5IN_GRfCR_1143 Parameter,securityTicket);
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
var parameter = new CL5_APOLogistic_Inventory.Atomic.Retrieval.P_L5IN_GRfCR_1143();
parameter.CountingRunID = ...;
parameter.OnlyIf_IsDifferenceFound = ...;

*/
