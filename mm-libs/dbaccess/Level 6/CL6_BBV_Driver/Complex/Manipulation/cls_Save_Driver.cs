/* 
 * Generated on 6/21/2013 1:56:22 PM
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
using CL1_HEC_STU;
using CL1_CMN_BPT;
using CL1_USR;
using CL2_DeviceAccountCode.Complex.Retrieval;
using CL1_CMN_PER;
using CL1_CMN;
using Core_ClassLibrarySupport.Apoteken;

namespace CL6_BBV_Driver.Complex.Manipulation
{
	/// <summary>
    /// No description found in <meta/> tag
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Driver.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Driver
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L6DR_SD_1537 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here

            if (Parameter.CMN_BPT_BusinessParticipantID == Guid.Empty)
            {
                #region Create Mode

                #region BusinessParticipant

                
                ORM_CMN_BPT_BusinessParticipant bParticipant = new ORM_CMN_BPT_BusinessParticipant();
                bParticipant.CMN_BPT_BusinessParticipantID = Guid.NewGuid();
                bParticipant.IfNaturalPerson_CMN_PER_PersonInfo_RefID = Guid.NewGuid();
                bParticipant.IsNaturalPerson = true;
                bParticipant.Tenant_RefID = securityTicket.TenantID;
                bParticipant.Creation_Timestamp = DateTime.Now;
                bParticipant.Save(Connection, Transaction);

                #endregion

                #region Account

                ORM_USR_Account account = new ORM_USR_Account();

                account.Username = Parameter.FirstName + "_" + Parameter.LastName;
                account.AccountType = 3;
                account.BusinessParticipant_RefID = bParticipant.CMN_BPT_BusinessParticipantID;
                account.Tenant_RefID = securityTicket.TenantID;
                account.Creation_Timestamp = DateTime.Now;
                account.Save(Connection, Transaction);

                P_L2DC_GUDCfT_1505 codeParam = new P_L2DC_GUDCfT_1505();
                codeParam.codeLength = 8;
                var checkCodeValue = cls_GetUniqueDeviceCodeForTenant.Invoke(Connection, Transaction, codeParam, securityTicket).Result;

                ORM_USR_Device_AccountCode accountCode = new ORM_USR_Device_AccountCode();
                accountCode.Account_RefID = account.USR_AccountID;
                accountCode.AccountCode_Value = checkCodeValue.CodeValue;
                accountCode.AccountCode_ValidFrom = DateTime.Now;
                accountCode.AccountCode_CurrentStatus_RefID = Guid.NewGuid();
                accountCode.IsAccountCode_Expirable = false;
                accountCode.Tenant_RefID = securityTicket.TenantID;
                accountCode.Creation_Timestamp = DateTime.Now;
                accountCode.Save(Connection, Transaction);

                ORM_USR_Device_AccountCode_StatusHistory Device_AccountCode_StatusHistory = new ORM_USR_Device_AccountCode_StatusHistory();
                Device_AccountCode_StatusHistory.USR_Device_AccountCode_StatusHistoryID = accountCode.AccountCode_CurrentStatus_RefID;
                Device_AccountCode_StatusHistory.IsAccountCode_Active = true;
                Device_AccountCode_StatusHistory.Device_AccountCode_RefID = accountCode.USR_Device_AccountCodeID;
                Device_AccountCode_StatusHistory.Tenant_RefID = securityTicket.TenantID;
                Device_AccountCode_StatusHistory.Creation_Timestamp = DateTime.Now;
                Device_AccountCode_StatusHistory.Save(Connection, Transaction);


                ORM_USR_Device_AccountCode_UsageHistory USR_Device_AccountCode_UsageHistory = new ORM_USR_Device_AccountCode_UsageHistory();
                USR_Device_AccountCode_UsageHistory.USR_Device_AccountCode_UsageHistoryID = Guid.NewGuid();
                USR_Device_AccountCode_UsageHistory.Tenant_RefID = securityTicket.TenantID;
                USR_Device_AccountCode_UsageHistory.Device_AccountCode_RefID = accountCode.USR_Device_AccountCodeID;
                USR_Device_AccountCode_UsageHistory.Creation_Timestamp = DateTime.Now;
                USR_Device_AccountCode_UsageHistory.Save(Connection, Transaction);


                #endregion

                #region PersonInfo and Adresses

                ORM_CMN_PER_PersonInfo personInfo = new ORM_CMN_PER_PersonInfo();
                personInfo.CMN_PER_PersonInfoID = bParticipant.IfNaturalPerson_CMN_PER_PersonInfo_RefID;
                personInfo.Salutation_General = Parameter.Salutation_General;
                personInfo.FirstName = Parameter.FirstName;
                personInfo.LastName = Parameter.LastName;
                personInfo.PrimaryEmail = Parameter.PrimaryMail;
                personInfo.Address_RefID = Guid.NewGuid();
                personInfo.Tenant_RefID = securityTicket.TenantID;
                personInfo.Save(Connection, Transaction);

                ORM_CMN_PER_PersonInfo_2_Address personAdress = new ORM_CMN_PER_PersonInfo_2_Address();
                personAdress.AssignmentID = Guid.NewGuid();
                personAdress.CMN_PER_PersonInfo_RefID = personInfo.CMN_PER_PersonInfoID;
                personAdress.CMN_Address_RefID = personInfo.Address_RefID;
                personAdress.IsPrimary = true;
                personAdress.Tenant_RefID = securityTicket.TenantID;
                personAdress.Save(Connection, Transaction);

                ORM_CMN_Address adress = new ORM_CMN_Address();
                adress.CMN_AddressID = personInfo.Address_RefID;
                adress.City_Name = Parameter.City_Name;
                adress.Province_Name = Parameter.Province_Name;
                adress.Street_Name = Parameter.Street_Name;
                adress.Street_Number = Parameter.Street_Number;
                adress.City_PostalCode = Parameter.City_PostalCode;
                adress.Tenant_RefID = securityTicket.TenantID;
                adress.Save(Connection, Transaction);

                #endregion

                #region Contacts

                foreach (var parContact in Parameter.Contacts)
                {
                    ORM_CMN_PER_CommunicationContact contact = new ORM_CMN_PER_CommunicationContact();
                    contact.Content = parContact.Content;
                    contact.Contact_Type = parContact.CMN_PER_CommunicationContact_TypeID;
                    contact.Tenant_RefID = securityTicket.TenantID;
                    contact.PersonInfo_RefID = personInfo.CMN_PER_PersonInfoID;
                    contact.Save(Connection, Transaction);
                }

                #endregion

                #region Driver To Employer

                ORM_CMN_BPT_BusinessParticipant_AssociatedBusinessParticipant bpt_asBP = new ORM_CMN_BPT_BusinessParticipant_AssociatedBusinessParticipant();
                bpt_asBP.CMN_BPT_BusinessParticipant_AssociatedBusinessParticipantID = Guid.NewGuid();
                bpt_asBP.BusinessParticipant_RefID = bParticipant.CMN_BPT_BusinessParticipantID;
                bpt_asBP.AssociatedParticipant_FunctionName = "Driver";
                bpt_asBP.Tenant_RefID = securityTicket.TenantID;
                bpt_asBP.AssociatedBusinessParticipant_RefID = Parameter.CMN_BPT_BusinessParticipantID_Of_Employer;
                bpt_asBP.Save(Connection, Transaction);

                #endregion

                #endregion
            }
            else {

                ORM_CMN_BPT_BusinessParticipant bParticipant = new ORM_CMN_BPT_BusinessParticipant();
                bParticipant.Load(Connection, Transaction, Parameter.CMN_BPT_BusinessParticipantID);

                var personInfo = new ORM_CMN_PER_PersonInfo();
                personInfo.Load(Connection, Transaction, bParticipant.IfNaturalPerson_CMN_PER_PersonInfo_RefID);
                personInfo.Salutation_General = Parameter.Salutation_General;
                personInfo.FirstName = Parameter.FirstName;
                personInfo.LastName = Parameter.LastName;
                personInfo.PrimaryEmail = Parameter.PrimaryMail;
                personInfo.Save(Connection, Transaction);

                ORM_CMN_Address adress = new ORM_CMN_Address();
                adress.Load(Connection, Transaction, personInfo.Address_RefID);
                adress.City_Name = Parameter.City_Name;
                adress.Province_Name = Parameter.Province_Name;
                adress.Street_Name = Parameter.Street_Name;
                adress.Street_Number = Parameter.Street_Number;
                adress.Save(Connection, Transaction);

                foreach (var parContact in Parameter.Contacts)
                {
                    var query = new ORM_CMN_PER_CommunicationContact.Query();
                    query.Contact_Type = parContact.CMN_PER_CommunicationContact_TypeID;
                    query.IsDeleted = false;
                    query.PersonInfo_RefID = personInfo.CMN_PER_PersonInfoID;

                    var contact = ORM_CMN_PER_CommunicationContact.Query.Search(Connection, Transaction, query).First();
                    contact.Content = parContact.Content;
                    contact.Contact_Type = parContact.CMN_PER_CommunicationContact_TypeID;
                    contact.Save(Connection, Transaction);
                }

                var associationQuery = new ORM_CMN_BPT_BusinessParticipant_AssociatedBusinessParticipant.Query();
                associationQuery.BusinessParticipant_RefID = Parameter.CMN_BPT_BusinessParticipantID;
                associationQuery.IsDeleted = false;

                var bpt_asBP = ORM_CMN_BPT_BusinessParticipant_AssociatedBusinessParticipant.Query.Search(Connection, Transaction, associationQuery).First();
                bpt_asBP.AssociatedBusinessParticipant_RefID = Parameter.CMN_BPT_BusinessParticipantID_Of_Employer;
                bpt_asBP.Save(Connection, Transaction);
            }

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L6DR_SD_1537 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L6DR_SD_1537 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L6DR_SD_1537 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6DR_SD_1537 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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
		#region SClass P_L6DR_SD_1537 for attribute P_L6DR_SD_1537
		[DataContract]
		public class P_L6DR_SD_1537 
		{
			[DataMember]
			public P_L6DR_SD_1537_Contacts[] Contacts { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid CMN_BPT_BusinessParticipantID { get; set; } 
			[DataMember]
			public String Salutation_General { get; set; } 
			[DataMember]
			public String FirstName { get; set; } 
			[DataMember]
			public String LastName { get; set; } 
			[DataMember]
			public String PrimaryMail { get; set; } 
			[DataMember]
			public String Participation_Comment { get; set; } 
			[DataMember]
			public String Street_Name { get; set; } 
			[DataMember]
			public String Street_Number { get; set; } 
			[DataMember]
			public String City_Name { get; set; } 
			[DataMember]
			public String City_PostalCode { get; set; } 
			[DataMember]
			public String Province_Name { get; set; } 
			[DataMember]
			public Guid CMN_BPT_BusinessParticipantID_Of_Employer { get; set; } 

		}
		#endregion
		#region SClass P_L6DR_SD_1537_Contacts for attribute Contacts
		[DataContract]
		public class P_L6DR_SD_1537_Contacts 
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
