
    SELECT
        cmn_pro_products.Product_Name_DictID,
        cmn_pro_products.Product_Number,
        hec_product_dosageforms.GlobalPropertyMatchingID AS DosageFormGlobalPropertyName,
        hec_product_dosageforms.DosageForm_Name_DictID,
        cmn_pro_pac_packageinfo.PackageContent_Amount,
        cmn_units.ISOCode,
        log_wrh_shelf_contents.Quantity_Current,
        log_producttrackinginstances.BatchNumber,
        log_producttrackinginstances.ExpirationDate,
        cmn_pro_products.CMN_PRO_ProductID,
        log_wrh_shelf_contents.LOG_WRH_Shelf_ContentID,
        log_producttrackinginstances.LOG_ProductTrackingInstanceID,
        log_producttrackinginstances.CurrentQuantityOnTrackingInstance
    FROM log_wrh_shelf_contents 

    INNER JOIN cmn_pro_products ON cmn_pro_products.CMN_PRO_ProductID = log_wrh_shelf_contents.Product_RefID 
        AND cmn_pro_products.IsDeleted = 0
        AND cmn_pro_products.Tenant_RefID = @TenantID
    LEFT OUTER JOIN  hec_products ON hec_products.Ext_PRO_Product_RefID = cmn_pro_products.CMN_PRO_ProductID 
        AND hec_products.Tenant_RefID = @TenantID
        AND hec_products.IsDeleted = 0 
    LEFT OUTER JOIN hec_product_dosageforms ON hec_products.ProductDosageForm_RefID = hec_product_dosageforms.HEC_Product_DosageFormID 
        AND hec_product_dosageforms.Tenant_RefID = @TenantID 
        AND hec_product_dosageforms.IsDeleted = 0 
    LEFT OUTER JOIN cmn_pro_pac_packageinfo ON cmn_pro_products.PackageInfo_RefID = cmn_pro_pac_packageinfo.CMN_PRO_PAC_PackageInfoID
        AND cmn_pro_pac_packageinfo.Tenant_RefID = @TenantID
        AND cmn_pro_pac_packageinfo.IsDeleted = 0
    INNER JOIN cmn_units ON cmn_pro_pac_packageinfo.PackageContent_MeasuredInUnit_RefID = cmn_units.CMN_UnitID
        AND cmn_units.Tenant_RefID = @TenantID
        AND cmn_units.IsDeleted = 0
    LEFT OUTER JOIN log_wrh_shelfcontent_2_trackinginstance ON log_wrh_shelf_contents.LOG_WRH_Shelf_ContentID = log_wrh_shelfcontent_2_trackinginstance.LOG_WRH_Shelf_Content_RefID
        AND log_wrh_shelfcontent_2_trackinginstance.Tenant_RefID = @TenantID
        AND log_wrh_shelfcontent_2_trackinginstance.IsDeleted = 0
    LEFT OUTER JOIN log_producttrackinginstances ON log_wrh_shelfcontent_2_trackinginstance.LOG_ProductTrackingInstance_RefID = log_producttrackinginstances.LOG_ProductTrackingInstanceID
        AND log_wrh_shelfcontent_2_trackinginstance.Tenant_RefID = @TenantID
        AND log_wrh_shelfcontent_2_trackinginstance.IsDeleted = 0
    WHERE
        log_wrh_shelf_contents.IsDeleted = 0
        AND log_wrh_shelf_contents.Tenant_RefID = @TenantID
        AND log_wrh_shelf_contents.Shelf_RefID = @ShelfID
  