
    
Select 
   Count(*) As NumberOfMatches
From
  cmn_str_costcenters Inner Join
  cmn_str_costcenters_de On cmn_str_costcenters.Name_DictID =
  cmn_str_costcenters_de.DictID
Where
  Lower(cmn_str_costcenters_de.Content) = Lower(@Name) And
  cmn_str_costcenters.IsDeleted = 0 And
  cmn_str_costcenters.Tenant_RefID = @TenantID And
  cmn_str_costcenters_de.Language_RefID = @LanguageID
  
