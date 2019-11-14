/* 
 * Generated on 20-Nov-14 9:36:55 AM
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

namespace CL6_DanuTask_PriceGrade.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Delete_MultipleChargingLevels.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Delete_MultipleChargingLevels
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Base Execute(DbConnection Connection,DbTransaction Transaction,P_L6PG_DMCL_1304 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Base();

            var item = new CL1_CMN_BPT.ORM_CMN_BPT_InvestedWorkTime_ChargingLevel();

            foreach (var cl in Parameter.ChargingLevelsToDelete)
            {
                if (cl != Guid.Empty)
                {
                    var result = item.Load(Connection, Transaction, cl);

                    if (result.Status != FR_Status.Success || item.CMN_BPT_InvestedWorkTime_ChargingLevelID == Guid.Empty)
                    {
                        var error = new FR_Base();
                        error.ErrorMessage = "No Such ID";
                        error.Status = FR_Status.Error_Internal;
                        return error;
                    }
                }

                #region Update project member type charging level

                CL1_TMP_PRO.ORM_TMP_PRO_ProjectMember_Type_AvailableChargingLevel.Query searchQuery = new CL1_TMP_PRO.ORM_TMP_PRO_ProjectMember_Type_AvailableChargingLevel.Query();
                searchQuery.ChargingLevel_RefID = Parameter.ChargingLevelToReplace;
                searchQuery.IsDeleted = false;

                CL1_TMP_PRO.ORM_TMP_PRO_ProjectMember_Type_AvailableChargingLevel.Query updateQuery = new CL1_TMP_PRO.ORM_TMP_PRO_ProjectMember_Type_AvailableChargingLevel.Query();
                updateQuery.ChargingLevel_RefID = Parameter.ChargingLevelToReplace;

                CL1_TMP_PRO.ORM_TMP_PRO_ProjectMember_Type_AvailableChargingLevel.Query.Update(Connection, Transaction, searchQuery, updateQuery);

                #endregion

                #region Delete charging level

                CL1_CMN_BPT.ORM_CMN_BPT_InvestedWorkTime_ChargingLevel.Query query2 = new CL1_CMN_BPT.ORM_CMN_BPT_InvestedWorkTime_ChargingLevel.Query();
                query2.CMN_BPT_InvestedWorkTime_ChargingLevelID = cl;
                CL1_CMN_BPT.ORM_CMN_BPT_InvestedWorkTime_ChargingLevel.Query.SoftDelete(Connection, Transaction, query2);

                #endregion
            }


			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Base Invoke(string ConnectionString,P_L6PG_DMCL_1304 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection,P_L6PG_DMCL_1304 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction,P_L6PG_DMCL_1304 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6PG_DMCL_1304 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Delete_MultipleChargingLevels",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L6PG_DMCL_1304 for attribute P_L6PG_DMCL_1304
		[DataContract]
		public class P_L6PG_DMCL_1304 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] ChargingLevelsToDelete { get; set; } 
			[DataMember]
			public Guid ChargingLevelToReplace { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Base cls_Delete_MultipleChargingLevels(,P_L6PG_DMCL_1304 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Base invocationResult = cls_Delete_MultipleChargingLevels.Invoke(connectionString,P_L6PG_DMCL_1304 Parameter,securityTicket);
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
var parameter = new CL6_DanuTask_PriceGrade.Atomic.Manipulation.P_L6PG_DMCL_1304();
parameter.ChargingLevelsToDelete = ...;
parameter.ChargingLevelToReplace = ...;

*/
