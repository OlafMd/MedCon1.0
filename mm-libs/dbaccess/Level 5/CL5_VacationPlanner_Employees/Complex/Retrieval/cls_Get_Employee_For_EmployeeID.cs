/* 
<<<<<<< HEAD
 * Generated on 2/11/2014 2:22:15 PM
=======
 * Generated on 2/18/2014 12:18:34 PM
>>>>>>> 45815bf9e37065aa6a7fc6af6def712be8ee7850
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
using CL1_USR;
using CL1_CMN_STR_PPS;
using CL1_HEC;
using CL1_CMN_BPT_EMP;
using CL1_CMN_PER;
using CL1_CMN_BPT;
using CL1_ACC_TAX;
using CL1_DOC;
using CL1_CMN_STR;
using CL1_CMN_CAL;
using CL1_CMN_BPT_STA;
using CL1_CMN;
using CL1_ACC_BNK;
using CL1_CMN_BPT_STA;
using PlannicoModel.Models;

namespace CL5_VacationPlanner_Employees.Complex.Retrieval
{
	/// <summary>
    /// No description found in <meta/> tag
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Employee_For_EmployeeID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Employee_For_EmployeeID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5EM_GEFE_1150 Execute(DbConnection Connection,DbTransaction Transaction,P_L5EM_GEFE_1150 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_L5EM_GEFE_1150();
            var result = new L5EM_GEFE_1150();

            ORM_CMN_BPT_EMP_Employee employee = new ORM_CMN_BPT_EMP_Employee();
            if (Parameter.EmployeeID != Guid.Empty)
            {
                employee.Load(Connection, Transaction, Parameter.EmployeeID);
                result.CMN_BPT_EMP_EmployeeID = employee.CMN_BPT_EMP_EmployeeID;
                result.Staff_Number = employee.Staff_Number;
                result.StandardFunction = employee.StandardFunction;
                result.EmployeeTax = new L5EM_GEFE_1150_EmployeeTax();
                result.EmployeeBankAccount = new L5EM_GEFE_1150_EmployeeBankAccount();

                ORM_USR_Account.Query accountQuery = new ORM_USR_Account.Query();
                accountQuery.BusinessParticipant_RefID = employee.BusinessParticipant_RefID;
                accountQuery.Tenant_RefID = securityTicket.TenantID;
                accountQuery.IsDeleted = false;
                ORM_USR_Account account = ORM_USR_Account.Query.Search(Connection, Transaction, accountQuery).FirstOrDefault();
                if (account != null)
                {
                    result.USR_AccountID = account.USR_AccountID;
                    result.Username = account.Username;
                    result.AccountType = account.AccountType;
                }

                ORM_CMN_BPT_BusinessParticipant businessParticipant = new ORM_CMN_BPT_BusinessParticipant();
                businessParticipant.Load(Connection, Transaction, employee.BusinessParticipant_RefID);

                result.CMN_BPT_BusinessParticipantID = businessParticipant.CMN_BPT_BusinessParticipantID;
                result.DisplayName = businessParticipant.DisplayName;

                ORM_CMN_BPT_BusinessParticipant_2_BankAccount.Query bankAccountQuery = new ORM_CMN_BPT_BusinessParticipant_2_BankAccount.Query();
                bankAccountQuery.CMN_BPT_BusinessParticipant_RefID = businessParticipant.CMN_BPT_BusinessParticipantID;
                bankAccountQuery.Tenant_RefID = securityTicket.TenantID;
                bankAccountQuery.IsDeleted = false;
                ORM_CMN_BPT_BusinessParticipant_2_BankAccount bank2Account = ORM_CMN_BPT_BusinessParticipant_2_BankAccount.Query.Search(Connection, Transaction, bankAccountQuery).FirstOrDefault();

                if (bank2Account != null)
                {
                    ORM_ACC_BNK_BankAccount bankAccount = new ORM_ACC_BNK_BankAccount();
                    var bankResult = bankAccount.Load(Connection, Transaction, bank2Account.ACC_BNK_BankAccount_RefID);
                    if (bankResult.Status == FR_Status.Success && bankAccount.ACC_BNK_BankAccountID != Guid.Empty)
                        result.EmployeeBankAccount = new L5EM_GEFE_1150_EmployeeBankAccount()
                        {
                            ACC_BNK_BankAccountID = bankAccount.ACC_BNK_BankAccountID,
                            IBAN = bankAccount.IBAN,
                            OwnerText = bankAccount.OwnerText
                        };
                }

                ORM_CMN_PER_PersonInfo personInfo = new ORM_CMN_PER_PersonInfo();
                personInfo.Load(Connection, Transaction, businessParticipant.IfNaturalPerson_CMN_PER_PersonInfo_RefID);
                result.CMN_PER_PersonInfoID = personInfo.CMN_PER_PersonInfoID;
                result.FirstName = personInfo.FirstName;
                result.LastName = personInfo.LastName;
                result.PrimaryEmail = personInfo.PrimaryEmail;
                result.Title = personInfo.Title;
                result.ProfileImage_Document_RefID = personInfo.ProfileImage_Document_RefID;
                result.BirthDate = personInfo.BirthDate;

                ORM_CMN_BPT_EMP_Employee_TaxInformation.Query taxInfoQuery = new ORM_CMN_BPT_EMP_Employee_TaxInformation.Query();
                taxInfoQuery.Employee_RefID = employee.CMN_BPT_EMP_EmployeeID;
                taxInfoQuery.Tenant_RefID = securityTicket.TenantID;
                taxInfoQuery.IsDeleted = false;
                ORM_CMN_BPT_EMP_Employee_TaxInformation taxInfo = ORM_CMN_BPT_EMP_Employee_TaxInformation.Query.Search(Connection, Transaction, taxInfoQuery).FirstOrDefault();

                ORM_CMN_PER_Person_2_Religion.Query religionQuery = new ORM_CMN_PER_Person_2_Religion.Query();
                religionQuery.CMN_PER_PersonInfo_RefID = personInfo.CMN_PER_PersonInfoID;
                religionQuery.Tenant_RefID = securityTicket.TenantID;
                religionQuery.IsDeleted = false;
                ORM_CMN_PER_Person_2_Religion religion = ORM_CMN_PER_Person_2_Religion.Query.Search(Connection, Transaction, religionQuery).FirstOrDefault();

                if (taxInfo != null)
                {
                    result.EmployeeTax = new L5EM_GEFE_1150_EmployeeTax()
                    {
                        CMN_BPT_EMP_Employee_TaxInformationID = taxInfo.CMN_BPT_EMP_Employee_TaxInformationID,
                        NumberOfChildren = personInfo.NumberOfChildren,
                        TaxClass = taxInfo.TaxClass,
                        TaxExemptionAmount = taxInfo.TaxExemptionAmount,
                        TaxNumber = taxInfo.TaxNumber,
                        Religion_RefID = religion != null ? religion.CMN_PER_Religion_RefID : Guid.Empty
                    };
                }

                ORM_CMN_BPT_EMP_EmploymentRelationship.Query employmentRelationshipQuery = new ORM_CMN_BPT_EMP_EmploymentRelationship.Query();
                employmentRelationshipQuery.Employee_RefID = employee.CMN_BPT_EMP_EmployeeID;
                employmentRelationshipQuery.IsDeleted = false;
                employmentRelationshipQuery.Tenant_RefID = securityTicket.TenantID;
                ORM_CMN_BPT_EMP_EmploymentRelationship employmentRelationship = ORM_CMN_BPT_EMP_EmploymentRelationship.Query.Search(Connection, Transaction, employmentRelationshipQuery).FirstOrDefault();

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
                List<L5EM_GEFE_1150_Contacts> resultComunicationContacts = new List<L5EM_GEFE_1150_Contacts>();
                foreach (var comunicationContact in comunicationContacts)
                {
                    ORM_CMN_PER_CommunicationContact_Type contactType = new ORM_CMN_PER_CommunicationContact_Type();

                    if (comunicationContact.Contact_Type != Guid.Empty)
                        contactType.Load(Connection, Transaction, comunicationContact.Contact_Type);

                    L5EM_GEFE_1150_Contacts resultComunicationContact = new L5EM_GEFE_1150_Contacts();
                    resultComunicationContact.CMN_PER_CommunicationContact_TypeID = contactType.CMN_PER_CommunicationContact_TypeID;
                    resultComunicationContact.CMN_PER_CommunicationContactID = comunicationContact.CMN_PER_CommunicationContactID;
                    resultComunicationContact.Content = comunicationContact.Content;
                    resultComunicationContact.Type = contactType.Type;

                    resultComunicationContacts.Add(resultComunicationContact);
                }
                result.Contacts = resultComunicationContacts.ToArray();



                //Function level rights
                if (account != null)
                {
                    ORM_USR_Account_2_FunctionLevelRight.Query functionLevelRightQuery = new ORM_USR_Account_2_FunctionLevelRight.Query();
                    functionLevelRightQuery.Account_RefID = account.USR_AccountID;
                    functionLevelRightQuery.Tenant_RefID = securityTicket.TenantID;
                    functionLevelRightQuery.IsDeleted = false;
                    List<ORM_USR_Account_2_FunctionLevelRight> functionLevelRights = ORM_USR_Account_2_FunctionLevelRight.Query.Search(Connection, Transaction, functionLevelRightQuery);
                    List<L5EM_GEFE_1150_Right> resultFunctionLevelRights = new List<L5EM_GEFE_1150_Right>();
                    foreach (var functionLevelRight in functionLevelRights)
                    {
                        ORM_USR_Account_FunctionLevelRight accountRight = new ORM_USR_Account_FunctionLevelRight();
                        accountRight.Load(Connection, Transaction, functionLevelRight.FunctionLevelRight_RefID);
                        L5EM_GEFE_1150_Right right = new L5EM_GEFE_1150_Right();
                        right.AssignmentID = functionLevelRight.AssignmentID;
                        right.RightName = accountRight.RightName;
                        right.USR_Account_FunctionLevelRightID = accountRight.USR_Account_FunctionLevelRightID;
                        resultFunctionLevelRights.Add(right);
                    }
                    result.Rights = resultFunctionLevelRights.ToArray();
                }


               




                ORM_CMN_BPT_EMP_EmploymentRelationship_2_WorkingContract.Query relationShipToContractQuery = new ORM_CMN_BPT_EMP_EmploymentRelationship_2_WorkingContract.Query();
                relationShipToContractQuery.EmploymentRelationship_RefID = employmentRelationship.CMN_BPT_EMP_EmploymentRelationshipID;
                relationShipToContractQuery.IsDeleted = false;
                relationShipToContractQuery.Tenant_RefID = securityTicket.TenantID;
                List<ORM_CMN_BPT_EMP_EmploymentRelationship_2_WorkingContract> relationShipToContracts = ORM_CMN_BPT_EMP_EmploymentRelationship_2_WorkingContract.Query.Search(Connection, Transaction, relationShipToContractQuery);
                List<L5EM_GEFE_1150_WorkingContract> resultWorkingContracts = new List<L5EM_GEFE_1150_WorkingContract>();
                foreach (var relationShipToContract in relationShipToContracts)
                {
                    L5EM_GEFE_1150_WorkingContract resultWorkingContract = new L5EM_GEFE_1150_WorkingContract();

                    ORM_CMN_BPT_EMP_WorkingContract workingContractItem = new ORM_CMN_BPT_EMP_WorkingContract();
                    workingContractItem.Load(Connection, Transaction, relationShipToContract.WorkingContract_RefID);
                    resultWorkingContract.CMN_BPT_EMP_WorkingContractID = workingContractItem.CMN_BPT_EMP_WorkingContractID;
                    resultWorkingContract.EmploymentRelationship_2_WorkingContractAssigmentID = relationShipToContract.AssignmentID;
                    resultWorkingContract.IsContract_Active = relationShipToContract.IsContract_Active;
                    resultWorkingContract.Contract_StartDate = workingContractItem.Contract_StartDate;
                    resultWorkingContract.Contract_EndDate = workingContractItem.Contract_EndDate;
                    resultWorkingContract.IsContractEndDateDefined = workingContractItem.IsContractEndDateDefined;
                    resultWorkingContract.IsWorkTimeCalculated_InDays = workingContractItem.IsWorkTimeCalculated_InDays;
                    resultWorkingContract.IsWorkTimeCalculated_InHours = workingContractItem.IsWorkTimeCalculated_InHours;
                    resultWorkingContract.R_WorkTime_DaysPerWeek = workingContractItem.R_WorkTime_DaysPerWeek;
                    resultWorkingContract.R_WorkTime_HoursPerWeek = workingContractItem.R_WorkTime_HoursPerWeek;
                    resultWorkingContract.WorkingContract_InCurrency_RefID = workingContractItem.WorkingContract_InCurrency_RefID;
                    resultWorkingContract.ExtraWorkCalculation_RefID = workingContractItem.ExtraWorkCalculation_RefID;
                    resultWorkingContract.IsWorktimeChecked_Weekly = workingContractItem.IsWorktimeChecked_Weekly;
                    resultWorkingContract.IsWorktimeChecked_Monthly = workingContractItem.IsWorktimeChecked_Monthly;
                    resultWorkingContract.SurchargeCalculation_UseMaximum = workingContractItem.SurchargeCalculation_UseMaximum;
                    resultWorkingContract.SurchargeCalculation_UseAccumulated = workingContractItem.SurchargeCalculation_UseAccumulated;
                    resultWorkingContract.IsMealAllowanceProvided = workingContractItem.IsMealAllowanceProvided;
                    resultWorkingContract.WorkingContract_Comment = workingContractItem.WorkingContract_Comment;

                    ORM_CMN_BPT_EMP_WorkingContract_2_ExtraWorkSurcharge.Query contractToExtraWorkSurchargeQuery = new ORM_CMN_BPT_EMP_WorkingContract_2_ExtraWorkSurcharge.Query();
                    contractToExtraWorkSurchargeQuery.CMN_BPT_EMP_WorkingContract_RefID = workingContractItem.CMN_BPT_EMP_WorkingContractID;
                    contractToExtraWorkSurchargeQuery.IsDeleted = false;
                    contractToExtraWorkSurchargeQuery.Tenant_RefID = securityTicket.TenantID;
                    var contractToExtraWorkSurchargeResult = ORM_CMN_BPT_EMP_WorkingContract_2_ExtraWorkSurcharge.Query.Search(Connection, Transaction, contractToExtraWorkSurchargeQuery);
                    if (contractToExtraWorkSurchargeResult.Count != 0)
                    {
                        var nightTimeSurcharge = contractToExtraWorkSurchargeResult.FirstOrDefault(x => x.R_IsNightTimeSurcharge && !x.R_IsSpecialEventSurcharge);
                        var specialEventSurcharge = contractToExtraWorkSurchargeResult.FirstOrDefault(x => x.R_IsSpecialEventSurcharge && !x.R_IsNightTimeSurcharge);

                        if (nightTimeSurcharge != null)
                        {
                            resultWorkingContract.NightTime_Surcharge_RefID = nightTimeSurcharge.CMN_BPT_EMP_ExtraWorkCalculation_Surcharge_RefID;
                            resultWorkingContract.MaximumAllowedNightTimeSurchargeTime_in_mins = nightTimeSurcharge.MaximumAllowedSurchargeTime_in_mins;
                        }

                        if (specialEventSurcharge != null)
                        {
                            resultWorkingContract.SpecialEvent_Surcharge_RefID = specialEventSurcharge.CMN_BPT_EMP_ExtraWorkCalculation_Surcharge_RefID;
                            resultWorkingContract.MaximumAllowedSpecialEventSurchargeTime_in_mins = specialEventSurcharge.MaximumAllowedSurchargeTime_in_mins;
                        }

                    }


                    //Office hours
                    ORM_CMN_BPT_EMP_WorkingContract_2_WorkingDay.Query workingContractToWorkingDayQuery = new ORM_CMN_BPT_EMP_WorkingContract_2_WorkingDay.Query();
                    workingContractToWorkingDayQuery.CMN_BPT_EMP_WorkingContract_RefID = workingContractItem.CMN_BPT_EMP_WorkingContractID;
                    //workingContractToWorkingDayQuery.Tenant_RefID = securityTicket.TenantID;
                    workingContractToWorkingDayQuery.IsDeleted = false;
                    List<ORM_CMN_BPT_EMP_WorkingContract_2_WorkingDay> workingDayAssigments = ORM_CMN_BPT_EMP_WorkingContract_2_WorkingDay.Query.Search(Connection, Transaction, workingContractToWorkingDayQuery);
                    List<L5EM_GEFE_1150_WeeklyOfficeHours> resultWeeklyOfficeHours = new List<L5EM_GEFE_1150_WeeklyOfficeHours>();
                    foreach (var workingDayAssigment in workingDayAssigments)
                    {

                        ORM_CMN_CAL_WeeklyOfficeHours_Interval interval = new ORM_CMN_CAL_WeeklyOfficeHours_Interval();
                        interval.Load(Connection, Transaction, workingDayAssigment.CMN_CAL_WeeklyOfficeHours_Interval_RefID);

                        L5EM_GEFE_1150_WeeklyOfficeHours resultOfficeHour = new L5EM_GEFE_1150_WeeklyOfficeHours();
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
                    AllowedAbsenceReasonQuery.WorkingContract_RefID = resultWorkingContract.CMN_BPT_EMP_WorkingContractID;
                    AllowedAbsenceReasonQuery.Tenant_RefID = securityTicket.TenantID;
                    AllowedAbsenceReasonQuery.IsDeleted = false;
                    List<ORM_CMN_BPT_EMP_WorkingContract_AllowedAbsenceReason> allowedAbsenceReasons = ORM_CMN_BPT_EMP_WorkingContract_AllowedAbsenceReason.Query.Search(Connection, Transaction, AllowedAbsenceReasonQuery);
                    List<L5EM_GEFE_1150_WorkingContractToLeaveRequest> resultAllowedAbsenceReasons = new List<L5EM_GEFE_1150_WorkingContractToLeaveRequest>();
                    foreach (var allowedAbsenceReason in allowedAbsenceReasons)
                    {
                        ORM_CMN_BPT_STA_AbsenceReason absenceReason = new ORM_CMN_BPT_STA_AbsenceReason();
                        absenceReason.Load(Connection, Transaction, allowedAbsenceReason.STA_AbsenceReason_RefID);

                        L5EM_GEFE_1150_WorkingContractToLeaveRequest resultReasonresultReason = new L5EM_GEFE_1150_WorkingContractToLeaveRequest();
                        resultReasonresultReason.CMN_BPT_EMP_WorkingContract_AllowedAbsenceReasonID = allowedAbsenceReason.CMN_BPT_EMP_WorkingContract_AllowedAbsenceReasonID;
                        resultReasonresultReason.CMN_BPT_STA_AbsenceReasonID = absenceReason.CMN_BPT_STA_AbsenceReasonID;
                        resultReasonresultReason.IsAbsenceCalculated_InDays = allowedAbsenceReason.IsAbsenceCalculated_InDays;
                        resultReasonresultReason.IsAbsenceCalculated_InHours = allowedAbsenceReason.IsAbsenceCalculated_InHours;
                        resultReasonresultReason.ContractAllowedAbsence_per_Month = allowedAbsenceReason.ContractAllowedAbsence_per_Month;
                        resultReasonresultReason.AbsenceReasonName = absenceReason.Name;
                        resultReasonresultReason.CMN_BPT_EMP_EmploymentRelationship_RefID = employmentRelationship.CMN_BPT_EMP_EmploymentRelationshipID;
                        resultAllowedAbsenceReasons.Add(resultReasonresultReason);
                    }
                    resultWorkingContract.WorkingContractToLeaveRequest = resultAllowedAbsenceReasons.ToArray();

                    ORM_CMN_BPT_EMP_WorkingContract_2_ContractEmploymentType.Query workingContractTypeQuery = new ORM_CMN_BPT_EMP_WorkingContract_2_ContractEmploymentType.Query();
                    workingContractTypeQuery.CMN_BPT_EMP_Employee_WorkingContract_RefID = workingContractItem.CMN_BPT_EMP_WorkingContractID;
                    workingContractTypeQuery.Tenant_RefID = securityTicket.TenantID;
                    workingContractTypeQuery.IsDeleted = false;
                    ORM_CMN_BPT_EMP_WorkingContract_2_ContractEmploymentType workingContract_2_ContractEmploymentType = ORM_CMN_BPT_EMP_WorkingContract_2_ContractEmploymentType.Query.Search(Connection, Transaction, workingContractTypeQuery).FirstOrDefault();
                    if(workingContract_2_ContractEmploymentType!=null){
                        ORM_CMN_BPT_EMP_WorkingContract_EmploymentType EmploymentType = new ORM_CMN_BPT_EMP_WorkingContract_EmploymentType();
                        EmploymentType.Load(Connection, Transaction, workingContract_2_ContractEmploymentType.CMN_BPT_EMP_WorkingContract_EmploymentTypeID);
                        if(EmploymentType.CMN_BPT_EMP_Employee_WorkingContract_EmploymentTypeID!=Guid.Empty){
                            resultWorkingContract.TypeOfEmployment =int.Parse(EmploymentType.GlobalPropertyMatchingID);
                        }
                    }

                    resultWorkingContracts.Add(resultWorkingContract);
                }
                result.WorkingContracts = resultWorkingContracts.ToArray();


                L5EM_GEFE_1150_EmployeeSocialSecurity socialSecurity = new L5EM_GEFE_1150_EmployeeSocialSecurity();
                ORM_HEC_Patient patient = ORM_HEC_Patient.Query.Search(Connection, Transaction, new ORM_HEC_Patient.Query()
                {
                    CMN_BPT_BusinessParticipant_RefID = businessParticipant.CMN_BPT_BusinessParticipantID,
                    IsDeleted = false,
                    Tenant_RefID=securityTicket.TenantID
                }).FirstOrDefault();

                if (patient != null)
                {
                    ORM_HEC_Patient_HealthInsurance patientHealthInsurance = ORM_HEC_Patient_HealthInsurance.Query.Search(Connection, Transaction, new ORM_HEC_Patient_HealthInsurance.Query()
                    {
                        Patient_RefID = patient.HEC_PatientID,
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID
                    }).FirstOrDefault();

                    socialSecurity.HealthInsurance_Number = patientHealthInsurance != null ? patientHealthInsurance.HealthInsurance_Number : String.Empty;
                    socialSecurity.HEC_HealthInsurance_CompanyID = patientHealthInsurance != null ?patientHealthInsurance.HIS_HealthInsurance_Company_RefID:Guid.Empty;
                }

                ORM_CMN_BPT_EMP_Employee_2_Profession.Query employeeProfessionQuery = new ORM_CMN_BPT_EMP_Employee_2_Profession.Query();
                employeeProfessionQuery.Employee_RefID = employee.CMN_BPT_EMP_EmployeeID;
                employeeProfessionQuery.Tenant_RefID = securityTicket.TenantID;
                employeeProfessionQuery.IsDeleted = false;
                List<ORM_CMN_BPT_EMP_Employee_2_Profession> employeeProfessionList = ORM_CMN_BPT_EMP_Employee_2_Profession.Query.Search(Connection, Transaction, employeeProfessionQuery);
                if (employeeProfessionList.Count != 0)
                {
                    socialSecurity.CMN_STR_ProfessionID = employeeProfessionList[0].Profession_RefID;
                }

                ORM_CMN_PER_Person_2_CompulsorySocialSecurityStatus.Query employeeSocialSecurityStatus = new ORM_CMN_PER_Person_2_CompulsorySocialSecurityStatus.Query();
                employeeSocialSecurityStatus.CMN_PER_PersonInfo_RefID = personInfo.CMN_PER_PersonInfoID;
                employeeSocialSecurityStatus.Tenant_RefID = securityTicket.TenantID;
                employeeSocialSecurityStatus.IsDeleted = false;
                List<ORM_CMN_PER_Person_2_CompulsorySocialSecurityStatus> employeeSocialSecurityStatusList = ORM_CMN_PER_Person_2_CompulsorySocialSecurityStatus.Query.Search(Connection, Transaction, employeeSocialSecurityStatus);
                if (employeeSocialSecurityStatusList.Count != 0)
                {
                    socialSecurity.CMN_PER_CompulsorySocialSecurityStatusID = employeeSocialSecurityStatusList[0].CMN_PER_CompulsorySocialSecurityStatus_RefID;
                }

                ORM_CMN_BPT_BusinessParticipant_AssociatedBusinessParticipant associatedPart = ORM_CMN_BPT_BusinessParticipant_AssociatedBusinessParticipant.Query.Search(Connection, Transaction, new ORM_CMN_BPT_BusinessParticipant_AssociatedBusinessParticipant.Query
                {
                    Tenant_RefID = securityTicket.TenantID,
                    BusinessParticipant_RefID = businessParticipant.CMN_BPT_BusinessParticipantID,
                    IsDeleted = false
                }).FirstOrDefault();
                if (associatedPart != null && associatedPart.CMN_BPT_BusinessParticipant_AssociatedBusinessParticipantID != Guid.Empty)
                {
                    ORM_ACC_TAX_TaxOffice taxOffice = ORM_ACC_TAX_TaxOffice.Query.Search(Connection,Transaction,new ORM_ACC_TAX_TaxOffice.Query{
                        CMN_BPT_BusinessParticipant_RefID=associatedPart.AssociatedBusinessParticipant_RefID,
                        IsDeleted=false,
                        Tenant_RefID=securityTicket.TenantID
                    }).FirstOrDefault();
                    if (taxOffice != null && taxOffice.ACC_TAX_TaxOfficeID != Guid.Empty)
                    {
                        result.EmployeeTax.ACC_TAX_TaxOfficeID = taxOffice.ACC_TAX_TaxOfficeID;
                    }

                }
                


                result.EmployeeSocialSecurity = socialSecurity;

                //Employee function history
                ORM_CMN_BPT_EMP_Employee_FunctionHistory.Query functionHistoryQuery = new ORM_CMN_BPT_EMP_Employee_FunctionHistory.Query();
                functionHistoryQuery.CMN_BPT_EMP_Employee_RefID = employee.CMN_BPT_EMP_EmployeeID;
                functionHistoryQuery.Tenant_RefID = securityTicket.TenantID;
                functionHistoryQuery.IsDeleted = false;
                List<ORM_CMN_BPT_EMP_Employee_FunctionHistory> functionHistoryQueryList = ORM_CMN_BPT_EMP_Employee_FunctionHistory.Query.Search(Connection, Transaction, functionHistoryQuery);

                List<L5EM_GEFE_1150_FunctionHistory> functionHistory = new List<L5EM_GEFE_1150_FunctionHistory>();
                L5EM_GEFE_1150_FunctionHistory functionHistoryItem;
                foreach (var item in functionHistoryQueryList)
                {
                    functionHistoryItem = new L5EM_GEFE_1150_FunctionHistory();
                    functionHistoryItem.CMN_BPT_EMP_Employee_FunctionHistoryID = item.CMN_BPT_EMP_Employee_FunctionHistoryID;
                    functionHistoryItem.Date = item.ValidFrom;
                    functionHistoryItem.FunctionName = item.FunctionName;
                    functionHistoryItem.IsPrimary = !String.IsNullOrWhiteSpace(employee.StandardFunction) && employee.StandardFunction == item.FunctionName;

                    functionHistory.Add(functionHistoryItem);
                }

                result.FunctionHistory = functionHistory.ToArray();

                //Employee workplace history
                ORM_CMN_BPT_EMP_Employee_WorkplaceAssignment.Query employeeWorkplaceAssignmentsQuery = new ORM_CMN_BPT_EMP_Employee_WorkplaceAssignment.Query();
                employeeWorkplaceAssignmentsQuery.CMN_BPT_EMP_Employee_RefID = employee.CMN_BPT_EMP_EmployeeID;
                employeeWorkplaceAssignmentsQuery.Tenant_RefID = securityTicket.TenantID;
                employeeWorkplaceAssignmentsQuery.IsDeleted = false;
                List<ORM_CMN_BPT_EMP_Employee_WorkplaceAssignment> employeeWorkplaceAssignemntsList = ORM_CMN_BPT_EMP_Employee_WorkplaceAssignment.Query.Search(Connection, Transaction, employeeWorkplaceAssignmentsQuery);
                List<L5EM_GEFE_1150_EmployeeWorkplaceHistory> employeeWorkplaceAssignments = new List<L5EM_GEFE_1150_EmployeeWorkplaceHistory>();

                foreach (var workplaceAssignemns in employeeWorkplaceAssignemntsList)
                {
                    L5EM_GEFE_1150_EmployeeWorkplaceHistory item = new L5EM_GEFE_1150_EmployeeWorkplaceHistory();
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

                //employee documents
                ORM_CMN_BPT_EMP_Employee_PayroleDocument.Query payroleDocumentQuery = new ORM_CMN_BPT_EMP_Employee_PayroleDocument.Query();
                payroleDocumentQuery.Employee_RefID = employee.CMN_BPT_EMP_EmployeeID;
                payroleDocumentQuery.Tenant_RefID = securityTicket.TenantID;
                payroleDocumentQuery.IsDeleted = false;
                List<ORM_CMN_BPT_EMP_Employee_PayroleDocument> payroleDocumentList = ORM_CMN_BPT_EMP_Employee_PayroleDocument.Query.Search(Connection, Transaction, payroleDocumentQuery);
                List<L5EM_GEFE_1150_EmployeeDocuments> payroleDocuments = new List<L5EM_GEFE_1150_EmployeeDocuments>();

                ORM_DOC_DocumentRevision documentRevision;
                foreach (var payroleDocument in payroleDocumentList)
                {
                    documentRevision = new ORM_DOC_DocumentRevision();
                    var documentRevisionResult = documentRevision.Load(Connection, Transaction, payroleDocument.Document_RefID);

                    if (documentRevisionResult.Status != FR_Status.Success || documentRevision.DOC_DocumentRevisionID == Guid.Empty)
                        continue;

                    payroleDocuments.Add(new L5EM_GEFE_1150_EmployeeDocuments()
                    {
                        CMN_BPT_EMP_Employee_PayroleDocumentsID = payroleDocument.CMN_BPT_EMP_Employee_PayroleDocumentsID,
                        Description = documentRevision.File_Description,
                        Document_RefID = documentRevision.DOC_DocumentRevisionID,
                        DocumentDate = payroleDocument.DocumentDate,
                        IsViewedByEmployee = payroleDocument.IsViewedByEmployee,
                        Name = documentRevision.File_Name,
                        ViewedOnDate = payroleDocument.ViewedOnDate,
                        File_Extension = documentRevision.File_Extension,
                        File_MIMEType = documentRevision.File_MIMEType
                    });

                }

                result.EmployeeDocuments = payroleDocuments.ToArray();

                //employee qualifications
                ORM_CMN_BPT_EMP_Employee_2_Skill.Query qualificationQuary = new ORM_CMN_BPT_EMP_Employee_2_Skill.Query();
                qualificationQuary.Employee_RefID = employee.CMN_BPT_EMP_EmployeeID;
                qualificationQuary.Tenant_RefID = securityTicket.TenantID;
                qualificationQuary.IsDeleted = false;
                List<ORM_CMN_BPT_EMP_Employee_2_Skill> qualificationList = ORM_CMN_BPT_EMP_Employee_2_Skill.Query.Search(Connection, Transaction, qualificationQuary);
                List<L5EM_GEFE_1150_EmployeeQualification> employeeQualifications = new List<L5EM_GEFE_1150_EmployeeQualification>();

                L5EM_GEFE_1150_EmployeeQualification employeeQualification;
                ORM_CMN_STR_Skill skillORM;
                foreach (var qualification in qualificationList)
                {
                    employeeQualification = new L5EM_GEFE_1150_EmployeeQualification();
                    employeeQualification.QualificationAssignmentID = qualification.AssignmentID;
                    employeeQualification.ProfessionObtainedAtDate = qualification.QualificationObtainedAtDate;
                    employeeQualification.SkillName = new Dict();
                    if (qualification.Skill_RefID != Guid.Empty)
                    {
                        skillORM = new ORM_CMN_STR_Skill();
                        skillORM.Load(Connection, Transaction, qualification.Skill_RefID);
                        employeeQualification.Skill_RefID = skillORM.CMN_STR_SkillID;
                        employeeQualification.SkillName = skillORM.Skill_Name;
                    }

                    employeeQualifications.Add(employeeQualification);

                }

                result.EmployeeQualifications = employeeQualifications.ToArray();

            }
            returnValue.Result = result;
            //Put your code here
            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5EM_GEFE_1150 Invoke(string ConnectionString,P_L5EM_GEFE_1150 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5EM_GEFE_1150 Invoke(DbConnection Connection,P_L5EM_GEFE_1150 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5EM_GEFE_1150 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5EM_GEFE_1150 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5EM_GEFE_1150 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5EM_GEFE_1150 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5EM_GEFE_1150 functionReturn = new FR_L5EM_GEFE_1150();
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

	#region Raw Grouping Class
	[Serializable]
	public class L5EM_GEFE_1150_raw 
	{
		public Guid CMN_PER_PersonInfoID; 
		public Guid USR_AccountID; 
		public String Username; 
		public String FirstName; 
		public Guid CMN_BPT_EMP_EmploymentRelationshipID; 
		public int AccountType; 
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
		public DateTime Work_StartDate; 
		public DateTime Work_EndDate; 
		public Dict WorkAreaName; 
		public Dict WorkPlaceName; 
		public Dict OfficeName; 
		public Guid CMN_BPT_EMP_WorkingContractID; 
		public Guid EmploymentRelationship_2_WorkingContractAssigmentID; 
		public bool IsContract_Active; 
		public bool IsContractEndDateDefined; 
		public bool IsWorkTimeCalculated_InHours; 
		public bool IsWorkTimeCalculated_InDays; 
		public DateTime Contract_StartDate; 
		public DateTime Contract_EndDate; 
		public double R_WorkTime_HoursPerWeek; 
		public double R_WorkTime_DaysPerWeek; 
		public Guid ExtraWorkCalculation_RefID; 
		public Guid WorkingContract_InCurrency_RefID; 
		public bool IsWorktimeChecked_Weekly; 
		public bool IsWorktimeChecked_Monthly; 
		public bool SurchargeCalculation_UseMaximum; 
		public bool SurchargeCalculation_UseAccumulated; 
		public bool IsMealAllowanceProvided; 
		public String WorkingContract_Comment; 
		public Guid NightTime_Surcharge_RefID; 
		public Guid SpecialEvent_Surcharge_RefID; 
		public int MaximumAllowedNightTimeSurchargeTime_in_mins; 
		public int MaximumAllowedSpecialEventSurchargeTime_in_mins; 
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
		public Guid CMN_BPT_EMP_WorkingContract_AllowedAbsenceReasonID; 
		public Guid CMN_BPT_STA_AbsenceReasonID; 
		public bool IsAbsenceCalculated_InHours; 
		public bool IsAbsenceCalculated_InDays; 
		public double ContractAllowedAbsence_per_Month; 
		public Dict AbsenceReasonName; 
		public Guid CMN_BPT_EMP_EmploymentRelationship_RefID; 
		public Guid AssignmentID; 
		public Guid USR_Account_FunctionLevelRightID; 
		public String RightName; 
		public String Content; 
		public Guid CMN_PER_CommunicationContactID; 
		public Guid CMN_PER_CommunicationContact_TypeID; 
		public String Type; 
		public DateTime Date; 
		public Guid CMN_BPT_EMP_Employee_FunctionHistoryID; 
		public String FunctionName; 
		public bool IsPrimary; 
		public Guid CMN_BPT_EMP_Employee_WorkplaceAssignmentID; 
		public Guid CMN_BPT_EMP_Employee_PlanGroup_RefID; 
		public Guid BoundTo_Workplace_RefID; 
		public Guid Default_BreakTime_Template_RefID; 
		public int SequenceNumber; 
		public DateTime WorkplaceAssignment_StartDate; 
		public bool IsBreakTimeCalculated_Planning; 
		public bool IsBreakTimeCalculated_Actual; 
		public Guid CMN_BPT_EMP_Employee_PayroleDocumentsID; 
		public Guid Document_RefID; 
		public bool IsViewedByEmployee; 
		public DateTime DocumentDate; 
		public DateTime ViewedOnDate; 
		public string Description; 
		public string Name; 
		public string File_Extension; 
		public string File_MIMEType; 
		public Guid QualificationAssignmentID; 
		public DateTime ProfessionObtainedAtDate; 
		public Guid Skill_RefID; 
		public Dict SkillName; 
		public Guid ACC_BNK_BankAccountID; 
		public String IBAN; 
		public String OwnerText; 
		public Guid CMN_BPT_EMP_Employee_TaxInformationID; 
		public String TaxNumber; 
		public String TaxClass; 
		public Decimal TaxExemptionAmount; 
		public int NumberOfChildren; 
		public Guid Religion_RefID; 
		public Guid VATIdentificationNumber; 
		public Guid ACC_TAX_TaxOfficeID; 
		public String HealthInsurance_Number; 
		public Guid CMN_STR_ProfessionID; 
		public Guid HEC_HealthInsurance_CompanyID; 
		public Guid CMN_PER_CompulsorySocialSecurityStatusID; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5EM_GEFE_1150[] Convert(List<L5EM_GEFE_1150_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5EM_GEFE_1150 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.CMN_BPT_EMP_EmployeeID)).ToArray()
	group el_L5EM_GEFE_1150 by new 
	{ 
		el_L5EM_GEFE_1150.CMN_BPT_EMP_EmployeeID,

	}
	into gfunct_L5EM_GEFE_1150
	select new L5EM_GEFE_1150
	{     
		CMN_PER_PersonInfoID = gfunct_L5EM_GEFE_1150.FirstOrDefault().CMN_PER_PersonInfoID ,
		USR_AccountID = gfunct_L5EM_GEFE_1150.FirstOrDefault().USR_AccountID ,
		Username = gfunct_L5EM_GEFE_1150.FirstOrDefault().Username ,
		FirstName = gfunct_L5EM_GEFE_1150.FirstOrDefault().FirstName ,
		CMN_BPT_EMP_EmploymentRelationshipID = gfunct_L5EM_GEFE_1150.FirstOrDefault().CMN_BPT_EMP_EmploymentRelationshipID ,
		AccountType = gfunct_L5EM_GEFE_1150.FirstOrDefault().AccountType ,
		LastName = gfunct_L5EM_GEFE_1150.FirstOrDefault().LastName ,
		PrimaryEmail = gfunct_L5EM_GEFE_1150.FirstOrDefault().PrimaryEmail ,
		Title = gfunct_L5EM_GEFE_1150.FirstOrDefault().Title ,
		BirthDate = gfunct_L5EM_GEFE_1150.FirstOrDefault().BirthDate ,
		ProfileImage_Document_RefID = gfunct_L5EM_GEFE_1150.FirstOrDefault().ProfileImage_Document_RefID ,
		CMN_AddressID = gfunct_L5EM_GEFE_1150.FirstOrDefault().CMN_AddressID ,
		Street_Name = gfunct_L5EM_GEFE_1150.FirstOrDefault().Street_Name ,
		Street_Number = gfunct_L5EM_GEFE_1150.FirstOrDefault().Street_Number ,
		City_AdministrativeDistrict = gfunct_L5EM_GEFE_1150.FirstOrDefault().City_AdministrativeDistrict ,
		City_Region = gfunct_L5EM_GEFE_1150.FirstOrDefault().City_Region ,
		City_Name = gfunct_L5EM_GEFE_1150.FirstOrDefault().City_Name ,
		City_PostalCode = gfunct_L5EM_GEFE_1150.FirstOrDefault().City_PostalCode ,
		Province_Name = gfunct_L5EM_GEFE_1150.FirstOrDefault().Province_Name ,
		Country_Name = gfunct_L5EM_GEFE_1150.FirstOrDefault().Country_Name ,
		Country_ISOCode = gfunct_L5EM_GEFE_1150.FirstOrDefault().Country_ISOCode ,
		CMN_BPT_BusinessParticipantID = gfunct_L5EM_GEFE_1150.FirstOrDefault().CMN_BPT_BusinessParticipantID ,
		DisplayName = gfunct_L5EM_GEFE_1150.FirstOrDefault().DisplayName ,
		CMN_BPT_EMP_EmployeeID = gfunct_L5EM_GEFE_1150.Key.CMN_BPT_EMP_EmployeeID ,
		Staff_Number = gfunct_L5EM_GEFE_1150.FirstOrDefault().Staff_Number ,
		StandardFunction = gfunct_L5EM_GEFE_1150.FirstOrDefault().StandardFunction ,
		Work_StartDate = gfunct_L5EM_GEFE_1150.FirstOrDefault().Work_StartDate ,
		Work_EndDate = gfunct_L5EM_GEFE_1150.FirstOrDefault().Work_EndDate ,
		WorkAreaName = gfunct_L5EM_GEFE_1150.FirstOrDefault().WorkAreaName ,
		WorkPlaceName = gfunct_L5EM_GEFE_1150.FirstOrDefault().WorkPlaceName ,
		OfficeName = gfunct_L5EM_GEFE_1150.FirstOrDefault().OfficeName ,

		WorkingContracts = 
		(
			from el_WorkingContracts in gfunct_L5EM_GEFE_1150.Where(element => !EqualsDefaultValue(element.CMN_BPT_EMP_WorkingContractID) && !EqualsDefaultValue(element.EmploymentRelationship_2_WorkingContractAssigmentID) && !EqualsDefaultValue(element.IsContract_Active) && !EqualsDefaultValue(element.IsContractEndDateDefined) && !EqualsDefaultValue(element.IsWorkTimeCalculated_InHours) && !EqualsDefaultValue(element.IsWorkTimeCalculated_InDays) && !EqualsDefaultValue(element.Contract_StartDate) && !EqualsDefaultValue(element.Contract_EndDate) && !EqualsDefaultValue(element.R_WorkTime_HoursPerWeek) && !EqualsDefaultValue(element.R_WorkTime_DaysPerWeek) && !EqualsDefaultValue(element.ExtraWorkCalculation_RefID) && !EqualsDefaultValue(element.WorkingContract_InCurrency_RefID) && !EqualsDefaultValue(element.IsWorktimeChecked_Weekly) && !EqualsDefaultValue(element.IsWorktimeChecked_Monthly) && !EqualsDefaultValue(element.SurchargeCalculation_UseMaximum) && !EqualsDefaultValue(element.SurchargeCalculation_UseAccumulated) && !EqualsDefaultValue(element.IsMealAllowanceProvided) && !EqualsDefaultValue(element.WorkingContract_Comment) && !EqualsDefaultValue(element.NightTime_Surcharge_RefID) && !EqualsDefaultValue(element.SpecialEvent_Surcharge_RefID) && !EqualsDefaultValue(element.MaximumAllowedNightTimeSurchargeTime_in_mins) && !EqualsDefaultValue(element.MaximumAllowedSpecialEventSurchargeTime_in_mins)).ToArray()
			group el_WorkingContracts by new 
			{ 
				el_WorkingContracts.CMN_BPT_EMP_WorkingContractID,
				el_WorkingContracts.EmploymentRelationship_2_WorkingContractAssigmentID,
				el_WorkingContracts.IsContract_Active,
				el_WorkingContracts.IsContractEndDateDefined,
				el_WorkingContracts.IsWorkTimeCalculated_InHours,
				el_WorkingContracts.IsWorkTimeCalculated_InDays,
				el_WorkingContracts.Contract_StartDate,
				el_WorkingContracts.Contract_EndDate,
				el_WorkingContracts.R_WorkTime_HoursPerWeek,
				el_WorkingContracts.R_WorkTime_DaysPerWeek,
				el_WorkingContracts.ExtraWorkCalculation_RefID,
				el_WorkingContracts.WorkingContract_InCurrency_RefID,
				el_WorkingContracts.IsWorktimeChecked_Weekly,
				el_WorkingContracts.IsWorktimeChecked_Monthly,
				el_WorkingContracts.SurchargeCalculation_UseMaximum,
				el_WorkingContracts.SurchargeCalculation_UseAccumulated,
				el_WorkingContracts.IsMealAllowanceProvided,
				el_WorkingContracts.WorkingContract_Comment,
				el_WorkingContracts.NightTime_Surcharge_RefID,
				el_WorkingContracts.SpecialEvent_Surcharge_RefID,
				el_WorkingContracts.MaximumAllowedNightTimeSurchargeTime_in_mins,
				el_WorkingContracts.MaximumAllowedSpecialEventSurchargeTime_in_mins,

			}
			into gfunct_WorkingContracts
			select new L5EM_GEFE_1150_WorkingContract
			{     
				CMN_BPT_EMP_WorkingContractID = gfunct_WorkingContracts.Key.CMN_BPT_EMP_WorkingContractID ,
				EmploymentRelationship_2_WorkingContractAssigmentID = gfunct_WorkingContracts.Key.EmploymentRelationship_2_WorkingContractAssigmentID ,
				IsContract_Active = gfunct_WorkingContracts.Key.IsContract_Active ,
				IsContractEndDateDefined = gfunct_WorkingContracts.Key.IsContractEndDateDefined ,
				IsWorkTimeCalculated_InHours = gfunct_WorkingContracts.Key.IsWorkTimeCalculated_InHours ,
				IsWorkTimeCalculated_InDays = gfunct_WorkingContracts.Key.IsWorkTimeCalculated_InDays ,
				Contract_StartDate = gfunct_WorkingContracts.Key.Contract_StartDate ,
				Contract_EndDate = gfunct_WorkingContracts.Key.Contract_EndDate ,
				R_WorkTime_HoursPerWeek = gfunct_WorkingContracts.Key.R_WorkTime_HoursPerWeek ,
				R_WorkTime_DaysPerWeek = gfunct_WorkingContracts.Key.R_WorkTime_DaysPerWeek ,
				ExtraWorkCalculation_RefID = gfunct_WorkingContracts.Key.ExtraWorkCalculation_RefID ,
				WorkingContract_InCurrency_RefID = gfunct_WorkingContracts.Key.WorkingContract_InCurrency_RefID ,
				IsWorktimeChecked_Weekly = gfunct_WorkingContracts.Key.IsWorktimeChecked_Weekly ,
				IsWorktimeChecked_Monthly = gfunct_WorkingContracts.Key.IsWorktimeChecked_Monthly ,
				SurchargeCalculation_UseMaximum = gfunct_WorkingContracts.Key.SurchargeCalculation_UseMaximum ,
				SurchargeCalculation_UseAccumulated = gfunct_WorkingContracts.Key.SurchargeCalculation_UseAccumulated ,
				IsMealAllowanceProvided = gfunct_WorkingContracts.Key.IsMealAllowanceProvided ,
				WorkingContract_Comment = gfunct_WorkingContracts.Key.WorkingContract_Comment ,
				NightTime_Surcharge_RefID = gfunct_WorkingContracts.Key.NightTime_Surcharge_RefID ,
				SpecialEvent_Surcharge_RefID = gfunct_WorkingContracts.Key.SpecialEvent_Surcharge_RefID ,
				MaximumAllowedNightTimeSurchargeTime_in_mins = gfunct_WorkingContracts.Key.MaximumAllowedNightTimeSurchargeTime_in_mins ,
				MaximumAllowedSpecialEventSurchargeTime_in_mins = gfunct_WorkingContracts.Key.MaximumAllowedSpecialEventSurchargeTime_in_mins ,

				WeeklyOfficeHours = 
				(
					from el_WeeklyOfficeHours in gfunct_WorkingContracts.Where(element => !EqualsDefaultValue(element.CMN_CAL_WeeklyOfficeHours_IntervalID)).ToArray()
					group el_WeeklyOfficeHours by new 
					{ 
						el_WeeklyOfficeHours.CMN_CAL_WeeklyOfficeHours_IntervalID,

					}
					into gfunct_WeeklyOfficeHours
					select new L5EM_GEFE_1150_WeeklyOfficeHours
					{     
						CMN_CAL_WeeklyOfficeHours_IntervalID = gfunct_WeeklyOfficeHours.Key.CMN_CAL_WeeklyOfficeHours_IntervalID ,
						IsWholeDay = gfunct_WeeklyOfficeHours.FirstOrDefault().IsWholeDay ,
						TimeFrom_InMinutes = gfunct_WeeklyOfficeHours.FirstOrDefault().TimeFrom_InMinutes ,
						TimeTo_InMinutes = gfunct_WeeklyOfficeHours.FirstOrDefault().TimeTo_InMinutes ,
						IsMonday = gfunct_WeeklyOfficeHours.FirstOrDefault().IsMonday ,
						IsTuesday = gfunct_WeeklyOfficeHours.FirstOrDefault().IsTuesday ,
						IsWednesday = gfunct_WeeklyOfficeHours.FirstOrDefault().IsWednesday ,
						IsThursday = gfunct_WeeklyOfficeHours.FirstOrDefault().IsThursday ,
						IsFriday = gfunct_WeeklyOfficeHours.FirstOrDefault().IsFriday ,
						IsSaturday = gfunct_WeeklyOfficeHours.FirstOrDefault().IsSaturday ,
						IsSunday = gfunct_WeeklyOfficeHours.FirstOrDefault().IsSunday ,

					}
				).ToArray(),
				WorkingContractToLeaveRequest = 
				(
					from el_WorkingContractToLeaveRequest in gfunct_WorkingContracts.ToArray()
					select new L5EM_GEFE_1150_WorkingContractToLeaveRequest
					{     
						CMN_BPT_EMP_WorkingContract_AllowedAbsenceReasonID = el_WorkingContractToLeaveRequest.CMN_BPT_EMP_WorkingContract_AllowedAbsenceReasonID,
						CMN_BPT_STA_AbsenceReasonID = el_WorkingContractToLeaveRequest.CMN_BPT_STA_AbsenceReasonID,
						IsAbsenceCalculated_InHours = el_WorkingContractToLeaveRequest.IsAbsenceCalculated_InHours,
						IsAbsenceCalculated_InDays = el_WorkingContractToLeaveRequest.IsAbsenceCalculated_InDays,
						ContractAllowedAbsence_per_Month = el_WorkingContractToLeaveRequest.ContractAllowedAbsence_per_Month,
						AbsenceReasonName = el_WorkingContractToLeaveRequest.AbsenceReasonName,
						CMN_BPT_EMP_EmploymentRelationship_RefID = el_WorkingContractToLeaveRequest.CMN_BPT_EMP_EmploymentRelationship_RefID,

					}
				).ToArray(),

			}
		).ToArray(),
		Rights = 
		(
			from el_Rights in gfunct_L5EM_GEFE_1150.Where(element => !EqualsDefaultValue(element.AssignmentID)).ToArray()
			group el_Rights by new 
			{ 
				el_Rights.AssignmentID,

			}
			into gfunct_Rights
			select new L5EM_GEFE_1150_Right
			{     
				AssignmentID = gfunct_Rights.Key.AssignmentID ,
				USR_Account_FunctionLevelRightID = gfunct_Rights.FirstOrDefault().USR_Account_FunctionLevelRightID ,
				RightName = gfunct_Rights.FirstOrDefault().RightName ,

			}
		).ToArray(),
		Contacts = 
		(
			from el_Contacts in gfunct_L5EM_GEFE_1150.Where(element => !EqualsDefaultValue(element.CMN_PER_CommunicationContactID)).ToArray()
			group el_Contacts by new 
			{ 
				el_Contacts.CMN_PER_CommunicationContactID,

			}
			into gfunct_Contacts
			select new L5EM_GEFE_1150_Contacts
			{     
				Content = gfunct_Contacts.FirstOrDefault().Content ,
				CMN_PER_CommunicationContactID = gfunct_Contacts.Key.CMN_PER_CommunicationContactID ,
				CMN_PER_CommunicationContact_TypeID = gfunct_Contacts.FirstOrDefault().CMN_PER_CommunicationContact_TypeID ,
				Type = gfunct_Contacts.FirstOrDefault().Type ,

			}
		).ToArray(),
		FunctionHistory = 
		(
			from el_FunctionHistory in gfunct_L5EM_GEFE_1150.Where(element => !EqualsDefaultValue(element.CMN_BPT_EMP_Employee_FunctionHistoryID)).ToArray()
			group el_FunctionHistory by new 
			{ 
				el_FunctionHistory.CMN_BPT_EMP_Employee_FunctionHistoryID,

			}
			into gfunct_FunctionHistory
			select new L5EM_GEFE_1150_FunctionHistory
			{     
				Date = gfunct_FunctionHistory.FirstOrDefault().Date ,
				CMN_BPT_EMP_Employee_FunctionHistoryID = gfunct_FunctionHistory.Key.CMN_BPT_EMP_Employee_FunctionHistoryID ,
				FunctionName = gfunct_FunctionHistory.FirstOrDefault().FunctionName ,
				IsPrimary = gfunct_FunctionHistory.FirstOrDefault().IsPrimary ,

			}
		).ToArray(),
		EmployeeWorkplaceHistory = 
		(
			from el_EmployeeWorkplaceHistory in gfunct_L5EM_GEFE_1150.Where(element => !EqualsDefaultValue(element.CMN_BPT_EMP_Employee_WorkplaceAssignmentID)).ToArray()
			group el_EmployeeWorkplaceHistory by new 
			{ 
				el_EmployeeWorkplaceHistory.CMN_BPT_EMP_Employee_WorkplaceAssignmentID,

			}
			into gfunct_EmployeeWorkplaceHistory
			select new L5EM_GEFE_1150_EmployeeWorkplaceHistory
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
		EmployeeDocuments = 
		(
			from el_EmployeeDocuments in gfunct_L5EM_GEFE_1150.Where(element => !EqualsDefaultValue(element.CMN_BPT_EMP_Employee_PayroleDocumentsID)).ToArray()
			group el_EmployeeDocuments by new 
			{ 
				el_EmployeeDocuments.CMN_BPT_EMP_Employee_PayroleDocumentsID,

			}
			into gfunct_EmployeeDocuments
			select new L5EM_GEFE_1150_EmployeeDocuments
			{     
				CMN_BPT_EMP_Employee_PayroleDocumentsID = gfunct_EmployeeDocuments.Key.CMN_BPT_EMP_Employee_PayroleDocumentsID ,
				Document_RefID = gfunct_EmployeeDocuments.FirstOrDefault().Document_RefID ,
				IsViewedByEmployee = gfunct_EmployeeDocuments.FirstOrDefault().IsViewedByEmployee ,
				DocumentDate = gfunct_EmployeeDocuments.FirstOrDefault().DocumentDate ,
				ViewedOnDate = gfunct_EmployeeDocuments.FirstOrDefault().ViewedOnDate ,
				Description = gfunct_EmployeeDocuments.FirstOrDefault().Description ,
				Name = gfunct_EmployeeDocuments.FirstOrDefault().Name ,
				File_Extension = gfunct_EmployeeDocuments.FirstOrDefault().File_Extension ,
				File_MIMEType = gfunct_EmployeeDocuments.FirstOrDefault().File_MIMEType ,

			}
		).ToArray(),
		EmployeeQualifications = 
		(
			from el_EmployeeQualifications in gfunct_L5EM_GEFE_1150.Where(element => !EqualsDefaultValue(element.QualificationAssignmentID)).ToArray()
			group el_EmployeeQualifications by new 
			{ 
				el_EmployeeQualifications.QualificationAssignmentID,

			}
			into gfunct_EmployeeQualifications
			select new L5EM_GEFE_1150_EmployeeQualification
			{     
				QualificationAssignmentID = gfunct_EmployeeQualifications.Key.QualificationAssignmentID ,
				ProfessionObtainedAtDate = gfunct_EmployeeQualifications.FirstOrDefault().ProfessionObtainedAtDate ,
				Skill_RefID = gfunct_EmployeeQualifications.FirstOrDefault().Skill_RefID ,
				SkillName = gfunct_EmployeeQualifications.FirstOrDefault().SkillName ,

			}
		).ToArray(),
		EmployeeBankAccount = 
		(
			from el_EmployeeBankAccount in gfunct_L5EM_GEFE_1150.ToArray()
			group el_EmployeeBankAccount by new 
			{ 
			}
			into gfunct_EmployeeBankAccount
			select new L5EM_GEFE_1150_EmployeeBankAccount
			{     
				ACC_BNK_BankAccountID = gfunct_EmployeeBankAccount.FirstOrDefault().ACC_BNK_BankAccountID ,
				IBAN = gfunct_EmployeeBankAccount.FirstOrDefault().IBAN ,
				OwnerText = gfunct_EmployeeBankAccount.FirstOrDefault().OwnerText ,

			}
		).FirstOrDefault(),
		EmployeeTax = 
		(
			from el_EmployeeTax in gfunct_L5EM_GEFE_1150.ToArray()
			group el_EmployeeTax by new 
			{ 
			}
			into gfunct_EmployeeTax
			select new L5EM_GEFE_1150_EmployeeTax
			{     
				CMN_BPT_EMP_Employee_TaxInformationID = gfunct_EmployeeTax.FirstOrDefault().CMN_BPT_EMP_Employee_TaxInformationID ,
				TaxNumber = gfunct_EmployeeTax.FirstOrDefault().TaxNumber ,
				TaxClass = gfunct_EmployeeTax.FirstOrDefault().TaxClass ,
				TaxExemptionAmount = gfunct_EmployeeTax.FirstOrDefault().TaxExemptionAmount ,
				NumberOfChildren = gfunct_EmployeeTax.FirstOrDefault().NumberOfChildren ,
				Religion_RefID = gfunct_EmployeeTax.FirstOrDefault().Religion_RefID ,
				VATIdentificationNumber = gfunct_EmployeeTax.FirstOrDefault().VATIdentificationNumber ,
				ACC_TAX_TaxOfficeID = gfunct_EmployeeTax.FirstOrDefault().ACC_TAX_TaxOfficeID ,

			}
		).FirstOrDefault(),
		EmployeeSocialSecurity = 
		(
			from el_EmployeeSocialSecurity in gfunct_L5EM_GEFE_1150.ToArray()
			group el_EmployeeSocialSecurity by new 
			{ 
			}
			into gfunct_EmployeeSocialSecurity
			select new L5EM_GEFE_1150_EmployeeSocialSecurity
			{     
				HealthInsurance_Number = gfunct_EmployeeSocialSecurity.FirstOrDefault().HealthInsurance_Number ,
				CMN_STR_ProfessionID = gfunct_EmployeeSocialSecurity.FirstOrDefault().CMN_STR_ProfessionID ,
				HEC_HealthInsurance_CompanyID = gfunct_EmployeeSocialSecurity.FirstOrDefault().HEC_HealthInsurance_CompanyID ,
				CMN_PER_CompulsorySocialSecurityStatusID = gfunct_EmployeeSocialSecurity.FirstOrDefault().CMN_PER_CompulsorySocialSecurityStatusID ,

			}
		).FirstOrDefault(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5EM_GEFE_1150 : FR_Base
	{
		public L5EM_GEFE_1150 Result	{ get; set; }

		public FR_L5EM_GEFE_1150() : base() {}

		public FR_L5EM_GEFE_1150(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5EM_GEFE_1150 cls_Get_Employee_For_EmployeeID(P_L5EM_GEFE_1150 Parameter,string sessionToken = null)
{
	 var securityTicket = ...;
	 FR_L5EM_GEFE_1150 result = cls_Get_Employee_For_EmployeeID.Invoke(connectionString,P_L5EM_GEFE_1150 Parameter,securityTicket);
	 return result;
}
*/