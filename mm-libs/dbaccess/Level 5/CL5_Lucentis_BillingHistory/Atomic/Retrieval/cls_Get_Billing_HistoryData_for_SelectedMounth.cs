/* 
 * Generated on 1/14/2014 11:03:23 AM
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

namespace CL5_Lucentis_BillingHistory.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Billing_HistoryData_for_SelectedMounth.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Billing_HistoryData_for_SelectedMounth
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5BH_GBHDfSM_1323_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5BH_GBHDfSM_1323 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5BH_GBHDfSM_1323_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_Lucentis_BillingHistory.Atomic.Retrieval.SQL.cls_Get_Billing_HistoryData_for_SelectedMounth.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"SelectedMounth", Parameter.SelectedMounth);



			List<L5BH_GBHDfSM_1323> results = new List<L5BH_GBHDfSM_1323>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "PositionNumber","BillID","TreatmentDate","HealthInsurance_Number","InsuranceStateCode","FirstName","LastName","BSNR","LANR","GPOS","Creation_Timestamp","PositionValue_IncludingTax","PositionValue_BeforeTax","BIL_BillHeaderID","BIL_BillPositionID","TreatmentID","BirthDate","PatientID" });
				while(reader.Read())
				{
					L5BH_GBHDfSM_1323 resultItem = new L5BH_GBHDfSM_1323();
					//0:Parameter PositionNumber of type String
					resultItem.PositionNumber = reader.GetString(0);
					//1:Parameter BillID of type int
					resultItem.BillID = reader.GetInteger(1);
					//2:Parameter TreatmentDate of type DateTime
					resultItem.TreatmentDate = reader.GetDate(2);
					//3:Parameter HealthInsurance_Number of type String
					resultItem.HealthInsurance_Number = reader.GetString(3);
					//4:Parameter InsuranceStateCode of type String
					resultItem.InsuranceStateCode = reader.GetString(4);
					//5:Parameter FirstName of type String
					resultItem.FirstName = reader.GetString(5);
					//6:Parameter LastName of type String
					resultItem.LastName = reader.GetString(6);
					//7:Parameter BSNR of type String
					resultItem.BSNR = reader.GetString(7);
					//8:Parameter LANR of type String
					resultItem.LANR = reader.GetString(8);
					//9:Parameter GPOS of type String
					resultItem.GPOS = reader.GetString(9);
					//10:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(10);
					//11:Parameter PositionValue_IncludingTax of type String
					resultItem.PositionValue_IncludingTax = reader.GetString(11);
					//12:Parameter PositionValue_BeforeTax of type String
					resultItem.PositionValue_BeforeTax = reader.GetString(12);
					//13:Parameter BIL_BillHeaderID of type Guid
					resultItem.BIL_BillHeaderID = reader.GetGuid(13);
					//14:Parameter BIL_BillPositionID of type Guid
					resultItem.BIL_BillPositionID = reader.GetGuid(14);
					//15:Parameter TreatmentID of type Guid
					resultItem.TreatmentID = reader.GetGuid(15);
					//16:Parameter BirthDate of type DateTime
					resultItem.BirthDate = reader.GetDate(16);
					//17:Parameter PatientID of type Guid
					resultItem.PatientID = reader.GetGuid(17);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Billing_HistoryData_for_SelectedMounth",ex);
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
		public static FR_L5BH_GBHDfSM_1323_Array Invoke(string ConnectionString,P_L5BH_GBHDfSM_1323 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5BH_GBHDfSM_1323_Array Invoke(DbConnection Connection,P_L5BH_GBHDfSM_1323 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5BH_GBHDfSM_1323_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5BH_GBHDfSM_1323 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5BH_GBHDfSM_1323_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5BH_GBHDfSM_1323 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5BH_GBHDfSM_1323_Array functionReturn = new FR_L5BH_GBHDfSM_1323_Array();
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

				throw new Exception("Exception occured in method cls_Get_Billing_HistoryData_for_SelectedMounth",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5BH_GBHDfSM_1323_Array : FR_Base
	{
		public L5BH_GBHDfSM_1323[] Result	{ get; set; } 
		public FR_L5BH_GBHDfSM_1323_Array() : base() {}

		public FR_L5BH_GBHDfSM_1323_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5BH_GBHDfSM_1323 for attribute P_L5BH_GBHDfSM_1323
		[DataContract]
		public class P_L5BH_GBHDfSM_1323 
		{
			//Standard type parameters
			[DataMember]
			public int SelectedMounth { get; set; } 

		}
		#endregion
		#region SClass L5BH_GBHDfSM_1323 for attribute L5BH_GBHDfSM_1323
		[DataContract]
		public class L5BH_GBHDfSM_1323 
		{
			//Standard type parameters
			[DataMember]
			public String PositionNumber { get; set; } 
			[DataMember]
			public int BillID { get; set; } 
			[DataMember]
			public DateTime TreatmentDate { get; set; } 
			[DataMember]
			public String HealthInsurance_Number { get; set; } 
			[DataMember]
			public String InsuranceStateCode { get; set; } 
			[DataMember]
			public String FirstName { get; set; } 
			[DataMember]
			public String LastName { get; set; } 
			[DataMember]
			public String BSNR { get; set; } 
			[DataMember]
			public String LANR { get; set; } 
			[DataMember]
			public String GPOS { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public String PositionValue_IncludingTax { get; set; } 
			[DataMember]
			public String PositionValue_BeforeTax { get; set; } 
			[DataMember]
			public Guid BIL_BillHeaderID { get; set; } 
			[DataMember]
			public Guid BIL_BillPositionID { get; set; } 
			[DataMember]
			public Guid TreatmentID { get; set; } 
			[DataMember]
			public DateTime BirthDate { get; set; } 
			[DataMember]
			public Guid PatientID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5BH_GBHDfSM_1323_Array cls_Get_Billing_HistoryData_for_SelectedMounth(,P_L5BH_GBHDfSM_1323 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5BH_GBHDfSM_1323_Array invocationResult = cls_Get_Billing_HistoryData_for_SelectedMounth.Invoke(connectionString,P_L5BH_GBHDfSM_1323 Parameter,securityTicket);
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
var parameter = new CL5_Lucentis_BillingHistory.Atomic.Retrieval.P_L5BH_GBHDfSM_1323();
parameter.SelectedMounth = ...;

*/
