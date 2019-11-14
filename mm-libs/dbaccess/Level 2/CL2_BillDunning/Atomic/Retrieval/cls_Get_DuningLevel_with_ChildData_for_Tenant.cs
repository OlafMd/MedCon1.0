/* 
 * Generated on 7/8/2014 9:36:43 AM
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

namespace CL2_BillDunning.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_DuningLevel_with_ChildData_for_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_DuningLevel_with_ChildData_for_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2BD_GDLwCDfT_1651_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2BD_GDLwCDfT_1651_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_BillDunning.Atomic.Retrieval.SQL.cls_Get_DuningLevel_with_ChildData_for_Tenant.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L2BD_GDLwCDfT_1651> results = new List<L2BD_GDLwCDfT_1651>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "parID","GlobalPropertyMatchingID","ParentLevel_RefID","childID","childGlobalPropertyMatchingID","OrderSequence","DunningFee","WaitPeriodToNextDunningLevel_In_Days","ACC_DUN_DunningLevel_ModelAssignmentID" });
				while(reader.Read())
				{
					L2BD_GDLwCDfT_1651 resultItem = new L2BD_GDLwCDfT_1651();
					//0:Parameter parID of type Guid
					resultItem.parID = reader.GetGuid(0);
					//1:Parameter GlobalPropertyMatchingID of type String
					resultItem.GlobalPropertyMatchingID = reader.GetString(1);
					//2:Parameter ParentLevel_RefID of type Guid
					resultItem.ParentLevel_RefID = reader.GetGuid(2);
					//3:Parameter childID of type Guid
					resultItem.childID = reader.GetGuid(3);
					//4:Parameter childGlobalPropertyMatchingID of type String
					resultItem.childGlobalPropertyMatchingID = reader.GetString(4);
					//5:Parameter OrderSequence of type int
					resultItem.OrderSequence = reader.GetInteger(5);
					//6:Parameter DunningFee of type Decimal
					resultItem.DunningFee = reader.GetDecimal(6);
					//7:Parameter WaitPeriodToNextDunningLevel_In_Days of type String
					resultItem.WaitPeriodToNextDunningLevel_In_Days = reader.GetString(7);
					//8:Parameter ACC_DUN_DunningLevel_ModelAssignmentID of type Guid
					resultItem.ACC_DUN_DunningLevel_ModelAssignmentID = reader.GetGuid(8);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_DuningLevel_with_ChildData_for_Tenant",ex);
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
		public static FR_L2BD_GDLwCDfT_1651_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2BD_GDLwCDfT_1651_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2BD_GDLwCDfT_1651_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2BD_GDLwCDfT_1651_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2BD_GDLwCDfT_1651_Array functionReturn = new FR_L2BD_GDLwCDfT_1651_Array();
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

				throw new Exception("Exception occured in method cls_Get_DuningLevel_with_ChildData_for_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2BD_GDLwCDfT_1651_Array : FR_Base
	{
		public L2BD_GDLwCDfT_1651[] Result	{ get; set; } 
		public FR_L2BD_GDLwCDfT_1651_Array() : base() {}

		public FR_L2BD_GDLwCDfT_1651_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L2BD_GDLwCDfT_1651 for attribute L2BD_GDLwCDfT_1651
		[DataContract]
		public class L2BD_GDLwCDfT_1651 
		{
			//Standard type parameters
			[DataMember]
			public Guid parID { get; set; } 
			[DataMember]
			public String GlobalPropertyMatchingID { get; set; } 
			[DataMember]
			public Guid ParentLevel_RefID { get; set; } 
			[DataMember]
			public Guid childID { get; set; } 
			[DataMember]
			public String childGlobalPropertyMatchingID { get; set; } 
			[DataMember]
			public int OrderSequence { get; set; } 
			[DataMember]
			public Decimal DunningFee { get; set; } 
			[DataMember]
			public String WaitPeriodToNextDunningLevel_In_Days { get; set; } 
			[DataMember]
			public Guid ACC_DUN_DunningLevel_ModelAssignmentID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2BD_GDLwCDfT_1651_Array cls_Get_DuningLevel_with_ChildData_for_Tenant(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2BD_GDLwCDfT_1651_Array invocationResult = cls_Get_DuningLevel_with_ChildData_for_Tenant.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

