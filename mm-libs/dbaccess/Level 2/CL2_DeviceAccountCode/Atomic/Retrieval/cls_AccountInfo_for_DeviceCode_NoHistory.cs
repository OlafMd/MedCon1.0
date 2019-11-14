/* 
 * Generated on 2/25/2015 1:03:18 AM
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

namespace CL2_DeviceAccountCode.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_AccountInfo_for_DeviceCode_NoHistory.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_AccountInfo_for_DeviceCode_NoHistory
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2_AIFDCNH_1556_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L2_AIFDCNH_1556 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2_AIFDCNH_1556_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_DeviceAccountCode.Atomic.Retrieval.SQL.cls_AccountInfo_for_DeviceCode_NoHistory.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"DeviceCode", Parameter.DeviceCode);



			List<L2_AIFDCNH_1556> results = new List<L2_AIFDCNH_1556>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "FirstName","PrimaryEmail","LastName","Title","Salutation_General","Salutation_Letter","CMN_BPT_BusinessParticipantID","CMN_PER_PersonInfoID","CMN_BPT_BusinessParticipant_AccessCodeID","Code","Tenant_RefID" });
				while(reader.Read())
				{
					L2_AIFDCNH_1556 resultItem = new L2_AIFDCNH_1556();
					//0:Parameter FirstName of type String
					resultItem.FirstName = reader.GetString(0);
					//1:Parameter PrimaryEmail of type String
					resultItem.PrimaryEmail = reader.GetString(1);
					//2:Parameter LastName of type String
					resultItem.LastName = reader.GetString(2);
					//3:Parameter Title of type String
					resultItem.Title = reader.GetString(3);
					//4:Parameter Salutation_General of type String
					resultItem.Salutation_General = reader.GetString(4);
					//5:Parameter Salutation_Letter of type String
					resultItem.Salutation_Letter = reader.GetString(5);
					//6:Parameter CMN_BPT_BusinessParticipantID of type Guid
					resultItem.CMN_BPT_BusinessParticipantID = reader.GetGuid(6);
					//7:Parameter CMN_PER_PersonInfoID of type Guid
					resultItem.CMN_PER_PersonInfoID = reader.GetGuid(7);
					//8:Parameter CMN_BPT_BusinessParticipant_AccessCodeID of type Guid
					resultItem.CMN_BPT_BusinessParticipant_AccessCodeID = reader.GetGuid(8);
					//9:Parameter Code of type String
					resultItem.Code = reader.GetString(9);
					//10:Parameter Tenant_RefID of type Guid
					resultItem.Tenant_RefID = reader.GetGuid(10);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_AccountInfo_for_DeviceCode_NoHistory",ex);
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
		public static FR_L2_AIFDCNH_1556_Array Invoke(string ConnectionString,P_L2_AIFDCNH_1556 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2_AIFDCNH_1556_Array Invoke(DbConnection Connection,P_L2_AIFDCNH_1556 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2_AIFDCNH_1556_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L2_AIFDCNH_1556 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2_AIFDCNH_1556_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2_AIFDCNH_1556 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2_AIFDCNH_1556_Array functionReturn = new FR_L2_AIFDCNH_1556_Array();
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

				throw new Exception("Exception occured in method cls_AccountInfo_for_DeviceCode_NoHistory",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2_AIFDCNH_1556_Array : FR_Base
	{
		public L2_AIFDCNH_1556[] Result	{ get; set; } 
		public FR_L2_AIFDCNH_1556_Array() : base() {}

		public FR_L2_AIFDCNH_1556_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L2_AIFDCNH_1556 for attribute P_L2_AIFDCNH_1556
		[DataContract]
		public class P_L2_AIFDCNH_1556 
		{
			//Standard type parameters
			[DataMember]
			public String DeviceCode { get; set; } 

		}
		#endregion
		#region SClass L2_AIFDCNH_1556 for attribute L2_AIFDCNH_1556
		[DataContract]
		public class L2_AIFDCNH_1556 
		{
			//Standard type parameters
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
			public Guid CMN_BPT_BusinessParticipantID { get; set; } 
			[DataMember]
			public Guid CMN_PER_PersonInfoID { get; set; } 
			[DataMember]
			public Guid CMN_BPT_BusinessParticipant_AccessCodeID { get; set; } 
			[DataMember]
			public String Code { get; set; } 
			[DataMember]
			public Guid Tenant_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2_AIFDCNH_1556_Array cls_AccountInfo_for_DeviceCode_NoHistory(,P_L2_AIFDCNH_1556 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2_AIFDCNH_1556_Array invocationResult = cls_AccountInfo_for_DeviceCode_NoHistory.Invoke(connectionString,P_L2_AIFDCNH_1556 Parameter,securityTicket);
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
var parameter = new CL2_DeviceAccountCode.Atomic.Retrieval.P_L2_AIFDCNH_1556();
parameter.DeviceCode = ...;

*/
