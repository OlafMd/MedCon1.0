/* 
 * Generated on 26.1.2015 14:08:26
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

namespace CL5_Zugseil_DistributionOrder.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_all_DistributionOrder_Headers_for_OrderTracking.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_all_DistributionOrder_Headers_for_OrderTracking
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5DO_GaDOHfOT_1502_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5DO_GaDOHfOT_1502 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5DO_GaDOHfOT_1502_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_Zugseil_DistributionOrder.Atomic.Retrieval.SQL.cls_Get_all_DistributionOrder_Headers_for_OrderTracking.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"OrderNumber", Parameter.OrderNumber);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"StartDate", Parameter.StartDate);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"EndDate", Parameter.EndDate);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CostCenter", Parameter.CostCenter);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"Office", Parameter.Office);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"Warehouse", Parameter.Warehouse);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"Employee", Parameter.Employee);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"LanguageID", Parameter.LanguageID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"IsCanceled", Parameter.IsCanceled);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"IsPartiallyFullfilled", Parameter.IsPartiallyFullfilled);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"IsFullyFullfilled", Parameter.IsFullyFullfilled);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"IsNew", Parameter.IsNew);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PageSize", Parameter.PageSize);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ActivePage", Parameter.ActivePage);



			List<L5DO_GaDOHfOT_1502> results = new List<L5DO_GaDOHfOT_1502>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "ORD_DIS_DistributionOrder_HeaderID","DistributionOrderDate","DistributionOrderNumber","IsCanceled","IsPartiallyFullfilled","IsFullyFullfilled","CostCenterName_DictID","OfficeName_DictID","EmployeeName","WarehouseName" });
				while(reader.Read())
				{
					L5DO_GaDOHfOT_1502 resultItem = new L5DO_GaDOHfOT_1502();
					//0:Parameter ORD_DIS_DistributionOrder_HeaderID of type Guid
					resultItem.ORD_DIS_DistributionOrder_HeaderID = reader.GetGuid(0);
					//1:Parameter DistributionOrderDate of type DateTime
					resultItem.DistributionOrderDate = reader.GetDate(1);
					//2:Parameter DistributionOrderNumber of type string
					resultItem.DistributionOrderNumber = reader.GetString(2);
					//3:Parameter IsCanceled of type bool
					resultItem.IsCanceled = reader.GetBoolean(3);
					//4:Parameter IsPartiallyFullfilled of type bool
					resultItem.IsPartiallyFullfilled = reader.GetBoolean(4);
					//5:Parameter IsFullyFullfilled of type bool
					resultItem.IsFullyFullfilled = reader.GetBoolean(5);
					//6:Parameter CostCenterName of type Dict
					resultItem.CostCenterName = reader.GetDictionary(6);
					resultItem.CostCenterName.SourceTable = "cmn_str_costcenters";
					loader.Append(resultItem.CostCenterName);
					//7:Parameter OfficeName of type Dict
					resultItem.OfficeName = reader.GetDictionary(7);
					resultItem.OfficeName.SourceTable = "cmn_str_offices";
					loader.Append(resultItem.OfficeName);
					//8:Parameter EmployeeName of type string
					resultItem.EmployeeName = reader.GetString(8);
					//9:Parameter WarehouseName of type string
					resultItem.WarehouseName = reader.GetString(9);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_all_DistributionOrder_Headers_for_OrderTracking",ex);
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
		public static FR_L5DO_GaDOHfOT_1502_Array Invoke(string ConnectionString,P_L5DO_GaDOHfOT_1502 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5DO_GaDOHfOT_1502_Array Invoke(DbConnection Connection,P_L5DO_GaDOHfOT_1502 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5DO_GaDOHfOT_1502_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5DO_GaDOHfOT_1502 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5DO_GaDOHfOT_1502_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5DO_GaDOHfOT_1502 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5DO_GaDOHfOT_1502_Array functionReturn = new FR_L5DO_GaDOHfOT_1502_Array();
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

				throw new Exception("Exception occured in method cls_Get_all_DistributionOrder_Headers_for_OrderTracking",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5DO_GaDOHfOT_1502_Array : FR_Base
	{
		public L5DO_GaDOHfOT_1502[] Result	{ get; set; } 
		public FR_L5DO_GaDOHfOT_1502_Array() : base() {}

		public FR_L5DO_GaDOHfOT_1502_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5DO_GaDOHfOT_1502 for attribute P_L5DO_GaDOHfOT_1502
		[DataContract]
		public class P_L5DO_GaDOHfOT_1502 
		{
			//Standard type parameters
			[DataMember]
			public string OrderNumber { get; set; } 
			[DataMember]
			public DateTime? StartDate { get; set; } 
			[DataMember]
			public DateTime? EndDate { get; set; } 
			[DataMember]
			public string CostCenter { get; set; } 
			[DataMember]
			public string Office { get; set; } 
			[DataMember]
			public string Warehouse { get; set; } 
			[DataMember]
			public string Employee { get; set; } 
			[DataMember]
			public Guid LanguageID { get; set; } 
			[DataMember]
			public bool IsCanceled { get; set; } 
			[DataMember]
			public bool IsPartiallyFullfilled { get; set; } 
			[DataMember]
			public bool IsFullyFullfilled { get; set; } 
			[DataMember]
			public bool IsNew { get; set; } 
			[DataMember]
			public int PageSize { get; set; } 
			[DataMember]
			public int ActivePage { get; set; } 

		}
		#endregion
		#region SClass L5DO_GaDOHfOT_1502 for attribute L5DO_GaDOHfOT_1502
		[DataContract]
		public class L5DO_GaDOHfOT_1502 
		{
			//Standard type parameters
			[DataMember]
			public Guid ORD_DIS_DistributionOrder_HeaderID { get; set; } 
			[DataMember]
			public DateTime DistributionOrderDate { get; set; } 
			[DataMember]
			public string DistributionOrderNumber { get; set; } 
			[DataMember]
			public bool IsCanceled { get; set; } 
			[DataMember]
			public bool IsPartiallyFullfilled { get; set; } 
			[DataMember]
			public bool IsFullyFullfilled { get; set; } 
			[DataMember]
			public Dict CostCenterName { get; set; } 
			[DataMember]
			public Dict OfficeName { get; set; } 
			[DataMember]
			public string EmployeeName { get; set; } 
			[DataMember]
			public string WarehouseName { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5DO_GaDOHfOT_1502_Array cls_Get_all_DistributionOrder_Headers_for_OrderTracking(,P_L5DO_GaDOHfOT_1502 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5DO_GaDOHfOT_1502_Array invocationResult = cls_Get_all_DistributionOrder_Headers_for_OrderTracking.Invoke(connectionString,P_L5DO_GaDOHfOT_1502 Parameter,securityTicket);
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
var parameter = new CL5_Zugseil_DistributionOrder.Atomic.Retrieval.P_L5DO_GaDOHfOT_1502();
parameter.OrderNumber = ...;
parameter.StartDate = ...;
parameter.EndDate = ...;
parameter.CostCenter = ...;
parameter.Office = ...;
parameter.Warehouse = ...;
parameter.Employee = ...;
parameter.LanguageID = ...;
parameter.IsCanceled = ...;
parameter.IsPartiallyFullfilled = ...;
parameter.IsFullyFullfilled = ...;
parameter.IsNew = ...;
parameter.PageSize = ...;
parameter.ActivePage = ...;

*/
