
        SELECT
          acc_fiscalyears.ACC_FiscalYearID,
          acc_fiscalyears.FiscalYearName,
          acc_fiscalyears.StartDate,
          acc_fiscalyears.EndDate
        FROM
          acc_fiscalyears
        WHERE
          acc_fiscalyears.IsDeleted = 0 
		  AND acc_fiscalyears.Tenant_RefID = @TenantID
          AND @ComparingDate between acc_fiscalyears.StartDate AND acc_fiscalyears.EndDate
          
  