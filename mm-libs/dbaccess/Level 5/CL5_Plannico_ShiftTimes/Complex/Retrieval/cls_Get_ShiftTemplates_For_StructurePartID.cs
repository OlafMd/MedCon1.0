/* 
 * Generated on 12/17/2013 11:43:31 AM
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
using CL5_VacationPlanner_Company.Complex.Retrieval;
using CL6_VacationPlanner_Tenant.Atomic.Retrieval;
using VacationPlannerCore.CustomClasses;
using VacationPlaner.Utils;
using PlannicoModel.Models;
using VacationPlannerCore.Utils;
using CL5_VacationPlanner_Employees.Complex.Retrieval;
using CL5_VacationPlanner_Tenant.Atomic.Retrieval;
using VacationPlaner;

namespace CL5_Plannico_ShiftTimes.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ShiftTemplates_For_StructurePartID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ShiftTemplates_For_StructurePartID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5ST_GSTFSPI_1037 Execute(DbConnection Connection,DbTransaction Transaction,P_L5ST_GSTFSPI_1037 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_L5ST_GSTFSPI_1037();
            returnValue.Result = new L5ST_GSTFSPI_1037();

            L5CM_GCSFT_1157 company = cls_Get_Company_Structure_For_Tenant.Invoke(Connection,Transaction,securityTicket).Result;
            L6TN_GSFT_1017 settingsForTenant = cls_Get_Settings_For_Tenant.Invoke(Connection, Transaction, securityTicket).Result;
            StructureBuilderUtil structureBuilderUtil = new StructureBuilderUtil();
            TreeNodeUtil treeNodeUtil = new TreeNodeUtil();
            List<Guid> structurePartsList=new List<Guid>();
            structurePartsList.Add(Parameter.StructurePartID);

            structureBuilderUtil.company = cls_Get_Company_Structure_For_Tenant.Invoke(Connection, Transaction, securityTicket).Result; ;
            structureBuilderUtil.sessionToken = securityTicket.SessionTicket;
            structureBuilderUtil.addEmployees = false;
            structureBuilderUtil.employees = cls_Get_Employees_For_Tenant.Invoke(Connection, Transaction, securityTicket).Result;
            structureBuilderUtil.sessionSettings = cls_Get_Settings_For_Tenant.Invoke(Connection, Transaction, securityTicket).Result;
            structureBuilderUtil.startDate = cls_Get_CalculationTimeFramesForTenant.Invoke(Connection, Transaction, securityTicket).Result.Min(x => x.CalculationTimeframe_StartDate).Date;
            structureBuilderUtil.endDate = DateTime.Now;
            structureBuilderUtil.hidenNodeType = CompanyStructureType.None;

            EmployeeUtils employeeUtil = new EmployeeUtils();
            structureBuilderUtil.employeeUtil = employeeUtil;

            List<Node> companyStructure = structureBuilderUtil.organizeData(DateTime.Now);
            List<L5ST_GSTFT_1610> remainingShiftTemplates = new List<L5ST_GSTFT_1610>();
            List<L5ST_GSTFT_1610> tempShiftTemplates = new List<L5ST_GSTFT_1610>();

            Node foundNode = treeNodeUtil.findNodeForID(companyStructure[0], Parameter.StructurePartID);
            if (foundNode != null)
            {
                treeNodeUtil.getParentIDsForStructurePart(foundNode, structurePartsList);

                L5ST_GSTFT_1610[] shiftTemplates = cls_Get_ShiftTemplates_For_Tenant.Invoke(Connection, Transaction, securityTicket).Result;

                foreach (var structureID in structurePartsList)
                {
                    tempShiftTemplates = shiftTemplates.Where(i => (i.CMN_STR_Office_RefID == structureID && structureID != Guid.Empty) || (i.CMN_STR_Workarea_RefID == structureID && structureID != Guid.Empty) || (i.CMN_STR_Workplace_RefID == structureID && structureID != Guid.Empty) || (i.CMN_STR_Workplace_RefID == Guid.Empty && i.CMN_STR_Workarea_RefID == Guid.Empty && i.CMN_STR_Office_RefID == Guid.Empty)).ToList();
                    foreach (var shiftTemplate in tempShiftTemplates)
                    {
                        if (!remainingShiftTemplates.Contains(shiftTemplate))
                            remainingShiftTemplates.Add(shiftTemplate);
                    }
                }
            }
            returnValue.Result.ShiftTemplates = remainingShiftTemplates.ToArray();

			//Put your code here
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5ST_GSTFSPI_1037 Invoke(string ConnectionString,P_L5ST_GSTFSPI_1037 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5ST_GSTFSPI_1037 Invoke(DbConnection Connection,P_L5ST_GSTFSPI_1037 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5ST_GSTFSPI_1037 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5ST_GSTFSPI_1037 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5ST_GSTFSPI_1037 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5ST_GSTFSPI_1037 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5ST_GSTFSPI_1037 functionReturn = new FR_L5ST_GSTFSPI_1037();
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

                Guid errorID = Guid.NewGuid();
                ServerLog.Instance.Fatal("Application error occured. ErrorID = " + errorID, ex);
				throw new Exception("Exception occured in method cls_Get_ShiftTemplates_For_StructurePartID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5ST_GSTFSPI_1037 : FR_Base
	{
		public L5ST_GSTFSPI_1037 Result	{ get; set; }

		public FR_L5ST_GSTFSPI_1037() : base() {}

		public FR_L5ST_GSTFSPI_1037(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes


	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5ST_GSTFSPI_1037 cls_Get_ShiftTemplates_For_StructurePartID(,P_L5ST_GSTFSPI_1037 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5ST_GSTFSPI_1037 invocationResult = cls_Get_ShiftTemplates_For_StructurePartID.Invoke(connectionString,P_L5ST_GSTFSPI_1037 Parameter,securityTicket);
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
var parameter = new CL5_Plannico_ShiftTimes.Complex.Retrieval.P_L5ST_GSTFSPI_1037();
parameter.StructurePartID = ...;

*/