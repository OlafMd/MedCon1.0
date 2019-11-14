/* 
 * Generated on 3/23/2015 12:23:29
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

namespace CL3_ShelfContent.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_StockQuantity_Current_and_Free_for_ShelfContentIDList.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_StockQuantity_Current_and_Free_for_ShelfContentIDList
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3SC_GSQCaFfSC_1707_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3SC_GSQCaFfSC_1707 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3SC_GSQCaFfSC_1707_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_ShelfContent.Atomic.Retrieval.SQL.cls_Get_StockQuantity_Current_and_Free_for_ShelfContentIDList.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@ShelfContentIDList"," IN $$ShelfContentIDList$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$ShelfContentIDList$",Parameter.ShelfContentIDList);


			List<L3SC_GSQCaFfSC_1707> results = new List<L3SC_GSQCaFfSC_1707>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "Product_RefID","CurrentQuantity","ReservedQuantity","FreeQuantity","LOG_WRH_Shelf_ContentID" });
				while(reader.Read())
				{
					L3SC_GSQCaFfSC_1707 resultItem = new L3SC_GSQCaFfSC_1707();
					//0:Parameter Product_RefID of type Guid
					resultItem.Product_RefID = reader.GetGuid(0);
					//1:Parameter CurrentQuantity of type double
					resultItem.CurrentQuantity = reader.GetDouble(1);
					//2:Parameter ReservedQuantity of type double
					resultItem.ReservedQuantity = reader.GetDouble(2);
					//3:Parameter FreeQuantity of type double
					resultItem.FreeQuantity = reader.GetDouble(3);
					//4:Parameter LOG_WRH_Shelf_ContentID of type Guid
					resultItem.LOG_WRH_Shelf_ContentID = reader.GetGuid(4);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_StockQuantity_Current_and_Free_for_ShelfContentIDList",ex);
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
		public static FR_L3SC_GSQCaFfSC_1707_Array Invoke(string ConnectionString,P_L3SC_GSQCaFfSC_1707 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3SC_GSQCaFfSC_1707_Array Invoke(DbConnection Connection,P_L3SC_GSQCaFfSC_1707 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3SC_GSQCaFfSC_1707_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3SC_GSQCaFfSC_1707 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3SC_GSQCaFfSC_1707_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3SC_GSQCaFfSC_1707 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3SC_GSQCaFfSC_1707_Array functionReturn = new FR_L3SC_GSQCaFfSC_1707_Array();
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

				throw new Exception("Exception occured in method cls_Get_StockQuantity_Current_and_Free_for_ShelfContentIDList",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3SC_GSQCaFfSC_1707_Array : FR_Base
	{
		public L3SC_GSQCaFfSC_1707[] Result	{ get; set; } 
		public FR_L3SC_GSQCaFfSC_1707_Array() : base() {}

		public FR_L3SC_GSQCaFfSC_1707_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3SC_GSQCaFfSC_1707 for attribute P_L3SC_GSQCaFfSC_1707
		[DataContract]
		public class P_L3SC_GSQCaFfSC_1707 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] ShelfContentIDList { get; set; } 

		}
		#endregion
		#region SClass L3SC_GSQCaFfSC_1707 for attribute L3SC_GSQCaFfSC_1707
		[DataContract]
		public class L3SC_GSQCaFfSC_1707 
		{
			//Standard type parameters
			[DataMember]
			public Guid Product_RefID { get; set; } 
			[DataMember]
			public double CurrentQuantity { get; set; } 
			[DataMember]
			public double ReservedQuantity { get; set; } 
			[DataMember]
			public double FreeQuantity { get; set; } 
			[DataMember]
			public Guid LOG_WRH_Shelf_ContentID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3SC_GSQCaFfSC_1707_Array cls_Get_StockQuantity_Current_and_Free_for_ShelfContentIDList(,P_L3SC_GSQCaFfSC_1707 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3SC_GSQCaFfSC_1707_Array invocationResult = cls_Get_StockQuantity_Current_and_Free_for_ShelfContentIDList.Invoke(connectionString,P_L3SC_GSQCaFfSC_1707 Parameter,securityTicket);
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
var parameter = new CL3_ShelfContent.Atomic.Retrieval.P_L3SC_GSQCaFfSC_1707();
parameter.ShelfContentIDList = ...;

*/
