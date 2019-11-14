/* 
 * Generated on 2/17/2015 4:18:39 PM
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
using CL1_DOC;

namespace CL5_MyHealthClub_DoctorsAndStaff.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_PrintingSettings.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_PrintingSettings
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5DO_SPS_1606 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            returnValue.Result = Guid.Empty;

            #region Save
            if (Parameter.DOC_DocumentTemplate_InstanceID == Guid.Empty)
            {
                ORM_DOC_DocumentTemplate_Instance documentTemplateInstance = new ORM_DOC_DocumentTemplate_Instance();
                documentTemplateInstance.DOC_DocumentTemplate_InstanceID = Guid.NewGuid();
                documentTemplateInstance.DisplayName = Parameter.DisplayName;
                documentTemplateInstance.InstanceContent = Parameter.InstanceContent;
                documentTemplateInstance.Modification_Timestamp = DateTime.Now;
                documentTemplateInstance.Source_DocumentTemplate_RefID = Parameter.Source_DocumentTemplate_RefID;
                documentTemplateInstance.Tenant_RefID = securityTicket.TenantID;
                documentTemplateInstance.Save(Connection, Transaction);

                ORM_DOC_DocumentTemplate_2_BusinessParticipant template2BusinessParticipant = new ORM_DOC_DocumentTemplate_2_BusinessParticipant();
                template2BusinessParticipant.AssignmentID = Guid.NewGuid();
                template2BusinessParticipant.CMN_BPT_BusinessParticipant_RefID = Parameter.CMN_BPT_BusinessParticipant_RefID;
                template2BusinessParticipant.DOC_DocumentTemplate_Instance_RefID = documentTemplateInstance.DOC_DocumentTemplate_InstanceID;
                template2BusinessParticipant.Tenant_RefID = securityTicket.TenantID;
                template2BusinessParticipant.Save(Connection, Transaction);

                returnValue.Result = documentTemplateInstance.DOC_DocumentTemplate_InstanceID;
            }
            #endregion
            //=====================Edit or Delete=====================
            else
            {
                ORM_DOC_DocumentTemplate_Instance documentTemplateInstance = ORM_DOC_DocumentTemplate_Instance.Query.Search(Connection, Transaction, new ORM_DOC_DocumentTemplate_Instance.Query
                {
                    DOC_DocumentTemplate_InstanceID = Parameter.DOC_DocumentTemplate_InstanceID,
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                }).Single();
                #region Edit
                if (Parameter.IsDeleted == false)
                {
                    ORM_DOC_DocumentTemplate_2_BusinessParticipant template2BusinessParticipant = ORM_DOC_DocumentTemplate_2_BusinessParticipant.Query.Search(Connection, Transaction, new ORM_DOC_DocumentTemplate_2_BusinessParticipant.Query
                    {
                        DOC_DocumentTemplate_Instance_RefID = documentTemplateInstance.DOC_DocumentTemplate_InstanceID,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).Single();

                    template2BusinessParticipant.CMN_BPT_BusinessParticipant_RefID = Parameter.CMN_BPT_BusinessParticipant_RefID;
                    template2BusinessParticipant.Save(Connection, Transaction);

                    documentTemplateInstance.DisplayName = Parameter.DisplayName;
                    documentTemplateInstance.InstanceContent = Parameter.InstanceContent;
                    documentTemplateInstance.Modification_Timestamp = DateTime.Now;
                    documentTemplateInstance.Source_DocumentTemplate_RefID = Parameter.Source_DocumentTemplate_RefID;
                    documentTemplateInstance.Save(Connection, Transaction);
                }
                #endregion
                #region Delete
                else
                {
                    ORM_DOC_DocumentTemplate_2_BusinessParticipant template2BusinessParticipant = ORM_DOC_DocumentTemplate_2_BusinessParticipant.Query.Search(Connection, Transaction, new ORM_DOC_DocumentTemplate_2_BusinessParticipant.Query
                    {
                        DOC_DocumentTemplate_Instance_RefID = documentTemplateInstance.DOC_DocumentTemplate_InstanceID,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).Single();

                    documentTemplateInstance.IsDeleted = true;
                    documentTemplateInstance.Save(Connection, Transaction);

                    template2BusinessParticipant.IsDeleted = true;
                    template2BusinessParticipant.Save(Connection, Transaction);
                }
                #endregion

                returnValue.Result = documentTemplateInstance.DOC_DocumentTemplate_InstanceID;
            }

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5DO_SPS_1606 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5DO_SPS_1606 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5DO_SPS_1606 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5DO_SPS_1606 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_PrintingSettings",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5DO_SPS_1606 for attribute P_L5DO_SPS_1606
		[DataContract]
		public class P_L5DO_SPS_1606 
		{
			//Standard type parameters
			[DataMember]
			public Guid DOC_DocumentTemplate_InstanceID { get; set; } 
			[DataMember]
			public Guid Source_DocumentTemplate_RefID { get; set; } 
			[DataMember]
			public Guid CMN_BPT_BusinessParticipant_RefID { get; set; } 
			[DataMember]
			public String DisplayName { get; set; } 
			[DataMember]
			public String InstanceContent { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_PrintingSettings(,P_L5DO_SPS_1606 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_PrintingSettings.Invoke(connectionString,P_L5DO_SPS_1606 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_DoctorsAndStaff.Atomic.Manipulation.P_L5DO_SPS_1606();
parameter.DOC_DocumentTemplate_InstanceID = ...;
parameter.Source_DocumentTemplate_RefID = ...;
parameter.CMN_BPT_BusinessParticipant_RefID = ...;
parameter.DisplayName = ...;
parameter.InstanceContent = ...;
parameter.IsDeleted = ...;

*/
