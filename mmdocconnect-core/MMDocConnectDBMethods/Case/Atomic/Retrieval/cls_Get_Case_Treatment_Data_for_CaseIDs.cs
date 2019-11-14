/* 
 * Generated on 4/5/2017 1:33:32 PM
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
    /// var result = cls_Get_Case_Treatment_Data_for_CaseIDs.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Case_Treatment_Data_for_CaseIDs
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_CAS_GCTDfCIDs_1624_Array Execute(DbConnection Connection,DbTransaction Transaction,P_CAS_GCTDfCIDs_1624 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_CAS_GCTDfCIDs_1624_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.Case.Atomic.Retrieval.SQL.cls_Get_Case_Treatment_Data_for_CaseIDs.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@CaseIDs"," IN $$CaseIDs$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$CaseIDs$",Parameter.CaseIDs);


			List<CAS_GCTDfCIDs_1624> results = new List<CAS_GCTDfCIDs_1624>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "localization","diagnose_id","is_confirmed","op_doctor_id","patient_id","case_id","drug_id","treatment_date","is_performed","planned_action_id" });
				while(reader.Read())
				{
					CAS_GCTDfCIDs_1624 resultItem = new CAS_GCTDfCIDs_1624();
					//0:Parameter localization of type String
					resultItem.localization = reader.GetString(0);
					//1:Parameter diagnose_id of type Guid
					resultItem.diagnose_id = reader.GetGuid(1);
					//2:Parameter is_confirmed of type Boolean
					resultItem.is_confirmed = reader.GetBoolean(2);
					//3:Parameter op_doctor_id of type Guid
					resultItem.op_doctor_id = reader.GetGuid(3);
					//4:Parameter patient_id of type Guid
					resultItem.patient_id = reader.GetGuid(4);
					//5:Parameter case_id of type Guid
					resultItem.case_id = reader.GetGuid(5);
					//6:Parameter drug_id of type Guid
					resultItem.drug_id = reader.GetGuid(6);
					//7:Parameter treatment_date of type DateTime
					resultItem.treatment_date = reader.GetDate(7);
					//8:Parameter is_performed of type Boolean
					resultItem.is_performed = reader.GetBoolean(8);
					//9:Parameter planned_action_id of type Guid
					resultItem.planned_action_id = reader.GetGuid(9);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Case_Treatment_Data_for_CaseIDs",ex);
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
		public static FR_CAS_GCTDfCIDs_1624_Array Invoke(string ConnectionString,P_CAS_GCTDfCIDs_1624 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_CAS_GCTDfCIDs_1624_Array Invoke(DbConnection Connection,P_CAS_GCTDfCIDs_1624 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_CAS_GCTDfCIDs_1624_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_CAS_GCTDfCIDs_1624 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_CAS_GCTDfCIDs_1624_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_CAS_GCTDfCIDs_1624 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_CAS_GCTDfCIDs_1624_Array functionReturn = new FR_CAS_GCTDfCIDs_1624_Array();
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

				throw new Exception("Exception occured in method cls_Get_Case_Treatment_Data_for_CaseIDs",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_CAS_GCTDfCIDs_1624_Array : FR_Base
	{
		public CAS_GCTDfCIDs_1624[] Result	{ get; set; } 
		public FR_CAS_GCTDfCIDs_1624_Array() : base() {}

		public FR_CAS_GCTDfCIDs_1624_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_CAS_GCTDfCIDs_1624 for attribute P_CAS_GCTDfCIDs_1624
		[DataContract]
		public class P_CAS_GCTDfCIDs_1624 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] CaseIDs { get; set; } 

		}
		#endregion
		#region SClass CAS_GCTDfCIDs_1624 for attribute CAS_GCTDfCIDs_1624
		[DataContract]
		public class CAS_GCTDfCIDs_1624 
		{
			//Standard type parameters
			[DataMember]
			public String localization { get; set; } 
			[DataMember]
			public Guid diagnose_id { get; set; } 
			[DataMember]
			public Boolean is_confirmed { get; set; } 
			[DataMember]
			public Guid op_doctor_id { get; set; } 
			[DataMember]
			public Guid patient_id { get; set; } 
			[DataMember]
			public Guid case_id { get; set; } 
			[DataMember]
			public Guid drug_id { get; set; } 
			[DataMember]
			public DateTime treatment_date { get; set; } 
			[DataMember]
			public Boolean is_performed { get; set; } 
			[DataMember]
			public Guid planned_action_id { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_CAS_GCTDfCIDs_1624_Array cls_Get_Case_Treatment_Data_for_CaseIDs(,P_CAS_GCTDfCIDs_1624 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_CAS_GCTDfCIDs_1624_Array invocationResult = cls_Get_Case_Treatment_Data_for_CaseIDs.Invoke(connectionString,P_CAS_GCTDfCIDs_1624 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Case.Atomic.Retrieval.P_CAS_GCTDfCIDs_1624();
parameter.CaseIDs = ...;

*/
