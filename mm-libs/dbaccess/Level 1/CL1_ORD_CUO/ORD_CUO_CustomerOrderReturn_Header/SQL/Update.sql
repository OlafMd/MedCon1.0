UPDATE 
	ord_cuo_customerorderreturn_headers
SET 
	Customer_RefID=@Customer_RefID,
	CorrespondingReceiptHeader_RefID=@CorrespondingReceiptHeader_RefID,
	DateOfCustomerReturn=@DateOfCustomerReturn,
	CustomerOrderReturnNumber=@CustomerOrderReturnNumber,
	Currency_RefID=@Currency_RefID,
	TotalValueBeforeTax=@TotalValueBeforeTax,
	Customer_BillingAddressUCD_RefID=@Customer_BillingAddressUCD_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	ORD_CUO_CustomerOrderReturn_HeaderID = @ORD_CUO_CustomerOrderReturn_HeaderID