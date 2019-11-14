/* 
 * Generated on 10/22/2013 2:55:16 PM
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
using CL1_ACC_BNK;
using CL5_Plannico_Banks.Atomic.Retrieval;

namespace CL5_Plannico_Banks.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Banks_For_BankID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Banks_For_BankID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5BK_GBFBID_1447 Execute(DbConnection Connection,DbTransaction Transaction,P_L5BK_GBFBID_1447 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_L5BK_GBFBID_1447();
            returnValue.Result = new L5BK_GBFBID_1447();

            ORM_ACC_BNK_Banks.Query bankQuery = new ORM_ACC_BNK_Banks.Query();
            bankQuery.ACC_BNK_BankID = Parameter.ACC_BNK_BankID;
            bankQuery.Tenant_RefID = securityTicket.TenantID;
            List<ORM_ACC_BNK_Banks> banks=ORM_ACC_BNK_Banks.Query.Search(Connection, Transaction, bankQuery);
            if (banks.Count == 0)
            {
                return null;
            }
            else
            {
                L5BK_GBFT_1318 bank = new L5BK_GBFT_1318();
                bank.ACC_BNK_BankID = banks[0].ACC_BNK_BankID;
                bank.BankName = banks[0].BankName;
                bank.BankNumber = banks[0].BankNumber;
                bank.BICCode = banks[0].BICCode;
                bank.Country_RefID = banks[0].Country_RefID;
                bank.RoutingNumber = banks[0].RoutingNumber;
                returnValue.Result.Bank= bank;
            }
			//Put your code here
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5BK_GBFBID_1447 Invoke(string ConnectionString,P_L5BK_GBFBID_1447 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5BK_GBFBID_1447 Invoke(DbConnection Connection,P_L5BK_GBFBID_1447 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5BK_GBFBID_1447 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5BK_GBFBID_1447 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5BK_GBFBID_1447 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5BK_GBFBID_1447 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5BK_GBFBID_1447 functionReturn = new FR_L5BK_GBFBID_1447();
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

				throw new Exception("Exception occured in method cls_Get_Banks_For_BankID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5BK_GBFBID_1447 : FR_Base
	{
		public L5BK_GBFBID_1447 Result	{ get; set; }

		public FR_L5BK_GBFBID_1447() : base() {}

		public FR_L5BK_GBFBID_1447(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5BK_GBFBID_1447 for attribute P_L5BK_GBFBID_1447
		[DataContract]
		public class P_L5BK_GBFBID_1447 
		{
			//Standard type parameters
			[DataMember]
			public Guid ACC_BNK_BankID { get; set; } 

		}
		#endregion
		#region SClass L5BK_GBFBID_1447 for attribute L5BK_GBFBID_1447
		[DataContract]
		public class L5BK_GBFBID_1447 
		{
			//Standard type parameters
			[DataMember]
			public L5BK_GBFT_1318 Bank { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5BK_GBFBID_1447 cls_Get_Banks_For_BankID(,P_L5BK_GBFBID_1447 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5BK_GBFBID_1447 invocationResult = cls_Get_Banks_For_BankID.Invoke(connectionString,P_L5BK_GBFBID_1447 Parameter,securityTicket);
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
var parameter = new CL5_Plannico_Banks.Complex.Retrieval.P_L5BK_GBFBID_1447();
parameter.ACC_BNK_BankID = ...;

*/