/* 
 * Generated on 06/30/15 17:34:19
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
using CL1_CMN;
using DataImporter.DBMethods.Patient.Atomic.Retrieval;
using DataImporter.DBMethods.ExportData.Atomic.Retrieval;

namespace DataImporter.DBMethods.Case.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Create_Drug_Order.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Create_Drug_Order
	{
        public static readonly int QueryTimeout = 360;

		#region Method Execution
		protected static FR_CAS_CDO_1202 Execute(DbConnection Connection,DbTransaction Transaction,P_CAS_CDO_1202 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_CAS_CDO_1202();
			//Put your code here
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_CAS_CDO_1202 Invoke(string ConnectionString,P_CAS_CDO_1202 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_CAS_CDO_1202 Invoke(DbConnection Connection,P_CAS_CDO_1202 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_CAS_CDO_1202 Invoke(DbConnection Connection, DbTransaction Transaction,P_CAS_CDO_1202 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_CAS_CDO_1202 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_CAS_CDO_1202 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_CAS_CDO_1202 functionReturn = new FR_CAS_CDO_1202();
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

				throw new Exception("Exception occured in method cls_Create_Drug_Order",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_CAS_CDO_1202 : FR_Base
	{
		public CAS_CDO_1202 Result	{ get; set; }

		public FR_CAS_CDO_1202() : base() {}

		public FR_CAS_CDO_1202(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_CAS_CDO_1202 for attribute P_CAS_CDO_1202
		[DataContract]
		public class P_CAS_CDO_1202 
		{
			//Standard type parameters
			[DataMember]
			public Guid case_id { get; set; } 
			[DataMember]
			public Guid created_by_bpt { get; set; } 
			[DataMember]
			public ORM_CMN_Language[] all_languagesL { get; set; } 
			[DataMember]
			public Guid drug_id { get; set; } 
			[DataMember]
			public DateTime delivery_date { get; set; } 
			[DataMember]
			public Boolean is_alternative_delivery_date { get; set; } 
			[DataMember]
			public DateTime alternative_delivery_date_from { get; set; } 
			[DataMember]
			public DateTime alternative_delivery_date_to { get; set; } 
			[DataMember]
			public DateTime treatment_date { get; set; } 
			[DataMember]
			public Boolean is_label_only { get; set; } 
			[DataMember]
			public Boolean is_send_invoice_to_practice { get; set; } 
			[DataMember]
			public Boolean is_patient_fee_waived { get; set; } 
			[DataMember]
			public DO_GDDfDID_0823 treatment_doctor_details { get; set; } 
			[DataMember]
			public Guid treatment_doctor_id { get; set; } 
			[DataMember]
            public PA_GPDfPID_1729 patient_details { get; set; } 
			[DataMember]
			public Guid practice_id { get; set; } 
			[DataMember]
			public Guid patient_id { get; set; } 

		}
		#endregion
		#region SClass CAS_CDO_1202 for attribute CAS_CDO_1202
		[DataContract]
		public class CAS_CDO_1202 
		{
			//Standard type parameters
			[DataMember]
			public Guid procurement_order_header_id { get; set; } 
			[DataMember]
			public Guid procurement_order_position_id { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_CAS_CDO_1202 cls_Create_Drug_Order(,P_CAS_CDO_1202 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_CAS_CDO_1202 invocationResult = cls_Create_Drug_Order.Invoke(connectionString,P_CAS_CDO_1202 Parameter,securityTicket);
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
var parameter = new DataImporter.DBMethods.Case.Atomic.Manipulation.P_CAS_CDO_1202();
parameter.case_id = ...;
parameter.created_by_bpt = ...;
parameter.all_languagesL = ...;
parameter.drug_id = ...;
parameter.delivery_date = ...;
parameter.is_alternative_delivery_date = ...;
parameter.alternative_delivery_date_from = ...;
parameter.alternative_delivery_date_to = ...;
parameter.treatment_date = ...;
parameter.is_label_only = ...;
parameter.is_send_invoice_to_practice = ...;
parameter.is_patient_fee_waived = ...;
parameter.treatment_doctor_details = ...;
parameter.treatment_doctor_id = ...;
parameter.patient_details = ...;
parameter.practice_id = ...;
parameter.patient_id = ...;

*/
