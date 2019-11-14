/* 
 * Generated on 3/12/2014 2:39:28 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 * Required Assemblies:
 * System.Runtime.Serialization
 * CSV2Core
 * CSV2Core_MySQL
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using System.Runtime.Serialization;

namespace CL3_APOCatalog.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Catalogs_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Catalogs_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3CA_GCfTID_1608_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3CA_GCfTID_1608_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_APOCatalog.Atomic.Retrieval.SQL.cls_Get_Catalogs_for_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L3CA_GCfTID_1608> results = new List<L3CA_GCfTID_1608>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CatalogID","CatalogCodeITL","IsPublicCatalog","Catalog_Language_RefID","Catalog_Currency_RefID" });
				while(reader.Read())
				{
					L3CA_GCfTID_1608 resultItem = new L3CA_GCfTID_1608();
					//0:Parameter CatalogID of type Guid
					resultItem.CatalogID = reader.GetGuid(0);
					//1:Parameter CatalogCodeITL of type String
					resultItem.CatalogCodeITL = reader.GetString(1);
					//2:Parameter IsPublicCatalog of type bool
					resultItem.IsPublicCatalog = reader.GetBoolean(2);
					//3:Parameter Catalog_Language_RefID of type Guid
					resultItem.Catalog_Language_RefID = reader.GetGuid(3);
					//4:Parameter Catalog_Currency_RefID of type Guid
					resultItem.Catalog_Currency_RefID = reader.GetGuid(4);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Catalogs_for_TenantID",ex);
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
		public static FR_L3CA_GCfTID_1608_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3CA_GCfTID_1608_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3CA_GCfTID_1608_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3CA_GCfTID_1608_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3CA_GCfTID_1608_Array functionReturn = new FR_L3CA_GCfTID_1608_Array();
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

				throw new Exception("Exception occured in method cls_Get_Catalogs_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3CA_GCfTID_1608_Array : FR_Base
	{
		public L3CA_GCfTID_1608[] Result	{ get; set; } 
		public FR_L3CA_GCfTID_1608_Array() : base() {}

		public FR_L3CA_GCfTID_1608_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L3CA_GCfTID_1608 for attribute L3CA_GCfTID_1608
		[DataContract]
		public class L3CA_GCfTID_1608 
		{
			//Standard type parameters
			[DataMember]
			public Guid CatalogID { get; set; } 
			[DataMember]
			public String CatalogCodeITL { get; set; } 
			[DataMember]
			public bool IsPublicCatalog { get; set; } 
			[DataMember]
			public Guid Catalog_Language_RefID { get; set; } 
			[DataMember]
			public Guid Catalog_Currency_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3CA_GCfTID_1608_Array cls_Get_Catalogs_for_TenantID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3CA_GCfTID_1608_Array invocationResult = cls_Get_Catalogs_for_TenantID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

