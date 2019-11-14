
Select
  cmn_bpt_businessparticipants.DisplayName As name,
  cmn_bpt_ctm_organizationalunits.IfMedicalPractise_HEC_MedicalPractice_RefID as practice_id
From
  hec_patient_medicalpractices Inner Join
  cmn_bpt_ctm_organizationalunits
    On hec_patient_medicalpractices.HEC_MedicalPractices_RefID = cmn_bpt_ctm_organizationalunits.IfMedicalPractise_HEC_MedicalPractice_RefID And
    cmn_bpt_ctm_organizationalunits.Tenant_RefID = @TenantID And cmn_bpt_ctm_organizationalunits.IsDeleted = 0 Inner Join
  cmn_bpt_ctm_customers
    On cmn_bpt_ctm_organizationalunits.Customer_RefID = cmn_bpt_ctm_customers.CMN_BPT_CTM_CustomerID And cmn_bpt_ctm_customers.Tenant_RefID = @TenantID And
    cmn_bpt_ctm_customers.IsDeleted = 0 Inner Join
  cmn_bpt_businessparticipants
    On cmn_bpt_ctm_customers.Ext_BusinessParticipant_RefID = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
    cmn_bpt_businessparticipants.Tenant_RefID = @TenantID And cmn_bpt_businessparticipants.IsDeleted = 0
Where
  hec_patient_medicalpractices.HEC_Patient_RefID = @PatientID And
  hec_patient_medicalpractices.Tenant_RefID = @TenantID And
  hec_patient_medicalpractices.IsDeleted = 0
  