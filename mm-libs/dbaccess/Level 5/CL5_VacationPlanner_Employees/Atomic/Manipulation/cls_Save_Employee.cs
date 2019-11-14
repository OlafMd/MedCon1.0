/* 
<<<<<<< HEAD
 * Generated on 2/13/2014 11:32:22 AM
=======
 * Generated on 2/18/2014 12:32:48 PM
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
using CL5_VacationPlanner_Employees.Atomic.Retrieval;
using CL1_CMN_BPT_EMP;
using CL1_USR;
using CL1_CMN_PER;
using BOp.Infrastructure;
using CL5_VacationPlanner_Employees.Complex.Retrieval;
using BOp.Infrastructure.Enterprise;
using CL5_VacationPlanner_Tenant.Atomic.Retrieval;
using CL1_CMN_CAL;
using CL1_CMN_BPT;
using CL1_CMN;
using BOp.Message.Realm;
using PlannicoModel.Models;

namespace CL5_VacationPlanner_Employees.Atomic.Manipulation
{
	/// <summary>
    /// No description found in <meta/> tag
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Employee.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Employee
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5EM_SE_1657 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_Guid();
            //Put your code here

            ORM_CMN_Address address = new ORM_CMN_Address();
            if (Parameter.CMN_AddressID != Guid.Empty)
            {
                var result = address.Load(Connection, Transaction, Parameter.CMN_AddressID);
                if (result.Status != FR_Status.Success || address.CMN_AddressID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }
            address.City_Name = Parameter.City_Name;
            address.Street_Name = Parameter.Street_Name;
            address.Street_Number = Parameter.Street_Number;
            address.Country_Name = Parameter.Country_Name;
            address.Province_Name = Parameter.Province_Name;
            address.Tenant_RefID = securityTicket.TenantID;
            address.City_PostalCode = Parameter.City_PostalCode;
            address.Save(Connection, Transaction);
            CSV2Core.DlTrace.Trace("success address");
            ORM_CMN_PER_PersonInfo person = new ORM_CMN_PER_PersonInfo();
            if (Parameter.CMN_PER_PersonInfoID != Guid.Empty)
            {
                var result = person.Load(Connection, Transaction, Parameter.CMN_PER_PersonInfoID);
                if (result.Status != FR_Status.Success || person.CMN_PER_PersonInfoID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }

            //person.AccountImage_URL = Parameter.ProfileImage_Document_RefID;
            person.FirstName = Parameter.FirstName;
            person.LastName = Parameter.LastName;
            person.PrimaryEmail = Parameter.PrimaryEmail;
            person.Tenant_RefID = securityTicket.TenantID;
            person.Title = Parameter.Title;
            person.Address_RefID = address.CMN_AddressID;
            person.ProfileImage_Document_RefID = Parameter.ImageID;
            person.BirthDate = Parameter.BirthDate;
            person.NumberOfChildren = Parameter.TaxInfoParameter != null ? Parameter.TaxInfoParameter.NumberOfChildren : 0;
            person.Save(Connection, Transaction);
            CSV2Core.DlTrace.Trace("success persopm");

            var contactQuery = new ORM_CMN_PER_CommunicationContact.Query();
            contactQuery.Tenant_RefID = securityTicket.TenantID;
            contactQuery.PersonInfo_RefID = person.CMN_PER_PersonInfoID;
            contactQuery.IsDeleted = false;
            var deleteContacts = ORM_CMN_PER_CommunicationContact.Query.SoftDelete(Connection, Transaction, contactQuery);
            foreach (var parContact in Parameter.Contacts)
            {
                ORM_CMN_PER_CommunicationContact contact = new ORM_CMN_PER_CommunicationContact();
                if (parContact.CMN_PER_CommunicationContactID != Guid.Empty)
                {
                    var result = contact.Load(Connection, Transaction, parContact.CMN_PER_CommunicationContactID);
                    if (result.Status != FR_Status.Success || contact.CMN_PER_CommunicationContactID == Guid.Empty)
                    {
                        var error = new FR_Guid();
                        error.ErrorMessage = "No Such ID";
                        error.Status = FR_Status.Error_Internal;
                        return error;
                    }
                }
                contact.Content = parContact.Content;
                contact.Contact_Type = parContact.CMN_PER_CommunicationContact_TypeID;
                contact.Tenant_RefID = securityTicket.TenantID;
                contact.PersonInfo_RefID = person.CMN_PER_PersonInfoID;
                contact.Save(Connection, Transaction);
                CSV2Core.DlTrace.Trace("success contact");
            }

            ORM_CMN_BPT_BusinessParticipant bParticipant = new ORM_CMN_BPT_BusinessParticipant();
            if (Parameter.CMN_BPT_BusinessParticipantID != Guid.Empty)
            {
                var result = bParticipant.Load(Connection, Transaction, Parameter.CMN_BPT_BusinessParticipantID);
                if (result.Status != FR_Status.Success || bParticipant.CMN_BPT_BusinessParticipantID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }
            bParticipant.DisplayName = Parameter.DisplayName;
            bParticipant.IfNaturalPerson_CMN_PER_PersonInfo_RefID = person.CMN_PER_PersonInfoID;
            bParticipant.IsNaturalPerson = true;
            bParticipant.Tenant_RefID = securityTicket.TenantID;
            bParticipant.Save(Connection, Transaction);
            ORM_CMN_BPT_EMP_Employee employee = new ORM_CMN_BPT_EMP_Employee();
            CSV2Core.DlTrace.Trace("success bpart");


            if (Parameter.CMN_BPT_EMP_EmployeeID != Guid.Empty)
            {
                var result = employee.Load(Connection, Transaction, Parameter.CMN_BPT_EMP_EmployeeID);
                if (result.Status != FR_Status.Success || employee.CMN_BPT_EMP_EmployeeID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }
            employee.BusinessParticipant_RefID = bParticipant.CMN_BPT_BusinessParticipantID;
            employee.Staff_Number = Parameter.Staff_Number;
            employee.StandardFunction = Parameter.StandardFunction;
            employee.Tenant_RefID = securityTicket.TenantID;
            employee.Save(Connection, Transaction);
            CSV2Core.DlTrace.Trace("success employee");


            ORM_CMN_BPT_EMP_EmploymentRelationship employmentRelationship = new ORM_CMN_BPT_EMP_EmploymentRelationship();
            if (Parameter.CMN_BPT_EMP_Employee_EmploymentRelationshipID != Guid.Empty)
            {
                var result = employmentRelationship.Load(Connection, Transaction, Parameter.CMN_BPT_EMP_Employee_EmploymentRelationshipID);
                if (result.Status != FR_Status.Success || employmentRelationship.CMN_BPT_EMP_EmploymentRelationshipID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }
            employmentRelationship.Work_StartDate = Parameter.Work_StartDate;

            bool resignationDateChanged = false;
            if (employmentRelationship.Work_EndDate != Parameter.Work_EndDate)
                resignationDateChanged = true;

            employmentRelationship.Work_EndDate = Parameter.Work_EndDate;
            employmentRelationship.Tenant_RefID = securityTicket.TenantID;
            employmentRelationship.Employee_RefID = employee.CMN_BPT_EMP_EmployeeID;
            employmentRelationship.Save(Connection, Transaction);
            CSV2Core.DlTrace.Trace("success employmentRelationship");

            if(Parameter.Work_EndDate.Ticks!=0){
            ORM_CMN_BPT_EMP_EmploymentRelationship_2_WorkingContract.Query empRelationShipToWorkingContractQuery = new ORM_CMN_BPT_EMP_EmploymentRelationship_2_WorkingContract.Query();
            empRelationShipToWorkingContractQuery.EmploymentRelationship_RefID = employmentRelationship.CMN_BPT_EMP_EmploymentRelationshipID;
            empRelationShipToWorkingContractQuery.Tenant_RefID = securityTicket.TenantID;
            empRelationShipToWorkingContractQuery.IsDeleted = false;
            List<ORM_CMN_BPT_EMP_EmploymentRelationship_2_WorkingContract> workingContractAssignments = ORM_CMN_BPT_EMP_EmploymentRelationship_2_WorkingContract.Query.Search(Connection, Transaction, empRelationShipToWorkingContractQuery);
            foreach (var workingContractAssignment in workingContractAssignments)
            {
                ORM_CMN_BPT_EMP_WorkingContract workingContract = new ORM_CMN_BPT_EMP_WorkingContract();
                if (workingContractAssignment.WorkingContract_RefID != Guid.Empty)
                {
                    var result = workingContract.Load(Connection, Transaction, workingContractAssignment.WorkingContract_RefID);
                    if (result.Status != FR_Status.Success || workingContract.CMN_BPT_EMP_WorkingContractID == Guid.Empty)
                    {
                        var error = new FR_Guid();
                        error.ErrorMessage = "No Such ID";
                        error.Status = FR_Status.Error_Internal;
                        return error;
                    }
                }
                if (workingContract.Contract_EndDate.Ticks == 0 || workingContract.Contract_EndDate.Ticks > Parameter.Work_EndDate.Ticks)
                {
                    workingContract.Contract_EndDate = Parameter.Work_EndDate;
                    workingContract.IsContractEndDateDefined = true;
                    workingContract.Save(Connection, Transaction);
                }
            }
            }

            var activeTimeFrame = cls_Get_Active_CalculationTimeFrame.Invoke(Connection, Transaction, securityTicket).Result;

            var timeframes = cls_Get_CalculationTimeFramesForTenant.Invoke(Connection, Transaction, securityTicket).Result.ToList();
            var resultFrames = timeframes.Where(i => i.CalculationTimeframe_StartDate.Year == employmentRelationship.Work_StartDate.Year).ToList();
            if (resultFrames.Count == 0)
            {
                var newFrame = new ORM_CMN_CAL_CalculationTimeframe();
                int currentYear = Parameter.Work_StartDate.Year;
                while (currentYear < activeTimeFrame.CalculationTimeframe_StartDate.Year)
                {
                    if (!timeframes.Any(i => i.CalculationTimeframe_StartDate.Year == currentYear))
                    {
                        newFrame.CalculationTimeframe_StartDate = new DateTime(currentYear, 1, 1);
                        newFrame.CalculationTimeframe_EstimatedEndDate = new DateTime(currentYear, 12, 31);
                        newFrame.Tenant_RefID = securityTicket.TenantID;
                        newFrame.Save(Connection, Transaction);
                        newFrame = new ORM_CMN_CAL_CalculationTimeframe();

                    }
                    currentYear++;

                    ORM_CMN_BPT_EMP_EmploymentRelationship_Timeframe relationshipFrame = new ORM_CMN_BPT_EMP_EmploymentRelationship_Timeframe();
                    relationshipFrame.CalculationTimeframe_RefID = newFrame.CMN_CAL_CalculationTimeframeID;
                    relationshipFrame.EmploymentRelationship_RefID = employmentRelationship.CMN_BPT_EMP_EmploymentRelationshipID;
                    relationshipFrame.Tenant_RefID = securityTicket.TenantID;
                    relationshipFrame.Save(Connection, Transaction);


                }
            }
            else
            {


                timeframes = timeframes.Where(i => i.CalculationTimeframe_StartDate.Year < activeTimeFrame.CalculationTimeframe_StartDate.Year && i.CalculationTimeframe_StartDate.Year >= employmentRelationship.Work_StartDate.Year).ToList();
                foreach (var timeframe in timeframes)
                {
                    ORM_CMN_BPT_EMP_EmploymentRelationship_Timeframe.Query relationshipFrameQuery = new ORM_CMN_BPT_EMP_EmploymentRelationship_Timeframe.Query();
                    relationshipFrameQuery.CalculationTimeframe_RefID = timeframe.CMN_CAL_CalculationTimeframeID;
                    relationshipFrameQuery.EmploymentRelationship_RefID = employmentRelationship.CMN_BPT_EMP_EmploymentRelationshipID;
                    relationshipFrameQuery.Tenant_RefID = securityTicket.TenantID;
                    List<ORM_CMN_BPT_EMP_EmploymentRelationship_Timeframe> oldContractFrames = ORM_CMN_BPT_EMP_EmploymentRelationship_Timeframe.Query.Search(Connection, Transaction, relationshipFrameQuery);
                    if (oldContractFrames.Count == 0)
                    {
                        ORM_CMN_BPT_EMP_EmploymentRelationship_Timeframe relationshipFrame = new ORM_CMN_BPT_EMP_EmploymentRelationship_Timeframe();
                        relationshipFrame.CalculationTimeframe_RefID = timeframe.CMN_CAL_CalculationTimeframeID;
                        relationshipFrame.EmploymentRelationship_RefID = employmentRelationship.CMN_BPT_EMP_EmploymentRelationshipID;
                        relationshipFrame.Tenant_RefID = securityTicket.TenantID;
                        relationshipFrame.Save(Connection, Transaction);
                    }
                }
            }



            P_L5EM_GAERCTFFE_1405 timeFrameParam = new P_L5EM_GAERCTFFE_1405();
            timeFrameParam.EmployeeID = employee.CMN_BPT_EMP_EmployeeID;
            L5EM_GAERCTFFE_1405 employeeTimeFrame = cls_Get_Active_EmployeeRelationshipTimeFrame_For_EmployeeID.Invoke(Connection, Transaction, timeFrameParam, securityTicket).Result;
            if (employeeTimeFrame == null)
            {
                ORM_CMN_BPT_EMP_EmploymentRelationship_Timeframe timeFrame = new ORM_CMN_BPT_EMP_EmploymentRelationship_Timeframe();
                timeFrame.CalculationTimeframe_RefID = activeTimeFrame.CMN_CAL_CalculationTimeframeID;
                timeFrame.EmploymentRelationship_RefID = employmentRelationship.CMN_BPT_EMP_EmploymentRelationshipID;
                timeFrame.Tenant_RefID = securityTicket.TenantID;
                timeFrame.Save(Connection, Transaction);
                CSV2Core.DlTrace.Trace("success timeFrame");
            }

            //save employee professions
            P_L5EM_SEP_1447 saveProfessionsPar = new P_L5EM_SEP_1447();
            saveProfessionsPar.Employee_RefID = employee.CMN_BPT_EMP_EmployeeID;
            saveProfessionsPar.FunctionHistories = Parameter.FunctionHistories;
            cls_Save_EmployeeFunctionHistory.Invoke(Connection, Transaction, saveProfessionsPar, securityTicket);
            CSV2Core.DlTrace.Trace("success employee function history");

            //save workplace histories
            P_L5EM_SWPH_1625 saveWorkplaceHistoryPar = new P_L5EM_SWPH_1625();
            saveWorkplaceHistoryPar.Employee_RefID = employee.CMN_BPT_EMP_EmployeeID;
            saveWorkplaceHistoryPar.WorkplaceHistories = Parameter.WorkplaceHistories;
            cls_Save_WorkplaceHistories.Invoke(Connection, Transaction, saveWorkplaceHistoryPar, securityTicket);
            CSV2Core.DlTrace.Trace("success workplaceHistories");

            P_L5EM_SUED_1648 saveDocuments = new P_L5EM_SUED_1648();
            saveDocuments.Employee_RefID = employee.CMN_BPT_EMP_EmployeeID;
            saveDocuments.Documents = Parameter.Documents;
            cls_Save_Uploaded_Employee_Document.Invoke(Connection, Transaction, saveDocuments, securityTicket);
            CSV2Core.DlTrace.Trace("success documents");

            P_L5EM_SEQS_0959 saveSkillsPar = new P_L5EM_SEQS_0959();
            saveSkillsPar.Employee_RefID = employee.CMN_BPT_EMP_EmployeeID;
            saveSkillsPar.Skills = Parameter.Skills;
            cls_Save_Employee_QualificationSkills.Invoke(Connection, Transaction, saveSkillsPar, securityTicket);
            CSV2Core.DlTrace.Trace("success skills");

            CSV2Core.DlTrace.Trace("AccountID :"+Parameter.USR_AccountID);

            if (Parameter.USR_AccountID != null && Parameter.USR_AccountID != Guid.Empty)
            {
                CSV2Core.DlTrace.Trace("success param");

                ORM_USR_Account account = new ORM_USR_Account();
                if (Parameter.USR_AccountID != Guid.Empty)
                {
                    var result = account.Load(Connection, Transaction, Parameter.USR_AccountID);
                    if (account.USR_AccountID == Guid.Empty)
                    {
                        account.USR_AccountID = Guid.NewGuid();
                        account.AccountType = 2;
                    }
                    account.Username = Parameter.username;
                    account.DefaultLanguage_RefID = Parameter.LanguageID;
                    account.BusinessParticipant_RefID = bParticipant.CMN_BPT_BusinessParticipantID;
                    account.Tenant_RefID = securityTicket.TenantID;
                    account.Save(Connection, Transaction);


                    var personToAccountQuery = new ORM_CMN_PER_PersonInfo_2_Account.Query();
                    personToAccountQuery.Tenant_RefID = securityTicket.TenantID;
                    personToAccountQuery.USR_Account_RefID = account.USR_AccountID;
                    personToAccountQuery.IsDeleted = false;
                    var personToAccounts = ORM_CMN_PER_PersonInfo_2_Account.Query.Search(Connection, Transaction, personToAccountQuery);
                    if (personToAccounts.Count != 0)
                    {
                        ORM_CMN_PER_PersonInfo_2_Account personToAccount = personToAccounts[0];
                        personToAccount.CMN_PER_PersonInfo_RefID = person.CMN_PER_PersonInfoID;
                        personToAccount.USR_Account_RefID = account.USR_AccountID;
                        personToAccount.Tenant_RefID = securityTicket.TenantID;
                        personToAccount.Save(Connection, Transaction);
                    }
                    else
                    {
                        ORM_CMN_PER_PersonInfo_2_Account personToAccount = new ORM_CMN_PER_PersonInfo_2_Account();
                        personToAccount.CMN_PER_PersonInfo_RefID = person.CMN_PER_PersonInfoID;
                        personToAccount.USR_Account_RefID = account.USR_AccountID;
                        personToAccount.Tenant_RefID = securityTicket.TenantID;
                        personToAccount.Save(Connection, Transaction);
                    }
          

                }



                
                if (Parameter.Rights != null)
                {
                    foreach (var rightsParam in Parameter.Rights)
                    {
                        if (rightsParam.RightAssinmentID == Guid.Empty && rightsParam.RightID != Guid.Empty)
                        {
                            var right2account = new ORM_USR_Account_2_FunctionLevelRight();
                            right2account.Account_RefID = Parameter.USR_AccountID;
                            right2account.FunctionLevelRight_RefID = rightsParam.RightID;
                            right2account.Tenant_RefID = securityTicket.TenantID;
                            right2account.Save(Connection, Transaction);
                            CSV2Core.DlTrace.Trace("success save right: " + right2account.FunctionLevelRight_RefID);
                        }

                        if (rightsParam.RightAssinmentID != Guid.Empty && rightsParam.RightID == Guid.Empty)
                        {
                            var right2account = new ORM_USR_Account_2_FunctionLevelRight();
                            if (rightsParam.RightAssinmentID != Guid.Empty)
                            {
                                var result = right2account.Load(Connection, Transaction, rightsParam.RightAssinmentID);
                                if (result.Status != FR_Status.Success || right2account.AssignmentID == Guid.Empty)
                                {
                                    var error = new FR_Guid();
                                    error.ErrorMessage = "No Such ID";
                                    error.Status = FR_Status.Error_Internal;
                                    return error;
                                }
                            }
                            right2account.IsDeleted = true;
                            right2account.Save(Connection, Transaction);
                            CSV2Core.DlTrace.Trace("success save right2Acc: " + right2account.FunctionLevelRight_RefID);
                        }
                    }
                }

            }

            CSV2Core.DlTrace.Trace("emp id wtf " + Parameter.CMN_BPT_EMP_EmployeeID);

            if (Parameter.CMN_BPT_EMP_EmployeeID == Guid.Empty || resignationDateChanged)
            {

                var enterpriseService = InfrastructureFactory.CreateEnterpriseService();
                KeyPerformanceIndicator action = new KeyPerformanceIndicator();
                action.PerformedByAccountID = securityTicket.AccountID;
                action.PerformedByApplicationID = Parameter.ApplicationID;
                action.PerformedOn = DateTime.Now;
                action.PerformedByTenantID = securityTicket.TenantID;
                action.KeyPerformanceIndicatorID = Guid.Parse("4dda967a-5399-4929-afae-7af64699895b");
                action.Value = cls_Get_Employees_For_Tenant.Invoke(Connection, Transaction, securityTicket).Result.Where(i=>i.Work_EndDate.Ticks==0||i.Work_EndDate.Ticks>DateTime.Now.Ticks).ToArray().Length;

                var result = enterpriseService.SendMessage(action.ToPayload(), KeyPerformanceIndicator.MESSAGE_TYPE, Parameter.ApplicationID, EMessageRecipient.CUSTOMER_MANAGEMENT_PLATFORM);
                // ServerLog.Instance.Info("Enterprise message sending " + (result.Code == 200 ? "successful" : "failed"));
                CSV2Core.DlTrace.Trace("success send kpi");
            }

            Parameter.TaxInfoParameter.EmployeeID = employee.CMN_BPT_EMP_EmployeeID;
            Parameter.TaxInfoParameter.CMN_BPT_BusinessParticipantID = bParticipant.CMN_BPT_BusinessParticipantID;
            cls_Save_Employee_TaxInformation.Invoke(Connection, Transaction, Parameter.TaxInfoParameter, securityTicket);
            cls_Save_Employee_BankAccount.Invoke(Connection, Transaction, Parameter.BankAccountParameter, securityTicket);
            Parameter.SocialSecurity.CMN_PER_PersonInfoID = person.CMN_PER_PersonInfoID;
            Parameter.SocialSecurity.CMN_BPT_EMP_EmployeeID = employee.CMN_BPT_EMP_EmployeeID;
            Parameter.SocialSecurity.CMN_BPT_BusinessParticipantID = bParticipant.CMN_BPT_BusinessParticipantID;
            cls_Save_Employee_SocialSecurity.Invoke(Connection, Transaction, Parameter.SocialSecurity, securityTicket);

            returnValue.Result = employee.CMN_BPT_EMP_EmployeeID;
            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5EM_SE_1657 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5EM_SE_1657 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5EM_SE_1657 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5EM_SE_1657 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Guid functionReturn = new FR_Guid();
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

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Employee(P_L5EM_SE_1657 Parameter,string sessionToken = null)
{
	 var securityTicket = ...;
	 FR_Guid result = cls_Save_Employee.Invoke(connectionString,P_L5EM_SE_1657 Parameter,securityTicket);
	 return result;
}
*/
/* Support for Parameter Invocation (Copy&Paste)
var parameter = new CL5_VacationPlanner_Employees.Atomic.Manipulation.P_L5EM_SE_1657();
parameter.Rights = ...;
parameter.Contacts = ...;

parameter.CMN_PER_PersonInfoID = ...;
parameter.FirstName = ...;
parameter.LastName = ...;
parameter.PrimaryEmail = ...;
parameter.Title = ...;
parameter.BirthDate = ...;
parameter.ProfileImage_Document_RefID = ...;
parameter.CMN_AddressID = ...;
parameter.Street_Name = ...;
parameter.Street_Number = ...;
parameter.City_AdministrativeDistrict = ...;
parameter.City_Region = ...;
parameter.City_Name = ...;
parameter.City_PostalCode = ...;
parameter.Province_Name = ...;
parameter.Country_Name = ...;
parameter.Country_ISOCode = ...;
parameter.CMN_BPT_BusinessParticipantID = ...;
parameter.DisplayName = ...;
parameter.CMN_BPT_EMP_EmployeeID = ...;
parameter.Staff_Number = ...;
parameter.StandardFunction = ...;
parameter.Employee_2_Contract_AssigmentID = ...;
parameter.CMN_BPT_EMP_Employee_EmploymentRelationshipID = ...;
parameter.IsActive = ...;
parameter.Work_StartDate = ...;
parameter.Work_EndDate = ...;
parameter.ContractDate = ...;
parameter.USR_AccountID = ...;
parameter.LanguageID = ...;
parameter.username = ...;
parameter.ImageID = ...;
parameter.ApplicationID = ...;
parameter.Professions = ...;
parameter.TaxInfoParameter = ...;
parameter.BankAccountParameter = ...;
parameter.WorkplaceHistories = ...;
parameter.Documents = ...;
parameter.Skills = ...;
parameter.SocialSecurity = ...;


*/