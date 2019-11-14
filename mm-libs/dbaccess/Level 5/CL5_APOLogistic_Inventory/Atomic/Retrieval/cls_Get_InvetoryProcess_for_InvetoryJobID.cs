/* 
 * Generated on 3/27/2014 11:38:14 AM
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
    /// var result = cls_Get_InvetoryProcess_for_InvetoryJobID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_InvetoryProcess_for_InvetoryJobID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5IN_GIPfIJ_1449_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5IN_GIPfIJ_1449 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5IN_GIPfIJ_1449_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOLogistic_Inventory.Atomic.Retrieval.SQL.cls_Get_InvetoryProcess_for_InvetoryJobID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"InvetoryJobID", Parameter.InvetoryJobID);



			List<L5IN_GIPfIJ_1449_raw> results = new List<L5IN_GIPfIJ_1449_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "LOG_WRH_INJ_InventoryJob_ProcessID","ProcessSequenceNumber","LOG_WRH_INJ_InventoryJob_CountingRunID","IsCounting_Started","IsCounting_Completed","IsCountingListPrinted","IsDifferenceFound","SequenceNumber","LOG_WRH_INJ_InventoryJob_Process_ShelfID","LOG_WRH_Shelf_RefID" });
				while(reader.Read())
				{
					L5IN_GIPfIJ_1449_raw resultItem = new L5IN_GIPfIJ_1449_raw();
					//0:Parameter LOG_WRH_INJ_InventoryJob_ProcessID of type Guid
					resultItem.LOG_WRH_INJ_InventoryJob_ProcessID = reader.GetGuid(0);
					//1:Parameter ProcessSequenceNumber of type int
					resultItem.ProcessSequenceNumber = reader.GetInteger(1);
					//2:Parameter LOG_WRH_INJ_InventoryJob_CountingRunID of type Guid
					resultItem.LOG_WRH_INJ_InventoryJob_CountingRunID = reader.GetGuid(2);
					//3:Parameter IsCounting_Started of type bool
					resultItem.IsCounting_Started = reader.GetBoolean(3);
					//4:Parameter IsCounting_Completed of type bool
					resultItem.IsCounting_Completed = reader.GetBoolean(4);
					//5:Parameter IsCountingListPrinted of type bool
					resultItem.IsCountingListPrinted = reader.GetBoolean(5);
					//6:Parameter IsDifferenceFound of type bool
					resultItem.IsDifferenceFound = reader.GetBoolean(6);
					//7:Parameter SequenceNumber of type int
					resultItem.SequenceNumber = reader.GetInteger(7);
					//8:Parameter LOG_WRH_INJ_InventoryJob_Process_ShelfID of type Guid
					resultItem.LOG_WRH_INJ_InventoryJob_Process_ShelfID = reader.GetGuid(8);
					//9:Parameter LOG_WRH_Shelf_RefID of type Guid
					resultItem.LOG_WRH_Shelf_RefID = reader.GetGuid(9);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_InvetoryProcess_for_InvetoryJobID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5IN_GIPfIJ_1449_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5IN_GIPfIJ_1449_Array Invoke(string ConnectionString,P_L5IN_GIPfIJ_1449 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5IN_GIPfIJ_1449_Array Invoke(DbConnection Connection,P_L5IN_GIPfIJ_1449 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5IN_GIPfIJ_1449_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5IN_GIPfIJ_1449 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5IN_GIPfIJ_1449_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5IN_GIPfIJ_1449 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5IN_GIPfIJ_1449_Array functionReturn = new FR_L5IN_GIPfIJ_1449_Array();
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

				throw new Exception("Exception occured in method cls_Get_InvetoryProcess_for_InvetoryJobID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5IN_GIPfIJ_1449_raw 
	{
		public Guid LOG_WRH_INJ_InventoryJob_ProcessID; 
		public int ProcessSequenceNumber; 
		public Guid LOG_WRH_INJ_InventoryJob_CountingRunID; 
		public bool IsCounting_Started; 
		public bool IsCounting_Completed; 
		public bool IsCountingListPrinted; 
		public bool IsDifferenceFound; 
		public int SequenceNumber; 
		public Guid LOG_WRH_INJ_InventoryJob_Process_ShelfID; 
		public Guid LOG_WRH_Shelf_RefID; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5IN_GIPfIJ_1449[] Convert(List<L5IN_GIPfIJ_1449_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5IN_GIPfIJ_1449 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.LOG_WRH_INJ_InventoryJob_ProcessID)).ToArray()
	group el_L5IN_GIPfIJ_1449 by new 
	{ 
		el_L5IN_GIPfIJ_1449.LOG_WRH_INJ_InventoryJob_ProcessID,

	}
	into gfunct_L5IN_GIPfIJ_1449
	select new L5IN_GIPfIJ_1449
	{     
		LOG_WRH_INJ_InventoryJob_ProcessID = gfunct_L5IN_GIPfIJ_1449.Key.LOG_WRH_INJ_InventoryJob_ProcessID ,
		ProcessSequenceNumber = gfunct_L5IN_GIPfIJ_1449.FirstOrDefault().ProcessSequenceNumber ,

		CountingRun = 
		(
			from el_CountingRun in gfunct_L5IN_GIPfIJ_1449.Where(element => !EqualsDefaultValue(element.LOG_WRH_INJ_InventoryJob_CountingRunID)).ToArray()
			group el_CountingRun by new 
			{ 
				el_CountingRun.LOG_WRH_INJ_InventoryJob_CountingRunID,

			}
			into gfunct_CountingRun
			select new L5IN_GIPfIJ_1449_CountingRuns
			{     
				LOG_WRH_INJ_InventoryJob_CountingRunID = gfunct_CountingRun.Key.LOG_WRH_INJ_InventoryJob_CountingRunID ,
				IsCounting_Started = gfunct_CountingRun.FirstOrDefault().IsCounting_Started ,
				IsCounting_Completed = gfunct_CountingRun.FirstOrDefault().IsCounting_Completed ,
				IsCountingListPrinted = gfunct_CountingRun.FirstOrDefault().IsCountingListPrinted ,
				IsDifferenceFound = gfunct_CountingRun.FirstOrDefault().IsDifferenceFound ,
				SequenceNumber = gfunct_CountingRun.FirstOrDefault().SequenceNumber ,

			}
		).ToArray(),
		ProcessShelfs = 
		(
			from el_ProcessShelfs in gfunct_L5IN_GIPfIJ_1449.Where(element => !EqualsDefaultValue(element.LOG_WRH_INJ_InventoryJob_Process_ShelfID)).ToArray()
			group el_ProcessShelfs by new 
			{ 
				el_ProcessShelfs.LOG_WRH_INJ_InventoryJob_Process_ShelfID,

			}
			into gfunct_ProcessShelfs
			select new L5IN_GIPfIJ_1449_Shelfs
			{     
				LOG_WRH_INJ_InventoryJob_Process_ShelfID = gfunct_ProcessShelfs.Key.LOG_WRH_INJ_InventoryJob_Process_ShelfID ,
				LOG_WRH_Shelf_RefID = gfunct_ProcessShelfs.FirstOrDefault().LOG_WRH_Shelf_RefID ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5IN_GIPfIJ_1449_Array : FR_Base
	{
		public L5IN_GIPfIJ_1449[] Result	{ get; set; } 
		public FR_L5IN_GIPfIJ_1449_Array() : base() {}

		public FR_L5IN_GIPfIJ_1449_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5IN_GIPfIJ_1449 for attribute P_L5IN_GIPfIJ_1449
		[DataContract]
		public class P_L5IN_GIPfIJ_1449 
		{
			//Standard type parameters
			[DataMember]
			public Guid InvetoryJobID { get; set; } 

		}
		#endregion
		#region SClass L5IN_GIPfIJ_1449 for attribute L5IN_GIPfIJ_1449
		[DataContract]
		public class L5IN_GIPfIJ_1449 
		{
			[DataMember]
			public L5IN_GIPfIJ_1449_CountingRuns[] CountingRun { get; set; }
			[DataMember]
			public L5IN_GIPfIJ_1449_Shelfs[] ProcessShelfs { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid LOG_WRH_INJ_InventoryJob_ProcessID { get; set; } 
			[DataMember]
			public int ProcessSequenceNumber { get; set; } 

		}
		#endregion
		#region SClass L5IN_GIPfIJ_1449_CountingRuns for attribute CountingRun
		[DataContract]
		public class L5IN_GIPfIJ_1449_CountingRuns 
		{
			//Standard type parameters
			[DataMember]
			public Guid LOG_WRH_INJ_InventoryJob_CountingRunID { get; set; } 
			[DataMember]
			public bool IsCounting_Started { get; set; } 
			[DataMember]
			public bool IsCounting_Completed { get; set; } 
			[DataMember]
			public bool IsCountingListPrinted { get; set; } 
			[DataMember]
			public bool IsDifferenceFound { get; set; } 
			[DataMember]
			public int SequenceNumber { get; set; } 

		}
		#endregion
		#region SClass L5IN_GIPfIJ_1449_Shelfs for attribute ProcessShelfs
		[DataContract]
		public class L5IN_GIPfIJ_1449_Shelfs 
		{
			//Standard type parameters
			[DataMember]
			public Guid LOG_WRH_INJ_InventoryJob_Process_ShelfID { get; set; } 
			[DataMember]
			public Guid LOG_WRH_Shelf_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5IN_GIPfIJ_1449_Array cls_Get_InvetoryProcess_for_InvetoryJobID(,P_L5IN_GIPfIJ_1449 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5IN_GIPfIJ_1449_Array invocationResult = cls_Get_InvetoryProcess_for_InvetoryJobID.Invoke(connectionString,P_L5IN_GIPfIJ_1449 Parameter,securityTicket);
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
var parameter = new CL5_APOLogistic_Inventory.Atomic.Retrieval.P_L5IN_GIPfIJ_1449();
parameter.InvetoryJobID = ...;

*/
