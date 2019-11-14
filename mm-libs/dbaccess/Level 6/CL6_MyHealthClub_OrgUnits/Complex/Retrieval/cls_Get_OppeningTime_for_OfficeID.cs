/* 
 * Generated on 9/10/2014 12:47:06 PM
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
using CL1_CMN_STR;

namespace CL6_MyHealthClub_OrgUnits.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_OppeningTime_for_OfficeID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_OppeningTime_for_OfficeID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6OU_GOTfOID_1544 Execute(DbConnection Connection,DbTransaction Transaction,P_L6OU_GOTfOID_1544 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L6OU_GOTfOID_1544();
            returnValue.Result = new L6OU_GOTfOID_1544();
            List<L5OU_GSHfOID_1540> StandardHours = new List<L5OU_GSHfOID_1540>();
            returnValue.Result.StandardHours = StandardHours.ToArray();
            List<L5OU_GNWTfOID_1506> NonWorkingTime = new List<L5OU_GNWTfOID_1506>();
            returnValue.Result.NonWorkingTime = NonWorkingTime.ToArray();

            returnValue.Result.Office_Name = ORM_CMN_STR_Office.Query.Search(Connection, Transaction, new ORM_CMN_STR_Office.Query
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                CMN_STR_OfficeID = Parameter.OfficeID
            }).Select(x => x.Office_Name).Single();

            returnValue.Result.StandardHours = cls_Get_StandardHours_for_OfficeID.Invoke(Connection, Transaction, new P_L5OU_GSHfOID_1540 { OfficeID = Parameter.OfficeID },securityTicket).Result;
            returnValue.Result.NonWorkingTime = cls_Get_NonWorkingTimesforOfficeID.Invoke(Connection, Transaction, new P_L5OU_GNWTfOID_1506 { OfficeID = Parameter.OfficeID }, securityTicket).Result;
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6OU_GOTfOID_1544 Invoke(string ConnectionString,P_L6OU_GOTfOID_1544 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6OU_GOTfOID_1544 Invoke(DbConnection Connection,P_L6OU_GOTfOID_1544 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6OU_GOTfOID_1544 Invoke(DbConnection Connection, DbTransaction Transaction,P_L6OU_GOTfOID_1544 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6OU_GOTfOID_1544 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6OU_GOTfOID_1544 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6OU_GOTfOID_1544 functionReturn = new FR_L6OU_GOTfOID_1544();
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

				throw new Exception("Exception occured in method cls_Get_OppeningTime_for_OfficeID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6OU_GOTfOID_1544 : FR_Base
	{
		public L6OU_GOTfOID_1544 Result	{ get; set; }

		public FR_L6OU_GOTfOID_1544() : base() {}

		public FR_L6OU_GOTfOID_1544(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6OU_GOTfOID_1544 for attribute P_L6OU_GOTfOID_1544
		[DataContract]
		public class P_L6OU_GOTfOID_1544 
		{
			//Standard type parameters
			[DataMember]
			public Guid OfficeID { get; set; } 

		}
		#endregion
		#region SClass L6OU_GOTfOID_1544 for attribute L6OU_GOTfOID_1544
		[DataContract]
		public class L6OU_GOTfOID_1544 
		{
			//Standard type parameters
			[DataMember]
			public L5OU_GSHfOID_1540[] StandardHours { get; set; } 
			[DataMember]
			public L5OU_GNWTfOID_1506[] NonWorkingTime { get; set; } 
			[DataMember]
			public Dict Office_Name { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6OU_GOTfOID_1544 cls_Get_OppeningTime_for_OfficeID(,P_L6OU_GOTfOID_1544 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6OU_GOTfOID_1544 invocationResult = cls_Get_OppeningTime_for_OfficeID.Invoke(connectionString,P_L6OU_GOTfOID_1544 Parameter,securityTicket);
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
var parameter = new CL6_MyHealthClub_OrgUnits.Complex.Retrieval.P_L6OU_GOTfOID_1544();
parameter.OfficeID = ...;

*/
