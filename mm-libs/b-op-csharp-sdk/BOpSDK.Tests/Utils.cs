using BOp.Providers;
using BOp.Providers.TMS.Requests;
using BOp.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BOp.Tests
{
    public class Utils
    {

        public static RegistrationEntity CreateRegistrationEntity(string password = "password")
        {
            var tenantProvider = ProviderFactory.Instance.CreateTenantServiceProvider();
            var registrationRequest = new RegistrationRequest();
            registrationRequest.Account = new Account();


            var tenant = new Tenant();
            tenant.DisplayName = "fakeTenant";
            tenant.ID = Guid.NewGuid();
            tenant.Code = GenerateRandomString();
            tenant.Address = new Address();
            tenant.Person = new Person();
            tenant.Organization = new Organization();

            var account = registrationRequest.Account;
            account.AccountType = EAccountType.Master;
            account.Email = GenerateRandomString() + "@test.com";
            account.PasswordHash = HashingUtil.CalculateMD5Hash(password);
            account.Verified = true;
            account.ID = Guid.NewGuid();
            account.TenantID = tenant.ID;
            account.Address = new Address();
            account.Person = new Person();

            tenantProvider.CreateTenantAndAccount(new RegistrationRequest()
            {
                Account = account,
                Tenant = tenant
            });

            var entity = new RegistrationEntity()
            {
                Account = account,
                Tenant = tenant,
                AccountPassword = password
            };

            return entity;
        }

        public static string GenerateRandomString(int size = 8)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefgijklmnopqrstuvwxyz";
            var random = new Random();
            var result = new string(Enumerable.Repeat(chars, size).Select(s => s[random.Next(s.Length)]).ToArray());
            return result;
        }

    }

    public class RegistrationEntity
    {
        public Tenant Tenant { get; set; }
        public Account Account { get; set; }
        public string AccountPassword { get; set; }
    }
}
