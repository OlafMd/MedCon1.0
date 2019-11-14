/* 
 * Generated on 08/26/16 11:58:32
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

namespace MMDocConnectDBMethods.Case.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Case_Order_Data_for_OrderID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Case_Order_Data_for_OrderID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_CAS_GCODfOID_1156 Execute(DbConnection Connection,DbTransaction Transaction,P_CAS_GCODfOID_1156 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_CAS_GCODfOID_1156();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.Case.Atomic.Retrieval.SQL.cls_Get_Case_Order_Data_for_OrderID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"OrderID", Parameter.OrderID);



			List<CAS_GCODfOID_1156> results = new List<CAS_GCODfOID_1156>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "is_patient_fee_waived","is_label_only","order_modification_timestamp","alternative_delivery_date_from","alternative_delivery_date_to","delivery_date","order_comment","order_status_code" });
				while(reader.Read())
				{
					CAS_GCODfOID_1156 resultItem = new CAS_GCODfOID_1156();
					//0:Parameter is_patient_fee_waived of type Boolean
					resultItem.is_patient_fee_waived = reader.GetBoolean(0);
					//1:Parameter is_label_only of type Boolean
					resultItem.is_label_only = reader.GetBoolean(1);
					//2:Parameter order_modification_timestamp of type DateTime
					resultItem.order_modification_timestamp = reader.GetDate(2);
					//3:Parameter alternative_delivery_date_from of type DateTime
					resultItem.alternative_delivery_date_from = reader.GetDate(3);
					//4:Parameter alternative_delivery_date_to of type DateTime
					resultItem.alternative_delivery_date_to = reader.GetDate(4);
					//5:Parameter delivery_date of type DateTime
					resultItem.delivery_date = reader.GetDate(5);
					//6:Parameter order_comment of type String
					resultItem.order_comment = reader.GetString(6);
					//7:Parameter order_status_code of type int
					resultItem.order_status_code = reader.GetInteger(7);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Case_Order_Data_for_OrderID",ex);
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
		public static FR_CAS_GCODfOID_1156 Invoke(string ConnectionString,P_CAS_GCODfOID_1156 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_CAS_GCODfOID_1156 Invoke(DbConnection Connection,P_CAS_GCODfOID_1156 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_CAS_GCODfOID_1156 Invoke(DbConnection Connection, DbTransaction Transaction,P_CAS_GCODfOID_1156 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_CAS_GCODfOID_1156 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_CAS_GCODfOID_1156 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_CAS_GCODfOID_1156 functionReturn = new FR_CAS_GCODfOID_1156();
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

				throw new Exception("Exception occured in method cls_Get_Case_Order_Data_for_OrderID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_CAS_GCODfOID_1156 : FR_Base
	{
		public CAS_GCODfOID_1156 Result	{ get; set; }

		public FR_CAS_GCODfOID_1156() : base() {}

		public FR_CAS_GCODfOID_1156(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_CAS_GCODfOID_1156 for attribute P_CAS_GCODfOID_1156
		[DataContract]
		public class P_CAS_GCODfOID_1156 
		{
			//Standard type parameters
			[DataMember]
			public Guid OrderID { get; set; } 

		}
		#endregion
		#region SClass CAS_GCODfOID_1156 for attribute CAS_GCODfOID_1156
		[DataContract]
		public class CAS_GCODfOID_1156 
		{
			//Standard type parameters
			[DataMember]
			public Boolean is_patient_fee_waived { get; set; } 
			[DataMember]
			public Boolean is_label_only { get; set; } 
			[DataMember]
			public DateTime order_modification_timestamp { get; set; } 
			[DataMember]
			public DateTime alternative_delivery_date_from { get; set; } 
			[DataMember]
			public DateTime alternative_delivery_date_to { get; set; } 
			[DataMember]
			public DateTime delivery_date { get; set; } 
			[DataMember]
			public String order_comment { get; set; } 
			[DataMember]
			public int order_status_code { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_CAS_GCODfOID_1156 cls_Get_Case_Order_Data_for_OrderID(,P_CAS_GCODfOID_1156 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_CAS_GCODfOID_1156 invocationResult = cls_Get_Case_Order_Data_for_OrderID.Invoke(connectionString,P_CAS_GCODfOID_1156 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Case.Atomic.Retrieval.P_CAS_GCODfOID_1156();
parameter.OrderID = ...;

*/
