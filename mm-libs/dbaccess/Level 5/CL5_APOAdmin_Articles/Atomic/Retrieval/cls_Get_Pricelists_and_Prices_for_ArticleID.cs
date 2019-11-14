/* 
 * Generated on 12/24/2013 5:07:48 PM
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
    /// var result = cls_Get_Pricelists_and_Prices_for_ArticleID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Pricelists_and_Prices_for_ArticleID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5AR_GPaPfAID_1603_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5AR_GPaPfAID_1603 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5AR_GPaPfAID_1603_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOAdmin_Articles.Atomic.Retrieval.SQL.cls_Get_Pricelists_and_Prices_for_ArticleID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ArticleID", Parameter.ArticleID);



			List<L5AR_GPaPfAID_1603> results = new List<L5AR_GPaPfAID_1603>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "Pricelist_Name_DictID","Pricelist_Description_DictID","CMN_SLS_PricelistID","CMN_SLS_PriceID","PriceAmount","Release_Version","CMN_SLS_Pricelist_ReleaseID","CMN_PRO_Product_RefID","CMN_Currency_RefID" });
				while(reader.Read())
				{
					L5AR_GPaPfAID_1603 resultItem = new L5AR_GPaPfAID_1603();
					//0:Parameter Pricelist_Name of type Dict
					resultItem.Pricelist_Name = reader.GetDictionary(0);
					resultItem.Pricelist_Name.SourceTable = "cmn_sls_pricelist";
					loader.Append(resultItem.Pricelist_Name);
					//1:Parameter Pricelist_Description of type Dict
					resultItem.Pricelist_Description = reader.GetDictionary(1);
					resultItem.Pricelist_Description.SourceTable = "cmn_sls_pricelist";
					loader.Append(resultItem.Pricelist_Description);
					//2:Parameter CMN_SLS_PricelistID of type Guid
					resultItem.CMN_SLS_PricelistID = reader.GetGuid(2);
					//3:Parameter CMN_SLS_PriceID of type Guid
					resultItem.CMN_SLS_PriceID = reader.GetGuid(3);
					//4:Parameter PriceAmount of type String
					resultItem.PriceAmount = reader.GetString(4);
					//5:Parameter Release_Version of type String
					resultItem.Release_Version = reader.GetString(5);
					//6:Parameter CMN_SLS_Pricelist_ReleaseID of type Guid
					resultItem.CMN_SLS_Pricelist_ReleaseID = reader.GetGuid(6);
					//7:Parameter CMN_PRO_Product_RefID of type Guid
					resultItem.CMN_PRO_Product_RefID = reader.GetGuid(7);
					//8:Parameter CMN_Currency_RefID of type Guid
					resultItem.CMN_Currency_RefID = reader.GetGuid(8);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Pricelists_and_Prices_for_ArticleID",ex);
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
		public static FR_L5AR_GPaPfAID_1603_Array Invoke(string ConnectionString,P_L5AR_GPaPfAID_1603 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5AR_GPaPfAID_1603_Array Invoke(DbConnection Connection,P_L5AR_GPaPfAID_1603 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5AR_GPaPfAID_1603_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AR_GPaPfAID_1603 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5AR_GPaPfAID_1603_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AR_GPaPfAID_1603 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5AR_GPaPfAID_1603_Array functionReturn = new FR_L5AR_GPaPfAID_1603_Array();
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

				throw new Exception("Exception occured in method cls_Get_Pricelists_and_Prices_for_ArticleID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5AR_GPaPfAID_1603_Array : FR_Base
	{
		public L5AR_GPaPfAID_1603[] Result	{ get; set; } 
		public FR_L5AR_GPaPfAID_1603_Array() : base() {}

		public FR_L5AR_GPaPfAID_1603_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5AR_GPaPfAID_1603 for attribute P_L5AR_GPaPfAID_1603
		[DataContract]
		public class P_L5AR_GPaPfAID_1603 
		{
			//Standard type parameters
			[DataMember]
			public Guid ArticleID { get; set; } 

		}
		#endregion
		#region SClass L5AR_GPaPfAID_1603 for attribute L5AR_GPaPfAID_1603
		[DataContract]
		public class L5AR_GPaPfAID_1603 
		{
			//Standard type parameters
			[DataMember]
			public Dict Pricelist_Name { get; set; } 
			[DataMember]
			public Dict Pricelist_Description { get; set; } 
			[DataMember]
			public Guid CMN_SLS_PricelistID { get; set; } 
			[DataMember]
			public Guid CMN_SLS_PriceID { get; set; } 
			[DataMember]
			public String PriceAmount { get; set; } 
			[DataMember]
			public String Release_Version { get; set; } 
			[DataMember]
			public Guid CMN_SLS_Pricelist_ReleaseID { get; set; } 
			[DataMember]
			public Guid CMN_PRO_Product_RefID { get; set; } 
			[DataMember]
			public Guid CMN_Currency_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5AR_GPaPfAID_1603_Array cls_Get_Pricelists_and_Prices_for_ArticleID(,P_L5AR_GPaPfAID_1603 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5AR_GPaPfAID_1603_Array invocationResult = cls_Get_Pricelists_and_Prices_for_ArticleID.Invoke(connectionString,P_L5AR_GPaPfAID_1603 Parameter,securityTicket);
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
var parameter = new CL5_APOAdmin_Articles.Atomic.Retrieval.P_L5AR_GPaPfAID_1603();
parameter.ArticleID = ...;

*/
