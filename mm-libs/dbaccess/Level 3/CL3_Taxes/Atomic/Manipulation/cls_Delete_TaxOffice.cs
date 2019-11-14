/* 
 * Generated on 11/6/2013 11:50:55 AM
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
using CSV2Core.Core;
using System.Runtime.Serialization;
using CL1_CMN_COM;
using CL1_CMN_BPT;
using CL1_ACC_TAX;

namespace CL3_Taxes.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Delete_TaxOffice.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Delete_TaxOffice
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Base Execute(DbConnection Connection,DbTransaction Transaction,P_L3TX_DTO_1148 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Base();

            ORM_ACC_TAX_TaxOffice taxOffice = new ORM_ACC_TAX_TaxOffice();

            if (Parameter.ACC_TAX_TaxOfficeID != Guid.Empty)
            {
                var result = taxOffice.Load(Connection, Transaction, Parameter.ACC_TAX_TaxOfficeID);
                if (result.Status != FR_Status.Success || taxOffice.ACC_TAX_TaxOfficeID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID.";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }
            
            taxOffice.IsDeleted = true;
            taxOffice.Save(Connection, Transaction);

            ORM_CMN_BPT_BusinessParticipant.Query bptQuery = new ORM_CMN_BPT_BusinessParticipant.Query();
            bptQuery.CMN_BPT_BusinessParticipantID = taxOffice.CMN_BPT_BusinessParticipant_RefID;
            bptQuery.IsDeleted = false;
            bptQuery.Tenant_RefID = securityTicket.TenantID;

            ORM_CMN_BPT_BusinessParticipant bparticipant = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, bptQuery).FirstOrDefault();
            bparticipant.IsDeleted = true;
            bparticipant.Save(Connection, Transaction);

            ORM_CMN_COM_CompanyInfo.Query cmpInfoQuery = new ORM_CMN_COM_CompanyInfo.Query();
            cmpInfoQuery.CMN_COM_CompanyInfoID = bparticipant.IfCompany_CMN_COM_CompanyInfo_RefID;
            cmpInfoQuery.IsDeleted = false;
            cmpInfoQuery.Tenant_RefID = securityTicket.TenantID;

            ORM_CMN_COM_CompanyInfo companyInfo = ORM_CMN_COM_CompanyInfo.Query.Search(Connection, Transaction, cmpInfoQuery).FirstOrDefault();           
            companyInfo.IsDeleted = true;
            companyInfo.Save(Connection, Transaction);

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Base Invoke(string ConnectionString,P_L3TX_DTO_1148 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection,P_L3TX_DTO_1148 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction,P_L3TX_DTO_1148 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3TX_DTO_1148 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Base functionReturn = new FR_Base();
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

				throw new Exception("Exception occured in method cls_Delete_TaxOffice",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3TX_DTO_1148 for attribute P_L3TX_DTO_1148
		[DataContract]
		public class P_L3TX_DTO_1148 
		{
			//Standard type parameters
			[DataMember]
			public Guid ACC_TAX_TaxOfficeID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Base cls_Delete_TaxOffice(,P_L3TX_DTO_1148 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Base invocationResult = cls_Delete_TaxOffice.Invoke(connectionString,P_L3TX_DTO_1148 Parameter,securityTicket);
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
var parameter = new CL3_Taxes.Atomic.Manipulation.P_L3TX_DTO_1148();
parameter.ACC_TAX_TaxOfficeID = ...;

*/