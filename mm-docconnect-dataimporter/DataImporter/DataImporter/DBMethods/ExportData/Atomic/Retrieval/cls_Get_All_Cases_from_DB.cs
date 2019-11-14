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
    /// var result = cls_Get_All_Cases_from_DB.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_All_Cases_from_DB
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_DO_GACfDB_1212_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_DO_GACfDB_1212_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "DataImporter.DBMethods.ExportData.Atomic.Retrieval.SQL.cls_Get_All_Cases_from_DB.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<DO_GACfDB_1212> results = new List<DO_GACfDB_1212>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "case_id","OrderHeaderID","patient_id","practice_id","treatment_date","drug_id","order_id","alternative_delivery_date_from","alternative_delivery_date_to","delivery_date","diagnose_id","localization","is_confirmed","op_doctor_id","ac_doctor_id","is_aftercare_doctor","is_aftercare_practice","aftercare_doctor_display_name","aftercare_practice_display_name","Patient_FirstName","Patient_LastName","Patient_Gender","Patient_Age","Patient_BirthDate","treatment_doctor_id","order_modification_timestamp","case_status" });
				while(reader.Read())
				{
					DO_GACfDB_1212 resultItem = new DO_GACfDB_1212();
					//0:Parameter case_id of type Guid
					resultItem.case_id = reader.GetGuid(0);
					//1:Parameter OrderHeaderID of type Guid
					resultItem.OrderHeaderID = reader.GetGuid(1);
					//2:Parameter patient_id of type Guid
					resultItem.patient_id = reader.GetGuid(2);
					//3:Parameter practice_id of type Guid
					resultItem.practice_id = reader.GetGuid(3);
					//4:Parameter treatment_date of type DateTime
					resultItem.treatment_date = reader.GetDate(4);
					//5:Parameter drug_id of type Guid
					resultItem.drug_id = reader.GetGuid(5);
					//6:Parameter order_id of type Guid
					resultItem.order_id = reader.GetGuid(6);
					//7:Parameter alternative_delivery_date_from of type DateTime
					resultItem.alternative_delivery_date_from = reader.GetDate(7);
					//8:Parameter alternative_delivery_date_to of type DateTime
					resultItem.alternative_delivery_date_to = reader.GetDate(8);
					//9:Parameter delivery_date of type DateTime
					resultItem.delivery_date = reader.GetDate(9);
					//10:Parameter diagnose_id of type Guid
					resultItem.diagnose_id = reader.GetGuid(10);
					//11:Parameter localization of type String
					resultItem.localization = reader.GetString(11);
					//12:Parameter is_confirmed of type bool
					resultItem.is_confirmed = reader.GetBoolean(12);
					//13:Parameter op_doctor_id of type Guid
					resultItem.op_doctor_id = reader.GetGuid(13);
					//14:Parameter ac_doctor_id of type Guid
					resultItem.ac_doctor_id = reader.GetGuid(14);
					//15:Parameter is_aftercare_doctor of type bool
					resultItem.is_aftercare_doctor = reader.GetBoolean(15);
					//16:Parameter is_aftercare_practice of type bool
					resultItem.is_aftercare_practice = reader.GetBoolean(16);
					//17:Parameter aftercare_doctor_display_name of type String
					resultItem.aftercare_doctor_display_name = reader.GetString(17);
					//18:Parameter aftercare_practice_display_name of type String
					resultItem.aftercare_practice_display_name = reader.GetString(18);
					//19:Parameter Patient_FirstName of type String
					resultItem.Patient_FirstName = reader.GetString(19);
					//20:Parameter Patient_LastName of type String
					resultItem.Patient_LastName = reader.GetString(20);
					//21:Parameter Patient_Gender of type int
					resultItem.Patient_Gender = reader.GetInteger(21);
					//22:Parameter Patient_Age of type int
					resultItem.Patient_Age = reader.GetInteger(22);
					//23:Parameter Patient_BirthDate of type DateTime
					resultItem.Patient_BirthDate = reader.GetDate(23);
					//24:Parameter treatment_doctor_id of type Guid
					resultItem.treatment_doctor_id = reader.GetGuid(24);
					//25:Parameter order_modification_timestamp of type DateTime
					resultItem.order_modification_timestamp = reader.GetDate(25);
					//26:Parameter case_status of type String
					resultItem.case_status = reader.GetString(26);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_All_Cases_from_DB",ex);
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
		public static FR_DO_GACfDB_1212_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_DO_GACfDB_1212_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_DO_GACfDB_1212_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_DO_GACfDB_1212_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_DO_GACfDB_1212_Array functionReturn = new FR_DO_GACfDB_1212_Array();
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

				throw new Exception("Exception occured in method cls_Get_All_Cases_from_DB",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_DO_GACfDB_1212_Array : FR_Base
	{
		public DO_GACfDB_1212[] Result	{ get; set; } 
		public FR_DO_GACfDB_1212_Array() : base() {}

		public FR_DO_GACfDB_1212_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass DO_GACfDB_1212 for attribute DO_GACfDB_1212
		[DataContract]
		public class DO_GACfDB_1212 
		{
			//Standard type parameters
			[DataMember]
			public Guid case_id { get; set; } 
			[DataMember]
			public Guid OrderHeaderID { get; set; } 
			[DataMember]
			public Guid patient_id { get; set; } 
			[DataMember]
			public Guid practice_id { get; set; } 
			[DataMember]
			public DateTime treatment_date { get; set; } 
			[DataMember]
			public Guid drug_id { get; set; } 
			[DataMember]
			public Guid order_id { get; set; } 
			[DataMember]
			public DateTime alternative_delivery_date_from { get; set; } 
			[DataMember]
			public DateTime alternative_delivery_date_to { get; set; } 
			[DataMember]
			public DateTime delivery_date { get; set; } 
			[DataMember]
			public Guid diagnose_id { get; set; } 
			[DataMember]
			public String localization { get; set; } 
			[DataMember]
			public bool is_confirmed { get; set; } 
			[DataMember]
			public Guid op_doctor_id { get; set; } 
			[DataMember]
			public Guid ac_doctor_id { get; set; } 
			[DataMember]
			public bool is_aftercare_doctor { get; set; } 
			[DataMember]
			public bool is_aftercare_practice { get; set; } 
			[DataMember]
			public String aftercare_doctor_display_name { get; set; } 
			[DataMember]
			public String aftercare_practice_display_name { get; set; } 
			[DataMember]
			public String Patient_FirstName { get; set; } 
			[DataMember]
			public String Patient_LastName { get; set; } 
			[DataMember]
			public int Patient_Gender { get; set; } 
			[DataMember]
			public int Patient_Age { get; set; } 
			[DataMember]
			public DateTime Patient_BirthDate { get; set; } 
			[DataMember]
			public Guid treatment_doctor_id { get; set; } 
			[DataMember]
			public DateTime order_modification_timestamp { get; set; } 
			[DataMember]
			public String case_status { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_DO_GACfDB_1212_Array cls_Get_All_Cases_from_DB(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_DO_GACfDB_1212_Array invocationResult = cls_Get_All_Cases_from_DB.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

