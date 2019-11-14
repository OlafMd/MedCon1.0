/* 
 * Generated on 10/24/2014 12:04:15 PM
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
using CL1_TMP_PRO;

namespace CL6_DanuTask_PriceGrade.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Add_ChargingLevels_to_ProjectMemberType.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Add_ChargingLevels_to_ProjectMemberType
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L6PG_ACLtPMT_1610 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here
            ORM_TMP_PRO_ProjectMember_Type_AvailableChargingLevel.Query searchQuery = new ORM_TMP_PRO_ProjectMember_Type_AvailableChargingLevel.Query();
            searchQuery.ProjectMember_Type_RefID = Parameter.ProjectMemberTypeID;

            ORM_TMP_PRO_ProjectMember_Type_AvailableChargingLevel.Query updateQuery = new ORM_TMP_PRO_ProjectMember_Type_AvailableChargingLevel.Query();
            updateQuery.IsDeleted = true;

            ORM_TMP_PRO_ProjectMember_Type_AvailableChargingLevel.Query.Update(Connection, Transaction, searchQuery, updateQuery);

            foreach (Guid currentChargingLevel in Parameter.ChargingLevelIDs)
            {
                ORM_TMP_PRO_ProjectMember_Type_AvailableChargingLevel cl = new ORM_TMP_PRO_ProjectMember_Type_AvailableChargingLevel();
                cl.ChargingLevel_RefID = currentChargingLevel;
                cl.ProjectMember_Type_RefID = Parameter.ProjectMemberTypeID;
                cl.Tenant_RefID = securityTicket.TenantID;
                if (Parameter.DefaultLevelID == currentChargingLevel)
                    cl.IsDefault = true;
                else
                    cl.IsDefault = false;

                cl.Save(Connection, Transaction);
            }

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L6PG_ACLtPMT_1610 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L6PG_ACLtPMT_1610 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L6PG_ACLtPMT_1610 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6PG_ACLtPMT_1610 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Add_ChargingLevels_to_ProjectMemberType",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L6PG_ACLtPMT_1610 for attribute P_L6PG_ACLtPMT_1610
		[DataContract]
		public class P_L6PG_ACLtPMT_1610 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] ChargingLevelIDs { get; set; } 
			[DataMember]
			public Guid DefaultLevelID { get; set; } 
			[DataMember]
			public Guid ProjectMemberTypeID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Add_ChargingLevels_to_ProjectMemberType(,P_L6PG_ACLtPMT_1610 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Add_ChargingLevels_to_ProjectMemberType.Invoke(connectionString,P_L6PG_ACLtPMT_1610 Parameter,securityTicket);
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
var parameter = new CL6_DanuTask_PriceGrade.Complex.Manipulation.P_L6PG_ACLtPMT_1610();
parameter.ChargingLevelIDs = ...;
parameter.DefaultLevelID = ...;
parameter.ProjectMemberTypeID = ...;

*/
