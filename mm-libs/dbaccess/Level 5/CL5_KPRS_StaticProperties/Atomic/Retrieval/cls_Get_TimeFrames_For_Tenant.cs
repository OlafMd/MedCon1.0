/* 
 * Generated on 8/12/2013 10:54:23 AM
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

namespace CL5_KPRS_StaticProperties.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_TimeFrames_For_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_TimeFrames_For_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5SP_GTFFT_1030_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5SP_GTFFT_1030_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_KPRS_StaticProperties.Atomic.Retrieval.SQL.cls_Get_TimeFrames_For_Tenant.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L5SP_GTFFT_1030> results = new List<L5SP_GTFFT_1030>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "RES_TimeframeID","Timeframe_Name_DictID","Timeframe_Description_DictID","Timeframe_SequenceNumber","IsDeleted","Tenant_RefID" });
				while(reader.Read())
				{
					L5SP_GTFFT_1030 resultItem = new L5SP_GTFFT_1030();
					//0:Parameter RES_TimeframeID of type Guid
					resultItem.RES_TimeframeID = reader.GetGuid(0);
					//1:Parameter Timeframe_Name of type Dict
					resultItem.Timeframe_Name = reader.GetDictionary(1);
					resultItem.Timeframe_Name.SourceTable = "res_timeframes";
					loader.Append(resultItem.Timeframe_Name);
					//2:Parameter Timeframe_Description of type Dict
					resultItem.Timeframe_Description = reader.GetDictionary(2);
					resultItem.Timeframe_Description.SourceTable = "res_timeframes";
					loader.Append(resultItem.Timeframe_Description);
					//3:Parameter Timeframe_SequenceNumber of type int
					resultItem.Timeframe_SequenceNumber = reader.GetInteger(3);
					//4:Parameter IsDeleted of type bool
					resultItem.IsDeleted = reader.GetBoolean(4);
					//5:Parameter Tenant_RefID of type Guid
					resultItem.Tenant_RefID = reader.GetGuid(5);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_TimeFrames_For_Tenant",ex);
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
		public static FR_L5SP_GTFFT_1030_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5SP_GTFFT_1030_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5SP_GTFFT_1030_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5SP_GTFFT_1030_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5SP_GTFFT_1030_Array functionReturn = new FR_L5SP_GTFFT_1030_Array();
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

				throw new Exception("Exception occured in method cls_Get_TimeFrames_For_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5SP_GTFFT_1030_Array : FR_Base
	{
		public L5SP_GTFFT_1030[] Result	{ get; set; } 
		public FR_L5SP_GTFFT_1030_Array() : base() {}

		public FR_L5SP_GTFFT_1030_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5SP_GTFFT_1030 for attribute L5SP_GTFFT_1030
		[DataContract]
		public class L5SP_GTFFT_1030 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_TimeframeID { get; set; } 
			[DataMember]
			public Dict Timeframe_Name { get; set; } 
			[DataMember]
			public Dict Timeframe_Description { get; set; } 
			[DataMember]
			public int Timeframe_SequenceNumber { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 
			[DataMember]
			public Guid Tenant_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5SP_GTFFT_1030_Array cls_Get_TimeFrames_For_Tenant(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5SP_GTFFT_1030_Array invocationResult = cls_Get_TimeFrames_For_Tenant.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/
