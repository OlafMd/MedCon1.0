
Select
  bil_billposition_propertyvalue.PropertyValue As value,
  hec_cas_case_billcodes.HEC_CAS_Case_RefID As case_id,
  hec_bil_potentialcode_catalogs.GlobalPropertyMatchingID As gpos_type
From
  hec_cas_cases Inner Join
  hec_cas_case_billcodes
    On hec_cas_case_billcodes.HEC_CAS_Case_RefID = hec_cas_cases.HEC_CAS_CaseID And hec_cas_case_billcodes.Tenant_RefID = @TenantID And
    hec_cas_case_billcodes.IsDeleted = 0 Inner Join
  hec_bil_billposition_billcodes
    On hec_cas_case_billcodes.HEC_BIL_BillPosition_BillCode_RefID = hec_bil_billposition_billcodes.HEC_BIL_BillPosition_BillCodeID And
    hec_cas_case_billcodes.Tenant_RefID = @TenantID And hec_cas_case_billcodes.IsDeleted = 0 Inner Join
  hec_bil_potentialcodes
    On hec_bil_billposition_billcodes.PotentialCode_RefID = hec_bil_potentialcodes.HEC_BIL_PotentialCodeID And hec_bil_potentialcodes.Tenant_RefID = @TenantID
    And hec_bil_potentialcodes.IsDeleted = 0 Inner Join
  hec_bil_potentialcode_catalogs
    On hec_bil_potentialcodes.PotentialCode_Catalog_RefID = hec_bil_potentialcode_catalogs.HEC_BIL_PotentialCode_CatalogID And
    hec_bil_potentialcode_catalogs.Tenant_RefID = @TenantID And hec_bil_potentialcode_catalogs.IsDeleted = 0 Inner Join
  hec_bil_billpositions
    On hec_bil_billposition_billcodes.BillPosition_RefID = hec_bil_billpositions.HEC_BIL_BillPositionID And hec_bil_billpositions.Tenant_RefID = @TenantID And
    hec_bil_billpositions.IsDeleted = 0 Inner Join
  bil_billposition_propertyvalue
    On hec_bil_billpositions.Ext_BIL_BillPosition_RefID = bil_billposition_propertyvalue.BIL_BillPosition_RefID And bil_billposition_propertyvalue.PropertyKey =
    'mm.doc.connect.management.fee' And bil_billposition_propertyvalue.Tenant_RefID = @TenantID And bil_billposition_propertyvalue.IsDeleted = 0
Where
  hec_cas_cases.Patient_RefID = @PatientID And
  hec_cas_cases.Tenant_RefID = @TenantID And
  hec_cas_cases.IsDeleted = 0
	