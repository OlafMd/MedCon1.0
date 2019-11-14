
SELECT Sum(log_rsv_reservations.reservedquantity)   Reserved_Quantity, 
       Sum(log_wrh_shelf_contents.quantity_current) Quantity_Current
FROM   log_producttrackinginstances 
       INNER JOIN log_wrh_shelfcontent_2_trackinginstance 
               ON 
       log_wrh_shelfcontent_2_trackinginstance.log_producttrackinginstance_refid 
       = 
                  log_producttrackinginstances.log_producttrackinginstanceid 
       AND log_wrh_shelfcontent_2_trackinginstance.isdeleted = 0 
       AND log_wrh_shelfcontent_2_trackinginstance.tenant_refid = @TenantID 
       INNER JOIN log_wrh_shelf_contents 
               ON log_wrh_shelf_contents.log_wrh_shelf_contentid = 
       log_wrh_shelfcontent_2_trackinginstance.log_wrh_shelf_content_refid 
       AND log_wrh_shelf_contents.isdeleted = 0 
       AND log_wrh_shelf_contents.tenant_refid = @TenantID 
       LEFT JOIN log_rsv_reservations 
              ON log_rsv_reservations.log_wrh_shelf_content_refid = 
                           log_wrh_shelf_contents.log_wrh_shelf_contentid 
                 AND log_rsv_reservations.isdeleted = 0 
                 AND log_rsv_reservations.tenant_refid = @TenantID 
WHERE  log_producttrackinginstances.isdeleted = 0 
       AND log_producttrackinginstances.tenant_refid = @TenantID 
       AND log_producttrackinginstances.cmn_pro_product_refid = @ProductID 
GROUP  BY log_producttrackinginstances.cmn_pro_product_refid 
  