/* 
 * Generated on 3/16/2017 1:50:50 PM
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
using MMDocConnectDBMethods.Case.Atomic.Retrieval;

namespace MMDocConnectDBMethods.Case.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_TreatmentYearOctCount_IndependentForLocalization.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_TreatmentYearOctCount_IndependentForLocalization
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_CAS_GTYOctCIfL_1939 Execute(DbConnection Connection,DbTransaction Transaction,P_CAS_GTYOctCIfL_1939 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_CAS_GTYOctCIfL_1939();
			//Put your code here
            var relevant_oct_actions = cls_Get_RelevantActionIDs_for_PatientID.Invoke(Connection, Transaction, new P_CAS_GRAIDsfPID_1352()
            {
                PatientID = Parameter.PatientID,
                ActionTypeID = Parameter.OctPlannedActionTypeID,
                TreatmentYearEndDate = Parameter.TreatmentYearEndDate,
                TreatmentYearStartDate = Parameter.TreatmentYearStartDate
            }, securityTicket).Result.Where(t => t.action_id != Parameter.OctActionIdToOmit).ToList();

            var relevant_oct_actions_grouped_by_case = relevant_oct_actions.GroupBy(t => t.case_id).ToDictionary(t => t.Key, t => t.ToList());

            var oct_count = 0;
            if (relevant_oct_actions.Any())
            {
                var case_ids = relevant_oct_actions.Select(t => t.case_id).ToArray();

                var oct_fs_statuses = cls_Get_OctFsStatuses_for_PatientID_in_TimeSpan_LocalizationIndependent.Invoke(Connection, Transaction, new P_CAS_GOctFSSfPIDiTSLI_1117()
                {
                    DateFrom = Parameter.TreatmentYearStartDate,
                    DateTo = Parameter.TreatmentYearEndDate,
                    PatientID = Parameter.PatientID
                }, securityTicket).Result.GroupBy(r => r.case_id).ToDictionary(r => r.Key, r => r.ToList());
                
                foreach (var case_oct_actions in relevant_oct_actions_grouped_by_case)
                {
                    if (oct_fs_statuses.ContainsKey(case_oct_actions.Key))
                    {
                        var fs_statuses = oct_fs_statuses[case_oct_actions.Key];
                        for (var i = 0; i < case_oct_actions.Value.Count; i++)
                        {
                            var fs_status_code = fs_statuses[i].fs_status;
                            if (fs_status_code != 8 && fs_status_code != 11 && fs_status_code != 17)
                            {
                                oct_count++;
                            }
                        }
                    }
                }
            }

            returnValue.Result = new CAS_GTYOctCIfL_1939();
            returnValue.Result.fs_status_count = oct_count;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_CAS_GTYOctCIfL_1939 Invoke(string ConnectionString,P_CAS_GTYOctCIfL_1939 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_CAS_GTYOctCIfL_1939 Invoke(DbConnection Connection,P_CAS_GTYOctCIfL_1939 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_CAS_GTYOctCIfL_1939 Invoke(DbConnection Connection, DbTransaction Transaction,P_CAS_GTYOctCIfL_1939 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_CAS_GTYOctCIfL_1939 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_CAS_GTYOctCIfL_1939 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_CAS_GTYOctCIfL_1939 functionReturn = new FR_CAS_GTYOctCIfL_1939();
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

				throw new Exception("Exception occured in method cls_Get_TreatmentYearOctCount_IndependentForLocalization",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_CAS_GTYOctCIfL_1939 : FR_Base
	{
		public CAS_GTYOctCIfL_1939 Result	{ get; set; }

		public FR_CAS_GTYOctCIfL_1939() : base() {}

		public FR_CAS_GTYOctCIfL_1939(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_CAS_GTYOctCIfL_1939 for attribute P_CAS_GTYOctCIfL_1939
		[DataContract]
		public class P_CAS_GTYOctCIfL_1939 
		{
			//Standard type parameters
			[DataMember]
			public Guid OctPlannedActionTypeID { get; set; } 
			[DataMember]
			public Guid PatientID { get; set; } 
			[DataMember]
			public DateTime TreatmentYearStartDate { get; set; } 
			[DataMember]
			public DateTime TreatmentYearEndDate { get; set; } 
			[DataMember]
			public Guid OctActionIdToOmit { get; set; } 

		}
		#endregion
		#region SClass CAS_GTYOctCIfL_1939 for attribute CAS_GTYOctCIfL_1939
		[DataContract]
		public class CAS_GTYOctCIfL_1939 
		{
			//Standard type parameters
			[DataMember]
			public int fs_status_count { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_CAS_GTYOctCIfL_1939 cls_Get_TreatmentYearOctCount_IndependentForLocalization(,P_CAS_GTYOctCIfL_1939 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_CAS_GTYOctCIfL_1939 invocationResult = cls_Get_TreatmentYearOctCount_IndependentForLocalization.Invoke(connectionString,P_CAS_GTYOctCIfL_1939 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Case.Complex.Retrieval.P_CAS_GTYOctCIfL_1939();
parameter.OctPlannedActionTypeID = ...;
parameter.PatientID = ...;
parameter.TreatmentYearStartDate = ...;
parameter.TreatmentYearEndDate = ...;
parameter.OctActionIdToOmit = ...;

*/
