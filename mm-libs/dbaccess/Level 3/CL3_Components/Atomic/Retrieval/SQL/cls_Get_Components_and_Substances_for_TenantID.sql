
    Select
      hec_pro_product_components.HEC_PRO_Product_RefID,
      hec_pro_components.Component_SimpleName,
      hec_sub_substances.GlobalPropertyMatchingID as SubstanceName,
      hec_sub_substances.IsActiveComponent,
      hec_pro_components.HEC_PRO_ComponentID,
      hec_sub_substances.HEC_SUB_SubstanceID
    From
      hec_pro_components Inner Join
      hec_pro_product_components
        On hec_pro_product_components.HEC_PRO_Component_RefID =
        hec_pro_components.HEC_PRO_ComponentID Inner Join
      hec_pro_component_substanceingredients
        On hec_pro_component_substanceingredients.Component_RefID =
        hec_pro_components.HEC_PRO_ComponentID Inner Join
      hec_sub_substances On hec_pro_component_substanceingredients.Substance_RefID =
        hec_sub_substances.HEC_SUB_SubstanceID
    Where
      hec_sub_substances.IsDeleted = 0 And
      hec_pro_product_components.IsDeleted = 0 And
      hec_pro_components.IsDeleted = 0 And
      hec_pro_component_substanceingredients.IsDeleted = 0 And
      hec_pro_product_components.Tenant_RefID = @TenantID
  