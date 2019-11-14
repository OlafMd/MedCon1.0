/* 
 * Generated on 20.8.2015 8:58:00
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
    /// var result = cls_Get_Practice_Details_for_Report.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Practice_Details_for_Report
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_DO_GPDFR_0840 Execute(DbConnection Connection,DbTransaction Transaction,P_DO_GPDFR_0840 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_DO_GPDFR_0840();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.Doctor.Atomic.Retrieval.SQL.cls_Get_Practice_Details_for_Report.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PracticeID", Parameter.PracticeID);



			List<DO_GPDFR_0840> results = new List<DO_GPDFR_0840>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "AccountID","BankAccountID","Name","City","BSNR","ZIP","Street_Number","Street_Name","Contact_Telephone","Contact_Email","BankName","BICCode","IBAN","AccountHolder","IsSurgeryPractice" });
				while(reader.Read())
				{
					DO_GPDFR_0840 resultItem = new DO_GPDFR_0840();
					//0:Parameter AccountID of type Guid
					resultItem.AccountID = reader.GetGuid(0);
					//1:Parameter BankAccountID of type Guid
					resultItem.BankAccountID = reader.GetGuid(1);
					//2:Parameter Name of type String
					resultItem.Name = reader.GetString(2);
					//3:Parameter City of type String
					resultItem.City = reader.GetString(3);
					//4:Parameter BSNR of type String
					resultItem.BSNR = reader.GetString(4);
					//5:Parameter ZIP of type String
					resultItem.ZIP = reader.GetString(5);
					//6:Parameter Street_Number of type String
					resultItem.Street_Number = reader.GetString(6);
					//7:Parameter Street_Name of type String
					resultItem.Street_Name = reader.GetString(7);
					//8:Parameter Contact_Telephone of type String
					resultItem.Contact_Telephone = reader.GetString(8);
					//9:Parameter Contact_Email of type String
					resultItem.Contact_Email = reader.GetString(9);
					//10:Parameter BankName of type String
					resultItem.BankName = reader.GetString(10);
					//11:Parameter BICCode of type String
					resultItem.BICCode = reader.GetString(11);
					//12:Parameter IBAN of type String
					resultItem.IBAN = reader.GetString(12);
					//13:Parameter AccountHolder of type String
					resultItem.AccountHolder = reader.GetString(13);
					//14:Parameter IsSurgeryPractice of type bool
					resultItem.IsSurgeryPractice = reader.GetBoolean(14);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Practice_Details_for_Report",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = results.FirstOrDefault();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_DO_GPDFR_0840 Invoke(string ConnectionString,P_DO_GPDFR_0840 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_DO_GPDFR_0840 Invoke(DbConnection Connection,P_DO_GPDFR_0840 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_DO_GPDFR_0840 Invoke(DbConnection Connection, DbTransaction Transaction,P_DO_GPDFR_0840 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_DO_GPDFR_0840 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_DO_GPDFR_0840 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_DO_GPDFR_0840 functionReturn = new FR_DO_GPDFR_0840();
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

				throw new Exception("Exception occured in method cls_Get_Practice_Details_for_Report",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_DO_GPDFR_0840 : FR_Base
	{
		public DO_GPDFR_0840 Result	{ get; set; }

		public FR_DO_GPDFR_0840() : base() {}

		public FR_DO_GPDFR_0840(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_DO_GPDFR_0840 for attribute P_DO_GPDFR_0840
		[DataContract]
		public class P_DO_GPDFR_0840 
		{
			//Standard type parameters
			[DataMember]
			public Guid PracticeID { get; set; } 

		}
		#endregion
		#region SClass DO_GPDFR_0840 for attribute DO_GPDFR_0840
		[DataContract]
		public class DO_GPDFR_0840 
		{
			//Standard type parameters
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
FR_DO_GPDFR_0840 cls_Get_Practice_Details_for_Report(,P_DO_GPDFR_0840 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_DO_GPDFR_0840 invocationResult = cls_Get_Practice_Details_for_Report.Invoke(connectionString,P_DO_GPDFR_0840 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Doctor.Atomic.Retrieval.P_DO_GPDFR_0840();
parameter.PracticeID = ...;

*/
