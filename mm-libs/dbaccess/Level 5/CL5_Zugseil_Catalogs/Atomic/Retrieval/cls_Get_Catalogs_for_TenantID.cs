/* 
 * Generated on 1/27/2015 11:14:59 AM
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
    /// var result = cls_Get_Catalogs_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Catalogs_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5CA_GCfT_1110_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5CA_GCfT_1110 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5CA_GCfT_1110_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_Zugseil_Catalogs.Atomic.Retrieval.SQL.cls_Get_Catalogs_for_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"LanguageID", Parameter.LanguageID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PageSize", Parameter.PageSize);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ActivePage", Parameter.ActivePage);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"SearchCriteria", Parameter.SearchCriteria);



			List<L5CA_GCfT_1110> results = new List<L5CA_GCfT_1110>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_PRO_CatalogID","Catalog_Currency_RefID","Catalog_Language_RefID","IsPublicCatalog","CatalogCodeITL","Catalog_Name_DictID" });
				while(reader.Read())
				{
					L5CA_GCfT_1110 resultItem = new L5CA_GCfT_1110();
					//0:Parameter CMN_PRO_CatalogID of type Guid
					resultItem.CMN_PRO_CatalogID = reader.GetGuid(0);
					//1:Parameter Catalog_Currency_RefID of type Guid
					resultItem.Catalog_Currency_RefID = reader.GetGuid(1);
					//2:Parameter Catalog_Language_RefID of type Guid
					resultItem.Catalog_Language_RefID = reader.GetGuid(2);
					//3:Parameter IsPublicCatalog of type bool
					resultItem.IsPublicCatalog = reader.GetBoolean(3);
					//4:Parameter CatalogCodeITL of type String
					resultItem.CatalogCodeITL = reader.GetString(4);
					//5:Parameter Catalog_Name of type Dict
					resultItem.Catalog_Name = reader.GetDictionary(5);
					resultItem.Catalog_Name.SourceTable = "cmn_pro_mastercatalogs";
					loader.Append(resultItem.Catalog_Name);

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
		public static FR_L5CA_GCfT_1110_Array Invoke(string ConnectionString,P_L5CA_GCfT_1110 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5CA_GCfT_1110_Array Invoke(DbConnection Connection,P_L5CA_GCfT_1110 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5CA_GCfT_1110_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5CA_GCfT_1110 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5CA_GCfT_1110_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5CA_GCfT_1110 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5CA_GCfT_1110_Array functionReturn = new FR_L5CA_GCfT_1110_Array();
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

				throw new Exception("Exception occured in method cls_Get_Catalogs_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5CA_GCfT_1110_Array : FR_Base
	{
		public L5CA_GCfT_1110[] Result	{ get; set; } 
		public FR_L5CA_GCfT_1110_Array() : base() {}

		public FR_L5CA_GCfT_1110_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5CA_GCfT_1110 for attribute P_L5CA_GCfT_1110
		[DataContract]
		public class P_L5CA_GCfT_1110 
		{
			//Standard type parameters
			[DataMember]
			public Guid LanguageID { get; set; } 
			[DataMember]
			public int PageSize { get; set; } 
			[DataMember]
			public int ActivePage { get; set; } 
			[DataMember]
			public String SearchCriteria { get; set; } 

		}
		#endregion
		#region SClass L5CA_GCfT_1110 for attribute L5CA_GCfT_1110
		[DataContract]
		public class L5CA_GCfT_1110 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_CatalogID { get; set; } 
			[DataMember]
			public Guid Catalog_Currency_RefID { get; set; } 
			[DataMember]
			public Guid Catalog_Language_RefID { get; set; } 
			[DataMember]
			public bool IsPublicCatalog { get; set; } 
			[DataMember]
			public String CatalogCodeITL { get; set; } 
			[DataMember]
			public Dict Catalog_Name { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5CA_GCfT_1110_Array cls_Get_Catalogs_for_TenantID(,P_L5CA_GCfT_1110 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5CA_GCfT_1110_Array invocationResult = cls_Get_Catalogs_for_TenantID.Invoke(connectionString,P_L5CA_GCfT_1110 Parameter,securityTicket);
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
var parameter = new CL5_Zugseil_Catalogs.Atomic.Retrieval.P_L5CA_GCfT_1110();
parameter.LanguageID = ...;
parameter.PageSize = ...;
parameter.ActivePage = ...;
parameter.SearchCriteria = ...;

*/
