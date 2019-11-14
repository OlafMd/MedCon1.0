/* 
 * Generated on 10/22/2014 10:47:13 AM
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
    /// var result = cls_Get_ReceiptPositions_for_Article.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ReceiptPositions_for_Article
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5SR_GRPfA_1343_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5SR_GRPfA_1343 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5SR_GRPfA_1343_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOLogistic_StockReceipt.Atomic.Retrieval.SQL.cls_Get_ReceiptPositions_for_Article.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ProductID", Parameter.ProductID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"BatchNumber", Parameter.BatchNumber);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ExpirationDate", Parameter.ExpirationDate);



			List<L5SR_GRPfA_1343> results = new List<L5SR_GRPfA_1343>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "LOG_RCP_Receipt_PositionID","ReceiptNumber","SupplierId","Supplier","Creation_Timestamp","BatchNumber","ExpiryDate","InitialQuantity","CurrentQuantity","FreeQuantity","StockQuantity","ExpectedPositionPrice","LOG_WRH_Shelf_ContentID","LOG_ProductTrackingInstance_RefID" });
				while(reader.Read())
				{
					L5SR_GRPfA_1343 resultItem = new L5SR_GRPfA_1343();
					//0:Parameter LOG_RCP_Receipt_PositionID of type Guid
					resultItem.LOG_RCP_Receipt_PositionID = reader.GetGuid(0);
					//1:Parameter ReceiptNumber of type String
					resultItem.ReceiptNumber = reader.GetString(1);
					//2:Parameter SupplierId of type Guid
					resultItem.SupplierId = reader.GetGuid(2);
					//3:Parameter Supplier of type String
					resultItem.Supplier = reader.GetString(3);
					//4:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(4);
					//5:Parameter BatchNumber of type String
					resultItem.BatchNumber = reader.GetString(5);
					//6:Parameter ExpiryDate of type DateTime
					resultItem.ExpiryDate = reader.GetDate(6);
					//7:Parameter InitialQuantity of type double
					resultItem.InitialQuantity = reader.GetDouble(7);
					//8:Parameter CurrentQuantity of type double
					resultItem.CurrentQuantity = reader.GetDouble(8);
					//9:Parameter FreeQuantity of type double
					resultItem.FreeQuantity = reader.GetDouble(9);
					//10:Parameter StockQuantity of type double
					resultItem.StockQuantity = reader.GetDouble(10);
					//11:Parameter ExpectedPositionPrice of type Decimal
					resultItem.ExpectedPositionPrice = reader.GetDecimal(11);
					//12:Parameter LOG_WRH_Shelf_ContentID of type Guid
					resultItem.LOG_WRH_Shelf_ContentID = reader.GetGuid(12);
					//13:Parameter LOG_ProductTrackingInstance_RefID of type Guid
					resultItem.LOG_ProductTrackingInstance_RefID = reader.GetGuid(13);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_ReceiptPositions_for_Article",ex);
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
		public static FR_L5SR_GRPfA_1343_Array Invoke(string ConnectionString,P_L5SR_GRPfA_1343 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5SR_GRPfA_1343_Array Invoke(DbConnection Connection,P_L5SR_GRPfA_1343 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5SR_GRPfA_1343_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5SR_GRPfA_1343 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5SR_GRPfA_1343_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5SR_GRPfA_1343 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5SR_GRPfA_1343_Array functionReturn = new FR_L5SR_GRPfA_1343_Array();
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

				throw new Exception("Exception occured in method cls_Get_ReceiptPositions_for_Article",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5SR_GRPfA_1343_Array : FR_Base
	{
		public L5SR_GRPfA_1343[] Result	{ get; set; } 
		public FR_L5SR_GRPfA_1343_Array() : base() {}

		public FR_L5SR_GRPfA_1343_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5SR_GRPfA_1343 for attribute P_L5SR_GRPfA_1343
		[DataContract]
		public class P_L5SR_GRPfA_1343 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProductID { get; set; } 
			[DataMember]
			public String BatchNumber { get; set; } 
			[DataMember]
			public DateTime? ExpirationDate { get; set; } 

		}
		#endregion
		#region SClass L5SR_GRPfA_1343 for attribute L5SR_GRPfA_1343
		[DataContract]
		public class L5SR_GRPfA_1343 
		{
			//Standard type parameters
			[DataMember]
			public Guid LOG_RCP_Receipt_PositionID { get; set; } 
			[DataMember]
			public String ReceiptNumber { get; set; } 
			[DataMember]
			public Guid SupplierId { get; set; } 
			[DataMember]
			public String Supplier { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public String BatchNumber { get; set; } 
			[DataMember]
			public DateTime ExpiryDate { get; set; } 
			[DataMember]
			public double InitialQuantity { get; set; } 
			[DataMember]
			public double CurrentQuantity { get; set; } 
			[DataMember]
			public double FreeQuantity { get; set; } 
			[DataMember]
			public double StockQuantity { get; set; } 
			[DataMember]
			public Decimal ExpectedPositionPrice { get; set; } 
			[DataMember]
			public Guid LOG_WRH_Shelf_ContentID { get; set; } 
			[DataMember]
			public Guid LOG_ProductTrackingInstance_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5SR_GRPfA_1343_Array cls_Get_ReceiptPositions_for_Article(,P_L5SR_GRPfA_1343 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5SR_GRPfA_1343_Array invocationResult = cls_Get_ReceiptPositions_for_Article.Invoke(connectionString,P_L5SR_GRPfA_1343 Parameter,securityTicket);
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
var parameter = new CL5_APOLogistic_StockReceipt.Atomic.Retrieval.P_L5SR_GRPfA_1343();
parameter.ProductID = ...;
parameter.BatchNumber = ...;
parameter.ExpirationDate = ...;

*/
