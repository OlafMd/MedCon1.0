/* 
 * Generated on 11/7/2014 1:37:05 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 * Required Assemblies:
 * System.Runtime.Serialization
 * CSV2Core
 * CSV2Core_MySQL
 */
using System;
using System.Linq;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;
using System.Runtime.Serialization;
using CL2_Language.Atomic.Retrieval;
using CL1_HEC;
using CL1_CMN_PER;
using CL1_CMN_BPT;
using CL1_CMN_BPT_CTM;
using CL1_CMN;
using CL1_CMN_COM;
using CL1_PPS_TSK;

namespace CL5_MyHealthClub_Diagnosis.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_ReferralMedicalPractice.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_ReferralMedicalPractice
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5DI_SRMP_1425 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            P_L2LN_GALFTID_1530 langParam = new P_L2LN_GALFTID_1530();
            langParam.Tenant_RefID = securityTicket.TenantID;
            var DBLanguages = cls_Get_All_Languages_ForTenantID.Invoke(Connection, Transaction, langParam, securityTicket).Result;

            #region Save
            if (Parameter.HEC_MedicalPractiseID == Guid.Empty)
            {
                ORM_HEC_MedicalPractis medicalPractice = new ORM_HEC_MedicalPractis();
                medicalPractice.HEC_MedicalPractiseID = Guid.NewGuid();
                medicalPractice.IsHospital = Parameter.IsHospital;
                medicalPractice.Tenant_RefID = securityTicket.TenantID;
                medicalPractice.IsDeleted = false;
                medicalPractice.Save(Connection, Transaction);

                //*******************Save Medical Practice Type******************* 
                if (Parameter.MedicalPracticeType != null && Parameter.MedicalPracticeType.Count() > 0)
                {
                    foreach (var medicalPracticeTypeParam in Parameter.MedicalPracticeType)
                    {
                        if (!medicalPracticeTypeParam.IsDeleted)
                        {
                            ORM_HEC_MedicalPractice_2_PracticeType medicalPracticeType = new ORM_HEC_MedicalPractice_2_PracticeType();
                            medicalPracticeType.AssignmentID = Guid.NewGuid();
                            medicalPracticeType.HEC_MedicalPractice_Type_RefID = medicalPracticeTypeParam.HEC_MedicalPractice_TypeID;
                            medicalPracticeType.HEC_MedicalPractice_RefID = medicalPractice.HEC_MedicalPractiseID;
                            medicalPracticeType.Tenant_RefID = securityTicket.TenantID;
                            medicalPracticeType.IsDeleted = false;
                            medicalPracticeType.Save(Connection, Transaction);
                        }
                    }
                }
                //*******************Save Medical Practice Service******************* 
                //on front we must find if medical practice already exist for given service name
                if (Parameter.MedicalService != null && Parameter.MedicalService.Count() > 0)
                {
                    //ORM_HEC_MedicalService medicalService = ORM_HEC_MedicalService.Query.Search(Connection, Transaction, new ORM_HEC_MedicalService.Query
                    //{
                    //    HEC_MedicalServiceID = Parameter.MedicalService.HEC_MedicalServiceID,
                    //    IsDeleted = false,
                    //    Tenant_RefID = securityTicket.TenantID
                    //}).SingleOrDefault();
                    foreach (var medicalServiceParam in Parameter.MedicalService)
                    {
                        ORM_HEC_MedicalService medicalService = new ORM_HEC_MedicalService();
                        if (medicalServiceParam.NewMedicalService)
                        {
                            medicalService.HEC_MedicalServiceID = Guid.NewGuid();
                            medicalService.ServiceName = medicalServiceParam.ServiceName;
                            medicalService.Tenant_RefID = securityTicket.TenantID;
                            medicalService.IsDeleted = false;
                            medicalService.Save(Connection, Transaction);
                        }

                        ORM_HEC_MedicalPractice_OfferedService medicalPracticeOfferedService = new ORM_HEC_MedicalPractice_OfferedService();
                        if (!medicalServiceParam.NewMedicalService)
                            medicalPracticeOfferedService.MedicalService_RefID = medicalServiceParam.HEC_MedicalServiceID;
                        else
                            medicalPracticeOfferedService.MedicalService_RefID = medicalService.HEC_MedicalServiceID;
                        medicalPracticeOfferedService.MedicalPractice_RefID = medicalPractice.HEC_MedicalPractiseID;
                        medicalPracticeOfferedService.IsDeleted = false;
                        medicalPracticeOfferedService.Tenant_RefID = securityTicket.TenantID;
                        medicalPracticeOfferedService.Save(Connection, Transaction);
                    }
                }
                //*******************Save Contact Person************************

                ORM_CMN_PER_PersonInfo personInfo = new ORM_CMN_PER_PersonInfo();
                personInfo.CMN_PER_PersonInfoID = Guid.NewGuid();
                personInfo.Title = Parameter.ContactPersonTitle;
                personInfo.FirstName = Parameter.ContactPersonFirstName;
                personInfo.LastName = Parameter.ContactPersonLastName;
                personInfo.Tenant_RefID = securityTicket.TenantID;
                personInfo.IsDeleted = false;
                personInfo.Save(Connection, Transaction);

                ORM_CMN_BPT_BusinessParticipant businessParticpant = new ORM_CMN_BPT_BusinessParticipant();
                businessParticpant.CMN_BPT_BusinessParticipantID = Guid.NewGuid();
                businessParticpant.IsNaturalPerson = true;
                businessParticpant.DisplayName = Parameter.ContactPersonTitle + " " + Parameter.ContactPersonFirstName + " " + Parameter.ContactPersonLastName;
                businessParticpant.Tenant_RefID = securityTicket.TenantID;
                businessParticpant.IsDeleted = false;
                businessParticpant.IfNaturalPerson_CMN_PER_PersonInfo_RefID = personInfo.CMN_PER_PersonInfoID;
                businessParticpant.Save(Connection, Transaction);

                medicalPractice.ContactPerson_RefID = businessParticpant.CMN_BPT_BusinessParticipantID;

                //*******************Customer OrganizationalUnit************************
                ORM_CMN_BPT_CTM_OrganizationalUnit organizationalUnit = new ORM_CMN_BPT_CTM_OrganizationalUnit();
                organizationalUnit.CMN_BPT_CTM_OrganizationalUnitID = Guid.NewGuid();

                Dict medicationPracticeName = new Dict("hec_dia_potentialdiagnoses");
                for (int i = 0; i < DBLanguages.Length; i++)
                    medicationPracticeName.AddEntry(DBLanguages[i].CMN_LanguageID, Parameter.MedicalPractiseName);
                
                organizationalUnit.OrganizationalUnit_Name = medicationPracticeName;
                organizationalUnit.IsDeleted = false;
                organizationalUnit.Tenant_RefID = securityTicket.TenantID;
                organizationalUnit.Default_PhoneNumber = Parameter.Contact_Telephone;
                organizationalUnit.IsMedicalPractice = true;
                organizationalUnit.IfMedicalPractise_HEC_MedicalPractice_RefID = medicalPractice.HEC_MedicalPractiseID;
                organizationalUnit.Save(Connection, Transaction);

                //*******************AppointmentType************************
                //if (Parameter.AppoitmentType != null && Parameter.AppoitmentType.Count() > 0)
                //{
                //    foreach (var item in Parameter.AppoitmentType)
                //    {
                //        ORM_PPS_TSK_Task_Template_CustomerOrgUnitAvailability customerOrgUnitAvailability = new ORM_PPS_TSK_Task_Template_CustomerOrgUnitAvailability();
                //        customerOrgUnitAvailability.PPS_TSK_Task_Template_CustomerOrgUnitAvailabilityID = Guid.NewGuid();
                //        customerOrgUnitAvailability.CMN_BPT_CTM_OrganizationalUnit_RefID = organizationalUnit.CMN_BPT_CTM_OrganizationalUnitID;
                //        customerOrgUnitAvailability.PPS_TSK_Task_Template_RefID = item.PPS_TSK_Task_Template_RefID;
                //        customerOrgUnitAvailability.Tenant_RefID = securityTicket.TenantID;
                //        customerOrgUnitAvailability.Save(Connection, Transaction);
                //    }
                //}
                //*******************Save Address************************
                ORM_CMN_UniversalContactDetail contactDetail = new ORM_CMN_UniversalContactDetail();
                contactDetail.CMN_UniversalContactDetailID = Guid.NewGuid();
                contactDetail.IsCompany = true;
                contactDetail.Street_Name = Parameter.Street_Name;
                contactDetail.Street_Number = Parameter.Street_Number;
                contactDetail.Town = Parameter.Town;
                contactDetail.Contact_Website_URL = Parameter.Contact_Website_URL;
                contactDetail.Contact_Telephone = Parameter.Contact_Telephone;
                contactDetail.IsDeleted = false;
                contactDetail.Tenant_RefID = securityTicket.TenantID;
                contactDetail.Save(Connection, Transaction);

                ORM_CMN_COM_CompanyInfo companyInfo = new ORM_CMN_COM_CompanyInfo();
                companyInfo.CMN_COM_CompanyInfoID = Guid.NewGuid();
                companyInfo.Contact_UCD_RefID = contactDetail.CMN_UniversalContactDetailID;
                companyInfo.IsDeleted = false;
                companyInfo.Tenant_RefID = securityTicket.TenantID;
                companyInfo.Save(Connection, Transaction);

                medicalPractice.Ext_CompanyInfo_RefID = companyInfo.CMN_COM_CompanyInfoID;
                medicalPractice.Save(Connection, Transaction);

                //*******************Save Address************************
                //ORM_CMN_UniversalContactDetail contactDetail = new ORM_CMN_UniversalContactDetail();
                //contactDetail.CMN_UniversalContactDetailID = Guid.NewGuid();
                //contactDetail.IsCompany = true;
                //contactDetail.Street_Name = Parameter.Street_Name;
                //contactDetail.Street_Number = Parameter.Street_Number;
                //contactDetail.Town = Parameter.Town;
                //contactDetail.Contact_Website_URL = Parameter.Contact_Website_URL;
                //contactDetail.Contact_Telephone = Parameter.Contact_Telephone;
                //contactDetail.IsDeleted = false;
                //contactDetail.Tenant_RefID = securityTicket.TenantID;
                //contactDetail.Save(Connection, Transaction);

                //ORM_CMN_BPT_CTM_OrganizationalUnit_Address organizationalUnitAddress = new ORM_CMN_BPT_CTM_OrganizationalUnit_Address();
                //organizationalUnitAddress.UniversalContactDetail_Address_RefID = contactDetail.CMN_UniversalContactDetailID;
                //organizationalUnitAddress.OrganizationalUnit_RefID = organizationalUnit.CMN_BPT_CTM_OrganizationalUnitID;
                //organizationalUnitAddress.IsDeleted = false;
                //organizationalUnitAddress.Tenant_RefID = securityTicket.TenantID;
                //organizationalUnitAddress.Save(Connection, Transaction);

                returnValue.Result = medicalPractice.HEC_MedicalPractiseID;
            }
            #endregion
            //=====================Edit or Delete=====================
            else
            {
                ORM_HEC_MedicalPractis medicalPractice = ORM_HEC_MedicalPractis.Query.Search(Connection, Transaction, new ORM_HEC_MedicalPractis.Query
                {
                    HEC_MedicalPractiseID = Parameter.HEC_MedicalPractiseID,
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                }).Single();
                ORM_CMN_BPT_CTM_OrganizationalUnit organizationalUnit = ORM_CMN_BPT_CTM_OrganizationalUnit.Query.Search(Connection, Transaction, new ORM_CMN_BPT_CTM_OrganizationalUnit.Query
                {
                    IfMedicalPractise_HEC_MedicalPractice_RefID = medicalPractice.HEC_MedicalPractiseID,
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                }).Single();

                #region Edit
                if (Parameter.IsDeleted == false)
                {
                    //*******************Edit Medical Practice Service******************* 
                    if (Parameter.MedicalService != null && Parameter.MedicalService.Count() > 0)
                    {
                        foreach (var medicalServiceParam in Parameter.MedicalService)
                        {
                            ORM_HEC_MedicalPractice_OfferedService medicalPracticeOfferedService = ORM_HEC_MedicalPractice_OfferedService.Query.Search(Connection, Transaction, new ORM_HEC_MedicalPractice_OfferedService.Query
                            {
                                HEC_MedicalPractice_OfferedServiceID = medicalServiceParam.HEC_MedicalPractice_OfferedServiceID,
                                IsDeleted = false,
                                Tenant_RefID = securityTicket.TenantID
                            }).SingleOrDefault();
                            ORM_HEC_MedicalService medicalService = ORM_HEC_MedicalService.Query.Search(Connection, Transaction, new ORM_HEC_MedicalService.Query
                            {
                                HEC_MedicalServiceID = medicalServiceParam.HEC_MedicalServiceID,
                                IsDeleted = false,
                                Tenant_RefID = securityTicket.TenantID
                            }).SingleOrDefault();

                            if (medicalServiceParam.NewMedicalService && !medicalServiceParam.IsDeleted)
                            {
                                medicalService = new ORM_HEC_MedicalService();
                                medicalService.HEC_MedicalServiceID = Guid.NewGuid();
                                medicalService.ServiceName = medicalServiceParam.ServiceName;
                                medicalService.Tenant_RefID = securityTicket.TenantID;
                                medicalService.IsDeleted = false;
                                medicalService.Save(Connection, Transaction);
                            }

                            if (medicalPracticeOfferedService == null && !medicalServiceParam.IsDeleted)
                            {
                                medicalPracticeOfferedService = new ORM_HEC_MedicalPractice_OfferedService();
                                if (!medicalServiceParam.NewMedicalService)
                                    medicalPracticeOfferedService.MedicalService_RefID = medicalServiceParam.HEC_MedicalServiceID;
                                else
                                    medicalPracticeOfferedService.MedicalService_RefID = medicalService.HEC_MedicalServiceID;
                                medicalPracticeOfferedService.MedicalPractice_RefID = medicalPractice.HEC_MedicalPractiseID;
                                medicalPracticeOfferedService.IsDeleted = false;
                                medicalPracticeOfferedService.Tenant_RefID = securityTicket.TenantID;
                                medicalPracticeOfferedService.Save(Connection, Transaction);
                            }
                            else if (medicalPracticeOfferedService != null && !medicalServiceParam.IsDeleted)
                            {
                                medicalPracticeOfferedService.MedicalService_RefID = medicalService.HEC_MedicalServiceID;
                                medicalPracticeOfferedService.Save(Connection, Transaction);
                            }
                            else if (medicalPracticeOfferedService != null && medicalServiceParam.IsDeleted)
                            {
                                medicalPracticeOfferedService.IsDeleted = true;
                                medicalPracticeOfferedService.Save(Connection, Transaction);
                            }
                        }
                    }


                    //*******************Edit Customer OrganizationalUnit************************
                    Dict medicationPracticeName = new Dict("hec_dia_potentialdiagnoses");
                    for (int i = 0; i < DBLanguages.Length; i++)
                        medicationPracticeName.AddEntry(DBLanguages[i].CMN_LanguageID, Parameter.MedicalPractiseName);

                    organizationalUnit.OrganizationalUnit_Name = medicationPracticeName;
                    organizationalUnit.Default_PhoneNumber = Parameter.Contact_Telephone;
                    organizationalUnit.Save(Connection, Transaction);

                    //*******************Edit Contact Person************************
                    ORM_CMN_BPT_BusinessParticipant businessParticipant = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, new ORM_CMN_BPT_BusinessParticipant.Query
                    {
                        CMN_BPT_BusinessParticipantID = medicalPractice.ContactPerson_RefID,
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID
                    }).Single();
                    businessParticipant.DisplayName = Parameter.ContactPersonTitle + " " + Parameter.ContactPersonFirstName + " " + Parameter.ContactPersonLastName;
                    businessParticipant.Save(Connection, Transaction);

                    ORM_CMN_PER_PersonInfo personInfo = ORM_CMN_PER_PersonInfo.Query.Search(Connection, Transaction, new ORM_CMN_PER_PersonInfo.Query
                    {
                        CMN_PER_PersonInfoID = businessParticipant.IfNaturalPerson_CMN_PER_PersonInfo_RefID,
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID
                    }).Single();
                    personInfo.Title = Parameter.ContactPersonTitle;
                    personInfo.FirstName = Parameter.ContactPersonFirstName;
                    personInfo.LastName = Parameter.ContactPersonLastName;
                    personInfo.Save(Connection, Transaction);

                    //*******************Edit Medical Practice Type******************* 
                    foreach (var medicalPracticeTypeParam in Parameter.MedicalPracticeType)
                    {
                        ORM_HEC_MedicalPractice_2_PracticeType existingPracticeType = ORM_HEC_MedicalPractice_2_PracticeType.Query.Search(Connection, Transaction, new ORM_HEC_MedicalPractice_2_PracticeType.Query
                        {
                            HEC_MedicalPractice_RefID = medicalPractice.HEC_MedicalPractiseID,
                            HEC_MedicalPractice_Type_RefID = medicalPracticeTypeParam.HEC_MedicalPractice_TypeID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        }).SingleOrDefault();
                        if (existingPracticeType == null && !medicalPracticeTypeParam.IsDeleted)
                        {
                            ORM_HEC_MedicalPractice_2_PracticeType medicalPracticeType = new ORM_HEC_MedicalPractice_2_PracticeType();
                            medicalPracticeType.AssignmentID = Guid.NewGuid();
                            medicalPracticeType.HEC_MedicalPractice_Type_RefID = medicalPracticeTypeParam.HEC_MedicalPractice_TypeID;
                            medicalPracticeType.HEC_MedicalPractice_RefID = medicalPractice.HEC_MedicalPractiseID;
                            medicalPracticeType.Tenant_RefID = securityTicket.TenantID;
                            medicalPracticeType.IsDeleted = false;
                            medicalPracticeType.Save(Connection, Transaction);
                        }
                        else if (existingPracticeType != null && !medicalPracticeTypeParam.IsDeleted)
                        {
                            existingPracticeType.HEC_MedicalPractice_Type_RefID = medicalPracticeTypeParam.HEC_MedicalPractice_TypeID;
                            existingPracticeType.Save(Connection, Transaction);
                        }
                        else if (existingPracticeType != null && medicalPracticeTypeParam.IsDeleted)
                        {
                            existingPracticeType.IsDeleted = true;
                            existingPracticeType.Save(Connection, Transaction);
                        }
                    }

                    //*******************Edit AppointmentType******************* 
                    //if (Parameter.AppoitmentType != null && Parameter.AppoitmentType.Count() > 0)
                    //{
                    //    foreach (var appointmentTypeParam in Parameter.AppoitmentType)
                    //    {
                    //        ORM_PPS_TSK_Task_Template_CustomerOrgUnitAvailability existingAppointmentType = ORM_PPS_TSK_Task_Template_CustomerOrgUnitAvailability.Query.Search(Connection, Transaction, new ORM_PPS_TSK_Task_Template_CustomerOrgUnitAvailability.Query
                    //        {
                    //            CMN_BPT_CTM_OrganizationalUnit_RefID = organizationalUnit.CMN_BPT_CTM_OrganizationalUnitID,
                    //            PPS_TSK_Task_Template_RefID = appointmentTypeParam.PPS_TSK_Task_Template_RefID,
                    //            IsDeleted = false,
                    //            Tenant_RefID = securityTicket.TenantID
                    //        }).SingleOrDefault();
                    //        if (existingAppointmentType == null & !appointmentTypeParam.IsDeleted)
                    //        {
                    //            ORM_PPS_TSK_Task_Template_CustomerOrgUnitAvailability customerOrgUnitAvailability = new ORM_PPS_TSK_Task_Template_CustomerOrgUnitAvailability();
                    //            customerOrgUnitAvailability.PPS_TSK_Task_Template_CustomerOrgUnitAvailabilityID = Guid.NewGuid();
                    //            customerOrgUnitAvailability.CMN_BPT_CTM_OrganizationalUnit_RefID = organizationalUnit.CMN_BPT_CTM_OrganizationalUnitID;
                    //            customerOrgUnitAvailability.PPS_TSK_Task_Template_RefID = appointmentTypeParam.PPS_TSK_Task_Template_RefID;
                    //            customerOrgUnitAvailability.Tenant_RefID = securityTicket.TenantID;
                    //            customerOrgUnitAvailability.Save(Connection, Transaction);
                    //        }
                    //        else if (existingAppointmentType != null & !appointmentTypeParam.IsDeleted)
                    //        {
                    //            existingAppointmentType.PPS_TSK_Task_Template_RefID = appointmentTypeParam.PPS_TSK_Task_Template_RefID;
                    //            existingAppointmentType.Save(Connection, Transaction);
                    //        }
                    //        else if (existingAppointmentType != null & !appointmentTypeParam.IsDeleted)
                    //        {
                    //            existingAppointmentType.IsDeleted = true;
                    //            existingAppointmentType.Save(Connection, Transaction);
                    //        }
                    //    }
                    //}
                    //*******************Edit Address and name************************
                    ORM_CMN_COM_CompanyInfo companyInfo = ORM_CMN_COM_CompanyInfo.Query.Search(Connection, Transaction, new ORM_CMN_COM_CompanyInfo.Query
                    {
                        CMN_COM_CompanyInfoID = medicalPractice.Ext_CompanyInfo_RefID,
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID
                    }).Single();

                    ORM_CMN_UniversalContactDetail contactDetail = ORM_CMN_UniversalContactDetail.Query.Search(Connection, Transaction, new ORM_CMN_UniversalContactDetail.Query
                    {
                        CMN_UniversalContactDetailID = companyInfo.Contact_UCD_RefID,
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID
                    }).Single();
                    contactDetail.Street_Name = Parameter.Street_Name;
                    contactDetail.Street_Number = Parameter.Street_Number;
                    contactDetail.Town = Parameter.Town;
                    contactDetail.Contact_Website_URL = Parameter.Contact_Website_URL;
                    contactDetail.Contact_Telephone = Parameter.Contact_Telephone;
                    contactDetail.Save(Connection, Transaction);

                    returnValue.Result = medicalPractice.HEC_MedicalPractiseID;
                }
                #endregion
                #region Delete
                else
                {
                    ORM_HEC_MedicalPractice_2_PracticeType.Query.SoftDelete(Connection, Transaction, new ORM_HEC_MedicalPractice_2_PracticeType.Query
                    {
                        HEC_MedicalPractice_RefID = medicalPractice.HEC_MedicalPractiseID,
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID
                    });

                    ORM_PPS_TSK_Task_Template_CustomerOrgUnitAvailability.Query.SoftDelete(Connection, Transaction, new ORM_PPS_TSK_Task_Template_CustomerOrgUnitAvailability.Query
                        {
                            CMN_BPT_CTM_OrganizationalUnit_RefID = organizationalUnit.CMN_BPT_CTM_OrganizationalUnitID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        });

                    ORM_HEC_MedicalPractice_OfferedService.Query.SoftDelete(Connection, Transaction, new ORM_HEC_MedicalPractice_OfferedService.Query
                    {
                        MedicalPractice_RefID = medicalPractice.HEC_MedicalPractiseID,
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID
                    });

                    ORM_CMN_BPT_BusinessParticipant businessParticipant = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, new ORM_CMN_BPT_BusinessParticipant.Query
                    {
                        CMN_BPT_BusinessParticipantID = medicalPractice.ContactPerson_RefID,
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID
                    }).Single();
                    businessParticipant.IsDeleted = true;
                    ORM_CMN_PER_PersonInfo personInfo = ORM_CMN_PER_PersonInfo.Query.Search(Connection, Transaction, new ORM_CMN_PER_PersonInfo.Query
                    {
                        CMN_PER_PersonInfoID = businessParticipant.IfNaturalPerson_CMN_PER_PersonInfo_RefID,
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID
                    }).Single();
                    personInfo.IsDeleted = true;
                    ORM_CMN_COM_CompanyInfo companyInfo = ORM_CMN_COM_CompanyInfo.Query.Search(Connection, Transaction, new ORM_CMN_COM_CompanyInfo.Query
                    {
                        CMN_COM_CompanyInfoID = medicalPractice.Ext_CompanyInfo_RefID,
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID
                    }).Single();
                    companyInfo.IsDeleted = true;
                    ORM_CMN_UniversalContactDetail contactDetail = ORM_CMN_UniversalContactDetail.Query.Search(Connection, Transaction, new ORM_CMN_UniversalContactDetail.Query
                    {
                        CMN_UniversalContactDetailID = companyInfo.Contact_UCD_RefID,
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID
                    }).Single();
                    contactDetail.IsDeleted = true;

                    ORM_HEC_MedicalPractis.Query.SoftDelete(Connection, Transaction, new ORM_HEC_MedicalPractis.Query
                    {
                        HEC_MedicalPractiseID = Parameter.HEC_MedicalPractiseID,
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID
                    });
                    contactDetail.Save(Connection, Transaction);
                    companyInfo.Save(Connection, Transaction);
                    personInfo.Save(Connection, Transaction);
                    businessParticipant.Save(Connection, Transaction);
                }
                #endregion
                returnValue.Result = medicalPractice.HEC_MedicalPractiseID;
            }
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5DI_SRMP_1425 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5DI_SRMP_1425 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5DI_SRMP_1425 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5DI_SRMP_1425 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Guid functionReturn = new FR_Guid();
			try
			{

				if (cleanupConnection == true) 
				{
					Connection = CSV2Core_MySQL.Support.DBSQLSupport.CreateConnection(ConnectionString);
					Connection.Open();
				}
				if (cleanupTransaction == true)
				{
					Transaction = Connection.BeginTransaction();
				}

				functionReturn = Execute(Connection, Transaction,Parameter,securityTicket);

				#region Cleanup Connection/Transaction
				//Commit the transaction 
				if (cleanupTransaction == true)
				{
					Transaction.Commit();
				}
				//Close the connection
				if (cleanupConnection == true)
				{
					Connection.Close();
				}
				#endregion
			}
			catch (Exception ex)
			{
				try
				{
					if (cleanupTransaction == true && Transaction!=null)
					{
						Transaction.Rollback();
					}
				}
				catch { }

				try
				{
					if (cleanupConnection == true && Connection != null)
					{
						Connection.Close();
					}
				}
				catch { }

				throw new Exception("Exception occured in method cls_Save_ReferralMedicalPractice",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5DI_SRMP_1425 for attribute P_L5DI_SRMP_1425
		[DataContract]
		public class P_L5DI_SRMP_1425 
		{
			[DataMember]
			public P_L5DI_SRMP_1425_MedicalService[] MedicalService { get; set; }
			[DataMember]
			public P_L5DI_SRMP_1425_MedicalPracticeType[] MedicalPracticeType { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid HEC_MedicalPractiseID { get; set; } 
			[DataMember]
			public String MedicalPractiseName { get; set; } 
			[DataMember]
			public String ContactPersonTitle { get; set; } 
			[DataMember]
			public String ContactPersonFirstName { get; set; } 
			[DataMember]
			public String ContactPersonLastName { get; set; } 
			[DataMember]
			public String Street_Name { get; set; } 
			[DataMember]
			public String Street_Number { get; set; } 
			[DataMember]
			public String Town { get; set; } 
			[DataMember]
			public String Contact_Telephone { get; set; } 
			[DataMember]
			public String Contact_Website_URL { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 
			[DataMember]
			public bool IsHospital { get; set; } 

		}
		#endregion
		#region SClass P_L5DI_SRMP_1425_MedicalService for attribute MedicalService
		[DataContract]
		public class P_L5DI_SRMP_1425_MedicalService 
		{
			//Standard type parameters
			[DataMember]
			public Dict ServiceName { get; set; } 
			[DataMember]
			public Guid HEC_MedicalPractice_OfferedServiceID { get; set; } 
			[DataMember]
			public Guid HEC_MedicalServiceID { get; set; } 
			[DataMember]
			public bool NewMedicalService { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 

		}
		#endregion
		#region SClass P_L5DI_SRMP_1425_MedicalPracticeType for attribute MedicalPracticeType
		[DataContract]
		public class P_L5DI_SRMP_1425_MedicalPracticeType 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_MedicalPractice_TypeID { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_ReferralMedicalPractice(,P_L5DI_SRMP_1425 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_ReferralMedicalPractice.Invoke(connectionString,P_L5DI_SRMP_1425 Parameter,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

/* Support for Parameter Invocation (Copy&Paste)
var parameter = new CL5_MyHealthClub_Diagnosis.Atomic.Manipulation.P_L5DI_SRMP_1425();
parameter.MedicalService = ...;
parameter.MedicalPracticeType = ...;

parameter.HEC_MedicalPractiseID = ...;
parameter.MedicalPractiseName = ...;
parameter.ContactPersonTitle = ...;
parameter.ContactPersonFirstName = ...;
parameter.ContactPersonLastName = ...;
parameter.Street_Name = ...;
parameter.Street_Number = ...;
parameter.Town = ...;
parameter.Contact_Telephone = ...;
parameter.Contact_Website_URL = ...;
parameter.IsDeleted = ...;
parameter.IsHospital = ...;

*/
