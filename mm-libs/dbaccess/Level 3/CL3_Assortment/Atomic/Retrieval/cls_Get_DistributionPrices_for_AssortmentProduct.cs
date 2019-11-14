/* 
 * Generated on 12/3/2014 15:13:17
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
    /// var result = cls_Get_DistributionPrices_for_AssortmentProduct.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_DistributionPrices_for_AssortmentProduct
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3AS_GDPfAP_1711_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3AS_GDPfAP_1711 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3AS_GDPfAP_1711_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_Assortment.Atomic.Retrieval.SQL.cls_Get_DistributionPrices_for_AssortmentProduct.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ProductID", Parameter.ProductID);



			List<L3AS_GDPfAP_1711_raw> results = new List<L3AS_GDPfAP_1711_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_PRO_ASS_AssortmentProductID","VariantName_DictID","IsStandardProductVariant","CMN_PRO_ASS_AssortmentVariantID","CMN_PRO_ASS_DistributionPriceID","CMN_PRO_ASS_DistributionPrice_ValueID","DefaultPointValue","ValidFrom","ValidThrough","CMN_Price_RefID","DefaultCurrency","CMN_Price_ValueID","PriceValue_Currency_RefID","PriceValue_Amount" });
				while(reader.Read())
				{
					L3AS_GDPfAP_1711_raw resultItem = new L3AS_GDPfAP_1711_raw();
					//0:Parameter CMN_PRO_ASS_AssortmentProductID of type Guid
					resultItem.CMN_PRO_ASS_AssortmentProductID = reader.GetGuid(0);
					//1:Parameter VariantName_DictID of type Dict
					resultItem.VariantName_DictID = reader.GetDictionary(1);
					resultItem.VariantName_DictID.SourceTable = "cmn_pro_product_variants";
					loader.Append(resultItem.VariantName_DictID);
					//2:Parameter IsStandardProductVariant of type bool
					resultItem.IsStandardProductVariant = reader.GetBoolean(2);
					//3:Parameter CMN_PRO_ASS_AssortmentVariantID of type Guid
					resultItem.CMN_PRO_ASS_AssortmentVariantID = reader.GetGuid(3);
					//4:Parameter CMN_PRO_ASS_DistributionPriceID of type Guid
					resultItem.CMN_PRO_ASS_DistributionPriceID = reader.GetGuid(4);
					//5:Parameter CMN_PRO_ASS_DistributionPrice_ValueID of type Guid
					resultItem.CMN_PRO_ASS_DistributionPrice_ValueID = reader.GetGuid(5);
					//6:Parameter DefaultPointValue of type double
					resultItem.DefaultPointValue = reader.GetDouble(6);
					//7:Parameter ValidFrom of type DateTime
					resultItem.ValidFrom = reader.GetDate(7);
					//8:Parameter ValidThrough of type DateTime
					resultItem.ValidThrough = reader.GetDate(8);
					//9:Parameter CMN_Price_RefID of type Guid
					resultItem.CMN_Price_RefID = reader.GetGuid(9);
					//10:Parameter DefaultCurrency of type Guid
					resultItem.DefaultCurrency = reader.GetGuid(10);
					//11:Parameter CMN_Price_ValueID of type Guid
					resultItem.CMN_Price_ValueID = reader.GetGuid(11);
					//12:Parameter PriceValue_Currency_RefID of type Guid
					resultItem.PriceValue_Currency_RefID = reader.GetGuid(12);
					//13:Parameter PriceValue_Amount of type Double
					resultItem.PriceValue_Amount = reader.GetDouble(13);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_DistributionPrices_for_AssortmentProduct",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L3AS_GDPfAP_1711_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3AS_GDPfAP_1711_Array Invoke(string ConnectionString,P_L3AS_GDPfAP_1711 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3AS_GDPfAP_1711_Array Invoke(DbConnection Connection,P_L3AS_GDPfAP_1711 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3AS_GDPfAP_1711_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3AS_GDPfAP_1711 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3AS_GDPfAP_1711_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3AS_GDPfAP_1711 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3AS_GDPfAP_1711_Array functionReturn = new FR_L3AS_GDPfAP_1711_Array();
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

				throw new Exception("Exception occured in method cls_Get_DistributionPrices_for_AssortmentProduct",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L3AS_GDPfAP_1711_raw 
	{
		public Guid CMN_PRO_ASS_AssortmentProductID; 
		public Dict VariantName_DictID; 
		public bool IsStandardProductVariant; 
		public Guid CMN_PRO_ASS_AssortmentVariantID; 
		public Guid CMN_PRO_ASS_DistributionPriceID; 
		public Guid CMN_PRO_ASS_DistributionPrice_ValueID; 
		public double DefaultPointValue; 
		public DateTime ValidFrom; 
		public DateTime ValidThrough; 
		public Guid CMN_Price_RefID; 
		public Guid DefaultCurrency; 
		public Guid CMN_Price_ValueID; 
		public Guid PriceValue_Currency_RefID; 
		public Double PriceValue_Amount; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L3AS_GDPfAP_1711[] Convert(List<L3AS_GDPfAP_1711_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L3AS_GDPfAP_1711 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.CMN_PRO_ASS_DistributionPriceID)).ToArray()
	group el_L3AS_GDPfAP_1711 by new 
	{ 
		el_L3AS_GDPfAP_1711.CMN_PRO_ASS_DistributionPriceID,

	}
	into gfunct_L3AS_GDPfAP_1711
	select new L3AS_GDPfAP_1711
	{     
		CMN_PRO_ASS_AssortmentProductID = gfunct_L3AS_GDPfAP_1711.FirstOrDefault().CMN_PRO_ASS_AssortmentProductID ,
		VariantName_DictID = gfunct_L3AS_GDPfAP_1711.FirstOrDefault().VariantName_DictID ,
		IsStandardProductVariant = gfunct_L3AS_GDPfAP_1711.FirstOrDefault().IsStandardProductVariant ,
		CMN_PRO_ASS_AssortmentVariantID = gfunct_L3AS_GDPfAP_1711.FirstOrDefault().CMN_PRO_ASS_AssortmentVariantID ,
		CMN_PRO_ASS_DistributionPriceID = gfunct_L3AS_GDPfAP_1711.Key.CMN_PRO_ASS_DistributionPriceID ,

		DistributionPriceValues = 
		(
			from el_DistributionPriceValues in gfunct_L3AS_GDPfAP_1711.Where(element => !EqualsDefaultValue(element.CMN_PRO_ASS_DistributionPrice_ValueID)).ToArray()
			group el_DistributionPriceValues by new 
			{ 
				el_DistributionPriceValues.CMN_PRO_ASS_DistributionPrice_ValueID,

			}
			into gfunct_DistributionPriceValues
			select new L3AS_GDPfAP_1711a
			{     
				CMN_PRO_ASS_DistributionPrice_ValueID = gfunct_DistributionPriceValues.Key.CMN_PRO_ASS_DistributionPrice_ValueID ,
				DefaultPointValue = gfunct_DistributionPriceValues.FirstOrDefault().DefaultPointValue ,
				ValidFrom = gfunct_DistributionPriceValues.FirstOrDefault().ValidFrom ,
				ValidThrough = gfunct_DistributionPriceValues.FirstOrDefault().ValidThrough ,
				CMN_Price_RefID = gfunct_DistributionPriceValues.FirstOrDefault().CMN_Price_RefID ,
				DefaultCurrency = gfunct_DistributionPriceValues.FirstOrDefault().DefaultCurrency ,

				Prices = 
				(
					from el_Prices in gfunct_DistributionPriceValues.Where(element => !EqualsDefaultValue(element.CMN_Price_ValueID)).ToArray()
					group el_Prices by new 
					{ 
						el_Prices.CMN_Price_ValueID,

					}
					into gfunct_Prices
					select new L3AS_GDPfAP_1711b
					{     
						CMN_Price_ValueID = gfunct_Prices.Key.CMN_Price_ValueID ,
						PriceValue_Currency_RefID = gfunct_Prices.FirstOrDefault().PriceValue_Currency_RefID ,
						PriceValue_Amount = gfunct_Prices.FirstOrDefault().PriceValue_Amount ,

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
	public class FR_L3AS_GDPfAP_1711_Array : FR_Base
	{
		public L3AS_GDPfAP_1711[] Result	{ get; set; } 
		public FR_L3AS_GDPfAP_1711_Array() : base() {}

		public FR_L3AS_GDPfAP_1711_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3AS_GDPfAP_1711 for attribute P_L3AS_GDPfAP_1711
		[DataContract]
		public class P_L3AS_GDPfAP_1711 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProductID { get; set; } 

		}
		#endregion
		#region SClass L3AS_GDPfAP_1711 for attribute L3AS_GDPfAP_1711
		[DataContract]
		public class L3AS_GDPfAP_1711 
		{
			[DataMember]
			public L3AS_GDPfAP_1711a[] DistributionPriceValues { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_ASS_AssortmentProductID { get; set; } 
			[DataMember]
			public Dict VariantName_DictID { get; set; } 
			[DataMember]
			public bool IsStandardProductVariant { get; set; } 
			[DataMember]
			public Guid CMN_PRO_ASS_AssortmentVariantID { get; set; } 
			[DataMember]
			public Guid CMN_PRO_ASS_DistributionPriceID { get; set; } 

		}
		#endregion
		#region SClass L3AS_GDPfAP_1711a for attribute DistributionPriceValues
		[DataContract]
		public class L3AS_GDPfAP_1711a 
		{
			[DataMember]
			public L3AS_GDPfAP_1711b[] Prices { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_ASS_DistributionPrice_ValueID { get; set; } 
			[DataMember]
			public double DefaultPointValue { get; set; } 
			[DataMember]
			public DateTime ValidFrom { get; set; } 
			[DataMember]
			public DateTime ValidThrough { get; set; } 
			[DataMember]
			public Guid CMN_Price_RefID { get; set; } 
			[DataMember]
			public Guid DefaultCurrency { get; set; } 

		}
		#endregion
		#region SClass L3AS_GDPfAP_1711b for attribute Prices
		[DataContract]
		public class L3AS_GDPfAP_1711b 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_Price_ValueID { get; set; } 
			[DataMember]
			public Guid PriceValue_Currency_RefID { get; set; } 
			[DataMember]
			public Double PriceValue_Amount { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3AS_GDPfAP_1711_Array cls_Get_DistributionPrices_for_AssortmentProduct(,P_L3AS_GDPfAP_1711 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3AS_GDPfAP_1711_Array invocationResult = cls_Get_DistributionPrices_for_AssortmentProduct.Invoke(connectionString,P_L3AS_GDPfAP_1711 Parameter,securityTicket);
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
var parameter = new CL3_Assortment.Atomic.Retrieval.P_L3AS_GDPfAP_1711();
parameter.ProductID = ...;

*/
