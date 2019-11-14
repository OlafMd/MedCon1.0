/* 
 * Generated on 7/2/2013 9:19:16 AM
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
using CL1_RES_STR;
using CL1_RES_ACT;

namespace CL5_KPRS_Actions.Atomic.Manipulation
{
	[DataContract]
	public class cls_Delete_Action
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Base Execute(DbConnection Connection,DbTransaction Transaction,P_L5AT_DA_1528 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Base();

			//Put your code here


            ORM_RES_ACT_Action.Query query = new ORM_RES_ACT_Action.Query();
            query.RES_ACT_ActionID = Parameter.RES_ACT_ActionID;
            ORM_RES_ACT_Action.Query.SoftDelete(Connection, Transaction, query);


            ORM_RES_STR_OutdoorFacility_Property_AvailableAction.Query query1 = new ORM_RES_STR_OutdoorFacility_Property_AvailableAction.Query();
            query1.RES_ACT_Action_RefID = Parameter.RES_ACT_ActionID;
            ORM_RES_STR_OutdoorFacility_Property_AvailableAction.Query.SoftDelete(Connection, Transaction, query1);

            ORM_RES_STR_Facade_Property_AvailableAction.Query query2 = new ORM_RES_STR_Facade_Property_AvailableAction.Query();
            query2.RES_ACT_Action_RefID = Parameter.RES_ACT_ActionID;
            ORM_RES_STR_Facade_Property_AvailableAction.Query.SoftDelete(Connection, Transaction, query2);

            ORM_RES_STR_Roof_Property_AvailableAction.Query query3 = new ORM_RES_STR_Roof_Property_AvailableAction.Query();
            query3.RES_ACT_Action_RefID = Parameter.RES_ACT_ActionID;
            ORM_RES_STR_Roof_Property_AvailableAction.Query.SoftDelete(Connection, Transaction, query3);

            ORM_RES_STR_Attic_Property_AvailableAction.Query query4 = new ORM_RES_STR_Attic_Property_AvailableAction.Query();
            query4.RES_ACT_Action_RefID = Parameter.RES_ACT_ActionID;
            ORM_RES_STR_Attic_Property_AvailableAction.Query.SoftDelete(Connection, Transaction, query4);

            ORM_RES_STR_Staircase_Property_AvailableAction.Query query5 = new ORM_RES_STR_Staircase_Property_AvailableAction.Query();
            query5.RES_ACT_Action_RefID = Parameter.RES_ACT_ActionID;
            ORM_RES_STR_Staircase_Property_AvailableAction.Query.SoftDelete(Connection, Transaction, query5);

            ORM_RES_STR_Basement_Property_AvailableAction.Query query6 = new ORM_RES_STR_Basement_Property_AvailableAction.Query();
            query6.RES_ACT_Action_RefID = Parameter.RES_ACT_ActionID;
            ORM_RES_STR_Basement_Property_AvailableAction.Query.SoftDelete(Connection, Transaction, query6);

            ORM_RES_STR_HVACR_Property_AvailableAction.Query query7 = new ORM_RES_STR_HVACR_Property_AvailableAction.Query();
            query7.RES_ACT_Action_RefID = Parameter.RES_ACT_ActionID;
            ORM_RES_STR_HVACR_Property_AvailableAction.Query.SoftDelete(Connection, Transaction, query7);

            ORM_RES_STR_Apartment_Property_AvailableAction.Query query8 = new ORM_RES_STR_Apartment_Property_AvailableAction.Query();
            query8.RES_ACT_Action_RefID = Parameter.RES_ACT_ActionID;
            ORM_RES_STR_Apartment_Property_AvailableAction.Query.SoftDelete(Connection, Transaction, query8);

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Base Invoke(string ConnectionString,P_L5AT_DA_1528 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection,P_L5AT_DA_1528 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AT_DA_1528 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AT_DA_1528 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Base functionReturn = new FR_Base();
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
		#region SClass P_L5AT_DA_1528 for attribute P_L5AT_DA_1528
		[DataContract]
		public class P_L5AT_DA_1528 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_ACT_ActionID { get; set; } 
			[DataMember]
			public Guid ActionType_RefID { get; set; } 
			[DataMember]
			public Guid RES_ACT_Action_VersionID { get; set; } 
			[DataMember]
			public Dict Action_Name_DictID { get; set; } 
			[DataMember]
			public Dict Action_Description_DictID { get; set; } 
			[DataMember]
			public int Action_Version { get; set; } 
			[DataMember]
			public Guid Default_PricePerUnit_RefID { get; set; } 
			[DataMember]
			public Guid Default_Unit_RefID { get; set; } 
			[DataMember]
			public double Default_UnitAmount { get; set; } 

		}
		#endregion

	#endregion
}
