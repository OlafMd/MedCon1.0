/* 
 * Generated on 6/2/2014 3:42:18 PM
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
using CL5_VacationPlanner_Employees.Complex.Retrieval;
using PlannicoModel.Models;
using CLE_L5_CMN_Employees.Complex.Retrieval;
namespace CLE_L6_PlannicoMobile_LeaveRequest.Complex.Retrieval
{
	/// <summary>
    /// No description found in <meta/> tag
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_View_LeaveRequest_Data.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_View_LeaveRequest_Data
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6LR_NLRD_1505 Execute(DbConnection Connection,DbTransaction Transaction,P_L6LR_NLRD_1505 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_L6LR_NLRD_1505();
            var loggedEmployee = cls_Get_Employee_For_LoggedAccount.Invoke(Connection, Transaction, securityTicket).Result;
            var employeesForTenantAndManager = cls_Get_Employees_For_Tenant_And_ManagerEmployeeID.Invoke(Connection, Transaction, new P_L5EM_GEFTAE_1517 { EmployeeID = loggedEmployee.CMN_BPT_EMP_EmployeeID }, securityTicket).Result;
            var forEmployees = cls_Get_Employees_And_LeaveRequestData_For_IDList.Invoke(Connection, Transaction, new P_L5EM_GEALRDFIDL_1138 { EmployeeIDList = employeesForTenantAndManager.Employees.Select(x => x.CMN_BPT_EMP_EmployeeID).ToArray() }, securityTicket).Result;
            var covers = cls_Get_Employees_For_Tenant_And_ManagerEmployeeID.Invoke(Connection, Transaction, new P_L5EM_GEFTAE_1517 { EmployeeID = loggedEmployee.CMN_BPT_EMP_EmployeeID }, securityTicket).Result.Employees;
            
            //var covers = cls_Get_Employees_And_ActiveWorkingContracts_For_Tenant_And_EmployeID.Invoke(Connection, Transaction, new P_L5EM_GEAAWCFTAE_1403 { EmployeeID = loggedEmployee.CMN_BPT_EMP_EmployeeID }, securityTicket).Result;

            #region employees and their leave types
            List<L6LR_NLRD_1505_ForEmployees> employees = new List<L6LR_NLRD_1505_ForEmployees>();
            foreach (var emp in forEmployees)
            {
                L6LR_NLRD_1505_ForEmployees employee = new L6LR_NLRD_1505_ForEmployees
                {
                    FirstName = emp.FirstName,
                    LastName = emp.LastName,
                    ID = emp.CMN_BPT_EMP_EmployeeID
                };
                List<L6LR_NLRD_1505_LeaveTypes> leaveTypes = new List<L6LR_NLRD_1505_LeaveTypes>();
                foreach (var contract in emp.WorkingContract2LeaveRequest)
                {
                    L6LR_NLRD_1505_LeaveTypes leaveType = new L6LR_NLRD_1505_LeaveTypes()
                    {
                        ID = contract.CMN_BPT_STA_AbsenceReasonID,
                        Name = contract.AbsenceReasonName
                    };
                    leaveTypes.Add(leaveType);
                }
                employee.LeaveTypes = leaveTypes.ToArray();
                employees.Add(employee);
            }
            #endregion employees and their leave types

            #region covers
            List<L6LR_NLRD_1505_Covers> rvCovers = new List<L6LR_NLRD_1505_Covers>();
            foreach (var cover in covers)
            {
                L6LR_NLRD_1505_Covers rvCover = new L6LR_NLRD_1505_Covers
                {
                    FirstName = cover.FirstName,
                    ID = cover.CMN_BPT_EMP_EmployeeID,
                    LastName = cover.LastName
                };
                rvCovers.Add(rvCover);
            }
            #endregion covers

            Guid firstLeaveTypeID = Guid.Empty;
            if (employees.Count > 0 && employees[0].LeaveTypes.Count() > 0)
            {
                firstLeaveTypeID = employees[0].LeaveTypes[0].ID;
            }

            L6LR_GLR_ID_1339 leave;
            if (Parameter.LeaveID != Guid.Empty)
            {
                //viewing existing leave
                leave = cls_Get_LeaveRequests_By_ID.Invoke(Connection, Transaction, new P_L6LR_GLR_ID_1339 { LeaveID = Parameter.LeaveID}, securityTicket).Result;
                firstLeaveTypeID = leave.Leave.AbsenceReason_Type_RefID;
            }
            else
            {
                //prepare values for new leave
                leave = new L6LR_GLR_ID_1339
                {
                    Leave = new L5LR_GLRFSP_1532 { StartTime = DateTime.Now, EndTime = DateTime.Now }
                };
                if (forEmployees.Count() > 0)
                {
                    leave.Leave.ForEmployeeID = forEmployees[0].CMN_BPT_EMP_EmployeeID;
                    leave.Leave.ReasonName = new Dict();
                    if (forEmployees[0].WorkingContract2LeaveRequest.Count() > 0)
                    {
                        leave.Leave.AbsenceReason_Type_RefID = forEmployees[0].WorkingContract2LeaveRequest[0].CMN_BPT_EMP_Employee_WorkingContract_AllowedAbsenceReasonID;
                    }
                }
            }

            P_L6LR_GLRS_M_1706 statParam = new P_L6LR_GLRS_M_1706
            {
                StartDate = leave.Leave.StartTime,
                EndDate = leave.Leave.EndTime,
                SavedLeaveDuration = 0,
                ForPerson = employees[0].ID,
                AbsenceResonID = firstLeaveTypeID
            };
            var statistics = cls_Get_Leave_Statistics_Mobile.Invoke(Connection, Transaction, statParam, securityTicket).Result;
            
            returnValue.Result = new L6LR_NLRD_1505()
            {
                ForEmployees = employees.ToArray(),
                Covers = rvCovers.ToArray(),
                Statistics = statistics,
                Leave = leave
            };

            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6LR_NLRD_1505 Invoke(string ConnectionString,P_L6LR_NLRD_1505 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6LR_NLRD_1505 Invoke(DbConnection Connection,P_L6LR_NLRD_1505 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6LR_NLRD_1505 Invoke(DbConnection Connection, DbTransaction Transaction,P_L6LR_NLRD_1505 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6LR_NLRD_1505 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6LR_NLRD_1505 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6LR_NLRD_1505 functionReturn = new FR_L6LR_NLRD_1505();
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

				throw new Exception("Exception occured in method cls_View_LeaveRequest_Data",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6LR_NLRD_1505 : FR_Base
	{
		public L6LR_NLRD_1505 Result	{ get; set; }

		public FR_L6LR_NLRD_1505() : base() {}

		public FR_L6LR_NLRD_1505(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6LR_NLRD_1505 for attribute P_L6LR_NLRD_1505
		[DataContract]
		public class P_L6LR_NLRD_1505 
		{
			//Standard type parameters
			[DataMember]
			public Guid LeaveID { get; set; } 

		}
		#endregion
		#region SClass L6LR_NLRD_1505 for attribute L6LR_NLRD_1505
		[DataContract]
		public class L6LR_NLRD_1505 
		{
			[DataMember]
			public L6LR_NLRD_1505_Covers[] Covers { get; set; }
			[DataMember]
			public L6LR_NLRD_1505_ForEmployees[] ForEmployees { get; set; }

			//Standard type parameters
			[DataMember]
			public L6LR_GLRS_M_1706 Statistics { get; set; } 
			[DataMember]
			public L6LR_GLR_ID_1339 Leave { get; set; } 

		}
		#endregion
		#region SClass L6LR_NLRD_1505_Covers for attribute Covers
		[DataContract]
		public class L6LR_NLRD_1505_Covers 
		{
			//Standard type parameters
			[DataMember]
			public string FirstName { get; set; } 
			[DataMember]
			public string LastName { get; set; } 
			[DataMember]
			public Guid ID { get; set; } 

		}
		#endregion
		#region SClass L6LR_NLRD_1505_ForEmployees for attribute ForEmployees
		[DataContract]
		public class L6LR_NLRD_1505_ForEmployees 
		{
			[DataMember]
			public L6LR_NLRD_1505_LeaveTypes[] LeaveTypes { get; set; }

			//Standard type parameters
			[DataMember]
			public string FirstName { get; set; } 
			[DataMember]
			public string LastName { get; set; } 
			[DataMember]
			public Guid ID { get; set; } 

		}
		#endregion
		#region SClass L6LR_NLRD_1505_LeaveTypes for attribute LeaveTypes
		[DataContract]
		public class L6LR_NLRD_1505_LeaveTypes 
		{
			//Standard type parameters
			[DataMember]
			public Dict Name { get; set; } 
			[DataMember]
			public Guid ID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6LR_NLRD_1505 cls_View_LeaveRequest_Data(,P_L6LR_NLRD_1505 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6LR_NLRD_1505 invocationResult = cls_View_LeaveRequest_Data.Invoke(connectionString,P_L6LR_NLRD_1505 Parameter,securityTicket);
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
var parameter = new CLE_L6_PlannicoMobile_LeaveRequest.Complex.Retrieval.P_L6LR_NLRD_1505();
parameter.LeaveID = ...;

*/
