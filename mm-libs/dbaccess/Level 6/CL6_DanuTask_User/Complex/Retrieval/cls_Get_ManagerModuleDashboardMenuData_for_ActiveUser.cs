/* 
 * Generated on 08-Dec-14 2:08:47 PM
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
using CL1_TMS_PRO;

namespace CL6_DanuTask_User.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ManagerModuleDashboardMenuData_for_ActiveUser.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ManagerModuleDashboardMenuData_for_ActiveUser
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6US_GMMDMDfAU_1401 Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_L6US_GMMDMDfAU_1401();
			//Put your code here
            returnValue.Result = new L6US_GMMDMDfAU_1401();

            ORM_TMS_PRO_Project.Query projectQuery = new ORM_TMS_PRO_Project.Query();
            projectQuery.IsArchived = false;
            projectQuery.IsDeleted = false;

            int ProjectsCount = ORM_TMS_PRO_Project.Query.Search(Connection, Transaction, projectQuery).Count;

            if (ProjectsCount != null)
                returnValue.Result.Projects_Count = ProjectsCount;

            // NO DATABASE TABLE
            returnValue.Result.Boards_Count = 11;

            ORM_TMS_PRO_Feature.Query featureQuery = new ORM_TMS_PRO_Feature.Query();
            featureQuery.IsArchived = false;
            featureQuery.IsDeleted = false;

            int FeaturesCount = ORM_TMS_PRO_Feature.Query.Search(Connection, Transaction, featureQuery).Count;

            if (FeaturesCount != null)
                returnValue.Result.Features_Count = FeaturesCount;

            ORM_TMS_PRO_Feature_2_DeveloperTask.Query developer_tasks_Query = new ORM_TMS_PRO_Feature_2_DeveloperTask.Query();
            developer_tasks_Query.IsDeleted = false;

            int DeveloperTasksCount = ORM_TMS_PRO_Feature_2_DeveloperTask.Query.Search(Connection, Transaction, developer_tasks_Query).Count;

            if (DeveloperTasksCount != null)
                returnValue.Result.DeveloperTasks_Count = DeveloperTasksCount;


            returnValue.Result.TimeReportedToday = 606;


			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6US_GMMDMDfAU_1401 Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6US_GMMDMDfAU_1401 Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6US_GMMDMDfAU_1401 Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6US_GMMDMDfAU_1401 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6US_GMMDMDfAU_1401 functionReturn = new FR_L6US_GMMDMDfAU_1401();
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

				throw new Exception("Exception occured in method cls_Get_ManagerModuleDashboardMenuData_for_ActiveUser",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6US_GMMDMDfAU_1401 : FR_Base
	{
		public L6US_GMMDMDfAU_1401 Result	{ get; set; }

		public FR_L6US_GMMDMDfAU_1401() : base() {}

		public FR_L6US_GMMDMDfAU_1401(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L6US_GMMDMDfAU_1401 for attribute L6US_GMMDMDfAU_1401
		[DataContract]
		public class L6US_GMMDMDfAU_1401 
		{
			//Standard type parameters
			[DataMember]
			public int Projects_Count { get; set; } 
			[DataMember]
			public int Boards_Count { get; set; } 
			[DataMember]
			public int Features_Count { get; set; } 
			[DataMember]
			public int DeveloperTasks_Count { get; set; } 
			[DataMember]
			public int Reports_Count { get; set; } 
			[DataMember]
			public int TimeReportedToday { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6US_GMMDMDfAU_1401 cls_Get_ManagerModuleDashboardMenuData_for_ActiveUser(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6US_GMMDMDfAU_1401 invocationResult = cls_Get_ManagerModuleDashboardMenuData_for_ActiveUser.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

