/* 
 * Generated on 7/10/2014 5:39:13 PM
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

namespace CL5_APOBilling_Bill.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Payments_with_Installments_for_BillHeader.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Payments_with_Installments_for_BillHeader
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5BL_GPwIfBH_1009_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5BL_GPwIfBH_1009 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5BL_GPwIfBH_1009_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOBilling_Bill.Atomic.Retrieval.SQL.cls_Get_Payments_with_Installments_for_BillHeader.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"BillHeaderID", Parameter.BillHeaderID);



			List<L5BL_GPwIfBH_1009> results = new List<L5BL_GPwIfBH_1009>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "ACC_IPL_InstallmentID","ACC_IPL_Installment_2_AssignedPaymentID","ExpectedAmount","Payment_PayedOnDate","PayedAmount","PaymentDeadline","PayedOnDate","Installment_IsFullyPaid" });
				while(reader.Read())
				{
					L5BL_GPwIfBH_1009 resultItem = new L5BL_GPwIfBH_1009();
					//0:Parameter ACC_IPL_InstallmentID of type Guid
					resultItem.ACC_IPL_InstallmentID = reader.GetGuid(0);
					//1:Parameter ACC_IPL_Installment_2_AssignedPaymentID of type Guid
					resultItem.ACC_IPL_Installment_2_AssignedPaymentID = reader.GetGuid(1);
					//2:Parameter ExpectedAmount of type Decimal
					resultItem.ExpectedAmount = reader.GetDecimal(2);
					//3:Parameter Payment_PayedOnDate of type DateTime
					resultItem.Payment_PayedOnDate = reader.GetDate(3);
					//4:Parameter PayedAmount of type Decimal
					resultItem.PayedAmount = reader.GetDecimal(4);
					//5:Parameter PaymentDeadline of type DateTime
					resultItem.PaymentDeadline = reader.GetDate(5);
					//6:Parameter PayedOnDate of type DateTime
					resultItem.PayedOnDate = reader.GetDate(6);
					//7:Parameter Installment_IsFullyPaid of type Boolean
					resultItem.Installment_IsFullyPaid = reader.GetBoolean(7);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Payments_with_Installments_for_BillHeader",ex);
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
		public static FR_L5BL_GPwIfBH_1009_Array Invoke(string ConnectionString,P_L5BL_GPwIfBH_1009 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5BL_GPwIfBH_1009_Array Invoke(DbConnection Connection,P_L5BL_GPwIfBH_1009 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5BL_GPwIfBH_1009_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5BL_GPwIfBH_1009 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5BL_GPwIfBH_1009_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5BL_GPwIfBH_1009 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5BL_GPwIfBH_1009_Array functionReturn = new FR_L5BL_GPwIfBH_1009_Array();
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

				throw new Exception("Exception occured in method cls_Get_Payments_with_Installments_for_BillHeader",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5BL_GPwIfBH_1009_Array : FR_Base
	{
		public L5BL_GPwIfBH_1009[] Result	{ get; set; } 
		public FR_L5BL_GPwIfBH_1009_Array() : base() {}

		public FR_L5BL_GPwIfBH_1009_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5BL_GPwIfBH_1009 for attribute P_L5BL_GPwIfBH_1009
		[DataContract]
		public class P_L5BL_GPwIfBH_1009 
		{
			//Standard type parameters
			[DataMember]
			public Guid BillHeaderID { get; set; } 

		}
		#endregion
		#region SClass L5BL_GPwIfBH_1009 for attribute L5BL_GPwIfBH_1009
		[DataContract]
		public class L5BL_GPwIfBH_1009 
		{
			//Standard type parameters
			[DataMember]
			public Guid ACC_IPL_InstallmentID { get; set; } 
			[DataMember]
			public Guid ACC_IPL_Installment_2_AssignedPaymentID { get; set; } 
			[DataMember]
			public Decimal ExpectedAmount { get; set; } 
			[DataMember]
			public DateTime Payment_PayedOnDate { get; set; } 
			[DataMember]
			public Decimal PayedAmount { get; set; } 
			[DataMember]
			public DateTime PaymentDeadline { get; set; } 
			[DataMember]
			public DateTime PayedOnDate { get; set; } 
			[DataMember]
			public Boolean Installment_IsFullyPaid { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5BL_GPwIfBH_1009_Array cls_Get_Payments_with_Installments_for_BillHeader(,P_L5BL_GPwIfBH_1009 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5BL_GPwIfBH_1009_Array invocationResult = cls_Get_Payments_with_Installments_for_BillHeader.Invoke(connectionString,P_L5BL_GPwIfBH_1009 Parameter,securityTicket);
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
var parameter = new CL5_APOBilling_Bill.Atomic.Retrieval.P_L5BL_GPwIfBH_1009();
parameter.BillHeaderID = ...;

*/
