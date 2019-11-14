/* 
 * Generated on 08.02.2014 14:02:32
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
using System.IO;
using CL6_Lucenits_Treatments.Utils;
using CL6_Lucenits_Treatments.Complex.Retrieval;

namespace CL6_Lucenits_Treatments.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_MakeReportData_forTreatmentsReport2.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_MakeReportData_forTreatmentsReport2
	{
		public static readonly int QueryTimeout = 6000;

		#region Method Execution
		protected static FR_L6TR_MRDfTR2_2310 Execute(DbConnection Connection,DbTransaction Transaction,P_L6TR_MRDfTR2_2310 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_L6TR_MRDfTR2_2310();
            returnValue.Result = new L6TR_MRDfTR2_2310();
            P_L6TR_GTI_fTR_1816 param = new P_L6TR_GTI_fTR_1816()
            {
                LanguageID = Parameter.LanguageID,
                fromDate = Parameter.fromDate,
                toDate = Parameter.toDate,
                statusFilter = Parameter.statusFilter
            };
            var data = cls_Get_TreatmentsInfo_for_TimeRange.Invoke(Connection, Transaction, param, securityTicket).Result;
            string file = ReportUtils.generateReport2SheetXLS(data);
            returnValue.Result.stream = new MemoryStream(File.ReadAllBytes(file));
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6TR_MRDfTR2_2310 Invoke(string ConnectionString,P_L6TR_MRDfTR2_2310 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6TR_MRDfTR2_2310 Invoke(DbConnection Connection,P_L6TR_MRDfTR2_2310 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6TR_MRDfTR2_2310 Invoke(DbConnection Connection, DbTransaction Transaction,P_L6TR_MRDfTR2_2310 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6TR_MRDfTR2_2310 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6TR_MRDfTR2_2310 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6TR_MRDfTR2_2310 functionReturn = new FR_L6TR_MRDfTR2_2310();
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

				throw new Exception("Exception occured in method cls_MakeReportData_forTreatmentsReport2",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6TR_MRDfTR2_2310 : FR_Base
	{
		public L6TR_MRDfTR2_2310 Result	{ get; set; }

		public FR_L6TR_MRDfTR2_2310() : base() {}

		public FR_L6TR_MRDfTR2_2310(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6TR_MRDfTR2_2310 for attribute P_L6TR_MRDfTR2_2310
		[DataContract]
		public class P_L6TR_MRDfTR2_2310 
		{
			//Standard type parameters
			[DataMember]
			public Guid LanguageID { get; set; } 
			[DataMember]
			public DateTime fromDate { get; set; } 
			[DataMember]
			public DateTime toDate { get; set; } 
			[DataMember]
			public int[] statusFilter { get; set; } 

		}
		#endregion
		#region SClass L6TR_MRDfTR2_2310 for attribute L6TR_MRDfTR2_2310
		[DataContract]
		public class L6TR_MRDfTR2_2310 
		{
			//Standard type parameters
			[DataMember]
			public MemoryStream stream { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6TR_MRDfTR2_2310 cls_MakeReportData_forTreatmentsReport2(,P_L6TR_MRDfTR2_2310 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6TR_MRDfTR2_2310 invocationResult = cls_MakeReportData_forTreatmentsReport2.Invoke(connectionString,P_L6TR_MRDfTR2_2310 Parameter,securityTicket);
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
var parameter = new CL6_Lucenits_Treatments.Complex.Manipulation.P_L6TR_MRDfTR2_2310();
parameter.LanguageID = ...;
parameter.fromDate = ...;
parameter.toDate = ...;
parameter.statusFilter = ...;

*/
