/* 
 * Generated on 11.02.2015 13:45:38
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
    /// var result = cls_Get_TenantMemershipData.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_TenantMemershipData
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5MPC_GTMD_1342 Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5MPC_GTMD_1342();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_MedProCommunity.Atomic.Retrieval.SQL.cls_Get_TenantMemershipData.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L5MPC_GTMD_1342_raw> results = new List<L5MPC_GTMD_1342_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_BPT_BusinessParticipantID","HEC_CMT_Membership_CredentialID","HEC_CMT_MembershipID","Membership_Username","Membership_Password" });
				while(reader.Read())
				{
					L5MPC_GTMD_1342_raw resultItem = new L5MPC_GTMD_1342_raw();
					//0:Parameter CMN_BPT_BusinessParticipantID of type Guid
					resultItem.CMN_BPT_BusinessParticipantID = reader.GetGuid(0);
					//1:Parameter HEC_CMT_Membership_CredentialID of type Guid
					resultItem.HEC_CMT_Membership_CredentialID = reader.GetGuid(1);
					//2:Parameter HEC_CMT_MembershipID of type Guid
					resultItem.HEC_CMT_MembershipID = reader.GetGuid(2);
					//3:Parameter Membership_Username of type string
					resultItem.Membership_Username = reader.GetString(3);
					//4:Parameter Membership_Password of type string
					resultItem.Membership_Password = reader.GetString(4);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_TenantMemershipData",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5MPC_GTMD_1342_raw.Convert(results).FirstOrDefault();

			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5MPC_GTMD_1342 Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5MPC_GTMD_1342 Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5MPC_GTMD_1342 Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5MPC_GTMD_1342 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5MPC_GTMD_1342 functionReturn = new FR_L5MPC_GTMD_1342();
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

				throw new Exception("Exception occured in method cls_Get_TenantMemershipData",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5MPC_GTMD_1342_raw 
	{
		public Guid CMN_BPT_BusinessParticipantID; 
		public Guid HEC_CMT_Membership_CredentialID; 
		public Guid HEC_CMT_MembershipID; 
		public string Membership_Username; 
		public string Membership_Password; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5MPC_GTMD_1342[] Convert(List<L5MPC_GTMD_1342_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5MPC_GTMD_1342 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.CMN_BPT_BusinessParticipantID)).ToArray()
	group el_L5MPC_GTMD_1342 by new 
	{ 
		el_L5MPC_GTMD_1342.CMN_BPT_BusinessParticipantID,

	}
	into gfunct_L5MPC_GTMD_1342
	select new L5MPC_GTMD_1342
	{     
		CMN_BPT_BusinessParticipantID = gfunct_L5MPC_GTMD_1342.Key.CMN_BPT_BusinessParticipantID ,

		Credantial = 
		(
			from el_Credantial in gfunct_L5MPC_GTMD_1342.Where(element => !EqualsDefaultValue(element.HEC_CMT_Membership_CredentialID)).ToArray()
			group el_Credantial by new 
			{ 
				el_Credantial.HEC_CMT_Membership_CredentialID,

			}
			into gfunct_Credantial
			select new L5MPC_GTMD_1342_Credantial
			{     
				HEC_CMT_Membership_CredentialID = gfunct_Credantial.Key.HEC_CMT_Membership_CredentialID ,
				HEC_CMT_MembershipID = gfunct_Credantial.FirstOrDefault().HEC_CMT_MembershipID ,
				Membership_Username = gfunct_Credantial.FirstOrDefault().Membership_Username ,
				Membership_Password = gfunct_Credantial.FirstOrDefault().Membership_Password ,

			}
		).FirstOrDefault(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5MPC_GTMD_1342 : FR_Base
	{
		public L5MPC_GTMD_1342 Result	{ get; set; }

		public FR_L5MPC_GTMD_1342() : base() {}

		public FR_L5MPC_GTMD_1342(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5MPC_GTMD_1342 for attribute L5MPC_GTMD_1342
		[DataContract]
		public class L5MPC_GTMD_1342 
		{
			[DataMember]
			public L5MPC_GTMD_1342_Credantial Credantial { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid CMN_BPT_BusinessParticipantID { get; set; } 

		}
		#endregion
		#region SClass L5MPC_GTMD_1342_Credantial for attribute Credantial
		[DataContract]
		public class L5MPC_GTMD_1342_Credantial 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_CMT_Membership_CredentialID { get; set; } 
			[DataMember]
			public Guid HEC_CMT_MembershipID { get; set; } 
			[DataMember]
			public string Membership_Username { get; set; } 
			[DataMember]
			public string Membership_Password { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5MPC_GTMD_1342 cls_Get_TenantMemershipData(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5MPC_GTMD_1342 invocationResult = cls_Get_TenantMemershipData.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

