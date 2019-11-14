/* 
 * Generated on 6/9/2014 2:58:29 PM
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
using CL2_NumberRange.Atomic.Retrieval;

namespace CL2_NumberRange.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_IncreasingNumber_for_UsageArea.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_IncreasingNumber_for_UsageArea
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2NR_GINfUA_1113 Execute(DbConnection Connection,DbTransaction Transaction,P_L2NR_GINfUA_1113 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_L2NR_GINfUA_1113();
            returnValue.Result = new L2NR_GINfUA_1113();

            #region Get_NumberRange_BasicInfo_for_UsageArea

            var param = new P_L2NR_GNRBIfUA_1000()
            {
                GlobalStaticMatchingID = Parameter.GlobalStaticMatchingID
            };

            var numberRangeBasicInfo = cls_Get_NumberRange_BasicInfo_for_UsageArea.Invoke(Connection, Transaction, param,securityTicket).Result;

            #endregion

            if (numberRangeBasicInfo==null ||numberRangeBasicInfo.CMN_NumberRangeID == Guid.Empty)
            {
                returnValue.Result.Current_IncreasingNumber = "Nummernkreis ist nicht definiert";
                return returnValue;
            }

            try
            {
                var lengthOfNextNumber = numberRangeBasicInfo.Value_Current.ToString().Length;
                var currentNumber = 
                    numberRangeBasicInfo.FixedPrefix + 
                    new String(numberRangeBasicInfo.Formatting_LeadingFillCharacter[0], numberRangeBasicInfo.Formatting_NumberLength - lengthOfNextNumber)+
                    numberRangeBasicInfo.Value_Current;

                var nextNumber = numberRangeBasicInfo.Value_Current + 1 ;
                if (nextNumber == numberRangeBasicInfo.Value_End && numberRangeBasicInfo.Value_End != 0)
                {
                    nextNumber = numberRangeBasicInfo.Value_Start;
                }

                returnValue.Result = new L2NR_GINfUA_1113()
                {
                    CMN_NumberRangeID = numberRangeBasicInfo.CMN_NumberRangeID,
                    Current_IncreasingNumber = currentNumber
                };
            }
            catch (Exception ex) {

                returnValue.Result.Current_IncreasingNumber = "Falsch Nummernkreis";
            }
            
            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L2NR_GINfUA_1113 Invoke(string ConnectionString,P_L2NR_GINfUA_1113 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2NR_GINfUA_1113 Invoke(DbConnection Connection,P_L2NR_GINfUA_1113 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2NR_GINfUA_1113 Invoke(DbConnection Connection, DbTransaction Transaction,P_L2NR_GINfUA_1113 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2NR_GINfUA_1113 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2NR_GINfUA_1113 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2NR_GINfUA_1113 functionReturn = new FR_L2NR_GINfUA_1113();
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

				throw new Exception("Exception occured in method cls_Get_IncreasingNumber_for_UsageArea",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2NR_GINfUA_1113 : FR_Base
	{
		public L2NR_GINfUA_1113 Result	{ get; set; }

		public FR_L2NR_GINfUA_1113() : base() {}

		public FR_L2NR_GINfUA_1113(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L2NR_GINfUA_1113 for attribute P_L2NR_GINfUA_1113
		[DataContract]
		public class P_L2NR_GINfUA_1113 
		{
			//Standard type parameters
			[DataMember]
			public String GlobalStaticMatchingID { get; set; } 

		}
		#endregion
		#region SClass L2NR_GINfUA_1113 for attribute L2NR_GINfUA_1113
		[DataContract]
		public class L2NR_GINfUA_1113 
		{
			//Standard type parameters
			[DataMember]
			public String Current_IncreasingNumber { get; set; } 
			[DataMember]
			public Guid CMN_NumberRangeID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2NR_GINfUA_1113 cls_Get_IncreasingNumber_for_UsageArea(,P_L2NR_GINfUA_1113 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2NR_GINfUA_1113 invocationResult = cls_Get_IncreasingNumber_for_UsageArea.Invoke(connectionString,P_L2NR_GINfUA_1113 Parameter,securityTicket);
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
var parameter = new CL2_NumberRange.Complex.Retrieval.P_L2NR_GINfUA_1113();
parameter.GlobalStaticMatchingID = ...;

*/
