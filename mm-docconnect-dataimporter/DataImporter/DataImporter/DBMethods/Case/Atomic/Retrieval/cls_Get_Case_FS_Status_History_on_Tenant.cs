/* 
 * Generated on 03/09/17 09:03:36
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

namespace DataImporter.DBMethods.Case.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Case_FS_Status_History_on_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Case_FS_Status_History_on_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_CAS_GCFSHoT_1347_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_CAS_GCFSHoT_1347_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "DataImporter.DBMethods.Case.Atomic.Retrieval.SQL.cls_Get_Case_FS_Status_History_on_Tenant.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<CAS_GCFSHoT_1347> results = new List<CAS_GCFSHoT_1347>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "IsActive","TransmitionCode","TransmitionStatusKey","TransmittedOnDate","CaseNumber","BIL_BillPosition_TransmitionStatusID","Ext_BIL_BillPosition_RefID","PotentialCode_RefID","IsTransmitionStatusManuallySet" });
				while(reader.Read())
				{
					CAS_GCFSHoT_1347 resultItem = new CAS_GCFSHoT_1347();
					//0:Parameter IsActive of type Boolean
					resultItem.IsActive = reader.GetBoolean(0);
					//1:Parameter TransmitionCode of type int
					resultItem.TransmitionCode = reader.GetInteger(1);
					//2:Parameter TransmitionStatusKey of type String
					resultItem.TransmitionStatusKey = reader.GetString(2);
					//3:Parameter TransmittedOnDate of type DateTime
					resultItem.TransmittedOnDate = reader.GetDate(3);
					//4:Parameter CaseNumber of type String
					resultItem.CaseNumber = reader.GetString(4);
					//5:Parameter BIL_BillPosition_TransmitionStatusID of type Guid
					resultItem.BIL_BillPosition_TransmitionStatusID = reader.GetGuid(5);
					//6:Parameter Ext_BIL_BillPosition_RefID of type Guid
					resultItem.Ext_BIL_BillPosition_RefID = reader.GetGuid(6);
					//7:Parameter PotentialCode_RefID of type Guid
					resultItem.PotentialCode_RefID = reader.GetGuid(7);
					//8:Parameter IsTransmitionStatusManuallySet of type Boolean
					resultItem.IsTransmitionStatusManuallySet = reader.GetBoolean(8);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Case_FS_Status_History_on_Tenant",ex);
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
		public static FR_CAS_GCFSHoT_1347_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_CAS_GCFSHoT_1347_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_CAS_GCFSHoT_1347_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_CAS_GCFSHoT_1347_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_CAS_GCFSHoT_1347_Array functionReturn = new FR_CAS_GCFSHoT_1347_Array();
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

				throw new Exception("Exception occured in method cls_Get_Case_FS_Status_History_on_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_CAS_GCFSHoT_1347_Array : FR_Base
	{
		public CAS_GCFSHoT_1347[] Result	{ get; set; } 
		public FR_CAS_GCFSHoT_1347_Array() : base() {}

		public FR_CAS_GCFSHoT_1347_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass CAS_GCFSHoT_1347 for attribute CAS_GCFSHoT_1347
		[DataContract]
		public class CAS_GCFSHoT_1347 
		{
			//Standard type parameters
			[DataMember]
			public Boolean IsActive { get; set; } 
			[DataMember]
			public int TransmitionCode { get; set; } 
			[DataMember]
			public String TransmitionStatusKey { get; set; } 
			[DataMember]
			public DateTime TransmittedOnDate { get; set; } 
			[DataMember]
			public String CaseNumber { get; set; } 
			[DataMember]
			public Guid BIL_BillPosition_TransmitionStatusID { get; set; } 
			[DataMember]
			public Guid Ext_BIL_BillPosition_RefID { get; set; } 
			[DataMember]
			public Guid PotentialCode_RefID { get; set; } 
			[DataMember]
			public Boolean IsTransmitionStatusManuallySet { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_CAS_GCFSHoT_1347_Array cls_Get_Case_FS_Status_History_on_Tenant(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_CAS_GCFSHoT_1347_Array invocationResult = cls_Get_Case_FS_Status_History_on_Tenant.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

