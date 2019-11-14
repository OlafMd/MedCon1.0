/* 
 * Generated on 1/22/2014 3:13:34 PM
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
using CL1_CMN_BPT_EMP;
using CL1_CMN_BPT;
using CL1_CMN_PER;
using CL1_CMN_STR;
using PlannicoModel.Models;

namespace CL5_VacationPlanner_WorkArea.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_WorkAreas_For_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_WorkAreas_For_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5WA_GWAFT_1201_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_L5WA_GWAFT_1201_Array();
            ORM_CMN_STR_PPS_WorkArea.Query workareaQuery=new ORM_CMN_STR_PPS_WorkArea.Query();
            workareaQuery.IsDeleted=false;
            workareaQuery.Tenant_RefID=securityTicket.TenantID;
            List<ORM_CMN_STR_PPS_WorkArea> workareaResult=ORM_CMN_STR_PPS_WorkArea.Query.Search(Connection,Transaction,workareaQuery);
            List<L5WA_GWAFT_1201> workareaResultList=new List<L5WA_GWAFT_1201>();
            foreach(var workarea in workareaResult){

            L5WA_GWAFT_1201 result = new L5WA_GWAFT_1201();

            ORM_CMN_STR_PPS_WorkArea item = new ORM_CMN_STR_PPS_WorkArea();
                var resultWorkplace = item.Load(Connection, Transaction, workarea.CMN_STR_PPS_WorkAreaID);
                if (resultWorkplace.Status != FR_Status.Success || item.CMN_STR_PPS_WorkAreaID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return null;

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
            workareaToCostcenterQuery.WorkArea_RefID = workarea.CMN_STR_PPS_WorkAreaID;
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
            workareaResultList.Add(result);
            }
            returnValue.Result=workareaResultList.ToArray();

			//Put your code here
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5WA_GWAFT_1201_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5WA_GWAFT_1201_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5WA_GWAFT_1201_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5WA_GWAFT_1201_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5WA_GWAFT_1201_Array functionReturn = new FR_L5WA_GWAFT_1201_Array();
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

				throw new Exception("Exception occured in method cls_Get_WorkAreas_For_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5WA_GWAFT_1201_raw 
	{
		public Guid CMN_STR_PPS_WorkAreaID; 
		public Guid Parent_RefID; 
		public Guid Office_RefID; 
		public Dict WorkAreaName; 
		public Dict WorkAreaDescription; 
		public int Default_StartWorkingHour; 
		public String ShortName; 
		public Guid CMN_BPT_STA_SettingProfile_RefID; 
		public Guid CMN_CAL_CalendarInstance_RefID; 
		public Guid AssignmentID; 
		public Guid CMN_STR_CostCenterID; 
		public String InternalID; 
		public Dict CostcenterName; 
		public Guid WorkArea_RefID; 
		public Guid CMN_STR_PPS_WorkArea_ResponsiblePersonID; 
		public Guid CMN_BPT_EMP_EmployeeID; 
		public Guid CMN_BPT_BusinessParticipantID; 
		public String FirstName; 
		public String LastName; 
		public Guid CMN_PER_PersonInfoID; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5WA_GWAFT_1201[] Convert(List<L5WA_GWAFT_1201_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5WA_GWAFT_1201 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.CMN_STR_PPS_WorkAreaID)).ToArray()
	group el_L5WA_GWAFT_1201 by new 
	{ 
		el_L5WA_GWAFT_1201.CMN_STR_PPS_WorkAreaID,

	}
	into gfunct_L5WA_GWAFT_1201
	select new L5WA_GWAFT_1201
	{     
		CMN_STR_PPS_WorkAreaID = gfunct_L5WA_GWAFT_1201.Key.CMN_STR_PPS_WorkAreaID ,
		Parent_RefID = gfunct_L5WA_GWAFT_1201.FirstOrDefault().Parent_RefID ,
		Office_RefID = gfunct_L5WA_GWAFT_1201.FirstOrDefault().Office_RefID ,
		WorkAreaName = gfunct_L5WA_GWAFT_1201.FirstOrDefault().WorkAreaName ,
		WorkAreaDescription = gfunct_L5WA_GWAFT_1201.FirstOrDefault().WorkAreaDescription ,
		Default_StartWorkingHour = gfunct_L5WA_GWAFT_1201.FirstOrDefault().Default_StartWorkingHour ,
		ShortName = gfunct_L5WA_GWAFT_1201.FirstOrDefault().ShortName ,
		CMN_BPT_STA_SettingProfile_RefID = gfunct_L5WA_GWAFT_1201.FirstOrDefault().CMN_BPT_STA_SettingProfile_RefID ,
		CMN_CAL_CalendarInstance_RefID = gfunct_L5WA_GWAFT_1201.FirstOrDefault().CMN_CAL_CalendarInstance_RefID ,

		Costcenter = 
		(
			from el_Costcenter in gfunct_L5WA_GWAFT_1201.Where(element => !EqualsDefaultValue(element.AssignmentID)).ToArray()
			group el_Costcenter by new 
			{ 
				el_Costcenter.AssignmentID,

			}
			into gfunct_Costcenter
			select new L5WA_GWAFT_1201_Costcenter
			{     
				AssignmentID = gfunct_Costcenter.Key.AssignmentID ,
				CMN_STR_CostCenterID = gfunct_Costcenter.FirstOrDefault().CMN_STR_CostCenterID ,
				InternalID = gfunct_Costcenter.FirstOrDefault().InternalID ,
				CostcenterName = gfunct_Costcenter.FirstOrDefault().CostcenterName ,

			}
		).FirstOrDefault(),
		ResponsiblePersons = 
		(
			from el_ResponsiblePersons in gfunct_L5WA_GWAFT_1201.Where(element => !EqualsDefaultValue(element.CMN_STR_PPS_WorkArea_ResponsiblePersonID)).ToArray()
			group el_ResponsiblePersons by new 
			{ 
				el_ResponsiblePersons.CMN_STR_PPS_WorkArea_ResponsiblePersonID,

			}
			into gfunct_ResponsiblePersons
			select new L5WA_GWAFT_1201_ResponsiblePersons
			{     
				WorkArea_RefID = gfunct_ResponsiblePersons.FirstOrDefault().WorkArea_RefID ,
				CMN_STR_PPS_WorkArea_ResponsiblePersonID = gfunct_ResponsiblePersons.Key.CMN_STR_PPS_WorkArea_ResponsiblePersonID ,
				CMN_BPT_EMP_EmployeeID = gfunct_ResponsiblePersons.FirstOrDefault().CMN_BPT_EMP_EmployeeID ,
				CMN_BPT_BusinessParticipantID = gfunct_ResponsiblePersons.FirstOrDefault().CMN_BPT_BusinessParticipantID ,
				FirstName = gfunct_ResponsiblePersons.FirstOrDefault().FirstName ,
				LastName = gfunct_ResponsiblePersons.FirstOrDefault().LastName ,
				CMN_PER_PersonInfoID = gfunct_ResponsiblePersons.FirstOrDefault().CMN_PER_PersonInfoID ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5WA_GWAFT_1201_Array : FR_Base
	{
		public L5WA_GWAFT_1201[] Result	{ get; set; } 
		public FR_L5WA_GWAFT_1201_Array() : base() {}

		public FR_L5WA_GWAFT_1201_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5WA_GWAFT_1201_Array cls_Get_WorkAreas_For_Tenant(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5WA_GWAFT_1201_Array invocationResult = cls_Get_WorkAreas_For_Tenant.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/
