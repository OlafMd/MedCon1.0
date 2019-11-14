using BOp.Providers;
using BOp.Providers.TMS;
using BOp.Providers.TMS.Requests;
using CL1_ACC_BNK;
using CL1_CMN;
using CL1_CMN_BPT;
using CL1_CMN_BPT_CTM;
using CL1_CMN_COM;
using CL1_HEC;
using CL1_USR;
using CSV2Core.Core;
using CSV2Core.SessionSecurity;
using DataImporter.Methods;
using DataImporter.Models;
using MMDocConnectElasticSearchMethods.Doctor.Manipulation;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataImporter.DBMethods.ExportData.Complex.Manipulation
{
   public class Save_practices
    {
       public static void Save_practices_to_DB(Practice_Model_from_xlsx Parameter,string connectionString, SessionSecurityTicket securityTicket)
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
                
            var returnValue = new FR_Guid();
            Guid companyInfoID = Guid.NewGuid();
            Guid BusinessParticipantID = Guid.NewGuid();
            Guid PracticeAddressID = Guid.NewGuid();
            Guid practice_id = Guid.NewGuid();
  
             if (!String.IsNullOrEmpty(Parameter.LoginEmail))
            //uncomment this if you've created account
          // if(false)   
           {
              
                    string[] stringUser = Parameter.LoginEmail.Split('@');
                    string usernameStr = stringUser[0];

                    try
                    {

                        var practiceAccountInfo = ORM_USR_Account.Query.Search(Connection, Transaction, new ORM_USR_Account.Query()
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

                        var functionLevelRightQ = new ORM_USR_Account_FunctionLevelRight.Query();
                        functionLevelRightQ.Tenant_RefID = securityTicket.TenantID;
                        functionLevelRightQ.IsDeleted = false;
                        functionLevelRightQ.GlobalPropertyMatchingID = Parameter.IsSurgeryPractice ? "mm.docconect.doc.app.op.practice" : "mm.docconect.doc.app.ac.practice";

                        var existingunctionLevelRight = ORM_USR_Account_FunctionLevelRight.Query.Search(Connection, Transaction, functionLevelRightQ).SingleOrDefault();

                        Guid tempFunctionLevelRightID = Guid.Empty;

                        if (existingunctionLevelRight == null)
                        {
                            ORM_USR_Account_FunctionLevelRight functionLevelRight = new ORM_USR_Account_FunctionLevelRight();
                            functionLevelRight.USR_Account_FunctionLevelRightID = Guid.NewGuid();
                            functionLevelRight.FunctionLevelRights_Group_RefID = accountGroup.USR_Account_FunctionLevelRights_GroupID;
                            functionLevelRight.Tenant_RefID = securityTicket.TenantID;
                            functionLevelRight.Creation_Timestamp = DateTime.Now;

                            functionLevelRight.RightName = Parameter.IsSurgeryPractice ? "mm.docconect.doc.app.op.practice" : "mm.docconect.doc.app.ac.practice";
                            functionLevelRight.GlobalPropertyMatchingID = Parameter.IsSurgeryPractice ? "mm.docconect.doc.app.op.practice" : "mm.docconect.doc.app.ac.practice";

                            functionLevelRight.Save(Connection, Transaction);

                            tempFunctionLevelRightID = functionLevelRight.USR_Account_FunctionLevelRightID;
                        }
                        else
                        {
                            tempFunctionLevelRightID = existingunctionLevelRight.USR_Account_FunctionLevelRightID;
                        }

                        var accountToFunctionLevelRight = new ORM_USR_Account_2_FunctionLevelRight();
                        accountToFunctionLevelRight.Tenant_RefID = securityTicket.TenantID;
                        accountToFunctionLevelRight.Creation_Timestamp = DateTime.Now;
                        accountToFunctionLevelRight.AssignmentID = Guid.NewGuid();
                        accountToFunctionLevelRight.Account_RefID = practiceAccountInfo.USR_AccountID;
                        accountToFunctionLevelRight.FunctionLevelRight_RefID = tempFunctionLevelRightID; // USR_Account_FunctionLevelRightID
                        accountToFunctionLevelRight.Save(Connection, Transaction);

                        var businessParticipantQ = new ORM_CMN_BPT_BusinessParticipant.Query();

                        businessParticipantQ.IsDeleted = false;
                        businessParticipantQ.Tenant_RefID = securityTicket.TenantID;
                        businessParticipantQ.CMN_BPT_BusinessParticipantID = practiceAccountInfo.BusinessParticipant_RefID;
                        BusinessParticipantID = practiceAccountInfo.BusinessParticipant_RefID;

                        var practiceinfoinBusinessParticipant = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, businessParticipantQ).Single();

                        practiceinfoinBusinessParticipant.DisplayName = Parameter.PracticeName;
                        practiceinfoinBusinessParticipant.IsCompany = true;
                        practiceinfoinBusinessParticipant.Modification_Timestamp = DateTime.Now;
                        practiceinfoinBusinessParticipant.Save(Connection, Transaction);
                        companyInfoID = practiceinfoinBusinessParticipant.IfCompany_CMN_COM_CompanyInfo_RefID;

                        var companyInfo = new ORM_CMN_COM_CompanyInfo.Query();

                        companyInfo.IsDeleted = false;
                        companyInfo.Tenant_RefID = securityTicket.TenantID;
                        companyInfo.CMN_COM_CompanyInfoID = companyInfoID;

                        var companyInfoPractice = ORM_CMN_COM_CompanyInfo.Query.Search(Connection, Transaction, companyInfo).Single();
                        companyInfoPractice.CompanyInfo_EstablishmentNumber = Parameter.BSNR;
                        companyInfoPractice.Save(Connection, Transaction);

                        var companyInfoAddressPractice = new ORM_CMN_COM_CompanyInfo_Address();
                        companyInfoAddressPractice.CompanyInfo_RefID = companyInfoID;
                        companyInfoAddressPractice.IsDefault = true;
                        companyInfoAddressPractice.IsShipping = true;
                        companyInfoAddressPractice.IsBilling = true;
                        companyInfoAddressPractice.Tenant_RefID = securityTicket.TenantID;
                        companyInfoAddressPractice.Address_UCD_RefID = Guid.NewGuid();
                        companyInfoAddressPractice.Address_Description = "Standard address for billing, shipping";
                        companyInfoAddressPractice.Save(Connection, Transaction);
                        PracticeAddressID = companyInfoAddressPractice.Address_UCD_RefID;

                        var universlContactPractice = new ORM_CMN_UniversalContactDetail();
                        universlContactPractice.IsDeleted = false;
                        universlContactPractice.Tenant_RefID = securityTicket.TenantID;
                        universlContactPractice.CMN_UniversalContactDetailID = PracticeAddressID;
                        universlContactPractice.CompanyName_Line1 = Parameter.PracticeName;
                        universlContactPractice.IsCompany = true;
                        universlContactPractice.Street_Name = Parameter.Street;
                        universlContactPractice.Street_Number = Parameter.No;
                        universlContactPractice.ZIP = Parameter.Zip;
                        universlContactPractice.Town = Parameter.City;
                        universlContactPractice.Contact_Email = Parameter.MainEmail;
                        universlContactPractice.Contact_Telephone = Parameter.MainPhone;
                        universlContactPractice.Contact_Fax = Parameter.Fax;
                        universlContactPractice.Creation_Timestamp = DateTime.Now;
                        universlContactPractice.Modification_Timestamp = DateTime.Now;
                        universlContactPractice.Save(Connection, Transaction);

                    }
                    catch (Exception ex)
                    {

                        throw new Exception("Exception occured durng data retrieval in method cls_Save_Practice", ex);
                        //Log the error (uncomment dex variable name and add a line here to write a log.
                    }
                }
              //  else{
                var companyInfoAddress2 = new ORM_CMN_COM_CompanyInfo_Address();
                companyInfoAddress2.IsDeleted = false;
                companyInfoAddress2.Tenant_RefID = securityTicket.TenantID;
                companyInfoAddress2.CompanyInfo_RefID = companyInfoID;
                companyInfoAddress2.IsDefault = true;
                companyInfoAddress2.IsContact = true;
                companyInfoAddress2.Address_UCD_RefID = Guid.NewGuid();
                companyInfoAddress2.Address_Description = "Standard contact person data";
                companyInfoAddress2.Creation_Timestamp = DateTime.Now;
                companyInfoAddress2.Save(Connection, Transaction);

                string personInfo = Parameter.ContactPerson;
                string PersonFirstName="";
                string PersonLastName = "";
                    int i = personInfo.IndexOf(' ');
                    if (i > 1)
                    {
                        PersonFirstName = personInfo.Substring(0, i);
                        PersonLastName = personInfo.Substring(i + 1);

                    }
                    else
                    {
                        PersonFirstName = Parameter.ContactPerson;
                        PersonLastName = " ";
                    }
                
                var universlContactPractice2 = new ORM_CMN_UniversalContactDetail();
                universlContactPractice2.CMN_UniversalContactDetailID = companyInfoAddress2.Address_UCD_RefID;
                universlContactPractice2.IsDeleted = false;
                universlContactPractice2.Tenant_RefID = securityTicket.TenantID;
                universlContactPractice2.IsCompany = false;
                universlContactPractice2.First_Name =PersonFirstName;
                universlContactPractice2.Last_Name = PersonLastName;
                universlContactPractice2.Contact_Email = Parameter.Email;
                universlContactPractice2.Contact_Telephone = Parameter.Phone;
                universlContactPractice2.Creation_Timestamp = DateTime.Now;
                universlContactPractice2.Modification_Timestamp = DateTime.Now;
                universlContactPractice2.Save(Connection, Transaction);

                var business2bankAccount = new ORM_CMN_BPT_BusinessParticipant_2_BankAccount();
                business2bankAccount.IsDeleted = false;
                business2bankAccount.Tenant_RefID = securityTicket.TenantID;
                business2bankAccount.CMN_BPT_BusinessParticipant_RefID = BusinessParticipantID;
                business2bankAccount.ACC_BNK_BankAccount_RefID = Guid.NewGuid();
                business2bankAccount.Creation_Timestamp = DateTime.Now;
                business2bankAccount.Save(Connection, Transaction);

                var bankAccountPractice = new ORM_ACC_BNK_BankAccount();
                bankAccountPractice.IsDeleted = false;
                bankAccountPractice.Tenant_RefID = securityTicket.TenantID;
                bankAccountPractice.ACC_BNK_BankAccountID = business2bankAccount.ACC_BNK_BankAccount_RefID;
                bankAccountPractice.OwnerText = Parameter.AccountHolder;
                bankAccountPractice.IBAN = Parameter.IBAN;
                bankAccountPractice.Bank_RefID = Guid.NewGuid();
                bankAccountPractice.Creation_Timestamp = DateTime.Now;
                bankAccountPractice.Save(Connection, Transaction);

                var bank = new ORM_ACC_BNK_Bank();
                bank.IsDeleted = false;
                bank.Tenant_RefID = securityTicket.TenantID;
                bank.ACC_BNK_BankID = bankAccountPractice.Bank_RefID;
                bank.BICCode = Parameter.Bic;
                bank.BankName = Parameter.Bank;
                bank.Creation_Timestamp = DateTime.Now;
                bank.Save(Connection, Transaction);

                var customer = new ORM_CMN_BPT_CTM_Customer();
                customer.IsDeleted = false;
                customer.Tenant_RefID = securityTicket.TenantID;
                customer.Ext_BusinessParticipant_RefID = BusinessParticipantID;
                customer.CMN_BPT_CTM_CustomerID = Guid.NewGuid();
                customer.Creation_Timestamp = DateTime.Now;
                customer.Save(Connection, Transaction);

                var organizationalUnit = new ORM_CMN_BPT_CTM_OrganizationalUnit();
                organizationalUnit.IsDeleted = false;
                organizationalUnit.Tenant_RefID = securityTicket.TenantID;
                organizationalUnit.Customer_RefID = customer.CMN_BPT_CTM_CustomerID;
                organizationalUnit.IsMedicalPractice = true;
                organizationalUnit.IfMedicalPractise_HEC_MedicalPractice_RefID = Guid.NewGuid();
                organizationalUnit.Creation_Timestamp = DateTime.Now;
                organizationalUnit.Modification_Timestamp = DateTime.Now;
                organizationalUnit.Save(Connection, Transaction);

                var medicalPractice = new ORM_HEC_MedicalPractis();

                medicalPractice.IsDeleted = false;
                medicalPractice.Tenant_RefID = securityTicket.TenantID;
                medicalPractice.HEC_MedicalPractiseID = organizationalUnit.IfMedicalPractise_HEC_MedicalPractice_RefID;
                medicalPractice.Creation_Timestamp = DateTime.Now;
                medicalPractice.Modification_Timestamp = DateTime.Now;
                medicalPractice.Save(Connection, Transaction);

                practice_id = medicalPractice.HEC_MedicalPractiseID;

                var medicalPRactice2Universal = new ORM_HEC_MedicalPractice_2_UniversalProperty();

                medicalPRactice2Universal.IsDeleted = false;
                medicalPRactice2Universal.Tenant_RefID = securityTicket.TenantID;
                medicalPRactice2Universal.HEC_MedicalPractice_RefID = medicalPractice.HEC_MedicalPractiseID;
                medicalPRactice2Universal.HEC_MedicalPractice_UniversalProperty_RefID = Guid.NewGuid();
                medicalPRactice2Universal.Value_Boolean = Parameter.IsSurgeryPractice;
                medicalPRactice2Universal.Creation_Timestamp = DateTime.Now;
                medicalPRactice2Universal.Modification_Timestamp = DateTime.Now;
                medicalPRactice2Universal.Save(Connection, Transaction);

                var practiceUniversal = new ORM_HEC_MedicalPractice_UniversalProperty();
                practiceUniversal.IsDeleted = false;
                practiceUniversal.Tenant_RefID = securityTicket.TenantID;
                practiceUniversal.HEC_MedicalPractice_UniversalPropertyID = medicalPRactice2Universal.HEC_MedicalPractice_UniversalProperty_RefID;
                practiceUniversal.PropertyName = "Surgery Practice";
                practiceUniversal.IsValue_Boolean = true;
                practiceUniversal.Creation_Timestamp = DateTime.Now;
                practiceUniversal.Modification_Timestamp = DateTime.Now;
                practiceUniversal.Save(Connection, Transaction);


                var medicalPRactice2Universal2 = new ORM_HEC_MedicalPractice_2_UniversalProperty();
                medicalPRactice2Universal2.Tenant_RefID = securityTicket.TenantID;
                medicalPRactice2Universal2.HEC_MedicalPractice_RefID = medicalPractice.HEC_MedicalPractiseID;
                medicalPRactice2Universal2.HEC_MedicalPractice_UniversalProperty_RefID = Guid.NewGuid();
                medicalPRactice2Universal2.Value_Boolean = Parameter.IsOrderDrugs;
                medicalPRactice2Universal2.Creation_Timestamp = DateTime.Now;
                medicalPRactice2Universal2.Modification_Timestamp = DateTime.Now;
                medicalPRactice2Universal2.Save(Connection, Transaction);

                var practiceUniversal2 = new ORM_HEC_MedicalPractice_UniversalProperty();
                practiceUniversal2.IsDeleted = false;
                practiceUniversal2.Tenant_RefID = securityTicket.TenantID;
                practiceUniversal2.HEC_MedicalPractice_UniversalPropertyID = medicalPRactice2Universal2.HEC_MedicalPractice_UniversalProperty_RefID;
                practiceUniversal2.PropertyName = "Order Drugs";
                practiceUniversal2.IsValue_Boolean = true;
                practiceUniversal2.Creation_Timestamp = DateTime.Now;
                practiceUniversal2.Modification_Timestamp = DateTime.Now;
                practiceUniversal2.Save(Connection, Transaction);


                // default shipping date offset 

                var medicalPRactice2Universal3 = new ORM_HEC_MedicalPractice_2_UniversalProperty();
                medicalPRactice2Universal3.Tenant_RefID = securityTicket.TenantID;
                medicalPRactice2Universal3.HEC_MedicalPractice_RefID = medicalPractice.HEC_MedicalPractiseID;
                medicalPRactice2Universal3.HEC_MedicalPractice_UniversalProperty_RefID = Guid.NewGuid();
                medicalPRactice2Universal3.Value_Number = double.Parse(Parameter.DefaultShippingDateOffset);
                medicalPRactice2Universal3.Creation_Timestamp = DateTime.Now;
                medicalPRactice2Universal3.Modification_Timestamp = DateTime.Now;
                medicalPRactice2Universal3.Save(Connection, Transaction);

                var practiceUniversal3 = new ORM_HEC_MedicalPractice_UniversalProperty();
                practiceUniversal3.IsDeleted = false;
                practiceUniversal3.Tenant_RefID = securityTicket.TenantID;
                practiceUniversal3.HEC_MedicalPractice_UniversalPropertyID = medicalPRactice2Universal3.HEC_MedicalPractice_UniversalProperty_RefID;
                practiceUniversal3.PropertyName = "Default Shipping Date Offset";
                practiceUniversal3.IsValue_Number = true;
                practiceUniversal3.Creation_Timestamp = DateTime.Now;
                practiceUniversal3.Modification_Timestamp = DateTime.Now;
                practiceUniversal3.Save(Connection, Transaction);

                var medicalPRactice2Universal4 = new ORM_HEC_MedicalPractice_2_UniversalProperty();
                medicalPRactice2Universal4.Tenant_RefID = securityTicket.TenantID;
                medicalPRactice2Universal4.HEC_MedicalPractice_RefID = medicalPractice.HEC_MedicalPractiseID;
                medicalPRactice2Universal4.HEC_MedicalPractice_UniversalProperty_RefID = Guid.NewGuid();
                medicalPRactice2Universal4.Value_Boolean = Parameter.IsOnlyLabelRequired;
                medicalPRactice2Universal4.Creation_Timestamp = DateTime.Now;
                medicalPRactice2Universal4.Modification_Timestamp = DateTime.Now;
                medicalPRactice2Universal4.Save(Connection, Transaction);

                var practiceUniversal4 = new ORM_HEC_MedicalPractice_UniversalProperty();
                practiceUniversal4.IsDeleted = false;
                practiceUniversal4.Tenant_RefID = securityTicket.TenantID;
                practiceUniversal4.HEC_MedicalPractice_UniversalPropertyID = medicalPRactice2Universal4.HEC_MedicalPractice_UniversalProperty_RefID;
                practiceUniversal4.PropertyName = "Only Label Required";
                practiceUniversal4.IsValue_Boolean = true;
                practiceUniversal4.Creation_Timestamp = DateTime.Now;
                practiceUniversal4.Modification_Timestamp = DateTime.Now;
                practiceUniversal4.Save(Connection, Transaction);

                var medicalPRactice2Universal5 = new ORM_HEC_MedicalPractice_2_UniversalProperty();
                medicalPRactice2Universal5.Tenant_RefID = securityTicket.TenantID;
                medicalPRactice2Universal5.HEC_MedicalPractice_RefID = medicalPractice.HEC_MedicalPractiseID;
                medicalPRactice2Universal5.HEC_MedicalPractice_UniversalProperty_RefID = Guid.NewGuid();
                medicalPRactice2Universal5.Value_Boolean = Parameter.isWaiveServiceFee;
                medicalPRactice2Universal5.Creation_Timestamp = DateTime.Now;
                medicalPRactice2Universal5.Modification_Timestamp = DateTime.Now;
                medicalPRactice2Universal5.Save(Connection, Transaction);

                var practiceUniversal5 = new ORM_HEC_MedicalPractice_UniversalProperty();
                practiceUniversal5.IsDeleted = false;
                practiceUniversal5.Tenant_RefID = securityTicket.TenantID;
                practiceUniversal5.HEC_MedicalPractice_UniversalPropertyID = medicalPRactice2Universal5.HEC_MedicalPractice_UniversalProperty_RefID;
                practiceUniversal5.PropertyName = "Waive Service Fee";
                practiceUniversal5.IsValue_Boolean = true;
                practiceUniversal5.Creation_Timestamp = DateTime.Now;
                practiceUniversal5.Modification_Timestamp = DateTime.Now;
                practiceUniversal5.Save(Connection, Transaction);

           //   }

      
        


            Practice_Doctors_Model DPModel = new Practice_Doctors_Model();
            DPModel.account_status =  "aktiv";
            DPModel.id = practice_id.ToString();
            DPModel.name = Parameter.PracticeName;
            DPModel.name_untouched = Parameter.PracticeName;
            DPModel.salutation = "";
            DPModel.type = "Practice";
            DPModel.autocomplete_name = Parameter.PracticeName;
            DPModel.address = Parameter.Street + " " + Parameter.No;
            DPModel.zip = Parameter.Zip;
            DPModel.city = Parameter.City;


            DPModel.bank_untouched = Parameter.Bank != null ? Parameter.Bank : "";
            DPModel.bank = Parameter.Bank != null ? Parameter.Bank : "";

            if (Parameter.Email != null)
            {
                DPModel.email = Parameter.MainEmail;
            }

            DPModel.phone = Parameter.MainPhone;
            if (Parameter.IBAN != null)
            {
                DPModel.iban = Parameter.IBAN;
            }
            if (Parameter.Bic != null)
            {
                DPModel.bic = Parameter.Bic;
            }

            DPModel.bsnr_lanr = Parameter.BSNR;
            DPModel.aditional_info = "";
            DPModel.contract = 0;
            DPModel.tenantid = securityTicket.TenantID.ToString();
            DPModel.role = Parameter.IsSurgeryPractice ? "op" : "ac";
            List<Practice_Doctors_Model> DPModelL = new List<Practice_Doctors_Model>();
            DPModelL.Add(DPModel);

            Add_Practice_Doctors_to_Elastic.Import_Practice_Data_to_ElasticDB(DPModelL, securityTicket.TenantID.ToString());


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
