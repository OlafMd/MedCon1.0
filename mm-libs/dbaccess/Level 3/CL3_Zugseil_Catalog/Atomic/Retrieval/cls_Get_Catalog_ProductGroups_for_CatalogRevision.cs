/* 
 * Generated on 12/1/2014 06:35:24
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

namespace CL3_Zugseil_Catalog.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Catalog_ProductGroups_for_CatalogRevision.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Catalog_ProductGroups_for_CatalogRevision
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3CA_GCPGfCR_1427_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3CA_GCPGfCR_1427 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3CA_GCPGfCR_1427_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_Zugseil_Catalog.Atomic.Retrieval.SQL.cls_Get_Catalog_ProductGroups_for_CatalogRevision.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CatalogRevisionID", Parameter.CatalogRevisionID);



			List<L3CA_GCPGfCR_1427> results = new List<L3CA_GCPGfCR_1427>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "Catalog_Revision_RefID","CMN_PRO_Catalog_ProductGroupID","CatalogProductGroup_Name","CatalogProductGroup_Parent_RefID" });
				while(reader.Read())
				{
					L3CA_GCPGfCR_1427 resultItem = new L3CA_GCPGfCR_1427();
					//0:Parameter Catalog_Revision_RefID of type Guid
					resultItem.Catalog_Revision_RefID = reader.GetGuid(0);
					//1:Parameter CMN_PRO_Catalog_ProductGroupID of type Guid
					resultItem.CMN_PRO_Catalog_ProductGroupID = reader.GetGuid(1);
					//2:Parameter CatalogProductGroup_Name of type String
					resultItem.CatalogProductGroup_Name = reader.GetString(2);
					//3:Parameter CatalogProductGroup_Parent_RefID of type Guid
					resultItem.CatalogProductGroup_Parent_RefID = reader.GetGuid(3);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Catalog_ProductGroups_for_CatalogRevision",ex);
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
		public static FR_L3CA_GCPGfCR_1427_Array Invoke(string ConnectionString,P_L3CA_GCPGfCR_1427 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3CA_GCPGfCR_1427_Array Invoke(DbConnection Connection,P_L3CA_GCPGfCR_1427 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3CA_GCPGfCR_1427_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3CA_GCPGfCR_1427 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3CA_GCPGfCR_1427_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3CA_GCPGfCR_1427 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3CA_GCPGfCR_1427_Array functionReturn = new FR_L3CA_GCPGfCR_1427_Array();
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

				throw new Exception("Exception occured in method cls_Get_Catalog_ProductGroups_for_CatalogRevision",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3CA_GCPGfCR_1427_Array : FR_Base
	{
		public L3CA_GCPGfCR_1427[] Result	{ get; set; } 
		public FR_L3CA_GCPGfCR_1427_Array() : base() {}

		public FR_L3CA_GCPGfCR_1427_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3CA_GCPGfCR_1427 for attribute P_L3CA_GCPGfCR_1427
		[DataContract]
		public class P_L3CA_GCPGfCR_1427 
		{
			//Standard type parameters
			[DataMember]
			public Guid CatalogRevisionID { get; set; } 

		}
		#endregion
		#region SClass L3CA_GCPGfCR_1427 for attribute L3CA_GCPGfCR_1427
		[DataContract]
		public class L3CA_GCPGfCR_1427 
		{
			//Standard type parameters
			[DataMember]
			public Guid Catalog_Revision_RefID { get; set; } 
			[DataMember]
			public Guid CMN_PRO_Catalog_ProductGroupID { get; set; } 
			[DataMember]
			public String CatalogProductGroup_Name { get; set; } 
			[DataMember]
			public Guid CatalogProductGroup_Parent_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3CA_GCPGfCR_1427_Array cls_Get_Catalog_ProductGroups_for_CatalogRevision(,P_L3CA_GCPGfCR_1427 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3CA_GCPGfCR_1427_Array invocationResult = cls_Get_Catalog_ProductGroups_for_CatalogRevision.Invoke(connectionString,P_L3CA_GCPGfCR_1427 Parameter,securityTicket);
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
var parameter = new CL3_Zugseil_Catalog.Atomic.Retrieval.P_L3CA_GCPGfCR_1427();
parameter.CatalogRevisionID = ...;

*/
