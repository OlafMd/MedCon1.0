
Select
  cmn_per_personinfo.Gender,
  cmn_per_personinfo.FirstName,
  cmn_per_personinfo.LastName,
  cmn_per_personinfo.BirthDate,
  cmn_bpt_businessparticipants1.DisplayName As practice_name,
  cmn_com_companyinfo.CompanyInfo_EstablishmentNumber As BSNR,
  hec_patient_healthinsurances.HealthInsurance_Number,
  hec_patient_healthinsurances.InsuranceStateCode,
  hec_his_healthinsurance_companies.HealthInsurance_IKNumber,
  cmn_bpt_businessparticipants2.DisplayName As Health_insurance_name
From
  hec_patients Inner Join
  cmn_bpt_businessparticipants
    On cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID =
    hec_patients.CMN_BPT_BusinessParticipant_RefID And
    cmn_bpt_businessparticipants.IsCompany = 0 And
    cmn_bpt_businessparticipants.IsNaturalPerson = 1 And
    cmn_bpt_businessparticipants.IsDeleted = 0 And
    cmn_bpt_businessparticipants.Tenant_RefID = @TenantID Inner Join
  cmn_per_personinfo
    On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID And cmn_per_personinfo.IsDeleted = 0
    And cmn_per_personinfo.Tenant_RefID = @TenantID Inner Join
  hec_patient_medicalpractices On hec_patients.HEC_PatientID =
    hec_patient_medicalpractices.HEC_Patient_RefID And
    hec_patient_medicalpractices.IsDeleted = 0 And
    hec_patient_medicalpractices.Tenant_RefID = @TenantID Inner Join
  hec_medicalpractises
    On hec_patient_medicalpractices.HEC_MedicalPractices_RefID =
    hec_medicalpractises.HEC_MedicalPractiseID And
    hec_medicalpractises.IsDeleted = 0 And hec_medicalpractises.Tenant_RefID =
    @TenantID Inner Join
  cmn_com_companyinfo On hec_medicalpractises.Ext_CompanyInfo_RefID =
    cmn_com_companyinfo.CMN_COM_CompanyInfoID And cmn_com_companyinfo.IsDeleted
    = 0 And cmn_com_companyinfo.Tenant_RefID = @TenantID Inner Join
  cmn_bpt_businessparticipants cmn_bpt_businessparticipants1
    On cmn_com_companyinfo.CMN_COM_CompanyInfoID =
    cmn_bpt_businessparticipants1.IfCompany_CMN_COM_CompanyInfo_RefID And
    cmn_bpt_businessparticipants1.IsCompany = 1 And
    cmn_bpt_businessparticipants1.IsNaturalPerson = 0 And
    cmn_bpt_businessparticipants1.IsDeleted = 0 And
    cmn_bpt_businessparticipants1.Tenant_RefID = @TenantID Inner Join
  hec_patient_healthinsurances On hec_patient_healthinsurances.Patient_RefID =
    hec_patients.HEC_PatientID And hec_patient_healthinsurances.IsDeleted = 0
    And hec_patient_healthinsurances.Tenant_RefID = @TenantID Inner Join
  hec_his_healthinsurance_companies
    On hec_patient_healthinsurances.HIS_HealthInsurance_Company_RefID =
    hec_his_healthinsurance_companies.HEC_HealthInsurance_CompanyID And
    hec_his_healthinsurance_companies.IsDeleted = 0 And
    hec_his_healthinsurance_companies.Tenant_RefID = @TenantID Inner Join
  cmn_bpt_businessparticipants cmn_bpt_businessparticipants2
    On cmn_bpt_businessparticipants2.IsDeleted = 0 And
    cmn_bpt_businessparticipants2.Tenant_RefID = @TenantID And
    cmn_bpt_businessparticipants2.IsNaturalPerson = 0 And
    cmn_bpt_businessparticipants2.IsCompany = 1 And
    cmn_bpt_businessparticipants2.CMN_BPT_BusinessParticipantID =
    hec_his_healthinsurance_companies.CMN_BPT_BusinessParticipant_RefID
Where
  hec_patients.IsDeleted = 0 And
  hec_patients.Tenant_RefID = @TenantID
  