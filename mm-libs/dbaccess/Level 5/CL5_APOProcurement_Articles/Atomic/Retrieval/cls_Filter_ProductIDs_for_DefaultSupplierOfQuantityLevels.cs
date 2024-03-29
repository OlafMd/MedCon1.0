/* 
 * Generated on 10/16/2014 10:37:29 AM
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

namespace CL5_APOProcurement_Articles.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Filter_ProductIDs_for_DefaultSupplierOfQuantityLevels.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Filter_ProductIDs_for_DefaultSupplierOfQuantityLevels
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5AR_FPfDSoQL_1410_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5AR_FPfDSoQL_1410 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5AR_FPfDSoQL_1410_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOProcurement_Articles.Atomic.Retrieval.SQL.cls_Filter_ProductIDs_for_DefaultSupplierOfQuantityLevels.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@ProductIDList"," IN $$ProductIDList$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$ProductIDList$",Parameter.ProductIDList);


			List<L5AR_FPfDSoQL_1410> results = new List<L5AR_FPfDSoQL_1410>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "Product_RefID","CMN_BPT_Supplier_RefID" });
				while(reader.Read())
				{
					L5AR_FPfDSoQL_1410 resultItem = new L5AR_FPfDSoQL_1410();
					//0:Parameter Product_RefID of type Guid
					resultItem.Product_RefID = reader.GetGuid(0);
					//1:Parameter CMN_BPT_Supplier_RefID of type Guid
					resultItem.CMN_BPT_Supplier_RefID = reader.GetGuid(1);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Filter_ProductIDs_for_DefaultSupplierOfQuantityLevels",ex);
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
		public static FR_L5AR_FPfDSoQL_1410_Array Invoke(string ConnectionString,P_L5AR_FPfDSoQL_1410 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5AR_FPfDSoQL_1410_Array Invoke(DbConnection Connection,P_L5AR_FPfDSoQL_1410 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5AR_FPfDSoQL_1410_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AR_FPfDSoQL_1410 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5AR_FPfDSoQL_1410_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AR_FPfDSoQL_1410 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5AR_FPfDSoQL_1410_Array functionReturn = new FR_L5AR_FPfDSoQL_1410_Array();
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

				throw new Exception("Exception occured in method cls_Filter_ProductIDs_for_DefaultSupplierOfQuantityLevels",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5AR_FPfDSoQL_1410_Array : FR_Base
	{
		public L5AR_FPfDSoQL_1410[] Result	{ get; set; } 
		public FR_L5AR_FPfDSoQL_1410_Array() : base() {}

		public FR_L5AR_FPfDSoQL_1410_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5AR_FPfDSoQL_1410 for attribute P_L5AR_FPfDSoQL_1410
		[DataContract]
		public class P_L5AR_FPfDSoQL_1410 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] ProductIDList { get; set; } 

		}
		#endregion
		#region SClass L5AR_FPfDSoQL_1410 for attribute L5AR_FPfDSoQL_1410
		[DataContract]
		public class L5AR_FPfDSoQL_1410 
		{
			//Standard type parameters
			[DataMember]
			public Guid Product_RefID { get; set; } 
			[DataMember]
			public Guid CMN_BPT_Supplier_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5AR_FPfDSoQL_1410_Array cls_Filter_ProductIDs_for_DefaultSupplierOfQuantityLevels(,P_L5AR_FPfDSoQL_1410 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5AR_FPfDSoQL_1410_Array invocationResult = cls_Filter_ProductIDs_for_DefaultSupplierOfQuantityLevels.Invoke(connectionString,P_L5AR_FPfDSoQL_1410 Parameter,securityTicket);
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
var parameter = new CL5_APOProcurement_Articles.Atomic.Retrieval.P_L5AR_FPfDSoQL_1410();
parameter.ProductIDList = ...;

*/
