/* 
 * Generated on 12/11/2014 05:42:57
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

namespace CL2_Catalog.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_CatalogProductGroup_for_ID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_CatalogProductGroup_for_ID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2CA_GCPGfID_1741_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L2CA_GCPGfID_1741 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2CA_GCPGfID_1741_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_Catalog.Atomic.Retrieval.SQL.cls_Get_CatalogProductGroup_for_ID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CatalogGroupID", Parameter.CatalogGroupID);



			List<L2CA_GCPGfID_1741> results = new List<L2CA_GCPGfID_1741>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_PRO_Catalog_ProductGroupID","Catalog_Revision_RefID","CatalogProductGroup_Name","CatalogProductGroup_Parent_RefID" });
				while(reader.Read())
				{
					L2CA_GCPGfID_1741 resultItem = new L2CA_GCPGfID_1741();
					//0:Parameter CMN_PRO_Catalog_ProductGroupID of type Guid
					resultItem.CMN_PRO_Catalog_ProductGroupID = reader.GetGuid(0);
					//1:Parameter Catalog_Revision_RefID of type Guid
					resultItem.Catalog_Revision_RefID = reader.GetGuid(1);
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
				throw new Exception("Exception occured durng data retrieval in method cls_Get_CatalogProductGroup_for_ID",ex);
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
		public static FR_L2CA_GCPGfID_1741_Array Invoke(string ConnectionString,P_L2CA_GCPGfID_1741 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2CA_GCPGfID_1741_Array Invoke(DbConnection Connection,P_L2CA_GCPGfID_1741 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2CA_GCPGfID_1741_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L2CA_GCPGfID_1741 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2CA_GCPGfID_1741_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2CA_GCPGfID_1741 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2CA_GCPGfID_1741_Array functionReturn = new FR_L2CA_GCPGfID_1741_Array();
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

				throw new Exception("Exception occured in method cls_Get_CatalogProductGroup_for_ID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2CA_GCPGfID_1741_Array : FR_Base
	{
		public L2CA_GCPGfID_1741[] Result	{ get; set; } 
		public FR_L2CA_GCPGfID_1741_Array() : base() {}

		public FR_L2CA_GCPGfID_1741_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L2CA_GCPGfID_1741 for attribute P_L2CA_GCPGfID_1741
		[DataContract]
		public class P_L2CA_GCPGfID_1741 
		{
			//Standard type parameters
			[DataMember]
			public Guid CatalogGroupID { get; set; } 

		}
		#endregion
		#region SClass L2CA_GCPGfID_1741 for attribute L2CA_GCPGfID_1741
		[DataContract]
		public class L2CA_GCPGfID_1741 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_Catalog_ProductGroupID { get; set; } 
			[DataMember]
			public Guid Catalog_Revision_RefID { get; set; } 
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
FR_L2CA_GCPGfID_1741_Array cls_Get_CatalogProductGroup_for_ID(,P_L2CA_GCPGfID_1741 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2CA_GCPGfID_1741_Array invocationResult = cls_Get_CatalogProductGroup_for_ID.Invoke(connectionString,P_L2CA_GCPGfID_1741 Parameter,securityTicket);
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
var parameter = new CL2_Catalog.Atomic.Retrieval.P_L2CA_GCPGfID_1741();
parameter.CatalogGroupID = ...;

*/
