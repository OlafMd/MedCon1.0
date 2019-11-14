/* 
 * Generated on 8/12/2014 11:33:25 AM
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

namespace CL5_APOBackoffice_CustomerOrder.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_AllCustomerOrders_for_Tenant_or_OrderID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_AllCustomerOrders_for_Tenant_or_OrderID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5CO_GACOfToO_1214_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5CO_GACOfToO_1214 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5CO_GACOfToO_1214_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOBackoffice_CustomerOrder.Atomic.Retrieval.SQL.cls_Get_AllCustomerOrders_for_Tenant_or_OrderID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"OrderID", Parameter.OrderID);



			List<L5CO_GACOfToO_1214> results = new List<L5CO_GACOfToO_1214>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "ORD_CUO_CustomerOrder_HeaderID","IfCompany_CMN_COM_CompanyInfo_RefID","CustomerOrder_Number","CompanyName_Line1","Contact_Email","CustomerOrder_Date","TotalValue_BeforeTax","Status_Code","Status_Name_DictID","CustomerOrderStatus_GlobalPropertyMatching","CreatedBy_DisplayName","CreatedBy_BusinessParticipant_RefID" });
				while(reader.Read())
				{
					L5CO_GACOfToO_1214 resultItem = new L5CO_GACOfToO_1214();
					//0:Parameter ORD_CUO_CustomerOrder_HeaderID of type Guid
					resultItem.ORD_CUO_CustomerOrder_HeaderID = reader.GetGuid(0);
					//1:Parameter IfCompany_CMN_COM_CompanyInfo_RefID of type Guid
					resultItem.IfCompany_CMN_COM_CompanyInfo_RefID = reader.GetGuid(1);
					//2:Parameter CustomerOrder_Number of type String
					resultItem.CustomerOrder_Number = reader.GetString(2);
					//3:Parameter CompanyName_Line1 of type String
					resultItem.CompanyName_Line1 = reader.GetString(3);
					//4:Parameter Contact_Email of type String
					resultItem.Contact_Email = reader.GetString(4);
					//5:Parameter CustomerOrder_Date of type DateTime
					resultItem.CustomerOrder_Date = reader.GetDate(5);
					//6:Parameter TotalValue_BeforeTax of type Decimal
					resultItem.TotalValue_BeforeTax = reader.GetDecimal(6);
					//7:Parameter Status_Code of type int
					resultItem.Status_Code = reader.GetInteger(7);
					//8:Parameter Status_Name_DictID of type Dict
					resultItem.Status_Name_DictID = reader.GetDictionary(8);
					resultItem.Status_Name_DictID.SourceTable = "ord_cuo_customerorder_statuses";
					loader.Append(resultItem.Status_Name_DictID);
					//9:Parameter CustomerOrderStatus_GlobalPropertyMatching of type String
					resultItem.CustomerOrderStatus_GlobalPropertyMatching = reader.GetString(9);
					//10:Parameter CreatedBy_DisplayName of type String
					resultItem.CreatedBy_DisplayName = reader.GetString(10);
					//11:Parameter CreatedBy_BusinessParticipant_RefID of type Guid
					resultItem.CreatedBy_BusinessParticipant_RefID = reader.GetGuid(11);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_AllCustomerOrders_for_Tenant_or_OrderID",ex);
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
		public static FR_L5CO_GACOfToO_1214_Array Invoke(string ConnectionString,P_L5CO_GACOfToO_1214 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5CO_GACOfToO_1214_Array Invoke(DbConnection Connection,P_L5CO_GACOfToO_1214 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5CO_GACOfToO_1214_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5CO_GACOfToO_1214 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5CO_GACOfToO_1214_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5CO_GACOfToO_1214 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5CO_GACOfToO_1214_Array functionReturn = new FR_L5CO_GACOfToO_1214_Array();
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

				throw new Exception("Exception occured in method cls_Get_AllCustomerOrders_for_Tenant_or_OrderID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5CO_GACOfToO_1214_Array : FR_Base
	{
		public L5CO_GACOfToO_1214[] Result	{ get; set; } 
		public FR_L5CO_GACOfToO_1214_Array() : base() {}

		public FR_L5CO_GACOfToO_1214_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5CO_GACOfToO_1214 for attribute P_L5CO_GACOfToO_1214
		[DataContract]
		public class P_L5CO_GACOfToO_1214 
		{
			//Standard type parameters
			[DataMember]
			public Guid? OrderID { get; set; } 

		}
		#endregion
		#region SClass L5CO_GACOfToO_1214 for attribute L5CO_GACOfToO_1214
		[DataContract]
		public class L5CO_GACOfToO_1214 
		{
			//Standard type parameters
			[DataMember]
			public Guid ORD_CUO_CustomerOrder_HeaderID { get; set; } 
			[DataMember]
			public Guid IfCompany_CMN_COM_CompanyInfo_RefID { get; set; } 
			[DataMember]
			public String CustomerOrder_Number { get; set; } 
			[DataMember]
			public String CompanyName_Line1 { get; set; } 
			[DataMember]
			public String Contact_Email { get; set; } 
			[DataMember]
			public DateTime CustomerOrder_Date { get; set; } 
			[DataMember]
			public Decimal TotalValue_BeforeTax { get; set; } 
			[DataMember]
			public int Status_Code { get; set; } 
			[DataMember]
			public Dict Status_Name_DictID { get; set; } 
			[DataMember]
			public String CustomerOrderStatus_GlobalPropertyMatching { get; set; } 
			[DataMember]
			public String CreatedBy_DisplayName { get; set; } 
			[DataMember]
			public Guid CreatedBy_BusinessParticipant_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5CO_GACOfToO_1214_Array cls_Get_AllCustomerOrders_for_Tenant_or_OrderID(,P_L5CO_GACOfToO_1214 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5CO_GACOfToO_1214_Array invocationResult = cls_Get_AllCustomerOrders_for_Tenant_or_OrderID.Invoke(connectionString,P_L5CO_GACOfToO_1214 Parameter,securityTicket);
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
var parameter = new CL5_APOBackoffice_CustomerOrder.Atomic.Retrieval.P_L5CO_GACOfToO_1214();
parameter.OrderID = ...;

*/
