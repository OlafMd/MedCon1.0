
Select
  hec_patients.HEC_PatientID,
  hec_act_performedactions.HEC_ACT_PerformedActionID,
  hec_act_plannedactions.PlannedFor_Date,
  hec_act_performedactions.IfPerfomed_DateOfAction,
  hec_pat_electronicmedicalrecord_creationrequests.IsEMRFileCreated,
  hec_pat_electronicmedicalrecord_creationrequests.RequestDate,
  hec_act_plannedactions.HEC_ACT_PlannedActionID,
  hec_pat_electronicmedicalrecord_creationrequests.HEC_PAT_ElectronicMedicalRecord_CreationRequestID
From
  hec_patients Left Join
  hec_act_performedactions On hec_act_performedactions.Patient_RefID =
    hec_patients.HEC_PatientID And (hec_act_performedactions.IsDeleted Is Null
      Or hec_act_performedactions.IsDeleted = 0) Left Join
  hec_act_plannedactions On hec_patients.HEC_PatientID =
    hec_act_plannedactions.Patient_RefID And (hec_act_plannedactions.IsDeleted
      Is Null Or hec_act_plannedactions.IsDeleted = 0) Left Join
  hec_pat_electronicmedicalrecord_creationrequests
    On hec_pat_electronicmedicalrecord_creationrequests.Patient_RefID =
    hec_patients.HEC_PatientID And
    (hec_pat_electronicmedicalrecord_creationrequests.IsDeleted Is Null Or
      hec_pat_electronicmedicalrecord_creationrequests.IsDeleted = 0)
Where
  hec_patients.IsDeleted = 0 And
  hec_patients.Tenant_RefID = @TenantID
  