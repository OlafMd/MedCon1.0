/* 
 * Generated on 7/23/2013 4:26:39 PM
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
using CL1_CMN_BPT;
using CL1_CMN_PER;
using CL1_CMN_COM;
using CL1_CMN;

namespace CL5_Lucentis_Pharmacies.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Pharmacy.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Pharmacy
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5PH_SP_1226 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            ORM_HEC_Pharmacy item = new ORM_HEC_Pharmacy();


            if (Parameter.PharmacyID != Guid.Empty)
            {
                var result = item.Load(Connection, Transaction, Parameter.PharmacyID);
                if (result.Status != FR_Status.Success)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }

                #region Delete

                if (Parameter.IsDeleted)
                {
                    //Contact person data finding and deleting
                    var query_BusinessParticipant_ContactPerson_del = new ORM_CMN_BPT_BusinessParticipant.Query();
                    query_BusinessParticipant_ContactPerson_del.CMN_BPT_BusinessParticipantID = item.ContactPerson_BusinessParticipant_RefID;
                    query_BusinessParticipant_ContactPerson_del.Tenant_RefID = item.Tenant_RefID;

                    ORM_CMN_BPT_BusinessParticipant found_BusinessParticipant_ContactPerson_del = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, query_BusinessParticipant_ContactPerson_del).First();
                    found_BusinessParticipant_ContactPerson_del.IsDeleted = true;

                    var query_PersonInfo_del = new ORM_CMN_PER_PersonInfo.Query();
                    query_PersonInfo_del.CMN_PER_PersonInfoID = found_BusinessParticipant_ContactPerson_del.IfNaturalPerson_CMN_PER_PersonInfo_RefID;

                    ORM_CMN_PER_PersonInfo found_PersonInfo_del = ORM_CMN_PER_PersonInfo.Query.Search(Connection, Transaction, query_PersonInfo_del).First();
                    found_PersonInfo_del.IsDeleted = true;

                    var query_CommunicationContact_del = new ORM_CMN_PER_CommunicationContact.Query();
                    query_CommunicationContact_del.PersonInfo_RefID = found_PersonInfo_del.CMN_PER_PersonInfoID;

                    ORM_CMN_PER_CommunicationContact found_CommunicationContact_del = ORM_CMN_PER_CommunicationContact.Query.Search(Connection, Transaction, query_CommunicationContact_del).First();
                    found_CommunicationContact_del.IsDeleted = true;

                    found_BusinessParticipant_ContactPerson_del.Save(Connection, Transaction);
                    found_CommunicationContact_del.Save(Connection, Transaction);
                    found_PersonInfo_del.Save(Connection, Transaction);

                   
                    //Company (pharmacy) finding and deleting

                    var query_CompanyInfo_del = new ORM_CMN_COM_CompanyInfo.Query();
                    query_CompanyInfo_del.CMN_COM_CompanyInfoID = item.Ext_CompanyInfo_RefID;

                    ORM_CMN_COM_CompanyInfo found_CompanyInfo_del = ORM_CMN_COM_CompanyInfo.Query.Search(Connection, Transaction, query_CompanyInfo_del).First();
                    found_CompanyInfo_del.IsDeleted = true;

                    var query_CompanyContactDetails_del = new ORM_CMN_UniversalContactDetail.Query();
                    query_CompanyContactDetails_del.CMN_UniversalContactDetailID = found_CompanyInfo_del.Contact_UCD_RefID;

                    ORM_CMN_UniversalContactDetail found_CompanyContactDetails_del = ORM_CMN_UniversalContactDetail.Query.Search(Connection, Transaction, query_CompanyContactDetails_del).First();
                    found_CompanyContactDetails_del.IsDeleted = true;

                    var query_BusinessParticipant_Company_del = new ORM_CMN_BPT_BusinessParticipant.Query();
                    query_BusinessParticipant_Company_del.IfCompany_CMN_COM_CompanyInfo_RefID = found_CompanyInfo_del.CMN_COM_CompanyInfoID;

                    ORM_CMN_BPT_BusinessParticipant found_BusinessParticipant_Company_del = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, query_BusinessParticipant_Company_del).First();
                    found_BusinessParticipant_Company_del.IsDeleted = true;

                    found_CompanyInfo_del.Save(Connection, Transaction);
                    found_CompanyContactDetails_del.Save(Connection, Transaction);
                    found_BusinessParticipant_Company_del.Save(Connection, Transaction);

                    item.IsDeleted = true;
                    return new FR_Guid(item.Save(Connection, Transaction), item.HEC_PharmacyID);
                }

                #endregion

                #region Edit

                //Contact person data finding and edit

                var query_BusinessParticipant_ContactPerson = new ORM_CMN_BPT_BusinessParticipant.Query();
                query_BusinessParticipant_ContactPerson.CMN_BPT_BusinessParticipantID = item.ContactPerson_BusinessParticipant_RefID;
                query_BusinessParticipant_ContactPerson.Tenant_RefID = item.Tenant_RefID;

                ORM_CMN_BPT_BusinessParticipant found_BusinessParticipant_ContactPerson = new ORM_CMN_BPT_BusinessParticipant() ;
                if (item.ContactPerson_BusinessParticipant_RefID != null && item.ContactPerson_BusinessParticipant_RefID != Guid.Empty)
                {
                    found_BusinessParticipant_ContactPerson = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, query_BusinessParticipant_ContactPerson).First();
                }
                else
                {
                    found_BusinessParticipant_ContactPerson = null;
                }
                 if (found_BusinessParticipant_ContactPerson != null)
                {

                    var query_PersonInfo = new ORM_CMN_PER_PersonInfo.Query();
                    query_PersonInfo.CMN_PER_PersonInfoID = found_BusinessParticipant_ContactPerson.IfNaturalPerson_CMN_PER_PersonInfo_RefID;

                    ORM_CMN_PER_PersonInfo found_PersonInfo = ORM_CMN_PER_PersonInfo.Query.Search(Connection, Transaction, query_PersonInfo).First();
                    found_PersonInfo.FirstName = Parameter.ContactFirstName;
                    found_PersonInfo.LastName = Parameter.ContactLastName;
                    found_PersonInfo.PrimaryEmail = Parameter.ContactEmail;

                    var query_CommunicationContact = new ORM_CMN_PER_CommunicationContact.Query();
                    query_CommunicationContact.PersonInfo_RefID = found_PersonInfo.CMN_PER_PersonInfoID;

                    ORM_CMN_PER_CommunicationContact found_CommunicationContact = ORM_CMN_PER_CommunicationContact.Query.Search(Connection, Transaction, query_CommunicationContact).First();
                    found_CommunicationContact.Content = Parameter.ContactPhoneNumber;

                    found_CommunicationContact.Save(Connection, Transaction);
                    found_PersonInfo.Save(Connection, Transaction);

                }
                else
                {
                    ORM_CMN_BPT_BusinessParticipant contactPerson = new ORM_CMN_BPT_BusinessParticipant();
                    Guid businessParticipantID = Guid.NewGuid();

                    contactPerson.CMN_BPT_BusinessParticipantID = businessParticipantID;
                    contactPerson.IsCompany = false;
                    contactPerson.IsNaturalPerson = true;
                    contactPerson.IsTenant = false;
                    contactPerson.Creation_Timestamp = DateTime.Now;
                    contactPerson.Tenant_RefID = securityTicket.TenantID;

                    item.ContactPerson_BusinessParticipant_RefID = businessParticipantID;

                    //person info
                    ORM_CMN_PER_PersonInfo personInfo = new ORM_CMN_PER_PersonInfo();
                    Guid personInfoID = Guid.NewGuid();

                    contactPerson.IfNaturalPerson_CMN_PER_PersonInfo_RefID = personInfoID;
                    contactPerson.Save(Connection, Transaction);

                    personInfo.CMN_PER_PersonInfoID = personInfoID;
                    personInfo.FirstName = Parameter.ContactFirstName;
                    personInfo.LastName = Parameter.ContactLastName;
                    personInfo.PrimaryEmail = Parameter.ContactEmail;
                    personInfo.Creation_Timestamp = DateTime.Now;
                    personInfo.Tenant_RefID = securityTicket.TenantID;

                    personInfo.Save(Connection, Transaction);

                    //Communication Contact
                    ORM_CMN_PER_CommunicationContact communicationContacts = new ORM_CMN_PER_CommunicationContact();

                    communicationContacts.CMN_PER_CommunicationContactID = Guid.NewGuid();
                    communicationContacts.PersonInfo_RefID = personInfoID;
                    communicationContacts.Contact_Type = Parameter.ContactTypePhone;
                    communicationContacts.Content = Parameter.ContactPhoneNumber;
                    communicationContacts.Creation_Timestamp = DateTime.Now;
                    communicationContacts.Tenant_RefID = securityTicket.TenantID;

                    communicationContacts.Save(Connection, Transaction);


                    item.ContactPerson_BusinessParticipant_RefID = businessParticipantID;
                    item.Save(Connection,Transaction);
                }

                //Company (pharmacy) finding and edit

                var query_CompanyInfo = new ORM_CMN_COM_CompanyInfo.Query();
                query_CompanyInfo.CMN_COM_CompanyInfoID = item.Ext_CompanyInfo_RefID;

                ORM_CMN_COM_CompanyInfo found_CompanyInfo = ORM_CMN_COM_CompanyInfo.Query.Search(Connection, Transaction, query_CompanyInfo).First();
                
                var query_CompanyContactDetails = new ORM_CMN_UniversalContactDetail.Query();
                query_CompanyContactDetails.CMN_UniversalContactDetailID = found_CompanyInfo.Contact_UCD_RefID;

                ORM_CMN_UniversalContactDetail found_CompanyContactDetails = ORM_CMN_UniversalContactDetail.Query.Search(Connection, Transaction, query_CompanyContactDetails).FirstOrDefault();
                if (found_CompanyContactDetails != null)
                {

                    found_CompanyContactDetails.CompanyName_Line1 = Parameter.PharmacyName;
                    found_CompanyContactDetails.Contact_Email = Parameter.MainEmail;
                    found_CompanyContactDetails.Street_Name = Parameter.Street;
                    found_CompanyContactDetails.Street_Number = Parameter.Number;
                    found_CompanyContactDetails.Street_Name_Line2 = Parameter.Street2;
                    found_CompanyContactDetails.Town = Parameter.Town;
                    found_CompanyContactDetails.ZIP = Parameter.ZIP;
                    found_CompanyContactDetails.Save(Connection, Transaction);
                }
                else
                {
                    ORM_CMN_UniversalContactDetail universalContactDetails = new ORM_CMN_UniversalContactDetail();
                    universalContactDetails.CMN_UniversalContactDetailID = Guid.NewGuid();
                    universalContactDetails.IsCompany = true;
                    universalContactDetails.CompanyName_Line1 = Parameter.PharmacyName;
                    universalContactDetails.Street_Name = Parameter.Street;
                    universalContactDetails.Street_Name_Line2 = Parameter.Street2;
                    universalContactDetails.Street_Number = Parameter.Number;
                    universalContactDetails.Contact_Email = Parameter.MainEmail;
                    universalContactDetails.ZIP = Parameter.ZIP;
                    universalContactDetails.Town = Parameter.Town;
                    universalContactDetails.Tenant_RefID = securityTicket.TenantID;


                    universalContactDetails.Save(Connection, Transaction);

                    found_CompanyInfo.Contact_UCD_RefID = universalContactDetails.CMN_UniversalContactDetailID;
                    found_CompanyInfo.Save(Connection, Transaction);
                }

                var query_BusinessParticipant_Company = new ORM_CMN_BPT_BusinessParticipant.Query();
                query_BusinessParticipant_Company.IfCompany_CMN_COM_CompanyInfo_RefID = found_CompanyInfo.CMN_COM_CompanyInfoID;

                ORM_CMN_BPT_BusinessParticipant found_BusinessParticipant_Company = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, query_BusinessParticipant_Company).First();
                found_BusinessParticipant_Company.DisplayName = Parameter.PharmacyName;

                
                found_BusinessParticipant_Company.Save(Connection, Transaction);

                #endregion
            }
            else
            {
                #region Save
               
                item.HEC_PharmacyID = Guid.NewGuid();

                item.Creation_Timestamp = DateTime.Now;
                item.Tenant_RefID = securityTicket.TenantID;

                //business Participants
                ORM_CMN_BPT_BusinessParticipant contactPerson = new ORM_CMN_BPT_BusinessParticipant();
                Guid businessParticipantID = Guid.NewGuid();

                contactPerson.CMN_BPT_BusinessParticipantID = businessParticipantID;
                contactPerson.IsCompany = false;
                contactPerson.IsNaturalPerson = true;
                contactPerson.IsTenant = false;
                contactPerson.Creation_Timestamp = DateTime.Now;
                contactPerson.Tenant_RefID = securityTicket.TenantID;

                item.ContactPerson_BusinessParticipant_RefID = businessParticipantID;

                //person info
                ORM_CMN_PER_PersonInfo personInfo = new ORM_CMN_PER_PersonInfo();
                Guid personInfoID = Guid.NewGuid();

                contactPerson.IfNaturalPerson_CMN_PER_PersonInfo_RefID = personInfoID;
                contactPerson.Save(Connection, Transaction);

                personInfo.CMN_PER_PersonInfoID = personInfoID;
                personInfo.FirstName = Parameter.ContactFirstName;
                personInfo.LastName = Parameter.ContactLastName;
                personInfo.PrimaryEmail = Parameter.ContactEmail;
                personInfo.Creation_Timestamp = DateTime.Now;
                personInfo.Tenant_RefID = securityTicket.TenantID;

                personInfo.Save(Connection, Transaction);

                //Communication Contact
                ORM_CMN_PER_CommunicationContact communicationContacts = new ORM_CMN_PER_CommunicationContact();

                communicationContacts.CMN_PER_CommunicationContactID = Guid.NewGuid();
                communicationContacts.PersonInfo_RefID = personInfoID;
                communicationContacts.Contact_Type = Parameter.ContactTypePhone;
                communicationContacts.Content = Parameter.ContactPhoneNumber;
                communicationContacts.Creation_Timestamp = DateTime.Now;
                communicationContacts.Tenant_RefID = securityTicket.TenantID;

                communicationContacts.Save(Connection, Transaction);

                //ORM_CMN_COM_CompanyInfo companyInfo = new ORM_CMN_COM_CompanyInfo();
                //Guid companyInfoID = Guid.NewGuid();       

                ORM_CMN_COM_CompanyInfo extCompanyInfo = new ORM_CMN_COM_CompanyInfo();
                Guid extCompanyInfoID = Guid.NewGuid();
                extCompanyInfo.CMN_COM_CompanyInfoID = extCompanyInfoID;
                Guid contactUCDID = Guid.NewGuid();
                extCompanyInfo.Contact_UCD_RefID = contactUCDID;
                extCompanyInfo.Creation_Timestamp = DateTime.Now;
                extCompanyInfo.Tenant_RefID = securityTicket.TenantID;

                item.Ext_CompanyInfo_RefID = extCompanyInfoID;

                ORM_CMN_UniversalContactDetail universalContactDetails = new ORM_CMN_UniversalContactDetail();
                universalContactDetails.CMN_UniversalContactDetailID = contactUCDID;
                universalContactDetails.IsCompany = true;
                universalContactDetails.CompanyName_Line1 = Parameter.PharmacyName;
                universalContactDetails.Street_Name = Parameter.Street;
                universalContactDetails.Street_Name_Line2 = Parameter.Street2;
                universalContactDetails.Street_Number = Parameter.Number;
                universalContactDetails.Contact_Email = Parameter.MainEmail;
                universalContactDetails.ZIP = Parameter.ZIP;
                universalContactDetails.Town = Parameter.Town;
                universalContactDetails.Tenant_RefID = securityTicket.TenantID;

                ORM_CMN_BPT_BusinessParticipant extCompany = new ORM_CMN_BPT_BusinessParticipant();
                extCompany.CMN_BPT_BusinessParticipantID = Guid.NewGuid();
                extCompany.Creation_Timestamp = DateTime.Now;
                extCompany.Tenant_RefID = securityTicket.TenantID;
                extCompany.DisplayName = Parameter.PharmacyName;
                extCompany.IsCompany = true;
                extCompany.IsNaturalPerson = false;
                extCompany.IsTenant = false;
                extCompany.IsDeleted = false;
                extCompany.IfCompany_CMN_COM_CompanyInfo_RefID = extCompanyInfoID;

                extCompany.Save(Connection, Transaction);
                extCompanyInfo.Save(Connection, Transaction);
                universalContactDetails.Save(Connection, Transaction);
                item.Save(Connection, Transaction);

                returnValue.Result = item.HEC_PharmacyID;
                #endregion
            }     
          
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5PH_SP_1226 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5PH_SP_1226 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5PH_SP_1226 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5PH_SP_1226 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Pharmacy",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5PH_SP_1226 for attribute P_L5PH_SP_1226
		[DataContract]
		public class P_L5PH_SP_1226 
		{
			//Standard type parameters
			[DataMember]
			public Guid PharmacyID { get; set; } 
			[DataMember]
			public String PharmacyName { get; set; } 
			[DataMember]
			public String Street { get; set; } 
			[DataMember]
			public String Number { get; set; } 
			[DataMember]
			public String MainEmail { get; set; } 
			[DataMember]
			public String Street2 { get; set; } 
			[DataMember]
			public String ZIP { get; set; } 
			[DataMember]
			public String Town { get; set; } 
			[DataMember]
			public String ContactFirstName { get; set; } 
			[DataMember]
			public String ContactLastName { get; set; } 
			[DataMember]
			public String ContactEmail { get; set; } 
			[DataMember]
			public String ContactPhoneNumber { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 
			[DataMember]
			public Guid ContactTypePhone { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Pharmacy(,P_L5PH_SP_1226 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Pharmacy.Invoke(connectionString,P_L5PH_SP_1226 Parameter,securityTicket);
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
var parameter = new CL5_Lucentis_Pharmacies.Complex.Manipulation.P_L5PH_SP_1226();
parameter.PharmacyID = ...;
parameter.PharmacyName = ...;
parameter.Street = ...;
parameter.Number = ...;
parameter.MainEmail = ...;
parameter.Street2 = ...;
parameter.ZIP = ...;
parameter.Town = ...;
parameter.ContactFirstName = ...;
parameter.ContactLastName = ...;
parameter.ContactEmail = ...;
parameter.ContactPhoneNumber = ...;
parameter.IsDeleted = ...;
parameter.ContactTypePhone = ...;

*/
