/* 
 * Generated on 7/29/2014 2:46:39 PM
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
using CL5_APOLogistic_Inventory.Atomic.Retrieval;
using CL5_APOLogistic_Inventory.Utils;

namespace CL5_APOLogistic_Inventory.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_AllData_for_FullInventoryPage.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_AllData_for_FullInventoryPage
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5IN_GADfFIP_1417 Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5IN_GADfFIP_1417();
			//Put your code here
            var inventoryJobs = cls_Get_InventoryJobs_for_TenantID.Invoke(Connection, Transaction, securityTicket).Result;
            
            var countedShelf = cls_Get_CountedShelfContent_for_TenantID.Invoke(Connection, Transaction, securityTicket).Result;
            var totalShelf = cls_Get_TotalShelfContent_for_TenantID.Invoke(Connection, Transaction, securityTicket).Result;

            returnValue.Result = new L5IN_GADfFIP_1417();

            List<L5IN_GADfFIP_1417a> returnList = new List<L5IN_GADfFIP_1417a>();

            foreach (var job in inventoryJobs)
            {
                L5IN_GADfFIP_1417a returnItem = new L5IN_GADfFIP_1417a();
                returnItem.InvetoryJob = job;
                var temp = countedShelf.Where(x => x.LOG_WRH_INJ_InventoryJob_RefID == job.LOG_WRH_INJ_InventoryJobID).SingleOrDefault();
                if (temp != null)
                {
                    returnItem.TotalShelf = totalShelf.Where(x => x.LOG_WRH_INJ_InventoryJob_RefID == job.LOG_WRH_INJ_InventoryJobID).SingleOrDefault().TotalCount;
                    returnItem.CountedShelf = temp.CountedShelfContentForInventory;
                    returnItem.Percentage = MathUtil.CountProcent(returnItem.CountedShelf, returnItem.TotalShelf);
                }
                else
                {
                    returnItem.TotalShelf = 0;
                    returnItem.CountedShelf = 0;
                    returnItem.Percentage = 0;
                }

                returnList.Add(returnItem);
            }

            returnValue.Result.Jobs = returnList.ToArray();
			return returnValue;
			#endregion UserCode
		}

		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5IN_GADfFIP_1417 Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5IN_GADfFIP_1417 Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5IN_GADfFIP_1417 Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5IN_GADfFIP_1417 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5IN_GADfFIP_1417 functionReturn = new FR_L5IN_GADfFIP_1417();
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

				throw new Exception("Exception occured in method cls_Get_AllData_for_FullInventoryPage",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5IN_GADfFIP_1417 : FR_Base
	{
		public L5IN_GADfFIP_1417 Result	{ get; set; }

		public FR_L5IN_GADfFIP_1417() : base() {}

		public FR_L5IN_GADfFIP_1417(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5IN_GADfFIP_1417 for attribute L5IN_GADfFIP_1417
		[DataContract]
		public class L5IN_GADfFIP_1417 
		{
			[DataMember]
			public L5IN_GADfFIP_1417a[] Jobs { get; set; }

			//Standard type parameters
		}
		#endregion
		#region SClass L5IN_GADfFIP_1417a for attribute Jobs
		[DataContract]
		public class L5IN_GADfFIP_1417a 
		{
			//Standard type parameters
			[DataMember]
			public CL5I_GIJfT_1413 InvetoryJob { get; set; } 
			[DataMember]
			public int TotalShelf { get; set; } 
			[DataMember]
			public int CountedShelf { get; set; } 
			[DataMember]
			public int Percentage { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5IN_GADfFIP_1417 cls_Get_AllData_for_FullInventoryPage(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5IN_GADfFIP_1417 invocationResult = cls_Get_AllData_for_FullInventoryPage.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

