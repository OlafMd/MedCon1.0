/* 
 * Generated on 11/11/2014 2:43:29 PM
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

namespace CL2_DiscountAmounts.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_DiscountAmounts_for_ReceiptPositionIDs.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_DiscountAmounts_for_ReceiptPositionIDs
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2DA_GDAfRP_1409_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L2DA_GDAfRP_1409 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2DA_GDAfRP_1409_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_DiscountAmounts.Atomic.Retrieval.SQL.cls_Get_DiscountAmounts_for_ReceiptPositionIDs.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@ReceiptPositionsID"," IN $$ReceiptPositionsID$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$ReceiptPositionsID$",Parameter.ReceiptPositionsID);


			List<L2DA_GDAfRP_1409> results = new List<L2DA_GDAfRP_1409>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "LOG_RCP_Receipt_Position_DiscountAmountID","LOG_RCP_Receipt_Position_RefID","ORD_PRC_DiscountType_RefID","IsAbsoluteValue","IsRelativeValue","PositionDiscountValue" });
				while(reader.Read())
				{
					L2DA_GDAfRP_1409 resultItem = new L2DA_GDAfRP_1409();
					//0:Parameter LOG_RCP_Receipt_Position_DiscountAmountID of type Guid
					resultItem.LOG_RCP_Receipt_Position_DiscountAmountID = reader.GetGuid(0);
					//1:Parameter LOG_RCP_Receipt_Position_RefID of type Guid
					resultItem.LOG_RCP_Receipt_Position_RefID = reader.GetGuid(1);
					//2:Parameter ORD_PRC_DiscountType_RefID of type Guid
					resultItem.ORD_PRC_DiscountType_RefID = reader.GetGuid(2);
					//3:Parameter IsAbsoluteValue of type bool
					resultItem.IsAbsoluteValue = reader.GetBoolean(3);
					//4:Parameter IsRelativeValue of type bool
					resultItem.IsRelativeValue = reader.GetBoolean(4);
					//5:Parameter PositionDiscountValue of type double
					resultItem.PositionDiscountValue = reader.GetDouble(5);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_DiscountAmounts_for_ReceiptPositionIDs",ex);
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
		public static FR_L2DA_GDAfRP_1409_Array Invoke(string ConnectionString,P_L2DA_GDAfRP_1409 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2DA_GDAfRP_1409_Array Invoke(DbConnection Connection,P_L2DA_GDAfRP_1409 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2DA_GDAfRP_1409_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L2DA_GDAfRP_1409 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2DA_GDAfRP_1409_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2DA_GDAfRP_1409 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2DA_GDAfRP_1409_Array functionReturn = new FR_L2DA_GDAfRP_1409_Array();
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

				throw new Exception("Exception occured in method cls_Get_DiscountAmounts_for_ReceiptPositionIDs",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2DA_GDAfRP_1409_Array : FR_Base
	{
		public L2DA_GDAfRP_1409[] Result	{ get; set; } 
		public FR_L2DA_GDAfRP_1409_Array() : base() {}

		public FR_L2DA_GDAfRP_1409_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L2DA_GDAfRP_1409 for attribute P_L2DA_GDAfRP_1409
		[DataContract]
		public class P_L2DA_GDAfRP_1409 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] ReceiptPositionsID { get; set; } 

		}
		#endregion
		#region SClass L2DA_GDAfRP_1409 for attribute L2DA_GDAfRP_1409
		[DataContract]
		public class L2DA_GDAfRP_1409 
		{
			//Standard type parameters
			[DataMember]
			public Guid LOG_RCP_Receipt_Position_DiscountAmountID { get; set; } 
			[DataMember]
			public Guid LOG_RCP_Receipt_Position_RefID { get; set; } 
			[DataMember]
			public Guid ORD_PRC_DiscountType_RefID { get; set; } 
			[DataMember]
			public bool IsAbsoluteValue { get; set; } 
			[DataMember]
			public bool IsRelativeValue { get; set; } 
			[DataMember]
			public double PositionDiscountValue { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2DA_GDAfRP_1409_Array cls_Get_DiscountAmounts_for_ReceiptPositionIDs(,P_L2DA_GDAfRP_1409 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2DA_GDAfRP_1409_Array invocationResult = cls_Get_DiscountAmounts_for_ReceiptPositionIDs.Invoke(connectionString,P_L2DA_GDAfRP_1409 Parameter,securityTicket);
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
var parameter = new CL2_DiscountAmounts.Atomic.Retrieval.P_L2DA_GDAfRP_1409();
parameter.ReceiptPositionsID = ...;

*/
