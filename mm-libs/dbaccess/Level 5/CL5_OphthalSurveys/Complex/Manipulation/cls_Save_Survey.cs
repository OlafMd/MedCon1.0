/* 
 * Generated on 8/30/2013 10:27:54 AM
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
    /// var result = cls_Save_Survey.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Survey
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5OS_SS_1614 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
            Boolean IsFirstInput = false;

            var template = new ORM_CMN_QST_Questionnaire_Template();
            var templateVersion = new ORM_CMN_QST_Questionnaire_Template_Version();
            var questionnaireAssignment = new ORM_CMN_PRO_Product_Questionnaire_Assignment();

            //Isn't First Input
            if (Parameter.CMN_QST_Questionnaire_TemplateID != Guid.Empty)
            {
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

                //var result3 = questionnaireAssignment.Load(Connection, Transaction, questionnaireAssignment.CMN_PRO_Product_Questionnaire_AssignmentID);
                //if (result3.Status != FR_Status.Success || questionnaireAssignment.CMN_PRO_Product_Questionnaire_AssignmentID == Guid.Empty)
                //{
                //    var error = new FR_Guid();
                //    error.ErrorMessage = "No Such ID";
                //    error.Status = FR_Status.Error_Internal;
                //    return error;
                //}

            }
            else
            {
                IsFirstInput = true;

                #region Template

                template.CMN_QST_Questionnaire_TemplateID = Guid.NewGuid();
                template.QuestionnaireTemplate_Description = new Dict();

                template.Tenant_RefID = securityTicket.TenantID;

                #endregion

                #region Template Version + setting Current published and unpublished version of a Template


                templateVersion.CMN_QST_Questionnaire_Template_VersionID = Guid.NewGuid();
                templateVersion.QuestionnaireTemplate_RefID = template.CMN_QST_Questionnaire_TemplateID;
                templateVersion.IsQuestionnaireVersion_Published = false;
                templateVersion.Tenant_RefID = securityTicket.TenantID;
                templateVersion.Creation_Account_RefID = securityTicket.AccountID;

                template.Current_PublishedVersion_RefID = Guid.Empty;
                template.Current_UnpublishedVersion_RefID = templateVersion.CMN_QST_Questionnaire_Template_VersionID;

                #endregion



                #region Questionnaire Assignment

                questionnaireAssignment.CMN_PRO_Product_Questionnaire_AssignmentID = Guid.NewGuid();
                questionnaireAssignment.CMN_PRO_Product_RefID = Parameter.CMN_PRO_Product_RefID;
                questionnaireAssignment.CMN_QST_Questionnaire_Template_Version_RefID = templateVersion.CMN_QST_Questionnaire_Template_VersionID;
                questionnaireAssignment.Tenant_RefID = securityTicket.TenantID;
                questionnaireAssignment.IsActive = false;
                #endregion

                questionnaireAssignment.Save(Connection, Transaction);
                template.Save(Connection, Transaction);
                templateVersion.Save(Connection, Transaction);
            }

            //Add
            if (Parameter.CMN_QST_Questionnaire_ItemID == Guid.Empty)
            {
                #region Question Item

                var quetionItem = new ORM_CMN_QST_Questionnaire_QuestionItem();
                quetionItem.CMN_QST_Questionnaire_ItemID = Guid.NewGuid();

                quetionItem.Questionnaire_Template_RefID = templateVersion.CMN_QST_Questionnaire_Template_VersionID;
                quetionItem.QuestionItem_Label = Parameter.QuestionItem_Label_DictID;
                quetionItem.IsDeleted = Parameter.IsDeleted;
                quetionItem.QuestionItem_Description = new Dict();
                quetionItem.IsAnswer_Enum = true;
                quetionItem.Tenant_RefID = securityTicket.TenantID;

                var query = new ORM_CMN_QST_Questionnaire_QuestionItem.Query();

                query.Questionnaire_Template_RefID = templateVersion.CMN_QST_Questionnaire_Template_VersionID;
                var questionItemsAll = ORM_CMN_QST_Questionnaire_QuestionItem.Query.Search(Connection, Transaction, query).ToList();

                quetionItem.QuestionItem_SequenceNumber = questionItemsAll.Count + 1;

                #endregion

                #region Enumeration Answers

                var questionItemEnumerationAnswerTypes = new ORM_CMN_QST_QuestionItem_EnumerationAnswerType();

                questionItemEnumerationAnswerTypes.CMN_QST_QuestionItem_EnumerationAnswerTypeID = Guid.NewGuid();
                questionItemEnumerationAnswerTypes.EnumerationAnswerType_Name = new Dict();

                quetionItem.IfAnswer_EnumType_RefID = questionItemEnumerationAnswerTypes.CMN_QST_QuestionItem_EnumerationAnswerTypeID;
                quetionItem.Tenant_RefID = securityTicket.TenantID;


                DateTime timeNow = DateTime.Now;

                /*######Answer 1  ###########*/
                var enumerationAnswer1 = new ORM_CMN_QST_QuestionItem_EnumerationAnswer();

                enumerationAnswer1.CMN_QST_QuestionItem_EnumerationAnswerID = Guid.NewGuid();
                enumerationAnswer1.EnumerationAnswerType_RefID = questionItemEnumerationAnswerTypes.CMN_QST_QuestionItem_EnumerationAnswerTypeID;
                enumerationAnswer1.EnumerationAnswer_Text = Parameter.EnumerationAnswer_Text_First_DictID;
                enumerationAnswer1.Creation_Timestamp = timeNow;
                enumerationAnswer1.Tenant_RefID = securityTicket.TenantID;

                /*######Answer 2  ###########*/

                var enumerationAnswer2 = new ORM_CMN_QST_QuestionItem_EnumerationAnswer();

                enumerationAnswer2.CMN_QST_QuestionItem_EnumerationAnswerID = Guid.NewGuid();
                enumerationAnswer2.EnumerationAnswerType_RefID = questionItemEnumerationAnswerTypes.CMN_QST_QuestionItem_EnumerationAnswerTypeID;
                enumerationAnswer2.EnumerationAnswer_Text = Parameter.EnumerationAnswer_Text_Second_DictID;
                enumerationAnswer2.Creation_Timestamp = timeNow.AddMinutes(1);
                enumerationAnswer2.Tenant_RefID = securityTicket.TenantID;

                #endregion


                enumerationAnswer1.Save(Connection, Transaction);
                enumerationAnswer2.Save(Connection, Transaction);
                questionItemEnumerationAnswerTypes.Save(Connection, Transaction);
                quetionItem.Save(Connection, Transaction);
            }
            else
            {

                #region Question Item

                var questionItem = new ORM_CMN_QST_Questionnaire_QuestionItem();
                questionItem.Load(Connection, Transaction, Parameter.CMN_QST_Questionnaire_ItemID);
                questionItem.QuestionItem_Label = Parameter.QuestionItem_Label_DictID;
                questionItem.IsDeleted = Parameter.IsDeleted;
                questionItem.Save(Connection, Transaction);

                #endregion

                #region Enumeration Answers Type

                var questionItemEnumerationAnswerTypes = new ORM_CMN_QST_QuestionItem_EnumerationAnswerType();
                questionItemEnumerationAnswerTypes.Load(Connection, Transaction, questionItem.IfAnswer_EnumType_RefID);


                #endregion Enumeration Answers Type

                #region Enumeration Answers

                var query = new ORM_CMN_QST_QuestionItem_EnumerationAnswer.Query();
                query.EnumerationAnswerType_RefID = questionItemEnumerationAnswerTypes.CMN_QST_QuestionItem_EnumerationAnswerTypeID;

                var answers = ORM_CMN_QST_QuestionItem_EnumerationAnswer.Query.Search(Connection, Transaction, query);

                if (answers.Count() != 2)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "There are no answers in DataBase!";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }

                answers[0].EnumerationAnswer_Text = Parameter.EnumerationAnswer_Text_First_DictID;
                answers[0].Save(Connection, Transaction);

                answers[1].EnumerationAnswer_Text = Parameter.EnumerationAnswer_Text_Second_DictID;
                answers[1].Save(Connection, Transaction);


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
		public static FR_Guid Invoke(string ConnectionString,P_L5OS_SS_1614 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5OS_SS_1614 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5OS_SS_1614 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5OS_SS_1614 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Survey",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5OS_SS_1614 for attribute P_L5OS_SS_1614
		[DataContract]
		public class P_L5OS_SS_1614 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_Product_RefID { get; set; } 
			[DataMember]
			public Guid CMN_QST_Questionnaire_TemplateID { get; set; } 
			[DataMember]
			public Guid CMN_QST_Questionnaire_Template_VersionID { get; set; } 
			[DataMember]
			public Guid CMN_QST_Questionnaire_ItemID { get; set; } 
			[DataMember]
			public Dict QuestionItem_Label_DictID { get; set; } 
			[DataMember]
			public Dict EnumerationAnswer_Text_First_DictID { get; set; } 
			[DataMember]
			public Dict EnumerationAnswer_Text_Second_DictID { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Survey(,P_L5OS_SS_1614 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Survey.Invoke(connectionString,P_L5OS_SS_1614 Parameter,securityTicket);
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
var parameter = new CL5_OphthalSurveys.Complex.Manipulation.P_L5OS_SS_1614();
parameter.CMN_PRO_Product_RefID = ...;
parameter.CMN_QST_Questionnaire_TemplateID = ...;
parameter.CMN_QST_Questionnaire_Template_VersionID = ...;
parameter.CMN_QST_Questionnaire_ItemID = ...;
parameter.QuestionItem_Label_DictID = ...;
parameter.EnumerationAnswer_Text_First_DictID = ...;
parameter.EnumerationAnswer_Text_Second_DictID = ...;
parameter.IsDeleted = ...;

*/
