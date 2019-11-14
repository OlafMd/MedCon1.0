
      Select
          doc_structures.DOC_StructureID,
          doc_structures.Label,
          doc_structures.Parent_RefID,
          doc_structures.Structure_Header_RefID
      From
          doc_structures Inner Join
          doc_structure_headers On doc_structures.Structure_Header_RefID =
          doc_structure_headers.DOC_Structure_HeaderID Inner Join
          tms_pro_feature On tms_pro_feature.DOC_Structure_Header_RefID =
          doc_structure_headers.DOC_Structure_HeaderID
      Where
          doc_structures.IsDeleted = 0 And
          doc_structure_headers.IsDeleted = 0 And
          tms_pro_feature.IsDeleted = 0 And
          tms_pro_feature.Tenant_RefID = @TenantID And
          tms_pro_feature.TMS_PRO_FeatureID = @ID  
  