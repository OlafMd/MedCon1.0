/* 
 * Generated on 9/3/2013 4:49:09 PM
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

namespace CL3_Doctors.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Doctor_by_DeviceCode.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Doctor_by_DeviceCode
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3MD_GDDC_0928 Execute(DbConnection Connection,DbTransaction Transaction,P_L3MD_GDDC_0928 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3MD_GDDC_0928();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_Doctors.Atomic.Retrieval.SQL.cls_Get_Doctor_by_DeviceCode.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"DeviceCode", Parameter.DeviceCode);



			List<L3MD_GDDC_0928> results = new List<L3MD_GDDC_0928>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "HEC_DoctorID","CMN_BPT_BusinessParticipantID","CMN_PER_PersonInfoID","FirstName","PrimaryEmail","LastName","Title","Salutation_General","Salutation_Letter","USR_AccountID","USR_Device_AccountCodeID","AccountCode_Value","Tenant_RefID" });
				while(reader.Read())
				{
					L3MD_GDDC_0928 resultItem = new L3MD_GDDC_0928();
					//0:Parameter HEC_DoctorID of type Guid
					resultItem.HEC_DoctorID = reader.GetGuid(0);
					//1:Parameter CMN_BPT_BusinessParticipantID of type Guid
					resultItem.CMN_BPT_BusinessParticipantID = reader.GetGuid(1);
					//2:Parameter CMN_PER_PersonInfoID of type Guid
					resultItem.CMN_PER_PersonInfoID = reader.GetGuid(2);
					//3:Parameter FirstName of type String
					resultItem.FirstName = reader.GetString(3);
					//4:Parameter PrimaryEmail of type String
					resultItem.PrimaryEmail = reader.GetString(4);
					//5:Parameter LastName of type String
					resultItem.LastName = reader.GetString(5);
					//6:Parameter Title of type String
					resultItem.Title = reader.GetString(6);
					//7:Parameter Salutation_General of type String
					resultItem.Salutation_General = reader.GetString(7);
					//8:Parameter Salutation_Letter of type String
					resultItem.Salutation_Letter = reader.GetString(8);
					//9:Parameter USR_AccountID of type Guid
					resultItem.USR_AccountID = reader.GetGuid(9);
					//10:Parameter USR_Device_AccountCodeID of type Guid
					resultItem.USR_Device_AccountCodeID = reader.GetGuid(10);
					//11:Parameter AccountCode_Value of type String
					resultItem.AccountCode_Value = reader.GetString(11);
					//12:Parameter Tenant_RefID of type Guid
					resultItem.Tenant_RefID = reader.GetGuid(12);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Doctor_by_DeviceCode",ex);
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
		public static FR_L3MD_GDDC_0928 Invoke(string ConnectionString,P_L3MD_GDDC_0928 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3MD_GDDC_0928 Invoke(DbConnection Connection,P_L3MD_GDDC_0928 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3MD_GDDC_0928 Invoke(DbConnection Connection, DbTransaction Transaction,P_L3MD_GDDC_0928 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3MD_GDDC_0928 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3MD_GDDC_0928 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3MD_GDDC_0928 functionReturn = new FR_L3MD_GDDC_0928();
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

				throw new Exception("Exception occured in method cls_Get_Doctor_by_DeviceCode",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3MD_GDDC_0928 : FR_Base
	{
		public L3MD_GDDC_0928 Result	{ get; set; }

		public FR_L3MD_GDDC_0928() : base() {}

		public FR_L3MD_GDDC_0928(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3MD_GDDC_0928 for attribute P_L3MD_GDDC_0928
		[DataContract]
		public class P_L3MD_GDDC_0928 
		{
			//Standard type parameters
			[DataMember]
			public String DeviceCode { get; set; } 

		}
		#endregion
		#region SClass L3MD_GDDC_0928 for attribute L3MD_GDDC_0928
		[DataContract]
		public class L3MD_GDDC_0928 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_DoctorID { get; set; } 
			[DataMember]
			public Guid CMN_BPT_BusinessParticipantID { get; set; } 
			[DataMember]
			public Guid CMN_PER_PersonInfoID { get; set; } 
			[DataMember]
			public String FirstName { get; set; } 
			[DataMember]
			public String PrimaryEmail { get; set; } 
			[DataMember]
			public String LastName { get; set; } 
			[DataMember]
			public String Title { get; set; } 
			[DataMember]
			public String Salutation_General { get; set; } 
			[DataMember]
			public String Salutation_Letter { get; set; } 
			[DataMember]
			public Guid USR_AccountID { get; set; } 
			[DataMember]
			public Guid USR_Device_AccountCodeID { get; set; } 
			[DataMember]
			public String AccountCode_Value { get; set; } 
			[DataMember]
			public Guid Tenant_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3MD_GDDC_0928 cls_Get_Doctor_by_DeviceCode(,P_L3MD_GDDC_0928 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3MD_GDDC_0928 invocationResult = cls_Get_Doctor_by_DeviceCode.Invoke(connectionString,P_L3MD_GDDC_0928 Parameter,securityTicket);
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
var parameter = new CL3_Doctors.Atomic.Retrieval.P_L3MD_GDDC_0928();
parameter.DeviceCode = ...;

*/
