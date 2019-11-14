/* 
 * Generated on 9/16/2014 4:47:10 PM
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
using CSV2Core_MySQL.Dictionaries.MultiTable;
using System.Runtime.Serialization;

namespace CL5_APOAdmin_ArticlesInfo.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Open_Expected_Delivery_for_ArticleID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Open_Expected_Delivery_for_ArticleID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5AI_GOEDfA_1635_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5AI_GOEDfA_1635 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5AI_GOEDfA_1635_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOAdmin_ArticlesInfo.Atomic.Retrieval.SQL.cls_Get_Open_Expected_Delivery_for_ArticleID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ProductID", Parameter.ProductID);



			List<L5AI_GOEDfA_1635> results = new List<L5AI_GOEDfA_1635>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "ProcurementOrder_Number","DisplayName","Status_Name_DictID","TotalExpectedQuantity","ExpectedDeliveryDate","IsDeliveryOpen" });
				while(reader.Read())
				{
					L5AI_GOEDfA_1635 resultItem = new L5AI_GOEDfA_1635();
					//0:Parameter ProcurementOrder_Number of type String
					resultItem.ProcurementOrder_Number = reader.GetString(0);
					//1:Parameter DisplayName of type String
					resultItem.DisplayName = reader.GetString(1);
					//2:Parameter Status_Name of type Dict
					resultItem.Status_Name = reader.GetDictionary(2);
					resultItem.Status_Name.SourceTable = "ord_prc_procurementorder_statuses";
					loader.Append(resultItem.Status_Name);
					//3:Parameter TotalExpectedQuantity of type double
					resultItem.TotalExpectedQuantity = reader.GetDouble(3);
					//4:Parameter ExpectedDeliveryDate of type DateTime
					resultItem.ExpectedDeliveryDate = reader.GetDate(4);
					//5:Parameter IsDeliveryOpen of type bool
					resultItem.IsDeliveryOpen = reader.GetBoolean(5);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Open_Expected_Delivery_for_ArticleID",ex);
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
		public static FR_L5AI_GOEDfA_1635_Array Invoke(string ConnectionString,P_L5AI_GOEDfA_1635 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5AI_GOEDfA_1635_Array Invoke(DbConnection Connection,P_L5AI_GOEDfA_1635 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5AI_GOEDfA_1635_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AI_GOEDfA_1635 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5AI_GOEDfA_1635_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AI_GOEDfA_1635 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5AI_GOEDfA_1635_Array functionReturn = new FR_L5AI_GOEDfA_1635_Array();
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

				throw new Exception("Exception occured in method cls_Get_Open_Expected_Delivery_for_ArticleID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5AI_GOEDfA_1635_Array : FR_Base
	{
		public L5AI_GOEDfA_1635[] Result	{ get; set; } 
		public FR_L5AI_GOEDfA_1635_Array() : base() {}

		public FR_L5AI_GOEDfA_1635_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5AI_GOEDfA_1635 for attribute P_L5AI_GOEDfA_1635
		[DataContract]
		public class P_L5AI_GOEDfA_1635 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProductID { get; set; } 

		}
		#endregion
		#region SClass L5AI_GOEDfA_1635 for attribute L5AI_GOEDfA_1635
		[DataContract]
		public class L5AI_GOEDfA_1635 
		{
			//Standard type parameters
			[DataMember]
			public String ProcurementOrder_Number { get; set; } 
			[DataMember]
			public String DisplayName { get; set; } 
			[DataMember]
			public Dict Status_Name { get; set; } 
			[DataMember]
			public double TotalExpectedQuantity { get; set; } 
			[DataMember]
			public DateTime ExpectedDeliveryDate { get; set; } 
			[DataMember]
			public bool IsDeliveryOpen { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5AI_GOEDfA_1635_Array cls_Get_Open_Expected_Delivery_for_ArticleID(,P_L5AI_GOEDfA_1635 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5AI_GOEDfA_1635_Array invocationResult = cls_Get_Open_Expected_Delivery_for_ArticleID.Invoke(connectionString,P_L5AI_GOEDfA_1635 Parameter,securityTicket);
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
var parameter = new CL5_APOAdmin_ArticlesInfo.Atomic.Retrieval.P_L5AI_GOEDfA_1635();
parameter.ProductID = ...;

*/
