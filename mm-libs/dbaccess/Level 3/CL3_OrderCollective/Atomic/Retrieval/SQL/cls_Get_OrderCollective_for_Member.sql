
SELECT
  ocl_ordercollectives.OCL_OrderCollectiveID,
  ocl_ordercollectives.OrderCollective_Name_DictID,
  ocl_ordercollectives.Creation_Timestamp,
  LeadMember.OCL_OrderCollective_MemberID AS LeadMemberID,
  LeadMemberBusinessParticipant.DisplayName AS LeadBusinessParticipantName,
  LeadUniversalContactDetail.CompanyName_Line1 AS LeadCompanyName,
  COUNT(ocl_ordercollective_members.OCL_OrderCollective_MemberID) AS OrderCollectiveMembersCount
FROM ocl_ordercollectives
INNER JOIN ocl_ordercollective_members
  ON ocl_ordercollective_members.OrderCollective_RefID = ocl_ordercollectives.OCL_OrderCollectiveID
  AND ocl_ordercollective_members.Tenant_RefID = @TenantID
  AND ocl_ordercollective_members.IsDeleted = 0
INNER JOIN cmn_bpt_businessparticipants AS CurrentBusinessParticipant
  ON CurrentBusinessParticipant.IfTenant_Tenant_RefID = @TenantID
  AND CurrentBusinessParticipant.Tenant_RefID = @TenantID
  AND CurrentBusinessParticipant.IsDeleted = 0
INNER JOIN ocl_ordercollective_members AS LeadMember
  ON LeadMember.OrderCollective_RefID = ocl_ordercollectives.OCL_OrderCollectiveID
  AND LeadMember.IsOrderCollectiveLead = 1
  AND LeadMember.Tenant_RefID = @TenantID
  AND LeadMember.IsDeleted = 0
INNER JOIN cmn_bpt_businessparticipants AS LeadMemberBusinessParticipant
  ON LeadMemberBusinessParticipant.CMN_BPT_BusinessParticipantID = LeadMember.BusinessParticipant_RefID
  AND LeadMemberBusinessParticipant.Tenant_RefID = @TenantID
  AND LeadMemberBusinessParticipant.IsDeleted = 0
LEFT JOIN cmn_tenants AS LeadTenant
  ON LeadTenant.CMN_TenantID = LeadMemberBusinessParticipant.IfTenant_Tenant_RefID
  AND LeadTenant.Tenant_RefID = @TenantID
  AND LeadTenant.IsDeleted = 0 
LEFT JOIN cmn_universalcontactdetails AS LeadUniversalContactDetail
  ON LeadUniversalContactDetail.CMN_UniversalContactDetailID = LeadTenant.UniversalContactDetail_RefID
  AND LeadUniversalContactDetail.Tenant_RefID = @TenantID
  AND LeadUniversalContactDetail.IsDeleted = 0 
WHERE
  ocl_ordercollectives.Tenant_RefID = @TenantID
  AND ocl_ordercollectives.IsDeleted = 0
  AND EXISTS (
    SELECT 1 FROM ocl_ordercollective_members
    WHERE
      ocl_ordercollective_members.OrderCollective_RefID = ocl_ordercollectives.OCL_OrderCollectiveID
      AND ocl_ordercollective_members.Tenant_RefID = @TenantID
      AND ocl_ordercollective_members.IsOrderCollectiveLead = @IsMemberLead
      AND ocl_ordercollective_members.BusinessParticipant_RefID = CurrentBusinessParticipant.CMN_BPT_BusinessParticipantID)
GROUP BY 
  ocl_ordercollectives.OCL_OrderCollectiveID;
  