/* 
 * Generated on 5/17/2014 5:47:44 PM
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
    /// var result = cls_Get_QualityControlItems_for_ReceiptPosition.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_QualityControlItems_for_ReceiptPosition
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5SR_GQCIfRP_1217_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5SR_GQCIfRP_1217 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5SR_GQCIfRP_1217_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOLogistic_StockReceipt.Atomic.Retrieval.SQL.cls_Get_QualityControlItems_for_ReceiptPosition.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ReceiptPositionID", Parameter.ReceiptPositionID);



			List<L5SR_GQCIfRP_1217> results = new List<L5SR_GQCIfRP_1217>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "LOG_RCP_Receipt_Position_QualityControlItem","Quantity","BatchNumber","ExpiryDate","IsStorage_BatchNumberMandatory","IsStorage_ExpiryDateMandatory" });
				while(reader.Read())
				{
					L5SR_GQCIfRP_1217 resultItem = new L5SR_GQCIfRP_1217();
					//0:Parameter LOG_RCP_Receipt_Position_QualityControlItem of type Guid
					resultItem.LOG_RCP_Receipt_Position_QualityControlItem = reader.GetGuid(0);
					//1:Parameter Quantity of type double
					resultItem.Quantity = reader.GetDouble(1);
					//2:Parameter BatchNumber of type String
					resultItem.BatchNumber = reader.GetString(2);
					//3:Parameter ExpiryDate of type DateTime
					resultItem.ExpiryDate = reader.GetDate(3);
					//4:Parameter IsStorage_BatchNumberMandatory of type Boolean
					resultItem.IsStorage_BatchNumberMandatory = reader.GetBoolean(4);
					//5:Parameter IsStorage_ExpiryDateMandatory of type Boolean
					resultItem.IsStorage_ExpiryDateMandatory = reader.GetBoolean(5);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_QualityControlItems_for_ReceiptPosition",ex);
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
		public static FR_L5SR_GQCIfRP_1217_Array Invoke(string ConnectionString,P_L5SR_GQCIfRP_1217 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5SR_GQCIfRP_1217_Array Invoke(DbConnection Connection,P_L5SR_GQCIfRP_1217 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5SR_GQCIfRP_1217_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5SR_GQCIfRP_1217 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5SR_GQCIfRP_1217_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5SR_GQCIfRP_1217 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5SR_GQCIfRP_1217_Array functionReturn = new FR_L5SR_GQCIfRP_1217_Array();
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

				throw new Exception("Exception occured in method cls_Get_QualityControlItems_for_ReceiptPosition",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5SR_GQCIfRP_1217_Array : FR_Base
	{
		public L5SR_GQCIfRP_1217[] Result	{ get; set; } 
		public FR_L5SR_GQCIfRP_1217_Array() : base() {}

		public FR_L5SR_GQCIfRP_1217_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5SR_GQCIfRP_1217 for attribute P_L5SR_GQCIfRP_1217
		[DataContract]
		public class P_L5SR_GQCIfRP_1217 
		{
			//Standard type parameters
			[DataMember]
			public Guid ReceiptPositionID { get; set; } 

		}
		#endregion
		#region SClass L5SR_GQCIfRP_1217 for attribute L5SR_GQCIfRP_1217
		[DataContract]
		public class L5SR_GQCIfRP_1217 
		{
			//Standard type parameters
			[DataMember]
			public Guid LOG_RCP_Receipt_Position_QualityControlItem { get; set; } 
			[DataMember]
			public double Quantity { get; set; } 
			[DataMember]
			public String BatchNumber { get; set; } 
			[DataMember]
			public DateTime ExpiryDate { get; set; } 
			[DataMember]
			public Boolean IsStorage_BatchNumberMandatory { get; set; } 
			[DataMember]
			public Boolean IsStorage_ExpiryDateMandatory { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5SR_GQCIfRP_1217_Array cls_Get_QualityControlItems_for_ReceiptPosition(,P_L5SR_GQCIfRP_1217 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5SR_GQCIfRP_1217_Array invocationResult = cls_Get_QualityControlItems_for_ReceiptPosition.Invoke(connectionString,P_L5SR_GQCIfRP_1217 Parameter,securityTicket);
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
var parameter = new CL5_APOLogistic_StockReceipt.Atomic.Retrieval.P_L5SR_GQCIfRP_1217();
parameter.ReceiptPositionID = ...;

*/
