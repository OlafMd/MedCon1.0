/* 
 * Generated on 01.11.2014 19:16:25
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
using CL5_APOLogistic_ShippingOrder.Atomic.Retrieval;
using CL2_Shipment.Atomic.Retrieval;
using CL1_LOG_SHP;

namespace CL5_APOLogistic_Storage.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ShippmentHeaders_with_BasicInfo_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ShippmentHeaders_with_BasicInfo_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5SO_GSHwBIfT_1533_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5SO_GSHwBIfT_1533 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5SO_GSHwBIfT_1533_Array();


            #region Retrieve Headers 

            var param = new P_L5SO_GSOHfTID_1650()
            {
                IsPartiallyReadyForPicking = Parameter.IsPartiallyReadyForPicking,
                IsReadyForPicking = Parameter.IsReadyForPicking,
                HasPickingStarted = Parameter.HasPickingStarted,
                HasPickingFinished = Parameter.HasPickingFinished,
                IsManuallyCleared_ForPicking = Parameter.IsManuallyCleared_ForPicking,
                IsBilled = Parameter.IsBilled,
                IsShipped = Parameter.IsShipped
            };

            var headers = cls_Get_ShippingOrderHeaders_for_TenantID.Invoke(Connection, Transaction, param, securityTicket).Result;

            var orgUnits = cls_Get_Shipment_OrganizationalUnits_for_TenantID.Invoke(Connection, Transaction, securityTicket).Result;

            #endregion

            var result = new List<L5SO_GSHwBIfT_1533>();

            foreach (var header in headers) {

                var notesCount = ORM_LOG_SHP_Shipment_Note.Query.Search(Connection, Transaction,
                    new ORM_LOG_SHP_Shipment_Note.Query()
                    {
                        Shipment_Header_RefID = header.LOG_SHP_Shipment_HeaderID,
                        IsDeleted = false
                    }).Count();

                var orgUnit = orgUnits.Where(i => i.LOG_SHP_Shipment_Header_RefID == header.LOG_SHP_Shipment_HeaderID).SingleOrDefault();

                if (orgUnit == null)
                    orgUnit = new L5SO_GSOUfT_1607();

                #region Get Shipment Positions

                List<Guid> ProductsInHeader = new List<Guid>();

                P_L2SH_GSPfToSH_1334 positionsGetParam = new P_L2SH_GSPfToSH_1334();
                positionsGetParam.ShipmentHeaderID = header.LOG_SHP_Shipment_HeaderID;
                var shipmentPositions = cls_Get_ShipmentPositions_for_Tenant_or_ShipmentHeaderID.Invoke(Connection, Transaction, positionsGetParam, securityTicket).Result.ToList();

                ProductsInHeader = shipmentPositions.Select(x => x.CMN_PRO_Product_RefID).Distinct().ToList();

                #endregion
                

                var item = new L5SO_GSHwBIfT_1533()
                {
                    LOG_SHP_Shipment_HeaderID = header.LOG_SHP_Shipment_HeaderID,
                    ORD_CUO_CustomerOrder_HeaderID = header.ORD_CUO_CustomerOrder_HeaderID,
                    ShipmentHeader_Number = header.ShipmentHeader_Number,
                    CustomerOrder_Number = header.CustomerOrder_Number,
                    CustomerOrderCreationDate = header.CustomerOrderCreationDate,
                    ShippingCreationDate = header.ShippingCreationDate,
                    IsPartiallyReadyForPicking = header.IsPartiallyReadyForPicking,
                    IsReadyForPicking = header.IsReadyForPicking,
                    HasPickingStarted = header.HasPickingStarted,
                    HasPickingFinished = header.HasPickingFinished,
                    IsManuallyCleared_ForPicking = header.IsManuallyCleared_ForPicking,
                    IsBilled = header.IsBilled,
                    IsShipped = header.IsShipped,
                    CompanyName_Line1 = header.CompanyName_Line1,
                    NotesCount = notesCount,
                    CMN_BPT_CTM_OrganizationalUnitID = orgUnit.CMN_BPT_CTM_OrganizationalUnitID,
                    InternalOrganizationalUnitNumber = orgUnit.InternalOrganizationalUnitNumber,
                    InternalOrganizationalUnitSimpleName = orgUnit.InternalOrganizationalUnitSimpleName,
                    ShipmentHeaderAddress = header.Shippipng_AddressUCD_RefID,
                    AllProductIDsInHeader = ProductsInHeader.ToArray()
                };

                result.Add(item);
            }

            returnValue.Result = result.ToArray();

            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5SO_GSHwBIfT_1533_Array Invoke(string ConnectionString,P_L5SO_GSHwBIfT_1533 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5SO_GSHwBIfT_1533_Array Invoke(DbConnection Connection,P_L5SO_GSHwBIfT_1533 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5SO_GSHwBIfT_1533_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5SO_GSHwBIfT_1533 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5SO_GSHwBIfT_1533_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5SO_GSHwBIfT_1533 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5SO_GSHwBIfT_1533_Array functionReturn = new FR_L5SO_GSHwBIfT_1533_Array();
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

				throw new Exception("Exception occured in method cls_Get_ShippmentHeaders_with_BasicInfo_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5SO_GSHwBIfT_1533_Array : FR_Base
	{
		public L5SO_GSHwBIfT_1533[] Result	{ get; set; } 
		public FR_L5SO_GSHwBIfT_1533_Array() : base() {}

		public FR_L5SO_GSHwBIfT_1533_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5SO_GSHwBIfT_1533 for attribute P_L5SO_GSHwBIfT_1533
		[DataContract]
		public class P_L5SO_GSHwBIfT_1533 
		{
			//Standard type parameters
			[DataMember]
			public Boolean? IsPartiallyReadyForPicking { get; set; } 
			[DataMember]
			public Boolean? IsReadyForPicking { get; set; } 
			[DataMember]
			public Boolean? HasPickingStarted { get; set; } 
			[DataMember]
			public Boolean? HasPickingFinished { get; set; } 
			[DataMember]
			public Boolean? IsManuallyCleared_ForPicking { get; set; } 
			[DataMember]
			public Boolean? IsBilled { get; set; } 
			[DataMember]
			public Boolean? IsShipped { get; set; } 

		}
		#endregion
		#region SClass L5SO_GSHwBIfT_1533 for attribute L5SO_GSHwBIfT_1533
		[DataContract]
		public class L5SO_GSHwBIfT_1533 
		{
			//Standard type parameters
			[DataMember]
			public Guid LOG_SHP_Shipment_HeaderID { get; set; } 
			[DataMember]
			public Guid ORD_CUO_CustomerOrder_HeaderID { get; set; } 
			[DataMember]
			public String ShipmentHeader_Number { get; set; } 
			[DataMember]
			public String CustomerOrder_Number { get; set; } 
			[DataMember]
			public DateTime CustomerOrderCreationDate { get; set; } 
			[DataMember]
			public DateTime ShippingCreationDate { get; set; } 
			[DataMember]
			public Boolean IsPartiallyReadyForPicking { get; set; } 
			[DataMember]
			public Boolean IsReadyForPicking { get; set; } 
			[DataMember]
			public Boolean HasPickingStarted { get; set; } 
			[DataMember]
			public Boolean HasPickingFinished { get; set; } 
			[DataMember]
			public Boolean IsManuallyCleared_ForPicking { get; set; } 
			[DataMember]
			public Boolean IsBilled { get; set; } 
			[DataMember]
			public Boolean IsShipped { get; set; } 
			[DataMember]
			public String CompanyName_Line1 { get; set; } 
			[DataMember]
			public int NotesCount { get; set; } 
			[DataMember]
			public Guid CMN_BPT_CTM_OrganizationalUnitID { get; set; } 
			[DataMember]
			public String InternalOrganizationalUnitNumber { get; set; } 
			[DataMember]
			public String InternalOrganizationalUnitSimpleName { get; set; } 
			[DataMember]
			public Guid ShipmentHeaderAddress { get; set; } 
			[DataMember]
			public Guid[] AllProductIDsInHeader { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5SO_GSHwBIfT_1533_Array cls_Get_ShippmentHeaders_with_BasicInfo_for_TenantID(,P_L5SO_GSHwBIfT_1533 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5SO_GSHwBIfT_1533_Array invocationResult = cls_Get_ShippmentHeaders_with_BasicInfo_for_TenantID.Invoke(connectionString,P_L5SO_GSHwBIfT_1533 Parameter,securityTicket);
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
var parameter = new CL5_APOLogistic_Storage.Complex.Retrieval.P_L5SO_GSHwBIfT_1533();
parameter.IsPartiallyReadyForPicking = ...;
parameter.IsReadyForPicking = ...;
parameter.HasPickingStarted = ...;
parameter.HasPickingFinished = ...;
parameter.IsManuallyCleared_ForPicking = ...;
parameter.IsBilled = ...;
parameter.IsShipped = ...;

*/
