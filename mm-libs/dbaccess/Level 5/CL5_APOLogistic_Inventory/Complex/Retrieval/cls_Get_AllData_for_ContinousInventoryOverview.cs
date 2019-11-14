/* 
 * Generated on 6/2/2014 1:42:24 PM
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

namespace CL5_APOLogistic_Inventory.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_AllData_for_ContinousInventoryOverview.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_AllData_for_ContinousInventoryOverview
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5IN_GADfCIO_1336_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5IN_GADfCIO_1336_Array();
			//Put your code here

            List<L5IN_GADfCIO_1336> retVal = new List<L5IN_GADfCIO_1336>(); 

            var inventorySeries = cls_Get_InventoryJobSeries_for_TenantID.Invoke(Connection, Transaction, securityTicket).Result;
            foreach (var item in inventorySeries)
            {
                L5IN_GADfCIO_1336 retItem = new L5IN_GADfCIO_1336();

                retItem.ArticlesToCount = item.ArticlesToCount;
                retItem.Creation_Timestamp = item.Creation_Timestamp;
                retItem.InventoryJobSeries_DisplayName = item.InventoryJobSeries_DisplayName;
                retItem.LOG_WRH_INJ_InventoryJob_SeriesID = item.LOG_WRH_INJ_InventoryJob_SeriesID;
                retItem.RythmCronExpression = item.RythmCronExpression;
                retItem.ShelfToCount = item.ShelfToCount;

                retVal.Add(retItem);
            }

            returnValue.Result = retVal.ToArray();

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5IN_GADfCIO_1336_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5IN_GADfCIO_1336_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5IN_GADfCIO_1336_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5IN_GADfCIO_1336_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5IN_GADfCIO_1336_Array functionReturn = new FR_L5IN_GADfCIO_1336_Array();
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

				throw new Exception("Exception occured in method cls_Get_AllData_for_ContinousInventoryOverview",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5IN_GADfCIO_1336_Array : FR_Base
	{
		public L5IN_GADfCIO_1336[] Result	{ get; set; } 
		public FR_L5IN_GADfCIO_1336_Array() : base() {}

		public FR_L5IN_GADfCIO_1336_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5IN_GADfCIO_1336 for attribute L5IN_GADfCIO_1336
		[DataContract]
		public class L5IN_GADfCIO_1336 
		{
			//Standard type parameters
			[DataMember]
			public Guid LOG_WRH_INJ_InventoryJob_SeriesID { get; set; } 
			[DataMember]
			public String InventoryJobSeries_DisplayName { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public String RythmCronExpression { get; set; } 
			[DataMember]
			public int ShelfToCount { get; set; } 
			[DataMember]
			public int ArticlesToCount { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5IN_GADfCIO_1336_Array cls_Get_AllData_for_ContinousInventoryOverview(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5IN_GADfCIO_1336_Array invocationResult = cls_Get_AllData_for_ContinousInventoryOverview.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

