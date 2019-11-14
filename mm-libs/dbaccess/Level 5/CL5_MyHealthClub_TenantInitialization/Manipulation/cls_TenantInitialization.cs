/* 
 * Generated on 31.01.2015 11:39:57
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
using CL2_Language.Atomic.Retrieval;
using CL1_APP;
using CL2_Contact.DomainManagement;
using CL1_CMN_CAL_AVA;
using DLCore_DBCommons.Utils;
using DLCore_DBCommons.MyHealthClub;
using CL1_CMN_PER;
using CL2_PatientParameters;
using CL2_PatientParameters.Complex.Retrieval;
using CL2_Contact.Complex.Retrieval;

namespace CL5_MyHealthClub_TenantInitialization.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_TenantInitialization.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_TenantInitialization
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Bool Execute(DbConnection Connection,DbTransaction Transaction,P_L5TI_TI_1134 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Bool();

            #region Get and update languages

            var init = ORM_APP_Initialization.Query.Search(Connection, Transaction, new ORM_APP_Initialization.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                Application_RefID = Parameter.AppID
            }).SingleOrDefault();

            if (init == null)
            {
                init = new ORM_APP_Initialization()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    Application_RefID = Parameter.AppID,
                    APP_InitializationID = Guid.NewGuid(),
                    Initialization_StartedAtDate = DateTime.Now,
                    Version = "1.0"
                };
            }

            var DBLanguages = cls_Get_All_Languages.Invoke(Connection, Transaction, securityTicket).Result;

            #endregion

            #region EComunactionContactType
            // Get all communication types from db.
            //var comunactionContactTypes = Enum.GetValues(typeof(EComunactionContactType));
            // Just this communication types can be inserted, if we want all, then use line above
            List<EComunactionContactType> comunactionContactTypes = new List<EComunactionContactType> { EComunactionContactType.Phone, EComunactionContactType.Email, EComunactionContactType.Fax, EComunactionContactType.Mobile };

            foreach (EComunactionContactType type in comunactionContactTypes)
            {
                P_L2CN_GCTIDfGPMID_1359 parameter = new P_L2CN_GCTIDfGPMID_1359();
                parameter.Type = EnumUtils.GetEnumDescription(type);
                var contactTypeResult = cls_Get_ContantTypeID_for_GlobalPropertyMatchingID.Invoke(Connection, Transaction, parameter, securityTicket).Result;

                //switch (type)
                //{
                //    // Just this communication types can be inserted
                //    case EComunactionContactType.Phone:
                //        {
                //            bool doesStatusExist = ORM_CMN_PER_CommunicationContact_Type.Query.Exists(Connection, Transaction,
                //                new ORM_CMN_PER_CommunicationContact_Type.Query
                //                {
                //                    Type = EnumUtils.GetEnumDescription(type),
                //                    Tenant_RefID = securityTicket.TenantID,
                //                    IsDeleted = false
                //                });

                //            if (!doesStatusExist)
                //            {
                //                var communicationContactType = new ORM_CMN_PER_CommunicationContact_Type();
                //                communicationContactType.Type = EnumUtils.GetEnumDescription(type);
                //                communicationContactType.Tenant_RefID = securityTicket.TenantID;
                //                communicationContactType.Save(Connection, Transaction);
                //            }
                //        }
                //        break;
                //    case EComunactionContactType.Email:
                //        {
                //            bool doesStatusExist = ORM_CMN_PER_CommunicationContact_Type.Query.Exists(Connection, Transaction,
                //                new ORM_CMN_PER_CommunicationContact_Type.Query
                //                {
                //                    Type = EnumUtils.GetEnumDescription(type),
                //                    Tenant_RefID = securityTicket.TenantID,
                //                    IsDeleted = false
                //                });

                //            if (!doesStatusExist)
                //            {
                //                var communicationContactType = new ORM_CMN_PER_CommunicationContact_Type();
                //                communicationContactType.Type = EnumUtils.GetEnumDescription(type);
                //                communicationContactType.Tenant_RefID = securityTicket.TenantID;
                //                communicationContactType.Save(Connection, Transaction);
                //            }
                //        }
                //        break;
                //    case EComunactionContactType.Fax:
                //        {
                //            bool doesStatusExist = ORM_CMN_PER_CommunicationContact_Type.Query.Exists(Connection, Transaction,
                //                new ORM_CMN_PER_CommunicationContact_Type.Query
                //                {
                //                    Type = EnumUtils.GetEnumDescription(type),
                //                    Tenant_RefID = securityTicket.TenantID,
                //                    IsDeleted = false
                //                });

                //            if (!doesStatusExist)
                //            {
                //                var communicationContactType = new ORM_CMN_PER_CommunicationContact_Type();
                //                communicationContactType.Type = EnumUtils.GetEnumDescription(type);
                //                communicationContactType.Tenant_RefID = securityTicket.TenantID;
                //                communicationContactType.Save(Connection, Transaction);
                //            }
                //        }
                //        break;
                //    case EComunactionContactType.Mobile:
                //        {
                //            bool doesStatusExist = ORM_CMN_PER_CommunicationContact_Type.Query.Exists(Connection, Transaction,
                //                new ORM_CMN_PER_CommunicationContact_Type.Query
                //                {
                //                    Type = EnumUtils.GetEnumDescription(type),
                //                    Tenant_RefID = securityTicket.TenantID,
                //                    IsDeleted = false
                //                });

                //            if (!doesStatusExist)
                //            {
                //                var communicationContactType = new ORM_CMN_PER_CommunicationContact_Type();
                //                communicationContactType.Type = EnumUtils.GetEnumDescription(type);
                //                communicationContactType.Tenant_RefID = securityTicket.TenantID;
                //                communicationContactType.Save(Connection, Transaction);
                //            }
                //        }
                //        break;
                //}
            }
            #endregion

            #region AvailabilityTypes

            var query = new ORM_CMN_CAL_AVA_Availability_Type.Query();
            query.IsDeleted = false;
            query.Tenant_RefID = securityTicket.TenantID;

            var Availability = ORM_CMN_CAL_AVA_Availability_Type.Query.Search(Connection, Transaction, query);

            if (Availability.Count == 0)
            {

                ORM_CMN_CAL_AVA_Availability_Type Availability_Exceptions = new ORM_CMN_CAL_AVA_Availability_Type();
                Availability_Exceptions.CMN_CAL_AVA_Availability_TypeID = Guid.NewGuid();
                Availability_Exceptions.IsDefaultAvailabilityType = true;
                Availability_Exceptions.GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(AvailabilityType.Exception);

                Dict name2 = new Dict("CMN_CAL_AVA_Availability_Type");
                for (int i = 0; i < DBLanguages.Count(); i++)
                {
                    name2.AddEntry(DBLanguages[i].CMN_LanguageID, EnumUtils.GetEnumDescription(AvailabilityType.Exception));
                }

                Availability_Exceptions.AvailabilityTypeName = name2;
                Availability_Exceptions.Tenant_RefID = securityTicket.TenantID;
                Availability_Exceptions.Creation_Timestamp = DateTime.Now;
                Availability_Exceptions.Save(Connection, Transaction);


                ORM_CMN_CAL_AVA_Availability_Type Availability_StandardHour = new ORM_CMN_CAL_AVA_Availability_Type();
                Availability_StandardHour.CMN_CAL_AVA_Availability_TypeID = Guid.NewGuid();
                Availability_StandardHour.IsDefaultAvailabilityType = true;
                Availability_StandardHour.GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(AvailabilityType.Standard);

                Dict name = new Dict("CMN_CAL_AVA_Availability_Type");
                for (int i = 0; i < DBLanguages.Count(); i++)
                {
                    name.AddEntry(DBLanguages[i].CMN_LanguageID, EnumUtils.GetEnumDescription(AvailabilityType.Standard));
                }

                Availability_StandardHour.AvailabilityTypeName = name;
                Availability_StandardHour.Tenant_RefID = securityTicket.TenantID;
                Availability_StandardHour.Creation_Timestamp = DateTime.Now;
                Availability_StandardHour.Save(Connection, Transaction);

                ORM_CMN_CAL_AVA_Availability_Type Availability_WebBookingHour = new ORM_CMN_CAL_AVA_Availability_Type();
                Availability_WebBookingHour.CMN_CAL_AVA_Availability_TypeID = Guid.NewGuid();
                Availability_WebBookingHour.IsDefaultAvailabilityType = true;
                Availability_WebBookingHour.GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(AvailabilityType.WebBooking);

                Dict name1 = new Dict("CMN_CAL_AVA_Availability_Type");
                for (int i = 0; i < DBLanguages.Count(); i++)
                {
                    name1.AddEntry(DBLanguages[i].CMN_LanguageID, EnumUtils.GetEnumDescription(AvailabilityType.WebBooking));
                }

                Availability_WebBookingHour.AvailabilityTypeName = name1;
                Availability_WebBookingHour.Tenant_RefID = securityTicket.TenantID;
                Availability_WebBookingHour.Creation_Timestamp = DateTime.Now;
                Availability_WebBookingHour.Save(Connection, Transaction);

            }
            #endregion

            #region PatinetParameters
            var PatientParameter = cls_Get_all_PatientParameters_for_Tenant.Invoke(Connection, Transaction, securityTicket).Result;
            #endregion

            init.Initialiaztion_CompletedAtDate = DateTime.Now;
            init.IsInitializationComplete = true;
            init.Save(Connection, Transaction);

            returnValue.Result = true;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Bool Invoke(string ConnectionString,P_L5TI_TI_1134 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection,P_L5TI_TI_1134 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction,P_L5TI_TI_1134 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5TI_TI_1134 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Bool functionReturn = new FR_Bool();
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

				throw new Exception("Exception occured in method cls_TenantInitialization",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5TI_TI_1134 for attribute P_L5TI_TI_1134
		[DataContract]
		public class P_L5TI_TI_1134 
		{
			//Standard type parameters
			[DataMember]
			public Guid AppID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Bool cls_TenantInitialization(,P_L5TI_TI_1134 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Bool invocationResult = cls_TenantInitialization.Invoke(connectionString,P_L5TI_TI_1134 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_TenantInitialization.Atomic.Manipulation.P_L5TI_TI_1134();
parameter.AppID = ...;

*/
