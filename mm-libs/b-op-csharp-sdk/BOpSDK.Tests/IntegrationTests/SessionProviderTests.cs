using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BOp.Providers.TrustRelation;
using System.Collections.Generic;
using BOp.Providers;
using BOp.Providers.TMS;
using System.Threading;
using BOp.Providers.TMS.Requests;
using System.Linq;
using BOp.Utility;

namespace BOp.Tests.IntegrationTests
{
    [TestClass]
    public class SessionProviderTests
    {
        private static Account _account;
        private static Tenant _tenant;
        private static string _password = "test";

        [ClassInitialize]
        public static void ClassInit(TestContext context)
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
            account.PasswordHash = HashingUtil.CalculateMD5Hash(_password);
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

            _account = account;
            _tenant = tenant;

        }

        public static string GenerateRandomString(int size = 8)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefgijklmnopqrstuvwxyz";
            var random = new Random();
            var result = new string(Enumerable.Repeat(chars, size).Select(s => s[random.Next(s.Length)]).ToArray());
            return result;
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {

        }


        /// <summary>
        /// Trusts the relation request with response.
        /// </summary>
        [TestMethod]
        public void Integration_SessionServiceProvider_GetAllSessions()
        {
            var providerFactory = ProviderFactory.Instance;
            var typeProvider = providerFactory.CreateSessionServiceProvider();

            var x = typeProvider.GetAccountSessions(_tenant.ID, _account.ID);

        }

        [TestMethod]
        public void SignInWithPassword()
        {
            var provider = ProviderFactory.Instance.CreateSessionServiceProvider();
            var session = provider.SignIn(_account.Email, _password);
            var isValid = provider.CheckIfSessionIsValid(session.SessionToken);
            Assert.AreEqual(true, isValid);
        }

        [TestMethod]
        public void SignInWithPasswordAndTenant()
        {
            var provider = ProviderFactory.Instance.CreateSessionServiceProvider();
            var session = provider.SignIn(_account.Email, _password, _account.TenantID);
            var isValid = provider.CheckIfSessionIsValid(session.SessionToken);
            Assert.AreEqual(true, isValid);
        }

        [TestMethod]
        public void GetStatusHistory()
        {
            var provider = ProviderFactory.Instance.CreateAccountServiceProvider();

            var history = provider.GetAccountStatusHistory(_account.TenantID, _account.ID);
            Assert.AreEqual(1, history.Count);
            Assert.AreEqual(history[0].AccountID, _account.ID);
            Assert.AreEqual(history[0].Status, EAccountStatus.CREATED);
        }


        [TestMethod]
        public void GetGenerateTiken()
        {

            var provider = ProviderFactory.Instance.CreateSessionServiceProvider();
            var token = provider.GenerateTemporarySession(new BOp.Providers.TMS.Requests.TemporaryTokenRequest()
            {
                AccountID = _account.ID,
                TenantID = _account.TenantID,
                TimeToLive = 15
            });
            Assert.IsNotNull(token);
            var validationResult = provider.CheckIfSessionIsValid(token);
            Assert.AreEqual(true, validationResult);
            var sessionInfo = provider.GetSessionInformation(token);
            Assert.AreEqual(token, sessionInfo.SessionToken);
            Assert.AreEqual(_account.TenantID, sessionInfo.TenantID);
            Assert.AreEqual(_account.ID, sessionInfo.AccountID);

        }
        [TestMethod]
        public void GetGenerateTikenExpirationTest()
        {
            /*
            var provider = ProviderFactory.Instance.CreateSessionServiceProvider();
            var token = provider.GenerateTemporarySession(new BOp.Providers.TMS.Requests.TemporaryTokenRequest()
            {
                AccountID = _account.ID,
                TenantID = _account.TenantID,
                TimeToLive = 1
            });

            Assert.IsNotNull(token);
            Thread.Sleep(20000);
            var validationResult = provider.CheckIfSessionIsValid(token);
            Assert.AreEqual(false, validationResult);
             */

        }


        [TestMethod]
        public void IntegrationTestGetTenantsForSession()
        {
            var tenantService = ProviderFactory.Instance.CreateTenantServiceProvider();
            var sessionService = ProviderFactory.Instance.CreateSessionServiceProvider();
            
            var session = sessionService.SignIn(new SignInRequest()
            {
                Email = _account.Email,
                Password = _account.PasswordHash,
                UseDefaultTenant = true,
                SessionDetails = new SessionDetails()
                {
                    ExternalAddress = "192.168.15.1"
                }
            });
            Assert.IsNotNull(session.SessionToken);

            var tenants = tenantService.GetTenantsForSessionToken(session.SessionToken);
            Assert.AreEqual(tenants.Count, 1);
            Assert.AreEqual(tenants[0].DisplayName, _tenant.DisplayName);
            Assert.AreEqual(tenants[0].ID, _tenant.ID);
        }

        [TestMethod]
        public void IntegrationTestRegisterAccountValid()
        {
            ProviderFactory _providerFactory = ProviderFactory.Instance;

            Guid tenantId = Guid.NewGuid();
            Guid accountId = Guid.NewGuid();
            var service = _providerFactory.CreateTenantServiceProvider();
            var request = new RegistrationRequest();
            request.Account = new Account()
            {
                AccountType = EAccountType.Master,
                Disabled = false,
                DisabledReason = "Test",
                Email = "testtest@test.com",
                ID = accountId,
                PasswordHash = "098f6bcd4621d373cade4e832627b4f6",
                TenantID = tenantId,
                Username = "test",

                Locale = new Locale()
                {
                    Country = "sr",
                    Currency = "rsd",
                    Language = "sr"
                },
                Person = new Person()
                {
                    FirstName = "test",
                    Gender = EGender.Female,
                    LastName = "Test",
                    MiddleName = "Test",
                    Title = "dr",
                    DateOfBirth = DateTime.Now,

                }

            };
            request.Tenant = new Tenant()
            {
                Code = "12123123123",
                Disabled = false,
                DisplayName = "test",
                ID = tenantId,
                ActivityDomain = "test",
                BannerImageId = Guid.NewGuid(),

                Locale = new Locale()
                {
                    Country = "sr",
                    Currency = "rsd",
                    Language = "sr"
                },
                Type = ETenantType.Person,
                TestTenant = true,
                Person = new Person()
                {
                    FirstName = "test",
                    Gender = EGender.Female,
                    LastName = "Test",
                    MiddleName = "Test",
                    Title = "dr"

                },
                Deactivated = true,
                DeactivationReason = "because of reasons"

            };
            service.CreateTenantAndAccount(request);
        }
    }
}
