
    
SELECT  
    cmn_pro_ass_assortmentproducts.CMN_PRO_ASS_AssortmentProductID,
    cmn_pro_products.CMN_PRO_ProductID,
    cmn_pro_products.Product_Number,
    cmn_pro_products.Product_Name_DictID,
    cmn_pro_products.Product_Description_DictID,
    cmn_pro_products_de.Content
FROM
    cmn_pro_ass_assortmentproducts
    INNER JOIN  cmn_pro_products
    ON cmn_pro_ass_assortmentproducts.Ext_CMN_PRO_Product_RefID =
    cmn_pro_products.CMN_PRO_ProductID
    INNER JOIN cmn_pro_products_de
    ON cmn_pro_products.Product_Name_DictID =
    cmn_pro_products_de.DictID
    INNER JOIN
    cmn_pro_ass_assortment_2_assortmentproduct
    ON cmn_pro_ass_assortment_2_assortmentproduct.CMN_PRO_ASS_Assortment_Product_RefID =
    cmn_pro_ass_assortmentproducts.CMN_PRO_ASS_AssortmentProductID
Where
    cmn_pro_ass_assortment_2_assortmentproduct.CMN_PRO_ASS_Assortment_RefID = @AssortmentID And
    cmn_pro_ass_assortment_2_assortmentproduct.Tenant_RefID = @TenantID And
    cmn_pro_ass_assortment_2_assortmentproduct.IsDeleted = 0 And
    cmn_pro_products_de.IsDeleted = 0 And
    cmn_pro_products_de.Language_RefID = @LanguageID And
    (@SearchCriteria Is Null Or
    Upper(cmn_pro_products_de.Content) Like CONCAT('%',Upper(@SearchCriteria),'%') Or
    Upper(cmn_pro_products.Product_Number) Like CONCAT('%',Upper(@SearchCriteria),'%')) 
    
Order By @OrderByCriteria    
LIMIT @Size OFFSET @From

 