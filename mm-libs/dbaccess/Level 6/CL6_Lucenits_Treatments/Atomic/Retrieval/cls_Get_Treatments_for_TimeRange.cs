/* 
 * Generated on 09.03.2014 20:06:11
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
    /// var result = cls_Get_Treatments_for_TimeRange.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Treatments_for_TimeRange
	{
		public static readonly int QueryTimeout = 6000;

		#region Method Execution
		protected static FR_L6TR_GT_fTR_1950_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L6TR_GT_fTR_1950 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L6TR_GT_fTR_1950_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL6_Lucenits_Treatments.Atomic.Retrieval.SQL.cls_Get_Treatments_for_TimeRange.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"fromDate", Parameter.fromDate);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"toDate", Parameter.toDate);



			List<L6TR_GT_fTR_1950> results = new List<L6TR_GT_fTR_1950>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "HEC_Patient_TreatmentID","TreatmentPractice_RefID","IsTreatmentPerformed","IfTreatmentPerformed_ByDoctor_RefID","IfTreatmentPerformed_Date","IsTreatmentFollowup","IfTreatmentFollowup_FromTreatment_RefID","IsScheduled","IfSheduled_Date","IsTreatmentBilled","IfTreatmentBilled_Date","Treatment_Comment","IfSheduled_ForDoctor_RefID" });
				while(reader.Read())
				{
					L6TR_GT_fTR_1950 resultItem = new L6TR_GT_fTR_1950();
					//0:Parameter HEC_Patient_TreatmentID of type Guid
					resultItem.HEC_Patient_TreatmentID = reader.GetGuid(0);
					//1:Parameter TreatmentPractice_RefID of type Guid
					resultItem.TreatmentPractice_RefID = reader.GetGuid(1);
					//2:Parameter IsTreatmentPerformed of type bool
					resultItem.IsTreatmentPerformed = reader.GetBoolean(2);
					//3:Parameter IfTreatmentPerformed_ByDoctor_RefID of type Guid
					resultItem.IfTreatmentPerformed_ByDoctor_RefID = reader.GetGuid(3);
					//4:Parameter IfTreatmentPerformed_Date of type DateTime
					resultItem.IfTreatmentPerformed_Date = reader.GetDate(4);
					//5:Parameter IsTreatmentFollowup of type bool
					resultItem.IsTreatmentFollowup = reader.GetBoolean(5);
					//6:Parameter IfTreatmentFollowup_FromTreatment_RefID of type Guid
					resultItem.IfTreatmentFollowup_FromTreatment_RefID = reader.GetGuid(6);
					//7:Parameter IsScheduled of type bool
					resultItem.IsScheduled = reader.GetBoolean(7);
					//8:Parameter IfSheduled_Date of type DateTime
					resultItem.IfSheduled_Date = reader.GetDate(8);
					//9:Parameter IsTreatmentBilled of type bool
					resultItem.IsTreatmentBilled = reader.GetBoolean(9);
					//10:Parameter IfTreatmentBilled_Date of type DateTime
					resultItem.IfTreatmentBilled_Date = reader.GetDate(10);
					//11:Parameter Treatment_Comment of type String
					resultItem.Treatment_Comment = reader.GetString(11);
					//12:Parameter IfSheduled_ForDoctor_RefID of type Guid
					resultItem.IfSheduled_ForDoctor_RefID = reader.GetGuid(12);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Treatments_for_TimeRange",ex);
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
		public static FR_L6TR_GT_fTR_1950_Array Invoke(string ConnectionString,P_L6TR_GT_fTR_1950 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6TR_GT_fTR_1950_Array Invoke(DbConnection Connection,P_L6TR_GT_fTR_1950 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6TR_GT_fTR_1950_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L6TR_GT_fTR_1950 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6TR_GT_fTR_1950_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6TR_GT_fTR_1950 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6TR_GT_fTR_1950_Array functionReturn = new FR_L6TR_GT_fTR_1950_Array();
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

				throw new Exception("Exception occured in method cls_Get_Treatments_for_TimeRange",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6TR_GT_fTR_1950_Array : FR_Base
	{
		public L6TR_GT_fTR_1950[] Result	{ get; set; } 
		public FR_L6TR_GT_fTR_1950_Array() : base() {}

		public FR_L6TR_GT_fTR_1950_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6TR_GT_fTR_1950 for attribute P_L6TR_GT_fTR_1950
		[DataContract]
		public class P_L6TR_GT_fTR_1950 
		{
			//Standard type parameters
			[DataMember]
			public DateTime fromDate { get; set; } 
			[DataMember]
			public DateTime toDate { get; set; } 

		}
		#endregion
		#region SClass L6TR_GT_fTR_1950 for attribute L6TR_GT_fTR_1950
		[DataContract]
		public class L6TR_GT_fTR_1950 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_Patient_TreatmentID { get; set; } 
			[DataMember]
			public Guid TreatmentPractice_RefID { get; set; } 
			[DataMember]
			public bool IsTreatmentPerformed { get; set; } 
			[DataMember]
			public Guid IfTreatmentPerformed_ByDoctor_RefID { get; set; } 
			[DataMember]
			public DateTime IfTreatmentPerformed_Date { get; set; } 
			[DataMember]
			public bool IsTreatmentFollowup { get; set; } 
			[DataMember]
			public Guid IfTreatmentFollowup_FromTreatment_RefID { get; set; } 
			[DataMember]
			public bool IsScheduled { get; set; } 
			[DataMember]
			public DateTime IfSheduled_Date { get; set; } 
			[DataMember]
			public bool IsTreatmentBilled { get; set; } 
			[DataMember]
			public DateTime IfTreatmentBilled_Date { get; set; } 
			[DataMember]
			public String Treatment_Comment { get; set; } 
			[DataMember]
			public Guid IfSheduled_ForDoctor_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6TR_GT_fTR_1950_Array cls_Get_Treatments_for_TimeRange(,P_L6TR_GT_fTR_1950 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6TR_GT_fTR_1950_Array invocationResult = cls_Get_Treatments_for_TimeRange.Invoke(connectionString,P_L6TR_GT_fTR_1950 Parameter,securityTicket);
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
var parameter = new CL6_Lucenits_Treatments.Atomic.Retrieval.P_L6TR_GT_fTR_1950();
parameter.fromDate = ...;
parameter.toDate = ...;

*/
