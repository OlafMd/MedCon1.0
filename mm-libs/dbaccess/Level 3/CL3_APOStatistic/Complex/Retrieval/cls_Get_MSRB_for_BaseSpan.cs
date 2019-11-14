/* 
 * Generated on 10/13/2014 2:04:43 PM
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

namespace CL3_APOStatistic.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_MSRB_for_BaseSpan.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_MSRB_for_BaseSpan
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3AS_GMSRfBS_1404_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3AS_GMSRfBS_1404 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_L3AS_GMSRfBS_1404_Array();

            #region Get_DailysalesOverall_for_TimePeriod

            P_L3AS_GDOfTP_1255 param = new P_L3AS_GDOfTP_1255();
            param.DateFrom = Parameter.StartDate;
            param.DateTo = Parameter.EndDate;

            var dailysalesOverall = cls_Get_DailysalesOverall_for_TimePeriod.Invoke(Connection, Transaction, param, securityTicket).Result.ToList();

            #endregion

            // 22.10.2014. - 01.10.2014  = 21days, we have to add 1 because we have to include both days
            var daysInBaseTimeSpan = (Parameter.EndDate - Parameter.StartDate).Days + 1; 

            returnValue.Result = dailysalesOverall.Select(i => new L3AS_GMSRfBS_1404()
            {
                MSRB = Math.Round((i.OverallSoldQuantity / daysInBaseTimeSpan) * 30, 1),
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
		public static FR_L3AS_GMSRfBS_1404_Array Invoke(string ConnectionString,P_L3AS_GMSRfBS_1404 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3AS_GMSRfBS_1404_Array Invoke(DbConnection Connection,P_L3AS_GMSRfBS_1404 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3AS_GMSRfBS_1404_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3AS_GMSRfBS_1404 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3AS_GMSRfBS_1404_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3AS_GMSRfBS_1404 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3AS_GMSRfBS_1404_Array functionReturn = new FR_L3AS_GMSRfBS_1404_Array();
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

				throw new Exception("Exception occured in method cls_Get_MSRB_for_BaseSpan",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3AS_GMSRfBS_1404_Array : FR_Base
	{
		public L3AS_GMSRfBS_1404[] Result	{ get; set; } 
		public FR_L3AS_GMSRfBS_1404_Array() : base() {}

		public FR_L3AS_GMSRfBS_1404_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3AS_GMSRfBS_1404 for attribute P_L3AS_GMSRfBS_1404
		[DataContract]
		public class P_L3AS_GMSRfBS_1404 
		{
			//Standard type parameters
			[DataMember]
			public DateTime EndDate { get; set; } 
			[DataMember]
			public DateTime StartDate { get; set; } 

		}
		#endregion
		#region SClass L3AS_GMSRfBS_1404 for attribute L3AS_GMSRfBS_1404
		[DataContract]
		public class L3AS_GMSRfBS_1404 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProductID { get; set; } 
			[DataMember]
			public Double MSRB { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3AS_GMSRfBS_1404_Array cls_Get_MSRB_for_BaseSpan(,P_L3AS_GMSRfBS_1404 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3AS_GMSRfBS_1404_Array invocationResult = cls_Get_MSRB_for_BaseSpan.Invoke(connectionString,P_L3AS_GMSRfBS_1404 Parameter,securityTicket);
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
var parameter = new CL3_APOStatistic.Complex.Retrieval.P_L3AS_GMSRfBS_1404();
parameter.EndDate = ...;
parameter.StartDate = ...;

*/
