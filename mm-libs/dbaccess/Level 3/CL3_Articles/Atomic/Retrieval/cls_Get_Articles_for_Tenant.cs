/* 
 * Generated on 8/7/2014 8:56:03 AM
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
    /// var result = cls_Get_Articles_for_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Articles_for_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3AR_GAfT_0942_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3AR_GAfT_0942 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3AR_GAfT_0942_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_Articles.Atomic.Retrieval.SQL.cls_Get_Articles_for_Tenant.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"LanguageID", Parameter.LanguageID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ProductNameStartWith", Parameter.ProductNameStartWith);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ProducerName", Parameter.ProducerName);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"GeneralQuery", Parameter.GeneralQuery);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"DosageFormQuery", Parameter.DosageFormQuery);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"UnitQuery", Parameter.UnitQuery);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PZNQuery", Parameter.PZNQuery);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CustomArticlesGroupGlobalPropertyID", Parameter.CustomArticlesGroupGlobalPropertyID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ActiveComponent", Parameter.ActiveComponent);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ActiveComponentStartWith", Parameter.ActiveComponentStartWith);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"IsAvailableForOrdering", Parameter.IsAvailableForOrdering);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ProductID", Parameter.ProductID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"IsDefaultStock", Parameter.IsDefaultStock);



			List<L3AR_GAfT_0942_raw> results = new List<L3AR_GAfT_0942_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "ProductName","Product_Number","ProductGroup","CMN_PRO_ProductID","PackageInfo_RefID","ProductDistributionStatus","ProductType_Name_DictID","Product_Description_DictID","Abbreviation_DictID","Label_DictID","IsPlaceholderArticle","ProductITL","UnitAmount","UnitAmount_DisplayLabel","UnitIsoCode","DossageFormName","ProducerName","IfImportedFromExternalCatalog_CatalogSubscription_RefID","IsProductPartOfDefaultStock","HEC_PRO_ComponentID","Component_Name_DictID","Component_SimpleName","IsActiveComponent","HEC_SUB_SubstanceID","SubstanceName","ACC_TAX_TaxeID","EconomicRegion_RefID","TaxRate","TaxName_DictID" });
				while(reader.Read())
				{
					L3AR_GAfT_0942_raw resultItem = new L3AR_GAfT_0942_raw();
					//0:Parameter ProductName of type String
					resultItem.ProductName = reader.GetString(0);
					//1:Parameter Product_Number of type String
					resultItem.Product_Number = reader.GetString(1);
					//2:Parameter ProductGroup of type String
					resultItem.ProductGroup = reader.GetString(2);
					//3:Parameter CMN_PRO_ProductID of type Guid
					resultItem.CMN_PRO_ProductID = reader.GetGuid(3);
					//4:Parameter PackageInfo_RefID of type Guid
					resultItem.PackageInfo_RefID = reader.GetGuid(4);
					//5:Parameter ProductDistributionStatus of type int
					resultItem.ProductDistributionStatus = reader.GetInteger(5);
					//6:Parameter ProductType_Name of type Dict
					resultItem.ProductType_Name = reader.GetDictionary(6);
					resultItem.ProductType_Name.SourceTable = "cmn_pro_product_types";
					loader.Append(resultItem.ProductType_Name);
					//7:Parameter Product_Description of type Dict
					resultItem.Product_Description = reader.GetDictionary(7);
					resultItem.Product_Description.SourceTable = "cmn_pro_products";
					loader.Append(resultItem.Product_Description);
					//8:Parameter Abbreviation of type Dict
					resultItem.Abbreviation = reader.GetDictionary(8);
					resultItem.Abbreviation.SourceTable = "cmn_units";
					loader.Append(resultItem.Abbreviation);
					//9:Parameter Label of type Dict
					resultItem.Label = reader.GetDictionary(9);
					resultItem.Label.SourceTable = "cmn_units";
					loader.Append(resultItem.Label);
					//10:Parameter IsPlaceholderArticle of type bool
					resultItem.IsPlaceholderArticle = reader.GetBoolean(10);
					//11:Parameter ProductITL of type String
					resultItem.ProductITL = reader.GetString(11);
					//12:Parameter UnitAmount of type double
					resultItem.UnitAmount = reader.GetDouble(12);
					//13:Parameter UnitAmount_DisplayLabel of type String
					resultItem.UnitAmount_DisplayLabel = reader.GetString(13);
					//14:Parameter UnitIsoCode of type String
					resultItem.UnitIsoCode = reader.GetString(14);
					//15:Parameter DossageFormName of type string
					resultItem.DossageFormName = reader.GetString(15);
					//16:Parameter ProducerName of type string
					resultItem.ProducerName = reader.GetString(16);
					//17:Parameter IfImportedFromExternalCatalog_CatalogSubscription_RefID of type Guid
					resultItem.IfImportedFromExternalCatalog_CatalogSubscription_RefID = reader.GetGuid(17);
					//18:Parameter IsProductPartOfDefaultStock of type bool
					resultItem.IsProductPartOfDefaultStock = reader.GetBoolean(18);
					//19:Parameter HEC_PRO_ComponentID of type Guid
					resultItem.HEC_PRO_ComponentID = reader.GetGuid(19);
					//20:Parameter Component_Name of type Dict
					resultItem.Component_Name = reader.GetDictionary(20);
					resultItem.Component_Name.SourceTable = "hec_pro_components";
					loader.Append(resultItem.Component_Name);
					//21:Parameter Component_SimpleName of type String
					resultItem.Component_SimpleName = reader.GetString(21);
					//22:Parameter IsActiveComponent of type bool
					resultItem.IsActiveComponent = reader.GetBoolean(22);
					//23:Parameter HEC_SUB_SubstanceID of type Guid
					resultItem.HEC_SUB_SubstanceID = reader.GetGuid(23);
					//24:Parameter SubstanceName of type String
					resultItem.SubstanceName = reader.GetString(24);
					//25:Parameter ACC_TAX_TaxeID of type Guid
					resultItem.ACC_TAX_TaxeID = reader.GetGuid(25);
					//26:Parameter EconomicRegion_RefID of type Guid
					resultItem.EconomicRegion_RefID = reader.GetGuid(26);
					//27:Parameter TaxRate of type double
					resultItem.TaxRate = reader.GetDouble(27);
					//28:Parameter TaxName_DictID of type Dict
					resultItem.TaxName_DictID = reader.GetDictionary(28);
					resultItem.TaxName_DictID.SourceTable = "acc_tax_taxes";
					loader.Append(resultItem.TaxName_DictID);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Articles_for_Tenant",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L3AR_GAfT_0942_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3AR_GAfT_0942_Array Invoke(string ConnectionString,P_L3AR_GAfT_0942 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3AR_GAfT_0942_Array Invoke(DbConnection Connection,P_L3AR_GAfT_0942 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3AR_GAfT_0942_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3AR_GAfT_0942 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3AR_GAfT_0942_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3AR_GAfT_0942 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3AR_GAfT_0942_Array functionReturn = new FR_L3AR_GAfT_0942_Array();
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

				throw new Exception("Exception occured in method cls_Get_Articles_for_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L3AR_GAfT_0942_raw 
	{
		public String ProductName; 
		public String Product_Number; 
		public String ProductGroup; 
		public Guid CMN_PRO_ProductID; 
		public Guid PackageInfo_RefID; 
		public int ProductDistributionStatus; 
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
		public Guid IfImportedFromExternalCatalog_CatalogSubscription_RefID; 
		public bool IsProductPartOfDefaultStock; 
		public Guid HEC_PRO_ComponentID; 
		public Dict Component_Name; 
		public String Component_SimpleName; 
		public bool IsActiveComponent; 
		public Guid HEC_SUB_SubstanceID; 
		public String SubstanceName; 
		public Guid ACC_TAX_TaxeID; 
		public Guid EconomicRegion_RefID; 
		public double TaxRate; 
		public Dict TaxName_DictID; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L3AR_GAfT_0942[] Convert(List<L3AR_GAfT_0942_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L3AR_GAfT_0942 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.CMN_PRO_ProductID)).ToArray()
	group el_L3AR_GAfT_0942 by new 
	{ 
		el_L3AR_GAfT_0942.CMN_PRO_ProductID,

	}
	into gfunct_L3AR_GAfT_0942
	select new L3AR_GAfT_0942
	{     
		ProductName = gfunct_L3AR_GAfT_0942.FirstOrDefault().ProductName ,
		Product_Number = gfunct_L3AR_GAfT_0942.FirstOrDefault().Product_Number ,
		ProductGroup = gfunct_L3AR_GAfT_0942.FirstOrDefault().ProductGroup ,
		CMN_PRO_ProductID = gfunct_L3AR_GAfT_0942.Key.CMN_PRO_ProductID ,
		PackageInfo_RefID = gfunct_L3AR_GAfT_0942.FirstOrDefault().PackageInfo_RefID ,
		ProductDistributionStatus = gfunct_L3AR_GAfT_0942.FirstOrDefault().ProductDistributionStatus ,
		ProductType_Name = gfunct_L3AR_GAfT_0942.FirstOrDefault().ProductType_Name ,
		Product_Description = gfunct_L3AR_GAfT_0942.FirstOrDefault().Product_Description ,
		Abbreviation = gfunct_L3AR_GAfT_0942.FirstOrDefault().Abbreviation ,
		Label = gfunct_L3AR_GAfT_0942.FirstOrDefault().Label ,
		IsPlaceholderArticle = gfunct_L3AR_GAfT_0942.FirstOrDefault().IsPlaceholderArticle ,
		ProductITL = gfunct_L3AR_GAfT_0942.FirstOrDefault().ProductITL ,
		UnitAmount = gfunct_L3AR_GAfT_0942.FirstOrDefault().UnitAmount ,
		UnitAmount_DisplayLabel = gfunct_L3AR_GAfT_0942.FirstOrDefault().UnitAmount_DisplayLabel ,
		UnitIsoCode = gfunct_L3AR_GAfT_0942.FirstOrDefault().UnitIsoCode ,
		DossageFormName = gfunct_L3AR_GAfT_0942.FirstOrDefault().DossageFormName ,
		ProducerName = gfunct_L3AR_GAfT_0942.FirstOrDefault().ProducerName ,
		IfImportedFromExternalCatalog_CatalogSubscription_RefID = gfunct_L3AR_GAfT_0942.FirstOrDefault().IfImportedFromExternalCatalog_CatalogSubscription_RefID ,
		IsProductPartOfDefaultStock = gfunct_L3AR_GAfT_0942.FirstOrDefault().IsProductPartOfDefaultStock ,

		ActiveComponents = 
		(
			from el_ActiveComponents in gfunct_L3AR_GAfT_0942.Where(element => !EqualsDefaultValue(element.HEC_SUB_SubstanceID)).ToArray()
			group el_ActiveComponents by new 
			{ 
				el_ActiveComponents.HEC_SUB_SubstanceID,

			}
			into gfunct_ActiveComponents
			select new L3AR_GAfT_0942_ActiveComponent
			{     
				HEC_PRO_ComponentID = gfunct_ActiveComponents.FirstOrDefault().HEC_PRO_ComponentID ,
				Component_Name = gfunct_ActiveComponents.FirstOrDefault().Component_Name ,
				Component_SimpleName = gfunct_ActiveComponents.FirstOrDefault().Component_SimpleName ,
				IsActiveComponent = gfunct_ActiveComponents.FirstOrDefault().IsActiveComponent ,
				HEC_SUB_SubstanceID = gfunct_ActiveComponents.Key.HEC_SUB_SubstanceID ,
				SubstanceName = gfunct_ActiveComponents.FirstOrDefault().SubstanceName ,

			}
		).ToArray(),
		Taxes = 
		(
			from el_Taxes in gfunct_L3AR_GAfT_0942.Where(element => !EqualsDefaultValue(element.ACC_TAX_TaxeID)).ToArray()
			group el_Taxes by new 
			{ 
				el_Taxes.ACC_TAX_TaxeID,

			}
			into gfunct_Taxes
			select new L3AR_GAfT_0942_Tax
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
	public class FR_L3AR_GAfT_0942_Array : FR_Base
	{
		public L3AR_GAfT_0942[] Result	{ get; set; } 
		public FR_L3AR_GAfT_0942_Array() : base() {}

		public FR_L3AR_GAfT_0942_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3AR_GAfT_0942 for attribute P_L3AR_GAfT_0942
		[DataContract]
		public class P_L3AR_GAfT_0942 
		{
			//Standard type parameters
			[DataMember]
			public Guid LanguageID { get; set; } 
			[DataMember]
			public string ProductNameStartWith { get; set; } 
			[DataMember]
			public string ProducerName { get; set; } 
			[DataMember]
			public string GeneralQuery { get; set; } 
			[DataMember]
			public string DosageFormQuery { get; set; } 
			[DataMember]
			public string UnitQuery { get; set; } 
			[DataMember]
			public string PZNQuery { get; set; } 
			[DataMember]
			public string CustomArticlesGroupGlobalPropertyID { get; set; } 
			[DataMember]
			public string ActiveComponent { get; set; } 
			[DataMember]
			public string ActiveComponentStartWith { get; set; } 
			[DataMember]
			public bool? IsAvailableForOrdering { get; set; } 
			[DataMember]
			public Guid? ProductID { get; set; } 
			[DataMember]
			public bool? IsDefaultStock { get; set; } 

		}
		#endregion
		#region SClass L3AR_GAfT_0942 for attribute L3AR_GAfT_0942
		[DataContract]
		public class L3AR_GAfT_0942 
		{
			[DataMember]
			public L3AR_GAfT_0942_ActiveComponent[] ActiveComponents { get; set; }
			[DataMember]
			public L3AR_GAfT_0942_Tax[] Taxes { get; set; }

			//Standard type parameters
			[DataMember]
			public String ProductName { get; set; } 
			[DataMember]
			public String Product_Number { get; set; } 
			[DataMember]
			public String ProductGroup { get; set; } 
			[DataMember]
			public Guid CMN_PRO_ProductID { get; set; } 
			[DataMember]
			public Guid PackageInfo_RefID { get; set; } 
			[DataMember]
			public int ProductDistributionStatus { get; set; } 
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
			public Guid IfImportedFromExternalCatalog_CatalogSubscription_RefID { get; set; } 
			[DataMember]
			public bool IsProductPartOfDefaultStock { get; set; } 

		}
		#endregion
		#region SClass L3AR_GAfT_0942_ActiveComponent for attribute ActiveComponents
		[DataContract]
		public class L3AR_GAfT_0942_ActiveComponent 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_PRO_ComponentID { get; set; } 
			[DataMember]
			public Dict Component_Name { get; set; } 
			[DataMember]
			public String Component_SimpleName { get; set; } 
			[DataMember]
			public bool IsActiveComponent { get; set; } 
			[DataMember]
			public Guid HEC_SUB_SubstanceID { get; set; } 
			[DataMember]
			public String SubstanceName { get; set; } 

		}
		#endregion
		#region SClass L3AR_GAfT_0942_Tax for attribute Taxes
		[DataContract]
		public class L3AR_GAfT_0942_Tax 
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
FR_L3AR_GAfT_0942_Array cls_Get_Articles_for_Tenant(,P_L3AR_GAfT_0942 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3AR_GAfT_0942_Array invocationResult = cls_Get_Articles_for_Tenant.Invoke(connectionString,P_L3AR_GAfT_0942 Parameter,securityTicket);
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
var parameter = new CL3_Articles.Atomic.Retrieval.P_L3AR_GAfT_0942();
parameter.LanguageID = ...;
parameter.ProductNameStartWith = ...;
parameter.ProducerName = ...;
parameter.GeneralQuery = ...;
parameter.DosageFormQuery = ...;
parameter.UnitQuery = ...;
parameter.PZNQuery = ...;
parameter.CustomArticlesGroupGlobalPropertyID = ...;
parameter.ActiveComponent = ...;
parameter.ActiveComponentStartWith = ...;
parameter.IsAvailableForOrdering = ...;
parameter.ProductID = ...;
parameter.IsDefaultStock = ...;

*/
