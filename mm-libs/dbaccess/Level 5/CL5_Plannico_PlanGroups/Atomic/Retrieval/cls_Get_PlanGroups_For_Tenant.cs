/* 
 * Generated on 12/12/2013 2:14:49 PM
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
using PlannicoModel.Models;
using VacationPlaner;

namespace CL5_Plannico_PlanGroups.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_PlanGroups_For_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_PlanGroups_For_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5PG_GPGFT_1317_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5PG_GPGFT_1317_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_Plannico_PlanGroups.Atomic.Retrieval.SQL.cls_Get_PlanGroups_For_Tenant.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L5PG_GPGFT_1317> results = new List<L5PG_GPGFT_1317>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_BPT_EMP_Employee_PlanGroupID","PlanGroup_Name_DictID","PlanGroup_Description_DictID","BoundTo_Office_RefID","BoundTo_WorkArea_RefID","BoundTo_WorkPlace_RefID" });
				while(reader.Read())
				{
					L5PG_GPGFT_1317 resultItem = new L5PG_GPGFT_1317();
					//0:Parameter CMN_BPT_EMP_Employee_PlanGroupID of type Guid
					resultItem.CMN_BPT_EMP_Employee_PlanGroupID = reader.GetGuid(0);
					//1:Parameter PlanGroup_Name of type Dict
					resultItem.PlanGroup_Name = reader.GetDictionary(1);
					resultItem.PlanGroup_Name.SourceTable = "cmn_bpt_emp_employee_plangroups";
					loader.Append(resultItem.PlanGroup_Name);
					//2:Parameter PlanGroup_Description of type Dict
					resultItem.PlanGroup_Description = reader.GetDictionary(2);
					resultItem.PlanGroup_Description.SourceTable = "cmn_bpt_emp_employee_plangroups";
					loader.Append(resultItem.PlanGroup_Description);
					//3:Parameter BoundTo_Office_RefID of type Guid
					resultItem.BoundTo_Office_RefID = reader.GetGuid(3);
					//4:Parameter BoundTo_WorkArea_RefID of type Guid
					resultItem.BoundTo_WorkArea_RefID = reader.GetGuid(4);
					//5:Parameter BoundTo_WorkPlace_RefID of type Guid
					resultItem.BoundTo_WorkPlace_RefID = reader.GetGuid(5);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_PlanGroups_For_Tenant",ex);
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
		public static FR_L5PG_GPGFT_1317_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5PG_GPGFT_1317_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5PG_GPGFT_1317_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5PG_GPGFT_1317_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5PG_GPGFT_1317_Array functionReturn = new FR_L5PG_GPGFT_1317_Array();
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

                Guid errorID = Guid.NewGuid();
                ServerLog.Instance.Fatal("Application error occured. ErrorID = " + errorID, ex);
				throw new Exception("Exception occured in method cls_Get_PlanGroups_For_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5PG_GPGFT_1317_Array : FR_Base
	{
		public L5PG_GPGFT_1317[] Result	{ get; set; } 
		public FR_L5PG_GPGFT_1317_Array() : base() {}

		public FR_L5PG_GPGFT_1317_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5PG_GPGFT_1317_Array cls_Get_PlanGroups_For_Tenant(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5PG_GPGFT_1317_Array invocationResult = cls_Get_PlanGroups_For_Tenant.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/
