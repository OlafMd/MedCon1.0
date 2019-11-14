/* 
 * Generated on 7/28/2014 6:48:31 PM
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
    /// var result = cls_Retrieve_Bank_Account_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Retrieve_Bank_Accounts_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2_RBAfT_1847_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2_RBAfT_1847_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_Bank.Atomic.Retrieval.SQL.cls_Retrieve_Bank_Account_for_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L2_RBAfT_1847> results = new List<L2_RBAfT_1847>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "ACC_BNK_BankAccountID","Bank_RefID","OwnerText","IsValid","IBAN","AccountNumber","Currency_RefID","BankAccountType_RefID","AccountOpenedAtDate","Tenant_RefID" });
				while(reader.Read())
				{
					L2_RBAfT_1847 resultItem = new L2_RBAfT_1847();
					//0:Parameter ACC_BNK_BankAccountID of type Guid
					resultItem.ACC_BNK_BankAccountID = reader.GetGuid(0);
					//1:Parameter Bank_RefID of type Guid
					resultItem.Bank_RefID = reader.GetGuid(1);
					//2:Parameter OwnerText of type String
					resultItem.OwnerText = reader.GetString(2);
					//3:Parameter IsValid of type bool
					resultItem.IsValid = reader.GetBoolean(3);
					//4:Parameter IBAN of type String
					resultItem.IBAN = reader.GetString(4);
					//5:Parameter AccountNumber of type String
					resultItem.AccountNumber = reader.GetString(5);
					//6:Parameter Currency_RefID of type Guid
					resultItem.Currency_RefID = reader.GetGuid(6);
					//7:Parameter BankAccountType_RefID of type Guid
					resultItem.BankAccountType_RefID = reader.GetGuid(7);
					//8:Parameter AccountOpenedAtDate of type DateTime
					resultItem.AccountOpenedAtDate = reader.GetDate(8);
					//9:Parameter Tenant_RefID of type Guid
					resultItem.Tenant_RefID = reader.GetGuid(9);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Retrieve_Bank_Account_for_TenantID",ex);
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
		public static FR_L2_RBAfT_1847_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2_RBAfT_1847_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2_RBAfT_1847_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2_RBAfT_1847_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2_RBAfT_1847_Array functionReturn = new FR_L2_RBAfT_1847_Array();
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

				throw new Exception("Exception occured in method cls_Retrieve_Bank_Account_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2_RBAfT_1847_Array : FR_Base
	{
		public L2_RBAfT_1847[] Result	{ get; set; } 
		public FR_L2_RBAfT_1847_Array() : base() {}

		public FR_L2_RBAfT_1847_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L2_RBAfT_1847 for attribute L2_RBAfT_1847
		[DataContract]
		public class L2_RBAfT_1847 
		{
			//Standard type parameters
			[DataMember]
			public Guid ACC_BNK_BankAccountID { get; set; } 
			[DataMember]
			public Guid Bank_RefID { get; set; } 
			[DataMember]
			public String OwnerText { get; set; } 
			[DataMember]
			public bool IsValid { get; set; } 
			[DataMember]
			public String IBAN { get; set; } 
			[DataMember]
			public String AccountNumber { get; set; } 
			[DataMember]
			public Guid Currency_RefID { get; set; } 
			[DataMember]
			public Guid BankAccountType_RefID { get; set; } 
			[DataMember]
			public DateTime AccountOpenedAtDate { get; set; } 
			[DataMember]
			public Guid Tenant_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2_RBAfT_1847_Array cls_Retrieve_Bank_Account_for_TenantID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2_RBAfT_1847_Array invocationResult = cls_Retrieve_Bank_Account_for_TenantID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

