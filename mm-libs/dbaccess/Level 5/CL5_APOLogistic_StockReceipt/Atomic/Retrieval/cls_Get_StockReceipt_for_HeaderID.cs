/* 
 * Generated on 5/5/2014 10:13:20 AM
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

namespace CL5_APOLogistic_StockReceipt.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_StockReceipt_for_HeaderID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_StockReceipt_for_HeaderID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5ALSR_GSRfH_1045 Execute(DbConnection Connection,DbTransaction Transaction,P_L5ALSR_GSRfH_1045 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5ALSR_GSRfH_1045();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOLogistic_StockReceipt.Atomic.Retrieval.SQL.cls_Get_StockReceipt_for_HeaderID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"HeaderID", Parameter.HeaderID);



			List<L5ALSR_GSRfH_1045_raw> results = new List<L5ALSR_GSRfH_1045_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "LOG_RCP_Receipt_HeaderID","SupplierID","SupplierName","ExpectedDeliveryDate","LOG_RCP_Receipt_PositionID","Product_Name_DictID","Product_Number","DosageForm_Name_DictID","GlobalPropertyMatchingID","Abbreviation_DictID","ISOCode","AEK_Price","Position_ValuePerUnit","PackageContent_Amount","Position_Quantity","TotalQuantityTakenIntoStock","Position_ValueTotal","BatchNumber","ExpiryDate" });
				while(reader.Read())
				{
					L5ALSR_GSRfH_1045_raw resultItem = new L5ALSR_GSRfH_1045_raw();
					//0:Parameter LOG_RCP_Receipt_HeaderID of type Guid
					resultItem.LOG_RCP_Receipt_HeaderID = reader.GetGuid(0);
					//1:Parameter SupplierID of type Guid
					resultItem.SupplierID = reader.GetGuid(1);
					//2:Parameter SupplierName of type String
					resultItem.SupplierName = reader.GetString(2);
					//3:Parameter ExpectedDeliveryDate of type DateTime
					resultItem.ExpectedDeliveryDate = reader.GetDate(3);
					//4:Parameter LOG_RCP_Receipt_PositionID of type Guid
					resultItem.LOG_RCP_Receipt_PositionID = reader.GetGuid(4);
					//5:Parameter Product_Name of type Dict
					resultItem.Product_Name = reader.GetDictionary(5);
					resultItem.Product_Name.SourceTable = "cmn_pro_products";
					loader.Append(resultItem.Product_Name);
					//6:Parameter Product_Number of type String
					resultItem.Product_Number = reader.GetString(6);
					//7:Parameter DosageForm_Name of type Dict
					resultItem.DosageForm_Name = reader.GetDictionary(7);
					resultItem.DosageForm_Name.SourceTable = "hec_product_dosageforms";
					loader.Append(resultItem.DosageForm_Name);
					//8:Parameter GlobalPropertyMatchingID of type String
					resultItem.GlobalPropertyMatchingID = reader.GetString(8);
					//9:Parameter Abbreviation of type Dict
					resultItem.Abbreviation = reader.GetDictionary(9);
					resultItem.Abbreviation.SourceTable = "cmn_units";
					loader.Append(resultItem.Abbreviation);
					//10:Parameter ISOCode of type String
					resultItem.ISOCode = reader.GetString(10);
					//11:Parameter AEK_Price of type double
					resultItem.AEK_Price = reader.GetDouble(11);
					//12:Parameter Position_ValuePerUnit of type double
					resultItem.Position_ValuePerUnit = reader.GetDouble(12);
					//13:Parameter PackageContent_Amount of type double
					resultItem.PackageContent_Amount = reader.GetDouble(13);
					//14:Parameter Position_Quantity of type double
					resultItem.Position_Quantity = reader.GetDouble(14);
					//15:Parameter TotalQuantityTakenIntoStock of type double
					resultItem.TotalQuantityTakenIntoStock = reader.GetDouble(15);
					//16:Parameter Position_ValueTotal of type double
					resultItem.Position_ValueTotal = reader.GetDouble(16);
					//17:Parameter BatchNumber of type String
					resultItem.BatchNumber = reader.GetString(17);
					//18:Parameter ExpiryDate of type DateTime
					resultItem.ExpiryDate = reader.GetDate(18);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_StockReceipt_for_HeaderID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5ALSR_GSRfH_1045_raw.Convert(results).FirstOrDefault();

			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5ALSR_GSRfH_1045 Invoke(string ConnectionString,P_L5ALSR_GSRfH_1045 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5ALSR_GSRfH_1045 Invoke(DbConnection Connection,P_L5ALSR_GSRfH_1045 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5ALSR_GSRfH_1045 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5ALSR_GSRfH_1045 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5ALSR_GSRfH_1045 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5ALSR_GSRfH_1045 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5ALSR_GSRfH_1045 functionReturn = new FR_L5ALSR_GSRfH_1045();
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

				throw new Exception("Exception occured in method cls_Get_StockReceipt_for_HeaderID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5ALSR_GSRfH_1045_raw 
	{
		public Guid LOG_RCP_Receipt_HeaderID; 
		public Guid SupplierID; 
		public String SupplierName; 
		public DateTime ExpectedDeliveryDate; 
		public Guid LOG_RCP_Receipt_PositionID; 
		public Dict Product_Name; 
		public String Product_Number; 
		public Dict DosageForm_Name; 
		public String GlobalPropertyMatchingID; 
		public Dict Abbreviation; 
		public String ISOCode; 
		public double AEK_Price; 
		public double Position_ValuePerUnit; 
		public double PackageContent_Amount; 
		public double Position_Quantity; 
		public double TotalQuantityTakenIntoStock; 
		public double Position_ValueTotal; 
		public String BatchNumber; 
		public DateTime ExpiryDate; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5ALSR_GSRfH_1045[] Convert(List<L5ALSR_GSRfH_1045_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5ALSR_GSRfH_1045 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.LOG_RCP_Receipt_HeaderID)).ToArray()
	group el_L5ALSR_GSRfH_1045 by new 
	{ 
		el_L5ALSR_GSRfH_1045.LOG_RCP_Receipt_HeaderID,

	}
	into gfunct_L5ALSR_GSRfH_1045
	select new L5ALSR_GSRfH_1045
	{     
		LOG_RCP_Receipt_HeaderID = gfunct_L5ALSR_GSRfH_1045.Key.LOG_RCP_Receipt_HeaderID ,
		SupplierID = gfunct_L5ALSR_GSRfH_1045.FirstOrDefault().SupplierID ,
		SupplierName = gfunct_L5ALSR_GSRfH_1045.FirstOrDefault().SupplierName ,
		ExpectedDeliveryDate = gfunct_L5ALSR_GSRfH_1045.FirstOrDefault().ExpectedDeliveryDate ,

		StockPositions = 
		(
			from el_StockPositions in gfunct_L5ALSR_GSRfH_1045.Where(element => !EqualsDefaultValue(element.LOG_RCP_Receipt_PositionID)).ToArray()
			group el_StockPositions by new 
			{ 
				el_StockPositions.LOG_RCP_Receipt_PositionID,

			}
			into gfunct_StockPositions
			select new L5ALSR_GSRfH_1045a
			{     
				LOG_RCP_Receipt_PositionID = gfunct_StockPositions.Key.LOG_RCP_Receipt_PositionID ,
				Product_Name = gfunct_StockPositions.FirstOrDefault().Product_Name ,
				Product_Number = gfunct_StockPositions.FirstOrDefault().Product_Number ,
				DosageForm_Name = gfunct_StockPositions.FirstOrDefault().DosageForm_Name ,
				GlobalPropertyMatchingID = gfunct_StockPositions.FirstOrDefault().GlobalPropertyMatchingID ,
				Abbreviation = gfunct_StockPositions.FirstOrDefault().Abbreviation ,
				ISOCode = gfunct_StockPositions.FirstOrDefault().ISOCode ,
				AEK_Price = gfunct_StockPositions.FirstOrDefault().AEK_Price ,
				Position_ValuePerUnit = gfunct_StockPositions.FirstOrDefault().Position_ValuePerUnit ,
				PackageContent_Amount = gfunct_StockPositions.FirstOrDefault().PackageContent_Amount ,
				Position_Quantity = gfunct_StockPositions.FirstOrDefault().Position_Quantity ,
				TotalQuantityTakenIntoStock = gfunct_StockPositions.FirstOrDefault().TotalQuantityTakenIntoStock ,
				Position_ValueTotal = gfunct_StockPositions.FirstOrDefault().Position_ValueTotal ,
				BatchNumber = gfunct_StockPositions.FirstOrDefault().BatchNumber ,
				ExpiryDate = gfunct_StockPositions.FirstOrDefault().ExpiryDate ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5ALSR_GSRfH_1045 : FR_Base
	{
		public L5ALSR_GSRfH_1045 Result	{ get; set; }

		public FR_L5ALSR_GSRfH_1045() : base() {}

		public FR_L5ALSR_GSRfH_1045(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5ALSR_GSRfH_1045 for attribute P_L5ALSR_GSRfH_1045
		[DataContract]
		public class P_L5ALSR_GSRfH_1045 
		{
			//Standard type parameters
			[DataMember]
			public Guid HeaderID { get; set; } 

		}
		#endregion
		#region SClass L5ALSR_GSRfH_1045 for attribute L5ALSR_GSRfH_1045
		[DataContract]
		public class L5ALSR_GSRfH_1045 
		{
			[DataMember]
			public L5ALSR_GSRfH_1045a[] StockPositions { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid LOG_RCP_Receipt_HeaderID { get; set; } 
			[DataMember]
			public Guid SupplierID { get; set; } 
			[DataMember]
			public String SupplierName { get; set; } 
			[DataMember]
			public DateTime ExpectedDeliveryDate { get; set; } 

		}
		#endregion
		#region SClass L5ALSR_GSRfH_1045a for attribute StockPositions
		[DataContract]
		public class L5ALSR_GSRfH_1045a 
		{
			//Standard type parameters
			[DataMember]
			public Guid LOG_RCP_Receipt_PositionID { get; set; } 
			[DataMember]
			public Dict Product_Name { get; set; } 
			[DataMember]
			public String Product_Number { get; set; } 
			[DataMember]
			public Dict DosageForm_Name { get; set; } 
			[DataMember]
			public String GlobalPropertyMatchingID { get; set; } 
			[DataMember]
			public Dict Abbreviation { get; set; } 
			[DataMember]
			public String ISOCode { get; set; } 
			[DataMember]
			public double AEK_Price { get; set; } 
			[DataMember]
			public double Position_ValuePerUnit { get; set; } 
			[DataMember]
			public double PackageContent_Amount { get; set; } 
			[DataMember]
			public double Position_Quantity { get; set; } 
			[DataMember]
			public double TotalQuantityTakenIntoStock { get; set; } 
			[DataMember]
			public double Position_ValueTotal { get; set; } 
			[DataMember]
			public String BatchNumber { get; set; } 
			[DataMember]
			public DateTime ExpiryDate { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5ALSR_GSRfH_1045 cls_Get_StockReceipt_for_HeaderID(,P_L5ALSR_GSRfH_1045 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5ALSR_GSRfH_1045 invocationResult = cls_Get_StockReceipt_for_HeaderID.Invoke(connectionString,P_L5ALSR_GSRfH_1045 Parameter,securityTicket);
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
var parameter = new CL5_APOLogistic_StockReceipt.Atomic.Retrieval.P_L5ALSR_GSRfH_1045();
parameter.HeaderID = ...;

*/
