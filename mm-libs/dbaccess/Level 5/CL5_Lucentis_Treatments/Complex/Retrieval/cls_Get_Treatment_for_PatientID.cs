/* 
 * Generated on 9/27/2013 10:42:32 AM
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

namespace CL5_Lucentis_Treatments.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Treatment_for_PatientID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Treatment_for_PatientID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5TR_GTfPID_1045_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5TR_GTfPID_1045 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5TR_GTfPID_1045_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_Lucentis_Treatments.Complex.Retrieval.SQL.cls_Get_Treatment_for_PatientID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PatientID", Parameter.PatientID);



			List<L5TR_GTfPID_1045_raw> results = new List<L5TR_GTfPID_1045_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "IsTreatmentPerformed","IfTreatmentPerformed_Date","IsTreatmentFollowup","IsScheduled","IfSheduled_Date","IsTreatmentBilled","IfTreatmentBilled_Date","HEC_Patient_TreatmentID","IsTreatmentOfLeftEye","IsTreatmentOfRightEye","Treatment_PracticeID","Treatment_Performed_by_DoctorID","CMN_PRO_ProductID","Product_Number","Quantity","Product_Name_DictID","Status_Name_DictID","ArticleDate","ExpectedDateOfDelivery","HEC_Patient_Treatment_RequiredProductID","BoundTo_CustomerOrderPosition_RefID","PharmacyID","FollowUp_ID","IsFollowUPPerformed","IfFollowUpPerformed_Date","IfFollowUpSheduled_Date","Followup_PracticeID","Followup_Performed_by_DoctorID","Followup_Scheduled_for_DoctorID" });
				while(reader.Read())
				{
					L5TR_GTfPID_1045_raw resultItem = new L5TR_GTfPID_1045_raw();
					//0:Parameter IsTreatmentPerformed of type bool
					resultItem.IsTreatmentPerformed = reader.GetBoolean(0);
					//1:Parameter IfTreatmentPerformed_Date of type DateTime
					resultItem.IfTreatmentPerformed_Date = reader.GetDate(1);
					//2:Parameter IsTreatmentFollowup of type bool
					resultItem.IsTreatmentFollowup = reader.GetBoolean(2);
					//3:Parameter IsScheduled of type bool
					resultItem.IsScheduled = reader.GetBoolean(3);
					//4:Parameter IfSheduled_Date of type DateTime
					resultItem.IfSheduled_Date = reader.GetDate(4);
					//5:Parameter IsTreatmentBilled of type bool
					resultItem.IsTreatmentBilled = reader.GetBoolean(5);
					//6:Parameter IfTreatmentBilled_Date of type DateTime
					resultItem.IfTreatmentBilled_Date = reader.GetDate(6);
					//7:Parameter HEC_Patient_TreatmentID of type Guid
					resultItem.HEC_Patient_TreatmentID = reader.GetGuid(7);
					//8:Parameter IsTreatmentOfLeftEye of type bool
					resultItem.IsTreatmentOfLeftEye = reader.GetBoolean(8);
					//9:Parameter IsTreatmentOfRightEye of type bool
					resultItem.IsTreatmentOfRightEye = reader.GetBoolean(9);
					//10:Parameter Treatment_PracticeID of type Guid
					resultItem.Treatment_PracticeID = reader.GetGuid(10);
					//11:Parameter Treatment_Performed_by_DoctorID of type Guid
					resultItem.Treatment_Performed_by_DoctorID = reader.GetGuid(11);
					//12:Parameter CMN_PRO_ProductID of type Guid
					resultItem.CMN_PRO_ProductID = reader.GetGuid(12);
					//13:Parameter Product_Number of type string
					resultItem.Product_Number = reader.GetString(13);
					//14:Parameter Quantity of type double
					resultItem.Quantity = reader.GetDouble(14);
					//15:Parameter Product_Name of type Dict
					resultItem.Product_Name = reader.GetDictionary(15);
					resultItem.Product_Name.SourceTable = "cmn_pro_products";
					loader.Append(resultItem.Product_Name);
					//16:Parameter Status_Name_DictID of type Dict
					resultItem.Status_Name_DictID = reader.GetDictionary(16);
					resultItem.Status_Name_DictID.SourceTable = "ord_cuo_customerorder_statuses";
					loader.Append(resultItem.Status_Name_DictID);
					//17:Parameter ArticleDate of type DateTime
					resultItem.ArticleDate = reader.GetDate(17);
					//18:Parameter ExpectedDateOfDelivery of type DateTime
					resultItem.ExpectedDateOfDelivery = reader.GetDate(18);
					//19:Parameter HEC_Patient_Treatment_RequiredProductID of type Guid
					resultItem.HEC_Patient_Treatment_RequiredProductID = reader.GetGuid(19);
					//20:Parameter BoundTo_CustomerOrderPosition_RefID of type Guid
					resultItem.BoundTo_CustomerOrderPosition_RefID = reader.GetGuid(20);
					//21:Parameter PharmacyID of type Guid
					resultItem.PharmacyID = reader.GetGuid(21);
					//22:Parameter FollowUp_ID of type Guid
					resultItem.FollowUp_ID = reader.GetGuid(22);
					//23:Parameter IsFollowUPPerformed of type bool
					resultItem.IsFollowUPPerformed = reader.GetBoolean(23);
					//24:Parameter IfFollowUpPerformed_Date of type DateTime
					resultItem.IfFollowUpPerformed_Date = reader.GetDate(24);
					//25:Parameter IfFollowUpSheduled_Date of type DateTime
					resultItem.IfFollowUpSheduled_Date = reader.GetDate(25);
					//26:Parameter Followup_PracticeID of type Guid
					resultItem.Followup_PracticeID = reader.GetGuid(26);
					//27:Parameter Followup_Performed_by_DoctorID of type Guid
					resultItem.Followup_Performed_by_DoctorID = reader.GetGuid(27);
					//28:Parameter Followup_Scheduled_for_DoctorID of type Guid
					resultItem.Followup_Scheduled_for_DoctorID = reader.GetGuid(28);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Treatment_for_PatientID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5TR_GTfPID_1045_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5TR_GTfPID_1045_Array Invoke(string ConnectionString,P_L5TR_GTfPID_1045 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5TR_GTfPID_1045_Array Invoke(DbConnection Connection,P_L5TR_GTfPID_1045 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5TR_GTfPID_1045_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5TR_GTfPID_1045 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5TR_GTfPID_1045_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5TR_GTfPID_1045 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5TR_GTfPID_1045_Array functionReturn = new FR_L5TR_GTfPID_1045_Array();
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

				throw new Exception("Exception occured in method cls_Get_Treatment_for_PatientID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5TR_GTfPID_1045_raw 
	{
		public bool IsTreatmentPerformed; 
		public DateTime IfTreatmentPerformed_Date; 
		public bool IsTreatmentFollowup; 
		public bool IsScheduled; 
		public DateTime IfSheduled_Date; 
		public bool IsTreatmentBilled; 
		public DateTime IfTreatmentBilled_Date; 
		public Guid HEC_Patient_TreatmentID; 
		public bool IsTreatmentOfLeftEye; 
		public bool IsTreatmentOfRightEye; 
		public Guid Treatment_PracticeID; 
		public Guid Treatment_Performed_by_DoctorID; 
		public Guid CMN_PRO_ProductID; 
		public string Product_Number; 
		public double Quantity; 
		public Dict Product_Name; 
		public Dict Status_Name_DictID; 
		public DateTime ArticleDate; 
		public DateTime ExpectedDateOfDelivery; 
		public Guid HEC_Patient_Treatment_RequiredProductID; 
		public Guid BoundTo_CustomerOrderPosition_RefID; 
		public Guid PharmacyID; 
		public Guid FollowUp_ID; 
		public bool IsFollowUPPerformed; 
		public DateTime IfFollowUpPerformed_Date; 
		public DateTime IfFollowUpSheduled_Date; 
		public Guid Followup_PracticeID; 
		public Guid Followup_Performed_by_DoctorID; 
		public Guid Followup_Scheduled_for_DoctorID; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5TR_GTfPID_1045[] Convert(List<L5TR_GTfPID_1045_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5TR_GTfPID_1045 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.HEC_Patient_TreatmentID)).ToArray()
	group el_L5TR_GTfPID_1045 by new 
	{ 
		el_L5TR_GTfPID_1045.HEC_Patient_TreatmentID,

	}
	into gfunct_L5TR_GTfPID_1045
	select new L5TR_GTfPID_1045
	{     
		IsTreatmentPerformed = gfunct_L5TR_GTfPID_1045.FirstOrDefault().IsTreatmentPerformed ,
		IfTreatmentPerformed_Date = gfunct_L5TR_GTfPID_1045.FirstOrDefault().IfTreatmentPerformed_Date ,
		IsTreatmentFollowup = gfunct_L5TR_GTfPID_1045.FirstOrDefault().IsTreatmentFollowup ,
		IsScheduled = gfunct_L5TR_GTfPID_1045.FirstOrDefault().IsScheduled ,
		IfSheduled_Date = gfunct_L5TR_GTfPID_1045.FirstOrDefault().IfSheduled_Date ,
		IsTreatmentBilled = gfunct_L5TR_GTfPID_1045.FirstOrDefault().IsTreatmentBilled ,
		IfTreatmentBilled_Date = gfunct_L5TR_GTfPID_1045.FirstOrDefault().IfTreatmentBilled_Date ,
		HEC_Patient_TreatmentID = gfunct_L5TR_GTfPID_1045.Key.HEC_Patient_TreatmentID ,
		IsTreatmentOfLeftEye = gfunct_L5TR_GTfPID_1045.FirstOrDefault().IsTreatmentOfLeftEye ,
		IsTreatmentOfRightEye = gfunct_L5TR_GTfPID_1045.FirstOrDefault().IsTreatmentOfRightEye ,
		Treatment_PracticeID = gfunct_L5TR_GTfPID_1045.FirstOrDefault().Treatment_PracticeID ,
		Treatment_Performed_by_DoctorID = gfunct_L5TR_GTfPID_1045.FirstOrDefault().Treatment_Performed_by_DoctorID ,

		Article = 
		(
			from el_Article in gfunct_L5TR_GTfPID_1045.Where(element => !EqualsDefaultValue(element.CMN_PRO_ProductID)).ToArray()
			group el_Article by new 
			{ 
				el_Article.CMN_PRO_ProductID,

			}
			into gfunct_Article
			select new L5TR_GTfPID_1045a
			{     
				CMN_PRO_ProductID = gfunct_Article.Key.CMN_PRO_ProductID ,
				Product_Number = gfunct_Article.FirstOrDefault().Product_Number ,
				Quantity = gfunct_Article.FirstOrDefault().Quantity ,
				Product_Name = gfunct_Article.FirstOrDefault().Product_Name ,
				Status_Name_DictID = gfunct_Article.FirstOrDefault().Status_Name_DictID ,
				ArticleDate = gfunct_Article.FirstOrDefault().ArticleDate ,
				ExpectedDateOfDelivery = gfunct_Article.FirstOrDefault().ExpectedDateOfDelivery ,

			}
		).ToArray(),
		RequiredProducts = 
		(
			from el_RequiredProducts in gfunct_L5TR_GTfPID_1045.Where(element => !EqualsDefaultValue(element.HEC_Patient_Treatment_RequiredProductID)).ToArray()
			group el_RequiredProducts by new 
			{ 
				el_RequiredProducts.HEC_Patient_Treatment_RequiredProductID,

			}
			into gfunct_RequiredProducts
			select new L5TR_GTfPID_1045b
			{     
				HEC_Patient_Treatment_RequiredProductID = gfunct_RequiredProducts.Key.HEC_Patient_Treatment_RequiredProductID ,
				BoundTo_CustomerOrderPosition_RefID = gfunct_RequiredProducts.FirstOrDefault().BoundTo_CustomerOrderPosition_RefID ,
				PharmacyID = gfunct_RequiredProducts.FirstOrDefault().PharmacyID ,

			}
		).ToArray(),
		FollowUps = 
		(
			from el_FollowUps in gfunct_L5TR_GTfPID_1045.Where(element => !EqualsDefaultValue(element.FollowUp_ID)).ToArray()
			group el_FollowUps by new 
			{ 
				el_FollowUps.FollowUp_ID,

			}
			into gfunct_FollowUps
			select new L5TR_GTfPID_1045c
			{     
				FollowUp_ID = gfunct_FollowUps.Key.FollowUp_ID ,
				IsFollowUPPerformed = gfunct_FollowUps.FirstOrDefault().IsFollowUPPerformed ,
				IfFollowUpPerformed_Date = gfunct_FollowUps.FirstOrDefault().IfFollowUpPerformed_Date ,
				IfFollowUpSheduled_Date = gfunct_FollowUps.FirstOrDefault().IfFollowUpSheduled_Date ,
				Followup_PracticeID = gfunct_FollowUps.FirstOrDefault().Followup_PracticeID ,
				Followup_Performed_by_DoctorID = gfunct_FollowUps.FirstOrDefault().Followup_Performed_by_DoctorID ,
				Followup_Scheduled_for_DoctorID = gfunct_FollowUps.FirstOrDefault().Followup_Scheduled_for_DoctorID ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5TR_GTfPID_1045_Array : FR_Base
	{
		public L5TR_GTfPID_1045[] Result	{ get; set; } 
		public FR_L5TR_GTfPID_1045_Array() : base() {}

		public FR_L5TR_GTfPID_1045_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5TR_GTfPID_1045 for attribute P_L5TR_GTfPID_1045
		[DataContract]
		public class P_L5TR_GTfPID_1045 
		{
			//Standard type parameters
			[DataMember]
			public Guid PatientID { get; set; } 

		}
		#endregion
		#region SClass L5TR_GTfPID_1045 for attribute L5TR_GTfPID_1045
		[DataContract]
		public class L5TR_GTfPID_1045 
		{
			[DataMember]
			public L5TR_GTfPID_1045a[] Article { get; set; }
			[DataMember]
			public L5TR_GTfPID_1045b[] RequiredProducts { get; set; }
			[DataMember]
			public L5TR_GTfPID_1045c[] FollowUps { get; set; }

			//Standard type parameters
			[DataMember]
			public bool IsTreatmentPerformed { get; set; } 
			[DataMember]
			public DateTime IfTreatmentPerformed_Date { get; set; } 
			[DataMember]
			public bool IsTreatmentFollowup { get; set; } 
			[DataMember]
			public bool IsScheduled { get; set; } 
			[DataMember]
			public DateTime IfSheduled_Date { get; set; } 
			[DataMember]
			public bool IsTreatmentBilled { get; set; } 
			[DataMember]
			public DateTime IfTreatmentBilled_Date { get; set; } 
			[DataMember]
			public Guid HEC_Patient_TreatmentID { get; set; } 
			[DataMember]
			public bool IsTreatmentOfLeftEye { get; set; } 
			[DataMember]
			public bool IsTreatmentOfRightEye { get; set; } 
			[DataMember]
			public Guid Treatment_PracticeID { get; set; } 
			[DataMember]
			public Guid Treatment_Performed_by_DoctorID { get; set; } 

		}
		#endregion
		#region SClass L5TR_GTfPID_1045a for attribute Article
		[DataContract]
		public class L5TR_GTfPID_1045a 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_ProductID { get; set; } 
			[DataMember]
			public string Product_Number { get; set; } 
			[DataMember]
			public double Quantity { get; set; } 
			[DataMember]
			public Dict Product_Name { get; set; } 
			[DataMember]
			public Dict Status_Name_DictID { get; set; } 
			[DataMember]
			public DateTime ArticleDate { get; set; } 
			[DataMember]
			public DateTime ExpectedDateOfDelivery { get; set; } 

		}
		#endregion
		#region SClass L5TR_GTfPID_1045b for attribute RequiredProducts
		[DataContract]
		public class L5TR_GTfPID_1045b 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_Patient_Treatment_RequiredProductID { get; set; } 
			[DataMember]
			public Guid BoundTo_CustomerOrderPosition_RefID { get; set; } 
			[DataMember]
			public Guid PharmacyID { get; set; } 

		}
		#endregion
		#region SClass L5TR_GTfPID_1045c for attribute FollowUps
		[DataContract]
		public class L5TR_GTfPID_1045c 
		{
			//Standard type parameters
			[DataMember]
			public Guid FollowUp_ID { get; set; } 
			[DataMember]
			public bool IsFollowUPPerformed { get; set; } 
			[DataMember]
			public DateTime IfFollowUpPerformed_Date { get; set; } 
			[DataMember]
			public DateTime IfFollowUpSheduled_Date { get; set; } 
			[DataMember]
			public Guid Followup_PracticeID { get; set; } 
			[DataMember]
			public Guid Followup_Performed_by_DoctorID { get; set; } 
			[DataMember]
			public Guid Followup_Scheduled_for_DoctorID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5TR_GTfPID_1045_Array cls_Get_Treatment_for_PatientID(,P_L5TR_GTfPID_1045 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5TR_GTfPID_1045_Array invocationResult = cls_Get_Treatment_for_PatientID.Invoke(connectionString,P_L5TR_GTfPID_1045 Parameter,securityTicket);
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
var parameter = new CL5_Lucentis_Treatments.Complex.Retrieval.P_L5TR_GTfPID_1045();
parameter.PatientID = ...;

*/
