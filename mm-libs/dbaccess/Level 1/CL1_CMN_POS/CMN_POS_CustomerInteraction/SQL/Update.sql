UPDATE 
	cmn_pos_customerinteractions
SET 
	CustomerOrderReturnHeader_RefID=@CustomerOrderReturnHeader_RefID,
	CustomerOrderHeader_RefID=@CustomerOrderHeader_RefID,
	IsCustomerOrderReturnInteraction=@IsCustomerOrderReturnInteraction,
	IsCustomerOrderInteraction=@IsCustomerOrderInteraction,
	CustomerInteractionNumber=@CustomerInteractionNumber,
	DateOfCustomerInteraction=@DateOfCustomerInteraction,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_POS_CustomerInteractionID = @CMN_POS_CustomerInteractionID