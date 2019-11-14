
Select Distinct
  pps_tsk_bok_bookabletimeslots.FreeInterval_End,
  pps_tsk_bok_bookabletimeslots.FreeInterval_Start,
  pps_tsk_bok_bookabletimeslots.TaskTemplate_RefID,
  pps_tsk_bok_bookabletimeslots.FreeSlotsForTaskTemplateITPL,
  pps_tsk_bok_bookabletimeslots.PPS_TSK_BOK_BookableTimeSlotID
From
  pps_tsk_bok_bookabletimeslots Inner Join pps_tsk_bok_bookabletimeslots_2_availabilitytypes
    On
    pps_tsk_bok_bookabletimeslots_2_availabilitytypes.PPS_TSK_BOK_BookableTimeSlot_RefID = pps_tsk_bok_bookabletimeslots.PPS_TSK_BOK_BookableTimeSlotID 
    And pps_tsk_bok_bookabletimeslots_2_availabilitytypes.IsDeleted = 0 
    Inner Join cmn_cal_ava_availability_types On
    pps_tsk_bok_bookabletimeslots_2_availabilitytypes.CMN_CAL_AVA_Availability_TypeID = cmn_cal_ava_availability_types.CMN_CAL_AVA_Availability_TypeID And 
    cmn_cal_ava_availability_types.IsDeleted = 0 And 
    cmn_cal_ava_availability_types.GlobalPropertyMatchingID = @AvaTypeMachingID 
    Inner Join pps_tsk_bok_availableresourcecombinations On 
    pps_tsk_bok_bookabletimeslots.PPS_TSK_BOK_BookableTimeSlotID = pps_tsk_bok_availableresourcecombinations.BookableTimeSlot_RefID And
    pps_tsk_bok_availableresourcecombinations.IsAvailable = 1 and 
    pps_tsk_bok_availableresourcecombinations.IsDeleted = 0
Where
  pps_tsk_bok_bookabletimeslots.FreeInterval_End <= @ToDate And
  pps_tsk_bok_bookabletimeslots.FreeInterval_Start >= @FromDate And
  pps_tsk_bok_bookabletimeslots.TaskTemplate_RefID = @TypeID And
  pps_tsk_bok_bookabletimeslots.IsDeleted = 0 And
  pps_tsk_bok_bookabletimeslots.Tenant_RefID = @TenantID And
  pps_tsk_bok_bookabletimeslots.Office_RefID = @OfficeID
  