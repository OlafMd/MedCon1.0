/* 
 * Generated on 7/22/2013 3:46:30 PM
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
using CL1_CMN_PER;
using CL6_MS_Patient.Atomic.Retrieval;
using CL1_CMN;

namespace CL6_MS_Patient.Complex.Manipulation
{
	/// <summary>
    /// 
      
    
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_MS_AddressForPatient.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_MS_AddressForPatient
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L6PA_SMSAFP_1547 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Guid();
            P_L6PA_GMSPfID_1538 getPatientParam = new P_L6PA_GMSPfID_1538();
            getPatientParam.HEC_PatientID = Parameter.HEC_PatientID;
            L6PA_GMSPfID_1538 patient = cls_Get_MS_Patients_For_ID.Invoke(Connection, Transaction, getPatientParam, securityTicket).Result;

            if (patient == null)
            {
                var error = new FR_Guid();
                error.ErrorMessage = "No Such ID";
                error.Status = FR_Status.Error_Internal;
                return error;
            }

            ORM_CMN_PER_PersonInfo_2_Address.Query query = new ORM_CMN_PER_PersonInfo_2_Address.Query();
            query.CMN_PER_PersonInfo_RefID = patient.CMN_PER_PersonInfoID;
            query.Tenant_RefID = securityTicket.TenantID;
            query.IsDeleted = false;
            var queryRes = ORM_CMN_PER_PersonInfo_2_Address.Query.Search(Connection, Transaction, query);

            ORM_CMN_Address address = new ORM_CMN_Address();
            if (Parameter.CMN_AddressID != Guid.Empty)
            {
                var result = address.Load(Connection, Transaction, Parameter.CMN_AddressID);
                if (result.Status != FR_Status.Success || address.CMN_AddressID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }
            address.Street_Name = Parameter.Street_Name;
            address.Street_Number = Parameter.Street_Number;
            address.City_Name = Parameter.City_Name;
            address.City_PostalCode = Parameter.City_PostalCode;
            address.Province_Name = Parameter.Province_Name;
            address.Tenant_RefID = securityTicket.TenantID;
            address.Save(Connection, Transaction);

            ORM_CMN_PER_PersonInfo_2_Address assignment = queryRes.FirstOrDefault(a => a.CMN_Address_RefID == Parameter.CMN_AddressID);
            if (assignment == null)
            {
                assignment = new ORM_CMN_PER_PersonInfo_2_Address();

                assignment.CMN_Address_RefID = address.CMN_AddressID;
                assignment.CMN_PER_PersonInfo_RefID = patient.CMN_PER_PersonInfoID;
                assignment.Tenant_RefID = securityTicket.TenantID;
                if (queryRes.Count == 0)
                    assignment.IsPrimary = true;
                assignment.SequenceNumber = queryRes.Count + 1;
            }

            assignment.Save(Connection, Transaction);

            returnValue.Result = address.CMN_AddressID;
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L6PA_SMSAFP_1547 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L6PA_SMSAFP_1547 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L6PA_SMSAFP_1547 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6PA_SMSAFP_1547 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_MS_AddressForPatient",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L6PA_SMSAFP_1547 for attribute P_L6PA_SMSAFP_1547
		[DataContract]
		public class P_L6PA_SMSAFP_1547 
		{
			//Standard type parameters
			[DataMember]
			public string Province_Name { get; set; } 
			[DataMember]
			public string City_PostalCode { get; set; } 
			[DataMember]
			public string City_Name { get; set; } 
			[DataMember]
			public string Street_Number { get; set; } 
			[DataMember]
			public string Street_Name { get; set; } 
			[DataMember]
			public Guid HEC_PatientID { get; set; } 
			[DataMember]
			public Guid CMN_AddressID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_MS_AddressForPatient(,P_L6PA_SMSAFP_1547 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_MS_AddressForPatient.Invoke(connectionString,P_L6PA_SMSAFP_1547 Parameter,securityTicket);
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
var parameter = new CL6_MS_Patient.Complex.Manipulation.P_L6PA_SMSAFP_1547();
parameter.Province_Name = ...;
parameter.City_PostalCode = ...;
parameter.City_Name = ...;
parameter.Street_Number = ...;
parameter.Street_Name = ...;
parameter.HEC_PatientID = ...;
parameter.CMN_AddressID = ...;

*/
