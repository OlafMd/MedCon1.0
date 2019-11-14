/* 
 * Generated on 8/12/2014 3:16:38 PM
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
using CL5_MyHealthClub_HealthInsurance.Atomic.Manipulation;
using CL1_HEC;
using CL5_MyHealthClub_Patient.Atomic.Retrieval;

namespace CL6_MyHealthClub_HealthInsurance.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_HIState_withDeleteCheck.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_HIState_withDeleteCheck
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6HI_SHISwDC_1513 Execute(DbConnection Connection,DbTransaction Transaction,P_L6HI_SHISwDC_1513 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_L6HI_SHISwDC_1513();
			//Put your code here

            returnValue.Result = new L6HI_SHISwDC_1513();

            Guid HealthStateId = Guid.Empty;
            if (!Parameter.BaseData.IsDeleted)
            {
                HealthStateId = cls_Save_HIState.Invoke(Connection, Transaction, Parameter.BaseData, securityTicket).Result;
            }
            else
            {
                List<ORM_HEC_Patient_HealthInsurance> existingPatient = ORM_HEC_Patient_HealthInsurance.Query.Search(Connection, Transaction, new ORM_HEC_Patient_HealthInsurance.Query
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID,
                    HealthInsurance_State_RefID = Parameter.BaseData.HEC_Patient_HealthInsurance_StateID
                }).ToList();

                if (existingPatient.Count > 0) //cannot delete
                {
                    List<L6HI_SHISwDC_1513_UsedInPatient> usedPatientList = new List<L6HI_SHISwDC_1513_UsedInPatient>();

                    foreach (var patient in existingPatient)
                    {
                        L5PA_GPNfPID_1500 patientName = cls_Get_Patient_Name_for_PatientID.Invoke(Connection, Transaction, new P_L5PA_GPNfPID_1500 { PatientID = patient.Patient_RefID }, securityTicket ).Result;
                        string fullName = patientName.FirstName + " " + patientName.LastName;
                        usedPatientList.Add(new L6HI_SHISwDC_1513_UsedInPatient { PatientName = fullName });
                    }
                    returnValue.Result.UsedInPatient = usedPatientList.ToArray();
                }

                if (existingPatient.Count == 0)
                {
                    HealthStateId = cls_Save_HIState.Invoke(Connection, Transaction, Parameter.BaseData, securityTicket).Result;
                }
            }
            returnValue.Result.ID = HealthStateId;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6HI_SHISwDC_1513 Invoke(string ConnectionString,P_L6HI_SHISwDC_1513 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6HI_SHISwDC_1513 Invoke(DbConnection Connection,P_L6HI_SHISwDC_1513 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6HI_SHISwDC_1513 Invoke(DbConnection Connection, DbTransaction Transaction,P_L6HI_SHISwDC_1513 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6HI_SHISwDC_1513 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6HI_SHISwDC_1513 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6HI_SHISwDC_1513 functionReturn = new FR_L6HI_SHISwDC_1513();
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

				throw new Exception("Exception occured in method cls_Save_HIState_withDeleteCheck",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6HI_SHISwDC_1513 : FR_Base
	{
		public L6HI_SHISwDC_1513 Result	{ get; set; }

		public FR_L6HI_SHISwDC_1513() : base() {}

		public FR_L6HI_SHISwDC_1513(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6HI_SHISwDC_1513 for attribute P_L6HI_SHISwDC_1513
		[DataContract]
		public class P_L6HI_SHISwDC_1513 
		{
			//Standard type parameters
			[DataMember]
			public P_L5HI_SHIS_1500 BaseData { get; set; } 

		}
		#endregion
		#region SClass L6HI_SHISwDC_1513 for attribute L6HI_SHISwDC_1513
		[DataContract]
		public class L6HI_SHISwDC_1513 
		{
			[DataMember]
			public L6HI_SHISwDC_1513_UsedInPatient[] UsedInPatient { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid ID { get; set; } 

		}
		#endregion
		#region SClass L6HI_SHISwDC_1513_UsedInPatient for attribute UsedInPatient
		[DataContract]
		public class L6HI_SHISwDC_1513_UsedInPatient 
		{
			//Standard type parameters
			[DataMember]
			public String PatientName { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6HI_SHISwDC_1513 cls_Save_HIState_withDeleteCheck(,P_L6HI_SHISwDC_1513 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6HI_SHISwDC_1513 invocationResult = cls_Save_HIState_withDeleteCheck.Invoke(connectionString,P_L6HI_SHISwDC_1513 Parameter,securityTicket);
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
var parameter = new CL6_MyHealthClub_HealthInsurance.Complex.Manipulation.P_L6HI_SHISwDC_1513();
parameter.BaseData = ...;

*/
