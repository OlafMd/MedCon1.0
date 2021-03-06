/* 
 * Generated on 11/7/2013 3:57:06 PM
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

namespace CL5_Plannico_ShiftTimes.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Delete_ShiftTemplateDetail.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Delete_ShiftTemplateDetail
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Base Execute(DbConnection Connection,DbTransaction Transaction,P_L5ST_DSTD_1425 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            var item = new ORM_CMN_PPS_ShiftTemplate_WorkDetail();
            item.Load(Connection, Transaction, Parameter.CMN_PPS_ShiftTemplate_WorkDetailID);
            item.Remove(Connection, Transaction);

            ORM_CMN_STR_PPS_WorkDetail_Activity.Query activityDetailQuery = new ORM_CMN_STR_PPS_WorkDetail_Activity.Query();
            activityDetailQuery.IsDeleted = false;
            activityDetailQuery.Tenant_RefID = securityTicket.TenantID;
            activityDetailQuery.CMN_PPS_ShiftTemplate_WorkDetail_RefID = item.CMN_PPS_ShiftTemplate_WorkDetailID;
            List<ORM_CMN_STR_PPS_WorkDetail_Activity> activityDetails = ORM_CMN_STR_PPS_WorkDetail_Activity.Query.Search(Connection, Transaction, activityDetailQuery);
            if (activityDetails != null && activityDetails.Count != 0)
            {
                ORM_CMN_STR_PPS_WorkDetail_Activity activityDetail = activityDetails.FirstOrDefault();
                activityDetail.Remove(Connection, Transaction);

                if (activityDetail.CMN_STR_PPS_Activity_RefID != Guid.Empty)
                {
                    ORM_CMN_STR_PPS_Activity activity = new ORM_CMN_STR_PPS_Activity();
                    activity.Load(Connection, Transaction, activityDetail.CMN_STR_PPS_Activity_RefID);
                    activity.Remove(Connection, Transaction);
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
		public static FR_Base Invoke(string ConnectionString,P_L5ST_DSTD_1425 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection,P_L5ST_DSTD_1425 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction,P_L5ST_DSTD_1425 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5ST_DSTD_1425 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

                Guid errorID = Guid.NewGuid();
                ServerLog.Instance.Fatal("Application error occured. ErrorID = " + errorID, ex);
				throw new Exception("Exception occured in method cls_Delete_ShiftTemplateDetail",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Base cls_Delete_ShiftTemplateDetail(,P_L5ST_DSTD_1425 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Base invocationResult = cls_Delete_ShiftTemplateDetail.Invoke(connectionString,P_L5ST_DSTD_1425 Parameter,securityTicket);
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
var parameter = new CL5_Plannico_ShiftTimes.Atomic.Manipulation.P_L5ST_DSTD_1425();
parameter.CMN_PPS_ShiftTemplate_WorkDetailID = ...;

*/