/* 
 * Generated on 10/6/2014 3:33:36 PM
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
    /// var result = cls_Get_AllPurchaseOrder_for_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_AllPurchaseOrder_for_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5CO_GAPOfT_1144_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5CO_GAPOfT_1144_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOBackoffice_CustomerOrder.Atomic.Retrieval.SQL.cls_Get_AllPurchaseOrder_for_Tenant.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L5CO_GAPOfT_1144> results = new List<L5CO_GAPOfT_1144>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "ORD_CUO_CustomerOrder_HeaderID","CustomerOrder_Number","CustomerOrder_Date","OrderedByCompanyName","OrderedByEmail","PositionCount","Price" });
				while(reader.Read())
				{
					L5CO_GAPOfT_1144 resultItem = new L5CO_GAPOfT_1144();
					//0:Parameter ORD_CUO_CustomerOrder_HeaderID of type Guid
					resultItem.ORD_CUO_CustomerOrder_HeaderID = reader.GetGuid(0);
					//1:Parameter CustomerOrder_Number of type String
					resultItem.CustomerOrder_Number = reader.GetString(1);
					//2:Parameter CustomerOrder_Date of type DateTime
					resultItem.CustomerOrder_Date = reader.GetDate(2);
					//3:Parameter OrderedByCompanyName of type String
					resultItem.OrderedByCompanyName = reader.GetString(3);
					//4:Parameter OrderedByEmail of type String
					resultItem.OrderedByEmail = reader.GetString(4);
					//5:Parameter PositionCount of type String
					resultItem.PositionCount = reader.GetString(5);
					//6:Parameter Price of type Double
					resultItem.Price = reader.GetDouble(6);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_AllPurchaseOrder_for_Tenant",ex);
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
		public static FR_L5CO_GAPOfT_1144_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5CO_GAPOfT_1144_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5CO_GAPOfT_1144_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5CO_GAPOfT_1144_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5CO_GAPOfT_1144_Array functionReturn = new FR_L5CO_GAPOfT_1144_Array();
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

				throw new Exception("Exception occured in method cls_Get_AllPurchaseOrder_for_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5CO_GAPOfT_1144_Array : FR_Base
	{
		public L5CO_GAPOfT_1144[] Result	{ get; set; } 
		public FR_L5CO_GAPOfT_1144_Array() : base() {}

		public FR_L5CO_GAPOfT_1144_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5CO_GAPOfT_1144 for attribute L5CO_GAPOfT_1144
		[DataContract]
		public class L5CO_GAPOfT_1144 
		{
			//Standard type parameters
			[DataMember]
			public Guid ORD_CUO_CustomerOrder_HeaderID { get; set; } 
			[DataMember]
			public String CustomerOrder_Number { get; set; } 
			[DataMember]
			public DateTime CustomerOrder_Date { get; set; } 
			[DataMember]
			public String OrderedByCompanyName { get; set; } 
			[DataMember]
			public String OrderedByEmail { get; set; } 
			[DataMember]
			public String PositionCount { get; set; } 
			[DataMember]
			public Double Price { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5CO_GAPOfT_1144_Array cls_Get_AllPurchaseOrder_for_Tenant(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5CO_GAPOfT_1144_Array invocationResult = cls_Get_AllPurchaseOrder_for_Tenant.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

