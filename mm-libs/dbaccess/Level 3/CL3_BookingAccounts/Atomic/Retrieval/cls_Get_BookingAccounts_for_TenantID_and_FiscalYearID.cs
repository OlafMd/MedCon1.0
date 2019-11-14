/* 
 * Generated on 9/9/2014 03:01:04
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

namespace CL3_BookingAccounts.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_BookingAccounts_for_TenantID_and_FiscalYearID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_BookingAccounts_for_TenantID_and_FiscalYearID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3BA_GBAfTaFYI_0930_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3BA_GBAfTaFYI_0930 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3BA_GBAfTaFYI_0930_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_BookingAccounts.Atomic.Retrieval.SQL.cls_Get_BookingAccounts_for_TenantID_and_FiscalYearID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"FiscalYearID", Parameter.FiscalYearID);



			List<L3BA_GBAfTaFYI_0930> results = new List<L3BA_GBAfTaFYI_0930>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "BookingAccountName","ACC_BOK_BookingAccountID","BookingAccountNumber","FiscalYearName","Tenant_RefID","ACC_FiscalYearID","StartDate","EndDate","IsDeleted" });
				while(reader.Read())
				{
					L3BA_GBAfTaFYI_0930 resultItem = new L3BA_GBAfTaFYI_0930();
					//0:Parameter BookingAccountName of type String
					resultItem.BookingAccountName = reader.GetString(0);
					//1:Parameter ACC_BOK_BookingAccountID of type Guid
					resultItem.ACC_BOK_BookingAccountID = reader.GetGuid(1);
					//2:Parameter BookingAccountNumber of type String
					resultItem.BookingAccountNumber = reader.GetString(2);
					//3:Parameter FiscalYearName of type String
					resultItem.FiscalYearName = reader.GetString(3);
					//4:Parameter Tenant_RefID of type Guid
					resultItem.Tenant_RefID = reader.GetGuid(4);
					//5:Parameter ACC_FiscalYearID of type Guid
					resultItem.ACC_FiscalYearID = reader.GetGuid(5);
					//6:Parameter StartDate of type DateTime
					resultItem.StartDate = reader.GetDate(6);
					//7:Parameter EndDate of type DateTime
					resultItem.EndDate = reader.GetDate(7);
					//8:Parameter IsDeleted of type bool
					resultItem.IsDeleted = reader.GetBoolean(8);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_BookingAccounts_for_TenantID_and_FiscalYearID",ex);
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
		public static FR_L3BA_GBAfTaFYI_0930_Array Invoke(string ConnectionString,P_L3BA_GBAfTaFYI_0930 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3BA_GBAfTaFYI_0930_Array Invoke(DbConnection Connection,P_L3BA_GBAfTaFYI_0930 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3BA_GBAfTaFYI_0930_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3BA_GBAfTaFYI_0930 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3BA_GBAfTaFYI_0930_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3BA_GBAfTaFYI_0930 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3BA_GBAfTaFYI_0930_Array functionReturn = new FR_L3BA_GBAfTaFYI_0930_Array();
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

				throw new Exception("Exception occured in method cls_Get_BookingAccounts_for_TenantID_and_FiscalYearID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3BA_GBAfTaFYI_0930_Array : FR_Base
	{
		public L3BA_GBAfTaFYI_0930[] Result	{ get; set; } 
		public FR_L3BA_GBAfTaFYI_0930_Array() : base() {}

		public FR_L3BA_GBAfTaFYI_0930_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3BA_GBAfTaFYI_0930 for attribute P_L3BA_GBAfTaFYI_0930
		[DataContract]
		public class P_L3BA_GBAfTaFYI_0930 
		{
			//Standard type parameters
			[DataMember]
			public Guid? FiscalYearID { get; set; } 

		}
		#endregion
		#region SClass L3BA_GBAfTaFYI_0930 for attribute L3BA_GBAfTaFYI_0930
		[DataContract]
		public class L3BA_GBAfTaFYI_0930 
		{
			//Standard type parameters
			[DataMember]
			public String BookingAccountName { get; set; } 
			[DataMember]
			public Guid ACC_BOK_BookingAccountID { get; set; } 
			[DataMember]
			public String BookingAccountNumber { get; set; } 
			[DataMember]
			public String FiscalYearName { get; set; } 
			[DataMember]
			public Guid Tenant_RefID { get; set; } 
			[DataMember]
			public Guid ACC_FiscalYearID { get; set; } 
			[DataMember]
			public DateTime StartDate { get; set; } 
			[DataMember]
			public DateTime EndDate { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3BA_GBAfTaFYI_0930_Array cls_Get_BookingAccounts_for_TenantID_and_FiscalYearID(,P_L3BA_GBAfTaFYI_0930 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3BA_GBAfTaFYI_0930_Array invocationResult = cls_Get_BookingAccounts_for_TenantID_and_FiscalYearID.Invoke(connectionString,P_L3BA_GBAfTaFYI_0930 Parameter,securityTicket);
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
var parameter = new CL3_BookingAccounts.Atomic.Retrieval.P_L3BA_GBAfTaFYI_0930();
parameter.FiscalYearID = ...;

*/