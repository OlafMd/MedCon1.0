/* 
 * Generated on 6/25/2014 4:52:29 PM
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

namespace CL5_APOProcurement_ProcurementOrder.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Open_ExtraDemandProducts.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Open_ExtraDemandProducts
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5PO_GOEDP_1716_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5PO_GOEDP_1716_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOProcurement_ProcurementOrder.Atomic.Retrieval.SQL.cls_Get_Open_ExtraDemandProducts.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L5PO_GOEDP_1716> results = new List<L5PO_GOEDP_1716>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "ORD_PRC_ExtraDemandProductID","Supplier_RefID","Product_RefID","CreatedFor_Office_RefID","CreatedBy_BusinessParticipant_RefID","ProcurementOrderPosition_RefID","RequestedQuantity","IsProcurementRunning","DeliveryTo_Warehouse_RefID","Supplier_Name" });
				while(reader.Read())
				{
					L5PO_GOEDP_1716 resultItem = new L5PO_GOEDP_1716();
					//0:Parameter ORD_PRC_ExtraDemandProductID of type Guid
					resultItem.ORD_PRC_ExtraDemandProductID = reader.GetGuid(0);
					//1:Parameter Supplier_RefID of type Guid
					resultItem.Supplier_RefID = reader.GetGuid(1);
					//2:Parameter Product_RefID of type Guid
					resultItem.Product_RefID = reader.GetGuid(2);
					//3:Parameter CreatedFor_Office_RefID of type Guid
					resultItem.CreatedFor_Office_RefID = reader.GetGuid(3);
					//4:Parameter CreatedBy_BusinessParticipant_RefID of type Guid
					resultItem.CreatedBy_BusinessParticipant_RefID = reader.GetGuid(4);
					//5:Parameter ProcurementOrderPosition_RefID of type Guid
					resultItem.ProcurementOrderPosition_RefID = reader.GetGuid(5);
					//6:Parameter RequestedQuantity of type Double
					resultItem.RequestedQuantity = reader.GetDouble(6);
					//7:Parameter IsProcurementRunning of type bool
					resultItem.IsProcurementRunning = reader.GetBoolean(7);
					//8:Parameter DeliveryTo_Warehouse_RefID of type Guid
					resultItem.DeliveryTo_Warehouse_RefID = reader.GetGuid(8);
					//9:Parameter Supplier_Name of type String
					resultItem.Supplier_Name = reader.GetString(9);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Open_ExtraDemandProducts",ex);
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
		public static FR_L5PO_GOEDP_1716_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5PO_GOEDP_1716_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5PO_GOEDP_1716_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5PO_GOEDP_1716_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5PO_GOEDP_1716_Array functionReturn = new FR_L5PO_GOEDP_1716_Array();
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

				throw new Exception("Exception occured in method cls_Get_Open_ExtraDemandProducts",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5PO_GOEDP_1716_Array : FR_Base
	{
		public L5PO_GOEDP_1716[] Result	{ get; set; } 
		public FR_L5PO_GOEDP_1716_Array() : base() {}

		public FR_L5PO_GOEDP_1716_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5PO_GOEDP_1716 for attribute L5PO_GOEDP_1716
		[DataContract]
		public class L5PO_GOEDP_1716 
		{
			//Standard type parameters
			[DataMember]
			public Guid ORD_PRC_ExtraDemandProductID { get; set; } 
			[DataMember]
			public Guid Supplier_RefID { get; set; } 
			[DataMember]
			public Guid Product_RefID { get; set; } 
			[DataMember]
			public Guid CreatedFor_Office_RefID { get; set; } 
			[DataMember]
			public Guid CreatedBy_BusinessParticipant_RefID { get; set; } 
			[DataMember]
			public Guid ProcurementOrderPosition_RefID { get; set; } 
			[DataMember]
			public Double RequestedQuantity { get; set; } 
			[DataMember]
			public bool IsProcurementRunning { get; set; } 
			[DataMember]
			public Guid DeliveryTo_Warehouse_RefID { get; set; } 
			[DataMember]
			public String Supplier_Name { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5PO_GOEDP_1716_Array cls_Get_Open_ExtraDemandProducts(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5PO_GOEDP_1716_Array invocationResult = cls_Get_Open_ExtraDemandProducts.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

