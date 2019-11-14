
	Select
	  hec_patient_findings.HEC_Patient_FindingID As finding_id,
	  hec_act_performedaction_referrals.ReferralTo_MedicalPracticeType_RefID As
	  referal_id,
	  hec_patient_findings.Modification_Timestamp As modification_time,
	  hec_patient_findings.DateOfFindings As  creation_date
	From
	  hec_patient_findings Inner Join
	  hec_act_performedaction_referrals
	    On hec_patient_findings.IfFindingFromReferral_Referral_RefID =
	    hec_act_performedaction_referrals.HEC_ACT_PerformedAction_ReferralID And
	    hec_act_performedaction_referrals.Tenant_RefID =
	    @TenantID And
	    hec_act_performedaction_referrals.IsDeleted = 0
	Where
	  hec_patient_findings.Patient_RefID = @PatientID And
	  hec_patient_findings.Tenant_RefID = @TenantID And
	  hec_patient_findings.IsDeleted = 0
  