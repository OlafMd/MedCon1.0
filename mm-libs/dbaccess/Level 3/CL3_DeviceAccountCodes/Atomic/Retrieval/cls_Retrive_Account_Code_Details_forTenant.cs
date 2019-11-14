/* 
 * Generated on 9/17/2013 12:56:07 PM
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

namespace CL3_DeviceAccountCodes.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Retrive_Account_Code_Details_forTenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Retrive_Account_Code_Details_forTenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3DAC_RACDfT_1423_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3DAC_RACDfT_1423_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_DeviceAccountCodes.Atomic.Retrieval.SQL.cls_Retrive_Account_Code_Details_forTenant.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L3DAC_RACDfT_1423> results = new List<L3DAC_RACDfT_1423>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "Account_RefID","USR_Device_AccountCodeID","AccountCode_Value","AccountCode_ValidFrom","AccountCode_ValidTo","IsAccountCode_Expirable","AccountCode_CurrentStatus_RefID","AccountCode_NumberOfAccesses_MaximumValue","AccountCode_NumberOfAccesses_CurrentValue","Tenant_RefID","BusinessParticipant_RefID" });
				while(reader.Read())
				{
					L3DAC_RACDfT_1423 resultItem = new L3DAC_RACDfT_1423();
					//0:Parameter Account_RefID of type Guid
					resultItem.Account_RefID = reader.GetGuid(0);
					//1:Parameter USR_Device_AccountCodeID of type Guid
					resultItem.USR_Device_AccountCodeID = reader.GetGuid(1);
					//2:Parameter AccountCode_Value of type String
					resultItem.AccountCode_Value = reader.GetString(2);
					//3:Parameter AccountCode_ValidFrom of type DateTime
					resultItem.AccountCode_ValidFrom = reader.GetDate(3);
					//4:Parameter AccountCode_ValidTo of type DateTime
					resultItem.AccountCode_ValidTo = reader.GetDate(4);
					//5:Parameter IsAccountCode_Expirable of type bool
					resultItem.IsAccountCode_Expirable = reader.GetBoolean(5);
					//6:Parameter AccountCode_CurrentStatus_RefID of type Guid
					resultItem.AccountCode_CurrentStatus_RefID = reader.GetGuid(6);
					//7:Parameter AccountCode_NumberOfAccesses_MaximumValue of type String
					resultItem.AccountCode_NumberOfAccesses_MaximumValue = reader.GetString(7);
					//8:Parameter AccountCode_NumberOfAccesses_CurrentValue of type String
					resultItem.AccountCode_NumberOfAccesses_CurrentValue = reader.GetString(8);
					//9:Parameter Tenant_RefID of type Guid
					resultItem.Tenant_RefID = reader.GetGuid(9);
					//10:Parameter BusinessParticipant_RefID of type Guid
					resultItem.BusinessParticipant_RefID = reader.GetGuid(10);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Retrive_Account_Code_Details_forTenant",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = results.ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3DAC_RACDfT_1423_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3DAC_RACDfT_1423_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3DAC_RACDfT_1423_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3DAC_RACDfT_1423_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3DAC_RACDfT_1423_Array functionReturn = new FR_L3DAC_RACDfT_1423_Array();
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

				functionReturn = Execute(Connection, Transaction,securityTicket);

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

				throw new Exception("Exception occured in method cls_Retrive_Account_Code_Details_forTenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3DAC_RACDfT_1423_Array : FR_Base
	{
		public L3DAC_RACDfT_1423[] Result	{ get; set; } 
		public FR_L3DAC_RACDfT_1423_Array() : base() {}

		public FR_L3DAC_RACDfT_1423_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L3DAC_RACDfT_1423 for attribute L3DAC_RACDfT_1423
		[DataContract]
		public class L3DAC_RACDfT_1423 
		{
			//Standard type parameters
			[DataMember]
			public Guid Account_RefID { get; set; } 
			[DataMember]
			public Guid USR_Device_AccountCodeID { get; set; } 
			[DataMember]
			public String AccountCode_Value { get; set; } 
			[DataMember]
			public DateTime AccountCode_ValidFrom { get; set; } 
			[DataMember]
			public DateTime AccountCode_ValidTo { get; set; } 
			[DataMember]
			public bool IsAccountCode_Expirable { get; set; } 
			[DataMember]
			public Guid AccountCode_CurrentStatus_RefID { get; set; } 
			[DataMember]
			public String AccountCode_NumberOfAccesses_MaximumValue { get; set; } 
			[DataMember]
			public String AccountCode_NumberOfAccesses_CurrentValue { get; set; } 
			[DataMember]
			public Guid Tenant_RefID { get; set; } 
			[DataMember]
			public Guid BusinessParticipant_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3DAC_RACDfT_1423_Array cls_Retrive_Account_Code_Details_forTenant(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3DAC_RACDfT_1423_Array invocationResult = cls_Retrive_Account_Code_Details_forTenant.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

