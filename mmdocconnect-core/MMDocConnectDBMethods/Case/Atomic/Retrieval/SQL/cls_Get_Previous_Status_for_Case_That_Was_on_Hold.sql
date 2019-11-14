
      Select
        bil_billposition_transmitionstatuses.TransmitionCode As previous_status
      From
        bil_billposition_transmitionstatuses Inner Join
        hec_bil_billpositions On hec_bil_billpositions.Ext_BIL_BillPosition_RefID =
          bil_billposition_transmitionstatuses.BillPosition_RefID And
          hec_bil_billpositions.Tenant_RefID = @TenantID And
          hec_bil_billpositions.IsDeleted = 0 Inner Join
        hec_bil_billposition_billcodes
          On hec_bil_billposition_billcodes.BillPosition_RefID =
          hec_bil_billpositions.HEC_BIL_BillPositionID And
          hec_bil_billposition_billcodes.Tenant_RefID =
          @TenantID And
          hec_bil_billposition_billcodes.IsDeleted = 0 Inner Join
        hec_cas_case_billcodes
          On hec_cas_case_billcodes.HEC_BIL_BillPosition_BillCode_RefID =
          hec_bil_billposition_billcodes.HEC_BIL_BillPosition_BillCodeID And
          hec_cas_case_billcodes.Tenant_RefID = @TenantID
          And hec_cas_case_billcodes.IsDeleted = 0 And
          hec_cas_case_billcodes.HEC_CAS_Case_RefID =
          @CaseID Inner Join
        hec_bil_potentialcodes On hec_bil_billposition_billcodes.PotentialCode_RefID =
          hec_bil_potentialcodes.HEC_BIL_PotentialCodeID And
          hec_bil_potentialcodes.Tenant_RefID = @TenantID
          And hec_bil_potentialcodes.IsDeleted = 0 Inner Join
        hec_bil_potentialcode_catalogs
          On hec_bil_potentialcodes.PotentialCode_Catalog_RefID =
          hec_bil_potentialcode_catalogs.HEC_BIL_PotentialCode_CatalogID And
          hec_bil_potentialcode_catalogs.Tenant_RefID =
          @TenantID And
          hec_bil_potentialcode_catalogs.IsDeleted = 0 And
          hec_bil_potentialcode_catalogs.GlobalPropertyMatchingID = @GPOSType
      Where
        bil_billposition_transmitionstatuses.TransmitionCode != 3 And
        bil_billposition_transmitionstatuses.IsDeleted = 0 And
        bil_billposition_transmitionstatuses.IsActive = 0 And
        bil_billposition_transmitionstatuses.Tenant_RefID =
        @TenantID
      Order By
        bil_billposition_transmitionstatuses.Creation_Timestamp Desc 
      Limit 1
	