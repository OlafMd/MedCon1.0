/* 
 * Generated on 10/30/2014 10:58:56 AM
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
    /// var result = cls_Get_ProjectMemberTypes_for_ProjectMembers_ID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ProjectMemberTypes_for_ProjectMembers_ID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2PR_GPMTfPMID_1020_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L2PR_GPMTfPMID_1020 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_L2PR_GPMTfPMID_1020_Array();
            List<L2PR_GPMTfPMID_1020> ProjectMembersAndChargingLevels = new List<L2PR_GPMTfPMID_1020>();
            foreach (var ProjectMemberID in Parameter.ProjectMemberIDs)
            {
                L2PR_GPMTfPMID_1020 projectMemberIDAndType=new L2PR_GPMTfPMID_1020();
                P_L2PR_GPMTfPMID_1307 ProjectMemberTypeParameter = new P_L2PR_GPMTfPMID_1307();
                ProjectMemberTypeParameter.ProjectMemberID = ProjectMemberID;
                var MemberTypeForMemberID = cls_Get_ProjectMemberType_for_ProjectMemberID.Invoke(Connection,Transaction, ProjectMemberTypeParameter,securityTicket).Result;
                projectMemberIDAndType.TMP_PRO_ProjectMember_ID = ProjectMemberID;
                if (MemberTypeForMemberID != null)
                {
                    projectMemberIDAndType.TMP_PRO_ProjectMember_TypeID = MemberTypeForMemberID.TMP_PRO_ProjectMember_TypeID;
                }
                else
                {
                    projectMemberIDAndType.TMP_PRO_ProjectMember_TypeID = new Guid();
                }
                
                ProjectMembersAndChargingLevels.Add(projectMemberIDAndType);
            }
            returnValue.Result = ProjectMembersAndChargingLevels.ToArray();
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L2PR_GPMTfPMID_1020_Array Invoke(string ConnectionString,P_L2PR_GPMTfPMID_1020 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2PR_GPMTfPMID_1020_Array Invoke(DbConnection Connection,P_L2PR_GPMTfPMID_1020 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2PR_GPMTfPMID_1020_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L2PR_GPMTfPMID_1020 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2PR_GPMTfPMID_1020_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2PR_GPMTfPMID_1020 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2PR_GPMTfPMID_1020_Array functionReturn = new FR_L2PR_GPMTfPMID_1020_Array();
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

				throw new Exception("Exception occured in method cls_Get_ProjectMemberTypes_for_ProjectMembers_ID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2PR_GPMTfPMID_1020_Array : FR_Base
	{
		public L2PR_GPMTfPMID_1020[] Result	{ get; set; } 
		public FR_L2PR_GPMTfPMID_1020_Array() : base() {}

		public FR_L2PR_GPMTfPMID_1020_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L2PR_GPMTfPMID_1020 for attribute P_L2PR_GPMTfPMID_1020
		[DataContract]
		public class P_L2PR_GPMTfPMID_1020 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] ProjectMemberIDs { get; set; } 

		}
		#endregion
		#region SClass L2PR_GPMTfPMID_1020 for attribute L2PR_GPMTfPMID_1020
		[DataContract]
		public class L2PR_GPMTfPMID_1020 
		{
			//Standard type parameters
			[DataMember]
			public Guid TMP_PRO_ProjectMember_TypeID { get; set; } 
			[DataMember]
			public Guid TMP_PRO_ProjectMember_ID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2PR_GPMTfPMID_1020_Array cls_Get_ProjectMemberTypes_for_ProjectMembers_ID(,P_L2PR_GPMTfPMID_1020 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2PR_GPMTfPMID_1020_Array invocationResult = cls_Get_ProjectMemberTypes_for_ProjectMembers_ID.Invoke(connectionString,P_L2PR_GPMTfPMID_1020 Parameter,securityTicket);
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
var parameter = new CL2_Project.Complex.Retrieval.P_L2PR_GPMTfPMID_1020();
parameter.ProjectMemberIDs = ...;

*/
