/* 
 * Generated on 3/3/2015 17:31:50
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

namespace CL5_Zugseil_CustomerOrder.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Customer_Orders_for_Status.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Customer_Orders_for_Status
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5CO_GCOfS_1449_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5CO_GCOfS_1449 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5CO_GCOfS_1449_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_Zugseil_CustomerOrder.Atomic.Retrieval.SQL.cls_Get_Customer_Orders_for_Status.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"StatusGlobalPropertyMatching", Parameter.StatusGlobalPropertyMatching);



			List<L5CO_GCOfS_1449> results = new List<L5CO_GCOfS_1449>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "ORD_CUO_CustomerOrder_HeaderID","CustomerOrder_Number","ProcurementOrderITL","CustomerOrder_Date","Current_CustomerOrderStatus_RefID","GlobalPropertyMatchingID","Status_Code","Status_Name_DictID","OrderingCustomer_BusinessParticipant_RefID","CustomerOrder_Currency_RefID","TotalValue_BeforeTax","Customer_Name","Name_DictID","ISO4127","Symbol","Number_of_Positions" });
				while(reader.Read())
				{
					L5CO_GCOfS_1449 resultItem = new L5CO_GCOfS_1449();
					//0:Parameter ORD_CUO_CustomerOrder_HeaderID of type Guid
					resultItem.ORD_CUO_CustomerOrder_HeaderID = reader.GetGuid(0);
					//1:Parameter CustomerOrder_Number of type String
					resultItem.CustomerOrder_Number = reader.GetString(1);
					//2:Parameter ProcurementOrderITL of type String
					resultItem.ProcurementOrderITL = reader.GetString(2);
					//3:Parameter CustomerOrder_Date of type DateTime
					resultItem.CustomerOrder_Date = reader.GetDate(3);
					//4:Parameter Current_CustomerOrderStatus_RefID of type Guid
					resultItem.Current_CustomerOrderStatus_RefID = reader.GetGuid(4);
					//5:Parameter GlobalPropertyMatchingID of type string
					resultItem.GlobalPropertyMatchingID = reader.GetString(5);
					//6:Parameter Status_Code of type String
					resultItem.Status_Code = reader.GetString(6);
					//7:Parameter Status_Name of type Dict
					resultItem.Status_Name = reader.GetDictionary(7);
					resultItem.Status_Name.SourceTable = "ord_cuo_customerorder_statuses";
					loader.Append(resultItem.Status_Name);
					//8:Parameter OrderingCustomer_BusinessParticipant_RefID of type Guid
					resultItem.OrderingCustomer_BusinessParticipant_RefID = reader.GetGuid(8);
					//9:Parameter CustomerOrder_Currency_RefID of type Guid
					resultItem.CustomerOrder_Currency_RefID = reader.GetGuid(9);
					//10:Parameter TotalValue_BeforeTax of type String
					resultItem.TotalValue_BeforeTax = reader.GetString(10);
					//11:Parameter Customer_Name of type String
					resultItem.Customer_Name = reader.GetString(11);
					//12:Parameter Name of type Dict
					resultItem.Name = reader.GetDictionary(12);
					resultItem.Name.SourceTable = "cmn_currencies";
					loader.Append(resultItem.Name);
					//13:Parameter ISO4127 of type String
					resultItem.ISO4127 = reader.GetString(13);
					//14:Parameter Symbol of type String
					resultItem.Symbol = reader.GetString(14);
					//15:Parameter Number_of_Positions of type int
					resultItem.Number_of_Positions = reader.GetInteger(15);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Customer_Orders_for_Status",ex);
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
		public static FR_L5CO_GCOfS_1449_Array Invoke(string ConnectionString,P_L5CO_GCOfS_1449 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5CO_GCOfS_1449_Array Invoke(DbConnection Connection,P_L5CO_GCOfS_1449 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5CO_GCOfS_1449_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5CO_GCOfS_1449 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5CO_GCOfS_1449_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5CO_GCOfS_1449 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5CO_GCOfS_1449_Array functionReturn = new FR_L5CO_GCOfS_1449_Array();
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

				throw new Exception("Exception occured in method cls_Get_Customer_Orders_for_Status",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5CO_GCOfS_1449_Array : FR_Base
	{
		public L5CO_GCOfS_1449[] Result	{ get; set; } 
		public FR_L5CO_GCOfS_1449_Array() : base() {}

		public FR_L5CO_GCOfS_1449_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5CO_GCOfS_1449 for attribute P_L5CO_GCOfS_1449
		[DataContract]
		public class P_L5CO_GCOfS_1449 
		{
			//Standard type parameters
			[DataMember]
			public string StatusGlobalPropertyMatching { get; set; } 

		}
		#endregion
		#region SClass L5CO_GCOfS_1449 for attribute L5CO_GCOfS_1449
		[DataContract]
		public class L5CO_GCOfS_1449 
		{
			//Standard type parameters
			[DataMember]
			public Guid ORD_CUO_CustomerOrder_HeaderID { get; set; } 
			[DataMember]
			public String CustomerOrder_Number { get; set; } 
			[DataMember]
			public String ProcurementOrderITL { get; set; } 
			[DataMember]
			public DateTime CustomerOrder_Date { get; set; } 
			[DataMember]
			public Guid Current_CustomerOrderStatus_RefID { get; set; } 
			[DataMember]
			public string GlobalPropertyMatchingID { get; set; } 
			[DataMember]
			public String Status_Code { get; set; } 
			[DataMember]
			public Dict Status_Name { get; set; } 
			[DataMember]
			public Guid OrderingCustomer_BusinessParticipant_RefID { get; set; } 
			[DataMember]
			public Guid CustomerOrder_Currency_RefID { get; set; } 
			[DataMember]
			public String TotalValue_BeforeTax { get; set; } 
			[DataMember]
			public String Customer_Name { get; set; } 
			[DataMember]
			public Dict Name { get; set; } 
			[DataMember]
			public String ISO4127 { get; set; } 
			[DataMember]
			public String Symbol { get; set; } 
			[DataMember]
			public int Number_of_Positions { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5CO_GCOfS_1449_Array cls_Get_Customer_Orders_for_Status(,P_L5CO_GCOfS_1449 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5CO_GCOfS_1449_Array invocationResult = cls_Get_Customer_Orders_for_Status.Invoke(connectionString,P_L5CO_GCOfS_1449 Parameter,securityTicket);
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
var parameter = new CL5_Zugseil_CustomerOrder.Atomic.Retrieval.P_L5CO_GCOfS_1449();
parameter.StatusGlobalPropertyMatching = ...;

*/
