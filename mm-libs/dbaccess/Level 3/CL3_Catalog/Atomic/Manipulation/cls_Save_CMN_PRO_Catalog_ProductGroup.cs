/* 
 * Generated on 12/17/2013 3:31:47 PM
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

namespace CL3_Catalog.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_CMN_PRO_Catalog_ProductGroup.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_CMN_PRO_Catalog_ProductGroup
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L3CA_SCPG_1531 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){

			var returnValue = new FR_Guid();

			var item = new CL1_CMN_PRO.ORM_CMN_PRO_Catalog_ProductGroup();
			if (Parameter.CMN_PRO_Catalog_ProductGroupID != Guid.Empty)
			{
			    var result = item.Load(Connection, Transaction, Parameter.CMN_PRO_Catalog_ProductGroupID);
			    if (result.Status != FR_Status.Success || item.CMN_PRO_Catalog_ProductGroupID == Guid.Empty)
			    {
			        var error = new FR_Guid();
			        error.ErrorMessage = "No Such ID";
			        error.Status =  FR_Status.Error_Internal;
			        return error;
			    }
			}

			if(Parameter.IsDeleted == true){
				item.IsDeleted = true;
				return new FR_Guid(item.Save(Connection, Transaction),item.CMN_PRO_Catalog_ProductGroupID);
			}

			//Creation specific parameters (Tenant, Account ... )
			if (Parameter.CMN_PRO_Catalog_ProductGroupID == Guid.Empty)
			{
				item.Tenant_RefID = securityTicket.TenantID;
			}

			item.Catalog_Revision_RefID = Parameter.Catalog_Revision_RefID;
			item.CatalogProductGroup_Name = Parameter.CatalogProductGroup_Name;
			item.CatalogProductGroup_Parent_RefID = Parameter.CatalogProductGroup_Parent_RefID;


			return new FR_Guid(item.Save(Connection, Transaction),item.CMN_PRO_Catalog_ProductGroupID);
  
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L3CA_SCPG_1531 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L3CA_SCPG_1531 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L3CA_SCPG_1531 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3CA_SCPG_1531 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Guid functionReturn = new FR_Guid();
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

				throw new Exception("Exception occured in method cls_Save_CMN_PRO_Catalog_ProductGroup",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3CA_SCPG_1531 for attribute P_L3CA_SCPG_1531
		[DataContract]
		public class P_L3CA_SCPG_1531 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_Catalog_ProductGroupID { get; set; } 
			[DataMember]
			public Guid Catalog_Revision_RefID { get; set; } 
			[DataMember]
			public String CatalogProductGroup_Name { get; set; } 
			[DataMember]
			public Guid CatalogProductGroup_Parent_RefID { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_CMN_PRO_Catalog_ProductGroup(,P_L3CA_SCPG_1531 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_CMN_PRO_Catalog_ProductGroup.Invoke(connectionString,P_L3CA_SCPG_1531 Parameter,securityTicket);
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
var parameter = new CL3_Catalog.Atomic.Manipulation.P_L3CA_SCPG_1531();
parameter.CMN_PRO_Catalog_ProductGroupID = ...;
parameter.Catalog_Revision_RefID = ...;
parameter.CatalogProductGroup_Name = ...;
parameter.CatalogProductGroup_Parent_RefID = ...;
parameter.IsDeleted = ...;

*/
