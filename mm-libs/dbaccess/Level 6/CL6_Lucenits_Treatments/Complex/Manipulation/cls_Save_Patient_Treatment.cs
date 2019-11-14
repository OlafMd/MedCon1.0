/* 
 * Generated on 7/8/2013 11:51:17 AM
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
using CL5_Lucentis_Diagnosis.Atomic.Manipulation;

namespace CL6_Lucenits_Treatments.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Patient_Treatment.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Patient_Treatment
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L6TR_SPT_1533 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_Guid();

            var TreatmentID = cls_Save_HEC_Patient_Treatment.Invoke(Connection, Transaction, Parameter.Treatment, securityTicket).Result;

            foreach (var param in Parameter.Diagnosis)
            {

                param.Patient_Treatment_RefID = TreatmentID;

                cls_Save_HEC_Patient_Treatment_RelevantDiagnosis.Invoke(Connection, Transaction, param, securityTicket);

            }

            if (Parameter.Aticles.Products == null)
            {
                Parameter.Aticles.Products = new List<P_L5TR_SRP_1317a>().ToArray();
            }
                

            cls_Save_HEC_Patient_Treatment_RequiredProduct.Invoke(Connection, Transaction, Parameter.Aticles, securityTicket);

            if (Parameter.Followups == null)
                Parameter.Followups = new List<P_L5TR_STF_1712>().ToArray();

            foreach (var param2 in Parameter.Followups) {

                param2.IfTreatmentFollowup_FromTreatment_RefID = TreatmentID;

                cls_Save_Treatment_Followups.Invoke(Connection, Transaction, param2, securityTicket);
            
            }

            returnValue.Result = TreatmentID;

            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L6TR_SPT_1533 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L6TR_SPT_1533 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L6TR_SPT_1533 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6TR_SPT_1533 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw ex;
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L6TR_SPT_1533 for attribute P_L6TR_SPT_1533
		[DataContract]
		public class P_L6TR_SPT_1533 
		{
			//Standard type parameters
			[DataMember]
			public P_L5TR_SPT_1407 Treatment { get; set; } 
			[DataMember]
			public P_L5DG_SPTRD_1501[] Diagnosis { get; set; } 
			[DataMember]
			public P_L5TR_SRP_1317 Aticles { get; set; } 
			[DataMember]
			public P_L5TR_STF_1712[] Followups { get; set; } 

		}
		#endregion

	#endregion
}
