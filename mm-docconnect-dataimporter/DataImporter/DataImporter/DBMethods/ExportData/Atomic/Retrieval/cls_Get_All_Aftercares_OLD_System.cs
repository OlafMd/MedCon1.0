/* 
 * Generated on 1/20/2017 2:34:26 PM
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

namespace DataImporter.DBMethods.ExportData.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_All_Aftercares_OLD_System.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_All_Aftercares_OLD_System
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_ED_GAAOS_1312_Array Execute(DbConnection Connection,DbTransaction Transaction,P_ED_GAAOS_1312 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_ED_GAAOS_1312_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "DataImporter.DBMethods.ExportData.Atomic.Retrieval.SQL.cls_Get_All_Aftercares_OLD_System.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"TreatmentID", Parameter.TreatmentID);



			List<ED_GAAOS_1312> results = new List<ED_GAAOS_1312>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "FollowupID","isTreatmentPerformed","IsScheduled","isTreatmentBilled","IfSheduled_Date","IfTreatmentPerformed_Date","PerformedDoctorLANR","PerformedDoctorFirstName","PerformedDoctorLastName","ScheduledDoctorLANR","ScheduledDoctorFirstName","ScheduledDoctorLastName","VorgangsNummer","PositionValue_IncludingTax","External_PositionType","BIL_BillPositionID","TransmitionCode","PrimaryComment","SecondaryComment","PracticeName","BSNR","TransmittedOnDate","GPOS" });
				while(reader.Read())
				{
					ED_GAAOS_1312 resultItem = new ED_GAAOS_1312();
					//0:Parameter FollowupID of type Guid
					resultItem.FollowupID = reader.GetGuid(0);
					//1:Parameter isTreatmentPerformed of type bool
					resultItem.isTreatmentPerformed = reader.GetBoolean(1);
					//2:Parameter IsScheduled of type bool
					resultItem.IsScheduled = reader.GetBoolean(2);
					//3:Parameter isTreatmentBilled of type bool
					resultItem.isTreatmentBilled = reader.GetBoolean(3);
					//4:Parameter IfSheduled_Date of type DateTime
					resultItem.IfSheduled_Date = reader.GetDate(4);
					//5:Parameter IfTreatmentPerformed_Date of type DateTime
					resultItem.IfTreatmentPerformed_Date = reader.GetDate(5);
					//6:Parameter PerformedDoctorLANR of type String
					resultItem.PerformedDoctorLANR = reader.GetString(6);
					//7:Parameter PerformedDoctorFirstName of type String
					resultItem.PerformedDoctorFirstName = reader.GetString(7);
					//8:Parameter PerformedDoctorLastName of type String
					resultItem.PerformedDoctorLastName = reader.GetString(8);
					//9:Parameter ScheduledDoctorLANR of type String
					resultItem.ScheduledDoctorLANR = reader.GetString(9);
					//10:Parameter ScheduledDoctorFirstName of type String
					resultItem.ScheduledDoctorFirstName = reader.GetString(10);
					//11:Parameter ScheduledDoctorLastName of type String
					resultItem.ScheduledDoctorLastName = reader.GetString(11);
					//12:Parameter VorgangsNummer of type String
					resultItem.VorgangsNummer = reader.GetString(12);
					//13:Parameter PositionValue_IncludingTax of type String
					resultItem.PositionValue_IncludingTax = reader.GetString(13);
					//14:Parameter External_PositionType of type String
					resultItem.External_PositionType = reader.GetString(14);
					//15:Parameter BIL_BillPositionID of type Guid
					resultItem.BIL_BillPositionID = reader.GetGuid(15);
					//16:Parameter TransmitionCode of type int
					resultItem.TransmitionCode = reader.GetInteger(16);
					//17:Parameter PrimaryComment of type String
					resultItem.PrimaryComment = reader.GetString(17);
					//18:Parameter SecondaryComment of type String
					resultItem.SecondaryComment = reader.GetString(18);
					//19:Parameter PracticeName of type String
					resultItem.PracticeName = reader.GetString(19);
					//20:Parameter BSNR of type String
					resultItem.BSNR = reader.GetString(20);
					//21:Parameter TransmittedOnDate of type DateTime
					resultItem.TransmittedOnDate = reader.GetDate(21);
					//22:Parameter GPOS of type String
					resultItem.GPOS = reader.GetString(22);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_All_Aftercares_OLD_System",ex);
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
		public static FR_ED_GAAOS_1312_Array Invoke(string ConnectionString,P_ED_GAAOS_1312 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_ED_GAAOS_1312_Array Invoke(DbConnection Connection,P_ED_GAAOS_1312 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_ED_GAAOS_1312_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_ED_GAAOS_1312 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_ED_GAAOS_1312_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_ED_GAAOS_1312 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_ED_GAAOS_1312_Array functionReturn = new FR_ED_GAAOS_1312_Array();
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

				throw new Exception("Exception occured in method cls_Get_All_Aftercares_OLD_System",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_ED_GAAOS_1312_Array : FR_Base
	{
		public ED_GAAOS_1312[] Result	{ get; set; } 
		public FR_ED_GAAOS_1312_Array() : base() {}

		public FR_ED_GAAOS_1312_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_ED_GAAOS_1312 for attribute P_ED_GAAOS_1312
		[DataContract]
		public class P_ED_GAAOS_1312 
		{
			//Standard type parameters
			[DataMember]
			public Guid TreatmentID { get; set; } 

		}
		#endregion
		#region SClass ED_GAAOS_1312 for attribute ED_GAAOS_1312
		[DataContract]
		public class ED_GAAOS_1312 
		{
			//Standard type parameters
			[DataMember]
			public Guid FollowupID { get; set; } 
			[DataMember]
			public bool isTreatmentPerformed { get; set; } 
			[DataMember]
			public bool IsScheduled { get; set; } 
			[DataMember]
			public bool isTreatmentBilled { get; set; } 
			[DataMember]
			public DateTime IfSheduled_Date { get; set; } 
			[DataMember]
			public DateTime IfTreatmentPerformed_Date { get; set; } 
			[DataMember]
			public String PerformedDoctorLANR { get; set; } 
			[DataMember]
			public String PerformedDoctorFirstName { get; set; } 
			[DataMember]
			public String PerformedDoctorLastName { get; set; } 
			[DataMember]
			public String ScheduledDoctorLANR { get; set; } 
			[DataMember]
			public String ScheduledDoctorFirstName { get; set; } 
			[DataMember]
			public String ScheduledDoctorLastName { get; set; } 
			[DataMember]
			public String VorgangsNummer { get; set; } 
			[DataMember]
			public String PositionValue_IncludingTax { get; set; } 
			[DataMember]
			public String External_PositionType { get; set; } 
			[DataMember]
			public Guid BIL_BillPositionID { get; set; } 
			[DataMember]
			public int TransmitionCode { get; set; } 
			[DataMember]
			public String PrimaryComment { get; set; } 
			[DataMember]
			public String SecondaryComment { get; set; } 
			[DataMember]
			public String PracticeName { get; set; } 
			[DataMember]
			public String BSNR { get; set; } 
			[DataMember]
			public DateTime TransmittedOnDate { get; set; } 
			[DataMember]
			public String GPOS { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_ED_GAAOS_1312_Array cls_Get_All_Aftercares_OLD_System(,P_ED_GAAOS_1312 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_ED_GAAOS_1312_Array invocationResult = cls_Get_All_Aftercares_OLD_System.Invoke(connectionString,P_ED_GAAOS_1312 Parameter,securityTicket);
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
var parameter = new DataImporter.DBMethods.ExportData.Atomic.Retrieval.P_ED_GAAOS_1312();
parameter.TreatmentID = ...;

*/
