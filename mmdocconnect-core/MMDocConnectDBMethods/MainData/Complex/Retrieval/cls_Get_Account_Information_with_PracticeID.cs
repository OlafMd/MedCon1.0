/* 
 * Generated on 09/29/15 10:57:30
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
using MMDocConnectDBMethods.MainData.Atomic.Retrieval;
using CL1_CMN_BPT;
using CL1_CMN_BPT_CTM;
using CL1_HEC;
using MMDocConnectDBMethods.Case.Atomic.Retrieval;

namespace MMDocConnectDBMethods.MainData.Complex.Retrieval
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Get_Account_Information_with_PracticeID
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_MD_GAIwPID_1629 Execute(DbConnection Connection, DbTransaction Transaction, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_MD_GAIwPID_1629();
            returnValue.Result = new MD_GAIwPID_1629();
            returnValue.Result.AccountInformation = new MD_GAI_1617();
      
            var data = cls_Get_Account_Information.Invoke(Connection, Transaction, securityTicket).Result;
            returnValue.Result.AccountInformation = data;
           
            if (data.group_id == "mm.docconect.doc.app.group")
            {
                var is_doctor = !data.role.Contains("practice");


                if (is_doctor)
                {
                    var medical_practice = cls_Get_PracticeID_for_Doctor_BusinessParticipantID.Invoke(Connection, Transaction, new P_CAS_GPIDfDBPTID_1205() { BusinessParticipantID = data.CMN_BPT_BusinessParticipantID }, securityTicket).Result;
                    var hec_doctorQuery = new ORM_HEC_Doctor.Query();
                    hec_doctorQuery.IsDeleted = false;
                    hec_doctorQuery.Tenant_RefID = securityTicket.TenantID;
                    hec_doctorQuery.BusinessParticipant_RefID = data.CMN_BPT_BusinessParticipantID;
                
                    var hec_doctor = ORM_HEC_Doctor.Query.Search(Connection, Transaction, hec_doctorQuery).Single();
             
                    returnValue.Result.DoctorID = hec_doctor.HEC_DoctorID;

                    returnValue.Result.PracticeID = medical_practice.practice_id;
                    returnValue.Result.PracticeName = medical_practice.practice_name;                  
                }
                else
                {
                    var medical_practice = cls_Get_Case_PracticeData_for_PracticeBptID.Invoke(Connection, Transaction, new P_CAS_GCPDfPBptID_1248() { PracticeBptID = data.CMN_BPT_BusinessParticipantID }, securityTicket).Result;

                    returnValue.Result.PracticeID = medical_practice.id;
                    returnValue.Result.PracticeName = medical_practice.name;
                }
            }
            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_MD_GAIwPID_1629 Invoke(string ConnectionString, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_MD_GAIwPID_1629 Invoke(DbConnection Connection, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_MD_GAIwPID_1629 Invoke(DbConnection Connection, DbTransaction Transaction, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_MD_GAIwPID_1629 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_MD_GAIwPID_1629 functionReturn = new FR_MD_GAIwPID_1629();
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

                functionReturn = Execute(Connection, Transaction, securityTicket);

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

                throw new Exception("Exception occured in method cls_Get_Account_Information_with_PracticeID", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Custom Return Type
    [Serializable]
    public class FR_MD_GAIwPID_1629 : FR_Base
    {
        public MD_GAIwPID_1629 Result { get; set; }

        public FR_MD_GAIwPID_1629() : base() { }

        public FR_MD_GAIwPID_1629(Exception ex) : base(ex) { }

    }
    #endregion

    #region Support Classes
    #region SClass MD_GAIwPID_1629 for attribute MD_GAIwPID_1629
    [DataContract]
    public class MD_GAIwPID_1629
    {
        //Standard type parameters
        [DataMember]
        public Guid PracticeID { get; set; }
        [DataMember]
        public String PracticeName { get; set; }
        [DataMember]
        public Guid DoctorID { get; set; }
        [DataMember]
        public MD_GAI_1617 AccountInformation { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_MD_GAIwPID_1629 cls_Get_Account_Information_with_PracticeID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_MD_GAIwPID_1629 invocationResult = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

