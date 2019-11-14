
	Select
	  Count(cmn_pro_ass_assortmentproduct_vendorproducts.CMN_PRO_ASS_AssortmentProduct_VendorProductID) as NumberOfProducts
	From
	  cmn_pro_ass_assortmentproduct_vendorproducts Inner Join
	  cmn_pro_ass_assortmentproducts
	    On
	    cmn_pro_ass_assortmentproduct_vendorproducts.CMN_PRO_ASS_AssortmentProduct_RefID = cmn_pro_ass_assortmentproducts.CMN_PRO_ASS_AssortmentProductID And cmn_pro_ass_assortmentproducts.Tenant_RefID = @TenantID And cmn_pro_ass_assortmentproducts.IsDeleted = 0 Inner Join
	  cmn_pro_ass_assortment_2_assortmentproduct
	    On cmn_pro_ass_assortmentproducts.CMN_PRO_ASS_AssortmentProductID =
	    cmn_pro_ass_assortment_2_assortmentproduct.CMN_PRO_ASS_Assortment_Product_RefID And cmn_pro_ass_assortment_2_assortmentproduct.Tenant_RefID = @TenantID And cmn_pro_ass_assortment_2_assortmentproduct.IsDeleted = 0 And cmn_pro_ass_assortment_2_assortmentproduct.CMN_PRO_ASS_Assortment_RefID = @AssortmentID
	Where
	cmn_pro_ass_assortmentproduct_vendorproducts.Tenant_RefID=@TenantID and
	cmn_pro_ass_assortmentproduct_vendorproducts.IsDeleted=0 and
	  cmn_pro_ass_assortmentproduct_vendorproducts.CMN_PRO_Product_RefID = @ProductRefID
  