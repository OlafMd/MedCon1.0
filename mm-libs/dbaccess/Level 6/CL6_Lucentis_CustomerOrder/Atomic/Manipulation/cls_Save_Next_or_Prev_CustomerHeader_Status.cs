/* 
 * Generated on 7/8/2013 3:16:59 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Linq;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;
using CL1_ORD_CUO;
using Core_ClassLibrarySupport.Lucentis;


namespace CL6_Lucentis_CustomerOrder.Atomic.Manipulation
{
	[Serializable]
	public class cls_Save_Next_or_Prev_CustomerHeader_Status
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L6CO_SNoPCHS_1833 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            foreach (var headerId in Parameter.CustomerOrder_HeaderID_List)
            {
            
             #region Save Order

            var status_query = new ORM_ORD_CUO_CustomerOrder_Status.Query();
            status_query.IsDeleted = false;
            status_query.Tenant_RefID = securityTicket.TenantID;
            var allStatuses = ORM_ORD_CUO_CustomerOrder_Status.Query.Search(Connection, Transaction, status_query).OrderBy(i => i.Status_Code);

            #region Save Header and Status
            
            var header = new ORM_ORD_CUO_CustomerOrder_Header();
            header.Load(Connection, Transaction, headerId);

            var currentStatusCode = allStatuses.Where(i => i.ORD_CUO_CustomerOrder_StatusID == header.Current_CustomerOrderStatus_RefID).First().Status_Code;
            string currentStatusGlobalID = allStatuses.Where(i => i.ORD_CUO_CustomerOrder_StatusID == header.Current_CustomerOrderStatus_RefID).First().GlobalPropertyMatchingID;

            ORM_ORD_CUO_CustomerOrder_Status nextStatus = null;
           // List<ORM_ORD_CUO_CustomerOrder_Status> nextStatuses = new List<ORM_ORD_CUO_CustomerOrder_Status>();

            switch (currentStatusGlobalID.ToUpper())
            {
                
                case "4621085A-E747-4645-AA61-FA4CE1A8E646":
                    nextStatus = allStatuses.Where(i => i.GlobalPropertyMatchingID == STLD_ORD_CUO_CustomerOrder_Status.OrderConfirmed.ToString()).First();
                    break;
                case "1712AF34-6E74-4A3D-9E97-5A90A88692B6":
                    if (Parameter.MoveToNext)
                    {
                        nextStatus = allStatuses.Where(i => i.GlobalPropertyMatchingID == STLD_ORD_CUO_CustomerOrder_Status.Shipped.ToString()).First();
                    }
                    else
                    {
                        nextStatus = allStatuses.Where(i => i.GlobalPropertyMatchingID == STLD_ORD_CUO_CustomerOrder_Status.Ordered.ToString()).First();
                    }
                    break;
                case "D2FDEBAE-865D-4DB2-B15F-7396C6CCBD8E":
                    if (Parameter.MoveToNext)
                    {
                        nextStatus = allStatuses.Where(i => i.GlobalPropertyMatchingID == STLD_ORD_CUO_CustomerOrder_Status.Billed.ToString()).First();
                    }
                    else
                    {
                        nextStatus = allStatuses.Where(i => i.GlobalPropertyMatchingID == STLD_ORD_CUO_CustomerOrder_Status.OrderConfirmed.ToString()).First();
                    }
                    break;
                case "ABF393AC-96CA-4154-B21E-57B20119C291":

                    nextStatus = allStatuses.Where(i => i.GlobalPropertyMatchingID == STLD_ORD_CUO_CustomerOrder_Status.Shipped.ToString()).First();
                    
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }

            header.Current_CustomerOrderStatus_RefID = nextStatus.ORD_CUO_CustomerOrder_StatusID;
            header.Save(Connection, Transaction);

            var history = new ORM_ORD_CUO_CustomerOrder_StatusHistory();
            history.ORD_CUO_CustomerOrder_StatusHistoryID = Guid.NewGuid();
            history.CustomerOrder_Header_RefID = header.ORD_CUO_CustomerOrder_HeaderID;
            history.CustomerOrder_Status_RefID = nextStatus.ORD_CUO_CustomerOrder_StatusID;
            history.StatusHistoryComment = "";
            history.Creation_Timestamp = DateTime.Now;
            history.Tenant_RefID = securityTicket.TenantID;
            history.Save(Connection, Transaction);

            #endregion

  
            

            #endregion
            
            
            }

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L6CO_SNoPCHS_1833 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L6CO_SNoPCHS_1833 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L6CO_SNoPCHS_1833 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6CO_SNoPCHS_1833 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw ex;
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L6CO_SNoPCHS_1833 for attribute P_L6CO_SNoPCHS_1833
		[Serializable]
		public class P_L6CO_SNoPCHS_1833 
		{
			//Standard type parameters
			public Guid[] CustomerOrder_HeaderID_List; 
			public bool MoveToNext; 
			public bool MoveToPrev; 

		}
		#endregion

	#endregion
}
