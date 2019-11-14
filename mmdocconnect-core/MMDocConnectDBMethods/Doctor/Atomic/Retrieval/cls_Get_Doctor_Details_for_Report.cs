/* 
 * Generated on 12/20/16 17:08:34
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

namespace MMDocConnectDBMethods.Doctor.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Doctor_Details_for_Report.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Doctor_Details_for_Report
	{
        public static readonly int QueryTimeout = 6000;

		#region Method Execution
		protected static FR_DO_GDDfR_2028_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_DO_GDDfR_2028_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.Doctor.Atomic.Retrieval.SQL.cls_Get_Doctor_Details_for_Report.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<DO_GDDfR_2028> results = new List<DO_GDDfR_2028>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "DoctorID","DoctorBptID","PracticeBPTID","FirstName","LastName","DoctorLANR","AccountHolder","IBAN","PracticeName","PracticeBSNR","BIC","BankName","Title","Salutation_General","SignInEmail" });
				while(reader.Read())
				{
					DO_GDDfR_2028 resultItem = new DO_GDDfR_2028();
					//0:Parameter DoctorID of type Guid
					resultItem.DoctorID = reader.GetGuid(0);
					//1:Parameter DoctorBptID of type Guid
					resultItem.DoctorBptID = reader.GetGuid(1);
					//2:Parameter PracticeBPTID of type Guid
					resultItem.PracticeBPTID = reader.GetGuid(2);
					//3:Parameter FirstName of type String
					resultItem.FirstName = reader.GetString(3);
					//4:Parameter LastName of type String
					resultItem.LastName = reader.GetString(4);
					//5:Parameter DoctorLANR of type String
					resultItem.DoctorLANR = reader.GetString(5);
					//6:Parameter AccountHolder of type String
					resultItem.AccountHolder = reader.GetString(6);
					//7:Parameter IBAN of type String
					resultItem.IBAN = reader.GetString(7);
					//8:Parameter PracticeName of type String
					resultItem.PracticeName = reader.GetString(8);
					//9:Parameter PracticeBSNR of type String
					resultItem.PracticeBSNR = reader.GetString(9);
					//10:Parameter BIC of type String
					resultItem.BIC = reader.GetString(10);
					//11:Parameter BankName of type String
					resultItem.BankName = reader.GetString(11);
					//12:Parameter Title of type String
					resultItem.Title = reader.GetString(12);
					//13:Parameter Salutation_General of type String
					resultItem.Salutation_General = reader.GetString(13);
					//14:Parameter SignInEmail of type String
					resultItem.SignInEmail = reader.GetString(14);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Doctor_Details_for_Report",ex);
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
		public static FR_DO_GDDfR_2028_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_DO_GDDfR_2028_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_DO_GDDfR_2028_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_DO_GDDfR_2028_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_DO_GDDfR_2028_Array functionReturn = new FR_DO_GDDfR_2028_Array();
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

				throw new Exception("Exception occured in method cls_Get_Doctor_Details_for_Report",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_DO_GDDfR_2028_Array : FR_Base
	{
		public DO_GDDfR_2028[] Result	{ get; set; } 
		public FR_DO_GDDfR_2028_Array() : base() {}

		public FR_DO_GDDfR_2028_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass DO_GDDfR_2028 for attribute DO_GDDfR_2028
		[DataContract]
		public class DO_GDDfR_2028 
		{
			//Standard type parameters
			[DataMember]
			public Guid DoctorID { get; set; } 
			[DataMember]
			public Guid DoctorBptID { get; set; } 
			[DataMember]
			public Guid PracticeBPTID { get; set; } 
			[DataMember]
			public String FirstName { get; set; } 
			[DataMember]
			public String LastName { get; set; } 
			[DataMember]
			public String DoctorLANR { get; set; } 
			[DataMember]
			public String AccountHolder { get; set; } 
			[DataMember]
			public String IBAN { get; set; } 
			[DataMember]
			public String PracticeName { get; set; } 
			[DataMember]
			public String PracticeBSNR { get; set; } 
			[DataMember]
			public String BIC { get; set; } 
			[DataMember]
			public String BankName { get; set; } 
			[DataMember]
			public String Title { get; set; } 
			[DataMember]
			public String Salutation_General { get; set; } 
			[DataMember]
			public String SignInEmail { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_DO_GDDfR_2028_Array cls_Get_Doctor_Details_for_Report(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_DO_GDDfR_2028_Array invocationResult = cls_Get_Doctor_Details_for_Report.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

