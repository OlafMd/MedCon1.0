/* 
 * Generated on 10/30/15 14:53:30
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
using CL1_HEC_CRT;
using MMDocConnectDBMethods.Doctor.Atomic.Retrieval;
using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectElasticSearchMethods.Doctor.Retrieval;
using MMDocConnectElasticSearchMethods.Doctor.Manipulation;

namespace MMDocConnectDBMethods.Doctor.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Doctor_to_Contract.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Doctor_to_Contract
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_DO_SDtC_1228 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_Guid();
            Guid AssignmentID = Guid.Empty;

            if (Parameter.DoctorAssignment == Guid.Empty)
            {
                var insuranceTobrokerContract = ORM_HEC_CRT_InsuranceToBrokerContract.Query.Search(Connection, Transaction, new ORM_HEC_CRT_InsuranceToBrokerContract.Query()
                {
                    Ext_CMN_CTR_Contract_RefID = Parameter.ContractID,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).SingleOrDefault();

                if (insuranceTobrokerContract != null)
                {
                    AssignmentID = insuranceTobrokerContract.HEC_CRT_InsuranceToBrokerContractID;
                }
                else
                {
                    insuranceTobrokerContract = new ORM_HEC_CRT_InsuranceToBrokerContract();
                    insuranceTobrokerContract.HEC_CRT_InsuranceToBrokerContractID = Guid.NewGuid();
                    insuranceTobrokerContract.Creation_Timestamp = DateTime.Now;
                    insuranceTobrokerContract.IsDeleted = false;
                    insuranceTobrokerContract.Tenant_RefID = securityTicket.TenantID;
                    insuranceTobrokerContract.Ext_CMN_CTR_Contract_RefID = Parameter.ContractID;
                    insuranceTobrokerContract.Save(Connection, Transaction);

                    AssignmentID = insuranceTobrokerContract.HEC_CRT_InsuranceToBrokerContractID;
                }

                var insuranceTobrokerContract2doctor = new ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingDoctor();
                insuranceTobrokerContract2doctor.Creation_Timestamp = DateTime.Now;
                insuranceTobrokerContract2doctor.HEC_CRT_InsuranceToBrokerContract_ParticipatingDoctorID = Guid.NewGuid();
                insuranceTobrokerContract2doctor.InsuranceToBrokerContract_RefID = AssignmentID;
                insuranceTobrokerContract2doctor.Tenant_RefID = securityTicket.TenantID;
                insuranceTobrokerContract2doctor.IsDeleted = false;
                insuranceTobrokerContract2doctor.Doctor_RefID = Parameter.DoctorID;
                insuranceTobrokerContract2doctor.ValidFrom = Parameter.ValidFrom;
                insuranceTobrokerContract2doctor.ValidThrough = Parameter.ValidThrough;

                insuranceTobrokerContract2doctor.Save(Connection, Transaction);
            }
            else
            {
                var insuranceTobrokerContract = ORM_HEC_CRT_InsuranceToBrokerContract.Query.Search(Connection, Transaction, new ORM_HEC_CRT_InsuranceToBrokerContract.Query()
                {
                    Ext_CMN_CTR_Contract_RefID = Parameter.ContractID,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).Single();

                AssignmentID = insuranceTobrokerContract.HEC_CRT_InsuranceToBrokerContractID;

                var insuranceTobrokerContract2doctor = ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingDoctor.Query.Search(Connection, Transaction, new ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingDoctor.Query()
                {
                    HEC_CRT_InsuranceToBrokerContract_ParticipatingDoctorID = Parameter.DoctorAssignment,
                    InsuranceToBrokerContract_RefID = AssignmentID,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false,
                    Doctor_RefID = Parameter.DoctorID
                }).Single();

                insuranceTobrokerContract2doctor.Modification_Timestamp = DateTime.Now;
                insuranceTobrokerContract2doctor.Doctor_RefID = Parameter.DoctorID;
                insuranceTobrokerContract2doctor.ValidFrom = Parameter.ValidFrom;
                insuranceTobrokerContract2doctor.ValidThrough = Parameter.ValidThrough;

                insuranceTobrokerContract2doctor.Save(Connection, Transaction);
            }
            
            var data = cls_Check_Doctor_Contracts_Dates.Invoke(Connection, Transaction, new P_DO_CDCD_1505() { DoctorID = Parameter.DoctorID }, securityTicket).Result;

            int DoctorContracts = data.Length;

            Practice_Doctors_Model DoctorFound = Get_Doctors_for_PracticeID.Set_Contract_Number_for_DoctorID(new Doctor_Contracts(){ DocID = Parameter.DoctorID }, securityTicket);

            if (DoctorFound != null)
            {
                List<Practice_Doctors_Model> DoctorFoundL = new List<Practice_Doctors_Model>();
                DoctorFound.contract = DoctorContracts;
                DoctorFoundL.Add(DoctorFound);
                Add_New_Practice.Import_Practice_Data_to_ElasticDB(DoctorFoundL, securityTicket.TenantID.ToString());
            }

            P_DO_GPIDfDID_1353 ParametarDocID = new P_DO_GPIDfDID_1353();
            ParametarDocID.DoctorID = Parameter.DoctorID;
            DO_GPIDfDID_1353[] data2 = cls_Get_PracticeID_for_DoctorID.Invoke(Connection, Transaction, ParametarDocID, securityTicket).Result;

            P_DO_GCfPID_1507 ParametarPractice = new P_DO_GCfPID_1507();

            ParametarPractice.PracticeID = data2.First().HEC_MedicalPractiseID;
            DO_GCfPID_1507[] Contracts = cls_Get_all_Doctors_Contract_Assignment_for_PracticeID.Invoke(Connection, Transaction, ParametarPractice, securityTicket).Result;
            int NumberOfContractsForPractice = Contracts.Count();
            Practice_Doctors_Model practice = new Practice_Doctors_Model();
            practice.id = ParametarPractice.PracticeID.ToString();

            Practice_Doctors_Model PracticeFound = Get_Doctors_for_PracticeID.Get_Practice_for_PracticeID(practice, securityTicket);
            List<Practice_Doctors_Model> practiceL = new List<Practice_Doctors_Model>();
            PracticeFound.contract = NumberOfContractsForPractice;
            practiceL.Add(PracticeFound);
            Add_New_Practice.Import_Practice_Data_to_ElasticDB(practiceL, securityTicket.TenantID.ToString());

            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_DO_SDtC_1228 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_DO_SDtC_1228 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_DO_SDtC_1228 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_DO_SDtC_1228 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Doctor_to_Contract",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_DO_SDtC_1228 for attribute P_DO_SDtC_1228
		[DataContract]
		public class P_DO_SDtC_1228 
		{
			//Standard type parameters
			[DataMember]
			public Guid DoctorID { get; set; } 
			[DataMember]
			public DateTime ValidFrom { get; set; } 
			[DataMember]
			public DateTime ValidThrough { get; set; } 
			[DataMember]
			public Guid ContractID { get; set; } 
			[DataMember]
			public Guid DoctorAssignment { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Doctor_to_Contract(,P_DO_SDtC_1228 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Doctor_to_Contract.Invoke(connectionString,P_DO_SDtC_1228 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Doctor.Complex.Manipulation.P_DO_SDtC_1228();
parameter.DoctorID = ...;
parameter.ValidFrom = ...;
parameter.ValidThrough = ...;
parameter.ContractID = ...;
parameter.DoctorAssignment = ...;

*/
