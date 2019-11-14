/* 
 * Generated on 25-Nov-14 8:41:29 AM
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

namespace CL2_Project.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ProjectProgress_for_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ProjectProgress_for_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2PR_GPPfT_0839_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2PR_GPPfT_0839_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_Project.Atomic.Retrieval.SQL.cls_Get_ProjectProgress_for_Tenant.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L2PR_GPPfT_0839> results = new List<L2PR_GPPfT_0839>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "PercentageComplete","TMS_PRO_ProjectID","TMS_PRO_DeveloperTaskID","IsDeleted","IsArchived" });
				while(reader.Read())
				{
					L2PR_GPPfT_0839 resultItem = new L2PR_GPPfT_0839();
					//0:Parameter PercentageComplete of type Double
					resultItem.PercentageComplete = reader.GetDouble(0);
					//1:Parameter TMS_PRO_ProjectID of type Guid
					resultItem.TMS_PRO_ProjectID = reader.GetGuid(1);
					//2:Parameter TMS_PRO_DeveloperTaskID of type Guid
					resultItem.TMS_PRO_DeveloperTaskID = reader.GetGuid(2);
					//3:Parameter IsDeleted of type bool
					resultItem.IsDeleted = reader.GetBoolean(3);
					//4:Parameter IsArchived of type bool
					resultItem.IsArchived = reader.GetBoolean(4);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_ProjectProgress_for_Tenant",ex);
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
		public static FR_L2PR_GPPfT_0839_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2PR_GPPfT_0839_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2PR_GPPfT_0839_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2PR_GPPfT_0839_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2PR_GPPfT_0839_Array functionReturn = new FR_L2PR_GPPfT_0839_Array();
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

				throw new Exception("Exception occured in method cls_Get_ProjectProgress_for_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2PR_GPPfT_0839_Array : FR_Base
	{
		public L2PR_GPPfT_0839[] Result	{ get; set; } 
		public FR_L2PR_GPPfT_0839_Array() : base() {}

		public FR_L2PR_GPPfT_0839_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L2PR_GPPfT_0839 for attribute L2PR_GPPfT_0839
		[DataContract]
		public class L2PR_GPPfT_0839 
		{
			//Standard type parameters
			[DataMember]
			public Double PercentageComplete { get; set; } 
			[DataMember]
			public Guid TMS_PRO_ProjectID { get; set; } 
			[DataMember]
			public Guid TMS_PRO_DeveloperTaskID { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 
			[DataMember]
			public bool IsArchived { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2PR_GPPfT_0839_Array cls_Get_ProjectProgress_for_Tenant(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2PR_GPPfT_0839_Array invocationResult = cls_Get_ProjectProgress_for_Tenant.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/
