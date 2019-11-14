/* 
 * Generated on 12/8/2014 2:19:25 PM
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
using CL5_Lucentis_Aftercare.Atomic.Retrieval;
using CL5_Lucentis_Aftercare.Utile;

namespace CL5_Lucentis_Aftercare.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_AftercareData.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_AftercareData
	{
		public static readonly int QueryTimeout = 6000;

		#region Method Execution
		protected static FR_L6AC_GA_1738 Execute(DbConnection Connection,DbTransaction Transaction,P_L6AC_GA_1738 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L6AC_GA_1738();
            L6AC_GA_1738 Data = new L6AC_GA_1738();
            List<L6AC_GA_1738_Aftercare> Aftercares = new List<L6AC_GA_1738_Aftercare>();
            int IsBilled = Parameter.SearchParameters.s_isBilled == true ? 1 : 0;
            int IsPerformed = Parameter.SearchParameters.s_isPerformed == true ? 1 : 0;
            int IsSheduled = Parameter.SearchParameters.s_isScheduled == true ? 1 : 0;

            /*@Get Total_Record_Count, 
            *------------------------------------------------*/
            Data.page_size = Parameter.NumberOfElementsPerPage;
            Data.current_page = Parameter.PageClicked;

            if (Parameter.SearchParameters.s_patientFirstName == "" && Parameter.SearchParameters.s_patientLastName == ""
                && Parameter.SearchParameters.s_healtInsurance == "" && Parameter.SearchParameters.s_doctorFirstName == ""
                && Parameter.SearchParameters.s_doctorLastName == "")
            {

                #region
                P_L5AF_GAC_1132 count_param = new P_L5AF_GAC_1132();
                count_param.S_Practice = SearchMethods.getPracticeParameter(Parameter.SearchParameters.s_practice);
                count_param.statusParameters = SearchMethods.getStatusParameter(IsBilled, IsPerformed, IsSheduled, Parameter.SearchParameters.s_aftercareFrom, Parameter.SearchParameters.s_aftercareTo);
                count_param.s_doctorParam = "";
                count_param.s_scheduled_doctorParam = "";         
                var recordCount = cls_Get_AftercareCount.Invoke(Connection, Transaction, count_param, securityTicket).Result.total_record_count;
               Data.total_record_count = recordCount;
                Data.total_page_count = (recordCount + Parameter.NumberOfElementsPerPage - 1) / Parameter.NumberOfElementsPerPage;
                var startRowIndex = (Parameter.PageClicked - 1) * Parameter.NumberOfElementsPerPage;
                Data.start_row_index = startRowIndex;
                Data.end_row_index = startRowIndex + Data.page_size > recordCount ? recordCount : startRowIndex + Data.page_size;

                /*@Get Aftercares
                *------------------------------------------------*/

                P_L5AF_GABD_1107 par = new P_L5AF_GABD_1107();
                if (Parameter.IsASC_Order == false)
                    par.OrderBy = "DESC";
                else
                    par.OrderBy = "ASC";
                par.OrderValue = Parameter.OrderValue;
                par.StartIndex = startRowIndex;
                par.NumberOfElements = Parameter.NumberOfElementsPerPage;
                par.S_Practice = count_param.S_Practice;
                par.statusParameters = count_param.statusParameters;
                par.s_doctorParam = count_param.s_doctorParam;
                par.s_scheduled_doctorParam = count_param.s_scheduled_doctorParam;

                var aftercareBaseData = cls_Get_AftercareBaseData.Invoke(Connection, Transaction, par, securityTicket).Result.ToList();
        
                foreach (var item in aftercareBaseData)
                {
                    P_L5AF_GADFFIDATID_1307 parameter = new P_L5AF_GADFFIDATID_1307();
                    parameter.FollowupID = item.FollowupID;
                    parameter.TreatmentID = item.TreatmentID;
                    L6AC_GA_1738_Aftercare aftercare = new L6AC_GA_1738_Aftercare();
                    aftercare.id = item.FollowupID.ToString();
                    aftercare.practice = item.Practice;

                    if (item.IsTreatmentBilled)
                    {
                        aftercare.status = "billed";
                        aftercare.status_date = item.IfTreatmentBilled_Date;
                    }
                    else if (item.IsTreatmentPerformed)
                    {
                        aftercare.status = "performed";
                        aftercare.status_date = item.IfTreatmentPerformed_Date;
                    }
                    else
                    {
                        aftercare.status = "sheduled";
                        aftercare.status_date = item.IfSheduled_Date;
                        aftercare.doctor = item.SheduledDoctorTitle + " " + item.SheduledDoctorFirstName + " " + item.SheduledDoctorLastName;
                    }

                    if (item.IsTreatmentPerformed)
                        aftercare.doctor = item.PerformedDoctorTitle + " " + item.PerformedDoctorFirstName + " " + item.PerformedDoctorLastName;

                    aftercare.status_name = aftercare.status;
                    var otherPartData = cls_Get_AftercareData_for_FollowupID_and_TenantID.Invoke(Connection, Transaction, parameter, securityTicket).Result;
                    if (otherPartData == null)
                        continue;
                  
                    aftercare.patient_name = otherPartData.PatientFirstName + " " + otherPartData.PatientLastName;
                    aftercare.health_insurance = otherPartData.HealthInsurance;
                    aftercare.treatment_date = otherPartData.TreatmentDate;
                    Aftercares.Add(aftercare);
                }
                #endregion
            }
            else if(Parameter.SearchParameters.s_doctorFirstName != "" || Parameter.SearchParameters.s_doctorLastName != "")
            {
                #region
                P_L5AF_GAACFDS_1252 count_param = new P_L5AF_GAACFDS_1252();
                count_param.S_Practice = SearchMethods.getPracticeParameter(Parameter.SearchParameters.s_practice);
                count_param.statusParameters = SearchMethods.getStatusParameter(IsBilled, IsPerformed, IsSheduled, Parameter.SearchParameters.s_aftercareFrom, Parameter.SearchParameters.s_aftercareTo);
                count_param.s_Patient = SearchMethods.getPatientParameter(Parameter.SearchParameters.s_patientFirstName, Parameter.SearchParameters.s_patientLastName);
                count_param.s_HealthInsurance = SearchMethods.getPracticeParameter(Parameter.SearchParameters.s_healtInsurance);
                count_param.s_doctorParam = SearchMethods.getPerformedDoctorParameter(Parameter.SearchParameters.s_doctorFirstName, Parameter.SearchParameters.s_doctorLastName);
                count_param.s_scheduled_doctorParam = SearchMethods.getScheduledDoctorParameter(Parameter.SearchParameters.s_doctorFirstName, Parameter.SearchParameters.s_doctorLastName);
                var recordCount = cls_Get_AftercareAllCount_for_doctorSearch.Invoke(Connection, Transaction, count_param, securityTicket).Result.total_record_count;
                Data.total_record_count = recordCount;
                Data.total_page_count = (recordCount + Parameter.NumberOfElementsPerPage - 1) / Parameter.NumberOfElementsPerPage;
                var startRowIndex = (Parameter.PageClicked - 1) * Parameter.NumberOfElementsPerPage;
                Data.start_row_index = startRowIndex;
                Data.end_row_index = startRowIndex + Data.page_size > recordCount ? recordCount : startRowIndex + Data.page_size;

                /*@Get Aftercares
               *------------------------------------------------*/
                P_L5AF_GAADFDS_1107 par = new P_L5AF_GAADFDS_1107();
                if (Parameter.IsASC_Order == false)
                    par.OrderBy = "DESC";
                else
                    par.OrderBy = "ASC";
                par.OrderValue = Parameter.OrderValue;
                par.StartIndex = startRowIndex;
                par.NumberOfElements = Parameter.NumberOfElementsPerPage;
                par.S_Practice = count_param.S_Practice;
                par.statusParameters = count_param.statusParameters;
                par.s_Patient = count_param.s_Patient;
                par.s_HealthInsurance = count_param.s_HealthInsurance;
                par.s_doctorParam = count_param.s_doctorParam;
                par.s_scheduled_doctorParam = count_param.s_scheduled_doctorParam;

                var aftercareData = cls_Get_AftercareAllData_for_doctorSearch.Invoke(Connection, Transaction, par, securityTicket).Result.ToList();

                foreach (var item in aftercareData)
                {
                    L6AC_GA_1738_Aftercare aftercare = new L6AC_GA_1738_Aftercare();
                    aftercare.id = item.FollowupID.ToString();
                    aftercare.practice = item.Practice;

                    if (item.IsTreatmentBilled)
                    {
                        aftercare.status = "billed";
                    }
                    else if (item.IsTreatmentPerformed)
                    {
                        aftercare.status = "performed";
                    }
                    else
                    {
                        aftercare.status = "sheduled";
                        aftercare.doctor = item.SheduledDoctorTitle + " " + item.SheduledDoctorFirstName + " " + item.SheduledDoctorLastName;
                    }
                    aftercare.status_date = item.FolllowupDate;
                    if (item.IsTreatmentPerformed)
                        aftercare.doctor = item.PerformedDoctorTitle + " " + item.PerformedDoctorFirstName + " " + item.PerformedDoctorLastName;

                    aftercare.status_name = aftercare.status;
                    aftercare.patient_name = item.PatientFirstName + " " + item.PatientLastName;
                    aftercare.health_insurance = item.HealthInsurance;
                    aftercare.treatment_date = item.TreatmentDate;
                    Aftercares.Add(aftercare);
                }
                #endregion
            }
            else
            {
                #region
                P_L5AF_GAAC_1732 count_param = new P_L5AF_GAAC_1732();
                count_param.S_Practice = SearchMethods.getPracticeParameter(Parameter.SearchParameters.s_practice);
                count_param.statusParameters = SearchMethods.getStatusParameter(IsBilled, IsPerformed, IsSheduled, Parameter.SearchParameters.s_aftercareFrom, Parameter.SearchParameters.s_aftercareTo);
                count_param.s_Patient = SearchMethods.getPatientParameter(Parameter.SearchParameters.s_patientFirstName, Parameter.SearchParameters.s_patientLastName);
                count_param.s_HealthInsurance = SearchMethods.getPracticeParameter(Parameter.SearchParameters.s_healtInsurance);
               // count_param.s_doctorParam = SearchMethods.getPerformedDoctorParameter(Parameter.SearchParameters.s_doctorFirstName, Parameter.SearchParameters.s_doctorLastName);
               // count_param.s_scheduled_doctorParam = SearchMethods.getScheduledDoctorParameter(Parameter.SearchParameters.s_doctorFirstName, Parameter.SearchParameters.s_doctorLastName);
                count_param.s_doctorParam = "";
                count_param.s_scheduled_doctorParam = "";              
                var recordCount = cls_Get_AftercareAllCount.Invoke(Connection, Transaction, count_param, securityTicket).Result.total_record_count;
                Data.total_record_count = recordCount;
                Data.total_page_count = (recordCount + Parameter.NumberOfElementsPerPage - 1) / Parameter.NumberOfElementsPerPage;
                var startRowIndex = (Parameter.PageClicked - 1) * Parameter.NumberOfElementsPerPage;
                Data.start_row_index = startRowIndex;
                Data.end_row_index = startRowIndex + Data.page_size > recordCount ? recordCount : startRowIndex + Data.page_size;

                /*@Get Aftercares
               *------------------------------------------------*/
                P_L5AF_GAAD_1607 par = new P_L5AF_GAAD_1607();
                if (Parameter.IsASC_Order == false)
                    par.OrderBy = "DESC";
                else
                    par.OrderBy = "ASC";
                par.OrderValue = Parameter.OrderValue;
                par.StartIndex = startRowIndex;
                par.NumberOfElements = Parameter.NumberOfElementsPerPage;
                par.S_Practice = count_param.S_Practice;
                par.statusParameters = count_param.statusParameters;
                par.s_Patient = count_param.s_Patient;
                par.s_HealthInsurance = count_param.s_HealthInsurance;
                par.s_doctorParam = count_param.s_doctorParam;
                par.s_scheduled_doctorParam = count_param.s_scheduled_doctorParam;

                var aftercareData = cls_Get_AftercareAllData.Invoke(Connection, Transaction, par, securityTicket).Result.ToList();

                foreach (var item in aftercareData)
                {
                    L6AC_GA_1738_Aftercare aftercare = new L6AC_GA_1738_Aftercare();
                    aftercare.id = item.FollowupID.ToString();
                    aftercare.practice = item.Practice;

                    if (item.IsTreatmentBilled)
                    {
                        aftercare.status = "billed";
                    }
                    else if (item.IsTreatmentPerformed)
                    {
                        aftercare.status = "performed";
                    }
                    else
                    {
                        aftercare.status = "sheduled";
                        aftercare.doctor = item.SheduledDoctorTitle + " " + item.SheduledDoctorFirstName + " " + item.SheduledDoctorLastName;
                    }
                    aftercare.status_date = item.FolllowupDate;
                    if (item.IsTreatmentPerformed)
                        aftercare.doctor = item.PerformedDoctorTitle + " " + item.PerformedDoctorFirstName + " " + item.PerformedDoctorLastName;

                    aftercare.status_name = aftercare.status;
                    aftercare.patient_name = item.PatientFirstName + " " + item.PatientLastName;
                    aftercare.health_insurance = item.HealthInsurance;
                    aftercare.treatment_date = item.TreatmentDate;
                    Aftercares.Add(aftercare);
                }
                #endregion
            }
            Data.aftercares = Aftercares.ToArray();
            returnValue.Result = Data;
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6AC_GA_1738 Invoke(string ConnectionString,P_L6AC_GA_1738 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6AC_GA_1738 Invoke(DbConnection Connection,P_L6AC_GA_1738 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6AC_GA_1738 Invoke(DbConnection Connection, DbTransaction Transaction,P_L6AC_GA_1738 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6AC_GA_1738 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6AC_GA_1738 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6AC_GA_1738 functionReturn = new FR_L6AC_GA_1738();
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

				throw new Exception("Exception occured in method cls_Get_AftercareData",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6AC_GA_1738 : FR_Base
	{
		public L6AC_GA_1738 Result	{ get; set; }

		public FR_L6AC_GA_1738() : base() {}

		public FR_L6AC_GA_1738(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6AC_GA_1738 for attribute P_L6AC_GA_1738
		[DataContract]
		public class P_L6AC_GA_1738 
		{
			[DataMember]
			public P_L6AC_GA_1738_SearchParams SearchParameters { get; set; }

			//Standard type parameters
			[DataMember]
			public bool IsASC_Order { get; set; } 
			[DataMember]
			public String OrderValue { get; set; } 
			[DataMember]
			public int PageClicked { get; set; } 
			[DataMember]
			public int NumberOfElementsPerPage { get; set; } 

		}
		#endregion
		#region SClass P_L6AC_GA_1738_SearchParams for attribute SearchParameters
		[DataContract]
		public class P_L6AC_GA_1738_SearchParams 
		{
			//Standard type parameters
			[DataMember]
			public String s_practice { get; set; } 
			[DataMember]
			public String s_doctorFirstName { get; set; } 
			[DataMember]
			public String s_doctorLastName { get; set; } 
			[DataMember]
			public String s_aftercareFrom { get; set; } 
			[DataMember]
			public String s_aftercareTo { get; set; } 
			[DataMember]
			public bool s_isScheduled { get; set; } 
			[DataMember]
			public bool s_isPerformed { get; set; } 
			[DataMember]
			public bool s_isBilled { get; set; } 
			[DataMember]
			public String s_patientFirstName { get; set; } 
			[DataMember]
			public String s_patientLastName { get; set; } 
			[DataMember]
			public String s_healtInsurance { get; set; } 

		}
		#endregion
		#region SClass L6AC_GA_1738 for attribute L6AC_GA_1738
		[DataContract]
		public class L6AC_GA_1738 
		{
			[DataMember]
			public L6AC_GA_1738_Aftercare[] aftercares { get; set; }

			//Standard type parameters
			[DataMember]
			public int start_row_index { get; set; } 
			[DataMember]
			public int end_row_index { get; set; } 
			[DataMember]
			public int page_size { get; set; } 
			[DataMember]
			public int current_page { get; set; } 
			[DataMember]
			public int total_page_count { get; set; } 
			[DataMember]
			public int total_record_count { get; set; } 

		}
		#endregion
		#region SClass L6AC_GA_1738_Aftercare for attribute aftercares
		[DataContract]
		public class L6AC_GA_1738_Aftercare 
		{
			//Standard type parameters
			[DataMember]
			public String id { get; set; } 
			[DataMember]
			public String practice { get; set; } 
			[DataMember]
			public DateTime treatment_date { get; set; } 
			[DataMember]
			public String doctor { get; set; } 
			[DataMember]
			public String status { get; set; } 
			[DataMember]
			public String status_name { get; set; } 
			[DataMember]
			public DateTime status_date { get; set; } 
			[DataMember]
			public String patient_name { get; set; } 
			[DataMember]
			public String health_insurance { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6AC_GA_1738 cls_Get_AftercareData(,P_L6AC_GA_1738 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6AC_GA_1738 invocationResult = cls_Get_AftercareData.Invoke(connectionString,P_L6AC_GA_1738 Parameter,securityTicket);
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
var parameter = new CL5_Lucentis_Aftercare.Complex.Retrieval.P_L6AC_GA_1738();
parameter.SearchParameters = ...;

parameter.IsASC_Order = ...;
parameter.OrderValue = ...;
parameter.PageClicked = ...;
parameter.NumberOfElementsPerPage = ...;

*/
