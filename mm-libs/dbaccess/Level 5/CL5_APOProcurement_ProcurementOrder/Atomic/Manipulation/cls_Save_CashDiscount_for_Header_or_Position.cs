/* 
 * Generated on 5/8/2014 04:29:38
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
using CL1_ORD_PRC;
using CL2_DiscountType.Atomic.Retrieval;
using DLCore_DBCommons.Utils;
using DLCore_DBCommons.APODemand;

namespace CL5_APOProcurement_ProcurementOrder.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_CashDiscount_for_Header_or_Position.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_CashDiscount_for_Header_or_Position
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5PO_SCDfHoP_1117 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here

            List<Guid> positionIDs = new List<Guid>();

            //if parameter contains headerID, discounts for all positions of header will be created/edited. 

            if (Parameter.ProcurementOrderHeaderID != Guid.Empty)
            {
                //Find all header positions
                var procurementOrderPositions = ORM_ORD_PRC_ProcurementOrder_Position.Query.Search(Connection, Transaction
                , new ORM_ORD_PRC_ProcurementOrder_Position.Query()
                {
                    ProcurementOrder_Header_RefID = Parameter.ProcurementOrderHeaderID,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                });

                if (procurementOrderPositions != null && procurementOrderPositions.Count > 0)
                {
                    positionIDs.AddRange(procurementOrderPositions.Select(x => x.ORD_PRC_ProcurementOrder_PositionID).ToList());
                }
            }
            else if (Parameter.ProcurementOrderPositionIDList != null && Parameter.ProcurementOrderPositionIDList.Length > 0)
            {
                positionIDs.AddRange(Parameter.ProcurementOrderPositionIDList);
            }


            if (positionIDs.Count > 0)
            {
                var discountTypeParam = new P_L2DT_GDTfGPMIL_1546();
                discountTypeParam.GlobalPropertyMatchingID_List = new string[] 
                    {
                        EnumUtils.GetEnumDescription(EDiscountType.CashDiscount),                      
                    };
                var discountTypes = cls_Get_DiscountTypes_for_GlobalPropertyMatchingID_List.Invoke(Connection, Transaction, discountTypeParam, securityTicket).Result;

                if (discountTypes != null && discountTypes.Length > 0)
                {
                    var discountTypeID = discountTypes.First().ORD_PRC_DiscountTypeID;

                    foreach (var item in positionIDs)
                    {
                        var positionDiscount = ORM_ORD_PRC_ProcurementOrder_Position_Discount.Query.Search(Connection, Transaction,
                        new ORM_ORD_PRC_ProcurementOrder_Position_Discount.Query
                        {
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false,
                            ORD_PRC_ProcurementOrder_Position_RefID = item,
                            ORD_PRC_DiscountType_RefID = discountTypeID
                        });

                        if (positionDiscount != null && positionDiscount.Count > 0)
                        {
                            //update existing discount for position
                            positionDiscount.First().DiscountValue = Parameter.DiscountValue;
                            positionDiscount.First().Save(Connection, Transaction);
                        }
                        else
                        {
                            //create new discount for position
                            ORM_ORD_PRC_ProcurementOrder_Position_Discount newPosition = new ORM_ORD_PRC_ProcurementOrder_Position_Discount();
                            newPosition.IsDeleted = false;
                            newPosition.Tenant_RefID = securityTicket.TenantID;
                            newPosition.Creation_Timestamp = DateTime.Now;
                            newPosition.DiscountValue = Parameter.DiscountValue;
                            newPosition.ORD_PRC_ProcurementOrder_Position_DiscountID = Guid.NewGuid();
                            newPosition.ORD_PRC_DiscountType_RefID = discountTypeID;
                            newPosition.ORD_PRC_ProcurementOrder_Position_RefID = item;
                            newPosition.Save(Connection, Transaction);
                        }
                    }
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
		public static FR_Guid Invoke(string ConnectionString,P_L5PO_SCDfHoP_1117 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5PO_SCDfHoP_1117 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5PO_SCDfHoP_1117 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5PO_SCDfHoP_1117 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_CashDiscount_for_Header_or_Position",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5PO_SCDfHoP_1117 for attribute P_L5PO_SCDfHoP_1117
		[DataContract]
		public class P_L5PO_SCDfHoP_1117 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] ProcurementOrderPositionIDList { get; set; } 
			[DataMember]
			public Guid ProcurementOrderHeaderID { get; set; } 
			[DataMember]
			public double DiscountValue { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_CashDiscount_for_Header_or_Position(,P_L5PO_SCDfHoP_1117 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_CashDiscount_for_Header_or_Position.Invoke(connectionString,P_L5PO_SCDfHoP_1117 Parameter,securityTicket);
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
var parameter = new CL5_APOProcurement_ProcurementOrder.Atomic.Manipulation.P_L5PO_SCDfHoP_1117();
parameter.ProcurementOrderPositionIDList = ...;
parameter.ProcurementOrderHeaderID = ...;
parameter.DiscountValue = ...;

*/
