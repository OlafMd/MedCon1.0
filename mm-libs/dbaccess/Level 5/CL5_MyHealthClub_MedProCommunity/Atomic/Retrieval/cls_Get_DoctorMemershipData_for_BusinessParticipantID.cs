/* 
 * Generated on 2/13/2015 9:57:10 AM
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

namespace CL5_MyHealthClub_MedProCommunity.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_DoctorMemershipData_for_BusinessParticipantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_DoctorMemershipData_for_BusinessParticipantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5MPC_GDMDfBPID_0952 Execute(DbConnection Connection,DbTransaction Transaction,P_L5MPC_GDMDfBPID_0952 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5MPC_GDMDfBPID_0952();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_MedProCommunity.Atomic.Retrieval.SQL.cls_Get_DoctorMemershipData_for_BusinessParticipantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"BusinessParticipantID", Parameter.BusinessParticipantID);



			List<L5MPC_GDMDfBPID_0952> results = new List<L5MPC_GDMDfBPID_0952>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "Membership_Username","Membership_Password","HEC_CMT_MembershipID","CMN_BPT_BusinessParticipantID","HEC_CMT_Membership_CredentialID" });
				while(reader.Read())
				{
					L5MPC_GDMDfBPID_0952 resultItem = new L5MPC_GDMDfBPID_0952();
					//0:Parameter Membership_Username of type String
					resultItem.Membership_Username = reader.GetString(0);
					//1:Parameter Membership_Password of type String
					resultItem.Membership_Password = reader.GetString(1);
					//2:Parameter HEC_CMT_MembershipID of type Guid
					resultItem.HEC_CMT_MembershipID = reader.GetGuid(2);
					//3:Parameter CMN_BPT_BusinessParticipantID of type Guid
					resultItem.CMN_BPT_BusinessParticipantID = reader.GetGuid(3);
					//4:Parameter HEC_CMT_Membership_CredentialID of type Guid
					resultItem.HEC_CMT_Membership_CredentialID = reader.GetGuid(4);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_DoctorMemershipData_for_BusinessParticipantID",ex);
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
		public static FR_L5MPC_GDMDfBPID_0952 Invoke(string ConnectionString,P_L5MPC_GDMDfBPID_0952 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5MPC_GDMDfBPID_0952 Invoke(DbConnection Connection,P_L5MPC_GDMDfBPID_0952 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5MPC_GDMDfBPID_0952 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5MPC_GDMDfBPID_0952 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5MPC_GDMDfBPID_0952 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5MPC_GDMDfBPID_0952 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5MPC_GDMDfBPID_0952 functionReturn = new FR_L5MPC_GDMDfBPID_0952();
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

				throw new Exception("Exception occured in method cls_Get_DoctorMemershipData_for_BusinessParticipantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5MPC_GDMDfBPID_0952 : FR_Base
	{
		public L5MPC_GDMDfBPID_0952 Result	{ get; set; }

		public FR_L5MPC_GDMDfBPID_0952() : base() {}

		public FR_L5MPC_GDMDfBPID_0952(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5MPC_GDMDfBPID_0952 for attribute P_L5MPC_GDMDfBPID_0952
		[DataContract]
		public class P_L5MPC_GDMDfBPID_0952 
		{
			//Standard type parameters
			[DataMember]
			public Guid BusinessParticipantID { get; set; } 

		}
		#endregion
		#region SClass L5MPC_GDMDfBPID_0952 for attribute L5MPC_GDMDfBPID_0952
		[DataContract]
		public class L5MPC_GDMDfBPID_0952 
		{
			//Standard type parameters
			[DataMember]
			public String Membership_Username { get; set; } 
			[DataMember]
			public String Membership_Password { get; set; } 
			[DataMember]
			public Guid HEC_CMT_MembershipID { get; set; } 
			[DataMember]
			public Guid CMN_BPT_BusinessParticipantID { get; set; } 
			[DataMember]
			public Guid HEC_CMT_Membership_CredentialID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5MPC_GDMDfBPID_0952 cls_Get_DoctorMemershipData_for_BusinessParticipantID(,P_L5MPC_GDMDfBPID_0952 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5MPC_GDMDfBPID_0952 invocationResult = cls_Get_DoctorMemershipData_for_BusinessParticipantID.Invoke(connectionString,P_L5MPC_GDMDfBPID_0952 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_MedProCommunity.Atomic.Retrieval.P_L5MPC_GDMDfBPID_0952();
parameter.BusinessParticipantID = ...;

*/
