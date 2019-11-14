
  Select
      doc_structures.DOC_StructureID,
      doc_structures.Label,
      doc_structures.Parent_RefID,
      doc_structures.Structure_Header_RefID
  From
      doc_structures Inner Join
      doc_structure_headers On doc_structures.Structure_Header_RefID =
      doc_structure_headers.DOC_Structure_HeaderID Inner Join
      tmp_pro_milestones On tmp_pro_milestones.DOC_Structure_Header_RefID =
      doc_structure_headers.DOC_Structure_HeaderID
  Where
      doc_structures.IsDeleted = 0 And
      doc_structure_headers.IsDeleted = 0 And
      tmp_pro_milestones.IsDeleted = 0 And
      tmp_pro_milestones.Tenant_RefID = @TenantID And
      tmp_pro_milestones.TMP_PRO_MilestoneID = @ID  
  