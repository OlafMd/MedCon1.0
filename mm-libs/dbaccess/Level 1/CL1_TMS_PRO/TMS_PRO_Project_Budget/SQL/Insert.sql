INSERT INTO 
	tms_pro_project_budgets
	(
		TMS_PRO_Project_BudgetID,
		Project_RefID,
		BudgetFor_Month,
		BudgetFor_Year,
		BudgetLimit_Amount,
		UsedBudget_Amount,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@TMS_PRO_Project_BudgetID,
		@Project_RefID,
		@BudgetFor_Month,
		@BudgetFor_Year,
		@BudgetLimit_Amount,
		@UsedBudget_Amount,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)