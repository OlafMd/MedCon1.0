/* 
 * Generated on 2/6/2015 1:21:01 PM
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
using CL1_CMN_PER;
using CL1_CMN;
using CL1_CMN_BPT;
using CL1_CMN_BPT_EMP;
using CL1_HEC;
using CL1_CMN_STR;
using CL1_CMN_CAL_AVA;
using DLCore_DBCommons.Utils;
using DLCore_DBCommons.MyHealthClub;

namespace CL5_MyHealthClub_DoctorsAndStaff.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Doctors_and_Staff.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Doctors_and_Staff
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5DO_SDaS_1604 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_Guid();
            returnValue.Result = new Guid();
            Guid BusinessParticipantID = Guid.NewGuid();
            if (Parameter.CMN_BPT_BusinessParticipantID != null && Parameter.CMN_BPT_BusinessParticipantID != Guid.Empty)
                returnValue.Result = Parameter.CMN_BPT_BusinessParticipantID;
            else
                returnValue.Result = BusinessParticipantID;
            #region Save

            var TelephoneCompanyType = CL1_CMN_PER.ORM_CMN_PER_CommunicationContact_Type.Query.Search(Connection, Transaction,
                   new CL1_CMN_PER.ORM_CMN_PER_CommunicationContact_Type.Query()
                   {
                       Type = DLCore_DBCommons.Utils.EnumUtils.GetEnumDescription(CL2_Contact.DomainManagement.EComunactionContactType.Phone),
                       Tenant_RefID = securityTicket.TenantID,
                       IsDeleted = false
                   }).Single();

            var MobileCompanyType = CL1_CMN_PER.ORM_CMN_PER_CommunicationContact_Type.Query.Search(Connection, Transaction,
                   new CL1_CMN_PER.ORM_CMN_PER_CommunicationContact_Type.Query()
                   {
                       Type = DLCore_DBCommons.Utils.EnumUtils.GetEnumDescription(CL2_Contact.DomainManagement.EComunactionContactType.Mobile),
                       Tenant_RefID = securityTicket.TenantID,
                       IsDeleted = false
                   }).Single();

            var EmailType = CL1_CMN_PER.ORM_CMN_PER_CommunicationContact_Type.Query.Search(Connection, Transaction,
                   new CL1_CMN_PER.ORM_CMN_PER_CommunicationContact_Type.Query()
                   {
                       Type = DLCore_DBCommons.Utils.EnumUtils.GetEnumDescription(CL2_Contact.DomainManagement.EComunactionContactType.Email),
                       Tenant_RefID = securityTicket.TenantID,
                       IsDeleted = false
                   }).Single();

            if (Parameter.CMN_BPT_BusinessParticipantID == null || Parameter.CMN_BPT_BusinessParticipantID == Guid.Empty)
            {
                //******************* General settings************************

                var personInfo = new ORM_CMN_PER_PersonInfo();
                personInfo.CMN_PER_PersonInfoID = Guid.NewGuid();
                personInfo.Tenant_RefID = securityTicket.TenantID;

                //*******************Save Account information************************
                if (Parameter.Account_RefID != Guid.Empty)
                {
                    ORM_CMN_PER_PersonInfo_2_Account personInfo2Account = ORM_CMN_PER_PersonInfo_2_Account.Query.Search(Connection, Transaction, new ORM_CMN_PER_PersonInfo_2_Account.Query
                    {
                        USR_Account_RefID = Parameter.Account_RefID,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).Single();

                    personInfo = ORM_CMN_PER_PersonInfo.Query.Search(Connection, Transaction, new ORM_CMN_PER_PersonInfo.Query
                    {
                        CMN_PER_PersonInfoID = personInfo2Account.CMN_PER_PersonInfo_RefID,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).Single();

                    ORM_CMN_Account_ApplicationSubscription accountApplicationSubscription = new ORM_CMN_Account_ApplicationSubscription();
                    accountApplicationSubscription.CMN_Account_ApplicationSubscriptionID = Guid.NewGuid();
                    accountApplicationSubscription.Account_RefID = Parameter.Account_RefID;
                    accountApplicationSubscription.Application_RefID = Parameter.ApplicationID;
                    accountApplicationSubscription.IsDisabled = false;
                    accountApplicationSubscription.UpdatedOn = DateTime.Now;
                    accountApplicationSubscription.Tenant_RefID = securityTicket.TenantID;
                    accountApplicationSubscription.Save(Connection, Transaction);
                }

                personInfo.FirstName = Parameter.First_Name;
                personInfo.Initials = Parameter.Initals;
                personInfo.LastName = Parameter.Last_Name;
                personInfo.Gender = Parameter.Gender;
                personInfo.Title = Parameter.Title;

                var Doctor = new ORM_CMN_BPT_BusinessParticipant();
                Doctor.CMN_BPT_BusinessParticipantID = BusinessParticipantID;
                Doctor.Tenant_RefID = securityTicket.TenantID;
                Doctor.IsNaturalPerson = true;
                Doctor.IfNaturalPerson_CMN_PER_PersonInfo_RefID = personInfo.CMN_PER_PersonInfoID;
                Doctor.DisplayName = Parameter.First_Name + " " + Parameter.Last_Name;
                Doctor.DisplayImage_RefID = Parameter.DisplayImage_Document_RefID;

                var Employer = new ORM_CMN_BPT_EMP_Employee();
                Employer.Staff_Number = Parameter.Staff_Number;
                Employer.CMN_BPT_EMP_EmployeeID = Guid.NewGuid();
                Employer.BusinessParticipant_RefID = Doctor.CMN_BPT_BusinessParticipantID;
                Employer.Tenant_RefID = securityTicket.TenantID;

                if (Parameter.DoctorIDNumber != "")
                {
                    var DoctorType = new ORM_HEC_Doctor();
                    DoctorType.DoctorIDNumber = Parameter.DoctorIDNumber;
                    DoctorType.HEC_DoctorID = Guid.NewGuid();
                    DoctorType.IsTreatingChildren = Parameter.IsTreatingChildren;
                    DoctorType.BusinessParticipant_RefID = Doctor.CMN_BPT_BusinessParticipantID;
                    DoctorType.Account_RefID = Parameter.Account_RefID;
                    DoctorType.Tenant_RefID = securityTicket.TenantID;
                    DoctorType.Save(Connection, Transaction);

                    //*******************Save AppointmentType************************

                    foreach (var item in Parameter.AppTypes)
                    {
                        var doctorAssignableAppointmentType = new ORM_HEC_Doctor_AssignableAppointmentType();
                        doctorAssignableAppointmentType.HEC_Doctor_AssignableAppointmentTypeID = Guid.NewGuid();
                        doctorAssignableAppointmentType.Doctor_RefID = DoctorType.HEC_DoctorID;
                        doctorAssignableAppointmentType.TaskTemplate_RefID = item.PPS_TSK_Task_TemplateID;
                        doctorAssignableAppointmentType.IsDeleted = item.IsDeleted;
                        doctorAssignableAppointmentType.Tenant_RefID = securityTicket.TenantID;
                        doctorAssignableAppointmentType.Save(Connection, Transaction);
                    }

                }
                //*******************Save contact types************************

                ORM_CMN_PER_CommunicationContact communicationContactsPhone = new ORM_CMN_PER_CommunicationContact();

                communicationContactsPhone.CMN_PER_CommunicationContactID = Guid.NewGuid();
                communicationContactsPhone.PersonInfo_RefID = personInfo.CMN_PER_PersonInfoID;
                communicationContactsPhone.Contact_Type = TelephoneCompanyType.CMN_PER_CommunicationContact_TypeID;
                communicationContactsPhone.Content = Parameter.Contact_Telephone;
                communicationContactsPhone.Creation_Timestamp = DateTime.Now;
                communicationContactsPhone.Tenant_RefID = securityTicket.TenantID;

                communicationContactsPhone.Save(Connection, Transaction);

                ORM_CMN_PER_CommunicationContact communicationContactsMobile = new ORM_CMN_PER_CommunicationContact();

                communicationContactsMobile.CMN_PER_CommunicationContactID = Guid.NewGuid();
                communicationContactsMobile.PersonInfo_RefID = personInfo.CMN_PER_PersonInfoID;
                communicationContactsMobile.Contact_Type = MobileCompanyType.CMN_PER_CommunicationContact_TypeID;
                communicationContactsMobile.Content = Parameter.Mobile_Phone;
                communicationContactsMobile.Creation_Timestamp = DateTime.Now;
                communicationContactsMobile.Tenant_RefID = securityTicket.TenantID;

                communicationContactsMobile.Save(Connection, Transaction);

                ORM_CMN_PER_CommunicationContact communicationContactsEmail = new ORM_CMN_PER_CommunicationContact();

                communicationContactsEmail.CMN_PER_CommunicationContactID = Guid.NewGuid();
                communicationContactsEmail.PersonInfo_RefID = personInfo.CMN_PER_PersonInfoID;
                communicationContactsEmail.Contact_Type = EmailType.CMN_PER_CommunicationContact_TypeID;
                communicationContactsEmail.Content = Parameter.Contact_Email;
                communicationContactsEmail.Creation_Timestamp = DateTime.Now;
                communicationContactsEmail.Tenant_RefID = securityTicket.TenantID;

                communicationContactsEmail.Save(Connection, Transaction);
                //*******************Save unit to doctor connection************************
                if (Parameter.OrgUnits != null && Parameter.OrgUnits.Count() != 0)
                {

                    foreach (var unit in Parameter.OrgUnits)
                    {

                        var query = new ORM_CMN_STR_Office.Query();
                        query.CMN_STR_OfficeID = unit.CMN_STR_Office_RefID;
                        query.IsDeleted = false;
                        query.Tenant_RefID = securityTicket.TenantID;

                        ORM_CMN_STR_Office office = ORM_CMN_STR_Office.Query.Search(Connection, Transaction, query).Single();

                        ORM_CMN_BPT_EMP_Employee_2_Office empOffice = new ORM_CMN_BPT_EMP_Employee_2_Office();
                        empOffice.CMN_BPT_EMP_Employee_RefID = Employer.CMN_BPT_EMP_EmployeeID;
                        empOffice.CMN_STR_Office_RefID = office.CMN_STR_OfficeID;
                        empOffice.AssignmentID = Guid.NewGuid();
                        empOffice.Tenant_RefID = securityTicket.TenantID;
                        empOffice.Save(Connection, Transaction);

                    }
                }

                if (Parameter.Skills != null && Parameter.Skills.Count() != 0)
                {

                    foreach (var unit in Parameter.Skills)
                    {

                        var query = new ORM_CMN_STR_Skill.Query();
                        query.CMN_STR_SkillID = unit.CMN_STR_SkillID;
                        query.IsDeleted = false;
                        query.Tenant_RefID = securityTicket.TenantID;

                        ORM_CMN_STR_Skill skill = ORM_CMN_STR_Skill.Query.Search(Connection, Transaction, query).Single();

                        ORM_CMN_BPT_EMP_Employee_2_Skill empOffice = new ORM_CMN_BPT_EMP_Employee_2_Skill();
                        empOffice.Employee_RefID = Employer.CMN_BPT_EMP_EmployeeID;
                        empOffice.Skill_RefID = skill.CMN_STR_SkillID;
                        empOffice.AssignmentID = Guid.NewGuid();
                        empOffice.Tenant_RefID = securityTicket.TenantID;
                        empOffice.Save(Connection, Transaction);

                    }
                }

                // ********saving proffesion*****************

                foreach (var profession in Parameter.StaffProfession)
                {
                    var queryProffestion = new ORM_CMN_STR_Profession.Query();
                    queryProffestion.CMN_STR_ProfessionID = profession.CMN_STR_ProfessionID;
                    queryProffestion.IsDeleted = false;
                    queryProffestion.Tenant_RefID = securityTicket.TenantID;

                    ORM_CMN_STR_Profession stafType = ORM_CMN_STR_Profession.Query.Search(Connection, Transaction, queryProffestion).Single();

                    ORM_CMN_BPT_EMP_Employee_2_Profession empProff = new ORM_CMN_BPT_EMP_Employee_2_Profession();
                    empProff.Employee_RefID = Employer.CMN_BPT_EMP_EmployeeID;
                    empProff.Profession_RefID = profession.CMN_STR_ProfessionID;
                    empProff.IsPrimary = profession.IsPrimary;
                    empProff.AssignmentID = Guid.NewGuid();
                    empProff.Tenant_RefID = securityTicket.TenantID;
                    empProff.Save(Connection, Transaction);
                }
                //*******************Save languages to doctor************************

                if (Parameter.Languages != null && Parameter.Languages.Count() != 0)
                {
                    foreach (var language in Parameter.Languages)
                    {
                        ORM_CMN_BPT_BusinessParticipant_SpokenLanguage bpLanguage = new ORM_CMN_BPT_BusinessParticipant_SpokenLanguage();
                        bpLanguage.CMN_BPT_BusinessParticipant_RefID = Doctor.CMN_BPT_BusinessParticipantID;
                        bpLanguage.CMN_BPT_BusinessParticipant_SpokenLanguageID = Guid.NewGuid();
                        bpLanguage.CMN_Language_RefID = language.CMN_Language_RefID;
                        bpLanguage.IsDeleted = false;
                        bpLanguage.Tenant_RefID = securityTicket.TenantID;
                        bpLanguage.Save(Connection, Transaction);
                    }
                }

                personInfo.Save(Connection, Transaction);
                Doctor.Save(Connection, Transaction);
                Employer.Save(Connection, Transaction);


                //********saving business participant excluded availability type*****************


                if (!Parameter.IsWebBookingAvailable)
                {
                    ORM_CMN_BPT_BusinessParticipant_ExcludedAvailabilityType businessParticipanrExcludedAvType = new ORM_CMN_BPT_BusinessParticipant_ExcludedAvailabilityType();
                    businessParticipanrExcludedAvType.CMN_BPT_BusinessParticipant_ExcludedAvailabilityTypeID = Guid.NewGuid();
                    businessParticipanrExcludedAvType.CMN_BPT_BusinessParticipant_RefID = Doctor.CMN_BPT_BusinessParticipantID;
                    businessParticipanrExcludedAvType.Creation_Timestamp = DateTime.Now;
                    businessParticipanrExcludedAvType.Tenant_RefID = securityTicket.TenantID;

                    var availabilityTypeQuery = new ORM_CMN_CAL_AVA_Availability_Type.Query();
                    availabilityTypeQuery.IsDeleted = false;
                    availabilityTypeQuery.Tenant_RefID = securityTicket.TenantID;
                    availabilityTypeQuery.GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(AvailabilityType.WebBooking);

                    var availabilityType = ORM_CMN_CAL_AVA_Availability_Type.Query.Search(Connection, Transaction, availabilityTypeQuery).First();
                    businessParticipanrExcludedAvType.Excluded_Availability_Type_RefID = availabilityType.CMN_CAL_AVA_Availability_TypeID;

                    businessParticipanrExcludedAvType.Save(Connection, Transaction);
                }


            }
            #endregion
            #region Delete
            else if (Parameter.IsDeleted)
            {
                var bpt = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, new ORM_CMN_BPT_BusinessParticipant.Query { CMN_BPT_BusinessParticipantID = Parameter.CMN_BPT_BusinessParticipantID, IsDeleted = false, Tenant_RefID = securityTicket.TenantID }).FirstOrDefault();
                var perInfo = ORM_CMN_PER_PersonInfo.Query.Search(Connection, Transaction, new ORM_CMN_PER_PersonInfo.Query { CMN_PER_PersonInfoID = bpt.IfNaturalPerson_CMN_PER_PersonInfo_RefID, IsDeleted = false, Tenant_RefID = securityTicket.TenantID }).FirstOrDefault();
                var emp = ORM_CMN_BPT_EMP_Employee.Query.Search(Connection, Transaction, new ORM_CMN_BPT_EMP_Employee.Query { BusinessParticipant_RefID = Parameter.CMN_BPT_BusinessParticipantID, IsDeleted = false, Tenant_RefID = securityTicket.TenantID }).FirstOrDefault();
                var phone = ORM_CMN_PER_CommunicationContact.Query.Search(Connection, Transaction, new ORM_CMN_PER_CommunicationContact.Query { PersonInfo_RefID = perInfo.CMN_PER_PersonInfoID, Contact_Type = TelephoneCompanyType.CMN_PER_CommunicationContact_TypeID, IsDeleted = false, Tenant_RefID = securityTicket.TenantID }).FirstOrDefault();

                if (Parameter.Account_RefID != Guid.Empty)
                {
                    ORM_CMN_PER_PersonInfo_2_Account personInfo2Account = ORM_CMN_PER_PersonInfo_2_Account.Query.Search(Connection, Transaction, new ORM_CMN_PER_PersonInfo_2_Account.Query
                    {
                        USR_Account_RefID = Parameter.Account_RefID,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).FirstOrDefault();

                    if (personInfo2Account != null)
                    {
                        personInfo2Account.IsDeleted = true;
                        personInfo2Account.Save(Connection, Transaction);
                    }
                }

                if (phone == null)
                {
                    phone = new ORM_CMN_PER_CommunicationContact();
                    phone.Content = "";
                }
                var mobile = ORM_CMN_PER_CommunicationContact.Query.Search(Connection, Transaction, new ORM_CMN_PER_CommunicationContact.Query { PersonInfo_RefID = perInfo.CMN_PER_PersonInfoID, Contact_Type = MobileCompanyType.CMN_PER_CommunicationContact_TypeID, IsDeleted = false, Tenant_RefID = securityTicket.TenantID }).FirstOrDefault();
                if (mobile == null)
                {
                    mobile = new ORM_CMN_PER_CommunicationContact();
                    mobile.Content = "";
                }
                var email = ORM_CMN_PER_CommunicationContact.Query.Search(Connection, Transaction, new ORM_CMN_PER_CommunicationContact.Query { PersonInfo_RefID = perInfo.CMN_PER_PersonInfoID, Contact_Type = EmailType.CMN_PER_CommunicationContact_TypeID, IsDeleted = false, Tenant_RefID = securityTicket.TenantID }).FirstOrDefault();
                if (email == null)
                {
                    email = new ORM_CMN_PER_CommunicationContact();
                    email.Content = "";
                }

                var orgUnits = ORM_CMN_BPT_EMP_Employee_2_Office.Query.Search(Connection, Transaction, new ORM_CMN_BPT_EMP_Employee_2_Office.Query { CMN_BPT_EMP_Employee_RefID = emp.CMN_BPT_EMP_EmployeeID, IsDeleted = false, Tenant_RefID = securityTicket.TenantID });
                var skills = ORM_CMN_BPT_EMP_Employee_2_Skill.Query.Search(Connection, Transaction, new ORM_CMN_BPT_EMP_Employee_2_Skill.Query { Employee_RefID = emp.CMN_BPT_EMP_EmployeeID, IsDeleted = false, Tenant_RefID = securityTicket.TenantID });
                var proffestion = ORM_CMN_BPT_EMP_Employee_2_Profession.Query.Search(Connection, Transaction, new ORM_CMN_BPT_EMP_Employee_2_Profession.Query { Employee_RefID = emp.CMN_BPT_EMP_EmployeeID, IsDeleted = false, Tenant_RefID = securityTicket.TenantID }).FirstOrDefault();
                ORM_CMN_BPT_BusinessParticipant_SpokenLanguage.Query.SoftDelete(Connection, Transaction, new ORM_CMN_BPT_BusinessParticipant_SpokenLanguage.Query { CMN_BPT_BusinessParticipant_RefID = emp.BusinessParticipant_RefID, IsDeleted = false, Tenant_RefID = securityTicket.TenantID });

                if (Parameter.DoctorIDNumber != "")
                {
                    var docType = ORM_HEC_Doctor.Query.Search(Connection, Transaction, new ORM_HEC_Doctor.Query { BusinessParticipant_RefID = bpt.CMN_BPT_BusinessParticipantID, IsDeleted = false, Tenant_RefID = securityTicket.TenantID }).FirstOrDefault();
                    if (docType != null)
                    {
                        docType.IsDeleted = true;
                        docType.Save(Connection, Transaction);
                    }
                }

                //*******************delete units************************
                if (orgUnits != null && orgUnits.Count() != 0)
                {

                    foreach (var unit in orgUnits)
                    {
                        unit.IsDeleted = true;
                        unit.Save(Connection, Transaction);
                    }
                }

                //*******************delete skills to doctor connection************************
                if (skills != null && skills.Count() != 0)
                {

                    foreach (var skill in skills)
                    {
                        skill.IsDeleted = true;
                        skill.Save(Connection, Transaction);
                    }
                }
                perInfo.IsDeleted = true;
                emp.IsDeleted = true;
                bpt.IsDeleted = true;
                phone.IsDeleted = true;
                mobile.IsDeleted = true;
                email.IsDeleted = true;
                proffestion.IsDeleted = true;


                proffestion.Save(Connection, Transaction);
                phone.Save(Connection, Transaction);
                mobile.Save(Connection, Transaction);
                email.Save(Connection, Transaction);
                perInfo.Save(Connection, Transaction);
                emp.Save(Connection, Transaction);
                bpt.Save(Connection, Transaction);


            }
            #endregion
            #region Edit
            else
            {
                var Doctor = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, new ORM_CMN_BPT_BusinessParticipant.Query { CMN_BPT_BusinessParticipantID = Parameter.CMN_BPT_BusinessParticipantID, IsDeleted = false, Tenant_RefID = securityTicket.TenantID }).FirstOrDefault();
                var personInfo = ORM_CMN_PER_PersonInfo.Query.Search(Connection, Transaction, new ORM_CMN_PER_PersonInfo.Query { CMN_PER_PersonInfoID = Doctor.IfNaturalPerson_CMN_PER_PersonInfo_RefID, IsDeleted = false, Tenant_RefID = securityTicket.TenantID }).FirstOrDefault();
                var emp = ORM_CMN_BPT_EMP_Employee.Query.Search(Connection, Transaction, new ORM_CMN_BPT_EMP_Employee.Query { BusinessParticipant_RefID = Parameter.CMN_BPT_BusinessParticipantID, IsDeleted = false, Tenant_RefID = securityTicket.TenantID }).FirstOrDefault();
                var phone = ORM_CMN_PER_CommunicationContact.Query.Search(Connection, Transaction, new ORM_CMN_PER_CommunicationContact.Query { PersonInfo_RefID = personInfo.CMN_PER_PersonInfoID, Contact_Type = TelephoneCompanyType.CMN_PER_CommunicationContact_TypeID, IsDeleted = false, Tenant_RefID = securityTicket.TenantID }).FirstOrDefault();
                if (phone == null)
                {
                    phone = new ORM_CMN_PER_CommunicationContact();
                    phone.Content = "";
                }
                var mobile = ORM_CMN_PER_CommunicationContact.Query.Search(Connection, Transaction, new ORM_CMN_PER_CommunicationContact.Query { PersonInfo_RefID = personInfo.CMN_PER_PersonInfoID, Contact_Type = MobileCompanyType.CMN_PER_CommunicationContact_TypeID, IsDeleted = false, Tenant_RefID = securityTicket.TenantID }).FirstOrDefault();
                if (mobile == null)
                {
                    mobile = new ORM_CMN_PER_CommunicationContact();
                    mobile.Content = "";
                }
                var email = ORM_CMN_PER_CommunicationContact.Query.Search(Connection, Transaction, new ORM_CMN_PER_CommunicationContact.Query { PersonInfo_RefID = personInfo.CMN_PER_PersonInfoID, Contact_Type = EmailType.CMN_PER_CommunicationContact_TypeID, IsDeleted = false, Tenant_RefID = securityTicket.TenantID }).FirstOrDefault();
                if (email == null)
                {
                    email = new ORM_CMN_PER_CommunicationContact();
                    email.Content = "";
                }

                var docType = ORM_HEC_Doctor.Query.Search(Connection, Transaction, new ORM_HEC_Doctor.Query { BusinessParticipant_RefID = Doctor.CMN_BPT_BusinessParticipantID, IsDeleted = false, Tenant_RefID = securityTicket.TenantID }).FirstOrDefault();
                Guid doctorId = Guid.Empty;

                //*******************Get information from account************************
                if (docType.Account_RefID == Guid.Empty && Parameter.Account_RefID != Guid.Empty)
                {
                    personInfo.IsDeleted = true;
                    personInfo.Save(Connection, Transaction);

                    ORM_CMN_PER_PersonInfo_2_Account personInfo2Account = ORM_CMN_PER_PersonInfo_2_Account.Query.Search(Connection, Transaction, new ORM_CMN_PER_PersonInfo_2_Account.Query
                    {
                        USR_Account_RefID = Parameter.Account_RefID,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).Single();

                    personInfo = ORM_CMN_PER_PersonInfo.Query.Search(Connection, Transaction, new ORM_CMN_PER_PersonInfo.Query
                    {
                        CMN_PER_PersonInfoID = personInfo2Account.CMN_PER_PersonInfo_RefID,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).Single();

                    ORM_CMN_Account_ApplicationSubscription accountApplicationSubscription = new ORM_CMN_Account_ApplicationSubscription();
                    accountApplicationSubscription.CMN_Account_ApplicationSubscriptionID = Guid.NewGuid();
                    accountApplicationSubscription.Account_RefID = Parameter.Account_RefID;
                    accountApplicationSubscription.Application_RefID = Parameter.ApplicationID;
                    accountApplicationSubscription.IsDisabled = false;
                    accountApplicationSubscription.UpdatedOn = DateTime.Now;
                    accountApplicationSubscription.Tenant_RefID = securityTicket.TenantID;
                    accountApplicationSubscription.Save(Connection, Transaction);
                }
                else if (docType.Account_RefID != Guid.Empty)
                {
                    ORM_CMN_Account_ApplicationSubscription accountApplicationSubscription = ORM_CMN_Account_ApplicationSubscription.Query.Search(Connection, Transaction, new ORM_CMN_Account_ApplicationSubscription.Query
                    {
                        Account_RefID = Parameter.Account_RefID,
                        Application_RefID = Parameter.ApplicationID,
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID
                    }).Single();

                    accountApplicationSubscription.IsDisabled = Parameter.AccountRevoke;
                    accountApplicationSubscription.Save(Connection, Transaction);
                }
                //*******************************************

                if (Parameter.DoctorIDNumber != "")
                {
                    if (docType == null)
                    {
                        var DoctorType = new ORM_HEC_Doctor();
                        DoctorType.DoctorIDNumber = Parameter.DoctorIDNumber;
                        DoctorType.HEC_DoctorID = Guid.NewGuid();
                        DoctorType.BusinessParticipant_RefID = Doctor.CMN_BPT_BusinessParticipantID;
                        DoctorType.Tenant_RefID = securityTicket.TenantID;
                        DoctorType.IsTreatingChildren = Parameter.IsTreatingChildren;
                        DoctorType.Account_RefID = Parameter.Account_RefID;
                        DoctorType.Save(Connection, Transaction);
                        doctorId = DoctorType.HEC_DoctorID;
                    }
                    else
                    {
                        docType.DoctorIDNumber = Parameter.DoctorIDNumber;
                        docType.Account_RefID = Parameter.Account_RefID;
                        docType.Save(Connection, Transaction);
                        doctorId = docType.HEC_DoctorID;
                    }

                    //*******************Save Appointment types************************ 

                    var doctorAssignableAppointmentType = new ORM_HEC_Doctor_AssignableAppointmentType.Query()
                    {
                        Tenant_RefID = securityTicket.TenantID,
                        Doctor_RefID = doctorId,
                        IsDeleted = false
                    };

                    var doctorAssignableAppointmentTypeQuery = ORM_HEC_Doctor_AssignableAppointmentType.Query.Search(Connection, Transaction, doctorAssignableAppointmentType);

                    foreach (var item in Parameter.AppTypes)
                    {
                        ORM_HEC_Doctor_AssignableAppointmentType assignableAppType = null;
                        foreach (var doctorAssignableAppointmentTypeItem in doctorAssignableAppointmentTypeQuery)
                        {
                            if (doctorAssignableAppointmentTypeItem.TaskTemplate_RefID == item.PPS_TSK_Task_TemplateID && doctorAssignableAppointmentTypeItem.Doctor_RefID == docType.HEC_DoctorID)
                            {
                                assignableAppType = doctorAssignableAppointmentTypeItem;
                                break;
                            }
                        }
                        if (assignableAppType == null)
                        {
                            var doctorAssignableType = new ORM_HEC_Doctor_AssignableAppointmentType();
                            doctorAssignableType.HEC_Doctor_AssignableAppointmentTypeID = Guid.NewGuid();
                            doctorAssignableType.TaskTemplate_RefID = item.PPS_TSK_Task_TemplateID;
                            doctorAssignableType.IsDeleted = item.IsDeleted;
                            if (docType == null)
                                doctorAssignableType.Doctor_RefID = doctorId;
                            else
                                doctorAssignableType.Doctor_RefID = docType.HEC_DoctorID;

                            doctorAssignableType.Tenant_RefID = securityTicket.TenantID;
                            doctorAssignableType.Save(Connection, Transaction);
                        }
                        else
                        {
                            assignableAppType.TaskTemplate_RefID = item.PPS_TSK_Task_TemplateID;
                            assignableAppType.IsDeleted = item.IsDeleted;
                            assignableAppType.Save(Connection, Transaction);
                        }
                    }

                }
                else
                {
                    if (docType != null)
                    {
                        docType.IsDeleted = true;
                        docType.Save(Connection, Transaction);
                    }
                }


                emp.Staff_Number = Parameter.Staff_Number;
                personInfo.FirstName = Parameter.First_Name;
                personInfo.Gender = Parameter.Gender;
                personInfo.Initials = Parameter.Initals;
                personInfo.LastName = Parameter.Last_Name;
                personInfo.Title = Parameter.Title;
                phone.Content = Parameter.Contact_Telephone;
                phone.PersonInfo_RefID = personInfo.CMN_PER_PersonInfoID;
                mobile.Content = Parameter.Mobile_Phone;
                mobile.PersonInfo_RefID = personInfo.CMN_PER_PersonInfoID;
                email.Content = Parameter.Contact_Email;
                email.PersonInfo_RefID = personInfo.CMN_PER_PersonInfoID;
                Doctor.DisplayImage_RefID = Parameter.DisplayImage_Document_RefID;
                Doctor.DisplayName = Parameter.First_Name + " " + Parameter.Last_Name;
                Doctor.IfNaturalPerson_CMN_PER_PersonInfo_RefID = personInfo.CMN_PER_PersonInfoID;
                #region organisational units

                if (Parameter.OrgUnits != null || Parameter.OrgUnits.Count() != 0)
                {

                    foreach (var unit in Parameter.OrgUnits)
                    {

                        var query = new ORM_CMN_STR_Office.Query();
                        query.CMN_STR_OfficeID = unit.CMN_STR_Office_RefID;
                        query.IsDeleted = false;
                        query.Tenant_RefID = securityTicket.TenantID;

                        ORM_CMN_STR_Office office = ORM_CMN_STR_Office.Query.Search(Connection, Transaction, query).Single();
                        var oficeToDoctor = ORM_CMN_BPT_EMP_Employee_2_Office.Query.Search(Connection, Transaction, new ORM_CMN_BPT_EMP_Employee_2_Office.Query { CMN_STR_Office_RefID = unit.CMN_STR_Office_RefID, CMN_BPT_EMP_Employee_RefID = emp.CMN_BPT_EMP_EmployeeID, IsDeleted = false, Tenant_RefID = securityTicket.TenantID }).FirstOrDefault();
                        if (oficeToDoctor == null)
                        {
                            ORM_CMN_BPT_EMP_Employee_2_Office empOffice = new ORM_CMN_BPT_EMP_Employee_2_Office();
                            empOffice.CMN_BPT_EMP_Employee_RefID = emp.CMN_BPT_EMP_EmployeeID;
                            empOffice.CMN_STR_Office_RefID = office.CMN_STR_OfficeID;
                            empOffice.AssignmentID = Guid.NewGuid();
                            empOffice.Tenant_RefID = securityTicket.TenantID;
                            empOffice.Save(Connection, Transaction);
                        }
                    }

                    // deleting office to employee that were deleted during edit

                    List<ORM_CMN_BPT_EMP_Employee_2_Office> oficeToDoctorList = ORM_CMN_BPT_EMP_Employee_2_Office.Query.Search(Connection, Transaction, new ORM_CMN_BPT_EMP_Employee_2_Office.Query { CMN_BPT_EMP_Employee_RefID = emp.CMN_BPT_EMP_EmployeeID, IsDeleted = false, Tenant_RefID = securityTicket.TenantID });
                    foreach (var oficeToDoctor in oficeToDoctorList)
                    {
                        if (Parameter.OrgUnits.FirstOrDefault(x => x.CMN_STR_Office_RefID == oficeToDoctor.CMN_STR_Office_RefID) == null)
                        {
                            oficeToDoctor.IsDeleted = true;
                            oficeToDoctor.Save(Connection, Transaction);

                            //delete time table assignemnts
                            var assignms = ORM_CMN_BPT_BusinessParticipant_Availability.Query.Search(Connection, Transaction, new ORM_CMN_BPT_BusinessParticipant_Availability.Query()
                            {
                                Tenant_RefID = securityTicket.TenantID,
                                IsDeleted = false,
                                BusinessParticipant_RefID = emp.BusinessParticipant_RefID
                            }).ToArray();

                            foreach (var assignm in assignms)
                            {
                                var count = ORM_CMN_CAL_AVA_Availability.Query.Search(Connection, Transaction, new ORM_CMN_CAL_AVA_Availability.Query()
                                {
                                    Tenant_RefID = securityTicket.TenantID,
                                    IsDeleted = false,
                                    CMN_CAL_AVA_AvailabilityID = assignm.CMN_CAL_AVA_Availability_RefID,
                                    Office_RefID = oficeToDoctor.CMN_STR_Office_RefID
                                }).Count;

                                if (count > 0)
                                {
                                    assignm.IsDeleted = true;
                                    assignm.Save(Connection, Transaction);
                                }
                            }
                        }
                    }

                }
                else
                {
                    List<ORM_CMN_BPT_EMP_Employee_2_Office> oficeToDoctorList = ORM_CMN_BPT_EMP_Employee_2_Office.Query.Search(Connection, Transaction, new ORM_CMN_BPT_EMP_Employee_2_Office.Query { CMN_BPT_EMP_Employee_RefID = emp.CMN_BPT_EMP_EmployeeID, IsDeleted = false, Tenant_RefID = securityTicket.TenantID });
                    if (oficeToDoctorList != null || oficeToDoctorList.Count() != 0)
                    {
                        foreach (var unit in oficeToDoctorList)
                        {
                            unit.IsDeleted = true;
                            unit.Save(Connection, Transaction);

                            //delete time table assignemnts
                            var assignms = ORM_CMN_BPT_BusinessParticipant_Availability.Query.Search(Connection, Transaction, new ORM_CMN_BPT_BusinessParticipant_Availability.Query()
                            {
                                Tenant_RefID = securityTicket.TenantID,
                                IsDeleted = false,
                                BusinessParticipant_RefID = emp.BusinessParticipant_RefID
                            }).ToArray();

                            foreach (var assignm in assignms)
                            {
                                var count = ORM_CMN_CAL_AVA_Availability.Query.Search(Connection, Transaction, new ORM_CMN_CAL_AVA_Availability.Query()
                                {
                                    Tenant_RefID = securityTicket.TenantID,
                                    IsDeleted = false,
                                    CMN_CAL_AVA_AvailabilityID = assignm.CMN_CAL_AVA_Availability_RefID,
                                    Office_RefID = unit.CMN_STR_Office_RefID
                                }).Count;

                                if (count > 0)
                                {
                                    assignm.IsDeleted = true;
                                    assignm.Save(Connection, Transaction);
                                }
                            }
                        }
                    }
                }

                var availabilityTypeQuery = new ORM_CMN_CAL_AVA_Availability_Type.Query();
                availabilityTypeQuery.IsDeleted = false;
                availabilityTypeQuery.Tenant_RefID = securityTicket.TenantID;
                availabilityTypeQuery.GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(AvailabilityType.WebBooking);

                var availabilityType = ORM_CMN_CAL_AVA_Availability_Type.Query.Search(Connection, Transaction, availabilityTypeQuery).First();

                var businessParticipantExcludedAvTypeQuery = new ORM_CMN_BPT_BusinessParticipant_ExcludedAvailabilityType.Query();
                businessParticipantExcludedAvTypeQuery.IsDeleted = false;
                businessParticipantExcludedAvTypeQuery.Tenant_RefID = securityTicket.TenantID;
                businessParticipantExcludedAvTypeQuery.CMN_BPT_BusinessParticipant_RefID = Doctor.CMN_BPT_BusinessParticipantID;
                businessParticipantExcludedAvTypeQuery.Excluded_Availability_Type_RefID = availabilityType.CMN_CAL_AVA_Availability_TypeID;

                var businessPartExAvType = ORM_CMN_BPT_BusinessParticipant_ExcludedAvailabilityType.Query.Search(Connection, Transaction, businessParticipantExcludedAvTypeQuery).FirstOrDefault();

                if (Parameter.IsWebBookingAvailable)
                {

                    if (businessPartExAvType != null)
                    {
                        businessPartExAvType.IsDeleted = true;
                        businessPartExAvType.Save(Connection, Transaction);
                    }

                }
                else
                {
                    if (businessPartExAvType == null)
                    {
                        ORM_CMN_BPT_BusinessParticipant_ExcludedAvailabilityType bpeat = new ORM_CMN_BPT_BusinessParticipant_ExcludedAvailabilityType();
                        bpeat.CMN_BPT_BusinessParticipant_ExcludedAvailabilityTypeID = Guid.NewGuid();
                        bpeat.CMN_BPT_BusinessParticipant_RefID = Doctor.CMN_BPT_BusinessParticipantID;
                        bpeat.Creation_Timestamp = DateTime.Now;
                        bpeat.Tenant_RefID = securityTicket.TenantID;

                        var avTypeQuery = new ORM_CMN_CAL_AVA_Availability_Type.Query();
                        avTypeQuery.IsDeleted = false;
                        avTypeQuery.Tenant_RefID = securityTicket.TenantID;
                        avTypeQuery.GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(AvailabilityType.WebBooking);

                        var at = ORM_CMN_CAL_AVA_Availability_Type.Query.Search(Connection, Transaction, avTypeQuery).First();
                        bpeat.Excluded_Availability_Type_RefID = at.CMN_CAL_AVA_Availability_TypeID;

                        bpeat.Save(Connection, Transaction);
                    }
                }


                #endregion




                #region skills

                if (Parameter.Skills == null || Parameter.Skills.Count() == 0)
                {
                    P_L5DO_SDaS_1604_Skills Skills = new P_L5DO_SDaS_1604_Skills();
                    Skills.CMN_STR_SkillID = Guid.Empty;
                }
                else if (Parameter.Skills != null || Parameter.Skills.Count() != 0)
                {

                    foreach (var skill in Parameter.Skills)
                    {

                        var query = new ORM_CMN_STR_Skill.Query();
                        query.CMN_STR_SkillID = skill.CMN_STR_SkillID;
                        query.IsDeleted = false;
                        query.Tenant_RefID = securityTicket.TenantID;

                        ORM_CMN_STR_Skill skilll = ORM_CMN_STR_Skill.Query.Search(Connection, Transaction, query).Single();
                        var skillToDoctora = ORM_CMN_BPT_EMP_Employee_2_Skill.Query.Search(Connection, Transaction, new ORM_CMN_BPT_EMP_Employee_2_Skill.Query { Skill_RefID = skill.CMN_STR_SkillID, Employee_RefID = emp.CMN_BPT_EMP_EmployeeID, IsDeleted = false, Tenant_RefID = securityTicket.TenantID }).FirstOrDefault();
                        if (skillToDoctora == null)
                        {
                            ORM_CMN_BPT_EMP_Employee_2_Skill empOffice = new ORM_CMN_BPT_EMP_Employee_2_Skill();
                            empOffice.Employee_RefID = emp.CMN_BPT_EMP_EmployeeID;
                            empOffice.Skill_RefID = skilll.CMN_STR_SkillID;
                            empOffice.AssignmentID = Guid.NewGuid();
                            empOffice.Tenant_RefID = securityTicket.TenantID;
                            empOffice.Save(Connection, Transaction);
                        }
                    }

                    // deleting office to employee that were deleted during edit

                    List<ORM_CMN_BPT_EMP_Employee_2_Skill> skillsToDoctorList = ORM_CMN_BPT_EMP_Employee_2_Skill.Query.Search(Connection, Transaction, new ORM_CMN_BPT_EMP_Employee_2_Skill.Query { Employee_RefID = emp.CMN_BPT_EMP_EmployeeID, IsDeleted = false, Tenant_RefID = securityTicket.TenantID });
                    foreach (var skillToDoctor in skillsToDoctorList)
                    {
                        if (Parameter.Skills.FirstOrDefault(x => x.CMN_STR_SkillID == skillToDoctor.Skill_RefID) == null)
                        {
                            skillToDoctor.IsDeleted = true;
                            skillToDoctor.Save(Connection, Transaction);
                        }
                    }

                }
                else
                {
                    List<ORM_CMN_BPT_EMP_Employee_2_Skill> skillsToDoctorList = ORM_CMN_BPT_EMP_Employee_2_Skill.Query.Search(Connection, Transaction, new ORM_CMN_BPT_EMP_Employee_2_Skill.Query { Employee_RefID = emp.CMN_BPT_EMP_EmployeeID, IsDeleted = false, Tenant_RefID = securityTicket.TenantID });
                    if (skillsToDoctorList != null || skillsToDoctorList.Count() != 0)
                    {
                        foreach (var skil in skillsToDoctorList)
                        {
                            skil.IsDeleted = true;
                            skil.Save(Connection, Transaction);
                        }
                    }
                }

                #endregion

                #region languages

                if (Parameter.Languages == null || Parameter.Languages.Count() == 0)
                {
                    P_L5DO_SDaS_1604_Languages Languages = new P_L5DO_SDaS_1604_Languages();
                    Languages.CMN_Language_RefID = Guid.Empty;
                }
                else if (Parameter.Languages != null || Parameter.Languages.Count() != 0)
                {

                    foreach (var language in Parameter.Languages)
                    {
                        var languageToDoctor = ORM_CMN_BPT_BusinessParticipant_SpokenLanguage.Query.Search(Connection, Transaction, new ORM_CMN_BPT_BusinessParticipant_SpokenLanguage.Query { CMN_Language_RefID = language.CMN_Language_RefID, CMN_BPT_BusinessParticipant_RefID = Doctor.CMN_BPT_BusinessParticipantID, IsDeleted = false, Tenant_RefID = securityTicket.TenantID }).FirstOrDefault();
                        if (languageToDoctor == null)
                        {
                            ORM_CMN_BPT_BusinessParticipant_SpokenLanguage bpLanguage = new ORM_CMN_BPT_BusinessParticipant_SpokenLanguage();
                            bpLanguage.CMN_BPT_BusinessParticipant_RefID = Doctor.CMN_BPT_BusinessParticipantID;
                            bpLanguage.CMN_BPT_BusinessParticipant_SpokenLanguageID = Guid.NewGuid();
                            bpLanguage.CMN_Language_RefID = language.CMN_Language_RefID;
                            bpLanguage.IsDeleted = false;
                            bpLanguage.Tenant_RefID = securityTicket.TenantID;
                            bpLanguage.Save(Connection, Transaction);
                        }
                    }

                    // deleting languages to employee that were deleted during edit

                    List<ORM_CMN_BPT_BusinessParticipant_SpokenLanguage> languageToDoctorList = ORM_CMN_BPT_BusinessParticipant_SpokenLanguage.Query.Search(Connection, Transaction, new ORM_CMN_BPT_BusinessParticipant_SpokenLanguage.Query { CMN_BPT_BusinessParticipant_RefID = Doctor.CMN_BPT_BusinessParticipantID, IsDeleted = false, Tenant_RefID = securityTicket.TenantID });
                    foreach (var languageToDoctor in languageToDoctorList)
                    {
                        if (Parameter.Languages.FirstOrDefault(x => x.CMN_Language_RefID == languageToDoctor.CMN_Language_RefID) == null)
                        {
                            languageToDoctor.IsDeleted = true;
                            languageToDoctor.Save(Connection, Transaction);
                        }
                    }

                }
                else
                {
                    List<ORM_CMN_BPT_BusinessParticipant_SpokenLanguage> languageToDoctorList = ORM_CMN_BPT_BusinessParticipant_SpokenLanguage.Query.Search(Connection, Transaction, new ORM_CMN_BPT_BusinessParticipant_SpokenLanguage.Query { CMN_BPT_BusinessParticipant_RefID = Doctor.CMN_BPT_BusinessParticipantID, IsDeleted = false, Tenant_RefID = securityTicket.TenantID });
                    if (languageToDoctorList != null || languageToDoctorList.Count() != 0)
                    {
                        foreach (var language in languageToDoctorList)
                        {
                            language.IsDeleted = true;
                            language.Save(Connection, Transaction);
                        }
                    }
                }

                #endregion

                #region proffesion

                var employeeToProfessionQuery = new ORM_CMN_BPT_EMP_Employee_2_Profession.Query();
                employeeToProfessionQuery.IsDeleted = false;
                employeeToProfessionQuery.Tenant_RefID = securityTicket.TenantID;
                employeeToProfessionQuery.Employee_RefID = emp.CMN_BPT_EMP_EmployeeID;

                var employeeToProfession = ORM_CMN_BPT_EMP_Employee_2_Profession.Query.Search(Connection, Transaction, employeeToProfessionQuery).ToList();

                foreach (var item in employeeToProfession)
                {
                    item.IsDeleted = true;
                    item.Save(Connection, Transaction);
                }

                foreach (var profession in Parameter.StaffProfession)
                {
                    var queryProffestion = new ORM_CMN_STR_Profession.Query();
                    queryProffestion.CMN_STR_ProfessionID = profession.CMN_STR_ProfessionID;
                    queryProffestion.IsDeleted = false;
                    queryProffestion.Tenant_RefID = securityTicket.TenantID;

                    ORM_CMN_STR_Profession stafType = ORM_CMN_STR_Profession.Query.Search(Connection, Transaction, queryProffestion).Single();

                    ORM_CMN_BPT_EMP_Employee_2_Profession empProff = new ORM_CMN_BPT_EMP_Employee_2_Profession();
                    empProff.Employee_RefID = emp.CMN_BPT_EMP_EmployeeID;
                    empProff.Profession_RefID = profession.CMN_STR_ProfessionID;
                    empProff.IsPrimary = profession.IsPrimary;
                    empProff.AssignmentID = Guid.NewGuid();
                    empProff.Tenant_RefID = securityTicket.TenantID;
                    empProff.Save(Connection, Transaction);
                }

                #endregion
                Doctor.Save(Connection, Transaction);
                emp.Save(Connection, Transaction);
                phone.Save(Connection, Transaction);
                mobile.Save(Connection, Transaction);
                email.Save(Connection, Transaction);
                personInfo.Save(Connection, Transaction);


            }
            #endregion
            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5DO_SDaS_1604 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5DO_SDaS_1604 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5DO_SDaS_1604 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5DO_SDaS_1604 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Doctors_and_Staff",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5DO_SDaS_1604 for attribute P_L5DO_SDaS_1604
		[DataContract]
		public class P_L5DO_SDaS_1604 
		{
			[DataMember]
			public P_L5DO_SDaS_1604_OrgUnits[] OrgUnits { get; set; }
			[DataMember]
			public P_L5DO_SDaS_1604_StaffProfession[] StaffProfession { get; set; }
			[DataMember]
			public P_L5DO_SDaS_1604_Skills[] Skills { get; set; }
			[DataMember]
			public P_L5DO_SDaS_1604_Languages[] Languages { get; set; }
			[DataMember]
			public P_L5DO_SDaS_1604_AppTypes[] AppTypes { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid CMN_BPT_BusinessParticipantID { get; set; } 
			[DataMember]
			public String First_Name { get; set; } 
			[DataMember]
			public String Initals { get; set; } 
			[DataMember]
			public String Last_Name { get; set; } 
			[DataMember]
			public String Contact_Email { get; set; } 
			[DataMember]
			public String Staff_Number { get; set; } 
			[DataMember]
			public String Title { get; set; } 
			[DataMember]
			public String Contact_Telephone { get; set; } 
			[DataMember]
			public String Mobile_Phone { get; set; } 
			[DataMember]
			public int Gender { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 
			[DataMember]
			public Guid StaffType { get; set; } 
			[DataMember]
			public String DoctorIDNumber { get; set; } 
			[DataMember]
			public Boolean IsWebBookingAvailable { get; set; } 
			[DataMember]
			public Boolean IsTreatingChildren { get; set; } 
			[DataMember]
			public Guid DisplayImage_Document_RefID { get; set; } 
			[DataMember]
			public Guid Account_RefID { get; set; } 
			[DataMember]
			public bool AccountRevoke { get; set; } 
			[DataMember]
			public Guid ApplicationID { get; set; } 

		}
		#endregion
		#region SClass P_L5DO_SDaS_1604_OrgUnits for attribute OrgUnits
		[DataContract]
		public class P_L5DO_SDaS_1604_OrgUnits 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_STR_Office_RefID { get; set; } 

		}
		#endregion
		#region SClass P_L5DO_SDaS_1604_StaffProfession for attribute StaffProfession
		[DataContract]
		public class P_L5DO_SDaS_1604_StaffProfession 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_STR_ProfessionID { get; set; } 
			[DataMember]
			public Boolean IsPrimary { get; set; } 

		}
		#endregion
		#region SClass P_L5DO_SDaS_1604_Skills for attribute Skills
		[DataContract]
		public class P_L5DO_SDaS_1604_Skills 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_STR_SkillID { get; set; } 

		}
		#endregion
		#region SClass P_L5DO_SDaS_1604_Languages for attribute Languages
		[DataContract]
		public class P_L5DO_SDaS_1604_Languages 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_Language_RefID { get; set; } 

		}
		#endregion
		#region SClass P_L5DO_SDaS_1604_AppTypes for attribute AppTypes
		[DataContract]
		public class P_L5DO_SDaS_1604_AppTypes 
		{
			//Standard type parameters
			[DataMember]
			public Guid PPS_TSK_Task_TemplateID { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Doctors_and_Staff(,P_L5DO_SDaS_1604 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Doctors_and_Staff.Invoke(connectionString,P_L5DO_SDaS_1604 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_DoctorsAndStaff.Atomic.Manipulation.P_L5DO_SDaS_1604();
parameter.OrgUnits = ...;
parameter.StaffProfession = ...;
parameter.Skills = ...;
parameter.Languages = ...;
parameter.AppTypes = ...;

parameter.CMN_BPT_BusinessParticipantID = ...;
parameter.First_Name = ...;
parameter.Initals = ...;
parameter.Last_Name = ...;
parameter.Contact_Email = ...;
parameter.Staff_Number = ...;
parameter.Title = ...;
parameter.Contact_Telephone = ...;
parameter.Mobile_Phone = ...;
parameter.Gender = ...;
parameter.IsDeleted = ...;
parameter.StaffType = ...;
parameter.DoctorIDNumber = ...;
parameter.IsWebBookingAvailable = ...;
parameter.IsTreatingChildren = ...;
parameter.DisplayImage_Document_RefID = ...;
parameter.Account_RefID = ...;
parameter.AccountRevoke = ...;
parameter.ApplicationID = ...;

*/
