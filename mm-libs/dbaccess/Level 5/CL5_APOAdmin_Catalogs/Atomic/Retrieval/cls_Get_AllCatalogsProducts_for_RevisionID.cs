/* 
 * Generated on 6/2/2014 12:24:11 PM
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

namespace CL5_APOAdmin_Catalogs.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_AllCatalogsProducts_for_RevisionID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_AllCatalogsProducts_for_RevisionID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5CA_GACPfR_1558_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5CA_GACPfR_1558 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5CA_GACPfR_1558_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOAdmin_Catalogs.Atomic.Retrieval.SQL.cls_Get_AllCatalogsProducts_for_RevisionID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"RevisionID", Parameter.RevisionID);



			List<L5CA_GACPfR_1558> results = new List<L5CA_GACPfR_1558>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_PRO_ProductID","HEC_ProductID","ProductITL","Product_Name_DictID","Product_Number","Product_Description_DictID","ISOCode","PackageContent_DisplayLabel","DosageForm","TaxRate","Producer_DisplayName","ProductDistributionStatus","IsStorage_CoolingRequired","DefaultExpirationPeriod_in_sec","DefaultStorageTemperature_max_in_kelvin","DefaultStorageTemperature_min_in_kelvin","IsProduct_AddictiveDrug","ProductAdditionalInfoXML" });
				while(reader.Read())
				{
					L5CA_GACPfR_1558 resultItem = new L5CA_GACPfR_1558();
					//0:Parameter CMN_PRO_ProductID of type Guid
					resultItem.CMN_PRO_ProductID = reader.GetGuid(0);
					//1:Parameter HEC_ProductID of type Guid
					resultItem.HEC_ProductID = reader.GetGuid(1);
					//2:Parameter ProductITL of type String
					resultItem.ProductITL = reader.GetString(2);
					//3:Parameter Product_Name of type Dict
					resultItem.Product_Name = reader.GetDictionary(3);
					resultItem.Product_Name.SourceTable = "cmn_pro_products";
					loader.Append(resultItem.Product_Name);
					//4:Parameter Product_Number of type String
					resultItem.Product_Number = reader.GetString(4);
					//5:Parameter Product_Description of type Dict
					resultItem.Product_Description = reader.GetDictionary(5);
					resultItem.Product_Description.SourceTable = "cmn_pro_products";
					loader.Append(resultItem.Product_Description);
					//6:Parameter ISOCode of type String
					resultItem.ISOCode = reader.GetString(6);
					//7:Parameter PackageContent_DisplayLabel of type String
					resultItem.PackageContent_DisplayLabel = reader.GetString(7);
					//8:Parameter DosageForm of type String
					resultItem.DosageForm = reader.GetString(8);
					//9:Parameter TaxRate of type Decimal
					resultItem.TaxRate = reader.GetDecimal(9);
					//10:Parameter Producer_DisplayName of type String
					resultItem.Producer_DisplayName = reader.GetString(10);
					//11:Parameter ProductDistributionStatus of type int
					resultItem.ProductDistributionStatus = reader.GetInteger(11);
					//12:Parameter IsStorage_CoolingRequired of type bool
					resultItem.IsStorage_CoolingRequired = reader.GetBoolean(12);
					//13:Parameter DefaultExpirationPeriod_in_sec of type long
					resultItem.DefaultExpirationPeriod_in_sec = reader.GetLong(13);
					//14:Parameter DefaultStorageTemperature_max_in_kelvin of type Double
					resultItem.DefaultStorageTemperature_max_in_kelvin = reader.GetDouble(14);
					//15:Parameter DefaultStorageTemperature_min_in_kelvin of type Double
					resultItem.DefaultStorageTemperature_min_in_kelvin = reader.GetDouble(15);
					//16:Parameter IsProduct_AddictiveDrug of type bool
					resultItem.IsProduct_AddictiveDrug = reader.GetBoolean(16);
					//17:Parameter ProductAdditionalInfoXML of type String
					resultItem.ProductAdditionalInfoXML = reader.GetString(17);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_AllCatalogsProducts_for_RevisionID",ex);
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
		public static FR_L5CA_GACPfR_1558_Array Invoke(string ConnectionString,P_L5CA_GACPfR_1558 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5CA_GACPfR_1558_Array Invoke(DbConnection Connection,P_L5CA_GACPfR_1558 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5CA_GACPfR_1558_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5CA_GACPfR_1558 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5CA_GACPfR_1558_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5CA_GACPfR_1558 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5CA_GACPfR_1558_Array functionReturn = new FR_L5CA_GACPfR_1558_Array();
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

				throw new Exception("Exception occured in method cls_Get_AllCatalogsProducts_for_RevisionID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5CA_GACPfR_1558_Array : FR_Base
	{
		public L5CA_GACPfR_1558[] Result	{ get; set; } 
		public FR_L5CA_GACPfR_1558_Array() : base() {}

		public FR_L5CA_GACPfR_1558_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5CA_GACPfR_1558 for attribute P_L5CA_GACPfR_1558
		[DataContract]
		public class P_L5CA_GACPfR_1558 
		{
			//Standard type parameters
			[DataMember]
			public Guid RevisionID { get; set; } 

		}
		#endregion
		#region SClass L5CA_GACPfR_1558 for attribute L5CA_GACPfR_1558
		[DataContract]
		public class L5CA_GACPfR_1558 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_ProductID { get; set; } 
			[DataMember]
			public Guid HEC_ProductID { get; set; } 
			[DataMember]
			public String ProductITL { get; set; } 
			[DataMember]
			public Dict Product_Name { get; set; } 
			[DataMember]
			public String Product_Number { get; set; } 
			[DataMember]
			public Dict Product_Description { get; set; } 
			[DataMember]
			public String ISOCode { get; set; } 
			[DataMember]
			public String PackageContent_DisplayLabel { get; set; } 
			[DataMember]
			public String DosageForm { get; set; } 
			[DataMember]
			public Decimal TaxRate { get; set; } 
			[DataMember]
			public String Producer_DisplayName { get; set; } 
			[DataMember]
			public int ProductDistributionStatus { get; set; } 
			[DataMember]
			public bool IsStorage_CoolingRequired { get; set; } 
			[DataMember]
			public long DefaultExpirationPeriod_in_sec { get; set; } 
			[DataMember]
			public Double DefaultStorageTemperature_max_in_kelvin { get; set; } 
			[DataMember]
			public Double DefaultStorageTemperature_min_in_kelvin { get; set; } 
			[DataMember]
			public bool IsProduct_AddictiveDrug { get; set; } 
			[DataMember]
			public String ProductAdditionalInfoXML { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5CA_GACPfR_1558_Array cls_Get_AllCatalogsProducts_for_RevisionID(,P_L5CA_GACPfR_1558 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5CA_GACPfR_1558_Array invocationResult = cls_Get_AllCatalogsProducts_for_RevisionID.Invoke(connectionString,P_L5CA_GACPfR_1558 Parameter,securityTicket);
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
var parameter = new CL5_APOAdmin_Catalogs.Atomic.Retrieval.P_L5CA_GACPfR_1558();
parameter.RevisionID = ...;

*/
