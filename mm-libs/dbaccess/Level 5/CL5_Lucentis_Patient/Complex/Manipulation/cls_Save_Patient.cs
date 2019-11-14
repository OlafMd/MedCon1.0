/* 
 * Generated on 12/3/2014 8:40:26 AM
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
using CL1_HEC;
using CL1_CMN_BPT;
using CL1_CMN_PER;
using CL5_Lucentis_Patient.Complex.Retrieval;

namespace CL5_Lucentis_Patient.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Patient.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Patient
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5PA_SP__1607 Execute(DbConnection Connection,DbTransaction Transaction,P_L5PA_SP__1607 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_L5PA_SP__1607();
            returnValue.Result = new L5PA_SP__1607();

            ORM_HEC_Patient item = new ORM_HEC_Patient();

            bool isOK = true;
            #region Save
            
            if (Parameter.IsEdit== false)
            {

                P_L5PA_CIPEIP_1213 healthInsuranceParam = new P_L5PA_CIPEIP_1213();
                healthInsuranceParam.PracticeID = Parameter.PracticeID;
                healthInsuranceParam.HealthInsuranceNumber = Parameter.HealthInsuranceNumber;

                var hInsurance = cls_CheckIfPatientExistsInPractice.Invoke(Connection, Transaction, healthInsuranceParam, securityTicket).Result;

                //var healtInsuranceQuery = new ORM_HEC_Patient_HealthInsurance.Query();
                //healtInsuranceQuery.HealthInsurance_Number = Parameter.HealthInsuranceNumber;
                //healtInsuranceQuery.Tenant_RefID = securityTicket.TenantID;
                //healtInsuranceQuery.IsDeleted = false;

                //var hInsurance = ORM_HEC_Patient_HealthInsurance.Query.Search(Connection, Transaction, healtInsuranceQuery).FirstOrDefault();

                if (hInsurance.numberofID==0)
                {

                    Guid patientID = Parameter.PatientID;
                    Guid CMN_BPT_BusinessParticipantID = Guid.NewGuid();

                    item.HEC_PatientID = patientID;
                    item.CMN_BPT_BusinessParticipant_RefID = CMN_BPT_BusinessParticipantID;
                    item.Tenant_RefID = securityTicket.TenantID;


                    item.Save(Connection, Transaction);



                    #region save CMN_BPT_BusinessParticipant

                    ORM_CMN_BPT_BusinessParticipant bussinessParticipant = new ORM_CMN_BPT_BusinessParticipant();

                    bussinessParticipant.CMN_BPT_BusinessParticipantID = CMN_BPT_BusinessParticipantID;
                    bussinessParticipant.DisplayName = Parameter.Name + Parameter.LastName;
                    bussinessParticipant.IsNaturalPerson = true;
                    bussinessParticipant.IsCompany = false;
                    Guid NaturalPerson_CMN_PER_PersonInfoID = Guid.NewGuid();
                    bussinessParticipant.IfNaturalPerson_CMN_PER_PersonInfo_RefID = NaturalPerson_CMN_PER_PersonInfoID;
                    bussinessParticipant.IfCompany_CMN_COM_CompanyInfo_RefID = Guid.Empty;
                    bussinessParticipant.IsTenant = false;
                    bussinessParticipant.IfTenant_Tenant_RefID = Guid.Empty;
                    bussinessParticipant.Tenant_RefID = securityTicket.TenantID;

                    bussinessParticipant.Save(Connection, Transaction);

                    ORM_CMN_PER_PersonInfo personInfo = new ORM_CMN_PER_PersonInfo();

                    personInfo.CMN_PER_PersonInfoID = NaturalPerson_CMN_PER_PersonInfoID;
                    personInfo.FirstName = Parameter.Name;
                    personInfo.LastName = Parameter.LastName;
                    personInfo.BirthDate = Parameter.Birthdate;
                    personInfo.Gender = Parameter.Gender;
                    personInfo.ProfileImage_Document_RefID = Guid.Empty;
                    personInfo.Modification_Timestamp = DateTime.Now;
                    personInfo.Tenant_RefID = securityTicket.TenantID;

                    personInfo.Save(Connection, Transaction);

                    ORM_HEC_Patient_MedicalPractice medicalPractice = new ORM_HEC_Patient_MedicalPractice();

                    medicalPractice.HEC_Patient_MedicalPracticeID = Guid.NewGuid();
                    medicalPractice.HEC_Patient_RefID = patientID;
                    medicalPractice.HEC_MedicalPractices_RefID = Parameter.PracticeID;
                    medicalPractice.Tenant_RefID = securityTicket.TenantID;

                    medicalPractice.Save(Connection, Transaction);

                    ORM_HEC_Patient_HealthInsurance healtInsurance = new ORM_HEC_Patient_HealthInsurance();

                    healtInsurance.HEC_Patient_HealthInsurancesID = Guid.NewGuid();
                    healtInsurance.HealthInsurance_Number = Parameter.HealthInsuranceNumber;
                    healtInsurance.Patient_RefID = patientID;
                    healtInsurance.HealthInsurance_State_RefID = Guid.Empty;
                    healtInsurance.InsuranceStateCode = Parameter.InsuranceStateCode;
                    healtInsurance.Tenant_RefID = securityTicket.TenantID;
                    //TODO
                    healtInsurance.HIS_HealthInsurance_Company_RefID = Parameter.HealthInsuranceCompanyID;
                    healtInsurance.Save(Connection, Transaction);

                    #endregion
                }else
                {
                    isOK = false;
                }


            }
            #endregion

            #region Edit
           

            else
            {
                var result = item.Load(Connection, Transaction, Parameter.PatientID);
                if (result.Status != FR_Status.Success || item.HEC_PatientID == Guid.Empty)
                {
                    //var error = new FR_Guid();
                    //error.ErrorMessage = "No Such ID";
                    //error.Status = FR_Status.Error_Internal;
                    //return error;
                }

                //bussinessParticipant
                var query1 = new ORM_CMN_BPT_BusinessParticipant.Query();
                query1.CMN_BPT_BusinessParticipantID = item.CMN_BPT_BusinessParticipant_RefID;


                var bussinessParticipant = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, query1).First();

                //personInfo
                var query2 = new ORM_CMN_PER_PersonInfo.Query();
                query2.CMN_PER_PersonInfoID = bussinessParticipant.IfNaturalPerson_CMN_PER_PersonInfo_RefID;

                var personInfo = ORM_CMN_PER_PersonInfo.Query.Search(Connection, Transaction, query2).FirstOrDefault();

                //medicalPractice
                var query3 = new ORM_HEC_Patient_MedicalPractice.Query();
                query3.HEC_Patient_RefID = Parameter.PatientID;

                var medicalPractice = ORM_HEC_Patient_MedicalPractice.Query.Search(Connection, Transaction, query3).First();

                //healthInsurance
                var query4 = new ORM_HEC_Patient_HealthInsurance.Query();
                query4.Patient_RefID = Parameter.PatientID;

                var healthInsurance = ORM_HEC_Patient_HealthInsurance.Query.Search(Connection, Transaction, query4).First();

                #region Delete Patient

                if (Parameter.IsDeleted == true)
                {
                    item.IsDeleted = true;
                    item.Save(Connection, Transaction);
                }
                #endregion

                else
                {
                    //edit person info
                    personInfo.FirstName = Parameter.Name;
                    personInfo.LastName = Parameter.LastName;
                    personInfo.BirthDate = Parameter.Birthdate;
                    personInfo.Gender = Parameter.Gender;

                    personInfo.Save(Connection, Transaction);

                    //edit medical practise
                    medicalPractice.HEC_MedicalPractices_RefID = Parameter.PracticeID;
                    medicalPractice.Save(Connection, Transaction);

                    // health insurance
                    healthInsurance.HealthInsurance_State_RefID = Guid.Empty;
                    healthInsurance.InsuranceStateCode = Parameter.InsuranceStateCode;
                    healthInsurance.HealthInsurance_Number = Parameter.HealthInsuranceNumber;
                    //TODO
                    healthInsurance.HIS_HealthInsurance_Company_RefID = Parameter.HealthInsuranceCompanyID;
                    healthInsurance.Save(Connection, Transaction);



                    item.Save(Connection, Transaction);
                }
            }
            #endregion

            returnValue.Result.isOK = isOK;
            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5PA_SP__1607 Invoke(string ConnectionString,P_L5PA_SP__1607 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5PA_SP__1607 Invoke(DbConnection Connection,P_L5PA_SP__1607 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5PA_SP__1607 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5PA_SP__1607 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5PA_SP__1607 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5PA_SP__1607 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5PA_SP__1607 functionReturn = new FR_L5PA_SP__1607();
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

				throw new Exception("Exception occured in method cls_Save_Patient",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5PA_SP__1607 : FR_Base
	{
		public L5PA_SP__1607 Result	{ get; set; }

		public FR_L5PA_SP__1607() : base() {}

		public FR_L5PA_SP__1607(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5PA_SP__1607 for attribute P_L5PA_SP__1607
		[DataContract]
		public class P_L5PA_SP__1607 
		{
			//Standard type parameters
			[DataMember]
			public Guid PatientID { get; set; } 
			[DataMember]
			public String Name { get; set; } 
			[DataMember]
			public String LastName { get; set; } 
			[DataMember]
			public String InsuranceStateCode { get; set; } 
			[DataMember]
			public DateTime Birthdate { get; set; } 
			[DataMember]
			public Guid InsuranceStateID { get; set; } 
			[DataMember]
			public Guid PracticeID { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 
			[DataMember]
			public Guid HealthInsuranceCompanyID { get; set; } 
			[DataMember]
			public String HealthInsuranceNumber { get; set; } 
			[DataMember]
			public Boolean IsEdit { get; set; } 
			[DataMember]
			public int Gender { get; set; } 

		}
		#endregion
		#region SClass L5PA_SP__1607 for attribute L5PA_SP__1607
		[DataContract]
		public class L5PA_SP__1607 
		{
			//Standard type parameters
			[DataMember]
			public bool isOK { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5PA_SP__1607 cls_Save_Patient(,P_L5PA_SP__1607 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5PA_SP__1607 invocationResult = cls_Save_Patient.Invoke(connectionString,P_L5PA_SP__1607 Parameter,securityTicket);
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
var parameter = new CL5_Lucentis_Patient.Complex.Manipulation.P_L5PA_SP__1607();
parameter.PatientID = ...;
parameter.Name = ...;
parameter.LastName = ...;
parameter.InsuranceStateCode = ...;
parameter.Birthdate = ...;
parameter.InsuranceStateID = ...;
parameter.PracticeID = ...;
parameter.IsDeleted = ...;
parameter.HealthInsuranceCompanyID = ...;
parameter.HealthInsuranceNumber = ...;
parameter.IsEdit = ...;
parameter.Gender = ...;

*/
