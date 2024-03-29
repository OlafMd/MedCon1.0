/* 
 * Generated on 10/31/2014 12:57:01 PM
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
using CL1_CMN_PRO;

namespace CL5_Zugseil_Catalogs.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Check_ProductsExists_for_RevisionID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Check_ProductsExists_for_RevisionID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Bool Execute(DbConnection Connection,DbTransaction Transaction,P_L5CA_CPEfRI_1256 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Bool();

			//Put your code here

            var exists = ORM_CMN_PRO_Catalog_Product.Query.Exists(Connection, Transaction,
                new ORM_CMN_PRO_Catalog_Product.Query
                {
                    CMN_PRO_Catalog_Revision_RefID = Parameter.CatalogRevision_ID,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                });

            returnValue.Result = exists;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Bool Invoke(string ConnectionString,P_L5CA_CPEfRI_1256 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection,P_L5CA_CPEfRI_1256 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction,P_L5CA_CPEfRI_1256 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5CA_CPEfRI_1256 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Bool functionReturn = new FR_Bool();
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

				throw new Exception("Exception occured in method cls_Check_ProductsExists_for_RevisionID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5CA_CPEfRI_1256 for attribute P_L5CA_CPEfRI_1256
		[DataContract]
		public class P_L5CA_CPEfRI_1256 
		{
			//Standard type parameters
			[DataMember]
			public Guid CatalogRevision_ID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Bool cls_Check_ProductsExists_for_RevisionID(,P_L5CA_CPEfRI_1256 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Bool invocationResult = cls_Check_ProductsExists_for_RevisionID.Invoke(connectionString,P_L5CA_CPEfRI_1256 Parameter,securityTicket);
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
var parameter = new CL5_Zugseil_Catalogs.Atomic.Manipulation.P_L5CA_CPEfRI_1256();
parameter.CatalogRevision_ID = ...;

*/
