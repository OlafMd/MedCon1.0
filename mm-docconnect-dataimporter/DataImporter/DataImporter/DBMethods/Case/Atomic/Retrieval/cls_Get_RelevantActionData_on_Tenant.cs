/* 
 * Generated on 4/22/2017 9:08:51 PM
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
    /// var result = cls_Get_RelevantActionData_on_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_RelevantActionData_on_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_CAS_GRADoT_1007_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_CAS_GRADoT_1007_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "DataImporter.DBMethods.Case.Atomic.Retrieval.SQL.cls_Get_RelevantActionData_on_Tenant.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<CAS_GRADoT_1007> results = new List<CAS_GRADoT_1007>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "IsDeleted","IsPerformed","IsCancelled","Patient_RefID","CaseID","PlannedAction_RefID","ActionTypeGpmID","ToBePerformedBy_BusinessParticipant_RefID","IsOpPerformed","IsOpCancelled","Localization" });
				while(reader.Read())
				{
					CAS_GRADoT_1007 resultItem = new CAS_GRADoT_1007();
					//0:Parameter IsDeleted of type Boolean
					resultItem.IsDeleted = reader.GetBoolean(0);
					//1:Parameter IsPerformed of type Boolean
					resultItem.IsPerformed = reader.GetBoolean(1);
					//2:Parameter IsCancelled of type Boolean
					resultItem.IsCancelled = reader.GetBoolean(2);
					//3:Parameter Patient_RefID of type Guid
					resultItem.Patient_RefID = reader.GetGuid(3);
					//4:Parameter CaseID of type Guid
					resultItem.CaseID = reader.GetGuid(4);
					//5:Parameter PlannedAction_RefID of type Guid
					resultItem.PlannedAction_RefID = reader.GetGuid(5);
					//6:Parameter ActionTypeGpmID of type String
					resultItem.ActionTypeGpmID = reader.GetString(6);
					//7:Parameter ToBePerformedBy_BusinessParticipant_RefID of type Guid
					resultItem.ToBePerformedBy_BusinessParticipant_RefID = reader.GetGuid(7);
					//8:Parameter IsOpPerformed of type Boolean
					resultItem.IsOpPerformed = reader.GetBoolean(8);
					//9:Parameter IsOpCancelled of type Boolean
					resultItem.IsOpCancelled = reader.GetBoolean(9);
					//10:Parameter Localization of type String
					resultItem.Localization = reader.GetString(10);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_RelevantActionData_on_Tenant",ex);
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
		public static FR_CAS_GRADoT_1007_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_CAS_GRADoT_1007_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_CAS_GRADoT_1007_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_CAS_GRADoT_1007_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_CAS_GRADoT_1007_Array functionReturn = new FR_CAS_GRADoT_1007_Array();
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

				throw new Exception("Exception occured in method cls_Get_RelevantActionData_on_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_CAS_GRADoT_1007_Array : FR_Base
	{
		public CAS_GRADoT_1007[] Result	{ get; set; } 
		public FR_CAS_GRADoT_1007_Array() : base() {}

		public FR_CAS_GRADoT_1007_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass CAS_GRADoT_1007 for attribute CAS_GRADoT_1007
		[DataContract]
		public class CAS_GRADoT_1007 
		{
			//Standard type parameters
			[DataMember]
			public Boolean IsDeleted { get; set; } 
			[DataMember]
			public Boolean IsPerformed { get; set; } 
			[DataMember]
			public Boolean IsCancelled { get; set; } 
			[DataMember]
			public Guid Patient_RefID { get; set; } 
			[DataMember]
			public Guid CaseID { get; set; } 
			[DataMember]
			public Guid PlannedAction_RefID { get; set; } 
			[DataMember]
			public String ActionTypeGpmID { get; set; } 
			[DataMember]
			public Guid ToBePerformedBy_BusinessParticipant_RefID { get; set; } 
			[DataMember]
			public Boolean IsOpPerformed { get; set; } 
			[DataMember]
			public Boolean IsOpCancelled { get; set; } 
			[DataMember]
			public String Localization { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_CAS_GRADoT_1007_Array cls_Get_RelevantActionData_on_Tenant(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_CAS_GRADoT_1007_Array invocationResult = cls_Get_RelevantActionData_on_Tenant.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

