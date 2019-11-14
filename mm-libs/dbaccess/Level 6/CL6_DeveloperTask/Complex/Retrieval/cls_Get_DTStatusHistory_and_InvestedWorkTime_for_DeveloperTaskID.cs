/* 
 * Generated on 10/2/2014 3:44:27 PM
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
using CL6_DanuTask_DeveloperTask.Atomic.Retrieval;

namespace CL6_DanuTask_DeveloperTask.Complex.Retrieval
{
	/// <summary>
    /// 
   ///   Get Developer Task Status history and Invested time for Developer task ID
    
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_DTStatusHistory_and_InvestedWorkTime_for_DeveloperTaskID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_DTStatusHistory_and_InvestedWorkTime_for_DeveloperTaskID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6DT_GDTSHaIWTfDT_0913 Execute(DbConnection Connection,DbTransaction Transaction,P_L6DT_GDTSHaIWTfDT_0913 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_L6DT_GDTSHaIWTfDT_0913();
            L6DT_GDTSHaIWTfDT_0913 temp = new L6DT_GDTSHaIWTfDT_0913();

            P_L6DT_GDTSHfDT_1646 parStatusHistory = new P_L6DT_GDTSHfDT_1646();
            parStatusHistory.DeveloperTaskID = Parameter.DeveloperTaskID;
            List<L6DT_GDTSHfDT_1646> lstStatusHistory = cls_Get_DeveloperTaskStatusHistory_for_DeveloperTaskID.Invoke(Connection, Transaction, parStatusHistory, securityTicket).Result.ToList();
          
            P_L6DT_GIWTfDT_1649 parInvestedTIme = new P_L6DT_GIWTfDT_1649();
            parInvestedTIme.DeveloperTaskID = Parameter.DeveloperTaskID;
            List<L6DT_GIWTfDT_1649> investedWorkTime = cls_Get_InvestedWorkTime_for_DeveloperTaskID.Invoke(Connection, Transaction, parInvestedTIme, securityTicket).Result.ToList();
            temp.InvestedWorkTime=investedWorkTime.Sum(x=>x.InvestedWorkTime);
            
            temp.StatusHistory = lstStatusHistory.ToArray();

            returnValue.Result = temp;

            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6DT_GDTSHaIWTfDT_0913 Invoke(string ConnectionString,P_L6DT_GDTSHaIWTfDT_0913 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6DT_GDTSHaIWTfDT_0913 Invoke(DbConnection Connection,P_L6DT_GDTSHaIWTfDT_0913 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6DT_GDTSHaIWTfDT_0913 Invoke(DbConnection Connection, DbTransaction Transaction,P_L6DT_GDTSHaIWTfDT_0913 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6DT_GDTSHaIWTfDT_0913 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6DT_GDTSHaIWTfDT_0913 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6DT_GDTSHaIWTfDT_0913 functionReturn = new FR_L6DT_GDTSHaIWTfDT_0913();
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

				throw new Exception("Exception occured in method cls_Get_DTStatusHistory_and_InvestedWorkTime_for_DeveloperTaskID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6DT_GDTSHaIWTfDT_0913 : FR_Base
	{
		public L6DT_GDTSHaIWTfDT_0913 Result	{ get; set; }

		public FR_L6DT_GDTSHaIWTfDT_0913() : base() {}

		public FR_L6DT_GDTSHaIWTfDT_0913(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6DT_GDTSHaIWTfDT_0913 for attribute P_L6DT_GDTSHaIWTfDT_0913
		[DataContract]
		public class P_L6DT_GDTSHaIWTfDT_0913 
		{
			//Standard type parameters
			[DataMember]
			public Guid DeveloperTaskID { get; set; } 

		}
		#endregion
		#region SClass L6DT_GDTSHaIWTfDT_0913 for attribute L6DT_GDTSHaIWTfDT_0913
		[DataContract]
		public class L6DT_GDTSHaIWTfDT_0913 
		{
			//Standard type parameters
			[DataMember]
			public L6DT_GDTSHfDT_1646[] StatusHistory { get; set; } 
			[DataMember]
			public long InvestedWorkTime { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6DT_GDTSHaIWTfDT_0913 cls_Get_DTStatusHistory_and_InvestedWorkTime_for_DeveloperTaskID(,P_L6DT_GDTSHaIWTfDT_0913 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6DT_GDTSHaIWTfDT_0913 invocationResult = cls_Get_DTStatusHistory_and_InvestedWorkTime_for_DeveloperTaskID.Invoke(connectionString,P_L6DT_GDTSHaIWTfDT_0913 Parameter,securityTicket);
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
var parameter = new CL6_DanuTask_DeveloperTask.Complex.Retrieval.P_L6DT_GDTSHaIWTfDT_0913();
parameter.DeveloperTaskID = ...;

*/
