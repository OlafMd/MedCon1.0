/* 
 * Generated on 11/11/2014 3:49:32 PM
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
using CL1_HEC;
using CL1_CMN_STR;
using CL1_CMN;
using CL1_CMN_BPT_EMP;
using CL1_CMN_BPT;
using CL1_CMN_PER;
using CL1_PPS_TSK;

namespace CL5_MyHealthClub_OrgUnits.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_OrgsUnitsGeneralData.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_OrgsUnitsGeneralData
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5OU_SOUGD_1221 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_Guid();

            #region Save
            if (Parameter.OrgUnitID == null || Parameter.OrgUnitID == Guid.Empty)
            {
                //*******************MedicalPracticeType************************

                var medicalPractice = new ORM_HEC_MedicalPractis();
                medicalPractice.HEC_MedicalPractiseID = Guid.NewGuid();
                medicalPractice.Tenant_RefID = securityTicket.TenantID;
                medicalPractice.IsDeleted = false;
                medicalPractice.Save(Connection, Transaction);

                foreach (var item in Parameter.MedicalPracticeType)
                {
                    var medicalPractice2PracticeType = new ORM_HEC_MedicalPractice_2_PracticeType();
                    medicalPractice2PracticeType.AssignmentID = Guid.NewGuid();
                    medicalPractice2PracticeType.HEC_MedicalPractice_Type_RefID = item.HEC_MedicalPractice_TypeID;
                    medicalPractice2PracticeType.HEC_MedicalPractice_RefID = medicalPractice.HEC_MedicalPractiseID;
                    medicalPractice2PracticeType.Tenant_RefID = securityTicket.TenantID;
                    medicalPractice2PracticeType.IsDeleted = false;
                    medicalPractice2PracticeType.Save(Connection, Transaction);
                }

                //******************* Office************************
                var Office = new ORM_CMN_STR_Office();
                Office.CMN_STR_OfficeID = Guid.NewGuid();
                Office.Office_Name = Parameter.OrgUnitName_DictID;
                Office.Tenant_RefID = securityTicket.TenantID;
                if (Parameter.ParentID != null && Parameter.ParentID != Guid.Empty)
                    Office.Parent_RefID = Parameter.ParentID;
                Office.Creation_Timestamp = DateTime.Now;

                var officeQuery = new ORM_CMN_STR_Office.Query();
                officeQuery.Tenant_RefID = securityTicket.TenantID;
                int officeCount = ORM_CMN_STR_Office.Query.Search(Connection, Transaction, officeQuery).Count;

                Office.Office_InternalNumber = String.Format("{0:00000}", officeCount + 1);
                Office.Default_PhoneNumber = Parameter.Telephone;
                Office.DisplayImage_Document_RefID = Parameter.DisplayImage_Document_RefID;
                Office.Default_Email = Parameter.Email;
                Office.Default_Website = Parameter.Website;
                Office.Office_Description = new Dict("cmn_str_offices");
                Office.Comment = Parameter.Notes;
                Office.IsMedicalPractice = true;
                Office.IfMedicalPractise_HEC_MedicalPractice_RefID = medicalPractice.HEC_MedicalPractiseID;
                Office.Save(Connection, Transaction);

                //*******************Save Address************************

                foreach (var address in Parameter.Adresses)
                {
                    var Office_2_Address = new ORM_CMN_STR_Office_Address();
                    Office_2_Address.CMN_STR_Office_AddressID = Guid.NewGuid();
                    Office_2_Address.IsBillingAddress = address.IsBillingAddress;
                    Office_2_Address.IsShippingAddress = address.IsShippingAddress;
                    Office_2_Address.IsSpecialAddress = address.IsSpecialAddress;
                    Office_2_Address.CMN_Address_RefID = address.AddressID;
                    Office_2_Address.Office_RefID = Office.CMN_STR_OfficeID;
                    Office_2_Address.Tenant_RefID = securityTicket.TenantID;
                    Office_2_Address.Creation_Timestamp = DateTime.Now;
                    Office_2_Address.IsDefault = address.IsDefault;
                    Office_2_Address.Save(Connection, Transaction);

                    var Address = new ORM_CMN_Address();
                    Address.CMN_AddressID = Office_2_Address.CMN_Address_RefID;
                    Address.Tenant_RefID = securityTicket.TenantID;
                    Address.Creation_Timestamp = DateTime.Now;
                    Address.City_Name = address.City;
                    Address.Street_Name = address.Street_Name;
                    Address.Street_Number = address.Street_Number;
                    Address.Country_ISOCode = address.CountryISO;
                    Address.Country_Name = address.CountryName;
                    Address.City_PostalCode = address.ZIP;
                    if (address.IsDefault)
                    {
                        Address.Lattitude = address.Lattitude;
                        Address.Longitude = address.Longitude;
                    }
                    Address.Save(Connection, Transaction);
                }

                //*******************Save Languages************************

                foreach (var item in Parameter.SpokenLanguage)
                {
                    var officeSpokenLanguages = new ORM_CMN_STR_Office_SpokenLanguage();
                    officeSpokenLanguages.CMN_STR_Office_SpokenLanguageID = Guid.NewGuid();
                    officeSpokenLanguages.Office_RefID = Office.CMN_STR_OfficeID;
                    officeSpokenLanguages.Language_RefID = item.CMN_LanguageID;
                    officeSpokenLanguages.IsDeleted = item.IsDeleted;
                    officeSpokenLanguages.Tenant_RefID = securityTicket.TenantID;
                    officeSpokenLanguages.Save(Connection, Transaction);
                }

                //*******************Save Contact Person************************

                var responsiblePerson = new ORM_CMN_STR_Office_ResponsiblePerson();
                responsiblePerson.CMN_STR_Office_ResponsiblePersonID = Guid.NewGuid();
                responsiblePerson.Office_RefID = Office.CMN_STR_OfficeID;
                responsiblePerson.CMN_BPT_EMP_Employee_RefID = Guid.NewGuid();
                responsiblePerson.Tenant_RefID = securityTicket.TenantID;
                responsiblePerson.Creation_Timestamp = DateTime.Now;
                responsiblePerson.Save(Connection, Transaction);

                var employee = new ORM_CMN_BPT_EMP_Employee();
                employee.CMN_BPT_EMP_EmployeeID = responsiblePerson.CMN_BPT_EMP_Employee_RefID;
                employee.BusinessParticipant_RefID = Guid.NewGuid();
                employee.Creation_Timestamp = DateTime.Now;
                employee.Tenant_RefID = securityTicket.TenantID;
                employee.Save(Connection, Transaction);

                var businessParticpant = new ORM_CMN_BPT_BusinessParticipant();
                businessParticpant.CMN_BPT_BusinessParticipantID = employee.BusinessParticipant_RefID;
                businessParticpant.IsNaturalPerson = true;
                businessParticpant.DisplayName = Parameter.ContactPerson.Title + " " + Parameter.ContactPerson.FirstName + " " + Parameter.ContactPerson.LastName;
                businessParticpant.Tenant_RefID = securityTicket.TenantID;
                businessParticpant.Creation_Timestamp = DateTime.Now;
                businessParticpant.IfNaturalPerson_CMN_PER_PersonInfo_RefID = Guid.NewGuid();
                businessParticpant.Save(Connection, Transaction);

                var personInfo = new ORM_CMN_PER_PersonInfo();
                personInfo.CMN_PER_PersonInfoID = businessParticpant.IfNaturalPerson_CMN_PER_PersonInfo_RefID;
                personInfo.Title = Parameter.ContactPerson.Title;
                personInfo.FirstName = Parameter.ContactPerson.FirstName;
                personInfo.LastName = Parameter.ContactPerson.LastName;
                personInfo.Tenant_RefID = securityTicket.TenantID;
                personInfo.Creation_Timestamp = DateTime.Now;
                personInfo.Save(Connection, Transaction);

                //*******************AppointmentType************************

                foreach (var item in Parameter.AppoitmentType)
                {
                    ORM_PPS_TSK_Task_Template_OrganizationalUnitAvailability orgUnitToAppointmentType = new ORM_PPS_TSK_Task_Template_OrganizationalUnitAvailability();
                    orgUnitToAppointmentType.PPS_TSK_Task_Template_OrganizationalUnitAvailabilityID = Guid.NewGuid();
                    orgUnitToAppointmentType.CMN_STR_Office_RefID = Office.CMN_STR_OfficeID;
                    orgUnitToAppointmentType.PPS_TSK_Task_Template_RefID = item.PPS_TSK_Task_Template_RefID;
                    orgUnitToAppointmentType.Creation_Timestamp = DateTime.Now;
                    orgUnitToAppointmentType.Tenant_RefID = securityTicket.TenantID;
                    orgUnitToAppointmentType.Save(Connection, Transaction);
                }

                returnValue.Result = Office.CMN_STR_OfficeID;

            }
            #endregion
            #region Delete
            else if (Parameter.IsDeleted)
            {
                List<Guid> guidList = new List<Guid>();
                guidList.Add(Parameter.OrgUnitID);
                cls_Delete_OrgsUnitsGeneralData.Invoke(Connection, Transaction, new P_L5OU_DOUGD_1221 { OrgUnitID = guidList.ToArray() }, securityTicket);
            }
            #endregion
            #region Edit
            else
            {
                var officeQuery = new ORM_CMN_STR_Office.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false,
                    CMN_STR_OfficeID = Parameter.OrgUnitID
                };

                var office = ORM_CMN_STR_Office.Query.Search(Connection, Transaction, officeQuery).Single();
                office.Office_Name = Parameter.OrgUnitName_DictID;
                office.Default_PhoneNumber = Parameter.Telephone;
                office.DisplayImage_Document_RefID = Parameter.DisplayImage_Document_RefID;
                office.Default_Email = Parameter.Email;
                office.Comment = Parameter.Notes;
                office.Default_Website = Parameter.Website;
                if (Parameter.ParentID != null && Parameter.ParentID != Guid.Empty)
                    office.Parent_RefID = Parameter.ParentID;
                office.IsMedicalPractice = true;
                office.Save(Connection, Transaction);

                //*******************Medical practice type************************

                var medicalPractice2TypeQuery = new ORM_HEC_MedicalPractice_2_PracticeType.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false,
                    HEC_MedicalPractice_RefID = office.IfMedicalPractise_HEC_MedicalPractice_RefID
                };
                var medicalPractice2Type = ORM_HEC_MedicalPractice_2_PracticeType.Query.Search(Connection, Transaction, medicalPractice2TypeQuery).ToList();

                foreach (var item in Parameter.MedicalPracticeType)
                {
                    if (item.IsDeleted)
                    {
                        foreach (var medicalPractice2TypeItem in medicalPractice2Type)
                        {
                            if (medicalPractice2TypeItem.HEC_MedicalPractice_Type_RefID == item.HEC_MedicalPractice_TypeID)
                            {
                                medicalPractice2TypeItem.Tenant_RefID = securityTicket.TenantID;
                                if (office.IfMedicalPractise_HEC_MedicalPractice_RefID != Guid.Empty)
                                {
                                    medicalPractice2TypeItem.HEC_MedicalPractice_RefID = office.IfMedicalPractise_HEC_MedicalPractice_RefID;
                                }
                                else
                                {
                                    var medicalPractice = new ORM_HEC_MedicalPractis();
                                    medicalPractice.HEC_MedicalPractiseID = Guid.NewGuid();
                                    medicalPractice.Tenant_RefID = securityTicket.TenantID;
                                    medicalPractice.IsDeleted = false;
                                    medicalPractice.Save(Connection, Transaction);
                                    office.IfMedicalPractise_HEC_MedicalPractice_RefID = medicalPractice.HEC_MedicalPractiseID;
                                    office.Save(Connection, Transaction);
                                    medicalPractice2TypeItem.HEC_MedicalPractice_RefID = medicalPractice.HEC_MedicalPractiseID;
                                }
                                medicalPractice2TypeItem.IsDeleted = true;
                                medicalPractice2TypeItem.Save(Connection, Transaction);
                                break;
                            }
                        }
                    }
                    else
                    {
                        ORM_HEC_MedicalPractice_2_PracticeType medPracticeType = null;
                        foreach (var medicalPractice2TypeItem in medicalPractice2Type)
                        {
                            if (medicalPractice2TypeItem.HEC_MedicalPractice_Type_RefID == item.HEC_MedicalPractice_TypeID)
                            {
                                medPracticeType = medicalPractice2TypeItem;
                                if (medPracticeType.HEC_MedicalPractice_RefID == Guid.Empty)
                                {
                                    var medicalPractice = new ORM_HEC_MedicalPractis();
                                    medicalPractice.HEC_MedicalPractiseID = Guid.NewGuid();
                                    medicalPractice.Tenant_RefID = securityTicket.TenantID;
                                    medicalPractice.IsDeleted = false;
                                    medicalPractice.Save(Connection, Transaction);
                                    office.IfMedicalPractise_HEC_MedicalPractice_RefID = medicalPractice.HEC_MedicalPractiseID;
                                    office.Save(Connection, Transaction);
                                    medPracticeType.HEC_MedicalPractice_RefID = medicalPractice.HEC_MedicalPractiseID;
                                    medPracticeType.Save(Connection, Transaction);
                                }
                                break;
                            }
                        }

                        if (medPracticeType == null)
                        {
                            medPracticeType = new ORM_HEC_MedicalPractice_2_PracticeType();
                            medPracticeType.Tenant_RefID = securityTicket.TenantID;
                            medPracticeType.IsDeleted = false;
                            medPracticeType.HEC_MedicalPractice_Type_RefID = item.HEC_MedicalPractice_TypeID;
                            if (office.IfMedicalPractise_HEC_MedicalPractice_RefID != Guid.Empty)
                            {
                                medPracticeType.HEC_MedicalPractice_RefID = office.IfMedicalPractise_HEC_MedicalPractice_RefID;
                            }
                            else
                            {
                                var medicalPractice = new ORM_HEC_MedicalPractis();
                                medicalPractice.HEC_MedicalPractiseID = Guid.NewGuid();
                                medicalPractice.Tenant_RefID = securityTicket.TenantID;
                                medicalPractice.IsDeleted = false;
                                medicalPractice.Save(Connection, Transaction);
                                office.IfMedicalPractise_HEC_MedicalPractice_RefID = medicalPractice.HEC_MedicalPractiseID;
                                office.Save(Connection, Transaction);
                                medPracticeType.HEC_MedicalPractice_RefID = medicalPractice.HEC_MedicalPractiseID;
                            }
                            medPracticeType.Save(Connection, Transaction);

                        }
                        else
                        {
                            if (medPracticeType.IsDeleted)
                            {
                                medPracticeType.Tenant_RefID = securityTicket.TenantID;
                                medPracticeType.IsDeleted = true;
                                if (office.IfMedicalPractise_HEC_MedicalPractice_RefID != Guid.Empty)
                                {
                                    medPracticeType.HEC_MedicalPractice_RefID = office.IfMedicalPractise_HEC_MedicalPractice_RefID;
                                }
                                else
                                {
                                    var medicalPractice = new ORM_HEC_MedicalPractis();
                                    medicalPractice.HEC_MedicalPractiseID = Guid.NewGuid();
                                    medicalPractice.Tenant_RefID = securityTicket.TenantID;
                                    medicalPractice.IsDeleted = false;
                                    medicalPractice.Save(Connection, Transaction);
                                    office.IfMedicalPractise_HEC_MedicalPractice_RefID = medicalPractice.HEC_MedicalPractiseID;
                                    office.Save(Connection, Transaction);
                                    medPracticeType.HEC_MedicalPractice_RefID = medicalPractice.HEC_MedicalPractiseID;
                                }
                                medPracticeType.Save(Connection, Transaction);
                            }
                        }
                    }

                }

                //*******************Save Spoken Languages************************ 

                var office_spoken_languages = new ORM_CMN_STR_Office_SpokenLanguage.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    Office_RefID = office.CMN_STR_OfficeID,
                    IsDeleted = false
                };

                var officeSpokenLanguageQuery = ORM_CMN_STR_Office_SpokenLanguage.Query.Search(Connection, Transaction, office_spoken_languages);

                foreach (var item in Parameter.SpokenLanguage)
                {
                    ORM_CMN_STR_Office_SpokenLanguage officeSpokenLang = null;
                    foreach (var officeSpokenLanguageItem in officeSpokenLanguageQuery)
                    {
                        if (officeSpokenLanguageItem.Language_RefID == item.CMN_LanguageID && officeSpokenLanguageItem.Office_RefID == office.CMN_STR_OfficeID)
                        {
                            officeSpokenLang = officeSpokenLanguageItem;
                            break;
                        }
                    }
                    if (officeSpokenLang == null)
                    {
                        var officeSpokenLanguage = new ORM_CMN_STR_Office_SpokenLanguage();
                        officeSpokenLanguage.CMN_STR_Office_SpokenLanguageID = Guid.NewGuid();
                        officeSpokenLanguage.Language_RefID = item.CMN_LanguageID;
                        officeSpokenLanguage.IsDeleted = item.IsDeleted;
                        officeSpokenLanguage.Office_RefID = office.CMN_STR_OfficeID;
                        officeSpokenLanguage.Tenant_RefID = securityTicket.TenantID;
                        officeSpokenLanguage.Save(Connection, Transaction);
                    }
                    else
                    {
                        officeSpokenLang.Language_RefID = item.CMN_LanguageID;
                        officeSpokenLang.IsDeleted = item.IsDeleted;                       
                        officeSpokenLang.Save(Connection, Transaction);                       
                    }
                }


                //*******************Save Address************************

                foreach (var address in Parameter.Adresses)
                {
                    var Office_2_Address = ORM_CMN_STR_Office_Address.Query.Search(Connection, Transaction, new ORM_CMN_STR_Office_Address.Query()
                    {
                        IsBillingAddress = address.IsBillingAddress,
                        IsShippingAddress = address.IsShippingAddress,
                        IsSpecialAddress = address.IsSpecialAddress,
                        Office_RefID = office.CMN_STR_OfficeID,
                        Tenant_RefID = securityTicket.TenantID,
                        CMN_Address_RefID = address.AddressID,
                        IsDeleted = false
                    }).SingleOrDefault();

                    if (Office_2_Address == null)
                    {
                        Office_2_Address = new ORM_CMN_STR_Office_Address();
                        Office_2_Address.CMN_STR_Office_AddressID = Guid.NewGuid();
                        Office_2_Address.IsBillingAddress = address.IsBillingAddress;
                        Office_2_Address.IsShippingAddress = address.IsShippingAddress;
                        Office_2_Address.IsSpecialAddress = address.IsSpecialAddress;
                        Office_2_Address.CMN_Address_RefID = address.AddressID;
                        Office_2_Address.Office_RefID = office.CMN_STR_OfficeID;
                        Office_2_Address.Tenant_RefID = securityTicket.TenantID;
                        Office_2_Address.Creation_Timestamp = DateTime.Now;
                    }

                    Office_2_Address.IsDefault = address.IsDefault;

                    var Address = ORM_CMN_Address.Query.Search(Connection, Transaction, new ORM_CMN_Address.Query()
                    {
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false,
                        CMN_AddressID = Office_2_Address.CMN_Address_RefID
                    }).SingleOrDefault();

                    if (Address == null)
                    {
                        Address = new ORM_CMN_Address();
                        Address.CMN_AddressID = Office_2_Address.CMN_Address_RefID;
                        Address.Tenant_RefID = securityTicket.TenantID;
                        Address.Creation_Timestamp = DateTime.Now;
                    }

                    if (address.IsDeleted)
                    {
                        Address.IsDeleted = true;
                        Office_2_Address.IsDeleted = true;
                    }
                    else
                    {
                        Address.City_Name = address.City;
                        Address.Street_Name = address.Street_Name;
                        Address.Street_Number = address.Street_Number;
                        Address.Country_ISOCode = address.CountryISO;
                        Address.Country_Name = address.CountryName;
                        Address.City_PostalCode = address.ZIP;
                        if (address.IsDefault)
                        {
                            Address.Lattitude = address.Lattitude;
                            Address.Longitude = address.Longitude;
                        }
                    }
                    Office_2_Address.Save(Connection, Transaction);
                    Address.Save(Connection, Transaction);
                }


                //*******************AppointmentType************************

                foreach (var item in Parameter.AppoitmentType)
                {
                    var orgUnitToAppointmentTypeQuery = new ORM_PPS_TSK_Task_Template_OrganizationalUnitAvailability.Query();
                    orgUnitToAppointmentTypeQuery.CMN_STR_Office_RefID = Parameter.OrgUnitID;
                    orgUnitToAppointmentTypeQuery.PPS_TSK_Task_Template_RefID = item.PPS_TSK_Task_Template_RefID;
                    orgUnitToAppointmentTypeQuery.Tenant_RefID = securityTicket.TenantID;
                    orgUnitToAppointmentTypeQuery.IsDeleted = false;

                    var orgUnitToAppointmentType = ORM_PPS_TSK_Task_Template_OrganizationalUnitAvailability.Query.Search(Connection, Transaction, orgUnitToAppointmentTypeQuery).SingleOrDefault();

                    if (orgUnitToAppointmentType == null)
                    {
                        if (!item.IsDeleted)
                        {
                            orgUnitToAppointmentType = new ORM_PPS_TSK_Task_Template_OrganizationalUnitAvailability();
                            orgUnitToAppointmentType.PPS_TSK_Task_Template_OrganizationalUnitAvailabilityID = Guid.NewGuid();
                            orgUnitToAppointmentType.CMN_STR_Office_RefID = Parameter.OrgUnitID;
                            orgUnitToAppointmentType.PPS_TSK_Task_Template_RefID = item.PPS_TSK_Task_Template_RefID;
                            orgUnitToAppointmentType.Creation_Timestamp = DateTime.Now;
                            orgUnitToAppointmentType.Tenant_RefID = securityTicket.TenantID;
                            orgUnitToAppointmentType.Save(Connection, Transaction);
                        }
                    }
                    else
                    {
                        if (item.IsDeleted)
                        {
                            orgUnitToAppointmentType.IsDeleted = true;
                            orgUnitToAppointmentType.Save(Connection, Transaction);
                        }
                    }

                }


                //*******************Save Contact Person************************

                var responsiblePerson = ORM_CMN_STR_Office_ResponsiblePerson.Query.Search(Connection, Transaction, new ORM_CMN_STR_Office_ResponsiblePerson.Query()
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID,
                    Office_RefID = office.CMN_STR_OfficeID
                }).Single();

                var employee = ORM_CMN_BPT_EMP_Employee.Query.Search(Connection, Transaction, new ORM_CMN_BPT_EMP_Employee.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false,
                    CMN_BPT_EMP_EmployeeID = responsiblePerson.CMN_BPT_EMP_Employee_RefID
                }).Single();

                var businessParticpant = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, new ORM_CMN_BPT_BusinessParticipant.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false,
                    CMN_BPT_BusinessParticipantID = employee.BusinessParticipant_RefID
                }).Single();
                businessParticpant.DisplayName = Parameter.ContactPerson.Title + " " + Parameter.ContactPerson.FirstName + " " + Parameter.ContactPerson.LastName;
                businessParticpant.Save(Connection, Transaction);

                var personInfo = ORM_CMN_PER_PersonInfo.Query.Search(Connection, Transaction, new ORM_CMN_PER_PersonInfo.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false,
                    CMN_PER_PersonInfoID = businessParticpant.IfNaturalPerson_CMN_PER_PersonInfo_RefID
                }).Single();
                personInfo.Title = Parameter.ContactPerson.Title;
                personInfo.FirstName = Parameter.ContactPerson.FirstName;
                personInfo.LastName = Parameter.ContactPerson.LastName;
                personInfo.Save(Connection, Transaction);

                returnValue.Result = office.CMN_STR_OfficeID;
            }
            #endregion

            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5OU_SOUGD_1221 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5OU_SOUGD_1221 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5OU_SOUGD_1221 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5OU_SOUGD_1221 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_OrgsUnitsGeneralData",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5OU_SOUGD_1221 for attribute P_L5OU_SOUGD_1221
		[DataContract]
		public class P_L5OU_SOUGD_1221 
		{
			[DataMember]
			public P_L5OU_SOUGD_1221_ContactPerson ContactPerson { get; set; }
			[DataMember]
			public P_L5OU_SOUGD_1221_Addresses[] Adresses { get; set; }
			[DataMember]
			public P_L5OU_SOUGD_1221_AppType[] AppoitmentType { get; set; }
			[DataMember]
			public P_L5OU_SOUGD_1221_MedPracticeType[] MedicalPracticeType { get; set; }
			[DataMember]
			public P_L5OU_SOUGD_1221_SpokenLanguage[] SpokenLanguage { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid OrgUnitID { get; set; } 
			[DataMember]
			public Dict OrgUnitName_DictID { get; set; } 
			[DataMember]
			public Guid ParentID { get; set; } 
			[DataMember]
			public String Telephone { get; set; } 
			[DataMember]
			public String Email { get; set; } 
			[DataMember]
			public String Website { get; set; } 
			[DataMember]
			public String Notes { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 
			[DataMember]
			public Guid DisplayImage_Document_RefID { get; set; } 

		}
		#endregion
		#region SClass P_L5OU_SOUGD_1221_ContactPerson for attribute ContactPerson
		[DataContract]
		public class P_L5OU_SOUGD_1221_ContactPerson 
		{
			//Standard type parameters
			[DataMember]
			public String FirstName { get; set; } 
			[DataMember]
			public String LastName { get; set; } 
			[DataMember]
			public String Title { get; set; } 

		}
		#endregion
		#region SClass P_L5OU_SOUGD_1221_Addresses for attribute Adresses
		[DataContract]
		public class P_L5OU_SOUGD_1221_Addresses 
		{
			//Standard type parameters
			[DataMember]
			public Boolean IsShippingAddress { get; set; } 
			[DataMember]
			public Boolean IsBillingAddress { get; set; } 
			[DataMember]
			public Boolean IsSpecialAddress { get; set; } 
			[DataMember]
			public Boolean IsDefault { get; set; } 
			[DataMember]
			public Guid AddressID { get; set; } 
			[DataMember]
			public String Street_Number { get; set; } 
			[DataMember]
			public String Street_Name { get; set; } 
			[DataMember]
			public String ZIP { get; set; } 
			[DataMember]
			public String City { get; set; } 
			[DataMember]
			public String CountryISO { get; set; } 
			[DataMember]
			public String CountryName { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 
			[DataMember]
			public double Longitude { get; set; } 
			[DataMember]
			public double Lattitude { get; set; } 

		}
		#endregion
		#region SClass P_L5OU_SOUGD_1221_AppType for attribute AppoitmentType
		[DataContract]
		public class P_L5OU_SOUGD_1221_AppType 
		{
			//Standard type parameters
			[DataMember]
			public Guid PPS_TSK_Task_Template_RefID { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 

		}
		#endregion
		#region SClass P_L5OU_SOUGD_1221_MedPracticeType for attribute MedicalPracticeType
		[DataContract]
		public class P_L5OU_SOUGD_1221_MedPracticeType 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_MedicalPractice_TypeID { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 

		}
		#endregion
		#region SClass P_L5OU_SOUGD_1221_SpokenLanguage for attribute SpokenLanguage
		[DataContract]
		public class P_L5OU_SOUGD_1221_SpokenLanguage 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_LanguageID { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_OrgsUnitsGeneralData(,P_L5OU_SOUGD_1221 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_OrgsUnitsGeneralData.Invoke(connectionString,P_L5OU_SOUGD_1221 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_OrgUnits.Atomic.Manipulation.P_L5OU_SOUGD_1221();
parameter.ContactPerson = ...;
parameter.Adresses = ...;
parameter.AppoitmentType = ...;
parameter.MedicalPracticeType = ...;
parameter.SpokenLanguage = ...;

parameter.OrgUnitID = ...;
parameter.OrgUnitName_DictID = ...;
parameter.ParentID = ...;
parameter.Telephone = ...;
parameter.Email = ...;
parameter.Website = ...;
parameter.Notes = ...;
parameter.IsDeleted = ...;
parameter.DisplayImage_Document_RefID = ...;

*/
