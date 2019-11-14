/* 
 * Generated on 11/06/15 16:02:16
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
using CL1_CMN_CTR;
using CL1_HEC_CRT;
using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectDBMethods.Doctor.Atomic.Retrieval;
using MMDocConnectElasticSearchMethods.Doctor.Retrieval;
using MMDocConnectElasticSearchMethods.Doctor.Manipulation;

namespace MMDocConnectDBMethods.MainData.Atomic.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Save_Contract_Participating_Doctors.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Save_Contract_Participating_Doctors
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Guid Execute(DbConnection Connection, DbTransaction Transaction, P_MD_SCPD_1341 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_Guid();
            //Put your code here
            var contractDetails = ORM_CMN_CTR_Contract.Query.Search(Connection, Transaction, new ORM_CMN_CTR_Contract.Query()
            {
                CMN_CTR_ContractID = Parameter.ContractID,
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID
            }).SingleOrDefault();

            var insuranceToBrokerContract = ORM_HEC_CRT_InsuranceToBrokerContract.Query.Search(Connection, Transaction, new ORM_HEC_CRT_InsuranceToBrokerContract.Query()
            {
                Ext_CMN_CTR_Contract_RefID = Parameter.ContractID,
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID
            }).SingleOrDefault();

            if (contractDetails != null && insuranceToBrokerContract != null)
            {
                var currentParticipatingDoctors = ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingDoctor.Query.Search(Connection, Transaction, new ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingDoctor.Query()
                {
                    InsuranceToBrokerContract_RefID = insuranceToBrokerContract.HEC_CRT_InsuranceToBrokerContractID,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).Where(cpd => Parameter.ParticipatingDoctors.Any(pd => !pd.IsParticipating && pd.AssignmentID == cpd.HEC_CRT_InsuranceToBrokerContract_ParticipatingDoctorID));

                foreach (var participatingDoctor in currentParticipatingDoctors)
                {
                    var doctor = Parameter.ParticipatingDoctors.Where(pd => pd.AssignmentID == participatingDoctor.HEC_CRT_InsuranceToBrokerContract_ParticipatingDoctorID && !pd.IsParticipating).SingleOrDefault();

                    if (doctor != null)
                    {
                        participatingDoctor.ValidThrough = doctor.ConsentDate;
                        participatingDoctor.Modification_Timestamp = DateTime.Now;

                        participatingDoctor.Save(Connection, Transaction);
                    }
                }

                List<Practice_Doctors_Model> practiceL = new List<Practice_Doctors_Model>();
                List<Practice_Doctors_Model> DoctorFoundL = new List<Practice_Doctors_Model>();

                foreach (var doctor in Parameter.ParticipatingDoctors.Where(d => d.IsParticipating && d.AssignmentID == Guid.Empty))
                {
                    var participatingDoctor = new ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingDoctor();
                    participatingDoctor.Creation_Timestamp = DateTime.Now;
                    participatingDoctor.Doctor_RefID = doctor.DoctorID;
                    participatingDoctor.HEC_CRT_InsuranceToBrokerContract_ParticipatingDoctorID = Guid.NewGuid();
                    participatingDoctor.ValidFrom = doctor.ConsentDate;
                    participatingDoctor.ValidThrough = contractDetails.ValidThrough;
                    participatingDoctor.InsuranceToBrokerContract_RefID = insuranceToBrokerContract.HEC_CRT_InsuranceToBrokerContractID;
                    participatingDoctor.Modification_Timestamp = DateTime.Now;
                    participatingDoctor.Tenant_RefID = securityTicket.TenantID;

                    participatingDoctor.Save(Connection, Transaction);

                    var data = cls_Check_Doctor_Contracts_Dates.Invoke(Connection, Transaction, new P_DO_CDCD_1505() { DoctorID = doctor.DoctorID }, securityTicket).Result;

                    int DoctorContracts = data.Count();

                    Practice_Doctors_Model DoctorFound = Get_Doctors_for_PracticeID.Set_Contract_Number_for_DoctorID(new Doctor_Contracts() { DocID = doctor.DoctorID }, securityTicket);

                    if (DoctorFound != null)
                    {
                        DoctorFound.contract = DoctorContracts;
                        DoctorFoundL.Add(DoctorFound);
                    }

                    var data2 = cls_Get_PracticeID_for_DoctorID.Invoke(Connection, Transaction, new P_DO_GPIDfDID_1353() { DoctorID = doctor.DoctorID }, securityTicket).Result;
                    var Contracts = cls_Get_all_Doctors_Contract_Assignment_for_PracticeID.Invoke(Connection, Transaction, new P_DO_GCfPID_1507() { PracticeID = data2.First().HEC_MedicalPractiseID }, securityTicket).Result;

                    int NumberOfContractsForPractice = Contracts.Count();

                    Practice_Doctors_Model PracticeFound = Get_Doctors_for_PracticeID.Get_Practice_for_PracticeID(new Practice_Doctors_Model() { id = data2.First().HEC_MedicalPractiseID.ToString() }, securityTicket);
                    PracticeFound.contract = NumberOfContractsForPractice;
                    practiceL.Add(PracticeFound);
                }

                if (practiceL.Count != 0)
                    Add_New_Practice.Import_Practice_Data_to_ElasticDB(practiceL, securityTicket.TenantID.ToString());

                if (DoctorFoundL.Count != 0)
                    Add_New_Practice.Import_Practice_Data_to_ElasticDB(DoctorFoundL, securityTicket.TenantID.ToString());
            }

            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_Guid Invoke(string ConnectionString, P_MD_SCPD_1341 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, P_MD_SCPD_1341 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, P_MD_SCPD_1341 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_MD_SCPD_1341 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

                functionReturn = Execute(Connection, Transaction, Parameter, securityTicket);

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
                    if (cleanupTransaction == true && Transaction != null)
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

                throw new Exception("Exception occured in method cls_Save_Contract_Participating_Doctors", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
    #region SClass P_MD_SCPD_1341 for attribute P_MD_SCPD_1341
    [DataContract]
    public class P_MD_SCPD_1341
    {
        [DataMember]
        public P_MD_SCPD_1341_Doctors[] ParticipatingDoctors { get; set; }

        //Standard type parameters
        [DataMember]
        public Guid ContractID { get; set; }

    }
    #endregion
    #region SClass P_MD_SCPD_1341_Doctors for attribute ParticipatingDoctors
    [DataContract]
    public class P_MD_SCPD_1341_Doctors
    {
        //Standard type parameters
        [DataMember]
        public Guid AssignmentID { get; set; }
        [DataMember]
        public Guid DoctorID { get; set; }
        [DataMember]
        public DateTime ConsentDate { get; set; }
        [DataMember]
        public Boolean IsParticipating { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Contract_Participating_Doctors(,P_MD_SCPD_1341 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Contract_Participating_Doctors.Invoke(connectionString,P_MD_SCPD_1341 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.MainData.Atomic.Manipulation.P_MD_SCPD_1341();
parameter.ParticipatingDoctors = ...;

parameter.ContractID = ...;

*/
