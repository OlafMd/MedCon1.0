/* 
 * Generated on 4/22/2014 9:59:34 AM
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

namespace CL5_APOBilling_Bill.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Cancel_BillPositions.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Cancel_BillPositions
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5BL_CBP_1330 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_Guid();

            var billHeader = new CL1_BIL.ORM_BIL_BillHeader();
            billHeader.Load(Connection, Transaction, Parameter.BillHeaderID);

            foreach (var item in Parameter.BillPositionIDs)
            {
                // Retrieve Bill Position
                var billPosition = new CL1_BIL.ORM_BIL_BillPosition();
                billPosition.Load(Connection, Transaction, item);

                // Delete relationship between Bill Positions and Shipment Positions in Assignment table.
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

                // Delete bill position
                billPosition.IsDeleted = true;
                billPosition.Save(Connection, Transaction);

                // Substract values for bill header
                billHeader.TotalValue_BeforeTax -= billPosition.PositionValue_BeforeTax;
                billHeader.TotalValue_IncludingTax -= billPosition.PositionValue_IncludingTax;
            }
            billHeader.Save(Connection, Transaction);

            returnValue.Status = FR_Status.Success;
            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5BL_CBP_1330 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5BL_CBP_1330 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5BL_CBP_1330 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5BL_CBP_1330 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Cancel_BillPositions",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5BL_CBP_1330 for attribute P_L5BL_CBP_1330
		[DataContract]
		public class P_L5BL_CBP_1330 
		{
			//Standard type parameters
			[DataMember]
			public Guid BillHeaderID { get; set; } 
			[DataMember]
			public Guid[] BillPositionIDs { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Cancel_BillPositions(,P_L5BL_CBP_1330 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Cancel_BillPositions.Invoke(connectionString,P_L5BL_CBP_1330 Parameter,securityTicket);
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
var parameter = new CL5_APOBilling_Bill.Complex.Manipulation.P_L5BL_CBP_1330();
parameter.BillHeaderID = ...;
parameter.BillPositionIDs = ...;

*/
