/* 
 * Generated on 6/24/2013 3:20:41 PM
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
using CL6_BBV_Patient.Atomic.Retrieval;
using CL1_HEC_STU;

namespace CL6_BBV_Patient.Complex.Manipulation
{
	[DataContract]
	public class cls_Edit_BBV_PatientPolicyComment
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L6PA_EBBVPPC_1519 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            P_L6PA_GBBVPfID_1714 getPatientParam = new P_L6PA_GBBVPfID_1714();
            getPatientParam.HEC_PatientID = Parameter.HEC_PatientID;
            L6PA_GBBVPfID_1714 patient = cls_Get_BBV_Patients_For_ID.Invoke(Connection, Transaction, getPatientParam, securityTicket).Result;

            if (patient == null)
            {
                var error = new FR_Guid();
                error.ErrorMessage = "No Such ID";
                error.Status = FR_Status.Error_Internal;
                return error;
            }
            
            ORM_HEC_STU_Study_ParticipatingPatient.Query ppQuery = new ORM_HEC_STU_Study_ParticipatingPatient.Query();
            ppQuery.IsDeleted = false;
            ppQuery.Tenant_RefID = securityTicket.TenantID;
            ppQuery.HEC_STU_Study_ParticipatingPatientID = patient.HEC_STU_Study_ParticipatingPatientID;
            var ppRes = ORM_HEC_STU_Study_ParticipatingPatient.Query.Search(Connection, Transaction, ppQuery);

            ORM_HEC_STU_Study_ParticipatingPatient ParticipatingPatient = ppRes[0];
            ParticipatingPatient.Participation_Comment = Parameter.Comment;
            ParticipatingPatient.Save(Connection, Transaction);

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L6PA_EBBVPPC_1519 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L6PA_EBBVPPC_1519 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L6PA_EBBVPPC_1519 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6PA_EBBVPPC_1519 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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
		#region SClass P_L6PA_EBBVPPC_1519 for attribute P_L6PA_EBBVPPC_1519
		[DataContract]
		public class P_L6PA_EBBVPPC_1519 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_PatientID { get; set; } 
			[DataMember]
			public string Comment { get; set; } 

		}
		#endregion

	#endregion
}
