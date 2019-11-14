/* 
 * Generated on 9/10/2014 10:15:27 AM
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

namespace CL5_MyHealthClub_TaskTemplate.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_AppointmentName_for_OfficeID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_AppointmentName_for_OfficeID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5AP_GANfOID_0917_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5AP_GANfOID_0917 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5AP_GANfOID_0917_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_TaskTemplate.Atomic.Retrieval.SQL.cls_Get_AppointmentName_for_OfficeID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"OfficeID", Parameter.OfficeID);



			List<L5AP_GANfOID_0917> results = new List<L5AP_GANfOID_0917>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "DisplayName","PlannedStartDate","PlannedDuration_in_sec","PPS_TSK_Task_TemplateID" });
				while(reader.Read())
				{
					L5AP_GANfOID_0917 resultItem = new L5AP_GANfOID_0917();
					//0:Parameter DisplayName of type String
					resultItem.DisplayName = reader.GetString(0);
					//1:Parameter PlannedStartDate of type DateTime
					resultItem.PlannedStartDate = reader.GetDate(1);
					//2:Parameter PlannedDuration_in_sec of type String
					resultItem.PlannedDuration_in_sec = reader.GetString(2);
					//3:Parameter PPS_TSK_Task_TemplateID of type Guid
					resultItem.PPS_TSK_Task_TemplateID = reader.GetGuid(3);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_AppointmentName_for_OfficeID",ex);
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
		public static FR_L5AP_GANfOID_0917_Array Invoke(string ConnectionString,P_L5AP_GANfOID_0917 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5AP_GANfOID_0917_Array Invoke(DbConnection Connection,P_L5AP_GANfOID_0917 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5AP_GANfOID_0917_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AP_GANfOID_0917 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5AP_GANfOID_0917_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AP_GANfOID_0917 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5AP_GANfOID_0917_Array functionReturn = new FR_L5AP_GANfOID_0917_Array();
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

				throw new Exception("Exception occured in method cls_Get_AppointmentName_for_OfficeID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5AP_GANfOID_0917_Array : FR_Base
	{
		public L5AP_GANfOID_0917[] Result	{ get; set; } 
		public FR_L5AP_GANfOID_0917_Array() : base() {}

		public FR_L5AP_GANfOID_0917_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5AP_GANfOID_0917 for attribute P_L5AP_GANfOID_0917
		[DataContract]
		public class P_L5AP_GANfOID_0917 
		{
			//Standard type parameters
			[DataMember]
			public Guid OfficeID { get; set; } 

		}
		#endregion
		#region SClass L5AP_GANfOID_0917 for attribute L5AP_GANfOID_0917
		[DataContract]
		public class L5AP_GANfOID_0917 
		{
			//Standard type parameters
			[DataMember]
			public String DisplayName { get; set; } 
			[DataMember]
			public DateTime PlannedStartDate { get; set; } 
			[DataMember]
			public String PlannedDuration_in_sec { get; set; } 
			[DataMember]
			public Guid PPS_TSK_Task_TemplateID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5AP_GANfOID_0917_Array cls_Get_AppointmentName_for_OfficeID(,P_L5AP_GANfOID_0917 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5AP_GANfOID_0917_Array invocationResult = cls_Get_AppointmentName_for_OfficeID.Invoke(connectionString,P_L5AP_GANfOID_0917 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_TaskTemplate.Atomic.Retrieval.P_L5AP_GANfOID_0917();
parameter.OfficeID = ...;

*/
