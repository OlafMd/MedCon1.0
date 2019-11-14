
Select
  acc_bok_bookingaccount_2_tax.IsDefaultAccountForRevenueBookings,
  acc_bok_bookingaccount_2_tax.IsDefaultAccountForTaxBookings,
  acc_tax_taxes.TaxRate,
  acc_bok_bookingaccount_2_tax.ACC_BOK_BookingAccount_RefID
From
  acc_bok_bookingaccount_2_tax Inner Join
  acc_tax_taxes On acc_tax_taxes.ACC_TAX_TaxeID =
    acc_bok_bookingaccount_2_tax.ACC_TAX_Tax_RefID
Where
  acc_tax_taxes.IsDeleted = 0 And
  acc_bok_bookingaccount_2_tax.IsDeleted = 0 And
  acc_tax_taxes.Tenant_RefID = @TenantID
  