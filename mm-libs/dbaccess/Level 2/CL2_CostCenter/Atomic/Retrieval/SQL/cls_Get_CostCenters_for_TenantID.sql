
	SELECT cmn_str_costcenters.CMN_STR_CostCenterID,
	       cmn_str_costcenters.InternalID,
	       cmn_str_costcenters.Name_DictID as CostCenterName_DictID,
         cmn_str_costcenters.Description_DictID,
	       cmn_str_costcenters.Creation_Timestamp,
	       cmn_str_costcenters.IsDeleted,
	       cmn_str_costcenters.CostCenterType_RefID,
	       cmn_str_costcenters.ResponsiblePerson_RefID,
	       cmn_str_costcenters.Currency_RefID,
	       cmn_str_costcenters.CostCenter_Parent_RefID,
	       cmn_str_costcenters.R_CostCenter_HasChildren,
	       cmn_str_costcenters.OpenForBooking,
	       cmn_per_personinfo.FirstName,
	       cmn_per_personinfo.LastName,
	       cmn_str_costcenter_types.CostCenterType_Name_DictID,
	       cmn_currencies.Name_DictID as CurrencyName_DictID,
         cmn_str_office_2_costcenter.Office_RefID
	  FROM cmn_str_costcenters 
	       left join cmn_per_personinfo on cmn_str_costcenters.ResponsiblePerson_RefID = cmn_per_personinfo.CMN_PER_PersonInfoID and cmn_per_personinfo.IsDeleted = 0
	       left join cmn_str_costcenter_types on cmn_str_costcenters.CostCenterType_RefID = cmn_str_costcenter_types.CMN_STR_CostCenter_TypeID and cmn_str_costcenter_types.IsDeleted = 0
	       left join cmn_currencies on cmn_str_costcenters.Currency_RefID = cmn_currencies.CMN_CurrencyID and cmn_currencies.IsDeleted = 0
         left join cmn_str_office_2_costcenter on cmn_str_costcenters.CMN_STR_CostCenterID = cmn_str_office_2_costcenter.CostCenter_RefID and cmn_str_office_2_costcenter.IsDeleted = 0
	  where cmn_str_costcenters.Tenant_RefID = @TenantID AND cmn_str_costcenters.IsDeleted = 0
  