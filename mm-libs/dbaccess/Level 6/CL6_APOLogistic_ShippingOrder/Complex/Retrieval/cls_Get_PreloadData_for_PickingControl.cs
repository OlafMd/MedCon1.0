/* 
 * Generated on 4/17/2014 3:35:58 PM
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
using CL6_APOLogistic_ShippingOrder.Atomic.Retrieval;
using CL1_ORD_CUO;

namespace CL6_APOLogistic_ShippingOrder.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_PreloadData_for_PickingControl.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_PreloadData_for_PickingControl
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6SO_GPDfPC_1049 Execute(DbConnection Connection,DbTransaction Transaction,P_L6SO_GPDfPC_1049 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_L6SO_GPDfPC_1049();
            //Put your code here

            returnValue.Result = new L6SO_GPDfPC_1049();
            returnValue.Result.BasicInfo = new L5SO_GSHfH_1040();

            //positions
            returnValue.Result.Positions = cls_Get_AllShippingPositions_for_PickingControlFlags_and_ShippingHeaderID.
                Invoke(Connection, Transaction, new P_L6SO_GASPfPCFaSH_1202 { ShippmentHeaderID = Parameter.ShipmentHeaderID }, securityTicket).Result;
           
            //basic info
            returnValue.Result.BasicInfo = cls_Get_ShippingHeader_for_HeaderID.
                Invoke(Connection, Transaction, new P_L5SO_GSHfH_1040 { HeaderID = Parameter.ShipmentHeaderID }, securityTicket).Result;
            
            //organizationunitid
            ORM_ORD_CUO_CustomerOrder_Position_2_ShipmentPosition assignment = new ORM_ORD_CUO_CustomerOrder_Position_2_ShipmentPosition();
            ORM_ORD_CUO_CustomerOrder_Position_2_ShipmentPosition.Query assignmentQuery = new ORM_ORD_CUO_CustomerOrder_Position_2_ShipmentPosition.Query();
            assignmentQuery.LOG_SHP_Shipment_Position_RefID = returnValue.Result.Positions.First().LOG_SHP_Shipment_PositionID;
            assignmentQuery.Tenant_RefID = securityTicket.TenantID;
            assignmentQuery.IsDeleted = false;

            assignment = ORM_ORD_CUO_CustomerOrder_Position_2_ShipmentPosition.Query.Search(Connection, Transaction, assignmentQuery).Single();

            returnValue.Result.OrganizationUnitID = assignment.CMN_BPT_CTM_OrganizationalUnit_RefID;



            return returnValue;

            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6SO_GPDfPC_1049 Invoke(string ConnectionString,P_L6SO_GPDfPC_1049 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6SO_GPDfPC_1049 Invoke(DbConnection Connection,P_L6SO_GPDfPC_1049 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6SO_GPDfPC_1049 Invoke(DbConnection Connection, DbTransaction Transaction,P_L6SO_GPDfPC_1049 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6SO_GPDfPC_1049 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6SO_GPDfPC_1049 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6SO_GPDfPC_1049 functionReturn = new FR_L6SO_GPDfPC_1049();
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

	#region Custom Return Type
	[Serializable]
	public class FR_L6SO_GPDfPC_1049 : FR_Base
	{
		public L6SO_GPDfPC_1049 Result	{ get; set; }

		public FR_L6SO_GPDfPC_1049() : base() {}

		public FR_L6SO_GPDfPC_1049(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6SO_GPDfPC_1049 for attribute P_L6SO_GPDfPC_1049
		[DataContract]
		public class P_L6SO_GPDfPC_1049 
		{
			//Standard type parameters
			[DataMember]
			public Guid ShipmentHeaderID { get; set; } 

		}
		#endregion
		#region SClass L6SO_GPDfPC_1049 for attribute L6SO_GPDfPC_1049
		[DataContract]
		public class L6SO_GPDfPC_1049 
		{
			//Standard type parameters
			[DataMember]
			public L6SO_GASPfPCFaSH_1202[] Positions { get; set; } 
			[DataMember]
			public L5SO_GSHfH_1040 BasicInfo { get; set; } 
			[DataMember]
			public Guid OrganizationUnitID { get; set; } 

		}
		#endregion

	#endregion
}
