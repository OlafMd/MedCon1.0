/* 
 * Generated on 2/11/2014 2:34:17 PM
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
using CL1_CMN_BPT_EMP;
using CL1_USR;
using CL1_CMN_BPT;
using CL1_CMN_PER;
using CL1_CMN;
using CL1_CMN_STR_PPS;
using CL1_CMN_STR;
using CL1_CMN_CAL;
using CL1_CMN_BPT_STA;
using PlannicoModel.Models;


namespace CL5_VacationPlanner_Employees.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Employees_For_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Employees_For_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5EM_GEFT_0959_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5EM_GEFT_0959_Array();
            List<L5EM_GEFT_0959> employeeResultList=new List<L5EM_GEFT_0959>();
            ORM_CMN_BPT_EMP_Employee.Query employeeQuery = new ORM_CMN_BPT_EMP_Employee.Query();
            employeeQuery.IsDeleted = false;
            employeeQuery.Tenant_RefID = securityTicket.TenantID;
            List<ORM_CMN_BPT_EMP_Employee> employeeList = ORM_CMN_BPT_EMP_Employee.Query.Search(Connection, Transaction, employeeQuery);
            
		    foreach(var employeeItem in employeeList)
		    {
                L5EM_GEFT_0959 result=new L5EM_GEFT_0959();
                ORM_CMN_BPT_EMP_Employee employee = new ORM_CMN_BPT_EMP_Employee();
		        employee.Load(Connection, Transaction, employeeItem.CMN_BPT_EMP_EmployeeID);
		        result.CMN_BPT_EMP_EmployeeID = employee.CMN_BPT_EMP_EmployeeID;
                result.Staff_Number = employee.Staff_Number;
                result.StandardFunction = employee.StandardFunction;

                ORM_USR_Account.Query accountQuery = new ORM_USR_Account.Query();
                accountQuery.BusinessParticipant_RefID = employee.BusinessParticipant_RefID;
                accountQuery.Tenant_RefID = securityTicket.TenantID;
                accountQuery.IsDeleted = false;
                ORM_USR_Account account = ORM_USR_Account.Query.Search(Connection, Transaction, accountQuery).FirstOrDefault();
                if (account != null)
                {
                    result.USR_AccountID = account.USR_AccountID;
                }

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

                ORM_CMN_BPT_EMP_EmploymentRelationship.Query workingContractQuery = new ORM_CMN_BPT_EMP_EmploymentRelationship.Query();
                workingContractQuery.Employee_RefID = employee.CMN_BPT_EMP_EmployeeID;
                workingContractQuery.IsDeleted = false;
                workingContractQuery.Tenant_RefID = securityTicket.TenantID;
                ORM_CMN_BPT_EMP_EmploymentRelationship employmentRelationship = ORM_CMN_BPT_EMP_EmploymentRelationship.Query.Search(Connection, Transaction, workingContractQuery).FirstOrDefault();

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
                ORM_CMN_PER_CommunicationContact.Query comunicationContactQuery = new ORM_CMN_PER_CommunicationContact.Query();
                comunicationContactQuery.PersonInfo_RefID = personInfo.CMN_PER_PersonInfoID;
                comunicationContactQuery.Tenant_RefID = securityTicket.TenantID;
                comunicationContactQuery.IsDeleted = false;
                List<ORM_CMN_PER_CommunicationContact> comunicationContacts = ORM_CMN_PER_CommunicationContact.Query.Search(Connection, Transaction, comunicationContactQuery);
                List<L5EM_GEFT_0959_Contacts> resultComunicationContacts = new List<L5EM_GEFT_0959_Contacts>();
                foreach (var comunicationContact in comunicationContacts)
                {            
                    ORM_CMN_PER_CommunicationContact_Type contactType = new ORM_CMN_PER_CommunicationContact_Type();
                    contactType.Load(Connection, Transaction, comunicationContact.CMN_PER_CommunicationContactID);
                    L5EM_GEFT_0959_Contacts resultComunicationContact = new L5EM_GEFT_0959_Contacts();
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
                List<L5EM_GEFT_0959_EmployeeWorkplaceHistory> employeeWorkplaceAssignments = new List<L5EM_GEFT_0959_EmployeeWorkplaceHistory>();

                foreach (var workplaceAssignemns in employeeWorkplaceAssignemntsList)
                {
                    L5EM_GEFT_0959_EmployeeWorkplaceHistory item = new L5EM_GEFT_0959_EmployeeWorkplaceHistory();
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


                //Contracts

                ORM_CMN_BPT_EMP_EmploymentRelationship_2_WorkingContract.Query contractTermQuery = new ORM_CMN_BPT_EMP_EmploymentRelationship_2_WorkingContract.Query();
                contractTermQuery.EmploymentRelationship_RefID = employmentRelationship.CMN_BPT_EMP_EmploymentRelationshipID;
                contractTermQuery.IsDeleted = false;
                contractTermQuery.Tenant_RefID = securityTicket.TenantID;
                List<ORM_CMN_BPT_EMP_EmploymentRelationship_2_WorkingContract> contracts = ORM_CMN_BPT_EMP_EmploymentRelationship_2_WorkingContract.Query.Search(Connection, Transaction, contractTermQuery);
                List<L5EM_GEFT_0959_WorkingContracts> resultContracts = new List<L5EM_GEFT_0959_WorkingContracts>();
                foreach (var contractToRelationship in contracts)
                {
                    L5EM_GEFT_0959_WorkingContracts resultContract = new L5EM_GEFT_0959_WorkingContracts();

                    ORM_CMN_BPT_EMP_WorkingContract workingContract = new ORM_CMN_BPT_EMP_WorkingContract();
                    workingContract.Load(Connection, Transaction, contractToRelationship.WorkingContract_RefID);
                    if (!workingContract.IsDeleted)
                    {
                        resultContract.CMN_BPT_EMP_WorkingContractID = workingContract.CMN_BPT_EMP_WorkingContractID;
                        resultContract.EmploymentRelationshipToWorkingContractAssignmentID = contractToRelationship.AssignmentID;
                        resultContract.IsWorkingContract_Active = contractToRelationship.IsContract_Active;
                        resultContract.Contract_StartDate = workingContract.Contract_StartDate;
                        resultContract.Contract_EndDate = workingContract.Contract_EndDate;
                        resultContract.IsContractEndDateDefined = workingContract.IsContractEndDateDefined;
                        resultContract.IsWorkTimeCalculated_InDays = workingContract.IsWorkTimeCalculated_InDays;
                        resultContract.IsWorkTimeCalculated_InHours = workingContract.IsWorkTimeCalculated_InHours;
                        resultContract.R_WorkTime_DaysPerWeek = workingContract.R_WorkTime_DaysPerWeek;
                        resultContract.R_WorkTime_HoursPerWeek = workingContract.R_WorkTime_HoursPerWeek;

                        //Office hours
                        ORM_CMN_BPT_EMP_WorkingContract_2_WorkingDay.Query workingContractTermToWorkingDayQuery = new ORM_CMN_BPT_EMP_WorkingContract_2_WorkingDay.Query();
                        workingContractTermToWorkingDayQuery.CMN_BPT_EMP_WorkingContract_RefID = workingContract.CMN_BPT_EMP_WorkingContractID;
                        workingContractTermToWorkingDayQuery.Tenant_RefID = securityTicket.TenantID;
                        workingContractTermToWorkingDayQuery.IsDeleted = false;
                        List<ORM_CMN_BPT_EMP_WorkingContract_2_WorkingDay> workingDayAssigments = ORM_CMN_BPT_EMP_WorkingContract_2_WorkingDay.Query.Search(Connection, Transaction, workingContractTermToWorkingDayQuery);
                        List<L5EM_GEFT_0959_WeeklyOfficeHours> resultWeeklyOfficeHours = new List<L5EM_GEFT_0959_WeeklyOfficeHours>();
                        foreach (var workingDayAssigment in workingDayAssigments)
                        {

                            ORM_CMN_CAL_WeeklyOfficeHours_Interval interval = new ORM_CMN_CAL_WeeklyOfficeHours_Interval();
                            interval.Load(Connection, Transaction, workingDayAssigment.CMN_CAL_WeeklyOfficeHours_Interval_RefID);

                            L5EM_GEFT_0959_WeeklyOfficeHours resultOfficeHour = new L5EM_GEFT_0959_WeeklyOfficeHours();
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
                        resultContract.WeeklyOfficeHours = resultWeeklyOfficeHours.ToArray();


                        //Allowed absence reasons
                        ORM_CMN_BPT_EMP_WorkingContract_AllowedAbsenceReason.Query AllowedAbsenceReasonQuery = new ORM_CMN_BPT_EMP_WorkingContract_AllowedAbsenceReason.Query();
                        AllowedAbsenceReasonQuery.WorkingContract_RefID = resultContract.CMN_BPT_EMP_WorkingContractID;
                        AllowedAbsenceReasonQuery.Tenant_RefID = securityTicket.TenantID;
                        AllowedAbsenceReasonQuery.IsDeleted = false;
                        List<ORM_CMN_BPT_EMP_WorkingContract_AllowedAbsenceReason> allowedAbsenceReasons = ORM_CMN_BPT_EMP_WorkingContract_AllowedAbsenceReason.Query.Search(Connection, Transaction, AllowedAbsenceReasonQuery);
                        List<L5EM_GEFT_0959_WorkingContractToLeaveRequest> resultAllowedAbsenceReasons = new List<L5EM_GEFT_0959_WorkingContractToLeaveRequest>();
                        foreach (var allowedAbsenceReason in allowedAbsenceReasons)
                        {
                            ORM_CMN_BPT_STA_AbsenceReason absenceReason = new ORM_CMN_BPT_STA_AbsenceReason();
                            absenceReason.Load(Connection, Transaction, allowedAbsenceReason.STA_AbsenceReason_RefID);

                            L5EM_GEFT_0959_WorkingContractToLeaveRequest resultReasonresultReason = new L5EM_GEFT_0959_WorkingContractToLeaveRequest();
                            resultReasonresultReason.CMN_BPT_EMP_Employee_WorkingContract_AllowedAbsenceReasonID = allowedAbsenceReason.CMN_BPT_EMP_WorkingContract_AllowedAbsenceReasonID;
                            resultReasonresultReason.STA_AbsenceReason_RefID = absenceReason.CMN_BPT_STA_AbsenceReasonID;
                            resultReasonresultReason.IsAbsenceCalculated_InDays = allowedAbsenceReason.IsAbsenceCalculated_InDays;
                            resultReasonresultReason.IsAbsenceCalculated_InHours = allowedAbsenceReason.IsAbsenceCalculated_InHours;
                            resultReasonresultReason.ContractAllowedAbsence_per_Month = allowedAbsenceReason.ContractAllowedAbsence_per_Month;
                            resultAllowedAbsenceReasons.Add(resultReasonresultReason);
                        }
                        resultContract.WorkingContractToLeaveRequest = resultAllowedAbsenceReasons.ToArray();

                        resultContracts.Add(resultContract);
                    }
                }
                result.WorkingContracts = resultContracts.ToArray();
                employeeResultList.Add(result);
		    }
            returnValue.Result=employeeResultList.ToArray();
			//Put your code here
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5EM_GEFT_0959_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5EM_GEFT_0959_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5EM_GEFT_0959_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5EM_GEFT_0959_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5EM_GEFT_0959_Array functionReturn = new FR_L5EM_GEFT_0959_Array();
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

				throw new Exception("Exception occured in method cls_Get_Employees_For_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5EM_GEFT_0959_raw 
	{
		public Guid CMN_PER_PersonInfoID; 
		public String FirstName; 
		public String LastName; 
		public String PrimaryEmail; 
		public String Title; 
		public DateTime BirthDate; 
		public Guid ProfileImage_Document_RefID; 
		public Guid CMN_AddressID; 
		public String Street_Name; 
		public String Street_Number; 
		public String City_AdministrativeDistrict; 
		public String City_Region; 
		public String City_Name; 
		public String City_PostalCode; 
		public String Province_Name; 
		public String Country_Name; 
		public String Country_ISOCode; 
		public Guid CMN_BPT_BusinessParticipantID; 
		public String DisplayName; 
		public Guid CMN_BPT_EMP_EmployeeID; 
		public String Staff_Number; 
		public String StandardFunction; 
		public Guid CMN_BPT_EMP_EmploymentRelationshipID; 
		public DateTime Work_StartDate; 
		public DateTime Work_EndDate; 
		public Guid WorkPlaceCalendarID; 
		public Guid WorkAreaCalendarID; 
		public Guid OfficeCalendarID; 
		public Guid USR_AccountID; 
		public Guid CMN_BPT_EMP_Employee_WorkplaceAssignmentID; 
		public Guid CMN_BPT_EMP_Employee_PlanGroup_RefID; 
		public Guid BoundTo_Workplace_RefID; 
		public Guid Default_BreakTime_Template_RefID; 
		public int SequenceNumber; 
		public DateTime WorkplaceAssignment_StartDate; 
		public bool IsBreakTimeCalculated_Planning; 
		public bool IsBreakTimeCalculated_Actual; 
		public Guid CMN_BPT_EMP_WorkingContractID; 
		public Guid EmploymentRelationshipToWorkingContractAssignmentID; 
		public bool IsWorkingContract_Active; 
		public bool IsWorkTimeCalculated_InHours; 
		public bool IsWorkTimeCalculated_InDays; 
		public DateTime Contract_StartDate; 
		public DateTime Contract_EndDate; 
		public double R_WorkTime_HoursPerWeek; 
		public double R_WorkTime_DaysPerWeek; 
		public bool IsContractEndDateDefined; 
		public Guid CMN_CAL_WeeklyOfficeHours_IntervalID; 
		public bool IsWholeDay; 
		public long TimeFrom_InMinutes; 
		public long TimeTo_InMinutes; 
		public bool IsMonday; 
		public bool IsTuesday; 
		public bool IsWednesday; 
		public bool IsThursday; 
		public bool IsFriday; 
		public bool IsSaturday; 
		public bool IsSunday; 
		public Guid CMN_BPT_EMP_Employee_WorkingContract_AllowedAbsenceReasonID; 
		public Guid STA_AbsenceReason_RefID; 
		public bool IsAbsenceCalculated_InHours; 
		public bool IsAbsenceCalculated_InDays; 
		public double ContractAllowedAbsence_per_Month; 
		public String Content; 
		public Guid CMN_PER_CommunicationContactID; 
		public Guid CMN_PER_CommunicationContact_TypeID; 
		public String Type; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5EM_GEFT_0959[] Convert(List<L5EM_GEFT_0959_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5EM_GEFT_0959 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.CMN_PER_PersonInfoID)).ToArray()
	group el_L5EM_GEFT_0959 by new 
	{ 
		el_L5EM_GEFT_0959.CMN_PER_PersonInfoID,

	}
	into gfunct_L5EM_GEFT_0959
	select new L5EM_GEFT_0959
	{     
		CMN_PER_PersonInfoID = gfunct_L5EM_GEFT_0959.Key.CMN_PER_PersonInfoID ,
		FirstName = gfunct_L5EM_GEFT_0959.FirstOrDefault().FirstName ,
		LastName = gfunct_L5EM_GEFT_0959.FirstOrDefault().LastName ,
		PrimaryEmail = gfunct_L5EM_GEFT_0959.FirstOrDefault().PrimaryEmail ,
		Title = gfunct_L5EM_GEFT_0959.FirstOrDefault().Title ,
		BirthDate = gfunct_L5EM_GEFT_0959.FirstOrDefault().BirthDate ,
		ProfileImage_Document_RefID = gfunct_L5EM_GEFT_0959.FirstOrDefault().ProfileImage_Document_RefID ,
		CMN_AddressID = gfunct_L5EM_GEFT_0959.FirstOrDefault().CMN_AddressID ,
		Street_Name = gfunct_L5EM_GEFT_0959.FirstOrDefault().Street_Name ,
		Street_Number = gfunct_L5EM_GEFT_0959.FirstOrDefault().Street_Number ,
		City_AdministrativeDistrict = gfunct_L5EM_GEFT_0959.FirstOrDefault().City_AdministrativeDistrict ,
		City_Region = gfunct_L5EM_GEFT_0959.FirstOrDefault().City_Region ,
		City_Name = gfunct_L5EM_GEFT_0959.FirstOrDefault().City_Name ,
		City_PostalCode = gfunct_L5EM_GEFT_0959.FirstOrDefault().City_PostalCode ,
		Province_Name = gfunct_L5EM_GEFT_0959.FirstOrDefault().Province_Name ,
		Country_Name = gfunct_L5EM_GEFT_0959.FirstOrDefault().Country_Name ,
		Country_ISOCode = gfunct_L5EM_GEFT_0959.FirstOrDefault().Country_ISOCode ,
		CMN_BPT_BusinessParticipantID = gfunct_L5EM_GEFT_0959.FirstOrDefault().CMN_BPT_BusinessParticipantID ,
		DisplayName = gfunct_L5EM_GEFT_0959.FirstOrDefault().DisplayName ,
		CMN_BPT_EMP_EmployeeID = gfunct_L5EM_GEFT_0959.FirstOrDefault().CMN_BPT_EMP_EmployeeID ,
		Staff_Number = gfunct_L5EM_GEFT_0959.FirstOrDefault().Staff_Number ,
		StandardFunction = gfunct_L5EM_GEFT_0959.FirstOrDefault().StandardFunction ,
		CMN_BPT_EMP_EmploymentRelationshipID = gfunct_L5EM_GEFT_0959.FirstOrDefault().CMN_BPT_EMP_EmploymentRelationshipID ,
		Work_StartDate = gfunct_L5EM_GEFT_0959.FirstOrDefault().Work_StartDate ,
		Work_EndDate = gfunct_L5EM_GEFT_0959.FirstOrDefault().Work_EndDate ,
		WorkPlaceCalendarID = gfunct_L5EM_GEFT_0959.FirstOrDefault().WorkPlaceCalendarID ,
		WorkAreaCalendarID = gfunct_L5EM_GEFT_0959.FirstOrDefault().WorkAreaCalendarID ,
		OfficeCalendarID = gfunct_L5EM_GEFT_0959.FirstOrDefault().OfficeCalendarID ,
		USR_AccountID = gfunct_L5EM_GEFT_0959.FirstOrDefault().USR_AccountID ,

		EmployeeWorkplaceHistory = 
		(
			from el_EmployeeWorkplaceHistory in gfunct_L5EM_GEFT_0959.Where(element => !EqualsDefaultValue(element.CMN_BPT_EMP_Employee_WorkplaceAssignmentID)).ToArray()
			group el_EmployeeWorkplaceHistory by new 
			{ 
				el_EmployeeWorkplaceHistory.CMN_BPT_EMP_Employee_WorkplaceAssignmentID,

			}
			into gfunct_EmployeeWorkplaceHistory
			select new L5EM_GEFT_0959_EmployeeWorkplaceHistory
			{     
				CMN_BPT_EMP_Employee_WorkplaceAssignmentID = gfunct_EmployeeWorkplaceHistory.Key.CMN_BPT_EMP_Employee_WorkplaceAssignmentID ,
				CMN_BPT_EMP_Employee_PlanGroup_RefID = gfunct_EmployeeWorkplaceHistory.FirstOrDefault().CMN_BPT_EMP_Employee_PlanGroup_RefID ,
				BoundTo_Workplace_RefID = gfunct_EmployeeWorkplaceHistory.FirstOrDefault().BoundTo_Workplace_RefID ,
				Default_BreakTime_Template_RefID = gfunct_EmployeeWorkplaceHistory.FirstOrDefault().Default_BreakTime_Template_RefID ,
				SequenceNumber = gfunct_EmployeeWorkplaceHistory.FirstOrDefault().SequenceNumber ,
				WorkplaceAssignment_StartDate = gfunct_EmployeeWorkplaceHistory.FirstOrDefault().WorkplaceAssignment_StartDate ,
				IsBreakTimeCalculated_Planning = gfunct_EmployeeWorkplaceHistory.FirstOrDefault().IsBreakTimeCalculated_Planning ,
				IsBreakTimeCalculated_Actual = gfunct_EmployeeWorkplaceHistory.FirstOrDefault().IsBreakTimeCalculated_Actual ,

			}
		).ToArray(),
		WorkingContracts = 
		(
			from el_WorkingContracts in gfunct_L5EM_GEFT_0959.Where(element => !EqualsDefaultValue(element.CMN_BPT_EMP_WorkingContractID) && !EqualsDefaultValue(element.EmploymentRelationshipToWorkingContractAssignmentID) && !EqualsDefaultValue(element.IsWorkingContract_Active) && !EqualsDefaultValue(element.IsWorkTimeCalculated_InHours) && !EqualsDefaultValue(element.IsWorkTimeCalculated_InDays) && !EqualsDefaultValue(element.Contract_StartDate) && !EqualsDefaultValue(element.Contract_EndDate) && !EqualsDefaultValue(element.R_WorkTime_HoursPerWeek) && !EqualsDefaultValue(element.R_WorkTime_DaysPerWeek) && !EqualsDefaultValue(element.IsContractEndDateDefined)).ToArray()
			group el_WorkingContracts by new 
			{ 
				el_WorkingContracts.CMN_BPT_EMP_WorkingContractID,
				el_WorkingContracts.EmploymentRelationshipToWorkingContractAssignmentID,
				el_WorkingContracts.IsWorkingContract_Active,
				el_WorkingContracts.IsWorkTimeCalculated_InHours,
				el_WorkingContracts.IsWorkTimeCalculated_InDays,
				el_WorkingContracts.Contract_StartDate,
				el_WorkingContracts.Contract_EndDate,
				el_WorkingContracts.R_WorkTime_HoursPerWeek,
				el_WorkingContracts.R_WorkTime_DaysPerWeek,
				el_WorkingContracts.IsContractEndDateDefined,

			}
			into gfunct_WorkingContracts
			select new L5EM_GEFT_0959_WorkingContracts
			{     
				CMN_BPT_EMP_WorkingContractID = gfunct_WorkingContracts.Key.CMN_BPT_EMP_WorkingContractID ,
				EmploymentRelationshipToWorkingContractAssignmentID = gfunct_WorkingContracts.Key.EmploymentRelationshipToWorkingContractAssignmentID ,
				IsWorkingContract_Active = gfunct_WorkingContracts.Key.IsWorkingContract_Active ,
				IsWorkTimeCalculated_InHours = gfunct_WorkingContracts.Key.IsWorkTimeCalculated_InHours ,
				IsWorkTimeCalculated_InDays = gfunct_WorkingContracts.Key.IsWorkTimeCalculated_InDays ,
				Contract_StartDate = gfunct_WorkingContracts.Key.Contract_StartDate ,
				Contract_EndDate = gfunct_WorkingContracts.Key.Contract_EndDate ,
				R_WorkTime_HoursPerWeek = gfunct_WorkingContracts.Key.R_WorkTime_HoursPerWeek ,
				R_WorkTime_DaysPerWeek = gfunct_WorkingContracts.Key.R_WorkTime_DaysPerWeek ,
				IsContractEndDateDefined = gfunct_WorkingContracts.Key.IsContractEndDateDefined ,

				WeeklyOfficeHours = 
				(
					from el_WeeklyOfficeHours in gfunct_WorkingContracts.ToArray()
					select new L5EM_GEFT_0959_WeeklyOfficeHours
					{     
						CMN_CAL_WeeklyOfficeHours_IntervalID = el_WeeklyOfficeHours.CMN_CAL_WeeklyOfficeHours_IntervalID,
						IsWholeDay = el_WeeklyOfficeHours.IsWholeDay,
						TimeFrom_InMinutes = el_WeeklyOfficeHours.TimeFrom_InMinutes,
						TimeTo_InMinutes = el_WeeklyOfficeHours.TimeTo_InMinutes,
						IsMonday = el_WeeklyOfficeHours.IsMonday,
						IsTuesday = el_WeeklyOfficeHours.IsTuesday,
						IsWednesday = el_WeeklyOfficeHours.IsWednesday,
						IsThursday = el_WeeklyOfficeHours.IsThursday,
						IsFriday = el_WeeklyOfficeHours.IsFriday,
						IsSaturday = el_WeeklyOfficeHours.IsSaturday,
						IsSunday = el_WeeklyOfficeHours.IsSunday,

					}
				).ToArray(),
				WorkingContractToLeaveRequest = 
				(
					from el_WorkingContractToLeaveRequest in gfunct_WorkingContracts.ToArray()
					select new L5EM_GEFT_0959_WorkingContractToLeaveRequest
					{     
						CMN_BPT_EMP_Employee_WorkingContract_AllowedAbsenceReasonID = el_WorkingContractToLeaveRequest.CMN_BPT_EMP_Employee_WorkingContract_AllowedAbsenceReasonID,
						STA_AbsenceReason_RefID = el_WorkingContractToLeaveRequest.STA_AbsenceReason_RefID,
						IsAbsenceCalculated_InHours = el_WorkingContractToLeaveRequest.IsAbsenceCalculated_InHours,
						IsAbsenceCalculated_InDays = el_WorkingContractToLeaveRequest.IsAbsenceCalculated_InDays,
						ContractAllowedAbsence_per_Month = el_WorkingContractToLeaveRequest.ContractAllowedAbsence_per_Month,

					}
				).ToArray(),

			}
		).ToArray(),
		Contacts = 
		(
			from el_Contacts in gfunct_L5EM_GEFT_0959.ToArray()
			select new L5EM_GEFT_0959_Contacts
			{     
				Content = el_Contacts.Content,
				CMN_PER_CommunicationContactID = el_Contacts.CMN_PER_CommunicationContactID,
				CMN_PER_CommunicationContact_TypeID = el_Contacts.CMN_PER_CommunicationContact_TypeID,
				Type = el_Contacts.Type,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5EM_GEFT_0959_Array : FR_Base
	{
		public L5EM_GEFT_0959[] Result	{ get; set; } 
		public FR_L5EM_GEFT_0959_Array() : base() {}

		public FR_L5EM_GEFT_0959_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5EM_GEFT_0959_Array cls_Get_Employees_For_Tenant(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5EM_GEFT_0959_Array invocationResult = cls_Get_Employees_For_Tenant.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/
