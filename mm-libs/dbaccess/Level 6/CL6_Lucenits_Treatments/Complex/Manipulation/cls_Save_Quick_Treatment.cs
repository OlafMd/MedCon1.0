/* 
 * Generated on 9/20/2013 4:07:42 PM
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
using CL5_Lucentis_Treatments.Atomic.Manipulation;
using CL5_Lucentis_Patient.Complex.Manipulation;

namespace CL6_Lucenits_Treatments.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Quick_Treatment.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Quick_Treatment
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L6TR_SQT_1308 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            P_L6TR_SPT_1533 Treatment_Data = new P_L6TR_SPT_1533();
            Treatment_Data = Parameter.Treatment_Data;
            Guid TreatmentID = cls_Save_Patient_Treatment.Invoke(Connection, Transaction, Treatment_Data, securityTicket).Result;


            P_L5TR_STF_1712 FollowUp_Data = new  P_L5TR_STF_1712();
            FollowUp_Data = Parameter.Followups_Data;
            FollowUp_Data.IfTreatmentFollowup_FromTreatment_RefID = TreatmentID;
            cls_Save_Treatment_Followups.Invoke(Connection,Transaction,FollowUp_Data,securityTicket);

            P_L5PA_SP__1607 Patient_Main_Data = new P_L5PA_SP__1607();
            Patient_Main_Data = Parameter.Patient_Main_Data;
            cls_Save_Patient.Invoke(Connection, Transaction, Patient_Main_Data, securityTicket);

            P_L5TR_SRP_1317 ArticleParam = new P_L5TR_SRP_1317();
            foreach(var item in Parameter.Aticles.Products)
            {
                item.HEC_Patient_Treatment_RefID = TreatmentID;
            }

            ArticleParam = Parameter.Aticles;
            cls_Save_HEC_Patient_Treatment_RequiredProduct.Invoke(Connection, Transaction, ArticleParam, securityTicket);

            returnValue.Result = TreatmentID;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L6TR_SQT_1308 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L6TR_SQT_1308 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L6TR_SQT_1308 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6TR_SQT_1308 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Quick_Treatment",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L6TR_SQT_1308 for attribute P_L6TR_SQT_1308
		[DataContract]
		public class P_L6TR_SQT_1308 
		{
			//Standard type parameters
			[DataMember]
			public P_L6TR_SPT_1533 Treatment_Data { get; set; } 
			[DataMember]
			public P_L5PA_SP__1607 Patient_Main_Data { get; set; } 
			[DataMember]
			public P_L5TR_STF_1712 Followups_Data { get; set; } 
			[DataMember]
			public P_L5TR_SRP_1317 Aticles { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Quick_Treatment(,P_L6TR_SQT_1308 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Quick_Treatment.Invoke(connectionString,P_L6TR_SQT_1308 Parameter,securityTicket);
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
var parameter = new CL6_Lucenits_Treatments.Complex.Manipulation.P_L6TR_SQT_1308();
parameter.Treatment_Data = ...;
parameter.Patient_Main_Data = ...;
parameter.Followups_Data = ...;
parameter.Aticles = ...;

*/
