/* 
 * Generated on 1/20/2015 5:46:12 PM
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
using CL1_CMN;

namespace CL3_NumberRange.Atomic.Manipulation
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
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L3SNR_1535 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here
            ORM_CMN_NumberRange orm_numberRanges = null;

            orm_numberRanges = ORM_CMN_NumberRange.Query.Search(Connection, Transaction, new ORM_CMN_NumberRange.Query
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID,
                CMN_NumberRangeID = Parameter.CMN_NumberRangeID
            }).FirstOrDefault();

            if (orm_numberRanges == null)
            {
                returnValue.Status = FR_Status.Error_Internal;
                returnValue.ErrorMessage = String.Format("No number range with id = {1} found.", Parameter.CMN_NumberRangeID.ToString());
                return returnValue;
            }

            orm_numberRanges.NumberRange_Name = Parameter.NumberRange_Name;
            orm_numberRanges.Tenant_RefID = securityTicket.TenantID;
            orm_numberRanges.NumberRange_UsageArea_RefID = Parameter.NumberRange_UsageArea_RefID;
            orm_numberRanges.FixedPrefix = Parameter.FixedPrefix;
            orm_numberRanges.Formatting_LeadingFillCharacter = Parameter.Formatting_LeadingFillCharacter;
            orm_numberRanges.Formatting_NumberLength = Parameter.Formatting_NumberLength;           
            orm_numberRanges.Value_Start = Parameter.Value_Start;
            orm_numberRanges.Value_End = Parameter.Value_End;
            orm_numberRanges.Save(Connection, Transaction);

            returnValue.Result = orm_numberRanges.CMN_NumberRangeID;

			return returnValue;    
           
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L3SNR_1535 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L3SNR_1535 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L3SNR_1535 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3SNR_1535 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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
		#region SClass P_L3SNR_1535 for attribute P_L3SNR_1535
		[DataContract]
		public class P_L3SNR_1535 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_NumberRangeID { get; set; } 
			[DataMember]
			public string NumberRange_Name { get; set; } 
			[DataMember]
			public Guid NumberRange_UsageArea_RefID { get; set; } 
			[DataMember]
			public long Value_Current { get; set; } 
			[DataMember]
			public long Value_Start { get; set; } 
			[DataMember]
			public long Value_End { get; set; } 
			[DataMember]
			public string FixedPrefix { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 
			[DataMember]
			public string Formatting_LeadingFillCharacter { get; set; } 
			[DataMember]
			public int Formatting_NumberLength { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_NumberRange(,P_L3SNR_1535 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_NumberRange.Invoke(connectionString,P_L3SNR_1535 Parameter,securityTicket);
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
var parameter = new CL3_NumberRange.Atomic.Manipulation.P_L3SNR_1535();
parameter.CMN_NumberRangeID = ...;
parameter.NumberRange_Name = ...;
parameter.NumberRange_UsageArea_RefID = ...;
parameter.Value_Current = ...;
parameter.Value_Start = ...;
parameter.Value_End = ...;
parameter.FixedPrefix = ...;
parameter.IsDeleted = ...;
parameter.Formatting_LeadingFillCharacter = ...;
parameter.Formatting_NumberLength = ...;

*/
