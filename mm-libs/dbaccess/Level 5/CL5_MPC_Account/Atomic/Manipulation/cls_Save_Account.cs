/* 
 * Generated on 11.02.2015 15:37:39
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
using CL1_CMN_PER;
using CL1_CMN;
using CL1_CMN_BPT_USR;
using CL5_MPC_Account.Utils;
using CL1_HEC_CMT;

namespace CL5_MPC_Account.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Account.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Account
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5AC_SA_1046 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            var bp = new ORM_CMN_BPT_BusinessParticipant()
            {
                CMN_BPT_BusinessParticipantID = Guid.NewGuid(),
                Tenant_RefID = securityTicket.TenantID,
                IsNaturalPerson = true,
                IfNaturalPerson_CMN_PER_PersonInfo_RefID = Guid.NewGuid(),
                DisplayName = Parameter.Title + " " + Parameter.FirstName + " " + Parameter.LastName
            };
            bp.Save(Connection, Transaction);

            var personInfo = new ORM_CMN_PER_PersonInfo() 
            {
                CMN_PER_PersonInfoID = bp.IfNaturalPerson_CMN_PER_PersonInfo_RefID,
                Tenant_RefID = securityTicket.TenantID,
                Title = Parameter.Title,
                FirstName = Parameter.FirstName,
                LastName = Parameter.LastName,
                PrimaryEmail = Parameter.Email,
                Address_RefID = Guid.NewGuid()
            };
            personInfo.Save(Connection, Transaction);

            var address = new ORM_CMN_Address()
            {
                CMN_AddressID = personInfo.Address_RefID,
                Tenant_RefID = securityTicket.TenantID,
                Street_Name = Parameter.StreetName,
                Street_Number = Parameter.StreetNumber,
                City_Name = Parameter.CityName,
                City_PostalCode = Parameter.CityPostalCode,
                Country_Name = Parameter.CountryName
            };
            address.Save(Connection, Transaction);

            var bptUser = new ORM_CMN_BPT_USR_User()
            {
                CMN_BPT_USR_UserID = Guid.NewGuid(),
                Tenant_RefID = securityTicket.TenantID,
                BusinessParticipant_RefID = bp.CMN_BPT_BusinessParticipantID,
                Username = Parameter.Email
            };

            bptUser.Save(Connection, Transaction);

            var cryptoUtils = new CryptoUtils();
            string passSalt = cryptoUtils.GenerateRandomSalt(32);

            var bptUserPass = new ORM_CMN_BPT_USR_User_Password()
            {
                CMN_BPT_USR_User_PasswordID = Guid.NewGuid(),
                CMN_BPT_USR_User_RefID = bptUser.CMN_BPT_USR_UserID,
                Tenant_RefID = securityTicket.TenantID,
                Password_Salt = passSalt,
                Password_Hash = cryptoUtils.GenerateSaltedHash(Parameter.Password, passSalt),
                Password_Algorithm = cryptoUtils.GetHashAlgorithName(),
                IsActive = Parameter.IsActivated
            };

            bptUserPass.Save(Connection, Transaction);

            var community = ORM_HEC_CMT_Community.Query.Search(Connection, Transaction, new ORM_HEC_CMT_Community.Query() 
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                IsCommunityOperatedByThisTenant = true
            }).Single();


            var membershipType = ORM_HEC_CMT_Community_OfferedMembershipType.Query.Search(Connection, Transaction, new ORM_HEC_CMT_Community_OfferedMembershipType.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                IsAvailableFor_Tenants = Parameter.IsTenant,
                IsAvailableFor_Doctors = !Parameter.IsTenant
            }).Single();

            var member = new ORM_HEC_CMT_Membership()
            {
                CommunityMembershipITL = Guid.NewGuid().ToString(),
                HEC_CMT_MembershipID = Guid.NewGuid(),
                Tenant_RefID = securityTicket.TenantID,
                Community_RefID = community.HEC_CMT_CommunityID,
                MembershipType_RefID = membershipType.HEC_CMT_Community_OfferedMembershipTypeID,
                BusinessParticipant_RefID = bp.CMN_BPT_BusinessParticipantID
            };
            member.Save(Connection, Transaction);

            returnValue.Result = bptUser.CMN_BPT_USR_UserID;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5AC_SA_1046 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5AC_SA_1046 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AC_SA_1046 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AC_SA_1046 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Account",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5AC_SA_1046 for attribute P_L5AC_SA_1046
		[DataContract]
		public class P_L5AC_SA_1046 
		{
			//Standard type parameters
			[DataMember]
			public String Title { get; set; } 
			[DataMember]
			public String FirstName { get; set; } 
			[DataMember]
			public String LastName { get; set; } 
			[DataMember]
			public String Email { get; set; } 
			[DataMember]
			public String Phone { get; set; } 
			[DataMember]
			public String StreetName { get; set; } 
			[DataMember]
			public String StreetNumber { get; set; } 
			[DataMember]
			public String CityName { get; set; } 
			[DataMember]
			public String CityPostalCode { get; set; } 
			[DataMember]
			public String CountryName { get; set; } 
			[DataMember]
			public String Password { get; set; } 
			[DataMember]
			public bool IsTenant { get; set; } 
			[DataMember]
			public bool IsActivated { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Account(,P_L5AC_SA_1046 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Account.Invoke(connectionString,P_L5AC_SA_1046 Parameter,securityTicket);
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
var parameter = new CL5_MPC_Account.Atomic.Manipulation.P_L5AC_SA_1046();
parameter.Title = ...;
parameter.FirstName = ...;
parameter.LastName = ...;
parameter.Email = ...;
parameter.Phone = ...;
parameter.StreetName = ...;
parameter.StreetNumber = ...;
parameter.CityName = ...;
parameter.CityPostalCode = ...;
parameter.CountryName = ...;
parameter.Password = ...;
parameter.IsTenant = ...;
parameter.IsActivated = ...;

*/
