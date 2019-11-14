/* 
 * Generated on 12/1/2014 9:50:13 AM
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

namespace CL5_Lucentis_Articles.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Article_ForTenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Article_ForTenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5LA_GAfTID_0821_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5LA_GAfTID_0821_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_Lucentis_Articles.Atomic.Retrieval.SQL.cls_Get_Article_ForTenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L5LA_GAfTID_0821_raw> results = new List<L5LA_GAfTID_0821_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "ArticleRecipe","Product_Name_DictID","Product_Number","HEC_ProductID","Creation_Timestamp","CMN_PRO_ProductID" });
				while(reader.Read())
				{
					L5LA_GAfTID_0821_raw resultItem = new L5LA_GAfTID_0821_raw();
					//0:Parameter ArticleRecipe of type String
					resultItem.ArticleRecipe = reader.GetString(0);
					//1:Parameter Product_Name_DictID of type Dict
					resultItem.Product_Name_DictID = reader.GetDictionary(1);
					resultItem.Product_Name_DictID.SourceTable = "cmn_pro_products";
					loader.Append(resultItem.Product_Name_DictID);
					//2:Parameter Product_Number of type String
					resultItem.Product_Number = reader.GetString(2);
					//3:Parameter HEC_ProductID of type Guid
					resultItem.HEC_ProductID = reader.GetGuid(3);
					//4:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(4);
					//5:Parameter CMN_PRO_ProductID of type Guid
					resultItem.CMN_PRO_ProductID = reader.GetGuid(5);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Article_ForTenantID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5LA_GAfTID_0821_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5LA_GAfTID_0821_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5LA_GAfTID_0821_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5LA_GAfTID_0821_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5LA_GAfTID_0821_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5LA_GAfTID_0821_Array functionReturn = new FR_L5LA_GAfTID_0821_Array();
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

				functionReturn = Execute(Connection, Transaction,securityTicket);

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

				throw new Exception("Exception occured in method cls_Get_Article_ForTenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5LA_GAfTID_0821_raw 
	{
		public String ArticleRecipe; 
		public Dict Product_Name_DictID; 
		public String Product_Number; 
		public Guid HEC_ProductID; 
		public DateTime Creation_Timestamp; 
		public Guid CMN_PRO_ProductID; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5LA_GAfTID_0821[] Convert(List<L5LA_GAfTID_0821_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5LA_GAfTID_0821 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.CMN_PRO_ProductID)).ToArray()
	group el_L5LA_GAfTID_0821 by new 
	{ 
		el_L5LA_GAfTID_0821.CMN_PRO_ProductID,

	}
	into gfunct_L5LA_GAfTID_0821
	select new L5LA_GAfTID_0821
	{     
		ArticleRecipe = gfunct_L5LA_GAfTID_0821.FirstOrDefault().ArticleRecipe ,
		Product_Name_DictID = gfunct_L5LA_GAfTID_0821.FirstOrDefault().Product_Name_DictID ,
		Product_Number = gfunct_L5LA_GAfTID_0821.FirstOrDefault().Product_Number ,
		HEC_ProductID = gfunct_L5LA_GAfTID_0821.FirstOrDefault().HEC_ProductID ,
		Creation_Timestamp = gfunct_L5LA_GAfTID_0821.FirstOrDefault().Creation_Timestamp ,
		CMN_PRO_ProductID = gfunct_L5LA_GAfTID_0821.Key.CMN_PRO_ProductID ,

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5LA_GAfTID_0821_Array : FR_Base
	{
		public L5LA_GAfTID_0821[] Result	{ get; set; } 
		public FR_L5LA_GAfTID_0821_Array() : base() {}

		public FR_L5LA_GAfTID_0821_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5LA_GAfTID_0821 for attribute L5LA_GAfTID_0821
		[DataContract]
		public class L5LA_GAfTID_0821 
		{
			//Standard type parameters
			[DataMember]
			public String ArticleRecipe { get; set; } 
			[DataMember]
			public Dict Product_Name_DictID { get; set; } 
			[DataMember]
			public String Product_Number { get; set; } 
			[DataMember]
			public Guid HEC_ProductID { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public Guid CMN_PRO_ProductID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5LA_GAfTID_0821_Array cls_Get_Article_ForTenantID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5LA_GAfTID_0821_Array invocationResult = cls_Get_Article_ForTenantID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

