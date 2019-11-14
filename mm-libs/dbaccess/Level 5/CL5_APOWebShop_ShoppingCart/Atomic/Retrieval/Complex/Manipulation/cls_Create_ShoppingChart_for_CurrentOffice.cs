/* 
 * Generated on 10/1/2014 05:09:06
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

namespace CL5_APOWebShop_ShoppingCart.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Create_ShoppingChart_for_CurrentOffice.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Create_ShoppingChart_for_CurrentOffice
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5AWSAR_CSC_1809 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_Guid();

            var item = new CL1_ORD_PRC.ORM_ORD_PRC_ShoppingCart();

            CL1_ORD_PRC.ORM_ORD_PRC_ShoppingCart_Status statusShoppingCart;

            if (Parameter.IsWaitingForApproval)
            {
                // Get status
                statusShoppingCart = CL1_ORD_PRC.ORM_ORD_PRC_ShoppingCart_Status.Query.Search(Connection, Transaction,
                new CL1_ORD_PRC.ORM_ORD_PRC_ShoppingCart_Status.Query()
                {
                    GlobalPropertyMatchingID = DLCore_DBCommons.Utils.EnumUtils.GetEnumDescription
                    (DLCore_DBCommons.APODemand.EShoppingCartStatus.WaitingForApproval),
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).Single();
            }
            else
            {
                // Get status
                statusShoppingCart = CL1_ORD_PRC.ORM_ORD_PRC_ShoppingCart_Status.Query.Search(Connection, Transaction,
                new CL1_ORD_PRC.ORM_ORD_PRC_ShoppingCart_Status.Query()
                {
                    GlobalPropertyMatchingID = DLCore_DBCommons.Utils.EnumUtils.GetEnumDescription
                    (DLCore_DBCommons.APODemand.EShoppingCartStatus.Active),
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).Single();
            }

            // Check does already exist available shopping cart for current office.
            var shoppingCartOffice = new CL1_ORD_PRC.ORM_ORD_PRC_Office_ShoppingCart();
            item.Tenant_RefID = securityTicket.TenantID;

            var lastShoppingCart = CL1_ORD_PRC.ORM_ORD_PRC_ShoppingCart.Query.Search(Connection, Transaction,
                new CL1_ORD_PRC.ORM_ORD_PRC_ShoppingCart.Query 
                { Tenant_RefID = securityTicket.TenantID }
                ).OrderByDescending(x => x.Creation_Timestamp).FirstOrDefault();

            // Set shopping cart number
            double internalIdentifier = 0;

            if (lastShoppingCart != null) 
                double.TryParse(lastShoppingCart.InternalIdentifier, out internalIdentifier);

            // Create shopping cart office
            shoppingCartOffice.ORD_PRC_ShoppingCart_RefID = item.ORD_PRC_ShoppingCartID;
            shoppingCartOffice.CMN_STR_Office_RefID = Parameter.OfficeID;
            shoppingCartOffice.Tenant_RefID = securityTicket.TenantID;
            shoppingCartOffice.Save(Connection, Transaction);

            // Create shoppping cart
            item.ShoppingCart_CurrentStatus_RefID = statusShoppingCart.ORD_PRC_ShoppingCart_StatusID;
            item.InternalIdentifier = (++internalIdentifier).ToString();
            item.CreatedBy_Account_RefID = securityTicket.AccountID;
            item.IsProcurementOrderCreated = false;

            // Create and save new shopping cart history
            var shoppingHistory = new CL1_ORD_PRC.ORM_ORD_PRC_ShoppingCartStatus_History();
            shoppingHistory.ORD_PRC_ShoppingCart_RefID = item.ORD_PRC_ShoppingCartID;
            shoppingHistory.ORD_PRC_ShoppingCart_Status_RefID = statusShoppingCart.ORD_PRC_ShoppingCart_StatusID;
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
		public static FR_Guid Invoke(string ConnectionString,P_L5AWSAR_CSC_1809 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5AWSAR_CSC_1809 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AWSAR_CSC_1809 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AWSAR_CSC_1809 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Create_ShoppingChart_for_CurrentOffice",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5AWSAR_CSC_1809 for attribute P_L5AWSAR_CSC_1809
		[DataContract]
		public class P_L5AWSAR_CSC_1809 
		{
			//Standard type parameters
			[DataMember]
			public Guid OfficeID { get; set; } 
			[DataMember]
			public bool IsWaitingForApproval { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Create_ShoppingChart_for_CurrentOffice(,P_L5AWSAR_CSC_1809 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Create_ShoppingChart_for_CurrentOffice.Invoke(connectionString,P_L5AWSAR_CSC_1809 Parameter,securityTicket);
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
var parameter = new CL5_APOWebShop_ShoppingCart.Complex.Manipulation.P_L5AWSAR_CSC_1809();
parameter.OfficeID = ...;
parameter.IsWaitingForApproval = ...;

*/
