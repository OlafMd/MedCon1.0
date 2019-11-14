/* 
 * Generated on 8/30/2013 10:32:39 AM
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
using CL5_OphthalSurveys.Atomic.Retrieval;
using CL3_Doctors.Atomic.Retrieval;

namespace CL5_OphthalSurveys.Complex.Retrieval
{
	/// <summary>
    /// No description found in <meta/> tag
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_SurveyForShippedProduct_For_Android_UI.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_SurveyForShippedProduct_For_Android_UI
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5OS_GSFSPDAUI_1800 Execute(DbConnection Connection,DbTransaction Transaction,P_L5OS_GSFSPDAUI_1800 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5OS_GSFSPDAUI_1800();
            //Put your code here

            L5OS_GSFSPD_1315[] allSurveys = null;
            //find tenant ID
            P_L3MD_GDDC_0928 param = new P_L3MD_GDDC_0928();
            param.DeviceCode = Parameter.AccountCode;
            var docResult = cls_Get_Doctor_by_DeviceCode.Invoke(Connection, Transaction, param);

            //TODO: handle!
            if (docResult != null)
            {
                //P_L3AC_SACUH_1003 historyParam = new P_L3AC_SACUH_1003();
                //historyParam.Device_AccountCodeID = docResult.USR_Device_AccountCodeID;
                //historyParam.TenantID = docResult.Tenant_RefID;
                //historyParam.UsedBy_BrowserAgent = UsedBy_BrowserAgent;
                //historyParam.UsedBy_ExternalAddress = UsedBy_ExternalAddress;
                //cls_Save_USR_AccountCode_UsageHistory.Invoke(connectionString, historyParam);
            }

            //retrive surveys
            P_L5OS_GSFSPD_1315 paramForSurvey = new P_L5OS_GSFSPD_1315();
            paramForSurvey.HEC_DoctorID = docResult.Result.HEC_DoctorID;
            paramForSurvey.TenantID = docResult.Result.Tenant_RefID;
            allSurveys = cls_Get_SurveyForShippedProduct_by_DocID.Invoke(Connection, Transaction, paramForSurvey).Result;

            List<L5OS_GSFSPD_1315> rv = new List<L5OS_GSFSPD_1315>();

            foreach (var barcodeValue in Parameter.QrCodeValues)
            {
                L5OS_GSFSPD_1315[] applicableQuestions = allSurveys.Where(a => a.ShippingPosition_BarcodeLabel == barcodeValue).ToArray();

                rv.AddRange(applicableQuestions);
            }

            returnValue.Result = new L5OS_GSFSPDAUI_1800();
            returnValue.Result.Surveys = rv.ToArray();

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5OS_GSFSPDAUI_1800 Invoke(string ConnectionString,P_L5OS_GSFSPDAUI_1800 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5OS_GSFSPDAUI_1800 Invoke(DbConnection Connection,P_L5OS_GSFSPDAUI_1800 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5OS_GSFSPDAUI_1800 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5OS_GSFSPDAUI_1800 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5OS_GSFSPDAUI_1800 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5OS_GSFSPDAUI_1800 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5OS_GSFSPDAUI_1800 functionReturn = new FR_L5OS_GSFSPDAUI_1800();
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

				throw new Exception("Exception occured in method cls_Get_SurveyForShippedProduct_For_Android_UI",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5OS_GSFSPDAUI_1800 : FR_Base
	{
		public L5OS_GSFSPDAUI_1800 Result	{ get; set; }

		public FR_L5OS_GSFSPDAUI_1800() : base() {}

		public FR_L5OS_GSFSPDAUI_1800(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5OS_GSFSPDAUI_1800 for attribute P_L5OS_GSFSPDAUI_1800
		[DataContract]
		public class P_L5OS_GSFSPDAUI_1800 
		{
			//Standard type parameters
			[DataMember]
			public String AccountCode { get; set; } 
			[DataMember]
			public String[] QrCodeValues { get; set; } 

		}
		#endregion
		#region SClass L5OS_GSFSPDAUI_1800 for attribute L5OS_GSFSPDAUI_1800
		[DataContract]
		public class L5OS_GSFSPDAUI_1800 
		{
			//Standard type parameters
			[DataMember]
			public L5OS_GSFSPD_1315[] Surveys { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5OS_GSFSPDAUI_1800 cls_Get_SurveyForShippedProduct_For_Android_UI(,P_L5OS_GSFSPDAUI_1800 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5OS_GSFSPDAUI_1800 invocationResult = cls_Get_SurveyForShippedProduct_For_Android_UI.Invoke(connectionString,P_L5OS_GSFSPDAUI_1800 Parameter,securityTicket);
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
var parameter = new CL5_OphthalSurveys.Complex.Retrieval.P_L5OS_GSFSPDAUI_1800();
parameter.AccountCode = ...;
parameter.QrCodeValues = ...;

*/
