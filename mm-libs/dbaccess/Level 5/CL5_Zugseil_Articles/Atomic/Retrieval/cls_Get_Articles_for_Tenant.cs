/* 
 * Generated on 10/3/2014 13:42:12
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

namespace CL5_Zugseil_Articles.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Articles_for_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Articles_for_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5AR_GAfT_1108_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5AR_GAfT_1108 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5AR_GAfT_1108_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_Zugseil_Articles.Atomic.Retrieval.SQL.cls_Get_Articles_for_Tenant.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"LanguageID", Parameter.LanguageID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PageSize", Parameter.PageSize);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ActivePage", Parameter.ActivePage);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"SearchCriteria", Parameter.SearchCriteria);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"OrderByCriteria", Parameter.OrderByCriteria);



			List<L5AR_GAfT_1108_raw> results = new List<L5AR_GAfT_1108_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_PRO_ProductID","Product_Name_DictID","Content","Product_Description_DictID","Product_Number","IsPlaceholderArticle" });
				while(reader.Read())
				{
					L5AR_GAfT_1108_raw resultItem = new L5AR_GAfT_1108_raw();
					//0:Parameter CMN_PRO_ProductID of type Guid
					resultItem.CMN_PRO_ProductID = reader.GetGuid(0);
					//1:Parameter ProductNameDict of type Dict
					resultItem.ProductNameDict = reader.GetDictionary(1);
					resultItem.ProductNameDict.SourceTable = "cmn_pro_products";
					loader.Append(resultItem.ProductNameDict);
					//2:Parameter Content of type String
					resultItem.Content = reader.GetString(2);
					//3:Parameter ProductDescription of type Dict
					resultItem.ProductDescription = reader.GetDictionary(3);
					resultItem.ProductDescription.SourceTable = "cmn_pro_products";
					loader.Append(resultItem.ProductDescription);
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
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Articles_for_Tenant",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5AR_GAfT_1108_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5AR_GAfT_1108_Array Invoke(string ConnectionString,P_L5AR_GAfT_1108 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5AR_GAfT_1108_Array Invoke(DbConnection Connection,P_L5AR_GAfT_1108 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5AR_GAfT_1108_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AR_GAfT_1108 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5AR_GAfT_1108_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AR_GAfT_1108 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5AR_GAfT_1108_Array functionReturn = new FR_L5AR_GAfT_1108_Array();
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

				throw new Exception("Exception occured in method cls_Get_Articles_for_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5AR_GAfT_1108_raw 
	{
		public Guid CMN_PRO_ProductID; 
		public Dict ProductNameDict; 
		public String Content; 
		public Dict ProductDescription; 
		public String Product_Number; 
		public bool IsPlaceholderArticle; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5AR_GAfT_1108[] Convert(List<L5AR_GAfT_1108_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5AR_GAfT_1108 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.CMN_PRO_ProductID)).ToArray()
	group el_L5AR_GAfT_1108 by new 
	{ 
		el_L5AR_GAfT_1108.CMN_PRO_ProductID,

	}
	into gfunct_L5AR_GAfT_1108
	select new L5AR_GAfT_1108
	{     
		CMN_PRO_ProductID = gfunct_L5AR_GAfT_1108.Key.CMN_PRO_ProductID ,
		ProductNameDict = gfunct_L5AR_GAfT_1108.FirstOrDefault().ProductNameDict ,
		Content = gfunct_L5AR_GAfT_1108.FirstOrDefault().Content ,
		ProductDescription = gfunct_L5AR_GAfT_1108.FirstOrDefault().ProductDescription ,
		Product_Number = gfunct_L5AR_GAfT_1108.FirstOrDefault().Product_Number ,
		IsPlaceholderArticle = gfunct_L5AR_GAfT_1108.FirstOrDefault().IsPlaceholderArticle ,

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5AR_GAfT_1108_Array : FR_Base
	{
		public L5AR_GAfT_1108[] Result	{ get; set; } 
		public FR_L5AR_GAfT_1108_Array() : base() {}

		public FR_L5AR_GAfT_1108_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5AR_GAfT_1108 for attribute P_L5AR_GAfT_1108
		[DataContract]
		public class P_L5AR_GAfT_1108 
		{
			//Standard type parameters
			[DataMember]
			public Guid LanguageID { get; set; } 
			[DataMember]
			public int PageSize { get; set; } 
			[DataMember]
			public int ActivePage { get; set; } 
			[DataMember]
			public String SearchCriteria { get; set; } 
			[DataMember]
			public String OrderByCriteria { get; set; } 

		}
		#endregion
		#region SClass L5AR_GAfT_1108 for attribute L5AR_GAfT_1108
		[DataContract]
		public class L5AR_GAfT_1108 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_ProductID { get; set; } 
			[DataMember]
			public Dict ProductNameDict { get; set; } 
			[DataMember]
			public String Content { get; set; } 
			[DataMember]
			public Dict ProductDescription { get; set; } 
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
FR_L5AR_GAfT_1108_Array cls_Get_Articles_for_Tenant(,P_L5AR_GAfT_1108 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5AR_GAfT_1108_Array invocationResult = cls_Get_Articles_for_Tenant.Invoke(connectionString,P_L5AR_GAfT_1108 Parameter,securityTicket);
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
var parameter = new CL5_Zugseil_Articles.Atomic.Retrieval.P_L5AR_GAfT_1108();
parameter.LanguageID = ...;
parameter.PageSize = ...;
parameter.ActivePage = ...;
parameter.SearchCriteria = ...;
parameter.OrderByCriteria = ...;

*/
