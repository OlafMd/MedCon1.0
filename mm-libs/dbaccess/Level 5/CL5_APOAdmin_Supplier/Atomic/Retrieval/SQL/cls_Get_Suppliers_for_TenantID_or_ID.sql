
     SELECT
         cmn_bpt_suppliers.CMN_BPT_SupplierID
        ,cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID
        ,cmn_bpt_suppliers.IsDeleted
        ,cmn_bpt_businessparticipants.DisplayName
        ,cmn_bpt_businessparticipants.DefaultLanguage_RefID
        ,cmn_bpt_businessparticipants.DefaultCurrency_RefID
        ,cmn_com_companyinfo.CMN_COM_CompanyInfoID
        ,cmn_com_companyinfo.CompanyInfo_EstablishmentNumber
        ,cmn_com_companyinfo.AnnualRevenueAmountValue_RefID
        ,cmn_com_companyinfo.VATIdentificationNumber
        ,cmn_universalcontactdetails.CompanyName_Line1
        ,cmn_universalcontactdetails.Country_639_1_ISOCode
        ,cmn_bpt_supplier_types.CMN_BPT_Supplier_TypeID
        ,cmn_bpt_supplier_types.GlobalPropertyMatchingID AS SupplierType
        ,cmn_bpt_suppliers.ExternalSupplierProvidedIdentifier
        ,cmn_bpt_supplier_discountvalues.DiscountValue_in_percent
        ,ord_prc_discounttypes.GlobalPropertyMatchingID AS DiscountType

    FROM cmn_bpt_suppliers
    INNER JOIN cmn_bpt_businessparticipants
        ON cmn_bpt_suppliers.Ext_BusinessParticipant_RefID = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID
        AND cmn_bpt_businessparticipants.IsDeleted = 0
    LEFT JOIN cmn_com_companyinfo
        ON cmn_bpt_businessparticipants.IfCompany_CMN_COM_CompanyInfo_RefID = cmn_com_companyinfo.CMN_COM_CompanyInfoID
        AND cmn_com_companyinfo.IsDeleted = 0
    LEFT JOIN cmn_universalcontactdetails 
        ON cmn_com_companyinfo.Contact_UCD_RefID = cmn_universalcontactdetails.CMN_UniversalContactDetailID
        AND cmn_universalcontactdetails.IsDeleted = 0
    LEFT JOIN cmn_bpt_supplier_types
        ON cmn_bpt_suppliers.SupplierType_RefID = cmn_bpt_supplier_types.CMN_BPT_Supplier_TypeID
        AND cmn_bpt_supplier_types.IsDeleted = 0
    LEFT JOIN cmn_bpt_supplier_discountvalues
        ON cmn_bpt_supplier_discountvalues.Supplier_RefID = cmn_bpt_suppliers.CMN_BPT_SupplierID
        AND cmn_bpt_supplier_discountvalues.IsDeleted = 0
        AND cmn_bpt_supplier_discountvalues.Tenant_RefID = @TenantID
    LEFT JOIN ord_prc_discounttypes
        ON ord_prc_discounttypes.ORD_PRC_DiscountTypeID = cmn_bpt_supplier_discountvalues.ORD_PRC_DiscountType_RefID
        AND ord_prc_discounttypes.IsDeleted = 0
        AND ord_prc_discounttypes.Tenant_RefID = @TenantID	 
        AND 
        (
            ord_prc_discounttypes.GlobalPropertyMatchingID = @GlobalMatching_CashDiscount OR
            ord_prc_discounttypes.GlobalPropertyMatchingID = @GlobalMatching_MainDiscount
        )
    WHERE 
        cmn_bpt_suppliers.CMN_BPT_SupplierID = IfNull(@CMN_BPT_SupplierID, cmn_bpt_suppliers.CMN_BPT_SupplierID)
        AND cmn_bpt_suppliers.IsDeleted = 0
        AND cmn_bpt_suppliers.Tenant_RefID = @TenantID

  