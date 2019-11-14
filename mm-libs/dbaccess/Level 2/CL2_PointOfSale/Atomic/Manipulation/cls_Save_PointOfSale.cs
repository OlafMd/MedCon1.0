/* 
 * Generated on 12/18/2014 3:59:13 PM
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
using CSV2Core_MySQL.Dictionaries.MultiTable;
using System.Runtime.Serialization;
using CL1_CMN_SLS;
using CSV2Core.Core;

namespace CL2_PointOfSale.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_PointOfSale.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_PointOfSale
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L2SPUS_1645 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			
            var returnValue = new FR_Guid();
            //Put your code here

            bool createNew = false;
            if (Parameter.CMN_SLS_PointOfSaleID == Guid.Empty)
            {
                createNew = true;
            }

            ORM_CMN_SLS_PointOfSale item = null;

            if (createNew)
            {
                item = new ORM_CMN_SLS_PointOfSale();
                item.CMN_SLS_PointOfSaleID = Guid.NewGuid();
                item.Tenant_RefID = securityTicket.TenantID;
                item.Creation_Timestamp = DateTime.Now;
            }
            else
            {

                item = ORM_CMN_SLS_PointOfSale.Query.Search(Connection, Transaction, new ORM_CMN_SLS_PointOfSale.Query
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID,
                    CMN_SLS_PointOfSaleID = Parameter.CMN_SLS_PointOfSaleID
                }).FirstOrDefault();

                if (item == null)
                {
                    returnValue.Status = FR_Status.Error_Internal;
                    returnValue.ErrorMessage = String.Format("No pick-up station with id = {1} found.", Parameter.CMN_SLS_PointOfSaleID.ToString());
                    return returnValue;
                }


            }
            item.CMN_STR_Office_RefID = Parameter.CMN_STR_Office_RefID;
            item.PointOfSale_DisplayName = Parameter.PointOfSale_DisplayName;
            item.IsPickUpStationForDistributionOrder = Parameter.IsPickUpStationForDistributionOrder;
            item.IsDeleted = Parameter.IsDeleted;
            item.PointOfSaleITL = String.Empty;
            item.Modification_Timestamp = DateTime.Now;

            item.Save(Connection, Transaction);
            returnValue.Result = item.CMN_SLS_PointOfSaleID;           

			return returnValue;

			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L2SPUS_1645 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L2SPUS_1645 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L2SPUS_1645 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2SPUS_1645 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_PointOfSale",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L2SPUS_1645 for attribute P_L2SPUS_1645
		[DataContract]
		public class P_L2SPUS_1645 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_SLS_PointOfSaleID { get; set; } 
			[DataMember]
			public Guid CMN_STR_Office_RefID { get; set; } 
			[DataMember]
			public String PointOfSale_DisplayName { get; set; } 
			[DataMember]
			public bool IsPickUpStationForDistributionOrder { get; set; } 
			[DataMember]
			public DateTime Modification_Timestamp { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public String PointOfSaleITL { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_PointOfSale(,P_L2SPUS_1645 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_PointOfSale.Invoke(connectionString,P_L2SPUS_1645 Parameter,securityTicket);
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
var parameter = new CL2_PointOfSale.Atomic.Manipulation.P_L2SPUS_1645();
parameter.CMN_SLS_PointOfSaleID = ...;
parameter.CMN_STR_Office_RefID = ...;
parameter.PointOfSale_DisplayName = ...;
parameter.IsPickUpStationForDistributionOrder = ...;
parameter.Modification_Timestamp = ...;
parameter.Creation_Timestamp = ...;
parameter.PointOfSaleITL = ...;
parameter.IsDeleted = ...;

*/
