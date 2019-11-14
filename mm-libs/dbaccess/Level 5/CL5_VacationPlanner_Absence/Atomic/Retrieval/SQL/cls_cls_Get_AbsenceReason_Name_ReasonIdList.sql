
	Select
	  cmn_bpt_sta_absencereasons.Name_DictID,
	  cmn_bpt_sta_absencereasons.ShortName,
	  cmn_bpt_sta_absencereasons.CMN_BPT_STA_AbsenceReasonID
	From
	  cmn_bpt_sta_absencereasons
	Where
	  cmn_bpt_sta_absencereasons.CMN_BPT_STA_AbsenceReasonID = @ReasonIdList
  