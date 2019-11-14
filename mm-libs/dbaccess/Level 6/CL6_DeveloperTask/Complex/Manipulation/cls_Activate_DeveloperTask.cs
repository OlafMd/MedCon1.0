/* 
 * Generated on 7/25/2014 2:44:22 PM
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
using DLCore_DBCommons.DanuTask;
using DLCore_DBCommons.Utils;
using CL2_Feature.Atomic.Retrieval;
using CL2_BusinessTask.Atomic.Retrieval;
using CL6_DanuTask_DeveloperTask.Atomic.Retrieval;
using CL6_DanuTask_DeveloperTask.Complex.Manipulation;
using CL3_DeveloperTask.Atomic.Retrieval;


namespace CL6_DanuTask_DeveloperTask.Complex.Manipulation
{
	/// <summary>
    ///       Retrieve old active task, deactivate it and activate new.    
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Activate_DeveloperTask.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Activate_DeveloperTask
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L6DT_ADT_1443 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
            var returnValue = new FR_Guid();

            #region InPreparationStatus

            var inPrepParam = new P_L2PR_GPSfGP_1339();
            inPrepParam.GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(EProjectStatus.InPreparation);

            var inPreparationStatus = cls_Get_ProjectStatuses_for_GlobalPropertyID.Invoke(Connection, Transaction, inPrepParam, securityTicket).Result;

            #endregion

            #region InPreparationFeatureStatus

            var inPrepFeatureParam = new P_L2FE_GFSfGPM_1405();
            inPrepFeatureParam.GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(EFeatureStatus.InPreparation);

            var inPreparationFeatureStatus = cls_Get_FeatureStatus_for_GlobalPropertyMatchigID.Invoke(Connection, Transaction, inPrepFeatureParam, securityTicket).Result;

            #endregion

            #region inPreparationBTStatus

            var inPreparationBTStatusParam = new P_L2BT_GBTfGPM_1409();
            inPreparationBTStatusParam.GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(EBusinessTaskStatus.InPreparation);

            var inPreparationBTStatus = cls_Get_BusinessTask_for_GlobalPropertyMatchingID.Invoke(Connection, Transaction, inPreparationBTStatusParam, securityTicket).Result;

            #endregion

            //find old active
            P_L3DT_GADTfAU_1505 param1 = new P_L3DT_GADTfAU_1505();
            param1.IsBeingPrepared_Only = false;
            var result1 = cls_Get_ActiveDeveloperTask_for_ActiveUser.Invoke(Connection, Transaction, param1, securityTicket).Result.FirstOrDefault();

            //if active task doesn't exist
            if (result1 == null)
                result1 = new L3DT_GADTfAU_1505();


            //deactivate old and activate new
            P_L6DT_CADT_1453 param2 = new P_L6DT_CADT_1453();
            param2.AssignmentID_newActive = Parameter.AssignmentID_newActive;
            param2.AssignmentID_oldActive = result1.DeveloperTask_InvolvementID;

            returnValue = cls_Change_Active_DeveloperTask.Invoke(Connection, Transaction, param2, securityTicket);

            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L6DT_ADT_1443 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L6DT_ADT_1443 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L6DT_ADT_1443 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6DT_ADT_1443 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Activate_DeveloperTask",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L6DT_ADT_1443 for attribute P_L6DT_ADT_1443
		[DataContract]
		public class P_L6DT_ADT_1443 
		{
			//Standard type parameters
			[DataMember]
			public Guid AssignmentID_newActive { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Activate_DeveloperTask(,P_L6DT_ADT_1443 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Activate_DeveloperTask.Invoke(connectionString,P_L6DT_ADT_1443 Parameter,securityTicket);
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
var parameter = new CL6_DeveloperTask.Complex.Manipulation.P_L6DT_ADT_1443();
parameter.AssignmentID_newActive = ...;

*/
