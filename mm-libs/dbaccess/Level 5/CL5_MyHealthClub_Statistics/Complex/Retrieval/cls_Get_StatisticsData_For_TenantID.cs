/* 
 * Generated on 13.03.2015 15:16:19
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
using CL1_HEC_CMT;

namespace CL5_MyHealthClub_EMR.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_StatisticsData_For_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_StatisticsData_For_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5MS_GSDfTID_1555 Execute(DbConnection Connection,DbTransaction Transaction,P_L5MS_GSDfTID_1555 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_L5MS_GSDfTID_1555();

            var community = ORM_HEC_CMT_Community.Query.Search(Connection, Transaction, new ORM_HEC_CMT_Community.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                IsCommunityOperatedByThisTenant = true
            }).Single();

            var groups = ORM_HEC_CMT_CommunityGroup.Query.Search(Connection, Transaction, new ORM_HEC_CMT_CommunityGroup.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).ToArray();


			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5MS_GSDfTID_1555 Invoke(string ConnectionString,P_L5MS_GSDfTID_1555 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5MS_GSDfTID_1555 Invoke(DbConnection Connection,P_L5MS_GSDfTID_1555 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5MS_GSDfTID_1555 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5MS_GSDfTID_1555 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5MS_GSDfTID_1555 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5MS_GSDfTID_1555 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5MS_GSDfTID_1555 functionReturn = new FR_L5MS_GSDfTID_1555();
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

				throw new Exception("Exception occured in method cls_Get_StatisticsData_For_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5MS_GSDfTID_1555 : FR_Base
	{
		public L5MS_GSDfTID_1555 Result	{ get; set; }

		public FR_L5MS_GSDfTID_1555() : base() {}

		public FR_L5MS_GSDfTID_1555(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5MS_GSDfTID_1555 for attribute P_L5MS_GSDfTID_1555
		[DataContract]
		public class P_L5MS_GSDfTID_1555 
		{
			//Standard type parameters
			[DataMember]
			public Guid PatientID { get; set; } 

		}
		#endregion
		#region SClass L5MS_GSDfTID_1555 for attribute L5MS_GSDfTID_1555
		[DataContract]
		public class L5MS_GSDfTID_1555 
		{
			[DataMember]
			public L5MS_GSDfTID_1555_Group[] Groups { get; set; }

			//Standard type parameters
		}
		#endregion
		#region SClass L5MS_GSDfTID_1555_Group for attribute Groups
		[DataContract]
		public class L5MS_GSDfTID_1555_Group 
		{
			[DataMember]
			public L5MS_GSDfTID_1555_Group_Member[] Members { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid GroupITL { get; set; } 

		}
		#endregion
		#region SClass L5MS_GSDfTID_1555_Group_Member for attribute Members
		[DataContract]
		public class L5MS_GSDfTID_1555_Group_Member 
		{
			[DataMember]
			public L5MS_GSDfTID_1555_Group_Member_Diagnosis[] Diagnoses { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid MemberITL { get; set; } 

		}
		#endregion
		#region SClass L5MS_GSDfTID_1555_Group_Member_Diagnosis for attribute Diagnoses
		[DataContract]
		public class L5MS_GSDfTID_1555_Group_Member_Diagnosis 
		{
			//Standard type parameters
			[DataMember]
			public Guid DiagnosisITL { get; set; } 
			[DataMember]
			public int NumberOfOccurences { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5MS_GSDfTID_1555 cls_Get_StatisticsData_For_TenantID(,P_L5MS_GSDfTID_1555 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5MS_GSDfTID_1555 invocationResult = cls_Get_StatisticsData_For_TenantID.Invoke(connectionString,P_L5MS_GSDfTID_1555 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_EMR.Complex.Retrieval.P_L5MS_GSDfTID_1555();
parameter.PatientID = ...;

*/
