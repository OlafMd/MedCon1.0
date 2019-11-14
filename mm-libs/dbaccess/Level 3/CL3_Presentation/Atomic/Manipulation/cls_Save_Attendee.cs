/* 
 * Generated on 13.10.2014 15:19:51
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
using CL1_CMN_CAL_EVT;
using CL1_CMN;

namespace CL3_Presentation.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Attendee.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Attendee
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L3PR_SA_1744 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            #region Save

            if (Parameter.IsDeleted)
            {
                if (ORM_CMN_CAL_EVT_Presentation_ExternalParticipant.Query.Search(Connection, Transaction, new ORM_CMN_CAL_EVT_Presentation_ExternalParticipant.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    CMN_CAL_EVT_Presentation_ParticipantID = Parameter.PresentationID,
                    IsDeleted = false
                }).Count != 1)
                {
                    returnValue.Status = FR_Status.Error_Internal;
                }
                else
                {
                    var presentation_ExternalParticipant = ORM_CMN_CAL_EVT_Presentation_ExternalParticipant.Query.Search(Connection, Transaction, new ORM_CMN_CAL_EVT_Presentation_ExternalParticipant.Query
                    {
                        Tenant_RefID = securityTicket.TenantID,
                        CMN_CAL_EVT_Presentation_ParticipantID = Parameter.PresentationID,
                        IsDeleted = false
                    }).Single();
                    presentation_ExternalParticipant.IsDeleted = true;
                    presentation_ExternalParticipant.Save(Connection, Transaction);

                    returnValue.Result = presentation_ExternalParticipant.CMN_CAL_EVT_Presentation_ParticipantID;
                }
            }
            else 
            {
                if (Parameter.CMN_UniversalContactDetailID == Guid.Empty)
                {
                    ORM_CMN_UniversalContactDetail ucd = new ORM_CMN_UniversalContactDetail()
                    {
                        CMN_UniversalContactDetailID = Guid.NewGuid(),
                        Tenant_RefID = securityTicket.TenantID,
                        First_Name = Parameter.FirstName,
                        Last_Name = Parameter.LastName,
                        Contact_Email = Parameter.Email,
                        Contact_Telephone = Parameter.Phone
                    };
                    ucd.Save(Connection, Transaction);

                    ORM_CMN_CAL_EVT_Presentation_ExternalParticipant presentationParticipant = new ORM_CMN_CAL_EVT_Presentation_ExternalParticipant()
                    {
                        CMN_CAL_EVT_Presentation_ParticipantID = Guid.NewGuid(),
                        Tenant_RefID = securityTicket.TenantID,
                        IsRegisteredThroughWebsite = true,
                        RegistrationDate = DateTime.Now,
                        Presentation_RefID = Parameter.PresentationID,
                        Participant_UCD_RefID = ucd.CMN_UniversalContactDetailID
                    };
                    presentationParticipant.Save(Connection, Transaction);

                    returnValue.Result = presentationParticipant.CMN_CAL_EVT_Presentation_ParticipantID;
                }
            }
            #endregion
            
            #endregion
            return returnValue;
			#endregion UserCode
		}
		
		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L3PR_SA_1744 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L3PR_SA_1744 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L3PR_SA_1744 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3PR_SA_1744 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Attendee",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3PR_SA_1744 for attribute P_L3PR_SA_1744
		[DataContract]
		public class P_L3PR_SA_1744 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_UniversalContactDetailID { get; set; } 
			[DataMember]
			public Guid PresentationID { get; set; } 
			[DataMember]
			public String FirstName { get; set; } 
			[DataMember]
			public String LastName { get; set; } 
			[DataMember]
			public String Email { get; set; } 
			[DataMember]
			public String Phone { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Attendee(,P_L3PR_SA_1744 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Attendee.Invoke(connectionString,P_L3PR_SA_1744 Parameter,securityTicket);
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
var parameter = new CL3_Presentation.Atomic.Manipulation.P_L3PR_SA_1744();
parameter.CMN_UniversalContactDetailID = ...;
parameter.PresentationID = ...;
parameter.FirstName = ...;
parameter.LastName = ...;
parameter.Email = ...;
parameter.Phone = ...;
parameter.IsDeleted = ...;

*/
