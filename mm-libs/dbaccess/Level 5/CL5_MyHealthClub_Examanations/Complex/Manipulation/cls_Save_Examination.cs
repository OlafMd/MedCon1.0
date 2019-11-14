/* 
 * Generated on 2/2/2015 17:07:26
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
using CL1_HEC_ACT;
using CL1_CMN_STR;
using CL1_HEC;

namespace CL5_MyHealthClub_Examanations.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Examination.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Examination
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5EX_SE_1508 Execute(DbConnection Connection,DbTransaction Transaction,P_L5EX_SE_1508 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_L5EX_SE_1508();
			//Put your code here
            Guid examinationID = new Guid();
            if(Parameter.PerformedInternally){
                ORM_HEC_ACT_PerformedAction examination = new ORM_HEC_ACT_PerformedAction();
                examination.IfPerfomed_DateOfAction = Parameter.ExaminationDate;
                examination.IfPerformed_DateOfAction_Day = Parameter.ExaminationDate.Day;
                examination.IfPerformed_DateOfAction_Month = Parameter.ExaminationDate.Month;
                examination.IfPerformed_DateOfAction_Year = Parameter.ExaminationDate.Year;
                examination.IfPerformed_MedicalPracticeType_RefID = Parameter.MedicalPracticeTypeID;
                examination.IsPerformed_Internally = true;
                examination.Patient_RefID = Parameter.PatientID;
                examination.Tenant_RefID = securityTicket.TenantID;
                examination.IsPerformed_MedicalPractice_RefID = ORM_CMN_STR_Office.Query.Search(Connection, Transaction, new ORM_CMN_STR_Office.Query()
                {
                    CMN_STR_OfficeID = Parameter.OfficeID,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).Single().IfMedicalPractise_HEC_MedicalPractice_RefID;
                examination.Save(Connection, Transaction);

                ORM_HEC_ACT_PerformedAction_Doctor performedAction_doctor = new ORM_HEC_ACT_PerformedAction_Doctor();
                performedAction_doctor.HEC_Doctor_RefID = Parameter.DoctorID;
                performedAction_doctor.HEC_ACT_PerformedAction_RefID = examination.HEC_ACT_PerformedActionID;
                performedAction_doctor.HEC_ACT_PerformedAction_DoctorID = Guid.NewGuid();
                performedAction_doctor.Tenant_RefID = securityTicket.TenantID;
                performedAction_doctor.Creation_Timestamp = DateTime.Now;
                performedAction_doctor.Modification_Timestamp = DateTime.Now;
                performedAction_doctor.Save(Connection, Transaction);
  
                examinationID = examination.HEC_ACT_PerformedActionID;
            }
            returnValue.Result = new L5EX_SE_1508();
            returnValue.Result.ExaminationID = examinationID;
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5EX_SE_1508 Invoke(string ConnectionString,P_L5EX_SE_1508 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5EX_SE_1508 Invoke(DbConnection Connection,P_L5EX_SE_1508 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5EX_SE_1508 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5EX_SE_1508 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5EX_SE_1508 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5EX_SE_1508 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5EX_SE_1508 functionReturn = new FR_L5EX_SE_1508();
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

				throw new Exception("Exception occured in method cls_Save_Examination",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5EX_SE_1508 : FR_Base
	{
		public L5EX_SE_1508 Result	{ get; set; }

		public FR_L5EX_SE_1508() : base() {}

		public FR_L5EX_SE_1508(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5EX_SE_1508 for attribute P_L5EX_SE_1508
		[DataContract]
		public class P_L5EX_SE_1508 
		{
			//Standard type parameters
			[DataMember]
			public Guid DoctorID { get; set; } 
			[DataMember]
			public Guid MedicalPracticeTypeID { get; set; } 
			[DataMember]
			public Guid OfficeID { get; set; } 
			[DataMember]
			public Guid PatientID { get; set; } 
			[DataMember]
			public Boolean PerformedInternally { get; set; } 
			[DataMember]
			public DateTime ExaminationDate { get; set; } 

		}
		#endregion
		#region SClass L5EX_SE_1508 for attribute L5EX_SE_1508
		[DataContract]
		public class L5EX_SE_1508 
		{
			//Standard type parameters
			[DataMember]
			public Guid ExaminationID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5EX_SE_1508 cls_Save_Examination(,P_L5EX_SE_1508 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5EX_SE_1508 invocationResult = cls_Save_Examination.Invoke(connectionString,P_L5EX_SE_1508 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_Examanations.Complex.Manipulation.P_L5EX_SE_1508();
parameter.DoctorID = ...;
parameter.MedicalPracticeTypeID = ...;
parameter.OfficeID = ...;
parameter.PatientID = ...;
parameter.PerformedInternally = ...;
parameter.ExaminationDate = ...;

*/
