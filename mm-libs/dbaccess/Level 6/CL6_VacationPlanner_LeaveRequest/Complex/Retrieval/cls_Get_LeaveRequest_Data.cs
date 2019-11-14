/* 
 * Generated on 10/25/2013 10:44:51 AM
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

using CL3_Events.Atomic.Retrieval;
using System.Diagnostics;
using System.Threading.Tasks;
using PlannicoModel.Models;
using CL6_VacationPlanner_Tenant.Atomic.Retrieval;
using CL5_VacationPlanner_Tenant.Atomic.Retrieval;
using CL5_VacationPlanner_Employees.Complex.Retrieval;
using CL5_VacationPlanner_Absence.Atomic.Retrieval;
using CL5_VacationPlanner_LeaveRequest.Complex.Retrieval;
using CL5_VacationPlanner_Company.Complex.Retrieval;

namespace CL6_VacationPlanner_LeaveRequest.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_LeaveRequest_Data.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_LeaveRequest_Data
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
        protected static FR_L6LR_GLRD_1503 Execute(DbConnection Connection, DbTransaction Transaction, String ConnectionString, P_L6LR_GLRD_1503 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
			#region UserCode 
			var returnValue = new FR_L6LR_GLRD_1503();
			//Put your code here

            L5EM_GEFU_445 LoggedEmplyeeID = null;

            L5EM_GEAAWCFT_1210[] For_Employees = null;

            L5AR_GAARFT_1130[] reasons_Res = null;

            L5TN_GTI_1646 tenant = null;

            L6TN_GSFT_1017 settings = null;

            L5EM_GEFT_0959[] employees = null;

            L5CM_GCSFT_1157 comapnyStructure = null;

            L5LR_GLRFSP_1532[] leaveRequests = null;

            L3EV_GSEFT_1647[] events = null;




            Parallel.Invoke(() =>
            {
                LoggedEmplyeeID = cls_Get_Employee_For_LoggedAccount.Invoke(ConnectionString, securityTicket).Result;
            },  // close first Action

                 () =>
                 {
                     For_Employees = cls_Get_Employees_And_ActiveWorkingContracts_For_Tenant.Invoke(ConnectionString, securityTicket).Result;
                 }, //close second Action

                 () =>
                 {
                     reasons_Res = cls_get_Active_AbsenceReason_For_TenantID.Invoke(ConnectionString, securityTicket).Result;
                 } 
                 , 

                 () =>
                 {
                     tenant = cls_get_Tenant_Informations.Invoke(ConnectionString, securityTicket).Result;
                 }
                 ,

                 () =>
                 {
                     settings = cls_Get_Settings_For_Tenant.Invoke(ConnectionString, securityTicket).Result;
                 }
                 , 

                 () =>
                 {
                     employees = cls_Get_Employees_For_Tenant.Invoke(ConnectionString, securityTicket).Result;
                 } , 

                 () =>
                 {
                     comapnyStructure = cls_Get_Company_Structure_For_Tenant.Invoke(ConnectionString, securityTicket).Result;
                 }
                 ,

                 () =>
                 {
                     P_L5LR_GLRFSP_1532 param = new P_L5LR_GLRFSP_1532();
                     param.EmployeeIDList = Parameter.EmployeeIDListForRequests;
                     leaveRequests = cls_Get_LeaveRequests_For_SelectedPersons.Invoke(ConnectionString, param, securityTicket).Result;
                 }
                 ,

                 () =>
                 {
                     events = cls_Get_StructureEvents_For_Tenant.Invoke(ConnectionString, securityTicket).Result;
                 } 
             ); 




            returnValue.Result = new L6LR_GLRD_1503();
            returnValue.Result.AllEvents = events;
            returnValue.Result.AllLeaveRequests = leaveRequests;
            returnValue.Result.ForEmployees = For_Employees;
            returnValue.Result.LoggedEmployeeID = LoggedEmplyeeID;
            returnValue.Result.Settings = settings;
            returnValue.Result.LeavingReasons = reasons_Res;
            returnValue.Result.TenantInformations = tenant;
            returnValue.Result.AllEmployees = employees;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6LR_GLRD_1503 Invoke(string ConnectionString,P_L6LR_GLRD_1503 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6LR_GLRD_1503 Invoke(DbConnection Connection,P_L6LR_GLRD_1503 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6LR_GLRD_1503 Invoke(DbConnection Connection, DbTransaction Transaction,P_L6LR_GLRD_1503 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6LR_GLRD_1503 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6LR_GLRD_1503 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6LR_GLRD_1503 functionReturn = new FR_L6LR_GLRD_1503();
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

				functionReturn = Execute(Connection, Transaction,ConnectionString, Parameter,securityTicket);

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

				throw new Exception("Exception occured in method cls_Get_LeaveRequest_Data",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6LR_GLRD_1503 : FR_Base
	{
		public L6LR_GLRD_1503 Result	{ get; set; }

		public FR_L6LR_GLRD_1503() : base() {}

		public FR_L6LR_GLRD_1503(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes


	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6LR_GLRD_1503 cls_Get_LeaveRequest_Data(,P_L6LR_GLRD_1503 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6LR_GLRD_1503 invocationResult = cls_Get_LeaveRequest_Data.Invoke(connectionString,P_L6LR_GLRD_1503 Parameter,securityTicket);
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
var parameter = new CL6_VacationPlanner_LeaveRequest.Complex.Retrieval.P_L6LR_GLRD_1503();
parameter.EmployeeIDListForRequests = ...;

*/