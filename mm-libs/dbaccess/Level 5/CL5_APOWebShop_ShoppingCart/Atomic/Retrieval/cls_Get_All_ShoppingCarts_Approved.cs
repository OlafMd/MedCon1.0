/* 
 * Generated on 25/9/2014 11:08:47
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

namespace CL5_APOWebShop_ShoppingCart.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_All_ShoppingCarts_Approved.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_All_ShoppingCarts_Approved
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5AWSSC_GASC_1414_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5AWSSC_GASC_1414 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5AWSSC_GASC_1414_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOWebShop_ShoppingCart.Atomic.Retrieval.SQL.cls_Get_All_ShoppingCarts_Approved.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"NumberOfLastDays", Parameter.NumberOfLastDays);

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@Status_GlobalPropertyMatchingID_List"," IN $$Status_GlobalPropertyMatchingID_List$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$Status_GlobalPropertyMatchingID_List$",Parameter.Status_GlobalPropertyMatchingID_List);
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ProductNameContains", Parameter.ProductNameContains);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ApprovedGlobalPropertyID", Parameter.ApprovedGlobalPropertyID);



			List<L5AWSSC_GASC_1414> results = new List<L5AWSSC_GASC_1414>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "ORD_PRC_ShoppingCartID","IsProcurementOrderCreated","InternalIdentifier","ShoppingCart_CreationDate","CMN_STR_OfficeID","Office_Name_DictID","Office_InternalName","ProcurementOrder_Date","ProcurementOrderStatus","Status_GlobalPropertyMatchingID","Creation_Timestamp","ApprovedDate" });
				while(reader.Read())
				{
					L5AWSSC_GASC_1414 resultItem = new L5AWSSC_GASC_1414();
					//0:Parameter ORD_PRC_ShoppingCartID of type Guid
					resultItem.ORD_PRC_ShoppingCartID = reader.GetGuid(0);
					//1:Parameter IsProcurementOrderCreated of type bool
					resultItem.IsProcurementOrderCreated = reader.GetBoolean(1);
					//2:Parameter InternalIdentifier of type String
					resultItem.InternalIdentifier = reader.GetString(2);
					//3:Parameter ShoppingCart_CreationDate of type DateTime
					resultItem.ShoppingCart_CreationDate = reader.GetDate(3);
					//4:Parameter CMN_STR_OfficeID of type Guid
					resultItem.CMN_STR_OfficeID = reader.GetGuid(4);
					//5:Parameter Office_Name of type Dict
					resultItem.Office_Name = reader.GetDictionary(5);
					resultItem.Office_Name.SourceTable = "cmn_str_offices";
					loader.Append(resultItem.Office_Name);
					//6:Parameter Office_InternalName of type String
					resultItem.Office_InternalName = reader.GetString(6);
					//7:Parameter ProcurementOrder_Date of type DateTime
					resultItem.ProcurementOrder_Date = reader.GetDate(7);
					//8:Parameter ProcurementOrderStatus of type String
					resultItem.ProcurementOrderStatus = reader.GetString(8);
					//9:Parameter Status_GlobalPropertyMatchingID of type String
					resultItem.Status_GlobalPropertyMatchingID = reader.GetString(9);
					//10:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(10);
					//11:Parameter ApprovedDate of type DateTime
					resultItem.ApprovedDate = reader.GetDate(11);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_All_ShoppingCarts_Approved",ex);
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
		public static FR_L5AWSSC_GASC_1414_Array Invoke(string ConnectionString,P_L5AWSSC_GASC_1414 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5AWSSC_GASC_1414_Array Invoke(DbConnection Connection,P_L5AWSSC_GASC_1414 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5AWSSC_GASC_1414_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AWSSC_GASC_1414 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5AWSSC_GASC_1414_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AWSSC_GASC_1414 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5AWSSC_GASC_1414_Array functionReturn = new FR_L5AWSSC_GASC_1414_Array();
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

				throw new Exception("Exception occured in method cls_Get_All_ShoppingCarts_Approved",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5AWSSC_GASC_1414_Array : FR_Base
	{
		public L5AWSSC_GASC_1414[] Result	{ get; set; } 
		public FR_L5AWSSC_GASC_1414_Array() : base() {}

		public FR_L5AWSSC_GASC_1414_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5AWSSC_GASC_1414 for attribute P_L5AWSSC_GASC_1414
		[DataContract]
		public class P_L5AWSSC_GASC_1414 
		{
			//Standard type parameters
			[DataMember]
			public int? NumberOfLastDays { get; set; } 
			[DataMember]
			public string[] Status_GlobalPropertyMatchingID_List { get; set; } 
			[DataMember]
			public string ProductNameContains { get; set; } 
			[DataMember]
			public string ApprovedGlobalPropertyID { get; set; } 

		}
		#endregion
		#region SClass L5AWSSC_GASC_1414 for attribute L5AWSSC_GASC_1414
		[DataContract]
		public class L5AWSSC_GASC_1414 
		{
			//Standard type parameters
			[DataMember]
			public Guid ORD_PRC_ShoppingCartID { get; set; } 
			[DataMember]
			public bool IsProcurementOrderCreated { get; set; } 
			[DataMember]
			public String InternalIdentifier { get; set; } 
			[DataMember]
			public DateTime ShoppingCart_CreationDate { get; set; } 
			[DataMember]
			public Guid CMN_STR_OfficeID { get; set; } 
			[DataMember]
			public Dict Office_Name { get; set; } 
			[DataMember]
			public String Office_InternalName { get; set; } 
			[DataMember]
			public DateTime ProcurementOrder_Date { get; set; } 
			[DataMember]
			public String ProcurementOrderStatus { get; set; } 
			[DataMember]
			public String Status_GlobalPropertyMatchingID { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public DateTime ApprovedDate { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5AWSSC_GASC_1414_Array cls_Get_All_ShoppingCarts_Approved(,P_L5AWSSC_GASC_1414 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5AWSSC_GASC_1414_Array invocationResult = cls_Get_All_ShoppingCarts_Approved.Invoke(connectionString,P_L5AWSSC_GASC_1414 Parameter,securityTicket);
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
var parameter = new CL5_APOWebShop_ShoppingCart.Atomic.Retrieval.P_L5AWSSC_GASC_1414();
parameter.NumberOfLastDays = ...;
parameter.Status_GlobalPropertyMatchingID_List = ...;
parameter.ProductNameContains = ...;
parameter.ApprovedGlobalPropertyID = ...;

*/
