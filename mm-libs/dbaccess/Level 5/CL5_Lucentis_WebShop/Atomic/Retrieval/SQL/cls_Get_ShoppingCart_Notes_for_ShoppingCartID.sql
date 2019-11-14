
		Select
		  ord_prc_shoppingcart_notes.ORD_PRC_ShoppingCart_RefID As ShoppingCartID,
		  cmn_per_personinfo.FirstName,
		  cmn_per_personinfo.LastName,
		  cmn_bpt_memos.CreatedBy_Account_RefID,
		  ord_prc_shoppingcart_notes.ORD_PRC_ShoppingCart_NoteID As ShoppingCartNoteID,
		  ord_prc_shoppingcart_notes.CMN_BPT_Memo_RefID,
		  cmn_bpt_memos.Memo_Text,
		  cmn_bpt_memos.UpdatedOn
		From
		  ord_prc_shoppingcart_notes Inner Join
		  cmn_bpt_memos On cmn_bpt_memos.CMN_BPT_MemoID =
			ord_prc_shoppingcart_notes.CMN_BPT_Memo_RefID And
			cmn_bpt_memos.Tenant_RefID = @TenantID And 
			cmn_bpt_memos.IsDeleted = 0
		  Inner Join
		  cmn_per_personinfo_2_account On cmn_bpt_memos.CreatedBy_Account_RefID =
			cmn_per_personinfo_2_account.USR_Account_RefID And
			cmn_per_personinfo_2_account.Tenant_RefID = @TenantID
		  Inner Join
		  cmn_per_personinfo On cmn_per_personinfo_2_account.CMN_PER_PersonInfo_RefID =
			cmn_per_personinfo.CMN_PER_PersonInfoID And
			cmn_per_personinfo.Tenant_RefID = @TenantID
		Where
		  ord_prc_shoppingcart_notes.ORD_PRC_ShoppingCart_RefID = @ShoppingCartID And
		  ord_prc_shoppingcart_notes.Tenant_RefID = @TenantID And
		  ord_prc_shoppingcart_notes.IsDeleted = 0
  