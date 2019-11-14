/* 
 * Generated on 11/12/2013 2:13:12 PM
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

namespace CL5_Lucentis_Patient.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_AllPatients_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_AllPatients_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5PA_GPfTID_1308_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5PA_GPfTID_1308_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_Lucentis_Patient.Atomic.Retrieval.SQL.cls_Get_AllPatients_for_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L5PA_GPfTID_1308_raw> results = new List<L5PA_GPfTID_1308_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "HEC_PatientID","PracticeID","FirstName","LastName","BirthDate","HEC_Patient_TreatmentID","TreatmentPractice_RefID","IsTreatmentFollowup","IfSheduled_Date","FollowUp_HEC_Patient_TreatmentID","FollowUp_PracticeID","IsTreatmentFollowupFollowUP","FollowUp_IfSheduled_Date","HEC_ProductID","Product_Name_DictID","ExpectedDateOfDelivery" });
				while(reader.Read())
				{
					L5PA_GPfTID_1308_raw resultItem = new L5PA_GPfTID_1308_raw();
					//0:Parameter HEC_PatientID of type Guid
					resultItem.HEC_PatientID = reader.GetGuid(0);
					//1:Parameter PracticeID of type Guid
					resultItem.PracticeID = reader.GetGuid(1);
					//2:Parameter FirstName of type String
					resultItem.FirstName = reader.GetString(2);
					//3:Parameter LastName of type String
					resultItem.LastName = reader.GetString(3);
					//4:Parameter BirthDate of type DateTime
					resultItem.BirthDate = reader.GetDate(4);
					//5:Parameter HEC_Patient_TreatmentID of type Guid
					resultItem.HEC_Patient_TreatmentID = reader.GetGuid(5);
					//6:Parameter TreatmentPractice_RefID of type Guid
					resultItem.TreatmentPractice_RefID = reader.GetGuid(6);
					//7:Parameter IsTreatmentFollowup of type bool
					resultItem.IsTreatmentFollowup = reader.GetBoolean(7);
					//8:Parameter IfSheduled_Date of type DateTime
					resultItem.IfSheduled_Date = reader.GetDate(8);
					//9:Parameter FollowUp_HEC_Patient_TreatmentID of type Guid
					resultItem.FollowUp_HEC_Patient_TreatmentID = reader.GetGuid(9);
					//10:Parameter FollowUp_PracticeID of type Guid
					resultItem.FollowUp_PracticeID = reader.GetGuid(10);
					//11:Parameter IsTreatmentFollowupFollowUP of type bool
					resultItem.IsTreatmentFollowupFollowUP = reader.GetBoolean(11);
					//12:Parameter FollowUp_IfSheduled_Date of type DateTime
					resultItem.FollowUp_IfSheduled_Date = reader.GetDate(12);
					//13:Parameter HEC_ProductID of type Guid
					resultItem.HEC_ProductID = reader.GetGuid(13);
					//14:Parameter Product_Name of type Dict
					resultItem.Product_Name = reader.GetDictionary(14);
					resultItem.Product_Name.SourceTable = "cmn_pro_products";
					loader.Append(resultItem.Product_Name);
					//15:Parameter ExpectedDateOfDelivery of type String
					resultItem.ExpectedDateOfDelivery = reader.GetString(15);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_AllPatients_for_TenantID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5PA_GPfTID_1308_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5PA_GPfTID_1308_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5PA_GPfTID_1308_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5PA_GPfTID_1308_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5PA_GPfTID_1308_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5PA_GPfTID_1308_Array functionReturn = new FR_L5PA_GPfTID_1308_Array();
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

				functionReturn = Execute(Connection, Transaction,securityTicket);

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

				throw new Exception("Exception occured in method cls_Get_AllPatients_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5PA_GPfTID_1308_raw 
	{
		public Guid HEC_PatientID; 
		public Guid PracticeID; 
		public String FirstName; 
		public String LastName; 
		public DateTime BirthDate; 
		public Guid HEC_Patient_TreatmentID; 
		public Guid TreatmentPractice_RefID; 
		public bool IsTreatmentFollowup; 
		public DateTime IfSheduled_Date; 
		public Guid FollowUp_HEC_Patient_TreatmentID; 
		public Guid FollowUp_PracticeID; 
		public bool IsTreatmentFollowupFollowUP; 
		public DateTime FollowUp_IfSheduled_Date; 
		public Guid HEC_ProductID; 
		public Dict Product_Name; 
		public String ExpectedDateOfDelivery; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5PA_GPfTID_1308[] Convert(List<L5PA_GPfTID_1308_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5PA_GPfTID_1308 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.HEC_PatientID)).ToArray()
	group el_L5PA_GPfTID_1308 by new 
	{ 
		el_L5PA_GPfTID_1308.HEC_PatientID,

	}
	into gfunct_L5PA_GPfTID_1308
	select new L5PA_GPfTID_1308
	{     
		HEC_PatientID = gfunct_L5PA_GPfTID_1308.Key.HEC_PatientID ,
		PracticeID = gfunct_L5PA_GPfTID_1308.FirstOrDefault().PracticeID ,
		FirstName = gfunct_L5PA_GPfTID_1308.FirstOrDefault().FirstName ,
		LastName = gfunct_L5PA_GPfTID_1308.FirstOrDefault().LastName ,
		BirthDate = gfunct_L5PA_GPfTID_1308.FirstOrDefault().BirthDate ,

		Treatments = 
		(
			from el_Treatments in gfunct_L5PA_GPfTID_1308.Where(element => !EqualsDefaultValue(element.HEC_Patient_TreatmentID)).ToArray()
			group el_Treatments by new 
			{ 
				el_Treatments.HEC_Patient_TreatmentID,

			}
			into gfunct_Treatments
			select new L5PA_GPfTID_1308a
			{     
				HEC_Patient_TreatmentID = gfunct_Treatments.Key.HEC_Patient_TreatmentID ,
				TreatmentPractice_RefID = gfunct_Treatments.FirstOrDefault().TreatmentPractice_RefID ,
				IsTreatmentFollowup = gfunct_Treatments.FirstOrDefault().IsTreatmentFollowup ,
				IfSheduled_Date = gfunct_Treatments.FirstOrDefault().IfSheduled_Date ,

				FollowUp = 
				(
					from el_FollowUp in gfunct_Treatments.Where(element => !EqualsDefaultValue(element.FollowUp_HEC_Patient_TreatmentID)).ToArray()
					group el_FollowUp by new 
					{ 
						el_FollowUp.FollowUp_HEC_Patient_TreatmentID,

					}
					into gfunct_FollowUp
					select new L5PA_GPfTID_1308b
					{     
						FollowUp_HEC_Patient_TreatmentID = gfunct_FollowUp.Key.FollowUp_HEC_Patient_TreatmentID ,
						FollowUp_PracticeID = gfunct_FollowUp.FirstOrDefault().FollowUp_PracticeID ,
						IsTreatmentFollowupFollowUP = gfunct_FollowUp.FirstOrDefault().IsTreatmentFollowupFollowUP ,
						FollowUp_IfSheduled_Date = gfunct_FollowUp.FirstOrDefault().FollowUp_IfSheduled_Date ,

					}
				).ToArray(),
				Articles = 
				(
					from el_Articles in gfunct_Treatments.Where(element => !EqualsDefaultValue(element.HEC_ProductID)).ToArray()
					group el_Articles by new 
					{ 
						el_Articles.HEC_ProductID,

					}
					into gfunct_Articles
					select new L5PA_GPfTID_1308c
					{     
						HEC_ProductID = gfunct_Articles.Key.HEC_ProductID ,
						Product_Name = gfunct_Articles.FirstOrDefault().Product_Name ,
						ExpectedDateOfDelivery = gfunct_Articles.FirstOrDefault().ExpectedDateOfDelivery ,

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
	public class FR_L5PA_GPfTID_1308_Array : FR_Base
	{
		public L5PA_GPfTID_1308[] Result	{ get; set; } 
		public FR_L5PA_GPfTID_1308_Array() : base() {}

		public FR_L5PA_GPfTID_1308_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5PA_GPfTID_1308 for attribute L5PA_GPfTID_1308
		[DataContract]
		public class L5PA_GPfTID_1308 
		{
			[DataMember]
			public L5PA_GPfTID_1308a[] Treatments { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid HEC_PatientID { get; set; } 
			[DataMember]
			public Guid PracticeID { get; set; } 
			[DataMember]
			public String FirstName { get; set; } 
			[DataMember]
			public String LastName { get; set; } 
			[DataMember]
			public DateTime BirthDate { get; set; } 

		}
		#endregion
		#region SClass L5PA_GPfTID_1308a for attribute Treatments
		[DataContract]
		public class L5PA_GPfTID_1308a 
		{
			[DataMember]
			public L5PA_GPfTID_1308b[] FollowUp { get; set; }
			[DataMember]
			public L5PA_GPfTID_1308c[] Articles { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid HEC_Patient_TreatmentID { get; set; } 
			[DataMember]
			public Guid TreatmentPractice_RefID { get; set; } 
			[DataMember]
			public bool IsTreatmentFollowup { get; set; } 
			[DataMember]
			public DateTime IfSheduled_Date { get; set; } 

		}
		#endregion
		#region SClass L5PA_GPfTID_1308b for attribute FollowUp
		[DataContract]
		public class L5PA_GPfTID_1308b 
		{
			//Standard type parameters
			[DataMember]
			public Guid FollowUp_HEC_Patient_TreatmentID { get; set; } 
			[DataMember]
			public Guid FollowUp_PracticeID { get; set; } 
			[DataMember]
			public bool IsTreatmentFollowupFollowUP { get; set; } 
			[DataMember]
			public DateTime FollowUp_IfSheduled_Date { get; set; } 

		}
		#endregion
		#region SClass L5PA_GPfTID_1308c for attribute Articles
		[DataContract]
		public class L5PA_GPfTID_1308c 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_ProductID { get; set; } 
			[DataMember]
			public Dict Product_Name { get; set; } 
			[DataMember]
			public String ExpectedDateOfDelivery { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5PA_GPfTID_1308_Array cls_Get_AllPatients_for_TenantID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5PA_GPfTID_1308_Array invocationResult = cls_Get_AllPatients_for_TenantID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

