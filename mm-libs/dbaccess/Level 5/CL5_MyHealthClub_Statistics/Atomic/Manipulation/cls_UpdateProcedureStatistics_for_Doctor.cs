/* 
 * Generated on 20.02.2015 15:19:23
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
using CL1_HEC_DIA_STA;

namespace CL5_MyHealthClub_Statistics.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_UpdateProcedureStatistics_for_Doctor.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_UpdateProcedureStatistics_for_Doctor
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Int Execute(DbConnection Connection,DbTransaction Transaction,P_L5ST_UPSfD_1508 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Int();

            var statistics = ORM_HEC_DIA_STA_Procedure_UsageStatistic.Query.Search(Connection, Transaction, new ORM_HEC_DIA_STA_Procedure_UsageStatistic.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                IfStatistics_ForDoctor_Doctor_RefID = Parameter.DoctorID,
                IsStatistics_ForDoctor = true,
                PotentialProcedure_RefID = Parameter.PotentialProcedureID
            }).SingleOrDefault();

            if (statistics == null)
            {
                if (Parameter.IsCorrection)
                    return returnValue;

                statistics = new ORM_HEC_DIA_STA_Procedure_UsageStatistic()
                {
                    HEC_DIA_STA_Procedure_UsageStatisticsID = Guid.NewGuid(),
                    Tenant_RefID = securityTicket.TenantID,
                    IsStatistics_ForDoctor = true,
                    IfStatistics_ForDoctor_Doctor_RefID = Parameter.DoctorID,
                    PotentialProcedure_RefID = Parameter.PotentialProcedureID,
                    StatisticsPeriod_From = DateTime.Now,
                    IsLatestStatisticsData = true
                };
            }

            if (Parameter.IsCorrection)
                statistics.NumberOfOccurences -= 1;
            else
                statistics.NumberOfOccurences += 1;
            statistics.StatisticsPeriod_Through = DateTime.Now;
            statistics.Modification_Timestamp = DateTime.Now;
            statistics.Save(Connection, Transaction);

            returnValue.Result = statistics.NumberOfOccurences;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Int Invoke(string ConnectionString,P_L5ST_UPSfD_1508 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Int Invoke(DbConnection Connection,P_L5ST_UPSfD_1508 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Int Invoke(DbConnection Connection, DbTransaction Transaction,P_L5ST_UPSfD_1508 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Int Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5ST_UPSfD_1508 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Int functionReturn = new FR_Int();
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

				throw new Exception("Exception occured in method cls_UpdateProcedureStatistics_for_Doctor",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5ST_UPSfD_1508 for attribute P_L5ST_UPSfD_1508
		[DataContract]
		public class P_L5ST_UPSfD_1508 
		{
			//Standard type parameters
			[DataMember]
			public Guid DoctorID { get; set; } 
			[DataMember]
			public Guid PotentialProcedureID { get; set; } 
			[DataMember]
			public bool IsCorrection { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Int cls_UpdateProcedureStatistics_for_Doctor(,P_L5ST_UPSfD_1508 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Int invocationResult = cls_UpdateProcedureStatistics_for_Doctor.Invoke(connectionString,P_L5ST_UPSfD_1508 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_Statistics.Atomic.Manipulation.P_L5ST_UPSfD_1508();
parameter.DoctorID = ...;
parameter.PotentialProcedureID = ...;
parameter.IsCorrection = ...;

*/
