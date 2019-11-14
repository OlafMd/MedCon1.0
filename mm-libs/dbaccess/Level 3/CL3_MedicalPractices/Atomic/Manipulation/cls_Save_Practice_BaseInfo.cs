/* 
 * Generated on 9/4/2013 12:48:12 PM
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
using CL1_HEC;
using CL1_CMN_COM;
using CL1_CMN_BPT;
using CL1_CMN;

namespace CL3_MedicalPractices.Atomic.Manipulation
{
	/// <summary>
    /// No description found in <meta/> tag
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Practice_BaseInfo.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Practice_BaseInfo
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L3MP_SPBI_1602 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            ORM_HEC_MedicalPractis practices;
            if (Parameter.HEC_MedicalPractiseID != Guid.Empty)
            {
                var practicesQuery = new ORM_HEC_MedicalPractis.Query();
                practicesQuery.HEC_MedicalPractiseID = Parameter.HEC_MedicalPractiseID;
                practices = ORM_HEC_MedicalPractis.Query.Search(Connection, Transaction, practicesQuery).First();
            }
            else
            {
                practices = new ORM_HEC_MedicalPractis();
                practices.HEC_MedicalPractiseID = Guid.NewGuid();
            }
            practices.Tenant_RefID = securityTicket.TenantID;
            if (Parameter.isLucentis == false)
            practices.Contact_EmergencyPhoneNumber = Parameter.Contact_EmergencyPhoneNumber;

            ORM_CMN_COM_CompanyInfo companyInfo;
            if (practices.Ext_CompanyInfo_RefID != Guid.Empty)
            {
                var companyInfoQuery = new ORM_CMN_COM_CompanyInfo.Query();
                companyInfoQuery.CMN_COM_CompanyInfoID = practices.Ext_CompanyInfo_RefID;
                companyInfo = ORM_CMN_COM_CompanyInfo.Query.Search(Connection, Transaction, companyInfoQuery).First();
            }
            else
            {
                companyInfo = new ORM_CMN_COM_CompanyInfo();
                companyInfo.CMN_COM_CompanyInfoID = Guid.NewGuid();
                practices.Ext_CompanyInfo_RefID = companyInfo.CMN_COM_CompanyInfoID;
            }
            companyInfo.Tenant_RefID = securityTicket.TenantID;
            if(Parameter.isLucentis)
                companyInfo.CompanyInfo_EstablishmentNumber = Parameter.ifLucentis_BSNR;            

            ORM_CMN_BPT_BusinessParticipant bParticipant;
            var bParticipantQuery = new ORM_CMN_BPT_BusinessParticipant.Query();
            bParticipantQuery.IfCompany_CMN_COM_CompanyInfo_RefID = companyInfo.CMN_COM_CompanyInfoID;
            var bpRes = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, bParticipantQuery);
            if (bpRes.Count == 0)
            {
                bParticipant = new ORM_CMN_BPT_BusinessParticipant();
                bParticipant.CMN_BPT_BusinessParticipantID = Guid.NewGuid();
                bParticipant.IsCompany = true;
                bParticipant.IfCompany_CMN_COM_CompanyInfo_RefID = companyInfo.CMN_COM_CompanyInfoID;
            }
            else
            {
                bParticipant = bpRes.First();
            }
            bParticipant.DisplayName = Parameter.PracticeName;
            bParticipant.Tenant_RefID = securityTicket.TenantID;
            

            ORM_CMN_UniversalContactDetail contactDetails;
            if (companyInfo.Contact_UCD_RefID != Guid.Empty)
            {
                var ucdQuery = new ORM_CMN_UniversalContactDetail.Query();
                ucdQuery.CMN_UniversalContactDetailID = companyInfo.Contact_UCD_RefID;
                contactDetails = ORM_CMN_UniversalContactDetail.Query.Search(Connection, Transaction, ucdQuery).First();
            }
            else
            {
                contactDetails = new ORM_CMN_UniversalContactDetail();
                contactDetails.CMN_UniversalContactDetailID = Guid.NewGuid();
                companyInfo.Contact_UCD_RefID = contactDetails.CMN_UniversalContactDetailID;
                contactDetails.IsCompany = true;
            }
            contactDetails.Tenant_RefID = securityTicket.TenantID;
            if (Parameter.isLucentis == false)
            contactDetails.Contact_Website_URL = Parameter.Contact_Website_URL;
            contactDetails.Contact_Email = Parameter.PracticeEmail;
            contactDetails.Town = Parameter.Town;
            contactDetails.Street_Number = Parameter.Street_Number;
            contactDetails.Street_Name = Parameter.Street_Name;
            contactDetails.ZIP = Parameter.ZIP;
            if (Parameter.isLucentis==false)
            contactDetails.Region_Name = Parameter.Region_Name;
            if (Parameter.isLucentis)
            contactDetails.Street_Name_Line2 = Parameter.Street_Name_Line2;

            companyInfo.Save(Connection, Transaction);
            bParticipant.Save(Connection, Transaction);
            contactDetails.Save(Connection, Transaction);
            practices.Save(Connection, Transaction);

            returnValue.Result = practices.HEC_MedicalPractiseID;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L3MP_SPBI_1602 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L3MP_SPBI_1602 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L3MP_SPBI_1602 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3MP_SPBI_1602 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Practice_BaseInfo",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3MP_SPBI_1602 for attribute P_L3MP_SPBI_1602
		[DataContract]
		public class P_L3MP_SPBI_1602 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_MedicalPractiseID { get; set; } 
			[DataMember]
			public String Street_Number { get; set; } 
			[DataMember]
			public String Street_Name { get; set; } 
			[DataMember]
			public String CompanyName_Line1 { get; set; } 
			[DataMember]
			public String PracticeName { get; set; } 
			[DataMember]
			public bool isLucentis { get; set; } 
			[DataMember]
			public String ifLucentis_BSNR { get; set; } 
			[DataMember]
			public String Street_Name_Line2 { get; set; } 
			[DataMember]
			public String PracticeEmail { get; set; } 
			[DataMember]
			public String Town { get; set; } 
			[DataMember]
			public String ZIP { get; set; } 
			[DataMember]
			public String Contact_EmergencyPhoneNumber { get; set; } 
			[DataMember]
			public String Contact_Website_URL { get; set; } 
			[DataMember]
			public String Region_Name { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Practice_BaseInfo(,P_L3MP_SPBI_1602 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = VerifySessionToken(sessionToken);
		FR_Guid invocationResult = cls_Save_Practice_BaseInfo.Invoke(connectionString,P_L3MP_SPBI_1602 Parameter,securityTicket);
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
var parameter = new CL3_MedicalPractices.Atomic.Manipulation.P_L3MP_SPBI_1602();
parameter.HEC_MedicalPractiseID = ...;
parameter.Street_Number = ...;
parameter.Street_Name = ...;
parameter.CompanyName_Line1 = ...;
parameter.PracticeName = ...;
parameter.isLucentis = ...;
parameter.ifLucentis_BSNR = ...;
parameter.Street_Name_Line2 = ...;
parameter.PracticeEmail = ...;
parameter.Town = ...;
parameter.ZIP = ...;
parameter.Contact_EmergencyPhoneNumber = ...;
parameter.Contact_Website_URL = ...;
parameter.Region_Name = ...;

*/
