/* 
 * Generated on 3/6/2014 04:19:24
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

namespace CL2_InventoryJobs.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_InventoryJobSeries_ParticipatingShelves_for_InventoryJobSeriesID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_InventoryJobSeries_ParticipatingShelves_for_InventoryJobSeriesID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2IJ_GIJSPSfIJS_1259_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L2IJ_GIJSPSfIJS_1259 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2IJ_GIJSPSfIJS_1259_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_InventoryJobs.Atomic.Retrieval.SQL.cls_Get_InventoryJobSeries_ParticipatingShelves_for_InventoryJobSeriesID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"InventoryJobSeriesID", Parameter.InventoryJobSeriesID);



			List<L2IJ_GIJSPSfIJS_1259> results = new List<L2IJ_GIJSPSfIJS_1259>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "LOG_WRH_Shelf_RefID","LOG_WRH_INJ_InventoryJob_Series_RefID","LOG_WRH_INJ_InventoryJob_Series_ParticipatingShelfID","Creation_Timestamp","Tenant_RefID","IsDeleted" });
				while(reader.Read())
				{
					L2IJ_GIJSPSfIJS_1259 resultItem = new L2IJ_GIJSPSfIJS_1259();
					//0:Parameter LOG_WRH_Shelf_RefID of type Guid
					resultItem.LOG_WRH_Shelf_RefID = reader.GetGuid(0);
					//1:Parameter LOG_WRH_INJ_InventoryJob_Series_RefID of type Guid
					resultItem.LOG_WRH_INJ_InventoryJob_Series_RefID = reader.GetGuid(1);
					//2:Parameter LOG_WRH_INJ_InventoryJob_Series_ParticipatingShelfID of type Guid
					resultItem.LOG_WRH_INJ_InventoryJob_Series_ParticipatingShelfID = reader.GetGuid(2);
					//3:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(3);
					//4:Parameter Tenant_RefID of type Guid
					resultItem.Tenant_RefID = reader.GetGuid(4);
					//5:Parameter IsDeleted of type bool
					resultItem.IsDeleted = reader.GetBoolean(5);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_InventoryJobSeries_ParticipatingShelves_for_InventoryJobSeriesID",ex);
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
		public static FR_L2IJ_GIJSPSfIJS_1259_Array Invoke(string ConnectionString,P_L2IJ_GIJSPSfIJS_1259 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2IJ_GIJSPSfIJS_1259_Array Invoke(DbConnection Connection,P_L2IJ_GIJSPSfIJS_1259 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2IJ_GIJSPSfIJS_1259_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L2IJ_GIJSPSfIJS_1259 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2IJ_GIJSPSfIJS_1259_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2IJ_GIJSPSfIJS_1259 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2IJ_GIJSPSfIJS_1259_Array functionReturn = new FR_L2IJ_GIJSPSfIJS_1259_Array();
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

				throw new Exception("Exception occured in method cls_Get_InventoryJobSeries_ParticipatingShelves_for_InventoryJobSeriesID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2IJ_GIJSPSfIJS_1259_Array : FR_Base
	{
		public L2IJ_GIJSPSfIJS_1259[] Result	{ get; set; } 
		public FR_L2IJ_GIJSPSfIJS_1259_Array() : base() {}

		public FR_L2IJ_GIJSPSfIJS_1259_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L2IJ_GIJSPSfIJS_1259 for attribute P_L2IJ_GIJSPSfIJS_1259
		[DataContract]
		public class P_L2IJ_GIJSPSfIJS_1259 
		{
			//Standard type parameters
			[DataMember]
			public Guid InventoryJobSeriesID { get; set; } 

		}
		#endregion
		#region SClass L2IJ_GIJSPSfIJS_1259 for attribute L2IJ_GIJSPSfIJS_1259
		[DataContract]
		public class L2IJ_GIJSPSfIJS_1259 
		{
			//Standard type parameters
			[DataMember]
			public Guid LOG_WRH_Shelf_RefID { get; set; } 
			[DataMember]
			public Guid LOG_WRH_INJ_InventoryJob_Series_RefID { get; set; } 
			[DataMember]
			public Guid LOG_WRH_INJ_InventoryJob_Series_ParticipatingShelfID { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public Guid Tenant_RefID { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2IJ_GIJSPSfIJS_1259_Array cls_Get_InventoryJobSeries_ParticipatingShelves_for_InventoryJobSeriesID(,P_L2IJ_GIJSPSfIJS_1259 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2IJ_GIJSPSfIJS_1259_Array invocationResult = cls_Get_InventoryJobSeries_ParticipatingShelves_for_InventoryJobSeriesID.Invoke(connectionString,P_L2IJ_GIJSPSfIJS_1259 Parameter,securityTicket);
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
var parameter = new CL2_InventoryJobs.Atomic.Retrieval.P_L2IJ_GIJSPSfIJS_1259();
parameter.InventoryJobSeriesID = ...;

*/
