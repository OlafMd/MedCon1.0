/* 
 * Generated on 1/31/2014 3:00:52 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 * Required Assemblies:
 * System.Runtime.Serialization
 * CSV2Core
 * CSV2Core_MySQL
 */
using System;
using System.Data.Common;
using CSV2Core.Core;
using System.Runtime.Serialization;
using CL1_BIL;


namespace CL5_APOBilling_Bill.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Delete_BillHeader.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Delete_BillHeader
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5BL_DBH_1332 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
            #region UserCode
            var returnValue = new FR_Guid();
            
            #region Retreve Bill Header
            
            var billHeader = new ORM_BIL_BillHeader();
            billHeader.Load(Connection, Transaction, Parameter.BillHeaderID);
            
            #endregion

            returnValue.Result = billHeader.BIL_BillHeaderID;

            #region Delete Bill Positions for Bill Header
            
            // Retrieve bill positions for bill header.
            var billPositions = ORM_BIL_BillPosition.Query.Search(Connection, Transaction,
                new ORM_BIL_BillPosition.Query
                {
                    BIL_BilHeader_RefID = billHeader.BIL_BillHeaderID,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                });

            foreach (var billPosition in billPositions)
            {
                // Delete relationship between BillPositions and CustomerOrderPositions in Assignment table.
                var billPos2CusPoss = ORM_BIL_BillPosition_2_ShipmentPosition.Query.SoftDelete(Connection, Transaction,
                     new ORM_BIL_BillPosition_2_ShipmentPosition.Query
                     {
                         BIL_BillPosition_RefID = billPosition.BIL_BillPositionID,
                         Tenant_RefID = securityTicket.TenantID,
                         IsDeleted = false
                     });

                CL1_BIL.ORM_BIL_BillPosition_2_CustomerOrderReturnPosition.Query.SoftDelete(Connection, Transaction,
                     new CL1_BIL.ORM_BIL_BillPosition_2_CustomerOrderReturnPosition.Query
                     {
                         BIL_BillPosition_RefID = billPosition.BIL_BillPositionID,
                         Tenant_RefID = securityTicket.TenantID,
                         IsDeleted = false
                     });

                billPosition.IsDeleted = true;
                billPosition.Save(Connection, Transaction);
            }

            #endregion

            #region Delete Bill Header's statuses

            // Delete all statuses for Bill header
            var billHeader2Statuses = ORM_BIL_BillHeader_2_BillStatus.Query.SoftDelete(Connection, Transaction,
                new ORM_BIL_BillHeader_2_BillStatus.Query
                {
                    BIL_BillHeader_RefID = billHeader.BIL_BillHeaderID,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                });

            #endregion

            #region Delete Bill Header

            billHeader.IsDeleted = true;
            billHeader.Save(Connection, Transaction);

            #endregion

            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5BL_DBH_1332 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5BL_DBH_1332 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5BL_DBH_1332 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5BL_DBH_1332 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Delete_BillHeader",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5BL_DBH_1332 for attribute P_L5BL_DBH_1332
		[DataContract]
		public class P_L5BL_DBH_1332 
		{
			//Standard type parameters
			[DataMember]
			public Guid BillHeaderID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Delete_BillHeader(,P_L5BL_DBH_1332 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Delete_BillHeader.Invoke(connectionString,P_L5BL_DBH_1332 Parameter,securityTicket);
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
var parameter = new CL5_APOBilling_Bill.Complex.Manipulation.P_L5BL_DBH_1332();
parameter.BillHeaderID = ...;

*/
