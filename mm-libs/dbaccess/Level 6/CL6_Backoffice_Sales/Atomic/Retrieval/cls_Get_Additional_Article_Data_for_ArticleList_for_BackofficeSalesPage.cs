/* 
 * Generated on 4/28/2014 7:38:02 PM
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

namespace CL6_Backoffice_Sales.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Additional_Article_Data_for_ArticleList_for_BackofficeSalesPage.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Additional_Article_Data_for_ArticleList_for_BackofficeSalesPage
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6SA_GAADfALfBSP_1115_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L6SA_GAADfALfBSP_1115 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L6SA_GAADfALfBSP_1115_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL6_Backoffice_Sales.Atomic.Retrieval.SQL.cls_Get_Additional_Article_Data_for_ArticleList_for_BackofficeSalesPage.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@ArticleList"," IN $$ArticleList$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$ArticleList$",Parameter.ArticleList);


			List<L6SA_GAADfALfBSP_1115> results = new List<L6SA_GAADfALfBSP_1115>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_PRO_ProductID","IsStorage_BatchNumberMandatory","IsStorage_ExpiryDateMandatory","StockQuantity" });
				while(reader.Read())
				{
					L6SA_GAADfALfBSP_1115 resultItem = new L6SA_GAADfALfBSP_1115();
					//0:Parameter CMN_PRO_ProductID of type Guid
					resultItem.CMN_PRO_ProductID = reader.GetGuid(0);
					//1:Parameter IsStorage_BatchNumberMandatory of type Boolean
					resultItem.IsStorage_BatchNumberMandatory = reader.GetBoolean(1);
					//2:Parameter IsStorage_ExpiryDateMandatory of type Boolean
					resultItem.IsStorage_ExpiryDateMandatory = reader.GetBoolean(2);
					//3:Parameter StockQuantity of type Double
					resultItem.StockQuantity = reader.GetDouble(3);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Additional_Article_Data_for_ArticleList_for_BackofficeSalesPage",ex);
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
		public static FR_L6SA_GAADfALfBSP_1115_Array Invoke(string ConnectionString,P_L6SA_GAADfALfBSP_1115 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6SA_GAADfALfBSP_1115_Array Invoke(DbConnection Connection,P_L6SA_GAADfALfBSP_1115 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6SA_GAADfALfBSP_1115_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L6SA_GAADfALfBSP_1115 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6SA_GAADfALfBSP_1115_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6SA_GAADfALfBSP_1115 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6SA_GAADfALfBSP_1115_Array functionReturn = new FR_L6SA_GAADfALfBSP_1115_Array();
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

				throw new Exception("Exception occured in method cls_Get_Additional_Article_Data_for_ArticleList_for_BackofficeSalesPage",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6SA_GAADfALfBSP_1115_Array : FR_Base
	{
		public L6SA_GAADfALfBSP_1115[] Result	{ get; set; } 
		public FR_L6SA_GAADfALfBSP_1115_Array() : base() {}

		public FR_L6SA_GAADfALfBSP_1115_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6SA_GAADfALfBSP_1115 for attribute P_L6SA_GAADfALfBSP_1115
		[DataContract]
		public class P_L6SA_GAADfALfBSP_1115 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] ArticleList { get; set; } 

		}
		#endregion
		#region SClass L6SA_GAADfALfBSP_1115 for attribute L6SA_GAADfALfBSP_1115
		[DataContract]
		public class L6SA_GAADfALfBSP_1115 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_ProductID { get; set; } 
			[DataMember]
			public Boolean IsStorage_BatchNumberMandatory { get; set; } 
			[DataMember]
			public Boolean IsStorage_ExpiryDateMandatory { get; set; } 
			[DataMember]
			public Double StockQuantity { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6SA_GAADfALfBSP_1115_Array cls_Get_Additional_Article_Data_for_ArticleList_for_BackofficeSalesPage(,P_L6SA_GAADfALfBSP_1115 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6SA_GAADfALfBSP_1115_Array invocationResult = cls_Get_Additional_Article_Data_for_ArticleList_for_BackofficeSalesPage.Invoke(connectionString,P_L6SA_GAADfALfBSP_1115 Parameter,securityTicket);
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
var parameter = new CL6_Backoffice_Sales.Atomic.Retrieval.P_L6SA_GAADfALfBSP_1115();
parameter.ArticleList = ...;

*/
