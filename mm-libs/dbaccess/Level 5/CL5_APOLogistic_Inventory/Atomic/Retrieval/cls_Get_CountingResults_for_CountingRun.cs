/* 
 * Generated on 7/24/2014 5:05:48 PM
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
    /// var result = cls_Get_CountingResults_for_CountingRun.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_CountingResults_for_CountingRun
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5IN_GCRfCR_1654_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5IN_GCRfCR_1654 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5IN_GCRfCR_1654_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOLogistic_Inventory.Atomic.Retrieval.SQL.cls_Get_CountingResults_for_CountingRun.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CountingRunID", Parameter.CountingRunID);



			List<L5IN_GCRfCR_1654> results = new List<L5IN_GCRfCR_1654>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CountingRun_RefID","LOG_WRH_INJ_InventoryJob_CountingResultID","TrackingInstance_CurrentQuantity","BatchNumber","TrackingInstance_CountedAmount","Shelf_CountedAmount","Shelf_DifferenceFound","TrackingInstance_DifferenceFound","LOG_WRH_INJ_CountingResult_TrackingInstanceID","LOG_WRH_Shelf_ContentID","LOG_ProductTrackingInstanceID","Shelf_CurrentQuantity" });
				while(reader.Read())
				{
					L5IN_GCRfCR_1654 resultItem = new L5IN_GCRfCR_1654();
					//0:Parameter CountingRun_RefID of type Guid
					resultItem.CountingRun_RefID = reader.GetGuid(0);
					//1:Parameter LOG_WRH_INJ_InventoryJob_CountingResultID of type Guid
					resultItem.LOG_WRH_INJ_InventoryJob_CountingResultID = reader.GetGuid(1);
					//2:Parameter TrackingInstance_CurrentQuantity of type double
					resultItem.TrackingInstance_CurrentQuantity = reader.GetDouble(2);
					//3:Parameter BatchNumber of type String
					resultItem.BatchNumber = reader.GetString(3);
					//4:Parameter TrackingInstance_CountedAmount of type double
					resultItem.TrackingInstance_CountedAmount = reader.GetDouble(4);
					//5:Parameter Shelf_CountedAmount of type double
					resultItem.Shelf_CountedAmount = reader.GetDouble(5);
					//6:Parameter Shelf_DifferenceFound of type bool
					resultItem.Shelf_DifferenceFound = reader.GetBoolean(6);
					//7:Parameter TrackingInstance_DifferenceFound of type bool
					resultItem.TrackingInstance_DifferenceFound = reader.GetBoolean(7);
					//8:Parameter LOG_WRH_INJ_CountingResult_TrackingInstanceID of type Guid
					resultItem.LOG_WRH_INJ_CountingResult_TrackingInstanceID = reader.GetGuid(8);
					//9:Parameter LOG_WRH_Shelf_ContentID of type Guid
					resultItem.LOG_WRH_Shelf_ContentID = reader.GetGuid(9);
					//10:Parameter LOG_ProductTrackingInstanceID of type Guid
					resultItem.LOG_ProductTrackingInstanceID = reader.GetGuid(10);
					//11:Parameter Shelf_CurrentQuantity of type double
					resultItem.Shelf_CurrentQuantity = reader.GetDouble(11);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_CountingResults_for_CountingRun",ex);
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
		public static FR_L5IN_GCRfCR_1654_Array Invoke(string ConnectionString,P_L5IN_GCRfCR_1654 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5IN_GCRfCR_1654_Array Invoke(DbConnection Connection,P_L5IN_GCRfCR_1654 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5IN_GCRfCR_1654_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5IN_GCRfCR_1654 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5IN_GCRfCR_1654_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5IN_GCRfCR_1654 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5IN_GCRfCR_1654_Array functionReturn = new FR_L5IN_GCRfCR_1654_Array();
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

				throw new Exception("Exception occured in method cls_Get_CountingResults_for_CountingRun",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5IN_GCRfCR_1654_Array : FR_Base
	{
		public L5IN_GCRfCR_1654[] Result	{ get; set; } 
		public FR_L5IN_GCRfCR_1654_Array() : base() {}

		public FR_L5IN_GCRfCR_1654_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5IN_GCRfCR_1654 for attribute P_L5IN_GCRfCR_1654
		[DataContract]
		public class P_L5IN_GCRfCR_1654 
		{
			//Standard type parameters
			[DataMember]
			public Guid CountingRunID { get; set; } 

		}
		#endregion
		#region SClass L5IN_GCRfCR_1654 for attribute L5IN_GCRfCR_1654
		[DataContract]
		public class L5IN_GCRfCR_1654 
		{
			//Standard type parameters
			[DataMember]
			public Guid CountingRun_RefID { get; set; } 
			[DataMember]
			public Guid LOG_WRH_INJ_InventoryJob_CountingResultID { get; set; } 
			[DataMember]
			public double TrackingInstance_CurrentQuantity { get; set; } 
			[DataMember]
			public String BatchNumber { get; set; } 
			[DataMember]
			public double TrackingInstance_CountedAmount { get; set; } 
			[DataMember]
			public double Shelf_CountedAmount { get; set; } 
			[DataMember]
			public bool Shelf_DifferenceFound { get; set; } 
			[DataMember]
			public bool TrackingInstance_DifferenceFound { get; set; } 
			[DataMember]
			public Guid LOG_WRH_INJ_CountingResult_TrackingInstanceID { get; set; } 
			[DataMember]
			public Guid LOG_WRH_Shelf_ContentID { get; set; } 
			[DataMember]
			public Guid LOG_ProductTrackingInstanceID { get; set; } 
			[DataMember]
			public double Shelf_CurrentQuantity { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5IN_GCRfCR_1654_Array cls_Get_CountingResults_for_CountingRun(,P_L5IN_GCRfCR_1654 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5IN_GCRfCR_1654_Array invocationResult = cls_Get_CountingResults_for_CountingRun.Invoke(connectionString,P_L5IN_GCRfCR_1654 Parameter,securityTicket);
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
var parameter = new CL5_APOLogistic_Inventory.Atomic.Retrieval.P_L5IN_GCRfCR_1654();
parameter.CountingRunID = ...;

*/
