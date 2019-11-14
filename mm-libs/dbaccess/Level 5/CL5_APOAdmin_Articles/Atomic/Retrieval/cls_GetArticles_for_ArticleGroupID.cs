/* 
 * Generated on 6/2/2014 3:29:38 PM
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

namespace CL5_APOAdmin_Articles.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_GetArticles_for_ArticleGroupID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_GetArticles_for_ArticleGroupID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_CL5AR_GAfAG_1516_Array Execute(DbConnection Connection,DbTransaction Transaction,P_CL5AR_GAfAG_1516 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_CL5AR_GAfAG_1516_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOAdmin_Articles.Atomic.Retrieval.SQL.cls_GetArticles_for_ArticleGroupID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ProductGroupID", Parameter.ProductGroupID);



			List<CL5AR_GAfAG_1516> results = new List<CL5AR_GAfAG_1516>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "AssignmentID","CMN_PRO_ProductID","Product_Name_DictID","Label_DictID","DosageForm_Name_DictID","Product_Number","GlobalPropertyMatchingID","ISOCode","PackageContent_Amount","PackageContent_DisplayLabel" });
				while(reader.Read())
				{
					CL5AR_GAfAG_1516 resultItem = new CL5AR_GAfAG_1516();
					//0:Parameter AssignmentID of type Guid
					resultItem.AssignmentID = reader.GetGuid(0);
					//1:Parameter CMN_PRO_ProductID of type Guid
					resultItem.CMN_PRO_ProductID = reader.GetGuid(1);
					//2:Parameter Product_Name of type Dict
					resultItem.Product_Name = reader.GetDictionary(2);
					resultItem.Product_Name.SourceTable = "cmn_pro_products";
					loader.Append(resultItem.Product_Name);
					//3:Parameter Label of type Dict
					resultItem.Label = reader.GetDictionary(3);
					resultItem.Label.SourceTable = "cmn_units";
					loader.Append(resultItem.Label);
					//4:Parameter DosageForm_Name of type Dict
					resultItem.DosageForm_Name = reader.GetDictionary(4);
					resultItem.DosageForm_Name.SourceTable = "hec_product_dosageforms";
					loader.Append(resultItem.DosageForm_Name);
					//5:Parameter Product_Number of type String
					resultItem.Product_Number = reader.GetString(5);
					//6:Parameter GlobalPropertyMatchingID of type String
					resultItem.GlobalPropertyMatchingID = reader.GetString(6);
					//7:Parameter ISOCode of type String
					resultItem.ISOCode = reader.GetString(7);
					//8:Parameter PackageContent_Amount of type Double
					resultItem.PackageContent_Amount = reader.GetDouble(8);
					//9:Parameter PackageContent_DisplayLabel of type String
					resultItem.PackageContent_DisplayLabel = reader.GetString(9);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_GetArticles_for_ArticleGroupID",ex);
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
		public static FR_CL5AR_GAfAG_1516_Array Invoke(string ConnectionString,P_CL5AR_GAfAG_1516 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_CL5AR_GAfAG_1516_Array Invoke(DbConnection Connection,P_CL5AR_GAfAG_1516 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_CL5AR_GAfAG_1516_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_CL5AR_GAfAG_1516 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_CL5AR_GAfAG_1516_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_CL5AR_GAfAG_1516 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_CL5AR_GAfAG_1516_Array functionReturn = new FR_CL5AR_GAfAG_1516_Array();
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

				throw new Exception("Exception occured in method cls_GetArticles_for_ArticleGroupID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_CL5AR_GAfAG_1516_Array : FR_Base
	{
		public CL5AR_GAfAG_1516[] Result	{ get; set; } 
		public FR_CL5AR_GAfAG_1516_Array() : base() {}

		public FR_CL5AR_GAfAG_1516_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_CL5AR_GAfAG_1516 for attribute P_CL5AR_GAfAG_1516
		[DataContract]
		public class P_CL5AR_GAfAG_1516 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProductGroupID { get; set; } 

		}
		#endregion
		#region SClass CL5AR_GAfAG_1516 for attribute CL5AR_GAfAG_1516
		[DataContract]
		public class CL5AR_GAfAG_1516 
		{
			//Standard type parameters
			[DataMember]
			public Guid AssignmentID { get; set; } 
			[DataMember]
			public Guid CMN_PRO_ProductID { get; set; } 
			[DataMember]
			public Dict Product_Name { get; set; } 
			[DataMember]
			public Dict Label { get; set; } 
			[DataMember]
			public Dict DosageForm_Name { get; set; } 
			[DataMember]
			public String Product_Number { get; set; } 
			[DataMember]
			public String GlobalPropertyMatchingID { get; set; } 
			[DataMember]
			public String ISOCode { get; set; } 
			[DataMember]
			public Double PackageContent_Amount { get; set; } 
			[DataMember]
			public String PackageContent_DisplayLabel { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_CL5AR_GAfAG_1516_Array cls_GetArticles_for_ArticleGroupID(,P_CL5AR_GAfAG_1516 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_CL5AR_GAfAG_1516_Array invocationResult = cls_GetArticles_for_ArticleGroupID.Invoke(connectionString,P_CL5AR_GAfAG_1516 Parameter,securityTicket);
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
var parameter = new CL5_APOAdmin_Articles.Atomic.Retrieval.P_CL5AR_GAfAG_1516();
parameter.ProductGroupID = ...;

*/
