/* 
 * Generated on 3/23/2015 01:20:35
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

namespace CL3_ShelfContent.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ShelfContentInventarData.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ShelfContentInventarData
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3SC_GSCID_1711_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3SC_GSCID_1711 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3SC_GSCID_1711_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_ShelfContent.Atomic.Retrieval.SQL.cls_Get_ShelfContentInventarData.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@ShelfIDList"," IN $$ShelfIDList$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$ShelfIDList$",Parameter.ShelfIDList);


			List<L3SC_GSCID_1711> results = new List<L3SC_GSCID_1711>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "LOG_WRH_Shelf_ContentID","Product_Number","Product_Name_DictID","VariantName_DictID","Shelf_RefID","Label_DictID" });
				while(reader.Read())
				{
					L3SC_GSCID_1711 resultItem = new L3SC_GSCID_1711();
					//0:Parameter LOG_WRH_Shelf_ContentID of type Guid
					resultItem.LOG_WRH_Shelf_ContentID = reader.GetGuid(0);
					//1:Parameter Product_Number of type String
					resultItem.Product_Number = reader.GetString(1);
					//2:Parameter Product_Name of type Dict
					resultItem.Product_Name = reader.GetDictionary(2);
					resultItem.Product_Name.SourceTable = "CMN_PRO_Products";
					loader.Append(resultItem.Product_Name);
					//3:Parameter VariantName of type Dict
					resultItem.VariantName = reader.GetDictionary(3);
					resultItem.VariantName.SourceTable = "CMN_PRO_Product_Variants";
					loader.Append(resultItem.VariantName);
					//4:Parameter Shelf_RefID of type Guid
					resultItem.Shelf_RefID = reader.GetGuid(4);
					//5:Parameter Label of type Dict
					resultItem.Label = reader.GetDictionary(5);
					resultItem.Label.SourceTable = "CMN_Units";
					loader.Append(resultItem.Label);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_ShelfContentInventarData",ex);
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
		public static FR_L3SC_GSCID_1711_Array Invoke(string ConnectionString,P_L3SC_GSCID_1711 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3SC_GSCID_1711_Array Invoke(DbConnection Connection,P_L3SC_GSCID_1711 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3SC_GSCID_1711_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3SC_GSCID_1711 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3SC_GSCID_1711_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3SC_GSCID_1711 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3SC_GSCID_1711_Array functionReturn = new FR_L3SC_GSCID_1711_Array();
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

				throw new Exception("Exception occured in method cls_Get_ShelfContentInventarData",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3SC_GSCID_1711_Array : FR_Base
	{
		public L3SC_GSCID_1711[] Result	{ get; set; } 
		public FR_L3SC_GSCID_1711_Array() : base() {}

		public FR_L3SC_GSCID_1711_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3SC_GSCID_1711 for attribute P_L3SC_GSCID_1711
		[DataContract]
		public class P_L3SC_GSCID_1711 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] ShelfIDList { get; set; } 

		}
		#endregion
		#region SClass L3SC_GSCID_1711 for attribute L3SC_GSCID_1711
		[DataContract]
		public class L3SC_GSCID_1711 
		{
			//Standard type parameters
			[DataMember]
			public Guid LOG_WRH_Shelf_ContentID { get; set; } 
			[DataMember]
			public String Product_Number { get; set; } 
			[DataMember]
			public Dict Product_Name { get; set; } 
			[DataMember]
			public Dict VariantName { get; set; } 
			[DataMember]
			public Guid Shelf_RefID { get; set; } 
			[DataMember]
			public Dict Label { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3SC_GSCID_1711_Array cls_Get_ShelfContentInventarData(,P_L3SC_GSCID_1711 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3SC_GSCID_1711_Array invocationResult = cls_Get_ShelfContentInventarData.Invoke(connectionString,P_L3SC_GSCID_1711 Parameter,securityTicket);
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
var parameter = new CL3_ShelfContent.Atomic.Retrieval.P_L3SC_GSCID_1711();
parameter.ShelfIDList = ...;

*/
