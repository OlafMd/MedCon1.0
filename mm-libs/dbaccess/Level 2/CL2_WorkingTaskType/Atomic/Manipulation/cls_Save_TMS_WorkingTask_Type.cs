/* 
 * Generated on 10/10/2014 10:42:17 AM
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
namespace CL2_WorkingTaskType.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_TMS_WorkingTask_Type.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_TMS_WorkingTask_Type
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L2WTT_SWTT_1313 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
            var item = new CL1_TMS.ORM_TMS_QuickTask_Type();
            if (Parameter.TMS_WorkingTaskTypeID!= Guid.Empty)
            {
                var result = item.Load(Connection, Transaction, Parameter.TMS_WorkingTaskTypeID);
                if (result.Status != FR_Status.Success || item.TMS_QuickTask_TypeID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }

            if (Parameter.IsDeleted == true || Parameter.IfDeleteReplaceWith != Guid.Empty)
            {

                CL1_TMS.ORM_TMS_QuickTask.Query searchQuery = new CL1_TMS.ORM_TMS_QuickTask.Query();
                searchQuery.QuickTask_Type_RefID = Parameter.TMS_WorkingTaskTypeID;

                CL1_TMS.ORM_TMS_QuickTask.Query updateQuery = new CL1_TMS.ORM_TMS_QuickTask.Query();
                updateQuery.QuickTask_Type_RefID = Parameter.IfDeleteReplaceWith;

                CL1_TMS.ORM_TMS_QuickTask.Query.Update(Connection, Transaction, searchQuery, updateQuery);

                item.IsDeleted = true;
                item.Save(Connection, Transaction);
                return new FR_Guid(item.TMS_QuickTask_TypeID);
            }

            //Creation specific parameters (Tenant, Account ... )
            if (Parameter.TMS_WorkingTaskTypeID == Guid.Empty)
            {
                item.Tenant_RefID = securityTicket.TenantID;
                item.IsPersistent = true;
            }

            item.QuickTaskType_Name = Parameter.QuickTaskType_Name;
            item.IsDeleted = Parameter.IsDeleted;
            return new FR_Guid(item.Save(Connection, Transaction), item.TMS_QuickTask_TypeID);
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L2WTT_SWTT_1313 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L2WTT_SWTT_1313 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L2WTT_SWTT_1313 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2WTT_SWTT_1313 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_TMS_WorkingTask_Type",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L2WTT_SWTT_1313 for attribute P_L2WTT_SWTT_1313
		[DataContract]
		public class P_L2WTT_SWTT_1313 
		{
			//Standard type parameters
			[DataMember]
			public Guid TMS_WorkingTaskTypeID { get; set; } 
			[DataMember]
			public String QuickTaskTupe_ExternalID { get; set; } 
			[DataMember]
			public Dict QuickTaskType_Description { get; set; } 
			[DataMember]
			public Dict QuickTaskType_Name { get; set; } 
			[DataMember]
			public Boolean IsPersistent { get; set; } 
			[DataMember]
			public Guid IfDeleteReplaceWith { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 
			[DataMember]
			public String GlobalPropertyMatchingID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_TMS_WorkingTask_Type(,P_L2WTT_SWTT_1313 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_TMS_WorkingTask_Type.Invoke(connectionString,P_L2WTT_SWTT_1313 Parameter,securityTicket);
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
var parameter = new CL2_WorkingTaskType.Atomic.Manipulation.P_L2WTT_SWTT_1313();
parameter.TMS_WorkingTaskTypeID = ...;
parameter.QuickTaskTupe_ExternalID = ...;
parameter.QuickTaskType_Description = ...;
parameter.QuickTaskType_Name = ...;
parameter.IsPersistent = ...;
parameter.IfDeleteReplaceWith = ...;
parameter.Creation_Timestamp = ...;
parameter.IsDeleted = ...;
parameter.GlobalPropertyMatchingID = ...;

*/
