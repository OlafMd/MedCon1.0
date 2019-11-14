/* 
 * Generated on 1/16/2015 14:49:17
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
using CL5_MyHealthClub_Patient.Atomic.Manipulation;

namespace CL6_MyHealthClub_Patient.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_PatientBaseData_withDeleteCheck_and_PatientHealthInsurance_withBankData.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_PatientBaseData_withDeleteCheck_and_PatientHealthInsurance_withBankData
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6PA_SPBDwDCaPHIwBD_1222 Execute(DbConnection Connection,DbTransaction Transaction,P_L6PA_SPBDwDCaPHIwBD_1222 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L6PA_SPBDwDCaPHIwBD_1222();
			//Put your code here
            P_L6PA_SPBDwDC_1323 BaseDataParam = new P_L6PA_SPBDwDC_1323();
            BaseDataParam.BaseData = Parameter.BaseData.BaseData;
            var res = cls_Save_PatientBaseData_withDeleteCheck.Invoke(Connection,Transaction, BaseDataParam,securityTicket).Result;
            returnValue.Result = new L6PA_SPBDwDCaPHIwBD_1222();
            returnValue.Result.ID = res.ID;
            returnValue.Result.UsedInAppointment = res.UsedInAppointment;
            P_L5PA_SPHIaBD_1143 InsuranceDataParam = new P_L5PA_SPHIaBD_1143();
            InsuranceDataParam.AccountNumber = Parameter.InsuranceAndBankDataInfo.AccountNumber;
            InsuranceDataParam.BankName = Parameter.InsuranceAndBankDataInfo.BankName;
            InsuranceDataParam.BICCode = Parameter.InsuranceAndBankDataInfo.BICCode;
            InsuranceDataParam.CompanyName = Parameter.InsuranceAndBankDataInfo.CompanyName;
            InsuranceDataParam.HealthInsurance_Number = Parameter.InsuranceAndBankDataInfo.HealthInsurance_Number;
            InsuranceDataParam.HEC_HealthInsurance_CompanyID = Parameter.InsuranceAndBankDataInfo.HEC_HealthInsurance_CompanyID;
            InsuranceDataParam.HEC_Patient_HealthInsurance_StateID = Parameter.InsuranceAndBankDataInfo.HEC_Patient_HealthInsurance_StateID;
            InsuranceDataParam.IBAN = Parameter.InsuranceAndBankDataInfo.IBAN;
            InsuranceDataParam.InsuranceValidFrom = Parameter.InsuranceAndBankDataInfo.InsuranceValidFrom;
            InsuranceDataParam.InsuranceValidThrough = Parameter.InsuranceAndBankDataInfo.InsuranceValidThrough;
            InsuranceDataParam.IsDeleted = Parameter.InsuranceAndBankDataInfo.IsDeleted;
            InsuranceDataParam.IsNotSelfInsured = Parameter.InsuranceAndBankDataInfo.IsNotSelfInsured;
            InsuranceDataParam.IsNotSelfInsured_InsuredPersonBirthday = Parameter.InsuranceAndBankDataInfo.IsNotSelfInsured_InsuredPersonBirthday;
            InsuranceDataParam.IsNotSelfInsured_InsuredPersonName = Parameter.InsuranceAndBankDataInfo.IsNotSelfInsured_InsuredPersonName;
            InsuranceDataParam.OwnerText = Parameter.InsuranceAndBankDataInfo.OwnerText;
            InsuranceDataParam.PatientID = res.ID;
            cls_Save_PatienHealthInsurance_and_BankData.Invoke(Connection, Transaction, InsuranceDataParam, securityTicket);


			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6PA_SPBDwDCaPHIwBD_1222 Invoke(string ConnectionString,P_L6PA_SPBDwDCaPHIwBD_1222 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6PA_SPBDwDCaPHIwBD_1222 Invoke(DbConnection Connection,P_L6PA_SPBDwDCaPHIwBD_1222 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6PA_SPBDwDCaPHIwBD_1222 Invoke(DbConnection Connection, DbTransaction Transaction,P_L6PA_SPBDwDCaPHIwBD_1222 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6PA_SPBDwDCaPHIwBD_1222 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6PA_SPBDwDCaPHIwBD_1222 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6PA_SPBDwDCaPHIwBD_1222 functionReturn = new FR_L6PA_SPBDwDCaPHIwBD_1222();
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

				throw new Exception("Exception occured in method cls_Save_PatientBaseData_withDeleteCheck_and_PatientHealthInsurance_withBankData",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6PA_SPBDwDCaPHIwBD_1222 : FR_Base
	{
		public L6PA_SPBDwDCaPHIwBD_1222 Result	{ get; set; }

		public FR_L6PA_SPBDwDCaPHIwBD_1222() : base() {}

		public FR_L6PA_SPBDwDCaPHIwBD_1222(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6PA_SPBDwDCaPHIwBD_1222 for attribute P_L6PA_SPBDwDCaPHIwBD_1222
		[DataContract]
		public class P_L6PA_SPBDwDCaPHIwBD_1222 
		{
			[DataMember]
			public P_L5PA_SPHIaBD_1143 InsuranceAndBankDataInfo { get; set; }

			//Standard type parameters
			[DataMember]
			public P_L6PA_SPBDwDC_1323 BaseData { get; set; } 

		}
		#endregion
		#region SClass L6PA_SPBDwDCaPHIwBD_1222 for attribute L6PA_SPBDwDCaPHIwBD_1222
		[DataContract]
		public class L6PA_SPBDwDCaPHIwBD_1222 
		{
			[DataMember]
			public L6PA_SPBDwDC_1323_UsedInAppointment[] UsedInAppointment { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid ID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6PA_SPBDwDCaPHIwBD_1222 cls_Save_PatientBaseData_withDeleteCheck_and_PatientHealthInsurance_withBankData(,P_L6PA_SPBDwDCaPHIwBD_1222 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6PA_SPBDwDCaPHIwBD_1222 invocationResult = cls_Save_PatientBaseData_withDeleteCheck_and_PatientHealthInsurance_withBankData.Invoke(connectionString,P_L6PA_SPBDwDCaPHIwBD_1222 Parameter,securityTicket);
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
var parameter = new CL6_MyHealthClub_Patient.Complex.Manipulation.P_L6PA_SPBDwDCaPHIwBD_1222();
parameter.InsuranceAndBankDataInfo = ...;

parameter.BaseData = ...;

*/
