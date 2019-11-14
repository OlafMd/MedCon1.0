/* 
 * Generated on 8/12/2014 10:53:40
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
using CL1_CMN_BPT;
using CL1_TMS;
using CL1_USR;
using CL1_DOC;
using CL3_User.Atomic.Retrieval;



namespace CL3_QuickTask.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_TMS_QuickTask.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_TMS_QuickTask
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L3QT_SQT_0905 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_Guid();

            var item = new ORM_TMS_QuickTask();
            if (Parameter.TMS_QuickTaskID != Guid.Empty)
            {
                var result = item.Load(Connection, Transaction, Parameter.TMS_QuickTaskID);
                if (result.Status != FR_Status.Success || item.TMS_QuickTaskID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }

            if (Parameter.IsDeleted == true)
            {
                #region Delete ORM_CMN_BPT_InvestedWorkTime

                var qtinv_query = new ORM_TMS_QuickTask_InvestedWorkTime.Query();
                qtinv_query.TMS_QuickTasks_RefID = item.TMS_QuickTaskID;
                qtinv_query.IsDeleted = false;

                var qtinv = ORM_TMS_QuickTask_InvestedWorkTime.Query.Search(Connection, Transaction, qtinv_query);

                foreach(var qt in qtinv){
                    qt.IsDeleted = true;
                    qt.Save(Connection, Transaction);

                    var inv_query = new ORM_CMN_BPT_InvestedWorkTime.Query();
                    inv_query.CMN_BPT_InvestedWorkTimeID = qt.CMN_BPT_InvestedWorkTime_RefID;
                    inv_query.IsDeleted = false;

                    ORM_CMN_BPT_InvestedWorkTime.Query.SoftDelete(Connection, Transaction, inv_query);
                }

                #endregion

                item.IsDeleted = true;
                return new FR_Guid(item.Save(Connection, Transaction), item.TMS_QuickTaskID);
            }

            //Creation specific parameters (Tenant, Account ... )
            if (Parameter.TMS_QuickTaskID == Guid.Empty)
            {
                item.QuickTask_CreatedByAccount_RefID = securityTicket.AccountID;
                item.Tenant_RefID = securityTicket.TenantID;

                #region Define IdentificationNumber

                ORM_TMS_QuickTask.Query query = new ORM_TMS_QuickTask.Query();
                query.Tenant_RefID = securityTicket.TenantID;
                var count = ORM_TMS_QuickTask.Query.Search(Connection, Transaction, query).Count() + 1;
                String identifier = "000000" + count.ToString();
                item.IdentificationNumber = identifier.Substring(identifier.Length - 6);

                #endregion


                #region Define DocumentsL3FE_GFIfF_1455

                var structureHeader = new ORM_DOC_Structure_Header();
                structureHeader.DOC_Structure_HeaderID = Guid.NewGuid();

                structureHeader.Label = Parameter.QuickTask_Title.GetContent(Parameter.LanguageID);

                structureHeader.Tenant_RefID = securityTicket.TenantID;
                var structureStatusSave = structureHeader.Save(Connection, Transaction);

                item.QuickTask_DocumentStructureHeader_RefID = structureHeader.DOC_Structure_HeaderID;

                #endregion

                #region BusinessParticipient

                ORM_USR_Account userAcc = new ORM_USR_Account();
                userAcc.Load(Connection, Transaction, securityTicket.AccountID);

                #endregion

                #region Invested work times

                ORM_CMN_BPT_InvestedWorkTime iwt = new ORM_CMN_BPT_InvestedWorkTime();
                iwt.BusinessParticipant_RefID = userAcc.BusinessParticipant_RefID;
                iwt.WorkTime_Source = "DanuTask - [W" + item.IdentificationNumber + "] " + Parameter.QuickTask_Title.GetContent(Parameter.LanguageID);
                
                iwt.CMN_BPT_InvestedWorkTimeID = Guid.NewGuid();
                iwt.WorkTime_Start = Parameter.QuickTask_StartTime;
                iwt.WorkTime_Amount_min = (long)Parameter.R_QuickTask_InvestedTime_min;
                iwt.WorkTime_InternalIdentifier = cls_Get_NewInvestedWTimeIdentifier.Invoke(Connection, Transaction, securityTicket).Result.Identifier;
                iwt.Tenant_RefID = securityTicket.TenantID;
                iwt.Save(Connection, Transaction);

                ORM_TMS_QuickTask_InvestedWorkTime qtiwt = new ORM_TMS_QuickTask_InvestedWorkTime();
                qtiwt.CMN_BPT_InvestedWorkTime_RefID = iwt.CMN_BPT_InvestedWorkTimeID;
                qtiwt.Creation_Timestamp = DateTime.Now;
                qtiwt.Tenant_RefID = securityTicket.TenantID;
                qtiwt.TMS_QuickTask_InvestedWorkTimeID = Guid.NewGuid();
                qtiwt.TMS_QuickTasks_RefID = item.TMS_QuickTaskID;
                qtiwt.Save(Connection, Transaction);

                #endregion

            }
            else {

                var query = new ORM_TMS_QuickTask_InvestedWorkTime.Query();
                query.TMS_QuickTasks_RefID = item.TMS_QuickTaskID;
                query.IsDeleted = false;

                var result = ORM_TMS_QuickTask_InvestedWorkTime.Query.Search(Connection, Transaction, query).ToArray();

                if (result.Count() == 1) {
                    ORM_CMN_BPT_InvestedWorkTime iwt = new ORM_CMN_BPT_InvestedWorkTime();
                    iwt.Load(Connection, Transaction, result[0].CMN_BPT_InvestedWorkTime_RefID);
                    iwt.WorkTime_Source = "DanuTask - [W" + item.IdentificationNumber + "] " + Parameter.QuickTask_Title.GetContent(Parameter.LanguageID);
                    iwt.WorkTime_Start = Parameter.QuickTask_StartTime;
                    iwt.WorkTime_Amount_min = (long)Parameter.R_QuickTask_InvestedTime_min;
                    iwt.WorkTime_InternalIdentifier = cls_Get_NewInvestedWTimeIdentifier.Invoke(Connection, Transaction, securityTicket).Result.Identifier;
                    iwt.Save(Connection, Transaction);

                }
            
            }

            if (item.QuickTask_StartTime != Parameter.QuickTask_StartTime)
                item.IsManuallyEntered = true;

            if (item.R_QuickTask_InvestedTime_min != Parameter.R_QuickTask_InvestedTime_min)
                item.IsManuallyEntered = true;

            item.QuickTask_Title = Parameter.QuickTask_Title;
            item.QuickTask_Description = Parameter.QuickTask_Description;
            item.QuickTask_Type_RefID = Parameter.QuickTask_Type_RefID;
            item.R_QuickTask_InvestedTime_min = Parameter.R_QuickTask_InvestedTime_min;
            item.AssignedTo_Project_RefID = Parameter.AssignedTo_Project_RefID;
            item.AssignedTo_BusinessTask_RefID = Parameter.AssignedTo_BusinessTask_RefID;
            item.AssignedTo_Feature_RefID = Parameter.AssignedTo_Feature_RefID;
            item.AssignedTo_DeveloperTask_RefID = Parameter.AssignedTo_DeveloperTask_RefID;
            item.QuickTask_StartTime = Parameter.QuickTask_StartTime;

            return new FR_Guid(item.Save(Connection, Transaction), item.TMS_QuickTaskID);

			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L3QT_SQT_0905 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L3QT_SQT_0905 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L3QT_SQT_0905 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3QT_SQT_0905 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_TMS_QuickTask",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3QT_SQT_0905 for attribute P_L3QT_SQT_0905
		[DataContract]
		public class P_L3QT_SQT_0905 
		{
			//Standard type parameters
			[DataMember]
			public Guid TMS_QuickTaskID { get; set; } 
			[DataMember]
			public Dict QuickTask_Title { get; set; } 
			[DataMember]
			public Dict QuickTask_Description { get; set; } 
			[DataMember]
			public Guid QuickTask_Type_RefID { get; set; } 
			[DataMember]
			public Double R_QuickTask_InvestedTime_min { get; set; } 
			[DataMember]
			public Guid QuickTask_CreatedByAccount_RefID { get; set; } 
			[DataMember]
			public Guid AssignedTo_Project_RefID { get; set; } 
			[DataMember]
			public Guid AssignedTo_BusinessTask_RefID { get; set; } 
			[DataMember]
			public Guid AssignedTo_Feature_RefID { get; set; } 
			[DataMember]
			public Guid AssignedTo_DeveloperTask_RefID { get; set; } 
			[DataMember]
			public DateTime QuickTask_StartTime { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; }
            [DataMember]
            public Guid LanguageID { get; set; }

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_TMS_QuickTask(,P_L3QT_SQT_0905 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_TMS_QuickTask.Invoke(connectionString,P_L3QT_SQT_0905 Parameter,securityTicket);
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
var parameter = new CL3_QuickTask.Atomic.Manipulation.P_L3QT_SQT_0905();
parameter.TMS_QuickTaskID = ...;
parameter.QuickTask_Title = ...;
parameter.QuickTask_Description = ...;
parameter.QuickTask_Type_RefID = ...;
parameter.R_QuickTask_InvestedTime_min = ...;
parameter.QuickTask_CreatedByAccount_RefID = ...;
parameter.AssignedTo_Project_RefID = ...;
parameter.AssignedTo_BusinessTask_RefID = ...;
parameter.AssignedTo_Feature_RefID = ...;
parameter.AssignedTo_DeveloperTask_RefID = ...;
parameter.QuickTask_StartTime = ...;
parameter.IsDeleted = ...;

*/
