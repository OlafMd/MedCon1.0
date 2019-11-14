
	Select
	  mrs_run_measurement_valueacquisitiontypes.MRS_RUN_Measurement_ValueAcquisitionTypeID,
	  mrs_run_measurement_valueacquisitiontypes.GlobalPropertyMatchingID,
	  mrs_run_measurement_valueacquisitiontypes.DisplayName,
	  mrs_run_measurement_valueacquisitiontypes.AcquisitionType_Name_DictID,
	  mrs_run_measurement_valueacquisitiontypes.Creation_Timestamp,
	  mrs_run_measurement_valueacquisitiontypes.Tenant_RefID,
	  mrs_run_measurement_valueacquisitiontypes.IsDeleted
	From
	  mrs_run_measurement_valueacquisitiontypes
	Where
	  mrs_run_measurement_valueacquisitiontypes.IsDeleted = 0
  