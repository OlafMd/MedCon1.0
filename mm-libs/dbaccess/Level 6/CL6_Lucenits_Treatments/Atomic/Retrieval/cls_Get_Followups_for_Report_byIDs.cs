/* 
 * Generated on 9/19/2013 11:24:35 AM
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
    /// var result = cls_Get_Followups_for_Report_byIDs.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Followups_for_Report_byIDs
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6TR_GFTfRbIDs_1646_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L6TR_GFTfRbIDs_1646 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L6TR_GFTfRbIDs_1646_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL6_Lucenits_Treatments.Atomic.Retrieval.SQL.cls_Get_Followups_for_Report_byIDs.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@TreatmentIDs"," IN $$TreatmentIDs$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$TreatmentIDs$",Parameter.TreatmentIDs);


			List<L6TR_GFTfRbIDs_1646> results = new List<L6TR_GFTfRbIDs_1646>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "IfTreatmentFollowup_FromTreatment_RefID","HEC_Patient_TreatmentID","IsTreatmentPerformed","IfTreatmentPerformed_Date","IfTreatmentPerformed_ByDoctor_RefID","DisplayName","DoctorFirstName","DoctorLastname","DoctorTitle","IsScheduled","IsTreatmentBilled","IfSheduled_Date","IfTreatmentBilled_Date" });
				while(reader.Read())
				{
					L6TR_GFTfRbIDs_1646 resultItem = new L6TR_GFTfRbIDs_1646();
					//0:Parameter IfTreatmentFollowup_FromTreatment_RefID of type Guid
					resultItem.IfTreatmentFollowup_FromTreatment_RefID = reader.GetGuid(0);
					//1:Parameter HEC_Patient_TreatmentID of type Guid
					resultItem.HEC_Patient_TreatmentID = reader.GetGuid(1);
					//2:Parameter IsTreatmentPerformed of type bool
					resultItem.IsTreatmentPerformed = reader.GetBoolean(2);
					//3:Parameter IfTreatmentPerformed_Date of type DateTime
					resultItem.IfTreatmentPerformed_Date = reader.GetDate(3);
					//4:Parameter IfTreatmentPerformed_ByDoctor_RefID of type Guid
					resultItem.IfTreatmentPerformed_ByDoctor_RefID = reader.GetGuid(4);
					//5:Parameter DisplayName of type String
					resultItem.DisplayName = reader.GetString(5);
					//6:Parameter DoctorFirstName of type String
					resultItem.DoctorFirstName = reader.GetString(6);
					//7:Parameter DoctorLastname of type String
					resultItem.DoctorLastname = reader.GetString(7);
					//8:Parameter DoctorTitle of type String
					resultItem.DoctorTitle = reader.GetString(8);
					//9:Parameter IsScheduled of type bool
					resultItem.IsScheduled = reader.GetBoolean(9);
					//10:Parameter IsTreatmentBilled of type bool
					resultItem.IsTreatmentBilled = reader.GetBoolean(10);
					//11:Parameter IfSheduled_Date of type DateTime
					resultItem.IfSheduled_Date = reader.GetDate(11);
					//12:Parameter IfTreatmentBilled_Date of type DateTime
					resultItem.IfTreatmentBilled_Date = reader.GetDate(12);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Followups_for_Report_byIDs",ex);
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
		public static FR_L6TR_GFTfRbIDs_1646_Array Invoke(string ConnectionString,P_L6TR_GFTfRbIDs_1646 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6TR_GFTfRbIDs_1646_Array Invoke(DbConnection Connection,P_L6TR_GFTfRbIDs_1646 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6TR_GFTfRbIDs_1646_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L6TR_GFTfRbIDs_1646 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6TR_GFTfRbIDs_1646_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6TR_GFTfRbIDs_1646 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6TR_GFTfRbIDs_1646_Array functionReturn = new FR_L6TR_GFTfRbIDs_1646_Array();
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

				throw new Exception("Exception occured in method cls_Get_Followups_for_Report_byIDs",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6TR_GFTfRbIDs_1646_Array : FR_Base
	{
		public L6TR_GFTfRbIDs_1646[] Result	{ get; set; } 
		public FR_L6TR_GFTfRbIDs_1646_Array() : base() {}

		public FR_L6TR_GFTfRbIDs_1646_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6TR_GFTfRbIDs_1646 for attribute P_L6TR_GFTfRbIDs_1646
		[DataContract]
		public class P_L6TR_GFTfRbIDs_1646 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] TreatmentIDs { get; set; } 

		}
		#endregion
		#region SClass L6TR_GFTfRbIDs_1646 for attribute L6TR_GFTfRbIDs_1646
		[DataContract]
		public class L6TR_GFTfRbIDs_1646 
		{
			//Standard type parameters
			[DataMember]
			public Guid IfTreatmentFollowup_FromTreatment_RefID { get; set; } 
			[DataMember]
			public Guid HEC_Patient_TreatmentID { get; set; } 
			[DataMember]
			public bool IsTreatmentPerformed { get; set; } 
			[DataMember]
			public DateTime IfTreatmentPerformed_Date { get; set; } 
			[DataMember]
			public Guid IfTreatmentPerformed_ByDoctor_RefID { get; set; } 
			[DataMember]
			public String DisplayName { get; set; } 
			[DataMember]
			public String DoctorFirstName { get; set; } 
			[DataMember]
			public String DoctorLastname { get; set; } 
			[DataMember]
			public String DoctorTitle { get; set; } 
			[DataMember]
			public bool IsScheduled { get; set; } 
			[DataMember]
			public bool IsTreatmentBilled { get; set; } 
			[DataMember]
			public DateTime IfSheduled_Date { get; set; } 
			[DataMember]
			public DateTime IfTreatmentBilled_Date { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6TR_GFTfRbIDs_1646_Array cls_Get_Followups_for_Report_byIDs(,P_L6TR_GFTfRbIDs_1646 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6TR_GFTfRbIDs_1646_Array invocationResult = cls_Get_Followups_for_Report_byIDs.Invoke(connectionString,P_L6TR_GFTfRbIDs_1646 Parameter,securityTicket);
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
var parameter = new CL6_Lucenits_Treatments.Atomic.Retrieval.P_L6TR_GFTfRbIDs_1646();
parameter.TreatmentIDs = ...;

*/
