/* 
 * Generated on 03-Dec-14 4:45:49 PM
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

namespace CL3_DeveloperTask.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_TMS_PRO_Peers_Development.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_TMS_PRO_Peers_Development
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Bool Execute(DbConnection Connection,DbTransaction Transaction,P_L3DT_SPDT_1644 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Bool();
			//Put your code here


            foreach (P_L3DT_SPDT_1644a asgn in Parameter.Assignments)
            {
                var item = new CL1_TMS_PRO.ORM_TMS_PRO_Peers_Development();

                if (asgn.AssignmentID != Guid.Empty)
                {
                    var result = item.Load(Connection, Transaction, asgn.AssignmentID);
                    if (result.Status != FR_Status.Success || item.AssignmentID == Guid.Empty)
                    {
                        var error = new FR_Bool(false);
                        error.ErrorMessage = "No Such ID";
                        error.Status = FR_Status.Error_Internal;
                        return error;
                    }
                }

                if (asgn.IsDeleted == true)
                {
                    item.IsDeleted = true;
                }

                //Creation specific parameters (Tenant, Account ... )
                if (asgn.AssignmentID == Guid.Empty)
                {
                    item.Tenant_RefID = securityTicket.TenantID;
                    item.ProjectMember_RefID = Parameter.AssignedBy_ProjectMemberID;
                }

                item.DeveloperTask_RefID = Parameter.DeveloperTask_RefID;

                item.ProjectMember_RefID = asgn.ProjectMember_RefID;

                item.Save(Connection, Transaction);



            }




			returnValue.Result = true;
            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Bool Invoke(string ConnectionString,P_L3DT_SPDT_1644 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection,P_L3DT_SPDT_1644 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction,P_L3DT_SPDT_1644 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3DT_SPDT_1644 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_TMS_PRO_Peers_Development",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3DT_SPDT_1644 for attribute P_L3DT_SPDT_1644
		[DataContract]
		public class P_L3DT_SPDT_1644 
		{
			[DataMember]
			public P_L3DT_SPDT_1644a[] Assignments { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid DeveloperTask_RefID { get; set; } 
			[DataMember]
			public Guid AssignedBy_ProjectMemberID { get; set; } 

		}
		#endregion
		#region SClass P_L3DT_SPDT_1644a for attribute Assignments
		[DataContract]
		public class P_L3DT_SPDT_1644a 
		{
			//Standard type parameters
			[DataMember]
			public Guid AssignmentID { get; set; } 
			[DataMember]
			public Guid ProjectMember_RefID { get; set; } 
			[DataMember]
			public String Comment { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Bool cls_Save_TMS_PRO_Peers_Development(,P_L3DT_SPDT_1644 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Bool invocationResult = cls_Save_TMS_PRO_Peers_Development.Invoke(connectionString,P_L3DT_SPDT_1644 Parameter,securityTicket);
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
var parameter = new CL3_DeveloperTask.Atomic.Manipulation.P_L3DT_SPDT_1644();
parameter.Assignments = ...;

parameter.DeveloperTask_RefID = ...;
parameter.AssignedBy_ProjectMemberID = ...;

*/
