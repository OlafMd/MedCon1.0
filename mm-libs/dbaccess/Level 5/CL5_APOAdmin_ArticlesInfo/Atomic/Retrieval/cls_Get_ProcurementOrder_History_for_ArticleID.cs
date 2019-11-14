/* 
 * Generated on 8/21/2014 5:42:18 PM
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
    /// var result = cls_Get_ProcurementOrder_History_for_ArticleID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ProcurementOrder_History_for_ArticleID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5AI_GPOHfA_1434_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5AI_GPOHfA_1434 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5AI_GPOHfA_1434_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOAdmin_ArticlesInfo.Atomic.Retrieval.SQL.cls_Get_ProcurementOrder_History_for_ArticleID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ArticleID", Parameter.ArticleID);



			List<L5AI_GPOHfA_1434> results = new List<L5AI_GPOHfA_1434>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "ProcurementOrder_Number","Position_ValuePerUnit","Position_Quantity","Supplier","Creator","Position_RequestedDateOfDelivery","ExpectedDeliveryDate","TakenIntoStock_AtDate","IsTakenIntoStock" });
				while(reader.Read())
				{
					L5AI_GPOHfA_1434 resultItem = new L5AI_GPOHfA_1434();
					//0:Parameter ProcurementOrder_Number of type String
					resultItem.ProcurementOrder_Number = reader.GetString(0);
					//1:Parameter Position_ValuePerUnit of type decimal
					resultItem.Position_ValuePerUnit = reader.GetDecimal(1);
					//2:Parameter Position_Quantity of type String
					resultItem.Position_Quantity = reader.GetString(2);
					//3:Parameter Supplier of type String
					resultItem.Supplier = reader.GetString(3);
					//4:Parameter Creator of type String
					resultItem.Creator = reader.GetString(4);
					//5:Parameter Position_RequestedDateOfDelivery of type DateTime
					resultItem.Position_RequestedDateOfDelivery = reader.GetDate(5);
					//6:Parameter ExpectedDeliveryDate of type DateTime
					resultItem.ExpectedDeliveryDate = reader.GetDate(6);
					//7:Parameter TakenIntoStock_AtDate of type DateTime
					resultItem.TakenIntoStock_AtDate = reader.GetDate(7);
					//8:Parameter IsTakenIntoStock of type bool
					resultItem.IsTakenIntoStock = reader.GetBoolean(8);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_ProcurementOrder_History_for_ArticleID",ex);
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
		public static FR_L5AI_GPOHfA_1434_Array Invoke(string ConnectionString,P_L5AI_GPOHfA_1434 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5AI_GPOHfA_1434_Array Invoke(DbConnection Connection,P_L5AI_GPOHfA_1434 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5AI_GPOHfA_1434_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AI_GPOHfA_1434 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5AI_GPOHfA_1434_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AI_GPOHfA_1434 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5AI_GPOHfA_1434_Array functionReturn = new FR_L5AI_GPOHfA_1434_Array();
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

				throw new Exception("Exception occured in method cls_Get_ProcurementOrder_History_for_ArticleID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5AI_GPOHfA_1434_Array : FR_Base
	{
		public L5AI_GPOHfA_1434[] Result	{ get; set; } 
		public FR_L5AI_GPOHfA_1434_Array() : base() {}

		public FR_L5AI_GPOHfA_1434_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5AI_GPOHfA_1434 for attribute P_L5AI_GPOHfA_1434
		[DataContract]
		public class P_L5AI_GPOHfA_1434 
		{
			//Standard type parameters
			[DataMember]
			public Guid ArticleID { get; set; } 

		}
		#endregion
		#region SClass L5AI_GPOHfA_1434 for attribute L5AI_GPOHfA_1434
		[DataContract]
		public class L5AI_GPOHfA_1434 
		{
			//Standard type parameters
			[DataMember]
			public String ProcurementOrder_Number { get; set; } 
			[DataMember]
			public decimal Position_ValuePerUnit { get; set; } 
			[DataMember]
			public String Position_Quantity { get; set; } 
			[DataMember]
			public String Supplier { get; set; } 
			[DataMember]
			public String Creator { get; set; } 
			[DataMember]
			public DateTime Position_RequestedDateOfDelivery { get; set; } 
			[DataMember]
			public DateTime ExpectedDeliveryDate { get; set; } 
			[DataMember]
			public DateTime TakenIntoStock_AtDate { get; set; } 
			[DataMember]
			public bool IsTakenIntoStock { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5AI_GPOHfA_1434_Array cls_Get_ProcurementOrder_History_for_ArticleID(,P_L5AI_GPOHfA_1434 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5AI_GPOHfA_1434_Array invocationResult = cls_Get_ProcurementOrder_History_for_ArticleID.Invoke(connectionString,P_L5AI_GPOHfA_1434 Parameter,securityTicket);
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
var parameter = new CL5_APOAdmin_ArticlesInfo.Atomic.Retrieval.P_L5AI_GPOHfA_1434();
parameter.ArticleID = ...;

*/
