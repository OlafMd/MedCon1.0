
        SELECT
           ord_prc_discounttypes.GlobalPropertyMatchingID
           ,ord_prc_discounttypes.ORD_PRC_DiscountTypeID
           ,ord_prc_discounttypes.DisplayName
        FROM 
           ord_prc_discounttypes
        WHERE
            ord_prc_discounttypes.GlobalPropertyMatchingID = @GlobalPropertyMatchingID_List
           AND ord_prc_discounttypes.IsDeleted = 0
           AND ord_prc_discounttypes.Tenant_RefID = @TenantID

  