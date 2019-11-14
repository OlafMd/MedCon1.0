/* 
 * Generated on 8/31/2013 3:55:26 PM
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
using CL1_CMN_COM;
using CL1_CMN_BPT;
using CL3_MedicalPractices.Atomic.Manipulation;
using CL1_CMN_PER;

namespace CL5_Lucentis_Practice.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_MedicalPractice.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_MedicalPractice
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5PR_SMP__1122 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            if (Parameter.isDeleted == true)
            {
                P_L3MP_DPBID_1026 param = new P_L3MP_DPBID_1026();
                param.HEC_MedicalPractiseID = Parameter.PracticeID;
                
                cls_Delete_Practice_By_ID.Invoke(Connection, Transaction, param,securityTicket);
            }
            else
            {
                #region Save

                if (Parameter.PracticeID == Guid.Empty)
                {

                    /*********************************
                        Save ContactPerson
                    ********************************/
                    //business Participants
                    ORM_CMN_BPT_BusinessParticipant contactPerson = new ORM_CMN_BPT_BusinessParticipant();
                    Guid businessParticipantsID = Guid.NewGuid();

                    contactPerson.CMN_BPT_BusinessParticipantID = businessParticipantsID;
                    contactPerson.IsCompany = false;
                    contactPerson.IsNaturalPerson = true;
                    contactPerson.IsTenant = false;
                    contactPerson.Creation_Timestamp = DateTime.Now;
                    contactPerson.Tenant_RefID = securityTicket.TenantID;

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

                    /*********************************
                       Save Practice
                     ********************************/
                    P_L3MP_SPBI_1602 param = new P_L3MP_SPBI_1602();
                    param.Street_Number = Parameter.PracticeNumber;
                    param.Street_Name = Parameter.PracticeStreet;
                    param.Street_Name_Line2 = Parameter.PracticeStreet2;
                    param.PracticeName = Parameter.PracticeName;
                    param.isLucentis = true;
                    param.ifLucentis_BSNR = Parameter.BSNR;
                    param.PracticeEmail = Parameter.PracitceEmail;
                    param.Town = Parameter.Town;
                    param.ZIP = Parameter.ZIP;
                    param.HEC_MedicalPractiseID = Parameter.PracticeID;

                    Guid HEC_MedicalPractiseID = cls_Save_Practice_BaseInfo.Invoke(Connection, Transaction, param, securityTicket).Result;


                    /*********************************
                      Save Cooperating Practices
                    ********************************/
                    var queryMedicalPractice = new ORM_HEC_MedicalPractis.Query();
                    queryMedicalPractice.HEC_MedicalPractiseID = HEC_MedicalPractiseID;
                    queryMedicalPractice.IsDeleted = false;

                    var medicalPractice = ORM_HEC_MedicalPractis.Query.Search(Connection, Transaction, queryMedicalPractice).FirstOrDefault();

                    if (medicalPractice != null)
                    {
                        medicalPractice.ContactPerson_RefID = businessParticipantsID;
                        medicalPractice.Save(Connection, Transaction);

                        var queryCompanyInfo = new ORM_CMN_COM_CompanyInfo.Query();
                        queryCompanyInfo.CMN_COM_CompanyInfoID = medicalPractice.Ext_CompanyInfo_RefID;
                        queryCompanyInfo.IsDeleted = false;

                        var CompanyInfo = ORM_CMN_COM_CompanyInfo.Query.Search(Connection, Transaction, queryCompanyInfo).FirstOrDefault();

                        if (CompanyInfo != null)
                        {
                            var queryBussinessParticipients = new ORM_CMN_BPT_BusinessParticipant.Query();
                            queryBussinessParticipients.IfCompany_CMN_COM_CompanyInfo_RefID = CompanyInfo.CMN_COM_CompanyInfoID;
                            queryBussinessParticipients.IsDeleted = false;

                            var bussinessParticipants = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, queryBussinessParticipients).FirstOrDefault();


                            if (bussinessParticipants != null)
                            {

                                foreach (var cooperatingPractice in Parameter.CooperatingPractices)
                                {
                                    ORM_CMN_BPT_BusinessParticipant_AssociatedBusinessParticipant associatedBussinessParticipants = new ORM_CMN_BPT_BusinessParticipant_AssociatedBusinessParticipant();

                                    associatedBussinessParticipants.CMN_BPT_BusinessParticipant_AssociatedBusinessParticipantID = Guid.NewGuid();
                                    associatedBussinessParticipants.IsDeleted = cooperatingPractice.isDeleted;
                                    associatedBussinessParticipants.BusinessParticipant_RefID = bussinessParticipants.CMN_BPT_BusinessParticipantID;
                                    associatedBussinessParticipants.AssociatedBusinessParticipant_RefID = cooperatingPractice.PracticeID;
                                    associatedBussinessParticipants.Creation_Timestamp = DateTime.Now;
                                    associatedBussinessParticipants.Tenant_RefID = bussinessParticipants.Tenant_RefID;

                                    associatedBussinessParticipants.Save(Connection, Transaction);
                                }


                            }
                        }

                        returnValue.Result = medicalPractice.HEC_MedicalPractiseID;
                    }
                }
                #endregion
                else
                {

                    /*********************************
                       Edit Practice
                     ********************************/
                    P_L3MP_SPBI_1602 param = new P_L3MP_SPBI_1602();
                    param.Street_Number = Parameter.PracticeNumber;
                    param.Street_Name = Parameter.PracticeStreet;
                    param.Street_Name_Line2 = Parameter.PracticeStreet2;
                    param.PracticeName = Parameter.PracticeName;
                    param.isLucentis = true;
                    param.ifLucentis_BSNR = Parameter.BSNR;
                    param.PracticeEmail = Parameter.PracitceEmail;
                    param.Town = Parameter.Town;
                    param.ZIP = Parameter.ZIP;
                    param.HEC_MedicalPractiseID = Parameter.PracticeID;

                    Guid HEC_MedicalPractiseID = cls_Save_Practice_BaseInfo.Invoke(Connection, Transaction, param, securityTicket).Result;

                    var medicalPracticeQuery = new ORM_HEC_MedicalPractis.Query();
                    medicalPracticeQuery.IsDeleted = false;
                    medicalPracticeQuery.HEC_MedicalPractiseID = HEC_MedicalPractiseID;

                    var medicalPractice = ORM_HEC_MedicalPractis.Query.Search(Connection, Transaction, medicalPracticeQuery).FirstOrDefault();

                    if (medicalPractice != null)
                    {
                        /*********************************
                            Edit Contact Person
                        ********************************/

                        //contact person
                        var contactPerson = new ORM_CMN_BPT_BusinessParticipant();

                        var contactPersonQuery = new ORM_CMN_BPT_BusinessParticipant.Query();
                        contactPersonQuery.IsDeleted = false;

                        if (medicalPractice.ContactPerson_RefID != Guid.Empty)
                        {
                            contactPersonQuery.CMN_BPT_BusinessParticipantID = medicalPractice.ContactPerson_RefID;
                            contactPerson = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, contactPersonQuery).FirstOrDefault();
                        }
                        else
                        {
                            contactPerson = null;
                        }

                        Guid personInfoID = Guid.NewGuid();

                        if (contactPerson == null)
                        {
                            contactPerson = new ORM_CMN_BPT_BusinessParticipant();
                            contactPerson.CMN_BPT_BusinessParticipantID = Guid.NewGuid();
                            contactPerson.IsCompany = false;
                            contactPerson.IsNaturalPerson = true;
                            contactPerson.IsTenant = false;
                            contactPerson.Creation_Timestamp = DateTime.Now;
                            contactPerson.Tenant_RefID = securityTicket.TenantID;

                            contactPerson.IfNaturalPerson_CMN_PER_PersonInfo_RefID = personInfoID;
                            contactPerson.Save(Connection, Transaction);

                            medicalPractice.ContactPerson_RefID = contactPerson.CMN_BPT_BusinessParticipantID;
                            medicalPractice.Save(Connection, Transaction);
                        }

                        var personInfo = new ORM_CMN_PER_PersonInfo();

                            //person info
                            var personInfoQuery = new ORM_CMN_PER_PersonInfo.Query();
                            personInfoQuery.IsDeleted = false;
                            personInfoQuery.CMN_PER_PersonInfoID = contactPerson.IfNaturalPerson_CMN_PER_PersonInfo_RefID;

                            personInfo = ORM_CMN_PER_PersonInfo.Query.Search(Connection, Transaction, personInfoQuery).FirstOrDefault();
                        
                        if (personInfo == null)
                        {
                            personInfo = new ORM_CMN_PER_PersonInfo();
                            personInfo.CMN_PER_PersonInfoID = Guid.NewGuid();
                            personInfo.Creation_Timestamp = DateTime.Now;
                            personInfo.Tenant_RefID = securityTicket.TenantID;
                            personInfo.CMN_PER_PersonInfoID = personInfoID;

                            contactPerson.IfNaturalPerson_CMN_PER_PersonInfo_RefID = personInfo.CMN_PER_PersonInfoID;
                            contactPerson.Save(Connection, Transaction);
                        }

                            personInfo.FirstName = Parameter.ContactPersonFirstName;
                            personInfo.LastName = Parameter.ContactPersonLastName;
                            personInfo.PrimaryEmail = Parameter.ContactPersonEmail;

                            personInfo.Save(Connection, Transaction);

                            //Communication Contact

                            var communicationContacts = new ORM_CMN_PER_CommunicationContact();

                            var communicationContactsQuery = new ORM_CMN_PER_CommunicationContact.Query();
                            communicationContactsQuery.IsDeleted = false;
                            communicationContactsQuery.PersonInfo_RefID = personInfo.CMN_PER_PersonInfoID;

                            communicationContacts = ORM_CMN_PER_CommunicationContact.Query.Search(Connection, Transaction, communicationContactsQuery).FirstOrDefault();

                                if (communicationContacts == null)
                                {
                                    communicationContacts = new ORM_CMN_PER_CommunicationContact();
                                    communicationContacts.CMN_PER_CommunicationContactID = Guid.NewGuid();
                                    communicationContacts.PersonInfo_RefID = personInfo.CMN_PER_PersonInfoID;
                                    communicationContacts.Creation_Timestamp = DateTime.Now;
                                    communicationContacts.Tenant_RefID = securityTicket.TenantID;
                                }
                                communicationContacts.Contact_Type = Parameter.ContactTypePhone;
                                communicationContacts.Content = Parameter.ContactPersonPhoneNumber;

                                communicationContacts.Save(Connection, Transaction);


                                /*********************************
                                    Edit Cooperating Practices
                                ********************************/

                                var queryCompanyInfo = new ORM_CMN_COM_CompanyInfo.Query();
                                queryCompanyInfo.CMN_COM_CompanyInfoID = medicalPractice.Ext_CompanyInfo_RefID;
                                queryCompanyInfo.IsDeleted = false;

                                var CompanyInfo = ORM_CMN_COM_CompanyInfo.Query.Search(Connection, Transaction, queryCompanyInfo).FirstOrDefault();

                                if (CompanyInfo != null)
                                {
                                    var queryBussinessParticipients = new ORM_CMN_BPT_BusinessParticipant.Query();
                                    queryBussinessParticipients.IfCompany_CMN_COM_CompanyInfo_RefID = CompanyInfo.CMN_COM_CompanyInfoID;
                                    queryBussinessParticipients.IsDeleted = false;

                                    var bussinessParticipants = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, queryBussinessParticipients).FirstOrDefault();


                                    if (bussinessParticipants != null)
                                    {

                                        foreach (var cooperatingPractice in Parameter.CooperatingPractices)
                                        {

                                            var associatedBussinessParticipantsQuery = new ORM_CMN_BPT_BusinessParticipant_AssociatedBusinessParticipant.Query();
                                            associatedBussinessParticipantsQuery.AssociatedBusinessParticipant_RefID = cooperatingPractice.PracticeID;
                                            associatedBussinessParticipantsQuery.Tenant_RefID = bussinessParticipants.Tenant_RefID;
                                            associatedBussinessParticipantsQuery.BusinessParticipant_RefID = bussinessParticipants.CMN_BPT_BusinessParticipantID;

                                            var associtePractice = ORM_CMN_BPT_BusinessParticipant_AssociatedBusinessParticipant.Query.Search(Connection, Transaction, associatedBussinessParticipantsQuery).FirstOrDefault();

                                            if (associtePractice != null)
                                            {
                                                associtePractice.IsDeleted = cooperatingPractice.isDeleted;
                                                associtePractice.AssociatedBusinessParticipant_RefID = cooperatingPractice.PracticeID;
                                                associtePractice.Save(Connection, Transaction);
                                            }
                                            else
                                            {
                                                ORM_CMN_BPT_BusinessParticipant_AssociatedBusinessParticipant associatedBussinessParticipants = new ORM_CMN_BPT_BusinessParticipant_AssociatedBusinessParticipant();

                                                associatedBussinessParticipants.CMN_BPT_BusinessParticipant_AssociatedBusinessParticipantID = Guid.NewGuid();
                                                associatedBussinessParticipants.IsDeleted = cooperatingPractice.isDeleted;
                                                associatedBussinessParticipants.BusinessParticipant_RefID = bussinessParticipants.CMN_BPT_BusinessParticipantID;
                                                associatedBussinessParticipants.AssociatedBusinessParticipant_RefID = cooperatingPractice.PracticeID;
                                                associatedBussinessParticipants.Creation_Timestamp = DateTime.Now;
                                                associatedBussinessParticipants.Tenant_RefID = bussinessParticipants.Tenant_RefID;

                                                associatedBussinessParticipants.Save(Connection, Transaction);
                                            }
                                        }


                                    }
                                }

                                returnValue.Result = medicalPractice.HEC_MedicalPractiseID;

                        

                    }

                    


                }
                
            }

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5PR_SMP__1122 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5PR_SMP__1122 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5PR_SMP__1122 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5PR_SMP__1122 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_MedicalPractice",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5PR_SMP__1122 for attribute P_L5PR_SMP__1122
		[DataContract]
		public class P_L5PR_SMP__1122 
		{
			[DataMember]
			public P_L5PR_SMP__1122_Practices[] CooperatingPractices { get; set; }

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
		#region SClass P_L5PR_SMP__1122_Practices for attribute CooperatingPractices
		[DataContract]
		public class P_L5PR_SMP__1122_Practices 
		{
			//Standard type parameters
			[DataMember]
			public Guid PracticeID { get; set; } 
			[DataMember]
			public Boolean isDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_MedicalPractice(,P_L5PR_SMP__1122 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_MedicalPractice.Invoke(connectionString,P_L5PR_SMP__1122 Parameter,securityTicket);
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
var parameter = new CL5_Lucentis_Practice.Atomic.Manipulation.P_L5PR_SMP__1122();
parameter.CooperatingPractices = ...;

parameter.PracticeID = ...;
parameter.PracticeName = ...;
parameter.PracticeStreet = ...;
parameter.PracticeNumber = ...;
parameter.PracitceEmail = ...;
parameter.PracticeStreet2 = ...;
parameter.BSNR = ...;
parameter.ZIP = ...;
parameter.Town = ...;
parameter.ContactPersonFirstName = ...;
parameter.ContactPersonLastName = ...;
parameter.ContactPersonEmail = ...;
parameter.ContactPersonPhoneNumber = ...;
parameter.isDeleted = ...;
parameter.ContactTypePhone = ...;

*/
