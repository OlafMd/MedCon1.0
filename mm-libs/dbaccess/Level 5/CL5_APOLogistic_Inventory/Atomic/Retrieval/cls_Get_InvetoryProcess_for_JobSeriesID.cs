/* 
 * Generated on 6/3/2014 3:46:55 PM
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
    /// var result = cls_Get_InvetoryProcess_for_JobSeriesID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_InvetoryProcess_for_JobSeriesID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5IN_GIPfJS_1539_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5IN_GIPfJS_1539 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5IN_GIPfJS_1539_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOLogistic_Inventory.Atomic.Retrieval.SQL.cls_Get_InvetoryProcess_for_JobSeriesID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"InventoryJobSeries_RefID", Parameter.InventoryJobSeries_RefID);



			List<L5IN_GIPfJS_1539_raw> results = new List<L5IN_GIPfJS_1539_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "LOG_WRH_INJ_InventoryJob_ProcessID","LOG_WRH_INJ_InventoryJobID","Creation_Timestamp","LOG_WRH_INJ_InventoryJob_CountingRunID","SequenceNumber","IsCounting_Started","IsCounting_Completed","IsCountingListPrinted" });
				while(reader.Read())
				{
					L5IN_GIPfJS_1539_raw resultItem = new L5IN_GIPfJS_1539_raw();
					//0:Parameter LOG_WRH_INJ_InventoryJob_ProcessID of type Guid
					resultItem.LOG_WRH_INJ_InventoryJob_ProcessID = reader.GetGuid(0);
					//1:Parameter LOG_WRH_INJ_InventoryJobID of type Guid
					resultItem.LOG_WRH_INJ_InventoryJobID = reader.GetGuid(1);
					//2:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(2);
					//3:Parameter LOG_WRH_INJ_InventoryJob_CountingRunID of type Guid
					resultItem.LOG_WRH_INJ_InventoryJob_CountingRunID = reader.GetGuid(3);
					//4:Parameter SequenceNumber of type int
					resultItem.SequenceNumber = reader.GetInteger(4);
					//5:Parameter IsCounting_Started of type bool
					resultItem.IsCounting_Started = reader.GetBoolean(5);
					//6:Parameter IsCounting_Completed of type bool
					resultItem.IsCounting_Completed = reader.GetBoolean(6);
					//7:Parameter IsCountingListPrinted of type bool
					resultItem.IsCountingListPrinted = reader.GetBoolean(7);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_InvetoryProcess_for_JobSeriesID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5IN_GIPfJS_1539_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5IN_GIPfJS_1539_Array Invoke(string ConnectionString,P_L5IN_GIPfJS_1539 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5IN_GIPfJS_1539_Array Invoke(DbConnection Connection,P_L5IN_GIPfJS_1539 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5IN_GIPfJS_1539_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5IN_GIPfJS_1539 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5IN_GIPfJS_1539_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5IN_GIPfJS_1539 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5IN_GIPfJS_1539_Array functionReturn = new FR_L5IN_GIPfJS_1539_Array();
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

				throw new Exception("Exception occured in method cls_Get_InvetoryProcess_for_JobSeriesID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5IN_GIPfJS_1539_raw 
	{
		public Guid LOG_WRH_INJ_InventoryJob_ProcessID; 
		public Guid LOG_WRH_INJ_InventoryJobID; 
		public DateTime Creation_Timestamp; 
		public Guid LOG_WRH_INJ_InventoryJob_CountingRunID; 
		public int SequenceNumber; 
		public bool IsCounting_Started; 
		public bool IsCounting_Completed; 
		public bool IsCountingListPrinted; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5IN_GIPfJS_1539[] Convert(List<L5IN_GIPfJS_1539_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5IN_GIPfJS_1539 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.LOG_WRH_INJ_InventoryJob_ProcessID)).ToArray()
	group el_L5IN_GIPfJS_1539 by new 
	{ 
		el_L5IN_GIPfJS_1539.LOG_WRH_INJ_InventoryJob_ProcessID,

	}
	into gfunct_L5IN_GIPfJS_1539
	select new L5IN_GIPfJS_1539
	{     
		LOG_WRH_INJ_InventoryJob_ProcessID = gfunct_L5IN_GIPfJS_1539.Key.LOG_WRH_INJ_InventoryJob_ProcessID ,
		LOG_WRH_INJ_InventoryJobID = gfunct_L5IN_GIPfJS_1539.FirstOrDefault().LOG_WRH_INJ_InventoryJobID ,
		Creation_Timestamp = gfunct_L5IN_GIPfJS_1539.FirstOrDefault().Creation_Timestamp ,

		CountingRun = 
		(
			from el_CountingRun in gfunct_L5IN_GIPfJS_1539.Where(element => !EqualsDefaultValue(element.LOG_WRH_INJ_InventoryJob_CountingRunID)).ToArray()
			group el_CountingRun by new 
			{ 
				el_CountingRun.LOG_WRH_INJ_InventoryJob_CountingRunID,

			}
			into gfunct_CountingRun
			select new L5IN_GIPfJS_1539_CountingRuns
			{     
				LOG_WRH_INJ_InventoryJob_CountingRunID = gfunct_CountingRun.Key.LOG_WRH_INJ_InventoryJob_CountingRunID ,
				SequenceNumber = gfunct_CountingRun.FirstOrDefault().SequenceNumber ,
				IsCounting_Started = gfunct_CountingRun.FirstOrDefault().IsCounting_Started ,
				IsCounting_Completed = gfunct_CountingRun.FirstOrDefault().IsCounting_Completed ,
				IsCountingListPrinted = gfunct_CountingRun.FirstOrDefault().IsCountingListPrinted ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5IN_GIPfJS_1539_Array : FR_Base
	{
		public L5IN_GIPfJS_1539[] Result	{ get; set; } 
		public FR_L5IN_GIPfJS_1539_Array() : base() {}

		public FR_L5IN_GIPfJS_1539_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5IN_GIPfJS_1539 for attribute P_L5IN_GIPfJS_1539
		[DataContract]
		public class P_L5IN_GIPfJS_1539 
		{
			//Standard type parameters
			[DataMember]
			public Guid InventoryJobSeries_RefID { get; set; } 

		}
		#endregion
		#region SClass L5IN_GIPfJS_1539 for attribute L5IN_GIPfJS_1539
		[DataContract]
		public class L5IN_GIPfJS_1539 
		{
			[DataMember]
			public L5IN_GIPfJS_1539_CountingRuns[] CountingRun { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid LOG_WRH_INJ_InventoryJob_ProcessID { get; set; } 
			[DataMember]
			public Guid LOG_WRH_INJ_InventoryJobID { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 

		}
		#endregion
		#region SClass L5IN_GIPfJS_1539_CountingRuns for attribute CountingRun
		[DataContract]
		public class L5IN_GIPfJS_1539_CountingRuns 
		{
			//Standard type parameters
			[DataMember]
			public Guid LOG_WRH_INJ_InventoryJob_CountingRunID { get; set; } 
			[DataMember]
			public int SequenceNumber { get; set; } 
			[DataMember]
			public bool IsCounting_Started { get; set; } 
			[DataMember]
			public bool IsCounting_Completed { get; set; } 
			[DataMember]
			public bool IsCountingListPrinted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5IN_GIPfJS_1539_Array cls_Get_InvetoryProcess_for_JobSeriesID(,P_L5IN_GIPfJS_1539 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5IN_GIPfJS_1539_Array invocationResult = cls_Get_InvetoryProcess_for_JobSeriesID.Invoke(connectionString,P_L5IN_GIPfJS_1539 Parameter,securityTicket);
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
var parameter = new CL5_APOLogistic_Inventory.Atomic.Retrieval.P_L5IN_GIPfJS_1539();
parameter.InventoryJobSeries_RefID = ...;

*/
