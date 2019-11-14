/* 
 * Generated on 10/17/2014 2:53:21 PM
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

namespace CL2_BusinessTask.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_BusinessTask_for_GlobalPropertyMatchingID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_BusinessTask_for_GlobalPropertyMatchingID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2BT_GBTfGPM_1409 Execute(DbConnection Connection,DbTransaction Transaction,P_L2BT_GBTfGPM_1409 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2BT_GBTfGPM_1409();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_BusinessTask.Atomic.Retrieval.SQL.cls_Get_BusinessTask_for_GlobalPropertyMatchingID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"GlobalPropertyMatchingID", Parameter.GlobalPropertyMatchingID);



			List<L2BT_GBTfGPM_1409> results = new List<L2BT_GBTfGPM_1409>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "TMS_PRO_BusinessTask_StatusID","Label_DictID","IsPersistent" });
				while(reader.Read())
				{
					L2BT_GBTfGPM_1409 resultItem = new L2BT_GBTfGPM_1409();
					//0:Parameter TMS_PRO_BusinessTask_StatusID of type Guid
					resultItem.TMS_PRO_BusinessTask_StatusID = reader.GetGuid(0);
					//1:Parameter Label of type Dict
					resultItem.Label = reader.GetDictionary(1);
					resultItem.Label.SourceTable = "tms_pro_businesstask_status";
					loader.Append(resultItem.Label);
					//2:Parameter IsPersistent of type bool
					resultItem.IsPersistent = reader.GetBoolean(2);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_BusinessTask_for_GlobalPropertyMatchingID",ex);
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
		public static FR_L2BT_GBTfGPM_1409 Invoke(string ConnectionString,P_L2BT_GBTfGPM_1409 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2BT_GBTfGPM_1409 Invoke(DbConnection Connection,P_L2BT_GBTfGPM_1409 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2BT_GBTfGPM_1409 Invoke(DbConnection Connection, DbTransaction Transaction,P_L2BT_GBTfGPM_1409 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2BT_GBTfGPM_1409 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2BT_GBTfGPM_1409 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2BT_GBTfGPM_1409 functionReturn = new FR_L2BT_GBTfGPM_1409();
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

				throw new Exception("Exception occured in method cls_Get_BusinessTask_for_GlobalPropertyMatchingID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2BT_GBTfGPM_1409 : FR_Base
	{
		public L2BT_GBTfGPM_1409 Result	{ get; set; }

		public FR_L2BT_GBTfGPM_1409() : base() {}

		public FR_L2BT_GBTfGPM_1409(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L2BT_GBTfGPM_1409 for attribute P_L2BT_GBTfGPM_1409
		[DataContract]
		public class P_L2BT_GBTfGPM_1409 
		{
			//Standard type parameters
			[DataMember]
			public String GlobalPropertyMatchingID { get; set; } 

		}
		#endregion
		#region SClass L2BT_GBTfGPM_1409 for attribute L2BT_GBTfGPM_1409
		[DataContract]
		public class L2BT_GBTfGPM_1409 
		{
			//Standard type parameters
			[DataMember]
			public Guid TMS_PRO_BusinessTask_StatusID { get; set; } 
			[DataMember]
			public Dict Label { get; set; } 
			[DataMember]
			public bool IsPersistent { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2BT_GBTfGPM_1409 cls_Get_BusinessTask_for_GlobalPropertyMatchingID(,P_L2BT_GBTfGPM_1409 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2BT_GBTfGPM_1409 invocationResult = cls_Get_BusinessTask_for_GlobalPropertyMatchingID.Invoke(connectionString,P_L2BT_GBTfGPM_1409 Parameter,securityTicket);
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
var parameter = new CL2_BusinessTask.Atomic.Retrieval.P_L2BT_GBTfGPM_1409();
parameter.GlobalPropertyMatchingID = ...;

*/
