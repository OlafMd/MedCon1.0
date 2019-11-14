/* 
 * Generated on 2/9/2015 6:11:48 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Linq;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;
using CL5_MyHealthClub_Examanations.Atomic.Retrieval;
using CL5_MyHealthClub_MedProCommunity.Atomic.Retrieval;

namespace CL5_MyHealthClub_Examinations.Complex.Retrieval
{
	[Serializable]
	public class cls_Get_AllPatient_DiagnoseDataOnInit
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5EX_GAPDDOI_1644 Execute(DbConnection Connection,DbTransaction Transaction,P_L5EX_GAPDDOI_1644 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5EX_GAPDDOI_1644();
            returnValue.Result = new L5EX_GAPDDOI_1644();
            List<L5EX_GAPDDOI_1644_patient_diagnoses> patient_diagnoses = new List<L5EX_GAPDDOI_1644_patient_diagnoses>();
            returnValue.Result.patient_diagnoses = patient_diagnoses.ToArray();

            returnValue.Result.diagnoses = cls_Get_Diagnoses_Elasticc.Invoke(Connection, Transaction, new P_L5MPC_GDE_1412
            {
                number_of_elements = Parameter.number_of_elements,
                search_params = Parameter.search_params,
                sort_by = Parameter.sort_by,
                sort_order = Parameter.sort_order,
                start_row_index = Parameter.start_row_index

            }, securityTicket).Result;

            var patient_diagnoses_list = cls_Get_Examination_Diagnoses.Invoke(Connection, Transaction, new P_L5EX_GED_1640 {
            
            ExaminationID = Parameter.ExaminationID,
            PatientID = Parameter.PatientID
            }, securityTicket).Result.ToList();

            foreach (var item in patient_diagnoses_list)
            {
                int days_active=0;
                if (item.R_ScheduledExpiryDate > DateTime.Now)
                {
                    TimeSpan span = item.R_ScheduledExpiryDate.Subtract(DateTime.Now);
                    days_active = span.Days;
                }

                L5EX_GAPDDOI_1644_patient_diagnoses diagnose = new L5EX_GAPDDOI_1644_patient_diagnoses();
                diagnose.date = item.R_ScheduledExpiryDate.ToShortDateString();
                diagnose.days_active = days_active.ToString();
                diagnose.icd_10 = item.ICD10_Code;
                diagnose.id = item.HEC_Patient_DiagnosisID.ToString();
                diagnose.itl = item.PotentialDiagnosisITL.ToString();
                diagnose.name = item.PotentialDiagnosis_Name.Contents[0].Content;
                patient_diagnoses.Add(diagnose);
            }

            returnValue.Result.patient_diagnoses = patient_diagnoses.ToArray();
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5EX_GAPDDOI_1644 Invoke(string ConnectionString,P_L5EX_GAPDDOI_1644 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5EX_GAPDDOI_1644 Invoke(DbConnection Connection,P_L5EX_GAPDDOI_1644 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5EX_GAPDDOI_1644 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5EX_GAPDDOI_1644 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5EX_GAPDDOI_1644 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5EX_GAPDDOI_1644 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5EX_GAPDDOI_1644 functionReturn = new FR_L5EX_GAPDDOI_1644();
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

				throw ex;
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5EX_GAPDDOI_1644 : FR_Base
	{
		public L5EX_GAPDDOI_1644 Result	{ get; set; }

		public FR_L5EX_GAPDDOI_1644() : base() {}

		public FR_L5EX_GAPDDOI_1644(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5EX_GAPDDOI_1644 for attribute P_L5EX_GAPDDOI_1644
		[Serializable]
		public class P_L5EX_GAPDDOI_1644 
		{
			//Standard type parameters
			public Guid ExaminationID; 
			public Guid PatientID; 
			public int start_row_index; 
			public int number_of_elements; 
			public String sort_by; 
			public String sort_order; 
			public String search_params; 
			public bool is_substance_count; 

		}
		#endregion
		#region SClass L5EX_GAPDDOI_1644 for attribute L5EX_GAPDDOI_1644
		[Serializable]
		public class L5EX_GAPDDOI_1644 
		{
			public L5EX_GAPDDOI_1644_patient_diagnoses[] patient_diagnoses;
            public L5MPC_GDE_1412 diagnoses;  

			//Standard type parameters
		}
		#endregion
		#region SClass L5EX_GAPDDOI_1644_patient_diagnoses for attribute patient_diagnoses
		[Serializable]
		public class L5EX_GAPDDOI_1644_patient_diagnoses 
		{
			//Standard type parameters
			public String id; 
			public String name; 
			public String icd_10; 
			public String date; 
			public String itl; 
			public String days_active; 

		}
		#endregion

	#endregion
}
