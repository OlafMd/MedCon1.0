/* 
 * Generated on 11/04/15 14:13:08
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
    /// var result = cls_Get_Doctors_Consent_Details_for_AssignmentID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Doctors_Consent_Details_for_AssignmentID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_DO_GDCDfAID_1532 Execute(DbConnection Connection,DbTransaction Transaction,P_DO_GDCDfAID_1532 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_DO_GDCDfAID_1532();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.Doctor.Atomic.Retrieval.SQL.cls_Get_Doctors_Consent_Details_for_AssignmentID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"AssignmentID", Parameter.AssignmentID);



			List<DO_GDCDfAID_1532> results = new List<DO_GDCDfAID_1532>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "ContractID","AssignmentID","DoctorID","ContractName","ConsentValidFrom","ConsentValidThrough","ContractValidFrom","ContractValidThrough" });
				while(reader.Read())
				{
					DO_GDCDfAID_1532 resultItem = new DO_GDCDfAID_1532();
					//0:Parameter ContractID of type Guid
					resultItem.ContractID = reader.GetGuid(0);
					//1:Parameter AssignmentID of type Guid
					resultItem.AssignmentID = reader.GetGuid(1);
					//2:Parameter DoctorID of type Guid
					resultItem.DoctorID = reader.GetGuid(2);
					//3:Parameter ContractName of type String
					resultItem.ContractName = reader.GetString(3);
					//4:Parameter ConsentValidFrom of type DateTime
					resultItem.ConsentValidFrom = reader.GetDate(4);
					//5:Parameter ConsentValidThrough of type DateTime
					resultItem.ConsentValidThrough = reader.GetDate(5);
					//6:Parameter ContractValidFrom of type DateTime
					resultItem.ContractValidFrom = reader.GetDate(6);
					//7:Parameter ContractValidThrough of type DateTime
					resultItem.ContractValidThrough = reader.GetDate(7);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Doctors_Consent_Details_for_AssignmentID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = results.FirstOrDefault();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_DO_GDCDfAID_1532 Invoke(string ConnectionString,P_DO_GDCDfAID_1532 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_DO_GDCDfAID_1532 Invoke(DbConnection Connection,P_DO_GDCDfAID_1532 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_DO_GDCDfAID_1532 Invoke(DbConnection Connection, DbTransaction Transaction,P_DO_GDCDfAID_1532 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_DO_GDCDfAID_1532 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_DO_GDCDfAID_1532 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_DO_GDCDfAID_1532 functionReturn = new FR_DO_GDCDfAID_1532();
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

				throw new Exception("Exception occured in method cls_Get_Doctors_Consent_Details_for_AssignmentID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_DO_GDCDfAID_1532 : FR_Base
	{
		public DO_GDCDfAID_1532 Result	{ get; set; }

		public FR_DO_GDCDfAID_1532() : base() {}

		public FR_DO_GDCDfAID_1532(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_DO_GDCDfAID_1532 for attribute P_DO_GDCDfAID_1532
		[DataContract]
		public class P_DO_GDCDfAID_1532 
		{
			//Standard type parameters
			[DataMember]
			public Guid AssignmentID { get; set; } 

		}
		#endregion
		#region SClass DO_GDCDfAID_1532 for attribute DO_GDCDfAID_1532
		[DataContract]
		public class DO_GDCDfAID_1532 
		{
			//Standard type parameters
			[DataMember]
			public Guid ContractID { get; set; } 
			[DataMember]
			public Guid AssignmentID { get; set; } 
			[DataMember]
			public Guid DoctorID { get; set; } 
			[DataMember]
			public String ContractName { get; set; } 
			[DataMember]
			public DateTime ConsentValidFrom { get; set; } 
			[DataMember]
			public DateTime ConsentValidThrough { get; set; } 
			[DataMember]
			public DateTime ContractValidFrom { get; set; } 
			[DataMember]
			public DateTime ContractValidThrough { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_DO_GDCDfAID_1532 cls_Get_Doctors_Consent_Details_for_AssignmentID(,P_DO_GDCDfAID_1532 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_DO_GDCDfAID_1532 invocationResult = cls_Get_Doctors_Consent_Details_for_AssignmentID.Invoke(connectionString,P_DO_GDCDfAID_1532 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Doctor.Atomic.Retrieval.P_DO_GDCDfAID_1532();
parameter.AssignmentID = ...;

*/
