
			SELECT
			  cmn_bpt_supplier_types.CMN_BPT_Supplier_TypeID,
			  cmn_bpt_supplier_types.GlobalPropertyMatchingID,
			  cmn_bpt_supplier_types.Creation_Timestamp,
			  cmn_bpt_supplier_types.IsDeleted
			FROM
			  cmn_bpt_supplier_types
			WHERE
			  cmn_bpt_supplier_types.Tenant_RefID = @TenantID AND
			  cmn_bpt_supplier_types.IsDeleted = 0
  