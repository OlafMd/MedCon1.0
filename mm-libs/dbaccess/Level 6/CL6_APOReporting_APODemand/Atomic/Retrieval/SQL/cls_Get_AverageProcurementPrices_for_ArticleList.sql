
Select
  cmn_pro_prc_general_averageprocurementprices.Product_RefID,
  cmn_pro_prc_general_averageprocurementprices.IsCurrentAveragePrice,
  cmn_price_values.PriceValue_Amount
From
  cmn_pro_prc_general_averageprocurementprices Inner Join
  cmn_price_values
    On
    cmn_pro_prc_general_averageprocurementprices.CurrentAverageProcurement_Price_RefID = cmn_price_values.Price_RefID
Where
  cmn_pro_prc_general_averageprocurementprices.Product_RefID = @ProductIDList
  And
  cmn_pro_prc_general_averageprocurementprices.IsCurrentAveragePrice = 1 And
  cmn_pro_prc_general_averageprocurementprices.Tenant_RefID = @TenantID And
  cmn_pro_prc_general_averageprocurementprices.IsDeleted = 0
  
  