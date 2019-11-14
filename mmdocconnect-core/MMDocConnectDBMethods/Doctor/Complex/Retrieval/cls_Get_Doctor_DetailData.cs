/* 
 * Generated on 9/7/2015 1:45:48 PM
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
using MMDocConnectDBMethods.Doctor.Atomic.Retrieval;

namespace MMDocConnectDBMethods.Doctor.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Doctor_DetailData.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Doctor_DetailData
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_DO_GPDD_1137 Execute(DbConnection Connection,DbTransaction Transaction,P_DO_GPDD_1137 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_DO_GPDD_1137();
            returnValue.Result = new DO_GPDD_1137();
            DO_GPDD_1137 doctor_detail = new DO_GPDD_1137();

            var data = cls_Get_Doctor_Details_for_DoctorID.Invoke(Connection, Transaction, new P_DO_GDDfDID_0823 { DoctorID = Parameter.ID }, securityTicket).Result.Single();

            doctor_detail.address = data.address;
            doctor_detail.practice = data.practice;
            doctor_detail.bank_name = data.BankName;
            doctor_detail.bic = data.BICCode;
            if (data.DoctorComunication.Where(k => k.Type == "Phone").SingleOrDefault() != null)
                doctor_detail.phone = data.DoctorComunication.Where(k => k.Type == "Phone").Single().Content;
            doctor_detail.iban = data.IBAN;
            doctor_detail.id = data.id.ToString();
            doctor_detail.lanr = data.lanr;
            doctor_detail.first_name = data.first_name;
            doctor_detail.practice_id = data.practice_id.ToString();
            doctor_detail.last_name = data.last_name;
            doctor_detail.title = data.title;
            if (data.DoctorComunication.Where(k => k.Type == "Email").SingleOrDefault() != null)
                doctor_detail.email = data.DoctorComunication.Where(k => k.Type == "Email").Single().Content;

            var practice_bank_info = cls_Get_BankInfo_for_Practice.Invoke(Connection, Transaction, new P_DO_GBAfPR_1524() { PracticeID = data.practice_id }, securityTicket).Result.FirstOrDefault();

            if (practice_bank_info != null)
            {
                var doctor_bank_info = cls_Get_BankInfo_for_DoctorID.Invoke(Connection, Transaction, new P_DO_BBIfDID_1424() { DoctorID = data.id }, securityTicket).Result;

                if (doctor_bank_info != null)
                    doctor_detail.is_bank_inherited = doctor_bank_info.BankAccountID == practice_bank_info.BankAccountID;
            }

            doctor_detail.login_email = data.sign_in_email;
            doctor_detail.account_holder = data.OwnerText;
            doctor_detail.password = "fake password";
            doctor_detail.salutation = data.salutation;
            

            returnValue.Result = doctor_detail;
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_DO_GPDD_1137 Invoke(string ConnectionString,P_DO_GPDD_1137 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_DO_GPDD_1137 Invoke(DbConnection Connection,P_DO_GPDD_1137 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_DO_GPDD_1137 Invoke(DbConnection Connection, DbTransaction Transaction,P_DO_GPDD_1137 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_DO_GPDD_1137 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_DO_GPDD_1137 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_DO_GPDD_1137 functionReturn = new FR_DO_GPDD_1137();
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

				throw new Exception("Exception occured in method cls_Get_Doctor_DetailData",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_DO_GPDD_1137 : FR_Base
	{
		public DO_GPDD_1137 Result	{ get; set; }

		public FR_DO_GPDD_1137() : base() {}

		public FR_DO_GPDD_1137(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_DO_GPDD_1137 for attribute P_DO_GPDD_1137
		[DataContract]
		public class P_DO_GPDD_1137 
		{
			//Standard type parameters
			[DataMember]
			public Guid ID { get; set; } 

		}
		#endregion
		#region SClass DO_GPDD_1137 for attribute DO_GPDD_1137
		[DataContract]
		public class DO_GPDD_1137 
		{
			//Standard type parameters
			[DataMember]
			public String id { get; set; } 
			[DataMember]
			public String practice_id { get; set; } 
			[DataMember]
			public String address { get; set; } 
			[DataMember]
			public String practice { get; set; } 
			[DataMember]
			public String bank_name { get; set; } 
			[DataMember]
			public String bic { get; set; } 
			[DataMember]
			public String phone { get; set; } 
			[DataMember]
			public String iban { get; set; } 
			[DataMember]
			public String lanr { get; set; } 
			[DataMember]
			public String first_name { get; set; } 
			[DataMember]
			public String last_name { get; set; } 
			[DataMember]
			public String title { get; set; } 
			[DataMember]
			public String email { get; set; } 
			[DataMember]
			public bool is_bank_inherited { get; set; } 
			[DataMember]
			public String login_email { get; set; } 
			[DataMember]
			public String account_holder { get; set; } 
			[DataMember]
			public String password { get; set; } 
			[DataMember]
			public String salutation { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_DO_GPDD_1137 cls_Get_Doctor_DetailData(,P_DO_GPDD_1137 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_DO_GPDD_1137 invocationResult = cls_Get_Doctor_DetailData.Invoke(connectionString,P_DO_GPDD_1137 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Doctor.Complex.Retrieval.P_DO_GPDD_1137();
parameter.ID = ...;

*/
