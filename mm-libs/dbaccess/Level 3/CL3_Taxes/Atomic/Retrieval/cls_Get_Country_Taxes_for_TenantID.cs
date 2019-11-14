/* 
 * Generated on 4/12/2013 02:37:49
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

namespace CL3_Taxes.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Country_Taxes_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Country_Taxes_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3TX_GTfT_1038_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3TX_GTfT_1038_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_Taxes.Atomic.Retrieval.SQL.cls_Get_Country_Taxes_for_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L3TX_GTfT_1038_raw> results = new List<L3TX_GTfT_1038_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_CountryID","Country_Name_DictID","ACC_TAX_TaxeID","EconomicRegion_RefID","TaxName_DictID","TaxRate","IsDeleted","Tenant_RefID","EconomicRegion_Name_DictID","EconomicRegion_Description_DictID","IsEconomicRegionCountry" });
				while(reader.Read())
				{
					L3TX_GTfT_1038_raw resultItem = new L3TX_GTfT_1038_raw();
					//0:Parameter CMN_CountryID of type Guid
					resultItem.CMN_CountryID = reader.GetGuid(0);
					//1:Parameter Country_Name of type Dict
					resultItem.Country_Name = reader.GetDictionary(1);
					resultItem.Country_Name.SourceTable = "cmn_countries";
					loader.Append(resultItem.Country_Name);
					//2:Parameter ACC_TAX_TaxeID of type Guid
					resultItem.ACC_TAX_TaxeID = reader.GetGuid(2);
					//3:Parameter EconomicRegion_RefID of type Guid
					resultItem.EconomicRegion_RefID = reader.GetGuid(3);
					//4:Parameter TaxName of type Dict
					resultItem.TaxName = reader.GetDictionary(4);
					resultItem.TaxName.SourceTable = "acc_tax_taxes";
					loader.Append(resultItem.TaxName);
					//5:Parameter TaxRate of type double
					resultItem.TaxRate = reader.GetDouble(5);
					//6:Parameter IsDeleted of type bool
					resultItem.IsDeleted = reader.GetBoolean(6);
					//7:Parameter Tenant_RefID of type Guid
					resultItem.Tenant_RefID = reader.GetGuid(7);
					//8:Parameter EconomicRegion_Name of type Dict
					resultItem.EconomicRegion_Name = reader.GetDictionary(8);
					resultItem.EconomicRegion_Name.SourceTable = "cmn_economicregion";
					loader.Append(resultItem.EconomicRegion_Name);
					//9:Parameter EconomicRegion_Description of type Dict
					resultItem.EconomicRegion_Description = reader.GetDictionary(9);
					resultItem.EconomicRegion_Description.SourceTable = "cmn_economicregion";
					loader.Append(resultItem.EconomicRegion_Description);
					//10:Parameter IsEconomicRegionCountry of type bool
					resultItem.IsEconomicRegionCountry = reader.GetBoolean(10);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Country_Taxes_for_TenantID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L3TX_GTfT_1038_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3TX_GTfT_1038_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3TX_GTfT_1038_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3TX_GTfT_1038_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3TX_GTfT_1038_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3TX_GTfT_1038_Array functionReturn = new FR_L3TX_GTfT_1038_Array();
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

				throw new Exception("Exception occured in method cls_Get_Country_Taxes_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L3TX_GTfT_1038_raw 
	{
		public Guid CMN_CountryID; 
		public Dict Country_Name; 
		public Guid ACC_TAX_TaxeID; 
		public Guid EconomicRegion_RefID; 
		public Dict TaxName; 
		public double TaxRate; 
		public bool IsDeleted; 
		public Guid Tenant_RefID; 
		public Dict EconomicRegion_Name; 
		public Dict EconomicRegion_Description; 
		public bool IsEconomicRegionCountry; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L3TX_GTfT_1038[] Convert(List<L3TX_GTfT_1038_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L3TX_GTfT_1038 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.CMN_CountryID)).ToArray()
	group el_L3TX_GTfT_1038 by new 
	{ 
		el_L3TX_GTfT_1038.CMN_CountryID,

	}
	into gfunct_L3TX_GTfT_1038
	select new L3TX_GTfT_1038
	{     
		CMN_CountryID = gfunct_L3TX_GTfT_1038.Key.CMN_CountryID ,
		Country_Name = gfunct_L3TX_GTfT_1038.FirstOrDefault().Country_Name ,

		Tax = 
		(
			from el_Tax in gfunct_L3TX_GTfT_1038.Where(element => !EqualsDefaultValue(element.ACC_TAX_TaxeID)).ToArray()
			group el_Tax by new 
			{ 
				el_Tax.ACC_TAX_TaxeID,

			}
			into gfunct_Tax
			select new L3TX_GTfT_1038_Tax
			{     
				ACC_TAX_TaxeID = gfunct_Tax.Key.ACC_TAX_TaxeID ,
				EconomicRegion_RefID = gfunct_Tax.FirstOrDefault().EconomicRegion_RefID ,
				TaxName = gfunct_Tax.FirstOrDefault().TaxName ,
				TaxRate = gfunct_Tax.FirstOrDefault().TaxRate ,
				IsDeleted = gfunct_Tax.FirstOrDefault().IsDeleted ,
				Tenant_RefID = gfunct_Tax.FirstOrDefault().Tenant_RefID ,
				EconomicRegion_Name = gfunct_Tax.FirstOrDefault().EconomicRegion_Name ,
				EconomicRegion_Description = gfunct_Tax.FirstOrDefault().EconomicRegion_Description ,
				IsEconomicRegionCountry = gfunct_Tax.FirstOrDefault().IsEconomicRegionCountry ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L3TX_GTfT_1038_Array : FR_Base
	{
		public L3TX_GTfT_1038[] Result	{ get; set; } 
		public FR_L3TX_GTfT_1038_Array() : base() {}

		public FR_L3TX_GTfT_1038_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L3TX_GTfT_1038 for attribute L3TX_GTfT_1038
		[DataContract]
		public class L3TX_GTfT_1038 
		{
			[DataMember]
			public L3TX_GTfT_1038_Tax[] Tax { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid CMN_CountryID { get; set; } 
			[DataMember]
			public Dict Country_Name { get; set; } 

		}
		#endregion
		#region SClass L3TX_GTfT_1038_Tax for attribute Tax
		[DataContract]
		public class L3TX_GTfT_1038_Tax 
		{
			//Standard type parameters
			[DataMember]
			public Guid ACC_TAX_TaxeID { get; set; } 
			[DataMember]
			public Guid EconomicRegion_RefID { get; set; } 
			[DataMember]
			public Dict TaxName { get; set; } 
			[DataMember]
			public double TaxRate { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 
			[DataMember]
			public Guid Tenant_RefID { get; set; } 
			[DataMember]
			public Dict EconomicRegion_Name { get; set; } 
			[DataMember]
			public Dict EconomicRegion_Description { get; set; } 
			[DataMember]
			public bool IsEconomicRegionCountry { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3TX_GTfT_1038_Array cls_Get_Country_Taxes_for_TenantID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3TX_GTfT_1038_Array invocationResult = cls_Get_Country_Taxes_for_TenantID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

