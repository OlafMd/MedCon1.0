/* 
 * Generated on 8/26/2013 11:09:56 AM
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
    /// var result = cls_Get_all_FollowUp_Treatments_ForReport.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_all_FollowUp_Treatments_ForReport
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5TR_GaFTfR_1618_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5TR_GaFTfR_1618 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5TR_GaFTfR_1618_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_Lucentis_Treatments.Complex.Retrieval.SQL.cls_Get_all_FollowUp_Treatments_ForReport.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@TreatmentID"," IN $$TreatmentID$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$TreatmentID$",Parameter.TreatmentID);


			List<L5TR_GaFTfR_1618_raw> results = new List<L5TR_GaFTfR_1618_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "HEC_Patient_TreatmentID","FirstName","LastName","IsTreatmentBilled","IsScheduled","IfSheduled_Date","IfTreatmentBilled_Date","IsTreatmentFollowup","IsTreatmentPerformed","IfTreatmentPerformed_Date","DisplayName","IfTreatmentPerformed_Date1","IsTreatmentPerformed1","IsTreatmentFollowup1","IfTreatmentBilled_Date1","IfSheduled_Date1","IsScheduled1","IsTreatmentBilled1","HEC_Patient_TreatmentID1","DoctorFirstName","DoctorLastname","DoctorTitle","ScheduledDoctor_FName","ScheduledDoctor_LName","ScheduledDoctor_title" });
				while(reader.Read())
				{
					L5TR_GaFTfR_1618_raw resultItem = new L5TR_GaFTfR_1618_raw();
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
					//11:Parameter IfTreatmentPerformed_Date1 of type DateTime
					resultItem.IfTreatmentPerformed_Date1 = reader.GetDate(11);
					//12:Parameter IsTreatmentPerformed1 of type bool
					resultItem.IsTreatmentPerformed1 = reader.GetBoolean(12);
					//13:Parameter IsTreatmentFollowup1 of type bool
					resultItem.IsTreatmentFollowup1 = reader.GetBoolean(13);
					//14:Parameter IfTreatmentBilled_Date1 of type DateTime
					resultItem.IfTreatmentBilled_Date1 = reader.GetDate(14);
					//15:Parameter IfSheduled_Date1 of type DateTime
					resultItem.IfSheduled_Date1 = reader.GetDate(15);
					//16:Parameter IsScheduled1 of type bool
					resultItem.IsScheduled1 = reader.GetBoolean(16);
					//17:Parameter IsTreatmentBilled1 of type bool
					resultItem.IsTreatmentBilled1 = reader.GetBoolean(17);
					//18:Parameter HEC_Patient_TreatmentID1 of type Guid
					resultItem.HEC_Patient_TreatmentID1 = reader.GetGuid(18);
					//19:Parameter DoctorFirstName of type String
					resultItem.DoctorFirstName = reader.GetString(19);
					//20:Parameter DoctorLastname of type String
					resultItem.DoctorLastname = reader.GetString(20);
					//21:Parameter DoctorTitle of type String
					resultItem.DoctorTitle = reader.GetString(21);
					//22:Parameter ScheduledDoctor_FName of type String
					resultItem.ScheduledDoctor_FName = reader.GetString(22);
					//23:Parameter ScheduledDoctor_LName of type String
					resultItem.ScheduledDoctor_LName = reader.GetString(23);
					//24:Parameter ScheduledDoctor_title of type String
					resultItem.ScheduledDoctor_title = reader.GetString(24);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_all_FollowUp_Treatments_ForReport",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5TR_GaFTfR_1618_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5TR_GaFTfR_1618_Array Invoke(string ConnectionString,P_L5TR_GaFTfR_1618 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5TR_GaFTfR_1618_Array Invoke(DbConnection Connection,P_L5TR_GaFTfR_1618 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5TR_GaFTfR_1618_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5TR_GaFTfR_1618 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5TR_GaFTfR_1618_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5TR_GaFTfR_1618 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5TR_GaFTfR_1618_Array functionReturn = new FR_L5TR_GaFTfR_1618_Array();
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

				throw new Exception("Exception occured in method cls_Get_all_FollowUp_Treatments_ForReport",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5TR_GaFTfR_1618_raw 
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
		public DateTime IfTreatmentPerformed_Date1; 
		public bool IsTreatmentPerformed1; 
		public bool IsTreatmentFollowup1; 
		public DateTime IfTreatmentBilled_Date1; 
		public DateTime IfSheduled_Date1; 
		public bool IsScheduled1; 
		public bool IsTreatmentBilled1; 
		public Guid HEC_Patient_TreatmentID1; 
		public String DoctorFirstName; 
		public String DoctorLastname; 
		public String DoctorTitle; 
		public String ScheduledDoctor_FName; 
		public String ScheduledDoctor_LName; 
		public String ScheduledDoctor_title; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5TR_GaFTfR_1618[] Convert(List<L5TR_GaFTfR_1618_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5TR_GaFTfR_1618 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.HEC_Patient_TreatmentID)).ToArray()
	group el_L5TR_GaFTfR_1618 by new 
	{ 
		el_L5TR_GaFTfR_1618.HEC_Patient_TreatmentID,

	}
	into gfunct_L5TR_GaFTfR_1618
	select new L5TR_GaFTfR_1618
	{     
		HEC_Patient_TreatmentID = gfunct_L5TR_GaFTfR_1618.Key.HEC_Patient_TreatmentID ,
		FirstName = gfunct_L5TR_GaFTfR_1618.FirstOrDefault().FirstName ,
		LastName = gfunct_L5TR_GaFTfR_1618.FirstOrDefault().LastName ,
		IsTreatmentBilled = gfunct_L5TR_GaFTfR_1618.FirstOrDefault().IsTreatmentBilled ,
		IsScheduled = gfunct_L5TR_GaFTfR_1618.FirstOrDefault().IsScheduled ,
		IfSheduled_Date = gfunct_L5TR_GaFTfR_1618.FirstOrDefault().IfSheduled_Date ,
		IfTreatmentBilled_Date = gfunct_L5TR_GaFTfR_1618.FirstOrDefault().IfTreatmentBilled_Date ,
		IsTreatmentFollowup = gfunct_L5TR_GaFTfR_1618.FirstOrDefault().IsTreatmentFollowup ,
		IsTreatmentPerformed = gfunct_L5TR_GaFTfR_1618.FirstOrDefault().IsTreatmentPerformed ,
		IfTreatmentPerformed_Date = gfunct_L5TR_GaFTfR_1618.FirstOrDefault().IfTreatmentPerformed_Date ,

		FollowUps = 
		(
			from el_FollowUps in gfunct_L5TR_GaFTfR_1618.Where(element => !EqualsDefaultValue(element.HEC_Patient_TreatmentID1)).ToArray()
			group el_FollowUps by new 
			{ 
				el_FollowUps.HEC_Patient_TreatmentID1,

			}
			into gfunct_FollowUps
			select new L5TR_GaFTfR_1618_FollowUps
			{     
				DisplayName = gfunct_FollowUps.FirstOrDefault().DisplayName ,
				IfTreatmentPerformed_Date1 = gfunct_FollowUps.FirstOrDefault().IfTreatmentPerformed_Date1 ,
				IsTreatmentPerformed1 = gfunct_FollowUps.FirstOrDefault().IsTreatmentPerformed1 ,
				IsTreatmentFollowup1 = gfunct_FollowUps.FirstOrDefault().IsTreatmentFollowup1 ,
				IfTreatmentBilled_Date1 = gfunct_FollowUps.FirstOrDefault().IfTreatmentBilled_Date1 ,
				IfSheduled_Date1 = gfunct_FollowUps.FirstOrDefault().IfSheduled_Date1 ,
				IsScheduled1 = gfunct_FollowUps.FirstOrDefault().IsScheduled1 ,
				IsTreatmentBilled1 = gfunct_FollowUps.FirstOrDefault().IsTreatmentBilled1 ,
				HEC_Patient_TreatmentID1 = gfunct_FollowUps.Key.HEC_Patient_TreatmentID1 ,

				DoctorPerformed = 
				(
					from el_DoctorPerformed in gfunct_FollowUps.ToArray()
					select new L5TR_GaFTfR_1618_FollowUps_DoctorsPerformed
					{     
						DoctorFirstName = el_DoctorPerformed.DoctorFirstName,
						DoctorLastname = el_DoctorPerformed.DoctorLastname,
						DoctorTitle = el_DoctorPerformed.DoctorTitle,

					}
				).FirstOrDefault(),
				ScheduledDoctor = 
				(
					from el_ScheduledDoctor in gfunct_FollowUps.ToArray()
					select new L5TR_GaFTfR_1618_FollowUps_ScheduledDoctor
					{     
						ScheduledDoctor_FName = el_ScheduledDoctor.ScheduledDoctor_FName,
						ScheduledDoctor_LName = el_ScheduledDoctor.ScheduledDoctor_LName,
						ScheduledDoctor_title = el_ScheduledDoctor.ScheduledDoctor_title,

					}
				).FirstOrDefault(),

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5TR_GaFTfR_1618_Array : FR_Base
	{
		public L5TR_GaFTfR_1618[] Result	{ get; set; } 
		public FR_L5TR_GaFTfR_1618_Array() : base() {}

		public FR_L5TR_GaFTfR_1618_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5TR_GaFTfR_1618 for attribute P_L5TR_GaFTfR_1618
		[DataContract]
		public class P_L5TR_GaFTfR_1618 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] TreatmentID { get; set; } 

		}
		#endregion
		#region SClass L5TR_GaFTfR_1618 for attribute L5TR_GaFTfR_1618
		[DataContract]
		public class L5TR_GaFTfR_1618 
		{
			[DataMember]
			public L5TR_GaFTfR_1618_FollowUps[] FollowUps { get; set; }

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

		}
		#endregion
		#region SClass L5TR_GaFTfR_1618_FollowUps for attribute FollowUps
		[DataContract]
		public class L5TR_GaFTfR_1618_FollowUps 
		{
			[DataMember]
			public L5TR_GaFTfR_1618_FollowUps_DoctorsPerformed DoctorPerformed { get; set; }
			[DataMember]
			public L5TR_GaFTfR_1618_FollowUps_ScheduledDoctor ScheduledDoctor { get; set; }

			//Standard type parameters
			[DataMember]
			public String DisplayName { get; set; } 
			[DataMember]
			public DateTime IfTreatmentPerformed_Date1 { get; set; } 
			[DataMember]
			public bool IsTreatmentPerformed1 { get; set; } 
			[DataMember]
			public bool IsTreatmentFollowup1 { get; set; } 
			[DataMember]
			public DateTime IfTreatmentBilled_Date1 { get; set; } 
			[DataMember]
			public DateTime IfSheduled_Date1 { get; set; } 
			[DataMember]
			public bool IsScheduled1 { get; set; } 
			[DataMember]
			public bool IsTreatmentBilled1 { get; set; } 
			[DataMember]
			public Guid HEC_Patient_TreatmentID1 { get; set; } 

		}
		#endregion
		#region SClass L5TR_GaFTfR_1618_FollowUps_DoctorsPerformed for attribute DoctorPerformed
		[DataContract]
		public class L5TR_GaFTfR_1618_FollowUps_DoctorsPerformed 
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
		#region SClass L5TR_GaFTfR_1618_FollowUps_ScheduledDoctor for attribute ScheduledDoctor
		[DataContract]
		public class L5TR_GaFTfR_1618_FollowUps_ScheduledDoctor 
		{
			//Standard type parameters
			[DataMember]
			public String ScheduledDoctor_FName { get; set; } 
			[DataMember]
			public String ScheduledDoctor_LName { get; set; } 
			[DataMember]
			public String ScheduledDoctor_title { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5TR_GaFTfR_1618_Array cls_Get_all_FollowUp_Treatments_ForReport(,P_L5TR_GaFTfR_1618 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5TR_GaFTfR_1618_Array invocationResult = cls_Get_all_FollowUp_Treatments_ForReport.Invoke(connectionString,P_L5TR_GaFTfR_1618 Parameter,securityTicket);
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
var parameter = new CL5_Lucentis_Treatments.Complex.Retrieval.P_L5TR_GaFTfR_1618();
parameter.TreatmentID = ...;

*/
