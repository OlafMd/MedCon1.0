/* 
 * Generated on 7/8/2013 1:45:29 PM
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

namespace CL6_Lucenits_Treatments.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Followups_for_TreatmentID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Followups_for_TreatmentID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6TR_GFfT_1704_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L6TR_GFfT_1704 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L6TR_GFfT_1704_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL6_Lucenits_Treatments.Atomic.Retrieval.SQL.cls_Get_Followups_for_TreatmentID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"TreatmentID", Parameter.TreatmentID);


			List<L6TR_GFfT_1704> results = new List<L6TR_GFfT_1704>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "HEC_Patient_TreatmentID","IsTreatmentPerformed","IfTreatmentPerformed_Date","IsScheduled","IfSheduled_Date","IfTreatmentPerformed_ByDoctor_RefID","IsTreatmentBilled","IfTreatmentBilled_Date","Treatment_Comment","TreatmentPractice_RefID","PracticeName","FirstName","LastName","Title","DoctorFirstNameScheduled","DoctorLastnameScheduled","DoctorTitleScheduled","ScheduledDoctorID" });
				while(reader.Read())
				{
					L6TR_GFfT_1704 resultItem = new L6TR_GFfT_1704();
					//0:Parameter HEC_Patient_TreatmentID of type Guid
					resultItem.HEC_Patient_TreatmentID = reader.GetGuid(0);
					//1:Parameter IsTreatmentPerformed of type bool
					resultItem.IsTreatmentPerformed = reader.GetBoolean(1);
					//2:Parameter IfTreatmentPerformed_Date of type DateTime
					resultItem.IfTreatmentPerformed_Date = reader.GetDate(2);
					//3:Parameter IsScheduled of type bool
					resultItem.IsScheduled = reader.GetBoolean(3);
					//4:Parameter IfSheduled_Date of type DateTime
					resultItem.IfSheduled_Date = reader.GetDate(4);
					//5:Parameter IfTreatmentPerformed_ByDoctor_RefID of type Guid
					resultItem.IfTreatmentPerformed_ByDoctor_RefID = reader.GetGuid(5);
					//6:Parameter IsTreatmentBilled of type bool
					resultItem.IsTreatmentBilled = reader.GetBoolean(6);
					//7:Parameter IfTreatmentBilled_Date of type DateTime
					resultItem.IfTreatmentBilled_Date = reader.GetDate(7);
					//8:Parameter Treatment_Comment of type String
					resultItem.Treatment_Comment = reader.GetString(8);
					//9:Parameter TreatmentPractice_RefID of type Guid
					resultItem.TreatmentPractice_RefID = reader.GetGuid(9);
					//10:Parameter PracticeName of type String
					resultItem.PracticeName = reader.GetString(10);
					//11:Parameter FirstName of type String
					resultItem.FirstName = reader.GetString(11);
					//12:Parameter LastName of type String
					resultItem.LastName = reader.GetString(12);
					//13:Parameter Title of type String
					resultItem.Title = reader.GetString(13);
					//14:Parameter DoctorFirstNameScheduled of type String
					resultItem.DoctorFirstNameScheduled = reader.GetString(14);
					//15:Parameter DoctorLastnameScheduled of type String
					resultItem.DoctorLastnameScheduled = reader.GetString(15);
					//16:Parameter DoctorTitleScheduled of type String
					resultItem.DoctorTitleScheduled = reader.GetString(16);
					//17:Parameter ScheduledDoctorID of type String
					resultItem.ScheduledDoctorID = reader.GetString(17);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw ex;
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
		public static FR_L6TR_GFfT_1704_Array Invoke(string ConnectionString,P_L6TR_GFfT_1704 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6TR_GFfT_1704_Array Invoke(DbConnection Connection,P_L6TR_GFfT_1704 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6TR_GFfT_1704_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L6TR_GFfT_1704 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6TR_GFfT_1704_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6TR_GFfT_1704 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6TR_GFfT_1704_Array functionReturn = new FR_L6TR_GFfT_1704_Array();
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

	#region Custom Return Type
	[Serializable]
	public class FR_L6TR_GFfT_1704_Array : FR_Base
	{
		public L6TR_GFfT_1704[] Result	{ get; set; } 
		public FR_L6TR_GFfT_1704_Array() : base() {}

		public FR_L6TR_GFfT_1704_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6TR_GFfT_1704 for attribute P_L6TR_GFfT_1704
		[DataContract]
		public class P_L6TR_GFfT_1704 
		{
			//Standard type parameters
			[DataMember]
			public Guid TreatmentID { get; set; } 

		}
		#endregion
		#region SClass L6TR_GFfT_1704 for attribute L6TR_GFfT_1704
		[DataContract]
		public class L6TR_GFfT_1704 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_Patient_TreatmentID { get; set; } 
			[DataMember]
			public bool IsTreatmentPerformed { get; set; } 
			[DataMember]
			public DateTime IfTreatmentPerformed_Date { get; set; } 
			[DataMember]
			public bool IsScheduled { get; set; } 
			[DataMember]
			public DateTime IfSheduled_Date { get; set; } 
			[DataMember]
			public Guid IfTreatmentPerformed_ByDoctor_RefID { get; set; } 
			[DataMember]
			public bool IsTreatmentBilled { get; set; } 
			[DataMember]
			public DateTime IfTreatmentBilled_Date { get; set; } 
			[DataMember]
			public String Treatment_Comment { get; set; } 
			[DataMember]
			public Guid TreatmentPractice_RefID { get; set; } 
			[DataMember]
			public String PracticeName { get; set; } 
			[DataMember]
			public String FirstName { get; set; } 
			[DataMember]
			public String LastName { get; set; } 
			[DataMember]
			public String Title { get; set; } 
			[DataMember]
			public String DoctorFirstNameScheduled { get; set; } 
			[DataMember]
			public String DoctorLastnameScheduled { get; set; } 
			[DataMember]
			public String DoctorTitleScheduled { get; set; } 
			[DataMember]
			public String ScheduledDoctorID { get; set; } 

		}
		#endregion

	#endregion
}
