using CL1_ACC_BNK;
using CL1_CMN;
using CL1_CMN_BPT;
using CL1_CMN_BPT_CTM;
using CL1_CMN_COM;
using CL1_CMN_CTR;
using CL1_CMN_PER;
using CL1_HEC;
using CL1_HEC_CRT;
using CL1_USR;
using CSV2Core.SessionSecurity;
using DataImporter.DBMethods.Doctor.Atomic.Retrieval;
using DataImporter.DBMethods.ExportData.Atomic.Retrieval;
using DataImporter.Elastic_Methods.Doctor.Retrieval;
using DataImporter.Models;
using MMDocConnectElasticSearchMethods.Doctor.Manipulation;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataImporter.DBMethods.ExportData.Complex.Manipulation
{
    class Save_Doctors
    {
        public static void Save_Doctors_to_DB(Doctor_model_from_xlsx Parameter, string connectionString, SessionSecurityTicket securityTicket)
        {
             DbConnection Connection = null;
            DbTransaction Transaction = null;
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;
            if (cleanupConnection == true)
            {
                Connection = CSV2Core_MySQL.Support.DBSQLSupport.CreateConnection(connectionString);
                Connection.Open();
            }
            if (cleanupTransaction == true)
            {
                Transaction = Connection.BeginTransaction();
            }
            try
            {

            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("de-DE");
            Guid BusinessParticipantID = Guid.NewGuid();
            Guid personInfoID = Guid.NewGuid();
            Guid PracticeCustomerID = Guid.NewGuid();
            Guid PracticeBusinessParticipantID = Guid.NewGuid();
            Guid PracticeCompanyInfoID = Guid.NewGuid();
            String PracticeName = "";
            Guid BankAccountID = Guid.Empty;
            Guid doctor_id = Parameter.DoctorID;
            var isOpPractice = false;

            if (!String.IsNullOrEmpty(Parameter.LoginEmail))
            //uncomment this if you've created account
          //  if (false)
            {
                string[] stringUser = Parameter.LoginEmail.Split('@');
                string usernameStr = stringUser[0];

                try
                {

                    var doctorAccountInfo = ORM_USR_Account.Query.Search(Connection, Transaction, new ORM_USR_Account.Query()
                    {
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID,
                        AccountSignInEmailAddress = Parameter.LoginEmail,
                    }).Single();

                    var accountGroupQuery = new ORM_USR_Account_FunctionLevelRights_Group.Query();
                    accountGroupQuery.Tenant_RefID = securityTicket.TenantID;
                    accountGroupQuery.IsDeleted = false;
                    accountGroupQuery.GlobalPropertyMatchingID = "mm.docconect.doc.app.group";

                    var accountGroup = ORM_USR_Account_FunctionLevelRights_Group.Query.Search(Connection, Transaction, accountGroupQuery).SingleOrDefault();

                    if (accountGroup == null)
                    {
                        accountGroup = new ORM_USR_Account_FunctionLevelRights_Group();
                        accountGroup.Tenant_RefID = securityTicket.TenantID;
                        accountGroup.Label = "mm.docconect.doc.app.group";
                        accountGroup.GlobalPropertyMatchingID = "mm.docconect.doc.app.group";
                        accountGroup.Creation_Timestamp = DateTime.Now;
                        accountGroup.USR_Account_FunctionLevelRights_GroupID = Guid.NewGuid();
                        accountGroup.Save(Connection, Transaction);
                    }

                    var PracticeAccount2UniversalProperty = ORM_HEC_MedicalPractice_2_UniversalProperty.Query.Search(Connection, Transaction, new ORM_HEC_MedicalPractice_2_UniversalProperty.Query()
                    {
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID,
                        HEC_MedicalPractice_RefID = Parameter.PracticeID
                    }).ToList();

                    List<ORM_HEC_MedicalPractice_UniversalProperty> PracticeUniversalPropertyList = new List<ORM_HEC_MedicalPractice_UniversalProperty>();
                    foreach (var item in PracticeAccount2UniversalProperty)
                    {
                        var PracticeUniversalProperty = ORM_HEC_MedicalPractice_UniversalProperty.Query.Search(Connection, Transaction, new ORM_HEC_MedicalPractice_UniversalProperty.Query()
                        {
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID,
                            HEC_MedicalPractice_UniversalPropertyID = item.HEC_MedicalPractice_UniversalProperty_RefID
                        }).Single();
                        PracticeUniversalPropertyList.Add(PracticeUniversalProperty);
                    };

                    P_DO_GPAIDfPID_1522 practiceAccountIDParameter = new P_DO_GPAIDfPID_1522();
                    practiceAccountIDParameter.PracticeID = Parameter.PracticeID;

                    var practiceAccountToFunctionLevelRightQ = new ORM_USR_Account_2_FunctionLevelRight.Query();
                    practiceAccountToFunctionLevelRightQ.Account_RefID = cls_Get_Practice_AccountID_for_PracticeID.Invoke(Connection, Transaction, practiceAccountIDParameter, securityTicket).Result.accountID;
                    practiceAccountToFunctionLevelRightQ.Tenant_RefID = securityTicket.TenantID;
                    practiceAccountToFunctionLevelRightQ.IsDeleted = false;

                    var practiceAccountToFunctionLevelRight = ORM_USR_Account_2_FunctionLevelRight.Query.Search(Connection, Transaction, practiceAccountToFunctionLevelRightQ).SingleOrDefault();

                    if (practiceAccountToFunctionLevelRight != null)
                    {
                        var practiceAccountFunctionLevelRightQ = new ORM_USR_Account_FunctionLevelRight.Query();
                        practiceAccountFunctionLevelRightQ.Tenant_RefID = securityTicket.TenantID;
                        practiceAccountFunctionLevelRightQ.IsDeleted = false;
                        practiceAccountFunctionLevelRightQ.USR_Account_FunctionLevelRightID = practiceAccountToFunctionLevelRight.FunctionLevelRight_RefID;

                        var practiceAccountFunctionLevelRight = ORM_USR_Account_FunctionLevelRight.Query.Search(Connection, Transaction, practiceAccountFunctionLevelRightQ).SingleOrDefault();

                        if (practiceAccountFunctionLevelRight != null)
                        {
                            isOpPractice = practiceAccountFunctionLevelRight.GlobalPropertyMatchingID.Equals("mm.docconect.doc.app.op.practice");
                        }
                    }

                    var functionLevelRightQ = new ORM_USR_Account_FunctionLevelRight.Query();
                    functionLevelRightQ.Tenant_RefID = securityTicket.TenantID;
                    functionLevelRightQ.IsDeleted = false;
                    functionLevelRightQ.GlobalPropertyMatchingID = isOpPractice ? "mm.docconect.doc.app.op.doctor" : "mm.docconect.doc.app.ac.doctor";

                    var existingFunctionLevelRight = ORM_USR_Account_FunctionLevelRight.Query.Search(Connection, Transaction, functionLevelRightQ).SingleOrDefault();

                    var tempFunctionLevelRightID = Guid.Empty;

                    if (existingFunctionLevelRight == null)
                    {
                        ORM_USR_Account_FunctionLevelRight functionLevelRight = new ORM_USR_Account_FunctionLevelRight();
                        functionLevelRight.USR_Account_FunctionLevelRightID = Guid.NewGuid();
                        functionLevelRight.FunctionLevelRights_Group_RefID = accountGroup.USR_Account_FunctionLevelRights_GroupID;
                        functionLevelRight.Tenant_RefID = securityTicket.TenantID;
                        functionLevelRight.Creation_Timestamp = DateTime.Now;

                        functionLevelRight.RightName = isOpPractice ? "mm.docconect.doc.app.op.doctor" : "mm.docconect.doc.app.ac.doctor";
                        functionLevelRight.GlobalPropertyMatchingID = isOpPractice ? "mm.docconect.doc.app.op.doctor" : "mm.docconect.doc.app.ac.doctor";

                        functionLevelRight.Save(Connection, Transaction);

                        tempFunctionLevelRightID = functionLevelRight.USR_Account_FunctionLevelRightID;
                    }
                    else
                    {
                        tempFunctionLevelRightID = existingFunctionLevelRight.USR_Account_FunctionLevelRightID;
                    }

                    var accountToFunctionLevelRight = new ORM_USR_Account_2_FunctionLevelRight();
                    accountToFunctionLevelRight.Tenant_RefID = securityTicket.TenantID;
                    accountToFunctionLevelRight.Creation_Timestamp = DateTime.Now;
                    accountToFunctionLevelRight.AssignmentID = Guid.NewGuid();
                    accountToFunctionLevelRight.Account_RefID = doctorAccountInfo.USR_AccountID;
                    accountToFunctionLevelRight.FunctionLevelRight_RefID = tempFunctionLevelRightID;

                    accountToFunctionLevelRight.Save(Connection, Transaction);

                    var businessParticipantQ = new ORM_CMN_BPT_BusinessParticipant.Query();

                    businessParticipantQ.IsDeleted = false;
                    businessParticipantQ.Tenant_RefID = securityTicket.TenantID;
                    businessParticipantQ.CMN_BPT_BusinessParticipantID = doctorAccountInfo.BusinessParticipant_RefID;
                    BusinessParticipantID = doctorAccountInfo.BusinessParticipant_RefID;

                    var DoctorBusinessParticipant = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, businessParticipantQ).Single();
                    DoctorBusinessParticipant.IfNaturalPerson_CMN_PER_PersonInfo_RefID = Guid.NewGuid();
                    DoctorBusinessParticipant.DisplayName = Parameter.FirstName + " " + Parameter.LastNAme;
                    DoctorBusinessParticipant.IsNaturalPerson = true;
                    DoctorBusinessParticipant.Modification_Timestamp = DateTime.Now;
                    DoctorBusinessParticipant.Save(Connection, Transaction);
                    personInfoID = DoctorBusinessParticipant.IfNaturalPerson_CMN_PER_PersonInfo_RefID;


                    var companyInfoPractice = new ORM_CMN_PER_PersonInfo();
                    companyInfoPractice.IsDeleted = false;
                    companyInfoPractice.Tenant_RefID = securityTicket.TenantID;
                    companyInfoPractice.CMN_PER_PersonInfoID = personInfoID;
                    companyInfoPractice.FirstName = Parameter.FirstName;
                    companyInfoPractice.LastName = Parameter.LastNAme;
                    companyInfoPractice.Salutation_General = Parameter.Salutation;
                    companyInfoPractice.Title = Parameter.Title;
                    companyInfoPractice.Save(Connection, Transaction);

                    var communicationContact = new ORM_CMN_PER_CommunicationContact();
                    communicationContact.IsDeleted = false;
                    communicationContact.Contact_Type = Guid.NewGuid();
                    communicationContact.Tenant_RefID = securityTicket.TenantID;
                    communicationContact.Modification_Timestamp = DateTime.Now;
                    communicationContact.PersonInfo_RefID = personInfoID;
                    communicationContact.Content = Parameter.Email;
                    communicationContact.Save(Connection, Transaction);
                    Guid CommunicationContactTypeID = communicationContact.Contact_Type;


                    var communicationContactType = new ORM_CMN_PER_CommunicationContact_Type();
                    communicationContactType.IsDeleted = false;
                    communicationContactType.Tenant_RefID = securityTicket.TenantID;
                    communicationContactType.CMN_PER_CommunicationContact_TypeID = CommunicationContactTypeID;
                    communicationContactType.Type = "Email";
                    communicationContactType.Save(Connection, Transaction);

                    var communicationContact2 = new ORM_CMN_PER_CommunicationContact();
                    communicationContact2.IsDeleted = false;
                    communicationContact2.Contact_Type = Guid.NewGuid();
                    communicationContact2.Tenant_RefID = securityTicket.TenantID;
                    communicationContact2.Modification_Timestamp = DateTime.Now;
                    communicationContact2.PersonInfo_RefID = personInfoID;
                    communicationContact2.Content = Parameter.Phone;
                    communicationContact2.Save(Connection, Transaction);
                    Guid CommunicationContactTypeID2 = communicationContact2.Contact_Type;


                    var communicationContactType2 = new ORM_CMN_PER_CommunicationContact_Type();
                    communicationContactType2.IsDeleted = false;
                    communicationContactType2.Tenant_RefID = securityTicket.TenantID;
                    communicationContactType2.CMN_PER_CommunicationContact_TypeID = CommunicationContactTypeID2;
                    communicationContactType2.Type = "Phone";
                    communicationContactType2.Save(Connection, Transaction);

                    var doctor = new ORM_HEC_Doctor();
                    doctor.HEC_DoctorID = Guid.NewGuid();
                    doctor.IsDeleted = false;
                    doctor.Tenant_RefID = securityTicket.TenantID;
                    doctor.BusinessParticipant_RefID = BusinessParticipantID;
                    doctor.DoctorIDNumber = Parameter.LANR.ToString();
                    doctor.Account_RefID = Parameter.account_id;

                    doctor.Save(Connection, Transaction);

                    doctor_id = doctor.HEC_DoctorID;

                    var ogranizationUnitPractice = ORM_CMN_BPT_CTM_OrganizationalUnit.Query.Search(Connection, Transaction, new ORM_CMN_BPT_CTM_OrganizationalUnit.Query()
                    {
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID,
                        IfMedicalPractise_HEC_MedicalPractice_RefID = Parameter.PracticeID
                    }).Single();


                    var organizationalunit_Staff = new ORM_CMN_BPT_CTM_OrganizationalUnit_Staff();
                    organizationalunit_Staff.IsDeleted = false;
                    organizationalunit_Staff.Tenant_RefID = securityTicket.TenantID;
                    organizationalunit_Staff.BusinessParticipant_RefID = BusinessParticipantID;
                    organizationalunit_Staff.OrganizationalUnit_RefID = ogranizationUnitPractice.CMN_BPT_CTM_OrganizationalUnitID;
                    organizationalunit_Staff.Save(Connection, Transaction);

                    var CustomerPRactice = ORM_CMN_BPT_CTM_Customer.Query.Search(Connection, Transaction, new ORM_CMN_BPT_CTM_Customer.Query()
                    {
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID,
                        CMN_BPT_CTM_CustomerID = ogranizationUnitPractice.Customer_RefID
                    }).Single();
                    var PracticeBusinessParticipant = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, new ORM_CMN_BPT_BusinessParticipant.Query()
                    {
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID,
                        CMN_BPT_BusinessParticipantID = CustomerPRactice.Ext_BusinessParticipant_RefID
                    }).Single();

                    PracticeName = PracticeBusinessParticipant.DisplayName;
                    PracticeBusinessParticipantID = PracticeBusinessParticipant.CMN_BPT_BusinessParticipantID;
                    PracticeCompanyInfoID = PracticeBusinessParticipant.IfCompany_CMN_COM_CompanyInfo_RefID;

                    if (Parameter.IsUsePracticeBank)
                    {

                        var PracticeBusinessParticipant2bankaccount = ORM_CMN_BPT_BusinessParticipant_2_BankAccount.Query.Search(Connection, Transaction, new ORM_CMN_BPT_BusinessParticipant_2_BankAccount.Query()
                        {
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID,
                            CMN_BPT_BusinessParticipant_RefID = PracticeBusinessParticipant.CMN_BPT_BusinessParticipantID,
                        }).Single();


                        var business2bankAccount = new ORM_CMN_BPT_BusinessParticipant_2_BankAccount();
                        business2bankAccount.IsDeleted = false;
                        business2bankAccount.Tenant_RefID = securityTicket.TenantID;
                        business2bankAccount.CMN_BPT_BusinessParticipant_RefID = BusinessParticipantID;
                        business2bankAccount.ACC_BNK_BankAccount_RefID = PracticeBusinessParticipant2bankaccount.ACC_BNK_BankAccount_RefID;
                        business2bankAccount.Creation_Timestamp = DateTime.Now;
                        business2bankAccount.Save(Connection, Transaction);

                        BankAccountID = PracticeBusinessParticipant2bankaccount.ACC_BNK_BankAccount_RefID;
                        //end of save bank data if inherited from practice   
                    }
                    else
                    {
                        if (!String.IsNullOrEmpty(Parameter.IBAN) || !String.IsNullOrEmpty(Parameter.Bank))
                        {
                            var business2bankAccount = new ORM_CMN_BPT_BusinessParticipant_2_BankAccount();
                            business2bankAccount.IsDeleted = false;
                            business2bankAccount.Tenant_RefID = securityTicket.TenantID;
                            business2bankAccount.CMN_BPT_BusinessParticipant_RefID = BusinessParticipantID;
                            business2bankAccount.ACC_BNK_BankAccount_RefID = Guid.NewGuid();
                            business2bankAccount.Creation_Timestamp = DateTime.Now;
                            business2bankAccount.Save(Connection, Transaction);

                            var bankAccountDoctor = new ORM_ACC_BNK_BankAccount();
                            bankAccountDoctor.IsDeleted = false;
                            bankAccountDoctor.Tenant_RefID = securityTicket.TenantID;
                            bankAccountDoctor.ACC_BNK_BankAccountID = business2bankAccount.ACC_BNK_BankAccount_RefID;
                            bankAccountDoctor.OwnerText = Parameter.AccountHolder;
                            bankAccountDoctor.IBAN = Parameter.IBAN;
                            bankAccountDoctor.Bank_RefID = Guid.NewGuid();
                            bankAccountDoctor.Creation_Timestamp = DateTime.Now;
                            bankAccountDoctor.Save(Connection, Transaction);

                            if (!String.IsNullOrEmpty(Parameter.Bank))
                            {
                                var bank = new ORM_ACC_BNK_Bank();
                                bank.IsDeleted = false;
                                bank.Tenant_RefID = securityTicket.TenantID;
                                bank.ACC_BNK_BankID = bankAccountDoctor.Bank_RefID;
                                bank.BICCode = Parameter.Bic;
                                bank.BankName = Parameter.Bank;
                                bank.Creation_Timestamp = DateTime.Now;
                                bank.Save(Connection, Transaction);
                            }

                            BankAccountID = business2bankAccount.ACC_BNK_BankAccount_RefID;
                            // end save bank data
                        }
                    }
                }
                catch
                {
                    throw new Exception();
                }
            }
            else
            {
                var DoctorBusinessParticipant = new ORM_CMN_BPT_BusinessParticipant();

                DoctorBusinessParticipant.IsDeleted = false;
                DoctorBusinessParticipant.Tenant_RefID = securityTicket.TenantID;
                DoctorBusinessParticipant.CMN_BPT_BusinessParticipantID = Guid.NewGuid();
                DoctorBusinessParticipant.IfNaturalPerson_CMN_PER_PersonInfo_RefID = Guid.NewGuid();
                DoctorBusinessParticipant.DisplayName = Parameter.FirstName + " " + Parameter.LastNAme;
                DoctorBusinessParticipant.IsNaturalPerson = true;
                DoctorBusinessParticipant.Modification_Timestamp = DateTime.Now;
                DoctorBusinessParticipant.Save(Connection, Transaction);
                personInfoID = DoctorBusinessParticipant.IfNaturalPerson_CMN_PER_PersonInfo_RefID;
                BusinessParticipantID = DoctorBusinessParticipant.CMN_BPT_BusinessParticipantID;

                var companyInfoPractice = new ORM_CMN_PER_PersonInfo();
                companyInfoPractice.IsDeleted = false;
                companyInfoPractice.Tenant_RefID = securityTicket.TenantID;
                companyInfoPractice.CMN_PER_PersonInfoID = personInfoID;
                companyInfoPractice.FirstName = Parameter.FirstName;
                companyInfoPractice.LastName = Parameter.LastNAme;
                companyInfoPractice.Salutation_General = Parameter.Salutation;
                companyInfoPractice.Title = Parameter.Title;
                companyInfoPractice.Save(Connection, Transaction);

                var communicationContact = new ORM_CMN_PER_CommunicationContact();
                communicationContact.IsDeleted = false;
                communicationContact.Contact_Type = Guid.NewGuid();
                communicationContact.Tenant_RefID = securityTicket.TenantID;
                communicationContact.Modification_Timestamp = DateTime.Now;
                communicationContact.PersonInfo_RefID = personInfoID;
                communicationContact.Content = Parameter.Email;
                communicationContact.Save(Connection, Transaction);
                Guid CommunicationContactTypeID = communicationContact.Contact_Type;

                var communicationContactType = new ORM_CMN_PER_CommunicationContact_Type();
                communicationContactType.IsDeleted = false;
                communicationContactType.Tenant_RefID = securityTicket.TenantID;
                communicationContactType.CMN_PER_CommunicationContact_TypeID = CommunicationContactTypeID;
                communicationContactType.Type = "Email";
                communicationContactType.Save(Connection, Transaction);

                var communicationContact2 = new ORM_CMN_PER_CommunicationContact();
                communicationContact2.IsDeleted = false;
                communicationContact2.Contact_Type = Guid.NewGuid();
                communicationContact2.Tenant_RefID = securityTicket.TenantID;
                communicationContact2.Modification_Timestamp = DateTime.Now;
                communicationContact2.PersonInfo_RefID = personInfoID;
                communicationContact2.Content = Parameter.Phone;
                communicationContact2.Save(Connection, Transaction);
                Guid CommunicationContactTypeID2 = communicationContact2.Contact_Type;


                var communicationContactType2 = new ORM_CMN_PER_CommunicationContact_Type();
                communicationContactType2.IsDeleted = false;
                communicationContactType2.Tenant_RefID = securityTicket.TenantID;
                communicationContactType2.CMN_PER_CommunicationContact_TypeID = CommunicationContactTypeID2;
                communicationContactType2.Type = "Phone";
                communicationContactType2.Save(Connection, Transaction);

                var doctor = new ORM_HEC_Doctor();
                doctor.HEC_DoctorID = Guid.NewGuid();
                doctor.IsDeleted = false;
                doctor.Tenant_RefID = securityTicket.TenantID;
                doctor.BusinessParticipant_RefID = BusinessParticipantID;
                doctor.DoctorIDNumber = Parameter.LANR.ToString();
                doctor.Account_RefID = Parameter.account_id;

                doctor.Save(Connection, Transaction);

                doctor_id = doctor.HEC_DoctorID;

                var ogranizationUnitPractice = ORM_CMN_BPT_CTM_OrganizationalUnit.Query.Search(Connection, Transaction, new ORM_CMN_BPT_CTM_OrganizationalUnit.Query()
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID,
                    IfMedicalPractise_HEC_MedicalPractice_RefID = Parameter.PracticeID
                }).Single();


                var organizationalunit_Staff = new ORM_CMN_BPT_CTM_OrganizationalUnit_Staff();
                organizationalunit_Staff.IsDeleted = false;
                organizationalunit_Staff.Tenant_RefID = securityTicket.TenantID;
                organizationalunit_Staff.BusinessParticipant_RefID = BusinessParticipantID;
                organizationalunit_Staff.OrganizationalUnit_RefID = ogranizationUnitPractice.CMN_BPT_CTM_OrganizationalUnitID;
                organizationalunit_Staff.Save(Connection, Transaction);


                var CustomerPRactice = ORM_CMN_BPT_CTM_Customer.Query.Search(Connection, Transaction, new ORM_CMN_BPT_CTM_Customer.Query()
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID,
                    CMN_BPT_CTM_CustomerID = ogranizationUnitPractice.Customer_RefID
                }).Single();
                var PracticeBusinessParticipant = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, new ORM_CMN_BPT_BusinessParticipant.Query()
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID,
                    CMN_BPT_BusinessParticipantID = CustomerPRactice.Ext_BusinessParticipant_RefID
                }).Single();
                PracticeName = PracticeBusinessParticipant.DisplayName;
                PracticeBusinessParticipantID = PracticeBusinessParticipant.CMN_BPT_BusinessParticipantID;
                PracticeCompanyInfoID = PracticeBusinessParticipant.IfCompany_CMN_COM_CompanyInfo_RefID;
                if (Parameter.IsUsePracticeBank == true)
                {


                    var PracticeBusinessParticipant2bankaccount = ORM_CMN_BPT_BusinessParticipant_2_BankAccount.Query.Search(Connection, Transaction, new ORM_CMN_BPT_BusinessParticipant_2_BankAccount.Query()
                    {
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID,
                        CMN_BPT_BusinessParticipant_RefID = PracticeBusinessParticipant.CMN_BPT_BusinessParticipantID,
                    }).Single();


                    var business2bankAccount = new ORM_CMN_BPT_BusinessParticipant_2_BankAccount();
                    business2bankAccount.IsDeleted = false;
                    business2bankAccount.Tenant_RefID = securityTicket.TenantID;
                    business2bankAccount.CMN_BPT_BusinessParticipant_RefID = BusinessParticipantID;
                    business2bankAccount.ACC_BNK_BankAccount_RefID = PracticeBusinessParticipant2bankaccount.ACC_BNK_BankAccount_RefID;
                    business2bankAccount.Creation_Timestamp = DateTime.Now;
                    business2bankAccount.Save(Connection, Transaction);

                    BankAccountID = PracticeBusinessParticipant2bankaccount.ACC_BNK_BankAccount_RefID;
                    //end of save bank data if inherited from practice   
                }
                else
                {
                    if (!String.IsNullOrEmpty(Parameter.IBAN) || !String.IsNullOrEmpty(Parameter.Bank))
                    {
                        var business2bankAccount = new ORM_CMN_BPT_BusinessParticipant_2_BankAccount();
                        business2bankAccount.IsDeleted = false;
                        business2bankAccount.Tenant_RefID = securityTicket.TenantID;
                        business2bankAccount.CMN_BPT_BusinessParticipant_RefID = BusinessParticipantID;
                        business2bankAccount.ACC_BNK_BankAccount_RefID = Guid.NewGuid();
                        business2bankAccount.Creation_Timestamp = DateTime.Now;
                        business2bankAccount.Save(Connection, Transaction);

                        var bankAccountDoctor = new ORM_ACC_BNK_BankAccount();
                        bankAccountDoctor.IsDeleted = false;
                        bankAccountDoctor.Tenant_RefID = securityTicket.TenantID;
                        bankAccountDoctor.ACC_BNK_BankAccountID = business2bankAccount.ACC_BNK_BankAccount_RefID;
                        bankAccountDoctor.OwnerText = Parameter.AccountHolder;
                        bankAccountDoctor.IBAN = Parameter.IBAN;
                        bankAccountDoctor.Bank_RefID = Guid.NewGuid();
                        bankAccountDoctor.Creation_Timestamp = DateTime.Now;
                        bankAccountDoctor.Save(Connection, Transaction);

                        if (!String.IsNullOrEmpty(Parameter.Bank))
                        {
                            var bank = new ORM_ACC_BNK_Bank();
                            bank.IsDeleted = false;
                            bank.Tenant_RefID = securityTicket.TenantID;
                            bank.ACC_BNK_BankID = bankAccountDoctor.Bank_RefID;
                            bank.BICCode = Parameter.Bic;
                            bank.BankName = Parameter.Bank;
                            bank.Creation_Timestamp = DateTime.Now;
                            bank.Save(Connection, Transaction);
                        }

                        BankAccountID = business2bankAccount.ACC_BNK_BankAccount_RefID;
                        // end save bank data
                    }
                }

            }
            var PracticeCompanyInfoAddress = ORM_CMN_COM_CompanyInfo_Address.Query.Search(Connection, Transaction, new ORM_CMN_COM_CompanyInfo_Address.Query()
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID,
                CompanyInfo_RefID = PracticeCompanyInfoID,
                Address_Description = "Standard address for billing, shipping",
            }).SingleOrDefault();


 


            Practice_Doctors_Model DPModel = new Practice_Doctors_Model();

            if (PracticeCompanyInfoAddress != null)
            {
                var PracticeUCD = ORM_CMN_UniversalContactDetail.Query.Search(Connection, Transaction, new ORM_CMN_UniversalContactDetail.Query()
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID,
                    CMN_UniversalContactDetailID = PracticeCompanyInfoAddress.Address_UCD_RefID,
                }).SingleOrDefault();
                DPModel.address = PracticeUCD.Street_Name + " " + PracticeUCD.Street_Number;
                DPModel.zip = PracticeUCD.ZIP;
                DPModel.city = PracticeUCD.Town;
            }

            DPModel.account_status = "aktiv";
            DPModel.id = doctor_id.ToString();

            var title = string.IsNullOrEmpty(Parameter.Title) ? "" : Parameter.Title.Trim();

            DPModel.name = title + " " + Parameter.FirstName + " " + Parameter.LastNAme;
            DPModel.name_untouched = Parameter.FirstName + " " + Parameter.LastNAme;
            DPModel.bsnr_lanr = Parameter.LANR.ToString();
            DPModel.autocomplete_name = title + " " + Parameter.FirstName + " " + Parameter.LastNAme;
            DPModel.salutation = title;

            DPModel.type = "Doctor";

            DPModel.bank = string.IsNullOrEmpty(Parameter.Bank) ? "" : Parameter.Bank;

            DPModel.bank_untouched = string.IsNullOrEmpty(Parameter.Bank) ? "" : Parameter.Bank;


            DPModel.phone = Parameter.Phone;

            DPModel.email = string.IsNullOrEmpty(Parameter.Email) ? "" : Parameter.Email;

            DPModel.iban = string.IsNullOrEmpty(Parameter.IBAN) ? "" : Parameter.IBAN;

            DPModel.bic = string.IsNullOrEmpty(Parameter.Bic) ? "" : Parameter.Bic;

            DPModel.bank_id = BankAccountID.ToString();
            DPModel.bank_info_inherited = Parameter.IsUsePracticeBank;
            DPModel.aditional_info = "";
            DPModel.contract = 0;


            DPModel.tenantid = securityTicket.TenantID.ToString();
            DPModel.practice_name_for_doctor = PracticeName;
            DPModel.practice_for_doctor_id = Parameter.PracticeID.ToString();

            DPModel.role = isOpPractice ? "op" : "ac";

            List<Practice_Doctors_Model> DPModelL = new List<Practice_Doctors_Model>();
            DPModelL.Add(DPModel);

            Add_Practice_Doctors_to_Elastic.Import_Practice_Data_to_ElasticDB(DPModelL, securityTicket.TenantID.ToString());

            #region Assignment to Contract

            var contractIvi = ORM_CMN_CTR_Contract.Query.Search(Connection, Transaction, new ORM_CMN_CTR_Contract.Query()
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID,
                ContractName = "IVI-Vertrag"
            }).SingleOrDefault();
            if (contractIvi != null)
            {
                Guid AssignmentID = Guid.NewGuid();
                var insuranceTobrokerContract = ORM_HEC_CRT_InsuranceToBrokerContract.Query.Search(Connection, Transaction, new ORM_HEC_CRT_InsuranceToBrokerContract.Query()
                {
                    Ext_CMN_CTR_Contract_RefID = contractIvi.CMN_CTR_ContractID,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false,

                }).SingleOrDefault();
                if (insuranceTobrokerContract != null)
                {
                    AssignmentID = insuranceTobrokerContract.HEC_CRT_InsuranceToBrokerContractID;
                }
                else
                {

                    var insuranceTobrokerContractNew = new ORM_HEC_CRT_InsuranceToBrokerContract();
                    insuranceTobrokerContractNew.HEC_CRT_InsuranceToBrokerContractID = Guid.NewGuid();
                    insuranceTobrokerContractNew.Creation_Timestamp = DateTime.Now;
                    insuranceTobrokerContractNew.IsDeleted = false;
                    insuranceTobrokerContractNew.Tenant_RefID = securityTicket.TenantID;
                    insuranceTobrokerContractNew.Ext_CMN_CTR_Contract_RefID = contractIvi.CMN_CTR_ContractID;
                    insuranceTobrokerContractNew.Save(Connection, Transaction);
                    AssignmentID = insuranceTobrokerContractNew.HEC_CRT_InsuranceToBrokerContractID;

                }
                var insuranceTobrokerContract2doctor = new ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingDoctor();
                insuranceTobrokerContract2doctor.Creation_Timestamp = DateTime.Now;
                insuranceTobrokerContract2doctor.HEC_CRT_InsuranceToBrokerContract_ParticipatingDoctorID = Guid.NewGuid();
                insuranceTobrokerContract2doctor.InsuranceToBrokerContract_RefID = AssignmentID;
                insuranceTobrokerContract2doctor.Tenant_RefID = securityTicket.TenantID;
                insuranceTobrokerContract2doctor.IsDeleted = false;
                insuranceTobrokerContract2doctor.Doctor_RefID = doctor_id;
                insuranceTobrokerContract2doctor.ValidFrom = new DateTime(2013, 6, 15);
                insuranceTobrokerContract2doctor.ValidThrough = DateTime.MinValue;
                insuranceTobrokerContract2doctor.Save(Connection, Transaction);

                P_DO_CDCD_1505 ParameterDoctorID = new P_DO_CDCD_1505();
                ParameterDoctorID.DoctorID = doctor_id;
                var data = cls_Get_Doctor_Contract_Numbers.Invoke(Connection, Transaction, ParameterDoctorID, securityTicket).Result;

                int DoctorContracts = data.Count();
                Doctor_Contracts ParameterDoctor = new Doctor_Contracts();
                ParameterDoctor.DocID = doctor_id;

                Practice_Doctors_Model DoctorFound = Get_Doctors_for_PracticeID.Set_Contract_Number_for_DoctorID(ParameterDoctor, securityTicket);

                if (DoctorFound != null)
                {
                    List<Practice_Doctors_Model> DoctorFoundL = new List<Practice_Doctors_Model>();
                    DoctorFound.contract = DoctorContracts;
                    DoctorFoundL.Add(DoctorFound);
                    Add_Practice_Doctors_to_Elastic.Import_Practice_Data_to_ElasticDB(DoctorFoundL, securityTicket.TenantID.ToString());
                }


                P_DO_GPIDfDID_1353 ParametarDocID = new P_DO_GPIDfDID_1353();
                ParametarDocID.DoctorID = doctor_id;
                DO_GPIDfDID_1353[] data2 = cls_Get_PracticeID_for_DoctorID.Invoke(Connection, Transaction, ParametarDocID, securityTicket).Result;

                P_DO_GCfPID_1507 ParametarPractice = new P_DO_GCfPID_1507();

                ParametarPractice.PracticeID = data2.First().HEC_MedicalPractiseID;
                DO_GCfPID_1507[] Contracts = cls_Get_all_Doctors_Contract_Assignment_for_PracticeID.Invoke(Connection, Transaction, ParametarPractice, securityTicket).Result;
                int NumberOfContractsForPractice = Contracts.Count();
                Practice_Doctors_Model practice = new Practice_Doctors_Model();
                practice.id = ParametarPractice.PracticeID.ToString();

                Practice_Doctors_Model PracticeFound = Get_Doctors_for_PracticeID.Get_Practice_for_PracticeID(practice, securityTicket);
                List<Practice_Doctors_Model> practiceL = new List<Practice_Doctors_Model>();
                PracticeFound.contract = NumberOfContractsForPractice;
                practiceL.Add(PracticeFound);
                Add_Practice_Doctors_to_Elastic.Import_Practice_Data_to_ElasticDB(practiceL, securityTicket.TenantID.ToString());
            }
            #endregion



            if (cleanupTransaction == true)
            {
                Transaction.Commit();
            }
            //Close the connection
            if (cleanupConnection == true)
            {
                Connection.Close();
            }
            }




            catch (Exception ex)
            {
                try
                {
                    if (cleanupTransaction == true && Transaction != null)
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
        }
    }

}
