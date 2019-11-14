/* 
 * Generated on 3/27/2014 11:20:02 AM
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
using CL5_Lucentis_BillingHistory.Atomic.Retrieval;
using CL5_Lucentis_Treatments.Atomic.Retrieval;

namespace CL6_Lucentis_BillingHistory.Complex.Retrieval
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Get_Billing_History_and_TreatmentNumber.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Get_Billing_History_and_TreatmentNumber
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_L6BH_GBHaTNfTID_1039 Execute(DbConnection Connection, DbTransaction Transaction, P_L6BH_GBHaTNfTID_1039 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_L6BH_GBHaTNfTID_1039();
            returnValue.Result = new L6BH_GBHaTNfTID_1039();
            List<L5BH_GBHfTID_1415> billHistory = new List<L5BH_GBHfTID_1415>();
            List<L6BH_GBHaTNfTID_1039_TreatmentNumberandTreatmentID> TreatmentNumberandTreatmentID = new List<L6BH_GBHaTNfTID_1039_TreatmentNumberandTreatmentID>();
            List<L5BH_GBSfSHID_1402> BillHistoryStatusAndHeaderID = new List<L5BH_GBSfSHID_1402>();
            returnValue.Result.billHistory = billHistory.ToArray();
            returnValue.Result.TreatmentNumberandTreatmentID = TreatmentNumberandTreatmentID.ToArray();
            returnValue.Result.BillHistoryStatusAndHeaderID = BillHistoryStatusAndHeaderID.ToArray();
            returnValue.Result.CurrentPage = 1;
            returnValue.Result.NumberOfPages = 1;
            returnValue.Result.NumberOfElements = 0;
            List<String> StatusesThatAreNotChecked = new List<String>();
            /*
           * @get billHistory
           * */
            P_L5BH_GBHfTID_1415 par = new P_L5BH_GBHfTID_1415();
            if (Parameter.IsASC_Order == false)
                par.OrderBy = "DESC";
            else
                par.OrderBy = "ASC";
            par.OrderValue = Parameter.OrderValue;
            par.StartIndex = (Parameter.PageClicked - 1) * Parameter.NumberOfElementsPerPage;
            par.NumberOfElements = Parameter.NumberOfElementsPerPage;

            if (Parameter.BillStatusID.Length == 0)
            {
                List<String> listWithGuidEmpty = new List<String>();// we use this when no status is checked
                String empty = String.Empty;
                listWithGuidEmpty.Add(empty);
                Parameter.BillStatusID = listWithGuidEmpty.ToArray();
            }


            // set statuses that are IN and NOT IN

            for (int i = 0; i < 8; i++)
            {
                StatusesThatAreNotChecked.Add(i.ToString());
            }

            foreach (var item in Parameter.BillStatusID.ToList())//remove statuses from StatusesThatAreNotChecked that are checked
            {
                StatusesThatAreNotChecked.Remove(item);
            }

            string InParameters = "";

            for (int i = 0; i < Parameter.BillStatusID.Length; i++)
            {
                if (i != Parameter.BillStatusID.Length - 1)
                    InParameters += Parameter.BillStatusID[i] + ",";
                else
                    InParameters += Parameter.BillStatusID[i];
            }

            par.InParameters = InParameters;

            string NOTInParameters = "";

            for (int i = 0; i < StatusesThatAreNotChecked.Count; i++)
            {
                if (i != StatusesThatAreNotChecked.Count - 1)
                    NOTInParameters += StatusesThatAreNotChecked[i] + ",";
                else
                    NOTInParameters += StatusesThatAreNotChecked[i];
            }

            par.NotInParameters = NOTInParameters;

            String searchCriterium = "";

            if (Parameter.PatientFirstName != null && Parameter.PatientFirstName != "")
            {
                searchCriterium = " AND LOWER( cmn_per_personinfo.FirstName ) LIKE '%" + Parameter.PatientFirstName.ToLower() + "%'";
            }

            if (Parameter.PatientLastName != null && Parameter.PatientLastName != "")
            {
                searchCriterium = searchCriterium + " AND LOWER( cmn_per_personinfo.LastName ) LIKE '%" + Parameter.PatientLastName.ToLower() + "%'";
            }

            if (Parameter.BillID_From != 0)
            {
                searchCriterium = searchCriterium + " AND bil_billheaders.BillNumber >= " + Parameter.BillID_From;
            }

            if (Parameter.BillID_To != 0)
            {
                searchCriterium = searchCriterium + " AND bil_billheaders.BillNumber <= " + Parameter.BillID_To;
            }

            if (Parameter.ProcessNumber_From != 0)
            {
                searchCriterium = searchCriterium + " AND bil_billpositions.External_PositionReferenceField >= " + Parameter.ProcessNumber_From;
            }

            if (Parameter.ProcessNumber_To != 0)
            {
                searchCriterium = searchCriterium + " AND bil_billpositions.External_PositionReferenceField <= " + Parameter.ProcessNumber_To;
            }

            if (Parameter.DateFrom != null && Parameter.DateFrom != "")
            {
                searchCriterium = searchCriterium + " AND hec_patient_treatment.IfTreatmentPerformed_Date >= '" + Parameter.DateFrom + "'";
            }

            if (Parameter.DateTo != null && Parameter.DateTo != "")
            {
                searchCriterium = searchCriterium + " AND hec_patient_treatment.IfTreatmentPerformed_Date <= '" + Parameter.DateTo + "'";
            }

            par.SearchCriterium = searchCriterium;

            //get number of pages to display in pager

            P_L5BH_GBHCfT_1334 para = new P_L5BH_GBHCfT_1334();

            para.BillStatusID = Parameter.BillStatusID;
            para.SearchCriterium = searchCriterium;

            var value = cls_Get_Billing_History_Count_for_TenantID.Invoke(Connection, Transaction, para, securityTicket).Result;

            int numberOfElements = value.NumberOfElements;
            returnValue.Result.NumberOfElements = value.NumberOfElements;
            int pageCount = (numberOfElements + Parameter.NumberOfElementsPerPage - 1) / Parameter.NumberOfElementsPerPage;

            returnValue.Result.CurrentPage = Parameter.PageClicked;
            returnValue.Result.NumberOfPages = pageCount;

            List<L5BH_GBHfTID_1415> billHistoryList = cls_Get_BillingHistory_for_TenantID.Invoke(Connection, Transaction, par, securityTicket).Result.ToList();

            List<L5BH_GBHfTID_1415> temp = billHistoryList.GroupBy(t => t.TreatmentID).Select(g => g.First()).ToList();
            List<L5BH_GBHfTID_1415> tempHeaderID = billHistoryList.GroupBy(t => t.BIL_BillHeaderID).Select(g => g.First()).ToList();

            List<Guid> treatmentIDList = new List<Guid>();
            Dictionary<Guid, Guid> patientIDandTreatmentID = new Dictionary<Guid, Guid>();
            List<Guid> headerIDList = new List<Guid>();

            foreach (var item in temp)
            {
                patientIDandTreatmentID.Add(item.TreatmentID, item.PatientID);
            }

            foreach (var item in tempHeaderID)
            {
                headerIDList.Add(item.BIL_BillHeaderID);
            }

            returnValue.Result.billHistory = billHistoryList.ToArray();

            //get bill status
            P_L5BH_GBSfSHID_1402 billStatusParam = new P_L5BH_GBSfSHID_1402();
            billStatusParam.BillHeaderID = headerIDList.ToArray();
            try
            {
                BillHistoryStatusAndHeaderID = cls_Get_BillStatus_for_BillHeaderID.Invoke(Connection, Transaction, billStatusParam, securityTicket).Result.ToList();
            }
            catch { }
            returnValue.Result.BillHistoryStatusAndHeaderID = BillHistoryStatusAndHeaderID.ToArray();
            /*
           * @get Treatment number and join it with Treatment ID
           * */
            List<L6BH_GBHaTNfTID_1039_TreatmentNumberandTreatmentID> TreatmentNumberAndIDList = new List<L6BH_GBHaTNfTID_1039_TreatmentNumberandTreatmentID>();

            foreach (var key in patientIDandTreatmentID.Keys)
            {
                L6BH_GBHaTNfTID_1039_TreatmentNumberandTreatmentID treatmentNumberAndTreatmentID = new L6BH_GBHaTNfTID_1039_TreatmentNumberandTreatmentID();
                treatmentNumberAndTreatmentID.TreatmentID = key;


                P_L5TR_GTIDaTDfPID_1130 par1 = new P_L5TR_GTIDaTDfPID_1130();
                par1.PatientID = patientIDandTreatmentID[key];

                var patientTreatments = cls_Get_TreatmentId_and_TreatmentDate_for_PatientID.Invoke(Connection, Transaction, par1, securityTicket).Result.ToList();


                patientTreatments = patientTreatments.OrderBy(i => i.TreatmentDate).ToList();

                if (patientTreatments.Count != 0)
                {

                    var patientTreatment = patientTreatments.Where(i => i.TreatmentID == key).First();

                    treatmentNumberAndTreatmentID.TreatmentNumber = patientTreatments.IndexOf(patientTreatment) + 1;
                }
                TreatmentNumberAndIDList.Add(treatmentNumberAndTreatmentID);
            }


            returnValue.Result.TreatmentNumberandTreatmentID = TreatmentNumberAndIDList.ToArray();

            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_L6BH_GBHaTNfTID_1039 Invoke(string ConnectionString, P_L6BH_GBHaTNfTID_1039 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_L6BH_GBHaTNfTID_1039 Invoke(DbConnection Connection, P_L6BH_GBHaTNfTID_1039 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_L6BH_GBHaTNfTID_1039 Invoke(DbConnection Connection, DbTransaction Transaction, P_L6BH_GBHaTNfTID_1039 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_L6BH_GBHaTNfTID_1039 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_L6BH_GBHaTNfTID_1039 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_L6BH_GBHaTNfTID_1039 functionReturn = new FR_L6BH_GBHaTNfTID_1039();
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

                throw new Exception("Exception occured in method cls_Get_Billing_History_and_TreatmentNumber", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Custom Return Type
    [Serializable]
    public class FR_L6BH_GBHaTNfTID_1039 : FR_Base
    {
        public L6BH_GBHaTNfTID_1039 Result { get; set; }

        public FR_L6BH_GBHaTNfTID_1039() : base() { }

        public FR_L6BH_GBHaTNfTID_1039(Exception ex) : base(ex) { }

    }
    #endregion

    #region Support Classes
    #region SClass P_L6BH_GBHaTNfTID_1039 for attribute P_L6BH_GBHaTNfTID_1039
    [DataContract]
    public class P_L6BH_GBHaTNfTID_1039
    {
        //Standard type parameters
        [DataMember]
        public bool IsASC_Order { get; set; }
        [DataMember]
        public String OrderValue { get; set; }
        [DataMember]
        public int PageClicked { get; set; }
        [DataMember]
        public int NumberOfElementsPerPage { get; set; }
        [DataMember]
        public String[] BillStatusID { get; set; }
        [DataMember]
        public String DateFrom { get; set; }
        [DataMember]
        public String DateTo { get; set; }
        [DataMember]
        public String PatientFirstName { get; set; }
        [DataMember]
        public String PatientLastName { get; set; }
        [DataMember]
        public int BillID_From { get; set; }
        [DataMember]
        public int BillID_To { get; set; }
        [DataMember]
        public int ProcessNumber_From { get; set; }
        [DataMember]
        public int ProcessNumber_To { get; set; }

    }
    #endregion
    #region SClass L6BH_GBHaTNfTID_1039 for attribute L6BH_GBHaTNfTID_1039
    [DataContract]
    public class L6BH_GBHaTNfTID_1039
    {
        [DataMember]
        public L6BH_GBHaTNfTID_1039_TreatmentNumberandTreatmentID[] TreatmentNumberandTreatmentID { get; set; }

        //Standard type parameters
        [DataMember]
        public L5BH_GBHfTID_1415[] billHistory { get; set; }
        [DataMember]
        public L5BH_GBSfSHID_1402[] BillHistoryStatusAndHeaderID { get; set; }
        [DataMember]
        public int NumberOfPages { get; set; }
        [DataMember]
        public int NumberOfElements { get; set; }
        [DataMember]
        public int CurrentPage { get; set; }

    }
    #endregion
    #region SClass L6BH_GBHaTNfTID_1039_TreatmentNumberandTreatmentID for attribute TreatmentNumberandTreatmentID
    [DataContract]
    public class L6BH_GBHaTNfTID_1039_TreatmentNumberandTreatmentID
    {
        //Standard type parameters
        [DataMember]
        public int TreatmentNumber { get; set; }
        [DataMember]
        public Guid TreatmentID { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6BH_GBHaTNfTID_1039 cls_Get_Billing_History_and_TreatmentNumber(,P_L6BH_GBHaTNfTID_1039 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6BH_GBHaTNfTID_1039 invocationResult = cls_Get_Billing_History_and_TreatmentNumber.Invoke(connectionString,P_L6BH_GBHaTNfTID_1039 Parameter,securityTicket);
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
var parameter = new CL6_Lucentis_BillingHistory.Complex.Retrieval.P_L6BH_GBHaTNfTID_1039();
parameter.IsASC_Order = ...;
parameter.OrderValue = ...;
parameter.PageClicked = ...;
parameter.NumberOfElementsPerPage = ...;
parameter.BillStatusID = ...;
parameter.DateFrom = ...;
parameter.DateTo = ...;
parameter.PatientFirstName = ...;
parameter.PatientLastName = ...;
parameter.BillID_From = ...;
parameter.BillID_To = ...;
parameter.ProcessNumber_From = ...;
parameter.ProcessNumber_To = ...;

*/
