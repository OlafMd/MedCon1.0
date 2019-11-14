/* 
 * Generated on 7/18/2014 1:05:38 PM
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

namespace CL3_Articles.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Articles_for_ArticleList.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Articles_for_ArticleList
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3AR_GAfAL_0942_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3AR_GAfAL_0942 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3AR_GAfAL_0942_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_Articles.Atomic.Retrieval.SQL.cls_Get_Articles_for_ArticleList.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@ProductID_List"," IN $$ProductID_List$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$ProductID_List$",Parameter.ProductID_List);
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ProducingBusinessParticipant", Parameter.ProducingBusinessParticipant);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ProductGroupID", Parameter.ProductGroupID);



			List<L3AR_GAfAL_0942_raw> results = new List<L3AR_GAfAL_0942_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "Product_Name_DictID","Product_Number","ProductGroup","CMN_PRO_ProductID","PackageInfo_RefID","ProductType_Name_DictID","Product_Description_DictID","Abbreviation_DictID","Label_DictID","IsPlaceholderArticle","ProductITL","UnitAmount","UnitAmount_DisplayLabel","UnitIsoCode","DossageFormName","ProducerName","ProducerId","IsStorage_BatchNumberMandatory","IsStorage_ExpiryDateMandatory","ACC_TAX_TaxeID","EconomicRegion_RefID","TaxRate","TaxName_DictID" });
				while(reader.Read())
				{
					L3AR_GAfAL_0942_raw resultItem = new L3AR_GAfAL_0942_raw();
					//0:Parameter Product_Name of type Dict
					resultItem.Product_Name = reader.GetDictionary(0);
					resultItem.Product_Name.SourceTable = "cmn_pro_products";
					loader.Append(resultItem.Product_Name);
					//1:Parameter Product_Number of type String
					resultItem.Product_Number = reader.GetString(1);
					//2:Parameter ProductGroup of type String
					resultItem.ProductGroup = reader.GetString(2);
					//3:Parameter CMN_PRO_ProductID of type Guid
					resultItem.CMN_PRO_ProductID = reader.GetGuid(3);
					//4:Parameter PackageInfo_RefID of type Guid
					resultItem.PackageInfo_RefID = reader.GetGuid(4);
					//5:Parameter ProductType_Name of type Dict
					resultItem.ProductType_Name = reader.GetDictionary(5);
					resultItem.ProductType_Name.SourceTable = "cmn_pro_product_types";
					loader.Append(resultItem.ProductType_Name);
					//6:Parameter Product_Description of type Dict
					resultItem.Product_Description = reader.GetDictionary(6);
					resultItem.Product_Description.SourceTable = "cmn_pro_products";
					loader.Append(resultItem.Product_Description);
					//7:Parameter Abbreviation of type Dict
					resultItem.Abbreviation = reader.GetDictionary(7);
					resultItem.Abbreviation.SourceTable = "cmn_units";
					loader.Append(resultItem.Abbreviation);
					//8:Parameter Label of type Dict
					resultItem.Label = reader.GetDictionary(8);
					resultItem.Label.SourceTable = "cmn_units";
					loader.Append(resultItem.Label);
					//9:Parameter IsPlaceholderArticle of type bool
					resultItem.IsPlaceholderArticle = reader.GetBoolean(9);
					//10:Parameter ProductITL of type String
					resultItem.ProductITL = reader.GetString(10);
					//11:Parameter UnitAmount of type double
					resultItem.UnitAmount = reader.GetDouble(11);
					//12:Parameter UnitAmount_DisplayLabel of type String
					resultItem.UnitAmount_DisplayLabel = reader.GetString(12);
					//13:Parameter UnitIsoCode of type String
					resultItem.UnitIsoCode = reader.GetString(13);
					//14:Parameter DossageFormName of type string
					resultItem.DossageFormName = reader.GetString(14);
					//15:Parameter ProducerName of type string
					resultItem.ProducerName = reader.GetString(15);
					//16:Parameter ProducerId of type Guid
					resultItem.ProducerId = reader.GetGuid(16);
					//17:Parameter IsStorage_BatchNumberMandatory of type bool
					resultItem.IsStorage_BatchNumberMandatory = reader.GetBoolean(17);
					//18:Parameter IsStorage_ExpiryDateMandatory of type bool
					resultItem.IsStorage_ExpiryDateMandatory = reader.GetBoolean(18);
					//19:Parameter ACC_TAX_TaxeID of type Guid
					resultItem.ACC_TAX_TaxeID = reader.GetGuid(19);
					//20:Parameter EconomicRegion_RefID of type Guid
					resultItem.EconomicRegion_RefID = reader.GetGuid(20);
					//21:Parameter TaxRate of type double
					resultItem.TaxRate = reader.GetDouble(21);
					//22:Parameter TaxName_DictID of type Dict
					resultItem.TaxName_DictID = reader.GetDictionary(22);
					resultItem.TaxName_DictID.SourceTable = "acc_tax_taxes";
					loader.Append(resultItem.TaxName_DictID);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Articles_for_ArticleList",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L3AR_GAfAL_0942_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3AR_GAfAL_0942_Array Invoke(string ConnectionString,P_L3AR_GAfAL_0942 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3AR_GAfAL_0942_Array Invoke(DbConnection Connection,P_L3AR_GAfAL_0942 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3AR_GAfAL_0942_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3AR_GAfAL_0942 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3AR_GAfAL_0942_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3AR_GAfAL_0942 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3AR_GAfAL_0942_Array functionReturn = new FR_L3AR_GAfAL_0942_Array();
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

				throw new Exception("Exception occured in method cls_Get_Articles_for_ArticleList",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L3AR_GAfAL_0942_raw 
	{
		public Dict Product_Name; 
		public String Product_Number; 
		public String ProductGroup; 
		public Guid CMN_PRO_ProductID; 
		public Guid PackageInfo_RefID; 
		public Dict ProductType_Name; 
		public Dict Product_Description; 
		public Dict Abbreviation; 
		public Dict Label; 
		public bool IsPlaceholderArticle; 
		public String ProductITL; 
		public double UnitAmount; 
		public String UnitAmount_DisplayLabel; 
		public String UnitIsoCode; 
		public string DossageFormName; 
		public string ProducerName; 
		public Guid ProducerId; 
		public bool IsStorage_BatchNumberMandatory; 
		public bool IsStorage_ExpiryDateMandatory; 
		public Guid ACC_TAX_TaxeID; 
		public Guid EconomicRegion_RefID; 
		public double TaxRate; 
		public Dict TaxName_DictID; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L3AR_GAfAL_0942[] Convert(List<L3AR_GAfAL_0942_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L3AR_GAfAL_0942 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.CMN_PRO_ProductID)).ToArray()
	group el_L3AR_GAfAL_0942 by new 
	{ 
		el_L3AR_GAfAL_0942.CMN_PRO_ProductID,

	}
	into gfunct_L3AR_GAfAL_0942
	select new L3AR_GAfAL_0942
	{     
		Product_Name = gfunct_L3AR_GAfAL_0942.FirstOrDefault().Product_Name ,
		Product_Number = gfunct_L3AR_GAfAL_0942.FirstOrDefault().Product_Number ,
		ProductGroup = gfunct_L3AR_GAfAL_0942.FirstOrDefault().ProductGroup ,
		CMN_PRO_ProductID = gfunct_L3AR_GAfAL_0942.Key.CMN_PRO_ProductID ,
		PackageInfo_RefID = gfunct_L3AR_GAfAL_0942.FirstOrDefault().PackageInfo_RefID ,
		ProductType_Name = gfunct_L3AR_GAfAL_0942.FirstOrDefault().ProductType_Name ,
		Product_Description = gfunct_L3AR_GAfAL_0942.FirstOrDefault().Product_Description ,
		Abbreviation = gfunct_L3AR_GAfAL_0942.FirstOrDefault().Abbreviation ,
		Label = gfunct_L3AR_GAfAL_0942.FirstOrDefault().Label ,
		IsPlaceholderArticle = gfunct_L3AR_GAfAL_0942.FirstOrDefault().IsPlaceholderArticle ,
		ProductITL = gfunct_L3AR_GAfAL_0942.FirstOrDefault().ProductITL ,
		UnitAmount = gfunct_L3AR_GAfAL_0942.FirstOrDefault().UnitAmount ,
		UnitAmount_DisplayLabel = gfunct_L3AR_GAfAL_0942.FirstOrDefault().UnitAmount_DisplayLabel ,
		UnitIsoCode = gfunct_L3AR_GAfAL_0942.FirstOrDefault().UnitIsoCode ,
		DossageFormName = gfunct_L3AR_GAfAL_0942.FirstOrDefault().DossageFormName ,
		ProducerName = gfunct_L3AR_GAfAL_0942.FirstOrDefault().ProducerName ,
		ProducerId = gfunct_L3AR_GAfAL_0942.FirstOrDefault().ProducerId ,
		IsStorage_BatchNumberMandatory = gfunct_L3AR_GAfAL_0942.FirstOrDefault().IsStorage_BatchNumberMandatory ,
		IsStorage_ExpiryDateMandatory = gfunct_L3AR_GAfAL_0942.FirstOrDefault().IsStorage_ExpiryDateMandatory ,

		Taxes = 
		(
			from el_Taxes in gfunct_L3AR_GAfAL_0942.Where(element => !EqualsDefaultValue(element.ACC_TAX_TaxeID)).ToArray()
			group el_Taxes by new 
			{ 
				el_Taxes.ACC_TAX_TaxeID,

			}
			into gfunct_Taxes
			select new L3AR_GAfAL_0942_Tax
			{     
				ACC_TAX_TaxeID = gfunct_Taxes.Key.ACC_TAX_TaxeID ,
				EconomicRegion_RefID = gfunct_Taxes.FirstOrDefault().EconomicRegion_RefID ,
				TaxRate = gfunct_Taxes.FirstOrDefault().TaxRate ,
				TaxName_DictID = gfunct_Taxes.FirstOrDefault().TaxName_DictID ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L3AR_GAfAL_0942_Array : FR_Base
	{
		public L3AR_GAfAL_0942[] Result	{ get; set; } 
		public FR_L3AR_GAfAL_0942_Array() : base() {}

		public FR_L3AR_GAfAL_0942_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3AR_GAfAL_0942 for attribute P_L3AR_GAfAL_0942
		[DataContract]
		public class P_L3AR_GAfAL_0942 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] ProductID_List { get; set; } 
			[DataMember]
			public Guid? ProducingBusinessParticipant { get; set; } 
			[DataMember]
			public Guid? ProductGroupID { get; set; } 

		}
		#endregion
		#region SClass L3AR_GAfAL_0942 for attribute L3AR_GAfAL_0942
		[DataContract]
		public class L3AR_GAfAL_0942 
		{
			[DataMember]
			public L3AR_GAfAL_0942_Tax[] Taxes { get; set; }

			//Standard type parameters
			[DataMember]
			public Dict Product_Name { get; set; } 
			[DataMember]
			public String Product_Number { get; set; } 
			[DataMember]
			public String ProductGroup { get; set; } 
			[DataMember]
			public Guid CMN_PRO_ProductID { get; set; } 
			[DataMember]
			public Guid PackageInfo_RefID { get; set; } 
			[DataMember]
			public Dict ProductType_Name { get; set; } 
			[DataMember]
			public Dict Product_Description { get; set; } 
			[DataMember]
			public Dict Abbreviation { get; set; } 
			[DataMember]
			public Dict Label { get; set; } 
			[DataMember]
			public bool IsPlaceholderArticle { get; set; } 
			[DataMember]
			public String ProductITL { get; set; } 
			[DataMember]
			public double UnitAmount { get; set; } 
			[DataMember]
			public String UnitAmount_DisplayLabel { get; set; } 
			[DataMember]
			public String UnitIsoCode { get; set; } 
			[DataMember]
			public string DossageFormName { get; set; } 
			[DataMember]
			public string ProducerName { get; set; } 
			[DataMember]
			public Guid ProducerId { get; set; } 
			[DataMember]
			public bool IsStorage_BatchNumberMandatory { get; set; } 
			[DataMember]
			public bool IsStorage_ExpiryDateMandatory { get; set; } 

		}
		#endregion
		#region SClass L3AR_GAfAL_0942_Tax for attribute Taxes
		[DataContract]
		public class L3AR_GAfAL_0942_Tax 
		{
			//Standard type parameters
			[DataMember]
			public Guid ACC_TAX_TaxeID { get; set; } 
			[DataMember]
			public Guid EconomicRegion_RefID { get; set; } 
			[DataMember]
			public double TaxRate { get; set; } 
			[DataMember]
			public Dict TaxName_DictID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3AR_GAfAL_0942_Array cls_Get_Articles_for_ArticleList(,P_L3AR_GAfAL_0942 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3AR_GAfAL_0942_Array invocationResult = cls_Get_Articles_for_ArticleList.Invoke(connectionString,P_L3AR_GAfAL_0942 Parameter,securityTicket);
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
var parameter = new CL3_Articles.Atomic.Retrieval.P_L3AR_GAfAL_0942();
parameter.ProductID_List = ...;
parameter.ProducingBusinessParticipant = ...;
parameter.ProductGroupID = ...;

*/
