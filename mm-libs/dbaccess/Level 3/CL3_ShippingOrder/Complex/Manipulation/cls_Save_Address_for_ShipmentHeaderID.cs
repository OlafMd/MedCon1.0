/* 
 * Generated on 7/31/2014 11:08:22 AM
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
using CSV2Core_MySQL.Dictionaries.MultiTable;
using System.Runtime.Serialization;

namespace CL3_ShippingOrder.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Address_for_ShipmentHeaderID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Address_for_ShipmentHeaderID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L3SO_SA_f_SHI_1535 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here
		    bool saveResult = false;
		    var Universal_C_Details = new ORM_CMN_UniversalContactDetail();
            Universal_C_Details.CMN_UniversalContactDetailID = Guid.NewGuid();
		    Universal_C_Details.Street_Name = Parameter.StreetName;
		    Universal_C_Details.Street_Number = Parameter.StreetNumber;
		    Universal_C_Details.Town = Parameter.Town;
		    Universal_C_Details.ZIP = Parameter.ZIP;
		    Universal_C_Details.IsCompany = Parameter.IsCompany;
		    Universal_C_Details.Tenant_RefID = securityTicket.TenantID;
		    Universal_C_Details.IsDeleted = false;
            
            

		    Universal_C_Details.Save(Connection, Transaction);

		    var SHeader = ORM_LOG_SHP_Shipment_Header.Query.Search(Connection, Transaction,
		        new ORM_LOG_SHP_Shipment_Header.Query
		        {
                    Tenant_RefID = securityTicket.TenantID,
                    LOG_SHP_Shipment_HeaderID = Parameter.LOG_SHP_Shipment_HeaderID
		        }).SingleOrDefault();


		    if (SHeader != null)
		    {
		        SHeader.Shippipng_AddressUCD_RefID = Universal_C_Details.CMN_UniversalContactDetailID;
		        SHeader.Save(Connection, Transaction);
		    }

		    returnValue.Result = Universal_C_Details.CMN_UniversalContactDetailID;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L3SO_SA_f_SHI_1535 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L3SO_SA_f_SHI_1535 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L3SO_SA_f_SHI_1535 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3SO_SA_f_SHI_1535 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Address_for_ShipmentHeaderID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3SO_SA_f_SHI_1535 for attribute P_L3SO_SA_f_SHI_1535
		[DataContract]
		public class P_L3SO_SA_f_SHI_1535 
		{
			//Standard type parameters
			[DataMember]
			public Guid LOG_SHP_Shipment_HeaderID { get; set; } 
			[DataMember]
			public string StreetName { get; set; } 
			[DataMember]
			public string StreetNumber { get; set; } 
			[DataMember]
			public string Town { get; set; } 
			[DataMember]
			public string ZIP { get; set; } 
			[DataMember]
			public bool IsCompany { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Address_for_ShipmentHeaderID(,P_L3SO_SA_f_SHI_1535 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Address_for_ShipmentHeaderID.Invoke(connectionString,P_L3SO_SA_f_SHI_1535 Parameter,securityTicket);
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
var parameter = new CL3_ShippingOrder.Complex.Manipulation.P_L3SO_SA_f_SHI_1535();
parameter.LOG_SHP_Shipment_HeaderID = ...;
parameter.StreetName = ...;
parameter.StreetNumber = ...;
parameter.Town = ...;
parameter.ZIP = ...;
parameter.IsCompany = ...;

*/
