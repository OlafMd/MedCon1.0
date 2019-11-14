/* 
 * Generated on 12/24/2013 6:47:32 PM
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
using CSV2Core.Core;
using System.Runtime.Serialization;
using CL1_USR;
using CL1_CMN;
using CL1_CMN_BPT;
using CL1_CMN_PER;
using CL2_Contact.Complex.Retrieval;
using DLCore_DBCommons.Utils;
using CL2_Contact.DomainManagement;
using CL1_CMN_BPT_EMP;

namespace CL5_APOAdmin_User.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_SystemUser.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_SystemUser
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5US_SSU_1847 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Guid();
            
            var userAccount = new ORM_USR_Account();
            var result = userAccount.Load(Connection, Transaction, Parameter.USR_AccountID);            

            if (result.Status == FR_Status.Success)
            {
                //Get business participant via userAccount 
                var businessParticipant = new ORM_CMN_BPT_BusinessParticipant();
                businessParticipant.Load(Connection, Transaction, userAccount.BusinessParticipant_RefID);
                
                //Load person
                var personInfo = new ORM_CMN_PER_PersonInfo();
                personInfo.Load(Connection, Transaction, businessParticipant.IfNaturalPerson_CMN_PER_PersonInfo_RefID);

                //Load communication contacts for person
                P_L2CN_GCCfPI_1222 contactsParam = new P_L2CN_GCCfPI_1222();
                contactsParam.PersonInfoID = personInfo.CMN_PER_PersonInfoID;
                var contactsForPersonInfo = cls_Get_ComunicationContacts_for_PersonInfoID.Invoke(Connection, Transaction, contactsParam, securityTicket).Result.ToList();

                if (!Parameter.IsInitialSave)
                {

                    if (Parameter.IsDeleted)
                    {
                        #region Delete

                        var queryApplicationSubscription = new ORM_CMN_Account_ApplicationSubscription.Query();
                        queryApplicationSubscription.Application_RefID = Parameter.ApplicationID;
                        queryApplicationSubscription.Account_RefID = userAccount.USR_AccountID;
                        queryApplicationSubscription.Tenant_RefID = securityTicket.TenantID;

                        var foundApplicationSubscription = ORM_CMN_Account_ApplicationSubscription.Query.SoftDelete(Connection, Transaction, queryApplicationSubscription);

                        return new FR_Guid(FR_Base.Status_OK, userAccount.USR_AccountID);

                        #endregion
                    }

                    #region Edit              

                   
                    personInfo.FirstName = Parameter.FirstName_ContactPerson;
                    personInfo.LastName = Parameter.LastName_ContactPerson;
                    personInfo.Save(Connection, Transaction);

                    var employeeTemp = ORM_CMN_BPT_EMP_Employee.Query.Search(Connection, Transaction, new ORM_CMN_BPT_EMP_Employee.Query()
                    {
                        BusinessParticipant_RefID = businessParticipant.CMN_BPT_BusinessParticipantID,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).SingleOrDefault();

                    if (employeeTemp == null)
                    {
                        var newEmployee = new ORM_CMN_BPT_EMP_Employee();
                        newEmployee.CMN_BPT_EMP_EmployeeID = Guid.NewGuid();
                        newEmployee.BusinessParticipant_RefID = businessParticipant.CMN_BPT_BusinessParticipantID;
                        newEmployee.StandardFunction = "APOAdminEmployee";
                        newEmployee.Tenant_RefID = securityTicket.TenantID;
                        newEmployee.Save(Connection, Transaction);
                    }


                    var address = new ORM_CMN_Address();
                    address.Load(Connection, Transaction, personInfo.Address_RefID);
                    address.Street_Name = Parameter.Street_Name;
                    address.Street_Number = Parameter.Street_Number;
                    address.City_Name = Parameter.Town;
                    address.City_PostalCode = Parameter.ZIP;
                    address.Save(Connection, Transaction);
                                       

                    try
                    {
                        //telephone
                        var telephone = contactsForPersonInfo.Where(i => i.Type == EnumUtils.GetEnumDescription(EComunactionContactType.Phone))
                            .First().Contacts;

                        if (telephone.Count() == 1)
                        {
                            var contactID = telephone[0].CMN_PER_CommunicationContactID;

                            var contactTelephone = new ORM_CMN_PER_CommunicationContact();
                            contactTelephone.Load(Connection, Transaction, contactID);
                            contactTelephone.Content = Parameter.Contact_Telephone;
                            contactTelephone.Save(Connection, Transaction);

                        }
                    }
                    catch
                    {

                        //Log this
                    }

                    #region CommentedUsefull-PreviousWayOfContactEmailHandling
                    
                    //try
                    //{
                    //    //email
                    //    var email = contactsForPersonInfo.Where(i => i.Type == EnumUtils.GetEnumDescription(EComunactionContactType.Email))
                    //        .First().Contacts;

                    //    if (email.Count() == 1)
                    //    {
                    //        var contactID = email[0].CMN_PER_CommunicationContactID;

                    //        var contactEmail = new ORM_CMN_PER_CommunicationContact();
                    //        contactEmail.Load(Connection, Transaction, contactID);
                    //        contactEmail.Content = Parameter.Contact_Email;
                    //        contactEmail.Save(Connection, Transaction);
                    //    }

                    //}
                    //catch
                    //{

                    //    //Log this
                    //}

                    #endregion

                    #endregion

                }

                #region SaveGroup

                var userAccountToGroup = ORM_USR_Account_2_Group.Query.Search(Connection, Transaction, new ORM_USR_Account_2_Group.Query()
                {
                    USR_Account_RefID = userAccount.USR_AccountID,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).SingleOrDefault();


                if (userAccountToGroup == null)
                {
                    var newGroup = new ORM_USR_Account_2_Group();
                    newGroup.AssignmentID = Guid.NewGuid();
                    newGroup.USR_Account_RefID = userAccount.USR_AccountID;
                    newGroup.USR_Group_RefID = Parameter.USR_GroupID;
                    newGroup.Creation_Timestamp = DateTime.Now;
                    newGroup.Tenant_RefID = securityTicket.TenantID;
                    newGroup.Save(Connection, Transaction);
                }
                else
                {
                    userAccountToGroup.USR_Group_RefID = Parameter.USR_GroupID;
                    userAccountToGroup.Save(Connection, Transaction);
                }

                #endregion

                #region SaveEmployee

                var employee = ORM_CMN_BPT_EMP_Employee.Query.Search(Connection, Transaction, new ORM_CMN_BPT_EMP_Employee.Query()
                {
                    BusinessParticipant_RefID = businessParticipant.CMN_BPT_BusinessParticipantID,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).SingleOrDefault();

                if (employee == null)
                {
                    var newEmployee = new ORM_CMN_BPT_EMP_Employee();
                    newEmployee.CMN_BPT_EMP_EmployeeID = Guid.NewGuid();
                    newEmployee.BusinessParticipant_RefID = businessParticipant.CMN_BPT_BusinessParticipantID;
                    newEmployee.StandardFunction = "APOAdminEmployee";
                    newEmployee.Tenant_RefID = securityTicket.TenantID;
                    newEmployee.Save(Connection, Transaction);
                }

                #endregion

                #region CreateOrUpdateContactEmail

                var emailTypeProperty = EnumUtils.GetEnumDescription(EComunactionContactType.Email);
                var contactEmailTypeQuery = new ORM_CMN_PER_CommunicationContact_Type.Query();
                contactEmailTypeQuery.Type = emailTypeProperty;
                contactEmailTypeQuery.Tenant_RefID = securityTicket.TenantID;
                var contactEmailType = ORM_CMN_PER_CommunicationContact_Type.Query.Search(Connection, Transaction, contactEmailTypeQuery).FirstOrDefault();                                

                //Search for default contact email and create it if don't exist

                var defaultContactEmailQuery = new ORM_CMN_PER_CommunicationContact.Query();
                defaultContactEmailQuery.PersonInfo_RefID = personInfo.CMN_PER_PersonInfoID;
                defaultContactEmailQuery.Contact_Type = contactEmailType.CMN_PER_CommunicationContact_TypeID;
                defaultContactEmailQuery.Tenant_RefID = securityTicket.TenantID;
                var defaultContactEmail = ORM_CMN_PER_CommunicationContact.Query.Search(Connection, Transaction, defaultContactEmailQuery).FirstOrDefault();

                if (defaultContactEmail == null)
                {
                    defaultContactEmail = new ORM_CMN_PER_CommunicationContact();
                    defaultContactEmail.PersonInfo_RefID = personInfo.CMN_PER_PersonInfoID;
                    defaultContactEmail.Contact_Type = contactEmailType.CMN_PER_CommunicationContact_TypeID;
                    defaultContactEmail.IsDefaultForContactType = true;
                    defaultContactEmail.Tenant_RefID = securityTicket.TenantID;
                }

                defaultContactEmail.Content = Parameter.Contact_Email;
                defaultContactEmail.IsDefaultForContactType = true;
                defaultContactEmail.Save(Connection, Transaction);

                #endregion
            }
            else
            {
                FR_Guid error = new FR_Guid();
                error.ErrorMessage = "No Such ID.";
                error.Status = FR_Status.Error_Internal;
                return error;
            }

            return new FR_Guid(FR_Base.Status_OK, userAccount.USR_AccountID);
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5US_SSU_1847 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5US_SSU_1847 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5US_SSU_1847 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5US_SSU_1847 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_SystemUser",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5US_SSU_1847 for attribute P_L5US_SSU_1847
		[DataContract]
		public class P_L5US_SSU_1847 
		{
			//Standard type parameters
			[DataMember]
			public Guid USR_AccountID { get; set; } 
			[DataMember]
			public String FirstName_ContactPerson { get; set; } 
			[DataMember]
			public String LastName_ContactPerson { get; set; } 
			[DataMember]
			public String Street_Name { get; set; } 
			[DataMember]
			public String Street_Number { get; set; } 
			[DataMember]
			public String ZIP { get; set; } 
			[DataMember]
			public String Town { get; set; } 
			[DataMember]
			public String Contact_Email { get; set; } 
			[DataMember]
			public String Contact_Telephone { get; set; } 
			[DataMember]
			public Guid USR_GroupID { get; set; } 
			[DataMember]
			public Guid ApplicationID { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 
			[DataMember]
			public bool IsInitialSave { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_SystemUser(,P_L5US_SSU_1847 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_SystemUser.Invoke(connectionString,P_L5US_SSU_1847 Parameter,securityTicket);
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
var parameter = new CL5_APOAdmin_User.Complex.Manipulation.P_L5US_SSU_1847();
parameter.USR_AccountID = ...;
parameter.FirstName_ContactPerson = ...;
parameter.LastName_ContactPerson = ...;
parameter.Street_Name = ...;
parameter.Street_Number = ...;
parameter.ZIP = ...;
parameter.Town = ...;
parameter.Contact_Email = ...;
parameter.Contact_Telephone = ...;
parameter.USR_GroupID = ...;
parameter.ApplicationID = ...;
parameter.IsDeleted = ...;
parameter.IsInitialSave = ...;

*/
