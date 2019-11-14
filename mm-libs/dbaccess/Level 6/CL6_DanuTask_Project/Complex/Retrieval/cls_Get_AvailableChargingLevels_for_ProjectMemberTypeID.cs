/* 
 * Generated on 10/30/2014 11:57:33 AM
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
using CL6_DanuTask_Project.Atomic.Retrieval;

namespace CL6_DanuTask_Project.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_AvailableChargingLevels_for_ProjectMemberTypeID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_AvailableChargingLevels_for_ProjectMemberTypeID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6PR_GACLfPMTID_1126_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L6PR_GACLfPMTID_1126 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L6PR_GACLfPMTID_1126_Array();
			//Put your code here
            List<L6PR_GACLfPMTID_1126> ChargingLevelsForTypes = new List<L6PR_GACLfPMTID_1126>();
            foreach (var item in Parameter.ProjectMemberTypeIDs)
            {
                L6PR_GACLfPMTID_1126 ChargingLevelsForType = new L6PR_GACLfPMTID_1126();
                P_L6PR_GCLfPMTID_1531 ChargingLevelsForTypeParameter = new P_L6PR_GCLfPMTID_1531();
                ChargingLevelsForTypeParameter.ProjectMemberID = item;
                var chargingLevels = cls_Get_ChargingLevels_for_ProjectMemberTypeID.Invoke(Connection, Transaction, ChargingLevelsForTypeParameter, securityTicket).Result;
                ChargingLevelsForType.ProjectMember_TypeID = item;
                ChargingLevelsForType.ProjectMemberAvailableChargingLevels = chargingLevels;
                ChargingLevelsForTypes.Add(ChargingLevelsForType);
            }
            returnValue.Result = ChargingLevelsForTypes.ToArray();
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6PR_GACLfPMTID_1126_Array Invoke(string ConnectionString,P_L6PR_GACLfPMTID_1126 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6PR_GACLfPMTID_1126_Array Invoke(DbConnection Connection,P_L6PR_GACLfPMTID_1126 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6PR_GACLfPMTID_1126_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L6PR_GACLfPMTID_1126 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6PR_GACLfPMTID_1126_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6PR_GACLfPMTID_1126 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6PR_GACLfPMTID_1126_Array functionReturn = new FR_L6PR_GACLfPMTID_1126_Array();
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

				throw new Exception("Exception occured in method cls_Get_AvailableChargingLevels_for_ProjectMemberTypeID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6PR_GACLfPMTID_1126_Array : FR_Base
	{
		public L6PR_GACLfPMTID_1126[] Result	{ get; set; } 
		public FR_L6PR_GACLfPMTID_1126_Array() : base() {}

		public FR_L6PR_GACLfPMTID_1126_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6PR_GACLfPMTID_1126 for attribute P_L6PR_GACLfPMTID_1126
		[DataContract]
		public class P_L6PR_GACLfPMTID_1126 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] ProjectMemberTypeIDs { get; set; } 

		}
		#endregion
		#region SClass L6PR_GACLfPMTID_1126 for attribute L6PR_GACLfPMTID_1126
		[DataContract]
		public class L6PR_GACLfPMTID_1126 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProjectMember_TypeID { get; set; } 
			[DataMember]
			public CL6_DanuTask_Project.Atomic.Retrieval.L6PR_GCLfPMTID_1531[] ProjectMemberAvailableChargingLevels { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6PR_GACLfPMTID_1126_Array cls_Get_AvailableChargingLevels_for_ProjectMemberTypeID(,P_L6PR_GACLfPMTID_1126 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6PR_GACLfPMTID_1126_Array invocationResult = cls_Get_AvailableChargingLevels_for_ProjectMemberTypeID.Invoke(connectionString,P_L6PR_GACLfPMTID_1126 Parameter,securityTicket);
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
var parameter = new CL6_DanuTask_Project.Complex.Retrieval.P_L6PR_GACLfPMTID_1126();
parameter.ProjectMemberTypeIDs = ...;

*/
