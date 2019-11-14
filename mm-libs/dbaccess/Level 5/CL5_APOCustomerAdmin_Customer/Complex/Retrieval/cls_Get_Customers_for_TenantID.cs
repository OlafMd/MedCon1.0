/* 
 * Generated on 9/25/2014 1:35:10 PM
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
using System.Runtime.Serialization;
using CL5_APOCustomerAdmin_Customer.Atomic.Retrieval;

namespace CL5_APOCustomerAdmin_Customer.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Customers_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Customers_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5ACACU_GCfT_1730_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5ACACU_GCfT_1730_Array();
            var resList = new List<L5ACACU_GCfT_1730>();

            var persons = cls_Get_PersonCustomers_for_TenantID.Invoke(Connection, Transaction, securityTicket).Result;
            var companies = cls_Get_CompanyCustomers_for_TenantID.Invoke(Connection, Transaction, securityTicket).Result;
            if (persons != null)
            {
                foreach (var p in persons)
                {
                    var item = new L5ACACU_GCfT_1730();
                    item.CMN_BPT_BusinessParticipantID = p.CMN_BPT_BusinessParticipantID;
                    item.CMN_BPT_CTM_CustomerID = p.CMN_BPT_CTM_CustomerID;
                    item.FirstName = p.FirstName;
                    item.LastName = p.LastName;
                    item.BirthDate = p.BirthDate;
                    item.IsPerson = true;
                    item.IfPerson_CMN_PER_PersonInfoID = p.CMN_PER_PersonInfoID;
                    item.PaymentTypeID = p.ACC_PAY_Type_RefID;
                    item.InternalCustomerNumber = p.InternalCustomerNumber;
                    item.PaymentCondition = p.ACC_PAY_Condition_RefID;
                    item.DispayName = p.DisplayName;
                    item.IsRepresentedByLegalGuardian = p.IsRepresentedByLegalGuardian;
                    item.LegalGuardianName = p.LegalGuardianDisplayName;
                    item.IsCustomerOrderAutomaticallyApprovedOnReceipt = p.IsCustomerOrderAutomaticallyApprovedOnReceipt;
                    item.NumberOfComments = p.NumberOfComments;
                    resList.Add(item);
                }
            }
            if (companies != null)
            {
                foreach (var c in companies)
                {
                    var item = new L5ACACU_GCfT_1730();
                    item.CMN_BPT_BusinessParticipantID = c.CMN_BPT_BusinessParticipantID;
                    item.CMN_BPT_CTM_CustomerID = c.CMN_BPT_CTM_CustomerID;
                    item.FirmName = c.CompanyName_Line1;
                    item.IsCompany = true;
                    item.IfCompany_CMN_COM_CompanyInfoID = c.CMN_COM_CompanyInfoID;
                    item.PaymentTypeID = c.ACC_PAY_Type_RefID;
                    item.InternalCustomerNumber = c.InternalCustomerNumber;
                    item.PaymentCondition = c.ACC_PAY_Condition_RefID;
                    item.CompanyName_Line2 = c.CompanyName_Line2;
                    item.DispayName = c.DisplayName;
                    item.IsCustomerOrderAutomaticallyApprovedOnReceipt = c.IsCustomerOrderAutomaticallyApprovedOnReceipt;
                    item.NumberOfComments = c.NumberOfComments;
                    resList.Add(item);
                }
            }

            returnValue.Result = resList.OrderBy(l => l.LastName).ToArray();

            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5ACACU_GCfT_1730_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5ACACU_GCfT_1730_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5ACACU_GCfT_1730_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5ACACU_GCfT_1730_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5ACACU_GCfT_1730_Array functionReturn = new FR_L5ACACU_GCfT_1730_Array();
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

				functionReturn = Execute(Connection, Transaction,securityTicket);

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

				throw new Exception("Exception occured in method cls_Get_Customers_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5ACACU_GCfT_1730_Array : FR_Base
	{
		public L5ACACU_GCfT_1730[] Result	{ get; set; } 
		public FR_L5ACACU_GCfT_1730_Array() : base() {}

		public FR_L5ACACU_GCfT_1730_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5ACACU_GCfT_1730 for attribute L5ACACU_GCfT_1730
		[DataContract]
		public class L5ACACU_GCfT_1730 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_BPT_CTM_CustomerID { get; set; } 
			[DataMember]
			public Guid CMN_BPT_BusinessParticipantID { get; set; } 
			[DataMember]
			public bool IsPerson { get; set; } 
			[DataMember]
			public bool IsCompany { get; set; } 
			[DataMember]
			public Guid IfPerson_CMN_PER_PersonInfoID { get; set; } 
			[DataMember]
			public Guid IfCompany_CMN_COM_CompanyInfoID { get; set; } 
			[DataMember]
			public String LastName { get; set; } 
			[DataMember]
			public String FirstName { get; set; } 
			[DataMember]
			public String FirmName { get; set; } 
			[DataMember]
			public DateTime BirthDate { get; set; } 
			[DataMember]
			public Guid PaymentTypeID { get; set; } 
			[DataMember]
			public String InternalCustomerNumber { get; set; } 
			[DataMember]
			public Guid PaymentCondition { get; set; } 
			[DataMember]
			public String CompanyName_Line2 { get; set; } 
			[DataMember]
			public String DispayName { get; set; } 
			[DataMember]
			public bool IsRepresentedByLegalGuardian { get; set; } 
			[DataMember]
			public String LegalGuardianName { get; set; } 
			[DataMember]
			public bool IsCustomerOrderAutomaticallyApprovedOnReceipt { get; set; } 
			[DataMember]
			public int NumberOfComments { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5ACACU_GCfT_1730_Array cls_Get_Customers_for_TenantID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5ACACU_GCfT_1730_Array invocationResult = cls_Get_Customers_for_TenantID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

