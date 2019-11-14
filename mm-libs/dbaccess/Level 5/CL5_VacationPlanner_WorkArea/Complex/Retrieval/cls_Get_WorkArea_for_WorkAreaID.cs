/* 
 * Generated on 14/08/2014 09:56:40
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
using CL1_CMN_STR_PPS;
using PlannicoModel.Models;
using CL1_CMN_STR;
using CL1_CMN_BPT;
using CL1_CMN_BPT_EMP;
using CL1_CMN_PER;

namespace CL5_VacationPlanner_WorkArea.complex.Retrieval
{
	/// <summary>
    /// No description found in <meta/> tag
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_WorkArea_for_WorkAreaID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_WorkArea_for_WorkAreaID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5WA_GWAFWA_0907 Execute(DbConnection Connection,DbTransaction Transaction,P_L5WA_GWAFWA_0907 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5WA_GWAFWA_0907();
            returnValue.Result = new L5WA_GWAFWA_0907();

            L5WA_GWAFT_1201 result = new L5WA_GWAFT_1201();

            ORM_CMN_STR_PPS_WorkArea item = new ORM_CMN_STR_PPS_WorkArea();
            if (Parameter.WorkAreaID != Guid.Empty)
            {
                var resultWorkplace = item.Load(Connection, Transaction, Parameter.WorkAreaID);
                if (resultWorkplace.Status != FR_Status.Success || item.CMN_STR_PPS_WorkAreaID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return null;

                }
            }
            result.CMN_CAL_CalendarInstance_RefID = item.CMN_CAL_CalendarInstance_RefID;
            result.CMN_BPT_STA_SettingProfile_RefID = item.CMN_BPT_STA_SettingProfile_RefID;
            result.Office_RefID = item.Office_RefID;
            result.Parent_RefID = item.Parent_RefID;
            result.WorkAreaName = item.Name;
            result.WorkAreaDescription = item.Description;
            result.ShortName = item.ShortName;
            result.CMN_STR_PPS_WorkAreaID = item.CMN_STR_PPS_WorkAreaID;
            result.Default_StartWorkingHour = item.Default_StartWorkingHour;



            ORM_CMN_STR_PPS_WorkArea_2_CostCenter.Query workareaToCostcenterQuery = new ORM_CMN_STR_PPS_WorkArea_2_CostCenter.Query();
            workareaToCostcenterQuery.WorkArea_RefID = Parameter.WorkAreaID;
            workareaToCostcenterQuery.Tenant_RefID = securityTicket.TenantID;
            workareaToCostcenterQuery.IsDeleted = false;
            List<ORM_CMN_STR_PPS_WorkArea_2_CostCenter> workareaToCostcenterList = ORM_CMN_STR_PPS_WorkArea_2_CostCenter.Query.Search(Connection, Transaction, workareaToCostcenterQuery);
            if (workareaToCostcenterList.Count != 0)
            {
                L5WA_GWAFT_1201_Costcenter costCenter = new L5WA_GWAFT_1201_Costcenter();
                ORM_CMN_STR_CostCenter costCenterItem = new ORM_CMN_STR_CostCenter();
                costCenterItem.Load(Connection, Transaction, workareaToCostcenterList[0].CostCenter_RefID);
                if (!costCenterItem.IsDeleted)
                {
                    costCenter.AssignmentID = workareaToCostcenterList[0].AssignmentID;
                    costCenter.CMN_STR_CostCenterID = workareaToCostcenterList[0].CostCenter_RefID;
                    costCenter.CostcenterName = costCenterItem.Name;
                    costCenter.InternalID = costCenterItem.InternalID;
                    result.Costcenter = costCenter;
                }
            }


            var responsiblePersonsQuery = new ORM_CMN_STR_PPS_WorkArea_ResponsiblePerson.Query();
            responsiblePersonsQuery.Tenant_RefID = securityTicket.TenantID;
            responsiblePersonsQuery.WorkArea_RefID = item.CMN_STR_PPS_WorkAreaID;
            responsiblePersonsQuery.IsDeleted = false;
            var responsiblePersonsList = ORM_CMN_STR_PPS_WorkArea_ResponsiblePerson.Query.Search(Connection, Transaction, responsiblePersonsQuery);
            List<L5WA_GWAFT_1201_ResponsiblePersons> responsiblePresonsResultList = new List<L5WA_GWAFT_1201_ResponsiblePersons>();
            foreach (var responsiblePerson in responsiblePersonsList)
            {
                L5WA_GWAFT_1201_ResponsiblePersons responsiblePersonResult = new L5WA_GWAFT_1201_ResponsiblePersons();
                responsiblePersonResult.CMN_BPT_EMP_EmployeeID = responsiblePerson.CMN_BPT_EMP_Employee_RefID;
                responsiblePersonResult.CMN_STR_PPS_WorkArea_ResponsiblePersonID = responsiblePerson.CMN_STR_PPS_WorkArea_ResponsiblePersonID;

                ORM_CMN_BPT_EMP_Employee employee = new ORM_CMN_BPT_EMP_Employee();
                employee.Load(Connection, Transaction, responsiblePerson.CMN_BPT_EMP_Employee_RefID);

                ORM_CMN_BPT_BusinessParticipant bParticipant = new ORM_CMN_BPT_BusinessParticipant();
                bParticipant.Load(Connection, Transaction, employee.BusinessParticipant_RefID);

                ORM_CMN_PER_PersonInfo person = new ORM_CMN_PER_PersonInfo();
                person.Load(Connection, Transaction, bParticipant.IfNaturalPerson_CMN_PER_PersonInfo_RefID);

                responsiblePersonResult.CMN_BPT_BusinessParticipantID = bParticipant.CMN_BPT_BusinessParticipantID;
                responsiblePersonResult.FirstName = person.FirstName;
                responsiblePersonResult.LastName = person.LastName;
                responsiblePersonResult.CMN_PER_PersonInfoID = person.CMN_PER_PersonInfoID;
                responsiblePersonResult.WorkArea_RefID = item.CMN_STR_PPS_WorkAreaID;

                responsiblePresonsResultList.Add(responsiblePersonResult);
            }

            result.ResponsiblePersons = responsiblePresonsResultList.ToArray();

            returnValue.Result.workarea = result;
			//Put your code here
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5WA_GWAFWA_0907 Invoke(string ConnectionString,P_L5WA_GWAFWA_0907 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5WA_GWAFWA_0907 Invoke(DbConnection Connection,P_L5WA_GWAFWA_0907 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5WA_GWAFWA_0907 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5WA_GWAFWA_0907 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5WA_GWAFWA_0907 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5WA_GWAFWA_0907 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5WA_GWAFWA_0907 functionReturn = new FR_L5WA_GWAFWA_0907();
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

				throw new Exception("Exception occured in method cls_Get_WorkArea_for_WorkAreaID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5WA_GWAFWA_0907 : FR_Base
	{
		public L5WA_GWAFWA_0907 Result	{ get; set; }

		public FR_L5WA_GWAFWA_0907() : base() {}

		public FR_L5WA_GWAFWA_0907(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5WA_GWAFWA_0907 cls_Get_WorkArea_for_WorkAreaID(,P_L5WA_GWAFWA_0907 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5WA_GWAFWA_0907 invocationResult = cls_Get_WorkArea_for_WorkAreaID.Invoke(connectionString,P_L5WA_GWAFWA_0907 Parameter,securityTicket);
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
var parameter = new CL5_VacationPlanner_WorkArea.complex.Retrieval.P_L5WA_GWAFWA_0907();
parameter.WorkAreaID = ...;

*/