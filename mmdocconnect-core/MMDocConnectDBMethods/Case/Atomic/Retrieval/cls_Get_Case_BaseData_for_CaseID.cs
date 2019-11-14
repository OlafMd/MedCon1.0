/* 
 * Generated on 12/19/16 08:47:03
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

namespace MMDocConnectDBMethods.Case.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Case_BaseData_for_CaseID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Case_BaseData_for_CaseID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_CAS_GCBDfCID_1054 Execute(DbConnection Connection,DbTransaction Transaction,P_CAS_GCBDfCID_1054 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_CAS_GCBDfCID_1054();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.Case.Atomic.Retrieval.SQL.cls_Get_Case_BaseData_for_CaseID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CaseID", Parameter.CaseID);



			List<CAS_GCBDfCID_1054> results = new List<CAS_GCBDfCID_1054>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "case_id","drug_id","treatment_date","drug_order_position_id","treatment_planned_action_id","treatment_doctor_bpt_id","practice_id","case_number","patient_id","patient_display_name","patient_first_name","patient_last_name","patient_gender","patient_birthdate","patient_age" });
				while(reader.Read())
				{
					CAS_GCBDfCID_1054 resultItem = new CAS_GCBDfCID_1054();
					//0:Parameter case_id of type Guid
					resultItem.case_id = reader.GetGuid(0);
					//1:Parameter drug_id of type Guid
					resultItem.drug_id = reader.GetGuid(1);
					//2:Parameter treatment_date of type DateTime
					resultItem.treatment_date = reader.GetDate(2);
					//3:Parameter drug_order_position_id of type Guid
					resultItem.drug_order_position_id = reader.GetGuid(3);
					//4:Parameter treatment_planned_action_id of type Guid
					resultItem.treatment_planned_action_id = reader.GetGuid(4);
					//5:Parameter treatment_doctor_bpt_id of type Guid
					resultItem.treatment_doctor_bpt_id = reader.GetGuid(5);
					//6:Parameter practice_id of type Guid
					resultItem.practice_id = reader.GetGuid(6);
					//7:Parameter case_number of type String
					resultItem.case_number = reader.GetString(7);
					//8:Parameter patient_id of type Guid
					resultItem.patient_id = reader.GetGuid(8);
					//9:Parameter patient_display_name of type String
					resultItem.patient_display_name = reader.GetString(9);
					//10:Parameter patient_first_name of type String
					resultItem.patient_first_name = reader.GetString(10);
					//11:Parameter patient_last_name of type String
					resultItem.patient_last_name = reader.GetString(11);
					//12:Parameter patient_gender of type int
					resultItem.patient_gender = reader.GetInteger(12);
					//13:Parameter patient_birthdate of type DateTime
					resultItem.patient_birthdate = reader.GetDate(13);
					//14:Parameter patient_age of type int
					resultItem.patient_age = reader.GetInteger(14);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Case_BaseData_for_CaseID",ex);
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
		public static FR_CAS_GCBDfCID_1054 Invoke(string ConnectionString,P_CAS_GCBDfCID_1054 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_CAS_GCBDfCID_1054 Invoke(DbConnection Connection,P_CAS_GCBDfCID_1054 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_CAS_GCBDfCID_1054 Invoke(DbConnection Connection, DbTransaction Transaction,P_CAS_GCBDfCID_1054 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_CAS_GCBDfCID_1054 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_CAS_GCBDfCID_1054 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_CAS_GCBDfCID_1054 functionReturn = new FR_CAS_GCBDfCID_1054();
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

				throw new Exception("Exception occured in method cls_Get_Case_BaseData_for_CaseID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_CAS_GCBDfCID_1054 : FR_Base
	{
		public CAS_GCBDfCID_1054 Result	{ get; set; }

		public FR_CAS_GCBDfCID_1054() : base() {}

		public FR_CAS_GCBDfCID_1054(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_CAS_GCBDfCID_1054 for attribute P_CAS_GCBDfCID_1054
		[DataContract]
		public class P_CAS_GCBDfCID_1054 
		{
			//Standard type parameters
			[DataMember]
			public Guid CaseID { get; set; } 

		}
		#endregion
		#region SClass CAS_GCBDfCID_1054 for attribute CAS_GCBDfCID_1054
		[DataContract]
		public class CAS_GCBDfCID_1054 
		{
			//Standard type parameters
			[DataMember]
			public Guid case_id { get; set; } 
			[DataMember]
			public Guid drug_id { get; set; } 
			[DataMember]
			public DateTime treatment_date { get; set; } 
			[DataMember]
			public Guid drug_order_position_id { get; set; } 
			[DataMember]
			public Guid treatment_planned_action_id { get; set; } 
			[DataMember]
			public Guid treatment_doctor_bpt_id { get; set; } 
			[DataMember]
			public Guid practice_id { get; set; } 
			[DataMember]
			public String case_number { get; set; } 
			[DataMember]
			public Guid patient_id { get; set; } 
			[DataMember]
			public String patient_display_name { get; set; } 
			[DataMember]
			public String patient_first_name { get; set; } 
			[DataMember]
			public String patient_last_name { get; set; } 
			[DataMember]
			public int patient_gender { get; set; } 
			[DataMember]
			public DateTime patient_birthdate { get; set; } 
			[DataMember]
			public int patient_age { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_CAS_GCBDfCID_1054 cls_Get_Case_BaseData_for_CaseID(,P_CAS_GCBDfCID_1054 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_CAS_GCBDfCID_1054 invocationResult = cls_Get_Case_BaseData_for_CaseID.Invoke(connectionString,P_CAS_GCBDfCID_1054 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Case.Atomic.Retrieval.P_CAS_GCBDfCID_1054();
parameter.CaseID = ...;

*/
