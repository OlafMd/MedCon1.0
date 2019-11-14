/* 
 * Generated on 9/2/2013 3:32:15 PM
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
using CL1_CMN_QST;
using CL1_HEC;

namespace CL5_OphthalSurveys.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Submission.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Submission
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5OS_SSub_1641 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
            ORM_CMN_QST_Questionnaire_Submission submission = new ORM_CMN_QST_Questionnaire_Submission();
            submission.SubmittedOn_Date = DateTime.Now;
            submission.SubmittedBy_Account_RefID = Parameter.AccountID;
            submission.Tenant_RefID = Parameter.TenantID;
            submission.Questionnaire_Template_Version_RefID = Parameter.TemplateVersionID;
            submission.Save(Connection, Transaction);

            returnValue.Result = submission.CMN_QST_Questionnaire_SubmissionID;

            if (Parameter.answerPairs != null)
            {
                foreach (var pair in Parameter.answerPairs)
                {
                    ORM_CMN_QST_Questionnaire_SubmissionItem item = new ORM_CMN_QST_Questionnaire_SubmissionItem();
                    item.IsAnswerEnum_EnumerationValue_RefID = pair.CMN_QST_QuestionItem_EnumerationAnswerID;
                    item.IsAswer_Specified = true;
                    item.Questionnaire_Submission_RefID = submission.CMN_QST_Questionnaire_SubmissionID;
                    item.Questionnaire_QuestionItem_RefID = pair.CMN_QST_Questionnaire_ItemID;
                    item.Tenant_RefID = Parameter.TenantID;
                    item.Save(Connection, Transaction);
                }
            }

            ORM_HEC_ShippingPosition_QuestionnaireSubmission ShippingPosition_QuestionnaireSubmission = new ORM_HEC_ShippingPosition_QuestionnaireSubmission();
            ShippingPosition_QuestionnaireSubmission.Doctor_RefID = Parameter.HEC_DoctorID;
            ShippingPosition_QuestionnaireSubmission.CMN_QST_Questionnaire_Submission_RefID = submission.CMN_QST_Questionnaire_SubmissionID;
            ShippingPosition_QuestionnaireSubmission.LOG_SHP_Shipment_Position_RefID = Parameter.LOG_SHP_Shipment_PositionID;
            ShippingPosition_QuestionnaireSubmission.Tenant_RefID = Parameter.TenantID;
            ShippingPosition_QuestionnaireSubmission.Save(Connection, Transaction);

            ORM_HEC_ShippingPosition_BarcodeLabel postionLabel = new ORM_HEC_ShippingPosition_BarcodeLabel();
            if (Parameter.HEC_ShippingPosition_BarcodeLabelID != Guid.Empty)
            {
                var result = postionLabel.Load(Connection, Transaction, Parameter.HEC_ShippingPosition_BarcodeLabelID);
                if (result.Status != FR_Status.Success || postionLabel.HEC_ShippingPosition_BarcodeLabelID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
                postionLabel.R_IsSubmission_Complete = true;
                postionLabel.Save(Connection, Transaction);
            }
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5OS_SSub_1641 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5OS_SSub_1641 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5OS_SSub_1641 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5OS_SSub_1641 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Submission",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5OS_SSub_1641 for attribute P_L5OS_SSub_1641
		[DataContract]
		public class P_L5OS_SSub_1641 
		{
			[DataMember]
			public P_L5OS_SSub_1641_AnswerPairs[] answerPairs { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid AccountID { get; set; } 
			[DataMember]
			public Guid TenantID { get; set; } 
			[DataMember]
			public Guid HEC_DoctorID { get; set; } 
			[DataMember]
			public Guid TemplateVersionID { get; set; } 
			[DataMember]
			public Guid HEC_ShippingPosition_BarcodeLabelID { get; set; } 
			[DataMember]
			public Guid LOG_SHP_Shipment_PositionID { get; set; } 

		}
		#endregion
        //#region SClass P_L5OS_SSub_1641_AnswerPairs for attribute answerPairs
        //[DataContract]
        //public class P_L5OS_SSub_1641_AnswerPairs 
        //{
        //    //Standard type parameters
        //    [DataMember]
        //    public Guid CMN_QST_QuestionItem_EnumerationAnswerID { get; set; } 
        //    [DataMember]
        //    public Guid CMN_QST_Questionnaire_ItemID { get; set; } 

        //}
		//#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Submission(,P_L5OS_SSub_1641 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Submission.Invoke(connectionString,P_L5OS_SSub_1641 Parameter,securityTicket);
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
var parameter = new CL5_OphthalSurveys.Complex.Manipulation.P_L5OS_SSub_1641();
parameter.answerPairs = ...;

parameter.AccountID = ...;
parameter.TenantID = ...;
parameter.HEC_DoctorID = ...;
parameter.TemplateVersionID = ...;
parameter.HEC_ShippingPosition_BarcodeLabelID = ...;
parameter.LOG_SHP_Shipment_PositionID = ...;

*/
