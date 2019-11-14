/* 
 * Generated on 25/7/2014 02:25:28
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
using CL3_Warehouse.Atomic.Retrieval;

namespace CL3_Supplier.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Default_Supplier_for_Product.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Default_Supplier_for_Product
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3SP_GDSfP_1401 Execute(DbConnection Connection,DbTransaction Transaction,P_L3SP_GDSfP_1401 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L3SP_GDSfP_1401();
			//Put your code here
            List<Guid> article = new List<Guid>() {Parameter.ArticleID};

            var storageParam = new P_L3WH_GASfA_1924();
            storageParam.ArticleID_List = article.ToArray();
            var storages = cls_Get_ArticleStorages_for_ArticleIDList.Invoke(Connection, Transaction, storageParam, securityTicket).Result;

            L3SP_GDSfP_1401 resultingSupplier = new L3SP_GDSfP_1401();
            foreach (var storage in storages)
            {
                P_L3SP_GDSfS_1347 supplierParam = new P_L3SP_GDSfS_1347();

                supplierParam.AreaID = storage.AreaID;
                supplierParam.RackID = storage.RackID;
                supplierParam.WarehouseID = storage.WarehouseID;
                var supplier = cls_Get_Default_Supplier_from_Storage.Invoke(Connection, Transaction, supplierParam, securityTicket).Result;

                if (supplier != null)
                {
                    resultingSupplier.Supplier = supplier;
                    break;
                }
            }

            returnValue.Result = resultingSupplier;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3SP_GDSfP_1401 Invoke(string ConnectionString,P_L3SP_GDSfP_1401 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3SP_GDSfP_1401 Invoke(DbConnection Connection,P_L3SP_GDSfP_1401 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3SP_GDSfP_1401 Invoke(DbConnection Connection, DbTransaction Transaction,P_L3SP_GDSfP_1401 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3SP_GDSfP_1401 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3SP_GDSfP_1401 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3SP_GDSfP_1401 functionReturn = new FR_L3SP_GDSfP_1401();
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

				throw new Exception("Exception occured in method cls_Get_Default_Supplier_for_Product",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3SP_GDSfP_1401 : FR_Base
	{
		public L3SP_GDSfP_1401 Result	{ get; set; }

		public FR_L3SP_GDSfP_1401() : base() {}

		public FR_L3SP_GDSfP_1401(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3SP_GDSfP_1401 for attribute P_L3SP_GDSfP_1401
		[DataContract]
		public class P_L3SP_GDSfP_1401 
		{
			//Standard type parameters
			[DataMember]
			public Guid ArticleID { get; set; } 

		}
		#endregion
		#region SClass L3SP_GDSfP_1401 for attribute L3SP_GDSfP_1401
		[DataContract]
		public class L3SP_GDSfP_1401 
		{
			//Standard type parameters
			[DataMember]
			public L3SP_GDSfS_1347 Supplier { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3SP_GDSfP_1401 cls_Get_Default_Supplier_for_Product(,P_L3SP_GDSfP_1401 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3SP_GDSfP_1401 invocationResult = cls_Get_Default_Supplier_for_Product.Invoke(connectionString,P_L3SP_GDSfP_1401 Parameter,securityTicket);
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
var parameter = new CL3_Supplier.Complex.Retrieval.P_L3SP_GDSfP_1401();
parameter.ArticleID = ...;

*/
