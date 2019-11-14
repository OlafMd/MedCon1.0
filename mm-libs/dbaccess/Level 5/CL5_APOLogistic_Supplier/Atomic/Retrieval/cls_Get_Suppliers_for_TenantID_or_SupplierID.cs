/* 
 * Generated on 3/6/2014 5:43:57 PM
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

namespace CL5_APOLogistic_Supplier.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Suppliers_for_TenantID_or_SupplierID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Suppliers_for_TenantID_or_SupplierID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5ALSU_GSfToS_1546_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5ALSU_GSfToS_1546 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5ALSU_GSfToS_1546_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOLogistic_Supplier.Atomic.Retrieval.SQL.cls_Get_Suppliers_for_TenantID_or_SupplierID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CMN_BPT_SupplierID", Parameter.CMN_BPT_SupplierID);



			List<L5ALSU_GSfToS_1546> results = new List<L5ALSU_GSfToS_1546>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_BPT_SupplierID","CMN_BPT_BusinessParticipantID","DisplayName","DefaultLanguage_RefID","DefaultCurrency_RefID","CMN_COM_CompanyInfoID","CompanyInfo_EstablishmentNumber","AnnualRevenueAmountValue_RefID","VATIdentificationNumber","CompanyName_Line1","Country_639_1_ISOCode","CMN_BPT_Supplier_TypeID","GlobalPropertyMatchingID","SupplierType_Name_DictID" });
				while(reader.Read())
				{
					L5ALSU_GSfToS_1546 resultItem = new L5ALSU_GSfToS_1546();
					//0:Parameter CMN_BPT_SupplierID of type Guid
					resultItem.CMN_BPT_SupplierID = reader.GetGuid(0);
					//1:Parameter CMN_BPT_BusinessParticipantID of type Guid
					resultItem.CMN_BPT_BusinessParticipantID = reader.GetGuid(1);
					//2:Parameter DisplayName of type String
					resultItem.DisplayName = reader.GetString(2);
					//3:Parameter DefaultLanguage_RefID of type Guid
					resultItem.DefaultLanguage_RefID = reader.GetGuid(3);
					//4:Parameter DefaultCurrency_RefID of type Guid
					resultItem.DefaultCurrency_RefID = reader.GetGuid(4);
					//5:Parameter CMN_COM_CompanyInfoID of type Guid
					resultItem.CMN_COM_CompanyInfoID = reader.GetGuid(5);
					//6:Parameter CompanyInfo_EstablishmentNumber of type String
					resultItem.CompanyInfo_EstablishmentNumber = reader.GetString(6);
					//7:Parameter AnnualRevenueAmountValue_RefID of type Guid
					resultItem.AnnualRevenueAmountValue_RefID = reader.GetGuid(7);
					//8:Parameter VATIdentificationNumber of type String
					resultItem.VATIdentificationNumber = reader.GetString(8);
					//9:Parameter CompanyName_Line1 of type String
					resultItem.CompanyName_Line1 = reader.GetString(9);
					//10:Parameter Country_639_1_ISOCode of type String
					resultItem.Country_639_1_ISOCode = reader.GetString(10);
					//11:Parameter CMN_BPT_Supplier_TypeID of type Guid
					resultItem.CMN_BPT_Supplier_TypeID = reader.GetGuid(11);
					//12:Parameter GlobalPropertyMatchingID of type String
					resultItem.GlobalPropertyMatchingID = reader.GetString(12);
					//13:Parameter SupplierType_Name of type Dict
					resultItem.SupplierType_Name = reader.GetDictionary(13);
					resultItem.SupplierType_Name.SourceTable = "cmn_bpt_supplier_types";
					loader.Append(resultItem.SupplierType_Name);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Suppliers_for_TenantID_or_SupplierID",ex);
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
		public static FR_L5ALSU_GSfToS_1546_Array Invoke(string ConnectionString,P_L5ALSU_GSfToS_1546 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5ALSU_GSfToS_1546_Array Invoke(DbConnection Connection,P_L5ALSU_GSfToS_1546 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5ALSU_GSfToS_1546_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5ALSU_GSfToS_1546 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5ALSU_GSfToS_1546_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5ALSU_GSfToS_1546 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5ALSU_GSfToS_1546_Array functionReturn = new FR_L5ALSU_GSfToS_1546_Array();
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

				throw new Exception("Exception occured in method cls_Get_Suppliers_for_TenantID_or_SupplierID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5ALSU_GSfToS_1546_Array : FR_Base
	{
		public L5ALSU_GSfToS_1546[] Result	{ get; set; } 
		public FR_L5ALSU_GSfToS_1546_Array() : base() {}

		public FR_L5ALSU_GSfToS_1546_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5ALSU_GSfToS_1546 for attribute P_L5ALSU_GSfToS_1546
		[DataContract]
		public class P_L5ALSU_GSfToS_1546 
		{
			//Standard type parameters
			[DataMember]
			public Guid? CMN_BPT_SupplierID { get; set; } 

		}
		#endregion
		#region SClass L5ALSU_GSfToS_1546 for attribute L5ALSU_GSfToS_1546
		[DataContract]
		public class L5ALSU_GSfToS_1546 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_BPT_SupplierID { get; set; } 
			[DataMember]
			public Guid CMN_BPT_BusinessParticipantID { get; set; } 
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
			public String GlobalPropertyMatchingID { get; set; } 
			[DataMember]
			public Dict SupplierType_Name { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5ALSU_GSfToS_1546_Array cls_Get_Suppliers_for_TenantID_or_SupplierID(,P_L5ALSU_GSfToS_1546 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5ALSU_GSfToS_1546_Array invocationResult = cls_Get_Suppliers_for_TenantID_or_SupplierID.Invoke(connectionString,P_L5ALSU_GSfToS_1546 Parameter,securityTicket);
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
var parameter = new CL5_APOLogistic_Supplier.Atomic.Retrieval.P_L5ALSU_GSfToS_1546();
parameter.CMN_BPT_SupplierID = ...;

*/
