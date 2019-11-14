/* 
 * Generated on 3/11/2015 10:14:10 AM
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
using CL2_PatientParameters.Complex.Retrieval;
using CL1_HEC;

namespace CL5_MyHealthClub_Examanations.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Vitals_for_ExaminationID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Vitals_for_ExaminationID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5EX_SVfEID_1440 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here
            var examination = ORM_HEC_ACT_PerformedAction.Query.Search(Connection, Transaction, new ORM_HEC_ACT_PerformedAction.Query()
            {
                HEC_ACT_PerformedActionID = Parameter.ExaminationID,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).Single();

            var patientID = examination.Patient_RefID;
            var allPatientParameters = cls_Get_all_PatientParameters_for_Tenant.Invoke(Connection, Transaction, securityTicket).Result.ToList();
        
            if (Parameter.HeartRate != null)
            {
                if (Parameter.HeartRate.Frequency != null)
                {
                    saveNewParameterValue(Connection, Transaction, patientID, Parameter.ExaminationID, Parameter.HeartRate.Frequency, "myhealtclub.gpapp.pulse-frequency", allPatientParameters, securityTicket);
                }
                if (Parameter.HeartRate.Rhythm != null)
                {
                    saveNewParameterValue(Connection, Transaction, patientID, Parameter.ExaminationID, Parameter.HeartRate.Rhythm, "myhealtclub.gpapp.pulse-rhytm", allPatientParameters, securityTicket);

                }
                if (Parameter.HeartRate.Volume != null)
                {
                    saveNewParameterValue(Connection, Transaction, patientID, Parameter.ExaminationID, Parameter.HeartRate.Volume, "myhealtclub.gpapp.pulse-volume", allPatientParameters, securityTicket);
                }
            }
            if (Parameter.BloodPressure != null)
            {
                if (Parameter.BloodPressure.Systolic != null)
                {
                    saveNewParameterValue(Connection, Transaction, patientID, Parameter.ExaminationID, Parameter.BloodPressure.Systolic, "myhealtclub.gpapp.preasure-sys", allPatientParameters, securityTicket);
                }
                if (Parameter.BloodPressure.Diastolic != null)
                {
                    saveNewParameterValue(Connection, Transaction, patientID, Parameter.ExaminationID, Parameter.BloodPressure.Diastolic, "myhealtclub.gpapp.preasure-dia", allPatientParameters, securityTicket);
                }
            }
            if (Parameter.BMI != null)
            {
                if (Parameter.BMI.Height != null)
                {
                    saveNewParameterValue(Connection, Transaction, patientID, Parameter.ExaminationID, Parameter.BMI.Height, "myhealtclub.gpapp.bmi-height", allPatientParameters, securityTicket);
                }
                if (Parameter.BMI.Weight != null)
                {
                    saveNewParameterValue(Connection, Transaction, patientID, Parameter.ExaminationID, Parameter.BMI.Weight, "myhealtclub.gpapp.bmi-weight", allPatientParameters, securityTicket);
                }
            }
            if (Parameter.BodyTemperature != null)
            {
                saveNewParameterValue(Connection, Transaction, patientID, Parameter.ExaminationID, Parameter.BodyTemperature, "myhealtclub.gpapp.body-temp", allPatientParameters, securityTicket);
            }
            if (Parameter.Oxygen_saturation != null)
            {
                saveNewParameterValue(Connection, Transaction, patientID, Parameter.ExaminationID, Parameter.Oxygen_saturation, "myhealtclub.gpapp.oxygen-saturation", allPatientParameters, securityTicket);

            }
            if (Parameter.Respiration != null)
            {
                saveNewParameterValue(Connection, Transaction, patientID, Parameter.ExaminationID, Parameter.Respiration, "myhealtclub.gpapp.respiration", allPatientParameters, securityTicket);

            }

            foreach (var custom in Parameter.CustomVitals)
            {
                saveNewParameterValue(Connection, Transaction, patientID, Parameter.ExaminationID, custom.Value, custom.PatientParameter_RefID.ToString(), allPatientParameters, securityTicket);
            }

			return returnValue;
			#endregion UserCode
		}
		#endregion

        private static void saveNewParameterValue(DbConnection Connection, DbTransaction Transaction, Guid patientID, Guid examinationID, string value, string parameterGlobalID, List<L2PP_GaPP_1554> allPatientParameters, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {


            ////EDIT

            ORM_HEC_Patient_ParameterValue parValue = null;
            bool isCustomVital = false;

            var performedActionpatientParameters = ORM_HEC_ACT_PerformedAction_PatientParameter.Query.Search(Connection, Transaction, new ORM_HEC_ACT_PerformedAction_PatientParameter.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted=false,
                HEC_ACT_PerformedAction_RefID = examinationID
            });
            var parameterValuesForExamination = new List<ORM_HEC_Patient_ParameterValue>();
            foreach (var perAvtionParValue in performedActionpatientParameters)
            {
                var parameterValue = ORM_HEC_Patient_ParameterValue.Query.Search(Connection, Transaction, new ORM_HEC_Patient_ParameterValue.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false,
                    HEC_Patient_ParameterValueID = perAvtionParValue.HEC_Patient_ParameterValue_RefID
                }).Single();
                parameterValuesForExamination.Add(parameterValue);
            }


            if(parameterGlobalID.Contains("myhealtclub.gpapp"))
            {
                var patientParameterID=allPatientParameters.Where(pp => pp.GlobalPropertyMatchingID == parameterGlobalID).Single().PatientParameter_ID;
                parValue = parameterValuesForExamination.Where(pv => pv.PatientParameter_RefID == patientParameterID).SingleOrDefault();
              
            }
            else
            {
                parValue = parameterValuesForExamination.Where(pv => pv.PatientParameter_RefID == Guid.Parse(parameterGlobalID)).SingleOrDefault(); 
                isCustomVital = true;
            }

            if (parValue != null)
            {
                if (isCustomVital)
                {
                    parValue.StringValue = value;
                    parValue.Modification_Timestamp = DateTime.Now;
                    parValue.Save(Connection, Transaction);
                }
                else if (parValue.PatientParameter_RefID == allPatientParameters.Where(pp => pp.GlobalPropertyMatchingID == parameterGlobalID).Single().PatientParameter_ID)
                {
                    parValue.StringValue = value;
                    parValue.Modification_Timestamp = DateTime.Now;
                    parValue.Save(Connection, Transaction);
                }
            }
            else
            {
                //SAVE
                ORM_HEC_Patient_ParameterValue ParameterValue = new ORM_HEC_Patient_ParameterValue();
                ParameterValue.Tenant_RefID = securityTicket.TenantID;
                ParameterValue.Patient_RefID = patientID;
                ParameterValue.StringValue = value;
                ParameterValue.IsDeleted = false;
                ParameterValue.DateOfValue = DateTime.Now;
                ParameterValue.Modification_Timestamp = DateTime.Now;
                if (isCustomVital)
                    ParameterValue.PatientParameter_RefID = Guid.Parse(parameterGlobalID);
                else
                    ParameterValue.PatientParameter_RefID = allPatientParameters.Where(pp => pp.GlobalPropertyMatchingID == parameterGlobalID).Single().PatientParameter_ID;
                ParameterValue.Save(Connection, Transaction);

                ORM_HEC_ACT_PerformedAction_PatientParameter papp = new ORM_HEC_ACT_PerformedAction_PatientParameter();
                papp.Tenant_RefID = securityTicket.TenantID;
                papp.HEC_ACT_PerformedAction_RefID = examinationID;
                papp.IsDeleted = false;
                papp.Modification_Timestamp = DateTime.Now;
                papp.HEC_Patient_ParameterValue_RefID = ParameterValue.HEC_Patient_ParameterValueID;
                papp.Save(Connection, Transaction);

            }
        }


		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5EX_SVfEID_1440 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5EX_SVfEID_1440 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5EX_SVfEID_1440 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5EX_SVfEID_1440 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Vitals_for_ExaminationID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5EX_SVfEID_1440 for attribute P_L5EX_SVfEID_1440
		[DataContract]
		public class P_L5EX_SVfEID_1440 
		{
			[DataMember]
			public P_L5EX_SVfEID_1440HeartPressure HeartRate { get; set; }
			[DataMember]
			public P_L5EX_SVfEID_1440BloodPressure BloodPressure { get; set; }
			[DataMember]
			public P_L5EX_SVfEID_1440BMI BMI { get; set; }
			[DataMember]
			public P_L5EX_SVfEID_1440_CustomVitals[] CustomVitals { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid ExaminationID { get; set; } 
			[DataMember]
			public String BodyTemperature { get; set; } 
			[DataMember]
			public String Oxygen_saturation { get; set; } 
			[DataMember]
			public String Respiration { get; set; } 

		}
		#endregion
		#region SClass P_L5EX_SVfEID_1440HeartPressure for attribute HeartRate
		[DataContract]
		public class P_L5EX_SVfEID_1440HeartPressure 
		{
			//Standard type parameters
			[DataMember]
			public String Volume { get; set; } 
			[DataMember]
			public String Rhythm { get; set; } 
			[DataMember]
			public String Frequency { get; set; } 

		}
		#endregion
		#region SClass P_L5EX_SVfEID_1440BloodPressure for attribute BloodPressure
		[DataContract]
		public class P_L5EX_SVfEID_1440BloodPressure 
		{
			//Standard type parameters
			[DataMember]
			public String Systolic { get; set; } 
			[DataMember]
			public String Diastolic { get; set; } 

		}
		#endregion
		#region SClass P_L5EX_SVfEID_1440BMI for attribute BMI
		[DataContract]
		public class P_L5EX_SVfEID_1440BMI 
		{
			//Standard type parameters
			[DataMember]
			public String Height { get; set; } 
			[DataMember]
			public String Weight { get; set; } 

		}
		#endregion
		#region SClass P_L5EX_SVfEID_1440_CustomVitals for attribute CustomVitals
		[DataContract]
		public class P_L5EX_SVfEID_1440_CustomVitals 
		{
			//Standard type parameters
			[DataMember]
			public Guid PatientParameter_RefID { get; set; } 
			[DataMember]
			public string Value { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Vitals_for_ExaminationID(,P_L5EX_SVfEID_1440 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Vitals_for_ExaminationID.Invoke(connectionString,P_L5EX_SVfEID_1440 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_Examanations.Complex.Manipulation.P_L5EX_SVfEID_1440();
parameter.HeartRate = ...;
parameter.BloodPressure = ...;
parameter.BMI = ...;
parameter.CustomVitals = ...;

parameter.ExaminationID = ...;
parameter.BodyTemperature = ...;
parameter.Oxygen_saturation = ...;
parameter.Respiration = ...;

*/
