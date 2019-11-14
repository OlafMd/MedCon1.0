/* 
 * Generated on 12/20/2014 8:07:24 PM
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

namespace CL3_Assortment.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_DistributionPrices_for_Product.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_DistributionPrices_for_Product
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3AS_GDPfP_2005_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3AS_GDPfP_2005 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3AS_GDPfP_2005_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_Assortment.Atomic.Retrieval.SQL.cls_Get_DistributionPrices_for_Product.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ProductID", Parameter.ProductID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CurrencyID", Parameter.CurrencyID);



			List<L3AS_GDPfP_2005> results = new List<L3AS_GDPfP_2005>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_PRO_Product_VariantID","PriceValue_Amount","IsStandardProductVariant" });
				while(reader.Read())
				{
					L3AS_GDPfP_2005 resultItem = new L3AS_GDPfP_2005();
					//0:Parameter CMN_PRO_Product_VariantID of type Guid
					resultItem.CMN_PRO_Product_VariantID = reader.GetGuid(0);
					//1:Parameter PriceValue_Amount of type double
					resultItem.PriceValue_Amount = reader.GetDouble(1);
					//2:Parameter IsStandardProductVariant of type bool
					resultItem.IsStandardProductVariant = reader.GetBoolean(2);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_DistributionPrices_for_Product",ex);
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
		public static FR_L3AS_GDPfP_2005_Array Invoke(string ConnectionString,P_L3AS_GDPfP_2005 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3AS_GDPfP_2005_Array Invoke(DbConnection Connection,P_L3AS_GDPfP_2005 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3AS_GDPfP_2005_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3AS_GDPfP_2005 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3AS_GDPfP_2005_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3AS_GDPfP_2005 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3AS_GDPfP_2005_Array functionReturn = new FR_L3AS_GDPfP_2005_Array();
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

				throw new Exception("Exception occured in method cls_Get_DistributionPrices_for_Product",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3AS_GDPfP_2005_Array : FR_Base
	{
		public L3AS_GDPfP_2005[] Result	{ get; set; } 
		public FR_L3AS_GDPfP_2005_Array() : base() {}

		public FR_L3AS_GDPfP_2005_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3AS_GDPfP_2005 for attribute P_L3AS_GDPfP_2005
		[DataContract]
		public class P_L3AS_GDPfP_2005 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProductID { get; set; } 
			[DataMember]
			public Guid CurrencyID { get; set; } 

		}
		#endregion
		#region SClass L3AS_GDPfP_2005 for attribute L3AS_GDPfP_2005
		[DataContract]
		public class L3AS_GDPfP_2005 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_Product_VariantID { get; set; } 
			[DataMember]
			public double PriceValue_Amount { get; set; } 
			[DataMember]
			public bool IsStandardProductVariant { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3AS_GDPfP_2005_Array cls_Get_DistributionPrices_for_Product(,P_L3AS_GDPfP_2005 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3AS_GDPfP_2005_Array invocationResult = cls_Get_DistributionPrices_for_Product.Invoke(connectionString,P_L3AS_GDPfP_2005 Parameter,securityTicket);
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
var parameter = new CL3_Assortment.Atomic.Retrieval.P_L3AS_GDPfP_2005();
parameter.ProductID = ...;
parameter.CurrencyID = ...;

*/
