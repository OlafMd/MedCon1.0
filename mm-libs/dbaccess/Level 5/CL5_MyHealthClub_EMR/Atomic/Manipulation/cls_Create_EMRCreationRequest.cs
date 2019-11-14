/* 
 * Generated on 22.01.2015 15:31:32
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
using CL1_HEC_PAT;
using CL1_USR;

namespace CL5_MyHealthClub_EMR.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Create_EMRCreationRequest.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Create_EMRCreationRequest
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5ME_CECRfPID_1520 Execute(DbConnection Connection,DbTransaction Transaction,P_L5ME_CECRfPID_1520 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_L5ME_CECRfPID_1520();

            var request = ORM_HEC_PAT_ElectronicMedicalRecord_CreationRequest.Query.Search(Connection, Transaction, new ORM_HEC_PAT_ElectronicMedicalRecord_CreationRequest.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                IsEMRFileCreated = false,
                Patient_RefID = Parameter.PatientID,
                
            }).SingleOrDefault();


            if (request == null)
            {
                var user = ORM_USR_Account.Query.Search(Connection, Transaction, new ORM_USR_Account.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    USR_AccountID = securityTicket.AccountID
                }).Single();

                request = new ORM_HEC_PAT_ElectronicMedicalRecord_CreationRequest()
                {
                    Tenant_RefID = securityTicket.TenantID, 
                    RequestedBy_BusinessParticipant_RefID = user.BusinessParticipant_RefID,
                    HEC_PAT_ElectronicMedicalRecord_CreationRequestID = Guid.NewGuid(),
                    Patient_RefID = Parameter.PatientID,
                    EMRFile_ExternalURL = string.Empty
                };
                request.RequestDate = DateTime.Now;
                request.Save(Connection, Transaction);
            }

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5ME_CECRfPID_1520 Invoke(string ConnectionString,P_L5ME_CECRfPID_1520 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5ME_CECRfPID_1520 Invoke(DbConnection Connection,P_L5ME_CECRfPID_1520 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5ME_CECRfPID_1520 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5ME_CECRfPID_1520 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5ME_CECRfPID_1520 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5ME_CECRfPID_1520 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5ME_CECRfPID_1520 functionReturn = new FR_L5ME_CECRfPID_1520();
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

				throw new Exception("Exception occured in method cls_Create_EMRCreationRequest",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5ME_CECRfPID_1520 : FR_Base
	{
		public L5ME_CECRfPID_1520 Result	{ get; set; }

		public FR_L5ME_CECRfPID_1520() : base() {}

		public FR_L5ME_CECRfPID_1520(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5ME_CECRfPID_1520 for attribute P_L5ME_CECRfPID_1520
		[DataContract]
		public class P_L5ME_CECRfPID_1520 
		{
			//Standard type parameters
			[DataMember]
			public Guid PatientID { get; set; } 

		}
		#endregion
		#region SClass L5ME_CECRfPID_1520 for attribute L5ME_CECRfPID_1520
		[DataContract]
		public class L5ME_CECRfPID_1520 
		{
			//Standard type parameters
			[DataMember]
			public Guid asd { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5ME_CECRfPID_1520 cls_Create_EMRCreationRequest(,P_L5ME_CECRfPID_1520 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5ME_CECRfPID_1520 invocationResult = cls_Create_EMRCreationRequest.Invoke(connectionString,P_L5ME_CECRfPID_1520 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_EMR.Atomic.Manipulation.P_L5ME_CECRfPID_1520();
parameter.PatientID = ...;

*/
