/* 
 * Generated on 7/16/2013 11:02:20 AM
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
using CL1_CMN_PER;
using CL1_CMN_BPT;
using CL1_CMN;
using CL1_USR;
using CL6_BBV_Driver.Atomic.Retrieval;

namespace CL6_BBV_Driver.Atomic.Manipulation
{
	/// <summary>
    /// No description found in <meta/> tag
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Delete_Driver_By_ID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Delete_Driver_By_ID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L6DR_DDBID_1653 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here
            P_L6DR_DDBID_1653 param = new P_L6DR_DDBID_1653();
            param.CMN_BPT_BusinessParticipantID = Parameter.CMN_BPT_BusinessParticipantID;

            var drivers = cls_Get_Drivers_for_Tennant.Invoke(Connection, Transaction, securityTicket).Result;

            var driver = drivers.FirstOrDefault(x => x.CMN_BPT_BusinessParticipantID == param.CMN_BPT_BusinessParticipantID);

            if (driver != null)
            {
                ORM_CMN_PER_PersonInfo person = new ORM_CMN_PER_PersonInfo();
                if (driver.CMN_PER_PersonInfoID != Guid.Empty)
                {
                    var result = person.Load(Connection, Transaction, driver.CMN_PER_PersonInfoID);
                    if (result.Status != FR_Status.Success || person.CMN_PER_PersonInfoID == Guid.Empty)
                    {
                        var error = new FR_Guid();
                        error.ErrorMessage = "No Such ID";
                        error.Status = FR_Status.Error_Internal;
                        return error;
                    }
                    person.IsDeleted = true;
                    person.Save(Connection, Transaction);
                }

                ORM_CMN_BPT_BusinessParticipant bParticipant = new ORM_CMN_BPT_BusinessParticipant();
                if (driver.CMN_BPT_BusinessParticipantID != Guid.Empty)
                {
                    var result = bParticipant.Load(Connection, Transaction, driver.CMN_BPT_BusinessParticipantID);
                    if (result.Status != FR_Status.Success || bParticipant.CMN_BPT_BusinessParticipantID == Guid.Empty)
                    {
                        var error = new FR_Guid();
                        error.ErrorMessage = "No Such ID";
                        error.Status = FR_Status.Error_Internal;
                        return error;
                    }
                    bParticipant.IsDeleted = true;
                    bParticipant.Save(Connection, Transaction);

                }

                if (driver.Contacts != null)
                {
                    foreach (var parContact in driver.Contacts)
                    {
                        ORM_CMN_PER_CommunicationContact contact = new ORM_CMN_PER_CommunicationContact();
                        if (parContact.CMN_PER_CommunicationContact_TypeID != Guid.Empty)
                        {
                            var result = contact.Load(Connection, Transaction, parContact.CMN_PER_CommunicationContact_TypeID);
                            if (result.Status != FR_Status.Success || contact.CMN_PER_CommunicationContactID == Guid.Empty)
                            {
                                var error = new FR_Guid();
                                error.ErrorMessage = "No Such ID";
                                error.Status = FR_Status.Error_Internal;
                                return error;
                            }
                            contact.IsDeleted = true;
                            contact.Save(Connection, Transaction);
                        }
                    }
                }

                ORM_CMN_Address adress = new ORM_CMN_Address();
                if (driver.CMN_AddressID != Guid.Empty)
                {
                    var result = adress.Load(Connection, Transaction, driver.CMN_AddressID);
                    if (result.Status != FR_Status.Success || adress.CMN_AddressID == Guid.Empty)
                    {
                        var error = new FR_Guid();
                        error.ErrorMessage = "No Such ID";
                        error.Status = FR_Status.Error_Internal;
                        return error;
                    }
                    adress.IsDeleted = true;
                    adress.Save(Connection, Transaction);
                }

                ORM_CMN_BPT_Supplier supplier = new ORM_CMN_BPT_Supplier();
                if (driver.CMN_BPT_SupplierID != Guid.Empty)
                {
                    var result = supplier.Load(Connection, Transaction, driver.CMN_BPT_SupplierID);
                    if (result.Status != FR_Status.Success || supplier.CMN_BPT_SupplierID == Guid.Empty)
                    {
                        var error = new FR_Guid();
                        error.ErrorMessage = "No Such ID";
                        error.Status = FR_Status.Error_Internal;
                        return error;
                    }
                    supplier.IsDeleted = true;
                    supplier.Save(Connection, Transaction);
                }

                ORM_CMN_BPT_BusinessParticipant asossBParticipant = new ORM_CMN_BPT_BusinessParticipant();
                if (driver.AssociatedBusinessParticipant_RefID != Guid.Empty)
                {
                    var result = asossBParticipant.Load(Connection, Transaction, driver.AssociatedBusinessParticipant_RefID);
                    if (result.Status != FR_Status.Success || asossBParticipant.CMN_BPT_BusinessParticipantID == Guid.Empty)
                    {
                        var error = new FR_Guid();
                        error.ErrorMessage = "No Such ID";
                        error.Status = FR_Status.Error_Internal;
                        return error;
                    }
                    asossBParticipant.IsDeleted = true;
                    asossBParticipant.Save(Connection, Transaction);
                }


                ORM_CMN_BPT_BusinessParticipant_AssociatedBusinessParticipant BusinessParticipant_AssociatedBusinessParticipant = new ORM_CMN_BPT_BusinessParticipant_AssociatedBusinessParticipant();
                if (driver.AssociatedBusinessParticipant_RefID != Guid.Empty)
                {
                    var result = BusinessParticipant_AssociatedBusinessParticipant.Load(Connection, Transaction, driver.CMN_BPT_BusinessParticipant_AssociatedBusinessParticipantID);
                    if (result.Status != FR_Status.Success || BusinessParticipant_AssociatedBusinessParticipant.CMN_BPT_BusinessParticipant_AssociatedBusinessParticipantID == Guid.Empty)
                    {
                        var error = new FR_Guid();
                        error.ErrorMessage = "No Such ID";
                        error.Status = FR_Status.Error_Internal;
                        return error;
                    }
                    BusinessParticipant_AssociatedBusinessParticipant.IsDeleted = true;
                    BusinessParticipant_AssociatedBusinessParticipant.Save(Connection, Transaction);
                }

                ORM_USR_Account account = new ORM_USR_Account();
                if (driver.USR_AccountID != Guid.Empty)
                {
                    var result = account.Load(Connection, Transaction, driver.USR_AccountID);
                    if (result.Status != FR_Status.Success || account.USR_AccountID == Guid.Empty)
                    {
                        var error = new FR_Guid();
                        error.ErrorMessage = "No Such ID";
                        error.Status = FR_Status.Error_Internal;
                        return error;
                    }
                    account.IsDeleted = true;
                    account.Save(Connection, Transaction);
                }

                ORM_USR_Device_AccountCode_StatusHistory Device_AccountCode_StatusHistory = new ORM_USR_Device_AccountCode_StatusHistory();
                if (driver.USR_Device_AccountCode_UsageHistoryID != Guid.Empty)
                {
                    var result = Device_AccountCode_StatusHistory.Load(Connection, Transaction, driver.USR_Device_AccountCode_UsageHistoryID);
                    if (result.Status != FR_Status.Success || Device_AccountCode_StatusHistory.USR_Device_AccountCode_StatusHistoryID == Guid.Empty)
                    {
                        var error = new FR_Guid();
                        error.ErrorMessage = "No Such ID";
                        error.Status = FR_Status.Error_Internal;
                        return error;
                    }
                    Device_AccountCode_StatusHistory.IsDeleted = true;
                    Device_AccountCode_StatusHistory.Save(Connection, Transaction);
                }

                ORM_USR_Device_AccountCode accountCode = new ORM_USR_Device_AccountCode();
                if (driver.USR_Device_AccountCodeID != Guid.Empty)
                {
                    var result = accountCode.Load(Connection, Transaction, driver.USR_Device_AccountCodeID);
                    if (result.Status != FR_Status.Success || accountCode.USR_Device_AccountCodeID == Guid.Empty)
                    {
                        var error = new FR_Guid();
                        error.ErrorMessage = "No Such ID";
                        error.Status = FR_Status.Error_Internal;
                        return error;
                    }
                    accountCode.IsDeleted = true;
                    accountCode.Save(Connection, Transaction);
                }

                var Device_AccountCode_UsageHistoryQuery = new ORM_USR_Device_AccountCode_UsageHistory.Query();
                Device_AccountCode_UsageHistoryQuery.Device_AccountCode_RefID = accountCode.USR_Device_AccountCodeID;
                Device_AccountCode_UsageHistoryQuery.IsDeleted = false;
                Device_AccountCode_UsageHistoryQuery.Tenant_RefID = securityTicket.TenantID;

                var historyArray = ORM_USR_Device_AccountCode_UsageHistory.Query.Search(Connection, Transaction, Device_AccountCode_UsageHistoryQuery);
                if (historyArray != null && historyArray.Count > 0)
                {
                    foreach (var historyItem in historyArray)
                    {
                        historyItem.IsDeleted = true;
                        historyItem.Save(Connection, Transaction);
                    }
                }
            }
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L6DR_DDBID_1653 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L6DR_DDBID_1653 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L6DR_DDBID_1653 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6DR_DDBID_1653 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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
		#region SClass P_L6DR_DDBID_1653 for attribute P_L6DR_DDBID_1653
		[DataContract]
		public class P_L6DR_DDBID_1653 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_BPT_BusinessParticipantID { get; set; } 

		}
		#endregion

	#endregion
}
