using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BOp.Providers.TMS.Requests;
using RestSharp;
using BOp.Services.Rest;
using System.Net;
using System.Security.Cryptography;
using BOp.Utility;
using BOp.Providers.TMS.Responses;
using BOp.Exceptions;

namespace BOp.Providers.TMS
{

    internal class AccountServiceProvider : BaseProvider, IAccountServiceProvider
    {

        public AccountServiceProvider(IRestClient client)
            : base(client) { }

        public List<Account> GetAllAccountsForTenant(Guid tenantID)
        {
            var url = string.Format("api/v3/tenants/{0}/accounts/", tenantID.ToString());
            var httpRequest = new JSONRestRequest(url);

            var response = Execute<List<Account>>(httpRequest, HttpStatusCode.OK);
            return response.Data;
        }

        public void BanAccount(Guid accountID, string banReason)
        {
            var url = string.Format("api/v3/accounts/{0}/ban", accountID.ToString());
            var reason = new ReasonWrapper()
            {
                Reason = banReason
            };
            var httpRequest = new JSONRestRequest(url, Method.POST);
            httpRequest.AddBody(reason);
            Execute(httpRequest, HttpStatusCode.OK);
        }

        public void UnbanAccount(Guid accountID)
        {
            var url = string.Format("api/v3/accounts/{0}/unban", accountID.ToString());
            var httpRequest = new JSONRestRequest(url, Method.POST);
            Execute(httpRequest, HttpStatusCode.OK);
        }

        public void VerifyAccount(Guid accountID)
        {
            var url = string.Format("api/v3/accounts/{0}/activate", accountID.ToString());
            var httpRequest = new JSONRestRequest(url, Method.POST);
            Execute(httpRequest, HttpStatusCode.OK);
        }

        public ChangePasswordResponse ChangePassword(ChangePasswordRequest request)
        {
            request.NewPassword = HashingUtil.CalculateMD5Hash(request.NewPassword);
            request.OldPassword = HashingUtil.CalculateMD5Hash(request.OldPassword);
            var httpRequest = new JSONRestRequest("api/v3/accounts/change-password", Method.POST);
            httpRequest.AddBody(request);
            var response = Execute<ChangePasswordResponse>(httpRequest, HttpStatusCode.OK);
            return response.Data;
        }

        public void ResetPassword(ResetPasswordRequest request)
        {
            if (request.NewPassword.Length >= 4)
            {
                request.NewPassword = HashingUtil.CalculateMD5Hash(request.NewPassword);
                var httpRequest = new JSONRestRequest("api/v3/accounts/reset-password", Method.POST);
                httpRequest.AddBody(request);
                Execute(httpRequest, HttpStatusCode.OK);
            }
            else
            {
                throw new SDKServiceException("Password must be at least 4 characters long!", new ServiceErrror());
            }
        }

        public void CreateAccount(Account account, string sessionToken)
        {
            var httpRequest = new JSONRestRequest("api/v3/accounts/", Method.POST);
            httpRequest.AddBody(account);
            httpRequest.AddHeader("sessiontoken", sessionToken);
            Execute(httpRequest, HttpStatusCode.Created);
        }

        public void UpdateAccount(Account account, string sessionToken)
        {
            try
            {
                String relativePath = String.Format("api/v3/accounts/{0}", account.ID);
                var httpRequest = new JSONRestRequest(relativePath, Method.PUT);
                httpRequest.AddBody(account);
                httpRequest.AddHeader("sessiontoken", sessionToken);
                Execute(httpRequest, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void CreateDeviceAccount(Account account)
        {
            account.AccountType = EAccountType.Device;
            var httpRequest = new JSONRestRequest("api/v3/device-accounts/", Method.POST);
            httpRequest.AddBody(account);
            Execute(httpRequest, HttpStatusCode.Created);
        }

        public List<AccountStatus> GetAccountStatusHistory(Guid tenantID, Guid accountID)
        {
            string relativePath = string.Format("api/v3/tenants/{0}/accounts/{1}/statuses", tenantID, accountID);
            var httpRequest = new JSONRestRequest(relativePath);
            var response = Execute<List<AccountStatus>>(httpRequest, HttpStatusCode.OK);
            return response.Data;
        }

        public IRestResponse ForcePasswordChange(Guid accountID)
        {
            string relativePath = string.Format("api/v3/accounts/{0}/force-password-reset", accountID);

            var httpRequest = new JSONRestRequest(relativePath, Method.POST);
            var response = Execute(httpRequest, HttpStatusCode.OK);
            return response;
        }

        public void SetDefaultAccount(DefaultTenantRequest request)
        {
            try
            {
                var httpRequest = new JSONRestRequest("api/v3/accounts/set-default-tenant", Method.POST);
                httpRequest.AddBody(request);
                Execute(httpRequest, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Account> GetAllAccounts()
        {
            try
            {
                var httpRequest = new JSONRestRequest("api/v3/accounts/", Method.GET);
                var response = Execute<List<Account>>(httpRequest, HttpStatusCode.OK);
                return response.Data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteAccount(Guid accountID, String sessionToken)
        {
            try
            {
                var httpRequest = new JSONRestRequest(string.Format("api/v3/accounts/{0}", accountID), Method.DELETE);
                httpRequest.AddHeader("sessiontoken", sessionToken);
                Execute(httpRequest, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeactivateAccount(Guid accountID, string deactivationReason)
        {
            var url = string.Format("api/v3/accounts/{0}/deactivate", accountID.ToString());
            var reason = new ReasonWrapper()
            {
                Reason = deactivationReason
            };
            var httpRequest = new JSONRestRequest(url, Method.POST);
            httpRequest.AddBody(reason);
            Execute(httpRequest, HttpStatusCode.OK);
        }

        public void ActivateAccount(Guid accountID)
        {
            var url = string.Format("api/v3/accounts/{0}/activate", accountID.ToString());
            var httpRequest = new JSONRestRequest(url, Method.POST);
            Execute(httpRequest, HttpStatusCode.OK);
        }

    }
}
