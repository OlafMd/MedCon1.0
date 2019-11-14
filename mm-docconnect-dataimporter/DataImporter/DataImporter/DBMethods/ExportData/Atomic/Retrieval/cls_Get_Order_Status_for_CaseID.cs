/* 
 * Generated on 1/20/2017 2:34:30 PM
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

namespace DataImporter.DBMethods.ExportData.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Order_Status_for_CaseID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Order_Status_for_CaseID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_OR_GOSfCID_0858_Array Execute(DbConnection Connection,DbTransaction Transaction,P_OR_GOSfCID_0858 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_OR_GOSfCID_0858_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "DataImporter.DBMethods.ExportData.Atomic.Retrieval.SQL.cls_Get_Order_Status_for_CaseID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CaseID", Parameter.CaseID);



			List<OR_GOSfCID_0858> results = new List<OR_GOSfCID_0858>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "OrderID","StatusCode","StatusHistoryID","StatusCanceled","StatusModified","StatusCreated" });
				while(reader.Read())
				{
					OR_GOSfCID_0858 resultItem = new OR_GOSfCID_0858();
					//0:Parameter OrderID of type Guid
					resultItem.OrderID = reader.GetGuid(0);
					//1:Parameter StatusCode of type Double
					resultItem.StatusCode = reader.GetDouble(1);
					//2:Parameter StatusHistoryID of type Guid
					resultItem.StatusHistoryID = reader.GetGuid(2);
					//3:Parameter StatusCanceled of type Double
					resultItem.StatusCanceled = reader.GetDouble(3);
					//4:Parameter StatusModified of type DateTime
					resultItem.StatusModified = reader.GetDate(4);
					//5:Parameter StatusCreated of type DateTime
					resultItem.StatusCreated = reader.GetDate(5);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Order_Status_for_CaseID",ex);
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
		public static FR_OR_GOSfCID_0858_Array Invoke(string ConnectionString,P_OR_GOSfCID_0858 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_OR_GOSfCID_0858_Array Invoke(DbConnection Connection,P_OR_GOSfCID_0858 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_OR_GOSfCID_0858_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_OR_GOSfCID_0858 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_OR_GOSfCID_0858_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_OR_GOSfCID_0858 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_OR_GOSfCID_0858_Array functionReturn = new FR_OR_GOSfCID_0858_Array();
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

				throw new Exception("Exception occured in method cls_Get_Order_Status_for_CaseID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_OR_GOSfCID_0858_Array : FR_Base
	{
		public OR_GOSfCID_0858[] Result	{ get; set; } 
		public FR_OR_GOSfCID_0858_Array() : base() {}

		public FR_OR_GOSfCID_0858_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_OR_GOSfCID_0858 for attribute P_OR_GOSfCID_0858
		[DataContract]
		public class P_OR_GOSfCID_0858 
		{
			//Standard type parameters
			[DataMember]
			public Guid CaseID { get; set; } 

		}
		#endregion
		#region SClass OR_GOSfCID_0858 for attribute OR_GOSfCID_0858
		[DataContract]
		public class OR_GOSfCID_0858 
		{
			//Standard type parameters
			[DataMember]
			public Guid OrderID { get; set; } 
			[DataMember]
			public Double StatusCode { get; set; } 
			[DataMember]
			public Guid StatusHistoryID { get; set; } 
			[DataMember]
			public Double StatusCanceled { get; set; } 
			[DataMember]
			public DateTime StatusModified { get; set; } 
			[DataMember]
			public DateTime StatusCreated { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_OR_GOSfCID_0858_Array cls_Get_Order_Status_for_CaseID(,P_OR_GOSfCID_0858 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_OR_GOSfCID_0858_Array invocationResult = cls_Get_Order_Status_for_CaseID.Invoke(connectionString,P_OR_GOSfCID_0858 Parameter,securityTicket);
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
var parameter = new DataImporter.DBMethods.ExportData.Atomic.Retrieval.P_OR_GOSfCID_0858();
parameter.CaseID = ...;

*/
