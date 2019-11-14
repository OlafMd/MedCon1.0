/* 
 * Generated on 9/16/2013 4:40:33 PM
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
using CL3_MedicalPractices.Atomic.Manipulation;
using CL1_HEC;
using CL1_CMN_COM;
using CL1_CMN_BPT;
using CL1_CMN_CAL;
using CL1_CMN_BPT_CTM;
using CL1_CMN;
using CL2_Language.Atomic.Retrieval;
using Core_ClassLibrarySupport.Apoteken;

namespace CL5_OphthalPractices.Complex.Manipulation
{
	/// <summary>
    /// No description found in <meta/> tag
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Practice.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Practice
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5OP_SP_1602 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            P_L2LN_GALFTID_1530 langParam = new P_L2LN_GALFTID_1530();
            langParam.Tenant_RefID = securityTicket.TenantID;
            var languages = cls_Get_All_Languages_ForTenantID.Invoke(Connection, Transaction, langParam, securityTicket).Result;

            P_L3MP_SPBI_1602 basePracticeParam = new P_L3MP_SPBI_1602();
            basePracticeParam.HEC_MedicalPractiseID = Parameter.HEC_MedicalPractiseID;
            basePracticeParam.Contact_EmergencyPhoneNumber = Parameter.PhoneNumber;
            basePracticeParam.Contact_Website_URL = Parameter.HomepageURL;
            basePracticeParam.PracticeEmail = Parameter.ContactEmail;
            basePracticeParam.PracticeName = Parameter.DisplyName;
            basePracticeParam.Region_Name = Parameter.AddressRegion;
            basePracticeParam.Street_Name = Parameter.AddressStreetName;
            basePracticeParam.Street_Number = Parameter.AddressStreetNumber;
            basePracticeParam.Town = Parameter.AddressCity;
            basePracticeParam.ZIP = Parameter.AddressZipCode;
            var practiceID = cls_Save_Practice_BaseInfo.Invoke(Connection, Transaction, basePracticeParam, securityTicket).Result;

            var practicesQuery = new ORM_HEC_MedicalPractis.Query();
            practicesQuery.HEC_MedicalPractiseID = practiceID;
            var practices = ORM_HEC_MedicalPractis.Query.Search(Connection, Transaction, practicesQuery).First();

            var companyInfoQuery = new ORM_CMN_COM_CompanyInfo.Query();
            companyInfoQuery.CMN_COM_CompanyInfoID = practices.Ext_CompanyInfo_RefID;
            var companyInfo = ORM_CMN_COM_CompanyInfo.Query.Search(Connection, Transaction, companyInfoQuery).First();

            var bParticipantQuery = new ORM_CMN_BPT_BusinessParticipant.Query();
            bParticipantQuery.IfCompany_CMN_COM_CompanyInfo_RefID = companyInfo.CMN_COM_CompanyInfoID;
            var bParticipant = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, bParticipantQuery).First();

            ORM_CMN_BPT_BusinessParticipant bpContctPerson;

            if (practices.ContactPerson_RefID != Guid.Empty)
            {
                var bpContctPersonQuery = new ORM_CMN_BPT_BusinessParticipant.Query();
                bpContctPersonQuery.CMN_BPT_BusinessParticipantID = practices.ContactPerson_RefID;
                bpContctPerson = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, bpContctPersonQuery).First();
            }
            else
            {
                bpContctPerson = new ORM_CMN_BPT_BusinessParticipant();
                bpContctPerson.Tenant_RefID = securityTicket.TenantID;
                bpContctPerson.IsNaturalPerson = true;
            }
            bpContctPerson.DisplayName = Parameter.ContactPerson_Name;
            bpContctPerson.Save(Connection, Transaction);

            practices.ContactPerson_RefID = bpContctPerson.CMN_BPT_BusinessParticipantID;

            ORM_CMN_CAL_WeeklyOfficeHours_Template officeHours;
            ORM_CMN_CAL_WeeklyOfficeHours_Template consultingHours;
            if (practices.WeeklyOfficeHours_Template_RefID != Guid.Empty && practices.WeeklySurgeryHours_Template_RefID != Guid.Empty)
            {
                var officeHoursQuery = new ORM_CMN_CAL_WeeklyOfficeHours_Template.Query();
                officeHoursQuery.CMN_CAL_WeeklyOfficeHours_TemplateID = practices.WeeklyOfficeHours_Template_RefID;
                officeHours = ORM_CMN_CAL_WeeklyOfficeHours_Template.Query.Search(Connection, Transaction, officeHoursQuery).First();

                officeHoursQuery.CMN_CAL_WeeklyOfficeHours_TemplateID = practices.WeeklySurgeryHours_Template_RefID;
                consultingHours = ORM_CMN_CAL_WeeklyOfficeHours_Template.Query.Search(Connection, Transaction, officeHoursQuery).First();
            }
            else
            {
                officeHours = new ORM_CMN_CAL_WeeklyOfficeHours_Template();
                officeHours.CMN_CAL_WeeklyOfficeHours_TemplateID = Guid.NewGuid();
                consultingHours = new ORM_CMN_CAL_WeeklyOfficeHours_Template();
                consultingHours.CMN_CAL_WeeklyOfficeHours_TemplateID = Guid.NewGuid();
                
                practices.WeeklyOfficeHours_Template_RefID = officeHours.CMN_CAL_WeeklyOfficeHours_TemplateID;
                practices.WeeklySurgeryHours_Template_RefID = consultingHours.CMN_CAL_WeeklyOfficeHours_TemplateID;

            }
            consultingHours.Tenant_RefID = securityTicket.TenantID;
            officeHours.Tenant_RefID = securityTicket.TenantID;
            consultingHours.FormattedOfficeHours = Parameter.Consultation_FormattedOfficeHours;
            officeHours.FormattedOfficeHours = Parameter.Working_FormattedOfficeHours;

            consultingHours.Save(Connection, Transaction);
            officeHours.Save(Connection, Transaction);

            ORM_CMN_COM_CompanyInfo_Type companyType;

            var companyTypeQuery = new ORM_CMN_COM_CompanyInfo_Type.Query();
            companyTypeQuery.IsDeleted = false;
            companyTypeQuery.CMN_COM_CompanyInfo_TypeID = Parameter.PracticeType_RefID;
            companyType = ORM_CMN_COM_CompanyInfo_Type.Query.Search(Connection, Transaction, companyTypeQuery).FirstOrDefault();
            if (companyType == null)
            {
                companyType = new ORM_CMN_COM_CompanyInfo_Type();
                companyType.CMN_COM_CompanyInfo_TypeID = Parameter.PracticeType_RefID;
                companyType.CompanyType_Name = new Dict();
                companyType.CompanyType_Name.DictionaryID = Guid.NewGuid();
                if (languages != null)
                {
                    foreach (var item in languages)
                    {
                        companyType.CompanyType_Name.AddEntry(item.CMN_LanguageID, STLD_PracticeType.typesItems.First(t => t.Value == Parameter.PracticeType_RefID).Text);
                    }
                }         
            }
            companyInfo.CompanyType_RefID = Parameter.PracticeType_RefID;

            ORM_HEC_PublicHealthcare_PhysitianAssociation pHealthcare;
            var pHealthcareQuery = new ORM_HEC_PublicHealthcare_PhysitianAssociation.Query();
            pHealthcareQuery.HEC_PublicHealthcare_PhysitianAssociationID = Parameter.HealthAssociation_RefID;
            pHealthcare = ORM_HEC_PublicHealthcare_PhysitianAssociation.Query.Search(Connection, Transaction, pHealthcareQuery).FirstOrDefault();
            if (pHealthcare == null)
            {
                pHealthcare = new ORM_HEC_PublicHealthcare_PhysitianAssociation();
                pHealthcare.HEC_PublicHealthcare_PhysitianAssociationID = Parameter.HealthAssociation_RefID;
                pHealthcare.HealthAssociation_Name = STLD_MedicalAssociation.associationItems.First(t => t.Value == Parameter.HealthAssociation_RefID).Text;
                pHealthcare.Save(Connection, Transaction);
            }
            practices.AssociatedWith_PhysitianAssociation_RefID = Parameter.HealthAssociation_RefID;

            ORM_CMN_BPT_CTM_Customer customer;
            var customerQuery = new ORM_CMN_BPT_CTM_Customer.Query();
            customerQuery.Ext_BusinessParticipant_RefID = bParticipant.CMN_BPT_BusinessParticipantID;
            var customerRes = ORM_CMN_BPT_CTM_Customer.Query.Search(Connection, Transaction, customerQuery);
            if (customerRes.Count == 0)
            {
                customer = new ORM_CMN_BPT_CTM_Customer();
                customer.CMN_BPT_CTM_CustomerID = Guid.NewGuid();
                customer.Ext_BusinessParticipant_RefID = bParticipant.CMN_BPT_BusinessParticipantID;
            }
            else
            {
                customer = ORM_CMN_BPT_CTM_Customer.Query.Search(Connection, Transaction, customerQuery).First();           
            }

            var affinityStatusQuery = new ORM_CMN_BPT_CTM_AffinityStatus.Query();
            affinityStatusQuery.CMN_BPT_CTM_AffinityStatusID = Parameter.AffinityStatus_RefID;
            var affinityStatus = ORM_CMN_BPT_CTM_AffinityStatus.Query.Search(Connection, Transaction, affinityStatusQuery).FirstOrDefault();
            if (affinityStatus == null)
            {
                affinityStatus = new ORM_CMN_BPT_CTM_AffinityStatus();
                affinityStatus.CMN_BPT_CTM_AffinityStatusID = Parameter.AffinityStatus_RefID;
                affinityStatus.AffinityStatus_Name = new Dict();
                affinityStatus.AffinityStatus_Name.DictionaryID = Guid.NewGuid();
                if (languages != null)
                {
                    foreach (var item in languages)
                    {
                        affinityStatus.AffinityStatus_Name.AddEntry(item.CMN_LanguageID, STLD_AffinityStatus.affinityItems.First(t => t.Value == Parameter.AffinityStatus_RefID).Text);
                    }
                }    
                affinityStatus.Save(Connection, Transaction);
            }

            customer.CustomerAffinityStatus_RefID = Parameter.AffinityStatus_RefID;
            customer.Tenant_RefID = securityTicket.TenantID;

            customer.Save(Connection, Transaction);

            ORM_CMN_COM_CompanyInfo_Address compAddress;
            ORM_CMN_UniversalContactDetail address;

            var compAddressQuery = new ORM_CMN_COM_CompanyInfo_Address.Query();
            compAddressQuery.Tenant_RefID = securityTicket.TenantID;
            compAddressQuery.CompanyInfo_RefID = practices.Ext_CompanyInfo_RefID;
            var compAddressRes = ORM_CMN_COM_CompanyInfo_Address.Query.Search(Connection, Transaction, compAddressQuery);

            if (compAddressRes.Count > 0)
            {
                compAddress = compAddressRes.First();
                var addressQuery = new ORM_CMN_UniversalContactDetail.Query();
                addressQuery.CMN_UniversalContactDetailID = compAddress.Address_UCD_RefID;
                address = ORM_CMN_UniversalContactDetail.Query.Search(Connection, Transaction, addressQuery).First();
            }
            else
            {
                compAddress = new ORM_CMN_COM_CompanyInfo_Address();
                compAddress.CMN_COM_CompanyInfo_AddressID = Guid.NewGuid();
                compAddress.IsShipping = true;
                compAddress.CompanyInfo_RefID = companyInfo.CMN_COM_CompanyInfoID;

                address = new ORM_CMN_UniversalContactDetail();
                address.CMN_UniversalContactDetailID = Guid.NewGuid();

                compAddress.Address_UCD_RefID = address.CMN_UniversalContactDetailID;
            }

            address.Town = Parameter.ShippingAddressCity;
            address.Street_Number = Parameter.ShippingAddressStreetNumber;
            address.Street_Name = Parameter.ShippingAddressStreetName;
            address.ZIP = Parameter.ShippingAddressZipCode;
            address.Region_Name = Parameter.ShippingAddressRegion;

            address.Tenant_RefID = securityTicket.TenantID;
            address.Save(Connection, Transaction);
            compAddress.Tenant_RefID = securityTicket.TenantID;
            compAddress.Save(Connection, Transaction);

            ORM_CMN_BPT_BusinessParticipant contactPBP;
            if (practices.ContactPerson_RefID != Guid.Empty)
            {
                var contactPBPQuery = new ORM_CMN_BPT_BusinessParticipant.Query();
                contactPBPQuery.CMN_BPT_BusinessParticipantID = practices.ContactPerson_RefID;
                contactPBP = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, contactPBPQuery).First();
            }
            else
            {
                contactPBP = new ORM_CMN_BPT_BusinessParticipant();
                contactPBP.CMN_BPT_BusinessParticipantID = Guid.NewGuid();
                contactPBP.IsCompany = true;
                practices.ContactPerson_RefID = contactPBP.CMN_BPT_BusinessParticipantID;
            }
            contactPBP.DisplayName = Parameter.ContactPerson_Name;
            contactPBP.Tenant_RefID = securityTicket.TenantID;
            contactPBP.Save(Connection, Transaction);

            companyInfo.Save(Connection, Transaction);
            practices.Save(Connection, Transaction);
            returnValue.Result = practices.HEC_MedicalPractiseID;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5OP_SP_1602 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5OP_SP_1602 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5OP_SP_1602 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5OP_SP_1602 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Practice",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5OP_SP_1602 for attribute P_L5OP_SP_1602
		[DataContract]
		public class P_L5OP_SP_1602 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_MedicalPractiseID { get; set; } 
			[DataMember]
			public String DisplyName { get; set; } 
			[DataMember]
			public String ShippingAddressStreetNumber { get; set; } 
			[DataMember]
			public String ShippingAddressStreetName { get; set; } 
			[DataMember]
			public String ShippingAddressCity { get; set; } 
			[DataMember]
			public String ShippingAddressRegion { get; set; } 
			[DataMember]
			public String ShippingAddressZipCode { get; set; } 
			[DataMember]
			public String AddressStreetNumber { get; set; } 
			[DataMember]
			public String AddressStreetName { get; set; } 
			[DataMember]
			public String AddressCity { get; set; } 
			[DataMember]
			public String AddressRegion { get; set; } 
			[DataMember]
			public String AddressZipCode { get; set; } 
			[DataMember]
			public String PhoneNumber { get; set; } 
			[DataMember]
			public String HomepageURL { get; set; } 
			[DataMember]
			public String ContactEmail { get; set; } 
			[DataMember]
			public Guid PracticeType_RefID { get; set; } 
			[DataMember]
			public String ContactPerson_Name { get; set; } 
			[DataMember]
			public String Working_FormattedOfficeHours { get; set; } 
			[DataMember]
			public String Consultation_FormattedOfficeHours { get; set; } 
			[DataMember]
			public Guid AffinityStatus_RefID { get; set; } 
			[DataMember]
			public Guid HealthAssociation_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Practice(,P_L5OP_SP_1602 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Practice.Invoke(connectionString,P_L5OP_SP_1602 Parameter,securityTicket);
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
var parameter = new CL5_OphthalPractices.Complex.Manipulation.P_L5OP_SP_1602();
parameter.HEC_MedicalPractiseID = ...;
parameter.DisplyName = ...;
parameter.ShippingAddressStreetNumber = ...;
parameter.ShippingAddressStreetName = ...;
parameter.ShippingAddressCity = ...;
parameter.ShippingAddressRegion = ...;
parameter.ShippingAddressZipCode = ...;
parameter.AddressStreetNumber = ...;
parameter.AddressStreetName = ...;
parameter.AddressCity = ...;
parameter.AddressRegion = ...;
parameter.AddressZipCode = ...;
parameter.PhoneNumber = ...;
parameter.HomepageURL = ...;
parameter.ContactEmail = ...;
parameter.PracticeType_RefID = ...;
parameter.ContactPerson_Name = ...;
parameter.Working_FormattedOfficeHours = ...;
parameter.Consultation_FormattedOfficeHours = ...;
parameter.AffinityStatus_RefID = ...;
parameter.HealthAssociation_RefID = ...;

*/
