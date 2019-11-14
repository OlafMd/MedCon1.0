/* 
 * Generated on 1/13/2014 11:32:41 AM
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
using CL5_VacationPlanner_WorkPlace.Atomic.Retrieval;
using CL1_CMN_STR_PPS;
using CL1_CMN_BPT_EMP;
using CL1_CMN_BPT;
using CL1_CMN_PER;
using PlannicoModel.Models;

namespace CL5_VacationPlanner_WorkPlace.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Workplaces_For_WorkplaceID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Workplaces_For_WorkplaceID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5WP_GWPFWPID_1132 Execute(DbConnection Connection,DbTransaction Transaction,P_L5WP_GWPFWPID_1132 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_L5WP_GWPFWPID_1132();

            returnValue.Result = new L5WP_GWPFWPID_1132();

            L5WP_GWFT_1203 result = new L5WP_GWFT_1203();

            ORM_CMN_STR_PPS_Workplace item = new ORM_CMN_STR_PPS_Workplace();
            if (Parameter.workplaceID != Guid.Empty)
            {
                var resultWorkplace = item.Load(Connection, Transaction, Parameter.workplaceID);
                if (resultWorkplace.Status != FR_Status.Success || item.CMN_STR_PPS_WorkplaceID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return null;

                }
            }
            result.CMN_CAL_CalendarInstance_RefID = item.CMN_CAL_CalendarInstance_RefID;
            result.CMN_STR_PPS_WorkplaceID = item.CMN_STR_PPS_WorkplaceID;
            result.ShortName = item.ShortName;
            result.WorkArea_RefID = item.WorkArea_RefID;
            result.WorkPlaceDescription = item.Description;
            result.WorkPlaceName = item.Name;


            var responsiblePersonsQuery = new ORM_CMN_STR_PPS_Workplace_ResponsiblePerson.Query();
            responsiblePersonsQuery.Tenant_RefID = securityTicket.TenantID;
            responsiblePersonsQuery.Workplace_RefID = item.CMN_STR_PPS_WorkplaceID;
            responsiblePersonsQuery.IsDeleted = false;
            var responsiblePersonsList = ORM_CMN_STR_PPS_Workplace_ResponsiblePerson.Query.Search(Connection, Transaction, responsiblePersonsQuery);
            List<L5WP_GWFT_1203_ResponsiblePerson> responsiblePresonsResultList = new List<L5WP_GWFT_1203_ResponsiblePerson>();
            foreach (var responsiblePerson in responsiblePersonsList)
            {
                L5WP_GWFT_1203_ResponsiblePerson responsiblePersonResult = new L5WP_GWFT_1203_ResponsiblePerson();
                responsiblePersonResult.CMN_BPT_EMP_EmployeeID = responsiblePerson.CMN_BPT_EMP_Employee_RefID;
                responsiblePersonResult.CMN_STR_PPS_Workplace_ResponsiblePersonID = responsiblePerson.CMN_STR_PPS_Workplace_ResponsiblePersonID;

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
                responsiblePresonsResultList.Add(responsiblePersonResult);
            }

            result.ResponsiblePersons = responsiblePresonsResultList.ToArray();
            returnValue.Result.workplace = result;
			//Put your code here
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5WP_GWPFWPID_1132 Invoke(string ConnectionString,P_L5WP_GWPFWPID_1132 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5WP_GWPFWPID_1132 Invoke(DbConnection Connection,P_L5WP_GWPFWPID_1132 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5WP_GWPFWPID_1132 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5WP_GWPFWPID_1132 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5WP_GWPFWPID_1132 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5WP_GWPFWPID_1132 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5WP_GWPFWPID_1132 functionReturn = new FR_L5WP_GWPFWPID_1132();
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

				throw new Exception("Exception occured in method cls_Get_Workplaces_For_WorkplaceID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5WP_GWPFWPID_1132 : FR_Base
	{
		public L5WP_GWPFWPID_1132 Result	{ get; set; }

		public FR_L5WP_GWPFWPID_1132() : base() {}

		public FR_L5WP_GWPFWPID_1132(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5WP_GWPFWPID_1132 cls_Get_Workplaces_For_WorkplaceID(,P_L5WP_GWPFWPID_1132 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5WP_GWPFWPID_1132 invocationResult = cls_Get_Workplaces_For_WorkplaceID.Invoke(connectionString,P_L5WP_GWPFWPID_1132 Parameter,securityTicket);
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
var parameter = new CL5_VacationPlanner_WorkPlace.Complex.Retrieval.P_L5WP_GWPFWPID_1132();
parameter.workplaceID = ...;

*/