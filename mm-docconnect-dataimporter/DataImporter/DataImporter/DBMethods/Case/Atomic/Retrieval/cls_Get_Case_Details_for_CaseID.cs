/* 
 * Generated on 2/3/2017 3:58:00 PM
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

namespace DataImporter.DBMethods.Case.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Case_Details_for_CaseID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Case_Details_for_CaseID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_CAS_GCDfCID_1435 Execute(DbConnection Connection,DbTransaction Transaction,P_CAS_GCDfCID_1435 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_CAS_GCDfCID_1435();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "DataImporter.DBMethods.Case.Atomic.Retrieval.SQL.cls_Get_Case_Details_for_CaseID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CaseID", Parameter.CaseID);



			List<CAS_GCDfCID_1435> results = new List<CAS_GCDfCID_1435>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "patient_id","case_id","patient_display_name","treatment_date","drug_id","is_patient_fee_waived","is_label_only","is_send_invoice_to_practice","order_id","alternative_delivery_date_from","alternative_delivery_date_to","delivery_date","diagnose_id","localization","is_confirmed","op_doctor_id","ac_doctor_id","ac_practice_id","is_aftercare_doctor","is_aftercare_practice","aftercare_doctor_display_name","aftercare_practice_display_name","order_status_code","Patient_FirstName","Patient_LastName","Patient_Gender","Patient_Age","Patient_BirthDate","treatment_doctor_id","order_modification_timestamp","practice_id","case_status","aftercare_planned_action_id","treatment_planned_action_id","aftercare_doctors_practice_id","aftercare_performed_date","pharmacy_supplier_id" });
				while(reader.Read())
				{
					CAS_GCDfCID_1435 resultItem = new CAS_GCDfCID_1435();
					//0:Parameter patient_id of type Guid
					resultItem.patient_id = reader.GetGuid(0);
					//1:Parameter case_id of type Guid
					resultItem.case_id = reader.GetGuid(1);
					//2:Parameter patient_display_name of type String
					resultItem.patient_display_name = reader.GetString(2);
					//3:Parameter treatment_date of type DateTime
					resultItem.treatment_date = reader.GetDate(3);
					//4:Parameter drug_id of type Guid
					resultItem.drug_id = reader.GetGuid(4);
					//5:Parameter is_patient_fee_waived of type Boolean
					resultItem.is_patient_fee_waived = reader.GetBoolean(5);
					//6:Parameter is_label_only of type Boolean
					resultItem.is_label_only = reader.GetBoolean(6);
					//7:Parameter is_send_invoice_to_practice of type Boolean
					resultItem.is_send_invoice_to_practice = reader.GetBoolean(7);
					//8:Parameter order_id of type Guid
					resultItem.order_id = reader.GetGuid(8);
					//9:Parameter alternative_delivery_date_from of type DateTime
					resultItem.alternative_delivery_date_from = reader.GetDate(9);
					//10:Parameter alternative_delivery_date_to of type DateTime
					resultItem.alternative_delivery_date_to = reader.GetDate(10);
					//11:Parameter delivery_date of type DateTime
					resultItem.delivery_date = reader.GetDate(11);
					//12:Parameter diagnose_id of type Guid
					resultItem.diagnose_id = reader.GetGuid(12);
					//13:Parameter localization of type String
					resultItem.localization = reader.GetString(13);
					//14:Parameter is_confirmed of type Boolean
					resultItem.is_confirmed = reader.GetBoolean(14);
					//15:Parameter op_doctor_id of type Guid
					resultItem.op_doctor_id = reader.GetGuid(15);
					//16:Parameter ac_doctor_id of type Guid
					resultItem.ac_doctor_id = reader.GetGuid(16);
					//17:Parameter ac_practice_id of type Guid
					resultItem.ac_practice_id = reader.GetGuid(17);
					//18:Parameter is_aftercare_doctor of type Boolean
					resultItem.is_aftercare_doctor = reader.GetBoolean(18);
					//19:Parameter is_aftercare_practice of type Boolean
					resultItem.is_aftercare_practice = reader.GetBoolean(19);
					//20:Parameter aftercare_doctor_display_name of type String
					resultItem.aftercare_doctor_display_name = reader.GetString(20);
					//21:Parameter aftercare_practice_display_name of type String
					resultItem.aftercare_practice_display_name = reader.GetString(21);
					//22:Parameter order_status_code of type int
					resultItem.order_status_code = reader.GetInteger(22);
					//23:Parameter Patient_FirstName of type String
					resultItem.Patient_FirstName = reader.GetString(23);
					//24:Parameter Patient_LastName of type String
					resultItem.Patient_LastName = reader.GetString(24);
					//25:Parameter Patient_Gender of type int
					resultItem.Patient_Gender = reader.GetInteger(25);
					//26:Parameter Patient_Age of type int
					resultItem.Patient_Age = reader.GetInteger(26);
					//27:Parameter Patient_BirthDate of type DateTime
					resultItem.Patient_BirthDate = reader.GetDate(27);
					//28:Parameter treatment_doctor_id of type Guid
					resultItem.treatment_doctor_id = reader.GetGuid(28);
					//29:Parameter order_modification_timestamp of type DateTime
					resultItem.order_modification_timestamp = reader.GetDate(29);
					//30:Parameter practice_id of type Guid
					resultItem.practice_id = reader.GetGuid(30);
					//31:Parameter case_status of type String
					resultItem.case_status = reader.GetString(31);
					//32:Parameter aftercare_planned_action_id of type Guid
					resultItem.aftercare_planned_action_id = reader.GetGuid(32);
					//33:Parameter treatment_planned_action_id of type Guid
					resultItem.treatment_planned_action_id = reader.GetGuid(33);
					//34:Parameter aftercare_doctors_practice_id of type Guid
					resultItem.aftercare_doctors_practice_id = reader.GetGuid(34);
					//35:Parameter aftercare_performed_date of type DateTime
					resultItem.aftercare_performed_date = reader.GetDate(35);
					//36:Parameter pharmacy_supplier_id of type Guid
					resultItem.pharmacy_supplier_id = reader.GetGuid(36);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Case_Details_for_CaseID",ex);
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
		public static FR_CAS_GCDfCID_1435 Invoke(string ConnectionString,P_CAS_GCDfCID_1435 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_CAS_GCDfCID_1435 Invoke(DbConnection Connection,P_CAS_GCDfCID_1435 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_CAS_GCDfCID_1435 Invoke(DbConnection Connection, DbTransaction Transaction,P_CAS_GCDfCID_1435 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_CAS_GCDfCID_1435 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_CAS_GCDfCID_1435 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_CAS_GCDfCID_1435 functionReturn = new FR_CAS_GCDfCID_1435();
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

				throw new Exception("Exception occured in method cls_Get_Case_Details_for_CaseID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_CAS_GCDfCID_1435 : FR_Base
	{
		public CAS_GCDfCID_1435 Result	{ get; set; }

		public FR_CAS_GCDfCID_1435() : base() {}

		public FR_CAS_GCDfCID_1435(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_CAS_GCDfCID_1435 for attribute P_CAS_GCDfCID_1435
		[DataContract]
		public class P_CAS_GCDfCID_1435 
		{
			//Standard type parameters
			[DataMember]
			public Guid CaseID { get; set; } 

		}
		#endregion
		#region SClass CAS_GCDfCID_1435 for attribute CAS_GCDfCID_1435
		[DataContract]
		public class CAS_GCDfCID_1435 
		{
			//Standard type parameters
			[DataMember]
			public Guid patient_id { get; set; } 
			[DataMember]
			public Guid case_id { get; set; } 
			[DataMember]
			public String patient_display_name { get; set; } 
			[DataMember]
			public DateTime treatment_date { get; set; } 
			[DataMember]
			public Guid drug_id { get; set; } 
			[DataMember]
			public Boolean is_patient_fee_waived { get; set; } 
			[DataMember]
			public Boolean is_label_only { get; set; } 
			[DataMember]
			public Boolean is_send_invoice_to_practice { get; set; } 
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
			public Boolean is_confirmed { get; set; } 
			[DataMember]
			public Guid op_doctor_id { get; set; } 
			[DataMember]
			public Guid ac_doctor_id { get; set; } 
			[DataMember]
			public Guid ac_practice_id { get; set; } 
			[DataMember]
			public Boolean is_aftercare_doctor { get; set; } 
			[DataMember]
			public Boolean is_aftercare_practice { get; set; } 
			[DataMember]
			public String aftercare_doctor_display_name { get; set; } 
			[DataMember]
			public String aftercare_practice_display_name { get; set; } 
			[DataMember]
			public int order_status_code { get; set; } 
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
			public Guid practice_id { get; set; } 
			[DataMember]
			public String case_status { get; set; } 
			[DataMember]
			public Guid aftercare_planned_action_id { get; set; } 
			[DataMember]
			public Guid treatment_planned_action_id { get; set; } 
			[DataMember]
			public Guid aftercare_doctors_practice_id { get; set; } 
			[DataMember]
			public DateTime aftercare_performed_date { get; set; } 
			[DataMember]
			public Guid pharmacy_supplier_id { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_CAS_GCDfCID_1435 cls_Get_Case_Details_for_CaseID(,P_CAS_GCDfCID_1435 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_CAS_GCDfCID_1435 invocationResult = cls_Get_Case_Details_for_CaseID.Invoke(connectionString,P_CAS_GCDfCID_1435 Parameter,securityTicket);
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
var parameter = new DataImporter.DBMethods.Case.Atomic.Retrieval.P_CAS_GCDfCID_1435();
parameter.CaseID = ...;

*/
