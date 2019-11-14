
Select
  hec_medicalpractice_2_universalproperty.Value_Boolean As OrderDrugs,
  hec_medicalpractice_2_universalproperty1.Value_Number As
  DefaultShippingDateOffset,
  hec_medicalpractice_2_universalproperty2.Value_Boolean As OnlyLabelRequired,
  hec_medicalpractice_2_universalproperty3.Value_Boolean As WaiveServiceFee
From
  hec_medicalpractises Inner Join
  hec_medicalpractice_2_universalproperty
    On hec_medicalpractises.HEC_MedicalPractiseID =
    hec_medicalpractice_2_universalproperty.HEC_MedicalPractice_RefID And
    hec_medicalpractice_2_universalproperty.Tenant_RefID =
    @TenantID And
    hec_medicalpractice_2_universalproperty.IsDeleted = 0 Inner Join
  hec_medicalpractice_universalproperties
    On
    hec_medicalpractice_2_universalproperty.HEC_MedicalPractice_UniversalProperty_RefID = hec_medicalpractice_universalproperties.HEC_MedicalPractice_UniversalPropertyID And hec_medicalpractice_universalproperties.PropertyName = "Order Drugs" And hec_medicalpractice_universalproperties.Tenant_RefID = @TenantID And hec_medicalpractice_universalproperties.IsDeleted = 0 And hec_medicalpractice_universalproperties.IsValue_Boolean = 1 Inner Join
  hec_medicalpractice_2_universalproperty
  hec_medicalpractice_2_universalproperty1
    On hec_medicalpractises.HEC_MedicalPractiseID =
    hec_medicalpractice_2_universalproperty1.HEC_MedicalPractice_RefID
    And hec_medicalpractice_2_universalproperty1.Tenant_RefID =
    @TenantID And
    hec_medicalpractice_2_universalproperty1.IsDeleted = 0 Inner Join
  hec_medicalpractice_universalproperties
  hec_medicalpractice_universalproperties1
    On
    hec_medicalpractice_2_universalproperty1.HEC_MedicalPractice_UniversalProperty_RefID = hec_medicalpractice_universalproperties1.HEC_MedicalPractice_UniversalPropertyID And hec_medicalpractice_universalproperties1.IsValue_Number = 1 And hec_medicalpractice_universalproperties1.PropertyName = 'Default Shipping Date Offset' And hec_medicalpractice_universalproperties1.Tenant_RefID = @TenantID And hec_medicalpractice_universalproperties1.IsDeleted = 0 Inner Join
  hec_medicalpractice_2_universalproperty
  hec_medicalpractice_2_universalproperty2
    On hec_medicalpractises.HEC_MedicalPractiseID =
    hec_medicalpractice_2_universalproperty2.HEC_MedicalPractice_RefID
    And hec_medicalpractice_2_universalproperty2.IsDeleted = 0 And
    hec_medicalpractice_2_universalproperty2.Tenant_RefID =
    @TenantID Inner Join
  hec_medicalpractice_universalproperties
  hec_medicalpractice_universalproperties2
    On
    hec_medicalpractice_2_universalproperty2.HEC_MedicalPractice_UniversalProperty_RefID = hec_medicalpractice_universalproperties2.HEC_MedicalPractice_UniversalPropertyID And hec_medicalpractice_universalproperties2.IsDeleted = 0 And hec_medicalpractice_universalproperties2.Tenant_RefID = @TenantID And hec_medicalpractice_universalproperties2.PropertyName = "Only Label Required" And hec_medicalpractice_universalproperties2.IsValue_Boolean = 1 Inner Join
  hec_medicalpractice_2_universalproperty
  hec_medicalpractice_2_universalproperty3
    On hec_medicalpractises.HEC_MedicalPractiseID =
    hec_medicalpractice_2_universalproperty3.HEC_MedicalPractice_RefID
    And hec_medicalpractice_2_universalproperty3.Tenant_RefID =
    @TenantID And
    hec_medicalpractice_2_universalproperty3.IsDeleted = 0 Inner Join
  hec_medicalpractice_universalproperties
  hec_medicalpractice_universalproperties3
    On
    hec_medicalpractice_2_universalproperty3.HEC_MedicalPractice_UniversalProperty_RefID = hec_medicalpractice_universalproperties3.HEC_MedicalPractice_UniversalPropertyID And hec_medicalpractice_universalproperties3.IsDeleted = 0 And hec_medicalpractice_universalproperties3.Tenant_RefID = @TenantID And hec_medicalpractice_universalproperties3.PropertyName = "Waive Service Fee" And hec_medicalpractice_universalproperties3.IsValue_Boolean = 1
Where
  hec_medicalpractises.HEC_MedicalPractiseID = @PracticeID And
  hec_medicalpractises.Tenant_RefID = @TenantID And
  hec_medicalpractises.IsDeleted = 0             
Group By
  hec_medicalpractises.HEC_MedicalPractiseID
	