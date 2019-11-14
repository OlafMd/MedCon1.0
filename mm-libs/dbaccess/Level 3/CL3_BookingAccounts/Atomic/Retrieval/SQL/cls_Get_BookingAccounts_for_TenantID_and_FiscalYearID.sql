
 Select
  acc_bok_bookingaccounts.BookingAccountName,
  acc_bok_bookingaccounts.ACC_BOK_BookingAccountID,
  acc_bok_bookingaccounts.BookingAccountNumber,
  acc_fiscalyears.FiscalYearName,
  acc_bok_bookingaccounts.Tenant_RefID,
  acc_fiscalyears.ACC_FiscalYearID,
  acc_fiscalyears.StartDate,
  acc_fiscalyears.EndDate,
  acc_bok_bookingaccounts.IsDeleted,
  acc_fiscalyears.Tenant_RefID As Tenant_RefID2
From
  acc_fiscalyears Inner Join
  acc_bok_bookingaccounts On acc_fiscalyears.ACC_FiscalYearID =
    acc_bok_bookingaccounts.FiscalYear_RefID 
Where
  acc_fiscalyears.ACC_FiscalYearID = @FiscalYearID And
  acc_bok_bookingaccounts.IsDeleted = 0 
   And acc_fiscalyears.Tenant_RefID = @TenantID 
  