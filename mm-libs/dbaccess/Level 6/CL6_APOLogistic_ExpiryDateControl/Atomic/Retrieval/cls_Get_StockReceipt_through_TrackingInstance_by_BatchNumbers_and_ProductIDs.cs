/* 
 * Generated on 8/27/2014 11:33:53 AM
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

namespace CL6_APOLogistic_ExpiryDateControl.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_StockReceipt_through_TrackingInstance_by_BatchNumbers_and_ProductIDs.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_StockReceipt_through_TrackingInstance_by_BatchNumbers_and_ProductIDs
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6ED_GSRtTIbBNaP_1353_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L6ED_GSRtTIbBNaP_1353 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L6ED_GSRtTIbBNaP_1353_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL6_APOLogistic_ExpiryDateControl.Atomic.Retrieval.SQL.cls_Get_StockReceipt_through_TrackingInstance_by_BatchNumbers_and_ProductIDs.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@ProductIDs"," IN $$ProductIDs$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$ProductIDs$",Parameter.ProductIDs);
			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@BatchNumbers"," IN $$BatchNumbers$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$BatchNumbers$",Parameter.BatchNumbers);


			List<L6ED_GSRtTIbBNaP_1353> results = new List<L6ED_GSRtTIbBNaP_1353>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "BatchNumber","SerialNumber","SupplierId","SupplierName","ReceiptPosition_Product_RefID","LOG_RCP_Receipt_PositionID","ReceiptQuantity","ExpectedPositionPrice" });
				while(reader.Read())
				{
					L6ED_GSRtTIbBNaP_1353 resultItem = new L6ED_GSRtTIbBNaP_1353();
					//0:Parameter BatchNumber of type String
					resultItem.BatchNumber = reader.GetString(0);
					//1:Parameter SerialNumber of type String
					resultItem.SerialNumber = reader.GetString(1);
					//2:Parameter SupplierId of type Guid
					resultItem.SupplierId = reader.GetGuid(2);
					//3:Parameter SupplierName of type String
					resultItem.SupplierName = reader.GetString(3);
					//4:Parameter ReceiptPosition_Product_RefID of type Guid
					resultItem.ReceiptPosition_Product_RefID = reader.GetGuid(4);
					//5:Parameter LOG_RCP_Receipt_PositionID of type Guid
					resultItem.LOG_RCP_Receipt_PositionID = reader.GetGuid(5);
					//6:Parameter ReceiptQuantity of type int
					resultItem.ReceiptQuantity = reader.GetInteger(6);
					//7:Parameter ExpectedPositionPrice of type decimal
					resultItem.ExpectedPositionPrice = reader.GetDecimal(7);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_StockReceipt_through_TrackingInstance_by_BatchNumbers_and_ProductIDs",ex);
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
		public static FR_L6ED_GSRtTIbBNaP_1353_Array Invoke(string ConnectionString,P_L6ED_GSRtTIbBNaP_1353 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6ED_GSRtTIbBNaP_1353_Array Invoke(DbConnection Connection,P_L6ED_GSRtTIbBNaP_1353 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6ED_GSRtTIbBNaP_1353_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L6ED_GSRtTIbBNaP_1353 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6ED_GSRtTIbBNaP_1353_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6ED_GSRtTIbBNaP_1353 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6ED_GSRtTIbBNaP_1353_Array functionReturn = new FR_L6ED_GSRtTIbBNaP_1353_Array();
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

				throw new Exception("Exception occured in method cls_Get_StockReceipt_through_TrackingInstance_by_BatchNumbers_and_ProductIDs",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6ED_GSRtTIbBNaP_1353_Array : FR_Base
	{
		public L6ED_GSRtTIbBNaP_1353[] Result	{ get; set; } 
		public FR_L6ED_GSRtTIbBNaP_1353_Array() : base() {}

		public FR_L6ED_GSRtTIbBNaP_1353_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6ED_GSRtTIbBNaP_1353 for attribute P_L6ED_GSRtTIbBNaP_1353
		[DataContract]
		public class P_L6ED_GSRtTIbBNaP_1353 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] ProductIDs { get; set; } 
			[DataMember]
			public String[] BatchNumbers { get; set; } 

		}
		#endregion
		#region SClass L6ED_GSRtTIbBNaP_1353 for attribute L6ED_GSRtTIbBNaP_1353
		[DataContract]
		public class L6ED_GSRtTIbBNaP_1353 
		{
			//Standard type parameters
			[DataMember]
			public String BatchNumber { get; set; } 
			[DataMember]
			public String SerialNumber { get; set; } 
			[DataMember]
			public Guid SupplierId { get; set; } 
			[DataMember]
			public String SupplierName { get; set; } 
			[DataMember]
			public Guid ReceiptPosition_Product_RefID { get; set; } 
			[DataMember]
			public Guid LOG_RCP_Receipt_PositionID { get; set; } 
			[DataMember]
			public int ReceiptQuantity { get; set; } 
			[DataMember]
			public decimal ExpectedPositionPrice { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6ED_GSRtTIbBNaP_1353_Array cls_Get_StockReceipt_through_TrackingInstance_by_BatchNumbers_and_ProductIDs(,P_L6ED_GSRtTIbBNaP_1353 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6ED_GSRtTIbBNaP_1353_Array invocationResult = cls_Get_StockReceipt_through_TrackingInstance_by_BatchNumbers_and_ProductIDs.Invoke(connectionString,P_L6ED_GSRtTIbBNaP_1353 Parameter,securityTicket);
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
var parameter = new CL6_APOLogistic_ExpiryDateControl.Atomic.Retrieval.P_L6ED_GSRtTIbBNaP_1353();
parameter.ProductIDs = ...;
parameter.BatchNumbers = ...;

*/
