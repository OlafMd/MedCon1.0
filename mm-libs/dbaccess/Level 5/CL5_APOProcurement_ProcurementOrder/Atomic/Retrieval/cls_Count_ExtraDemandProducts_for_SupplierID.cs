/* 
 * Generated on 31/7/2014 02:09:23
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

namespace CL5_APOProcurement_ProcurementOrder.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Count_ExtraDemandProducts_for_SupplierID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Count_ExtraDemandProducts_for_SupplierID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5PO_CEDPfS_1407_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5PO_CEDPfS_1407 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5PO_CEDPfS_1407_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOProcurement_ProcurementOrder.Atomic.Retrieval.SQL.cls_Count_ExtraDemandProducts_for_SupplierID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"SupplierID", Parameter.SupplierID);



			List<L5PO_CEDPfS_1407> results = new List<L5PO_CEDPfS_1407>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "numberOfPositions" });
				while(reader.Read())
				{
					L5PO_CEDPfS_1407 resultItem = new L5PO_CEDPfS_1407();
					//0:Parameter numberOfPositions of type int
					resultItem.numberOfPositions = reader.GetInteger(0);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Count_ExtraDemandProducts_for_SupplierID",ex);
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
		public static FR_L5PO_CEDPfS_1407_Array Invoke(string ConnectionString,P_L5PO_CEDPfS_1407 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5PO_CEDPfS_1407_Array Invoke(DbConnection Connection,P_L5PO_CEDPfS_1407 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5PO_CEDPfS_1407_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5PO_CEDPfS_1407 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5PO_CEDPfS_1407_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5PO_CEDPfS_1407 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5PO_CEDPfS_1407_Array functionReturn = new FR_L5PO_CEDPfS_1407_Array();
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

				throw new Exception("Exception occured in method cls_Count_ExtraDemandProducts_for_SupplierID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5PO_CEDPfS_1407_Array : FR_Base
	{
		public L5PO_CEDPfS_1407[] Result	{ get; set; } 
		public FR_L5PO_CEDPfS_1407_Array() : base() {}

		public FR_L5PO_CEDPfS_1407_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5PO_CEDPfS_1407 for attribute P_L5PO_CEDPfS_1407
		[DataContract]
		public class P_L5PO_CEDPfS_1407 
		{
			//Standard type parameters
			[DataMember]
			public Guid SupplierID { get; set; } 

		}
		#endregion
		#region SClass L5PO_CEDPfS_1407 for attribute L5PO_CEDPfS_1407
		[DataContract]
		public class L5PO_CEDPfS_1407 
		{
			//Standard type parameters
			[DataMember]
			public int numberOfPositions { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5PO_CEDPfS_1407_Array cls_Count_ExtraDemandProducts_for_SupplierID(,P_L5PO_CEDPfS_1407 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5PO_CEDPfS_1407_Array invocationResult = cls_Count_ExtraDemandProducts_for_SupplierID.Invoke(connectionString,P_L5PO_CEDPfS_1407 Parameter,securityTicket);
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
var parameter = new CL5_APOProcurement_ProcurementOrder.Atomic.Retrieval.P_L5PO_CEDPfS_1407();
parameter.SupplierID = ...;

*/
