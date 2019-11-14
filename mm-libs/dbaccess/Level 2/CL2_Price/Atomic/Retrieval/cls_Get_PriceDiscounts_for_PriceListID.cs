/* 
 * Generated on 2/12/2013 03:58:12
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

namespace CL2_Price.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_PriceDiscounts_for_PriceListID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_PriceDiscounts_for_PriceListID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2PL_GPDfPL_1439_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L2PL_GPDfPL_1439 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2PL_GPDfPL_1439_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_Price.Atomic.Retrieval.SQL.cls_Get_PriceDiscounts_for_PriceListID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PriceListID", Parameter.PriceListID);



			List<L2PL_GPDfPL_1439> results = new List<L2PL_GPDfPL_1439>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_SLS_Pricelist_DiscountID","CMN_SLS_PricelistID","CMN_SLS_Pricelist_ReleaseID","Pricelist_Name_DictID","Release_Version","Product_RefID","Product_Variant_RefID","Product_Release_RefID","DiscountPercentAmount","DiscountValid_From","DiscountValid_To","IsDeleted" });
				while(reader.Read())
				{
					L2PL_GPDfPL_1439 resultItem = new L2PL_GPDfPL_1439();
					//0:Parameter CMN_SLS_Pricelist_DiscountID of type Guid
					resultItem.CMN_SLS_Pricelist_DiscountID = reader.GetGuid(0);
					//1:Parameter CMN_SLS_PricelistID of type Guid
					resultItem.CMN_SLS_PricelistID = reader.GetGuid(1);
					//2:Parameter CMN_SLS_Pricelist_ReleaseID of type Guid
					resultItem.CMN_SLS_Pricelist_ReleaseID = reader.GetGuid(2);
					//3:Parameter Pricelist_Name of type Dict
					resultItem.Pricelist_Name = reader.GetDictionary(3);
					resultItem.Pricelist_Name.SourceTable = "cmn_sls_pricelist";
					loader.Append(resultItem.Pricelist_Name);
					//4:Parameter Release_Version of type String
					resultItem.Release_Version = reader.GetString(4);
					//5:Parameter Product_RefID of type Guid
					resultItem.Product_RefID = reader.GetGuid(5);
					//6:Parameter Product_Variant_RefID of type Guid
					resultItem.Product_Variant_RefID = reader.GetGuid(6);
					//7:Parameter Product_Release_RefID of type Guid
					resultItem.Product_Release_RefID = reader.GetGuid(7);
					//8:Parameter DiscountPercentAmount of type decimal
					resultItem.DiscountPercentAmount = reader.GetDecimal(8);
					//9:Parameter DiscountValid_From of type DateTime
					resultItem.DiscountValid_From = reader.GetDate(9);
					//10:Parameter DiscountValid_To of type DateTime
					resultItem.DiscountValid_To = reader.GetDate(10);
					//11:Parameter IsDeleted of type Boolean
					resultItem.IsDeleted = reader.GetBoolean(11);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_PriceDiscounts_for_PriceListID",ex);
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
		public static FR_L2PL_GPDfPL_1439_Array Invoke(string ConnectionString,P_L2PL_GPDfPL_1439 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2PL_GPDfPL_1439_Array Invoke(DbConnection Connection,P_L2PL_GPDfPL_1439 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2PL_GPDfPL_1439_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L2PL_GPDfPL_1439 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2PL_GPDfPL_1439_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2PL_GPDfPL_1439 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2PL_GPDfPL_1439_Array functionReturn = new FR_L2PL_GPDfPL_1439_Array();
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

				throw new Exception("Exception occured in method cls_Get_PriceDiscounts_for_PriceListID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2PL_GPDfPL_1439_Array : FR_Base
	{
		public L2PL_GPDfPL_1439[] Result	{ get; set; } 
		public FR_L2PL_GPDfPL_1439_Array() : base() {}

		public FR_L2PL_GPDfPL_1439_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L2PL_GPDfPL_1439 for attribute P_L2PL_GPDfPL_1439
		[DataContract]
		public class P_L2PL_GPDfPL_1439 
		{
			//Standard type parameters
			[DataMember]
			public Guid? PriceListID { get; set; } 

		}
		#endregion
		#region SClass L2PL_GPDfPL_1439 for attribute L2PL_GPDfPL_1439
		[DataContract]
		public class L2PL_GPDfPL_1439 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_SLS_Pricelist_DiscountID { get; set; } 
			[DataMember]
			public Guid CMN_SLS_PricelistID { get; set; } 
			[DataMember]
			public Guid CMN_SLS_Pricelist_ReleaseID { get; set; } 
			[DataMember]
			public Dict Pricelist_Name { get; set; } 
			[DataMember]
			public String Release_Version { get; set; } 
			[DataMember]
			public Guid Product_RefID { get; set; } 
			[DataMember]
			public Guid Product_Variant_RefID { get; set; } 
			[DataMember]
			public Guid Product_Release_RefID { get; set; } 
			[DataMember]
			public decimal DiscountPercentAmount { get; set; } 
			[DataMember]
			public DateTime DiscountValid_From { get; set; } 
			[DataMember]
			public DateTime DiscountValid_To { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2PL_GPDfPL_1439_Array cls_Get_PriceDiscounts_for_PriceListID(,P_L2PL_GPDfPL_1439 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2PL_GPDfPL_1439_Array invocationResult = cls_Get_PriceDiscounts_for_PriceListID.Invoke(connectionString,P_L2PL_GPDfPL_1439 Parameter,securityTicket);
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
var parameter = new CL2_Price.Atomic.Retrieval.P_L2PL_GPDfPL_1439();
parameter.PriceListID = ...;

*/
