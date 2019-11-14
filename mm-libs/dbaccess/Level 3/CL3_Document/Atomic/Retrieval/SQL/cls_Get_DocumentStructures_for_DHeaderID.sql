
    Select
      doc_structures.DOC_StructureID,
      doc_structures.Label,
      doc_structures.Parent_RefID,
      doc_structures.Structure_Header_RefID
    From
      doc_structures
    Where
      doc_structures.Structure_Header_RefID = @DHeaderID And
      doc_structures.IsDeleted = 0
  