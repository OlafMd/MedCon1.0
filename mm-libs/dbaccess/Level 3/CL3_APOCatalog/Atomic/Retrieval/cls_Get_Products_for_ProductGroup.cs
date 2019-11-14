/* 
 * Generated on 6/2/2014 3:43:20 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 * Required Assemblies:
 * System.Runtime.Serialization
 * CSV2Core
 * CSV2Core_MySQL
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;
using System.Runtime.Serialization;

namespace CL3_APOCatalog.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Products_for_ProductGroup.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Products_for_ProductGroup
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3CA_GPfPG_0958_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3CA_GPfPG_0958 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3CA_GPfPG_0958_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_APOCatalog.Atomic.Retrieval.SQL.cls_Get_Products_for_ProductGroup.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ProductGroupID", Parameter.ProductGroupID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CatalogRevisionID", Parameter.CatalogRevisionID);



			List<L3CA_GPfPG_0958> results = new List<L3CA_GPfPG_0958>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_PRO_Catalog_ProductGroup_RefID","IsDeleted","Tenant_RefID","IsDeleted1","CMN_PRO_Catalog_ProductID","CMN_PRO_Product_RefID","Product_Name_DictID","PackageContent_Amount","PackageContent_DisplayLabel","Product_Number","Label_DictID","Abbreviation_DictID","ISOCode","DosageForm_Name_DictID","DosageForm_Description_DictID","GlobalPropertyMatchingID" });
				while(reader.Read())
				{
					L3CA_GPfPG_0958 resultItem = new L3CA_GPfPG_0958();
					//0:Parameter CMN_PRO_Catalog_ProductGroup_RefID of type Guid
					resultItem.CMN_PRO_Catalog_ProductGroup_RefID = reader.GetGuid(0);
					//1:Parameter IsDeleted of type bool
					resultItem.IsDeleted = reader.GetBoolean(1);
					//2:Parameter Tenant_RefID of type Guid
					resultItem.Tenant_RefID = reader.GetGuid(2);
					//3:Parameter IsDeleted1 of type bool
					resultItem.IsDeleted1 = reader.GetBoolean(3);
					//4:Parameter CMN_PRO_Catalog_ProductID of type Guid
					resultItem.CMN_PRO_Catalog_ProductID = reader.GetGuid(4);
					//5:Parameter CMN_PRO_Product_RefID of type Guid
					resultItem.CMN_PRO_Product_RefID = reader.GetGuid(5);
					//6:Parameter Product_Name of type Dict
					resultItem.Product_Name = reader.GetDictionary(6);
					resultItem.Product_Name.SourceTable = "cmn_pro_products";
					loader.Append(resultItem.Product_Name);
					//7:Parameter PackageContent_Amount of type Decimal
					resultItem.PackageContent_Amount = reader.GetDecimal(7);
					//8:Parameter PackageContent_DisplayLabel of type String
					resultItem.PackageContent_DisplayLabel = reader.GetString(8);
					//9:Parameter Product_Number of type String
					resultItem.Product_Number = reader.GetString(9);
					//10:Parameter Label_DictID of type Dict
					resultItem.Label_DictID = reader.GetDictionary(10);
					resultItem.Label_DictID.SourceTable = "cmn_units";
					loader.Append(resultItem.Label_DictID);
					//11:Parameter Abbreviation_DictID of type Dict
					resultItem.Abbreviation_DictID = reader.GetDictionary(11);
					resultItem.Abbreviation_DictID.SourceTable = "cmn_units";
					loader.Append(resultItem.Abbreviation_DictID);
					//12:Parameter ISOCode of type String
					resultItem.ISOCode = reader.GetString(12);
					//13:Parameter DosageForm_Name_DictID of type Dict
					resultItem.DosageForm_Name_DictID = reader.GetDictionary(13);
					resultItem.DosageForm_Name_DictID.SourceTable = "hec_product_dosageforms";
					loader.Append(resultItem.DosageForm_Name_DictID);
					//14:Parameter DosageForm_Description_DictID of type Dict
					resultItem.DosageForm_Description_DictID = reader.GetDictionary(14);
					resultItem.DosageForm_Description_DictID.SourceTable = "hec_product_dosageforms";
					loader.Append(resultItem.DosageForm_Description_DictID);
					//15:Parameter GlobalPropertyMatchingID of type String
					resultItem.GlobalPropertyMatchingID = reader.GetString(15);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Products_for_ProductGroup",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = results.ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3CA_GPfPG_0958_Array Invoke(string ConnectionString,P_L3CA_GPfPG_0958 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3CA_GPfPG_0958_Array Invoke(DbConnection Connection,P_L3CA_GPfPG_0958 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3CA_GPfPG_0958_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3CA_GPfPG_0958 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3CA_GPfPG_0958_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3CA_GPfPG_0958 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3CA_GPfPG_0958_Array functionReturn = new FR_L3CA_GPfPG_0958_Array();
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

				throw new Exception("Exception occured in method cls_Get_Products_for_ProductGroup",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3CA_GPfPG_0958_Array : FR_Base
	{
		public L3CA_GPfPG_0958[] Result	{ get; set; } 
		public FR_L3CA_GPfPG_0958_Array() : base() {}

		public FR_L3CA_GPfPG_0958_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3CA_GPfPG_0958 for attribute P_L3CA_GPfPG_0958
		[DataContract]
		public class P_L3CA_GPfPG_0958 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProductGroupID { get; set; } 
			[DataMember]
			public Guid CatalogRevisionID { get; set; } 

		}
		#endregion
		#region SClass L3CA_GPfPG_0958 for attribute L3CA_GPfPG_0958
		[DataContract]
		public class L3CA_GPfPG_0958 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_Catalog_ProductGroup_RefID { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 
			[DataMember]
			public Guid Tenant_RefID { get; set; } 
			[DataMember]
			public bool IsDeleted1 { get; set; } 
			[DataMember]
			public Guid CMN_PRO_Catalog_ProductID { get; set; } 
			[DataMember]
			public Guid CMN_PRO_Product_RefID { get; set; } 
			[DataMember]
			public Dict Product_Name { get; set; } 
			[DataMember]
			public Decimal PackageContent_Amount { get; set; } 
			[DataMember]
			public String PackageContent_DisplayLabel { get; set; } 
			[DataMember]
			public String Product_Number { get; set; } 
			[DataMember]
			public Dict Label_DictID { get; set; } 
			[DataMember]
			public Dict Abbreviation_DictID { get; set; } 
			[DataMember]
			public String ISOCode { get; set; } 
			[DataMember]
			public Dict DosageForm_Name_DictID { get; set; } 
			[DataMember]
			public Dict DosageForm_Description_DictID { get; set; } 
			[DataMember]
			public String GlobalPropertyMatchingID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3CA_GPfPG_0958_Array cls_Get_Products_for_ProductGroup(,P_L3CA_GPfPG_0958 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3CA_GPfPG_0958_Array invocationResult = cls_Get_Products_for_ProductGroup.Invoke(connectionString,P_L3CA_GPfPG_0958 Parameter,securityTicket);
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
var parameter = new CL3_APOCatalog.Atomic.Retrieval.P_L3CA_GPfPG_0958();
parameter.ProductGroupID = ...;
parameter.CatalogRevisionID = ...;

*/
