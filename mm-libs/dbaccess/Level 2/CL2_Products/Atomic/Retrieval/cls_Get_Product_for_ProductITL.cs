/* 
 * Generated on 28/12/2013 06:59:42
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
using System.Runtime.Serialization;

namespace CL2_Products.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Product_for_ProductITL.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Product_for_ProductITL
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2_GPfPITL_1651_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L2_GPfPITL_1651 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2_GPfPITL_1651_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_Products.Atomic.Retrieval.SQL.cls_Get_Product_for_ProductITL.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ProductITL", Parameter.ProductITL);



			List<L2_GPfPITL_1651> results = new List<L2_GPfPITL_1651>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] {  });
				while(reader.Read())
				{
					L2_GPfPITL_1651 resultItem = new L2_GPfPITL_1651();
					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Product_for_ProductITL",ex);
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
		public static FR_L2_GPfPITL_1651_Array Invoke(string ConnectionString,P_L2_GPfPITL_1651 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2_GPfPITL_1651_Array Invoke(DbConnection Connection,P_L2_GPfPITL_1651 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2_GPfPITL_1651_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L2_GPfPITL_1651 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2_GPfPITL_1651_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2_GPfPITL_1651 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2_GPfPITL_1651_Array functionReturn = new FR_L2_GPfPITL_1651_Array();
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

				throw new Exception("Exception occured in method cls_Get_Product_for_ProductITL",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2_GPfPITL_1651_Array : FR_Base
	{
		public L2_GPfPITL_1651[] Result	{ get; set; } 
		public FR_L2_GPfPITL_1651_Array() : base() {}

		public FR_L2_GPfPITL_1651_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L2_GPfPITL_1651 for attribute P_L2_GPfPITL_1651
		[DataContract]
		public class P_L2_GPfPITL_1651 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProductITL { get; set; } 

		}
		#endregion
		#region SClass L2_GPfPITL_1651 for attribute L2_GPfPITL_1651
		[DataContract]
		public class L2_GPfPITL_1651 
		{
			//Standard type parameters
		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2_GPfPITL_1651_Array cls_Get_Product_for_ProductITL(,P_L2_GPfPITL_1651 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2_GPfPITL_1651_Array invocationResult = cls_Get_Product_for_ProductITL.Invoke(connectionString,P_L2_GPfPITL_1651 Parameter,securityTicket);
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
var parameter = new CL2_Products.Atomic.Retrieval.P_L2_GPfPITL_1651();
parameter.ProductITL = ...;

*/
