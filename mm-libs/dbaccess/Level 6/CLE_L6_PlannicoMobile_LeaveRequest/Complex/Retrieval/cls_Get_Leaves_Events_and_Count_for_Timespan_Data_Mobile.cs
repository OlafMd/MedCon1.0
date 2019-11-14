/* 
 * Generated on 5/9/2014 10:01:37 AM
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
using CL3_Events.Atomic.Retrieval;
using CL6_VacationPlanner_Tenant.Atomic.Retrieval;
using CL5_VacationPlanner_Company.Complex.Retrieval;
using CL5_VacationPlanner_LeaveRequest.Complex.Retrieval;
using CL5_VacationPlanner_Employees.Complex.Retrieval;

using CLE_L5_PlannicoMobile_Events.Complex.Retrieval;
using CLE_L5_CMN_Employees.Complex.Retrieval;

namespace CLE_L6_PlannicoMobile_LeaveRequest.Complex.Retrieval
{
	/// <summary>
    /// No description found in <meta/> tag
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Leaves_Events_and_Count_for_Timespan_Data_Mobile.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Leaves_Events_and_Count_for_Timespan_Data_Mobile
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6LR_LR_EV_D_1503 Execute(DbConnection Connection,DbTransaction Transaction,P_L6LR_LR_EV_D_1503 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_L6LR_LR_EV_D_1503();
            int TotalUnapprovedLeaveCount = 0;
            L5LR_GLRFSP_1532[] LeaveRequests = null;
            L5LR_EV_TSD_1047[] Events = null;

            #region retrive employee list for leave request
            //get employee details
            var loggedInEmployeeDetails = cls_Get_Employee_For_LoggedAccount.Invoke(Connection, Transaction, securityTicket).Result;
            P_L5EM_GEFTAE_1517 p_employeesForTennantAndManager = new P_L5EM_GEFTAE_1517()
            {
                EmployeeID = loggedInEmployeeDetails.CMN_BPT_EMP_EmployeeID
            };
            //use employee details to retrive a list of employees whose leave requests you need
            var employeesForTenantAndManager = cls_Get_Employees_For_Tenant_And_ManagerEmployeeID.Invoke(Connection, Transaction, p_employeesForTennantAndManager, securityTicket).Result;
            //employed and non resigned people
            //employeesForTenantAndManager.Employees = employeesForTenantAndManager.Employees.Where(e => e.Work_StartDate.Ticks <= Parameter.EndDate.Ticks && !(e.Work_EndDate.Ticks <= Parameter.StartDate.Ticks)).ToArray();

            #endregion

            #region get leave requests
            P_L5LR_GLRFSP_1532 p_leaves_for_selected_person = new P_L5LR_GLRFSP_1532()
            {
                EmployeeIDList = employeesForTenantAndManager.Employees.Select(e => e.CMN_BPT_EMP_EmployeeID).ToArray()
            };
            L5LR_GLRFSP_1532[] AllLeaveRequests = cls_Get_LeaveRequests_For_SelectedPersons.Invoke(Connection, Transaction, p_leaves_for_selected_person, securityTicket).Result;
            TotalUnapprovedLeaveCount = AllLeaveRequests.Count(lr => lr.IsApproved == false);

            //add to rv only those that fit the timespan
            LeaveRequests = AllLeaveRequests.Where(a =>
                                              ((a.StartTime >= Parameter.StartDate && a.EndTime <= Parameter.EndDate) ||
                                              (a.StartTime <= Parameter.StartDate && a.EndTime >= Parameter.StartDate) ||
                                              (a.StartTime <= Parameter.EndDate && a.EndTime >= Parameter.EndDate) ||
                                              (a.StartTime <= Parameter.StartDate && a.EndTime >= Parameter.EndDate)) && !a.IsDeactivated).ToArray();
            #endregion

            #region  get events
            P_L5LR_EV_TSD_1047 param = new P_L5LR_EV_TSD_1047
            {
                EndDate = Parameter.EndDate,
                StartDate = Parameter.StartDate
            };
            Events = cls_Get_Events_for_Timespan_Data.Invoke(Connection,Transaction,param,securityTicket).Result;
            #endregion
            returnValue.Result = new L6LR_LR_EV_D_1503();
            returnValue.Result.Events = Events;
            returnValue.Result.LeaveRequests = LeaveRequests;
            returnValue.Result.TotalUnapprovedLeaveCount = TotalUnapprovedLeaveCount;
            return returnValue;
             
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6LR_LR_EV_D_1503 Invoke(string ConnectionString,P_L6LR_LR_EV_D_1503 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6LR_LR_EV_D_1503 Invoke(DbConnection Connection,P_L6LR_LR_EV_D_1503 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6LR_LR_EV_D_1503 Invoke(DbConnection Connection, DbTransaction Transaction,P_L6LR_LR_EV_D_1503 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6LR_LR_EV_D_1503 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6LR_LR_EV_D_1503 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6LR_LR_EV_D_1503 functionReturn = new FR_L6LR_LR_EV_D_1503();
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

				throw new Exception("Exception occured in method cls_Get_Leaves_Events_and_Count_for_Timespan_Data_Mobile",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6LR_LR_EV_D_1503 : FR_Base
	{
		public L6LR_LR_EV_D_1503 Result	{ get; set; }

		public FR_L6LR_LR_EV_D_1503() : base() {}

		public FR_L6LR_LR_EV_D_1503(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6LR_LR_EV_D_1503 for attribute P_L6LR_LR_EV_D_1503
		[DataContract]
		public class P_L6LR_LR_EV_D_1503 
		{
			//Standard type parameters
			[DataMember]
			public DateTime StartDate { get; set; } 
			[DataMember]
			public DateTime EndDate { get; set; } 

		}
		#endregion
		#region SClass L6LR_LR_EV_D_1503 for attribute L6LR_LR_EV_D_1503
		[DataContract]
		public class L6LR_LR_EV_D_1503 
		{
			//Standard type parameters
			[DataMember]
			public int TotalUnapprovedLeaveCount { get; set; } 
			[DataMember]
			public L5LR_GLRFSP_1532[] LeaveRequests { get; set; } 
			[DataMember]
			public L5LR_EV_TSD_1047[] Events { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6LR_LR_EV_D_1503 cls_Get_Leaves_Events_and_Count_for_Timespan_Data_Mobile(,P_L6LR_LR_EV_D_1503 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6LR_LR_EV_D_1503 invocationResult = cls_Get_Leaves_Events_and_Count_for_Timespan_Data_Mobile.Invoke(connectionString,P_L6LR_LR_EV_D_1503 Parameter,securityTicket);
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
var parameter = new CLE_L6_PlannicoMobile_LeaveRequest.Complex.Retrieval.P_L6LR_LR_EV_D_1503();
parameter.StartDate = ...;
parameter.EndDate = ...;

*/
