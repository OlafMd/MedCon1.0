/* 
 * Generated on 11/7/2013 3:53:45 PM
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
using CL1_CMN_STR_PPS;
using CL1_CMN_PPS;
using PlannicoModel.Models;
using VacationPlaner;

namespace CL5_Plannico_ShiftTimes.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ShiftTemplateDetail_For_ShiftTemplateDetailID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ShiftTemplateDetail_For_ShiftTemplateDetailID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5ST_GSTDFSTD_1426 Execute(DbConnection Connection,DbTransaction Transaction,P_L5ST_GSTDFSTD_1426 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5ST_GSTDFSTD_1426();
            returnValue.Result = new L5ST_GSTDFSTD_1426();
            returnValue.Result.ShiftTemplateDetail = new L5ST_GSTDFST_1402();

            var item = new ORM_CMN_PPS_ShiftTemplate_WorkDetail();
            item.Load(Connection, Transaction, Parameter.ShiftTemplateDetailID);
            returnValue.Result.ShiftTemplateDetail.CMN_PPS_ShiftTemplate_WorkDetailID = item.CMN_PPS_ShiftTemplate_WorkDetailID;
            returnValue.Result.ShiftTemplateDetail.Duration_in_sec = item.Duration_in_sec;
            returnValue.Result.ShiftTemplateDetail.Required_StaffHeadCount = item.Required_StaffHeadCount;
            returnValue.Result.ShiftTemplateDetail.ShiftStart_Offset_sec = item.ShiftStart_Offset_sec;
            returnValue.Result.ShiftTemplateDetail.WorkDetail_Note_Content = item.WorkDetail_Note_Content;
            returnValue.Result.ShiftTemplateDetail.WorkDetail_Note_Title = item.WorkDetail_Note_Title;

            ORM_CMN_STR_PPS_WorkDetail_Activity.Query activityDetailQuery = new ORM_CMN_STR_PPS_WorkDetail_Activity.Query();
            activityDetailQuery.IsDeleted = false;
            activityDetailQuery.Tenant_RefID = securityTicket.TenantID;
            activityDetailQuery.CMN_PPS_ShiftTemplate_WorkDetail_RefID = item.CMN_PPS_ShiftTemplate_WorkDetailID;
            List<ORM_CMN_STR_PPS_WorkDetail_Activity> activityDetails = ORM_CMN_STR_PPS_WorkDetail_Activity.Query.Search(Connection, Transaction, activityDetailQuery);
            if (activityDetails != null && activityDetails.Count != 0)
            {
                ORM_CMN_STR_PPS_WorkDetail_Activity activityDetail = activityDetails.FirstOrDefault();
                returnValue.Result.ShiftTemplateDetail.CMN_STR_PPS_Workplace_RefID=activityDetail.CMN_STR_PPS_Workplace_RefID;

                if (activityDetail.CMN_STR_PPS_Activity_RefID != Guid.Empty)
                {
                    ORM_CMN_STR_PPS_Activity activity = new ORM_CMN_STR_PPS_Activity();
                    activity.Load(Connection, Transaction, activityDetail.CMN_STR_PPS_Activity_RefID);
                    returnValue.Result.ShiftTemplateDetail.AbsenceReason_RefID = activity.AbsenceReason_RefID;
                }

            }
			//Put your code here
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5ST_GSTDFSTD_1426 Invoke(string ConnectionString,P_L5ST_GSTDFSTD_1426 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5ST_GSTDFSTD_1426 Invoke(DbConnection Connection,P_L5ST_GSTDFSTD_1426 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5ST_GSTDFSTD_1426 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5ST_GSTDFSTD_1426 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5ST_GSTDFSTD_1426 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5ST_GSTDFSTD_1426 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5ST_GSTDFSTD_1426 functionReturn = new FR_L5ST_GSTDFSTD_1426();
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

                Guid errorID = Guid.NewGuid();
                ServerLog.Instance.Fatal("Application error occured. ErrorID = " + errorID, ex);
				throw new Exception("Exception occured in method cls_Get_ShiftTemplateDetail_For_ShiftTemplateDetailID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5ST_GSTDFSTD_1426 : FR_Base
	{
		public L5ST_GSTDFSTD_1426 Result	{ get; set; }

		public FR_L5ST_GSTDFSTD_1426() : base() {}

		public FR_L5ST_GSTDFSTD_1426(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes


	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5ST_GSTDFSTD_1426 cls_Get_ShiftTemplateDetail_For_ShiftTemplateDetailID(,P_L5ST_GSTDFSTD_1426 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5ST_GSTDFSTD_1426 invocationResult = cls_Get_ShiftTemplateDetail_For_ShiftTemplateDetailID.Invoke(connectionString,P_L5ST_GSTDFSTD_1426 Parameter,securityTicket);
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
var parameter = new CL5_Plannico_ShiftTimes.Complex.Retrieval.P_L5ST_GSTDFSTD_1426();
parameter.ShiftTemplateDetailID = ...;

*/