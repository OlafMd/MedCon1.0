/* 
 * Generated on 10/31/2013 3:27:15 PM
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
using System.Runtime.Serialization;
using CL2_Office.Atomic.Manipulation;
using CL1_CMN_STR;
using CL2_Address.Atomic.Manipulation;

namespace CL5_APOAdmin_Office.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Delete_Office_Deep.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Delete_Office_Deep
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5OF_DOD_1520 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here

            var queryOfficeToDelete = new ORM_CMN_STR_Office.Query();
            queryOfficeToDelete.CMN_STR_OfficeID = Parameter.OfficeID;
            queryOfficeToDelete.Tenant_RefID = securityTicket.TenantID;
            queryOfficeToDelete.IsDeleted = false;
            var OfficeToDelete = ORM_CMN_STR_Office.Query.Search(Connection, Transaction, queryOfficeToDelete).SingleOrDefault();

            if (OfficeToDelete != null)
            {
                var param = new P_L2O_SO_1529();
                param.CMN_STR_OfficeID = Parameter.OfficeID;
                param.IsDeleted = true;
                                
                var queryOfficeAddresses = new ORM_CMN_STR_Office_Address.Query();
                queryOfficeAddresses.Office_RefID = Parameter.OfficeID;
                queryOfficeAddresses.Tenant_RefID = securityTicket.TenantID;
                queryOfficeAddresses.IsDeleted = false;

                //Locate all office addresses using connection table
                var OfficeAddresses = ORM_CMN_STR_Office_Address.Query.Search(Connection, Transaction, queryOfficeAddresses);
                
                foreach (var officeAddress in OfficeAddresses)
                {
                    var deleteAddressParam = new P_L2AD_SA_1755();
                    deleteAddressParam.CMN_AddressID = officeAddress.CMN_Address_RefID;
                    deleteAddressParam.IsDeleted = true;
                    cls_Save_Address.Invoke(Connection, Transaction, deleteAddressParam);
                }

                cls_Save_Office.Invoke(Connection, Transaction, param);
            }

            var queryChildrenOfficesToDelete = new ORM_CMN_STR_Office.Query();
            queryChildrenOfficesToDelete.Parent_RefID = Parameter.OfficeID;
            queryChildrenOfficesToDelete.Tenant_RefID = securityTicket.TenantID;
            queryChildrenOfficesToDelete.IsDeleted = false;
            var ChildrenOfficesToDelete = ORM_CMN_STR_Office.Query.Search(Connection, Transaction, queryChildrenOfficesToDelete);

            if (ChildrenOfficesToDelete.Count > 0)
            {
                foreach (var childrenOffice in ChildrenOfficesToDelete)
                {
                    var deleteChildrenOfficeParam = new P_L5OF_DOD_1520();
                    deleteChildrenOfficeParam.OfficeID = childrenOffice.CMN_STR_OfficeID;
                    cls_Delete_Office_Deep.Invoke(Connection, Transaction, deleteChildrenOfficeParam, securityTicket);
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
		public static FR_Guid Invoke(string ConnectionString,P_L5OF_DOD_1520 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5OF_DOD_1520 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5OF_DOD_1520 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5OF_DOD_1520 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Delete_Office_Deep",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5OF_DOD_1520 for attribute P_L5OF_DOD_1520
		[DataContract]
		public class P_L5OF_DOD_1520 
		{
			//Standard type parameters
			[DataMember]
			public Guid OfficeID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Delete_Office_Deep(,P_L5OF_DOD_1520 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Delete_Office_Deep.Invoke(connectionString,P_L5OF_DOD_1520 Parameter,securityTicket);
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
var parameter = new CL5_APOAdmin_Office.Complex.Manipulation.P_L5OF_DOD_1520();
parameter.OfficeID = ...;

*/
