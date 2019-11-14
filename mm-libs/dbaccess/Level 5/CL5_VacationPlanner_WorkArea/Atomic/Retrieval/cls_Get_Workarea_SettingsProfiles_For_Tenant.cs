/* 
 * Generated on 14-Nov-13 15:21:31
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

namespace CL5_VacationPlanner_WorkArea.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Workarea_SettingsProfiles_For_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Workarea_SettingsProfiles_For_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5WA_GWASPFT_1325_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5WA_GWASPFT_1325_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_VacationPlanner_WorkArea.Atomic.Retrieval.SQL.cls_Get_Workarea_SettingsProfiles_For_Tenant.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;
			List<L5WA_GWASPFT_1325> results = new List<L5WA_GWASPFT_1325>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_BPT_STR_Workarea_SettingsProfileID","Workarea_RefID","WorkdayStart_in_mins","RoosterGridMinimumPlanningUnit_in_mins","MaximumPreWork_Period_in_mins","MaximumPostWork_Period_in_mins" });
				while(reader.Read())
				{
					L5WA_GWASPFT_1325 resultItem = new L5WA_GWASPFT_1325();
					//0:Parameter CMN_BPT_STR_Workarea_SettingsProfileID of type Guid
					resultItem.CMN_BPT_STR_Workarea_SettingsProfileID = reader.GetGuid(0);
					//1:Parameter Workarea_RefID of type Guid
					resultItem.Workarea_RefID = reader.GetGuid(1);
					//2:Parameter WorkdayStart_in_mins of type int
					resultItem.WorkdayStart_in_mins = reader.GetInteger(2);
					//3:Parameter RoosterGridMinimumPlanningUnit_in_mins of type int
					resultItem.RoosterGridMinimumPlanningUnit_in_mins = reader.GetInteger(3);
					//4:Parameter MaximumPreWork_Period_in_mins of type int
					resultItem.MaximumPreWork_Period_in_mins = reader.GetInteger(4);
					//5:Parameter MaximumPostWork_Period_in_mins of type int
					resultItem.MaximumPostWork_Period_in_mins = reader.GetInteger(5);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw ex;
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
		public static FR_L5WA_GWASPFT_1325_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5WA_GWASPFT_1325_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5WA_GWASPFT_1325_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5WA_GWASPFT_1325_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5WA_GWASPFT_1325_Array functionReturn = new FR_L5WA_GWASPFT_1325_Array();
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

				throw ex;
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5WA_GWASPFT_1325_Array : FR_Base
	{
		public L5WA_GWASPFT_1325[] Result	{ get; set; } 
		public FR_L5WA_GWASPFT_1325_Array() : base() {}

		public FR_L5WA_GWASPFT_1325_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes

	#endregion
}
