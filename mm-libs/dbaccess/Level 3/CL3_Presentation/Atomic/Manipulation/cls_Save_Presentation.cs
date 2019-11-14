/* 
 * Generated on 8/29/2014 9:44:30 AM
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
using CL1_CMN_CAL;
using CL1_CMN_CAL_EVT;

namespace CL3_Presentation.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Presentation.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Presentation
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L3PR_SP_1520 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
            //Put your code here

            #region Save
            if (Parameter.CMN_CAL_EVT_PresentationID == Guid.Empty)
            {
                ORM_CMN_CAL_Event presentationEvent = new ORM_CMN_CAL_Event();
                presentationEvent.CMN_CAL_EventID = Guid.NewGuid();
                presentationEvent.StartTime = Parameter.PresentationDate;
                presentationEvent.Tenant_RefID = securityTicket.TenantID;
                presentationEvent.IsDeleted = false;
                presentationEvent.Save(Connection, Transaction);

                ORM_CMN_CAL_EVT_Presentation presentation = new ORM_CMN_CAL_EVT_Presentation();
                presentation.CMN_CAL_EVT_PresentationID = Guid.NewGuid();
                presentation.Ext_CMN_CAL_Calendar_RefID = presentationEvent.CMN_CAL_EventID;
                presentation.MaximumNumberOfParticipants = Parameter.MaximumNumberOfParticipants;
                presentation.PresentationLocation = Parameter.PresentationLocation;
                presentation.PresentationTitle = Parameter.PresentationTitle;
                presentation.PresentationDescription = Parameter.PresentationDescription;
                presentation.IsFeaturedEvent = Parameter.IsFeaturedEvent;
                presentation.Tenant_RefID = securityTicket.TenantID;
                presentation.IsDeleted = false;
                presentation.Save(Connection, Transaction);

                ORM_CMN_CAL_EVT_Presenter presenter = new ORM_CMN_CAL_EVT_Presenter();
                presenter.CMN_CAL_EVT_PresenterID = Guid.NewGuid();
                presenter.Presentation_RefID = presentation.CMN_CAL_EVT_PresentationID;
                presenter.PresenterDisplayName = Parameter.PresenterDisplayName;
                presenter.Tenant_RefID = securityTicket.TenantID;
                presenter.IsDeleted = false;
                presenter.Save(Connection, Transaction);

                returnValue.Result = presentation.CMN_CAL_EVT_PresentationID;
            }
            #endregion
            else
            {
                var existingPresentation = ORM_CMN_CAL_EVT_Presentation.Query.Search(Connection, Transaction, new ORM_CMN_CAL_EVT_Presentation.Query
                {
                    CMN_CAL_EVT_PresentationID = Parameter.CMN_CAL_EVT_PresentationID,
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                }).Single();
                var existingEventDate = ORM_CMN_CAL_Event.Query.Search(Connection, Transaction, new ORM_CMN_CAL_Event.Query
                {
                    CMN_CAL_EventID = existingPresentation.Ext_CMN_CAL_Calendar_RefID,
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                }).Single();
                var existingPresenter = ORM_CMN_CAL_EVT_Presenter.Query.Search(Connection, Transaction, new ORM_CMN_CAL_EVT_Presenter.Query
                {
                    Presentation_RefID = existingPresentation.CMN_CAL_EVT_PresentationID,
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                }).Single();
                #region Edit
                if (!Parameter.IsDeleted)
                {
                    existingPresentation.MaximumNumberOfParticipants = Parameter.MaximumNumberOfParticipants;
                    existingPresentation.PresentationLocation = Parameter.PresentationLocation;
                    existingPresentation.PresentationTitle = Parameter.PresentationTitle;
                    existingPresentation.PresentationDescription = Parameter.PresentationDescription;
                    existingPresentation.IsFeaturedEvent = Parameter.IsFeaturedEvent;

                    existingEventDate.StartTime = Parameter.PresentationDate;
                    existingPresenter.PresenterDisplayName = Parameter.PresenterDisplayName;
                }
                #endregion
                #region Delete
                else
                {
                    existingPresentation.IsDeleted = true;
                    existingEventDate.IsDeleted = true;
                    existingPresenter.IsDeleted = true;
                }
                #endregion

                existingEventDate.Save(Connection, Transaction);
                existingPresenter.Save(Connection, Transaction);
                existingPresentation.Save(Connection, Transaction);
                returnValue.Result = existingPresentation.CMN_CAL_EVT_PresentationID;
            }
            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L3PR_SP_1520 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L3PR_SP_1520 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L3PR_SP_1520 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3PR_SP_1520 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Presentation",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3PR_SP_1520 for attribute P_L3PR_SP_1520
		[DataContract]
		public class P_L3PR_SP_1520 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_CAL_EVT_PresentationID { get; set; } 
			[DataMember]
			public String PresentationLocation { get; set; } 
			[DataMember]
			public int MaximumNumberOfParticipants { get; set; } 
			[DataMember]
			public Dict PresentationTitle { get; set; } 
			[DataMember]
			public Dict PresentationDescription { get; set; } 
			[DataMember]
			public DateTime PresentationDate { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 
			[DataMember]
			public bool IsFeaturedEvent { get; set; } 
			[DataMember]
			public String PresenterDisplayName { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Presentation(,P_L3PR_SP_1520 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Presentation.Invoke(connectionString,P_L3PR_SP_1520 Parameter,securityTicket);
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
var parameter = new CL3_Event.Atomic.Manipulation.P_L3PR_SP_1520();
parameter.CMN_CAL_EVT_PresentationID = ...;
parameter.PresentationLocation = ...;
parameter.MaximumNumberOfParticipants = ...;
parameter.PresentationTitle = ...;
parameter.PresentationDescription = ...;
parameter.PresentationDate = ...;
parameter.IsDeleted = ...;
parameter.IsFeaturedEvent = ...;
parameter.PresenterDisplayName = ...;

*/
