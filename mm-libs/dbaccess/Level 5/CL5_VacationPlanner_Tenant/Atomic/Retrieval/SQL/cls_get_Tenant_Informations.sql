
Select
  cmn_tenants.CMN_TenantID,
  cmn_tenants.IsUsing_WorkAreas,
  cmn_tenants.IsUsing_Offices,
  cmn_tenants.IsUsing_Workplaces,
  cmn_tenants.DocumentServerRootURL,
  cmn_universalcontactdetails.CMN_UniversalContactDetailID,
  cmn_universalcontactdetails.IsCompany,
  cmn_universalcontactdetails.CompanyName_Line1,
  cmn_universalcontactdetails.CompanyName_Line2,
  cmn_universalcontactdetails.WorkDescription,
  cmn_universalcontactdetails.Salutation,
  cmn_universalcontactdetails.Title,
  cmn_universalcontactdetails.First_Name,
  cmn_universalcontactdetails.Last_Name,
  cmn_universalcontactdetails.CareOf,
  cmn_universalcontactdetails.Country_Name,
  cmn_universalcontactdetails.Country_639_1_ISOCode,
  cmn_universalcontactdetails.Street_Number,
  cmn_universalcontactdetails.Street_Name,
  cmn_universalcontactdetails.PostalAddress_Number,
  cmn_universalcontactdetails.PostalAddress_Formatted,
  cmn_universalcontactdetails.ZIP,
  cmn_universalcontactdetails.Town,
  cmn_universalcontactdetails.Contact_Email,
  cmn_universalcontactdetails.Contact_Telephone,
  cmn_universalcontactdetails.Contact_Fax,
  cmn_bpt_sta_settingprofiles.CMN_BPT_STA_SettingProfileID,
  cmn_bpt_sta_settingprofiles.StafMember_Caption_DictID,
  cmn_bpt_sta_settingprofiles.IsLeaveTimeCalculated_InDays,
  cmn_bpt_sta_settingprofiles.IsLeaveTimeCalculated_InHours,
  cmn_bpt_sta_settingprofiles.IsUsingWorkflow_ForLeaveRequests,
  cmn_tenants.CMN_CAL_CalendarInstance_RefID,
  cmn_loc_regions.CMN_LOC_RegionID,
  cmn_loc_regions.Region_Name_DictID,
  cmn_bpt_sta_settingprofiles.Default_SurchargeCalculation_UseMaximum,
  cmn_bpt_sta_settingprofiles.Default_SurchargeCalculation_UseAccumulated
From
  cmn_tenants Inner Join
  cmn_universalcontactdetails
    On cmn_universalcontactdetails.CMN_UniversalContactDetailID =
    cmn_tenants.UniversalContactDetail_RefID Left Join
  cmn_bpt_sta_settingprofiles On cmn_tenants.CMN_BPT_STA_SettingProfile_RefID =
    cmn_bpt_sta_settingprofiles.CMN_BPT_STA_SettingProfileID Left Join
  cmn_loc_regions On cmn_universalcontactdetails.Region_RefID =
    cmn_loc_regions.CMN_LOC_RegionID
Where
  cmn_tenants.CMN_TenantID = @TenantID And
  cmn_universalcontactdetails.IsCompany = 1 And
  cmn_universalcontactdetails.IsDeleted = 0 And
  cmn_tenants.IsDeleted = 0 And
  (cmn_loc_regions.IsDeleted = 0 Or
    cmn_loc_regions.IsDeleted Is Null)
  