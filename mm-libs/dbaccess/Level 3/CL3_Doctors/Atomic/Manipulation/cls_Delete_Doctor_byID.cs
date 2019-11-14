/* 
 * Generated on 9/9/2013 10:31:14 AM
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
using CL1_CMN_BPT_CTM;
using CL1_USR;

namespace CL3_Doctors.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Delete_Doctor_byID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Delete_Doctor_byID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L3MD_DDbID_1031 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
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
                doctor.IsDeleted = true;
                doctor.Save(Connection, Transaction);

                //bussinessParticipant
                var query1 = new ORM_CMN_BPT_BusinessParticipant.Query();
                query1.CMN_BPT_BusinessParticipantID = doctor.BusinessParticipant_RefID;
                var bussinessParticipant = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, query1).First();
                bussinessParticipant.IsDeleted = true;
                bussinessParticipant.Save(Connection, Transaction);

                if(doctor.Account_RefID != Guid.Empty)
                {
                    var account2personInfoQuery = new ORM_CMN_PER_PersonInfo_2_Account.Query();
                    account2personInfoQuery.USR_Account_RefID = doctor.Account_RefID;
                    account2personInfoQuery.Tenant_RefID = securityTicket.TenantID;
                    var account2personInfo = ORM_CMN_PER_PersonInfo_2_Account.Query.Search(Connection, Transaction, account2personInfoQuery).FirstOrDefault();
                    if (account2personInfo != null)
                    {
                        account2personInfo.IsDeleted = true;
                        account2personInfo.Save(Connection, Transaction);

                        var query2 = new ORM_CMN_PER_PersonInfo.Query();
                        query2.CMN_PER_PersonInfoID = account2personInfo.CMN_PER_PersonInfo_RefID;
                        var personInfo = ORM_CMN_PER_PersonInfo.Query.Search(Connection, Transaction, query2).First();
                        personInfo.IsDeleted = true;
                        personInfo.Save(Connection, Transaction);
                    }
                    var query4 = new ORM_CMN_PER_CommunicationContact.Query();
                    query4.PersonInfo_RefID = bussinessParticipant.IfNaturalPerson_CMN_PER_PersonInfo_RefID;

                    var communicationContactsList = ORM_CMN_PER_CommunicationContact.Query.Search(Connection, Transaction, query4).ToList();

                    foreach (var contact in communicationContactsList)
                    {
                        contact.IsDeleted = true;
                        contact.Save(Connection, Transaction);
                    }
                }

                var query3 = new ORM_CMN_BPT_BusinessParticipant_AssociatedBusinessParticipant.Query();
                query3.BusinessParticipant_RefID = bussinessParticipant.CMN_BPT_BusinessParticipantID;
                query3.IsDeleted = false;
                var abpRes = ORM_CMN_BPT_BusinessParticipant_AssociatedBusinessParticipant.Query.Search(Connection, Transaction, query3);
                foreach (ORM_CMN_BPT_BusinessParticipant_AssociatedBusinessParticipant assigned in abpRes)
                {
                    assigned.IsDeleted = true;
                    assigned.Save(Connection, Transaction);
                }
               
                #endregion

                ORM_CMN_BPT_CTM_Customer customer;
                ORM_CMN_BPT_CTM_Customer_2_SalesRepresentative SalesRepresentative;
                var customerQuery = new ORM_CMN_BPT_CTM_Customer.Query();
                customerQuery.Ext_BusinessParticipant_RefID = bussinessParticipant.CMN_BPT_BusinessParticipantID;
                var customerRes = ORM_CMN_BPT_CTM_Customer.Query.Search(Connection, Transaction, customerQuery);
                if (customerRes.Count != 0)
                {
                    customer = ORM_CMN_BPT_CTM_Customer.Query.Search(Connection, Transaction, customerQuery).First();
                    var SalesRepresentativeQuery = new ORM_CMN_BPT_CTM_Customer_2_SalesRepresentative.Query();
                    SalesRepresentativeQuery.Customer_RefID = customer.CMN_BPT_CTM_CustomerID;
                    SalesRepresentative = ORM_CMN_BPT_CTM_Customer_2_SalesRepresentative.Query.Search(Connection, Transaction, SalesRepresentativeQuery).First();

                    customer.IsDeleted = true;
                    customer.Save(Connection, Transaction);
                    SalesRepresentative.IsDeleted = true;
                    SalesRepresentative.Save(Connection, Transaction);
                }

                var accountQuery = new ORM_USR_Account.Query();
                accountQuery.BusinessParticipant_RefID = bussinessParticipant.CMN_BPT_BusinessParticipantID;
                accountQuery.AccountType = 3;
                var accountQueryRes = ORM_USR_Account.Query.Search(Connection, Transaction, accountQuery);
                if (accountQueryRes.Count != 0)
                {
                    var account = accountQueryRes.First();
                    account.IsDeleted = true;
                    account.Save(Connection, Transaction);

                    var codeQuery = new ORM_USR_Device_AccountCode.Query();
                    codeQuery.Account_RefID = account.USR_AccountID;
                    var code = ORM_USR_Device_AccountCode.Query.Search(Connection, Transaction, codeQuery).First();
                    code.IsDeleted = true;
                    code.Save(Connection, Transaction);

                    var codeStatusQuery = new ORM_USR_Device_AccountCode_StatusHistory.Query();
                    codeStatusQuery.Device_AccountCode_RefID = code.USR_Device_AccountCodeID;
                    var codeStatus = ORM_USR_Device_AccountCode_StatusHistory.Query.Search(Connection, Transaction, codeStatusQuery).First();
                    codeStatus.IsDeleted = true;
                    codeStatus.Save(Connection, Transaction);
                }
            }

            returnValue.Result = doctor.HEC_DoctorID;
			return returnValue;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L3MD_DDbID_1031 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L3MD_DDbID_1031 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L3MD_DDbID_1031 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3MD_DDbID_1031 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Delete_Doctor_byID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3MD_DDbID_1031 for attribute P_L3MD_DDbID_1031
		[DataContract]
		public class P_L3MD_DDbID_1031 
		{
			//Standard type parameters
			[DataMember]
			public Guid DoctorID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Delete_Doctor_byID(,P_L3MD_DDbID_1031 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = VerifySessionToken(sessionToken);
		FR_Guid invocationResult = cls_Delete_Doctor_byID.Invoke(connectionString,P_L3MD_DDbID_1031 Parameter,securityTicket);
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
var parameter = new CL3_Doctors.Atomic.Manipulation.P_L3MD_DDbID_1031();
parameter.DoctorID = ...;

*/
