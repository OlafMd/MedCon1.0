/* 
 * Generated on 2/18/2015 2:16:10 PM
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

namespace CL3_Product.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Product_with_PictureID_for_ProductID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Product_with_PictureID_for_ProductID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3PR_GPwPfP_1620 Execute(DbConnection Connection,DbTransaction Transaction,P_L3PR_GPwPfP_1620 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3PR_GPwPfP_1620();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_Product.Atomic.Retrieval.SQL.cls_Get_Product_with_PictureID_for_ProductID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ProductID", Parameter.ProductID);



			List<L3PR_GPwPfP_1620> results = new List<L3PR_GPwPfP_1620>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_PRO_ProductID","Product_Name_DictID","Product_Description_DictID","Product_Number","IsCustomizable","Product_DocumentationStructure_RefID","Document_RefID","IsImportedFromExternalCatalog" });
				while(reader.Read())
				{
					L3PR_GPwPfP_1620 resultItem = new L3PR_GPwPfP_1620();
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
					//4:Parameter IsCustomizable of type bool
					resultItem.IsCustomizable = reader.GetBoolean(4);
					//5:Parameter Product_DocumentationStructure_RefID of type Guid
					resultItem.Product_DocumentationStructure_RefID = reader.GetGuid(5);
					//6:Parameter Document_RefID of type Guid
					resultItem.Document_RefID = reader.GetGuid(6);
					//7:Parameter IsImportedFromExternalCatalog of type Boolean
					resultItem.IsImportedFromExternalCatalog = reader.GetBoolean(7);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Product_with_PictureID_for_ProductID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = results.FirstOrDefault();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3PR_GPwPfP_1620 Invoke(string ConnectionString,P_L3PR_GPwPfP_1620 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3PR_GPwPfP_1620 Invoke(DbConnection Connection,P_L3PR_GPwPfP_1620 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3PR_GPwPfP_1620 Invoke(DbConnection Connection, DbTransaction Transaction,P_L3PR_GPwPfP_1620 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3PR_GPwPfP_1620 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3PR_GPwPfP_1620 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3PR_GPwPfP_1620 functionReturn = new FR_L3PR_GPwPfP_1620();
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

				throw new Exception("Exception occured in method cls_Get_Product_with_PictureID_for_ProductID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3PR_GPwPfP_1620 : FR_Base
	{
		public L3PR_GPwPfP_1620 Result	{ get; set; }

		public FR_L3PR_GPwPfP_1620() : base() {}

		public FR_L3PR_GPwPfP_1620(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3PR_GPwPfP_1620 for attribute P_L3PR_GPwPfP_1620
		[DataContract]
		public class P_L3PR_GPwPfP_1620 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProductID { get; set; } 

		}
		#endregion
		#region SClass L3PR_GPwPfP_1620 for attribute L3PR_GPwPfP_1620
		[DataContract]
		public class L3PR_GPwPfP_1620 
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
			public bool IsCustomizable { get; set; } 
			[DataMember]
			public Guid Product_DocumentationStructure_RefID { get; set; } 
			[DataMember]
			public Guid Document_RefID { get; set; } 
			[DataMember]
			public Boolean IsImportedFromExternalCatalog { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3PR_GPwPfP_1620 cls_Get_Product_with_PictureID_for_ProductID(,P_L3PR_GPwPfP_1620 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3PR_GPwPfP_1620 invocationResult = cls_Get_Product_with_PictureID_for_ProductID.Invoke(connectionString,P_L3PR_GPwPfP_1620 Parameter,securityTicket);
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
var parameter = new CL3_Product.Atomic.Retrieval.P_L3PR_GPwPfP_1620();
parameter.ProductID = ...;

*/
