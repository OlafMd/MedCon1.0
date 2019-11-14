
Select
  pps_tsk_bok_bookabletimeslots.FreeInterval_Start,
  pps_tsk_bok_bookabletimeslots.FreeInterval_End,
  pps_tsk_bok_deviceresources.PPS_DEV_Device_Instance_RefID,
  pps_tsk_bok_staffresources.CMN_BPT_EMP_Employee_RefID,
  pps_tsk_bok_availableresourcecombinations.PPS_TSK_BOK_AvailableResourceCombinationID,
  pps_tsk_bok_deviceresources.PPS_TSK_BOK_DeviceResourceID,
  pps_tsk_bok_staffresources.PPS_TSK_BOK_StaffResourceID,
  pps_tsk_bok_bookabletimeslots.PPS_TSK_BOK_BookableTimeSlotID,
  pps_tsk_bok_bookabletimeslots.FreeSlotsForTaskTemplateITPL,
  pps_tsk_bok_staffresources.CreatedFor_TaskTemplateRequiredStaff_RefID,
  pps_tsk_bok_bookabletimeslots_2_availabilitytypes.AssignmentID,
  pps_tsk_bok_availableresourcecombinations.IsAvailable
From
  pps_tsk_bok_availableresourcecombinations Inner Join
  pps_tsk_bok_bookabletimeslots
    On pps_tsk_bok_bookabletimeslots.PPS_TSK_BOK_BookableTimeSlotID =
    pps_tsk_bok_availableresourcecombinations.BookableTimeSlot_RefID Left Join
  pps_tsk_bok_deviceresources
    On
    pps_tsk_bok_availableresourcecombinations.PPS_TSK_BOK_AvailableResourceCombinationID = pps_tsk_bok_deviceresources.AvailableResourceCombination_RefID And pps_tsk_bok_availableresourcecombinations.IsDeleted = 0 Left Join
  pps_tsk_bok_staffresources
    On
    pps_tsk_bok_availableresourcecombinations.PPS_TSK_BOK_AvailableResourceCombinationID = pps_tsk_bok_staffresources.AvailableResourceCombination_RefID And pps_tsk_bok_staffresources.IsDeleted = 0 Left Join
  pps_tsk_bok_bookabletimeslots_2_availabilitytypes
    On
    pps_tsk_bok_bookabletimeslots_2_availabilitytypes.PPS_TSK_BOK_BookableTimeSlot_RefID = pps_tsk_bok_bookabletimeslots.PPS_TSK_BOK_BookableTimeSlotID And pps_tsk_bok_bookabletimeslots_2_availabilitytypes.IsDeleted = 0 Left Join
  cmn_cal_ava_availability_types
    On
    pps_tsk_bok_bookabletimeslots_2_availabilitytypes.CMN_CAL_AVA_Availability_TypeID = cmn_cal_ava_availability_types.CMN_CAL_AVA_Availability_TypeID And cmn_cal_ava_availability_types.IsDeleted = 0
Where
  pps_tsk_bok_bookabletimeslots.Office_RefID = @OfficeID And
  pps_tsk_bok_bookabletimeslots.Tenant_RefID = @TenantID And
  pps_tsk_bok_bookabletimeslots.IsDeleted = 0 and 
  pps_tsk_bok_bookabletimeslots.FreeInterval_Start = @StartTime and
  pps_tsk_bok_bookabletimeslots.TaskTemplate_RefID = @TypeID
  