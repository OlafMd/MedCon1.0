/* 
 * Generated on 10/3/2014 2:21:54 PM
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
using CL3_DeveloperTask.Atomic.Retrieval;
using CL6_DanuTask_DeveloperTask.Atomic.Retrieval;

namespace CL6_DanuTask_DeveloperTask.Complex.Retrieval
{
	/// <summary>
    /// 
   //   Get Developer Task Information and Invested time for Developer task ID and AccountID
    
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_DTaskInfo_and_InvestedWorkTime_for_DTaskID_and_AccountID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_DTaskInfo_and_InvestedWorkTime_for_DTaskID_and_AccountID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6DT_GDTIaIWTfDTaACC_1259 Execute(DbConnection Connection,DbTransaction Transaction,P_L6DT_GDTIaIWTfDTaACC_1259 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L6DT_GDTIaIWTfDTaACC_1259();
			//Put your code here
            L6DT_GDTIaIWTfDTaACC_1259 temp = new L6DT_GDTIaIWTfDTaACC_1259();
            P_L6DT_GDTIfDT_1505 parDeveloperTaskInfo = new P_L6DT_GDTIfDT_1505();
            parDeveloperTaskInfo.TaskID = Parameter.DeveloperTaskID;
            parDeveloperTaskInfo.IsBeingPrepared_Only = false;
            L6DT_GDTIfDT_1505 developerTaskInfo = cls_Get_DeveloperTaskInfo_for_DeveloperTaskID.Invoke(Connection, Transaction, parDeveloperTaskInfo, securityTicket).Result;
            temp.DeveloperTaskInfo = developerTaskInfo;

            P_L3DT_GRIfDTID_1408 parameterRecommendations = new P_L3DT_GRIfDTID_1408();
            parameterRecommendations.DTaskID = Parameter.DeveloperTaskID;
            temp.Recommendations = cls_Get_RecommendationsInfo_for_DeveloperTaskID.Invoke(Connection, Transaction, parameterRecommendations, securityTicket).Result;

            P_L6DT_GDTSHfDT_1646 parStatusHistory = new P_L6DT_GDTSHfDT_1646();
            parStatusHistory.DeveloperTaskID = Parameter.DeveloperTaskID;
            List<L6DT_GDTSHfDT_1646> statusHistoryList = cls_Get_DeveloperTaskStatusHistory_for_DeveloperTaskID.Invoke(Connection, Transaction, parStatusHistory, securityTicket).Result.ToList();

            List<L6DT_GDTIaIWTfDTaACC_1259a> tempStatusHistoryList = new List<L6DT_GDTIaIWTfDTaACC_1259a>();
            foreach (var currentStatusItem in statusHistoryList)
            {
                tempStatusHistoryList.Add(new L6DT_GDTIaIWTfDTaACC_1259a() { 
                    Status_ID = currentStatusItem.DeveloperTask_Status_RefID,
                    Status_Name = currentStatusItem.Label,
                    Status_GlobalPropertyMatchingID = currentStatusItem.GlobalPropertyMatchingID,
                    Status_TimeStamp = currentStatusItem.Creation_Timestamp
                });
            }
            temp.StatusHistory = tempStatusHistoryList.ToArray();

            returnValue.Result = temp;
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6DT_GDTIaIWTfDTaACC_1259 Invoke(string ConnectionString,P_L6DT_GDTIaIWTfDTaACC_1259 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6DT_GDTIaIWTfDTaACC_1259 Invoke(DbConnection Connection,P_L6DT_GDTIaIWTfDTaACC_1259 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6DT_GDTIaIWTfDTaACC_1259 Invoke(DbConnection Connection, DbTransaction Transaction,P_L6DT_GDTIaIWTfDTaACC_1259 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6DT_GDTIaIWTfDTaACC_1259 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6DT_GDTIaIWTfDTaACC_1259 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6DT_GDTIaIWTfDTaACC_1259 functionReturn = new FR_L6DT_GDTIaIWTfDTaACC_1259();
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

				throw new Exception("Exception occured in method cls_Get_DTaskInfo_and_InvestedWorkTime_for_DTaskID_and_AccountID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6DT_GDTIaIWTfDTaACC_1259 : FR_Base
	{
		public L6DT_GDTIaIWTfDTaACC_1259 Result	{ get; set; }

		public FR_L6DT_GDTIaIWTfDTaACC_1259() : base() {}

		public FR_L6DT_GDTIaIWTfDTaACC_1259(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6DT_GDTIaIWTfDTaACC_1259 for attribute P_L6DT_GDTIaIWTfDTaACC_1259
		[DataContract]
		public class P_L6DT_GDTIaIWTfDTaACC_1259 
		{
			//Standard type parameters
			[DataMember]
			public Guid DeveloperTaskID { get; set; } 

		}
		#endregion
		#region SClass L6DT_GDTIaIWTfDTaACC_1259 for attribute L6DT_GDTIaIWTfDTaACC_1259
		[DataContract]
		public class L6DT_GDTIaIWTfDTaACC_1259 
		{
			[DataMember]
			public L6DT_GDTIaIWTfDTaACC_1259a[] StatusHistory { get; set; }

			//Standard type parameters
			[DataMember]
			public L6DT_GDTIfDT_1505 DeveloperTaskInfo { get; set; } 
			[DataMember]
			public L3DT_GRIfDTID_1408[] Recommendations { get; set; } 

		}
		#endregion
		#region SClass L6DT_GDTIaIWTfDTaACC_1259a for attribute StatusHistory
		[DataContract]
		public class L6DT_GDTIaIWTfDTaACC_1259a 
		{
			//Standard type parameters
			[DataMember]
			public Guid Status_ID { get; set; } 
			[DataMember]
			public String Status_GlobalPropertyMatchingID { get; set; } 
			[DataMember]
			public Dict Status_Name { get; set; } 
			[DataMember]
			public DateTime Status_TimeStamp { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6DT_GDTIaIWTfDTaACC_1259 cls_Get_DTaskInfo_and_InvestedWorkTime_for_DTaskID_and_AccountID(,P_L6DT_GDTIaIWTfDTaACC_1259 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6DT_GDTIaIWTfDTaACC_1259 invocationResult = cls_Get_DTaskInfo_and_InvestedWorkTime_for_DTaskID_and_AccountID.Invoke(connectionString,P_L6DT_GDTIaIWTfDTaACC_1259 Parameter,securityTicket);
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
var parameter = new CL6_DanuTask_DeveloperTask.Complex.Retrieval.P_L6DT_GDTIaIWTfDTaACC_1259();
parameter.DeveloperTaskID = ...;

*/
