/* 
 * Generated on 12/10/2014 3:28:06 PM
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
using CL1_TMS_PRO;

namespace CL3_Notes.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Update_ProjectNote_Collaborators.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Update_ProjectNote_Collaborators
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Base Execute(DbConnection Connection,DbTransaction Transaction,P_L3N_UPNC_1521 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Base();
            //Put your code here
            #region Remove existing collaborators
            ORM_TMS_PRO_Project_Note_Collaborators.Query noteCollaboratorsQuery = new ORM_TMS_PRO_Project_Note_Collaborators.Query();
            noteCollaboratorsQuery.ProjectNote_RefID = Parameter.ProjectNote_ID;
            ORM_TMS_PRO_Project_Note_Collaborators.Query.SoftDelete(Connection, Transaction, noteCollaboratorsQuery);
            #endregion

            #region Update new collaborators query
            if (Parameter.ProjectNote_Collaborators != null)
            {
                foreach (var currentCollaborator in Parameter.ProjectNote_Collaborators) 
                {
                    ORM_TMS_PRO_Project_Note_Collaborators tempCollaboratorAssignment = new ORM_TMS_PRO_Project_Note_Collaborators();
                    tempCollaboratorAssignment.Account_RefID = currentCollaborator;
                    tempCollaboratorAssignment.ProjectNote_RefID = Parameter.ProjectNote_ID;
                    tempCollaboratorAssignment.Tenant_RefID = securityTicket.TenantID;
                    tempCollaboratorAssignment.Save(Connection, Transaction);
                }
            }
            #endregion


            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Base Invoke(string ConnectionString,P_L3N_UPNC_1521 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection,P_L3N_UPNC_1521 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction,P_L3N_UPNC_1521 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3N_UPNC_1521 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Base functionReturn = new FR_Base();
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

				throw new Exception("Exception occured in method cls_Update_ProjectNote_Collaborators",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3N_UPNC_1521 for attribute P_L3N_UPNC_1521
		[DataContract]
		public class P_L3N_UPNC_1521 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProjectNote_ID { get; set; } 
			[DataMember]
			public Guid[] ProjectNote_Collaborators { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Base cls_Update_ProjectNote_Collaborators(,P_L3N_UPNC_1521 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Base invocationResult = cls_Update_ProjectNote_Collaborators.Invoke(connectionString,P_L3N_UPNC_1521 Parameter,securityTicket);
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
var parameter = new CL3_Notes.Complex.Manipulation.P_L3N_UPNC_1521();
parameter.ProjectNote_ID = ...;
parameter.ProjectNote_Collaborators = ...;

*/
