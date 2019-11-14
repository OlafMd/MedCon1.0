/* 
 * Generated on 7/24/2013 10:44:34 AM
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
using CL1_CMN_BPT;
using CL1_HEC;
using CL1_CMN_PER;
using CL1_CMN_COM;
using CL1_CMN;

namespace CL5_Lucentis_Practice.Atomic.Manipulation
{
	/// <summary>
    /// 
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
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5PR_SP__1122 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            ORM_HEC_MedicalPractis item = new ORM_HEC_MedicalPractis();

            if (Parameter.PracticeID != Guid.Empty)
            {
                var result = item.Load(Connection, Transaction, Parameter.PracticeID);
                if (result.Status != FR_Status.Success || item.HEC_MedicalPractiseID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }

                #region Delete

                if (Parameter.isDeleted == true)
                {
                    var query_BP_ContactPerson_del = new ORM_CMN_BPT_BusinessParticipant.Query();
                    query_BP_ContactPerson_del.CMN_BPT_BusinessParticipantID = item.ContactPerson_RefID;
                    query_BP_ContactPerson_del.Tenant_RefID = securityTicket.TenantID;

                    var found_BP_ContactPerson_del = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, query_BP_ContactPerson_del).First();
                    found_BP_ContactPerson_del.IsDeleted = true;

                    var query_PersonInfo_del = new ORM_CMN_PER_PersonInfo.Query();
                    query_PersonInfo_del.CMN_PER_PersonInfoID = found_BP_ContactPerson_del.IfNaturalPerson_CMN_PER_PersonInfo_RefID;

                    var found_PersonInfo_del = ORM_CMN_PER_PersonInfo.Query.Search(Connection, Transaction, query_PersonInfo_del).First();
                    found_PersonInfo_del.IsDeleted = true;
                    found_PersonInfo_del.Save(Connection, Transaction);


                    var query_CommunicationContact_del = new ORM_CMN_PER_CommunicationContact.Query();
                    query_CommunicationContact_del.PersonInfo_RefID = found_PersonInfo_del.CMN_PER_PersonInfoID;


                    var found_CommunicationContact_del = ORM_CMN_PER_CommunicationContact.Query.Search(Connection, Transaction, query_CommunicationContact_del).First();
                    found_CommunicationContact_del.IsDeleted = true;

                    found_CommunicationContact_del.Save(Connection, Transaction);


                    var query_CompanyInfo_del = new ORM_CMN_COM_CompanyInfo.Query();
                    query_CompanyInfo_del.CMN_COM_CompanyInfoID = item.Ext_CompanyInfo_RefID;

                    var found_CompanyInfo_del = ORM_CMN_COM_CompanyInfo.Query.Search(Connection, Transaction, query_CompanyInfo_del).First();
                    found_CompanyInfo_del.IsDeleted = true;

                    found_CompanyInfo_del.Save(Connection, Transaction);

                    var query_BP_Company_del = new ORM_CMN_BPT_BusinessParticipant.Query();
                    query_BP_Company_del.IfCompany_CMN_COM_CompanyInfo_RefID = found_CompanyInfo_del.CMN_COM_CompanyInfoID;

                    var found_BP_Company_del = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, query_BP_Company_del).First();
                    found_BP_Company_del.IsDeleted = true;
                    found_BP_Company_del.Save(Connection, Transaction);

                    var query_UniversalContactDetails_del = new ORM_CMN_UniversalContactDetail.Query();
                    query_UniversalContactDetails_del.CMN_UniversalContactDetailID = found_CompanyInfo_del.Contact_UCD_RefID;

                    var found_UniversalCompanyDetails_del = ORM_CMN_UniversalContactDetail.Query.Search(Connection, Transaction, query_UniversalContactDetails_del).First();

                    found_UniversalCompanyDetails_del.IsDeleted = true;
                    found_UniversalCompanyDetails_del.Save(Connection, Transaction);

                    item.IsDeleted = true;
                    return new FR_Guid(item.Save(Connection, Transaction), item.HEC_MedicalPractiseID);
                }

                #endregion
                #region Edit

                var query1 = new ORM_CMN_BPT_BusinessParticipant.Query();
                query1.CMN_BPT_BusinessParticipantID = item.ContactPerson_RefID;
                query1.Tenant_RefID = securityTicket.TenantID;
                query1.IsCompany = false;
                query1.IsNaturalPerson = true;
                query1.IsTenant = false;

                var bussinessParticipant = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, query1).First();


                var query2 = new ORM_CMN_PER_PersonInfo.Query();
                query2.CMN_PER_PersonInfoID = bussinessParticipant.IfNaturalPerson_CMN_PER_PersonInfo_RefID;

                var personInfo = ORM_CMN_PER_PersonInfo.Query.Search(Connection, Transaction, query2).First();

                personInfo.FirstName = Parameter.ContactPersonFirstName;
                personInfo.LastName = Parameter.ContactPersonLastName;
                personInfo.PrimaryEmail = Parameter.ContactPersonEmail;
                personInfo.Save(Connection, Transaction);


                var query3 =  new ORM_CMN_PER_CommunicationContact.Query();
                query3.PersonInfo_RefID = personInfo.CMN_PER_PersonInfoID;


                var communicationContacts = ORM_CMN_PER_CommunicationContact.Query.Search(Connection, Transaction, query3).First();
                communicationContacts.Contact_Type = Parameter.ContactTypePhone;
                communicationContacts.Content = Parameter.ContactPersonPhoneNumber;

                communicationContacts.Save(Connection, Transaction);


                var query4 = new ORM_CMN_COM_CompanyInfo.Query();
                query4.CMN_COM_CompanyInfoID = item.Ext_CompanyInfo_RefID;

                var companyInfo =  ORM_CMN_COM_CompanyInfo.Query.Search(Connection, Transaction, query4).First();
                companyInfo.CompanyInfo_EstablishmentNumber = Parameter.BSNR;

                companyInfo.Save(Connection, Transaction);

                var query5 = new ORM_CMN_BPT_BusinessParticipant.Query();
                query5.IfCompany_CMN_COM_CompanyInfo_RefID = companyInfo.CMN_COM_CompanyInfoID;

                var extCompany = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, query5).First();
                extCompany.DisplayName = Parameter.PracticeName;
                extCompany.Save(Connection, Transaction);

                var query6 = new ORM_CMN_UniversalContactDetail.Query();
                query6.CMN_UniversalContactDetailID = companyInfo.Contact_UCD_RefID;

                var companyDetails =  ORM_CMN_UniversalContactDetail.Query.Search(Connection, Transaction, query6).First();

                companyDetails.ZIP = Parameter.ZIP;
                companyDetails.Town = Parameter.Town;
                companyDetails.Street_Name = Parameter.PracticeStreet;
                companyDetails.Street_Number = Parameter.PracticeNumber;
                companyDetails.Contact_Email = Parameter.PracitceEmail;
                companyDetails.Street_Name_Line2 = Parameter.PracticeStreet2;

                companyDetails.Save(Connection, Transaction);
                #endregion
            }
            else
            {
                #region Save
                
                item.HEC_MedicalPractiseID = Guid.NewGuid();

                item.Creation_Timestamp = DateTime.Now;
                item.Tenant_RefID = securityTicket.TenantID;


                //business Participants
                ORM_CMN_BPT_BusinessParticipant contactPerson = new ORM_CMN_BPT_BusinessParticipant();
                Guid businessParticipantsID = Guid.NewGuid();

                contactPerson.CMN_BPT_BusinessParticipantID = businessParticipantsID;
                contactPerson.IsCompany = false;
                contactPerson.IsNaturalPerson = true;
                contactPerson.IsTenant = false;
                contactPerson.Creation_Timestamp = DateTime.Now;
                contactPerson.Tenant_RefID = securityTicket.TenantID;

                item.ContactPerson_RefID = businessParticipantsID;

                //person info
                ORM_CMN_PER_PersonInfo personInfo = new ORM_CMN_PER_PersonInfo();
                Guid personInfoID = Guid.NewGuid();

                contactPerson.IfNaturalPerson_CMN_PER_PersonInfo_RefID = personInfoID;
                contactPerson.Save(Connection, Transaction);

                personInfo.CMN_PER_PersonInfoID = personInfoID;
                personInfo.FirstName = Parameter.ContactPersonFirstName;
                personInfo.LastName = Parameter.ContactPersonLastName;
                personInfo.PrimaryEmail = Parameter.ContactPersonEmail;
                personInfo.Creation_Timestamp = DateTime.Now;
                personInfo.Tenant_RefID = securityTicket.TenantID;

                personInfo.Save(Connection, Transaction);

                //Communication Contact
                ORM_CMN_PER_CommunicationContact communicationContacts = new ORM_CMN_PER_CommunicationContact();

                communicationContacts.CMN_PER_CommunicationContactID = Guid.NewGuid();
                communicationContacts.PersonInfo_RefID = personInfoID;
                communicationContacts.Contact_Type = Parameter.ContactTypePhone;
                communicationContacts.Content = Parameter.ContactPersonPhoneNumber;
                communicationContacts.Creation_Timestamp = DateTime.Now;
                communicationContacts.Tenant_RefID = securityTicket.TenantID;

                communicationContacts.Save(Connection, Transaction);


                ORM_CMN_COM_CompanyInfo companyInfo = new ORM_CMN_COM_CompanyInfo();
                Guid companyInfoID = Guid.NewGuid();
                companyInfo.CMN_COM_CompanyInfoID = companyInfoID;
                companyInfo.Creation_Timestamp = DateTime.Now;
                companyInfo.Tenant_RefID = securityTicket.TenantID;
                companyInfo.CompanyInfo_EstablishmentNumber = Parameter.BSNR;

                item.Ext_CompanyInfo_RefID = companyInfoID;


                ORM_CMN_BPT_BusinessParticipant extCompany = new ORM_CMN_BPT_BusinessParticipant();
                extCompany.CMN_BPT_BusinessParticipantID = Guid.NewGuid();
                extCompany.Creation_Timestamp = DateTime.Now;
                extCompany.Tenant_RefID = securityTicket.TenantID;
                extCompany.DisplayName = Parameter.PracticeName;
                extCompany.IsCompany = true;
                extCompany.IsNaturalPerson = false;
                extCompany.IsTenant = false;
                extCompany.IsDeleted = false;
                extCompany.IfCompany_CMN_COM_CompanyInfo_RefID = companyInfoID;

                extCompany.Save(Connection, Transaction);

                ORM_CMN_UniversalContactDetail companyDetails = new ORM_CMN_UniversalContactDetail();
                Guid companyDetailsID = Guid.NewGuid();

                companyInfo.Contact_UCD_RefID = companyDetailsID;
                companyInfo.Save(Connection, Transaction);

                companyDetails.CMN_UniversalContactDetailID = companyDetailsID;
                companyDetails.Tenant_RefID = securityTicket.TenantID;
                companyDetails.Creation_Timestamp = DateTime.Now;
                companyDetails.IsCompany = true;
                companyDetails.ZIP = Parameter.ZIP;
                companyDetails.Town = Parameter.Town;
                companyDetails.Street_Name = Parameter.PracticeStreet;
                companyDetails.Street_Number = Parameter.PracticeNumber;
                companyDetails.Contact_Email = Parameter.PracitceEmail;
                companyDetails.Street_Name_Line2 = Parameter.PracticeStreet2;
                companyDetails.IsDeleted = false;
                companyDetails.Save(Connection, Transaction);

                item.Save(Connection, Transaction);

                
                #endregion
            }

            returnValue.Result = item.HEC_MedicalPractiseID;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5PR_SP__1122 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5PR_SP__1122 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5PR_SP__1122 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5PR_SP__1122 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw ex;
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5PR_SP__1122 for attribute P_L5PR_SP__1122
		[DataContract]
		public class P_L5PR_SP__1122 
		{
			//Standard type parameters
			[DataMember]
			public Guid PracticeID { get; set; } 
			[DataMember]
			public String PracticeName { get; set; } 
			[DataMember]
			public String PracticeStreet { get; set; } 
			[DataMember]
			public String PracticeNumber { get; set; } 
			[DataMember]
			public String PracitceEmail { get; set; } 
			[DataMember]
			public String PracticeStreet2 { get; set; } 
			[DataMember]
			public String BSNR { get; set; } 
			[DataMember]
			public String ZIP { get; set; } 
			[DataMember]
			public String Town { get; set; } 
			[DataMember]
			public String ContactPersonFirstName { get; set; } 
			[DataMember]
			public String ContactPersonLastName { get; set; } 
			[DataMember]
			public String ContactPersonEmail { get; set; } 
			[DataMember]
			public String ContactPersonPhoneNumber { get; set; } 
			[DataMember]
			public Boolean isDeleted { get; set; } 
			[DataMember]
			public Guid ContactTypePhone { get; set; } 

		}
		#endregion

	#endregion
}
