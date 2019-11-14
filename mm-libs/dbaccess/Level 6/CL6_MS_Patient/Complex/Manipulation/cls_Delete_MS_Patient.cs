/* 
 * Generated on 7/22/2013 3:45:47 PM
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
using CL6_MS_Patient.Atomic.Retrieval;
using CL1_CMN_PER;
using CL1_CMN_BPT;
using CL1_HEC;
using CL1_HEC_STU;
using CL1_USR;

namespace CL6_MS_Patient.Complex.Manipulation
{
	/// <summary>
    /// 
      
    
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Delete_MS_Patient.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Delete_MS_Patient
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L6PA_DMSP_1546 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Guid();

            P_L6PA_GMSPfID_1538 getParam = new P_L6PA_GMSPfID_1538();
            getParam.HEC_PatientID = Parameter.HEC_PatientID;
            var patient = cls_Get_MS_Patients_For_ID.Invoke(Connection, Transaction, getParam, securityTicket).Result;
            if (patient != null)
            {
                if (patient.Addresses != null)
                {
                    foreach (var address in patient.Addresses)
                    {
                        P_L6PA_MSVAFP_1545 delAddressPar = new P_L6PA_MSVAFP_1545();
                        delAddressPar.CMN_AddressID = address.CMN_AddressID;
                        cls_Delete_MS_AddressForPatient.Invoke(Connection, Transaction, delAddressPar, securityTicket);
                    }
                }
                if (patient.Contacts != null)
                {
                    foreach (var contact in patient.Contacts)
                    {
                        ORM_CMN_PER_CommunicationContact.Query cQuery = new ORM_CMN_PER_CommunicationContact.Query();
                        cQuery.CMN_PER_CommunicationContactID = contact.CMN_PER_CommunicationContactID;
                        cQuery.IsDeleted = false;
                        cQuery.Tenant_RefID = securityTicket.TenantID;
                        ORM_CMN_PER_CommunicationContact.Query.SoftDelete(Connection, Transaction, cQuery);
                    }
                }

                ORM_CMN_PER_PersonInfo.Query ORM_CMN_PER_PersonInfoQuery = new ORM_CMN_PER_PersonInfo.Query();
                ORM_CMN_PER_PersonInfoQuery.CMN_PER_PersonInfoID = patient.CMN_PER_PersonInfoID;
                ORM_CMN_PER_PersonInfoQuery.IsDeleted = false;
                ORM_CMN_PER_PersonInfoQuery.Tenant_RefID = securityTicket.TenantID;
                ORM_CMN_PER_PersonInfo.Query.SoftDelete(Connection, Transaction, ORM_CMN_PER_PersonInfoQuery);

                ORM_CMN_BPT_BusinessParticipant.Query ORM_CMN_BPT_BusinessParticipantoQuery = new ORM_CMN_BPT_BusinessParticipant.Query();
                ORM_CMN_BPT_BusinessParticipantoQuery.CMN_BPT_BusinessParticipantID = patient.CMN_BPT_BusinessParticipantID;
                ORM_CMN_BPT_BusinessParticipantoQuery.IsDeleted = false;
                ORM_CMN_BPT_BusinessParticipantoQuery.Tenant_RefID = securityTicket.TenantID;
                ORM_CMN_BPT_BusinessParticipant.Query.SoftDelete(Connection, Transaction, ORM_CMN_BPT_BusinessParticipantoQuery);

                ORM_HEC_Patient.Query ORM_HEC_PatientQuery = new ORM_HEC_Patient.Query();
                ORM_HEC_PatientQuery.HEC_PatientID = patient.HEC_PatientID;
                ORM_HEC_PatientQuery.IsDeleted = false;
                ORM_HEC_PatientQuery.Tenant_RefID = securityTicket.TenantID;
                ORM_HEC_Patient.Query.SoftDelete(Connection, Transaction, ORM_HEC_PatientQuery);

                ORM_HEC_Patient_HealthInsurance.Query ORM_HEC_Patient_HealthInsuranceoQuery = new ORM_HEC_Patient_HealthInsurance.Query();
                ORM_HEC_Patient_HealthInsuranceoQuery.HEC_Patient_HealthInsurancesID = patient.HEC_Patient_HealthInsurancesID;
                ORM_HEC_Patient_HealthInsuranceoQuery.IsDeleted = false;
                ORM_HEC_Patient_HealthInsuranceoQuery.Tenant_RefID = securityTicket.TenantID;
                ORM_HEC_Patient_HealthInsurance.Query.SoftDelete(Connection, Transaction, ORM_HEC_Patient_HealthInsuranceoQuery);

                ORM_HEC_STU_Study_ParticipatingPatient.Query ORM_HEC_STU_Study_ParticipatingPatientQuery = new ORM_HEC_STU_Study_ParticipatingPatient.Query();
                ORM_HEC_STU_Study_ParticipatingPatientQuery.HEC_STU_Study_ParticipatingPatientID = patient.HEC_STU_Study_ParticipatingPatientID;
                ORM_HEC_STU_Study_ParticipatingPatientQuery.IsDeleted = false;
                ORM_HEC_STU_Study_ParticipatingPatientQuery.Tenant_RefID = securityTicket.TenantID;
                ORM_HEC_STU_Study_ParticipatingPatient.Query.SoftDelete(Connection, Transaction, ORM_HEC_STU_Study_ParticipatingPatientQuery);

                ORM_USR_Account.Query ORM_USR_AccountQuery = new ORM_USR_Account.Query();
                ORM_USR_AccountQuery.IsDeleted = false;
                ORM_USR_AccountQuery.Tenant_RefID = securityTicket.TenantID;
                ORM_USR_AccountQuery.BusinessParticipant_RefID = patient.CMN_BPT_BusinessParticipantID;
                ORM_USR_Account.Query.SoftDelete(Connection, Transaction, ORM_USR_AccountQuery);

                var accountRes = ORM_USR_Account.Query.Search(Connection, Transaction, ORM_USR_AccountQuery);

                if(accountRes.Count == 1)
                {
                    ORM_USR_Device_AccountCode.Query ORM_USR_Device_AccountCodeQuery = new ORM_USR_Device_AccountCode.Query();
                    ORM_USR_Device_AccountCodeQuery.IsDeleted = false;
                    ORM_USR_Device_AccountCodeQuery.Tenant_RefID = securityTicket.TenantID;
                    ORM_USR_Device_AccountCodeQuery.Account_RefID = accountRes[0].USR_AccountID;
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
		public static FR_Guid Invoke(string ConnectionString,P_L6PA_DMSP_1546 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L6PA_DMSP_1546 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L6PA_DMSP_1546 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6PA_DMSP_1546 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Delete_MS_Patient",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L6PA_DMSP_1546 for attribute P_L6PA_DMSP_1546
		[DataContract]
		public class P_L6PA_DMSP_1546 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_PatientID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Delete_MS_Patient(,P_L6PA_DMSP_1546 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Delete_MS_Patient.Invoke(connectionString,P_L6PA_DMSP_1546 Parameter,securityTicket);
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
var parameter = new CL6_MS_Patient.Complex.Manipulation.P_L6PA_DMSP_1546();
parameter.HEC_PatientID = ...;

*/
