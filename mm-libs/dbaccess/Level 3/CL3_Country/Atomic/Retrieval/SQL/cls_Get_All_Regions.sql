
	Select
	  cmn_loc_regions.CMN_LOC_RegionID,
	  cmn_loc_regions.Region_Name_DictID,
	  cmn_loc_regions.Parent_RefID,
	  cmn_loc_regions.RegionExternalID
	From
	  cmn_loc_regions
	Where
	  cmn_loc_regions.IsDeleted = 0
  