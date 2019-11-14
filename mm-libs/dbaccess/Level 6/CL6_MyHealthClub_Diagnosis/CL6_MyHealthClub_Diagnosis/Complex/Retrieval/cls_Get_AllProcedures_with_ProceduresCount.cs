/* 
 * Generated on 12/9/2014 1:33:13 PM
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
using CL5_MyHealthClub_Diagnosis.Atomic.Manipulation;

namespace CL6_MyHealthClub_Diagnosis.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_AllProcedures_with_ProceduresCount.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_AllProcedures_with_ProceduresCount
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6DI_GAPwPC_1329 Execute(DbConnection Connection,DbTransaction Transaction,P_L6DI_GAPwPC_1329 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_L6DI_GAPwPC_1329();

            returnValue.Result = new L6DI_GAPwPC_1329();
            List<L5DIGAPfTID_1318> procedureList = new List<L5DIGAPfTID_1318>();
            returnValue.Result.Procedures = procedureList.ToArray();
            returnValue.Result.CurrentPage = 1;
            returnValue.Result.NumberOfPages = 1;
            returnValue.Result.NumberOfElements = 0;
            /*@
             * 
             * Get procedures
             * ************************************/
            P_L5DIGAPfTID_1318 par = new P_L5DIGAPfTID_1318();
            if (Parameter.IsASC_Order == false)
                par.OrderBy = "DESC";
            else
                par.OrderBy = "ASC";
            par.OrderValue = Parameter.OrderValue;
            par.StartIndex = (Parameter.PageClicked - 1) * Parameter.NumberOfElementsPerPage;
            par.NumberOfElements = Parameter.NumberOfElementsPerPage;

            String searchCriterium = "";

            if (Parameter.Search_Param != null && Parameter.Search_Param != "")
                searchCriterium = " AND LOWER( hec_tre_potentialprocedure_catalogcodes.Code ) LIKE '%" + Parameter.Search_Param.ToLower() + "%' OR " +
                    " Lower(hec_tre_potentialprocedures_de.Content) Like '%" + Parameter.Search_Param.ToLower() + "%'";

            par.SearchCriterium = searchCriterium;
            par.CatalogID = Parameter.CatalogID;
            par.LanguageID = Parameter.LanguageID;
            returnValue.Result.Procedures = cls_Get_AllProcedures_for_TenantID.Invoke(Connection, Transaction, par, securityTicket).Result;
            /*@
             * 
             * Get procedures number
             * ************************************/
            P_L5DIGCoAP_1355 parameter = new P_L5DIGCoAP_1355();
            parameter.SearchCriterium = searchCriterium;
            parameter.CatalogID = Parameter.CatalogID;

            var value = cls_Get_Count_Of_AllProcedures.Invoke(Connection, Transaction, parameter, securityTicket).Result.FirstOrDefault();
            int numberOfElements = 0;
            if (value != null)
            {
                numberOfElements = value.NumberOfElements;
                returnValue.Result.NumberOfElements = value.NumberOfElements;
            }
            else
            {
                returnValue.Result.NumberOfElements = 0;
            }
            int pageCount = (numberOfElements + Parameter.NumberOfElementsPerPage - 1) / Parameter.NumberOfElementsPerPage;
            returnValue.Result.NumberOfPages = pageCount;
            returnValue.Result.CurrentPage = Parameter.PageClicked;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6DI_GAPwPC_1329 Invoke(string ConnectionString,P_L6DI_GAPwPC_1329 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6DI_GAPwPC_1329 Invoke(DbConnection Connection,P_L6DI_GAPwPC_1329 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6DI_GAPwPC_1329 Invoke(DbConnection Connection, DbTransaction Transaction,P_L6DI_GAPwPC_1329 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6DI_GAPwPC_1329 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6DI_GAPwPC_1329 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6DI_GAPwPC_1329 functionReturn = new FR_L6DI_GAPwPC_1329();
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

				throw new Exception("Exception occured in method cls_Get_AllProcedures_with_ProceduresCount",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6DI_GAPwPC_1329 : FR_Base
	{
		public L6DI_GAPwPC_1329 Result	{ get; set; }

		public FR_L6DI_GAPwPC_1329() : base() {}

		public FR_L6DI_GAPwPC_1329(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6DI_GAPwPC_1329 for attribute P_L6DI_GAPwPC_1329
		[DataContract]
		public class P_L6DI_GAPwPC_1329 
		{
			//Standard type parameters
			[DataMember]
			public bool IsASC_Order { get; set; } 
			[DataMember]
			public String OrderValue { get; set; } 
			[DataMember]
			public int PageClicked { get; set; } 
			[DataMember]
			public int NumberOfElementsPerPage { get; set; } 
			[DataMember]
			public String Search_Param { get; set; } 
			[DataMember]
			public Guid LanguageID { get; set; } 
			[DataMember]
			public Guid CatalogID { get; set; } 

		}
		#endregion
		#region SClass L6DI_GAPwPC_1329 for attribute L6DI_GAPwPC_1329
		[DataContract]
		public class L6DI_GAPwPC_1329 
		{
			//Standard type parameters
			[DataMember]
			public L5DIGAPfTID_1318[] Procedures { get; set; } 
			[DataMember]
			public int NumberOfPages { get; set; } 
			[DataMember]
			public int CurrentPage { get; set; } 
			[DataMember]
			public int NumberOfElements { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6DI_GAPwPC_1329 cls_Get_AllProcedures_with_ProceduresCount(,P_L6DI_GAPwPC_1329 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6DI_GAPwPC_1329 invocationResult = cls_Get_AllProcedures_with_ProceduresCount.Invoke(connectionString,P_L6DI_GAPwPC_1329 Parameter,securityTicket);
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
var parameter = new CL6_MyHealthClub_Diagnosis.Complex.Retrieval.P_L6DI_GAPwPC_1329();
parameter.IsASC_Order = ...;
parameter.OrderValue = ...;
parameter.PageClicked = ...;
parameter.NumberOfElementsPerPage = ...;
parameter.Search_Param = ...;
parameter.LanguageID = ...;
parameter.CatalogID = ...;

*/
