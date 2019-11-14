/* 
 * Generated on 6/2/2014 3:44:42 PM
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
    /// var result = cls_Get_Root_Products_for_Catalog_Revision.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Root_Products_for_Catalog_Revision
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3CA_GRPfCR_1525_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3CA_GRPfCR_1525 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3CA_GRPfCR_1525_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_APOCatalog.Atomic.Retrieval.SQL.cls_Get_Root_Products_for_Catalog_Revision.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CatalogRevisionID", Parameter.CatalogRevisionID);



			List<L3CA_GRPfCR_1525> results = new List<L3CA_GRPfCR_1525>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_PRO_Catalog_Revision_RefID","CMN_PRO_Catalog_ProductID","PackageContent_Amount","PackageContent_DisplayLabel","Product_Name_DictID","Product_Description_DictID","CMN_PRO_ProductID","Product_Number","Label_DictID","Abbreviation_DictID","ISOCode","DosageForm_Name_DictID","DosageForm_Description_DictID","GlobalPropertyMatchingID" });
				while(reader.Read())
				{
					L3CA_GRPfCR_1525 resultItem = new L3CA_GRPfCR_1525();
					//0:Parameter CMN_PRO_Catalog_Revision_RefID of type Guid
					resultItem.CMN_PRO_Catalog_Revision_RefID = reader.GetGuid(0);
					//1:Parameter CMN_PRO_Catalog_ProductID of type Guid
					resultItem.CMN_PRO_Catalog_ProductID = reader.GetGuid(1);
					//2:Parameter PackageContent_Amount of type Double
					resultItem.PackageContent_Amount = reader.GetDouble(2);
					//3:Parameter PackageContent_DisplayLabel of type String
					resultItem.PackageContent_DisplayLabel = reader.GetString(3);
					//4:Parameter Product_Name of type Dict
					resultItem.Product_Name = reader.GetDictionary(4);
					resultItem.Product_Name.SourceTable = "cmn_pro_products";
					loader.Append(resultItem.Product_Name);
					//5:Parameter Product_Description of type Dict
					resultItem.Product_Description = reader.GetDictionary(5);
					resultItem.Product_Description.SourceTable = "cmn_pro_products";
					loader.Append(resultItem.Product_Description);
					//6:Parameter CMN_PRO_ProductID of type Guid
					resultItem.CMN_PRO_ProductID = reader.GetGuid(6);
					//7:Parameter Product_Number of type String
					resultItem.Product_Number = reader.GetString(7);
					//8:Parameter Label_DictID of type Dict
					resultItem.Label_DictID = reader.GetDictionary(8);
					resultItem.Label_DictID.SourceTable = "cmn_units";
					loader.Append(resultItem.Label_DictID);
					//9:Parameter Abbreviation_DictID of type Dict
					resultItem.Abbreviation_DictID = reader.GetDictionary(9);
					resultItem.Abbreviation_DictID.SourceTable = "cmn_units";
					loader.Append(resultItem.Abbreviation_DictID);
					//10:Parameter ISOCode of type String
					resultItem.ISOCode = reader.GetString(10);
					//11:Parameter DosageForm_Name_DictID of type Dict
					resultItem.DosageForm_Name_DictID = reader.GetDictionary(11);
					resultItem.DosageForm_Name_DictID.SourceTable = "hec_product_dosageforms";
					loader.Append(resultItem.DosageForm_Name_DictID);
					//12:Parameter DosageForm_Description_DictID of type Dict
					resultItem.DosageForm_Description_DictID = reader.GetDictionary(12);
					resultItem.DosageForm_Description_DictID.SourceTable = "hec_product_dosageforms";
					loader.Append(resultItem.DosageForm_Description_DictID);
					//13:Parameter GlobalPropertyMatchingID of type String
					resultItem.GlobalPropertyMatchingID = reader.GetString(13);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Root_Products_for_Catalog_Revision",ex);
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
		public static FR_L3CA_GRPfCR_1525_Array Invoke(string ConnectionString,P_L3CA_GRPfCR_1525 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3CA_GRPfCR_1525_Array Invoke(DbConnection Connection,P_L3CA_GRPfCR_1525 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3CA_GRPfCR_1525_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3CA_GRPfCR_1525 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3CA_GRPfCR_1525_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3CA_GRPfCR_1525 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3CA_GRPfCR_1525_Array functionReturn = new FR_L3CA_GRPfCR_1525_Array();
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

				throw new Exception("Exception occured in method cls_Get_Root_Products_for_Catalog_Revision",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3CA_GRPfCR_1525_Array : FR_Base
	{
		public L3CA_GRPfCR_1525[] Result	{ get; set; } 
		public FR_L3CA_GRPfCR_1525_Array() : base() {}

		public FR_L3CA_GRPfCR_1525_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3CA_GRPfCR_1525 for attribute P_L3CA_GRPfCR_1525
		[DataContract]
		public class P_L3CA_GRPfCR_1525 
		{
			//Standard type parameters
			[DataMember]
			public Guid CatalogRevisionID { get; set; } 

		}
		#endregion
		#region SClass L3CA_GRPfCR_1525 for attribute L3CA_GRPfCR_1525
		[DataContract]
		public class L3CA_GRPfCR_1525 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_Catalog_Revision_RefID { get; set; } 
			[DataMember]
			public Guid CMN_PRO_Catalog_ProductID { get; set; } 
			[DataMember]
			public Double PackageContent_Amount { get; set; } 
			[DataMember]
			public String PackageContent_DisplayLabel { get; set; } 
			[DataMember]
			public Dict Product_Name { get; set; } 
			[DataMember]
			public Dict Product_Description { get; set; } 
			[DataMember]
			public Guid CMN_PRO_ProductID { get; set; } 
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
FR_L3CA_GRPfCR_1525_Array cls_Get_Root_Products_for_Catalog_Revision(,P_L3CA_GRPfCR_1525 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3CA_GRPfCR_1525_Array invocationResult = cls_Get_Root_Products_for_Catalog_Revision.Invoke(connectionString,P_L3CA_GRPfCR_1525 Parameter,securityTicket);
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
var parameter = new CL3_APOCatalog.Atomic.Retrieval.P_L3CA_GRPfCR_1525();
parameter.CatalogRevisionID = ...;

*/
