
        Select
          doc_structures.DOC_StructureID,
          doc_structures.Label,
          doc_structures.Parent_RefID,
          doc_structures.Structure_Header_RefID
      From
          doc_structures Inner Join
          doc_structure_headers On doc_structures.Structure_Header_RefID =
          doc_structure_headers.DOC_Structure_HeaderID Inner Join
          tms_pro_developertasks On tms_pro_developertasks.DOC_Structure_Header_RefID =
          doc_structure_headers.DOC_Structure_HeaderID
      Where
          doc_structures.IsDeleted = 0 And
          doc_structure_headers.IsDeleted = 0 And
          tms_pro_developertasks.IsDeleted = 0 And
          tms_pro_developertasks.Tenant_RefID = @TenantID And
          tms_pro_developertasks.TMS_PRO_DeveloperTaskID = @ID
  