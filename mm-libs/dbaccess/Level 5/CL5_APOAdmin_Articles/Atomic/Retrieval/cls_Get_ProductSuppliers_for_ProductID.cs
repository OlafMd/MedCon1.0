/* 
 * Generated on 14.10.2014 17:38:07
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

namespace CL5_APOAdmin_Articles.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ProductSuppliers_for_ProductID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ProductSuppliers_for_ProductID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5AA_GPSfPI_1248_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5AA_GPSfPI_1248 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5AA_GPSfPI_1248_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOAdmin_Articles.Atomic.Retrieval.SQL.cls_Get_ProductSuppliers_for_ProductID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ProductID", Parameter.ProductID);



			List<L5AA_GPSfPI_1248_raw> results = new List<L5AA_GPSfPI_1248_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "SupplierPriority","MinimalPackageOrderingAmount","BatchOrderSize","DisplayName","Tenant_RefID","CMN_PRO_Product_RefID","RecommendedRetailPrice_RefID","SupplierType_Name_DictID","GlobalPropertyMatchingID","CMN_BPT_Supplier_RefID","CMN_PRO_Product_SupplierID","ProcurementPrice_RefID","PriceValue_Amount","ORD_PRC_DiscountType_RefID","DiscountValue" });
				while(reader.Read())
				{
					L5AA_GPSfPI_1248_raw resultItem = new L5AA_GPSfPI_1248_raw();
					//0:Parameter SupplierPriority of type int
					resultItem.SupplierPriority = reader.GetInteger(0);
					//1:Parameter MinimalPackageOrderingAmount of type Double
					resultItem.MinimalPackageOrderingAmount = reader.GetDouble(1);
					//2:Parameter BatchOrderSize of type int
					resultItem.BatchOrderSize = reader.GetInteger(2);
					//3:Parameter DisplayName of type String
					resultItem.DisplayName = reader.GetString(3);
					//4:Parameter Tenant_RefID of type Guid
					resultItem.Tenant_RefID = reader.GetGuid(4);
					//5:Parameter CMN_PRO_Product_RefID of type Guid
					resultItem.CMN_PRO_Product_RefID = reader.GetGuid(5);
					//6:Parameter RecommendedRetailPrice_RefID of type Guid
					resultItem.RecommendedRetailPrice_RefID = reader.GetGuid(6);
					//7:Parameter SupplierType_Name_DictID of type Guid
					resultItem.SupplierType_Name_DictID = reader.GetGuid(7);
					//8:Parameter GlobalPropertyMatchingID of type String
					resultItem.GlobalPropertyMatchingID = reader.GetString(8);
					//9:Parameter CMN_BPT_Supplier_RefID of type Guid
					resultItem.CMN_BPT_Supplier_RefID = reader.GetGuid(9);
					//10:Parameter CMN_PRO_Product_SupplierID of type Guid
					resultItem.CMN_PRO_Product_SupplierID = reader.GetGuid(10);
					//11:Parameter ProcurementPrice_RefID of type Guid
					resultItem.ProcurementPrice_RefID = reader.GetGuid(11);
					//12:Parameter PriceValue_Amount of type Double
					resultItem.PriceValue_Amount = reader.GetDouble(12);
					//13:Parameter ORD_PRC_DiscountType_RefID of type Guid
					resultItem.ORD_PRC_DiscountType_RefID = reader.GetGuid(13);
					//14:Parameter DiscountValue of type Double
					resultItem.DiscountValue = reader.GetDouble(14);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_ProductSuppliers_for_ProductID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5AA_GPSfPI_1248_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5AA_GPSfPI_1248_Array Invoke(string ConnectionString,P_L5AA_GPSfPI_1248 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5AA_GPSfPI_1248_Array Invoke(DbConnection Connection,P_L5AA_GPSfPI_1248 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5AA_GPSfPI_1248_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AA_GPSfPI_1248 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5AA_GPSfPI_1248_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AA_GPSfPI_1248 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5AA_GPSfPI_1248_Array functionReturn = new FR_L5AA_GPSfPI_1248_Array();
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

				throw new Exception("Exception occured in method cls_Get_ProductSuppliers_for_ProductID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5AA_GPSfPI_1248_raw 
	{
		public int SupplierPriority; 
		public Double MinimalPackageOrderingAmount; 
		public int BatchOrderSize; 
		public String DisplayName; 
		public Guid Tenant_RefID; 
		public Guid CMN_PRO_Product_RefID; 
		public Guid RecommendedRetailPrice_RefID; 
		public Guid SupplierType_Name_DictID; 
		public String GlobalPropertyMatchingID; 
		public Guid CMN_BPT_Supplier_RefID; 
		public Guid CMN_PRO_Product_SupplierID; 
		public Guid ProcurementPrice_RefID; 
		public Double PriceValue_Amount; 
		public Guid ORD_PRC_DiscountType_RefID; 
		public Double DiscountValue; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5AA_GPSfPI_1248[] Convert(List<L5AA_GPSfPI_1248_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5AA_GPSfPI_1248 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.CMN_PRO_Product_SupplierID)).ToArray()
	group el_L5AA_GPSfPI_1248 by new 
	{ 
		el_L5AA_GPSfPI_1248.CMN_PRO_Product_SupplierID,

	}
	into gfunct_L5AA_GPSfPI_1248
	select new L5AA_GPSfPI_1248
	{     
		SupplierPriority = gfunct_L5AA_GPSfPI_1248.FirstOrDefault().SupplierPriority ,
		MinimalPackageOrderingAmount = gfunct_L5AA_GPSfPI_1248.FirstOrDefault().MinimalPackageOrderingAmount ,
		BatchOrderSize = gfunct_L5AA_GPSfPI_1248.FirstOrDefault().BatchOrderSize ,
		DisplayName = gfunct_L5AA_GPSfPI_1248.FirstOrDefault().DisplayName ,
		Tenant_RefID = gfunct_L5AA_GPSfPI_1248.FirstOrDefault().Tenant_RefID ,
		CMN_PRO_Product_RefID = gfunct_L5AA_GPSfPI_1248.FirstOrDefault().CMN_PRO_Product_RefID ,
		RecommendedRetailPrice_RefID = gfunct_L5AA_GPSfPI_1248.FirstOrDefault().RecommendedRetailPrice_RefID ,
		SupplierType_Name_DictID = gfunct_L5AA_GPSfPI_1248.FirstOrDefault().SupplierType_Name_DictID ,
		GlobalPropertyMatchingID = gfunct_L5AA_GPSfPI_1248.FirstOrDefault().GlobalPropertyMatchingID ,
		CMN_BPT_Supplier_RefID = gfunct_L5AA_GPSfPI_1248.FirstOrDefault().CMN_BPT_Supplier_RefID ,
		CMN_PRO_Product_SupplierID = gfunct_L5AA_GPSfPI_1248.Key.CMN_PRO_Product_SupplierID ,
		ProcurementPrice_RefID = gfunct_L5AA_GPSfPI_1248.FirstOrDefault().ProcurementPrice_RefID ,
		PriceValue_Amount = gfunct_L5AA_GPSfPI_1248.FirstOrDefault().PriceValue_Amount ,

		ProductSupplierDiscounts = 
		(
			from el_ProductSupplierDiscounts in gfunct_L5AA_GPSfPI_1248.Where(element => !EqualsDefaultValue(element.ORD_PRC_DiscountType_RefID)).ToArray()
			group el_ProductSupplierDiscounts by new 
			{ 
				el_ProductSupplierDiscounts.ORD_PRC_DiscountType_RefID,

			}
			into gfunct_ProductSupplierDiscounts
			select new L5AA_GPSfPI_1248a
			{     
				ORD_PRC_DiscountType_RefID = gfunct_ProductSupplierDiscounts.Key.ORD_PRC_DiscountType_RefID ,
				DiscountValue = gfunct_ProductSupplierDiscounts.FirstOrDefault().DiscountValue ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5AA_GPSfPI_1248_Array : FR_Base
	{
		public L5AA_GPSfPI_1248[] Result	{ get; set; } 
		public FR_L5AA_GPSfPI_1248_Array() : base() {}

		public FR_L5AA_GPSfPI_1248_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5AA_GPSfPI_1248 for attribute P_L5AA_GPSfPI_1248
		[DataContract]
		public class P_L5AA_GPSfPI_1248 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProductID { get; set; } 

		}
		#endregion
		#region SClass L5AA_GPSfPI_1248 for attribute L5AA_GPSfPI_1248
		[DataContract]
		public class L5AA_GPSfPI_1248 
		{
			[DataMember]
			public L5AA_GPSfPI_1248a[] ProductSupplierDiscounts { get; set; }

			//Standard type parameters
			[DataMember]
			public int SupplierPriority { get; set; } 
			[DataMember]
			public Double MinimalPackageOrderingAmount { get; set; } 
			[DataMember]
			public int BatchOrderSize { get; set; } 
			[DataMember]
			public String DisplayName { get; set; } 
			[DataMember]
			public Guid Tenant_RefID { get; set; } 
			[DataMember]
			public Guid CMN_PRO_Product_RefID { get; set; } 
			[DataMember]
			public Guid RecommendedRetailPrice_RefID { get; set; } 
			[DataMember]
			public Guid SupplierType_Name_DictID { get; set; } 
			[DataMember]
			public String GlobalPropertyMatchingID { get; set; } 
			[DataMember]
			public Guid CMN_BPT_Supplier_RefID { get; set; } 
			[DataMember]
			public Guid CMN_PRO_Product_SupplierID { get; set; } 
			[DataMember]
			public Guid ProcurementPrice_RefID { get; set; } 
			[DataMember]
			public Double PriceValue_Amount { get; set; } 

		}
		#endregion
		#region SClass L5AA_GPSfPI_1248a for attribute ProductSupplierDiscounts
		[DataContract]
		public class L5AA_GPSfPI_1248a 
		{
			//Standard type parameters
			[DataMember]
			public Guid ORD_PRC_DiscountType_RefID { get; set; } 
			[DataMember]
			public Double DiscountValue { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5AA_GPSfPI_1248_Array cls_Get_ProductSuppliers_for_ProductID(,P_L5AA_GPSfPI_1248 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5AA_GPSfPI_1248_Array invocationResult = cls_Get_ProductSuppliers_for_ProductID.Invoke(connectionString,P_L5AA_GPSfPI_1248 Parameter,securityTicket);
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
var parameter = new CL5_APOAdmin_Articles.Atomic.Retrieval.P_L5AA_GPSfPI_1248();
parameter.ProductID = ...;

*/
