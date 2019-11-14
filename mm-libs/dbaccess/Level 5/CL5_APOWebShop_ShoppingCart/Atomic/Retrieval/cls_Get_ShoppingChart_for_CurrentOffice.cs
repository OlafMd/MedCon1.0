/* 
 * Generated on 6/30/2014 12:31:23 PM
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

namespace CL5_APOWebShop_ShoppingCart.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ShoppingChart_for_CurrentOffice.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ShoppingChart_for_CurrentOffice
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5AWSAR_GSCfCO_1805_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5AWSAR_GSCfCO_1805 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5AWSAR_GSCfCO_1805_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOWebShop_ShoppingCart.Atomic.Retrieval.SQL.cls_Get_ShoppingChart_for_CurrentOffice.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ShoppingCartStatusID", Parameter.ShoppingCartStatusID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"OfficeID", Parameter.OfficeID);



			List<L5AWSAR_GSCfCO_1805_raw> results = new List<L5AWSAR_GSCfCO_1805_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "ORD_PRC_ShoppingCartID","IsProcurementOrderCreated","ORD_PRC_Office_ShoppingCartID","CMN_STR_Office_RefID","Office_InternalName","ShoppingCartStatus","ORD_PRC_ShoppingCart_ProductID","CMN_PRO_Product_RefID","CMN_PRO_Product_Variant_RefID","CMN_PRO_Product_Release_RefID","Quantity","IsProductCanceled","IsProductDeleted","IsProductReplacementAllowed","Product_Name_DictID","Product_Number","ProductITL","Comment","Price","CurrencyISO","CurrencySymbol","TaxRate","Group_GlobalPropertyMatchingID" });
				while(reader.Read())
				{
					L5AWSAR_GSCfCO_1805_raw resultItem = new L5AWSAR_GSCfCO_1805_raw();
					//0:Parameter ORD_PRC_ShoppingCartID of type Guid
					resultItem.ORD_PRC_ShoppingCartID = reader.GetGuid(0);
					//1:Parameter IsProcurementOrderCreated of type bool
					resultItem.IsProcurementOrderCreated = reader.GetBoolean(1);
					//2:Parameter ORD_PRC_Office_ShoppingCartID of type Guid
					resultItem.ORD_PRC_Office_ShoppingCartID = reader.GetGuid(2);
					//3:Parameter CMN_STR_Office_RefID of type Guid
					resultItem.CMN_STR_Office_RefID = reader.GetGuid(3);
					//4:Parameter Office_InternalName of type string
					resultItem.Office_InternalName = reader.GetString(4);
					//5:Parameter ShoppingCartStatus of type string
					resultItem.ShoppingCartStatus = reader.GetString(5);
					//6:Parameter ORD_PRC_ShoppingCart_ProductID of type Guid
					resultItem.ORD_PRC_ShoppingCart_ProductID = reader.GetGuid(6);
					//7:Parameter CMN_PRO_Product_RefID of type Guid
					resultItem.CMN_PRO_Product_RefID = reader.GetGuid(7);
					//8:Parameter CMN_PRO_Product_Variant_RefID of type Guid
					resultItem.CMN_PRO_Product_Variant_RefID = reader.GetGuid(8);
					//9:Parameter CMN_PRO_Product_Release_RefID of type Guid
					resultItem.CMN_PRO_Product_Release_RefID = reader.GetGuid(9);
					//10:Parameter Quantity of type double
					resultItem.Quantity = reader.GetDouble(10);
					//11:Parameter IsProductCanceled of type bool
					resultItem.IsProductCanceled = reader.GetBoolean(11);
					//12:Parameter IsProductDeleted of type bool
					resultItem.IsProductDeleted = reader.GetBoolean(12);
					//13:Parameter IsProductReplacementAllowed of type bool
					resultItem.IsProductReplacementAllowed = reader.GetBoolean(13);
					//14:Parameter Product_Name of type Dict
					resultItem.Product_Name = reader.GetDictionary(14);
					resultItem.Product_Name.SourceTable = "cmn_pro_products";
					loader.Append(resultItem.Product_Name);
					//15:Parameter Product_Number of type string
					resultItem.Product_Number = reader.GetString(15);
					//16:Parameter ProductITL of type string
					resultItem.ProductITL = reader.GetString(16);
					//17:Parameter Comment of type string
					resultItem.Comment = reader.GetString(17);
					//18:Parameter Price of type decimal
					resultItem.Price = reader.GetDecimal(18);
					//19:Parameter CurrencyISO of type string
					resultItem.CurrencyISO = reader.GetString(19);
					//20:Parameter CurrencySymbol of type string
					resultItem.CurrencySymbol = reader.GetString(20);
					//21:Parameter TaxRate of type decimal
					resultItem.TaxRate = reader.GetDecimal(21);
					//22:Parameter Group_GlobalPropertyMatchingID of type string
					resultItem.Group_GlobalPropertyMatchingID = reader.GetString(22);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_ShoppingChart_for_CurrentOffice",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5AWSAR_GSCfCO_1805_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5AWSAR_GSCfCO_1805_Array Invoke(string ConnectionString,P_L5AWSAR_GSCfCO_1805 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5AWSAR_GSCfCO_1805_Array Invoke(DbConnection Connection,P_L5AWSAR_GSCfCO_1805 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5AWSAR_GSCfCO_1805_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AWSAR_GSCfCO_1805 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5AWSAR_GSCfCO_1805_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AWSAR_GSCfCO_1805 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5AWSAR_GSCfCO_1805_Array functionReturn = new FR_L5AWSAR_GSCfCO_1805_Array();
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

				throw new Exception("Exception occured in method cls_Get_ShoppingChart_for_CurrentOffice",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5AWSAR_GSCfCO_1805_raw 
	{
		public Guid ORD_PRC_ShoppingCartID; 
		public bool IsProcurementOrderCreated; 
		public Guid ORD_PRC_Office_ShoppingCartID; 
		public Guid CMN_STR_Office_RefID; 
		public string Office_InternalName; 
		public string ShoppingCartStatus; 
		public Guid ORD_PRC_ShoppingCart_ProductID; 
		public Guid CMN_PRO_Product_RefID; 
		public Guid CMN_PRO_Product_Variant_RefID; 
		public Guid CMN_PRO_Product_Release_RefID; 
		public double Quantity; 
		public bool IsProductCanceled; 
		public bool IsProductDeleted; 
		public bool IsProductReplacementAllowed; 
		public Dict Product_Name; 
		public string Product_Number; 
		public string ProductITL; 
		public string Comment; 
		public decimal Price; 
		public string CurrencyISO; 
		public string CurrencySymbol; 
		public decimal TaxRate; 
		public string Group_GlobalPropertyMatchingID; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5AWSAR_GSCfCO_1805[] Convert(List<L5AWSAR_GSCfCO_1805_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5AWSAR_GSCfCO_1805 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.ORD_PRC_ShoppingCartID)).ToArray()
	group el_L5AWSAR_GSCfCO_1805 by new 
	{ 
		el_L5AWSAR_GSCfCO_1805.ORD_PRC_ShoppingCartID,

	}
	into gfunct_L5AWSAR_GSCfCO_1805
	select new L5AWSAR_GSCfCO_1805
	{     
		ORD_PRC_ShoppingCartID = gfunct_L5AWSAR_GSCfCO_1805.Key.ORD_PRC_ShoppingCartID ,
		IsProcurementOrderCreated = gfunct_L5AWSAR_GSCfCO_1805.FirstOrDefault().IsProcurementOrderCreated ,
		ORD_PRC_Office_ShoppingCartID = gfunct_L5AWSAR_GSCfCO_1805.FirstOrDefault().ORD_PRC_Office_ShoppingCartID ,
		CMN_STR_Office_RefID = gfunct_L5AWSAR_GSCfCO_1805.FirstOrDefault().CMN_STR_Office_RefID ,
		Office_InternalName = gfunct_L5AWSAR_GSCfCO_1805.FirstOrDefault().Office_InternalName ,
		ShoppingCartStatus = gfunct_L5AWSAR_GSCfCO_1805.FirstOrDefault().ShoppingCartStatus ,

		Products = 
		(
			from el_Products in gfunct_L5AWSAR_GSCfCO_1805.Where(element => !EqualsDefaultValue(element.ORD_PRC_ShoppingCart_ProductID)).ToArray()
			group el_Products by new 
			{ 
				el_Products.ORD_PRC_ShoppingCart_ProductID,

			}
			into gfunct_Products
			select new L5AWSAR_GSCfCO_1805_Product
			{     
				ORD_PRC_ShoppingCart_ProductID = gfunct_Products.Key.ORD_PRC_ShoppingCart_ProductID ,
				CMN_PRO_Product_RefID = gfunct_Products.FirstOrDefault().CMN_PRO_Product_RefID ,
				CMN_PRO_Product_Variant_RefID = gfunct_Products.FirstOrDefault().CMN_PRO_Product_Variant_RefID ,
				CMN_PRO_Product_Release_RefID = gfunct_Products.FirstOrDefault().CMN_PRO_Product_Release_RefID ,
				Quantity = gfunct_Products.FirstOrDefault().Quantity ,
				IsProductCanceled = gfunct_Products.FirstOrDefault().IsProductCanceled ,
				IsProductDeleted = gfunct_Products.FirstOrDefault().IsProductDeleted ,
				IsProductReplacementAllowed = gfunct_Products.FirstOrDefault().IsProductReplacementAllowed ,
				Product_Name = gfunct_Products.FirstOrDefault().Product_Name ,
				Product_Number = gfunct_Products.FirstOrDefault().Product_Number ,
				ProductITL = gfunct_Products.FirstOrDefault().ProductITL ,
				Comment = gfunct_Products.FirstOrDefault().Comment ,
				Price = gfunct_Products.FirstOrDefault().Price ,
				CurrencyISO = gfunct_Products.FirstOrDefault().CurrencyISO ,
				CurrencySymbol = gfunct_Products.FirstOrDefault().CurrencySymbol ,
				TaxRate = gfunct_Products.FirstOrDefault().TaxRate ,

				Groups = 
				(
					from el_Groups in gfunct_Products.Where(element => !EqualsDefaultValue(element.Group_GlobalPropertyMatchingID)).ToArray()
					group el_Groups by new 
					{ 
						el_Groups.Group_GlobalPropertyMatchingID,

					}
					into gfunct_Groups
					select new L5AWSAR_GSCfCO_1805_Group
					{     
						Group_GlobalPropertyMatchingID = gfunct_Groups.Key.Group_GlobalPropertyMatchingID ,

					}
				).ToArray(),

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5AWSAR_GSCfCO_1805_Array : FR_Base
	{
		public L5AWSAR_GSCfCO_1805[] Result	{ get; set; } 
		public FR_L5AWSAR_GSCfCO_1805_Array() : base() {}

		public FR_L5AWSAR_GSCfCO_1805_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5AWSAR_GSCfCO_1805 for attribute P_L5AWSAR_GSCfCO_1805
		[DataContract]
		public class P_L5AWSAR_GSCfCO_1805 
		{
			//Standard type parameters
			[DataMember]
			public Guid ShoppingCartStatusID { get; set; } 
			[DataMember]
			public Guid OfficeID { get; set; } 

		}
		#endregion
		#region SClass L5AWSAR_GSCfCO_1805 for attribute L5AWSAR_GSCfCO_1805
		[DataContract]
		public class L5AWSAR_GSCfCO_1805 
		{
			[DataMember]
			public L5AWSAR_GSCfCO_1805_Product[] Products { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid ORD_PRC_ShoppingCartID { get; set; } 
			[DataMember]
			public bool IsProcurementOrderCreated { get; set; } 
			[DataMember]
			public Guid ORD_PRC_Office_ShoppingCartID { get; set; } 
			[DataMember]
			public Guid CMN_STR_Office_RefID { get; set; } 
			[DataMember]
			public string Office_InternalName { get; set; } 
			[DataMember]
			public string ShoppingCartStatus { get; set; } 

		}
		#endregion
		#region SClass L5AWSAR_GSCfCO_1805_Product for attribute Products
		[DataContract]
		public class L5AWSAR_GSCfCO_1805_Product 
		{
			[DataMember]
			public L5AWSAR_GSCfCO_1805_Group[] Groups { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid ORD_PRC_ShoppingCart_ProductID { get; set; } 
			[DataMember]
			public Guid CMN_PRO_Product_RefID { get; set; } 
			[DataMember]
			public Guid CMN_PRO_Product_Variant_RefID { get; set; } 
			[DataMember]
			public Guid CMN_PRO_Product_Release_RefID { get; set; } 
			[DataMember]
			public double Quantity { get; set; } 
			[DataMember]
			public bool IsProductCanceled { get; set; } 
			[DataMember]
			public bool IsProductDeleted { get; set; } 
			[DataMember]
			public bool IsProductReplacementAllowed { get; set; } 
			[DataMember]
			public Dict Product_Name { get; set; } 
			[DataMember]
			public string Product_Number { get; set; } 
			[DataMember]
			public string ProductITL { get; set; } 
			[DataMember]
			public string Comment { get; set; } 
			[DataMember]
			public decimal Price { get; set; } 
			[DataMember]
			public string CurrencyISO { get; set; } 
			[DataMember]
			public string CurrencySymbol { get; set; } 
			[DataMember]
			public decimal TaxRate { get; set; } 

		}
		#endregion
		#region SClass L5AWSAR_GSCfCO_1805_Group for attribute Groups
		[DataContract]
		public class L5AWSAR_GSCfCO_1805_Group 
		{
			//Standard type parameters
			[DataMember]
			public string Group_GlobalPropertyMatchingID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5AWSAR_GSCfCO_1805_Array cls_Get_ShoppingChart_for_CurrentOffice(,P_L5AWSAR_GSCfCO_1805 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5AWSAR_GSCfCO_1805_Array invocationResult = cls_Get_ShoppingChart_for_CurrentOffice.Invoke(connectionString,P_L5AWSAR_GSCfCO_1805 Parameter,securityTicket);
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
var parameter = new CL5_APOWebShop_ShoppingCart.Atomic.Retrieval.P_L5AWSAR_GSCfCO_1805();
parameter.ShoppingCartStatusID = ...;
parameter.OfficeID = ...;

*/
