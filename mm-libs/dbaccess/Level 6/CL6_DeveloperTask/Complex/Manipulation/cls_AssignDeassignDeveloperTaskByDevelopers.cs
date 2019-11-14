/* 
 * Generated on 11/4/2014 3:40:01 PM
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

namespace CL6_DanuTask_DeveloperTask.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_AssignDeassignDeveloperTaskByDevelopers.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_AssignDeassignDeveloperTaskByDevelopers
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L6DT_ADTD_0945 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here

            P_L6DT_ADTbD_1314 assignParametar = new P_L6DT_ADTbD_1314();
            P_L6DT_DDTbD_0958 deassignParametar = new P_L6DT_DDTbD_0958();

            if (Parameter.Deassign_DeveloperTaskByDeveloper != null && Parameter.Deassign_DeveloperTaskByDeveloper.ToList().Count() != 0)
            {
                foreach (var developerTask in Parameter.Deassign_DeveloperTaskByDeveloper.ToList())
                {
                    if (developerTask != Guid.Empty)
                    {   
                        deassignParametar.AssigmentID = developerTask;
                        var deassigndeveloperTask = cls_Deassign_DeveloperTask_by_Developer.Invoke(Connection, Transaction, deassignParametar, securityTicket).Result;
                    }
                    
                 }
            }


                if (Parameter.Assign_DeveloperTaskByDeveloper !=null && Parameter.Assign_DeveloperTaskByDeveloper.ToList().Count() != 0)
                {
                    foreach (var developertask in Parameter.Assign_DeveloperTaskByDeveloper.ToList())
                    {
                        if (developertask != Guid.Empty)
                        { 
                            assignParametar.DeveloperTask_RefID = developertask;
                            assignParametar.Developer_TimeEstimation_min = Parameter.Estimated_Time;
                            var assigndeveloperTask = cls_Assign_DeveloperTask_by_Developer.Invoke(Connection, Transaction, assignParametar, securityTicket).Result;
                        }

                    }

                
            }

     
            

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L6DT_ADTD_0945 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L6DT_ADTD_0945 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L6DT_ADTD_0945 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6DT_ADTD_0945 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_AssignDeassignDeveloperTaskByDevelopers",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L6DT_ADTD_0945 for attribute P_L6DT_ADTD_0945
		[DataContract]
		public class P_L6DT_ADTD_0945 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] Assign_DeveloperTaskByDeveloper { get; set; } 
			[DataMember]
			public Guid[] Deassign_DeveloperTaskByDeveloper { get; set; } 
			[DataMember]
			public long Estimated_Time { get; set; } 
			[DataMember]
			public Guid DeveloperTask_ID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_AssignDeassignDeveloperTaskByDevelopers(,P_L6DT_ADTD_0945 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_AssignDeassignDeveloperTaskByDevelopers.Invoke(connectionString,P_L6DT_ADTD_0945 Parameter,securityTicket);
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
var parameter = new CL6_DanuTask_DeveloperTask.Complex.Manipulation.P_L6DT_ADTD_0945();
parameter.Assign_DeveloperTaskByDeveloper = ...;
parameter.Deassign_DeveloperTaskByDeveloper = ...;
parameter.Estimated_Time = ...;
parameter.DeveloperTask_ID = ...;

*/
