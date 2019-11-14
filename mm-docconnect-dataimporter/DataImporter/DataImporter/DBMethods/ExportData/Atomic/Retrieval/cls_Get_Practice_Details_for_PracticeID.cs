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
    /// var result = cls_Get_Practice_Details_for_PracticeID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Practice_Details_for_PracticeID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_DO_GPDfPID_1432_Array Execute(DbConnection Connection,DbTransaction Transaction,P_DO_GPDfPID_1432 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_DO_GPDfPID_1432_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "DataImporter.DBMethods.ExportData.Atomic.Retrieval.SQL.cls_Get_Practice_Details_for_PracticeID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PracticeID", Parameter.PracticeID);



			List<DO_GPDfPID_1432> results = new List<DO_GPDfPID_1432>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "practiceID","practice_BSNR","is_company","practice_name","practice_address","practice_town","contact_email","contact_telephone","contact_fax","contact_person_name","practice_IBAN","account_holder","practice_bank_name","practice_bank_BIC","IsValue_String","IsValue_Number","IsValue_Boolean","PropertyName","Value_String","Value_Number","Value_Boolean" });
				while(reader.Read())
				{
					DO_GPDfPID_1432 resultItem = new DO_GPDfPID_1432();
					//0:Parameter practiceID of type Guid
					resultItem.practiceID = reader.GetGuid(0);
					//1:Parameter practice_BSNR of type String
					resultItem.practice_BSNR = reader.GetString(1);
					//2:Parameter is_company of type Boolean
					resultItem.is_company = reader.GetBoolean(2);
					//3:Parameter practice_name of type String
					resultItem.practice_name = reader.GetString(3);
					//4:Parameter practice_address of type String
					resultItem.practice_address = reader.GetString(4);
					//5:Parameter practice_town of type String
					resultItem.practice_town = reader.GetString(5);
					//6:Parameter contact_email of type String
					resultItem.contact_email = reader.GetString(6);
					//7:Parameter contact_telephone of type String
					resultItem.contact_telephone = reader.GetString(7);
					//8:Parameter contact_fax of type String
					resultItem.contact_fax = reader.GetString(8);
					//9:Parameter contact_person_name of type String
					resultItem.contact_person_name = reader.GetString(9);
					//10:Parameter practice_IBAN of type String
					resultItem.practice_IBAN = reader.GetString(10);
					//11:Parameter account_holder of type String
					resultItem.account_holder = reader.GetString(11);
					//12:Parameter practice_bank_name of type String
					resultItem.practice_bank_name = reader.GetString(12);
					//13:Parameter practice_bank_BIC of type String
					resultItem.practice_bank_BIC = reader.GetString(13);
					//14:Parameter IsValue_String of type Boolean
					resultItem.IsValue_String = reader.GetBoolean(14);
					//15:Parameter IsValue_Number of type Boolean
					resultItem.IsValue_Number = reader.GetBoolean(15);
					//16:Parameter IsValue_Boolean of type Boolean
					resultItem.IsValue_Boolean = reader.GetBoolean(16);
					//17:Parameter PropertyName of type String
					resultItem.PropertyName = reader.GetString(17);
					//18:Parameter Value_String of type String
					resultItem.Value_String = reader.GetString(18);
					//19:Parameter Value_Number of type int
					resultItem.Value_Number = reader.GetInteger(19);
					//20:Parameter Value_Boolean of type Boolean
					resultItem.Value_Boolean = reader.GetBoolean(20);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Practice_Details_for_PracticeID",ex);
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
		public static FR_DO_GPDfPID_1432_Array Invoke(string ConnectionString,P_DO_GPDfPID_1432 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_DO_GPDfPID_1432_Array Invoke(DbConnection Connection,P_DO_GPDfPID_1432 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_DO_GPDfPID_1432_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_DO_GPDfPID_1432 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_DO_GPDfPID_1432_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_DO_GPDfPID_1432 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_DO_GPDfPID_1432_Array functionReturn = new FR_DO_GPDfPID_1432_Array();
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

				throw new Exception("Exception occured in method cls_Get_Practice_Details_for_PracticeID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_DO_GPDfPID_1432_Array : FR_Base
	{
		public DO_GPDfPID_1432[] Result	{ get; set; } 
		public FR_DO_GPDfPID_1432_Array() : base() {}

		public FR_DO_GPDfPID_1432_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_DO_GPDfPID_1432 for attribute P_DO_GPDfPID_1432
		[DataContract]
		public class P_DO_GPDfPID_1432 
		{
			//Standard type parameters
			[DataMember]
			public Guid PracticeID { get; set; } 

		}
		#endregion
		#region SClass DO_GPDfPID_1432 for attribute DO_GPDfPID_1432
		[DataContract]
		public class DO_GPDfPID_1432 
		{
			//Standard type parameters
			[DataMember]
			public Guid practiceID { get; set; } 
			[DataMember]
			public String practice_BSNR { get; set; } 
			[DataMember]
			public Boolean is_company { get; set; } 
			[DataMember]
			public String practice_name { get; set; } 
			[DataMember]
			public String practice_address { get; set; } 
			[DataMember]
			public String practice_town { get; set; } 
			[DataMember]
			public String contact_email { get; set; } 
			[DataMember]
			public String contact_telephone { get; set; } 
			[DataMember]
			public String contact_fax { get; set; } 
			[DataMember]
			public String contact_person_name { get; set; } 
			[DataMember]
			public String practice_IBAN { get; set; } 
			[DataMember]
			public String account_holder { get; set; } 
			[DataMember]
			public String practice_bank_name { get; set; } 
			[DataMember]
			public String practice_bank_BIC { get; set; } 
			[DataMember]
			public Boolean IsValue_String { get; set; } 
			[DataMember]
			public Boolean IsValue_Number { get; set; } 
			[DataMember]
			public Boolean IsValue_Boolean { get; set; } 
			[DataMember]
			public String PropertyName { get; set; } 
			[DataMember]
			public String Value_String { get; set; } 
			[DataMember]
			public int Value_Number { get; set; } 
			[DataMember]
			public Boolean Value_Boolean { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_DO_GPDfPID_1432_Array cls_Get_Practice_Details_for_PracticeID(,P_DO_GPDfPID_1432 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_DO_GPDfPID_1432_Array invocationResult = cls_Get_Practice_Details_for_PracticeID.Invoke(connectionString,P_DO_GPDfPID_1432 Parameter,securityTicket);
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
var parameter = new DataImporter.DBMethods.ExportData.Atomic.Retrieval.P_DO_GPDfPID_1432();
parameter.PracticeID = ...;

*/
