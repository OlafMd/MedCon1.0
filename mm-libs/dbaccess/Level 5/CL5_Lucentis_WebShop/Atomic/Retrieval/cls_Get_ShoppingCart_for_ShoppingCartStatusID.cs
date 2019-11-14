/* 
 * Generated on 1/22/2014 11:41:36 AM
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

namespace CL5_Lucentis_WebShop.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ShoppingCart_for_ShoppingCartStatusID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ShoppingCart_for_ShoppingCartStatusID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5WS_GSCfSCS_1539_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5WS_GSCfSCS_1539 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5WS_GSCfSCS_1539_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_Lucentis_WebShop.Atomic.Retrieval.SQL.cls_Get_ShoppingCart_for_ShoppingCartStatusID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ShoppingCartStatusID", Parameter.ShoppingCartStatusID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PracticeBPID", Parameter.PracticeBPID);



			List<L5WS_GSCfSCS_1539_raw> results = new List<L5WS_GSCfSCS_1539_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "ORD_PRC_ShoppingCartID","ShoppingCart_CreationDate","ORD_PRC_ShoppingCart_ProductID","CMN_PRO_Product_RefID","Quantity","PriceAmount","IsProductCanceled","IsProductDeleted","Product_Name_DictID","Product_Number","TaxRate" });
				while(reader.Read())
				{
					L5WS_GSCfSCS_1539_raw resultItem = new L5WS_GSCfSCS_1539_raw();
					//0:Parameter ORD_PRC_ShoppingCartID of type Guid
					resultItem.ORD_PRC_ShoppingCartID = reader.GetGuid(0);
					//1:Parameter ShoppingCart_CreationDate of type DateTime
					resultItem.ShoppingCart_CreationDate = reader.GetDate(1);
					//2:Parameter ORD_PRC_ShoppingCart_ProductID of type Guid
					resultItem.ORD_PRC_ShoppingCart_ProductID = reader.GetGuid(2);
					//3:Parameter CMN_PRO_Product_RefID of type Guid
					resultItem.CMN_PRO_Product_RefID = reader.GetGuid(3);
					//4:Parameter Quantity of type double
					resultItem.Quantity = reader.GetDouble(4);
					//5:Parameter PriceAmount of type double
					resultItem.PriceAmount = reader.GetDouble(5);
					//6:Parameter IsProductCanceled of type bool
					resultItem.IsProductCanceled = reader.GetBoolean(6);
					//7:Parameter IsProductDeleted of type bool
					resultItem.IsProductDeleted = reader.GetBoolean(7);
					//8:Parameter Product_Name of type Dict
					resultItem.Product_Name = reader.GetDictionary(8);
					resultItem.Product_Name.SourceTable = "cmn_pro_products";
					loader.Append(resultItem.Product_Name);
					//9:Parameter Product_Number of type String
					resultItem.Product_Number = reader.GetString(9);
					//10:Parameter TaxRate of type double
					resultItem.TaxRate = reader.GetDouble(10);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_ShoppingCart_for_ShoppingCartStatusID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5WS_GSCfSCS_1539_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5WS_GSCfSCS_1539_Array Invoke(string ConnectionString,P_L5WS_GSCfSCS_1539 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5WS_GSCfSCS_1539_Array Invoke(DbConnection Connection,P_L5WS_GSCfSCS_1539 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5WS_GSCfSCS_1539_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5WS_GSCfSCS_1539 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5WS_GSCfSCS_1539_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5WS_GSCfSCS_1539 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5WS_GSCfSCS_1539_Array functionReturn = new FR_L5WS_GSCfSCS_1539_Array();
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

				throw new Exception("Exception occured in method cls_Get_ShoppingCart_for_ShoppingCartStatusID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5WS_GSCfSCS_1539_raw 
	{
		public Guid ORD_PRC_ShoppingCartID; 
		public DateTime ShoppingCart_CreationDate; 
		public Guid ORD_PRC_ShoppingCart_ProductID; 
		public Guid CMN_PRO_Product_RefID; 
		public double Quantity; 
		public double PriceAmount; 
		public bool IsProductCanceled; 
		public bool IsProductDeleted; 
		public Dict Product_Name; 
		public String Product_Number; 
		public double TaxRate; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5WS_GSCfSCS_1539[] Convert(List<L5WS_GSCfSCS_1539_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5WS_GSCfSCS_1539 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.ORD_PRC_ShoppingCartID)).ToArray()
	group el_L5WS_GSCfSCS_1539 by new 
	{ 
		el_L5WS_GSCfSCS_1539.ORD_PRC_ShoppingCartID,

	}
	into gfunct_L5WS_GSCfSCS_1539
	select new L5WS_GSCfSCS_1539
	{     
		ORD_PRC_ShoppingCartID = gfunct_L5WS_GSCfSCS_1539.Key.ORD_PRC_ShoppingCartID ,
		ShoppingCart_CreationDate = gfunct_L5WS_GSCfSCS_1539.FirstOrDefault().ShoppingCart_CreationDate ,

		Products = 
		(
			from el_Products in gfunct_L5WS_GSCfSCS_1539.Where(element => !EqualsDefaultValue(element.ORD_PRC_ShoppingCart_ProductID)).ToArray()
			group el_Products by new 
			{ 
				el_Products.ORD_PRC_ShoppingCart_ProductID,

			}
			into gfunct_Products
			select new L5WS_GSCfSCS_1539_Product
			{     
				ORD_PRC_ShoppingCart_ProductID = gfunct_Products.Key.ORD_PRC_ShoppingCart_ProductID ,
				CMN_PRO_Product_RefID = gfunct_Products.FirstOrDefault().CMN_PRO_Product_RefID ,
				Quantity = gfunct_Products.FirstOrDefault().Quantity ,
				PriceAmount = gfunct_Products.FirstOrDefault().PriceAmount ,
				IsProductCanceled = gfunct_Products.FirstOrDefault().IsProductCanceled ,
				IsProductDeleted = gfunct_Products.FirstOrDefault().IsProductDeleted ,
				Product_Name = gfunct_Products.FirstOrDefault().Product_Name ,
				Product_Number = gfunct_Products.FirstOrDefault().Product_Number ,
				TaxRate = gfunct_Products.FirstOrDefault().TaxRate ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5WS_GSCfSCS_1539_Array : FR_Base
	{
		public L5WS_GSCfSCS_1539[] Result	{ get; set; } 
		public FR_L5WS_GSCfSCS_1539_Array() : base() {}

		public FR_L5WS_GSCfSCS_1539_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5WS_GSCfSCS_1539 for attribute P_L5WS_GSCfSCS_1539
		[DataContract]
		public class P_L5WS_GSCfSCS_1539 
		{
			//Standard type parameters
			[DataMember]
			public Guid ShoppingCartStatusID { get; set; } 
			[DataMember]
			public String PracticeBPID { get; set; } 

		}
		#endregion
		#region SClass L5WS_GSCfSCS_1539 for attribute L5WS_GSCfSCS_1539
		[DataContract]
		public class L5WS_GSCfSCS_1539 
		{
			[DataMember]
			public L5WS_GSCfSCS_1539_Product[] Products { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid ORD_PRC_ShoppingCartID { get; set; } 
			[DataMember]
			public DateTime ShoppingCart_CreationDate { get; set; } 

		}
		#endregion
		#region SClass L5WS_GSCfSCS_1539_Product for attribute Products
		[DataContract]
		public class L5WS_GSCfSCS_1539_Product 
		{
			//Standard type parameters
			[DataMember]
			public Guid ORD_PRC_ShoppingCart_ProductID { get; set; } 
			[DataMember]
			public Guid CMN_PRO_Product_RefID { get; set; } 
			[DataMember]
			public double Quantity { get; set; } 
			[DataMember]
			public double PriceAmount { get; set; } 
			[DataMember]
			public bool IsProductCanceled { get; set; } 
			[DataMember]
			public bool IsProductDeleted { get; set; } 
			[DataMember]
			public Dict Product_Name { get; set; } 
			[DataMember]
			public String Product_Number { get; set; } 
			[DataMember]
			public double TaxRate { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5WS_GSCfSCS_1539_Array cls_Get_ShoppingCart_for_ShoppingCartStatusID(,P_L5WS_GSCfSCS_1539 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5WS_GSCfSCS_1539_Array invocationResult = cls_Get_ShoppingCart_for_ShoppingCartStatusID.Invoke(connectionString,P_L5WS_GSCfSCS_1539 Parameter,securityTicket);
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
var parameter = new CL5_Lucentis_WebShop.Atomic.Retrieval.P_L5WS_GSCfSCS_1539();
parameter.ShoppingCartStatusID = ...;
parameter.PracticeBPID = ...;

*/
