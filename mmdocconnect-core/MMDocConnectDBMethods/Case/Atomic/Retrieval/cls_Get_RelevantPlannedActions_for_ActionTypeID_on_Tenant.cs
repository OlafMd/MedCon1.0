/* 
 * Generated on 04/19/17 21:00:24
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
    /// var result = cls_Get_RelevantPlannedActions_for_ActionTypeID_on_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_RelevantPlannedActions_for_ActionTypeID_on_Tenant
	{
        public static readonly int QueryTimeout = 6000;

		#region Method Execution
		protected static FR_CAS_GRPAfATIDoT_1656_Array Execute(DbConnection Connection,DbTransaction Transaction,P_CAS_GRPAfATIDoT_1656 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_CAS_GRPAfATIDoT_1656_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.Case.Atomic.Retrieval.SQL.cls_Get_RelevantPlannedActions_for_ActionTypeID_on_Tenant.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ActionTypeID", Parameter.ActionTypeID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"IsPerformed", Parameter.IsPerformed);



			List<CAS_GRPAfATIDoT_1656> results = new List<CAS_GRPAfATIDoT_1656>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "PlannedActionID","CaseID","IsDeleted","CreationTimestamp","IsCancelled","IsPerformed","PatientID" });
				while(reader.Read())
				{
					CAS_GRPAfATIDoT_1656 resultItem = new CAS_GRPAfATIDoT_1656();
					//0:Parameter PlannedActionID of type Guid
					resultItem.PlannedActionID = reader.GetGuid(0);
					//1:Parameter CaseID of type Guid
					resultItem.CaseID = reader.GetGuid(1);
					//2:Parameter IsDeleted of type Boolean
					resultItem.IsDeleted = reader.GetBoolean(2);
					//3:Parameter CreationTimestamp of type DateTime
					resultItem.CreationTimestamp = reader.GetDate(3);
					//4:Parameter IsCancelled of type Boolean
					resultItem.IsCancelled = reader.GetBoolean(4);
					//5:Parameter IsPerformed of type Boolean
					resultItem.IsPerformed = reader.GetBoolean(5);
					//6:Parameter PatientID of type Guid
					resultItem.PatientID = reader.GetGuid(6);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_RelevantPlannedActions_for_ActionTypeID_on_Tenant",ex);
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
		public static FR_CAS_GRPAfATIDoT_1656_Array Invoke(string ConnectionString,P_CAS_GRPAfATIDoT_1656 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_CAS_GRPAfATIDoT_1656_Array Invoke(DbConnection Connection,P_CAS_GRPAfATIDoT_1656 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_CAS_GRPAfATIDoT_1656_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_CAS_GRPAfATIDoT_1656 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_CAS_GRPAfATIDoT_1656_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_CAS_GRPAfATIDoT_1656 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_CAS_GRPAfATIDoT_1656_Array functionReturn = new FR_CAS_GRPAfATIDoT_1656_Array();
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

				throw new Exception("Exception occured in method cls_Get_RelevantPlannedActions_for_ActionTypeID_on_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_CAS_GRPAfATIDoT_1656_Array : FR_Base
	{
		public CAS_GRPAfATIDoT_1656[] Result	{ get; set; } 
		public FR_CAS_GRPAfATIDoT_1656_Array() : base() {}

		public FR_CAS_GRPAfATIDoT_1656_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_CAS_GRPAfATIDoT_1656 for attribute P_CAS_GRPAfATIDoT_1656
		[DataContract]
		public class P_CAS_GRPAfATIDoT_1656 
		{
			//Standard type parameters
			[DataMember]
			public Guid ActionTypeID { get; set; } 
			[DataMember]
			public Boolean IsPerformed { get; set; } 

		}
		#endregion
		#region SClass CAS_GRPAfATIDoT_1656 for attribute CAS_GRPAfATIDoT_1656
		[DataContract]
		public class CAS_GRPAfATIDoT_1656 
		{
			//Standard type parameters
			[DataMember]
			public Guid PlannedActionID { get; set; } 
			[DataMember]
			public Guid CaseID { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 
			[DataMember]
			public DateTime CreationTimestamp { get; set; } 
			[DataMember]
			public Boolean IsCancelled { get; set; } 
			[DataMember]
			public Boolean IsPerformed { get; set; } 
			[DataMember]
			public Guid PatientID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_CAS_GRPAfATIDoT_1656_Array cls_Get_RelevantPlannedActions_for_ActionTypeID_on_Tenant(,P_CAS_GRPAfATIDoT_1656 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_CAS_GRPAfATIDoT_1656_Array invocationResult = cls_Get_RelevantPlannedActions_for_ActionTypeID_on_Tenant.Invoke(connectionString,P_CAS_GRPAfATIDoT_1656 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Case.Atomic.Retrieval.P_CAS_GRPAfATIDoT_1656();
parameter.ActionTypeID = ...;
parameter.IsPerformed = ...;

*/
