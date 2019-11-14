/* 
 * Generated on 8/30/2013 11:21:19 AM
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

namespace CL5_OphthalShipments.Atomic.Retrieval
{
	/// <summary>
    /// No description found in <meta/> tag
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ShippmentPositionsForDoctorID_and_DateRange.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ShippmentPositionsForDoctorID_and_DateRange
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5OS_GSPfDaDR_0402_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5OS_GSPfDaDR_0402 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5OS_GSPfDaDR_0402_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_OphthalShipments.Atomic.Retrieval.SQL.cls_Get_ShippmentPositionsForDoctorID_and_DateRange.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"HEC_DoctorID", Parameter.HEC_DoctorID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"FormDate", Parameter.FormDate);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ToDate", Parameter.ToDate);



			List<L5OS_GSPfDaDR_0402_raw> results = new List<L5OS_GSPfDaDR_0402_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "HEC_ShippingPosition_BarcodeLabelID","CMN_PRO_ProductID","LOG_SHP_Shipment_PositionID","LOG_SHP_Shipment_HeaderID","CMN_QST_Questionnaire_SubmissionID","HEC_ShippingPosition_QuestionnaireSubmissionID","ShippingPosition_BarcodeLabel","Product_Number","Header_Creation_Timestamp","R_IsSubmission_Complete","Header_IsShipped","Product_Name_DictID","Product_Description_DictID","CMN_QST_Questionnaire_SubmissionItemID","CMN_QST_QuestionItem_EnumerationAnswerID","CMN_QST_Questionnaire_ItemID","QuestionItem_SequenceNumber","QuestionItem_Label_DictID","EnumerationAnswer_Text_DictID" });
				while(reader.Read())
				{
					L5OS_GSPfDaDR_0402_raw resultItem = new L5OS_GSPfDaDR_0402_raw();
					//0:Parameter HEC_ShippingPosition_BarcodeLabelID of type Guid
					resultItem.HEC_ShippingPosition_BarcodeLabelID = reader.GetGuid(0);
					//1:Parameter CMN_PRO_ProductID of type Guid
					resultItem.CMN_PRO_ProductID = reader.GetGuid(1);
					//2:Parameter LOG_SHP_Shipment_PositionID of type Guid
					resultItem.LOG_SHP_Shipment_PositionID = reader.GetGuid(2);
					//3:Parameter LOG_SHP_Shipment_HeaderID of type Guid
					resultItem.LOG_SHP_Shipment_HeaderID = reader.GetGuid(3);
					//4:Parameter CMN_QST_Questionnaire_SubmissionID of type Guid
					resultItem.CMN_QST_Questionnaire_SubmissionID = reader.GetGuid(4);
					//5:Parameter HEC_ShippingPosition_QuestionnaireSubmissionID of type Guid
					resultItem.HEC_ShippingPosition_QuestionnaireSubmissionID = reader.GetGuid(5);
					//6:Parameter ShippingPosition_BarcodeLabel of type String
					resultItem.ShippingPosition_BarcodeLabel = reader.GetString(6);
					//7:Parameter Product_Number of type String
					resultItem.Product_Number = reader.GetString(7);
					//8:Parameter Header_Creation_Timestamp of type DateTime
					resultItem.Header_Creation_Timestamp = reader.GetDate(8);
					//9:Parameter R_IsSubmission_Complete of type bool
					resultItem.R_IsSubmission_Complete = reader.GetBoolean(9);
					//10:Parameter Header_IsShipped of type bool
					resultItem.Header_IsShipped = reader.GetBoolean(10);
					//11:Parameter Product_Name_DictID of type Dict
					resultItem.Product_Name_DictID = reader.GetDictionary(11);
					resultItem.Product_Name_DictID.SourceTable = "cmn_pro_products";
					loader.Append(resultItem.Product_Name_DictID);
					//12:Parameter Product_Description_DictID of type Dict
					resultItem.Product_Description_DictID = reader.GetDictionary(12);
					resultItem.Product_Description_DictID.SourceTable = "cmn_pro_products";
					loader.Append(resultItem.Product_Description_DictID);
					//13:Parameter CMN_QST_Questionnaire_SubmissionItemID of type Guid
					resultItem.CMN_QST_Questionnaire_SubmissionItemID = reader.GetGuid(13);
					//14:Parameter CMN_QST_QuestionItem_EnumerationAnswerID of type Guid
					resultItem.CMN_QST_QuestionItem_EnumerationAnswerID = reader.GetGuid(14);
					//15:Parameter CMN_QST_Questionnaire_ItemID of type Guid
					resultItem.CMN_QST_Questionnaire_ItemID = reader.GetGuid(15);
					//16:Parameter QuestionItem_SequenceNumber of type int
					resultItem.QuestionItem_SequenceNumber = reader.GetInteger(16);
					//17:Parameter QuestionItem_Label of type Dict
					resultItem.QuestionItem_Label = reader.GetDictionary(17);
					resultItem.QuestionItem_Label.SourceTable = "cmn_qst_questionnaire_questionitems";
					loader.Append(resultItem.QuestionItem_Label);
					//18:Parameter EnumerationAnswer_Text_DictID of type Dict
					resultItem.EnumerationAnswer_Text_DictID = reader.GetDictionary(18);
					resultItem.EnumerationAnswer_Text_DictID.SourceTable = "cmn_qst_questionitem_enumerationanswers";
					loader.Append(resultItem.EnumerationAnswer_Text_DictID);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_ShippmentPositionsForDoctorID_and_DateRange",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5OS_GSPfDaDR_0402_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5OS_GSPfDaDR_0402_Array Invoke(string ConnectionString,P_L5OS_GSPfDaDR_0402 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5OS_GSPfDaDR_0402_Array Invoke(DbConnection Connection,P_L5OS_GSPfDaDR_0402 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5OS_GSPfDaDR_0402_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5OS_GSPfDaDR_0402 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5OS_GSPfDaDR_0402_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5OS_GSPfDaDR_0402 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5OS_GSPfDaDR_0402_Array functionReturn = new FR_L5OS_GSPfDaDR_0402_Array();
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

				throw new Exception("Exception occured in method cls_Get_ShippmentPositionsForDoctorID_and_DateRange",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5OS_GSPfDaDR_0402_raw 
	{
		public Guid HEC_ShippingPosition_BarcodeLabelID; 
		public Guid CMN_PRO_ProductID; 
		public Guid LOG_SHP_Shipment_PositionID; 
		public Guid LOG_SHP_Shipment_HeaderID; 
		public Guid CMN_QST_Questionnaire_SubmissionID; 
		public Guid HEC_ShippingPosition_QuestionnaireSubmissionID; 
		public String ShippingPosition_BarcodeLabel; 
		public String Product_Number; 
		public DateTime Header_Creation_Timestamp; 
		public bool R_IsSubmission_Complete; 
		public bool Header_IsShipped; 
		public Dict Product_Name_DictID; 
		public Dict Product_Description_DictID; 
		public Guid CMN_QST_Questionnaire_SubmissionItemID; 
		public Guid CMN_QST_QuestionItem_EnumerationAnswerID; 
		public Guid CMN_QST_Questionnaire_ItemID; 
		public int QuestionItem_SequenceNumber; 
		public Dict QuestionItem_Label; 
		public Dict EnumerationAnswer_Text_DictID; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5OS_GSPfDaDR_0402[] Convert(List<L5OS_GSPfDaDR_0402_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5OS_GSPfDaDR_0402 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.HEC_ShippingPosition_BarcodeLabelID)).ToArray()
	group el_L5OS_GSPfDaDR_0402 by new 
	{ 
		el_L5OS_GSPfDaDR_0402.HEC_ShippingPosition_BarcodeLabelID,

	}
	into gfunct_L5OS_GSPfDaDR_0402
	select new L5OS_GSPfDaDR_0402
	{     
		HEC_ShippingPosition_BarcodeLabelID = gfunct_L5OS_GSPfDaDR_0402.Key.HEC_ShippingPosition_BarcodeLabelID ,
		CMN_PRO_ProductID = gfunct_L5OS_GSPfDaDR_0402.FirstOrDefault().CMN_PRO_ProductID ,
		LOG_SHP_Shipment_PositionID = gfunct_L5OS_GSPfDaDR_0402.FirstOrDefault().LOG_SHP_Shipment_PositionID ,
		LOG_SHP_Shipment_HeaderID = gfunct_L5OS_GSPfDaDR_0402.FirstOrDefault().LOG_SHP_Shipment_HeaderID ,
		CMN_QST_Questionnaire_SubmissionID = gfunct_L5OS_GSPfDaDR_0402.FirstOrDefault().CMN_QST_Questionnaire_SubmissionID ,
		HEC_ShippingPosition_QuestionnaireSubmissionID = gfunct_L5OS_GSPfDaDR_0402.FirstOrDefault().HEC_ShippingPosition_QuestionnaireSubmissionID ,
		ShippingPosition_BarcodeLabel = gfunct_L5OS_GSPfDaDR_0402.FirstOrDefault().ShippingPosition_BarcodeLabel ,
		Product_Number = gfunct_L5OS_GSPfDaDR_0402.FirstOrDefault().Product_Number ,
		Header_Creation_Timestamp = gfunct_L5OS_GSPfDaDR_0402.FirstOrDefault().Header_Creation_Timestamp ,
		R_IsSubmission_Complete = gfunct_L5OS_GSPfDaDR_0402.FirstOrDefault().R_IsSubmission_Complete ,
		Header_IsShipped = gfunct_L5OS_GSPfDaDR_0402.FirstOrDefault().Header_IsShipped ,
		Product_Name_DictID = gfunct_L5OS_GSPfDaDR_0402.FirstOrDefault().Product_Name_DictID ,
		Product_Description_DictID = gfunct_L5OS_GSPfDaDR_0402.FirstOrDefault().Product_Description_DictID ,

		QuestionAnswerPairs = 
		(
			from el_QuestionAnswerPairs in gfunct_L5OS_GSPfDaDR_0402.Where(element => !EqualsDefaultValue(element.CMN_QST_Questionnaire_ItemID)).ToArray()
			group el_QuestionAnswerPairs by new 
			{ 
				el_QuestionAnswerPairs.CMN_QST_Questionnaire_ItemID,

			}
			into gfunct_QuestionAnswerPairs
			select new L5OS_GSPfDaDR_0402_QuestionAnswerPair
			{     
				CMN_QST_Questionnaire_SubmissionItemID = gfunct_QuestionAnswerPairs.FirstOrDefault().CMN_QST_Questionnaire_SubmissionItemID ,
				CMN_QST_QuestionItem_EnumerationAnswerID = gfunct_QuestionAnswerPairs.FirstOrDefault().CMN_QST_QuestionItem_EnumerationAnswerID ,
				CMN_QST_Questionnaire_ItemID = gfunct_QuestionAnswerPairs.Key.CMN_QST_Questionnaire_ItemID ,
				QuestionItem_SequenceNumber = gfunct_QuestionAnswerPairs.FirstOrDefault().QuestionItem_SequenceNumber ,
				QuestionItem_Label = gfunct_QuestionAnswerPairs.FirstOrDefault().QuestionItem_Label ,
				EnumerationAnswer_Text_DictID = gfunct_QuestionAnswerPairs.FirstOrDefault().EnumerationAnswer_Text_DictID ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5OS_GSPfDaDR_0402_Array : FR_Base
	{
		public L5OS_GSPfDaDR_0402[] Result	{ get; set; } 
		public FR_L5OS_GSPfDaDR_0402_Array() : base() {}

		public FR_L5OS_GSPfDaDR_0402_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5OS_GSPfDaDR_0402 for attribute P_L5OS_GSPfDaDR_0402
		[DataContract]
		public class P_L5OS_GSPfDaDR_0402 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_DoctorID { get; set; } 
			[DataMember]
			public DateTime FormDate { get; set; } 
			[DataMember]
			public DateTime ToDate { get; set; } 

		}
		#endregion
		#region SClass L5OS_GSPfDaDR_0402 for attribute L5OS_GSPfDaDR_0402
		[DataContract]
		public class L5OS_GSPfDaDR_0402 
		{
			[DataMember]
			public L5OS_GSPfDaDR_0402_QuestionAnswerPair[] QuestionAnswerPairs { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid HEC_ShippingPosition_BarcodeLabelID { get; set; } 
			[DataMember]
			public Guid CMN_PRO_ProductID { get; set; } 
			[DataMember]
			public Guid LOG_SHP_Shipment_PositionID { get; set; } 
			[DataMember]
			public Guid LOG_SHP_Shipment_HeaderID { get; set; } 
			[DataMember]
			public Guid CMN_QST_Questionnaire_SubmissionID { get; set; } 
			[DataMember]
			public Guid HEC_ShippingPosition_QuestionnaireSubmissionID { get; set; } 
			[DataMember]
			public String ShippingPosition_BarcodeLabel { get; set; } 
			[DataMember]
			public String Product_Number { get; set; } 
			[DataMember]
			public DateTime Header_Creation_Timestamp { get; set; } 
			[DataMember]
			public bool R_IsSubmission_Complete { get; set; } 
			[DataMember]
			public bool Header_IsShipped { get; set; } 
			[DataMember]
			public Dict Product_Name_DictID { get; set; } 
			[DataMember]
			public Dict Product_Description_DictID { get; set; } 

		}
		#endregion
		#region SClass L5OS_GSPfDaDR_0402_QuestionAnswerPair for attribute QuestionAnswerPairs
		[DataContract]
		public class L5OS_GSPfDaDR_0402_QuestionAnswerPair 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_QST_Questionnaire_SubmissionItemID { get; set; } 
			[DataMember]
			public Guid CMN_QST_QuestionItem_EnumerationAnswerID { get; set; } 
			[DataMember]
			public Guid CMN_QST_Questionnaire_ItemID { get; set; } 
			[DataMember]
			public int QuestionItem_SequenceNumber { get; set; } 
			[DataMember]
			public Dict QuestionItem_Label { get; set; } 
			[DataMember]
			public Dict EnumerationAnswer_Text_DictID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5OS_GSPfDaDR_0402_Array cls_Get_ShippmentPositionsForDoctorID_and_DateRange(,P_L5OS_GSPfDaDR_0402 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5OS_GSPfDaDR_0402_Array invocationResult = cls_Get_ShippmentPositionsForDoctorID_and_DateRange.Invoke(connectionString,P_L5OS_GSPfDaDR_0402 Parameter,securityTicket);
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
var parameter = new CL5_OphthalShipments.Atomic.Retrieval.P_L5OS_GSPfDaDR_0402();
parameter.HEC_DoctorID = ...;
parameter.FormDate = ...;
parameter.ToDate = ...;

*/
