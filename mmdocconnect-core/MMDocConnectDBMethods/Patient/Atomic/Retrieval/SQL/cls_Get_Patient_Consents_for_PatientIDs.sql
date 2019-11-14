
    Select
      hec_crt_insurancetobrokercontract_participatingpatients.Patient_RefID,
      hec_crt_insurancetobrokercontract_participatingpatients.ValidFrom,
      hec_crt_insurancetobrokercontract_participatingpatients.InsuranceToBrokerContract_RefID,
      hec_crt_insurancetobrokercontract_participatingpatients.HEC_CRT_InsuranceToBrokerContract_ParticipatingPatientID
    From
      hec_crt_insurancetobrokercontract_participatingpatients
    Where
      hec_crt_insurancetobrokercontract_participatingpatients.Patient_RefID = @PatientIDs And
      hec_crt_insurancetobrokercontract_participatingpatients.Tenant_RefID = @TenantID And
      hec_crt_insurancetobrokercontract_participatingpatients.IsDeleted = 0  
  