/* 
 * Generated on 7/9/2014 10:50:50 AM
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
using CL2_BusinessTask.Atomic.Retrieval;
using CL2_Feature.Atomic.Retrieval;
using CL2_DeveloperTask.Atomic.Retrieval;
using CL2_RightsPackage.Atomic.Retrieval;
using CL2_Right.Atomic.Retrieval;
using CL2_Project.Atomic.Retrieval;

namespace CL6_DanuTask_User.Complex.Retrieval
{
	/// <summary>
    /// 
    
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_UserAccountPreloadingData_for_ActiveUser_and_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_UserAccountPreloadingData_for_ActiveUser_and_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6US_GUAPDfAUaT_1547 Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_L6US_GUAPDfAUaT_1547();
			//Put your code here
            returnValue.Result = new L6US_GUAPDfAUaT_1547();

            #region ProjectSpecific

            returnValue.Result.Project_Statuses = cls_Get_ProjectStatuses_for_Tenant.Invoke(Connection, Transaction, securityTicket).Result;

            #endregion

            #region BusinessTaskSpecific

            returnValue.Result.BusinessTask_Statuses = cls_Get_BusinessTaskStatuses_for_Tenant.Invoke(Connection, Transaction, securityTicket).Result;

            #endregion

            #region FeatureSpecific

            returnValue.Result.Feature_Statuses = cls_Get_FeatureStatuses_for_Tenant.Invoke(Connection, Transaction, securityTicket).Result;

            #endregion

            #region DeveloperTaskSpecific

            returnValue.Result.DeveloperTask_Statuses = cls_Get_DeveloperTaskStatuses_for_Tenant.Invoke(Connection, Transaction, securityTicket).Result; 

            #endregion

            #region RightsMappings

            returnValue.Result.RightsPackages = cls_Get_RightsPackages_for_Tenant.Invoke(Connection, Transaction, securityTicket).Result;

            #endregion

            #region Rights

            returnValue.Result.Rights = cls_Get_Rights_for_Tenant.Invoke(Connection, Transaction, securityTicket).Result;

            #endregion


            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6US_GUAPDfAUaT_1547 Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6US_GUAPDfAUaT_1547 Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6US_GUAPDfAUaT_1547 Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6US_GUAPDfAUaT_1547 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6US_GUAPDfAUaT_1547 functionReturn = new FR_L6US_GUAPDfAUaT_1547();
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

				throw new Exception("Exception occured in method cls_Get_UserAccountPreloadingData_for_ActiveUser_and_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6US_GUAPDfAUaT_1547 : FR_Base
	{
		public L6US_GUAPDfAUaT_1547 Result	{ get; set; }

		public FR_L6US_GUAPDfAUaT_1547() : base() {}

		public FR_L6US_GUAPDfAUaT_1547(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L6US_GUAPDfAUaT_1547 for attribute L6US_GUAPDfAUaT_1547
		[DataContract]
		public class L6US_GUAPDfAUaT_1547 
		{
			//Standard type parameters
			[DataMember]
			public L2PR_GPSfT_1511[] Project_Statuses { get; set; } 
			[DataMember]
			public L2BT_GBTSfT_1549[] BusinessTask_Statuses { get; set; } 
			[DataMember]
			public L2FE_GFSfT_1602[] Feature_Statuses { get; set; } 
			[DataMember]
			public L2DT_GDTSfT_1120[] DeveloperTask_Statuses { get; set; } 
			[DataMember]
			public L2RP_GRPfT_1223[] RightsPackages { get; set; } 
			[DataMember]
			public L2RT_GRfT_1757[] Rights { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6US_GUAPDfAUaT_1547 cls_Get_UserAccountPreloadingData_for_ActiveUser_and_Tenant(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6US_GUAPDfAUaT_1547 invocationResult = cls_Get_UserAccountPreloadingData_for_ActiveUser_and_Tenant.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

