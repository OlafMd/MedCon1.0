/* 
 * Generated on 8/30/2013 10:20:19 AM
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
using CL1_CMN_PRO;

namespace CL5_OphthalSurveys.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Publish_Survey.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Publish_Survey
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5OS_SS_1352 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Guid();
            var template = new ORM_CMN_QST_Questionnaire_Template();
            var templateVersion = new ORM_CMN_QST_Questionnaire_Template_Version();
            var questionnaireAssignment = new ORM_CMN_PRO_Product_Questionnaire_Assignment();

            var result1 = template.Load(Connection, Transaction, Parameter.CMN_QST_Questionnaire_TemplateID);
            if (result1.Status != FR_Status.Success || template.CMN_QST_Questionnaire_TemplateID == Guid.Empty)
            {
                var error = new FR_Guid();
                error.ErrorMessage = "No Such ID";
                error.Status = FR_Status.Error_Internal;
                return error;
            }

            var result2 = templateVersion.Load(Connection, Transaction, template.Current_UnpublishedVersion_RefID);
            if (result2.Status != FR_Status.Success || templateVersion.CMN_QST_Questionnaire_Template_VersionID == Guid.Empty)
            {
                var error = new FR_Guid();
                error.ErrorMessage = "No Such ID";
                error.Status = FR_Status.Error_Internal;
                return error;
            }

            var result3 = questionnaireAssignment.Load(Connection, Transaction, Parameter.CMN_PRO_Product_Questionnaire_AssignmentID);
            if (result3.Status != FR_Status.Success || questionnaireAssignment.CMN_PRO_Product_Questionnaire_AssignmentID == Guid.Empty)
            {
                var error = new FR_Guid();
                error.ErrorMessage = "No Such ID";
                error.Status = FR_Status.Error_Internal;
                return error;
            }


            template.Current_PublishedVersion_RefID = template.Current_UnpublishedVersion_RefID;
            templateVersion.IsQuestionnaireVersion_Published = true;

            #region Template Version +  unpublished version of a Template

            var templateVersionNew = new ORM_CMN_QST_Questionnaire_Template_Version();


            templateVersionNew.CMN_QST_Questionnaire_Template_VersionID = Guid.NewGuid();
            templateVersionNew.QuestionnaireTemplate_RefID = template.CMN_QST_Questionnaire_TemplateID;
            templateVersionNew.IsQuestionnaireVersion_Published = false;
            templateVersionNew.Tenant_RefID = securityTicket.TenantID;
            templateVersionNew.Creation_Account_RefID = securityTicket.AccountID;
            templateVersionNew.Tenant_RefID = securityTicket.TenantID;

            template.Current_UnpublishedVersion_RefID = templateVersionNew.CMN_QST_Questionnaire_Template_VersionID;

            template.Save(Connection, Transaction);
            templateVersion.Save(Connection, Transaction);
            templateVersionNew.Save(Connection, Transaction);
            #endregion

            #region set old questionnare Assigment to false  and create  new Questionnaire Assignment

            questionnaireAssignment.IsActive = true;
            questionnaireAssignment.Save(Connection, Transaction);

            var questionnaireAssignmentNew = new ORM_CMN_PRO_Product_Questionnaire_Assignment();
            questionnaireAssignmentNew.CMN_PRO_Product_Questionnaire_AssignmentID = Guid.NewGuid();
            questionnaireAssignmentNew.CMN_PRO_Product_RefID = questionnaireAssignment.CMN_PRO_Product_RefID;
            questionnaireAssignmentNew.CMN_QST_Questionnaire_Template_Version_RefID = templateVersionNew.CMN_QST_Questionnaire_Template_VersionID;
            questionnaireAssignmentNew.Tenant_RefID = securityTicket.TenantID;
            questionnaireAssignmentNew.IsActive = false;
            questionnaireAssignmentNew.Tenant_RefID = securityTicket.TenantID;
            questionnaireAssignmentNew.Save(Connection, Transaction);
            #endregion

            #region Question items , Enumeration Answers and answers

            var query = new ORM_CMN_QST_Questionnaire_QuestionItem.Query();
            query.Questionnaire_Template_RefID = templateVersion.CMN_QST_Questionnaire_Template_VersionID;

            var questionItemsAll = ORM_CMN_QST_Questionnaire_QuestionItem.Query.Search(Connection, Transaction, query).ToList();

            for (int i = 0; i < questionItemsAll.Count; i++)
            {
                ORM_CMN_QST_QuestionItem_EnumerationAnswerType questionItemEnumerationAnswerTypes = new ORM_CMN_QST_QuestionItem_EnumerationAnswerType();
                questionItemEnumerationAnswerTypes.EnumerationAnswerType_Name = new Dict();
                questionItemEnumerationAnswerTypes.EnumerationAnswerType_Name.DictionaryID = Guid.NewGuid(); ;
                questionItemEnumerationAnswerTypes.Tenant_RefID = securityTicket.TenantID;
                questionItemEnumerationAnswerTypes.Save(Connection, Transaction);

                ORM_CMN_QST_Questionnaire_QuestionItem quetionItem = new ORM_CMN_QST_Questionnaire_QuestionItem();
                quetionItem.Questionnaire_Template_RefID = templateVersionNew.CMN_QST_Questionnaire_Template_VersionID;
                quetionItem.QuestionItem_Label = questionItemsAll[i].QuestionItem_Label.CopyContents("ORM_CMN_QST_Questionnaire_QuestionItem");
                quetionItem.IsDeleted = questionItemsAll[i].IsDeleted;
                quetionItem.QuestionItem_Description = questionItemsAll[i].QuestionItem_Description.CopyContents("ORM_CMN_QST_Questionnaire_QuestionItem");
                quetionItem.IsAnswer_Enum = questionItemsAll[i].IsAnswer_Enum;
                quetionItem.Tenant_RefID = questionItemsAll[i].Tenant_RefID;
                quetionItem.QuestionItem_SequenceNumber = questionItemsAll[i].QuestionItem_SequenceNumber;
                quetionItem.IfAnswer_EnumType_RefID = questionItemEnumerationAnswerTypes.CMN_QST_QuestionItem_EnumerationAnswerTypeID;
                quetionItem.Save(Connection, Transaction);

                var query2 = new ORM_CMN_QST_QuestionItem_EnumerationAnswer.Query();
                query2.EnumerationAnswerType_RefID = questionItemsAll[i].IfAnswer_EnumType_RefID;

                var answers = ORM_CMN_QST_QuestionItem_EnumerationAnswer.Query.Search(Connection, Transaction, query2);

                if (answers.Count() != 2)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "There are no answers in DataBase!";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
                ORM_CMN_QST_QuestionItem_EnumerationAnswer answr1 = answers.OrderBy(a => a.Creation_Timestamp).First();
                ORM_CMN_QST_QuestionItem_EnumerationAnswer answr2 = answers.OrderBy(a => a.Creation_Timestamp).Last();

                /*######Answer 1  ###########*/
                var enumerationAnswer1 = new ORM_CMN_QST_QuestionItem_EnumerationAnswer();
                enumerationAnswer1.EnumerationAnswerType_RefID = questionItemEnumerationAnswerTypes.CMN_QST_QuestionItem_EnumerationAnswerTypeID;
                enumerationAnswer1.EnumerationAnswer_Text = answr1.EnumerationAnswer_Text.CopyContents("ORM_CMN_QST_QuestionItem_EnumerationAnswer");
                enumerationAnswer1.Tenant_RefID = securityTicket.TenantID;
                enumerationAnswer1.Creation_Timestamp = DateTime.Now;
                enumerationAnswer1.Save(Connection, Transaction);

                /*######Answer 2  ###########*/
                var enumerationAnswer2 = new ORM_CMN_QST_QuestionItem_EnumerationAnswer();
                enumerationAnswer2.EnumerationAnswerType_RefID = questionItemEnumerationAnswerTypes.CMN_QST_QuestionItem_EnumerationAnswerTypeID;
                enumerationAnswer2.EnumerationAnswer_Text = answr2.EnumerationAnswer_Text.CopyContents("ORM_CMN_QST_QuestionItem_EnumerationAnswer");
                enumerationAnswer2.Tenant_RefID = securityTicket.TenantID;
                enumerationAnswer2.Creation_Timestamp = DateTime.Now.AddMinutes(1);
                enumerationAnswer2.Save(Connection, Transaction);
            }
            #endregion
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5OS_SS_1352 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5OS_SS_1352 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5OS_SS_1352 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5OS_SS_1352 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Publish_Survey",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5OS_SS_1352 for attribute P_L5OS_SS_1352
		[DataContract]
		public class P_L5OS_SS_1352 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_Product_Questionnaire_AssignmentID { get; set; } 
			[DataMember]
			public Guid CMN_QST_Questionnaire_TemplateID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Publish_Survey(,P_L5OS_SS_1352 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Publish_Survey.Invoke(connectionString,P_L5OS_SS_1352 Parameter,securityTicket);
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
var parameter = new CL5_OphthalSurveys.Complex.Manipulation.P_L5OS_SS_1352();
parameter.CMN_PRO_Product_Questionnaire_AssignmentID = ...;
parameter.CMN_QST_Questionnaire_TemplateID = ...;

*/
