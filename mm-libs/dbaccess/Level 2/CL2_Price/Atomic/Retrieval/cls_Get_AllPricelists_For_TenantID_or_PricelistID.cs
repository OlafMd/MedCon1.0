/* 
 * Generated on 08/27/2014 15:10:55
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
    /// var result = cls_Get_AllPricelists_For_TenantID_or_PricelistID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_AllPricelists_For_TenantID_or_PricelistID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2PL_GAPfToP_1723_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L2PL_GAPfToP_1723 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2PL_GAPfToP_1723_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_Price.Atomic.Retrieval.SQL.cls_Get_AllPricelists_For_TenantID_or_PricelistID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PricelistID", Parameter.PricelistID);



			List<L2PL_GAPfToP_1723> results = new List<L2PL_GAPfToP_1723>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_SLS_PricelistID","Pricelist_Name_DictID","Pricelist_Description_DictID","IsDiscountCalculated_Maximum","IsDiscountCalculated_Accumulative","Customers_DefaultPricelist_RefID","GlobalPropertyMatchingID" });
				while(reader.Read())
				{
					L2PL_GAPfToP_1723 resultItem = new L2PL_GAPfToP_1723();
					//0:Parameter CMN_SLS_PricelistID of type Guid
					resultItem.CMN_SLS_PricelistID = reader.GetGuid(0);
					//1:Parameter Pricelist_Name of type Dict
					resultItem.Pricelist_Name = reader.GetDictionary(1);
					resultItem.Pricelist_Name.SourceTable = "cmn_sls_pricelist";
					loader.Append(resultItem.Pricelist_Name);
					//2:Parameter Pricelist_Description of type Dict
					resultItem.Pricelist_Description = reader.GetDictionary(2);
					resultItem.Pricelist_Description.SourceTable = "cmn_sls_pricelist";
					loader.Append(resultItem.Pricelist_Description);
					//3:Parameter IsDiscountCalculated_Maximum of type Boolean
					resultItem.IsDiscountCalculated_Maximum = reader.GetBoolean(3);
					//4:Parameter IsDiscountCalculated_Accumulative of type Boolean
					resultItem.IsDiscountCalculated_Accumulative = reader.GetBoolean(4);
					//5:Parameter Customers_DefaultPricelist_RefID of type Guid
					resultItem.Customers_DefaultPricelist_RefID = reader.GetGuid(5);
					//6:Parameter GlobalPropertyMatchingID of type String
					resultItem.GlobalPropertyMatchingID = reader.GetString(6);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_AllPricelists_For_TenantID_or_PricelistID",ex);
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
		public static FR_L2PL_GAPfToP_1723_Array Invoke(string ConnectionString,P_L2PL_GAPfToP_1723 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2PL_GAPfToP_1723_Array Invoke(DbConnection Connection,P_L2PL_GAPfToP_1723 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2PL_GAPfToP_1723_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L2PL_GAPfToP_1723 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2PL_GAPfToP_1723_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2PL_GAPfToP_1723 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2PL_GAPfToP_1723_Array functionReturn = new FR_L2PL_GAPfToP_1723_Array();
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

				throw new Exception("Exception occured in method cls_Get_AllPricelists_For_TenantID_or_PricelistID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2PL_GAPfToP_1723_Array : FR_Base
	{
		public L2PL_GAPfToP_1723[] Result	{ get; set; } 
		public FR_L2PL_GAPfToP_1723_Array() : base() {}

		public FR_L2PL_GAPfToP_1723_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L2PL_GAPfToP_1723 for attribute P_L2PL_GAPfToP_1723
		[DataContract]
		public class P_L2PL_GAPfToP_1723 
		{
			//Standard type parameters
			[DataMember]
			public Guid? PricelistID { get; set; } 

		}
		#endregion
		#region SClass L2PL_GAPfToP_1723 for attribute L2PL_GAPfToP_1723
		[DataContract]
		public class L2PL_GAPfToP_1723 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_SLS_PricelistID { get; set; } 
			[DataMember]
			public Dict Pricelist_Name { get; set; } 
			[DataMember]
			public Dict Pricelist_Description { get; set; } 
			[DataMember]
			public Boolean IsDiscountCalculated_Maximum { get; set; } 
			[DataMember]
			public Boolean IsDiscountCalculated_Accumulative { get; set; } 
			[DataMember]
			public Guid Customers_DefaultPricelist_RefID { get; set; } 
			[DataMember]
			public String GlobalPropertyMatchingID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2PL_GAPfToP_1723_Array cls_Get_AllPricelists_For_TenantID_or_PricelistID(,P_L2PL_GAPfToP_1723 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2PL_GAPfToP_1723_Array invocationResult = cls_Get_AllPricelists_For_TenantID_or_PricelistID.Invoke(connectionString,P_L2PL_GAPfToP_1723 Parameter,securityTicket);
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
var parameter = new CL2_Price.Atomic.Retrieval.P_L2PL_GAPfToP_1723();
parameter.PricelistID = ...;

*/
