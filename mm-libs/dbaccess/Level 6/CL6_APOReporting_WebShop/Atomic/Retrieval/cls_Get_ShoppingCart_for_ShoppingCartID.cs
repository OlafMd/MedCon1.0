/* 
 * Generated on 6/23/2014 10:16:40 AM
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

namespace CL6_APOReporting_WebShop.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ShoppingCart_for_ShoppingCartID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ShoppingCart_for_ShoppingCartID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6WS_GSCfSCID_1448 Execute(DbConnection Connection,DbTransaction Transaction,P_L6WS_GSCfSCID_1448 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L6WS_GSCfSCID_1448();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL6_APOReporting_WebShop.Atomic.Retrieval.SQL.cls_Get_ShoppingCart_for_ShoppingCartID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ShoppingCartID", Parameter.ShoppingCartID);



			List<L6WS_GSCfSCID_1448> results = new List<L6WS_GSCfSCID_1448>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "ORD_PRC_ShoppingCartID","IsProcurementOrderCreated","Office_InternalName","Office_InternalNumber","ShoppingCartIdentifier" });
				while(reader.Read())
				{
					L6WS_GSCfSCID_1448 resultItem = new L6WS_GSCfSCID_1448();
					//0:Parameter ORD_PRC_ShoppingCartID of type Guid
					resultItem.ORD_PRC_ShoppingCartID = reader.GetGuid(0);
					//1:Parameter IsProcurementOrderCreated of type bool
					resultItem.IsProcurementOrderCreated = reader.GetBoolean(1);
					//2:Parameter Office_InternalName of type String
					resultItem.Office_InternalName = reader.GetString(2);
					//3:Parameter Office_InternalNumber of type String
					resultItem.Office_InternalNumber = reader.GetString(3);
					//4:Parameter ShoppingCartIdentifier of type String
					resultItem.ShoppingCartIdentifier = reader.GetString(4);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_ShoppingCart_for_ShoppingCartID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = results.FirstOrDefault();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6WS_GSCfSCID_1448 Invoke(string ConnectionString,P_L6WS_GSCfSCID_1448 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6WS_GSCfSCID_1448 Invoke(DbConnection Connection,P_L6WS_GSCfSCID_1448 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6WS_GSCfSCID_1448 Invoke(DbConnection Connection, DbTransaction Transaction,P_L6WS_GSCfSCID_1448 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6WS_GSCfSCID_1448 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6WS_GSCfSCID_1448 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6WS_GSCfSCID_1448 functionReturn = new FR_L6WS_GSCfSCID_1448();
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

				throw new Exception("Exception occured in method cls_Get_ShoppingCart_for_ShoppingCartID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6WS_GSCfSCID_1448 : FR_Base
	{
		public L6WS_GSCfSCID_1448 Result	{ get; set; }

		public FR_L6WS_GSCfSCID_1448() : base() {}

		public FR_L6WS_GSCfSCID_1448(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6WS_GSCfSCID_1448 for attribute P_L6WS_GSCfSCID_1448
		[DataContract]
		public class P_L6WS_GSCfSCID_1448 
		{
			//Standard type parameters
			[DataMember]
			public Guid ShoppingCartID { get; set; } 

		}
		#endregion
		#region SClass L6WS_GSCfSCID_1448 for attribute L6WS_GSCfSCID_1448
		[DataContract]
		public class L6WS_GSCfSCID_1448 
		{
			//Standard type parameters
			[DataMember]
			public Guid ORD_PRC_ShoppingCartID { get; set; } 
			[DataMember]
			public bool IsProcurementOrderCreated { get; set; } 
			[DataMember]
			public String Office_InternalName { get; set; } 
			[DataMember]
			public String Office_InternalNumber { get; set; } 
			[DataMember]
			public String ShoppingCartIdentifier { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6WS_GSCfSCID_1448 cls_Get_ShoppingCart_for_ShoppingCartID(,P_L6WS_GSCfSCID_1448 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6WS_GSCfSCID_1448 invocationResult = cls_Get_ShoppingCart_for_ShoppingCartID.Invoke(connectionString,P_L6WS_GSCfSCID_1448 Parameter,securityTicket);
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
var parameter = new CL6_APOReporting_WebShop.Atomic.Retrieval.P_L6WS_GSCfSCID_1448();
parameter.ShoppingCartID = ...;

*/
