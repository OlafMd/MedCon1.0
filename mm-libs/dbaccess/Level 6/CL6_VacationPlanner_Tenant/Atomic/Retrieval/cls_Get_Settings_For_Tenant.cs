/* 
 * Generated on 8/30/2013 11:30:27 AM
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

namespace CL6_VacationPlanner_Tenant.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Settings_For_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Settings_For_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6TN_GSFT_1017 Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L6TN_GSFT_1017();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL6_VacationPlanner_Tenant.Atomic.Retrieval.SQL.cls_Get_Settings_For_Tenant.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L6TN_GSFT_1017> results = new List<L6TN_GSFT_1017>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "IsUsing_Offices","IsUsing_WorkAreas","IsUsing_Workplaces","IsUsing_CostCenters","NumberOfResponsiblePersonsRequiredToApprove","CMN_CAL_APR_ResponsiblePersonID","CMN_CAL_Event_ApprovalProcess_TypeID","CMN_Tenant_ActiveApprovalProcessTypeID" });
				while(reader.Read())
				{
					L6TN_GSFT_1017 resultItem = new L6TN_GSFT_1017();
					//0:Parameter IsUsing_Offices of type bool
					resultItem.IsUsing_Offices = reader.GetBoolean(0);
					//1:Parameter IsUsing_WorkAreas of type bool
					resultItem.IsUsing_WorkAreas = reader.GetBoolean(1);
					//2:Parameter IsUsing_Workplaces of type bool
					resultItem.IsUsing_Workplaces = reader.GetBoolean(2);
					//3:Parameter IsUsing_CostCenters of type bool
					resultItem.IsUsing_CostCenters = reader.GetBoolean(3);
					//4:Parameter NumberOfResponsiblePersonsRequiredToApprove of type int
					resultItem.NumberOfResponsiblePersonsRequiredToApprove = reader.GetInteger(4);
					//5:Parameter CMN_CAL_APR_ResponsiblePersonID of type Guid
					resultItem.CMN_CAL_APR_ResponsiblePersonID = reader.GetGuid(5);
					//6:Parameter CMN_CAL_Event_ApprovalProcess_TypeID of type Guid
					resultItem.CMN_CAL_Event_ApprovalProcess_TypeID = reader.GetGuid(6);
					//7:Parameter CMN_Tenant_ActiveApprovalProcessTypeID of type Guid
					resultItem.CMN_Tenant_ActiveApprovalProcessTypeID = reader.GetGuid(7);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Settings_For_Tenant",ex);
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
		public static FR_L6TN_GSFT_1017 Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6TN_GSFT_1017 Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6TN_GSFT_1017 Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6TN_GSFT_1017 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6TN_GSFT_1017 functionReturn = new FR_L6TN_GSFT_1017();
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

				throw new Exception("Exception occured in method cls_Get_Settings_For_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6TN_GSFT_1017 : FR_Base
	{
		public L6TN_GSFT_1017 Result	{ get; set; }

		public FR_L6TN_GSFT_1017() : base() {}

		public FR_L6TN_GSFT_1017(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
	

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6TN_GSFT_1017 cls_Get_Settings_For_Tenant(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6TN_GSFT_1017 invocationResult = cls_Get_Settings_For_Tenant.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/
