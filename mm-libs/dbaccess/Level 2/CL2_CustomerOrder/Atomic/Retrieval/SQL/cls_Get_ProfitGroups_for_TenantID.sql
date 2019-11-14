
	Select
	  ord_cuo_profitgroups.ORD_CUO_ProfitGroupID,
	  ord_cuo_profitgroups.ShortName,
	  ord_cuo_profitgroups.ProfitGroup_Name_DictID,
	  ord_cuo_profitgroups.ProfitGroup_Description_DictID
	From
	  ord_cuo_profitgroups
	Where
	  ord_cuo_profitgroups.Tenant_RefID = @TenantID And
	  ord_cuo_profitgroups.IsDeleted = 0
  