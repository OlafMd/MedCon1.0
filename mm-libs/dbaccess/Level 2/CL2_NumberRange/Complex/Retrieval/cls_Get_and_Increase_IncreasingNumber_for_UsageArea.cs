/* 
 * Generated on 6/9/2014 2:54:42 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 * Required Assemblies:
 * System.Runtime.Serialization
 * CSV2Core
 * CSV2Core_MySQL
 */
using System;
using System.Data.Common;
using CSV2Core.Core;
using System.Runtime.Serialization;
using CL1_CMN;

namespace CL2_NumberRange.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_and_Increase_IncreasingNumber_for_UsageArea.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_and_Increase_IncreasingNumber_for_UsageArea
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2NR_GaIINfUA_1454 Execute(DbConnection Connection,DbTransaction Transaction,P_L2NR_GaIINfUA_1454 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_L2NR_GaIINfUA_1454();
			
            var param = new P_L2NR_GINfUA_1113(){
                GlobalStaticMatchingID = Parameter.GlobalStaticMatchingID
            };
            var result = cls_Get_IncreasingNumber_for_UsageArea.Invoke(Connection, Transaction, param, securityTicket).Result;

            if (result.CMN_NumberRangeID != Guid.Empty)
            {
                var numberRange = new ORM_CMN_NumberRange();
                numberRange.Load(Connection, Transaction, result.CMN_NumberRangeID);
                numberRange.Value_Current++;
                numberRange.Save(Connection, Transaction);
            }

            returnValue.Result = new L2NR_GaIINfUA_1454()
            {
                Current_IncreasingNumber = result.Current_IncreasingNumber
            };

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L2NR_GaIINfUA_1454 Invoke(string ConnectionString,P_L2NR_GaIINfUA_1454 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2NR_GaIINfUA_1454 Invoke(DbConnection Connection,P_L2NR_GaIINfUA_1454 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2NR_GaIINfUA_1454 Invoke(DbConnection Connection, DbTransaction Transaction,P_L2NR_GaIINfUA_1454 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2NR_GaIINfUA_1454 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2NR_GaIINfUA_1454 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2NR_GaIINfUA_1454 functionReturn = new FR_L2NR_GaIINfUA_1454();
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

				throw new Exception("Exception occured in method cls_Get_and_Increase_IncreasingNumber_for_UsageArea",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2NR_GaIINfUA_1454 : FR_Base
	{
		public L2NR_GaIINfUA_1454 Result	{ get; set; }

		public FR_L2NR_GaIINfUA_1454() : base() {}

		public FR_L2NR_GaIINfUA_1454(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L2NR_GaIINfUA_1454 for attribute P_L2NR_GaIINfUA_1454
		[DataContract]
		public class P_L2NR_GaIINfUA_1454 
		{
			//Standard type parameters
			[DataMember]
			public String GlobalStaticMatchingID { get; set; } 

		}
		#endregion
		#region SClass L2NR_GaIINfUA_1454 for attribute L2NR_GaIINfUA_1454
		[DataContract]
		public class L2NR_GaIINfUA_1454 
		{
			//Standard type parameters
			[DataMember]
			public String Current_IncreasingNumber { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2NR_GaIINfUA_1454 cls_Get_and_Increase_IncreasingNumber_for_UsageArea(,P_L2NR_GaIINfUA_1454 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2NR_GaIINfUA_1454 invocationResult = cls_Get_and_Increase_IncreasingNumber_for_UsageArea.Invoke(connectionString,P_L2NR_GaIINfUA_1454 Parameter,securityTicket);
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
var parameter = new CL2_NumberRange.Complex.Retrieval.P_L2NR_GaIINfUA_1454();
parameter.GlobalStaticMatchingID = ...;

*/
