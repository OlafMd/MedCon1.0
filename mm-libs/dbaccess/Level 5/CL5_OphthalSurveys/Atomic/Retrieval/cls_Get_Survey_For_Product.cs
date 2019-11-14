/* 
 * Generated on 8/30/2013 10:31:25 AM
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
    /// var result = cls_Get_Survey_For_Product.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Survey_For_Product
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5OS__RSFP_1417_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5OS__RSFP_1417 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5OS__RSFP_1417_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_OphthalSurveys.Atomic.Retrieval.SQL.cls_Get_Survey_For_Product.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ProductID", Parameter.ProductID);



			List<L5OS__RSFP_1417_raw> results = new List<L5OS__RSFP_1417_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_PRO_Product_Questionnaire_AssignmentID","QuestionnaireTemplate_RefID","CMN_QST_Questionnaire_Template_VersionID","CMN_QST_Questionnaire_ItemID","Questionnaire_Template_RefID","QuestionItem_Label_DictID","QuestionItem_Description_DictID","QuestionItem_SequenceNumber","EnumerationAnswerType_Name_DictID","CMN_QST_QuestionItem_EnumerationAnswerTypeID","CMN_QST_QuestionItem_EnumerationAnswerID","EnumerationAnswer_Text_DictID","EnumerationAnswerType_RefID" });
				while(reader.Read())
				{
					L5OS__RSFP_1417_raw resultItem = new L5OS__RSFP_1417_raw();
					//0:Parameter CMN_PRO_Product_Questionnaire_AssignmentID of type Guid
					resultItem.CMN_PRO_Product_Questionnaire_AssignmentID = reader.GetGuid(0);
					//1:Parameter QuestionnaireTemplate_RefID of type Guid
					resultItem.QuestionnaireTemplate_RefID = reader.GetGuid(1);
					//2:Parameter CMN_QST_Questionnaire_Template_VersionID of type Guid
					resultItem.CMN_QST_Questionnaire_Template_VersionID = reader.GetGuid(2);
					//3:Parameter CMN_QST_Questionnaire_ItemID of type Guid
					resultItem.CMN_QST_Questionnaire_ItemID = reader.GetGuid(3);
					//4:Parameter Questionnaire_Template_RefID of type Guid
					resultItem.Questionnaire_Template_RefID = reader.GetGuid(4);
					//5:Parameter QuestionItem_Label of type Dict
					resultItem.QuestionItem_Label = reader.GetDictionary(5);
					resultItem.QuestionItem_Label.SourceTable = "cmn_qst_questionnaire_questionitems";
					loader.Append(resultItem.QuestionItem_Label);
					//6:Parameter QuestionItem_Description of type Dict
					resultItem.QuestionItem_Description = reader.GetDictionary(6);
					resultItem.QuestionItem_Description.SourceTable = "cmn_qst_questionnaire_questionitems";
					loader.Append(resultItem.QuestionItem_Description);
					//7:Parameter QuestionItem_SequenceNumber of type String
					resultItem.QuestionItem_SequenceNumber = reader.GetString(7);
					//8:Parameter EnumerationAnswerType_Name of type Dict
					resultItem.EnumerationAnswerType_Name = reader.GetDictionary(8);
					resultItem.EnumerationAnswerType_Name.SourceTable = "cmn_qst_questionitem_enumerationanswertypes";
					loader.Append(resultItem.EnumerationAnswerType_Name);
					//9:Parameter CMN_QST_QuestionItem_EnumerationAnswerTypeID of type Guid
					resultItem.CMN_QST_QuestionItem_EnumerationAnswerTypeID = reader.GetGuid(9);
					//10:Parameter CMN_QST_QuestionItem_EnumerationAnswerID of type Guid
					resultItem.CMN_QST_QuestionItem_EnumerationAnswerID = reader.GetGuid(10);
					//11:Parameter EnumerationAnswer_Text of type Dict
					resultItem.EnumerationAnswer_Text = reader.GetDictionary(11);
					resultItem.EnumerationAnswer_Text.SourceTable = "cmn_qst_questionitem_enumerationanswers";
					loader.Append(resultItem.EnumerationAnswer_Text);
					//12:Parameter EnumerationAnswerType_RefID of type Guid
					resultItem.EnumerationAnswerType_RefID = reader.GetGuid(12);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Survey_For_Product",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5OS__RSFP_1417_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5OS__RSFP_1417_Array Invoke(string ConnectionString,P_L5OS__RSFP_1417 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5OS__RSFP_1417_Array Invoke(DbConnection Connection,P_L5OS__RSFP_1417 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5OS__RSFP_1417_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5OS__RSFP_1417 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5OS__RSFP_1417_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5OS__RSFP_1417 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5OS__RSFP_1417_Array functionReturn = new FR_L5OS__RSFP_1417_Array();
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

				throw new Exception("Exception occured in method cls_Get_Survey_For_Product",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5OS__RSFP_1417_raw 
	{
		public Guid CMN_PRO_Product_Questionnaire_AssignmentID; 
		public Guid QuestionnaireTemplate_RefID; 
		public Guid CMN_QST_Questionnaire_Template_VersionID; 
		public Guid CMN_QST_Questionnaire_ItemID; 
		public Guid Questionnaire_Template_RefID; 
		public Dict QuestionItem_Label; 
		public Dict QuestionItem_Description; 
		public String QuestionItem_SequenceNumber; 
		public Dict EnumerationAnswerType_Name; 
		public Guid CMN_QST_QuestionItem_EnumerationAnswerTypeID; 
		public Guid CMN_QST_QuestionItem_EnumerationAnswerID; 
		public Dict EnumerationAnswer_Text; 
		public Guid EnumerationAnswerType_RefID; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5OS__RSFP_1417[] Convert(List<L5OS__RSFP_1417_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5OS__RSFP_1417 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.CMN_QST_Questionnaire_Template_VersionID)).ToArray()
	group el_L5OS__RSFP_1417 by new 
	{ 
		el_L5OS__RSFP_1417.CMN_QST_Questionnaire_Template_VersionID,

	}
	into gfunct_L5OS__RSFP_1417
	select new L5OS__RSFP_1417
	{     
		CMN_PRO_Product_Questionnaire_AssignmentID = gfunct_L5OS__RSFP_1417.FirstOrDefault().CMN_PRO_Product_Questionnaire_AssignmentID ,
		QuestionnaireTemplate_RefID = gfunct_L5OS__RSFP_1417.FirstOrDefault().QuestionnaireTemplate_RefID ,
		CMN_QST_Questionnaire_Template_VersionID = gfunct_L5OS__RSFP_1417.Key.CMN_QST_Questionnaire_Template_VersionID ,

		questionItems = 
		(
			from el_questionItems in gfunct_L5OS__RSFP_1417.Where(element => !EqualsDefaultValue(element.CMN_QST_Questionnaire_ItemID)).ToArray()
			group el_questionItems by new 
			{ 
				el_questionItems.CMN_QST_Questionnaire_ItemID,

			}
			into gfunct_questionItems
			select new L5OS__RSFP_1417_QuestionItems
			{     
				CMN_QST_Questionnaire_ItemID = gfunct_questionItems.Key.CMN_QST_Questionnaire_ItemID ,
				Questionnaire_Template_RefID = gfunct_questionItems.FirstOrDefault().Questionnaire_Template_RefID ,
				QuestionItem_Label = gfunct_questionItems.FirstOrDefault().QuestionItem_Label ,
				QuestionItem_Description = gfunct_questionItems.FirstOrDefault().QuestionItem_Description ,
				QuestionItem_SequenceNumber = gfunct_questionItems.FirstOrDefault().QuestionItem_SequenceNumber ,

				answerTypes = 
				(
					from el_answerTypes in gfunct_questionItems.Where(element => !EqualsDefaultValue(element.CMN_QST_QuestionItem_EnumerationAnswerTypeID)).ToArray()
					group el_answerTypes by new 
					{ 
						el_answerTypes.CMN_QST_QuestionItem_EnumerationAnswerTypeID,

					}
					into gfunct_answerTypes
					select new L5OS__RSFP_1417_AnswerTypes
					{     
						EnumerationAnswerType_Name = gfunct_answerTypes.FirstOrDefault().EnumerationAnswerType_Name ,
						CMN_QST_QuestionItem_EnumerationAnswerTypeID = gfunct_answerTypes.Key.CMN_QST_QuestionItem_EnumerationAnswerTypeID ,

						EnumerationAnswers = 
						(
							from el_EnumerationAnswers in gfunct_answerTypes.Where(element => !EqualsDefaultValue(element.CMN_QST_QuestionItem_EnumerationAnswerID)).ToArray()
							group el_EnumerationAnswers by new 
							{ 
								el_EnumerationAnswers.CMN_QST_QuestionItem_EnumerationAnswerID,

							}
							into gfunct_EnumerationAnswers
							select new L5OS__RSFP_1417_EnumerationAnswers
							{     
								CMN_QST_QuestionItem_EnumerationAnswerID = gfunct_EnumerationAnswers.Key.CMN_QST_QuestionItem_EnumerationAnswerID ,
								EnumerationAnswer_Text = gfunct_EnumerationAnswers.FirstOrDefault().EnumerationAnswer_Text ,
								EnumerationAnswerType_RefID = gfunct_EnumerationAnswers.FirstOrDefault().EnumerationAnswerType_RefID ,

							}
						).ToArray(),

					}
				).ToArray(),

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5OS__RSFP_1417_Array : FR_Base
	{
		public L5OS__RSFP_1417[] Result	{ get; set; } 
		public FR_L5OS__RSFP_1417_Array() : base() {}

		public FR_L5OS__RSFP_1417_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5OS__RSFP_1417 for attribute P_L5OS__RSFP_1417
		[DataContract]
		public class P_L5OS__RSFP_1417 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProductID { get; set; } 

		}
		#endregion
		#region SClass L5OS__RSFP_1417 for attribute L5OS__RSFP_1417
		[DataContract]
		public class L5OS__RSFP_1417 
		{
			[DataMember]
			public L5OS__RSFP_1417_QuestionItems[] questionItems { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_Product_Questionnaire_AssignmentID { get; set; } 
			[DataMember]
			public Guid QuestionnaireTemplate_RefID { get; set; } 
			[DataMember]
			public Guid CMN_QST_Questionnaire_Template_VersionID { get; set; } 

		}
		#endregion
		#region SClass L5OS__RSFP_1417_QuestionItems for attribute questionItems
		[DataContract]
		public class L5OS__RSFP_1417_QuestionItems 
		{
			[DataMember]
			public L5OS__RSFP_1417_AnswerTypes[] answerTypes { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid CMN_QST_Questionnaire_ItemID { get; set; } 
			[DataMember]
			public Guid Questionnaire_Template_RefID { get; set; } 
			[DataMember]
			public Dict QuestionItem_Label { get; set; } 
			[DataMember]
			public Dict QuestionItem_Description { get; set; } 
			[DataMember]
			public String QuestionItem_SequenceNumber { get; set; } 

		}
		#endregion
		#region SClass L5OS__RSFP_1417_AnswerTypes for attribute answerTypes
		[DataContract]
		public class L5OS__RSFP_1417_AnswerTypes 
		{
			[DataMember]
			public L5OS__RSFP_1417_EnumerationAnswers[] EnumerationAnswers { get; set; }

			//Standard type parameters
			[DataMember]
			public Dict EnumerationAnswerType_Name { get; set; } 
			[DataMember]
			public Guid CMN_QST_QuestionItem_EnumerationAnswerTypeID { get; set; } 

		}
		#endregion
		#region SClass L5OS__RSFP_1417_EnumerationAnswers for attribute EnumerationAnswers
		[DataContract]
		public class L5OS__RSFP_1417_EnumerationAnswers 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_QST_QuestionItem_EnumerationAnswerID { get; set; } 
			[DataMember]
			public Dict EnumerationAnswer_Text { get; set; } 
			[DataMember]
			public Guid EnumerationAnswerType_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5OS__RSFP_1417_Array cls_Get_Survey_For_Product(,P_L5OS__RSFP_1417 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5OS__RSFP_1417_Array invocationResult = cls_Get_Survey_For_Product.Invoke(connectionString,P_L5OS__RSFP_1417 Parameter,securityTicket);
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
var parameter = new CL5_OphthalSurveys.Atomic.Retrieval.P_L5OS__RSFP_1417();
parameter.ProductID = ...;

*/
