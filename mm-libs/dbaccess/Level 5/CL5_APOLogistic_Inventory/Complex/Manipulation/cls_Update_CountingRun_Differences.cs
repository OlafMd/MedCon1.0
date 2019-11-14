/* 
 * Generated on 21/3/2014 01:58:19
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
using CL5_APOLogistic_Inventory.Complex.Retrieval;

namespace CL5_APOLogistic_Inventory.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Update_CountingRun_Differences.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Update_CountingRun_Differences
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Bool Execute(DbConnection Connection,DbTransaction Transaction,P_L5IN_UCRD_1140 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            // Get current counting run
            var countingRun = new CL1_LOG_WRH_INJ.ORM_LOG_WRH_INJ_InventoryJob_CountingRun();
            countingRun.Load(Connection, Transaction, Parameter.CountingRunID);

            // Check is current counting run valid
            if( countingRun == null ||
                countingRun.IsDeleted ||
                countingRun.LOG_WRH_INJ_InventoryJob_CountingRunID == Guid.Empty)
            {
                throw new Exception("Bad parameter CountingRunID.");
            }

            // Get counting result values for current counting run
            var parameterGetCountingResult = new CL5_APOLogistic_Inventory.Atomic.Retrieval.P_L5IN_GCRfCR_1654
            {
                CountingRunID = Parameter.CountingRunID
            };

            var countingResultAndTrackingInstanceValues = CL5_APOLogistic_Inventory.Atomic.Retrieval.cls_Get_CountingResults_for_CountingRun.Invoke(Connection, Transaction, parameterGetCountingResult, securityTicket).Result;
            
            #region Check Counting Results
            // Check values
            bool updateCountingRuns = false;
            foreach (var item in countingResultAndTrackingInstanceValues)
            {
                // Check Tracking Instance
                if (item.LOG_WRH_INJ_CountingResult_TrackingInstanceID != Guid.Empty)
                {
                    if (item.TrackingInstance_CountedAmount != item.TrackingInstance_CurrentQuantity)
                    {
                        var trackingInstance = new CL1_LOG_WRH_INJ.ORM_LOG_WRH_INJ_CountingResult_TrackingInstance();
                        trackingInstance.Load(Connection, Transaction, item.LOG_WRH_INJ_CountingResult_TrackingInstanceID);
                        trackingInstance.IsDifferenceToExpectedQuantityFound = true;
                        trackingInstance.Save(Connection, Transaction);
                        updateCountingRuns = true;
                    }
                }

                // Check Shelf counting result
                if (item.LOG_WRH_INJ_InventoryJob_CountingResultID != Guid.Empty)
                {
                    if (item.Shelf_CountedAmount != item.Shelf_CurrentQuantity)
                    {
                        var countingResult = new CL1_LOG_WRH_INJ.ORM_LOG_WRH_INJ_InventryJob_CountingResult();
                        countingResult.Load(Connection, Transaction, item.LOG_WRH_INJ_InventoryJob_CountingResultID);
                        countingResult.IsDifferenceToExpectedQuantityFound = true;
                        countingResult.Save(Connection, Transaction);
                        updateCountingRuns = true;
                    }
                }
            }
            #endregion

            #region Counting Run Manage

            if (updateCountingRuns)
            {
                // Create new counting run
                var nextCountingRun = new CL1_LOG_WRH_INJ.ORM_LOG_WRH_INJ_InventoryJob_CountingRun();
                nextCountingRun.ExecutingBusinessParticipant_RefID = countingRun.ExecutingBusinessParticipant_RefID;
                nextCountingRun.InventoryJob_Process_RefID = countingRun.InventoryJob_Process_RefID;
                nextCountingRun.SequenceNumber = 2;
                nextCountingRun.Tenant_RefID = securityTicket.TenantID;
                nextCountingRun.Save(Connection, Transaction);

                countingRun.IsDifferenceFound = true;
                countingRun.Save(Connection, Transaction);
            }

            countingRun.IsCounting_Completed = true;
            countingRun.Save(Connection, Transaction);

            #endregion

            return new FR_Bool { Result = true };
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Bool Invoke(string ConnectionString,P_L5IN_UCRD_1140 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection,P_L5IN_UCRD_1140 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction,P_L5IN_UCRD_1140 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5IN_UCRD_1140 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Bool functionReturn = new FR_Bool();
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

				throw new Exception("Exception occured in method cls_Update_CountingRun_Differences",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5IN_UCRD_1140 for attribute P_L5IN_UCRD_1140
		[DataContract]
		public class P_L5IN_UCRD_1140 
		{
			//Standard type parameters
			[DataMember]
			public Guid CountingRunID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Bool cls_Update_CountingRun_Differences(,P_L5IN_UCRD_1140 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Bool invocationResult = cls_Update_CountingRun_Differences.Invoke(connectionString,P_L5IN_UCRD_1140 Parameter,securityTicket);
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
var parameter = new CL5_APOLogistic_Inventory.Complex.Manipulation.P_L5IN_UCRD_1140();
parameter.CountingRunID = ...;

*/
