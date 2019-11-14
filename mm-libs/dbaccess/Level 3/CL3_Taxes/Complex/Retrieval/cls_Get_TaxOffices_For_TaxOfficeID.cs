/* 
 * Generated on 11/6/2013 10:11:17 AM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 * Required Assemblies:
 * System.Runtime.Serialization
 * CSV2Core
 * CSV2Core_MySQL
 */
using System;
using System.Data.Common;
using CSV2Core.Core;
using System.Runtime.Serialization;
using CL1_ACC_TAX;
using CL1_CMN_BPT;
using CL1_CMN_COM;
using CL3_Taxes.Atomic.Retrieval;
using CL1_CMN;

namespace CL3_Taxes.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_TaxOffices_For_TaxOfficeID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_TaxOffices_For_TaxOfficeID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3TX_GTOFTO_1006 Execute(DbConnection Connection,DbTransaction Transaction,P_L3TX_GTOFTO_1006 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L3TX_GTOFTO_1006();
            returnValue.Result = new L3TX_GTOFTO_1006();
            var item = new ORM_ACC_TAX_TaxOffice();
            returnValue.Result.TaxOffice = new L3TX_GTOFT_0914();
            var result = item.Load(Connection, Transaction, Parameter.ACC_TAX_TaxOfficeID);

            ORM_CMN_BPT_BusinessParticipant bparticipant = new ORM_CMN_BPT_BusinessParticipant();
            bparticipant.Load(Connection, Transaction, item.CMN_BPT_BusinessParticipant_RefID);
            returnValue.Result.TaxOffice.DisplayName = bparticipant.DisplayName;

            


            ORM_CMN_COM_CompanyInfo companyInfo = new ORM_CMN_COM_CompanyInfo();
            companyInfo.Load(Connection, Transaction, bparticipant.IfCompany_CMN_COM_CompanyInfo_RefID);

            ORM_CMN_UniversalContactDetail ucd = new ORM_CMN_UniversalContactDetail();
            ucd.Load(Connection, Transaction, companyInfo.Contact_UCD_RefID);

            returnValue.Result.TaxOffice.VATIdentificationNumber = companyInfo.VATIdentificationNumber;
            returnValue.Result.TaxOffice.ACC_TAX_TaxOfficeID = item.ACC_TAX_TaxOfficeID;
            returnValue.Result.TaxOffice.Country_639_1_ISOCode = ucd.Country_639_1_ISOCode;

			//Put your code here
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3TX_GTOFTO_1006 Invoke(string ConnectionString,P_L3TX_GTOFTO_1006 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3TX_GTOFTO_1006 Invoke(DbConnection Connection,P_L3TX_GTOFTO_1006 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3TX_GTOFTO_1006 Invoke(DbConnection Connection, DbTransaction Transaction,P_L3TX_GTOFTO_1006 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3TX_GTOFTO_1006 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3TX_GTOFTO_1006 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3TX_GTOFTO_1006 functionReturn = new FR_L3TX_GTOFTO_1006();
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

				throw new Exception("Exception occured in method cls_Get_TaxOffices_For_TaxOfficeID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3TX_GTOFTO_1006 : FR_Base
	{
		public L3TX_GTOFTO_1006 Result	{ get; set; }

		public FR_L3TX_GTOFTO_1006() : base() {}

		public FR_L3TX_GTOFTO_1006(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3TX_GTOFTO_1006 for attribute P_L3TX_GTOFTO_1006
		[DataContract]
		public class P_L3TX_GTOFTO_1006 
		{
			//Standard type parameters
			[DataMember]
			public Guid ACC_TAX_TaxOfficeID { get; set; } 

		}
		#endregion
		#region SClass L3TX_GTOFTO_1006 for attribute L3TX_GTOFTO_1006
		[DataContract]
		public class L3TX_GTOFTO_1006 
		{
			//Standard type parameters
			[DataMember]
			public L3TX_GTOFT_0914 TaxOffice { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3TX_GTOFTO_1006 cls_Get_TaxOffices_For_TaxOfficeID(,P_L3TX_GTOFTO_1006 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3TX_GTOFTO_1006 invocationResult = cls_Get_TaxOffices_For_TaxOfficeID.Invoke(connectionString,P_L3TX_GTOFTO_1006 Parameter,securityTicket);
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
var parameter = new CL3_Taxes.Complex.Retrieval.P_L3TX_GTOFTO_1006();
parameter.ACC_TAX_TaxOfficeID = ...;

*/