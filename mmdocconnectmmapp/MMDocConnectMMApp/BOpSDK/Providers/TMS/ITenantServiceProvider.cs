using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BOp.Providers.TMS.Requests;
using BOp.Providers.TMS.Responses;

namespace BOp.Providers.TMS
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITenantServiceProvider
    {
        /// <summary>
        /// Creates the tenant and account.
        /// </summary>
        /// <param name="request">The request. Contains information about tenant and account to create.</param>
        void CreateTenantAndAccount(RegistrationRequest request);
        /// <summary>
        /// Gets the tenants that have accounts with same credentials (email+password) as account which is logged in.
        /// His session token is provided.
        /// </summary>
        /// <param name="sessionToken">The session token.</param>
        /// <returns>Method returns all other tenant information for account with same credentials. Account that is logged in is not taken into consideration.</returns>
        List<TenantBasicInfo> GetTenantsForSessionToken(string sessionToken);

        List<TenantBasicInfo> GetTenantsForUsernamePassword(SignInRequest request);

        /// <summary>
        /// Gets the tenant for the account credential combination in case of multiple
        /// </summary>
        List<TenantBasicInfo> GetMultipleTenantsForCredentials(SignInRequest signInRequest);
    }
}
