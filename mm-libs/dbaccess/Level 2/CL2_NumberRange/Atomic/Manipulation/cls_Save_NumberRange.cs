/* 
 * Generated on 6/9/2014 10:51:49 AM
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

namespace CL2_NumberRange.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_NumberRange.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_NumberRange
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L2NR_SNR_1611 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 

            var returnValue = new FR_Guid();

            var item = new CL1_CMN.ORM_CMN_NumberRange();
            if (Parameter.CMN_NumberRangeID != Guid.Empty)
            {
                var result = item.Load(Connection, Transaction, Parameter.CMN_NumberRangeID);
            }

            if (Parameter.IsDeleted == true)
            {
                item.IsDeleted = true;
                return new FR_Guid(item.Save(Connection, Transaction), item.CMN_NumberRangeID);
            }

            if (Parameter.CMN_NumberRangeID == Guid.Empty)
            {
                item.Tenant_RefID = securityTicket.TenantID;
            }

            item.NumberRange_UsageArea_RefID = Parameter.NumberRange_UsageArea_RefID;
            item.NumberRange_Name = Parameter.NumberRange_Name;
            item.Value_Current = Parameter.Value_Current;
            item.Value_Start = Parameter.Value_Start;
            item.Value_End = Parameter.Value_End;
            item.FixedPrefix = Parameter.FixedPrefix;
            item.Formatting_NumberLength = Parameter.Formatting_NumberLength;
            item.Formatting_LeadingFillCharacter = Parameter.Formatting_LeadingFillCharacter;

            return new FR_Guid(item.Save(Connection, Transaction), item.CMN_NumberRangeID);

			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L2NR_SNR_1611 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L2NR_SNR_1611 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L2NR_SNR_1611 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2NR_SNR_1611 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_NumberRange",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L2NR_SNR_1611 for attribute P_L2NR_SNR_1611
		[DataContract]
		public class P_L2NR_SNR_1611 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_NumberRangeID { get; set; } 
			[DataMember]
			public Guid NumberRange_UsageArea_RefID { get; set; } 
			[DataMember]
			public String NumberRange_Name { get; set; } 
			[DataMember]
			public long Value_Current { get; set; } 
			[DataMember]
			public long Value_Start { get; set; } 
			[DataMember]
			public long Value_End { get; set; } 
			[DataMember]
			public String FixedPrefix { get; set; } 
			[DataMember]
			public int Formatting_NumberLength { get; set; } 
			[DataMember]
			public String Formatting_LeadingFillCharacter { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_NumberRange(,P_L2NR_SNR_1611 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_NumberRange.Invoke(connectionString,P_L2NR_SNR_1611 Parameter,securityTicket);
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
var parameter = new CL2_NumberRange.Atomic.Manipulation.P_L2NR_SNR_1611();
parameter.CMN_NumberRangeID = ...;
parameter.NumberRange_UsageArea_RefID = ...;
parameter.NumberRange_Name = ...;
parameter.Value_Current = ...;
parameter.Value_Start = ...;
parameter.Value_End = ...;
parameter.FixedPrefix = ...;
parameter.Formatting_NumberLength = ...;
parameter.Formatting_LeadingFillCharacter = ...;
parameter.IsDeleted = ...;

*/
