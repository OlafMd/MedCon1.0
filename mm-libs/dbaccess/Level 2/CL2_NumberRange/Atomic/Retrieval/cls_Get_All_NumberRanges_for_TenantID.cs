/* 
 * Generated on 5/30/2014 10:13:44 AM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 * Required Assemblies:
 * System.Runtime.Serialization
 * CSV2Core
 * CSV2Core_MySQL
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using System.Runtime.Serialization;

namespace CL2_NumberRange.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_All_NumberRanges_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_All_NumberRanges_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2NR_GANRfT_1628_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2NR_GANRfT_1628_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_NumberRange.Atomic.Retrieval.SQL.cls_Get_All_NumberRanges_for_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L2NR_GANRfT_1628> results = new List<L2NR_GANRfT_1628>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_NumberRangeID","NumberRange_UsageArea_RefID","NumberRange_Name","Value_Current","Value_Start","Value_End","FixedPrefix","Formatting_NumberLength","Formatting_LeadingFillCharacter","Creation_Timestamp","IsDeleted","Tenant_RefID" });
				while(reader.Read())
				{
					L2NR_GANRfT_1628 resultItem = new L2NR_GANRfT_1628();
					//0:Parameter CMN_NumberRangeID of type Guid
					resultItem.CMN_NumberRangeID = reader.GetGuid(0);
					//1:Parameter NumberRange_UsageArea_RefID of type Guid
					resultItem.NumberRange_UsageArea_RefID = reader.GetGuid(1);
					//2:Parameter NumberRange_Name of type String
					resultItem.NumberRange_Name = reader.GetString(2);
					//3:Parameter Value_Current of type long
					resultItem.Value_Current = reader.GetLong(3);
					//4:Parameter Value_Start of type long
					resultItem.Value_Start = reader.GetLong(4);
					//5:Parameter Value_End of type long
					resultItem.Value_End = reader.GetLong(5);
					//6:Parameter FixedPrefix of type String
					resultItem.FixedPrefix = reader.GetString(6);
					//7:Parameter Formatting_NumberLength of type int
					resultItem.Formatting_NumberLength = reader.GetInteger(7);
					//8:Parameter Formatting_LeadingFillCharacter of type String
					resultItem.Formatting_LeadingFillCharacter = reader.GetString(8);
					//9:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(9);
					//10:Parameter IsDeleted of type Boolean
					resultItem.IsDeleted = reader.GetBoolean(10);
					//11:Parameter Tenant_RefID of type Guid
					resultItem.Tenant_RefID = reader.GetGuid(11);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_All_NumberRanges_for_TenantID",ex);
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
		public static FR_L2NR_GANRfT_1628_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2NR_GANRfT_1628_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2NR_GANRfT_1628_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2NR_GANRfT_1628_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2NR_GANRfT_1628_Array functionReturn = new FR_L2NR_GANRfT_1628_Array();
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

				throw new Exception("Exception occured in method cls_Get_All_NumberRanges_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2NR_GANRfT_1628_Array : FR_Base
	{
		public L2NR_GANRfT_1628[] Result	{ get; set; } 
		public FR_L2NR_GANRfT_1628_Array() : base() {}

		public FR_L2NR_GANRfT_1628_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L2NR_GANRfT_1628 for attribute L2NR_GANRfT_1628
		[DataContract]
		public class L2NR_GANRfT_1628 
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
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 
			[DataMember]
			public Guid Tenant_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2NR_GANRfT_1628_Array cls_Get_All_NumberRanges_for_TenantID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2NR_GANRfT_1628_Array invocationResult = cls_Get_All_NumberRanges_for_TenantID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

