/* 
 * Generated on 8/9/2013 9:43:17 AM
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

namespace CL5_Lucentis_Treatments.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_HEC_Patient_Treatment.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_HEC_Patient_Treatment
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5TR_SPT_1407 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_Guid();

            var item = new ORM_HEC_Patient_Treatment();
            if (Parameter.HEC_Patient_TreatmentID != Guid.Empty)
            {
                var result = item.Load(Connection, Transaction, Parameter.HEC_Patient_TreatmentID);
                if (result.Status != FR_Status.Success || item.HEC_Patient_TreatmentID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }

            if (Parameter.IsDeleted == true)
            {
                #region Delete Assignment

                var query = new ORM_HEC_Patient_2_PatientTreatment.Query();
                query.HEC_Patient_Treatment_RefID = Parameter.HEC_Patient_TreatmentID;
                query.IsDeleted = false;


                ORM_HEC_Patient_2_PatientTreatment.Query.SoftDelete(Connection, Transaction, query);

                #endregion

                item.IsDeleted = true;
                return new FR_Guid(item.Save(Connection, Transaction), item.HEC_Patient_TreatmentID);
            }

            //Creation specific parameters (Tenant, Account ... )
            if (Parameter.HEC_Patient_TreatmentID == Guid.Empty)
            {
                item.HEC_Patient_TreatmentID = Guid.NewGuid();
                item.Tenant_RefID = securityTicket.TenantID;
                if (Parameter.IfTreatmentScheduled_ByDoctor_RefID != Guid.Empty)
                {
                    item.IfSheduled_ForDoctor_RefID = Parameter.IfTreatmentPerformed_ByDoctor_RefID;
                }
                #region Add Assignment

                var assignment = new ORM_HEC_Patient_2_PatientTreatment();
                assignment.AssignmentID = Guid.NewGuid();
                assignment.HEC_Patient_RefID = Parameter.Patient_RefID;
                assignment.HEC_Patient_Treatment_RefID = item.HEC_Patient_TreatmentID;
                assignment.Creation_Timestamp = DateTime.Now;
                assignment.Modification_Timestamp = DateTime.Now;
                assignment.Tenant_RefID = securityTicket.TenantID;
                assignment.Save(Connection, Transaction);

                #endregion

                ORM_HEC_Patient_Treatment_OcularExtension ocularExtension = new ORM_HEC_Patient_Treatment_OcularExtension();
                ocularExtension.HEC_Patient_Treatment_OcularExtensionID = Guid.NewGuid();
                ocularExtension.HEC_Patient_Treatment_RefID = item.HEC_Patient_TreatmentID;
                ocularExtension.IsTreatmentOfLeftEye = Parameter.IsTreatmentOfLeftEye;
                ocularExtension.IsTreatmentOfRightEye = Parameter.IsTreatmentOfRightEye;
                ocularExtension.Creation_Timestamp = DateTime.Now;
                ocularExtension.Tenant_RefID = securityTicket.TenantID;
                ocularExtension.Save(Connection, Transaction);
            }
            else
            {
                var query = new ORM_HEC_Patient_Treatment_OcularExtension.Query();
                query.HEC_Patient_Treatment_RefID = item.HEC_Patient_TreatmentID;

                var ocularExtension = ORM_HEC_Patient_Treatment_OcularExtension.Query.Search(Connection,Transaction,query).FirstOrDefault();

                if (ocularExtension != null)
                {
                    ocularExtension.IsTreatmentOfLeftEye = Parameter.IsTreatmentOfLeftEye;
                    ocularExtension.IsTreatmentOfRightEye = Parameter.IsTreatmentOfRightEye;
                    ocularExtension.Save(Connection, Transaction);
                }
                else
                {
                    ORM_HEC_Patient_Treatment_OcularExtension ocularExtension1 = new ORM_HEC_Patient_Treatment_OcularExtension();
                    ocularExtension1.HEC_Patient_Treatment_OcularExtensionID = Guid.NewGuid();
                    ocularExtension1.HEC_Patient_Treatment_RefID = item.HEC_Patient_TreatmentID;
                    ocularExtension1.IsTreatmentOfLeftEye = Parameter.IsTreatmentOfLeftEye;
                    ocularExtension1.IsTreatmentOfRightEye = Parameter.IsTreatmentOfRightEye;
                    ocularExtension1.Creation_Timestamp = DateTime.Now;
                    ocularExtension1.Tenant_RefID = securityTicket.TenantID;
                    ocularExtension1.Save(Connection, Transaction);
                }
            }

            item.TreatmentPractice_RefID = Parameter.TreatmentPractice_RefID;
            item.IsTreatmentPerformed = Parameter.IsTreatmentPerformed;
            if (Parameter.IfTreatmentScheduled_ByDoctor_RefID != Guid.Empty)
            {
                item.IfSheduled_ForDoctor_RefID = Parameter.IfTreatmentScheduled_ByDoctor_RefID;
            }
            item.IfTreatmentPerformed_ByDoctor_RefID = Parameter.IfTreatmentPerformed_ByDoctor_RefID;
            item.IfTreatmentPerformed_Date = Parameter.IfTreatmentPerformed_Date;
            item.IsTreatmentFollowup = Parameter.IsTreatmentFollowup;
            item.IfTreatmentFollowup_FromTreatment_RefID = Parameter.IfTreatmentFollowup_FromTreatment_RefID;
            item.IsScheduled = Parameter.IsScheduled;
            item.IfSheduled_Date = Parameter.IfSheduled_Date;
            item.IsTreatmentBilled = Parameter.IsTreatmentBilled;
            item.IfTreatmentBilled_Date = Parameter.IfTreatmentBilled_Date;
            item.Treatment_Comment = Parameter.Treatment_Comment;

            


            return new FR_Guid(item.Save(Connection, Transaction), item.HEC_Patient_TreatmentID);
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5TR_SPT_1407 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5TR_SPT_1407 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5TR_SPT_1407 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5TR_SPT_1407 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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
		#region SClass P_L5TR_SPT_1407 for attribute P_L5TR_SPT_1407
		[DataContract]
		public class P_L5TR_SPT_1407 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_Patient_TreatmentID { get; set; } 
			[DataMember]
			public Guid TreatmentPractice_RefID { get; set; } 
			[DataMember]
			public Guid Patient_RefID { get; set; } 
			[DataMember]
			public Boolean IsTreatmentPerformed { get; set; } 
			[DataMember]
			public Guid IfTreatmentPerformed_ByDoctor_RefID { get; set; } 
			[DataMember]
			public Guid IfTreatmentScheduled_ByDoctor_RefID { get; set; } 
			[DataMember]
			public DateTime IfTreatmentPerformed_Date { get; set; } 
			[DataMember]
			public Boolean IsTreatmentFollowup { get; set; } 
			[DataMember]
			public Guid IfTreatmentFollowup_FromTreatment_RefID { get; set; } 
			[DataMember]
			public Boolean IsScheduled { get; set; } 
			[DataMember]
			public DateTime IfSheduled_Date { get; set; } 
			[DataMember]
			public Boolean IsTreatmentBilled { get; set; } 
			[DataMember]
			public DateTime IfTreatmentBilled_Date { get; set; } 
			[DataMember]
			public bool IsTreatmentOfLeftEye { get; set; } 
			[DataMember]
			public bool IsTreatmentOfRightEye { get; set; } 
			[DataMember]
			public String Treatment_Comment { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}
