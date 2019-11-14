/* 
 * Generated on 3/26/2014 11:46:17 AM
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
    /// var result = cls_Finish_CountingRun.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Finish_CountingRun
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5IN_FCR_1048 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            var countingRun = CL1_LOG_WRH_INJ.ORM_LOG_WRH_INJ_InventoryJob_CountingRun.Query.Search(Connection, Transaction,
                new CL1_LOG_WRH_INJ.ORM_LOG_WRH_INJ_InventoryJob_CountingRun.Query
                {
                    LOG_WRH_INJ_InventoryJob_CountingRunID = Parameter.CountingRunID,
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                }).Single();

            // Check if counting run is completed and has no differences in results
            if (!countingRun.IsCounting_Completed && ((countingRun.SequenceNumber == 1 && !countingRun.IsDifferenceFound) || countingRun.SequenceNumber == 2) )
            {
                countingRun.IsCounting_Completed = true;
                countingRun.Save(Connection, Transaction);

                //save counting process
                var countingProcess = CL1_LOG_WRH_INJ.ORM_LOG_WRH_INJ_InventoryJob_Process.Query.Search(Connection, Transaction,
                    new CL1_LOG_WRH_INJ.ORM_LOG_WRH_INJ_InventoryJob_Process.Query
                    {
                        LOG_WRH_INJ_InventoryJob_ProcessID = countingRun.InventoryJob_Process_RefID,
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID
                    }).SingleOrDefault();

                countingProcess.IsBookedIntoStock = true;

                countingProcess.Save(Connection, Transaction);
                countingRun.Save(Connection, Transaction);
            }

            #region Update Stock
            if (countingRun.SequenceNumber == 1 && countingRun.IsCounting_Completed == true)
            {
                var udParameter = new P_L5IN_UCRD_1140 { CountingRunID = countingRun.LOG_WRH_INJ_InventoryJob_CountingRunID };
                var updateDiffResult = cls_Update_CountingRun_Differences.Invoke(Connection, Transaction, udParameter, securityTicket);
            }
            else if (countingRun.SequenceNumber == 2)
            {
                var parameterGetCountingResult = new CL5_APOLogistic_Inventory.Atomic.Retrieval.P_L5IN_GCRfCR_1654
                {
                    CountingRunID = Parameter.CountingRunID,
                };

                var resultsWithDifferences = CL5_APOLogistic_Inventory.Atomic.Retrieval.cls_Get_CountingResults_for_CountingRun.Invoke(Connection, Transaction, parameterGetCountingResult, securityTicket).Result;

                foreach (var result in resultsWithDifferences)
                {
                    bool isTrackingInstance = result.LOG_WRH_INJ_CountingResult_TrackingInstanceID != Guid.Empty;
                    if (isTrackingInstance)
                    {
                        var ti = CL1_LOG.ORM_LOG_ProductTrackingInstance.Query.Search(Connection, Transaction,
                            new CL1_LOG.ORM_LOG_ProductTrackingInstance.Query
                            {
                                LOG_ProductTrackingInstanceID = result.LOG_ProductTrackingInstanceID,
                                IsDeleted = false,
                                Tenant_RefID = securityTicket.TenantID
                            }).Single();

                        ti.CurrentQuantityOnTrackingInstance = result.TrackingInstance_CountedAmount;
                        ti.Save(Connection, Transaction);
                    }
                    var shelfContent = CL1_LOG_WRH.ORM_LOG_WRH_Shelf_Content.Query.Search(Connection, Transaction,
                        new CL1_LOG_WRH.ORM_LOG_WRH_Shelf_Content.Query
                        {
                            LOG_WRH_Shelf_ContentID = result.LOG_WRH_Shelf_ContentID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        }).Single();

                    shelfContent.Quantity_Current = result.Shelf_CountedAmount;
                    shelfContent.Save(Connection, Transaction);
                }
            }
            #endregion Update Stock

            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5IN_FCR_1048 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5IN_FCR_1048 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5IN_FCR_1048 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5IN_FCR_1048 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Finish_CountingRun",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5IN_FCR_1048 for attribute P_L5IN_FCR_1048
		[DataContract]
		public class P_L5IN_FCR_1048 
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
FR_Guid cls_Finish_CountingRun(,P_L5IN_FCR_1048 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Finish_CountingRun.Invoke(connectionString,P_L5IN_FCR_1048 Parameter,securityTicket);
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
var parameter = new CL5_APOLogistic_Inventory.Complex.Manipulation.P_L5IN_FCR_1048();
parameter.CountingRunID = ...;

*/
