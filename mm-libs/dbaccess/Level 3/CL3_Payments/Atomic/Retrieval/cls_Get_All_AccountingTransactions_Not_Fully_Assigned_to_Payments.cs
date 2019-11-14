/* 
 * Generated on 6/3/2014 12:56:55 PM
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

namespace CL3_Payments.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_All_AccountingTransactions_Not_Fully_Assigned_to_Payments.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_All_AccountingTransactions_Not_Fully_Assigned_to_Payments
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3PY_GAATNFAtP_0846_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3PY_GAATNFAtP_0846 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3PY_GAATNFAtP_0846_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_Payments.Atomic.Retrieval.SQL.cls_Get_All_AccountingTransactions_Not_Fully_Assigned_to_Payments.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"BusinessParticipantID", Parameter.BusinessParticipantID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"FiscalYearID", Parameter.FiscalYearID);



			List<L3PY_GAATNFAtP_0846> results = new List<L3PY_GAATNFAtP_0846>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "TotalTransactionValue","AssignedTransactionValue","UnassignedTransactionValue","AccountingTransactionID" });
				while(reader.Read())
				{
					L3PY_GAATNFAtP_0846 resultItem = new L3PY_GAATNFAtP_0846();
					//0:Parameter TotalTransactionValue of type Decimal
					resultItem.TotalTransactionValue = reader.GetDecimal(0);
					//1:Parameter AssignedTransactionValue of type Decimal
					resultItem.AssignedTransactionValue = reader.GetDecimal(1);
					//2:Parameter UnassignedTransactionValue of type Decimal
					resultItem.UnassignedTransactionValue = reader.GetDecimal(2);
					//3:Parameter AccountingTransactionID of type Guid
					resultItem.AccountingTransactionID = reader.GetGuid(3);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_All_AccountingTransactions_Not_Fully_Assigned_to_Payments",ex);
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
		public static FR_L3PY_GAATNFAtP_0846_Array Invoke(string ConnectionString,P_L3PY_GAATNFAtP_0846 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3PY_GAATNFAtP_0846_Array Invoke(DbConnection Connection,P_L3PY_GAATNFAtP_0846 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3PY_GAATNFAtP_0846_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3PY_GAATNFAtP_0846 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3PY_GAATNFAtP_0846_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3PY_GAATNFAtP_0846 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3PY_GAATNFAtP_0846_Array functionReturn = new FR_L3PY_GAATNFAtP_0846_Array();
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

				throw new Exception("Exception occured in method cls_Get_All_AccountingTransactions_Not_Fully_Assigned_to_Payments",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3PY_GAATNFAtP_0846_Array : FR_Base
	{
		public L3PY_GAATNFAtP_0846[] Result	{ get; set; } 
		public FR_L3PY_GAATNFAtP_0846_Array() : base() {}

		public FR_L3PY_GAATNFAtP_0846_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3PY_GAATNFAtP_0846 for attribute P_L3PY_GAATNFAtP_0846
		[DataContract]
		public class P_L3PY_GAATNFAtP_0846 
		{
			//Standard type parameters
			[DataMember]
			public Guid BusinessParticipantID { get; set; } 
			[DataMember]
			public Guid FiscalYearID { get; set; } 

		}
		#endregion
		#region SClass L3PY_GAATNFAtP_0846 for attribute L3PY_GAATNFAtP_0846
		[DataContract]
		public class L3PY_GAATNFAtP_0846 
		{
			//Standard type parameters
			[DataMember]
			public Decimal TotalTransactionValue { get; set; } 
			[DataMember]
			public Decimal AssignedTransactionValue { get; set; } 
			[DataMember]
			public Decimal UnassignedTransactionValue { get; set; } 
			[DataMember]
			public Guid AccountingTransactionID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3PY_GAATNFAtP_0846_Array cls_Get_All_AccountingTransactions_Not_Fully_Assigned_to_Payments(,P_L3PY_GAATNFAtP_0846 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3PY_GAATNFAtP_0846_Array invocationResult = cls_Get_All_AccountingTransactions_Not_Fully_Assigned_to_Payments.Invoke(connectionString,P_L3PY_GAATNFAtP_0846 Parameter,securityTicket);
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
var parameter = new CL3_Payments.Atomic.Retrieval.P_L3PY_GAATNFAtP_0846();
parameter.BusinessParticipantID = ...;
parameter.FiscalYearID = ...;

*/
