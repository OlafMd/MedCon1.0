using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BOp.Services;
using BOp.Providers.TMS.Requests;

namespace BOp.Providers.TMS
{
    public interface ISessionServiceProvider
    {
        /// <summary>
        /// Signs the in. If Tenant ID is not provided, UseDefaultTenant must be set to true.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Session SignIn(SignInRequest request);

        /// <summary>
        /// Signs the in without hashing the password.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        Session SignInWithoutPasswordHashing(string email, string password);

        /// <summary>
        /// Signs the in.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        Session SignIn(string email, string password);
        /// <summary>
        /// Signs the in.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <param name="tenantID">The tenant identifier.</param>
        /// <returns></returns>
        Session SignIn(string email, string password, Guid tenantID);
        /// <summary>
        /// Signs the out.
        /// </summary>
        /// <param name="token">The token.</param>
        void SignOut(string token);
        /// <summary>
        /// Checks if session exists.
        /// </summary>
        /// <param name="token">The token.</param>
        bool CheckIfSessionExists(string token);
        /// <summary>
        /// Gets the session information.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        Session GetSessionInformation(string token);
        /// <summary>
        /// Verifies the session token.
        /// </summary>
        /// <param name="token">The token.</param>
        bool CheckIfSessionIsValid(string token);
        /// <summary>
        /// Switches the tenant.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        Session SwitchTenant(SwitchTenantRequest request, string token);
        /// <summary>
        /// Gets the account sessions.
        /// </summary>
        /// <param name="tenantID">The tenant identifier.</param>
        /// <param name="accountID">The account identifier.</param>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        List<Session> GetAccountSessions(Guid tenantID, Guid accountID, SessionFilter filter = null);
        /// <summary>
        /// Generates the temporary session.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        string GenerateTemporarySession(TemporaryTokenRequest request);

        /// <summary>
        /// Checks if account with given credentials exist (for given tenant).
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        bool CheckIfCredentialsAreValid(SignInRequest request);
    }
}
