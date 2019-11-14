
Select
  cmn_str_pps_workplaces.CMN_STR_PPS_WorkplaceID,
  cmn_str_pps_workplaces.WorkArea_RefID,
  cmn_str_pps_workplaces.Name_DictID As WorkPlaceName_DictID,
  cmn_str_pps_workplaces.Description_DictID As WorkPlaceDescription_DictID,
  cmn_str_pps_workplaces.ShortName,
  cmn_str_pps_workplaces.CMN_CAL_CalendarInstance_RefID
From
  cmn_str_pps_workplaces
Where
  cmn_str_pps_workplaces.ShortName = @ShortName And
  cmn_str_pps_workplaces.IsDeleted = 0 And
  cmn_str_pps_workplaces.Tenant_RefID = @TenantID
  