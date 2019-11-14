/* 
 * Generated on 11/11/2014 2:39:27 PM
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
using CL5_Zugseil_Catalogs.Atomic.Retrieval;

namespace CL5_Zugseil_Catalogs.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Imported_Catalog_for_SearchCriteria_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Imported_Catalog_for_SearchCriteria_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5CA_GICfSCfTID_1437 Execute(DbConnection Connection,DbTransaction Transaction,P_L5CA_GICfSCfTID_1437 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_L5CA_GICfSCfTID_1437();

			//Put your code here
            List<L5CA_GICfTID_1432> subscribedCatalogsList = new List<L5CA_GICfTID_1432>();

            if (Parameter.SearchCriteria != null)
            {

                Parameter.SearchCriteria = Parameter.SearchCriteria.Replace("%", "\\%");
                Parameter.SearchCriteria = "%" + Parameter.SearchCriteria.ToUpper() + "%";
            }

            #region get subscribed catalogs
            P_L5CA_GICfTID_1432 param = new P_L5CA_GICfTID_1432();
            param.BussinessParticipantID = Parameter.BussinessParticipantID;
            param.ActivePage = Parameter.ActivePage;
            param.PageSize = Parameter.PageSize;
            param.SearchCriteria = Parameter.SearchCriteria;
            param.OrderByCriteria = Parameter.OrderByCriteria;

            var result = cls_Get_Imported_Catalog_for_TenantID.Invoke(Connection, Transaction, param, securityTicket);
            if(result != null && result.Result != null)
                subscribedCatalogsList = result.Result.ToList();
            #endregion

            L5CA_GICfSCfTID_1437 retValResult = new L5CA_GICfSCfTID_1437();
            retValResult.SubscribedCatalogsList = subscribedCatalogsList.ToArray();
            returnValue.Result = retValResult;

            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5CA_GICfSCfTID_1437 Invoke(string ConnectionString,P_L5CA_GICfSCfTID_1437 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5CA_GICfSCfTID_1437 Invoke(DbConnection Connection,P_L5CA_GICfSCfTID_1437 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5CA_GICfSCfTID_1437 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5CA_GICfSCfTID_1437 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5CA_GICfSCfTID_1437 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5CA_GICfSCfTID_1437 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5CA_GICfSCfTID_1437 functionReturn = new FR_L5CA_GICfSCfTID_1437();
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

				throw new Exception("Exception occured in method cls_Get_Imported_Catalog_for_SearchCriteria_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5CA_GICfSCfTID_1437 : FR_Base
	{
		public L5CA_GICfSCfTID_1437 Result	{ get; set; }

		public FR_L5CA_GICfSCfTID_1437() : base() {}

		public FR_L5CA_GICfSCfTID_1437(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5CA_GICfSCfTID_1437 for attribute P_L5CA_GICfSCfTID_1437
		[DataContract]
		public class P_L5CA_GICfSCfTID_1437 
		{
			//Standard type parameters
			[DataMember]
			public int PageSize { get; set; } 
			[DataMember]
			public int ActivePage { get; set; } 
			[DataMember]
			public String SearchCriteria { get; set; } 
			[DataMember]
			public String OrderByCriteria { get; set; } 
			[DataMember]
			public Guid BussinessParticipantID { get; set; } 

		}
		#endregion
		#region SClass L5CA_GICfSCfTID_1437 for attribute L5CA_GICfSCfTID_1437
		[DataContract]
		public class L5CA_GICfSCfTID_1437 
		{
			//Standard type parameters
			[DataMember]
			public L5CA_GICfTID_1432[] SubscribedCatalogsList { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5CA_GICfSCfTID_1437 cls_Get_Imported_Catalog_for_SearchCriteria_for_TenantID(,P_L5CA_GICfSCfTID_1437 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5CA_GICfSCfTID_1437 invocationResult = cls_Get_Imported_Catalog_for_SearchCriteria_for_TenantID.Invoke(connectionString,P_L5CA_GICfSCfTID_1437 Parameter,securityTicket);
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
var parameter = new CL5_Zugseil_Catalogs.Complex.Retrieval.P_L5CA_GICfSCfTID_1437();
parameter.PageSize = ...;
parameter.ActivePage = ...;
parameter.SearchCriteria = ...;
parameter.OrderByCriteria = ...;
parameter.BussinessParticipantID = ...;

*/
