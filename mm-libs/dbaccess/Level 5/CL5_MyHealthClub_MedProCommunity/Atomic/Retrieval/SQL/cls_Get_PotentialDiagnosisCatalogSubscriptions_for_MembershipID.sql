
	Select
	hec_cmt_membership_potentialdiagnosiscatalogsubscriptions.HEC_CMT_Membership_DiagnosisCatalogSubscriptionID,
	  hec_cmt_membership_potentialdiagnosiscatalogsubscriptions.PotentialDiagnosisCatalogITL
	From
	  hec_cmt_membership_potentialdiagnosiscatalogsubscriptions
	Where
	  hec_cmt_membership_potentialdiagnosiscatalogsubscriptions.Tenant_RefID =
	  @TenantID And
	  hec_cmt_membership_potentialdiagnosiscatalogsubscriptions.IsDeleted = 0 And
	  hec_cmt_membership_potentialdiagnosiscatalogsubscriptions.Membership_RefID =
	  @MembershipID
  