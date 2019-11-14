/* 
 * Generated on 9/16/2013 11:47:07 AM
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

namespace CL3_Doctors.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Doctor_BaseInfo.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Doctor_BaseInfo
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L3MD_SDBI_1349 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            var doctor = new ORM_HEC_Doctor();

            if (Parameter.DoctorID != Guid.Empty)
            {
                var result = doctor.Load(Connection, Transaction, Parameter.DoctorID);
                if (result.Status != FR_Status.Success || doctor.HEC_DoctorID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
                #region Edit

                bool bopAccIsChenged = (doctor.Account_RefID == Parameter.Account_RefID) ? false : true;

                doctor.Account_RefID = Parameter.Account_RefID;
                if (Parameter.isLucentisSave)
                {
                    doctor.DoctorIDNumber = Parameter.ifLucentis_LANR;
                }
                doctor.Save(Connection, Transaction);

                //bussinessParticipant
                var query1 = new ORM_CMN_BPT_BusinessParticipant.Query();
                query1.CMN_BPT_BusinessParticipantID = doctor.BusinessParticipant_RefID;

                var bussinessParticipant = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, query1).First();

                if (!bopAccIsChenged)
                {
                    //personInfo
                    var query2 = new ORM_CMN_PER_PersonInfo.Query();
                    query2.CMN_PER_PersonInfoID = bussinessParticipant.IfNaturalPerson_CMN_PER_PersonInfo_RefID;

                    var personInfo = ORM_CMN_PER_PersonInfo.Query.Search(Connection, Transaction, query2).First();
                    personInfo.FirstName = Parameter.FirstName;
                    personInfo.LastName = Parameter.LastName;
                    personInfo.Title = Parameter.Title;
                    if (Parameter.isOphthalSave)
                    {
                        personInfo.Salutation_General = Parameter.ifOphthal_Salutation_General;
                        personInfo.Salutation_Letter = Parameter.ifOphthal_Salutation_Letter;
                    }
                    if (Parameter.isLucentisSave)
                        personInfo.PrimaryEmail = Parameter.ifLucentis_LoginEmail;
                    personInfo.Save(Connection, Transaction);

                    var query4 = new ORM_CMN_PER_CommunicationContact.Query();
                    query4.PersonInfo_RefID = personInfo.CMN_PER_PersonInfoID;

                    var communicationContactsList = ORM_CMN_PER_CommunicationContact.Query.Search(Connection, Transaction, query4).ToList();

                    if (Parameter.Contacts != null)
                    {
                        foreach (var parContact in Parameter.Contacts)
                        {

                            ORM_CMN_PER_CommunicationContact communicationContacts = communicationContactsList.FirstOrDefault(c => c.Contact_Type == parContact.CMN_PER_CommunicationContact_TypeID);
                            if (communicationContacts != null)
                            {
                                communicationContacts.Tenant_RefID = securityTicket.TenantID;
                                communicationContacts.Content = parContact.Content;
                                communicationContacts.Save(Connection, Transaction);
                            }
                            else
                            {
                                communicationContacts = new ORM_CMN_PER_CommunicationContact();
                                communicationContacts.CMN_PER_CommunicationContactID = Guid.NewGuid();
                                communicationContacts.PersonInfo_RefID = personInfo.CMN_PER_PersonInfoID;
                                communicationContacts.Contact_Type = parContact.CMN_PER_CommunicationContact_TypeID;
                                communicationContacts.Content = parContact.Content;
                                communicationContacts.Creation_Timestamp = DateTime.Now;
                                communicationContacts.Tenant_RefID = securityTicket.TenantID;
                                communicationContacts.Save(Connection, Transaction);
                            }
                        }
                    }
                }
                else
                {
                    var account2personInfoQuery = new ORM_CMN_PER_PersonInfo_2_Account.Query();
                    account2personInfoQuery.USR_Account_RefID = Parameter.Account_RefID;
                    account2personInfoQuery.Tenant_RefID = securityTicket.TenantID;
                    account2personInfoQuery.IsDeleted = false;
                    var account2personInfo = ORM_CMN_PER_PersonInfo_2_Account.Query.Search(Connection, Transaction, account2personInfoQuery).First();

                    var query2 = new ORM_CMN_PER_PersonInfo.Query();
                    query2.CMN_PER_PersonInfoID = account2personInfo.CMN_PER_PersonInfo_RefID;

                    var personInfo = ORM_CMN_PER_PersonInfo.Query.Search(Connection, Transaction, query2).First();
                    personInfo.FirstName = Parameter.FirstName;
                    personInfo.LastName = Parameter.LastName;
                    personInfo.Title = Parameter.Title;
                    personInfo.Save(Connection, Transaction);

                    var query4 = new ORM_CMN_PER_CommunicationContact.Query();
                    query4.PersonInfo_RefID = bussinessParticipant.IfNaturalPerson_CMN_PER_PersonInfo_RefID;
                    var communicationContactsList = ORM_CMN_PER_CommunicationContact.Query.Search(Connection, Transaction, query4).ToList();

                    if (communicationContactsList != null)
                    {
                        foreach (var c in communicationContactsList)
                        {
                            c.PersonInfo_RefID = personInfo.CMN_PER_PersonInfoID;
                            c.Save(Connection, Transaction);
                        }
                    }

                    if (Parameter.Contacts != null)
                    {
                        foreach (var parContact in Parameter.Contacts)
                        {

                            ORM_CMN_PER_CommunicationContact communicationContacts = communicationContactsList.FirstOrDefault(c => c.Contact_Type == parContact.CMN_PER_CommunicationContact_TypeID);
                            if (communicationContacts != null)
                            {
                                communicationContacts.Tenant_RefID = securityTicket.TenantID;
                                communicationContacts.Content = parContact.Content;
                                communicationContacts.Save(Connection, Transaction);
                            }
                            else
                            {
                                communicationContacts = new ORM_CMN_PER_CommunicationContact();
                                communicationContacts.CMN_PER_CommunicationContactID = Guid.NewGuid();
                                communicationContacts.PersonInfo_RefID = personInfo.CMN_PER_PersonInfoID;
                                communicationContacts.Contact_Type = parContact.CMN_PER_CommunicationContact_TypeID;
                                communicationContacts.Content = parContact.Content;
                                communicationContacts.Creation_Timestamp = DateTime.Now;
                                communicationContacts.Tenant_RefID = securityTicket.TenantID;
                                communicationContacts.Save(Connection, Transaction);
                            }
                        }
                    }        

                    bussinessParticipant.IfNaturalPerson_CMN_PER_PersonInfo_RefID = personInfo.CMN_PER_PersonInfoID;
                    bussinessParticipant.Save(Connection, Transaction);
                }
                if (Parameter.isLucentisSave)
                {
                    foreach (var practice in Parameter.Practices)
                    {
                        //if (practice.PracticeID != Guid.Empty) {

                            var medPract = new ORM_HEC_MedicalPractis.Query();
                            medPract.HEC_MedicalPractiseID = practice.PracticeID;

                            var medicalPractice = ORM_HEC_MedicalPractis.Query.Search(Connection, Transaction, medPract).First();

                            var queryCompanyInfo = new ORM_CMN_COM_CompanyInfo.Query();
                            queryCompanyInfo.CMN_COM_CompanyInfoID = medicalPractice.Ext_CompanyInfo_RefID;

                            var companyInfo = ORM_CMN_COM_CompanyInfo.Query.Search(Connection, Transaction, queryCompanyInfo).First();

                            var practiceQuery = new ORM_CMN_BPT_BusinessParticipant.Query();
                            practiceQuery.IfCompany_CMN_COM_CompanyInfo_RefID = companyInfo.CMN_COM_CompanyInfoID;

                            var practiceBPT = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, practiceQuery).First();

                            var query3 = new ORM_CMN_BPT_BusinessParticipant_AssociatedBusinessParticipant.Query();
                            query3.BusinessParticipant_RefID = bussinessParticipant.CMN_BPT_BusinessParticipantID;
                            query3.AssociatedBusinessParticipant_RefID = practiceBPT.CMN_BPT_BusinessParticipantID;
                            query3.IsDeleted = false;

                            var associatedbusinessparticipantsOriginal = ORM_CMN_BPT_BusinessParticipant_AssociatedBusinessParticipant.Query.Search(Connection, Transaction, query3).FirstOrDefault();
                            if (associatedbusinessparticipantsOriginal != null)
                            {
                                associatedbusinessparticipantsOriginal.IsDeleted = practice.isDeleted;
                                associatedbusinessparticipantsOriginal.Save(Connection, Transaction);
                            }
                            else
                            {
                                var associatedbusinessparticipants = new ORM_CMN_BPT_BusinessParticipant_AssociatedBusinessParticipant();
                                associatedbusinessparticipants.BusinessParticipant_RefID = bussinessParticipant.CMN_BPT_BusinessParticipantID;
                                associatedbusinessparticipants.AssociatedBusinessParticipant_RefID = practiceBPT.CMN_BPT_BusinessParticipantID;
                                associatedbusinessparticipants.AssociatedParticipant_FunctionName = practice.AssociatedParticipant_FunctionName;
                                associatedbusinessparticipants.Creation_Timestamp = DateTime.Now;
                                associatedbusinessparticipants.Tenant_RefID = securityTicket.TenantID;
                                associatedbusinessparticipants.Save(Connection, Transaction);
                       

                       // }
                        }
                    }
                }
                if (Parameter.isOphthalSave && Parameter.Practices.Length == 1)
                {
                    var query3 = new ORM_CMN_BPT_BusinessParticipant_AssociatedBusinessParticipant.Query();
                    query3.BusinessParticipant_RefID = bussinessParticipant.CMN_BPT_BusinessParticipantID;
                    query3.IsDeleted = false;
                    var associatedbusinessparticipantsRes = ORM_CMN_BPT_BusinessParticipant_AssociatedBusinessParticipant.Query.Search(Connection, Transaction, query3);
                    ORM_CMN_BPT_BusinessParticipant_AssociatedBusinessParticipant firstPractice;

                    var medPract = new ORM_HEC_MedicalPractis.Query();
                    medPract.HEC_MedicalPractiseID = Parameter.Practices[0].PracticeID;
                    var medicalPractice = ORM_HEC_MedicalPractis.Query.Search(Connection, Transaction, medPract).First();
                    var queryCompanyInfo = new ORM_CMN_COM_CompanyInfo.Query();
                    queryCompanyInfo.CMN_COM_CompanyInfoID = medicalPractice.Ext_CompanyInfo_RefID;
                    var companyInfo = ORM_CMN_COM_CompanyInfo.Query.Search(Connection, Transaction, queryCompanyInfo).First();
                    var practiceQuery = new ORM_CMN_BPT_BusinessParticipant.Query();
                    practiceQuery.IfCompany_CMN_COM_CompanyInfo_RefID = companyInfo.CMN_COM_CompanyInfoID;
                    var practiceBPT = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, practiceQuery).First();

                    if (associatedbusinessparticipantsRes.Count > 0)
                    {
                        associatedbusinessparticipantsRes = associatedbusinessparticipantsRes.OrderBy(a => a.Creation_Timestamp).ToList();
                        firstPractice = associatedbusinessparticipantsRes.First();
                        foreach (var item in associatedbusinessparticipantsRes)
                        {
                            if (item != firstPractice && item.CMN_BPT_BusinessParticipant_AssociatedBusinessParticipantID == practiceBPT.CMN_BPT_BusinessParticipantID)
                            {
                                item.IsDeleted = true;
                                item.Save(Connection, Transaction);
                            }
                        }
                    }
                    else
                    {
                        firstPractice = new ORM_CMN_BPT_BusinessParticipant_AssociatedBusinessParticipant();
                        firstPractice.CMN_BPT_BusinessParticipant_AssociatedBusinessParticipantID = Guid.NewGuid();
                        firstPractice.Tenant_RefID = securityTicket.TenantID;
                        firstPractice.BusinessParticipant_RefID = bussinessParticipant.CMN_BPT_BusinessParticipantID;
                    }
                    firstPractice.AssociatedParticipant_FunctionName = Parameter.Practices[0].AssociatedParticipant_FunctionName;
                    firstPractice.AssociatedBusinessParticipant_RefID = practiceBPT.CMN_BPT_BusinessParticipantID;
                    firstPractice.Save(Connection, Transaction);
                }
                #endregion
            }
            else
            {
                #region Save

                //personInfo
                Guid personInfoID;
                if (Parameter.Account_RefID == Guid.Empty)
                {
                    var personInfo = new ORM_CMN_PER_PersonInfo();
                    personInfo.CMN_PER_PersonInfoID = Guid.NewGuid();
                    personInfo.FirstName = Parameter.FirstName;
                    personInfo.LastName = Parameter.LastName;
                    if(Parameter.isLucentisSave)
                        personInfo.PrimaryEmail = Parameter.ifLucentis_LoginEmail;
                    personInfo.Title = Parameter.Title;
                    personInfo.Creation_Timestamp = DateTime.Now;
                    personInfo.Tenant_RefID = securityTicket.TenantID;
                    if (Parameter.isOphthalSave)
                    {
                        personInfo.Salutation_Letter = Parameter.ifOphthal_Salutation_Letter;
                        personInfo.Salutation_General = Parameter.ifOphthal_Salutation_General;
                    }
                    personInfo.Save(Connection, Transaction);
                    personInfoID = personInfo.CMN_PER_PersonInfoID;
                }
                else
                {
                    var account2personInfoQuery = new ORM_CMN_PER_PersonInfo_2_Account.Query();
                    account2personInfoQuery.USR_Account_RefID = Parameter.Account_RefID;
                    account2personInfoQuery.Tenant_RefID = securityTicket.TenantID;
                    account2personInfoQuery.IsDeleted = false;
                    var account2personInfo = ORM_CMN_PER_PersonInfo_2_Account.Query.Search(Connection, Transaction, account2personInfoQuery).First();

                    var query2 = new ORM_CMN_PER_PersonInfo.Query();
                    query2.CMN_PER_PersonInfoID = account2personInfo.CMN_PER_PersonInfo_RefID;

                    var personInfo = ORM_CMN_PER_PersonInfo.Query.Search(Connection, Transaction, query2).First();
                    personInfo.FirstName = Parameter.FirstName;
                    personInfo.LastName = Parameter.LastName;
                    personInfo.Title = Parameter.Title;
                    personInfo.Save(Connection, Transaction);

                    personInfoID = personInfo.CMN_PER_PersonInfoID;
                }
                //bussinessParticipants
                var bussinessParticipantTable = new ORM_CMN_BPT_BusinessParticipant();
                bussinessParticipantTable.CMN_BPT_BusinessParticipantID = Guid.NewGuid();
                bussinessParticipantTable.IsNaturalPerson = true;
                bussinessParticipantTable.IsTenant = false;
                bussinessParticipantTable.IsCompany = false;
                bussinessParticipantTable.IsDeleted = false;
                bussinessParticipantTable.Creation_Timestamp = DateTime.Now;
                bussinessParticipantTable.Tenant_RefID = securityTicket.TenantID;
                bussinessParticipantTable.IfNaturalPerson_CMN_PER_PersonInfo_RefID = personInfoID;
                bussinessParticipantTable.Save(Connection, Transaction);

                doctor.HEC_DoctorID = Guid.NewGuid();
                if (Parameter.isLucentisSave)
                {
                    doctor.DoctorIDNumber = Parameter.ifLucentis_LANR;
                }
                doctor.Creation_Timestamp = DateTime.Now;
                doctor.Tenant_RefID = securityTicket.TenantID;
                doctor.BusinessParticipant_RefID = bussinessParticipantTable.CMN_BPT_BusinessParticipantID;
                doctor.Account_RefID = Parameter.Account_RefID;
                doctor.Save(Connection, Transaction);

                if (Parameter.Contacts != null)
                {
                    foreach (var contact in Parameter.Contacts)
                    {
                        ORM_CMN_PER_CommunicationContact communicationContacts = new ORM_CMN_PER_CommunicationContact();
                        communicationContacts.CMN_PER_CommunicationContactID = Guid.NewGuid();
                        communicationContacts.PersonInfo_RefID = personInfoID;
                        communicationContacts.Contact_Type = contact.CMN_PER_CommunicationContact_TypeID;
                        communicationContacts.Content = contact.Content;
                        communicationContacts.Creation_Timestamp = DateTime.Now;
                        communicationContacts.Tenant_RefID = securityTicket.TenantID;
                        communicationContacts.Save(Connection, Transaction);
                    }
                }

                foreach (var practice in Parameter.Practices)
                {
                    if (practice.isDeleted == true)
                        continue;

                    var medPract = new ORM_HEC_MedicalPractis.Query();
                    medPract.HEC_MedicalPractiseID = practice.PracticeID;
                    var medicalPractice = ORM_HEC_MedicalPractis.Query.Search(Connection, Transaction, medPract).First();

                    var queryCompanyInfo = new ORM_CMN_COM_CompanyInfo.Query();
                    queryCompanyInfo.CMN_COM_CompanyInfoID = medicalPractice.Ext_CompanyInfo_RefID;
                    var companyInfo = ORM_CMN_COM_CompanyInfo.Query.Search(Connection, Transaction, queryCompanyInfo).First();

                    var practiceQuery = new ORM_CMN_BPT_BusinessParticipant.Query();
                    practiceQuery.IfCompany_CMN_COM_CompanyInfo_RefID = companyInfo.CMN_COM_CompanyInfoID;
                    var practiceBPT = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, practiceQuery).First();

                    //associatedbusinessparticipants
                    var associatedbusinessparticipants = new ORM_CMN_BPT_BusinessParticipant_AssociatedBusinessParticipant();
                    associatedbusinessparticipants.BusinessParticipant_RefID = bussinessParticipantTable.CMN_BPT_BusinessParticipantID;
                    associatedbusinessparticipants.AssociatedBusinessParticipant_RefID = practiceBPT.CMN_BPT_BusinessParticipantID;
                    associatedbusinessparticipants.AssociatedParticipant_FunctionName = practice.AssociatedParticipant_FunctionName;
                    associatedbusinessparticipants.Creation_Timestamp = DateTime.Now;
                    associatedbusinessparticipants.Tenant_RefID = securityTicket.TenantID;
                    associatedbusinessparticipants.Save(Connection, Transaction);
                }
                #endregion
            }

            returnValue.Result = doctor.HEC_DoctorID;
            return returnValue;

			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L3MD_SDBI_1349 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L3MD_SDBI_1349 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L3MD_SDBI_1349 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3MD_SDBI_1349 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Doctor_BaseInfo",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3MD_SDBI_1349 for attribute P_L3MD_SDBI_1349
		[DataContract]
		public class P_L3MD_SDBI_1349 
		{
			[DataMember]
			public P_L3MD_SDBI_1349_Practice[] Practices { get; set; }
			[DataMember]
			public P_L3MD_SDBI_1349_Contacts[] Contacts { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid DoctorID { get; set; } 
			[DataMember]
			public Guid Account_RefID { get; set; } 
			[DataMember]
			public String Title { get; set; } 
			[DataMember]
			public String FirstName { get; set; } 
			[DataMember]
			public String LastName { get; set; } 
			[DataMember]
			public Boolean isOphthalSave { get; set; } 
			[DataMember]
			public String ifOphthal_Salutation_General { get; set; } 
			[DataMember]
			public String ifOphthal_Salutation_Letter { get; set; } 
			[DataMember]
			public Boolean isLucentisSave { get; set; } 
			[DataMember]
			public String ifLucentis_LANR { get; set; } 
			[DataMember]
			public String ifLucentis_LoginEmail { get; set; } 

		}
		#endregion
		#region SClass P_L3MD_SDBI_1349_Practice for attribute Practices
		[DataContract]
		public class P_L3MD_SDBI_1349_Practice 
		{
			//Standard type parameters
			[DataMember]
			public Guid PracticeID { get; set; } 
			[DataMember]
			public Boolean isDeleted { get; set; } 
			[DataMember]
			public String AssociatedParticipant_FunctionName { get; set; } 

		}
		#endregion
		#region SClass P_L3MD_SDBI_1349_Contacts for attribute Contacts
		[DataContract]
		public class P_L3MD_SDBI_1349_Contacts 
		{
			//Standard type parameters
			[DataMember]
			public String Content { get; set; } 
			[DataMember]
			public Guid CMN_PER_CommunicationContact_TypeID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Doctor_BaseInfo(,P_L3MD_SDBI_1349 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = VerifySessionToken(sessionToken);
		FR_Guid invocationResult = cls_Save_Doctor_BaseInfo.Invoke(connectionString,P_L3MD_SDBI_1349 Parameter,securityTicket);
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
var parameter = new CL3_Doctors.Atomic.Manipulation.P_L3MD_SDBI_1349();
parameter.Practices = ...;
parameter.Contacts = ...;

parameter.DoctorID = ...;
parameter.Account_RefID = ...;
parameter.Title = ...;
parameter.FirstName = ...;
parameter.LastName = ...;
parameter.isOphthalSave = ...;
parameter.ifOphthal_Salutation_General = ...;
parameter.ifOphthal_Salutation_Letter = ...;
parameter.isLucentisSave = ...;
parameter.ifLucentis_LANR = ...;
parameter.ifLucentis_LoginEmail = ...;

*/
