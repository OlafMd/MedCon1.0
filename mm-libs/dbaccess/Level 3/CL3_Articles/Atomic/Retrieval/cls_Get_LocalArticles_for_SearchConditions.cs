/* 
 * Generated on 8/21/2014 2:58:07 PM
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
using System.Runtime.Serialization;

namespace CL3_Articles.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_LocalArticles_for_SearchConditions.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_LocalArticles_for_SearchConditions
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3AR_GLAfSC_1320_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3AR_GLAfSC_1320 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3AR_GLAfSC_1320_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_Articles.Atomic.Retrieval.SQL.cls_Get_LocalArticles_for_SearchConditions.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"LanguageID", Parameter.LanguageID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ProductNameStartWith", Parameter.ProductNameStartWith);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ActiveComponentStartWith", Parameter.ActiveComponentStartWith);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PZNOrName", Parameter.PZNOrName);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"DosageForm", Parameter.DosageForm);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"Unit", Parameter.Unit);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ProducerName", Parameter.ProducerName);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ActiveComponent", Parameter.ActiveComponent);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"IsAvailableForOrdering", Parameter.IsAvailableForOrdering);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"IsDefaultStock", Parameter.IsDefaultStock);



			List<L3AR_GLAfSC_1320_raw> results = new List<L3AR_GLAfSC_1320_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_PRO_ProductID","ProductITL","ProductName","Product_Number","IsProductPartOfDefaultStock","ProductDistributionStatus","ProducerName","UnitAmount_DisplayLabel","UnitIsoCode","DossageFormName","TaxRate","IsActiveComponent","SubstanceName" });
				while(reader.Read())
				{
					L3AR_GLAfSC_1320_raw resultItem = new L3AR_GLAfSC_1320_raw();
					//0:Parameter CMN_PRO_ProductID of type Guid
					resultItem.CMN_PRO_ProductID = reader.GetGuid(0);
					//1:Parameter ProductITL of type String
					resultItem.ProductITL = reader.GetString(1);
					//2:Parameter ProductName of type String
					resultItem.ProductName = reader.GetString(2);
					//3:Parameter Product_Number of type String
					resultItem.Product_Number = reader.GetString(3);
					//4:Parameter IsProductPartOfDefaultStock of type bool
					resultItem.IsProductPartOfDefaultStock = reader.GetBoolean(4);
					//5:Parameter ProductDistributionStatus of type int
					resultItem.ProductDistributionStatus = reader.GetInteger(5);
					//6:Parameter ProducerName of type string
					resultItem.ProducerName = reader.GetString(6);
					//7:Parameter UnitAmount_DisplayLabel of type String
					resultItem.UnitAmount_DisplayLabel = reader.GetString(7);
					//8:Parameter UnitIsoCode of type String
					resultItem.UnitIsoCode = reader.GetString(8);
					//9:Parameter DossageFormName of type string
					resultItem.DossageFormName = reader.GetString(9);
					//10:Parameter TaxRate of type double
					resultItem.TaxRate = reader.GetDouble(10);
					//11:Parameter IsActiveComponent of type bool
					resultItem.IsActiveComponent = reader.GetBoolean(11);
					//12:Parameter SubstanceName of type String
					resultItem.SubstanceName = reader.GetString(12);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_LocalArticles_for_SearchConditions",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L3AR_GLAfSC_1320_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3AR_GLAfSC_1320_Array Invoke(string ConnectionString,P_L3AR_GLAfSC_1320 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3AR_GLAfSC_1320_Array Invoke(DbConnection Connection,P_L3AR_GLAfSC_1320 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3AR_GLAfSC_1320_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3AR_GLAfSC_1320 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3AR_GLAfSC_1320_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3AR_GLAfSC_1320 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3AR_GLAfSC_1320_Array functionReturn = new FR_L3AR_GLAfSC_1320_Array();
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

				throw new Exception("Exception occured in method cls_Get_LocalArticles_for_SearchConditions",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L3AR_GLAfSC_1320_raw 
	{
		public Guid CMN_PRO_ProductID; 
		public String ProductITL; 
		public String ProductName; 
		public String Product_Number; 
		public bool IsProductPartOfDefaultStock; 
		public int ProductDistributionStatus; 
		public string ProducerName; 
		public String UnitAmount_DisplayLabel; 
		public String UnitIsoCode; 
		public string DossageFormName; 
		public double TaxRate; 
		public bool IsActiveComponent; 
		public String SubstanceName; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L3AR_GLAfSC_1320[] Convert(List<L3AR_GLAfSC_1320_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L3AR_GLAfSC_1320 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.CMN_PRO_ProductID)).ToArray()
	group el_L3AR_GLAfSC_1320 by new 
	{ 
		el_L3AR_GLAfSC_1320.CMN_PRO_ProductID,

	}
	into gfunct_L3AR_GLAfSC_1320
	select new L3AR_GLAfSC_1320
	{     
		CMN_PRO_ProductID = gfunct_L3AR_GLAfSC_1320.Key.CMN_PRO_ProductID ,
		ProductITL = gfunct_L3AR_GLAfSC_1320.FirstOrDefault().ProductITL ,
		ProductName = gfunct_L3AR_GLAfSC_1320.FirstOrDefault().ProductName ,
		Product_Number = gfunct_L3AR_GLAfSC_1320.FirstOrDefault().Product_Number ,
		IsProductPartOfDefaultStock = gfunct_L3AR_GLAfSC_1320.FirstOrDefault().IsProductPartOfDefaultStock ,
		ProductDistributionStatus = gfunct_L3AR_GLAfSC_1320.FirstOrDefault().ProductDistributionStatus ,
		ProducerName = gfunct_L3AR_GLAfSC_1320.FirstOrDefault().ProducerName ,
		UnitAmount_DisplayLabel = gfunct_L3AR_GLAfSC_1320.FirstOrDefault().UnitAmount_DisplayLabel ,
		UnitIsoCode = gfunct_L3AR_GLAfSC_1320.FirstOrDefault().UnitIsoCode ,
		DossageFormName = gfunct_L3AR_GLAfSC_1320.FirstOrDefault().DossageFormName ,
		TaxRate = gfunct_L3AR_GLAfSC_1320.FirstOrDefault().TaxRate ,

		ActiveComponents = 
		(
			from el_ActiveComponents in gfunct_L3AR_GLAfSC_1320.ToArray()
			group el_ActiveComponents by new 
			{ 
			}
			into gfunct_ActiveComponents
			select new L3AR_GLAfSC_1320_ActiveComponent
			{     
				IsActiveComponent = gfunct_ActiveComponents.FirstOrDefault().IsActiveComponent ,
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
	public class FR_L3AR_GLAfSC_1320_Array : FR_Base
	{
		public L3AR_GLAfSC_1320[] Result	{ get; set; } 
		public FR_L3AR_GLAfSC_1320_Array() : base() {}

		public FR_L3AR_GLAfSC_1320_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3AR_GLAfSC_1320 for attribute P_L3AR_GLAfSC_1320
		[DataContract]
		public class P_L3AR_GLAfSC_1320 
		{
			//Standard type parameters
			[DataMember]
			public Guid LanguageID { get; set; } 
			[DataMember]
			public string ProductNameStartWith { get; set; } 
			[DataMember]
			public string ActiveComponentStartWith { get; set; } 
			[DataMember]
			public string PZNOrName { get; set; } 
			[DataMember]
			public string DosageForm { get; set; } 
			[DataMember]
			public string Unit { get; set; } 
			[DataMember]
			public string ProducerName { get; set; } 
			[DataMember]
			public string ActiveComponent { get; set; } 
			[DataMember]
			public bool? IsAvailableForOrdering { get; set; } 
			[DataMember]
			public bool? IsDefaultStock { get; set; } 

		}
		#endregion
		#region SClass L3AR_GLAfSC_1320 for attribute L3AR_GLAfSC_1320
		[DataContract]
		public class L3AR_GLAfSC_1320 
		{
			[DataMember]
			public L3AR_GLAfSC_1320_ActiveComponent[] ActiveComponents { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_ProductID { get; set; } 
			[DataMember]
			public String ProductITL { get; set; } 
			[DataMember]
			public String ProductName { get; set; } 
			[DataMember]
			public String Product_Number { get; set; } 
			[DataMember]
			public bool IsProductPartOfDefaultStock { get; set; } 
			[DataMember]
			public int ProductDistributionStatus { get; set; } 
			[DataMember]
			public string ProducerName { get; set; } 
			[DataMember]
			public String UnitAmount_DisplayLabel { get; set; } 
			[DataMember]
			public String UnitIsoCode { get; set; } 
			[DataMember]
			public string DossageFormName { get; set; } 
			[DataMember]
			public double TaxRate { get; set; } 

		}
		#endregion
		#region SClass L3AR_GLAfSC_1320_ActiveComponent for attribute ActiveComponents
		[DataContract]
		public class L3AR_GLAfSC_1320_ActiveComponent 
		{
			//Standard type parameters
			[DataMember]
			public bool IsActiveComponent { get; set; } 
			[DataMember]
			public String SubstanceName { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3AR_GLAfSC_1320_Array cls_Get_LocalArticles_for_SearchConditions(,P_L3AR_GLAfSC_1320 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3AR_GLAfSC_1320_Array invocationResult = cls_Get_LocalArticles_for_SearchConditions.Invoke(connectionString,P_L3AR_GLAfSC_1320 Parameter,securityTicket);
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
var parameter = new CL3_Articles.Atomic.Retrieval.P_L3AR_GLAfSC_1320();
parameter.LanguageID = ...;
parameter.ProductNameStartWith = ...;
parameter.ActiveComponentStartWith = ...;
parameter.PZNOrName = ...;
parameter.DosageForm = ...;
parameter.Unit = ...;
parameter.ProducerName = ...;
parameter.ActiveComponent = ...;
parameter.IsAvailableForOrdering = ...;
parameter.IsDefaultStock = ...;

*/
