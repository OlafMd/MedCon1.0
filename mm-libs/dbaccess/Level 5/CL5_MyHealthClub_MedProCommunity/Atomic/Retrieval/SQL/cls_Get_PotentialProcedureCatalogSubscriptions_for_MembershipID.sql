
	Select
	  hec_cmt_membership_potentialprocedurecatalogsubscriptions.HEC_CMT_Membership_PotentialProcedureCatalogSubscriptionID,
	  hec_cmt_membership_potentialprocedurecatalogsubscriptions.PotentialProcedureCatalogITL
	From
	  hec_cmt_membership_potentialprocedurecatalogsubscriptions
	Where
	  hec_cmt_membership_potentialprocedurecatalogsubscriptions.Tenant_RefID =
	  @TenantID And
	  hec_cmt_membership_potentialprocedurecatalogsubscriptions.IsDeleted = 0 And
	  hec_cmt_membership_potentialprocedurecatalogsubscriptions.Membership_RefID =
	  @MembershipID
  