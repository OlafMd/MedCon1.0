
    Select
  acc_bok_bookingaccounts_purpose_bp_assignments.ACC_BOK_BookingAccounts_Purpose_BP_AssignmentID,
  acc_bok_bookingaccounts_purpose_bp_assignments.BusinessParticipant_RefID,
  acc_bok_bookingaccounts_purpose_bp_assignments.BookingAccount_RefID,
  acc_bok_bookingaccounts.BookingAccountName,
  acc_bok_bookingaccounts.BookingAccountNumber,
  acc_bok_bookingaccounts_purpose_bp_assignments.Is_L1_BalanceSheet_Account,
  acc_bok_bookingaccounts_purpose_bp_assignments.Is_L1_IncomeStatement_Account,
  acc_bok_bookingaccounts_purpose_bp_assignments.Is_L2_AssetAccount,
  acc_bok_bookingaccounts_purpose_bp_assignments.Is_L2_LiabilitiesAccount,
  acc_bok_bookingaccounts_purpose_bp_assignments.Is_L2_RevenuesOrIncomeAccount,
  acc_bok_bookingaccounts_purpose_bp_assignments.Is_L2_ExpensesOrLossesAccount,
  acc_bok_bookingaccounts_purpose_bp_assignments.If_L3_AssetAccount_BankAccount_RefID,
  acc_bok_bookingaccounts_purpose_bp_assignments.Is_L3_BankAccount,
  acc_bok_bookingaccounts_purpose_bp_assignments.Is_L3_CustomerAccount,
  acc_bok_bookingaccounts_purpose_bp_assignments.Is_L3_SupplierAccount,
  acc_bok_bookingaccounts_purpose_bp_assignments.Is_L3_VATAccount
From
  acc_bok_bookingaccounts_purpose_bp_assignments Inner Join
  acc_bok_bookingaccounts On acc_bok_bookingaccounts.ACC_BOK_BookingAccountID =
    acc_bok_bookingaccounts_purpose_bp_assignments.BookingAccount_RefID And
    acc_bok_bookingaccounts.FiscalYear_RefID = @FiscalYearID And
    (@IsRevenueAccount Is Null Or
      acc_bok_bookingaccounts_purpose_bp_assignments.Is_L2_RevenuesOrIncomeAccount = @IsRevenueAccount) 
      And (@IsCustomerAccount Is Null Or acc_bok_bookingaccounts_purpose_bp_assignments.Is_L3_CustomerAccount = @IsCustomerAccount) 
      And (@IsVATAccount Is Null Or acc_bok_bookingaccounts_purpose_bp_assignments.Is_L3_VATAccount = @IsVATAccount) 
      And (@IsSupplierAccount Is Null Or acc_bok_bookingaccounts_purpose_bp_assignments.Is_L3_SupplierAccount = @IsSupplierAccount) 
      And (@IsBankAccount Is Null Or (@IsBankAccount = False And acc_bok_bookingaccounts_purpose_bp_assignments.Is_L3_BankAccount = False) 
            Or (@IsBankAccount = True And acc_bok_bookingaccounts_purpose_bp_assignments.Is_L3_BankAccount = True And acc_bok_bookingaccounts_purpose_bp_assignments.If_L3_AssetAccount_BankAccount_RefID Is Not Null)) And (@IsCashBox Is Null Or (@IsCashBox = False And acc_bok_bookingaccounts_purpose_bp_assignments.Is_L3_BankAccount = False) Or (@IsCashBox = True And acc_bok_bookingaccounts_purpose_bp_assignments.If_L3_AssetAccount_CashBox_RefID Is Not Null)
          )
Where
  acc_bok_bookingaccounts_purpose_bp_assignments.BusinessParticipant_RefID = @BusinessParticipantID_List And
  acc_bok_bookingaccounts_purpose_bp_assignments.Tenant_RefID = @TenantID And
  acc_bok_bookingaccounts_purpose_bp_assignments.IsDeleted = 0


  