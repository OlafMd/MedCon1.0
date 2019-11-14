
Select
  mrs_run_measurement_tariffs.Tenant_RefID,
  mrs_run_measurement_tariffs.Creation_Timestamp,
  mrs_run_measurement_tariffs.MeasurementTariffName_DictID,
  mrs_run_measurement_tariffs.GlobalPropertyMatchingID,
  mrs_run_measurement_tariffs.MRS_RUN_Measurement_TariffID
From
  mrs_run_measurement_tariffs
Where
  mrs_run_measurement_tariffs.isDeleted = 0
  