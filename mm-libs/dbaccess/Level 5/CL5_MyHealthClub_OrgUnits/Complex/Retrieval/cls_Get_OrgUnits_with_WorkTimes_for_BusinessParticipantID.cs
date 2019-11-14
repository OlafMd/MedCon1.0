/* 
 * Generated on 1/8/2015 12:24:01
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
using CL5_MyHealthClub_OrgUnits.Atomic.Retrieval;

namespace CL5_MyHealthClub_OrgUnits.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_OrgUnits_with_WorkTimes_for_BusinessParticipantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_OrgUnits_with_WorkTimes_for_BusinessParticipantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5OU_GOUwWT_1346 Execute(DbConnection Connection,DbTransaction Transaction,P_L5OU_GOUwWT_1346 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_L5OU_GOUwWT_1346();
          
            P_L5OU_GOUNfBPID_1501 ParameterOrgUnitsForBusinessPar = new P_L5OU_GOUNfBPID_1501();
            ParameterOrgUnitsForBusinessPar.BusinessParticipantID=Parameter.BusinessParticipantID;
            var orgUnitsInfoForBusinessParticipantID = cls_Get_OrgUnitNames_for_BusinessParticipantID.Invoke(Connection, Transaction, ParameterOrgUnitsForBusinessPar, securityTicket).Result.ToArray();
            L5OU_GOUwWT_1346 OrgUnitsNamesAndStandardTimes = new L5OU_GOUwWT_1346();
            OrgUnitsNamesAndStandardTimes.OrgUnitOfficeName = orgUnitsInfoForBusinessParticipantID;
            List<L5OU_GOUwWT_1346StandardTimes> orgUnitsStandardTimesForOfficeID = new List<L5OU_GOUwWT_1346StandardTimes>();
            foreach(var office in orgUnitsInfoForBusinessParticipantID){

                 L5OU_GOUwWT_1346StandardTimes StandardTimes = new L5OU_GOUwWT_1346StandardTimes();
                 StandardTimes.CMN_STR_OfficeID = office.CMN_STR_OfficeID;
                 P_L5OU_GSHfOID_1540 ParameterOrgUnitStandardTime = new P_L5OU_GSHfOID_1540();
                 ParameterOrgUnitStandardTime.OfficeID=office.CMN_STR_OfficeID;
                 L5OU_GSHfOID_1540[] orgUnitStandardTimes = cls_Get_StandardHours_for_OfficeID.Invoke(Connection, Transaction, ParameterOrgUnitStandardTime, securityTicket).Result;
                 StandardTimes.StandardWorkTimes = orgUnitStandardTimes;
                 orgUnitsStandardTimesForOfficeID.Add(StandardTimes);
            }
            OrgUnitsNamesAndStandardTimes.OrgUnitStandardWorkTime = orgUnitsStandardTimesForOfficeID.ToArray();
            returnValue.Result = OrgUnitsNamesAndStandardTimes;
			//Put your code here
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5OU_GOUwWT_1346 Invoke(string ConnectionString,P_L5OU_GOUwWT_1346 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5OU_GOUwWT_1346 Invoke(DbConnection Connection,P_L5OU_GOUwWT_1346 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5OU_GOUwWT_1346 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5OU_GOUwWT_1346 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5OU_GOUwWT_1346 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5OU_GOUwWT_1346 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5OU_GOUwWT_1346 functionReturn = new FR_L5OU_GOUwWT_1346();
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

				throw new Exception("Exception occured in method cls_Get_OrgUnits_with_WorkTimes_for_BusinessParticipantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5OU_GOUwWT_1346 : FR_Base
	{
		public L5OU_GOUwWT_1346 Result	{ get; set; }

		public FR_L5OU_GOUwWT_1346() : base() {}

		public FR_L5OU_GOUwWT_1346(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5OU_GOUwWT_1346 for attribute P_L5OU_GOUwWT_1346
		[DataContract]
		public class P_L5OU_GOUwWT_1346 
		{
			//Standard type parameters
			[DataMember]
			public Guid BusinessParticipantID { get; set; } 

		}
		#endregion
		#region SClass L5OU_GOUwWT_1346 for attribute L5OU_GOUwWT_1346
		[DataContract]
		public class L5OU_GOUwWT_1346 
		{
			[DataMember]
			public L5OU_GOUNfBPID_1501[] OrgUnitOfficeName { get; set; }
			[DataMember]
			public L5OU_GOUwWT_1346StandardTimes[] OrgUnitStandardWorkTime { get; set; }

			//Standard type parameters
		}
		#endregion
		#region SClass L5OU_GOUwWT_1346StandardTimes for attribute OrgUnitStandardWorkTime
		[DataContract]
		public class L5OU_GOUwWT_1346StandardTimes 
		{
			[DataMember]
			public L5OU_GSHfOID_1540[] StandardWorkTimes { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid CMN_STR_OfficeID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5OU_GOUwWT_1346 cls_Get_OrgUnits_with_WorkTimes_for_BusinessParticipantID(,P_L5OU_GOUwWT_1346 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5OU_GOUwWT_1346 invocationResult = cls_Get_OrgUnits_with_WorkTimes_for_BusinessParticipantID.Invoke(connectionString,P_L5OU_GOUwWT_1346 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_OrgUnits.Complex.Retrieval.P_L5OU_GOUwWT_1346();
parameter.BusinessParticipantID = ...;

*/
