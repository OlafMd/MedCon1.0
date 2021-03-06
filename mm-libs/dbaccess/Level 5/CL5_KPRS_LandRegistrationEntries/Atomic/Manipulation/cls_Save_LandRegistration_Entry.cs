/* 
 * Generated on 7/8/2013 11:34:56 AM
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
using CL1_RES;

namespace CL5_KPRS_LandRegistrationEntries.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_LandRegistration_Entry.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_LandRegistration_Entry
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5LR_SLRE_1043 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Guid();

            ORM_RES_RealestateProperty_LandRegistrationEntry landRegistrationEntry = new ORM_RES_RealestateProperty_LandRegistrationEntry();
            if (Parameter.RES_RealestateProperty_LandRegistrationEntryID != Guid.Empty)
            {
                var result = landRegistrationEntry.Load(Connection, Transaction, Parameter.RES_RealestateProperty_LandRegistrationEntryID);
                if (result.Status != FR_Status.Success || landRegistrationEntry.RES_RealestateProperty_LandRegistrationEntryID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }
            landRegistrationEntry.LandRegistrationEntry_GroundAreaSize_in_sqm = Parameter.LandRegistrationEntry_GroundAreaSize_in_sqm;
            landRegistrationEntry.LandRegistrationEntry_LandLot = Parameter.LandRegistrationEntry_LandLot;
            landRegistrationEntry.LandRegistrationEntry_LandTitleRegister = Parameter.LandRegistrationEntry_LandTitleRegister;
            landRegistrationEntry.LandRegistrationEntry_Marking = Parameter.LandRegistrationEntry_Marking;
            landRegistrationEntry.LandRegistrationEntry_Parcel_FromNumber = Parameter.LandRegistrationEntry_Parcel_FromNumber;
            landRegistrationEntry.LandRegistrationEntry_Parcel_ToNumber = Parameter.LandRegistrationEntry_Parcel_ToNumber;
            landRegistrationEntry.LandRegistrationEntry_Sheet = Parameter.LandRegistrationEntry_Sheet;
            landRegistrationEntry.RealestateProperty_RefID = Parameter.RealestateProperty_RefID;
            landRegistrationEntry.Tenant_RefID = securityTicket.TenantID;
            landRegistrationEntry.Save(Connection, Transaction);

            returnValue.Result = landRegistrationEntry.RES_RealestateProperty_LandRegistrationEntryID;
			//Put your code here
			return returnValue;
			#endregion UserCode
        }
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5LR_SLRE_1043 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5LR_SLRE_1043 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5LR_SLRE_1043 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5LR_SLRE_1043 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_LandRegistration_Entry",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5LR_SLRE_1043 for attribute P_L5LR_SLRE_1043
		[DataContract]
		public class P_L5LR_SLRE_1043 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_RealestateProperty_LandRegistrationEntryID { get; set; } 
			[DataMember]
			public String LandRegistrationEntry_LandTitleRegister { get; set; } 
			[DataMember]
			public String LandRegistrationEntry_Marking { get; set; } 
			[DataMember]
			public int LandRegistrationEntry_LandLot { get; set; } 
			[DataMember]
			public int LandRegistrationEntry_Parcel_FromNumber { get; set; } 
			[DataMember]
			public int LandRegistrationEntry_Parcel_ToNumber { get; set; } 
			[DataMember]
			public int LandRegistrationEntry_Sheet { get; set; } 
			[DataMember]
			public double LandRegistrationEntry_GroundAreaSize_in_sqm { get; set; } 
			[DataMember]
			public Guid RealestateProperty_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_LandRegistration_Entry(,P_L5LR_SLRE_1043 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_LandRegistration_Entry.Invoke(connectionString,P_L5LR_SLRE_1043 Parameter,securityTicket);
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
var parameter = new CL5_KPRS_LandRegistrationEntries.Atomic.Manipulation.P_L5LR_SLRE_1043();
parameter.RES_RealestateProperty_LandRegistrationEntryID = ...;
parameter.LandRegistrationEntry_LandTitleRegister = ...;
parameter.LandRegistrationEntry_Marking = ...;
parameter.LandRegistrationEntry_LandLot = ...;
parameter.LandRegistrationEntry_Parcel_FromNumber = ...;
parameter.LandRegistrationEntry_Parcel_ToNumber = ...;
parameter.LandRegistrationEntry_Sheet = ...;
parameter.LandRegistrationEntry_GroundAreaSize_in_sqm = ...;
parameter.RealestateProperty_RefID = ...;

*/