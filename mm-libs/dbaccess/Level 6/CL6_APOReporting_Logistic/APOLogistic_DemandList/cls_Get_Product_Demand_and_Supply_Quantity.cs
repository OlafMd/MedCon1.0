/* 
 * Generated on 7/22/2014 1:32:38 PM
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

namespace CL6_APOReporting_Logistic.APOLogistic_DemandList
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Product_Demand_and_Supply_Quantity.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Product_Demand_and_Supply_Quantity
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6LG_GPDaSQ_1636_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L6LG_GPDaSQ_1636_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL6_APOReporting_Logistic.APOLogistic_DemandList.SQL.cls_Get_Product_Demand_and_Supply_Quantity.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L6LG_GPDaSQ_1636> results = new List<L6LG_GPDaSQ_1636>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "Product_Number","DemandQuantity","SupplyQuantity","ProductID" });
				while(reader.Read())
				{
					L6LG_GPDaSQ_1636 resultItem = new L6LG_GPDaSQ_1636();
					//0:Parameter Product_Number of type String
					resultItem.Product_Number = reader.GetString(0);
					//1:Parameter DemandQuantity of type double
					resultItem.DemandQuantity = reader.GetDouble(1);
					//2:Parameter SupplyQuantity of type double
					resultItem.SupplyQuantity = reader.GetDouble(2);
					//3:Parameter ProductID of type Guid
					resultItem.ProductID = reader.GetGuid(3);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Product_Demand_and_Supply_Quantity",ex);
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
		public static FR_L6LG_GPDaSQ_1636_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6LG_GPDaSQ_1636_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6LG_GPDaSQ_1636_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6LG_GPDaSQ_1636_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6LG_GPDaSQ_1636_Array functionReturn = new FR_L6LG_GPDaSQ_1636_Array();
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

				throw new Exception("Exception occured in method cls_Get_Product_Demand_and_Supply_Quantity",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6LG_GPDaSQ_1636_Array : FR_Base
	{
		public L6LG_GPDaSQ_1636[] Result	{ get; set; } 
		public FR_L6LG_GPDaSQ_1636_Array() : base() {}

		public FR_L6LG_GPDaSQ_1636_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L6LG_GPDaSQ_1636 for attribute L6LG_GPDaSQ_1636
		[DataContract]
		public class L6LG_GPDaSQ_1636 
		{
			//Standard type parameters
			[DataMember]
			public String Product_Number { get; set; } 
			[DataMember]
			public double DemandQuantity { get; set; } 
			[DataMember]
			public double SupplyQuantity { get; set; } 
			[DataMember]
			public Guid ProductID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6LG_GPDaSQ_1636_Array cls_Get_Product_Demand_and_Supply_Quantity(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6LG_GPDaSQ_1636_Array invocationResult = cls_Get_Product_Demand_and_Supply_Quantity.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/
