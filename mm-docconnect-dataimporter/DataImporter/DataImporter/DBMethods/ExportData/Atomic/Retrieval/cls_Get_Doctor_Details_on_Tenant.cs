/* 
 * Generated on 1/20/2017 2:34:29 PM
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
    /// var result = cls_Get_Doctor_Details_on_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Doctor_Details_on_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_DO_GDDoT_1735_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_DO_GDDoT_1735_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "DataImporter.DBMethods.ExportData.Atomic.Retrieval.SQL.cls_Get_Doctor_Details_on_Tenant.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<DO_GDDoT_1735> results = new List<DO_GDDoT_1735>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "DoctorID","DoctorBptId","PracticeBPTID","FirstName","LastName","DoctorLANR","PracticeName","Title","Salutation_General","PracticeId" });
				while(reader.Read())
				{
					DO_GDDoT_1735 resultItem = new DO_GDDoT_1735();
					//0:Parameter DoctorID of type Guid
					resultItem.DoctorID = reader.GetGuid(0);
					//1:Parameter DoctorBptId of type Guid
					resultItem.DoctorBptId = reader.GetGuid(1);
					//2:Parameter PracticeBPTID of type Guid
					resultItem.PracticeBPTID = reader.GetGuid(2);
					//3:Parameter FirstName of type String
					resultItem.FirstName = reader.GetString(3);
					//4:Parameter LastName of type String
					resultItem.LastName = reader.GetString(4);
					//5:Parameter DoctorLANR of type String
					resultItem.DoctorLANR = reader.GetString(5);
					//6:Parameter PracticeName of type String
					resultItem.PracticeName = reader.GetString(6);
					//7:Parameter Title of type String
					resultItem.Title = reader.GetString(7);
					//8:Parameter Salutation_General of type String
					resultItem.Salutation_General = reader.GetString(8);
					//9:Parameter PracticeId of type Guid
					resultItem.PracticeId = reader.GetGuid(9);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Doctor_Details_on_Tenant",ex);
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
		public static FR_DO_GDDoT_1735_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_DO_GDDoT_1735_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_DO_GDDoT_1735_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_DO_GDDoT_1735_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_DO_GDDoT_1735_Array functionReturn = new FR_DO_GDDoT_1735_Array();
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

				throw new Exception("Exception occured in method cls_Get_Doctor_Details_on_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_DO_GDDoT_1735_Array : FR_Base
	{
		public DO_GDDoT_1735[] Result	{ get; set; } 
		public FR_DO_GDDoT_1735_Array() : base() {}

		public FR_DO_GDDoT_1735_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass DO_GDDoT_1735 for attribute DO_GDDoT_1735
		[DataContract]
		public class DO_GDDoT_1735 
		{
			//Standard type parameters
			[DataMember]
			public Guid DoctorID { get; set; } 
			[DataMember]
			public Guid DoctorBptId { get; set; } 
			[DataMember]
			public Guid PracticeBPTID { get; set; } 
			[DataMember]
			public String FirstName { get; set; } 
			[DataMember]
			public String LastName { get; set; } 
			[DataMember]
			public String DoctorLANR { get; set; } 
			[DataMember]
			public String PracticeName { get; set; } 
			[DataMember]
			public String Title { get; set; } 
			[DataMember]
			public String Salutation_General { get; set; } 
			[DataMember]
			public Guid PracticeId { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_DO_GDDoT_1735_Array cls_Get_Doctor_Details_on_Tenant(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_DO_GDDoT_1735_Array invocationResult = cls_Get_Doctor_Details_on_Tenant.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/
