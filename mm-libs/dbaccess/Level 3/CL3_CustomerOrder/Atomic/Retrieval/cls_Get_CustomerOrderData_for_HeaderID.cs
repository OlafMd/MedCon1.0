/* 
 * Generated on 08/27/2014 09:43:53
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

namespace CL3_CustomerOrder.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_CustomerOrderData_for_HeaderID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_CustomerOrderData_for_HeaderID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_CL3_GCODfH_1537 Execute(DbConnection Connection,DbTransaction Transaction,P_CL3_GCODfH_1537 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_CL3_GCODfH_1537();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_CustomerOrder.Atomic.Retrieval.SQL.cls_Get_CustomerOrderData_for_HeaderID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CustomerOrderHeaderID", Parameter.CustomerOrderHeaderID);



			List<CL3_GCODfH_1537> results = new List<CL3_GCODfH_1537>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "ORD_CUO_CustomerOrder_HeaderID","CustomerOrder_Number","CustomerOrder_Date","CustomerId","CustomerName","Warehouse_Name","DeliveryDeadline","Creation_Timestamp" });
				while(reader.Read())
				{
					CL3_GCODfH_1537 resultItem = new CL3_GCODfH_1537();
					//0:Parameter ORD_CUO_CustomerOrder_HeaderID of type Guid
					resultItem.ORD_CUO_CustomerOrder_HeaderID = reader.GetGuid(0);
					//1:Parameter CustomerOrder_Number of type String
					resultItem.CustomerOrder_Number = reader.GetString(1);
					//2:Parameter CustomerOrder_Date of type DateTime
					resultItem.CustomerOrder_Date = reader.GetDate(2);
					//3:Parameter CustomerId of type Guid
					resultItem.CustomerId = reader.GetGuid(3);
					//4:Parameter CustomerName of type String
					resultItem.CustomerName = reader.GetString(4);
					//5:Parameter Warehouse_Name of type String
					resultItem.Warehouse_Name = reader.GetString(5);
					//6:Parameter DeliveryDeadline of type DateTime
					resultItem.DeliveryDeadline = reader.GetDate(6);
					//7:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(7);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_CustomerOrderData_for_HeaderID",ex);
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
		public static FR_CL3_GCODfH_1537 Invoke(string ConnectionString,P_CL3_GCODfH_1537 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_CL3_GCODfH_1537 Invoke(DbConnection Connection,P_CL3_GCODfH_1537 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_CL3_GCODfH_1537 Invoke(DbConnection Connection, DbTransaction Transaction,P_CL3_GCODfH_1537 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_CL3_GCODfH_1537 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_CL3_GCODfH_1537 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_CL3_GCODfH_1537 functionReturn = new FR_CL3_GCODfH_1537();
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

				throw new Exception("Exception occured in method cls_Get_CustomerOrderData_for_HeaderID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_CL3_GCODfH_1537 : FR_Base
	{
		public CL3_GCODfH_1537 Result	{ get; set; }

		public FR_CL3_GCODfH_1537() : base() {}

		public FR_CL3_GCODfH_1537(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_CL3_GCODfH_1537 for attribute P_CL3_GCODfH_1537
		[DataContract]
		public class P_CL3_GCODfH_1537 
		{
			//Standard type parameters
			[DataMember]
			public Guid CustomerOrderHeaderID { get; set; } 

		}
		#endregion
		#region SClass CL3_GCODfH_1537 for attribute CL3_GCODfH_1537
		[DataContract]
		public class CL3_GCODfH_1537 
		{
			//Standard type parameters
			[DataMember]
			public Guid ORD_CUO_CustomerOrder_HeaderID { get; set; } 
			[DataMember]
			public String CustomerOrder_Number { get; set; } 
			[DataMember]
			public DateTime CustomerOrder_Date { get; set; } 
			[DataMember]
			public Guid CustomerId { get; set; } 
			[DataMember]
			public String CustomerName { get; set; } 
			[DataMember]
			public String Warehouse_Name { get; set; } 
			[DataMember]
			public DateTime DeliveryDeadline { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_CL3_GCODfH_1537 cls_Get_CustomerOrderData_for_HeaderID(,P_CL3_GCODfH_1537 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_CL3_GCODfH_1537 invocationResult = cls_Get_CustomerOrderData_for_HeaderID.Invoke(connectionString,P_CL3_GCODfH_1537 Parameter,securityTicket);
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
var parameter = new CL3_CustomerOrder.Atomic.Retrieval.P_CL3_GCODfH_1537();
parameter.CustomerOrderHeaderID = ...;

*/
