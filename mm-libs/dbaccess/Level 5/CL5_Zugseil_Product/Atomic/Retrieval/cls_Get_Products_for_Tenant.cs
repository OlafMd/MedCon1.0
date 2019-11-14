/* 
 * Generated on 2/12/2015 11:30:16 AM
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

namespace CL5_Zugseil_Product.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Products_for_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Products_for_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5PR_GPfT_1439_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5PR_GPfT_1439 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5PR_GPfT_1439_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_Zugseil_Product.Atomic.Retrieval.SQL.cls_Get_Products_for_Tenant.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"LanguageID", Parameter.LanguageID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"SearchCriteria", Parameter.SearchCriteria);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PageSize", Parameter.PageSize);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ActivePage", Parameter.ActivePage);

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@ExcludedProducts"," IN $$ExcludedProducts$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$ExcludedProducts$",Parameter.ExcludedProducts);


			List<L5PR_GPfT_1439_raw> results = new List<L5PR_GPfT_1439_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_PRO_ProductID","Product_Name_DictID","Content","Product_Description_DictID","Product_Number","IsPlaceholderArticle" });
				while(reader.Read())
				{
					L5PR_GPfT_1439_raw resultItem = new L5PR_GPfT_1439_raw();
					//0:Parameter CMN_PRO_ProductID of type Guid
					resultItem.CMN_PRO_ProductID = reader.GetGuid(0);
					//1:Parameter Product_Name of type Dict
					resultItem.Product_Name = reader.GetDictionary(1);
					resultItem.Product_Name.SourceTable = "cmn_pro_products";
					loader.Append(resultItem.Product_Name);
					//2:Parameter Content of type String
					resultItem.Content = reader.GetString(2);
					//3:Parameter Product_Description of type Dict
					resultItem.Product_Description = reader.GetDictionary(3);
					resultItem.Product_Description.SourceTable = "cmn_pro_products";
					loader.Append(resultItem.Product_Description);
					//4:Parameter Product_Number of type String
					resultItem.Product_Number = reader.GetString(4);
					//5:Parameter IsPlaceholderArticle of type bool
					resultItem.IsPlaceholderArticle = reader.GetBoolean(5);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Products_for_Tenant",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5PR_GPfT_1439_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5PR_GPfT_1439_Array Invoke(string ConnectionString,P_L5PR_GPfT_1439 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5PR_GPfT_1439_Array Invoke(DbConnection Connection,P_L5PR_GPfT_1439 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5PR_GPfT_1439_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5PR_GPfT_1439 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5PR_GPfT_1439_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5PR_GPfT_1439 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5PR_GPfT_1439_Array functionReturn = new FR_L5PR_GPfT_1439_Array();
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

				throw new Exception("Exception occured in method cls_Get_Products_for_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5PR_GPfT_1439_raw 
	{
		public Guid CMN_PRO_ProductID; 
		public Dict Product_Name; 
		public String Content; 
		public Dict Product_Description; 
		public String Product_Number; 
		public bool IsPlaceholderArticle; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5PR_GPfT_1439[] Convert(List<L5PR_GPfT_1439_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5PR_GPfT_1439 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.CMN_PRO_ProductID)).ToArray()
	group el_L5PR_GPfT_1439 by new 
	{ 
		el_L5PR_GPfT_1439.CMN_PRO_ProductID,

	}
	into gfunct_L5PR_GPfT_1439
	select new L5PR_GPfT_1439
	{     
		CMN_PRO_ProductID = gfunct_L5PR_GPfT_1439.Key.CMN_PRO_ProductID ,
		Product_Name = gfunct_L5PR_GPfT_1439.FirstOrDefault().Product_Name ,
		Content = gfunct_L5PR_GPfT_1439.FirstOrDefault().Content ,
		Product_Description = gfunct_L5PR_GPfT_1439.FirstOrDefault().Product_Description ,
		Product_Number = gfunct_L5PR_GPfT_1439.FirstOrDefault().Product_Number ,
		IsPlaceholderArticle = gfunct_L5PR_GPfT_1439.FirstOrDefault().IsPlaceholderArticle ,

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5PR_GPfT_1439_Array : FR_Base
	{
		public L5PR_GPfT_1439[] Result	{ get; set; } 
		public FR_L5PR_GPfT_1439_Array() : base() {}

		public FR_L5PR_GPfT_1439_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5PR_GPfT_1439 for attribute P_L5PR_GPfT_1439
		[DataContract]
		public class P_L5PR_GPfT_1439 
		{
			//Standard type parameters
			[DataMember]
			public Guid LanguageID { get; set; } 
			[DataMember]
			public String SearchCriteria { get; set; } 
			[DataMember]
			public int PageSize { get; set; } 
			[DataMember]
			public int ActivePage { get; set; } 
			[DataMember]
			public Guid[] ExcludedProducts { get; set; } 

		}
		#endregion
		#region SClass L5PR_GPfT_1439 for attribute L5PR_GPfT_1439
		[DataContract]
		public class L5PR_GPfT_1439 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_ProductID { get; set; } 
			[DataMember]
			public Dict Product_Name { get; set; } 
			[DataMember]
			public String Content { get; set; } 
			[DataMember]
			public Dict Product_Description { get; set; } 
			[DataMember]
			public String Product_Number { get; set; } 
			[DataMember]
			public bool IsPlaceholderArticle { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5PR_GPfT_1439_Array cls_Get_Products_for_Tenant(,P_L5PR_GPfT_1439 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5PR_GPfT_1439_Array invocationResult = cls_Get_Products_for_Tenant.Invoke(connectionString,P_L5PR_GPfT_1439 Parameter,securityTicket);
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
var parameter = new CL5_Zugseil_Product.Atomic.Retrieval.P_L5PR_GPfT_1439();
parameter.LanguageID = ...;
parameter.SearchCriteria = ...;
parameter.PageSize = ...;
parameter.ActivePage = ...;
parameter.ExcludedProducts = ...;

*/
