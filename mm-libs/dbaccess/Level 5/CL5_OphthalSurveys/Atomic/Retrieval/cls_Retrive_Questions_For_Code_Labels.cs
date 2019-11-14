/* 
 * Generated on 8/30/2013 10:30:48 AM
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

namespace CL5_OphthalSurveys.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Retrive_Questions_For_Code_Labels.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Retrive_Questions_For_Code_Labels
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5OS_r_questions_qrlabel_1217_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5OS_r_questions_qrlabel_1217 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5OS_r_questions_qrlabel_1217_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_OphthalSurveys.Atomic.Retrieval.SQL.cls_Retrive_Questions_For_Code_Labels.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"barcodeLabel", Parameter.barcodeLabel);



			List<L5OS_r_questions_qrlabel_1217> results = new List<L5OS_r_questions_qrlabel_1217>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "IsActive","QuestionItem_Label_DictID","QuestionItem_SequenceNumber","CMN_QST_Questionnaire_Template_VersionID","CMN_QST_Questionnaire_ItemID","CMN_QST_QuestionItem_EnumerationAnswerTypeID","HEC_ShippingPosition_BarcodeLabelID","LOG_SHP_Shipment_PositionID","CMN_PRO_Product_RefID","CMN_PRO_ProductVariant_RefID","LOG_SHP_Shipment_Position_RefID","Bound_QuestionnaireTemplateVersion_RefID","CMN_PRO_ProductID","Product_Name_DictID","CMN_PRO_Product_Questionnaire_AssignmentID","CMN_PRO_Product_RefID1","CMN_QST_Questionnaire_Template_Version_RefID","QuestionnaireTemplate_RefID","CopiedFrom_TemplateVersion_RefID","CMN_QST_QuestionItem_EnumerationAnswerID","EnumerationAnswer_Text_DictID","ShippingPosition_BarcodeLabel" });
				while(reader.Read())
				{
					L5OS_r_questions_qrlabel_1217 resultItem = new L5OS_r_questions_qrlabel_1217();
					//0:Parameter IsActive of type bool
					resultItem.IsActive = reader.GetBoolean(0);
					//1:Parameter QuestionItem_Label of type Dict
					resultItem.QuestionItem_Label = reader.GetDictionary(1);
					resultItem.QuestionItem_Label.SourceTable = "cmn_qst_questionnaire_questionitems";
					loader.Append(resultItem.QuestionItem_Label);
					//2:Parameter QuestionItem_SequenceNumber of type String
					resultItem.QuestionItem_SequenceNumber = reader.GetString(2);
					//3:Parameter CMN_QST_Questionnaire_Template_VersionID of type Guid
					resultItem.CMN_QST_Questionnaire_Template_VersionID = reader.GetGuid(3);
					//4:Parameter CMN_QST_Questionnaire_ItemID of type Guid
					resultItem.CMN_QST_Questionnaire_ItemID = reader.GetGuid(4);
					//5:Parameter CMN_QST_QuestionItem_EnumerationAnswerTypeID of type Guid
					resultItem.CMN_QST_QuestionItem_EnumerationAnswerTypeID = reader.GetGuid(5);
					//6:Parameter HEC_ShippingPosition_BarcodeLabelID of type Guid
					resultItem.HEC_ShippingPosition_BarcodeLabelID = reader.GetGuid(6);
					//7:Parameter LOG_SHP_Shipment_PositionID of type Guid
					resultItem.LOG_SHP_Shipment_PositionID = reader.GetGuid(7);
					//8:Parameter CMN_PRO_Product_RefID of type Guid
					resultItem.CMN_PRO_Product_RefID = reader.GetGuid(8);
					//9:Parameter CMN_PRO_ProductVariant_RefID of type Guid
					resultItem.CMN_PRO_ProductVariant_RefID = reader.GetGuid(9);
					//10:Parameter LOG_SHP_Shipment_Position_RefID of type Guid
					resultItem.LOG_SHP_Shipment_Position_RefID = reader.GetGuid(10);
					//11:Parameter Bound_QuestionnaireTemplateVersion_RefID of type Guid
					resultItem.Bound_QuestionnaireTemplateVersion_RefID = reader.GetGuid(11);
					//12:Parameter CMN_PRO_ProductID of type Guid
					resultItem.CMN_PRO_ProductID = reader.GetGuid(12);
					//13:Parameter Product_Name of type Dict
					resultItem.Product_Name = reader.GetDictionary(13);
					resultItem.Product_Name.SourceTable = "cmn_pro_products";
					loader.Append(resultItem.Product_Name);
					//14:Parameter CMN_PRO_Product_Questionnaire_AssignmentID of type Guid
					resultItem.CMN_PRO_Product_Questionnaire_AssignmentID = reader.GetGuid(14);
					//15:Parameter CMN_PRO_Product_RefID1 of type String
					resultItem.CMN_PRO_Product_RefID1 = reader.GetString(15);
					//16:Parameter CMN_QST_Questionnaire_Template_Version_RefID of type Guid
					resultItem.CMN_QST_Questionnaire_Template_Version_RefID = reader.GetGuid(16);
					//17:Parameter QuestionnaireTemplate_RefID of type Guid
					resultItem.QuestionnaireTemplate_RefID = reader.GetGuid(17);
					//18:Parameter CopiedFrom_TemplateVersion_RefID of type Guid
					resultItem.CopiedFrom_TemplateVersion_RefID = reader.GetGuid(18);
					//19:Parameter CMN_QST_QuestionItem_EnumerationAnswerID of type Guid
					resultItem.CMN_QST_QuestionItem_EnumerationAnswerID = reader.GetGuid(19);
					//20:Parameter EnumerationAnswer_Text of type Dict
					resultItem.EnumerationAnswer_Text = reader.GetDictionary(20);
					resultItem.EnumerationAnswer_Text.SourceTable = "cmn_qst_questionitem_enumerationanswers";
					loader.Append(resultItem.EnumerationAnswer_Text);
					//21:Parameter ShippingPosition_BarcodeLabel of type String
					resultItem.ShippingPosition_BarcodeLabel = reader.GetString(21);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Retrive_Questions_For_Code_Labels",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = results.ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5OS_r_questions_qrlabel_1217_Array Invoke(string ConnectionString,P_L5OS_r_questions_qrlabel_1217 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5OS_r_questions_qrlabel_1217_Array Invoke(DbConnection Connection,P_L5OS_r_questions_qrlabel_1217 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5OS_r_questions_qrlabel_1217_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5OS_r_questions_qrlabel_1217 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5OS_r_questions_qrlabel_1217_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5OS_r_questions_qrlabel_1217 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5OS_r_questions_qrlabel_1217_Array functionReturn = new FR_L5OS_r_questions_qrlabel_1217_Array();
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

				throw new Exception("Exception occured in method cls_Retrive_Questions_For_Code_Labels",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5OS_r_questions_qrlabel_1217_Array : FR_Base
	{
		public L5OS_r_questions_qrlabel_1217[] Result	{ get; set; } 
		public FR_L5OS_r_questions_qrlabel_1217_Array() : base() {}

		public FR_L5OS_r_questions_qrlabel_1217_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5OS_r_questions_qrlabel_1217 for attribute P_L5OS_r_questions_qrlabel_1217
		[DataContract]
		public class P_L5OS_r_questions_qrlabel_1217 
		{
			//Standard type parameters
			[DataMember]
			public Guid barcodeLabel { get; set; } 

		}
		#endregion
		#region SClass L5OS_r_questions_qrlabel_1217 for attribute L5OS_r_questions_qrlabel_1217
		[DataContract]
		public class L5OS_r_questions_qrlabel_1217 
		{
			//Standard type parameters
			[DataMember]
			public bool IsActive { get; set; } 
			[DataMember]
			public Dict QuestionItem_Label { get; set; } 
			[DataMember]
			public String QuestionItem_SequenceNumber { get; set; } 
			[DataMember]
			public Guid CMN_QST_Questionnaire_Template_VersionID { get; set; } 
			[DataMember]
			public Guid CMN_QST_Questionnaire_ItemID { get; set; } 
			[DataMember]
			public Guid CMN_QST_QuestionItem_EnumerationAnswerTypeID { get; set; } 
			[DataMember]
			public Guid HEC_ShippingPosition_BarcodeLabelID { get; set; } 
			[DataMember]
			public Guid LOG_SHP_Shipment_PositionID { get; set; } 
			[DataMember]
			public Guid CMN_PRO_Product_RefID { get; set; } 
			[DataMember]
			public Guid CMN_PRO_ProductVariant_RefID { get; set; } 
			[DataMember]
			public Guid LOG_SHP_Shipment_Position_RefID { get; set; } 
			[DataMember]
			public Guid Bound_QuestionnaireTemplateVersion_RefID { get; set; } 
			[DataMember]
			public Guid CMN_PRO_ProductID { get; set; } 
			[DataMember]
			public Dict Product_Name { get; set; } 
			[DataMember]
			public Guid CMN_PRO_Product_Questionnaire_AssignmentID { get; set; } 
			[DataMember]
			public String CMN_PRO_Product_RefID1 { get; set; } 
			[DataMember]
			public Guid CMN_QST_Questionnaire_Template_Version_RefID { get; set; } 
			[DataMember]
			public Guid QuestionnaireTemplate_RefID { get; set; } 
			[DataMember]
			public Guid CopiedFrom_TemplateVersion_RefID { get; set; } 
			[DataMember]
			public Guid CMN_QST_QuestionItem_EnumerationAnswerID { get; set; } 
			[DataMember]
			public Dict EnumerationAnswer_Text { get; set; } 
			[DataMember]
			public String ShippingPosition_BarcodeLabel { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5OS_r_questions_qrlabel_1217_Array cls_Retrive_Questions_For_Code_Labels(,P_L5OS_r_questions_qrlabel_1217 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5OS_r_questions_qrlabel_1217_Array invocationResult = cls_Retrive_Questions_For_Code_Labels.Invoke(connectionString,P_L5OS_r_questions_qrlabel_1217 Parameter,securityTicket);
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
var parameter = new CL5_OphthalSurveys.Atomic.Retrieval.P_L5OS_r_questions_qrlabel_1217();
parameter.barcodeLabel = ...;

*/
