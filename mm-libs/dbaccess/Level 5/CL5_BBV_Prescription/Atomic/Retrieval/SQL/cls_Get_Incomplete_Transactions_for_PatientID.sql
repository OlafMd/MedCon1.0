

		Select
			  hec_patient_prescription_transactions.PrescriptionTransaction_InternalNubmer,
			  hec_patient_prescription_transactions.Creation_Timestamp,
			  hec_patients.IsPatientParticipationPolicyValidated,
			  hec_patient_prescription_transactions.HEC_Patient_Prescription_TransactionID,
			  hec_patient_prescription_transactions.PrescriptionTransaction_IsComplete,
			  hec_patients.HEC_PatientID,
			  Driver.CMN_PER_PersonInfoID,
			  Driver.CMN_BPT_BusinessParticipantID,
			  Driver.LastName,
			  Driver.FirstName,
			  Driver.DisplayName,
			  Driver.CompanyName_Line1
			From
			  hec_patients Inner Join
			  hec_patient_prescription_transactions
			    On
			    hec_patient_prescription_transactions.PrescriptionTransaction_Patient_RefID
			    = hec_patients.HEC_PatientID Left Join
			  (Select
			    cmn_per_personinfo.CMN_PER_PersonInfoID,
			    cmn_per_personinfo.FirstName,
			    cmn_per_personinfo.LastName,
			    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID,
			    cmn_bpt_businessparticipants.DisplayName,
			    cmn_universalcontactdetails.CompanyName_Line1
			  From
			    cmn_bpt_businessparticipants Inner Join
			    cmn_per_personinfo
			      On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
			      cmn_per_personinfo.CMN_PER_PersonInfoID Inner Join
			    cmn_bpt_businessparticipant_associatedbusinessparticipants
			      On cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID =
			      cmn_bpt_businessparticipant_associatedbusinessparticipants.BusinessParticipant_RefID Inner Join
			    cmn_bpt_businessparticipants cmn_bpt_businessparticipants1
			      On
			      cmn_bpt_businessparticipant_associatedbusinessparticipants.AssociatedBusinessParticipant_RefID = cmn_bpt_businessparticipants1.CMN_BPT_BusinessParticipantID Inner Join
			    cmn_com_companyinfo
			      On cmn_bpt_businessparticipants1.IfCompany_CMN_COM_CompanyInfo_RefID =
			      cmn_com_companyinfo.CMN_COM_CompanyInfoID Inner Join
			    cmn_universalcontactdetails On cmn_com_companyinfo.Contact_UCD_RefID =
			      cmn_universalcontactdetails.CMN_UniversalContactDetailID
			  Where
			    cmn_per_personinfo.IsDeleted = 0 And
			    cmn_bpt_businessparticipants.IsDeleted = 0 And
			    cmn_bpt_businessparticipant_associatedbusinessparticipants.IsDeleted = 0 And
			    cmn_bpt_businessparticipants1.IsDeleted = 0 And
			    cmn_com_companyinfo.IsDeleted = 0 And
			    cmn_universalcontactdetails.IsDeleted = 0) Driver
			    On
			    hec_patient_prescription_transactions.PrescriptionTransaction_CreatedByBusinessParticpant_RefID = Driver.CMN_BPT_BusinessParticipantID
			Where
			  hec_patients.HEC_PatientID = @HEC_PatientID And
			  hec_patients.IsDeleted = 0 And
			  hec_patient_prescription_transactions.IsDeleted = 0
  