/* 
 * Generated on 31.1.2015 16:23:38
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
using CL1_MRS_MPT;
using CL1_CMN_BPT;
using CL1_CMN_PER;
using DLUtils_Common.Email;
using CL1_MRS_RUN;

namespace CL6_MRMS_Backoffice.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Send_Email_to_Readers.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Send_Email_to_Readers
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Base Execute(DbConnection Connection,DbTransaction Transaction,P_L6MRMS_SEtR_1606 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Base();


            List<ORM_MRS_RUN_MeasurementRun_AccountDownloadCode> downloadCodes = ORM_MRS_RUN_MeasurementRun_AccountDownloadCode.Query.Search(Connection, Transaction, new ORM_MRS_RUN_MeasurementRun_AccountDownloadCode.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                MeasurementRun_RefID = Parameter.ReadingSessionId
            });

            foreach (var downloadCode in downloadCodes)
            {

                ORM_CMN_BPT_BusinessParticipant businessParticipant = new ORM_CMN_BPT_BusinessParticipant();
                var bpLoad = businessParticipant.Load(Connection, Transaction, downloadCode.Account_RefID);
                if (bpLoad.Status != FR_Status.Success)
                {
                    continue;
                }

                ORM_CMN_BPT_BusinessParticipant_AccessCode bpAccountCode = ORM_CMN_BPT_BusinessParticipant_AccessCode.Query.Search(Connection, Transaction , new ORM_CMN_BPT_BusinessParticipant_AccessCode.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    BusinessParticipant_RefID = businessParticipant.CMN_BPT_BusinessParticipantID
                }).SingleOrDefault();
                if(bpAccountCode == null)
                    continue;

                ORM_CMN_PER_PersonInfo personInfo = new ORM_CMN_PER_PersonInfo();
                var piLoad = personInfo.Load(Connection, Transaction, businessParticipant.IfNaturalPerson_CMN_PER_PersonInfo_RefID);
                if (piLoad.Status != FR_Status.Success)
                {
                    continue;
                }

                //sending email

                string subject = Parameter.EmailSubjectTemplate;
                string body = String.Format
                    (
                        Parameter.EmailBodyTemplate, 
                        personInfo.FirstName, 
                        personInfo.LastName, 
                        downloadCode.DownloadCode, 
                        bpAccountCode.Code
                    );
                EmailUtils.SendMail(personInfo.PrimaryEmail, subject, body);

            }

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Base Invoke(string ConnectionString,P_L6MRMS_SEtR_1606 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection,P_L6MRMS_SEtR_1606 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction,P_L6MRMS_SEtR_1606 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6MRMS_SEtR_1606 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Base functionReturn = new FR_Base();
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

				throw new Exception("Exception occured in method cls_Send_Email_to_Readers",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L6MRMS_SEtR_1606 for attribute P_L6MRMS_SEtR_1606
		[DataContract]
		public class P_L6MRMS_SEtR_1606 
		{
			//Standard type parameters
			[DataMember]
			public Guid ReadingSessionId { get; set; } 
			[DataMember]
			public string EmailSubjectTemplate { get; set; } 
			[DataMember]
			public string EmailBodyTemplate { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Base cls_Send_Email_to_Readers(,P_L6MRMS_SEtR_1606 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Base invocationResult = cls_Send_Email_to_Readers.Invoke(connectionString,P_L6MRMS_SEtR_1606 Parameter,securityTicket);
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
var parameter = new CL6_MRMS_Backoffice.Complex.Manipulation.P_L6MRMS_SEtR_1606();
parameter.ReadingSessionId = ...;
parameter.EmailSubjectTemplate = ...;
parameter.EmailBodyTemplate = ...;

*/
