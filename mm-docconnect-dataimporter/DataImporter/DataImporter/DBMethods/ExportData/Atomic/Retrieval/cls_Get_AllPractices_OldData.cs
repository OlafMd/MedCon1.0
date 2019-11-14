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
    /// var result = cls_Get_AllPractices_OldData.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_AllPractices_OldData
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_ED_GAPOD_1624_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_ED_GAPOD_1624_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "DataImporter.DBMethods.ExportData.Atomic.Retrieval.SQL.cls_Get_AllPractices_OldData.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<ED_GAPOD_1624> results = new List<ED_GAPOD_1624>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "PracticeName","Street_Name","Street_Number","ZIP","Town","PracticeEmail","BSNR","Region_Name","Contact_Website_URL","Contact_EmergencyPhoneNumber","ContactPersonFirstName","ContactPersonLastName","ContactPersonEmail","ContactPersonPhone" });
				while(reader.Read())
				{
					ED_GAPOD_1624 resultItem = new ED_GAPOD_1624();
					//0:Parameter PracticeName of type String
					resultItem.PracticeName = reader.GetString(0);
					//1:Parameter Street_Name of type String
					resultItem.Street_Name = reader.GetString(1);
					//2:Parameter Street_Number of type String
					resultItem.Street_Number = reader.GetString(2);
					//3:Parameter ZIP of type String
					resultItem.ZIP = reader.GetString(3);
					//4:Parameter Town of type String
					resultItem.Town = reader.GetString(4);
					//5:Parameter PracticeEmail of type String
					resultItem.PracticeEmail = reader.GetString(5);
					//6:Parameter BSNR of type String
					resultItem.BSNR = reader.GetString(6);
					//7:Parameter Region_Name of type String
					resultItem.Region_Name = reader.GetString(7);
					//8:Parameter Contact_Website_URL of type String
					resultItem.Contact_Website_URL = reader.GetString(8);
					//9:Parameter Contact_EmergencyPhoneNumber of type String
					resultItem.Contact_EmergencyPhoneNumber = reader.GetString(9);
					//10:Parameter ContactPersonFirstName of type String
					resultItem.ContactPersonFirstName = reader.GetString(10);
					//11:Parameter ContactPersonLastName of type String
					resultItem.ContactPersonLastName = reader.GetString(11);
					//12:Parameter ContactPersonEmail of type String
					resultItem.ContactPersonEmail = reader.GetString(12);
					//13:Parameter ContactPersonPhone of type String
					resultItem.ContactPersonPhone = reader.GetString(13);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_AllPractices_OldData",ex);
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
		public static FR_ED_GAPOD_1624_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_ED_GAPOD_1624_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_ED_GAPOD_1624_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_ED_GAPOD_1624_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_ED_GAPOD_1624_Array functionReturn = new FR_ED_GAPOD_1624_Array();
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

				throw new Exception("Exception occured in method cls_Get_AllPractices_OldData",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_ED_GAPOD_1624_Array : FR_Base
	{
		public ED_GAPOD_1624[] Result	{ get; set; } 
		public FR_ED_GAPOD_1624_Array() : base() {}

		public FR_ED_GAPOD_1624_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass ED_GAPOD_1624 for attribute ED_GAPOD_1624
		[DataContract]
		public class ED_GAPOD_1624 
		{
			//Standard type parameters
			[DataMember]
			public String PracticeName { get; set; } 
			[DataMember]
			public String Street_Name { get; set; } 
			[DataMember]
			public String Street_Number { get; set; } 
			[DataMember]
			public String ZIP { get; set; } 
			[DataMember]
			public String Town { get; set; } 
			[DataMember]
			public String PracticeEmail { get; set; } 
			[DataMember]
			public String BSNR { get; set; } 
			[DataMember]
			public String Region_Name { get; set; } 
			[DataMember]
			public String Contact_Website_URL { get; set; } 
			[DataMember]
			public String Contact_EmergencyPhoneNumber { get; set; } 
			[DataMember]
			public String ContactPersonFirstName { get; set; } 
			[DataMember]
			public String ContactPersonLastName { get; set; } 
			[DataMember]
			public String ContactPersonEmail { get; set; } 
			[DataMember]
			public String ContactPersonPhone { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_ED_GAPOD_1624_Array cls_Get_AllPractices_OldData(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_ED_GAPOD_1624_Array invocationResult = cls_Get_AllPractices_OldData.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

