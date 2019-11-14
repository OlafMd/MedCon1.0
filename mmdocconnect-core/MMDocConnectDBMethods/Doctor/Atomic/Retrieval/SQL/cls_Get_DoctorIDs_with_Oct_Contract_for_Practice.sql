
Select
  hec_crt_insurancetobrokercontract_participatingdoctors.Doctor_RefID As
  DoctorID,
  hec_crt_insurancetobrokercontracts.Ext_CMN_CTR_Contract_RefID As ContractID,
  cmn_bpt_ctm_organizationalunits.IfMedicalPractise_HEC_MedicalPractice_RefID
From
  hec_crt_insurancetobrokercontract_participatingdoctors Inner Join
  hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes
    On
    hec_crt_insurancetobrokercontract_participatingdoctors.InsuranceToBrokerContract_RefID = hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.InsuranceToBrokerContract_RefID And 
    hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.Tenant_RefID = @TenantID And 
    hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.IsDeleted = 0 Inner Join
  hec_bil_potentialcodes
    On
    hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.PotentialBillCode_RefID = hec_bil_potentialcodes.HEC_BIL_PotentialCodeID And 
    hec_bil_potentialcodes.Tenant_RefID = @TenantID And 
    hec_bil_potentialcodes.IsDeleted = 0 Inner Join
  hec_bil_potentialcode_catalogs
    On hec_bil_potentialcodes.PotentialCode_Catalog_RefID =
    hec_bil_potentialcode_catalogs.HEC_BIL_PotentialCode_CatalogID And
    hec_bil_potentialcode_catalogs.GlobalPropertyMatchingID =
    'mm.docconnect.gpos.catalog.voruntersuchung' And
    hec_bil_potentialcode_catalogs.Tenant_RefID =
    @TenantID And
    hec_bil_potentialcode_catalogs.IsDeleted = 0 Inner Join
  hec_crt_insurancetobrokercontracts
    On
    hec_crt_insurancetobrokercontract_participatingdoctors.InsuranceToBrokerContract_RefID = hec_crt_insurancetobrokercontracts.HEC_CRT_InsuranceToBrokerContractID And 
    hec_crt_insurancetobrokercontracts.Tenant_RefID = @TenantID And 
    hec_crt_insurancetobrokercontracts.IsDeleted = 0 Inner Join
  hec_doctors
    On hec_crt_insurancetobrokercontract_participatingdoctors.Doctor_RefID =
    hec_doctors.HEC_DoctorID And hec_doctors.Tenant_RefID = @TenantID And
    hec_doctors.IsDeleted = 0 Inner Join
  cmn_bpt_ctm_organizationalunit_staff
    On hec_doctors.BusinessParticipant_RefID =
    cmn_bpt_ctm_organizationalunit_staff.BusinessParticipant_RefID And
    cmn_bpt_ctm_organizationalunit_staff.Tenant_RefID = @TenantID And
    cmn_bpt_ctm_organizationalunit_staff.IsDeleted = 0 Inner Join
  cmn_bpt_ctm_organizationalunits
    On cmn_bpt_ctm_organizationalunit_staff.OrganizationalUnit_RefID =
    cmn_bpt_ctm_organizationalunits.CMN_BPT_CTM_OrganizationalUnitID And
    cmn_bpt_ctm_organizationalunits.IsDeleted = 0 And
    cmn_bpt_ctm_organizationalunits.Tenant_RefID = @TenantID And
    cmn_bpt_ctm_organizationalunits.IfMedicalPractise_HEC_MedicalPractice_RefID = @PracticeID
Where
  hec_crt_insurancetobrokercontract_participatingdoctors.Tenant_RefID = @TenantID And
  hec_crt_insurancetobrokercontract_participatingdoctors.IsDeleted = 0
	