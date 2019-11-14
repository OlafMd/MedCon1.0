/* 
 * Generated on 11/17/2014 9:43:10 AM
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

namespace CL5_Zugseil_Catalogs.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_All_Imported_Catalog_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_All_Imported_Catalog_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5CA_GAICfTID_0942_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5CA_GAICfTID_0942_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_Zugseil_Catalogs.Atomic.Retrieval.SQL.cls_Get_All_Imported_Catalog_for_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L5CA_GAICfTID_0942> results = new List<L5CA_GAICfTID_0942>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "ValidFrom","ValidTo","CatalogID","CatalogName","IsActive","IsCatalogPublic","SupplierName","CatalogITL" });
				while(reader.Read())
				{
					L5CA_GAICfTID_0942 resultItem = new L5CA_GAICfTID_0942();
					//0:Parameter ValidFrom of type DateTime
					resultItem.ValidFrom = reader.GetDate(0);
					//1:Parameter ValidTo of type DateTime
					resultItem.ValidTo = reader.GetDate(1);
					//2:Parameter CatalogID of type Guid
					resultItem.CatalogID = reader.GetGuid(2);
					//3:Parameter CatalogName of type String
					resultItem.CatalogName = reader.GetString(3);
					//4:Parameter IsActive of type bool
					resultItem.IsActive = reader.GetBoolean(4);
					//5:Parameter IsCatalogPublic of type bool
					resultItem.IsCatalogPublic = reader.GetBoolean(5);
					//6:Parameter SupplierName of type String
					resultItem.SupplierName = reader.GetString(6);
					//7:Parameter CatalogITL of type String
					resultItem.CatalogITL = reader.GetString(7);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_All_Imported_Catalog_for_TenantID",ex);
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
		public static FR_L5CA_GAICfTID_0942_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5CA_GAICfTID_0942_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5CA_GAICfTID_0942_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5CA_GAICfTID_0942_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5CA_GAICfTID_0942_Array functionReturn = new FR_L5CA_GAICfTID_0942_Array();
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

				throw new Exception("Exception occured in method cls_Get_All_Imported_Catalog_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5CA_GAICfTID_0942_Array : FR_Base
	{
		public L5CA_GAICfTID_0942[] Result	{ get; set; } 
		public FR_L5CA_GAICfTID_0942_Array() : base() {}

		public FR_L5CA_GAICfTID_0942_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5CA_GAICfTID_0942 for attribute L5CA_GAICfTID_0942
		[DataContract]
		public class L5CA_GAICfTID_0942 
		{
			//Standard type parameters
			[DataMember]
			public DateTime ValidFrom { get; set; } 
			[DataMember]
			public DateTime ValidTo { get; set; } 
			[DataMember]
			public Guid CatalogID { get; set; } 
			[DataMember]
			public String CatalogName { get; set; } 
			[DataMember]
			public bool IsActive { get; set; } 
			[DataMember]
			public bool IsCatalogPublic { get; set; } 
			[DataMember]
			public String SupplierName { get; set; } 
			[DataMember]
			public String CatalogITL { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5CA_GAICfTID_0942_Array cls_Get_All_Imported_Catalog_for_TenantID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5CA_GAICfTID_0942_Array invocationResult = cls_Get_All_Imported_Catalog_for_TenantID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

