/* 
 * Generated on 1/21/2014 3:45:41 PM
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
using CL5_VacationPlanner_Tenant.Atomic.Retrieval;
using CL1_CMN_CAL;
using PlannicoModel.Models;

namespace CL5_VacationPlanner_Tenant.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Check_TimeFrames.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Check_TimeFrames
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Guid();

            L5TN_GCTFFT_1529[] timeFrames=cls_Get_CalculationTimeFramesForTenant.Invoke(Connection,Transaction,securityTicket).Result;
            List<int> allYears=new List<int>();
            foreach(var timeFrame in timeFrames){
                if(!allYears.Contains(timeFrame.CalculationTimeframe_StartDate.Year))
                    allYears.Add(timeFrame.CalculationTimeframe_StartDate.Year);
            }

            foreach(var year in allYears){
                if(timeFrames.Count(i=>i.CalculationTimeframe_StartDate.Year==year)>1){
                    List<L5TN_GCTFFT_1529> problematicFrames=timeFrames.Where(i=>i.CalculationTimeframe_StartDate.Year==year).ToList();
                    DateTime validFrame=problematicFrames.Min(i=>i.Creation_Timestamp);
                    foreach (var frame in problematicFrames.Where(i => i.Creation_Timestamp != validFrame))
                    {
                        ORM_CMN_CAL_CalculationTimeframe timeFrame = new ORM_CMN_CAL_CalculationTimeframe();
                        timeFrame.Load(Connection, Transaction, frame.CMN_CAL_CalculationTimeframeID);
                        timeFrame.Remove(Connection, Transaction);
                    }

                    L5TN_GCTFFT_1529 activeFrame = problematicFrames.Where(i => i.Creation_Timestamp != validFrame).First();
                    ORM_CMN_CAL_CalculationTimeframe validTimeFrame = new ORM_CMN_CAL_CalculationTimeframe();
                    validTimeFrame.Load(Connection, Transaction, activeFrame.CMN_CAL_CalculationTimeframeID);
                    validTimeFrame.IsCalculationTimeframe_Active = true;
                    validTimeFrame.Save(Connection, Transaction);
                }
            }

            bool hasActive = timeFrames.Any(i => i.IsCalculationTimeframe_Active);
            if (!hasActive)
            {
                if (timeFrames.Any(i => i.CalculationTimeframe_StartDate.Year == DateTime.Now.Year))
                {
                    L5TN_GCTFFT_1529 timeFrame = timeFrames.First(i => i.CalculationTimeframe_StartDate.Year == DateTime.Now.Year);
                    ORM_CMN_CAL_CalculationTimeframe validTimeFrame = new ORM_CMN_CAL_CalculationTimeframe();
                    validTimeFrame.Load(Connection, Transaction, timeFrame.CMN_CAL_CalculationTimeframeID);
                    validTimeFrame.IsCalculationTimeframe_Active = true;
                    validTimeFrame.Save(Connection, Transaction);
                }
                else
                {
                    ORM_CMN_CAL_CalculationTimeframe validTimeFrame = new ORM_CMN_CAL_CalculationTimeframe();
                    validTimeFrame.CalculationTimeframe_StartDate = new DateTime(DateTime.Now.Year, 1, 1);
                    validTimeFrame.CalculationTimeframe_EstimatedEndDate = new DateTime(DateTime.Now.Year, 12, 31);
                    validTimeFrame.IsCalculationTimeframe_Active = true;
                    validTimeFrame.Save(Connection, Transaction);
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
		public static FR_Guid Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				functionReturn = Execute(Connection, Transaction,securityTicket);

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

				throw new Exception("Exception occured in method cls_Check_TimeFrames",ex);
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
FR_Guid cls_Check_TimeFrames(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Check_TimeFrames.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/
