

Select distinct
  pps_tsk_bok_bookabletimeslots.FreeInterval_End,
  pps_tsk_bok_bookabletimeslots.FreeInterval_Start,
  pps_tsk_bok_bookabletimeslots.TaskTemplate_RefID,
  pps_tsk_bok_bookabletimeslots.FreeSlotsForTaskTemplateITPL,
  pps_tsk_bok_bookabletimeslots.PPS_TSK_BOK_BookableTimeSlotID
From
  pps_tsk_bok_bookabletimeslots Inner Join pps_tsk_bok_availableresourcecombinations On 
  pps_tsk_bok_availableresourcecombinations.BookableTimeSlot_RefID = pps_tsk_bok_bookabletimeslots.PPS_TSK_BOK_BookableTimeSlotID  and 
  (pps_tsk_bok_availableresourcecombinations.IsAvailable = 1 or pps_tsk_bok_availableresourcecombinations.PPS_TSK_BOK_AvailableResourceCombinationID = @WithCombinationID) and
  pps_tsk_bok_availableresourcecombinations.IsDeleted = 0
  Where
  pps_tsk_bok_bookabletimeslots.IsDeleted = 0 And
  pps_tsk_bok_bookabletimeslots.Tenant_RefID = @TenantID And
  pps_tsk_bok_bookabletimeslots.Office_RefID = @OfficeID And
  pps_tsk_bok_bookabletimeslots.TaskTemplate_RefID = @TypeID and
  pps_tsk_bok_bookabletimeslots.FreeInterval_End <=@ToDate and
  pps_tsk_bok_bookabletimeslots.FreeInterval_Start >=@FromDate
  