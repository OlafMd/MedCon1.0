/* 
 * Generated on 11/25/2014 9:45:58 AM
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
using CL3_Project.Complex.Manipulation;
using CL2_Project.Atomic.Manipulation;

namespace CL3_Project.Complex.Manipulation
{
	/// <summary>
    /// 
    
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Projects.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Projects
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L2PR_SP_1040 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here
            if (Parameter.ArchiveOrDelete == "Delete")
            {
                foreach (var projectID in Parameter.Project_IDs_to_Save)
                {
                    P_L3SPFT_SPN_1100 projectParameter = new P_L3SPFT_SPN_1100();
                    projectParameter.IsDeleted = true;
                    projectParameter.TMS_PRO_ProjectID = Guid.Parse(projectID);
                    cls_Save_Admin_Project_for_Tenant.Invoke(Connection, Transaction, projectParameter, securityTicket);
                }
            }
            else if (Parameter.ArchiveOrDelete == "Archive")
            {
                foreach (var projectID in Parameter.Project_IDs_to_Save)
                {
                    P_L3SPFT_SPN_1100 projectParameter = new P_L3SPFT_SPN_1100();
                    projectParameter.IsArchived = true;
                    projectParameter.TMS_PRO_ProjectID = Guid.Parse(projectID);
                    cls_Save_Admin_Project_for_Tenant.Invoke(Connection, Transaction, projectParameter, securityTicket);
                }
            }

            else if (Parameter.ArchiveOrDelete == "Unarchive")
            {
                foreach (var projectID in Parameter.Project_IDs_to_Save)
                {
                    P_L2PR_UPfPID_1438 parameter = new P_L2PR_UPfPID_1438();
                    parameter.TMS_PRO_ProjectID = Guid.Parse(projectID);

                    cls_Unarchive_Project_for_ProjectID.Invoke(Connection, Transaction, parameter, securityTicket);

                    //P_L3SPFT_SPN_1100 projectParameter = new P_L3SPFT_SPN_1100();
                    //projectParameter.IsArchived = false;
                    //projectParameter.TMS_PRO_ProjectID = Guid.Parse(projectID);
                    //cls_Save_Admin_Project_for_Tenant.Invoke(Connection, Transaction, projectParameter, securityTicket);
                }
            }

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L2PR_SP_1040 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L2PR_SP_1040 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L2PR_SP_1040 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2PR_SP_1040 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Projects",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L2PR_SP_1040 for attribute P_L2PR_SP_1040
		[DataContract]
		public class P_L2PR_SP_1040 
		{
			//Standard type parameters
			[DataMember]
			public String[] Project_IDs_to_Save { get; set; } 
			[DataMember]
			public String ArchiveOrDelete { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Projects(,P_L2PR_SP_1040 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Projects.Invoke(connectionString,P_L2PR_SP_1040 Parameter,securityTicket);
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
var parameter = new CL3_Project.Complex.Manipulation.P_L2PR_SP_1040();
parameter.Project_IDs_to_Save = ...;
parameter.ArchiveOrDelete = ...;

*/
