/* 
 * Generated on 17/4/2014 02:44:49
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
using System.Runtime.Serialization;

namespace CL3_Supplier.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Supplier_for_TenantITL.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Supplier_for_TenantITL
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3SP_GSfT_1241 Execute(DbConnection Connection,DbTransaction Transaction,P_L3SP_GSfT_1241 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3SP_GSfT_1241();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_Supplier.Atomic.Retrieval.SQL.cls_Get_Supplier_for_TenantITL.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"TenantITL", Parameter.TenantITL);



			List<L3SP_GSfT_1241> results = new List<L3SP_GSfT_1241>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_BPT_SupplierID" });
				while(reader.Read())
				{
					L3SP_GSfT_1241 resultItem = new L3SP_GSfT_1241();
					//0:Parameter CMN_BPT_SupplierID of type Guid
					resultItem.CMN_BPT_SupplierID = reader.GetGuid(0);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Supplier_for_TenantITL",ex);
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
		public static FR_L3SP_GSfT_1241 Invoke(string ConnectionString,P_L3SP_GSfT_1241 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3SP_GSfT_1241 Invoke(DbConnection Connection,P_L3SP_GSfT_1241 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3SP_GSfT_1241 Invoke(DbConnection Connection, DbTransaction Transaction,P_L3SP_GSfT_1241 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3SP_GSfT_1241 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3SP_GSfT_1241 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3SP_GSfT_1241 functionReturn = new FR_L3SP_GSfT_1241();
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

				throw new Exception("Exception occured in method cls_Get_Supplier_for_TenantITL",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3SP_GSfT_1241 : FR_Base
	{
		public L3SP_GSfT_1241 Result	{ get; set; }

		public FR_L3SP_GSfT_1241() : base() {}

		public FR_L3SP_GSfT_1241(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3SP_GSfT_1241 for attribute P_L3SP_GSfT_1241
		[DataContract]
		public class P_L3SP_GSfT_1241 
		{
			//Standard type parameters
			[DataMember]
			public string TenantITL { get; set; } 

		}
		#endregion
		#region SClass L3SP_GSfT_1241 for attribute L3SP_GSfT_1241
		[DataContract]
		public class L3SP_GSfT_1241 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_BPT_SupplierID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3SP_GSfT_1241 cls_Get_Supplier_for_TenantITL(,P_L3SP_GSfT_1241 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3SP_GSfT_1241 invocationResult = cls_Get_Supplier_for_TenantITL.Invoke(connectionString,P_L3SP_GSfT_1241 Parameter,securityTicket);
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
var parameter = new CL3_Supplier.Atomic.Retrieval.P_L3SP_GSfT_1241();
parameter.TenantITL = ...;

*/
