/* 
 * Generated on 9/10/2013 12:53:39 PM
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
using CL3_MedicalPractices.Atomic.Retrieval;
using CL1_CMN_CAL;
using CL1_CMN_COM;
using CL1_HEC;
using CL1_CMN_BPT_CTM;
using CL1_CMN;

namespace CL3_MedicalPractices.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Practice_For_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Practice_For_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3MP_GPfT_1209_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L3MP_GPfT_1209_Array();

            List<L3MP_GPfT_1209> res = new List<L3MP_GPfT_1209>();

            var baseInfos = cls_Get_Practice_BaseInfo_For_Tenant.Invoke(Connection, Transaction, securityTicket).Result;
            var contactsP = cls_Get_Practice_ContactPerson_For_Tenant.Invoke(Connection, Transaction, securityTicket).Result;

            var officeHoursQuery = new ORM_CMN_CAL_WeeklyOfficeHours_Template.Query();
            officeHoursQuery.IsDeleted = false;
            officeHoursQuery.Tenant_RefID = securityTicket.TenantID;
            var officeHours = ORM_CMN_CAL_WeeklyOfficeHours_Template.Query.Search(Connection, Transaction, officeHoursQuery);

            var companyTypeQuery = new ORM_CMN_COM_CompanyInfo_Type.Query();
            companyTypeQuery.IsDeleted = false;
            companyTypeQuery.Tenant_RefID = securityTicket.TenantID;
            var companyTypes = ORM_CMN_COM_CompanyInfo_Type.Query.Search(Connection, Transaction, companyTypeQuery);

            var pHealthcareQuery = new ORM_HEC_PublicHealthcare_PhysitianAssociation.Query();
            pHealthcareQuery.Tenant_RefID = securityTicket.TenantID;
            var pHealthcares = ORM_HEC_PublicHealthcare_PhysitianAssociation.Query.Search(Connection, Transaction, pHealthcareQuery);

            var customerQuery = new ORM_CMN_BPT_CTM_Customer.Query();
            customerQuery.Tenant_RefID = securityTicket.TenantID;
            var customers = ORM_CMN_BPT_CTM_Customer.Query.Search(Connection, Transaction, customerQuery);
            var affinityStatusQuery = new ORM_CMN_BPT_CTM_AffinityStatus.Query();
            affinityStatusQuery.Tenant_RefID = securityTicket.TenantID;
            var affinityStatuses = ORM_CMN_BPT_CTM_AffinityStatus.Query.Search(Connection, Transaction, affinityStatusQuery);

            var compAddressQuery = new ORM_CMN_COM_CompanyInfo_Address.Query();
            compAddressQuery.Tenant_RefID = securityTicket.TenantID;
            compAddressQuery.IsShipping = true;
            compAddressQuery.IsDeleted = false;
            var compAddresses = ORM_CMN_COM_CompanyInfo_Address.Query.Search(Connection, Transaction, compAddressQuery);
            var addressQuery = new ORM_CMN_UniversalContactDetail.Query();
            addressQuery.Tenant_RefID = securityTicket.TenantID;
            addressQuery.IsDeleted = false;
            var addresses = ORM_CMN_UniversalContactDetail.Query.Search(Connection, Transaction, addressQuery);

            foreach (var bInfo in baseInfos)
            {
                L3MP_GPfT_1209 practice = new L3MP_GPfT_1209();
                practice.BaseInfo = bInfo;
                if(bInfo.ContactPerson_RefID != null)
                {
                    var contactPerson = contactsP.FirstOrDefault(c => c.CMN_BPT_BusinessParticipantID == bInfo.ContactPerson_RefID);
                    practice.ContactPerson = contactPerson;
                }

                if (bInfo.WeeklyOfficeHours_Template_RefID != Guid.Empty && bInfo.WeeklySurgeryHours_Template_RefID != Guid.Empty)
                {           
                    var oHours = officeHours.FirstOrDefault(o => o.CMN_CAL_WeeklyOfficeHours_TemplateID == bInfo.WeeklyOfficeHours_Template_RefID);
                    var cHours = officeHours.FirstOrDefault(o => o.CMN_CAL_WeeklyOfficeHours_TemplateID == bInfo.WeeklySurgeryHours_Template_RefID);
                    if (oHours != null && cHours != null)
                    {
                        practice.OfficeHours = new L3MP_GPfT_1209_OfficeHours();
                        practice.OfficeHours.ConsultingHours_FormattedOfficeHours = cHours.FormattedOfficeHours;
                        practice.OfficeHours.WorkingHours_FormattedOfficeHours = oHours.FormattedOfficeHours;
                    }
                }
                if (bInfo.CompanyType_RefID != Guid.Empty)
                {
                    practice.OtherOphthal_PracticeData = new L3MP_GPfT_1209_OtherOphthal_PracticeData();
                    var company = companyTypes.FirstOrDefault(c => c.CMN_COM_CompanyInfo_TypeID == bInfo.CompanyType_RefID);
                    if (company != null)
                    {                
                        practice.OtherOphthal_PracticeData.CompanyType_Name = company.CompanyType_Name;
                        practice.OtherOphthal_PracticeData.CMN_COM_CompanyInfo_TypeID = company.CMN_COM_CompanyInfo_TypeID;                 
                    }

                    var pHealthcare = pHealthcares.FirstOrDefault(c => c.HEC_PublicHealthcare_PhysitianAssociationID == bInfo.AssociatedWith_PhysitianAssociation_RefID);
                    if (pHealthcare != null)
                    {
                        practice.OtherOphthal_PracticeData.HealthAssociation_Name = pHealthcare.HealthAssociation_Name;
                        practice.OtherOphthal_PracticeData.HEC_PublicHealthcare_PhysitianAssociationID = pHealthcare.HEC_PublicHealthcare_PhysitianAssociationID;
                    }
                }

                var customer = customers.FirstOrDefault(c => c.Ext_BusinessParticipant_RefID == bInfo.CMN_BPT_BusinessParticipantID);
                if(customer != null)
                {
                    var affinityStatus = affinityStatuses.FirstOrDefault(a => a.CMN_BPT_CTM_AffinityStatusID == customer.CustomerAffinityStatus_RefID);
                    if (affinityStatus != null)
                    {
                        practice.OtherOphthal_PracticeData.CMN_BPT_CTM_AffinityStatusID = affinityStatus.CMN_BPT_CTM_AffinityStatusID;
                        practice.OtherOphthal_PracticeData.AffinityStatus_Name = affinityStatus.AffinityStatus_Name;
                    }
                }

                var compAddress = compAddresses.FirstOrDefault(ca => ca.CompanyInfo_RefID == bInfo.CMN_COM_CompanyInfoID);
                if(compAddress != null)
                {
                    var address = addresses.FirstOrDefault(a => a.CMN_UniversalContactDetailID == compAddress.Address_UCD_RefID);
                    if (address != null)
                    {
                        practice.ShippingAddress = new L3MP_GPfT_1209_ShippingAddress();
                        practice.ShippingAddress.CMN_UniversalContactDetailID = address.CMN_UniversalContactDetailID;
                        practice.ShippingAddress.CMN_COM_CompanyInfo_AddressID = compAddress.CMN_COM_CompanyInfo_AddressID;
                        practice.ShippingAddress.Region_Name = address.Region_Name;
                        practice.ShippingAddress.Street_Name = address.Street_Name;
                        practice.ShippingAddress.Street_Number = address.Street_Number;
                        practice.ShippingAddress.Town = address.Town;
                        practice.ShippingAddress.ZIP = address.ZIP;
                    }
                }
                
                res.Add(practice);
            }

            returnValue.Result = res.ToArray();

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3MP_GPfT_1209_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3MP_GPfT_1209_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3MP_GPfT_1209_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3MP_GPfT_1209_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3MP_GPfT_1209_Array functionReturn = new FR_L3MP_GPfT_1209_Array();
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

				functionReturn = Execute(Connection, Transaction,securityTicket);

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

				throw new Exception("Exception occured in method cls_Get_Practice_For_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3MP_GPfT_1209_Array : FR_Base
	{
		public L3MP_GPfT_1209[] Result	{ get; set; } 
		public FR_L3MP_GPfT_1209_Array() : base() {}

		public FR_L3MP_GPfT_1209_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L3MP_GPfT_1209 for attribute L3MP_GPfT_1209
		[DataContract]
		public class L3MP_GPfT_1209 
		{
			[DataMember]
			public L3MP_GPfT_1209_ShippingAddress ShippingAddress { get; set; }
			[DataMember]
			public L3MP_GPfT_1209_OfficeHours OfficeHours { get; set; }
			[DataMember]
			public L3MP_GPfT_1209_OtherOphthal_PracticeData OtherOphthal_PracticeData { get; set; }

			//Standard type parameters
			[DataMember]
			public L3MP_GPBIfT_1706 BaseInfo { get; set; } 
			[DataMember]
			public L3MP_GPCPfT_1214 ContactPerson { get; set; } 

		}
		#endregion
		#region SClass L3MP_GPfT_1209_ShippingAddress for attribute ShippingAddress
		[DataContract]
		public class L3MP_GPfT_1209_ShippingAddress 
		{
			//Standard type parameters
			[DataMember]
			public String Street_Name { get; set; } 
			[DataMember]
			public String Street_Number { get; set; } 
			[DataMember]
			public String ZIP { get; set; } 
			[DataMember]
			public String Town { get; set; } 
			[DataMember]
			public String Region_Name { get; set; } 
			[DataMember]
			public Guid CMN_COM_CompanyInfo_AddressID { get; set; } 
			[DataMember]
			public Guid CMN_UniversalContactDetailID { get; set; } 

		}
		#endregion
		#region SClass L3MP_GPfT_1209_OfficeHours for attribute OfficeHours
		[DataContract]
		public class L3MP_GPfT_1209_OfficeHours 
		{
			//Standard type parameters
			[DataMember]
			public String ConsultingHours_FormattedOfficeHours { get; set; } 
			[DataMember]
			public String WorkingHours_FormattedOfficeHours { get; set; } 

		}
		#endregion
		#region SClass L3MP_GPfT_1209_OtherOphthal_PracticeData for attribute OtherOphthal_PracticeData
		[DataContract]
		public class L3MP_GPfT_1209_OtherOphthal_PracticeData 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_BPT_CTM_AffinityStatusID { get; set; } 
			[DataMember]
			public Dict AffinityStatus_Name { get; set; } 
			[DataMember]
			public Guid HEC_PublicHealthcare_PhysitianAssociationID { get; set; } 
			[DataMember]
			public String HealthAssociation_Name { get; set; } 
			[DataMember]
			public Guid Contact_UCD_RefID { get; set; } 
			[DataMember]
			public Guid CMN_COM_CompanyInfo_TypeID { get; set; } 
			[DataMember]
			public Dict CompanyType_Name { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3MP_GPfT_1209_Array cls_Get_Practice_For_Tenant(string sessionToken = null)
{
	try
	{
		var securityTicket = VerifySessionToken(sessionToken);
		FR_L3MP_GPfT_1209_Array invocationResult = cls_Get_Practice_For_Tenant.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

