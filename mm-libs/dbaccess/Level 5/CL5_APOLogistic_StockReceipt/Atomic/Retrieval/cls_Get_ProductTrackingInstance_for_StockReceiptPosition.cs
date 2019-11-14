/* 
 * Generated on 7/9/2014 2:05:30 PM
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

namespace CL5_APOLogistic_StockReceipt.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ProductTrackingInstance_for_StockReceiptPosition.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ProductTrackingInstance_for_StockReceiptPosition
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5SR_GPTIfSRP_1322 Execute(DbConnection Connection,DbTransaction Transaction,P_L5SR_GPTIfSRP_1322 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5SR_GPTIfSRP_1322();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOLogistic_StockReceipt.Atomic.Retrieval.SQL.cls_Get_ProductTrackingInstance_for_StockReceiptPosition.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ReceiptPositionsID", Parameter.ReceiptPositionsID);



			List<L5SR_GPTIfSRP_1322> results = new List<L5SR_GPTIfSRP_1322>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "LOG_RCP_Receipt_Position_RefID","LOG_ProductTrackingInstanceID","LOG_WRH_Shelf_ContentID" });
				while(reader.Read())
				{
					L5SR_GPTIfSRP_1322 resultItem = new L5SR_GPTIfSRP_1322();
					//0:Parameter LOG_RCP_Receipt_Position_RefID of type Guid
					resultItem.LOG_RCP_Receipt_Position_RefID = reader.GetGuid(0);
					//1:Parameter LOG_ProductTrackingInstanceID of type Guid
					resultItem.LOG_ProductTrackingInstanceID = reader.GetGuid(1);
					//2:Parameter LOG_WRH_Shelf_ContentID of type Guid
					resultItem.LOG_WRH_Shelf_ContentID = reader.GetGuid(2);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_ProductTrackingInstance_for_StockReceiptPosition",ex);
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
		public static FR_L5SR_GPTIfSRP_1322 Invoke(string ConnectionString,P_L5SR_GPTIfSRP_1322 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5SR_GPTIfSRP_1322 Invoke(DbConnection Connection,P_L5SR_GPTIfSRP_1322 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5SR_GPTIfSRP_1322 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5SR_GPTIfSRP_1322 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5SR_GPTIfSRP_1322 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5SR_GPTIfSRP_1322 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5SR_GPTIfSRP_1322 functionReturn = new FR_L5SR_GPTIfSRP_1322();
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

				throw new Exception("Exception occured in method cls_Get_ProductTrackingInstance_for_StockReceiptPosition",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5SR_GPTIfSRP_1322 : FR_Base
	{
		public L5SR_GPTIfSRP_1322 Result	{ get; set; }

		public FR_L5SR_GPTIfSRP_1322() : base() {}

		public FR_L5SR_GPTIfSRP_1322(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5SR_GPTIfSRP_1322 for attribute P_L5SR_GPTIfSRP_1322
		[DataContract]
		public class P_L5SR_GPTIfSRP_1322 
		{
			//Standard type parameters
			[DataMember]
			public Guid ReceiptPositionsID { get; set; } 

		}
		#endregion
		#region SClass L5SR_GPTIfSRP_1322 for attribute L5SR_GPTIfSRP_1322
		[DataContract]
		public class L5SR_GPTIfSRP_1322 
		{
			//Standard type parameters
			[DataMember]
			public Guid LOG_RCP_Receipt_Position_RefID { get; set; } 
			[DataMember]
			public Guid LOG_ProductTrackingInstanceID { get; set; } 
			[DataMember]
			public Guid LOG_WRH_Shelf_ContentID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5SR_GPTIfSRP_1322 cls_Get_ProductTrackingInstance_for_StockReceiptPosition(,P_L5SR_GPTIfSRP_1322 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5SR_GPTIfSRP_1322 invocationResult = cls_Get_ProductTrackingInstance_for_StockReceiptPosition.Invoke(connectionString,P_L5SR_GPTIfSRP_1322 Parameter,securityTicket);
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
var parameter = new CL5_APOLogistic_StockReceipt.Atomic.Retrieval.P_L5SR_GPTIfSRP_1322();
parameter.ReceiptPositionsID = ...;

*/
