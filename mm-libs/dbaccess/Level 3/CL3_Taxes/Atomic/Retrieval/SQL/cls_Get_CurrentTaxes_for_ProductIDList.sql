
Select
  cmn_pro_product_salestaxassignmnets.Product_RefID,
  acc_tax_taxes.TaxRate
From
  acc_tax_taxes Inner Join
  cmn_pro_product_salestaxassignmnets On acc_tax_taxes.ACC_TAX_TaxeID =
    cmn_pro_product_salestaxassignmnets.ApplicableSalesTax_RefID
Where
  cmn_pro_product_salestaxassignmnets.Product_RefID = @ProductIDList And
  acc_tax_taxes.Tenant_RefID = @TenantID And
  acc_tax_taxes.IsDeleted = 0
  