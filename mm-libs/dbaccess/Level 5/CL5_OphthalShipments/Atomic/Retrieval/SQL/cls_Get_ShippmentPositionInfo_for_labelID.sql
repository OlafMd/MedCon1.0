
Select
  cmn_per_personinfo.FirstName,
  cmn_per_personinfo.PrimaryEmail,
  cmn_per_personinfo.LastName,
  cmn_per_personinfo.Title,
  cmn_per_personinfo.Salutation_General,
  cmn_per_personinfo.Salutation_Letter,
  cmn_bpt_businessparticipants1.DisplayName As PracticeName,
  cmn_universalcontactdetails.PostalAddress_Formatted As PracticeAddress,
  hec_shippingposition_barcodelabels.R_IsSubmission_Complete,
  hec_shippingposition_barcodelabels.ShippingPosition_BarcodeLabel,
  hec_shippingposition_barcodelabels.HEC_ShippingPosition_BarcodeLabelID
From
  cmn_bpt_businessparticipants Inner Join
  cmn_per_personinfo On cmn_per_personinfo.CMN_PER_PersonInfoID =
    cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID
  Inner Join
  cmn_bpt_ctm_customers On cmn_bpt_ctm_customers.Ext_BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID Inner Join
  cmn_bpt_ctm_customer_2_salesrepresentatives
    On cmn_bpt_ctm_customer_2_salesrepresentatives.Customer_RefID =
    cmn_bpt_ctm_customers.CMN_BPT_CTM_CustomerID Inner Join
  hec_doctors On hec_doctors.BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID Inner Join
  hec_shippingposition_barcodelabels
    On hec_shippingposition_barcodelabels.Doctor_RefID =
    hec_doctors.HEC_DoctorID Inner Join
  cmn_bpt_businessparticipant_associatedbusinessparticipants
    On cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID =
    cmn_bpt_businessparticipant_associatedbusinessparticipants.BusinessParticipant_RefID Inner Join
  cmn_bpt_businessparticipants cmn_bpt_businessparticipants1
    On
    cmn_bpt_businessparticipant_associatedbusinessparticipants.AssociatedBusinessParticipant_RefID = cmn_bpt_businessparticipants1.CMN_BPT_BusinessParticipantID Inner Join
  hec_medicalpractises
    On cmn_bpt_businessparticipants1.IfCompany_CMN_COM_CompanyInfo_RefID =
    hec_medicalpractises.Ext_CompanyInfo_RefID Inner Join
  cmn_com_companyinfo On cmn_com_companyinfo.CMN_COM_CompanyInfoID =
    cmn_bpt_businessparticipants1.IfCompany_CMN_COM_CompanyInfo_RefID Inner Join
  cmn_universalcontactdetails
    On cmn_universalcontactdetails.CMN_UniversalContactDetailID =
    cmn_com_companyinfo.Contact_UCD_RefID
Where
  hec_shippingposition_barcodelabels.HEC_ShippingPosition_BarcodeLabelID =
  @LabelID And
  cmn_bpt_businessparticipants.IsNaturalPerson = 1 And
  cmn_bpt_businessparticipants.IsDeleted = 0 And
  cmn_per_personinfo.IsDeleted = 0 And
  cmn_bpt_ctm_customer_2_salesrepresentatives.IsDeleted = 0 And
  cmn_bpt_ctm_customers.IsDeleted = 0 And
  hec_doctors.IsDeleted = 0 And
  hec_medicalpractises.IsDeleted = 0 And
  cmn_bpt_businessparticipants1.IsDeleted = 0 And
  cmn_universalcontactdetails.IsDeleted = 0 And
  cmn_com_companyinfo.IsDeleted = 0 And
  hec_shippingposition_barcodelabels.IsDeleted = 0 And
  cmn_bpt_businessparticipant_associatedbusinessparticipants.IsDeleted = 0
  