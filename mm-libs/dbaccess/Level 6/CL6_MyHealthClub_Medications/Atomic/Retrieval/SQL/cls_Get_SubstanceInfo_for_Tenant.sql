
	Select
  hec_sub_substances.HEC_SUB_SubstanceID,
  hec_sub_substances.GlobalPropertyMatchingID,
  hec_sub_substances.NarcoticAppendixStatus,
  hec_sub_substances.CategoryByLawStatus,
  hec_sub_substances.IsAntroposhopicalMedicine,
  hec_sub_substances.IsChemical,
  hec_sub_substances.IsHomeophaticMedicine,
  hec_sub_substances.IsCOSubstance,
  hec_sub_substances.IsExcipient,
  hec_sub_substances.IsDeleted,
  hec_sub_substances.IsFoodAdditive,
  hec_sub_substances.IsNaturalStimulant,
  hec_sub_substances.IsPerscriptionRequired,
  hec_sub_substances.IsAgriculturePesticide,
  hec_sub_substances.IsCosmeticSubstance,
  hec_sub_substances.IsActiveComponent,
  hec_sub_substances.Creation_Timestamp,
  hec_sub_substances.Tenant_RefID,
  hec_sub_substance_texts.Substance_RefID,
  hec_sub_substance_texts.SubstanceText_DictID,
  hec_sub_substance_texts.SubstanceText_Status,
  hec_sub_substance_texts.Modification_Timestamp As Modification_TimestampSubstanceTexts,
  hec_sub_substances.Modification_Timestamp As Modification_TimestampSubstances
From
  hec_sub_substances Inner Join
  hec_sub_substance_texts On hec_sub_substance_texts.Substance_RefID =
    hec_sub_substances.HEC_SUB_SubstanceID
Where
  hec_sub_substances.Tenant_RefID = @Tenant
  