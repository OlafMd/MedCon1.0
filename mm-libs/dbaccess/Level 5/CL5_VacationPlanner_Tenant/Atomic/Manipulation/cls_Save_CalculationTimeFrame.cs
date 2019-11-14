/* 
 * Generated on 8/26/2013 2:27:49 PM
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
using CL1_CMN_CAL;
using PlannicoModel.Models;

namespace CL5_VacationPlanner_Tenant.Atomic.Manipulation
{
	/// <summary>
    /// No description found in <meta/> tag
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_CalculationTimeFrame.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_CalculationTimeFrame
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5TN_SCTF_1041 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here


            if (Parameter.IsCalculationTimeframe_Active)
            {
                ORM_CMN_CAL_CalculationTimeframe.Query query = new ORM_CMN_CAL_CalculationTimeframe.Query();
                query.Tenant_RefID = securityTicket.TenantID;
                ORM_CMN_CAL_CalculationTimeframe.Query values = new ORM_CMN_CAL_CalculationTimeframe.Query();
                values.IsCalculationTimeframe_Active = false;
                ORM_CMN_CAL_CalculationTimeframe.Query.Update(Connection, Transaction, query, values);
            }
            ORM_CMN_CAL_CalculationTimeframe timeFrame = new ORM_CMN_CAL_CalculationTimeframe();
            if (Parameter.CMN_CAL_CalculationTimeframeID != Guid.Empty)
            {
                var result = timeFrame.Load(Connection, Transaction, Parameter.CMN_CAL_CalculationTimeframeID);
                if (result.Status != FR_Status.Success || timeFrame.CMN_CAL_CalculationTimeframeID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }

            timeFrame.CalculationTimeframe_EstimatedEndDate = Parameter.CalculationTimeframe_EstimatedEndDate;
            timeFrame.CalculationTimeframe_StartDate = Parameter.CalculationTimeframe_StartDate;
            timeFrame.CalculationTimefrate_EndDate = Parameter.CalculationTimefrate_EndDate;
            timeFrame.IsCalculationTimeframe_Active = Parameter.IsCalculationTimeframe_Active;
            timeFrame.Tenant_RefID = securityTicket.TenantID;
            timeFrame.Save(Connection, Transaction);
            returnValue.Result = timeFrame.CMN_CAL_CalculationTimeframeID;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5TN_SCTF_1041 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5TN_SCTF_1041 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5TN_SCTF_1041 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5TN_SCTF_1041 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_CalculationTimeFrame(P_L5TN_SCTF_1041 Parameter,string sessionToken = null)
{
	 var securityTicket = ...;
	 FR_Guid result = cls_Save_CalculationTimeFrame.Invoke(connectionString,P_L5TN_SCTF_1041 Parameter,securityTicket);
	 return result;
}
*/