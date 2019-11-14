
SELECT cmn_pro_product_notes.CMN_PRO_Product_NoteID
	,cmn_pro_product_notes.Product_RefID
	,cmn_pro_product_notes.NoteContent
	,cmn_pro_product_notes.IsImportant
	,cmn_pro_product_notes.CreatedBy_BusinessParticipant_RefID
	,cmn_bpt_businessparticipants.DisplayName
	,cmn_pro_product_notes.Creation_Timestamp
	,cmn_pro_products.Product_Name_DictID
FROM cmn_pro_products
INNER JOIN cmn_pro_product_notes ON cmn_pro_product_notes.Product_RefID = CMN_PRO_Products.cmn_pro_productID
	AND cmn_pro_product_notes.Tenant_RefID = @TenantID
	AND cmn_pro_product_notes.IsDeleted = 0
INNER JOIN cmn_bpt_businessparticipants ON cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID = cmn_pro_product_notes.CreatedBy_BusinessParticipant_RefID
WHERE cmn_pro_products.cmn_pro_productID = @ProductID
	AND cmn_pro_products.Tenant_RefID = @TenantID
	AND cmn_pro_products.IsDeleted = 0
  