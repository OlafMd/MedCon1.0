/* 
 * Generated on 7/22/2014 4:57:10 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 * Required Assemblies:
 * System.Runtime.Serialization
 * CSV2Core
 * CSV2Core_MySQL
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using System.Runtime.Serialization;

namespace CL2_Bank.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Retrieve_All_Banks_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Retrieve_All_Banks_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2B_RABfT_1655_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2B_RABfT_1655_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_Bank.Atomic.Retrieval.SQL.cls_Retrieve_All_Banks_for_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L2B_RABfT_1655> results = new List<L2B_RABfT_1655>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "ACC_BNK_BankID","BankName","Country_RefID","BICCode","RoutingNumber","BankNumber","BankLocationComment" });
				while(reader.Read())
				{
					L2B_RABfT_1655 resultItem = new L2B_RABfT_1655();
					//0:Parameter ACC_BNK_BankID of type Guid
					resultItem.ACC_BNK_BankID = reader.GetGuid(0);
					//1:Parameter BankName of type String
					resultItem.BankName = reader.GetString(1);
					//2:Parameter Country_RefID of type Guid
					resultItem.Country_RefID = reader.GetGuid(2);
					//3:Parameter BICCode of type String
					resultItem.BICCode = reader.GetString(3);
					//4:Parameter RoutingNumber of type String
					resultItem.RoutingNumber = reader.GetString(4);
					//5:Parameter BankNumber of type String
					resultItem.BankNumber = reader.GetString(5);
					//6:Parameter BankLocationComment of type String
					resultItem.BankLocationComment = reader.GetString(6);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Retrieve_All_Banks_for_TenantID",ex);
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
		public static FR_L2B_RABfT_1655_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2B_RABfT_1655_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2B_RABfT_1655_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2B_RABfT_1655_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2B_RABfT_1655_Array functionReturn = new FR_L2B_RABfT_1655_Array();
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

				throw new Exception("Exception occured in method cls_Retrieve_All_Banks_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2B_RABfT_1655_Array : FR_Base
	{
		public L2B_RABfT_1655[] Result	{ get; set; } 
		public FR_L2B_RABfT_1655_Array() : base() {}

		public FR_L2B_RABfT_1655_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L2B_RABfT_1655 for attribute L2B_RABfT_1655
		[DataContract]
		public class L2B_RABfT_1655 
		{
			//Standard type parameters
			[DataMember]
			public Guid ACC_BNK_BankID { get; set; } 
			[DataMember]
			public String BankName { get; set; } 
			[DataMember]
			public Guid Country_RefID { get; set; } 
			[DataMember]
			public String BICCode { get; set; } 
			[DataMember]
			public String RoutingNumber { get; set; } 
			[DataMember]
			public String BankNumber { get; set; } 
			[DataMember]
			public String BankLocationComment { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2B_RABfT_1655_Array cls_Retrieve_All_Banks_for_TenantID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2B_RABfT_1655_Array invocationResult = cls_Retrieve_All_Banks_for_TenantID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

