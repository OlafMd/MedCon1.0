/* 
 * Generated on 6/3/2014 10:00:17 AM
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
    /// var result = cls_Get_HitList_for_OfficeID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_HitList_for_OfficeID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5AWSSC_GHLfO_1407_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5AWSSC_GHLfO_1407 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5AWSSC_GHLfO_1407_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOWebShop_ShoppingCart.Atomic.Retrieval.SQL.cls_Get_HitList_for_OfficeID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@ProductGroupMatchingID_List"," IN $$ProductGroupMatchingID_List$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$ProductGroupMatchingID_List$",Parameter.ProductGroupMatchingID_List);
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"OfficeID", Parameter.OfficeID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"NumberOfLastDays", Parameter.NumberOfLastDays);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"LanguageID", Parameter.LanguageID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ProductNameStartWith", Parameter.ProductNameStartWith);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ProductNameContains", Parameter.ProductNameContains);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ProductNumberContains", Parameter.ProductNumberContains);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ActiveComponentContains", Parameter.ActiveComponentContains);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ActiveComponentStartWith", Parameter.ActiveComponentStartWith);



			List<L5AWSSC_GHLfO_1407_raw> results = new List<L5AWSSC_GHLfO_1407_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_PRO_ProductID","ProductName","Product_Number","ProductDistributionStatus","Group_GlobalPropertyMatchingID","HEC_Product_DosageFormID","DosageForm_GlobalPropertyMatchingID","UnitIsoCode","UnitAmount","UnitAmount_DisplayLabel","IsProductAvailableForOrdering","Price","CurrencyISO","CurrencySymbol","Quantity","HEC_PRO_ComponentID","Component_Name_DictID","Component_SimpleName","IsActiveComponent","HEC_SUB_SubstanceID","SubstanceName" });
				while(reader.Read())
				{
					L5AWSSC_GHLfO_1407_raw resultItem = new L5AWSSC_GHLfO_1407_raw();
					//0:Parameter CMN_PRO_ProductID of type Guid
					resultItem.CMN_PRO_ProductID = reader.GetGuid(0);
					//1:Parameter ProductName of type string
					resultItem.ProductName = reader.GetString(1);
					//2:Parameter Product_Number of type String
					resultItem.Product_Number = reader.GetString(2);
					//3:Parameter ProductDistributionStatus of type int
					resultItem.ProductDistributionStatus = reader.GetInteger(3);
					//4:Parameter Group_GlobalPropertyMatchingID of type String
					resultItem.Group_GlobalPropertyMatchingID = reader.GetString(4);
					//5:Parameter HEC_Product_DosageFormID of type Guid
					resultItem.HEC_Product_DosageFormID = reader.GetGuid(5);
					//6:Parameter DosageForm_GlobalPropertyMatchingID of type string
					resultItem.DosageForm_GlobalPropertyMatchingID = reader.GetString(6);
					//7:Parameter UnitIsoCode of type string
					resultItem.UnitIsoCode = reader.GetString(7);
					//8:Parameter UnitAmount of type double
					resultItem.UnitAmount = reader.GetDouble(8);
					//9:Parameter UnitAmount_DisplayLabel of type String
					resultItem.UnitAmount_DisplayLabel = reader.GetString(9);
					//10:Parameter IsProductAvailableForOrdering of type bool
					resultItem.IsProductAvailableForOrdering = reader.GetBoolean(10);
					//11:Parameter Price of type decimal
					resultItem.Price = reader.GetDecimal(11);
					//12:Parameter CurrencyISO of type string
					resultItem.CurrencyISO = reader.GetString(12);
					//13:Parameter CurrencySymbol of type string
					resultItem.CurrencySymbol = reader.GetString(13);
					//14:Parameter Quantity of type double
					resultItem.Quantity = reader.GetDouble(14);
					//15:Parameter HEC_PRO_ComponentID of type Guid
					resultItem.HEC_PRO_ComponentID = reader.GetGuid(15);
					//16:Parameter Component_Name of type Dict
					resultItem.Component_Name = reader.GetDictionary(16);
					resultItem.Component_Name.SourceTable = "hec_pro_components";
					loader.Append(resultItem.Component_Name);
					//17:Parameter Component_SimpleName of type String
					resultItem.Component_SimpleName = reader.GetString(17);
					//18:Parameter IsActiveComponent of type bool
					resultItem.IsActiveComponent = reader.GetBoolean(18);
					//19:Parameter HEC_SUB_SubstanceID of type Guid
					resultItem.HEC_SUB_SubstanceID = reader.GetGuid(19);
					//20:Parameter SubstanceName of type String
					resultItem.SubstanceName = reader.GetString(20);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_HitList_for_OfficeID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5AWSSC_GHLfO_1407_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5AWSSC_GHLfO_1407_Array Invoke(string ConnectionString,P_L5AWSSC_GHLfO_1407 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5AWSSC_GHLfO_1407_Array Invoke(DbConnection Connection,P_L5AWSSC_GHLfO_1407 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5AWSSC_GHLfO_1407_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AWSSC_GHLfO_1407 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5AWSSC_GHLfO_1407_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AWSSC_GHLfO_1407 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5AWSSC_GHLfO_1407_Array functionReturn = new FR_L5AWSSC_GHLfO_1407_Array();
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

				throw new Exception("Exception occured in method cls_Get_HitList_for_OfficeID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5AWSSC_GHLfO_1407_raw 
	{
		public Guid CMN_PRO_ProductID; 
		public string ProductName; 
		public String Product_Number; 
		public int ProductDistributionStatus; 
		public String Group_GlobalPropertyMatchingID; 
		public Guid HEC_Product_DosageFormID; 
		public string DosageForm_GlobalPropertyMatchingID; 
		public string UnitIsoCode; 
		public double UnitAmount; 
		public String UnitAmount_DisplayLabel; 
		public bool IsProductAvailableForOrdering; 
		public decimal Price; 
		public string CurrencyISO; 
		public string CurrencySymbol; 
		public double Quantity; 
		public Guid HEC_PRO_ComponentID; 
		public Dict Component_Name; 
		public String Component_SimpleName; 
		public bool IsActiveComponent; 
		public Guid HEC_SUB_SubstanceID; 
		public String SubstanceName; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5AWSSC_GHLfO_1407[] Convert(List<L5AWSSC_GHLfO_1407_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5AWSSC_GHLfO_1407 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.CMN_PRO_ProductID)).ToArray()
	group el_L5AWSSC_GHLfO_1407 by new 
	{ 
		el_L5AWSSC_GHLfO_1407.CMN_PRO_ProductID,

	}
	into gfunct_L5AWSSC_GHLfO_1407
	select new L5AWSSC_GHLfO_1407
	{     
		CMN_PRO_ProductID = gfunct_L5AWSSC_GHLfO_1407.Key.CMN_PRO_ProductID ,
		ProductName = gfunct_L5AWSSC_GHLfO_1407.FirstOrDefault().ProductName ,
		Product_Number = gfunct_L5AWSSC_GHLfO_1407.FirstOrDefault().Product_Number ,
		ProductDistributionStatus = gfunct_L5AWSSC_GHLfO_1407.FirstOrDefault().ProductDistributionStatus ,
		Group_GlobalPropertyMatchingID = gfunct_L5AWSSC_GHLfO_1407.FirstOrDefault().Group_GlobalPropertyMatchingID ,
		HEC_Product_DosageFormID = gfunct_L5AWSSC_GHLfO_1407.FirstOrDefault().HEC_Product_DosageFormID ,
		DosageForm_GlobalPropertyMatchingID = gfunct_L5AWSSC_GHLfO_1407.FirstOrDefault().DosageForm_GlobalPropertyMatchingID ,
		UnitIsoCode = gfunct_L5AWSSC_GHLfO_1407.FirstOrDefault().UnitIsoCode ,
		UnitAmount = gfunct_L5AWSSC_GHLfO_1407.FirstOrDefault().UnitAmount ,
		UnitAmount_DisplayLabel = gfunct_L5AWSSC_GHLfO_1407.FirstOrDefault().UnitAmount_DisplayLabel ,
		IsProductAvailableForOrdering = gfunct_L5AWSSC_GHLfO_1407.FirstOrDefault().IsProductAvailableForOrdering ,
		Price = gfunct_L5AWSSC_GHLfO_1407.FirstOrDefault().Price ,
		CurrencyISO = gfunct_L5AWSSC_GHLfO_1407.FirstOrDefault().CurrencyISO ,
		CurrencySymbol = gfunct_L5AWSSC_GHLfO_1407.FirstOrDefault().CurrencySymbol ,
		Quantity = gfunct_L5AWSSC_GHLfO_1407.FirstOrDefault().Quantity ,

		ActiveComponents = 
		(
			from el_ActiveComponents in gfunct_L5AWSSC_GHLfO_1407.Where(element => !EqualsDefaultValue(element.HEC_SUB_SubstanceID)).ToArray()
			group el_ActiveComponents by new 
			{ 
				el_ActiveComponents.HEC_SUB_SubstanceID,

			}
			into gfunct_ActiveComponents
			select new L5AWSSC_GHLfO_1407_ActiveComponent
			{     
				HEC_PRO_ComponentID = gfunct_ActiveComponents.FirstOrDefault().HEC_PRO_ComponentID ,
				Component_Name = gfunct_ActiveComponents.FirstOrDefault().Component_Name ,
				Component_SimpleName = gfunct_ActiveComponents.FirstOrDefault().Component_SimpleName ,
				IsActiveComponent = gfunct_ActiveComponents.FirstOrDefault().IsActiveComponent ,
				HEC_SUB_SubstanceID = gfunct_ActiveComponents.Key.HEC_SUB_SubstanceID ,
				SubstanceName = gfunct_ActiveComponents.FirstOrDefault().SubstanceName ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5AWSSC_GHLfO_1407_Array : FR_Base
	{
		public L5AWSSC_GHLfO_1407[] Result	{ get; set; } 
		public FR_L5AWSSC_GHLfO_1407_Array() : base() {}

		public FR_L5AWSSC_GHLfO_1407_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5AWSSC_GHLfO_1407 for attribute P_L5AWSSC_GHLfO_1407
		[DataContract]
		public class P_L5AWSSC_GHLfO_1407 
		{
			//Standard type parameters
			[DataMember]
			public String[] ProductGroupMatchingID_List { get; set; } 
			[DataMember]
			public Guid OfficeID { get; set; } 
			[DataMember]
			public int NumberOfLastDays { get; set; } 
			[DataMember]
			public Guid LanguageID { get; set; } 
			[DataMember]
			public string ProductNameStartWith { get; set; } 
			[DataMember]
			public string ProductNameContains { get; set; } 
			[DataMember]
			public string ProductNumberContains { get; set; } 
			[DataMember]
			public string ActiveComponentContains { get; set; } 
			[DataMember]
			public string ActiveComponentStartWith { get; set; } 

		}
		#endregion
		#region SClass L5AWSSC_GHLfO_1407 for attribute L5AWSSC_GHLfO_1407
		[DataContract]
		public class L5AWSSC_GHLfO_1407 
		{
			[DataMember]
			public L5AWSSC_GHLfO_1407_ActiveComponent[] ActiveComponents { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_ProductID { get; set; } 
			[DataMember]
			public string ProductName { get; set; } 
			[DataMember]
			public String Product_Number { get; set; } 
			[DataMember]
			public int ProductDistributionStatus { get; set; } 
			[DataMember]
			public String Group_GlobalPropertyMatchingID { get; set; } 
			[DataMember]
			public Guid HEC_Product_DosageFormID { get; set; } 
			[DataMember]
			public string DosageForm_GlobalPropertyMatchingID { get; set; } 
			[DataMember]
			public string UnitIsoCode { get; set; } 
			[DataMember]
			public double UnitAmount { get; set; } 
			[DataMember]
			public String UnitAmount_DisplayLabel { get; set; } 
			[DataMember]
			public bool IsProductAvailableForOrdering { get; set; } 
			[DataMember]
			public decimal Price { get; set; } 
			[DataMember]
			public string CurrencyISO { get; set; } 
			[DataMember]
			public string CurrencySymbol { get; set; } 
			[DataMember]
			public double Quantity { get; set; } 

		}
		#endregion
		#region SClass L5AWSSC_GHLfO_1407_ActiveComponent for attribute ActiveComponents
		[DataContract]
		public class L5AWSSC_GHLfO_1407_ActiveComponent 
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

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5AWSSC_GHLfO_1407_Array cls_Get_HitList_for_OfficeID(,P_L5AWSSC_GHLfO_1407 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5AWSSC_GHLfO_1407_Array invocationResult = cls_Get_HitList_for_OfficeID.Invoke(connectionString,P_L5AWSSC_GHLfO_1407 Parameter,securityTicket);
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
var parameter = new CL5_APOWebShop_ShoppingCart.Atomic.Retrieval.P_L5AWSSC_GHLfO_1407();
parameter.ProductGroupMatchingID_List = ...;
parameter.OfficeID = ...;
parameter.NumberOfLastDays = ...;
parameter.LanguageID = ...;
parameter.ProductNameStartWith = ...;
parameter.ProductNameContains = ...;
parameter.ProductNumberContains = ...;
parameter.ActiveComponentContains = ...;
parameter.ActiveComponentStartWith = ...;

*/
