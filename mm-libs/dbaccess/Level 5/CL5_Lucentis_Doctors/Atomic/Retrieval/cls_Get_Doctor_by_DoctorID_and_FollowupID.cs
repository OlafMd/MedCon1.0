/* 
 * Generated on 11/23/2013 5:29:10 PM
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
    /// var result = cls_Get_Doctor_by_DoctorID_and_FollowupID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Doctor_by_DoctorID_and_FollowupID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5_DO_GDbDIDaFID_1513_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5_DO_GDbDIDaFID_1513 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5_DO_GDbDIDaFID_1513_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_Lucentis_Doctors.Atomic.Retrieval.SQL.cls_Get_Doctor_by_DoctorID_and_FollowupID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"DoctorsID", Parameter.DoctorsID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"TreatmentID", Parameter.TreatmentID);



			List<L5_DO_GDbDIDaFID_1513> results = new List<L5_DO_GDbDIDaFID_1513>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "LANR","DoctorFirstName","DoctorLastName","AccountHolder","AccountNumber","BankName","BLZ","Tenant_RefID","HEC_DoctorID","HEC_Patient_TreatmentID","PracticeName" });
				while(reader.Read())
				{
					L5_DO_GDbDIDaFID_1513 resultItem = new L5_DO_GDbDIDaFID_1513();
					//0:Parameter LANR of type String
					resultItem.LANR = reader.GetString(0);
					//1:Parameter DoctorFirstName of type String
					resultItem.DoctorFirstName = reader.GetString(1);
					//2:Parameter DoctorLastName of type String
					resultItem.DoctorLastName = reader.GetString(2);
					//3:Parameter AccountHolder of type String
					resultItem.AccountHolder = reader.GetString(3);
					//4:Parameter AccountNumber of type String
					resultItem.AccountNumber = reader.GetString(4);
					//5:Parameter BankName of type String
					resultItem.BankName = reader.GetString(5);
					//6:Parameter BLZ of type String
					resultItem.BLZ = reader.GetString(6);
					//7:Parameter Tenant_RefID of type Guid
					resultItem.Tenant_RefID = reader.GetGuid(7);
					//8:Parameter HEC_DoctorID of type Guid
					resultItem.HEC_DoctorID = reader.GetGuid(8);
					//9:Parameter HEC_Patient_TreatmentID of type Guid
					resultItem.HEC_Patient_TreatmentID = reader.GetGuid(9);
					//10:Parameter PracticeName of type String
					resultItem.PracticeName = reader.GetString(10);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Doctor_by_DoctorID_and_FollowupID",ex);
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
		public static FR_L5_DO_GDbDIDaFID_1513_Array Invoke(string ConnectionString,P_L5_DO_GDbDIDaFID_1513 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5_DO_GDbDIDaFID_1513_Array Invoke(DbConnection Connection,P_L5_DO_GDbDIDaFID_1513 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5_DO_GDbDIDaFID_1513_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5_DO_GDbDIDaFID_1513 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5_DO_GDbDIDaFID_1513_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5_DO_GDbDIDaFID_1513 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5_DO_GDbDIDaFID_1513_Array functionReturn = new FR_L5_DO_GDbDIDaFID_1513_Array();
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

				throw new Exception("Exception occured in method cls_Get_Doctor_by_DoctorID_and_FollowupID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5_DO_GDbDIDaFID_1513_Array : FR_Base
	{
		public L5_DO_GDbDIDaFID_1513[] Result	{ get; set; } 
		public FR_L5_DO_GDbDIDaFID_1513_Array() : base() {}

		public FR_L5_DO_GDbDIDaFID_1513_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5_DO_GDbDIDaFID_1513 for attribute P_L5_DO_GDbDIDaFID_1513
		[DataContract]
		public class P_L5_DO_GDbDIDaFID_1513 
		{
			//Standard type parameters
			[DataMember]
			public Guid DoctorsID { get; set; } 
			[DataMember]
			public Guid TreatmentID { get; set; } 

		}
		#endregion
		#region SClass L5_DO_GDbDIDaFID_1513 for attribute L5_DO_GDbDIDaFID_1513
		[DataContract]
		public class L5_DO_GDbDIDaFID_1513 
		{
			//Standard type parameters
			[DataMember]
			public String LANR { get; set; } 
			[DataMember]
			public String DoctorFirstName { get; set; } 
			[DataMember]
			public String DoctorLastName { get; set; } 
			[DataMember]
			public String AccountHolder { get; set; } 
			[DataMember]
			public String AccountNumber { get; set; } 
			[DataMember]
			public String BankName { get; set; } 
			[DataMember]
			public String BLZ { get; set; } 
			[DataMember]
			public Guid Tenant_RefID { get; set; } 
			[DataMember]
			public Guid HEC_DoctorID { get; set; } 
			[DataMember]
			public Guid HEC_Patient_TreatmentID { get; set; } 
			[DataMember]
			public String PracticeName { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5_DO_GDbDIDaFID_1513_Array cls_Get_Doctor_by_DoctorID_and_FollowupID(,P_L5_DO_GDbDIDaFID_1513 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5_DO_GDbDIDaFID_1513_Array invocationResult = cls_Get_Doctor_by_DoctorID_and_FollowupID.Invoke(connectionString,P_L5_DO_GDbDIDaFID_1513 Parameter,securityTicket);
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
var parameter = new CL5_Lucentis_Doctors.Atomic.Retrieval.P_L5_DO_GDbDIDaFID_1513();
parameter.DoctorsID = ...;
parameter.TreatmentID = ...;

*/
