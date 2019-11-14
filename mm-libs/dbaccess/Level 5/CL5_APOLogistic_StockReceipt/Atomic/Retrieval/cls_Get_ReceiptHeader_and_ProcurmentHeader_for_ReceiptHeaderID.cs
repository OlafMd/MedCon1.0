/* 
 * Generated on 3/6/2014 5:15:57 PM
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
    /// var result = cls_Get_ReceiptHeader_and_ProcurmentHeader_for_ReceiptHeaderID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ReceiptHeader_and_ProcurmentHeader_for_ReceiptHeaderID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5SR_GRaPHfRH_1636 Execute(DbConnection Connection,DbTransaction Transaction,P_L5SR_GRaPHfRH_1636 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5SR_GRaPHfRH_1636();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOLogistic_StockReceipt.Atomic.Retrieval.SQL.cls_Get_ReceiptHeader_and_ProcurmentHeader_for_ReceiptHeaderID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ReceiptHeaderID", Parameter.ReceiptHeaderID);



			List<L5SR_GRaPHfRH_1636> results = new List<L5SR_GRaPHfRH_1636>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "LOG_RCP_Receipt_HeaderID","QualityControlPerformed_AtDate","TakenIntoStock_AtDate","ProcurementOrder_Number","IsTakenIntoStock","IsPriceConditionsManuallyCleared","IsReceiptForwardedToBookkeeping","IsQualityControlPerformed","ReceiptNumber","ProvidingSupplier_RefID","PriceConditionsManuallyCleared_ByAccount_RefID","PriceConditionsManuallyCleared_AtDate","TakenIntoStock_ByAccount_RefID","ReceiptForwardedToBookkeeping_ByAccount_RefID","ReceiptForwardedToBookkeeping_AtDate","QualityControlPerformed_ByAccount_RefID" });
				while(reader.Read())
				{
					L5SR_GRaPHfRH_1636 resultItem = new L5SR_GRaPHfRH_1636();
					//0:Parameter LOG_RCP_Receipt_HeaderID of type Guid
					resultItem.LOG_RCP_Receipt_HeaderID = reader.GetGuid(0);
					//1:Parameter QualityControlPerformed_AtDate of type DateTime
					resultItem.QualityControlPerformed_AtDate = reader.GetDate(1);
					//2:Parameter TakenIntoStock_AtDate of type DateTime
					resultItem.TakenIntoStock_AtDate = reader.GetDate(2);
					//3:Parameter ProcurementOrder_Number of type String
					resultItem.ProcurementOrder_Number = reader.GetString(3);
					//4:Parameter IsTakenIntoStock of type bool
					resultItem.IsTakenIntoStock = reader.GetBoolean(4);
					//5:Parameter IsPriceConditionsManuallyCleared of type bool
					resultItem.IsPriceConditionsManuallyCleared = reader.GetBoolean(5);
					//6:Parameter IsReceiptForwardedToBookkeeping of type bool
					resultItem.IsReceiptForwardedToBookkeeping = reader.GetBoolean(6);
					//7:Parameter IsQualityControlPerformed of type bool
					resultItem.IsQualityControlPerformed = reader.GetBoolean(7);
					//8:Parameter ReceiptNumber of type String
					resultItem.ReceiptNumber = reader.GetString(8);
					//9:Parameter ProvidingSupplier_RefID of type Guid
					resultItem.ProvidingSupplier_RefID = reader.GetGuid(9);
					//10:Parameter PriceConditionsManuallyCleared_ByAccount_RefID of type Guid
					resultItem.PriceConditionsManuallyCleared_ByAccount_RefID = reader.GetGuid(10);
					//11:Parameter PriceConditionsManuallyCleared_AtDate of type DateTime
					resultItem.PriceConditionsManuallyCleared_AtDate = reader.GetDate(11);
					//12:Parameter TakenIntoStock_ByAccount_RefID of type Guid
					resultItem.TakenIntoStock_ByAccount_RefID = reader.GetGuid(12);
					//13:Parameter ReceiptForwardedToBookkeeping_ByAccount_RefID of type Guid
					resultItem.ReceiptForwardedToBookkeeping_ByAccount_RefID = reader.GetGuid(13);
					//14:Parameter ReceiptForwardedToBookkeeping_AtDate of type DateTime
					resultItem.ReceiptForwardedToBookkeeping_AtDate = reader.GetDate(14);
					//15:Parameter QualityControlPerformed_ByAccount_RefID of type Guid
					resultItem.QualityControlPerformed_ByAccount_RefID = reader.GetGuid(15);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_ReceiptHeader_and_ProcurmentHeader_for_ReceiptHeaderID",ex);
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
		public static FR_L5SR_GRaPHfRH_1636 Invoke(string ConnectionString,P_L5SR_GRaPHfRH_1636 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5SR_GRaPHfRH_1636 Invoke(DbConnection Connection,P_L5SR_GRaPHfRH_1636 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5SR_GRaPHfRH_1636 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5SR_GRaPHfRH_1636 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5SR_GRaPHfRH_1636 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5SR_GRaPHfRH_1636 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5SR_GRaPHfRH_1636 functionReturn = new FR_L5SR_GRaPHfRH_1636();
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

				throw new Exception("Exception occured in method cls_Get_ReceiptHeader_and_ProcurmentHeader_for_ReceiptHeaderID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5SR_GRaPHfRH_1636 : FR_Base
	{
		public L5SR_GRaPHfRH_1636 Result	{ get; set; }

		public FR_L5SR_GRaPHfRH_1636() : base() {}

		public FR_L5SR_GRaPHfRH_1636(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5SR_GRaPHfRH_1636 for attribute P_L5SR_GRaPHfRH_1636
		[DataContract]
		public class P_L5SR_GRaPHfRH_1636 
		{
			//Standard type parameters
			[DataMember]
			public Guid ReceiptHeaderID { get; set; } 

		}
		#endregion
		#region SClass L5SR_GRaPHfRH_1636 for attribute L5SR_GRaPHfRH_1636
		[DataContract]
		public class L5SR_GRaPHfRH_1636 
		{
			//Standard type parameters
			[DataMember]
			public Guid LOG_RCP_Receipt_HeaderID { get; set; } 
			[DataMember]
			public DateTime QualityControlPerformed_AtDate { get; set; } 
			[DataMember]
			public DateTime TakenIntoStock_AtDate { get; set; } 
			[DataMember]
			public String ProcurementOrder_Number { get; set; } 
			[DataMember]
			public bool IsTakenIntoStock { get; set; } 
			[DataMember]
			public bool IsPriceConditionsManuallyCleared { get; set; } 
			[DataMember]
			public bool IsReceiptForwardedToBookkeeping { get; set; } 
			[DataMember]
			public bool IsQualityControlPerformed { get; set; } 
			[DataMember]
			public String ReceiptNumber { get; set; } 
			[DataMember]
			public Guid ProvidingSupplier_RefID { get; set; } 
			[DataMember]
			public Guid PriceConditionsManuallyCleared_ByAccount_RefID { get; set; } 
			[DataMember]
			public DateTime PriceConditionsManuallyCleared_AtDate { get; set; } 
			[DataMember]
			public Guid TakenIntoStock_ByAccount_RefID { get; set; } 
			[DataMember]
			public Guid ReceiptForwardedToBookkeeping_ByAccount_RefID { get; set; } 
			[DataMember]
			public DateTime ReceiptForwardedToBookkeeping_AtDate { get; set; } 
			[DataMember]
			public Guid QualityControlPerformed_ByAccount_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5SR_GRaPHfRH_1636 cls_Get_ReceiptHeader_and_ProcurmentHeader_for_ReceiptHeaderID(,P_L5SR_GRaPHfRH_1636 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5SR_GRaPHfRH_1636 invocationResult = cls_Get_ReceiptHeader_and_ProcurmentHeader_for_ReceiptHeaderID.Invoke(connectionString,P_L5SR_GRaPHfRH_1636 Parameter,securityTicket);
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
var parameter = new CL5_APOLogistic_StockReceipt.Atomic.Retrieval.P_L5SR_GRaPHfRH_1636();
parameter.ReceiptHeaderID = ...;

*/
