using BOp.Providers;
using BOp.Providers.TMS.Requests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BOp.Tests.IntegrationTests
{
    [TestClass]
    public class AccountProviderTest
    {
        [TestMethod]
        public void IntegrationTestCreateDeviceAccount()
        {
            var accountProvider = ProviderFactory.Instance.CreateAccountServiceProvider();
            var sessionProvider = ProviderFactory.Instance.CreateSessionServiceProvider();
            var email = string.Format("teste{0}@teste.com", new Random().Next(10000));
            var account = new Account()
            {
                Email = email,
                PasswordHash = "098f6bcd4621d373cade4e832627b4f6",
                AccountType = EAccountType.Device,
                ID = Guid.NewGuid(),
                TenantID = Guid.Parse("857797b5-a24f-4eb8-b4bd-7d8e582c8d8b"),
                Username = "testetst",
                Verified = true

            };
            accountProvider.CreateDeviceAccount(account);
            var res = sessionProvider.SignIn(new SignInRequest()
            {
                Email = email,
                Password = "098f6bcd4621d373cade4e832627b4f6",
                UseDefaultTenant = true
            });
            Assert.IsNotNull(res.SessionToken);
        }
    }
}
