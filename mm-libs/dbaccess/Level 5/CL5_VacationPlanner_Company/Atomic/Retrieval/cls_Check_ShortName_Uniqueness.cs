/* 
 * Generated on 8/26/2013 1:32:59 PM
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
using CL1_CMN_STR;
using CL1_CMN_STR_PPS;
using PlannicoModel.Models;
using VacationPlannerCore.Utils;
using CL5_VacationPlanner_Company.Complex.Retrieval;
using CL6_VacationPlanner_Tenant.Atomic.Retrieval;
using CL5_VacationPlanner_Tenant.Atomic.Retrieval;
using VacationPlannerCore.CustomClasses;

namespace CL5_VacationPlanner_Company.Atomic.Retrieval
{
	/// <summary>
    /// No description found in <meta/> tag
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Check_ShortName_Uniqueness.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Check_ShortName_Uniqueness
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5CM_CSNU_1524 Execute(DbConnection Connection,DbTransaction Transaction,P_L5CM_CSNU_1524 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5CM_CSNU_1524();

            StructureBuilderUtil structureBuilderUtil = new StructureBuilderUtil();
            TreeNodeUtil treeNodeUtil = new TreeNodeUtil();

            structureBuilderUtil.company = cls_Get_Company_Structure_For_Tenant.Invoke(Connection, Transaction, securityTicket).Result; ;
            structureBuilderUtil.sessionToken = securityTicket.SessionTicket;
            structureBuilderUtil.addEmployees = false;
            structureBuilderUtil.sessionSettings = cls_Get_Settings_For_Tenant.Invoke(Connection, Transaction, securityTicket).Result;
            structureBuilderUtil.startDate = cls_Get_CalculationTimeFramesForTenant.Invoke(Connection, Transaction, securityTicket).Result.Min(x => x.CalculationTimeframe_StartDate).Date;
            structureBuilderUtil.endDate = DateTime.Now;
            structureBuilderUtil.hidenNodeType = CompanyStructureType.None;
            structureBuilderUtil.employees = new L5EM_GEFT_0959[0];

            EmployeeUtils employeeUtil = new EmployeeUtils();
            structureBuilderUtil.employeeUtil = employeeUtil;
            returnValue.Result = new L5CM_CSNU_1524();
            List<Node> companyStructure = structureBuilderUtil.organizeData(DateTime.Now);

            Node node = treeNodeUtil.findNodeForID(companyStructure[0], Parameter.ParentRefID);
            if (node != null&&node.Children.Count!=0)
            {
                if (node.Children[0].data is L5OF_GOFT_1157)
                {
                    var officeQuery = new ORM_CMN_STR_Office.Query();
                    officeQuery.Tenant_RefID = securityTicket.TenantID;
                    officeQuery.IsDeleted = false;
                    officeQuery.Office_ShortName = Parameter.ShortName;
                    var officeQueryRes = ORM_CMN_STR_Office.Query.Search(Connection, Transaction, officeQuery);

                    if (officeQueryRes.Count > 0 )
                    {             

                        if (officeQueryRes.Count > 0)
                        {
                            returnValue.Result.OfficeID = officeQueryRes[0].CMN_STR_OfficeID;
                            returnValue.Result.OfficeShortName = officeQueryRes[0].Office_ShortName;
                        }
                    }
                    
                }
                else if (node.Children[0].data is L5WA_GWAFT_1201)
                {
                    var workareaQuery = new ORM_CMN_STR_PPS_WorkArea.Query();
                    workareaQuery.Tenant_RefID = securityTicket.TenantID;
                    workareaQuery.IsDeleted = false;
                    workareaQuery.ShortName = Parameter.ShortName;
                    if (node.data is L5WA_GWAFT_1201)
                    {
                        workareaQuery.Parent_RefID = Parameter.ParentRefID;
                    }
                    else
                    {
                        workareaQuery.Office_RefID = Parameter.ParentRefID;
                    }

                    var workareaQueryRes = ORM_CMN_STR_PPS_WorkArea.Query.Search(Connection, Transaction, workareaQuery);
                    if ( workareaQueryRes.Count > 0 )
                    {         
                        returnValue.Result.WorkAreaID = workareaQueryRes[0].CMN_STR_PPS_WorkAreaID;
                        returnValue.Result.WorkAreaShortName = workareaQueryRes[0].ShortName;
                    }
                }
                else if (node.Children[0].data is L5WP_GWFT_1203)
                {
                    var workplaceQuery = new ORM_CMN_STR_PPS_Workplace.Query();
                    workplaceQuery.Tenant_RefID = securityTicket.TenantID;
                    workplaceQuery.IsDeleted = false;
                    workplaceQuery.ShortName = Parameter.ShortName;
                    workplaceQuery.WorkArea_RefID = Parameter.ParentRefID;
                    var workplaceQueryRes = ORM_CMN_STR_PPS_Workplace.Query.Search(Connection, Transaction, workplaceQuery);
                    if (workplaceQueryRes.Count > 0)
                    {

                        if (workplaceQueryRes.Count > 0)
                        {
                            returnValue.Result.WorkPlaceID = workplaceQueryRes[0].CMN_STR_PPS_WorkplaceID;
                            returnValue.Result.WorkPlaceShortName = workplaceQueryRes[0].ShortName;
                        }
                    }

                }
            }

         
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5CM_CSNU_1524 Invoke(string ConnectionString,P_L5CM_CSNU_1524 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5CM_CSNU_1524 Invoke(DbConnection Connection,P_L5CM_CSNU_1524 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5CM_CSNU_1524 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5CM_CSNU_1524 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5CM_CSNU_1524 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5CM_CSNU_1524 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5CM_CSNU_1524 functionReturn = new FR_L5CM_CSNU_1524();
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

	#region Custom Return Type
	[Serializable]
	public class FR_L5CM_CSNU_1524 : FR_Base
	{
		public L5CM_CSNU_1524 Result	{ get; set; }

		public FR_L5CM_CSNU_1524() : base() {}

		public FR_L5CM_CSNU_1524(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5CM_CSNU_1524 cls_Check_ShortName_Uniqueness(P_L5CM_CSNU_1524 Parameter,string sessionToken = null)
{
	 var securityTicket = ...;
	 FR_L5CM_CSNU_1524 result = cls_Check_ShortName_Uniqueness.Invoke(connectionString,P_L5CM_CSNU_1524 Parameter,securityTicket);
	 return result;
}
*/