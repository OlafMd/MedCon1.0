/* 
 * Generated on 2/8/2017 10:30:03 AM
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
using MMDocConnectDBMethods.Case.Atomic.Retrieval;
using MMDocConnectDocApp;
using MMDocConnectUtils;

namespace MMDocConnectDBMethods.Case.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Case_Details_for_CaseID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Case_Details_for_CaseID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_CAS_GCDfCID_1435 Execute(DbConnection Connection,DbTransaction Transaction,P_CAS_GCDfCID_1435 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_CAS_GCDfCID_1435();
            returnValue.Result = new CAS_GCDfCID_1435();
            //Put your code here
            var base_data = cls_Get_Case_BaseData_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GCBDfCID_1054() { CaseID = Parameter.CaseID }, securityTicket).Result;
            if (base_data != null)
            {                
                #region Base data
                returnValue.Result.case_id = base_data.case_id;
                returnValue.Result.drug_id = base_data.drug_id;
                returnValue.Result.treatment_date = base_data.treatment_date;
                returnValue.Result.treatment_doctor_id = base_data.treatment_doctor_bpt_id;
                returnValue.Result.practice_id = base_data.practice_id;
                returnValue.Result.case_number = base_data.case_number;
                #endregion

                #region Patient
                returnValue.Result.patient_display_name = base_data.patient_display_name;
                returnValue.Result.patient_id = base_data.patient_id;
                returnValue.Result.Patient_Age = base_data.patient_age;
                returnValue.Result.Patient_BirthDate = base_data.patient_birthdate;
                returnValue.Result.Patient_FirstName = base_data.patient_first_name;
                returnValue.Result.Patient_Gender = base_data.patient_gender;
                returnValue.Result.Patient_LastName = base_data.patient_last_name;
                #endregion

                #region Drug order
                var order_data = cls_Get_Case_Order_Data_for_OrderID.Invoke(Connection, Transaction, new P_CAS_GCODfOID_1156() { OrderID = base_data.drug_order_position_id }, securityTicket).Result;
                
                returnValue.Result.order_status = "";
                if (order_data != null)
                {
                    returnValue.Result.order_comment = order_data.order_comment;
                    returnValue.Result.order_id = base_data.drug_order_position_id;
                    returnValue.Result.order_modification_timestamp = order_data.order_modification_timestamp;
                    returnValue.Result.order_status_code = order_data.order_status_code;
                    returnValue.Result.alternative_delivery_date_from = order_data.alternative_delivery_date_from;
                    returnValue.Result.alternative_delivery_date_to = order_data.alternative_delivery_date_to;
                    returnValue.Result.delivery_date = order_data.delivery_date;
                    returnValue.Result.is_patient_fee_waived = order_data.is_patient_fee_waived;
                    returnValue.Result.is_label_only = order_data.is_label_only;
                    returnValue.Result.order_status = "MO" + order_data.order_status_code;
                }
                #endregion

                #region Treatment
                returnValue.Result.treatment_planned_action_id = base_data.treatment_planned_action_id;
                var treatment_data = cls_Get_Case_Treatment_Data_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GCTDfCID_1143() { CaseID = Parameter.CaseID }, securityTicket).Result;
                if (treatment_data != null)
                {
                    returnValue.Result.diagnose_id = treatment_data.diagnose_id;
                    returnValue.Result.localization = treatment_data.localization;
                    returnValue.Result.op_doctor_id = treatment_data.op_doctor_id;
                    returnValue.Result.is_confirmed = treatment_data.is_confirmed;
                }
                #endregion

                #region Aftercare
                var aftercare_planned_action_data = cls_Get_Case_PlannedActionData_for_CaseID_and_ActionTypeGpmID.Invoke(Connection, Transaction, new P_CAS_GCPADfCIDaATGpmID_1235()
                {
                    CaseID = Parameter.CaseID,
                    ActionTypeGpmID = "mm.docconect.doc.app.planned.action.aftercare"
                }, securityTicket).Result;

                if (aftercare_planned_action_data != null)
                {
                    returnValue.Result.aftercare_planned_action_id = aftercare_planned_action_data.planned_action_id;
                    returnValue.Result.aftercare_performed_date = aftercare_planned_action_data.performed_on_date;

                    var aftercare_doctor = cls_Get_Case_DoctorData_for_DoctorBptID.Invoke(Connection, Transaction, new P_CAS_GCDDfDBptID_1242() { DoctorBptID = aftercare_planned_action_data.to_be_performed_by_bpt_id }, securityTicket).Result;
                    if (aftercare_doctor != null)
                    {
                        returnValue.Result.ac_doctor_id = aftercare_doctor.id;
                        returnValue.Result.aftercare_doctor_display_name = GenericUtils.GetDoctorName(aftercare_doctor);
                        returnValue.Result.aftercare_doctors_practice_id = aftercare_doctor.practice_id;
                        returnValue.Result.is_aftercare_doctor = true;
                    }
                    else
                    {
                        var aftercare_practice = cls_Get_Case_PracticeData_for_PracticeBptID.Invoke(Connection, Transaction, new P_CAS_GCPDfPBptID_1248() { PracticeBptID = aftercare_planned_action_data.to_be_performed_by_bpt_id }, securityTicket).Result;
                        if (aftercare_practice != null)
                        {
                            returnValue.Result.ac_practice_id = aftercare_practice.id;
                            returnValue.Result.aftercare_practice_display_name = aftercare_practice.name;
                            returnValue.Result.is_aftercare_practice = true;
                        }
                    }
                }
                #endregion

                #region Oct
                var oct_planned_action_data = cls_Get_Case_PlannedActionData_for_CaseID_and_ActionTypeGpmID.Invoke(Connection, Transaction, new P_CAS_GCPADfCIDaATGpmID_1235()
                {
                    CaseID = Parameter.CaseID,
                    ActionTypeGpmID = EActionType.PlannedOct.Value()
                }, securityTicket).Result;

                if (oct_planned_action_data != null)
                {
                    var oct_doctor = cls_Get_Case_DoctorData_for_DoctorBptID.Invoke(Connection, Transaction, new P_CAS_GCDDfDBptID_1242() { DoctorBptID = oct_planned_action_data.to_be_performed_by_bpt_id }, securityTicket).Result;
                    if (oct_doctor != null)
                    {
                        returnValue.Result.oct_doctor_id = oct_doctor.id;
                        returnValue.Result.oct_doctor_display_name = GenericUtils.GetDoctorName(oct_doctor);
                    }

                }
                #endregion

                #region Case properties
                var properties = cls_Get_Case_Properties_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GCPfCID_1204() { CaseID = Parameter.CaseID }, securityTicket).Result;
                if (properties.Any())
                {
                    var invoice_to_practice = properties.SingleOrDefault(t => t.property_gpmid == "mm.doc.connect.case.practice.invoice");
                    var documentation_only = properties.SingleOrDefault(t => t.property_gpmid == "mm.doc.connect.case.is.for.documentation.only");

                    if (invoice_to_practice != null)
                    {
                        returnValue.Result.is_send_invoice_to_practice = invoice_to_practice.boolean_value;
                    }

                    if (documentation_only != null)
                    {
                        returnValue.Result.is_documentation_only = documentation_only.boolean_value;
                    }
                }
                #endregion
            }

            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_CAS_GCDfCID_1435 Invoke(string ConnectionString,P_CAS_GCDfCID_1435 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_CAS_GCDfCID_1435 Invoke(DbConnection Connection,P_CAS_GCDfCID_1435 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_CAS_GCDfCID_1435 Invoke(DbConnection Connection, DbTransaction Transaction,P_CAS_GCDfCID_1435 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_CAS_GCDfCID_1435 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_CAS_GCDfCID_1435 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_CAS_GCDfCID_1435 functionReturn = new FR_CAS_GCDfCID_1435();
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

				throw new Exception("Exception occured in method cls_Get_Case_Details_for_CaseID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_CAS_GCDfCID_1435 : FR_Base
	{
		public CAS_GCDfCID_1435 Result	{ get; set; }

		public FR_CAS_GCDfCID_1435() : base() {}

		public FR_CAS_GCDfCID_1435(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_CAS_GCDfCID_1435 for attribute P_CAS_GCDfCID_1435
		[DataContract]
		public class P_CAS_GCDfCID_1435 
		{
			//Standard type parameters
			[DataMember]
			public Guid CaseID { get; set; } 

		}
		#endregion
		#region SClass CAS_GCDfCID_1435 for attribute CAS_GCDfCID_1435
		[DataContract]
		public class CAS_GCDfCID_1435 
		{
			//Standard type parameters
			[DataMember]
			public Guid patient_id { get; set; } 
			[DataMember]
			public Guid case_id { get; set; } 
			[DataMember]
			public String patient_display_name { get; set; } 
			[DataMember]
			public DateTime treatment_date { get; set; } 
			[DataMember]
			public Guid drug_id { get; set; } 
			[DataMember]
			public Boolean is_patient_fee_waived { get; set; } 
			[DataMember]
			public Boolean is_label_only { get; set; } 
			[DataMember]
			public Boolean is_send_invoice_to_practice { get; set; } 
			[DataMember]
			public Guid order_id { get; set; } 
			[DataMember]
			public DateTime alternative_delivery_date_from { get; set; } 
			[DataMember]
			public DateTime alternative_delivery_date_to { get; set; } 
			[DataMember]
			public DateTime delivery_date { get; set; } 
			[DataMember]
			public Guid diagnose_id { get; set; } 
			[DataMember]
			public String localization { get; set; } 
			[DataMember]
			public Boolean is_confirmed { get; set; } 
			[DataMember]
			public Guid op_doctor_id { get; set; } 
			[DataMember]
			public Guid ac_doctor_id { get; set; } 
			[DataMember]
			public Guid ac_practice_id { get; set; } 
			[DataMember]
			public Boolean is_aftercare_doctor { get; set; } 
			[DataMember]
			public Boolean is_aftercare_practice { get; set; } 
			[DataMember]
			public String aftercare_doctor_display_name { get; set; } 
			[DataMember]
			public String aftercare_practice_display_name { get; set; } 
			[DataMember]
			public int order_status_code { get; set; } 
			[DataMember]
			public String Patient_FirstName { get; set; } 
			[DataMember]
			public String Patient_LastName { get; set; } 
			[DataMember]
			public int Patient_Gender { get; set; } 
			[DataMember]
			public int Patient_Age { get; set; } 
			[DataMember]
			public DateTime Patient_BirthDate { get; set; } 
			[DataMember]
			public Guid treatment_doctor_id { get; set; } 
			[DataMember]
			public DateTime order_modification_timestamp { get; set; } 
			[DataMember]
			public Guid practice_id { get; set; } 
			[DataMember]
			public Guid aftercare_planned_action_id { get; set; } 
			[DataMember]
			public Guid treatment_planned_action_id { get; set; } 
			[DataMember]
			public Guid aftercare_doctors_practice_id { get; set; } 
			[DataMember]
			public DateTime aftercare_performed_date { get; set; } 
			[DataMember]
			public String order_comment { get; set; } 
			[DataMember]
			public String oct_doctor_display_name { get; set; } 
			[DataMember]
			public Guid oct_doctor_id { get; set; } 
			[DataMember]
			public Boolean is_documentation_only { get; set; } 
			[DataMember]
			public String case_number { get; set; } 
			[DataMember]
			public String order_status { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_CAS_GCDfCID_1435 cls_Get_Case_Details_for_CaseID(,P_CAS_GCDfCID_1435 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_CAS_GCDfCID_1435 invocationResult = cls_Get_Case_Details_for_CaseID.Invoke(connectionString,P_CAS_GCDfCID_1435 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Case.Complex.Retrieval.P_CAS_GCDfCID_1435();
parameter.CaseID = ...;

*/
