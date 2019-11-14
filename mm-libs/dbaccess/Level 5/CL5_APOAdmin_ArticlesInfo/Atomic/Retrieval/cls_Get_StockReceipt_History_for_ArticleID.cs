/* 
 * Generated on 8/21/2014 1:54:54 PM
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

namespace CL5_APOAdmin_ArticlesInfo.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_StockReceipt_History_for_ArticleID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_StockReceipt_History_for_ArticleID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5AI_GSRHfA_1005_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5AI_GSRHfA_1005 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5AI_GSRHfA_1005_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOAdmin_ArticlesInfo.Atomic.Retrieval.SQL.cls_Get_StockReceipt_History_for_ArticleID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ArticleID", Parameter.ArticleID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"Tenant", Parameter.Tenant);



			List<L5AI_GSRHfA_1005> results = new List<L5AI_GSRHfA_1005>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "ProcurementOrder_Number","Position_Quantity","Position_ValueTotal","Creator","Supplier","TakenIntoStock_AtDate","ReceiptNumber" });
				while(reader.Read())
				{
					L5AI_GSRHfA_1005 resultItem = new L5AI_GSRHfA_1005();
					//0:Parameter ProcurementOrder_Number of type String
					resultItem.ProcurementOrder_Number = reader.GetString(0);
					//1:Parameter Position_Quantity of type String
					resultItem.Position_Quantity = reader.GetString(1);
					//2:Parameter Position_ValueTotal of type decimal
					resultItem.Position_ValueTotal = reader.GetDecimal(2);
					//3:Parameter Creator of type String
					resultItem.Creator = reader.GetString(3);
					//4:Parameter Supplier of type String
					resultItem.Supplier = reader.GetString(4);
					//5:Parameter TakenIntoStock_AtDate of type DateTime
					resultItem.TakenIntoStock_AtDate = reader.GetDate(5);
					//6:Parameter ReceiptNumber of type String
					resultItem.ReceiptNumber = reader.GetString(6);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_StockReceipt_History_for_ArticleID",ex);
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
		public static FR_L5AI_GSRHfA_1005_Array Invoke(string ConnectionString,P_L5AI_GSRHfA_1005 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5AI_GSRHfA_1005_Array Invoke(DbConnection Connection,P_L5AI_GSRHfA_1005 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5AI_GSRHfA_1005_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AI_GSRHfA_1005 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5AI_GSRHfA_1005_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AI_GSRHfA_1005 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5AI_GSRHfA_1005_Array functionReturn = new FR_L5AI_GSRHfA_1005_Array();
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

				throw new Exception("Exception occured in method cls_Get_StockReceipt_History_for_ArticleID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5AI_GSRHfA_1005_Array : FR_Base
	{
		public L5AI_GSRHfA_1005[] Result	{ get; set; } 
		public FR_L5AI_GSRHfA_1005_Array() : base() {}

		public FR_L5AI_GSRHfA_1005_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5AI_GSRHfA_1005 for attribute P_L5AI_GSRHfA_1005
		[DataContract]
		public class P_L5AI_GSRHfA_1005 
		{
			//Standard type parameters
			[DataMember]
			public Guid ArticleID { get; set; } 
			[DataMember]
			public Guid Tenant { get; set; } 

		}
		#endregion
		#region SClass L5AI_GSRHfA_1005 for attribute L5AI_GSRHfA_1005
		[DataContract]
		public class L5AI_GSRHfA_1005 
		{
			//Standard type parameters
			[DataMember]
			public String ProcurementOrder_Number { get; set; } 
			[DataMember]
			public String Position_Quantity { get; set; } 
			[DataMember]
			public decimal Position_ValueTotal { get; set; } 
			[DataMember]
			public String Creator { get; set; } 
			[DataMember]
			public String Supplier { get; set; } 
			[DataMember]
			public DateTime TakenIntoStock_AtDate { get; set; } 
			[DataMember]
			public String ReceiptNumber { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5AI_GSRHfA_1005_Array cls_Get_StockReceipt_History_for_ArticleID(,P_L5AI_GSRHfA_1005 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5AI_GSRHfA_1005_Array invocationResult = cls_Get_StockReceipt_History_for_ArticleID.Invoke(connectionString,P_L5AI_GSRHfA_1005 Parameter,securityTicket);
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
var parameter = new CL5_APOAdmin_ArticlesInfo.Atomic.Retrieval.P_L5AI_GSRHfA_1005();
parameter.ArticleID = ...;
parameter.Tenant = ...;

*/
