/* 
 * Generated on 11/04/15 14:13:22
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
    /// var result = cls_Get_Doctors_ConsentStartDate_for_DoctorID_and_ContractID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Doctors_ConsentStartDate_for_DoctorID_and_ContractID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_DO_GDCSDfDIDaCID_1411 Execute(DbConnection Connection,DbTransaction Transaction,P_DO_GDCSDfDIDaCID_1411 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_DO_GDCSDfDIDaCID_1411();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.Doctor.Atomic.Retrieval.SQL.cls_Get_Doctors_ConsentStartDate_for_DoctorID_and_ContractID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"DoctorID", Parameter.DoctorID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ContractID", Parameter.ContractID);



			List<DO_GDCSDfDIDaCID_1411> results = new List<DO_GDCSDfDIDaCID_1411>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "ConsentStartDate" });
				while(reader.Read())
				{
					DO_GDCSDfDIDaCID_1411 resultItem = new DO_GDCSDfDIDaCID_1411();
					//0:Parameter ConsentStartDate of type DateTime
					resultItem.ConsentStartDate = reader.GetDate(0);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Doctors_ConsentStartDate_for_DoctorID_and_ContractID",ex);
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
		public static FR_DO_GDCSDfDIDaCID_1411 Invoke(string ConnectionString,P_DO_GDCSDfDIDaCID_1411 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_DO_GDCSDfDIDaCID_1411 Invoke(DbConnection Connection,P_DO_GDCSDfDIDaCID_1411 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_DO_GDCSDfDIDaCID_1411 Invoke(DbConnection Connection, DbTransaction Transaction,P_DO_GDCSDfDIDaCID_1411 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_DO_GDCSDfDIDaCID_1411 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_DO_GDCSDfDIDaCID_1411 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_DO_GDCSDfDIDaCID_1411 functionReturn = new FR_DO_GDCSDfDIDaCID_1411();
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

				throw new Exception("Exception occured in method cls_Get_Doctors_ConsentStartDate_for_DoctorID_and_ContractID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_DO_GDCSDfDIDaCID_1411 : FR_Base
	{
		public DO_GDCSDfDIDaCID_1411 Result	{ get; set; }

		public FR_DO_GDCSDfDIDaCID_1411() : base() {}

		public FR_DO_GDCSDfDIDaCID_1411(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_DO_GDCSDfDIDaCID_1411 for attribute P_DO_GDCSDfDIDaCID_1411
		[DataContract]
		public class P_DO_GDCSDfDIDaCID_1411 
		{
			//Standard type parameters
			[DataMember]
			public Guid DoctorID { get; set; } 
			[DataMember]
			public Guid ContractID { get; set; } 

		}
		#endregion
		#region SClass DO_GDCSDfDIDaCID_1411 for attribute DO_GDCSDfDIDaCID_1411
		[DataContract]
		public class DO_GDCSDfDIDaCID_1411 
		{
			//Standard type parameters
			[DataMember]
			public DateTime ConsentStartDate { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_DO_GDCSDfDIDaCID_1411 cls_Get_Doctors_ConsentStartDate_for_DoctorID_and_ContractID(,P_DO_GDCSDfDIDaCID_1411 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_DO_GDCSDfDIDaCID_1411 invocationResult = cls_Get_Doctors_ConsentStartDate_for_DoctorID_and_ContractID.Invoke(connectionString,P_DO_GDCSDfDIDaCID_1411 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Doctor.Atomic.Retrieval.P_DO_GDCSDfDIDaCID_1411();
parameter.DoctorID = ...;
parameter.ContractID = ...;

*/
