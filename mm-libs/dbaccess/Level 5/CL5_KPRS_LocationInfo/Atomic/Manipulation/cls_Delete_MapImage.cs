/* 
 * Generated on 8/2/2013 12:51:23 PM
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
using CL1_RES_LOC;

namespace CL5_KPRS_Buildings.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Delete_MapImage.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Delete_MapImage
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Base Execute(DbConnection Connection,DbTransaction Transaction,P_L5BD_DMI_1248 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Base();
			//Put your code here

            ORM_RES_LOC_LocationInformation.Query locationInfoQuery = new ORM_RES_LOC_LocationInformation.Query();

            if (Parameter.MapType == "AreaMap")
            {
                locationInfoQuery.LocationInformation_MapImage_DocID = Parameter.DocumentID;
            }
            else if (Parameter.MapType == "SateliteMap")
            {
                locationInfoQuery.LocationInformation_SatelliteImage_DocID = Parameter.DocumentID;
            }
            else if (Parameter.MapType == "RegionMap")
            {
                locationInfoQuery.LocationInformation_AddressImage_DocID = Parameter.DocumentID;
            }

            locationInfoQuery.Tenant_RefID = securityTicket.TenantID;
            locationInfoQuery.IsDeleted = false;

            ORM_RES_LOC_LocationInformation locationInfo = ORM_RES_LOC_LocationInformation.Query.Search(Connection, Transaction, locationInfoQuery).FirstOrDefault();

            if (Parameter.MapType == "AreaMap")
            {
                locationInfo.LocationInformation_MapImage_DocID = Guid.Empty;
            }
            else if (Parameter.MapType == "SateliteMap")
            {
                locationInfo.LocationInformation_SatelliteImage_DocID = Guid.Empty;
            }
            else if (Parameter.MapType == "RegionMap")
            {
                locationInfo.LocationInformation_AddressImage_DocID = Guid.Empty;
            }

            locationInfo.Save(Connection, Transaction);

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Base Invoke(string ConnectionString,P_L5BD_DMI_1248 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection,P_L5BD_DMI_1248 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction,P_L5BD_DMI_1248 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5BD_DMI_1248 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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
		#region SClass P_L5BD_DMI_1248 for attribute P_L5BD_DMI_1248
		[DataContract]
		public class P_L5BD_DMI_1248 
		{
			//Standard type parameters
			[DataMember]
			public Guid DocumentID { get; set; } 
			[DataMember]
			public String MapType { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Base cls_Delete_MapImage(P_L5BD_DMI_1248 Parameter,string sessionToken = null)
{
	 var securityTicket = ...;
	 FR_Base result = cls_Delete_MapImage.Invoke(connectionString,P_L5BD_DMI_1248 Parameter,securityTicket);
	 return result;
}
*/