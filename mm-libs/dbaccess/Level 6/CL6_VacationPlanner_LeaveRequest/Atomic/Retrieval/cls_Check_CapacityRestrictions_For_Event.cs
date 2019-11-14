/* 
 * Generated on 25-Mar-14 11:42:12
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
using CL1_CMN_STR_SCE;
using CL3_Events.Atomic.Retrieval;
using CL1_CMN_STR;
using CL1_CMN_STR_PPS;
using CL5_VacationPlanner_Employees.Complex.Retrieval;
using VacationPlannerCore.Utils;
using CL5_VacationPlanner_Company.Complex.Retrieval;
using VacationPlannerCore.CustomClasses;
using PlannicoModel.Models;
using VacationPlannerCore.CoreAPISupport;
using CL5_VacationPlanner_LeaveRequest.Atomic.Retrieval;

namespace CL6_VacationPlanner_LeaveRequest.Atomic.Retrieval
{
	/// <summary>
    /// No description found in <meta/> tag
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Check_CapacityRestrictions_For_Event.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Check_CapacityRestrictions_For_Event
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Bool Execute(DbConnection Connection,DbTransaction Transaction,P_L6LR_CCRFE_1340 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Bool();
			//Put your code here

            returnValue.Result = true;

            //if (Parameter.Events != null)
            //{
            //    foreach (var Event in Parameter.Events)
            //    {
            //        var  structureEvenQuery = new ORM_CMN_STR_SCE_StructureCalendarEvent.Query();
            //        structureEvenQuery.Tenant_RefID = securityTicket.TenantID;
            //        structureEvenQuery.IsDeleted = false;
            //        structureEvenQuery.CMN_CAL_Event_RefID = Event.EventID;

            //        var structCelEventRes = ORM_CMN_STR_SCE_StructureCalendarEvent.Query.Search(Connection, Transaction, structureEvenQuery);

            //        if (structCelEventRes != null && structCelEventRes.Count == 1)
            //        {
            //            ORM_CMN_STR_SCE_StructureCalendarEvent structEventItem = structCelEventRes[0];

            //            P_L3EV_GSEFSE_1102 eventParam = new P_L3EV_GSEFSE_1102();
            //            eventParam.StructureEventID = structEventItem.CMN_STR_SCE_StructureCalendarEventID;
            //            var structEventRes = cls_Get_StructureEvent_For_StructureEventID.Invoke(Connection, Transaction, eventParam, securityTicket).Result;


            //            Guid structureID = Guid.Empty;

            //            var officeQuery = new ORM_CMN_STR_Office.Query();
            //            officeQuery.CMN_CAL_CalendarInstance_RefID = structEventRes.CalendarInstance_RefID;
            //            officeQuery.Tenant_RefID = securityTicket.TenantID;
            //            officeQuery.IsDeleted = false;

            //            var officeRes = ORM_CMN_STR_Office.Query.Search(Connection, Transaction, officeQuery);

            //            if (officeRes == null || officeRes.Count == 0)
            //            {
            //                var workAreaQuery = new ORM_CMN_STR_PPS_WorkArea.Query();
            //                workAreaQuery.CMN_CAL_CalendarInstance_RefID = structEventRes.CalendarInstance_RefID;
            //                workAreaQuery.Tenant_RefID = securityTicket.TenantID;
            //                workAreaQuery.IsDeleted = false;

            //                var workAreaRes = ORM_CMN_STR_PPS_WorkArea.Query.Search(Connection, Transaction, workAreaQuery);
            //                if (workAreaRes == null || workAreaRes.Count == 0)
            //                {
            //                    var workPlaceQuery = new ORM_CMN_STR_PPS_Workplace.Query();
            //                    workPlaceQuery.CMN_CAL_CalendarInstance_RefID = structEventRes.CalendarInstance_RefID;
            //                    workPlaceQuery.Tenant_RefID = securityTicket.TenantID;
            //                    workPlaceQuery.IsDeleted = false;

            //                    var workPlaceRes = ORM_CMN_STR_PPS_Workplace.Query.Search(Connection, Transaction, workPlaceQuery);
            //                    if (workPlaceRes != null && workPlaceRes.Count == 1)
            //                    {
            //                        structureID = workPlaceRes[0].CMN_STR_PPS_WorkplaceID;
            //                    }

            //                }
            //                else
            //                {
            //                    structureID = workAreaRes[0].CMN_STR_PPS_WorkAreaID;
            //                }
            //            }
            //            else
            //            {
            //                structureID = officeRes[0].CMN_STR_OfficeID;
            //            }


                       

            //            var emploayees = cls_Get_Employees_For_Tenant.Invoke(Connection, Transaction, securityTicket).Result;
            //            var company = cls_Get_Company_Structure_For_Tenant.Invoke(Connection, Transaction, securityTicket).Result;
            //            OfficeHierarchyUtils officeUtils = new OfficeHierarchyUtils();
            //            StructureBuilderUtil structureUtil = new StructureBuilderUtil();
            //            TreeNodeUtil treeUtil = new TreeNodeUtil();

            //            structureUtil.company = company;
            //            structureUtil.employees = emploayees;
            //            structureUtil.addEmployees = true;
            //            structureUtil.startDate = Parameter.LeaveRequestStartDate;
            //            structureUtil.endDate = Parameter.LeaveRequestEndDate;
            //            structureUtil.sessionToken = securityTicket.SessionTicket;
            //            List<Node> tree = structureUtil.organizeData(Parameter.appStartDate, true);
            //            var node = treeUtil.findNodeForID(tree.FirstOrDefault(), structureID);

            //            List<L5EM_GEFT_0959> selectedEmployees = new List<L5EM_GEFT_0959>();
            //            if (structureID != Guid.Empty)
            //                officeUtils.getEmployeesForStructurePart(node, selectedEmployees);
            //            else
            //                selectedEmployees = cls_Get_Employees_For_Tenant.Invoke(Connection, Transaction, securityTicket).Result.ToList();

            //            if (selectedEmployees != null && selectedEmployees.Count > 0)
            //            {
            //                foreach (var DateRange in Event.dateRange)
            //                {
            //                    int counter = 0;
            //                    DateTime startDate = new DateTime(DateRange.Start.Ticks);
            //                    DateTime endDate = new DateTime(DateRange.End.Ticks);
            //                    while (startDate <= endDate)
            //                    {

            //                        DateTime tempStartDate = new DateTime(startDate.Ticks);
            //                        DateTime tempEndDate = new DateTime(startDate.AddDays(1).Ticks);
            //                        startDate = startDate.AddDays(1);
            //                        if (tempEndDate > endDate)
            //                            tempEndDate = endDate;
            //                        foreach (var emp in selectedEmployees)
            //                        {


            //                            P_L5LR_GLRTFEAT_1634 param = new P_L5LR_GLRTFEAT_1634();
            //                            param.EmployeeID = emp.CMN_BPT_EMP_EmployeeID;
            //                            param.StartTime = tempStartDate;
            //                            param.EndTime = tempEndDate;
            //                            var res = cls_Get_LeaveRequestsTimes_For_EmployeeAndTime.Invoke(Connection, Transaction, param, securityTicket).Result;
            //                            if (res != null && res.CMN_BPT_EMP_Employee_LeaveRequestID != Guid.Empty)
            //                            {
            //                                counter++;
            //                            }


            //                            if (structEventRes.CMN_STR_SCE_CapacityRestriction_TypeID == StaffLeaveLimitTypes.MaxStaffOnDuty)
            //                            {
            //                                if (structEventRes.IsValueCalculated_InHeadCount)
            //                                {
            //                                    if (selectedEmployees.Count() - (counter + 1) > structEventRes.ValueCalculated)
            //                                    {
            //                                        returnValue.Result = false;
            //                                    }
            //                                }
            //                                else
            //                                {
            //                                    if (selectedEmployees.Count() - (counter + 1) > (structEventRes.ValueCalculated / 100) * selectedEmployees.Count())
            //                                    {
            //                                        returnValue.Result = false;
            //                                    }
            //                                }
            //                            }
            //                            else if (structEventRes.CMN_STR_SCE_CapacityRestriction_TypeID == StaffLeaveLimitTypes.MaxStaffOnLeave)
            //                            {
            //                                if (structEventRes.IsValueCalculated_InHeadCount)
            //                                {
            //                                    if (counter + 1 > structEventRes.ValueCalculated)
            //                                    {
            //                                        returnValue.Result = false;
            //                                    }
            //                                }
            //                                else
            //                                {
            //                                    if (counter + 1 > (structEventRes.ValueCalculated / 100) * selectedEmployees.Count())
            //                                    {
            //                                        returnValue.Result = false;
            //                                    }
            //                                }
            //                            }

            //                            }
            //                        }


            //                    }
            //                }
                        
            //        }

                  

            //    }

            //}
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Bool Invoke(string ConnectionString,P_L6LR_CCRFE_1340 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection,P_L6LR_CCRFE_1340 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction,P_L6LR_CCRFE_1340 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6LR_CCRFE_1340 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Bool functionReturn = new FR_Bool();
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

				throw ex;
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		

	#endregion
}
