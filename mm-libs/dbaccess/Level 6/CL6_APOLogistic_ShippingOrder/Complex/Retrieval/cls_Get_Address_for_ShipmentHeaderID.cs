/* 
 * Generated on 7/30/2014 11:02:37 AM
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
using CL1_CMN;
using CL1_LOG_SHP;
using CSV2Core.Core;
using CSV2Core.SessionSecurity;
using CSV2Core_MySQL.Dictionaries.MultiTable;
using System.Runtime.Serialization;

namespace CL6_APOLogistic_ShippingOrder.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Address_for_ShipmentHeaderID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Address_for_ShipmentHeaderID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6SO_GAfSHI_1435 Execute(DbConnection Connection,DbTransaction Transaction,P_L6SO_GAfSHI_1435 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_L6SO_GAfSHI_1435();
            returnValue.Result = new L6SO_GAfSHI_1435();
			//Put your code here

		    var ShipmentHeader = ORM_LOG_SHP_Shipment_Header.Query.Search(Connection, Transaction,
		        new ORM_LOG_SHP_Shipment_Header.Query
		        {
                    Tenant_RefID = securityTicket.TenantID,
                    LOG_SHP_Shipment_HeaderID = Parameter.ShipmentHeaderID,
                    IsDeleted = false
		        }).SingleOrDefault();

		    Guid saUCD = Guid.Empty;

            if (ShipmentHeader != null) saUCD = ShipmentHeader.Shippipng_AddressUCD_RefID;

		    if (saUCD != Guid.Empty)
		    {
		        var Universal_Contact_Details = ORM_CMN_UniversalContactDetail.Query.Search(Connection, Transaction,
		            new ORM_CMN_UniversalContactDetail.Query
		            {
		                Tenant_RefID = securityTicket.TenantID,
		                CMN_UniversalContactDetailID = saUCD,
		                IsDeleted = false,
                        
		            }).SingleOrDefault();


		        if (Universal_Contact_Details != null)
		        {
		            returnValue.Result.Street = Universal_Contact_Details.Street_Name;
		            returnValue.Result.StreetNumber = Universal_Contact_Details.Street_Number;
		            returnValue.Result.PLZ = Universal_Contact_Details.ZIP;
		            returnValue.Result.City = Universal_Contact_Details.Town;
		        }
		    }
		    else
		    {
		        returnValue.Result = null;

		    }

		    return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6SO_GAfSHI_1435 Invoke(string ConnectionString,P_L6SO_GAfSHI_1435 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6SO_GAfSHI_1435 Invoke(DbConnection Connection,P_L6SO_GAfSHI_1435 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6SO_GAfSHI_1435 Invoke(DbConnection Connection, DbTransaction Transaction,P_L6SO_GAfSHI_1435 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6SO_GAfSHI_1435 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6SO_GAfSHI_1435 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6SO_GAfSHI_1435 functionReturn = new FR_L6SO_GAfSHI_1435();
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

				throw new Exception("Exception occured in method cls_Get_Address_for_ShipmentHeaderID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6SO_GAfSHI_1435 : FR_Base
	{
		public L6SO_GAfSHI_1435 Result	{ get; set; }

		public FR_L6SO_GAfSHI_1435() : base() {}

		public FR_L6SO_GAfSHI_1435(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6SO_GAfSHI_1435 for attribute P_L6SO_GAfSHI_1435
		[DataContract]
		public class P_L6SO_GAfSHI_1435 
		{
			//Standard type parameters
			[DataMember]
			public Guid ShipmentHeaderID { get; set; } 

		}
		#endregion
		#region SClass L6SO_GAfSHI_1435 for attribute L6SO_GAfSHI_1435
		[DataContract]
		public class L6SO_GAfSHI_1435 
		{
			//Standard type parameters
			[DataMember]
			public string Street { get; set; } 
			[DataMember]
			public string StreetNumber { get; set; } 
			[DataMember]
			public string PLZ { get; set; } 
			[DataMember]
			public string City { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6SO_GAfSHI_1435 cls_Get_Address_for_ShipmentHeaderID(,P_L6SO_GAfSHI_1435 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6SO_GAfSHI_1435 invocationResult = cls_Get_Address_for_ShipmentHeaderID.Invoke(connectionString,P_L6SO_GAfSHI_1435 Parameter,securityTicket);
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
var parameter = new CL6_APOLogistic_ShippingOrder.Complex.Retrieval.P_L6SO_GAfSHI_1435();
parameter.ShipmentHeaderID = ...;

*/
