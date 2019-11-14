/* 
 * Generated on 10/30/2014 2:04:01 PM
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
using CL2_Project.Atomic.Retrieval;

namespace CL2_Project.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ProjectMembers_ChargingLevel_for_ProjectMemberIDs.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ProjectMembers_ChargingLevel_for_ProjectMemberIDs
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2PR_GPMCLfPMID_1234_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L2PR_GPMCLfPMID_1234 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L2PR_GPMCLfPMID_1234_Array();
			//Put your code here
            List<L2PR_GPMCLfPMID_1234> ProjectMemberTypes = new List<L2PR_GPMCLfPMID_1234>();
            foreach (var ProjectMemberID in Parameter.ProjectMemberIDs)
            {
                L2PR_GPMCLfPMID_1234 ProjectMemberIDAndChargingLevel = new L2PR_GPMCLfPMID_1234();
                P_L2PR_GPMCLfPMID_1526 ProjectMemberIDAndChargingLevelParameter = new P_L2PR_GPMCLfPMID_1526();
                ProjectMemberIDAndChargingLevelParameter.ProjectMemberID = ProjectMemberID;
                var ChargingLevelForMemberID = cls_Get_ProjectMemberChargingLevel_for_ProjectMemberID.Invoke(Connection, Transaction, ProjectMemberIDAndChargingLevelParameter, securityTicket).Result;
                ProjectMemberIDAndChargingLevel.TMP_PRO_ProjectMember_ID = ProjectMemberID;
                if (ChargingLevelForMemberID != null)
                {
                    ProjectMemberIDAndChargingLevel.CharginglevelID = ChargingLevelForMemberID.ChargingLevel_RefID;
                }
                else
                {
                    ProjectMemberIDAndChargingLevel.CharginglevelID = new Guid();
                }
                
                ProjectMemberTypes.Add(ProjectMemberIDAndChargingLevel);
            }
            returnValue.Result = ProjectMemberTypes.ToArray();
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L2PR_GPMCLfPMID_1234_Array Invoke(string ConnectionString,P_L2PR_GPMCLfPMID_1234 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2PR_GPMCLfPMID_1234_Array Invoke(DbConnection Connection,P_L2PR_GPMCLfPMID_1234 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2PR_GPMCLfPMID_1234_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L2PR_GPMCLfPMID_1234 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2PR_GPMCLfPMID_1234_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2PR_GPMCLfPMID_1234 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2PR_GPMCLfPMID_1234_Array functionReturn = new FR_L2PR_GPMCLfPMID_1234_Array();
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

				throw new Exception("Exception occured in method cls_Get_ProjectMembers_ChargingLevel_for_ProjectMemberIDs",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2PR_GPMCLfPMID_1234_Array : FR_Base
	{
		public L2PR_GPMCLfPMID_1234[] Result	{ get; set; } 
		public FR_L2PR_GPMCLfPMID_1234_Array() : base() {}

		public FR_L2PR_GPMCLfPMID_1234_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L2PR_GPMCLfPMID_1234 for attribute P_L2PR_GPMCLfPMID_1234
		[DataContract]
		public class P_L2PR_GPMCLfPMID_1234 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] ProjectMemberIDs { get; set; } 

		}
		#endregion
		#region SClass L2PR_GPMCLfPMID_1234 for attribute L2PR_GPMCLfPMID_1234
		[DataContract]
		public class L2PR_GPMCLfPMID_1234 
		{
			//Standard type parameters
			[DataMember]
			public Guid CharginglevelID { get; set; } 
			[DataMember]
			public Guid TMP_PRO_ProjectMember_ID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2PR_GPMCLfPMID_1234_Array cls_Get_ProjectMembers_ChargingLevel_for_ProjectMemberIDs(,P_L2PR_GPMCLfPMID_1234 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2PR_GPMCLfPMID_1234_Array invocationResult = cls_Get_ProjectMembers_ChargingLevel_for_ProjectMemberIDs.Invoke(connectionString,P_L2PR_GPMCLfPMID_1234 Parameter,securityTicket);
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
var parameter = new CL2_Project.Complex.Retrieval.P_L2PR_GPMCLfPMID_1234();
parameter.ProjectMemberIDs = ...;

*/
