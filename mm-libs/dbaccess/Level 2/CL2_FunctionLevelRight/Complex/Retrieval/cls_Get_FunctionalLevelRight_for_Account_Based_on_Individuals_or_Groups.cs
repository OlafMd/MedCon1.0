/* 
 * Generated on 5/30/2014 11:52:49 AM
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
using System.Runtime.Serialization;

namespace CL2_FunctionLevelRight.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_FunctionalLevelRight_for_Account_Based_on_Individuals_or_Groups.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_FunctionalLevelRight_for_Account_Based_on_Individuals_or_Groups
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2FLR_GFLRfABoIoG_1554_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L2FLR_GFLRfABoIoG_1554 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_L2FLR_GFLRfABoIoG_1554_Array();

            var rights = new List<L2FLR_GFLRfABoIoG_1554>();
            foreach (var rightGroup in Parameter.AccountFunctionLevelRightGroup)
            {
                var individualParam = new CL2_FunctionLevelRight.Atomic.Retrieval.P_L5FLR_GFLRfABoIR_1216();
                individualParam.AccountFunctionLevelRightGroup = rightGroup;
                var individualRights = CL2_FunctionLevelRight.Atomic.Retrieval.cls_Get_FunctionalLevelRights_for_Account_Based_on_IndividualRelation.Invoke(Connection, Transaction, individualParam, securityTicket).Result;

                foreach (var ir in individualRights)
                {
                    var right = new L2FLR_GFLRfABoIoG_1554();
                    right.AccountID = ir.USR_AccountID;
                    right.USR_Account_FunctionLevelRightID = ir.USR_Account_FunctionLevelRightID;
                    right.RightLevel = ir.RightLevel;
                    rights.Add(right);
                }

                var groupParam = new CL2_FunctionLevelRight.Atomic.Retrieval.P_L2FLR_GFLRfABoAG_1206();
                groupParam.AccountFunctionLevelRightGroup = rightGroup;
                var groupRights =
                    CL2_FunctionLevelRight.Atomic.Retrieval
                        .cls_Get_FunctionLevelRight_for_Account_Based_on_AccountGroup.Invoke(Connection, Transaction,
                            groupParam, securityTicket).Result;

                foreach (var gr in groupRights)
                {
                    var right = new L2FLR_GFLRfABoIoG_1554();
                    right.AccountID = gr.USR_AccountID;
                    right.USR_Account_FunctionLevelRightID = gr.USR_Account_FunctionLevelRightID;
                    right.RightLevel = gr.RightLevel;
                    if (
                        !rights.Any(
                            x => x.USR_Account_FunctionLevelRightID == right.USR_Account_FunctionLevelRightID))
                        rights.Add(right);
                }
                
            }

            returnValue.Result = rights.ToArray();
			return returnValue;

			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L2FLR_GFLRfABoIoG_1554_Array Invoke(string ConnectionString,P_L2FLR_GFLRfABoIoG_1554 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2FLR_GFLRfABoIoG_1554_Array Invoke(DbConnection Connection,P_L2FLR_GFLRfABoIoG_1554 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2FLR_GFLRfABoIoG_1554_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L2FLR_GFLRfABoIoG_1554 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2FLR_GFLRfABoIoG_1554_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2FLR_GFLRfABoIoG_1554 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2FLR_GFLRfABoIoG_1554_Array functionReturn = new FR_L2FLR_GFLRfABoIoG_1554_Array();
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

				throw new Exception("Exception occured in method cls_Get_FunctionalLevelRight_for_Account_Based_on_Individuals_or_Groups",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2FLR_GFLRfABoIoG_1554_Array : FR_Base
	{
		public L2FLR_GFLRfABoIoG_1554[] Result	{ get; set; } 
		public FR_L2FLR_GFLRfABoIoG_1554_Array() : base() {}

		public FR_L2FLR_GFLRfABoIoG_1554_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L2FLR_GFLRfABoIoG_1554 for attribute P_L2FLR_GFLRfABoIoG_1554
		[DataContract]
		public class P_L2FLR_GFLRfABoIoG_1554 
		{
			//Standard type parameters
			[DataMember]
			public String[] AccountFunctionLevelRightGroup { get; set; } 

		}
		#endregion
		#region SClass L2FLR_GFLRfABoIoG_1554 for attribute L2FLR_GFLRfABoIoG_1554
		[DataContract]
		public class L2FLR_GFLRfABoIoG_1554 
		{
			//Standard type parameters
			[DataMember]
			public Guid AccountID { get; set; } 
			[DataMember]
			public Guid USR_Account_FunctionLevelRightID { get; set; } 
			[DataMember]
			public String RightLevel { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2FLR_GFLRfABoIoG_1554_Array cls_Get_FunctionalLevelRight_for_Account_Based_on_Individuals_or_Groups(,P_L2FLR_GFLRfABoIoG_1554 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2FLR_GFLRfABoIoG_1554_Array invocationResult = cls_Get_FunctionalLevelRight_for_Account_Based_on_Individuals_or_Groups.Invoke(connectionString,P_L2FLR_GFLRfABoIoG_1554 Parameter,securityTicket);
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
var parameter = new CL2_FunctionLevelRight.Complex.Retrieval.P_L2FLR_GFLRfABoIoG_1554();
parameter.AccountFunctionLevelRightGroup = ...;

*/
