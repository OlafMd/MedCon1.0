/* 
 * Generated on 3/21/2014 4:05:41 PM
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

namespace CL5_APOLogistic_Inventory.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_InventoryProcess.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_InventoryProcess
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5IN_SIP_1804 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Guid();
			
            var previouslyAddedProcessShelves = new CL1_LOG_WRH_INJ.ORM_LOG_WRH_INJ_InventoryJob_Process_Shelf[0];
            
            var processID = Parameter.InventoryProcessID;
            if (processID != Guid.Empty)
            {
                #region Load previously added Process Shelves
                
                previouslyAddedProcessShelves = CL1_LOG_WRH_INJ.ORM_LOG_WRH_INJ_InventoryJob_Process_Shelf.Query.Search(Connection, Transaction,
                new CL1_LOG_WRH_INJ.ORM_LOG_WRH_INJ_InventoryJob_Process_Shelf.Query
                {
                    LOG_WRH_INJ_InventoryJob_Process_RefID = Parameter.InventoryProcessID,
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                }).ToArray();

                #endregion
            }
            else
            {
                #region Create new Inventory Process

                int processesCount = CL1_LOG_WRH_INJ.ORM_LOG_WRH_INJ_InventoryJob_Process.Query.Search(Connection, Transaction,
                    new CL1_LOG_WRH_INJ.ORM_LOG_WRH_INJ_InventoryJob_Process.Query
                    {
                        LOG_WRH_INJ_InventoryJob_RefID = Parameter.InventoryJobID,
                        Tenant_RefID = securityTicket.TenantID
                    }).Count();

                var process = new CL1_LOG_WRH_INJ.ORM_LOG_WRH_INJ_InventoryJob_Process
                {

                    LOG_WRH_INJ_InventoryJob_ProcessID = Guid.NewGuid(),
                    Creation_Timestamp = DateTime.Now,
                    Tenant_RefID = securityTicket.TenantID,
                    LOG_WRH_INJ_InventoryJob_RefID = Parameter.InventoryJobID,
                    SequenceNumber = processesCount + 1,
                    //BookedIntoStock_ByAccount_RefID = securityTicket.TenantID,
                    //BookedIntoStock_Date = DateTime.Now,
                    IsBookedIntoStock = false
                };
                process.Save(Connection, Transaction);
                processID = process.LOG_WRH_INJ_InventoryJob_ProcessID;

                #endregion

                #region Create counting run with Sequence Number 1

                CL1_LOG_WRH_INJ.ORM_LOG_WRH_INJ_InventoryJob_CountingRun countingRun = new CL1_LOG_WRH_INJ.ORM_LOG_WRH_INJ_InventoryJob_CountingRun();

                countingRun.LOG_WRH_INJ_InventoryJob_CountingRunID = Guid.NewGuid();
                countingRun.InventoryJob_Process_RefID = process.LOG_WRH_INJ_InventoryJob_ProcessID;
                countingRun.IsCounting_Completed = false;
                countingRun.IsCounting_Started = false;
                countingRun.IsCountingListPrinted = false;
                countingRun.IsDifferenceFound = false;
                countingRun.SequenceNumber = 1;
                countingRun.Tenant_RefID = securityTicket.TenantID;
                countingRun.Creation_Timestamp = DateTime.Now;
                countingRun.IsDeleted = false;
                countingRun.Save(Connection, Transaction);

                #endregion
            }
            
            #region Delete removed deselected
            // TODO: make cross between previosly added shelves and those one that are given through Parameter's array member
            var previouslyAddedShelvesIDs = previouslyAddedProcessShelves.Select(x => x.LOG_WRH_Shelf_RefID).ToArray();
            var intersected = previouslyAddedShelvesIDs.Intersect(Parameter.CheckedShelves);
            var shelvesForDeletion = previouslyAddedShelvesIDs.Except(intersected);
            var newShelves = Parameter.CheckedShelves.Except(intersected);

            if (shelvesForDeletion.Count() != 0)
            {    
                foreach (var shelfID in shelvesForDeletion)
                {
                    var processShelf = previouslyAddedProcessShelves.Single(x => x.LOG_WRH_Shelf_RefID == shelfID);
                    processShelf.IsDeleted = true;
                    processShelf.Save(Connection, Transaction);
                }
            }
            #endregion

            #region Create new process-shelf entries

            foreach (var newShelfID in newShelves)
            {
                var processShelf = new CL1_LOG_WRH_INJ.ORM_LOG_WRH_INJ_InventoryJob_Process_Shelf
                {
                    LOG_WRH_INJ_InventoryJob_Process_ShelfID = Guid.NewGuid(),
                    Creation_Timestamp = DateTime.Now,
                    Tenant_RefID = securityTicket.TenantID,
                    LOG_WRH_INJ_InventoryJob_Process_RefID = processID,
                    LOG_WRH_Shelf_RefID = newShelfID,
                };
                processShelf.Save(Connection, Transaction);
            }
            #endregion
            
            
            returnValue.Result = processID;

            //CL1_LOG_WRH_INJ.ORM_LOG_WRH_INJ_InventoryJob_Process_ShelfContent

            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5IN_SIP_1804 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5IN_SIP_1804 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5IN_SIP_1804 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5IN_SIP_1804 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_InventoryProcess",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5IN_SIP_1804 for attribute P_L5IN_SIP_1804
		[DataContract]
		public class P_L5IN_SIP_1804 
		{
			//Standard type parameters
			[DataMember]
			public Guid InventoryJobID { get; set; } 
			[DataMember]
			public Guid InventoryProcessID { get; set; } 
			[DataMember]
			public Guid[] CheckedShelves { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_InventoryProcess(,P_L5IN_SIP_1804 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_InventoryProcess.Invoke(connectionString,P_L5IN_SIP_1804 Parameter,securityTicket);
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
var parameter = new CL5_APOLogistic_Inventory.Complex.Manipulation.P_L5IN_SIP_1804();
parameter.InventoryJobID = ...;
parameter.InventoryProcessID = ...;
parameter.CheckedShelves = ...;

*/
