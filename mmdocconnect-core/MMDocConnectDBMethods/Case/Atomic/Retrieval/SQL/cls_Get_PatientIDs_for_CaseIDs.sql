
SELECT
  hec_cas_cases.Patient_RefID as PatientID
FROM
  hec_cas_cases
WHERE
  hec_cas_cases.HEC_CAS_CaseID = @CaseIDs
	