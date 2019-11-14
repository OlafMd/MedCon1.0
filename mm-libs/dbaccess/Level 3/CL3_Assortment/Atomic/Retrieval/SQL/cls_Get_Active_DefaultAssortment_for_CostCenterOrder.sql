
	SELECT cmn_pro_ass_assortmentID
			,AssortmentName_DictID
			,AvailableForOrderingFrom
			,AvailableForOrderingThrough
		FROM CMN_PRO_ASS_Assortments
		WHERE IsDeleted = 0
			AND IsDefaultAssortment_ForCostcenterOrder = 1
			AND (
				CAST(NOW() AS DATE) BETWEEN CAST(AvailableForOrderingFrom AS DATE)
					AND CAST(AvailableForOrderingThrough AS DATE)
				)
			AND Tenant_RefID = @TenantID
  