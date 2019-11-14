/* 
 * Generated on 09/02/16 09:48:55
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
using CL1_HEC_ACT;
using CL1_HEC_CAS;

namespace MMDocConnectDBMethods.Case.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Create_OCT.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Create_OCT
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_CAS_COCT_1703 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_Guid();
            //Put your code here

            var oct_planned_action = new ORM_HEC_ACT_PlannedAction();
            oct_planned_action.Patient_RefID = Parameter.patient_id;
            oct_planned_action.PlannedFor_Date = Parameter.treatment_date;
            oct_planned_action.MedicalPractice_RefID = Parameter.practice_id;
            oct_planned_action.Tenant_RefID = securityTicket.TenantID;
            oct_planned_action.ToBePerformedBy_BusinessParticipant_RefID = Parameter.oct_bpt_id;
            oct_planned_action.Modification_Timestamp = DateTime.Now;

            oct_planned_action.Save(Connection, Transaction);

            var oct_planned_action_2_type = new ORM_HEC_ACT_PlannedAction_2_ActionType();
            oct_planned_action_2_type.HEC_ACT_ActionType_RefID = Parameter.oct_action_type_id;
            oct_planned_action_2_type.HEC_ACT_PlannedAction_RefID = oct_planned_action.HEC_ACT_PlannedActionID;
            oct_planned_action_2_type.Tenant_RefID = securityTicket.TenantID;
            oct_planned_action_2_type.Modification_Timestamp = DateTime.Now;

            oct_planned_action_2_type.Save(Connection, Transaction);

            var oct_relevant_planned_action = new ORM_HEC_CAS_Case_RelevantPlannedAction();
            oct_relevant_planned_action.Case_RefID = Parameter.case_id;
            oct_relevant_planned_action.PlannedAction_RefID = oct_planned_action.HEC_ACT_PlannedActionID;
            oct_relevant_planned_action.Tenant_RefID = securityTicket.TenantID;
            oct_relevant_planned_action.Modification_Timestamp = DateTime.Now;

            oct_relevant_planned_action.Save(Connection, Transaction);

            returnValue.Result = oct_planned_action.HEC_ACT_PlannedActionID;
            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_CAS_COCT_1703 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_CAS_COCT_1703 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_CAS_COCT_1703 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_CAS_COCT_1703 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Create_OCT",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_CAS_COCT_1703 for attribute P_CAS_COCT_1703
		[DataContract]
		public class P_CAS_COCT_1703 
		{
			//Standard type parameters
			[DataMember]
			public Guid case_id { get; set; } 
			[DataMember]
			public Guid patient_id { get; set; } 
			[DataMember]
			public Guid practice_id { get; set; } 
			[DataMember]
			public Guid oct_bpt_id { get; set; } 
			[DataMember]
			public Guid oct_action_type_id { get; set; } 
			[DataMember]
			public DateTime treatment_date { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Create_OCT(,P_CAS_COCT_1703 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Create_OCT.Invoke(connectionString,P_CAS_COCT_1703 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Case.Atomic.Manipulation.P_CAS_COCT_1703();
parameter.case_id = ...;
parameter.patient_id = ...;
parameter.practice_id = ...;
parameter.oct_bpt_id = ...;
parameter.oct_action_type_id = ...;
parameter.treatment_date = ...;

*/
