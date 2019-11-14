/* 
 * Generated on 1/20/2017 2:34:27 PM
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
    /// var result = cls_Get_All_Practices_from_DB.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_All_Practices_from_DB
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_DO_GAPDB_1430_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_DO_GAPDB_1430_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "DataImporter.DBMethods.ExportData.Atomic.Retrieval.SQL.cls_Get_All_Practices_from_DB.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<DO_GAPDB_1430> results = new List<DO_GAPDB_1430>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "PracticeID","AccountID","BankAccountID","Name","City","BSNR","ZIP","Street_Number","Street_Name","Contact_Telephone","Contact_Email","BankName","BICCode","IBAN","AccountHolder","IsSurgeryPractice" });
				while(reader.Read())
				{
					DO_GAPDB_1430 resultItem = new DO_GAPDB_1430();
					//0:Parameter PracticeID of type Guid
					resultItem.PracticeID = reader.GetGuid(0);
					//1:Parameter AccountID of type Guid
					resultItem.AccountID = reader.GetGuid(1);
					//2:Parameter BankAccountID of type Guid
					resultItem.BankAccountID = reader.GetGuid(2);
					//3:Parameter Name of type String
					resultItem.Name = reader.GetString(3);
					//4:Parameter City of type String
					resultItem.City = reader.GetString(4);
					//5:Parameter BSNR of type String
					resultItem.BSNR = reader.GetString(5);
					//6:Parameter ZIP of type String
					resultItem.ZIP = reader.GetString(6);
					//7:Parameter Street_Number of type String
					resultItem.Street_Number = reader.GetString(7);
					//8:Parameter Street_Name of type String
					resultItem.Street_Name = reader.GetString(8);
					//9:Parameter Contact_Telephone of type String
					resultItem.Contact_Telephone = reader.GetString(9);
					//10:Parameter Contact_Email of type String
					resultItem.Contact_Email = reader.GetString(10);
					//11:Parameter BankName of type String
					resultItem.BankName = reader.GetString(11);
					//12:Parameter BICCode of type String
					resultItem.BICCode = reader.GetString(12);
					//13:Parameter IBAN of type String
					resultItem.IBAN = reader.GetString(13);
					//14:Parameter AccountHolder of type String
					resultItem.AccountHolder = reader.GetString(14);
					//15:Parameter IsSurgeryPractice of type bool
					resultItem.IsSurgeryPractice = reader.GetBoolean(15);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_All_Practices_from_DB",ex);
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
		public static FR_DO_GAPDB_1430_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_DO_GAPDB_1430_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_DO_GAPDB_1430_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_DO_GAPDB_1430_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_DO_GAPDB_1430_Array functionReturn = new FR_DO_GAPDB_1430_Array();
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

				throw new Exception("Exception occured in method cls_Get_All_Practices_from_DB",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_DO_GAPDB_1430_Array : FR_Base
	{
		public DO_GAPDB_1430[] Result	{ get; set; } 
		public FR_DO_GAPDB_1430_Array() : base() {}

		public FR_DO_GAPDB_1430_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass DO_GAPDB_1430 for attribute DO_GAPDB_1430
		[DataContract]
		public class DO_GAPDB_1430 
		{
			//Standard type parameters
			[DataMember]
			public Guid PracticeID { get; set; } 
			[DataMember]
			public Guid AccountID { get; set; } 
			[DataMember]
			public Guid BankAccountID { get; set; } 
			[DataMember]
			public String Name { get; set; } 
			[DataMember]
			public String City { get; set; } 
			[DataMember]
			public String BSNR { get; set; } 
			[DataMember]
			public String ZIP { get; set; } 
			[DataMember]
			public String Street_Number { get; set; } 
			[DataMember]
			public String Street_Name { get; set; } 
			[DataMember]
			public String Contact_Telephone { get; set; } 
			[DataMember]
			public String Contact_Email { get; set; } 
			[DataMember]
			public String BankName { get; set; } 
			[DataMember]
			public String BICCode { get; set; } 
			[DataMember]
			public String IBAN { get; set; } 
			[DataMember]
			public String AccountHolder { get; set; } 
			[DataMember]
			public bool IsSurgeryPractice { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_DO_GAPDB_1430_Array cls_Get_All_Practices_from_DB(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_DO_GAPDB_1430_Array invocationResult = cls_Get_All_Practices_from_DB.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

