/* 
 * Generated on 1/22/2014 3:39:24 PM
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
using CL1_CMN_PER;
using CL1_CMN_BPT;
using CL1_CMN_BPT_EMP;
using PlannicoModel.Models;

namespace CL5_VacationPlanner_WorkPlace.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Workplaces_For_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Workplaces_For_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5WP_GWFT_1203_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_L5WP_GWFT_1203_Array();


            L5WP_GWFT_1203 result = new L5WP_GWFT_1203();
            ORM_CMN_STR_PPS_Workplace.Query workplaceQuery=new ORM_CMN_STR_PPS_Workplace.Query();
            workplaceQuery.IsDeleted=false;
            workplaceQuery.Tenant_RefID=securityTicket.TenantID;
            List<ORM_CMN_STR_PPS_Workplace> workplaceResults=ORM_CMN_STR_PPS_Workplace.Query.Search(Connection,Transaction,workplaceQuery);
            List<L5WP_GWFT_1203> workplaceResultList=new List<L5WP_GWFT_1203>();
            foreach(var workplace in workplaceResults){
                result = new L5WP_GWFT_1203();
            ORM_CMN_STR_PPS_Workplace item = new ORM_CMN_STR_PPS_Workplace();
                var resultWorkplace = item.Load(Connection, Transaction, workplace.CMN_STR_PPS_WorkplaceID);
                if (resultWorkplace.Status != FR_Status.Success || item.CMN_STR_PPS_WorkplaceID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return null;

                }
            
            result.CMN_CAL_CalendarInstance_RefID = item.CMN_CAL_CalendarInstance_RefID;
            result.CMN_STR_PPS_WorkplaceID = workplace.CMN_STR_PPS_WorkplaceID;
            result.ShortName = item.ShortName;
            result.WorkArea_RefID = item.WorkArea_RefID;
            result.WorkPlaceDescription = item.Description;
            result.WorkPlaceName = item.Name;
            result.DisplayColor = item.DisplayColor;


            var responsiblePersonsQuery = new ORM_CMN_STR_PPS_Workplace_ResponsiblePerson.Query();
            responsiblePersonsQuery.Tenant_RefID = securityTicket.TenantID;
            responsiblePersonsQuery.Workplace_RefID = workplace.CMN_STR_PPS_WorkplaceID;
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
                workplaceResultList.Add(result);
            }

            returnValue.Result=workplaceResultList.ToArray();

			//Put your code here
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5WP_GWFT_1203_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5WP_GWFT_1203_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5WP_GWFT_1203_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5WP_GWFT_1203_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5WP_GWFT_1203_Array functionReturn = new FR_L5WP_GWFT_1203_Array();
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

				throw new Exception("Exception occured in method cls_Get_Workplaces_For_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5WP_GWFT_1203_raw 
	{
		public Guid CMN_STR_PPS_WorkplaceID; 
		public Guid WorkArea_RefID; 
		public Dict WorkPlaceName; 
		public Dict WorkPlaceDescription; 
		public String ShortName; 
		public Guid CMN_CAL_CalendarInstance_RefID; 
		public Guid CMN_STR_PPS_Workplace_ResponsiblePersonID; 
		public Guid CMN_BPT_EMP_EmployeeID; 
		public Guid CMN_BPT_BusinessParticipantID; 
		public String LastName; 
		public Guid CMN_PER_PersonInfoID; 
		public String FirstName; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5WP_GWFT_1203[] Convert(List<L5WP_GWFT_1203_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5WP_GWFT_1203 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.CMN_STR_PPS_WorkplaceID)).ToArray()
	group el_L5WP_GWFT_1203 by new 
	{ 
		el_L5WP_GWFT_1203.CMN_STR_PPS_WorkplaceID,

	}
	into gfunct_L5WP_GWFT_1203
	select new L5WP_GWFT_1203
	{     
		CMN_STR_PPS_WorkplaceID = gfunct_L5WP_GWFT_1203.Key.CMN_STR_PPS_WorkplaceID ,
		WorkArea_RefID = gfunct_L5WP_GWFT_1203.FirstOrDefault().WorkArea_RefID ,
		WorkPlaceName = gfunct_L5WP_GWFT_1203.FirstOrDefault().WorkPlaceName ,
		WorkPlaceDescription = gfunct_L5WP_GWFT_1203.FirstOrDefault().WorkPlaceDescription ,
		ShortName = gfunct_L5WP_GWFT_1203.FirstOrDefault().ShortName ,
		CMN_CAL_CalendarInstance_RefID = gfunct_L5WP_GWFT_1203.FirstOrDefault().CMN_CAL_CalendarInstance_RefID ,

		ResponsiblePersons = 
		(
			from el_ResponsiblePersons in gfunct_L5WP_GWFT_1203.Where(element => !EqualsDefaultValue(element.CMN_STR_PPS_Workplace_ResponsiblePersonID)).ToArray()
			group el_ResponsiblePersons by new 
			{ 
				el_ResponsiblePersons.CMN_STR_PPS_Workplace_ResponsiblePersonID,

			}
			into gfunct_ResponsiblePersons
			select new L5WP_GWFT_1203_ResponsiblePerson
			{     
				CMN_STR_PPS_Workplace_ResponsiblePersonID = gfunct_ResponsiblePersons.Key.CMN_STR_PPS_Workplace_ResponsiblePersonID ,
				CMN_BPT_EMP_EmployeeID = gfunct_ResponsiblePersons.FirstOrDefault().CMN_BPT_EMP_EmployeeID ,
				CMN_BPT_BusinessParticipantID = gfunct_ResponsiblePersons.FirstOrDefault().CMN_BPT_BusinessParticipantID ,
				LastName = gfunct_ResponsiblePersons.FirstOrDefault().LastName ,
				CMN_PER_PersonInfoID = gfunct_ResponsiblePersons.FirstOrDefault().CMN_PER_PersonInfoID ,
				FirstName = gfunct_ResponsiblePersons.FirstOrDefault().FirstName ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5WP_GWFT_1203_Array : FR_Base
	{
		public L5WP_GWFT_1203[] Result	{ get; set; } 
		public FR_L5WP_GWFT_1203_Array() : base() {}

		public FR_L5WP_GWFT_1203_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5WP_GWFT_1203_Array cls_Get_Workplaces_For_Tenant(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5WP_GWFT_1203_Array invocationResult = cls_Get_Workplaces_For_Tenant.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/
