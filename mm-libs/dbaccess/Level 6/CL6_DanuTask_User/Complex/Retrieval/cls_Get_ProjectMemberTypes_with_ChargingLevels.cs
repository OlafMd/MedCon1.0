/* 
 * Generated on 11/21/2014 9:17:45 AM
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
using CL3_ProjectMember.Atomic.Retrieval;

namespace CL6_DanuTask_User.Complex.Retrieval
{
	/// <summary>
    /// 
    
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ProjectMemberTypes_with_ChargingLevels.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ProjectMemberTypes_with_ChargingLevels
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6US_GPMTwCL_1310_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L6US_GPMTwCL_1310_Array();
            //Put your code here
            List<L6US_GPMTwCL_1310> tempResult = new List<L6US_GPMTwCL_1310>();

            var tempProjectMemberTypes = cls_Get_ProjectMemberTypes_for_ActiveTenant.Invoke(Connection, Transaction, securityTicket).Result;
            foreach (var currentProjectMemberType in tempProjectMemberTypes)
            {
                L6US_GPMTwCL_1310 tempResultItem = new L6US_GPMTwCL_1310();
                tempResultItem.ProjectMemberType_ID = currentProjectMemberType.TMP_PRO_ProjectMember_TypeID;
                tempResultItem.ProjectMemberType_Name = currentProjectMemberType.ProjectMemberType_Name;
                tempResultItem.Color = currentProjectMemberType.Color;
                P_L3PM_GACLfPMT_1114 chargingLevelsParameter = new P_L3PM_GACLfPMT_1114();
                chargingLevelsParameter.MemberTypeID = currentProjectMemberType.TMP_PRO_ProjectMember_TypeID;

                tempResultItem.ProjectMemberType_ChargingLevels = cls_Get_AvailableChargingLevels_for_ProjectMemberTypeID.Invoke(Connection, Transaction, chargingLevelsParameter, securityTicket).Result;

                tempResult.Add(tempResultItem);
            }

            returnValue.Result = tempResult.ToArray();
            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6US_GPMTwCL_1310_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6US_GPMTwCL_1310_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6US_GPMTwCL_1310_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6US_GPMTwCL_1310_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6US_GPMTwCL_1310_Array functionReturn = new FR_L6US_GPMTwCL_1310_Array();
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

				throw new Exception("Exception occured in method cls_Get_ProjectMemberTypes_with_ChargingLevels",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6US_GPMTwCL_1310_Array : FR_Base
	{
		public L6US_GPMTwCL_1310[] Result	{ get; set; } 
		public FR_L6US_GPMTwCL_1310_Array() : base() {}

		public FR_L6US_GPMTwCL_1310_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L6US_GPMTwCL_1310 for attribute L6US_GPMTwCL_1310
		[DataContract]
		public class L6US_GPMTwCL_1310 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProjectMemberType_ID { get; set; } 
			[DataMember]
			public Dict ProjectMemberType_Name { get; set; } 
			[DataMember]
			public String Color { get; set; } 
			[DataMember]
			public L3PM_GACLfPMT_1114[] ProjectMemberType_ChargingLevels { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6US_GPMTwCL_1310_Array cls_Get_ProjectMemberTypes_with_ChargingLevels(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6US_GPMTwCL_1310_Array invocationResult = cls_Get_ProjectMemberTypes_with_ChargingLevels.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

