
    Select
      Count(hec_bil_potentialcode_2_healthcareproduct.AssignmentID) as AssignmentCount
    From
      hec_bil_potentialcode_2_potentialdiagnosis
      Inner Join hec_bil_potentialcode_2_healthcareproduct On hec_bil_potentialcode_2_healthcareproduct.HEC_BIL_PotentialCode_RefID =
        hec_bil_potentialcode_2_potentialdiagnosis.HEC_BIL_PotentialCode_RefID And
        hec_bil_potentialcode_2_healthcareproduct.IsDeleted = 0 And
        hec_bil_potentialcode_2_healthcareproduct.Tenant_RefID = @TenantID 
    Where
      hec_bil_potentialcode_2_potentialdiagnosis.HEC_BIL_PotentialCode_RefID = @GposID And
      hec_bil_potentialcode_2_potentialdiagnosis.Tenant_RefID = @TenantID And
      hec_bil_potentialcode_2_potentialdiagnosis.IsDeleted = 0
	