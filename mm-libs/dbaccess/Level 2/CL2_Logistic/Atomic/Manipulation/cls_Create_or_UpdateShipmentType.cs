/* 
 * Generated on 2/15/2015 2:09:26 PM
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
using CL3_Language.Complex.Retrieval;
using CL1_LOG_SHP;
using CL1_CMN;

namespace CL2_Logistic.Atomic.Manipulation
{
	/// <summary>
    /// Create_or_UpdateShipmentType
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Create_or_UpdateShipmentType.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Create_or_UpdateShipmentType
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L2L_CoUST_1327 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here


            var defaultLanguage = cls_Get_Default_Language_For_Tenant.Invoke(Connection, Transaction, securityTicket).Result.DefaultLanguage.CMN_LanguageID;

            var shipmentTypeID = Parameter.ShipmentTypeID;

            if (shipmentTypeID == Guid.Empty)
            {
                returnValue.Status = FR_Status.Error_Internal;
                returnValue.ErrorMessage = "ShipmentTypeID cannot be Guid empty!";
                return returnValue;
            }

            ORM_LOG_SHP_Shipment_Type.Query orm_shipmentTypeQuery = new ORM_LOG_SHP_Shipment_Type.Query();
            orm_shipmentTypeQuery.LOG_SHP_Shipment_TypeID = shipmentTypeID;
            orm_shipmentTypeQuery.Tenant_RefID = securityTicket.TenantID;
            orm_shipmentTypeQuery.IsDeleted = false;

            var exists = ORM_LOG_SHP_Shipment_Type.Query.Exists(Connection, Transaction, orm_shipmentTypeQuery);

            if (exists)  //UPDATE
            {
                ORM_LOG_SHP_Shipment_Type orm_shipmentType = new ORM_LOG_SHP_Shipment_Type();
                orm_shipmentType.Load(Connection, Transaction, shipmentTypeID);

                orm_shipmentType.ShipmentType_Name.UpdateEntry(defaultLanguage, Parameter.Name);
                orm_shipmentType.ShipmentType_Description.UpdateEntry(defaultLanguage, Parameter.Description);
                orm_shipmentType.Creation_Timestamp = DateTime.Now;

                orm_shipmentType.Save(Connection, Transaction);

                returnValue.Result = orm_shipmentType.LOG_SHP_Shipment_TypeID;
            }
            else // CREATE
            {

                ORM_LOG_SHP_Shipment_Type orm_shipmentType = new ORM_LOG_SHP_Shipment_Type();
                orm_shipmentType.LOG_SHP_Shipment_TypeID = shipmentTypeID;
                orm_shipmentType.ShipmentType_Name = new Dict() { DictionaryID = Guid.NewGuid() };
                orm_shipmentType.ShipmentType_Description = new Dict() { DictionaryID = Guid.NewGuid() };
                orm_shipmentType.ShipmentType_Name.UpdateEntry(defaultLanguage, Parameter.Name);
                orm_shipmentType.ShipmentType_Description.UpdateEntry(defaultLanguage, Parameter.Description);
                orm_shipmentType.Tenant_RefID = securityTicket.TenantID;
                orm_shipmentType.Creation_Timestamp = DateTime.Now;
                orm_shipmentType.Save(Connection, Transaction);

                returnValue.Result = orm_shipmentType.LOG_SHP_Shipment_TypeID;
            }

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L2L_CoUST_1327 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L2L_CoUST_1327 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L2L_CoUST_1327 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2L_CoUST_1327 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Create_or_UpdateShipmentType",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L2L_CoUST_1327 for attribute P_L2L_CoUST_1327
		[DataContract]
		public class P_L2L_CoUST_1327 
		{
			//Standard type parameters
			[DataMember]
			public Guid ShipmentTypeID { get; set; } 
			[DataMember]
			public string Name { get; set; } 
			[DataMember]
			public string Description { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Create_or_UpdateShipmentType(,P_L2L_CoUST_1327 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Create_or_UpdateShipmentType.Invoke(connectionString,P_L2L_CoUST_1327 Parameter,securityTicket);
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
var parameter = new CL2_Logistic.Atomic.Manipulation.P_L2L_CoUST_1327();
parameter.ShipmentTypeID = ...;
parameter.Name = ...;
parameter.Description = ...;

*/
