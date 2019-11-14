/* 
 * Generated on 8/31/2013 12:33:04 PM
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

namespace CL3_MedicalPractices.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Practice_ContactPerson_For_PersonID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Practice_ContactPerson_For_PersonID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3MP_GPCPfPID_1155 Execute(DbConnection Connection,DbTransaction Transaction,P_L3MP_GPCPfPID_1155 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3MP_GPCPfPID_1155();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_MedicalPractices.Atomic.Retrieval.SQL.cls_Get_Practice_ContactPerson_For_PersonID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CMN_BPT_BusinessParticipantID", Parameter.CMN_BPT_BusinessParticipantID);



			List<L3MP_GPCPfPID_1155> results = new List<L3MP_GPCPfPID_1155>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "Ophthal_ContactPerson","Luc_ContactPerPhoneID","CMN_PER_PersonInfoID","Luc_ContactPerPhone","Luc_ContactPerLName","Luc_ContactPerFName","Luc_ContactPerEmail" });
				while(reader.Read())
				{
					L3MP_GPCPfPID_1155 resultItem = new L3MP_GPCPfPID_1155();
					//0:Parameter Ophthal_ContactPerson of type String
					resultItem.Ophthal_ContactPerson = reader.GetString(0);
					//1:Parameter Luc_ContactPerPhoneID of type Guid
					resultItem.Luc_ContactPerPhoneID = reader.GetGuid(1);
					//2:Parameter CMN_PER_PersonInfoID of type Guid
					resultItem.CMN_PER_PersonInfoID = reader.GetGuid(2);
					//3:Parameter Luc_ContactPerPhone of type String
					resultItem.Luc_ContactPerPhone = reader.GetString(3);
					//4:Parameter Luc_ContactPerLName of type String
					resultItem.Luc_ContactPerLName = reader.GetString(4);
					//5:Parameter Luc_ContactPerFName of type String
					resultItem.Luc_ContactPerFName = reader.GetString(5);
					//6:Parameter Luc_ContactPerEmail of type String
					resultItem.Luc_ContactPerEmail = reader.GetString(6);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Practice_ContactPerson_For_PersonID",ex);
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
		public static FR_L3MP_GPCPfPID_1155 Invoke(string ConnectionString,P_L3MP_GPCPfPID_1155 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3MP_GPCPfPID_1155 Invoke(DbConnection Connection,P_L3MP_GPCPfPID_1155 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3MP_GPCPfPID_1155 Invoke(DbConnection Connection, DbTransaction Transaction,P_L3MP_GPCPfPID_1155 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3MP_GPCPfPID_1155 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3MP_GPCPfPID_1155 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3MP_GPCPfPID_1155 functionReturn = new FR_L3MP_GPCPfPID_1155();
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

				throw new Exception("Exception occured in method cls_Get_Practice_ContactPerson_For_PersonID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3MP_GPCPfPID_1155 : FR_Base
	{
		public L3MP_GPCPfPID_1155 Result	{ get; set; }

		public FR_L3MP_GPCPfPID_1155() : base() {}

		public FR_L3MP_GPCPfPID_1155(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3MP_GPCPfPID_1155 for attribute P_L3MP_GPCPfPID_1155
		[DataContract]
		public class P_L3MP_GPCPfPID_1155 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_BPT_BusinessParticipantID { get; set; } 

		}
		#endregion
		#region SClass L3MP_GPCPfPID_1155 for attribute L3MP_GPCPfPID_1155
		[DataContract]
		public class L3MP_GPCPfPID_1155 
		{
			//Standard type parameters
			[DataMember]
			public String Ophthal_ContactPerson { get; set; } 
			[DataMember]
			public Guid Luc_ContactPerPhoneID { get; set; } 
			[DataMember]
			public Guid CMN_PER_PersonInfoID { get; set; } 
			[DataMember]
			public String Luc_ContactPerPhone { get; set; } 
			[DataMember]
			public String Luc_ContactPerLName { get; set; } 
			[DataMember]
			public String Luc_ContactPerFName { get; set; } 
			[DataMember]
			public String Luc_ContactPerEmail { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3MP_GPCPfPID_1155 cls_Get_Practice_ContactPerson_For_PersonID(,P_L3MP_GPCPfPID_1155 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = VerifySessionToken(sessionToken);
		FR_L3MP_GPCPfPID_1155 invocationResult = cls_Get_Practice_ContactPerson_For_PersonID.Invoke(connectionString,P_L3MP_GPCPfPID_1155 Parameter,securityTicket);
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
var parameter = new CL3_MedicalPractices.Atomic.Retrieval.P_L3MP_GPCPfPID_1155();
parameter.CMN_BPT_BusinessParticipantID = ...;

*/
