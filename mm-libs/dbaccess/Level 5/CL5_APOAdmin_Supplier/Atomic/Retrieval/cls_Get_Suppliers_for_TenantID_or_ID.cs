/* 
 * Generated on 7/26/2014 1:36:20 PM
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

namespace CL5_APOAdmin_Supplier.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Suppliers_for_TenantID_or_ID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Suppliers_for_TenantID_or_ID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5AAS_GSfToI_1340_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5AAS_GSfToI_1340 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5AAS_GSfToI_1340_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOAdmin_Supplier.Atomic.Retrieval.SQL.cls_Get_Suppliers_for_TenantID_or_ID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CMN_BPT_SupplierID", Parameter.CMN_BPT_SupplierID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"GlobalMatching_CashDiscount", Parameter.GlobalMatching_CashDiscount);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"GlobalMatching_MainDiscount", Parameter.GlobalMatching_MainDiscount);



			List<L5AAS_GSfToI_1340_raw> results = new List<L5AAS_GSfToI_1340_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_BPT_SupplierID","CMN_BPT_BusinessParticipantID","IsDeleted","DisplayName","DefaultLanguage_RefID","DefaultCurrency_RefID","CMN_COM_CompanyInfoID","CompanyInfo_EstablishmentNumber","AnnualRevenueAmountValue_RefID","VATIdentificationNumber","CompanyName_Line1","Country_639_1_ISOCode","CMN_BPT_Supplier_TypeID","SupplierType","ExternalSupplierProvidedIdentifier","DiscountType","DiscountValue_in_percent" });
				while(reader.Read())
				{
					L5AAS_GSfToI_1340_raw resultItem = new L5AAS_GSfToI_1340_raw();
					//0:Parameter CMN_BPT_SupplierID of type Guid
					resultItem.CMN_BPT_SupplierID = reader.GetGuid(0);
					//1:Parameter CMN_BPT_BusinessParticipantID of type Guid
					resultItem.CMN_BPT_BusinessParticipantID = reader.GetGuid(1);
					//2:Parameter IsDeleted of type bool
					resultItem.IsDeleted = reader.GetBoolean(2);
					//3:Parameter DisplayName of type String
					resultItem.DisplayName = reader.GetString(3);
					//4:Parameter DefaultLanguage_RefID of type Guid
					resultItem.DefaultLanguage_RefID = reader.GetGuid(4);
					//5:Parameter DefaultCurrency_RefID of type Guid
					resultItem.DefaultCurrency_RefID = reader.GetGuid(5);
					//6:Parameter CMN_COM_CompanyInfoID of type Guid
					resultItem.CMN_COM_CompanyInfoID = reader.GetGuid(6);
					//7:Parameter CompanyInfo_EstablishmentNumber of type String
					resultItem.CompanyInfo_EstablishmentNumber = reader.GetString(7);
					//8:Parameter AnnualRevenueAmountValue_RefID of type Guid
					resultItem.AnnualRevenueAmountValue_RefID = reader.GetGuid(8);
					//9:Parameter VATIdentificationNumber of type String
					resultItem.VATIdentificationNumber = reader.GetString(9);
					//10:Parameter CompanyName_Line1 of type String
					resultItem.CompanyName_Line1 = reader.GetString(10);
					//11:Parameter Country_639_1_ISOCode of type String
					resultItem.Country_639_1_ISOCode = reader.GetString(11);
					//12:Parameter CMN_BPT_Supplier_TypeID of type Guid
					resultItem.CMN_BPT_Supplier_TypeID = reader.GetGuid(12);
					//13:Parameter SupplierType of type String
					resultItem.SupplierType = reader.GetString(13);
					//14:Parameter ExternalSupplierProvidedIdentifier of type String
					resultItem.ExternalSupplierProvidedIdentifier = reader.GetString(14);
					//15:Parameter DiscountType of type string
					resultItem.DiscountType = reader.GetString(15);
					//16:Parameter DiscountValue_in_percent of type double
					resultItem.DiscountValue_in_percent = reader.GetDouble(16);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Suppliers_for_TenantID_or_ID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5AAS_GSfToI_1340_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5AAS_GSfToI_1340_Array Invoke(string ConnectionString,P_L5AAS_GSfToI_1340 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5AAS_GSfToI_1340_Array Invoke(DbConnection Connection,P_L5AAS_GSfToI_1340 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5AAS_GSfToI_1340_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AAS_GSfToI_1340 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5AAS_GSfToI_1340_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AAS_GSfToI_1340 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5AAS_GSfToI_1340_Array functionReturn = new FR_L5AAS_GSfToI_1340_Array();
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

				throw new Exception("Exception occured in method cls_Get_Suppliers_for_TenantID_or_ID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5AAS_GSfToI_1340_raw 
	{
		public Guid CMN_BPT_SupplierID; 
		public Guid CMN_BPT_BusinessParticipantID; 
		public bool IsDeleted; 
		public String DisplayName; 
		public Guid DefaultLanguage_RefID; 
		public Guid DefaultCurrency_RefID; 
		public Guid CMN_COM_CompanyInfoID; 
		public String CompanyInfo_EstablishmentNumber; 
		public Guid AnnualRevenueAmountValue_RefID; 
		public String VATIdentificationNumber; 
		public String CompanyName_Line1; 
		public String Country_639_1_ISOCode; 
		public Guid CMN_BPT_Supplier_TypeID; 
		public String SupplierType; 
		public String ExternalSupplierProvidedIdentifier; 
		public string DiscountType; 
		public double DiscountValue_in_percent; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5AAS_GSfToI_1340[] Convert(List<L5AAS_GSfToI_1340_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5AAS_GSfToI_1340 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.CMN_BPT_SupplierID)).ToArray()
	group el_L5AAS_GSfToI_1340 by new 
	{ 
		el_L5AAS_GSfToI_1340.CMN_BPT_SupplierID,

	}
	into gfunct_L5AAS_GSfToI_1340
	select new L5AAS_GSfToI_1340
	{     
		CMN_BPT_SupplierID = gfunct_L5AAS_GSfToI_1340.Key.CMN_BPT_SupplierID ,
		CMN_BPT_BusinessParticipantID = gfunct_L5AAS_GSfToI_1340.FirstOrDefault().CMN_BPT_BusinessParticipantID ,
		IsDeleted = gfunct_L5AAS_GSfToI_1340.FirstOrDefault().IsDeleted ,
		DisplayName = gfunct_L5AAS_GSfToI_1340.FirstOrDefault().DisplayName ,
		DefaultLanguage_RefID = gfunct_L5AAS_GSfToI_1340.FirstOrDefault().DefaultLanguage_RefID ,
		DefaultCurrency_RefID = gfunct_L5AAS_GSfToI_1340.FirstOrDefault().DefaultCurrency_RefID ,
		CMN_COM_CompanyInfoID = gfunct_L5AAS_GSfToI_1340.FirstOrDefault().CMN_COM_CompanyInfoID ,
		CompanyInfo_EstablishmentNumber = gfunct_L5AAS_GSfToI_1340.FirstOrDefault().CompanyInfo_EstablishmentNumber ,
		AnnualRevenueAmountValue_RefID = gfunct_L5AAS_GSfToI_1340.FirstOrDefault().AnnualRevenueAmountValue_RefID ,
		VATIdentificationNumber = gfunct_L5AAS_GSfToI_1340.FirstOrDefault().VATIdentificationNumber ,
		CompanyName_Line1 = gfunct_L5AAS_GSfToI_1340.FirstOrDefault().CompanyName_Line1 ,
		Country_639_1_ISOCode = gfunct_L5AAS_GSfToI_1340.FirstOrDefault().Country_639_1_ISOCode ,
		CMN_BPT_Supplier_TypeID = gfunct_L5AAS_GSfToI_1340.FirstOrDefault().CMN_BPT_Supplier_TypeID ,
		SupplierType = gfunct_L5AAS_GSfToI_1340.FirstOrDefault().SupplierType ,
		ExternalSupplierProvidedIdentifier = gfunct_L5AAS_GSfToI_1340.FirstOrDefault().ExternalSupplierProvidedIdentifier ,

		DiscountValues = 
		(
			from el_DiscountValues in gfunct_L5AAS_GSfToI_1340.Where(element => !EqualsDefaultValue(element.DiscountType)).ToArray()
			group el_DiscountValues by new 
			{ 
				el_DiscountValues.DiscountType,

			}
			into gfunct_DiscountValues
			select new L5AAS_GSfToI_1340a
			{     
				DiscountType = gfunct_DiscountValues.Key.DiscountType ,
				DiscountValue_in_percent = gfunct_DiscountValues.FirstOrDefault().DiscountValue_in_percent ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5AAS_GSfToI_1340_Array : FR_Base
	{
		public L5AAS_GSfToI_1340[] Result	{ get; set; } 
		public FR_L5AAS_GSfToI_1340_Array() : base() {}

		public FR_L5AAS_GSfToI_1340_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5AAS_GSfToI_1340 for attribute P_L5AAS_GSfToI_1340
		[DataContract]
		public class P_L5AAS_GSfToI_1340 
		{
			//Standard type parameters
			[DataMember]
			public Guid? CMN_BPT_SupplierID { get; set; } 
			[DataMember]
			public String GlobalMatching_CashDiscount { get; set; } 
			[DataMember]
			public String GlobalMatching_MainDiscount { get; set; } 

		}
		#endregion
		#region SClass L5AAS_GSfToI_1340 for attribute L5AAS_GSfToI_1340
		[DataContract]
		public class L5AAS_GSfToI_1340 
		{
			[DataMember]
			public L5AAS_GSfToI_1340a[] DiscountValues { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid CMN_BPT_SupplierID { get; set; } 
			[DataMember]
			public Guid CMN_BPT_BusinessParticipantID { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 
			[DataMember]
			public String DisplayName { get; set; } 
			[DataMember]
			public Guid DefaultLanguage_RefID { get; set; } 
			[DataMember]
			public Guid DefaultCurrency_RefID { get; set; } 
			[DataMember]
			public Guid CMN_COM_CompanyInfoID { get; set; } 
			[DataMember]
			public String CompanyInfo_EstablishmentNumber { get; set; } 
			[DataMember]
			public Guid AnnualRevenueAmountValue_RefID { get; set; } 
			[DataMember]
			public String VATIdentificationNumber { get; set; } 
			[DataMember]
			public String CompanyName_Line1 { get; set; } 
			[DataMember]
			public String Country_639_1_ISOCode { get; set; } 
			[DataMember]
			public Guid CMN_BPT_Supplier_TypeID { get; set; } 
			[DataMember]
			public String SupplierType { get; set; } 
			[DataMember]
			public String ExternalSupplierProvidedIdentifier { get; set; } 

		}
		#endregion
		#region SClass L5AAS_GSfToI_1340a for attribute DiscountValues
		[DataContract]
		public class L5AAS_GSfToI_1340a 
		{
			//Standard type parameters
			[DataMember]
			public string DiscountType { get; set; } 
			[DataMember]
			public double DiscountValue_in_percent { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5AAS_GSfToI_1340_Array cls_Get_Suppliers_for_TenantID_or_ID(,P_L5AAS_GSfToI_1340 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5AAS_GSfToI_1340_Array invocationResult = cls_Get_Suppliers_for_TenantID_or_ID.Invoke(connectionString,P_L5AAS_GSfToI_1340 Parameter,securityTicket);
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
var parameter = new CL5_APOAdmin_Supplier.Atomic.Retrieval.P_L5AAS_GSfToI_1340();
parameter.CMN_BPT_SupplierID = ...;
parameter.GlobalMatching_CashDiscount = ...;
parameter.GlobalMatching_MainDiscount = ...;

*/
