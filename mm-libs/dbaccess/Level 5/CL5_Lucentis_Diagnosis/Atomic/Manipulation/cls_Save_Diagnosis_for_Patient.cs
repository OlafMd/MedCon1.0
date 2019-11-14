/* 
 * Generated on 8/14/2013 12:06:21 PM
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
using CL1_HEC;

namespace CL5_Lucentis_Diagnosis.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Diagnosis_for_Patient.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Diagnosis_for_Patient
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5DG_SDfP_17_02 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();


            #region New

            for (int i = 0; i < Parameter.PatientDiagnosis.Length; i++)
            {
                ORM_HEC_Patient_Diagnosis item = new ORM_HEC_Patient_Diagnosis();
                ORM_HEC_Patient_Diagnosis_Localization localization = new ORM_HEC_Patient_Diagnosis_Localization();


                if (Parameter.PatientDiagnosis[i].HEC_Patient_DiagnosesID != Guid.Empty)
                {
                    var result = item.Load(Connection, Transaction, Parameter.PatientDiagnosis[i].HEC_Patient_DiagnosesID);
                    if (result.Status != FR_Status.Success || item.HEC_Patient_DiagnosisID == Guid.Empty)
                    {
                        if (item.IsDeleted)
                            continue;

                        Guid PatientID = Guid.NewGuid();
                        item.HEC_Patient_DiagnosisID = PatientID;
                        item.Patient_RefID = Parameter.PatientDiagnosis[i].PatientID;
                        //item.Doctor_RefID = Parameter.PatientDiagnosis[i].Doctor_RefID;
                        //item.DIA_PotentialDiagnosis_RefID = Parameter.PatientDiagnosis[i].DIA_PotentialDiagnosis_RefID;
                        //item.DIA_State_RefID = Parameter.PatientDiagnosis[i].DIA_State_RefID;
                        //item.PatientDiagnosis_Comment = Parameter.PatientDiagnosis[i].RelevantDiagnosis_Comment;
                        item.Creation_Timestamp = DateTime.Now;
                       // item.DiagnosedOnDate = Parameter.PatientDiagnosis[i].CreationTime;
                        item.IsDeleted = false;
                        item.Tenant_RefID = securityTicket.TenantID;


                        localization.HEC_Patient_Diagnosis_LocalizationID = Guid.NewGuid();
                        localization.HEC_Patient_Diagnosis_RefID = PatientID;
                        localization.HEC_DIA_Diagnosis_Localization_RefID = Parameter.PatientDiagnosis[i].DIA_Localization_RefID;
                        localization.Tenant_RefID = securityTicket.TenantID;
                        localization.Creation_Timestamp = DateTime.Now;

                        item.Save(Connection, Transaction);

                        localization.Save(Connection, Transaction);
                    }


            #endregion
                    else
                    {

                        if (Parameter.PatientDiagnosis[i].IsDeleted == true)
                        {
                            item.IsDeleted = true;
                            item.Save(Connection, Transaction);
                        }
                        else
                        {

                            item.Patient_RefID = Parameter.PatientDiagnosis[i].PatientID;
                          //  item.Doctor_RefID = Parameter.PatientDiagnosis[i].Doctor_RefID;
                          //  item.DIA_PotentialDiagnosis_RefID = Parameter.PatientDiagnosis[i].DIA_PotentialDiagnosis_RefID;
                           // item.DIA_State_RefID = Parameter.PatientDiagnosis[i].DIA_State_RefID;
                           // item.PatientDiagnosis_Comment = Parameter.PatientDiagnosis[i].RelevantDiagnosis_Comment;
                            item.Creation_Timestamp = DateTime.Now;
                            //item.DiagnosedOnDate = Parameter.PatientDiagnosis[i].CreationTime;
                            item.IsDeleted = false;
                            item.Tenant_RefID = securityTicket.TenantID;


                            var query = new ORM_HEC_Patient_Diagnosis_Localization.Query();
                            query.HEC_Patient_Diagnosis_RefID = Parameter.PatientDiagnosis[i].HEC_Patient_DiagnosesID;

                            var local = ORM_HEC_Patient_Diagnosis_Localization.Query.Search(Connection, Transaction, query);

                            if (local.Count > 0)
                            {
                                local[0].HEC_Patient_Diagnosis_LocalizationID = Parameter.PatientDiagnosis[i].DIA_Localization_RefID;
                                local[0].Save(Connection, Transaction);
                            }


                            item.Save(Connection, Transaction);
                        }

                    }

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
		public static FR_Guid Invoke(string ConnectionString,P_L5DG_SDfP_17_02 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5DG_SDfP_17_02 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5DG_SDfP_17_02 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5DG_SDfP_17_02 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw ex;
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5DG_SDfP_17_02 for attribute P_L5DG_SDfP_17_02
		[DataContract]
		public class P_L5DG_SDfP_17_02 
		{
			[DataMember]
			public L5DG_SDfP_17_02a[] PatientDiagnosis { get; set; }

			//Standard type parameters
		}
		#endregion
		#region SClass L5DG_SDfP_17_02a for attribute PatientDiagnosis
		[DataContract]
		public class L5DG_SDfP_17_02a 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_Patient_DiagnosesID { get; set; } 
			[DataMember]
			public Guid PatientID { get; set; } 
			[DataMember]
			public Guid Doctor_RefID { get; set; } 
			[DataMember]
			public Guid DIA_PotentialDiagnosis_RefID { get; set; } 
			[DataMember]
			public Guid DIA_Localization_RefID { get; set; } 
			[DataMember]
			public Guid DIA_State_RefID { get; set; } 
			[DataMember]
			public String RelevantDiagnosis_Comment { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 
			[DataMember]
			public DateTime CreationTime { get; set; } 

		}
		#endregion

	#endregion
}
