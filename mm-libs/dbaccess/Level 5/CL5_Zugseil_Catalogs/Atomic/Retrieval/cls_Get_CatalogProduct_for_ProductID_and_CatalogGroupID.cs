/* 
 * Generated on 11/20/2014 05:00:03
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
    /// var result = cls_Get_CatalogProduct_for_ProductID_and_CatalogGroupID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_CatalogProduct_for_ProductID_and_CatalogGroupID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5CA_GCPfPaCG_1653_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5CA_GCPfPaCG_1653 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5CA_GCPfPaCG_1653_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_Zugseil_Catalogs.Atomic.Retrieval.SQL.cls_Get_CatalogProduct_for_ProductID_and_CatalogGroupID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ProductID", Parameter.ProductID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CatalogGroupID", Parameter.CatalogGroupID);



			List<L5CA_GCPfPaCG_1653> results = new List<L5CA_GCPfPaCG_1653>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_PRO_Catalog_ProductID","CMN_PRO_Product_RefID" });
				while(reader.Read())
				{
					L5CA_GCPfPaCG_1653 resultItem = new L5CA_GCPfPaCG_1653();
					//0:Parameter CMN_PRO_Catalog_ProductID of type Guid
					resultItem.CMN_PRO_Catalog_ProductID = reader.GetGuid(0);
					//1:Parameter CMN_PRO_Product_RefID of type Guid
					resultItem.CMN_PRO_Product_RefID = reader.GetGuid(1);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_CatalogProduct_for_ProductID_and_CatalogGroupID",ex);
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
		public static FR_L5CA_GCPfPaCG_1653_Array Invoke(string ConnectionString,P_L5CA_GCPfPaCG_1653 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5CA_GCPfPaCG_1653_Array Invoke(DbConnection Connection,P_L5CA_GCPfPaCG_1653 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5CA_GCPfPaCG_1653_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5CA_GCPfPaCG_1653 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5CA_GCPfPaCG_1653_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5CA_GCPfPaCG_1653 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5CA_GCPfPaCG_1653_Array functionReturn = new FR_L5CA_GCPfPaCG_1653_Array();
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

				throw new Exception("Exception occured in method cls_Get_CatalogProduct_for_ProductID_and_CatalogGroupID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5CA_GCPfPaCG_1653_Array : FR_Base
	{
		public L5CA_GCPfPaCG_1653[] Result	{ get; set; } 
		public FR_L5CA_GCPfPaCG_1653_Array() : base() {}

		public FR_L5CA_GCPfPaCG_1653_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5CA_GCPfPaCG_1653 for attribute P_L5CA_GCPfPaCG_1653
		[DataContract]
		public class P_L5CA_GCPfPaCG_1653 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProductID { get; set; } 
			[DataMember]
			public Guid CatalogGroupID { get; set; } 

		}
		#endregion
		#region SClass L5CA_GCPfPaCG_1653 for attribute L5CA_GCPfPaCG_1653
		[DataContract]
		public class L5CA_GCPfPaCG_1653 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_Catalog_ProductID { get; set; } 
			[DataMember]
			public Guid CMN_PRO_Product_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5CA_GCPfPaCG_1653_Array cls_Get_CatalogProduct_for_ProductID_and_CatalogGroupID(,P_L5CA_GCPfPaCG_1653 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5CA_GCPfPaCG_1653_Array invocationResult = cls_Get_CatalogProduct_for_ProductID_and_CatalogGroupID.Invoke(connectionString,P_L5CA_GCPfPaCG_1653 Parameter,securityTicket);
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
var parameter = new CL5_Zugseil_Catalogs.Atomic.Retrieval.P_L5CA_GCPfPaCG_1653();
parameter.ProductID = ...;
parameter.CatalogGroupID = ...;

*/
