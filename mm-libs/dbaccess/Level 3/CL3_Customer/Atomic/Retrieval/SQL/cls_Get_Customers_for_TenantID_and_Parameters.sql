
        SELECT
          cmn_bpt_ctm_customers.CMN_BPT_CTM_CustomerID,
          cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID,
          cmn_universalcontactdetails.CompanyName_Line1,
          cmn_com_companyinfo.CMN_COM_CompanyInfoID,
          cmn_bpt_ctm_availablepaymenttypes.ACC_PAY_Type_RefID AS PaymentTypeID,
          cmn_bpt_businessparticipants.DisplayName AS Customer_DisplayName,
          LegalGuardian.DisplayName As LegalGuardian_DisplayName,
          cmn_bpt_ctm_customers.InternalCustomerNumber
        FROM cmn_bpt_businessparticipants 
        INNER JOIN cmn_bpt_ctm_customers ON cmn_bpt_ctm_customers.Ext_BusinessParticipant_RefID = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID 
          AND cmn_bpt_ctm_customers.IsDeleted = 0
          AND cmn_bpt_ctm_customers.Tenant_RefID = @TenantID
        INNER JOIN cmn_com_companyinfo ON cmn_bpt_businessparticipants.IfCompany_CMN_COM_CompanyInfo_RefID = cmn_com_companyinfo.CMN_COM_CompanyInfoID 
          AND cmn_com_companyinfo.IsDeleted = 0
          AND cmn_com_companyinfo.Tenant_RefID = @TenantID
        INNER JOIN cmn_universalcontactdetails ON cmn_com_companyinfo.Contact_UCD_RefID = cmn_universalcontactdetails.CMN_UniversalContactDetailID 
          AND cmn_universalcontactdetails.IsCompany = 1
          AND cmn_universalcontactdetails.IsDeleted = 0
          AND cmn_universalcontactdetails.Tenant_RefID = @TenantID
        LEFT OUTER JOIN cmn_bpt_ctm_availablepaymenttypes ON cmn_bpt_ctm_availablepaymenttypes.Customer_RefID = cmn_bpt_ctm_customers.CMN_BPT_CTM_CustomerID
          AND cmn_bpt_ctm_availablepaymenttypes.IsDeleted = 0
          AND cmn_bpt_ctm_availablepaymenttypes.Tenant_RefID = @TenantID
        LEFT OUTER JOIN cmn_bpt_businessparticipant_associatedbusinessparticipants ON cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID = cmn_bpt_businessparticipant_associatedbusinessparticipants.BusinessParticipant_RefID 
         AND cmn_bpt_businessparticipant_associatedbusinessparticipants.IsDeleted = 0 
        LEFT OUTER JOIN cmn_bpt_businessparticipants LegalGuardian ON cmn_bpt_businessparticipant_associatedbusinessparticipants.AssociatedBusinessParticipant_RefID = LegalGuardian.CMN_BPT_BusinessParticipantID
          AND LegalGuardian.IsDeleted = 0
          AND LegalGuardian.Tenant_RefID = @TenantID
        WHERE
          cmn_bpt_businessparticipants.IsDeleted = 0
          AND cmn_bpt_businessparticipants.Tenant_RefID = @TenantID
          AND cmn_bpt_businessparticipants.IsCompany = 1
          AND cmn_bpt_businessparticipants.IsTenant = 1
          AND (@CustomerID IS NULL OR cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID = @CustomerID)
          AND (@Customer_NameOrNumber IS NULL OR (@Customer_NameOrNumber IS NOT NULL AND 
            ( LOWER(cmn_bpt_ctm_customers.InternalCustomerNumber) LIKE CONCAT('%',  LOWER(@Customer_NameOrNumber), '%') 
              OR  LOWER(cmn_bpt_businessparticipants.DisplayName) LIKE CONCAT('%', LOWER(@Customer_NameOrNumber), '%') 
            )))
          
  