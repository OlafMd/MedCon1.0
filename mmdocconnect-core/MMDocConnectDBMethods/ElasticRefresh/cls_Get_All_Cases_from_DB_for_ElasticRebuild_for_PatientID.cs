/* 
 * Generated on 3/21/2017 10:06:46 AM
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

namespace MMDocConnectDBMethods.ElasticRefresh
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_All_Cases_from_DB_for_ElasticRebuild_for_PatientID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_All_Cases_from_DB_for_ElasticRebuild_for_PatientID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_ER_GACfDBfERfPID_1722_Array Execute(DbConnection Connection,DbTransaction Transaction,P_ER_GACfDBfERfPID_1722 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_ER_GACfDBfERfPID_1722_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.ElasticRefresh.SQL.cls_Get_All_Cases_from_DB_for_ElasticRebuild_for_PatientID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@PatientIDs"," IN $$PatientIDs$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$PatientIDs$",Parameter.PatientIDs);


			List<ER_GACfDBfERfPID_1722> results = new List<ER_GACfDBfERfPID_1722>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "treatment_date","drug_name","localization","diagnose_name","treatment_doctor_name","aftercare_bpt","is_treatment_cancelled","is_treatment_performed","order_header_id","treatment_doctor_id","diagnose_id","hec_drug_id","case_id","patient_id","practice_id","treatment_doctor_lanr","order_delivery_date","order_status","order_delivery_time_from","order_delivery_time_to","order_modification_timestamp","aftercare_planned_action_id","treatment_planned_action_id","case_number","is_aftercare_cancelled","pharmacy_supplier_id" });
				while(reader.Read())
				{
					ER_GACfDBfERfPID_1722 resultItem = new ER_GACfDBfERfPID_1722();
					//0:Parameter treatment_date of type DateTime
					resultItem.treatment_date = reader.GetDate(0);
					//1:Parameter drug_name of type String
					resultItem.drug_name = reader.GetString(1);
					//2:Parameter localization of type String
					resultItem.localization = reader.GetString(2);
					//3:Parameter diagnose_name of type String
					resultItem.diagnose_name = reader.GetString(3);
					//4:Parameter treatment_doctor_name of type String
					resultItem.treatment_doctor_name = reader.GetString(4);
					//5:Parameter aftercare_bpt of type Guid
					resultItem.aftercare_bpt = reader.GetGuid(5);
					//6:Parameter is_treatment_cancelled of type Boolean
					resultItem.is_treatment_cancelled = reader.GetBoolean(6);
					//7:Parameter is_treatment_performed of type Boolean
					resultItem.is_treatment_performed = reader.GetBoolean(7);
					//8:Parameter order_header_id of type Guid
					resultItem.order_header_id = reader.GetGuid(8);
					//9:Parameter treatment_doctor_id of type Guid
					resultItem.treatment_doctor_id = reader.GetGuid(9);
					//10:Parameter diagnose_id of type Guid
					resultItem.diagnose_id = reader.GetGuid(10);
					//11:Parameter hec_drug_id of type Guid
					resultItem.hec_drug_id = reader.GetGuid(11);
					//12:Parameter case_id of type Guid
					resultItem.case_id = reader.GetGuid(12);
					//13:Parameter patient_id of type Guid
					resultItem.patient_id = reader.GetGuid(13);
					//14:Parameter practice_id of type Guid
					resultItem.practice_id = reader.GetGuid(14);
					//15:Parameter treatment_doctor_lanr of type String
					resultItem.treatment_doctor_lanr = reader.GetString(15);
					//16:Parameter order_delivery_date of type DateTime
					resultItem.order_delivery_date = reader.GetDate(16);
					//17:Parameter order_status of type int
					resultItem.order_status = reader.GetInteger(17);
					//18:Parameter order_delivery_time_from of type DateTime
					resultItem.order_delivery_time_from = reader.GetDate(18);
					//19:Parameter order_delivery_time_to of type DateTime
					resultItem.order_delivery_time_to = reader.GetDate(19);
					//20:Parameter order_modification_timestamp of type DateTime
					resultItem.order_modification_timestamp = reader.GetDate(20);
					//21:Parameter aftercare_planned_action_id of type Guid
					resultItem.aftercare_planned_action_id = reader.GetGuid(21);
					//22:Parameter treatment_planned_action_id of type Guid
					resultItem.treatment_planned_action_id = reader.GetGuid(22);
					//23:Parameter case_number of type String
					resultItem.case_number = reader.GetString(23);
					//24:Parameter is_aftercare_cancelled of type Boolean
					resultItem.is_aftercare_cancelled = reader.GetBoolean(24);
					//25:Parameter pharmacy_supplier_id of type Guid
					resultItem.pharmacy_supplier_id = reader.GetGuid(25);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_All_Cases_from_DB_for_ElasticRebuild_for_PatientID",ex);
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
		public static FR_ER_GACfDBfERfPID_1722_Array Invoke(string ConnectionString,P_ER_GACfDBfERfPID_1722 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_ER_GACfDBfERfPID_1722_Array Invoke(DbConnection Connection,P_ER_GACfDBfERfPID_1722 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_ER_GACfDBfERfPID_1722_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_ER_GACfDBfERfPID_1722 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_ER_GACfDBfERfPID_1722_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_ER_GACfDBfERfPID_1722 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_ER_GACfDBfERfPID_1722_Array functionReturn = new FR_ER_GACfDBfERfPID_1722_Array();
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

				throw new Exception("Exception occured in method cls_Get_All_Cases_from_DB_for_ElasticRebuild_for_PatientID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_ER_GACfDBfERfPID_1722_Array : FR_Base
	{
		public ER_GACfDBfERfPID_1722[] Result	{ get; set; } 
		public FR_ER_GACfDBfERfPID_1722_Array() : base() {}

		public FR_ER_GACfDBfERfPID_1722_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_ER_GACfDBfERfPID_1722 for attribute P_ER_GACfDBfERfPID_1722
		[DataContract]
		public class P_ER_GACfDBfERfPID_1722 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] PatientIDs { get; set; } 

		}
		#endregion
		#region SClass ER_GACfDBfERfPID_1722 for attribute ER_GACfDBfERfPID_1722
		[DataContract]
		public class ER_GACfDBfERfPID_1722 
		{
			//Standard type parameters
			[DataMember]
			public DateTime treatment_date { get; set; } 
			[DataMember]
			public String drug_name { get; set; } 
			[DataMember]
			public String localization { get; set; } 
			[DataMember]
			public String diagnose_name { get; set; } 
			[DataMember]
			public String treatment_doctor_name { get; set; } 
			[DataMember]
			public Guid aftercare_bpt { get; set; } 
			[DataMember]
			public Boolean is_treatment_cancelled { get; set; } 
			[DataMember]
			public Boolean is_treatment_performed { get; set; } 
			[DataMember]
			public Guid order_header_id { get; set; } 
			[DataMember]
			public Guid treatment_doctor_id { get; set; } 
			[DataMember]
			public Guid diagnose_id { get; set; } 
			[DataMember]
			public Guid hec_drug_id { get; set; } 
			[DataMember]
			public Guid case_id { get; set; } 
			[DataMember]
			public Guid patient_id { get; set; } 
			[DataMember]
			public Guid practice_id { get; set; } 
			[DataMember]
			public String treatment_doctor_lanr { get; set; } 
			[DataMember]
			public DateTime order_delivery_date { get; set; } 
			[DataMember]
			public int order_status { get; set; } 
			[DataMember]
			public DateTime order_delivery_time_from { get; set; } 
			[DataMember]
			public DateTime order_delivery_time_to { get; set; } 
			[DataMember]
			public DateTime order_modification_timestamp { get; set; } 
			[DataMember]
			public Guid aftercare_planned_action_id { get; set; } 
			[DataMember]
			public Guid treatment_planned_action_id { get; set; } 
			[DataMember]
			public String case_number { get; set; } 
			[DataMember]
			public Boolean is_aftercare_cancelled { get; set; } 
			[DataMember]
			public Guid pharmacy_supplier_id { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_ER_GACfDBfERfPID_1722_Array cls_Get_All_Cases_from_DB_for_ElasticRebuild_for_PatientID(,P_ER_GACfDBfERfPID_1722 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_ER_GACfDBfERfPID_1722_Array invocationResult = cls_Get_All_Cases_from_DB_for_ElasticRebuild_for_PatientID.Invoke(connectionString,P_ER_GACfDBfERfPID_1722 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.ElasticRefresh.P_ER_GACfDBfERfPID_1722();
parameter.PatientIDs = ...;

*/
