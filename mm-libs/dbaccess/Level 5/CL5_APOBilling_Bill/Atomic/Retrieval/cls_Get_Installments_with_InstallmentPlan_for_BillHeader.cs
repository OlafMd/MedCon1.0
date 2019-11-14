/* 
 * Generated on 5/8/2014 12:49:51 PM
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
    /// var result = cls_Get_Installments_with_InstallmentPlan_for_BillHeader.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Installments_with_InstallmentPlan_for_BillHeader
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5BL_GIwIP_fBH_1306_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5BL_GIwIP_fBH_1306 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5BL_GIwIP_fBH_1306_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOBilling_Bill.Atomic.Retrieval.SQL.cls_Get_Installments_with_InstallmentPlan_for_BillHeader.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"BillHeaderID", Parameter.BillHeaderID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"IsFullyPaid", Parameter.IsFullyPaid);



			List<L5BL_GIwIP_fBH_1306> results = new List<L5BL_GIwIP_fBH_1306>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "ACC_IPL_InstallmentPlanID","ACC_IPL_InstallmentID","Amount","PaymentDeadline","IsFullyPaid" });
				while(reader.Read())
				{
					L5BL_GIwIP_fBH_1306 resultItem = new L5BL_GIwIP_fBH_1306();
					//0:Parameter ACC_IPL_InstallmentPlanID of type Guid
					resultItem.ACC_IPL_InstallmentPlanID = reader.GetGuid(0);
					//1:Parameter ACC_IPL_InstallmentID of type Guid
					resultItem.ACC_IPL_InstallmentID = reader.GetGuid(1);
					//2:Parameter Amount of type Decimal
					resultItem.Amount = reader.GetDecimal(2);
					//3:Parameter PaymentDeadline of type DateTime
					resultItem.PaymentDeadline = reader.GetDate(3);
					//4:Parameter IsFullyPaid of type Boolean
					resultItem.IsFullyPaid = reader.GetBoolean(4);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Installments_with_InstallmentPlan_for_BillHeader",ex);
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
		public static FR_L5BL_GIwIP_fBH_1306_Array Invoke(string ConnectionString,P_L5BL_GIwIP_fBH_1306 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5BL_GIwIP_fBH_1306_Array Invoke(DbConnection Connection,P_L5BL_GIwIP_fBH_1306 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5BL_GIwIP_fBH_1306_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5BL_GIwIP_fBH_1306 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5BL_GIwIP_fBH_1306_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5BL_GIwIP_fBH_1306 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5BL_GIwIP_fBH_1306_Array functionReturn = new FR_L5BL_GIwIP_fBH_1306_Array();
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

				throw new Exception("Exception occured in method cls_Get_Installments_with_InstallmentPlan_for_BillHeader",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5BL_GIwIP_fBH_1306_Array : FR_Base
	{
		public L5BL_GIwIP_fBH_1306[] Result	{ get; set; } 
		public FR_L5BL_GIwIP_fBH_1306_Array() : base() {}

		public FR_L5BL_GIwIP_fBH_1306_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5BL_GIwIP_fBH_1306 for attribute P_L5BL_GIwIP_fBH_1306
		[DataContract]
		public class P_L5BL_GIwIP_fBH_1306 
		{
			//Standard type parameters
			[DataMember]
			public Guid BillHeaderID { get; set; } 
			[DataMember]
			public Boolean? IsFullyPaid { get; set; } 

		}
		#endregion
		#region SClass L5BL_GIwIP_fBH_1306 for attribute L5BL_GIwIP_fBH_1306
		[DataContract]
		public class L5BL_GIwIP_fBH_1306 
		{
			//Standard type parameters
			[DataMember]
			public Guid ACC_IPL_InstallmentPlanID { get; set; } 
			[DataMember]
			public Guid ACC_IPL_InstallmentID { get; set; } 
			[DataMember]
			public Decimal Amount { get; set; } 
			[DataMember]
			public DateTime PaymentDeadline { get; set; } 
			[DataMember]
			public Boolean IsFullyPaid { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5BL_GIwIP_fBH_1306_Array cls_Get_Installments_with_InstallmentPlan_for_BillHeader(,P_L5BL_GIwIP_fBH_1306 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5BL_GIwIP_fBH_1306_Array invocationResult = cls_Get_Installments_with_InstallmentPlan_for_BillHeader.Invoke(connectionString,P_L5BL_GIwIP_fBH_1306 Parameter,securityTicket);
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
var parameter = new CL5_APOBilling_Bill.Atomic.Retrieval.P_L5BL_GIwIP_fBH_1306();
parameter.BillHeaderID = ...;
parameter.IsFullyPaid = ...;

*/
