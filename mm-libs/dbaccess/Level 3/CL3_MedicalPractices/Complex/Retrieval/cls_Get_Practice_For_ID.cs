/* 
 * Generated on 8/30/2013 1:05:11 PM
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
    /// var result = cls_Get_Practice_For_ID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Practice_For_ID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3MP_GPfID_1222 Execute(DbConnection Connection,DbTransaction Transaction,P_L3MP_GPfID_1222 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L3MP_GPfID_1222();

            returnValue.Result = new L3MP_GPfID_1222();
			
            P_L3MP_GPBIfID_1131 paramBasicInfo = new P_L3MP_GPBIfID_1131();
            paramBasicInfo.HEC_MedicalPractiseID = Parameter.HEC_MedicalPractiseID;
            var baseInfo = cls_Get_Practice_BaseInfo_For_ID.Invoke(Connection, Transaction, paramBasicInfo, securityTicket).Result;
            if (baseInfo == null)
            {
                returnValue.Result = null;
                return returnValue;
            }

            returnValue.Result.BaseInfo = baseInfo;

            P_L3MP_GPCPfPID_1155 paramCP = new P_L3MP_GPCPfPID_1155();
            paramCP.CMN_BPT_BusinessParticipantID = baseInfo.ContactPerson_RefID;
            var contactPerson = cls_Get_Practice_ContactPerson_For_PersonID.Invoke(Connection, Transaction, paramCP, securityTicket).Result;
            returnValue.Result.ContactPerson = contactPerson;

            if (baseInfo.WeeklyOfficeHours_Template_RefID != Guid.Empty && baseInfo.WeeklySurgeryHours_Template_RefID != Guid.Empty)
            {
                returnValue.Result.OfficeHours = new L3MP_GPfID_1222_OfficeHours();

                var officeHoursQuery = new ORM_CMN_CAL_WeeklyOfficeHours_Template.Query();
                officeHoursQuery.IsDeleted = false;
                officeHoursQuery.Tenant_RefID = securityTicket.TenantID;
                officeHoursQuery.CMN_CAL_WeeklyOfficeHours_TemplateID = baseInfo.WeeklyOfficeHours_Template_RefID;
                var officeHours = ORM_CMN_CAL_WeeklyOfficeHours_Template.Query.Search(Connection, Transaction, officeHoursQuery).First();
                returnValue.Result.OfficeHours.WorkingHours_FormattedOfficeHours = officeHours.FormattedOfficeHours;
                officeHoursQuery.CMN_CAL_WeeklyOfficeHours_TemplateID = baseInfo.WeeklySurgeryHours_Template_RefID;
                var consultingHours = ORM_CMN_CAL_WeeklyOfficeHours_Template.Query.Search(Connection, Transaction, officeHoursQuery).First();
                returnValue.Result.OfficeHours.ConsultingHours_FormattedOfficeHours = consultingHours.FormattedOfficeHours;

                returnValue.Result.OtherOphthal_PracticeData = new L3MP_GPfID_1222_OtherOphthal_PracticeData();
                var companyTypeQuery = new ORM_CMN_COM_CompanyInfo_Type.Query();
                companyTypeQuery.IsDeleted = false;
                companyTypeQuery.CMN_COM_CompanyInfo_TypeID = baseInfo.CompanyType_RefID;
                var companyType = ORM_CMN_COM_CompanyInfo_Type.Query.Search(Connection, Transaction, companyTypeQuery).First();
                returnValue.Result.OtherOphthal_PracticeData.CompanyType_Name = companyType.CompanyType_Name;
                returnValue.Result.OtherOphthal_PracticeData.CMN_COM_CompanyInfo_TypeID = companyType.CMN_COM_CompanyInfo_TypeID;
                var pHealthcareQuery = new ORM_HEC_PublicHealthcare_PhysitianAssociation.Query();
                pHealthcareQuery.HEC_PublicHealthcare_PhysitianAssociationID = baseInfo.AssociatedWith_PhysitianAssociation_RefID;
                var pHealthcare = ORM_HEC_PublicHealthcare_PhysitianAssociation.Query.Search(Connection, Transaction, pHealthcareQuery).First();
                returnValue.Result.OtherOphthal_PracticeData.HealthAssociation_Name = pHealthcare.HealthAssociation_Name;
                returnValue.Result.OtherOphthal_PracticeData.HEC_PublicHealthcare_PhysitianAssociationID = baseInfo.AssociatedWith_PhysitianAssociation_RefID;
                   var customerQuery = new ORM_CMN_BPT_CTM_Customer.Query();
                customerQuery.Ext_BusinessParticipant_RefID = baseInfo.CMN_BPT_BusinessParticipantID;
                var customer = ORM_CMN_BPT_CTM_Customer.Query.Search(Connection, Transaction, customerQuery).FirstOrDefault();

                if (customer != null)
                {
                    var affinityStatusQuery = new ORM_CMN_BPT_CTM_AffinityStatus.Query();
                    affinityStatusQuery.CMN_BPT_CTM_AffinityStatusID = customer.CustomerAffinityStatus_RefID;
                    var affinityStatus = ORM_CMN_BPT_CTM_AffinityStatus.Query.Search(Connection, Transaction, affinityStatusQuery).FirstOrDefault();

                    if (affinityStatus != null)
                    {
                        returnValue.Result.OtherOphthal_PracticeData.CMN_BPT_CTM_AffinityStatusID = affinityStatus.CMN_BPT_CTM_AffinityStatusID;
                        returnValue.Result.OtherOphthal_PracticeData.AffinityStatus_Name = affinityStatus.AffinityStatus_Name;
                    }

                }
                returnValue.Result.ShippingAddress = new L3MP_GPfID_1222_ShippingAddress();
                var compAddressQuery = new ORM_CMN_COM_CompanyInfo_Address.Query();
                compAddressQuery.Tenant_RefID = securityTicket.TenantID;
                compAddressQuery.CompanyInfo_RefID = baseInfo.CMN_COM_CompanyInfoID;
                compAddressQuery.IsShipping = true;
                compAddressQuery.IsDeleted = false;
                var compAddress = ORM_CMN_COM_CompanyInfo_Address.Query.Search(Connection, Transaction, compAddressQuery).First();
                var addressQuery = new ORM_CMN_UniversalContactDetail.Query();
                addressQuery.Tenant_RefID = securityTicket.TenantID;
                addressQuery.IsDeleted = false;
                addressQuery.CMN_UniversalContactDetailID = compAddress.Address_UCD_RefID;
                var address = ORM_CMN_UniversalContactDetail.Query.Search(Connection, Transaction, addressQuery).First();

                returnValue.Result.ShippingAddress.CMN_UniversalContactDetailID = address.CMN_UniversalContactDetailID;
                returnValue.Result.ShippingAddress.CMN_COM_CompanyInfo_AddressID = compAddress.CMN_COM_CompanyInfo_AddressID;

                returnValue.Result.ShippingAddress.Region_Name = address.Region_Name;
                returnValue.Result.ShippingAddress.Street_Name = address.Street_Name;
                returnValue.Result.ShippingAddress.Street_Number = address.Street_Number;
                returnValue.Result.ShippingAddress.Town = address.Town;
                returnValue.Result.ShippingAddress.ZIP = address.ZIP;
            }

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3MP_GPfID_1222 Invoke(string ConnectionString,P_L3MP_GPfID_1222 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3MP_GPfID_1222 Invoke(DbConnection Connection,P_L3MP_GPfID_1222 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3MP_GPfID_1222 Invoke(DbConnection Connection, DbTransaction Transaction,P_L3MP_GPfID_1222 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3MP_GPfID_1222 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3MP_GPfID_1222 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3MP_GPfID_1222 functionReturn = new FR_L3MP_GPfID_1222();
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

				throw new Exception("Exception occured in method cls_Get_Practice_For_ID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3MP_GPfID_1222 : FR_Base
	{
		public L3MP_GPfID_1222 Result	{ get; set; }

		public FR_L3MP_GPfID_1222() : base() {}

		public FR_L3MP_GPfID_1222(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3MP_GPfID_1222 for attribute P_L3MP_GPfID_1222
		[DataContract]
		public class P_L3MP_GPfID_1222 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_MedicalPractiseID { get; set; } 

		}
		#endregion
		#region SClass L3MP_GPfID_1222 for attribute L3MP_GPfID_1222
		[DataContract]
		public class L3MP_GPfID_1222 
		{
			[DataMember]
			public L3MP_GPfID_1222_ShippingAddress ShippingAddress { get; set; }
			[DataMember]
			public L3MP_GPfID_1222_OfficeHours OfficeHours { get; set; }
			[DataMember]
			public L3MP_GPfID_1222_OtherOphthal_PracticeData OtherOphthal_PracticeData { get; set; }

			//Standard type parameters
			[DataMember]
			public L3MP_GPBIfID_1131 BaseInfo { get; set; } 
			[DataMember]
			public L3MP_GPCPfPID_1155 ContactPerson { get; set; } 

		}
		#endregion
		#region SClass L3MP_GPfID_1222_ShippingAddress for attribute ShippingAddress
		[DataContract]
		public class L3MP_GPfID_1222_ShippingAddress 
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
		#region SClass L3MP_GPfID_1222_OfficeHours for attribute OfficeHours
		[DataContract]
		public class L3MP_GPfID_1222_OfficeHours 
		{
			//Standard type parameters
			[DataMember]
			public String ConsultingHours_FormattedOfficeHours { get; set; } 
			[DataMember]
			public String WorkingHours_FormattedOfficeHours { get; set; } 

		}
		#endregion
		#region SClass L3MP_GPfID_1222_OtherOphthal_PracticeData for attribute OtherOphthal_PracticeData
		[DataContract]
		public class L3MP_GPfID_1222_OtherOphthal_PracticeData 
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
FR_L3MP_GPfID_1222 cls_Get_Practice_For_ID(,P_L3MP_GPfID_1222 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = VerifySessionToken(sessionToken);
		FR_L3MP_GPfID_1222 invocationResult = cls_Get_Practice_For_ID.Invoke(connectionString,P_L3MP_GPfID_1222 Parameter,securityTicket);
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
var parameter = new CL3_MedicalPractices.Complex.Retrieval.P_L3MP_GPfID_1222();
parameter.HEC_MedicalPractiseID = ...;

*/
