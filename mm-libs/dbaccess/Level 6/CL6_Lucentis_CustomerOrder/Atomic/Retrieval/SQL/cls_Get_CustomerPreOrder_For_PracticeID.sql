
Select
  hec_patient_treatment.IfSheduled_Date,
  cmn_per_personinfo.FirstName,
  cmn_per_personinfo.LastName,
  cmn_bpt_businessparticipantsCompany.DisplayName As PracticeName,
  DoctorPerformed.HEC_DoctorID,
  DoctorPerformed.DoctorFirstName,
  DoctorPerformed.DoctorLastname,
  DoctorPerformed.DoctorTitle,
  hec_patient_treatment.HEC_Patient_TreatmentID,
  Article.ArticlID,
  Article.Articles_Name_DictID,
  Article.ProductProvidingPharmacy_RefID,
  Article.BoundTo_CustomerOrderPosition_RefID,
  Article.HEC_Patient_Treatment_RequiredProductID
From
  hec_patients Inner Join
  hec_patient_2_patienttreatment
    On hec_patient_2_patienttreatment.HEC_Patient_RefID =
    hec_patients.HEC_PatientID Inner Join
  hec_patient_treatment On hec_patient_treatment.HEC_Patient_TreatmentID =
    hec_patient_2_patienttreatment.HEC_Patient_Treatment_RefID Inner Join
  cmn_bpt_businessparticipants On hec_patients.CMN_BPT_BusinessParticipant_RefID
    = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID Inner Join
  cmn_per_personinfo
    On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID Inner Join
  hec_medicalpractises On hec_patient_treatment.TreatmentPractice_RefID =
    hec_medicalpractises.HEC_MedicalPractiseID Inner Join
  cmn_com_companyinfo On hec_medicalpractises.Ext_CompanyInfo_RefID =
    cmn_com_companyinfo.CMN_COM_CompanyInfoID Inner Join
  cmn_bpt_businessparticipants cmn_bpt_businessparticipantsCompany
    On cmn_bpt_businessparticipantsCompany.IfCompany_CMN_COM_CompanyInfo_RefID =
    cmn_com_companyinfo.CMN_COM_CompanyInfoID Left Join
  (Select
    cmn_per_personinfo.FirstName As DoctorFirstName,
    cmn_per_personinfo.LastName As DoctorLastname,
    cmn_per_personinfo.Title As DoctorTitle,
    hec_doctors.HEC_DoctorID
  From
    cmn_per_personinfo Inner Join
    cmn_bpt_businessparticipants
      On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
      cmn_per_personinfo.CMN_PER_PersonInfoID Inner Join
    hec_doctors On hec_doctors.BusinessParticipant_RefID =
      cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID
  Where
    hec_doctors.IsDeleted = 0 And
    cmn_bpt_businessparticipants.IsDeleted = 0 And
    cmn_bpt_businessparticipants.IsTenant = 0 And
    cmn_bpt_businessparticipants.IsCompany = 0 And
    cmn_bpt_businessparticipants.IsNaturalPerson = 1 And
    cmn_per_personinfo.IsDeleted = 0) DoctorPerformed
    On hec_patient_treatment.IfSheduled_ForDoctor_RefID =
    DoctorPerformed.HEC_DoctorID Left Join
  (Select
    cmn_pro_products.Product_Name_DictID As Articles_Name_DictID,
    cmn_pro_products.CMN_PRO_ProductID As ArticlID,
    hec_patient_treatment_requiredproducts.ProductProvidingPharmacy_RefID,
    hec_patient_treatment_requiredproducts.BoundTo_CustomerOrderPosition_RefID,
    hec_patient_treatment_requiredproducts.HEC_Patient_Treatment_RequiredProductID,
    hec_patient_treatment_requiredproducts.HEC_Patient_Treatment_RefID
  From
    hec_patient_treatment_requiredproducts Inner Join
    hec_products On hec_patient_treatment_requiredproducts.HEC_Product_RefID =
      hec_products.HEC_ProductID Inner Join
    cmn_pro_products On hec_products.Ext_PRO_Product_RefID =
      cmn_pro_products.CMN_PRO_ProductID
  Where
    hec_patient_treatment_requiredproducts.BoundTo_CustomerOrderPosition_RefID =
    Cast(0x00000000000000000000000000000000 As Binary) And
    hec_patient_treatment_requiredproducts.IsDeleted = 0 And
    hec_products.IsDeleted = 0 And
    cmn_pro_products.IsDeleted = 0) Article
    On hec_patient_treatment.HEC_Patient_TreatmentID =
    Article.HEC_Patient_Treatment_RefID
Where
  Article.ProductProvidingPharmacy_RefID = @PharmacyID And
  hec_patients.IsDeleted = 0 And
  hec_patient_2_patienttreatment.IsDeleted = 0 And
  hec_patient_treatment.IsDeleted = 0 And
  hec_patient_treatment.IsTreatmentBilled = 0 And
  hec_patient_treatment.IsTreatmentFollowup = 0 And
  cmn_bpt_businessparticipants.IsDeleted = 0 And
  cmn_bpt_businessparticipants.IsTenant = 0 And
  cmn_bpt_businessparticipants.IsCompany = 0 And
  cmn_bpt_businessparticipants.IsNaturalPerson = 1 And
  cmn_per_personinfo.IsDeleted = 0 And
  hec_medicalpractises.IsDeleted = 0 And
  cmn_com_companyinfo.IsDeleted = 0 And
  cmn_bpt_businessparticipantsCompany.IsDeleted = 0 And
  cmn_bpt_businessparticipantsCompany.IsCompany = 1 And
  cmn_bpt_businessparticipantsCompany.IsNaturalPerson = 0 And
  cmn_bpt_businessparticipantsCompany.IsTenant = 0 And
  hec_patient_treatment.IsScheduled = 1 And
  hec_patient_treatment.IsTreatmentPerformed = 0 And
  hec_patients.Tenant_RefID = @TenantID
  