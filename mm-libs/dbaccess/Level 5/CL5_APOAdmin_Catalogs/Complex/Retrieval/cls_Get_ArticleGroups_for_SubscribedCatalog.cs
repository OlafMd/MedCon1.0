/* 
 * Generated on 12/20/2013 3:25:02 PM
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
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;
using System.Runtime.Serialization;
using CL1_CMN_PRO;
using CL1_USR;
using DLCore_DBCommons.Utils;
using DLCore_DBCommons.APODemand;

namespace CL5_APOAdmin_Catalogs.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ArticleGroups_for_SubscribedCatalog.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ArticleGroups_for_SubscribedCatalog
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5CA_GAGfSC_1456_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5CA_GAGfSC_1456 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_L5CA_GAGfSC_1456_Array();
			
            ORM_CMN_PRO_SubscribedCatalog.Query query = new ORM_CMN_PRO_SubscribedCatalog.Query();
            query.CMN_PRO_SubscribedCatalogID = Parameter.SubscribedCatalogID;
            query.Tenant_RefID = securityTicket.TenantID;
            query.IsDeleted = false;
            ORM_CMN_PRO_SubscribedCatalog subscribedCatalog = ORM_CMN_PRO_SubscribedCatalog.Query.Search(Connection, Transaction, query).SingleOrDefault();
            if (subscribedCatalog != null && subscribedCatalog.CMN_PRO_SubscribedCatalogID == Parameter.SubscribedCatalogID)
            {
                string matching = subscribedCatalog.IsCatalogPublic ? EnumUtils.GetEnumDescription(EProductGroup.ABDA) : EnumUtils.GetEnumDescription(EProductGroup.HauseList);

                ORM_USR_Account.Query query2 = new ORM_USR_Account.Query();
                query2.USR_AccountID = securityTicket.AccountID;
                query2.Tenant_RefID = securityTicket.TenantID;
                query2.IsDeleted = false;
                ORM_USR_Account account = ORM_USR_Account.Query.Search(Connection, Transaction, query2).SingleOrDefault();
                if (account != null && account.USR_AccountID == query2.USR_AccountID)
                {
                    ORM_CMN_PRO_ProductGroup.Query query3 = new ORM_CMN_PRO_ProductGroup.Query();
                    query3.GlobalPropertyMatchingID = matching; //+ account.BusinessParticipant_RefID;
                    query3.Tenant_RefID = securityTicket.TenantID;
                    query3.IsDeleted = false;

                    var productGroups = ORM_CMN_PRO_ProductGroup.Query.Search(Connection, Transaction, query3);

                    returnValue.Result = productGroups.Select(x =>
                        new L5CA_GAGfSC_1456
                        {
                            CMN_PRO_ProductGroupID = x.CMN_PRO_ProductGroupID,
                            Parent_RefID = x.Parent_RefID,
                            ProductGroup_Name = x.ProductGroup_Name,
                            ProductGroup_Description = x.ProductGroup_Description
                        }
                    ).ToArray();

                }
            }

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5CA_GAGfSC_1456_Array Invoke(string ConnectionString,P_L5CA_GAGfSC_1456 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5CA_GAGfSC_1456_Array Invoke(DbConnection Connection,P_L5CA_GAGfSC_1456 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5CA_GAGfSC_1456_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5CA_GAGfSC_1456 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5CA_GAGfSC_1456_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5CA_GAGfSC_1456 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5CA_GAGfSC_1456_Array functionReturn = new FR_L5CA_GAGfSC_1456_Array();
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

				throw new Exception("Exception occured in method cls_Get_ArticleGroups_for_SubscribedCatalog",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5CA_GAGfSC_1456_Array : FR_Base
	{
		public L5CA_GAGfSC_1456[] Result	{ get; set; } 
		public FR_L5CA_GAGfSC_1456_Array() : base() {}

		public FR_L5CA_GAGfSC_1456_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5CA_GAGfSC_1456 for attribute P_L5CA_GAGfSC_1456
		[DataContract]
		public class P_L5CA_GAGfSC_1456 
		{
			//Standard type parameters
			[DataMember]
			public Guid SubscribedCatalogID { get; set; } 

		}
		#endregion
		#region SClass L5CA_GAGfSC_1456 for attribute L5CA_GAGfSC_1456
		[DataContract]
		public class L5CA_GAGfSC_1456 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_ProductGroupID { get; set; } 
			[DataMember]
			public Guid Parent_RefID { get; set; } 
			[DataMember]
			public Dict ProductGroup_Name { get; set; } 
			[DataMember]
			public Dict ProductGroup_Description { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5CA_GAGfSC_1456_Array cls_Get_ArticleGroups_for_SubscribedCatalog(,P_L5CA_GAGfSC_1456 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5CA_GAGfSC_1456_Array invocationResult = cls_Get_ArticleGroups_for_SubscribedCatalog.Invoke(connectionString,P_L5CA_GAGfSC_1456 Parameter,securityTicket);
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
var parameter = new CL5_APOAdmin_Catalogs.Complex.Retrieval.P_L5CA_GAGfSC_1456();
parameter.SubscribedCatalogID = ...;

*/
