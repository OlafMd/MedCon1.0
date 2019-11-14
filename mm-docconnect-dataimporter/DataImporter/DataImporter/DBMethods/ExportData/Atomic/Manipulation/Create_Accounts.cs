using BOp.Providers;
using BOp.Providers.TMS;
using BOp.Providers.TMS.Requests;
using CL1_CMN_BPT;
using CL1_USR;
using CSV2Core.SessionSecurity;
using DataImporter.DBMethods.Doctor.Atomic.Retrieval;
using DataImporter.Methods;
using DataImporter.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.DBMethods.ExportData.Atomic.Manipulation
{
    public class Create_Accounts
    {
        public static void Save_accounts_to_DBCompany(Practice_Model_from_xlsx Parameter, string connestionString, SessionSecurityTicket securityTicket)
        {
            DbConnection Connection = null;
            DbTransaction Transaction = null;
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;
            if (cleanupConnection == true)
            {
                Connection = CSV2Core_MySQL.Support.DBSQLSupport.CreateConnection(connestionString);
                Connection.Open();
            }
            if (cleanupTransaction == true)
            {
                Transaction = Connection.BeginTransaction();
            }
            try
            {

                IAccountServiceProvider accountService;
                var _providerFactory = ProviderFactory.Instance;
                accountService = _providerFactory.CreateAccountServiceProvider();
                var accId = Guid.NewGuid();

                string[] stringUser = Parameter.LoginEmail.Split('@');
                string usernameStr = stringUser[0];

                try
                {
                    Organization PracticeOrganization = new Organization();
                    PracticeOrganization.OrganizationName1 = Parameter.PracticeName;
                    Account account = new Account();
                    account.ID = accId;
                    account.TenantID = securityTicket.TenantID;
                    account.Email = Parameter.LoginEmail;
                    account.PasswordHash = ValidationMethods.CalculateMD5Hash(Parameter.inPassword);
                    account.Username = usernameStr;
                    account.AccountType = EAccountType.Standard;
                    account.Company = true;
                    account.Organization = PracticeOrganization;
                    account.Verified = true;

                    accountService.CreateAccount(account, securityTicket.SessionTicket);
                    accountService.VerifyAccount(account.ID);
                }
                catch (Exception ex)
                {

                    throw new Exception("Exception occured durng saving accounts", ex);

                }

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
        public static Guid Save_accounts_to_DBPerson(Doctor_model_from_xlsx Parameter, string connectionString, SessionSecurityTicket securityTicket)
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
                IAccountServiceProvider accountService;
                var _providerFactory = ProviderFactory.Instance;
                accountService = _providerFactory.CreateAccountServiceProvider();
                string[] stringUser = Parameter.LoginEmail.Split('@');
                string usernameStr = stringUser[0];

                Person DoctorAccount = new Person();
                DoctorAccount.FirstName = Parameter.FirstName;
                DoctorAccount.LastName = Parameter.LastNAme;
                DoctorAccount.Title = Parameter.Title;
                var accId = Guid.NewGuid();
                Account account = new Account();
                account.Person = DoctorAccount;
                account.ID = accId;
                account.TenantID = securityTicket.TenantID;
                account.Email = Parameter.LoginEmail;
                account.PasswordHash = ValidationMethods.CalculateMD5Hash(Parameter.inPassword);
                account.Username = usernameStr;
                account.AccountType = EAccountType.Standard;
                account.Verified = true;
                accountService.CreateAccount(account, securityTicket.SessionTicket);
                accountService.VerifyAccount(account.ID);

                return accId;

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
