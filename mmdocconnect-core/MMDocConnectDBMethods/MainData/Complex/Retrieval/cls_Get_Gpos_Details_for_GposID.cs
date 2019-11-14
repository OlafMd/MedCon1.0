/* 
 * Generated on 10/21/15 15:55:39
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
using MMDocConnectDBMethods.MainData.Atomic.Retrieval;
using CL1_HEC_BIL;

namespace MMDocConnectDBMethods.MainData.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Gpos_Details_for_GposID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Gpos_Details_for_GposID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_MD_GGPOSDfGPOSID_1546 Execute(DbConnection Connection,DbTransaction Transaction,P_MD_GGPOSDfGPOSID_1546 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_MD_GGPOSDfGPOSID_1546();
            //Put your code here
            var gposBaseData = cls_Get_GPOS_BaseData_for_GPOSID.Invoke(Connection, Transaction, new P_MD_GGPOSBDfGPOSID_1544() { GposID = Parameter.GposID }, securityTicket).Result;
            if (gposBaseData != null)
            {
                returnValue.Result = new MD_GGPOSDfGPOSID_1546()
                {
                    FeeValue = gposBaseData.FeeValue,
                    FromInjection = gposBaseData.FromInjection,
                    GposID = gposBaseData.GposID,
                    GposName = gposBaseData.GposName,
                    GposNumber = gposBaseData.GposNumber,
                    GposType = gposBaseData.GposType,
                    ManagementFeeValue = gposBaseData.ManagementFeeValue,
                    WaiveWithOrder = gposBaseData.WaiveWithOrder,
                    DrugIDs = ORM_HEC_BIL_PotentialCode_2_HealthcareProduct.Query.Search(Connection, Transaction, new ORM_HEC_BIL_PotentialCode_2_HealthcareProduct.Query()
                    {
                        HEC_BIL_PotentialCode_RefID = Parameter.GposID,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).Select(cd => cd.HEC_Product_RefID).ToArray(),
                    DiagnoseIDs = ORM_HEC_BIL_PotentialCode_2_PotentialDiagnosis.Query.Search(Connection, Transaction, new ORM_HEC_BIL_PotentialCode_2_PotentialDiagnosis.Query()
                    {
                        HEC_BIL_PotentialCode_RefID = Parameter.GposID,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).Select(cd => cd.HEC_DIA_PotentialDiagnosis_RefID).ToArray()
                };
            }

            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_MD_GGPOSDfGPOSID_1546 Invoke(string ConnectionString,P_MD_GGPOSDfGPOSID_1546 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_MD_GGPOSDfGPOSID_1546 Invoke(DbConnection Connection,P_MD_GGPOSDfGPOSID_1546 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_MD_GGPOSDfGPOSID_1546 Invoke(DbConnection Connection, DbTransaction Transaction,P_MD_GGPOSDfGPOSID_1546 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_MD_GGPOSDfGPOSID_1546 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_MD_GGPOSDfGPOSID_1546 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_MD_GGPOSDfGPOSID_1546 functionReturn = new FR_MD_GGPOSDfGPOSID_1546();
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

				throw new Exception("Exception occured in method cls_Get_Gpos_Details_for_GposID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_MD_GGPOSDfGPOSID_1546 : FR_Base
	{
		public MD_GGPOSDfGPOSID_1546 Result	{ get; set; }

		public FR_MD_GGPOSDfGPOSID_1546() : base() {}

		public FR_MD_GGPOSDfGPOSID_1546(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_MD_GGPOSDfGPOSID_1546 for attribute P_MD_GGPOSDfGPOSID_1546
		[DataContract]
		public class P_MD_GGPOSDfGPOSID_1546 
		{
			//Standard type parameters
			[DataMember]
			public Guid GposID { get; set; } 

		}
		#endregion
		#region SClass MD_GGPOSDfGPOSID_1546 for attribute MD_GGPOSDfGPOSID_1546
		[DataContract]
		public class MD_GGPOSDfGPOSID_1546 
		{
			//Standard type parameters
			[DataMember]
			public Guid GposID { get; set; } 
			[DataMember]
			public String GposNumber { get; set; } 
			[DataMember]
			public String GposName { get; set; } 
			[DataMember]
			public String GposType { get; set; } 
			[DataMember]
			public Double FeeValue { get; set; } 
			[DataMember]
			public int FromInjection { get; set; } 
			[DataMember]
			public String ManagementFeeValue { get; set; } 
			[DataMember]
			public Boolean WaiveWithOrder { get; set; } 
			[DataMember]
			public Guid[] DrugIDs { get; set; } 
			[DataMember]
			public Guid[] DiagnoseIDs { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_MD_GGPOSDfGPOSID_1546 cls_Get_Gpos_Details_for_GposID(,P_MD_GGPOSDfGPOSID_1546 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_MD_GGPOSDfGPOSID_1546 invocationResult = cls_Get_Gpos_Details_for_GposID.Invoke(connectionString,P_MD_GGPOSDfGPOSID_1546 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.MainData.Complex.Retrieval.P_MD_GGPOSDfGPOSID_1546();
parameter.GposID = ...;

*/
