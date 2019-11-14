/* 
 * Generated on 28/7/2014 09:44:40
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
using System.Runtime.Serialization;
using CL1_ORD_PRC;
using CL1_CMN_PRO;
using CL1_CMN_PRO_PAC;

namespace CL3_APOProcurement_ProcurementOrder.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_ProcurementOrder_Positions.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_ProcurementOrder_Positions
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guids Execute(DbConnection Connection,DbTransaction Transaction,P_L3PO_SPOP_0331 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Guids();
			//Put your code here

            

            #region Get ProcurementOrder Header
            var header = ORM_ORD_PRC_ProcurementOrder_Header.Query.Search(Connection, Transaction
                , new ORM_ORD_PRC_ProcurementOrder_Header.Query()
                {
                    ORD_PRC_ProcurementOrder_HeaderID = Parameter.ORD_PRC_ProcurementOrder_HeaderID,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).FirstOrDefault();
            
            if (header.Equals(default(ORM_ORD_PRC_ProcurementOrder_Header)))
            {
                returnValue.Status = FR_Status.Error_Internal;
                return returnValue;
            }
            #endregion

            #region Get Positions count, if we are creating the positions
            int positionsCount = 0;
            if (Parameter.Positions[0].ORD_PRC_ProcurementOrder_PositionID == Guid.Empty)
            {
                positionsCount = ORM_ORD_PRC_ProcurementOrder_Position.Query.Search(Connection, Transaction,
                   new ORM_ORD_PRC_ProcurementOrder_Position.Query()
                   {
                       ProcurementOrder_Header_RefID = Parameter.ORD_PRC_ProcurementOrder_HeaderID,
                       IsDeleted = false,
                       Tenant_RefID = securityTicket.TenantID
                   }).Count();
            }
            #endregion

            List<Guid> createdPositionsIDs = new List<Guid>();

            decimal oldHeaderTotalValue = 0, newHeaderTotalValue = 0;
            foreach (var p in Parameter.Positions)
            {
                ORM_ORD_PRC_ProcurementOrder_Position position;
                if (p.ORD_PRC_ProcurementOrder_PositionID == Guid.Empty)
                {
                    #region Create ProcurementOrder Position

                    #region Get Unit ID
                    var product = ORM_CMN_PRO_Product.Query.Search(Connection, Transaction, new ORM_CMN_PRO_Product.Query
                    {
                        CMN_PRO_ProductID = p.ProductID,
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID
                    }).Single();

                    var packageInfo = ORM_CMN_PRO_PAC_PackageInfo.Query.Search(Connection, Transaction,
                        new ORM_CMN_PRO_PAC_PackageInfo.Query
                        {
                            CMN_PRO_PAC_PackageInfoID = product.PackageInfo_RefID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        }).Single();

                    var unitID = packageInfo.PackageContent_MeasuredInUnit_RefID;
                    #endregion

                    #region Create ProcurementPosition Object
                    position = new ORM_ORD_PRC_ProcurementOrder_Position()
                    {
                        ORD_PRC_ProcurementOrder_PositionID = Guid.NewGuid(),
                        CMN_PRO_Product_RefID = p.ProductID,
                        Creation_Timestamp = DateTime.Now,
                        Tenant_RefID = securityTicket.TenantID,
                        ProcurementOrder_Header_RefID = Parameter.ORD_PRC_ProcurementOrder_HeaderID,
                        Position_Quantity = p.Position_Quantity,
                        Position_ValuePerUnit = p.PricePerUnit,
                        Position_ValueTotal = p.PricePerUnit * Convert.ToDecimal(p.Position_Quantity),
                        Position_RequestedDateOfDelivery = DateTime.MinValue,
                        Position_Unit_RefID = unitID,
                        Position_OrdinalNumber = ++positionsCount
                    };
                    #endregion

                    createdPositionsIDs.Add(position.ORD_PRC_ProcurementOrder_PositionID);

                    newHeaderTotalValue += position.Position_ValueTotal;
                    #endregion
                }
                else
                {
                    #region Update ProcurementOrder Position

                    #region Get ProcurementOrder Position
                    position = ORM_ORD_PRC_ProcurementOrder_Position.Query.Search(Connection, Transaction
                        , new ORM_ORD_PRC_ProcurementOrder_Position.Query()
                        {
                            ORD_PRC_ProcurementOrder_PositionID = p.ORD_PRC_ProcurementOrder_PositionID,
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false
                        }).FirstOrDefault();
                    if (position.Equals(default(ORM_ORD_PRC_ProcurementOrder_Position)))
                    {
                        returnValue.Status = FR_Status.Error_Internal;
                        return returnValue;
                    }
                    #endregion

                    #region Update ProcurementOrder Position and Total Values
                    oldHeaderTotalValue += position.Position_ValueTotal;
                    position.Position_Quantity = p.Position_Quantity;
                    position.Position_ValueTotal = Convert.ToDecimal(p.Position_Quantity) * position.Position_ValuePerUnit;
                    newHeaderTotalValue += position.Position_ValueTotal;
                    position.IsDeleted = p.IsDeleted;
                    #endregion

                    #endregion
                }

                if (position.Save(Connection, Transaction).Status != FR_Status.Success)
                {
                    returnValue.Status = FR_Status.Error_Internal;
                    return returnValue;
                }
            }

            #region Update ProcurementOrder Header
            header.TotalValue_BeforeTax = (header.TotalValue_BeforeTax - oldHeaderTotalValue) + newHeaderTotalValue;
            if (header.Save(Connection, Transaction).Status != FR_Status.Success)
            {
                returnValue.Status = FR_Status.Error_Internal;
                return returnValue;
            }
            #endregion

            returnValue.Result = createdPositionsIDs.ToArray();
            returnValue.Status = FR_Status.Success;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guids Invoke(string ConnectionString,P_L3PO_SPOP_0331 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guids Invoke(DbConnection Connection,P_L3PO_SPOP_0331 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guids Invoke(DbConnection Connection, DbTransaction Transaction,P_L3PO_SPOP_0331 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guids Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3PO_SPOP_0331 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Guids functionReturn = new FR_Guids();
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

				throw new Exception("Exception occured in method cls_Save_ProcurementOrder_Positions",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3PO_SPOP_0331 for attribute P_L3PO_SPOP_0331
		[DataContract]
		public class P_L3PO_SPOP_0331 
		{
			[DataMember]
			public P_L3PO_SPOP_0331a[] Positions { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid ORD_PRC_ProcurementOrder_HeaderID { get; set; } 

		}
		#endregion
		#region SClass P_L3PO_SPOP_0331a for attribute Positions
		[DataContract]
		public class P_L3PO_SPOP_0331a 
		{
			//Standard type parameters
			[DataMember]
			public Guid ORD_PRC_ProcurementOrder_PositionID { get; set; } 
			[DataMember]
			public Guid ProductID { get; set; } 
			[DataMember]
			public Double Position_Quantity { get; set; } 
			[DataMember]
			public decimal PricePerUnit { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guids cls_Save_ProcurementOrder_Positions(,P_L3PO_SPOP_0331 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guids invocationResult = cls_Save_ProcurementOrder_Positions.Invoke(connectionString,P_L3PO_SPOP_0331 Parameter,securityTicket);
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
var parameter = new CL3_APOProcurement_ProcurementOrder.Complex.Manipulation.P_L3PO_SPOP_0331();
parameter.Positions = ...;

parameter.ORD_PRC_ProcurementOrder_HeaderID = ...;

*/
