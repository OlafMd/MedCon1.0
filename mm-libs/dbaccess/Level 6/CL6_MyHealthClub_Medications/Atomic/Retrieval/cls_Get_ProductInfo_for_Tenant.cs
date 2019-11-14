/* 
 * Generated on 10/14/2014 11:03:46 AM
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

namespace CL6_MyHealthClub_Medications.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ProductInfo_for_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ProductInfo_for_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6_MgPIfT_1631_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L6_MgPIfT_1631 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L6_MgPIfT_1631_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL6_MyHealthClub_Medications.Atomic.Retrieval.SQL.cls_Get_ProductInfo_for_Tenant.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"Tenant", Parameter.Tenant);



			List<L6_MgPIfT_1631> results = new List<L6_MgPIfT_1631>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "HEC_ProductID","Ext_PRO_Product_RefID","Recepie","ProductDosageForm_RefID","IsProduct_OverTheCounter","IsProduct_PrescriptionRequired","IsProduct_HospitalPackage","IsProduct_AddictiveDrug","ProductDistributionStatus","ISOCode","PackageContent_Amount","IsDeleted","DisplayName","Creation_Timestamp","Tenant_RefID","Product_Name_DictID","DosageForm_Name_DictID","Modification_TimestampProducts","Modification_TimestampHecProducts","Modification_TimestampBpart","Modification_TimestampPackageInfo","Modification_TimestampUnits","Modification_TimestampDosageForms" });
				while(reader.Read())
				{
					L6_MgPIfT_1631 resultItem = new L6_MgPIfT_1631();
					//0:Parameter HEC_ProductID of type Guid
					resultItem.HEC_ProductID = reader.GetGuid(0);
					//1:Parameter Ext_PRO_Product_RefID of type Guid
					resultItem.Ext_PRO_Product_RefID = reader.GetGuid(1);
					//2:Parameter Recepie of type String
					resultItem.Recepie = reader.GetString(2);
					//3:Parameter ProductDosageForm_RefID of type Guid
					resultItem.ProductDosageForm_RefID = reader.GetGuid(3);
					//4:Parameter IsProduct_OverTheCounter of type bool
					resultItem.IsProduct_OverTheCounter = reader.GetBoolean(4);
					//5:Parameter IsProduct_PrescriptionRequired of type bool
					resultItem.IsProduct_PrescriptionRequired = reader.GetBoolean(5);
					//6:Parameter IsProduct_HospitalPackage of type bool
					resultItem.IsProduct_HospitalPackage = reader.GetBoolean(6);
					//7:Parameter IsProduct_AddictiveDrug of type bool
					resultItem.IsProduct_AddictiveDrug = reader.GetBoolean(7);
					//8:Parameter ProductDistributionStatus of type int
					resultItem.ProductDistributionStatus = reader.GetInteger(8);
					//9:Parameter ISOCode of type String
					resultItem.ISOCode = reader.GetString(9);
					//10:Parameter PackageContent_Amount of type double
					resultItem.PackageContent_Amount = reader.GetDouble(10);
					//11:Parameter IsDeleted of type bool
					resultItem.IsDeleted = reader.GetBoolean(11);
					//12:Parameter DisplayName of type String
					resultItem.DisplayName = reader.GetString(12);
					//13:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(13);
					//14:Parameter Tenant_RefID of type Guid
					resultItem.Tenant_RefID = reader.GetGuid(14);
					//15:Parameter Product_Name of type Dict
					resultItem.Product_Name = reader.GetDictionary(15);
					resultItem.Product_Name.SourceTable = "cmn_pro_products";
					loader.Append(resultItem.Product_Name);
					//16:Parameter DosageForm_Name of type Dict
					resultItem.DosageForm_Name = reader.GetDictionary(16);
					resultItem.DosageForm_Name.SourceTable = "hec_product_dosageforms";
					loader.Append(resultItem.DosageForm_Name);
					//17:Parameter Modification_TimestampProducts of type DateTime
					resultItem.Modification_TimestampProducts = reader.GetDate(17);
					//18:Parameter Modification_TimestampHecProducts of type DateTime
					resultItem.Modification_TimestampHecProducts = reader.GetDate(18);
					//19:Parameter Modification_TimestampBpart of type DateTime
					resultItem.Modification_TimestampBpart = reader.GetDate(19);
					//20:Parameter Modification_TimestampPackageInfo of type DateTime
					resultItem.Modification_TimestampPackageInfo = reader.GetDate(20);
					//21:Parameter Modification_TimestampUnits of type DateTime
					resultItem.Modification_TimestampUnits = reader.GetDate(21);
					//22:Parameter Modification_TimestampDosageForms of type DateTime
					resultItem.Modification_TimestampDosageForms = reader.GetDate(22);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_ProductInfo_for_Tenant",ex);
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
		public static FR_L6_MgPIfT_1631_Array Invoke(string ConnectionString,P_L6_MgPIfT_1631 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6_MgPIfT_1631_Array Invoke(DbConnection Connection,P_L6_MgPIfT_1631 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6_MgPIfT_1631_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L6_MgPIfT_1631 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6_MgPIfT_1631_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6_MgPIfT_1631 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6_MgPIfT_1631_Array functionReturn = new FR_L6_MgPIfT_1631_Array();
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

				throw new Exception("Exception occured in method cls_Get_ProductInfo_for_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6_MgPIfT_1631_Array : FR_Base
	{
		public L6_MgPIfT_1631[] Result	{ get; set; } 
		public FR_L6_MgPIfT_1631_Array() : base() {}

		public FR_L6_MgPIfT_1631_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6_MgPIfT_1631 for attribute P_L6_MgPIfT_1631
		[DataContract]
		public class P_L6_MgPIfT_1631 
		{
			//Standard type parameters
			[DataMember]
			public Guid Tenant { get; set; } 

		}
		#endregion
		#region SClass L6_MgPIfT_1631 for attribute L6_MgPIfT_1631
		[DataContract]
		public class L6_MgPIfT_1631 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_ProductID { get; set; } 
			[DataMember]
			public Guid Ext_PRO_Product_RefID { get; set; } 
			[DataMember]
			public String Recepie { get; set; } 
			[DataMember]
			public Guid ProductDosageForm_RefID { get; set; } 
			[DataMember]
			public bool IsProduct_OverTheCounter { get; set; } 
			[DataMember]
			public bool IsProduct_PrescriptionRequired { get; set; } 
			[DataMember]
			public bool IsProduct_HospitalPackage { get; set; } 
			[DataMember]
			public bool IsProduct_AddictiveDrug { get; set; } 
			[DataMember]
			public int ProductDistributionStatus { get; set; } 
			[DataMember]
			public String ISOCode { get; set; } 
			[DataMember]
			public double PackageContent_Amount { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 
			[DataMember]
			public String DisplayName { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public Guid Tenant_RefID { get; set; } 
			[DataMember]
			public Dict Product_Name { get; set; } 
			[DataMember]
			public Dict DosageForm_Name { get; set; } 
			[DataMember]
			public DateTime Modification_TimestampProducts { get; set; } 
			[DataMember]
			public DateTime Modification_TimestampHecProducts { get; set; } 
			[DataMember]
			public DateTime Modification_TimestampBpart { get; set; } 
			[DataMember]
			public DateTime Modification_TimestampPackageInfo { get; set; } 
			[DataMember]
			public DateTime Modification_TimestampUnits { get; set; } 
			[DataMember]
			public DateTime Modification_TimestampDosageForms { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6_MgPIfT_1631_Array cls_Get_ProductInfo_for_Tenant(,P_L6_MgPIfT_1631 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6_MgPIfT_1631_Array invocationResult = cls_Get_ProductInfo_for_Tenant.Invoke(connectionString,P_L6_MgPIfT_1631 Parameter,securityTicket);
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
var parameter = new CL6_MyHealthClub_Medications.Atomic.Retrieval.P_L6_MgPIfT_1631();
parameter.Tenant = ...;

*/
