/* 
 * Generated on 3/7/2014 4:42:02 PM
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
    /// var result = cls_Get_LightStockReceiptsPositions_for_HeaderID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_LightStockReceiptsPositions_for_HeaderID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5ALSR_GLSRPfH_1138_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5ALSR_GLSRPfH_1138 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5ALSR_GLSRPfH_1138_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOLogistic_StockReceipt.Atomic.Retrieval.SQL.cls_Get_LightStockReceiptsPositions_for_HeaderID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"HeaderID", Parameter.HeaderID);



			List<L5ALSR_GLSRPfH_1138> results = new List<L5ALSR_GLSRPfH_1138>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "LOG_RCP_Receipt_HeaderID","Product_Name_DictID","Product_Number","DosageForm_Name_DictID","GlobalPropertyMatchingID","Abbreviation_DictID","ISOCode","PackageContent_Amount","Position_Quantity","TotalQuantityTakenIntoStock","LOG_RCP_Receipt_PositionID","ORD_PRC_ProcurementOrder_PositionID" });
				while(reader.Read())
				{
					L5ALSR_GLSRPfH_1138 resultItem = new L5ALSR_GLSRPfH_1138();
					//0:Parameter LOG_RCP_Receipt_HeaderID of type Guid
					resultItem.LOG_RCP_Receipt_HeaderID = reader.GetGuid(0);
					//1:Parameter Product_Name of type Dict
					resultItem.Product_Name = reader.GetDictionary(1);
					resultItem.Product_Name.SourceTable = "cmn_pro_products";
					loader.Append(resultItem.Product_Name);
					//2:Parameter Product_Number of type String
					resultItem.Product_Number = reader.GetString(2);
					//3:Parameter DosageForm_Name of type Dict
					resultItem.DosageForm_Name = reader.GetDictionary(3);
					resultItem.DosageForm_Name.SourceTable = "hec_product_dosageforms";
					loader.Append(resultItem.DosageForm_Name);
					//4:Parameter GlobalPropertyMatchingID of type String
					resultItem.GlobalPropertyMatchingID = reader.GetString(4);
					//5:Parameter Abbreviation of type Dict
					resultItem.Abbreviation = reader.GetDictionary(5);
					resultItem.Abbreviation.SourceTable = "cmn_units";
					loader.Append(resultItem.Abbreviation);
					//6:Parameter ISOCode of type String
					resultItem.ISOCode = reader.GetString(6);
					//7:Parameter PackageContent_Amount of type Double
					resultItem.PackageContent_Amount = reader.GetDouble(7);
					//8:Parameter Position_Quantity of type Double
					resultItem.Position_Quantity = reader.GetDouble(8);
					//9:Parameter TotalQuantityTakenIntoStock of type Double
					resultItem.TotalQuantityTakenIntoStock = reader.GetDouble(9);
					//10:Parameter LOG_RCP_Receipt_PositionID of type Guid
					resultItem.LOG_RCP_Receipt_PositionID = reader.GetGuid(10);
					//11:Parameter ORD_PRC_ProcurementOrder_PositionID of type Guid
					resultItem.ORD_PRC_ProcurementOrder_PositionID = reader.GetGuid(11);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_LightStockReceiptsPositions_for_HeaderID",ex);
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
		public static FR_L5ALSR_GLSRPfH_1138_Array Invoke(string ConnectionString,P_L5ALSR_GLSRPfH_1138 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5ALSR_GLSRPfH_1138_Array Invoke(DbConnection Connection,P_L5ALSR_GLSRPfH_1138 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5ALSR_GLSRPfH_1138_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5ALSR_GLSRPfH_1138 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5ALSR_GLSRPfH_1138_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5ALSR_GLSRPfH_1138 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5ALSR_GLSRPfH_1138_Array functionReturn = new FR_L5ALSR_GLSRPfH_1138_Array();
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

				throw new Exception("Exception occured in method cls_Get_LightStockReceiptsPositions_for_HeaderID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5ALSR_GLSRPfH_1138_Array : FR_Base
	{
		public L5ALSR_GLSRPfH_1138[] Result	{ get; set; } 
		public FR_L5ALSR_GLSRPfH_1138_Array() : base() {}

		public FR_L5ALSR_GLSRPfH_1138_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5ALSR_GLSRPfH_1138 for attribute P_L5ALSR_GLSRPfH_1138
		[DataContract]
		public class P_L5ALSR_GLSRPfH_1138 
		{
			//Standard type parameters
			[DataMember]
			public Guid HeaderID { get; set; } 

		}
		#endregion
		#region SClass L5ALSR_GLSRPfH_1138 for attribute L5ALSR_GLSRPfH_1138
		[DataContract]
		public class L5ALSR_GLSRPfH_1138 
		{
			//Standard type parameters
			[DataMember]
			public Guid LOG_RCP_Receipt_HeaderID { get; set; } 
			[DataMember]
			public Dict Product_Name { get; set; } 
			[DataMember]
			public String Product_Number { get; set; } 
			[DataMember]
			public Dict DosageForm_Name { get; set; } 
			[DataMember]
			public String GlobalPropertyMatchingID { get; set; } 
			[DataMember]
			public Dict Abbreviation { get; set; } 
			[DataMember]
			public String ISOCode { get; set; } 
			[DataMember]
			public Double PackageContent_Amount { get; set; } 
			[DataMember]
			public Double Position_Quantity { get; set; } 
			[DataMember]
			public Double TotalQuantityTakenIntoStock { get; set; } 
			[DataMember]
			public Guid LOG_RCP_Receipt_PositionID { get; set; } 
			[DataMember]
			public Guid ORD_PRC_ProcurementOrder_PositionID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5ALSR_GLSRPfH_1138_Array cls_Get_LightStockReceiptsPositions_for_HeaderID(,P_L5ALSR_GLSRPfH_1138 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5ALSR_GLSRPfH_1138_Array invocationResult = cls_Get_LightStockReceiptsPositions_for_HeaderID.Invoke(connectionString,P_L5ALSR_GLSRPfH_1138 Parameter,securityTicket);
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
var parameter = new CL5_APOLogistic_StockReceipt.Atomic.Retrieval.P_L5ALSR_GLSRPfH_1138();
parameter.HeaderID = ...;

*/
