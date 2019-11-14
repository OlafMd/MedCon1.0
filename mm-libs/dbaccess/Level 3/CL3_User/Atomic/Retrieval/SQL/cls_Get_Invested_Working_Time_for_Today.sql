
  Select
    cmn_bpt_investedworktimes.WorkTime_Amount_min,
    cmn_bpt_investedworktimes.WorkTime_Start
  From
    cmn_bpt_investedworktimes Inner Join
    usr_accounts On usr_accounts.BusinessParticipant_RefID =
      cmn_bpt_investedworktimes.BusinessParticipant_RefID
  Where
    cmn_bpt_investedworktimes.WorkTime_Start > CurDate() And
    usr_accounts.IsDeleted = 0 And
    cmn_bpt_investedworktimes.IsDeleted = 0 And
    usr_accounts.USR_AccountID = @AccountID
  