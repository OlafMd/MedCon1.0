/* 
 * Generated on 6.3.2015 12:49:01
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

namespace CL5_Zugseil_Catalogs.Atomic.Retrieval
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
		protected static FR_L5CA_GACPfR_1621_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5CA_GACPfR_1621 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5CA_GACPfR_1621_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_Zugseil_Catalogs.Atomic.Retrieval.SQL.cls_Get_AllCatalogsProducts_for_RevisionID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"RevisionID", Parameter.RevisionID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PricelistReleaseID", Parameter.PricelistReleaseID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CurrencyID", Parameter.CurrencyID);



			List<L5CA_GACPfR_1621> results = new List<L5CA_GACPfR_1621>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_PRO_ProductID","Product_Name_DictID","Product_Description_DictID","Product_Number","ProductITL","ProductAdditionalInfoXML","Producer_DisplayName","CMN_BPT_BusinessParticipantID","TaxRate","PackageContent_DisplayLabel","ISOCode","PriceAmount" });
				while(reader.Read())
				{
					L5CA_GACPfR_1621 resultItem = new L5CA_GACPfR_1621();
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
					//4:Parameter ProductITL of type String
					resultItem.ProductITL = reader.GetString(4);
					//5:Parameter ProductAdditionalInfoXML of type String
					resultItem.ProductAdditionalInfoXML = reader.GetString(5);
					//6:Parameter Producer_DisplayName of type String
					resultItem.Producer_DisplayName = reader.GetString(6);
					//7:Parameter CMN_BPT_BusinessParticipantID of type Guid
					resultItem.CMN_BPT_BusinessParticipantID = reader.GetGuid(7);
					//8:Parameter TaxRate of type String
					resultItem.TaxRate = reader.GetString(8);
					//9:Parameter PackageContent_DisplayLabel of type String
					resultItem.PackageContent_DisplayLabel = reader.GetString(9);
					//10:Parameter ISOCode of type String
					resultItem.ISOCode = reader.GetString(10);
					//11:Parameter PriceAmount of type Decimal
					resultItem.PriceAmount = reader.GetDecimal(11);

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
		public static FR_L5CA_GACPfR_1621_Array Invoke(string ConnectionString,P_L5CA_GACPfR_1621 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5CA_GACPfR_1621_Array Invoke(DbConnection Connection,P_L5CA_GACPfR_1621 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5CA_GACPfR_1621_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5CA_GACPfR_1621 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5CA_GACPfR_1621_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5CA_GACPfR_1621 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5CA_GACPfR_1621_Array functionReturn = new FR_L5CA_GACPfR_1621_Array();
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
	public class FR_L5CA_GACPfR_1621_Array : FR_Base
	{
		public L5CA_GACPfR_1621[] Result	{ get; set; } 
		public FR_L5CA_GACPfR_1621_Array() : base() {}

		public FR_L5CA_GACPfR_1621_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5CA_GACPfR_1621 for attribute P_L5CA_GACPfR_1621
		[DataContract]
		public class P_L5CA_GACPfR_1621 
		{
			//Standard type parameters
			[DataMember]
			public Guid RevisionID { get; set; } 
			[DataMember]
			public Guid PricelistReleaseID { get; set; } 
			[DataMember]
			public Guid CurrencyID { get; set; } 

		}
		#endregion
		#region SClass L5CA_GACPfR_1621 for attribute L5CA_GACPfR_1621
		[DataContract]
		public class L5CA_GACPfR_1621 
		{
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
			public String ProductITL { get; set; } 
			[DataMember]
			public String ProductAdditionalInfoXML { get; set; } 
			[DataMember]
			public String Producer_DisplayName { get; set; } 
			[DataMember]
			public Guid CMN_BPT_BusinessParticipantID { get; set; } 
			[DataMember]
			public String TaxRate { get; set; } 
			[DataMember]
			public String PackageContent_DisplayLabel { get; set; } 
			[DataMember]
			public String ISOCode { get; set; } 
			[DataMember]
			public Decimal PriceAmount { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5CA_GACPfR_1621_Array cls_Get_AllCatalogsProducts_for_RevisionID(,P_L5CA_GACPfR_1621 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5CA_GACPfR_1621_Array invocationResult = cls_Get_AllCatalogsProducts_for_RevisionID.Invoke(connectionString,P_L5CA_GACPfR_1621 Parameter,securityTicket);
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
var parameter = new CL5_Zugseil_Catalogs.Atomic.Retrieval.P_L5CA_GACPfR_1621();
parameter.RevisionID = ...;
parameter.PricelistReleaseID = ...;
parameter.CurrencyID = ...;

*/
