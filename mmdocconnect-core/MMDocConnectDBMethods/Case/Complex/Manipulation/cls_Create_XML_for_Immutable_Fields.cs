/* 
 * Generated on 23.6.2015 8:45:35
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
using System.IO;
using System.Xml;
using System.Text;

namespace MMDocConnectDBMethods.Case.Complex.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Create_XML_for_Immutable_Fields.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Create_XML_for_Immutable_Fields
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_CAS_CXFIF_0830 Execute(DbConnection Connection, DbTransaction Transaction, P_CAS_CXFIF_0830 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_CAS_CXFIF_0830();
            //Put your code here
            returnValue.Result = new CAS_CXFIF_0830();

            // string name = "immutableCase" +DateTime.Now.ToString("dd.MM.yyyy")+ ".xml";

            var ms = new MemoryStream();
            var w = new XmlTextWriter(ms, new UTF8Encoding(false)) { Formatting = Formatting.Indented };


            w.WriteStartDocument();
            w.WriteStartElement("CaseData");
            w.WriteElementString("PatientBirthDate", Parameter.PatientBirthDate);
            w.WriteElementString("PatientFirstName", Parameter.PatientFirstName);
            w.WriteElementString("PatientLastName", Parameter.PatientLastName);
            w.WriteElementString("PatientGender", Parameter.PatientGender);
            w.WriteElementString("PatientAge", Parameter.PatientAge);
            w.WriteElementString("DiagnosisName", Parameter.DiagnosisName);
            w.WriteElementString("DiagnosisCatalogName", Parameter.DiagnosisCatalogName);
            w.WriteElementString("DiagnosisCatalogCode", Parameter.DiagnosisCatalogCode);
            w.WriteElementString("Localization", Parameter.Localization);
            w.WriteElementString("IFPerformedResponsibleBPFullName", Parameter.IFPerformedResponsibleBPFullName);
            w.WriteElementString("IFPerformedMedicalPracticeName", Parameter.IFPerformedMedicalPracticeName);
            w.WriteEndElement();

            w.WriteEndDocument();
            w.Flush();

            returnValue.Result.XmlFileString = Encoding.UTF8.GetString(ms.ToArray());
            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_CAS_CXFIF_0830 Invoke(string ConnectionString, P_CAS_CXFIF_0830 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_CAS_CXFIF_0830 Invoke(DbConnection Connection, P_CAS_CXFIF_0830 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_CAS_CXFIF_0830 Invoke(DbConnection Connection, DbTransaction Transaction, P_CAS_CXFIF_0830 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_CAS_CXFIF_0830 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_CAS_CXFIF_0830 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_CAS_CXFIF_0830 functionReturn = new FR_CAS_CXFIF_0830();
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

                throw new Exception("Exception occured in method cls_Create_XML_for_Immutable_Fields", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Custom Return Type
    [Serializable]
    public class FR_CAS_CXFIF_0830 : FR_Base
    {
        public CAS_CXFIF_0830 Result { get; set; }

        public FR_CAS_CXFIF_0830() : base() { }

        public FR_CAS_CXFIF_0830(Exception ex) : base(ex) { }

    }
    #endregion

    #region Support Classes
    #region SClass P_CAS_CXFIF_0830 for attribute P_CAS_CXFIF_0830
    [DataContract]
    public class P_CAS_CXFIF_0830
    {
        //Standard type parameters
        [DataMember]
        public String PatientBirthDate { get; set; }
        [DataMember]
        public String PatientFirstName { get; set; }
        [DataMember]
        public String PatientLastName { get; set; }
        [DataMember]
        public String PatientGender { get; set; }
        [DataMember]
        public String PatientAge { get; set; }
        [DataMember]
        public String DiagnosisName { get; set; }
        [DataMember]
        public String DiagnosisCatalogName { get; set; }
        [DataMember]
        public String DiagnosisCatalogCode { get; set; }
        [DataMember]
        public String Localization { get; set; }
        [DataMember]
        public String IFPerformedResponsibleBPFullName { get; set; }
        [DataMember]
        public String IFPerformedMedicalPracticeName { get; set; }

    }
    #endregion
    #region SClass CAS_CXFIF_0830 for attribute CAS_CXFIF_0830
    [DataContract]
    public class CAS_CXFIF_0830
    {
        //Standard type parameters
        [DataMember]
        public String XmlFileString { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_CAS_CXFIF_0830 cls_Create_XML_for_Immutable_Fields(,P_CAS_CXFIF_0830 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_CAS_CXFIF_0830 invocationResult = cls_Create_XML_for_Immutable_Fields.Invoke(connectionString,P_CAS_CXFIF_0830 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Case.Complex.Manipulation.P_CAS_CXFIF_0830();
parameter.PatientBirthDate = ...;
parameter.PatientFirstName = ...;
parameter.PatientLastName = ...;
parameter.PatientGender = ...;
parameter.PatientAge = ...;
parameter.DiagnosisName = ...;
parameter.DiagnosisCatalogName = ...;
parameter.DiagnosisCatalogCode = ...;
parameter.Localization = ...;
parameter.IFPerformedResponsibleBPFullName = ...;
parameter.IFPerformedMedicalPracticeName = ...;

*/
