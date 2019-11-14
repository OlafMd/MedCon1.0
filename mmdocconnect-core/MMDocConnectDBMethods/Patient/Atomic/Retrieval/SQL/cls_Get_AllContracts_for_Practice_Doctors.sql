
Select
  cmn_ctr_contracts.CMN_CTR_ContractID,
  cmn_ctr_contracts.ContractName,
  cmn_ctr_contracts.ValidFrom,
  cmn_ctr_contracts.ValidThrough,
  cmn_ctr_contract_parameters.IfNumericValue_Value As
  participation_consent_valid_days
From
  cmn_bpt_ctm_organizationalunits Inner Join
  hec_medicalpractises
    On
    cmn_bpt_ctm_organizationalunits.IfMedicalPractise_HEC_MedicalPractice_RefID
    = hec_medicalpractises.HEC_MedicalPractiseID And
    cmn_bpt_ctm_organizationalunits.Tenant_RefID = @TenantID And
    cmn_bpt_ctm_organizationalunits.IsDeleted = 0 Inner Join
  cmn_bpt_ctm_organizationalunit_staff
    On cmn_bpt_ctm_organizationalunit_staff.OrganizationalUnit_RefID =
    cmn_bpt_ctm_organizationalunits.CMN_BPT_CTM_OrganizationalUnitID And
    cmn_bpt_ctm_organizationalunit_staff.Tenant_RefID = @TenantID And
    cmn_bpt_ctm_organizationalunit_staff.IsDeleted = 0 Inner Join
  cmn_bpt_businessparticipants cmn_bpt_businessparticipants1
    On cmn_bpt_ctm_organizationalunit_staff.BusinessParticipant_RefID =
    cmn_bpt_businessparticipants1.CMN_BPT_BusinessParticipantID And
    cmn_bpt_businessparticipants1.Tenant_RefID = @TenantID And
    cmn_bpt_businessparticipants1.IsDeleted = 0 Inner Join
  hec_doctors On hec_doctors.BusinessParticipant_RefID =
    cmn_bpt_businessparticipants1.CMN_BPT_BusinessParticipantID And
    hec_doctors.Tenant_RefID = @TenantID And hec_doctors.IsDeleted = 0
  Inner Join
  hec_crt_insurancetobrokercontract_participatingdoctors
    On hec_crt_insurancetobrokercontract_participatingdoctors.Doctor_RefID =
    hec_doctors.HEC_DoctorID And
    hec_crt_insurancetobrokercontract_participatingdoctors.Tenant_RefID =
    @TenantID And
    hec_crt_insurancetobrokercontract_participatingdoctors.IsDeleted = 0
  Inner Join
  hec_crt_insurancetobrokercontracts
    On
    hec_crt_insurancetobrokercontract_participatingdoctors.InsuranceToBrokerContract_RefID = hec_crt_insurancetobrokercontracts.HEC_CRT_InsuranceToBrokerContractID And hec_crt_insurancetobrokercontracts.Tenant_RefID = @TenantID And hec_crt_insurancetobrokercontracts.IsDeleted = 0 Inner Join
  cmn_ctr_contracts
    On hec_crt_insurancetobrokercontracts.Ext_CMN_CTR_Contract_RefID =
    cmn_ctr_contracts.CMN_CTR_ContractID And cmn_ctr_contracts.Tenant_RefID =
    @TenantID And cmn_ctr_contracts.IsDeleted = 0 And
    cmn_ctr_contracts.ValidFrom <= NOW() 
  Left Join
  cmn_ctr_contract_parameters On cmn_ctr_contract_parameters.Contract_RefID =
    cmn_ctr_contracts.CMN_CTR_ContractID  
    And
  cmn_ctr_contract_parameters.Tenant_RefID = @TenantID And
  cmn_ctr_contract_parameters.IsDeleted = 0 And 
     cmn_ctr_contract_parameters.ParameterName =
  "Duration of participation consent – Month"
Where
  hec_medicalpractises.Tenant_RefID = @TenantID And
  hec_medicalpractises.IsDeleted = 0 And
  hec_medicalpractises.HEC_MedicalPractiseID = @PracticeID 
	