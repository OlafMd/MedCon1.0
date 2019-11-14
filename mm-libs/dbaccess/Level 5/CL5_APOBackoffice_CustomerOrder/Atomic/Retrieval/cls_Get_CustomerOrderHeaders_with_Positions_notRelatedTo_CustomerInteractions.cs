/* 
 * Generated on 6/19/2014 1:41:33 PM
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

namespace CL5_APOBackoffice_CustomerOrder.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_CustomerOrderHeaders_with_Positions_notRelatedTo_CustomerInteractions.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_CustomerOrderHeaders_with_Positions_notRelatedTo_CustomerInteractions
	{

		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5CO_GCOHwPnCI_0820_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5CO_GCOHwPnCI_0820_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOBackoffice_CustomerOrder.Atomic.Retrieval.SQL.cls_Get_CustomerOrderHeaders_with_Positions_notRelatedTo_CustomerInteractions.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L5CO_GCOHwPnCI_0820_raw> results = new List<L5CO_GCOHwPnCI_0820_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "ORD_CUO_CustomerOrder_HeaderID","IfCompany_CMN_COM_CompanyInfo_RefID","CustomerOrder_Number","OrderedByCompanyName","OrderedByEmail","CustomerOrder_Date","TotalValue_BeforeTax","Status_Code","Status_Name_DictID","GlobalPropertyMatchingID","OrderCreatedBy","IsCustomerOrderFinalized","ConfirmedBy_DisplayName","Product_Name_DictID","Product_Number","CustomerOrder_Header_RefID","PackageContent_Amount","PackageContent_MeasuredInUnit_RefID","DosageForm_Name_DictID","Abbreviation_DictID","Label_DictID","ORD_CUO_CustomerOrder_PositionID","Position_Quantity","Position_ValuePerUnit","Position_ValueTotal","TaxRate","TaxName_DictID","EconomicRegion_RefID","ApplicableSalesTax_RefID" });
				while(reader.Read())
				{
					L5CO_GCOHwPnCI_0820_raw resultItem = new L5CO_GCOHwPnCI_0820_raw();
					//0:Parameter ORD_CUO_CustomerOrder_HeaderID of type Guid
					resultItem.ORD_CUO_CustomerOrder_HeaderID = reader.GetGuid(0);
					//1:Parameter IfCompany_CMN_COM_CompanyInfo_RefID of type Guid
					resultItem.IfCompany_CMN_COM_CompanyInfo_RefID = reader.GetGuid(1);
					//2:Parameter CustomerOrder_Number of type String
					resultItem.CustomerOrder_Number = reader.GetString(2);
					//3:Parameter OrderedByCompanyName of type String
					resultItem.OrderedByCompanyName = reader.GetString(3);
					//4:Parameter OrderedByEmail of type String
					resultItem.OrderedByEmail = reader.GetString(4);
					//5:Parameter CustomerOrder_Date of type DateTime
					resultItem.CustomerOrder_Date = reader.GetDate(5);
					//6:Parameter TotalValue_BeforeTax of type Decimal
					resultItem.TotalValue_BeforeTax = reader.GetDecimal(6);
					//7:Parameter Status_Code of type String
					resultItem.Status_Code = reader.GetString(7);
					//8:Parameter Status_Name of type Dict
					resultItem.Status_Name = reader.GetDictionary(8);
					resultItem.Status_Name.SourceTable = "ord_cuo_customerorder_statuses";
					loader.Append(resultItem.Status_Name);
					//9:Parameter GlobalPropertyMatchingID of type String
					resultItem.GlobalPropertyMatchingID = reader.GetString(9);
					//10:Parameter OrderCreatedBy of type String
					resultItem.OrderCreatedBy = reader.GetString(10);
					//11:Parameter IsCustomerOrderFinalized of type Boolean
					resultItem.IsCustomerOrderFinalized = reader.GetBoolean(11);
					//12:Parameter ConfirmedBy_DisplayName of type String
					resultItem.ConfirmedBy_DisplayName = reader.GetString(12);
					//13:Parameter Product_Name of type Dict
					resultItem.Product_Name = reader.GetDictionary(13);
					resultItem.Product_Name.SourceTable = "cmn_pro_products";
					loader.Append(resultItem.Product_Name);
					//14:Parameter Product_Number of type String
					resultItem.Product_Number = reader.GetString(14);
					//15:Parameter CustomerOrder_Header_RefID of type Guid
					resultItem.CustomerOrder_Header_RefID = reader.GetGuid(15);
					//16:Parameter PackageContent_Amount of type String
					resultItem.PackageContent_Amount = reader.GetString(16);
					//17:Parameter PackageContent_MeasuredInUnit_RefID of type Guid
					resultItem.PackageContent_MeasuredInUnit_RefID = reader.GetGuid(17);
					//18:Parameter DosageForm_Name of type Dict
					resultItem.DosageForm_Name = reader.GetDictionary(18);
					resultItem.DosageForm_Name.SourceTable = "hec_product_dosageforms";
					loader.Append(resultItem.DosageForm_Name);
					//19:Parameter Abbreviation of type Dict
					resultItem.Abbreviation = reader.GetDictionary(19);
					resultItem.Abbreviation.SourceTable = "cmn_units";
					loader.Append(resultItem.Abbreviation);
					//20:Parameter Label of type Dict
					resultItem.Label = reader.GetDictionary(20);
					resultItem.Label.SourceTable = "cmn_units";
					loader.Append(resultItem.Label);
					//21:Parameter ORD_CUO_CustomerOrder_PositionID of type Guid
					resultItem.ORD_CUO_CustomerOrder_PositionID = reader.GetGuid(21);
					//22:Parameter Position_Quantity of type double
					resultItem.Position_Quantity = reader.GetDouble(22);
					//23:Parameter Position_ValuePerUnit of type Decimal
					resultItem.Position_ValuePerUnit = reader.GetDecimal(23);
					//24:Parameter Position_ValueTotal of type Decimal
					resultItem.Position_ValueTotal = reader.GetDecimal(24);
					//25:Parameter TaxRate of type double
					resultItem.TaxRate = reader.GetDouble(25);
					//26:Parameter TaxName_DictID of type Dict
					resultItem.TaxName_DictID = reader.GetDictionary(26);
					resultItem.TaxName_DictID.SourceTable = "acc_tax_taxes";
					loader.Append(resultItem.TaxName_DictID);
					//27:Parameter EconomicRegion_RefID of type Guid
					resultItem.EconomicRegion_RefID = reader.GetGuid(27);
					//28:Parameter ApplicableSalesTax_RefID of type Guid
					resultItem.ApplicableSalesTax_RefID = reader.GetGuid(28);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_CustomerOrderHeaders_with_Positions_notRelatedTo_CustomerInteractions",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5CO_GCOHwPnCI_0820_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5CO_GCOHwPnCI_0820_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5CO_GCOHwPnCI_0820_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5CO_GCOHwPnCI_0820_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5CO_GCOHwPnCI_0820_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5CO_GCOHwPnCI_0820_Array functionReturn = new FR_L5CO_GCOHwPnCI_0820_Array();
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

				functionReturn = Execute(Connection, Transaction,securityTicket);

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

				throw new Exception("Exception occured in method cls_Get_CustomerOrderHeaders_with_Positions_notRelatedTo_CustomerInteractions",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5CO_GCOHwPnCI_0820_raw 
	{
		public Guid ORD_CUO_CustomerOrder_HeaderID; 
		public Guid IfCompany_CMN_COM_CompanyInfo_RefID; 
		public String CustomerOrder_Number; 
		public String OrderedByCompanyName; 
		public String OrderedByEmail; 
		public DateTime CustomerOrder_Date; 
		public Decimal TotalValue_BeforeTax; 
		public String Status_Code; 
		public Dict Status_Name; 
		public String GlobalPropertyMatchingID; 
		public String OrderCreatedBy; 
		public Boolean IsCustomerOrderFinalized; 
		public String ConfirmedBy_DisplayName; 
		public Dict Product_Name; 
		public String Product_Number; 
		public Guid CustomerOrder_Header_RefID; 
		public String PackageContent_Amount; 
		public Guid PackageContent_MeasuredInUnit_RefID; 
		public Dict DosageForm_Name; 
		public Dict Abbreviation; 
		public Dict Label; 
		public Guid ORD_CUO_CustomerOrder_PositionID; 
		public double Position_Quantity; 
		public Decimal Position_ValuePerUnit; 
		public Decimal Position_ValueTotal; 
		public double TaxRate; 
		public Dict TaxName_DictID; 
		public Guid EconomicRegion_RefID; 
		public Guid ApplicableSalesTax_RefID; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5CO_GCOHwPnCI_0820[] Convert(List<L5CO_GCOHwPnCI_0820_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5CO_GCOHwPnCI_0820 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.ORD_CUO_CustomerOrder_HeaderID)).ToArray()
	group el_L5CO_GCOHwPnCI_0820 by new 
	{ 
		el_L5CO_GCOHwPnCI_0820.ORD_CUO_CustomerOrder_HeaderID,

	}
	into gfunct_L5CO_GCOHwPnCI_0820
	select new L5CO_GCOHwPnCI_0820
	{     
		ORD_CUO_CustomerOrder_HeaderID = gfunct_L5CO_GCOHwPnCI_0820.Key.ORD_CUO_CustomerOrder_HeaderID ,
		IfCompany_CMN_COM_CompanyInfo_RefID = gfunct_L5CO_GCOHwPnCI_0820.FirstOrDefault().IfCompany_CMN_COM_CompanyInfo_RefID ,
		CustomerOrder_Number = gfunct_L5CO_GCOHwPnCI_0820.FirstOrDefault().CustomerOrder_Number ,
		OrderedByCompanyName = gfunct_L5CO_GCOHwPnCI_0820.FirstOrDefault().OrderedByCompanyName ,
		OrderedByEmail = gfunct_L5CO_GCOHwPnCI_0820.FirstOrDefault().OrderedByEmail ,
		CustomerOrder_Date = gfunct_L5CO_GCOHwPnCI_0820.FirstOrDefault().CustomerOrder_Date ,
		TotalValue_BeforeTax = gfunct_L5CO_GCOHwPnCI_0820.FirstOrDefault().TotalValue_BeforeTax ,
		Status_Code = gfunct_L5CO_GCOHwPnCI_0820.FirstOrDefault().Status_Code ,
		Status_Name = gfunct_L5CO_GCOHwPnCI_0820.FirstOrDefault().Status_Name ,
		GlobalPropertyMatchingID = gfunct_L5CO_GCOHwPnCI_0820.FirstOrDefault().GlobalPropertyMatchingID ,
		OrderCreatedBy = gfunct_L5CO_GCOHwPnCI_0820.FirstOrDefault().OrderCreatedBy ,
		IsCustomerOrderFinalized = gfunct_L5CO_GCOHwPnCI_0820.FirstOrDefault().IsCustomerOrderFinalized ,
		ConfirmedBy_DisplayName = gfunct_L5CO_GCOHwPnCI_0820.FirstOrDefault().ConfirmedBy_DisplayName ,

		Positions = 
		(
			from el_Positions in gfunct_L5CO_GCOHwPnCI_0820.Where(element => !EqualsDefaultValue(element.ORD_CUO_CustomerOrder_PositionID)).ToArray()
			group el_Positions by new 
			{ 
				el_Positions.ORD_CUO_CustomerOrder_PositionID,

			}
			into gfunct_Positions
			select new L5CO_GAOWPfT_1518a
			{     
				Product_Name = gfunct_Positions.FirstOrDefault().Product_Name ,
				Product_Number = gfunct_Positions.FirstOrDefault().Product_Number ,
				CustomerOrder_Header_RefID = gfunct_Positions.FirstOrDefault().CustomerOrder_Header_RefID ,
				PackageContent_Amount = gfunct_Positions.FirstOrDefault().PackageContent_Amount ,
				PackageContent_MeasuredInUnit_RefID = gfunct_Positions.FirstOrDefault().PackageContent_MeasuredInUnit_RefID ,
				DosageForm_Name = gfunct_Positions.FirstOrDefault().DosageForm_Name ,
				Abbreviation = gfunct_Positions.FirstOrDefault().Abbreviation ,
				Label = gfunct_Positions.FirstOrDefault().Label ,
				ORD_CUO_CustomerOrder_PositionID = gfunct_Positions.Key.ORD_CUO_CustomerOrder_PositionID ,
				Position_Quantity = gfunct_Positions.FirstOrDefault().Position_Quantity ,
				Position_ValuePerUnit = gfunct_Positions.FirstOrDefault().Position_ValuePerUnit ,
				Position_ValueTotal = gfunct_Positions.FirstOrDefault().Position_ValueTotal ,
				TaxRate = gfunct_Positions.FirstOrDefault().TaxRate ,
				TaxName_DictID = gfunct_Positions.FirstOrDefault().TaxName_DictID ,
				EconomicRegion_RefID = gfunct_Positions.FirstOrDefault().EconomicRegion_RefID ,
				ApplicableSalesTax_RefID = gfunct_Positions.FirstOrDefault().ApplicableSalesTax_RefID ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5CO_GCOHwPnCI_0820_Array : FR_Base
	{
		public L5CO_GCOHwPnCI_0820[] Result	{ get; set; } 
		public FR_L5CO_GCOHwPnCI_0820_Array() : base() {}

		public FR_L5CO_GCOHwPnCI_0820_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5CO_GCOHwPnCI_0820 for attribute L5CO_GCOHwPnCI_0820
		[DataContract]
		public class L5CO_GCOHwPnCI_0820 
		{
			[DataMember]
			public L5CO_GAOWPfT_1518a[] Positions { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid ORD_CUO_CustomerOrder_HeaderID { get; set; } 
			[DataMember]
			public Guid IfCompany_CMN_COM_CompanyInfo_RefID { get; set; } 
			[DataMember]
			public String CustomerOrder_Number { get; set; } 
			[DataMember]
			public String OrderedByCompanyName { get; set; } 
			[DataMember]
			public String OrderedByEmail { get; set; } 
			[DataMember]
			public DateTime CustomerOrder_Date { get; set; } 
			[DataMember]
			public Decimal TotalValue_BeforeTax { get; set; } 
			[DataMember]
			public String Status_Code { get; set; } 
			[DataMember]
			public Dict Status_Name { get; set; } 
			[DataMember]
			public String GlobalPropertyMatchingID { get; set; } 
			[DataMember]
			public String OrderCreatedBy { get; set; } 
			[DataMember]
			public Boolean IsCustomerOrderFinalized { get; set; } 
			[DataMember]
			public String ConfirmedBy_DisplayName { get; set; } 

		}
		#endregion
		#region SClass L5CO_GAOWPfT_1518a for attribute Positions
		[DataContract]
		public class L5CO_GAOWPfT_1518a 
		{
			//Standard type parameters
			[DataMember]
			public Dict Product_Name { get; set; } 
			[DataMember]
			public String Product_Number { get; set; } 
			[DataMember]
			public Guid CustomerOrder_Header_RefID { get; set; } 
			[DataMember]
			public String PackageContent_Amount { get; set; } 
			[DataMember]
			public Guid PackageContent_MeasuredInUnit_RefID { get; set; } 
			[DataMember]
			public Dict DosageForm_Name { get; set; } 
			[DataMember]
			public Dict Abbreviation { get; set; } 
			[DataMember]
			public Dict Label { get; set; } 
			[DataMember]
			public Guid ORD_CUO_CustomerOrder_PositionID { get; set; } 
			[DataMember]
			public double Position_Quantity { get; set; } 
			[DataMember]
			public Decimal Position_ValuePerUnit { get; set; } 
			[DataMember]
			public Decimal Position_ValueTotal { get; set; } 
			[DataMember]
			public double TaxRate { get; set; } 
			[DataMember]
			public Dict TaxName_DictID { get; set; } 
			[DataMember]
			public Guid EconomicRegion_RefID { get; set; } 
			[DataMember]
			public Guid ApplicableSalesTax_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5CO_GCOHwPnCI_0820_Array cls_Get_CustomerOrderHeaders_with_Positions_notRelatedTo_CustomerInteractions(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5CO_GCOHwPnCI_0820_Array invocationResult = cls_Get_CustomerOrderHeaders_with_Positions_notRelatedTo_CustomerInteractions.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

