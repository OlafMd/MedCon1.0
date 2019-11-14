/* 
 * Generated on 1/31/2014 2:57:18 PM
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

namespace CL5_APOBilling_Bill.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Cancel_BillHeaders.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Cancel_BillHeaders
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Bool Execute(DbConnection Connection,DbTransaction Transaction,P_L5BL_CBH_1330 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_Bool();

            foreach(var BillHeaderID in Parameter.BillHeaderIDs)
            {
                // Retrieve bill header
                var billHeader = new CL1_BIL.ORM_BIL_BillHeader();
                billHeader.Load(Connection, Transaction, BillHeaderID);

                // Find current status for bill header
                var billHeaderStatus = CL1_BIL.ORM_BIL_BillHeader_2_BillStatus.Query.Search(Connection, Transaction,
                    new CL1_BIL.ORM_BIL_BillHeader_2_BillStatus.Query
                    {
                        BIL_BillHeader_RefID = BillHeaderID,
                        IsCurrentStatus = true,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).Single();

                var status = CL1_BIL.ORM_BIL_BillStatus.Query.Search(Connection, Transaction,
                    new CL1_BIL.ORM_BIL_BillStatus.Query
                    {
                        BIL_BillStatusID = billHeaderStatus.BIL_BillStatus_RefID,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).Single();

                bool result = status.GlobalPropertyMatchingID ==
                    DLCore_DBCommons.Utils.EnumUtils.GetEnumDescription(DLCore_DBCommons.APODemand.EBillStatus.Closed);

                if (result == false)
                {
                    throw new Exception("Bill header status is not expected. It cannot be canceled!");
                }

                #region Cancel customerOrderReturnPosition 




                #endregion

                #region Cancel bill positions

                // Retrieve bill positions for bill header.
                var billPositions = CL1_BIL.ORM_BIL_BillPosition.Query.Search(Connection, Transaction,
                    new CL1_BIL.ORM_BIL_BillPosition.Query
                    {
                        BIL_BilHeader_RefID = BillHeaderID,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    });

                // Cancel all bill positions
                foreach (var billPosition in billPositions)
                {
                    // Delete relationship between BillPositions and ShipmentPosition in Assignment table.
                    CL1_BIL.ORM_BIL_BillPosition_2_ShipmentPosition.Query.SoftDelete(Connection, Transaction,
                        new CL1_BIL.ORM_BIL_BillPosition_2_ShipmentPosition.Query
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
                }

                #endregion

                #region Deactivate current bill statuses

                billHeaderStatus.IsCurrentStatus = false;
                billHeaderStatus.Save(Connection, Transaction);

                #endregion

                #region Add status "Canceled" for Bill Header

                var statusCanceled = CL1_BIL.ORM_BIL_BillStatus.Query.Search(Connection, Transaction,
                    new CL1_BIL.ORM_BIL_BillStatus.Query
                    {
                        GlobalPropertyMatchingID = DLCore_DBCommons.Utils.EnumUtils.GetEnumDescription(DLCore_DBCommons.APODemand.EBillStatus.Canceled),
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).Single();

                var billHeader2BillStatusCanceled = new CL1_BIL.ORM_BIL_BillHeader_2_BillStatus()
                {
                    BIL_BillHeader_RefID = BillHeaderID,
                    BIL_BillStatus_RefID = statusCanceled.BIL_BillStatusID,
                    IsCurrentStatus = true,
                    Tenant_RefID = securityTicket.TenantID,
                    Creation_Timestamp = DateTime.Now
                };
                billHeader2BillStatusCanceled.Save(Connection, Transaction);

                #endregion
            }

            // Return success
            returnValue.Status = FR_Status.Success;
            returnValue.Result = true;
            return returnValue;
            #endregion UserCode
        }
        #endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Bool Invoke(string ConnectionString,P_L5BL_CBH_1330 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection,P_L5BL_CBH_1330 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction,P_L5BL_CBH_1330 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5BL_CBH_1330 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Cancel_BillHeaders",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5BL_CBH_1330 for attribute P_L5BL_CBH_1330
		[DataContract]
		public class P_L5BL_CBH_1330 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] BillHeaderIDs { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Bool cls_Cancel_BillHeaders(,P_L5BL_CBH_1330 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Bool invocationResult = cls_Cancel_BillHeaders.Invoke(connectionString,P_L5BL_CBH_1330 Parameter,securityTicket);
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
var parameter = new CL5_APOBilling_Bill.Complex.Manipulation.P_L5BL_CBH_1330();
parameter.BillHeaderIDs = ...;

*/
