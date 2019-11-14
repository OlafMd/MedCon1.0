/* 
 * Generated on 12/23/2013 2:31:51 PM
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
using CL1_CMN_STR;

namespace CL5_Lucentis_WebShop.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Create_ShoppingChart.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Create_ShoppingChart
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5WS_CSCfP_1431 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
            var item = new CL1_ORD_PRC.ORM_ORD_PRC_ShoppingCart();
            item.ORD_PRC_ShoppingCartID = Guid.NewGuid();

            // Get status
            var statusActive = CL1_ORD_PRC.ORM_ORD_PRC_ShoppingCart_Status.Query.Search(Connection, Transaction,
                new CL1_ORD_PRC.ORM_ORD_PRC_ShoppingCart_Status.Query()
                {
                    GlobalPropertyMatchingID = DLCore_DBCommons.Utils.EnumUtils.GetEnumDescription
                    (DLCore_DBCommons.APODemand.EShoppingCartStatus.Active),
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).Single();

            ORM_CMN_STR_Office office; 
            var offices = ORM_CMN_STR_Office.Query.Search(Connection, Transaction,
               new ORM_CMN_STR_Office.Query()
               {
                   Office_InternalName = Parameter.PracticeBPID,
                   Tenant_RefID = securityTicket.TenantID,
                   IsDeleted = false
               }).ToArray();
            if(offices.Count() == 0)
            {
                office = new ORM_CMN_STR_Office();
                office.CMN_STR_OfficeID = Guid.NewGuid();
                office.Tenant_RefID = securityTicket.TenantID;
                office.Office_InternalName = Parameter.PracticeBPID;
                office.Save(Connection, Transaction);
            }
            else
            {
                office = offices[0];
            }



            double internalIdentifier = 0;

            var lastShoppingCartOfficeAssignment = CL1_ORD_PRC.ORM_ORD_PRC_Office_ShoppingCart.Query.Search(Connection, Transaction,
                new CL1_ORD_PRC.ORM_ORD_PRC_Office_ShoppingCart.Query { Tenant_RefID = securityTicket.TenantID, CMN_STR_Office_RefID = office.CMN_STR_OfficeID }
                ).OrderByDescending(x => x.Creation_Timestamp).FirstOrDefault();
            if (lastShoppingCartOfficeAssignment != null)
            {
                var lastShoppingCart = CL1_ORD_PRC.ORM_ORD_PRC_ShoppingCart.Query.Search(Connection, Transaction,
                    new CL1_ORD_PRC.ORM_ORD_PRC_ShoppingCart.Query { Tenant_RefID = securityTicket.TenantID, ORD_PRC_ShoppingCartID = lastShoppingCartOfficeAssignment.ORD_PRC_ShoppingCart_RefID }
                    ).FirstOrDefault();
                double.TryParse(lastShoppingCart.InternalIdentifier, out internalIdentifier);
            }

            var shoppingCartOffice = new CL1_ORD_PRC.ORM_ORD_PRC_Office_ShoppingCart();
            shoppingCartOffice.ORD_PRC_ShoppingCart_RefID = item.ORD_PRC_ShoppingCartID;
            shoppingCartOffice.CMN_STR_Office_RefID = office.CMN_STR_OfficeID;
            shoppingCartOffice.Tenant_RefID = securityTicket.TenantID;
            shoppingCartOffice.Save(Connection, Transaction);

            // Create shoppping cart
            item.ShoppingCart_CurrentStatus_RefID = statusActive.ORD_PRC_ShoppingCart_StatusID;
            item.InternalIdentifier = (++internalIdentifier).ToString();
            item.Tenant_RefID = securityTicket.TenantID;
            item.CreatedBy_Account_RefID = securityTicket.AccountID;
            item.IsProcurementOrderCreated = false;

            // Create and save new shopping cart history
            var shoppingHistory = new CL1_ORD_PRC.ORM_ORD_PRC_ShoppingCartStatus_History();
            shoppingHistory.ORD_PRC_ShoppingCart_RefID = item.ORD_PRC_ShoppingCartID;
            shoppingHistory.ORD_PRC_ShoppingCart_Status_RefID = statusActive.ORD_PRC_ShoppingCart_StatusID;
            shoppingHistory.PerformedBy_Account_RefID = securityTicket.AccountID;
            shoppingHistory.Tenant_RefID = securityTicket.TenantID;
            shoppingHistory.Save(Connection, Transaction);

            return new FR_Guid(item.Save(Connection, Transaction), item.ORD_PRC_ShoppingCartID);
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5WS_CSCfP_1431 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5WS_CSCfP_1431 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5WS_CSCfP_1431 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5WS_CSCfP_1431 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Create_ShoppingChart",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5WS_CSCfP_1431 for attribute P_L5WS_CSCfP_1431
		[DataContract]
		public class P_L5WS_CSCfP_1431 
		{
			//Standard type parameters
			[DataMember]
			public String PracticeBPID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Create_ShoppingChart(,P_L5WS_CSCfP_1431 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Create_ShoppingChart.Invoke(connectionString,P_L5WS_CSCfP_1431 Parameter,securityTicket);
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
var parameter = new CL5_Lucentis_WebShop.Complex.Manipulation.P_L5WS_CSCfP_1431();
parameter.PracticeBPID = ...;

*/
