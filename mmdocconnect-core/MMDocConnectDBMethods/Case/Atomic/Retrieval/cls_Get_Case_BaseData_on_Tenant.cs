/* 
 * Generated on 10/04/16 10:20:42
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
    /// var result = cls_Get_Case_BaseData_on_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Case_BaseData_on_Tenant
	{
        public static readonly int QueryTimeout = 6000;

		#region Method Execution
		protected static FR_CAS_GCBDoT_0911_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_CAS_GCBDoT_0911_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.Case.Atomic.Retrieval.SQL.cls_Get_Case_BaseData_on_Tenant.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<CAS_GCBDoT_0911> results = new List<CAS_GCBDoT_0911>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "op_planned_action_id","case_id","drug_id","drug_order_position_id","op_date","op_doctor_bpt_id","is_op_performed","patient_id","creation_date","case_number" });
				while(reader.Read())
				{
					CAS_GCBDoT_0911 resultItem = new CAS_GCBDoT_0911();
					//0:Parameter op_planned_action_id of type Guid
					resultItem.op_planned_action_id = reader.GetGuid(0);
					//1:Parameter case_id of type Guid
					resultItem.case_id = reader.GetGuid(1);
					//2:Parameter drug_id of type Guid
					resultItem.drug_id = reader.GetGuid(2);
					//3:Parameter drug_order_position_id of type Guid
					resultItem.drug_order_position_id = reader.GetGuid(3);
					//4:Parameter op_date of type DateTime
					resultItem.op_date = reader.GetDate(4);
					//5:Parameter op_doctor_bpt_id of type Guid
					resultItem.op_doctor_bpt_id = reader.GetGuid(5);
					//6:Parameter is_op_performed of type Boolean
					resultItem.is_op_performed = reader.GetBoolean(6);
					//7:Parameter patient_id of type Guid
					resultItem.patient_id = reader.GetGuid(7);
					//8:Parameter creation_date of type DateTime
					resultItem.creation_date = reader.GetDate(8);
					//9:Parameter case_number of type String
					resultItem.case_number = reader.GetString(9);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Case_BaseData_on_Tenant",ex);
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
		public static FR_CAS_GCBDoT_0911_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_CAS_GCBDoT_0911_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_CAS_GCBDoT_0911_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_CAS_GCBDoT_0911_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_CAS_GCBDoT_0911_Array functionReturn = new FR_CAS_GCBDoT_0911_Array();
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

				throw new Exception("Exception occured in method cls_Get_Case_BaseData_on_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_CAS_GCBDoT_0911_Array : FR_Base
	{
		public CAS_GCBDoT_0911[] Result	{ get; set; } 
		public FR_CAS_GCBDoT_0911_Array() : base() {}

		public FR_CAS_GCBDoT_0911_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass CAS_GCBDoT_0911 for attribute CAS_GCBDoT_0911
		[DataContract]
		public class CAS_GCBDoT_0911 
		{
			//Standard type parameters
			[DataMember]
			public Guid op_planned_action_id { get; set; } 
			[DataMember]
			public Guid case_id { get; set; } 
			[DataMember]
			public Guid drug_id { get; set; } 
			[DataMember]
			public Guid drug_order_position_id { get; set; } 
			[DataMember]
			public DateTime op_date { get; set; } 
			[DataMember]
			public Guid op_doctor_bpt_id { get; set; } 
			[DataMember]
			public Boolean is_op_performed { get; set; } 
			[DataMember]
			public Guid patient_id { get; set; } 
			[DataMember]
			public DateTime creation_date { get; set; } 
			[DataMember]
			public String case_number { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_CAS_GCBDoT_0911_Array cls_Get_Case_BaseData_on_Tenant(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_CAS_GCBDoT_0911_Array invocationResult = cls_Get_Case_BaseData_on_Tenant.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

