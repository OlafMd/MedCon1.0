/* 
 * Generated on 10/27/2014 1:13:03 PM
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

namespace CL3_Variant.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_All_Variants_for_Product.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_All_Variants_for_Product
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3VA_GAVfP_1300_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3VA_GAVfP_1300 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3VA_GAVfP_1300_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_Variant.Atomic.Retrieval.SQL.cls_Get_All_Variants_for_Product.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ProductID", Parameter.ProductID);



			List<L3VA_GAVfP_1300_raw> results = new List<L3VA_GAVfP_1300_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_PRO_Product_VariantID","ProductVariantITL","VariantName_DictID","IsStandardProductVariant","IsImportedFromExternalCatalog","IsProductAvailableForOrdering","IsObsolete","CMN_PRO_Dimension_ValueID","DimensionValue_Text_DictID","DimensionValue_OrderSequence","CMN_PRO_DimensionID","Abbreviation","DimensionName_DictID","Dimension_OrderSequence","IsDimensionTemplate" });
				while(reader.Read())
				{
					L3VA_GAVfP_1300_raw resultItem = new L3VA_GAVfP_1300_raw();
					//0:Parameter CMN_PRO_Product_VariantID of type Guid
					resultItem.CMN_PRO_Product_VariantID = reader.GetGuid(0);
					//1:Parameter ProductVariantITL of type string
					resultItem.ProductVariantITL = reader.GetString(1);
					//2:Parameter VariantName of type Dict
					resultItem.VariantName = reader.GetDictionary(2);
					resultItem.VariantName.SourceTable = "cmn_pro_product_variants";
					loader.Append(resultItem.VariantName);
					//3:Parameter IsStandardProductVariant of type bool
					resultItem.IsStandardProductVariant = reader.GetBoolean(3);
					//4:Parameter IsImportedFromExternalCatalog of type bool
					resultItem.IsImportedFromExternalCatalog = reader.GetBoolean(4);
					//5:Parameter IsProductAvailableForOrdering of type bool
					resultItem.IsProductAvailableForOrdering = reader.GetBoolean(5);
					//6:Parameter IsObsolete of type bool
					resultItem.IsObsolete = reader.GetBoolean(6);
					//7:Parameter CMN_PRO_Dimension_ValueID of type Guid
					resultItem.CMN_PRO_Dimension_ValueID = reader.GetGuid(7);
					//8:Parameter DimensionValue_Text of type Dict
					resultItem.DimensionValue_Text = reader.GetDictionary(8);
					resultItem.DimensionValue_Text.SourceTable = "cmn_pro_dimension_values";
					loader.Append(resultItem.DimensionValue_Text);
					//9:Parameter DimensionValue_OrderSequence of type int
					resultItem.DimensionValue_OrderSequence = reader.GetInteger(9);
					//10:Parameter CMN_PRO_DimensionID of type Guid
					resultItem.CMN_PRO_DimensionID = reader.GetGuid(10);
					//11:Parameter Abbreviation of type string
					resultItem.Abbreviation = reader.GetString(11);
					//12:Parameter DimensionName of type Dict
					resultItem.DimensionName = reader.GetDictionary(12);
					resultItem.DimensionName.SourceTable = "cmn_pro_dimensions";
					loader.Append(resultItem.DimensionName);
					//13:Parameter Dimension_OrderSequence of type int
					resultItem.Dimension_OrderSequence = reader.GetInteger(13);
					//14:Parameter IsDimensionTemplate of type bool
					resultItem.IsDimensionTemplate = reader.GetBoolean(14);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_All_Variants_for_Product",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L3VA_GAVfP_1300_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3VA_GAVfP_1300_Array Invoke(string ConnectionString,P_L3VA_GAVfP_1300 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3VA_GAVfP_1300_Array Invoke(DbConnection Connection,P_L3VA_GAVfP_1300 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3VA_GAVfP_1300_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3VA_GAVfP_1300 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3VA_GAVfP_1300_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3VA_GAVfP_1300 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3VA_GAVfP_1300_Array functionReturn = new FR_L3VA_GAVfP_1300_Array();
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

				throw new Exception("Exception occured in method cls_Get_All_Variants_for_Product",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L3VA_GAVfP_1300_raw 
	{
		public Guid CMN_PRO_Product_VariantID; 
		public string ProductVariantITL; 
		public Dict VariantName; 
		public bool IsStandardProductVariant; 
		public bool IsImportedFromExternalCatalog; 
		public bool IsProductAvailableForOrdering; 
		public bool IsObsolete; 
		public Guid CMN_PRO_Dimension_ValueID; 
		public Dict DimensionValue_Text; 
		public int DimensionValue_OrderSequence; 
		public Guid CMN_PRO_DimensionID; 
		public string Abbreviation; 
		public Dict DimensionName; 
		public int Dimension_OrderSequence; 
		public bool IsDimensionTemplate; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L3VA_GAVfP_1300[] Convert(List<L3VA_GAVfP_1300_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L3VA_GAVfP_1300 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.CMN_PRO_Product_VariantID)).ToArray()
	group el_L3VA_GAVfP_1300 by new 
	{ 
		el_L3VA_GAVfP_1300.CMN_PRO_Product_VariantID,

	}
	into gfunct_L3VA_GAVfP_1300
	select new L3VA_GAVfP_1300
	{     
		CMN_PRO_Product_VariantID = gfunct_L3VA_GAVfP_1300.Key.CMN_PRO_Product_VariantID ,
		ProductVariantITL = gfunct_L3VA_GAVfP_1300.FirstOrDefault().ProductVariantITL ,
		VariantName = gfunct_L3VA_GAVfP_1300.FirstOrDefault().VariantName ,
		IsStandardProductVariant = gfunct_L3VA_GAVfP_1300.FirstOrDefault().IsStandardProductVariant ,
		IsImportedFromExternalCatalog = gfunct_L3VA_GAVfP_1300.FirstOrDefault().IsImportedFromExternalCatalog ,
		IsProductAvailableForOrdering = gfunct_L3VA_GAVfP_1300.FirstOrDefault().IsProductAvailableForOrdering ,
		IsObsolete = gfunct_L3VA_GAVfP_1300.FirstOrDefault().IsObsolete ,

		DimensionValues = 
		(
			from el_DimensionValues in gfunct_L3VA_GAVfP_1300.Where(element => !EqualsDefaultValue(element.CMN_PRO_Dimension_ValueID)).ToArray()
			group el_DimensionValues by new 
			{ 
				el_DimensionValues.CMN_PRO_Dimension_ValueID,

			}
			into gfunct_DimensionValues
			select new L3VA_GAVfP_1300a
			{     
				CMN_PRO_Dimension_ValueID = gfunct_DimensionValues.Key.CMN_PRO_Dimension_ValueID ,
				DimensionValue_Text = gfunct_DimensionValues.FirstOrDefault().DimensionValue_Text ,
				DimensionValue_OrderSequence = gfunct_DimensionValues.FirstOrDefault().DimensionValue_OrderSequence ,
				CMN_PRO_DimensionID = gfunct_DimensionValues.FirstOrDefault().CMN_PRO_DimensionID ,
				Abbreviation = gfunct_DimensionValues.FirstOrDefault().Abbreviation ,
				DimensionName = gfunct_DimensionValues.FirstOrDefault().DimensionName ,
				Dimension_OrderSequence = gfunct_DimensionValues.FirstOrDefault().Dimension_OrderSequence ,
				IsDimensionTemplate = gfunct_DimensionValues.FirstOrDefault().IsDimensionTemplate ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L3VA_GAVfP_1300_Array : FR_Base
	{
		public L3VA_GAVfP_1300[] Result	{ get; set; } 
		public FR_L3VA_GAVfP_1300_Array() : base() {}

		public FR_L3VA_GAVfP_1300_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3VA_GAVfP_1300 for attribute P_L3VA_GAVfP_1300
		[DataContract]
		public class P_L3VA_GAVfP_1300 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProductID { get; set; } 

		}
		#endregion
		#region SClass L3VA_GAVfP_1300 for attribute L3VA_GAVfP_1300
		[DataContract]
		public class L3VA_GAVfP_1300 
		{
			[DataMember]
			public L3VA_GAVfP_1300a[] DimensionValues { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_Product_VariantID { get; set; } 
			[DataMember]
			public string ProductVariantITL { get; set; } 
			[DataMember]
			public Dict VariantName { get; set; } 
			[DataMember]
			public bool IsStandardProductVariant { get; set; } 
			[DataMember]
			public bool IsImportedFromExternalCatalog { get; set; } 
			[DataMember]
			public bool IsProductAvailableForOrdering { get; set; } 
			[DataMember]
			public bool IsObsolete { get; set; } 

		}
		#endregion
		#region SClass L3VA_GAVfP_1300a for attribute DimensionValues
		[DataContract]
		public class L3VA_GAVfP_1300a 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_Dimension_ValueID { get; set; } 
			[DataMember]
			public Dict DimensionValue_Text { get; set; } 
			[DataMember]
			public int DimensionValue_OrderSequence { get; set; } 
			[DataMember]
			public Guid CMN_PRO_DimensionID { get; set; } 
			[DataMember]
			public string Abbreviation { get; set; } 
			[DataMember]
			public Dict DimensionName { get; set; } 
			[DataMember]
			public int Dimension_OrderSequence { get; set; } 
			[DataMember]
			public bool IsDimensionTemplate { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3VA_GAVfP_1300_Array cls_Get_All_Variants_for_Product(,P_L3VA_GAVfP_1300 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3VA_GAVfP_1300_Array invocationResult = cls_Get_All_Variants_for_Product.Invoke(connectionString,P_L3VA_GAVfP_1300 Parameter,securityTicket);
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
var parameter = new CL3_Variant.Atomic.Retrieval.P_L3VA_GAVfP_1300();
parameter.ProductID = ...;

*/
