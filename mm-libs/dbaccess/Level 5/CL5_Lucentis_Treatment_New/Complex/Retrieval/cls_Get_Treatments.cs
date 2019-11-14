/* 
 * Generated on 12/8/2014 10:49:47 AM
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
using CL5_Lucentis_Treatment_New.Atomic.Retrieval;
using CL5_Lucentis_Treatment_New.Utils;

namespace CL5_Lucentis_Treatment_New.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Treatments.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Treatments
	{
		public static readonly int QueryTimeout = 6000;

		#region Method Execution
		protected static FR_L5TR_GT_1748 Execute(DbConnection Connection,DbTransaction Transaction,P_L5TR_GT_1748 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_L5TR_GT_1748();
            returnValue.Result = new L5TR_GT_1748();
            int IsBilled = Parameter.SearchParameters.s_isBilled == true ? 1 : 0;
            int IsPerformed = Parameter.SearchParameters.s_isPerformed == true ? 1 : 0;
            int IsSheduled = Parameter.SearchParameters.s_isScheduled == true ? 1 : 0;

            returnValue.Result.page_size = Parameter.NumberOfElementsPerPage;
            returnValue.Result.current_page = Parameter.PageClicked;

            P_L5TR_GTDC_1426 count_param = new P_L5TR_GTDC_1426();
            count_param.S_Practice = SearchMethods.getPracticeParameter(Parameter.SearchParameters.s_practice);
            count_param.statusParameters = SearchMethods.getStatusParameter(IsBilled, IsPerformed, IsSheduled, Parameter.SearchParameters.s_treatmentFrom, Parameter.SearchParameters.s_treatmentTo);
            count_param.s_Patient = SearchMethods.getPatientParameter(Parameter.SearchParameters.s_patientFirstName, Parameter.SearchParameters.s_patientLastName);
            count_param.s_HealthInsurance = SearchMethods.getPracticeParameter(Parameter.SearchParameters.s_healtInsurance);
             
            var recordCount = cls_Get_TreatmentlDataCount.Invoke(Connection, Transaction, count_param, securityTicket).Result.total_record_count;
            returnValue.Result.total_record_count = recordCount;
            returnValue.Result.total_page_count = (recordCount + Parameter.NumberOfElementsPerPage - 1) / Parameter.NumberOfElementsPerPage;
            var startRowIndex = (Parameter.PageClicked - 1) * Parameter.NumberOfElementsPerPage;
            returnValue.Result.start_row_index = startRowIndex;
            returnValue.Result.end_row_index = startRowIndex + returnValue.Result.page_size > recordCount ? recordCount : startRowIndex + returnValue.Result.page_size;


            /*@Get Treatments
               *------------------------------------------------*/
            P_L5TR_GTD_1607 par = new P_L5TR_GTD_1607();
            par.StartIndex = startRowIndex;
            par.NumberOfElements = Parameter.NumberOfElementsPerPage;
            par.S_Practice = count_param.S_Practice;
            par.statusParameters = count_param.statusParameters;
            par.s_Patient = count_param.s_Patient;
            par.s_HealthInsurance = count_param.s_HealthInsurance;

            returnValue.Result.treatments = cls_Get_TreatmentlData.Invoke(Connection, Transaction, par, securityTicket).Result.ToArray();

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5TR_GT_1748 Invoke(string ConnectionString,P_L5TR_GT_1748 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5TR_GT_1748 Invoke(DbConnection Connection,P_L5TR_GT_1748 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5TR_GT_1748 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5TR_GT_1748 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5TR_GT_1748 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5TR_GT_1748 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5TR_GT_1748 functionReturn = new FR_L5TR_GT_1748();
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

				throw new Exception("Exception occured in method cls_Get_Treatments",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5TR_GT_1748 : FR_Base
	{
		public L5TR_GT_1748 Result	{ get; set; }

		public FR_L5TR_GT_1748() : base() {}

		public FR_L5TR_GT_1748(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5TR_GT_1748 for attribute P_L5TR_GT_1748
		[DataContract]
		public class P_L5TR_GT_1748 
		{
			[DataMember]
			public P_L5TR_GT_1748_SearchParams SearchParameters { get; set; }

			//Standard type parameters
			[DataMember]
			public int PageClicked { get; set; } 
			[DataMember]
			public int NumberOfElementsPerPage { get; set; } 

		}
		#endregion
		#region SClass P_L5TR_GT_1748_SearchParams for attribute SearchParameters
		[DataContract]
		public class P_L5TR_GT_1748_SearchParams 
		{
			//Standard type parameters
			[DataMember]
			public String s_practice { get; set; } 
			[DataMember]
			public String s_treatmentFrom { get; set; } 
			[DataMember]
			public String s_treatmentTo { get; set; } 
			[DataMember]
			public bool s_isScheduled { get; set; } 
			[DataMember]
			public bool s_isPerformed { get; set; } 
			[DataMember]
			public bool s_isBilled { get; set; } 
			[DataMember]
			public String s_patientFirstName { get; set; } 
			[DataMember]
			public String s_patientLastName { get; set; } 
			[DataMember]
			public String s_healtInsurance { get; set; } 

		}
		#endregion
		#region SClass L5TR_GT_1748 for attribute L5TR_GT_1748
		[DataContract]
		public class L5TR_GT_1748 
		{
			//Standard type parameters
			[DataMember]
			public L5TR_GTD_1607[] treatments { get; set; } 
			[DataMember]
			public int start_row_index { get; set; } 
			[DataMember]
			public int end_row_index { get; set; } 
			[DataMember]
			public int page_size { get; set; } 
			[DataMember]
			public int current_page { get; set; } 
			[DataMember]
			public int total_page_count { get; set; } 
			[DataMember]
			public int total_record_count { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5TR_GT_1748 cls_Get_Treatments(,P_L5TR_GT_1748 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5TR_GT_1748 invocationResult = cls_Get_Treatments.Invoke(connectionString,P_L5TR_GT_1748 Parameter,securityTicket);
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
var parameter = new CL5_Lucentis_Treatment_New.Complex.Retrieval.P_L5TR_GT_1748();
parameter.SearchParameters = ...;

parameter.PageClicked = ...;
parameter.NumberOfElementsPerPage = ...;

*/
