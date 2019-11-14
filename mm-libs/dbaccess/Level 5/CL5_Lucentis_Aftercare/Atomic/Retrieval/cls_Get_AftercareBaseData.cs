/* 
 * Generated on 12/3/2014 8:41:44 PM
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

namespace CL5_Lucentis_Aftercare.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_AftercareBaseData.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_AftercareBaseData
	{
		public static readonly int QueryTimeout = 6000;

		#region Method Execution
		protected static FR_L5AF_GABD_1107_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5AF_GABD_1107 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5AF_GABD_1107_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_Lucentis_Aftercare.Atomic.Retrieval.SQL.cls_Get_AftercareBaseData.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"OrderBy", Parameter.OrderBy);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"S_Practice", Parameter.S_Practice);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"OrderValue", Parameter.OrderValue);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"StartIndex", Parameter.StartIndex);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"NumberOfElements", Parameter.NumberOfElements);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"statusParameters", Parameter.statusParameters);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"s_doctorParam", Parameter.s_doctorParam);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"s_scheduled_doctorParam", Parameter.s_scheduled_doctorParam);

            /***For Order**/
            if (Parameter.OrderValue != "")
            {
                string newText = command.CommandText.Replace("@OrderValue", Parameter.OrderValue);
                command.CommandText = newText;
            }

            /***Search parameters**/
            if (Parameter.S_Practice != "")
            {
                string newText = command.CommandText.Replace("@S_Practice", Parameter.S_Practice);
                command.CommandText = newText;
            }

            if (Parameter.s_doctorParam != "")
            {
                string newText = command.CommandText.Replace("@s_doctorParam", Parameter.s_doctorParam);
                command.CommandText = newText;
            }

            if (Parameter.s_scheduled_doctorParam != "")
            {
                string newText = command.CommandText.Replace("@s_scheduled_doctorParam", Parameter.s_scheduled_doctorParam);
                command.CommandText = newText;
            }


            /***status parameters**/
            if (Parameter.statusParameters != "")
            {
                string newText = command.CommandText.Replace("@statusParameters", Parameter.statusParameters);
                command.CommandText = newText;
            }

			List<L5AF_GABD_1107> results = new List<L5AF_GABD_1107>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "FollowupID","TreatmentID","Practice","IsScheduled","IsTreatmentBilled","IsTreatmentPerformed","IfSheduled_Date","IfTreatmentBilled_Date","IfTreatmentPerformed_Date","PerformedDoctorTitle","PerformedDoctorFirstName","PerformedDoctorLastName","SheduledDoctorTitle","SheduledDoctorFirstName","SheduledDoctorLastName" });
				while(reader.Read())
				{
					L5AF_GABD_1107 resultItem = new L5AF_GABD_1107();
					//0:Parameter FollowupID of type Guid
					resultItem.FollowupID = reader.GetGuid(0);
					//1:Parameter TreatmentID of type Guid
					resultItem.TreatmentID = reader.GetGuid(1);
					//2:Parameter Practice of type String
					resultItem.Practice = reader.GetString(2);
					//3:Parameter IsScheduled of type bool
					resultItem.IsScheduled = reader.GetBoolean(3);
					//4:Parameter IsTreatmentBilled of type bool
					resultItem.IsTreatmentBilled = reader.GetBoolean(4);
					//5:Parameter IsTreatmentPerformed of type bool
					resultItem.IsTreatmentPerformed = reader.GetBoolean(5);
					//6:Parameter IfSheduled_Date of type DateTime
					resultItem.IfSheduled_Date = reader.GetDate(6);
					//7:Parameter IfTreatmentBilled_Date of type DateTime
					resultItem.IfTreatmentBilled_Date = reader.GetDate(7);
					//8:Parameter IfTreatmentPerformed_Date of type DateTime
					resultItem.IfTreatmentPerformed_Date = reader.GetDate(8);
					//9:Parameter PerformedDoctorTitle of type String
					resultItem.PerformedDoctorTitle = reader.GetString(9);
					//10:Parameter PerformedDoctorFirstName of type String
					resultItem.PerformedDoctorFirstName = reader.GetString(10);
					//11:Parameter PerformedDoctorLastName of type String
					resultItem.PerformedDoctorLastName = reader.GetString(11);
					//12:Parameter SheduledDoctorTitle of type String
					resultItem.SheduledDoctorTitle = reader.GetString(12);
					//13:Parameter SheduledDoctorFirstName of type String
					resultItem.SheduledDoctorFirstName = reader.GetString(13);
					//14:Parameter SheduledDoctorLastName of type String
					resultItem.SheduledDoctorLastName = reader.GetString(14);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_AftercareBaseData",ex);
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
		public static FR_L5AF_GABD_1107_Array Invoke(string ConnectionString,P_L5AF_GABD_1107 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5AF_GABD_1107_Array Invoke(DbConnection Connection,P_L5AF_GABD_1107 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5AF_GABD_1107_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AF_GABD_1107 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5AF_GABD_1107_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AF_GABD_1107 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5AF_GABD_1107_Array functionReturn = new FR_L5AF_GABD_1107_Array();
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

				throw new Exception("Exception occured in method cls_Get_AftercareBaseData",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5AF_GABD_1107_Array : FR_Base
	{
		public L5AF_GABD_1107[] Result	{ get; set; } 
		public FR_L5AF_GABD_1107_Array() : base() {}

		public FR_L5AF_GABD_1107_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5AF_GABD_1107 for attribute P_L5AF_GABD_1107
		[DataContract]
		public class P_L5AF_GABD_1107 
		{
			//Standard type parameters
			[DataMember]
			public String OrderBy { get; set; } 
			[DataMember]
			public String S_Practice { get; set; } 
			[DataMember]
			public String OrderValue { get; set; } 
			[DataMember]
			public int StartIndex { get; set; } 
			[DataMember]
			public int NumberOfElements { get; set; } 
			[DataMember]
			public String statusParameters { get; set; } 
			[DataMember]
			public String s_doctorParam { get; set; } 
			[DataMember]
			public String s_scheduled_doctorParam { get; set; } 

		}
		#endregion
		#region SClass L5AF_GABD_1107 for attribute L5AF_GABD_1107
		[DataContract]
		public class L5AF_GABD_1107 
		{
			//Standard type parameters
			[DataMember]
			public Guid FollowupID { get; set; } 
			[DataMember]
			public Guid TreatmentID { get; set; } 
			[DataMember]
			public String Practice { get; set; } 
			[DataMember]
			public bool IsScheduled { get; set; } 
			[DataMember]
			public bool IsTreatmentBilled { get; set; } 
			[DataMember]
			public bool IsTreatmentPerformed { get; set; } 
			[DataMember]
			public DateTime IfSheduled_Date { get; set; } 
			[DataMember]
			public DateTime IfTreatmentBilled_Date { get; set; } 
			[DataMember]
			public DateTime IfTreatmentPerformed_Date { get; set; } 
			[DataMember]
			public String PerformedDoctorTitle { get; set; } 
			[DataMember]
			public String PerformedDoctorFirstName { get; set; } 
			[DataMember]
			public String PerformedDoctorLastName { get; set; } 
			[DataMember]
			public String SheduledDoctorTitle { get; set; } 
			[DataMember]
			public String SheduledDoctorFirstName { get; set; } 
			[DataMember]
			public String SheduledDoctorLastName { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5AF_GABD_1107_Array cls_Get_AftercareBaseData(,P_L5AF_GABD_1107 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5AF_GABD_1107_Array invocationResult = cls_Get_AftercareBaseData.Invoke(connectionString,P_L5AF_GABD_1107 Parameter,securityTicket);
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
var parameter = new CL5_Lucentis_Aftercare.Atomic.Retrieval.P_L5AF_GABD_1107();
parameter.OrderBy = ...;
parameter.S_Practice = ...;
parameter.OrderValue = ...;
parameter.StartIndex = ...;
parameter.NumberOfElements = ...;
parameter.statusParameters = ...;
parameter.s_doctorParam = ...;
parameter.s_scheduled_doctorParam = ...;

*/
