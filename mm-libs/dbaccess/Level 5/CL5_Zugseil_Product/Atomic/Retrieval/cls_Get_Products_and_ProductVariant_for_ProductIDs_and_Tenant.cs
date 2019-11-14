/* 
 * Generated on 11/26/2014 16:23:06
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

namespace CL5_Zugseil_Product.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Products_and_ProductVariant_for_ProductIDs_and_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Products_and_ProductVariant_for_ProductIDs_and_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5PR_GPaPVfPaT_1602_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5PR_GPaPVfPaT_1602 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5PR_GPaPVfPaT_1602_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_Zugseil_Product.Atomic.Retrieval.SQL.cls_Get_Products_and_ProductVariant_for_ProductIDs_and_Tenant.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@ProductIDs"," IN $$ProductIDs$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$ProductIDs$",Parameter.ProductIDs);


			List<L5PR_GPaPVfPaT_1602_raw> results = new List<L5PR_GPaPVfPaT_1602_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_PRO_ProductID","Product_Name_DictID","Product_Description_DictID","Product_Number","Product_DocumentationStructure_RefID","CMN_PRO_Product_VariantID","IsStandardProductVariant","ProductVariantITL","IsImportedFromExternalCatalog","IsProductAvailableForOrdering","IsObsolete","VariantName_DictID" });
				while(reader.Read())
				{
					L5PR_GPaPVfPaT_1602_raw resultItem = new L5PR_GPaPVfPaT_1602_raw();
					//0:Parameter CMN_PRO_ProductID of type Guid
					resultItem.CMN_PRO_ProductID = reader.GetGuid(0);
					//1:Parameter Product_Name of type Dict
					resultItem.Product_Name = reader.GetDictionary(1);
					resultItem.Product_Name.SourceTable = "cmn_pro_products";
					loader.Append(resultItem.Product_Name);
					//2:Parameter Product_Description of type Dict
					resultItem.Product_Description = reader.GetDictionary(2);
					resultItem.Product_Description.SourceTable = "cmn_pro_products";
					loader.Append(resultItem.Product_Description);
					//3:Parameter Product_Number of type String
					resultItem.Product_Number = reader.GetString(3);
					//4:Parameter Product_DocumentationStructure_RefID of type Guid
					resultItem.Product_DocumentationStructure_RefID = reader.GetGuid(4);
					//5:Parameter CMN_PRO_Product_VariantID of type Guid
					resultItem.CMN_PRO_Product_VariantID = reader.GetGuid(5);
					//6:Parameter IsStandardProductVariant of type bool
					resultItem.IsStandardProductVariant = reader.GetBoolean(6);
					//7:Parameter ProductVariantITL of type String
					resultItem.ProductVariantITL = reader.GetString(7);
					//8:Parameter IsImportedFromExternalCatalog of type bool
					resultItem.IsImportedFromExternalCatalog = reader.GetBoolean(8);
					//9:Parameter IsProductAvailableForOrdering of type bool
					resultItem.IsProductAvailableForOrdering = reader.GetBoolean(9);
					//10:Parameter IsObsolete of type bool
					resultItem.IsObsolete = reader.GetBoolean(10);
					//11:Parameter VariantName of type Dict
					resultItem.VariantName = reader.GetDictionary(11);
					resultItem.VariantName.SourceTable = "cmn_pro_product_variants";
					loader.Append(resultItem.VariantName);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Products_and_ProductVariant_for_ProductIDs_and_Tenant",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5PR_GPaPVfPaT_1602_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5PR_GPaPVfPaT_1602_Array Invoke(string ConnectionString,P_L5PR_GPaPVfPaT_1602 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5PR_GPaPVfPaT_1602_Array Invoke(DbConnection Connection,P_L5PR_GPaPVfPaT_1602 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5PR_GPaPVfPaT_1602_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5PR_GPaPVfPaT_1602 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5PR_GPaPVfPaT_1602_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5PR_GPaPVfPaT_1602 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5PR_GPaPVfPaT_1602_Array functionReturn = new FR_L5PR_GPaPVfPaT_1602_Array();
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

				throw new Exception("Exception occured in method cls_Get_Products_and_ProductVariant_for_ProductIDs_and_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5PR_GPaPVfPaT_1602_raw 
	{
		public Guid CMN_PRO_ProductID; 
		public Dict Product_Name; 
		public Dict Product_Description; 
		public String Product_Number; 
		public Guid Product_DocumentationStructure_RefID; 
		public Guid CMN_PRO_Product_VariantID; 
		public bool IsStandardProductVariant; 
		public String ProductVariantITL; 
		public bool IsImportedFromExternalCatalog; 
		public bool IsProductAvailableForOrdering; 
		public bool IsObsolete; 
		public Dict VariantName; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5PR_GPaPVfPaT_1602[] Convert(List<L5PR_GPaPVfPaT_1602_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5PR_GPaPVfPaT_1602 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.CMN_PRO_ProductID)).ToArray()
	group el_L5PR_GPaPVfPaT_1602 by new 
	{ 
		el_L5PR_GPaPVfPaT_1602.CMN_PRO_ProductID,

	}
	into gfunct_L5PR_GPaPVfPaT_1602
	select new L5PR_GPaPVfPaT_1602
	{     
		CMN_PRO_ProductID = gfunct_L5PR_GPaPVfPaT_1602.Key.CMN_PRO_ProductID ,
		Product_Name = gfunct_L5PR_GPaPVfPaT_1602.FirstOrDefault().Product_Name ,
		Product_Description = gfunct_L5PR_GPaPVfPaT_1602.FirstOrDefault().Product_Description ,
		Product_Number = gfunct_L5PR_GPaPVfPaT_1602.FirstOrDefault().Product_Number ,
		Product_DocumentationStructure_RefID = gfunct_L5PR_GPaPVfPaT_1602.FirstOrDefault().Product_DocumentationStructure_RefID ,

		Variants = 
		(
			from el_Variants in gfunct_L5PR_GPaPVfPaT_1602.ToArray()
			select new L5PR_GPaPVfPaT_1602a
			{     
				CMN_PRO_Product_VariantID = el_Variants.CMN_PRO_Product_VariantID,
				IsStandardProductVariant = el_Variants.IsStandardProductVariant,
				ProductVariantITL = el_Variants.ProductVariantITL,
				IsImportedFromExternalCatalog = el_Variants.IsImportedFromExternalCatalog,
				IsProductAvailableForOrdering = el_Variants.IsProductAvailableForOrdering,
				IsObsolete = el_Variants.IsObsolete,
				VariantName = el_Variants.VariantName,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5PR_GPaPVfPaT_1602_Array : FR_Base
	{
		public L5PR_GPaPVfPaT_1602[] Result	{ get; set; } 
		public FR_L5PR_GPaPVfPaT_1602_Array() : base() {}

		public FR_L5PR_GPaPVfPaT_1602_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5PR_GPaPVfPaT_1602 for attribute P_L5PR_GPaPVfPaT_1602
		[DataContract]
		public class P_L5PR_GPaPVfPaT_1602 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] ProductIDs { get; set; } 

		}
		#endregion
		#region SClass L5PR_GPaPVfPaT_1602 for attribute L5PR_GPaPVfPaT_1602
		[DataContract]
		public class L5PR_GPaPVfPaT_1602 
		{
			[DataMember]
			public L5PR_GPaPVfPaT_1602a[] Variants { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_ProductID { get; set; } 
			[DataMember]
			public Dict Product_Name { get; set; } 
			[DataMember]
			public Dict Product_Description { get; set; } 
			[DataMember]
			public String Product_Number { get; set; } 
			[DataMember]
			public Guid Product_DocumentationStructure_RefID { get; set; } 

		}
		#endregion
		#region SClass L5PR_GPaPVfPaT_1602a for attribute Variants
		[DataContract]
		public class L5PR_GPaPVfPaT_1602a 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_Product_VariantID { get; set; } 
			[DataMember]
			public bool IsStandardProductVariant { get; set; } 
			[DataMember]
			public String ProductVariantITL { get; set; } 
			[DataMember]
			public bool IsImportedFromExternalCatalog { get; set; } 
			[DataMember]
			public bool IsProductAvailableForOrdering { get; set; } 
			[DataMember]
			public bool IsObsolete { get; set; } 
			[DataMember]
			public Dict VariantName { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5PR_GPaPVfPaT_1602_Array cls_Get_Products_and_ProductVariant_for_ProductIDs_and_Tenant(,P_L5PR_GPaPVfPaT_1602 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5PR_GPaPVfPaT_1602_Array invocationResult = cls_Get_Products_and_ProductVariant_for_ProductIDs_and_Tenant.Invoke(connectionString,P_L5PR_GPaPVfPaT_1602 Parameter,securityTicket);
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
var parameter = new CL5_Zugseil_Product.Atomic.Retrieval.P_L5PR_GPaPVfPaT_1602();
parameter.ProductIDs = ...;

*/
