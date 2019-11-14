/* 
 * Generated on 7/8/2013 11:16:20 AM
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
using CL1_ORD_CUO;
using Core_ClassLibrarySupport;
using CL1_HEC;
using CL6_Lucenits_Products.Atomic.Retrieval;
using Core_ClassLibrarySupport.Lucentis;

namespace CL6_Lucenits_Treatments.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Order_Header_and_Status.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Order_Header_and_Status
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L6TR_SOHaS1434 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
            //* Array TreatmentID and ArticleID are the sam lenght; Treatment with position i has article with the position i

            var count = 0;
            List<Orders> orderList = new List<Orders>();
            int ordinalNumber = 0;
            Guid headerID = Guid.Empty;

            for (int g = 0; g < Parameter.HEC_Patient_TreatmentID.Length; g++)
            {


                #region Save Order

                var status_query = new ORM_ORD_CUO_CustomerOrder_Status.Query();
                status_query.IsDeleted = false;
                status_query.Tenant_RefID = securityTicket.TenantID;
                status_query.GlobalPropertyMatchingID = STLD_ORD_CUO_CustomerOrder_Status.Ordered.ToString();
                var notOrderedstatus = ORM_ORD_CUO_CustomerOrder_Status.Query.Search(Connection, Transaction, status_query).First();


                // za ispraviti sto pre
                #region 
                var prod_param = new P_L6PD_GPaCOSfT_1120();
                prod_param.TreatmentID = Parameter.HEC_Patient_TreatmentID[g];
                var products = cls_Get_Products_and_CustomerOrderStatuses_for_TreatmentID.Invoke(Connection, Transaction, prod_param, securityTicket).Result;


                var notOrdered_Products = products.Where(i => i.CMN_PRO_ProductID == Guid.Empty);
                #endregion

                if (notOrdered_Products.Count() == 0)
                    return returnValue;

                #region Save Header and Status

                var header_query = new ORM_ORD_CUO_CustomerOrder_Header.Query();
                header_query.IsDeleted = false;
                header_query.Tenant_RefID = securityTicket.TenantID;
                var headers = ORM_ORD_CUO_CustomerOrder_Header.Query.Search(Connection, Transaction, header_query);




                if (headers != null)
                    count = headers.Count();

                String ordernumber = String.Empty;
                var orderFound = orderList.Where(c => c.TreatmentID == Parameter.HEC_Patient_TreatmentID[g]).FirstOrDefault();

                if (orderFound == null)
                {
                    ordernumber = "000000000000" + (count + 1).ToString();
                    ordernumber = ordernumber.Substring(ordernumber.Length - 12);



                    var header = new ORM_ORD_CUO_CustomerOrder_Header();
                    headerID = Guid.NewGuid();
                    header.ORD_CUO_CustomerOrder_HeaderID = headerID;
                    header.Current_CustomerOrderStatus_RefID = notOrderedstatus.ORD_CUO_CustomerOrder_StatusID;
                    header.CustomerOrder_Number = ordernumber;
                    header.CustomerOrder_Date = DateTime.Now;
                    header.Creation_Timestamp = DateTime.Now;
                    header.Tenant_RefID = securityTicket.TenantID;
                    header.Save(Connection, Transaction);

                    var history = new ORM_ORD_CUO_CustomerOrder_StatusHistory();
                    history.ORD_CUO_CustomerOrder_StatusHistoryID = Guid.NewGuid();
                    history.CustomerOrder_Header_RefID = header.ORD_CUO_CustomerOrder_HeaderID;
                    history.CustomerOrder_Status_RefID = notOrderedstatus.ORD_CUO_CustomerOrder_StatusID;
                    history.StatusHistoryComment = "";
                    history.Creation_Timestamp = DateTime.Now;
                    history.Tenant_RefID = securityTicket.TenantID;
                    history.Save(Connection, Transaction);


                    Orders ord = new Orders();
                    ord.TreatmentID = Parameter.HEC_Patient_TreatmentID[g];
                    ord.Ordernumber = ordernumber;
                    ord.OrdinalNumber = 0;
                    ord.headerID = headerID;
                    orderList.Add(ord);
                    ordinalNumber = 0;

                }
                else
                {
                    ordernumber = orderFound.Ordernumber;
                    ordinalNumber = orderFound.OrdinalNumber + 1;
                    headerID = orderFound.headerID;
                }
                #endregion




            
                var product = notOrdered_Products.Where(t => t.CMN_PRO_ProductID == Parameter.AtricleID[g]).FirstOrDefault();


                var position = new ORM_ORD_CUO_CustomerOrder_Position();
                position.ORD_CUO_CustomerOrder_PositionID = Guid.NewGuid();
                position.CustomerOrder_Header_RefID = headerID;
                position.Position_OrdinalNumber = ordinalNumber;
                position.Position_Quantity = product.Quantity;
                position.Position_ValuePerUnit = 1;
                position.Position_ValueTotal = (decimal)product.Quantity;
                position.CMN_PRO_Product_Variant_RefID = Guid.Empty;
                position.CMN_PRO_Product_RefID = product.CMN_PRO_ProductID;
                position.CMN_PRO_Product_Release_RefID = Guid.Empty;
                position.Position_RequestedDateOfDelivery = product.ExpectedDateOfDelivery;
                position.Creation_Timestamp = DateTime.Now;
                position.Tenant_RefID = securityTicket.TenantID;
                position.Save(Connection, Transaction);


                var item = new ORM_HEC_Patient_Treatment_RequiredProduct();
                item.Load(Connection, Transaction, product.HEC_Patient_Treatment_RequiredProductID);
                item.BoundTo_CustomerOrderPosition_RefID = position.ORD_CUO_CustomerOrder_PositionID;
                item.Save(Connection, Transaction);
               


            
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
		public static FR_Guid Invoke(string ConnectionString,P_L6TR_SOHaS1434 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L6TR_SOHaS1434 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L6TR_SOHaS1434 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6TR_SOHaS1434 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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
		#region SClass P_L6TR_SOHaS1434 for attribute P_L6TR_SOHaS1434
		[DataContract]
		public class P_L6TR_SOHaS1434 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] HEC_Patient_TreatmentID { get; set; } 
			[DataMember]
			public Guid[] AtricleID { get; set; } 

		}
		#endregion

        public class Orders
        {
            public Guid TreatmentID { get; set; }
            public String Ordernumber { get; set; }
            public int OrdinalNumber { get; set; }
            public Guid headerID { get; set; }
        }

	#endregion
}