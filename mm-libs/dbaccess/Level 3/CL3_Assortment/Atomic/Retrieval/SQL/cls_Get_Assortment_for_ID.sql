
    
Select
  cmn_pro_ass_assortments.CMN_PRO_ASS_AssortmentID,
  cmn_pro_ass_assortments.AssortmentName_DictID,
  cmn_pro_ass_assortments.AvailableForOrderingFrom,
  cmn_pro_ass_assortments.AvailableForOrderingThrough,
  cmn_pro_ass_assortments.IsDefaultAssortment_ForPersonalOrder,
  cmn_pro_ass_assortments.IsDefaultAssortment_ForOfficeOrder,
  cmn_pro_ass_assortments.IsDefaultAssortment_ForCostcenterOrder,
  cmn_pro_ass_assortments.IsDefaultAssortment_ForWarehouseOrder,
  cmn_pro_ass_assortments.IsDeleted,
  cmn_pro_ass_assortments.Tenant_RefID
From
  cmn_pro_ass_assortments
Where
  cmn_pro_ass_assortments.CMN_PRO_ASS_AssortmentID = @AssortmentID And
  cmn_pro_ass_assortments.IsDeleted = 0 And
  cmn_pro_ass_assortments.Tenant_RefID = @TenantID	 
  
  