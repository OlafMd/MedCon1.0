

    SELECT cmn_bpt_suppliers.CMN_BPT_SupplierID,
           cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID,
           cmn_bpt_businessparticipants.DisplayName,
           cmn_bpt_businessparticipants.DefaultLanguage_RefID,
           cmn_bpt_businessparticipants.DefaultCurrency_RefID,
           cmn_com_companyinfo.CMN_COM_CompanyInfoID,
           cmn_com_companyinfo.CompanyInfo_EstablishmentNumber,
           cmn_com_companyinfo.AnnualRevenueAmountValue_RefID,
           cmn_com_companyinfo.VATIdentificationNumber,
           cmn_universalcontactdetails.CompanyName_Line1,
           cmn_universalcontactdetails.Country_639_1_ISOCode,
           cmn_bpt_supplier_types.GlobalPropertyMatchingID,
           cmn_bpt_supplier_types.SupplierType_Name_DictID,
           cmn_bpt_supplier_types.CMN_BPT_Supplier_TypeID
      FROM cmn_bpt_suppliers
           INNER JOIN cmn_bpt_businessparticipants
              ON     cmn_bpt_suppliers.Ext_BusinessParticipant_RefID =
                        cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID
                 AND cmn_bpt_businessparticipants.IsDeleted = 0
                 AND cmn_bpt_businessparticipants.Tenant_RefID = @TenantID
           LEFT JOIN cmn_com_companyinfo
              ON     cmn_bpt_businessparticipants.IfCompany_CMN_COM_CompanyInfo_RefID =
                        cmn_com_companyinfo.CMN_COM_CompanyInfoID
                 AND cmn_com_companyinfo.IsDeleted = 0
                 AND cmn_com_companyinfo.Tenant_RefID = @TenantID
           LEFT JOIN cmn_universalcontactdetails
              ON     cmn_com_companyinfo.Contact_UCD_RefID =
                        cmn_universalcontactdetails.CMN_UniversalContactDetailID
                 AND cmn_universalcontactdetails.IsDeleted = 0
                 AND cmn_universalcontactdetails.Tenant_RefID = @TenantID
           LEFT JOIN cmn_bpt_supplier_types
              ON     cmn_bpt_supplier_types.CMN_BPT_Supplier_TypeID =
                        cmn_bpt_suppliers.SupplierType_RefID
                 AND cmn_bpt_supplier_types.IsDeleted = 0
                 AND cmn_bpt_supplier_types.Tenant_RefID = @TenantID
     WHERE     cmn_bpt_suppliers.CMN_BPT_SupplierID =
                  IfNull(@CMN_BPT_SupplierID,
                         cmn_bpt_suppliers.CMN_BPT_SupplierID)
           AND cmn_bpt_suppliers.IsDeleted = 0
           AND cmn_bpt_suppliers.Tenant_RefID = @TenantID
           AND cmn_bpt_suppliers.SupplierType_RefID IS NOT NULL
           AND cmn_bpt_suppliers.SupplierType_RefID !=
                  0x00000000000000000000000000000000
               
  