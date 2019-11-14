/* 
 * Generated on 12/15/15 15:27:52
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

namespace MMDocConnectDBMethods.Doctor.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Practice_Details_on_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Practice_Details_on_Tenant
	{
        public static readonly int QueryTimeout = 6000;

		#region Method Execution
		protected static FR_DO_GPDoT_2040_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_DO_GPDoT_2040_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.Doctor.Atomic.Retrieval.SQL.cls_Get_Practice_Details_on_Tenant.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<DO_GPDoT_2040> results = new List<DO_GPDoT_2040>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "PracticeID","PracticeBptID","PracticeBSNR","PracticeName","AccountHolder","IBAN","BankName","BIC","ZIP","City","StreetName","StreetNumber" });
				while(reader.Read())
				{
					DO_GPDoT_2040 resultItem = new DO_GPDoT_2040();
					//0:Parameter PracticeID of type Guid
					resultItem.PracticeID = reader.GetGuid(0);
					//1:Parameter PracticeBptID of type Guid
					resultItem.PracticeBptID = reader.GetGuid(1);
					//2:Parameter PracticeBSNR of type String
					resultItem.PracticeBSNR = reader.GetString(2);
					//3:Parameter PracticeName of type String
					resultItem.PracticeName = reader.GetString(3);
					//4:Parameter AccountHolder of type String
					resultItem.AccountHolder = reader.GetString(4);
					//5:Parameter IBAN of type String
					resultItem.IBAN = reader.GetString(5);
					//6:Parameter BankName of type String
					resultItem.BankName = reader.GetString(6);
					//7:Parameter BIC of type String
					resultItem.BIC = reader.GetString(7);
					//8:Parameter ZIP of type String
					resultItem.ZIP = reader.GetString(8);
					//9:Parameter City of type String
					resultItem.City = reader.GetString(9);
					//10:Parameter StreetName of type String
					resultItem.StreetName = reader.GetString(10);
					//11:Parameter StreetNumber of type String
					resultItem.StreetNumber = reader.GetString(11);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Practice_Details_on_Tenant",ex);
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
		public static FR_DO_GPDoT_2040_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_DO_GPDoT_2040_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_DO_GPDoT_2040_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_DO_GPDoT_2040_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_DO_GPDoT_2040_Array functionReturn = new FR_DO_GPDoT_2040_Array();
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

				throw new Exception("Exception occured in method cls_Get_Practice_Details_on_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_DO_GPDoT_2040_Array : FR_Base
	{
		public DO_GPDoT_2040[] Result	{ get; set; } 
		public FR_DO_GPDoT_2040_Array() : base() {}

		public FR_DO_GPDoT_2040_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass DO_GPDoT_2040 for attribute DO_GPDoT_2040
		[DataContract]
		public class DO_GPDoT_2040 
		{
			//Standard type parameters
			[DataMember]
			public Guid PracticeID { get; set; } 
			[DataMember]
			public Guid PracticeBptID { get; set; } 
			[DataMember]
			public String PracticeBSNR { get; set; } 
			[DataMember]
			public String PracticeName { get; set; } 
			[DataMember]
			public String AccountHolder { get; set; } 
			[DataMember]
			public String IBAN { get; set; } 
			[DataMember]
			public String BankName { get; set; } 
			[DataMember]
			public String BIC { get; set; } 
			[DataMember]
			public String ZIP { get; set; } 
			[DataMember]
			public String City { get; set; } 
			[DataMember]
			public String StreetName { get; set; } 
			[DataMember]
			public String StreetNumber { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_DO_GPDoT_2040_Array cls_Get_Practice_Details_on_Tenant(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_DO_GPDoT_2040_Array invocationResult = cls_Get_Practice_Details_on_Tenant.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

