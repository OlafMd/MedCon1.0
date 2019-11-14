/* 
 * Generated on 2/2/2015 6:27:57 PM
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

namespace CL5_Lucentis_Import_and_BugFixes.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_All_BilledData_in_2015.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_All_BilledData_in_2015
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5IB_GABD_1840_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5IB_GABD_1840_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_Lucentis_Import_and_BugFixes.Atomic.Retrieval.SQL.cls_Get_All_BilledData_in_2015.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L5IB_GABD_1840> results = new List<L5IB_GABD_1840>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "VorgangsNummer","IsTreatmentFollowup","Patient_Birthday","Patient_First_Name","Patient_Last_Name","Performed_Date","Billed_Date","Treatment_ID","Performed_Doctor_ID_Number","External_PositionType","BIL_BillPositionID","TransmitionCode","TransmittedOnDate" });
				while(reader.Read())
				{
					L5IB_GABD_1840 resultItem = new L5IB_GABD_1840();
					//0:Parameter VorgangsNummer of type string
					resultItem.VorgangsNummer = reader.GetString(0);
					//1:Parameter IsTreatmentFollowup of type bool
					resultItem.IsTreatmentFollowup = reader.GetBoolean(1);
					//2:Parameter Patient_Birthday of type DateTime
					resultItem.Patient_Birthday = reader.GetDate(2);
					//3:Parameter Patient_First_Name of type string
					resultItem.Patient_First_Name = reader.GetString(3);
					//4:Parameter Patient_Last_Name of type string
					resultItem.Patient_Last_Name = reader.GetString(4);
					//5:Parameter Performed_Date of type DateTime
					resultItem.Performed_Date = reader.GetDate(5);
					//6:Parameter Billed_Date of type DateTime
					resultItem.Billed_Date = reader.GetDate(6);
					//7:Parameter Treatment_ID of type Guid
					resultItem.Treatment_ID = reader.GetGuid(7);
					//8:Parameter Performed_Doctor_ID_Number of type string
					resultItem.Performed_Doctor_ID_Number = reader.GetString(8);
					//9:Parameter External_PositionType of type string
					resultItem.External_PositionType = reader.GetString(9);
					//10:Parameter BIL_BillPositionID of type Guid
					resultItem.BIL_BillPositionID = reader.GetGuid(10);
					//11:Parameter TransmitionCode of type int
					resultItem.TransmitionCode = reader.GetInteger(11);
					//12:Parameter TransmittedOnDate of type DateTime
					resultItem.TransmittedOnDate = reader.GetDate(12);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_All_BilledData_in_2015",ex);
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
		public static FR_L5IB_GABD_1840_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5IB_GABD_1840_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5IB_GABD_1840_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5IB_GABD_1840_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5IB_GABD_1840_Array functionReturn = new FR_L5IB_GABD_1840_Array();
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

				throw new Exception("Exception occured in method cls_Get_All_BilledData_in_2015",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5IB_GABD_1840_Array : FR_Base
	{
		public L5IB_GABD_1840[] Result	{ get; set; } 
		public FR_L5IB_GABD_1840_Array() : base() {}

		public FR_L5IB_GABD_1840_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5IB_GABD_1840 for attribute L5IB_GABD_1840
		[DataContract]
		public class L5IB_GABD_1840 
		{
			//Standard type parameters
			[DataMember]
			public string VorgangsNummer { get; set; } 
			[DataMember]
			public bool IsTreatmentFollowup { get; set; } 
			[DataMember]
			public DateTime Patient_Birthday { get; set; } 
			[DataMember]
			public string Patient_First_Name { get; set; } 
			[DataMember]
			public string Patient_Last_Name { get; set; } 
			[DataMember]
			public DateTime Performed_Date { get; set; } 
			[DataMember]
			public DateTime Billed_Date { get; set; } 
			[DataMember]
			public Guid Treatment_ID { get; set; } 
			[DataMember]
			public string Performed_Doctor_ID_Number { get; set; } 
			[DataMember]
			public string External_PositionType { get; set; } 
			[DataMember]
			public Guid BIL_BillPositionID { get; set; } 
			[DataMember]
			public int TransmitionCode { get; set; } 
			[DataMember]
			public DateTime TransmittedOnDate { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5IB_GABD_1840_Array cls_Get_All_BilledData_in_2015(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5IB_GABD_1840_Array invocationResult = cls_Get_All_BilledData_in_2015.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

