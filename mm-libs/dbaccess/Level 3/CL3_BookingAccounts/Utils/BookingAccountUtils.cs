using CL1_ACC_BOK;

namespace CL3_BookingAccounts.Utils
{
    public class BookingAccountUtils
    {
        #region Create Empty Booking Accounts for every type

        public static ORM_ACC_BOK_BookingAccounts_Purpose_BP_Assignment GetEmptyVATAccount()
        {
            return new ORM_ACC_BOK_BookingAccounts_Purpose_BP_Assignment
            {
                Is_L1_BalanceSheet_Account = true,
                Is_L2_LiabilitiesAccount = true,
                Is_L3_VATAccount = true
            };
        }
        
        /// <summary>
        /// Supplier account, creditor, account payable
        /// </summary>
        /// <returns></returns>
        public static ORM_ACC_BOK_BookingAccounts_Purpose_BP_Assignment GetEmptySupplierAccount()
        {
            return new ORM_ACC_BOK_BookingAccounts_Purpose_BP_Assignment
            {
                Is_L1_BalanceSheet_Account = true,
                Is_L2_LiabilitiesAccount = true,
                Is_L3_SupplierAccount = true
            };
        }

        /// <summary>
        /// Customer account, debtor, accounts receivable
        /// </summary>
        /// <returns></returns>
        public static ORM_ACC_BOK_BookingAccounts_Purpose_BP_Assignment GetEmptyCustomerAccount()
        {
            return new ORM_ACC_BOK_BookingAccounts_Purpose_BP_Assignment
            {
                Is_L1_BalanceSheet_Account = true,
                Is_L2_AssetAccount = true,
                Is_L3_CustomerAccount = true
            };
        }

        /// <summary>
        /// Cash box, bank account
        /// </summary>
        /// <returns></returns>
        public static ORM_ACC_BOK_BookingAccounts_Purpose_BP_Assignment GetEmptyBankAccount()
        {
            return new ORM_ACC_BOK_BookingAccounts_Purpose_BP_Assignment
            {
                Is_L1_BalanceSheet_Account = true,
                Is_L2_AssetAccount = true,
                Is_L3_BankAccount = true
            };
        }

        public static ORM_ACC_BOK_BookingAccounts_Purpose_BP_Assignment GetEmptyExpenseAccount()
        {
            return new ORM_ACC_BOK_BookingAccounts_Purpose_BP_Assignment
            {
                Is_L1_IncomeStatement_Account = true,
                Is_L2_ExpensesOrLossesAccount = true,
            };
        }

        public static ORM_ACC_BOK_BookingAccounts_Purpose_BP_Assignment GetEmptyRevenueAccount()
        {
            return new ORM_ACC_BOK_BookingAccounts_Purpose_BP_Assignment
            {
                Is_L1_IncomeStatement_Account = true,
                Is_L2_RevenuesOrIncomeAccount = true,
            };
        }
        
        #endregion

    }
}
