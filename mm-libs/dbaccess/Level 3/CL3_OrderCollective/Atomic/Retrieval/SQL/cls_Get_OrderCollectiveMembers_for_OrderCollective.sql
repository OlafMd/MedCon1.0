
SELECT
  ocl_ordercollective_members.OCL_OrderCollective_MemberID,
  ocl_ordercollective_members.OrderCollective_RefID,
  ocl_ordercollective_members.OrderCollectiveMemberITL,
  ocl_ordercollective_members.IsOrderCollectiveLead,
  ocl_ordercollective_members.BusinessParticipant_RefID,
  ocl_ordercollective_members.MemberSince,
  ocl_ordercollective_members.EndOfMembership,
  ocl_ordercollective_members.Creation_Timestamp,
  cmn_bpt_businessparticipants.DisplayName AS BusinessParticipantDispalyName,
  cmn_bpt_businessparticipants.BusinessParticipantITL,
  cmn_bpt_businessparticipants.IsCompany,
  cmn_universalcontactdetails.CMN_UniversalContactDetailID,
  cmn_universalcontactdetails.UniversalContactDetailsITL,
  cmn_universalcontactdetails.CompanyName_Line1 AS UniversalContactDetailCompanyName,
  cmn_universalcontactdetails.Contact_Email,
  cmn_tenants.CMN_TenantID AS MemberTenantID,
  cmn_tenants.TenantITL AS MemberTenantITL,
  CompanyInfoUCD.CMN_UniversalContactDetailID AS CompanyInfoUniversalContactDetailsID,
  CompanyInfoUCD.UniversalContactDetailsITL AS CompanyInfoUniversalContactDetailsITL
FROM ocl_ordercollective_members
INNER JOIN cmn_bpt_businessparticipants
  ON cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID = ocl_ordercollective_members.BusinessParticipant_RefID
  AND cmn_bpt_businessparticipants.Tenant_RefID = @TenantID
  AND cmn_bpt_businessparticipants.IsDeleted = 0
INNER JOIN cmn_tenants
  ON cmn_tenants.CMN_TenantID = cmn_bpt_businessparticipants.IfTenant_Tenant_RefID
  AND cmn_tenants.Tenant_RefID = @TenantID
  AND cmn_tenants.IsDeleted = 0
INNER JOIN cmn_universalcontactdetails
  ON cmn_universalcontactdetails.CMN_UniversalContactDetailID = cmn_tenants.UniversalContactDetail_RefID
  AND cmn_universalcontactdetails.Tenant_RefID = @TenantID
  AND cmn_universalcontactdetails.IsDeleted = 0
LEFT JOIN cmn_com_companyinfo
  ON cmn_com_companyinfo.CMN_COM_CompanyInfoID = cmn_bpt_businessparticipants.IfCompany_CMN_COM_CompanyInfo_RefID
  AND cmn_com_companyinfo.Tenant_RefID = @TenantID
  AND cmn_com_companyinfo.IsDeleted = 0
LEFT JOIN cmn_universalcontactdetails AS CompanyInfoUCD
  ON CompanyInfoUCD.CMN_UniversalContactDetailID = cmn_com_companyinfo.Contact_UCD_RefID
  AND CompanyInfoUCD.Tenant_RefID = @TenantID
  AND CompanyInfoUCD.IsDeleted = 0
WHERE
  ocl_ordercollective_members.OrderCollective_RefID = @OrderCollectiveID
  AND ocl_ordercollective_members.Tenant_RefID = @TenantID
  AND ocl_ordercollective_members.IsDeleted = 0
  