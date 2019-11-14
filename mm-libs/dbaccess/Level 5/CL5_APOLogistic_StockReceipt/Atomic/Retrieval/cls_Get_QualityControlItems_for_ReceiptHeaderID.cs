/* 
 * Generated on 9/19/2014 5:05:15 PM
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
    /// var result = cls_Get_QualityControlItems_for_ReceiptHeaderID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_QualityControlItems_for_ReceiptHeaderID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5SR_GQCIfRHId_1359_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5SR_GQCIfRHId_1359 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5SR_GQCIfRHId_1359_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOLogistic_StockReceipt.Atomic.Retrieval.SQL.cls_Get_QualityControlItems_for_ReceiptHeaderID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"HeaderID", Parameter.HeaderID);



			List<L5SR_GQCIfRHId_1359> results = new List<L5SR_GQCIfRHId_1359>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "LOG_RCP_Receipt_Position_QualityControlItem","Quantity","BatchNumber","ExpiryDate","Product_Name_DictID","Product_Number","LOG_WRH_ShelfID","CoordinateCodeArea","CoordinateCodeWarehouse","CoordinateCodeRack","CoordinateCodeShelf","LOG_RCP_Receipt_HeaderID","ProductID","ReceiptNumber" });
				while(reader.Read())
				{
					L5SR_GQCIfRHId_1359 resultItem = new L5SR_GQCIfRHId_1359();
					//0:Parameter LOG_RCP_Receipt_Position_QualityControlItem of type Guid
					resultItem.LOG_RCP_Receipt_Position_QualityControlItem = reader.GetGuid(0);
					//1:Parameter Quantity of type String
					resultItem.Quantity = reader.GetString(1);
					//2:Parameter BatchNumber of type String
					resultItem.BatchNumber = reader.GetString(2);
					//3:Parameter ExpiryDate of type DateTime
					resultItem.ExpiryDate = reader.GetDate(3);
					//4:Parameter Product_Name of type Dict
					resultItem.Product_Name = reader.GetDictionary(4);
					resultItem.Product_Name.SourceTable = "cmn_pro_products";
					loader.Append(resultItem.Product_Name);
					//5:Parameter Product_Number of type String
					resultItem.Product_Number = reader.GetString(5);
					//6:Parameter LOG_WRH_ShelfID of type Guid
					resultItem.LOG_WRH_ShelfID = reader.GetGuid(6);
					//7:Parameter CoordinateCodeArea of type String
					resultItem.CoordinateCodeArea = reader.GetString(7);
					//8:Parameter CoordinateCodeWarehouse of type String
					resultItem.CoordinateCodeWarehouse = reader.GetString(8);
					//9:Parameter CoordinateCodeRack of type String
					resultItem.CoordinateCodeRack = reader.GetString(9);
					//10:Parameter CoordinateCodeShelf of type String
					resultItem.CoordinateCodeShelf = reader.GetString(10);
					//11:Parameter LOG_RCP_Receipt_HeaderID of type Guid
					resultItem.LOG_RCP_Receipt_HeaderID = reader.GetGuid(11);
					//12:Parameter ProductID of type Guid
					resultItem.ProductID = reader.GetGuid(12);
					//13:Parameter ReceiptNumber of type String
					resultItem.ReceiptNumber = reader.GetString(13);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_QualityControlItems_for_ReceiptHeaderID",ex);
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
		public static FR_L5SR_GQCIfRHId_1359_Array Invoke(string ConnectionString,P_L5SR_GQCIfRHId_1359 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5SR_GQCIfRHId_1359_Array Invoke(DbConnection Connection,P_L5SR_GQCIfRHId_1359 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5SR_GQCIfRHId_1359_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5SR_GQCIfRHId_1359 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5SR_GQCIfRHId_1359_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5SR_GQCIfRHId_1359 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5SR_GQCIfRHId_1359_Array functionReturn = new FR_L5SR_GQCIfRHId_1359_Array();
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

				throw new Exception("Exception occured in method cls_Get_QualityControlItems_for_ReceiptHeaderID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5SR_GQCIfRHId_1359_Array : FR_Base
	{
		public L5SR_GQCIfRHId_1359[] Result	{ get; set; } 
		public FR_L5SR_GQCIfRHId_1359_Array() : base() {}

		public FR_L5SR_GQCIfRHId_1359_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5SR_GQCIfRHId_1359 for attribute P_L5SR_GQCIfRHId_1359
		[DataContract]
		public class P_L5SR_GQCIfRHId_1359 
		{
			//Standard type parameters
			[DataMember]
			public Guid HeaderID { get; set; } 

		}
		#endregion
		#region SClass L5SR_GQCIfRHId_1359 for attribute L5SR_GQCIfRHId_1359
		[DataContract]
		public class L5SR_GQCIfRHId_1359 
		{
			//Standard type parameters
			[DataMember]
			public Guid LOG_RCP_Receipt_Position_QualityControlItem { get; set; } 
			[DataMember]
			public String Quantity { get; set; } 
			[DataMember]
			public String BatchNumber { get; set; } 
			[DataMember]
			public DateTime ExpiryDate { get; set; } 
			[DataMember]
			public Dict Product_Name { get; set; } 
			[DataMember]
			public String Product_Number { get; set; } 
			[DataMember]
			public Guid LOG_WRH_ShelfID { get; set; } 
			[DataMember]
			public String CoordinateCodeArea { get; set; } 
			[DataMember]
			public String CoordinateCodeWarehouse { get; set; } 
			[DataMember]
			public String CoordinateCodeRack { get; set; } 
			[DataMember]
			public String CoordinateCodeShelf { get; set; } 
			[DataMember]
			public Guid LOG_RCP_Receipt_HeaderID { get; set; } 
			[DataMember]
			public Guid ProductID { get; set; } 
			[DataMember]
			public String ReceiptNumber { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5SR_GQCIfRHId_1359_Array cls_Get_QualityControlItems_for_ReceiptHeaderID(,P_L5SR_GQCIfRHId_1359 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5SR_GQCIfRHId_1359_Array invocationResult = cls_Get_QualityControlItems_for_ReceiptHeaderID.Invoke(connectionString,P_L5SR_GQCIfRHId_1359 Parameter,securityTicket);
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
var parameter = new CL5_APOLogistic_StockReceipt.Atomic.Retrieval.P_L5SR_GQCIfRHId_1359();
parameter.HeaderID = ...;

*/
