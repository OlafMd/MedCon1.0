/* 
 * Generated on 3/4/2014 3:27:05 PM
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

namespace CL5_Lucentis_Doctors.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_DoctorData_for_LANR_for_Reports.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_DoctorData_for_LANR_for_Reports
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5DO_GDDfLfR_1409_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5DO_GDDfLfR_1409 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5DO_GDDfLfR_1409_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_Lucentis_Doctors.Atomic.Retrieval.SQL.cls_Get_DoctorData_for_LANR_for_Reports.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@LANR"," IN $$LANR$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$LANR$",Parameter.LANR);


			List<L5DO_GDDfLfR_1409> results = new List<L5DO_GDDfLfR_1409>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "HEC_DoctorID","LANR","FirstName","LastName","Account_RefID","PrimaryEmail","BankName","BICCode","BankNumber","AccountNumber","IBAN","OwnerText" });
				while(reader.Read())
				{
					L5DO_GDDfLfR_1409 resultItem = new L5DO_GDDfLfR_1409();
					//0:Parameter HEC_DoctorID of type Guid
					resultItem.HEC_DoctorID = reader.GetGuid(0);
					//1:Parameter LANR of type String
					resultItem.LANR = reader.GetString(1);
					//2:Parameter FirstName of type String
					resultItem.FirstName = reader.GetString(2);
					//3:Parameter LastName of type String
					resultItem.LastName = reader.GetString(3);
					//4:Parameter Account_RefID of type Guid
					resultItem.Account_RefID = reader.GetGuid(4);
					//5:Parameter PrimaryEmail of type String
					resultItem.PrimaryEmail = reader.GetString(5);
					//6:Parameter BankName of type String
					resultItem.BankName = reader.GetString(6);
					//7:Parameter BICCode of type String
					resultItem.BICCode = reader.GetString(7);
					//8:Parameter BankNumber of type String
					resultItem.BankNumber = reader.GetString(8);
					//9:Parameter AccountNumber of type String
					resultItem.AccountNumber = reader.GetString(9);
					//10:Parameter IBAN of type String
					resultItem.IBAN = reader.GetString(10);
					//11:Parameter OwnerText of type String
					resultItem.OwnerText = reader.GetString(11);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_DoctorData_for_LANR_for_Reports",ex);
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
		public static FR_L5DO_GDDfLfR_1409_Array Invoke(string ConnectionString,P_L5DO_GDDfLfR_1409 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5DO_GDDfLfR_1409_Array Invoke(DbConnection Connection,P_L5DO_GDDfLfR_1409 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5DO_GDDfLfR_1409_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5DO_GDDfLfR_1409 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5DO_GDDfLfR_1409_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5DO_GDDfLfR_1409 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5DO_GDDfLfR_1409_Array functionReturn = new FR_L5DO_GDDfLfR_1409_Array();
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

				throw new Exception("Exception occured in method cls_Get_DoctorData_for_LANR_for_Reports",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5DO_GDDfLfR_1409_Array : FR_Base
	{
		public L5DO_GDDfLfR_1409[] Result	{ get; set; } 
		public FR_L5DO_GDDfLfR_1409_Array() : base() {}

		public FR_L5DO_GDDfLfR_1409_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5DO_GDDfLfR_1409 for attribute P_L5DO_GDDfLfR_1409
		[DataContract]
		public class P_L5DO_GDDfLfR_1409 
		{
			//Standard type parameters
			[DataMember]
			public String[] LANR { get; set; } 

		}
		#endregion
		#region SClass L5DO_GDDfLfR_1409 for attribute L5DO_GDDfLfR_1409
		[DataContract]
		public class L5DO_GDDfLfR_1409 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_DoctorID { get; set; } 
			[DataMember]
			public String LANR { get; set; } 
			[DataMember]
			public String FirstName { get; set; } 
			[DataMember]
			public String LastName { get; set; } 
			[DataMember]
			public Guid Account_RefID { get; set; } 
			[DataMember]
			public String PrimaryEmail { get; set; } 
			[DataMember]
			public String BankName { get; set; } 
			[DataMember]
			public String BICCode { get; set; } 
			[DataMember]
			public String BankNumber { get; set; } 
			[DataMember]
			public String AccountNumber { get; set; } 
			[DataMember]
			public String IBAN { get; set; } 
			[DataMember]
			public String OwnerText { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5DO_GDDfLfR_1409_Array cls_Get_DoctorData_for_LANR_for_Reports(,P_L5DO_GDDfLfR_1409 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5DO_GDDfLfR_1409_Array invocationResult = cls_Get_DoctorData_for_LANR_for_Reports.Invoke(connectionString,P_L5DO_GDDfLfR_1409 Parameter,securityTicket);
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
var parameter = new CL5_Lucentis_Doctors.Atomic.Retrieval.P_L5DO_GDDfLfR_1409();
parameter.LANR = ...;

*/
