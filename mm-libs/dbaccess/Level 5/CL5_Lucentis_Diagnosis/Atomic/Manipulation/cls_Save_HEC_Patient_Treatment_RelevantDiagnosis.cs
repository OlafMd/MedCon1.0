/* 
 * Generated on 8/14/2013 2:11:38 PM
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
    /// var result = cls_Save_HEC_Patient_Treatment_RelevantDiagnosis.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_HEC_Patient_Treatment_RelevantDiagnosis
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5DG_SPTRD_1501 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_Guid();

            var item = new ORM_HEC_Patient_Treatment_RelevantDiagnosis();
            if (Parameter.HEC_Patient_Treatment_RelevantDiagnosisID != Guid.Empty)
            {
                var result = item.Load(Connection, Transaction, Parameter.HEC_Patient_Treatment_RelevantDiagnosisID);
                if (result.Status != FR_Status.Success || item.HEC_Patient_Treatment_RelevantDiagnosisID == Guid.Empty)
                {
                    //Item doesn't exist, create it
                    Parameter.HEC_Patient_Treatment_RelevantDiagnosisID = Guid.Empty;

                    if (Parameter.IsDeleted)
                        return returnValue;
                }
            }

            if (Parameter.IsDeleted == true)
            {
                #region Delete Assignment

                var query = new ORM_HEC_Patient_Treatment_RelevantDiagnosis_Localization.Query();
                query.HEC_Patient_Treatment_RelevantDiagnoses_RefID = Parameter.HEC_Patient_Treatment_RelevantDiagnosisID;
                query.IsDeleted = false;

                ORM_HEC_Patient_Treatment_RelevantDiagnosis_Localization.Query.SoftDelete(Connection, Transaction, query);

                #endregion

                item.IsDeleted = true;
                return new FR_Guid(item.Save(Connection, Transaction), item.HEC_Patient_Treatment_RelevantDiagnosisID);
            }

            //Creation specific parameters (Tenant, Account ... )
            if (Parameter.HEC_Patient_Treatment_RelevantDiagnosisID == Guid.Empty)
            {

                item.HEC_Patient_Treatment_RelevantDiagnosisID = Guid.NewGuid();
                item.Tenant_RefID = securityTicket.TenantID;

                var assignment = new ORM_HEC_Patient_Treatment_RelevantDiagnosis_Localization();
                assignment.HEC_Patient_Treatment_RelevantDiagnosis_LocalizationID = Guid.NewGuid();
                assignment.HEC_DIA_Diagnosis_Localization_RefID = Parameter.DIA_Localization_RefID;
                assignment.Tenant_RefID = securityTicket.TenantID;
                assignment.Creation_Timestamp = DateTime.Now;
                assignment.HEC_Patient_Treatment_RelevantDiagnoses_RefID = item.HEC_Patient_Treatment_RelevantDiagnosisID;
                assignment.Save(Connection, Transaction);
            }
            else { 
            
                var  query = new ORM_HEC_Patient_Treatment_RelevantDiagnosis_Localization.Query();
                query.HEC_Patient_Treatment_RelevantDiagnoses_RefID = item.HEC_Patient_Treatment_RelevantDiagnosisID;
                var assignments = ORM_HEC_Patient_Treatment_RelevantDiagnosis_Localization.Query.Search(Connection, Transaction, query);

                foreach (var assignemnt in assignments) {
                    assignemnt.HEC_DIA_Diagnosis_Localization_RefID = Parameter.DIA_Localization_RefID;
                    assignemnt.Save(Connection, Transaction);
                }
            
            }

            item.Patient_Treatment_RefID = Parameter.Patient_Treatment_RefID;
            item.Doctor_RefID = Parameter.Doctor_RefID;
            item.DIA_PotentialDiagnosis_RefID = Parameter.DIA_PotentialDiagnosis_RefID;
            item.DIA_State_RefID = Parameter.DIA_State_RefID;
            item.RelevantDiagnosis_Comment = Parameter.RelevantDiagnosis_Comment;
            item.DiagnosedOnDate = Parameter.CreationTime;

            return new FR_Guid(item.Save(Connection, Transaction), item.HEC_Patient_Treatment_RelevantDiagnosisID);
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5DG_SPTRD_1501 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5DG_SPTRD_1501 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5DG_SPTRD_1501 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5DG_SPTRD_1501 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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
		#region SClass P_L5DG_SPTRD_1501 for attribute P_L5DG_SPTRD_1501
		[DataContract]
		public class P_L5DG_SPTRD_1501 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_Patient_Treatment_RelevantDiagnosisID { get; set; } 
			[DataMember]
			public Guid Patient_Treatment_RefID { get; set; } 
			[DataMember]
			public DateTime CreationTime { get; set; } 
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

		}
		#endregion

	#endregion
}
