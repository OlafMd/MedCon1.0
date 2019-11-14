/* 
 * Generated on 20-Jun-14 13:48:27
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
using PlannicoModel.Models;
using CL1_CMN_CAL;

namespace CL5_VacationPlanner_Tenant.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_CalculationTimeFramesForTenant_And_Year.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_CalculationTimeFramesForTenant_And_Year
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5TN_GCTFFTAY_1320 Execute(DbConnection Connection,DbTransaction Transaction,P_L5TN_GCTFFTAY_1320 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5TN_GCTFFTAY_1320();
			//Put your code here

            ORM_CMN_CAL_CalculationTimeframe.Query calcTimeFrameQuery = new ORM_CMN_CAL_CalculationTimeframe.Query();
            calcTimeFrameQuery.Tenant_RefID = securityTicket.TenantID;
            calcTimeFrameQuery.IsDeleted = false;

            var calcTimeFrame = ORM_CMN_CAL_CalculationTimeframe.Query.Search(Connection, Transaction, calcTimeFrameQuery).FirstOrDefault(x => x.CalculationTimeframe_StartDate.Year == Parameter.Year);

            returnValue.Result = new L5TN_GCTFFTAY_1320();

            L5TN_GCTFFT_1529 result = new L5TN_GCTFFT_1529();


            if (calcTimeFrame == null)
            {
                ORM_CMN_CAL_CalculationTimeframe newCalcTimeframe = new ORM_CMN_CAL_CalculationTimeframe();
                newCalcTimeframe.CalculationTimeframe_StartDate = new DateTime(Parameter.Year, 1, 1);
                newCalcTimeframe.CalculationTimeframe_EstimatedEndDate = new DateTime(Parameter.Year, 12, 31);
                newCalcTimeframe.IsCalculationTimeframe_Active = false;
                newCalcTimeframe.Tenant_RefID = securityTicket.TenantID;
                newCalcTimeframe.Save(Connection, Transaction);

                result.CalculationTimeframe_EstimatedEndDate = newCalcTimeframe.CalculationTimeframe_EstimatedEndDate;
                result.CalculationTimeframe_StartDate = newCalcTimeframe.CalculationTimeframe_StartDate;
                result.CalculationTimefrate_EndDate = newCalcTimeframe.CalculationTimefrate_EndDate;
                result.CMN_CAL_CalculationTimeframeID = newCalcTimeframe.CMN_CAL_CalculationTimeframeID;
                result.Creation_Timestamp = newCalcTimeframe.Creation_Timestamp;
                result.IsCalculationTimeframe_Active = newCalcTimeframe.IsCalculationTimeframe_Active;
            }
            else
            {
                result.CalculationTimeframe_EstimatedEndDate = calcTimeFrame.CalculationTimeframe_EstimatedEndDate;
                result.CalculationTimeframe_StartDate = calcTimeFrame.CalculationTimeframe_StartDate;
                result.CalculationTimefrate_EndDate = calcTimeFrame.CalculationTimefrate_EndDate;
                result.CMN_CAL_CalculationTimeframeID = calcTimeFrame.CMN_CAL_CalculationTimeframeID;
                result.Creation_Timestamp = calcTimeFrame.Creation_Timestamp;
                result.IsCalculationTimeframe_Active = calcTimeFrame.IsCalculationTimeframe_Active;
            }

            returnValue.Result.CalculationTimeFrame = result;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5TN_GCTFFTAY_1320 Invoke(string ConnectionString,P_L5TN_GCTFFTAY_1320 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5TN_GCTFFTAY_1320 Invoke(DbConnection Connection,P_L5TN_GCTFFTAY_1320 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5TN_GCTFFTAY_1320 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5TN_GCTFFTAY_1320 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5TN_GCTFFTAY_1320 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5TN_GCTFFTAY_1320 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5TN_GCTFFTAY_1320 functionReturn = new FR_L5TN_GCTFFTAY_1320();
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

	#region Custom Return Type
	[Serializable]
	public class FR_L5TN_GCTFFTAY_1320 : FR_Base
	{
		public L5TN_GCTFFTAY_1320 Result	{ get; set; }

		public FR_L5TN_GCTFFTAY_1320() : base() {}

		public FR_L5TN_GCTFFTAY_1320(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes		

	#endregion
}
