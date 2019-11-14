/* 
 * Generated on 6/3/2014 10:53:03 AM
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
    /// var result = cls_Get_Pricelists_and_Prices_for_Article_and_Currency_ID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Pricelists_and_Prices_for_Article_and_Currency_ID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5AR_GPaPfAaCID_1020_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5AR_GPaPfAaCID_1020 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5AR_GPaPfAaCID_1020_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOAdmin_Articles.Atomic.Retrieval.SQL.cls_Get_Pricelists_and_Prices_for_Article_and_Currency_ID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ArticleID", Parameter.ArticleID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CurrencyID", Parameter.CurrencyID);



			List<L5AR_GPaPfAaCID_1020> results = new List<L5AR_GPaPfAaCID_1020>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "Pricelist_Name_DictID","CMN_SLS_PricelistID","CMN_SLS_PriceID","GlobalPropertyMatchingID","PriceAmount","Release_Version","CMN_SLS_Pricelist_ReleaseID","CMN_PRO_Product_RefID","CMN_Currency_RefID","IsDynamicPricingUsed","DynamicPricingFormula_Type_RefID","DynamicPricingFormula" });
				while(reader.Read())
				{
					L5AR_GPaPfAaCID_1020 resultItem = new L5AR_GPaPfAaCID_1020();
					//0:Parameter Pricelist_Name of type Dict
					resultItem.Pricelist_Name = reader.GetDictionary(0);
					resultItem.Pricelist_Name.SourceTable = "cmn_sls_pricelist";
					loader.Append(resultItem.Pricelist_Name);
					//1:Parameter CMN_SLS_PricelistID of type Guid
					resultItem.CMN_SLS_PricelistID = reader.GetGuid(1);
					//2:Parameter CMN_SLS_PriceID of type Guid
					resultItem.CMN_SLS_PriceID = reader.GetGuid(2);
					//3:Parameter GlobalPropertyMatchingID of type String
					resultItem.GlobalPropertyMatchingID = reader.GetString(3);
					//4:Parameter PriceAmount of type decimal
					resultItem.PriceAmount = reader.GetDecimal(4);
					//5:Parameter Release_Version of type String
					resultItem.Release_Version = reader.GetString(5);
					//6:Parameter CMN_SLS_Pricelist_ReleaseID of type Guid
					resultItem.CMN_SLS_Pricelist_ReleaseID = reader.GetGuid(6);
					//7:Parameter CMN_PRO_Product_RefID of type Guid
					resultItem.CMN_PRO_Product_RefID = reader.GetGuid(7);
					//8:Parameter CMN_Currency_RefID of type Guid
					resultItem.CMN_Currency_RefID = reader.GetGuid(8);
					//9:Parameter IsDynamicPricingUsed of type bool
					resultItem.IsDynamicPricingUsed = reader.GetBoolean(9);
					//10:Parameter DynamicPricingFormula_Type_RefID of type Guid
					resultItem.DynamicPricingFormula_Type_RefID = reader.GetGuid(10);
					//11:Parameter DynamicPricingFormula of type String
					resultItem.DynamicPricingFormula = reader.GetString(11);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Pricelists_and_Prices_for_Article_and_Currency_ID",ex);
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
		public static FR_L5AR_GPaPfAaCID_1020_Array Invoke(string ConnectionString,P_L5AR_GPaPfAaCID_1020 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5AR_GPaPfAaCID_1020_Array Invoke(DbConnection Connection,P_L5AR_GPaPfAaCID_1020 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5AR_GPaPfAaCID_1020_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AR_GPaPfAaCID_1020 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5AR_GPaPfAaCID_1020_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AR_GPaPfAaCID_1020 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5AR_GPaPfAaCID_1020_Array functionReturn = new FR_L5AR_GPaPfAaCID_1020_Array();
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

				throw new Exception("Exception occured in method cls_Get_Pricelists_and_Prices_for_Article_and_Currency_ID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5AR_GPaPfAaCID_1020_Array : FR_Base
	{
		public L5AR_GPaPfAaCID_1020[] Result	{ get; set; } 
		public FR_L5AR_GPaPfAaCID_1020_Array() : base() {}

		public FR_L5AR_GPaPfAaCID_1020_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5AR_GPaPfAaCID_1020 for attribute P_L5AR_GPaPfAaCID_1020
		[DataContract]
		public class P_L5AR_GPaPfAaCID_1020 
		{
			//Standard type parameters
			[DataMember]
			public Guid ArticleID { get; set; } 
			[DataMember]
			public Guid CurrencyID { get; set; } 

		}
		#endregion
		#region SClass L5AR_GPaPfAaCID_1020 for attribute L5AR_GPaPfAaCID_1020
		[DataContract]
		public class L5AR_GPaPfAaCID_1020 
		{
			//Standard type parameters
			[DataMember]
			public Dict Pricelist_Name { get; set; } 
			[DataMember]
			public Guid CMN_SLS_PricelistID { get; set; } 
			[DataMember]
			public Guid CMN_SLS_PriceID { get; set; } 
			[DataMember]
			public String GlobalPropertyMatchingID { get; set; } 
			[DataMember]
			public decimal PriceAmount { get; set; } 
			[DataMember]
			public String Release_Version { get; set; } 
			[DataMember]
			public Guid CMN_SLS_Pricelist_ReleaseID { get; set; } 
			[DataMember]
			public Guid CMN_PRO_Product_RefID { get; set; } 
			[DataMember]
			public Guid CMN_Currency_RefID { get; set; } 
			[DataMember]
			public bool IsDynamicPricingUsed { get; set; } 
			[DataMember]
			public Guid DynamicPricingFormula_Type_RefID { get; set; } 
			[DataMember]
			public String DynamicPricingFormula { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5AR_GPaPfAaCID_1020_Array cls_Get_Pricelists_and_Prices_for_Article_and_Currency_ID(,P_L5AR_GPaPfAaCID_1020 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5AR_GPaPfAaCID_1020_Array invocationResult = cls_Get_Pricelists_and_Prices_for_Article_and_Currency_ID.Invoke(connectionString,P_L5AR_GPaPfAaCID_1020 Parameter,securityTicket);
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
var parameter = new CL5_APOAdmin_Articles.Atomic.Retrieval.P_L5AR_GPaPfAaCID_1020();
parameter.ArticleID = ...;
parameter.CurrencyID = ...;

*/
