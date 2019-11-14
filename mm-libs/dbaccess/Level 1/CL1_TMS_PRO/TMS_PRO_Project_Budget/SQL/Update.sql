UPDATE 
	tms_pro_project_budgets
SET 
	Project_RefID=@Project_RefID,
	BudgetFor_Month=@BudgetFor_Month,
	BudgetFor_Year=@BudgetFor_Year,
	BudgetLimit_Amount=@BudgetLimit_Amount,
	UsedBudget_Amount=@UsedBudget_Amount,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	TMS_PRO_Project_BudgetID = @TMS_PRO_Project_BudgetID