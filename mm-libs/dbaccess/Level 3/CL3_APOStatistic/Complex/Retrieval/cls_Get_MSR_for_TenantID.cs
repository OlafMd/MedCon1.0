/* 
 * Generated on 10/13/2014 12:52:49 PM
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
using CL3_APOStatistic.Atomic.Retrieval;
using CL2_ApplicationSettings.Atomic.Retrieval;
using DLCore_DBCommons.Utils;
using DLCore_DBCommons.APODemand;

namespace CL3_APOStatistic.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_MSR_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_MSR_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3AS_GMSRfT_1215_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_L3AS_GMSRfT_1215_Array();

            const double defaultConsideredDays = 90;

            #region GetConsideredDays

            var consDaysParam = new P_L2AS_GTASfSK_1313()
            {
                TenantApplicationSettingsKey = EnumUtils.GetEnumDescription(EApplicationSettings.MonthlySalesTimeSpan)
            };

            var tenantAppSettings = cls_Get_Tenant_Application_Settings_for_SettingsKey.Invoke(Connection, Transaction, consDaysParam, securityTicket).Result;


            var consideredDays = defaultConsideredDays;

            if(tenantAppSettings != null)
            {
                double.TryParse(tenantAppSettings.DefaultValue,out consideredDays);
                double.TryParse(tenantAppSettings.ItemValue,out consideredDays);
            }

            #endregion


            #region Get_DailysalesOverall_for_TimePeriod

            P_L3AS_GDOfTP_1255 param = new P_L3AS_GDOfTP_1255();
            param.DateFrom = DateTime.Now.AddDays(-consideredDays);
            param.DateTo = DateTime.Now;

            var dailysalesOverall = cls_Get_DailysalesOverall_for_TimePeriod.Invoke(Connection, Transaction, param, securityTicket).Result.ToList();

            #endregion

            returnValue.Result = dailysalesOverall.Select(i => new L3AS_GMSRfT_1215()
            {
                MSR = Math.Round((i.OverallSoldQuantity / consideredDays) * 30, 1),
                ProductID = i.Product_RefID

            }).ToArray();

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3AS_GMSRfT_1215_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3AS_GMSRfT_1215_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3AS_GMSRfT_1215_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3AS_GMSRfT_1215_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3AS_GMSRfT_1215_Array functionReturn = new FR_L3AS_GMSRfT_1215_Array();
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

				throw new Exception("Exception occured in method cls_Get_MSR_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3AS_GMSRfT_1215_Array : FR_Base
	{
		public L3AS_GMSRfT_1215[] Result	{ get; set; } 
		public FR_L3AS_GMSRfT_1215_Array() : base() {}

		public FR_L3AS_GMSRfT_1215_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L3AS_GMSRfT_1215 for attribute L3AS_GMSRfT_1215
		[DataContract]
		public class L3AS_GMSRfT_1215 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProductID { get; set; } 
			[DataMember]
			public Double MSR { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3AS_GMSRfT_1215_Array cls_Get_MSR_for_TenantID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3AS_GMSRfT_1215_Array invocationResult = cls_Get_MSR_for_TenantID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

