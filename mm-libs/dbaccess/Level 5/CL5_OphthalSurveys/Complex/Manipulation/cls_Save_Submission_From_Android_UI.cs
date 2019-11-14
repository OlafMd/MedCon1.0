/* 
 * Generated on 9/2/2013 3:32:16 PM
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
using CL3_Doctors.Atomic.Retrieval;

namespace CL5_OphthalSurveys.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Submission_From_Android_UI.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Submission_From_Android_UI
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5OS_SSFA_1614 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
            //find tenant ID
            P_L3MD_GDDC_0928 param = new P_L3MD_GDDC_0928();
            param.DeviceCode = Parameter.AccountCode;
            var docResult = cls_Get_Doctor_by_DeviceCode.Invoke(Connection, Transaction, param);

            //TODO: handle!
            if (docResult == null)
            {

            }
            //retrive surveys
            P_L5OS_SSub_1641 paramForSubmission = new P_L5OS_SSub_1641();
            paramForSubmission.AccountID = docResult.Result.USR_AccountID;
            paramForSubmission.TenantID = docResult.Result.Tenant_RefID;
            paramForSubmission.HEC_DoctorID = docResult.Result.HEC_DoctorID;
            paramForSubmission.HEC_ShippingPosition_BarcodeLabelID = Parameter.HEC_ShippingPosition_BarcodeLabelID;
            paramForSubmission.LOG_SHP_Shipment_PositionID = Parameter.LOG_SHP_Shipment_PositionID;
            paramForSubmission.TemplateVersionID = Parameter.TemplateVersionID;
            paramForSubmission.answerPairs = Parameter.answerPairs;
            cls_Save_Submission.Invoke(Connection, Transaction, paramForSubmission);
            
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5OS_SSFA_1614 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5OS_SSFA_1614 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5OS_SSFA_1614 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5OS_SSFA_1614 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Guid functionReturn = new FR_Guid();
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

				throw new Exception("Exception occured in method cls_Save_Submission_From_Android_UI",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5OS_SSFA_1614 for attribute P_L5OS_SSFA_1614
		[DataContract]
		public class P_L5OS_SSFA_1614 
		{
			[DataMember]
			public P_L5OS_SSub_1641_AnswerPairs[] answerPairs { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid TemplateVersionID { get; set; } 
			[DataMember]
			public Guid HEC_ShippingPosition_BarcodeLabelID { get; set; } 
			[DataMember]
			public Guid LOG_SHP_Shipment_PositionID { get; set; } 
			[DataMember]
			public String AccountCode { get; set; } 

		}
		#endregion
		#region SClass P_L5OS_SSub_1641_AnswerPairs for attribute answerPairs
		[DataContract]
		public class P_L5OS_SSub_1641_AnswerPairs 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_QST_QuestionItem_EnumerationAnswerID { get; set; } 
			[DataMember]
			public Guid CMN_QST_Questionnaire_ItemID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Submission_From_Android_UI(,P_L5OS_SSFA_1614 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Submission_From_Android_UI.Invoke(connectionString,P_L5OS_SSFA_1614 Parameter,securityTicket);
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
var parameter = new CL5_OphthalSurveys.Complex.Manipulation.P_L5OS_SSFA_1614();
parameter.answerPairs = ...;

parameter.TemplateVersionID = ...;
parameter.HEC_ShippingPosition_BarcodeLabelID = ...;
parameter.LOG_SHP_Shipment_PositionID = ...;
parameter.AccountCode = ...;

*/
