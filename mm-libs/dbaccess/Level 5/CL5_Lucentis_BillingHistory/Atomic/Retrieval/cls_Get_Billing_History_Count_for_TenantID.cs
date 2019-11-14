/* 
 * Generated on 2/7/2014 4:01:44 PM
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

namespace CL5_Lucentis_BillingHistory.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Billing_History_Count_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Billing_History_Count_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5BH_GBHCfT_1334 Execute(DbConnection Connection,DbTransaction Transaction,P_L5BH_GBHCfT_1334 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5BH_GBHCfT_1334();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_Lucentis_BillingHistory.Atomic.Retrieval.SQL.cls_Get_Billing_History_Count_for_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@BillStatusID"," IN $$BillStatusID$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$BillStatusID$",Parameter.BillStatusID);
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"SearchCriterium", Parameter.SearchCriterium);

            /***For Search**/
            string newText2 = command.CommandText.Replace("@SearchCriterium", Parameter.SearchCriterium);
            command.CommandText = newText2;

			List<L5BH_GBHCfT_1334> results = new List<L5BH_GBHCfT_1334>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "NumberOfElements" });
				while(reader.Read())
				{
					L5BH_GBHCfT_1334 resultItem = new L5BH_GBHCfT_1334();
					//0:Parameter NumberOfElements of type int
					resultItem.NumberOfElements = reader.GetInteger(0);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Billing_History_Count_for_TenantID",ex);
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
		public static FR_L5BH_GBHCfT_1334 Invoke(string ConnectionString,P_L5BH_GBHCfT_1334 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5BH_GBHCfT_1334 Invoke(DbConnection Connection,P_L5BH_GBHCfT_1334 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5BH_GBHCfT_1334 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5BH_GBHCfT_1334 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5BH_GBHCfT_1334 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5BH_GBHCfT_1334 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5BH_GBHCfT_1334 functionReturn = new FR_L5BH_GBHCfT_1334();
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

				throw new Exception("Exception occured in method cls_Get_Billing_History_Count_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5BH_GBHCfT_1334 : FR_Base
	{
		public L5BH_GBHCfT_1334 Result	{ get; set; }

		public FR_L5BH_GBHCfT_1334() : base() {}

		public FR_L5BH_GBHCfT_1334(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5BH_GBHCfT_1334 for attribute P_L5BH_GBHCfT_1334
		[DataContract]
		public class P_L5BH_GBHCfT_1334 
		{
			//Standard type parameters
			[DataMember]
			public String[] BillStatusID { get; set; } 
			[DataMember]
			public String SearchCriterium { get; set; } 

		}
		#endregion
		#region SClass L5BH_GBHCfT_1334 for attribute L5BH_GBHCfT_1334
		[DataContract]
		public class L5BH_GBHCfT_1334 
		{
			//Standard type parameters
			[DataMember]
			public int NumberOfElements { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5BH_GBHCfT_1334 cls_Get_Billing_History_Count_for_TenantID(,P_L5BH_GBHCfT_1334 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5BH_GBHCfT_1334 invocationResult = cls_Get_Billing_History_Count_for_TenantID.Invoke(connectionString,P_L5BH_GBHCfT_1334 Parameter,securityTicket);
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
var parameter = new CL5_Lucentis_BillingHistory.Atomic.Retrieval.P_L5BH_GBHCfT_1334();
parameter.BillStatusID = ...;
parameter.SearchCriterium = ...;

*/
