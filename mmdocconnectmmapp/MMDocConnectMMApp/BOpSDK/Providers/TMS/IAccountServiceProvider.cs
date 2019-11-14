using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BOp.Providers.TMS.Requests;
using BOp.Providers.TMS.Responses;
using RestSharp;

namespace BOp.Providers.TMS
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAccountServiceProvider
    {
        /// <summary>
        /// Gets all accounts for tenant.
        /// </summary>
        /// <param name="tenantID">The tenant identifier.</param>
        /// <returns></returns>
        List<Account> GetAllAccountsForTenant(Guid tenantID);
        //void VerifyAccount(IAccount account);
        /// <summary>
        /// Bans the account.
        /// </summary>
        /// <param name="accountID">The account identifier.</param>
        /// <param name="banReason">The ban reason.</param>
        void BanAccount(Guid accountID, string banReason);
        /// <summary>
        /// Unbans the account.
        /// </summary>
        /// <param name="accountID">The account identifier.</param>
        void UnbanAccount(Guid accountID);
        /// <summary>
        /// Verifies the account.
        /// </summary>
        /// <param name="accountID">The account identifier.</param>
        void VerifyAccount(Guid accountID);
        /// <summary>
        /// Changes the password.
        /// </summary>
        /// <param name="request">The request containing email, tenant id (optional), old password and new password.</param>
        ChangePasswordResponse ChangePassword(ChangePasswordRequest request);
        /// <summary>
        /// Resets the password to specified value.
        /// </summary>
        /// <param name="request">The request containing master account session token, account id and new password.</param>
        void ResetPassword(ResetPasswordRequest request);
        /// <summary>
        /// Creates the account.
        /// </summary>
        /// <param name="account">The account.</param>
        /// <param name="token">The token.</param>
        void CreateAccount(Account account, string sessionToken);
        /// <summary>
        /// Creates the device account. Account type is Device (4).
        /// </summary>
        /// <param name="account">The account.</param>
        void CreateDeviceAccount(Account account);
        /// <summary>
        /// Only account username could be updated for now
        /// </summary>
        /// <param name="account">The account.</param>
        /// <param name="token">The token.</param>
        void UpdateAccount(Account account, string sessionToken);
        /// <summary>
        /// Gets the account status history.
        /// </summary>
        /// <param name="tenantID">The tenant identifier.</param>
        /// <param name="accountID">The account identifier.</param>
        /// <returns></returns>
        List<AccountStatus> GetAccountStatusHistory(Guid tenantID, Guid accountID);
        /// <summary>
        /// Force password change on next login
        /// Setting PasswordChangeRequired flag to true
        /// </summary>
        /// <param name="accountID">The account identifier</param>
        IRestResponse ForcePasswordChange(Guid accountID);
        void SetDefaultAccount(DefaultTenantRequest request);
        /// <summary>
        /// Get all accounts
        /// </summary>
        List<Account> GetAllAccounts();
        /// Delete account
        /// Deleting account
        /// </summary>
        /// <param name="AccountID">The account identifier</param>
        /// /// <param name="sessionToken">The token.</param>
        void DeleteAccount(Guid accountID, String sessionToken);
        /// <summary>
        /// Deactivates the account.
        /// </summary>
        /// <param name="accountID">The account identifier.</param>
        /// <param name="deactivateReason">The deactivate reason.</param>
        void DeactivateAccount(Guid accountID, string deactivationReason);
        /// <summary>
        /// Activates the account.
        /// </summary>
        /// <param name="accountID">The account identifier.</param>
        void ActivateAccount(Guid accountID);
    }
}
