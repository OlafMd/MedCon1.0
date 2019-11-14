/* 
 * Generated on 2/19/2014 3:38:50 PM
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
    /// var result = cls_Get_all_Treatment_for_TennantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_all_Treatment_for_TennantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5TR_GaTfT_1211_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5TR_GaTfT_1211_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_Lucentis_Treatments.Complex.Retrieval.SQL.cls_Get_all_Treatment_for_TennantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L5TR_GaTfT_1211_raw> results = new List<L5TR_GaTfT_1211_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "HEC_Patient_TreatmentID","FirstName","LastName","IsTreatmentBilled","IsScheduled","IfSheduled_Date","IfTreatmentBilled_Date","IsTreatmentFollowup","IsTreatmentPerformed","IfTreatmentPerformed_Date","DisplayName","CompanyName","Tenant_RefID","DoctorFirstName","DoctorLastname","DoctorTitle","DoctorFirstNameScheduled","DoctorLastnameScheduled","DoctorTitleScheduled" });
				while(reader.Read())
				{
					L5TR_GaTfT_1211_raw resultItem = new L5TR_GaTfT_1211_raw();
					//0:Parameter HEC_Patient_TreatmentID of type Guid
					resultItem.HEC_Patient_TreatmentID = reader.GetGuid(0);
					//1:Parameter FirstName of type String
					resultItem.FirstName = reader.GetString(1);
					//2:Parameter LastName of type String
					resultItem.LastName = reader.GetString(2);
					//3:Parameter IsTreatmentBilled of type bool
					resultItem.IsTreatmentBilled = reader.GetBoolean(3);
					//4:Parameter IsScheduled of type bool
					resultItem.IsScheduled = reader.GetBoolean(4);
					//5:Parameter IfSheduled_Date of type DateTime
					resultItem.IfSheduled_Date = reader.GetDate(5);
					//6:Parameter IfTreatmentBilled_Date of type DateTime
					resultItem.IfTreatmentBilled_Date = reader.GetDate(6);
					//7:Parameter IsTreatmentFollowup of type bool
					resultItem.IsTreatmentFollowup = reader.GetBoolean(7);
					//8:Parameter IsTreatmentPerformed of type bool
					resultItem.IsTreatmentPerformed = reader.GetBoolean(8);
					//9:Parameter IfTreatmentPerformed_Date of type DateTime
					resultItem.IfTreatmentPerformed_Date = reader.GetDate(9);
					//10:Parameter DisplayName of type String
					resultItem.DisplayName = reader.GetString(10);
					//11:Parameter CompanyName of type String
					resultItem.CompanyName = reader.GetString(11);
					//12:Parameter Tenant_RefID of type Guid
					resultItem.Tenant_RefID = reader.GetGuid(12);
					//13:Parameter DoctorFirstName of type String
					resultItem.DoctorFirstName = reader.GetString(13);
					//14:Parameter DoctorLastname of type String
					resultItem.DoctorLastname = reader.GetString(14);
					//15:Parameter DoctorTitle of type String
					resultItem.DoctorTitle = reader.GetString(15);
					//16:Parameter DoctorFirstNameScheduled of type String
					resultItem.DoctorFirstNameScheduled = reader.GetString(16);
					//17:Parameter DoctorLastnameScheduled of type String
					resultItem.DoctorLastnameScheduled = reader.GetString(17);
					//18:Parameter DoctorTitleScheduled of type String
					resultItem.DoctorTitleScheduled = reader.GetString(18);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_all_Treatment_for_TennantID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5TR_GaTfT_1211_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5TR_GaTfT_1211_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5TR_GaTfT_1211_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5TR_GaTfT_1211_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5TR_GaTfT_1211_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5TR_GaTfT_1211_Array functionReturn = new FR_L5TR_GaTfT_1211_Array();
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

				throw new Exception("Exception occured in method cls_Get_all_Treatment_for_TennantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5TR_GaTfT_1211_raw 
	{
		public Guid HEC_Patient_TreatmentID; 
		public String FirstName; 
		public String LastName; 
		public bool IsTreatmentBilled; 
		public bool IsScheduled; 
		public DateTime IfSheduled_Date; 
		public DateTime IfTreatmentBilled_Date; 
		public bool IsTreatmentFollowup; 
		public bool IsTreatmentPerformed; 
		public DateTime IfTreatmentPerformed_Date; 
		public String DisplayName; 
		public String CompanyName; 
		public Guid Tenant_RefID; 
		public String DoctorFirstName; 
		public String DoctorLastname; 
		public String DoctorTitle; 
		public String DoctorFirstNameScheduled; 
		public String DoctorLastnameScheduled; 
		public String DoctorTitleScheduled; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5TR_GaTfT_1211[] Convert(List<L5TR_GaTfT_1211_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5TR_GaTfT_1211 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.HEC_Patient_TreatmentID)).ToArray()
	group el_L5TR_GaTfT_1211 by new 
	{ 
		el_L5TR_GaTfT_1211.HEC_Patient_TreatmentID,

	}
	into gfunct_L5TR_GaTfT_1211
	select new L5TR_GaTfT_1211
	{     
		HEC_Patient_TreatmentID = gfunct_L5TR_GaTfT_1211.Key.HEC_Patient_TreatmentID ,
		FirstName = gfunct_L5TR_GaTfT_1211.FirstOrDefault().FirstName ,
		LastName = gfunct_L5TR_GaTfT_1211.FirstOrDefault().LastName ,
		IsTreatmentBilled = gfunct_L5TR_GaTfT_1211.FirstOrDefault().IsTreatmentBilled ,
		IsScheduled = gfunct_L5TR_GaTfT_1211.FirstOrDefault().IsScheduled ,
		IfSheduled_Date = gfunct_L5TR_GaTfT_1211.FirstOrDefault().IfSheduled_Date ,
		IfTreatmentBilled_Date = gfunct_L5TR_GaTfT_1211.FirstOrDefault().IfTreatmentBilled_Date ,
		IsTreatmentFollowup = gfunct_L5TR_GaTfT_1211.FirstOrDefault().IsTreatmentFollowup ,
		IsTreatmentPerformed = gfunct_L5TR_GaTfT_1211.FirstOrDefault().IsTreatmentPerformed ,
		IfTreatmentPerformed_Date = gfunct_L5TR_GaTfT_1211.FirstOrDefault().IfTreatmentPerformed_Date ,
		DisplayName = gfunct_L5TR_GaTfT_1211.FirstOrDefault().DisplayName ,
		CompanyName = gfunct_L5TR_GaTfT_1211.FirstOrDefault().CompanyName ,
		Tenant_RefID = gfunct_L5TR_GaTfT_1211.FirstOrDefault().Tenant_RefID ,

		DoctorPerformed = 
		(
			from el_DoctorPerformed in gfunct_L5TR_GaTfT_1211.ToArray()
			select new L5CO_GCOFPID_1129_DoctorsPerformed
			{     
				DoctorFirstName = el_DoctorPerformed.DoctorFirstName,
				DoctorLastname = el_DoctorPerformed.DoctorLastname,
				DoctorTitle = el_DoctorPerformed.DoctorTitle,

			}
		).FirstOrDefault(),
		DoctorScheduled = 
		(
			from el_DoctorScheduled in gfunct_L5TR_GaTfT_1211.ToArray()
			select new L5CO_GCOFPID_1129_DoctorsScheduled
			{     
				DoctorFirstNameScheduled = el_DoctorScheduled.DoctorFirstNameScheduled,
				DoctorLastnameScheduled = el_DoctorScheduled.DoctorLastnameScheduled,
				DoctorTitleScheduled = el_DoctorScheduled.DoctorTitleScheduled,

			}
		).FirstOrDefault(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5TR_GaTfT_1211_Array : FR_Base
	{
		public L5TR_GaTfT_1211[] Result	{ get; set; } 
		public FR_L5TR_GaTfT_1211_Array() : base() {}

		public FR_L5TR_GaTfT_1211_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5TR_GaTfT_1211 for attribute L5TR_GaTfT_1211
		[DataContract]
		public class L5TR_GaTfT_1211 
		{
			[DataMember]
			public L5CO_GCOFPID_1129_DoctorsPerformed DoctorPerformed { get; set; }
			[DataMember]
			public L5CO_GCOFPID_1129_DoctorsScheduled DoctorScheduled { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid HEC_Patient_TreatmentID { get; set; } 
			[DataMember]
			public String FirstName { get; set; } 
			[DataMember]
			public String LastName { get; set; } 
			[DataMember]
			public bool IsTreatmentBilled { get; set; } 
			[DataMember]
			public bool IsScheduled { get; set; } 
			[DataMember]
			public DateTime IfSheduled_Date { get; set; } 
			[DataMember]
			public DateTime IfTreatmentBilled_Date { get; set; } 
			[DataMember]
			public bool IsTreatmentFollowup { get; set; } 
			[DataMember]
			public bool IsTreatmentPerformed { get; set; } 
			[DataMember]
			public DateTime IfTreatmentPerformed_Date { get; set; } 
			[DataMember]
			public String DisplayName { get; set; } 
			[DataMember]
			public String CompanyName { get; set; } 
			[DataMember]
			public Guid Tenant_RefID { get; set; } 

		}
		#endregion
		#region SClass L5CO_GCOFPID_1129_DoctorsPerformed for attribute DoctorPerformed
		[DataContract]
		public class L5CO_GCOFPID_1129_DoctorsPerformed 
		{
			//Standard type parameters
			[DataMember]
			public String DoctorFirstName { get; set; } 
			[DataMember]
			public String DoctorLastname { get; set; } 
			[DataMember]
			public String DoctorTitle { get; set; } 

		}
		#endregion
		#region SClass L5CO_GCOFPID_1129_DoctorsScheduled for attribute DoctorScheduled
		[DataContract]
		public class L5CO_GCOFPID_1129_DoctorsScheduled 
		{
			//Standard type parameters
			[DataMember]
			public String DoctorFirstNameScheduled { get; set; } 
			[DataMember]
			public String DoctorLastnameScheduled { get; set; } 
			[DataMember]
			public String DoctorTitleScheduled { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5TR_GaTfT_1211_Array cls_Get_all_Treatment_for_TennantID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5TR_GaTfT_1211_Array invocationResult = cls_Get_all_Treatment_for_TennantID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

