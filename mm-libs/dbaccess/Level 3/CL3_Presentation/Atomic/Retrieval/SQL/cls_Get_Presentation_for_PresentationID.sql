
	Select
	  cmn_cal_evt_presentations.CMN_CAL_EVT_PresentationID,
	  cmn_cal_evt_presentations.PresentationLocation,
	  cmn_cal_evt_presentations.MaximumNumberOfParticipants,
	  cmn_cal_evt_presentations.PresentationTitle_DictID,
	  cmn_cal_evt_presentations.PresentationDescription_DictID,
	  cmn_cal_events.StartTime,
	  cmn_cal_evt_presentations.IsFeaturedEvent,
	  cmn_cal_evt_presenters.PresenterDisplayName
	From
	  cmn_cal_evt_presentations Inner Join
	  cmn_cal_events On cmn_cal_evt_presentations.Ext_CMN_CAL_Calendar_RefID =
	    cmn_cal_events.CMN_CAL_EventID And cmn_cal_events.IsDeleted = 0 And
	    cmn_cal_events.Tenant_RefID = @TenantID Inner Join
	  cmn_cal_evt_presenters On cmn_cal_evt_presentations.CMN_CAL_EVT_PresentationID
	    = cmn_cal_evt_presenters.Presentation_RefID  And
	  cmn_cal_evt_presenters.Tenant_RefID = @TenantID And
	  cmn_cal_evt_presenters.IsDeleted = 0
	Where
	  cmn_cal_evt_presentations.IsDeleted = 0 And
	  cmn_cal_evt_presentations.Tenant_RefID = @TenantID And
	  cmn_cal_evt_presentations.CMN_CAL_EVT_PresentationID = @PresentationID
  