/* 
 * Generated on 4/10/2017 1:36:49 PM
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

namespace DataImporter.DBMethods.Order.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_all_orders.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_all_orders
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_OR_GOwS_1428_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_OR_GOwS_1428_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "DataImporter.DBMethods.Order.Atomic.Retrieval.SQL.cls_Get_all_orders.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<OR_GOwS_1428> results = new List<OR_GOwS_1428>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "StatusID","CaseID","OrderID","StatusCode","OrderNumber","OrderCreationTimestamp","RequestedDateOfDelivery_TimeFrame_From","RequestedDateOfDelivery_TimeFrame_To","Position_RequestedDateOfDelivery","Treatment_Date" });
				while(reader.Read())
				{
					OR_GOwS_1428 resultItem = new OR_GOwS_1428();
					//0:Parameter StatusID of type Guid
					resultItem.StatusID = reader.GetGuid(0);
					//1:Parameter CaseID of type Guid
					resultItem.CaseID = reader.GetGuid(1);
					//2:Parameter OrderID of type Guid
					resultItem.OrderID = reader.GetGuid(2);
					//3:Parameter StatusCode of type Double
					resultItem.StatusCode = reader.GetDouble(3);
					//4:Parameter OrderNumber of type Double
					resultItem.OrderNumber = reader.GetDouble(4);
					//5:Parameter OrderCreationTimestamp of type DateTime
					resultItem.OrderCreationTimestamp = reader.GetDate(5);
					//6:Parameter RequestedDateOfDelivery_TimeFrame_From of type DateTime
					resultItem.RequestedDateOfDelivery_TimeFrame_From = reader.GetDate(6);
					//7:Parameter RequestedDateOfDelivery_TimeFrame_To of type DateTime
					resultItem.RequestedDateOfDelivery_TimeFrame_To = reader.GetDate(7);
					//8:Parameter Position_RequestedDateOfDelivery of type DateTime
					resultItem.Position_RequestedDateOfDelivery = reader.GetDate(8);
					//9:Parameter Treatment_Date of type DateTime
					resultItem.Treatment_Date = reader.GetDate(9);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_all_orders",ex);
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
		public static FR_OR_GOwS_1428_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_OR_GOwS_1428_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_OR_GOwS_1428_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_OR_GOwS_1428_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_OR_GOwS_1428_Array functionReturn = new FR_OR_GOwS_1428_Array();
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

				functionReturn = Execute(Connection, Transaction,securityTicket);

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

				throw new Exception("Exception occured in method cls_Get_all_orders",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_OR_GOwS_1428_Array : FR_Base
	{
		public OR_GOwS_1428[] Result	{ get; set; } 
		public FR_OR_GOwS_1428_Array() : base() {}

		public FR_OR_GOwS_1428_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass OR_GOwS_1428 for attribute OR_GOwS_1428
		[DataContract]
		public class OR_GOwS_1428 
		{
			//Standard type parameters
			[DataMember]
			public Guid StatusID { get; set; } 
			[DataMember]
			public Guid CaseID { get; set; } 
			[DataMember]
			public Guid OrderID { get; set; } 
			[DataMember]
			public Double StatusCode { get; set; } 
			[DataMember]
			public Double OrderNumber { get; set; } 
			[DataMember]
			public DateTime OrderCreationTimestamp { get; set; } 
			[DataMember]
			public DateTime RequestedDateOfDelivery_TimeFrame_From { get; set; } 
			[DataMember]
			public DateTime RequestedDateOfDelivery_TimeFrame_To { get; set; } 
			[DataMember]
			public DateTime Position_RequestedDateOfDelivery { get; set; } 
			[DataMember]
			public DateTime Treatment_Date { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_OR_GOwS_1428_Array cls_Get_all_orders(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_OR_GOwS_1428_Array invocationResult = cls_Get_all_orders.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

