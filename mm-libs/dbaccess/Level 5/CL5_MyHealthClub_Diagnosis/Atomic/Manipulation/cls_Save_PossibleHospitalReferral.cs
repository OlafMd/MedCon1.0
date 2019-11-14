/* 
 * Generated on 11/7/2014 12:19:36 PM
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
using CL1_HEC_DIA_STA;

namespace CL5_MyHealthClub_Diagnosis.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_PossibleHospitalReferral.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_PossibleHospitalReferral
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guids Execute(DbConnection Connection,DbTransaction Transaction,P_L5DI_SPHR_1208 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guids();
			//Put your code here

            List<Guid> resultID = new List<Guid>();
            //foreach (var hospitalParam in Parameter.PossibleHospitalReferral)
            //{
            //    ORM_HEC_DIA_STA_Diagnosis_ReferalHistory referalMedicalPractice = ORM_HEC_DIA_STA_Diagnosis_ReferalHistory.Query.Search(Connection, Transaction, new ORM_HEC_DIA_STA_Diagnosis_ReferalHistory.Query
            //    {
            //        HEC_DIA_STA_Diagnosis_ReferalHistoryID = hospitalParam.HEC_DIA_STA_Diagnosis_ReferalHistoryID,
            //        IsDeleted = false,
            //        Tenant_RefID = securityTicket.TenantID
            //    }).SingleOrDefault();

            //    if (!hospitalParam.IsDeleted)
            //    {
            //        if (referalMedicalPractice == null)
            //        {
            //            referalMedicalPractice = new ORM_HEC_DIA_STA_Diagnosis_ReferalHistory();
            //            referalMedicalPractice.HEC_DIA_STA_Diagnosis_ReferalHistoryID = referalMedicalPractice.HEC_DIA_STA_Diagnosis_ReferalHistoryID;
            //        }
            //        referalMedicalPractice.MedicalPractice_RefID = hospitalParam.MedicalPractice_RefID;
            //        referalMedicalPractice.PotentialDiagnosis_RefID = hospitalParam.PotentialDiagnosis_RefID;
            //        referalMedicalPractice.IsDeleted = false;
            //        referalMedicalPractice.Tenant_RefID = securityTicket.TenantID;
            //        referalMedicalPractice.Save(Connection, Transaction);
            //        resultID.Add(referalMedicalPractice.HEC_DIA_STA_Diagnosis_ReferalHistoryID);
            //    }
            //    else if (referalMedicalPractice != null && hospitalParam.IsDeleted)
            //    {
            //        referalMedicalPractice.IsDeleted = true;
            //        referalMedicalPractice.Save(Connection, Transaction);
            //        resultID.Add(referalMedicalPractice.HEC_DIA_STA_Diagnosis_ReferalHistoryID);
            //    }
            //}
            returnValue.Result = resultID.ToArray();

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guids Invoke(string ConnectionString,P_L5DI_SPHR_1208 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guids Invoke(DbConnection Connection,P_L5DI_SPHR_1208 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guids Invoke(DbConnection Connection, DbTransaction Transaction,P_L5DI_SPHR_1208 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guids Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5DI_SPHR_1208 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Guids functionReturn = new FR_Guids();
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

				throw new Exception("Exception occured in method cls_Save_PossibleHospitalReferral",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5DI_SPHR_1208 for attribute P_L5DI_SPHR_1208
		[DataContract]
		public class P_L5DI_SPHR_1208 
		{
			[DataMember]
			public P_L5DI_SPHR_1208_PossibleHospitalReferral[] PossibleHospitalReferral { get; set; }

			//Standard type parameters
		}
		#endregion
		#region SClass P_L5DI_SPHR_1208_PossibleHospitalReferral for attribute PossibleHospitalReferral
		[DataContract]
		public class P_L5DI_SPHR_1208_PossibleHospitalReferral 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_DIA_STA_Diagnosis_ReferalHistoryID { get; set; } 
			[DataMember]
			public Guid PotentialDiagnosis_RefID { get; set; } 
			[DataMember]
			public Guid MedicalPractice_RefID { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guids cls_Save_PossibleHospitalReferral(,P_L5DI_SPHR_1208 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guids invocationResult = cls_Save_PossibleHospitalReferral.Invoke(connectionString,P_L5DI_SPHR_1208 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_Diagnosis.Atomic.Manipulation.P_L5DI_SPHR_1208();
parameter.PossibleHospitalReferral = ...;


*/
