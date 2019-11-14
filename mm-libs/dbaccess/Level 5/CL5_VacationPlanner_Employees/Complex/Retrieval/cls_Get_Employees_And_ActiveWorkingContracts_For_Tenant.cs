/* 
 * Generated on 2/11/2014 2:41:12 PM
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
using CL1_CMN_STR;
using CL1_CMN;
using CL1_CMN_BPT_EMP;
using CL1_CMN_BPT;
using CL1_CMN_PER;
using CL1_CMN_CAL;
using CL1_CMN_BPT_STA;
using PlannicoModel.Models;

namespace CL5_VacationPlanner_Employees.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Employees_And_ActiveWorkingContracts_For_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Employees_And_ActiveWorkingContracts_For_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5EM_GEAAWCFT_1210_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5EM_GEAAWCFT_1210_Array();

            List<L5EM_GEAAWCFT_1210> resultList = new List<L5EM_GEAAWCFT_1210>();
            List<Guid> employeeIDs = new List<Guid>();
            ORM_CMN_BPT_EMP_Employee.Query employeeQuery = new ORM_CMN_BPT_EMP_Employee.Query();
            employeeQuery.IsDeleted = false;
            employeeQuery.Tenant_RefID = securityTicket.TenantID;
            List<ORM_CMN_BPT_EMP_Employee> employeeList = ORM_CMN_BPT_EMP_Employee.Query.Search(Connection, Transaction, employeeQuery);
            foreach (var employeeItem in employeeList)
            {
                L5EM_GEAAWCFT_1210 result = new L5EM_GEAAWCFT_1210();
                ORM_CMN_BPT_EMP_Employee employee = new ORM_CMN_BPT_EMP_Employee();
                employee.Load(Connection, Transaction, employeeItem.CMN_BPT_EMP_EmployeeID);
                result.CMN_BPT_EMP_EmployeeID = employee.CMN_BPT_EMP_EmployeeID;
                result.Staff_Number = employee.Staff_Number;
                result.StandardFunction = employee.StandardFunction;

                ORM_CMN_BPT_EMP_EmploymentRelationship.Query employmentRelationshipQuery = new ORM_CMN_BPT_EMP_EmploymentRelationship.Query();
                employmentRelationshipQuery.Employee_RefID = employee.CMN_BPT_EMP_EmployeeID;
                employmentRelationshipQuery.IsDeleted = false;
                employmentRelationshipQuery.Tenant_RefID = securityTicket.TenantID;
                ORM_CMN_BPT_EMP_EmploymentRelationship employmentRelationship = ORM_CMN_BPT_EMP_EmploymentRelationship.Query.Search(Connection, Transaction, employmentRelationshipQuery).FirstOrDefault();

                if (employmentRelationship == null)
                    continue;
                ORM_CMN_BPT_EMP_EmploymentRelationship_2_WorkingContract.Query employmentRelationship_2_WorkingContractQuery = new ORM_CMN_BPT_EMP_EmploymentRelationship_2_WorkingContract.Query();
                employmentRelationship_2_WorkingContractQuery.EmploymentRelationship_RefID = employmentRelationship.CMN_BPT_EMP_EmploymentRelationshipID;
                employmentRelationship_2_WorkingContractQuery.IsDeleted = false;
                employmentRelationship_2_WorkingContractQuery.Tenant_RefID = securityTicket.TenantID;
                employmentRelationship_2_WorkingContractQuery.IsContract_Active = true;
                List<ORM_CMN_BPT_EMP_EmploymentRelationship_2_WorkingContract> employmentRelationship_2_WorkingContractList = ORM_CMN_BPT_EMP_EmploymentRelationship_2_WorkingContract.Query.Search(Connection, Transaction, employmentRelationship_2_WorkingContractQuery);
                if (employmentRelationship_2_WorkingContractList.Count == 0)
                    continue;

                ORM_CMN_BPT_BusinessParticipant businessParticipant = new ORM_CMN_BPT_BusinessParticipant();
                businessParticipant.Load(Connection, Transaction, employee.BusinessParticipant_RefID);

                result.CMN_BPT_BusinessParticipantID = businessParticipant.CMN_BPT_BusinessParticipantID;
                result.DisplayName = businessParticipant.DisplayName;

                ORM_CMN_PER_PersonInfo personInfo = new ORM_CMN_PER_PersonInfo();
                personInfo.Load(Connection, Transaction, businessParticipant.IfNaturalPerson_CMN_PER_PersonInfo_RefID);
                result.CMN_PER_PersonInfoID = personInfo.CMN_PER_PersonInfoID;
                result.FirstName = personInfo.FirstName;
                result.LastName = personInfo.LastName;
                result.PrimaryEmail = personInfo.PrimaryEmail;
                result.Title = personInfo.Title;
                result.ProfileImage_Document_RefID = personInfo.ProfileImage_Document_RefID;
                result.BirthDate = personInfo.BirthDate;


                result.CMN_BPT_EMP_EmploymentRelationshipID = employmentRelationship.CMN_BPT_EMP_EmploymentRelationshipID;
                result.Work_StartDate = employmentRelationship.Work_StartDate;
                result.Work_EndDate = employmentRelationship.Work_EndDate;

                //Address
                if (personInfo.Address_RefID != Guid.Empty)
                {
                    ORM_CMN_Address address = new ORM_CMN_Address();
                    address.Load(Connection, Transaction, personInfo.Address_RefID);
                    result.CMN_AddressID = address.CMN_AddressID;
                    result.Street_Name = address.Street_Name;
                    result.Street_Number = address.Street_Number;
                    result.City_AdministrativeDistrict = address.City_AdministrativeDistrict;
                    result.City_Region = address.City_Region;
                    result.City_Name = address.City_Name;
                    result.City_PostalCode = address.City_PostalCode;
                    result.Province_Name = address.Province_Name;
                    result.Country_Name = address.Country_Name;
                    result.Country_ISOCode = address.Country_ISOCode;
                }

                //Contacts
                ORM_CMN_PER_CommunicationContact comunicationContactQuery = new ORM_CMN_PER_CommunicationContact();
                comunicationContactQuery.PersonInfo_RefID = personInfo.CMN_PER_PersonInfoID;
                comunicationContactQuery.Tenant_RefID = securityTicket.TenantID;
                comunicationContactQuery.IsDeleted = false;
                List<ORM_CMN_PER_CommunicationContact> comunicationContacts = new List<ORM_CMN_PER_CommunicationContact>();
                List<L5EM_GEAAWCFT_1210_Contacts> resultComunicationContacts = new List<L5EM_GEAAWCFT_1210_Contacts>();
                foreach (var comunicationContact in comunicationContacts)
                {
                    ORM_CMN_PER_CommunicationContact_Type contactType = new ORM_CMN_PER_CommunicationContact_Type();
                    contactType.Load(Connection, Transaction, comunicationContact.CMN_PER_CommunicationContactID);
                    L5EM_GEAAWCFT_1210_Contacts resultComunicationContact = new L5EM_GEAAWCFT_1210_Contacts();
                    resultComunicationContact.CMN_PER_CommunicationContact_TypeID = contactType.CMN_PER_CommunicationContact_TypeID;
                    resultComunicationContact.CMN_PER_CommunicationContactID = comunicationContact.CMN_PER_CommunicationContactID;
                    resultComunicationContact.Content = comunicationContact.Content;
                    resultComunicationContact.Type = contactType.Type;
                    resultComunicationContacts.Add(resultComunicationContact);
                }
                result.Contacts = resultComunicationContacts.ToArray();


                //Employee workplace history
                ORM_CMN_BPT_EMP_Employee_WorkplaceAssignment.Query employeeWorkplaceAssignmentsQuery = new ORM_CMN_BPT_EMP_Employee_WorkplaceAssignment.Query();
                employeeWorkplaceAssignmentsQuery.CMN_BPT_EMP_Employee_RefID = employee.CMN_BPT_EMP_EmployeeID;
                employeeWorkplaceAssignmentsQuery.Tenant_RefID = securityTicket.TenantID;
                employeeWorkplaceAssignmentsQuery.IsDeleted = false;
                List<ORM_CMN_BPT_EMP_Employee_WorkplaceAssignment> employeeWorkplaceAssignemntsList = ORM_CMN_BPT_EMP_Employee_WorkplaceAssignment.Query.Search(Connection, Transaction, employeeWorkplaceAssignmentsQuery);
                List<L5EM_GEAAWCFT_1210_EmployeeWorkplaceHistory> employeeWorkplaceAssignments = new List<L5EM_GEAAWCFT_1210_EmployeeWorkplaceHistory>();

                foreach (var workplaceAssignemns in employeeWorkplaceAssignemntsList)
                {
                    L5EM_GEAAWCFT_1210_EmployeeWorkplaceHistory item = new L5EM_GEAAWCFT_1210_EmployeeWorkplaceHistory();
                    item.BoundTo_Workplace_RefID = workplaceAssignemns.BoundTo_Workplace_RefID;
                    item.CMN_BPT_EMP_Employee_PlanGroup_RefID = workplaceAssignemns.CMN_BPT_EMP_Employee_PlanGroup_RefID;
                    item.CMN_BPT_EMP_Employee_WorkplaceAssignmentID = workplaceAssignemns.CMN_BPT_EMP_Employee_WorkplaceAssignment;
                    item.Default_BreakTime_Template_RefID = workplaceAssignemns.Default_BreakTime_Template_RefID;
                    item.IsBreakTimeCalculated_Actual = workplaceAssignemns.IsBreakTimeCalculated_Actual;
                    item.IsBreakTimeCalculated_Planning = workplaceAssignemns.IsBreakTimeCalculated_Planning;
                    item.SequenceNumber = workplaceAssignemns.SequenceNumber;
                    item.WorkplaceAssignment_StartDate = workplaceAssignemns.WorkplaceAssignment_StartDate;

                    employeeWorkplaceAssignments.Add(item);
                }

                result.EmployeeWorkplaceHistory = employeeWorkplaceAssignments.ToArray();




                L5EM_GEAAWCFT_1210_WorkingContract resultWorkingContract = new L5EM_GEAAWCFT_1210_WorkingContract();

                ORM_CMN_BPT_EMP_WorkingContract workingContract = new ORM_CMN_BPT_EMP_WorkingContract();
                workingContract.Load(Connection, Transaction, employmentRelationship_2_WorkingContractList[0].WorkingContract_RefID);
                resultWorkingContract.CMN_BPT_EMP_WorkingContractID = workingContract.CMN_BPT_EMP_WorkingContractID;
                resultWorkingContract.EmploymentRelationship_2_WorkingContractAssigmentID = employmentRelationship_2_WorkingContractList[0].AssignmentID;
                resultWorkingContract.IsContract_Active = employmentRelationship_2_WorkingContractList[0].IsContract_Active;
                resultWorkingContract.Contract_StartDate = workingContract.Contract_StartDate;
                resultWorkingContract.Contract_EndDate = workingContract.Contract_EndDate;
                resultWorkingContract.IsContractEndDateDefined = workingContract.IsContractEndDateDefined;
                resultWorkingContract.IsWorkTimeCalculated_InDays = workingContract.IsWorkTimeCalculated_InDays;
                resultWorkingContract.IsWorkTimeCalculated_InHours = workingContract.IsWorkTimeCalculated_InHours;
                resultWorkingContract.R_WorkTime_DaysPerWeek = workingContract.R_WorkTime_DaysPerWeek;
                resultWorkingContract.R_WorkTime_HoursPerWeek = workingContract.R_WorkTime_HoursPerWeek;

                //Office hours
                ORM_CMN_BPT_EMP_WorkingContract_2_WorkingDay.Query workingContractToWorkingDayQuery = new ORM_CMN_BPT_EMP_WorkingContract_2_WorkingDay.Query();
                workingContractToWorkingDayQuery.CMN_BPT_EMP_WorkingContract_RefID = workingContract.CMN_BPT_EMP_WorkingContractID;
                //workingContractToWorkingDayQuery.Tenant_RefID = securityTicket.TenantID;
                workingContractToWorkingDayQuery.IsDeleted = false;
                List<ORM_CMN_BPT_EMP_WorkingContract_2_WorkingDay> workingDayAssigments = ORM_CMN_BPT_EMP_WorkingContract_2_WorkingDay.Query.Search(Connection, Transaction, workingContractToWorkingDayQuery);
                List<L5EM_GEAAWCFT_1210_WeeklyOfficeHour> resultWeeklyOfficeHours = new List<L5EM_GEAAWCFT_1210_WeeklyOfficeHour>();
                foreach (var workingDayAssigment in workingDayAssigments)
                {

                    ORM_CMN_CAL_WeeklyOfficeHours_Interval interval = new ORM_CMN_CAL_WeeklyOfficeHours_Interval();
                    interval.Load(Connection, Transaction, workingDayAssigment.CMN_CAL_WeeklyOfficeHours_Interval_RefID);

                    L5EM_GEAAWCFT_1210_WeeklyOfficeHour resultOfficeHour = new L5EM_GEAAWCFT_1210_WeeklyOfficeHour();
                    resultOfficeHour.CMN_CAL_WeeklyOfficeHours_IntervalID = interval.CMN_CAL_WeeklyOfficeHours_IntervalID;
                    resultOfficeHour.IsFriday = interval.IsFriday;
                    resultOfficeHour.IsMonday = interval.IsMonday;
                    resultOfficeHour.IsSaturday = interval.IsSaturday;
                    resultOfficeHour.IsSunday = interval.IsSunday;
                    resultOfficeHour.IsThursday = interval.IsThursday;
                    resultOfficeHour.IsTuesday = interval.IsTuesday;
                    resultOfficeHour.IsWednesday = interval.IsWednesday;
                    resultOfficeHour.IsWholeDay = interval.IsWholeDay;
                    resultOfficeHour.TimeFrom_InMinutes = interval.TimeFrom_InMinutes;
                    resultOfficeHour.TimeTo_InMinutes = interval.TimeTo_InMinutes;
                    resultWeeklyOfficeHours.Add(resultOfficeHour);
                }
                resultWorkingContract.WeeklyOfficeHours = resultWeeklyOfficeHours.ToArray();


                //Allowed absence reasons
                ORM_CMN_BPT_EMP_WorkingContract_AllowedAbsenceReason.Query AllowedAbsenceReasonQuery = new ORM_CMN_BPT_EMP_WorkingContract_AllowedAbsenceReason.Query();
                AllowedAbsenceReasonQuery.WorkingContract_RefID = workingContract.CMN_BPT_EMP_WorkingContractID;
                AllowedAbsenceReasonQuery.Tenant_RefID = securityTicket.TenantID;
                AllowedAbsenceReasonQuery.IsDeleted = false;
                List<ORM_CMN_BPT_EMP_WorkingContract_AllowedAbsenceReason> allowedAbsenceReasons = ORM_CMN_BPT_EMP_WorkingContract_AllowedAbsenceReason.Query.Search(Connection, Transaction, AllowedAbsenceReasonQuery);
                List<L5EM_GEAAWCFT_1210_WorkingContract2LeaveRequest> resultAllowedAbsenceReasons = new List<L5EM_GEAAWCFT_1210_WorkingContract2LeaveRequest>();
                foreach (var allowedAbsenceReason in allowedAbsenceReasons)
                {
                    ORM_CMN_BPT_STA_AbsenceReason absenceReason = new ORM_CMN_BPT_STA_AbsenceReason();
                    absenceReason.Load(Connection, Transaction, allowedAbsenceReason.STA_AbsenceReason_RefID);

                    L5EM_GEAAWCFT_1210_WorkingContract2LeaveRequest resultReasonresultReason = new L5EM_GEAAWCFT_1210_WorkingContract2LeaveRequest();
                    resultReasonresultReason.IsAbsenceCalculated_InDays = allowedAbsenceReason.IsAbsenceCalculated_InDays;
                    resultReasonresultReason.IsAbsenceCalculated_InHours = allowedAbsenceReason.IsAbsenceCalculated_InHours;
                    resultReasonresultReason.ContractAllowedAbsence_per_Month = allowedAbsenceReason.ContractAllowedAbsence_per_Month;
                    resultReasonresultReason.STA_AbsenceReason_RefID = allowedAbsenceReason.STA_AbsenceReason_RefID;
                    resultAllowedAbsenceReasons.Add(resultReasonresultReason);
                }
                resultWorkingContract.WorkingContract2LeaveRequest = resultAllowedAbsenceReasons.ToArray();



                result.ActiveWorkingContract = resultWorkingContract;
                resultList.Add(result);
            }
            returnValue.Result = resultList.ToArray();
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5EM_GEAAWCFT_1210_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5EM_GEAAWCFT_1210_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5EM_GEAAWCFT_1210_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5EM_GEAAWCFT_1210_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5EM_GEAAWCFT_1210_Array functionReturn = new FR_L5EM_GEAAWCFT_1210_Array();
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

				throw new Exception("Exception occured in method cls_Get_Employees_And_ActiveWorkingContracts_For_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5EM_GEAAWCFT_1210_Array : FR_Base
	{
		public L5EM_GEAAWCFT_1210[] Result	{ get; set; } 
		public FR_L5EM_GEAAWCFT_1210_Array() : base() {}

		public FR_L5EM_GEAAWCFT_1210_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5EM_GEAAWCFT_1210_Array cls_Get_Employees_And_ActiveWorkingContracts_For_Tenant(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5EM_GEAAWCFT_1210_Array invocationResult = cls_Get_Employees_And_ActiveWorkingContracts_For_Tenant.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/
