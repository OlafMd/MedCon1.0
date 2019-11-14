/* 
 * Generated on 8/31/2013 1:53:32 PM
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
using CL3_MedicalPractices.Atomic.Retrieval;

namespace CL5_Lucentis_Practice.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_GetPractice_for_TenantID_and_PraciceID_Admin.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_GetPractice_for_TenantID_and_PraciceID_Admin
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5PP_GPFTIDaPIDA_1406 Execute(DbConnection Connection,DbTransaction Transaction,P_L5PP_GPFTIDaPIDA_1406 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5PP_GPFTIDaPIDA_1406();

            returnValue.Result = new L5PP_GPFTIDaPIDA_1406();
            returnValue.Result.ContactPerson = new L3MP_GPCPfPID_1155();
            returnValue.Result.PracticeData = new L3MP_GPBIfID_1131();
            List<L3MP_GCPfPBITID_1228> copPractices = new List<L3MP_GCPfPBITID_1228>();
            returnValue.Result.CooperatingPractices = copPractices.ToArray();

            P_L3MP_GPBIfID_1131 par = new P_L3MP_GPBIfID_1131();
            par.HEC_MedicalPractiseID = Parameter.PracticeID;

            L3MP_GPBIfID_1131 PracticeData = cls_Get_Practice_BaseInfo_For_ID.Invoke(Connection, Transaction, par, securityTicket).Result;

            returnValue.Result.PracticeData = PracticeData;

            P_L3MP_GPCPfPID_1155 param = new P_L3MP_GPCPfPID_1155();
            param.CMN_BPT_BusinessParticipantID = PracticeData.ContactPerson_RefID;

            L3MP_GPCPfPID_1155 ContactPerson = cls_Get_Practice_ContactPerson_For_PersonID.Invoke(Connection, Transaction, param, securityTicket).Result;

            returnValue.Result.ContactPerson = ContactPerson;


            P_L3MP_GCPfPBITID_1228 parameter = new P_L3MP_GCPfPBITID_1228();
            parameter.PracticeBussinessParticipant_RefID = PracticeData.CMN_BPT_BusinessParticipantID;

            List<L3MP_GCPfPBITID_1228> CooperatingPractices = cls_Get_CooperatingPractices_For_PracticeBussinessID_and_TenantID.Invoke(Connection, Transaction, parameter, securityTicket).Result.ToList();

            returnValue.Result.CooperatingPractices = CooperatingPractices.ToArray();

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5PP_GPFTIDaPIDA_1406 Invoke(string ConnectionString,P_L5PP_GPFTIDaPIDA_1406 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5PP_GPFTIDaPIDA_1406 Invoke(DbConnection Connection,P_L5PP_GPFTIDaPIDA_1406 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5PP_GPFTIDaPIDA_1406 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5PP_GPFTIDaPIDA_1406 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5PP_GPFTIDaPIDA_1406 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5PP_GPFTIDaPIDA_1406 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5PP_GPFTIDaPIDA_1406 functionReturn = new FR_L5PP_GPFTIDaPIDA_1406();
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

				throw new Exception("Exception occured in method cls_GetPractice_for_TenantID_and_PraciceID_Admin",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5PP_GPFTIDaPIDA_1406 : FR_Base
	{
		public L5PP_GPFTIDaPIDA_1406 Result	{ get; set; }

		public FR_L5PP_GPFTIDaPIDA_1406() : base() {}

		public FR_L5PP_GPFTIDaPIDA_1406(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5PP_GPFTIDaPIDA_1406 for attribute P_L5PP_GPFTIDaPIDA_1406
		[DataContract]
		public class P_L5PP_GPFTIDaPIDA_1406 
		{
			//Standard type parameters
			[DataMember]
			public Guid PracticeID { get; set; } 

		}
		#endregion
		#region SClass L5PP_GPFTIDaPIDA_1406 for attribute L5PP_GPFTIDaPIDA_1406
		[DataContract]
		public class L5PP_GPFTIDaPIDA_1406 
		{
			//Standard type parameters
			[DataMember]
			public L3MP_GPBIfID_1131 PracticeData { get; set; } 
			[DataMember]
			public L3MP_GPCPfPID_1155 ContactPerson { get; set; } 
			[DataMember]
			public L3MP_GCPfPBITID_1228[] CooperatingPractices { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5PP_GPFTIDaPIDA_1406 cls_GetPractice_for_TenantID_and_PraciceID_Admin(,P_L5PP_GPFTIDaPIDA_1406 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5PP_GPFTIDaPIDA_1406 invocationResult = cls_GetPractice_for_TenantID_and_PraciceID_Admin.Invoke(connectionString,P_L5PP_GPFTIDaPIDA_1406 Parameter,securityTicket);
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
var parameter = new CL5_Lucentis_Practice.Atomic.Retrieval.P_L5PP_GPFTIDaPIDA_1406();
parameter.PracticeID = ...;

*/
