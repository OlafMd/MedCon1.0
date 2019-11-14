/* 
 * Generated on 1/20/2017 2:34:28 PM
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
    /// var result = cls_Get_BankInfo_for_Practice.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_BankInfo_for_Practice
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_DO_GBAfPR_1524_Array Execute(DbConnection Connection,DbTransaction Transaction,P_DO_GBAfPR_1524 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_DO_GBAfPR_1524_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "DataImporter.DBMethods.ExportData.Atomic.Retrieval.SQL.cls_Get_BankInfo_for_Practice.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PracticeID", Parameter.PracticeID);



			List<DO_GBAfPR_1524> results = new List<DO_GBAfPR_1524>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "OwnerText","IBAN","BICCode","BankName","BankAccountID","BankID" });
				while(reader.Read())
				{
					DO_GBAfPR_1524 resultItem = new DO_GBAfPR_1524();
					//0:Parameter OwnerText of type String
					resultItem.OwnerText = reader.GetString(0);
					//1:Parameter IBAN of type String
					resultItem.IBAN = reader.GetString(1);
					//2:Parameter BICCode of type String
					resultItem.BICCode = reader.GetString(2);
					//3:Parameter BankName of type String
					resultItem.BankName = reader.GetString(3);
					//4:Parameter BankAccountID of type Guid
					resultItem.BankAccountID = reader.GetGuid(4);
					//5:Parameter BankID of type Guid
					resultItem.BankID = reader.GetGuid(5);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_BankInfo_for_Practice",ex);
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
		public static FR_DO_GBAfPR_1524_Array Invoke(string ConnectionString,P_DO_GBAfPR_1524 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_DO_GBAfPR_1524_Array Invoke(DbConnection Connection,P_DO_GBAfPR_1524 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_DO_GBAfPR_1524_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_DO_GBAfPR_1524 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_DO_GBAfPR_1524_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_DO_GBAfPR_1524 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_DO_GBAfPR_1524_Array functionReturn = new FR_DO_GBAfPR_1524_Array();
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

				throw new Exception("Exception occured in method cls_Get_BankInfo_for_Practice",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_DO_GBAfPR_1524_Array : FR_Base
	{
		public DO_GBAfPR_1524[] Result	{ get; set; } 
		public FR_DO_GBAfPR_1524_Array() : base() {}

		public FR_DO_GBAfPR_1524_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_DO_GBAfPR_1524 for attribute P_DO_GBAfPR_1524
		[DataContract]
		public class P_DO_GBAfPR_1524 
		{
			//Standard type parameters
			[DataMember]
			public Guid PracticeID { get; set; } 

		}
		#endregion
		#region SClass DO_GBAfPR_1524 for attribute DO_GBAfPR_1524
		[DataContract]
		public class DO_GBAfPR_1524 
		{
			//Standard type parameters
			[DataMember]
			public String OwnerText { get; set; } 
			[DataMember]
			public String IBAN { get; set; } 
			[DataMember]
			public String BICCode { get; set; } 
			[DataMember]
			public String BankName { get; set; } 
			[DataMember]
			public Guid BankAccountID { get; set; } 
			[DataMember]
			public Guid BankID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_DO_GBAfPR_1524_Array cls_Get_BankInfo_for_Practice(,P_DO_GBAfPR_1524 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_DO_GBAfPR_1524_Array invocationResult = cls_Get_BankInfo_for_Practice.Invoke(connectionString,P_DO_GBAfPR_1524 Parameter,securityTicket);
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
var parameter = new DataImporter.DBMethods.ExportData.Atomic.Retrieval.P_DO_GBAfPR_1524();
parameter.PracticeID = ...;

*/
