/* 
 * Generated on 5/30/2014 11:56:08 AM
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
using CL5_VacationPlanner_Company.Complex.Retrieval;
using CL5_VacationPlanner_Employees.Complex.Retrieval;

namespace CLE_L5_PlannicoMobile_Employees.Complex.Retrieval
{
	/// <summary>
    /// No description found in <meta/> tag
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Employees_For_Tenant_And_ManagerEmployeeID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Employees_For_Tenant_And_ManagerEmployeeID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5EM_GEFTAE_1517 Execute(DbConnection Connection,DbTransaction Transaction,P_L5EM_GEFTAE_1517 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_L5EM_GEFTAE_1517();
            returnValue.Result = new L5EM_GEFTAE_1517();
			//Put your code here
            
            L5EM_GEAAWCFT_1210[] employees = cls_Get_Employees_And_ActiveWorkingContracts_For_Tenant.Invoke(Connection, Transaction, securityTicket).Result;
            L5EM_GEAAWCFT_1210 loggedEmployee = employees.Where(i => i.CMN_BPT_EMP_EmployeeID == Parameter.EmployeeID).FirstOrDefault();
            L5CM_GCSFT_1157 company= cls_Get_Company_Structure_For_Tenant.Invoke(Connection,Transaction,securityTicket).Result;
            Dictionary<Guid, List<Guid>> managesPerLocation = new Dictionary<Guid, List<Guid>>();

            var oldEmpls = CLE_L5_CMN_Employees.Complex.Retrieval.cls_Get_Employees_For_Tenant_And_ManagerEmployeeID.Invoke(Connection, Transaction, new PlannicoModel.Models.P_L5EM_GEFTAE_1517 { EmployeeID = Parameter.EmployeeID }, securityTicket).Result;

            foreach (var office in company.Offices)
            {
                List<Guid> managerIDList = new List<Guid>();
                foreach (var manager in office.Managers)
                {
                    if (!managerIDList.Contains(manager.CMN_BPT_EMP_EmployeeID))
                    {
                        managerIDList.Add(manager.CMN_BPT_EMP_EmployeeID);
                    }
                }
                if (managerIDList.Count() > 0)
                {
                    managesPerLocation.Add(office.CMN_STR_OfficeID, managerIDList);
                }
            }
            foreach (var workarea in company.WorkAreas)
            {
                List<Guid> managerIDList = new List<Guid>();
                foreach (var manager in workarea.ResponsiblePersons)
                {
                    if (!managerIDList.Contains(manager.CMN_BPT_EMP_EmployeeID))
                    {
                        managerIDList.Add(manager.CMN_BPT_EMP_EmployeeID);
                    }
                }
                if (managerIDList.Count() > 0)
                {
                    managesPerLocation.Add(workarea.CMN_STR_PPS_WorkAreaID, managerIDList);
                }
            }
            foreach (var workplace in company.WorkPlaces)
            {
                List<Guid> managerIDList = new List<Guid>();
                foreach (var manager in workplace.ResponsiblePersons)
                {
                    if (!managerIDList.Contains(manager.CMN_BPT_EMP_EmployeeID))
                    {
                        managerIDList.Add(manager.CMN_BPT_EMP_EmployeeID);
                    }
                }
                if (managerIDList.Count() > 0)
                {
                    managesPerLocation.Add(workplace.CMN_STR_PPS_WorkplaceID, managerIDList);
                }                
            }
            var employeeList = new List<L5EM_GEAAWCFT_1210>();
            foreach (var e in employees)
            {
                foreach (var wh in e.EmployeeWorkplaceHistory)
                {
                    if (managesPerLocation.ContainsKey(wh.BoundTo_Workplace_RefID)
                        && managesPerLocation[wh.BoundTo_Workplace_RefID].Contains(loggedEmployee.CMN_BPT_EMP_EmployeeID))
                    {
                        var loggedEmployeeValidWorkplaces = loggedEmployee.EmployeeWorkplaceHistory.Where(w => w.WorkplaceAssignment_StartDate >= Parameter.appStartDate).Select(w => w.BoundTo_Workplace_RefID);
                        if (loggedEmployeeValidWorkplaces != null)
                        {
                            if (loggedEmployeeValidWorkplaces.Contains(wh.BoundTo_Workplace_RefID) && !employeeList.Contains(e))
                            {
                                employeeList.Add(e);
                            }
                        }
                    }
                }
            }
            if (!employeeList.Contains(loggedEmployee))
            {
                employeeList.Add(loggedEmployee);
            }
            returnValue.Result.Employees = employeeList.ToArray();
            if (employees.Length == 0)
            {
                returnValue.Result = null;
            }
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5EM_GEFTAE_1517 Invoke(string ConnectionString,P_L5EM_GEFTAE_1517 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5EM_GEFTAE_1517 Invoke(DbConnection Connection,P_L5EM_GEFTAE_1517 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5EM_GEFTAE_1517 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5EM_GEFTAE_1517 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5EM_GEFTAE_1517 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5EM_GEFTAE_1517 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5EM_GEFTAE_1517 functionReturn = new FR_L5EM_GEFTAE_1517();
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

				throw new Exception("Exception occured in method cls_Get_Employees_For_Tenant_And_ManagerEmployeeID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5EM_GEFTAE_1517 : FR_Base
	{
		public L5EM_GEFTAE_1517 Result	{ get; set; }

		public FR_L5EM_GEFTAE_1517() : base() {}

		public FR_L5EM_GEFTAE_1517(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5EM_GEFTAE_1517 for attribute P_L5EM_GEFTAE_1517
		[DataContract]
		public class P_L5EM_GEFTAE_1517 
		{
			//Standard type parameters
			[DataMember]
			public Guid EmployeeID { get; set; } 
			[DataMember]
			public DateTime appStartDate { get; set; } 

		}
		#endregion
		#region SClass L5EM_GEFTAE_1517 for attribute L5EM_GEFTAE_1517
		[DataContract]
		public class L5EM_GEFTAE_1517 
		{
			//Standard type parameters
			[DataMember]
			public L5EM_GEAAWCFT_1210[] Employees { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5EM_GEFTAE_1517 cls_Get_Employees_For_Tenant_And_ManagerEmployeeID(,P_L5EM_GEFTAE_1517 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5EM_GEFTAE_1517 invocationResult = cls_Get_Employees_For_Tenant_And_ManagerEmployeeID.Invoke(connectionString,P_L5EM_GEFTAE_1517 Parameter,securityTicket);
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
var parameter = new CLE_L5_PlannicoMobile_Employees.Complex.Retrieval.P_L5EM_GEFTAE_1517();
parameter.EmployeeID = ...;
parameter.appStartDate = ...;

*/
