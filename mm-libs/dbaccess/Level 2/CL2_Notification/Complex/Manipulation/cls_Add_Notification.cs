/* 
 * Generated on 10/25/2013 2:54:08 PM
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
using CSV2Core.Core;
using System.Runtime.Serialization;
using CL1_USR;
using CL1_USR_NOT;

namespace CL2_Notification.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Add_Notification.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Add_Notification
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L2NT_AN_1402 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            var typeQuery = new ORM_USR_NOT_Notification_Type.Query();
            typeQuery.IsDeleted = false;
            typeQuery.Tenant_RefID = securityTicket.TenantID;
            typeQuery.NotificationType_Key = Parameter.NotificationTypeKey;
            var typeRes = ORM_USR_NOT_Notification_Type.Query.Search(Connection, Transaction, typeQuery).ToArray();
            ORM_USR_NOT_Notification_Type notificationType;
            if (typeRes == null || typeRes.Count() == 0)
            {
                notificationType = new ORM_USR_NOT_Notification_Type();
                notificationType.NotificationType_Key = Parameter.NotificationTypeKey;
                notificationType.NotificationType_Label = Parameter.NotificationTypeLabel;
                notificationType.Tenant_RefID = securityTicket.TenantID;
                notificationType.USR_NOT_Notification_TypeID = Guid.NewGuid();
                notificationType.Save(Connection, Transaction);
            }
            else
            {
                notificationType = typeRes.First();
            }

            if (Parameter.IsSingleUser)
            {
                ORM_USR_NOT_Notification_Subscription notificationSbs = null;
                var sbsQuery = new ORM_USR_NOT_Notification_Subscription.Query();
                sbsQuery.IsDeleted = false;
                sbsQuery.Tenant_RefID = securityTicket.TenantID;
                sbsQuery.Account_RefID = Parameter.IfSingleUser_AccountID;
                sbsQuery.NotificationType_RefID = notificationType.USR_NOT_Notification_TypeID;
                var sbsRes = ORM_USR_NOT_Notification_Subscription.Query.Search(Connection, Transaction, sbsQuery).ToArray();
                if (sbsRes != null && sbsRes.Count() > 0)
                {
                    notificationSbs = sbsRes.First();
                }
                else if(Parameter.IsSubscribableNotification)
                {
                    notificationSbs = new ORM_USR_NOT_Notification_Subscription();
                    notificationSbs.USR_NOT_Notification_SubscriptionID = Guid.NewGuid();
                    notificationSbs.NotificationType_RefID = notificationType.USR_NOT_Notification_TypeID;
                    notificationSbs.Account_RefID = Parameter.IfSingleUser_AccountID;
                    notificationSbs.Tenant_RefID = securityTicket.TenantID;
                    notificationSbs.Save(Connection, Transaction);
                }

                if (notificationSbs != null)
                {
                    var notification = new ORM_USR_NOT_Notification();
                    notification.USR_NOT_NotificationID = Guid.NewGuid();
                    notification.NotificationSubscription_RefID = notificationSbs.USR_NOT_Notification_SubscriptionID;
                    notification.R_Account_RefID = notificationSbs.Account_RefID;
                    notification.R_NotificationKey = notificationType.NotificationType_Key;
                    notification.Notification_Link = Parameter.Notification_Link;
                    notification.Notification_Text = Parameter.Notification_Text;
                    notification.Tenant_RefID = securityTicket.TenantID;
                    notification.Save(Connection, Transaction);
                }
            }
            else if (Parameter.IsMultiUser && Parameter.IfMultiUser_AccoundIDList != null)
            {
                foreach (Guid AccountID in Parameter.IfMultiUser_AccoundIDList)
                {
                    ORM_USR_NOT_Notification_Subscription notificationSbs = null;
                    var sbsQuery = new ORM_USR_NOT_Notification_Subscription.Query();
                    sbsQuery.IsDeleted = false;
                    sbsQuery.Tenant_RefID = securityTicket.TenantID;
                    sbsQuery.Account_RefID = AccountID;
                    sbsQuery.NotificationType_RefID = notificationType.USR_NOT_Notification_TypeID;
                    var sbsRes = ORM_USR_NOT_Notification_Subscription.Query.Search(Connection, Transaction, sbsQuery).ToArray();
                    if (sbsRes != null && sbsRes.Count() > 0)
                    {
                        notificationSbs = sbsRes.First();
                    }
                    else if (Parameter.IsSubscribableNotification)
                    {
                        notificationSbs = new ORM_USR_NOT_Notification_Subscription();
                        notificationSbs.USR_NOT_Notification_SubscriptionID = Guid.NewGuid();
                        notificationSbs.NotificationType_RefID = notificationType.USR_NOT_Notification_TypeID;
                        notificationSbs.Account_RefID = AccountID;
                        notificationSbs.Tenant_RefID = securityTicket.TenantID;
                        notificationSbs.Save(Connection, Transaction);
                    }

                    if (notificationSbs != null)
                    {
                        var notification = new ORM_USR_NOT_Notification();
                        notification.USR_NOT_NotificationID = Guid.NewGuid();
                        notification.NotificationSubscription_RefID = notificationSbs.USR_NOT_Notification_SubscriptionID;
                        notification.R_Account_RefID = notificationSbs.Account_RefID;
                        notification.R_NotificationKey = notificationType.NotificationType_Key;
                        notification.Notification_Link = Parameter.Notification_Link;
                        notification.Notification_Text = Parameter.Notification_Text;
                        notification.Tenant_RefID = securityTicket.TenantID;
                        notification.Save(Connection, Transaction);
                    }
                }
            }
            else if (Parameter.IsTenant)
            {
                var accountQery = new ORM_USR_Account.Query();
                accountQery.IsDeleted = false;
                accountQery.Tenant_RefID = securityTicket.TenantID;
                var accounts = ORM_USR_Account.Query.Search(Connection, Transaction, accountQery).ToArray();
                if (accounts != null)
                {
                    foreach (ORM_USR_Account account in accounts)
                    {
                        if (!Parameter.IfTenant_IsForMeAlso && account.USR_AccountID == securityTicket.AccountID)
                            continue;

                        ORM_USR_NOT_Notification_Subscription notificationSbs = null;
                        var sbsQuery = new ORM_USR_NOT_Notification_Subscription.Query();
                        sbsQuery.IsDeleted = false;
                        sbsQuery.Tenant_RefID = securityTicket.TenantID;
                        sbsQuery.Account_RefID = account.USR_AccountID;
                        sbsQuery.NotificationType_RefID = notificationType.USR_NOT_Notification_TypeID;
                        var sbsRes = ORM_USR_NOT_Notification_Subscription.Query.Search(Connection, Transaction, sbsQuery).ToArray();
                        if (sbsRes != null && sbsRes.Count() > 0)
                        {
                            notificationSbs = sbsRes.First();
                        }
                        else if (Parameter.IsSubscribableNotification)
                        {
                            notificationSbs = new ORM_USR_NOT_Notification_Subscription();
                            notificationSbs.USR_NOT_Notification_SubscriptionID = Guid.NewGuid();
                            notificationSbs.NotificationType_RefID = notificationType.USR_NOT_Notification_TypeID;
                            notificationSbs.Account_RefID = account.USR_AccountID;
                            notificationSbs.Tenant_RefID = securityTicket.TenantID;
                            notificationSbs.Save(Connection, Transaction);
                        }

                        if (notificationSbs != null)
                        {
                            var notification = new ORM_USR_NOT_Notification();
                            notification.USR_NOT_NotificationID = Guid.NewGuid();
                            notification.NotificationSubscription_RefID = notificationSbs.USR_NOT_Notification_SubscriptionID;
                            notification.R_Account_RefID = notificationSbs.Account_RefID;
                            notification.R_NotificationKey = notificationType.NotificationType_Key;
                            notification.Notification_Link = Parameter.Notification_Link;
                            notification.Notification_Text = Parameter.Notification_Text;
                            notification.Tenant_RefID = securityTicket.TenantID;
                            notification.Save(Connection, Transaction);
                        }
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
		public static FR_Guid Invoke(string ConnectionString,P_L2NT_AN_1402 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L2NT_AN_1402 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L2NT_AN_1402 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2NT_AN_1402 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Add_Notification",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L2NT_AN_1402 for attribute P_L2NT_AN_1402
		[DataContract]
		public class P_L2NT_AN_1402 
		{
			//Standard type parameters
			[DataMember]
			public String NotificationTypeKey { get; set; } 
			[DataMember]
			public String NotificationTypeLabel { get; set; } 
			[DataMember]
			public String Notification_Text { get; set; } 
			[DataMember]
			public String Notification_Link { get; set; } 
			[DataMember]
			public bool IsSubscribableNotification { get; set; } 
			[DataMember]
			public bool IsSingleUser { get; set; } 
			[DataMember]
			public Guid IfSingleUser_AccountID { get; set; } 
			[DataMember]
			public bool IsMultiUser { get; set; } 
			[DataMember]
			public Guid[] IfMultiUser_AccoundIDList { get; set; } 
			[DataMember]
			public bool IsTenant { get; set; } 
			[DataMember]
			public bool IfTenant_IsForMeAlso { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Add_Notification(,P_L2NT_AN_1402 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Add_Notification.Invoke(connectionString,P_L2NT_AN_1402 Parameter,securityTicket);
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
var parameter = new CL2_Notification.Complex.Manipulation.P_L2NT_AN_1402();
parameter.NotificationTypeKey = ...;
parameter.NotificationTypeLabel = ...;
parameter.Notification_Text = ...;
parameter.Notification_Link = ...;
parameter.IsSubscribableNotification = ...;
parameter.IsSingleUser = ...;
parameter.IfSingleUser_AccountID = ...;
parameter.IsMultiUser = ...;
parameter.IfMultiUser_AccoundIDList = ...;
parameter.IsTenant = ...;
parameter.IfTenant_IsForMeAlso = ...;

*/
