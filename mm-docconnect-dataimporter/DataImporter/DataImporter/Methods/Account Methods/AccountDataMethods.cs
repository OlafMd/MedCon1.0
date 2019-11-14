using CL1_CMN_BPT;
using CL1_CMN_PER;
using CL1_USR;
using CSV2Core.SessionSecurity;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.Methods
{
    public static class AccountDataMethods
    {
        public static void AddMasterRoleToAccount(DbConnection Connection, DbTransaction Transaction, SessionSecurityTicket securityTicket)
        {

            //check if mm group exists
            var accountGroupQuery = new ORM_USR_Account_FunctionLevelRights_Group.Query();
            accountGroupQuery.Tenant_RefID = securityTicket.TenantID;
            accountGroupQuery.IsDeleted = false;
            accountGroupQuery.GlobalPropertyMatchingID = Properties.Settings.Default.MMAppGroup;

            var accountGroup = ORM_USR_Account_FunctionLevelRights_Group.Query.Search(Connection, Transaction, accountGroupQuery).SingleOrDefault();

            if (accountGroup == null)
            {
                accountGroup = new ORM_USR_Account_FunctionLevelRights_Group();
                accountGroup.Tenant_RefID = securityTicket.TenantID;
                accountGroup.Label = Properties.Settings.Default.MMAppGroup;
                accountGroup.GlobalPropertyMatchingID = Properties.Settings.Default.MMAppGroup;
                accountGroup.Creation_Timestamp = DateTime.Now;
                accountGroup.USR_Account_FunctionLevelRights_GroupID = Guid.NewGuid();
                accountGroup.Save(Connection, Transaction);
            }

            var accountQuery = new ORM_USR_Account.Query();
            accountQuery.IsDeleted = false;
            accountQuery.Tenant_RefID = securityTicket.TenantID;
            accountQuery.USR_AccountID = new Guid("1B86561E-58D6-4A00-81F6-126BCB75776E");

            var account = ORM_USR_Account.Query.Search(Connection, Transaction, accountQuery).Single();

            var accountToFunctionLevelRight = new ORM_USR_Account_2_FunctionLevelRight();
            accountToFunctionLevelRight.Tenant_RefID = securityTicket.TenantID;
            accountToFunctionLevelRight.Creation_Timestamp = DateTime.Now;
            accountToFunctionLevelRight.AssignmentID = Guid.NewGuid();
            accountToFunctionLevelRight.Account_RefID = account.USR_AccountID;
            accountToFunctionLevelRight.FunctionLevelRight_RefID = Guid.NewGuid();// USR_Account_FunctionLevelRightID
            accountToFunctionLevelRight.Save(Connection, Transaction);

            ORM_USR_Account_FunctionLevelRight functionLevelRight = new ORM_USR_Account_FunctionLevelRight();
            functionLevelRight.USR_Account_FunctionLevelRightID = accountToFunctionLevelRight.FunctionLevelRight_RefID;
            functionLevelRight.FunctionLevelRights_Group_RefID = accountGroup.USR_Account_FunctionLevelRights_GroupID;
            functionLevelRight.Tenant_RefID = securityTicket.TenantID;
            functionLevelRight.Creation_Timestamp = DateTime.Now;
            functionLevelRight.RightName = Properties.Settings.Default.MasterAccountMMApp;
            functionLevelRight.GlobalPropertyMatchingID = Properties.Settings.Default.MasterAccountMMApp;
            functionLevelRight.Save(Connection, Transaction);
            Console.WriteLine("Added master account role.");
        }

        public static void AddRegularUserRoleToAccount(DbConnection Connection, DbTransaction Transaction, SessionSecurityTicket securityTicket)
        {

            //check if mm group exists
            var accountGroupQuery = new ORM_USR_Account_FunctionLevelRights_Group.Query();
            accountGroupQuery.Tenant_RefID = securityTicket.TenantID;
            accountGroupQuery.IsDeleted = false;
            accountGroupQuery.GlobalPropertyMatchingID = Properties.Settings.Default.MMAppGroup;

            var accountGroup = ORM_USR_Account_FunctionLevelRights_Group.Query.Search(Connection, Transaction, accountGroupQuery).SingleOrDefault();

            if (accountGroup == null)
            {
                accountGroup = new ORM_USR_Account_FunctionLevelRights_Group();
                accountGroup.Tenant_RefID = securityTicket.TenantID;
                accountGroup.Label = Properties.Settings.Default.MMAppGroup;
                accountGroup.GlobalPropertyMatchingID = Properties.Settings.Default.MMAppGroup;
                accountGroup.Creation_Timestamp = DateTime.Now;
                accountGroup.USR_Account_FunctionLevelRights_GroupID = Guid.NewGuid();
                accountGroup.Save(Connection, Transaction);
            }

            var accountQuery = new ORM_USR_Account.Query();
            accountQuery.IsDeleted = false;
            accountQuery.Tenant_RefID = securityTicket.TenantID;
            accountQuery.USR_AccountID = new Guid("5348559C-6256-4BBC-B7BF-DD80B63F9F03");

            var account = ORM_USR_Account.Query.Search(Connection, Transaction, accountQuery).Single();

            var accountToFunctionLevelRight = new ORM_USR_Account_2_FunctionLevelRight();
            accountToFunctionLevelRight.Tenant_RefID = securityTicket.TenantID;
            accountToFunctionLevelRight.Creation_Timestamp = DateTime.Now;
            accountToFunctionLevelRight.AssignmentID = Guid.NewGuid();
            accountToFunctionLevelRight.Account_RefID = account.USR_AccountID;
            accountToFunctionLevelRight.FunctionLevelRight_RefID = Guid.NewGuid();// USR_Account_FunctionLevelRightID
            accountToFunctionLevelRight.Save(Connection, Transaction);

            ORM_USR_Account_FunctionLevelRight functionLevelRight = new ORM_USR_Account_FunctionLevelRight();
            functionLevelRight.USR_Account_FunctionLevelRightID = accountToFunctionLevelRight.FunctionLevelRight_RefID;
            functionLevelRight.FunctionLevelRights_Group_RefID = accountGroup.USR_Account_FunctionLevelRights_GroupID;
            functionLevelRight.Tenant_RefID = securityTicket.TenantID;
            functionLevelRight.Creation_Timestamp = DateTime.Now;
            functionLevelRight.RightName = Properties.Settings.Default.RegularAccountMMApp;
            functionLevelRight.GlobalPropertyMatchingID = Properties.Settings.Default.RegularAccountMMApp;
            functionLevelRight.Save(Connection, Transaction);
            Console.WriteLine("Added regular account role.");
        }

        public static void AddOPUserRoleToAccount(DbConnection Connection, DbTransaction Transaction, SessionSecurityTicket securityTicket)
        {

            //check if mm group exists
            var accountGroupQuery = new ORM_USR_Account_FunctionLevelRights_Group.Query();
            accountGroupQuery.Tenant_RefID = securityTicket.TenantID;
            accountGroupQuery.IsDeleted = false;
            accountGroupQuery.GlobalPropertyMatchingID = Properties.Settings.Default.DocAppGroup;

            var accountGroup = ORM_USR_Account_FunctionLevelRights_Group.Query.Search(Connection, Transaction, accountGroupQuery).SingleOrDefault();

            if (accountGroup == null)
            {
                accountGroup = new ORM_USR_Account_FunctionLevelRights_Group();
                accountGroup.Tenant_RefID = securityTicket.TenantID;
                accountGroup.Label = Properties.Settings.Default.DocAppGroup;
                accountGroup.GlobalPropertyMatchingID = Properties.Settings.Default.DocAppGroup;
                accountGroup.Creation_Timestamp = DateTime.Now;
                accountGroup.USR_Account_FunctionLevelRights_GroupID = Guid.NewGuid();
                accountGroup.Save(Connection, Transaction);
            }

            var accountQuery = new ORM_USR_Account.Query();
            accountQuery.IsDeleted = false;
            accountQuery.Tenant_RefID = securityTicket.TenantID;
            accountQuery.USR_AccountID = new Guid("8BE3F9AF-D136-483B-BED0-AB54749189A9");

            var account = ORM_USR_Account.Query.Search(Connection, Transaction, accountQuery).Single();

            var accountToFunctionLevelRight = new ORM_USR_Account_2_FunctionLevelRight();
            accountToFunctionLevelRight.Tenant_RefID = securityTicket.TenantID;
            accountToFunctionLevelRight.Creation_Timestamp = DateTime.Now;
            accountToFunctionLevelRight.AssignmentID = Guid.NewGuid();
            accountToFunctionLevelRight.Account_RefID = account.USR_AccountID;
            accountToFunctionLevelRight.FunctionLevelRight_RefID = Guid.NewGuid();// USR_Account_FunctionLevelRightID
            accountToFunctionLevelRight.Save(Connection, Transaction);

            ORM_USR_Account_FunctionLevelRight functionLevelRight = new ORM_USR_Account_FunctionLevelRight();
            functionLevelRight.USR_Account_FunctionLevelRightID = accountToFunctionLevelRight.FunctionLevelRight_RefID;
            functionLevelRight.FunctionLevelRights_Group_RefID = accountGroup.USR_Account_FunctionLevelRights_GroupID;
            functionLevelRight.Tenant_RefID = securityTicket.TenantID;
            functionLevelRight.Creation_Timestamp = DateTime.Now;
            functionLevelRight.RightName = Properties.Settings.Default.OPDocAccountDocApp;
            functionLevelRight.GlobalPropertyMatchingID = Properties.Settings.Default.OPDocAccountDocApp;
            functionLevelRight.Save(Connection, Transaction);
            Console.WriteLine("Added op doctor account role.");
        }

        public static void AddACUserRoleToAccount(DbConnection Connection, DbTransaction Transaction, SessionSecurityTicket securityTicket)
        {

            //check if mm group exists
            var accountGroupQuery = new ORM_USR_Account_FunctionLevelRights_Group.Query();
            accountGroupQuery.Tenant_RefID = securityTicket.TenantID;
            accountGroupQuery.IsDeleted = false;
            accountGroupQuery.GlobalPropertyMatchingID = Properties.Settings.Default.DocAppGroup;

            var accountGroup = ORM_USR_Account_FunctionLevelRights_Group.Query.Search(Connection, Transaction, accountGroupQuery).SingleOrDefault();

            if (accountGroup == null)
            {
                accountGroup = new ORM_USR_Account_FunctionLevelRights_Group();
                accountGroup.Tenant_RefID = securityTicket.TenantID;
                accountGroup.Label = Properties.Settings.Default.DocAppGroup;
                accountGroup.GlobalPropertyMatchingID = Properties.Settings.Default.DocAppGroup;
                accountGroup.Creation_Timestamp = DateTime.Now;
                accountGroup.USR_Account_FunctionLevelRights_GroupID = Guid.NewGuid();
                accountGroup.Save(Connection, Transaction);
            }

            var accountQuery = new ORM_USR_Account.Query();
            accountQuery.IsDeleted = false;
            accountQuery.Tenant_RefID = securityTicket.TenantID;
            accountQuery.USR_AccountID = new Guid("D2310A2B-4587-4512-BA3A-48099B31B7C5");

            var account = ORM_USR_Account.Query.Search(Connection, Transaction, accountQuery).Single();

            var accountToFunctionLevelRight = new ORM_USR_Account_2_FunctionLevelRight();
            accountToFunctionLevelRight.Tenant_RefID = securityTicket.TenantID;
            accountToFunctionLevelRight.Creation_Timestamp = DateTime.Now;
            accountToFunctionLevelRight.AssignmentID = Guid.NewGuid();
            accountToFunctionLevelRight.Account_RefID = account.USR_AccountID;
            accountToFunctionLevelRight.FunctionLevelRight_RefID = Guid.NewGuid();// USR_Account_FunctionLevelRightID
            accountToFunctionLevelRight.Save(Connection, Transaction);

            ORM_USR_Account_FunctionLevelRight functionLevelRight = new ORM_USR_Account_FunctionLevelRight();
            functionLevelRight.USR_Account_FunctionLevelRightID = accountToFunctionLevelRight.FunctionLevelRight_RefID;
            functionLevelRight.FunctionLevelRights_Group_RefID = accountGroup.USR_Account_FunctionLevelRights_GroupID;
            functionLevelRight.Tenant_RefID = securityTicket.TenantID;
            functionLevelRight.Creation_Timestamp = DateTime.Now;
            functionLevelRight.RightName = Properties.Settings.Default.ACDocAccountDocApp;
            functionLevelRight.GlobalPropertyMatchingID = Properties.Settings.Default.ACDocAccountDocApp;
            functionLevelRight.Save(Connection, Transaction);
            Console.WriteLine("Added ac doctor account role.");
        }

        public static void RemofeFirstNameAndLastNameForTest(DbConnection Connection, DbTransaction Transaction, SessionSecurityTicket securityTicket)
        {
            var accountQuery = new ORM_USR_Account.Query();
            accountQuery.IsDeleted = false;
            accountQuery.Tenant_RefID = securityTicket.TenantID;
            accountQuery.USR_AccountID = new Guid("5348559C-6256-4BBC-B7BF-DD80B63F9F03");

            var account = ORM_USR_Account.Query.Search(Connection, Transaction, accountQuery).Single();

            var businesParticipantQuery = new ORM_CMN_BPT_BusinessParticipant.Query();
            businesParticipantQuery.CMN_BPT_BusinessParticipantID = account.BusinessParticipant_RefID;
            businesParticipantQuery.Tenant_RefID = securityTicket.TenantID;
            businesParticipantQuery.IsDeleted = false;

            var businesParticipant = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, businesParticipantQuery).Single();
            businesParticipant.DisplayName = string.Empty;
            businesParticipant.Save(Connection, Transaction);

            var personInfoQuery = new ORM_CMN_PER_PersonInfo.Query();
            personInfoQuery.CMN_PER_PersonInfoID = businesParticipant.IfNaturalPerson_CMN_PER_PersonInfo_RefID;
            personInfoQuery.IsDead = false;
            personInfoQuery.Tenant_RefID = securityTicket.TenantID;

            var personInfo = ORM_CMN_PER_PersonInfo.Query.Search(Connection, Transaction, personInfoQuery).Single();
            personInfo.FirstName = string.Empty;
            personInfo.LastName = string.Empty;
            personInfo.Save(Connection, Transaction);

            Console.WriteLine("Changed first name and last name. ");
        }

    }
}
