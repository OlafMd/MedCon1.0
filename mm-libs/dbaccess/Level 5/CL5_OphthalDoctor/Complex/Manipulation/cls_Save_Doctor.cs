/* 
 * Generated on 9/16/2013 11:53:19 AM
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
using CL3_Doctors.Atomic.Manipulation;
using CL1_HEC;
using CL1_CMN_BPT_CTM;
using CL1_USR;
using CL1_CMN_BPT;
using CL3_DeviceAccountCodes.Complex.Retrieval;
using Core_ClassLibrarySupport.Utils;

namespace CL5_OphthalDoctors.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Doctor.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Doctor
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5OD_SD_1130 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            Guid accounrRefID = Guid.Empty;
            var doctorQuery = new ORM_HEC_Doctor.Query();
            ORM_HEC_Doctor doctor;
            if(Parameter.HEC_DoctorID != Guid.Empty)
            {
                doctorQuery.HEC_DoctorID = Parameter.HEC_DoctorID;
                doctor = ORM_HEC_Doctor.Query.Search(Connection, Transaction, doctorQuery).First();
                accounrRefID = doctor.Account_RefID;
            }

            P_L3MD_SDBI_1349 sbdParam = new P_L3MD_SDBI_1349();
            sbdParam.DoctorID = Parameter.HEC_DoctorID;
            sbdParam.Account_RefID = accounrRefID;
            sbdParam.FirstName = Parameter.FirstName;
            sbdParam.LastName = Parameter.LastName;
            sbdParam.isOphthalSave = true;
            sbdParam.ifOphthal_Salutation_General = Parameter.Salutation_General;
            sbdParam.ifOphthal_Salutation_Letter = Parameter.Salutation_Letter;
            sbdParam.Title = Parameter.Title;

            List<P_L3MD_SDBI_1349_Contacts> contactsParams = new List<P_L3MD_SDBI_1349_Contacts>();
            if (Parameter.Contacts != null)
            {
                foreach (var item in Parameter.Contacts)
                {
                    var c = new P_L3MD_SDBI_1349_Contacts();
                    c.CMN_PER_CommunicationContact_TypeID = item.CMN_PER_CommunicationContact_TypeID;
                    c.Content = item.Content;
                    contactsParams.Add(c);
                }
            }
            sbdParam.Contacts = contactsParams.ToArray();

            List<P_L3MD_SDBI_1349_Practice> practicesParams = new List<P_L3MD_SDBI_1349_Practice>();
            if (Parameter.Practices != null)
            {
                foreach (var item in Parameter.Practices)
                {
                    var p = new P_L3MD_SDBI_1349_Practice();
                    p.PracticeID = item.PracticeID;
                    p.isDeleted = item.isDeleted;
                    p.AssociatedParticipant_FunctionName = item.AssociatedParticipant_FunctionName;
                    practicesParams.Add(p);
                }
            }
            sbdParam.Practices = practicesParams.ToArray();

            var docID = cls_Save_Doctor_BaseInfo.Invoke(Connection, Transaction, sbdParam, securityTicket).Result;

            doctorQuery = new ORM_HEC_Doctor.Query();
            doctorQuery.HEC_DoctorID = docID;
            
            doctor = ORM_HEC_Doctor.Query.Search(Connection, Transaction, doctorQuery).First();
            var bParticipantQuery = new ORM_CMN_BPT_BusinessParticipant.Query();
            bParticipantQuery.CMN_BPT_BusinessParticipantID = doctor.BusinessParticipant_RefID;
            var bParticipant = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, bParticipantQuery).First();

            ORM_CMN_BPT_CTM_Customer_2_SalesRepresentative SalesRepresentative;
            var customerQuery = new ORM_CMN_BPT_CTM_Customer.Query();
            customerQuery.Ext_BusinessParticipant_RefID = bParticipant.CMN_BPT_BusinessParticipantID;
            var customer = ORM_CMN_BPT_CTM_Customer.Query.Search(Connection, Transaction, customerQuery).FirstOrDefault();
            if (customer == null)
            {
                customer = new ORM_CMN_BPT_CTM_Customer();
                customer.CMN_BPT_CTM_CustomerID = Guid.NewGuid();
                customer.Tenant_RefID = securityTicket.TenantID;
                SalesRepresentative = new ORM_CMN_BPT_CTM_Customer_2_SalesRepresentative();
                SalesRepresentative.AssignmentID = Guid.NewGuid();
                SalesRepresentative.Customer_RefID = customer.CMN_BPT_CTM_CustomerID;
                SalesRepresentative.Tenant_RefID = securityTicket.TenantID;
                customer.Ext_BusinessParticipant_RefID = bParticipant.CMN_BPT_BusinessParticipantID;
            }
            else
            {
                customer = ORM_CMN_BPT_CTM_Customer.Query.Search(Connection, Transaction, customerQuery).First();
                var SalesRepresentativeQuery = new ORM_CMN_BPT_CTM_Customer_2_SalesRepresentative.Query();
                SalesRepresentativeQuery.Customer_RefID = customer.CMN_BPT_CTM_CustomerID;
                SalesRepresentative = ORM_CMN_BPT_CTM_Customer_2_SalesRepresentative.Query.Search(Connection, Transaction, SalesRepresentativeQuery).First();
            }
            SalesRepresentative.SalesRepresentative_RefID = Parameter.CMN_BPT_SalesRepresentativeID;

            var sRepresentativeQuery = new ORM_CMN_BPT_SalesRepresentative.Query();
            sRepresentativeQuery.CMN_BPT_SalesRepresentativeID = Parameter.CMN_BPT_SalesRepresentativeID;
            sRepresentativeQuery.IsDeleted = false;
            var sRepresentative = ORM_CMN_BPT_SalesRepresentative.Query.Search(Connection, Transaction, sRepresentativeQuery).FirstOrDefault();
            if (sRepresentative == null)
            {
                sRepresentative = new ORM_CMN_BPT_SalesRepresentative();
                sRepresentative.CMN_BPT_SalesRepresentativeID = Parameter.CMN_BPT_SalesRepresentativeID;
                sRepresentative.Save(Connection, Transaction);
            }

            customer.Save(Connection, Transaction);
            SalesRepresentative.Save(Connection, Transaction);

            ORM_USR_Account account;
            ORM_USR_Device_AccountCode code;
            ORM_USR_Device_AccountCode_StatusHistory codeStatus;
            var accountQuery = new ORM_USR_Account.Query();
            accountQuery.BusinessParticipant_RefID = bParticipant.CMN_BPT_BusinessParticipantID;
            accountQuery.AccountType = 3;
            var accountQueryRes = ORM_USR_Account.Query.Search(Connection, Transaction, accountQuery);
            if (accountQueryRes.Count == 0)
            {
                account = new ORM_USR_Account();
                account.USR_AccountID = Guid.NewGuid();
                account.Tenant_RefID = securityTicket.TenantID;
                account.AccountType = 3;
                account.BusinessParticipant_RefID = bParticipant.CMN_BPT_BusinessParticipantID;
                account.Save(Connection, Transaction);

                code = new ORM_USR_Device_AccountCode();
                code.Tenant_RefID = securityTicket.TenantID;
                code.USR_Device_AccountCodeID = Guid.NewGuid();
                code.Account_RefID = account.USR_AccountID;
                code.AccountCode_ValidFrom = DateTime.Now;

                codeStatus = new ORM_USR_Device_AccountCode_StatusHistory();
                codeStatus.USR_Device_AccountCode_StatusHistoryID = Guid.NewGuid();
                codeStatus.Device_AccountCode_RefID = code.USR_Device_AccountCodeID;
                codeStatus.Tenant_RefID = securityTicket.TenantID;
                codeStatus.IsAccountCode_Active = true;
                codeStatus.Save(Connection, Transaction);

                code.AccountCode_CurrentStatus_RefID = codeStatus.USR_Device_AccountCode_StatusHistoryID;

                L3DAC_GDACFTCV_1616 checkCodeValue;
                P_L3DAC_GDACFTCV_1616 codeParam = new P_L3DAC_GDACFTCV_1616();
                string codeValue;
                do
                {
                    codeValue = RandomString.Generate(8);      
                    codeParam.CodeValue = codeValue;
                    checkCodeValue = cls_GetDeviceAccountCodeForTenantAndCodeValue.Invoke(Connection, Transaction, codeParam, securityTicket).Result;
                } while (checkCodeValue != null);

                code.AccountCode_Value = codeValue;
                code.Save(Connection, Transaction);
            }

            returnValue.Result = docID;
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5OD_SD_1130 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5OD_SD_1130 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5OD_SD_1130 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5OD_SD_1130 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Doctor",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5OD_SD_1130 for attribute P_L5OD_SD_1130
		[DataContract]
		public class P_L5OD_SD_1130 
		{
			[DataMember]
			public P_L3MD_SD_1130_Contacts[] Contacts { get; set; }
			[DataMember]
			public P_L3MD_SD_1130_Practice[] Practices { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid HEC_DoctorID { get; set; } 
			[DataMember]
			public String Title { get; set; } 
			[DataMember]
			public String LastName { get; set; } 
			[DataMember]
			public String FirstName { get; set; } 
			[DataMember]
			public String Salutation_General { get; set; } 
			[DataMember]
			public String Salutation_Letter { get; set; } 
			[DataMember]
			public String AssociatedParticipant_FunctionName { get; set; } 
			[DataMember]
			public Guid CMN_BPT_SalesRepresentativeID { get; set; } 

		}
		#endregion
		#region SClass P_L3MD_SD_1130_Contacts for attribute Contacts
		[DataContract]
		public class P_L3MD_SD_1130_Contacts 
		{
			//Standard type parameters
			[DataMember]
			public String Content { get; set; } 
			[DataMember]
			public Guid CMN_PER_CommunicationContact_TypeID { get; set; } 

		}
		#endregion
		#region SClass P_L3MD_SD_1130_Practice for attribute Practices
		[DataContract]
		public class P_L3MD_SD_1130_Practice 
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

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Doctor(,P_L5OD_SD_1130 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Doctor.Invoke(connectionString,P_L5OD_SD_1130 Parameter,securityTicket);
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
var parameter = new CL5_OphthalDoctors.Complex.Manipulation.P_L5OD_SD_1130();
parameter.Contacts = ...;
parameter.Practices = ...;

parameter.HEC_DoctorID = ...;
parameter.Title = ...;
parameter.LastName = ...;
parameter.FirstName = ...;
parameter.Salutation_General = ...;
parameter.Salutation_Letter = ...;
parameter.AssociatedParticipant_FunctionName = ...;
parameter.CMN_BPT_SalesRepresentativeID = ...;

*/
