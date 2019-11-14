/* 
 * Generated on 2/2/2015 04:10:06
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
    /// var result = cls_Get_Products_for_AssortmentProductID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Products_for_AssortmentProductID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5PR_GPfAP_0155_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5PR_GPfAP_0155 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5PR_GPfAP_0155_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_Zugseil_Product.Atomic.Retrieval.SQL.cls_Get_Products_for_AssortmentProductID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"AssortmentProductID", Parameter.AssortmentProductID);



			List<L5PR_GPfAP_0155_raw> results = new List<L5PR_GPfAP_0155_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_PRO_Product_RefID","CMN_PRO_ASS_AssortmentProduct_VendorProductID","Product_Name_DictID","Product_Description_DictID","Product_Number","IsDeleted","CMN_PRO_Product_VariantID","VariantName_DictID" });
				while(reader.Read())
				{
					L5PR_GPfAP_0155_raw resultItem = new L5PR_GPfAP_0155_raw();
					//0:Parameter CMN_PRO_Product_RefID of type Guid
					resultItem.CMN_PRO_Product_RefID = reader.GetGuid(0);
					//1:Parameter CMN_PRO_ASS_AssortmentProduct_VendorProductID of type Guid
					resultItem.CMN_PRO_ASS_AssortmentProduct_VendorProductID = reader.GetGuid(1);
					//2:Parameter Product_Name of type Dict
					resultItem.Product_Name = reader.GetDictionary(2);
					resultItem.Product_Name.SourceTable = "cmn_pro_products";
					loader.Append(resultItem.Product_Name);
					//3:Parameter Product_Description of type Dict
					resultItem.Product_Description = reader.GetDictionary(3);
					resultItem.Product_Description.SourceTable = "cmn_pro_products";
					loader.Append(resultItem.Product_Description);
					//4:Parameter Product_Number of type String
					resultItem.Product_Number = reader.GetString(4);
					//5:Parameter IsDeleted of type bool
					resultItem.IsDeleted = reader.GetBoolean(5);
					//6:Parameter CMN_PRO_Product_VariantID of type Guid
					resultItem.CMN_PRO_Product_VariantID = reader.GetGuid(6);
					//7:Parameter VariantName_DictID of type Dict
					resultItem.VariantName_DictID = reader.GetDictionary(7);
					resultItem.VariantName_DictID.SourceTable = "cmn_pro_product_Variants";
					loader.Append(resultItem.VariantName_DictID);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Products_for_AssortmentProductID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5PR_GPfAP_0155_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5PR_GPfAP_0155_Array Invoke(string ConnectionString,P_L5PR_GPfAP_0155 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5PR_GPfAP_0155_Array Invoke(DbConnection Connection,P_L5PR_GPfAP_0155 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5PR_GPfAP_0155_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5PR_GPfAP_0155 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5PR_GPfAP_0155_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5PR_GPfAP_0155 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5PR_GPfAP_0155_Array functionReturn = new FR_L5PR_GPfAP_0155_Array();
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

				throw new Exception("Exception occured in method cls_Get_Products_for_AssortmentProductID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5PR_GPfAP_0155_raw 
	{
		public Guid CMN_PRO_Product_RefID; 
		public Guid CMN_PRO_ASS_AssortmentProduct_VendorProductID; 
		public Dict Product_Name; 
		public Dict Product_Description; 
		public String Product_Number; 
		public bool IsDeleted; 
		public Guid CMN_PRO_Product_VariantID; 
		public Dict VariantName_DictID; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5PR_GPfAP_0155[] Convert(List<L5PR_GPfAP_0155_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5PR_GPfAP_0155 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.CMN_PRO_Product_RefID)).ToArray()
	group el_L5PR_GPfAP_0155 by new 
	{ 
		el_L5PR_GPfAP_0155.CMN_PRO_Product_RefID,

	}
	into gfunct_L5PR_GPfAP_0155
	select new L5PR_GPfAP_0155
	{     
		CMN_PRO_Product_RefID = gfunct_L5PR_GPfAP_0155.Key.CMN_PRO_Product_RefID ,
		CMN_PRO_ASS_AssortmentProduct_VendorProductID = gfunct_L5PR_GPfAP_0155.FirstOrDefault().CMN_PRO_ASS_AssortmentProduct_VendorProductID ,
		Product_Name = gfunct_L5PR_GPfAP_0155.FirstOrDefault().Product_Name ,
		Product_Description = gfunct_L5PR_GPfAP_0155.FirstOrDefault().Product_Description ,
		Product_Number = gfunct_L5PR_GPfAP_0155.FirstOrDefault().Product_Number ,
		IsDeleted = gfunct_L5PR_GPfAP_0155.FirstOrDefault().IsDeleted ,

		Variants = 
		(
			from el_Variants in gfunct_L5PR_GPfAP_0155.Where(element => !EqualsDefaultValue(element.CMN_PRO_Product_VariantID)).ToArray()
			group el_Variants by new 
			{ 
				el_Variants.CMN_PRO_Product_VariantID,

			}
			into gfunct_Variants
			select new L5PR_GPfAP_0155a
			{     
				CMN_PRO_Product_VariantID = gfunct_Variants.Key.CMN_PRO_Product_VariantID ,
				VariantName_DictID = gfunct_Variants.FirstOrDefault().VariantName_DictID ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5PR_GPfAP_0155_Array : FR_Base
	{
		public L5PR_GPfAP_0155[] Result	{ get; set; } 
		public FR_L5PR_GPfAP_0155_Array() : base() {}

		public FR_L5PR_GPfAP_0155_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5PR_GPfAP_0155 for attribute P_L5PR_GPfAP_0155
		[DataContract]
		public class P_L5PR_GPfAP_0155 
		{
			//Standard type parameters
			[DataMember]
			public Guid AssortmentProductID { get; set; } 

		}
		#endregion
		#region SClass L5PR_GPfAP_0155 for attribute L5PR_GPfAP_0155
		[DataContract]
		public class L5PR_GPfAP_0155 
		{
			[DataMember]
			public L5PR_GPfAP_0155a[] Variants { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_Product_RefID { get; set; } 
			[DataMember]
			public Guid CMN_PRO_ASS_AssortmentProduct_VendorProductID { get; set; } 
			[DataMember]
			public Dict Product_Name { get; set; } 
			[DataMember]
			public Dict Product_Description { get; set; } 
			[DataMember]
			public String Product_Number { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 

		}
		#endregion
		#region SClass L5PR_GPfAP_0155a for attribute Variants
		[DataContract]
		public class L5PR_GPfAP_0155a 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_Product_VariantID { get; set; } 
			[DataMember]
			public Dict VariantName_DictID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5PR_GPfAP_0155_Array cls_Get_Products_for_AssortmentProductID(,P_L5PR_GPfAP_0155 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5PR_GPfAP_0155_Array invocationResult = cls_Get_Products_for_AssortmentProductID.Invoke(connectionString,P_L5PR_GPfAP_0155 Parameter,securityTicket);
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
var parameter = new CL5_Zugseil_Product.Atomic.Retrieval.P_L5PR_GPfAP_0155();
parameter.AssortmentProductID = ...;

*/
