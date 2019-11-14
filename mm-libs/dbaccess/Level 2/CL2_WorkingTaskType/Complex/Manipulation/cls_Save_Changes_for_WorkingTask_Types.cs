/* 
 * Generated on 11/11/2014 12:53:43 PM
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
using CL1_TMS;
using CL2_WorkingTaskType.Atomic.Manipulation;

namespace CL2_WorkingTaskType.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Changes_for_WorkingTask_Types.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Changes_for_WorkingTask_Types
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L2WTT_SCfWTT_1703 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here
            var item = new ORM_TMS_QuickTask_Type();
            foreach (var workingTaskTypeID in Parameter.Working_Task_Types_IDs)
            {
                P_L2WTT_SWTT_1313 deleteWorkingTaskTypeParameter = new P_L2WTT_SWTT_1313();
                deleteWorkingTaskTypeParameter.TMS_WorkingTaskTypeID = Guid.Parse (workingTaskTypeID);
                deleteWorkingTaskTypeParameter.IsDeleted = true;
                deleteWorkingTaskTypeParameter.IfDeleteReplaceWith = Parameter.ReplaceWith;
                cls_Save_TMS_WorkingTask_Type.Invoke(Connection, Transaction, deleteWorkingTaskTypeParameter);

                //if(workingTaskTypeID!=null && workingTaskTypeID!=Guid.Empty.ToString() && workingTaskTypeID!="" )
                //{
                //    item = ORM_TMS_QuickTask_Type.Query.Search(Connection, Transaction, new ORM_TMS_QuickTask_Type.Query()
                //    {
                //        Tenant_RefID = securityTicket.TenantID,
                //        IsDeleted = false,
                //        TMS_QuickTask_TypeID=Guid.Parse(workingTaskTypeID)
                //    }).Single();
                //    item.IsDeleted = true;
                //    item.Save(Connection, Transaction);
                //}
            }
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L2WTT_SCfWTT_1703 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L2WTT_SCfWTT_1703 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L2WTT_SCfWTT_1703 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2WTT_SCfWTT_1703 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Changes_for_WorkingTask_Types",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L2WTT_SCfWTT_1703 for attribute P_L2WTT_SCfWTT_1703
		[DataContract]
		public class P_L2WTT_SCfWTT_1703 
		{
			//Standard type parameters
			[DataMember]
			public String[] Working_Task_Types_IDs { get; set; } 
			[DataMember]
			public Guid ReplaceWith { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Changes_for_WorkingTask_Types(,P_L2WTT_SCfWTT_1703 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Changes_for_WorkingTask_Types.Invoke(connectionString,P_L2WTT_SCfWTT_1703 Parameter,securityTicket);
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
var parameter = new CL2_WorkingTaskType.Complex.Manipulation.P_L2WTT_SCfWTT_1703();
parameter.Working_Task_Types_IDs = ...;
parameter.ReplaceWith = ...;

*/
