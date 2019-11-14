/* 
 * Generated on 2/6/2017 5:33:32 PM
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
using MMDocConnectDBMethods.Doctor.Atomic.Retrieval;
using MMDocConnectDBMethods.Pharmacy.Atomic.Retrieval;

namespace MMDocConnectDBMethods.Doctor.Complex.Retrieval
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Get_Practice_DetailData.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Get_Practice_DetailData
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_DO_GPDD_1700 Execute(DbConnection Connection, DbTransaction Transaction, P_DO_GPDD_1700 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_DO_GPDD_1700();
            returnValue.Result = new DO_GPDD_1700();
            var practice_details = new DO_GPDD_1700();

            var data = cls_Get_Practice_Details_for_PracticeID.Invoke(Connection, Transaction, new P_DO_GPDfPID_1432 { PracticeID = Parameter.ID }, securityTicket).Result;

            foreach (var practice in data)
            {
                if (practice.is_company)
                {
                    practice_details.address = practice.street;
                    practice_details.bank = practice.practice_bank_name;
                    practice_details.bic = practice.practice_bank_BIC;
                    practice_details.bsnr = practice.practice_BSNR;
                    practice_details.No = practice.number;

                    practice_details.email = practice.contact_email;
                    practice_details.fax = practice.contact_fax;
                    practice_details.iban = practice.practice_IBAN;
                    practice_details.id = practice.practiceID.ToString();
                    practice_details.phone = practice.contact_telephone;
                    practice_details.name = practice.practice_name;
                    practice_details.town = practice.city;
                    practice_details.Zip = practice.zip;
                    practice_details.account_holder = practice.account_holder;
                    practice_details.password = "fake pass";


                    if (practice.IsValue_Number)
                    {
                        if (practice.PropertyName.Equals("Default Shipping Date Offset"))
                            practice_details.default_shipping_date_offset = practice.Value_Number;
                    }

                    if (practice.IsValue_Boolean)
                    {
                        if (practice.PropertyName.Equals("Waive Service Fee"))
                            practice_details.isWaiveServiceFee = practice.Value_Boolean;
                        if (practice.PropertyName.Equals("Order Drugs"))
                            practice_details.IsOrderDrugs = practice.Value_Boolean;
                        if (practice.PropertyName.Equals("Surgery Practice"))
                            practice_details.IsSurgeryPractice = practice.Value_Boolean;
                        if (practice.PropertyName.Equals("Only Label Required"))
                            practice_details.IsOnlyLabelRequired = practice.Value_Boolean;
                        if (practice.PropertyName.Equals("Quick order"))
                            practice_details.IsQuickOrderActive = practice.Value_Boolean;

                    }
                }
                else
                {
                    practice_details.contact_email = practice.contact_email;
                    practice_details.contact_person_name = practice.contact_person_name;
                    practice_details.contact_telephone = practice.contact_telephone;
                }

                var accountID = cls_Get_Practice_AccountID_for_PracticeID.Invoke(Connection, Transaction, new P_DO_GPAIDfPID_1351() { PracticeID = Parameter.ID }, securityTicket).Result.accountID;
                practice_details.login_email = data.First().sign_in_email;
            }

            var shouldDownloadReportProperty = cls_Get_Practice_PropertyValue_for_PropertyName_and_PracticeID.Invoke(Connection, Transaction, new P_DO_GPPVfPNaPID_0916()
            {
                PracticeID = Parameter.ID,
                PropertyName = "Download Report Upon Submission"
            }, securityTicket).Result;
            if (shouldDownloadReportProperty != null)
                practice_details.ShouldDownloadReportUponSubmission = shouldDownloadReportProperty.BooleanValue;

            var pressEnterToSearchProperty = cls_Get_Practice_PropertyValue_for_PropertyName_and_PracticeID.Invoke(Connection, Transaction, new P_DO_GPPVfPNaPID_0916()
            {
                PracticeID = Parameter.ID,
                PropertyName = "Press enter to search"
            }, securityTicket).Result;
            if (pressEnterToSearchProperty != null)
            {
                practice_details.PressEnterToSearch = pressEnterToSearchProperty.BooleanValue;
            }

            var practiceHasOctDeviceProperty = cls_Get_Practice_PropertyValue_for_PropertyName_and_PracticeID.Invoke(Connection, Transaction, new P_DO_GPPVfPNaPID_0916()
            {
                PracticeID = Parameter.ID,
                PropertyName = "Practice has OCT device"
            }, securityTicket).Result;
            if (practiceHasOctDeviceProperty != null)
            {
                practice_details.PracticeHasOctDevice = practiceHasOctDeviceProperty.BooleanValue;
            }

            var defaultPharmacyProperty = cls_Get_Practice_PropertyValue_for_PropertyName_and_PracticeID.Invoke(Connection, Transaction, new P_DO_GPPVfPNaPID_0916()
            {
                PracticeID = Parameter.ID,
                PropertyName = "Default pharmacy"
            }, securityTicket).Result;
            if (defaultPharmacyProperty != null)
            {
                practice_details.DefaultPharmacy = String.IsNullOrEmpty(defaultPharmacyProperty.TextValue) ? Guid.Empty.ToString() : defaultPharmacyProperty.TextValue;
            }
            else
            {
                practice_details.DefaultPharmacy = null;
            }

            var quickOrderProperty = cls_Get_Practice_PropertyValue_for_PropertyName_and_PracticeID.Invoke(Connection, Transaction, new P_DO_GPPVfPNaPID_0916()
            {
                PracticeID = Parameter.ID,
                PropertyName = "Quick order"
            }, securityTicket).Result;
            if (quickOrderProperty != null)
            {
                practice_details.IsQuickOrderActive = quickOrderProperty.BooleanValue;
            }

            var deliveryDateFromProperty = cls_Get_Practice_PropertyValue_for_PropertyName_and_PracticeID.Invoke(Connection, Transaction, new P_DO_GPPVfPNaPID_0916()
            {
                PracticeID = Parameter.ID,
                PropertyName = "Delivery date from"
            }, securityTicket).Result;
            if (quickOrderProperty != null)
            {
                practice_details.DeliveryDateFrom = deliveryDateFromProperty.TextValue;
            }
            else
            {
                practice_details.DeliveryDateFrom = "08:00";
            }

            var deliveryDateToProperty = cls_Get_Practice_PropertyValue_for_PropertyName_and_PracticeID.Invoke(Connection, Transaction, new P_DO_GPPVfPNaPID_0916()
            {
                PracticeID = Parameter.ID,
                PropertyName = "Delivery date to"
            }, securityTicket).Result;
            if (quickOrderProperty != null)
            {
                practice_details.DeliveryDateTo = deliveryDateToProperty.TextValue;
            }
            else
            {
                practice_details.DeliveryDateTo = "18:00";
            }

            var gracePeriodProperty = cls_Get_Practice_PropertyValue_for_PropertyName_and_PracticeID.Invoke(Connection, Transaction, new P_DO_GPPVfPNaPID_0916()
            {
                PracticeID = Parameter.ID,
                PropertyName = "Grace period"
            }, securityTicket).Result;
            if (gracePeriodProperty != null)
            {
                practice_details.UseGracePeriod = gracePeriodProperty.BooleanValue;
            }

            returnValue.Result = practice_details;

            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_DO_GPDD_1700 Invoke(string ConnectionString, P_DO_GPDD_1700 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_DO_GPDD_1700 Invoke(DbConnection Connection, P_DO_GPDD_1700 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_DO_GPDD_1700 Invoke(DbConnection Connection, DbTransaction Transaction, P_DO_GPDD_1700 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_DO_GPDD_1700 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_DO_GPDD_1700 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_DO_GPDD_1700 functionReturn = new FR_DO_GPDD_1700();
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

                throw new Exception("Exception occured in method cls_Get_Practice_DetailData", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Custom Return Type
    [Serializable]
    public class FR_DO_GPDD_1700 : FR_Base
    {
        public DO_GPDD_1700 Result { get; set; }

        public FR_DO_GPDD_1700() : base() { }

        public FR_DO_GPDD_1700(Exception ex) : base(ex) { }

    }
    #endregion

    #region Support Classes
    #region SClass P_DO_GPDD_1700 for attribute P_DO_GPDD_1700
    [DataContract]
    public class P_DO_GPDD_1700
    {
        //Standard type parameters
        [DataMember]
        public Guid ID { get; set; }

    }
    #endregion
    #region SClass DO_GPDD_1700 for attribute DO_GPDD_1700
    [DataContract]
    public class DO_GPDD_1700
    {
        //Standard type parameters
        [DataMember]
        public String bank { get; set; }
        [DataMember]
        public String bic { get; set; }
        [DataMember]
        public String address { get; set; }
        [DataMember]
        public String No { get; set; }
        [DataMember]
        public String bsnr { get; set; }
        [DataMember]
        public String email { get; set; }
        [DataMember]
        public String iban { get; set; }
        [DataMember]
        public String fax { get; set; }
        [DataMember]
        public String id { get; set; }
        [DataMember]
        public String phone { get; set; }
        [DataMember]
        public String name { get; set; }
        [DataMember]
        public String Zip { get; set; }
        [DataMember]
        public String town { get; set; }
        [DataMember]
        public String account_holder { get; set; }
        [DataMember]
        public int default_shipping_date_offset { get; set; }
        [DataMember]
        public String login_email { get; set; }
        [DataMember]
        public String password { get; set; }
        [DataMember]
        public String contact_email { get; set; }
        [DataMember]
        public String contact_person_name { get; set; }
        [DataMember]
        public String contact_telephone { get; set; }
        [DataMember]
        public bool IsSurgeryPractice { get; set; }
        [DataMember]
        public bool IsOrderDrugs { get; set; }
        [DataMember]
        public bool IsOnlyLabelRequired { get; set; }
        [DataMember]
        public bool isWaiveServiceFee { get; set; }
        [DataMember]
        public bool ShouldDownloadReportUponSubmission { get; set; }
        [DataMember]
        public bool PressEnterToSearch { get; set; }
        [DataMember]
        public bool PracticeHasOctDevice { get; set; }
        [DataMember]
        public String DefaultPharmacy { get; set; }
        [DataMember]
        public bool IsQuickOrderActive { get; set; }
        [DataMember]
        public String DeliveryDateFrom { get; set; }
        [DataMember]
        public String DeliveryDateTo { get; set; }
        [DataMember]
        public bool UseGracePeriod { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_DO_GPDD_1700 cls_Get_Practice_DetailData(,P_DO_GPDD_1700 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_DO_GPDD_1700 invocationResult = cls_Get_Practice_DetailData.Invoke(connectionString,P_DO_GPDD_1700 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Doctor.Complex.Retrieval.P_DO_GPDD_1700();
parameter.ID = ...;

*/
